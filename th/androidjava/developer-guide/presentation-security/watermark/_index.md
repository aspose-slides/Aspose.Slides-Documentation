---
title: เพิ่มลายน้ำไปยังงานนำเสนอบน Android
linktitle: ลายน้ำ
type: docs
weight: 40
url: /th/androidjava/watermark/
keywords:
- ลายน้ำ
- ลายน้ำข้อความ
- ลายน้ำภาพ
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
- Android
- Java
- Aspose.Slides
description: "จัดการลายน้ำข้อความและภาพในงานนำเสนอ PowerPoint และ OpenDocument บน Android ด้วย Java เพื่อระบุร่าง ข้อมูลลับ และอื่น ๆ"
---
## **บทนำ**

**ลายน้ำ** ในงานนำเสนอคือสตั๊มข้อความหรือภาพที่ใช้บนสไลด์หรือทั้งหมดของสไลด์การนำเสนอ โดยปกติแล้วลายน้ำจะใช้เพื่อบ่งบอกว่างานนำเสนอเป็นฉบับร่าง (เช่น ลายน้ำ “Draft”) มีข้อมูลที่เป็นความลับ (เช่น ลายน้ำ “Confidential”) เพื่อระบุว่าข้อมูลเป็นของบริษัทใด (เช่น ลายน้ำ “Company Name”) หรือระบุตัวผู้เขียนงานนำเสนอ ฯลฯ ลายน้ำช่วยป้องกันการละเมิดลิขสิทธิ์โดยบ่งบอกว่างานนำเสนอไม่ควรคัดลอก ลายน้ำใช้ได้ทั้งรูปแบบ PowerPoint และ OpenOffice ใน Aspose.Slides คุณสามารถเพิ่มลายน้ำให้กับไฟล์รูปแบบ PowerPoint PPT, PPTX และ OpenOffice ODP ได้

