---
title: จัดการเซลล์ตารางในงานนำเสนอด้วย Python
linktitle: จัดการเซลล์
type: docs
weight: 30
url: /th/python-net/manage-cells/
keywords:
- เซลล์ตาราง
- รวมเซลล์
- ลบขอบ
- แยกเซลล์
- รูปภาพในเซลล์
- สีพื้นหลัง
- PowerPoint
- งานนำเสนอ
- Python
- Aspose.Slides
description: "จัดการเซลล์ตาราง PowerPoint ด้วย Python: ระบุเซลล์ที่ผสาน, ลบขอบ, แยกเซลล์, และตั้งค่าสีพื้นหลังและรูปภาพด้วย Aspose.Slides สำหรับ Python ผ่าน .NET."
---
## **ภาพรวม**

Aspose.Slides ให้คุณเข้าถึงและแก้ไขเซลล์ตารางในงานนำเสนอ PowerPoint บทความนี้อธิบายวิธีระบุเซลล์ตารางที่รวมกัน, ลบขอบเซลล์, ทำงานกับหมายเลขเซลล์หลังจากการผสานหรือแยกเซลล์, เปลี่ยนสีพื้นหลังของเซลล์, และเพิ่มรูปภาพภายในเซลล์ตาราง ตัวอย่างแสดงวิธีสร้างหรือเปิดงานนำเสนอ, ดึงตารางจากสไลด์, ปรับรูปแบบเซลล์ผ่านคุณสมบัติของเซลล์, และบันทึกงานนำเสนอที่แก้ไขเป็นไฟล์ PPTX

Aspose.Slides ใช้ดัชนีเริ่มจากศูนย์ พิกัดในบทความนี้เขียนเป็น `(column, row)`

## **ระบุเซลล์ตารางที่รวมกัน**

