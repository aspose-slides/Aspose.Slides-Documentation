---
title: จัดการเซลล์ตารางในงานนำเสนอด้วย Python
linktitle: จัดการเซลล์
type: docs
weight: 30
url: /th/python-net/manage-cells/
keywords:
- เซลล์ตาราง
- ผสานเซลล์
- ลบเส้นขอบ
- แยกเซลล์
- รูปภาพในเซลล์
- สีพื้นหลัง
- PowerPoint
- งานนำเสนอ
- Python
- Aspose.Slides
description: "จัดการเซลล์ตาราง PowerPoint ด้วย Python: ระบุเซลล์ที่ถูกผสาน, ลบเส้นขอบ, แยกเซลล์, และตั้งค่าสีพื้นหลังและรูปภาพด้วย Aspose.Slides สำหรับ Python ผ่าน .NET."
---
## **ภาพรวม**

Aspose.Slides ช่วยให้คุณเข้าถึงและแก้ไขเซลล์ตารางในงานนำเสนอ PowerPoint ได้ บทความนี้อธิบายวิธีระบุเซลล์ตารางที่ถูกผสาน การลบเส้นขอบของเซลล์ การทำงานกับการนับหมายเลขเซลล์หลังจากการผสานหรือการแยกเซลล์ การเปลี่ยนสีพื้นหลังของเซลล์ และการเพิ่มรูปภาพลงในเซลล์ตาราง ตัวอย่างจะแสดงวิธีสร้างหรือเปิดงานนำเสนอ การดึงตารางจากสไลด์ การอัปเดตการจัดรูปแบบเซลล์ผ่านคุณสมบัติของเซลล์ และการบันทึกงานนำเสนอที่แก้ไขเป็นไฟล์ PPTX

Aspose.Slides ใช้ดัชนีเริ่มจากศูนย์ พิกัดในบทความนี้เขียนเป็น `(คอลัมน์, แถว)`

## **ระบุตารางที่ถูกผสาน**

