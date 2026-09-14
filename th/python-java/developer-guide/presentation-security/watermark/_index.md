---
title: เพิ่มลายน้ำในงานนำเสนอด้วย Python
linktitle: ลายน้ำ
type: docs
weight: 40
url: /th/python-java/watermark/
keywords:
- ลายน้ำ
- ลายน้ำข้อความ
- ลายน้ำรูปภาพ
- เพิ่มลายน้ำ
- แก้ไขลายน้ำ
- ลบลายน้ำ
- ลบลายน้ำ
- เพิ่มลายน้ำลงใน PPT
- เพิ่มลายน้ำลงใน PPTX
- เพิ่มลายน้ำลงใน ODP
- ลบลายน้ำจาก PPT
- ลบลายน้ำจาก PPTX
- ลบลายน้ำจาก ODP
- ลบลายน้ำจาก PPT
- ลบลายน้ำจาก PPTX
- ลบลายน้ำจาก ODP
- PowerPoint
- OpenDocument
- การนำเสนอ
- Python
- Aspose.Slides
description: "จัดการลายน้ำข้อความและลายน้ำรูปภาพในงานนำเสนอ PowerPoint และ OpenDocument ด้วย Python เพื่อระบุว่าเป็นร่าง, ข้อมูลลับ, ลิขสิทธิ์, และอื่น ๆ"
---
## **บทนำ**

**ลายน้ำ** ในงานนำเสนอคือสติ๊กเกอร์ข้อความหรือรูปภาพที่ใช้บนสไลด์หรือทั่วทั้งสไลด์ของงานนำเสนอ โดยทั่วไปลายน้ำจะใช้เพื่อบ่งบอกว่างานนำเสนอเป็นร่าง (เช่น ลายน้ำ “Draft”) หรือมีข้อมูลลับ (เช่น ลายน้ำ “Confidential”) เพื่อระบุบริษัทที่เป็นเจ้าของ (เช่น ลายน้ำ “Company Name”) เพื่อระบุผู้สร้างงานนำเสนอ เป็นต้น ลายน้ำช่วยป้องกันการละเมิดลิขสิทธิ์โดยบ่งบอกว่าห้ามคัดลอกงานนำเสนอ ลายน้ำใช้ได้ทั้งในรูปแบบ PowerPoint และ OpenOffice ใน Aspose.Slides คุณสามารถเพิ่มลายน้ำให้กับไฟล์ PowerPoint PPT, PPTX และไฟล์ OpenOffice ODP ได้

