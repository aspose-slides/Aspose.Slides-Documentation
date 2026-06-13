---
title: รับขอบเขตย่อหน้าจากงานนำเสนอใน Python
linktitle: ย่อหน้า
type: docs
weight: 60
url: /th/python-net/paragraph/
keywords:
- ขอบเขตย่อหน้า
- ขอบเขตส่วนข้อความ
- พิกัดย่อหน้า
- พิกัดส่วน
- ขนาดย่อหน้า
- ขนาดส่วนข้อความ
- กรอบข้อความ
- PowerPoint
- OpenDocument
- งานนำเสนอ
- Python
- Aspose.Slides
description: "เรียนรู้วิธีการดึงขอบเขตย่อหน้าและส่วนข้อความใน Aspose.Slides สำหรับ Python ผ่าน .NET เพื่อเพิ่มประสิทธิภาพการจัดตำแหน่งข้อความในงานนำเสนอ PowerPoint และ OpenDocument"
---
## **ภาพรวม**

บทความนี้อธิบายวิธีการรับค่าขอบเขต, ขนาด, และพิกัดของย่อหน้าและส่วนข้อความใน Aspose.Slides แสดงวิธีการดึงสี่เหลี่ยมของย่อหน้าใน `TextFrame` ด้วยการใช้ `get_rect()`, วิธีการรับพิกัดของย่อหน้าและส่วนภายใน TextFrame ของเซลล์ตาราง, รวมถึงรายละเอียดสำคัญเช่น หน่วยวัด, ผลของการห่อข้อความต่อขอบเขต, การแปลงเป็นพิกเซล, และค่าการจัดรูปแบบย่อหน้าแบบ effective

## **รับพิกัดย่อหน้าและส่วนใน TextFrame**
โดยใช้ Aspose.Slides for Python via .NET นักพัฒนาสามารถรับพิกัดสี่เหลี่ยมของ Paragraph ภายในคอลเลกชันของ TextFrame ได้ นอกจากนี้ยังสามารถรับพิกัดของ Portion ภายในคอลเลกชันของ Paragraph ได้อีกด้วย ในหัวข้อนี้เราจะสาธิตด้วยตัวอย่างวิธีการรับพิกัดสี่เหลี่ยมของย่อหน้าพร้อมตำแหน่งของ Portion ภายในย่อหน้า

## **รับพิกัดสี่เหลี่ยมของย่อหน้า**
มีการเพิ่มเมธอดใหม่ **GetRect()** ซึ่งทำให้สามารถรับสี่เหลี่ยมขอบเขตของย่อหน้าได้

```py
import aspose.slides as slides

# สร้างอ็อบเจกต์ Presentation ที่แสดงถึงไฟล์งานนำเสนอ
with slides.Presentation(path + "Shapes.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]
    textFrame = shape.text_frame
    rect = textFrame.paragraphs[0].get_rect()
```

## **รับขนาดของย่อหน้าและส่วนภายใน TextFrame ของเซลล์ตาราง** ##

เพื่อรับขนาดและพิกัดของ [ส่วน](https://reference.aspose.com/slides/th/python-net/aspose.slides/portion/) หรือ [ย่อหน้า](https://reference.aspose.com/slides/th/python-net/aspose.slides/paragraph/) ใน TextFrame ของเซลล์ตาราง คุณสามารถใช้เมธอด [IPortion.GetRect](https://reference.aspose.com/slides/th/python-net/aspose.slides/iportion/) และ [IParagraph.GetRect](https://reference.aspose.com/slides/th/python-net/aspose.slides/iparagraph/) ได้

โค้ดตัวอย่างนี้แสดงการทำงานที่อธิบายไว้:

```py
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation(path + "source.pptx") as pres:
    tbl = pres.slides[0].shapes[0]

    cell = tbl.rows[1][1]


    x = tbl.X + tbl.rows[1][1].offset_x
    y = tbl.Y + tbl.rows[1][1].offset_y

    for para in cell.text_frame.paragraphs:
        if para.text == "":
            continue

        rect = para.get_rect()
        shape = pres.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE,
                rect.x + x, rect.y + y, rect.width, rect.height)

        shape.fill_format.fill_type = slides.FillType.NO_FILL
        shape.line_format.fill_format.solid_fill_color.color = draw.Color.yellow
        shape.line_format.fill_format.fill_type = slides.FillType.SOLID

        for portion in para.portions:
            if "0" in portion.text:
                rect = portion.get_rect()
                shape = pres.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE,
                        rect.x + x, rect.y + y, rect.width, rect.height)

                shape.fill_format.fill_type = slides.FillType.NO_FILL
```

## **คำถามที่พบบ่อย**

**หน่วยที่ใช้ในการวัดพิกัดที่ส่งกลับสำหรับย่อหน้าและส่วนข้อความคืออะไร?**

ในหน่วยพอยต์, โดยที่ 1 นิ้ว = 72 พอยต์. ค่านี้ใช้กับพิกัดและมิติทั้งหมดบนสไลด์

**การตัดบรรทัดอัตโนมัติมีผลต่อขอบเขตของย่อหน้าหรือไม่?**

ใช่. หากเปิดการห่อข้อความ([wrapping](https://reference.aspose.com/slides/th/python-net/aspose.slides/textframeformat/wrap_text/)) ใน [TextFrame](https://reference.aspose.com/slides/th/python-net/aspose.slides/textframe/), ข้อความจะตัดบรรทัดให้พอดีกับความกว้างของพื้นที่, ซึ่งทำให้ขอบเขตของย่อหน้าจริงเปลี่ยนไป

**สามารถแมพพิกัดของย่อหน้าเป็นพิกเซลในภาพที่ส่งออกได้อย่างเชื่อถือได้หรือไม่?**

ใช่. แปลงพอยต์เป็นพิกเซลโดยใช้: pixels = points × (DPI / 72). ผลลัพธ์ขึ้นอยู่กับ DPI ที่เลือกสำหรับการเรนเดอร์/ส่งออก

**จะดึงพารามิเตอร์การจัดรูปแบบย่อหน้าแบบ "effective" อย่างไรโดยคำนึงถึงการสืบทอดสไตล์?**

ใช้ [effective paragraph formatting data structure](/slides/th/python-net/shape-effective-properties/); มันจะส่งค่าที่สรุปขั้นสุดท้ายสำหรับการเยื้อง, ระยะห่าง, การห่อ, RTL, และอื่น ๆ