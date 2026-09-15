---
title: การทำงานหลายเธรดใน Aspose.Slides สำหรับ Python ผ่าน Java
linktitle: การทำงานหลายเธรด
type: docs
weight: 310
url: /th/python-java/multithreading/
keywords:
- การทำงานหลายเธรด
- หลายเธรด
- งานขนาน
- แปลงสไลด์
- สไลด์เป็นรูปภาพ
- PowerPoint
- OpenDocument
- การนำเสนอ
- Python
- Java
- Aspose.Slides
description: "การทำงานหลายเธรดใน Aspose.Slides สำหรับ Python ผ่าน Java ช่วยเพิ่มประสิทธิภาพการประมวลผล PowerPoint และ OpenDocument. ค้นหาวิธีปฏิบัติที่ดีที่สุดสำหรับกระบวนการทำงานการนำเสนอที่มีประสิทธิภาพ."
---
## **บทนำ**

แม้ว่าการทำงานขนานกับการนำเสนอจะเป็นไปได้ (ยกเว้นการแยกวิเคราะห์ โหลด และคล cloning) และโดยทั่วไปทำงานได้ดี แต่ก็ยังมีโอกาสผลลัพธ์ไม่ถูกต้องเล็กน้อยเมื่อคุณใช้ไลบรารีในหลายเธรด

เราขอแนะนำอย่างยิ่งให้คุณ **ไม่** ใช้ตัวอย่าง [Presentation](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentation/) เพียงตัวเดียวในสภาพแวดล้อมหลายเธรด เพราะอาจทำให้เกิดข้อผิดพลาดหรือความล้มเหลวที่คาดเดาไม่ได้และตรวจจับได้ยาก

เป็น **ไม่** ปลอดภัยที่จะโหลด บันทึก และ/หรือคล cloning ตัวอย่าง [Presentation](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentation/) ในหลายเธรด การดำเนินการดังกล่าว **ไม่** ได้รับการสนับสนุน หากคุณต้องการทำงานเหล่านี้ คุณต้องขนานการทำงานโดยใช้หลายกระบวนการแบบสิงเกิ้ลเธรดและแต่ละกระบวนการควรใช้อินสแตนซ์การนำเสนอของตนเอง

## **แปลงสไลด์การนำเสนอเป็นรูปภาพแบบขนาน**

สมมติว่าเราต้องการแปลงสไลด์ทั้งหมดจากไฟล์ PowerPoint เป็นรูปภาพ PNG แบบขนาน เนื่องจากการใช้ตัวอย่าง [Presentation](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentation/) เพียงตัวเดียวในหลายเธรดนั้นไม่ปลอดภัย เราจึงแยกสไลด์การนำเสนอออกเป็นการนำเสนอหลายชุดและแปลงสไลด์เป็นรูปภาพแบบขนาน โดยใช้การนำเสนอแต่ละชุดในเธรดแยกต่างหาก ตัวอย่างโค้ดต่อไปนี้แสดงวิธีทำเช่นนั้น

```python
from concurrent.futures import ThreadPoolExecutor

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation, SlideSizeScaleType


input_file_path = "sample.pptx"
output_file_path_template = "slide_{}.png"
image_scale = 2.0


def convert_slide_to_image(slide_presentation, slide_number):
    try:
        slide = slide_presentation.getSlides().get_Item(0)
        image = slide.getImage(image_scale, image_scale)
        try:
            image_file_path = output_file_path_template.format(slide_number)
            image.save(image_file_path, ImageFormat.Png)
        finally:
            image.dispose()
    finally:
        slide_presentation.dispose()


presentation = Presentation(input_file_path)
try:
    slide_count = presentation.getSlides().size()
    slide_size = presentation.getSlideSize().getSize()
    slide_width = jpype.JFloat(slide_size.getWidth())
    slide_height = jpype.JFloat(slide_size.getHeight())

    with ThreadPoolExecutor() as executor:
        conversion_tasks = []
        for slide_index in range(slide_count):
            # แยกสไลด์ไปเป็นการนำเสนอแยก
            slide_presentation = Presentation()
            slide_presentation.getSlideSize().setSize(slide_width, slide_height, SlideSizeScaleType.DoNotScale)
            slide_presentation.getSlides().removeAt(0)
            slide_presentation.getSlides().addClone(presentation.getSlides().get_Item(slide_index))

            # แปลงสไลด์เป็นภาพในงานแยก
            slide_number = slide_index + 1
            conversion_task = executor.submit(convert_slide_to_image, slide_presentation, slide_number)
            conversion_tasks.append(conversion_task)

        # รอให้ทุกงานเสร็จสมบูรณ์
        for conversion_task in conversion_tasks:
            conversion_task.result()
finally:
    presentation.dispose()
```

## **คำถามที่พบบ่อย**

**ฉันต้องเรียกตั้งค่าลิขสิทธิ์ในทุกเธรดหรือไม่?**

ไม่จำเป็น เพียงทำครั้งเดียวต่อกระบวนการก่อนที่เธรดจะเริ่มทำงาน หากการตั้งค่าลิขสิทธิ์ ([license setup](/slides/th/python-java/licensing/)) อาจถูกเรียกพร้อมกัน (เช่น ในระหว่างการเริ่มต้นแบบ lazy) ให้ทำการซิงโครไนซ์การเรียกนั้น เนื่องจากเมธอดการตั้งค่าลิขสิทธิ์เองไม่เป็น thread‑safe

**ฉันสามารถส่งวัตถุ [Presentation](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentation/) หรือ [Slide](https://reference.aspose.com/slides/th/python-java/aspose.slides/slide/) ระหว่างเธรดได้หรือไม่?**

ไม่แนะนำให้ส่งวัตถุการนำเสนอ “สด” ระหว่างเธรด: ควรใช้อินสแตนซ์อิสระต่อเธรดหรือสร้างการนำเสนอหรือคอนเทนเนอร์สไลด์แยกสำหรับแต่ละเธรดล่วงหน้า วิธีนี้สอดคล้องกับคำแนะนำทั่วไปที่ไม่ควรแชร์อินสแตนซ์การนำเสนอเดียวกันข้ามเธรด

**การส่งออกไปยังรูปแบบต่าง ๆ (PDF, HTML, images) แบบขนานปลอดภัยหรือไม่ หากแต่ละเธรดมีอินสแตนซ์ [Presentation](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentation/) ของตนเอง?**

ใช่ เมื่อใช้อินสแตนซ์อิสระและเส้นทางผลลัพธ์แยกกัน งานเหล่านี้มักจะทำขนานได้อย่างถูกต้อง; เพียงหลีกเลี่ยงการแชร์วัตถุการนำเสนอและสตรีม I/O ร่วมกัน

**ฉันควรทำอย่างไรกับการตั้งค่าแบบอักษรระดับโลก (โฟลเดอร์, การทดแทน) ในการทำงานหลายเธรด?**

ให้เริ่มต้นการตั้งค่าแบบอักษรระดับโลกทั้งหมด ([font settings](/slides/th/python-java/powerpoint-fonts/)) ก่อนที่จะสตาร์ทเธรดและห้ามเปลี่ยนแปลงระหว่างการทำงานแบบขนาน การทำเช่นนี้จะขจัดการแข่งขันเมื่อเข้าถึงทรัพยากรแบบอักษรร่วมกัน