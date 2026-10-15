---
title: ปรับแต่งแกนแผนภูมิในงานนำเสนอด้วย Python
linktitle: แกนแผนภูมิ
type: docs
url: /th/python-java/chart-axis/
keywords:
- แกนแผนภูมิ
- แกนแนวตั้ง
- แกนแนวนอน
- ปรับแต่งแกน
- จัดการแกน
- ควบคุมแกน
- คุณสมบัติของแกน
- ค่าสูงสุด
- ค่าต่ำสุด
- เส้นแกน
- รูปแบบวันที่
- ชื่อแกน
- ตำแหน่งแกน
- PowerPoint
- งานนำเสนอ
- Python
- Aspose.Slides
description: "ค้นพบวิธีการใช้ Aspose.Slides สำหรับ Python ผ่าน Java เพื่อปรับแต่งแกนแผนภูมิในงานนำเสนอ PowerPoint สำหรับรายงานและการสร้างภาพ."
---
## **ภาพรวม**

บทความนี้อธิบายวิธีปรับแต่งแกนแผนภูมิด้วย Aspose.Slides สำหรับ Python ผ่าน Java โดยครอบคลุมค่าที่คำนวณของแกน, การสลับแถวและคอลัมน์ของแผนภูมิ, การแสดงหรือซ่อนแกน, ระยะห่างของป้ายชื่อหมวดหมู่และติ๊ก‑มาร์ก, หมวดหมู่วันที่และการจัดรูปแบบ, การหมุนชื่อแกน, การตำแหน่งแกน, หน่วยแสดงผล, และการสเกลแบบลอการิทึม

## **รับค่ามากสุดบนแกนแนวตั้งของแผนภูมิ**

