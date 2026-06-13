---
title: แปลง PPT, PPTX, และ ODP เป็น JPG ใน Python
linktitle: แปลงสไลด์เป็นภาพ JPG
type: docs
weight: 60
url: /th/python-net/convert-powerpoint-to-jpg/
keywords:
- แปลง PowerPoint เป็น JPG
- แปลงงานนำเสนอเป็น JPG
- แปลงสไลด์เป็น JPG
- แปลง PPT เป็น JPG
- แปลง PPTX เป็น JPG
- แปลง ODP เป็น JPG
- PowerPoint เป็น JPG
- งานนำเสนอเป็น JPG
- สไลด์เป็น JPG
- PPT เป็น JPG
- PPTX เป็น JPG
- ODP เป็น JPG
- แปลง PowerPoint เป็น JPEG
- แปลงงานนำเสนอเป็น JPEG
- แปลงสไลด์เป็น JPEG
- แปลง PPT เป็น JPEG
- แปลง PPTX เป็น JPEG
- แปลง ODP เป็น JPEG
- PowerPoint เป็น JPEG
- งานนำเสนอเป็น JPEG
- สไลด์เป็น JPEG
- PPT เป็น JPEG
- PPTX เป็น JPEG
- ODP เป็น JPEG
- Python
- Aspose.Slides
description: "เรียนรู้วิธีแปลงสไลด์ของคุณจากการนำเสนอ PowerPoint และ OpenDocument ให้เป็นภาพ JPEG คุณภาพสูงด้วยโค้ดเพียงไม่กี่บรรทัดใน Python ปรับแต่งงานนำเสนอสำหรับการใช้งานบนเว็บ การแชร์และการเก็บถาวร อ่านคู่มือเต็มได้ทันที!"
---
## **บทนำ**

การแปลงงานนำเสนอ PowerPoint และ OpenDocument เป็นภาพ JPG ช่วยในเรื่องการแชร์สไลด์, ปรับประสิทธิภาพ, และฝังเนื้อหาเข้าในเว็บไซต์หรือแอปพลิเคชัน Aspose.Slides for Python ช่วยให้คุณแปลงไฟล์ PPTX, PPT, และ ODP เป็นภาพ JPEG คุณภาพสูง คู่มือนี้อธิบายวิธีต่าง ๆ สำหรับการแปลง

ด้วยคุณลักษณะเหล่านี้ คุณสามารถสร้างตัวดูงานนำเสนอของคุณเองและสร้างภาพย่อสำหรับแต่ละสไลด์ได้ง่ายต่อการใช้งาน ซึ่งอาจเป็นประโยชน์หากคุณต้องการปกป้องสไลด์จากการคัดลอกหรือแสดงงานนำเสนอในโหมดอ่านอย่างเดียว Aspose.Slides อนุญาตให้คุณแปลงงานนำเสนอทั้งหมดหรือสไลด์เฉพาะเป็นรูปแบบภาพ

## **แปลงสไลด์งานนำเสนอเป็นภาพ JPG**

