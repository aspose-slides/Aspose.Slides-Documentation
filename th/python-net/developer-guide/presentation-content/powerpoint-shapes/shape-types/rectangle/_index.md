---
title: เพิ่มสี่เหลี่ยมผืนผ้าในงานนำเสนอด้วย Python
linktitle: สี่เหลี่ยมผืนผ้า
type: docs
weight: 80
url: /th/python-net/rectangle/
keywords:
- เพิ่มสี่เหลี่ยมผืนผ้า
- สร้างสี่เหลี่ยมผืนผ้า
- รูปร่างสี่เหลี่ยมผืนผ้า
- สี่เหลี่ยมผืนผ้าง่าย
- สี่เหลี่ยมผืนผ้าแบบจัดรูปแบบ
- PowerPoint
- OpenDocument
- การนำเสนอ
- Python
- Aspose.Slides
description: "เพิ่มพลังให้กับการนำเสนอ PowerPoint และ OpenDocument ของคุณโดยการเพิ่มสี่เหลี่ยมผืนผ้าด้วย Aspose.Slides สำหรับ Python ผ่าน .NET—ออกแบบและแก้ไขรูปร่างได้อย่างง่ายดายโดยใช้โปรแกรม"
---
## **ภาพรวม**

บทความนี้แสดงวิธีเพิ่มรูปสี่เหลี่ยมผืนผ้าไปยังสไลด์ PowerPoint ด้วยการใช้ Aspose.Slides ซึ่งครอบคลุมการสร้างสี่เหลี่ยมผืนผ้าแบบง่าย การสร้างสี่เหลี่ยมผืนผ้าแบบจัดรูปแบบ และการบันทึกการนำเสนอที่อัปเดตเป็นไฟล์ PPTX

คุณยังจะได้เห็นวิธีใช้การจัดรูปแบบสี่เหลี่ยมพื้นฐาน เช่น สีเติมแบบทึบ สีเส้น และความกว้างของเส้น นอกจากนี้ส่วนคำถามที่พบบ่อยของบทความยังชี้ไปยังงานที่เกี่ยวข้องกับสี่เหลี่ยม เช่น มุมโค้ง การเติมรูปภาพ เอฟเฟกต์ภาพเคลื่อนไหว ไฮเปอร์ลิงก์ การล็อกรูปร่าง ตัวเลือกการส่งออก และคุณสมบัติที่มีผล

## **สร้างสี่เหลี่ยมผืนผ้าแบบง่าย**
เช่นเดียวกับหัวข้อก่อนหน้า หัวข้อนี้ก็เกี่ยวกับการเพิ่มรูปร่างและครั้งนี้เราจะพูดถึงสี่เหลี่ยมผืนผ้า ในหัวข้อนี้เราได้อธิบายว่าผู้พัฒนาสามารถเพิ่มสี่เหลี่ยมผืนผ้าแบบง่ายหรือแบบจัดรูปแบบลงในสไลด์ของตนโดยใช้ Aspose.Slides for Python via .NET วิธีเพิ่มสี่เหลี่ยมผืนผ้าแบบง่ายไปยังสไลด์ที่เลือกของการนำเสนอ โปรดทำตามขั้นตอนต่อไปนี้:

1. สร้างอินสแตนซ์ของ [Presentation ](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/)class.
1. รับอ้างอิงของสไลด์โดยใช้ Index ของมัน.
1. เพิ่ม IAutoShape ประเภท Rectangle ด้วยวิธี AddAutoShape ที่เปิดให้ใช้งานโดยออบเจ็กต์ IShapes.
1. เขียนการนำเสนอที่แก้ไขแล้วเป็นไฟล์ PPTX.

ในตัวอย่างด้านล่าง เราได้เพิ่มสี่เหลี่ยมผืนผ้าแบบง่ายไปยังสไลด์แรกของการนำเสนอ

```py
import aspose.slides as slides

# สร้างอินสแตนซ์ของคลาส Presentation ที่เป็นตัวแทนของไฟล์ PPTX
with slides.Presentation() as pres:
    # ดึงสไลด์แรก
    sld = pres.slides[0]

    # เพิ่ม autoshape ประเภทสี่เหลี่ยมผืนผ้า
    sld.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 150, 150, 50)

    #เขียนไฟล์ PPTX ลงดิสก์
    pres.save("RectShp1_out.pptx", slides.export.SaveFormat.PPTX)
```

## **สร้างสี่เหลี่ยมผืนผ้าแบบจัดรูปแบบ**
เพื่อเพิ่มสี่เหลี่ยมผืนผ้าแบบจัดรูปแบบไปยังสไลด์ โปรดทำตามขั้นตอนต่อไปนี้:

