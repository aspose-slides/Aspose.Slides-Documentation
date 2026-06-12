---
title: Hoe Aspose.Slides voor Java te gebruiken in Docker
type: docs
weight: 75
url: /nl/java/how-to-run-aspose-slides-in-docker/
keywords:
- download Aspose.Slides
- installeer Aspose.Slides
- Aspose.Slides installatie
- Docker
- Windows
- macOS
- Linux
- cross-platform compatibiliteit
- afhankelijkheidsisolatie
- vereenvoudigde implementatie
- projectconfiguratie
- PowerPoint
- OpenDocument
- presentatie
- Java
- Aspose.Slides
description: "Voer Aspose.Slides uit in Docker-containers: configureer images, afhankelijkheden, lettertypen en licenties om schaalbare services te bouwen die PowerPoint- en OpenDocument-presentaties verwerken."
---
## **Introductie**

Deze handleiding legt uit hoe u een Java‑applicatie kunt containeriseren met Aspose Slides en Docker. Belangrijke voordelen zijn:

- **Cross-platform compatibiliteit** - Werkt op Windows, macOS en Linux
- **Afzondering van afhankelijkheden** - Geen systeem‑brede installaties vereist
- **Vereenvoudigde implementatie** - Gemakkelijk delen en uitvoeren

## **1. Docker‑installatie**

### **Windows**

**Vereisten:**

- Windows 10/11 Pro/Enterprise/Education (64‑bit) met ingeschakelde WSL 2
- Voor Home‑editie: Handmatige installatie van WSL 2 vereist

**Stappen:**

