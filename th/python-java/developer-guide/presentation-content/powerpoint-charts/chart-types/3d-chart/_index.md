---
title: ปรับแต่งแผนภูมิ 3D ในงานนำเสนอโดยใช้ Python
linktitle: แผนภูมิ 3D
type: docs
url: /th/python-java/3d-chart/
keywords:
- แผนภูมิ 3D
- การหมุน
- ความลึก
- PowerPoint
- งานนำเสนอ
- Python
- Java
- Aspose.Slides
description: "เรียนรู้วิธีสร้างและปรับแต่งแผนภูมิ 3 มิติใน Aspose.Slides สำหรับ Python ผ่าน Java พร้อมการรองรับไฟล์ PPT และ PPTX — ปรับระดับงานนำเสนอของคุณวันนี้"
---
## **ภาพรวม**

บทความนี้อธิบายวิธีปรับแต่งแผนภูมิ 3D ใน Aspose.Slides โดยกำหนดค่า [Rotation3D](https://reference.aspose.com/slides/th/python-java/aspose.slides/rotation3d/) เช่น [setRotationX](https://reference.aspose.com/slides/th/python-java/aspose.slides/rotation3d/#setRotationX), [setRotationY](https://reference.aspose.com/slides/th/python-java/aspose.slides/rotation3d/#setRotationY), [setDepthPercents](https://reference.aspose.com/slides/th/python-java/aspose.slides/rotation3d/#setDepthPercents) และ [setRightAngleAxes](https://reference.aspose.com/slides/th/python-java/aspose.slides/rotation3d/#setRightAngleAxes) มันอธิบายขั้นตอนการสร้างงานนำเสนอ, เพิ่มแผนภูมิ 3D พร้อมข้อมูลเริ่มต้น, ตั้งค่าการมอง 3D ที่จำเป็น, และบันทึกงานนำเสนอที่แก้ไขเป็นไฟล์ PPTX

## **ตั้งค่า X Rotation, Y Rotation และ Depth ของแผนภูมิ 3D**
Aspose.Slides for Python via Java มี API อย่างง่ายสำหรับการตั้งค่าเหล่านี้ ตัวอย่างต่อไปนี้แสดงวิธีตั้งค่า X rotation, Y rotation และ depth ของแผนภูมิ 3D

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentation/)
1. เข้าถึงสไลด์แรก
1. เพิ่มแผนภูมิพร้อมข้อมูลเริ่มต้น
1. ตั้งค่าคุณสมบัติการหมุน 3D
1. เขียนงานนำเสนอที่แก้ไขลงในไฟล์ PPTX

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    # เข้าถึงสไลด์แรก.
    slide = presentation.getSlides().get_Item(0)

    # เพิ่มแผนภูมิด้วยข้อมูลเริ่มต้น.
    chart = slide.getShapes().addChart(ChartType.StackedColumn3D, 0, 0, 500, 500)

    # ตั้งค่าดัชนี worksheet ของข้อมูลแผนภูมิ.
    default_worksheet_index = 0

    # รับ workbook ของข้อมูลแผนภูมิ.
    workbook = chart.getChartData().getChartDataWorkbook()

    # เพิ่ม series.
    series_cell = workbook.getCell(default_worksheet_index, 0, 1, "Series 1")
    chart.getChartData().getSeries().add(series_cell, chart.getType())
    series_cell = workbook.getCell(default_worksheet_index, 0, 2, "Series 2")
    chart.getChartData().getSeries().add(series_cell, chart.getType())

    # เพิ่ม categories.
    category_cell = workbook.getCell(default_worksheet_index, 1, 0, "Category 1")
    chart.getChartData().getCategories().add(category_cell)
    category_cell = workbook.getCell(default_worksheet_index, 2, 0, "Category 2")
    chart.getChartData().getCategories().add(category_cell)
    category_cell = workbook.getCell(default_worksheet_index, 3, 0, "Category 3")
    chart.getChartData().getCategories().add(category_cell)

    # ตั้งค่าคุณสมบัติการหมุน 3D.
    chart.getRotation3D().setRightAngleAxes(True)
    chart.getRotation3D().setRotationX(jpype.JByte(40))
    chart.getRotation3D().setRotationY(270)
    chart.getRotation3D().setDepthPercents(150)

    # เข้าถึง series ของแผนภูมิที่สอง.
    series = chart.getChartData().getSeries().get_Item(1)

    # เติมข้อมูลให้ series.
    data_cell = workbook.getCell(default_worksheet_index, 1, 1, jpype.JInt(20))
    series.getDataPoints().addDataPointForBarSeries(data_cell)
    data_cell = workbook.getCell(default_worksheet_index, 2, 1, jpype.JInt(50))
    series.getDataPoints().addDataPointForBarSeries(data_cell)
    data_cell = workbook.getCell(default_worksheet_index, 3, 1, jpype.JInt(30))
    series.getDataPoints().addDataPointForBarSeries(data_cell)
    data_cell = workbook.getCell(default_worksheet_index, 1, 2, jpype.JInt(30))
    series.getDataPoints().addDataPointForBarSeries(data_cell)
    data_cell = workbook.getCell(default_worksheet_index, 2, 2, jpype.JInt(10))
    series.getDataPoints().addDataPointForBarSeries(data_cell)
    data_cell = workbook.getCell(default_worksheet_index, 3, 2, jpype.JInt(60))
    series.getDataPoints().addDataPointForBarSeries(data_cell)

    # บันทึกงานนำเสนอ.
    presentation.save("Rotation3D_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **คำถามที่พบบ่อย**

**แผนภูมิประเภทใดที่รองรับโหมด 3D ใน Aspose.Slides?**

Aspose.Slides รองรับรูปแบบ 3D ของแผนภูมิคอลัมน์ รวมถึง Column 3D, Clustered Column 3D, Stacked Column 3D, และ 100% Stacked Column 3D พร้อมประเภท 3D ที่เกี่ยวข้องที่เปิดเผยผ่านคลาส [ChartType](https://reference.aspose.com/slides/th/python-java/aspose.slides/charttype/) หากต้องการรายการที่แม่นยำและเป็นปัจจุบัน ให้ตรวจสอบสมาชิกของ [ChartType](https://reference.aspose.com/slides/th/python-java/aspose.slides/charttype/) ในเอกสารอ้างอิง API ของรุ่นที่ติดตั้งอยู่

**ฉันสามารถรับรูปภาพเรสเตอร์ของแผนภูมิ 3D สำหรับรายงานหรือเว็บได้หรือไม่?**

ใช่ คุณสามารถส่งออกแผนภูมิเป็นภาพผ่าน [chart API](https://reference.aspose.com/slides/th/python-java/aspose.slides/shape/#getImage) หรือ [render the entire slide](/slides/th/python-java/convert-powerpoint-to-png/) เป็นรูปแบบเช่น PNG หรือ JPEG ได้ สิ่งนี้มีประโยชน์เมื่อคุณต้องการตัวอย่างภาพที่พิกเซลสมบูรณ์หรือฝังแผนภูมิลงในเอกสาร, แดชบอร์ด หรือหน้าเว็บโดยไม่ต้องใช้ PowerPoint

**ประสิทธิภาพการสร้างและเรนเดอร์แผนภูมิ 3D ขนาดใหญ่เป็นอย่างไร?**

ประสิทธิภาพขึ้นอยู่กับปริมาณข้อมูลและความซับซ้อนของภาพ สำหรับผลลัพธ์ที่ดีที่สุด ควรลดเอฟเฟกต์ 3D ให้เหลือน้อยที่สุด, หลีกเลี่ยงการใช้พื้นผิวหนาบนผนังและพื้นที่พล็อต, จำกัดจำนวนจุดข้อมูลต่อซีรีส์เมื่อทำได้, และเรนเดอร์เป็นเอาต์พุตที่มีขนาดเหมาะสม (ความละเอียดและมิติ) เพื่อให้ตรงกับการแสดงผลหรือการพิมพ์ที่ต้องการ