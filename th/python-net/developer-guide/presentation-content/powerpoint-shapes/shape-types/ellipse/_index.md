---
title: เพิ่มวงรีในงานนำเสนอด้วย Python
linktitle: วงรี
type: docs
weight: 30
url: /th/python-net/ellipse/
keywords:
- วงรี
- รูปทรง
- เพิ่มวงรี
- สร้างวงรี
- วาดวงรี
- วงรีที่จัดรูปแบบ
- PowerPoint
- OpenDocument
- งานนำเสนอ
- Python
- Aspose.Slides
description: "เรียนรู้วิธีการสร้าง, จัดรูปแบบ, และจัดการรูปทรงวงรีใน Aspose.Slides for Python via .NET สำหรับงานนำเสนอ PPT, PPTX และ ODP พร้อมตัวอย่างโค้ด"
---
## **ภาพรวม**

บทความนี้แสดงวิธีการเพิ่มรูปทรงวงรีลงในสไลด์ PowerPoint โดยใช้ Aspose.Slides ครอบคลุมการสร้างวงรีแบบง่าย การสร้างวงรีที่มีการจัดรูปแบบ และการบันทึกการนำเสนอที่อัปเดตเป็นไฟล์ PPTX นอกจากนี้ยังสอดแทรกคำถามที่เกี่ยวข้อง เช่น การทำงานกับตำแหน่งและขนาดของวงรี การควบคุมลำดับการเรียงชั้น และการใช้เอฟเฟ็กต์แอนิเมชัน

## **สร้างวงรี**
ในหัวข้อนี้ เราจะอธิบายวิธีการเพิ่มรูปทรงวงรีลงในสไลด์โดยใช้ Aspose.Slides for Python via .NET Aspose.Slides for Python via .NET มีชุด API ที่ง่ายต่อการวาดรูปทรงต่าง ๆ ด้วยเพียงไม่กี่บรรทัดโค้ด เพื่อเพิ่มวงรีแบบง่ายลงในสไลด์ที่เลือกของการนำเสนอ โปรดทำตามขั้นตอนต่อไปนี้:

1. สร้างอินสแตนซ์ของ [Presentation ](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/)class
1. รับอ้างอิงของสไลด์โดยใช้ Index ของมัน
1. เพิ่ม AutoShape ชนิด Ellipse โดยใช้เมธอด AddAutoShape ที่เปิดให้ใช้งานโดยอ็อบเจ็กต์ IShapes
1. เขียนการนำเสนอที่แก้ไขแล้วเป็นไฟล์ PPTX

ในตัวอย่างด้านล่าง เราได้เพิ่มวงรีลงในสไลด์แรก

```py
import aspose.slides as slides

# สร้างอินสแตนซ์ของคลาส Presentation ที่แทนไฟล์ PPTX
with slides.Presentation() as pres:
    # รับสไลด์แรก
    sld = pres.slides[0]

    # เพิ่ม autoshape ประเภทวงรี
    sld.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 50, 150, 150, 50)

    #เขียนไฟล์ PPTX ไปยังดิสก์
    pres.save("EllipseShp1_out.pptx", slides.export.SaveFormat.PPTX)
```



## **สร้างวงรีที่จัดรูปแบบ**
เพื่อเพิ่มวงรีที่มีการจัดรูปแบบที่ดีกว่าในสไลด์ โปรดทำตามขั้นตอนต่อไปนี้:

1. สร้างอินสแตนซ์ของ [Presentation ](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/)class.
1. รับอ้างอิงของสไลด์โดยใช้ Index ของมัน.
1. เพิ่ม AutoShape ชนิด Ellipse โดยใช้เมธอด AddAutoShape ที่เปิดให้ใช้งานโดยอ็อบเจ็กต์ IShapes.
1. ตั้งค่า Fill Type ของวงรีเป็น Solid.
1. ตั้งค่าสีของวงรีโดยใช้คุณสมบัติ SolidFillColor.Color ที่เปิดให้ใช้งานโดยอ็อบเจ็กต์ FillFormat ที่เชื่อมโยงกับอ็อบเจ็กต์ IShape.
1. ตั้งค่าสีของเส้นของวงรี.
1. ตั้งค่าความกว้างของเส้นของวงรี.
1. เขียนการนำเสนอที่แก้ไขแล้วเป็นไฟล์ PPTX.

ในตัวอย่างด้านล่าง เราได้เพิ่มวงรีที่จัดรูปแบบลงในสไลด์แรกของการนำเสนอ

```py
import aspose.slides as slides
import aspose.pydrawing as draw

# สร้างอินสแตนซ์ของคลาส Presentation ที่แทนไฟล์ PPTX
with slides.Presentation() as pres:
    # รับสไลด์แรก
    sld = pres.slides[0]

    # เพิ่ม autoshape ประเภทวงรี
    shp = sld.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 50, 150, 150, 50)

    # ใช้การจัดรูปแบบบางอย่างกับรูปทรงวงรี
    shp.fill_format.fill_type = slides.FillType.SOLID
    shp.fill_format.solid_fill_color.color = draw.Color.chocolate

    # ใช้การจัดรูปแบบบางอย่างกับเส้นของวงรี
    shp.line_format.fill_format.fill_type = slides.FillType.SOLID
    shp.line_format.fill_format.solid_fill_color.color = draw.Color.black
    shp.line_format.width = 5

    #เขียนไฟล์ PPTX ไปยังดิสก์
    pres.save("EllipseShp2_out.pptx", slides.export.SaveFormat.PPTX)
```

## **คำถามที่พบบ่อย**

**ฉันจะตั้งค่าตำแหน่งและขนาดที่แน่นอนของวงรีโดยอิงหน่วยของสไลด์ได้อย่างไร?**

พิกัดและขนาดโดยทั่วไปจะระบุ **เป็นจุด** เพื่อให้ผลลัพธ์คาดเดาได้ ควรคำนวณบนพื้นฐานขนาดสไลด์และแปลงมิลลิเมตร์หรืออินช์ที่ต้องการเป็นจุดก่อนกำหนดค่า

**ฉันจะวางวงรีเหนือหรือใต้วัตถุอื่น ๆ (ควบคุมลำดับการเรียงชั้น) อย่างไร?**

ปรับลำดับการวาดของวัตถุโดยนำมันไปที่หน้าหรือส่งไปที่หลัง ซึ่งทำให้วงรีทับซ้อนกับวัตถุอื่นหรือเปิดเผยวัตถุที่อยู่ใต้มัน

**ฉันจะทำแอนิเมชันการปรากฏหรือเน้นของวงรีได้อย่างไร?**

[Apply](/slides/th/python-net/shape-animation/) เอฟเฟ็กต์การเข้าสู่, เน้น, หรือออกจากรูปทรง, และกำหนดค่า trigger และ timing เพื่อควบคุมเมื่อและวิธีที่แอนิเมชันทำงาน  