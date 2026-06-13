---
title: เพิ่มประสิทธิภาพการจัดการรูปภาพใน PowerPoint ด้วย Python
linktitle: จัดการรูปภาพ
type: docs
weight: 10
url: /th/python-net/image/
keywords:
- เพิ่มรูปภาพ
- เพิ่มรูป
- เพิ่มบิตแมพ
- แทนที่รูปภาพ
- แทนที่รูป
- จากเว็บ
- พื้นหลัง
- เพิ่ม PNG
- เพิ่ม JPG
- เพิ่ม SVG
- เพิ่ม EMF
- เพิ่ม WMF
- เพิ่ม TIFF
- PowerPoint
- การนำเสนอ
- Python
- Aspose.Slides
description: "ปรับกระบวนการจัดการรูปภาพใน PowerPoint และ OpenDocument ด้วย Aspose.Slides for Python บน .NET เพื่อเพิ่มประสิทธิภาพและอัตโนมัติกระบวนการทำงานของคุณ."
---
## **บทนำ**

รูปภาพทำให้การนำเสนอมีส่วนร่วมและน่าสนใจยิ่งขึ้น. ใน Microsoft PowerPoint คุณสามารถแทรกรูปภาพจากไฟล์ อินเทอร์เน็ต หรือแหล่งอื่น ๆ ลงบนสไลด์ได้. ในทำนองเดียวกัน Aspose.Slides ให้คุณเพิ่มรูปภาพลงในสไลด์ได้หลายวิธี.

{{% alert  title="Tip" color="primary" %}}

