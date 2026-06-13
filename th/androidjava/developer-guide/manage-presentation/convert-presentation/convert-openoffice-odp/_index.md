---
title: แปลงงานนำเสนอ OpenDocument บน Android
linktitle: แปลง OpenDocument
type: docs
weight: 10
url: /th/androidjava/convert-openoffice-odp/
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
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides สำหรับ Android ทำให้คุณสามารถแปลง ODP เป็น PDF, HTML และรูปแบบภาพต่าง ๆ ได้อย่างง่ายดาย เพิ่มประสิทธิภาพให้แอป Java ของคุณด้วยการแปลงงานนำเสนอที่รวดเร็วและแม่นยำ"
---
## **บทนำ**

[**Aspose.Slides API**](https://products.aspose.com/slides/th/androidjava/) ช่วยให้คุณสามารถแปลงงานนำเสนอ OpenDocument (ODP) ไปยังหลายรูปแบบ (HTML, PDF, TIFF, SWF, XPS ฯลฯ) API ที่ใช้แปลงไฟล์ ODP ไปยังรูปแบบเอกสารอื่นเป็น APIเดียวกันที่ใช้สำหรับการแปลง PowerPoint (PPT และ PPTX) 

ตัวอย่างเช่น หากคุณต้องการแปลงงานนำเสนอ ODP เป็น PDF คุณสามารถทำได้ดังต่อไปนี้:

```java
Presentation presentation = null;
try {
    presentation = new Presentation("pres.odp");
    presentation.save("pres.pdf", SaveFormat.Pdf);
    
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

## **คำถามที่พบบ่อย**

**ถ้าการจัดรูปแบบของไฟล์ ODP ของฉันเปลี่ยนแปลงหลังการแปลงจะเป็นอย่างไร?**

ODP และ PowerPoint ใช้โมเดลการนำเสนอที่แตกต่างกัน และบางองค์ประกอบ เช่น ตาราง แบบอักษรที่กำหนดเอง หรือสไตล์การเติมสี อาจไม่แสดงผลอย่างตรงกัน แนะนำให้ตรวจสอบผลลัพธ์และปรับแต่งการจัดวางหรือการจัดรูปแบบในโค้ดหากจำเป็น

**ฉันต้องติดตั้ง OpenOffice หรือ LibreOffice เพื่อใช้การแปลง ODP หรือไม่?**

ไม่, Aspose.Slides เป็นไลบรารีแบบสแตนด์อโลนและไม่จำเป็นต้องติดตั้ง OpenOffice หรือ LibreOffice บนระบบของคุณ

**ฉันสามารถกำหนดรูปแบบผลลัพธ์ระหว่างการแปลง ODP (เช่น ตั้งค่าตัวเลือก PDF) ได้หรือไม่?**

ใช่, Aspose.Slides มีตัวเลือกหลากหลายสำหรับการปรับแต่งผลลัพธ์ ตัวอย่างเช่น เมื่อบันทึกเป็น PDF คุณสามารถควบคุมการบีบอัด คุณภาพภาพ การเรนเดอร์ข้อความ และอื่น ๆ ผ่านคลาส [PdfOptions](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/pdfoptions/)

**Aspose.Slides เหมาะสำหรับการประมวลผล ODP บนเซิร์ฟเวอร์หรือคลาวด์หรือไม่?**

แน่นอน. Aspose.Slides ถูกออกแบบให้ทำงานได้ทั้งในสภาพแวดล้อมเดสก์ท็อปและเซิร์ฟเวอร์รวมถึงแพลตฟอร์มคลาวด์เช่น Azure, AWS, และคอนเทนเนอร์ Docker โดยไม่ต้องพึ่งพา UI ใด ๆ