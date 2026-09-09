---
title: จัดการ Picture Frame ในงานนำเสนอด้วย Python
linktitle: Picture Frame
type: docs
weight: 10
url: /th/python-java/picture-frame/
keywords:
- picture frame
- เพิ่ม picture frame
- สร้าง picture frame
- รูปภาพฝังไว้
- รูปภาพเชื่อมโยง
- สกัดรูปภาพ
- รูปภาพ raster
- รูปภาพ SVG
- ครอปรูปภาพ
- ลบพื้นที่ที่ครอป
- บีบอัดรูปภาพ
- StretchOffset
- การจัดรูปแบบ picture frame
- สเกลสัมพัทธ์
- เอฟเฟกต์รูปภาพ
- อัตราส่วน
- PowerPoint
- OpenDocument
- งานนำเสนอ
- Python
- Java
- Aspose.Slides
description: "สร้าง, จัดรูปแบบ, เชื่อมโยง, ครอป, สกัด, และบีบอัด picture frame ในงานนำเสนอด้วย Aspose.Slides สำหรับ Python ผ่าน Java."
---
## **ภาพรวม**

Picture frame คือรูปทรงบนสไลด์ที่แสดงรูปภาพ ใน Aspose.Slides, แหล่งข้อมูลรูปภาพและรูปทรงที่แสดงรูปภาพเป็นอ็อบเจ็กต์แยกกัน: [Presentation](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentation/) เป็นเจ้าของแหล่งข้อมูลรูปภาพที่ฝังไว้ผ่าน [ImageCollection](https://reference.aspose.com/slides/th/python-java/aspose.slides/imagecollection/), ในขณะที่ [PictureFrame](https://reference.aspose.com/slides/th/python-java/aspose.slides/pictureframe/) ควบคุมตำแหน่งของรูปภาพ, ขนาด, การจัดรูปแบบเส้น, การหมุน, การครอป, เอฟเฟกต์รูปภาพ, และการตั้งค่าระดับเฟรมอื่นๆ

การแยกนี้มีประโยชน์เมื่อรูปภาพเดียวกันถูกแสดงมากกว่าหนึ่งครั้ง เพิ่มรูปภาพลงในงานนำเสนอเพียงครั้งเดียว, เก็บ [PPImage](https://reference.aspose.com/slides/th/python-java/aspose.slides/ppimage/) ที่คืนค่า, แล้วใช้แหล่งข้อมูลรูปภาพนั้นเมื่อสร้าง picture frame

Picture frame สามารถบรรจุรูปภาพแบบ raster เช่น PNG หรือ JPEG และรูปภาพเวกเตอร์ SVG ได้ นอกจากนี้ยังสามารถอ้างอิงรูปภาพที่เชื่อมโยง (linked) แทนการเก็บไบต์ของรูปภาพในงานนำเสนอ ตัวเลือกนี้ส่งผลต่อความพกพา, ขนาดไฟล์, การสกัดและพฤติกรรมการส่งออก ดังนั้นจึงควรตัดสินใจก่อนว่ารูปภาพจะถูกจัดเก็บอย่างไรก่อนที่จะทำการจัดรูปแบบหรือปรับแต่ง

## **เพิ่มและจัดรูปแบบรูปภาพฝังไว้**

สำหรับรูปภาพฝังไว้ ให้เพิ่มข้อมูลรูปภาพลงในงานนำเสนอและสร้าง picture frame ด้วย [ShapeCollection.addPictureFrame](https://reference.aspose.com/slides/th/python-java/aspose.slides/shapecollection/#addPictureFrame) รูปภาพจะกลายเป็นส่วนหนึ่งของแพ็กเกจงานนำเสนอ ทำให้งานนำเสนอคงอยู่ในตัวเองเมื่อนำไปย้ายไปยังคอมพิวเตอร์เครื่องอื่น

ตัวอย่างต่อไปนี้เพิ่มรูป JPEG, สร้างเฟรมที่มีขนาดตามมิติธรรมชาติของรูปภาพ, และทำการจัดรูปแบบเส้นและการหมุน:

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

Picture frame ควบคุมรูปทรงที่แสดง; การเปลี่ยนขนาดเฟรมไม่ได้เปลี่ยนมิติพิกเซลดั้งเดิมที่เก็บในแหล่งข้อมูลรูปภาพฝังไว้ ความแตกต่างนี้สำคัญเมื่อต้องทำการครอปหรือบีบอัดรูปภาพในภายหลัง

## **ใช้สเกลสัมพัทธ์**

[PictureFrame](https://reference.aspose.com/slides/th/python-java/aspose.slides/pictureframe/) เปิดเผยการสเกลความกว้างและความสูงแบบสัมพัทธ์ของเฟรมผ่าน [setRelativeScaleWidth](https://reference.aspose.com/slides/th/python-java/aspose.slides/pictureframe/#setRelativeScaleWidth) และ [setRelativeScaleHeight](https://reference.aspose.com/slides/th/python-java/aspose.slides/pictureframe/#setRelativeScaleHeight) ค่า `1.0` หมายถึง 100% ของขนาดรูปภาพต้นฉบับ สเกลสัมพัทธ์มีประโยชน์เมื่อกระบวนการทำงานต้องคงความสัมพันธ์กับขนาดรูปภาพต้นฉบับแทนการคำนวณขนาดสุดท้ายด้วยตนเอง

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

การสเกลสัมพัทธ์เปลี่ยนการตั้งค่าขนาดของเฟรม; มันไม่ได้ทำการรีซามพลิงหรือบีบอัดรูปภาพฝังไว้

## **รูปภาพฝังไว้และรูปภาพเชื่อมโยง**

รูปภาพฝังไว้เก็บข้อมูลรูปภาพภายในงานนำเสนอ ดังนั้นจึงเป็นตัวเลือกที่ปลอดภัยที่สุดสำหรับความพกพาและการแสดงผลที่คาดเดาได้ รูปภาพเชื่อมโยงจะเก็บตำแหน่งที่อยู่นอกงานนำเสนอผ่านเมธอด [Picture.setLinkPathLong](https://reference.aspose.com/slides/th/python-java/aspose.slides/picture/#setLinkPathLong) แทนการฝังข้อมูลรูปภาพในลักษณะเดียวกัน

รูปภาพเชื่อมโยงสามารถลดปริมาณข้อมูลรูปภาพที่เก็บใน PPTX ได้ แต่ก็สร้างการพึ่งพาภายนอก ไฟล์ที่เชื่อมโยงต้องสามารถเข้าถึงได้โดยแอปพลิเคชันที่เปิดหรือเรนเดอร์งานนำเสนอ หากเส้นทางเปลี่ยน, ไฟล์ถูกย้าย, หรือแหล่งข้อมูลไม่พร้อมใช้งาน รูปภาพเชื่อมโยงอาจไม่แสดงตามที่คาดหวัง สำหรับงานนำเสนอที่ต้องส่งอีเมล, เก็บเป็นไฟล์เก่า, หรือเรนเดอร์ในสภาพแวดล้อมแยก, รูปภาพฝังไว้มักจะเชื่อถือได้มากกว่า

### **เพิ่มรูปภาพเชื่อมโยง**

ตัวอย่างต่อไปนี้สร้าง picture frame และชี้ไปยังไฟล์รูปภาพภายในเครื่อง มุ่งเน้นที่การเชื่อมโยงรูปภาพเท่านั้น; การเชื่อมโยงวิดีโอเป็นกระบวนการสื่ออื่นและไม่ได้รวมไว้ในตัวอย่างนี้โดยเจตนา

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

ใช้ลิงก์เมื่อการจัดการไฟล์ภายนอกเป็นจุดประสงค์ อย่าใช้เป็นวิธีทดแทนการบีบอัด: PPTX ขนาดเล็กที่มีการพึ่งพารูปภาพหักระงับมักจะไม่มีประโยชน์เท่ากับงานนำเสนอที่มีขนาดใหญ่และเป็นอิสระ

## **สกัดรูปภาพจาก Picture Frame**

ก่อนจะสกัดรูปภาพจากงานนำเสนอที่มีอยู่, ตรวจสอบให้แน่ใจว่า shape นั้นเป็น [PictureFrame](https://reference.aspose.com/slides/th/python-java/aspose.slides/pictureframe/) จริงและว่ามันมีรูปภาพฝังไว้ Picture frame ที่เชื่อมโยงอาจไม่มีไบต์ของรูปภาพที่สามารถสกัดได้ในลักษณะเดียวกัน

### **สกัดรูปภาพ Raster**

API รูปภาพสมัยใหม่ทำงานกับรูปภาพ raster โดยตรงและไม่ต้องอาศัย wrapper ของ Java รุ่นเก่า ตัวอย่างต่อไปนี้ค้นหารูปภาพ raster ฝังแรกบนสไลด์และบันทึกเป็น PNG:

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

การบันทึกรูปภาพ raster จะเปลี่ยนรูปภาพที่สกัดเป็นรูปแบบเอาต์พุตที่ร้องขอ หากต้องการไบต์ที่เข้ารหัสเก็บอยู่ในงานนำเสนอแทนไฟล์ raster ที่แปลงแล้ว ให้ใช้ข้อมูลไบนารีของแหล่งรูปภาพแทน

### **สกัดรูปภาพ SVG**

สำหรับรูปภาพ SVG, [PPImage](https://reference.aspose.com/slides/th/python-java/aspose.slides/ppimage/) ให้บริการอ็อบเจ็กต์ [SvgImage](https://reference.aspose.com/slides/th/python-java/aspose.slides/svgimage/) ซึ่งทำให้คุณเรียกข้อมูล SVG โดยตรงแทนการเรนเดอร์รูปภาพเป็น raster ก่อน

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

การเก็บเนื้อหา SVG เป็น SVG จะรักษาแหล่งเวกเตอร์ไว้ในงานนำเสนอ การส่งออกเป็น raster เช่น PNG หรือ JPEG จะต้องเรนเดอร์เนื้อหาเวกเตอร์นั้นเป็นพิกเซล การส่งออกสไลด์เป็น PDF หรือ SVG ก็เป็นการเรนเดอร์เช่นกัน ดังนั้นกราฟิกที่ส่งออกไม่ควรถูกมองว่าเป็นสำเนาไบต์ต่อไบต์ของ SVG ฝังไว้; ใช้ข้อมูลจาก [SvgImage.getSvgData](https://reference.aspose.com/slides/th/python-java/aspose.slides/svgimage/#getSvgData) เมื่อจำเป็นต้องใช้แหล่งเวกเตอร์ต้นฉบับจริง

## **ครอปรูปภาพ**

การครอปเปลี่ยนส่วนที่มองเห็นของรูปภาพภายในเฟรม ค่า crop บน [PictureFillFormat](https://reference.aspose.com/slides/th/python-java/aspose.slides/picturefillformat/) เป็นเปอร์เซ็นต์ของมิติรูปภาพต้นฉบับ การครอปไม่ลบพิกเซลที่ซ่อนอยู่จากรูปภาพฝังไว้ในตอนแรก; มันเพียงเปลี่ยนพื้นที่ที่มองเห็น

ตัวอย่างต่อไปนี้ค้นหา picture frame อย่างปลอดภัยและใช้ค่า crop:

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

เนื่องจากข้อมูลรูปภาพที่ซ่อนอยู่ยังคงอยู่ การครอปสามารถเปลี่ยนแปลงได้ในภายหลังโดยไม่สูญเสียพิกเซลต้นฉบับ หากขนาดไฟล์มีความสำคัญกว่าความสามารถในการย้อนกลับ พื้นที่ที่ครอปแล้วสามารถลบจริงได้ตามที่อธิบายในส่วนต่อไป

## **ลบข้อมูลรูปภาพที่ครอปแล้ว**

[PictureFillFormat.deletePictureCroppedAreas](https://reference.aspose.com/slides/th/python-java/aspose.slides/picturefillformat/#deletePictureCroppedAreas) จะลบข้อมูลรูปภาพที่อยู่นอกสี่เหลี่ยมครอปปัจจุบันและคืนแหล่งรูปภาพที่ได้ ผลลัพธ์คือขนาดไฟล์ลดลง แต่เป็นการปรับแต่งทำลาย ถ้าบันทึกงานนำเสนอแล้ว พิกเซลที่ลบจะไม่มีให้ทำการยกเลิกครอปในภายหลัง

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

เมธอดนี้อาจเพิ่มแหล่งรูปภาพใหม่ลงในงานนำเสนอ หากรูปภาพต้นฉบับยังถูกใช้งานโดย picture frame อื่นๆ อยู่, เฟรมเหล่านั้นยังคงต้องการแหล่งเดิม ดังนั้นการลบพื้นที่ที่ครอปไม่ได้จำเป็นต้องลดจำนวนรูปภาพทั้งหมด การครอป WMF หรือ EMF ด้วยเมธอดนี้จะทำให้ผลลัพธ์ที่ครอปเป็น raster ไปเป็น PNG

## **บีบอัดรูปภาพ Raster**

[PictureFillFormat.compressImage](https://reference.aspose.com/slides/th/python-java/aspose.slides/picturefillformat/#compressImage) ลดความละเอียดของรูปภาพ raster ตามขนาดที่รูปภาพถูกแสดง มันยังสามารถลบพื้นที่ที่ครอปในขั้นตอนเดียวได้ เมธอดจะคืนค่า `True` เมื่อรูปภาพถูกปรับขนาดหรือครอปและคืนค่า `False` เมื่อไม่มีการเปลี่ยนแปลงใดๆ จำเป็น

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

สามารถส่งค่า DPI บวกที่กำหนดเองแทนค่าที่กำหนดไว้ล่วงหน้าเมื่อมีเป้าหมายเฉพาะต้องการ

การบีบอัดนี้ออกแบบมาสำหรับรูปภาพ raster; เนื้อหา SVG และเมตาไฟล์จะไม่ลดลงด้วยกระบวนการบีบอัด raster นี้ นอกจากนี้จำไว้ว่าความละเอียดที่ต่ำลงและพื้นที่ที่ครอปที่ถูกลบไม่สามารถกู้คืนจากงานนำเสนอที่ทำการปรับแต่งแล้ว เลือกความละเอียดเป้าหมายโดยอิงจากขนาดสูงสุดที่รูปภาพจะถูกดูหรือส่งออกจริง แทนการใช้ DPI ต่ำที่สุดทั่วทั้งไฟล์

## **จัดการเอฟเฟกต์การแปลงรูปภาพ**

สำหรับกระบวนการทำงานที่ครอบคลุมความสว่าง, ความคอนทราสต์, การแปลงสี, การเบลอ, เอฟเฟกต์อัลฟา, เชนลำดับ, การตรวจสอบ, การลบ, และการตรวจสอบรอบกลับแบบเต็มรูปแบบ, ดูที่ [Image Transform Effects](/slides/th/python-java/image-transform-effects/)

## **ล็อกเรขาคณิตของ Picture Frame**

การตั้งค่า [PictureFrameLock](https://reference.aspose.com/slides/th/python-java/aspose.slides/pictureframelock/) ควบคุมว่าการดำเนินการแก้ไขใดบ้างที่ถูกปิดใช้งานสำหรับ picture frame ตัวอย่างเช่น, [setAspectRatioLocked](https://reference.aspose.com/slides/th/python-java/aspose.slides/pictureframelock/#setAspectRatioLocked) จะคงอัตราส่วนของรูปทรงขณะปรับขนาด

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

การล็อกนี้ใช้กับ shape ของ picture frame เท่านั้น ไม่บังคับให้ภาพต้นฉบับต้องถูกรีซามพลิงหรือเปลี่ยนอัตราส่วนอย่างถาวร

## **ปรับค่า StretchOffset**

เมื่อโหมดการเติมภาพเป็น stretch, ค่าที่อยู่ใน [PictureFillFormat](https://reference.aspose.com/slides/th/python-java/aspose.slides/picturefillformat/) จะกำหนดสี่เหลี่ยมเติมสัมพันธ์กับกล่องขอบของ picture frame ค่าร้อยละบวกจะสร้างการเยื้องจากขอบ, ส่วนค่าร้อยละลบจะสร้างการขยายออก

นี่แตกต่างจากการครอป ค่า crop เลือกส่วนของภาพต้นฉบับที่มองเห็น; stretch offset จะเปลี่ยนสี่เหลี่ยมที่ภาพเติมที่มองเห็นถูกยืด

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

ใช้ stretch offset สำหรับการจัดวางการเติม ใช้คุณสมบัติ crop เมื่อเป้าหมายคือซ่อนขอบของภาพต้นฉบับ

## **การจัดเก็บ, ขนาดไฟล์, และข้อพิจารณาการส่งออก**

ข้อเท็จจริงหลักจะจัดการได้ง่ายขึ้นเมื่อการจัดเก็บรูปภาพและการจัดรูปแบบ picture frame แยกจากกัน:

- **รูปภาพฝังไว้** ทำให้งานนำเสนอเป็นอิสระและเป็นทางเลือกที่เชื่อถือได้ที่สุดสำหรับการแชร์และการเรนเดอร์บนเซิร์ฟเวอร์, แต่รูปภาพ raster ขนาดใหญ่จะเพิ่มขนาด PPTX และการใช้หน่วยความจำ
- **รูปภาพเชื่อมโยง** สามารถทำให้แพ็คเกจมีขนาดเล็กลง, แต่งานนำเสนอขึ้นอยู่กับไฟล์ภายนอกที่ต้องยังคงเข้าถึงได้ตามเส้นทางหรือที่ตั้งที่จัดเก็บไว้
- **การครอป** ในขั้นต้นไม่ทำลาย; พิกเซลที่ซ่อนอยู่ยังคงฝังอยู่จนกว่าพื้นที่ที่ครอปจะถูกลบโดยเจตนาหรือระหว่างการบีบอัด
- **การบีบอัด** สามารถลดขนาดไฟล์ได้อย่างมากสำหรับรูปภาพ raster ขนาดใหญ่, แต่จะเสียความละเอียดของแหล่งต้นฉบับ ควรทำหลังจากที่ทราบขนาดที่จะแสดงบนสไลด์แล้ว
- **รูปภาพ SVG** ควรคงเป็น SVG เมื่อต้องการรักษาเวกเตอร์ไว้. สกัด SVG ฝังโดยตรงเมื่อต้องการแหล่งเวกเตอร์เอง. การส่งออกสไลด์เป็น raster เช่น PNG หรือ JPEG จะต้องแปลงเวกเตอร์เป็นพิกเซลเสมอ
- **รูปภาพที่ใช้ซ้ำ** ควรใช้แหล่ง [PPImage](https://reference.aspose.com/slides/th/python-java/aspose.slides/ppimage/) ที่มีอยู่แล้วเมื่อเป็นไปได้ แทนการโหลดไฟล์เดียวกันหลายครั้งเข้าสู่กระบวนการทำงานของงานนำเสนอ

สำหรับงานนำเสนอขนาดใหญ่, การปรับแต่งรูปภาพมักจะได้ผลมากที่สุดเมื่อทำแบบเลือกสรร: เก็บโลโก้และไดอะแกรมเป็นเนื้อหาเวกเตอร์, บีบอัดภาพถ่ายตามขนาดการแสดงผลจริง, ลบพิกเซลที่ครอปเมื่อไม่ต้องการแก้ไขต่อในภายหลัง, และหลีกเลี่ยงลิงก์ภายนอก เว้นแต่การจัดการการพึ่งพาจะเป็นส่วนหนึ่งของการออกแบบการปรับใช้

## **คำถามที่พบบ่อย**

**ความแตกต่างระหว่าง picture frame และแหล่งข้อมูลรูปภาพคืออะไร?**

[PPImage](https://reference.aspose.com/slides/th/python-java/aspose.slides/ppimage/) แทนแหล่งข้อมูลรูปภาพที่เชื่อมกับงานนำเสนอ. [PictureFrame](https://reference.aspose.com/slides/th/python-java/aspose.slides/pictureframe/) คือรูปทรงบนสไลด์ที่แสดงรูปภาพและเก็บเรขาคณิตและการจัดรูปแบบระดับเฟรม เช่น ขนาด, การหมุน, ค่าครอป, เอฟเฟกต์, และการล็อก

**ควรฝังหรือเชื่อมโยงรูปภาพ?**

ฝังรูปภาพเมื่อจำเป็นต้องให้งานนำเสนอพกพา, เก็บเป็นไฟล์เก่า, หรือเรนเดอร์โดยไม่ต้องพึ่งพาแหล่งภายนอก. เชื่อมโยงรูปภาพเฉพาะเมื่อต้องการเก็บไฟล์รูปภาพไว้นอก PPTX อย่างตั้งใจและตำแหน่งภายนอกสามารถจัดการได้อย่างมั่นคง

**การครอปลดขนาดไฟล์ PPTX หรือไม่?**

ไม่ได้โดยตรง ตั้งค่าครอปปกติจะซ่อนส่วนของภาพต้นฉบับแต่ยังคงเก็บพิกเซลไว้ ใช้ [PictureFillFormat.deletePictureCroppedAreas](https://reference.aspose.com/slides/th/python-java/aspose.slides/picturefillformat/#deletePictureCroppedAreas) หรือการบีบอัดรูปภาพพร้อมการลบพื้นที่ที่ครอปเมื่อพิกเซลเหล่านั้นสามารถละทิ้งได้อย่างถาวร

**สามารถกู้คืนคุณภาพภาพหลังการบีบอัดได้หรือไม่?**

ไม่ได้ การบีบอัดอาจลดความละเอียด raster ที่เก็บไว้, และการลบพื้นที่ที่ครอปจะทิ้งข้อมูลภาพไป เก็บภาพต้นฉบับนอกงานนำเสนอไว้หากอาจต้องแก้ไขความละเอียดสูงในภายหลัง

**ควรจัดการรูปภาพ SVG อย่างไร?**

เก็บเนื้อหา SVG เป็น SVG เมื่อความแม่นยำของเวกเตอร์สำคัญ. สามารถสกัด [SvgImage](https://reference.aspose.com/slides/th/python-java/aspose.slides/svgimage/) ฝังโดยตรง. การเรนเดอร์สไลด์เป็นรูปแบบ raster เช่น PNG หรือ JPEG จะทำให้ SVG ถูกแปลงเป็นพิกเซล

**ทำอย่างไรจึงหลีกเลี่ยงการแคสที่ไม่ปลอดภัยเมื่ออ่านสไลด์ที่มีอยู่?**

ตรวจสอบประเภทของ shape ก่อนใช้สมาชิกเฉพาะ picture-frame การตรวจสอบ `isinstance` กับ [PictureFrame](https://reference.aspose.com/slides/th/python-java/aspose.slides/pictureframe/) จะหลีกเลี่ยงการแคสที่ไม่ถูกต้องและช่วยให้โค้ดจัดการสไลด์ที่ไม่มี picture frame ได้อย่างเหมาะสม.