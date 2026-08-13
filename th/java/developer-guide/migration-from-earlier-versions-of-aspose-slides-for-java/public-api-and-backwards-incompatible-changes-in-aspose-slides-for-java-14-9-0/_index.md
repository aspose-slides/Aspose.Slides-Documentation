---
title: API สาธารณะและการเปลี่ยนแปลงที่ไม่เข้ากันย้อนหลังใน Aspose.Slides สำหรับ Java 14.9.0
linktitle: Aspose.Slides สำหรับ Java 14.9.0
type: docs
weight: 80
url: /th/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-9-0/
keywords:
- การย้าย
- โค้ดเดิม
- โค้ดใหม่
- แนวทางเดิม
- แนวทางสมัยใหม่
- PowerPoint
- OpenDocument
- งานนำเสนอ
- Java
- Aspose.Slides
description: "รีวิวการอัปเดต API สาธารณะและการเปลี่ยนแปลงที่ทำให้เกิดการหยุดทำงานใน Aspose.Slides สำหรับ Java เพื่อช่วยให้การย้ายโซลูชันการนำเสนอ PowerPoint PPT, PPTX และ ODP ของคุณเป็นไปอย่างราบรื่น"
---
{{% alert color="info" %}} 

หน้านี้แสดงรายการทั้งหมดของคลาส, เมธอด, คุณสมบัติ ฯลฯ, ข้อจำกัดใหม่ใด ๆ และ [การเปลี่ยนแปลง](/slides/th/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-9-0/) ที่ถูกแนะนำใน Aspose.Slides for Java 14.9.0 API.

{{% /alert %}} 
## **การเปลี่ยนแปลง Public API**
### **เพิ่มเมธอดสำหรับการแทนที่รูปภาพเป็น PPImage, IPPImage**
เมธอดใหม่ที่เพิ่มเข้ามา:

- IPPImage.replaceImage(byte[] newImageData)
- IPPImage.replaceImage(IPPImage newImage)

``` java
import com.aspose.slides.*;
import java.nio.file.Files;
import java.nio.file.Paths;

Presentation presentation = new Presentation("presentation.pptx");
try {
    // วิธีแรก
    byte[] imageData = Files.readAllBytes(Paths.get("image.png"));
    presentation.getImages().get_Item(0).replaceImage(imageData);

    // วิธีที่สอง
    presentation.getImages().get_Item(1).replaceImage(presentation.getImages().get_Item(0));

    presentation.save("presentation_out.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```
### **เพิ่มเมธอดสำหรับการบันทึกสไลด์โดยเก็บหมายเลขหน้า**
เมธอดต่อไปนี้ได้ถูกเพิ่ม:

- void IPresentation.save(string fname, int[] slides, SaveFormat format);
- void IPresentation.save(string fname, int[] slides, SaveFormat format, ISaveOption options);
- void IPresentation.save(Stream stream, int[] slides, SaveFormat format);
- void IPresentation.save(Stream stream, int[] slides, SaveFormat format, ISaveOption options);

เมธอดเหล่านี้อนุญาตให้บันทึกสไลด์การพรีเซนเทชันที่ระบุเป็นรูปแบบ PDF, XPS, TIFF, HTML. อาร์เรย์ 'slides' สามารถกำหนดหมายเลขหน้าได้ โดยเริ่มจาก 1.

``` java
// เพิ่มเมธอดโอเวอร์โหลดให้กับ IPresentation (ค่าของ SaveFormat เป็นคอนสแตนต์ int ใน Java):
//
// void save(String fname, int[] slides, int format);
// void save(String fname, int[] slides, int format, ISaveOptions options);
// void save(OutputStream stream, int[] slides, int format);
// void save(OutputStream stream, int[] slides, int format, ISaveOptions options);
```




``` java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    int[] slides = new int[] { 2, 3, 5 }; // อาร์เรย์ของตำแหน่งสไลด์

    presentation.save("presentation_out.pdf", slides, SaveFormat.Pdf);
} finally {
    if (presentation != null) presentation.dispose();
}
```
### **เพิ่มค่า Enum ของ SmartArtLayoutType.Custom**
ประเภทของการจัดวาง SmartArt นี้แสดงแผนภาพที่ใช้เทมเพลตแบบกำหนดเอง. แผนภาพแบบกำหนดเองสามารถโหลดได้เฉพาะจากไฟล์พรีเซนเทชันและไม่สามารถสร้างผ่านเมธอด ShapeCollection.addSmartArt(x, y, width, height, SmartArtLayoutType.Custom)

### **เพิ่มคลาส SmartArtShape และอินเทอร์เฟซ ISmartArtShape**
แคลาส Aspose.Slides.SmartArt.SmartArtShape (และอินเทอร์เฟซ Aspose.Slides.SmartArt.ISmartArtShape) เพิ่มการเข้าถึงรูปร่างแต่ละอันภายในแผนภาพ SmartArt. SmartArtShape สามารถใช้เพื่อเปลี่ยน FillFormat, LineFormat, เพิ่ม Hyperlinks เป็นต้น.

{{% alert color="info" %}} 

SmartArtShape ไม่รองรับคุณสมบัติของ IShape ได้แก่ RawFrame, Frame, Rotation, X, Y, Width, Height และจะส่ง System.NotSupportedException เมื่อลองเข้าถึงมัน.

{{% /alert %}} 

ตัวอย่างการใช้งาน:

``` java
import com.aspose.slides.*;
import java.awt.Color;


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
### **เพิ่มคลาส SmartArtShapeCollection, อินเทอร์เฟซ ISmartArtShapeCollection และเมธอด ISmartArtNode.getShapes()**
แคลาส Aspose.Slides.SmartArt.SmartArtShapeCollection (และอินเทอร์เฟซ Aspose.Slides.SmartArt.ISmartArtShapeCollection) เพิ่มการเข้าถึงรูปร่างแต่ละอันภายในแผนภาพ SmartArt. คอลเลกชันนี้มีรูปทรงที่เชื่อมโยงกับ SmartArtNode. คุณสมบัติ SmartArtNode.Shapes จะคืนคอลเลกชันของรูปทรงทั้งหมดที่เชื่อมโยงกับโหนดนั้น.

{{% alert color="info" %}} 

ขึ้นอยู่กับ SmartArtLayoutType, SmartArtShape หนึ่งอาจถูกแชร์ระหว่างหลายโหนด.

{{% /alert %}} 

 
``` java
import com.aspose.slides.*;
import java.awt.Color;


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