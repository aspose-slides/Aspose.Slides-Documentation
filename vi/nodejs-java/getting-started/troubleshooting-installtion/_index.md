---
title: Khắc phục sự cố cài đặt Aspose.Slides cho Node.js qua Java
linktitle: Khắc phục cài đặt
type: docs
weight: 75
url: /vi/nodejs-java/troubleshooting-installation/
keywords:
- tải xuống Aspose.Slides
- cài đặt Aspose.Slides
- khắc phục sự cố cài đặt
- yêu cầu phiên bản
- Windows
- macOS
- Linux
- PowerPoint
- OpenDocument
- bài thuyết trình
- Node.js
- JavaScript
- Aspose.Slides
description: "Khắc phục các vấn đề cài đặt Aspose.Slides cho Node.js qua Java, sửa các lỗi và phụ thuộc thường gặp, và đảm bảo hoạt động trơn tru với PPT, PPTX và ODP."
---
## **Giới thiệu**

Khi [cài đặt](/slides/vi/nodejs-java/installation/) `aspose.slides.via.java` bằng `npm`, có những trường hợp lỗi xảy ra trong quá trình biên dịch các mô-đun `java` và `node-gyp`. Chúng tôi đã điều tra các lỗi này chi tiết hơn và xác định các yêu cầu cụ thể cho phiên bản của các chương trình và gói đã được cài đặt. 

## **Yêu cầu phiên bản**

1. Đối với Node.js 12 và các phiên bản trước:
   - Python không được cao hơn 3.10.
   - Đối với Windows, nên cài đặt Visual Studio Build Tools không mới hơn năm 2017.
   - phiên bản gói npm java: 0.12.1.

2. Đối với Node.js 13:
   - Các yêu cầu tương tự như đối với Node.js 12.

3. Đối với Node.js 14:
   - Python 3.10.
   - phiên bản gói npm java: 0.14.0.

4. Đối với Node.js 15:
   - Python 3.12.
   - phiên bản gói npm java: 0.14.0.

5. Đối với Node.js 16 và các phiên bản mới hơn:
   - Python 3.12.
   - phiên bản gói npm java: 0.14.0.

**Làm theo các hướng dẫn dưới đây để cài đặt các chương trình cần thiết.**

### **Cài đặt trên Unix**

- Cài đặt [Node.js](https://nodejs.org/en/download).
- Cài đặt [Python](https://devguide.python.org/versions/).
- Cài đặt Java (JDK 1.8).
- Cài đặt một chuỗi công cụ biên dịch C/C++ thích hợp, chẳng hạn như [GCC](https://gcc.gnu.org).

### **Cài đặt trên macOS**

- Cài đặt [Node.js](https://nodejs.org/en/download).
- Cài đặt [Python](https://devguide.python.org/versions/).
- Cài đặt Java (JDK 1.8) và sửa mục JVMCapabilities trong /Library/Java/JavaVirtualMachines/jdk1.8.x_xxx.jdk/Contents/Info.plist với quyền root. jdk1.8.x_xxx.jdk phụ thuộc vào phiên bản jdk của bạn. Đặt nó như sau: 
```
<key>JavaVM</key>
    <dict>
        <key>JVMCapabilities</key>
        <array>
                <string>JNI</string>
                <string>BundledApp</string>
                <string>CommandLine</string>
        </array>
```
- Cài đặt công cụ `Xcode Command Line Tools` riêng lẻ bằng cách chạy `xcode-select --install`. -- HOẶC -- Ngoài ra, nếu bạn đã có [Xcode đầy đủ đã được cài đặt](https://developer.apple.com/xcode/download/), bạn có thể cài đặt Command Line Tools trong menu `Xcode -> Open Developer Tool -> More Developer Tools...`.

### **Cài đặt trên Windows**

- Cài đặt [Node.js](https://nodejs.org/en/download).
- Cài đặt [Python](https://devguide.python.org/versions/) từ [Microsoft Store](https://apps.microsoft.com/store/search?publisher=Python+Software+Foundation).
- Cài đặt Java (JDK 1.8).
- Cài đặt [Visual C++ Build Environment](https://visualstudio.microsoft.com/thank-you-downloading-visual-studio/?sku=BuildTools) (sử dụng "Visual C++ build tools" nếu dùng phiên bản cũ hơn VS2019, nếu không hãy chọn workload "Desktop development with C++" hoặc [Visual Studio Community](https://visualstudio.microsoft.com/thank-you-downloading-visual-studio/?sku=Community) với workload "Desktop development with C++").

Đảm bảo rằng Node.js, Python và Java đã được thêm vào biến PATH.

## **Cài đặt Aspose.Slides cho Node.js qua Java trên Node.js phiên bản 14 trở lên**

Chỉ cần chạy lệnh:
```
npm i aspose.slides.via.java
```

## **Cài đặt Aspose.Slides cho Node.js qua Java trên Node.js phiên bản 12 hoặc 13**

Aspose.Slides cho Node.js qua Java cần được cài đặt thủ công. Sử dụng lệnh sau:

- Đối với Node.js 12:
```
npm i java@0.12.1
```
- Đối với Node.js 13: 
```
npm i java@0.13.0
```

Sau đó tải xuống [aspose.slides.via.java](https://releases.aspose.com/slides/vi/nodejs-java/) và giải nén vào thư mục `node_modules/aspose.slides.via.java`.

## **Xác thực cài đặt**

Để xác thực cài đặt, tạo một file `index.js` ở thư mục gốc của dự án với nội dung sau:

```javascript
var aspose = aspose || {};
var java = require('java');
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation();
var slide = presentation.getSlides().get_Item(0);
slide.getShapes().addAutoShape(aspose.slides.ShapeType.Line, 50, 150, 300, 0);
presentation.save("lineShape.pptx", aspose.slides.SaveFormat.Pptx);
```

Chạy file này bằng lệnh `node index.js`.

## **Thông tin bổ sung**

Không thể bao quát mọi vấn đề có thể xảy ra trong phạm vi của bài viết này. Vì các vấn đề phát sinh do việc biên dịch các mô-đun `java` và `node-gyp` nên các liên kết sau cũng sẽ hữu ích:
- [cài đặt java](https://www.npmjs.com/package/java#installation) 
- [cài đặt node-gyp](https://www.npmjs.com/package/node-gyp#installation)