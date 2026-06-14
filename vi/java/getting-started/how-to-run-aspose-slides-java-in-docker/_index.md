---
title: Cách chạy Aspose.Slides cho Java trong Docker
type: docs
weight: 75
url: /vi/java/how-to-run-aspose-slides-in-docker/
keywords:
- tải xuống Aspose.Slides
- cài đặt Aspose.Slides
- cài đặt Aspose.Slides
- Docker
- Windows
- macOS
- Linux
- khả năng tương thích đa nền tảng
- cô lập phụ thuộc
- triển khai đơn giản
- cài đặt dự án
- PowerPoint
- OpenDocument
- bản trình bày
- Java
- Aspose.Slides
description: "Chạy Aspose.Slides trong các container Docker: cấu hình hình ảnh, phụ thuộc, phông chữ và giấy phép để xây dựng các dịch vụ mở rộng quy mô xử lý PowerPoint và OpenDocument."
---
## **Giới thiệu**

Hướng dẫn này giải thích cách đóng gói một ứng dụng Java bằng Aspose Slides với Docker. Các lợi ích chính bao gồm:

- **Khả năng tương thích đa nền tảng** - Chạy trên Windows, macOS và Linux
- **Cách ly phụ thuộc** - Không cần cài đặt trên toàn hệ thống
- **Triển khai đơn giản** - Dễ dàng chia sẻ và thực thi

## **1. Cài đặt Docker**

### **Windows**

**Yêu cầu:**

- Windows 10/11 Pro/Enterprise/Education (64-bit) với WSL 2 được bật
- Đối với bản Home: Cần cài đặt WSL 2 thủ công

**Các bước:**

