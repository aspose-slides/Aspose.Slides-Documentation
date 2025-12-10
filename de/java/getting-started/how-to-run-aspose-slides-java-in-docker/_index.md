---
title: Wie man Aspose.Slides für Java in Docker ausführt
type: docs
weight: 75
url: /de/java/how-to-run-aspose-slides-in-docker/
keywords:
- Aspose.Slides herunterladen
- Aspose.Slides installieren
- Aspose.Slides Installation
- Docker
- Windows
- macOS
- Linux
- plattformübergreifende Kompatibilität
- Abhängigkeitsisolierung
- vereinfachte Bereitstellung
- Projekt-Setup
- PowerPoint
- OpenDocument
- Präsentation
- Java
- Aspose.Slides
description: "Führen Sie Aspose.Slides in Docker-Containern aus: Konfigurieren Sie Images, Abhängigkeiten, Schriftarten und Lizenzierung, um skalierbare Dienste zu erstellen, die PowerPoint- und OpenDocument-Dateien verarbeiten."
---

## **Einleitung**

Dieser Leitfaden erklärt, wie man eine Java‑Anwendung mit Aspose Slides mithilfe von Docker containerisiert. Die wichtigsten Vorteile sind:

- **Plattformübergreifende Kompatibilität** - Läuft unter Windows, macOS und Linux
- **Abhängigkeitsisolation** - Keine systemweiten Installationen erforderlich
- **Vereinfachte Bereitstellung** - Einfaches Teilen und Ausführen

## **1. Docker-Installation**

### **Windows**

**Voraussetzungen:**

- Windows 10/11 Pro/Enterprise/Education (64‑Bit) mit aktiviertem WSL 2
- Für die Home‑Edition: Manuelle Installation von WSL 2 erforderlich

**Schritte:**

