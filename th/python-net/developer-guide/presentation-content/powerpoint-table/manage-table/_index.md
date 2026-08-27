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
- การนำเสนอ
- Python
- Aspose.Slides
description: "สร้างและแก้ไขตารางในสไลด์ PowerPoint และ OpenDocument ด้วย Aspose.Slides สำหรับ Python ผ่าน .NET. ค้นหาโค้ดตัวอย่างง่ายๆ เพื่อปรับกระบวนการทำงานกับตารางของคุณให้ราบรื่นขึ้น."
---
## **บทนำ**

ตารางใน PowerPoint เป็นวิธีที่มีประสิทธิภาพสำหรับการนำเสนอข้อมูล ข้อมูลที่จัดเรียงเป็นกริดของเซลล์ (แถวและคอลัมน์) นั้นเข้าใจง่ายและตรงไปตรงมา

Aspose.Slides มีคลาส [Table](https://reference.aspose.com/slides/th/python-net/aspose.slides/table/) , คลาส [Cell](https://reference.aspose.com/slides/th/python-net/aspose.slides/cell/) และประเภทที่เกี่ยวข้องอื่นๆ เพื่อช่วยคุณสร้าง, ปรับปรุงและจัดการตารางในงานนำเสนอใดๆ

## **สร้างตารางจากศูนย์**

ส่วนนี้แสดงวิธีสร้างตารางจากศูนย์ใน Aspose.Slides โดยการเพิ่มรูปทรงตารางลงในสไลด์, กำหนดแถวและคอลัมน์, และตั้งค่าขนาดที่แม่นยำ คุณยังจะได้เห็นวิธีการใส่ข้อความลงในเซลล์, ปรับการจัดแนวและเส้นขอบ, และปรับแต่งลักษณะของตาราง

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/) 
2. รับการอ้างอิงไปยังสไลด์ด้วยดัชนีของมัน 
3. กำหนดอาเรย์ของความกว้างคอลัมน์ 
4. กำหนดอาเรย์ของความสูงแถว 
5. เพิ่ม [Table](https://reference.aspose.com/slides/th/python-net/aspose.slides/table/) ลงในสไลด์ 
6. วนรอบแต่ละ [Cell](https://reference.aspose.com/slides/th/python-net/aspose.slides/cell/) และกำหนดรูปแบบเส้นขอบด้านบน, ด้านล่าง, ด้านขวา, และด้านซ้าย 
7. รวมเซลล์ของสองแถวแรกและสองคอลัมน์แรกเป็นเซลล์เดียว 
8. เข้าถึง [TextFrame](https://reference.aspose.com/slides/th/python-net/aspose.slides/textframe/) ของ [Cell](https://reference.aspose.com/slides/th/python-net/aspose.slides/cell/) 
9. เพิ่มข้อความลงใน [TextFrame](https://reference.aspose.com/slides/th/python-net/aspose.slides/textframe/) 
10. บันทึกงานนำเสนอที่แก้ไขแล้ว 

ตัวอย่าง Python ต่อไปนี้แสดงวิธีสร้างตารางในงานนำเสนอ:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

    # สร้างอินสแตนซ์ของคลาส Presentation ที่แสดงถึงไฟล์งานนำเสนอ
    with slides.Presentation() as presentation:
        # เข้าถึงสไลด์แรก
        slide = presentation.slides[0]

        # กำหนดความกว้างของคอลัมน์และความสูงของแถว
        column_widths = [50, 50, 50]
        row_heights = [50, 30, 30, 30, 30]

        # เพิ่มรูปทรงตารางลงในสไลด์
        table = slide.shapes.add_table(100, 50, column_widths, row_heights)

        # ตั้งค่ารูปแบบเส้นขอบสำหรับแต่ละเซลล์
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
        
        # รวมเซลล์จาก (แถว 0, คอลัมน์ 0) ถึง (แถว 1, คอลัมน์ 1)
        table.merge_cells(table.rows[0][0], table.rows[1][1], False)

        # เพิ่มข้อความลงในเซลล์ที่รวมกัน
        table.rows[0][0].text_frame.text = "Merged Cells"

        # บันทึกงานนำเสนอลงดิสก์
        presentation.save("table.pptx", slides.export.SaveFormat.PPTX)
```

## **การนับในตารางมาตรฐาน**

ในตารางมาตรฐาน, การนับเซลล์เป็นเรื่องง่ายและเริ่มจากศูนย์ เซลล์แรกในตารางจะมีดัชนีเป็น (0, 0) (คอลัมน์ 0, แถว 0)

ตัวอย่างเช่น, ในตารางที่มี 4 คอลัมน์และ 4 แถว, เซลล์จะถูกนับดังนี้:

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

ตัวอย่าง Python ต่อไปนี้แสดงวิธีอ้างอิงเซลล์โดยใช้การนับเริ่มจากศูนย์นี้:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    # เข้าถึงสไลด์แรก.
    slide = presentation.slides[0]

    # เพิ่มตารางที่มี 4 คอลัมน์และ 4 แถว.
    table = slide.shapes.add_table(100, 50, [50, 50, 50, 50], [30, 30, 30, 30])

    for row_index in range(len(table.rows)):
        for column_index in range(len(table.rows[row_index])):
            cell = table.rows[row_index][column_index]
            cell.text_frame.text = f"({column_index}, {row_index})"

    presentation.save("table.pptx", slides.export.SaveFormat.PPTX)
```

## **เข้าถึงตารางที่มีอยู่**

ส่วนนี้อธิบายวิธีค้นหาและทำงานกับตารางที่มีอยู่ในงานนำเสนอโดยใช้ Aspose.Slides คุณจะได้เรียนรู้วิธีหาตารางบนสไลด์, เข้าถึงแถว, คอลัมน์และเซลล์ต่างๆ, และอัปเดตเนื้อหาหรือรูปแบบ

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/) 
2. รับการอ้างอิงไปยังสไลด์ที่มีตารางอยู่โดยใช้ดัชนีของมัน 
3. วนรอบวัตถุ [Shape](https://reference.aspose.com/slides/th/python-net/aspose.slides/shape/) ทั้งหมดจนกว่าจะพบตาราง 
4. ใช้วัตถุ [Table](https://reference.aspose.com/slides/th/python-net/aspose.slides/table/) เพื่อทำงานกับตาราง 
5. บันทึกงานนำเสนอที่แก้ไขแล้ว 

{{% alert color="info" title="Note" %}}
หากสไลด์มีหลายตาราง, ควรค้นหาตารางที่ต้องการโดยใช้คุณสมบัติ `alternative_text` 
{{% /alert %}}

ตัวอย่าง Python ต่อไปนี้แสดงวิธีเข้าถึงและทำงานกับตารางที่มีอยู่:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

# สร้างอินสแตนซ์ของคลาส Presentation เพื่อโหลดไฟล์ PPTX
with slides.Presentation("sample.pptx") as presentation:
    # เข้าถึงสไลด์แรก.
    slide = presentation.slides[0]

    table = None

    # วนลูปผ่านรูปทรงและอ้างอิงตารางแรกที่พบ.
    for shape in slide.shapes:
        if isinstance(shape, slides.Table):
            table = shape
            break

    # ตั้งค่าข้อความของเซลล์แรกในแถวแรก.
    if table is not None:
        table.rows[0][0].text_frame.text = "Found"

    # บันทึกงานนำเสนอที่แก้ไขแล้วลงดิสก์.
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **ค้นหาเซลล์ที่เป็นเจ้าของ TextFrame**

เมื่อโค้ดการประมวลผลข้อความทั่วไปได้รับ [TextFrame](https://reference.aspose.com/slides/th/python-net/aspose.slides/textframe/) จากตาราง, ให้ใช้คุณสมบัติ TextFrame.parent_cell เพื่อดึงเซลล์เจ้าของ สำหรับ TextFrame ของเซลล์ตาราง, TextFrame.parent_cell จะถูกตั้งค่าและ TextFrame.parent_shape จะเป็น `None` แม้ว่าตารางเองจะเป็นรูปทรง

พิกัดของเซลล์สามารถเข้าถึงได้ผ่านคุณสมบัติแบบอ่านอย่างเดียว Cell.first_column_index และ Cell.first_row_index. TextFrame.parent_cell ก็เป็นแบบอ่านอย่างเดียวเช่นกัน: ให้การนำทางไปยังเจ้าของแต่ไม่เปลี่ยนความเป็นเจ้าของ. ควรตรวจสอบว่าเซลล์ที่คืนค่ามาเป็น `None` หรือไม่ก่อนนำไปใช้เสมอ

สำหรับตัวอย่างครบที่ระบุเจ้าของเซลล์ตารางและรูปทรง, รวมถึงรูปทรงที่เชื่อมกับโหนด SmartArt, ดูที่ [Search and Replace Text](/slides/th/python-net/search-and-replace-text/).

## **จัดแนวข้อความในตาราง**

ส่วนนี้แสดงวิธีควบคุมตำแหน่งข้อความภายในเซลล์ตารางโดยใช้ Aspose.Slides คุณจะได้เรียนรู้การตรึงข้อความแนวตั้งในเซลล์และเปลี่ยนทิศทางการแสดงผลของข้อความ

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/) 
2. รับการอ้างอิงไปยังสไลด์ด้วยดัชนีของมัน 
3. เพิ่มวัตถุ [Table](https://reference.aspose.com/slides/th/python-net/aspose.slides/table/) ลงในสไลด์ 
4. เข้าถึงวัตถุ [Cell](https://reference.aspose.com/slides/th/python-net/aspose.slides/cell/) จากตาราง 
5. จัดตำแหน่งข้อความให้อยู่ตรงกลางแนวตั้งในเซลล์และตั้งค่าทิศทางของข้อความ 
6. บันทึกงานนำเสนอที่แก้ไขแล้ว 

ตัวอย่าง Python ต่อไปนี้แสดงวิธีจัดแนวข้อความในตาราง:

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

    # เพิ่มรูปทรงตารางลงในสไลด์.
    table = slide.shapes.add_table(100, 50, column_widths, row_heights)
    table.rows[0][0].text_frame.text = "Numbers"
    table.rows[1][0].text_frame.text = "10"
    table.rows[2][0].text_frame.text = "20"
    table.rows[3][0].text_frame.text = "30"

    # จัดตำแหน่งข้อความให้อยู่กึ่งกลางและตั้งค่าการวางแนวตั้ง.
    cell = table.rows[0][0]
    cell.text_anchor_type = slides.TextAnchorType.CENTER
    cell.text_vertical_type = slides.TextVerticalType.VERTICAL270

    # บันทึกงานนำเสนอลงดิสก์.
    presentation.save("aligned_cell.pptx", slides.export.SaveFormat.PPTX)
```

## **ตั้งค่าการจัดรูปแบบข้อความระดับตาราง**

ส่วนนี้แสดงวิธีใช้การจัดรูปแบบข้อความในระดับตารางใน Aspose.Slides เพื่อให้ทุกเซลล์สืบทอดสไตล์ที่สอดคล้องและเป็นหนึ่งเดียว คุณจะได้เรียนรู้การตั้งขนาดฟอนต์, การจัดแนว, และระยะขอบโดยรวม

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/) 
2. รับการอ้างอิงไปยังสไลด์ด้วยดัชนีของมัน 
3. เพิ่ม [Table](https://reference.aspose.com/slides/th/python-net/aspose.slides/table/) ลงในสไลด์ 
4. ตั้งค่าขนาดฟอนต์ (ความสูงฟอนต์) สำหรับข้อความ 
5. ตั้งค่าการจัดแนวย่อหน้าและระยะขอบ 
6. ตั้งค่าการวางแนวข้อความแนวตั้ง 
7. บันทึกงานนำเสนอที่แก้ไขแล้ว 

ตัวอย่าง Python ต่อไปนี้แสดงวิธีใช้ตัวเลือกการจัดรูปแบบที่คุณต้องการกับข้อความในตาราง:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

# สร้างอินสแตนซ์ของคลาส Presentation
with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    table = slide.shapes.add_table(20, 20, [100, 50, 30], [30, 50, 30])

    # ตั้งค่าขนาดฟอนต์สำหรับเซลล์ตารางทั้งหมด.
    portion_format = slides.PortionFormat()
    portion_format.font_height = 25
    table.set_text_format(portion_format)

    # ตั้งค่าข้อความจัดชิดขวาและระยะขอบด้านขวาสำหรับเซลล์ตารางทั้งหมด.
    paragraph_format = slides.ParagraphFormat()
    paragraph_format.alignment = slides.TextAlignment.RIGHT
    paragraph_format.margin_right = 20
    table.set_text_format(paragraph_format)

    # ตั้งค่าการวางแนวข้อความแนวตั้งสำหรับเซลล์ตารางทั้งหมด.
    text_frame_format = slides.TextFrameFormat()
    text_frame_format.text_vertical_type = slides.TextVerticalType.VERTICAL
    table.set_text_format(text_frame_format)

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **ใช้สไตล์ตารางที่กำหนดไว้ล่วงหน้า**

Aspose.Slides ให้คุณจัดรูปแบบตารางโดยใช้สไตล์ที่กำหนดไว้ล่วงหน้าโดยตรงในโค้ด ตัวอย่างแสดงการสร้างตาราง, ใช้สไตล์ในตัว, และบันทึกผลลัพธ์—เป็นวิธีที่มีประสิทธิภาพเพื่อให้การจัดรูปแบบสอดคล้องและเป็นมืออาชีพ

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    table = slide.shapes.add_table(10, 10, [100, 150], [5, 5, 5])

    table.style_preset = slides.TableStylePreset.DARK_STYLE1

    presentation.save("table.pptx", slides.export.SaveFormat.PPTX)
```

## **ล็อคอัตราส่วนของตาราง**

อัตราส่วนของรูปทรงคืออัตราส่วนของมิติของมัน Aspose.Slides มีคุณสมบัติ `aspect_ratio_locked` ซึ่งช่วยให้คุณล็อคอัตราส่วนของตารางและรูปทรงอื่นๆ

ตัวอย่าง Python ต่อไปนี้แสดงวิธีล็อคอัตราส่วนสำหรับตาราง:

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

**ฉันสามารถเปิดใช้งานทิศทางการอ่านจากขวาไปซ้าย (RTL) สำหรับตารางทั้งหมดและข้อความในเซลล์ของมันได้หรือไม่?**

ใช่ ตารางมีคุณสมบัติ [right_to_left](https://reference.aspose.com/slides/th/python-net/aspose.slides/table/right_to_left/) และย่อหน้ามี [ParagraphFormat.right_to_left](https://reference.aspose.com/slides/th/python-net/aspose.slides/paragraphformat/right_to_left/) การใช้ทั้งสองทำให้แน่ใจว่าลำดับและการแสดงผล RTL ถูกต้องภายในเซลล์

**ฉันจะป้องกันไม่ให้ผู้ใช้ย้ายหรือปรับขนาดตารางในไฟล์สุดท้ายได้อย่างไร?**

ใช้ [shape locks](/slides/th/python-net/applying-protection-to-presentation/) เพื่อปิดการย้าย, ปรับขนาด, การเลือก ฯลฯ ฺล็อกเหล่านี้ใช้กับตารางด้วย

**การแทรกรูปภาพภายในเซลล์เป็นพื้นหลังได้รับการสนับสนุนหรือไม่?**

ใช่ คุณสามารถตั้งค่า [picture fill](https://reference.aspose.com/slides/th/python-net/aspose.slides/picturefillformat/) สำหรับเซลล์; ภาพจะครอบพื้นที่เซลล์ตามโหมดที่เลือก (ยืดหรือปูกระเบียง)