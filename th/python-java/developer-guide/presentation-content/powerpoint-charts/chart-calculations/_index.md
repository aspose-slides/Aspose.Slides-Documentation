---
title: เพิ่มประสิทธิภาพการคำนวณแผนภูมิสำหรับงานนำเสนอใน Python ผ่าน Java
linktitle: การคำนวณแผนภูมิ
type: docs
weight: 50
url: /th/python-java/chart-calculations/
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
- งานนำเสนอ
- Python
- Java
- Aspose.Slides
description: "ทำความเข้าใจการคำนวณแผนภูมิ การอัปเดตข้อมูล และการควบคุมความแม่นยำใน Aspose.Slides สำหรับ Python ผ่าน Java สำหรับไฟล์ PPT และ PPTX พร้อมตัวอย่างโค้ด Python ที่ใช้งานจริง"
---
## **ภาพรวม**

Aspose.Slides มี API สำหรับทำงานกับการคำนวณแผนภูมิและข้อมูลการจัดวางในงานนำเสนอ บทความนี้แสดงวิธีการดึงค่าจริงขององค์ประกอบแผนภูมิต่าง ๆ รวมถึงตำแหน่งและขนาดที่แท้จริงขององค์ประกอบแผนภูมิและค่าจริงของแกนแผนภูมิ อีกทั้งยังอธิบายว่าค่าดังกล่าวจะถูกเติมหลังจากการตรวจสอบการจัดวางแผนภูมิ

นอกจากนี้บทความยังสาธิตวิธีการรับตำแหน่งจริงขององค์ประกอบแผนภูมิระดับพาเรนต์และวิธีการซ่อนส่วนต่าง ๆ ของแผนภูมิ เช่น ชื่อ, แกน, คำอธิบาย, และเส้นกริด ตัวอย่างเหล่านี้ช่วยให้คุณตรวจสอบข้อมูลการจัดวางแผนภูมิและควบคุมการมองเห็นขององค์ประกอบแผนภูมิใน PowerPoint อย่างเป็นโปรแกรม

## **คำนวณค่าจริงขององค์ประกอบแผนภูมิ**
Aspose.Slides for Python via Java มี API อย่างง่ายสำหรับการดึงคุณสมบัติเหล่านี้ วิธีการของคลาส [Axis](https://reference.aspose.com/slides/th/python-java/aspose.slides/axis/) ให้ข้อมูลเกี่ยวกับค่าจริงของแกนแผนภูมิ ([getActualMaxValue](https://reference.aspose.com/slides/th/python-java/aspose.slides/axis/#getActualMaxValue), [getActualMinValue](https://reference.aspose.com/slides/th/python-java/aspose.slides/axis/#getActualMinValue), [getActualMajorUnit](https://reference.aspose.com/slides/th/python-java/aspose.slides/axis/#getActualMajorUnit), [getActualMinorUnit](https://reference.aspose.com/slides/th/python-java/aspose.slides/axis/#getActualMinorUnit), [getActualMajorUnitScale](https://reference.aspose.com/slides/th/python-java/aspose.slides/axis/#getActualMajorUnitScale), [getActualMinorUnitScale](https://reference.aspose.com/slides/th/python-java/aspose.slides/axis/#getActualMinorUnitScale)). เรียกใช้เมธอด [Chart.validateChartLayout](https://reference.aspose.com/slides/th/python-java/aspose.slides/chart/#validateChartLayout) ก่อนเพื่อเติมคุณสมบัติเหล่านี้ด้วยค่าจริง

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation

presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Area, 100, 100, 500, 350)
    chart.validateChartLayout()

    max_value = chart.getAxes().getVerticalAxis().getActualMaxValue()
    min_value = chart.getAxes().getVerticalAxis().getActualMinValue()

    major_unit = chart.getAxes().getHorizontalAxis().getActualMajorUnit()
    minor_unit = chart.getAxes().getHorizontalAxis().getActualMinorUnit()
finally:
    presentation.dispose()
```

## **คำนวณตำแหน่งจริงขององค์ประกอบพาเรนต์ของแผนภูมิ**
Aspose.Slides for Python via Java มี API อย่างง่ายสำหรับการดึงคุณสมบัติเหล่านี้ วิธีการของคลาส [ChartPlotArea](https://reference.aspose.com/slides/th/python-java/aspose.slides/chartplotarea/) ให้ข้อมูลเกี่ยวกับตำแหน่งและขนาดที่แท้จริงของพื้นที่พล็อตของแผนภูมิ ([getActualX](https://reference.aspose.com/slides/th/python-java/aspose.slides/chartplotarea/#getActualX), [getActualY](https://reference.aspose.com/slides/th/python-java/aspose.slides/chartplotarea/#getActualY), [getActualWidth](https://reference.aspose.com/slides/th/python-java/aspose.slides/chartplotarea/#getActualWidth), [getActualHeight](https://reference.aspose.com/slides/th/python-java/aspose.slides/chartplotarea/#getActualHeight)). เรียกใช้เมธอด [Chart.validateChartLayout](https://reference.aspose.com/slides/th/python-java/aspose.slides/chart/#validateChartLayout) ก่อนเพื่อเติมคุณสมบัติเหล่านี้ด้วยค่าจริง

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation

presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 100, 100, 500, 350)
    chart.validateChartLayout()

    x = chart.getPlotArea().getActualX()
    y = chart.getPlotArea().getActualY()
    width = chart.getPlotArea().getActualWidth()
    height = chart.getPlotArea().getActualHeight()
finally:
    presentation.dispose()
```

