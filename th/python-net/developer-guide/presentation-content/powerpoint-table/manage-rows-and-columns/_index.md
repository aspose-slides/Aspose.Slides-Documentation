---
title: จัดการแถวและคอลัมน์ในตาราง PowerPoint ด้วย Python
linktitle: แถวและคอลัมน์
type: docs
weight: 20
url: /th/python-net/manage-rows-and-columns/
keywords:
- แถวตาราง
- คอลัมน์ตาราง
- แถวแรก
- ส่วนหัวตาราง
- คัดลอกแถว
- คัดลอกคอลัมน์
- คัดลอกแถว
- คัดลอกคอลัมน์
- ลบแถว
- ลบคอลัมน์
- การจัดรูปแบบข้อความในแถว
- การจัดรูปแบบข้อความในคอลัมน์
- สไตล์ตาราง
- PowerPoint
- การนำเสนอ
- Python
- Aspose.Slides
description: "จัดการแถวและคอลัมน์ของตารางใน PowerPoint และ OpenDocument ด้วย Aspose.Slides for Python ผ่าน .NET เพื่อเร่งการแก้ไขการนำเสนอและการอัปเดตข้อมูล."
---
## **ภาพรวม**

บทความนี้แสดงวิธีจัดการแถวและคอลัมน์ของตารางในงานนำเสนอ PowerPoint และ OpenDocument โดยใช้ Aspose.Slides for Python คุณจะได้เรียนรู้วิธีเพิ่ม แทรก คัดลอก และลบแถวหรือคอลัมน์ กำหนดให้แถวแรกเป็นส่วนหัว ปรับขนาดและเค้าโครง และใช้รูปแบบข้อความและสไตล์ในระดับแถวหรือคอลัมน์ งานแต่ละอย่างจะแสดงด้วยตัวอย่างโค้ดสั้น ๆ ที่เป็นอิสระโดยอิงจาก API [Table](https://reference.aspose.com/slides/th/python-net/aspose.slides/table/) เพื่อให้คุณสามารถค้นหาตารางบนสไลด์ได้อย่างรวดเร็วและปรับโครงสร้างเพื่อตรงกับการออกแบบของคุณ

## **กำหนดแถวแรกเป็นส่วนหัว**

ทำเครื่องหมายให้แถวแรกของตารางเป็นส่วนหัวเพื่อให้แยกความแตกต่างระหว่างชื่อคอลัมน์และข้อมูลได้ชัดเจน ใน Aspose.Slides for Python เพียงเปิดใช้งานตัวเลือก *First Row* ของตารางเพื่อใช้รูปแบบส่วนหัวที่กำหนดโดยสไตล์ตารางที่เลือก

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/) แล้วโหลดงานนำเสนอ
1. เข้าถึงสไลด์ตามดัชนี
1. วนลูปผ่านวัตถุ [Shape](https://reference.aspose.com/slides/th/python-net/aspose.slides/shape/) ทั้งหมดเพื่อค้นหาตารางที่ต้องการ
1. ตั้งค่าให้แถวแรกของตารางเป็นส่วนหัว

โค้ด Python นี้แสดงวิธีกำหนดให้แถวแรกของตารางเป็นส่วนหัว:

```python
import aspose.slides as slides

# สร้างอินสแตนซ์ของคลาส Presentation.
with slides.Presentation("table.pptx") as presentation:
    # เข้าถึงสไลด์แรก.
    slide = presentation.slides[0]

    # วนลูปผ่านรูปร่างทั้งหมดและรับการอ้างอิงถึงตาราง.
    for shape in slide.shapes:
        if type(shape) is slides.Table:
            table = shape
            break

    # กำหนดให้แถวแรกของตารางเป็นส่วนหัว.
    table.first_row = True
    
    # บันทึกการนำเสนอลงในดิสก์.
    presentation.save("table_out.pptx", slides.export.SaveFormat.PPTX)
```

## **คัดลอกแถวหรือคอลัมน์ของตาราง**

คัดลอกแถวหรือคอลัมน์ใด ๆ ของตารางแล้วใส่สำเนาที่ตำแหน่งที่ต้องการในตาราง การทำสำเนาจะรักษาเนื้อหาเซลล์ การจัดรูปแบบ และขนาดไว้ ทำให้คุณขยายเค้าโครงได้อย่างรวดเร็วและสอดคล้องกัน

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/) แล้วโหลดงานนำเสนอ
1. เข้าถึงสไลด์ตามดัชนี
1. กำหนดอาเรย์ของความกว้างคอลัมน์
1. กำหนดอาเรย์ของความสูงแถว
1. เพิ่ม [Table](https://reference.aspose.com/slides/th/python-net/aspose.slides/table/) ลงในสไลด์โดยใช้ `add_table(x, y, column_widths, row_heights)`
1. คัดลอกแถวของตาราง
1. คัดลอกคอลัมน์ของตาราง
1. บันทึกงานนำเสนอที่แก้ไขแล้ว

โค้ด Python นี้แสดงวิธีคัดลอกแถวและคอลัมน์ของตาราง PowerPoint:

```python
 import aspose.slides as slides

# สร้างอินสแตนซ์ของคลาส Presentation.
with slides.Presentation() as presentation:
    # เข้าถึงสไลด์แรก.
    slide = presentation.slides[0]

    # กำหนดความกว้างของคอลัมน์และความสูงของแถว.
    column_widths = [50, 50, 50]
    row_heights = [50, 30, 30, 30, 30]

    # เพิ่มตารางลงในสไลด์.
    table = slide.shapes.add_table(100, 50, column_widths, row_heights)

    # เพิ่มข้อความในแถว 1, คอลัมน์ 1.
    table.rows[0][0].text_frame.text = "Row 1 Cell 1"

    # เพิ่มข้อความในแถว 2, คอลัมน์ 1.
    table.rows[1][0].text_frame.text = "Row 1 Cell 2"

    # คัดลอกแถว 1 ไปยังส่วนท้ายของตาราง.
    table.rows.add_clone(table.rows[0], False)

    # เพิ่มข้อความในแถว 1, คอลัมน์ 2.
    table.rows[0][1].text_frame.text = "Row 2 Cell 1"

    # เพิ่มข้อความในแถว 2, คอลัมน์ 2.
    table.rows[1][1].text_frame.text = "Row 2 Cell 2"

    # คัดลอกแถว 2 เป็นแถวที่ 4 ของตาราง.
    table.rows.insert_clone(3,table.rows[1], False)

    # คัดลอกคอลัมน์แรกไปยังส่วนท้าย.
    table.columns.add_clone(table.columns[0], False)

    # คัดลอกคอลัมน์ที่สองที่ดัชนี 3 (ตำแหน่งที่ 4).
    table.columns.insert_clone(3,table.columns[1], False)
    
    # บันทึกการนำเสนอลงในดิสก์.
    presentation.save("table_out.pptx", slides.export.SaveFormat.PPTX)
```

## **ลบแถวหรือคอลัมน์จากตาราง**

ทำให้ตารางเรียบง่ายขึ้นโดยลบแถวหรือคอลัมน์ตามดัชนีด้วย Aspose.Slides for Python — เค้าโครงจะปรับใหม่โดยอัตโนมัติในขณะที่คงรูปแบบของเซลล์ที่เหลือไว้ สิ่งนี้มีประโยชน์สำหรับการทำตารางข้อมูลให้สั้นลงหรือการลบตัวแสดงตำแหน่งโดยไม่ต้องสร้างตารางใหม่

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/) แล้วโหลดงานนำเสนอ
1. เข้าถึงสไลด์ตามดัชนี
1. กำหนดอาเรย์ของความกว้างคอลัมน์
1. กำหนดอาเรย์ของความสูงแถว
1. เพิ่ม ITable ลงในสไลด์โดยใช้ `add_table(x, y, column_widths, row_heights)`
1. ลบแถวของตาราง
1. ลบคอลัมน์ของตาราง
1. บันทึกงานนำเสนอที่แก้ไขแล้ว

