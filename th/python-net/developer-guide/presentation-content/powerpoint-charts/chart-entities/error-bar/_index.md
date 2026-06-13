---
title: ปรับแต่งแท่งความผิดพลาดในแผนภูมิกาารนำเสนอด้วย Python
linktitle: แท่งความผิดพลาด
type: docs
url: /th/python-net/error-bar/
keywords:
- แท่งความผิดพลาด
- ค่ากำหนดเอง
- PowerPoint
- OpenDocument
- การนำเสนอ
- Python
- Aspose.Slides
description: "เรียนรู้วิธีเพิ่มและปรับแต่งแท่งความผิดพลาดในแผนภูมิด้วย Aspose.Slides for Python via .NET—เพิ่มประสิทธิภาพการแสดงผลข้อมูลในงานนำเสนอ PowerPoint และ OpenDocument"
---
## **ภาพรวม**

บทความนี้อธิบายวิธีทำงานกับแท่งความผิดพลาดในแผนภูมิการนำเสนอโดยใช้ Aspose.Slides. มันแสดงวิธีเพิ่มแท่งความผิดพลาดให้กับชุดข้อมูลแผนภูมิ, กำหนดการตั้งค่า X และ Y ของแท่งความผิดพลาด, และใช้ประเภทค่าต่าง ๆ เช่น ค่าคงที่, เปอร์เซ็นต์, และค่ากำหนดเอง

นอกจากนี้ยังสาธิตวิธีกำหนดค่าตำแหน่งแท่งความผิดพลาดแบบกำหนดเองสำหรับจุดข้อมูลแต่ละจุดในชุดข้อมูลโดยใช้คอลเลกชันจุดข้อมูลที่สอดคล้อง

เพิ่มเติม บทความรวมบันทึกสั้น ๆ เกี่ยวกับการทำงานของแท่งความผิดพลาดระหว่างการส่งออก, ความเข้ากันได้กับมาร์คเกอร์และป้ายข้อมูล, และตำแหน่งที่สามารถค้นหารายการคลาสและ enum ของ API ที่เกี่ยวข้องได้

## **เพิ่มแท่งความผิดพลาด**
Aspose.Slides for Python via .NET มี API อย่างง่ายสำหรับจัดการค่าของแท่งความผิดพลาด ตัวอย่างโค้ดใช้เมื่อต้องการประเภทค่ากำหนดเอง เพื่อระบุค่าให้ใช้คุณสมบัติ **ErrorBarCustomValues** ของจุดข้อมูลเฉพาะในคอลเลกชัน **DataPoints** ของซีรีส์:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/)
2. เพิ่มแผนภูมิบับเบิลบนสไลด์ที่ต้องการ
3. เข้าถึงซีรีส์แผนภูมียลแรกและตั้งค่ารูปแบบแท่งความผิดพลาด X
4. เข้าถึงซีรีส์แผนภูมียลแรกและตั้งค่ารูปแบบแท่งความผิดพลาด Y
5. ตั้งค่าค่าและรูปแบบของแท่ง
6. บันทึกการนำเสนอที่แก้ไขเป็นไฟล์ PPTX

```py
import aspose.slides.charts as charts
import aspose.slides as slides

# สร้างงานนำเสนอเปล่า
with slides.Presentation() as presentation:
    # สร้างแผนภูมิบับเบิล
    chart = presentation.slides[0].shapes.add_chart(charts.ChartType.BUBBLE, 50, 50, 400, 300, True)

    # เพิ่มแท่งความผิดพลาดและตั้งค่ารูปแบบของมัน
    errBarX = chart.chart_data.series[0].error_bars_x_format
    errBarY = chart.chart_data.series[0].error_bars_y_format
    errBarX.is_visible = True
    errBarY.is_visible = True
    errBarX.value_type = charts.ErrorBarValueType.FIXED
    errBarX.value = 0.1
    errBarY.value_type = charts.ErrorBarValueType.PERCENTAGE
    errBarY.value = 5
    errBarX.type = charts.ErrorBarType.PLUS
    errBarY.format.line.width = 2
    errBarX.has_end_cap = True

    # บันทึกงานนำเสนอ
    presentation.save("ErrorBars_out.pptx", slides.export.SaveFormat.PPTX)
```

