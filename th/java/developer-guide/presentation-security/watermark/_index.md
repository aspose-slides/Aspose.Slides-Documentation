---
title: เพิ่มลายน้ำลงในงานนำเสนอด้วย Java
linktitle: ลายน้ำ
type: docs
weight: 40
url: /th/java/watermark/
keywords:
- ลายน้ำ
- ลายน้ำข้อความ
- ลายน้ำรูปภาพ
- เพิ่มลายน้ำ
- เปลี่ยนลายน้ำ
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
- งานนำเสนอ
- Java
- Aspose.Slides
description: "จัดการลายน้ำข้อความและลายน้ำรูปภาพในงานนำเสนอ PowerPoint และ OpenDocument ด้วย Java เพื่อแสดงถึงฉบับร่าง ข้อมูลที่เป็นความลับ ลิขสิทธิ์ และอื่น ๆ"
---
## **บทนำ**

**ลายน้ำ** ในงานนำเสนอคือแสตมป์ข้อความหรือภาพที่ใช้บนสไลด์หรือทั่วทั้งสไลด์ทั้งหมดของงานนำเสนอ โดยทั่วไปลายน้ำจะใช้เพื่อระบุว่าผลงานนั้นเป็นฉบับร่าง (เช่น ลายน้ำ “Draft”) หรือเป็นข้อมูลลับ (เช่น ลายน้ำ “Confidential”) เพื่อระบุกลุ่มบริษัทที่เป็นเจ้าของ (เช่น ลายน้ำ “Company Name”) เพื่อระบุผู้เขียนงานนำเสนอ ฯลฯ ลายน้ำช่วยป้องกันการละเมิดลิขสิทธิ์โดยบ่งบอกว่าห้ามคัดลอกงานนำเสนอ ลายน้ำถูกใช้ในรูปแบบ PowerPoint และ OpenOffice ทั้งสองรูปแบบใน Aspose.Slides คุณสามารถเพิ่มลายน้ำลงในไฟล์ PowerPoint PPT, PPTX และ OpenOffice ODP ได้