ตัวอย่างเปิดงานนำเสนอที่มีอยู่และเข้าถึงรูปร่างแรกบนสไลด์แรกเป็นตาราง โดยสมมติว่ามีสไลด์และรูปร่างดังกล่าวและรูปร่างเป็นตาราง จากนั้นวนลูปผ่านทุกแถวและคอลัมน์และใช้ [is_merged_cell](https://reference.aspose.com/slides/python-net/aspose.slides/cell/is_merged_cell/) เพื่อระบุเซลล์ในพื้นที่ที่รวม สำหรับแต่ละการจับคู่ จะพิมพ์พิกัดเซลล์ในรูปแบบ `row;column`, [row_span](https://reference.aspose.com/slides/python-net/aspose.slides/cell/row_span/), [col_span](https://reference.aspose.com/slides/python-net/aspose.slides/cell/col_span/), และพิกัดเริ่มต้นของพื้นที่, [first_row_index](https://reference.aspose.com/slides/python-net/aspose.slides/cell/first_row_index/) และ [first_column_index](https://reference.aspose.com/slides/python-net/aspose.slides/cell/first_column_index/)

```python
import aspose.slides as slides

with slides.Presentation("presentation_with_table.pptx") as presentation:
    slide = presentation.slides[0]
    table = slide.shapes[0]

    for row_index in range(len(table.rows)):
        for column_index in range(len(table.columns)):
            cell = table.rows[row_index][column_index]
            if cell.is_merged_cell:
                print(f"Cell {row_index};{column_index} belongs to a merged region with row_span={cell.row_span} and col_span={cell.col_span} starting at {cell.first_row_index};{cell.first_column_index}.")
```

## **ลบขอบเซลล์ตาราง**

สร้าง [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) และเพิ่มตารางลงในสไลด์แรกด้วย [add_table](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_table/). ความกว้างคอลัมน์, ความสูงแถว, และตำแหน่งตารางระบุเป็นพอยท์ ตัวอย่างตั้งค่าขอบเซลล์สี่ด้านทั้งหมดให้เป็น [FillType.NO_FILL](https://reference.aspose.com/slides/python-net/aspose.slides/filltype/) ทำให้ขอบไม่ปรากฏ

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    column_widths = [50, 50, 50, 50]
    row_heights = [50, 30, 30, 30, 30]
    table = slide.shapes.add_table(100, 50, column_widths, row_heights)

    for row in table.rows:
        for cell in row:
            cell.cell_format.border_top.fill_format.fill_type = slides.FillType.NO_FILL
            cell.cell_format.border_bottom.fill_format.fill_type = slides.FillType.NO_FILL
            cell.cell_format.border_left.fill_format.fill_type = slides.FillType.NO_FILL
            cell.cell_format.border_right.fill_format.fill_type = slides.FillType.NO_FILL

    presentation.save("table.pptx", slides.export.SaveFormat.PPTX)
```

## **เพิ่มขอบเซลล์แนวทแยง**

ใช้ [border_diagonal_down](https://reference.aspose.com/slides/python-net/aspose.slides/cellformat/border_diagonal_down/) วาดเส้นจากมุมซ้ายบนไปขวาล่าง, และ [border_diagonal_up](https://reference.aspose.com/slides/python-net/aspose.slides/cellformat/border_diagonal_up/) วาดเส้นจากมุมซ้ายล่างไปขวาบน. เส้นทแยงสามารถทำเครื่องหมายหัวข้อมุม; ทั้งสองเส้นสามารถสร้างรูป X เพื่อระบุว่าเซลล์ไม่ใช้ได้

แต่ละเส้นทแยงเป็น [LineFormat](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/). ใน [fill_format](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/fill_format/) ตั้งค่า [fill_type](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/fill_type/) เป็น [FillType.SOLID](https://reference.aspose.com/slides/python-net/aspose.slides/filltype/) แล้วเลือก [solid_fill_color](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/solid_fill_color/). ตั้งค่า [width](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/width/) ของเส้นเป็นพอยท์

ตัวอย่างสร้างเซลล์สามเซลล์ในแถวเดียว: เส้นทแยงลงสีแดง, เส้นทแยงขึ้นสีฟ้า, และเส้นทแยงทั้งสอง. ขอบด้านบน, ด้านล่าง, ด้านซ้าย, และด้านขวาของเซลล์จะคงไว้ไม่เปลี่ยน

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    column_widths = [210, 210, 210]
    row_heights = [160]
    table = slide.shapes.add_table(45, 130, column_widths, row_heights)

    downward_border = table.rows[0][0].cell_format.border_diagonal_down
    downward_border.fill_format.fill_type = slides.FillType.SOLID
    downward_border.fill_format.solid_fill_color.color = slides.Color.red
    downward_border.width = 3

    upward_border = table.rows[0][1].cell_format.border_diagonal_up
    upward_border.fill_format.fill_type = slides.FillType.SOLID
    upward_border.fill_format.solid_fill_color.color = slides.Color.blue
    upward_border.width = 5

    cross_downward_border = table.rows[0][2].cell_format.border_diagonal_down
    cross_downward_border.fill_format.fill_type = slides.FillType.SOLID
    cross_downward_border.fill_format.solid_fill_color.color = slides.Color.red
    cross_downward_border.width = 3

    cross_upward_border = table.rows[0][2].cell_format.border_diagonal_up
    cross_upward_border.fill_format.fill_type = slides.FillType.SOLID
    cross_upward_border.fill_format.solid_fill_color.color = slides.Color.blue
    cross_upward_border.width = 5

    presentation.save("diagonal_cell_borders.pptx", slides.export.SaveFormat.PPTX)
```

เส้นทแยงเป็นคุณสมบัติการจัดรูปแบบ ไม่ใช่การแยกเซลล์ แต่ละเซลล์รักษา [text_frame](https://reference.aspose.com/slides/python-net/aspose.slides/cell/text_frame/) เพียงหนึ่ง; พื้นที่ทั้งสองด้านของเส้นทแยงไม่สามารถแก้ไขแยกกันได้

ตารางที่บันทึกแล้วแสดงใน Microsoft PowerPoint:

![Three table cells showing a red diagonal from top-left to bottom-right, a blue diagonal from bottom-left to top-right, and both diagonals forming an X.](diagonal-cell-borders.png)

*ซ้ายไปขวา: เส้นทแยงลง (สีแดง, 3 pt), เส้นทแยงขึ้น (สีน้ำเงิน, 5 pt) และเส้นทแยงทั้งสอง*

## **ผสานเซลล์ตาราง**

ใช้ [merge_cells](https://reference.aspose.com/slides/python-net/aspose.slides/table/merge_cells/) เพื่อรวมช่วงสี่เหลี่ยมของเซลล์ตารางเป็นเซลล์เดียว ระบุเซลล์ที่มุมซ้ายบนและมุมขวาล่างของช่วง พารามิเตอร์สุดท้ายควบคุมว่าการผสานอาจรวมเซลล์นอกช่วงที่ระบุหรือไม่; `False` จะทำให้การผสานอยู่ภายในช่วงนั้นเท่านั้น

ตัวอย่างสร้างตารางขนาด 4x4 โดยแต่ละคอลัมน์และแถวมีความกว้าง 70 พอยท์, จากนั้นผสานเซลล์ศูนย์กลางสี่เซลล์จาก `(1, 1)` ถึง `(2, 2)`. เซลล์ที่ได้ครอบคลุมสองคอลัมน์และสองแถว, ในขณะที่กริดพื้นฐานของตารางยังคงมีสี่คอลัมน์และสี่แถว เพื่อเข้าถึงเนื้อหาหรือการจัดรูปแบบของเซลล์ที่ผสาน, ใช้ตำแหน่งมุมซ้ายบน: `table.rows[1][1]` ในตัวอย่างนี้ ตำแหน่งอื่นในช่วงที่ผสานยังคงเป็นส่วนหนึ่งของกริดตาราง, ดังนั้นดัชนีของเซลล์นอกช่วงจะไม่เปลี่ยน

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    column_widths = [70, 70, 70, 70]
    row_heights = [70, 70, 70, 70]
    table = slide.shapes.add_table(100, 50, column_widths, row_heights)

    table.merge_cells(table.rows[1][1], table.rows[2][2], False)

    presentation.save("merged_cells.pptx", slides.export.SaveFormat.PPTX)
```

## **แยกเซลล์ตาราง**

การผสานเซลล์ในตัวอย่างก่อนหน้านี้ทำให้กริดของตารางคงเดิม การแยกเซลล์อาจเพิ่มคอลัมน์กริดใหม่และเปลี่ยนดัชนีคอลัมน์ของเซลล์ที่อยู่ทางขวา Aspose.Slides ปฏิบัติตามโมเดลกริดของตาราง PowerPoint

ตัวอย่างนี้สร้างตาราง 4x4 โดยแต่ละคอลัมน์และแถวมีความกว้าง 70 พอยท์และเรียกใช้ [split_by_width](https://reference.aspose.com/slides/python-net/aspose.slides/cell/split_by_width/) กับเซลล์ `(1, 1)`. ความกว้าง 70 พอยท์ของเซลล์จะถูกแบ่งครึ่งเพื่อสร้างเซลล์สองเซลล์ที่มีความกว้างเท่ากัน

หลังการแยกนี้, ครึ่งสองส่วนจะเข้าถึงได้ด้วย `table.rows[1][1]` และ `table.rows[1][2]`. กริดของตารางตอนนี้มีห้าคอลัมน์: เซลล์ที่อยู่เดิมในคอลัมน์ 2 และ 3 ย้ายไปคอลัมน์ 3 และ 4 ตามลำดับ ดัชนีแถวคงเดิม ใช้ดัชนีคอลัมน์ที่อัปเดตเมื่อเข้าถึงเซลล์หลังการแยก

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    column_widths = [70, 70, 70, 70]
    row_heights = [70, 70, 70, 70]
    table = slide.shapes.add_table(100, 50, column_widths, row_heights)

    table.rows[1][1].split_by_width(table.rows[1][1].width / 2)

    presentation.save("split_cells.pptx", slides.export.SaveFormat.PPTX)
```


<!-- visual-explanation:manage-cells:start -->
[![An unmerged 70-point cell splits into two 35-point cells, adding a fifth grid column and shifting the indices to its right.](visual-manage-cells-04c40789d81c.svg)](visual-manage-cells-04c40789d81c.svg)

*การแบ่งความกว้างมีผลต่อเซลล์ (1, 1) โดยใช้ดัชนีแบบศูนย์ (คอลัมน์, แถว). แถวอื่น ๆ ยังคงเซลล์ที่ครอบคลุมทั้งตำแหน่งคอลัมน์ใหม่*
<!-- visual-explanation:manage-cells:end -->

### **แยกเซลล์ที่รวมกันตามช่วงแถวหรือคอลัมน์**

เพื่อเตรียมเซลล์แม่แบบที่ผสานไว้สำหรับการเติมข้อมูล, ใช้ [split_by_row_span](https://reference.aspose.com/slides/python-net/aspose.slides/cell/split_by_row_span/) เพื่อแบ่งตามเส้นขอบแถวที่มีอยู่, หรือ [split_by_col_span](https://reference.aspose.com/slides/python-net/aspose.slides/cell/split_by_col_span/) เพื่อแบ่งตามเส้นขอบคอลัมน์

อาร์กิวเมนต์ `index` จะนับแถวในส่วนบนหรือคอลัมน์ในส่วนซ้ายของการแบ่ง; ค่านี้สัมพันธ์กับพื้นที่ที่ผสาน:

- การแบ่งแถว: `0 < index <` [row_span](https://reference.aspose.com/slides/python-net/aspose.slides/cell/row_span/).
- การแบ่งคอลัมน์: `0 < index <` [col_span](https://reference.aspose.com/slides/python-net/aspose.slides/cell/col_span/).

ตัวอย่างคาดว่างานนำเสนอมีตารางเป็นรูปร่างแรกบนสไลด์แรก, โดยเซลล์ `(1, 2)` และ `(1, 3)` ถูกผสานแนวตั้ง เริ่มจากตำแหน่งล่าง, ใช้ [first_column_index](https://reference.aspose.com/slides/python-net/aspose.slides/cell/first_column_index/) และ [first_row_index](https://reference.aspose.com/slides/python-net/aspose.slides/cell/first_row_index/) เพื่อหาตำแหน่งต้นกำเนิดและตรวจสอบทั้งสองช่วง `split_by_row_span` ด้วยค่า index = 1 จะทำการแยกแถว 2 กับ 3 เพื่อระบุชื่อผลิตภัณฑ์ สำหรับการผสานแนวนอนสองคอลัมน์ ให้ใช้ `split_by_col_span` ด้วยค่า index = 1 แทน

```python
import aspose.slides as slides

with slides.Presentation("table_template.pptx") as presentation:
    slide = presentation.slides[0]
    table = slide.shapes[0]

    selected_cell = table.rows[3][1]
    first_column_index = selected_cell.first_column_index
    first_row_index = selected_cell.first_row_index
    merged_cell = table.rows[first_row_index][first_column_index]

    if merged_cell.is_merged_cell and merged_cell.row_span == 2 and merged_cell.col_span == 1:
        merged_cell.split_by_row_span(1)

        # ดึงเซลล์ที่ได้จากตารางหลังจากการแยก.
        upper_cell = table.rows[first_row_index][first_column_index]
        lower_cell = table.rows[first_row_index + 1][first_column_index]
        print(f"Upper cell merged: {upper_cell.is_merged_cell}")
        print(f"Lower cell merged: {lower_cell.is_merged_cell}")

        upper_cell.text_frame.text = "Product A"
        lower_cell.text_frame.text = "Product B"

        presentation.save("split_template.pptx", slides.export.SaveFormat.PPTX)
    else:
        print("Select a merged region spanning exactly two rows and one column.")
```

กริดของตารางและดัชนีเซลล์โดยรอบคงเดิม ดึงเซลล์ผลลัพธ์โดยใช้พิกัด; ในที่นี้ทั้งสองมี span เป็น 1 และ [is_merged_cell](https://reference.aspose.com/slides/python-net/aspose.slides/cell/is_merged_cell/) จะพิมพ์ `False`. พื้นที่ที่ใหญ่ขึ้นอาจยังคงผสานบางส่วนหลังจากการแบ่งหนึ่งครั้ง

ข้อความต้นฉบับและการจัดรูปแบบของมันยังคงอยู่ในเซลล์บน (หรือซ้าย), เซลล์ใหม่จะว่างเปล่าแต่สืบทอดการจัดรูปแบบของเซลล์เช่น fill, borders, และ margins เติมข้อมูลในเซลล์หลังการแยกและกำหนดการจัดรูปแบบข้อความตามต้องการ

งานนำเสนอที่บันทึกไว้จะมีเซลล์ “Product A” และ “Product B” แยกจากกันโดยคงรูปแบบเซลล์ของแม่แบบไว้ ดู [Cell API Reference](https://reference.aspose.com/slides/python-net/aspose.slides/cell/) สำหรับรายละเอียด

### **แยกเซลล์ตามความสูงที่กำหนด**

[split_by_height](https://reference.aspose.com/slides/python-net/aspose.slides/cell/split_by_height/) รับความสูงของส่วนบนเป็นพอยท์ [split_by_row_span](https://reference.aspose.com/slides/python-net/aspose.slides/cell/split_by_row_span/) รับจำนวนแถวกริดที่มีอยู่ในส่วนบน เพื่อจัดตำแหน่งเซลล์ความสูง 40 พอยท์ให้อยู่กึ่งกลางคอลัมน์ขวา, ให้ลบ 40 จากความสูงจริงของเซลล์แล้วแบ่งพื้นที่ที่เหลือเท่า ๆ กันด้านบนและด้านล่าง

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    column_widths = [160, 160]
    row_heights = [140]
    
    table = slide.shapes.add_table(50, 50, column_widths, row_heights)
    table.rows[0][0].text_frame.text = "Left"

    height = table.rows[0][1].height
    margin = (height - 40) / 2

    table.rows[0][1].split_by_height(margin)
    table.rows[1][1].split_by_height(40)
    table.rows[1][1].text_frame.text = "Middle"

    presentation.save("split_by_height.pptx", slides.export.SaveFormat.PPTX)
```

การแบ่งแรกเพิ่มแถวกริด, ทำให้ส่วนล่าง 90 พอยท์อยู่ใน `table.rows[1][1]`. การแบ่งที่สองแบ่งเซลล์นั้นเป็นเซลล์กลางความสูง 40 พอยท์และเซลล์ล่างความสูง 50 พอยท์. เซลล์สามเซลล์ในคอลัมน์ขวาจึงมีความสูงจากบนลงล่างเป็น 50, 40, และ 50 พอยท์ตามลำดับ. เซลล์ซ้ายครอบคลุมทั้งสามแถวด้วยความสูงเดิม 140 พอยท์

![The left cell spans the full table height beside three cells with Middle in the center.](split-by-height.png)

## **เปลี่ยนสีพื้นหลังของเซลล์ตาราง**

ตัวอย่างนี้สร้างตารางโดยคอลัมน์ความกว้าง 150 พอยท์และแถวความสูง 50 พอยท์. ตั้งค่า [fill_type](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/fill_type/) เป็น solid และ [solid_fill_color](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/solid_fill_color/) เป็นสีแดงสำหรับเซลล์ `(2, 3)`, ซึ่งอยู่ในคอลัมน์ที่สามและแถวที่สี่

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    column_widths = [150, 150, 150, 150]
    row_heights = [50, 50, 50, 50, 50]
    table = slide.shapes.add_table(50, 50, column_widths, row_heights)

    cell = table.rows[3][2]
    cell.cell_format.fill_format.fill_type = slides.FillType.SOLID
    cell.cell_format.fill_format.solid_fill_color.color = slides.Color.red

    presentation.save("cell_background_color.pptx", slides.export.SaveFormat.PPTX)
```

## **เพิ่มรูปภาพในเซลล์ตาราง**

วางรูปภาพต้นฉบับในไดเรกทอรีทำงานก่อนรันตัวอย่างนี้. ตัวอย่างโหลดรูปภาพด้วย [Images.from_file](https://reference.aspose.com/slides/python-net/aspose.slides/images/from_file/) และเพิ่มลงในคอลเลกชันรูปภาพของงานนำเสนอด้วย [add_image](https://reference.aspose.com/slides/python-net/aspose.slides/imagecollection/add_image/). จากนั้นกำหนดรูปภาพให้กับ picture fill ของเซลล์ `(0, 0)`, เซลล์แรกของตาราง

[PictureFillMode.STRETCH](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillmode/) จะยืดรูปภาพให้เติมเต็มเซลล์, ซึ่งอาจเปลี่ยนอัตราส่วนภาพ. ความกว้างคอลัมน์และความสูงแถวเป็นพอยท์ รูปภาพที่โหลดจะถูกรับมือโดยอัตโนมัติเมื่อบล็อก `with` สิ้นสุด

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    column_widths = [150, 150, 150, 150]
    row_heights = [100, 100, 100, 100, 90]
    table = slide.shapes.add_table(50, 50, column_widths, row_heights)

    with slides.Images.from_file("aspose_logo.jpg") as image:
        presentation_image = presentation.images.add_image(image)

    cell = table.rows[0][0]
    cell.cell_format.fill_format.fill_type = slides.FillType.PICTURE
    cell.cell_format.fill_format.picture_fill_format.picture_fill_mode = slides.PictureFillMode.STRETCH
    cell.cell_format.fill_format.picture_fill_format.picture.image = presentation_image

    presentation.save("table_cell_with_image.pptx", slides.export.SaveFormat.PPTX)
```

## **คำถามที่พบบ่อย**

**สามารถกำหนดความหนาและสไตล์ของเส้นขอบที่ต่างกันสำหรับแต่ละด้านของเซลล์เดียวได้หรือไม่?**

ได้. ขอบ [top](https://reference.aspose.com/slides/python-net/aspose.slides/cellformat/border_top/)/[bottom](https://reference.aspose.com/slides/python-net/aspose.slides/cellformat/border_bottom/)/[left](https://reference.aspose.com/slides/python-net/aspose.slides/cellformat/border_left/)/[right](https://reference.aspose.com/slides/python-net/aspose.slides/cellformat/border_right/) มีคุณสมบัติเฉพาะ, ดังนั้นความหนาและสไตล์ของแต่ละด้านจึงสามารถต่างกันได้

**ภาพจะเกิดอะไรขึ้นหากเปลี่ยนขนาดคอลัมน์/แถวหลังจากตั้งภาพเป็นพื้นหลังของเซลล์?**

พฤติกรรมขึ้นอยู่กับ [fill mode](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillmode/) (stretch/tile). หากใช้การยืด, ภาพจะปรับตามเซลล์ใหม่; หากใช้การทำเป็นแผะแผ่น, แผ่นจะถูกคำนวณใหม่

**สามารถกำหนด hyperlink ให้กับเนื้อหาทั้งหมดของเซลล์ได้หรือไม่?**

[Hyperlinks](/slides/th/python-net/manage-hyperlinks/) ถูกกำหนดที่ระดับข้อความ (portion) ภายใน text frame ของเซลล์หรือที่ระดับตาราง/รูปร่างทั้งหมด โดยทั่วไปคุณจะกำหนดลิงก์ให้กับ portion หรือให้กับข้อความทั้งหมดในเซลล์

**สามารถกำหนดฟอนต์ที่ต่างกันภายในเซลล์เดียวได้หรือไม่?**

ได้. text frame ของเซลล์รองรับ [portions](https://reference.aspose.com/slides/python-net/aspose.slides/portion/) (run) ที่มีการจัดรูปแบบอิสระ—ฟอนต์, สไตล์, ขนาด, และสี.