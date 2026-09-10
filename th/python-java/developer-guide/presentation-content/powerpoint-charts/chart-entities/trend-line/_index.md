---
title: เพิ่มเส้นแนวโน้มไปยังแผนภูมิการนำเสนอใน Python
linktitle: เส้นแนวโน้ม
type: docs
url: /th/python-java/trend-line/
keywords:
- แผนภูมิ
- เส้นแนวโน้ม
- เส้นแนวโน้มเอ็กซ์โพเนนเชียล
- เส้นแนวโน้มเชิงเส้น
- เส้นแนวโน้มลอกรายทิศ
- เส้นแนวโน้มค่าเฉลี่ยเคลื่อนที่
- เส้นแนวโน้มพหุคณิต
- เส้นแนวโน้มกำลัง
- เส้นแนวโน้มกำหนดเอง
- PowerPoint
- การนำเสนอ
- Python
- Java
- Aspose.Slides
description: "เพิ่มและปรับแต่งเส้นแนวโน้มในแผนภูมิ PowerPoint อย่างรวดเร็วด้วย Aspose.Slides สำหรับ Python ผ่าน Java — คู่มือเชิงปฏิบัติที่ช่วยดึงดูดผู้ชมของคุณ"
---
## **ภาพรวม**

บทความนี้อธิบายวิธีเพิ่มเส้นแนวโน้มไปยังแผนภูมิการนำเสนอโดยใช้ Aspose.Slides โดยจะแสดงวิธีสร้างแผนภูมิ, เพิ่มเส้นแนวโน้มให้กับซีรีส์ของแผนภูมิ, และทำงานกับประเภทของเส้นแนวโน้มหลายประเภท รวมถึงเอ็กซ์โพเนนเชียล, เชิงเส้น, ลอกรายทิศ, ค่าเฉลี่ยเคลื่อนที่, พหุคณิต, และกำลัง

นอกจากนี้ยังอธิบายวิธีเพิ่มเส้นกำหนดเองไปยังแผนภูมิโดยการแทรกรูปทรงเส้น และรวมคำถามที่พบบ่อยสั้น ๆ เกี่ยวกับค่าการฉายเส้นแนวโน้มไปข้างหน้าและถอยหลัง และว่าการนำออกเป็น PDF หรือ SVG หรือการเรนเดอร์แผนภูมิเป็นภาพจะคงเส้นแนวโน้มไว้หรือไม่

## **เพิ่มเส้นแนวโน้ม**

