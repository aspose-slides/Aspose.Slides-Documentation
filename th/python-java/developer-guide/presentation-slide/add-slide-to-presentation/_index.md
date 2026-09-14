---
title: เพิ่มสไลด์ในงานนำเสนอด้วย Python
linktitle: เพิ่มสไลด์
type: docs
weight: 10
url: /th/python-java/add-slide-to-presentation/
keywords:
- เพิ่มสไลด์
- สร้างสไลด์
- สไลด์เปล่า
- PowerPoint
- OpenDocument
- งานนำเสนอ
- Python
- Aspose.Slides
description: "เพิ่มสไลด์ในงานนำเสนอ PowerPoint และ OpenDocument ของคุณได้อย่างง่ายดายโดยใช้ Aspose.Slides for Python via Java—การแทรกสไลด์ที่รวดเร็วและมีประสิทธิภาพในไม่กี่วินาที."
---
## **ภาพรวม**

Aspose.Slides ให้คุณเพิ่มสไลด์ลงในงานนำเสนอ PowerPoint ผ่านโปรแกรม งานนำเสนอประกอบด้วยสไลด์ master/layout และสไลด์ปกติ โดยสไลด์ปกติจะเรียงตามดัชนีเริ่มจากศูนย์ แต่ละสไลด์มี ID ที่ไม่ซ้ำกัน และไฟล์งานนำเสนอที่ไม่มีสไลด์จะไม่ได้รับการสนับสนุน

บทความนี้อธิบายวิธีสร้างอ็อบเจกต์ [Presentation](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentation/) เข้าถึงคอลเลกชันสไลด์ เพิ่มสไลด์เปล่า ทำงานกับสไลด์ที่เพิ่มใหม่ และบันทึกงานนำเสนอที่อัปเดต อีกทั้งยังครอบคลุมจุดที่เกี่ยวข้อง เช่น การแทรกสไลด์ในตำแหน่งเฉพาะ การใช้เลเอาต์ และความเข้าใจเกี่ยวกับสไลด์ว่างที่มีอยู่ในงานนำเสนอที่สร้างใหม่

## **เพิ่มสไลด์ในงานนำเสนอ**

ก่อนจะอธิบายวิธีเพิ่มสไลด์ในไฟล์งานนำเสนอ ให้เราทบทวนข้อเท็จจริงเกี่ยวกับสไลด์แต่ละไฟล์งานนำเสนอ PowerPoint จะประกอบด้วยสไลด์ **master/layout** และสไลด์ **ปกติ** ไฟล์งานนำเสนอจะต้องมีอย่างน้อยหนึ่งสไลด์ ไฟล์งานนำเสนอที่ไม่มีสไลด์จะไม่ได้รับการสนับสนุนโดย Aspose.Slides for Python via Java แต่ละสไลด์มี ID ที่ไม่ซ้ำกัน และสไลด์ปกติทั้งหมดจะเรียงตามดัชนีเริ่มจากศูนย์

Aspose.Slides for Python via Java อนุญาตให้ผู้พัฒนาเพิ่มสไลด์เปล่าในงานนำเสนอของตน เพื่อเพิ่มสไลด์เปล่าให้ทำตามขั้นตอนต่อไปนี้:

- สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentation/)  
- รับอ้างอิงไปยังอ็อบเจกต์ [SlideCollection](https://reference.aspose.com/slides/th/python-java/aspose.slides/slidecollection/) โดยใช้เมธอด [getSlides](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentation/#getSlides) ของอ็อบเจกต์ [Presentation](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentation/)  
- เรียกเมธอด [addEmptySlide](https://reference.aspose.com/slides/th/python-java/aspose.slides/slidecollection/#addEmptySlide) ของอ็อบเจกต์ [SlideCollection](https://reference.aspose.com/slides/th/python-java/aspose.slides/slidecollection/) เพื่อเพิ่มสไลด์เปล่าที่ส่วนท้ายของคอลเลกชันสไลด์  
- ทำงานบางอย่างกับสไลด์เปล่าที่เพิ่งเพิ่มใหม่  
- สุดท้ายให้เขียนไฟล์งานนำเสนอโดยใช้อ็อบเจกต์ [Presentation](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentation/)

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

# สร้างอินสแตนซ์ของคลาส Presentation ที่เป็นตัวแทนของไฟล์งานนำเสนอ.
presentation = Presentation()
try:
    # รับคอลเลกชันสไลด์.
    slides = presentation.getSlides()

    for i in range(presentation.getLayoutSlides().size()):
        # เพิ่มสไลด์เปล่าไปยังคอลเลกชันสไลด์.
        slides.addEmptySlide(presentation.getLayoutSlides().get_Item(i))

    # ทำงานบางอย่างกับสไลด์ที่เพิ่งเพิ่มใหม่.

    # บันทึกไฟล์ PPTX ลงดิสก์.
    presentation.save("EmptySlide.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **คำถามที่พบบ่อย**

**ฉันสามารถแทรกสไลด์ใหม่ในตำแหน่งเฉพาะได้หรือไม่ ไม่ใช่แค่ที่ส่วนท้าย?**

ได้ ไลบรารีสนับสนุนคอลเลกชันสไลด์และการดำเนินการ [insert](https://reference.aspose.com/slides/th/python-java/aspose.slides/slidecollection/#insertEmptySlide)/[clone](https://reference.aspose.com/slides/th/python-java/aspose.slides/slidecollection/#insertClone) ดังนั้นคุณสามารถเพิ่มสไลด์ที่ตำแหน่งดัชนีที่ต้องการได้ ไม่จำเป็นต้องเป็นส่วนท้ายเท่านั้น

**ธีม/สไตล์จะถูกเก็บรักษาไว้เมื่อเพิ่มสไลด์โดยอิงจากเลเอาต์หรือไม่?**

ใช่ เลเอาต์สืบทอดการจัดรูปแบบจากมาสเตอร์ของมัน และสไลด์ใหม่จะสืบทอดจากเลเอาต์ที่เลือกและมาสเตอร์ที่เกี่ยวข้อง

**สไลด์ใดที่ปรากฏในงานนำเสนอ "เปล่า" ใหม่ก่อนที่จะเพิ่มสไลด์?**

งานนำเสนอที่สร้างใหม่จะมีสไลด์ว่างหนึ่งสไลด์อยู่แล้วโดยมีดัชนีเป็นศูนย์ ซึ่งต้องคำนึงถึงเมื่อต้องคำนวณดัชนีการแทรก

**ฉันจะเลือกเลเอาต์ "ที่เหมาะสม" สำหรับสไลด์ใหม่เมื่อมาสเตอร์มีหลายตัวเลือกอย่างไร?**

โดยทั่วไปให้เลือก [LayoutSlide](https://reference.aspose.com/slides/th/python-java/aspose.slides/layoutslide/) ที่ตรงกับโครงสร้างที่ต้องการ (เช่น Title and Content, Two Content เป็นต้น) หากไม่มีเลเอาต์ดังกล่าว คุณสามารถ [add it to the master](/slides/th/python-java/slide-layout/) แล้วใช้ต่อไปได้