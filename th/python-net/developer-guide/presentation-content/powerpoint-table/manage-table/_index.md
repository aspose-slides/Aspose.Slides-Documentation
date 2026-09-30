---
title: จัดการตารางงานนำเสนอด้วย Python
linktitle: จัดการตาราง
type: docs
weight: 10
url: /th/python-net/manage-table/
keywords:
- เพิ่มตาราง
- สร้างตาราง
- เข้าถึงตาราง
- อัตราส่วน
- จัดแนวข้อความ
- การจัดรูปแบบข้อความ
- สไตล์ตาราง
- PowerPoint
- OpenDocument
- งานนำเสนอ
- Python
- Aspose.Slides
description: "สร้างและแก้ไขตารางในสไลด์ PowerPoint และ OpenDocument ด้วย Aspose.Slides สำหรับ Python ผ่าน .NET. ค้นหาโค้ดตัวอย่างง่ายเพื่อทำให้ขั้นตอนการทำงานกับตารางของคุณราบรื่นขึ้น."
---
## **บทนำ**

ตารางใน PowerPoint จัดระเบียบข้อมูลเป็นแถวและคอลัมน์ ทำให้อ่านและเปรียบเทียบค่าได้ง่ายขึ้น

Aspose.Slides มีคลาส [Table](https://reference.aspose.com/slides/python-net/aspose.slides/table/) และ [Cell](https://reference.aspose.com/slides/python-net/aspose.slides/cell/) รวมถึงชนิดอื่น ๆ เพื่อให้คุณสร้าง อัปเดต และจัดการตารางในงานนำเสนอ

## **สร้างตารางจากศูนย์**

สร้างตารางโดยระบุตำแหน่ง ความกว้างของคอลัมน์และความสูงของแถว หลังจากเพิ่มลงในสไลด์แล้ว คุณสามารถกำหนดรูปแบบเส้นขอบของเซลล์ รวมเซลล์ และแทรกข้อความได้

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)
2. รับอ้างอิงถึงสไลด์ตามดัชนีของมัน
3. กำหนดรายการความกว้างของคอลัมน์เป็นหน่วยจุด
4. กำหนดรายการความสูงของแถวเป็นหน่วยจุด
5. เพิ่มอ็อบเจกต์ [Table](https://reference.aspose.com/slides/python-net/aspose.slides/table/) ลงในสไลด์ผ่านเมธอด [add_table](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_table/)
6. วนลูปผ่านแต่ละ [Cell](https://reference.aspose.com/slides/python-net/aspose.slides/cell/) เพื่อกำหนดรูปแบบเส้นขอบบน, ล่าง, ขวาและซ้าย
7. รวมเซลล์สองเซลล์แรกของแถวแรกของตาราง
8. เข้าถึงเซลล์ที่รวมแล้วผ่านคุณสมบัติ [text_frame](https://reference.aspose.com/slides/python-net/aspose.slides/cell/text_frame/)
9. ตั้งค่าข้อความในเซลล์ที่รวมแล้ว
10. บันทึกงานนำเสนอที่แก้ไขแล้ว

ตัวอย่างด้านล่างสร้างตารางที่มีสามคอลัมน์และห้าแถวที่ตำแหน่ง (100, 50) จุด ใช้เส้นขอบสีแดงความกว้าง 5 จุด รวมเซลล์สองเซลล์แรกในแถวแรก และบันทึกผลลัพธ์เป็น `table.pptx`.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    column_widths = [50, 50, 50]
    row_heights = [50, 30, 30, 30, 30]
    table = slide.shapes.add_table(100, 50, column_widths, row_heights)

    for row in table.rows:
        for cell in row:
            cell_format = cell.cell_format
            cell_format.border_top.fill_format.fill_type = slides.FillType.SOLID
            cell_format.border_top.fill_format.solid_fill_color.color = draw.Color.red
            cell_format.border_top.width = 5

            cell_format.border_bottom.fill_format.fill_type = slides.FillType.SOLID
            cell_format.border_bottom.fill_format.solid_fill_color.color = draw.Color.red
            cell_format.border_bottom.width = 5

            cell_format.border_left.fill_format.fill_type = slides.FillType.SOLID
            cell_format.border_left.fill_format.solid_fill_color.color = draw.Color.red
            cell_format.border_left.width = 5

            cell_format.border_right.fill_format.fill_type = slides.FillType.SOLID
            cell_format.border_right.fill_format.solid_fill_color.color = draw.Color.red
            cell_format.border_right.width = 5

    table.merge_cells(table.rows[0][0], table.rows[0][1], False)
    table.rows[0][0].text_frame.text = "Merged Cells"

    presentation.save("table.pptx", slides.export.SaveFormat.PPTX)
```

## **การจัดลำดับในตารางมาตรฐาน**

ในตารางมาตรฐาน ดัชนีเซลล์เริ่มต้นจากศูนย์และใช้ลำดับ (คอลัมน์, แถว) เซลล์แรกมีดัชนีเป็น (0, 0) ใน Python เข้าถึงเซลล์ด้วย `table.rows[row_index][column_index]` ดัชนีแถวจะอยู่ก่อนในนิพจน์นี้

ตัวอย่างเช่น เซลล์ในตารางที่มี 4 คอลัมน์และ 4 แถวจะถูกจัดลำดับดังนี้:

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

ตัวอย่างนี้สร้างตาราง 4 × 4 ตามที่แสดงด้านบน โดยตั้งค่าความกว้างคอลัมน์และความสูงแถวเป็น 70 จุด และเส้นขอบเซลล์สีแดงความกว้าง 5 จุด พิกัดแสดงดัชนีเซลล์; ตัวอย่างปล่อยเซลล์ว่างเปล่าและบันทึกตารางเป็น `StandardTables_out.pptx`.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    column_widths = [70, 70, 70, 70]
    row_heights = [70, 70, 70, 70]
    table = slide.shapes.add_table(100, 50, column_widths, row_heights)

    for row in table.rows:
        for cell in row:
            cell_format = cell.cell_format
            cell_format.border_top.fill_format.fill_type = slides.FillType.SOLID
            cell_format.border_top.fill_format.solid_fill_color.color = draw.Color.red
            cell_format.border_top.width = 5

            cell_format.border_bottom.fill_format.fill_type = slides.FillType.SOLID
            cell_format.border_bottom.fill_format.solid_fill_color.color = draw.Color.red
            cell_format.border_bottom.width = 5

            cell_format.border_left.fill_format.fill_type = slides.FillType.SOLID
            cell_format.border_left.fill_format.solid_fill_color.color = draw.Color.red
            cell_format.border_left.width = 5

            cell_format.border_right.fill_format.fill_type = slides.FillType.SOLID
            cell_format.border_right.fill_format.solid_fill_color.color = draw.Color.red
            cell_format.border_right.width = 5

    presentation.save("StandardTables_out.pptx", slides.export.SaveFormat.PPTX)
```

## **การเข้าถึงตารางที่มีอยู่**

ตารางถูกจัดเก็บในคอลเลกชันรูปร่างของสไลด์ วนลูปผ่านรูปร่างเพื่อค้นหาตาราง แล้วใช้คลาส [Table](https://reference.aspose.com/slides/python-net/aspose.slides/table/) เพื่ออ่านหรืออัปเดตเซลล์ของมัน

1. โหลดงานนำเสนอโดยใช้คลาส [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)
2. รับอ้างอิงถึงสไลด์ที่มีตารางตามดัชนีของมัน
3. วนลูปผ่านอ็อบเจกต์ [Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/) และหยุดเมื่อพบตาราง หากสไลด์มีหลายตาราง ให้ใช้ [alternative_text](https://reference.aspose.com/slides/python-net/aspose.slides/shape/alternative_text/) เพื่อระบุตารางที่ต้องการ
4. อัปเดตข้อความในเซลล์เป้าหมาย
5. บันทึกงานนำเสนอที่แก้ไขแล้ว

ตัวอย่างด้านล่างเปิดไฟล์ `UpdateExistingTable.pptx` และค้นหาตารางแรกในสไลด์แรก ตั้งค่าเซลล์ที่คอลัมน์ 0 แถว 1 ให้เป็น `New` แล้วบันทึกผลลัพธ์เป็น `table1_out.pptx` อินพุตต้องมีอย่างน้อยหนึ่งสไลด์ และตารางแรกบนสไลด์นั้นต้องมีอย่างน้อยหนึ่งคอลัมน์และสองแถว

```python
import aspose.slides as slides

with slides.Presentation("UpdateExistingTable.pptx") as presentation:
    slide = presentation.slides[0]
    table = None

    for shape in slide.shapes:
        if isinstance(shape, slides.Table):
            table = shape
            break

    if table is not None and len(table.rows) >= 2:
        table.rows[1][0].text_frame.text = "New"
        presentation.save("table1_out.pptx", slides.export.SaveFormat.PPTX)
```

เพื่อปรับขนาดแถวในตารางที่มีอยู่และเข้าใจว่าทำไมความสูงจริงอาจเกินค่าต่ำสุดที่กำหนด โปรดดูที่ [Control Row Height](/slides/th/python-net/manage-rows-and-columns/#control-row-height)

## **ค้นหาเซลล์ที่เป็นเจ้าของ Text Frame**

เมื่อโค้ดการประมวลผลข้อความทั่วไปรับอ็อบเจกต์ [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) จากตาราง ให้ใช้คุณสมบัติ [TextFrame.parent_cell](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/parent_cell/) เพื่อดึงเซลล์ [Cell](https://reference.aspose.com/slides/python-net/aspose.slides/cell/) ที่เป็นเจ้าของ สำหรับ TextFrame ของเซลล์ตาราง [TextFrame.parent_cell](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/parent_cell/) จะถูกตั้งค่าและ [TextFrame.parent_shape](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/parent_shape/) จะเป็น `None` แม้ว่าตารางเองเป็นรูปร่างก็ตาม

พิกัดเซลล์สามารถเข้าถึงได้ผ่านคุณสมบัติแบบอ่านอย่างเดียว [Cell.first_column_index](https://reference.aspose.com/slides/python-net/aspose.slides/cell/first_column_index/) และ [Cell.first_row_index](https://reference.aspose.com/slides/python-net/aspose.slides/cell/first_row_index/) [TextFrame.parent_cell](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/parent_cell/) ยังเป็นแบบอ่านอย่างเดียวเช่นกัน: ให้การนำทางไปยังเจ้าของแต่ไม่เปลี่ยนแปลงความเป็นเจ้าของ ตรวจสอบค่า `None` ก่อนใช้งานเสมอ

สำหรับตัวอย่างสมบูรณ์ที่ระบุเจ้าของเซลล์ตารางและรูปร่าง รวมถึงรูปร่างที่เชื่อมกับโหนด SmartArt โปรดดูที่ [Search and Replace Text](/slides/th/python-net/search-and-replace-text/)

## **จัดแนวข้อความในตาราง**

คุณสามารถควบคุมการตรึงแนวตั้งและทิศทางข้อความของเซลล์ตารางแต่ละเซลล์ ตัวอย่างในส่วนนี้จัดศูนย์ข้อความในเซลล์แรกและหมุนข้อความไปที่ 270 องศา

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)
2. รับอ้างอิงถึงสไลด์ตามดัชนีของมัน
3. เพิ่มอ็อบเจกต์ [Table](https://reference.aspose.com/slides/python-net/aspose.slides/table/) ลงในสไลด์
4. เข้าถึงอ็อบเจกต์ [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) จากตาราง
5. เข้าถึง [Paragraph](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/) แรกและตั้งค่าข้อความและสี
6. ตั้งค่า [text_anchor_type](https://reference.aspose.com/slides/python-net/aspose.slides/cell/text_anchor_type/) และ [text_vertical_type](https://reference.aspose.com/slides/python-net/aspose.slides/cell/text_vertical_type/) ของเซลล์
7. บันทึกงานนำเสนอที่แก้ไขแล้ว

ตัวอย่างนี้สร้างตาราง 4 × 4 โดยความกว้างคอลัมน์ 120 จุดและความสูงแถว 100 จุด จัดรูปแบบข้อความในเซลล์ (0, 0) เพิ่มค่าให้เซลล์ที่เหลือในแถวแรกและบันทึกผลลัพธ์เป็น `Vertical_Align_Text_out.pptx`.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    column_widths = [120, 120, 120, 120]
    row_heights = [100, 100, 100, 100]
    table = slide.shapes.add_table(100, 50, column_widths, row_heights)
    table.rows[0][1].text_frame.text = "10"
    table.rows[0][2].text_frame.text = "20"
    table.rows[0][3].text_frame.text = "30"

    cell = table.rows[0][0]
    paragraph = cell.text_frame.paragraphs[0]
    portion = paragraph.portions[0]
    portion.text = "Text here"
    portion.portion_format.fill_format.fill_type = slides.FillType.SOLID
    portion.portion_format.fill_format.solid_fill_color.color = draw.Color.black

    cell.text_anchor_type = slides.TextAnchorType.CENTER
    cell.text_vertical_type = slides.TextVerticalType.VERTICAL270

    presentation.save("Vertical_Align_Text_out.pptx", slides.export.SaveFormat.PPTX)
```

## **ตั้งค่าการจัดรูปแบบข้อความระดับตาราง**

ใช้เมธอด [set_text_format](https://reference.aspose.com/slides/python-net/aspose.slides/table/set_text_format/) เพื่อกำหนดการจัดรูปแบบข้อความให้กับทุกเซลล์ในตาราง มีโอเวอร์โหลดที่รับการจัดรูปแบบส่วน, ย่อหน้าและ TextFrame ดังนั้นคุณสามารถตั้งค่าคุณสมบัติเหล่านี้ได้โดยไม่ต้องวนลูปผ่านเซลล์แต่ละเซลล์

1. โหลดงานนำเสนอโดยใช้คลาส [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)
2. รับอ้างอิงถึงสไลด์ตามดัชนีของมัน
3. เข้าถึงอ็อบเจกต์ [Table](https://reference.aspose.com/slides/python-net/aspose.slides/table/) จากสไลด์
4. ตั้งค่า [font_height](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/font_height/) สำหรับข้อความ
5. ตั้งค่า [alignment](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/alignment/) และ [margin_right](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/margin_right/)
6. ตั้งค่า [text_vertical_type](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/text_vertical_type/)
7. บันทึกงานนำเสนอที่แก้ไขแล้ว

ตัวอย่างด้านล่างเปิดไฟล์ `table.pptx` ซึ่งต้องมีอย่างน้อยหนึ่งสไลด์ที่มีตารางเป็นรูปร่างแรก ตั้งค่าขนาดฟอนต์เป็น 25 จุด จัดย่อหน้าให้ชิดขวาด้วยระยะขอบขวา 20 จุด และทำให้ข้อความเป็นแนวตั้ง งานนำเสนอที่จัดรูปแบบแล้วบันทึกเป็น `result.pptx`.

```python
import aspose.slides as slides

with slides.Presentation("table.pptx") as presentation:
    slide = presentation.slides[0]
    table = slide.shapes[0]

    portion_format = slides.PortionFormat()
    portion_format.font_height = 25
    table.set_text_format(portion_format)

    paragraph_format = slides.ParagraphFormat()
    paragraph_format.alignment = slides.TextAlignment.RIGHT
    paragraph_format.margin_right = 20
    table.set_text_format(paragraph_format)

    text_frame_format = slides.TextFrameFormat()
    text_frame_format.text_vertical_type = slides.TextVerticalType.VERTICAL
    table.set_text_format(text_frame_format)

    presentation.save("result.pptx", slides.export.SaveFormat.PPTX)
```

## **รับคุณสมบัติสไตล์ของตาราง**

ใช้คุณสมบัติ [style_preset](https://reference.aspose.com/slides/python-net/aspose.slides/table/style_preset/) เพื่ออ่านหรือกำหนดสไตล์สำเร็จรูปของตาราง ตัวอย่างนี้ใช้ [TableStylePreset.DARK_STYLE1](https://reference.aspose.com/slides/python-net/aspose.slides/tablestylepreset/) กับตารางหนึ่ง พิมพ์ชื่อสไตล์สำเร็จรูป แล้วกำหนดสไตล์เดียวกันกับตารางที่สอง ทั้งสองตารางบันทึกเป็น `table-style.pptx`.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    column_widths = [100, 150]
    row_heights = [5, 5, 5]
    table = slide.shapes.add_table(10, 10, column_widths, row_heights)
    table.style_preset = slides.TableStylePreset.DARK_STYLE1

    style_preset = table.style_preset
    print(f"Table style preset: {style_preset.name}")

    another_table = slide.shapes.add_table(10, 100, column_widths, row_heights)
    another_table.style_preset = style_preset

    presentation.save("table-style.pptx", slides.export.SaveFormat.PPTX)
```

## **ล็อกอัตราส่วนของตาราง**

อัตราส่วนของตารางคืออัตราระหว่างความกว้างและความสูง ใช้คุณสมบัติ [aspect_ratio_locked](https://reference.aspose.com/slides/python-net/aspose.slides/graphicalobjectlock/aspect_ratio_locked/) เพื่อบังคับล็อกอัตราส่วนนี้สำหรับตาราง

ตัวอย่างด้านล่างเปิดไฟล์ `pres.pptx` ซึ่งต้องมีอย่างน้อยหนึ่งสไลด์ที่มีตารางเป็นรูปร่างแรก พิมพ์สถานะล็อกปัจจุบัน เปิดล็อกอัตราส่วน แล้วพิมพ์สถานะที่อัปเดต (`True`) และบันทึกผลลัพธ์เป็น `pres-out.pptx`.

```python
import aspose.slides as slides

with slides.Presentation("pres.pptx") as presentation:
    slide = presentation.slides[0]
    table = slide.shapes[0]

    print(f"Lock aspect ratio set: {table.shape_lock.aspect_ratio_locked}")
    
    table.shape_lock.aspect_ratio_locked = True
    print(f"Lock aspect ratio set: {table.shape_lock.aspect_ratio_locked}")

    presentation.save("pres-out.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**ฉันสามารถเปิดใช้งานการอ่านจากขวาไปซ้าย (RTL) สำหรับตารางทั้งหมดและข้อความในเซลล์ได้หรือไม่?**

ได้ ตารางมีคุณสมบัติ [right_to_left](https://reference.aspose.com/slides/python-net/aspose.slides/table/right_to_left/) และย่อหน้ามี [ParagraphFormat.right_to_left](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/right_to_left/) ใช้ทั้งสองจะทำให้ลำดับและการแสดงผล RTL ถูกต้องภายในเซลล์

**ฉันจะป้องกันไม่ให้ผู้ใช้ย้ายหรือปรับขนาดตารางในไฟล์สุดท้ายได้อย่างไร?**

ใช้ [shape locks](/slides/th/python-net/applying-protection-to-presentation/) เพื่อปิดการย้าย, ปรับขนาด, การเลือก เป็นต้น ล็อกเหล่านี้ใช้ได้กับตารางด้วยเช่นกัน

**การแทรกรูปภาพเป็นพื้นหลังภายในเซลล์ได้รับการสนับสนุนหรือไม่?**

ได้ คุณสามารถตั้งค่า [picture fill](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/) สำหรับเซลล์ รูปภาพจะครอบพื้นที่เซลล์ตามโหมดที่เลือก (ขยายหรือวางซ้ำ)