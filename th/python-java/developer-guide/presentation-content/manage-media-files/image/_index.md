---
title: เพิ่มประสิทธิภาพการจัดการรูปภาพในงานนำเสนอด้วย Python
linktitle: จัดการรูปภาพ
type: docs
weight: 10
url: /th/python-java/image/
keywords:
- เพิ่มรูปภาพ
- เพิ่มภาพ
- แทนที่รูปภาพ
- คอลเลกชันรูปภาพ
- กรอบรูป
- รูปภาพแบบลิงก์
- พื้นหลัง
- เพิ่ม PNG
- เพิ่ม JPG
- เพิ่ม SVG
- แปลง SVG เป็นรูปทรง
- แหล่งทรัพยากร SVG ภายนอก
- PowerPoint
- OpenDocument
- งานนำเสนอ
- Python
- Java
- Aspose.Slides
description: "เรียนรู้วิธีเพิ่ม, ใช้ใหม่, ลิงก์, แทนที่ และจัดการรูปภาพแบบ raster และ SVG ในงานนำเสนอ PowerPoint และ OpenDocument ด้วย Aspose.Slides สำหรับ Python ผ่าน Java."
---
## **บทนำ**

Aspose.Slides for Python via Java มีวิธีการทำงานกับรูปภาพหลายวิธีและแต่ละวิธีมีจุดประสงค์ที่แตกต่างกัน คุณสามารถเก็บรูปภาพในงานนำเสนอ แสดงในกรอบรูป ใช้เป็นพื้นหลังของสไลด์ ลิงก์ไปยังรูปภาพภายนอก แทนที่ทรัพยากรรูปภาพที่ใช้ร่วมกัน หรือแปลงเนื้อหา SVG ให้เป็นรูปทรงที่แก้ไขได้

บทความนี้เน้นที่ทรัพยากรรูปภาพและวิธีการใช้ทั่วทั้งงานนำเสนอ สำหรับการครอบ ตัดส่วนที่โปร่งใส เอฟเฟกต์ การยืด และการจัดรูปแบบอื่น ๆ ที่ใช้กับกรอบรูปแต่ละกรอบ ดูที่ [กรอบรูป](/slides/th/python-java/picture-frame/)

## **ทำความเข้าใจโมเดลรูปภาพ**

แนวคิด API ต่อไปนี้เกี่ยวข้องกันอย่างใกล้ชิดแต่ไม่สามารถแทนกันได้:

