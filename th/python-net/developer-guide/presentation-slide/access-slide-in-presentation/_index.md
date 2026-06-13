---
title: เข้าถึงสไลด์ในงานนำเสนอด้วย Python
linktitle: เข้าถึงสไลด์
type: docs
weight: 20
url: /th/python-net/access-slide-in-presentation/
keywords:
- เข้าถึงสไลด์
- ดัชนีสไลด์
- ID สไลด์
- ตำแหน่งสไลด์
- เปลี่ยนตำแหน่ง
- คุณสมบัติสไลด์
- หมายเลขสไลด์
- PowerPoint
- OpenDocument
- งานนำเสนอ
- Python
- Aspose.Slides
description: "เรียนรู้วิธีเข้าถึงและจัดการสไลด์ในงานนำเสนอ PowerPoint และ OpenDocument ด้วย Aspose.Slides สำหรับ Python ผ่าน .NET เพิ่มประสิทธิภาพการทำงานด้วยตัวอย่างโค้ด."
---
## **Overview**

บทความนี้อธิบายวิธีเข้าถึงสไลด์เฉพาะในงานนำเสนอ PowerPoint ด้วย Aspose.Slides for Python แสดงวิธีเปิดงานนำเสนอ อ้างอิงสไลด์ด้วยดัชนีหรือด้วย ID ที่ไม่ซ้ำกัน และอ่านข้อมูลพื้นฐานของสไลด์ที่จำเป็นสำหรับการนำทางภายในไฟล์ ด้วยเทคนิคเหล่านี้ คุณสามารถค้นหาสไลด์ที่ต้องการตรวจสอบหรือประมวลผลได้อย่างแม่นยำ

## **Access a Slide by Index**

สไลด์ในงานนำเสนอจะถูกจัดเรียงตามตำแหน่งโดยเริ่มจาก 0 สไลด์แรกมีดัชนี 0 สไลด์ที่สองมีดัชนี 1 และต่อไปเช่นนั้น

คลาส [Presentation](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/) (ซึ่งแทนไฟล์งานนำเสนอ) เปิดเผยสไลด์ผ่าน [SlideCollection](https://reference.aspose.com/slides/th/python-net/aspose.slides/slidecollection/) ของอ็อบเจกต์ [Slide](https://reference.aspose.com/slides/th/python-net/aspose.slides/slide/)

โค้ด Python ด้านล่างแสดงวิธีเข้าถึงสไลด์ตามดัชนีของมัน:

```python
import aspose.slides as slides

# สร้าง Presentation ที่แสดงถึงไฟล์งานนำเสนอ
with slides.Presentation("sample.pptx") as presentation:
    # รับสไลด์ตามดัชนีของมัน
    slide = presentation.slides[0]
```

## **Access a Slide by ID**

แต่ละสไลด์ในงานนำเสนอจะมี ID ที่ไม่ซ้ำกัน คุณสามารถใช้เมธอด [get_slide_by_id](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/get_slide_by_id/) (ซึ่งเปิดเผยโดยคลาส [Presentation](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/)) เพื่อระบุ ID นั้น

โค้ด Python ด้านล่างแสดงวิธีระบุ ID สไลด์ที่ถูกต้องและเข้าถึงสไลด์นั้นผ่านเมธอด [get_slide_by_id](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/get_slide_by_id/):

```python
import aspose.slides as slides

# สร้าง Presentation ที่แสดงถึงไฟล์งานนำเสนอ
with slides.Presentation("sample.pptx") as presentation:
    # รับ ID ของสไลด์
    id = presentation.slides[0].slide_id
    # เข้าถึงสไลด์โดยใช้ ID ของมัน
    slide = presentation.get_slide_by_id(id)
```

## **Change a Slide's Position**

Aspose.Slides อนุญาตให้คุณเปลี่ยนตำแหน่งของสไลด์ ตัวอย่างเช่น คุณสามารถทำให้สไลด์แรกกลายเป็นสไลด์ที่สอง

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/)  
1. รับอ้างอิงถึงสไลด์ที่ต้องการเปลี่ยนตำแหน่งตามดัชนีของมัน  
1. ตั้งค่าตำแหน่งใหม่สำหรับสไลด์ผ่านคุณสมบัติ [slide_number](https://reference.aspose.com/slides/th/python-net/aspose.slides/slide/slide_number/)  
1. บันทึกงานนำเสนอที่แก้ไขแล้ว  

โค้ด Python ด้านล่างย้ายสไลด์จากตำแหน่ง 1 ไปยังตำแหน่ง 2:

```python
import aspose.slides as slides

# สร้างอ็อบเจกต์ Presentation ที่แสดงถึงไฟล์งานนำเสนอ
with slides.Presentation("sample.pptx") as presentation:
    # รับสไลด์ที่ตำแหน่งจะถูกเปลี่ยน
    slide = presentation.slides[0]
    # ตั้งค่าตำแหน่งใหม่ให้กับสไลด์
    slide.slide_number = 2
    # บันทึกงานนำเสนอที่แก้ไขแล้ว
    presentation.save("slide_number.pptx", slides.export.SaveFormat.PPTX)
```

สไลด์แรกจะกลายเป็นสไลด์ที่สอง; สไลด์ที่สองจะกลายเป็นสไลด์แรก เมื่อคุณเปลี่ยนตำแหน่งของสไลด์ สไลด์อื่น ๆ จะถูกปรับอัตโนมัติ

## **Set the Slide Number**

โดยใช้คุณสมบัติ [first_slide_number](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/first_slide_number/) (ที่เปิดเผยโดยคลาส [Presentation](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/)) คุณสามารถกำหนดหมายเลขใหม่ให้กับสไลด์แรกในงานนำเสนอ การดำเนินการนี้จะทำให้หมายเลขสไลด์อื่น ๆ ถูกคำนวณใหม่

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/)  
1. ตั้งค่าหมายเลขสไลด์  
1. บันทึกงานนำเสนอที่แก้ไขแล้ว  

