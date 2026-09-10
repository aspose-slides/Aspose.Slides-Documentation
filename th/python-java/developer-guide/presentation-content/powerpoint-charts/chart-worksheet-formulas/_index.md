---
title: ใช้สูตร Worksheet ของแผนภูมิในงานนำเสนอด้วย Python ผ่าน Java
linktitle: สูตร Worksheet
type: docs
weight: 70
url: /th/python-java/chart-worksheet-formulas/
keywords:
- แผนภูมิสเปรดชีท
- worksheet ของแผนภูมิ
- สูตรแผนภูมิ
- สูตร worksheet
- สูตรสเปรดชีท
- workbook ข้อมูลแผนภูมิ
- การคำนวนสูตร
- วัฒนธรรมที่ต้องการ
- สูตรที่กำหนดโดยวัฒนธรรม
- DBCS
- ค่าคงที่ตรรกะ
- ค่าคงที่เชิงตัวเลข
- ค่าคงที่สตริง
- ค่าคงที่ข้อผิดพลาด
- ตัวดำเนินการคณิตศาสตร์
- ตัวดำเนินการเปรียบเทียบ
- สไตล์ A1
- สไตล์ R1C1
- ฟังก์ชันที่กำหนดล่วงหน้า
- PowerPoint
- งานนำเสนอ
- Python
- Java
- Aspose.Slides
description: "ใช้สูตรแบบ Excel ใน Aspose.Slides สำหรับ Python ผ่าน Java บน worksheet ของแผนภูมิ, คำนวนค่าใหม่, และใช้ผลลัพธ์ในแผนภูมิ PowerPoint."
---
## **ภาพรวม**

แผนภูมิ PowerPoint ส่วนใหญ่จะจัดเก็บข้อมูลต้นทางไว้ในเวิร์กชีทที่ฝังอยู่ภายใน ใน Aspose.Slides for Python via Java คุณสามารถเข้าถึงเวิร์กชีทนั้นผ่าน chart data workbook, เขียนค่าตรงเข้า, กำหนดสูตรให้กับเซลล์, คำนวณสูตรที่รองรับ, และใช้เซลล์ที่คำนวณแล้วเป็นข้อมูลสำหรับแผนภูมิ

บทความนี้อธิบายขั้นตอนการทำงานของสูตรอย่างครบถ้วน: สร้างแผนภูมิ, เติมข้อมูลในเวิร์กชีท, กำหนดสูตรแบบ A1 หรือ R1C1, คำนวณสูตรใหม่, อ่านค่าที่คำนวณ, เชื่อมต่อเซลล์เหล่านั้นกับซีรีส์ของแผนภูมิ, และบันทึกงานนำเสนอ นอกจากนี้ยังอธิบายไวยากรณ์สูตรที่รองรับ, ชุดฟังก์ชันในตัว, ค่าที่แคชไว้, สูตรที่ไม่ได้รองรับ, และข้อผิดพลาดเฉพาะสเปรดชีท

## **แผนภูมิ Worksheet และสูตร**

แผนภูมิ worksheet จะบรรจุประเภท, ชื่อซีรีส์, และค่าที่แผนภูมิใช้ ใน PowerPoint คุณสามารถตรวจสอบ worksheet ได้โดยเปิด chart data editor:

![PowerPoint chart with its embedded worksheet open, showing category and series data](chart-worksheet-formulas_1.png)

