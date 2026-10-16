---
title: เพิ่มเส้นแนวโน้มในแผนภูมินำเสนอด้วย Python
linktitle: เส้นแนวโน้ม
type: docs
url: /th/python-java/trend-line/
keywords:
- แผนภูมิ
- เส้นแนวโน้ม
- เส้นแนวโน้มเชิงเอ็กซ์โพเนนเชียล
- เส้นแนวโน้มเชิงเส้น
- เส้นแนวโน้มเชิงลอการิทึม
- เส้นแนวโน้มค่าเฉลี่ยเคลื่อนที่
- เส้นแนวโน้มพหุนาม
- เส้นแนวโน้มพาวเวอร์
- เส้นแนวโน้มกำหนดเอง
- PowerPoint
- งานนำเสนอ
- Python
- Java
- Aspose.Slides
description: "เพิ่มและปรับแต่งเส้นแนวโน้มในแผนภูมิ PowerPoint อย่างรวดเร็วด้วย Aspose.Slides สำหรับ Python ผ่าน Java — คู่มือปฏิบัติที่ช่วยดึงดูดผู้ชมของคุณ"
---
## **ภาพรวม**

บทความนี้อธิบายวิธีการเพิ่มเส้นแนวโน้มลงในแผนภูมินำเสนอโดยใช้ Aspose.Slides โดยจะแสดงวิธีสร้างแผนภูมิ, เพิ่มเส้นแนวโน้มให้กับชุดข้อมูลของแผนภูมิ, และทำงานกับประเภทเส้นแนวโน้มต่าง ๆ ได้แก่ เชิงเอ็กซ์โพเนนเชียล, เชิงเส้น, ลอการิทึม, ค่าเฉลี่ยเคลื่อนที่, พหุนาม, และพาวเวอร์

นอกจากนี้ยังอธิบายวิธีเพิ่มเส้นแบบกำหนดเองลงในแผนภูมิโดยการแทรกรูปทรงเส้น และรวมคำถามที่พบบ่อยสั้น ๆ เกี่ยวกับค่าการฉายเส้นแนวโน้มไปข้างหน้าและถอยหลังว่าเป็นอย่างไร และเส้นแนวโน้มจะคงอยู่หรือไม่เมื่อนำเสนอไปยัง PDF หรือ SVG หรือเมื่อตัวแปลงแผนภูมิเป็นรูปภาพ

## **เพิ่มเส้นแนวโน้ม**

