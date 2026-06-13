---
title: เพิ่ม Picture Frame ลงในงานนำเสนอด้วย Python
linktitle: กรอบรูป
type: docs
weight: 10
url: /th/python-net/picture-frame/
keywords:
- กรอบรูป
- เพิ่มกรอบรูป
- สร้างกรอบรูป
- เพิ่มรูปภาพ
- สร้างรูปภาพ
- ดึงรูปภาพ
- รูปภาพราสเตอร์
- รูปภาพเวกเตอร์
- ครอบรูปภาพ
- พื้นที่ที่ถูกครอบ
- คุณสมบัติ StretchOff
- การจัดรูปแบบกรอบรูป
- คุณสมบัติกรอบรูป
- สเกลสัมพันธ์
- เอฟเฟกต์ของรูปภาพ
- อัตราส่วน
- ความโปร่งใสของรูปภาพ
- PowerPoint
- OpenDocument
- งานนำเสนอ
- Python
- Aspose.Slides
description: "เพิ่มกรอบรูปลงในงานนำเสนอ PowerPoint และ OpenDocument ด้วย Aspose.Slides สำหรับ Python via .NET ทำให้การทำงานของคุณรวดเร็วขึ้นและปรับปรุงการออกแบบสไลด์"
---
## **บทนำ**

Picture frames ใน Aspose.Slides for Python ช่วยให้คุณสามารถวางและจัดการภาพแบบราสเตอร์และเวกเตอร์เป็นรูปทรงสไลด์แบบเนทีฟได้ คุณสามารถแทรกรูปจากไฟล์หรือสตรีม, กำหนดตำแหน่งและขนาดด้วยพิกัดที่แม่นยำ, ใช้การหมุน, ตั้งค่าความโปร่งใส, และควบคุมลำดับ Z พร้อมกับรูปทรงอื่น ๆ API ยังรองรับการครอบ, รักษาอัตราส่วน, ตั้งขอบและเอฟเฟกต์, รวมถึงการแทนที่ภาพพื้นฐานโดยไม่ต้องสร้างเลเอาต์ใหม่ เนื่องจาก picture frames ทำงานเหมือนรูปทรงทั่วไป คุณจึงสามารถเพิ่มแอนิเมชัน, ไฮเปอร์ลิงก์, และข้อความแทน (alt text) ทำให้การสร้างงานนำเสนอที่มีภาพสวยงามและเข้าถึงได้ง่ายเป็นเรื่องง่าย

## **สร้าง Picture Frames**

