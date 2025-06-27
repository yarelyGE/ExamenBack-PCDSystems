# Entorno de Desarrollo con Docker

Este proyecto incluye un entorno de desarrollo completo con Docker que incluye:

- **API .NET 8**: Tu aplicación Web API
- **MySQL 8.0**: Base de datos
- **phpMyAdmin**: Interfaz web para administrar la base de datos

## 🚀 Inicio Rápido

### Prerrequisitos
- Docker
- Docker Compose

### Comandos Principales

```bash
# Iniciar el entorno de desarrollo
./dev.sh up

# Detener el entorno
./dev.sh down

# Ver logs en tiempo real
./dev.sh logs

# Reiniciar el entorno completo
./dev.sh restart

# Ejecutar migraciones
./dev.sh migrate

# Abrir shell en el contenedor de la API
./dev.sh shell

# Limpiar contenedores y volúmenes
./dev.sh clean
```

### Acceso a los Servicios

- **API**: http://localhost:5244
- **Swagger UI**: http://localhost:5244/swagger
- **phpMyAdmin**: http://localhost:8080
  - Usuario: `root`
  - Contraseña: `root1234`

## 🛠️ Desarrollo

### Hot Reload
El entorno está configurado para **hot reload**, lo que significa que los cambios en tu código se reflejarán automáticamente sin necesidad de reconstruir el contenedor.

### Migraciones
Para ejecutar migraciones de Entity Framework:
```bash
./dev.sh migrate
```

### Acceso a la Base de Datos
La base de datos está disponible en:
- **Host**: localhost
- **Puerto**: 3306
- **Usuario**: root
- **Contraseña**: root1234
- **Base de datos**: examen

### Debugging
Para hacer debugging, puedes:
1. Usar el shell del contenedor: `./dev.sh shell`
2. Ver los logs: `./dev.sh logs`
3. Conectarte a la base de datos usando phpMyAdmin

## 📁 Estructura de Archivos Docker

- `docker-compose-dev.yml`: Configuración de servicios para desarrollo
- `Dockerfile.dev`: Dockerfile optimizado para desarrollo con hot reload
- `dev.sh`: Script de utilidades para manejar el entorno
- `.dockerignore`: Archivos a ignorar en el contexto de Docker

## 🔧 Personalización

### Variables de Entorno
Puedes modificar las variables de entorno en `docker-compose-dev.yml`:

```yaml
environment:
  - ASPNETCORE_ENVIRONMENT=Development
  - ConnectionStrings__WebinarDB=Server=mysql;user=root;password=root1234;database=examen
```

### Puertos
Los puertos pueden modificarse en `docker-compose-dev.yml`:
- API: `5244:5000`
- MySQL: `3306:3306`  
- phpMyAdmin: `8080:80`

## 🐛 Troubleshooting

### La API no inicia
```bash
./dev.sh logs
```

### Problemas con la base de datos
```bash
# Reiniciar solo MySQL
docker compose -f docker-compose-dev.yml restart mysql

# Limpiar volúmenes y reiniciar
./dev.sh clean
./dev.sh up
```

### Puertos ocupados
Si algún puerto está ocupado, puedes cambiarlos en `docker-compose-dev.yml` o detener el servicio que los está usando.

## 📝 Notas Importantes

1. **Persistencia**: Los datos de MySQL se persisten en un volumen Docker
2. **Hot Reload**: Los cambios en el código se reflejan automáticamente
3. **Migraciones**: Usar `./dev.sh migrate` para aplicar cambios en la BD
4. **Logs**: Usar `./dev.sh logs` para ver logs de todos los servicios
