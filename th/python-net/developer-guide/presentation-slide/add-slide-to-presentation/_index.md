---
title: เพิ่มสไลด์ไปยังงานนำเสนอด้วย Python
linktitle: เพิ่มสไลด์
type: docs
weight: 10
url: /th/python-net/add-slide-to-presentation/
keywords:
- เพิ่มสไลด์
- สร้างสไลด์
- สไลด์เปล่า
- PowerPoint
- OpenDocument
- งานนำเสนอ
- Python
- Aspose.Slides
description: "เพิ่มสไลด์ใน PowerPoint และงานนำเสนอ OpenDocument ของคุณได้อย่างง่ายดายโดยใช้ Aspose.Slides สำหรับ Python ผ่าน .NET—การแทรกสไลด์ที่ราบรื่นและมีประสิทธิภาพในไม่กี่วินาที"
---
## **Overview**

ก่อนเพิ่มสไลด์ลงในงานนำเสนอ ควรเข้าใจก่อนว่า PowerPoint จัดระเบียบสไลด์อย่างไร งานนำเสนอแต่ละรายการจะมีสไลด์มาสเตอร์, สไลด์เค้าโครงที่เป็นตัวเลือก, และสไลด์ปกติหนึ่งหรือหลายสไลด์ ทุกสไลด์มีรหัสที่ไม่ซ้ำกัน และสไลด์ปกติจะถูกจัดลำดับตามดัชนีเริ่มที่ศูนย์ บทความนี้แสดงวิธีการใช้ Aspose.Slides for Python เพื่อสร้างสไลด์และเลือกเค้าโครงที่เหมาะสม

## **Add Slides to Presentations**

Aspose.Slides อนุญาตให้คุณเพิ่มสไลด์ใหม่โดยอิงจากสไลด์เค้าโครงที่มีอยู่ ตัวอย่างด้านล่างจะวนผ่านแต่ละเค้าโครงในงานนำเสนอ เพิ่มสไลด์ที่ใช้เค้าโครงนั้น แล้วบันทึกไฟล์

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/)
2. เข้าถึง [SlideCollection](https://reference.aspose.com/slides/th/python-net/aspose.slides/slidecollection/)
3. สำหรับแต่ละรายการใน `presentation.layout_slides` เรียก `add_empty_slide` เพื่อเพิ่มสไลด์ที่ใช้เค้าโครงนั้น
4. ปรับแก้สไลด์ที่เพิ่มใหม่ตามต้องการ
5. บันทึกงานนำเสนอเป็นไฟล์ PPTX

```py
import aspose.slides as slides

# สร้างอินสแตนซ์ของคลาส Presentation.
with slides.Presentation() as presentation:
    # เข้าถึงคอลเลกชันสไลด์.
    slides = presentation.slides

    for layout_slide in presentation.layout_slides:
        # เพิ่มสไลด์เปล่าลงในคอลเลกชันสไลด์.
        slides.add_empty_slide(layout_slide)

    # ทำงานบางอย่างบนสไลด์ที่เพิ่มใหม่.

    # บันทึกงานนำเสนอลงดิสก์.
    presentation.save("empty_slides.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Can I insert a new slide at a specific position, not just at the end?**

ใช่ ไลบรารีรองรับการทำงานกับคอลเลกชันสไลด์และการ [insert](https://reference.aspose.com/slides/th/python-net/aspose.slides/slidecollection/insert_empty_slide/)/[clone](https://reference.aspose.com/slides/th/python-net/aspose.slides/slidecollection/insert_clone/) ดังนั้นคุณสามารถเพิ่มสไลด์ที่ดัชนีที่ต้องการได้ ไม่จำกัดเฉพาะที่ส่วนท้าย

**Are the theme/styles preserved when adding a slide based on a layout?**

ใช่ เค้าโครงจะสืบทอดรูปแบบจากมาสเตอร์ของมัน และสไลด์ใหม่จะสืบทอดจากเค้าโครงที่เลือกและมาสเตอร์ที่เชื่อมโยงกับมัน

**Which slide is present in a new "empty" presentation before adding slides?**

งานนำเสนอที่สร้างใหม่จะมีสไลด์เปล่าหนึ่งสไลด์ที่มีดัชนีศูนย์อยู่แล้ว สิ่งนี้สำคัญเมื่อคำนวณตำแหน่งการแทรก

**How do I choose the "right" layout for a new slide if the master has many options?**

โดยทั่วไปเลือก [LayoutSlide](https://reference.aspose.com/slides/th/python-net/aspose.slides/layoutslide/) ที่ตรงกับโครงสร้างที่ต้องการ ([Title and Content, Two Content, etc.](https://reference.aspose.com/slides/th/python-net/aspose.slides/slidelayouttype/)) หากไม่มีเค้าโครงดังกล่าว คุณสามารถ [เพิ่มลงในมาสเตอร์](/slides/th/python-net/slide-layout/) แล้วใช้งานได้