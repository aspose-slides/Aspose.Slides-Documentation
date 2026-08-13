---
title: เพิ่มลายน้ำในงานนำเสนอบน Android
linktitle: ลายน้ำ
type: docs
weight: 40
url: /th/androidjava/watermark/
keywords:
- ลายน้ำ
- ลายน้ำข้อความ
- ลายน้ำรูปภาพ
- เพิ่มลายน้ำ
- เปลี่ยนลายน้ำ
- ลบลายน้ำ
- ลบลายน้ำ
- เพิ่มลายน้ำให้กับ PPT
- เพิ่มลายน้ำให้กับ PPTX
- เพิ่มลายน้ำให้กับ ODP
- ลบลายน้ำจาก PPT
- ลบลายน้ำจาก PPTX
- ลบลายน้ำจาก ODP
- ลบลายน้ำจาก PPT
- ลบลายน้ำจาก PPTX
- ลบลายน้ำจาก ODP
- PowerPoint
- OpenDocument
- งานนำเสนอ
- Android
- Java
- Aspose.Slides
description: "จัดการลายน้ำข้อความและลายน้ำรูปภาพในงานนำเสนอ PowerPoint และ OpenDocument บน Android ด้วย Java เพื่อระบุต้นฉบับร่าง, ข้อมูลลับ, และอื่น ๆ"
---
## **คำนำ**

**ลายน้ำ** ในงานนำเสนอคือข้อความหรือรูปภาพที่ประทับบนสไลด์หรือทั่วทั้งสไลด์ของการนำเสนอ ปกติแล้วลายน้ำถูกใช้เพื่อบ่งบอกว่าการนำเสนอนั้นเป็นฉบับร่าง (เช่น ลายน้ำ “Draft”) มีข้อมูลลับ (เช่นลายน้ำ “Confidential”) ระบุบริษัท (เช่นลายน้ำ “Company Name”) หรือระบุตัวผู้สร้างงานนำเสนอ เป็นต้น ลายน้ำช่วยป้องกันการละเมิดลิขสิทธิ์โดยระบุว่าการนำเสนอไม่ควรถูกคัดลอก ลายน้ำใช้ได้กับรูปแบบ PowerPoint และ OpenOffice ทั้งสองรูปแบบ ใน Aspose.Slides คุณสามารถเพิ่มลายน้ำให้กับไฟล์ PowerPoint PPT, PPTX และ OpenOffice ODP ได้