ใช้ [TrendlineCollection.add](https://reference.aspose.com/slides/python-java/aspose.slides/trendlinecollection/#add) เพื่อเพิ่มเส้นแนวโน้มให้กับชุดข้อมูลของแผนภูมิ โดยเลือกประเภทผ่าน [TrendlineType](https://reference.aspose.com/slides/python-java/aspose.slides/trendlinetype/). ตัวอย่างสร้างแผนภูมิเชิงคอลัมน์แบบกลุ่มโดยใช้ข้อมูลค่าเริ่มต้นและเพิ่มเส้นแนวโน้มสองเส้นให้กับแต่ละชุดข้อมูลจำนวนสามชุด

เส้นแนวโน้มเชิงเอ็กซ์โพเนนเชียลซ่อนสมการและค่า R‑squared ผ่าน [setDisplayEquation](https://reference.aspose.com/slides/python-java/aspose.slides/trendline/#setDisplayEquation) และ [setDisplayRSquaredValue](https://reference.aspose.com/slides/python-java/aspose.slides/trendline/#setDisplayRSquaredValue) ขณะที่เส้นแนวโน้มเชิงเส้นเป็นสีแดง เส้นแนวโน้มเชิงลอการิทึมใช้ [addTextFrameForOverriding](https://reference.aspose.com/slides/python-java/aspose.slides/trendline/#addTextFrameForOverriding) เพื่อกำหนดป้ายกำกับแบบกำหนดเอง ค่าเฉลี่ยเคลื่อนที่ใช้ [setPeriod](https://reference.aspose.com/slides/python-java/aspose.slides/trendline/#setPeriod) เป็นสามจุดข้อมูลและกำหนดชื่อผ่าน [setTrendlineName](https://reference.aspose.com/slides/python-java/aspose.slides/trendline/#setTrendlineName)

เส้นแนวโน้มพหุนามมีลำดับเป็นสามกำหนดโดย [setOrder](https://reference.aspose.com/slides/python-java/aspose.slides/trendline/#setOrder) และขยายหนึ่งหมวดหมู่ต่อไปข้างหน้าโดย [setForward](https://reference.aspose.com/slides/python-java/aspose.slides/trendline/#setForward) เส้นแนวโน้มพาวเวอร์ขยายหนึ่งหมวดหมู่ถอยหลังโดย [setBackward](https://reference.aspose.com/slides/python-java/aspose.slides/trendline/#setBackward)

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, FillType, Presentation, SaveFormat, TrendlineType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 400)

    first_series = chart.getChartData().getSeries().get_Item(0)

    exponential_trendline = first_series.getTrendLines().add(TrendlineType.Exponential)
    exponential_trendline.setDisplayEquation(False)
    exponential_trendline.setDisplayRSquaredValue(False)

    linear_trendline = first_series.getTrendLines().add(TrendlineType.Linear)
    linear_trendline.getFormat().getLine().getFillFormat().setFillType(FillType.Solid)
    linear_trendline.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.RED)

    second_series = chart.getChartData().getSeries().get_Item(1)

    logarithmic_trendline = second_series.getTrendLines().add(TrendlineType.Logarithmic)
    logarithmic_trendline.addTextFrameForOverriding("New log trend line")

    moving_average_trendline = second_series.getTrendLines().add(TrendlineType.MovingAverage)
    moving_average_trendline.setPeriod(jpype.JByte(3))
    moving_average_trendline.setTrendlineName("New TrendLine Name")

    third_series = chart.getChartData().getSeries().get_Item(2)

    polynomial_trendline = third_series.getTrendLines().add(TrendlineType.Polynomial)
    polynomial_trendline.setForward(1)
    polynomial_trendline.setOrder(jpype.JByte(3))

    power_trendline = third_series.getTrendLines().add(TrendlineType.Power)
    power_trendline.setBackward(1)

    presentation.save("ChartTrendLines.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **กำหนดจุดตัดแกนของเส้นแนวโน้ม**

ใช้ [setIntercept](https://reference.aspose.com/slides/python-java/aspose.slides/trendline/#setIntercept) เพื่อกำหนดค่า Y ของเส้นแนวโน้มเมื่อ X = 0 การตั้งค่านี้สนับสนุนสำหรับเส้นแนวโน้มเชิงเส้น, เชิงเอ็กซ์โพเนนเชียล, และพหุนาม

ตัวอย่างเช่น โมเดลต้นทุนการผลิตอาจต้องเริ่มต้นที่ค่าใช้จ่ายคงที่ที่ทราบไว้ 100 แม้ว่าข้อมูลที่วัดที่ปริมาณการผลิตที่ไม่เป็นศูนย์จะบ่งบอกฐานข้อมูลที่ต่างออกไป สำหรับเส้นแนวโน้มเชิงเส้น การกำหนดจุดตัดทำให้สมการ `y = ax + b` กลายเป็น `b = 100`; ความชันจะถูกฟิตตามข้อมูลภายใต้เงื่อนไขนั้น ไม่ได้เพียงแค่ย้ายเส้นที่ฟิตแล้วตั้งค่า การตั้งค่าการตัดแกนจะกำหนดตำแหน่งที่แกนของแผนภูมิกัน, ไม่ใช่ค่าสัมประสิทธิ์ของเส้นแนวโน้มที่ฟิตแล้ว

ตัวอย่างต่อไปสร้างแผนภูมิกระจาย (XY) โดยใช้ปริมาณการผลิตตั้งแต่ 1 ถึง 4 และต้นทุน 170, 200, 230, และ 260 บันทึกแผนภูมิด้วยการคำนวณจุดตัดอัตโนมัติเริ่มต้น, จากนั้นกำหนดจุดตัดเป็น 100 และบันทึกเป็นไฟล์ PPTX ที่สอง ทั้งสองไฟล์ต่างกันเฉพาะค่า การตั้งค่าจุดตัด จุดตัดเส้นแนวโน้มจะแสดงสมการและขยายกลับไปที่ X = 0

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat, TrendlineType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ScatterWithMarkers, 20, 20, 480, 210)
    chart.setLegend(False)

    chart.getChartData().getSeries().clear()
    chart.getChartData().getCategories().clear()

    workbook = chart.getChartData().getChartDataWorkbook()
    workbook.clear(0)

    name_cell = workbook.getCell(0, 0, 1, "Production cost")
    series = chart.getChartData().getSeries().add(name_cell, ChartType.ScatterWithMarkers)
    costs = [170, 200, 230, 260]

    for i in range(len(costs)):
        x_cell = workbook.getCell(0, i + 1, 0, i + 1)
        y_cell = workbook.getCell(0, i + 1, 1, costs[i])
        series.getDataPoints().addDataPointForScatterSeries(x_cell, y_cell)

    trendline = series.getTrendLines().add(TrendlineType.Linear)
    trendline.setDisplayEquation(True)
    trendline.setBackward(1)

    presentation.save("AutomaticIntercept.pptx", SaveFormat.Pptx)

    trendline.setIntercept(100)
    presentation.save("FixedIntercept.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

เมื่อคำนวณอัตโนมัติ ข้อมูลเหล่านี้ให้ผลลัพธ์ `y = 30x + 140` การตั้งค่าจุดตัดเป็น 100 แทนจะให้ผลลัพธ์ประมาณ `y = 43.33x + 100`: ค่าที่ฟิตที่ศูนย์ตรงกับฐานข้อมูลที่ทราบไว้, ในขณะที่เส้นจะไม่ผ่านทุกจุดข้อมูลอีกต่อไป

| การตัดแกนอัตโนมัติ | การตัดแกนที่ตั้งค่าเป็น 100 |
| --- | --- |
| ![เส้นแนวโน้มเชิงเส้นที่คำนวณจุดตัดอัตโนมัติเป็น 140](intercept-automatic.png) | ![เส้นแนวโน้มเชิงเส้นที่ตั้งค่าจุดตัดเป็น 100](intercept-fixed.png) |

ภาพทั้งสองใช้ข้อมูลและสเกลแกนเดียวกัน เส้นแนวโน้มถูกขยายกลับไปที่ X = 0 เพื่อแสดงจุดตัดของมัน

โดยค่าเริ่มต้น, [getIntercept](https://reference.aspose.com/slides/python-java/aspose.slides/trendline/#getIntercept) จะคืนค่า `NaN` ซึ่งหมายถึงจุดตัดที่ไม่ได้ระบุ ไม่ใช่ศูนย์ จากนั้นจุดตัดจะถูกคำนวณโดยอัตโนมัติจากข้อมูล

## **เพิ่มเส้นที่กำหนดเอง**

เส้นที่กำหนดเองเป็นรูปทรงที่วาดเหนือแผนภูมิแทนที่จะเป็นเส้นแนวโน้มที่คำนวณจากข้อมูลชุดข้อมูล ตัวอย่างนี้ใช้ [ShapeCollection.addAutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addAutoShape) เพื่อเพิ่มเส้นแนวนอนบนสไลด์เหนือแผนภูมิ ตำแหน่งของเส้นระบุด้วยพิกัดของสไลด์เป็นจุด, ดังนั้นเริ่มจากขอบซ้ายของแผนภูมิและอยู่กึ่งกลางความสูงของแผนภูมิ ความกว้างของเส้นตรงกับความกว้างของแผนภูมิ วิธี [getLineFormat](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getLineFormat) ให้เข้าถึงการจัดรูปแบบเส้นเพื่อกำหนดสีแดงทึบ

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, FillType, Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 100, 100, 500, 400)

    line = slide.getShapes().addAutoShape(ShapeType.Line, chart.getX(), chart.getY() + chart.getHeight() / 2, chart.getWidth(), 0)
    line.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    line.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.RED)

    presentation.save("AddCustomLines.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **คำถามที่พบบ่อย**

**'forward' และ 'backward' มีความหมายอย่างไรสำหรับเส้นแนวโน้ม?**

เป็นความยาวของเส้นแนวโน้มที่ฉายไปข้างหน้า/ถอยหลัง: สำหรับแผนภูมิกระจาย (XY) — หน่วยแกน; สำหรับแผนภูมิที่ไม่ใช่กระจาย — จำนวนหมวดหมู่ ค่าที่รับได้ต้องเป็นค่าที่ไม่เป็นลบเท่านั้น

**เส้นแนวโน้มจะคงอยู่หรือไม่เมื่อส่งออกงานนำเสนอเป็น PDF หรือ SVG หรือเมื่อแปลงสไลด์เป็นรูปภาพ?**

ใช่ Aspose.Slides จะแปลงงานนำเสนอเป็น [PDF](/slides/th/python-java/convert-powerpoint-to-pdf/) หรือ [SVG](/slides/th/python-java/render-a-slide-as-an-svg-image/) และเรนเดอร์แผนภูมิเป็นรูปภาพ; เส้นแนวโน้มในฐานะส่วนหนึ่งของแผนภูมิจะถูกเก็บไว้ในกระบวนการเหล่านี้ อีกทั้งยังมีเมธอดสำหรับ [export an image of the chart](/slides/th/python-java/create-shape-thumbnails/) ด้วย