โค้ด Python ด้านล่างแสดงตัวอย่างการตั้งหมายเลขสไลด์แรกเป็น 10:

```python
import aspose.slides as slides

# สร้างอ็อบเจกต์ Presentation ที่แสดงถึงไฟล์งานนำเสนอ
with slides.Presentation("sample.pptx") as presentation:
    # ตั้งค่าหมายเลขสไลด์
    presentation.first_slide_number = 10
    # บันทึกงานนำเสนอที่แก้ไขแล้ว
    presentation.save("first_slide_number.pptx", slides.export.SaveFormat.PPTX)
```

ถ้าต้องการข้ามสไลด์แรก คุณสามารถเริ่มนับหมายเลขจากสไลด์ที่สอง (และซ่อนหมายเลขบนสไลด์แรก) ได้ดังนี้:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    layout_slide = presentation.layout_slides.get_by_type(slides.SlideLayoutType.BLANK)
    presentation.slides.add_empty_slide(layout_slide)
    presentation.slides.add_empty_slide(layout_slide)
    presentation.slides.add_empty_slide(layout_slide)

    # ตั้งค่าหมายเลขสำหรับสไลด์แรกในงานนำเสนอ.
    presentation.first_slide_number = 0

    # แสดงหมายเลขสไลด์สำหรับสไลด์ทั้งหมด.
    presentation.header_footer_manager.set_all_slide_numbers_visibility(True)

    # ซ่อนหมายเลขสไลด์บนสไลด์แรก.
    presentation.slides[0].header_footer_manager.set_slide_number_visibility(False)

    # บันทึกงานนำเสนอที่แก้ไขแล้ว.
    presentation.save("first_slide_number.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Does the slide number a user sees match the collection’s zero-based index?**

หมายเลขที่แสดงบนสไลด์อาจเริ่มจากค่าใดค่าหนึ่ง (เช่น 10) และไม่จำเป็นต้องตรงกับดัชนี; ความสัมพันธ์นี้ถูกควบคุมโดยการตั้งค่า [first slide number](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/first_slide_number/) ของงานนำเสนอ

**Do hidden slides affect indexing?**

ใช่ สไลด์ที่ซ่อนอยู่ยังคงอยู่ในคอลเลกชันและถูกนับในการระดัชนี; “hidden” หมายถึงการแสดงผล ไม่ได้หมายถึงตำแหน่งในคอลเลกชัน

**Does a slide’s index change when other slides are added or removed?**

ใช่ ดัชนีจะสะท้อนลำดับปัจจุบันของสไลด์เสมอและจะถูกคำนวณใหม่เมื่อทำการแทรก, ลบ หรือย้ายสไลด์  