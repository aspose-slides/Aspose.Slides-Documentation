---
title: Cómo ejecutar Aspose.Slides para Java en Docker
type: docs
weight: 75
url: /es/java/how-to-run-aspose-slides-in-docker/
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
- Java
- Aspose.Slides
description: "Ejecute Aspose.Slides en contenedores Docker: configure imágenes, dependencias, fuentes y licencias para crear servicios escalables que procesen PowerPoint y OpenDocument."
---

## **Introducción**

Esta guía explica cómo contenerizar una aplicación Java usando Aspose Slides con Docker. Los principales beneficios incluyen:

- **Compatibilidad multiplataforma** - Se ejecuta en Windows, macOS y Linux
- **Aislamiento de dependencias** - No se requieren instalaciones a nivel del sistema
- **Implementación simplificada** - Compartir y ejecutar fácilmente

## **1. Instalación de Docker**

### **Windows**

**Requisitos:**

- Windows 10/11 Pro/Enterprise/Education (64 bits) con WSL 2 habilitado
- Para la edición Home: requiere instalación manual de WSL 2

**Pasos:**

1. Descarga [Docker Desktop para Windows](https://www.docker.com/products/docker-desktop/)
2. Ejecuta el instalador y sigue el asistente de configuración
3. Reinicia tu computadora cuando se solicite
4. Verifica la instalación:
   ```powershell
   docker --version
   ```


### **macOS**

**Requisitos:**

- macOS 10.15 (Catalina) o posterior
- Procesador Apple Silicon o Intel

**Pasos:**

1. Descarga [Docker Desktop para Mac](https://www.docker.com/products/docker-desktop/)
2. Arrastra la aplicación a tu carpeta `Applications`
3. Inicia Docker y espera a que se inicialice
4. Verifica la instalación:
   ```bash
   docker --version
   ```


### **Linux (Ubuntu/Debian)**

**Instalación:**
```bash
# Actualizar listas de paquetes
sudo apt update && sudo apt upgrade -y

# Instalar requisitos previos
sudo apt install -y \
    apt-transport-https \
    ca-certificates \
    curl \
    software-properties-common

# Añadir la clave GPG oficial de Docker
curl -fsSL https://download.docker.com/linux/ubuntu/gpg | sudo gpg --dearmor -o /usr/share/keyrings/docker-archive-keyring.gpg

# Añadir un repositorio estable
echo "deb [arch=amd64 signed-by=/usr/share/keyrings/docker-archive-keyring.gpg] https://download.docker.com/linux/ubuntu $(lsb_release -cs) stable" | sudo tee /etc/apt/sources.list.d/docker.list > /dev/null

# Instalar el motor Docker
sudo apt update
sudo apt install -y docker-ce docker-ce-cli containerd.io

# Permitir al usuario actual ejecutar comandos Docker
sudo usermod -aG docker $USER
newgrp docker

# Verificar la instalación
docker --version
```


## **2. Configuración del Dockerfile**

### **Imagen base**
```dockerfile
FROM ubuntu:24.04
```

> **Nota**: Utiliza la [imagen oficial de Ubuntu](https://hub.docker.com/_/ubuntu) de Docker Hub.

### **Dependencias**
```dockerfile
RUN apt-get install -y openjdk-11-jdk wget fontconfig ttf-mscorefonts-installer
```

- **OpenJDK 11**: entorno de ejecución Java
- **Paquetes de fuentes**: incluyen Microsoft Core Fonts

### **Configuración de Aspose.Slides**
```dockerfile
ENV ASPOSE_VERSION=25.3

ENV ASPOSE_JAR=aspose-slides-${ASPOSE_VERSION}-jdk16.jar
ENV ASPOSE_URL=https://releases.aspose.com/java/repo/com/aspose/aspose-slides/${ASPOSE_VERSION}/${ASPOSE_JAR}
```

- Descarga de la biblioteca Aspose Slides con versión fija

## **3. Configuración del proyecto**

### **Estructura de archivos**
```
aspose-docker/
├── Dockerfile          # Configuración del contenedor
├── TestAspose.java     # Código de la aplicación
└── output/             # Carpeta con PDFs generados (creada automáticamente)
```


### **Dockerfile**

Crea un archivo llamado `Dockerfile` con:
```dockerfile
FROM ubuntu:24.04

# Establecer variables de entorno
ENV JAVA_HOME=/usr/lib/jvm/java-11-openjdk-amd64
ENV PATH=$JAVA_HOME/bin:$PATH
ENV APP_DIR=/tmp
ENV ASPOSE_VERSION=25.3
ENV ASPOSE_JAR=aspose-slides-${ASPOSE_VERSION}-jdk16.jar
ENV ASPOSE_URL=https://releases.aspose.com/java/repo/com/aspose/aspose-slides/${ASPOSE_VERSION}/${ASPOSE_JAR}

# Crear un directorio de trabajo
RUN mkdir -p ${APP_DIR}
WORKDIR ${APP_DIR}

# Instalar dependencias
RUN apt-get update && \
    apt-get install -y --no-install-recommends \
    openjdk-11-jdk \
    wget \
    fontconfig \
    ttf-mscorefonts-installer && \
    rm -rf /var/lib/apt/lists/*

# Configurar fuentes
RUN echo "ttf-mscorefonts-installer msttcorefonts/accepted-mscorefonts-eula select true" | debconf-set-selections && \
    apt-get update && \
    apt-get install -y --no-install-recommends ttf-mscorefonts-installer && \
    fc-cache -f -v

# Descargar Aspose.Slides a /tmp
RUN wget ${ASPOSE_URL} -O ${APP_DIR}/${ASPOSE_JAR}

# Copiar el código fuente
COPY TestAspose.java ${APP_DIR}/

# Crear el script de ejecución
RUN echo '#!/bin/bash' > ${APP_DIR}/run.sh && \
    echo 'java --add-opens=java.desktop/sun.java2d=ALL-UNNAMED \' >> ${APP_DIR}/run.sh && \
    echo '     --add-opens=java.desktop/sun.awt.image=ALL-UNNAMED \' >> ${APP_DIR}/run.sh && \
    echo '     --add-opens=java.desktop/sun.font=ALL-UNNAMED \' >> ${APP_DIR}/run.sh && \
    echo '     -cp ".:'"${ASPOSE_JAR}"'" TestAspose' >> ${APP_DIR}/run.sh && \
    chmod +x ${APP_DIR}/run.sh

# Conceder explícitamente permisos de ejecución al script
RUN chmod 755 ${APP_DIR}/run.sh

# Compilar el código Java
RUN javac -cp "${APP_DIR}/${ASPOSE_JAR}" ${APP_DIR}/TestAspose.java

# Establecer el directorio de trabajo
WORKDIR /tmp

CMD ["sh", "-c", "/tmp/run.sh && cp /tmp/output/output.pdf /output"]
```


### **Aplicación Java**

Crea `TestAspose.java` con:
```java
import com.aspose.slides.*;

public class TestAspose {
    public static void main(String[] args) throws Exception {
        System.out.println("Creating presentation...");
        
        Presentation presentation = new Presentation();
        try {
            ISlide slide = presentation.getSlides().get_Item(0);
            
            IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 190, 300, 25);
            autoShape.getTextFrame().setText("Greetings from Docker!");
            
            presentation.save("/tmp/output/output.pdf", SaveFormat.Pdf);
        } finally {
            if (presentation != null) presentation.dispose();
        }
        System.out.println("Presentation saved as output.pdf");
    }
}
```


## **4. Construcción y ejecución**

### **Construir la imagen**

   Ejecuta el siguiente comando en el directorio donde se encuentra tu Dockerfile para construir la imagen Docker:
   ```powershell
   docker build -t aspose-test .
   ```

   
- `-t` nombra la imagen "aspose-test"
- `.` usa el Dockerfile del directorio actual

### **Ejecutar el contenedor**

   Ejecuta el siguiente comando en el directorio donde se encuentra tu Dockerfile para ejecutar el contenedor Docker:
   ```powershell
   docker run -v "$(pwd)/output:/output" aspose-test
   ```

   
- `-v` monta el directorio de salida
- Crea `output.pdf` en tu carpeta local `output`