---
title: การเปิดงานนำเสนอใน VSTO และ Aspose.Slides
type: docs
weight: 120
url: /th/net/opening-a-presentation-in-vsto-and-aspose-slides/
---
## **VSTO**
ด้านล่างเป็นโค้ดตัวอย่างสำหรับการเปิดงานนำเสนอ:

``` csharp

  string FileName = "Open Presentation.pptx";

 Application.Presentations.Open(FileName);


``` 
## **Aspose.Slides**
Aspose.Slides สำหรับ .NET มีคลาส **Presentation** ที่ใช้ในการเปิดงานนำเสนอที่มีอยู่แล้ว. คลาสนี้มีคอนสตรัคเตอร์หลายแบบที่โอเวอร์โหลดและเราสามารถใช้คอนสตรัคเตอร์ที่เหมาะสมหนึ่งตัวของคลาส **Presentation** เพื่อสร้างอ็อบเจ็กต์จากงานนำเสนอที่มีอยู่. ในตัวอย่างด้านล่าง เราได้ส่งชื่อไฟล์งานนำเสนอ (ที่ต้องการเปิด) ไปยังคอนสตรัคเตอร์ของคลาส Presentation. หลังจากไฟล์ถูกเปิด เราจะรับจำนวนสไลด์ทั้งหมดในงานนำเสนอเพื่อพิมพ์แสดงบนหน้าจอ.

``` csharp

  string FileName = "Open Presentation.pptx";

 Presentation MyPresentation = new Presentation(FileName);

``` 
## **Download Running Code**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/AsposeSlidesVsVSTOv1.1)
## **Download Sample Code**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/Aspose.Slides%20Vs%20VSTO%20Presentations/Code%20Comparison%20of%20Common%20Features/Opening%20a%20Presentation)