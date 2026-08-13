---
title: เพิ่มลายน้ำในงานนำเสนอด้วย Java
linktitle: ลายน้ำ
type: docs
weight: 40
url: /th/java/watermark/
keywords:
- ลายน้ำ
- ลายน้ำข้อความ
- ลายน้ำรูปภาพ
- เพิ่มลายน้ำ
- แก้ไขลายน้ำ
- ลบลายน้ำ
- ลบลายน้ำ
- เพิ่มลายน้ำใน PPT
- เพิ่มลายน้ำใน PPTX
- เพิ่มลายน้ำใน ODP
- ลบลายน้ำจาก PPT
- ลบลายน้ำจาก PPTX
- ลบลายน้ำจาก ODP
- ลบลายน้ำจาก PPT
- ลบลายน้ำจาก PPTX
- ลบลายน้ำจาก ODP
- PowerPoint
- OpenDocument
- การนำเสนอ
- Java
- Aspose.Slides
description: "จัดการลายน้ำข้อความและรูปภาพในงานนำเสนอ PowerPoint และ OpenDocument ด้วย Java เพื่อบ่งบอกฉบับร่าง ข้อมูลลับ ลิขสิทธิ์ และอื่น ๆ."
---
## **บทนำ**

**ลายน้ำ** ในการนำเสนอคือแสตมป์ข้อความหรือรูปภาพที่ใช้บนสไลด์หรือทั่วทั้งสไลด์ของการนำเสนอ โดยทั่วไป ลายน้ำใช้เพื่อบ่งชี้ว่าการนำเสนอเป็นฉบับร่าง (เช่น ลายน้ำ "Draft") มีข้อมูลลับ (เช่น ลายน้ำ "Confidential") ระบุบริษัทที่เป็นเจ้าของ (เช่น ลายน้ำ "Company Name") ระบุผู้เขียนการนำเสนอ ฯลฯ ลายน้ำช่วยป้องกันการละเมิดลิขสิทธิ์โดยบ่งบอกว่าการนำเสนอไม่ควรถูกคัดลอก ลายน้ำใช้ได้ในรูปแบบการนำเสนอของ PowerPoint และ OpenOffice ใน Aspose.Slides คุณสามารถเพิ่มลายน้ำลงในไฟล์ PowerPoint PPT, PPTX และ OpenOffice ODP ได้

