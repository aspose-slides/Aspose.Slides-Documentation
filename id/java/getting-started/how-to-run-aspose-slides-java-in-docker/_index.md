---
title: Cara Menjalankan Aspose.Slides untuk Java di Docker
type: docs
weight: 75
url: /id/java/how-to-run-aspose-slides-in-docker/
keywords:
- unduh Aspose.Slides
- pasang Aspose.Slides
- Instalasi Aspose.Slides
- Docker
- Windows
- macOS
- Linux
- kompatibilitas lintas platform
- isolasi dependensi
- penyebaran yang disederhanakan
- penyiapan proyek
- PowerPoint
- OpenDocument
- presentasi
- Java
- Aspose.Slides
description: "Jalankan Aspose.Slides dalam kontainer Docker: konfigurasikan gambar, dependensi, font, dan lisensi untuk membangun layanan skalabel yang memproses PowerPoint dan OpenDocument."
---
## **Pendahuluan**

Panduan ini menjelaskan cara mengontainerkan aplikasi Java menggunakan Aspose Slides dengan Docker. Manfaat utama meliputi:

- **Kompatibilitas lintas platform** - Berjalan di Windows, macOS, dan Linux
- **Isolasi dependensi** - Tidak memerlukan instalasi di seluruh sistem
- **Penyebaran yang disederhanakan** - Berbagi dan menjalankan dengan mudah

## **1. Instalasi Docker**

### **Windows**

**Persyaratan:**

- Windows 10/11 Pro/Enterprise/Education (64-bit) dengan WSL 2 diaktifkan
- Untuk edisi Home: Memerlukan instalasi WSL 2 manual

**Langkah:**

