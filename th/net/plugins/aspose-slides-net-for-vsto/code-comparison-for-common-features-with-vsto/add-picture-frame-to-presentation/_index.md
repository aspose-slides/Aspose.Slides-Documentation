---
title: เพิ่มกรอบรูปภาพไปยังงานนำเสนอ
type: docs
weight: 50
url: /th/net/add-picture-frame-to-presentation/
---
## **VSTO**
ต่อไปเป็นโค้ดสำหรับการเพิ่มรูปภาพในงานนำเสนอ VSTO:

``` csharp

  string ImageFilePath="AddPicture.jpg";

 Slide slide = Application.ActivePresentation.Slides[1];

 slide.Shapes.AddPicture(ImageFilePath, Microsoft.Office.Core.MsoTriState.msoFalse,

 Microsoft.Office.Core.MsoTriState.msoCTrue, 0, 0);

``` 
## **Aspose.Slides**
ในการเพิ่มกรอบรูปภาพอย่างง่ายลงในสไลด์ของคุณ โปรดทำตามขั้นตอนด้านล่าง:

1. สร้างอินสแตนซ์ของคลาส Presentation.
1. รับอ้างอิงของสไลด์โดยใช้ดัชนีของมัน.
1. สร้างอ็อบเจ็กต์ Image ด้วยการเพิ่มรูปภาพลงในคอลเลกชัน Images ที่เชื่อมโยงกับอ็อบเจ็กต์ Presentation ซึ่งจะใช้ในการเติม Shape.
1. คำนวณความกว้างและความสูงของรูปภาพ.
1. สร้าง PictureFrame ตามความกว้างและความสูงของรูปภาพโดยใช้เมธอด AddPictureFrame ที่เปิดให้ใช้โดยอ็อบเจ็กต์ Shapes ที่เชื่อมโยงกับสไลด์ที่อ้างอิง.
1. เพิ่มกรอบรูปภาพ (ซึ่งประกอบด้วยรูป) ลงในสไลด์.
1. บันทึกงานนำเสนอที่แก้ไขเป็นไฟล์ PPTX.

ขั้นตอนข้างต้นได้ถูกนำไปใช้ในตัวอย่างที่ให้ด้านล่าง.

``` csharp

   string ImageFilePath = "AddPicture.jpg";

  //สร้างอินสแตนซ์ของคลาส Presentation ที่แทนไฟล์ PPTX

  Presentation pres = new Presentation();

  //รับสไลด์แรก

  ISlide sld = pres.Slides[0];

  //สร้างอินสแตนซ์ของคลาส ImageEx

  using IImage img = Images.FromFile(ImageFilePath);

  IPPImage imgx = pres.Images.AddImage(img);

  //เพิ่มกรอบรูปภาพโดยใช้ความสูงและความกว้างที่เท่ากับรูปภาพ

  sld.Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 150, imgx.Width, imgx.Height, imgx);

``` 
## **Download Running Code**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/AsposeSlidesVsVSTOv1.1)
## **Download Sample Code**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/Aspose.Slides%20Vs%20VSTO%20Presentations/Code%20Comparison%20of%20Common%20Features/Add%20Picture%20Frame)