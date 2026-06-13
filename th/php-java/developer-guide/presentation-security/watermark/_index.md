---
title: เพิ่มลายน้ำในงานนำเสนอด้วย PHP
linktitle: ลายน้ำ
type: docs
weight: 40
url: /th/php-java/watermark/
keywords:
- ลายน้ำ
- ลายน้ำข้อความ
- ลายน้ำรูปภาพ
- เพิ่มลายน้ำ
- เปลี่ยนแปลงลายน้ำ
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
- PHP
- Aspose.Slides
description: "จัดการลายน้ำข้อความและรูปภาพในงานนำเสนอ PowerPoint และ OpenDocument ด้วย PHP เพื่อบ่งบอกว่าเป็นฉบับร่าง, ข้อมูลลับ, ลิขสิทธิ์และอื่น ๆ"
---
## **บทนำ**

**ลายน้ำ** ในงานนำเสนอคือข้อความหรือภาพที่ประทับบนสไลด์หรือทั่วทั้งสไลด์ของงานนำเสนอ ปกติแล้วลายน้ำใช้เพื่อระบุว่างานนำเสนอเป็นร่าง (เช่น ลายน้ำ “Draft”) มีข้อมูลเป็นความลับ (เช่น ลายน้ำ “Confidential”) ระบุว่าเป็นของบริษัทใด (เช่น ลายน้ำ “Company Name”) หรือระบุตัวผู้เขียนงานนำเสนอ ฯลฯ ลายน้ำช่วยป้องกันการละเมิดลิขสิทธิ์โดยบอกว่างานนำเสนอไม่ควรคัดลอก ลายน้ำใช้ได้ทั้งในรูปแบบ PowerPoint และ OpenOffice ใน Aspose.Slides คุณสามารถเพิ่มลายน้ำลงในไฟล์ PowerPoint PPT, PPTX และ OpenOffice ODP ได้

