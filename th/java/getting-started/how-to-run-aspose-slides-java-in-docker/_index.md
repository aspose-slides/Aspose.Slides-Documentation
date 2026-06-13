---
title: วิธีรัน Aspose.Slides สำหรับ Java ใน Docker
type: docs
weight: 75
url: /th/java/how-to-run-aspose-slides-in-docker/
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
- การนำเสนอ
- Java
- Aspose.Slides
description: "รัน Aspose.Slides ในคอนเทนเนอร์ Docker: กำหนดค่าภาพ, การพึ่งพา, ฟอนต์, และการออกใบอนุญาตเพื่อสร้างบริการที่ขยายได้ที่ประมวลผล PowerPoint และ OpenDocument."
---
## **บทนำ**

คู่มือฉบับนี้อธิบายวิธีการทำคอนเทนเนอร์ไอแอปพลิเคชัน Java ด้วย Aspose Slides บน Docker. ประโยชน์หลักรวมถึง:

- **ความเข้ากันได้หลายแพลตฟอร์ม** - ทำงานบน Windows, macOS, และ Linux
- **การแยกการพึ่งพา** - ไม่ต้องติดตั้งระดับระบบ
- **การปรับใช้ที่ง่าย** - แชร์และรันได้ง่าย

## **1. การติดตั้ง Docker**

### **Windows**

**ความต้องการ:**

- Windows 10/11 Pro/Enterprise/Education (64 บิต) พร้อมเปิดใช้งาน WSL 2
- สำหรับรุ่น Home: ต้องติดตั้ง WSL 2 ด้วยตนเอง

**ขั้นตอน:**