Aspose.Slides for Python via Java มี API ที่ง่ายสำหรับการจัดการเส้นแนวโน้มของแผนภูมิที่แตกต่างกัน:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentation/)
2. รับอ้างอิงไปยังสไลด์โดยใช้ดัชนีของมัน
3. เพิ่มแผนภูมิพร้อมข้อมูลเริ่มต้นและประเภทที่ต้องการ (ตัวอย่างนี้ใช้ [ChartType.ClusteredColumn](https://reference.aspose.com/slides/th/python-java/aspose.slides/charttype/#ClusteredColumn))
4. เพิ่มเส้นแนวโน้มเอ็กซ์โพเนนเชียลให้กับซีรีส์แผนภูมิที่ 1
5. เพิ่มเส้นแนวโน้มเชิงเส้นให้กับซีรีส์แผนภูมิที่ 1
6. เพิ่มเส้นแนวโน้มลอกรายทิศให้กับซีรีส์แผนภูมิที่ 2
7. เพิ่มเส้นแนวโน้มค่าเฉลี่ยเคลื่อนที่ให้กับซีรีส์แผนภูมิที่ 2
8. เพิ่มเส้นแนวโน้มพหุคณิตให้กับซีรีส์แผนภูมิที่ 3
9. เพิ่มเส้นแนวโน้มกำลังให้กับซีรีส์แผนภูมิที่ 3
10. บันทึกการนำเสนอที่แก้ไขแล้วเป็นไฟล์ PPTX

โค้ดต่อไปนี้สร้างแผนภูมิพร้อมเส้นแนวโน้ม

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, FillType, Presentation, SaveFormat, TrendlineType
from java.awt import Color

# สร้างอินสแตนซ์ของคลาส Presentation.
presentation = Presentation()
try:
    # สร้างแผนภูมิคอลัมน์แบบกลุ่ม.
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 400)

    # เพิ่มเส้นแนวโน้มเอ็กซ์โพเนนเชียลให้กับซีรีส์แผนภูมิที่ 1.
    exponential_trend_line = chart.getChartData().getSeries().get_Item(0).getTrendLines().add(TrendlineType.Exponential)
    exponential_trend_line.setDisplayEquation(False)
    exponential_trend_line.setDisplayRSquaredValue(False)

    # เพิ่มเส้นแนวโน้มเชิงเส้นให้กับซีรีส์แผนภูมิที่ 1.
    linear_trend_line = chart.getChartData().getSeries().get_Item(0).getTrendLines().add(TrendlineType.Linear)
    linear_trend_line.setTrendlineType(TrendlineType.Linear)
    linear_trend_line.getFormat().getLine().getFillFormat().setFillType(FillType.Solid)
    linear_trend_line.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.RED)

    # เพิ่มเส้นแนวโน้มลอกรายทิศให้กับซีรีส์แผนภูมิที่ 2.
    logarithmic_trend_line = chart.getChartData().getSeries().get_Item(1).getTrendLines().add(TrendlineType.Logarithmic)
    logarithmic_trend_line.setTrendlineType(TrendlineType.Logarithmic)
    logarithmic_trend_line.addTextFrameForOverriding("New log trend line")

    # เพิ่มเส้นแนวโน้มค่าเฉลี่ยเคลื่อนที่ให้กับซีรีส์แผนภูมิที่ 2.
    moving_average_trend_line = chart.getChartData().getSeries().get_Item(1).getTrendLines().add(TrendlineType.MovingAverage)
    moving_average_trend_line.setTrendlineType(TrendlineType.MovingAverage)
    moving_average_trend_line.setPeriod(jpype.JByte(3))
    moving_average_trend_line.setTrendlineName("New TrendLine Name")

    # เพิ่มเส้นแนวโน้มพหุคณิตให้กับซีรีส์แผนภูมิที่ 3.
    polynomial_trend_line = chart.getChartData().getSeries().get_Item(2).getTrendLines().add(TrendlineType.Polynomial)
    polynomial_trend_line.setTrendlineType(TrendlineType.Polynomial)
    polynomial_trend_line.setForward(1)
    polynomial_trend_line.setOrder(jpype.JByte(3))

    # เพิ่มเส้นแนวโน้มกำลังให้กับซีรีส์แผนภูมิที่ 3.
    power_trend_line = chart.getChartData().getSeries().get_Item(2).getTrendLines().add(TrendlineType.Power)
    power_trend_line.setTrendlineType(TrendlineType.Power)
    power_trend_line.setBackward(1)

    # บันทึกการนำเสนอ.
    presentation.save("ChartTrendLines_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **เพิ่มเส้นกำหนดเอง**

Aspose.Slides for Python via Java มี API ที่ง่ายสำหรับการเพิ่มเส้นกำหนดเองไปยังแผนภูมิ เพื่อเพิ่มเส้นธรรมดาไปยังแผนภูมิบนสไลด์ที่เลือก ให้ทำตามขั้นตอนต่อไปนี้:

- สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentation/)
- รับอ้างอิงไปยังสไลด์โดยใช้ดัชนีของมัน
- สร้างแผนภูมิใหม่โดยใช้เมธอด [addChart](https://reference.aspose.com/slides/th/python-java/aspose.slides/shapecollection/#addChart) ของคลาส [ShapeCollection](https://reference.aspose.com/slides/th/python-java/aspose.slides/shapecollection/)
- เพิ่มรูปทรงเส้นโดยใช้เมธอด [addAutoShape](https://reference.aspose.com/slides/th/python-java/aspose.slides/shapecollection/#addAutoShape) พร้อมกับ [ShapeType.Line](https://reference.aspose.com/slides/th/python-java/aspose.slides/shapetype/#Line)
- ตั้งค่าสีของเส้นรูปทรง
- บันทึกการนำเสนอที่แก้ไขแล้วเป็นไฟล์ PPTX

โค้ดต่อไปนี้สร้างแผนภูมิพร้อมเส้นกำหนดเอง

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, FillType, Presentation, SaveFormat, ShapeType
from java.awt import Color

# สร้างอินสแตนซ์ของคลาส Presentation.
presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 100, 100, 500, 400)
    shape = chart.getUserShapes().getShapes().addAutoShape(ShapeType.Line, 0, chart.getHeight() / 2, chart.getWidth(), 0)

    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.RED)

    presentation.save("Presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **คำถามที่พบบ่อย**

**'forward' และ 'backward' มีความหมายอย่างไรสำหรับเส้นแนวโน้ม?**

พวกมันคือความยาวของเส้นแนวโน้มที่ถูกฉายไปข้างหน้า หรือถอยหลัง: สำหรับแผนภูมิกระจาย (XY) จะวัดเป็นหน่วยของแกน; สำหรับแผนภูมิที่ไม่ใช่กระจาย จะวัดเป็นจำนวนของประเภท ค่าไม่เป็นลบเท่านั้นที่อนุญาต

**เส้นแนวโน้มจะคงอยู่เมื่อนำการนำเสนอออกเป็น PDF หรือ SVG หรือเมื่อตัวแปลงสไลด์เป็นภาพหรือไม่?**

ใช่ Aspose.Slides แปลงการนำเสนอเป็น [PDF](/slides/th/python-java/convert-powerpoint-to-pdf/)/[SVG](/slides/th/python-java/render-a-slide-as-an-svg-image/) และเรนเดอร์แผนภูมิเป็นภาพ; เส้นแนวโน้มซึ่งเป็นส่วนหนึ่งของแผนภูมิจะถูกคงไว้ในกระบวนการเหล่านี้ นอกจากนี้ยังมีเมธอดสำหรับ [ส่งออกภาพของแผนภูมิ](/slides/th/python-java/create-shape-thumbnails/) ด้วย