1. Tải xuống [Docker Desktop for Windows](https://www.docker.com/products/docker-desktop/)
2. Chạy trình cài đặt và làm theo hướng dẫn cài đặt
3. Khởi động lại máy tính khi được yêu cầu
4. Xác minh cài đặt:
   ```powershell
   docker --version
   ```

### **macOS**

**Yêu cầu:**

- macOS 10.15 (Catalina) trở lên
- Bộ xử lý Apple Silicon hoặc Intel

**Các bước:**

1. Tải xuống [Docker Desktop for Mac](https://www.docker.com/products/docker-desktop/)
2. Kéo ứng dụng vào thư mục `Applications` của bạn
3. Khởi động Docker và chờ quá trình khởi tạo
4. Xác minh cài đặt:
   ```bash
   docker --version
   ```

### **Linux (Ubuntu/Debian)**

**Cài đặt:**

```bash
# Cập nhật danh sách gói
sudo apt update && sudo apt upgrade -y

# Cài đặt các gói cần thiết
sudo apt install -y \
    apt-transport-https \
    ca-certificates \
    curl \
    software-properties-common

# Thêm khóa GPG chính thức của Docker
curl -fsSL https://download.docker.com/linux/ubuntu/gpg | sudo gpg --dearmor -o /usr/share/keyrings/docker-archive-keyring.gpg

# Thêm một kho lưu trữ ổn định
echo "deb [arch=amd64 signed-by=/usr/share/keyrings/docker-archive-keyring.gpg] https://download.docker.com/linux/ubuntu $(lsb_release -cs) stable" | sudo tee /etc/apt/sources.list.d/docker.list > /dev/null

# Cài đặt Docker Engine
sudo apt update
sudo apt install -y docker-ce docker-ce-cli containerd.io

# Cho phép người dùng hiện tại chạy các lệnh Docker
sudo usermod -aG docker $USER
newgrp docker

# Xác minh cài đặt
docker --version
```

## **2. Cấu hình Dockerfile**

### **Ảnh nền**

```dockerfile
FROM ubuntu:24.04
```
> **Lưu ý**: Sử dụng [ảnh Ubuntu chính thức](https://hub.docker.com/_/ubuntu) từ Docker Hub.

### **Phụ thuộc**

```dockerfile
RUN apt-get install -y openjdk-11-jdk wget fontconfig ttf-mscorefonts-installer
```
- **OpenJDK 11**: Môi trường chạy Java
- **Gói phông chữ**: Bao gồm Microsoft Core Fonts

### **Cài đặt Aspose.Slides**

```dockerfile
ENV ASPOSE_VERSION=25.3

ENV ASPOSE_JAR=aspose-slides-${ASPOSE_VERSION}-jdk16.jar
ENV ASPOSE_URL=https://releases.aspose.com/java/repo/com/aspose/aspose-slides/${ASPOSE_VERSION}/${ASPOSE_JAR}
```
- Tải xuống thư viện Aspose Slides với phiên bản cố định

## **3. Cài đặt dự án**

### **Cấu trúc tệp**

```
aspose-docker/
├── Dockerfile          # Cấu hình container
├── TestAspose.java     # Mã ứng dụng
└── output/             # Thư mục chứa các PDF được tạo (tự động tạo)
```

### **Dockerfile**

Tạo một tệp có tên `Dockerfile` với nội dung:
```dockerfile
FROM ubuntu:24.04

# Đặt các biến môi trường
ENV JAVA_HOME=/usr/lib/jvm/java-11-openjdk-amd64
ENV PATH=$JAVA_HOME/bin:$PATH
ENV APP_DIR=/tmp
ENV ASPOSE_VERSION=25.3
ENV ASPOSE_JAR=aspose-slides-${ASPOSE_VERSION}-jdk16.jar
ENV ASPOSE_URL=https://releases.aspose.com/java/repo/com/aspose/aspose-slides/${ASPOSE_VERSION}/${ASPOSE_JAR}

# Tạo thư mục làm việc
RUN mkdir -p ${APP_DIR}
WORKDIR ${APP_DIR}

# Cài đặt các phụ thuộc
RUN apt-get update && \
    apt-get install -y --no-install-recommends \
    openjdk-11-jdk \
    wget \
    fontconfig \
    ttf-mscorefonts-installer && \
    rm -rf /var/lib/apt/lists/*

# Cấu hình phông chữ
RUN echo "ttf-mscorefonts-installer msttcorefonts/accepted-mscorefonts-eula select true" | debconf-set-selections && \
    apt-get update && \
    apt-get install -y --no-install-recommends ttf-mscorefonts-installer && \
    fc-cache -f -v

# Tải Aspose.Slides về /tmp
RUN wget ${ASPOSE_URL} -O ${APP_DIR}/${ASPOSE_JAR}

# Sao chép mã nguồn
COPY TestAspose.java ${APP_DIR}/

# Tạo script chạy
RUN echo '#!/bin/bash' > ${APP_DIR}/run.sh && \
    echo 'java --add-opens=java.desktop/sun.java2d=ALL-UNNAMED \' >> ${APP_DIR}/run.sh && \
    echo '     --add-opens=java.desktop/sun.awt.image=ALL-UNNAMED \' >> ${APP_DIR}/run.sh && \
    echo '     --add-opens=java.desktop/sun.font=ALL-UNNAMED \' >> ${APP_DIR}/run.sh && \
    echo '     -cp ".:'"${ASPOSE_JAR}"'" TestAspose' >> ${APP_DIR}/run.sh && \
    chmod +x ${APP_DIR}/run.sh

# Cấp quyền thực thi cho script một cách rõ ràng
RUN chmod 755 ${APP_DIR}/run.sh

# Biên dịch mã Java
RUN javac -cp "${APP_DIR}/${ASPOSE_JAR}" ${APP_DIR}/TestAspose.java

# Đặt thư mục làm việc
WORKDIR /tmp

CMD ["sh", "-c", "/tmp/run.sh && cp /tmp/output/output.pdf /output"]
```

### **Ứng dụng Java**

Tạo `TestAspose.java` với nội dung:
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

## **4. Xây dựng và Chạy**

### **Xây dựng Image**

   Chạy lệnh sau trong thư mục chứa Dockerfile của bạn để xây dựng image Docker:
   ```powershell
   docker build -t aspose-test .
   ```
   
- `-t` đặt tên cho image là "aspose-test"
- `.` sử dụng Dockerfile trong thư mục hiện tại

### **Chạy Container**

   Chạy lệnh sau trong thư mục chứa Dockerfile của bạn để chạy container Docker:
   ```powershell
   docker run -v "$(pwd)/output:/output" aspose-test
   ```
   
- `-v` gắn thư mục đầu ra
- Tạo `output.pdf` trong thư mục `output` cục bộ của bạn