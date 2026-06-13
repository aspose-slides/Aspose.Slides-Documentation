---
title: จัดการตารางการนำเสนอด้วย Python
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
description: "สร้างและแก้ไขตารางในสไลด์ PowerPoint และ OpenDocument ด้วย Aspose.Slides สำหรับ Python ผ่าน .NET. ค้นพบตัวอย่างโค้ดง่ายๆ เพื่อทำให้เวิร์กโฟลว์ของตารางของคุณเป็นระเบียบง่ายขึ้น."
---
## **บทนำ**

ตารางใน PowerPoint เป็นวิธีที่มีประสิทธิภาพในการนำเสนอข้อมูล ข้อมูลที่จัดเรียงในรูปแบบตารางของเซลล์ (แถวและคอลัมน์) นั้นเข้าใจง่ายและตรงไปตรงมา

Aspose.Slides มีคลาส [Table](https://reference.aspose.com/slides/th/python-net/aspose.slides/table/) , คลาส [Cell](https://reference.aspose.com/slides/th/python-net/aspose.slides/cell/) และประเภทที่เกี่ยวข้องอื่นๆ เพื่อช่วยคุณสร้าง, ปรับปรุง, และจัดการตารางในงานนำเสนอใดๆ

## **สร้างตารางจากศูนย์**

ส่วนนี้จะแสดงวิธีสร้างตารางจากศูนย์ใน Aspose.Slides โดยเพิ่มรูปร่างตารางลงในสไลด์, กำหนดแถวและคอลัมน์, และตั้งค่าขนาดที่แม่นยำ คุณจะได้เห็นวิธีเติมข้อความในเซลล์, ปรับการจัดตำแหน่งและเส้นขอบ, และปรับแต่งลักษณะของตาราง

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/) .
2. รับอ้างอิงไปยังสไลด์โดยใช้ดัชนีของมัน.
3. กำหนดอาเรย์ของความกว้างคอลัมน์.
4. กำหนดอาเรย์ของความสูงแถว.
5. เพิ่ม [Table](https://reference.aspose.com/slides/th/python-net/aspose.slides/table/) ลงในสไลด์.
6. วนซ้ำผ่านแต่ละ [Cell](https://reference.aspose.com/slides/th/python-net/aspose.slides/cell/) และจัดรูปแบบเส้นขอบบน, ล่าง, ขวา, และซ้ายของมัน.
7. รวมเซลล์สองเซลล์แรกในแถวแรกของตาราง.
8. เข้าถึง [TextFrame](https://reference.aspose.com/slides/th/python-net/aspose.slides/textframe/) ของ [Cell](https://reference.aspose.com/slides/th/python-net/aspose.slides/cell/) หนึ่งเซลล์.
9. เพิ่มข้อความลงใน [TextFrame](https://reference.aspose.com/slides/th/python-net/aspose.slides/textframe/).
10. บันทึกงานนำเสนอที่แก้ไขแล้ว.

ตัวอย่าง Python ด้านล่างแสดงวิธีสร้างตารางในงานนำเสนอ:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

# สร้างอินสแตนซ์ของคลาส Presentation ที่แทนไฟล์งานนำเสนอ.
with slides.Presentation() as presentation:
    # เข้าถึงสไลด์แรก.
    slide = presentation.slides[0]

    # กำหนดความกว้างของคอลัมน์และความสูงของแถว.
    column_widths = [50, 50, 50]
    row_heights = [50, 30, 30, 30, 30]

    # เพิ่มรูปร่างตารางลงบนสไลด์.
    table = slide.shapes.add_table(100, 50, column_widths, row_heights)

    # ตั้งค่ารูปแบบเส้นขอบสำหรับแต่ละเซลล์.
    for row in table.rows:
        for cell in row:
            cell.cell_format.border_top.fill_format.fill_type = slides.FillType.SOLID
            cell.cell_format.border_top.fill_format.solid_fill_color.color = draw.Color.red
            cell.cell_format.border_top.width = 5

            cell.cell_format.border_bottom.fill_format.fill_type = slides.FillType.SOLID
            cell.cell_format.border_bottom.fill_format.solid_fill_color.color= draw.Color.red
            cell.cell_format.border_bottom.width = 5

            cell.cell_format.border_left.fill_format.fill_type = slides.FillType.SOLID
            cell.cell_format.border_left.fill_format.solid_fill_color.color =draw.Color.red
            cell.cell_format.border_left.width = 5

            cell.cell_format.border_right.fill_format.fill_type = slides.FillType.SOLID
            cell.cell_format.border_right.fill_format.solid_fill_color.color = draw.Color.red
            cell.cell_format.border_right.width = 5
        
    # รวมเซลล์จาก (row 0, col 0) ถึง (row 1, col 1).
    table.merge_cells(table.rows[0][0], table.rows[1][1], False)

    # เพิ่มข้อความลงในเซลล์ที่รวม.
    table.rows[0][0].text_frame.text = "Merged Cells"

    # บันทึกงานนำเสนอลงดิสก์.
    presentation.save("table.pptx", slides.export.SaveFormat.PPTX)
```

## **การนับเลขในตารางมาตรฐาน**

ในตารางมาตรฐาน การนับหมายเลขเซลล์เป็นเรื่องง่ายและเริ่มจากศูนย์ เซลล์แรกในตารางมีดัชนีเป็น (0, 0) (คอลัมน์ 0, แถว 0).

ตัวอย่างเช่น ในตารางที่มี 4 คอลัมน์และ 4 แถว เซลล์จะถูกนับเลขดังต่อไปนี้:

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

ตัวอย่าง Python ด้านล่างแสดงวิธีอ้างอิงเซลล์โดยใช้การนับเลขแบบเริ่มจากศูนย์:

```python
for row_index in range(len(table.rows)):
    for column_index in range(len(table.rows[row_index])):
        cell = table.rows[row_index][column_index]
        cell.text_frame.text = f"({column_index}, {row_index})"
```

## **เข้าถึงตารางที่มีอยู่**

ส่วนนี้อธิบายวิธีค้นหาและทำงานกับตารางที่มีอยู่ในงานนำเสนอโดยใช้ Aspose.Slides คุณจะได้เรียนรู้วิธีค้นหาตารางบนสไลด์, เข้าถึงแถว, คอลัมน์, และเซลล์ของมัน, และอัปเดตเนื้อหา หรือรูปแบบ

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/) .
2. รับอ้างอิงไปยังสไลด์ที่บรรจุตารางโดยใช้ดัชนีของมัน.
3. วนซ้ำผ่านอ็อบเจกต์ [Shape](https://reference.aspose.com/slides/th/python-net/aspose.slides/shape/) ทั้งหมดจนกว่าจะพบตาราง.
4. ใช้วัตถุ [Table](https://reference.aspose.com/slides/th/python-net/aspose.slides/table/) เพื่อทำงานกับตาราง.
5. บันทึกงานนำเสนอที่แก้ไขแล้ว.

{{% alert color="info" %}}
หากสไลด์มีตารางหลายตาราง ควรค้นหาตารางที่ต้องการโดยใช้คุณสมบัติ `alternative_text` ของมัน.
{{% /alert %}}

ตัวอย่าง Python ด้านล่างแสดงวิธีเข้าถึงและทำงานกับตารางที่มีอยู่:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

# สร้างอินสแตนซ์ของคลาส Presentation เพื่อโหลดไฟล์ PPTX.
with slides.Presentation("sample.pptx") as presentation:
    # เข้าถึงสไลด์แรก.
    slide = presentation.slides[0]

    table = None

    # วนลูปผ่านรูปร่างและอ้างถึงตารางแรกที่พบ.
    for shape in slide.shapes:
        if isinstance(shape, slides.Table):
            table = shape
            break

    # ตั้งค่าข้อความของเซลล์แรกในแถวแรก.
    if table is not None:
        table.rows[0][0].text_frame.text = "Found"

    # บันทึกงานนำเสนอที่แก้ไขลงดิสก์.
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **จัดแนวข้อความในตาราง**

ส่วนนี้แสดงวิธีควบคุมการจัดตำแหน่งข้อความภายในเซลล์ของตารางโดยใช้ Aspose.Slides คุณจะได้เรียนรู้การตั้งค่าการจัดแนวนอนและตั้งตรงของเซลล์เพื่อทำให้เนื้อหาชัดเจนและสอดคล้องกัน

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/) .
2. รับอ้างอิงไปยังสไลด์โดยใช้ดัชนีของมัน.
3. เพิ่ม [Table](https://reference.aspose.com/slides/th/python-net/aspose.slides/table/) ลงในสไลด์.
4. เข้าถึงวัตถุ [Cell](https://reference.aspose.com/slides/th/python-net/aspose.slides/cell/) จากตาราง.
5. จัดแนวข้อความในแนวตั้ง.
6. บันทึกงานนำเสนอที่แก้ไขแล้ว.

ตัวอย่าง Python ด้านล่างแสดงวิธีจัดแนวข้อความในตาราง:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

# สร้างอินสแตนซ์ของคลาส Presentation.
with slides.Presentation() as presentation:
    # เข้าถึงสไลด์แรก.
    slide = presentation.slides[0]

    # กำหนดความกว้างของคอลัมน์และความสูงของแถว.
    column_widths = [40, 120, 120, 120]
    row_heights = [100, 100, 100, 100]

    # เพิ่มรูปร่างตารางลงบนสไลด์.
    table = slide.shapes.add_table(100, 50, column_widths, row_heights)
    table.rows[0][0].text_frame.text = "Numbers"
    table.rows[1][0].text_frame.text = "10"
    table.rows[2][0].text_frame.text = "20"
    table.rows[3][0].text_frame.text = "30"

    # จัดกึ่งกลางข้อความและตั้งค่าการจัดแนวแนวตั้ง.
    cell = table.rows[0][0]
    cell.text_anchor_type = slides.TextAnchorType.CENTER
    cell.text_vertical_type = slides.TextVerticalType.VERTICAL270

    # บันทึกงานนำเสนอลงดิสก์.
    presentation.save("aligned_cell.pptx", slides.export.SaveFormat.PPTX)
```

## **ตั้งค่าการจัดรูปแบบข้อความระดับตาราง**

ส่วนนี้แสดงวิธีใช้การจัดรูปแบบข้อความในระดับตารางใน Aspose.Slides เพื่อให้ทุกเซลล์สืบทอดสไตล์ที่สอดคล้องและเป็นเอกภาพ คุณจะได้เรียนรู้การตั้งค่าขนาดฟอนต์, การจัดแนว, และระยะขอบโดยรวม

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/) .
2. รับอ้างอิงไปยังสไลด์โดยใช้ดัชนีของมัน.
3. เพิ่ม [Table](https://reference.aspose.com/slides/th/python-net/aspose.slides/table/) ลงในสไลด์.
4. ตั้งค่าขนาดฟอนต์ (ความสูงฟอนต์) สำหรับข้อความ.
5. ตั้งค่าการจัดแนวย่อหน้าและระยะขอบ.
6. ตั้งค่าการวางข้อความแนวตั้ง.
7. บันทึกงานนำเสนอที่แก้ไขแล้ว.

ตัวอย่าง Python ด้านล่างแสดงวิธีใช้ตัวเลือกการจัดรูปแบบที่คุณต้องการกับข้อความในตาราง:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

# สร้างอินสแตนซ์ของคลาส Presentation
with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    table = slide.shapes.add_table(20, 20, [100, 50, 30], [30, 50, 30])

    # ตั้งค่าขนาดฟอนต์สำหรับทุกเซลล์ของตาราง.
    portion_format = slides.PortionFormat()
    portion_format.font_height = 25
    table.set_text_format(portion_format)

    # ตั้งค่าข้อความจัดชิดขวาและระยะขอบด้านขวาสำหรับทุกเซลล์ของตาราง.
    paragraph_format = slides.ParagraphFormat()
    paragraph_format.alignment = slides.TextAlignment.RIGHT
    paragraph_format.margin_right = 20
    table.set_text_format(paragraph_format)

    # ตั้งค่าการจัดแนวข้อความแนวตั้งสำหรับทุกเซลล์ของตาราง.
    text_frame_format = slides.TextFrameFormat()
    text_frame_format.text_vertical_type = slides.TextVerticalType.VERTICAL
    table.set_text_format(text_frame_format)

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **ใช้สไตล์ตารางที่มีให้ในตัว**

Aspose.Slides ให้คุณจัดรูปแบบตารางโดยใช้สไตล์ที่กำหนดไว้ล่วงหน้าตรงในโค้ด ตัวอย่างแสดงการสร้างตาราง, ใช้สไตล์ที่มีให้ในตัว, และบันทึกผลลัพธ์—เป็นวิธีที่มีประสิทธิภาพเพื่อให้ได้การจัดรูปแบบที่สอดคล้องและเป็นมืออาชีพ.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    table = slide.shapes.add_table(10, 10, [100, 150], [5, 5, 5])

    table.style_preset = slides.TableStylePreset.DARK_STYLE1

    presentation.save("table.pptx", slides.export.SaveFormat.PPTX)
```

## **ล็อกอัตราส่วนของตาราง**

อัตราส่วนของรูปร่างคืออัตราส่วนของมิติต่างๆ Aspose.Slides มีคุณสมบัติ `aspect_ratio_locked` ที่ทำให้คุณสามารถล็อกอัตราส่วนของตารางและรูปร่างอื่นๆได้.

ตัวอย่าง Python ด้านล่างแสดงวิธีล็อกอัตราส่วนของตาราง:

```py
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    table = slide.shapes.add_table(20, 20, [100, 50, 30], [30, 50, 30])

    print(f"Lock aspect ratio set: {table.shape_lock.aspect_ratio_locked}")
    table.shape_lock.aspect_ratio_locked = not table.shape_lock.aspect_ratio_locked
    print(f"Lock aspect ratio set: {table.shape_lock.aspect_ratio_locked}")

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**ฉันสามารถเปิดใช้งานการอ่านจากขวาไปซ้าย (RTL) สำหรับตารางทั้งหมดและข้อความในเซลล์ของมันได้หรือไม่?**

ใช่ ตารางมีคุณสมบัติ [right_to_left](https://reference.aspose.com/slides/th/python-net/aspose.slides/table/right_to_left/) และย่อหน้ามี [ParagraphFormat.right_to_left](https://reference.aspose.com/slides/th/python-net/aspose.slides/paragraphformat/right_to_left/) การใช้ทั้งสองจะทำให้การจัดเรียงและการแสดงผล RTL ถูกต้องภายในเซลล์.

**ฉันจะป้องกันไม่ให้ผู้ใช้ย้ายหรือปรับขนาดตารางในไฟล์สุดท้ายได้อย่างไร?**

ใช้ [shape locks](/slides/th/python-net/applying-protection-to-presentation/) เพื่อลบการย้าย, การปรับขนาด, การเลือก ฯลฯ การล็อกเหล่านี้ใช้กับตารางด้วย.

**การแทรกรูปภาพภายในเซลล์เป็นพื้นหลังรองรับหรือไม่?**

ใช่ คุณสามารถตั้งค่า [picture fill](https://reference.aspose.com/slides/th/python-net/aspose.slides/picturefillformat/) สำหรับเซลล์; รูปภาพจะครอบคลุมพื้นที่เซลล์ตามโหมดที่เลือก (ขยายหรือทำเป็นกระเบื้อง).