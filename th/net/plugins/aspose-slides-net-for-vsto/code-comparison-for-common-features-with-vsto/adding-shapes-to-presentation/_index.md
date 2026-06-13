---
title: เพิ่มรูปทรงลงในงานนำเสนอ
type: docs
weight: 30
url: /th/net/adding-shapes-to-presentation/
---
## **VSTO**
ต่อไปนี้คือส่วนของโค้ดสำหรับเพิ่มรูปทรงเส้น:

``` csharp

   Slide slide = Application.ActivePresentation.Slides[1];

  slide.Shapes.AddLine(10, 10, 100, 10);

``` 
## **Aspose.Slides**
เพื่อเพิ่มเส้นธรรมดาอย่างง่ายลงในสไลด์ที่เลือกของงานนำเสนอ โปรดทำตามขั้นตอนต่อไปนี้:

- สร้างอินสแตนซ์ของคลาส Presentation
- รับอ้างอิงของสไลด์โดยใช้ Index ของมัน
- เพิ่ม AutoShape ประเภท Line โดยใช้เมธอด AddAutoShape ที่เปิดโดยอ็อบเจกต์ Shapes
- บันทึกงานนำเสนอที่แก้ไขเป็นไฟล์ PPTX

ในตัวอย่างด้านล่าง เราได้เพิ่มเส้นลงในสไลด์แรกของงานนำเสนอ.

``` csharp

   //สร้างอินสแตนซ์ของคลาส Presentation ที่เป็นตัวแทนของไฟล์ PPTX

  Presentation pres = new Presentation();

  //รับสไลด์แรก

  ISlide slide = pres.Slides[0];

  //เพิ่ม AutoShape ประเภทเส้น

  slide.Shapes.AddAutoShape(ShapeType.Line, 50, 150, 300, 0);

``` 
## **ดาวน์โหลดโค้ดที่ทำงานอยู่**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/AsposeSlidesVsVSTOv1.1)
## **ดาวน์โหลดโค้ดตัวอย่าง**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/Aspose.Slides%20Vs%20VSTO%20Presentations/Code%20Comparison%20of%20Common%20Features/Adding%20Shape%20to%20Presentation)