โค้ด Python ต่อไปนี้แสดงวิธีลบแถวและคอลัมน์จากตาราง:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    
    column_widths = [100, 50, 30]
    row_heights = [30, 50, 30]

    table = slide.shapes.add_table(100, 100, column_widths, row_heights)
    table.rows.remove_at(1, False)
    table.columns.remove_at(1, False)

    presentation.save("TestTable_out.pptx", slides.export.SaveFormat.PPTX)
```

## **กำหนดรูปแบบข้อความระดับแถวของตาราง**

ใช้สไตล์ข้อความแบบสม่ำเสมอกับแถวทั้งหมดของตารางในขั้นตอนเดียว ด้วย Aspose.Slides for Python คุณสามารถตั้งค่าแบบอักษร ขนาด น้ำหนัก สี และการจัดแนวสำหรับเซลล์ทั้งหมดในแถวพร้อมกัน เพื่อให้หัวเรื่องหรือแถบข้อมูลมีความสอดคล้อง

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/) แล้วโหลดงานนำเสนอ
1. เข้าถึงสไลด์ตามดัชนี
1. เข้าถึงอ็อบเจ็กต์ [Table](https://reference.aspose.com/slides/th/python-net/aspose.slides/table/) ที่เกี่ยวข้องบนสไลด์
1. ตั้งค่าสูงของฟอนต์สำหรับเซลล์ในแถวแรก
1. ตั้งค่าการจัดแนวและระยะขอบด้านขวาสำหรับเซลล์ในแถวแรก
1. ตั้งค่าชนิดการวางแนวตั้งของข้อความสำหรับเซลล์ในแถวที่สอง
1. บันทึกงานนำเสนอที่แก้ไขแล้ว

โค้ด Python นี้แสดงการทำงาน:

```python
import aspose.slides as slides

