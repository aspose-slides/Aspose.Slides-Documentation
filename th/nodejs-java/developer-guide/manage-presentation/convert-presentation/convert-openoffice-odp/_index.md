---
title: แปลงงานนำเสนอ OpenDocument ด้วย JavaScript
linktitle: แปลง OpenDocument
type: docs
weight: 10
url: /th/nodejs-java/convert-openoffice-odp/
keywords:
- แปลง ODP
- ODP เป็นรูปภาพ
- ODP เป็น GIF
- ODP เป็น HTML
- ODP เป็น JPG
- ODP เป็น MD
- ODP เป็น PDF
- ODP เป็น PNG
- ODP เป็น PPT
- ODP เป็น PPTX
- ODP เป็น TIFF
- ODP เป็นวิดีโอ
- ODP เป็น Word
- ODP เป็น XPS
- OpenDocument
- การนำเสนอ
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js ช่วยให้คุณแปลง ODP เป็น PDF, HTML และรูปแบบภาพได้อย่างง่ายดาย เพิ่มประสิทธิภาพให้แอปของคุณด้วยการแปลงงานนำเสนอที่เร็วและแม่นยำ."
---
[**Aspose.Slides API**](https://products.aspose.com/slides/th/nodejs-java/) ช่วยให้คุณแปลงงานนำเสนอ OpenDocument (ODP) เป็นหลายรูปแบบ (HTML, PDF, TIFF, SWF, XPS เป็นต้น) API ที่ใช้แปลงไฟล์ ODP เป็นรูปแบบเอกสารอื่นนั้นเหมือนกับที่ใช้สำหรับการแปลง PowerPoint (PPT และ PPTX) 

ต่อไปเป็นตัวอย่าง หากคุณต้องการแปลงงานนำเสนอ ODP เป็น PDF คุณสามารถทำได้ดังนี้:

```js
let presentation = null;
try {
  presentation = new aspose.slides.Presentation("presentation.odp");
  presentation.save("presentation.pdf", aspose.slides.SaveFormat.Pdf);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

## **FAQ**

**หากฟอร์แมตของไฟล์ ODP ของฉันเปลี่ยนแปลงหลังจากการแปลงจะเป็นอย่างไร?**

ODP และ PowerPoint ใช้โมเดลการนำเสนอที่แตกต่างกัน และบางองค์ประกอบ เช่น ตาราง ฟอนต์แบบกำหนดเอง หรือสไตล์การเติมสี อาจไม่แสดงผลตรงกันอย่างสมบูรณ์ แนะนำให้ตรวจสอบผลลัพธ์และปรับเลย์เอาต์หรือฟอร์แมตในโค้ดหากจำเป็น

**ฉันต้องติดตั้ง OpenOffice หรือ LibreOffice เพื่อใช้การแปลง ODP หรือไม่?**

ไม่, Aspose.Slides เป็นไลบรารีที่ทำงานแบบอิสระและไม่ต้องการให้มีการติดตั้ง OpenOffice หรือ LibreOffice บนระบบของคุณ

**ฉันสามารถปรับแต่งรูปแบบผลลัพธ์ระหว่างการแปลง ODP ได้หรือไม่ (เช่น ตั้งค่าตัวเลือก PDF)?**

ใช่, Aspose.Slides มีตัวเลือกหลากหลายสำหรับการปรับแต่งผลลัพธ์ ตัวอย่างเช่น เมื่อบันทึกเป็น PDF คุณสามารถควบคุมการบีบอัด คุณภาพของภาพ การเรนเดอร์ข้อความ และอื่น ๆ ผ่านคลาส [PdfOptions](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/pdfoptions/)

**Aspose.Slides เหมาะสำหรับการประมวลผล ODP ฝั่งเซิร์ฟเวอร์หรือบนคลาวด์หรือไม่?**

แน่นอน. Aspose.Slides ถูกออกแบบให้ทำงานได้ทั้งในสภาพแวดล้อมเดสก์ท็อปและเซิร์ฟเวอร์ รวมถึงแพลตฟอร์มคลาวด์เช่น Azure, AWS และคอนเทนเนอร์ Docker โดยไม่มีการพึ่งพา UI ใด ๆ