ใน [**Aspose.Slides**](https://products.aspose.com/slides/th/java/) มีหลายวิธีที่คุณสามารถสร้างลายน้ำในเอกสาร PowerPoint หรือ OpenOffice และปรับแต่งการออกแบบและพฤติกรรมของมัน ส่วนที่สำคัญคือเพื่อเพิ่มลายน้ำข้อความ คุณควรใช้อินเทอร์เฟซ [ITextFrame](https://reference.aspose.com/slides/th/java/com.aspose.slides/itextframe/) และเพื่อเพิ่มลายน้ำภาพ ใช้คลาส [PictureFrame](https://reference.aspose.com/slides/th/java/com.aspose.slides/pictureframe/) หรือเติมรูปร่างลายน้ำด้วยภาพ `PictureFrame` implements the [IShape](https://reference.aspose.com/slides/th/java/com.aspose.slides/ishape/) interface, allowing you to use all the flexible settings of the shape object. Since `ITextFrame` is not a shape and its settings are limited, it is wrapped into an [IShape](https://reference.aspose.com/slides/th/java/com.aspose.slides/ishape/) object.

มีสองวิธีในการใช้ลายน้ำ: กับสไลด์เดียวหรือกับสไลด์ทั้งหมดของงานนำเสนอ Slide Master จะถูกใช้เพื่อใช้ลายน้ำกับสไลด์ทั้งหมด — ลายน้ำจะถูกเพิ่มไปยัง Slide Master ออกแบบที่นั่นอย่างเต็มที่ แล้วนำไปใช้กับทุกสไลด์โดยไม่กระทบต่อสิทธิ์การแก้ไขลายน้ำบนสไลด์แต่ละอัน

ลายน้ำมักถือว่าไม่สามารถแก้ไขได้โดยผู้ใช้คนอื่น เพื่อป้องกันไม่ให้ลายน้ำ (หรือรูปร่างแม่ของลายน้ำ) ถูกแก้ไข Aspose.Slides มีฟังก์ชันการล็อครูปร่าง รูปร่างใด ๆ สามารถถูกล็อคบนสไลด์ปกติหรือบน Slide Master เมื่อรูปร่างลายน้ำถูกล็อคบน Slide Master จะถูกล็อคบนสไลด์ทั้งหมดของงานนำเสนอ

คุณสามารถตั้งชื่อให้กับลายน้ำได้ เพื่อให้ในอนาคตต้องการลบลายน้ำ สามารถค้นหารูปร่างโดยใช้ชื่อได้

คุณสามารถออกแบบลายน้ำได้ตามวิธีใดก็ได้; อย่างไรก็ตามโดยทั่วไปลายน้ำมักมีคุณสมบัติเช่น การจัดตำแหน่งศูนย์, การหมุน, การวางไว้ด้านหน้า เป็นต้น เราจะพิจารณาวิธีการใช้เหล่านี้ในตัวอย่างต่อไป

## **ลายน้ำข้อความ**

### **เพิ่มลายน้ำข้อความในสไลด์**

เพื่อเพิ่มลายน้ำข้อความใน PPT, PPTX หรือ ODP คุณสามารถเพิ่มรูปร่างไปยังสไลด์ก่อน แล้วเพิ่มเฟรมข้อความไปยังรูปร่างนั้น เฟรมข้อความแทนด้วยอินเทอร์เฟซ [ITextFrame](https://reference.aspose.com/slides/th/java/com.aspose.slides/itextframe/) ประเภทนี้ไม่ได้สืบทอดมาจาก [IShape](https://reference.aspose.com/slides/th/java/com.aspose.slides/ishape/) ซึ่งมีคุณสมบัติมากมายสำหรับการวางตำแหน่งลายน้ำในแบบยืดหยุ่น ดังนั้นอ็อบเจกต์ [ITextFrame](https://reference.aspose.com/slides/th/java/com.aspose.slides/itextframe/) จะถูกห่อในอ็อบเจกต์ [IAutoShape](https://reference.aspose.com/slides/th/java/com.aspose.slides/iautoshape/) เพื่อเพิ่มข้อความลายน้ำไปยังรูปร่าง ให้ใช้เมธอด [addTextFrame](https://reference.aspose.com/slides/th/java/com.aspose.slides/iautoshape/#addTextFrame-java.lang.String-) ตามตัวอย่างด้านล่าง

```java
String watermarkText = "CONFIDENTIAL";

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

IAutoShape watermarkShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);
ITextFrame watermarkFrame = watermarkShape.addTextFrame(watermarkText);

presentation.dispose();
```

{{% alert color="primary" title="See also" %}} 
- [วิธีใช้คลาส TextFrame](/slides/th/java/text-formatting/)
{{% /alert %}}

### **เพิ่มลายน้ำข้อความในพรีเซนเทชัน**

หากต้องการเพิ่มลายน้ำข้อความให้กับพรีเซนเทชันทั้งหมด (คือทุกสไลด์พร้อมกัน) ให้เพิ่มลงใน [MasterSlide](https://reference.aspose.com/slides/th/java/com.aspose.slides/masterslide/) ส่วนตรรกะที่เหลือเหมือนกับการเพิ่มลายน้ำในสไลด์เดียว — สร้างอ็อบเจกต์ [IAutoShape](https://reference.aspose.com/slides/th/java/com.aspose.slides/iautoshape/) แล้วเพิ่มลายน้ำโดยใช้เมธอด [addTextFrame](https://reference.aspose.com/slides/th/java/com.aspose.slides/iautoshape/#addTextFrame-java.lang.String-)

```java
String watermarkText = "CONFIDENTIAL";

Presentation presentation = new Presentation();
IMasterSlide masterSlide = presentation.getMasters().get_Item(0);

IAutoShape watermarkShape = masterSlide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);
ITextFrame watermarkFrame = watermarkShape.addTextFrame(watermarkText);

presentation.dispose();
```

{{% alert color="primary" title="See also" %}} 
- [วิธีใช้ Slide Master](/slides/th/java/slide-master/)
{{% /alert %}}

### **ตั้งค่าความโปร่งใสของรูปร่างลายน้ำ**

โดยค่าเริ่มต้นรูปร่างสี่เหลี่ยมจะมีสีเติมและสีเส้น โค้ดต่อไปนี้ทำให้รูปร่างโปร่งใส

```java
watermarkShape.getFillFormat().setFillType(FillType.NoFill);
watermarkShape.getLineFormat().getFillFormat().setFillType(FillType.NoFill);
```

### **ตั้งค่าฟอนต์สำหรับลายน้ำข้อความ**

คุณสามารถเปลี่ยนฟอนต์ของลายน้ำข้อความได้ตามด้านล่าง

```java
IPortionFormat textFormat = watermarkFrame.getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat();
textFormat.setLatinFont(new FontData("Arial"));
textFormat.setFontHeight(50);
```

### **ตั้งค่าสีข้อความลายน้ำ**

เพื่อกำหนดสีของข้อความลายน้ำ ให้ใช้โค้ดนี้

```java
int alpha = 150, red = 200, green = 200, blue = 200;

IFillFormat fillFormat = watermarkFrame.getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().getFillFormat();
fillFormat.setFillType(FillType.Solid);
fillFormat.getSolidFillColor().setColor(new Color(red, green, blue, alpha));
```

### **จัดกึ่งกลางลายน้ำข้อความ**

สามารถจัดกึ่งกลางลายน้ำบนสไลด์ได้โดยทำตามขั้นตอนต่อไปนี้

```java
Dimension2D slideSize = presentation.getSlideSize().getSize();

float watermarkWidth = 400;
float watermarkHeight = 40;
float watermarkX = ((float)slideSize.getWidth() - watermarkWidth) / 2;
float watermarkY = ((float)slideSize.getHeight() - watermarkHeight) / 2;

IAutoShape watermarkShape = slide.getShapes().addAutoShape(
        ShapeType.Rectangle, watermarkX, watermarkY, watermarkWidth, watermarkHeight);

ITextFrame watermarkFrame = watermarkShape.addTextFrame(watermarkText);
```

รูปด้านล่างแสดงผลลัพธ์สุดท้าย

![ลายน้ำข้อความ](text_watermark.png)

## **ลายน้ำรูปภาพ**

### **เพิ่มลายน้ำรูปภาพในพรีเซนเทชัน**

เพื่อเพิ่มลายน้ำรูปภาพในสไลด์ของพรีเซนเทชัน คุณสามารถทำตามขั้นตอนต่อไปนี้

```java
InputStream imageStream = new FileInputStream("watermark.png");
IPPImage image = presentation.getImages().addImage(imageStream);

watermarkShape.getFillFormat().setFillType(FillType.Picture);
watermarkShape.getFillFormat().getPictureFillFormat().getPicture().setImage(image);
watermarkShape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch);
```

### **ล็อกลายน้ำไม่ให้แก้ไข**

หากจำเป็นต้องป้องกันไม่ให้ลายน้ำถูกแก้ไข ให้ใช้เมธอด [IAutoShape.getAutoShapeLock](https://reference.aspose.com/slides/th/java/com.aspose.slides/iautoshape/#getAutoShapeLock--) บนรูปร่าง ด้วยคุณสมบัตินี้คุณสามารถป้องกันรูปร่างจากการเลือก, ปรับขนาด, ย้ายตำแหน่ง, รวมกลุ่มกับองค์ประกอบอื่น, ล็อกข้อความจากการแก้ไข และอื่น ๆ อีกมาก

```java
// ล็อครูปร่างลายน้ำไม่ให้แก้ไข
watermarkShape.getAutoShapeLock().setSelectLocked(true);
watermarkShape.getAutoShapeLock().setSizeLocked(true);
watermarkShape.getAutoShapeLock().setTextLocked(true);
watermarkShape.getAutoShapeLock().setPositionLocked(true);
watermarkShape.getAutoShapeLock().setGroupingLocked(true);
```

### **นำลายน้ำไปไว้ด้านหน้า**

ใน Aspose.Slides การจัดลำดับ Z ของรูปร่างสามารถตั้งค่าได้ผ่านเมธอด [IShapeCollection.reorder](https://reference.aspose.com/slides/th/java/com.aspose.slides/ishapecollection/#reorder-int-com.aspose.slides.IShape-) เพื่อทำเช่นนี้ให้เรียกเมธอดจากรายการสไลด์ของพรีเซนเทชันและส่งอ้างอิงรูปร่างพร้อมหมายเลขลำดับเข้าเมธอด วิธีนี้ทำให้คุณสามารถนำรูปร่างไปไว้ด้านหน้า หรือส่งไปด้านหลังของสไลด์ได้ ฟีเจอร์นี้มีประโยชน์เป็นพิเศษเมื่อคุณต้องการวางลายน้ำไว้ด้านหน้าของพรีเซนเทชัน

```java
int shapeCount = slide.getShapes().size();
slide.getShapes().reorder(shapeCount - 1, watermarkShape);
```

### **ตั้งค่าการหมุนของลายน้ำ**

ตัวอย่างโค้ดต่อไปนี้แสดงวิธีปรับการหมุนของลายน้ำให้วางตามแนวทแยงของสไลด์

```java
double diagonalAngle = Math.atan((slideSize.getHeight() / slideSize.getWidth())) * 180 / Math.PI;

watermarkShape.setRotation((float)diagonalAngle);
```

### **ตั้งชื่อให้ลายน้ำ**

Aspose.Slides อนุญาตให้คุณตั้งชื่อให้กับรูปร่างได้ โดยใช้ชื่อรูปร่างคุณสามารถเข้าถึงในอนาคตเพื่อแก้ไขหรือ حذف ได้ เพื่อกำหนดชื่อให้กับรูปร่างลายน้ำ ให้เรียกเมธอด [IAutoShape.setName](https://reference.aspose.com/slides/th/java/com.aspose.slides/ishape/#setName-java.lang.String-)

```java
watermarkShape.setName("watermark");
```

### **ลบลายน้ำ**

เพื่อเอารูปร่างลายน้ำออก ใช้เมธอด [IAutoShape.getName](https://reference.aspose.com/slides/th/java/com.aspose.slides/ishape/#getName--) เพื่อค้นหาในรูปร่างของสไลด์ จากนั้นส่งรูปร่างลายน้ำไปยังเมธอด [IShapeCollection.remove](https://reference.aspose.com/slides/th/java/com.aspose.slides/ishapecollection/#remove-com.aspose.slides.IShape-)

```java
IShape[] slideShapes = slide.getShapes().toArray();
for (IShape shape : slideShapes) {
    if ("watermark".equals(shape.getName()))
    {
        slide.getShapes().remove(watermarkShape);
    }
}
```

## **คำถามที่พบบ่อย**

**ลายน้ำคืออะไรและทำไมต้องใช้?**

ลายน้ำคือภาพซ้อนข้อความหรือรูปภาพที่ใช้บนสไลด์เพื่อช่วยปกป้องทรัพย์สินทางปัญญา เสริมการจดจำแบรนด์ หรือป้องกันการใช้งานนำเสนอโดยไม่ได้รับอนุญาต

**ฉันสามารถเพิ่มลายน้ำให้กับสไลด์ทั้งหมดในพรีเซนเทชันได้หรือไม่?**

ได้, Aspose.Slides อนุญาตให้คุณเพิ่มลายน้ำให้กับทุกสไลด์ในพรีเซนเทชันได้โดยใช้โค้ดโปรแกรม คุณสามารถวนลูปผ่านสไลด์ทั้งหมดและตั้งค่าลายน้ำให้แต่ละสไลด์ได้

**ฉันจะปรับความโปร่งใสของลายน้ำอย่างไร?**

คุณสามารถปรับความโปร่งใสของลายน้ำได้โดยแก้ไขการตั้งค่าเติมสี ([getFillFormat](https://reference.aspose.com/slides/th/java/com.aspose.slides/shape/#getFillFormat--)) ของรูปร่าง ซึ่งทำให้ลายน้ำดูอ่อนละมุนและไม่เป็นการรบกวนเนื้อหาสไลด์

**รูปแบบภาพใดบ้างที่สนับสนุนสำหรับลายน้ำ?**

Aspose.Slides รองรับรูปแบบภาพต่าง ๆ เช่น PNG, JPEG, GIF, BMP, SVG และอื่น ๆ

**ฉันสามารถปรับแต่งฟอนต์และสไตล์ของลายน้ำข้อความได้หรือไม่?**

ได้, คุณสามารถเลือกฟอนต์, ขนาด, และสไตล์ใดก็ได้เพื่อให้สอดคล้องกับการออกแบบพรีเซนเทชันและรักษาความสอดคล้องของแบรนด์

**ฉันจะเปลี่ยนตำแหน่งหรือการวางแนวของลายน้ำอย่างไร?**

คุณสามารถปรับตำแหน่งและการวางแนวของลายน้ำด้วยโค้ดโดยแก้ไขพิกัด, ขนาด, และคุณสมบัติการหมุนของรูปร่างได้