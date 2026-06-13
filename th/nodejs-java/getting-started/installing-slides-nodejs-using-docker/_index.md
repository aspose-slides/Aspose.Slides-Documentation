---
title: ติดตั้ง Aspose.Slides สำหรับ Node.js ผ่าน Java โดยใช้ Docker
type: docs
weight: 75
url: /th/nodejs-java/installing-slides-nodejs-using-docker/
keywords:
- ดาวน์โหลด Aspose.Slides
- ติดตั้ง Aspose.Slides
- การติดตั้ง Aspose.Slides
- Docker
- Windows
- macOS
- Linux
- ความเข้ากันได้ข้ามแพลตฟอร์ม
- การแยกการพึ่งพา
- การปรับใช้ที่ง่ายขึ้น
- การตั้งค่าโครงการ
- PowerPoint
- OpenDocument
- งานนำเสนอ
- Node.js
- JavaScript
- Aspose.Slides
description: "รัน Aspose.Slides ในคอนเทนเนอร์ Docker: กำหนดค่าภาพ, การพึ่งพา, ฟอนต์, และลิขสิทธิ์เพื่อสร้างบริการที่สามารถขยายได้ซึ่งประมวลผล PowerPoint & OpenDocument."
---
## ข้อกำหนดเบื้องต้น:
* ติดตั้ง Docker บนเครื่องของคุณ คุณสามารถปฏิบัติตามคู่มือการติดตั้งอย่างเป็นทางการ[ที่นี่](https://docs.docker.com/get-docker/).

## Steps:

### 1. **สร้าง Dockerfile** 
สร้างไฟล์ใหม่ชื่อ Dockerfile ในไดเรกทอรีโครงการของคุณด้วยเนื้อหาต่อไปนี้:
```
   # ใช้ Ubuntu 20.04 เป็นอิมเมจฐาน
   FROM ubuntu:20.04

   # อัปเดตรายการแพ็กเกจและติดตั้งแพ็กเกจที่จำเป็นสำหรับการเพิ่มรีโพซิทอรีและดาวน์โหลดไฟล์
   RUN apt-get update && \
      apt-get install -y curl gnupg2 software-properties-common && \
      rm -rf /var/lib/apt/lists/*

   # ติดตั้ง Node.js เวอร์ชัน 18.x จากรีโพซิทอรี Nodesource
   RUN curl -fsSL https://deb.nodesource.com/setup_22.x | bash - && \
      apt-get install -y nodejs && \
      rm -rf /var/lib/apt/lists/*

   # ติดตั้ง Python 2.x ซึ่งจำเป็นสำหรับ npm แพ็คเกจบางตัวเช่น node-gyp
   RUN apt-get update && \
      apt-get install -y python2 && \
      rm -rf /var/lib/apt/lists/*

   # ติดตั้ง OpenJDK 11 ซึ่งจำเป็นสำหรับ Aspose.Slides สำหรับการพึ่งพา Java
   RUN apt-get update && \
      apt-get install -y openjdk-11-jdk && \
      rm -rf /var/lib/apt/lists/*

   # ติดตั้งแพ็กเกจ build-essential ซึ่งรวมเครื่องมือต่าง ๆ เช่น 'make' ที่จำเป็นสำหรับการสร้างโมดูลเนทีพ
   RUN apt-get update && \
      apt-get install -y build-essential && \
      rm -rf /var/lib/apt/lists/*

   # ติดตั้ง node-gyp อย่างทั่วโลก, เครื่องมือที่ใช้คอมไพล์ native add-ons สำหรับ Node.js
   RUN npm install -g node-gyp

   # ตั้งค่าไดเรกทอรีทำงานภายในคอนเทนเนอร์เป็น /app
   WORKDIR /app

   # สร้างไฟล์ package.json พร้อมรายละเอียดและการพึ่งพาที่จำเป็น
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

   # สร้างไฟล์ index.js พร้อมตัวอย่างโค้ดเพื่อสร้างงานนำเสนอด้วย Aspose.Slides
   RUN echo 'const slides = require("aspose.slides.via.java");\n\
   var presentation = new slides.Presentation();\n\
   var slide = presentation.getSlides().get_Item(0);\n\
   slide.getShapes().addAutoShape(slides.ShapeType.Line, 50, 150, 300, 0);\n\
   presentation.save("./NewPresentation.pptx", slides.SaveFormat.Pptx);\n\
   console.log("Script completed, please check file /app/NewPresentation.pptx!");' > index.js

   # ติดตั้งแพ็คเกจ Aspose.Slides via Java ตามที่ระบุใน package.json
   RUN npm install aspose.slides.via.java

   # ตั้งคำสั่งเริ่มต้นเพื่อรันแอปพลิเคชันเมื่อคอนเทนเนอร์เริ่มทำงาน
   CMD ["node", "index.js"]
   ```

### 2. **สร้าง Docker Image**
เรียกใช้คำสั่งต่อไปนี้ในไดเรกทอรีที่ไฟล์ Dockerfile ของคุณอยู่เพื่อสร้าง Docker Image:
```bash
   docker build -t aspose-slides-nodejs .
   ```

### 3. **รัน Docker Container**
รันคอนเทนเนอร์และบันทึก ID ของมัน:
```bash
   CONTAINER_ID=$(docker create aspose-slides-nodejs)
   docker start -a $CONTAINER_ID
   ```

### 4. **เข้าถึง Aspose.Slides ใน Docker** 
หลังจากเริ่มคอนเทนเนอร์ สคริปต์จะสร้างไฟล์ PPTX คุณสามารถพบไฟล์ผลลัพธ์ที่สร้างขึ้น `NewPresentation.pptx` ในโฟลเดอร์ `/app` ภายในคอนเทนเนอร์:
```bash
   docker cp $CONTAINER_ID:/app/NewPresentation.pptx ./NewPresentation.pptx
   ```
ลบคอนเทนเนอร์ชั่วคราว:
```bash
   docker rm $CONTAINER_ID
   ```