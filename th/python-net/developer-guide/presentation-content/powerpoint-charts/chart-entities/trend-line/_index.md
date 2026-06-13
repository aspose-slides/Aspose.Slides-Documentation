---
title: เพิ่มเส้นเทรนด์ในแผนภูมิการนำเสนอใน Python
linktitle: เส้นเทรนด์
type: docs
url: /th/python-net/trend-line/
keywords:
- แผนภูมิ
- เส้นเทรนด์
- เส้นเทรนด์แบบเอ็กซ์โพเนนเชียล
- เส้นเทรนด์เชิงเส้น
- เส้นเทรนด์ลอการิทึม
- เส้นเทรนด์ค่าเฉลี่ยเคลื่อนที่
- เส้นเทรนด์พหุนาม
- เส้นเทรนด์แบบพาวเวอร์
- เส้นเทรนด์แบบกำหนดเอง
- PowerPoint
- OpenDocument
- การนำเสนอ
- Python
- Aspose.Slides
description: "เพิ่มและปรับแต่งเส้นเทรนด์ในแผนภูมิ PowerPoint และ OpenDocument อย่างรวดเร็วด้วย Aspose.Slides for Python via .NET — คู่มือการใช้งานและตัวอย่างโค้ดเพื่อปรับปรุงความแม่นยำของการคาดการณ์และดึงดูดผู้ชมของคุณ."
---
## **ภาพรวม**

บทความนี้อธิบายวิธีเพิ่มเส้นเทรนด์ในแผนภูมิการนำเสนอโดยใช้ Aspose.Slides แสดงวิธีสร้างแผนภูมิ, เพิ่มเส้นเทรนด์ให้กับซีรีส์ของแผนภูมิ, และทำงานกับประเภทของเส้นเทรนด์หลายประเภท รวมถึง exponential, linear, logarithmic, moving average, polynomial, และ power  

นอกจากนี้ยังอธิบายวิธีเพิ่มเส้นแบบกำหนดเองในแผนภูมิโดยการแทรกรูปทรงเส้น และรวมส่วน FAQ สั้น ๆ เกี่ยวกับค่าการฉายเส้นเทรนด์ไปข้างหน้าและถอยหลัง รวมถึงว่ามีการคงเส้นเทรนด์ไว้เมื่อส่งออกเป็น PDF หรือ SVG หรือเมื่อเรนเดอร์แผนภูมิเป็นภาพหรือไม่

## **Add Trend Line**
Aspose.Slides for Python via .NET มี API ที่ง่ายต่อการจัดการ Trend Line ของแผนภูมิต่าง ๆ:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/)  
2. รับอ้างอิงของสไลด์โดยใช้ดัชนีของมัน  
3. เพิ่มแผนภูมิพร้อมข้อมูลเริ่มต้นและเลือกประเภทที่ต้องการ (ตัวอย่างนี้ใช้ ChartType.CLUSTERED_COLUMN)  
4. เพิ่มเส้นเทรนด์แบบ exponential สำหรับซีรีส์แผนภูมิที่ 1  
5. เพิ่มเส้นเทรนด์แบบ linear สำหรับซีรีส์แผนภูมิที่ 1  
6. เพิ่มเส้นเทรนด์แบบ logarithmic สำหรับซีรีส์แผนภูมิที่ 2  
7. เพิ่มเส้นเทรนด์แบบ moving average สำหรับซีรีส์แผนภูมิที่ 2  
8. เพิ่มเส้นเทรนด์แบบ polynomial สำหรับซีรีส์แผนภูมิที่ 3  
9. เพิ่มเส้นเทรนด์แบบ power สำหรับซีรีส์แผนภูมิที่ 3  
10. บันทึกการนำเสนอที่แก้ไขแล้วเป็นไฟล์ PPTX  

โค้ดต่อไปนี้ใช้เพื่อสร้างแผนภูมิพร้อม Trend Line

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