ใน[**Aspose.Slides**](https://products.aspose.com/slides/th/android-java/), มีวิธีต่าง ๆ ที่คุณสามารถสร้างลายน้ำในเอกสาร PowerPoint หรือ OpenOffice และปรับการออกแบบและพฤติกรรมของมัน วิธีทั่วไปคือเพื่อเพิ่มลายน้ำข้อความให้ใช้ interface [ITextFrame](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/itextframe/) และเพื่อเพิ่มลายน้ำรูปภาพให้ใช้คลาส [PictureFrame](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/pictureframe/) หรือเติมรูปภาพให้กับรูปร่างลายน้ำ `PictureFrame` ทำการประมวลผล interface [IShape](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ishape/) ทำให้คุณใช้การตั้งค่าที่ยืดหยุ่นของอ็อบเจกต์รูปร่างได้ทั้งหมด เนื่องจาก `ITextFrame` ไม่ใช่รูปร่างและการตั้งค่ามีข้อจำกัด มันจึงถูกห่อหุ้มไว้ในอ็อบเจกต์ [IShape](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ishape/)

มีสองวิธีในการใช้ลายน้ำ: กับสไลด์เดียวหรือกับสไลด์ทั้งหมด Slide Master จะใช้เพื่อเพิ่มลายน้ำให้กับสไลด์ทั้งหมด — ลายน้ำถูกเพิ่มไปที่ Slide Master ออกแบบเต็มรูปแบบที่นั่นและนำไปใช้กับสไลด์ทุกสไลด์โดยไม่กระทบต่อสิทธิ์การแก้ไขลายน้ำบนสไลด์แต่ละอัน

ปกติแล้วลายน้ำจะถือว่าไม่สามารถแก้ไขได้โดยผู้ใช้คนอื่น เพื่อป้องกันไม่ให้ลายน้ำ (หรือแม้แต่รูปร่างพาเรนต์ของลายน้ำ) ถูกแก้ไข Aspose.Slides มีฟังก์ชันการล็อกรูปร่าง รูปร่างเฉพาะสามารถล็อกได้บนสไลด์ปกติหรือบน Slide Master เมื่อรูปร่างลายน้ำถูกล็อกบน Slide Master จะถูกล็อกบนสไลด์ทั้งหมดเช่นกัน

คุณสามารถตั้งชื่อให้กับลายน้ำเพื่อในอนาคตหากต้องการลบ คุณสามารถค้นหารูปร่างนั้นในสไลด์โดยใช้ชื่อได้

คุณสามารถออกแบบลายน้ำได้ตามต้องการ; อย่างไรก็ตามลายน้ำส่วนใหญ่มีลักษณะร่วมกัน เช่น การจัดกึ่งกลาง การหมุน การอยู่หน้าสุด เป็นต้น เราจะพิจารณาการใช้เหล่านี้ในตัวอย่างต่อไป

## **ลายน้ำข้อความ**

### **เพิ่มลายน้ำข้อความลงในสไลด์**

เพื่อเพิ่มลายน้ำข้อความใน PPT, PPTX หรือ ODP คุณสามารถเริ่มโดยเพิ่มรูปร่างลงในสไลด์ แล้วเพิ่มเฟรมข้อความลงในรูปร่างนั้น เฟรมข้อความเป็นตัวแทนโดย interface [ITextFrame](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/itextframe/) ซึ่งไม่สืบทอดจาก [IShape](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ishape/) ที่มีชุดคุณสมบัติกว้างขวางสำหรับกำหนดตำแหน่งลายน้ำอย่างยืดหยุ่น ดังนั้นอ็อบเจกต์ [ITextFrame](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/itextframe/) จะถูกห่อหุ้มในอ็อบเจกต์ [IAutoShape](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iautoshape/) เพื่อเพิ่มข้อความลายน้ำลงในรูปร่าง ให้ใช้เมธอด [addTextFrame](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iautoshape/#addTextFrame-java.lang.String-) ตามตัวอย่างด้านล่าง

```java
import com.aspose.slides.*;

String watermarkText = "CONFIDENTIAL";

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

IAutoShape watermarkShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);
ITextFrame watermarkFrame = watermarkShape.addTextFrame(watermarkText);

presentation.dispose();
```

{{% alert color="info" title="ดูเพิ่มเติม" %}} 
- [How to Use the TextFrame Class](/slides/th/androidjava/text-formatting/)
{{% /alert %}}

### **เพิ่มลายน้ำข้อความลงในงานนำเสนอ**

หากต้องการเพิ่มลายน้ำข้อความให้กับงานนำเสนอทั้งหมด (คือทุกสไลด์พร้อมกัน) ให้เพิ่มลงใน [MasterSlide](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/masterslide/) ส่วนตรรกะที่เหลือเหมือนกับการเพิ่มลายน้ำลงในสไลด์เดี่ยว — สร้างอ็อบเจกต์ [IAutoShape](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iautoshape/) แล้วใช้เมธอด [addTextFrame](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iautoshape/#addTextFrame-java.lang.String-) เพื่อใส่ลายน้ำลงไป

```java
import com.aspose.slides.*;

String watermarkText = "CONFIDENTIAL";

Presentation presentation = new Presentation();
IMasterSlide masterSlide = presentation.getMasters().get_Item(0);

IAutoShape watermarkShape = masterSlide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);
ITextFrame watermarkFrame = watermarkShape.addTextFrame(watermarkText);

presentation.dispose();
```

{{% alert color="info" title="ดูเพิ่มเติม" %}} 
- [How to Use the Slide Master](/slides/th/androidjava/slide-master/)
{{% /alert %}}

### **ตั้งค่าความโปร่งใสของรูปร่างลายน้ำ**

โดยค่าเริ่มต้น รูปร่างสี่เหลี่ยมจะมีสีเติมและสีเส้น โค้ดต่อไปนี้ทำให้รูปร่างโปร่งใส

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape watermarkShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);

    watermarkShape.getFillFormat().setFillType(FillType.NoFill);
    watermarkShape.getLineFormat().getFillFormat().setFillType(FillType.NoFill);
} finally {
    presentation.dispose();
}
```

### **ตั้งค่าแบบอักษรสำหรับลายน้ำข้อความ**

คุณสามารถเปลี่ยนแบบอักษรของลายน้ำข้อความได้ตามตัวอย่างต่อไปนี้

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape watermarkShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);
    ITextFrame watermarkFrame = watermarkShape.addTextFrame("CONFIDENTIAL");

    IPortionFormat textFormat = watermarkFrame.getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat();
    textFormat.setLatinFont(new FontData("Arial"));
    textFormat.setFontHeight(50);
} finally {
    presentation.dispose();
}
```

### **ตั้งค่าสีข้อความลายน้ำ**

เพื่อกำหนดสีข้อความลายน้ำ ให้ใช้โค้ดนี้

```java
import com.aspose.slides.*;
import java.awt.Color;

int alpha = 150, red = 200, green = 200, blue = 200;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape watermarkShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);
    ITextFrame watermarkFrame = watermarkShape.addTextFrame("CONFIDENTIAL");

    IFillFormat fillFormat = watermarkFrame.getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().getFillFormat();
    fillFormat.setFillType(FillType.Solid);
    fillFormat.getSolidFillColor().setColor(new Color(red, green, blue, alpha));
} finally {
    presentation.dispose();
}
```

### **จัดกึ่งกลางลายน้ำข้อความ**

คุณสามารถจัดกึ่งกลางลายน้ำบนสไลด์ได้โดยทำตามขั้นตอนต่อไปนี้

```java
import com.aspose.slides.*;
import java.awt.geom.Dimension2D;

String watermarkText = "CONFIDENTIAL";

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    Dimension2D slideSize = presentation.getSlideSize().getSize();

    float watermarkWidth = 400;
    float watermarkHeight = 40;
    float watermarkX = ((float)slideSize.getWidth() - watermarkWidth) / 2;
    float watermarkY = ((float)slideSize.getHeight() - watermarkHeight) / 2;

    IAutoShape watermarkShape = slide.getShapes().addAutoShape(
            ShapeType.Rectangle, watermarkX, watermarkY, watermarkWidth, watermarkHeight);

    ITextFrame watermarkFrame = watermarkShape.addTextFrame(watermarkText);
} finally {
    presentation.dispose();
}
```

รูปภาพด้านล่างแสดงผลลัพธ์สุดท้าย

![The text watermark](text_watermark.png)

## **ลายน้ำรูปภาพ**

### **เพิ่มลายน้ำรูปภาพลงในงานนำเสนอ**

เพื่อเพิ่มลายน้ำรูปภาพลงในสไลด์ของงานนำเสนอ คุณสามารถทำตามขั้นตอนต่อไปนี้

```java
import com.aspose.slides.*;
import java.io.FileInputStream;
import java.io.InputStream;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape watermarkShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);

    InputStream imageStream = new FileInputStream("watermark.png");
    IPPImage image = presentation.getImages().addImage(imageStream);

    watermarkShape.getFillFormat().setFillType(FillType.Picture);
    watermarkShape.getFillFormat().getPictureFillFormat().getPicture().setImage(image);
    watermarkShape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch);
} finally {
    presentation.dispose();
}
```

### **ล็อกลายน้ำไม่ให้แก้ไข**

หากต้องการป้องกันการแก้ไขลายน้ำ ให้ใช้เมธอด [IAutoShape.getAutoShapeLock](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iautoshape/#getAutoShapeLock--) กับรูปร่าง ด้วยคุณสมบัตินี้คุณสามารถปกป้องรูปร่างจากการเลือก การปรับขนาด การย้ายตำแหน่ง การรวมกลุ่มกับองค์ประกอบอื่น ๆ การล็อกข้อความจากการแก้ไข และอื่น ๆ อีกมากมาย

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape watermarkShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);

    // ล็อกรูปร่างลายน้ำไม่ให้แก้ไข
    watermarkShape.getAutoShapeLock().setSelectLocked(true);
    watermarkShape.getAutoShapeLock().setSizeLocked(true);
    watermarkShape.getAutoShapeLock().setTextLocked(true);
    watermarkShape.getAutoShapeLock().setPositionLocked(true);
    watermarkShape.getAutoShapeLock().setGroupingLocked(true);
} finally {
    presentation.dispose();
}
```

### **นำลายน้ำไปอยู่ด้านหน้า**

ใน Aspose.Slides, การจัดลำดับ Z ของรูปร่างสามารถตั้งค่าได้ผ่านเมธอด [IShapeCollection.reorder](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ishapecollection/#reorder-int-com.aspose.slides.IShape-) ให้เรียกเมธอดนี้จากรายการสไลด์ของงานนำเสนอและส่งอ้างอิงรูปร่างพร้อมลำดับเลขเข้าไป วิธีนี้ทำให้สามารถนำรูปร่างไปอยู่ด้านหน้า หรือส่งไปอยู่ด้านหลังของสไลด์ได้ ฟีเจอร์นี้มีประโยชน์อย่างยิ่งหากต้องการให้ลายน้ำอยู่หน้าสุดของงานนำเสนอ

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape watermarkShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);

    int shapeCount = slide.getShapes().size();
    slide.getShapes().reorder(shapeCount - 1, watermarkShape);
} finally {
    presentation.dispose();
}
```