ใน [**Aspose.Slides**](https://products.aspose.com/slides/th/python-java/) มีวิธีหลายวิธีที่จะสร้างลายน้ำในเอกสาร PowerPoint หรือ OpenOffice และปรับแต่งการออกแบบและพฤติกรรมของมัน ส่วนที่สำคัญคือ การเพิ่มลายน้ำข้อความต้องใช้คลาส [TextFrame](https://reference.aspose.com/slides/th/python-java/aspose.slides/textframe/) และการเพิ่มลายน้ำรูปภาพต้องใช้คลาส [PictureFrame](https://reference.aspose.com/slides/th/python-java/aspose.slides/pictureframe/) หรือเติมรูปร่างลายน้ำด้วยภาพ [PictureFrame](https://reference.aspose.com/slides/th/python-java/aspose.slides/pictureframe/) สืบทอดจากคลาส [Shape](https://reference.aspose.com/slides/th/python-java/aspose.slides/shape/) ทำให้คุณสามารถใช้การตั้งค่าที่ยืดหยุ่นของออบเจกต์รูปร่างได้ เนื่องจาก [TextFrame](https://reference.aspose.com/slides/th/python-java/aspose.slides/textframe/) ไม่ใช่รูปร่างและการตั้งค่ามีขอบเขตจำกัด จึงถูกห่อหุ้มในออบเจกต์ [Shape](https://reference.aspose.com/slides/th/python-java/aspose.slides/shape/)

มีสองวิธีในการใช้ลายน้ำ: กับสไลด์เดียวหรือกับสไลด์ทั้งหมดของงานนำเสนอ Slide Master จะใช้เพื่อเพิ่มลายน้ำให้กับสไลด์ทั้งหมด — ลายน้ำจะถูกเพิ่มไปที่ Slide Master ออกแบบที่นั่น แล้วนำไปใช้กับสไลด์ทุกอันโดยไม่กระทบต่อสิทธิ์ในการแก้ไขลายน้ำบนสไลด์แต่ละหน้า

ลายน้ำมักถือว่าไม่ควรให้ผู้ใช้คนอื่นแก้ไข เพื่อป้องกันไม่ให้ลายน้ำ (หรือรูปร่างแม่ของลายน้ำ) ถูกแก้ไข Aspose.Slides มีฟังก์ชันล็อกรูปร่าง คุณสามารถล็อกรูปร่างเฉพาะบนสไลด์ปกติหรือบน Slide Master เมื่อรูปร่างลายน้ำถูกล็อกบน Slide Master มันจะถูกล็อกบนสไลด์ทั้งหมด

คุณสามารถตั้งชื่อให้ลายน้ำได้ เพื่อให้ในอนาคตต้องการลบลายน้ำสามารถค้นหาได้จากรูปร่างของสไลด์โดยใช้ชื่อ

คุณสามารถออกแบบลายน้ำได้ตามต้องการ; อย่างไรก็ตามลักษณะที่พบบ่อยของลายน้ำมักจะอยู่กึ่งกลาง, มีการหมุน, อยู่ตำแหน่งหน้า เป็นต้น เราจะพิจารณาการใช้คุณลักษณะเหล่านี้ในตัวอย่างด้านล่าง

## **ลายน้ำข้อความ**

### **เพิ่มลายน้ำข้อความลงในสไลด์**

เพื่อเพิ่มลายน้ำข้อความใน PPT, PPTX หรือ ODP คุณสามารถเพิ่มรูปร่างลงในสไลด์ก่อน แล้วเพิ่มกรอบข้อความลงในรูปร่างนั้น กรอบข้อความแสดงด้วยคลาส [TextFrame](https://reference.aspose.com/slides/th/python-java/aspose.slides/textframe/) คลาสนี้ไม่ได้สืบทอดจาก [Shape](https://reference.aspose.com/slides/th/python-java/aspose.slides/shape/) ซึ่งมีคุณสมบัติกว้างสำหรับการวางตำแหน่งลายน้ำอย่างยืดหยุ่น ดังนั้นออบเจกต์ [TextFrame](https://reference.aspose.com/slides/th/python-java/aspose.slides/textframe/) จะถูกห่อหุ้มในออบเจกต์ [AutoShape](https://reference.aspose.com/slides/th/python-java/aspose.slides/autoshape/) เพื่อเพิ่มข้อความลายน้ำลงในรูปร่าง ให้ใช้เมธอด [addTextFrame](https://reference.aspose.com/slides/th/python-java/aspose.slides/autoshape/#addTextFrame) ตามตัวอย่างด้านล่าง

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType

watermark_text = "CONFIDENTIAL"
presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    watermark_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40)
    watermark_frame = watermark_shape.addTextFrame(watermark_text)
finally:
    presentation.dispose()
```

{{% alert color="info" title="หมายเหตุ" %}} 
- [วิธีใช้คลาส TextFrame](/slides/th/python-java/text-formatting/)
{{% /alert %}}

### **เพิ่มลายน้ำข้อความลงในงานนำเสนอ**

หากต้องการเพิ่มลายน้ำข้อความให้กับงานนำเสนอทั้งหมด (คือทุกสไลด์พร้อมกัน) ให้เพิ่มลงใน [MasterSlide](https://reference.aspose.com/slides/th/python-java/aspose.slides/masterslide/) ส่วนที่เหลือของตรรกะเหมือนกับการเพิ่มลายน้ำลงในสไลด์เดียว — สร้างออบเจกต์ [AutoShape](https://reference.aspose.com/slides/th/python-java/aspose.slides/autoshape/) แล้วเพิ่มลายน้ำด้วยเมธอด [addTextFrame](https://reference.aspose.com/slides/th/python-java/aspose.slides/autoshape/#addTextFrame)

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType

watermark_text = "CONFIDENTIAL"
presentation = Presentation()
try:
    master_slide = presentation.getMasters().get_Item(0)
    watermark_shape = master_slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40)
    watermark_frame = watermark_shape.addTextFrame(watermark_text)
finally:
    presentation.dispose()
```

{{% alert color="info" title="หมายเหตุ" %}} 
- [วิธีใช้ Slide Master](/slides/th/python-java/slide-master/)
{{% /alert %}}

### **ตั้งค่าความโปร่งใสของรูปร่างลายน้ำ**

โดยค่าเริ่มต้นรูปร่างสี่เหลี่ยมจะมีสีเติมและเส้นสี บรรทัดโค้ดต่อไปนี้ทำให้รูปร่างโปร่งใส

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, FillType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    watermark_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40)
    watermark_shape.getFillFormat().setFillType(FillType.NoFill)
    watermark_shape.getLineFormat().getFillFormat().setFillType(FillType.NoFill)
