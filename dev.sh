#!/bin/bash

# Script para manejar el entorno de desarrollo con Docker

set -e

case "$1" in
    "up")
        echo "🚀 Iniciando entorno de desarrollo..."
        docker compose -f docker-compose-dev.yml up -d --build
        echo "✅ Entorno iniciado!"
        echo "📝 API disponible en: http://localhost:5244"
        echo "🗄️ phpMyAdmin disponible en: http://localhost:8080"
        ;;
    "down")
        echo "🛑 Deteniendo entorno de desarrollo..."
        docker compose -f docker-compose-dev.yml down
        echo "✅ Entorno detenido!"
        ;;
    "logs")
        echo "📋 Mostrando logs..."
        docker compose -f docker-compose-dev.yml logs -f
        ;;
    "restart")
        echo "🔄 Reiniciando entorno..."
        docker compose -f docker-compose-dev.yml down
        docker compose -f docker-compose-dev.yml up -d --build
        echo "✅ Entorno reiniciado!"
        ;;
    "migrate")
        echo "🗄️ Ejecutando migraciones..."
        docker compose -f docker-compose-dev.yml exec webapi dotnet ef database update
        echo "✅ Migraciones aplicadas!"
        ;;
    "shell")
        echo "🐚 Abriendo shell en el contenedor..."
        docker compose -f docker-compose-dev.yml exec webapi bash
        ;;
    "clean")
        echo "🧹 Limpiando contenedores y volúmenes..."
        docker compose -f docker-compose-dev.yml down -v
        docker system prune -f
        echo "✅ Limpieza completa!"
        ;;
    *)
        echo "📖 Uso: $0 {up|down|logs|restart|migrate|shell|clean}"
        echo ""
        echo "Comandos disponibles:"
        echo "  up       - Inicia el entorno de desarrollo"
        echo "  down     - Detiene el entorno de desarrollo"
        echo "  logs     - Muestra los logs en tiempo real"
        echo "  restart  - Reinicia el entorno completo"
        echo "  migrate  - Ejecuta las migraciones de la BD"
        echo "  shell    - Abre una shell en el contenedor de la API"
        echo "  clean    - Limpia contenedores y volúmenes"
        exit 1
        ;;
esac