ใน [**Aspose.Slides**](https://products.aspose.com/slides/th/php-java/) มีวิธีต่าง ๆ ที่คุณสามารถสร้างลายน้ำในเอกสาร PowerPoint หรือ OpenOffice และปรับแต่งการออกแบบและพฤติกรรมของลายน้ำได้ ส่วนร่วมคือการเพิ่มลายน้ำข้อความคุณควรใช้คลาส [TextFrame](https://reference.aspose.com/slides/th/php-java/aspose.slides/textframe/) และเพื่อเพิ่มลายน้ำรูปภาพให้ใช้คลาส [PictureFrame](https://reference.aspose.com/slides/th/php-java/aspose.slides/pictureframe/) หรือเติมรูปภาพลงในรูปร่างลายน้ำ `PictureFrame` สืบทอดจากคลาส [Shape](https://reference.aspose.com/slides/th/php-java/aspose.slides/shape/) ทำให้คุณสามารถใช้การตั้งค่าต่าง ๆ ของวัตถุ Shape ได้อย่างยืดหยุ่น เนื่องจาก `ITextFrame` ไม่ใช่ Shape และการตั้งค่าจำกัด จึงถูกห่อหุ้มในอ็อบเจกต์ [Shape](https://reference.aspose.com/slides/th/php-java/aspose.slides/shape/)

มีสองวิธีในการใช้ลายน้ำ: กับสไลด์เดียวหรือกับสไลด์ทั้งหมด การใช้ Slide Master จะทำให้ลายน้ำปรากฏบนสไลด์ทั้งหมด — ลายน้ำถูกเพิ่มลงใน Slide Master ออกแบบที่นั่นแล้วใช้กับสไลด์ทั้งหมดโดยไม่กระทบต่อสิทธิ์การแก้ไขลายน้ำบนสไลด์แต่ละสไลด์

ลายน้ำโดยทั่วไปถือว่าไม่สามารถแก้ไขได้โดยผู้ใช้คนอื่น เพื่อป้องกันไม่ให้ลายน้ำ (หรือรูปร่างแม่ของลายน้ำ) ถูกแก้ไข Aspose.Slides มีฟังก์ชันการล็อกรูปร่าง คุณสามารถล็อกรูปร่างเฉพาะบนสไลด์ปกติหรือบน Slide Master เมื่อรูปร่างลายน้ำถูกล็อกบน Slide Master จะถูกล็อกบนสไลด์ทั้งหมด

คุณสามารถตั้งชื่อให้กับลายน้ำเพื่อให้ในอนาคตเมื่อต้องการลบ สามารถค้นหาได้จากรูปร่างของสไลด์โดยใช้ชื่อ

คุณสามารถออกแบบลายน้ำได้หลายรูปแบบ; อย่างไรก็ตามลายน้ำมักมีลักษณะทั่วไปเช่น จัดกึ่งกลาง, หมุน, อยู่ด้านหน้า เป็นต้น เราจะพิจารณาวิธีใช้เหล่านี้ในตัวอย่างต่อไป

## **ลายน้ำข้อความ**

### **เพิ่มลายน้ำข้อความลงในสไลด์**

เพื่อเพิ่มลายน้ำข้อความใน PPT, PPTX หรือ ODP คุณสามารถเพิ่มรูปร่างลงในสไลด์แล้วเพิ่ม TextFrame ลงในรูปร่างนั้น TextFrame แสดงโดยคลาส [TextFrame](https://reference.aspose.com/slides/th/php-java/aspose.slides/textframe/) คลาสนี้ไม่สืบทอดจาก [Shape](https://reference.aspose.com/slides/th/php-java/aspose.slides/shape/) ซึ่งมีคุณสมบัติตั้งค่าการวางตำแหน่งลายน้ำอย่างยืดหยุ่น ดังนั้นอ็อบเจกต์ [TextFrame](https://reference.aspose.com/slides/th/php-java/aspose.slides/textframe/) จะถูกห่อหุ้มในอ็อบเจกต์ [AutoShape](https://reference.aspose.com/slides/th/php-java/aspose.slides/autoshape/) เพื่อเพิ่มข้อความลายน้ำลงในรูปร่าง ให้ใช้เมธอด [addTextFrame](https://reference.aspose.com/slides/th/php-java/aspose.slides/autoshape/#addTextFrame) ตามตัวอย่างด้านล่าง

```php
$watermarkText = "CONFIDENTIAL";

$presentation = new Presentation();
$slide = $presentation->getSlides()->get_Item(0);

$watermarkShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 400, 40);
$watermarkFrame = $watermarkShape->addTextFrame($watermarkText);

$presentation->dispose();
```

{{% alert color="primary" title="ดูเพิ่มเติม" %}} 
- [วิธีการใช้คลาส TextFrame](/slides/th/php-java/text-formatting/)
{{% /alert %}}

### **เพิ่มลายน้ำข้อความลงในงานนำเสนอ**

หากต้องการเพิ่มลายน้ำข้อความให้กับงานนำเสนอทั้งหมด (เช่น ทุกสไลด์พร้อมกัน) ให้เพิ่มลงใน [MasterSlide](https://reference.aspose.com/slides/th/php-java/aspose.slides/masterslide/) ส่วนที่เหลือของตรรกะเดียวกับการเพิ่มลายน้ำบนสไลด์เดียว — สร้างอ็อบเจกต์ [AutoShape](https://reference.aspose.com/slides/th/php-java/aspose.slides/autoshape/) แล้วเพิ่มลายน้ำด้วยเมธอด [addTextFrame](https://reference.aspose.com/slides/th/php-java/aspose.slides/autoshape/#addTextFrame)

```php
$watermarkText = "CONFIDENTIAL";

$presentation = new Presentation();
$masterSlide = $presentation->getMasters()->get_Item(0);

$watermarkShape = $masterSlide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 400, 40);
$watermarkFrame = $watermarkShape->addTextFrame($watermarkText);

$presentation->dispose();
```

{{% alert color="primary" title="ดูเพิ่มเติม" %}} 
- [วิธีการใช้ Slide Master](/slides/th/php-java/slide-master/)
{{% /alert %}}

### **ตั้งค่าความโปร่งใสของรูปร่างลายน้ำ**

โดยค่าเริ่มต้นรูปร่างสี่เหลี่ยมจะมีสีเติมและสีเส้น โค้ดต่อไปนี้ทำให้รูปร่างโปร่งใส

```php
$watermarkShape->getFillFormat()->setFillType(FillType::NoFill);
$watermarkShape->getLineFormat()->getFillFormat()->setFillType(FillType::NoFill);
```

### **ตั้งค่าฟอนต์สำหรับลายน้ำข้อความ**

คุณสามารถเปลี่ยนฟอนต์ของลายน้ำข้อความได้ตามด้านล่าง

```php
$textFormat = $watermarkFrame->getParagraphs()->get_Item(0)->getParagraphFormat()->getDefaultPortionFormat();
$textFormat->setLatinFont(new FontData("Arial"));
$textFormat->setFontHeight(50);
```

### **ตั้งค่าสีข้อความลายน้ำ**

เพื่อกำหนดสีของข้อความลายน้ำ ให้ใช้โค้ดนี้

```php
$alpha = 150;
$red = 200;
$green = 200;
$blue = 200;
$textColor = new Java("java.awt.Color", $red, $green, $blue, $alpha);

$fillFormat = $watermarkFrame->getParagraphs()->get_Item(0)->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat();
$fillFormat->setFillType(FillType::Solid);
$fillFormat->getSolidFillColor()->setColor($textColor);
```

### **จัดกึ่งกลางลายน้ำข้อความ**

คุณสามารถจัดกึ่งกลางลายน้ำบนสไลด์ได้โดยทำตามขั้นตอนต่อไปนี้

```php
$slideSize = $presentation->getSlideSize()->getSize();
$slideWidth = java_values($slideSize->getWidth());
$slideHeight = java_values($slideSize->getHeight());

$watermarkWidth = 400;
$watermarkHeight = 40;
$watermarkX = ($slideWidth - $watermarkWidth) / 2;
$watermarkY = ($slideHeight - $watermarkHeight) / 2;

$watermarkShape = $slide->getShapes()->addAutoShape(
        ShapeType::Rectangle, $watermarkX, $watermarkY, $watermarkWidth, $watermarkHeight);

$watermarkFrame = $watermarkShape->addTextFrame($watermarkText);
```

รูปด้านล่างแสดงผลลัพธ์สุดท้าย

![The text watermark](text_watermark.png)

## **ลายน้ำรูปภาพ**

### **เพิ่มลายน้ำรูปภาพลงในงานนำเสนอ**

เพื่อเพิ่มลายน้ำรูปภาพลงในสไลด์ของงานนำเสนอ คุณสามารถทำตามขั้นตอนต่อไปนี้

```php
$image = Images::fromFile("watermark.png");
$picture = $presentation->getImages()->addImage($image);
$image->dispose();

$watermarkShape->getFillFormat()->setFillType(FillType::Picture);
$watermarkShape->getFillFormat()->getPictureFillFormat()->getPicture()->setImage($picture);
$watermarkShape->getFillFormat()->getPictureFillFormat()->setPictureFillMode(PictureFillMode::Stretch);
```

### **ล็อกลายน้ำไม่ให้แก้ไข**

หากต้องการป้องกันไม่ให้ลายน้ำถูกแก้ไข ใช้เมธอด [AutoShape.getAutoShapeLock](https://reference.aspose.com/slides/th/php-java/aspose.slides/autoshape/#getAutoShapeLock) บนรูปร่าง ด้วยคุณสมบัตินี้คุณสามารถป้องกันไม่ให้รูปร่างถูกเลือก, ปรับขนาด, ย้ายตำแหน่ง, รวมกลุ่มกับองค์ประกอบอื่น, ล็อกข้อความจากการแก้ไข ฯลฯ

```php
// ล็อกรูปลายน้ำไม่ให้แก้ไข
$watermarkShape->getAutoShapeLock()->setSelectLocked(true);
$watermarkShape->getAutoShapeLock()->setSizeLocked(true);
$watermarkShape->getAutoShapeLock()->setTextLocked(true);
$watermarkShape->getAutoShapeLock()->setPositionLocked(true);
$watermarkShape->getAutoShapeLock()->setGroupingLocked(true);
```

### **นำลายน้ำไปอยู่ด้านหน้า**

ใน Aspose.Slides การจัดลำดับ Z ของรูปร่างสามารถตั้งค่าได้ผ่านเมธอด [ShapeCollection.reorder](https://reference.aspose.com/slides/th/php-java/aspose.slides/shapecollection/#reorder) เพียงเรียกเมธอดนี้จากรายการสไลด์ของงานนำเสนอและส่งอ้างอิงรูปร่างพร้อมหมายเลขลำดับเข้าไป จะทำให้สามารถนำรูปร่างไปอยู่ด้านหน้า หรือส่งไปอยู่ด้านหลังของสไลด์ได้ ฟีเจอร์นี้มีประโยชน์เมื่อคุณต้องการให้ลายน้ำอยู่ด้านหน้าของงานนำเสนอ

```php
$shapeCount = java_values($slide->getShapes()->size());
$slide->getShapes()->reorder($shapeCount - 1, $watermarkShape);
```

### **ตั้งค่าการหมุนของลายน้ำ**

ตัวอย่างโค้ดต่อไปนี้แสดงวิธีปรับการหมุนของลายน้ำให้ตำแหน่งเป็นแนวทแยงมุมบนสไลด์

```php
$diagonalAngle = atan($slideWidth / $slideHeight) * 180 / M_PI;

$watermarkShape->setRotation($diagonalAngle);
```

### **ตั้งชื่อให้กับลายน้ำ**

Aspose.Slides อนุญาตให้คุณตั้งชื่อให้กับรูปร่างได้ โดยใช้ชื่อรูปร่างคุณสามารถเข้าถึงเพื่อแก้ไขหรือทำการลบในภายหลัง เพื่อกำหนดชื่อให้กับรูปร่างลายน้ำ ให้เรียกเมธอด [AutoShape.setName](https://reference.aspose.com/slides/th/php-java/aspose.slides/shape/#setName)

```php
$watermarkShape->setName("watermark");
```

### **ลบลายน้ำ**

เพื่อทำการลบรูปร่างลายน้ำ ให้ใช้เมธอด [AutoShape.getName](https://reference.aspose.com/slides/th/php-java/aspose.slides/shape/#getName) เพื่อค้นหาในรูปร่างของสไลด์ จากนั้นส่งรูปร่างลายน้ำเข้าเมธอด [ShapeCollection.remove](https://reference.aspose.com/slides/th/php-java/aspose.slides/shapecollection/#remove)

```php
$slideShapes = $slide->getShapes()->toArray();
foreach ($slideShapes as $shape) {
    if ($shape->getName() === "watermark") {
        $slide->getShapes()->remove($shape);
    }
}
```

## **คำถามที่พบบ่อย**

**ลายน้ำคืออะไรและทำไมต้องใช้?**

ลายน้ำคือชั้นทับข้อความหรือรูปภาพบนสไลด์ที่ช่วยปกป้องทรัพย์สินทางปัญญา เสริมการรับรู้แบรนด์ หรือป้องกันการใช้งานนำเสนอโดยไม่ได้รับอนุญาต

**ฉันสามารถเพิ่มลายน้ำให้กับทุกสไลด์ในงานนำเสนอได้หรือไม่?**

ได้, Aspose.Slides อนุญาตให้คุณเพิ่มลายน้ำให้กับทุกสไลด์ในงานนำเสนอโดยเขียนโค้ดวนลูปผ่านสไลด์ทั้งหมดและกำหนดค่าลายน้ำแต่ละสไลด์

**ฉันจะปรับความโปร่งใสของลายน้ำอย่างไร?**

คุณสามารถปรับความโปร่งใสของลายน้ำโดยแก้ไขการตั้งค่าการเติม ([getFillFormat](https://reference.aspose.com/slides/th/php-java/aspose.slides/shape/getfillformat/)) ของรูปร่าง ซึ่งทำให้ลายน้ำดูอ่อนโยนและไม่รบกวนเนื้อหาในสไลด์

**ลายน้ำรองรับรูปแบบไฟล์ภาพใดบ้าง?**

Aspose.Slides รองรับรูปแบบภาพหลายประเภท เช่น PNG, JPEG, GIF, BMP, SVG และอื่น ๆ

**ฉันสามารถกำหนดฟอนต์และสไตล์ของลายน้ำข้อความได้หรือไม่?**

ได้, คุณสามารถเลือกฟอนต์, ขนาด, และสไตล์ใดก็ได้เพื่อให้สอดคล้องกับการออกแบบงานนำเสนอและคงความสอดคล้องของแบรนด์

**ฉันจะเปลี่ยนตำแหน่งหรือการวางแนวของลายน้ำอย่างไร?**

คุณสามารถปรับตำแหน่งและการวางแนวของลายน้ำโดยโปรแกรมโดยแก้ไขพิกัด, ขนาด, และคุณสมบัติการหมุนของรูปร่างได้