- [คอลเลกชันรูปภาพของงานนำเสนอ](https://reference.aspose.com/slides/th/python-java/aspose.slides/imagecollection/) เก็บทรัพยากรรูปภาพที่ใช้โดยงานนำเสนอ ใช้ [ImageCollection.addImage](https://reference.aspose.com/slides/th/python-java/aspose.slides/imagecollection/#addImage) เพื่อเพิ่มข้อมูลรูปภาพและรับทรัพยากร [PPImage](https://reference.aspose.com/slides/th/python-java/aspose.slides/ppimage/)
- [กรอบรูป](https://reference.aspose.com/slides/th/python-java/aspose.slides/pictureframe/) คือรูปทรงที่แสดงรูปภาพบนสไลด์ เลย์เอาต์ หรือมาสเตอร์ ใช้ [ShapeCollection.addPictureFrame](https://reference.aspose.com/slides/th/python-java/aspose.slides/shapecollection/#addPictureFrame) เพื่อวางทรัพยากรรูปภาพบนสไลด์
- พื้นหลังสไลด์ใช้รูปภาพเป็นส่วนหนึ่งของการเติมสีสไลด์ ไม่ได้ทำหน้าที่เหมือนกรอบรูป
- [PPImage.replaceImage](https://reference.aspose.com/slides/th/python-java/aspose.slides/ppimage/#replaceImage) แทนที่ทรัพยากรรูปภาพ หากหลายองค์ประกอบของงานนำใช้ทรัพยากรนั้น พวกมันทั้งหมดจะใช้รูปที่แทนที่
- การแปลง SVG เป็นรูปทรงสร้างรูปทรงสไลด์ที่สามารถแก้ไขได้ หลังจากแปลงแล้ว เนื้อหาจะไม่ถูกจัดการเป็นรูปภาพเดียวอีกต่อไป

ดังนั้นขั้นตอนทำงานทั่วไปคือ: เพิ่มข้อมูลรูปภาพลงในคอลเลกชันรูปภาพ รับ [PPImage] แล้วใช้ทรัพยากรนั้นในกรอบรูปหรือการเติมสีหนึ่งหรือหลายตำแหน่ง

## **เพิ่มรูปแบบฝัง**

เพื่อแทรกรูปภาพในเครื่อง โหลดไฟล์ เพิ่มลงในคอลเลกชันรูปภาพ แล้วสร้างกรอบรูปที่ใช้ [PPImage] ที่ส่งคืนมา

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Images, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    source_image = Images.fromFile("photo.png")
    try:
        image = presentation.getImages().addImage(source_image)
    finally:
        source_image.dispose()

    slide = presentation.getSlides().get_Item(0)
    slide.getShapes().addPictureFrame(ShapeType.Rectangle, 20, 20, 320, 180, image)

    presentation.save("presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

รูปภาพที่เพิ่มด้วยวิธีนี้จะฝังอยู่ในงานนำเสนอ ดังนั้นไฟล์ที่ได้จึงไม่ขึ้นกับการมีอยู่ของไฟล์รูปต้นฉบับ

### **เพิ่มรูปจากเว็บ**

เมื่อรูปภาพสามารถเข้าถึงได้ผ่าน HTTP หรือ HTTPS ให้ดาวน์โหลดไบต์ของรูปภาพ เพิ่มลงในคอลเลกชันรูปภาพของงานนำเสนอ และใช้ทรัพยากรรูปภาพที่ส่งคืนเช่นเดียวกับรูปภาพในเครื่อง

```python
import jpide
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from urllib.request import urlopen
from asposeslides.api import Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    with urlopen("https://example.com/image.png", timeout=10) as response:
        image_data = response.read()

    image_bytes = jpype.JArray(jpype.JByte)(image_data)
    image = presentation.getImages().addImage(image_bytes)
    slide = presentation.getSlides().get_Item(0)
    slide.getShapes().addPictureFrame(ShapeType.Rectangle, 20, 20, 320, 180, image)

    presentation.save("presentation-from-web.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

ในแอปพลิเคชันที่ทำงานเป็นเวลานาน ควรใช้คลายเอนท์ HTTP หรือกลยุทธ์การจัดการการเชื่อมต่อที่เหมาะสมกับแอปพลิเคชันแทนการสร้างโครงสร้างเครือข่ายที่ไม่จำเป็นซ้ำ ๆ ตรวจสอบ URL ระยะไกล ขนาดการตอบสนอง และประเภทของเนื้อหาเมื่อแหล่งที่มาไม่น่าเชื่อถือ

## **ใช้รูปภาพซ้ำในหลายสไลด์**

หากต้องการใช้รูปเดียวกันหลายครั้ง ให้เพิ่มรูปลงในงานนำเสนอเพียงครั้งเดียวแล้วใช้ [PPImage] ที่ส่งคืนเมื่อสร้างกรอบรูปเพิ่มเติม วิธีนี้ช่วยหลีกเลี่ยงการโหลดข้อมูลแหล่งที่ซ้ำกันหลายครั้งและทำให้ความสัมพันธ์ระหว่างทรัพยากรรูปภาพที่แชร์กับการใช้งานของมันชัดเจน

สำหรับกราฟิกที่ควรปรากฏอัตโนมัติบนหลายสไลด์ เช่น โลโก้บริษัท พิจารณาวางกรอบรูปบน [มาสเตอร์สไลด์](/slides/th/python-java/slide-master/) หรือเลย์เอาต์แทนการเพิ่มรูปทรงที่เทียบเท่าในแต่ละสไลด์

## **ใช้รูปเป็นพื้นหลังสไลด์**

รูปพื้นหลังจะถูกกำหนดให้กับการเติมสีของสไลด์ ไม่ได้ถูกเพิ่มเป็นรูปทรงกรอบรูป วิธีนี้มีประโยชน์เมื่อต้องการให้รูปครอบพื้นหลังสไลด์และไม่ต้องการจัดการเป็นวัตถุสไลด์ทั่วไป

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, Images, PictureFillMode, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    source_image = Images.fromFile("background.jpg")
    try:
        image = presentation.getImages().addImage(source_image)
    finally:
        source_image.dispose()

    slide.getBackground().setType(BackgroundType.OwnBackground)
    slide.getBackground().getFillFormat().setFillType(FillType.Picture)
    slide.getBackground().getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch)
    slide.getBackground().getFillFormat().getPictureFillFormat().getPicture().setImage(image)

    presentation.save("background-image.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

สำหรับตัวเลือกพื้นหลังเพิ่มเติม รวมถึงพื้นหลังมาสเตอร์และเลย์เอาต์ ดูที่ [พื้นหลังการนำเสนอ](/slides/th/python-java/presentation-background/)

## **รูปภาพแบบฝังและแบบลิงก์**

รูปภาพแบบฝังและรูปภาพแบบลิงก์มีการแลกเปลี่ยนด้านความพกพาและขนาดไฟล์ที่แตกต่างกัน:

- **รูปภาพแบบฝัง:** ข้อมูลรูปภาพถูกเก็บไว้ภายในงานนำเสนอ งานนำเสนอจึงเป็นไฟล์อิสระ แต่ขนาดไฟล์จะรวมข้อมูลรูปภาพด้วย
- **รูปภาพแบบลิงก์:** งานนำเสนอเก็บพาธหรือ URL ของรูปภาพภายนอก ซึ่งสามารถลดขนาดงานนำเสนอได้ แต่ต้องให้ทรัพยากรภายนอกยังคงเข้าถึงได้เมื่อเปิดหรือแสดงผลงานนำเสนอ

รูปภาพที่เชื่อมโยงสามารถสร้างได้โดยกำหนดพาธหรือ URL ภายนอกผ่าน [Picture.setLinkPathLong](https://reference.aspose.com/slides/th/python-java/aspose.slides/picture/#setLinkPathLong) แทนการฝังข้อมูลรูปภาพ

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    picture_frame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 20, 20, 320, 180, None)
    picture_frame.getPictureFormat().getPicture().setLinkPathLong("https://example.com/image.png")

    presentation.save("linked-image.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

ใช้รูปภาพแบบลิงก์เฉพาะเมื่อสภาพแวดล้อมการปรับใช้สามารถเข้าถึงทรัพยากรภายนอกได้อย่างน่าเชื่อถือ สำหรับงานนำเสนอที่ต้องทำงานออฟไลน์หรือย้ายระหว่างระบบ รูปภาพแบบฝังมักจะปลอดภัยกว่า

## **ทำงานกับภาพ SVG**

SVG เป็นฟอร์แมตเวกเตอร์ จึงเหมาะสำหรับไอคอน แผนภาพ และกราฟิกอื่น ๆ ที่ต้องการขยายโดยไม่สูญเสียรายละเอียดอย่างภาพจังหวะ (raster) Aspose.Slides รองรับ SVG ทั้งในฐานะทรัพยากรรูปภาพและเป็นแหล่งสำหรับรูปทรงสไลด์ที่แก้ไขได้

### **เพิ่ม SVG เป็นรูปภาพ**

สร้าง [SvgImage](https://reference.aspose.com/slides/th/python-java/aspose.slides/svgimage/) เพิ่มลงในคอลเลกชันรูปภาพ แล้ววางทรัพยากรรูปภาพที่ได้ในกรอบรูป

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from pathlib import Path
from asposeslides.api import Presentation, SaveFormat, ShapeType, SvgImage

presentation = Presentation()
try:
    svg_content = Path("icon.svg").read_text(encoding="utf-8")
    svg_image = SvgImage(svg_content)

    image = presentation.getImages().addImage(svg_image)
    slide = presentation.getSlides().get_Item(0)
    slide.getShapes().addPictureFrame(ShapeType.Rectangle, 20, 20, 200, 200, image)

    presentation.save("svg-image.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **ไฟล์ SVG ที่มีทรัพยากรภายนอก**

SVG สามารถอ้างอิงรูปภาพ สไตล์ชีต หรือฟอนต์ภายนอก สำหรับกรณีเหล่านี้ [SvgImage](https://reference.aspose.com/slides/th/python-java/aspose.slides/svgimage/) มีคอนสตรัคเตอร์รับ [ExternalResourceResolver](https://reference.aspose.com/slides/th/python-java/aspose.slides/externalresourceresolver/) และ URI ฐาน ตัว resolver สามารถแมพ URI relativo ไปยัง URI absolute ที่อนุญาตและคืนสตรีมของทรัพยากรที่ร้องขอ

Resolver ทำให้ทรัพยากรภายนอกพร้อมใช้งานขณะ Aspose.Slides ประมวลผล SVG แต่ไม่ได้เขียนใหม่เป็นเอกสารที่มีตัวเองครบถ้วน หากต้องการให้ SVG พกพาได้ ควรฝังทรัพยากรที่จำเป็นไว้ใน SVG เอง ตัวอย่างเช่นใช้ URI `data:` สำหรับรูปภาพที่ลิงก์

เมื่อไฟล์ SVG มาจากแหล่งที่ไม่น่าเชื่อถือ ควรจำกัดสเค็ม, ที่ตั้งไฟล์, และโฮสต์ที่ resolver สามารถเข้าถึง ตัว resolver เครือข่ายควรตั้งค่า timeout, ขีดจำกัดขนาดการตอบสนอง, และการตรวจสอบความถูกต้องของเนื้อหา

### **แปลง SVG เป็นรูปทรงที่แก้ไขได้**

Aspose.Slides สามารถแปลง SVG ให้เป็นกลุ่มรูปทรงสไลด์ที่แก้ไขได้ คล้ายกับคำสั่งใน PowerPoint

![เมนูป็อปอัพ PowerPoint](img_01_01.png)

ใช้เมธอด overload ของ [ShapeCollection.addGroupShape](https://reference.aspose.com/slides/th/python-java/aspose.slides/shapecollection/#addGroupShape) ที่รับ [SvgImage] เพื่อทำการแปลง

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from pathlib import Path
from asposeslides.api import Presentation, SaveFormat, SvgImage

presentation = Presentation()
try:
    svg_content = Path("diagram.svg").read_text(encoding="utf-8")
    svg_image = SvgImage(svg_content)

    slide_size = presentation.getSlideSize().getSize()
    slide = presentation.getSlides().get_Item(0)
    slide_width = jpype.JFloat(slide_size.getWidth())
    slide_height = jpype.JFloat(slide_size.getHeight())
    slide.getShapes().addGroupShape(svg_image, 0, 0, slide_width, slide_height)

    presentation.save("editable-svg-shapes.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

ใช้การแปลง SVG‑to‑shapes เมื่อองค์ประกอบเวกเตอร์แต่ละอันต้องการแก้ไขเป็นรูปทรง PowerPoint หาก SVG เพียงต้องการแสดงผล การเก็บไว้เป็นรูปภาพจะง่ายกว่าและหลีกเลี่ยงการสร้างรูปทรงแยกหลาย ๆ รูป

## **แทนที่ทรัพยากรรูปภาพที่มีอยู่**

ใช้ [PPImage.replaceImage](https://reference.aspose.com/slides/th/python-java/aspose.slides/ppimage/#replaceImage) เมื่อคุณต้องการแทนที่ทรัพยากรรูปภาพที่มีอยู่ วิธีนี้มีประโยชน์เป็นพิเศษสำหรับกราฟิกที่ใช้ร่วมกัน เช่น โลโก้

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Images, Presentation, SaveFormat

presentation = Presentation("input.pptx")
try:
    image_to_replace = presentation.getImages().get_Item(0)

    replacement_image = Images.fromFile("new-logo.png")
    try:
        image_to_replace.replaceImage(replacement_image)
    finally:
        replacement_image.dispose()

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

หากหลายกรอบรูป, พื้นหลัง, มาสเตอร์ หรือเลย์เอาต์ใช้ทรัพยากรรูปเดียวกัน การแทนที่ทรัพยากรนั้นจะอัปเดตการใช้ทั้งหมด หากต้องการเปลี่ยนกรอบรูปเดียวเท่านั้น ให้กำหนดรูปภาพอื่นให้กับกรอบรูปนั้นแทนการแทนที่ทรัพยากรที่แชร์

[PPImage.replaceImage](https://reference.aspose.com/slides/th/python-java/aspose.slides/ppimage/#replaceImage) ยังมี overload ที่รับอาร์เรย์ไบต์หรือ [PPImage] อื่น

## **แนวทางการจัดการรูปภาพเชิงปฏิบัติ**

### **ควบคุมขนาดงานนำเสนอ**

รูปภาพ raster ขนาดใหญ่สามารถทำให้ไฟล์งานนำเสนอใหญ่มากเกินจำเป็น ใช้รูปภาพต้นฉบับที่มีขนาดมิติเหมาะสมกับการแสดงผลที่ต้องการ รีไซเคิลทรัพยากรรูปภาพที่แชร์เมื่อทำได้ และหลีกเลี่ยงการฝังสำเนาเต็มความละเอียดเดียวกันหลายครั้ง

สำหรับรูป raster ที่ได้วางไว้ในกรอบรูปแล้ว สามารถใช้ [PictureFillFormat.compressImage](https://reference.aspose.com/slides/th/python-java/aspose.slides/picturefillformat/#compressImage) เพื่อลดข้อมูลรูปภาพตามความละเอียดและการครอปที่เลือก นี่เป็นการประมวลผลกรอบรูป ไม่ใช่การจัดการคอลเลกชันรูปภาพ ดังนั้นดูที่ [กรอบรูป](/slides/th/python-java/picture-frame/) เพื่อเรียนรู้การจัดรูปแบบที่เกี่ยวข้อง

### **เลือกใช้ระหว่างเนื้อหาแบบฝังและแบบลิงก์**

การฝังทำให้งานนำพาได้ง่ายเพราะข้อมูลรูปภาพทั้งหมดถูกบรรจุอยู่ในไฟล์เดียว การลิงก์สามารถลดขนาดไฟล์ได้ แต่จะสร้างการพึ่งพาภายนอก ใช้ลิงก์เฉพาะเมื่อการพึ่งพานั้นยอมรับได้และมีความเสถียร

### **ใช้แบรนด์ที่แชร์ซ้ำ**

สำหรับโลโก้, ลายน้ำ หรือกราฟิกตกแต่งที่ต้องใช้ซ้ำหลายครั้ง ให้ใช้ทรัพยากรรูปภาพเดียวและรีไซเคิล หากกราฟิกนั้นเป็นส่วนของการออกแบบงานนำเสนอ ไม่ใช่เนื้อหาสไลด์ ให้วางไว้บนมาสเตอร์หรือเลย์เอาต์เพื่อให้สไลด์ที่สืบทอดรับมาโดยอัตโนมัติ

### **ทำให้ทรัพยากร SVG พกพาได้**

SVG ที่เป็นไฟล์อิสระง่ายต่อการย้ายและเรนเดอร์อย่างสม่ำเสมอกว่า SVG ที่ต้องพึ่งพาไฟล์หรือทรัพยากรเครือข่าย ภายในไฟล์ให้ฝังทรัพยากรที่จำเป็นก่อนนำเข้า SVG หากต้องการแก้ไขเวกเตอร์ส่วนย่อย ให้แปลง SVG เป็นรูปทรงเท่านั้น

### **ใช้ API รูปภาพข้ามแพลตฟอร์มสมัยใหม่**

สำหรับโค้ด Python via Java ใหม่ ให้ใช้วัตถุรูปภาพข้ามแพลตฟอร์มของ Aspose.Slides และ API [Images](https://reference.aspose.com/slides/th/python-java/aspose.slides/images/) แทน API สาธารณะรุ่นเก่าที่อิง `java.awt.image.BufferedImage` ดูที่ [API สมัยใหม่](/slides/th/python-java/modern-api/) เพื่อรับคำแนะนำการย้าย

WMF และ EMF ต้องพิจารณาเป็นพิเศษ เมื่อฟอร์แมตเหล่านี้ถูกส่งผ่านวัตถุรูปภาพข้ามแพลตฟอร์ม [ImageCollection.addImage](https://reference.aspose.com/slides/th/python-java/aspose.slides/imagecollection/#addImage) จะเปลี่ยน metafile ให้เป็น PNG raster ก่อนแทรก หากต้องการรักษาข้อมูล metafile ดิบ ควรใช้ overload ของ [ImageCollection.addImage](https://reference.aspose.com/slides/th/python-java/aspose.slides/imagecollection/#addImage) ที่รับสตรีม การสร้างเนื้อหา EMF จากสเปรดชีตหรือผลิตภัณฑ์อื่นเป็นกระบวนการบูรณาการแยกต่างหากและอยู่นอกขอบเขตของบทความนี้

## **คำถามที่พบบ่อย**

**ความแตกต่างระหว่างคอลเลกชันรูปภาพและกรอบรูปคืออะไร?**

คอลเลกชันรูปภาพเก็บทรัพยากรรูปภาพที่สามารถนำมาใช้ซ้ำได้ ส่วนกรอบรูปเป็นรูปทรงสไลด์ที่แสดงหนึ่งในทรัพยากรเหล่านั้นและให้การจัดรูปแบบเฉพาะของรูปภาพเช่นการครอปและเอฟเฟกต์

**วิธีที่ดีที่สุดในการแทนที่โลโก้เดียวกันทุกที่คืออะไร?**

หากโลโก้ถูกแชร์เป็นทรัพยากรรูปภาพเดียว ให้แทนที่ทรัพยากรนั้นด้วย [PPImage.replaceImage] สำหรับการแบรนด์ทั่วทั้งงานนำเสนอ สามารถวางโลโก้บนมาสเตอร์หรือเลย์เอาต์เพื่อหลีกเลี่ยงการทำซ้ำเนื้อหาสไลด์

**ทำไมรูปภาพแบบลิงก์ถึงหายไปเมื่อนำไปใช้บนคอมพิวเตอร์เครื่องอื่น?**

รูปภาพที่ลิงก์พึ่งพาไฟล์หรือ URL ภายนอก หากทรัพยากรนั้นไม่สามารถเข้าถึงจากคอมพิวเตอร์เครื่องอื่น รูปภาพลิงก์จะไม่ปรากฏ ให้ฝังรูปภาพเมื่อจำเป็นต้องทำให้งานนำเสนอเป็นไฟล์อิสระ

**สามารถแก้ไข SVG ที่แทรกเข้าไปเป็นรูปทรง PowerPoint ได้หรือไม่?**

ได้ สามารถแปลง SVG ด้วย [ShapeCollection.addGroupShape] ผลลัพธ์จะเป็นกลุ่มรูปทรงสไลด์ที่แก้ไขได้ แทนที่จะเป็นรูปภาพ SVG เพียงอันเดียว

**จะทำอย่างไรให้การนำเสนอที่มีรูปภาพจำนวนมากมีขนาดเล็กลง?**

รีไซเคิลทรัพยากรรูปภาพที่แชร์ ใช้รูปภาพ raster ที่มีขนาดไม่ใหญ่เกินความจำเป็น บีบอัดรูป raster ที่เหมาะสมเมื่อจำเป็น เก็บแบรนด์ที่ทำซ้ำบนมาสเตอร์หรือเลย์เอาต์ และใช้รูปภาพแบบลิงก์เฉพาะเมื่อการพึ่งพาภายนอกยอมรับได้