## **ซ่อนองค์ประกอบแผนภูมิ**
ส่วนนี้อธิบายวิธีการซ่อนข้อมูลจากแผนภูมิ โดยใช้ Aspose.Slides for Python via Java คุณสามารถซ่อน **Title, Vertical Axis, Horizontal Axis** และ **Grid Lines** ได้ ตัวอย่างโค้ดด้านล่างแสดงวิธีการใช้คุณสมบัติเหล่านี้

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, FillType, LegendDataLabelPosition, LineDashStyle, MarkerStyleType, Presentation, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    chart = slide.getShapes().addChart(ChartType.LineWithMarkers, 140, 118, 320, 370)

    # ซ่อนชื่อแผนภูมิ.
    chart.setTitle(False)

    # ซ่อนแกนค่า.
    chart.getAxes().getVerticalAxis().setVisible(False)

    # ซ่อนแกนหมวดหมู่.
    chart.getAxes().getHorizontalAxis().setVisible(False)

    # ซ่อนคำอธิบาย.
    chart.setLegend(False)

    # ซ่อนเส้นกริดหลัก.
    chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.NoFill)

    # เก็บเฉพาะชุดข้อมูลแรก. การลบจากท้ายทำให้ดัชนีที่เหลือยังคงใช้งานได้.
    series_collection = chart.getChartData().getSeries()
    while series_collection.size() > 1:
        series_collection.removeAt(series_collection.size() - 1)

    series = series_collection.get_Item(0)

    series.getMarker().setSymbol(MarkerStyleType.Circle)
    series.getLabels().getDefaultDataLabelFormat().setShowValue(True)
    series.getLabels().getDefaultDataLabelFormat().setPosition(LegendDataLabelPosition.Top)
    series.getMarker().setSize(15)

    # ตั้งค่าสีเส้นของชุดข้อมูล.
    series.getFormat().getLine().getFillFormat().setFillType(FillType.Solid)
    series.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.MAGENTA)
    series.getFormat().getLine().setDashStyle(LineDashStyle.Solid)

    presentation.save("HideInformationFromChart.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **คำถามที่พบบ่อย**

**ไฟล์ Excel ภายนอกทำงานเป็นแหล่งข้อมูลได้หรือไม่ และมันส่งผลต่อการคำนวณใหม่อย่างไร?**

ใช่ แผนภูมิสามารถอ้างอิงไฟล์ workbook ภายนอกได้: เมื่อคุณเชื่อมต่อหรือรีเฟรชแหล่งข้อมูลภายนอก สูตรและค่าจะถูกดึงจากไฟล์ workbook นั้น และแผนภูมิจะอัปเดตตามการเปลี่ยนแปลงในระหว่างการเปิดหรือแก้ไข API ให้คุณ [specify the external workbook](https://reference.aspose.com/slides/th/python-java/aspose.slides/chartdata/#setExternalWorkbook) พาธและจัดการข้อมูลที่เชื่อมโยง

**ฉันสามารถคำนวณและแสดงเส้นแนวโน้มโดยไม่ต้องเขียนการถดถอยด้วยตนเองได้หรือไม่?**

ใช่ [Trendlines](/slides/th/python-java/trend-line/) (เชิงเส้น, เอกซ์โพเนนเชียล และอื่นๆ) ถูกเพิ่มและอัปเดตโดย Aspose.Slides; พารามิเตอร์ของมันจะถูกคำนวณใหม่จากข้อมูลซีรีส์โดยอัตโนมัติ ดังนั้นคุณไม่จำเป็นต้องเขียนการคำนวณของคุณเอง

**หากงานนำเสนอมีหลายแผนภูมิที่มีลิงก์ภายนอก ฉันสามารถควบคุมว่าแต่ละแผนภูมิใช้ workbook ใดสำหรับค่าที่คำนวณได้หรือไม่?**

ใช่ แผนภูมิแต่ละอันสามารถชี้ไปที่ [external workbook](https://reference.aspose.com/slides/th/python-java/aspose.slides/chartdata/#setExternalWorkbook) ของตนเองได้ หรือคุณสามารถสร้าง/แทนที่ไฟล์ external workbook สำหรับแต่ละแผนภูมิโดยอิสระจากแผนภูมิอื่น