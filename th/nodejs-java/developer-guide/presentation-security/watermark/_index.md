---
title: เพิ่มลายน้ำในงานนำเสนอด้วย JavaScript
linktitle: ลายน้ำ
type: docs
weight: 40
url: /th/nodejs-java/watermark/
keywords:
- ลายน้ำ
- ลายน้ำข้อความ
- ลายน้ำภาพ
- เพิ่มลายน้ำ
- แก้ไขลายน้ำ
- นำลายน้ำออก
- ลบลายน้ำ
- เพิ่มลายน้ำลงใน PPT
- เพิ่มลายน้ำลงใน PPTX
- เพิ่มลายน้ำลงใน ODP
- นำลายน้ำออกจาก PPT
- นำลายน้ำออกจาก PPTX
- นำลายน้ำออกจาก ODP
- ลบลายน้ำจาก PPT
- ลบลายน้ำจาก PPTX
- ลบลายน้ำจาก ODP
- PowerPoint
- OpenDocument
- การนำเสนอ
- Node.js
- JavaScript
- Aspose.Slides
description: "จัดการลายน้ำข้อความและลายน้ำภาพในงานนำเสนอ PowerPoint และ OpenDocument ด้วย Node.js เพื่อระบุสถานะร่าง ข้อมูลที่เป็นความลับ ลิขสิทธิ์ และอื่น ๆ"
---
## **บทนำ**

**A watermark** ในการนำเสนอคือสติ๊กเกอร์ข้อความหรือภาพที่ใช้บนสไลด์หรือทั่วทั้งสไลด์การนำเสนอ โดยทั่วไป ลายน้ำจะใช้เพื่อบ่งบอกว่าการนำเสนอยังอยู่ในขั้นร่าง (เช่น ลายน้ำ “Draft”) หรือมีข้อมูลที่เป็นความลับ (เช่น ลายน้ำ “Confidential”) เพื่อระบุว่าเป็นของบริษัทใด (เช่น ลายน้ำ “Company Name”) หรือเพื่อระบุตัวผู้เขียนการนำเสนอ ฯลฯ ลายน้ำช่วยป้องกันการละเมิดลิขสิทธิ์โดยบ่งบอกว่าการนำเสนอไม่ควรถูกคัดลอก ลายน้ำสามารถใช้ได้ทั้งในรูปแบบไฟล์ PowerPoint และ OpenOffice การใช้ Aspose.Slides คุณสามารถเพิ่มลายน้ำให้กับไฟล์ PowerPoint PPT, PPTX และไฟล์ OpenOffice ODP ได้