ใน [**Aspose.Slides**](https://products.aspose.com/slides/th/java/) มีวิธีต่าง ๆ ที่คุณสามารถสร้างลายน้ำในเอกสาร PowerPoint หรือ OpenOffice และปรับเปลี่ยนการออกแบบและพฤติกรรมของมัน ด้านที่สำคัญคือเพื่อเพิ่มลายน้ำข้อความ คุณควรใช้อินเทอร์เฟซ [ITextFrame](https://reference.aspose.com/slides/th/java/com.aspose.slides/itextframe/) และเพื่อเพิ่มลายน้ำรูปภาพ ใช้คลาส [PictureFrame](https://reference.aspose.com/slides/th/java/com.aspose.slides/pictureframe/) หรือเติมรูปภาพลงในรูปร่างลายน้ำ `PictureFrame` ใช้อินเทอร์เฟซ [IShape](https://reference.aspose.com/slides/th/java/com.aspose.slides/ishape/) ทำให้คุณสามารถใช้การตั้งค่าที่ยืดหยุ่นทั้งหมดของอ็อบเจ็กต์รูปร่าง เนื่องจาก `ITextFrame` ไม่ใช่รูปร่างและการตั้งค่ามีจำกัด จึงถูกห่อหุ้มเป็นอ็อบเจ็กต์ [IShape](https://reference.aspose.com/slides/th/java/com.aspose.slides/ishape/)

มีสองวิธีในการใช้ลายน้ำ: บนสไลด์เดียวหรือบนสไลด์ทั้งหมดของการนำเสนอ Slide Master จะถูกใช้เพื่อใส่ลายน้ำบนสไลด์ทั้งหมด — ลายน้ำถูกเพิ่มลงใน Slide Master ออกแบบเต็มที่ที่นั้นและนำไปใช้กับทุกสไลด์โดยไม่ส่งผลต่อสิทธิ์การแก้ไขลายน้ำบนสไลด์แต่ละอัน

ลายน้ำมักถือว่าไม่สามารถแก้ไขได้โดยผู้ใช้คนอื่น ๆ เพื่อป้องกันไม่ให้ลายน้ำ (หรือรูปร่างพาเรนต์ของลายน้ำ) ถูกแก้ไข Aspose.Slides มีฟังก์ชันการล็อกรูปร่าง รูปร่างเฉพาะสามารถล็อกบนสไลด์ปกติหรือบน Slide Master เมื่อรูปร่างลายน้ำถูกล็อกบน Slide Master จะถูกล็อกบนสไลด์ทั้งหมดของการนำเสนอ

คุณสามารถตั้งชื่อให้กับลายน้ำ เพื่อให้ในอนาคตหากต้องการลบ คุณสามารถค้นหามันในรูปร่างของสไลด์โดยใช้ชื่อได้

คุณสามารถออกแบบลายน้ำได้ทุกแบบ; อย่างไรก็ตามลายน้ำมักมีคุณลักษณะร่วมกันเช่นการจัดกึ่งกลาง การหมุน การวางหน้า เป็นต้น เราจะพิจารณาวิธีใช้คุณลักษณะเหล่านี้ในตัวอย่างด้านล่าง

## **ลายน้ำข้อความ**

### **เพิ่มลายน้ำข้อความในสไลด์**

เพื่อเพิ่มลายน้ำข้อความใน PPT, PPTX หรือ ODP คุณสามารถเพิ่มรูปร่างลงในสไลด์ก่อน แล้วเพิ่มเฟรมข้อความลงในรูปร่างนั้น เฟรมข้อความถูกแทนด้วยอินเทอร์เฟซ [ITextFrame](https://reference.aspose.com/slides/th/java/com.aspose.slides/itextframe/) ประเภทนี้ไม่ได้สืบทอดจาก [IShape](https://reference.aspose.com/slides/th/java/com.aspose.slides/ishape/) ซึ่งมีชุดคุณสมบัติที่กว้างสำหรับการกำหนดตำแหน่งลายน้ำอย่างยืดหยุ่น ดังนั้นอ็อบเจ็กต์ [ITextFrame](https://reference.aspose.com/slides/th/java/com.aspose.slides/itextframe/) จะถูกห่อหุ้มในอ็อบเจ็กต์ [IAutoShape](https://reference.aspose.com/slides/th/java/com.aspose.slides/iautoshape/) เพื่อเพิ่มข้อความลายน้ำลงในรูปร่าง ใช้เมธอด [addTextFrame](https://reference.aspose.com/slides/th/java/com.aspose.slides/iautoshape/#addTextFrame-java.lang.String-) ตามตัวอย่างด้านล่าง

```java
import com.aspose.slides.*;

String watermarkText = "CONFIDENTIAL";

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

IAutoShape watermarkShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);
ITextFrame watermarkFrame = watermarkShape.addTextFrame(watermarkText);

presentation.dispose();
```

{{% alert color="info" title="See also" %}} 
- [วิธีใช้คลาส TextFrame](/slides/th/java/text-formatting/)
{{% /alert %}}

### **เพิ่มลายน้ำข้อความในงานนำเสนอ**

หากคุณต้องการเพิ่มลายน้ำข้อความให้กับงานนำเสนอทั้งหมด (คือทุกสไลด์พร้อมกัน) ให้เพิ่มลงใน [MasterSlide](https://reference.aspose.com/slides/th/java/com.aspose.slides/masterslide/) ส่วนตรรกะอื่น ๆ เหมือนกับการเพิ่มลายน้ำลงในสไลด์เดียว — สร้างอ็อบเจ็กต์ [IAutoShape](https://reference.aspose.com/slides/th/java/com.aspose.slides/iautoshape/) จากนั้นใช้เมธอด [addTextFrame](https://reference.aspose.com/slides/th/java/com.aspose.slides/iautoshape/#addTextFrame-java.lang.String-) เพื่อเพิ่มลายน้ำลงในรูปร่างนั้น

```java
import com.aspose.slides.*;

String watermarkText = "CONFIDENTIAL";

Presentation presentation = new Presentation();
IMasterSlide masterSlide = presentation.getMasters().get_Item(0);

IAutoShape watermarkShape = masterSlide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);
ITextFrame watermarkFrame = watermarkShape.addTextFrame(watermarkText);

presentation.dispose();
```

{{% alert color="info" title="See also" %}} 
- [วิธีใช้ Slide Master](/slides/th/java/slide-master/)
{{% /alert %}}

### **ตั้งค่าความโปร่งใสของรูปร่างลายน้ำ**

โดยค่าเริ่มต้น รูปร่างสี่เหลี่ยมจะมีการจัดรูปแบบด้วยสีเติมและสีเส้น ส่วนโค้ดต่อไปนี้ทำให้รูปร่างโปร่งแสง

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);
IAutoShape watermarkShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);

watermarkShape.getFillFormat().setFillType(FillType.NoFill);
watermarkShape.getLineFormat().getFillFormat().setFillType(FillType.NoFill);

presentation.dispose();
```

### **ตั้งค่าแบบอักษรสำหรับลายน้ำข้อความ**

คุณสามารถเปลี่ยนแบบอักษรของลายน้ำข้อความได้ตามตัวอย่างด้านล่าง

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);
IAutoShape watermarkShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);
ITextFrame watermarkFrame = watermarkShape.addTextFrame("CONFIDENTIAL");

IPortionFormat textFormat = watermarkFrame.getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat();
textFormat.setLatinFont(new FontData("Arial"));
textFormat.setFontHeight(50);

presentation.dispose();
```

### **ตั้งค่าสีข้อความลายน้ำ**

เพื่อกำหนดสีของข้อความลายน้ำให้ใช้โค้ดนี้

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);
IAutoShape watermarkShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);
ITextFrame watermarkFrame = watermarkShape.addTextFrame("CONFIDENTIAL");

