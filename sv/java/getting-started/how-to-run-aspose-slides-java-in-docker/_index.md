---
title: Hur du kör Aspose.Slides för Java i Docker
type: docs
weight: 75
url: /sv/java/how-to-run-aspose-slides-in-docker/
keywords:
- ladda ner Aspose.Slides
- installera Aspose.Slides
- Aspose.Slides-installation
- Docker
- Windows
- macOS
- Linux
- plattformsoberoende kompatibilitet
- isolering av beroenden
- förenklad distribution
- projektuppsättning
- PowerPoint
- OpenDocument
- presentation
- Java
- Aspose.Slides
description: "Kör Aspose.Slides i Docker-behållare: konfigurera avbildningar, beroenden, teckensnitt och licensiering för att bygga skalbara tjänster som behandlar PowerPoint och OpenDocument."
---
## **Introduktion**

Den här guiden förklarar hur du containeriserar en Java‑applikation med Aspose Slides och Docker. Nyckelfördelar inkluderar:

- **Plattformsoberoende kompatibilitet** - kör på Windows, macOS och Linux
- **Isolering av beroenden** - Inga systemomfattande installationer krävs
- **Förenklad distribution** - Enkelt att dela och köra

## **1. Docker‑installation**

### **Windows**

**Krav:**

- Windows 10/11 Pro/Enterprise/Education (64‑bit) med WSL 2 aktiverat
- För Home‑editionen: Kräver manuell installation av WSL 2

**Steg:**

