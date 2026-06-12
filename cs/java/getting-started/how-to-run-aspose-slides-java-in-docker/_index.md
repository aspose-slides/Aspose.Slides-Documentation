---
title: Jak spustit Aspose.Slides pro Java v Dockeru
type: docs
weight: 75
url: /cs/java/how-to-run-aspose-slides-in-docker/
keywords:
- stáhnout Aspose.Slides
- nainstalovat Aspose.Slides
- Instalace Aspose.Slides
- Docker
- Windows
- macOS
- Linux
- kompatibilita napříč platformami
- izolace závislostí
- zjednodušené nasazení
- nastavení projektu
- PowerPoint
- OpenDocument
- prezentace
- Java
- Aspose.Slides
description: "Spusťte Aspose.Slides v Docker kontejnerech: nakonfigurujte obrazy, závislosti, fonty a licencování a vytvořte škálovatelné služby zpracovávající PowerPoint a OpenDocument."
---
## **Úvod**

Tento průvodce vysvětluje, jak kontejnerizovat Java aplikaci pomocí Aspose Slides s Dockerem. Hlavní výhody zahrnují:

- **Kompatibilita napříč platformami** - běží na Windows, macOS a Linuxu
- **Izolace závislostí** - není vyžadována instalace na úrovni systému
- **Zjednodušené nasazení** - snadné sdílení a spuštění

## **1. Instalace Dockeru**

### **Windows**

**Požadavky:**

- Windows 10/11 Pro/Enterprise/Education (64-bit) s povoleným WSL 2
- Pro edici Home: vyžaduje ruční instalaci WSL 2

**Kroky:**

