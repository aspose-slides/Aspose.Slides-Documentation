---
title: كيفية تشغيل Aspose.Slides لجافا في Docker
type: docs
weight: 75
url: /ar/java/how-to-run-aspose-slides-in-docker/
keywords:
- تنزيل Aspose.Slides
- تثبيت Aspose.Slides
- تثبيت Aspose.Slides
- Docker
- Windows
- macOS
- Linux
- التوافق عبر الأنظمة
- عزل الاعتمادات
- نشر مبسط
- إعداد المشروع
- PowerPoint
- OpenDocument
- عرض تقديمي
- Java
- Aspose.Slides
description: "تشغيل Aspose.Slides في حاويات Docker: تكوين الصور، الاعتمادات، الخطوط، والترخيص لبناء خدمات قابلة للتوسع تعالج ملفات PowerPoint وOpenDocument."
---

## **المقدمة**

يوضح هذا الدليل كيفية حاوية تطبيق جافا باستخدام Aspose Slides مع Docker. تشمل الفوائد الرئيسية:

- **التوافق عبر الأنظمة** - يعمل على Windows و macOS و Linux
- **عزل الاعتمادات** - لا يتطلب تثبيتات على مستوى النظام
- **نشر مبسط** - مشاركة وتنفيذ سهل

## **1. تثبيت Docker**

### **Windows**

**المتطلبات:**

- Windows 10/11 Pro/Enterprise/Education (64‑bit) مع تمكين WSL 2
- لإصدار Home: يتطلب تثبيت يدوي لـ WSL 2

**الخطوات:**