Aspose มีตัวแปลงฟรี—[JPEG to PowerPoint](https://products.aspose.app/slides/th/import/jpg-to-ppt) และ [PNG to PowerPoint](https://products.aspose.app/slides/th/import/png-to-ppt)—ที่ช่วยให้คุณสร้างการนำเสนอจากรูปภาพได้อย่างรวดเร็ว.

{{% /alert %}}

{{% alert title="Info" color="info" %}}

หากคุณต้องการเพิ่มรูปภาพเป็นออบเจ็กต์กรอบ—โดยเฉพาะอย่างยิ่งหากคุณวางแผนที่จะใช้ตัวเลือกการจัดรูปแบบมาตรฐาน เช่น การปรับขนาดหรือการใช้เอฟเฟกต์—ดู [Add Picture Frames to Presentations with Python](https://docs.aspose.com/slides/th/python-net/picture-frame/).

{{% /alert %}}

{{% alert title="Note" color="warning" %}}

คุณสามารถใช้การดำเนินการ I/O ของรูปภาพและการนำเสนอเพื่อแปลงรูปภาพระหว่างฟอร์แมตต่าง ๆ ดูหน้าต่อไปนี้: แปลง [image to JPG](https://products.aspose.com/slides/th/python-net/conversion/image-to-jpg/); แปลง [JPG to image](https://products.aspose.com/slides/th/python-net/conversion/jpg-to-image/); แปลง [JPG to PNG](https://products.aspose.com/slides/th/python-net/conversion/jpg-to-png/); แปลง [PNG to JPG](https://products.aspose.com/slides/th/python-net/conversion/png-to-jpg/); แปลง [PNG to SVG](https://products.aspose.com/slides/th/python-net/conversion/png-to-svg/); และแปลง [SVG to PNG](https://products.aspose.com/slides/th/python-net/conversion/svg-to-png/).

{{% /alert %}}

Aspose.Slides รองรับการทำงานกับรูปภาพในฟอร์แมตที่นิยม เช่น JPEG, PNG, BMP, GIF และอื่น ๆ.

## **เพิ่มรูปภาพที่เก็บไว้ในเครื่องลงในสไลด์**

คุณสามารถเพิ่มรูปภาพหนึ่งหรือหลายรูปจากคอมพิวเตอร์ของคุณลงในสไลด์ของการนำเสนอได้. ตัวอย่าง Python ด้านล่างแสดงวิธีเพิ่มรูปภาพลงในสไลด์:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    with open("image.jpeg", "rb") as image_stream:
        image = presentation.images.add_image(image_stream)
        slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 10, 10, 100, 100, image)

    presentation.save("presentation_with_image.pptx", slides.export.SaveFormat.PPTX)
```

## **เพิ่มรูปภาพจากเว็บลงในสไลด์**

หากรูปภาพที่คุณต้องการเพิ่มลงในสไลด์ไม่มีในคอมพิวเตอร์ของคุณ คุณสามารถแทรกโดยตรงจากเว็บได้. ตัวอย่าง Python ด้านล่างแสดงวิธีเพิ่มรูปภาพจาก URL ลงในสไลด์:

```py
import aspose.slides as slides
import urllib2
import base64

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    image_data = base64.b64encode(urllib2.urlopen("[REPLACE WITH URL]").read())

    image = presentation.images.add_image(image_data)
    slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 10, 10, 100, 100, image)
    
    presentation.save("presentation.pptx", slides.export.SaveFormat.PPTX)
```

## **เพิ่มรูปภาพลงใน Slide Master**

Slide Master คือสไลด์ระดับบนสุดที่เก็บและควบคุมข้อมูล—ธีม, เค้าโครง, เป็นต้น—สำหรับสไลด์ทั้งหมดที่อยู่ด้านล่าง เมื่อคุณเพิ่มรูปภาพลงใน Slide Master รูปภาพนั้นจะปรากฏบนทุกสไลด์ที่ใช้ Master นั้น.

ตัวอย่าง Python ด้านล่างแสดงวิธีเพิ่มรูปภาพลงใน Slide Master:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    master_slide = slide.layout_slide.master_slide

    with open("image.jpeg", "rb") as image_stream:
        image = presentation.images.add_image(image_stream)
        master_slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 10, 10, 100, 100, image)

    presentation.save("master_with_image.pptx", slides.export.SaveFormat.PPTX)
```

## **ตั้งรูปภาพเป็นพื้นหลังของสไลด์**

คุณอาจต้องการใช้รูปภาพเป็นพื้นหลังสำหรับสไลด์เดียวหรือหลายสไลด์ สำหรับรายละเอียดดูที่ [Set an Image as the Background for a Slide](https://docs.aspose.com/slides/th/python-net/presentation-background/#set-image-as-background-for-slide).

## **เพิ่ม SVG ไปยังการนำเสนอ**

คุณสามารถแทรกรูปภาพใด ๆ ลงในการนำเสนอโดยใช้เมธอด [add_picture_frame](https://reference.aspose.com/slides/th/python-net/aspose.slides/shapecollection/add_picture_frame/) ของคลาส [ShapeCollection](https://reference.aspose.com/slides/th/python-net/aspose.slides/shapecollection/).

เพื่อสร้างออบเจ็กต์รูปภาพจาก SVG ให้ทำตามขั้นตอนต่อไปนี้:

1. สร้าง [SvgImage](https://reference.aspose.com/slides/th/python-net/aspose.slides/svgimage/) แล้วเพิ่มลงในคอลเลกชันรูปภาพของการนำเสนอ.
2. สร้างออบเจ็กต์ [PPImage](https://reference.aspose.com/slides/th/python-net/aspose.slides/ppimage/) จาก [SvgImage](https://reference.aspose.com/slides/th/python-net/aspose.slides/svgimage/).
3. สร้างออบเจ็กต์ [PictureFrame](https://reference.aspose.com/slides/th/python-net/aspose.slides/pictureframe/) ด้วยการใช้ [PPImage](https://reference.aspose.com/slides/th/python-net/aspose.slides/ppimage/).

ตัวอย่าง Python ด้านล่างแสดงวิธีเพิ่มรูปภาพ SVG ลงในการนำเสนอโดยใช้ขั้นตอนเหล่านี้:

```py 
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # อ่านเนื้อหาของไฟล์ SVG.
    with open("sample.svg", "rt") as image_stream:
        svg_content = image_stream.read()
        # สร้างอ็อบเจ็กต์ SvgImage.
        svg_image = slides.SvgImage(svg_content)

        # สร้างอ็อบเจ็กต์ PPImage.
        pp_image = presentation.images.add_image(svg_image)

        # สร้าง PictureFrame ใหม่.
        slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 200, 100, pp_image.width, pp_image.height, pp_image)

        # บันทึกการนำเสนอในรูปแบบ PPTX.
        presentation.save("presentation_with_SVG.pptx", slides.export.SaveFormat.PPTX)
```

## **แปลง SVG เป็นชุดของรูปทรง**

Aspose.Slides จะแปลง SVG เป็นชุดของรูปทรงในวิธีที่คล้ายกับการจัดการ SVG ของ PowerPoint.

![PowerPoint Popup Menu](img_01_01.png)

ฟังก์ชันนี้มาจากการโอเวอร์โหลดของเมธอด [add_group_shape](https://reference.aspose.com/slides/th/python-net/aspose.slides/shapecollection/add_group_shape/) ในคลาส [ShapeCollection](https://reference.aspose.com/slides/th/python-net/aspose.slides/shapecollection/) ที่รับอาร์กิวเมนต์แรกเป็น [SvgImage](https://reference.aspose.com/slides/th/python-net/aspose.slides/svgimage/).

โค้ดตัวอย่างด้านล่างแสดงวิธีแปลงไฟล์ SVG เป็นชุดของรูปทรง.

```py 
import aspose.slides as slides

with slides.Presentation() as presentation:
    # อ่านเนื้อหาไฟล์ SVG.
    with open("sample.svg","rt") as image_stream:
        svg_content = image_stream.read()
        # สร้างอ็อบเจ็กต์ SvgImage.
        svg_image = slides.SvgImage(svg_content)

        # รับขนาดสไลด์.
        slide_size = presentation.slide_size.size

        # แปลงภาพ SVG เป็นกลุ่มของรูปทรงและปรับขนาดให้พอดีกับสไลด์.
        presentation.slides[0].shapes.add_group_shape(svg_image, 0, 0, slide_size.width, slide_size.height)

        # บันทึกการนำเสนอในรูปแบบ PPTX.
        presentation.save("shapes_from_SVG.pptx", slides.export.SaveFormat.PPTX)
```

## **เพิ่มรูปภาพเป็น EMF ในสไลด์**

Aspose.Slides for Python ให้คุณแทรกรูปภาพ Enhanced Metafile (EMF) ลงในการนำเสนอ.

ตัวอย่าง Python ด้านล่างแสดงวิธีนี้:

```py 
with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    with open("image.emf", "rb") as image_stream:
        emf_image = presentation.images.add_image(image_stream)
        slide_size = presentation.slide_size.size
        slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 0, 0, slide_size.width, slide_size.height, emf_image)
    
    presentation.save("presentation_with_EMF.pptx", slides.export.SaveFormat.PPTX)
```

## **แทนที่รูปภาพใน Image Collection**

Aspose.Slides อนุญาตให้คุณแทนที่รูปภาพที่เก็บอยู่ในคอลเลกชันรูปภาพของการนำเสนอ รวมถึงรูปภาพที่ใช้โดยรูปทรงสไลด์ ส่วนนี้สรุปวิธีหลายวิธีในการอัปเดตรูปภาพในคอลเลกชัน API มีเมธอดที่ง่ายต่อการแทนที่รูปภาพด้วยข้อมูลไบต์ดิบ, อินสแตนซ์ของ [IImage](https://reference.aspose.com/slides/th/python-net/aspose.slides/iimage/) หรือรูปภาพอื่นที่มีอยู่แล้วในคอลเลกชัน.

ทำตามขั้นตอนต่อไปนี้:

1. โหลดการนำเสนอที่มีรูปภาพโดยใช้คลาส [Presentation](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/).
2. โหลดรูปภาพใหม่จากไฟล์เข้าสู่ byte array.
3. แทนที่รูปภาพเป้าหมายด้วยรูปภาพใหม่โดยใช้ byte array.
4. หรืออีกวิธีหนึ่ง โหลดรูปภาพเข้าสู่ออบเจ็กต์ [IImage](https://reference.aspose.com/slides/th/python-net/aspose.slides/iimage/) และแทนที่รูปภาพเป้าหมายด้วยออบเจ็กต์นั้น.
5. หรือแทนที่รูปภาพเป้าหมายด้วยรูปภาพที่มีอยู่แล้วในคอลเลกชันรูปภาพของการนำเสนอ.
6. บันทึกการนำเสนอที่แก้ไขเป็นไฟล์ PPTX.

```py
def read_all_bytes(file_name):
    with open(file_name, "rb") as stream:
        return stream.read()


# สร้างอินสแตนซ์ของคลาส Presentation ที่แสดงไฟล์การนำเสนอ.
with slides.Presentation("sample.pptx") as presentation:

    # วิธีที่หนึ่ง.
    image_data = read_all_bytes("image0.jpeg")
    old_image = presentation.images[0]
    old_image.replace_image(image_data)

    # วิธีที่สอง.
    new_image = slides.Images.from_file("image1.jpeg")
    old_image = presentation.images[1]
    old_image.replace_image(new_image)

    # วิธีที่สาม.
    old_image = presentation.images[2]
    old_image.replace_image(presentation.images[3])

    # บันทึกการนำเสนอไปยังไฟล์.
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert title="Info" color="info" %}}

ด้วยตัวแปลงฟรี [Text to GIF](https://products.aspose.app/slides/th/text-to-gif) ของ Aspose คุณสามารถทำข้อความเคลื่อนไหวและสร้าง GIF จากข้อความได้อย่างง่ายดาย.

{{% /alert %}}

## **คำถามที่พบบ่อย**

**ความละเอียดของรูปภาพต้นฉบับยังคงเหมือนเดิมหลังจากแทรกหรือไม่?**

ใช่ พิกเซลต้นฉบับจะถูกเก็บไว้ แต่การแสดงผลสุดท้ายขึ้นอยู่กับวิธีการปรับขนาด [picture](/slides/th/python-net/picture-frame/) บนสไลด์และการบีบอัดใด ๆ ที่ทำในขั้นตอนบันทึก.

**วิธีที่ดีที่สุดในการแทนที่โลโก้เดียวกันในหลายสิบสไลด์พร้อมกันคืออะไร?**

วางโลโก้บนสไลด์แม่หรือเลย์เอาต์และแทนที่ในคอลเลกชันรูปภาพของการนำเสนอ — การอัปเดตจะกระจายไปยังทุกองค์ประกอบที่ใช้ทรัพยากรนั้น.

**สามารถแปลง SVG ที่แทรกแล้วเป็นรูปทรงที่แก้ไขได้หรือไม่?**

ได้ คุณสามารถแปลง SVG เป็นกลุ่มของรูปทรงได้ หลังจากนั้นส่วนย่อยต่าง ๆ จะสามารถแก้ไขได้ด้วยคุณสมบัติรูปทรงมาตรฐาน.

**ฉันจะตั้งรูปภาพเป็นพื้นหลังสำหรับหลายสไลด์พร้อมกันได้อย่างไร?**

[กำหนดรูปภาพเป็นพื้นหลัง](/slides/th/python-net/presentation-background/) บนสไลด์แม่หรือเลย์เอาต์ที่เกี่ยวข้อง — สไลด์ใด ๆ ที่ใช้แม่/เลย์เอาต์นั้นจะสืบทอดพื้นหลัง.

**ฉันจะป้องกันไม่ให้การนำเสนอเพิ่มขนาดมากเกินไปเนื่องจากรูปภาพจำนวนมากได้อย่างไร?**

ใช้ทรัพยากรรูปภาพเดียวซ้ำแทนการทำสำเนาเลือกความละเอียดที่เหมาะสมใช้การบีบอัดเมื่อต้องการบันทึก และเก็บกราฟิกที่ใช้ซ้ำบนสไลด์แม่เมื่อเหมาะสม.