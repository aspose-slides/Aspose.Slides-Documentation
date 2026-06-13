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
- Windows
- Linux
- macOS
- PowerPoint
- OpenDocument
- การนำเสนอ
- Node.js
- JavaScript
- Aspose.Slides
description: "เรียนรู้วิธีการติดตั้ง Aspose.Slides อย่างรวดเร็ว คู่มือทีละขั้นตอน ข้อกำหนดของระบบ และตัวอย่างโค้ด — เริ่มทำงานกับการนำเสนอ PowerPoint วันนี้!"
---
## **บทนำ**

Aspose.Slides for Node.js via Java เป็น API ที่ไม่ขึ้นกับแพลตฟอร์มและสามารถใช้ได้บนแพลตฟอร์มใดก็ได้ (Windows, Linux และ MacOS) ที่มีการติดตั้ง `Node.js` และสะพาน [`java`](https://www.npmjs.com/package/java) 

## **ติดตั้งจาก NPM**

คุณสามารถติดตั้ง Aspose.Slides for Node.js via Java ได้อย่างง่ายดายจาก [NPM](https://www.npmjs.com/).

1. สร้างโฟลเดอร์ใหม่และเริ่มโครงการใหม่โดยใช้คำสั่งต่อไปนี้:
	```
	$ npm init
	```
	
2. กรอกช่องชื่อเรื่องและเวอร์ชัน (ปล่อยช่องที่เหลือไว้ด้วยค่าเริ่มต้น)

3. ติดตั้ง Aspose.Slides for Node.js via Java โดยใช้คำสั่งต่อไปนี้:
	```
	$ npm install aspose.slides.via.java
	```

หากคุณพบปัญหาใด ๆ ระหว่างกระบวนการติดตั้ง โปรดดูบทความนี้ [article](/slides/th/nodejs-java/troubleshooting-installation/).

**ตัวอย่างการใช้งาน**:

สร้างไฟล์ชื่อ `hello.js` ในโฟลเดอร์โครงการของคุณและเพิ่มโค้ดตัวอย่างต่อไปนี้:

```javascript
var aspose = aspose || {};

aspose.slides = require("aspose.slides.via.java");

var pres = new aspose.slides.Presentation();

var slide = pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0));

slide.getShapes().get_Item(0).getTextFrame().setText("Slide Title Heading");

pres.save("out.pptx", aspose.slides.SaveFormat.Pptx)

console.log("Done");
```

## **ติดตั้งจากไฟล์ ZIP**

เพื่อทำการติดตั้งและใช้ Aspose.Slides for Node.js via Java จากไฟล์ ZIP ให้ทำตามขั้นตอนต่อไปนี้:

### **Windows**

1. ติดตั้ง JDK8 และกำหนดค่าตัวแปรสภาพแวดล้อม `JAVA_HOME`  
2. ติดตั้ง Node.js (https://nodejs.org/en/download/) และเพิ่ม node.exe ไปยัง `PATH`  
3. ติดตั้ง node-gyp  
4. ติดตั้ง Windows Build Tools  
5. ติดตั้ง [`java`](https://www.npmjs.com/package/java) bridge และรันคำสั่งเหล่านี้ใน Command Prompt ในฐานะผู้ดูแลระบบ:
	```bash
	$ mkdir aspose.slides.nodejs

	$ cd aspose.slides.nodejs

	$ npm install -g node-gyp

	$ npm install --global --production windows-build-tools

	$ npm install java
	```
6. [Download Aspose.Slides for Node.js via Java](https://releases.aspose.com/slides/th/nodejs-java/) and extract it to `aspose.slides.nodejs/node_modules/aspose.slides.via.java`  
7. สร้างไฟล์ชื่อ `hello.js` ในโฟลเดอร์ `aspose.slides.nodejs` โดยใช้โค้ดตัวอย่างต่อไปนี้:

	```javascript
	var aspose = aspose || {};

	aspose.slides = require("aspose.slides.via.java");

	var pres = new aspose.slides.Presentation();

	var slide = pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0));

	slide.getShapes().get_Item(0).getTextFrame().setText("Slide Title Heading");

	pres.save("out.pptx", aspose.slides.SaveFormat.Pptx)

	console.log("Done");
	```

8. ตอนนี้ให้รัน `node hello.js` ที่ command prompt เพื่อทำงาน

### **Linux**

1. ติดตั้ง Node.js (https://nodejs.org/en/download/)  
2. ติดตั้ง JDK8 สำหรับ Linux และกำหนดค่าตัวแปรสภาพแวดล้อม `JAVA_HOME`  
3. ติดตั้ง python 2.x  
4. ติดตั้ง [`java`](https://www.npmjs.com/package/java) bridge คุณสามารถรันคำสั่งเหล่านี้ใน terminal:
	```bash
	$ mkdir aspose.slides.nodejs

	$ cd aspose.slides.nodejs

	$ npm install java
	```
5. [Download Aspose.Slides for Node.js via Java](https://releases.aspose.com/slides/th/nodejs-java/) and extract it to `aspose.slides.nodejs/node_modules/aspose.slides.via.java`  
6. สร้างไฟล์ทดสอบชื่อ `hello.js` โดยใช้โค้ดตัวอย่างนี้ในโฟลเดอร์ `aspose.slides.nodejs`:

	```javascript
	var aspose = aspose || {};

	aspose.slides = require("aspose.slides.via.java");

	var pres = new aspose.slides.Presentation();

	var slide = pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0));

	slide.getShapes().get_Item(0).getTextFrame().setText("Slide Title Heading");

	pres.save("out.pptx", aspose.slides.SaveFormat.Pptx)

	console.log("Done");
	```
7. ตอนนี้ให้รัน `node hello.js` ที่ command prompt เพื่อทำงาน

### **Mac**

1. ติดตั้ง Node.js (https://nodejs.org/en/download/)  
2. ติดตั้ง JDK8 สำหรับ Mac และกำหนดค่าตัวแปรสภาพแวดล้อม `JAVA_HOME`  
3. แก้ไขส่วน JVMCapabilities ใน `/Library/Java/JavaVirtualMachines/jdk1.8.x_xxx.jdk/Contents/Info.plist` ด้วยสิทธิ์ราก `jdk1.8.x_xxx.jdk` ขึ้นอยู่กับเวอร์ชันของคุณ ให้มีลักษณะดังนี้:
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
4. ติดตั้ง python 2.x (หากยังไม่ได้ติดตั้ง)  
5. ติดตั้ง Xcode Command Line Tools  
6. ติดตั้ง [`java`](https://www.npmjs.com/package/java) bridge คุณสามารถรันคำสั่งด้านล่างนี้ใน terminal:
	```bash
	$ mkdir aspose.slides.nodejs
	 
	$ cd aspose.slides.nodejs
	 
	$ npm install java
	```
7. ดาวน์โหลด Aspose.Slides for Node.js via Java และแตกไฟล์ลงใน `aspose.slides.nodejs/node_modules/aspose.slides.via.java`  
8. สร้างไฟล์ทดสอบชื่อ `hello.js` โดยใช้โค้ดตัวอย่างนี้ในโฟลเดอร์ `aspose.slides.nodejs`:

	```javascript
	var aspose = aspose || {};

	aspose.slides = require("aspose.slides.via.java");

	var pres = new aspose.slides.Presentation();

	var slide = pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0));

	slide.getShapes().get_Item(0).getTextFrame().setText("Slide Title Heading");

	pres.save("out.pptx", aspose.slides.SaveFormat.Pptx)

	console.log("Done");
	```
9. ตอนนี้ให้รัน `node hello.js` ที่ command prompt เพื่อทำงาน


{{% alert color="primary" %}}

กรุณาใช้ [article](https://docs.aspose.com/slides/th/nodejs-java/troubleshooting-installation/) นี้หากคุณพบข้อผิดพลาดการคอมไพล์ระหว่างการติดตั้ง Aspose.Slides for Node.js via Java

{{% /alert %}}

## **FAQ**

**มีรุ่นฟรีหรือข้อจำกัดการทดลองใช้ฟรีหรือไม่?**

ใช่, โดยค่าเริ่มต้น Aspose.Slides จะทำงานในโหมดประเมินผล ซึ่งจะแสดงลายน้ำและอาจมีข้อจำกัดอื่น ๆ เพื่อเอาข้อจำกัดออก คุณต้องใช้ [license](/slides/th/nodejs-java/licensing/) ที่ถูกต้อง.