finally:
    presentation.dispose()
```

### **ตั้งค่าแบบอักษรสำหรับลายน้ำข้อความ**

คุณสามารถเปลี่ยนแบบอักษรของลายน้ำข้อความได้ตามด้านล่าง

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, FontData

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    watermark_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40)
    watermark_frame = watermark_shape.addTextFrame("CONFIDENTIAL")
    text_format = watermark_frame.getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat()
    font = FontData("Arial")
    text_format.setLatinFont(font)
    text_format.setFontHeight(50)
finally:
    presentation.dispose()
```

### **ตั้งค่าสีข้อความของลายน้ำ**

เพื่อกำหนดสีของข้อความลายน้ำ ให้ใช้โค้ดนี้

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, FillType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    watermark_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40)
    watermark_frame = watermark_shape.addTextFrame("CONFIDENTIAL")
    alpha, red, green, blue = 150, 200, 200, 200
    fill_format = watermark_frame.getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().getFillFormat()
    fill_format.setFillType(FillType.Solid)
    color = Color(red, green, blue, alpha)
    fill_format.getSolidFillColor().setColor(color)
finally:
    presentation.dispose()
```

### **จัดกึ่งกลางลายน้ำข้อความ**

คุณสามารถจัดกึ่งกลางลายน้ำบนสไลด์ได้โดยทำตามขั้นตอนต่อไปนี้

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType

watermark_text = "CONFIDENTIAL"
presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    slide_size = presentation.getSlideSize().getSize()
    watermark_width = 400
    watermark_height = 40
    watermark_x = (slide_size.getWidth() - watermark_width) / 2
    watermark_y = (slide_size.getHeight() - watermark_height) / 2
    watermark_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, watermark_x, watermark_y, watermark_width, watermark_height)
    watermark_frame = watermark_shape.addTextFrame(watermark_text)
finally:
    presentation.dispose()
```

ภาพด้านล่างแสดงผลลัพธ์สุดท้าย

![ลายน้ำข้อความ](text_watermark.png)

## **ลายน้ำรูปภาพ**

### **เพิ่มลายน้ำรูปภาพลงในงานนำเสนอ**

เพื่อเพิ่มลายน้ำรูปภาพลงในสไลด์ของงานนำเสนอ ให้ทำตามขั้นตอนต่อไปนี้

```python
import jpype
import asposeslides
from pathlib import Path

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, FillType, PictureFillMode

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    watermark_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40)
    image_data = Path("watermark.png").read_bytes()
    image = presentation.getImages().addImage(jpype.JArray(jpype.JByte)(image_data))
    watermark_shape.getFillFormat().setFillType(FillType.Picture)
    watermark_shape.getFillFormat().getPictureFillFormat().getPicture().setImage(image)
    watermark_shape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch)
finally:
    presentation.dispose()
```

### **ล็อกลายน้ำไม่ให้แก้ไข**

หากต้องการป้องกันไม่ให้ลายน้ำถูกแก้ไข ให้ใช้เมธอด [AutoShape.getAutoShapeLock](https://reference.aspose.com/slides/th/python-java/aspose.slides/autoshape/#getAutoShapeLock) บนรูปร่าง ด้วยคุณสมบัตินี้คุณสามารถปกป้องรูปร่างจากการเลือก, ปรับขนาด, ย้ายตำแหน่ง, จัดกลุ่มกับองค์ประกอบอื่น, ล็อกข้อความไม่ให้แก้ไข และอื่น ๆ อีกมาก

```python
import jpype
import asposeslides

if not jpade.isJVMStarted():
    jpade.startJVM()

from asposeslides.api import Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    watermark_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40)
    # ล็อกรูปร่างลายน้ำไม่ให้แก้ไข.
    watermark_shape.getAutoShapeLock().setSelectLocked(True)
    watermark_shape.getAutoShapeLock().setSizeLocked(True)
    watermark_shape.getAutoShapeLock().setTextLocked(True)
    watermark_shape.getAutoShapeLock().setPositionLocked(True)
    watermark_shape.getAutoShapeLock().setGroupingLocked(True)
finally:
    presentation.dispose()
```

### **ย้ายลายน้ำไปไว้ด้านหน้า**

ใน Aspose.Slides สามารถตั้งค่าลำดับ Z ของรูปร่างได้ด้วยเมธอด [ShapeCollection.reorder](https://reference.aspose.com/slides/th/python-java/aspose.slides/shapecollection/#reorder) เรียกเมธอดนี้จากคอลเลกชันรูปร่างของสไลด์และส่งอ้างอิงรูปร่างพร้อมเลขลำดับเข้าไป วิธีนี้ทำให้สามารถย้ายรูปร่างไปอยู่ด้านหน้า หรือส่งไปด้านหลังของสไลด์ได้ ฟีเจอร์นี้มีประโยชน์เมื่อคุณต้องการให้ลายน้ำอยู่หน้าต่างงานนำเสนอ

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    watermark_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40)
    shape_count = slide.getShapes().size()
    slide.getShapes().reorder(shape_count - 1, watermark_shape)
finally:
    presentation.dispose()
```

### **ตั้งค่าการหมุนของลายน้ำ**

ตัวอย่างโค้ดต่อไปนี้แสดงวิธีปรับการหมุนของลายน้ำให้วางแนวทแยงบนสไลด์

```python
import jpype
import asposeslides
import math

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    watermark_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40)
    slide_size = presentation.getSlideSize().getSize()
    diagonal_angle = math.atan((slide_size.getHeight() / slide_size.getWidth())) * 180 / math.pi
    watermark_shape.setRotation(diagonal_angle)
