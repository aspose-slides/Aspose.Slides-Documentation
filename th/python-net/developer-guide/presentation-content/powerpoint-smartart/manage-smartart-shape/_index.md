---
title: จัดการกราฟิก SmartArt ในงานนำเสนอด้วย Python
linktitle: กราฟิก SmartArt
type: docs
weight: 20
url: /th/python-net/manage-smartart-shape/
keywords:
- วัตถุ SmartArt
- กราฟิก SmartArt
- สไตล์ SmartArt
- สี SmartArt
- สร้าง SmartArt
- เพิ่ม SmartArt
- แก้ไข SmartArt
- เปลี่ยน SmartArt
- เข้าถึง SmartArt
- ประเภทเลย์เอาต์ SmartArt
- PowerPoint
- งานนำเสนอ
- Python
- Aspose.Slides
description: "อัตโนมัติการสร้าง แก้ไข และจัดรูปแบบ SmartArt ของ PowerPoint ด้วย Python ผ่าน .NET โดยใช้ Aspose.Slides พร้อมตัวอย่างโค้ดสั้นและแนวทางที่เน้นประสิทธิภาพ"
---
## **ภาพรวม**

Aspose.Slides ช่วยให้คุณสร้างและจัดการกราฟิก SmartArt ในงานนำเสนอ PowerPoint ผ่านโปรแกรมได้ บทความนี้อธิบายวิธีการเพิ่มรูปร่าง SmartArt ลงในสไลด์, เข้าถึงรูปร่าง SmartArt ที่มีอยู่, ค้นหา SmartArt ด้วยประเภทเลย์เอาต์เฉพาะ, และอัปเดตลักษณะการแสดงผลโดยการเปลี่ยนสไตล์ SmartArt หรือสไตล์สี

ตัวอย่างจะแสดงวิธีทำงานกับรูปร่าง SmartArt ผ่านคอลเลกชันรูปร่างของสไลด์งานนำเสนอ, ตรวจสอบว่ารูปร่างเป็น SmartArt หรือไม่ แล้วทำการแก้ไขหรือตรวจสอบคุณสมบัติต่างๆ

## **สร้างรูปร่าง SmartArt**

Aspose.Slides สำหรับ Python ผ่าน .NET ให้คุณเพิ่มรูปร่าง SmartArt ที่กำหนดเองลงในสไลด์ตั้งแต่ต้น API ทำให้สิ่งนี้ง่ายขึ้น เพื่อเพิ่มรูปร่าง SmartArt ลงในสไลด์:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/)
1. ดึงสไลด์เป้าหมายตามดัชนีของมัน
1. เพิ่มรูปร่าง SmartArt โดยระบุประเภทเลย์เอาต์ของมัน
1. บันทึกงานนำเสนอที่แก้ไขเป็นไฟล์ PPTX

```py
import aspose.slides as slides
import aspose.slides.smartart as smartart

# สร้างอินสแตนซ์ของคลาส Presentation.
with slides.Presentation() as presentation:
    # เข้าถึงสไลด์ของงานนำเสนอ.
    slide = presentation.slides[0]
    # เพิ่มรูปร่าง SmartArt.
    smart_art = slide.shapes.add_smart_art(0, 0, 400, 400, smartart.SmartArtLayoutType.BASIC_BLOCK_LIST)
    # บันทึกงานนำเสนอลงดิสก์.
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **เข้าถึงรูปร่าง SmartArt บนสไลด์**

โค้ดต่อไปนี้แสดงวิธีการเข้าถึงรูปร่าง SmartArt บนสไลด์ ตัวอย่างจะวนผ่านแต่ละรูปร่างบนสไลด์และตรวจสอบว่ามันเป็นอ็อบเจ็กต์ [SmartArt](https://reference.aspose.com/slides/th/python-net/aspose.slides.smartart/smartart/) หรือไม่

```py
import aspose.slides as slides
import aspose.slides.smartart as smartart