1. تنزيل [Docker Desktop for Windows](https://www.docker.com/products/docker-desktop/)
2. تشغيل المثبت واتباع معالج الإعداد
3. إعادة تشغيل الكمبيوتر عند المطالبة
4. التحقق من التثبيت:
   ```powershell
   docker --version
   ```


### **macOS**

**المتطلبات:**

- macOS 10.15 (Catalina) أو أحدث
- معالج Apple Silicon أو Intel

**الخطوات:**

1. تنزيل [Docker Desktop for Mac](https://www.docker.com/products/docker-desktop/)
2. اسحب التطبيق إلى مجلد `Applications` الخاص بك
3. تشغيل Docker وانتظار التهيئة
4. التحقق من التثبيت:
   ```bash
   docker --version
   ```


### **Linux (Ubuntu/Debian)**

**التثبيت:**
```bash
# تحديث قوائم الحزم
sudo apt update && sudo apt upgrade -y

# تثبيت المتطلبات المسبقة
sudo apt install -y \
    apt-transport-https \
    ca-certificates \
    curl \
    software-properties-common

# إضافة مفتاح GPG الرسمي لـ Docker
curl -fsSL https://download.docker.com/linux/ubuntu/gpg | sudo gpg --dearmor -o /usr/share/keyrings/docker-archive-keyring.gpg

# إضافة مستودع ثابت
echo "deb [arch=amd64 signed-by=/usr/share/keyrings/docker-archive-keyring.gpg] https://download.docker.com/linux/ubuntu $(lsb_release -cs) stable" | sudo tee /etc/apt/sources.list.d/docker.list > /dev/null

# تثبيت محرك Docker
sudo apt update
sudo apt install -y docker-ce docker-ce-cli containerd.io

# السماح للمستخدم الحالي بتنفيذ أوامر Docker
sudo usermod -aG docker $USER
newgrp docker

# التحقق من التثبيت
docker --version
```


## **2. تكوين Dockerfile**

### **الصورة الأساسية**
```dockerfile
FROM ubuntu:24.04
```

> **ملاحظة**: يستخدم [الصورة الرسمية Ubuntu](https://hub.docker.com/_/ubuntu) من Docker Hub.

### **التبعيات**
```dockerfile
RUN apt-get install -y openjdk-11-jdk wget fontconfig ttf-mscorefonts-installer
```

- **OpenJDK 11**: بيئة تشغيل جافا
- **حزم الخطوط**: تشمل Microsoft Core Fonts

### **إعداد Aspose.Slides**
```dockerfile
ENV ASPOSE_VERSION=25.3

ENV ASPOSE_JAR=aspose-slides-${ASPOSE_VERSION}-jdk16.jar
ENV ASPOSE_URL=https://releases.aspose.com/java/repo/com/aspose/aspose-slides/${ASPOSE_VERSION}/${ASPOSE_JAR}
```

- تنزيل مكتبة Aspose Slides مقفل بالإصدار

## **3. إعداد المشروع**

### **هيكل الملفات**
```
aspose-docker/
├── Dockerfile          # تهيئة الحاوية
├── TestAspose.java     # كود التطبيق
└── output/             # مجلد يحتوي على ملفات PDF المولدة (تم إنشاؤه تلقائيًا)
```


### **Dockerfile**

إنشاء ملف باسم `Dockerfile` يحتوي على:
```dockerfile
FROM ubuntu:24.04

# تعيين متغيرات البيئة
ENV JAVA_HOME=/usr/lib/jvm/java-11-openjdk-amd64
ENV PATH=$JAVA_HOME/bin:$PATH
ENV APP_DIR=/tmp
ENV ASPOSE_VERSION=25.3
ENV ASPOSE_JAR=aspose-slides-${ASPOSE_VERSION}-jdk16.jar
ENV ASPOSE_URL=https://releases.aspose.com/java/repo/com/aspose/aspose-slides/${ASPOSE_VERSION}/${ASPOSE_JAR}

# إنشاء دليل عمل
RUN mkdir -p ${APP_DIR}
WORKDIR ${APP_DIR}

# تثبيت الاعتمادات
RUN apt-get update && \
    apt-get install -y --no-install-recommends \
    openjdk-11-jdk \
    wget \
    fontconfig \
    ttf-mscorefonts-installer && \
    rm -rf /var/lib/apt/lists/*

# تكوين الخطوط
RUN echo "ttf-mscorefonts-installer msttcorefonts/accepted-mscorefonts-eula select true" | debconf-set-selections && \
    apt-get update && \
    apt-get install -y --no-install-recommends ttf-mscorefonts-installer && \
    fc-cache -f -v

# تنزيل Aspose.Slides إلى /tmp
RUN wget ${ASPOSE_URL} -O ${APP_DIR}/${ASPOSE_JAR}

# نسخ شفرة المصدر
COPY TestAspose.java ${APP_DIR}/

# إنشاء سكريبت التشغيل
RUN echo '#!/bin/bash' > ${APP_DIR}/run.sh && \
    echo 'java --add-opens=java.desktop/sun.java2d=ALL-UNNAMED \' >> ${APP_DIR}/run.sh && \
    echo '     --add-opens=java.desktop/sun.awt.image=ALL-UNNAMED \' >> ${APP_DIR}/run.sh && \
    echo '     --add-opens=java.desktop/sun.font=ALL-UNNAMED \' >> ${APP_DIR}/run.sh && \
    echo '     -cp ".:'"${ASPOSE_JAR}"'" TestAspose' >> ${APP_DIR}/run.sh && \
    chmod +x ${APP_DIR}/run.sh

# منح أذونات التنفيذ للسكريبت صراحةً
RUN chmod 755 ${APP_DIR}/run.sh

# تجميع شفرة جافا
RUN javac -cp "${APP_DIR}/${ASPOSE_JAR}" ${APP_DIR}/TestAspose.java

# تعيين دليل العمل
WORKDIR /tmp

CMD ["sh", "-c", "/tmp/run.sh && cp /tmp/output/output.pdf /output"]
```


### **تطبيق Java**

إنشاء `TestAspose.java` مع:
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


## **4. الإنشاء والتشغيل**

### **بناء الصورة**

   نفّذ الأمر التالي في المجلد الذي يحتوي على Dockerfile لبناء صورة Docker:
   ```powershell
   docker build -t aspose-test .
   ```

- `-t` يسمي الصورة "aspose-test"
- `.` يستخدم Dockerfile الموجود في المجلد الحالي

### **تشغيل الحاوية**

   نفّذ الأمر التالي في المجلد الذي يحتوي على Dockerfile لتشغيل حاوية Docker:
```powershell
docker run -v "$(pwd)/output:/output" aspose-test
```

- `-v` يربط (mount) مجلد الإخراج
- ينشئ `output.pdf` في مجلد `output` المحلي الخاص بك