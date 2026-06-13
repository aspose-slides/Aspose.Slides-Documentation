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
- OpenDocument
- งานนำเสนอ
- Python
- Aspose.Slides
description: "จัดการเซลล์ตารางใน PowerPoint และ OpenDocument ด้วย Aspose.Slides สำหรับ Python ผ่าน .NET อย่างง่ายดาย ทำการเข้าถึง, แก้ไข, และจัดรูปแบบเซลล์ได้อย่างเชี่ยวชาญและรวดเร็วเพื่อการอัตโนมัติสไลด์ที่ไม่มีสะดุด"
---
## **ภาพรวม**

Aspose.Slides อนุญาตให้คุณเข้าถึงและแก้ไขเซลล์ตารางในงานนำเสนอ PowerPoint บทความนี้อธิบายวิธีระบุเซลล์ตารางที่ถูกรวมกัน, ลบขอบเซลล์, ทำงานกับการกำหนดหมายเลขเซลล์หลังจากการรวมหรือแยกเซลล์, เปลี่ยนสีพื้นหลังของเซลล์, และเพิ่มรูปภาพภายในเซลล์ตาราง ตัวอย่างแสดงวิธีสร้างหรือเปิดงานนำเสนอ, ดึงตารางจากสไลด์, ปรับรูปแบบเซลล์ผ่านคุณสมบัติของเซลล์, และบันทึกงานนำเสนอที่แก้ไขเป็นไฟล์ PPTX

## **ระบุเซลล์ตารางที่ถูกรวมกัน**

ตารางมักมีเซลล์ที่ถูกรวมกันเพื่อเป็นหัวข้อหรือจัดกลุ่มข้อมูลที่เกี่ยวข้อง ในส่วนนี้คุณจะเห็นวิธีกำหนดว่าเซลล์ใดเป็นส่วนหนึ่งของพื้นที่ที่ถูกรวมและวิธีอ้างอิงเซลล์หลัก (ซ้ายบน) เพื่อให้คุณสามารถอ่านหรือจัดรูปแบบบล็อกทั้งหมดได้อย่างสม่ำเสมอ

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/) .
1. ดึงตารางจากสไลด์แรก .
1. วนลูปผ่านแถวและคอลัมน์ของตารางเพื่อค้นหาเซลล์ที่ถูกรวม .
1. พิมพ์ข้อความเมื่อพบเซลล์ที่ถูกรวม .

โค้ด Python ต่อไปนี้ระบุเซลล์ตารางที่ถูกรวมในงานนำเสนอ:

```py
import aspose.slides as slides

with slides.Presentation("presentation_with_table.pptx") as presentation:
    # สมมติว่า shape แรกบนสไลด์แรกเป็นตาราง.
    table = presentation.slides[0].shapes[0]

    for row_index in range(len(table.rows)):
        for column_index in range(len(table.columns)):
            cell = table.rows[row_index][column_index]
            if cell.is_merged_cell:
                print("Cell ({}, {}) is part of a merged region with a row span of {} and a column span of {}, starting from cell ({}, {}).".format(
                    row_index, column_index, cell.row_span, cell.col_span, cell.first_row_index, cell.first_column_index))
```

## **ลบขอบเซลล์ตาราง**

