---
title: Instalar Aspose.Slides para PHP via Java usando Docker
type: docs
weight: 75
url: /pt/php-java/installing-slides-php-using-docker/
keywords:
- baixar Aspose.Slides
- instalar Aspose.Slides
- instalação do Aspose.Slides
- Docker
- Windows
- macOS
- Linux
- compatibilidade multiplataforma
- isolamento de dependências
- implantação simplificada
- configuração do projeto
- PowerPoint
- OpenDocument
- apresentação
- PHP
- Aspose.Slides
description: "Execute Aspose.Slides em contêineres Docker: configure imagens, dependências, fontes e licenças para criar serviços escaláveis que processam PowerPoint e OpenDocument."
---
## **Pré-requisitos**
* Instale o Docker na sua máquina. Você pode seguir o guia oficial de instalação [aqui](https://docs.docker.com/get-docker/).

## **Etapas**

### **1. Crie um Dockerfile** 
   Crie um novo arquivo chamado Dockerfile no diretório do seu projeto com o seguinte conteúdo:
   ```
   # Imagem base (imagem oficial do Ubuntu)
   FROM ubuntu:20.04
   
   # Defina o fuso horário antecipadamente para evitar seleção interativa
   ENV DEBIAN_FRONTEND=noninteractive
   RUN ln -fs /usr/share/zoneinfo/Europe/Berlin /etc/localtime && \
       apt-get update && apt-get install -y tzdata && \
       dpkg-reconfigure --frontend noninteractive tzdata
   
   # Instale os pacotes necessários e atualize as listas de pacotes
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
   
   # Aceite automaticamente o contrato de licença ao instalar fontes TrueType da Microsoft
   RUN echo "ttf-mscorefonts-installer msttcorefonts/accepted-mscorefonts-eula select true" | debconf-set-selections
   
   # Instale as fontes TrueType da Microsoft
   RUN apt-get update && \
       apt-get install -y ttf-mscorefonts-installer && \
       rm -rf /var/lib/apt/lists/*
   
   # Instale o Tomcat – usando a versão 9.0.93
   RUN wget https://archive.apache.org/dist/tomcat/tomcat-9/v9.0.93/bin/apache-tomcat-9.0.93.tar.gz -O /tmp/tomcat.tar.gz && \
       tar xzf /tmp/tomcat.tar.gz -C /opt/ && \
       mv /opt/apache-tomcat-9.0.93 /opt/tomcat && \
       rm /tmp/tomcat.tar.gz
   
   # Instale o PHP/Java Bridge
   RUN curl -L http://sourceforge.net/projects/php-java-bridge/files/Binary%20package/php-java-bridge_7.2.1/php-java-bridge_7.2.1_documentation.zip/download -o /tmp/php-java-bridge.zip && \
       unzip /tmp/php-java-bridge.zip -d /tmp/php-java-bridge && \
       mkdir -p /opt/tomcat/webapps/JavaBridge && \
       cp /tmp/php-java-bridge/JavaBridge.war /opt/tomcat/webapps/JavaBridge && \
       cd /opt/tomcat/webapps/JavaBridge && \
       jar -xvf JavaBridge.war && \
       rm -rf /tmp/php-java-bridge.zip /tmp/php-java-bridge
   
   # Baixe e instale o Aspose.Slides para PHP via Java
   RUN wget https://github.com/aspose-slides/Aspose.Slides-for-PHP-via-Java/archive/refs/heads/master.zip -O /tmp/aspose-slides.zip && \
       unzip /tmp/aspose-slides.zip -d /tmp/aspose-slides && \
       mkdir -p /opt/tomcat/webapps/JavaBridge/WEB-INF/lib && \
       mkdir -p /tmp/sample && \
       cp /tmp/aspose-slides/Aspose.Slides-for-PHP-via-Java-master/jar/*.jar /opt/tomcat/webapps/JavaBridge/WEB-INF/lib && \
       cp -r /tmp/aspose-slides/Aspose.Slides-for-PHP-via-Java-master/lib /tmp/sample && \
       rm -rf /tmp/aspose-slides.zip /tmp/aspose-slides
   
   # Crie o arquivo test.php
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
   
   # Crie o script entrypoint.sh
   RUN echo '#!/bin/bash\n\
   # Iniciar o Tomcat em segundo plano\n\
   catalina.sh start\n\
   # Aguarde o Tomcat iniciar completamente\n\
   until curl -s http://localhost:8080 > /dev/null; do\n\
    sleep 2\n\
   done\n\
   echo "Running the PHP script..."\n\
   # Executar o script PHP\n\
   php /tmp/sample/test.php\n\
   echo "PHP script completed, please check file /tmp/output.pdf."\n\
   # Manter o contêiner ativo\n\
   echo "Keeping the container alive..."\n\
   tail -f /dev/null\n\
   ' > /tmp/entrypoint.sh
   
   # Conceda explicitamente permissões de execução ao script
   RUN chmod 755 /tmp/entrypoint.sh
   
   # Configure php.ini
   RUN echo "allow_url_include = On" >> /etc/php/7.4/cli/php.ini
   
   # Defina variáveis de ambiente para o Tomcat
   ENV CATALINA_HOME /opt/tomcat
   ENV PATH $CATALINA_HOME/bin:$PATH
   ENV PHP_CLASSPATH /opt/aspose-slides/lib
   
   # Exponha a porta 8080 para o Tomcat e a porta 9000 para o PHP/Java Bridge
   EXPOSE 8080
   EXPOSE 9000
   
   # Defina o diretório de trabalho
   WORKDIR /tmp
   
   # Inicie o Tomcat quando o contêiner iniciar
   ENTRYPOINT ["/tmp/entrypoint.sh"]
   ```

### **2. Construir a imagem Docker**
   Execute o comando a seguir no diretório onde seu Dockerfile está localizado para criar a imagem Docker:
   ```bash
   docker build -t aspose-slides-php-java .
```

### **3. Executar o contêiner Docker**
   Depois que a imagem for criada, execute o contêiner:
   ```bash
   docker run -p 8080:8080 aspose-slides-php-java
   ```

### **4. Acessar o Aspose.Slides no Docker** 
   Após iniciar o contêiner, o script gerará um arquivo PDF. Você pode encontrar o arquivo de saída gerado `output.pdf` na pasta `/tmp` dentro do contêiner:
   ```bash
   docker exec -it <container-id> ls /tmp
   ```
   Para copiar o arquivo PDF gerado para sua máquina local, execute o comando a seguir:
   ```bash
   docker cp <container-id>:/tmp/output.pdf ./output.pdf
   ```