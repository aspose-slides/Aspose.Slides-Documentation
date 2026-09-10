---
title: จัดการตัวทำเครื่องหมายข้อมูลแผนภูมิในงานนำเสนอด้วย Python
linktitle: ตัวทำเครื่องหมายข้อมูล
type: docs
url: /th/python-java/chart-data-marker/
keywords:
- แผนภูมิ
- จุดข้อมูล
- ตัวทำเครื่องหมาย
- ตัวเลือกตัวทำเครื่องหมาย
- ขนาดตัวทำเครื่องหมาย
- ประเภทการเติม
- PowerPoint
- งานนำเสนอ
- Python
- Java
- Aspose.Slides
description: "เรียนรู้วิธีปรับแต่งตัวทำเครื่องหมายข้อมูลแผนภูมิใน Aspose.Slides สำหรับ Python ผ่าน Java เพื่อเพิ่มผลกระทบของงานนำเสนอในรูปแบบ PPT และ PPTX ด้วยตัวอย่างโค้ด Python ที่ชัดเจน"
---
## **ภาพรวม**

บทความนี้อธิบายวิธีการทำงานกับตัวทำเครื่องหมายข้อมูลแผนภูมิใน Aspose.Slides แสดงวิธีการสร้างแผนภูมิ, เข้าถึงซีรีส์และจุดข้อมูลของมัน, ใช้การเติมรูปภาพกับตัวทำเครื่องหมายในระดับจุดข้อมูล, ปรับขนาดตัวทำเครื่องหมาย, และบันทึกงานนำเสนอที่อัปเดตแล้ว นอกจากนี้ยังระบุว่ารูปร่างตัวทำเครื่องหมายมาตรฐานสามารถใช้ได้ผ่าน enumeration [MarkerStyleType](https://reference.aspose.com/slides/th/python-java/aspose.slides/markerstyletype/) และรูปลักษณ์ของตัวทำเครื่องหมายจะถูกเก็บไว้เมื่อนำแผนภูมิส่งออกเป็นรูปแบบเรสเตอร์หรือ SVG

## **ตั้งค่าตัวทำเครื่องหมายแผนภูมิ**
สามารถตั้งค่าตัวทำเครื่องหมายบนจุดข้อมูลของแผนภูมิในซีรีส์ที่กำหนดได้ เพื่อกำหนดตัวเลือกตัวทำเครื่องหมายของแผนภูมิ ให้ทำตามขั้นตอนต่อไปนี้:

- สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentation/)
- สร้างแผนภูมิเริ่มต้น
- ตั้งค่ารูปภาพ
- เข้าถึงซีรีส์แผนภูมิแรก
- เพิ่มจุดข้อมูลใหม่
- บันทึกงานนำเสนอลงดิสก์

ตัวอย่างต่อไปนี้ตั้งค่าตัวทำเครื่องหมายแผนภูมิในระดับจุดข้อมูล

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, FillType, Presentation, SaveFormat

# สร้างงานนำเสนอเปล่า.
presentation = Presentation()
try:
    # เข้าถึงสไลด์แรก
    slide = presentation.getSlides().get_Item(0)

    # สร้างแผนภูมิเริ่มต้น
    chart = slide.getShapes().addChart(ChartType.LineWithMarkers, 0, 0, 400, 400)

    # รับดัชนีแผ่นงานข้อมูลแผนภูมิเริ่มต้น.
    default_worksheet_index = 0

    # รับสมุดงานข้อมูลแผนภูมิ.
    workbook = chart.getChartData().getChartDataWorkbook()

    # ลบซีรีส์ตัวอย่าง
    chart.getChartData().getSeries().clear()

    # เพิ่มซีรีส์ใหม่
    series_name_cell = workbook.getCell(default_worksheet_index, 1, 1, "Series 1")
    chart.getChartData().getSeries().add(series_name_cell, chart.getType())

    # โหลดรูปภาพแรก.
    desert_bytes = Path("Desert.jpg").read_bytes()
    desert_image = presentation.getImages().addImage(jpype.JArray(jpype.JByte)(desert_bytes))

    # โหลดรูปภาพที่สอง.
    tulips_bytes = Path("Tulips.jpg").read_bytes()
    tulips_image = presentation.getImages().addImage(jpype.JArray(jpype.JByte)(tulips_bytes))

    # เข้าถึงซีรีส์แผนภูมิแรก.
    series = chart.getChartData().getSeries().get_Item(0)

    # เพิ่มจุดข้อมูล.
    value_cell = workbook.getCell(default_worksheet_index, 1, 1, 4.5)
    point = series.getDataPoints().addDataPointForLineSeries(value_cell)
    point.getMarker().getFormat().getFill().setFillType(FillType.Picture)
    point.getMarker().getFormat().getFill().getPictureFillFormat().getPicture().setImage(desert_image)

    value_cell = workbook.getCell(default_worksheet_index, 2, 1, 2.5)
    point = series.getDataPoints().addDataPointForLineSeries(value_cell)
    point.getMarker().getFormat().getFill().setFillType(FillType.Picture)
    point.getMarker().getFormat().getFill().getPictureFillFormat().getPicture().setImage(tulips_image)

    value_cell = workbook.getCell(default_worksheet_index, 3, 1, 3.5)
    point = series.getDataPoints().addDataPointForLineSeries(value_cell)
    point.getMarker().getFormat().getFill().setFillType(FillType.Picture)
    point.getMarker().getFormat().getFill().getPictureFillFormat().getPicture().setImage(desert_image)

    value_cell = workbook.getCell(default_worksheet_index, 4, 1, 4.5)
    point = series.getDataPoints().addDataPointForLineSeries(value_cell)
    point.getMarker().getFormat().getFill().setFillType(FillType.Picture)
    point.getMarker().getFormat().getFill().getPictureFillFormat().getPicture().setImage(tulips_image)

    # เปลี่ยนขนาดตัวทำเครื่องหมายของซีรีส์แผนภูมิ
    series.getMarker().setSize(15)

    # บันทึกงานนำเสนอพร้อมแผนภูมิ
    presentation.save("MarkOptions_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **คำถามที่พบบ่อย**

**รูปร่างตัวทำเครื่องหมายที่มีให้โดยมาตรฐานคืออะไร?**

มีรูปร่างมาตรฐาน (วงกลม, สี่เหลี่ยม, เพชร, สามเหลี่ยม ฯลฯ) รายการนี้กำหนดโดยคลาส [MarkerStyleType](https://reference.aspose.com/slides/th/python-java/aspose.slides/markerstyletype/) หากต้องการรูปร่างที่ไม่เป็นมาตรฐาน ให้ใช้ตัวทำเครื่องหมายที่เติมรูปภาพเพื่อจำลองภาพที่กำหนดเอง

**ตัวทำเครื่องหมายจะถูกเก็บไว้เมื่อส่งออกแผนภูมิเป็นภาพหรือ SVG หรือไม่?**

ใช่ เมื่อนำแผนภูมิเรนเดอร์เป็น [รูปแบบเรสเตอร์](/slides/th/python-java/convert-powerpoint-to-png/) หรือบันทึก [รูปร่างเป็น SVG](/slides/th/python-java/render-a-slide-as-an-svg-image/) ตัวทำเครื่องหมายจะคงรูปลักษณ์และการตั้งค่าต่างๆ รวมถึงขนาด, การเติม, และเส้นขอบไว้ 