สร้าง [การนำเสนอ](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) และเพิ่มแผนภูมิพื้นที่ด้วยข้อมูลค่าเริ่มต้น เรียกใช้ [validateChartLayout](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#validateChartLayout) ก่อนอ่านค่าที่คำนวณของแกนเพื่อให้เค้าโครงแผนภูมิเป็นปัจจุบัน

อ่าน [getActualMaxValue](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#getActualMaxValue) และ [getActualMinValue](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#getActualMinValue) เพื่อรับขอบเขตของแกน และอ่าน [getActualMajorUnit](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#getActualMajorUnit) และ [getActualMinorUnit](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#getActualMinorUnit) เพื่อรับช่วงระยะของติ๊ก [getActualMajorUnitScale](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#getActualMajorUnitScale) และ [getActualMinorUnitScale](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#getActualMinorUnitScale) ให้สเกลหน่วยเวลา ซึ่งเกี่ยวข้องกับแกนวันที่ ตัวอย่างจะเก็บค่าต่าง ๆ นี้ในตัวแปรท้องถิ่นและบันทึกแผนภูมิ

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ChartType, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.Area, 100, 100, 500, 350)
    chart.validateChartLayout()

    max_value = chart.getAxes().getVerticalAxis().getActualMaxValue()
    min_value = chart.getAxes().getVerticalAxis().getActualMinValue()

    major_unit = chart.getAxes().getVerticalAxis().getActualMajorUnit()
    minor_unit = chart.getAxes().getVerticalAxis().getActualMinorUnit()

    major_unit_scale = chart.getAxes().getVerticalAxis().getActualMajorUnitScale()
    minor_unit_scale = chart.getAxes().getVerticalAxis().getActualMinorUnitScale()

    presentation.save("AxisValues_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **สลับข้อมูลระหว่างแกน**

ใช้ [switchRowColumn](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#switchRowColumn) เพื่อสลับบทบาทของซีรีส์และหมวดหมู่ในข้อมูลแผนภูมิ แต่ละหมวดหมู่เดิมจะกลายเป็นซีรีส์ และแต่ละซีรีส์เดิมจะกลายเป็นหมวดหมู่ การเปลี่ยนแปลงนี้ทำให้การจัดกลุ่มข้อมูลเปลี่ยนแปลง; ไม่ได้สลับแกนแนวนอนและแนวตั้ง ตัวอย่างใช้ [setRange](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#setRange) เพื่อผูกข้อมูลค่าเริ่มต้นกับ `Sheet1!A1:D5` รวมถึงแถวหัวเรื่องและคอลัมน์หมวดหมู่ ก่อนทำการสลับแถวและคอลัมน์ จะบันทึกแผนภูมิที่มีสี่ซีรีส์และสามหมวดหมู่

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ChartType, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 100, 100, 400, 300)
    chart.getChartData().setRange("Sheet1!A1:D5")
    chart.getChartData().switchRowColumn()

    presentation.save("SwitchChartRowColumns_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **กลับลำดับการพล็อตของแกน**

ใช้ [setPlotOrderReversed](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setPlotOrderReversed) เพื่อย้อนกลับลำดับของแกนหมวดหมู่หรือค่า ตัวอย่างเช่น แผนภูมิบาร์แนวนอนสามารถแสดงขั้นตอนของโครงการจากบนลงล่างตามลำดับเดียวกับในแผ่นงาน: Planning, Development, Testing การย้อนกลับแกนจะเปลี่ยนทิศทางการพล็อต; ไม่ได้ทำการเรียงลำดับหรือจัดเรียงข้อมูลในเวิร์กบุ๊ก ในการเปรียบเทียบ [switchRowColumn](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#switchRowColumn) จะสลับบทบาทของซีรีส์และหมวดหมู่

ตัวอย่างต่อไปนี้สร้างแผนภูมิบาร์แนวนอนที่มีสามขั้นตอนและหนึ่งซีรีส์ จะบันทึกการนำเสนอที่มีสามสไลด์: ลำดับปกติ, หมวดหมู่ย้อนกลับ, และค่าย้อนกลับ แต่ละสำเนาใช้ชุดข้อมูลเดียวกัน และแต่ละสำเนาจะย้อนกลับเพียงแกนเดียว

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpipe.startJVM()

from asposeslides.api import Presentation, ChartType, CrossesType, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredBar, 50, 40, 620, 320)
    chart.setLegend(False)

    chart.getChartData().getCategories().clear()
    chart.getChartData().getSeries().clear()

    workbook = chart.getChartData().getChartDataWorkbook()
    workbook.clear(0)

    series = chart.getChartData().getSeries().add(ChartType.ClusteredBar)
    stages = ["Planning", "Development", "Testing"]
    values = [10, 30, 20]
    for i, stage in enumerate(stages):
        category_cell = workbook.getCell(0, i + 1, 0, stage)
        chart.getChartData().getCategories().add(category_cell)
        value_cell = workbook.getCell(0, i + 1, 1, float(values[i]))
        series.getDataPoints().addDataPointForBarSeries(value_cell)

    # สไลด์ 2: แสดงหมวดหมู่แรกที่ด้านบน.
    category_slide = presentation.getSlides().addClone(slide)
    category_chart = category_slide.getShapes().get_Item(0)
    category_chart.getAxes().getVerticalAxis().setPlotOrderReversed(True)
    # คงแกนค่าทางแนวนอนไว้ที่ด้านล่าง.
    category_chart.getAxes().getVerticalAxis().setCrossType(CrossesType.Maximum)

    # สไลด์ 3: ย้อนกลับเฉพาะสเกลตัวเลขแนวนอนเท่านั้น.
    value_slide = presentation.getSlides().addClone(slide)
    value_chart = value_slide.getShapes().get_Item(0)
    value_chart.getAxes().getHorizontalAxis().setPlotOrderReversed(True)

    presentation.save("ReversedAxes.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

การย้อนกลับแกนอาจทำให้แกนตั้งฉากย้ายไปด้านตรงข้ามของพล็อต [setCrossType](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setCrossType) ควบคุมตำแหน่งที่แกนอื่นตัดแกนที่กำลังตั้งค่า ในสไลด์ที่ 2 การเรียกใช้ด้วย [CrossesType.Maximum](https://reference.aspose.com/slides/python-java/aspose.slides/crossestype/#Maximum) บนแกนหมวดหมู่ที่ย้อนกลับจะทำให้แกนค่ามแนวนอนอยู่ที่ด้านล่าง สำหรับจุดตัดที่ระบุเฉพาะ ให้ใช้ [setCrossAt](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setCrossAt) ตรวจสอบการตั้งค่าตัดเมื่อเปลี่ยนทิศทาง โดยเฉพาะอย่างยิ่งหากแผนภูมิมีจุดตัดกำหนดเองแล้ว เรียก [setPlotOrderReversed](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setPlotOrderReversed) กับ `False` เพื่อคืนทิศทางการพล็อตปกติ; การตั้งค่าตัดเป็นค่าแยกจากกัน

| ลำดับปกติ (สไลด์ 1) | หมวดหมู่ย้อนกลับ (สไลด์ 2) | ค่าที่ย้อนกลับ (สไลด์ 3) |
| --- | --- | --- |
| ![แผนภูบาร์แนวนอนกับลำดับหมวดหมู่และแกนค่าปกติ](axis-order-normal.png) | ![แผนภูบาร์แนวนอนกับหมวดหมู่แสดงจากบนลงล่าง](axis-order-categories-reversed.png) | ![แผนภูบาร์แนวนอนกับแกนค่าที่ย้อนกลับและศูนย์ที่ด้านขวา](axis-order-values-reversed.png) |
| หมวดหมู่เรียงจากล่างขึ้นบน; ค่าจะเพิ่มจากซ้ายไปขวา. | Planning, Development, และ Testing เรียงจากบนลงล่าง ค่และลำดับแถวในเวิร์กบุ๊กยังคงไม่เปลี่ยน. | หมวดหมู่คงลำดับปกติ; ค่าจะเพิ่มจากขวาไปซ้าย แกนหมวดหมู่ตัดที่ศูนย์ด้านขวา. |

## **ปิดการแสดงแกนแนวตั้งสำหรับแผนภูมิเส้น**

เรียกใช้ [setVisible](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setVisible) กับ `False` บนแกนแนวตั้งเพื่อซ่อนมัน ตัวอย่างสร้างแผนภูมิเส้นด้วยข้อมูลค่าเริ่มต้นและบันทึกโดยที่แกนแนวตั้งถูกซ่อน

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ChartType, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.Line, 100, 100, 400, 300)
    chart.getAxes().getVerticalAxis().setVisible(False)

    presentation.save("HiddenVerticalAxis.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **ปิดการแสดงแกนแนวนอนสำหรับแผนภูมิเส้น**

เรียกใช้ [setVisible](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setVisible) กับ `False` บนแกนแนวนอนเพื่อซ่อนมัน ตัวอย่างสร้างแผนภูมิเส้นด้วยข้อมูลค่าเริ่มต้นและบันทึกโดยที่แกนแนวนอนถูกซ่อน

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ChartType, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.Line, 100, 100, 400, 300)
    chart.getAxes().getHorizontalAxis().setVisible(False)

    presentation.save("HiddenHorizontalAxis.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **เปลี่ยนแกนหมวดหมู่**

ใช้ [setCategoryAxisType](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setCategoryAxisType) เพื่อเลือกแกนหมวดหมู่แบบวันที่หรือข้อความ ตัวอย่างนี้ต้องใช้ไฟล์ `ExistingChart.pptx` โดยที่แผนภูมิเป็นรูปร่างแรกบนสไลด์แรกและเซลล์หมวดหมู่มีค่าตัวเลขวันที่ของ Excel จะเปลี่ยนแกนแนวนอนเป็นแกนวันที่ การเรียก [setAutomaticMajorUnit](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setAutomaticMajorUnit) กับ `False`, [setMajorUnit](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setMajorUnit) กับ `1`, และ [setMajorUnitScale](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setMajorUnitScale) กับ [TimeUnitType.Months](https://reference.aspose.com/slides/python-java/aspose.slides/timeunittype/#Months) จะตั้งติ๊กหลักให้เป็นช่วงหนึ่งเดือน

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, CategoryAxisType, TimeUnitType

presentation = Presentation("ExistingChart.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().get_Item(0)
    chart.getAxes().getHorizontalAxis().setCategoryAxisType(CategoryAxisType.Date)
    chart.getAxes().getHorizontalAxis().setAutomaticMajorUnit(False)
    chart.getAxes().getHorizontalAxis().setMajorUnit(1)
    chart.getAxes().getHorizontalAxis().setMajorUnitScale(TimeUnitType.Months)

    presentation.save("ChangeChartCategoryAxis_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **ควบคุมช่วงป้ายชื่อแกนหมวดหมู่**

เมื่อแผนภูมิมีหลายหมวดหมู่ ให้ลดจำนวนป้ายชื่อแกนที่มองเห็นได้โดยไม่ลบหมวดหมู่หรือจุดข้อมูล เรียก [setAutomaticTickLabelSpacing](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setAutomaticTickLabelSpacing) กับ `False` แล้วส่งช่วงหมวดหมู่ที่ต้องการไปยัง [setTickLabelSpacing](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setTickLabelSpacing) สำหรับหมวดหมู่ข้อความในลำดับปกติ การนับเริ่มจากหมวดหมู่แรก:

| ช่วง | ป้ายชื่อที่แสดงในตัวอย่าง |
| --- | --- |
| `1` | หมวดหมู่ 1, หมวดหมู่ 2, หมวดหมู่ 3, ... หมวดหมู่ 24 |
| `2` | หมวดหมู่ 1, หมวดหมู่ 3, หมวดหมู่ 5, ... หมวดหมู่ 23 |
| `3` | หมวดหมู่ 1, หมวดหมู่ 4, หมวดหมู่ 7, ... หมวดหมู่ 22 |

ช่วง `3` จะแสดงทุกป้ายที่สาม โดยซ่อนสองป้ายระหว่างที่แสดง ไม่ได้ลบคอลัมน์ที่สอดคล้องกัน การเว้นช่วงอัตโนมัติจะเลือกช่วงตามพื้นที่ที่มีอยู่; ไม่ได้จำเป็นต้องแสดงทุกป้าย

ติ๊ก‑มาร์กมีการควบคุมแยกต่างหาก เรียก [setAutomaticTickMarksSpacing](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setAutomaticTickMarksSpacing) กับ `False` และใช้ [setTickMarksSpacing](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setTickMarksSpacing) เพื่อกำหนดช่วงของมัน ตัวอย่างเช่น `1` จะคงติ๊ก‑มาร์กที่ทุกช่วงหมวดหมู่ในขณะที่ป้ายชื่อปรากฏเฉพาะทุกหมวดหมู่ที่สาม ใช้ [setMajorTickMark](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setMajorTickMark) กับสไตล์ที่มองเห็นได้เพื่อให้เห็นผล หากเรียกตัวตั้งค่าเว้นช่วงอัตโนมัติกับ `True` อีกครั้ง แผนภูมิจะเลือกช่วงนั้นใหม่

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ChartType, SaveFormat, CategoryAxisType, TickMarkType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 30, 40, 660, 320)

    chart.setLegend(False)
    chart.getChartData().getCategories().clear()
    chart.getChartData().getSeries().clear()

    workbook = chart.getChartData().getChartDataWorkbook()
    workbook.clear(0)

    series = chart.getChartData().getSeries().add(ChartType.ClusteredColumn)
    for i in range(24):
        category_cell = workbook.getCell(0, i + 1, 0, f"Category {i + 1}")
        chart.getChartData().getCategories().add(category_cell)
        value_cell = workbook.getCell(0, i + 1, 1, float(10 + i % 6 * 5))
        series.getDataPoints().addDataPointForBarSeries(value_cell)

    axis = chart.getAxes().getHorizontalAxis()
    axis.setCategoryAxisType(CategoryAxisType.Text)
    axis.getTextFormat().getTextBlockFormat().setRotationAngle(0)
    axis.getTextFormat().getPortionFormat().setFontHeight(12)
    axis.setMajorTickMark(TickMarkType.Outside)
    axis.setAutomaticTickLabelSpacing(True)
    axis.setAutomaticTickMarksSpacing(True)

    # สไลด์ 2: แสดงป้ายทุกสามรายการ แต่คงติ๊ก‑มาร์กสำหรับทุกหมวดหมู่.
    manual_slide = presentation.getSlides().addClone(slide)
    manual_chart = manual_slide.getShapes().get_Item(0)
    manual_axis = manual_chart.getAxes().getHorizontalAxis()
    manual_axis.setAutomaticTickLabelSpacing(False)
    manual_axis.setTickLabelSpacing(3)
    manual_axis.setAutomaticTickMarksSpacing(False)
    manual_axis.setTickMarksSpacing(1)

    # สไลด์ 3: ให้แผนภูมิเลือกช่วงทั้งสองอย่างใหม่.
    restored_slide = presentation.getSlides().addClone(manual_slide)
    restored_chart = restored_slide.getShapes().get_Item(0)
    restored_chart.getAxes().getHorizontalAxis().setAutomaticTickLabelSpacing(True)
    restored_chart.getAxes().getHorizontalAxis().setAutomaticTickMarksSpacing(True)

    presentation.save("CategoryAxisIntervals.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

**การเว้นช่วงอัตโนมัติ (สไลด์ 1):** ในการแสดงผลนี้ ป้ายชื่อหมวดหมู่ทุกๆ สองรายการจะแสดงและขึ้นบรรทัดใหม่ ผลลัพธ์อัตโนมัติอาจแตกต่างตามขนาดแผนภูมิ, แบบอักษร, และเครื่องมือเรนเดอร์

![การเว้นช่วงป้ายชื่อหมวดหมู่อัตโนมัติพร้อมคอลัมน์ทั้งหมด 24 คอลัมน์แสดง](category-axis-automatic.png)

**การเว้นช่วงด้วยตนเอง (สไลด์ 2):** ป้ายชื่อทุกสามรายการจะแสดงในหนึ่งบรรทัด ในขณะที่ติ๊ก‑มาร์กยังคงอยู่ที่ทุกช่วงหมวดหมู่ คอลัมน์ทั้งหมด 24 คอลัมน์รวมถึงที่ไม่มีป้ายชื่อยังคงแสดงพร้อมค่าที่เหมือนกัน สไลด์ 3 จะคืนสภาพการแสดงอัตโนมัติที่แสดงข้างต้น

![ช่วงป้ายชื่อหมวดหมู่แบบมือด้วยสามรายการ พร้อมคอลัมน์ทั้งหมด 24 คอลัมน์แสดง](category-axis-manual.png)

### **เลือกแกนและช่วงที่ถูกต้อง**

ใช้ช่วงจำนวนหมวดหมู่นี้สำหรับแกนหมวดหมู่แบบข้อความ เช่น แกนหมวดหมู่ของแผนภูมิคอลัมน์, เส้น, พื้นที่ หรือบาร์ ในแผนภูมิคอลัมน์เป็นแกนแนวนอน ในแผนภูมิบาร์แนวนอนแกนหมวดหมู่เป็นแนวตั้ง ดังนั้นให้ใช้การตั้งค่านี้กับแกนที่ได้จาก [getVerticalAxis](https://reference.aspose.com/slides/python-java/aspose.slides/axesmanager/#getVerticalAxis) การเว้นช่วงติ๊ก‑มาร์กยังใช้ได้กับแกนซีรีส์ในแผนภูมิที่มี

ห้ามใช้การเว้นช่วงป้ายชื่อหมวดหมู่เพื่อกำหนดสเกลเชิงตัวเลขของแกนค่า บนแกนค่า, [setMajorUnit](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setMajorUnit) ระบุความแตกต่างของค่า: ตัวอย่างเช่น หน่วยหลัก `10` จะสร้างติ๊กที่ 0, 10, 20 ฯลฯ เมื่อแกนเริ่มจากศูนย์ ช่วงป้ายชื่อหมวดหมู่ `3` จะนับตำแหน่งหมวดหมู่โดยไม่คำนึงถึงค่าข้อมูล แผนภูมิกระจายและฟองใช้แกนค่าแทนแกนหมวดหมู่แบบข้อความ สำหรับแกนวันที่ ให้ใช้หน่วยหลักและสเกลตามเวลา [เปลี่ยนแกนหมวดหมู่](#change-a-category-axis)

## **ตั้งรูปแบบวันที่สำหรับค่าของแกนหมวดหมู่**

ตัวอย่างนี้แทนที่ข้อมูลแผนภูมิปริยายด้วยค่าปีละสี่ค่า วันที่ถูกเก็บเป็นหมายเลขซีเรียล OLE Automation ในแผ่นงานแรก (ดัชนี `0`) ซึ่งคำนวณเป็นจำนวนวันตั้งแต่ 30 ธันวาคม 1899 สำหรับวันที่เหล่านั้น ใช้ [setCategoryAxisType](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setCategoryAxisType) กับ [CategoryAxisType.Date](https://reference.aspose.com/slides/python-java/aspose.slides/categoryaxistype/#Date), เรียก [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setNumberFormatLinkedToSource) กับ `False`, และส่ง `yyyy` ไปยัง [setNumberFormat](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setNumberFormat) เพื่อให้ป้ายชื่อหมวดหมู่แสดงปีสี่หลักโดยอิสระจากการจัดรูปแบบของเซลล์

```python
from datetime import date

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ChartType, SaveFormat, CategoryAxisType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.Line, 50, 50, 450, 300)

    chart.getChartData().getCategories().clear()
    chart.getChartData().getSeries().clear()

    workbook = chart.getChartData().getChartDataWorkbook()
    workbook.clear(0)

    base_date = date(1899, 12, 30)

    series = chart.getChartData().getSeries().add(ChartType.Line)
    for i in range(4):
        category_date = date(2015 + i, 1, 1)
        category_value = float((category_date - base_date).days)
        category_cell = workbook.getCell(0, i + 1, 0, category_value)
        chart.getChartData().getCategories().add(category_cell)

        value_cell = workbook.getCell(0, i + 1, 1, float(i + 1))
        series.getDataPoints().addDataPointForLineSeries(value_cell)

    chart.getAxes().getHorizontalAxis().setCategoryAxisType(CategoryAxisType.Date)
    chart.getAxes().getHorizontalAxis().setNumberFormatLinkedToSource(False)
    chart.getAxes().getHorizontalAxis().setNumberFormat("yyyy")

    presentation.save("DateAxisFormat.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **ตั้งค่ามุมการหมุนสำหรับชื่อแกนแผนภูมิ**

เรียกใช้ [setTitle](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setTitle) กับ `True` บนแกนแนวตั้ง, ให้ข้อความชื่อแกน, และตั้งค่ามุมหมุนในการจัดรูปแบบบล็อกข้อความของชื่อมุมจะวัดด้วยหน่วยองศา ตัวอย่างนี้บันทึกแผนภูมิคอลัมน์ที่ชื่อแกนค่าถูกหมุน 90 องศา

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ChartType, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 450, 300)
    chart.getAxes().getVerticalAxis().setTitle(True)
    chart.getAxes().getVerticalAxis().getTitle().addTextFrameForOverriding("Value")
    chart.getAxes().getVerticalAxis().getTitle().getTextFormat().getTextBlockFormat().setRotationAngle(90)

    presentation.save("RotatedAxisTitle.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **ตั้งตำแหน่งแกนบนแกนหมวดหมู่หรือค่า**

ใช้ [setAxisBetweenCategories](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setAxisBetweenCategories) เพื่อควบคุมว่าแกนค่าตัดแกนหมวดหมู่ระหว่างหมวดหมู่หรือที่ติ๊ก‑มาร์กของหมวดหมู่ การตั้งค่านี้ใช้กับแกนหมวดหมู่ ตัวอย่างตั้งค่าเป็น `True` บนแกนหมวดหมู่แนวนอนของแผนภูมิคอลัมน์และบันทึกผลลัพธ์

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ChartType, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 450, 300)
    chart.getAxes().getHorizontalAxis().setAxisBetweenCategories(True)

    presentation.save("AxisBetweenCategories.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **ตั้งหน่วยแสดงผลบนแกนค่าของแผนภูมิ**

ใช้ [setDisplayUnit](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setDisplayUnit) เพื่อปรับสเกลป้ายบนแกนค่าโดยไม่เปลี่ยนข้อมูลพื้นฐาน ด้วยการตั้งค่า [DisplayUnitType](https://reference.aspose.com/slides/python-java/aspose.slides/displayunittype/) เป็น `Millions` ค่าที่ 60,000,000 จะแสดงเป็น 60 ตัวอย่างสร้างแผนภูมิคอลัมน์และใช้หน่วยแสดงผลเป็นล้านบนแกนแนวตั้งของมัน

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ChartType, SaveFormat, DisplayUnitType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 450, 300)
    chart.getAxes().getVerticalAxis().setDisplayUnit(DisplayUnitType.Millions)

    presentation.save("Result.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **กำหนดค่าแกนค่าลอการิทึม**

แกนค่าลอการิทึมเป็นประโยชน์เมื่อค่าบวกกระจายอยู่หลายลำดับขนาด ตัวอย่าง บริการอาจได้รับคำขอ 10, 100, 1,000, 10,000, และ 100,000 ครั้งในห้าช่วง เวลาในสเกลเชิงเส้นค่าต่ำจะอยู่ใกล้ศูนย์กัน การสเกลลอการิทึมทำให้การเปรียบเทียการเติบโตสัมพันธ์ง่ายขึ้น: ระยะเท่ากันแทนอัตราส่วนเท่ากัน ไม่ใช่ความแตกต่างเท่าเดิม

เรียกใช้ [setLogarithmic](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setLogarithmic) กับ `True` บนแกนค่าและใช้ [setLogBase](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setLogBase) เพื่อเลือกฐาน การเปลี่ยนแปลงนี้ทำให้การแสดงค่าที่มีอยู่เปลี่ยนไป; ไม่ได้เปลี่ยนข้อมูลหรือเพิ่มเส้นแนวโน้มลอการิทึม เส้นแนวโน้มเป็นการแทนความสัมพันธ์ที่เหมาะสมกับข้อมูลและเป็นฟีเจอร์แยกจากกัน

### **เลือกแกนค่าและฐาน**

สำหรับแผนภูมิเส้นหรือคอลัมน์ แกนค่าจะได้จาก [getVerticalAxis](https://reference.aspose.com/slides/python-java/aspose.slides/axesmanager/#getVerticalAxis) สำหรับแผนภูมิบาร์แนวนอน จะได้จาก [getHorizontalAxis](https://reference.aspose.com/slides/python-java/aspose.slides/axesmanager/#getHorizontalAxis) แผนภูมิกระจายและฟองมีแกนค่าสองแกน ดังนั้นเลือกแกนแนวนอนสำหรับค่า X, แกนแนวตั้งสำหรับค่า Y หรือทั้งสองแกน อย่าใช้การสเกลลอการิทึมกับแกนหมวดหมู่

ฐานลอการิทึมเริ่มต้นคือ `10` สำหรับแผนภูมิ PPTX ให้ใช้ฐานตั้งแต่ `2` ถึง `1000` รวมถึงฐานเศษส่วนเช่น `2.5` ด้วยฐาน `10` พลังยกกำลังต่อเนื่องเช่น 10, 100, 1,000, และ 10,000 จะถูกจัดระยะอย่างเท่าเทียม

### **เปรียบเทียบการสเกลเชิงเส้นและลอการิทึม**

ตัวอย่างต่อไปนี้สร้างแผนภูมิเส้นที่มีจำนวนคำขอห้าช่วงบนสไลด์แรก แล้วคัดลอกสไลด์นั้นและเปิดใช้งานแกนค่าลอการิทึมฐาน 10 บนสไลด์ที่สอง ทั้งสองสไลด์รักษาข้อมูลเดียวกัน

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ChartType, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.Line, 30, 40, 660, 200)

    chart.setLegend(False)

    chart.getChartData().getCategories().clear()
    chart.getChartData().getSeries().clear()

    workbook = chart.getChartData().getChartDataWorkbook()
    workbook.clear(0)

    series = chart.getChartData().getSeries().add(ChartType.Line)
    values = [10, 100, 1000, 10000, 100000]

    for i, value in enumerate(values):
        category_cell = workbook.getCell(0, i + 1, 0, f"Period {i + 1}")
        chart.getChartData().getCategories().add(category_cell)

        value_cell = workbook.getCell(0, i + 1, 1, float(value))
        series.getDataPoints().addDataPointForLineSeries(value_cell)

    # คงสไลด์แรกเป็นเชิงเส้นและเปลี่ยนสเกลแกนค่าของสำเนาเท่านั้น.
    logarithmic_slide = presentation.getSlides().addClone(slide)
    logarithmic_chart = logarithmic_slide.getShapes().get_Item(0)
    value_axis = logarithmic_chart.getAxes().getVerticalAxis()
    value_axis.setLogarithmic(True)
    value_axis.setLogBase(10)

    presentation.save("LogarithmicAxis.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

**สเกลเชิงเส้น (สไลด์ 1):** ระยะแนวดิ่งเท่ากันแทนความแตกต่างเท่ากันของจำนวนคำขอ ค่าง่ายที่สุดครอบงำแผนภูมิ ทำให้ค่าต่ำดูยากต่อการแยกแยะ

![แผนภูมิเส้นใน PowerPoint แสดงห้าจำนวนคำขอบนแกนค่าที่เป็นเชิงเส้น](value-axis-linear.png)

**สเกลลอการิทึม (สไลด์ 2):** ระยะแนวดิ่งเท่ากันแทนอัตราส่วนเท่าเทียม แต่ละช่วงมีจำนวนคำขอเป็นสิบเท่าของช่วงก่อนหน้า ดังนั้นจุดข้อมูลจะแสดงเป็นเส้นตรงที่เพิ่มขึ้นบนสเกลฐาน 10 ป้ายแกนยังคงแสดงจำนวนคำขอเดิม

![จำนวนคำขอห้าข้อเดียวกันใน PowerPoint บนแกนค่าลอการิทึมฐาน 10](value-axis-logarithmic.png)

### **จัดการค่าศูนย์และค่าติดลบ**

สเกลลอการิทึมสามารถแสดงได้เฉพาะค่าบวกอย่างเคร่งครัด ตรวจสอบข้อมูลก่อนเปิดใช้ หากค่าศูนย์หรือค่าติดลบมีความหมาย ควรใช้สเกลเชิงเส้นหรือแสดงแยกออก หากการยกเว้นค่าดังกล่าวเหมาะกับการวิเคราะห์ ให้ชี้แจงเหตุผล ไม่ควรแทนที่ค่าดังกล่าวด้วยจำนวนบวกเล็ก ๆ อย่างเงียบ ๆ เพราะจะเปลี่ยนความหมายของข้อมูล ค่าอย่างต่ำหรือสูงสุดที่กำหนดด้วยตนเองสำหรับแกนลอการิทึมต้องเป็นค่าบวกเช่นกัน

## **คำถามที่พบบ่อย**

**ฉันจะตั้งค่าที่แกนหนึ่งตัดแกนอีก (การตัดของแกน) อย่างไร?**  
ใช้ [setCrossType](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setCrossType) เพื่อเลือกพฤติกรรมการตัด หากต้องการระบุค่าตัดเชิงตัวเลข ให้ใช้ [setCrossAt](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setCrossAt) การตั้งค่าเหล่านี้ช่วยให้คุณย้ายจุดตัดของแกนไปยังระดับฐานที่เหมาะสม

**ฉันจะตำแหน่งป้ายติ๊กสัมพันธ์กับแกนได้อย่างไร?**  
เรียก [setTickLabelPosition](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setTickLabelPosition) โดยใช้ [TickLabelPositionType](https://reference.aspose.com/slides/python-java/aspose.slides/ticklabelpositiontype/): `Low`, `High`, `NextTo`, หรือ `None` เพื่อกำหนดตำแหน่งป้ายติ๊ก หากต้องการควบคุมติ๊ก‑มาร์กเอง ให้ใช้ [setMajorTickMark](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setMajorTickMark) หรือ [setMinorTickMark](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setMinorTickMark) ซึ่งแยกจากการจัดตำแหน่งป้ายชื่ออย่างอิสระ