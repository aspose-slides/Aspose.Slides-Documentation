---
title: Docker'da Aspose.Slides for Java Nasıl Çalıştırılır
type: docs
weight: 75
url: /tr/java/how-to-run-aspose-slides-in-docker/
keywords:
- Aspose.Slides'ı indir
- Aspose.Slides'ı kur
- Aspose.Slides kurulumu
- Docker
- Windows
- macOS
- Linux
- çapraz platform uyumluluğu
- bağımlılık izolasyonu
- basitleştirilmiş dağıtım
- proje kurulumu
- PowerPoint
- OpenDocument
- sunum
- Java
- Aspose.Slides
description: "Docker konteynerlerinde Aspose.Slides'ı çalıştırın: görüntüleri, bağımlılıkları, yazı tiplerini ve lisanslamayı yapılandırarak PowerPoint ve OpenDocument işleyen ölçeklenebilir hizmetler oluşturun."
---
## **Giriş**

Bu kılavuz, Aspose Slides kullanarak bir Java uygulamasını Docker ile konteynerleştirmenin yolunu açıklar. Ana faydalar şunlardır:

- **Çapraz platform uyumluluğu** - Windows, macOS ve Linux'ta çalışır
- **Bağımlılık izolasyonu** - Sistem genelinde kurulum gerektirmez
- **Basitleştirilmiş dağıtım** - Kolay paylaşım ve yürütme

## **1. Docker Kurulumu**

### **Windows**

**Gereksinimler:**

- Windows 10/11 Pro/Enterprise/Education (64-bit) WSL 2 etkinleştirilmiş
- Home sürümü için: Manuel WSL 2 kurulumu gerekir

**Adımlar:**