# สร้างอินสแตนซ์ของคลาส Presentation.
with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    table = slide.shapes.add_table(100, 100, [100, 50, 30], [30, 50, 30])

    # ตั้งค่าสูงของฟอนต์สำหรับเซลล์ในแถวแรก.
    portion_format = slides.PortionFormat()
    portion_format.font_height = 25
    table.rows[0].set_text_format(portion_format)

    # ตั้งค่าการจัดแนวข้อความและระยะขอบขวาสำหรับเซลล์ในแถวแรก.
    paragraph_format = slides.ParagraphFormat()
    paragraph_format.alignment = slides.TextAlignment.RIGHT
    paragraph_format.margin_right = 20
    table.rows[0].set_text_format(paragraph_format)

    # ตั้งค่าชนิดการวางแนวตั้งของข้อความสำหรับเซลล์ในแถวที่สอง.
    text_frame_format = slides.TextFrameFormat()
    text_frame_format.text_vertical_type = slides.TextVerticalType.VERTICAL
    table.rows[1].set_text_format(text_frame_format)
	
    # บันทึกการนำเสนอลงในดิสก์.
    presentation.save("result.pptx", slides.export.SaveFormat.PPTX)
```

## **กำหนดรูปแบบข้อความระดับคอลัมน์ของตาราง**

ใช้สไตล์ข้อความแบบสม่ำเสมอกับคอลัมน์ทั้งหมดของตารางในขั้นตอนเดียว ด้วย Aspose.Slides for Python คุณสามารถตั้งค่าแบบอักษร ขนาด น้ำหนัก สี และการจัดแนวสำหรับเซลล์ทั้งหมดในคอลัมน์เพื่อสร้างแถบแนวตั้งที่สอดคล้องสำหรับหัวเรื่องหรือข้อมูล

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/) แล้วโหลดงานนำเสนอ
1. เข้าถึงสไลด์ตามดัชนี
1. เข้าถึงอ็อบเจ็กต์ [Table](https://reference.aspose.com/slides/th/python-net/aspose.slides/table/) ที่เกี่ยวข้องบนสไลด์
1. ตั้งค่าสูงของฟอนต์สำหรับเซลล์ในคอลัมน์แรก
1. ตั้งค่าการจัดแนวและระยะขอบด้านขวาสำหรับเซลล์ในคอลัมน์แรก
1. ตั้งค่าชนิดการวางแนวตั้งของข้อความสำหรับเซลล์ในคอลัมน์ที่สอง
1. บันทึกงานนำเสนอที่แก้ไขแล้ว

โค้ด Python ต่อไปนี้แสดงการทำงาน:

```python
import aspose.slides as slides

