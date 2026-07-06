---
title: รับขอบเขตย่อหน้าจากการนำเสนอใน Python
linktitle: ขอบเขตย่อหน้า
type: docs
weight: 43
url: /th/python-net/paragraph-bounds/
keywords:
- ขอบเขตย่อหน้า
- พิกัดย่อหน้า
- ขนาดย่อหน้า
- กรอบข้อความ
- PowerPoint
- OpenDocument
- การนำเสนอ
- Python
- Aspose.Slides
description: "เรียนรู้วิธีดึงขอบเขตย่อหน้าใน Aspose.Slides สำหรับ Python ผ่าน .NET เพื่อปรับตำแหน่งข้อความให้เหมาะสมในงานนำเสนอ PowerPoint และ OpenDocument"
---
## **ภาพรวม**

บทความนี้อธิบายวิธีการรับขอบเขต, ขนาด และพิกัดของย่อหน้าใน Aspose.Slides โดยจะแสดงวิธีดึงสี่เหลี่ยมของย่อหน้าจาก [TextFrame](https://reference.aspose.com/slides/th/python-net/aspose.slides/textframe/) ด้วยการใช้ [Paragraph.get_rect](https://reference.aspose.com/slides/th/python-net/aspose.slides/paragraph/get_rect/), วิธีรับพิกัดของย่อหน้าในกรอบข้อความของเซลล์ตาราง, และเน้นรายละเอียดสำคัญเช่น หน่วยวัด, ผลของการตัดคำต่อขอบเขต, การแปลงเป็นพิกเซล, และค่าการจัดรูปแบบย่อหน้าที่มีประสิทธิภาพ

## **รับพิกัดสี่เหลี่ยมของย่อหน้า**

ใช้ [Paragraph.get_rect](https://reference.aspose.com/slides/th/python-net/aspose.slides/paragraph/get_rect/) เพื่อรับสี่เหลี่ยมขอบเขตของย่อหน้า

```py
import aspose.slides as slides

with slides.Presentation("Shapes.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]
    paragraph = shape.text_frame.paragraphs[0]
    rectangle = paragraph.get_rect()
```

## **รับขนาดของย่อหน้าใน TextFrame ของเซลล์ตาราง**

เพื่อรับขนาดและพิกัดของ [Paragraph](https://reference.aspose.com/slides/th/python-net/aspose.slides/paragraph/) ในกรอบข้อความของเซลล์ตาราง, ให้ใช้ [Paragraph.get_rect](https://reference.aspose.com/slides/th/python-net/aspose.slides/paragraph/get_rect/) สี่เหลี่ยมที่คืนค่าจะเป็นสัมพัทธ์กับกรอบข้อความของเซลล์ตาราง, ดังนั้นจึงต้องเพิ่มตำแหน่งของตารางและออฟเซ็ตของเซลล์เมื่อคุณต้องการพิกัดระดับสไลด์

ตัวอย่างต่อไปนี้จะรับขอบเขตของย่อหน้าในเซลล์ตารางและวาดสี่เหลี่ยมบนสไลด์เพื่อแสดงขอบเขตเหล่านั้น:

```py
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation("source.pptx") as presentation:
    slide = presentation.slides[0]
    table = slide.shapes[0]
    cell = table.rows[1][1]

    cell_x = table.x + cell.offset_x
    cell_y = table.y + cell.offset_y

    for paragraph in cell.text_frame.paragraphs:
        if paragraph.text == "":
            continue

        paragraph_rectangle = paragraph.get_rect()
        paragraph_rectangle_x = paragraph_rectangle.x + cell_x
        paragraph_rectangle_y = paragraph_rectangle.y + cell_y

        paragraph_bounds_shape = slide.shapes.add_auto_shape(
            slides.ShapeType.RECTANGLE,
            paragraph_rectangle_x,
            paragraph_rectangle_y,
            paragraph_rectangle.width,
            paragraph_rectangle.height)

        paragraph_bounds_shape.fill_format.fill_type = slides.FillType.NO_FILL
        paragraph_bounds_shape.line_format.fill_format.solid_fill_color.color = draw.Color.yellow
        paragraph_bounds_shape.line_format.fill_format.fill_type = slides.FillType.SOLID

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **คำถามที่พบบ่อย**

**พิกัดของย่อมาวัดเป็นหน่วยใด?**

พิกัดวัดเป็นจุด (points) โดยที่ 1 นิ้วเท่ากับ 72 จุด ค่าที่วัดนี้ใช้กับพิกัดและมิติทั้งหมดบนสไลด์

**การตัดคำมีผลต่อขอบเขตของย่อหน้าหรือไม่?**

ใช่ หาก [TextFrameFormat.wrap_text](https://reference.aspose.com/slides/th/python-net/aspose.slides/textframeformat/wrap_text/) ถูกเปิดใช้งานสำหรับ [TextFrame](https://reference.aspose.com/slides/th/python-net/aspose.slides/textframe/), ข้อความจะถูกตัดเพื่อให้พอดีกับความกว้างของพื้นที่ ทำให้ขอบเขตจริงของย่อหน้ามีการเปลี่ยนแปลง

**พิกัดของย่อหน้าสามารถแมปเป็นพิกเซลในภาพที่ส่งออกได้อย่างเชื่อถือได้หรือไม่?**

ได้ ใช้สูตรต่อไปนี้เพื่อแปลงจากจุดเป็นพิกเซล: pixels = points x (DPI / 72) ผลลัพธ์ขึ้นอยู่กับค่า DPI ที่เลือกสำหรับการเรนเดอร์หรือการส่งออก

**ฉันจะรับพารามิเตอร์การจัดรูปแบบย่อหน้าที่ "effective" โดยคำนึงถึงการสืบทอดสไตล์อย่างไร?**

ใช้ [โครงสร้างข้อมูลการจัดรูปแบบย่อหน้าที่มีประสิทธิภาพ](/slides/th/python-net/shape-effective-properties/) ซึ่งจะคืนค่าที่สรุปขั้นสุดท้ายของการเยื้อง, ระยะห่าง, การตัดคำ, RTL และอื่นๆ