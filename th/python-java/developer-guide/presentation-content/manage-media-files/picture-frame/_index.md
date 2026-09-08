---
title: จัดการ Picture Frame ในงานนำเสนอโดยใช้ Python
linktitle: กรอบรูป
type: docs
weight: 10
url: /th/python-java/picture-frame/
keywords:
- กรอบรูป
- เพิ่มกรอบรูป
- สร้างกรอบรูป
- ภาพที่ฝังอยู่
- ภาพที่เชื่อมโยง
- สกัดภาพ
- ภาพแรสเตอร์
- ภาพ SVG
- ครอบภาพ
- ลบพื้นที่ที่ครอบ
- บีบอัดภาพ
- StretchOffset
- การจัดรูปแบบกรอบรูป
- สเกลสัมพัทธ์
- เอฟเฟกต์ภาพ
- อัตราส่วนภาพ
- PowerPoint
- OpenDocument
- งานนำเสนอ
- Python
- Java
- Aspose.Slides
description: สร้าง, จัดรูปแบบ, เชื่อมโยง, ครอบ, สกัด, และบีบอัดกรอบรูปในงานนำเสนอด้วย Aspose.Slides สำหรับ Python ผ่าน Java.
---
## **ภาพรวม**

Picture frame คือรูปแบบสไลด์ที่แสดงภาพ ใน Aspose.Slides แหล่งภาพและรูปแบบที่แสดงมันเป็นออบเจ็กต์ที่แยกจากกัน: a [Presentation](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentation/) มีแหล่งภาพที่ฝังอยู่ผ่าน [ImageCollection](https://reference.aspose.com/slides/th/python-java/aspose.slides/imagecollection/), ในขณะที่ [PictureFrame](https://reference.aspose.com/slides/th/python-java/aspose.slides/pictureframe/) ควบคุมตำแหน่ง ขนาด การจัดรูปแบบเส้น การหมุน การครอบภาพ เอฟเฟกต์รูปภาพ และการตั้งค่าระดับเฟรมอื่น ๆ

การแยกนี้มีประโยชน์เมื่อภาพเดียวกันต้องแสดงหลายครั้ง เพิ่มภาพลงในการนำเสนอครั้งเดียว เก็บ [PPImage](https://reference.aspose.com/slides/th/python-java/aspose.slides/ppimage/) ที่คืนค่าไว้และใช้แหล่งภาพนั้นเมื่อสร้าง picture frame

Picture frame สามารถบรรจุภาพแรสเตอร์เช่น PNG หรือ JPEG และภาพเวกเตอร์ SVG ได้ ทั้งยังสามารถอ้างอิงภาพที่เชื่อมโยงแทนการเก็บไบต์ของภาพไว้ในงานนำเสนอ การเลือกวิธีนี้ส่งผลต่อความพกพา ขนาดไฟล์ การสกัดและพฤติกรรมการส่งออก ดังนั้นควรตัดสินใจว่าภาพควรจะจัดเก็บอย่างไรก่อนทำการจัดรูปแบบหรือการเพิ่มประสิทธิภาพ

## **เพิ่มและจัดรูปแบบภาพที่ฝังไว้**

สำหรับภาพที่ฝังไว้ ให้เพิ่มข้อมูลภาพลงในงานนำเสนอและสร้าง picture frame ด้วย [ShapeCollection.addPictureFrame](https://reference.aspose.com/slides/th/python-java/aspose.slides/shapecollection/#addPictureFrame) ภาพจะกลายเป็นส่วนหนึ่งของแพ็กเกจงานนำเสนอ ทำให้งานนำเสนอคงเป็นแบบอิสระเมื่อนำไปยังคอมพิวเตอร์เครื่องอื่น

ตัวอย่างต่อไปนี้เพิ่มภาพ JPEG สร้างเฟรมที่ขนาดดั้งเดิมของภาพและทำการจัดรูปแบบเส้นและการหมุน:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from java.awt import Color
from asposeslides.api import FillType, Images, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    source_image = Images.fromFile("photo.jpg")
    try:
        image = presentation.getImages().addImage(source_image)
    finally:
        source_image.dispose()

    picture_frame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 100, image.getWidth(), image.getHeight(), image)
    picture_frame.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    picture_frame.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE)
    picture_frame.getLineFormat().setWidth(3)
    picture_frame.setRotation(15)

    presentation.save("picture-frame.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Picture frame ควบคุมเรขาคณิตที่แสดง; การเปลี่ยนขนาดเฟรมไม่ได้เปลี่ยนมิติพิกเซลดั้งเดิมที่เก็บในแหล่งภาพที่ฝังไว้ ความแตกต่างนี้สำคัญเมื่อทำการครอบหรือบีบอัดภาพในภายหลัง

## **ใช้สเกลสัมพัทธ์**

[PictureFrame](https://reference.aspose.com/slides/th/python-java/aspose.slides/pictureframe/) เปิดเผยการสเกลความกว้างและความสูงแบบสัมพัทธ์สำหรับเฟรมผ่าน [setRelativeScaleWidth](https://reference.aspose.com/slides/th/python-java/aspose.slides/pictureframe/#setRelativeScaleWidth) และ [setRelativeScaleHeight](https://reference.aspose.com/slides/th/python-java/aspose.slides/pictureframe/#setRelativeScaleHeight) ค่า `1.0` เทียบเท่ากับ 100% ของขนาดภาพต้นฉบับ สเกลสัมพัทธ์มีประโยชน์เมื่อเวิร์กโฟลว์ต้องคงความสัมพันธ์กับขนาดภาพต้นฉบับแทนการคำนวณขนาดสุดท้ายด้วยตนเอง

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Images, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    source_image = Images.fromFile("photo.jpg")
    try:
        image = presentation.getImages().addImage(source_image)
    finally:
        source_image.dispose()

    picture_frame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 50, 100, 100, image)
    picture_frame.setRelativeScaleWidth(1.35)
    picture_frame.setRelativeScaleHeight(0.8)

    presentation.save("relative-scale.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

สเกลสัมพัทธ์เปลี่ยนการตั้งค่าการสเกลของเฟรม; ไม่ทำการสุ่มตัวอย่างหรือบีบอัดภาพที่ฝังไว้

## **ภาพที่ฝังและภาพที่เชื่อมโยง**

ภาพที่ฝังไว้จะเก็บข้อมูลภาพภายในงานนำเสนอจึงเป็นตัวเลือกที่ปลอดภัยที่สุดสำหรับความพกพาและการเรนเดอร์ที่คาดเดาได้ ส่วนภาพที่เชื่อมโยงจะเก็บตำแหน่งภายนอกผ่านเมธ็อด [Picture.setLinkPathLong](https://reference.aspose.com/slides/th/python-java/aspose.slides/picture/#setLinkPathLong) แทนการฝังข้อมูลภาพในลักษณะเดียวกัน

ภาพที่เชื่อมโยงสามารถลดปริมาณข้อมูลภาพที่เก็บใน PPTX ได้ แต่จะเพิ่มการพึ่งพาไฟล์ภายนอก ไฟล์ที่เชื่อมโยงต้องยังคงเข้าถึงได้สำหรับแอปพลิเคชันที่เปิดหรือเรนเดอร์งานนำเสนอ หากเส้นทางเปลี่ยน ไฟล์ย้าย หรือแหล่งข้อมูลไม่พร้อมใช้งาน picture frame ที่เชื่อมโยงอาจไม่แสดงตามคาด สำหรับงานนำเสนอที่ต้องส่งทางอีเมล เก็บถาวร หรือเรนเดอร์ในสภาพแวดล้อมแยก การฝังภาพมักจะน่าเชื่อถือกว่า

### **เพิ่มภาพที่เชื่อมโยง**

ตัวอย่างต่อไปนี้สร้าง picture frame และชี้ไปที่ไฟล์ภาพในเครื่อง มุ่งเน้นที่การเชื่อมโยงภาพเท่านั้น; การเชื่อมโยงวิดีโอเป็นเวิร์กโฟลว์สื่อที่แยกออกและไม่ได้ผสานในตัวอย่างนี้โดยเจตนา

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from pathlib import Path
from asposeslides.api import Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    picture_frame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 50, 320, 180, None)
    linked_image_file = Path("linked-image.jpg").resolve()
    link_path = str(linked_image_file)
    picture_frame.getPictureFormat().getPicture().setLinkPathLong(link_path)

    presentation.save("linked-image.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

ใช้ลิงก์เมื่อการจัดการไฟล์ภายนอกเป็นเจตนา อย่าใช้เป็นวิธีทดแทนการบีบอัด: PPTX ขนาดเล็กที่มีการพึ่งพาภาพเสียหายมักจะใช้ได้น้อยกว่าการนำเสนอขนาดใหญ่ที่เป็นอิสระ

## **สกัดภาพจาก PictureFrame**

ก่อนสกัดภาพจากงานนำเสนอที่มีอยู่ ตรวจสอบให้แน่ใจว่า shape เป็น [PictureFrame](https://reference.aspose.com/slides/th/python-java/aspose.slides/pictureframe/) จริงและมีภาพที่ฝังอยู่ Picture frame ที่เชื่อมโยงอาจไม่มีไบต์ของภาพที่สามารถสกัดได้ในลักษณะเดียวกัน

### **สกัดภาพแรสเตอร์**

API ภาพสมัยใหม่ทำงานกับภาพแรสเตอร์โดยตรงและไม่ต้องการ wrapper ของ Java รุ่นเก่า ตัวอย่างต่อไปนี้ค้นหาภาพแรสเตอร์ที่ฝังอยู่แรกบนสไลด์และบันทึกเป็น PNG:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation, PictureFrame

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    for shape in slide.getShapes():
        if not isinstance(shape, PictureFrame):
            continue

        picture_frame = shape
        embedded_image = picture_frame.getPictureFormat().getPicture().getImage()
        if embedded_image is None or embedded_image.getSvgImage() is not None:
            continue

        raster_image = embedded_image.getImage()
        try:
            raster_image.save("extracted-image.png", ImageFormat.Png)
        finally:
            raster_image.dispose()
        break
finally:
    presentation.dispose()
```

การบันทึกภาพแรสเตอร์จะเปลี่ยนภาพที่สกัดเป็นรูปแบบเอาต์พุตที่ร้องขอ หากต้องการไบต์ที่เข้ารหัสที่เก็บในงานนำเสนอแทนไฟล์แรสเตอร์ที่แปลงแล้ว ให้ใช้ข้อมูลไบนารีของแหล่งภาพแทน

### **สกัดภาพ SVG**

สำหรับภาพ SVG, [PPImage](https://reference.aspose.com/slides/th/python-java/aspose.slides/ppimage/) เปิดเผยอ็อบเจ็กต์ [SvgImage](https://reference.aspose.com/slides/th/python-java/aspose.slides/svgimage/) ซึ่งทำให้คุณดึงข้อมูล SVG โดยตรงแทนการเรซอร์ตภาพก่อน

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from pathlib import Path
from asposeslides.api import Presentation, PictureFrame

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    for shape in slide.getShapes():
        if not isinstance(shape, PictureFrame):
            continue

        picture_frame = shape
        embedded_image = picture_frame.getPictureFormat().getPicture().getImage()
        svg_image = embedded_image.getSvgImage() if embedded_image is not None else None
        if svg_image is None:
            continue

        svg_data = svg_image.getSvgData()
        Path("extracted-image.svg").write_bytes(bytes(svg_data))
        break
finally:
    presentation.dispose()
```

การเก็บเนื้อหา SVG เป็น SVG จะคงแหล่งเวกเตอร์ไว้ในงานนำเสนอ การส่งออกเป็นแรสเตอร์เช่น PNG หรือ JPEG จะต้องเรนเดอร์เนื้อหาเวกเตอร์เป็นพิกเซล การส่งออกสไลด์เป็น PDF หรือ SVG ก็เป็นการเรนเดอร์เช่นกัน ดังนั้นกราฟิกที่ส่งออกไม่ควรถือเป็นสำเนาแบบไบต์ต่อไบต์ของ SVG ที่ฝังไว้; ใช้ข้อมูล [SvgImage.getSvgData](https://reference.aspose.com/slides/th/python-java/aspose.slides/svgimage/#getSvgData) เมื่อต้องการแหล่งเวกเตอร์ต้นฉบับ

## **ครอบภาพ**

การครอบเปลี่ยนส่วนของภาพที่มองเห็นได้ภายในเฟรม ค่า crop บน [PictureFillFormat](https://reference.aspose.com/slides/th/python-java/aspose.slides/picturefillformat/) เป็นเปอร์เซ็นต์ของมิติภาพต้นฉบับ การครอบไม่ได้ลบพิกเซลที่ซ่อนอยู่จากภาพที่ฝังไว้ในตอนแรก; เพียงเปลี่ยนพื้นที่ที่มองเห็น

ตัวอย่างต่อไปนี้ค้นหา picture frame อย่างปลอดภัยและนำค่า crop ไปใช้:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, PictureFrame

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    picture_frame = None

    for shape in slide.getShapes():
        if isinstance(shape, PictureFrame):
            picture_frame = shape
            break

    if picture_frame is not None:
        picture_frame.getPictureFormat().setCropLeft(23.6)
        picture_frame.getPictureFormat().setCropRight(21.5)
        picture_frame.getPictureFormat().setCropTop(3)
        picture_frame.getPictureFormat().setCropBottom(31)
        presentation.save("cropped-image.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

เนื่องจากข้อมูลภาพที่ซ่อนอยู่ยังคงอยู่ การครอบจึงสามารถเปลี่ยนแปลงได้ในภายหลังโดยไม่สูญเสียพิกเซลต้นฉบับ หากขนาดไฟล์สำคัญกว่าการย้อนกลับ สามารถลบพื้นที่ที่ครอบจริง ๆ ได้ตามที่อธิบายในส่วนต่อไป

## **ลบข้อมูลภาพที่ถูกครอบ**

[PictureFillFormat.deletePictureCroppedAreas](https://reference.aspose.com/slides/th/python-java/aspose.slides/picturefillformat/#deletePictureCroppedAreas) ลบข้อมูลภาพที่อยู่นอกสี่เหลี่ยมครอบปัจจุบันและคืนค่าแหล่งภาพที่ได้ ผลลัพธ์สามารถลดขนาดไฟล์ได้ แต่เป็นการเพิ่มประสิทธิภาพที่ทำลาย: หลังจากบันทึกงานนำเสนอ พิกเซลที่ถูกลบจะไม่มีให้ใช้ในการยกเลิกการครอบในภายหลัง

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, PictureFrame

presentation = Presentation("cropped-image.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    picture_frame = None

    for shape in slide.getShapes():
        if isinstance(shape, PictureFrame):
            picture_frame = shape
            break

    if picture_frame is not None:
        cropped_image = picture_frame.getPictureFormat().deletePictureCroppedAreas()
        if cropped_image is not None:
            presentation.save("cropped-data-removed.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

เมธ็อดอาจเพิ่มแหล่งภาพใหม่ลงในงานนำเสนอ หากภาพต้นฉบับยังถูกใช้โดย picture frame อื่น ๆ เฟรมเหล่านั้นยังต้องใช้แหล่งภาพที่มีอยู่เดิม ดังนั้นการลบพื้นที่ที่ครอบอาจไม่ลดจำนวนภาพทั้งหมด การครอบเนื้อหา WMF หรือ EMF ด้วยเมธ็อดนี้จะทำให้ผลลัพธ์ที่ครอบเป็น PNG

## **บีบอัดภาพแรสเตอร์**

[PictureFillFormat.compressImage](https://reference.aspose.com/slides/th/python-java/aspose.slides/picturefillformat/#compressImage) ลดความละเอียดของภาพแรสเตอร์สัมพันธ์กับขนาดที่ภาพถูกแสดง สามารถลบพื้นที่ที่ครอบในขั้นตอนเดียวได้ เมธ็อดคืนค่า `True` เมื่อภาพถูกปรับขนาดหรือครอบ และ `False` เมื่อไม่มีการเปลี่ยนแปลงใด ๆ จำเป็น

ใช้ค่าที่กำหนดไว้ล่วงหน้าใน [PicturesCompression](https://reference.aspose.com/slides/th/python-java/aspose.slides/picturescompression/) เมื่อความละเอียดเป้าหมายมาตรฐานเพียงพอ:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PicturesCompression, Presentation, SaveFormat, PictureFrame

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    picture_frame = None

    for shape in slide.getShapes():
        if isinstance(shape, PictureFrame):
            picture_frame = shape
            break

    if picture_frame is not None:
        compressed = picture_frame.getPictureFormat().compressImage(True, PicturesCompression.Dpi150)
        print("The image was compressed." if compressed else "No compression was necessary.")
        presentation.save("compressed-image.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

สามารถส่งค่าดีพีไอบวกที่กำหนดเองแทนค่าที่กำหนดล่วงหน้าเมื่อจำเป็นต้องมีเป้าหมายเฉพาะ

การบีบอัดมุ่งเน้นที่ภาพแรสเตอร์ SVG และเนื้อหาเมตาไฟล์จะไม่ถูกลดโดยกระบวนการบีบอัดแรสเตอร์นี้ นอกจากนี้จำไว้ว่า ความละเอียดต่ำและการลบพื้นที่ที่ครอบไม่สามารถกู้คืนจากงานนำเสนอที่ได้ทำการเพิ่มประสิทธิภาพแล้ว เลือกความละเอียดเป้าหมายตามขนาดสูงสุดที่ภาพจะถูกมองเห็นหรือส่งออกจริง ๆ แทนการใช้ค่าดีพีไอต่ำสุดทั่วทั้งเอกสาร

## **จัดการเอฟเฟกต์การแปลงภาพ**

สำหรับเวิร์กโฟลว์ครบถ้วนที่ครอบคลุมความสว่าง คอนทราสต์ การแปลงสี เบลอ เอฟเฟกต์อัลฟ่า โซ่ที่จัดลำดับ การตรวจสอบ การลบและการตรวจสอบรอบต่อรอบ ดูที่ [Image Transform Effects](/slides/th/python-java/image-transform-effects/)

## **ล็อกเรขาคณิตของ PictureFrame**

การตั้งค่า [PictureFrameLock] ควบคุมการดำเนินการแก้ไขที่ถูกปิดสำหรับ picture frame ตัวอย่างเช่น [setAspectRatioLocked](https://reference.aspose.com/slides/th/python-java/aspose.slides/pictureframelock/#setAspectRatioLocked) จะคงอัตราส่วนของรูปเมื่อทำการปรับขนาด

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Images, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    source_image = Images.fromFile("photo.jpg")
    try:
        image = presentation.getImages().addImage(source_image)
    finally:
        source_image.dispose()

    picture_frame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 100, image.getWidth(), image.getHeight(), image)
    picture_frame.getPictureFrameLock().setAspectRatioLocked(True)

    presentation.save("locked-picture-frame.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

การล็อกจะนำไปใช้กับรูปแบบ picture frame ไม่บังคับให้ภาพต้นฉบับถูกสุ่มตัวอย่างหรือเปลี่ยนอัตราส่วนอย่างถาวร

## **ปรับค่า StretchOffset**

เมื่อโหมดเติมภาพเป็น stretch ค่าการ offset บน [PictureFillFormat](https://reference.aspose.com/slides/th/python-java/aspose.slides/picturefillformat/) จะกำหนดสี่เหลี่ยมเติมสัมพันธ์กับกล่องขอบของ picture frame ค่าเปอร์เซ็นต์บวกสร้างการเยื้องจากขอบ ส่วนค่าเปอร์เซ็นต์ลบสร้างการขยายออก

นี่แตกต่างจากการครอบ ค่าครอบเลือกส่วนของภาพต้นฉบับที่จะแสดง; stretch offset จะเปลี่ยนสี่เหลี่ยมที่ภาพเติมที่มองเห็นถูกยืด

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Images, PictureFillMode, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    source_image = Images.fromFile("photo.png")
    try:
        image = presentation.getImages().addImage(source_image)
    finally:
        source_image.dispose()

    picture_frame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 10, 10, 400, 300, image)
    picture_frame.getPictureFormat().setPictureFillMode(PictureFillMode.Stretch)
    picture_frame.getPictureFormat().setStretchOffsetLeft(12)
    picture_frame.getPictureFormat().setStretchOffsetRight(12)
    picture_frame.getPictureFormat().setStretchOffsetTop(8)
    picture_frame.getPictureFormat().setStretchOffsetBottom(8)

    presentation.save("stretch-offsets.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

ใช้ stretch offset สำหรับการวางตำแหน่งการเติม ใช้คุณสมบัติการครอบเมื่อเป้าหมายคือซ่อนขอบของภาพต้นฉบับ

## **การจัดเก็บ ขนาดไฟล์และข้อพิจารณาการส่งออก**

การตัดสินใจหลักจะง่ายขึ้นเมื่อการจัดเก็บภาพและการจัดรูปแบบ picture‑frame แยกกัน:

- **รูปภาพที่ฝังไว้** ทำให้การนำเสนอเป็นอิสระและเชื่อถือได้สูงสุดสำหรับการแชร์และการเรนเดอร์บนเซิร์ฟเวอร์ แต่ภาพแรสเตอร์ขนาดใหญ่จะทำให้ไฟล์ PPTX ใหญ่ขึ้นและใช้หน่วยความจำมากกว่า
- **รูปภาพที่เชื่อมโยง** สามารถทำให้แพ็กเกจเล็กลงได้ แต่การนำเสนอจะขึ้นอยู่กับไฟล์ภายนอกที่ต้องคงอยู่ที่ตำแหน่งหรือที่เก็บที่ระบุ
- **การครอบ** เริ่มต้นเป็นแบบไม่ทำลาย พิกเซลที่ซ่อนอยู่ยังคงฝังอยู่จนกว่าจะลบพื้นที่ที่ครอบอย่างชัดเจนหรือระหว่างการบีบอัด
- **การบีบอัด** สามารถลดขนาดไฟล์อย่างมากสำหรับภาพแรสเตอร์ที่ใหญ่เกินไป แต่จะเสียความละเอียดต้นฉบับ ควรทำหลังจากทราบขนาดบนสไลด์ที่ต้องการแล้ว
- **ภาพ SVG** ควรคงเป็น SVG เมื่อความคงที่ของเวกเตอร์สำคัญ สกัด SVG ที่ฝังไว้โดยตรงเมื่อต้องการแหล่งเวกเตอร์เอง การส่งออกสไลด์เป็นแรสเตอร์จะเปลี่ยน SVG เป็นพิกเซลเสมอ
- **ภาพที่ใช้ซ้ำ** ควรใช้แหล่ง [PPImage](https://reference.aspose.com/slides/th/python-java/aspose.slides/ppimage/) เดิมเมื่อต้องการแทนการโหลดไฟล์เดียวกันหลายครั้งในเวิร์กโฟลว์

สำหรับงานนำเสนอขนาดใหญ่ การเพิ่มประสิทธิภาพภาพมักจะได้ผลดีที่สุดเมื่อทำแบบเลือกสรร: เก็บโลโก้และแผนภาพเป็นเนื้อหาเวกเตอร์ บีบอัดรูปถ่ายตามขนาดการแสดงที่แท้จริง ลบพิกเซลที่ครอบเฉพาะเมื่อไม่ต้องการแก้ไขต่อภายหลัง และหลีกเลี่ยงลิงก์ภายนอกเว้นแต่การจัดการการพึ่งพาจะเป็นส่วนหนึ่งของการออกแบบการใช้งาน

## **คำถามที่พบบ่อย**

**ความแตกต่างระหว่าง picture frame กับแหล่งภาพคืออะไร?**

[PPImage](https://reference.aspose.com/slides/th/python-java/aspose.slides/ppimage/) แทนแหล่งภาพที่เชื่อมโยงกับงานนำเสนอ ส่วน [PictureFrame](https://reference.aspose.com/slides/th/python-java/aspose.slides/pictureframe/) คือรูปแบบบนสไลด์ที่แสดงภาพและเก็บเรขาคณิตและการจัดรูปแบบระดับเฟรม เช่น ขนาด การหมุน ค่าครอบ เอฟเฟกต์และการล็อก

**ควรฝังหรือเชื่อมโยงภาพ?**

ควรฝังภาพเมื่อการนำเสนอจำเป็นต้องพกพา เก็บถาวร หรือเรนเดอร์โดยไม่ต้องพึ่งพาแหล่งภายนอก เชื่อมโยงภาพเฉพาะเมื่อต้องการเก็บไฟล์ภาพแยกจาก PPTX อย่างตั้งใจและสามารถดูแลตำแหน่งภายนอกได้อย่างเชื่อถือได้

**การครอบลดขนาดไฟล์ PPTX หรือไม่?**

ไม่โดยตรง การตั้งค่าครอบธรรมดาจะซ่อนส่วนของภาพต้นฉบับแต่ยังคงเก็บพิกเซลไว้ ใช้ [PictureFillFormat.deletePictureCroppedAreas](https://reference.aspose.com/slides/th/python-java/aspose.slides/picturefillformat/#deletePictureCroppedAreas) หรือการบีบอัดภาพพร้อมการลบพื้นที่ที่ครอบเมื่อพิกเซลเหล่านั้นสามารถทิ้งได้อย่างถาวร

**สามารถคืนคุณภาพภาพหลังการบีบอัดได้หรือไม่?**

ไม่ได้ การบีบอัดอาจลดความละเอียดแรสเตอร์ที่เก็บไว้และการลบพื้นที่ที่ครอบจะทำให้ข้อมูลภาพหายไป ควรเก็บภาพต้นฉบับนอกงานนำเสนอหากต้องการแก้ไขความละเอียดสูงในภายหลัง

**ควรจัดการภาพ SVG อย่างไร?**

ควรเก็บเนื้อหา SVG เป็น SVG เมื่อความคงที่ของเวกเตอร์สำคัญ สามารถสกัด [SvgImage](https://reference.aspose.com/slides/th/python-java/aspose.slides/svgimage/) ที่ฝังไว้โดยตรง การเรนเดอร์สไลด์เป็นรูปแบบแรสเตอร์เช่น PNG หรือ JPEG จะทำให้ SVG ถูกแปลงเป็นพิกเซล

**จะหลีกเลี่ยงการแคสต์ที่ไม่ปลอดภัยเมื่ออ่านสไลด์ที่มีอยู่ได้อย่างไร?**

ตรวจสอบประเภทของ shape ก่อนใช้สมาชิกเฉพาะ picture‑frame การตรวจสอบ `isinstance` กับ [PictureFrame](https://reference.aspose.com/slides/th/python-java/aspose.slides/pictureframe/) จะป้องกันการแคสต์ที่ไม่ถูกต้องและทำให้โค้ดจัดการกับสไลด์ที่ไม่มี picture frame ได้อย่างเหมาะสม