### **ตั้งค่าการหมุนของลายน้ำ**

นี่คือตัวอย่างโค้ดเพื่อปรับการหมุนของลายน้ำให้วางแนวทแยงมุมบนสไลด์

```java
import com.aspose.slides.*;
import java.awt.geom.Dimension2D;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape watermarkShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);
    Dimension2D slideSize = presentation.getSlideSize().getSize();

    double diagonalAngle = Math.atan((slideSize.getHeight() / slideSize.getWidth())) * 180 / Math.PI;

    watermarkShape.setRotation((float)diagonalAngle);
} finally {
    presentation.dispose();
}
```

### **ตั้งชื่อให้ลายน้ำ**

Aspose.Slides อนุญาตให้คุณตั้งชื่อให้กับรูปร่างโดยใช้ชื่อรูปร่าง คุณสามารถเข้าถึงมันในภายหลังเพื่อแก้ไขหรือ删除ได้ เพื่อกำหนดชื่อให้กับรูปร่างลายน้ำ ให้เรียกเมธอด [IAutoShape.setName](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ishape/#setName-java.lang.String-)

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape watermarkShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);

    watermarkShape.setName("watermark");
} finally {
    presentation.dispose();
}
```

### **ลบลายน้ำ**

เพื่อลบรูปร่างลายน้ำ ใช้เมธอด [IAutoShape.getName](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ishape/#getName--) เพื่อค้นหาในรูปร่างของสไลด์ แล้วส่งรูปร่างลายน้ำเข้าเมธอด [IShapeCollection.remove](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ishapecollection/#remove-com.aspose.slides.IShape-)

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("watermarked.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IShape[] slideShapes = slide.getShapes().toArray();
    for (IShape shape : slideShapes) {
        if ("watermark".equals(shape.getName()))
        {
            slide.getShapes().remove(shape);
        }
    }
} finally {
    presentation.dispose();
}
```

