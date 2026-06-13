---
title: เพิ่มประสิทธิภาพการคำนวณแผนภูมิสำหรับการนำเสนอใน Python
linktitle: การคำนวณแผนภูมิ
type: docs
weight: 50
url: /th/python-net/chart-calculations/
keywords:
- การคำนวณแผนภูมิ
- องค์ประกอบแผนภูมิ
- ตำแหน่งขององค์ประกอบ
- ตำแหน่งจริง
- องค์ประกอบลูก
- องค์ประกอบพาเรนต์
- ค่าแผนภูมิ
- ค่าจริง
- PowerPoint
- OpenDocument
- การนำเสนอ
- Python
- Aspose.Slides
description: "ทำความเข้าใจการคำนวณแผนภูมิ การอัปเดตข้อมูล และการควบคุมความแม่นยำใน Aspose.Slides สำหรับ Python ผ่าน .NET สำหรับ PPT, PPTX และ ODP พร้อมตัวอย่างโค้ดจริง"
---
## **ภาพรวม**

Aspose.Slides มี API สำหรับทำงานกับการคำนวณแผนภูมิและข้อมูลการจัดวางในงานนำเสนอ บทความนี้แสดงวิธีดึงค่าแท้จริงขององค์ประกอบแผนภูมิ รวมถึงตำแหน่งและขนาดที่แท้จริงขององค์ประกอบที่ใช้ `ActualLayout` และค่าที่แท้จริงของแกนแผนภูมิ นอกจากนี้ยังอธิบายว่าค่าเหล่านี้จะถูกกำหนดหลังจากทำการตรวจสอบการจัดวางแผนภูมิ

นอกจากนี้ บทความยังสาธิตวิธีการรับตำแหน่งที่แท้จริงขององค์ประกอบแผนภูมิพาเรนต์และวิธีการซ่อนส่วนประกอบของแผนภูมิ เช่น ชื่อเรื่อง, แกน, คำอธิบาย, และเส้นตาราง ตัวอย่างเหล่านี้ช่วยให้คุณตรวจสอบข้อมูลการจัดวางแผนภูมิและควบคุมการแสดงผลขององค์ประกอบแผนภูมิในงานนำเสนอ PowerPoint ผ่านโปรแกรมได้

## **คำนวณค่าที่แท้จริงขององค์ประกอบแผนภูมิ**
Aspose.Slides for Python via .NET มี API ง่าย ๆ สำหรับการดึงคุณสมบัติเหล่านี้ ซึ่งจะช่วยให้คุณคำนวณค่าที่แท้จริงขององค์ประกอบแผนภูมิ ค่าที่แท้จริงรวมถึงตำแหน่งขององค์ประกอบที่สืบทอดคลาส [IActualLayout](https://reference.aspose.com/slides/th/python-net/aspose.slides.charts/iactuallayout/) (IActualLayout.ActualX, IActualLayout.ActualY, IActualLayout.ActualWidth, IActualLayout.ActualHeight) และค่าที่แท้จริงของแกน (IAxis.ActualMaxValue, IAxis.ActualMinValue, IAxis.ActualMajorUnit, IAxis.ActualMinorUnit, IAxis.ActualMajorUnitScale, IAxis.ActualMinorUnitScale).

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation("pres.pptx") as pres:
    chart = pres.slides[0].shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 100, 100, 500, 350)
    chart.validate_chart_layout()

    maxValue = chart.axes.vertical_axis.actual_max_value
    minValue = chart.axes.vertical_axis.actual_min_value
    majorUnit = chart.axes.horizontal_axis.actual_major_unit
    minorUnit = chart.axes.horizontal_axis.actual_minor_unit
```

## **คำนวณตำแหน่งที่แท้จริงขององค์ประกอบแผนภูมิพาเรนต์**
Aspose.Slides for Python via .NET มี API ง่าย ๆ สำหรับการดึงคุณสมบัติเหล่านี้ คุณสมบัติของ IActualLayout ให้ข้อมูลเกี่ยวกับตำแหน่งที่แท้จริงขององค์ประกอบแผนภูมิพาเรนต์ จำเป็นต้องเรียกเมธอด IChart.ValidateChartLayout() ก่อนหน้าเพื่อเติมคุณสมบัติด้วยค่าที่แท้จริง

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation("pres.pptx") as pres:
    chart = pres.slides[0].shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 100, 100, 500, 350)
    chart.validate_chart_layout()

    x = chart.plot_area.actual_x
    y = chart.plot_area.actual_y
    w = chart.plot_area.actual_width
    h = chart.plot_area.actual_height
```

