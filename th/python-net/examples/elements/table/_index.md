---
title: ตาราง
type: docs
weight: 120
url: /th/python-net/examples/elements/table/
keywords:
- ตาราง
- เพิ่มตาราง
- เข้าถึงตาราง
- ลบตาราง
- รวมเซลล์
- ตัวอย่างโค้ด
- PowerPoint
- OpenDocument
- การนำเสนอ
- Python
- Aspose.Slides
description: "สร้างและจัดรูปแบบตารางใน Python ด้วย Aspose.Slides: แทรกข้อมูล, รวมเซลล์, ตั้งสไตล์ขอบ, จัดแนวเนื้อหา, และนำเข้า/ส่งออกสำหรับ PPT, PPTX และ ODP."
---
ตัวอย่างการเพิ่มตาราง, การเข้าถึงตาราง, การลบตาราง และการรวมเซลล์โดยใช้ **Aspose.Slides for Python via .NET**.

## **เพิ่มตาราง**

สร้างตารางง่ายๆ ที่มีสองแถวและสองคอลัมน์.

```py
def add_table():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        # กำหนดความกว้างของคอลัมน์และความสูงของแถว.
        widths = [80, 80]
        heights = [30, 30]

        # เพิ่มรูปแบบตารางลงบนสไลด์.
        table = slide.shapes.add_table(50, 50, widths, heights)

        presentation.save("table.pptx", slides.export.SaveFormat.PPTX)
```

## **เข้าถึงตาราง**

ดึงรูปแบบตารางแรกบนสไลด์.

```py
def access_table():
    with slides.Presentation("table.pptx") as presentation:
        slide = presentation.slides[0]

        # เข้าถึงตารางแรกบนสไลด์.
        first_table = next(shape for shape in slide.shapes if isinstance(shape, slides.Table))
```

## **ลบตาราง**

ลบตารางออกจากสไลด์.

```py
def remove_table():
    with slides.Presentation("table.pptx") as presentation:
        slide = presentation.slides[0]

        # สมมติว่า shape แรกเป็นตาราง.
        table = slide.shapes[0]

        # ลบตารางออกจากสไลด์.
        slide.shapes.remove(table)

        presentation.save("table_removed.pptx", slides.export.SaveFormat.PPTX)
```

## **รวมเซลล์ตาราง**

รวมเซลล์ที่อยู่ติดกันของตารางเป็นเซลล์เดียว.

```py
def merge_table_cells():
    with slides.Presentation("table.pptx") as presentation:
        slide = presentation.slides[0]

        # สมมติว่า shape แรกเป็นตาราง.
        table = slide.shapes[0]

        # รวมเซลล์.
        table.merge_cells(table.rows[0][0], table.rows[1][1], False)

        presentation.save("cells_merged.pptx", slides.export.SaveFormat.PPTX)
```