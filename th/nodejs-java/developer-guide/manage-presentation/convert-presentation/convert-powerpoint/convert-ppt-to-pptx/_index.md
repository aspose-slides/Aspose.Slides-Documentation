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
- ส่งออก PPT ไปเป็น PPTX
- PowerPoint
- การนำเสนอ
- Node.js
- JavaScript
- Aspose.Slides
description: "แปลงไฟล์ PPT รุ่นเก่าเป็น PPTX ใน Node.js ด้วย Aspose.Slides. รวมตัวอย่าง JavaScript สำหรับการแปลงไฟล์เดี่ยวและแบบกลุ่ม, การจัดการข้อผิดพลาด, และหมายเหตุเกี่ยวกับความแม่นยำ."
---
## **ภาพรวม**

PPT คือรูปแบบไฟล์ไบนารีเดิมของ PowerPoint ในขณะที่ PPTX คือรูปแบบ Open XML ใหม่กว่า Aspose.Slides สำหรับ Node.js ผ่าน Java สามารถโหลดไฟล์ PPT และบันทึกเป็น PPTX ได้โดยไม่ต้องใช้ Microsoft PowerPoint บทความนี้แสดงวิธีแปลงไฟล์เดียวหรือไดเรกทอรีของไฟล์และอธิบายสิ่งที่ต้องตรวจสอบหลังการแปลง

## **แปลงไฟล์ PPT เป็น PPTX**

