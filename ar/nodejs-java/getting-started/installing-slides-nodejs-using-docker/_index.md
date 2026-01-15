---
title: تثبيت Aspose.Slides لـ Node.js عبر Java باستخدام Docker
type: docs
weight: 75
url: /ar/nodejs-java/installing-slides-nodejs-using-docker/
keywords:
- تنزيل Aspose.Slides
- تثبيت Aspose.Slides
- تثبيت Aspose.Slides
- Docker
- Windows
- macOS
- Linux
- التوافق عبر المنصات
- عزل الاعتمادات
- نشر مبسط
- إعداد المشروع
- PowerPoint
- OpenDocument
- عرض تقديمي
- Node.js
- JavaScript
- Aspose.Slides
description: "تشغيل Aspose.Slides في حاويات Docker: تكوين الصور، والاعتمادات، والخطوط، والترخيص لبناء خدمات قابلة للتوسع تعالج PowerPoint و OpenDocument."
---

## المتطلبات المسبقة:
* ثبت Docker على جهازك. يمكنك اتباع دليل التثبيت الرسمي [هنا](https://docs.docker.com/get-docker/).

## الخطوات:

### 1. **Create Dockerfile** 
   إنشاء ملف جديد باسم Dockerfile في دليل مشروعك بالمحتوى التالي:
   ```
   # استخدم Ubuntu 20.04 كصورة الأساس
   FROM ubuntu:20.04

   # تحديث قائمة الحزم وتثبيت الحزم الأساسية لإضافة المستودعات وتنزيل الملفات
   RUN apt-get update && \
      apt-get install -y curl gnupg2 software-properties-common && \
      rm -rf /var/lib/apt/lists/*

   # تثبيت Node.js الإصدار 18.x من مستودع Nodesource
   RUN curl -fsSL https://deb.nodesource.com/setup_22.x | bash - && \
      apt-get install -y nodejs && \
      rm -rf /var/lib/apt/lists/*

   # تثبيت Python 2.x، وهو مطلوب من بعض حزم npm مثل node-gyp
   RUN apt-get update && \
      apt-get install -y python2 && \
      rm -rf /var/lib/apt/lists/*

   # تثبيت OpenJDK 11، وهو مطلوب من Aspose.Slides لاعتماديات Java
   RUN apt-get update && \
      apt-get install -y openjdk-11-jdk && \
      rm -rf /var/lib/apt/lists/*

   # تثبيت حزمة build-essential، التي تشمل أدوات مثل 'make' المطلوبة لبناء الوحدات الأصلية
   RUN apt-get update && \
      apt-get install -y build-essential && \
      rm -rf /var/lib/apt/lists/*

   # تثبيت node-gyp عالمياً، أداة تُستخدم لتجميع الإضافات الأصلية لـ Node.js
   RUN npm install -g node-gyp

   # تعيين دليل العمل داخل الحاوية إلى /app
   WORKDIR /app

   # إنشاء ملف package.json بالتفاصيل والاعتماديات اللازمة
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

   # إنشاء ملف index.js مع كود مثال لإنشاء عرض تقديمي باستخدام Aspose.Slides
   RUN echo 'const slides = require("aspose.slides.via.java");\n\
   var presentation = new slides.Presentation();\n\
   var slide = presentation.getSlides().get_Item(0);\n\
   slide.getShapes().addAutoShape(slides.ShapeType.Line, 50, 150, 300, 0);\n\
   presentation.save("./NewPresentation.pptx", slides.SaveFormat.Pptx);\n\
   console.log("Script completed, please check file /app/NewPresentation.pptx!");' > index.js

   # تثبيت حزمة Aspose.Slides عبر Java المحددة في package.json
   RUN npm install aspose.slides.via.java

   # تعيين الأمر الافتراضي لتشغيل التطبيق عند بدء الحاوية
   CMD ["node", "index.js"]
   ```


### 2. **Build Docker Image**
   قم بتشغيل الأمر التالي في الدليل الذي يوجد فيه Dockerfile لبناء صورة Docker:
```bash
docker build -t aspose-slides-nodejs .
```


### 3. **Run Docker Container**
   شغّل الحاوية واحفظ معرفها:
```bash
CONTAINER_ID=$(docker create aspose-slides-nodejs)
docker start -a $CONTAINER_ID
```


### 4. **Access Aspose.Slides in Docker** 
   بعد بدء الحاوية، سيولد البرنامج النصي ملف PPTX. يمكنك العثور على ملف الإخراج المُولد `NewPresentation.pptx` في مجلد `/app` داخل الحاوية:
   ```bash
   docker cp $CONTAINER_ID:/app/NewPresentation.pptx ./NewPresentation.pptx
   ```

   إزالة الحاوية المؤقتة:
   ```bash
   docker rm $CONTAINER_ID
   ```
