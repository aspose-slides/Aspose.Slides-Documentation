---
title: ปรับขนาดรูปร่างในงานนำเสนอด้วย Python
linktitle: การปรับขนาดรูปร่าง
type: docs
weight: 130
url: /th/python-net/re-sizing-shapes-on-slide/
keywords:
- ปรับขนาดรูปร่าง
- เปลี่ยนขนาดรูปร่าง
- PowerPoint
- OpenDocument
- งานนำเสนอ
- Python
- Aspose.Slides
description: "ปรับขนาดรูปร่างบนสไลด์ PowerPoint และ OpenDocument อย่างง่ายดายด้วย Aspose.Slides for Python ผ่าน .NET—อัตโนมัติการปรับเลย์เอาต์สไลด์และเพิ่มประสิทธิภาพการทำงาน."
---
## **ภาพรวม**

หนึ่งในคำถามที่พบบ่อยที่สุดจากลูกค้า Aspose.Slides for Python คือวิธีการปรับขนาดรูปร่าง เพื่อให้เมื่ขนาดสไลด์เปลี่ยนแปลง ข้อมูลจะไม่ถูกตัดออก บทความเทคนิคสั้น ๆ นี้จะแสดงวิธีทำเช่นนั้น

## **ปรับขนาดรูปร่าง**

เพื่อป้องกันไม่ให้รูปร่างเบี่ยงเบนเมื่อขนาดสไลด์เปลี่ยนแปลง ให้ปรับตำแหน่งและมิติสของแต่ละรูปร่างให้สอดคล้องกับการจัดวางสไลด์ใหม่