# โหลดไฟล์งานนำเสนอ.
with slides.Presentation("SmartArt.pptx") as presentation:
    # วนผ่านทุกรูปร่างบนสไลด์แรก.
    for shape in presentation.slides[0].shapes:
        # ตรวจสอบว่ารูปร่างเป็นรูปร่าง SmartArt หรือไม่.
        if isinstance(shape, smartart.SmartArt):
            # พิมพ์ชื่อรูปร่าง.
            print("Shape name:", shape.name)
```

## **เข้าถึงรูปร่าง SmartArt ด้วยประเภทเลย์เอาต์ที่ระบุ**

ตัวอย่างต่อไปนี้แสดงวิธีเข้าถึงรูปร่าง SmartArt ด้วยประเภทเลย์เอาต์ที่ระบุ โปรดทราบว่าคุณไม่สามารถเปลี่ยนประเภทเลย์เอาต์ของ SmartArt ได้ — มันเป็นแบบอ่านอย่างเดียวและถูกกำหนดเมื่อสร้างรูปร่าง

1. สร้างอินสแตนซ์ [Presentation](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/) และโหลดงานนำเสนอที่มีรูปร่าง SmartArt
1. ดึงอ้างอิงไปยังสไลด์แรกตามดัชนี
1. วนผ่านทุกรูปร่างบนสไลด์แรก
1. ตรวจสอบว่ารูปร่างเป็นอ็อบเจ็กต์ [SmartArt](https://reference.aspose.com/slides/th/python-net/aspose.slides.smartart/smartart/) หรือไม่
1. หากประเภทเลย์เอาต์ของรูปร่าง SmartArt ตรงกับที่คุณต้องการ ให้ทำการกระทำที่จำเป็น

```py
import aspose.slides as slides
import aspose.slides.smartart as smartart

with slides.Presentation("SmartArt.pptx") as presentation:
    # วนผ่านทุกรูปร่างบนสไลด์แรก.
    for shape in presentation.slides[0].shapes:
        # ตรวจสอบว่ารูปร่างเป็นรูปร่าง SmartArt หรือไม่.
        if isinstance(shape, smartart.SmartArt):
            # ตรวจสอบประเภทเลย์เอาต์ของ SmartArt.
            if shape.layout == smartart.SmartArtLayoutType.BASIC_BLOCK_LIST:
                print("Do something here...")
```

## **เปลี่ยนสไตล์รูปร่าง SmartArt**

ตัวอย่างต่อไปนี้แสดงวิธีค้นหารูปร่าง SmartArt และเปลี่ยนสไตล์ของพวกมัน:

1. สร้าง [Presentation](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/) และโหลดไฟล์ที่มีรูปร่าง SmartArt
1. ดึงอ้างอิงไปยังสไลด์แรกตามดัชนี
1. วนผ่านแต่ละรูปร่างบนสไลด์แรก
1. ค้นหารูปร่าง SmartArt ที่มีสไตล์ที่ระบุ
1. กำหนดสไตล์ใหม่ให้กับรูปร่าง SmartArt
1. บันทึกงานนำเสนอ

```py
import aspose.slides as slides
import aspose.slides.smartart as smartart

with slides.Presentation("SmartArt.pptx") as presentation:
    # วนผ่านทุกรูปร่างบนสไลด์แรก.
    for shape in presentation.slides[0].shapes:
        # ตรวจสอบว่ารูปร่างเป็นรูปร่าง SmartArt หรือไม่.
        if isinstance(shape, smartart.SmartArt):
            # ตรวจสอบสไตล์ของ SmartArt.
            if shape.quick_style == smartart.SmartArtQuickStyleType.SIMPLE_FILL:
                # เปลี่ยนสไตล์ของ SmartArt.
                smart.quick_style = smartart.SmartArtQuickStyleType.CARTOON
    # บันทึกงานนำเสนอ.
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **เปลี่ยนสไตล์สีของรูปร่าง SmartArt**