# สร้างอินสแตนซ์ของคลาส Presentation.
with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    table = slide.shapes.add_table(100, 100, [100, 50, 30], [30, 50, 30])

    # ตั้งค่าสูงของฟอนต์สำหรับเซลล์ในคอลัมน์แรก.
    portion_format = slides.PortionFormat()
    portion_format.font_height = 25
    table.columns[0].set_text_format(portion_format)

    # ตั้งค่าการจัดแนวข้อความและระยะขอบขวาสำหรับเซลล์ในคอลัมน์แรก.
    paragraph_format = slides.ParagraphFormat()
    paragraph_format.alignment = slides.TextAlignment.RIGHT
    paragraph_format.margin_right = 20
    table.columns[0].set_text_format(paragraph_format)

    # ตั้งค่าชนิดการวางแนวตั้งของข้อความสำหรับเซลล์ในคอลัมน์ที่สอง.
    text_frame_format = slides.TextFrameFormat()
    text_frame_format.text_vertical_type = slides.TextVerticalType.VERTICAL
    table.columns[1].set_text_format(text_frame_format)

    # บันทึกการนำเสนอลงในดิสก์.
    presentation.save("result.pptx", slides.export.SaveFormat.PPTX)
```

## **รับคุณสมบัติสไตล์ของตาราง**

Aspose.Slides ให้คุณเรียกคืนคุณสมบัติสไตล์ของตารางเพื่อใช้ซ้ำกับตารางอื่นหรือที่อื่น โค้ด Python ต่อไปนี้แสดงวิธีดึงคุณสมบัติสไตล์จากสไตล์ตารางที่กำหนดไว้ล่วงหน้า:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    table = slide.shapes.add_table(10, 10, [100, 150], [5, 5, 5])
    table.style_preset = slides.TableStylePreset.DARK_STYLE1

    presentation.save("table.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**ฉันสามารถใช้ธีม/สไตล์ของ PowerPoint กับตารางที่สร้างแล้วได้หรือไม่?**

ได้ ตารางสืบทอดธีมของสไลด์/เลเอาต์/มาสเตอร์ และคุณยังสามารถเขียนทับการเติมสี เส้นขอบ และสีข้อความเหนือธีมนั้นได้

**ฉันสามารถจัดเรียงแถวของตารางเหมือนใน Excel ได้หรือไม่?**

ไม่ได้ ตารางของ Aspose.Slides ไม่มีการจัดเรียงหรือฟิลเตอร์ในตัว จัดเรียงข้อมูลในหน่วยความจำก่อนแล้วค่อยเติมแถวตารางตามลำดับนั้นใหม่

**ฉันสามารถทำคอลัมน์แบบลายเส้น (banded) พร้อมสีเฉพาะเซลล์ได้หรือไม่?**

ได้ เปิดใช้งานคอลัมน์แบบลายเส้น จากนั้นเขียนทับเซลล์ที่ต้องการด้วยการจัดรูปแบบท้องถิ่น; การจัดรูปแบบระดับเซลล์จะมีสิทธิ์เหนือสไตล์ของตาราง