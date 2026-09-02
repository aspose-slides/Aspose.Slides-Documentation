---
title: แปลง PPT เป็น PPTX ใน Node.js
linktitle: PPT เป็น PPTX
type: docs
weight: 20
url: /th/nodejs-java/convert-ppt-to-pptx/
keywords:
- แปลง PowerPoint
- แปลงการนำเสนอ
- แปลงสไลด์
- แปลง PPT
- PPT เป็น PPTX
- บันทึก PPT เป็น PPTX
- ส่งออก PPT เป็น PPTX
- PowerPoint
- การนำเสนอ
- Node.js
- JavaScript
- Aspose.Slides
description: "แปลงไฟล์ PPT รุ่นเก่าเป็น PPTX ใน Node.js ด้วย Aspose.Slides. มีตัวอย่าง JavaScript สำหรับการแปลงไฟล์เดียวและแบบชุด, การจัดการข้อผิดพลาด, และหมายเหตุความแม่นยำ."
---
## **ภาพรวม**

PPT คือรูปแบบไบนารีเก่าของ PowerPoint, ส่วน PPTX คือรูปแบบ Open XML รุ่นใหม่. Aspose.Slides สำหรับ Node.js ผ่าน Java สามารถโหลดไฟล์ PPT แล้วบันทึกเป็น PPTX ได้โดยไม่ต้องใช้ Microsoft PowerPoint. บทความนี้แสดงวิธีแปลงไฟล์เดียวหรือไดเรกทอรีของไฟล์และอธิบายสิ่งที่ต้องตรวจสอบหลังการแปลง.

## **แปลงไฟล์ PPT เป็น PPTX**