1. Stáhněte [Docker Desktop pro Windows](https://www.docker.com/products/docker-desktop/)
2. Spusťte instalátor a postupujte podle průvodce nastavením
3. Restartujte počítač, když bude vyzváno
4. Ověřte instalaci:
   ```powershell
   docker --version
   ```

### **macOS**

**Požadavky:**

- macOS 10.15 (Catalina) nebo novější
- Procesor Apple Silicon nebo Intel

**Kroky:**

1. Stáhněte [Docker Desktop pro Mac](https://www.docker.com/products/docker-desktop/)
2. Přetáhněte aplikaci do složky `Applications`
3. Spusťte Docker a počkejte na inicializaci
4. Ověřte instalaci:
   ```bash
   docker --version
   ```

### **Linux (Ubuntu/Debian)**

**Instalace:**

```bash
# Aktualizovat seznam balíčků
sudo apt update && sudo apt upgrade -y

# Instalovat požadavky
sudo apt install -y \
    apt-transport-https \
    ca-certificates \
    curl \
    software-properties-common

# Přidat oficiální GPG klíč Dockeru
curl -fsSL https://download.docker.com/linux/ubuntu/gpg | sudo gpg --dearmor -o /usr/share/keyrings/docker-archive-keyring.gpg

# Přidat stabilní repozitář
echo "deb [arch=amd64 signed-by=/usr/share/keyrings/docker-archive-keyring.gpg] https://download.docker.com/linux/ubuntu $(lsb_release -cs) stable" | sudo tee /etc/apt/sources.list.d/docker.list > /dev/null

# Instalovat Docker Engine
sudo apt update
sudo apt install -y docker-ce docker-ce-cli containerd.io

# Povolit aktuálnímu uživateli spouštět Docker příkazy
sudo usermod -aG docker $USER
newgrp docker

# Ověřit instalaci
docker --version
```

## **2. Konfigurace Dockerfile**

### **Základní obraz**

```dockerfile
FROM ubuntu:24.04
```
> **Poznámka**: Používá [oficiální obraz Ubuntu](https://hub.docker.com/_/ubuntu) z Docker Hub.

### **Závislosti**

```dockerfile
RUN apt-get install -y openjdk-11-jdk wget fontconfig ttf-mscorefonts-installer
```
- **OpenJDK 11**: běhové prostředí Java
- **Balíčky fontů**: obsahuje Microsoft Core Fonts

### **Nastavení Aspose.Slides**

```dockerfile
ENV ASPOSE_VERSION=25.3

ENV ASPOSE_JAR=aspose-slides-${ASPOSE_VERSION}-jdk16.jar
ENV ASPOSE_URL=https://releases.aspose.com/java/repo/com/aspose/aspose-slides/${ASPOSE_VERSION}/${ASPOSE_JAR}
```
- Stažení knihovny Aspose Slides s pevně určenou verzí

## **3. Nastavení projektu**

### **Struktura souborů**

```
aspose-docker/
├── Dockerfile          # Konfigurace kontejneru
├── TestAspose.java     # Kód aplikace
└── output/             # Složka s vygenerovanými PDF (vytvořeno automaticky)
```

### **Dockerfile**

Vytvořte soubor s názvem `Dockerfile` s obsahem:
```dockerfile
FROM ubuntu:24.04

# Nastavit proměnné prostředí
ENV JAVA_HOME=/usr/lib/jvm/java-11-openjdk-amd64
ENV PATH=$JAVA_HOME/bin:$PATH
ENV APP_DIR=/tmp
ENV ASPOSE_VERSION=25.3
ENV ASPOSE_JAR=aspose-slides-${ASPOSE_VERSION}-jdk16.jar
ENV ASPOSE_URL=https://releases.aspose.com/java/repo/com/aspose/aspose-slides/${ASPOSE_VERSION}/${ASPOSE_JAR}

# Vytvořit pracovní adresář
RUN mkdir -p ${APP_DIR}
WORKDIR ${APP_DIR}

# Nainstalovat závislosti
RUN apt-get update && \
    apt-get install -y --no-install-recommends \
    openjdk-11-jdk \
    wget \
    fontconfig \
    ttf-mscorefonts-installer && \
    rm -rf /var/lib/apt/lists/*

# Nastavit fonty
RUN echo "ttf-mscorefonts-installer msttcorefonts/accepted-mscorefonts-eula select true" | debconf-set-selections && \
    apt-get update && \
    apt-get install -y --no-install-recommends ttf-mscorefonts-installer && \
    fc-cache -f -v

# Stáhnout Aspose.Slides do /tmp
RUN wget ${ASPOSE_URL} -O ${APP_DIR}/${ASPOSE_JAR}

# Zkopírovat zdrojový kód
COPY TestAspose.java ${APP_DIR}/

# Vytvořit spouštěcí skript
RUN echo '#!/bin/bash' > ${APP_DIR}/run.sh && \
    echo 'java --add-opens=java.desktop/sun.java2d=ALL-UNNAMED \' >> ${APP_DIR}/run.sh && \
    echo '     --add-opens=java.desktop/sun.awt.image=ALL-UNNAMED \' >> ${APP_DIR}/run.sh && \
    echo '     --add-opens=java.desktop/sun.font=ALL-UNNAMED \' >> ${APP_DIR}/run.sh && \
    echo '     -cp ".:'"${ASPOSE_JAR}"'" TestAspose' >> ${APP_DIR}/run.sh && \
    chmod +x ${APP_DIR}/run.sh

# Explicitně udělit práva spouštění skriptu
RUN chmod 755 ${APP_DIR}/run.sh

# Zkompilovat Java kód
RUN javac -cp "${APP_DIR}/${ASPOSE_JAR}" ${APP_DIR}/TestAspose.java

# Nastavit pracovní adresář
WORKDIR /tmp

CMD ["sh", "-c", "/tmp/run.sh && cp /tmp/output/output.pdf /output"]
```

### **Java aplikace**

Vytvořte `TestAspose.java` s obsahem:
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

## **4. Sestavení a spuštění**

### **Sestavení obrazu**

   Spusťte následující příkaz v adresáři, kde se nachází váš Dockerfile, pro vytvoření Docker obrazu:
   ```powershell
   docker build -t aspose-test .
   ```
   
- `-t` pojmenovává obraz "aspose-test"
- `.` používá Dockerfile z aktuálního adresáře

### **Spuštění kontejneru**

   Spusťte následující příkaz v adresáři, kde se nachází váš Dockerfile, pro spuštění Docker kontejneru:
   ```powershell
   docker run -v "$(pwd)/output:/output" aspose-test
   ```
   
- `-v` připojí výstupní adresář
- Vytvoří `output.pdf` ve vaší místní složce `output`