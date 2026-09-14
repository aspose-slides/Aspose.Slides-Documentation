---
title: แปลงสไลด์การนำเสนอเป็นภาพใน Python
linktitle: สไลด์เป็นภาพ
type: docs
weight: 35
url: /th/python-java/convert-slide/
keywords:
- แปลงสไลด์
- ส่งออกสไลด์
- สไลด์เป็นภาพ
- บันทึกสไลด์เป็นภาพ
- สไลด์เป็น EMF
- สไลด์เป็น PNG
- สไลด์เป็น JPEG
- สไลด์เป็นบิทแมป
- สไลด์เป็น TIFF
- PowerPoint
- OpenDocument
- การนำเสนอ
- Python
- Aspose.Slides
description: "แปลงสไลด์จากการนำเสนอรูปแบบ PPT, PPTX และ ODP เป็น PNG, JPEG, GIF, TIFF, EMF และรูปแบบภาพอื่น ๆ ใน Python กับ Aspose.Slides."
---
## **บทนำ**

Aspose.Slides for Python via Java สามารถเรนเดอร์สไลด์แต่ละสไลด์จากไฟล์นำเสนอ PowerPoint และ OpenDocument เป็นรูปแบบภาพ PNG, JPEG, GIF, TIFF และรูปแบบภาพอื่น ๆ

เพื่อแปลงสไลด์เป็นภาพ ให้ทำตามขั้นตอนต่อไปนี้:

