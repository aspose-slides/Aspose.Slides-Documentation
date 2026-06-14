---
title: Cài đặt Aspose.Slides cho Node.js qua Java sử dụng Docker
type: docs
weight: 75
url: /vi/nodejs-java/installing-slides-nodejs-using-docker/
keywords:
- tải xuống Aspose.Slides
- cài đặt Aspose.Slides
- cài đặt Aspose.Slides
- Docker
- Windows
- macOS
- Linux
- tính tương thích đa nền tảng
- cách ly phụ thuộc
- triển khai đơn giản hoá
- cài đặt dự án
- PowerPoint
- OpenDocument
- bài thuyết trình
- Node.js
- JavaScript
- Aspose.Slides
description: "Chạy Aspose.Slides trong các container Docker: cấu hình hình ảnh, phụ thuộc, phông chữ và giấy phép để xây dựng các dịch vụ mở rộng có thể xử lý PowerPoint & OpenDocument."
---
## Yêu cầu trước:
* Cài đặt Docker trên máy của bạn. Bạn có thể tham khảo hướng dẫn cài đặt chính thức [tại đây](https://docs.docker.com/get-docker/).

## Các bước:

### 1. **Tạo Dockerfile** 
   Tạo một tệp mới có tên Dockerfile trong thư mục dự án của bạn với nội dung sau:
   ``` 
   # Sử dụng Ubuntu 20.04 làm ảnh nền
   FROM ubuntu:20.04

   # Cập nhật danh sách gói và cài đặt các gói thiết yếu để thêm kho và tải xuống tệp
   RUN apt-get update && \
      apt-get install -y curl gnupg2 software-properties-common && \
      rm -rf /var/lib/apt/lists/*

   # Cài đặt Node.js phiên bản 18.x từ kho Nodesource
   RUN curl -fsSL https://deb.nodesource.com/setup_22.x | bash - && \
      apt-get install -y nodejs && \
      rm -rf /var/lib/apt/lists/*

   # Cài đặt Python 2.x, cần thiết cho một số gói npm như node-gyp
   RUN apt-get update && \
      apt-get install -y python2 && \
      rm -rf /var/lib/apt/lists/*

   # Cài đặt OpenJDK 11, cần thiết cho Aspose.Slides để phụ thuộc Java
   RUN apt-get update && \
      apt-get install -y openjdk-11-jdk && \
      rm -rf /var/lib/apt/lists/*

   # Cài đặt gói build-essential, bao gồm các công cụ như 'make' cần cho việc xây dựng mô-đun gốc
   RUN apt-get update && \
      apt-get install -y build-essential && \
      rm -rf /var/lib/apt/lists/*

   # Cài đặt node-gyp toàn cầu, công cụ dùng để biên dịch add-on gốc cho Node.js
   RUN npm install -g node-gyp

   # Đặt thư mục làm việc bên trong container là /app
   WORKDIR /app

   # Tạo tệp package.json với các chi tiết và phụ thuộc cần thiết
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

   # Tạo tệp index.js với mã mẫu để tạo bản trình bày bằng Aspose.Slides
   RUN echo 'const slides = require("aspose.slides.via.java");\n\
   var presentation = new slides.Presentation();\n\
   var slide = presentation.getSlides().get_Item(0);\n\
   slide.getShapes().addAutoShape(slides.ShapeType.Line, 50, 150, 300, 0);\n\
   presentation.save("./NewPresentation.pptx", slides.SaveFormat.Pptx);\n\
   console.log("Script completed, please check file /app/NewPresentation.pptx!");' > index.js

   # Cài đặt gói Aspose.Slides qua Java được chỉ định trong package.json
   RUN npm install aspose.slides.via.java

   # Đặt lệnh mặc định để chạy ứng dụng khi container khởi động
   CMD ["node", "index.js"]
   ```

### 2. **Xây dựng Docker Image**
   Chạy lệnh sau trong thư mục chứa Dockerfile để xây dựng hình ảnh Docker:
   ```bash
   docker build -t aspose-slides-nodejs .
   ```

### 3. **Chạy Docker Container**
   Chạy container và lưu ID của nó:
   ```bash
   CONTAINER_ID=$(docker create aspose-slides-nodejs)
   docker start -a $CONTAINER_ID
   ```

### 4. **Truy cập Aspose.Slides trong Docker** 
   Sau khi khởi động container, script sẽ tạo một tệp PPTX. Bạn có thể tìm tệp đầu ra đã tạo `NewPresentation.pptx` trong thư mục `/app` bên trong container:
   ```bash
   docker cp $CONTAINER_ID:/app/NewPresentation.pptx ./NewPresentation.pptx
   ```
   Xóa container tạm thời:
   ```bash
   docker rm $CONTAINER_ID
   ```