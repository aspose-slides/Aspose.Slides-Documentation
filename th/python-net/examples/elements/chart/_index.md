---
title: แผนภูมิ
type: docs
weight: 60
url: /th/python-net/examples/elements/chart/
keywords:
- แผนภูมิ
- เพิ่มแผนภูมิ
- เข้าถึงแผนภูมิ
- ลบแผนภูมิ
- อัปเดตแผนภูมิ
- ตัวอย่างโค้ด
- PowerPoint
- OpenDocument
- งานนำเสนอ
- Python
- Aspose.Slides
description: "สร้างและปรับแต่งแผนภูมิใน Python ด้วย Aspose.Slides: เพิ่มข้อมูล, จัดรูปแบบซีรีส์, แกนและป้ายกำกับ, เปลี่ยนประเภท, และส่งออก—ทำงานกับ PPT, PPTX และ ODP."
---
ตัวอย่างการเพิ่ม, เข้าถึง, ลบ และอัปเดตประเภทแผนภูมิต่าง ๆ ด้วย **Aspose.Slides for Python via .NET**. โค้ดตัวอย่างด้านล่างแสดงการดำเนินการพื้นฐานของแผนภูมิ.

## **เพิ่มแผนภูมิ**

เมธอดนี้เพิ่มแผนภูมิแบบพื้นที่ง่าย ๆ ไปยังสไลด์แรก.

```py
def add_chart():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        # เพิ่มแผนภูมิคอลัมน์ง่าย ๆ ไปยังสไลด์แรก.
        chart = slide.shapes.add_chart(slides.charts.ChartType.AREA, 50, 50, 400, 300)

        presentation.save("chart.pptx", slides.export.SaveFormat.PPTX)
```

## **เข้าถึงแผนภูมิ**

โค้ดต่อไปนี้ดึงแผนภูมิจากคอลเลกชันรูปทรง.

```py
def access_chart():
    with slides.Presentation("chart.pptx") as presentation:
        slide = presentation.slides[0]

        # เข้าถึงแผนภูมิแรกบนสไลด์.
        first_chart = None
        for shape in slide.shapes:
            if isinstance(shape, slides.charts.Chart):
                first_chart = shape
                break
```

## **ลบแผนภูมิ**

โค้ดต่อไปนี้ลบแผนภูมิออกจากสไลด์.

```py
def remove_chart():
    with slides.Presentation("chart.pptx") as presentation:
        slide = presentation.slides[0]

        # สมมติว่า shape แรกเป็นแผนภูมิ.
        chart = slide.shapes[0]

        # ลบแผนภูมิ.
        slide.shapes.remove(chart)

        presentation.save("chart_removed.pptx", slides.export.SaveFormat.PPTX)
```

## **อัปเดตข้อมูลแผนภูมิ**

คุณสามารถเปลี่ยนคุณสมบัติของแผนภูมิ เช่น ชื่อเรื่อง.

```py
def update_chart_data():
    with slides.Presentation("chart.pptx") as presentation:
        slide = presentation.slides[0]

        # สมมติว่า shape แรกเป็นแผนภูมิ.
        chart = slide.shapes[0]

        # เปลี่ยนชื่อแผนภูมิ.
        chart.chart_title.add_text_frame_for_overriding("Sales Report")

        presentation.save("chart_updated.pptx", slides.export.SaveFormat.PPTX)
```