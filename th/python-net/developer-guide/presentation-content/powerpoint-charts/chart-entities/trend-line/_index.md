---
title: เพิ่มเส้นแนวโน้มลงในแผนภูมือนำเสนอด้วย Python
linktitle: เส้นแนวโน้ม
type: docs
url: /th/python-net/trend-line/
keywords:
- แผนภูมิ
- เส้นแนวโน้ม
- เส้นแนวโน้มเอ็กซโปเนนเชียล
- เส้นแนวโน้มเชิงเส้น
- เส้นแนวโน้มลอการิทึม
- เส้นแนวโน้มค่าเฉลี่ยเคลื่อนที่
- เส้นแนวโน้มโพลิโนเมียล
- เส้นแนวโน้มพาวเวอร์
- เส้นแนวโน้มกำหนดเอง
- PowerPoint
- การนำเสนอ
- Python
- Aspose.Slides
description: "เพิ่มและปรับแต่งเส้นแนวโน้มในแผนภูมิ PowerPoint อย่างรวดเร็วด้วย Aspose.Slides for Python ผ่าน .NET — คู่มือใช้งานจริงเพื่อดึงดูดผู้ชมของคุณ."
---
## **ภาพรวม**

บทความนี้อธิบายวิธีการเพิ่มเส้นแนวโน้มลงในแผนภูมิการนำเสนอโดยใช้ Aspose.Slides แสดงวิธีสร้างแผนภูมิ, เพิ่มเส้นแนวโน้มให้กับชุดข้อมูลในแผนภูมิ, และทำงานกับประเภทเส้นแนวโน้มหลายประเภท ได้แก่ เอ็กซโปเนนเชียล, ลิเนียร์, ลอการิทึม, ค่าเฉลี่ยเคลื่อนที่, โพลิโนเมียล, และพาวเวอร์

นอกจากนี้ยังอธิบายวิธีการเพิ่มเส้นที่กำหนดเองลงในแผนภูมิโดยการแทรกรูปร่างเส้น, พร้อมส่วน FAQ สั้น ๆ เกี่ยวกับค่าโปรเจกชันของเส้นแนวโน้มแบบ forward และ backward และว่าการส่งออกเป็น PDF หรือ SVG หรือการเรนเดอร์แผนภูมิเป็นภาพจะคงรักษาเส้นแนวโน้มไว้หรือไม่

## **เพิ่มเส้นแนวโน้ม**

