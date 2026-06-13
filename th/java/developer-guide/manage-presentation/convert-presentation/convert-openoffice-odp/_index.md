---
title: แปลงงานนำเสนอ OpenDocument ใน Java
linktitle: แปลง OpenDocument
type: docs
weight: 10
url: /th/java/convert-openoffice-odp/
keywords:
- แปลง ODP
- ODP เป็นภาพ
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
- Java
- Aspose.Slides
description: "Aspose.Slides สำหรับ Java ช่วยให้คุณแปลง ODP เป็น PDF, HTML และรูปภาพได้อย่างง่ายดาย เพิ่มประสิทธิภาพให้แอป Java ของคุณด้วยการแปลงงานนำเสนอที่เร็วและแม่นยำ"
---
## **บทนำ**

[**Aspose.Slides API**](https://products.aspose.com/slides/th/java/) ช่วยให้คุณแปลงงานนำเสนอ OpenDocument (ODP) ไปยังรูปแบบต่าง ๆ มากมาย (HTML, PDF, TIFF, SWF, XPS ฯลฯ). API ที่ใช้ในการแปลงไฟล์ ODP ไปยังรูปแบบเอกสารอื่นนั้นเป็น APIเดียวกับที่ใช้สำหรับการแปลง PowerPoint (PPT และ PPTX).

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

## **งานนำเสนอ OpenDocument ในแอปพลิเคชันต่าง ๆ**

เมื่อไฟล์งานนำเสนอ OpenDocument (ODP) ถูกเปิดใน PowerPoint อาจไม่คงรูปแบบดั้งเดิมจากแอปพลิเคชันที่สร้างขึ้น สิ่งนี้เกิดขึ้นเนื่องจากแอปงานนำเสนอ OpenDocument และแอป PowerPoint มีคุณลักษณะและการแสดงผลที่แตกต่างกัน

ต่อไปนี้คือความแตกต่างบางประการ:

- ใน PowerPoint ตารางมักจะถูกเรนเดอร์เป็นสุดท้ายและอาจทับรูปทรงอื่น ๆ โดยไม่คำนึงถึงลำดับบนสไลด์ ODP
- การเติมรูปภาพสำหรับตาราง ODP ไม่รองรับใน PowerPoint
- การหมุนข้อความในแนวตั้ง (270°, ซ้อนกัน) และการจัดแนวแบบกระจาย ไม่รองรับใน LibreOffice/OpenOffice Impress
- การเติมรูปภาพ, การเติมแบบไล่สี, และการเติมแบบลวดลายสำหรับข้อความ ไม่รองรับใน LibreOffice/OpenOffice Impress

MS PowerPoint และ LibreOffice/OpenOffice Impress ยังจัดการรายการแตกต่างกัน ไฟล์ ODP ที่สร้างใน PowerPoint อาจไม่แสดงอย่างถูกต้องใน LibreOffice/OpenOffice Impress และในทางกลับกัน

รูปภาพด้านล่างแสดงว่ารายการจะปรากฏอย่างไรเมื่อสร้างใน LibreOffice Impress:

![ตัวอย่างรายการ ODP](odp-list-example.png)

Aspose.Slides บันทึกรายการ ODP อย่างที่ทำให้แน่ใจว่าจะแสดงอย่างถูกต้องใน LibreOffice/OpenOffice Impress.

[Learn more about the OpenDocument format and PowerPoint](https://support.microsoft.com/en-us/office/use-powerpoint-to-save-or-open-a-presentation-in-the-opendocument-presentation-odp-format-94805e84-1b09-4c98-a8b5-0da2a52242a0).

## **คำถามที่พบบ่อย**

**ถ้ารูปแบบของไฟล์ ODP ของฉันเปลี่ยนแปลงหลังการแปลงจะทำอย่างไร?**

ODP และ PowerPoint ใช้โมเดลการนำเสนอที่แตกต่างกัน และบางองค์ประกอบ—เช่น ตาราง, ฟอนต์กำหนดเอง, หรือสไตล์การเติม—อาจไม่แสดงผลตรงกันทั้งหมด แนะนำให้ตรวจสอบผลลัพธ์และปรับเค้าโครงหรือรูปแบบในโค้ดหากจำเป็น.

**ฉันต้องติดตั้ง OpenOffice หรือ LibreOffice เพื่อใช้การแปลง ODP หรือไม่?**

ไม่, Aspose.Slides เป็นไลบรารีแบบสแตนด์อโลนและไม่จำเป็นต้องติดตั้ง OpenOffice หรือ LibreOffice บนระบบของคุณ.

**ฉันสามารถปรับแต่งรูปแบบผลลัพธ์ระหว่างการแปลง ODP (เช่น ตั้งค่าตัวเลือก PDF) ได้หรือไม่?**

ใช่, Aspose.Slides มีตัวเลือกที่หลากหลายสำหรับการปรับแต่งผลลัพธ์ ตัวอย่างเช่น เมื่อบันทึกเป็น PDF คุณสามารถควบคุมการบีบอัด, คุณภาพภาพ, การเรนเดอร์ข้อความ, และอื่น ๆ ผ่านคลาส [PdfOptions](https://reference.aspose.com/slides/th/java/com.aspose.slides/pdfoptions/).

**Aspose.Slides เหมาะสมสำหรับการประมวลผล ODP บนเซิร์ฟเวอร์หรือคลาวด์หรือไม่?**

แน่นอน. Aspose.Slides ถูกออกแบบให้ทำงานได้ทั้งในสภาพแวดล้อมเดสก์ท็อปและเซิร์ฟเวอร์ รวมถึงแพลตฟอร์มคลาวด์เช่น Azure, AWS, และคอนเทนเนอร์ Docker โดยไม่ต้องพึ่งพา UI ใด ๆ.