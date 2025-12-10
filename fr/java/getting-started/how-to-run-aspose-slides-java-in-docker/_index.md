---
title: Comment exécuter Aspose.Slides pour Java dans Docker
type: docs
weight: 75
url: /fr/java/how-to-run-aspose-slides-in-docker/
keywords:
- télécharger Aspose.Slides
- installer Aspose.Slides
- installation d'Aspose.Slides
- Docker
- Windows
- macOS
- Linux
- compatibilité multiplateforme
- isolation des dépendances
- déploiement simplifié
- configuration du projet
- PowerPoint
- OpenDocument
- présentation
- Java
- Aspose.Slides
description: "Exécuter Aspose.Slides dans des conteneurs Docker : configurer les images, les dépendances, les polices et les licences pour créer des services évolutifs qui traitent PowerPoint et OpenDocument."
---

## **Introduction**

Ce guide explique comment conteneuriser une application Java en utilisant Aspose Slides avec Docker. Les principaux avantages incluent :

- **Compatibilité multiplateforme** - Fonctionne sous Windows, macOS et Linux
- **Isolation des dépendances** - Aucune installation système requise
- **Déploiement simplifié** - Partage et exécution facilités

## **1. Docker Installation**

### **Windows**

**Exigences :**

- Windows 10/11 Pro/Enterprise/Education (64 bits) avec WSL 2 activé
- Pour l'édition Home : nécessite une installation manuelle de WSL 2

**Étapes :**

