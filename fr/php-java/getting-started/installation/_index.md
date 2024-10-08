---
title: Installation
type: docs
weight: 70
url: /fr/php-java/installation/
keySlides: "Télécharger Aspose.Slides, Installer Aspose.Slides, Installation d'Aspose.Slides, Windows, macOS, Linux, PHP"
description: "Installer Aspose.Slides pour PHP via Java sous Windows, Linux ou macOS"
---

## **Configurer l'environnement**

1. Installez PHP 7, ajoutez le chemin PHP à la variable système `PATH` et définissez `allow_url_include` sur `On` dans le fichier `php.ini`.
1. Installez JRE 8. Définissez la variable d'environnement `JAVA_HOME` sur le chemin du JRE installé.
1. Installez Apache Tomcat 8.0.

## **Télécharger Aspose.Slides pour PHP via Java**

`packagist` est le moyen le plus simple de télécharger [Aspose.Slides pour PHP via Java](https://packagist.org/packages/aspose/slides).

Pour installer Aspose.Slides en utilisant Packagist, exécutez cette commande :
   ```bash
   composer require aspose/slides
   ```

## **Configurer Apache Tomcat**

1. Téléchargez PHP/Java Bridge (`php-java-bridge_x.x.x_documentation.zip`) depuis http://php-java-bridge.sourceforge.net/pjb/download.php et extrayez le fichier `JavaBridge.war` dans le dossier `webapps` de tomcat.
1. Démarrez le service Apache Tomcat.
1. Téléchargez [« Aspose.Slides pour PHP via Java »](https://downloads.aspose.com/slides/php-java) et extrayez-le dans le dossier `aspose.slides`. Copiez le fichier `jar/aspose-slides-x.x-php.jar` dans le dossier `webapps\JavaBridge\WEB-INF\lib`. Si vous utilisez **PHP 8**, remplacez l'original `Java.inc` du PHP-Java Bridge par le `Java.inc` de `Java.inc.php8.zip`.
1. Redémarrez le service Apache Tomcat.
1. Exécutez `example.php` dans le dossier `aspose.slides` pour exécuter l'exemple avec cette commande :
   ```bash
   php example.php
   ```

## Configuration de Docker ##

Conditions préalables :
* Installez Docker sur votre machine. Vous pouvez suivre le guide d'installation officiel [ici](https://docs.docker.com/get-docker/).

Étapes :
1. **Créer Dockerfile**. Créez un nouveau fichier nommé Dockerfile dans votre répertoire de projet avec le contenu suivant :
   ```
   # Image de base (image officielle d'Ubuntu)
   FROM ubuntu:20.04
   
   # Définir le fuseau horaire à l'avance pour éviter la sélection interactive
   ENV DEBIAN_FRONTEND=noninteractive
   RUN ln -fs /usr/share/zoneinfo/Europe/Berlin /etc/localtime && \
       apt-get update && apt-get install -y tzdata && \
       dpkg-reconfigure --frontend noninteractive tzdata
   
   # Installer les packages nécessaires et mettre à jour les listes de packages
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
   
   # Accepter automatiquement l'accord de licence pour l'installation des polices Microsoft TrueType
   RUN echo "ttf-mscorefonts-installer msttcorefonts/accepted-mscorefonts-eula select true" | debconf-set-selections
   
   # Installer les polices Microsoft TrueType
   RUN apt-get update && \
       apt-get install -y ttf-mscorefonts-installer && \
       rm -rf /var/lib/apt/lists/*
   
   # Installer Tomcat - en utilisant la version 9.0.93
   RUN wget https://archive.apache.org/dist/tomcat/tomcat-9/v9.0.93/bin/apache-tomcat-9.0.93.tar.gz -O /tmp/tomcat.tar.gz && \
       tar xzf /tmp/tomcat.tar.gz -C /opt/ && \
       mv /opt/apache-tomcat-9.0.93 /opt/tomcat && \
       rm /tmp/tomcat.tar.gz
   
   # Installer PHP/Java Bridge
   RUN curl -L http://sourceforge.net/projects/php-java-bridge/files/Binary%20package/php-java-bridge_7.2.1/php-java-bridge_7.2.1_documentation.zip/download -o /tmp/php-java-bridge.zip && \
       unzip /tmp/php-java-bridge.zip -d /tmp/php-java-bridge && \
       mkdir -p /opt/tomcat/webapps/JavaBridge && \
       cp /tmp/php-java-bridge/JavaBridge.war /opt/tomcat/webapps/JavaBridge && \
       cd /opt/tomcat/webapps/JavaBridge && \
       jar -xvf JavaBridge.war && \
       rm -rf /tmp/php-java-bridge.zip /tmp/php-java-bridge
   
   # Télécharger et installer Aspose.Slides pour PHP via Java
   RUN wget https://github.com/aspose-slides/Aspose.Slides-for-PHP-via-Java/archive/refs/heads/master.zip -O /tmp/aspose-slides.zip && \
       unzip /tmp/aspose-slides.zip -d /tmp/aspose-slides && \
       mkdir -p /opt/tomcat/webapps/JavaBridge/WEB-INF/lib && \
       mkdir -p /tmp/sample && \
       cp /tmp/aspose-slides/Aspose.Slides-for-PHP-via-Java-master/jar/*.jar /opt/tomcat/webapps/JavaBridge/WEB-INF/lib && \
       cp -r /tmp/aspose-slides/Aspose.Slides-for-PHP-via-Java-master/lib /tmp/sample && \
       rm -rf /tmp/aspose-slides.zip /tmp/aspose-slides
   
   # Créer le fichier test.php
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
   
   # Créer le script entrypoint.sh
   RUN echo '#!/bin/bash\n\
   # Démarrer Tomcat en arrière-plan\n\
   catalina.sh start\n\
   # Attendre que Tomcat démarre complètement\n\
   until curl -s http://localhost:8080 > /dev/null; do\n\
    sleep 2\n\
   done\n\
   echo "Exécution du script PHP..."\n\
   # Exécuter le script PHP\n\
   php /tmp/sample/test.php\n\
   echo "Script PHP terminé, veuillez vérifier le fichier /tmp/output.pdf."\n\
   # Garder le conteneur en vie\n\
   echo "Maintenir le conteneur en vie..."\n\
   tail -f /dev/null\n\
   ' > /tmp/entrypoint.sh
   
   # Accorder explicitement les permissions d'exécution au script
   RUN chmod 755 /tmp/entrypoint.sh
   
   # Configurer php.ini
   RUN echo "allow_url_include = On" >> /etc/php/7.4/cli/php.ini
   
   # Définir les variables d'environnement pour Tomcat
   ENV CATALINA_HOME /opt/tomcat
   ENV PATH $CATALINA_HOME/bin:$PATH
   ENV PHP_CLASSPATH /opt/aspose-slides/lib
   
   # Exposer le port 8080 pour Tomcat et le port 9000 pour PHP/Java Bridge
   EXPOSE 8080
   EXPOSE 9000
   
   # Définir le répertoire de travail
   WORKDIR /tmp
   
   # Démarrer Tomcat lorsque le conteneur démarre
   ENTRYPOINT ["/tmp/entrypoint.sh"]
   ```

2. **Construire l'image Docker**. Exécutez la commande suivante dans le répertoire où se trouve votre Dockerfile pour construire l'image Docker :
   ```bash
   docker build -t aspose-slides-php-java .
   ```

3. **Exécuter le conteneur Docker**. Une fois l'image construite, exécutez le conteneur :
   ```bash
   docker run -p 8080:8080 aspose-slides-php-java
   ```

4. **Accéder à Aspose.Slides dans Docker**. Après le démarrage du conteneur, le script générera un fichier PDF. Vous pouvez trouver le fichier de sortie généré `output.pdf` dans le dossier `/tmp` à l'intérieur du conteneur :
   ```bash
   docker exec -it <container-id> ls /tmp
   ```
   Pour copier le fichier PDF généré sur votre machine locale, exécutez la commande suivante :
   ```bash
   docker cp <container-id>:/tmp/output.pdf ./output.pdf
   ```