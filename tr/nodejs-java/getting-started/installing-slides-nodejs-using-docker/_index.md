---
title: Node.js için Aspose.Slides'ı Java Kullanarak Docker ile Kurun
type: docs
weight: 75
url: /tr/nodejs-java/installing-slides-nodejs-using-docker/
keywords:
- Aspose.Slides indirme
- Aspose.Slides kurma
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides'ı Docker konteynerlerinde çalıştırın: görüntüleri, bağımlılıkları, yazı tiplerini ve lisanslamayı yapılandırarak PowerPoint ve OpenDocument işleyen ölçeklenebilir hizmetler oluşturun."
---
## Önkoşullar:
* Makinenize Docker kurun. Resmi kurulum kılavuzunu [burada](https://docs.docker.com/get-docker/) takip edebilirsiniz.

## Adımlar:

### 1. **Dockerfile Oluştur** 
   Proje dizininizde Dockerfile adlı yeni bir dosya oluşturun ve aşağıdaki içeriği ekleyin:
   ```
   # Ubuntu 20.04'ü temel görüntü olarak kullan
   FROM ubuntu:20.04

   # Paket listesini güncelle ve depolar eklemek ile dosya indirmek için gerekli paketleri kur
   RUN apt-get update && \
      apt-get install -y curl gnupg2 software-properties-common && \
      rm -rf /var/lib/apt/lists/*

   # Nodesource deposundan Node.js 18.x sürümünü kur
   RUN curl -fsSL https://deb.nodesource.com/setup_22.x | bash - && \
      apt-get install -y nodejs && \
      rm -rf /var/lib/apt/lists/*

   # node-gyp gibi bazı npm paketlerinin gerektirdiği Python 2.x'i kur
   RUN apt-get update && \
      apt-get install -y python2 && \
      rm -rf /var/lib/apt/lists/*

   # Aspose.Slides'ın Java bağımlılıkları için gerekli olan OpenJDK 11'i kur
   RUN apt-get update && \
      apt-get install -y openjdk-11-jdk && \
      rm -rf /var/lib/apt/lists/*

   # Yerel modülleri oluşturmak için gerekli 'make' gibi araçları içeren build-essential paketini kur
   RUN apt-get update && \
      apt-get install -y build-essential && \
      rm -rf /var/lib/apt/lists/*

   # node-gyp'ı global olarak kur, bu araç Node.js için yerel eklentileri derlemek için kullanılır
   RUN npm install -g node-gyp

   # Çalışma dizinini konteyner içinde /app olarak ayarla
   WORKDIR /app

   # Gerekli detaylar ve bağımlılıklarla package.json dosyasını oluştur
   RUN echo '{\n\
     "name": "aspose-slides-app",\n\
     "version": "1.0.0",\n\
     "main": "index.js",\n\
     "scripts": {\n\
      "start": "node index.js"\n\
     },\n\
     "dependencies": {\n\
      "aspose.slides.via.java": "^25.12.0"\n\
     }\n\
   }' > package.json

   # Aspose.Slides kullanarak bir sunum oluşturmak için örnek kod içeren index.js dosyasını oluştur
   RUN echo 'const slides = require("aspose.slides.via.java");\n\
   var presentation = new slides.Presentation();\n\
   var slide = presentation.getSlides().get_Item(0);\n\
   slide.getShapes().addAutoShape(slides.ShapeType.Line, 50, 150, 300, 0);\n\
   presentation.save("./NewPresentation.pptx", slides.SaveFormat.Pptx);\n\
   console.log("Script completed, please check file /app/NewPresentation.pptx!");' > index.js

   # package.json'da belirtilen Aspose.Slides via Java paketini kur
   RUN npm install aspose.slides.via.java

   # Konteyner start edildiğinde uygulamayı çalıştırmak için varsayılan komutu ayarla
   CMD ["node", "index.js"]
   ```


### 2. **Docker Görüntüsü Oluştur**
   Dockerfile'inizin bulunduğu dizinde aşağıdaki komutu çalıştırarak Docker görüntüsünü oluşturun:
   ```bash
   docker build -t aspose-slides-nodejs .
   ```

### 3. **Docker Container'ı Çalıştır**
   Konteyneri çalıştırın ve kimliğini kaydedin:
   ```bash
   CONTAINER_ID=$(docker create aspose-slides-nodejs)
   docker start -a $CONTAINER_ID
   ```

### 4. **Docker'da Aspose.Slides'a Erişin** 
   Konteyneri başlattıktan sonra script bir PPTX dosyası oluşturacaktır. Oluşturulan çıktı dosyasını `NewPresentation.pptx` konteyner içindeki `/app` klasöründe bulabilirsiniz:
   ```bash
   docker cp $CONTAINER_ID:/app/NewPresentation.pptx ./NewPresentation.pptx
   ```
   Geçici konteyneri kaldırın:
   ```bash
   docker rm $CONTAINER_ID
   ```