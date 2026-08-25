---
title: จัดการ Picture Frame ในงานนำเสนอด้วย Python
linktitle: กรอบรูปภาพ
type: docs
weight: 10
url: /th/python-net/picture-frame/
keywords:
- กรอบรูปภาพ
- เพิ่มกรอบรูปภาพ
- สร้างกรอบรูปภาพ
- ภาพที่ฝังอยู่
- ภาพที่เชื่อมโยง
- สกัดภาพ
- ภาพแรสเตอร์
- ภาพ SVG
- ครอปภาพ
- ลบพื้นที่ที่ถูกครอป
- บีบอัดภาพ
- StretchOffset
- การจัดรูปแบบกรอบรูปภาพ
- สเกลสัมพัทธ์
- เอฟเฟกต์ภาพ
- อัตราส่วนภาพ
- PowerPoint
- OpenDocument
- งานนำเสนอ
- Python
- Aspose.Slides
description: "สร้าง, จัดรูปแบบ, เชื่อมโยง, ครอป, สกัด, และบีบอัดกรอบรูปภาพในงานนำเสนอด้วย Aspose.Slides สำหรับ Python ผ่าน .NET."
---
## **ภาพรวม**

Picture frame เป็นรูปทรงของสไลด์ที่แสดงภาพ ใน Aspose.Slides, ทรัพยากรภาพและรูปทรงที่แสดงภาพเป็นอ็อบเจกต์แยกกัน: a [Presentation](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/) เป็นเจ้าของทรัพยากรภาพที่ฝังอยู่ผ่าน [ImageCollection](https://reference.aspose.com/slides/th/python-net/aspose.slides/imagecollection/) ของมัน, ในขณะที่ [PictureFrame](https://reference.aspose.com/slides/th/python-net/aspose.slides/pictureframe/) ควบคุมตำแหน่งของภาพ, ขนาด, การจัดรูปแบบเส้น, การหมุน, การครอป, เอฟเฟกต์ของรูปภาพ, และการตั้งค่าระดับเฟรมอื่น ๆ

การแยกนี้มีประโยชน์เมื่อภาพเดียวกันถูกแสดงมากกว่าหนึ่งครั้ง เพิ่มภาพลงในงานนำเสนอหนึ่งครั้ง, เก็บ [PPImage](https://reference.aspose.com/slides/th/python-net/aspose.slides/ppimage/) ที่ส่งกลับ, แล้วใช้ทรัพยากรภาพนั้นเมื่อต้องสร้าง picture frame

Picture frame สามารถบรรจุภาพแบบ raster เช่น PNG หรือ JPEG และภาพแบบ vector SVG ได้ ทั้งนี้ยังสามารถอ้างอิงภาพที่เชื่อมโยงแทนการจัดเก็บไบต์ของภาพไว้ในงานนำเสนอ ตัวเลือกนี้ส่งผลต่อความพกพา, ขนาดไฟล์, การสกัด, และพฤติกรรมการส่งออก จึงควรตัดสินใจว่าจะจัดเก็บภาพอย่างไรก่อนทำการจัดรูปแบบหรือการปรับแต่ง

## **เพิ่มและจัดรูปแบบภาพที่ฝังอยู่**

สำหรับภาพที่ฝังอยู่, เพิ่มข้อมูลภาพลงในงานนำหน้าและสร้าง picture frame ด้วย [ShapeCollection.add_picture_frame](https://reference.aspose.com/slides/th/python-net/aspose.slides/shapecollection/add_picture_frame/) ภาพจะกลายเป็นส่วนหนึ่งของแพ็คเกจงานนำเสนอ, ดังนั้นงานนำเสนอจะยังคงเป็นอิสระเมื่อย้ายไปยังคอมพิวเตอร์เครื่องอื่น

ตัวอย่างต่อไปนี้เพิ่มภาพ JPEG, สร้างเฟรมที่มีมิติเดิมของภาพ, และใช้การจัดรูปแบบเส้นและการหมุน:

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

Picture frame ควบคุมเรขาคณิตที่แสดง; การเปลี่ยนขนาดเฟรมจะไม่เปลี่ยนมิติพิกเซลต้นฉบับที่จัดเก็บในทรัพยากรภาพที่ฝังอยู่ ความแตกต่างนี้สำคัญเมื่อทำการครอปหรือบีบอัดภาพในภายหลัง

## **ใช้สเกลสัมพัทธ์**

[PictureFrame](https://reference.aspose.com/slides/th/python-net/aspose.slides/pictureframe/) เปิดให้ใช้ [relative_scale_width](https://reference.aspose.com/slides/th/python-net/aspose.slides/pictureframe/relative_scale_width/) และ [relative_scale_height](https://reference.aspose.com/slides/th/python-net/aspose.slides/pictureframe/relative_scale_height/) สำหรับเฟรม ค่า `1.0` แทน 100% ของขนาดรูปภาพดั้งเดิม สเกลสัมพัทธ์มีประโยชน์เมื่อเวิร์กโฟลว์ต้องการรักษาความสัมพันธ์กับขนาดภาพต้นฉบับแทนการคำนวณมิติสุดท้ายด้วยตนเอง

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

สเกลสัมพัทธ์เปลี่ยนการตั้งค่าสเกลของเฟรม; มันไม่ทำการรีแซมพลิงหรือบีบอัดภาพที่ฝังอยู่

## **ภาพที่ฝังอยู่และภาพที่เชื่อมโยง**

ภาพที่ฝังอยู่เก็บข้อมูลภาพภายในงานนำเสนอและจึงเป็นตัวเลือกที่ปลอดภัยที่สุดสำหรับความพกพาและการแสดงผลที่คาดเดาได้ ภาพที่เชื่อมโยงจะเก็บตำแหน่งภายนอกผ่านเส้นทางลิงก์ [Picture](https://reference.aspose.com/slides/th/python-net/aspose.slides/picture/) แทนการฝังข้อมูลภาพในลักษณะเดียวกัน

ภาพที่เชื่อมโยงสามารถลดปริมาณข้อมูลภาพที่เก็บใน PPTX ได้, แต่จะสร้างการพึ่งพาภายนอก ไฟล์ที่เชื่อมโยงต้องยังคงเข้าถึงได้สำหรับแอปพลิเคชันที่เปิดหรือเรนเดอร์งานนำเสนอ หากเส้นทางเปลี่ยน, ไฟล์ถูกย้าย, หรือทรัพยากรไม่พร้อมใช้งาน, ภาพที่เชื่อมโยงอาจไม่แสดงตามที่คาดหวัง สำหรับงานนำเสนอที่ต้องส่งอีเมล, จัดเก็บ, หรือเรนเดอร์ในสภาพแวดล้อมแยก, ภาพที่ฝังอยู่มักจะเชื่อถือได้มากกว่า

### **เพิ่มภาพที่เชื่อมโยง**

ตัวอย่างต่อไปนี้สร้าง picture frame แล้วชี้ไปยังไฟล์ภาพในเครื่อง มันจัดการเฉพาะการเชื่อมโยงภาพ; การเชื่อมโยงวิดีโอเป็นเวิร์กโฟลว์สื่อแยกต่างหากและไม่ได้รวมไว้ในตัวอย่างนี้โดยเจตนา

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

ใช้ลิงก์เมื่อการจัดการไฟล์ภายนอกเป็นสิ่งตั้งใจ. อย่าใช้เป็นเพียงการทดแทนการบีบอัด: PPTX ขนาดเล็กที่มีการพึ่งพาภาพเสียหายมักจะใช้งานได้น้อยกว่าการนำเสนอที่มีขนาดใหญ่แต่เป็นอิสระ

## **สกัดภาพจาก Picture Frame**

ก่อนสกัดภาพจากงานนำเสนอที่มีอยู่, ตรวจสอบให้แน่ใจว่ารูปทรงเป็นจริง ๆ แล้วเป็น [PictureFrame](https://reference.aspose.com/slides/th/python-net/aspose.slides/pictureframe/) และว่ามันมีภาพที่ฝังอยู่ Picture frame ที่เชื่อมโยงอาจไม่มีไบต์ของภาพที่สกัดได้ในลักษณะเดียวกัน

### **สกัดภาพ Raster**

API ภาพสมัยใหม่ใช้ [IImage](https://reference.aspose.com/slides/th/python-net/aspose.slides/iimage/) โดยตรง ตัวอย่างต่อไปนี้ค้นหาภาพ raster ที่ฝังอยู่แรกบนสไลด์และบันทึกเป็น PNG:

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

การบันทึกผ่าน [IImage](https://reference.aspose.com/slides/th/python-net/aspose.slides/iimage/) จะแปลงภาพที่สกัดเป็นรูปแบบผลลัพธ์ที่ร้องขอ หากคุณต้องการไบต์ที่เข้ารหัสที่จัดเก็บในงานนำเสนอแทนไฟล์ raster ที่แปลงแล้ว, ใช้คุณสมบัติ [PPImage.binary_data](https://reference.aspose.com/slides/th/python-net/aspose.slides/ppimage/binary_data/) แทน

### **สกัดภาพ SVG**

สำหรับภาพ SVG, [PPImage](https://reference.aspose.com/slides/th/python-net/aspose.slides/ppimage/) เปิดให้ใช้วัตถุ [SvgImage](https://reference.aspose.com/slides/th/python-net/aspose.slides/svgimage/) ซึ่งทำให้คุณดึงข้อมูล SVG โดยตรงแทนการเรสเตอร์ไลซ์ภาพก่อน

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

การเก็บเนื้อหา SVG เป็น SVG จะคงความเป็นเวกเตอร์ของแหล่งข้อมูลภายในงานนำเสนอ การส่งออกเป็น raster เช่น PNG หรือ JPEG จะต้องเรนเดอร์เนื้อหาเวกเตอร์นั้นเป็นพิกเซล การส่งออกสไลด์เป็น PDF หรือ SVG ก็เป็นการเรนเดอร์เช่นกัน, ดังนั้นกราฟิกที่ส่งออกจึงไม่ควรถูกมองว่าเป็นสำเนาไบต์ต่อไบต์ของ SVG ที่ฝังอยู่เดิม; ใช้ [SvgImage.svg_data](https://reference.aspose.com/slides/th/python-net/aspose.slides/svgimage/svg_data/) เมื่อจำเป็นต้องใช้แหล่งเวกเตอร์ต้นฉบับ

## **ครอปภาพ**

การครอปเปลี่ยนส่วนที่เห็นของภาพภายในเฟรม ค่าครอปบน [PictureFillFormat](https://reference.aspose.com/slides/th/python-net/aspose.slides/picturefillformat/) เป็นเปอร์เซ็นต์ของมิติภาพต้นฉบับ การครอปไม่ลบพิกเซลที่ซ่อนไว้จากภาพที่ฝังอยู่เริ่มต้น; มันเพียงเปลี่ยนพื้นที่ที่มองเห็น

ตัวอย่างต่อไปนี้ค้นหา picture frame อย่างปลอดภัยและนำค่าครอปไปใช้:

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

เนื่องจากข้อมูลภาพที่ซ่อนไว้ยังคงอยู่, ค่าครอปสามารถเปลี่ยนได้ในภายหลังโดยไม่สูญเสียพิกเซลต้นฉบับ หากขนาดไฟล์เป็นสิ่งสำคัญกว่าการย้อนกลับ, พื้นที่ที่ครอปแล้วสามารถลบออกทางกายภาพตามที่อธิบายในส่วนถัดไป

## **ลบข้อมูลภาพที่ถูกครอป**

[PictureFillFormat.delete_picture_cropped_areas](https://reference.aspose.com/slides/th/python-net/aspose.slides/picturefillformat/delete_picture_cropped_areas/) จะลบข้อมูลภาพที่อยู่นอกสี่เหลี่ยมครอปปัจจุบันและคืนทรัพยากรภาพที่ได้ผลลัพธ์ ซึ่งอาจลดขนาดไฟล์ได้, แต่เป็นการปรับให้เสียหาย: หลังจากบันทึกงานนำเสนอ, พิกเซลที่ลบจะไม่สามารถกู้คืนเพื่อทำการ "uncrop" ได้อีก

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

เมธอดนี้อาจเพิ่มทรัพยากรภาพใหม่ลงในงานนำเสนอ หากภาพต้นฉบับยังถูกใช้โดย picture frame อื่น ๆ, เฟรมเหล่านั้นยังคงต้องการทรัพยากรเดิม, ดังนั้นการลบพื้นที่ที่ครอปไม่ได้จำเป็นต้องลดจำนวนภาพทั้งหมด การครอป WMF หรือ EMF ด้วยเมธอดนี้จะทำให้ผลลัพธ์ที่ครอปถูกเรสเตอร์ไลซ์เป็น PNG

## **บีบอัดภาพ Raster**

[PictureFillFormat.compress_image](https://reference.aspose.com/slides/th/python-net/aspose.slides/picturefillformat/compress_image/) ลดความละเอียดของภาพ raster ตามขนาดที่ภาพแสดงอยู่ มันยังสามารถลบพื้นที่ที่ครอปได้ในการทำงานเดียวกัน เมธอดจะคืนค่า `True` เมื่อภาพถูกปรับขนาดหรือครอปและ `False` เมื่อไม่มีการเปลี่ยนแปลงใด ๆ จำเป็น

ใช้ค่าที่กำหนดไว้ล่วงหน้าใน [PicturesCompression](https://reference.aspose.com/slides/th/python-net/aspose.slides.export/picturescompression/) เมื่อความละเอียดเป้าหมายมาตรฐานเพียงพอ:

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

สามารถส่งค่าความละเอียด DPI บวกที่กำหนดเองแทนค่าที่เป็น enum ได้เมื่อจำเป็นต้องการเป้าหมายเฉพาะ

การบีบอัดออกแบบมาสำหรับภาพ raster; เนื้อหา SVG และเมตาไฟล์จะไม่ได้รับการลดโดยเวิร์กโฟลว์บีบอัด raster นี้ อีกทั้งจำไว้ว่า ความละเอียดที่ต่ำและการลบพื้นที่ที่ครอปแล้วไม่สามารถกู้คืนจากงานนำเสนอที่ปรับให้เหมาะสมนั้นได้ เลือกความละเอียดเป้าหมายตามขนาดสูงสุดที่ภาพจะถูกมองเห็นหรือส่งออกจริง แทนการใช้ DPI ต่ำสุดทั่วทั้งงาน

## **จัดการเอฟเฟกต์การแปลงภาพ**

สำหรับเวิร์กโฟลว์ครบวงจรที่ครอบคลุมความสว่าง, คอนทราสต, การแปลงสี, เบลอ, เอฟเฟกต์อัลฟ่า, เชนที่จัดลำดับ, การตรวจสอบ, การลบ, และการตรวจสอบรอบกลับ, ดูที่ [Image Transform Effects](/slides/th/python-net/image-transform-effects/)

## **ล็อกเรขาคณิตของ Picture Frame**

การตั้งค่า [PictureFrameLock](https://reference.aspose.com/slides/th/python-net/aspose.slides/pictureframelock/) ควบคุมการดำเนินการแก้ไขใดที่ถูกปิดการใช้งานสำหรับ picture frame ตัวอย่างเช่นคุณสมบัติ [aspect_ratio_locked](https://reference.aspose.com/slides/th/python-net/aspose.slides/pictureframelock/aspect_ratio_locked/) จะรักษาสัดส่วนของรูปทรงขณะปรับขนาด

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

การล็อกนี้ใช้กับรูปทรง picture frame เท่านั้น ไม่บังคับให้ภาพต้นฉบับต้องถูกรีแซมพลิงหรือเปลี่ยนเป็นสัดส่วนเดียวอย่างถาวร

## **ปรับค่า StretchOffset**

เมื่อโหมดการเติมรูปภาพเป็น stretch, ค่าที่เรียกว่า stretch‑offset บน [PictureFillFormat](https://reference.aspose.com/slides/th/python-net/aspose.slides/picturefillformat/) จะกำหนดสี่เหลี่ยมเติมสัมพันธ์กับกรอบของ picture frame เปอร์เซ็นต์บวกจะสร้างการเยื้องจากขอบ, ส่วนเปอร์เซ็นต์ลบจะขยายออกไป

นี่แตกต่างจากการครอป ค่าครอปเลือกส่วนของภาพต้นฉบับที่เห็นได้; stretch offset ปรับสี่เหลี่ยมที่ภาพเติมที่เห็นถูกยืดออก

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

ใช้ stretch offset เพื่อวางตำแหน่งการเติม ใช้คุณสมบัติการครอปเมื่อต้องการซ่อนขอบของภาพต้นฉบับ

## **การจัดเก็บ, ขนาดไฟล์, และข้อควรพิจารณาในการส่งออก**

การแลกเปลี่ยนหลักจะจัดการได้ง่ายขึ้นเมื่อการจัดเก็บภาพและการจัดรูปแบบ picture‑frame ถูกแยกออกจากกัน:

- **ภาพที่ฝังอยู่** ทำให้งานนำเสนอเป็นอิสระและเป็นตัวเลือกที่เชื่อถือได้ที่สุดสำหรับการแชร์และการเรนเดอร์ฝั่งเซิร์ฟเวอร์, แต่ภาพ raster ขนาดใหญ่จะเพิ่มขนาด PPTX และการใช้หน่วยความจำ
- **ภาพที่เชื่อมโยง** สามารถทำให้แพ็คเกจเล็กลง, แต่งานนำเสนอจะพึ่งพาไฟล์ภายนอกที่ยังคงอยู่ตามเส้นทางหรือสถานที่ที่เก็บไว้
- **การครอป** ในตอนแรกไม่ทำลาย; พิกเซลที่ซ่อนไว้ยังคงฝังอยู่จนกว่าจะลบพื้นที่ที่ครอปอย่างชัดเจนหรือถูกลบระหว่างการบีบอัด
- **การบีบอัด** สามารถลดขนาดไฟล์ได้อย่างมากสำหรับภาพ raster ที่ใหญ่เกินไป, แต่จะเสียความละเอียดต้นฉบับ ควรทำเมื่อขนาดบนสไลด์ที่ต้องการแสดงได้ถูกกำหนดแล้ว
- **ภาพ SVG** ควรคงเป็น SVG เมื่อการรักษาเวกเตอร์สำคัญ; สกัด SVG ที่ฝังอยู่โดยตรงเมื่อคุณต้องการแหล่งเวกเตอร์เอง การส่งออกสไลด์เป็น raster จะเปลี่ยนสไลด์ที่เรนเดอร์ให้เป็นพิกเซลเสมอ
- **ภาพที่ใช้ซ้ำ** ควรใช้ทรัพยากร [PPImage](https://reference.aspose.com/slides/th/python-net/aspose.slides/ppimage/) ที่มีอยู่แล้วเมื่อเป็นไปได้ แทนการโหลดไฟล์เดียวกันซ้ำ ๆ เข้าเวิร์กโฟลว์ของงานนำเสนอ

สำหรับงานนำเสนอขนาดใหญ่, การปรับภาพให้เหมาะสมมักจะได้ผลดีที่สุดเมื่อทำแบบเลือกตามส่วน: เก็บโลโก้และไดอะแกรมเป็นเนื้อหาเวกเตอร์, บีบอัดภาพถ่ายตามขนาดการแสดงจริง, ลบพิกเซลที่ครอปเฉพาะเมื่อไม่ต้องการการแก้ไขต่อ, และหลีกเลี่ยงลิงก์ภายนอกเว้นแต่การจัดการการพึ่งพาจะเป็นส่วนหนึ่งของการออกแบบการปรับใช้

## **FAQ**

**ความแตกต่างระหว่าง picture frame และทรัพยากรภาพคืออะไร?**

[PPImage](https://reference.aspose.com/slides/th/python-net/aspose.slides/ppimage/) แทนทรัพยากรภาพที่เชื่อมโยงกับงานนำเสนอ ส่วน [PictureFrame](https://reference.aspose.com/slides/th/python-net/aspose.slides/pictureframe/) คือรูปทรงบนสไลด์ที่แสดงภาพและเก็บเรขาคณิตและการจัดรูปแบบระดับเฟรม เช่น ขนาด, การหมุน, ค่าครอป, เอฟเฟกต์, และการล็อก

**ควรฝังภาพหรือเชื่อมโยงภาพ?**

ฝังภาพเมื่อโครงการต้องการความพกพา, การเก็บรักษา, หรือการเรนเดอร์โดยไม่ต้องอ้างอิงทรัพยากรภายนอก เชื่อมโยงภาพเฉพาะเมื่อต้องการเก็บไฟล์ภาพนอก PPTX อย่างตั้งใจและตำแหน่งภายนอกสามารถจัดการได้อย่างเชื่อถือได้

**การครอปลดขนาดไฟล์ PPTX หรือไม่?**

ไม่โดยตนเอง การตั้งค่าครอปปกติจะซ่อนส่วนของภาพต้นฉบับแต่ยังคงพิกเซลพื้นฐานไว้ ใช้ [PictureFillFormat.delete_picture_cropped_areas](https://reference.aspose.com/slides/th/python-net/aspose.slides/picturefillformat/delete_picture_cropped_areas/) หรือการบีบอัดภาพพร้อมการลบพื้นที่ที่ครอปเมื่อพิกเซลเหล่านั้นสามารถกำจัดได้อย่างถาวร

**ฉันสามารถกู้คืนคุณภาพภาพหลังการบีบอัดได้หรือไม่?**

ไม่ได้ การบีบอัดอาจลดความละเอียด raster ที่เก็บไว้, และการลบพื้นที่ที่ครอปจะทำให้ข้อมูลภาพหายไป เก็บภาพต้นฉบับไว้ภายนอกงานนำเสนอหากอาจต้องการแก้ไขความละเอียดสูงในภายหลัง

**ควรจัดการภาพ SVG อย่างไร?**

เก็บเนื้อหา SVG เป็น SVG เมื่อความแม่นยำของเวกเตอร์สำคัญ; สามารถสกัด [SvgImage](https://reference.aspose.com/slides/th/python-net/aspose.slides/svgimage/) ที่ฝังอยู่โดยตรง การเรนเดอร์สไลด์เป็นรูปแบบ raster เช่น PNG หรือ JPEG จะทำให้ SVG ถูกแปลงเป็นพิกเซล

**จะหลีกเลี่ยงการ cast ที่ไม่ปลอดภัยเมื่ออ่านสไลด์ที่มีอยู่ได้อย่างไร?**

ตรวจสอบชนิดของรูปทรงก่อนใช้สมาชิกเฉพาะ picture‑frame การใช้ `isinstance(shape, slides.PictureFrame)` จะหลีกเลี่ยงการ cast ที่ไม่ถูกต้องและทำให้โค้ดจัดการกับสไลด์ที่ไม่มี picture frame ได้อย่างปลอดภัย