1. Unduh [Docker Desktop for Windows](https://www.docker.com/products/docker-desktop/)
2. Jalankan installer dan ikuti wizard penyiapan
3. Restart komputer Anda ketika diminta
4. Verifikasi instalasi:
   ```powershell
   docker --version
   ```

### **macOS**

**Persyaratan:**

- macOS 10.15 (Catalina) atau lebih baru
- Prosesor Apple Silicon atau Intel

**Langkah:**

1. Unduh [Docker Desktop for Mac](https://www.docker.com/products/docker-desktop/)
2. Seret aplikasi ke folder `Applications` Anda
3. Luncurkan Docker dan tunggu inisialisasi
4. Verifikasi instalasi:
   ```bash
   docker --version
   ```

### **Linux (Ubuntu/Debian)**

**Instalasi:**

```bash
   # Perbarui daftar paket
   sudo apt update && sudo apt upgrade -y

   # Pasang prasyarat
   sudo apt install -y \
       apt-transport-https \
       ca-certificates \
       curl \
       software-properties-common

   # Tambahkan kunci GPG resmi Docker
   curl -fsSL https://download.docker.com/linux/ubuntu/gpg | sudo gpg --dearmor -o /usr/share/keyrings/docker-archive-keyring.gpg

   # Tambahkan repositori stabil
   echo "deb [arch=amd64 signed-by=/usr/share/keyrings/docker-archive-keyring.gpg] https://download.docker.com/linux/ubuntu $(lsb_release -cs) stable" | sudo tee /etc/apt/sources.list.d/docker.list > /dev/null

   # Pasang Docker Engine
   sudo apt update
   sudo apt install -y docker-ce docker-ce-cli containerd.io

   # Izinkan pengguna saat ini menjalankan perintah Docker
   sudo usermod -aG docker $USER
   newgrp docker

   # Verifikasi instalasi
   docker --version
```

## **2. Konfigurasi Dockerfile**

### **Gambar Dasar**

```dockerfile
FROM ubuntu:24.04
```
> **Catatan**: Menggunakan [gambar Ubuntu resmi](https://hub.docker.com/_/ubuntu) dari Docker Hub.

### **Dependensi**

```dockerfile
RUN apt-get install -y openjdk-11-jdk wget fontconfig ttf-mscorefonts-installer
```
- **OpenJDK 11**: Lingkungan runtime Java
- **Font packages**: Termasuk Microsoft Core Fonts

### **Pengaturan Aspose.Slides**

```dockerfile
ENV ASPOSE_VERSION=25.3

ENV ASPOSE_JAR=aspose-slides-${ASPOSE_VERSION}-jdk16.jar
ENV ASPOSE_URL=https://releases.aspose.com/java/repo/com/aspose/aspose-slides/${ASPOSE_VERSION}/${ASPOSE_JAR}
```
- Unduhan perpustakaan Aspose Slides dengan versi yang dipatok

## **3. Pengaturan Proyek**

### **Struktur Berkas**

```
aspose-docker/
├── Dockerfile          # Konfigurasi kontainer
├── TestAspose.java     # Kode aplikasi
└── output/             # Folder dengan PDF yang dihasilkan (dibuat otomatis)
```

### **Dockerfile**

Buat file bernama `Dockerfile` dengan:
```dockerfile
FROM ubuntu:24.04

# Atur variabel lingkungan
ENV JAVA_HOME=/usr/lib/jvm/java-11-openjdk-amd64
ENV PATH=$JAVA_HOME/bin:$PATH
ENV APP_DIR=/tmp
ENV ASPOSE_VERSION=25.3
ENV ASPOSE_JAR=aspose-slides-${ASPOSE_VERSION}-jdk16.jar
ENV ASPOSE_URL=https://releases.aspose.com/java/repo/com/aspose/aspose-slides/${ASPOSE_VERSION}/${ASPOSE_JAR}

# Buat direktori kerja
RUN mkdir -p ${APP_DIR}
WORKDIR ${APP_DIR}

# Pasang dependensi
RUN apt-get update && \
    apt-get install -y --no-install-recommends \
    openjdk-11-jdk \
    wget \
    fontconfig \
    ttf-mscorefonts-installer && \
    rm -rf /var/lib/apt/lists/*

# Konfigurasikan font
RUN echo "ttf-mscorefonts-installer msttcorefonts/accepted-mscorefonts-eula select true" | debconf-set-selections && \
    apt-get update && \
    apt-get install -y --no-install-recommends ttf-mscorefonts-installer && \
    fc-cache -f -v

# Unduh Aspose.Slides ke /tmp
RUN wget ${ASPOSE_URL} -O ${APP_DIR}/${ASPOSE_JAR}

# Salin kode sumber
COPY TestAspose.java ${APP_DIR}/

# Buat skrip jalankan
RUN echo '#!/bin/bash' > ${APP_DIR}/run.sh && \
    echo 'java --add-opens=java.desktop/sun.java2d=ALL-UNNAMED \' >> ${APP_DIR}/run.sh && \
    echo '     --add-opens=java.desktop/sun.awt.image=ALL-UNNAMED \' >> ${APP_DIR}/run.sh && \
    echo '     --add-opens=java.desktop/sun.font=ALL-UNNAMED \' >> ${APP_DIR}/run.sh && \
    echo '     -cp ".:'"${ASPOSE_JAR}"'" TestAspose' >> ${APP_DIR}/run.sh && \
    chmod +x ${APP_DIR}/run.sh

# Beri izin eksekusi secara eksplisit ke skrip
RUN chmod 755 ${APP_DIR}/run.sh

# Kompilasi kode Java
RUN javac -cp "${APP_DIR}/${ASPOSE_JAR}" ${APP_DIR}/TestAspose.java

# Atur direktori kerja
WORKDIR /tmp

CMD ["sh", "-c", "/tmp/run.sh && cp /tmp/output/output.pdf /output"]
```

### **Aplikasi Java**

Buat `TestAspose.java` dengan:
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

## **4. Membangun dan Menjalankan**

### **Bangun Image**

Jalankan perintah berikut di direktori tempat Dockerfile Anda berada untuk membangun image Docker:
```powershell
   docker build -t aspose-test .
   ```

- `-t` memberi nama image "aspose-test"
- `.` menggunakan Dockerfile dari direktori saat ini

### **Jalankan Kontainer**

Jalankan perintah berikut di direktori tempat Dockerfile Anda berada untuk menjalankan kontainer Docker:
```powershell
   docker run -v "$(pwd)/output:/output" aspose-test
   ```

- `-v` memasang direktori output
- Membuat `output.pdf` di folder `output` lokal Anda