finally:
    presentation.dispose()
```

### **ตั้งชื่อให้ลายน้ำ**

Aspose.Slides ให้คุณตั้งชื่อให้กับรูปร่าง โดยใช้ชื่อรูปร่างคุณสามารถเข้าถึงในภายหลังเพื่อแก้ไขหรือทำลายลบได้ เพื่อกำหนดชื่อให้กับรูปร่างลายน้ำ ให้ส่งชื่อไปยังเมธอด [Shape.setName](https://reference.aspose.com/slides/th/python-java/aspose.slides/shape/#setName)

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    watermark_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40)
    watermark_shape.setName("watermark")
finally:
    presentation.dispose()
```

### **ลบลายน้ำ**

เพื่อลบรูปร่างลายน้ำ ใช้เมธอด [Shape.getName](https://reference.aspose.com/slides/th/python-java/aspose.slides/shape/#getName) ค้นหารูปร่างในสไลด์ แล้วส่งรูปร่างลายน้ำเข้าเมธอด [ShapeCollection.remove](https://reference.aspose.com/slides/th/python-java/aspose.slides/shapecollection/#remove)

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("presentation.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    slide_shapes = slide.getShapes().toArray()
    for shape in slide_shapes:
        if shape.getName() == "watermark":
            slide.getShapes().remove(shape)
finally:
    presentation.dispose()
```

## **คำถามที่พบบ่อย**

**ลายน้ำคืออะไรและทำไมต้องใช้?**

ลายน้ำคือการครอบข้อความหรือรูปภาพบนสไลด์ที่ช่วยปกป้องทรัพย์สินทางปัญญา, เพิ่มการจดจำแบรนด์, หรือป้องกันการใช้งานนำเสนอโดยไม่ได้รับอนุญาต

**ฉันสามารถเพิ่มลายน้ำให้กับทุกสไลด์ในงานนำเสนอได้หรือไม่?**

ได้, Aspose.Slides อนุญาตให้คุณเพิ่มลายน้ำให้กับทุกสไลด์โดยอัตโนมัติ คุณสามารถวนลูปผ่านสไลด์ทั้งหมดและกำหนดค่าลายน้ำให้แต่ละสไลด์ได้

**ฉันจะปรับความโปร่งใสของลายน้ำได้อย่างไร?**

คุณสามารถปรับความโปร่งใสของลายน้ำได้โดยแก้ไขการตั้งค่าการเติม ([getFillFormat](https://reference.aspose.com/slides/th/python-java/aspose.slides/shape/#getFillFormat)) ของรูปร่าง เพื่อให้ลายน้ำดูอ่อนและไม่รบกวนเนื้อหาในสไลด์

**ลายน้ำรองรับรูปแบบภาพใดบ้าง?**

Aspose.Slides รองรับรูปแบบภาพหลายประเภท เช่น PNG, JPEG, GIF, BMP, SVG และอื่น ๆ

**ฉันสามารถปรับแต่งแบบอักษรและสไตล์ของลายน้ำข้อความได้หรือไม่?**

ได้, คุณสามารถเลือกแบบอักษร, ขนาด, และสไตล์ใดก็ได้เพื่อให้ตรงกับการออกแบบงานนำเสนอและรักษาความสอดคล้องของแบรนด์

**ฉันจะเปลี่ยนตำแหน่งหรือแนวลายน้ำได้อย่างไร?**

คุณสามารถปรับตำแหน่งและแนวของลายน้ำโดยโปรแกรมโดยแก้ไขพิกัด, ขนาด, และคุณสมบัติการหมุนของรูปร่างได้