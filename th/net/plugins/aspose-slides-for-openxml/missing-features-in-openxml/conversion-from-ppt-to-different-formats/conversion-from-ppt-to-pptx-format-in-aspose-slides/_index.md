---
title: การแปลงจาก PPT เป็นรูปแบบ PPTX ใน Aspose.Slides
type: docs
weight: 10
url: /th/net/conversion-from-ppt-to-pptx-format-in-aspose-slides/
---
**Aspose.Slides** for .NET ตอนนี้อำนวยความสะดวกให้ผู้พัฒนาสามารถเข้าถึงไฟล์ PPT ผ่านอินสแตนซ์ของคลาส Presentation และแปลงเป็นรูปแบบ PPTX ที่สอดคล้องกัน ปัจจุบันรองรับการแปลงบางส่วนจาก PPT ไปเป็น PPTX สำหรับรายละเอียดเพิ่มเติมเกี่ยวกับคุณลักษณะที่ได้รับการสนับสนุนและไม่รองรับในการแปลงจาก PPT เป็น PPTX โปรดไปที่ลิงก์เอกสารนี้

**Aspose.Slides** for .NET มีคลาส Presentation ที่เป็นตัวแทนของไฟล์นำเสนอ PPTX คลาส Presentation ตอนนี้ยังสามารถเข้าถึงไฟล์ PPT ผ่าน Presentation เมื่ออ็อบเจ็กต์ถูกสร้างขึ้น

``` csharp

 //สร้างอ็อบเจ็กต์ Presentation ที่เป็นตัวแทนของไฟล์ PPTX

PresentationEx pres = new PresentationEx("Conversion.ppt");

//บันทึกการนำเสนอ PPTX เป็นรูปแบบ PPTX

pres.Save(MyDir +"Converted.pptx", SaveFormat.Pptx);

``` 
## **ดาวน์โหลดตัวอย่างโค้ด**
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/Conversion%20PPT%20to%20PPTX%20%28Aspose.Slides%29.zip)