1. Laden Sie [Docker Desktop für Windows](https://www.docker.com/products/docker-desktop/) herunter
2. Führen Sie das Installationsprogramm aus und folgen Sie dem Einrichtungsassistenten
3. Starten Sie Ihren Computer neu, wenn Sie dazu aufgefordert werden
4. Installation prüfen:
   ```powershell
   docker --version
   ```


### **macOS**

**Voraussetzungen:**

- macOS 10.15 (Catalina) oder neuer
- Apple‑Silicon‑ oder Intel‑Prozessor

**Schritte:**

1. Laden Sie [Docker Desktop für Mac](https://www.docker.com/products/docker-desktop/) herunter
2. Ziehen Sie die Anwendung in Ihren `Applications`‑Ordner
3. Starten Sie Docker und warten Sie auf die Initialisierung
4. Installation prüfen:
   ```bash
   docker --version
   ```


### **Linux (Ubuntu/Debian)**

**Installation:**
```bash
# Paketlisten aktualisieren
sudo apt update && sudo apt upgrade -y

# Voraussetzungen installieren
sudo apt install -y \
    apt-transport-https \
    ca-certificates \
    curl \
    software-properties-common

# Offiziellen GPG-Schlüssel von Docker hinzufügen
curl -fsSL https://download.docker.com/linux/ubuntu/gpg | sudo gpg --dearmor -o /usr/share/keyrings/docker-archive-keyring.gpg

# Stabiles Repository hinzufügen
echo "deb [arch=amd64 signed-by=/usr/share/keyrings/docker-archive-keyring.gpg] https://download.docker.com/linux/ubuntu $(lsb_release -cs) stable" | sudo tee /etc/apt/sources.list.d/docker.list > /dev/null

# Docker Engine installieren
sudo apt update
sudo apt install -y docker-ce docker-ce-cli containerd.io

# Dem aktuellen Benutzer erlauben, Docker-Befehle auszuführen
sudo usermod -aG docker $USER
newgrp docker

# Installation überprüfen
docker --version
```


## **2. Dockerfile-Konfiguration**

### **Basis-Image**
```dockerfile
FROM ubuntu:24.04
```

> **Hinweis**: Verwendet das [offizielle Ubuntu-Image](https://hub.docker.com/_/ubuntu) von Docker Hub.

### **Abhängigkeiten**
```dockerfile
RUN apt-get install -y openjdk-11-jdk wget fontconfig ttf-mscorefonts-installer
```

- **OpenJDK 11**: Java-Laufzeitumgebung
- **Schriftpakete**: Enthalten Microsoft Core Fonts

### **Aspose.Slides‑Einrichtung**
```dockerfile
ENV ASPOSE_VERSION=25.3

ENV ASPOSE_JAR=aspose-slides-${ASPOSE_VERSION}-jdk16.jar
ENV ASPOSE_URL=https://releases.aspose.com/java/repo/com/aspose/aspose-slides/${ASPOSE_VERSION}/${ASPOSE_JAR}
```

- Versionsgebundener Download der Aspose Slides-Bibliothek

## **3. Projekt-Setup**

### **Dateistruktur**
```
aspose-docker/
├── Dockerfile          # Container-Konfiguration
├── TestAspose.java     # Anwendungscode
└── output/             # Ordner mit erzeugten PDFs (automatisch erstellt)
```


### **Dockerfile**

Erstellen Sie eine Datei mit dem Namen `Dockerfile` mit folgendem Inhalt:
```dockerfile
FROM ubuntu:24.04

# Umgebungsvariablen festlegen
ENV JAVA_HOME=/usr/lib/jvm/java-11-openjdk-amd64
ENV PATH=$JAVA_HOME/bin:$PATH
ENV APP_DIR=/tmp
ENV ASPOSE_VERSION=25.3
ENV ASPOSE_JAR=aspose-slides-${ASPOSE_VERSION}-jdk16.jar
ENV ASPOSE_URL=https://releases.aspose.com/java/repo/com/aspose/aspose-slides/${ASPOSE_VERSION}/${ASPOSE_JAR}

# Arbeitsverzeichnis erstellen
RUN mkdir -p ${APP_DIR}
WORKDIR ${APP_DIR}

# Abhängigkeiten installieren
RUN apt-get update && \
    apt-get install -y --no-install-recommends \
    openjdk-11-jdk \
    wget \
    fontconfig \
    ttf-mscorefonts-installer && \
    rm -rf /var/lib/apt/lists/*

# Schriften konfigurieren
RUN echo "ttf-mscorefonts-installer msttcorefonts/accepted-mscorefonts-eula select true" | debconf-set-selections && \
    apt-get update && \
    apt-get install -y --no-install-recommends ttf-mscorefonts-installer && \
    fc-cache -f -v

# Aspose.Slides nach /tmp herunterladen
RUN wget ${ASPOSE_URL} -O ${APP_DIR}/${ASPOSE_JAR}

# Quellcode kopieren
COPY TestAspose.java ${APP_DIR}/

# Ausführungsskript erstellen
RUN echo '#!/bin/bash' > ${APP_DIR}/run.sh && \
    echo 'java --add-opens=java.desktop/sun.java2d=ALL-UNNAMED \' >> ${APP_DIR}/run.sh && \
    echo '     --add-opens=java.desktop/sun.awt.image=ALL-UNNAMED \' >> ${APP_DIR}/run.sh && \
    echo '     --add-opens=java.desktop/sun.font=ALL-UNNAMED \' >> ${APP_DIR}/run.sh && \
    echo '     -cp ".:'"${ASPOSE_JAR}"'" TestAspose' >> ${APP_DIR}/run.sh && \
    chmod +x ${APP_DIR}/run.sh

# Ausführungsberechtigungen für das Skript explizit gewähren
RUN chmod 755 ${APP_DIR}/run.sh

# Java-Code kompilieren
RUN javac -cp "${APP_DIR}/${ASPOSE_JAR}" ${APP_DIR}/TestAspose.java

# Arbeitsverzeichnis festlegen
WORKDIR /tmp

CMD ["sh", "-c", "/tmp/run.sh && cp /tmp/output/output.pdf /output"]
```


### **Java-Anwendung**

Erstellen Sie `TestAspose.java` mit folgendem Inhalt:
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


## **4. Erstellen und Ausführen**

### **Image bauen**

Führen Sie den folgenden Befehl im Verzeichnis aus, in dem sich Ihre Dockerfile befindet, um das Docker-Image zu erstellen:
   ```powershell
   docker build -t aspose-test .
   ```


- `-t` gibt dem Image den Namen „aspose-test“
- `.` verwendet das Dockerfile des aktuellen Verzeichnisses

### **Container ausführen**

Führen Sie den folgenden Befehl im Verzeichnis aus, in dem sich Ihre Dockerfile befindet, um den Docker-Container zu starten:
   ```powershell
   docker run -v "$(pwd)/output:/output" aspose-test
   ```


- `-v` bindet das Ausgabeverzeichnis
- Erstellt `output.pdf` in Ihrem lokalen Ordner `output`