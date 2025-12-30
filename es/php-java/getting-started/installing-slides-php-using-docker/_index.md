---
title: Instalar Aspose.Slides para PHP mediante Java usando Docker
type: docs
weight: 75
url: /es/php-java/installing-slides-php-using-docker/
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
- PHP
- Aspose.Slides
description: "Ejecute Aspose.Slides en contenedores Docker: configure imágenes, dependencias, fuentes y licencias para crear servicios escalables que procesen PowerPoint y OpenDocument."
---

## **Prerequisitos**
* Instala Docker en tu máquina. Puedes seguir la guía de instalación oficial [aquí](https://docs.docker.com/get-docker/).

## **Pasos**

### **1. Crear un Dockerfile** 
   Crea un nuevo archivo llamado Dockerfile en el directorio de tu proyecto con el siguiente contenido:
   ```
   # Imagen base (imagen oficial de Ubuntu)
   FROM ubuntu:20.04
   
   # Establezca la zona horaria por adelantado para evitar la selección interactiva
   ENV DEBIAN_FRONTEND=noninteractive
   RUN ln -fs /usr/share/zoneinfo/Europe/Berlin /etc/localtime && \
       apt-get update && apt-get install -y tzdata && \
       dpkg-reconfigure --frontend noninteractive tzdata
   
   # Instalar paquetes necesarios y actualizar listas de paquetes
   RUN apt-get install -y \
       wget \
       curl \
       apt-transport-https \
       ca-certificates \
       software-properties-common \
       php-cli \
       php-cgi \
       libapache2-mod-php \
       unzip \
       openjdk-8-jdk \
       debconf \
       && rm -rf /var/lib/apt/lists/*
   
   # Aceptar automáticamente el acuerdo de licencia para instalar fuentes TrueType de Microsoft
   RUN echo "ttf-mscorefonts-installer msttcorefonts/accepted-mscorefonts-eula select true" | debconf-set-selections
   
   # Instalar fuentes TrueType de Microsoft
   RUN apt-get update && \
       apt-get install -y ttf-mscorefonts-installer && \
       rm -rf /var/lib/apt/lists/*
   
   # Instalar Tomcat - usando la versión 9.0.93
   RUN wget https://archive.apache.org/dist/tomcat/tomcat-9/v9.0.93/bin/apache-tomcat-9.0.93.tar.gz -O /tmp/tomcat.tar.gz && \
       tar xzf /tmp/tomcat.tar.gz -C /opt/ && \
       mv /opt/apache-tomcat-9.0.93 /opt/tomcat && \
       rm /tmp/tomcat.tar.gz
   
   # Instalar PHP/Java Bridge
   RUN curl -L http://sourceforge.net/projects/php-java-bridge/files/Binary%20package/php-java-bridge_7.2.1/php-java-bridge_7.2.1_documentation.zip/download -o /tmp/php-java-bridge.zip && \
       unzip /tmp/php-java-bridge.zip -d /tmp/php-java-bridge && \
       mkdir -p /opt/tomcat/webapps/JavaBridge && \
       cp /tmp/php-java-bridge/JavaBridge.war /opt/tomcat/webapps/JavaBridge && \
       cd /opt/tomcat/webapps/JavaBridge && \
       jar -xvf JavaBridge.war && \
       rm -rf /tmp/php-java-bridge.zip /tmp/php-java-bridge
   
   # Descargar e instalar Aspose.Slides para PHP vía Java
   RUN wget https://github.com/aspose-slides/Aspose.Slides-for-PHP-via-Java/archive/refs/heads/master.zip -O /tmp/aspose-slides.zip && \
       unzip /tmp/aspose-slides.zip -d /tmp/aspose-slides && \
       mkdir -p /opt/tomcat/webapps/JavaBridge/WEB-INF/lib && \
       mkdir -p /tmp/sample && \
       cp /tmp/aspose-slides/Aspose.Slides-for-PHP-via-Java-master/jar/*.jar /opt/tomcat/webapps/JavaBridge/WEB-INF/lib && \
       cp -r /tmp/aspose-slides/Aspose.Slides-for-PHP-via-Java-master/lib /tmp/sample && \
       rm -rf /tmp/aspose-slides.zip /tmp/aspose-slides
   
   # Crear el archivo test.php
   RUN echo '<?php\n\
   require_once("http://localhost:8080/JavaBridge/java/Java.inc");\n\
   require_once("lib/aspose.slides.php");\n\n\
   use aspose\\slides\\Presentation;\n\
   use aspose\\slides\\ShapeType;\n\
   use aspose\\slides\\SaveFormat;\n\
   use aspose\\slides\\License;\n\n\
   $license = new License();\n\n\
   $presentation = new Presentation();\n\
   $slide = $presentation->getSlides()->get_Item(0);\n\
   $slide->getShapes()->addAutoShape(ShapeType::Line, 50, 150, 300, 0);\n\
   $presentation->save("output.pdf", SaveFormat::Pdf);\n\n\
   ?>' > /tmp/sample/test.php
   
   # Crear el script entrypoint.sh
   RUN echo '#!/bin/bash\n\
   # Iniciar Tomcat en segundo plano\n\
   catalina.sh start\n\
   # Esperar a que Tomcat se inicie completamente\n\
   until curl -s http://localhost:8080 > /dev/null; do\n\
    sleep 2\n\
   done\n\
   echo "Running the PHP script..."\n\
   # Ejecutar el script PHP\n\
   php /tmp/sample/test.php\n\
   echo "PHP script completed, please check file /tmp/output.pdf."\n\
   # Mantener el contenedor activo\n\
   echo "Keeping the container alive..."\n\
   tail -f /dev/null\n\
   ' > /tmp/entrypoint.sh
   
   # Conceder explícitamente permisos de ejecución al script
   RUN chmod 755 /tmp/entrypoint.sh
   
   # Configurar php.ini
   RUN echo "allow_url_include = On" >> /etc/php/7.4/cli/php.ini
   
   # Establecer variables de entorno para Tomcat
   ENV CATALINA_HOME /opt/tomcat
   ENV PATH $CATALINA_HOME/bin:$PATH
   ENV PHP_CLASSPATH /opt/aspose-slides/lib
   
   # Exponer el puerto 8080 para Tomcat y el puerto 9000 para PHP/Java Bridge
   EXPOSE 8080
   EXPOSE 9000
   
   # Establecer el directorio de trabajo
   WORKDIR /tmp
   
   # Iniciar Tomcat cuando el contenedor se inicia
   ENTRYPOINT ["/tmp/entrypoint.sh"]
   ```


### **2. Compilar la Imagen Docker**
   Ejecuta el siguiente comando en el directorio donde se encuentra tu Dockerfile para compilar la imagen Docker:
```bash
docker build -t aspose-slides-php-java .
```


### **3. Ejecutar el Contenedor Docker**
   Una vez compilada la imagen, ejecuta el contenedor:
   ```bash
   docker run -p 8080:8080 aspose-slides-php-java
   ```


### 4. **Acceder a Aspose.Slides en Docker** 
   Después de iniciar el contenedor, el script generará un archivo PDF. Puedes encontrar el archivo de salida generado `output.pdf` en la carpeta `/tmp` dentro del contenedor:
```bash
docker exec -it <container-id> ls /tmp
```

   Para copiar el PDF generado a tu máquina local, ejecuta el siguiente comando:
```bash
docker cp <container-id>:/tmp/output.pdf ./output.pdf
```