1. Download the [Docker Desktop for Windows](https://www.docker.com/products/docker-desktop/)
2. Run the installer and follow the setup wizard
3. Restart your computer when prompted
4. Verify installation:
   ```powershell
   docker --version
   ```

### **macOS**

**ความต้องการ:**

- macOS 10.15 (Catalina) หรือใหม่กว่า
- โปรเซสเซอร์ Apple Silicon หรือ Intel

**ขั้นตอน:**

1. Download the [Docker Desktop for Mac](https://www.docker.com/products/docker-desktop/)
2. Drag the application to your `Applications` folder
3. Launch Docker and wait for initialization
4. Verify installation:
   ```bash
   docker --version
   ```

### **Linux (Ubuntu/Debian)**

**การติดตั้ง:**

```bash
# อัปเดตรายการแพคเกจ
sudo apt update && sudo apt upgrade -y

# ติดตั้งข้อกำหนดเบื้องต้น
sudo apt install -y \
    apt-transport-https \
    ca-certificates \
    curl \
    software-properties-common

# เพิ่มคีย์ GPG อย่างเป็นทางการของ Docker
curl -fsSL https://download.docker.com/linux/ubuntu/gpg | sudo gpg --dearmor -o /usr/share/keyrings/docker-archive-keyring.gpg

# เพิ่มรีโพซิทอรีที่เสถียร
echo "deb [arch=amd64 signed-by=/usr/share/keyrings/docker-archive-keyring.gpg] https://download.docker.com/linux/ubuntu $(lsb_release -cs) stable" | sudo tee /etc/apt/sources.list.d/docker.list > /dev/null

# ติดตั้ง Docker Engine
sudo apt update
sudo apt install -y docker-ce docker-ce-cli containerd.io

# อนุญาตผู้ใช้ปัจจุบันให้เรียกใช้คำสั่ง Docker
sudo usermod -aG docker $USER
newgrp docker

# ตรวจสอบการติดตั้ง
docker --version
```

## **2. การกำหนดค่า Dockerfile**

### **Base Image**

```dockerfile
FROM ubuntu:24.04
```
> **หมายเหตุ**: Uses the [official Ubuntu image](https://hub.docker.com/_/ubuntu) from Docker Hub.

### **การพึ่งพา**

```dockerfile
RUN apt-get install -y openjdk-11-jdk wget fontconfig ttf-mscorefonts-installer
```
- **OpenJDK 11**: สภาพแวดล้อมรันไทม์ของ Java
- **แพคเกจฟอนต์**: รวม Microsoft Core Fonts

### **การตั้งค่า Aspose.Slides**

```dockerfile
ENV ASPOSE_VERSION=25.3

ENV ASPOSE_JAR=aspose-slides-${ASPOSE_VERSION}-jdk16.jar
ENV ASPOSE_URL=https://releases.aspose.com/java/repo/com/aspose/aspose-slides/${ASPOSE_VERSION}/${ASPOSE_JAR}
```
- การดาวน์โหลด Aspose Slides library ด้วยเวอร์ชันที่กำหนด

## **3. การตั้งค่าโครงการ**

### **โครงสร้างไฟล์**

```
aspose-docker/
├── Dockerfile          # การกำหนดค่าคอนเทนเนอร์
├── TestAspose.java     # โค้ดแอปพลิเคชัน
└── output/             # โฟลเดอร์ที่มี PDF ที่สร้างขึ้น (สร้างโดยอัตโนมัติ)
```

### **Dockerfile**

Create a file named `Dockerfile` with:
```dockerfile
FROM ubuntu:24.04

# ตั้งค่าตัวแปรสภาพแวดล้อม
ENV JAVA_HOME=/usr/lib/jvm/java-11-openjdk-amd64
ENV PATH=$JAVA_HOME/bin:$PATH
ENV APP_DIR=/tmp
ENV ASPOSE_VERSION=25.3
ENV ASPOSE_JAR=aspose-slides-${ASPOSE_VERSION}-jdk16.jar
ENV ASPOSE_URL=https://releases.aspose.com/java/repo/com/aspose/aspose-slides/${ASPOSE_VERSION}/${ASPOSE_JAR}

# สร้างไดเรกทอรีทำงาน
RUN mkdir -p ${APP_DIR}
WORKDIR ${APP_DIR}

# ติดตั้งการพึ่งพา
RUN apt-get update && \
    apt-get install -y --no-install-recommends \
    openjdk-11-jdk \
    wget \
    fontconfig \
    ttf-mscorefonts-installer && \
    rm -rf /var/lib/apt/lists/*

# กำหนดค่าฟอนต์
RUN echo "ttf-mscorefonts-installer msttcorefonts/accepted-mscorefonts-eula select true" | debconf-set-selections && \
    apt-get update && \
    apt-get install -y --no-install-recommends ttf-mscorefonts-installer && \
    fc-cache -f -v

# ดาวน์โหลด Aspose.Slides ไปยัง /tmp
RUN wget ${ASPOSE_URL} -O ${APP_DIR}/${ASPOSE_JAR}

# คัดลอกซอร์สโค้ด
COPY TestAspose.java ${APP_DIR}/

# สร้างสคริปต์เรียกใช้งาน
RUN echo '#!/bin/bash' > ${APP_DIR}/run.sh && \
    echo 'java --add-opens=java.desktop/sun.java2d=ALL-UNNAMED \' >> ${APP_DIR}/run.sh && \
    echo '     --add-opens=java.desktop/sun.awt.image=ALL-UNNAMED \' >> ${APP_DIR}/run.sh && \
    echo '     --add-opens=java.desktop/sun.font=ALL-UNNAMED \' >> ${APP_DIR}/run.sh && \
    echo '     -cp ".:'"${ASPOSE_JAR}"'" TestAspose' >> ${APP_DIR}/run.sh && \
    chmod +x ${APP_DIR}/run.sh

# ให้สิทธิ์การดำเนินการกับสคริปต์อย่างชัดเจน
RUN chmod 755 ${APP_DIR}/run.sh

# คอมไพล์โค้ด Java
RUN javac -cp "${APP_DIR}/${ASPOSE_JAR}" ${APP_DIR}/TestAspose.java

# ตั้งค่าไดเรกทอรีทำงาน
WORKDIR /tmp

CMD ["sh", "-c", "/tmp/run.sh && cp /tmp/output/output.pdf /output"]
```

### **แอปพลิเคชัน Java**

Create `TestAspose.java` with:
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

## **4. การสร้างและรัน**

### **สร้างอิมเมจ**

Run the following command in the directory where your Dockerfile is located to build the Docker image:
```powershell
   docker build -t aspose-test .
   ```

- `-t` ตั้งชื่ออิมเมจเป็น "aspose-test"
- `.` ใช้ Dockerfile จากไดเรกทอรีปัจจุบัน

### **รันคอนเทนเนอร์**

Run the following command in the directory where your Dockerfile is located to run the Docker container:
```powershell
   docker run -v "$(pwd)/output:/output" aspose-test
   ```

- `-v` ติดตั้งไดเรกทอรี output
- สร้าง `output.pdf` ในโฟลเดอร์ `output` ของคุณ