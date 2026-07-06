---
title: เพิ่มกรอบรูปในงานนำเสนอด้วย Python
linktitle: กรอบรูป
type: docs
weight: 10
url: /th/python-net/picture-frame/
keywords:
- กรอบรูป
- เพิ่มกรอบรูป
- สร้างกรอบรูป
- เพิ่มภาพ
- สร้างภาพ
- สกัดภาพ
- ภาพแรสเตอร์
- ภาพเวกเตอร์
- ครอบภาพ
- พื้นที่ที่ถูกครอบ
- คุณสมบัติ StretchOff
- การจัดรูปแบบกรอบรูป
- คุณสมบัติกรอบรูป
- สเกลสัมพันธ์
- เอฟเฟกต์ภาพ
- อัตราส่วน
- ความโปร่งใสของภาพ
- PowerPoint
- OpenDocument
- การนำเสนอ
- Python
- Aspose.Slides
description: "เพิ่มกรอบรูปในงานนำเสนอ PowerPoint และ OpenDocument ด้วย Aspose.Slides สำหรับ Python ผ่าน .NET. เพิ่มประสิทธิภาพการทำงานของคุณและปรับปรุงการออกแบบสไลด์."
---
## **บทนำ**

กรอบรูปใน Aspose.Slides for Python ให้คุณวางและจัดการภาพแรสเตอร์และเวกเตอร์เป็นรูปร่างสไลด์แบบดิบ คุณสามารถแทรกรูปภาพจากไฟล์หรือสตรีม, ตำแหน่งและปรับขนาดด้วยพิกัดที่แม่นยำ, เติมการหมุน, ตั้งค่าความโปร่งใส, และควบคุม z-order พร้อมกับรูปร่างอื่น ๆ API ยังรองรับการครอป, การรักษาอัตราส่วน, การตั้งค่าขอบและเอฟเฟกต์, และการเปลี่ยนภาพพื้นฐานโดยไม่ต้องสร้างเลเอาต์ใหม่ เนื่องจากกรอบรูปทำงานเช่นรูปร่างทั่วไป คุณสามารถเพิ่มแอนิเมชัน, ไฮเปอร์ลิงก์, และข้อความแทนที่ ทำให้การสร้างงานนำเสนอที่มีภาพสวยงามและเข้าถึงได้ง่ายเป็นเรื่องตรงไปตรงมา

## **สร้างกรอบรูป**

