---
title: Instal Aspose.Slides untuk Node.js via Java Menggunakan Docker
type: docs
weight: 75
url: /id/nodejs-java/installing-slides-nodejs-using-docker/
keywords:
- unduh Aspose.Slides
- instal Aspose.Slides
- instalasi Aspose.Slides
- Docker
- Windows
- macOS
- Linux
- kompatibilitas lintas platform
- isolasi dependensi
- penyebaran sederhana
- penyiapan proyek
- PowerPoint
- OpenDocument
- presentasi
- Node.js
- JavaScript
- Aspose.Slides
description: "Jalankan Aspose.Slides dalam kontainer Docker: konfigurasikan gambar, dependensi, font, dan lisensi untuk membangun layanan skalabel yang memproses PowerPoint & OpenDocument."
---
## Prasyarat:
* Instal Docker di mesin Anda. Anda dapat mengikuti panduan instalasi resmi [di sini](https://docs.docker.com/get-docker/).

## Langkah-langkah:

### 1. **Buat Dockerfile** 
   Buat file baru bernama Dockerfile di direktori proyek Anda dengan konten berikut:
   ``` 
   # Gunakan Ubuntu 20.04 sebagai image dasar
   FROM ubuntu:20.04

   # Perbarui daftar paket dan instal paket penting untuk menambahkan repositori dan mengunduh file
   RUN apt-get update && \
      apt-get install -y curl gnupg2 software-properties-common && \
      rm -rf /var/lib/apt/lists/*

   # Instal Node.js versi 18.x dari repositori Nodesource
   RUN curl -fsSL https://deb.nodesource.com/setup_22.x | bash - && \
      apt-get install -y nodejs && \
      rm -rf /var/lib/apt/lists/*

   # Instal Python 2.x, yang diperlukan oleh beberapa paket npm seperti node-gyp
   RUN apt-get update && \
      apt-get install -y python2 && \
      rm -rf /var/lib/apt/lists/*

   # Instal OpenJDK 11, yang diperlukan oleh Aspose.Slides untuk dependensi Java
   RUN apt-get update && \
      apt-get install -y openjdk-11-jdk && \
      rm -rf /var/lib/apt/lists/*

   # Instal paket build-essential, yang mencakup alat seperti 'make' yang diperlukan untuk membangun modul native
   RUN apt-get update && \
      apt-get install -y build-essential && \
      rm -rf /var/lib/apt/lists/*

   # Instal node-gyp secara global, alat yang digunakan untuk mengompilasi add-on native untuk Node.js
   RUN npm install -g node-gyp

   # Atur direktori kerja di dalam kontainer ke /app
   WORKDIR /app

   # Buat file package.json dengan detail dan dependensi yang diperlukan
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

   # Buat file index.js dengan contoh kode untuk membuat presentasi menggunakan Aspose.Slides
   RUN echo 'const slides = require("aspose.slides.via.java");\n\
   var presentation = new slides.Presentation();\n\
   var slide = presentation.getSlides().get_Item(0);\n\
   slide.getShapes().addAutoShape(slides.ShapeType.Line, 50, 150, 300, 0);\n\
   presentation.save("./NewPresentation.pptx", slides.SaveFormat.Pptx);\n\
   console.log("Script completed, please check file /app/NewPresentation.pptx!");' > index.js

   # Instal paket Aspose.Slides via Java yang ditentukan dalam package.json
   RUN npm install aspose.slides.via.java

   # Atur perintah default untuk menjalankan aplikasi saat kontainer dimulai
   CMD ["node", "index.js"]
   ```

### 2. **Bangun Image Docker**
   Jalankan perintah berikut di direktori tempat Dockerfile Anda berada untuk membangun image Docker:
   ```bash
   docker build -t aspose-slides-nodejs .
   ```

### 3. **Jalankan Kontainer Docker**
   Jalankan kontainer dan simpan ID-nya:
   ```bash
   CONTAINER_ID=$(docker create aspose-slides-nodejs)
   docker start -a $CONTAINER_ID
   ```

### 4. **Akses Aspose.Slides di Docker** 
   Setelah memulai kontainer, skrip akan menghasilkan file PPTX. Anda dapat menemukan file output yang dihasilkan `NewPresentation.pptx` di folder `/app` di dalam kontainer:
   ```bash
   docker cp $CONTAINER_ID:/app/NewPresentation.pptx ./NewPresentation.pptx
   ```
   Hapus kontainer sementara:
   ```bash
   docker rm $CONTAINER_ID
   ```