## **ถามตอบ**

### ลายน้ำคืออะไรและทำไมต้องใช้?

ลายน้ำคือการวางข้อความหรือรูปภาพทับบนสไลด์เพื่อช่วยปกป้องทรัพย์สินทางปัญญา เสริมการรู้จักแบรนด์ หรือป้องกันการใช้ผลงานโดยไม่ได้รับอนุญาต

### ฉันสามารถเพิ่มลายน้ำให้กับสไลด์ทั้งหมดในงานนำเสนอได้หรือไม่?

ได้, Aspose.Slides ช่วยให้คุณเพิ่มลายน้ำให้กับทุกสไลด์ในงานนำเสนอได้โดยอัตโนมัติ คุณสามารถวนลูปผ่านสไลด์ทั้งหมดและตั้งค่าลายน้ำแต่ละสไลด์ได้

### ฉันจะปรับความโปร่งใสของลายน้ำได้อย่างไร?

คุณสามารถปรับความโปร่งใสของลายน้ำได้โดยแก้ไขการตั้งค่าการเติมสี ([getFillFormat](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/shape/#getFillFormat--)) ของรูปร่าง ซึ่งทำให้ลายน้ำดูอ่อนโยนและไม่รบกวนเนื้อหาสไลด์

### รูปแบบภาพใดบ้างที่รองรับสำหรับลายน้ำ?

Aspose.Slides รองรับรูปแบบภาพหลายประเภท เช่น PNG, JPEG, GIF, BMP, SVG เป็นต้น

### ฉันสามารถปรับแบบอักษรและสไตล์ของลายน้ำข้อความได้หรือไม่?

ได้, คุณสามารถเลือกแบบอักษร, ขนาด, และสไตล์ใดก็ได้เพื่อให้ตรงกับการออกแบบงานนำเสนอและรักษาความสอดคล้องของแบรนด์

### ฉันจะเปลี่ยนตำแหน่งหรือการวางแนวของลายน้ำได้อย่างไร?

คุณสามารถปรับตำแหน่งและการวางแนวของลายน้ำโดยโปรแกรมได้โดยแก้ไขพิกัด, ขนาด, และคุณสมบัติการหมุนของรูปร่าง 