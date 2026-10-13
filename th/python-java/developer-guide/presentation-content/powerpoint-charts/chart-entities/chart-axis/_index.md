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
description: "ค้นพบวิธีใช้ Aspose.Slides สำหรับ Python ผ่าน Java เพื่อปรับแต่งแกนแผนภูมิในงานนำเสนอ PowerPoint สำหรับรายงานและการแสดงผล"
---
## **ภาพรวม**

บทความนี้อธิบายวิธีการปรับแต่งแกนของแผนภูมิด้วย Aspose.Slides for Python via Java. มันครอบคลุมค่าที่คำนวณของแกน, การสลับแถวและคอลัมน์ของแผนภูมิ, การมองเห็นแกน, ช่วงเวลาของป้ายระดับและเครื่องหมายบ่งชี้, หมวดวันที่และการจัดรูปแบบ, การหมุนหัวเรื่อง, การกำหนดตำแหน่งแกน, หน่วยแสดงผล, และการสเกลลอการิทึม

## **รับค่าสูงสุดบนแกนแนวตั้งของแผนภูมิ**

สร้าง [งานนำเสนอ](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) และเพิ่มแผนภูมิพื้นที่ด้วยข้อมูลค่าเริ่มต้น. เรียก [validateChartLayout](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#validateChartLayout) ก่อนอ่านค่าที่คำนวณของแกนเพื่อให้การจัดวางแผนภูมิเป็นปัจจุบัน.

อ่าน [getActualMaxValue](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#getActualMaxValue) และ [getActualMinValue](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#getActualMinValue) สำหรับขอบเขตของแกน, และ [getActualMajorUnit](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#getActualMajorUnit) กับ [getActualMinorUnit](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#getActualMinorUnit) สำหรับช่วงระยะของเครื่องหมายบ่งชี้. [getActualMajorUnitScale](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#getActualMajorUnitScale) และ [getActualMinorUnitScale](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#getActualMinorUnitScale) ให้สเกลหน่วยเวลา, ซึ่งเกี่ยวข้องกับแกนวันที่. ตัวอย่างเก็บค่าต่าง ๆ นี้ในตัวแปรท้องถิ่นและบันทึกแผนภูมิ

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

ใช้ [switchRowColumn](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#switchRowColumn) เพื่อสลับบทบาทของชุดข้อมูลและหมวดหมู่ในข้อมูลแผนภูมิ. แต่ละหมวดเดิมจะกลายเป็นชุดข้อมูล, และแต่ละชุดข้อมูลเดิมจะกลายเป็นหมวด. การเปลี่ยนนี้ทำให้การจัดกลุ่มข้อมูลเปลี่ยน; มันไม่ได้สลับแกนแนวนอนและแนวตั้ง. ตัวอย่างใช้ [setRange](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#setRange) เพื่อผูกข้อมูลค่าเริ่มต้นกับ `Sheet1!A1:D5`, รวมแถวหัวและคอลัมน์หมวด, ก่อนสลับแถวและคอลัมน์. มันบันทึกแผนภูมิที่มีสี่ชุดข้อมูลและสามหมวด

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

## **ปิดการแสดงแกนแนวตั้งสำหรับแผนภูมิเส้น**

เรียก [setVisible](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setVisible) ด้วยค่า `False` บนแกนแนวตั้งเพื่อซ่อนมัน. ตัวอย่างสร้างแผนภูมิเส้นด้วยข้อมูลค่าเริ่มต้นและบันทึกโดยมีแกนแนวตั้งถูกซ่อน

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

เรียก [setVisible](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setVisible) ด้วยค่า `False` บนแกนแนวนอนเพื่อซ่อนมัน. ตัวอย่างสร้างแผนภูมิเส้นด้วยข้อมูลค่าเริ่มต้นและบันทึกโดยมีแกนแนวนอนถูกซ่อน

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

## **เปลี่ยนแกนประเภท**

ใช้ [setCategoryAxisType](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setCategoryAxisType) เพื่อเลือกแกนประเภทวันที่หรือข้อความ. ตัวอย่างนี้ต้องการ `ExistingChart.pptx`, โดยมีแผนภูมิเป็นรูปร่างแรกบนสไลด์แรกและเซลล์หมวดมีค่าที่เป็นวันที่ Excel ตัวเลข. มันเปลี่ยนแกนแนวนอนเป็นแกนวันที่. การเรียก [setAutomaticMajorUnit](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setAutomaticMajorUnit) ด้วย `False`, [setMajorUnit](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setMajorUnit) ด้วย `1`, และ [setMajorUnitScale](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setMajorUnitScale) ด้วย [TimeUnitType.Months](https://reference.aspose.com/slides/python-java/aspose.slides/timeunittype/#Months) จะทำให้เครื่องหมายหลักอยู่ที่ช่วงหนึ่งเดือน

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

## **ควบคุมช่วงเวลาของป้ายแกนประเภท**

เมื่อแผนภูมิมีหลายหมวด, สามารถลดจำนวนป้ายแกนที่มองเห็นได้โดยไม่ต้องลบหมวดหรือจุดข้อมูล. เรียก [setAutomaticTickLabelSpacing](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setAutomaticTickLabelSpacing) ด้วย `False`, จากนั้นส่งช่วงหมวดที่ต้องการไปยัง [setTickLabelSpacing](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setTickLabelSpacing). สำหรับหมวดข้อความในลำดับปกติ, การนับเริ่มจากหมวดแรก:

| ช่วง | ป้ายที่แสดงในตัวอย่าง |
| --- | --- |
| `1` | หมวด 1, หมวด 2, หมวด 3, ... หมวด 24 |
| `2` | หมวด 1, หมวด 3, หมวด 5, ... หมวด 23 |
| `3` | หมวด 1, หมวด 4, หมวด 7, ... หมวด 22 |

ช่วง `3` จะทำให้แสดงป้ายทุก ๆ หมวดที่สาม, โดยเหลือสองป้ายที่ซ่อนอยู่ระหว่างป้ายที่แสดง. มันไม่ลบคอลัมน์ที่สอดคล้องกัน. การจัดช่องว่างอัตโนมัติจะเลือกช่วงตามพื้นที่ที่มี; ไม่ได้หมายความว่าจะต้องแสดงทุกป้าย.

เครื่องหมายบ่งชี้มีการควบคุมแยกต่างหาก. เรียก [setAutomaticTickMarksSpacing](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setAutomaticTickMarksSpacing) ด้วย `False` และใช้ [setTickMarksSpacing](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setTickMarksSpacing) เพื่อกำหนดช่วงของมัน. ตัวอย่างเช่น, `1` จะทำให้มีเครื่องหมายบ่งชี้ที่ทุกช่วงหมวดในขณะที่ป้ายปรากฏเพียงทุก ๆ หมวดที่สาม. ใช้ [setMajorTickMark](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setMajorTickMark) ด้วยสไตล์ที่มองเห็นได้เพื่อให้เห็นผลลัพธ์. การเรียกตัวตั้งค่าการจัดช่องว่างอัตโนมัติใด ๆ ด้วย `True` อีกครั้งจะทำให้แผนภูมิเลือกช่วงนั้นใหม่

ตัวอย่างอิสระต่อไปนี้สร้าง 24 หมวดและหนึ่งชุดข้อมูล, จากนั้นบันทึกสามสไลด์ใน `CategoryAxisIntervals.pptx`: การจัดช่องว่างอัตโนมัติ, การจัดช่องว่างด้วยตนเองพร้อมเครื่องหมายบ่งชี้อิสระ, และการคืนค่าเป็นการจัดช่องว่างอัตโนมัติ. สองสำเนาเก็บข้อมูลแผนภูมิดั้งเดิม. ไม่จำเป็นต้องมีงานนำเสนอเข้า. ข้อความป้ายแนวนอนทำให้ความหนาแน่นต่างกันเห็นได้ง่าย

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

    # สไลด์ 2: แสดงป้ายทุกสามรายการ แต่คงเครื่องหมายบรรทัดสำหรับทุกหมวด.
    manual_slide = presentation.getSlides().addClone(slide)
    manual_chart = manual_slide.getShapes().get_Item(0)
    manual_axis = manual_chart.getAxes().getHorizontalAxis()
    manual_axis.setAutomaticTickLabelSpacing(False)
    manual_axis.setTickLabelSpacing(3)
    manual_axis.setAutomaticTickMarksSpacing(False)
    manual_axis.setTickMarksSpacing(1)

    # สไลด์ 3: ให้แผนภูมิเลือกช่วงทั้งสองใหม่อีกครั้ง.
    restored_slide = presentation.getSlides().addClone(manual_slide)
    restored_chart = restored_slide.getShapes().get_Item(0)
    restored_chart.getAxes().getHorizontalAxis().setAutomaticTickLabelSpacing(True)
    restored_chart.getAxes().getHorizontalAxis().setAutomaticTickMarksSpacing(True)

    presentation.save("CategoryAxisIntervals.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

**การจัดช่องว่างอัตโนมัติ (สไลด์ 1):** ในการแสดงผลนี้, ป้ายหมวดที่สองจะถูกแสดงและขึ้นบรรทัดใหม่สองบรรทัด. ผลลัพธ์อัตโนมัติอาจแตกต่างตามขนาดแผนภูมิ, ฟอนต์, และตัวเรนเดอร์

![การจัดช่องว่างป้ายหมวดอัตโนมัติพร้อมคอลัมน์ทั้งหมด 24 คอลัมน์มองเห็นได้](category-axis-automatic.png)

**การจัดช่องว่างด้วยตนเอง (สไลด์ 2):** ป้ายที่สามจะแสดงในบรรทัดเดียว, ในขณะที่เครื่องหมายบ่งชี้ยังคงอยู่ที่ทุกช่วงหมวด. ทั้ง 24 คอลัมน์, รวมถึงคอลัมน์ที่ไม่มีป้าย, ยังคงมองเห็นได้ด้วยค่าที่เหมือนกัน. สไลด์ 3 คืนค่าต่าง ๆ ให้กลับสู่การจัดช่องว่างอัตโนมัติเช่นแสดงด้านบน

![ช่วงป้ายหมวดแบบมือที่สามพร้อมคอลัมน์ทั้งหมด 24 คอลัมน์มองเห็นได้](category-axis-manual.png)

### **เลือกแกนและช่วงที่ถูกต้อง**

ใช้ช่วงจำนวนหมวดนี้สำหรับแกนประเภทข้อความ, เช่น แกนประเภทของแผนภูมิคอลัมน์, เส้น, พื้นที่, หรือแถบ. ในแผนภูมิคอลัมน์, มันเป็นแกนแนวนอน. ในแผนภูมิเส้นแนวนอน, แกนประเภทอยู่แนวตั้ง, ดังนั้นให้ใช้การตั้งค่าเหล่านี้กับแกนที่ได้จาก [getVerticalAxis](https://reference.aspose.com/slides/python-java/aspose.slides/axesmanager/#getVerticalAxis). ระยะห่างของเครื่องหมายบ่งชี้ยังใช้ได้กับแกนชุดข้อมูลในแผนภูมิที่มีแกนชุดข้อมูล

อย่าใช้การจัดช่องว่างของป้ายหมวดเพื่อกำหนดสเกลเชิงตัวเลขของแกนค่า. บนแกนค่า, [setMajorUnit](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setMajorUnit) ระบุความต่างของค่าตัวอย่าง, เช่น หน่วยหลัก `10` จะสร้างเครื่องหมายที่ 0, 10, 20, เป็นต้นเมื่อแกนเริ่มที่ศูนย์. ช่วงป้ายหมวด `3` จะนับตำแหน่งหมวดโดยไม่คำนึงถึงค่าข้อมูล. แผนภูมิกระจายและฟองใช้แกนค่าแทนแกนประเภทข้อความ. สำหรับแกนวันที่, ให้ใช้หน่วยหลักและสเกลตามเวลาเช่นอธิบายไว้ใน [เปลี่ยนแกนประเภท](#change-a-category-axis)

## **ตั้งค่ารูปแบบวันที่สำหรับค่าของแกนประเภท**

ตัวอย่างแทนที่ข้อมูลแผนภูมิค่าเริ่มต้นด้วยสี่ค่าปี. วันที่ถูกจัดเก็บเป็นตัวเลขซีเรียล OLE Automation ในเวิร์กชีตแรก (ดัชนี `0`), คำนวณจากจำนวนวันตั้งแต่ 30 ธ.ค. 1899 สำหรับวันที่เหล่านี้. ใช้ [setCategoryAxisType](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setCategoryAxisType) กับ [CategoryAxisType.Date](https://reference.aspose.com/slides/python-java/aspose.slides/categoryaxistype/#Date), เรียก [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setNumberFormatLinkedToSource) ด้วย `False`, และส่ง `yyyy` ไปยัง [setNumberFormat](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setNumberFormat) เพื่อให้ป้ายหมวดแสดงปีสี่หลักโดยอิสระจากการจัดรูปแบบเซลล์

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

เรียก [setTitle](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setTitle) ด้วย `True` บนแกนแนวตั้ง, ใส่ข้อความชื่อ, และตั้งค่ามุมการหมุนในรูปแบบบล็อกข้อความของชื่อ. มุมวัดเป็นองศา; ตัวอย่างนี้บันทึกแผนภูมิคอลัมน์โดยหมุนชื่อแกนค่าที่ 90 องศา

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

## **ตั้งค่าตำแหน่งแกนบนแกนประเภทหรือค่า**

ใช้ [setAxisBetweenCategories](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setAxisBetweenCategories) เพื่อควบคุมว่าแกนค่าตัดกับแกนประเภทระหว่างหมวดหรือที่เครื่องหมายหมวด. การตั้งค่านี้ใช้กับแกนประเภท. ตัวอย่างตั้งค่าเป็น `True` บนแกนประเภทแนวนอนของแผนภูมิคอลัมน์และบันทึกผลลัพธ์

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

## **ตั้งค่าหน่วยแสดงผลบนแกนค่าของแผนภูมิ**

ใช้ [setDisplayUnit](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setDisplayUnit) เพื่อสเกลป้ายบนแกนค่าโดยไม่ต้องเปลี่ยนข้อมูลพื้นฐาน. กับ [DisplayUnitType](https://reference.aspose.com/slides/python-java/aspose.slides/displayunittype/) ตั้งเป็น `Millions`, ค่า 60,000,000 จะแสดงเป็น 60. ตัวอย่างสร้างแผนภูมิคอลัมน์และใช้หน่วยแสดงผลล้านบนแกนแนวตั้ง

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

แกนค่าลอการิทึมมีประโยชน์เมื่อค่าบวกกระจายหลายระดับจำนวน. ตัวอย่างเช่น บริการอาจได้รับคำขอ 10, 100, 1,000, 10,000, และ 100,000 ในห้าช่วง. บนสเกลเชิงเส้น, ค่าที่เล็กกว่าจะอยู่ใกล้ศูนย์กัน. สเกลลอการิทึมทำให้การเปรียบเทียบการเติบโตสัมพันธ์ง่ายขึ้น: ระยะห่างที่เท่ากันแทนสัดส่วนที่เท่ากันแทนความแตกต่างที่เท่าเดียว

เรียก [setLogarithmic](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setLogarithmic) ด้วย `True` บนแกนค่าและใช้ [setLogBase](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setLogBase) เพื่อเลือกฐาน. สิ่งนี้เปลี่ยนวิธีแสดงค่าที่มีอยู่; ไม่ได้เปลี่ยนข้อมูลหรือเพิ่มเส้นแนวโน้มลอการิทึม. เส้นแนวโน้มเป็นฟีเจอร์แยกต่างหากที่แสดงความสัมพันธ์ที่ฟิตกับข้อมูล

### **เลือกแกนค่าและฐาน**

สำหรับแผนภูมิเส้นหรือคอลัมน์, แกนค่าจะได้จาก [getVerticalAxis](https://reference.aspose.com/slides/python-java/aspose.slides/axesmanager/#getVerticalAxis). สำหรับแผนภูมิแถบแนวนอน, จะได้จาก [getHorizontalAxis](https://reference.aspose.com/slides/python-java/aspose.slides/axesmanager/#getHorizontalAxis). แผนภูมิกระจายและฟองมีแกนค่าสองแกน, ดังนั้นเลือกแกนแนวนอนสำหรับค่า X, แกนแนวตั้งสำหรับค่า Y, หรือทั้งสอง. อย่าใช้สเกลลอการิทึมกับแกนประเภท

ฐานลอการิทึมเริ่มต้นคือ `10`. สำหรับแผนภูมิกระดาน PPTX, สามารถใช้ฐานตั้งแต่ `2` ถึง `1000` รวมถึงฐานเศษส่วนเช่น `2.5`. ด้วยฐาน `10`, พลังงานต่อเนื่องเช่น 10, 100, 1,000, และ 10,000 จะสเปซเท่ากัน

### **เปรียบเทียบการสเกลเชิงเส้นและลอการิทึม**

ตัวอย่างอิสระต่อไปนี้สร้างแผนภูมิเส้นพร้อมจำนวนคำขอห้าช่วงบนสไลด์แรก, จากนั้นคัดลอกสไลด์นั้นและเปิดใช้งานแกนค่าลอการิทึมฐาน-10 บนสไลด์ที่สอง. ทั้งสองสไลด์เก็บข้อมูลเดียวกัน

```python
import jpage
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

    # เก็บสไลด์แรกเป็นเชิงเส้นและเปลี่ยนสเกลแกนค่าของสำเนาเท่านั้น.
    logarithmic_slide = presentation.getSlides().addClone(slide)
    logarithmic_chart = logarithmic_slide.getShapes().get_Item(0)
    value_axis = logarithmic_chart.getAxes().getVerticalAxis()
    value_axis.setLogarithmic(True)
    value_axis.setLogBase(10)

    presentation.save("LogarithmicAxis.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

**สเกลเชิงเส้น (สไลด์ 1):** ระยะแนวตั้งที่เท่ากันแทนความแตกต่างที่เท่าเดียวของจำนวนคำขอ. ค่าที่ใหญ่ที่สุดครอบคลุมแผนภูมิ, ทำให้ค่าที่เล็กกว่าจะยากต่อการแยกแยะ

![แผนภูมิเส้นใน PowerPoint แสดงห้าจำนวนคำขอบนแกนค่าที่เป็นเชิงเส้น](value-axis-linear.png)

**สเกลลอการิทึม (สไลด์ 2):** ระยะแนวตั้งที่เท่ากันแทนสัดส่วนที่เท่าเดียว. แต่ละช่วงมีจำนวนคำขอเพิ่มขึ้นสิบเท่าเมื่อเทียบกับช่วงก่อน, ดังนั้นจุดจะสร้างเส้นตรงที่ขึ้นบนสเกลฐาน-10. ป้ายแกนยังคงแสดงจำนวนคำขอเดิม

![ห้าจำนวนคำขอเดียวกันใน PowerPoint บนแกนค่าลอการิทึมฐาน-10](value-axis-logarithmic.png)

### **จัดการกับค่าศูนย์และค่าติดลบ**

สเกลลอการิทึมสามารถแสดงค่าได้เฉพาะค่าบวกที่แน่ชัด. ตรวจสอบข้อมูลก่อนเปิดใช้งาน. หากศูนย์หรือค่าติดลบมีความหมาย, ควรใช้สเกลเชิงเส้นหรือแสดงแยกต่างหาก. หากการละเว้นค่าดังกล่าวเหมาะสมกับการวิเคราะห์, ควรอธิบายเหตุผล. อย่าแทนที่ค่าดังกล่าวด้วยตัวเลขบวกเล็ก ๆ อย่างเงียบ ๆ เพราะจะเปลี่ยนความหมายของข้อมูล. ค่าต่ำสุดหรือค่าสูงสุดที่ตั้งค่าเองสำหรับแกนลอการิทึมต้องเป็นค่าบวกเช่นกัน

## **คำถามที่พบบ่อย**

**ฉันจะตั้งค่าที่แกนหนึ่งตัดแกนอื่น (การตัดแกน) อย่างไร?**

ใช้ [setCrossType](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setCrossType) เพื่อเลือกพฤติการณ์การตัด. หากต้องการระบุค่าตัดเชิงตัวเลข, ใช้ [setCrossAt](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setCrossAt). การตั้งค่าเหล่านี้ช่วยให้คุณย้ายการตัดแกนไปยังเส้นฐานที่เหมาะสม

**ฉันจะกำหนดตำแหน่งของป้ายเครื่องหมายบ่งชี้สัมพันธ์กับแกนอย่างไร?**

เรียก [setTickLabelPosition](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setTickLabelPosition) โดยใช้ [TickLabelPositionType](https://reference.aspose.com/slides/python-java/aspose.slides/ticklabelpositiontype/): `Low`, `High`, `NextTo`, หรือ `None`. เพื่อควบคุมเครื่องหมายบ่งชี้เอง, ใช้ [setMajorTickMark](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setMajorTickMark) หรือ [setMinorTickMark](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setMinorTickMark); สิ่งเหล่านี้แยกจากการกำหนดตำแหน่งป้าย.