int alpha = 150, red = 200, green = 200, blue = 200;

IFillFormat fillFormat = watermarkFrame.getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().getFillFormat();
fillFormat.setFillType(FillType.Solid);
fillFormat.getSolidFillColor().setColor(new Color(red, green, blue, alpha));

presentation.dispose();
```

### **จัดกึ่งกลางลายน้ำข้อความ**

สามารถจัดกึ่งกลางลายน้ำบนสไลด์ได้ โดยทำตามขั้นตอนต่อไปนี้

```java
import com.aspose.slides.*;
import java.awt.geom.Dimension2D;

String watermarkText = "CONFIDENTIAL";

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

Dimension2D slideSize = presentation.getSlideSize().getSize();

float watermarkWidth = 400;
float watermarkHeight = 40;
float watermarkX = ((float)slideSize.getWidth() - watermarkWidth) / 2;
float watermarkY = ((float)slideSize.getHeight() - watermarkHeight) / 2;

IAutoShape watermarkShape = slide.getShapes().addAutoShape(
        ShapeType.Rectangle, watermarkX, watermarkY, watermarkWidth, watermarkHeight);

ITextFrame watermarkFrame = watermarkShape.addTextFrame(watermarkText);

presentation.dispose();
```

รูปภาพด้านล่างแสดงผลลัพธ์สุดท้าย.

![ลายน้ำข้อความ](text_watermark.png)

## **ลายน้ำรูปภาพ**

### **เพิ่มลายน้ำรูปภาพในงานนำเสนอ**

เพื่อเพิ่มลายน้ำรูปภาพลงในสไลด์ของงานนำเสนอ คุณสามารถทำตามขั้นตอนต่อไปนี้

```java
import com.aspose.slides.*;
import java.io.FileInputStream;
import java.io.InputStream;

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);
IAutoShape watermarkShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);

InputStream imageStream = new FileInputStream("watermark.png");
IPPImage image = presentation.getImages().addImage(imageStream);

watermarkShape.getFillFormat().setFillType(FillType.Picture);
watermarkShape.getFillFormat().getPictureFillFormat().getPicture().setImage(image);
watermarkShape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch);

presentation.dispose();
```

### **ล็อกลายน้ำไม่ให้แก้ไขได้**

หากจำเป็นต้องป้องกันไม่ให้ลายน้ำถูกแก้ไข ให้ใช้เมธอด [IAutoShape.getAutoShapeLock](https://reference.aspose.com/slides/th/java/com.aspose.slides/iautoshape/#getAutoShapeLock--) บนรูปร่าง ด้วยคุณสมบัตินี้คุณสามารถป้องกันไม่ให้รูปร่างถูกเลือก ปรับขนาด ย้ายตำแหน่ง รวมกลุ่มกับองค์ประกอบอื่น ๆ ล็อกข้อความจากการแก้ไข และอื่น ๆ อีกมากมาย

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);
IAutoShape watermarkShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);

// ล็อกรูปร่างลายน้ำไม่ให้แก้ไข
watermarkShape.getAutoShapeLock().setSelectLocked(true);
watermarkShape.getAutoShapeLock().setSizeLocked(true);
watermarkShape.getAutoShapeLock().setTextLocked(true);
watermarkShape.getAutoShapeLock().setPositionLocked(true);
watermarkShape.getAutoShapeLock().setGroupingLocked(true);

presentation.dispose();
```

### **นำลายน้ำไปอยู่ด้านหน้า**

ใน Aspose.Slides การจัดลำดับ Z ของรูปร่างสามารถตั้งค่าได้ผ่านเมธอด [IShapeCollection.reorder](https://reference.aspose.com/slides/th/java/com.aspose.slides/ishapecollection/#reorder-int-com.aspose.slides.IShape-) วิธีนี้คุณต้องเรียกเมธอดจากรายการสไลด์ของงานนำเสนอและส่งอ้างอิงรูปร่างพร้อมหมายเลขลำดับให้เมธอดนั้น เพื่อที่จะนำรูปร่างไปอยู่ด้านหน้าหรือด้านหลังของสไลด์ ฟีเจอร์นี้มีประโยชน์อย่างยิ่งเมื่อคุณต้องการวางลายน้ำไว้ด้านหน้าในงานนำเสนอ

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);
IAutoShape watermarkShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);