ใช้ [TrendlineCollection.add](https://reference.aspose.com/slides/python-net/aspose.slides.charts/trendlinecollection/add/) เพื่อเพิ่มเส้นแนวโน้มให้กับชุดข้อมูลของแผนภูมิ โดยเลือกประเภทด้วย [TrendlineType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/trendlinetype/). ตัวอย่างสร้างแผนภูมิคอลัมน์แบบคลัสเตอร์พร้อมข้อมูลเริ่มต้นและเพิ่มเส้นแนวโน้มสองเส้นให้กับแต่ละหนึ่งในสามชุดข้อมูล

เส้นแนวโน้มเอ็กซโปเนนเชียลซ่อนสมการและค่า R‑squared ผ่าน [display_equation](https://reference.aspose.com/slides/python-net/aspose.slides.charts/trendline/display_equation/) และ [display_r_squared_value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/trendline/display_r_squared_value/), ส่วนเส้นแนวโน้มลิเนียร์มีสีแดง เส้นแนวโน้มลอการิทึมใช้ [add_text_frame_for_overriding](https://reference.aspose.com/slides/python-net/aspose.slides.charts/trendline/add_text_frame_for_overriding/) เพื่อกำหนดป้ายกำกับแบบกำหนดเอง ค่าเฉลี่ยเคลื่อนที่ใช้ [period](https://reference.aspose.com/slides/python-net/aspose.slides.charts/trendline/period/) จำนวนสามจุดข้อมูลและ [trendline_name](https://reference.aspose.com/slides/python-net/aspose.slides.charts/trendline/trendline_name/) แบบกำหนดเอง

เส้นแนวโน้มโพลิโนเมียลมี [order](https://reference.aspose.com/slides/python-net/aspose.slides.charts/trendline/order/) เป็นสามและขยายหนึ่งหมวดหมู่ไปข้างหน้าผ่าน [forward](https://reference.aspose.com/slides/python-net/aspose.slides.charts/trendline/forward/). เส้นแนวโน้มพาวเวอร์ขยายหนึ่งหมวดหมู่ไปข้างหลังผ่าน [backward](https://reference.aspose.com/slides/python-net/aspose.slides.charts/trendline/backward/).

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 400)

    first_series = chart.chart_data.series[0]

    exponential_trendline = first_series.trend_lines.add(charts.TrendlineType.EXPONENTIAL)
    exponential_trendline.display_equation = False
    exponential_trendline.display_r_squared_value = False

    linear_trendline = first_series.trend_lines.add(charts.TrendlineType.LINEAR)
    linear_trendline.format.line.fill_format.fill_type = slides.FillType.SOLID
    linear_trendline.format.line.fill_format.solid_fill_color.r = 255
    linear_trendline.format.line.fill_format.solid_fill_color.g = 0
    linear_trendline.format.line.fill_format.solid_fill_color.b = 0

    second_series = chart.chart_data.series[1]

    logarithmic_trendline = second_series.trend_lines.add(charts.TrendlineType.LOGARITHMIC)
    logarithmic_trendline.add_text_frame_for_overriding("New log trend line")

    moving_average_trendline = second_series.trend_lines.add(charts.TrendlineType.MOVING_AVERAGE)
    moving_average_trendline.period = 3
    moving_average_trendline.trendline_name = "New TrendLine Name"

    third_series = chart.chart_data.series[2]

    polynomial_trendline = third_series.trend_lines.add(charts.TrendlineType.POLYNOMIAL)
    polynomial_trendline.forward = 1
    polynomial_trendline.order = 3

    power_trendline = third_series.trend_lines.add(charts.TrendlineType.POWER)
    power_trendline.backward = 1

    presentation.save("ChartTrendLines.pptx", slides.export.SaveFormat.PPTX)
```

## **กำหนดค่าจุดตัดของเส้นแนวโน้ม**

ใช้ [intercept](https://reference.aspose.com/slides/python-net/aspose.slides.charts/trendline/intercept/) เพื่อกำหนดค่าของ Y ที่ X = 0 เส้นแนวโน้ม การตั้งค่านี้รองรับเส้นแนวโน้มลิเนียร์, เอ็กซโปเนนเชียล, และโพลิโนเมียล

ตัวอย่างเช่น โมเดลต้นทุนการผลิตอาจต้องเริ่มจากค่าใช้จ่ายคงที่ที่ทราบคือ 100 แม้ว่าการวัดที่ปริมาณการผลิตไม่เป็นศูนย์จะบ่งบอกฐานพื้นฐานที่ต่างออกไป สำหรับเส้นแนวโน้มลิเนียร์ การกำหนดจุดตัดทำให้สมการ `y = ax + b` มี `b = 100`; ความชันจะถูกฟิตตามข้อมูลภายใต้เงื่อนไขนั้น ไม่ได้เพียงแค่ย้ายเส้นที่ฟิตไว้แล้ว การตั้งค่าการตัดแกนจะกำหนดตำแหน่งที่แกนของแผนภูมิเข้ากัน, ไม่ได้แก้ค่า系数ของเส้นแนวโน้มที่ฟิตแล้ว

ตัวอย่างต่อไปนี้สร้างแผนภูมิกระจายใน (XY) โดยมีปริมาณการผลิตตั้งแต่ 1 ถึง 4 และต้นทุน 170, 200, 230, และ 260 บันทึกแผนภูมิด้วยจุดตัดอัตโนมัติเริ่มต้น, ตั้งค่าจุดตัดเป็น 100, แล้วบันทึกเป็น PPTX ตัวที่สอง ไฟล์สองไฟล์แตกต่างกันเฉพาะที่การตั้งค่าจุดตัด เส้นแนวโน้มแสดงสมการและขยายกลับไปที่ X = 0

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.SCATTER_WITH_MARKERS, 20, 20, 480, 210)
    chart.has_legend = False

    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()

    workbook = chart.chart_data.chart_data_workbook
    workbook.clear(0)

    name_cell = workbook.get_cell(0, 0, 1, "Production cost")
    series = chart.chart_data.series.add(name_cell, charts.ChartType.SCATTER_WITH_MARKERS)
    costs = [170, 200, 230, 260]

    for i, cost in enumerate(costs):
        x_cell = workbook.get_cell(0, i + 1, 0, i + 1)
        y_cell = workbook.get_cell(0, i + 1, 1, cost)
        series.data_points.add_data_point_for_scatter_series(x_cell, y_cell)

    trendline = series.trend_lines.add(charts.TrendlineType.LINEAR)
    trendline.display_equation = True
    trendline.backward = 1

    presentation.save("AutomaticIntercept.pptx", slides.export.SaveFormat.PPTX)

    trendline.intercept = 100
    presentation.save("FixedIntercept.pptx", slides.export.SaveFormat.PPTX)
```

ด้วยการคำนวณอัตโนมัติ ข้อมูลเหล่านี้ให้ผลลัพธ์ `y = 30x + 140` การตั้งค่าจุดตัดเป็น 100 แทนจะให้ผลประมาณ `y = 43.33x + 100`: ค่าที่ฟิตที่ศูนย์ตรงกับฐานระดับที่ทราบ, ในขณะที่เส้นจะไม่ผ่านทุกจุดข้อมูลอีกต่อไป

| จุดตัดอัตโนมัติ | จุดตัดคงที่ 100 |
| --- | --- |
| ![เส้นแนวโน้มลิเนียร์ที่คำนวณจุดตัดอัตโนมัติ 140](intercept-automatic.png) | ![เส้นแนวโน้มลิเนียร์ที่ตั้งจุดตัดคงที่ 100](intercept-fixed.png) |

ทั้งสองภาพใช้ข้อมูลและสเกลแกนเดียวกัน เส้นแนวโน้มถูกขยายกลับไปที่ X = 0 เพื่อแสดงจุดตัดของมัน

โดยค่าเริ่มต้น คุณสมบัติมีค่า `float("nan")` ซึ่งหมายถึงจุดตัดที่ไม่ได้ระบุ ไม่ใช่ศูนย์ แล้วจุดตัดจะถูกคำนวณอัตโนมัติจากข้อมูล

## **เพิ่มเส้นที่กำหนดเอง**

เส้นที่กำหนดเองคือรูปทรงที่วาดเหนือแผนภูมิ แทนที่จะเป็นเส้นแนวโน้มที่คำนวณจากข้อมูลชุด การทำตัวอย่างนี้ใช้ [ShapeCollection.add_auto_shape](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_auto_shape/) เพื่อเพิ่มเส้นแนวนอนลงบนสไลด์เหนือแผนภูมิ ตำแหน่งของเส้นระบุด้วยพิกัดสไลด์หน่วยพอยท์ ดังนั้นมันเริ่มที่ขอบซ้ายของแผนภูมิและอยู่กึ่งกลางสูงของแผนภูมิ ความกว้างตรงกับความกว้างของแผนภูมิ [line_format](https://reference.aspose.com/slides/python-net/aspose.slides/shape/line_format/) ทำให้เส้นเป็นสีแดงทึบ

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 100, 100, 500, 400)

    line = slide.shapes.add_auto_shape(slides.ShapeType.LINE, chart.x, chart.y + chart.height / 2, chart.width, 0)
    line.line_format.fill_format.fill_type = slides.FillType.SOLID
    line.line_format.fill_format.solid_fill_color.r = 255
    line.line_format.fill_format.solid_fill_color.g = 0
    line.line_format.fill_format.solid_fill_color.b = 0

    presentation.save("AddCustomLines.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**'forward' และ 'backward' มีความหมายอย่างไรสำหรับเส้นแนวโน้ม?**

พวกมันคือความยาวของเส้นแนวโน้มที่ถูกโปรเจกต์ไปข้างหน้า/ข้างหลัง: สำหรับแผนภูมิกระจาย (XY) — ในหน่วยแกน; สำหรับแผนภูมิที่ไม่ใช่กระจาย — ในจำนวนหมวดหมู่ ค่าใด ๆ ที่เป็นลบไม่ได้รับอนุญาต

**เส้นแนวโน้มจะคงอยู่เมื่อส่งออกการนำเสนอเป็น PDF หรือ SVG หรือเมื่อเรนเดอร์สไลด์เป็นภาพหรือไม่?**

ใช่ Aspose.Slides จะเปลี่ยนการนำเสนอเป็น [PDF](/slides/th/python-net/convert-powerpoint-to-pdf/) หรือ [SVG](/slides/th/python-net/render-a-slide-as-an-svg-image/) และเรนเดอร์แผนภูมิเป็นภาพ; เส้นแนวโน้มในฐานะส่วนหนึ่งของแผนภูมิจึงถูกคงไว้ในกระบวนการเหล่านั้น อีกวิธีหนึ่งยังมีให้เพื่อ [export an image of the chart](/slides/th/python-net/create-shape-thumbnails/) เอง.