1. Ladda ner [Docker Desktop för Windows](https://www.docker.com/products/docker-desktop/)
2. Kör installationsprogrammet och följ installationsguiden
3. Starta om datorn när du uppmanas
4. Verifiera installationen:
   ```powershell
   docker --version
   ```

### **macOS**

**Krav:**

- macOS 10.15 (Catalina) eller nyare
- Apple Silicon‑ eller Intel‑processor

**Steg:**

1. Ladda ner [Docker Desktop för Mac](https://www.docker.com/products/docker-desktop/)
2. Dra programmet till din `Applications`‑mapp
3. Starta Docker och vänta på initieringen
4. Verifiera installationen:
   ```bash
   docker --version
   ```

### **Linux (Ubuntu/Debian)**

**Installation:**
```bash
# Uppdatera paketlistor
sudo apt update && sudo apt upgrade -y

# Installera förutsättningar
sudo apt install -y \
    apt-transport-https \
    ca-certificates \
    curl \
    software-properties-common

# Lägg till Dockers officiella GPG-nyckel
curl -fsSL https://download.docker.com/linux/ubuntu/gpg | sudo gpg --dearmor -o /usr/share/keyrings/docker-archive-keyring.gpg

# Lägg till ett stabilt arkiv
echo "deb [arch=amd64 signed-by=/usr/share/keyrings/docker-archive-keyring.gpg] https://download.docker.com/linux/ubuntu $(lsb_release -cs) stable" | sudo tee /etc/apt/sources.list.d/docker.list > /dev/null

# Installera Docker Engine
sudo apt update
sudo apt install -y docker-ce docker-ce-cli containerd.io

# Tillåt den aktuella användaren att köra Docker-kommandon
sudo usermod -aG docker $USER
newgrp docker

# Verifiera installationen
docker --version
```

## **2. Dockerfile‑konfiguration**

### **Basimage**
```dockerfile
FROM ubuntu:24.04
```
> **Obs**: Använder den [officiella Ubuntu‑avbilden](https://hub.docker.com/_/ubuntu) från Docker Hub.

### **Beroenden**
```dockerfile
RUN apt-get install -y openjdk-11-jdk wget fontconfig ttf-mscorefonts-installer
```
- **OpenJDK 11**: Java‑körningsmiljö
- **Fontpaket**: Inkluderar Microsoft Core Fonts

### **Aspose.Slides‑inställning**
```dockerfile
ENV ASPOSE_VERSION=25.3

ENV ASPOSE_JAR=aspose-slides-${ASPOSE_VERSION}-jdk16.jar
ENV ASPOSE_URL=https://releases.aspose.com/java/repo/com/aspose/aspose-slides/${ASPOSE_VERSION}/${ASPOSE_JAR}
```
- Versionslåsad nedladdning av Aspose Slides‑biblioteket

## **3. Projektuppsättning**

### **Filstruktur**
```
aspose-docker/
├── Dockerfile          # Containerkonfiguration
├── TestAspose.java     # Applikationskod
└── output/             # Mapp med genererade PDF-filer (automatiskt skapad)
```

### **Dockerfile**
Skapa en fil med namnet `Dockerfile` med:
```dockerfile
FROM ubuntu:24.04

# Ställ in miljövariabler
ENV JAVA_HOME=/usr/lib/jvm/java-11-openjdk-amd64
ENV PATH=$JAVA_HOME/bin:$PATH
ENV APP_DIR=/tmp
ENV ASPOSE_VERSION=25.3
ENV ASPOSE_JAR=aspose-slides-${ASPOSE_VERSION}-jdk16.jar
ENV ASPOSE_URL=https://releases.aspose.com/java/repo/com/aspose/aspose-slides/${ASPOSE_VERSION}/${ASPOSE_JAR}

# Skapa en arbetskatalog
RUN mkdir -p ${APP_DIR}
WORKDIR ${APP_DIR}

# Installera beroenden
RUN apt-get update && \
    apt-get install -y --no-install-recommends \
    openjdk-11-jdk \
    wget \
    fontconfig \
    ttf-mscorefonts-installer && \
    rm -rf /var/lib/apt/lists/*

# Konfigurera typsnitt
RUN echo "ttf-mscorefonts-installer msttcorefonts/accepted-mscorefonts-eula select true" | debconf-set-selections && \
    apt-get update && \
    apt-get install -y --no-install-recommends ttf-mscorefonts-installer && \
    fc-cache -f -v

# Ladda ner Aspose.Slides till /tmp
RUN wget ${ASPOSE_URL} -O ${APP_DIR}/${ASPOSE_JAR}

# Kopiera källkoden
COPY TestAspose.java ${APP_DIR}/

# Skapa körskriptet
RUN echo '#!/bin/bash' > ${APP_DIR}/run.sh && \
    echo 'java --add-opens=java.desktop/sun.java2d=ALL-UNNAMED \' >> ${APP_DIR}/run.sh && \
    echo '     --add-opens=java.desktop/sun.awt.image=ALL-UNNAMED \' >> ${APP_DIR}/run.sh && \
    echo '     --add-opens=java.desktop/sun.font=ALL-UNNAMED \' >> ${APP_DIR}/run.sh && \
    echo '     -cp ".:'"${ASPOSE_JAR}"'" TestAspose' >> ${APP_DIR}/run.sh && \
    chmod +x ${APP_DIR}/run.sh

# Ge körbehörighet till skriptet explicit
RUN chmod 755 ${APP_DIR}/run.sh

# Kompilera Java‑koden
RUN javac -cp "${APP_DIR}/${ASPOSE_JAR}" ${APP_DIR}/TestAspose.java

# Ställ in arbetskatalogen
WORKDIR /tmp

CMD ["sh", "-c", "/tmp/run.sh && cp /tmp/output/output.pdf /output"]
```

### **Java‑applikation**
Skapa `TestAspose.java` med:
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

## **4. Bygga och köra**

### **Bygg av bild**
Kör följande kommando i katalogen där din Dockerfile finns för att bygga Docker‑avbilden:
```powershell
   docker build -t aspose-test .
   ```

- `-t` namnger avbilden "aspose-test"
- `.` använder Dockerfile i den aktuella katalogen

### **Kör containern**
Kör följande kommando i katalogen där din Dockerfile finns för att köra Docker‑containern:
```powershell
   docker run -v "$(pwd)/output:/output" aspose-test
   ```

- `-v` monterar utdata‑katalogen
- Skapar `output.pdf` i din lokala `output`‑mapp