1. [Docker Desktop for Windows](https://www.docker.com/products/docker-desktop/) indirin
2. Yükleyiciyi çalıştırın ve kurulum sihirbazını izleyin
3. İstendiğinde bilgisayarınızı yeniden başlatın
4. Kurulumu doğrulayın:
   ```powershell
   docker --version
   ```

### **macOS**

**Gereksinimler:**

- macOS 10.15 (Catalina) veya daha yeni
- Apple Silicon veya Intel işlemci

**Adımlar:**

1. [Docker Desktop for Mac](https://www.docker.com/products/docker-desktop/) indirin
2. Uygulamayı `Applications` klasörünüze sürükleyin
3. Docker'ı başlatın ve başlatılmasını bekleyin
4. Kurulumu doğrulayın:
   ```bash
   docker --version
   ```

### **Linux (Ubuntu/Debian)**

**Kurulum:**

```bash
# Paket listelerini güncelle
sudo apt update && sudo apt upgrade -y

# Gereksinimleri kur
sudo apt install -y \
    apt-transport-https \
    ca-certificates \
    curl \
    software-properties-common

# Docker'ın resmi GPG anahtarını ekle
curl -fsSL https://download.docker.com/linux/ubuntu/gpg | sudo gpg --dearmor -o /usr/share/keyrings/docker-archive-keyring.gpg

# Kararlı bir depoyu ekle
echo "deb [arch=amd64 signed-by=/usr/share/keyrings/docker-archive-keyring.gpg] https://download.docker.com/linux/ubuntu $(lsb_release -cs) stable" | sudo tee /etc/apt/sources.list.d/docker.list > /dev/null

# Docker Engine'i kur
sudo apt update
sudo apt install -y docker-ce docker-ce-cli containerd.io

# Mevcut kullanıcının Docker komutlarını çalıştırmasına izin ver
sudo usermod -aG docker $USER
newgrp docker

# Kurulumu doğrula
docker --version
```

## **2. Dockerfile Yapılandırması**

### **Temel Görüntü**

```dockerfile
FROM ubuntu:24.04
```
> **Not**: Docker Hub'dan resmi Ubuntu görüntüsünü kullanır.

### **Bağımlılıklar**

```dockerfile
RUN apt-get install -y openjdk-11-jdk wget fontconfig ttf-mscorefonts-installer
```
- **OpenJDK 11**: Java çalışma zamanı ortamı
- **Font paketleri**: Microsoft Core Fonts içerir

### **Aspose.Slides Kurulumu**

```dockerfile
ENV ASPOSE_VERSION=25.3

ENV ASPOSE_JAR=aspose-slides-${ASPOSE_VERSION}-jdk16.jar
ENV ASPOSE_URL=https://releases.aspose.com/java/repo/com/aspose/aspose-slides/${ASPOSE_VERSION}/${ASPOSE_JAR}
```
- Aspose Slides kütüphanesinin sürüm kilitli indirmesi

## **3. Proje Kurulumu**

### **Dosya Yapısı**

```
aspose-docker/
├── Dockerfile          # Konteyner yapılandırması
├── TestAspose.java     # Uygulama kodu
└── output/             # Oluşturulan PDF'lerin bulunduğu klasör (otomatik oluşturulur)
```

### **Dockerfile**

‘Dockerfile’ adlı bir dosya oluşturun:
```dockerfile
FROM ubuntu:24.04

# Ortam değişkenlerini ayarla
ENV JAVA_HOME=/usr/lib/jvm/java-11-openjdk-amd64
ENV PATH=$JAVA_HOME/bin:$PATH
ENV APP_DIR=/tmp
ENV ASPOSE_VERSION=25.3
ENV ASPOSE_JAR=aspose-slides-${ASPOSE_VERSION}-jdk16.jar
ENV ASPOSE_URL=https://releases.aspose.com/java/repo/com/aspose/aspose-slides/${ASPOSE_VERSION}/${ASPOSE_JAR}

# Çalışma dizini oluştur
RUN mkdir -p ${APP_DIR}
WORKDIR ${APP_DIR}

# Bağımlılıkları kur
RUN apt-get update && \
    apt-get install -y --no-install-recommends \
    openjdk-11-jdk \
    wget \
    fontconfig \
    ttf-mscorefonts-installer && \
    rm -rf /var/lib/apt/lists/*

# Yazı tiplerini yapılandır
RUN echo "ttf-mscorefonts-installer msttcorefonts/accepted-mscorefonts-eula select true" | debconf-set-selections && \
    apt-get update && \
    apt-get install -y --no-install-recommends ttf-mscorefonts-installer && \
    fc-cache -f -v

# Aspose.Slides'ı /tmp dizinine indir
RUN wget ${ASPOSE_URL} -O ${APP_DIR}/${ASPOSE_JAR}

# Kaynak kodunu kopyala
COPY TestAspose.java ${APP_DIR}/

# Çalıştırma betiğini oluştur
RUN echo '#!/bin/bash' > ${APP_DIR}/run.sh && \
    echo 'java --add-opens=java.desktop/sun.java2d=ALL-UNNAMED \' >> ${APP_DIR}/run.sh && \
    echo '     --add-opens=java.desktop/sun.awt.image=ALL-UNNAMED \' >> ${APP_DIR}/run.sh && \
    echo '     --add-opens=java.desktop/sun.font=ALL-UNNAMED \' >> ${APP_DIR}/run.sh && \
    echo '     -cp ".:'"${ASPOSE_JAR}"'" TestAspose' >> ${APP_DIR}/run.sh && \
    chmod +x ${APP_DIR}/run.sh

# Betiğe yürütme izni ver
RUN chmod 755 ${APP_DIR}/run.sh

# Java kodunu derle
RUN javac -cp "${APP_DIR}/${ASPOSE_JAR}" ${APP_DIR}/TestAspose.java

# Çalışma dizinini ayarla
WORKDIR /tmp

CMD ["sh", "-c", "/tmp/run.sh && cp /tmp/output/output.pdf /output"]
```

### **Java Uygulaması**

`TestAspose.java` dosyasını şu içerikle oluşturun:
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

## **4. Oluşturma ve Çalıştırma**

### **Görüntüyü Oluşturma**

‘Dockerfile’inizin bulunduğu dizinde aşağıdaki komutu çalıştırarak Docker görüntüsünü oluşturun:
```powershell
   docker build -t aspose-test .
   ```

- `-t` görüntüyü "aspose-test" olarak adlandırır
- `.` mevcut dizinin Dockerfile'ını kullanır

### **Konteyneri Çalıştırma**

‘Dockerfile’inizin bulunduğu dizinde aşağıdaki komutu çalıştırarak Docker konteynerini başlatın:
```powershell
   docker run -v "$(pwd)/output:/output" aspose-test
   ```

- `-v` çıktı dizinini bağlar
- Yerel `output` klasörünüzde `output.pdf` oluşturur