---
title: "ปรับแต่งแถบความคลาดเคลื่อนในแผนภูมิการนำเสนอโดยใช้ Python"
linktitle: "แถบความคลาดเคลื่อน"
type: docs
url: /th/python-java/error-bar/
keywords:
- แถบความคลาดเคลื่อน
- ค่าที่กำหนดเอง
- PowerPoint
- การนำเสนอ
- Python
- Java
- Aspose.Slides
description: "เรียนรู้วิธีเพิ่มและปรับแต่งแถบความคลาดเคลื่อนในแผนภูมิด้วย Aspose.Slides สำหรับ Python ผ่าน Java — ปรับให้ภาพข้อมูลในงานนำเสนอ PowerPoint มีประสิทธิภาพมากขึ้น"
---
## **ภาพรวม**

บทความนี้อธิบายวิธีการทำงานกับแถบความคลาดเคลื่อนในแผนภูมิการนำเสนอโดยใช้ Aspose.Slides โดยจะแสดงวิธีการเพิ่มแถบความคลาดเคลื่อนให้กับชุดข้อมูลของแผนภูมิ ตั้งค่าการแสดงแถบความคลาดเคลื่อนแบบ X และ Y และใช้ประเภทค่าที่แตกต่างกัน เช่น ค่าคงที่ ค่าร้อยละ และค่าที่กำหนดเอง

บทความยังสาธิตวิธีการกำหนดค่าตำแหน่งแถบความคลาดเคลื่อนแบบกำหนดเองสำหรับจุดข้อมูลแต่ละจุดในชุดข้อมูลโดยใช้คอลเลกชันของจุดข้อมูลที่สอดคล้องกัน นอกจากนี้ ยังมีบันทึกสั้นๆ เกี่ยวกับการทำงานของแถบความคลาดเคลื่อนระหว่างการส่งออก ความเข้ากันได้กับมาร์กเกอร์และป้ายข้อมูล และตำแหน่งที่สามารถค้นหาชั้นและ enum ที่เกี่ยวข้องในเอกสารอ้างอิง API

## **เพิ่มแถบความคลาดเคลื่อน**

Aspose.Slides for Python via Java มี API ที่ง่ายสำหรับการจัดการค่าของแถบความคลาดเคลื่อน ตัวอย่างโค้ดต่อไปนี้ใช้ประเภทค่าแบบคงที่และแบบร้อยละ

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentation/)
2. เพิ่มแผนภูมิบับเบิ้ลลงในสไลด์ที่ต้องการ
3. เข้าถึงชุดข้อมูลแผนภูมืแรกและตั้งค่ารูปแบบแถบความคลาดเคลื่อน X
4. เข้าถึงชุดข้อมูลแผนภูมืแรกและตั้งค่ารูปแบบแถบความคลาดเคลื่อน Y
5. ตั้งค่าค่าและการจัดรูปแบบของแถบความคลาดเคลื่อน
6. บันทึกการนำเสนอที่แก้ไขเป็นไฟล์ PPTX

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, DataSourceType, ErrorBarType, ErrorBarValueType, Presentation, SaveFormat