## **เพิ่มค่าตำแหน่งแท่งความผิดพลาดแบบกำหนดเอง**
Aspose.Slides for Python via .NET มี API อย่างง่ายสำหรับจัดการค่าตำแหน่งแท่งความผิดพลาดแบบกำหนดเอง ตัวอย่างโค้ดใช้เมื่อคุณสมบัติ **IErrorBarsFormat.ValueType** เท่ากับ **Custom** เพื่อระบุค่าให้ใช้คุณสมบัติ **ErrorBarCustomValues** ของจุดข้อมูลเฉพาะในคอลเลกชัน **DataPoints** ของซีรีส์:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/)
2. เพิ่มแผนภูมิบับเบิลบนสไลด์ที่ต้องการ
3. เข้าถึงซีรีส์แผนภูมียลแรกและตั้งค่ารูปแบบแท่งความผิดพลาด X
4. เข้าถึงซีรีส์แผนภูมียลแรกและตั้งค่ารูปแบบแท่งความผิดพลาด Y
5. เข้าถึงจุดข้อมูลแต่ละจุดของซีรีส์แผนภูมิและตั้งค่า Error Bar สำหรับจุดข้อมูลแต่ละจุดของซีรีส์
6. ตั้งค่าค่าและรูปแบบของแท่ง
7. บันทึกการนำเสนอที่แก้ไขเป็นไฟล์ PPTX

```py
import aspose.slides.charts as charts
import aspose.slides as slides

# สร้างงานนำเสนอเปล่า
with slides.Presentation() as presentation:
    # สร้างแผนภูมิบับเบิล
    chart = presentation.slides[0].shapes.add_chart(charts.ChartType.BUBBLE, 50, 50, 400, 300, True)

    # เพิ่มแท่งความผิดพลาดแบบกำหนดเองและตั้งค่ารูปแบบของมัน
    series = chart.chart_data.series[0]
    errBarX = series.error_bars_x_format
    errBarY = series.error_bars_y_format
    errBarX.is_visible = True
    errBarY.is_visible = True
    errBarX.value_type = charts.ErrorBarValueType.CUSTOM
    errBarY.value_type = charts.ErrorBarValueType.CUSTOM

    # เข้าถึงจุดข้อมูลของซีรีส์แผนภูมิและตั้งค่าค่าแท่งความผิดพลาดสำหรับจุดแต่ละจุด
    points = series.data_points
    points.data_source_type_for_error_bars_custom_values.data_source_type_for_x_plus_values = charts.DataSourceType.DOUBLE_LITERALS
    points.data_source_type_for_error_bars_custom_values.data_source_type_for_x_minus_values = charts.DataSourceType.DOUBLE_LITERALS
    points.data_source_type_for_error_bars_custom_values.data_source_type_for_y_plus_values = charts.DataSourceType.DOUBLE_LITERALS
    points.data_source_type_for_error_bars_custom_values.data_source_type_for_y_minus_values = charts.DataSourceType.DOUBLE_LITERALS

    # ตั้งค่าแท่งความผิดพลาดสำหรับจุดของซีรีส์แผนภูมิ
    for i in range(len(points)):
        points[i].error_bars_custom_values.x_minus.as_literal_double = i + 1
        points[i].error_bars_custom_values.x_plus.as_literal_double = i + 1
        points[i].error_bars_custom_values.y_minus.as_literal_double = i + 1
        points[i].error_bars_custom_values.y_plus.as_literal_double = i + 1

    # บันทึกงานนำเสนอ
    presentation.save("ErrorBarsCustomValues_out.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**อะไรจะเกิดขึ้นกับแท่งความผิดพลาดเมื่อส่งออกการนำเสนอเป็น PDF หรือรูปภาพ?**

แท่งความผิดพลาดจะถูกเรนเดอร์เป็นส่วนหนึ่งของแผนภูมิและจะถูกเก็บไว้ระหว่างการแปลงพร้อมกับการจัดรูปแบบแผนภูมิส่วนอื่น ๆ หากใช้เวอร์ชันหรือเรนเดอร์ที่เข้ากันได้

**แท่งความผิดพลาดสามารถผสานกับมาร์คเกอร์และป้ายข้อมูลได้หรือไม่?**

ได้ แท่งความผิดพลาดเป็นองค์ประกอบแยกจากกันและเข้ากันได้กับมาร์คเกอร์และป้ายข้อมูล; หากองค์ประกอบทับกันอาจต้องปรับการจัดรูปแบบ

**ฉันจะค้นหารายการคุณสมบัติและ enum สำหรับทำงานกับแท่งความผิดพลาดใน API ได้ที่ไหน?**

ในอ้างอิง API: คลาส [ErrorBarsFormat](https://reference.aspose.com/slides/th/python-net/aspose.slides.charts/errorbarsformat/) และ enum ที่เกี่ยวข้อง [ErrorBarType](https://reference.aspose.com/slides/th/python-net/aspose.slides.charts/errorbartype/) และ [ErrorBarValueType](https://reference.aspose.com/slides/th/python-net/aspose.slides.charts/errorbarvaluetype/)