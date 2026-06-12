---
title: Come eseguire Aspose.Slides per Java in Docker
type: docs
weight: 75
url: /it/java/how-to-run-aspose-slides-in-docker/
keywords:
- scarica Aspose.Slides
- installa Aspose.Slides
- installazione Aspose.Slides
- Docker
- Windows
- macOS
- Linux
- compatibilità multipiattaforma
- isolamento delle dipendenze
- distribuzione semplificata
- configurazione del progetto
- PowerPoint
- OpenDocument
- presentazione
- Java
- Aspose.Slides
description: "Esegui Aspose.Slides in contenitori Docker: configura immagini, dipendenze, font e licenze per creare servizi scalabili che elaborano PowerPoint e OpenDocument."
---
## **Introduzione**

Questa guida spiega come containerizzare un'applicazione Java utilizzando Aspose Slides con Docker. I principali vantaggi includono:

- **Compatibilità multipiattaforma** - Funziona su Windows, macOS e Linux
- **Isolamento delle dipendenze** - Non sono necessarie installazioni a livello di sistema
- **Distribuzione semplificata** - Condivisione ed esecuzione facili

## **1. Installazione di Docker**

### **Windows**

**Requisiti:**

- Windows 10/11 Pro/Enterprise/Education (64-bit) con WSL 2 abilitato
- Per l'edizione Home: richiede installazione manuale di WSL 2

**Passaggi:**

