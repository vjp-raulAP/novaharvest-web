# NovaHarvest

## 1. Arranque

### Ejecutar con Docker

Para iniciar NovaHarvest, abrimos una terminal en la carpeta principal del proyecto y ejecutamos:

    docker compose up -d --build

Para comprobar que los contenedores están funcionando:

    docker compose ps

Accedemos a la aplicación desde el navegador:

- **Inicio:** http://localhost:8080/
- **Acerca de:** http://localhost:8080/about
- **Estado del servidor:** http://localhost:8080/status
- **Hoja de estilos:** http://localhost:8080/css/site.css
- **Logotipo:** http://localhost:8080/img/logo.png

Para detener los contenedores:

    docker compose down

### Ejecutar sin Docker

Entramos en la carpeta del backend:

    cd backend/NovaHarvest.Web

Ejecutamos la aplicación:

    dotnet run

La aplicación se ejecuta directamente mediante Kestrel. Para acceder a ella, utilizamos la dirección que aparece en la terminal al iniciar el servidor.

Para detenerla, pulsamos `Ctrl + C`.

## 2. Arquitectura

NovaHarvest utiliza Nginx como proxy inverso y ASP.NET Core como backend.

El navegador envía las peticiones a Nginx, que las recibe por el puerto 80 del contenedor web, publicado en el puerto 8080 del equipo. Después, Nginx reenvía las peticiones al backend mediante el puerto 8080 de la red interna de Docker.

El backend utiliza ASP.NET Core y Kestrel para procesar las peticiones y generar las páginas HTML.

### Diagrama de arquitectura

    ```mermaid
flowchart TD
    A["🌐 NAVEGADOR<br/>localhost:8080"]

    subgraph DOCKER["🐳 ENTORNO DOCKER"]
        B["🌍 WEB<br/>NGINX<br/>Puerto 80"]
        C["⚙️ BACKEND<br/>ASP.NET Core<br/>KESTREL · Puerto 8080"]

        B -->|"Proxy inverso<br/>backend:8080"| C
    end

    A -->|"Petición HTTP"| B
    C -->|"Respuesta HTTP"| A

    style A fill:#dbeafe,stroke:#2563eb,color:#1e3a8a
    style B fill:#dcfce7,stroke:#16a34a,color:#14532d
    style C fill:#fef3c7,stroke:#d97706,color:#78350f
    style DOCKER fill:#f8fafc,stroke:#64748b,color:#1e293b
```

### Recorrido de una petición

1. El usuario introduce una dirección en el navegador.
2. Nginx recibe la petición a través del puerto 8080 del equipo.
3. Nginx reenvía la petición al backend por la red interna de Docker.
4. Kestrel procesa la petición y ejecuta el código C# correspondiente.
5. El backend devuelve la respuesta a Nginx.
6. Nginx entrega la respuesta al navegador.