1. Télécharger le [Docker Desktop pour Windows](https://www.docker.com/products/docker-desktop/)
2. Exécuter le programme d'installation et suivre l'assistant de configuration
3. Redémarrer votre ordinateur lorsqu'on le demande
4. Vérifier l'installation :
   ```powershell
   docker --version
   ```


### **macOS**

**Exigences :**

- macOS 10.15 (Catalina) ou version ultérieure
- Processeur Apple Silicon ou Intel

**Étapes :**

1. Télécharger le [Docker Desktop pour Mac](https://www.docker.com/products/docker-desktop/)
2. Glisser l'application dans le dossier `Applications`
3. Lancer Docker et attendre l'initialisation
4. Vérifier l'installation :
   ```bash
   docker --version
   ```


### **Linux (Ubuntu/Debian)**

**Installation :**
```bash
# Mettre à jour les listes de paquets
sudo apt update && sudo apt upgrade -y

# Installer les prérequis
sudo apt install -y \
    apt-transport-https \
    ca-certificates \
    curl \
    software-properties-common

# Ajouter la clé GPG officielle de Docker
curl -fsSL https://download.docker.com/linux/ubuntu/gpg | sudo gpg --dearmor -o /usr/share/keyrings/docker-archive-keyring.gpg

# Ajouter un dépôt stable
echo "deb [arch=amd64 signed-by=/usr/share/keyrings/docker-archive-keyring.gpg] https://download.docker.com/linux/ubuntu $(lsb_release -cs) stable" | sudo tee /etc/apt/sources.list.d/docker.list > /dev/null

# Installer le moteur Docker
sudo apt update
sudo apt install -y docker-ce docker-ce-cli containerd.io

# Autoriser l'utilisateur actuel à exécuter les commandes Docker
sudo usermod -aG docker $USER
newgrp docker

# Vérifier l'installation
docker --version
```


## **2. Dockerfile Configuration**

### **Base Image**
```dockerfile
FROM ubuntu:24.04
```

> **Note** : Utilise l'[image officielle Ubuntu](https://hub.docker.com/_/ubuntu) de Docker Hub.

### **Dependencies**
```dockerfile
RUN apt-get install -y openjdk-11-jdk wget fontconfig ttf-mscorefonts-installer
```

- **OpenJDK 11** : environnement d'exécution Java
- **Paquets de polices** : inclut les Microsoft Core Fonts

### **Aspose.Slides Setup**
```dockerfile
ENV ASPOSE_VERSION=25.3

ENV ASPOSE_JAR=aspose-slides-${ASPOSE_VERSION}-jdk16.jar
ENV ASPOSE_URL=https://releases.aspose.com/java/repo/com/aspose/aspose-slides/${ASPOSE_VERSION}/${ASPOSE_JAR}
```

- Téléchargement de la bibliothèque Aspose Slides avec version verrouillée

## **3. Project Setup**

### **File Structure**
```
aspose-docker/
├── Dockerfile          # Configuration du conteneur
├── TestAspose.java     # Code de l'application
└── output/             # Dossier contenant les PDF générés (créé automatiquement)
```


### **Dockerfile**

Créer un fichier nommé `Dockerfile` contenant :
```dockerfile
FROM ubuntu:24.04

# Définir les variables d'environnement
ENV JAVA_HOME=/usr/lib/jvm/java-11-openjdk-amd64
ENV PATH=$JAVA_HOME/bin:$PATH
ENV APP_DIR=/tmp
ENV ASPOSE_VERSION=25.3
ENV ASPOSE_JAR=aspose-slides-${ASPOSE_VERSION}-jdk16.jar
ENV ASPOSE_URL=https://releases.aspose.com/java/repo/com/aspose/aspose-slides/${ASPOSE_VERSION}/${ASPOSE_JAR}

# Créer un répertoire de travail
RUN mkdir -p ${APP_DIR}
WORKDIR ${APP_DIR}

# Installer les dépendances
RUN apt-get update && \
    apt-get install -y --no-install-recommends \
    openjdk-11-jdk \
    wget \
    fontconfig \
    ttf-mscorefonts-installer && \
    rm -rf /var/lib/apt/lists/*

# Configurer les polices
RUN echo "ttf-mscorefonts-installer msttcorefonts/accepted-mscorefonts-eula select true" | debconf-set-selections && \
    apt-get update && \
    apt-get install -y --no-install-recommends ttf-mscorefonts-installer && \
    fc-cache -f -v

# Télécharger Aspose.Slides dans /tmp
RUN wget ${ASPOSE_URL} -O ${APP_DIR}/${ASPOSE_JAR}

# Copier le code source
COPY TestAspose.java ${APP_DIR}/

# Créer le script d'exécution
RUN echo '#!/bin/bash' > ${APP_DIR}/run.sh && \
    echo 'java --add-opens=java.desktop/sun.java2d=ALL-UNNAMED \' >> ${APP_DIR}/run.sh && \
    echo '     --add-opens=java.desktop/sun.awt.image=ALL-UNNAMED \' >> ${APP_DIR}/run.sh && \
    echo '     --add-opens=java.desktop/sun.font=ALL-UNNAMED \' >> ${APP_DIR}/run.sh && \
    echo '     -cp ".:'"${ASPOSE_JAR}"'" TestAspose' >> ${APP_DIR}/run.sh && \
    chmod +x ${APP_DIR}/run.sh

# Accorder explicitement les permissions d'exécution au script
RUN chmod 755 ${APP_DIR}/run.sh

# Compiler le code Java
RUN javac -cp "${APP_DIR}/${ASPOSE_JAR}" ${APP_DIR}/TestAspose.java

# Définir le répertoire de travail
WORKDIR /tmp

CMD ["sh", "-c", "/tmp/run.sh && cp /tmp/output/output.pdf /output"]
```


### **Java Application**

Créer `TestAspose.java` contenant :
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


## **4. Building and Running**

### **Build the Image**

Exécuter la commande suivante dans le répertoire contenant votre Dockerfile pour construire l'image Docker :
   ```powershell
   docker build -t aspose-test .
   ```

   
- `-t` nomme l'image « aspose-test »
- `.` utilise le Dockerfile du répertoire actuel

### **Run the Container**

Exécuter la commande suivante dans le répertoire contenant votre Dockerfile pour exécuter le conteneur Docker :
   ```powershell
   docker run -v "$(pwd)/output:/output" aspose-test
   ```

   
- `-v` monte le répertoire de sortie
- Crée `output.pdf` dans votre dossier local `output`