โหลดไฟล์ต้นฉบับด้วยคลาส [Presentation](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/presentation/) แล้วเรียก [Presentation.save](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/presentation/#save) พร้อมกับ [SaveFormat.Pptx](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/saveformat/) บล็อค `finally` จะทำการปลดปล่อยการนำเสนอและคืนทรัพยากรของมัน

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// โหลดการนำเสนอ PPT รุ่นเก่า
let presentation = new aspose.slides.Presentation("presentation.ppt");
try {
    // บันทึกการนำเสนอในรูปแบบ PPTX
    presentation.save("presentation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

นามสกุลไฟล์ไม่ได้กำหนดรูปแบบผลลัพธ์โดยอัตโนมัติ; การระบุ [SaveFormat.Pptx](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/saveformat/) เป็นตัวกำหนด หากคุณต้องการเก็บไฟล์ PPT ต้นฉบับไว้ให้ทำให้เส้นทางอินพุตและเอาต์พุตแตกต่างกัน

## **แปลงไฟล์ PPT หลายไฟล์**

ตัวอย่างต่อไปนี้จะแปลงไฟล์ `.ppt` ทุกไฟล์ในไดเรกทอรีหนึ่งๆ แต่ละไฟล์จะถูกประมวลผลอย่างอิสระ ดังนั้นการแปลงที่ล้มเหลวหนึ่งไฟล์จะไม่ทำให้ชุดอื่นหยุดทำงาน

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

สำหรับงานในสภาพแวดล้อมการผลิต ควรบันทึกข้อผิดพลาดทั้งหมด พิจารณาว่าไฟล์ผลลัพธ์ที่มีอยู่สามารถเขียนทับได้หรือไม่ และบันทึกชื่อไฟล์ที่ล้มเหลวไปยังคิวลองใหม่หรือคิวตรวจสอบ ไฟล์ที่เสียหาย ไฟล์ที่ป้องกันด้วยรหัสผ่านแต่เปิดโดยไม่มีรหัสที่ถูกต้อง เส้นทางที่เข้าถึงไม่ได้ และเนื้อหาที่ไม่รองรับทั้งหมดอาจทำให้การแปลงล้มเหลว ดู [Password-Protected Presentations](/nodejs-java/password-protected-presentation/) เพื่อโหลดไฟล์ที่เข้ารหัส

## **ความแม่นยำและคุณลักษณะเดิม**

การแปลงโดยทั่วไปจะคงสไลด์ มาสเตอร์ รูปแบบ โครงร่าง ข้อความ รูปร่าง รูปภาพ ตาราง และแผนภูมิไว้ อย่างไรก็ตาม PPT และ PPTX ไม่ได้แสดงคุณลักษณะทั้งหมดในลักษณะเดียวกัน ฟีเจอร์เดิมที่ไม่มีเทียบเท่าใน PPTX หรือไม่ได้รับการสนับสนุนจากไลบรารีอาจถูกทำให้เป็นมาตรฐาน เพิกเฉย หรือแสดงแตกต่างกัน

ตรวจสอบไฟล์ที่แปลงเมื่อมีแอนิเมชัน การเปลี่ยนฉาก วัตถุ OLE ฝังหรือเชื่อมโยง ควบคุม ActiveX สื่อฝัง ฟอนต์ที่ไม่ทั่วไป หรือมาโคร VBA ไฟล์ PPTX ธรรมดาไม่ได้เป็นรูปแบบที่รองรับมาโคร ดังนั้นควรใช้กระบวนการทำงานที่รองรับมาโครเมื่อจำเป็นต้องให้ VBA ยังใช้งานได้ นอกจากนี้ควรตรวจสอบว่าฟอนต์ที่ต้องการและทรัพยากรภายนอกมีอยู่ในสภาพแวดล้อมที่จะแสดงหรือเรนเดอร์การนำเสนอที่แปลงแล้ว

สำหรับเอกสารที่สำคัญ ให้เปิดไฟล์ PPTX ที่สร้างขึ้นใหม่ด้วยโปรแกรมอีกครั้งและตรวจสอบจำนวนสไลด์หลักและเนื้อหา แล้วเปรียบเทียบลักษณะการแสดงผลและพฤติกรรมการสไลด์โชว์ในโปรแกรมที่ตั้งใจใช้ อย่าพิจารณาการเรียก [Presentation.save](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/presentation/#save) ที่สำเร็จเป็นหลักฐานว่าฟีเจอร์เดิมทุกอย่างมีการแสดงผลใน PPTX อย่างสมบูรณ์

## **เมื่อควรใช้ PPTX**

ใช้ PPTX เมื่อการนำเสนอจะถูกแก้ไขในเวอร์ชัน PowerPoint ปัจจุบัน แลกเปลี่ยนกับระบบที่ทำงานกับแพ็กเกจ Open XML หรือเก็บในรูปแบบที่ตรวจสอบและกู้คืนได้ง่ายกว่ารูปแบบไบนารี PPT เดิม เก็บไฟล์ PPT ต้นฉบับเป็นสำเนาสำรองหรือสำเนาการกู้คืนจนกว่าการนำเสนอที่แปลงแล้วจะผ่านการตรวจสอบความแม่นยำของคุณ

หากต้องการ PDF, HTML, รูปภาพ, XPS หรือรูปแบบผลลัพธ์อื่น ให้ใช้แนวทางตามรูปแบบใน [Convert Presentations to Multiple Formats](/nodejs-java/convert-presentation/) แทนการสันนิษฐานว่าทุกเป้าหมายจะคงคุณสมบัติการแก้ไขของ PowerPoint ไว้

## **เครื่องมือแปลงออนไลน์**

สำหรับไฟล์บางครั้งหรือการเปรียบเทียบอย่างรวดเร็ว คุณสามารถใช้ [online PPT to PPTX converter](https://products.aspose.app/slides/th/conversion/ppt-to-pptx) ได้ สำหรับการแปลงที่ทำซ้ำอย่างต่อเนื่อง การประมวลผลเป็นชุด หรือการจัดการข้อผิดพลาดระดับแอปพลิเคชัน ให้ใช้ API ของ Node.js ผ่าน Java

## **บทความที่เกี่ยวข้อง**

- [PPT กับ PPTX](/nodejs-java/ppt-vs-pptx/)
- [บันทึกการนำเสนอใน Node.js](/nodejs-java/save-presentation/)
- [รูปแบบไฟล์ที่รองรับ](/nodejs-java/supported-file-formats/)
- [เปิดการนำเสนอใน Node.js](/nodejs-java/open-presentation/)

## **คำถามที่พบบ่อย**

**ฉันสามารถแปลง PPT เป็น PPTX ได้โดยไม่ต้องติดตั้ง Microsoft PowerPoint หรือไม่?**

ใช่ Aspose.Slides สำหรับ Node.js ผ่าน Java สามารถโหลดและบันทึกไฟล์การนำเสนอได้โดยไม่ต้องอาศัย Microsoft PowerPoint

**การแปลงจาก PPT เป็น PPTX จะคงเนื้อหาทั้งหมดไว้โดยตรงหรือไม่?**

มันจะคงเนื้อหาการนำเสนอทั่วไปไว้ได้ แต่ความแม่นยำแบบเต็มรูปแบบไม่สามารถรับประกันได้สำหรับทุกฟีเจอร์เดิมหรือฟีเจอร์ที่ไม่ได้รับการสนับสนุน ควรตรวจสอบไฟล์ที่สร้างเมื่อมีมาโคร OLE หรือวัตถุ ActiveX สื่อ แอนิเมชันพิเศษ หรือฟอนต์ที่ไม่ทั่วไป

**ฉันสามารถแปลงไฟล์ PPT ที่ป้องกันด้วยรหัสผ่านได้หรือไม่?**

ได้ หากคุณระบุรหัสผ่านที่ถูกต้องเมื่อโหลดไฟล์ การไม่มีรหัสผ่านหรือรหัสผ่านไม่ถูกต้องจะทำให้การโหลดล้มเหลว

**ควรลบไฟล์ PPT หลังจากการแปลงหรือไม่?**

เก็บไฟล์ต้นฉบับไว้จนกว่าคุณจะตรวจสอบ PPTX ในโปรแกรมดูและกระบวนการทำงานที่สำคัญสำหรับคุณ ซึ่งจะเป็นสำเนาสำรองหากฟีเจอร์เดิมแปลงได้แตกต่างกัน