1. Scarica [Docker Desktop per Windows](https://www.docker.com/products/docker-desktop/)
2. Esegui il programma di installazione e segui la procedura guidata
3. Riavvia il computer quando richiesto
4. Verifica l'installazione:
   ```powershell
   docker --version
   ```

### **macOS**

**Requisiti:**

- macOS 10.15 (Catalina) o versioni successive
- Processore Apple Silicon o Intel

**Passaggi:**

1. Scarica [Docker Desktop per Mac](https://www.docker.com/products/docker-desktop/)
2. Trascina l'applicazione nella cartella `Applications`
3. Avvia Docker e attendi l'inizializzazione
4. Verifica l'installazione:
   ```bash
   docker --version
   ```

### **Linux (Ubuntu/Debian)**

**Installazione:**

```bash
# Aggiorna le liste dei pacchetti
sudo apt update && sudo apt upgrade -y

# Installa i prerequisiti
sudo apt install -y \
    apt-transport-https \
    ca-certificates \
    curl \
    software-properties-common

# Aggiungi la chiave GPG ufficiale di Docker
curl -fsSL https://download.docker.com/linux/ubuntu/gpg | sudo gpg --dearmor -o /usr/share/keyrings/docker-archive-keyring.gpg

# Aggiungi un repository stabile
echo "deb [arch=amd64 signed-by=/usr/share/keyrings/docker-archive-keyring.gpg] https://download.docker.com/linux/ubuntu $(lsb_release -cs) stable" | sudo tee /etc/apt/sources.list.d/docker.list > /dev/null

# Installa il motore Docker
sudo apt update
sudo apt install -y docker-ce docker-ce-cli containerd.io

# Consenti all'utente corrente di eseguire comandi Docker
sudo usermod -aG docker $USER
newgrp docker

# Verifica l'installazione
docker --version
```

## **2. Configurazione del Dockerfile**

### **Immagine di base**

```dockerfile
FROM ubuntu:24.04
```
> **Nota**: Usa l'[immagine Ubuntu ufficiale](https://hub.docker.com/_/ubuntu) da Docker Hub.

### **Dipendenze**

```dockerfile
RUN apt-get install -y openjdk-11-jdk wget fontconfig ttf-mscorefonts-installer
```
- **OpenJDK 11**: ambiente di runtime Java
- **Pacchetti di font**: Include Microsoft Core Fonts

### **Configurazione di Aspose.Slides**

```dockerfile
ENV ASPOSE_VERSION=25.3

ENV ASPOSE_JAR=aspose-slides-${ASPOSE_VERSION}-jdk16.jar
ENV ASPOSE_URL=https://releases.aspose.com/java/repo/com/aspose/aspose-slides/${ASPOSE_VERSION}/${ASPOSE_JAR}
```
- Download della libreria Aspose Slides con versione fissata

## **3. Configurazione del progetto**

### **Struttura dei file**

```
aspose-docker/
├── Dockerfile          # Configurazione del contenitore
├── TestAspose.java     # Codice dell'applicazione
└── output/             # Cartella con PDF generati (creata automaticamente)
```

### **Dockerfile**

Crea un file chiamato `Dockerfile` con:
```dockerfile
FROM ubuntu:24.04

# Imposta le variabili d'ambiente
ENV JAVA_HOME=/usr/lib/jvm/java-11-openjdk-amd64
ENV PATH=$JAVA_HOME/bin:$PATH
ENV APP_DIR=/tmp
ENV ASPOSE_VERSION=25.3
ENV ASPOSE_JAR=aspose-slides-${ASPOSE_VERSION}-jdk16.jar
ENV ASPOSE_URL=https://releases.aspose.com/java/repo/com/aspose/aspose-slides/${ASPOSE_VERSION}/${ASPOSE_JAR}

# Crea una directory di lavoro
RUN mkdir -p ${APP_DIR}
WORKDIR ${APP_DIR}

# Installa le dipendenze
RUN apt-get update && \
    apt-get install -y --no-install-recommends \
    openjdk-11-jdk \
    wget \
    fontconfig \
    ttf-mscorefonts-installer && \
    rm -rf /var/lib/apt/lists/*

# Configura i font
RUN echo "ttf-mscorefonts-installer msttcorefonts/accepted-mscorefonts-eula select true" | debconf-set-selections && \
    apt-get update && \
    apt-get install -y --no-install-recommends ttf-mscorefonts-installer && \
    fc-cache -f -v

# Scarica Aspose.Slides in /tmp
RUN wget ${ASPOSE_URL} -O ${APP_DIR}/${ASPOSE_JAR}

# Copia il codice sorgente
COPY TestAspose.java ${APP_DIR}/

# Crea lo script di esecuzione
RUN echo '#!/bin/bash' > ${APP_DIR}/run.sh && \
    echo 'java --add-opens=java.desktop/sun.java2d=ALL-UNNAMED \' >> ${APP_DIR}/run.sh && \
    echo '     --add-opens=java.desktop/sun.awt.image=ALL-UNNAMED \' >> ${APP_DIR}/run.sh && \
    echo '     --add-opens=java.desktop/sun.font=ALL-UNNAMED \' >> ${APP_DIR}/run.sh && \
    echo '     -cp ".:'"${ASPOSE_JAR}"'" TestAspose' >> ${APP_DIR}/run.sh && \
    chmod +x ${APP_DIR}/run.sh

# Concedi esplicitamente i permessi di esecuzione allo script
RUN chmod 755 ${APP_DIR}/run.sh

# Compila il codice Java
RUN javac -cp "${APP_DIR}/${ASPOSE_JAR}" ${APP_DIR}/TestAspose.java

# Imposta la directory di lavoro
WORKDIR /tmp

CMD ["sh", "-c", "/tmp/run.sh && cp /tmp/output/output.pdf /output"]
```

### **Applicazione Java**

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

## **4. Compilazione ed esecuzione**

### **Creare l'immagine**

Esegui il comando seguente nella directory in cui si trova il tuo Dockerfile per costruire l'immagine Docker:
```powershell
   docker build -t aspose-test .
   ```

- `-t` assegna all'immagine il nome "aspose-test"
- `.` utilizza il Dockerfile della directory corrente

### **Eseguire il contenitore**

Esegui il comando seguente nella directory in cui si trova il tuo Dockerfile per avviare il contenitore Docker:
```powershell
   docker run -v "$(pwd)/output:/output" aspose-test
   ```

- `-v` monta la directory di output
- Crea `output.pdf` nella tua cartella locale `output`