# สร้างอินสแตนซ์ของคลาส Presentation.
presentation = Presentation()
try:
    # สร้างแผนภูมิบับเบิ้ล.
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Bubble, 50, 50, 400, 300, True)

    # เพิ่มแถบความคลาดเคลื่อนและตั้งค่าการจัดรูปแบบของมัน.
    series = chart.getChartData().getSeries().get_Item(0)
    error_bar_x = series.getErrorBarsXFormat()
    error_bar_y = series.getErrorBarsYFormat()

    error_bar_x.setVisible(True)
    error_bar_y.setVisible(True)
    error_bar_x.setValueType(ErrorBarValueType.Fixed)
    error_bar_x.setValue(0.1)
    error_bar_y.setValueType(ErrorBarValueType.Percentage)
    error_bar_y.setValue(5)
    error_bar_x.setType(ErrorBarType.Plus)
    error_bar_y.getFormat().getLine().setWidth(2.0)
    error_bar_x.setEndCap(True)

    # บันทึกการนำเสนอ.
    presentation.save("ErrorBars.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **เพิ่มค่าแถบความคลาดเคลื่อนแบบกำหนดเอง**

Aspose.Slides for Python via Java มี API ที่ง่ายสำหรับการจัดการค่าของแถบความคลาดเคลื่อนแบบกำหนดเอง ตัวอย่างโค้ดต่อไปนี้ใช้เมื่อ [getValueType](https://reference.aspose.com/slides/th/python-java/aspose.slides/errorbarsformat/#getValueType) คืนค่าเป็น [ErrorBarValueType.Custom](https://reference.aspose.com/slides/th/python-java/aspose.slides/errorbarvaluetype/#Custom) เพื่อระบุค่า ให้ใช้ [getErrorBarsCustomValues](https://reference.aspose.com/slides/th/python-java/aspose.slides/chartdatapoint/#getErrorBarsCustomValues) สำหรับจุดข้อมูลเฉพาะในคอลเลกชันที่ได้จากเมธอดของชุดข้อมูล [getDataPoints](https://reference.aspose.com/slides/th/python-java/aspose.slides/chartseries/#getDataPoints)

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentation/)
2. เพิ่มแผนภูมิบับเบิ้ลลงในสไลด์ที่ต้องการ
3. เข้าถึงชุดข้อมูลแผนภูมืแรกและตั้งค่ารูปแบบแถบความคลาดเคลื่อน X
4. เข้าถึงชุดข้อมูลแผนภูมืแรกและตั้งค่ารูปแบบแถบความคลาดเคลื่อน Y
5. เข้าถึงจุดข้อมูลแต่ละจุดในชุดข้อมูลแผนภูมิและตั้งค่าแถบความคลาดเคลื่อนของมัน
6. ตั้งค่าค่าและการจัดรูปแบบของแถบความคลาดเคลื่อน
7. บันทึกการนำเสนอที่แก้ไขเป็นไฟล์ PPTX

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, DataSourceType, ErrorBarType, ErrorBarValueType, Presentation, SaveFormat

# สร้างอินสแตนซ์ของคลาส Presentation.
presentation = Presentation()
try:
    # สร้างแผนภูมิบับเบิ้ล.
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Bubble, 50, 50, 400, 300, True)

    # เพิ่มแถบความคลาดเคลื่อนแบบกำหนดเองและตั้งค่าการจัดรูปแบบของมัน.
    series = chart.getChartData().getSeries().get_Item(0)
    error_bar_x = series.getErrorBarsXFormat()
    error_bar_y = series.getErrorBarsYFormat()
    error_bar_x.setVisible(True)
    error_bar_y.setVisible(True)
    error_bar_x.setValueType(ErrorBarValueType.Custom)
    error_bar_y.setValueType(ErrorBarValueType.Custom)

    # เข้าถึงจุดข้อมูลของชุดแผนภูมิและกำหนดแหล่งค่าของแถบความคลาดเคลื่อน.
    points = series.getDataPoints()
    data_source = points.getDataSourceTypeForErrorBarsCustomValues()
    data_source.setDataSourceTypeForXPlusValues(jpype.JByte(DataSourceType.DoubleLiterals))
    data_source.setDataSourceTypeForXMinusValues(jpype.JByte(DataSourceType.DoubleLiterals))
    data_source.setDataSourceTypeForYPlusValues(jpype.JByte(DataSourceType.DoubleLiterals))
    data_source.setDataSourceTypeForYMinusValues(jpype.JByte(DataSourceType.DoubleLiterals))

    # ตั้งค่าค่าแถบความคลาดเคลื่อนสำหรับจุดข้อมูลของชุดแผนภูมิ.
    for i in range(points.size()):
        custom_values = points.get_Item(i).getErrorBarsCustomValues()
        custom_values.getXMinus().setAsLiteralDouble(i + 1)
        custom_values.getXPlus().setAsLiteralDouble(i + 1)
        custom_values.getYMinus().setAsLiteralDouble(i + 1)
        custom_values.getYPlus().setAsLiteralDouble(i + 1)

    # บันทึกการนำเสนอ.
    presentation.save("ErrorBarsCustomValues.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **คำถามที่พบบ่อย**

**เกิดอะไรขึ้นกับแถบความคลาดเคลื่อนเมื่อนำเสนอการส่งออกเป็น PDF หรือรูปภาพ?**

แถบความคลาดเคลื่อนจะถูกเรนเดอร์เป็นส่วนหนึ่งของแผนภูมิและจะคงอยู่ระหว่างการแปลงพร้อมกับการจัดรูปแบบของแผนภูมิโดยรวม หากใช้เวอร์ชันหรือเรนเดอร์ที่เข้ากันได้

**สามารถรวมแถบความคลาดเคลื่อนกับมาร์กเกอร์และป้ายข้อมูลได้หรือไม่?**

ได้ แถบความคลาดเคลื่อนเป็นองค์ประกอบแยกต่างหากและเข้ากันได้กับมาร์กเกอร์และป้ายข้อมูล; หากองค์ประกอบทับกันอาจจำเป็นต้องปรับการจัดรูปแบบ

**ฉันสามารถค้นหารายการคุณสมบัติและคลาสสำหรับการทำงานกับแถบความคลาดเคลื่อนใน API ได้จากที่ไหน?**

ในเอกสารอ้างอิง API: คลาส [ErrorBarsFormat](https://reference.aspose.com/slides/th/python-java/aspose.slides/errorbarsformat/) และคลาสที่เกี่ยวข้อง [ErrorBarType](https://reference.aspose.com/slides/th/python-java/aspose.slides/errorbartype/) และ [ErrorBarValueType](https://reference.aspose.com/slides/th/python-java/aspose.slides/errorbarvaluetype/)