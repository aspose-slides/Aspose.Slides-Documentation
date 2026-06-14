---
title: Cài đặt
type: docs
weight: 70
url: /vi/nodejs-net/installation/
keywords:
- tải xuống Aspose.Slides
- cài đặt Aspose.Slides
- cài đặt Aspose.Slides
- Windows
- macOS
- Linux
- JavaScript
- Node.js
description: "Cài đặt Aspose.Slides cho Node.js qua .NET trên Windows, Linux hoặc macOS"
---
Aspose.Slides for Node.js qua .NET là API độc lập nền tảng và có thể được sử dụng trên bất kỳ nền tảng nào (Windows, Linux và macOS) nơi đã cài đặt `Node.js` và cầu nối `edge-js`.

## **Cài đặt từ NPM**

Bạn có thể dễ dàng cài đặt Aspose.Slides for Node.js qua .NET từ [NPM](https://www.npmjs.com/) bằng lệnh sau:
```
$ npm install aspose.slides.via.net
```
Nếu bạn gặp bất kỳ vấn đề nào trong quá trình cài đặt, vui lòng tham khảo https://www.npmjs.com/package/edge-js.

## **Cài đặt từ tệp ZIP**

Để cài đặt và sử dụng Aspose.Slides for Node.js qua .NET từ tệp ZIP, hãy làm theo các hướng dẫn sau:

### **Windows**

1. Cài đặt .NET6 hoặc phiên bản mới hơn.
1. Cài đặt Node.js (https://nodejs.org/en/download/) và thêm node.exe vào `PATH`.
1. Cài đặt edge-js.
```
$ mkdir aspose.slides.nodejs.net

$ cd aspose.slides.nodejs.net

$ npm install -g edge-js
```
6. [Tải xuống Aspose.Slides for Node.js qua .NET](https://releases.aspose.com/slides/vi/nodejs-net/) và giải nén vào `aspose.slides.nodejs/node_modules/aspose.slides.via.net`.
7. Tạo một tệp có tên `hello.js` trong thư mục `aspose.slides.nodejs.net` bằng mã mẫu sau:

```javascript
// Nhập mô-đun Aspose.Slides để thao tác tệp PowerPoint
const asposeSlides = require('aspose.slides.via.net');

// Thêm các lớp cần thiết từ asposeSlides
const { Presentation, SaveFormat, PdfOptions } = asposeSlides;

const fs = require('fs');
if (!fs.existsSync("out")) fs.mkdirSync("out");

// Tạo và lưu một bài thuyết trình rỗng để minh họa chức năng cơ bản
function createEmptyPresentation() {
	
    // Khởi tạo một bài thuyết trình rỗng mới
    var emptyPresentation = new Presentation();
    
    // Lưu bài thuyết trình rỗng ở định dạng PPTX
    emptyPresentation.save("out/emptyPresentation.pptx", SaveFormat.Pptx);
    
    // Giải phóng tài nguyên liên quan đến bài thuyết trình
    emptyPresentation.dispose();
}

createEmptyPresentation(); // Thực thi hàm để tạo một bài thuyết trình rỗng
```

8. Bây giờ chạy `node hello.js` trong command prompt để thực thi.

### **Linux**

1. Cài đặt .NET6 hoặc phiên bản mới hơn.
1. Cài đặt Node.js (https://nodejs.org/en/download/) và thêm node.exe vào `PATH`.
1. Cài đặt edge-js.
```
$ mkdir aspose.slides.nodejs.net

$ cd aspose.slides.nodejs.net

$ npm install edge-js
```
5. [Tải xuống Aspose.Slides for Node.js qua Java](https://releases.aspose.com/slides/vi/nodejs-net/) và giải nén vào `aspose.slides.nodejs/node_modules/aspose.slides.via.net`.
6. Tạo một tệp thử nghiệm có tên `hello.js` bằng mã mẫu này trong thư mục `aspose.slides.nodejs.net`:

```javascript
// Nhập mô-đun Aspose.Slides để thao tác tệp PowerPoint
const asposeSlides = require('aspose.slides.via.net');

// Thêm các lớp cần thiết từ asposeSlides
const { Presentation, SaveFormat, PdfOptions } = asposeSlides;

const fs = require('fs');
if (!fs.existsSync("out")) fs.mkdirSync("out");

// Tạo và lưu một bài thuyết trình rỗng để minh họa chức năng cơ bản
function createEmptyPresentation() {
	
    // Khởi tạo một bài thuyết trình rỗng mới
    var emptyPresentation = new Presentation();
    
    // Lưu bài thuyết trình rỗng ở định dạng PPTX
    emptyPresentation.save("out/emptyPresentation.pptx", SaveFormat.Pptx);
    
    // Giải phóng tài nguyên liên quan đến bài thuyết trình
    emptyPresentation.dispose();
}

createEmptyPresentation(); // Thực thi hàm để tạo một bài thuyết trình rỗng
```
7. Bây giờ chạy `node hello.js` trong command prompt để thực thi.

### **Mac**

1. Cài đặt .NET6 hoặc phiên bản mới hơn.
1. Cài đặt Node.js (https://nodejs.org/en/download/) và thêm node.exe vào `PATH`.
1. Cài đặt edge-js.

$ mkdir aspose.slides.nodejs.net

$ cd aspose.slides.nodejs.net

$ npm install edge-js
```

```javascript
// Import the Aspose.Slides module for PowerPoint file manipulation
const asposeSlides = require('aspose.slides.via.net');

// Add necessary classes from the asposeSlides
const { Presentation, SaveFormat, PdfOptions } = asposeSlides;

const fs = require('fs');
if (!fs.existsSync("out")) fs.mkdirSync("out");

// Create and save an empty presentation to demonstrate basic functionality
function createEmptyPresentation() {
	
    // Initialize a new empty presentation
    var emptyPresentation = new Presentation();
    
    // Save the empty presentation in PPTX format
    emptyPresentation.save("out/emptyPresentation.pptx", SaveFormat.Pptx);
    
    // Release resources associated with the presentation
    emptyPresentation.dispose();
}

createEmptyPresentation(); // Execute the function to create an empty presentation
9. Bây giờ chạy `node hello.js` trong command prompt để thực thi.