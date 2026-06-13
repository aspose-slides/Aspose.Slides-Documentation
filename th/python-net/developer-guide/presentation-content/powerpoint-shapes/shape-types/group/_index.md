---
title: รูปแบบการนำเสนอแบบกลุ่มด้วย Python
linktitle: กลุ่มรูปร่าง
type: docs
weight: 40
url: /th/python-net/group/
keywords:
- กลุ่มรูปร่าง
- รูปร่างกลุ่ม
- เพิ่มกลุ่ม
- ข้อความแทน
- PowerPoint
- การนำเสนอ
- Python
- Aspose.Slides
description: "เรียนรู้วิธีการจัดกลุ่มและยกเลิกการจัดกลุ่มรูปร่างใน PowerPoint และชุดเอกสาร OpenDocument ด้วย Aspose.Slides สำหรับ Python—คู่มือเร็ว ขั้นตอนต่อขั้นตอน พร้อมโค้ดฟรี."
---
## **ภาพรวม**

บทความนี้อธิบายวิธีการทำงานกับกลุ่มรูปร่างใน Aspose.Slides แสดงวิธีการเพิ่มกลุ่มรูปร่างลงในสไลด์ ใส่รูปร่างภายในกลุ่มและบันทึกงานนำเสนอที่อัปเดต นอกจากนี้ยังสาธิตวิธีการเข้าถึงรูปร่างที่เก็บอยู่ภายในกลุ่มและอ่านค่า `alternative_text` ของพวกมัน อีกทั้งบทความยังครอบคลุมสั้น ๆ เกี่ยวกับความสามารถของกลุ่มรูปร่างที่เกี่ยวข้อง เช่น กลุ่มซ้อนกัน ลำดับชั้น z‑order และตัวเลือกการล็อค

## **เพิ่มกลุ่มรูปร่าง**

Aspose.Slides รองรับการทำงานกับกลุ่มรูปร่างบนสไลด์ ฟีเจอร์นี้ช่วยให้คุณสร้างงานนำเสนอที่หลากหลายยิ่งขึ้นโดยถือหลายรูปร่างเป็นวัตถุเดียว คุณสามารถเพิ่มกลุ่มรูปร่างใหม่ เข้าถึงกลุ่มที่มีอยู่ เติมเต็มด้วยรูปร่างย่อย และอ่านหรือแก้ไขคุณสมบัติต่าง ๆ ของมันได้ เพื่อเพิ่มกลุ่มรูปร่างลงในสไลด์:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/)
2. รับอ้างอิงสไลด์โดยดัชนี
3. เพิ่ม [GroupShape](https://reference.aspose.com/slides/th/python-net/aspose.slides/groupshape/) ลงในสไลด์
4. เพิ่มรูปร่างลงในกลุ่มรูปร่างใหม่
5. บันทึกงานนำเสนอที่แก้ไขเป็นไฟล์ PPTX

ตัวอย่างด้านล่างแสดงวิธีการเพิ่มกลุ่มรูปร่างลงในสไลด์

```py
import aspose.slides as slides

# สร้างอินสแตนซ์ของคลาส Presentation.
with slides.Presentation() as presentation:
    # รับสไลด์แรก.
    slide = presentation.slides[0]

    # เพิ่มกลุ่มรูปร่างลงในสไลด์.
    group_shape = slide.shapes.add_group_shape()

    # เพิ่มรูปร่างภายในกลุ่มรูปร่าง.
    group_shape.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 300, 100, 100, 100)
    group_shape.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 500, 100, 100, 100)
    group_shape.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 300, 300, 100, 100)
    group_shape.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 500, 300, 100, 100)

    # บันทึกไฟล์ PPTX ลงดิสก์.
    presentation.save("group_shape.pptx", slides.export.SaveFormat.PPTX)
```

## **เข้าถึงคุณสมบัติ Alt Text**

ส่วนนี้อธิบายวิธีการอ่าน Alt Text ของรูปร่างที่อยู่ภายในกลุ่มรูปร่างบนสไลด์โดยใช้ Aspose.Slides เพื่อเข้าถึง Alt Text ของรูปร่าง:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/) เพื่อเป็นไฟล์ PPTX
2. รับอ้างอิงสไลด์โดยใช้ดัชนีของมัน
3. เข้าถึงคอลเลกชันรูปร่างของสไลด์
4. เข้าถึง [GroupShape](https://reference.aspose.com/slides/th/python-net/aspose.slides/groupshape/)
5. อ่านคุณสมบัติ Alt Text

ตัวอย่างด้านล่างดึงค่า Alt Text ของรูปร่างที่อยู่ภายในกลุ่มรูปร่าง

```py
import aspose.slides as slides

# สร้างอินสแตนซ์ของคลาส Presentation เพื่อเปิดไฟล์ PPTX.
with slides.Presentation("group_shape.pptx") as presentation:
    # รับสไลด์แรก.
    slide = presentation.slides[0]

    for shape in slide.shapes:
        if isinstance(shape, slides.GroupShape):
            # เข้าถึงกลุ่มรูปร่าง.
            for child_shape in shape.shapes:
                # เข้าถึงคุณสมบัติ Alt Text.
                print(child_shape.alternative_text)
```

## **คำถามที่พบบ่อย**

**รองรับการจัดกลุ่มซ้อนกัน (กลุ่มภายในกลุ่ม) หรือไม่?**

ใช่. [GroupShape](https://reference.aspose.com/slides/th/python-net/aspose.slides/groupshape/) มีคุณสมบัติ [parent_group](https://reference.aspose.com/slides/th/python-net/aspose.slides/groupshape/parent_group/) ซึ่งบ่งบอกการสนับสนุนลำดับชั้นโดยตรง (กลุ่มสามารถเป็นลูกของกลุ่มอื่นได้).

**ฉันจะควบคุมลำดับชั้น z‑order ของกลุ่มเทียบกับวัตถุอื่นบนสไลด์ได้อย่างไร?**

ใช้คุณสมบัติ [z_order_position](https://reference.aspose.com/slides/th/python-net/aspose.slides/groupshape/z_order_position/) ของ [GroupShape](https://reference.aspose.com/slides/th/python-net/aspose.slides/groupshape/) เพื่อตรวจสอบตำแหน่งของมันในสแต็กการแสดงผล.

**ฉันสามารถป้องกันการย้าย/แก้ไข/ขจัดการจัดกลุ่มได้หรือไม่?**

ใช่. ส่วนการล็อคของกลุ่มถูกเปิดเผยผ่าน [group_shape_lock](https://reference.aspose.com/slides/th/python-net/aspose.slides/groupshape/group_shape_lock/) ซึ่งให้คุณจำกัดการดำเนินการบนวัตถุ.