---
title: จัดการชุดข้อมูลแผนภูมิในงานนำเสนอด้วย Python
linktitle: ชุดข้อมูล
type: docs
url: /th/python-java/chart-series/
keywords:
- ชุดข้อมูลแผนภูมิ
- การทับซ้อนของชุด
- สีของชุด
- ชื่อชุด
- จุดข้อมูล
- เซลล์ workbook
- ช่องว่างของชุด
- ค่าติดลบ
- PowerPoint
- งานนำเสนอ
- Python
- Java
- Aspose.Slides
description: "เรียนรู้วิธีจัดการชุดข้อมูลแผนภูมิ, จุดข้อมูล, เซลล์ workbook, การจัดรูปแบบ, การทับซ้อน, ความกว้างของช่องว่าง, และค่าติดลบในงานนำเสนอด้วย Aspose.Slides สำหรับ Python ผ่าน Java."
---
## **ภาพรวม**

แผนภูมิสามารถเก็บค่าที่พล็อตไว้ในเซลล์ของ workbook หรือเป็นค่าตัวเลขโดยตรงได้ [ChartSeries](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/) แทนชุดค่าที่เกี่ยวข้องหนึ่งชุด และแต่ละ [ChartDataPoint](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapoint/) แทนจุดหนึ่งในชุดนั้น [ChartCategory](https://reference.aspose.com/slides/python-java/aspose.slides/chartcategory/) ให้ป้ายหรือค่ากลุ่มที่ใช้ร่วมกันโดยชุดข้อมูล ในแผนภูมิที่สร้างด้วยข้อมูลเริ่มต้น ชื่อชุดข้อมูล, หมวดหมู่, และค่าจุดใช้วัตถุ [ChartDataCell](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatacell/) จาก workbook ของแผนภูมิ

สำหรับแผนภูมิกลุ่มประเภทมาตรฐาน workbook เริ่มต้นใช้แถว 0 สำหรับชื่อชุดข้อมูล, คอลัมน์ 0 สำหรับชื่อหมวดหมู่, และเซลล์ที่เหลือสำหรับค่าชุดข้อมูล ดัชนี worksheet, แถว, และคอลัมน์ที่ส่งให้ [ChartDataWorkbook.getCell](https://reference.aspose.com/slides/python-java/aspose.slides/chartdataworkbook/#getCell) มีค่าเริ่มต้นจาก 0 การจัดวางนี้เป็นประโยชน์เมื่อคุณสร้างแผนภูมิด้วยข้อมูลเริ่มต้น แต่ไม่ควรสันนิษฐานว่าแผนภูมิวางอยู่แล้วทั้งหมดใช้แบบนี้ สำหรับงานนำเสนอที่โหลดมา ให้ตรวจสอบเซลล์ที่ชุดข้อมูล, หมวดหมู่, และจุดข้อมูลอ้างอิงก่อนที่จะเปลี่ยนค่าใน workbook

การตั้งค่าแผนภูมิมีสามระดับขอบเขตต่างกัน:

- การตั้งค่าระดับชุดข้อมูล เช่น [ChartSeries.getFormat](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#getFormat) ให้รูปลักษณ์เริ่มต้นสำหรับจุดทั้งหมดในชุดเดียว
- การตั้งค่าระดับจุดข้อมูล เช่น [ChartDataPoint.getFormat](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapoint/#getFormat) เขียนทับรูปลักษณ์ของชุดสำหรับจุดหนึ่ง
- การตั้งค่ากลุ่มใช้กับชุดข้อมูลที่เข้ากันซึ่งอยู่ใน [ChartSeriesGroup](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/) เดียว เข้าถึงกลุ่มผ่าน [ChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#getParentSeriesGroup) เมื่อคุณต้องการกำหนดตัวเลือกเช่น overlap หรือ gap width

เมื่อไม่มีการกำหนดการเติมจุดหรือชุดข้อมูลโดยชัดเจน สไตล์และธีมของแผนภูมิจะกำหนดรูปลักษณ์อัตโนมัติ เมื่อทั้งการจัดรูปแบบชุดและการจัดรูปแบบจุดมีอยู่ การจัดรูปแบบจุดจะมีลำดับความสำคัญสำหรับจุดนั้น

![chart-series-powerpoint](chart-series-powerpoint.png)

สำหรับแผนภูมิทรงกระบอกแบบจัดกลุ่ม ให้ดูว่า [changing the 3D series type or bar shape](/slides/th/python-java/3d-chart/#change-the-3d-series-type-and-bar-shape) มีผลต่อชุดแรกอย่างไร

## **การตั้งค่าชุดข้อมูลโดยใช้ค่าตัวเลขลิเทอรัล**

ใช้ค่าตัวเลขลิเทอรัลเมื่อค่าชุดข้อมูลมาจากข้อมูลแอปพลิเคชันหรือการคำนวณและไม่จำเป็นต้องอ้างอิงเซลล์ worksheet เรียก [setDataSourceTypeForValues](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapointcollection/#setDataSourceTypeForValues) พร้อม [DataSourceType.DoubleLiterals](https://reference.aspose.com/slides/python-java/aspose.slides/datasourcetype/#DoubleLiterals) ก่อนกำหนดผลลัพธ์ [getValue](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapoint/#getValue) ของแต่ละจุดผ่าน [setAsLiteralDouble](https://reference.aspose.com/slides/python-java/aspose.slides/doublechartvalue/#setAsLiteralDouble)

การตั้งค่าคอลเลกชันควบคุมประเภทแหล่งที่มาของค่าจุดทั้งหมดในชุด แต่ละจุด [getDataSourceType](https://reference.aspose.com/slides/python-java/aspose.slides/basechartvalue/#getDataSourceType) รายงานประเภทที่เลือก เปลี่ยนได้ผ่านการตั้งค่าคอลเลกชัน เมื่อใช้ `Worksheet` ให้ใช้ [getAsCell](https://reference.aspose.com/slides/python-java/aspose.slides/doublechartvalue/#getAsCell) เพื่อเข้าถึงเซลล์อ้างอิง เมื่อใช้ `DoubleLiterals` ให้ใช้ [getAsLiteralDouble](https://reference.aspose.com/slides/python-java/aspose.slides/doublechartvalue/#getAsLiteralDouble) หรือ `setAsLiteralDouble` เพื่ออ่านหรือเขียนตัวเลขโดยตรง

ตัวอย่างต่อไปนี้สร้างแผนภูมิคอลัมน์ด้วยชุดและหมวดหมู่เริ่มต้น จากนั้นกำหนดค่าคำนวณ 10, 20 ฯลฯ ให้กับจุดที่มีอยู่ของชุดแรก บันทึกงานนำเสนอ, เปิดใหม่อีกครั้ง, และพิมพ์ค่าที่เก็บไว้

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, DataSourceType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 300)
    series = chart.getChartData().getSeries().get_Item(0)

    series.getDataPoints().setDataSourceTypeForValues(DataSourceType.DoubleLiterals)
    for i in range(series.getDataPoints().size()):
        series.getDataPoints().get_Item(i).getValue().setAsLiteralDouble((i + 1) * 10)

    presentation.save("numeric_literals.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()

reopened_presentation = Presentation("numeric_literals.pptx")
try:
    reopened_slide = reopened_presentation.getSlides().get_Item(0)
    reopened_chart = reopened_slide.getShapes().get_Item(0)
    reopened_series = reopened_chart.getChartData().getSeries().get_Item(0)
    for point in reopened_series.getDataPoints():
        print(point.getValue().getAsLiteralDouble())
finally:
    reopened_presentation.dispose()
```

ประเภทแหล่งที่มาของค่าจุดแยกจาก [ChartData.getDataSourceType](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#getDataSourceType) ซึ่งระบุการกำหนดค่า workbook ภายในหรือภายนอกของแผนภูมิ การใช้ค่าตัวเลขลิเทอรัลไม่ได้ลบ workbook ที่ฝังอยู่โดยอัตโนมัติ ในตัวอย่างนี้ workbook ยังคงใช้สำหรับป้ายหมวดหมู่, ชื่อชุดข้อมูล, และชุดอื่น ดู [Chart Workbook](/slides/th/python-java/chart-workbook/) สำหรับการจัดการ workbook

สำหรับแผนภูมิจุดกระจายและฟองอากาศ ให้ใช้ [setDataSourceTypeForXValues](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapointcollection/#setDataSourceTypeForXValues) และ [setDataSourceTypeForYValues](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapointcollection/#setDataSourceTypeForYValues) เพื่อเลือกแหล่งที่มาสำหรับ [getXValue](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapoint/#getXValue) และ [getYValue](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapoint/#getYValue) แผนภูมิฟองอากาศยังใช้ [setDataSourceTypeForBubbleSizes](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapointcollection/#setDataSourceTypeForBubbleSizes) สำหรับ [getBubbleSize](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapoint/#getBubbleSize) ตั้งแต่แหล่งที่มาที่เกี่ยวข้องเป็น `DoubleLiterals` ก่อนกำหนดตัวเลขผ่าน `setAsLiteralDouble`

## **การตั้งค่า Overlap ของชุดข้อมูลในแผนภูมิ**

[ChartSeries.getOverlap](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#getOverlap) รายงานว่าบาร์หรือคอลัมน์ทับกันเท่าไรในแผนภูมิ 2D ตั้งแต่ ‑100 ถึง 100 เปอร์เซ็นต์ โดยเป็นการฉายภาพแบบอ่าน‑เท่านั้นของการตั้งค่าบนกลุ่มชุดหลัก ใช้ [ChartSeriesGroup.setOverlap](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/#setOverlap) เพื่ออัปเดตทุกชุดที่เข้ากันในกลุ่มนั้น ตัวเลือกนี้ใช้กับประเภทแผนภูมิที่แสดงบาร์หรือคอลัมน์เป็นกลุ่ม; ไม่กระทบกับกลุ่มชุดที่ไม่เกี่ยวข้องในแผนภูมิกำหนดค่า

ตัวอย่างต่อไปนี้ตั้งค่า overlap สำหรับกลุ่มที่มีชุดแรกอยู่

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

first_slide_index = 0
first_series_index = 0
overlap_percent = 30

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(first_slide_index)

    # แผนภูมิใหม่มีชุดตัวอย่าง, หมวดหมู่, และค่า.
    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200)

    series = chart.getChartData().getSeries().get_Item(first_series_index)
    series.getParentSeriesGroup().setOverlap(overlap_percent)

    presentation.save("series_overlap.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

ผลลัพธ์:

![The series overlap](series_overlap.png)

## **การเปลี่ยนสีเติมของชุดข้อมูล**

ใช้ [ChartSeries.getFormat](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#getFormat) เพื่อตั้งค่าสีเติมเริ่มต้นสำหรับชุดทั้งหมด หากจุดมีการเติมที่ระบุแล้ว [ChartDataPoint.getFormat](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapoint/#getFormat) จะเขียนทับการเติมของชุดสำหรับจุดนั้น

ตัวอย่างต่อไปนี้ใช้สีทึบสีน้ำเงินเติมให้กับชุดแรก

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, FillType, Presentation, SaveFormat

Color = jpype.JClass("java.awt.Color")

first_slide_index = 0
first_series_index = 0

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(first_slide_index)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200)

    series = chart.getChartData().getSeries().get_Item(first_series_index)
    series.getFormat().getFill().setFillType(FillType.Solid)
    series.getFormat().getFill().getSolidFillColor().setColor(Color.BLUE)

    presentation.save("series_color.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

ผลลัพธ์:

![The color of the series](series_color.png)

## **การเปลี่ยนชื่อชุดข้อมูล**

ชื่อชุดข้อมูลถูกเก็บใน chart data workbook และโดยปกติจะแสดงในคำอธิบาย ใน workbook เริ่มต้นที่สร้างสำหรับแผนภูมิคอลัมน์จัดกลุ่ม เซลล์ B1 อยู่ที่แถว 0, คอลัมน์ 1 และมีชื่อของชุดแรก ตัวแปรที่ตั้งชื่อในตัวอย่างต่อไปนี้ทำให้โครงสร้างนี้ชัดเจน

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

first_slide_index = 0
worksheet_index = 0
series_name_row_index = 0
first_series_column_index = 1

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(first_slide_index)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200)

    workbook = chart.getChartData().getChartDataWorkbook()
    series_name_cell = workbook.getCell(worksheet_index, series_name_row_index, first_series_column_index)
    series_name_cell.setValue("Revenue")

    presentation.save("series_name.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

คุณสามารถอัปเดตเซลล์ที่ [ChartSeries.getName](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#getName) อ้างอิงอยู่ได้ วิธีนี้หลีกเลี่ยงการสมมติแถวและคอลัมน์เฉพาะในแผนภูมิที่มีอยู่

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

first_slide_index = 0
first_series_index = 0
first_name_cell_index = 0

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(first_slide_index)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200)

    series = chart.getChartData().getSeries().get_Item(first_series_index)
    series_name_cell = series.getName().getAsCells().get_Item(first_name_cell_index)
    series_name_cell.setValue("Revenue")

    presentation.save("series_name.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

ผลลัพธ์:

![The series name](series_name.png)

### **สร้างชุดข้อมูลด้วยชื่อจากหลายเซลล์**

ชื่อชุดข้อมูลเชิงประกอบมีประโยชน์เมื่อชื่อผลิตภัณฑ์และช่วงเวลารายงานถูกเก็บในเซลล์ workbook แยกกัน เช่น คุณสามารถผสาน `Product A` ใน B1 และ `2026` ใน C1 เป็นชื่อชุดเดียวโดยให้ส่วนทั้งสองเชื่อมต่อกับเซลล์แหล่งที่มาของตน

ใช้ [ChartDataWorkbook.getCellCollection](https://reference.aspose.com/slides/python-java/aspose.slides/chartdataworkbook/#getCellCollection) เพื่อดึงช่วงชื่อ แล้วส่งคอลเลกชันนั้นให้ [ChartSeriesCollection.add](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriescollection/#add) อาร์กิวเมนต์ `skipHiddenCells` ควบคุมว่าจะรวมเซลล์ที่ซ่อนไว้หรือไม่: `True` ยกเว้น, `False` รวม ตัวอย่างนี้ใช้ `False` เพื่อรวมทุกเซลล์ในช่วงชื่อ

ตัวอย่างต่อไปนี้สร้างงานนำเสนอที่มีชุดหนึ่งและจุดข้อมูลสองจุด เซลล์ B1:C1 ให้ชื่อชุดเท่านั้น; A2:A3 ให้ป้ายหมวดหมู่, B2:B3 ให้ค่าตัวเลข

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 620, 180)

    chart.getChartData().getSeries().clear()
    chart.getChartData().getCategories().clear()
    chart.setLegend(True)

    workbook = chart.getChartData().getChartDataWorkbook()
    workbook.clear(0)

    # เซลล์สองนี้ให้ชื่อชุดข้อมูล.
    workbook.getCell(0, 0, 1, "Product A")
    workbook.getCell(0, 0, 2, "2026")
    name_cells = workbook.getCellCollection("Sheet1!$B$1:$C$1", False)
    series = chart.getChartData().getSeries().add(name_cells, ChartType.ClusteredColumn)

    # เซลล์แยกให้หมวดหมู่และจุดข้อมูลเชิงตัวเลข.
    north_category = workbook.getCell(0, 1, 0, "North")
    south_category = workbook.getCell(0, 2, 0, "South")
    chart.getChartData().getCategories().add(north_category)
    chart.getChartData().getCategories().add(south_category)
    north_value = workbook.getCell(0, 1, 1, jpype.JInt(120))
    south_value = workbook.getCell(0, 2, 1, jpype.JInt(150))
    series.getDataPoints().addDataPointForBarSeries(north_value)
    series.getDataPoints().addDataPointForBarSeries(south_value)

    presentation.save("composite_series_name.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

ชื่อชุดที่ได้คือ `Product A 2026` โดยมีช่องว่างระหว่างค่าจากสองเซลล์ คำอธิบายจะแสดงเป็นรายการเดียวสำหรับสองคอลัมน์ รูปภาพด้านล่างแสดงผลลัพธ์

![Column chart with North and South values and the composite series name Product A 2026 in the legend](composite_series_name.png)

## **รับสีเติมอัตโนมัติของชุดข้อมูล**

[ChartSeries.getAutomaticSeriesColor](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#getAutomaticSeriesColor) คืนค่าสีที่คำนวณจากดัชนีชุดและสไตล์แผนภูมิ เป็นสีที่ใช้เมื่อการเติมชุดไม่ได้กำหนดอย่างชัดเจน การเรียกเมธอดนี้อ่านค่าสีที่ค.calculate โดยไม่กำหนดการเติมใหม่

ตัวอย่างต่อไปนี้พิมพ์สีอัตโนมัติของแต่ละชุดเริ่มต้น

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation

first_slide_index = 0

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(first_slide_index)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200)

    series_count = chart.getChartData().getSeries().size()
    for series_index in range(series_count):
        series = chart.getChartData().getSeries().get_Item(series_index)
        automatic_color = series.getAutomaticSeriesColor()
        print(f"Series {series_index}: {automatic_color}")
finally:
    presentation.dispose()
```

ผลลัพธ์ตัวอย่างสำหรับสไตล์แผนภูมิเริ่มต้น

```text
Series 0: java.awt.Color[r=79,g=129,b=189]
Series 1: java.awt.Color[r=192,g=80,b=77]
Series 2: java.awt.Color[r=155,g=187,b=89]
```

สีที่แน่นอนขึ้นอยู่กับสไตล์และธีมของแผนภูมิ

## **ตั้งค่าสีเติมกลับสำหรับชุดข้อมูลในแผนภูมิ**

สำหรับชุดบาร์, คอลัมน์, และฟองอากาศ [ChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#setInvertIfNegative) สามารถแสดงค่าติดลบด้วยสีเติมที่ต่างออกไป ตั้งค่าการเติมปกติเป็นสีทึบ, เปิดการกลับสี, แล้วกำหนดสีค่าติดลบผ่าน [ChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#getInvertedSolidFillColor) ตัวเลขติดลบจะคงอยู่ใน workbook; เพียงสีการแสดงเท่านั้นที่เปลี่ยน

ตัวอย่างต่อไปนี้แทนที่ข้อมูลแผนภูมิเริ่มต้นด้วยชุดหนึ่ง แถว 0 ของ worksheet มีชื่อชุด, คอลัมน์ 0 มีชื่อหมวดหมู่, คอลัมน์ 1 มีค่า

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, FillType, Presentation, SaveFormat

Color = jpype.JClass("java.awt.Color")

first_slide_index = 0
worksheet_index = 0
header_row_index = 0
category_column_index = 0
first_series_column_index = 1
first_data_row_index = 1

category_names = ["Category 1", "Category 2", "Category 3"]
series_values = [-20, 50, -30]

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(first_slide_index)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200)
    chart_data = chart.getChartData()
    workbook = chart_data.getChartDataWorkbook()

    chart_data.getSeries().clear()
    chart_data.getCategories().clear()

    series_name_cell = workbook.getCell(worksheet_index, header_row_index, first_series_column_index, "Series 1")
    chart_type = chart.getType()
    series = chart_data.getSeries().add(series_name_cell, chart_type)

    for category_index in range(len(category_names)):
        data_row_index = first_data_row_index + category_index
        category_name = category_names[category_index]
        series_value = series_values[category_index]

        category_cell = workbook.getCell(worksheet_index, data_row_index, category_column_index, category_name)
        chart_data.getCategories().add(category_cell)

        value_cell = workbook.getCell(worksheet_index, data_row_index, first_series_column_index, series_value)
        series.getDataPoints().addDataPointForBarSeries(value_cell)

    automatic_series_color = series.getAutomaticSeriesColor()
    series.getFormat().getFill().setFillType(FillType.Solid)
    series.getFormat().getFill().getSolidFillColor().setColor(automatic_series_color)
    series.setInvertIfNegative(True)
    series.getInvertedSolidFillColor().setColor(Color.RED)

    presentation.save("inverted_solid_fill_color.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

ผลลัพธ์:

![The inverted solid fill color](inverted_solid_fill_color.png)

คุณสามารถเปิดการกลับสีสำหรับจุดเดียวผ่าน [ChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapoint/#setInvertIfNegative) ในตัวอย่างต่อไปนี้ การกลับสีถูกปิดสำหรับชุดและเปิดเฉพาะจุดที่เลือก จุดนั้นยังถูกกำหนดค่าเป็นค่าติดลบเพื่อให้เห็นผล

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, FillType, Presentation, SaveFormat

Color = jpype.JClass("java.awt.Color")

first_slide_index = 0
first_series_index = 0
target_data_point_index = 2
negative_value = -30

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(first_slide_index)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200)

    series = chart.getChartData().getSeries().get_Item(first_series_index)
    automatic_series_color = series.getAutomaticSeriesColor()
    series.getFormat().getFill().setFillType(FillType.Solid)
    series.getFormat().getFill().getSolidFillColor().setColor(automatic_series_color)
    series.getInvertedSolidFillColor().setColor(Color.RED)
    series.setInvertIfNegative(False)

    data_point = series.getDataPoints().get_Item(target_data_point_index)
    data_point.getValue().getAsCell().setValue(negative_value)
    data_point.setInvertIfNegative(True)

    presentation.save("data_point_invert_color_if_negative.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **ล้างค่า Data Point เฉพาะ**

เพื่อทำให้จุดหนึ่งว่างโดยไม่ลบจุดอื่น ให้ตั้งค่าเซลล์ workbook ที่สนับสนุนจุดนั้นเป็น `None` สำหรับแผนภูมิคอลัมน์ ค่าที่พล็อตสามารถเข้าถึงได้ผ่าน [ChartDataPoint.getValue](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapoint/#getValue) จุดข้อมูลจะคงที่อยู่ในตำแหน่งหมวดหมู่เดียวกัน แต่แผนภูมิจะถือค่าว่างตามการกำหนดค่า blank‑value ของแผนภูมิ

ตัวอย่างต่อไปนี้ล้างเฉพาะจุดที่สองในชุดแรก

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

first_slide_index = 0
first_series_index = 0
target_data_point_index = 1

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(first_slide_index)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200)

    series = chart.getChartData().getSeries().get_Item(first_series_index)
    data_point = series.getDataPoints().get_Item(target_data_point_index)
    data_point.getValue().getAsCell().setValue(None)

    presentation.save("clear_data_point_value.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

แผนภูมิกระจายใช้เซลล์ X และ Y แยกกัน, แผนภูมิจุดฟองอากาศยังใช้เซลล์ขนาด ล้างเฉพาะเซลล์ที่แทนค่าที่ต้องการลบ อย่าเรียก [ChartDataPointCollection.clear](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapointcollection/#clear) เมื่อต้องการคงจุดอื่นไว้ เพราะเมธอดนั้นลบจุดทั้งหมดจากคอลเลกชัน

## **ควบคุมการแสดงผลของเซลล์ว่าง**

เซลล์ที่ซ่อนอยู่และมีค่าเป็นกรณีแยกจากเซลล์ว่าง เพื่อรวมหรือไม่รวมข้อมูลจากแถวและคอลัมน์ worksheet ที่ซ่อนไว้ ดู [Include Data from Hidden Rows and Columns](/slides/th/python-java/chart-workbook/#include-data-from-hidden-rows-and-columns)

เซลล์ workbook ที่ว่างแสดงข้อมูลที่หายไป; เซลล์ที่มีค่า `0` แสดงค่าตัวเลขที่รู้ เรียก [ChartDataCell.setValue](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatacell/#setValue) พร้อม `None` เพื่อทำให้เซลล์ว่าง ศูนย์ตัวเลขยังคงเป็นศูนย์ไม่ว่าการตั้งค่าเซลล์ว่างจะเป็นอย่างไร

ใช้ [Chart.setDisplayBlanksAs](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#setDisplayBlanksAs) เพื่อเลือกวิธีที่แผนภูมิแสดงเซลล์ว่าง การตั้งค่านี้ใช้กับแผนภูมิตลอดทั้งหมด มันเปลี่ยนวิธีการพล็อตช่องว่างโดยไม่เติมค่า 0 หรือค่าที่ประมวลผล

ตัวอย่างต่อไปนี้สร้างแผนภูมิเส้นเดียวที่มีชุดหนึ่ง, ล้างค่าของ Day 3, และบันทึกแผนภูมิเพื่อแต่ละโหมด ไม่ต้องใช้ไฟล์อินพุต [ChartDataWorkbook](https://reference.aspose.com/slides/python-java/aspose.slides/chartdataworkbook/) ใช้ worksheet 0, คอลัมน์ 0 สำหรับป้ายหมวดหมู่, คอลัมน์ 1 สำหรับค่า; แถว 0 เก็บชื่อชุด ค่าขั้นสุดท้ายคือ `10, 20, empty, 30, 40`

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, DisplayBlanksAsType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.LineWithMarkers, 40, 40, 640, 400)
    chart_data = chart.getChartData()
    workbook = chart_data.getChartDataWorkbook()

    chart_data.getSeries().clear()
    chart_data.getCategories().clear()

    series_name_cell = workbook.getCell(0, 0, 1, "Measurements")
    series = chart_data.getSeries().add(series_name_cell, chart.getType())
    values = [10, 20, 25, 30, 40]

    for i, value in enumerate(values):
        category_cell = workbook.getCell(0, i + 1, 0, f"Day {i + 1}")
        chart_data.getCategories().add(category_cell)
        value_cell = workbook.getCell(0, i + 1, 1, jpype.JInt(value))
        series.getDataPoints().addDataPointForLineSeries(value_cell)

    # ทำให้ Day 3 ว่างเปล่าจริง ๆ ในขณะที่ยังคงหมวดหมู่และจุดข้อมูลไว้
    workbook.getCell(0, 3, 1).setValue(None)

    modes = [DisplayBlanksAsType.Gap, DisplayBlanksAsType.Zero, DisplayBlanksAsType.Span]
    mode_names = ["Gap", "Zero", "Span"]
    for mode, mode_name in zip(modes, mode_names):
        chart.setDisplayBlanksAs(mode)
        presentation.save(f"empty_cells_{mode_name}.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

แต่ละไฟล์ผลลัพธ์บันทึกโหมดที่กำหนดก่อนบันทึก: `empty_cells_Gap.pptx`, `empty_cells_Zero.pptx`, และ `empty_cells_Span.pptx` หากต้องการบันทึกเวอร์ชันเดียว ให้กำหนดโหมดที่ต้องการและบันทึกงานนำเสนอครั้งเดียวแทนการวนลูปตามโหมด

การเปรียบเทียบด้านล่างแสดงข้อมูลเดียวกันในไฟล์ทั้งหมด Day 3 ว่างใน workbook ทุกกรณี

![Line charts with identical data: Gap breaks the line at Day 3, Zero drops the line to zero, and Span connects Day 2 to Day 4.](display_blanks_as.png)

ผลลัพธ์ที่มองเห็นขึ้นอยู่กับประเภทแผนภูมิ แผนภูมิเส้นทำให้โหมดทั้งสามเปรียบเทียบได้ง่าย แผนภูมิบาร์และคอลัมน์ไม่มีเส้นเชื่อมผ่านหมวดหมู่ที่หายไป ดังนั้น `Span` ไม่สามารถสร้างส่วนเชื่อมได้; คอลัมน์ที่หายไปและคอลัมน์ศูนย์อาจดูคล้ายกัน เช่นกัน แผนภูมิกระจายที่มีเครื่องหมายเท่านั้นไม่มีเส้นเชื่อม อย่าคาดหวังผลลัพธ์สามแบบที่แตกต่างกันสำหรับทุกประเภทแผนภูมิ; ตรวจสอบผลลัพธ์สำหรับประเภทที่คุณใช้

## **ตั้งค่า Gap Width ของชุดข้อมูล**

Gap width คือช่องว่างระหว่างกลุ่มบาร์หรือคอลัมน์ที่อยู่ติดกัน, แสดงเป็นเปอร์เซ็นต์ของความกว้างบาร์หรือคอลัมน์ เช่นเดียวกับ overlap, มันเป็นส่วนของกลุ่มชุดแม่ มากกว่าชุดเดี่ยว เรียก [ChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/#setGapWidth) ครั้งเดียวสำหรับกลุ่ม ค่ามากทำให้ระยะห่างระหว่างกลุ่มเพิ่ม, ค่าต่ำทำให้กลุ่มแน่นขึ้น

ตัวอย่างต่อไปนี้เปลี่ยน gap width แล้วบันทึกงานนำเสนอสุดท้ายเท่านั้น

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

first_slide_index = 0
first_series_index = 0
gap_width_percent = 30

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(first_slide_index)

    chart = slide.getShapes().addChart(ChartType.StackedColumn, 20, 20, 500, 200)

    series = chart.getChartData().getSeries().get_Item(first_series_index)
    series.getParentSeriesGroup().setGapWidth(gap_width_percent)

    presentation.save("gap_width_30.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

ผลลัพธ์:

![The gap width](gap_width.png)

## **แสดงหรือซ่อนเส้นชุดข้อมูล**

เส้นชุดข้อมูลเชื่อมต่อส่วนที่เกี่ยวข้องของแผนภูมิด้วยสายภาพ ใช้ [ChartSeriesGroup.setSeriesLines](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/#setSeriesLines) เพื่อแสดงหรือซ่อนในแผนภูมิ stacked bar และ OfPie ที่รองรับ ในแผนภูมิ stacked bar และ column สองมิติ เส้นเหล่านี้เชื่อมขอบของสแตกที่สอดคล้องกันข้ามหมวดหมู่ ใน Pie of Pie และ Bar of Pie เส้นเชื่อมแผนภูมิตามหลักกับแผนภูมิรอง การตั้งค้านี้ไม่ใช่ตัวเชื่อมทั่วไปสำหรับประเภทแผนภูมิอื่น

เข้าถึงกลุ่มผ่าน [ChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#getParentSeriesGroup) การตั้งค่านี้ใช้กับทุกชุดในกลุ่มนั้น [ChartSeries.hasSeriesLines](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#hasSeriesLines) อ่าน‑เท่านั้นและสะท้อนการตั้งค่ากลุ่มแม่; เรียก setter ของกลุ่มเพื่ออัปเดต

ตัวอย่างต่อไปนี้สร้างแผนภูมิ [PieOfPie](https://reference.aspose.com/slides/python-java/aspose.slides/charttype/#PieOfPie) หนึ่งอันด้วยข้อมูลเริ่มต้น บันทึกแผนภูมิเช่นเดียวกันโดยเปิดใช้งานเส้นชุดข้อมูลแล้วปิดใช้งานเพื่อสร้างงานนำเสนอสองไฟล์เปรียบเทียบ

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.PieOfPie, 50, 50, 600, 400)
    series = chart.getChartData().getSeries().get_Item(0)
    series_group = series.getParentSeriesGroup()

    series_group.setSeriesLines(True)
    presentation.save("series_lines_enabled.pptx", SaveFormat.Pptx)

    series_group.setSeriesLines(False)
    presentation.save("series_lines_disabled.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

| เปิดใช้งานเส้นชุดข้อมูล | ปิดใช้งานเส้นชุดข้อมูล |
| --- | --- |
| ![Pie of Pie chart with series lines enabled](series_lines_enabled.png) | ![Pie of Pie chart with series lines disabled](series_lines_disabled.png) |
| สองเส้นเชื่อมพายหลักกับพายรอง | พายทั้งสองยังคงมองเห็นได้ แต่เส้นเชื่อมถูกซ่อน |

เส้นชุดข้อมูลแตกต่างจาก leader line ของป้ายข้อมูล (เชื่อมป้ายกับจุดข้อมูล) , gridlines (ทำเครื่องหมายช่วงตามแกน) , และเส้นในแผนภูมิเส้น (แสดงค่า) การตั้งค่านี้ไม่ควบคุมองค์ประกอบเหล่านั้น

## **FAQ**

**แผนภูมิประเภทใดสนับสนุนชุดข้อมูล?**

แผนภูมิทุกประเภทที่แสดงโดย [ChartType](https://reference.aspose.com/slides/python-java/aspose.slides/charttype/) ใช้ข้อมูลแผนภูมิ, แต่ชุดข้อมูลของพวกมันไม่ทั้งหมดมีโครงสร้างหรือการตั้งค่าเดียวกัน เช่น แผนภูมิกลุ่มใช้ categories และ values, แผนภูมิกระจายใช้ X และ Y values, แผนภูมิจุดฟองอากาศเพิ่ม bubble sizes ใช้วิธีสร้าง data‑point ที่ตรงกับประเภทชุด ตัวเลือกเช่น overlap และ gap width ใช้กับกลุ่มบาร์หรือคอลัมน์ที่เข้ากันเท่านั้น

**ชุดข้อมูลกลุ่มคืออะไร?**

[ChartSeriesGroup](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/) ประกอบด้วยชุดที่เข้ากันซึ่งใช้การตั้งค่าการพล็อตระดับกลุ่ม แผนภูมิแบบผสมอาจมีหลายกลุ่ม, ดังนั้นการเปลี่ยนกลุ่มผ่านชุดหนึ่งอาจไม่เปลี่ยนทุกชุดในแผนภูมิ

**แผนภูมิที่สร้างใหม่มีข้อมูลเริ่มต้นหรือไม่?**

มี โดยค่าเริ่มต้น [ShapeCollection.addChart](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addChart) สร้างชุดตัวอย่าง, categories, และ values คุณสามารถแก้ไขเซลล์เหล่านั้นหรือทำความสะอาดทั้งชุดและคอลเลกชัน categories ก่อนเพิ่มชุดข้อมูลที่กำหนดเองโดยสมบูรณ์ ออเวอร์โหลดบางตัวยังสามารถสร้างแผนภูมิโดยไม่มีข้อมูลเริ่มต้น

**แผนภูมิเชื่อมต่อกับเซลล์ workbook อย่างไร?**

ชื่อชุด, ป้ายหมวดหมู่, และค่า data‑point อ้างอิงเซลล์ใน [ChartDataWorkbook](https://reference.aspose.com/slides/python-java/aspose.slides/chartdataworkbook/) การเปลี่ยนเซลล์ที่อ้างอิงจะอัปเดตองค์ประกอบแผนภูมิตรงกัน เมื่อสร้างข้อมูลแบบกำหนดเอง ให้คงแถว category และแถว series‑value ให้ตรงกันเพื่อให้แต่ละจุดพล็อตภายใต้หมวดหมู่ที่ตั้งใจ

**จะล้างจุดเดียวอย่างไรโดยไม่ลบชุดทั้งหมด?**

ตั้งค่าเซลล์ค่าที่เกี่ยวข้องเป็น `None` เพื่อรักษาตำแหน่งหมวดหมู่ของจุดเป็นจุดว่าง ใช้ [ChartDataPointCollection.clear](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapointcollection/#clear) เฉพาะเมื่อคุณต้องการลบจุดทั้งหมดจากชุด หากคุณลบ categories ด้วย ให้ปรับทุกชุดให้ค่าตรงกับคอลเลกชัน categories

**จุดว่างแสดงผลอย่างไร?**

ผลลัพธ์ขึ้นอยู่กับประเภทแผนภูมิและค่าที่กำหนดผ่าน [Chart.setDisplayBlanksAs](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#setDisplayBlanksAs) แผนภูมิที่รองรับสามารถแสดงช่องว่างเป็น gap, zero, หรือเชื่อมจุดใกล้เคียง เลือกการตั้งค่าที่สอดคล้องกับความหมายของข้อมูลที่หายไปในงานนำเสนอของคุณ ดู [Control the Display of Empty Cells](#control-the-display-of-empty-cells) สำหรับตัวอย่างเต็มและเปรียบเทียบภาพ

**ค่าติดลบถูกจัดรูปแบบอย่างไร?**

สำหรับชุดบาร์, คอลัมน์, และฟองอากาศที่รองรับ, เรียก [ChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#setInvertIfNegative) และตั้งค่าสีที่ [ChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#getInvertedSolidFillColor) คุณสามารถเขียนทับพฤติกรรมสำหรับจุดเดี่ยวด้วย [ChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapoint/#setInvertIfNegative) วิธีเหล่านี้ส่งผลต่อการจัดรูปแบบ, ไม่ใช่ค่าตัวเลขที่เก็บไว้

**เมื่อทั้งชุดและจุดถูกจัดรูปแบบ, การจัดรูปแบบใดชนะ?**

การจัดรูปแบบจุดโดยชัดเจนจะเหนือกว่าสำหรับจุดนั้น จุดอื่นจะใช้การจัดรูปแบบชุดที่ชัดเจนหรือ, หากชุดไม่ได้กำหนด, สไตล์และธีมอัตโนมัติของแผนภูมิ การตั้งค่ากลุ่มเช่น overlap และ gap width ควบคุมการจัดวางและไม่ใช่การเขียนทับระดับจุด

**แผนภูมิสามารถมีชุดได้สูงสุดกี่ชุด?**

Aspose.Slides ไม่ได้กำหนดขีดจำกัดจำนวนชุดแยกต่างหาก ในทางปฏิบัติ ข้อจำกัดจะมาจากข้อจำกัดของไฟล์การนำเสนอ, หน่วยความจำ, เวลาเรนเดอร์, และความอ่านง่ายของแผนภูมิ

**ควรเปลี่ยนอะไรเมื่อคอลัมน์ใกล้กันเกินไปหรือห่างกันมากเกินไป?**

เรียก [ChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/#setGapWidth) บนกลุ่มชุดแม่ที่เหมาะสม เพิ่มค่ากลายเป็นช่องว่างระหว่างคลัสเตอร์กว้างขึ้น, ลดค่ากลายเป็นคลัสเตอร์ใกล้กันมากขึ้น