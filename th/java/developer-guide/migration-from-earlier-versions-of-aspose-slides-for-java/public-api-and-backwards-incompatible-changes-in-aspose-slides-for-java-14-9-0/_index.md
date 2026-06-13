---  
title: Public API และการเปลี่ยนแปลงที่ไม่เข้ากันย้อนหลังใน Aspose.Slides for Java 14.9.0  
linktitle: Aspose.Slides สำหรับ Java 14.9.0  
type: docs  
weight: 80  
url: /th/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-9-0/  
keywords:  
  - การย้าย  
  - โค้ดเดิม  
  - โค้ดสมัยใหม่  
  - แนวทางเดิม  
  - แนวทางสมัยใหม่  
  - PowerPoint  
  - OpenDocument  
  - การนำเสนอ  
  - Java  
  - Aspose.Slides  
description: "ตรวจสอบการอัปเดต Public API และการเปลี่ยนแปลงที่ทำให้เกิดการแตกหักใน Aspose.Slides for Java เพื่อย้ายโซลูชันการนำเสนอ PowerPoint PPT, PPTX และ ODP ของคุณอย่างราบรื่น."  
---
{{% alert color="primary" %}} 

หน้านี้แสดงรายการทั้งหมดของคลาส, เมธอด, คุณสมบัติ ฯลฯ ที่ [added](/slides/th/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-9-0/) , ข้อจำกัดใหม่ใด ๆ และ [changes](/slides/th/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-9-0/) อื่น ๆ ที่นำมาใช้กับ Aspose.Slides for Java 14.9.0 API.

{{% /alert %}} 
## **Public API Changes**
### **Added Methods for Replacing Image to PPImage, IPPImage**
เมธอดใหม่ที่เพิ่มขึ้น:

- IPPImage.replaceImage(byte[] newImageData)
- IPPImage.replaceImage(IPPImage newImage)

``` java

 Presentation presentation = new Presentation("presentation.pptx");

//วิธีที่หนึ่ง

byte[] imageData = // ...

presentation.getImages().get_Item(0).replaceImage(imageData);

//วิธีที่สอง

presentation.getImages().get_Item(1).replaceImage(

    presentation.getImages().get_Item(0));

presentation.save("presentation_out.pptx", SaveFormat.Pptx);

```
### **Added Methods for Saving Slides Keeping Page Numbers**
เมธอดต่อไปนี้ได้ถูกเพิ่ม:

- void IPresentation.save(string fname, int[] slides, SaveFormat format);
- void IPresentation.save(string fname, int[] slides, SaveFormat format, ISaveOption options);
- void IPresentation.save(Stream stream, int[] slides, SaveFormat format);
- void IPresentation.save(Stream stream, int[] slides, SaveFormat format, ISaveOption options);

เมธอดเหล่านี้อนุญาตให้บันทึกสไลด์ของการนำเสนอที่ระบุเป็นรูปแบบ PDF, XPS, TIFF, HTML. อาร์เรย์ 'slides' ใช้ระบุเลขหน้าโดยเริ่มจาก 1.

``` java

 save(string fname, int\[\] slides, SaveFormat format);

```




``` java

 Presentation presentation = new Presentation(presentationFileName);

int[] slides = new int[] { 2, 3, 5 }; //อาร์เรย์ของตำแหน่งสไลด์

presentation.save(outFileName, slides, SaveFormat.Pdf);

```
### **Added the SmartArtLayoutType.Custom Enum Value**
ประเภทของ SmartArt layout นี้แสดงแผนภูมิที่ใช้เทมเพลตกำหนดเอง. แผนภูมิที่กำหนดเองสามารถโหลดได้จากไฟล์การนำเสนอเท่านั้นและไม่สามารถสร้างได้โดยใช้เมธอด ShapeCollection.addSmartArt(x, y, width, height, SmartArtLayoutType.Custom)
### **Added the SmartArtShape Class and ISmartArtShape Interface**
คลาส Aspose.Slides.SmartArt.SmartArtShape (และอินเทอร์เฟซ Aspose.Slides.SmartArt.ISmartArtShape) ให้การเข้าถึงรูปร่างแต่ละอันภายในแผนภูมิ SmartArt. SmartArtShape สามารถใช้เพื่อเปลี่ยน FillFormat, LineFormat, เพิ่ม Hyperlinks ฯลฯ

{{% alert color="primary" %}} 

SmartArtShape ไม่รองรับคุณสมบัติ IShape ได้แก่ RawFrame, Frame, Rotation, X, Y, Width, Height และจะขวาง System.NotSupportedException เมื่อพยายามเข้าถึง

{{% /alert %}} 

ตัวอย่างการใช้งาน:

``` java

 Presentation pres = new Presentation();

ISmartArt smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicBlockList);

ISmartArtNode node = smart.getAllNodes().get_Item(0);

for (ISmartArtShape shape : node.getShapes())

{

    shape.getFillFormat().setFillType(FillType.Solid);

    shape.getFillFormat().getSolidFillColor().setColor(Color.RED);

}

pres.save("out.pptx", SaveFormat.Pptx);

```
### **SmartArtShapeCollection class, ISmartArtShapeCollection interface and ISmartArtNode.getShapes() method have been added**
คลาส Aspose.Slides.SmartArt.SmartArtShapeCollection (และอินเทอร์เฟซ Aspose.Slides.SmartArt.ISmartArtShapeCollection) ให้การเข้าถึงรูปร่างแต่ละอันภายในแผนภูมิ SmartArt. คอลเลกชันนี้มีรูปร่างที่เชื่อมโยงกับ SmartArtNode. คุณสมบัติ SmartArtNode.Shapes จะคืนคอลเลกชันของรูปร่างทั้งหมดที่เชื่อมโยงกับโหนด

{{% alert color="primary" %}} 

ขึ้นอยู่กับ SmartArtLayoutType, SmartArtShape หนึ่งอาจถูกแชร์ระหว่างหลายโหนด

{{% /alert %}} 

 
``` java

 Presentation pres = new Presentation();

ISmartArt smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicBlockList);

ISmartArtNode node = smart.getAllNodes().get_Item(0);

for (ISmartArtShape shape : node.getShapes())

{

    shape.getFillFormat().setFillType(FillType.Solid);

    shape.getFillFormat().getSolidFillColor().setColor(Color.RED);

}

pres.save("out.pptx", SaveFormat.Pptx);

```