บางครั้งขอบตารางอาจทำให้เนื้อหาดูรกหรือสร้างความสับสน ส่วนนี้แสดงวิธีลบขอบจากเซลล์ที่เลือก—หรือจากด้านเฉพาะของเซลล์—เพื่อให้ได้เค้าโครงที่สะอาดตาและสอดคล้องกับการออกแบบสไลด์ของคุณ

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/) .
1. ดึงสไลด์โดยใช้ดัชนีของมัน .
1. กำหนดอาเรย์ของความกว้างคอลัมน์ .
1. กำหนดอาเรย์ของความสูงแถว .
1. เพิ่มตารางลงในสไลด์โดยใช้เมธอด [add_table](https://reference.aspose.com/slides/th/python-net/aspose.slides/shapecollection/add_table/) .
1. วนลูปผ่านแต่ละเซลล์เพื่อเคลียร์ขอบบน, ล่าง, ซ้าย, และขวา .
1. บันทึกงานนำเสนอที่แก้ไขเป็นไฟล์ PPTX .

โค้ด Python ต่อไปนี้แสดงวิธีลบขอบจากเซลล์ตาราง:

```python
import aspose.slides as slides

# สร้างอินสแตนซ์ของคลาส Presentation ที่เป็นตัวแทนไฟล์ PPTX.
with slides.Presentation() as presentation:
    # เข้าถึงสไลด์แรก.
    slide = presentation.slides[0]

    # กำหนดคอลัมน์ด้วยความกว้างและแถวด้วยความสูง.
    column_widths = [50, 50, 50, 50]
    row_heights = [50, 30, 30, 30, 30]

    # เพิ่มรูปแบบตารางลงในสไลด์.
    table = slide.shapes.add_table(50, 50, column_widths, row_heights)

    # ล้างการเติมขอบของแต่ละเซลล์.
    for row in table.rows:
        for cell in row:
            cell.cell_format.border_top.fill_format.fill_type = slides.FillType.NO_FILL
            cell.cell_format.border_bottom.fill_format.fill_type = slides.FillType.NO_FILL
            cell.cell_format.border_left.fill_format.fill_type = slides.FillType.NO_FILL
            cell.cell_format.border_right.fill_format.fill_type = slides.FillType.NO_FILL

    # บันทึกไฟล์ PPTX ลงดิสก์.
    presentation.save("table.pptx", slides.export.SaveFormat.PPTX)
```

## **การกำหนดหมายเลขในเซลล์ที่ถูกรวม**

หากคุณรวมเซลล์สองคู่—for example, (1, 1) x (2, 1) และ (1, 2) x (2, 2)—ตารางที่ได้จะรักษาการกำหนดหมายเลขเซลล์เช่นเดียวกับตารางที่ไม่ได้รวม โค้ด Python ต่อไปนี้สาธิตพฤติกรรมนี้:

```python
import aspose.slides as slides

# สร้างอินสแตนซ์ของคลาส Presentation ที่เป็นตัวแทนไฟล์ PPTX.
with slides.Presentation() as presentation:
    # เข้าถึงสไลด์แรก.
    slide = presentation.slides[0]

    # กำหนดคอลัมน์ด้วยความกว้างและแถวด้วยความสูง.
    column_widths = [70, 70, 70, 70]
    row_heights = [70, 70, 70, 70]

    # เพิ่มรูปแบบตารางลงในสไลด์.
    table = slide.shapes.add_table(50, 50, column_widths, row_heights)

    # รวมเซลล์ (1,1) และ (2,1).
    table.merge_cells(table.rows[1][1], table.rows[2][1], False)

    # รวมเซลล์ (1, 2) และ (2, 2).
    table.merge_cells(table.rows[1][2], table.rows[2][2], False)

    # พิมพ์ดัชนีของเซลล์.
    for row_index in range(len(table.rows)):
        for column_index in range(len(table.rows[row_index])):
            cell = table.rows[row_index][column_index]
            print(f"{cell.first_row_index, cell.first_column_index} ", end="")
        print()

    # บันทึกไฟล์ PPTX ลงดิสก์.
    presentation.save("merged_cells.pptx", slides.export.SaveFormat.PPTX)
```

ผลลัพธ์:

```text
(0, 0) (0, 1) (0, 2) (0, 3) 
(1, 0) (1, 1) (1, 2) (1, 3) 
(2, 0) (1, 1) (1, 2) (2, 3) 
(3, 0) (3, 1) (3, 2) (3, 3)
```

## **การกำหนดหมายเลขในเซลล์ที่แยกออก**

ในตัวอย่างก่อนหน้า เมื่อเซลล์ตารางถูกรวม การกำหนดหมายเลขในเซลล์อื่น ๆ ไม่เปลี่ยนแปลง ครั้งนี้เราจะสร้างตารางปกติ (ไม่มีเซลล์ที่รวม) แล้วแยกเซลล์ (1, 1) เพื่อสร้างตารางพิเศษ ใส่ใจกับการกำหนดหมายเลขของตารางนี้—อาจดูแปลก แต่นี่คือวิธีที่ Microsoft PowerPoint กำหนดหมายเลขเซลล์ตาราง และ Aspose.Slides ปฏิบัติตามพฤติกรรมเดียวกัน

โค้ด Python ต่อไปนี้สาธิตพฤติกรรมนี้:

```python
import aspose.slides as slides

# สร้างอินสแตนซ์ของคลาส Presentation ที่เป็นตัวแทนไฟล์ PPTX.
with slides.Presentation() as presentation:
    # เข้าถึงสไลด์แรก.
    slide = presentation.slides[0]

    # กำหนดความกว้างของคอลัมน์และความสูงของแถว.
    column_widths = [70, 70, 70, 70]
    row_heights = [70, 70, 70, 70]

    # เพิ่มรูปแบบตารางลงในสไลด์.
    table = slide.shapes.add_table(50, 50, column_widths, row_heights)

    # แบ่งเซลล์ (1, 1).
    table.rows[1][1].split_by_width(table.rows[2][1].width / 2)

    # พิมพ์ดัชนีของเซลล์.
    for row_index in range(len(table.rows)):
        for column_index in range(len(table.rows[row_index])):
            cell = table.rows[row_index][column_index]
            print(f"{cell.first_row_index, cell.first_column_index} ", end="")
        print()

    # บันทึกไฟล์ PPTX ลงดิสก์.
    presentation.save("split_cells.pptx", slides.export.SaveFormat.PPTX)
```

ผลลัพธ์:

```text
(0, 0) (0, 1) (0, 1) (0, 3) (0, 4) 
(1, 0) (1, 1) (1, 2) (1, 3) (1, 4) 
(2, 0) (2, 1) (2, 1) (2, 3) (2, 4) 
(3, 0) (3, 1) (3, 1) (3, 3) (3, 4) 
```

## **เปลี่ยนสีพื้นหลังของเซลล์ตาราง**

ตัวอย่าง Python ต่อไปนี้สาธิตวิธีเปลี่ยนสีพื้นหลังของเซลล์ตาราง:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    column_widths = [150, 150, 150, 150]
    row_heights = [50, 50, 50, 50, 50]

    # สร้างตารางใหม่.
    table = slide.shapes.add_table(50, 50, column_widths, row_heights)

    # ตั้งค่าสีพื้นหลังให้กับเซลล์.
    cell = table.rows[2][3]
    cell.cell_format.fill_format.fill_type = slides.FillType.SOLID
    cell.cell_format.fill_format.solid_fill_color.color = draw.Color.red

    presentation.save("cell_background_color.pptx", slides.export.SaveFormat.PPTX)
```

## **แทรกรูปภาพลงในเซลล์ตาราง**

ส่วนนี้แสดงวิธีแทรกรูปภาพลงในเซลล์ตารางใน Aspose.Slides รวมถึงการใช้ picture fill กับเซลล์เป้าหมายและการกำหนดตัวเลือกการแสดงผล เช่น stretch หรือ tile

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/) .
1. ดึงอ้างอิงสไลด์โดยใช้ดัชนีของมัน .
1. กำหนดอาเรย์ของความกว้างคอลัมน์ .
1. กำหนดอาเรย์ของความสูงแถว .
1. เพิ่มตารางลงในสไลด์ด้วยเมธอด [add_table](https://reference.aspose.com/slides/th/python-net/aspose.slides/shapecollection/add_table/) .
1. โหลดรูปภาพจากไฟล์ .
1. เพิ่มรูปภาพลงใน images ของงานนำเสนอเพื่อให้ได้วัตถุ [PPImage](https://reference.aspose.com/slides/th/python-net/aspose.slides/ppimage/) .
1. ตั้งค่า [FillType](https://reference.aspose.com/slides/th/python-net/aspose.slides/filltype/) ของเซลล์ตารางเป็น `PICTURE` .
1. นำรูปภาพไปใช้กับเซลล์ตารางและเลือกโหมดการเติม (เช่น `STRETCH`) .
1. บันทึกงานนำเสนอเป็นไฟล์ PPTX .

โค้ด Python ต่อไปนี้แสดงวิธีใส่รูปภาพภายในเซลล์ตารางเมื่อสร้างตาราง:

```python
import aspose.slides as slides

# สร้างอ็อบเจ็กต์ Presentation.
with slides.Presentation() as presentation:
    # เข้าถึงสไลด์แรก.
    slide = presentation.slides[0]

    # กำหนดความกว้างของคอลัมน์และความสูงของแถว.
    column_widths = [150, 150, 150, 150]
    row_heights = [100, 100, 100, 100]

    # เพิ่มรูปแบบตารางลงในสไลด์.
    table = slide.shapes.add_table(50, 50, column_widths, row_heights)

    # โหลดภาพและเพิ่มเข้าไปในงานนำเสนอเพื่อให้ได้วัตถุ PPImage.
    with slides.Images.from_file("image.png") as source_image:
        image = presentation.images.add_image(source_image)

    # นำภาพไปใช้กับเซลล์ตารางแรก.
    cell = table.rows[0][0]
    cell.cell_format.fill_format.fill_type = slides.FillType.PICTURE
    cell.cell_format.fill_format.picture_fill_format.picture_fill_mode = slides.PictureFillMode.STRETCH
    cell.cell_format.fill_format.picture_fill_format.picture.image = image

    # บันทึกงานนำเสนอลงดิสก์.
    presentation.save("image_in_table_cell.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**ฉันสามารถกำหนดความหนาและสไตล์ของเส้นขอบที่ต่างกันสำหรับแต่ละด้านของเซลล์เดียวได้หรือไม่?**

ได้. ขอบ [top](https://reference.aspose.com/slides/th/python-net/aspose.slides/cellformat/border_top/)/[bottom](https://reference.aspose.com/slides/th/python-net/aspose.slides/cellformat/border_bottom/)/[left](https://reference.aspose.com/slides/th/python-net/aspose.slides/cellformat/border_left/)/[right](https://reference.aspose.com/slides/th/python-net/aspose.slides/cellformat/border_right/) มีคุณสมบัติแยกกัน ดังนั้นความหนาและสไตล์ของแต่ละด้านจึงสามารถต่างกันได้ สิ่งนี้สอดคล้องกับการควบคุมขอบแต่ละด้านของเซลล์ที่อธิบายในบทความ

**ภาพจะเป็นอย่างไรหากฉันเปลี่ยนขนาดคอลัมน์หรือแถวหลังจากตั้งภาพเป็นพื้นหลังของเซลล์?**

พฤติกรรมขึ้นอยู่กับ [fill mode](https://reference.aspose.com/slides/th/python-net/aspose.slides/picturefillmode/) (stretch/tile) หากเลือก stretch ภาพจะปรับให้พอดีกับเซลล์ใหม่; หากเลือก tile ไทล์จะถูกคำนวณใหม่ บทความได้อธิบายโหมดการแสดงผลภาพในเซลล์

**ฉันสามารถกำหนดไฮเปอร์ลิงก์ให้กับเนื้อหาทั้งหมดของเซลล์ได้หรือไม่?**

[Hyperlinks](/slides/th/python-net/manage-hyperlinks/) ถูกตั้งค่าที่ระดับข้อความ (portion) ภายใน text frame ของเซลล์หรือที่ระดับของตาราง/shape ทั้งหมด ในการปฏิบัติ คุณสามารถกำหนดลิงก์ให้กับ portion หรือให้กับข้อความทั้งหมดในเซลล์

**ฉันสามารถกำหนดฟอนต์ที่ต่างกันภายในเซลล์เดียวได้หรือไม่?**

ได้. text frame ของเซลล์รองรับ [portions](https://reference.aspose.com/slides/th/python-net/aspose.slides/portion/) (runs) ที่มีการฟอร์แมตอิสระ—เช่น ฟอนต์, สไตล์, ขนาด, และสี