1. Download de [Docker Desktop voor Windows](https://www.docker.com/products/docker-desktop/)
2. Voer het installatieprogramma uit en volg de setup-wizard
3. Start uw computer opnieuw op wanneer daarom wordt gevraagd
4. Controleer de installatie:
   ```powershell
   docker --version
   ```

### **macOS**

**Vereisten:**

- macOS 10.15 (Catalina) of nieuwer
- Apple Silicon of Intel‑processor

**Stappen:**

1. Download de [Docker Desktop voor Mac](https://www.docker.com/products/docker-desktop/)
2. Sleep de applicatie naar uw `Applications`‑map
3. Start Docker en wacht tot het is geïnitialiseerd
4. Controleer de installatie:
   ```bash
   docker --version
   ```

### **Linux (Ubuntu/Debian)**

**Installatie:**

```bash
# Werk pakkettenlijsten bij
sudo apt update && sudo apt upgrade -y

# Installeer vereisten
sudo apt install -y \
    apt-transport-https \
    ca-certificates \
    curl \
    software-properties-common

# Voeg de officiële GPG-sleutel van Docker toe
curl -fsSL https://download.docker.com/linux/ubuntu/gpg | sudo gpg --dearmor -o /usr/share/keyrings/docker-archive-keyring.gpg

# Voeg een stabiele repository toe
echo "deb [arch=amd64 signed-by=/usr/share/keyrings/docker-archive-keyring.gpg] https://download.docker.com/linux/ubuntu $(lsb_release -cs) stable" | sudo tee /etc/apt/sources.list.d/docker.list > /dev/null

# Installeer de Docker Engine
sudo apt update
sudo apt install -y docker-ce docker-ce-cli containerd.io

# Sta de huidige gebruiker toe Docker-commando's uit te voeren
sudo usermod -aG docker $USER
newgrp docker

# Verifieer installatie
docker --version
```

## **2. Dockerfile‑configuratie**

### **Basis‑image**

```dockerfile
FROM ubuntu:24.04
```
> **Opmerking**: Gebruikt de [officiële Ubuntu‑image](https://hub.docker.com/_/ubuntu) van Docker Hub.

### **Afhankelijkheden**

```dockerfile
RUN apt-get install -y openjdk-11-jdk wget fontconfig ttf-mscorefonts-installer
```
- **OpenJDK 11**: Java‑runtime‑omgeving
- **Lettertype‑pakketten**: Bevat Microsoft Core Fonts

### **Aspose.Slides‑configuratie**

```dockerfile
ENV ASPOSE_VERSION=25.3

ENV ASPOSE_JAR=aspose-slides-${ASPOSE_VERSION}-jdk16.jar
ENV ASPOSE_URL=https://releases.aspose.com/java/repo/com/aspose/aspose-slides/${ASPOSE_VERSION}/${ASPOSE_JAR}
```
- Versie‑gebonden download van de Aspose Slides‑bibliotheek

## **3. Project‑configuratie**

### **Bestandsstructuur**

```
aspose-docker/
├── Dockerfile          # Containerconfiguratie
├── TestAspose.java     # Applicatiecode
└── output/             # Map met gegenereerde PDF's (automatisch aangemaakt)
```

### **Dockerfile**

Maak een bestand aan met de naam `Dockerfile` met:
```dockerfile
FROM ubuntu:24.04

# Stel omgevingsvariabelen in
ENV JAVA_HOME=/usr/lib/jvm/java-11-openjdk-amd64
ENV PATH=$JAVA_HOME/bin:$PATH
ENV APP_DIR=/tmp
ENV ASPOSE_VERSION=25.3
ENV ASPOSE_JAR=aspose-slides-${ASPOSE_VERSION}-jdk16.jar
ENV ASPOSE_URL=https://releases.aspose.com/java/repo/com/aspose/aspose-slides/${ASPOSE_VERSION}/${ASPOSE_JAR}

# Maak een werkmap
RUN mkdir -p ${APP_DIR}
WORKDIR ${APP_DIR}

# Installeer afhankelijkheden
RUN apt-get update && \
    apt-get install -y --no-install-recommends \
    openjdk-11-jdk \
    wget \
    fontconfig \
    ttf-mscorefonts-installer && \
    rm -rf /var/lib/apt/lists/*

# Configureer lettertypen
RUN echo "ttf-mscorefonts-installer msttcorefonts/accepted-mscorefonts-eula select true" | debconf-set-selections && \
    apt-get update && \
    apt-get install -y --no-install-recommends ttf-mscorefonts-installer && \
    fc-cache -f -v

# Download Aspose.Slides naar /tmp
RUN wget ${ASPOSE_URL} -O ${APP_DIR}/${ASPOSE_JAR}

# Kopieer de broncode
COPY TestAspose.java ${APP_DIR}/

# Maak het uitvoer‑script
RUN echo '#!/bin/bash' > ${APP_DIR}/run.sh && \
    echo 'java --add-opens=java.desktop/sun.java2d=ALL-UNNAMED \' >> ${APP_DIR}/run.sh && \
    echo '     --add-opens=java.desktop/sun.awt.image=ALL-UNNAMED \' >> ${APP_DIR}/run.sh && \
    echo '     --add-opens=java.desktop/sun.font=ALL-UNNAMED \' >> ${APP_DIR}/run.sh && \
    echo '     -cp ".:'"${ASPOSE_JAR}"'" TestAspose' >> ${APP_DIR}/run.sh && \
    chmod +x ${APP_DIR}/run.sh

# Verleen expliciet uitvoerrechten aan het script
RUN chmod 755 ${APP_DIR}/run.sh

# Compileer de Java‑code
RUN javac -cp "${APP_DIR}/${ASPOSE_JAR}" ${APP_DIR}/TestAspose.java

# Stel de werkmap in
WORKDIR /tmp

CMD ["sh", "-c", "/tmp/run.sh && cp /tmp/output/output.pdf /output"]
```

### **Java‑applicatie**

Maak `TestAspose.java` aan met:
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

## **4. Bouwen en uitvoeren**

### **Image bouwen**

   Voer de volgende opdracht uit in de map waarin uw Dockerfile zich bevindt om de Docker‑image te bouwen:
   ```powershell
   docker build -t aspose-test .
   ```
- `-t` geeft de image de naam "aspose-test"
- `.` gebruikt de Dockerfile uit de huidige map

### **Container uitvoeren**

   Voer de volgende opdracht uit in de map waarin uw Dockerfile zich bevindt om de Docker‑container uit te voeren:
   ```powershell
   docker run -v "$(pwd)/output:/output" aspose-test
   ```
- `-v` koppelt de output‑map
- Maakt `output.pdf` aan in uw lokale `output`‑map