ต่อไปนี้เป็นขั้นตอนในการแปลงไฟล์ PPT, PPTX หรือ ODP เป็น JPG:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/) .
2. ดึงอ็อบเจกต์สไลด์ของประเภท [Slide](https://reference.aspose.com/slides/th/python-net/aspose.slides/slide/) จากคอลเลกชัน [Presentation.slides](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/slides/th/) .
3. สร้างภาพของสไลด์โดยใช้เมธอด [Slide.get_image(scale_x, scale_y)](https://reference.aspose.com/slides/th/python-net/aspose.slides/slide/get_image/#float-float) .
4. เรียกเมธอด [IImage.save(filename, format)](https://reference.aspose.com/slides/th/python-net/aspose.slides/iimage/save/#str-imageformat) บนวัตถุภาพ ส่งชื่อไฟล์ผลลัพธ์และรูปแบบภาพเป็นอาร์กิวเมนต์

{{% alert color="primary" %}}

**หมายเหตุ:** การแปลง PPT, PPTX หรือ ODP เป็น JPG แตกต่างจากการแปลงไปยังรูปแบบอื่นใน Aspose.Slides Python API สำหรับรูปแบบอื่นโดยทั่วไปคุณจะใช้เมธอด [Presentation.save(fname, format, options)](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/save/#str-asposeslidesexportsaveformat-asposeslidesexportisaveoptions) อย่างไรก็ตามสำหรับการแปลงเป็น JPG คุณต้องใช้เมธอด [IImage.save(filename, format)](https://reference.aspose.com/slides/th/python-net/aspose.slides/iimage/save/#str-imageformat) .

{{% /alert %}}

```py
import aspose.slides as slides

scale_x = 1
scale_y = scale_x

with slides.Presentation("PowerPoint_Presentation.ppt") as presentation:
    for slide in presentation.slides:
        with slide.get_image(scale_x, scale_y) as thumbnail:
            # บันทึกภาพลงดิสก์ในรูปแบบ JPEG.
            file_name = f"Slide_{slide.slide_number}.jpg"
            thumbnail.save(file_name, slides.ImageFormat.JPEG)
```

## **แปลงสไลด์เป็น JPG ด้วยขนาดที่กำหนดเอง**

เพื่อเปลี่ยนขนาดของภาพ JPG ที่สร้างขึ้น คุณสามารถกำหนดขนาดภาพโดยส่งค่าเข้าเมธอด [Slide.get_image(image_size)](https://reference.aspose.com/slides/th/python-net/aspose.slides/slide/get_image/#asposepydrawingsize) วิธีนี้ช่วยให้คุณสร้างภาพที่มีความกว้างและความสูงตามที่ต้องการ เพื่อให้ผลลัพธ์ตรงตามความต้องการเรื่องความละเอียดและอัตราส่วนภาพ ความยืดหยุ่นนี้มีประโยชน์อย่างยิ่งเมื่อต้องสร้างภาพสำหรับเว็บแอปพลิเคชัน รายงาน หรือเอกสารที่ต้องการขนาดภาพที่แม่นยำ

```py
import aspose.slides as slides
import aspose.pydrawing as pydrawing

image_size = pydrawing.Size(1200, 800)

with slides.Presentation("PowerPoint_Presentation.pptx") as presentation:
    for slide in presentation.slides:
        # สร้างภาพสไลด์ขนาดที่กำหนด.
        with slide.get_image(image_size) as thumbnail:
            # บันทึกภาพลงดิสก์ในรูปแบบ JPEG.
            file_name = f"Slide_{slide.slide_number}.jpg"
            thumbnail.save(file_name, slides.ImageFormat.JPEG)
```

## **แสดงคอมเมนต์เมื่อบันทึกสไลด์เป็นภาพ**

Aspose.Slides for Python มีฟีเจอร์ที่ช่วยให้คุณสามารถแสดงคอมเมนต์บนสไลด์ของงานนำเสนอเมื่อแปลงเป็นภาพ JPG ฟังก์ชันนี้มีประโยชน์เป็นพิเศษสำหรับการเก็บรักษาโน้ต, ความเห็น, หรือการสนทนาที่ผู้ร่วมงานเพิ่มใน PowerPoint โดยการเปิดใช้งานตัวเลือกนี้ คุณจะมั่นใจว่าคอมเมนต์แสดงในภาพที่สร้างขึ้น ทำให้การตรวจสอบและแชร์ความเห็นง่ายขึ้นโดยไม่ต้องเปิดไฟล์งานนำเสนอเดิม

สมมติว่าเรามีไฟล์งานนำเสนอ "sample.pptx" ที่มีสไลด์ที่มีคอมเมนต์:

![สไลด์ที่มีคอมเมนต์](slide_with_comments.png)

โค้ด Python ด้านล่างแปลงสไลด์เป็นภาพ JPG พร้อมคงคอมเมนต์ไว้:

```py
import aspose.slides as slides
import aspose.pydrawing as pydrawing

scale_x = 1
scale_y = scale_x

with slides.Presentation("sample.pptx") as presentation:
    # ตั้งค่าตัวเลือกสำหรับคอมเมนต์ของสไลด์.
    comments_options = slides.export.NotesCommentsLayoutingOptions()
    comments_options.comments_position = slides.export.CommentsPositions.RIGHT
    comments_options.comments_area_width = 200
    comments_options.comments_area_color = pydrawing.Color.dark_orange

    options = slides.export.RenderingOptions()
    options.slides_layout_options = comments_options

    # แปลงสไลด์แรกเป็นภาพ.
    with presentation.slides[0].get_image(options, scale_x, scale_y) as thumbnail:
        thumbnail.save("Slide_1.jpg", slides.ImageFormat.JPEG)
```

ผลลัพธ์:

![ภาพ JPG ที่มีคอมเมนต์](image_with_comments.png)

## **ดูเพิ่มเติม**

ดูตัวเลือกอื่น ๆ สำหรับการแปลง PPT, PPTX หรือ ODP เป็นภาพ เช่น:

- [แปลง PowerPoint เป็น GIF](/slides/th/python-net/convert-powerpoint-to-animated-gif/)
- [แปลง PowerPoint เป็น PNG](/slides/th/python-net/convert-powerpoint-to-png/)
- [แปลง PowerPoint เป็น TIFF](/slides/th/python-net/convert-powerpoint-to-tiff/)
- [แปลง PowerPoint เป็น SVG](/slides/th/python-net/render-a-slide-as-an-svg-image/)

{{% alert color="primary" %}} 

เพื่อดูว่า Aspose.Slides แปลง PowerPoint เป็นภาพ JPG อย่างไร ลองใช้ตัวแปลงออนไลน์ฟรีเหล่านี้: PowerPoint [PPTX to JPG](https://products.aspose.app/slides/th/conversion/pptx-to-jpg) และ [PPT to JPG](https://products.aspose.app/slides/th/conversion/ppt-to-jpg). 

{{% /alert %}} 

![ตัวแปลงออนไลน์ฟรี PPTX เป็น JPG](ppt-to-jpg.png)

{{% alert title="Tip" color="primary" %}}

Aspose มีแอปเว็บ [Collage ฟรี](https://products.aspose.app/slides/th/collage) ให้บริการออนไลน์ คุณสามารถรวม [JPG to JPG](https://products.aspose.app/slides/th/collage/jpg) หรือ PNG to PNG, สร้าง [photo grids](https://products.aspose.app/slides/th/collage/photo-grid) ฯลฯ

โดยใช้หลักการเดียวกันที่อธิบายไว้ในบทความนี้ คุณสามารถแปลงภาพจากรูปแบบหนึ่งเป็นอีกรูปแบบหนึ่ง สำหรับข้อมูลเพิ่มเติม ดูหน้าต่อไปนี้: แปลง [ภาพเป็น JPG](https://products.aspose.com/slides/th/python-net/conversion/image-to-jpg/); แปลง [JPG เป็นภาพ](https://products.aspose.com/slides/th/python-net/conversion/jpg-to-image/); แปลง [JPG เป็น PNG](https://products.aspose.com/slides/th/python-net/conversion/jpg-to-png/), แปลง [PNG เป็น JPG](https://products.aspose.com/slides/th/python-net/conversion/png-to-jpg/); แปลง [PNG เป็น SVG](https://products.aspose.com/slides/th/python-net/conversion/png-to-svg/), แปลง [SVG เป็น PNG](https://products.aspose.com/slides/th/python-net/conversion/svg-to-png/).

{{% /alert %}}

## **คำถามที่พบบ่อย**

**วิธีนี้รองรับการแปลงเป็นชุดหรือไม่?**

ใช่, Aspose.Slides รองรับการแปลงหลายสไลด์เป็น JPG ในหนึ่งการดำเนินการ

**การแปลงสนับสนุน SmartArt, แผนภูมิ, และวัตถุซับซ้อนอื่น ๆ หรือไม่?**

ใช่, Aspose.Slides เรนเดอร์เนื้อหาทั้งหมดรวมถึง SmartArt, แผนภูมิ, ตาราง, รูปร่าง และอื่น ๆ อย่างไรก็ตามความแม่นยำของการเรนเดอร์อาจแตกต่างเล็กน้อยเมื่อเทียบกับ PowerPoint โดยเฉพาะเมื่อใช้ฟอนต์ที่กำหนดเองหรือฟอนต์ที่หายไป

**มีข้อจำกัดใด ๆ เกี่ยวกับจำนวนสไลด์ที่สามารถประมวลผลได้หรือไม่?**

Aspose.Slides เองไม่ได้กำหนดขีดจำกัดที่เข้มงวดต่อจำนวนสไลด์ที่คุณสามารถประมวลผลได้ อย่างไรก็ตามคุณอาจเจอข้อผิดพลาด out-of-memory เมื่อทำงานกับงานนำเสนอขนาดใหญ่หรือภาพความละเอียดสูง