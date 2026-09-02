---
title: เพิ่มประสิทธิภาพการจัดการภาพใน PowerPoint ด้วย Python
linktitle: จัดการภาพ
type: docs
weight: 10
url: /th/python-net/image/
keywords:
- เพิ่มภาพ
- เพิ่มรูปภาพ
- เพิ่มบิตแมป
- แทนที่ภาพ
- แทนที่รูปภาพ
- จากเว็บ
- พื้นหลัง
- เพิ่ม PNG
- เพิ่ม JPG
- เพิ่ม SVG
- เพิ่ม EMF
- เพิ่ม WMF
- เพิ่ม TIFF
- PowerPoint
- OpenDocument
- งานนำเสนอ
- Python
- Aspose.Slides
description: "ปรับปรุงการจัดการภาพใน PowerPoint และ OpenDocument ด้วย Aspose.Slides สำหรับ Python ผ่าน .NET เพื่อเพิ่มประสิทธิภาพการทำงานและอัตโนมัติขั้นตอนการทำงานของคุณ."
---
## **บทนำ**

ภาพทำให้การนำเสนอมีความน่าสนใจและดึงดูดมากขึ้น ใน Microsoft PowerPoint คุณสามารถแทรกรูปภาพจากไฟล์ อินเทอร์เน็ต หรือแหล่งอื่นลงในสไลด์ได้ เช่นเดียวกับ Aspose.Slides ที่ช่วยให้คุณเพิ่มภาพลงในสไลด์ได้หลายวิธี.

