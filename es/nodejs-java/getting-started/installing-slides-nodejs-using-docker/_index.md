---
title: Instalar Aspose.Slides para Node.js mediante Java usando Docker
type: docs
weight: 75
url: /es/nodejs-java/installing-slides-nodejs-using-docker/
keywords:
- descargar Aspose.Slides
- instalar Aspose.Slides
- instalación de Aspose.Slides
- Docker
- Windows
- macOS
- Linux
- compatibilidad multiplataforma
- aislamiento de dependencias
- despliegue simplificado
- configuración del proyecto
- PowerPoint
- OpenDocument
- presentación
- Node.js
- JavaScript
- Aspose.Slides
description: "Ejecute Aspose.Slides en contenedores Docker: configure imágenes, dependencias, fuentes y licencias para crear servicios escalables que procesen PowerPoint y OpenDocument."
---

## Requisitos:
* Instala Docker en tu máquina. Puedes seguir la guía oficial de instalación [aquí](https://docs.docker.com/get-docker/).

## Pasos:

### 1. **Crear Dockerfile** 
   Crea un nuevo archivo llamado Dockerfile en el directorio de tu proyecto con el siguiente contenido:
   # Utiliza Ubuntu 20.04 como imagen base
   FROM ubuntu:20.04

   # Actualiza la lista de paquetes e instala los paquetes esenciales para añadir repositorios y descargar archivos
   RUN apt-get update && \
      apt-get install -y curl gnupg2 software-properties-common && \
      rm -rf /var/lib/apt/lists/*

   # Instala Node.js versión 18.x desde el repositorio Nodesource
   RUN curl -fsSL https://deb.nodesource.com/setup_22.x | bash - && \
      apt-get install -y nodejs && \
      rm -rf /var/lib/apt/lists/*

   # Instala Python 2.x, que es necesario para algunos paquetes npm como node-gyp
   RUN apt-get update && \
      apt-get install -y python2 && \
      rm -rf /var/lib/apt/lists/*

   # Instala OpenJDK 11, que es necesario para las dependencias Java de Aspose.Slides
   RUN apt-get update && \
      apt-get install -y openjdk-11-jdk && \
      rm -rf /var/lib/apt/lists/*

   # Instala el paquete build-essential, que incluye herramientas como 'make' necesarias para compilar módulos nativos
   RUN apt-get update && \
      apt-get install -y build-essential && \
      rm -rf /var/lib/apt/lists/*

   # Instala node-gyp globalmente, una herramienta utilizada para compilar complementos nativos para Node.js
   RUN npm install -g node-gyp

   # Establece el directorio de trabajo dentro del contenedor en /app
   WORKDIR /app

   # Crea el archivo package.json con los detalles y dependencias necesarios
   RUN echo '{\n\
     "name": "aspose-slides-app",\n\
     "version": "1.0.0",\n\
     "main": "index.js",\n\
     "scripts": {\n\
      "start": "node index.js"\n\
     },\n\
     "dependencies": {\n\
      "aspose.slides.via.java": "^25.12.0"\n\
     }\n\
   }' > package.json

   # Crea el archivo index.js con código de ejemplo para crear una presentación usando Aspose.Slides
   RUN echo 'const slides = require("aspose.slides.via.java");\n\
   var presentation = new slides.Presentation();\n\
   var slide = presentation.getSlides().get_Item(0);\n\
   slide.getShapes().addAutoShape(slides.ShapeType.Line, 50, 150, 300, 0);\n\
   presentation.save("./NewPresentation.pptx", slides.SaveFormat.Pptx);\n\
   console.log("Script completed, please check file /app/NewPresentation.pptx!");' > index.js

   # Instala el paquete Aspose.Slides vía Java especificado en package.json
   RUN npm install aspose.slides.via.java

   # Establece el comando predeterminado para ejecutar la aplicación cuando el contenedor se inicie
   CMD ["node", "index.js"]
```


### 2. **Construir Imagen Docker**
   Ejecuta el siguiente comando en el directorio donde se encuentra tu Dockerfile para construir la imagen Docker:
```bash
docker build -t aspose-slides-nodejs .
```


### 3. **Ejecutar Contenedor Docker**
   Ejecuta el contenedor y guarda su ID:
```bash
CONTAINER_ID=$(docker create aspose-slides-nodejs)
docker start -a $CONTAINER_ID
```


### 4. **Acceder a Aspose.Slides en Docker** 
   Después de iniciar el contenedor, el script generará un archivo PPTX. Puedes encontrar el archivo de salida generado `NewPresentation.pptx` en la carpeta `/app` dentro del contenedor:
```bash
docker cp $CONTAINER_ID:/app/NewPresentation.pptx ./NewPresentation.pptx
```

   Elimina el contenedor temporal:
```bash
docker rm $CONTAINER_ID
```
