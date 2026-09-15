---
title: ดึงพื้นหลังสไลด์ทั้งหมดจากการนำเสนอเป็นภาพ
linktitle: พื้นหลังสไลด์ทั้งหมด
type: docs
weight: 95
url: /th/python-java/get-the-entire-presentation-slide-background-as-an-image/
keywords:
- พื้นหลังสไลด์
- พื้นหลังสุดท้าย
- สกัดพื้นหลัง
- พื้นหลังทั้งหมด
- พื้นหลังเป็นภาพ
- พื้นหลัง PPT
- พื้นหลัง PPTX
- พื้นหลัง ODP
- PowerPoint
- OpenDocument
- presentation
- Python
- Java
- Aspose.Slides
description: "สกัดพื้นหลังสไลด์เต็มเป็นภาพจากการนำเสนอ PowerPoint และ OpenDocument ด้วย Aspose.Slides for Python via Java เพื่อทำให้กระบวนการทำงานด้านภาพเป็นไปอย่างราบรื่น"
---
## **ภาพรวม**

ในการนำเสนอ PowerPoint พื้นหลังสไลด์อาจประกอบด้วยหลายองค์ประกอบ รวมถึงภาพพื้นหลังสไลด์ ธีมการนำเสนอ โครงสี และวัตถุที่วางบนสไลด์แม่หรือสไลด์เค้าโครง

บทความนี้แสดงวิธีสกัดพื้นหลังสไลด์ทั้งหมดเป็นภาพโดยใช้ Aspose.Slides for Python via Java เนื่องจากไม่มีวิธีเดียวสำหรับงานนี้ วิธีการจะทำการโคลนสไลด์ที่เลือกไปยังการนำเสนอชั่วคราว ลบรูปทรงของสไลด์ แล้วแปลงพื้นหลังสไลด์ที่ได้เป็นภาพ

## **รับพื้นหลังสไลด์ทั้งหมด**

Aspose.Slides for Python via Java ไม่ได้ให้วิธีง่าย ๆ ในการสกัดพื้นหลังสไลด์ทั้งหมดของการนำเสนอเป็นภาพ แต่คุณสามารถทำตามขั้นตอนต่อไปนี้ได้:

1. โหลดการนำเสนอโดยใช้คลาส [Presentation](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentation/)
2. รับขนาดสไลด์จากการนำเสนอ
3. เลือกสไลด์
4. สร้างการนำเสนอชั่วคราว
5. กำหนดขนาดสไลด์เดียวกันในการนำเสนอชั่วคราว
6. โคลนสไลด์ที่เลือกไปยังการนำเสนอชั่วคราว
7. ลบรูปทรงจากสไลด์ที่โคลน
8. แปลงสไลด์ที่โคลนเป็นภาพ

ตัวอย่างโค้ดต่อไปนี้สกัดพื้นหลังสไลด์ทั้งหมดของการนำเสนอเป็นภาพ

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SlideSizeScaleType, ImageFormat

slide_index = 0
image_scale = 1.0

presentation = Presentation("sample.pptx")
try:
    slide_size = presentation.getSlideSize().getSize()
    slide = presentation.getSlides().get_Item(slide_index)

    temp_presentation = Presentation()
    try:
        slide_width = jpype.JFloat(slide_size.getWidth())
        slide_height = jpype.JFloat(slide_size.getHeight())
        temp_presentation.getSlideSize().setSize(slide_width, slide_height, SlideSizeScaleType.DoNotScale)

        cloned_slide = temp_presentation.getSlides().addClone(slide)
        cloned_slide.getShapes().clear()

        background = cloned_slide.getImage(image_scale, image_scale)
        try:
            background.save("output.png", ImageFormat.Png)
        finally:
            background.dispose()
    finally:
        temp_presentation.dispose()
finally:
    presentation.dispose()
```

## **คำถามที่พบบ่อย**

**จะมีการรักษา gradient ซับซ้อน, texture, หรือการเติมรูปภาพจากสไลด์แม่ไว้ในภาพพื้นหลังที่ได้หรือไม่?**

ใช่ Aspose.Slides จะเรนเดอร์การเติม gradient, รูปภาพ และ texture ที่กำหนดบนสไลด์, เค้าโครง หรือสไลด์แม่ หากต้องการแยกลักษณะจากสไลด์แม่ที่สืบทอดไว้ ให้ [ตั้งค่าพื้นหลังที่กำหนดเอง](/slides/th/python-java/presentation-background/) บนสไลด์ปัจจุบันก่อนทำการส่งออก

**ฉันสามารถเพิ่มลายน้ำลงในภาพพื้นหลังที่ได้ก่อนบันทึกได้หรือไม่?**

ใช่ คุณสามารถ [เพิ่มลายน้ำ](/slides/th/python-java/watermark/) รูปทรงหรือภาพบน [สำเนาของสไลด์](/slides/th/python-java/clone-slides/) ที่ทำงานอยู่ (วางไว้ด้านหลังเนื้อหาอื่น) แล้วทำการส่งออก วิธีนี้ช่วยให้คุณสร้างภาพพื้นหลังที่มีลายน้ำฝังอยู่แล้ว

**ฉันสามารถรับพื้นหลังสำหรับเค้าโครงหรือสไลด์แม่เฉพาะได้โดยไม่ต้องเชื่อมกับสไลด์ที่มีอยู่หรือไม่?**

ใช่ เข้าถึงสไลด์แม่หรือเค้าโครงที่ต้องการ แล้วนำไปใช้กับ [สไลด์ชั่วคราว](/slides/th/python-java/clone-slides/) ที่มีขนาดตามต้องการ แล้วส่งออกสไลด์นั้นเพื่อรับพื้นหลังที่ได้จากเค้าโครงหรือสไลด์แม่นั้น

**มีข้อจำกัดด้านใบอนุญาตที่มีผลต่อการส่งออกภาพหรือไม่?**

คุณลักษณะการเรนเดอร์สามารถใช้ได้เต็มที่พร้อมกับ [ใบอนุญาตที่ถูกต้อง](/slides/th/python-java/licensing/) ในโหมดประเมินผล ผลลัพธ์อาจมีข้อจำกัดเช่นลายน้ำ เปิดใช้งานใบอนุญาตหนึ่งครั้งต่อกระบวนการก่อนทำการส่งออกเป็นชุด