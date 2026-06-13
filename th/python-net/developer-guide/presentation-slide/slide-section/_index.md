---
title: จัดการส่วนสไลด์ในการนำเสนอด้วย Python
linktitle: ส่วนสไลด์
type: docs
weight: 100
url: /th/python-net/slide-section/
keywords:
- สร้างส่วน
- เพิ่มส่วน
- แก้ไขส่วน
- เปลี่ยนส่วน
- ชื่อส่วน
- PowerPoint
- การนำเสนอ
- Python
- Aspose.Slides
description: "ทำให้ส่วนสไลด์ใน PowerPoint และ OpenDocument ง่ายขึ้นด้วย Aspose.Slides for Python — แยก, เปลี่ยนชื่อ, และจัดเรียงใหม่เพื่อเพิ่มประสิทธิภาพการทำงานของ PPTX และ ODP"
---
## **บทนำ**

ด้วย Aspose.Slides for Python คุณสามารถจัดระเบียบการนำเสนอ PowerPoint ให้เป็นส่วนที่กลุ่มสไลด์เฉพาะได้

คุณอาจต้องการสร้างส่วนเพื่อจัดระเบียบหรือแบ่งการนำเสนอเป็นส่วนที่มีเหตุผลในสถานการณ์เหล่านี้:

- เมื่อคุณทำงานกับการนำเสนอขนาดใหญ่ร่วมกับทีมและต้องการมอบหมายสไลด์บางส่วนให้กับเพื่อนร่วมงานเฉพาะ
- เมื่อคุณต้องจัดการกับการนำเสนอที่มีสไลด์จำนวนมากและพบว่าลำบากในการจัดการหรือแก้ไขทั้งหมดในครั้งเดียว

โดยควรสร้างส่วนที่กลุ่มสไลด์ที่เกี่ยวข้อง—สไลด์ที่มีธีม ประเด็น หรือวัตถุประสงค์เดียวกัน—และตั้งชื่อแต่ละส่วนให้สื่อความหมายของเนื้อหาอย่างชัดเจน

## **สร้างส่วนในการนำเสนอ**

เพื่อเพิ่ม [ส่วน](https://reference.aspose.com/slides/th/python-net/aspose.slides/section/) ที่กลุ่มสไลด์ในการนำเสนอ Aspose.Slides มีเมธอด [add_section](https://reference.aspose.com/slides/th/python-net/aspose.slides/sectioncollection/add_section/) ให้คุณระบุชื่อส่วนและสไลด์ที่ส่วนเริ่มต้น

ตัวอย่าง Python ด้านล่างแสดงวิธีสร้างส่วนในการนำเสนอ:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    layout_slide = presentation.layout_slides[0]

    slide1 = presentation.slides.add_empty_slide(layout_slide)
    slide2 = presentation.slides.add_empty_slide(layout_slide)
    slide3 = presentation.slides.add_empty_slide(layout_slide)
    slide4 = presentation.slides.add_empty_slide(layout_slide)

    section1 = presentation.sections.add_section("Section 1", slide1)
    # ส่วนที่ 1 สิ้นสุดที่สไลด์ 2; ส่วนที่ 2 เริ่มที่สไลด์ 3.
    section2 = presentation.sections.add_section("Section 2", slide3) 
      
    presentation.save("presentation_sections.pptx", slides.export.SaveFormat.PPTX)
    
    presentation.sections.reorder_section_with_slides(section2, 0)
    presentation.save("reordered_sections.pptx", slides.export.SaveFormat.PPTX)
    
    presentation.sections.remove_section_with_slides(section2)
    presentation.sections.append_empty_section("Last empty section")
    presentation.save("presentation_with_empty_section.pptx",slides.export.SaveFormat.PPTX)
```

## **เปลี่ยนชื่อของส่วน**

หลังจากสร้าง [ส่วน](https://reference.aspose.com/slides/th/python-net/aspose.slides/section/) ในการนำเสนอ PowerPoint คุณอาจต้องการเปลี่ยนชื่อของมัน

ตัวอย่าง Python ด้านล่างแสดงวิธีเปลี่ยนชื่อส่วนในการนำเสนอ:

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
   section = presentation.sections[0]
   section.name = "My section"
```

## **คำถามที่พบบ่อย**

**ส่วนจะถูกเก็บไว้เมื่อบันทึกเป็นรูปแบบ PPT (PowerPoint 97–2003) หรือไม่?**

ไม่ รูปแบบ PPT ไม่รองรับเมทาดาต้าส่วน จึงทำให้การจัดกลุ่มส่วนหายไปเมื่อบันทึกเป็น .ppt

**สามารถซ่อนส่วนทั้งหมดได้หรือไม่?**

ไม่ เพียงสไลด์เดี่ยวเท่านั้นที่สามารถซ่อนได้ ส่วนในฐานะเอนทิตี้ไม่มีสถานะ “ซ่อน”

**ฉันสามารถค้นหาส่วนโดยอ้างอิงจากสไลด์ได้อย่างรวดเร็วและในทางกลับกันหาสไลด์แรกของส่วนได้หรือไม่?**

ได้ ส่วนถูกกำหนดอย่างชัดเจนด้วยสไลด์เริ่มต้น; หากคุณมีสไลด์ คุณสามารถระบุได้ว่ามันอยู่ในส่วนใด และสำหรับส่วนหนึ่งคุณสามารถเข้าถึงสไลด์แรกของมันได้