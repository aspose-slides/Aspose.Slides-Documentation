---
title: แปลงงานนำเสนอ OpenDocument ใน .NET
linktitle: แปลง OpenDocument
type: docs
weight: 10
url: /th/net/convert-openoffice-odp/
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
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET ช่วยให้คุณแปลง ODP เป็น PDF, HTML, และรูปภาพได้อย่างง่ายดาย เพิ่มประสิทธิภาพให้แอป .NET ของคุณด้วยการแปลงงานนำเสนอที่รวดเร็วและแม่นยำ."
---
## **บทนำ**

[**Aspose.Slides API**](https://products.aspose.com/slides/th/net/) ช่วยให้คุณแปลงงานนำเสนอ OpenDocument (ODP) เป็นหลายรูปแบบ (HTML, PDF, TIFF, SWF, XPS ฯลฯ) API ที่ใช้แปลงไฟล์ ODP ไปเป็นรูปแบบเอกสารอื่น ๆ เป็น API เดียวกับที่ใช้สำหรับการแปลง PowerPoint (PPT และ PPTX).

ตัวอย่างเช่น หากคุณต้องการแปลงงานนำเสนอ ODP เป็น PDF คุณสามารถทำตามขั้นตอนต่อไปนี้:

```cs
using (Presentation presentation = new Presentation("presentation.odp"))
{
    presentation.Save("presentation.pdf", SaveFormat.Pdf);
}
```

## **งานนำเสนอ OpenDocument ในแอปพลิเคชันต่าง ๆ**

เมื่อไฟล์งานนำเสนอ OpenDocument (ODP) ถูกเปิดใน PowerPoint อาจไม่คงรูปแบบเดิมที่สร้างในแอปพลิเคชันต้นทาง เนื่องจากแอป OpenDocument และ PowerPoint มีฟีเจอร์และพฤติกรรมการเรนเดอร์ที่ต่างกัน

ต่อไปนี้คือความแตกต่างบางประการ:

- ใน PowerPoint ตารางมักจะถูกเรนเดอร์เป็นครั้งสุดท้ายและอาจทับรูปทรงอื่น ๆ แม้ลำดับของตารางบนสไลด์ ODP จะเป็นอย่างไร
- การเติมรูปภาพในตาราง ODP ไม่ได้รับการสนับสนุนใน PowerPoint
- การหมุนข้อความแนวตั้ง (270°, ซ้อนกัน) และการจัดตำแหน่งแบบกระจาย ไม่ได้รับการสนับสนุนใน LibreOffice/OpenOffice Impress
- การเติมรูปภาพ, การเติมไล่สี, และการเติมลายแบบสำหรับข้อความ ไม่ได้รับการสนับสนุนใน LibreOffice/OpenOffice Impress

MS PowerPoint และ LibreOffice/OpenOffice Impress ยังจัดการรายการ (lists) อย่างแตกต่างกัน ไฟล์ ODP ที่สร้างใน PowerPoint อาจแสดงไม่ถูกต้องใน LibreOffice/OpenOffice Impress และในทางกลับกัน

รูปภาพด้านล่างแสดงว่ารายการจะปรากฏอย่างไรเมื่อสร้างใน LibreOffice Impress:

![ODP list example](odp-list-example.png)

Aspose.Slides จะบันทึกรายการ ODP โดยวิธีที่ทำให้แสดงผลได้อย่างถูกต้องใน LibreOffice/OpenOffice Impress.

[เรียนรู้เพิ่มเติมเกี่ยวกับรูปแบบ OpenDocument และ PowerPoint](https://support.microsoft.com/en-us/office/use-powerpoint-to-save-or-open-a-presentation-in-the-opendocument-presentation-odp-format-94805e84-1b09-4c98-a8b5-0da2a52242a0).

## **คำถามที่พบบ่อย**

**หากรูปแบบของไฟล์ ODP ของฉันเปลี่ยนแปลงหลังการแปลงจะทำอย่างไร?**

ODP และ PowerPoint ใช้โมเดลการนำเสนอที่แตกต่างกัน และบางองค์ประกอบ เช่น ตาราง, ฟอนต์ที่กำหนดเอง, หรือสไตล์การเติม อาจไม่แสดงผลตรงกันอย่างสมบูรณ์ แนะนำให้ตรวจสอบผลลัพธ์และปรับแต่งเลเอาต์หรือรูปแบบในโค้ดหากจำเป็น

**ฉันจำเป็นต้องติดตั้ง OpenOffice หรือ LibreOffice เพื่อใช้การแปลง ODP หรือไม่?**

ไม่, Aspose.Slides สำหรับ .NET เป็นไลบรารีแบบสแตนด์อโลนและไม่จำเป็นต้องติดตั้ง OpenOffice หรือ LibreOffice บนระบบของคุณ

**ฉันสามารถปรับแต่งรูปแบบผลลัพธ์ระหว่างการแปลง ODP (เช่น ตั้งค่า PDF options) ได้หรือไม่?**

ได้, Aspose.Slides มีตัวเลือกมากมายสำหรับการปรับแต่งผลลัพธ์ ตัวอย่างเช่น เมื่อบันทึกเป็น PDF คุณสามารถควบคุมการบีบอัด, คุณภาพภาพ, การเรนเดอร์ข้อความ, และอื่น ๆ ผ่านคลาส [PdfOptions](https://reference.aspose.com/slides/th/net/aspose.slides.export/pdfoptions/)

**Aspose.Slides เหมาะสำหรับการประมวลผล ODP ทางฝั่งเซิร์ฟเวอร์หรือบนคลาวด์หรือไม่?**

แน่นอน Aspose.Slides สำหรับ .NET ถูกออกแบบให้ทำงานได้ทั้งในสภาพแวดล้อมเดสก์ท็อปและเซิร์ฟเวอร์ รวมถึงแพลตฟอร์มคลาวด์เช่น Azure, AWS และคอนเทนเนอร์ Docker โดยไม่ต้องพึ่งพา UI ใด ๆ