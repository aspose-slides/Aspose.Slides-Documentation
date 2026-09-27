---
title: Cài đặt
type: docs
weight: 70
url: /vi/nodejs-java/installation/
keywords:
- cài đặt Aspose.Slides
- tải xuống Aspose.Slides
- sử dụng Aspose.Slides
- cài đặt Aspose.Slides
- Windows
- Linux
- macOS
- PowerPoint
- OpenDocument
- bản trình bày
- Node.js
- JavaScript
- Aspose.Slides
description: "Cài đặt Aspose.Slides cho Node.js qua Java từ npm trên Windows, Linux và macOS: JDK, Python và công cụ xây dựng C++ mà nó cần, lệnh npm và một script đầu tiên để kiểm tra việc cài đặt."
---
## **Tổng quan**

Bài viết này giải thích cách cài đặt Aspose.Slides for Node.js via Java trên Windows, Linux và macOS, và cách kiểm tra việc cài đặt có hoạt động hay không.

Aspose.Slides for Node.js via Java được phân phối dưới dạng gói `aspose.slides.via.java` trên npm. Nó chạy Aspose.Slides trong một máy ảo Java thông qua gói [`java`](https://github.com/joeferner/node-java), một addon gốc của Node.js mà npm biên dịch trên máy tính của bạn trong quá trình cài đặt. Đó là lý do vì sao việc cài đặt cần, ngoài Node.js:

- **Bộ công cụ phát triển Java (JDK) 8 trở lên.** Chỉ có môi trường chạy Java không đủ: quá trình biên dịch cần các tập tin header của JDK.
- **Python 3**, mà công cụ biên dịch [node-gyp](https://github.com/nodejs/node-gyp) sử dụng.
- **Một chuỗi công cụ xây dựng C++** cho hệ điều hành của bạn.

## **Cài đặt các Yêu cầu Trước**

### **Windows**

1. Cài đặt [Node.js](https://nodejs.org/en/download) phiên bản 20 hoặc mới hơn.
2. Cài đặt một JDK, ví dụ như [Eclipse Temurin](https://adoptium.net/), và đặt biến môi trường `JAVA_HOME` trỏ đến thư mục cài đặt của nó. Quá trình biên dịch sử dụng JDK mà `JAVA_HOME` chỉ tới.
3. Cài đặt [Python 3](https://www.python.org/downloads/).
4. Cài đặt [Build Tools for Visual Studio 2022](https://aka.ms/vs/17/release/vs_BuildTools.exe) với gói công việc **Desktop development with C++**. Giữ nguyên các thành phần mặc định của gói công việc, bao gồm **MSVC v143 - VS 2022 C++ x64/x86 build tools** và **Windows 11 SDK**. Visual Studio 2026 không hoạt động: phiên bản node-gyp mà gói `java` biên dịch không nhận ra nó.

### **Linux**

Cài đặt Node.js 20 hoặc mới hơn từ [nodejs.org](https://nodejs.org/en/download) hoặc nguồn gói của bản phân phối của bạn. Sau đó cài đặt JDK, Python 3 và các công cụ xây dựng C++. Trên Debian và Ubuntu:

```bash
sudo apt-get update
sudo apt-get install -y default-jdk python3 build-essential
```

Trên Linux, quá trình biên dịch sẽ tự tìm JDK đã cài đặt mà không cần cấu hình thêm. Nếu có nhiều JDK được cài đặt, hãy đặt `JAVA_HOME` tới JDK mà bạn muốn sử dụng.

### **macOS**

Cài đặt Node.js 20 hoặc mới hơn, một JDK và Xcode Command Line Tools, bao gồm Python 3 và trình biên dịch C++. Xem [Troubleshooting Installation](/slides/vi/nodejs-java/troubleshooting-installation/) để biết các ghi chú cụ thể cho macOS.

## **Cài đặt từ npm**

Tạo một thư mục dự án và cài đặt gói:

```bash
mkdir hello-slides
cd hello-slides
npm init -y
npm install aspose.slides.via.java
```

npm tải xuống Aspose.Slides và biên dịch cầu nối `java`, việc này có thể mất vài phút. Nếu quá trình biên dịch thất bại, xem [Troubleshooting Installation](/slides/vi/nodejs-java/troubleshooting-installation/).

## **Kiểm tra việc Cài đặt**

Tạo một tệp có tên *hello.js* trong thư mục dự án với đoạn mã sau. Nó tạo một bản trình bày, thêm một hộp văn bản vào slide đầu tiên và lưu kết quả thành *hello.pptx*:

```javascript
const asposeSlides = require("aspose.slides.via.java");

const presentation = new asposeSlides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().addAutoShape(asposeSlides.ShapeType.Rectangle, 50, 50, 400, 100);
    shape.getTextFrame().setText("Hello, Aspose.Slides!");
    presentation.save("hello.pptx", asposeSlides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}

// Aspose.Slides chạy trong một máy ảo Java khiến Node.js không tự kết thúc, vì vậy hãy kết thúc tiến trình một cách rõ ràng.
process.exit(0);
```

Chạy script:

```bash
node hello.js
```

Nếu *hello.pptx* xuất hiện trong thư mục dự án, việc cài đặt đã thành công. Máy ảo Java chạy Aspose.Slides ngăn Node.js tự thoát, đó là lý do script kết thúc bằng `process.exit(0)`. [Create Presentations](/slides/vi/nodejs-java/create-presentation/) giải thích mã nguồn.

## **Cài đặt từ Tệp ZIP**

Gói này cũng có sẵn dưới dạng tệp ZIP với cùng nội dung như gói npm. Để cài đặt từ tệp ZIP:

1. Cài đặt các yêu cầu trước cho hệ điều hành của bạn, như mô tả ở trên.
2. Tải tệp nén từ [Aspose.Slides for Node.js via Java download page](https://releases.aspose.com/slides/nodejs-java/).
3. Tạo một thư mục dự án:

    ```bash
    mkdir hello-slides
    cd hello-slides
    npm init -y
    ```

4. Giải nén tệp vào một thư mục con có tên *aspose.slides.via.java* trong thư mục dự án, sao cho *package.json* của tệp nén nằm ở *hello-slides/aspose.slides.via.java/package.json*.
5. Cài đặt gói từ thư mục đó:

    ```bash
    npm install ./aspose.slides.via.java
    ```

    npm cài đặt cầu nối `java` mà gói này phụ thuộc và biên dịch nó, giống như khi cài đặt gói npm.
6. Kiểm tra việc cài đặt như mô tả trong [Check the Installation](#check-the-installation).

## **FAQ**

**Có phiên bản miễn phí hoặc giới hạn dùng thử không?**

Có. Nếu không có giấy phép, Aspose.Slides chạy ở chế độ đánh giá: nó thêm một watermark đánh giá vào mỗi slide được lưu và cắt ngắn văn bản đọc từ các bản trình bày. Để loại bỏ các hạn chế này, áp dụng một [license](/slides/vi/nodejs-java/licensing/) hợp lệ.

**Tại sao script của tôi không thoát sau khi hoàn thành?**

Gói `java` khởi động một máy ảo Java bên trong tiến trình Node.js, và máy ảo đó giữ tiến trình chạy. Gọi `process.exit` khi script của bạn đã hoàn thành công việc.