1. โหลดไฟล์นำเสนอด้วยคลาส [Presentation](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentation/)  
2. เลือกสไลด์ที่คุณต้องการเรนเดอร์  
3. หากจำเป็น ให้กำหนดค่าการเรนเดอร์ด้วยคลาส [RenderingOptions](https://reference.aspose.com/slides/th/python-java/aspose.slides/renderingoptions/) หรือ [TiffOptions](https://reference.aspose.com/slides/th/python-java/aspose.slides/tiffoptions/)  
4. เรียกเมธอด [Slide.getImage](https://reference.aspose.com/slides/th/python-java/aspose.slides/slide/#getImage) จะคืนค่าอ็อบเจ็กต์รูปภาพ  
5. บันทึกรูปภาพและระบุรูปแบบเอาต์พุตด้วยค่า [ImageFormat](https://reference.aspose.com/slides/th/python-java/aspose.slides/imageformat/)

## **แปลงสไลด์เป็นภาพ PNG**

การแปลงที่ง่ายที่สุดใช้การตั้งค่าการเรนเดอร์เริ่มต้น โดยอ็อบเจ็กต์ภาพที่ได้สามารถประมวลผลในหน่วยความจำหรือบันทึกเป็นไฟล์ได้

ตัวอย่าง Python ด้านล่างเรนเดอร์สไลด์แรกและบันทึกเป็นภาพ PNG:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation

presentation = Presentation("Presentation.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    image = slide.getImage()
    try:
        image.save("Slide_0.png", ImageFormat.Png)
    finally:
        image.dispose()
finally:
    presentation.dispose()
```

## **แปลงสไลด์เป็นภาพด้วยขนาดกำหนดเอง**

ใช้เมธอด overload ของ [Slide.getImage](https://reference.aspose.com/slides/th/python-java/aspose.slides/slide/#getImage) ที่รับค่า [Dimension](https://docs.oracle.com/javase/8/docs/api/java/awt/Dimension.html) เพื่อเรนเดอร์สไลด์ด้วยขนาดพิกเซลที่ต้องการอย่างแม่นยำ

ตัวอย่างต่อไปนี้สร้างภาพ JPEG ขนาด 1820 × 1040 พิกเซล:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation
from java.awt import Dimension

image_size = Dimension(1820, 1040)

presentation = Presentation("Presentation.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    image = slide.getImage(image_size)
    try:
        image.save("Slide_0.jpg", ImageFormat.Jpeg)
    finally:
        image.dispose()
finally:
    presentation.dispose()
```

## **แปลงสไลด์พร้อมบันทึกโน้ตและคอมเมนต์เป็นภาพ**

โดยค่าเริ่มต้น ภาพสไลด์จะไม่รวมโน้트หรือคอมเมนต์ ให้ส่งอ็อบเจ็กต์ [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/th/python-java/aspose.slides/notescommentslayoutingoptions/) ไปยังเมธอด [RenderingOptions.setSlidesLayoutOptions](https://reference.aspose.com/slides/th/python-java/aspose.slides/renderingoptions/#setSlidesLayoutOptions) เพื่อควบคุมตำแหน่งที่โน้ตและคอมเมนต์ปรากฏ

ตัวอย่างต่อไปนี้วางโน้ตที่ถูกตัดทอนด้านล่างสไลด์และคอมเมนต์ทางด้านขวา:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import CommentsPositions, ImageFormat, NotesCommentsLayoutingOptions, NotesPositions, Presentation, RenderingOptions
from java.awt import Color

scale_x = 2.0
scale_y = scale_x

comments_area_color = Color(250, 235, 215)

layout_options = NotesCommentsLayoutingOptions()
layout_options.setNotesPosition(NotesPositions.BottomTruncated)
layout_options.setCommentsPosition(CommentsPositions.Right)
layout_options.setCommentsAreaWidth(500)
layout_options.setCommentsAreaColor(comments_area_color)

rendering_options = RenderingOptions()
rendering_options.setSlidesLayoutOptions(layout_options)

presentation = Presentation("Presentation_with_notes_and_comments.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    image = slide.getImage(rendering_options, scale_x, scale_y)
    try:
        image.save("Image_with_notes_and_comments_0.gif", ImageFormat.Gif)
    finally:
        image.dispose()
finally:
    presentation.dispose()
```

{{% alert title="Warning" color="warning" %}}
สำหรับการแปลงสไลด์เป็นภาพ อย่าใช้ [BottomFull](https://reference.aspose.com/slides/th/python-java/aspose.slides/notespositions/#BottomFull) กับเมธอด [NotesCommentsLayoutingOptions.setNotesPosition](https://reference.aspose.com/slides/th/python-java/aspose.slides/notescommentslayoutingoptions/#setNotesPosition) เนื่องจากโน้ตอาจมีข้อความมากกว่าที่ขนาดภาพคงที่จะรับได้ ให้ใช้ [BottomTruncated](https://reference.aspose.com/slides/th/python-java/aspose.slides/notespositions/#BottomTruncated) แทน
{{% /alert %}}

## **แปลงสไลด์เป็นภาพโดยใช้ตัวเลือก TIFF**

คลาส [TiffOptions](https://reference.aspose.com/slides/th/python-java/aspose.slides/tiffoptions/) ให้คุณควบคุมขนาด ความละเอียด และคุณสมบัติอื่น ๆ ของภาพ TIFF ที่เรนเดอร์

ตัวอย่างต่อไปนี้เรนเดอร์สไลด์แรกเป็นภาพ TIFF ขนาด 2160 × 2880 พิกเซล ที่ 300 DPI:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation, TiffOptions
from java.awt import Dimension

image_size = Dimension(2160, 2880)

tiff_options = TiffOptions()
tiff_options.setImageSize(image_size)
tiff_options.setDpiX(300)
tiff_options.setDpiY(300)

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    image = slide.getImage(tiff_options)
    try:
        image.save("output.tiff", ImageFormat.Tiff)
    finally:
        image.dispose()
finally:
    presentation.dispose()
```

{{% alert title="Warning" color="warning" %}}
การสนับสนุน TIFF ไม่รับประกันในรุ่น Java ที่เก่ากว่า JDK 9
{{% /alert %}}

## **แปลงสไลด์ทั้งหมดเป็นภาพ**

วนลูปผ่านคอลเลกชันสไลด์เพื่อแปลงไฟล์นำเสนอทั้งหมดเป็นชุดของภาพ สไลด์ที่ซ่อนอยู่จะรวมอยู่ด้วย เว้นแต่คุณจะข้ามโดยเจตนา

ตัวอย่างต่อไปนี้เรนเดอร์ทุกสไลด์เป็นภาพ JPEG ด้วยอัตราการขยายแนวนอนและแนวตั้งเป็น 2 เท่า:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation

scale_x = 2.0
scale_y = scale_x

presentation = Presentation("Presentation.pptx")
try:
    slide_count = presentation.getSlides().size()
    for index in range(slide_count):
        slide = presentation.getSlides().get_Item(index)
        image = slide.getImage(scale_x, scale_y)
        try:
            image.save(f"Slide_{index}.jpg", ImageFormat.Jpeg)
        finally:
            image.dispose()
finally:
    presentation.dispose()
```

## **สร้างเอาต์พุตเป็น Enhanced Metafile**

Enhanced Metafile (EMF) มีประโยชน์เมื่อกราฟิกแบบเวกเตอร์ต้องแลกเปลี่ยนกับ Microsoft Office หรือแอปพลิเคชัน Windows อื่นที่รองรับ Windows metafiles ต่างจากภาพพิกเซล EMF สามารถเก็บการดำเนินการวาดเวกเตอร์ที่ขยายได้โดยไม่สูญเสียความคมชัด อย่างไรก็ตาม EMF เป็นรูปแบบที่เน้นความเข้ากันได้สำหรับแอปพลิเคชันที่รองรับ Windows metafile ไม่ใช่รูปแบบแลกเปลี่ยนสากล นอกจากนี้ เนื้อหาสไลด์ที่ซับซ้อน เช่น ภาพบิตแมปและเอฟเฟกต์บางอย่าง อาจถูกจัดเก็บเป็นองค์ประกอบราสเตอร์ภายในคอนเทนเนอร์เมตาฟายล์เวกเตอร์

### **ส่งออกสไลด์เป็น EMF**

เมธอด [Slide.writeAsEmf](https://reference.aspose.com/slides/th/python-java/aspose.slides/slide/) เขียน [Slide](https://reference.aspose.com/slides/th/python-java/aspose.slides/slide/) ไปยังสตรีมเป้าหมายในรูปแบบ EMF ตัวอย่างต่อไปนี้โหลดไฟล์นำเสนอ เลือกสไลด์แรก แล้วเขียนเป็นสตรีมไฟล์ EMF:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation
from java.io import FileOutputStream

presentation = Presentation("Presentation.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    emf_stream = FileOutputStream("Slide_0.emf")
    try:
        slide.writeAsEmf(emf_stream)
    finally:
        emf_stream.close()
finally:
    presentation.dispose()
```

ผู้เรียกต้องเป็นเจ้าของสตรีมที่ส่งให้กับ [Slide.writeAsEmf](https://reference.aspose.com/slides/th/python-java/aspose.slides/slide/) และต้องรับผิดชอบปิดสตรีมนั้นตามที่แสดงข้างต้น

### **แปลงภาพ SVG เป็น EMF แล้วใส่ลงในไฟล์นำเสนอ**

ใช้ [SvgImage.writeAsEmf](https://reference.aspose.com/slides/th/python-java/aspose.slides/svgimage/) เพื่อแปลงเนื้อหา SVG เป็น EMF ไบต์ที่ได้สามารถเพิ่มลงในไฟล์นำเสนอผ่าน [ImageCollection.addImage](https://reference.aspose.com/slides/th/python-java/aspose.slides/imagecollection/#addImage) และวางบนสไลด์ด้วย [ShapeCollection.addPictureFrame](https://reference.aspose.com/slides/th/python-java/aspose.slides/shapecollection/#addPictureFrame)

ตัวอย่างต่อไปนี้สร้าง [SvgImage](https://reference.aspose.com/slides/th/python-java/aspose.slides/svgimage/) จากโค้ด SVG แปลงเป็น EMF ในหน่วยความจำ แทรกเมตาฟายล์ลงบนสไลด์แรก และบันทึกไฟล์นำเสนอ:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType, SvgImage
from java.io import ByteArrayOutputStream

svg_content = "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"200\" height=\"100\"><rect width=\"200\" height=\"100\" fill=\"#4472C4\"/></svg>"
svg_image = SvgImage(svg_content)

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    emf_stream = ByteArrayOutputStream()
    try:
        svg_image.writeAsEmf(emf_stream)

        emf_data = emf_stream.toByteArray()
        image = presentation.getImages().addImage(emf_data)
        slide.getShapes().addPictureFrame(ShapeType.Rectangle, 20, 20, 200, 100, image)
    finally:
        emf_stream.close()

    presentation.save("Presentation_with_emf.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

[SvgImage.writeAsEmf](https://reference.aspose.com/slides/th/python-java/aspose.slides/svgimage/) ไม่รับครอบครองสตรีมปลายทาง [ByteArrayOutputStream](https://docs.oracle.com/javase/8/docs/api/java/io/ByteArrayOutputStream.html) จะเก็บข้อมูลที่สร้างทั้งหมดในหน่วยความจำ ดังนั้นจึงไม่ต้องรีเซ็ตตำแหน่งก่อนเรียก [ByteArrayOutputStream.toByteArray](https://docs.oracle.com/javase/8/docs/api/java/io/ByteArrayOutputStream.html#toByteArray--) ไบต์อาร์เรย์ที่คืนค่าจะยังคงใช้ได้หลังจากสตรีมถูกปิด

การสร้าง EMF มีให้ใช้บนระบบปฏิบัติการที่สนับสนุนโดย Aspose.Slides for Python via Java และการกำหนดค่า JDK ที่เลือก อย่างไรก็ตาม การเรนเดอร์อาจแตกต่างกันในแต่ละแพลตฟอร์มเมื่อฟอนต์หรือกราฟิกที่ต้องการไม่มี การติดตั้งฟอนต์ที่ใช้ในเนื้อหาแหล่งที่มาติดตั้งหรือกำหนดค่าการทดแทนที่เหมาะสม ปฏิบัติตาม [ความต้องการของแพลตฟอร์ม](/slides/th/python-java/system-requirements/) สำหรับ Aspose.Slides for Python via Java และตรวจสอบผลลัพธ์ในแอปพลิเคชันที่รับ EMF ผลลัพธ์ Linux และ macOS บางครั้งอาจมีการสนับสนุนแสดงและแก้ไข Windows metafile ที่จำกัดหรือไม่สอดคล้องกัน

## **การเรนเดอร์สี Emoji**

{{% alert title="Note" color="info" %}}
เพื่อให้สี Emoji แสดงผลอย่างถูกต้องเมื่อแปลงสไลด์เป็นภาพ ฟอนต์ Emoji ที่ใช้ในไฟล์นำเสนอต้องถูกติดตั้งและพร้อมใช้งานบนระบบที่ทำการแปลง ตัวอย่างเช่น หากไฟล์นำเสนอใช้ **Segoe UI Emoji** แต่ฟอนต์นี้ไม่มีอยู่ Emoji อาจปรากฏเป็นสีขาวดำในภาพเอาต์พุต
{{% /alert %}}

## **คำถามที่พบบ่อย**

**Aspose.Slides รองรับการเรนเดอร์สไลด์พร้อมแอนิเมชันหรือไม่?**

ไม่ เมธอด [Slide.getImage](https://reference.aspose.com/slides/th/python-java/aspose.slides/slide/#getImage) จะเรนเดอร์ภาพนิ่งของสไลด์และไม่ส่งออกแอนิเมชัน

**สไลด์ที่ซ่อนไว้สามารถส่งออกเป็นภาพได้หรือไม่?**

ได้ สามารถเรนเดอร์สไลด์ที่ซ่อนไว้เช่นสไลด์ปกติ รวมไว้ในลูปการประมวลผลตามตัวอย่างข้างต้น

**เงาและเอฟเฟกต์อื่น ๆ จะถูกรักษาในภาพสไลด์หรือไม่?**

ได้ Aspose.Slides จะเรนเดอร์เงา ความโปร่งแสง และเอฟเฟกต์กราฟิกอื่น ๆ ที่รองรับในภาพสไลด์