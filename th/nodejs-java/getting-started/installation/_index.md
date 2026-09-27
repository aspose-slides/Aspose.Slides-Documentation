---
title: การติดตั้ง
type: docs
weight: 70
url: /th/nodejs-java/installation/
keywords:
- ติดตั้ง Aspose.Slides
- ดาวน์โหลด Aspose.Slides
- ใช้ Aspose.Slides
- การติดตั้ง Aspose.Slides
- วินโดวส์
- ลินุกซ์
- macOS
- PowerPoint
- OpenDocument
- การนำเสนอ
- Node.js
- จาวาสคริปต์
- Aspose.Slides
description: "ติดตั้ง Aspose.Slides สำหรับ Node.js ผ่าน Java จาก npm บน Windows, Linux, และ macOS: JDK, Python, และเครื่องมือการสร้าง C++ ที่จำเป็น, คำสั่ง npm, และสคริปต์แรกเพื่อตรวจสอบการติดตั้ง."
---
## **ภาพรวม**

บทความนี้อธิบายวิธีการติดตั้ง Aspose.Slides for Node.js via Java บน Windows, Linux, และ macOS รวมถึงวิธีตรวจสอบว่าการติดตั้งทำงานได้หรือไม่

Aspose.Slides for Node.js via Java จะจัดจำหน่ายเป็นแพ็คเกจ `aspose.slides.via.java` บน npm ซึ่งทำงานโดยรัน Aspose.Slides ในเครื่องเสมือน Java ผ่านแพ็คเกจ [`java`](https://github.com/joeferner/node-java) ซึ่งเป็นส่วนเสริมของ Node.js ที่ npm จะคอมไพล์บนเครื่องของคุณระหว่างการติดตั้ง นั่นคือเหตุผลที่การติดตั้งต้องการสิ่งต่อไปนี้ นอกเหนือจาก Node.js:

- **Java Development Kit (JDK) 8 หรือใหม่กว่า**. เพียงแค่ Java runtime ไม่เพียงพอ: การสร้างต้องใช้ไฟล์หัวของ JDK
- **Python 3** ซึ่งเครื่องมือสร้าง [node-gyp](https://github.com/nodejs/node-gyp) ใช้
- **ชุดเครื่องมือการสร้าง C++** สำหรับระบบปฏิบัติการของคุณ

## **การติดตั้งข้อกำหนดเบื้องต้น**

### **Windows**

1. ติดตั้ง [Node.js](https://nodejs.org/en/download) เวอร์ชัน 20 หรือใหม่กว่า
1. ติดตั้ง JDK เช่น [Eclipse Temurin](https://adoptium.net/) และตั้งค่าตัวแปรสภาพแวดล้อม `JAVA_HOME` ให้ชี้ไปยังโฟลเดอร์การติดตั้ง ตัวสร้างใช้ JDK ที่ `JAVA_HOME` ชี้ถึง
1. ติดตั้ง [Python 3](https://www.python.org/downloads/)
1. ติดตั้ง [Build Tools for Visual Studio 2022](https://aka.ms/vs/17/release/vs_BuildTools.exe) พร้อมเวิร์กโหลด **Desktop development with C++** คงส่วนประกอบเริ่มต้นของเวิร์กโหลด ซึ่งรวม **MSVC v143 - VS 2022 C++ x64/x86 build tools** และ **Windows 11 SDK** Visual Studio 2026 ไม่ทำงาน: เวอร์ชัน node-gyp ที่แพ็คเกจ `java` คอมไพล์ด้วยไม่รองรับ

### **Linux**

ติดตั้ง Node.js เวอร์ชัน 20 หรือใหม่กว่าจาก [nodejs.org](https://nodejs.org/en/download) หรือแหล่งแพ็คเกจของดิสจิวิชันของคุณ แล้วติดตั้ง JDK, Python 3, และชุดเครื่องมือ C++ สำหรับ Linux และ Ubuntu:

```bash
sudo apt-get update
sudo apt-get install -y default-jdk python3 build-essential
```

บน Linux ตัวสร้างจะค้นหา JDK ที่ติดตั้งไว้โดยอัตโนมัติ หากมีหลาย JDK ให้ตั้งค่า `JAVA_HOME` เป็น JDK ที่ต้องการใช้

### **macOS**

ติดตั้ง Node.js เวอร์ชัน 20 หรือใหม่กว่า, JDK, และ Xcode Command Line Tools ซึ่งรวม Python 3 และคอมไพเลอร์ C++ ดู [Troubleshooting Installation](/slides/th/nodejs-java/troubleshooting-installation/) สำหรับหมายเหตุเฉพาะ macOS

## **การติดตั้งจาก npm**

สร้างโฟลเดอร์โครงการและติดตั้งแพ็คเกจ:

```bash
mkdir hello-slides
cd hello-slides
npm init -y
npm install aspose.slides.via.java
```

npm จะดาวน์โหลด Aspose.Slides และคอมไพล์สะพาน `java` ซึ่งอาจใช้เวลาหลายนาที หากการคอมไพล์ล้มเหลว ให้ดูที่ [Troubleshooting Installation](/slides/th/nodejs-java/troubleshooting-installation/)

## **ตรวจสอบการติดตั้ง**

สร้างไฟล์ชื่อ *hello.js* ในโฟลเดอร์โครงการด้วยโค้ดต่อไปนี้ ไฟล์นี้จะสร้างพรีเซนเทชัน, เพิ่มกล่องข้อความในสไลด์แรก, แล้วบันทึกเป็น *hello.pptx*:

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

// Aspose.Slides ทำงานอยู่ในเครื่องเสมือน Java ที่ทำให้ Node.js ทำงานต่ออยู่ ดังนั้นจึงต้องจบกระบวนการอย่างชัดเจน.
process.exit(0);
```

เรียกสคริปต์:

```bash
node hello.js
```

หากพบไฟล์ *hello.pptx* ในโฟลเดอร์โครงการ การติดตั้งทำงานได้สำเร็จ เครื่องเสมือน Java ที่รัน Aspose.Slides จะทำให้ Node.js ไม่ออกจากการทำงานโดยอัตโนมัติ จึงต้องจบสคริปต์ด้วย `process.exit(0)` ดูรายละเอียดโค้ดที่ [Create Presentations](/slides/th/nodejs-java/create-presentation/)

## **การติดตั้งจากไฟล์ ZIP**

แพ็คเกจนี้มีให้ดาวน์โหลดเป็นไฟล์ ZIP ซึ่งมีเนื้อหาเดียวกับแพ็คเกจ npm เพื่อให้ติดตั้งจากไฟล์ ZIP ให้ทำตามขั้นตอน:

1. ติดตั้งข้อกำหนดเบื้องต้นตามระบบปฏิบัติการของคุณเช่นในขั้นตอนข้างต้น
1. ดาวน์โหลดไฟล์จาก [Aspose.Slides for Node.js via Java download page](https://releases.aspose.com/slides/th/nodejs-java/)
1. สร้างโฟลเดอร์โครงการ:

    ```bash
    mkdir hello-slides
    cd hello-slides
    npm init -y
    ```

1. แตกไฟล์ ZIP ลงในโฟลเดอร์ย่อยชื่อ *aspose.slides.via.java* ภายในโฟลเดอร์โครงการ เพื่อให้ไฟล์ *package.json* ของไฟล์ ZIP อยู่ที่ *hello-slides/aspose.slides.via.java/package.json*
1. ติดตั้งแพ็คเกจจากโฟลเดอร์นั้น:

    ```bash
    npm install ./aspose.slides.via.java
    ```

    npm จะติดตั้งสะพาน `java` ที่แพ็คเกจพึ่งพาและคอมไพล์เช่นเดียวกับแพ็คเกจ npm

1. ตรวจสอบการติดตั้งตามที่อธิบายใน [Check the Installation](#check-the-installation)

## **คำถามที่พบบ่อย**

**มีรุ่นฟรีหรือข้อจำกัดการทดลองใช้งานหรือไม่?**

ใช่ หากไม่มีไลเซนส์ Aspose.Slides จะทำงานในโหมดประเมินผล: จะเพิ่มลายน้ำการประเมินผลในทุกสไลด์ที่บันทึกและตัดข้อความจากพรีเซนเทชันออก เพื่อกำจัดข้อจำกัดเหล่านี้ให้ใช้ [license](/slides/th/nodejs-java/licensing/) ที่ถูกต้อง

**ทำไมสคริปต์ของฉันไม่หยุดทำงานหลังจากเสร็จสิ้น?**

แพ็คเกจ `java` จะเริ่มเครื่องเสมือน Java ภายในกระบวนการ Node.js และเครื่องเสมือนนั้นทำให้กระบวนการยังคงทำงานอยู่ ให้เรียก `process.exit` เมื่อสคริปต์ทำงานเสร็จแล้ว