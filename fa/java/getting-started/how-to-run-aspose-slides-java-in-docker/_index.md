---
title: نحوه اجرای Aspose.Slides برای جاوا در Docker
type: docs
weight: 75
url: /fa/java/how-to-run-aspose-slides-in-docker/
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
- Java
- Aspose.Slides
description: "اجرای Aspose.Slides در کانتینرهای Docker: پیکربندی تصاویر، وابستگی‌ها، فونت‌ها و مجوزها برای ساخت سرویس‌های مقیاس‌پذیر که PowerPoint و OpenDocument را پردازش می‌کنند."
---
## **مقدمه**

این راهنما توضیح می‌دهد که چگونه می‌توان یک برنامه جاوا را با استفاده از Aspose Slides و Docker در کانتینر قرار داد. مزایای کلیدی شامل:

- **قابلیت سازگاری چند پلتفرمی** - بر روی ویندوز، macOS و لینوکس اجرا می‌شود
- **ایزولاسیون وابستگی‌ها** - نیازی به نصب‌های سراسری سیستم نیست
- **استقرار ساده‌شده** - به‌اشتراک‌گذاری و اجرای آسان

## **1. نصب Docker**

### **ویندوز**

**الزامات:**

- ویندوز 10/11 Pro/Enterprise/Education (۶۴ بیتی) با WSL 2 فعال
- برای نسخه Home: نیاز به نصب دستی WSL 2 دارد

**مراحل:**

