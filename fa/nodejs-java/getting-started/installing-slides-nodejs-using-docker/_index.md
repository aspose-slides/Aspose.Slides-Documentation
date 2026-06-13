---
title: نصب Aspose.Slides برای Node.js از طریق Java با استفاده از Docker
type: docs
weight: 75
url: /fa/nodejs-java/installing-slides-nodejs-using-docker/
keywords:
- دانلود Aspose.Slides
- نصب Aspose.Slides
- نصب Aspose.Slides
- Docker
- Windows
- macOS
- Linux
- سازگاری چند پلتفرمی
- ایزولاسیون وابستگی‌ها
- استقرار ساده‌شده
- راه‌اندازی پروژه
- PowerPoint
- OpenDocument
- ارائه
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides را در کانتینرهای Docker اجرا کنید: تنظیم تصاویر، وابستگی‌ها، قلم‌ها و لایسنس برای ساخت سرویس‌های مقیاس‌پذیر که پردازش PowerPoint و OpenDocument را انجام می‌دهند."
---
## پیش‌نیازها:
* Docker را روی دستگاه خود نصب کنید. می‌توانید راهنمای نصب رسمی را [اینجا](https://docs.docker.com/get-docker/) دنبال کنید.

## مراحل:

### 1. **ایجاد Dockerfile** 
   یک فایل جدید به نام Dockerfile در پوشه پروژه خود ایجاد کنید و محتویات زیر را اضافه کنید:
   ```
   # استفاده از Ubuntu 20.04 به عنوان تصویر پایه
   FROM ubuntu:20.04

   # به‌روزرسانی فهرست بسته‌ها و نصب بسته‌های ضروری برای افزودن مخازن و دانلود فایل‌ها
   RUN apt-get update && \
      apt-get install -y curl gnupg2 software-properties-common && \
      rm -rf /var/lib/apt/lists/*

   # نصب Node.js نسخه 18.x از مخزن Nodesource
   RUN curl -fsSL https://deb.nodesource.com/setup_22.x | bash - && \
      apt-get install -y nodejs && \
      rm -rf /var/lib/apt/lists/*

   # نصب Python 2.x که برای برخی بسته‌های npm مانند node-gyp لازم است
   RUN apt-get update && \
      apt-get install -y python2 && \
      rm -rf /var/lib/apt/lists/*

   # نصب OpenJDK 11 که برای وابستگی‌های Java Aspose.Slides مورد نیاز است
   RUN apt-get update && \
      apt-get install -y openjdk-11-jdk && \
      rm -rf /var/lib/apt/lists/*

   # نصب بسته build-essential که شامل ابزارهایی مانند 'make' برای ساخت ماژول‌های بومی لازم است
   RUN apt-get update && \
      apt-get install -y build-essential && \
      rm -rf /var/lib/apt/lists/*

   # نصب node-gyp به‌صورت سراسری، ابزاری برای کامپایل افزونه‌های بومی برای Node.js
   RUN npm install -g node-gyp

   # تنظیم پوشه کاری داخل کانتینر به /app
   WORKDIR /app

   # ایجاد فایل package.json با جزئیات و وابستگی‌های لازم
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

   # ایجاد فایل index.js با کد نمونه برای ساخت ارائه با استفاده از Aspose.Slides
   RUN echo 'const slides = require("aspose.slides.via.java");\n\
   var presentation = new slides.Presentation();\n\
   var slide = presentation.getSlides().get_Item(0);\n\
   slide.getShapes().addAutoShape(slides.ShapeType.Line, 50, 150, 300, 0);\n\
   presentation.save("./NewPresentation.pptx", slides.SaveFormat.Pptx);\n\
   console.log("Script completed, please check file /app/NewPresentation.pptx!");' > index.js

   # نصب بسته Aspose.Slides via Java که در package.json مشخص شده است
   RUN npm install aspose.slides.via.java

   # تنظیم دستور پیش‌فرض برای اجرای برنامه هنگام شروع کانتینر
   CMD ["node", "index.js"]
   ```

### 2. **ساخت Docker Image**
   دستور زیر را در پوشه‌ای که Dockerfile در آن قرار دارد اجرا کنید تا Docker Image ساخته شود:
   ```bash
   docker build -t aspose-slides-nodejs .
   ```

### 3. **اجرا کردن Docker Container**
   Container را اجرا کنید و شناسه آن را ذخیره کنید:
   ```bash
   CONTAINER_ID=$(docker create aspose-slides-nodejs)
   docker start -a $CONTAINER_ID
   ```

### 4. **دسترسی به Aspose.Slides در Docker** 
   پس از شروع Container، اسکریپت یک فایل PPTX تولید می‌کند. می‌توانید فایل خروجی تولید شده `NewPresentation.pptx` را در پوشه `/app` داخل Container پیدا کنید:
   ```bash
   docker cp $CONTAINER_ID:/app/NewPresentation.pptx ./NewPresentation.pptx
   ```
   Container موقت را حذف کنید:
   ```bash
   docker rm $CONTAINER_ID
   ```