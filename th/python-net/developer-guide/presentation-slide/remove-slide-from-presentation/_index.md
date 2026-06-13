---
title: ลบสไลด์จากงานนำเสนอใน Python
linktitle: ลบสไลด์
type: docs
weight: 30
url: /th/python-net/remove-slide-from-presentation/
keywords:
- ลบสไลด์
- ลบสไลด์
- ลบสไลด์ที่ไม่ได้ใช้
- PowerPoint
- งานนำเสนอ
- Python
- Aspose.Slides
description: "ลบสไลด์จากงานนำเสนอ PowerPoint และ OpenDocument อย่างง่ายดายด้วย Aspose.Slides สำหรับ Python ผ่าน .NET รับตัวอย่างโค้ดที่ชัดเจนและเพิ่มประสิทธิภาพการทำงานของคุณ"
---
## **บทนำ**

หากสไลด์ (หรือเนื้อหาภายใน) ไม่จำเป็นอีกต่อไป คุณสามารถลบมันได้ Aspose.Slides มีคลาส [Presentation](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/) ที่ห่อหุ้ม [SlideCollection](https://reference.aspose.com/slides/th/python-net/aspose.slides/slidecollection/) ซึ่งเป็นคลังเก็บสไลด์ทั้งหมดในงานพรีเซนเทชัน โดยใช้การอ้างอิงหรือดัชนีไปยังอ็อบเจกต์ [Slide](https://reference.aspose.com/slides/th/python-net/aspose.slides/slide/) ที่ทราบ คุณสามารถลบสไลด์เป้าหมายได้

## **ลบสไลด์โดยอ้างอิง**

เมื่อคุณมีการอ้างอิงไปยัง [Slide](https://reference.aspose.com/slides/th/python-net/aspose.slides/slide/) เป้าหมายแล้ว คุณสามารถลบมันโดยตรงได้ วิธีนี้ช่วยหลีกเลี่ยงการค้นหาดัชนีและทำให้โค้ดสั้นและชัดเจนขึ้น

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/)
1. รับการอ้างอิงไปยังสไลด์ที่คุณต้องการลบโดยใช้ ID หรือดัชนีของมัน
1. ลบสไลด์ที่อ้างอิงออกจากพรีเซนเทชัน
1. บันทึกพรีเซนเทชันที่แก้ไขแล้ว

ตัวอย่าง Python ด้านล่างนี้ลบสไลด์โดยอ้างอิง:

```python
import aspose.slides as slides

# สร้างอินสแตนซ์ของคลาส Presentation เพื่อเปิดไฟล์งานนำเสนอ.
with slides.Presentation("sample.pptx") as presentation:
    # เข้าถึงสไลด์โดยใช้ดัชนีในคอลเลกชันสไลด์.
    slide = presentation.slides[0]

    # ลบสไลด์โดยอ้างอิง.
    presentation.slides.remove(slide)

    # บันทึกงานนำเสนอที่แก้ไขแล้ว.
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **ลบสไลด์โดยดัชนี**

หากคุณรู้ตำแหน่งของสไลด์ในชุด ให้ลบมันโดยใช้ดัชนี วิธีนี้มีประโยชน์อย่างยิ่งในลูปหรือการดำเนินการแบบกลุ่มที่ตำแหน่งทราบล่วงหน้า

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/)
1. ลบสไลด์โดยใช้ดัชนีของมัน
1. บันทึกพรีเซนเทชันที่แก้ไขแล้ว

ตัวอย่าง Python นี้แสดงวิธีลบสไลด์โดยใช้ดัชนี:

```python
import aspose.slides as slides

# สร้างอินสแตนซ์ของคลาส Presentation เพื่อเปิดไฟล์งานนำเสนอ.
with slides.Presentation("sample.pptx") as presentation:
    # ลบสไลด์โดยใช้ดัชนีของมัน.
    presentation.slides.remove_at(0)

    # บันทึกงานนำเสนอที่แก้ไขแล้ว.
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **ลบสไลด์เลย์เอาต์ที่ไม่ได้ใช้งาน**

Aspose.Slides มีเมธอด `remove_unused_layout_slides` ในคลาส [Compress](https://reference.aspose.com/slides/th/python-net/aspose.slides.lowcode/compress/) เพื่อทำการลบสไลด์เลย์เอาต์ที่ไม่ต้องการและไม่ได้ใช้ ตัวอย่าง Python ด้านล่างแสดงวิธีลบสไลด์เลย์เอาต์ที่ไม่ได้ใช้จากงานนำเสนอ PowerPoint:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slides.lowcode.Compress.remove_unused_layout_slides(presentation)
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **ลบสไลด์มาสเตอร์ที่ไม่ได้ใช้งาน**

Aspose.Slides มีเมธอด `remove_unused_master_slides` ในคลาส [Compress](https://reference.aspose.com/slides/th/python-net/aspose.slides.lowcode/compress/) เพื่อทำการลบมาสเตอร์สไลด์ที่ไม่ต้องการและไม่ได้ใช้ ตัวอย่าง Python ด้านล่างแสดงวิธีลบมาสเตอร์สไลด์ที่ไม่ได้ใช้จากงานนำเสนอ PowerPoint:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slides.lowcode.Compress.remove_unused_master_slides(presentation)
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **คำถามที่พบบ่อย**

**เกิดอะไรขึ้นกับดัชนีสไลด์หลังจากที่ฉันลบสไลด์?**

หลังจากการลบ [collection](https://reference.aspose.com/slides/th/python-net/aspose.slides/slidecollection/) จะทำการจัดทำดัชนีใหม่: สไลด์ถัดไปทุกสไลด์จะเลื่อนตำแหน่งหนึ่งตำแหน่งไปทางซ้าย ทำให้หมายเลขดัชนีก่อนหน้านี้ล้าสมัย หากคุณต้องการการอ้างอิงที่คงที่ ควรใช้ ID คงที่ของสไลด์แทนดัชนี

**ID ของสไลด์แตกต่างจากดัชนีหรือไม่ และเปลี่ยนแปลงเมื่อสไลด์ข้างเคียงถูกลบหรือไม่?**

ใช่ ดัชนีคือตำแหน่งของสไลด์และจะเปลี่ยนแปลงเมื่อสไลด์ถูกเพิ่มหรือถูกลบ ส่วน ID ของสไลด์เป็นตัวระบุที่คงที่และจะไม่เปลี่ยนแปลงเมื่อสไลด์อื่นถูกลบ

**การลบสไลด์ส่งผลต่อส่วนของสไลด์อย่างไร?**

หากสไลด์เป็นส่วนหนึ่งของเซ็กชัน เซ็กชันนั้นจะมีสไลด์น้อยลงหนึ่งสไลด์ โครงสร้างของเซ็กชันยังคงอยู่; หากเซ็กชันว่างเปล่า คุณสามารถ [remove or reorganize sections](/slides/th/python-net/slide-section/) ตามต้องการ

**เกิดอะไรขึ้นกับบันทึกและความคิดเห็นที่แนบกับสไลด์เมื่อมันถูกลบ?**

[Notes](/slides/th/python-net/presentation-notes/) และ [comments](/slides/th/python-net/presentation-comments/) ผูกติดกับสไลด์นั้นและจะถูกลบพร้อมกับสไลด์นั้น เนื้อหาบนสไลด์อื่นไม่ถูกกระทบ

**การลบสไลด์ต่างจากการทำความสะอาดเลย์เอาต์/มาสเตอร์ที่ไม่ได้ใช้อย่างไร?**

การลบจะเอาสไลด์ปกติที่เฉพาะเจาะจงออกจากชุด การทำความสะอาดเลย์เอาต์/มาสเตอร์ที่ไม่ได้ใช้จะลบสไลด์เลย์เอาต์หรือมาสเตอร์ที่ไม่มีอ้างอิงใด ๆ เพื่อลดขนาดไฟล์โดยไม่เปลี่ยนเนื้อหาสไลด์ที่เหลือ การดำเนินการเหล่านี้ทำงานเสริมกันโดยทั่วไปจะลบก่อนแล้วจึงทำความสะอาด