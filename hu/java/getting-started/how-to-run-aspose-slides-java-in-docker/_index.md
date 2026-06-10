---
title: Az Aspose.Slides for Java futtatása Dockerben
type: docs
weight: 75
url: /hu/java/how-to-run-aspose-slides-in-docker/
keywords:
- Aspose.Slides letöltése
- Aspose.Slides telepítése
- Aspose.Slides telepítés
- Docker
- Windows
- macOS
- Linux
- platformfüggetlen kompatibilitás
- függőség izolálás
- egyszerűsített telepítés
- projekt beállítása
- PowerPoint
- OpenDocument
- prezentáció
- Java
- Aspose.Slides
description: "Az Aspose.Slides futtatása Docker konténerekben: képek, függőségek, betűkészletek és licenc beállítása, hogy skálázható szolgáltatásokat építsünk, amelyek feldolgozzák a PowerPoint és OpenDocument fájlokat."
---
## **Bevezetés**

Ez az útmutató elmagyarázza, hogyan lehet konténerizálni egy Java alkalmazást az Aspose Slides segítségével Docker környezetben. A fő előnyök a következők:

- **Platformok közötti kompatibilitás** – Windows, macOS és Linux rendszereken fut
- **Függőségek izolálása** – Nem szükséges rendszerszintű telepítésekkel
- **Egyszerűsített telepítés** – Könnyű megosztás és futtatás

## **1. Docker telepítése**

### **Windows**

**Követelmények:**

- Windows 10/11 Pro/Enterprise/Education (64 bites) WSL 2 engedélyezéssel
- Home kiadás esetén: manuális WSL 2 telepítést igényel

**Lépések:**