ใน[**Aspose.Slides**](https://products.aspose.com/slides/th/nodejs-java/) มีวิธีต่าง ๆ ที่คุณสามารถสร้างลายน้ำในเอกสาร PowerPoint หรือ OpenOffice และปรับเปลี่ยนการออกแบบและพฤติกรรมของลายน้ำได้ ส่วนที่สากลคือการเพิ่มลายน้ำข้อความ คุณควรใช้ประเภท[TextFrame](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/textframe/) และการเพิ่มลายน้ำภาพใช้คลาส[PictureFrame](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/pictureframe/) หรือเติมรูปภาพลงในรูปร่างลายน้ำ `PictureFrame` ทำการ implements ประเภท[Shape](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/shape/) ทำให้คุณใช้การตั้งค่าที่ยืดหยุ่นทั้งหมดของอ็อบเจ็กต์ Shape ได้ เนื่องจาก `TextFrame` ไม่ได้เป็น Shape และการตั้งค่าของมันมีข้อจำกัด จึงถูกห่อหุ้มไว้ในอ็อบเจ็กต์[Shape](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/shape/)

มีสองวิธีในการใช้ลายน้ำ: ให้กับสไลด์เดียวหรือให้กับสไลด์ทั้งหมดของการนำเสนอ Slide Master จะถูกใช้เพื่อเพิ่มลายน้ำให้กับสไลด์ทั้งหมด — ลายน้ำจะถูกเพิ่มเข้าไปใน Slide Master ออกแบบที่นั่นอย่างเต็มที่ และจะถูกใช้กับสไลด์ทั้งหมดโดยไม่กระทบต่อสิทธิ์การแก้ไขลายน้ำบนสไลด์แต่ละอัน

ลายน้ำมักจะถือว่าไม่สามารถแก้ไขได้โดยผู้ใช้อื่น ๆ เพื่อป้องกันไม่ให้ลายน้ำ (หรือรูปร่างแม่ของลายน้ำ) ถูกแก้ไข Aspose.Slides มีฟังก์ชันการล็อกรูปร่าง คุณสามารถล็อกรูปร่างเฉพาะบนสไลด์ปกติหรือบน Slide Master ได้ เมื่อรูปร่างลายน้ำถูกล็อกบน Slide Master มันจะถูกล็อกบนสไลด์ทั้งหมดของการนำเสนอ

คุณสามารถตั้งชื่อให้กับลายน้ำเพื่อว่าหากต้องการลบในภายหลัง คุณจะสามารถค้นหารูปร่างนั้นในสไลด์โดยใช้ชื่อนั้นได้

คุณสามารถออกแบบลายน้ำได้ทุกแบบ; อย่างไรก็ตามลักษณะทั่วไปของลายน้ำมักจะมีการจัดกึ่งกลาง, การหมุน, อยู่ด้านหน้าสไลด์ เป็นต้น เราจะพิจารณาวิธีใช้เหล่านี้ในตัวอย่างต่อไป

## **ลายน้ำข้อความ**

### **เพิ่มลายน้ำข้อความไปยังสไลด์**
เพื่อเพิ่มลายน้ำข้อความใน PPT, PPTX หรือ ODP คุณสามารถเพิ่มรูปร่างลงบนสไลด์ก่อน แล้วเพิ่ม TextFrame ลงในรูปร่างนั้น TextFrame แสดงด้วยประเภท[**TextFrame**](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/TextFrame) ประเภทนี้ไม่ได้สืบทอดจาก[Shape](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/Shape) ซึ่งมีคุณสมบัติกว้างขวางในการกำหนดตำแหน่งลายน้ำอย่างยืดหยุ่น ดังนั้นอ็อบเจ็กต์[TextFrame](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/TextFrame) จะถูกห่อหุ้มไว้ในอ็อบเจ็กต์[AutoShape](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/AutoShape) เพื่อเพิ่มข้อความลายน้ำลงในรูปร่าง ให้ใช้เมธอด[**addTextFrame**](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/AutoShape#addTextFrame-java.lang.String-) พร้อมข้อความลายน้ำที่ส่งเข้าไป:

```javascript
const watermarkText = "CONFIDENTIAL";

let presentation = new aspose.slides.Presentation();
let slide = presentation.getSlides().get_Item(0);

let watermarkShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 400, 40);
let watermarkFrame = watermarkShape.addTextFrame(watermarkText);

presentation.dispose();
```

{{% alert color="primary" title="ดูเพิ่มเติม" %}} 
- วิธีการใช้ [TextFrame](/slides/th/nodejs-java/text-formatting/).
{{% /alert %}}

### **เพิ่มลายน้ำข้อความไปยังการนำเสนอ**

หากต้องการเพิ่มลายน้ำข้อความไปยังการนำเสนอทั้งหมด (เช่น ทุกสไลด์พร้อมกัน) ให้เพิ่มลงใน[**MasterSlide**](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/MasterSlide) ส่วนของตรรกะที่เหลือเหมือนกับการเพิ่มลายน้ำไปยังสไลด์เดียว — สร้างอ็อบเจ็กต์[AutoShape](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/AutoShape) แล้วใช้เมธอด[**addTextFrame**](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/AutoShape#addTextFrame-java.lang.String-) เพื่อนำลายน้ำลงในนั้น:

```javascript
const watermarkText = "CONFIDENTIAL";

let presentation = new aspose.slides.Presentation();
let masterSlide = presentation.getMasters().get_Item(0);

let watermarkShape = masterSlide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 400, 40);
let watermarkFrame = watermarkShape.addTextFrame(watermarkText);

presentation.dispose();
```

{{% alert color="primary" title="ดูเพิ่มเติม" %}} 
- [วิธีการใช้ ](/slides/th/nodejs-java/slide-master/)[Slide Master](/slides/th/nodejs-java/slide-master/)
{{% /alert %}}

### **ตั้งค่าการโปร่งใสของรูปร่างลายน้ำ**

โดยค่าเริ่มต้น รูปร่างสี่เหลี่ยมจะถูกกำหนดสีเติมและสีเส้น บรรทัดของโค้ดต่อไปนี้ทำให้รูปร่างโปร่งใส

```javascript
watermarkShape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
watermarkShape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
```

### **ตั้งค่าแบบอักษรสำหรับลายน้ำข้อความ**

คุณสามารถเปลี่ยนแบบอักษรของลายน้ำข้อความได้ดังตัวอย่างด้านล่าง

```javascript
let textFormat = watermarkFrame.getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat();
textFormat.setLatinFont(new aspose.slides.FontData("Arial"));
textFormat.setFontHeight(50);
```

### **ตั้งค่าสีข้อความลายน้ำ**

เพื่อกำหนดสีของข้อความลายน้ำ ให้ใช้โค้ดนี้

```java
let alpha = 150;
let red = 200;
let green = 200;
let blue = 200;

let fillFormat = watermarkFrame.getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().getFillFormat();
fillFormat.setFillType(java.newByte(aspose.slides.FillType.Solid));
fillFormat.getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", red, green, blue, alpha));
```

### **จัดกึ่งกลางลายน้ำข้อความ**
คุณสามารถจัดกึ่งกลางลายน้ำบนสไลด์ได้โดยทำตามขั้นตอนต่อไปนี้:

```javascript
const watermarkWidth = 400;
const watermarkHeight = 40;
const watermarkX = (slideSize.getWidth() - watermarkWidth) / 2;
const watermarkY = (slideSize.getHeight() - watermarkHeight) / 2;

let watermarkShape = masterSlide.getShapes().addAutoShape(
        aspose.slides.ShapeType.Rectangle, watermarkX, watermarkY, watermarkWidth, watermarkHeight);
        
let watermarkFrame = watermarkShape.addTextFrame(watermarkText);
```

รูปภาพด้านล่างแสดงผลลัพธ์สุดท้าย

![ลายน้ำข้อความ](text_watermark.png)

## **ลายน้ำภาพ**

### **เพิ่มลายน้ำภาพไปยังการนำเสนอ**

เพื่อเพิ่มลายน้ำภาพให้กับสไลด์ทั้งหมดของการนำเสนอ คุณสามารถทำตามขั้นตอนต่อไปนี้:

```javascript
let watermarkImage = aspose.slides.Images.fromFile("watermark.png");
let image = presentation.getImages().addImage(watermarkImage);

// ...

watermarkShape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Picture));
watermarkShape.getFillFormat().getPictureFillFormat().getPicture().setImage(image);
watermarkShape.getFillFormat().getPictureFillFormat().setPictureFillMode(aspose.slides.PictureFillMode.Stretch);
```

### **ล็อกลายน้ำไม่ให้แก้ไข**

หากต้องการป้องกันไม่ให้ลายน้ำถูกแก้ไข ให้ใช้เมธอด[**AutoShape.getShapeLock**](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/AutoShape#getShapeLock--) บนรูปร่าง ด้วยคุณสมบัตินี้คุณสามารถป้องกันการเลือก, ปรับขนาด, ย้ายตำแหน่ง, รวมกลุ่มกับองค์ประกอบอื่น, ล็อกข้อความจากการแก้ไข และอื่น ๆ อีกมากมาย:

```javascript
// ล็อกรูปร่างลายน้ำจากการแก้ไข
watermarkShape.getShapeLock().setSelectLocked(true);
watermarkShape.getShapeLock().setSizeLocked(true);
watermarkShape.getShapeLock().setTextLocked(true);
watermarkShape.getShapeLock().setPositionLocked(true);
watermarkShape.getShapeLock().setGroupingLocked(true);
```

### **นำลายน้ำไปไว้ด้านหน้า**

ใน Aspose.Slides สามารถกำหนดลำดับ Z ของรูปร่างได้ผ่านเมธอด[**SlideCollection.reorder**](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/SlideCollection#reorder-int-aspose.slides.ISlide...-) โดยเรียกเมธอดนี้จากรายการสไลด์ของการนำเสนอและส่งอ้างอิงรูปร่างพร้อมหมายเลขลำดับเข้าไป วิธีนี้ทำให้คุณสามารถนำรูปร่างไปไว้ด้านหน้าหรือส่งไปไว้ด้านหลังของสไลด์ได้ ซึ่งมีประโยชน์เป็นพิเศษเมื่อคุณต้องการวางลายน้ำไว้ด้านหน้าการนำเสนอ:

```javascript
let shapeCount = slide.getShapes().size();
slide.getShapes().reorder(shapeCount - 1, watermarkShape);
```

### **ตั้งค่าการหมุนของลายน้ำ**

ต่อไปนี้เป็นตัวอย่างโค้ดที่แสดงวิธีปรับการหมุนของลายน้ำให้วางแนวทแยงมุมบนสไลด์:

```javascript
const diagonalAngle = Math.atan(slideSize.getHeight() / slideSize.getWidth()) * 180 / Math.PI;

watermarkShape.setRotation(diagonalAngle);
```

### **ตั้งชื่อให้กับลายน้ำ**

Aspose.Slides อนุญาตให้คุณตั้งชื่อตัวรูปร่างได้ โดยใช้ชื่อนี้คุณสามารถเข้าถึงและแก้ไขหรือทำการลบในภายหลัง เพื่อกำหนดชื่อให้กับรูปร่างลายน้ำ ให้กำหนดค่าให้เมธอด[**AutoShape.getName**](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/Shape#getName--) :

```javascript
watermarkShape.setName("watermark");
```

### **ลบลายน้ำ**

เพื่อทำการลบรูปร่างลายน้ำ ใช้เมธอด[AutoShape.getName](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/Shape#getName--) เพื่อค้นหาในรูปร่างของสไลด์ แล้วส่งรูปร่างลายน้ำเข้าเมธอด[**ShapeCollection.remove**](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/ShapeCollection#remove-aspose.slides.IShape-) :

```javascript
for (var i = 0; i < slide.getShapes().size(); i++) {
    var shape = slide.getShapes().get_Item(i);
    if ("watermark" == shape.getName()) {
        slide.getShapes().remove(watermarkShape);
    }
}
```

## **คำถามที่พบบ่อย**

**ลายน้ำคืออะไรและทำไมจึงควรใช้?**

ลายน้ำคือการซ้อนข้อความหรือภาพบนสไลด์ที่ช่วยปกป้องทรัพย์สินทางปัญญา เพิ่มการรับรู้แบรนด์ หรือป้องกันการใช้การนำเสนอโดยไม่ได้รับอนุญาต

**ฉันสามารถเพิ่มลายน้ำให้กับสไลด์ทั้งหมดในการนำเสนอได้หรือไม่?**

ได้ Aspose.Slides อนุญาตให้คุณเพิ่มลายน้ำให้กับทุกสไลด์ในการนำเสนอ คุณสามารถวนลูปผ่านสไลด์ทั้งหมดและตั้งค่าลายน้ำให้แต่ละสไลด์ได้

**ฉันจะปรับความโปร่งใสของลายน้ำได้อย่างไร?**

คุณสามารถปรับความโปร่งใสของลายน้ำได้โดยแก้ไข[การตั้งค่าการเติม](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/shape/getfillformat/)ของรูปร่าง ซึ่งทำให้ลายน้ำดูนุ่มนวลและไม่รบกวนเนื้อหาสไลด์

**รูปแบบภาพใดบ้างที่สนับสนุนสำหรับลายน้ำ?**

Aspose.Slides สนับสนุนรูปแบบภาพต่าง ๆ เช่น PNG, JPEG, GIF, BMP, SVG และอื่น ๆ

**ฉันสามารถปรับแต่งแบบอักษรและสไตล์ของลายน้ำข้อความได้หรือไม่?**

ได้ คุณสามารถเลือกแบบอักษร, ขนาดและสไตล์ใดก็ได้เพื่อให้สอดคล้องกับการออกแบบการนำเสนอและรักษาความสอดคล้องของแบรนด์

**ฉันจะเปลี่ยนตำแหน่งหรือการวางแนวของลายน้ำได้อย่างไร?**

คุณสามารถปรับตำแหน่งและการวางแนวของลายน้ำได้โดยแก้ไขพิกัด, ขนาดและคุณสมบัติการหมุนของรูปร่าง