---
title: จัดการเฟรมรูปภาพในงานนำเสนอด้วย Python
linktitle: เฟรมรูปภาพ
type: docs
weight: 10
url: /th/python-net/picture-frame/
keywords:
- เฟรมรูปภาพ
- เพิ่มเฟรมรูปภาพ
- สร้างเฟรมรูปภาพ
- รูปภาพฝังไว้
- รูปภาพลิงก์
- สกัดรูปภาพ
- รูปภาพแรสเตอร์
- รูปภาพ SVG
- ครอบรูปภาพ
- ลบพื้นที่ที่ครอบไว้
- บีบอัดรูปภาพ
- StretchOffset
- การจัดรูปแบบเฟรมรูปภาพ
- สเกลสัมพัทธ์
- เอฟเฟกต์รูปภาพ
- อัตราส่วนภาพ
- PowerPoint
- OpenDocument
- งานนำเสนอ
- Python
- Aspose.Slides
description: "สร้าง, จัดรูปแบบ, ลิงก์, ครอบ, สกัด, และบีบอัดเฟรมรูปภาพในงานนำเสนอด้วย Aspose.Slides สำหรับ Python ผ่าน .NET."
---
## **ภาพรวม**

Picture frame คือรูปทรงของสไลด์ที่แสดงรูปภาพ ใน Aspose.Slides, แหล่งทรัพยากรรูปภาพและรูปทรงที่แสดงมันเป็นออบเจ็กต์แยกกัน: [Presentation](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/) ครอบครองทรัพยากรรูปภาพที่ฝังอยู่ผ่าน [ImageCollection](https://reference.aspose.com/slides/th/python-net/aspose.slides/imagecollection/), ขณะที่ [PictureFrame](https://reference.aspose.com/slides/th/python-net/aspose.slides/pictureframe/) ควบคุมตำแหน่ง, ขนาด, การจัดรูปแบบเส้น, การหมุน, การครอบ, เอฟเฟกต์รูปภาพ, และการตั้งค่าระดับเฟรมอื่น ๆ

การแยกนี้มีประโยชน์เมื่อรูปเดียวกันถูกแสดงหลายครั้ง เพิ่มรูปภาพลงในงานนำเสนอเพียงครั้งเดียว, เก็บ [PPImage](https://reference.aspose.com/slides/th/python-net/aspose.slides/ppimage/) ที่คืนค่า, จากนั้นใช้ทรัพยากรรูปนั้นเมื่อตั้งค่า picture frame

Picture frame สามารถบรรจุรูปแบบ raster เช่น PNG หรือ JPEG และรูปแบบเวกเตอร์ SVG ได้ นอกจากนี้ยังสามารถอ้างอิงรูปภาพแบบลิงก์แทนการเก็บไบต์ของรูปภาพไว้ในงานนำเสนอ การเลือกนี้ส่งผลต่อความพกพา, ขนาดไฟล์, การสกัดและพฤติกรรมการส่งออก ดังนั้นจึงควรตัดสินใจว่ารูปภาพควรถูกเก็บอย่างไรก่อนทำการจัดรูปแบบหรือการเพิ่มประสิทธิภาพ

## **เพิ่มและจัดรูปแบบรูปภาพฝังไว้**

สำหรับรูปภาพที่ฝังไว้, เพิ่มข้อมูลรูปภาพลงในงานนำเสนอและสร้าง picture frame ด้วย [ShapeCollection.add_picture_frame](https://reference.aspose.com/slides/th/python-net/aspose.slides/shapecollection/add_picture_frame/). รูปภาพจะกลายเป็นส่วนหนึ่งของแพ็คเกจงานนำเสนอ, ทำให้งานนำเสนอคงเป็นอิสระเมื่อย้ายไปคอมพิวเตอร์เครื่องอื่น

ตัวอย่างต่อไปนี้เพิ่มรูป JPEG, สร้างเฟรมที่มีมิติเดิมของรูปภาพ, และใช้การจัดรูปแบบเส้นและการหมุน:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    with slides.Images.from_file("photo.jpg") as source_image:
        image = presentation.images.add_image(source_image)

    picture_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 50, 100, image.width, image.height, image)
    picture_frame.line_format.fill_format.fill_type = slides.FillType.SOLID
    picture_frame.line_format.fill_format.solid_fill_color.color = draw.Color.blue
    picture_frame.line_format.width = 3
    picture_frame.rotation = 15

    presentation.save("picture-frame.pptx", slides.export.SaveFormat.PPTX)
```

picture frame ควบคุมรูปทรงที่แสดง; การเปลี่ยนขนาดเฟรมไม่เปลี่ยนมิติพิกเซลดั้งเดิมที่เก็บไว้ในทรัพยากรรูปภาพฝังไว้ ความแตกต่างนี้สำคัญเมื่อทำการครอบหรือบีบอัดรูปภาพในภายหลัง

## **ใช้ Relative Scale**

[PictureFrame](https://reference.aspose.com/slides/th/python-net/aspose.slides/pictureframe/) เปิดเผย [relative_scale_width](https://reference.aspose.com/slides/th/python-net/aspose.slides/pictureframe/relative_scale_width/) และ [relative_scale_height](https://reference.aspose.com/slides/th/python-net/aspose.slides/pictureframe/relative_scale_height/) สำหรับเฟรม ค่า `1.0` ตรงกับ 100% ของขนาดรูปภาพต้นฉบับ Relative scale มีประโยชน์เมื่อเวิร์กโฟลว์ต้องการรักษาความสัมพันธ์กับขนาดรูปภาพต้นฉบับแทนการคำนวณมิติสุดท้ายด้วยตนเอง

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    with slides.Images.from_file("photo.jpg") as source_image:
        image = presentation.images.add_image(source_image)

    picture_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 50, 50, 100, 100, image)
    picture_frame.relative_scale_width = 1.35
    picture_frame.relative_scale_height = 0.8

    presentation.save("relative-scale.pptx", slides.export.SaveFormat.PPTX)
```

Relative scale เปลี่ยนการตั้งค่าขนาดของเฟรม; มันไม่ได้ทำการรีซัมป์หรือบีบอัดรูปภาพฝังไว้

## **รูปภาพฝังไว้และรูปภาพลิงก์**

รูปภาพฝังไว้เก็บข้อมูลรูปภาพภายในงานนำเสนอจึงเป็นตัวเลือกที่ปลอดภัยที่สุดสำหรับความพกพาและการเรนเดอร์ที่คาดการณ์ได้ รูปภาพลิงก์เก็บตำแหน่งภายนอกผ่านพาธลิงก์ [Picture](https://reference.aspose.com/slides/th/python-net/aspose.slides/picture/) แทนการฝังข้อมูลรูปภาพในลักษณะเดียวกัน

รูปภาพลิงก์สามารถลดปริมาณข้อมูลรูปภาพที่เก็บใน PPTX ได้ แต่ก็สร้างการพึ่งพาภายนอก ไฟล์ที่ลิงก์ต้องสามารถเข้าถึงได้โดยแอปพลิเคชันที่เปิดหรือเรนเดอร์งานนำเสนอ หากพาธเปลี่ยน, ไฟล์ถูกย้าย, หรือทรัพยากรไม่พร้อมใช้งาน รูปภาพลิงก์อาจไม่แสดงตามที่คาดไว้ สำหรับงานนำเสนอที่ต้องส่งอีเมล, จัดเก็บ, หรือเรนเดอร์ในสภาพแวดล้อมแยก, รูปภาพฝังไว้มักจะน่าเชื่อถือกว่า

### **เพิ่มรูปภาพลิงก์**

ตัวอย่างต่อไปนี้สร้าง picture frame และชี้ไปที่ไฟล์รูปภาพในเครื่องท้องถิ่น มุ่งเน้นเฉพาะการลิงก์รูปภาพ; การลิงก์วิดีโอเป็นเวิร์กโฟลว์สื่อแยกและไม่ได้ผสมในตัวอย่างนี้โดยเจตนา

```python
import os
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    picture_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 50, 50, 320, 180, None)
    linked_image_path = os.path.abspath("linked-image.jpg")
    picture_frame.picture_format.picture.link_path_long = linked_image_path

    presentation.save("linked-image.pptx", slides.export.SaveFormat.PPTX)
```

ใช้ลิงก์เมื่อการจัดการไฟล์ภายนอกเป็นจุดประสงค์ ไม่ใช้เป็นเพียงทางเลือกแทนการบีบอัด: PPTX เล็กที่มีการพึ่งพารูปภาพเสียหายมักจะใช้งานได้น้อยกว่าการนำเสนอที่อิสระแต่ขนาดใหญ่กว่า

## **สกัดรูปภาพจาก Picture Frame**

ก่อนสกัดรูปภาพจากงานนำเสนอที่มีอยู่, ตรวจสอบให้แน่ใจว่า shape เป็น [PictureFrame](https://reference.aspose.com/slides/th/python-net/aspose.slides/pictureframe/) และมีรูปภาพฝังอยู่ รูปภาพลิงก์อาจไม่มีไบต์ของรูปภาพที่สามารถสกัดได้ในลักษณะเดียวกัน

### **สกัดรูป Raster**

API รูปภาพสมัยใหม่ใช้ [IImage](https://reference.aspose.com/slides/th/python-net/aspose.slides/iimage/) โดยตรง ตัวอย่างต่อไปนี้ค้นหารูป raster ฝังแรกบนสไลด์และบันทึกเป็น PNG:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    for shape in slide.shapes:
        if not isinstance(shape, slides.PictureFrame):
            continue

        embedded_image = shape.picture_format.picture.image
        if embedded_image is None or embedded_image.svg_image is not None:
            continue

        raster_image = embedded_image.image
        raster_image.save("extracted-image.png", slides.ImageFormat.PNG)
        break
```

การบันทึกผ่าน [IImage](https://reference.aspose.com/slides/th/python-net/aspose.slides/iimage/) จะเปลี่ยนรูปภาพที่สกัดเป็นรูปแบบผลลัพธ์ที่ร้องขอ หากต้องการไบต์ที่เข้ารหัสเก็บไว้ในงานนำเสนอแทนไฟล์ raster ที่แปลงแล้ว ให้ใช้คุณสมบัติ [PPImage.binary_data](https://reference.aspose.com/slides/th/python-net/aspose.slides/ppimage/binary_data/) แทน

### **สกัดรูป SVG**

สำหรับรูป SVG, [PPImage](https://reference.aspose.com/slides/th/python-net/aspose.slides/ppimage/) เปิดเผยออบเจ็กต์ [SvgImage](https://reference.aspose.com/slides/th/python-net/aspose.slides/svgimage/) ซึ่งทำให้คุณดึงข้อมูล SVG โดยตรงแทนการเรนเดอร์รูปภาพเป็น raster ก่อน

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    for shape in slide.shapes:
        if not isinstance(shape, slides.PictureFrame):
            continue

        embedded_image = shape.picture_format.picture.image
        svg_image = embedded_image.svg_image if embedded_image is not None else None
        if svg_image is None:
            continue

        svg_data = bytes(svg_image.svg_data)
        with open("extracted-image.svg", "wb") as svg_stream:
            svg_stream.write(svg_data)
        break
```

การเก็บเนื้อหา SVG เป็น SVG จะรักษาแหล่งเวกเตอร์ไว้ในงานนำเสนอ การส่งออกเป็น raster เช่น PNG หรือ JPEG จะต้องเรนเดอร์เนื้อหาเวกเตอร์นั้นเป็นพิกเซล การส่งออกสไลด์เป็น PDF หรือ SVG ก็เป็นการเรนเดอร์เช่นกัน, ดังนั้นกราฟิกที่ส่งออกไม่ควรถูกมองว่าเป็นสำเนาไบต์ต่อไบต์ของ SVG ฝังเดิม; ให้ใช้ [SvgImage.svg_data](https://reference.aspose.com/slides/th/python-net/aspose.slides/svgimage/svg_data/) เมื่อจำเป็นต้องใช้แหล่งเวกเตอร์ต้นฉบับ

## **ครอบรูปภาพ**

การครอบเปลี่ยนส่วนที่มองเห็นของรูปภาพภายในเฟรม ค่า crop บน [PictureFillFormat](https://reference.aspose.com/slides/th/python-net/aspose.slides/picturefillformat/) คือเปอร์เซ็นต์ของมิติภาพต้นฉบับ การครอบไม่ได้ลบพิกเซลที่ซ่อนไว้จากรูปภาพฝังไว้; มันเพียงเปลี่ยนพื้นที่ที่มองเห็น

ตัวอย่างต่อไปนี้ค้นหา picture frame อย่างปลอดภัยและใช้ค่า crop:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    picture_frame = None

    for shape in slide.shapes:
        if isinstance(shape, slides.PictureFrame):
            picture_frame = shape
            break

    if picture_frame is not None:
        picture_frame.picture_format.crop_left = 23.6
        picture_frame.picture_format.crop_right = 21.5
        picture_frame.picture_format.crop_top = 3
        picture_frame.picture_format.crop_bottom = 31
        presentation.save("cropped-image.pptx", slides.export.SaveFormat.PPTX)
```

เนื่องจากข้อมูลภาพที่ซ่อนไว้ยังคงอยู่, สามารถเปลี่ยน crop ภายหลังได้โดยไม่เสียพิกเซลต้นฉบับ หากขนาดไฟล์สำคัญกว่าการย้อนกลับ, สามารถลบบริเวณที่ครอบไว้ตามที่อธิบายในส่วนต่อไป

## **ลบข้อมูลรูปที่ครอบไว้**

[PictureFillFormat.delete_picture_cropped_areas](https://reference.aspose.com/slides/th/python-net/aspose.slides/picturefillformat/delete_picture_cropped_areas/) จะลบข้อมูลรูปภาพที่อยู่นอกสี่เหลี่ยมครอบปัจจุบันและคืนทรัพยากรรูปภาพที่ได้ผลลัพธ์ การทำเช่นนี้สามารถลดขนาดไฟล์ได้, แต่เป็นการเพิ่มประสิทธิภาพทำลาย: หลังจากบันทึกงานนำเสนอ, พิกเซลที่ถูกลบจะไม่สามารถกู้คืนได้สำหรับการยกเลิกการครอบภายหลัง

```python
import aspose.slides as slides

with slides.Presentation("cropped-image.pptx") as presentation:
    slide = presentation.slides[0]
    picture_frame = None

    for shape in slide.shapes:
        if isinstance(shape, slides.PictureFrame):
            picture_frame = shape
            break

    if picture_frame is not None:
        cropped_image = picture_frame.picture_format.delete_picture_cropped_areas()
        if cropped_image is not None:
            presentation.save("cropped-data-removed.pptx", slides.export.SaveFormat.PPTX)
```

เมธอดอาจเพิ่มทรัพยากรรูปภาพใหม่ลงในงานนำเสนอ หากรูปภาพต้นฉบับยังถูกใช้โดย picture frame อื่น ๆ, เฟรมเหล่านั้นยังคงต้องใช้ทรัพยากรเดิม, ดังนั้นการลบพื้นที่ที่ครอบไว้ไม่ได้จำเป็นต้องลดจำนวนรูปภาพโดยรวม การครอบ WMF หรือ EMF ด้วยเมธอดนี้จะทำให้ผลลัพธ์ที่ครอบเป็น raster ไปเป็น PNG

## **บีบอ็อกตรูป Raster**

[PictureFillFormat.compress_image](https://reference.aspose.com/slides/th/python-net/aspose.slides/picturefillformat/compress_image/) ลดความละเอียดของรูป raster เทียบกับขนาดที่รูปภาพแสดง สามารถลบบริเวณที่ครอบไว้ในขั้นตอนเดียวได้ เมธอดจะคืนค่า `True` เมื่อรูปภาพถูกปรับขนาดหรือครอบและ `False` เมื่อไม่มีการเปลี่ยนแปลงใด ๆ จำเป็น

ใช้ค่า [PicturesCompression](https://reference.aspose.com/slides/th/python-net/aspose.slides.export/picturescompression/) ที่กำหนดไว้ล่วงหน้าเมื่อความละเอียดเป้าหมายมาตรฐานเพียงพอ:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    picture_frame = None

    for shape in slide.shapes:
        if isinstance(shape, slides.PictureFrame):
            picture_frame = shape
            break

    if picture_frame is not None:
        compressed = picture_frame.picture_format.compress_image(True, slides.export.PicturesCompression.DPI150)
        print("The image was compressed." if compressed else "No compression was necessary.")
        presentation.save("compressed-image.pptx", slides.export.SaveFormat.PPTX)
```

สามารถส่งค่าความละเอียด DPI เชิงบวกที่กำหนดเองแทนค่า enum เมื่อจำเป็นต้องใช้เป้าหมายเฉพาะ

การบีบอัดมุ่งเน้นที่รูป raster; เนื้อหา SVG และเมตาไฟล์จะไม่ถูกลดขนาดโดยกระบวนการบีบอัด raster นี้ อีกทั้งจำไว้ว่าความละเอียดต่ำและการลบส่วนที่ครอบไว้ไม่สามารถกู้คืนจากงานนำเสนอที่ถูกเพิ่มประสิทธิภาพได้ เลือกความละเอียดเป้าหมายตามขนาดสูงสุดที่รูปภาพจะถูกดูหรือส่งออกจริง ๆ แทนการใช้ DPI ต่ำสุดทั่วทั้งไฟล์

## **ตรวจสอบเอฟเฟกต์รูปภาพ**

เอฟเฟกต์รูปภาพถูกเก็บบนรูปที่ใช้ในเฟรม คอลเลกชันการแปลงรูปภาพสามารถมีเอฟเฟกต์เช่น AlphaModulateFixed สำหรับความโปร่งแสงและ Luminance สำหรับความสว่างและคอนทราสต์ ตัวอย่างด้านล่างจะอ่านเอฟเฟกต์ทั้งสองชนิดจาก picture frame แรกบนสไลด์อย่างปลอดภัย:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    picture_frame = None

    for shape in slide.shapes:
        if isinstance(shape, slides.PictureFrame):
            picture_frame = shape
            break

    if picture_frame is not None:
        for effect in picture_frame.picture_format.picture.image_transform:
            if isinstance(effect, slides.effects.AlphaModulateFixed):
                transparency = 100 - effect.amount
                print("Transparency: " + str(transparency))

            if isinstance(effect, slides.effects.Luminance):
                luminance = effect.get_effective()
                print("Brightness: " + str(luminance.brightness))
                print("Contrast: " + str(luminance.contrast))
```

[AlphaModulateFixed](https://reference.aspose.com/slides/th/python-net/aspose.slides.effects/alphamodulatefixed/) และ [Luminance](https://reference.aspose.com/slides/th/python-net/aspose.slides.effects/luminance/) เปลี่ยนวิธีที่รูปภาพถูกเรนเดอร์ในเฟรม; พวกมันไม่ได้เขียนทับไบต์ของรูปภาพฝังเดิม

## **ล็อกเรขาคณิตของ Picture Frame**

การตั้งค่า [PictureFrameLock](https://reference.aspose.com/slides/th/python-net/aspose.slides/pictureframelock/) ควบคุมการดำเนินการแก้ไขใดบ้างที่ถูกปิดใช้งานสำหรับ picture frame ตัวอย่างเช่น คุณสมบัติ [aspect_ratio_locked](https://reference.aspose.com/slides/th/python-net/aspose.slides/pictureframelock/aspect_ratio_locked/) จะรักษาอัตราส่วนของรูปทรงขณะปรับขนาด

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    with slides.Images.from_file("photo.jpg") as source_image:
        image = presentation.images.add_image(source_image)

    picture_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 50, 100, image.width, image.height, image)
    picture_frame.picture_frame_lock.aspect_ratio_locked = True

    presentation.save("locked-picture-frame.pptx", slides.export.SaveFormat.PPTX)
```

การล็อกนี้ใช้กับ shape ของ picture frame ไม่ได้บังคับให้รูปภาพต้นฉบับต้องรีซัมป์หรือเปลี่ยนอัตราส่วนอย่างถาวร

## **ปรับค่า StretchOffset**

เมื่อโหมดเติมรูปเป็น stretch, ค่า stretch‑offset บน [PictureFillFormat](https://reference.aspose.com/slides/th/python-net/aspose.slides/picturefillformat/) กำหนดสี่เหลี่ยมเติมสัมพันธ์กับกล่องขอบของ picture frame ค่าเปอร์เซ็นต์บวกสร้างการเยื้องจากขอบ, ส่วนค่าเปอร์เซ็นต์ลบสร้างการขยายออก

นี่ต่างจากการครอบ ค่า crop เลือกส่วนของรูปต้นฉบับที่มองเห็น; stretch offset เปลี่ยนสี่เหลี่ยมที่รูปเติมที่มองเห็นถูกยืด

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    with slides.Images.from_file("photo.png") as source_image:
        image = presentation.images.add_image(source_image)

    picture_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 10, 10, 400, 300, image)
    picture_frame.picture_format.picture_fill_mode = slides.PictureFillMode.STRETCH
    picture_frame.picture_format.stretch_offset_left = 12
    picture_frame.picture_format.stretch_offset_right = 12
    picture_frame.picture_format.stretch_offset_top = 8
    picture_frame.picture_format.stretch_offset_bottom = 8

    presentation.save("stretch-offsets.pptx", slides.export.SaveFormat.PPTX)
```

ใช้ stretch offset สำหรับการจัดตำแหน่งการเติม ใช้คุณสมบัติ crop เมื่อเป้าหมายคือการซ่อนขอบของรูปต้นฉบับ

## **การจัดเก็บ, ขนาดไฟล์, และข้อพิจารณาการส่งออก**

การตัดสินใจหลักจะจัดการได้ง่ายเมื่อการจัดเก็บรูปภาพและการจัดรูปแบบ picture‑frame แยกกัน:

- **รูปภาพฝังไว้** ทำให้งานนำเสนอเป็นอิสระและเป็นตัวเลือกที่เชื่อถือได้ที่สุดสำหรับการแชร์และการเรนเดอร์บนเซิร์ฟเวอร์, แต่รูป raster ขนาดใหญ่จะเพิ่มขนาด PPTX และการใช้หน่วยความจำ
- **รูปภาพลิงก์** สามารถทำให้แพ็คเกจเล็กลง, แต่งานนำเสนอจะพึ่งพาไฟล์ภายนอกที่ต้องคงอยู่ที่พาธหรือที่ตั้งที่บันทึกไว้
- **การครอบ** เริ่มต้นเป็นแบบไม่ทำลาย; พิกเซลที่ซ่อนไว้จะคงฝังอยู่จนกว่าจะลบบริเวณที่ครอบอย่างชัดเจนหรือระหว่างการบีบอัด
- **การบีบอัด** สามารถลดขนาดไฟล์อย่างมากสำหรับรูป raster ที่ใหญ่เกินไป, แต่จะเสียความละเอียดต้นฉบับ ควรทำหลังจากทราบขนาดที่จะแสดงบนสไลด์แล้ว
- **รูป SVG** ควรคงเป็น SVG เมื่อการคงรักษาเวกเตอร์สำคัญ; สกัด SVG ฝังโดยตรงเมื่อคุณต้องการแหล่งเวกเตอร์เอง การส่งออกสไลด์เป็น raster จะเปลี่ยนสไลด์ที่เรนเดอร์เป็นพิกเซลเสมอ
- **รูปภาพที่ใช้ซ้ำ** ควรใช้ทรัพยากร [PPImage](https://reference.aspose.com/slides/th/python-net/aspose.slides/ppimage/) เดิมเมื่อทำได้แทนการโหลดไฟล์เดียวกันหลายครั้งในเวิร์กโฟลว์ของงานนำเสนอ

สำหรับงานนำเสนอขนาดใหญ่, การเพิ่มประสิทธิภาพรูปภาพมักได้ผลดีที่สุดเมื่อทำแบบเลือกใช้: เก็บโลโก้และไดอะแกรมเป็นเนื้อหาเวกเตอร์, บีบอัดภาพถ่ายตามขนาดการแสดงจริง, ลบพิกเซลที่ครอบเฉพาะเมื่อไม่ต้องการการแก้ไขต่อ, และหลีกเลี่ยงลิงก์ภายนอกเว้นแต่การจัดการการพึ่งพาจะเป็นส่วนหนึ่งของออกแบบการนำไปใช้

## **คำถามที่พบบ่อย**

**ความแตกต่างระหว่าง picture frame และแหล่งทรัพยากรรูปภาพคืออะไร?**

[PPImage](https://reference.aspose.com/slides/th/python-net/aspose.slides/ppimage/) แทนแหล่งทรัพยากรรูปภาพที่เชื่อมโยงกับงานนำเสนอ ส่วน [PictureFrame](https://reference.aspose.com/slides/th/python-net/aspose.slides/pictureframe/) คือรูปทรงบนสไลด์ที่แสดงรูปภาพและเก็บเรขาคณิตระดับเฟรมและการจัดรูปแบบเช่น ขนาด, การหมุน, ค่า crop, เอฟเฟกต์, และล็อก

**ควรฝังหรือลิงก์รูปภาพ?**

ฝังรูปภาพเมื่อจำเป็นต้องให้งานนำเสนอพกพา, จัดเก็บ, หรือเรนเดอร์โดยไม่ต้องเข้าถึงทรัพยากรภายนอก ลิงก์รูปภาพเฉพาะเมื่อต้องการเก็บไฟล์รูปภาพอยู่นอก PPTX อย่างตั้งใจและตำแหน่งภายนอกสามารถรักษาได้อย่างเชื่อถือได้

**การครอบลดขนาดไฟล์ PPTX หรือไม่?**

ไม่โดยตรง การตั้งค่าครอบปกติจะซ่อนส่วนของรูปต้นฉบับแต่ยังคงพิกเซลอยู่ ใช้ [PictureFillFormat.delete_picture_cropped_areas](https://reference.aspose.com/slides/th/python-net/aspose.slides/picturefillformat/delete_picture_cropped_areas/) หรือการบีบอัดรูปภาพพร้อมการลบพื้นที่ที่ครอบเมื่อพิกเซลเหล่านั้นสามารถทิ้งได้อย่างถาวร

**สามารถกู้คืนคุณภาพรูปภาพหลังการบีบอัดได้หรือไม่?**

ไม่ การบีบอัดอาจลดความละเอียด raster ที่เก็บไว้, การลบบริเวณที่ครอบจะทิ้งข้อมูลรูปภาพ การเก็บรักษาต้นฉบับนอกงานนำเสนอเป็นวิธีที่ดีที่สุดหากอาจต้องการแก้ไขความละเอียดสูงในภายหลัง

**ควรจัดการรูป SVG อย่างไร?**

เก็บเนื้อหา SVG เป็น SVG เมื่อความแม่นยำของเวกเตอร์สำคัญ สามารถสกัด [SvgImage](https://reference.aspose.com/slides/th/python-net/aspose.slides/svgimage/) ฝังโดยตรง การเรนเดอร์สไลด์เป็นรูป raster เช่น PNG หรือ JPEG จะทำให้ SVG แปลงเป็นพิกเซล

**จะหลีกเลี่ยงการ cast ที่ไม่ปลอดภัยเมื่ออ่านสไลด์ที่มีอยู่ได้อย่างไร?**

ตรวจสอบประเภทของ shape ก่อนใช้สมาชิกเฉพาะ picture‑frame การใช้ `isinstance(shape, slides.PictureFrame)` จะหลีกเลี่ยงการ cast ที่ผิดพลาดและให้โค้ดจัดการกับสไลด์ที่ไม่มี picture frame ได้อย่างปลอดภัย