```py
import aspose.slides as slides

# โหลดไฟล์งานนำเสนอ.
with slides.Presentation("sample.pptx") as presentation:
    # รับขนาดสไลด์เดิม.
    current_height = presentation.slide_size.size.height
    current_width = presentation.slide_size.size.width

    # เปลี่ยนขนาดสไลด์โดยไม่สเกลรูปร่างที่มีอยู่.
    presentation.slide_size.set_size(slides.SlideSizeType.A4_PAPER, slides.SlideSizeScaleType.DO_NOT_SCALE)

    # รับขนาดสไลด์ใหม่.
    new_height = presentation.slide_size.size.height
    new_width = presentation.slide_size.size.width

    height_ratio = new_height / current_height
    width_ratio = new_width / current_width

    # ปรับขนาดและตำแหน่งรูปร่างในทุกสไลด์.
    for slide in presentation.slides:
        for shape in slide.shapes:
            # สเกลขนาดรูปร่าง.
            shape.height = shape.height * height_ratio
            shape.width = shape.width * width_ratio

            # สเกลตำแหน่งรูปร่าง.
            shape.y = shape.y * height_ratio
            shape.x = shape.x * width_ratio

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert color="primary" %}} 
หากสไลด์มีตาราง โค้ดด้านบนจะทำงานไม่ถูกต้อง ในกรณีนั้นต้องปรับขนาดเซลล์แต่ละเซลล์ในตาราง
{{% /alert %}} 

ใช้โค้ดต่อไปนี้ในฝั่งของคุณเพื่อปรับขนาดสไลด์ที่มีตาราง สำหรับตาราง การตั้งค่าความกว้างหรือความสูงเป็นกรณีพิเศษ: คุณต้องปรับความสูงของแถวและความกว้างของคอลัมน์แต่ละอันเพื่อเปลี่ยนขนาดโดยรวมของตาราง

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    # รับขนาดสไลด์เดิม.
    current_height = presentation.slide_size.size.height
    current_width = presentation.slide_size.size.width

    # เปลี่ยนขนาดสไลด์โดยไม่สเกลรูปร่างที่มีอยู่.
    presentation.slide_size.set_size(slides.SlideSizeType.A4_PAPER, slides.SlideSizeScaleType.DO_NOT_SCALE)

    # รับขนาดสไลด์ใหม่.
    new_height = presentation.slide_size.size.height
    new_width = presentation.slide_size.size.width

    height_ratio = new_height / current_height
    width_ratio = new_width / current_width

    for master in presentation.masters:
        for shape in master.shapes:
            # สเกลขนาดรูปร่าง.
            shape.height = shape.height * height_ratio
            shape.width = shape.width * width_ratio

            # สเกลตำแหน่งรูปร่าง.
            shape.y = shape.y * height_ratio
            shape.x = shape.x * width_ratio

        for layout_slide in master.layout_slides:
            for shape in layout_slide.shapes:
                # สเกลขนาดรูปร่าง.
                shape.height = shape.height * height_ratio
                shape.width = shape.width * width_ratio

                # สเกลตำแหน่งรูปร่าง.
                shape.y = shape.y * height_ratio
                shape.x = shape.x * width_ratio

    for slide in presentation.slides:
        for shape in slide.shapes:
            # สเกลขนาดรูปร่าง.
            shape.height = shape.height * height_ratio
            shape.width = shape.width * width_ratio

            # สเกลตำแหน่งรูปร่าง.
            shape.y = shape.y * height_ratio
            shape.x = shape.x * width_ratio

            if type(shape) is slides.Table:
                for row in shape.rows:
                    row.minimal_height = row.minimal_height * height_ratio
                for column in shape.columns:
                    column.width = column.width * width_ratio

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **คำถามที่พบบ่อย**

**ทำไมรูปร่างจึงบิดเบี้ยวหรือถูกตัดออกหลังจากปรับขนาดสไลด์?**

เมื่อปรับขนาดสไลด์ รูปร่างจะรักษาตำแหน่งและขนาดเดิมไว้ เว้นแต่จะมีการเปลี่ยนสเกลโดยเจตนา สิ่งนี้อาจทำให้เนื้อหาถูกตัดหรือรูปร่างเบี่ยงเบน

**โค้ดที่ให้มาทำงานกับรูปแบบรูปร่างทั้งหมดหรือไม่?**

ตัวอย่างพื้นฐานทำงานกับรูปแบบรูปร่างส่วนใหญ่ (กล่องข้อความ, รูปภาพ, แผนภูมิ ฯลฯ) อย่างไรก็ตาม สำหรับตาราง คุณต้องจัดการแถวและคอลัมน์แยกกัน เพราะความสูงและความกว้างของตารางกำหนดโดยมิติของเซลล์แต่ละเซลล์

**ฉันจะปรับขนาดตารางเมื่อปรับขนาดสไลด์อย่างไร?**

คุณต้องวนลูปผ่านทุกแถวและคอลัมน์ของตารางและปรับความสูงและความกว้างของพวกมันอย่างสัดส่วน ตามที่แสดงในตัวอย่างโค้ดที่สอง

**การปรับขนาดนี้จะทำงานกับสไลด์มาสเตอร์และสไลด์เลย์เอาต์หรือไม่?**

ใช่ แต่คุณควรวนลูปผ่าน [Masters](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/masters/) และ [Layout slides](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/layout_slides/) แล้วใช้ตรรกะการสเกลเดียวกันกับรูปร่างของพวกมันเพื่อให้การนำเสนอทั้งหมดสอดคล้องกัน

**ฉันสามารถเปลี่ยนทิศทางของสไลด์ (แนวตั้ง/แนวนอน) พร้อมกับการปรับขนาดได้หรือไม่?**

ได้ คุณสามารถใช้ [presentation.slide_size.orientation](https://reference.aspose.com/slides/th/python-net/aspose.slides/islidesize/orientation/) เพื่อเปลี่ยนทิศทาง อย่าลืมตั้งตรรกะการสเกลให้สอดคล้องเพื่อคงการจัดวางเดิม

**มีขีดจำกัดขนาดสไลด์ที่ฉันสามารถตั้งค่าได้หรือไม่?**

Aspose.Slides รองรับขนาดที่กำหนดเอง แต่ขนาดที่ใหญ่มากอาจส่งผลต่อประสิทธิภาพหรือความเข้ากันได้กับเวอร์ชันบางรุ่นของ PowerPoint

**ฉันจะป้องกันไม่ให้รูปร่างที่มีอัตราส่วนคงที่บิดเบี้ยวได้อย่างไร?**

คุณสามารถตรวจสอบคุณสมบัติ `aspect_ratio_locked` ของรูปร่างก่อนทำการสเกล หากมันถูกล็อก ให้ปรับความกว้างหรือความสูงโดยสัดส่วนแทนการสเกลแยกกัน