ตัวอย่างนี้แสดงวิธีเปลี่ยนสไตล์สีของรูปร่าง SmartArt โค้ดตัวอย่างจะค้นหารูปร่าง SmartArt ที่มีสไตล์สีที่ระบุและอัปเดตมัน

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/) และโหลดงานนำเสนอที่มีรูปร่าง SmartArt
1. ดึงอ้างอิงไปยังสไลด์แรกตามดัชนี
1. วนผ่านแต่ละรูปร่างบนสไลด์แรก
1. ตรวจสอบว่ารูปร่างเป็นอ็อบเจ็กต์ [SmartArt](https://reference.aspose.com/slides/th/python-net/aspose.slides.smartart/smartart/) หรือไม่
1. ค้นหารูปร่าง SmartArt ที่มีสไตล์สีที่ระบุ
1. ตั้งค่าสไตล์สีใหม่สำหรับรูปร่าง SmartArt นั้น
1. บันทึกงานนำเสนอ

```py
import aspose.slides as slides
import aspose.slides.smartart as smartart

with slides.Presentation("SmartArt.pptx") as presentation:
    # วนผ่านทุกรูปร่างบนสไลด์แรก.
    for shape in presentation.slides[0].shapes:
        # ตรวจสอบว่ารูปร่างเป็นรูปร่าง SmartArt หรือไม่.
        if isinstance(shape, smartart.SmartArt):
            # ตรวจสอบประเภทสี.
            if shape.color_style == smartart.SmartArtColorType.COLORED_FILL_ACCENT1:
                # เปลี่ยนประเภทสี.
                shape.color_style = smartart.SmartArtColorType.COLORFUL_ACCENT_COLORS
    # บันทึกงานนำเสนอ.
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **คำถามที่พบบ่อย**

**ฉันสามารถทำแอนิเมชันกับ SmartArt เป็นวัตถุเดียวได้หรือไม่?**

ได้. SmartArt เป็นรูปร่าง ดังนั้นคุณสามารถใช้ [standard animations](/slides/th/python-net/powerpoint-animation/) ผ่าน API แอนิเมชัน (การเข้า, การออก, การเน้น, เส้นทางการเคลื่อนที่) เหมือนกับรูปร่างอื่นๆ

**ฉันจะค้นหา SmartArt เฉพาะบนสไลด์ได้อย่างไรหากไม่รู้ ID ภายในของมัน?**

ตั้งค่าและใช้ข้อความแทน (AltText) แล้วค้นหารูปร่างด้วยค่าดังกล่าว — นี่เป็นวิธีที่แนะนำในการระบุรูปร่างเป้าหมาย

**ฉันสามารถรวม SmartArt กับรูปร่างอื่นได้หรือไม่?**

ได้. คุณสามารถรวม SmartArt กับรูปร่างอื่นๆ (รูปภาพ, ตาราง, ฯลฯ) แล้ว [manipulate the group](/slides/th/python-net/group/).

**ฉันจะได้รูปภาพของ SmartArt เฉพาะ (เช่น สำหรับพรีวิวหรือรายงาน) อย่างไร?**

ส่งออกภาพขนาดย่อ/รูปภาพของรูปร่าง; ไลบรารีสามารถ [render individual shapes](/slides/th/python-net/create-shape-thumbnails/) เป็นไฟล์เรสเตอร์ (PNG/JPG/TIFF).

**รูปลักษณ์ของ SmartArt จะคงเดิมเมื่อแปลงงานนำเสนอทั้งหมดเป็น PDF หรือไม่?**

ได้. เอนจินการเรนเดอร์มุ่งเน้นความแม่นยำสูงสำหรับ [PDF export](/slides/th/python-net/convert-powerpoint-to-pdf/), พร้อมตัวเลือกคุณภาพและความเข้ากันได้หลายแบบ.