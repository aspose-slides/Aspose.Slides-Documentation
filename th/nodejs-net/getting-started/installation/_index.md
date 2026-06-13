---
title: การติดตั้ง
type: docs
weight: 70
url: /th/nodejs-net/installation/
keywords:
- ดาวน์โหลด Aspose.Slides
- ติดตั้ง Aspose.Slides
- การติดตั้ง Aspose.Slides
- Windows
- macOS
- Linux
- JavaScript
- Node.js
description: "ติดตั้ง Aspose.Slides for Node.js via .NET ใน Windows, Linux หรือ macOS"
---
Aspose.Slides for Node.js via .NET เป็น API ที่ไม่ขึ้นกับแพลตฟอร์มและสามารถใช้ได้บนทุกแพลตฟอร์ม (Windows, Linux และ MacOS) ที่ติดตั้ง `Node.js` และ bridge `edge-js` ไปแล้ว.

## **ติดตั้งจาก NPM**

คุณสามารถติดตั้ง Aspose.Slides for Node.js via .NET จาก [NPM](https://www.npmjs.com/) ผ่านคำสั่งต่อไปนี้:
```
$ npm install aspose.slides.via.net
```
หากคุณพบปัญหาใด ๆ ระหว่างกระบวนการติดตั้ง โปรดดูที่ https://www.npmjs.com/package/edge-js.

## **ติดตั้งจากไฟล์ ZIP**

เพื่อทำการติดตั้งและใช้ Aspose.Slides for Node.js via .NET จากไฟล์ ZIP ให้ทำตามคำแนะนำต่อไปนี้แทน:

### **Windows**

1. ติดตั้ง .NET6 หรือรุ่นที่สูงกว่า.
1. ติดตั้ง Node.js (https://nodejs.org/en/download/) และเพิ่ม node.exe ไปยัง `PATH`.
1. ติดตั้ง edge-js.
```
$ mkdir aspose.slides.nodejs.net

$ cd aspose.slides.nodejs.net

$ npm install -g edge-js
```
6. [ดาวน์โหลด Aspose.Slides for Node.js via .NET](https://releases.aspose.com/slides/th/nodejs-net/) และแตกไฟล์ไปยัง `aspose.slides.nodejs/node_modules/aspose.slides.via.net`.
7. สร้างไฟล์ชื่อ `hello.js` ในโฟลเดอร์ `aspose.slides.nodejs.net` โดยใช้โค้ดตัวอย่างต่อไปนี้:
```javascript
// นำเข้าโมดูล Aspose.Slides สำหรับการจัดการไฟล์ PowerPoint
const asposeSlides = require('aspose.slides.via.net');

// เพิ่มคลาสที่จำเป็นจาก asposeSlides
const { Presentation, SaveFormat, PdfOptions } = asposeSlides;

const fs = require('fs');
if (!fs.existsSync("out")) fs.mkdirSync("out");

// สร้างและบันทึกการนำเสนอเปล่าเพื่อสาธิตการทำงานพื้นฐาน
function createEmptyPresentation() {
	
    // กำหนดค่าเริ่มต้นการนำเสนอเปล่าใหม่
    var emptyPresentation = new Presentation();
    
    // บันทึกการนำเสนอเปล่าเป็นรูปแบบ PPTX
    emptyPresentation.save("out/emptyPresentation.pptx", SaveFormat.Pptx);
    
    // ปล่อยทรัพยากรที่เกี่ยวข้องกับการนำเสนอ
    emptyPresentation.dispose();
}

createEmptyPresentation(); // เรียกใช้ฟังก์ชันเพื่อสร้างการนำเสนอเปล่า
```
8. ตอนนี้รัน `node hello.js` ที่ command prompt เพื่อเรียกใช้งาน.

### **Linux**

1. ติดตั้ง .NET6 หรือรุ่นที่สูงกว่า.
1. ติดตั้ง Node.js (https://nodejs.org/en/download/) และเพิ่ม node.exe ไปยัง `PATH`.
1. ติดตั้ง edge-js.
```
$ mkdir aspose.slides.nodejs.net

$ cd aspose.slides.nodejs.net

$ npm install edge-js
```
5. [ดาวน์โหลด Aspose.Slides for Node.js via Java](https://releases.aspose.com/slides/th/nodejs-net/) และแตกไฟล์ไปยัง `aspose.slides.nodejs/node_modules/aspose.slides.via.net`.
6. สร้างไฟล์ทดสอบชื่อ `hello.js` โดยใช้โค้ดตัวอย่างนี้ในโฟลเดอร์ `aspose.slides.nodejs.net`:
```javascript
// นำเข้าโมดูล Aspose.Slides สำหรับการจัดการไฟล์ PowerPoint
const asposeSlides = require('aspose.slides.via.net');

// เพิ่มคลาสที่จำเป็นจาก asposeSlides
const { Presentation, SaveFormat, PdfOptions } = asposeSlides;

const fs = require('fs');
if (!fs.existsSync("out")) fs.mkdirSync("out");

// สร้างและบันทึกการนำเสนอเปล่าเพื่อสาธิตการทำงานพื้นฐาน
function createEmptyPresentation() {
	
    // กำหนดค่าเริ่มต้นการนำเสนอเปล่าใหม่
    var emptyPresentation = new Presentation();
    
    // บันทึกการนำเสนอเปล่าในรูปแบบ PPTX
    emptyPresentation.save("out/emptyPresentation.pptx", SaveFormat.Pptx);
    
    // ปล่อยทรัพยากรที่เกี่ยวข้องกับการนำเสนอ
    emptyPresentation.dispose();
}

createEmptyPresentation(); // เรียกใช้ฟังก์ชันเพื่อสร้างการนำเสนอเปล่า
```
7. ตอนนี้รัน `node hello.js` ที่ command prompt เพื่อเรียกใช้งาน.

### **Mac**

1. ติดตั้ง .NET6 หรือรุ่นที่สูงกว่า.
1. ติดตั้ง Node.js (https://nodejs.org/en/download/) และเพิ่ม node.exe ไปยัง `PATH`.
1. ติดตั้ง edge-js.

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
9. ตอนนี้รัน `node hello.js` ที่ command prompt เพื่อเรียกใช้งาน.