---
title: การแก้ไขปัญหาการติดตั้ง Aspose.Slides สำหรับ Node.js ผ่าน Java
linktitle: การแก้ไขปัญหาการติดตั้ง
type: docs
weight: 75
url: /th/nodejs-java/troubleshooting-installation/
keywords:
- ดาวน์โหลด Aspose.Slides
- ติดตั้ง Aspose.Slides
- แก้ไขปัญหาการติดตั้ง
- ความต้องการเวอร์ชัน
- Windows
- macOS
- Linux
- PowerPoint
- OpenDocument
- การนำเสนอ
- Node.js
- JavaScript
- Aspose.Slides
description: "แก้ไขปัญหาการติดตั้ง Aspose.Slides สำหรับ Node.js ผ่าน Java, แก้ไขข้อผิดพลาดทั่วไปและการพึ่งพา, และทำให้การทำงานกับ PPT, PPTX และ ODP ราบรื่น"
---
## **บทนำ**

เมื่อ[การติดตั้ง](/slides/th/nodejs-java/installation/) `aspose.slides.via.java` ด้วย `npm` มีบางกรณีที่เกิดข้อผิดพลาดระหว่างการคอมไพล์โมดูล `java` และ `node-gyp` เราได้ทำการตรวจสอบข้อผิดพลาดเหล่านี้อย่างละเอียดและระบุความต้องการเฉพาะสำหรับเวอร์ชันของโปรแกรมและแพคเกจที่ติดตั้ง

## **ความต้องการเวอร์ชัน**

1. สำหรับ Node.js 12 และก่อนหน้า:
   - Python ไม่เกิน 3.10
   - สำหรับ Windows แนะนำให้ติดตั้ง Visual Studio Build Tools ที่ไม่ใหม่กว่า 2017
   - เวอร์ชัน npm java package: 0.12.1

2. สำหรับ Node.js 13:
   - ความต้องการเดียวกับ Node.js 12

3. สำหรับ Node.js 14:
   - Python 3.10
   - เวอร์ชัน npm java package: 0.14.0

4. สำหรับ Node.js 15:
   - Python 3.12
   - เวอร์ชัน npm java package: 0.14.0

5. สำหรับ Node.js 16 ขึ้นไป:
   - Python 3.12
   - เวอร์ชัน npm java package: 0.14.0

**ทำตามคำแนะนำด้านล่างเพื่อ安装โปรแกรมที่จำเป็น**

### **การติดตั้งบน Unix**

- ติดตั้ง [Node.js](https://nodejs.org/en/download)
- ติดตั้ง [Python](https://devguide.python.org/versions)
- ติดตั้ง Java (JDK 1.8)
- ติดตั้งชุดคอมไพเลอร์ C/C++ ที่เหมาะสม เช่น [GCC](https://gcc.gnu.org)

### **การติดตั้งบน macOS**

- ติดตั้ง [Node.js](https://nodejs.org/en/download)
- ติดตั้ง [Python](https://devguide.python.org/versions)
- ติดตั้ง Java (JDK 1.8) และแก้ไขส่วน JVMCapabilities ใน `/Library/Java/JavaVirtualMachines/jdk1.8.x_xxx.jdk/Contents/Info.plist` ด้วยสิทธิ์ผู้ดูแลระบบ jdk1.8.x_xxx.jdk ขึ้นอยู่กับเวอร์ชันของ jdk ให้มีลักษณะดังนี้:
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
- ติดตั้ง `Xcode Command Line Tools` แบบสแตนด์อโลนโดยรัน `xcode-select --install` -- OR -- หรือหากคุณได้ติดตั้ง [Xcode เต็มชุด](https://developer.apple.com/xcode/download/) ไแล้ว คุณสามารถติดตั้ง Command Line Tools ได้จากเมนู `Xcode -> Open Developer Tool -> More Developer Tools...`

### **การติดตั้งบน Windows**

- ติดตั้ง [Node.js](https://nodejs.org/en/download)
- ติดตั้ง [Python](https://devguide.python.org/versions) จาก [Microsoft Store](https://apps.microsoft.com/store/search?publisher=Python+Software+Foundation)
- ติดตั้ง Java (JDK 1.8)
- ติดตั้ง [Visual C++ Build Environment](https://visualstudio.microsoft.com/thank-you-downloading-visual-studio/?sku=BuildTools) (ใช้ "Visual C++ build tools" หากใช้เวอร์ชันที่เก่ากว่า VS2019 มิฉะนั้นให้เลือก workload "Desktop development with C++" หรือ [Visual Studio Community](https://visualstudio.microsoft.com/thank-you-downloading-visual-studio/?sku=Community) พร้อม workload "Desktop development with C++")

ตรวจสอบให้แน่ใจว่า Node.js, Python และ Java ถูกเพิ่มไปยังตัวแปร PATH

## **การติดตั้ง Aspose.Slides for Node.js via Java บน Node.js เวอร์ชัน 14 ขึ้นไป**

ใช้คำสั่งต่อไปนี้:
```
npm i aspose.slides.via.java
```

## **การติดตั้ง Aspose.Slides for Node.js via Java บน Node.js เวอร์ชัน 12 หรือ 13**

Aspose.Slides for Node.js via Java ต้องติดตั้งด้วยตนเอง ใช้คำสั่งต่อไปนี้

- สำหรับ Node.js 12:
```
npm i java@0.12.1
```
- สำหรับ Node.js 13:
```
npm i java@0.13.0
```

จากนั้นดาวน์โหลด [aspose.slides.via.java](https://releases.aspose.com/slides/th/nodejs-java/) และแตกไฟล์ลงในโฟลเดอร์ `node_modules/aspose.slides.via.java`

## **การตรวจสอบการติดตั้ง**

เพื่อยืนยันการติดตั้ง ให้สร้างไฟล์ `index.js` ที่รากของโครงการด้วยเนื้อหาดังนี้:
```javascript
var aspose = aspose || {};
var java = require('java');
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation();
var slide = presentation.getSlides().get_Item(0);
slide.getShapes().addAutoShape(aspose.slides.ShapeType.Line, 50, 150, 300, 0);
presentation.save("lineShape.pptx", aspose.slides.SaveFormat.Pptx);
```

เรียกใช้ไฟล์นี้ด้วยคำสั่ง `node index.js`

## **ข้อมูลเพิ่มเติม**

อาจไม่สามารถครอบคลุมปัญหาทั้งหมดในบทความนี้ได้ เนื่องจากปัญหาเกิดจากการคอมไพล์โมดูล `java` และ `node-gyp` ดังนั้นลิงก์ต่อไปนี้อาจเป็นประโยชน์:
- [java installation](https://www.npmjs.com/package/java#installation)
- [node-gyp installation](https://www.npmjs.com/package/node-gyp#installation)