ส่วนนี้จะแสดงวิธีแทรกภาพลงในสไลด์โดยสร้าง [PictureFrame](https://reference.aspose.com/slides/th/python-net/aspose.slides/pictureframe/) ด้วย Aspose.Slides for Python คุณจะได้เรียนรู้วิธีโหลดภาพ, วางตำแหน่งอย่างแม่นยำบนสไลด์, และควบคุมขนาดและการจัดรูปแบบของมัน

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/)  
2. รับสไลด์ตามดัชนีของมัน  
3. สร้าง [PPImage](https://reference.aspose.com/slides/th/python-net/aspose.slides/ppimage/) โดยเพิ่มภาพลงใน [ImageCollection](https://reference.aspose.com/slides/th/python-net/aspose.slides/imagecollection/) ของการนำเสนอ ภาพนี้จะใช้เพื่อเติมรูปทรง  
4. ระบุความกว้างและความสูงของเฟรม  
5. สร้าง [PictureFrame](https://reference.aspose.com/slides/th/python-net/aspose.slides/pictureframe/) ด้วยขนาดนั้นโดยใช้เมธอด [add_picture_frame](https://reference.aspose.com/slides/th/python-net/aspose.slides/shapecollection/add_picture_frame/)  
6. บันทึกการนำเสนอเป็นไฟล์ PPTX  

โค้ด Python ด้านล่างแสดงวิธีสร้าง picture frame:

```py
import aspose.slides as slides

# สร้างอินสแตนซ์ของคลาส Presentation เพื่อแทนไฟล์ PPTX.
with slides.Presentation() as presentation:
    # ดึงสไลด์แรก.
    slide = presentation.slides[0]

    # เพิ่มรูปภาพลงในงานนำเสนอ.
    with open("image.jpeg", "rb") as image_stream:
        image = presentation.images.add_image(image_stream)

        # เพิ่ม picture frame ที่มีขนาดเท่ากับรูปภาพ.
        picture_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 50, 50, image.width, image.height, image)

        # บันทึกงานนำเสนอเป็นไฟล์ PPTX.
        presentation.save("picture_frame.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert color="warning" %}}
Picture frames ช่วยให้คุณสร้างสไลด์นำเสนอจากภาพได้อย่างรวดเร็ว เมื่อผสาน picture frames กับตัวเลือกการบันทึกของ Aspose.Slides คุณสามารถควบคุมการทำงาน I/O เพื่อแปลงภาพจากรูปแบบหนึ่งเป็นอีกรูปแบบหนึ่ง คุณอาจต้องการดูหน้าเหล่านี้: แปลง [image to JPG](https://products.aspose.com/slides/th/python-net/conversion/image-to-jpg/); แปลง [JPG to image](https://products.aspose.com/slides/th/python-net/conversion/jpg-to-image/); แปลง [JPG to PNG](https://products.aspose.com/slides/th/python-net/conversion/jpg-to-png/); แปลง [PNG to JPG](https://products.aspose.com/slides/th/python-net/conversion/png-to-jpg/); แปลง [PNG to SVG](https://products.aspose.com/slides/th/python-net/conversion/png-to-svg/); แปลง [SVG to PNG](https://products.aspose.com/slides/th/python-net/conversion/svg-to-png/)  
{{% /alert %}}

## **สร้าง Picture Frames ด้วยการสเกลตามสัดส่วน**

ส่วนนี้จะแสดงการวางภาพที่ขนาดคงที่แล้วใช้การสเกลแบบเปอร์เซ็นต์แยกตามความกว้างและความสูง เนื่องจากเปอร์เซ็นต์อาจแตกต่างกัน อัตราส่วนภาพอาจเปลี่ยนแปลง การสเกลจะอ้างอิงจากมิติเดิมของภาพ

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/)  
2. รับสไลด์ตามดัชนีของมัน  
3. สร้าง [PPImage](https://reference.aspose.com/slides/th/python-net/aspose.slides/ppimage/) โดยเพิ่มภาพลงใน [ImageCollection](https://reference.aspose.com/slides/th/python-net/aspose.slides/imagecollection/)  
4. เพิ่ม [PictureFrame](https://reference.aspose.com/slides/th/python-net/aspose.slides/pictureframe/) ลงในสไลด์  
5. ตั้งค่าความกว้างและความสูงแบบสัมพันธ์ของ picture frame  
6. บันทึกการนำเสนอเป็นไฟล์ PPTX  

โค้ด Python ด้านล่างแสดงวิธีสร้าง picture frame ด้วยการสเกลแบบสัมพันธ์:

```py
import aspose.slides as slides

# สร้างอินสแตนซ์ของคลาส Presentation เพื่อแทนไฟล์ PPTX.
with slides.Presentation() as presentation:
    # ดึงสไลด์แรก.
    slide = presentation.slides[0]

    # เพิ่มรูปภาพลงในคอลเลกชันภาพของงานนำเสนอ.
    with open("image.jpeg", "rb") as image_stream:
        image = presentation.images.add_image(image_stream)

        # เพิ่ม picture frame ลงในสไลด์.
        picture_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 50, 50, 100, 100, image)

        # ตั้งค่าความกว้างและความสูงของสเกลสัมพันธ์.
        picture_frame.relative_scale_height = 0.8
        picture_frame.relative_scale_width = 1.35

        # บันทึกงานนำเสนอ.
        presentation.save("relative_scaling.pptx", slides.export.SaveFormat.PPTX)
```

## **ดึงภาพ Raster จาก Picture Frames**

คุณสามารถดึงภาพ raster จากออบเจ็กต์ [PictureFrame](https://reference.aspose.com/slides/th/python-net/aspose.slides/pictureframe/) และบันทึกเป็น PNG, JPG หรือรูปแบบอื่น ตัวอย่างโค้ดด้านล่างแสดงวิธีดึงภาพจากเอกสาร “sample.pptx” แล้วบันทึกเป็น PNG

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    first_slide = presentation.slides[0]
    first_shape = first_slide.shapes[0]

    if isinstance(first_shape, slides.PictureFrame):
        image = first_shape.picture_format.picture.image.image
        image.save("slide_1_shape_1.png", slides.ImageFormat.PNG)
```

## **ดึงภาพ SVG จาก Picture Frames**

เมื่อการนำเสนอมีกราฟิก SVG ที่วางอยู่ภายในรูปทรง [PictureFrame](https://reference.aspose.com/slides/th/python-net/aspose.slides/pictureframe/) Aspose.Slides for Python via .NET จะให้คุณดึงภาพเวกเตอร์ดั้งเดิมพร้อมความแม่นยำเต็มรูปแบบ โดยการเดินทางผ่านคอล렉ชันของรูปทรงในสไลด์ คุณสามารถระบุแต่ละ [PictureFrame](https://reference.aspose.com/slides/th/python-net/aspose.slides/pictureframe/), ตรวจสอบว่า [PPImage](https://reference.aspose.com/slides/th/python-net/aspose.slides/ppimage/) พื้นฐานมีเนื้อหา SVG หรือไม่, แล้วบันทึกภาพนั้นลงดิสก์หรือสตรีมในรูปแบบ SVG ดั้งเดิม

โค้ดตัวอย่างต่อไปนี้แสดงวิธีดึงภาพ SVG จาก picture frame:

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]

    if isinstance(shape, slides.PictureFrame):
        svg_image = shape.picture_format.picture.image.svg_image

        if svg_image is not None:
            with open("output.svg", "w", encoding="utf-8") as svg_stream:
                svg_stream.write(svg_image.svg_content)
```

## **รับค่า Transparency ของภาพ**

Aspose.Slides ให้คุณดึงเอฟเฟกต์การโปร่งใสที่ใช้กับภาพ โค้ด Python ด้านล่างแสดงการทำงานนี้:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    picture_frame = presentation.slides[0].shapes[0]
    image_transform = picture_frame.picture_format.picture.image_transform
    for effect in image_transform:
        if isinstance(effect, slides.effects.AlphaModulateFixed):
            transparency_value = 100 - effect.amount
            print("Picture transparency: " + str(transparency_value))
```

{{% alert color="primary" %}}
เอฟเฟกต์ทั้งหมดที่ใช้กับภาพสามารถพบได้ใน [aspose.slides.effects](https://reference.aspose.com/slides/th/python-net/aspose.slides.effects/)  
{{% /alert %}}

## **การจัดรูปแบบ Picture Frame**

Aspose.Slides มีตัวเลือกการจัดรูปแบบหลายอย่างที่คุณสามารถใช้กับ picture frame ด้วยตัวเลือกเหล่านี้ คุณสามารถปรับ picture frame ให้ตรงตามความต้องการเฉพาะ

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/)  
2. รับสไลด์ตามดัชนีของมัน  
3. สร้าง [PPImage](https://reference.aspose.com/slides/th/python-net/aspose.slides/ppimage/) โดยเพิ่มภาพลงใน [ImageCollection](https://reference.aspose.com/slides/th/python-net/aspose.slides/imagecollection/) ของการนำเสนอ ภาพนี้จะใช้เพื่อเติมรูปทรง  
4. ระบุความกว้างและความสูงของเฟรม  
5. สร้าง [PictureFrame](https://reference.aspose.com/slides/th/python-net/aspose.slides/pictureframe/) ด้วยขนาดนั้นโดยใช้เมธอด [add_picture_frame](https://reference.aspose.com/slides/th/python-net/aspose.slides/shapecollection/add_picture_frame/) ของสไลด์  
6. ตั้งค่าสีเส้นของ picture frame  
7. ตั้งค่าความกว้างเส้นของ picture frame  
8. หมุน picture frame ด้วยค่าบวก (ตามเข็มนาฬิกา) หรือค่าลบ (ทวนเข็มนาฬิกา)  
9. บันทึกการนำเสนอที่แก้ไขแล้วเป็นไฟล์ PPTX  

โค้ด Python ด้านล่างแสดงกระบวนการจัดรูปแบบ picture frame:

```py
import aspose.slides as slides
import aspose.pydrawing as draw

# สร้างอินสแตนซ์ของคลาส Presentation เพื่อแทนไฟล์ PPTX.
with slides.Presentation() as presentation:
    # ดึงสไลด์แรก.
    slide = presentation.slides[0]

    # เพิ่มรูปภาพลงในคอลเลกชันภาพของงานนำเสนอ.
    with open("image.jpeg", "rb") as image_stream:
        image = presentation.images.add_image(image_stream)

        # เพิ่ม picture frame ที่มีขนาดเท่ากับรูปภาพ.
        picture_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 50, 50, image.width, image.height, image)

        # ใช้การจัดรูปแบบกับ picture frame.
        picture_frame.line_format.fill_format.fill_type = slides.FillType.SOLID
        picture_frame.line_format.fill_format.solid_fill_color.color = draw.Color.blue
        picture_frame.line_format.width = 20
        picture_frame.rotation = 45

    # บันทึกงานนำเสนอเป็นไฟล์ PPTX.
    presentation.save("picture_formatting.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert title="Tip" color="primary" %}}
Aspose มี **Collage Maker** ฟรีที่ <https://products.aspose.app/slides/th/collage> หากคุณต้องการ [merge JPG/JPEG](https://products.aspose.app/slides/th/collage/jpg) หรือ PNG, หรือ [create photo grids](https://products.aspose.app/slides/th/collage/photo-grid) คุณสามารถใช้บริการนี้ได้  
{{% /alert %}}

## **เพิ่มรูปภาพเป็นลิงก์**

เพื่อให้ไฟล์การนำเสนอมีขนาดเล็ก คุณสามารถเพิ่มรูปภาพหรือวิดีโอผ่านลิงก์แทนการฝังไฟล์โดยตรงในงานนำเสนอ โค้ด Python ด้านล่างแสดงวิธีแทรกรูปภาพและวิดีโอลงใน placeholder:

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    slide = presentation.slides[0]

    shapes_to_remove = []

    for shape in slide.shapes:
        if shape.placeholder is None:
            continue

        if shape.placeholder.type == slides.PlaceholderType.PICTURE:
            picture_frame = slide.shapes.add_picture_frame(
                slides.ShapeType.RECTANGLE, shape.x, shape.y, shape.width, shape.height, None)

            picture_frame.picture_format.picture.link_path_long = \
                "https://upload.wikimedia.org/wikipedia/commons/3/3a/I.M_at_Old_School_Public_Broadcasting_in_October_2016_02.jpg"

            shapes_to_remove.append(shape)

        elif shape.placeholder.type == slides.PlaceholderType.MEDIA:
            video_frame = slide.shapes.add_video_frame(shape.X, shape.Y, shape.width, shape.height, "")

            video_frame.picture_format.picture.link_path_long = \
                "https://upload.wikimedia.org/wikipedia/commons/3/3a/I.M_at_Old_School_Public_Broadcasting_in_October_2016_02.jpg"

            video_frame.link_path_long = "https://youtu.be/t_1LYZ102RA"
            shapes_to_remove.append(shape)

    for shape in shapes_to_remove:
        slide.shapes.remove(shape)

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **ครอบภาพ**

ในส่วนนี้คุณจะได้เรียนรู้วิธีครอบพื้นที่ที่มองเห็นของภาพภายใน picture frame โดยไม่ต้องแก้ไขไฟล์ต้นฉบับ นอกจากนี้ยังจะแสดงวิธีพื้นฐานในการกำหนดขอบครอบเพื่อสร้างองค์ประกอบที่สะอาดและเน้นจุดสำคัญโดยตรงบนสไลด์

โค้ด Python ด้านล่างแสดงวิธีครอบภาพบนสไลด์:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # เพิ่มรูปภาพลงในคอลเลกชันภาพของงานนำเสนอ.
    with slides.Images.from_file("image.png") as source_image:
        image = presentation.images.add_image(source_image)

    # เพิ่ม picture frame ลงในสไลด์.
    picture_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 100, 100, 420, 250, image)

    # ครอบรูปภาพ (ค่าเป็นเปอร์เซ็นต์).
    picture_frame.picture_format.crop_left = 23.6
    picture_frame.picture_format.crop_right = 21.5
    picture_frame.picture_format.crop_top = 3
    picture_frame.picture_format.crop_bottom = 31

    # บันทึกผลลัพธ์.
    presentation.save("cropped_image.pptx", slides.export.SaveFormat.PPTX)
```

## **ลบพื้นที่ที่ถูกครอบของภาพ**

หากต้องการลบพื้นที่ที่ถูกครอบของภาพในเฟรม ให้ใช้เมธอด [delete_picture_cropped_areas](https://reference.aspose.com/slides/th/python-net/aspose.slides/picturefillformat/delete_picture_cropped_areas/) เมธอดนี้จะคืนภาพที่ถูกครอบ, หรือภาพเดิมถ้าไม่มีการครอบ

โค้ด Python ด้านล่างแสดงการทำงานนี้:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    # ดึง PictureFrame จากสไลด์แรก.
    picture_frame = slides.shape[0]

    # ดึง PictureFrame จากสไลด์แรก.
    cropped_image = picture_frame.picture_format.delete_picture_cropped_areas()

    # บันทึกผลลัพธ์.
    presentation.save("deleted_cropped_areas.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert title="NOTE" color="warning" %}}
เมธอด [delete_picture_cropped_areas](https://reference.aspose.com/slides/th/python-net/aspose.slides/picturefillformat/delete_picture_cropped_areas/) จะเพิ่มภาพที่ถูกครอบลงในคอลเลกชันภาพของการนำเสนอ หากภาพนั้นใช้เฉพาะใน [PictureFrame](https://reference.aspose.com/slides/th/python-net/aspose.slides/pictureframe/) ที่ประมวลผลแล้ว จะช่วยลดขนาดของงานนำเสนอ; หากไม่เช่นนั้น จำนวนภาพในงานนำเสนอที่ได้อาจเพิ่มขึ้น  

ในระหว่างการครอบ เมธอดนี้จะแปลงไฟล์เมตาฟายล์ WMF/EMF เป็นภาพ PNG แบบราสเตอร์  
{{% /alert %}}

## **บีบอัดภาพ**

คุณสามารถบีบอัดรูปภาพในงานนำเสนอด้วยเมธอด [PictureFillFormat.compress_image](https://reference.aspose.com/slides/th/python-net/aspose.slides/picturefillformat/compress_image/)  
เมธอดนี้บีบอัดภาพโดยลดขนาดตามขนาดของรูปทรงและความละเอียดที่ระบุ, พร้อมตัวเลือกให้ลบพื้นที่ที่ถูกครอบ

มันปรับขนาดและความละเอียดของภาพคล้ายกับฟีเจอร์ **Picture Format → Compress Pictures → Resolution** ของ PowerPoint

โค้ด Python ต่อไปนี้แสดงวิธีบีบอัดภาพในงานนำเสนอโดยระบุความละเอียดเป้าหมายและอาจลบพื้นที่ที่ถูกครอบ:

```python
import aspose.slides as slides

with slides.Presentation("demo.pptx") as presentation:
    slide = presentation.slides[0]
    picture_frame = slide.shapes[0]

    # บีบอัดภาพด้วยความละเอียดเป้าหมาย 150 DPI (ความละเอียดเว็บ) และลบพื้นที่ที่ถูกครอบ
    result = picture_frame.picture_format.compress_image(True, slides.export.PicturesCompression.DPI150)

    # ตรวจสอบผลของการบีบอัด
    if result:
        print("Image successfully compressed.")
    else:
        print("Image compression failed or no changes were necessary.")

    presentation.save("compressed_image.pptx", slides.export.SaveFormat.PPTX)
```

หรือใช้ค่า DPI ที่กำหนดเองโดยตรง:

```python
import aspose.slides as slides

with slides.Presentation("demo.pptx") as presentation:
    slide = presentation.slides[0]
    picture_frame = slide.shapes[0]

    # บีบอัดภาพเป็น 150 DPI (ความละเอียดเว็บ) และลบพื้นที่ที่ถูกครอบ
    picture_frame.picture_format.compress_image(True, 150)

    presentation.save("compressed_image.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert title="NOTE" color="warning" %}}
เมธอดจะเปลี่ยนภาพเป็นความละเอียดต่ำกว่าโดยอิงจากขนาดของรูปทรงและ DPI ที่ให้ไว้ พื้นที่ที่ถูกครอบก็สามารถลบได้เพื่อเพิ่มประสิทธิภาพขนาดไฟล์  
หากภาพเป็นเมตาฟายล์ (WMF/EMF) หรือ SVG จะไม่ทำการบีบอัด นอกจากนี้คุณภาพ JPEG จะถูกรักษาหรืออาจลดลงเล็กน้อยตามความละเอียดเช่นเดียวกับที่ PowerPoint จัดการ JPEG ความละเอียดสูง  
{{% /alert %}}

## **ล็อคอัตราส่วน**

หากต้องการให้รูปทรงที่บรรจุภาพคงอัตราส่วนหลังจากคุณเปลี่ยนขนาดของภาพ ให้ตั้งค่า [aspect_ratio_locked](https://reference.aspose.com/slides/th/python-net/aspose.slides/pictureframelock/aspect_ratio_locked/) เป็น `True`

โค้ด Python ด้านล่างแสดงวิธีล็อคอัตราส่วนของรูปทรง:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    layout = presentation.layout_slides.get_by_type(slides.SlideLayoutType.CUSTOM)
    empty_slide = presentation.slides.add_empty_slide(layout)

    with slides.Images.from_file("image.png") as source_image:
        image = presentation.images.add_image(source_image)

    picture_frame = empty_slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 50, 50, image.width, image.height, image)

    # ล็อคอัตราส่วนเมื่อทำการปรับขนาด.
    picture_frame.picture_frame_lock.aspect_ratio_locked = True

    presentation.save("aspect_ratio_locked.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert title="NOTE" color="warning" %}}
การตั้งค่า *Lock Aspect Ratio* นี้จะรักษาเพียงอัตราส่วนของรูปทรง, ไม่ใช่อัตราส่วนของภาพภายในรูปทรงนั้น  
{{% /alert %}}

## **ใช้คุณสมบัติ Stretch Offset**

โดยใช้คุณสมบัติ `stretch_offset_left`, `stretch_offset_top`, `stretch_offset_right`, และ `stretch_offset_bottom` ของคลาส [PictureFillFormat](https://reference.aspose.com/slides/th/python-net/aspose.slides/picturefillformat/) คุณสามารถกำหนดสี่เหลี่ยมเติม

เมื่อกำหนดการยืดสำหรับภาพ, สี่เหลี่ยมต้นฉบับจะถูกสเกลเพื่อให้พอดีกับสี่เหลี่ยมเติม แต่ละด้านของสี่เหลี่ยมเติมจะกำหนดโดยออฟเซ็ตเปอร์เซ็นต์จากขอบที่สอดคล้องของกล่องขอบเขตของรูปทรง ค่าบวกหมายถึงการย่อเข้ามา, ค่าลบหมายถึงการขยายออก

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/)  
2. รับอ้างอิงสไลด์ตามดัชนีของมัน  
3. เพิ่ม [AutoShape](https://reference.aspose.com/slides/th/python-net/aspose.slides/autoshape/) แบบสี่เหลี่ยม  
4. ตั้งค่าชนิดการเติมของรูปทรง  
5. ตั้งค่าโหมดการเติมภาพของรูปทรง  
6. โหลดภาพ  
7. กำหนดภาพเพื่อเติมรูปทรง  
8. ระบุออฟเซ็ตของภาพจากขอบที่สอดคล้องของกล่องขอบเขตของรูปทรง  
9. บันทึกการนำเสนอเป็นไฟล์ PPTX  

โค้ด Python ด้านล่างแสดงวิธีใช้คุณสมบัติ Stretch Offset:

```py
import aspose.slides as slides

# สร้างอินสแตนซ์ของคลาส Presentation ที่แทนไฟล์ PPTX.
with slides.Presentation() as presentation:
    # ดึงสไลด์แรก.
    slide = presentation.slides[0]

    # เพิ่ม AutoShape รูปร่างสี่เหลี่ยม.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 300, 300)

    # ตั้งค่าชนิดการเติมของรูปทรง.
    shape.fill_format.fill_type = slides.FillType.PICTURE

    # ตั้งค่าโหมดการเติมภาพของรูปทรง.
    shape.fill_format.picture_fill_format.picture_fill_mode = slides.PictureFillMode.STRETCH

    # โหลดภาพและเพิ่มลงในงานนำเสนอ.
    with open("image.jpeg", "rb") as image_stream:
        image = presentation.images.add_image(image_stream)

    # กำหนดภาพเพื่อเติมรูปทรง.
    shape.fill_format.picture_fill_format.picture.image = image

    # ระบุออฟเซ็ตของภาพจากขอบที่สอดคล้องของกล่องขอบเขตของรูปทรง.
    shape.fill_format.picture_fill_format.stretch_offset_left = 25
    shape.fill_format.picture_fill_format.stretch_offset_right = 25
    shape.fill_format.picture_fill_format.stretch_offset_top = -20
    shape.fill_format.picture_fill_format.stretch_offset_bottom = -10

    # บันทึกไฟล์ PPTX ลงดิสก์.
    presentation.save("stretch_offset.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert title="Tip" color="primary" %}}
Aspose มีเครื่องมือแปลงไฟล์ฟรี — [JPEG to PowerPoint](https://products.aspose.app/slides/th/import/jpg-to-ppt) และ [PNG to PowerPoint](https://products.aspose.app/slides/th/import/png-to-ppt) — ที่ช่วยให้คุณสร้างงานนำเสนอจากภาพอย่างรวดเร็ว  
{{% /alert %}}

## **FAQ**

**ฉันจะตรวจสอบได้ว่า PictureFrame รองรับรูปแบบภาพใดบ้าง?**  
Aspose.Slides รองรับภาพราสเตอร์ (PNG, JPEG, BMP, GIF ฯลฯ) และภาพเวกเตอร์ (เช่น SVG) ผ่านออบเจ็กต์ภาพที่กำหนดให้กับ [PictureFrame](https://reference.aspose.com/slides/th/python-net/aspose.slides/pictureframe/) รายการรูปแบบที่รองรับมักจะตรงกับความสามารถของเครื่องมือแปลงสไลด์และภาพ

**การเพิ่มภาพขนาดใหญ่หลายสิบไฟล์จะส่งผลต่อขนาดและประสิทธิภาพของ PPTX อย่างไร?**  
การฝังภาพขนาดใหญ่จะเพิ่มขนาดไฟล์และการใช้หน่วยความจำ; การลิงก์ภาพช่วยลดขนาดงานนำเสนอแต่ต้องให้ไฟล์ภายนอกยังคงเข้าถึงได้ Aspose.Slides มีความสามารถในการเพิ่มภาพแบบลิงก์เพื่อช่วยลดขนาดไฟล์

**ฉันจะล็อคออบเจ็กต์ภาพไม่ให้เคลื่อนย้าย/ปรับขนาดโดยไม่ได้ตั้งใจได้อย่างไร?**  
ใช้ [shape locks](https://reference.aspose.com/slides/th/python-net/aspose.slides/pictureframe/picture_frame_lock/) สำหรับ [PictureFrame](https://reference.aspose.com/slides/th/python-net/aspose.slides/pictureframe/) (เช่น ปิดการย้ายหรือปรับขนาด) กลไกการล็อคนี้อธิบายไว้ในบทความการป้องกันรูปทรงแยกต่างหา [/slides/th/python-net/applying-protection-to-presentation/] และรองรับหลายประเภทของรูปทรงรวมถึง [PictureFrame](https://reference.aspose.com/slides/th/python-net/aspose.slides/pictureframe/)

**การรักษาความแม่นยำของเวกเตอร์ SVG จะยังคงอยู่หรือไม่เมื่อส่งออกงานนำเสนอเป็น PDF/ภาพ?**  
Aspose.Slides อนุญาตให้ดึง SVG จาก [PictureFrame](https://reference.aspose.com/slides/th/python-net/aspose.slides/pictureframe/) เป็นเวกเตอร์ดั้งเดิม เมื่อ [exporting to PDF](/slides/th/python-net/convert-powerpoint-to-pdf/) หรือ [raster formats](/slides/th/python-net/convert-powerpoint-to-png/) ผลลัพธ์อาจถูกแปลงเป็นราสเตอร์ขึ้นอยู่กับการตั้งค่าการส่งออก; ความจริงที่ว่า SVG ดั้งเดิมถูกเก็บเป็นเวกเตอร์จะได้รับการยืนยันจากพฤติกรรมการดึงข้อมูล.