ส่วนนี้แสดงวิธีแทรกภาพลงในสไลด์โดยสร้าง [PictureFrame](https://reference.aspose.com/slides/th/python-net/aspose.slides/pictureframe/) ด้วย Aspose.Slides for Python คุณจะได้เรียนรู้วิธีโหลดภาพ, วางบนสไลด์อย่างแม่นยำ, และควบคุมขนาดและการจัดรูปแบบของมัน

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/)  
2. รับสไลด์ตามดัชนีของมัน  
3. สร้าง [PPImage](https://reference.aspose.com/slides/th/python-net/aspose.slides/ppimage/) โดยเพิ่มภาพลงใน [ImageCollection](https://reference.aspose.com/slides/th/python-net/aspose.slides/imagecollection/) ของการนำเสนอ ภาพนี้จะใช้เพื่อเติมรูปร่าง  
4. ระบุความกว้างและความสูงของกรอบ  
5. สร้าง [PictureFrame](https://reference.aspose.com/slides/th/python-net/aspose.slides/pictureframe/) ขนาดนั้นโดยใช้เมธอด [add_picture_frame](https://reference.aspose.com/slides/th/python-net/aspose.slides/shapecollection/add_picture_frame/)  
6. บันทึกการนำเสนอเป็นไฟล์ PPTX  

โค้ด Python ด้านล่างแสดงวิธีสร้างกรอบรูป:

```py
import aspose.slides as slides

# สร้างอินสแตนซ์ของคลาส Presentation เพื่อเป็นตัวแทนไฟล์ PPTX.
with slides.Presentation() as presentation:
    # ดึงสไลด์แรก.
    slide = presentation.slides[0]

    # เพิ่มรูปภาพลงในงานนำเสนอ.
    with open("image.jpeg", "rb") as image_stream:
        image = presentation.images.add_image(image_stream)

        # เพิ่มกรอบรูปที่มีขนาดเท่ากับภาพ.
        picture_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 50, 50, image.width, image.height, image)

        # บันทึกงานนำเสนอเป็น PPTX.
        presentation.save("picture_frame.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert color="warning" %}}
กรอบรูปช่วยให้คุณสร้างสไลด์การนำเสนอจากภาพได้อย่างรวดเร็ว เมื่อคุณรวมกรอบรูปกับตัวเลือกการบันทึกของ Aspose.Slides คุณสามารถควบคุมการดำเนินการ I/O เพื่อแปลงภาพจากรูปแบบหนึ่งเป็นอีกรูปแบบหนึ่ง คุณอาจต้องการดูหน้าต่อไปนี้: แปลง [รูปภาพเป็น JPG](https://products.aspose.com/slides/th/python-net/conversion/image-to-jpg/); แปลง [JPG เป็นรูปภาพ](https://products.aspose.com/slides/th/python-net/conversion/jpg-to-image/); แปลง [JPG เป็น PNG](https://products.aspose.com/slides/th/python-net/conversion/jpg-to-png/); แปลง [PNG เป็น JPG](https://products.aspose.com/slides/th/python-net/conversion/png-to-jpg/); แปลง [PNG เป็น SVG](https://products.aspose.com/slides/th/python-net/conversion/png-to-svg/); แปลง [SVG เป็น PNG](https://products.aspose.com/slides/th/python-net/conversion/svg-to-png/).
{{% /alert %}}

## **สร้างกรอบรูปด้วยสเกลสัมพันธ์**

ส่วนนี้สาธิตการวางภาพด้วยขนาดคงที่ แล้วใช้การสเกลตามเปอร์เซ็นต์แยกกันสำหรับความกว้างและความสูง เนื่องจากเปอร์เซ็นต์อาจต่างกัน อัตราส่วนอาจเปลี่ยนแปลง การสเกลทำโดยอิงจากมิติเดิมของภาพ

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/)  
2. รับสไลด์ตามดัชนีของมัน  
3. สร้าง [PPImage](https://reference.aspose.com/slides/th/python-net/aspose.slides/ppimage/) โดยเพิ่มภาพลงใน [ImageCollection](https://reference.aspose.com/slides/th/python-net/aspose.slides/imagecollection/)  
4. เพิ่ม [PictureFrame](https://reference.aspose.com/slides/th/python-net/aspose.slides/pictureframe/) ลงในสไลด์  
5. ตั้งค่าความกว้างและความสูงสัมพันธ์ของกรอบรูป  
6. บันทึกการนำเสนอเป็นไฟล์ PPTX  

โค้ด Python ด้านล่างแสดงวิธีสร้างกรอบรูปด้วยการสเกลสัมพันธ์:

```py
import aspose.slides as slides

# สร้างอินสแตนซ์ของคลาส Presentation เพื่อเป็นตัวแทนไฟล์ PPTX.
with slides.Presentation() as presentation:
    # ดึงสไลด์แรก.
    slide = presentation.slides[0]

    # เพิ่มรูปภาพลงในคอลเลกชันภาพของงานนำเสนอ.
    with open("image.jpeg", "rb") as image_stream:
        image = presentation.images.add_image(image_stream)

        # เพิ่มกรอบรูปลงในสไลด์.
        picture_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 50, 50, 100, 100, image)

        # ตั้งค่าความกว้างและความสูงสเกลสัมพันธ์.
        picture_frame.relative_scale_height = 0.8
        picture_frame.relative_scale_width = 1.35

        # บันทึกงานนำเสนอ.
        presentation.save("relative_scaling.pptx", slides.export.SaveFormat.PPTX)
```

## **สกัดภาพแรสเตอร์จากกรอบรูป**

คุณสามารถสกัดภาพแรสเตอร์จากอ็อบเจ็กต์ [PictureFrame](https://reference.aspose.com/slides/th/python-net/aspose.slides/pictureframe/) แล้วบันทึกเป็น PNG, JPG หรือรูปแบบอื่น ตัวอย่างโค้ดด้านล่างแสดงวิธีสกัดภาพจากเอกสาร “sample.pptx” และบันทึกเป็นรูปแบบ PNG

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    first_slide = presentation.slides[0]
    first_shape = first_slide.shapes[0]

    if isinstance(first_shape, slides.PictureFrame):
        image = first_shape.picture_format.picture.image.image
        image.save("slide_1_shape_1.png", slides.ImageFormat.PNG)
```

## **สกัดภาพ SVG จากกรอบรูป**

เมื่อการนำเสนอมีกราฟิก SVG อยู่ในรูปร่าง [PictureFrame](https://reference.aspose.com/slides/th/python-net/aspose.slides/pictureframe/) Aspose.Slides for Python via .NET ให้คุณดึงภาพเวกเตอร์ดั้งเดิมออกมาโดยคงความละเอียดเต็มโดยการเดินทางผ่านคอลเลกชันรูปร่างของสไลด์ คุณสามารถระบุแต่ละ [PictureFrame](https://reference.aspose.com/slides/th/python-net/aspose.slides/pictureframe/), ตรวจสอบว่า [PPImage](https://reference.aspose.com/slides/th/python-net/aspose.slides/ppimage/) ที่อยู่ข้างใต้มีเนื้อหา SVG หรือไม่ แล้วบันทึกภาพนั้นลงดิสก์หรือสตรีมในรูปแบบ SVG ดิบ

โค้ดตัวอย่างต่อไปนี้แสดงวิธีสกัดภาพ SVG จากกรอบรูป:

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

## **รับความโปร่งใสของภาพ**

Aspose.Slides ให้คุณดึงเอาเอฟเฟกต์ความโปร่งใสที่ใช้กับภาพได้ โค้ด Python ด้านล่างแสดงการทำงานนี้:

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

## **รับความสว่างและความคอนทราสต์ของภาพ**

Aspose.Slides ให้คุณดึงเอาเอฟเฟกต์ความสว่างและความคอนทราสต์ที่ใช้กับภาพได้ คลาส [Luminance](https://reference.aspose.com/slides/th/python-net/aspose.slides.effects/luminance/) แทนการแปลงเอฟเฟกต์นี้ของภาพ

โค้ด Python ด้านล่างแสดงวิธีรับการตั้งค่าความสว่างและความคอนทราสต์จากกรอบรูป:

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]
    picture_frame = shape

    image_transform = picture_frame.picture_format.picture.image_transform
    for effect in image_transform:
        if isinstance(effect, slides.effects.Luminance):
            luminance = effect.get_effective()
            brightness = luminance.brightness
            contrast = luminance.contrast

            print("Brightness: " + str(brightness))
            print("Contrast: " + str(contrast))
```

## **การจัดรูปแบบกรอบรูป**

Aspose.Slides มีตัวเลือกการจัดรูปแบบมากมายที่คุณสามารถใช้กับกรอบรูปได้ ด้วยตัวเลือกเหล่านี้คุณสามารถปรับกรอบรูปให้ตรงตามความต้องการเฉพาะ

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/)  
2. รับสไลด์ตามดัชนีของมัน  
3. สร้าง [PPImage](https://reference.aspose.com/slides/th/python-net/aspose.slides/ppimage/) โดยเพิ่มภาพลงใน [ImageCollection](https://reference.aspose.com/slides/th/python-net/aspose.slides/imagecollection/) ของการนำเสนอ ภาพนี้จะใช้เพื่อเติมรูปร่าง  
4. ระบุความกว้างและความสูงของกรอบ  
5. สร้าง [PictureFrame](https://reference.aspose.com/slides/th/python-net/aspose.slides/pictureframe/) ขนาดนั้นโดยใช้เมธอด [add_picture_frame](https://reference.aspose.com/slides/th/python-net/aspose.slides/shapecollection/add_picture_frame/) ของสไลด์  
6. ตั้งค่าสีเส้นของกรอบรูป  
7. ตั้งค่าความกว้างของเส้นกรอบรูป  
8. หมุนกรอบรูปโดยระบุค่าบวก (ตามเข็มนาฬิกา) หรือค่าลบ (ทวนเข็มนาฬิกา)  
9. บันทึกการนำเสนอที่แก้ไขแล้วเป็นไฟล์ PPTX  

โค้ด Python ด้านล่างแสดงกระบวนการจัดรูปแบบกรอบรูป:

```py
import aspose.slides as slides
import aspose.pydrawing as draw

# สร้างอินสแตนซ์ของคลาส Presentation เพื่อเป็นตัวแทนไฟล์ PPTX.
with slides.Presentation() as presentation:
    # ดึงสไลด์แรก.
    slide = presentation.slides[0]

    # เพิ่มรูปภาพลงในคอลเลกชันภาพของงานนำเสนอ.
    with open("image.jpeg", "rb") as image_stream:
        image = presentation.images.add_image(image_stream)

        # เพิ่มกรอบรูปที่มีขนาดเท่ากับภาพ.
        picture_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 50, 50, image.width, image.height, image)

        # ใช้การจัดรูปแบบกับกรอบรูป.
        picture_frame.line_format.fill_format.fill_type = slides.FillType.SOLID
        picture_frame.line_format.fill_format.solid_fill_color.color = draw.Color.blue
        picture_frame.line_format.width = 20
        picture_frame.rotation = 45

    # บันทึกงานนำเสนอเป็น PPTX.
    presentation.save("picture_formatting.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert title="Tip" color="primary" %}}
Aspose ได้พัฒนาเครื่องมือฟรี [Collage Maker](https://products.aspose.app/slides/th/collage) หากคุณต้องการ [รวม JPG/JPEG](https://products.aspose.app/slides/th/collage/jpg) หรือ PNG, หรือ [สร้างกริดรูปถ่าย](https://products.aspose.app/slides/th/collage/photo-grid) คุณสามารถใช้บริการนี้ได้  
{{% /alert %}}

## **เพิ่มรูปภาพเป็นลิงก์**

เพื่อให้ไฟล์การนำเสนอมีขนาดเล็ก คุณสามารถเพิ่มรูปภาพหรือวิดีโอกับลิงก์แทนการฝังไฟล์โดยตรงในงานนำเสนอ โค้ด Python ด้านล่างแสดงวิธีแทรกรูปภาพและวิดีโอลงใน placeholder:

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

## **ครอปภาพ**

ในส่วนนี้คุณจะได้เรียนรู้วิธีครอปรูปภาพภายในกรอบรูปโดยไม่ต้องแก้ไขไฟล์ต้นทาง คุณยังจะได้เรียนรู้วิธีการกำหนดขอบครอปเพื่อสร้างภาพที่สะอาดและเน้นจุดสนใจโดยตรงบนสไลด์

โค้ด Python ด้านล่างแสดงวิธีครอปรูปบนสไลด์:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # เพิ่มรูปภาพลงในคอลเลกชันภาพของงานนำเสนอ.
    with slides.Images.from_file("image.png") as source_image:
        image = presentation.images.add_image(source_image)

    # เพิ่มกรอบรูปลงในสไลด์.
    picture_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 100, 100, 420, 250, image)

    # ครอบตัดรูปภาพ (ค่าร้อยละ).
    picture_frame.picture_format.crop_left = 23.6
    picture_frame.picture_format.crop_right = 21.5
    picture_frame.picture_format.crop_top = 3
    picture_frame.picture_format.crop_bottom = 31

    # บันทึกผลลัพธ์.
    presentation.save("cropped_image.pptx", slides.export.SaveFormat.PPTX)
```

## **ลบพื้นที่ที่ถูกครอปของภาพ**

หากต้องการลบพื้นที่ที่ถูกครอปของภาพในกรอบ ให้ใช้เมธอด [delete_picture_cropped_areas](https://reference.aspose.com/slides/th/python-net/aspose.slides/picturefillformat/delete_picture_cropped_areas/) เมธอดนี้จะคืนค่าภาพที่ถูกครอป หรือภาพเดิมหากไม่มีการครอป

โค้ด Python ด้านล่างแสดงการทำงานนี้:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    # รับ PictureFrame จากสไลด์แรก.
    picture_frame = slides.shape[0]

    # รับ PictureFrame จากสไลด์แรก.
    cropped_image = picture_frame.picture_format.delete_picture_cropped_areas()

    # บันทึกผลลัพธ์.
    presentation.save("deleted_cropped_areas.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert title="NOTE" color="warning" %}}
เมธอด [delete_picture_cropped_areas](https://reference.aspose.com/slides/th/python-net/aspose.slides/picturefillformat/delete_picture_cropped_areas/) จะเพิ่มภาพที่ถูกครอปลงในคอลเลกชันภาพของการนำเสนอ หากภาพถูกใช้เพียงใน [PictureFrame](https://reference.aspose.com/slides/th/python-net/aspose.slides/pictureframe/) ที่ประมวลผลแล้ว นี้อาจลดขนาดของการนำเสนอ; หากไม่ใช่ จำนวนภาพในผลลัพธ์อาจเพิ่มขึ้น

ระหว่างการครอป เมธอดนี้จะแปลงไฟล์เมตาฟไฟล์ WMF/EMF ไปเป็นภาพแรสเตอร์ PNG  
{{% /alert %}}

## **บีบอัดภาพ**

คุณสามารถบีบอัดรูปในงานนำเสนอโดยใช้เมธอด [PictureFillFormat.compress_image](https://reference.aspose.com/slides/th/python-net/aspose.slides/picturefillformat/compress_image/)  
เมธอดนี้บีบอัดภาพโดยลดขนาดตามขนาดรูปร่างและความละเอียดที่กำหนด พร้อมตัวเลือกเพื่อลบพื้นที่ที่ครอป

มันปรับขนาดและความละเอียดของรูปภาพเช่นเดียวกับฟีเจอร์ **Picture Format → Compress Pictures → Resolution** ของ PowerPoint

ตัวอย่าง Python ด้านล่างแสดงวิธีบีบอัดภาพในงานนำเสนอโดยระบุความละเอียดเป้าหมายและเลือกลบพื้นที่ที่ครอป (ถ้าต้องการ):

```python
import aspose.slides as slides

with slides.Presentation("demo.pptx") as presentation:
    slide = presentation.slides[0]
    picture_frame = slide.shapes[0]

    # บีบอัดภาพด้วยความละเอียดเป้าหมาย 150 DPI (ความละเอียดเว็บ) และลบพื้นที่ที่ถูกครอบ.
    result = picture_frame.picture_format.compress_image(True, slides.export.PicturesCompression.DPI150)

    # ตรวจสอบผลลัพธ์ของการบีบอัด.
    if result:
        print("Image successfully compressed.")
    else:
        print("Image compression failed or no changes were necessary.")

    presentation.save("compressed_image.pptx", slides.export.SaveFormat.PPTX)
```

หรือใช้ค่ DPI แบบกำหนดเองโดยตรง:

```python
import aspose.slides as slides

with slides.Presentation("demo.pptx") as presentation:
    slide = presentation.slides[0]
    picture_frame = slide.shapes[0]

    # บีบอัดภาพเป็น 150 DPI (ความละเอียดเว็บ) โดยลบพื้นที่ที่ถูกครอบ.
    picture_frame.picture_format.compress_image(True, 150)

    presentation.save("compressed_image.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert title="NOTE" color="warning" %}}
เมธอดจะเปลี่ยนภาพเป็นความละเอียดที่ต่ำลงตามขนาดรูปร่างและ DPI ที่ให้ไว้ พื้นที่ที่ถูกครอปสามารถลบได้เพื่อเพิ่มประสิทธิภาพขนาดไฟล์  
หากภาพเป็นเมตาฟไฟล์ (WMF/EMF) หรือ SVG การบีบอัดจะไม่ถูกนำไปใช้ อีกทั้งคุณภาพ JPEG จะถูกเก็บหรือปรับลดเล็กน้อยตามความละเอียดเช่นเดียวกับ PowerPoint  
{{% /alert %}}

## **ล็อคอัตราส่วนของภาพ**

หากต้องการให้รูปร่างที่บรรจุภาพคงอัตราส่วนหลังจากเปลี่ยนขนาดภาพ ให้ตั้งค่า [aspect_ratio_locked](https://reference.aspose.com/slides/th/python-net/aspose.slides/pictureframelock/aspect_ratio_locked/) เป็น `True`

โค้ด Python ด้านล่างแสดงวิธีล็อคอัตราส่วนของรูปร่าง:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    layout = presentation.layout_slides.get_by_type(slides.SlideLayoutType.CUSTOM)
    empty_slide = presentation.slides.add_empty_slide(layout)

    with slides.Images.from_file("image.png") as source_image:
        image = presentation.images.add_image(source_image)

    picture_frame = empty_slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 50, 50, image.width, image.height, image)

    # ล็อคอัตราส่วนเมื่อปรับขนาด.
    picture_frame.picture_frame_lock.aspect_ratio_locked = True

    presentation.save("aspect_ratio_locked.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert title="NOTE" color="warning" %}}
การตั้งค่า *Lock Aspect Ratio* นี้จะคงอัตราส่วนของรูปร่างเท่านั้น ไม่ได้คงอัตราส่วนของภาพภายในรูปร่าง  
{{% /alert %}}

## **ใช้คุณสมบัติ Stretch Offset**

โดยใช้คุณสมบัติ `stretch_offset_left`, `stretch_offset_top`, `stretch_offset_right` และ `stretch_offset_bottom` ของคลาส [PictureFillFormat](https://reference.aspose.com/slides/th/python-net/aspose.slides/picturefillformat/) คุณสามารถกำหนดสี่เหลี่ยมเติมได้

เมื่อกำหนดการยืดสำหรับภาพ สี่เหลี่ยมต้นฉบับจะถูกสเกลเพื่อให้พอดีกับสี่เหลี่ยมเติม แต่ละขอบของสี่เหลี่ยมเติมจะถูกกำหนดโดยออฟเซ็ตเปอร์เซ็นต์จากขอบที่สอดคล้องของกล่องขอบเขตของรูปร่าง ออฟเซ็ตเปอร์เซ็นต์บวกระบุการย่อตัวเข้ามา ส่วนออฟเซ็ตลบระบุการขยายออกไป

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/)  
2. รับอ้างอิงถึงสไลด์ตามดัชนีของมัน  
3. เพิ่ม [AutoShape](https://reference.aspose.com/slides/th/python-net/aspose.slides/autoshape/) สี่เหลี่ยม  
4. ตั้งค่าชนิดการเติมของรูปร่าง  
5. ตั้งค่าโหมดเติมรูปภาพของรูปร่าง  
6. โหลดภาพ  
7. กำหนดภาพให้เติมรูปทรง  
8. ระบุออฟเซ็ตของภาพจากขอบที่สอดคล้องของกล่องขอบเขตของรูปร่าง  
9. บันทึกการนำเสนอเป็นไฟล์ PPTX  

โค้ด Python ด้านล่างสาธิตวิธีใช้คุณสมบัติ Stretch Offset:

```py
import aspose.slides as slides

# สร้างอินสแตนซ์ของคลาส Presentation ที่เป็นตัวแทนไฟล์ PPTX.
with slides.Presentation() as presentation:
    # ดึงสไลด์แรก.
    slide = presentation.slides[0]

    # เพิ่ม AutoShape สี่เหลี่ยมผืนผ้า.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 300, 300)

    # ตั้งค่าชนิดการเติมของรูปร่าง.
    shape.fill_format.fill_type = slides.FillType.PICTURE

    # ตั้งค่าโหมดการเติมรูปภาพของรูปร่าง.
    shape.fill_format.picture_fill_format.picture_fill_mode = slides.PictureFillMode.STRETCH

    # โหลดภาพและเพิ่มเข้าไปในงานนำเสนอ.
    with open("image.jpeg", "rb") as image_stream:
        image = presentation.images.add_image(image_stream)

    # กำหนดภาพเพื่อเติมรูปร่าง.
    shape.fill_format.picture_fill_format.picture.image = image

    # ระบุออฟเซ็ตของภาพจากขอบที่สอดคล้องของกล่องขอบเขตของรูปร่าง.
    shape.fill_format.picture_fill_format.stretch_offset_left = 25
    shape.fill_format.picture_fill_format.stretch_offset_right = 25
    shape.fill_format.picture_fill_format.stretch_offset_top = -20
    shape.fill_format.picture_fill_format.stretch_offset_bottom = -10

    # บันทึกไฟล์ PPTX ลงดิสก์.
    presentation.save("stretch_offset.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert  title="Tip" color="primary" %}}
Aspose มีเครื่องแปลงฟรี — [JPEG to PowerPoint](https://products.aspose.app/slides/th/import/jpg-to-ppt) และ [PNG to PowerPoint](https://products.aspose.app/slides/th/import/png-to-ppt) — ที่ช่วยให้คุณสร้างงานนำเสนอจากภาพได้อย่างรวดเร็ว  
{{% /alert %}}

## **คำถามที่พบบ่อย**

**ฉันจะตรวจสอบได้ว่าแบบฟอร์มภาพใดบ้างที่รองรับสำหรับ PictureFrame?**  
Aspose.Slides รองรับทั้งภาพแรสเตอร์ (PNG, JPEG, BMP, GIF ฯลฯ) และภาพเวกเตอร์ (เช่น SVG) ผ่านอ็อบเจ็กต์ภาพที่กำหนดให้กับ [PictureFrame](https://reference.aspose.com/slides/th/python-net/aspose.slides/pictureframe/) รายการรูปแบบที่รองรับโดยทั่วไปจะทับซ้อนกับความสามารถของเอนจินการแปลงสไลด์และภาพ

**การเพิ่มรูปภาพขนาดใหญ่หลายสิบภาพจะส่งผลต่อขนาดและประสิทธิภาพของไฟล์ PPTX อย่างไร?**  
การฝังภาพขนาดใหญ่จะเพิ่มขนาดไฟล์และการใช้หน่วยความจำ; การลิงก์ภาพช่วยให้ขนาดการนำเสนอเล็กลงแต่ต้องให้ไฟล์ภายนอกยังคงเข้าถึงได้ Aspose.Slides มีความสามารถในการเพิ่มภาพโดยลิงก์เพื่อ ลดขนาดไฟล์

**ฉันจะล็อคอ็อบเจ็กต์ภาพไม่ให้ถูกย้ายหรือปรับขนาดโดยบังเอิญได้อย่างไร?**  
ใช้ [shape locks](https://reference.aspose.com/slides/th/python-net/aspose.slides/pictureframe/picture_frame_lock/) สำหรับ [PictureFrame](https://reference.aspose.com/slides/th/python-net/aspose.slides/pictureframe/) (เช่น ปิดการย้ายหรือการปรับขนาด) กลไกการล็อคอธิบายไว้สำหรับรูปร่างในบทความการปกป้องแยกต่างหาก [/slides/th/python-net/applying-protection-to-presentation/] และรองรับหลายประเภทรูปร่างรวมถึง [PictureFrame](https://reference.aspose.com/slides/th/python-net/aspose.slides/pictureframe/)

**ความละเอียดของเวกเตอร์ SVG จะคงไว้เมื่อส่งออกการนำเสนอเป็น PDF/ภาพหรือไม่?**  
Aspose.Slides อนุญาตให้สกัด SVG จาก [PictureFrame](https://reference.aspose.com/slides/th/python-net/aspose.slides/pictureframe/) เป็นเวกเตอร์ดั้งเดิม เมื่อ [exporting to PDF](/slides/th/python-net/convert-powerpoint-to-pdf/) หรือ [raster formats](/slides/th/python-net/convert-powerpoint-to-png/) ผลลัพธ์อาจถูกแปลงเป็นแรสเตอร์ขึ้นอยู่กับการตั้งค่าการส่งออก; ความจริงที่ว่า SVG ดั้งเดิมถูกเก็บเป็นเวกเตอร์ได้รับการยืนยันจากพฤติกรรมการสกัดนี้.