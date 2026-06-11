---
title: Jak uruchomić Aspose.Slides dla języka Java w Dockerze
type: docs
weight: 75
url: /pl/java/how-to-run-aspose-slides-in-docker/
keywords:
- pobierz Aspose.Slides
- zainstaluj Aspose.Slides
- instalacja Aspose.Slides
- Docker
- Windows
- macOS
- Linux
- kompatybilność wieloplatformowa
- izolacja zależności
- uproszczone wdrażanie
- konfiguracja projektu
- PowerPoint
- OpenDocument
- prezentacja
- Java
- Aspose.Slides
description: "Uruchom Aspose.Slides w kontenerach Docker: skonfiguruj obrazy, zależności, czcionki i licencjonowanie, aby tworzyć skalowalne usługi przetwarzające PowerPoint i OpenDocument."
---
## **Wprowadzenie**

Ten przewodnik wyjaśnia, jak konteneryzować aplikację Java przy użyciu Aspose Slides i Dockera. Główne korzyści to:

- **Kompatybilność wieloplatformowa** - Działa na systemach Windows, macOS i Linux
- **Izolacja zależności** - Nie wymaga instalacji systemowych
- **Uproszczone wdrażanie** - Łatwe udostępnianie i uruchamianie

## **1. Instalacja Dockera**

### **Windows**

**Wymagania:**

- Windows 10/11 Pro/Enterprise/Education (64-bit) z włączonym WSL 2
- Dla edycji Home: wymagana ręczna instalacja WSL 2

**Kroki:**

