---
title: จัดการชุดข้อมูลแผนภูมิในงานนำเสนอด้วย Python
linktitle: ชุดข้อมูล
type: docs
url: /th/python-java/chart-series/
keywords:
- ชุดข้อมูลแผนภูมิ
- การทับซ้อนของชุดข้อมูล
- สีของชุดข้อมูล
- ชื่อชุดข้อมูล
- จุดข้อมูล
- เซลล์ workbook
- ช่องว่างของชุดข้อมูล
- ค่าลบ
- PowerPoint
- งานนำเสนอ
- Python
- Java
- Aspose.Slides
description: "เรียนรู้วิธีจัดการชุดข้อมูลแผนภูมิ, จุดข้อมูล, เซลล์ workbook, การจัดรูปแบบ, การทับซ้อน, ความกว้างช่องว่าง, และค่าลบในงานนำเสนอด้วย Aspose.Slides สำหรับ Python ผ่าน Java."
---
## **ภาพรวม**

แผนภูมิสามารถจัดเก็บค่าที่พล็อตไว้ในเซลล์ของ workbook หรือโดยตรงเป็นค่าตัวเลขลิเทรัลได้ [ChartSeries](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/) แทนชุดค่าที่เกี่ยวข้องหนึ่งชุด และแต่ละ [ChartDataPoint](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapoint/) แทนจุดในชุดนั้น [ChartCategory](https://reference.aspose.com/slides/python-java/aspose.slides/chartcategory/) ให้ป้ายหรือค่าการจัดกลุ่มที่ใช้ร่วมกันระหว่างชุดข้อมูล ในแผนภูมิที่สร้างด้วยข้อมูลเริ่มต้น ชื่อชุดข้อมูล, หมวดหมู่, และค่าจุดจะใช้วัตถุ [ChartDataCell](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatacell/) จาก workbook ของแผนภูมิ

สำหรับแผนภูมิเบื้องต้นประเภทหมวดหมู่ workbook เริ่มต้นจะใช้แถว 0 สำหรับชื่อชุดข้อมูล, คอลัมน์ 0 สำหรับชื่อหมวดหมู่, และเซลล์ที่เหลือสำหรับค่าชุดข้อมูล ดัชนี worksheet, แถว, และคอลัมน์ที่ส่งไปยัง [ChartDataWorkbook.getCell](https://reference.aspose.com/slides/python-java/aspose.slides/chartdataworkbook/#getCell) จะเป็นค่าเริ่มต้นจากศูนย์ การจัดวางนี้มีประโยชน์เมื่อคุณสร้างแผนภูมิด้วยข้อมูลเริ่มต้น แต่ไม่ควรสันนิษฐานว่าทุกแผนภูมิที่มีอยู่ใช้แบบนี้ สำหรับการนำเสนอที่โหลดมาแล้ว ควรตรวจสอบเซลล์ที่ชุดข้อมูล, หมวดหมู่, และจุดข้อมูลอ้างอิงก่อนที่จะเปลี่ยนค่าของ workbook

การตั้งค่าแผนภูมิมีสามระดับต่างกัน:

- การตั้งค่าระดับชุดข้อมูล เช่น [ChartSeries.getFormat](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#getFormat) ให้ลักษณะเริ่มต้นสำหรับทุกจุดในชุดเดียว
- การตั้งค่าระดับจุดข้อมูล เช่น [ChartDataPoint.getFormat](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapoint/#getFormat) จะลบล้างลักษณะของชุดสำหรับจุดหนึ่ง
- การตั้งค่าระดับกลุ่มใช้กับชุดข้อมูลที่เข้ากันได้และอยู่ใน [ChartSeriesGroup](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/) เดียวกัน เข้าถึงกลุ่มผ่าน [ChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#getParentSeriesGroup) เมื่อคุณต้องการตั้งค่าต่าง ๆ เช่น การทับซ้อนหรือความกว้างช่องว่าง

เมื่อไม่มีการกำหนดการเติมสีจุดหรือชุดข้อมูลอย่างชัดเจน สไตล์และธีมของแผนภูมิจะกำหนดลักษณะอัตโนมัติ เมื่อทั้งการจัดรูปแบบของชุดและจุดมีอยู่ การจัดรูปแบบของจุดจะมีลำดับความสำคัญสำหรับจุดนั้น

![chart-series-powerpoint](chart-series-powerpoint.png)

## **ตั้งค่าค่าชุดข้อมูลโดยใช้ค่าตัวเลขลิเทรัล**

ใช้ค่าตัวเลขลิเทรัลเมื่อค่าชุดมาจากข้อมูลหรือการคำนวณของแอปพลิเคชันและไม่ต้องการอ้างอิงเซลล์ของ worksheet เรียก [setDataSourceTypeForValues](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapointcollection/#setDataSourceTypeForValues) พร้อมกับ [DataSourceType.DoubleLiterals](https://reference.aspose.com/slides/python-java/aspose.slides/datasourcetype/#DoubleLiterals) ก่อนกำหนดผลลัพธ์ของแต่ละจุดด้วย [getValue](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapoint/#getValue) ผ่าน [setAsLiteralDouble](https://reference.aspose.com/slides/python-java/aspose.slides/doublechartvalue/#setAsLiteralDouble)

การตั้งค่าคอลเลกชันควบคุมประเภทแหล่งข้อมูลของค่าจุดทั้งหมดในชุดนั้น วิธี [getDataSourceType](https://reference.aspose.com/slides/python-java/aspose.slides/basechartvalue/#getDataSourceType) ของแต่ละค่าจุดจะรายงานประเภทที่เลือก; เปลี่ยนได้ผ่านการตั้งค่าคอลเลกชัน ด้วย `Worksheet` ใช้ [getAsCell](https://reference.aspose.com/slides/python-java/aspose.slides/doublechartvalue/#getAsCell) เพื่อเข้าถึงเซลล์ที่อ้างอิง ด้วย `DoubleLiterals` ใช้ [getAsLiteralDouble](https://reference.aspose.com/slides/python-java/aspose.slides/doublechartvalue/#getAsLiteralDouble) หรือ `setAsLiteralDouble` เพื่ออ่านหรือเขียนตัวเลขโดยตรง

ตัวอย่างต่อไปนี้สร้างแผนภูมิคอลัมน์ด้วยชุดและหมวดหมู่เริ่มต้น แล้วกำหนดค่าที่คำนวณได้ 10, 20, ฯลฯ ให้กับจุดที่มีอยู่ของชุดแรก บันทึกการนำเสนอ, เปิดใหม่อีกครั้ง, และพิมพ์ค่าที่จัดเก็บ

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

ประเภทแหล่งค่าจุดแยกจาก [ChartData.getDataSourceType](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#getDataSourceType) ซึ่งระบุการกำหนดค่า workbook ภายในหรือภายนอกของแผนภูมิ การใช้ค่าตัวเลขลิเทรัลโดยตัวมันเองไม่ได้ลบ workbook ที่ฝังอยู่ ตัวอย่างนี้ workbook ยังคงพร้อมใช้งานสำหรับป้ายหมวดหมู่, ชื่อชุด, และชุดอื่น ๆ ดูที่ [Workbook ของแผนภูมิ](/slides/th/python-java/chart-workbook/) เพื่อการจัดการ workbook

สำหรับแผนภูมิ scatter และ bubble ใช้ [setDataSourceTypeForXValues](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapointcollection/#setDataSourceTypeForXValues) และ [setDataSourceTypeForYValues](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapointcollection/#setDataSourceTypeForYValues) เพื่อเลือกแหล่งข้อมูลสำหรับ [getXValue](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapoint/#getXValue) และ [getYValue](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapoint/#getYValue) แผนภูมิ bubble ยังใช้ [setDataSourceTypeForBubbleSizes](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapointcollection/#setDataSourceTypeForBubbleSizes) สำหรับ [getBubbleSize](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapoint/#getBubbleSize) ตั้งค่าแหล่งที่เหมาะสมแต่ละอย่างเป็น `DoubleLiterals` ก่อนกำหนดตัวเลขผ่านเมธอด `setAsLiteralDouble` ของค่าดังกล่าว

## **ตั้งค่าการทับซ้อนของชุดข้อมูลในแผนภูมิ**

[ChartSeries.getOverlap](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#getOverlap) รายงานว่าบาร์หรือคอลัมน์ทับซ้อนกันมากเท่าใดในแผนภูมิ 2D, จาก -100 ถึง 100 เปอร์เซ็นต์ เป็นการฉายภาพแบบอ่านอย่างเดียวของการตั้งค่าที่กลุ่มชุดแม่ ใช้ [ChartSeriesGroup.setOverlap](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/#setOverlap) เพื่ออัปเดตทุกชุดข้อมูลที่เข้ากันได้ในกลุ่มนั้น ตัวเลือกนี้ใช้กับประเภทแผนภูมิที่แสดงบาร์หรือคอลัมน์เป็นกลุ่ม; จะไม่กระทบกับกลุ่มชุดข้อมูลที่ไม่เกี่ยวข้องในแผนภูมิแบบผสม

ตัวอย่างต่อไปนี้ตั้งค่าการทับซ้อนสำหรับกลุ่มที่บรรจุชุดแรก:

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

    # แผนภูมิใหม่ประกอบด้วยชุดตัวอย่าง, หมวดหมู่, และค่า.
    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200)

    series = chart.getChartData().getSeries().get_Item(first_series_index)
    series.getParentSeriesGroup().setOverlap(overlap_percent)

    presentation.save("series_overlap.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

ผลลัพธ์:

![The series overlap](series_overlap.png)

## **เปลี่ยนสีพื้นหลังของชุดข้อมูล**

ใช้ [ChartSeries.getFormat](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#getFormat) เพื่อกำหนดการเติมสีเริ่มต้นสำหรับชุดทั้งหมด หากจุดใดจุดหนึ่งมีการเติมสีที่ระบุไว้แล้ว การตั้งค่า [ChartDataPoint.getFormat](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapoint/#getFormat) จะลบล้างการเติมสีของชุดสำหรับจุดนั้น

ตัวอย่างต่อไปนี้ใช้การเติมสีฟ้าเข้มแบบทึบกับชุดแรก:

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

## **เปลี่ยนชื่อชุดข้อมูล**

ชื่อชุดข้อมูลถูกจัดเก็บใน workbook ของข้อมูลแผนภูมิและโดยปกติจะแสดงในคำอธิบาย legend ใน workbook เริ่มต้นที่สร้างสำหรับแผนภูมิคอลัมน์แบบคลัสเตอร์ เซลล์ B1 อยู่ที่แถว 0, คอลัมน์ 1 และบรรจุชื่อของชุดแรก ตัวแปรที่ตั้งชื่อในตัวอย่างต่อไปนี้ทำให้โครงสร้างนั้นชัดเจน:

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

คุณยังสามารถอัปเดตเซลล์ที่ [ChartSeries.getName](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#getName) อ้างอิงอยู่แล้ว วิธีนี้หลีกเลี่ยงการสันนิษฐานว่าแถวและคอลัมน์เป็นค่าที่แน่นอนในแผนภูมิที่มีอยู่:

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

ชื่อชุดข้อมูลแบบคอมโพสิตมีประโยชน์เมื่อชื่อสินค้าและช่วงเวลารายงานถูกเก็บในเซลล์ workbook แยกกัน ตัวอย่างเช่น คุณสามารถผสาน `Product A` ใน B1 และ `2026` ใน C1 ให้เป็นชื่อชุดเดียวในขณะยังคงเชื่อมโยงทั้งสองส่วนกับเซลล์ต้นทางของมัน

ใช้ [ChartDataWorkbook.getCellCollection](https://reference.aspose.com/slides/python-java/aspose.slides/chartdataworkbook/#getCellCollection) เพื่อดึงช่วงชื่อ แล้วส่งคอลเลกชันนั้นไปยัง [ChartSeriesCollection.add](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriescollection/#add) ค่าพารามิเตอร์ `skipHiddenCells` ควบคุมว่าจะรวมเซลล์ที่ซ่อนอยู่หรือไม่: `True` จะไม่รวม, `False` จะรวม ตัวอย่างนี้ใช้ `False` เพื่อรวมทุกเซลล์ในช่วงชื่อ

ตัวอย่างต่อไปนี้สร้างการนำเสนอที่มีหนึ่งชุดและสองจุดข้อมูล เซลล์ B1:C1 ให้ชื่อชุดเท่านั้น; A2:A3 ให้ป้ายหมวดหมู่, และ B2:B3 ให้ค่าตัวเลข

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

    # เซลล์สองเซลล์นี้จัดหาให้กับชื่อชุดข้อมูล.
    workbook.getCell(0, 0, 1, "Product A")
    workbook.getCell(0, 0, 2, "2026")
    name_cells = workbook.getCellCollection("Sheet1!$B$1:$C$1", False)
    series = chart.getChartData().getSeries().add(name_cells, ChartType.ClusteredColumn)

    # เซลล์แยกกันจัดหาหมวดหมู่และจุดข้อมูลเชิงตัวเลข.
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

ชื่อชุดที่ได้คือ `Product A 2026` โดยมีช่องว่างระหว่างค่าจากสองเซลล์ legend จะแสดงเป็นรายการเดียวสำหรับทั้งสองคอลัมน์ ภาพด้านล่างแสดงผลลัพธ์:

![Column chart with North and South values and the composite series name Product A 2026 in the legend](composite_series_name.png)

## **รับสีพื้นหลังอัตโนมัติของชุดข้อมูล**

[ChartSeries.getAutomaticSeriesColor](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#getAutomaticSeriesColor) คืนค่าสีที่คำนวนจากดัชนีชุดและสไตล์ของแผนภูมิ นี่คือสีที่ใช้เมื่อการเติมสีของชุดไม่ได้ถูกกำหนดอย่างชัดเจน การเรียกเมธอดจะอ่านสีที่คำนวนได้; ไม่ได้กำหนดการเติมสีใหม่

ตัวอย่างต่อไปนี้พิมพ์สีอัตโนมัติของแต่ละชุดเริ่มต้น:

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

ผลลัพธ์ตัวอย่างสำหรับสไตล์แผนภูมิเริ่มต้น:

```text
Series 0: java.awt.Color[r=79,g=129,b=189]
Series 1: java.awt.Color[r=192,g=80,b=77]
Series 2: java.awt.Color[r=155,g=187,b=89]
```

สีที่แน่นอนขึ้นอยู่กับสไตล์และธีมของแผนภูมิ

## **ตั้งค่าสีพื้นหลังย้อนกลับสำหรับชุดข้อมูลในแผนภูมิ**

สำหรับชุดข้อมูลประเภทบาร์, คอลัมน์, และ bubble, [ChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#setInvertIfNegative) สามารถแสดงค่าลบด้วยการเติมสีที่ต่างออกไป ตั้งค่าการเติมสีของชุดให้เป็นแบบทึบ, เปิดใช้งานการย้อนกลับ, แล้วกำหนดสีค่าลบผ่าน [ChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#getInvertedSolidFillColor) ตัวเลขลบจะคงเดิมใน workbook; เพียงสีการแสดงผลที่เปลี่ยน

ตัวอย่างต่อไปนี้แทนที่ข้อมูลแผนภูมิเริ่มต้นด้วยชุดเดียว แถว worksheet 0 มีชื่อชุด, คอลัมน์ 0 มีชื่อหมวดหมู่, และคอลัมน์ 1 มีค่าต่าง ๆ:

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

คุณสามารถเปิดการย้อนกลับสำหรับจุดเดียวผ่าน [ChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapoint/#setInvertIfNegative) ในตัวอย่างต่อไปนี้ การย้อนกลับถูกปิดสำหรับชุดและเปิดเฉพาะสำหรับจุดที่เลือก จุดนั้นยังถูกกำหนดให้เป็นค่าลบเพื่อให้เห็นผล:

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

## **ล้างค่าจุดข้อมูลเฉพาะ**

เพื่อให้จุดหนึ่งเป็นค่าว่างโดยไม่ลบจุดอื่น ๆ ให้ตั้งค่าเซลล์ workbook ที่รองรับเป็น `None` สำหรับแผนภูมิคอลัมน์ ค่าที่พล็อตได้สามารถเข้าถึงได้ผ่าน [ChartDataPoint.getValue](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapoint/#getValue) จุดข้อมูลจะอยู่ในตำแหน่งหมวดหมู่เดียวกัน แต่แผนภูมิจะถือว่าค่าของมันเป็นค่าว่างตามการตั้งค่าค่าว่างของแผนภูมิ

ตัวอย่างต่อไปนี้ล้างเฉพาะจุดที่สองในชุดแรก:

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

แผนภูมิ scatter ใช้เซลล์ X และ Y แยกกัน, และแผนภูมิ bubble ยังใช้เซลล์ขนาดด้วย ให้ลบเฉพาะเซลล์ที่เป็นค่าที่คุณต้องการลบ อย่าเรียก [ChartDataPointCollection.clear](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapointcollection/#clear) เมื่อคุณต้องการเก็บจุดอื่นไว้ เพราะเมธอดนั้นจะลบทุกจุดจากคอลเลกชัน

## **ควบคุมการแสดงผลของเซลล์ว่าง**

เซลล์ที่ซ่อนอยู่และมีค่าเป็นกรณีแยกจากเซลล์ว่าง เพื่อรวมหรือแยกข้อมูลจากแถวและคอลัมน์ที่ซ่อนอยู่ ดูที่ [รวมข้อมูลจากแถวและคอลัมน์ที่ซ่อนอยู่](/slides/th/python-java/chart-workbook/#include-data-from-hidden-rows-and-columns)

เซลล์ workbook ว่างแสดงถึงข้อมูลที่หายไป; เซลล์ที่มีค่า `0` แสดงถึงค่าตัวเลขที่ทราบ เรียก [ChartDataCell.setValue](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatacell/#setValue) ด้วย `None` เพื่อทำให้เซลล์เป็นค่าว่าง ตัวเลขศูนย์จะคงเป็นศูนย์ไม่ว่า setting ของเซลล์ว่างจะเป็นอย่างไร

ใช้ [Chart.setDisplayBlanksAs](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#setDisplayBlanksAs) เพื่อเลือกว่าจะให้แผนภูมิแสดงเซลล์ว่างอย่างไร การตั้งค่านี้ใช้กับแผนภูมิทั้งหมด เปลี่ยนวิธีที่ค่าว่างถูกพล็อต โดยไม่เติมค่า `0` หรือค่าที่ประมาณลงในเซลล์ workbook ที่ว่าง

ตัวอย่างต่อไปนี้เป็นตัวอย่างครบวงจรที่สร้างแผนภูมิเส้นหนึ่งชุด, ล้างค่าของ Day 3, และบันทึกแผนภูมิเดียวกันในแต่ละโหมด ไม่ต้องใช้ไฟล์อินพุต [ChartDataWorkbook](https://reference.aspose.com/slides/python-java/aspose.slides/chartdataworkbook/) ใช้ worksheet 0, คอลัมน์ 0 สำหรับป้ายหมวดหมู่, และคอลัมน์ 1 สำหรับค่า; แถว 0 เก็บชื่อชุด ข้อมูลสุดท้ายคือ `10, 20, empty, 30, 40`

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

    # ปล่อยให้ Day 3 ว่างจริง ๆ ในขณะที่ยังคงหมวดหมู่และจุดข้อมูลไว้.
    workbook.getCell(0, 3, 1).setValue(None)

    modes = [DisplayBlanksAsType.Gap, DisplayBlanksAsType.Zero, DisplayBlanksAsType.Span]
    mode_names = ["Gap", "Zero", "Span"]
    for mode, mode_name in zip(modes, mode_names):
        chart.setDisplayBlanksAs(mode)
        presentation.save(f"empty_cells_{mode_name}.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

แต่ละไฟล์ผลลัพธ์บันทึกโหมดที่กำหนดก่อนบันทึก: `empty_cells_Gap.pptx`, `empty_cells_Zero.pptx`, และ `empty_cells_Span.pptx` เพื่อบันทึกเวอร์ชันเดียว ให้กำหนดโหมดที่ต้องการและบันทึกการนำเสนอครั้งเดียวแทนการวนลูปผ่านโหมดต่าง ๆ

การเปรียบเทียบด้านล่างแสดงข้อมูลเดียวกันในทั้งสามไฟล์ Day 3 เป็นค่าว่างใน workbook ทุกกรณี:

![แผนภูมิเส้นที่มีข้อมูลเดียวกัน: Gap ทำให้เส้นขาดหายที่ Day 3, Zero ทำให้เส้นลดลงเป็นศูนย์, และ Span เชื่อม Day 2 ไปยัง Day 4.](display_blanks_as.png)

ผลกระทบที่มองเห็นได้ขึ้นอยู่กับประเภทแผนภูมิ แผนภูมิเส้นทำให้สามโหมดเปรียบเทียบได้ง่าย แผนภูมิแบบบาร์และคอลัมน์ไม่มีเส้นเชื่อมข้ามหมวดหมู่ที่หายไป ดังนั้น `Span` ไม่สามารถสร้างส่วนเชื่อมที่แสดงในภาพได้; คอลัมน์ที่หายไปและคอลัมน์ที่สูงศูนย์อาจดูคล้ายกันเช่นกัน ในทำนองเดียวกัน แผนภูมิ scatter ที่มีเพียงมาร์คเกอร์ไม่มีเส้นเชื่อม อย่าคาดหวังผลลัพธ์ที่แตกต่างกันสามแบบสำหรับทุกประเภทแผนภูมิ; ตรวจสอบผลลัพธ์สำหรับประเภทที่คุณใช้

## **ตั้งค่าความกว้างช่องว่างของชุดข้อมูล**

ความกว้างช่องว่างคือช่องว่างระหว่างกลุ่มบาร์หรือคอลัมน์ที่อยู่ติดกัน แสดงเป็นเปอร์เซ็นต์ของความกว้างบาร์หรือคอลัมน์ เช่นเดียวกับการทับซ้อน มันเป็นของกลุ่มชุดแม่ไม่ใช่ของชุดเดียว เรียก [ChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/#setGapWidth) ครั้งเดียวสำหรับกลุ่ม ค่าใหญ่จะสร้างช่องว่างระหว่างกลุ่มมากขึ้น, ค่าเล็กจะทำให้กลุ่มแน่นขึ้น

ตัวอย่างต่อไปนี้เปลี่ยนความกว้างช่องว่างและบันทึกการนำเสนอสุดท้ายเท่านั้น:

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

## **คำถามที่พบบ่อย**

**แผนภูมิประเภทใดสนับสนุนชุดข้อมูล?**

ทุกประเภทแผนภูมิที่ระบุโดย enumeration [ChartType](https://reference.aspose.com/slides/python-java/aspose.slides/charttype/) ใช้ข้อมูลแผนภูมิ, แต่ชุดข้อมูลของแต่ละประเภทอาจมีโครงสร้างค่าและการตั้งค่าที่แตกต่างกัน เช่น แผนภูมิจัดประเภทใช้หมวดหมู่และค่า, แผนภูมิ scatter ใช้ค่า X และ Y, แผนภูมิ bubble เพิ่มขนาดบับเบิล ใช้วิธีสร้างจุดข้อมูลที่สอดคล้องกับประเภทชุด ค่าตัวเลือกเช่น การทับซ้อนและความกว้างช่องว่างใช้ได้เฉพาะกลุ่มบาร์หรือคอลัมน์ที่เข้ากัน

**กลุ่มชุดข้อมูลในแผนภูมิคืออะไร?**

[ChartSeriesGroup](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/) มีชุดข้อมูลที่เข้ากันได้ซึ่งใช้การตั้งค่าการพล็อตระดับกลุ่ม แผนภูมิแบบผสมอาจมีมากกว่าหนึ่งกลุ่ม ดังนั้นการเปลี่ยนแปลงกลุ่มผ่านชุดข้อมูลหนึ่งไม่จำเป็นต้องเปลี่ยนแปลงทุกชุดในแผนภูมิ

**แผนภูมิที่สร้างใหม่มีข้อมูลเริ่มต้นหรือไม่?**

มี. โดยค่าเริ่มต้น [ShapeCollection.addChart](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addChart) จะสร้างชุดตัวอย่าง, หมวดหมู่, และค่า คุณสามารถแก้ไขเซลล์เหล่านั้นหรือเคลียร์ทั้งชุดและคอลเลกชันหมวดหมู่ก่อนเพิ่มชุดข้อมูลที่กำหนดเองอย่างสมบูรณ์ การ overload ยังสามารถสร้างแผนภูมิโดยไม่มีข้อมูลเริ่มต้นได้

**วัตถุแผนภูมิเชื่อมต่อกับเซลล์ workbook อย่างไร?**

ชื่อชุด, ป้ายหมวดหมู่, และค่าจุดข้อมูลอ้างอิงเซลล์ใน [ChartDataWorkbook](https://reference.aspose.com/slides/python-java/aspose.slides/chartdataworkbook/) การเปลี่ยนเซลล์ที่อ้างอิงจะอัปเดตองค์ประกอบแผนภูมที่สอดคล้องกัน เมื่อคุณสร้างข้อมูลกำหนดเอง ให้จัดแถวหมวดหมู่และแถวค่าชุดให้สอดคล้องกันเพื่อให้แต่ละจุดพล็อตภายใต้หมวดหมู่ที่ตั้งใจ

**จะล้างจุดเดียวโดยไม่ลบชุดทั้งหมดอย่างไร?**

ตั้งค่าเซลล์ค่าที่เกี่ยวข้องเป็น `None` เพื่อรักษาตำแหน่งหมวดหมู่ของจุดเป็นจุดว่าง ใช้ [ChartDataPointCollection.clear](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapointcollection/#clear) เฉพาะเมื่อคุณต้องการลบทุกจุดจากชุดนั้น หากคุณลบหมวดหมู่ด้วย, ให้อัปเดตทุกชุดเพื่อให้ค่าของพวกมันยังคงสอดคล้องกับคอลเลกชันหมวดหมู่

**จุดที่ว่างแสดงอย่างไร?**

ผลลัพธ์ขึ้นอยู่กับประเภทแผนภูมิและค่าที่ตั้งค่าโดย [Chart.setDisplayBlanksAs](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#setDisplayBlanksAs) แผนภูมิที่รองรับสามารถแสดงค่าว่างเป็นช่องว่าง, ค่าเป็นศูนย์, หรือโดยการเชื่อมต่อจุดใกล้เคียง เลือกการตั้งค่าที่สอดคล้องกับความหมายของข้อมูลที่หายไปในงานนำเสนอของคุณ ดูที่ [ควบคุมการแสดงผลของเซลล์ว่าง](#control-the-display-of-empty-cells) เพื่อดูตัวอย่างเต็มและการเปรียบเทียบภาพ

**ค่าจากลบจะถูกจัดรูปแบบอย่างไร?**

สำหรับชุดบาร์, คอลัมน์, และ bubble ที่รองรับ ให้เรียก [ChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#setInvertIfNegative) แล้วตั้งค่าสีที่ได้จาก [ChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#getInvertedSolidFillColor) คุณสามารถลบล้างพฤติกรรมสำหรับจุดเดี่ยวด้วย [ChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapoint/#setInvertIfNegative) วิธีเหล่านี้ส่งผลต่อการจัดรูปแบบ, ไม่ได้เปลี่ยนค่าตัวเลขที่เก็บ

**เมื่อทั้งชุดและจุดถูกจัดรูปแบบ, การจัดรูปแบบใดมีความเหนือกว่า?**

การจัดรูปแบบจุดข้อมูลโดยเฉพาะจะมีลำดับความสำคัญสำหรับจุดนั้น จุดอื่น ๆ จะใช้การจัดรูปแบบของชุดที่ระบุไว้หรือถ้าชุดไม่ได้กำหนด จะใช้สไตล์และธีมของแผนภูมิโดยอัตโนมัติ การตั้งค่ากลุ่มเช่น การทับซ้อนและความกว้างช่องว่างควบคุมการวางตำแหน่งและไม่ใช่การลบการจัดรูปแบบระดับจุด

**แผนภูมิสามารถมีชุดข้อมูลได้กี่ชุด?**

Aspose.Slides ไม่กำหนดขีดจำกัดจำนวนชุดข้อมูลแยกต่างหาก ในทางปฏิบัติ ข้อจำกัดจะขึ้นกับขนาดไฟล์การนำเสนอ, หน่วยความจำที่มี, เวลาในการเรนเดอร์, และความอ่านง่ายของแผนภูมิ

**ควรทำอย่างไรเมื่อคอลัมน์ใกล้กันเกินไปหรือห่างกันเกินไป?**

เรียก [ChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/#setGapWidth) บนกลุ่มชุดแม่ที่เหมาะสม เพิ่มค่าจะทำให้ช่องว่างระหว่างกลุ่มกว้างขึ้น, ลดค่าจะทำให้กลุ่มใกล้กันขึ้น.