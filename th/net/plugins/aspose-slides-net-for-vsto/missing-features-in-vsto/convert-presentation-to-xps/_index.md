---
title: แปลงงานนำเสนอเป็น XPS
type: docs
weight: 60
url: /th/net/convert-presentation-to-xps/
---
**XPS** รูปแบบถูกใช้อย่างกว้างขวางสำหรับการแลกเปลี่ยนข้อมูล Aspose.Slides for .NET ใส่ใจถึงความสำคัญของมันและให้การสนับสนุนในตัวสำหรับการแปลงงานนำเสนอเป็นเอกสาร XPS

วิธี **Save** ที่เปิดให้ใช้โดยคลาส Presentation สามารถใช้เพื่อแปลงงานนำเสนอทั้งหมดเป็นเอกสาร **XPS** ได้ อีกทั้งคลาส **XpsOptions** เปิดให้ใช้คุณสมบัติ **SaveMetafileAsPng** ซึ่งสามารถตั้งค่าเป็น true หรือ false ตามความต้องการ
## **ตัวอย่าง**

``` 

 //สร้างอ็อบเจ็กต์ Presentation ที่เป็นตัวแทนของไฟล์งานนำเสนอ

Presentation pres = new Presentation("Conversion.ppt");

//บันทึกงานนำเสนอเป็นเอกสาร TIFF

pres.Save("converted.xps", Aspose.Slides.Export.SaveFormat.Xps);

``` 
## **ดาวน์โหลดตัวอย่างที่ทำงาน**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/Aspose.Slides%20Vs%20VSTO%20Presentations/Aspose.Slides%20Features%20missing%20in%20VSTO/Converting%20to%20XPS)
## **ดาวน์โหลดโค้ดตัวอย่าง**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/Aspose.SlidesFeaturesmissingInVSTOv1.1)

{{% alert color="primary" %}} 

สำหรับรายละเอียดเพิ่มเติม ดูที่ [แปลงงานนำเสนอ PowerPoint เป็น XPS ใน .NET](/slides/th/net/convert-powerpoint-to-xps/).

{{% /alert %}}