{{% alert  title="Tip" color="primary" %}}
Aspose มีตัวแปลงฟรี—[JPEG ไปยัง PowerPoint](https://products.aspose.app/slides/th/import/jpg-to-ppt) และ [PNG ไปยัง PowerPoint](https://products.aspose.app/slides/th/import/png-to-ppt)—ที่ช่วยให้คุณสร้างการนำเสนอจากภาพได้อย่างรวดเร็ว.
{{% /alert %}}

{{% alert title="Info" color="info" %}}
หากคุณต้องการเพิ่มภาพเป็นออบเจ็กต์เฟรม—โดยเฉพาะอย่างยิ่งหากคุณวางแผนใช้ตัวเลือกการจัดรูปแบบมาตรฐานเช่นการปรับขนาดหรือการใช้เอฟเฟกต์—ดูที่ [เพิ่มเฟรมรูปภาพในงานนำเสนอด้วย Python](https://docs.aspose.com/slides/th/python-net/picture-frame/).
{{% /alert %}}

{{% alert title="Note" color="warning" %}}
คุณสามารถใช้การดำเนินการ I/O ของภาพและการนำเสนอเพื่อแปลงภาพระหว่างรูปแบบต่าง ๆ ดูหน้าต่อไปนี้: แปลง [ภาพเป็น JPG](https://products.aspose.com/slides/th/python-net/conversion/image-to-jpg/); แปลง [JPG เป็นภาพ](https://products.aspose.com/slides/th/python-net/conversion/jpg-to-image/); แปลง [JPG เป็น PNG](https://products.aspose.com/slides/th/python-net/conversion/jpg-to-png/); แปลง [PNG เป็น JPG](https://products.aspose.com/slides/th/python-net/conversion/png-to-jpg/); แปลง [PNG เป็น SVG](https://products.aspose.com/slides/th/python-net/conversion/png-to-svg/); และแปลง [SVG เป็น PNG](https://products.aspose.com/slides/th/python-net/conversion/svg-to-png/).
{{% /alert %}}

Aspose.Slides รองรับการทำงานกับภาพในรูปแบบยอดนิยม เช่น JPEG, PNG, BMP, GIF และอื่น ๆ.

## **เพิ่มภาพที่จัดเก็บในเครื่องลงในสไลด์**

คุณสามารถเพิ่มภาพหนึ่งหรือหลายภาพจากคอมพิวเตอร์ของคุณลงในสไลด์ของการนำเสนอ ตัวอย่าง Python ด้านล่างแสดงวิธีการเพิ่มภาพลงในสไลด์:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    with open("image.jpeg", "rb") as image_stream:
        image = presentation.images.add_image(image_stream)
        slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 10, 10, 100, 100, image)

    presentation.save("presentation_with_image.pptx", slides.export.SaveFormat.PPTX)
```

## **เพิ่มภาพจากเว็บลงในสไลด์**

หากภาพที่คุณต้องการเพิ่มลงในสไลด์ไม่มีในคอมพิวเตอร์ของคุณ คุณสามารถแทรกภาพโดยตรงจากเว็บได้

ตัวอย่าง Python ด้านล่างแสดงวิธีการเพิ่มภาพจาก URL ลงในสไลด์:

```py
import aspose.slides as slides
from urllib.request import urlopen

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # ดาวน์โหลดไบต์ของภาพดิบ.
    with urlopen("[REPLACE WITH URL]") as response:
        image_data = response.read()

    image = presentation.images.add_image(image_data)
    slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 10, 10, 100, 100, image)

    presentation.save("presentation.pptx", slides.export.SaveFormat.PPTX)
```

## **เพิ่มภาพลงใน Slide Master**

Slide Master คือสไลด์ระดับบนสุดที่เก็บและควบคุมข้อมูล เช่น ธีม, รูปแบบ ฯลฯ สำหรับสไลด์ทั้งหมดที่อยู่ใต้มัน เมื่อคุณเพิ่มภาพลงใน Slide Master ภาพนั้นจะปรากฏบนทุกสไลด์ที่ใช้มาสเตอร์นั้น.

ตัวอย่าง Python ด้านล่างแสดงวิธีการเพิ่มภาพลงใน Slide Master:

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

## **เพิ่มภาพเป็นพื้นหลังสไลด์**

คุณสามารถใช้รูปภาพเป็นพื้นหลังสำหรับหนึ่งหรือหลายสไลด์ สำหรับรายละเอียดดู *[ตั้งค่าภาพเป็นพื้นหลังสำหรับสไลด์](/slides/th/python-net/presentation-background/#setting-images-as-background-for-slides)*.

## **เพิ่ม SVG ลงในงานนำเสนอ**

เนื้อหา SVG สามารถเพิ่มลงในงานนำเสนอได้โดยใช้คลาส [SvgImage](https://reference.aspose.com/slides/th/python-net/aspose.slides/svgimage/) ภาพ SVG ที่ได้สามารถเพิ่มลงในคอลเลกชันภาพของงานนำเสนอและใช้สร้างเฟรมรูปภาพได้.

ตัวอย่าง Python ด้านล่างนำเข้า SVG string ที่เป็นอิสระทั้งหมด ภาพ, สไตล์ และทรัพยากรอื่น ๆ ที่ใช้โดย SVG นี้ถูกฝังโดยตรงในเนื้อหา SVG.

```py
import aspose.slides as slides

svg_content = """
<svg xmlns='http://www.w3.org/2000/svg' width='320' height='180'>
    <rect width='320' height='180' fill='#4F81BD'/>
    <circle cx='160' cy='90' r='55' fill='#F2F2F2'/>
</svg>
"""

with slides.Presentation() as presentation:
    svg_image = slides.SvgImage(svg_content)
    image = presentation.images.add_image(svg_image)

    presentation.slides[0].shapes.add_picture_frame(
        slides.ShapeType.RECTANGLE, 20, 20, image.width, image.height, image
    )

    presentation.save("self-contained-svg.pptx", slides.export.SaveFormat.PPTX)
```

## **แปลง SVG เป็นชุดของรูปร่าง**

Aspose.Slides แปลง SVG เป็นชุดของรูปร่างในลักษณะคล้ายกับการจัดการ SVG ของ PowerPoint.

![เมนูป๊อปอัปของ PowerPoint](img_01_01.png)

ฟังก์ชันนี้ให้โดยการ overload ของเมธอด [add_group_shape](https://reference.aspose.com/slides/th/python-net/aspose.slides/shapecollection/add_group_shape/) ในคลาส [ShapeCollection](https://reference.aspose.com/slides/th/python-net/aspose.slides/shapecollection/) ที่รับ [SvgImage](https://reference.aspose.com/slides/th/python-net/aspose.slides/svgimage/) เป็นอาร์กิวเมนต์แรก.

โค้ดตัวอย่างด้านล่างแสดงวิธีการแปลงไฟล์ SVG เป็นชุดของรูปร่าง.

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

        # แปลงภาพ SVG เป็นกลุ่มรูปทรงและปรับขนาดให้พอดีกับสไลด์.
        presentation.slides[0].shapes.add_group_shape(svg_image, 0, 0, slide_size.width, slide_size.height)

        # บันทึกการนำเสนอในรูปแบบ PPTX.
        presentation.save("shapes_from_SVG.pptx", slides.export.SaveFormat.PPTX)
```

## **เพิ่มภาพเป็น EMF ลงในสไลด์**

Aspose.Slides สำหรับ Python ให้คุณแทรกภาพ Enhanced Metafile (EMF) ลงในงานนำเสนอได้.

ตัวอย่าง Python ด้านล่างแสดงวิธีนี้:

```py 
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    with open("image.emf", "rb") as image_stream:
        emf_image = presentation.images.add_image(image_stream)
        slide_size = presentation.slide_size.size
        slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 0, 0, slide_size.width, slide_size.height, emf_image)
    
    presentation.save("presentation_with_EMM.pptx", slides.export.SaveFormat.PPTX)
```

## **แทนที่ภาพในคอลเลกชันภาพ**

Aspose.Slides ให้คุณแทนที่ภาพที่เก็บอยู่ในคอลเลกชันภาพของการนำเสนอ รวมถึงภาพที่ใช้โดยรูปร่างของสไลด์ ส่วนนี้อธิบายวิธีการหลายวิธีในการอัปเดตภาพในคอลเลกชัน API มีเมธอดง่าย ๆ เพื่อแทนที่ภาพด้วยข้อมูลไบต์ดิบ, อินสแตนซ์ของ [IImage](https://reference.aspose.com/slides/th/python-net/aspose.slides/iimage/), หรือภาพอื่นที่มีอยู่แล้วในคอลเลกชัน.

ทำตามขั้นตอนต่อไปนี้:

1. โหลดงานนำเสนอที่มีภาพโดยใช้คลาส [Presentation](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/).
1. โหลดภาพใหม่จากไฟล์ลงในอาร์เรย์ไบต์.
1. แทนที่ภาพเป้าหมายด้วยภาพใหม่โดยใช้อาร์เรย์ไบต์.
1. หรืออีกทางเลือกหนึ่ง โหลดภาพเป็นอ็อบเจ็กต์ของ [IImage](https://reference.aspose.com/slides/th/python-net/aspose.slides/iimage/) แล้วแทนที่ภาพเป้าหมายด้วยอ็อบเจ็กต์นั้น.
1. หรือแทนที่ภาพเป้าหมายด้วยภาพที่มีอยู่แล้วในคอลเลกชันภาพของการนำเสนอ.
1. บันทึกการนำเสนอที่แก้ไขเป็นไฟล์ PPTX.

```py
import aspose.slides as slides

def read_all_bytes(file_name):
    with open(file_name, "rb") as stream:
        return stream.read()


# สร้างอินสแตนซ์ของคลาส Presentation ที่แสดงถึงไฟล์งานนำเสนอ.
with slides.Presentation("sample.pptx") as presentation:

    # วิธีแรก.
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

    # บันทึกงานนำเสนอลงไฟล์.
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert title="Info" color="info" %}}
ด้วยตัวแปลง [Text to GIF](https://products.aspose.app/slides/th/text-to-gif) ฟรีของ Aspose คุณสามารถทำเอฟเฟกต์เคลื่อนไหวให้กับข้อความและสร้าง GIF จากข้อความได้อย่างง่ายดาย.
{{% /alert %}}

## **คำถามที่พบบ่อย**

**ความละเอียดของภาพต้นฉบับยังคงอยู่เต็มที่หลังจากแทรกหรือไม่?**

ใช่ พิกเซลต้นฉบับจะถูกเก็บไว้ แต่ลักษณะสุดท้ายขึ้นอยู่กับวิธีการที่ [picture](/slides/th/python-net/picture-frame/) ถูกสเกลบนสไลด์และการบีบอัดใด ๆ ที่ทำเมื่อลงบันทึก.

**วิธีที่ดีที่สุดในการแทนที่โลโก้เดียวกันบนหลายสิบสไลด์พร้อมกันคืออะไร?**

วางโลโก้บน master slide หรือ layout แล้วแทนที่ในคอลเลกชันภาพของการนำเสนอ—การอัปเดตจะกระจายไปยังองค์ประกอบทั้งหมดที่ใช้ทรัพยากรนั้น.

**สามารถแปลง SVG ที่แทรกเข้ามาเป็นรูปร่างที่แก้ไขได้หรือไม่?**

ได้ คุณสามารถแปลง SVG เป็นกลุ่มของรูปร่าง หลังจากนั้นส่วนต่าง ๆ จะสามารถแก้ไขได้ด้วยคุณสมบัติจัดรูปแบบมาตรฐาน.

**ฉันจะตั้งค่าภาพเป็นพื้นหลังสำหรับหลายสไลด์พร้อมกันอย่างไร?**

ให้ [กำหนดภาพเป็นพื้นหลัง](/slides/th/python-net/presentation-background/) บน master slide หรือ layout ที่เกี่ยวข้อง—สไลด์ใด ๆ ที่ใช้ master/layout นั้นจะได้รับพื้นหลังเดียวกัน.

**ฉันจะป้องกันไม่ให้การนำเสนอใหญ่เกินไปเนื่องจากมีรูปภาพมากมายได้อย่างไร?**

ใช้ทรัพยากรภาพเดียวซ้ำแทนการทำสำเนาหลาย ๆ ครั้ง เลือกความละเอียดที่เหมาะสม ใช้การบีบอัดเมื่อลงบันทึก และเก็บกราฟิกที่ซ้ำกันไว้บน master หากเหมาะสม.