โหลดไฟล์ต้นฉบับด้วยคลาส [Presentation](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/presentation/) แล้วเรียกใช้ [Presentation.save](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/presentation/#save) พร้อมกับ [SaveFormat.Pptx](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/saveformat/). บล็อก `finally` จะทำการปลดปล่อยการนำเสนอและทรัพยากรที่เกี่ยวข้อง.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// โหลดการนำเสนอ PPT รุ่นเก่า.
let presentation = new aspose.slides.Presentation("presentation.ppt");
try {
    // บันทึกการนำเสนอในรูปแบบ PPTX.
    presentation.save("presentation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

นามสกุลไฟล์ไม่ได้กำหนดรูปแบบผลลัพธ์โดยอัตโนมัติ; พารามิเตอร์ [SaveFormat.Pptx](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/saveformat/) เป็นผู้กำหนด. ให้เก็บเส้นทางไฟล์ต้นเข้าและออกแยกกันหากต้องการรักษาไฟล์ PPT ดั้งเดิมไว้.

## **แปลงหลายไฟล์ PPT**

ตัวอย่างต่อไปนี้จะแปลงไฟล์ `.ppt` ทุกไฟล์ในหนึ่งไดเรกทอรี. แต่ละไฟล์จะถูกประมวลผลแยกจากกัน, ดังนั้นการแปลงล้มเหลวหนึ่งไฟล์จะไม่ทำให้กระบวนการแบตช์ทั้งหมดหยุด.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const fs = require("fs");
const path = require("path");

const inputDirectory = "input";
const outputDirectory = "output";
fs.mkdirSync(outputDirectory, { recursive: true });

const inputFiles = fs.readdirSync(inputDirectory, { withFileTypes: true })
    .filter(entry => entry.isFile() && path.extname(entry.name).toLowerCase() === ".ppt")
    .map(entry => entry.name);

for (const fileName of inputFiles) {
    const inputPath = path.join(inputDirectory, fileName);
    const outputFileName = path.basename(fileName, path.extname(fileName)) + ".pptx";
    const outputPath = path.join(outputDirectory, outputFileName);
    let presentation = null;

    try {
        presentation = new aspose.slides.Presentation(inputPath);
        presentation.save(outputPath, aspose.slides.SaveFormat.Pptx);
        console.log("Converted: " + inputPath);
    } catch (error) {
        console.error("Failed: " + inputPath + " (" + error.message + ")");
    } finally {
        if (presentation !== null) {
            presentation.dispose();
        }
    }
}
```

สำหรับงานในสภาพการผลิต ให้บันทึกข้อผิดพลาดอย่างสมบูรณ์, ตัดสินใจว่าควรเขียนทับไฟล์ผลลัพธ์ที่มีอยู่หรือไม่, และเขียนชื่อไฟล์ที่ล้มเหลวไปยังคิวการลองใหม่หรือการตรวจสอบ. ไฟล์เสีย, ไฟล์ที่ป้องกันด้วยรหัสผ่านซึ่งเปิดโดยไม่มีรหัสที่ต้องการ, เส้นทางที่เข้าถึงไม่ได้, และเนื้อหาที่ไม่รองรับทั้งหมดสามารถทำให้การแปลงล้มเหลว. ดู [การนำเสนอที่ป้องกันด้วยรหัสผ่าน](/slides/th/nodejs-java/password-protected-presentation/) เพื่อโหลดไฟล์ที่เข้ารหัส.

## **ความแม่นยำและคุณลักษณะเดิม**

การแปลงโดยปกติจะคงสไลด์, มาสเตอร์, การจัดวาง, ข้อความ, รูปทรง, รูปภาพ, ตาราง, และแผนภูมิ. อย่างไรก็ตาม PPT และ PPTX ไม่ได้แสดงคุณลักษณะทุกอย่างในแบบเดียวกันอย่างสมบูรณ์. คุณลักษณะเดิมที่ไม่มีเทียบเท่าใน PPTX หรือไม่รองรับโดยไลบรารีอาจถูกทำให้เป็นมาตรฐาน, ลบออก, หรือแสดงแตกต่างกัน.

ตรวจสอบไฟล์ที่แปลงแล้วเมื่อมีแอนิเมชัน, การเปลี่ยนฉาก, วัตถุ OLE ที่ฝังหรือเชื่อมโยง, คอนโทรล ActiveX, สื่อที่ฝัง, ฟอนต์ที่ไม่ทั่วไป, หรือแมโคร VBA. ไฟล์ PPTX ธรรมดไม่ได้เป็นรูปแบบที่รองรับแมโคร, ดังนั้นให้ใช้กระบวนการทำงานที่รองรับแมโครเมื่อจำเป็นต้องให้ VBA อยู่. นอกจากนี้ให้ตรวจสอบว่าฟอนต์ที่จำเป็นและทรัพยากรภายนอกพร้อมในสภาพแวดล้อมที่จะแสดงหรือเรนเดอร์การนำเสนอที่แปลงแล้ว.

สำหรับเอกสารสำคัญ, ให้เปิดไฟล์ PPTX ที่สร้างขึ้นใหม่โดยโปรแกรมและตรวจสอบจำนวนสไลด์และเนื้อหาที่สำคัญ, จากนั้นเปรียบเทียบรูปลักษณ์และพฤติกรรมการสไลด์โชว์ในโปรแกรมแสดงที่ต้องการ. อย่าเพิ่งถือว่าการเรียก [Presentation.save](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/presentation/#save) ที่สำเร็จเป็นหลักฐานว่าทุกรายละเอียดเดิมมีการแสดงผลเป็น PPTX อย่างแม่นยำ.

## **เมื่อควรใช้ PPTX**

ใช้ PPTX เมื่อการนำเสนอจะถูกแก้ไขในเวอร์ชัน PowerPoint ปัจจุบัน, แลกเปลี่ยนกับระบบที่ทำงานกับแพ็กเกจ Open XML, หรือเก็บในรูปแบบที่ง่ายต่อการตรวจสอบและกู้คืนมากกว่ารูปแบบไบนารี PPT เก่า. เก็บไฟล์ PPT ดั้งเดิมเป็นสำเนาสำรองหรือสำเนาการกู้คืนจนกว่าการนำเสนอที่แปลงแล้วจะผ่านการตรวจสอบความแม่นยำของคุณ.

หากต้องการ PDF, HTML, รูปภาพ, XPS หรือรูปแบบผลลัพธ์อื่น, ให้ใช้แนวทางตามรูปแบบใน [แปลงการนำเสนอเป็นหลายรูปแบบ](/slides/th/nodejs-java/convert-presentation/) แทนการสมมติว่าทุกเป้าหมายจะคงคุณลักษณะ PowerPoint ที่แก้ไขได้.

## **ตัวแปลงออนไลน์**

สำหรับไฟล์เป็นครั้งคราวหรือการเปรียบเทียบอย่างรวดเร็ว, คุณสามารถใช้ [ตัวแปลง PPT เป็น PPTX ออนไลน์](https://products.aspose.app/slides/th/conversion/ppt-to-pptx). สำหรับการแปลงที่ทำซ้ำ, การประมวลผลเป็นชุด, หรือการจัดการข้อผิดพลาดระดับแอปพลิเคชัน, ให้ใช้ Node.js ผ่าน Java API.

## **บทความที่เกี่ยวข้อง**

- [PPT กับ PPTX](/slides/th/nodejs-java/ppt-vs-pptx/)
- [บันทึกการนำเสนอใน Node.js](/slides/th/nodejs-java/save-presentation/)
- [รูปแบบไฟล์ที่รองรับ](/slides/th/nodejs-java/supported-file-formats/)
- [เปิดการนำเสนอใน Node.js](/slides/th/nodejs-java/open-presentation/)

## **FAQ**

**ฉันสามารถแปลง PPT เป็น PPTX ได้โดยไม่ต้องติดตั้ง Microsoft PowerPoint หรือไม่?**

ได้. Aspose.Slides สำหรับ Node.js ผ่าน Java โหลดและบันทึกไฟล์การนำเสนอได้โดยไม่ต้องอ้างอิง Microsoft PowerPoint.

**การแปลง PPT เป็น PPTX จะคงเนื้อหาทั้งหมดอย่างสมบูรณ์หรือไม่?**

มันจะคงเนื้อหาการนำเสนอทั่วไปไว้, แต่ความแม่นยำอย่างเต็มที่ไม่รับประกันสำหรับทุกคุณลักษณะเดิมหรือที่ไม่รองรับ. ควรตรวจสอบไฟล์ที่สร้างเมื่อมีแมโคร, วัตถุ OLE หรือ ActiveX, สื่อ, แอนิเมชันพิเศษ, หรือฟอนต์ที่ไม่ทั่วไป.

**ฉันสามารถแปลงไฟล์ PPT ที่ป้องกันด้วยรหัสผ่านได้หรือไม่?**

ได้, หากคุณระบุรหัสผ่านที่ถูกต้องเมื่อโหลดไฟล์. รหัสผ่านที่หายไปหรือไม่ถูกต้องจะทำให้การโหลดล้มเหลว.

**ควรลบไฟล์ PPT หลังจากการแปลงหรือไม่?**

ให้เก็บไฟล์ต้นฉบับไว้จนกว่าคุณจะตรวจสอบ PPTX ในโปรแกรมแสดงและกระบวนการทำงานที่สำคัญสำหรับคุณ. สิ่งนี้ให้สำเนาสำรองหากคุณลักษณะเดิมแปลงแตกต่าง.