1. Töltse le a [Docker Desktop for Windows](https://www.docker.com/products/docker-desktop/) alkalmazást
2. Futtassa a telepítőt és kövesse a beállítóvarázslót
3. Indítsa újra a számítógépet a felszólításkor
4. Ellenőrizze a telepítést:
   ```powershell
   docker --version
   ```

### **macOS**

**Követelmények:**

- macOS 10.15 (Catalina) vagy újabb
- Apple Silicon vagy Intel processzor

**Lépések:**

1. Töltse le a [Docker Desktop for Mac](https://www.docker.com/products/docker-desktop/) alkalmazást
2. Húzza az alkalmazást az `Applications` mappába
3. Indítsa el a Docker-t, és várja meg az inicializálást
4. Ellenőrizze a telepítést:
   ```bash
   docker --version
   ```

### **Linux (Ubuntu/Debian)**

**Telepítés:**

```bash
   # Frissítse a csomaglistákat
   sudo apt update && sudo apt upgrade -y

   # Telepítse az előfeltételeket
   sudo apt install -y \
       apt-transport-https \
       ca-certificates \
       curl \
       software-properties-common

   # Docker hivatalos GPG kulcsának hozzáadása
   curl -fsSL https://download.docker.com/linux/ubuntu/gpg | sudo gpg --dearmor -o /usr/share/keyrings/docker-archive-keyring.gpg

   # Stabil tároló hozzáadása
   echo "deb [arch=amd64 signed-by=/usr/share/keyrings/docker-archive-keyring.gpg] https://download.docker.com/linux/ubuntu $(lsb_release -cs) stable" | sudo tee /etc/apt/sources.list.d/docker.list > /dev/null

   # Docker Engine telepítése
   sudo apt update
   sudo apt install -y docker-ce docker-ce-cli containerd.io

   # Engedélyezze a jelenlegi felhasználónak a Docker parancsok futtatását
   sudo usermod -aG docker $USER
   newgrp docker

   # Telepítés ellenőrzése
   docker --version
```

## **2. Dockerfile konfiguráció**

### **Alap kép**

```dockerfile
FROM ubuntu:24.04
```
> **Megjegyzés**: Az [hivatalos Ubuntu képet](https://hub.docker.com/_/ubuntu) használja a Docker Hub-ról.

### **Függőségek**

```dockerfile
RUN apt-get install -y openjdk-11-jdk wget fontconfig ttf-mscorefonts-installer
```
- **OpenJDK 11**: Java futtatókörnyezet
- **Betűcsomagok**: Tartalmazza a Microsoft Core Fonts-ot

### **Aspose.Slides beállítás**

```dockerfile
ENV ASPOSE_VERSION=25.3

ENV ASPOSE_JAR=aspose-slides-${ASPOSE_VERSION}-jdk16.jar
ENV ASPOSE_URL=https://releases.aspose.com/java/repo/com/aspose/aspose-slides/${ASPOSE_VERSION}/${ASPOSE_JAR}
```
- Verzióhoz rögzített letöltés az Aspose Slides könyvtárból

## **3. Projekt beállítása**

### **Fájlstruktúra**

```
aspose-docker/
├── Dockerfile          # Konténer konfiguráció
├── TestAspose.java     # Alkalmazás kódja
└── output/             # Mappa a generált PDF-ekkel (automatikusan létrehozva)
```

### **Dockerfile**

Hozzon létre egy `Dockerfile` nevű fájlt a következő tartalommal:
```dockerfile
FROM ubuntu:24.04

# Környezeti változók beállítása
ENV JAVA_HOME=/usr/lib/jvm/java-11-openjdk-amd64
ENV PATH=$JAVA_HOME/bin:$PATH
ENV APP_DIR=/tmp
ENV ASPOSE_VERSION=25.3
ENV ASPOSE_JAR=aspose-slides-${ASPOSE_VERSION}-jdk16.jar
ENV ASPOSE_URL=https://releases.aspose.com/java/repo/com/aspose/aspose-slides/${ASPOSE_VERSION}/${ASPOSE_JAR}

# Munkakönyvtár létrehozása
RUN mkdir -p ${APP_DIR}
WORKDIR ${APP_DIR}

# Függőségek telepítése
RUN apt-get update && \
    apt-get install -y --no-install-recommends \
    openjdk-11-jdk \
    wget \
    fontconfig \
    ttf-mscorefonts-installer && \
    rm -rf /var/lib/apt/lists/*

# Betűkészletek konfigurálása
RUN echo "ttf-mscorefonts-installer msttcorefonts/accepted-mscorefonts-eula select true" | debconf-set-selections && \
    apt-get update && \
    apt-get install -y --no-install-recommends ttf-mscorefonts-installer && \
    fc-cache -f -v

# Aspose.Slides letöltése a /tmp mappába
RUN wget ${ASPOSE_URL} -O ${APP_DIR}/${ASPOSE_JAR}

# Forráskód másolása
COPY TestAspose.java ${APP_DIR}/

# Futtatási szkript létrehozása
RUN echo '#!/bin/bash' > ${APP_DIR}/run.sh && \
    echo 'java --add-opens=java.desktop/sun.java2d=ALL-UNNAMED \' >> ${APP_DIR}/run.sh && \
    echo '     --add-opens=java.desktop/sun.awt.image=ALL-UNNAMED \' >> ${APP_DIR}/run.sh && \
    echo '     --add-opens=java.desktop/sun.font=ALL-UNNAMED \' >> ${APP_DIR}/run.sh && \
    echo '     -cp ".:'"${ASPOSE_JAR}"'" TestAspose' >> ${APP_DIR}/run.sh && \
    chmod +x ${APP_DIR}/run.sh

# Kifejezetten adja meg a végrehajtási jogosultságot a szkriptnek
RUN chmod 755 ${APP_DIR}/run.sh

# Java kód fordítása
RUN javac -cp "${APP_DIR}/${ASPOSE_JAR}" ${APP_DIR}/TestAspose.java

# Munkakönyvtár beállítása
WORKDIR /tmp

CMD ["sh", "-c", "/tmp/run.sh && cp /tmp/output/output.pdf /output"]
```

### **Java alkalmazás**

Hozzon létre egy `TestAspose.java` fájlt a következő tartalommal:
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

## **4. Felépítés és futtatás**

### **Képfájl építése**

Futtassa a következő parancsot abban a könyvtárban, ahol a Dockerfile található, a Docker kép felépítéséhez:
```powershell
   docker build -t aspose-test .
   ```

- `-t` a képet "aspose-test" névre jelöli
- `.` az aktuális könyvtár Dockerfile-ját használja

### **Konténer futtatása**

Futtassa a következő parancsot abban a könyvtárban, ahol a Dockerfile található, a Docker konténer futtatásához:
```powershell
   docker run -v "$(pwd)/output:/output" aspose-test
   ```

- `-v` csatolja a kimeneti könyvtárat
- Létrehozza az `output.pdf` fájlt a helyi `output` mappában