1. สร้างอินสแตนซ์ของ [Presentation ](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/)class.
1. รับอ้างอิงของสไลด์โดยใช้ Index ของมัน.
1. เพิ่ม IAutoShape ประเภท Rectangle ด้วยวิธี AddAutoShape ที่เปิดให้ใช้งานโดยออบเจ็กต์ IShapes.
1. ตั้งค่า Fill Type ของสี่เหลี่ยมผืนผ้าเป็น Solid.
1. ตั้งค่าสีของสี่เหลี่ยมผืนผ้าโดยใช้คุณสมบัติ SolidFillColor.Color ที่เปิดให้ใช้งานโดยออบเจ็กต์ FillFormat ที่เชื่อมกับออบเจ็กต์ IShape.
1. ตั้งค่าสีของเส้นของสี่เหลี่ยมผืนผ้า.
1. ตั้งค่าความกว้างของเส้นของสี่เหลี่ยมผืนผ้า.
1. เขียนการนำเสนอที่แก้ไขแล้วเป็นไฟล์ PPTX.
   ขั้นตอนข้างต้นได้ถูกดำเนินการในตัวอย่างด้านล่าง

```py
import aspose.slides as slides
import aspose.pydrawing as draw

# สร้างอินสแตนซ์ของคลาส Presentation ที่เป็นตัวแทนของไฟล์ PPTX
with slides.Presentation() as pres:
    # ดึงสไลด์แรก
    sld = pres.slides[0]

    # เพิ่ม autoshape ประเภทสี่เหลี่ยมผืนผ้า
    shp = sld.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 150, 150, 50)

    # ปรับการจัดรูปแบบบางอย่างให้กับรูปร่างสี่เหลี่ยมผืนผ้า
    shp.fill_format.fill_type = slides.FillType.SOLID
    shp.fill_format.solid_fill_color.color = draw.Color.chocolate

    # ปรับการจัดรูปแบบบางอย่างให้กับเส้นของสี่เหลี่ยมผืนผ้า
    shp.line_format.fill_format.fill_type = slides.FillType.SOLID
    shp.line_format.fill_format.solid_fill_color.color = draw.Color.black
    shp.line_format.width = 5

    #เขียนไฟล์ PPTX ลงดิสก์
    pres.save("RectShp2_out.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**วิธีเพิ่มสี่เหลี่ยมผืนผ้าพร้อมมุมโค้งคืออย่างไร?**

ใช้ประเภทรูปร่าง [shape type](https://reference.aspose.com/slides/th/python-net/aspose.slides/shapetype/) ที่มีมุมโค้งและปรับรัศมีของมุมในคุณสมบัติของรูปร่าง; สามารถกำหนดมุมโค้งแยกตามแต่ละมุมได้โดยการปรับรูปทรงเรขาคณิต

**วิธีเติมสี่เหลี่ยมผืนผ้าด้วยรูปภาพ (เทกเจอร์) คืออย่างไร?**

เลือกประเภทการเติมรูปภาพ [fill type](https://reference.aspose.com/slides/th/python-net/aspose.slides/filltype/), ระบุแหล่งที่มาของรูปภาพ, แล้วกำหนดโหมด [stretching/tiling modes](https://reference.aspose.com/slides/th/python-net/aspose.slides/picturefillmode/)

**สี่เหลี่ยมผืนผ้าสามารถมีเงาและความสว่างได้หรือไม่?**

ได้. [Outer/inner shadow, glow, and soft edges](/slides/th/python-net/shape-effect/) มีให้เลือกพร้อมพารามิเตอร์ที่ปรับได้

**ฉันสามารถทำให้สี่เหลี่ยมผืนผ้าเป็นปุ่มพร้อมไฮเปอร์ลิงก์ได้หรือไม่?**

ได้. [Assign a hyperlink](/slides/th/python-net/manage-hyperlinks/) ให้กับการคลิกรูปร่าง (เช่น ไปยังสไลด์, ไฟล์, ที่อยู่เว็บ หรืออีเมล)

**วิธีป้องกันสี่เหลี่ยมผืนผ้าจากการเคลื่อนที่หรือการเปลี่ยนแปลงคืออะไร?**

[Use shape locks](/slides/th/python-net/applying-protection-to-presentation/): คุณสามารถห้ามการย้าย, ปรับขนาด, เลือก, หรือแก้ไขข้อความเพื่อรักษาเลย์เอาต์

**ฉันสามารถแปลงสี่เหลี่ยมผืนผ้าเป็นภาพราสเตอร์หรือ SVG ได้หรือไม่?**

ได้. คุณสามารถ [render the shape](http://reference.aspose.com/slides/th/python-net/aspose.slides/shape/get_image/) เป็นภาพด้วยขนาด/สเกลที่กำหนด หรือ [export it as SVG](https://reference.aspose.com/slides/th/python-net/aspose.slides/shape/write_as_svg/) เพื่อใช้งานในรูปแบบเวกเตอร์

**วิธีที่เร็วที่สุดในการรับคุณสมบัติที่แท้จริง (effective) ของสี่เหลี่ยมผืนผ้าโดยพิจารณาจากธีมและการสืบทอดคืออะไร?**

[Use the shape’s effective properties](/slides/th/python-net/shape-effective-properties/): API จะคืนค่าที่คำนวณแล้วซึ่งคำนึงถึงสไตล์ธีม, Layout, และการตั้งค่าท้องถิ่น ทำให้การวิเคราะห์การจัดรูปแบบง่ายขึ้น