1. Pobierz [Docker Desktop for Windows](https://www.docker.com/products/docker-desktop/)
2. Uruchom instalator i postępuj zgodnie z kreatorem instalacji
3. Zrestartuj komputer, gdy zostaniesz o to poproszony
4. Zweryfikuj instalację:
   ```powershell
   docker --version
   ```

### **macOS**

**Wymagania:**

- macOS 10.15 (Catalina) lub nowszy
- Procesor Apple Silicon lub Intel

**Kroki:**

1. Pobierz [Docker Desktop for Mac](https://www.docker.com/products/docker-desktop/)
2. Przeciągnij aplikację do folderu `Applications`
3. Uruchom Docker i poczekaj na inicjalizację
4. Zweryfikuj instalację:
   ```bash
   docker --version
   ```

### **Linux (Ubuntu/Debian)**

**Instalacja:**

```bash
# Aktualizuj listy pakietów
sudo apt update && sudo apt upgrade -y

# Zainstaluj wymagane zależności
sudo apt install -y \
    apt-transport-https \
    ca-certificates \
    curl \
    software-properties-common

# Dodaj oficjalny klucz GPG Dockera
curl -fsSL https://download.docker.com/linux/ubuntu/gpg | sudo gpg --dearmor -o /usr/share/keyrings/docker-archive-keyring.gpg

# Dodaj stabilne repozytorium
echo "deb [arch=amd64 signed-by=/usr/share/keyrings/docker-archive-keyring.gpg] https://download.docker.com/linux/ubuntu $(lsb_release -cs) stable" | sudo tee /etc/apt/sources.list.d/docker.list > /dev/null

# Zainstaluj silnik Docker
sudo apt update
sudo apt install -y docker-ce docker-ce-cli containerd.io

# Zezwól bieżącemu użytkownikowi na wykonywanie poleceń Docker
sudo usermod -aG docker $USER
newgrp docker

# Zweryfikuj instalację
docker --version
```

## **2. Konfiguracja Dockerfile**

### **Obraz bazowy**

```dockerfile
FROM ubuntu:24.04
```
> **Notatka**: Używa [official Ubuntu image](https://hub.docker.com/_/ubuntu) z Docker Hub.

### **Zależności**

```dockerfile
RUN apt-get install -y openjdk-11-jdk wget fontconfig ttf-mscorefonts-installer
```
- **OpenJDK 11**: środowisko uruchomieniowe Java
- **Font packages**: zawiera Microsoft Core Fonts

### **Konfiguracja Aspose.Slides**

```dockerfile
ENV ASPOSE_VERSION=25.3

ENV ASPOSE_JAR=aspose-slides-${ASPOSE_VERSION}-jdk16.jar
ENV ASPOSE_URL=https://releases.aspose.com/java/repo/com/aspose/aspose-slides/${ASPOSE_VERSION}/${ASPOSE_JAR}
```
- Pobranie biblioteki Aspose Slides z określoną wersją

## **3. Konfiguracja projektu**

### **Struktura plików**

```
aspose-docker/
├── Dockerfile          # Konfiguracja kontenera
├── TestAspose.java     # Kod aplikacji
└── output/             # Folder z wygenerowanymi plikami PDF (tworzony automatycznie)
```

### **Dockerfile**

Utwórz plik o nazwie `Dockerfile` z:
```dockerfile
FROM ubuntu:24.04

# Ustaw zmienne środowiskowe
ENV JAVA_HOME=/usr/lib/jvm/java-11-openjdk-amd64
ENV PATH=$JAVA_HOME/bin:$PATH
ENV APP_DIR=/tmp
ENV ASPOSE_VERSION=25.3
ENV ASPOSE_JAR=aspose-slides-${ASPOSE_VERSION}-jdk16.jar
ENV ASPOSE_URL=https://releases.aspose.com/java/repo/com/aspose/aspose-slides/${ASPOSE_VERSION}/${ASPOSE_JAR}

# Utwórz katalog roboczy
RUN mkdir -p ${APP_DIR}
WORKDIR ${APP_DIR}

# Zainstaluj zależności
RUN apt-get update && \
    apt-get install -y --no-install-recommends \
    openjdk-11-jdk \
    wget \
    fontconfig \
    ttf-mscorefonts-installer && \
    rm -rf /var/lib/apt/lists/*

# Skonfiguruj czcionki
RUN echo "ttf-mscorefonts-installer msttcorefonts/accepted-mscorefonts-eula select true" | debconf-set-selections && \
    apt-get update && \
    apt-get install -y --no-install-recommends ttf-mscorefonts-installer && \
    fc-cache -f -v

# Pobierz Aspose.Slides do /tmp
RUN wget ${ASPOSE_URL} -O ${APP_DIR}/${ASPOSE_JAR}

# Skopiuj kod źródłowy
COPY TestAspose.java ${APP_DIR}/

# Utwórz skrypt uruchomieniowy
RUN echo '#!/bin/bash' > ${APP_DIR}/run.sh && \
    echo 'java --add-opens=java.desktop/sun.java2d=ALL-UNNAMED \' >> ${APP_DIR}/run.sh && \
    echo '     --add-opens=java.desktop/sun.awt.image=ALL-UNNAMED \' >> ${APP_DIR}/run.sh && \
    echo '     --add-opens=java.desktop/sun.font=ALL-UNNAMED \' >> ${APP_DIR}/run.sh && \
    echo '     -cp ".:'"${ASPOSE_JAR}"'" TestAspose' >> ${APP_DIR}/run.sh && \
    chmod +x ${APP_DIR}/run.sh

# Jawnie przyznaj uprawnienia do wykonywania skryptowi
RUN chmod 755 ${APP_DIR}/run.sh

# Skompiluj kod Java
RUN javac -cp "${APP_DIR}/${ASPOSE_JAR}" ${APP_DIR}/TestAspose.java

# Ustaw katalog roboczy
WORKDIR /tmp

CMD ["sh", "-c", "/tmp/run.sh && cp /tmp/output/output.pdf /output"]
```

### **Aplikacja Java**

Utwórz `TestAspose.java` z:
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

## **4. Budowanie i uruchamianie**

### **Budowanie obrazu**

   Uruchom następujące polecenie w katalogu, w którym znajduje się Twój Dockerfile, aby zbudować obraz Docker:
   ```powershell
   docker build -t aspose-test .
   ```
   
- `-t` nazywa obraz "aspose-test"
- `.` używa Dockerfile z bieżącego katalogu

### **Uruchomienie kontenera**

   Uruchom następujące polecenie w katalogu, w którym znajduje się Twój Dockerfile, aby uruchomić kontener Docker:
   ```powershell
   docker run -v "$(pwd)/output:/output" aspose-test
   ```
   
- `-v` montuje katalog wyjściowy
- Tworzy `output.pdf` w lokalnym folderze `output`