int shapeCount = slide.getShapes().size();
slide.getShapes().reorder(shapeCount - 1, watermarkShape);

presentation.dispose();
```

### **ตั้งค่าการหมุนของลายน้ำ**

ต่อไปนี้เป็นตัวอย่างโค้ดที่แสดงวิธีปรับการหมุนของลายน้ำให้วางเป็นแนวทแยงมุมบนสไลด์

```java
import com.aspose.slides.*;
import java.awt.geom.Dimension2D;

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);
IAutoShape watermarkShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);

Dimension2D slideSize = presentation.getSlideSize().getSize();

double diagonalAngle = Math.atan((slideSize.getHeight() / slideSize.getWidth())) * 180 / Math.PI;

watermarkShape.setRotation((float)diagonalAngle);

presentation.dispose();
```

### **ตั้งชื่อให้ลายน้ำ**

Aspose.Slides อนุญาตให้คุณตั้งชื่อให้กับรูปร่าง โดยใช้ชื่อรูปร่างคุณสามารถเข้าถึงเพื่อแก้ไขหรือทำการลบในอนาคตได้ เพื่อกำหนดชื่อให้กับรูปร่างลายน้ำ ให้กำหนดค่าให้เมธอด [IAutoShape.setName](https://reference.aspose.com/slides/th/java/com.aspose.slides/ishape/#setName-java.lang.String-)

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);
IAutoShape watermarkShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);

watermarkShape.setName("watermark");

presentation.dispose();
```

### **ลบลายน้ำ**

เพื่อทำการลบรูปร่างลายน้ำ ให้ใช้เมธอด [IAutoShape.getName](https://reference.aspose.com/slides/th/java/com.aspose.slides/ishape/#getName--) เพื่อค้นหาในรูปร่างของสไลด์ จากนั้นส่งรูปร่างลายน้ำเข้าไปในเมธอด [IShapeCollection.remove](https://reference.aspose.com/slides/th/java/com.aspose.slides/ishapecollection/#remove-com.aspose.slides.IShape-)

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");

ISlide slide = presentation.getSlides().get_Item(0);

IShape[] slideShapes = slide.getShapes().toArray();
for (IShape shape : slideShapes) {
    if ("watermark".equals(shape.getName()))
    {
        slide.getShapes().remove(shape);
    }
}

presentation.dispose();
```

## **คำถามที่พบบ่อย**

### ลายน้ำคืออะไรและทำไมต้องใช้?

ลายน้ำคือการทับข้อความหรือรูปภาพบนสไลด์ที่ช่วยปกป้องทรัพย์สินทางปัญญา เพิ่มการจดจำแบรนด์ หรือป้องกันการใช้การนำเสนอโดยไม่ได้รับอนุญาต

### ฉันสามารถเพิ่มลายน้ำให้กับทุกสไลด์ในงานนำเสนอได้หรือไม่?

ได้, Aspose.Slides อนุญาตให้คุณเพิ่มลายน้ำให้กับทุกสไลด์ในงานนำเสนอโดยใช้โปรแกรม คุณสามารถวนลูปผ่านสไลด์ทั้งหมดและตั้งค่าลายน้ำสำหรับแต่ละสไลด์ได้

### ฉันจะปรับความโปร่งใสของลายน้ำอย่างไร?

คุณสามารถปรับความโปร่งใสของลายน้ำโดยแก้ไขการตั้งค่าการเติม ([getFillFormat](https://reference.aspose.com/slides/th/java/com.aspose.slides/shape/#getFillFormat--)) ของรูปร่าง เพื่อให้ลายน้ำดูอ่อนแอและไม่เบี่ยงเบนความสนใจจากเนื้อหาสไลด์

### รูปแบบภาพใดบ้างที่รองรับสำหรับลายน้ำ?

Aspose.Slides รองรับรูปแบบภาพหลายประเภท เช่น PNG, JPEG, GIF, BMP, SVG และอื่น ๆ

### ฉันสามารถปรับแต่งแบบอักษรและสไตล์ของลายน้ำข้อความได้หรือไม่?

ได้, คุณสามารถเลือกแบบอักษร, ขนาด, และสไตล์ใดก็ได้เพื่อให้เข้ากับการออกแบบของงานนำเสนอและรักษาความสอดคล้องของแบรนด์

### ฉันจะเปลียนตำแหน่งหรือการวางแนวของลายน้ำอย่างไร?

คุณสามารถปรับตำแหน่งและการวางแนวของลายน้ำโดยโปรแกรมได้ ด้วยการแก้ไขพิกัด, ขนาด, และคุณสมบัติการหมุนของรูปร่าง