ตัวอย่างเปิดงานนำเสนอที่มีอยู่และเข้าถึงรูปร่างแรกบนสไลด์แรกเป็นตาราง โดยสมมติว่ามีสไลด์และรูปร่างอยู่และรูปร่างเป็นตาราง จากนั้นวนลูปผ่านทุกแถวและคอลัมน์และใช้ [is_merged_cell](https://reference.aspose.com/slides/python-net/aspose.slides/cell/is_merged_cell/) เพื่อระบุเซลล์ในพื้นที่ที่ผสาน สำหรับแต่ละผลลัพธ์จะพิมพ์พิกัดเซลล์ในรูปแบบ `row;column` พร้อมกับ [row_span](https://reference.aspose.com/slides/python-net/aspose.slides/cell/row_span/), [col_span](https://reference.aspose.com/slides/python-net/aspose.slides/cell/col_span/), และพิกัดเริ่มต้นของพื้นที่นั้น ได้แก่ [first_row_index](https://reference.aspose.com/slides/python-net/aspose.slides/cell/first_row_index/) และ [first_column_index](https://reference.aspose.com/slides/python-net/aspose.slides/cell/first_column_index/)

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

## **ลบเส้นขอบของเซลล์ตาราง**

สร้าง [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) แล้วเพิ่มตารางลงในสไลด์แรกด้วย [add_table](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_table/). ความกว้างของคอลัมน์, ความสูงของแถว, และตำแหน่งของตารางระบุเป็นจุด ตัวอย่างกำหนดให้เส้นขอบสี่ด้านของเซลล์เป็น [FillType.NO_FILL](https://reference.aspose.com/slides/python-net/aspose.slides/filltype/) ทำให้เส้นขอบไม่แสดง

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

## **ผสานเซลล์ตาราง**

ใช้ [merge_cells](https://reference.aspose.com/slides/python-net/aspose.slides/table/merge_cells/) เพื่อรวมช่วงสี่เหลี่ยมของเซลล์ตารางเป็นเซลล์เดียว ระบุตำแหน่งเซลล์บนซ้ายและล่างขวาของช่วง ส่วนอาร์กิวเมนต์สุดท้ายควบคุมว่าการผสานอาจรวมเซลล์ที่อยู่นอกช่วงที่กำหนดหรือไม่; `False` จะทำให้การผสานอยู่ภายในช่วงเท่านั้น

ตัวอย่างสร้างตารางขนาด 4x4 โดยแต่ละคอลัมน์และแถวมีความกว้าง 70 จุด แล้วผสานเซลล์ศูนย์กลางสี่เซลล์จาก `(1, 1)` ถึง `(2, 2)` เซลล์ที่ได้จะครอบคลุมสองคอลัมน์และสองแถว ในขณะที่กริดของตารางยังคงมีสี่คอลัมน์และสี่แถว การเข้าถึงเนื้อหาหรือการจัดรูปแบบของเซลล์ที่ผสานให้ใช้ตำแหน่งบนซ้าย: `table.rows[1][1]` ในตัวอย่างนี้ ตำแหน่งอื่น ๆ ในช่วงที่ผสานยังคงเป็นส่วนของกริดตาราง ดังนั้นดัชนีของเซลล์นอกช่วงจะไม่เปลี่ยน

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

การผสานเซลล์ในตัวอย่างก่อนหน้านี้ทำให้กริดของตารางคงเดิม การแยกเซลล์อาจเพิ่มคอลัมน์กริดใหม่และเปลี่ยนดัชนีของเซลล์ที่อยู่ทางขวา Aspose.Slides ปฏิบัติตามโมเดลกริดของตาราง PowerPoint

ตัวอย่างนี้สร้างตารางขนาด 4x4 โดยแต่ละคอลัมน์และแถวมีความกว้าง 70 จุด แล้วเรียกใช้ [split_by_width](https://reference.aspose.com/slides/python-net/aspose.slides/cell/split_by_width/) บนเซลล์ `(1, 1)` ครึ่งหนึ่งของความกว้าง 70 จุดจะถูกส่งเข้าไปเพื่อสร้างเซลล์สองเซลล์ที่มีความกว้างเท่า ๆ กัน

หลังจากแยกเซลล์แล้ว ครึ่งสองส่วนจะถูกเข้าถึงเป็น `table.rows[1][1]` และ `table.rows[1][2]` กริดของตารางตอนนี้มีห้าคอลัมน์: เซลล์ที่เคยอยู่ที่คอลัมน์ 2 และ 3 จะย้ายไปที่คอลัมน์ 3 และ 4 ตามลำดับ ดัชนีแถวยังคงเหมือนเดิม ใช้ดัชนีคอลัมน์ที่อัปเดตเมื่อเข้าถึงเซลล์หลังการแยก

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

### **แยกเซลล์ที่ผสานตามแถวหรือคอลัมน์**

เพื่อเตรียมเซลล์เทมเพลตที่ผสานสำหรับการเติมข้อมูล ให้ใช้ [split_by_row_span](https://reference.aspose.com/slides/python-net/aspose.slides/cell/split_by_row_span/) เพื่อแยกตามขอบแถวที่มีอยู่ หรือใช้ [split_by_col_span](https://reference.aspose.com/slides/python-net/aspose.slides/cell/split_by_col_span/) เพื่อแยกตามขอบคอลัมน์

อาร์กิวเมนต์ `index` นับแถวในส่วนบนหรือคอลัมน์ในส่วนซ้ายของการแยก; ค่าจะอิงตามพื้นที่ที่ผสาน:

- แยกตามแถว: `0 < index <` [row_span](https://reference.aspose.com/slides/python-net/aspose.slides/cell/row_span/).
- แยกตามคอลัมน์: `0 < index <` [col_span](https://reference.aspose.com/slides/python-net/aspose.slides/cell/col_span/).

ตัวอย่างสมมติว่ามีงานนำเสนอที่มีตารางเป็นรูปร่างแรกบนสไลด์แรก โดยเซลล์ `(1, 2)` และ `(1, 3)` ผสานกันแนวตั้ง เริ่มจากตำแหน่งล่าง จะใช้ [first_column_index](https://reference.aspose.com/slides/python-net/aspose.slides/cell/first_column_index/) และ [first_row_index](https://reference.aspose.com/slides/python-net/aspose.slides/cell/first_row_index/) หาแหล่งกำเนิดและตรวจสอบทั้งสองช่วง `split_by_row_span` ด้วยค่า index 1 จะทำให้แยกแถวที่ 2 และ 3 สำหรับชื่อสินค้า หากต้องการผสานสองคอลัมน์แนวนอน ให้ใช้ `split_by_col_span` ด้วยค่า index 1 แทน

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

กริดของตารางและดัชนีเซลล์รอบข้างคงเดิม ดึงเซลล์ที่ได้โดยใช้พิกัด; ทั้งสองเซลล์จะมี span เท่ากับ 1 และ [is_merged_cell](https://reference.aspose.com/slides/python-net/aspose.slides/cell/is_merged_cell/) จะคืนค่า `False` พื้นที่ที่ใหญ่กว่าสามารถคงอยู่เป็นบางส่วนที่ผสานหลังจากการแยกหนึ่งครั้ง

ข้อความและการจัดรูปแบบเดิมจะอยู่ในเซลล์บน (หรือซ้าย) เซลล์ใหม่จะว่างเปล่าแต่สืบทอดการจัดรูปแบบเซลล์ เช่น การเติม, เส้นขอบ, และขอบเขต ให้เติมข้อมูลในเซลล์หลังการแยกและตั้งค่าการจัดรูปแบบข้อความที่ต้องการอย่างชัดเจน

งานนำเสนอที่บันทึกจะมีเซลล์ “Product A” และ “Product B” แยกกันโดยคงรูปแบบเซลล์ของเทมเพลตไว้ ดูรายละเอียดได้ที่ [Cell API Reference](https://reference.aspose.com/slides/python-net/aspose.slides/cell/)

## **เปลี่ยนสีพื้นหลังของเซลล์ตาราง**

ตัวอย่างนี้สร้างตารางโดยคอลัมน์กว้าง 150 จุดและแถวสูง 50 จุด ตั้งค่า [fill_type](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/fill_type/) ให้เป็น solid และ [solid_fill_color](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/solid_fill_color/) เป็นสีแดงสำหรับเซลล์ `(2, 3)` ซึ่งอยู่ในคอลัมน์ที่สามและแถวที่สี่

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    column_widths = [150, 150, 150, 150]
    row_heights = [50, 50, 50, 50, 50]
    table = slide.shapes.add_table(50, 50, column_widths, row_heights)

    cell = table.rows[3][2]
    cell.cell_format.fill_format.fill_type = slides.FillType.SOLID
    cell.cell_format.fill_format.solid_fill_color.color = draw.Color.red

    presentation.save("cell_background_color.pptx", slides.export.SaveFormat.PPTX)
```

## **เพิ่มรูปภาพลงในเซลล์ตาราง**

ใส่รูปภาพอินพุตไว้ในไดเรกทอรีทำงานก่อนรันตัวอย่างนี้ ตัวอย่างโหลดรูปด้วย [Images.from_file](https://reference.aspose.com/slides/python-net/aspose.slides/images/from_file/) แล้วเพิ่มลงในคอลเลกชันรูปของงานนำเสนอด้วย [add_image](https://reference.aspose.com/slides/python-net/aspose.slides/imagecollection/add_image/) จากนั้นกำหนดรูปให้กับ picture fill ของเซลล์ `(0, 0)` ซึ่งเป็นเซลล์แรกของตาราง

[PictureFillMode.STRETCH](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillmode/) จะขยายรูปเพื่อเติมเซลล์ ซึ่งอาจทำให้สัดส่วนเปลี่ยนแปลง ความกว้างของคอลัมน์และความสูงของแถวระบุเป็นจุด รูปที่โหลดจะถูกทำลายอัตโนมัติเมื่อบล็อก `with` สิ้นสุด

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

## **FAQ**

**ฉันสามารถตั้งค่าความหนาและสไตล์ของเส้นขอบต่าง ๆ สำหรับด้านต่าง ๆ ของเซลล์เดียวได้หรือไม่?**

ได้. เส้นขอบ [top](https://reference.aspose.com/slides/python-net/aspose.slides/cellformat/border_top/)/[bottom](https://reference.aspose.com/slides/python-net/aspose.slides/cellformat/border_bottom/)/[left](https://reference.aspose.com/slides/python-net/aspose.slides/cellformat/border_left/)/[right](https://reference.aspose.com/slides/python-net/aspose.slides/cellformat/border_right/) มีคุณสมบัติแยกกัน ทำให้ความหนาและสไตล์ของแต่ละด้านสามารถแตกต่างกันได้

**ถ้าฉันเปลี่ยนขนาดคอลัมน์/แถวหลังจากตั้งรูปภาพเป็นพื้นหลังของเซลล์ ผลลัพธ์ของรูปจะเป็นอย่างไร?**

พฤติกรรมขึ้นอยู่กับ [fill mode](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillmode/) (stretch/tile) หากใช้การยืดรูป รูปจะปรับให้เข้ากับเซลล์ใหม่; หากใช้การทำแผ่นรูป รูปแบบแผ่นจะถูกคำนวณใหม่

**ฉันสามารถกำหนด hyperlink ให้กับเนื้อหาทั้งหมดของเซลล์ได้หรือไม่?**

[Hyperlinks](/slides/th/python-net/manage-hyperlinks/) ถูกตั้งที่ระดับข้อความ (portion) ภายใน text frame ของเซลล์ หรือที่ระดับตาราง/รูปร่างทั้งหมด ในการปฏิบัติจริง คุณจะกำหนดลิงก์ให้กับ portion หรือให้กับข้อความทั้งหมดในเซลล์

**ฉันสามารถตั้งค่าฟอนต์ต่าง ๆ ภายในเซลล์เดียวได้หรือไม่?**

ได้. text frame ของเซลล์สนับสนุน [portions](https://reference.aspose.com/slides/python-net/aspose.slides/portion/) (runs) ที่มีการจัดรูปแบบอิสระ – ฟอนต์, สไตล์, ขนาด, และสี