1. لینک [Docker Desktop for Windows](https://www.docker.com/products/docker-desktop/) را دانلود کنید
2. نصب‌کننده را اجرا کنید و مراحل نصب را دنبال کنید
3. وقتی خواسته شد، رایانه خود را ریستارت کنید
4. نصب را تأیید کنید:
   ```powershell
   docker --version
   ```

### **macOS**

**الزامات:**

- macOS 10.15 (Catalina) یا بالاتر
- پردازنده Apple Silicon یا Intel

**مراحل:**

1. لینک [Docker Desktop for Mac](https://www.docker.com/products/docker-desktop/) را دانلود کنید
2. برنامه را به پوشه `Applications` خود بکشید
3. Docker را اجرا کنید و منتظر تکمیل راه‌اندازی بمانید
4. نصب را تأیید کنید:
   ```bash
   docker --version
   ```

### **Linux (Ubuntu/Debian)**

**نصب:**

```bash
# به‌روزرسانی فهرست بسته‌ها
sudo apt update && sudo apt upgrade -y

# نصب پیش‌نیازها
sudo apt install -y \
    apt-transport-https \
    ca-certificates \
    curl \
    software-properties-common

# افزودن کلید GPG رسمی Docker
curl -fsSL https://download.docker.com/linux/ubuntu/gpg | sudo gpg --dearmor -o /usr/share/keyrings/docker-archive-keyring.gpg

# افزودن مخزن پایدار
echo "deb [arch=amd64 signed-by=/usr/share/keyrings/docker-archive-keyring.gpg] https://download.docker.com/linux/ubuntu $(lsb_release -cs) stable" | sudo tee /etc/apt/sources.list.d/docker.list > /dev/null

# نصب Docker Engine
sudo apt update
sudo apt install -y docker-ce docker-ce-cli containerd.io

# اجازه به کاربر فعلی برای اجرای دستورات Docker
sudo usermod -aG docker $USER
newgrp docker

# تأیید نصب
docker --version
```

## **2. پیکربندی Dockerfile**

### **تصویر پایه**

```dockerfile
FROM ubuntu:24.04
```
> **نکته**: از [تصویر رسمی اوبونتو](https://hub.docker.com/_/ubuntu) در Docker Hub استفاده می‌کند.

### **وابستگی‌ها**

```dockerfile
RUN apt-get install -y openjdk-11-jdk wget fontconfig ttf-mscorefonts-installer
```
- **OpenJDK 11**: محیط اجراگر جاوا
- **پکیج‌های فونت**: شامل Microsoft Core Fonts است

### **راه‌اندازی Aspose.Slides**

```dockerfile
ENV ASPOSE_VERSION=25.3

ENV ASPOSE_JAR=aspose-slides-${ASPOSE_VERSION}-jdk16.jar
ENV ASPOSE_URL=https://releases.aspose.com/java/repo/com/aspose/aspose-slides/${ASPOSE_VERSION}/${ASPOSE_JAR}
```
- بارگیری نسخه‌قفل شده از کتابخانه Aspose Slides

## **3. تنظیم پروژه**

### **ساختار فایل‌ها**

```
aspose-docker/
├── Dockerfile          # پیکربندی کانتینر
├── TestAspose.java     # کد برنامه
└── output/             # پوشه حاوی PDFهای تولید شده (به‌صورت خودکار ایجاد شده)
```

### **Dockerfile**

فایلی به نام `Dockerfile` ایجاد کنید با:
```dockerfile
FROM ubuntu:24.04

# تنظیم متغیرهای محیطی
ENV JAVA_HOME=/usr/lib/jvm/java-11-openjdk-amd64
ENV PATH=$JAVA_HOME/bin:$PATH
ENV APP_DIR=/tmp
ENV ASPOSE_VERSION=25.3
ENV ASPOSE_JAR=aspose-slides-${ASPOSE_VERSION}-jdk16.jar
ENV ASPOSE_URL=https://releases.aspose.com/java/repo/com/aspose/aspose-slides/${ASPOSE_VERSION}/${ASPOSE_JAR}

# ایجاد یک پوشه کاری
RUN mkdir -p ${APP_DIR}
WORKDIR ${APP_DIR}

# نصب وابستگی‌ها
RUN apt-get update && \
    apt-get install -y --no-install-recommends \
    openjdk-11-jdk \
    wget \
    fontconfig \
    ttf-mscorefonts-installer && \
    rm -rf /var/lib/apt/lists/*

# پیکربندی فونت‌ها
RUN echo "ttf-mscorefonts-installer msttcorefonts/accepted-mscorefonts-eula select true" | debconf-set-selections && \
    apt-get update && \
    apt-get install -y --no-install-recommends ttf-mscorefonts-installer && \
    fc-cache -f -v

# بارگیری Aspose.Slides به /tmp
RUN wget ${ASPOSE_URL} -O ${APP_DIR}/${ASPOSE_JAR}

# کپی کد منبع
COPY TestAspose.java ${APP_DIR}/

# ایجاد اسکریپت اجرا
RUN echo '#!/bin/bash' > ${APP_DIR}/run.sh && \
    echo 'java --add-opens=java.desktop/sun.java2d=ALL-UNNAMED \' >> ${APP_DIR}/run.sh && \
    echo '     --add-opens=java.desktop/sun.awt.image=ALL-UNNAMED \' >> ${APP_DIR}/run.sh && \
    echo '     --add-opens=java.desktop/sun.font=ALL-UNNAMED \' >> ${APP_DIR}/run.sh && \
    echo '     -cp ".:'"${ASPOSE_JAR}"'" TestAspose' >> ${APP_DIR}/run.sh && \
    chmod +x ${APP_DIR}/run.sh

# به‌طور صریح به اسکریپت مجوز اجرا بدهید
RUN chmod 755 ${APP_DIR}/run.sh

# کامپایل کد Java
RUN javac -cp "${APP_DIR}/${ASPOSE_JAR}" ${APP_DIR}/TestAspose.java

# تنظیم پوشه کاری
WORKDIR /tmp

CMD ["sh", "-c", "/tmp/run.sh && cp /tmp/output/output.pdf /output"]
```

### **برنامه جاوا**

فایل `TestAspose.java` را ایجاد کنید با:
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

## **4. ساخت و اجرا**

### **ساخت تصویر**

دستور زیر را در دایرکتوری که Dockerfile شما قرار دارد اجرا کنید تا تصویر Docker ساخته شود:
```powershell
   docker build -t aspose-test .
   ```

- `-t` نام تصویر را به «aspose-test» می‌گذارد
- `.` از Dockerfile موجود در دایرکتوری جاری استفاده می‌کند

### **اجرای کانتینر**

دستور زیر را در دایرکتوری که Dockerfile شما قرار دارد اجرا کنید تا کانتینر Docker را اجرا کنید:
```powershell
   docker run -v "$(pwd)/output:/output" aspose-test
   ```

- `-v` دایرکتوری خروجی را سوار می‌کند
- فایل `output.pdf` را در پوشهٔ محلی `output` شما ایجاد می‌کند