# สร้างการนำเสนอเปล่า
with slides.Presentation() as pres:

    # สร้างแผนภูมิคอลัมน์แบบกลุ่ม
    chart = pres.slides[0].shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 400)

    # เพิ่มเส้นเทรนด์แบบเอ็กซ์โพเนนเชียลสำหรับซีรีส์แผนภูมิที่ 1
    tredLinep = chart.chart_data.series[0].trend_lines.add(charts.TrendlineType.EXPONENTIAL)
    tredLinep.display_equation = False
    tredLinep.display_r_squared_value = False

    # เพิ่มเส้นเทรนด์เชิงเส้นสำหรับซีรีส์แผนภูมิที่ 1
    tredLineLin = chart.chart_data.series[0].trend_lines.add(charts.TrendlineType.LINEAR)
    tredLineLin.trendline_type = charts.TrendlineType.LINEAR
    tredLineLin.format.line.fill_format.fill_type = slides.FillType.SOLID
    tredLineLin.format.line.fill_format.solid_fill_color.color = draw.Color.red


    # เพิ่มเส้นเทรนด์ลอการิทึมสำหรับซีรีส์แผนภูมิที่ 2
    tredLineLog = chart.chart_data.series[1].trend_lines.add(charts.TrendlineType.LOGARITHMIC)
    tredLineLog.trendline_type = charts.TrendlineType.LOGARITHMIC
    tredLineLog.add_text_frame_for_overriding("New log trend line")

    # เพิ่มเส้นเทรนด์ค่าเฉลี่ยเคลื่อนที่สำหรับซีรีส์แผนภูมิที่ 2
    tredLineMovAvg = chart.chart_data.series[1].trend_lines.add(charts.TrendlineType.MOVING_AVERAGE)
    tredLineMovAvg.trendline_type = charts.TrendlineType.MOVING_AVERAGE
    tredLineMovAvg.period = 3
    tredLineMovAvg.trendline_name = "New TrendLine Name"

    # เพิ่มเส้นเทรนด์พหุนามสำหรับซีรีส์แผนภูมิที่ 3
    tredLinePol = chart.chart_data.series[2].trend_lines.add(charts.TrendlineType.POLYNOMIAL)
    tredLinePol.trendline_type = charts.TrendlineType.POLYNOMIAL
    tredLinePol.forward = 1
    tredLinePol.order = 3

    # เพิ่มเส้นเทรนด์แบบพาวเวอร์สำหรับซีรีส์แผนภูมิที่ 3
    tredLinePower = chart.chart_data.series[1].trend_lines.add(charts.TrendlineType.POWER)
    tredLinePower.trendline_type = charts.TrendlineType.POWER
    tredLinePower.backward = 1

    # บันทึกการนำเสนอ
    pres.save("Charttrend_lines_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Add Custom Line**
Aspose.Slides for Python via .NET มี API ที่ง่ายต่อการเพิ่มเส้นแบบกำหนดเองในแผนภูมิ เพื่อเพิ่มเส้นธรรมดาแบบ plain ลงในสไลด์ที่เลือกของการนำเสนอ โปรดทำตามขั้นตอนด้านล่าง:

- สร้างอินสแตนซ์ของคลาส Presentation  
- รับอ้างอิงของสไลด์โดยใช้ Index ของมัน  
- สร้างแผนภูมิใหม่ด้วยเมธอด AddChart ที่เปิดให้ใช้จากอ็อบเจ็กต์ Shapes  
- เพิ่ม AutoShape ประเภท Line ด้วยเมธอด AddAutoShape ที่เปิดให้ใช้จากอ็อบเจ็กต์ Shapes  
- กำหนดสีของเส้นรูปทรง  
- บันทึกการนำเสนอที่แก้ไขแล้วเป็นไฟล์ PPTX  

โค้ดต่อไปนี้ใช้เพื่อสร้างแผนภูมิพร้อม Custom Lines

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    chart = pres.slides[0].shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 100, 100, 500, 400)
    shape = chart.user_shapes.shapes.add_auto_shape(slides.ShapeType.LINE, 0, chart.height / 2, chart.width, 0)
    shape.line_format.fill_format.fill_type = slides.FillType.SOLID
    shape.line_format.fill_format.solid_fill_color.color = draw.Color.red
    pres.save("AddCustomLines.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**'forward' และ 'backward' หมายถึงอะไรในเส้นเทรนด์?**  

พวกมันคือความยาวของเส้นเทรนด์ที่ฉายไปข้างหน้า/ถอยหลัง: สำหรับแผนภูมิ scatter (XY) — ในหน่วยแกน; สำหรับแผนภูมิที่ไม่ใช่ scatter — ในจำนวนของหมวดหมู่. ค่าที่รับได้ต้องเป็นค่าไม่เป็นลบเท่านั้น  

**เส้นเทรนด์จะถูกคงไว้เมื่อส่งออกการนำเสนอเป็น PDF หรือ SVG หรือเมื่อเรนเดอร์สไลด์เป็นภาพหรือไม่?**  

ใช่. Aspose.Slides แปลงการนำเสนอเป็น [PDF](/slides/th/python-net/convert-powerpoint-to-pdf/)/[SVG](/slides/th/python-net/render-a-slide-as-an-svg-image/) และเรนเดอร์แผนภูมิเป็นภาพ; เส้นเทรนด์ในฐานะส่วนหนึ่งของแผนภูมิจะถูกคงไว้ในขั้นตอนเหล่านี้. มีเมธอดเพิ่มเติมที่ใช้เพื่อ [export an image of the chart](/slides/th/python-net/create-shape-thumbnails/) ด้วย.