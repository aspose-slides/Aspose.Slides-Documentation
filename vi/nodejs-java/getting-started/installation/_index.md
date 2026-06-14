---
title: Cài đặt
type: docs
weight: 70
url: /vi/nodejs-java/installation/
keywords:
- cài đặt Aspose.Slides
- tải về Aspose.Slides
- sử dụng Aspose.Slides
- cài đặt Aspose.Slides
- Windows
- Linux
- macOS
- PowerPoint
- OpenDocument
- bài thuyết trình
- Node.js
- JavaScript
- Aspose.Slides
description: "Tìm hiểu cách cài đặt nhanh Aspose.Slides. Hướng dẫn từng bước, yêu cầu hệ thống và mẫu mã — bắt đầu làm việc với các bài thuyết trình PowerPoint ngay hôm nay!"
---
## **Giới thiệu**

Aspose.Slides for Node.js via Java là API độc lập với nền tảng và có thể được sử dụng trên bất kỳ nền tảng nào (Windows, Linux và MacOS) nơi đã cài đặt `Node.js` và cầu nối [`java`](https://www.npmjs.com/package/java).

## **Cài đặt từ NPM**

Bạn có thể dễ dàng cài đặt Aspose.Slides for Node.js via Java từ [NPM](https://www.npmjs.com/).

1. Tạo một thư mục mới và khởi tạo một dự án mới bằng lệnh sau:
	```
	$ npm init
	```
	
2. Điền vào các trường tiêu đề và phiên bản (để các trường còn lại với giá trị mặc định).

3. Cài đặt Aspose.Slides for Node.js via Java bằng lệnh sau:
	```
	$ npm install aspose.slides.via.java
	```

Nếu bạn gặp bất kỳ vấn đề nào trong quá trình cài đặt, vui lòng tham khảo [bài viết](/slides/vi/nodejs-java/troubleshooting-installation/).

**Ví dụ sử dụng**:

Tạo một tệp có tên `hello.js` trong thư mục dự án của bạn và thêm đoạn mã mẫu sau:

```javascript
var aspose = aspose || {};

aspose.slides = require("aspose.slides.via.java");

var pres = new aspose.slides.Presentation();

var slide = pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0));

slide.getShapes().get_Item(0).getTextFrame().setText("Slide Title Heading");

pres.save("out.pptx", aspose.slides.SaveFormat.Pptx)

console.log("Done");
```

## **Cài đặt từ tệp ZIP**

Để cài đặt và sử dụng Aspose.Slides for Node.js via Java từ tệp ZIP, hãy làm theo các hướng dẫn sau:

### **Windows**

1. Cài đặt JDK8 và cấu hình biến môi trường `JAVA_HOME`.
1. Cài đặt Node.js (https://nodejs.org/en/download/) và thêm node.exe vào `PATH`.
1. Cài đặt node-gyp.
1. Cài đặt Windows Build Tools.
1. Cài đặt cầu nối [`java`](https://www.npmjs.com/package/java) và chạy các lệnh sau trong Command Prompt với quyền quản trị:
	```bash
	$ mkdir aspose.slides.nodejs

	$ cd aspose.slides.nodejs

	$ npm install -g node-gyp

	$ npm install --global --production windows-build-tools

	$ npm install java
	```
6. [Tải về Aspose.Slides for Node.js via Java](https://releases.aspose.com/slides/vi/nodejs-java/) và giải nén vào `aspose.slides.nodejs/node_modules/aspose.slides.via.java`.
7. Tạo một tệp có tên `hello.js` trong thư mục `aspose.slides.nodejs` bằng đoạn mã mẫu sau:

	```javascript
	var aspose = aspose || {};

	aspose.slides = require("aspose.slides.via.java");

	var pres = new aspose.slides.Presentation();

	var slide = pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0));

	slide.getShapes().get_Item(0).getTextFrame().setText("Slide Title Heading");

	pres.save("out.pptx", aspose.slides.SaveFormat.Pptx)

	console.log("Done");
	```

8. Bây giờ chạy `node hello.js` trong command prompt để thực thi nó.

### **Linux**

1. Cài đặt Node.js (https://nodejs.org/en/download/).
1. Cài đặt JDK8 cho Linux và cấu hình biến môi trường `JAVA_HOME`.
1. Cài đặt python 2.x
1. Cài đặt cầu nối [`java`](https://www.npmjs.com/package/java). Bạn có thể chạy các lệnh sau trong terminal:
	```bash
	$ mkdir aspose.slides.nodejs

	$ cd aspose.slides.nodejs

	$ npm install java
	```
5. [Tải về Aspose.Slides for Node.js via Java](https://releases.aspose.com/slides/vi/nodejs-java/) và giải nén vào `aspose.slides.nodejs/node_modules/aspose.slides.via.java`.
6. Tạo một tệp thử nghiệm có tên `hello.js` bằng đoạn mã mẫu này trong thư mục `aspose.slides.nodejs`:

	```javascript
	var aspose = aspose || {};

	aspose.slides = require("aspose.slides.via.java");

	var pres = new aspose.slides.Presentation();

	var slide = pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0));

	slide.getShapes().get_Item(0).getTextFrame().setText("Slide Title Heading");

	pres.save("out.pptx", aspose.slides.SaveFormat.Pptx)

	console.log("Done");
	```
7. Bây giờ chạy `node hello.js` trong command prompt để thực thi nó.

### **Mac**

1. Cài đặt Node.js (https://nodejs.org/en/download/).
1. Cài đặt JDK8 cho Mac và cấu hình biến môi trường `JAVA_HOME`.
1. Sửa đổi phần JVMCapabilities trong `/Library/Java/JavaVirtualMachines/jdk1.8.x_xxx.jdk/Contents/Info.plist` với quyền root. `jdk1.8.x_xxx.jdk` phụ thuộc vào phiên bản jdk của bạn. Đặt nó giống như sau:
	```xml
	<key>JavaVM</key>
		<dict>
			<key>JVMCapabilities</key>
			<array>
					<string>JNI</string>
					<string>BundledApp</string>
					<string>CommandLine</string>
			</array>
	```
4. Cài đặt python 2.x (nếu chưa được cài đặt).
5. Cài đặt Xcode Command Line Tools.
6. Cài đặt cầu nối [`java`](https://www.npmjs.com/package/java). Bạn có thể chạy các lệnh dưới đây trong terminal:
	```bash
	$ mkdir aspose.slides.nodejs
	 
	$ cd aspose.slides.nodejs
	 
	$ npm install java
	```
7. Tải về Aspose.Slides for Node.js via Java và giải nén vào `aspose.slides.nodejs/node_modules/aspose.slides.via.java`.
8. Tạo một tệp thử nghiệm có tên `hello.js` bằng đoạn mã mẫu này trong thư mục `aspose.slides.nodejs`:

	```javascript
	var aspose = aspose || {};

	aspose.slides = require("aspose.slides.via.java");

	var pres = new aspose.slides.Presentation();

	var slide = pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0));

	slide.getShapes().get_Item(0).getTextFrame().setText("Slide Title Heading");

	pres.save("out.pptx", aspose.slides.SaveFormat.Pptx)

	console.log("Done");
	```
9. Bây giờ chạy `node hello.js` trong command prompt để thực thi nó.

{{% alert color="primary" %}}
Vui lòng sử dụng [bài viết](https://docs.aspose.com/slides/vi/nodejs-java/troubleshooting-installation/) nếu bạn gặp lỗi biên dịch trong quá trình cài đặt Aspose.Slides for Node.js via Java.
{{% /alert %}}

## **Câu hỏi thường gặp**

**Có phiên bản miễn phí hay giới hạn bản dùng thử không?**

Có, mặc định, Aspose.Slides chạy ở chế độ đánh giá, sẽ hiển thị watermark và có thể có các hạn chế khác. Để loại bỏ các hạn chế, bạn cần áp dụng một [giấy phép](/slides/vi/nodejs-java/licensing/) hợp lệ.