ใน [**Aspose.Slides**](https://products.aspose.com/slides/th/android-java/) มีวิธีการหลายวิธีเพื่อสร้างลายน้ำในเอกสาร PowerPoint หรือ OpenOffice และปรับเปลี่ยนการออกแบบและพฤติกรรมของลายน้ำ ประเด็นร่วมคือการเพิ่มลายน้ำข้อความควรใช้อินเทอร์เฟซ [ITextFrame](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/itextframe/) และการเพิ่มลายน้ำภาพควรใช้คลาส [PictureFrame](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/pictureframe/) หรือเติมรูปร่างลายน้ำด้วยภาพ `PictureFrame` ทำการ implements อินเทอร์เฟซ [IShape](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ishape/) ทำให้คุณสามารถใช้การตั้งค่าที่ยืดหยุ่นทั้งหมดของวัตถุรูปร่างได้ เนื่องจาก `ITextFrame` ไม่ใช่รูปร่างและการตั้งค่าของมันจำกัด จึงถูกห่อหุ้มเป็นอ็อบเจกต์ [IShape](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ishape/)

มีสองวิธีในการใช้ลายน้ำ: กับสไลด์เดียวหรือกับสไลด์ทั้งหมดของการนำเสนอ Slide Master ถูกใช้เพื่อใช้ลายน้ำกับสไลด์ทั้งหมด — ลายน้ำถูกเพิ่มลงใน Slide Master ออกแบบที่นั่นอย่างสมบูรณ์ และจะถูกประยุกต์ใช้กับทุกสไลด์โดยไม่กระทบต่อสิทธิ์การแก้ไขลายน้ำในสไลด์แต่ละสไลด์

โดยทั่วไปลายน้ำถือว่าหนักต่อการแก้ไขโดยผู้ใช้คนอื่น เพื่อป้องกันไม่ให้ลายน้ำ (หรือรูปร่างแม่ของลายน้ำ) ถูกแก้ไข Aspose.Slides มีฟังก์ชันการล็อกรูปร่าง ซึ่งสามารถล็อกรูปร่างเฉพาะบนสไลด์ปกติหรือบน Slide Master เมื่อรูปร่างลายน้ำถูกล็อกบน Slide Master จะถูกล็อกบนสไลด์ทั้งหมดของการนำเสนอ

คุณสามารถกำหนดชื่อให้กับลายน้ำเพื่อให้ในภายหลัง หากต้องการลบสามารถค้นหาโดยใช้ชื่อในรายการรูปร่างของสไลด์ได้

คุณสามารถออกแบบลายน้ำได้ทุกรูปแบบ; อย่างไรก็ตามลายน้ำมักมีคุณลักษณะร่วมเช่น การจัดกึ่งกลาง การหมุน การนำไปอยู่หน้าต่างหน้า ฯลฯ เราจะพิจารณาวิธีใช้เหล่านี้ในตัวอย่างต่อไป

## **ลายน้ำข้อความ**

### **เพิ่มลายน้ำข้อความลงในสไลด์**

เพื่อเพิ่มลายน้ำข้อความใน PPT, PPTX หรือ ODP คุณสามารถเพิ่มรูปร่างลงในสไลด์ก่อน จากนั้นเพิ่มกรอบข้อความลงในรูปร่างนั้น กรอบข้อความแสดงด้วยอินเทอร์เฟซ [ITextFrame](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/itextframe/) ซึ่งไม่สืบทอดจาก [IShape](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ishape/) ที่มีคุณสมบัติหลายอย่างสำหรับการวางตำแหน่งลายน้ำอย่างยืดหยุ่น ดังนั้นอ็อบเจกต์ [ITextFrame](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/itextframe/) จึงถูกห่อหุ้มในอ็อบเจกต์ [IAutoShape](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iautoshape/) เพื่อเพิ่มข้อความลายน้ำลงในรูปร่าง ให้ใช้เมธอด [addTextFrame](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iautoshape/#addTextFrame-java.lang.String-) ตามตัวอย่างด้านล่าง

```java
String watermarkText = "CONFIDENTIAL";

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

IAutoShape watermarkShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);
ITextFrame watermarkFrame = watermarkShape.addTextFrame(watermarkText);

presentation.dispose();
```

{{% alert color="primary" title="ดูเพิ่มเติม" %}} 
- [วิธีใช้คลาส TextFrame](/slides/th/androidjava/text-formatting/)
{{% /alert %}}

### **เพิ่มลายน้ำข้อความลงในงานนำเสนอ**

หากต้องการเพิ่มลายน้ำข้อความให้กับงานนำเสนอทั้งหมด (คือทุกสไลด์พร้อมกัน) ให้เพิ่มลงใน [MasterSlide](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/masterslide/) ส่วนโลจิกที่เหลือเหมือนกับการเพิ่มลายน้ำในสไลด์เดียว — สร้างอ็อบเจกต์ [IAutoShape](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iautoshape/) แล้วเพิ่มลายน้ำลงโดยใช้เมธอด [addTextFrame](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iautoshape/#addTextFrame-java.lang.String-)

```java
String watermarkText = "CONFIDENTIAL";

Presentation presentation = new Presentation();
IMasterSlide masterSlide = presentation.getMasters().get_Item(0);

IAutoShape watermarkShape = masterSlide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);
ITextFrame watermarkFrame = watermarkShape.addTextFrame(watermarkText);

presentation.dispose();
```

{{% alert color="primary" title="ดูเพิ่มเติม" %}} 
- [วิธีใช้ Slide Master](/slides/th/androidjava/slide-master/)
{{% /alert %}}

### **ตั้งค่าความโปร่งใสของรูปร่างลายน้ำ**

โดยค่าเริ่มต้น รูปร่างสี่เหลี่ยมจะมีสีเติมและสีเส้น โค้ดด้านล่างทำให้รูปร่างโปร่งใส

```java
watermarkShape.getFillFormat().setFillType(FillType.NoFill);
watermarkShape.getLineFormat().getFillFormat().setFillType(FillType.NoFill);
```

### **ตั้งค่าแบบอักษรสำหรับลายน้ำข้อความ**

คุณสามารถเปลี่ยนแบบอักษรของลายน้ำข้อความได้ดังตัวอย่างต่อไปนี้

```java
IPortionFormat textFormat = watermarkFrame.getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat();
textFormat.setLatinFont(new FontData("Arial"));
textFormat.setFontHeight(50);
```

### **ตั้งค่าสีข้อความของลายน้ำ**

เพื่อกำหนดสีของข้อความลายน้ำ ใช้โค้ดนี้

```java
int alpha = 150, red = 200, green = 200, blue = 200;

IFillFormat fillFormat = watermarkFrame.getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().getFillFormat();
fillFormat.setFillType(FillType.Solid);
fillFormat.getSolidFillColor().setColor(Color.argb(alpha, red, green, blue));
```

### **จัดกึ่งกลางลายน้ำข้อความ**

คุณสามารถจัดกึ่งกลางลายน้ำบนสไลด์ได้โดยทำตามขั้นตอนต่อไปนี้

```java
SizeF slideSize = presentation.getSlideSize().getSize();

float watermarkWidth = 400;
float watermarkHeight = 40;
float watermarkX = ((float)slideSize.getWidth() - watermarkWidth) / 2;
float watermarkY = ((float)slideSize.getHeight() - watermarkHeight) / 2;

IAutoShape watermarkShape = slide.getShapes().addAutoShape(
        ShapeType.Rectangle, watermarkX, watermarkY, watermarkWidth, watermarkHeight);

ITextFrame watermarkFrame = watermarkShape.addTextFrame(watermarkText);
```

ภาพด้านล่างแสดงผลลัพธ์สุดท้าย

![The text watermark](text_watermark.png)

## **ลายน้ำภาพ**

### **เพิ่มลายน้ำภาพลงในงานนำเสนอ**

เพื่อเพิ่มลายน้ำภาพลงในสไลด์งานนำเสนอ สามารถทำตามขั้นตอนต่อไปนี้

```java
InputStream imageStream = new FileInputStream("watermark.png");
IPPImage image = presentation.getImages().addImage(imageStream);

watermarkShape.getFillFormat().setFillType(FillType.Picture);
watermarkShape.getFillFormat().getPictureFillFormat().getPicture().setImage(image);
watermarkShape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch);
```

### **ล็อกลายน้ำไม่ให้แก้ไข**

หากต้องการป้องกันไม่ให้ลายน้ำถูกแก้ไข ใช้เมธอด [IAutoShape.getAutoShapeLock](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iautoshape/#getAutoShapeLock--) บนรูปร่าง ด้วยคุณสมบัตินี้คุณสามารถปกป้องรูปร่างจากการถูกเลือก การปรับขนาด การย้ายตำแหน่ง การรวมกลุ่มกับองค์ประกอบอื่น ๆ การล็อกข้อความจากการแก้ไข ฯลฯ

```java
// ล็อกรูปร่างลายน้ำจากการแก้ไข
watermarkShape.getAutoShapeLock().setSelectLocked(true);
watermarkShape.getAutoShapeLock().setSizeLocked(true);
watermarkShape.getAutoShapeLock().setTextLocked(true);
watermarkShape.getAutoShapeLock().setPositionLocked(true);
watermarkShape.getAutoShapeLock().setGroupingLocked(true);
```

### **นำลายน้ำไปอยู่หน้าตรงหน้า**

ใน Aspose.Slides ลำดับชั้น Z ของรูปร่างสามารถกำหนดได้ผ่านเมธอด [IShapeCollection.reorder](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ishapecollection/#reorder-int-com.aspose.slides.IShape-) โดยเรียกเมธอดนี้จากรายการสไลด์ของงานนำเสนอและส่งอ้างอิงรูปร่างและลำดับที่ต้องการเข้าไป วิธีนี้ทำให้สามารถนำรูปร่างไปอยู่หน้าตรงหน้า หรือย้ายไปอยู่หลังสุดของสไลด์ได้ ฟีเจอร์นี้มีประโยชน์โดยเฉพาะเมื่อคุณต้องการให้ลายน้ำอยู่หน้าตรงหน้าของการนำเสนอ

```java
int shapeCount = slide.getShapes().size();
slide.getShapes().reorder(shapeCount - 1, watermarkShape);
```

### **ตั้งค่าการหมุนของลายน้ำ**

ตัวอย่างโค้ดต่อไปนี้แสดงวิธีปรับการหมุนของลายน้ำเพื่อให้วางเป็นแนวทแยงบนสไลด์

```java
double diagonalAngle = Math.atan((slideSize.getHeight() / slideSize.getWidth())) * 180 / Math.PI;

watermarkShape.setRotation((float)diagonalAngle);
```

### **กำหนดชื่อให้กับลายน้ำ**

Aspose.Slides อนุญาตให้คุณตั้งชื่อให้กับรูปร่างโดยใช้ชื่อรูปร่างคุณสามารถเข้าถึงในภายหลังเพื่อแก้ไขหรือทำลบได้ เพื่อตั้งชื่อรูปร่างลายน้ำ ให้กำหนดชื่อผ่านเมธอด [IAutoShape.setName](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ishape/#setName-java.lang.String-)

```java
watermarkShape.setName("watermark");
```

### **ลบลายน้ำ**

เพื่อเอารูปร่างลายน้ำออก ให้ใช้เมธอด [IAutoShape.getName](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ishape/#getName--) ค้นหารูปร่างในสไลด์ แล้วส่งรูปร่างลายน้ำเข้าเมธอด [IShapeCollection.remove](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ishapecollection/#remove-com.aspose.slides.IShape-)

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

**ลายน้ำคืออะไรและทำไมถึงควรใช้?**

ลายน้ำคือการซ้อนข้อความหรือภาพบนสไลด์ที่ช่วยปกป้องทรัพย์สินทางปัญญา เพิ่มการรับรู้แบรนด์ หรือป้องกันการใช้งานงานนำเสนอโดยไม่ได้รับอนุญาต

**ฉันสามารถเพิ่มลายน้ำให้กับทุกสไลด์ในงานนำเสนอได้หรือไม่?**

ได้, Aspose.Slides ให้คุณเพิ่มลายน้ำให้กับทุกสไลด์ของงานนำเสนอโดยใช้โค้ด คุณสามารถวนลูปทุกสไลด์และกำหนดค่าลายน้ำแต่ละสไลด์ได้

**ฉันจะปรับความโปร่งใสของลายน้ำได้อย่างไร?**

คุณสามารถปรับความโปร่งใสของลายน้ำโดยการแก้ไขการตั้งค่าการเติม ([getFillFormat](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/shape/#getFillFormat--)) ของรูปร่าง ซึ่งทำให้ลายน้ำดูบางเบาและไม่รบกวนเนื้อหาในสไลด์

**ลายน้ำรองรับรูปแบบภาพใดบ้าง?**

Aspose.Slides รองรับรูปแบบภาพต่าง ๆ เช่น PNG, JPEG, GIF, BMP, SVG และอื่น ๆ

**ฉันสามารถปรับแต่งแบบอักษรและสไตล์ของลายน้ำข้อความได้หรือไม่?**

ได้, คุณสามารถเลือกแบบอักษร, ขนาด, และสไตล์ใดก็ได้เพื่อให้ตรงกับการออกแบบของงานนำเสนอและรักษาความสอดคล้องของแบรนด์

**ฉันจะเปลี่ยนตำแหน่งหรือทิศทางของลายน้ำอย่างไร?**

คุณสามารถปรับตำแหน่งและทิศทางของลายน้ำโดยใช้โค้ดโดยแก้ไขพิกัด, ขนาด, และคุณสมบัติการหมุนของรูปร่างได้