## **ซ่อนข้อมูลจากแผนภูมิ**
หัวข้อนี้ช่วยให้คุณเข้าใจวิธีการซ่อนข้อมูลจากแผนภูมิ โดยใช้ Aspose.Slides for Python via .NET คุณสามารถซ่อน **Title, Vertical Axis, Horizontal Axis** และ **Grid Lines** จากแผนภูมิได้ ตัวอย่างโค้ดด้านล่างแสดงวิธีการใช้คุณสมบัติเหล่านี้

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as pres:
    slide = pres.slides[0]
    chart = slide.shapes.add_chart(charts.ChartType.LINE_WITH_MARKERS, 140, 118, 320, 370)

    # ซ่อนชื่อแผนภูมิ
    chart.has_title = False

    # ซ่อนแกนค่า
    chart.axes.vertical_axis.is_visible = False

    # การมองเห็นแกนหมวดหมู่
    chart.axes.horizontal_axis.is_visible = False

    # ซ่อนคำอธิบาย
    chart.has_legend = False

    # ซ่อนเส้นตารางหลัก
    chart.axes.horizontal_axis.major_grid_lines_format.line.fill_format.fill_type = slides.FillType.NO_FILL

    #for i in range(len(chart.chart_data.series)):
    #    chart.chart_data.series.remove_at(i)

    series = chart.chart_data.series[0]

    series.marker.symbol = charts.MarkerStyleType.CIRCLE
    series.labels.default_data_label_format.show_value = True
    series.labels.default_data_label_format.position = charts.LegendDataLabelPosition.TOP
    series.marker.size = 15

    # ตั้งค่าสีเส้นชุดข้อมูล
    series.format.line.fill_format.fill_type = slides.FillType.SOLID
    series.format.line.fill_format.solid_fill_color.color = draw.Color.purple
    series.format.line.dash_style = slides.LineDashStyle.SOLID

    pres.save("HideInformationFromChart.pptx", slides.export.SaveFormat.PPTX)
```

## **คำถามที่พบบ่อย**

**ไฟล์ Excel ภายนอกสามารถทำหน้าที่เป็นแหล่งข้อมูลได้หรือไม่ และสิ่งนั้นส่งผลต่อการคำนวณใหม่อย่างไร?**

ใช่ แผนภูมิสามารถอ้างอิงไฟล์ทำงานภายนอกได้: เมื่อคุณเชื่อมต่อหรือรีเฟรชแหล่งภายนอก สูตรและค่าจะถูกนำมาจากไฟล์นั้น และแผนภูมิจะแสดงการอัปเดตระหว่างการเปิดหรือแก้ไข API ให้คุณ [specify the external workbook](https://reference.aspose.com/slides/th/python-net/aspose.slides.charts/chartdata/set_external_workbook/) เส้นทางและจัดการข้อมูลที่เชื่อมโยง

**ฉันสามารถคำนวณและแสดงเส้นแนวโน้มโดยไม่ต้องทำการถดถอยด้วยตนเองได้หรือไม่?**

ใช่ [Trendlines](/slides/th/python-net/trend-line/) (เชิงเส้น, เอ็กซ์โพเนนเชียล, และอื่น ๆ) จะถูกเพิ่มและอัปเดตโดย Aspose.Slides พารามิเตอร์ของพวกมันจะถูกคำนวณใหม่จากข้อมูลชุดอัตโนมัติ ดังนั้นคุณไม่จำเป็นต้องทำการคำนวณด้วยตนเอง

**หากงานนำเสนอมีแผนภูมิมากกว่าหนึ่งแผนพร้อมลิงก์ภายนอก ฉันสามารถควบคุมว่าไฟล์ทำงานใดจะถูกใช้โดยแต่ละแผนภูมิสำหรับค่าที่คำนวณได้หรือไม่?**

ใช่ แผนภูมิแต่ละอันสามารถชี้ไปยัง [external workbook](https://reference.aspose.com/slides/th/python-net/aspose.slides.charts/chartdata/set_external_workbook/) ของตนเองได้ หรือคุณสามารถสร้าง/แทนที่ไฟล์ทำงานภายนอกต่อแผนภูมิได้อย่างอิสระจากแผนภูมิต่าง ๆ