ใน Aspose.Slides worksheet จะถูกเปิดเผยผ่านคลาส [ChartDataWorkbook](https://reference.aspose.com/slides/th/python-java/aspose.slides/chartdataworkbook/) ใช้เมธอด [ChartDataCell.setFormula](https://reference.aspose.com/slides/th/python-java/aspose.slides/chartdatacell/#setFormula) สำหรับสูตรแบบ A1 และ [ChartDataCell.setR1C1Formula](https://reference.aspose.com/slides/th/python-java/aspose.slides/chartdatacell/#setR1C1Formula) สำหรับสูตรแบบ R1C1 หลังจากเปลี่ยนค่าเซลล์หรือสูตร ให้เรียก [ChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/th/python-java/aspose.slides/chartdataworkbook/#calculateFormulas) เพื่อคำนวณสูตรที่รองรับและอัปเดตค่าของเซลล์ที่เกี่ยวข้อง

เซลล์ที่คำนวณแล้วยังคงเปิดเผยผลลัพธ์ผ่าน [ChartDataCell.getValue](https://reference.aspose.com/slides/th/python-java/aspose.slides/chartdatacell/#getValue) สิ่งนี้สำคัญเมื่อคุณต้องการตรวจสอบผลลัพธ์ของสูตรในโค้ดหรือใช้เซลล์เป็นจุดข้อมูลของแผนภูมิ

## **สร้างแผนภูมิและคำนวณสูตรใน Worksheet**

ตัวอย่างต่อไปนี้แสดงขั้นตอนทำงานจากต้นจนจบ มันสร้างแผนภูมิคอลัมน์แบบกลุ่ม, ลบข้อมูลตัวอย่าง, เขียนค่ารายได้และค่าใช้จ่ายรายไตรมาส, คำนวณกำไรด้วยสูตร, อ่านผลลัพธ์, ใช้เซลล์ที่คำนวณแล้วเป็นค่าแผนภูมิ, และบันทึกงานนำเสนอ

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 350)
    workbook = chart.getChartData().getChartDataWorkbook()
    worksheet_index = 0

    chart.getChartData().getSeries().clear()
    chart.getChartData().getCategories().clear()
    workbook.clear(worksheet_index)

    category1 = workbook.getCell(worksheet_index, "A2", "Q1")
    category2 = workbook.getCell(worksheet_index, "A3", "Q2")
    category3 = workbook.getCell(worksheet_index, "A4", "Q3")

    workbook.getCell(worksheet_index, "B1", "Revenue")
    workbook.getCell(worksheet_index, "C1", "Expenses")
    workbook.getCell(worksheet_index, "D1", "Profit")

    workbook.getCell(worksheet_index, "B2").setValue(120.0)
    workbook.getCell(worksheet_index, "C2").setValue(80.0)
    workbook.getCell(worksheet_index, "B3").setValue(150.0)
    workbook.getCell(worksheet_index, "C3").setValue(95.0)
    workbook.getCell(worksheet_index, "B4").setValue(135.0)
    workbook.getCell(worksheet_index, "C4").setValue(110.0)

    profit1 = workbook.getCell(worksheet_index, "D2")
    profit2 = workbook.getCell(worksheet_index, "D3")
    profit3 = workbook.getCell(worksheet_index, "D4")

    profit1.setFormula("B2-C2")
    profit2.setFormula("B3-C3")
    profit3.setFormula("B4-C4")

    workbook.calculateFormulas()

    q1_profit = float(profit1.getValue()) # 40
    q2_profit = float(profit2.getValue()) # 55
    q3_profit = float(profit3.getValue()) # 25

    print("Q1 profit: ", q1_profit)
    print("Q2 profit: ", q2_profit)
    print("Q3 profit: ", q3_profit)

    chart.getChartData().getCategories().add(category1)
    chart.getChartData().getCategories().add(category2)
    chart.getChartData().getCategories().add(category3)

    profit_series = chart.getChartData().getSeries().add(workbook.getCell(worksheet_index, "D1"), chart.getType())
    profit_series.getDataPoints().addDataPointForBarSeries(profit1)
    profit_series.getDataPoints().addDataPointForBarSeries(profit2)
    profit_series.getDataPoints().addDataPointForBarSeries(profit3)
    profit_series.getLabels().getDefaultDataLabelFormat().setShowValue(True)

    presentation.save("chart-formulas.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

จุดข้อมูลของแผนภูมิมีการอ้างอิง `D2:D4` ดังนั้นแผนภูมิจะใช้ค่ากำไรที่คำนวณได้ ไม่มีการเรียกเมธอดรีเฟรชแผนภูมิแยกต่างหากในขั้นตอนนี้: คำนวณเวิร์กชีทก่อน, แล้วจึงใช้หรือบันทึกข้อมูลแผนภูมิที่อ้างอิงเซลล์ที่คำนวณแล้ว

## **ใช้สูตรแบบ A1**

รูปแบบ A1 ระบุคอลัมน์ด้วยอักษรและแถวด้วยตัวเลข กำหนดนิพจน์แบบ A1 ผ่าน [ChartDataCell.setFormula](https://reference.aspose.com/slides/th/python-java/aspose.slides/chartdatacell/#setFormula)

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 500, 300)
    workbook = chart.getChartData().getChartDataWorkbook()

    workbook.getCell(0, "C3").setValue(10)
    workbook.getCell(0, "F2").setValue(2)
    workbook.getCell(0, "G2").setValue(3)
    workbook.getCell(0, "H2").setValue(4)

    cell = workbook.getCell(0, "A2")
    cell.setFormula("C3+SUM(F2:H2)")

    workbook.calculateFormulas()

    value = cell.getValue() # 19
finally:
    presentation.dispose()
```

รูปแบบการอ้างอิง A1 ที่พบบ่อยคือ:

| อ้างอิง | เชิงสัมพัทธ์ | แน่นอน | ผสม |
|---|---|---|---|
| เซลล์ | `A2` | `$A$2` | `A$2`, `$A2` |
| แถว | `2:2` | `$2:$2` | — |
| คอลัมน์ | `A:A` | `$A:$A` | — |
| ช่วง | `A2:C4` | `$A$2:$C$4` | `A$2:$C4`, `$A2:C$4` |

การอ้างอิงเชิงสัมพัทธ์อาจเปลี่ยนเมื่อสูตรถูกย้ายหรือคัดลอกโดยแอปพลิเคชันสเปรดชีท การอ้างอิงแน่นอนจะตรึงพิกัดทั้งสอง, ส่วนการอ้างอิงผสมจะตรึงแค่แถวหรือคอลัมน์หนึ่งเท่านั้น

## **ใช้สูตรแบบ R1C1**

รูปแบบ R1C1 ระบุทั้งแถวและคอลัมน์ด้วยตัวเลข การอ้างอิงเชิงสัมพัทธ์ใช้การออฟเซตในวงเล็บเหลี่ยม กำหนดไวยากรณ์นี้ผ่าน [ChartDataCell.setR1C1Formula](https://reference.aspose.com/slides/th/python-java/aspose.slides/chartdatacell/#setR1C1Formula)

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 500, 300)
    workbook = chart.getChartData().getChartDataWorkbook()

    workbook.getCell(0, "B2").setValue(12)
    workbook.getCell(0, "C2").setValue(5)

    cell = workbook.getCell(0, "D2")
    cell.setR1C1Formula("RC[-2]-RC[-1]")

    workbook.calculateFormulas()

    value = cell.getValue() # 7
finally:
    presentation.dispose()
```

รูปแบบการอ้างอิง R1C1 ที่พบบ่อยคือ:

| อ้างอิง | เชิงสัมพัทธ์ | แน่นอน | ผสม |
|---|---|---|---|
| เซลล์ | `R[2]C[3]` | `R2C3` | `R2C[3]`, `R[2]C3` |
| แถว | `R[2]` | `R2` | — |
| คอลัมน์ | `C[3]` | `C3` | — |
| ช่วง | `R[2]C[3]:R[5]C[7]` | `R2C3:R5C7` | `R2C3:R[5]C[7]`, `R[2]C3:R5C[7]` |

เช่นในเซลล์ `D2` คำว่า `RC[-2]` หมายถึงเซลล์ในแถวเดียวกันสองคอลัมน์ทางซ้าย (`B2`)

## **ค่าสัมพัทธ์และตัวดำเนินการของสูตร**

 Evaluator ในตัวรองรับค่าตรรกะ, ตัวเลข, สตริง, ค่าข้อผิดพลาดของสเปรดชีท, ตัวดำเนินการคณิตศาสตร์, และตัวดำเนินการเปรียบเทียบ

### **ค่าคงที่และลิเทรัล**

| ประเภท | ตัวอย่าง | หมายเหตุ |
|---|---|---|
| ตรรกะ | `TRUE`, `FALSE` | สามารถใช้โดยตรงในนิพจน์ตรรกะ เช่น `A2=TRUE` |
| ตัวเลข | `1`, `0.5`, `.3`, `1E-2` | รองรับรูปแบบทั่วไปและเชิงวิทยาศาสตร์ |
| สตริง | `"abc"`, `"2/3/2020 12:00"` | ลิเทรัลข้อความต้องล้อมด้วยเครื่องหมายอัญประกาศคู่ในสูตร |
| ผลลัพธ์ข้อผิดพลาด | `#DIV/0!`, `#N/A`, `#REF!` | สูตรที่ถูกต้องอาจให้ค่าเป็นข้อผิดพลาดของสเปรดชีทแทนผลลัพธ์ปกติ |

ตัวอย่างนี้ใช้ค่าสัมพัทธ์หลายประเภท:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 500, 300)
    workbook = chart.getChartData().getChartDataWorkbook()

    workbook.getCell(0, "A2").setValue(False)
    workbook.getCell(0, "B2").setFormula("A2=TRUE")
    workbook.getCell(0, "C2").setFormula("1+0.5")
    workbook.getCell(0, "D2").setFormula(".3*1E-2")
    workbook.getCell(0, "E2").setFormula("\"abc\"")
    workbook.getCell(0, "F2").setFormula("2/0")

    workbook.calculateFormulas()

    logical_value = workbook.getCell(0, "B2").getValue() # False
    numeric_value = workbook.getCell(0, "C2").getValue() # 1.5
    scientific_value = workbook.getCell(0, "D2").getValue() # 0.003
    string_value = workbook.getCell(0, "E2").getValue() # abc
    error_value = workbook.getCell(0, "F2").getValue() # #DIV/0!
finally:
    presentation.dispose()
```

### **ตัวดำเนินการคณิตศาสตร์**

| ตัวดำเนินการ | ความหมาย | ตัวอย่าง |
|---|---|---|
| `+` | การบวกหรือเครื่องหมายบวกเอกพจน์ | `2+3` |
| `-` | การลบหรือเครื่องหมายลบเอกพจน์ | `2-3`, `-3` |
| `*` | การคูณ | `2*3` |
| `/` | การหาร | `2/3` |
| `%` | เปอร์เซ็นต์ | `30%` |
| `^` | ยกกำลัง | `2^3` |

ใช้วงเล็บเพื่อระบุลำดับการประเมินอย่างชัดเจน เช่น `(A2+B2)*C2`

### **ตัวดำเนินการเปรียบเทียบ**

นิพจน์เปรียบเทียบจะคืนค่าตรรกะ

| ตัวดำเนินการ | ความหมาย | ตัวอย่าง |
|---|---|---|
| `=` | เท่ากับ | `A2=3` |
| `<>` | ไม่เท่ากับ | `A2<>3` |
| `>` | มากกว่า | `A2>3` |
| `>=` | มากกว่าหรือเท่ากับ | `A2>=3` |
| `<` | น้อยกว่า | `A2<3` |
| `<=` | น้อยกว่าหรือเท่ากับ | `A2<=3` |

## **ฟังก์ชันที่กำหนดไว้ล่วงหน้าและรองรับ**

Aspose.Slides มี evaluator สูตรในตัวสำหรับแผนภูมิ worksheet, แต่ไม่ได้เป็นเอนจิ้นคำนวน Excel แบบเต็ม ชุดฟังก์ชันที่ระบุไว้จำกัดอยู่ในตารางต่อไปนี้ อย่า Assume ว่า Excel ฟังก์ชันใดก็ได้สามารถคำนวณใหม่โดย [ChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/th/python-java/aspose.slides/chartdataworkbook/#calculateFormulas)

| ฟังก์ชัน | วัตถุประสงค์หรือรูปแบบที่รองรับ | ตัวอย่าง |
|---|---|---|
| `ABS` | ค่าตัวเลขแบบสัมบูรณ์ | `ABS(A2)` |
| `AVERAGE` | ค่าเฉลี่ยเลขคณิต | `AVERAGE(B2:B5)` |
| `CEILING` | ปัดขึ้นเป็นจำนวนเต็มหลายเท่า | `CEILING(A2,5)` |
| `CHOOSE` | เลือกค่าโดยดัชนี | `CHOOSE(A2,"Low","High")` |
| `CONCAT` | รวมค่าข้อความ | `CONCAT(A2,B2)` |
| `CONCATENATE` | รวมค่าข้อความ | `CONCATENATE(A2," ",B2)` |
| `DATE` | สร้างค่าวันที่โดยใช้ระบบวันที่ 1900 | `DATE(2026,8,19)` |
| `DAYS` | คืนจำนวนวันระหว่างวันที่สองวัน | `DAYS(B2,A2)` |
| `FIND` | หาข้อความหนึ่งภายในอีกข้อความหนึ่ง | `FIND("-",A2)` |
| `FINDB` | การค้นหาข้อความแบบไบต์ | `FINDB("a",A2)` |
| `IF` | ผลลัพธ์ตามเงื่อนไข | `IF(A2>0,A2,0)` |
| `INDEX` | รูปแบบอ้างอิง | `INDEX(A2:C4,2,3)` |
| `LOOKUP` | รูปแบบเวกเตอร์ | `LOOKUP(A2,B2:B5,C2:C5)` |
| `MATCH` | รูปแบบเวกเตอร์ | `MATCH(A2,B2:B5,0)` |
| `MAX` | ค่าสูงสุด | `MAX(B2:B5)` |
| `SUM` | ผลรวมค่า | `SUM(B2:B5)` |
| `VLOOKUP` | การค้นหาแนวตั้ง | `VLOOKUP(A2,B2:D10,3,FALSE)` |

ข้อจำกัดในตารางสำคัญ: `INDEX` มีรูปแบบอ้างอิง, `LOOKUP` และ `MATCH` มีรูปแบบเวกเตอร์, `DATE` ใช้ระบบวันที่ 1900 ฟังก์ชันหรือคุณสมบัติที่ไม่ได้ระบุในที่นี่ควรถือว่าไม่รองรับโดย evaluator ของ Aspose.Slides เว้นแต่จะมีเอกสารแยกต่างหาก

## **คำนวณสูตรด้วยวัฒนธรรมที่ต้องการ**

ฟังก์ชันบางอย่างของเวิร์กชีทตีความข้อความตามกฎของวัฒนธรรม (culture) นี่สำคัญมากสำหรับฟังก์ชันที่ออกแบบมาสำหรับภาษาที่ใช้รหัสสองไบต์ (DBCS) เพื่อคำนวณสูตรเหล่านี้อย่างถูกต้อง ให้สร้าง [LoadOptions](https://reference.aspose.com/slides/th/python-java/aspose.slides/loadoptions/), ตั้งค่าวัฒนธรรมที่ต้องการด้วย [SpreadsheetOptions.setPreferredCulture](https://reference.aspose.com/slides/th/python-java/aspose.slides/spreadsheetoptions/#setPreferredCulture), กำหนดตัวเลือกสเปรดชีทผ่าน [LoadOptions.setSpreadsheetOptions](https://reference.aspose.com/slides/th/python-java/aspose.slides/loadoptions/#setSpreadsheetOptions), แล้วโหลดงานนำเสนอ

ตัวอย่างต่อไปนี้เลือกวัฒนธรรมญี่ปุ่น, เปิดงานนำเสนอด้วย LoadOptions ที่กำหนด, แล้วเรียก [ChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/th/python-java/aspose.slides/chartdataworkbook/#calculateFormulas) สำหรับทุก chart workbook:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Chart, LoadOptions, Presentation, SpreadsheetOptions
from java.util import Locale

japanese_culture = Locale.forLanguageTag("ja-JP")

spreadsheet_options = SpreadsheetOptions()
spreadsheet_options.setPreferredCulture(japanese_culture)

load_options = LoadOptions()
load_options.setSpreadsheetOptions(spreadsheet_options)

presentation = Presentation("presentation.pptx", load_options)
try:
    for slide in presentation.getSlides():
        for shape in slide.getShapes():
            if isinstance(shape, Chart):
                shape.getChartData().getChartDataWorkbook().calculateFormulas()
finally:
    presentation.dispose()
```

วัฒนธรรมที่ต้องการเป็นส่วนหนึ่งของการกำหนดค่าการโหลดงานนำเสนอ ดังนั้นให้ระบุก่อนสร้างอินสแตนซ์ [Presentation](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentation/) ใช้วัฒนธรรมที่สูตรเวิร์กชีทคาดหวัง; ตัวอย่างเช่นใช้ `ja-JP` สำหรับสูตรที่ต้องปฏิบัติตามกฎการคำนวณ DBCS ของญี่ปุ่น

## **การคำนวณใหม่และค่าที่แคชไว้**

ไฟล์สเปรดชีทมักจะเก็บทั้งสูตรและค่าที่คำนวณล่าสุด Aspose.Slides จึงสามารถอ่านค่าที่แคชจาก [ChartDataCell.getValue](https://reference.aspose.com/slides/th/python-java/aspose.slides/chartdatacell/#getValue) เมื่อโหลดงานนำเสนอและข้อมูลแผนภูมิเกี่ยวข้องไม่ได้ถูกเปลี่ยน

หลังจากเปลี่ยนค่าอินพุตหรือสูตร อย่าอ้างอิงผลลัพธ์ที่แคชเก่า ให้เรียก [ChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/th/python-java/aspose.slides/chartdataworkbook/#calculateFormulas) ก่อนอ่านค่าที่คำนวณหรือบันทึกข้อมูลแผนภูมิที่ขึ้นกับค่าดังกล่าว

สำหรับสูตรที่อยู่นอกชุดที่รองรับ Aspose.Slides อาจไม่สามารถแยกสูตรหรือระบุการพึ่งพาได้ หากเวิร์กชีทถูกแก้ไข ค่าแคชก่อนหน้าจะไม่เป็นที่เชื่อถือได้ ในสถานการณ์นั้น การอ่านค่าของเซลล์ที่มีข้อมูลไม่รองรับอาจจะทำให้เกิด [CellUnsupportedDataException](https://reference.aspose.com/slides/th/python-java/aspose.slides/cellunsupporteddataexception/)

หากแผนภูมิของคุณพึ่งพาฟังก์ชัน Excel ที่ Aspose.Slides ไม่คำนวน, ให้คำนวนสูตรเหล่านั้นด้วยเอนจิ้นสเปรดชีทที่รองรับ แล้วเขียนค่าที่ได้กลับไปยัง chart workbook อย่าทดแทนสูตรที่ไม่รองรับด้วยค่าที่คาดเดา

## **จัดการข้อผิดพลาดของสูตร**

มีสองประเภทของปัญหาที่แตกต่างกัน

สูตรอาจถูกต้องแต่ให้ผลลัพธ์เป็นค่าข้อผิดพลาดของสเปรดชีท เช่น `#DIV/0!`, `#N/A`, `#NAME?`, `#NULL!`, `#NUM!`, `#REF!`, หรือ `#VALUE!` ในกรณีนี้ token ข้อผิดพลาดเป็นผลลัพธ์ของเซลล์และสามารถคืนค่าผ่าน [ChartDataCell.getValue](https://reference.aspose.com/slides/th/python-java/aspose.slides/chartdatacell/#getValue)

สูตรอาจล้มเหลวที่ขั้นตอนการแยก, การอ้างอิง, การพึ่งพา, หรือระดับข้อมูลที่รองรับ Aspose.Slides มีข้อยกเว้นเฉพาะสเปรดชีทสำหรับกรณีเหล่านี้: [CellInvalidFormulaException](https://reference.aspose.com/slides/th/python-java/aspose.slides/cellinvalidformulaexception/), [CellInvalidReferenceException](https://reference.aspose.com/slides/th/python-java/aspose.slides/cellinvalidreferenceexception/), [CellCircularReferenceException](https://reference.aspose.com/slides/th/python-java/aspose.slides/cellcircularreferenceexception/), และ [CellUnsupportedDataException](https://reference.aspose.com/slides/th/python-java/aspose.slides/cellunsupporteddataexception/)

เมื่อสูตรมาจากเทมเพลตหรือการป้อนข้อมูลของผู้ใช้ ให้จัดการข้อยกเว้นเหล่านี้รอบการคำนวณใหม่และการเข้าถึงค่า:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import CellCircularReferenceException, CellInvalidFormulaException, CellInvalidReferenceException, CellUnsupportedDataException, ChartType, Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 500, 300)
    workbook = chart.getChartData().getChartDataWorkbook()
    cell = workbook.getCell(0, "A2")
    cell.setFormula("SUM(B2:B5)")

    try:
        workbook.calculateFormulas()
        print(cell.getValue())
    except CellInvalidFormulaException as ex:
        print("Invalid formula: " + str(ex.getMessage()))
    except CellInvalidReferenceException as ex:
        print("Invalid cell reference: " + str(ex.getMessage()))
    except CellCircularReferenceException as ex:
        print("Circular reference: " + str(ex.getMessage()))
    except CellUnsupportedDataException as ex:
        print("Unsupported spreadsheet data: " + str(ex.getMessage()))
finally:
    presentation.dispose()
```

## **ข้อจำกัดเชิงปฏิบัติ**

การสนับสนุนสูตรในแผนภูมิ worksheet ถูกออกแบบมาสำหรับชุดจำกัดของการคำนวณสเปรดชีท ไม่ใช่เพื่อให้เข้ากันได้เต็มรูปแบบกับ Excel คำนึงถึงข้อจำกัดเหล่านี้เมื่อออกแบบเวิร์กโฟลว์รายงาน:

- ใช้เพียงค่าคงที่, ตัวดำเนินการ, การอ้างอิง, และฟังก์ชันที่ระบุในเอกสารเมื่อต้องการให้ Aspose.Slides คำนวนสูตร
- คำนวนใหม่หลังจากเปลี่ยนเซลล์ที่สูตรอ้างอิง
- ถือค่าที่แคชจากงานนำเสนอที่โหลดเป็นภาพสแนปช็อต ไม่ใช่การคำนวนใหม่หลังจากแก้ไข
- ทดสอบสูตรจากเทมเพลตที่มีอยู่ก่อนพึ่งพาค่าที่คำนวนได้, โดยเฉพาะเมื่อใช้ฟังก์ชันที่อยู่นอกรายการที่ระบุ
- สำหรับสูตรที่ต้องการเอนจิ้นคำนวนสเปรดชีทเต็มรูปแบบ ให้คำนวนภายนอกแล้วอัปเดตค่าที่ได้ใน chart workbook

## **คำถามที่พบบ่อย**

**สูตร [ChartDataCell.setFormula](https://reference.aspose.com/slides/th/python-java/aspose.slides/chartdatacell/#setFormula) กับ [ChartDataCell.setR1C1Formula](https://reference.aspose.com/slides/th/python-java/aspose.slides/chartdatacell/#setR1C1Formula) มีความแตกต่างอย่างไร?**

[ChartDataCell.setFormula](https://reference.aspose.com/slides/th/python-java/aspose.slides/chartdatacell/#setFormula) เก็บนิพจน์แบบ A1 เช่น `B2-C2` ส่วน [ChartDataCell.setR1C1Formula](https://reference.aspose.com/slides/th/python-java/aspose.slides/chartdatacell/#setR1C1Formula) เก็บนิพจน์แบบ R1C1 เช่น `RC[-2]-RC[-1]` ใช้รูปแบบที่สอดคล้องกับวิธีที่คุณสร้างหรือคัดลอกสูตรมากที่สุด

**หลังคำนวนแล้วต้องอ่านค่าเซลล์หรือค่าในเซลล์?**

[ChartDataWorkbook.getCell](https://reference.aspose.com/slides/th/python-java/aspose.slides/chartdataworkbook/#getCell) คืนค่าเป็นอ็อบเจ็กต์ [ChartDataCell](https://reference.aspose.com/slides/th/python-java/aspose.slides/chartdatacell/) เพื่อให้ได้ผลลัพธ์ที่คำนวนแล้ว ให้เรียกเมธอด [ChartDataCell.getValue](https://reference.aspose.com/slides/th/python-java/aspose.slides/chartdatacell/#getValue) ของเซลล์นั้นหลังจากคำนวนใหม่

**ควรเรียก [ChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/th/python-java/aspose.slides/chartdataworkbook/#calculateFormulas) เมื่อใด?**

ให้เรียก [ChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/th/python-java/aspose.slides/chartdataworkbook/#calculateFormulas) หลังจากเปลี่ยนค่าอินพุตหรือสูตรและก่อนที่คุณจะพึ่งพาผลลัพธ์ที่คำนวน นี่จะอัปเดตค่าของสูตรที่ evaluator ในตัวรองรับ

**Aspose.Slides รองรับทุกฟังก์ชันของ Excel หรือไม่?**

ไม่. Evaluator ในตัวรองรับเพียงชุดฟังก์ชันที่ระบุไว้เท่านั้น ฟังก์ชันที่อยู่นอกชุดนั้นไม่ควรถือว่าสามารถคำนวนใหม่ได้อย่างถูกต้อง หากต้องการความเข้ากันได้เต็มรูปแบบกับสูตร Excel ให้ทำการคำนวนด้วยเอนจิ้นสเปรดชีทที่เหมาะสมและเขียนค่าที่ได้กลับไปยัง chart workbook

**ถ้างานนำเสนอที่โหลดมามีสูตรที่ไม่รองรับจะเกิดอะไรขึ้น?**

หากข้อมูลแผนภูมิไม่ได้เปลี่ยน แวร์คบุ๊กอาจยังคงมีค่าที่แคชจากการคำนวนก่อนหน้า หลังจากข้อมูลที่เกี่ยวข้องถูกแก้ไข ค่าที่แคชอาจไม่ถูกต้อง การเข้าถึงเซลล์ที่สูตรไม่สามารถจัดการได้อาจทำให้เกิด [CellUnsupportedDataException](https://reference.aspose.com/slides/th/python-java/aspose.slides/cellunsupporteddataexception/)

**ค่าข้อผิดพลาดของสูตรเป็นเช่นเดียวกับข้อยกเว้นหรือไม่?**

ไม่. ผลลัพธ์เช่น `#DIV/0!` เป็นค่าของสเปรดชีทที่เกิดจากการคำนวนที่ถูกต้อง ส่วนข้อยกเว้นเช่น [CellInvalidFormulaException](https://reference.aspose.com/slides/th/python-java/aspose.slides/cellinvalidformulaexception/) หรือ [CellCircularReferenceException](https://reference.aspose.com/slides/th/python-java/aspose.slides/cellcircularreferenceexception/) บ่งบอกว่าสูตรไม่สามารถประมวลผลตามปกติได้

**แผนภูมิจะอัปเดตอัตโนมัติเมื่อเซลล์สูตรเปลี่ยนหรือไม่?**

ซีรีส์ของแผนภูมิสามารถอ้างอิงเซลล์ในเวิร์กบุ๊กได้ คำนวนเวิร์กบุ๊กก่อน, แล้วบันทึกหรือเรนเดอร์งานนำเสนอ หากจุดข้อมูลของแผนภูมิอ้างอิงเซลล์ที่คำนวนแล้ว แผนภูมิจะใช้ค่าที่อัปเดตเหล่านั้น; ไม่จำเป็นต้องเรียกเมธอดรีเฟรชแผนภูมิแยกต่างหากในเวิร์กโฟลว์นี้

**แผนภูมิสามารถใช้เวิร์กบุ๊ก Excel ภายนอกได้หรือไม่?**

ได้, ข้อมูลแผนภูมิสามารถกำหนดให้ใช้เวิร์กบุ๊กภายนอกผ่าน API ของ chart data อย่างไรก็ตาม กระบวนการคำนวนสูตรที่อธิบายในบทความนี้เกี่ยวกับ chart data workbook และชุดสูตรที่ Aspose.Slides ประเมิน ไม่ควรสมมติว่า [ChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/th/python-java/aspose.slides/chartdataworkbook/#calculateFormulas) จะทำการคำนวนสูตรใดก็ได้ในไฟล์ XLSX ภายนอก

**สูตรสามารถอ้างอิง worksheet หรือ workbook อื่นได้หรือไม่?**

การอ้างอิงแบบ Excel อาจมีอยู่ใน chart workbook, แต่การประเมินสูตรถูกจำกัดโดย parser และชุดฟังก์ชันที่รองรับ หากการอ้างอิงข้ามชีทหรือไฟล์ภายนอกเป็นสิ่งจำเป็น ให้ตรวจสอบสูตรนั้นกับเวอร์ชัน Aspose.Slides ที่คุณใช้ สำหรับเวิร์กโฟลว์ที่ต้องการความเข้ากันได้กับการอ้างอิงของ Excel อย่างกว้างขวาง ให้คำนวนเวิร์กบุ๊กภายนอกแล้วเขียนค่าที่แก้ไขกลับไปยังข้อมูลแผนภูมิ

**สูตรต้องเริ่มต้นด้วย `=` หรือไม่?**

ตัวอย่าง API ของ Aspose.Slides นิยมกำหนดนิพจน์เช่น `B2-C2` หรือ `SUM(B2:B5)` โดยไม่มีเครื่องหมาย `=` ก่อนหน้า การใช้รูปแบบนี้ทำให้สูตรที่สร้างสอดคล้องกับตัวอย่างในเอกสาร API**