---
title: ใช้สูตร Worksheet ของแผนภูมิในงานนำเสนอด้วย Python
linktitle: สูตร Worksheet
type: docs
weight: 70
url: /th/python-net/chart-worksheet-formulas/
keywords:
- แผนภูมิสเปรดชีต
- แผนภูมิ worksheet
- สูตรแผนภูมิ
- สูตร worksheet
- สูตรสเปรดชีต
- workbook ข้อมูลแผนภูมิ
- การคำนวณสูตร
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
- Aspose.Slides
description: "ใช้สูตรสไตล์ Excel ใน Aspose.Slides สำหรับ Python via .NET บน worksheet ของแผนภูมิ, คำนวนค่าใหม่, และใช้ผลลัพธ์ในแผนภูมิ PowerPoint."
---
## **Overview**

แผนภูมิ PowerPoint มักจะจัดเก็บข้อมูลต้นฉบับในแผ่นงานที่ฝังอยู่ ใน Aspose.Slides for Python via .NET คุณสามารถเข้าถึงแผ่นงานนั้นผ่าน workbook ข้อมูลแผนภูมิ, เขียนค่าตัวอินพุต, กำหนดสูตรให้กับเซลล์, คำนวณสูตรที่รองรับ, และใช้เซลล์ที่คำนวณแล้วเป็นข้อมูลแผนภูมิได้

บทความนี้อธิบายกระบวนการทำงานของสูตรอย่างครบถ้วน: สร้างแผนภูมิ, เติมข้อมูลในแผ่นงาน, กำหนดสูตรแบบ A1 หรือ R1C1, คำนวณใหม่, อ่านค่าที่คำนวณได้, เชื่อมต่อเซลล์เหล่านั้นกับซีรีส์ของแผนภูมิ, และบันทึกงานนำเสนอ นอกจากนี้ยังอธิบายไวยากรณ์สูตรที่รองรับ, ชุดฟังก์ชันในตัว, ค่าที่แคชไว้, สูตรที่ไม่รองรับ, และข้อผิดพลาดเฉพาะสเปรดชีต

## **Chart Worksheets and Formulas**

แผ่นงานของแผนภูมิประกอบด้วยหมวดหมู่, ชื่อซีรีส์, และค่า ที่ใช้โดยแผนภูมิ ใน PowerPoint คุณสามารถตรวจสอบแผ่นงานโดยเปิดตัวแก้ไขข้อมูลแผนภูมิ:

![PowerPoint chart with its embedded worksheet open, showing category and series data](chart-worksheet-formulas_1.png)

ใน Aspose.Slides แผ่นงานจะถูกเปิดเผยผ่าน [chart data workbook](https://reference.aspose.com/slides/th/python-net/aspose.slides.charts/ichartdataworkbook/). ใช้คุณสมบัติ [formula](https://reference.aspose.com/slides/th/python-net/aspose.slides.charts/ichartdatacell/formula/) สำหรับสูตรแบบ A1 และคุณสมบัติ [r1c1_formula](https://reference.aspose.com/slides/th/python-net/aspose.slides.charts/ichartdatacell/r1c1_formula/) สำหรับสูตรแบบ R1C1 หลังจากเปลี่ยนเซลล์อินพุตหรือสูตรแล้ว ให้เรียก [calculate_formulas](https://reference.aspose.com/slides/th/python-net/aspose.slides.charts/chartdataworkbook/calculate_formulas/) เพื่อคำนวณสูตรที่รองรับและอัปเดตค่าเซลล์ที่เกี่ยวข้อง

เซลล์ที่คำนวณแล้วยังคงเปิดเผยผลลัพธ์ผ่านคุณสมบัติ [value](https://reference.aspose.com/slides/th/python-net/aspose.slides.charts/ichartdatacell/value/) สิ่งนี้สำคัญเมื่อคุณต้องตรวจสอบผลลัพธ์สูตรในโค้ดหรือใช้เซลล์เป็นจุดข้อมูลของแผนภูมิ

## **Create a Chart and Calculate Worksheet Formulas**

ตัวอย่างต่อไปนี้แสดงการทำงานแบบครบวงจร มันสร้างแผนภูมิคอลัมน์แบบคลัสเตอร์, ลบข้อมูลตัวอย่าง, เขียนค่ารายได้และค่าใช้จ่ายรายไตรมาส, คำนวณกำไรด้วยสูตร, อ่านผลลัพธ์, ใช้เซลล์ที่คำนวณแล้วเป็นค่าของแผนภูมิ, และบันทึกงานนำเสนอ

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 600, 350)
    workbook = chart.chart_data.chart_data_workbook
    worksheet_index = 0

    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()
    workbook.clear(worksheet_index)

    category1 = workbook.get_cell(worksheet_index, "A2", "Q1")
    category2 = workbook.get_cell(worksheet_index, "A3", "Q2")
    category3 = workbook.get_cell(worksheet_index, "A4", "Q3")

    workbook.get_cell(worksheet_index, "B1", "Revenue")
    workbook.get_cell(worksheet_index, "C1", "Expenses")
    workbook.get_cell(worksheet_index, "D1", "Profit")

    workbook.get_cell(worksheet_index, "B2").value = 120.0
    workbook.get_cell(worksheet_index, "C2").value = 80.0
    workbook.get_cell(worksheet_index, "B3").value = 150.0
    workbook.get_cell(worksheet_index, "C3").value = 95.0
    workbook.get_cell(worksheet_index, "B4").value = 135.0
    workbook.get_cell(worksheet_index, "C4").value = 110.0

    profit1 = workbook.get_cell(worksheet_index, "D2")
    profit2 = workbook.get_cell(worksheet_index, "D3")
    profit3 = workbook.get_cell(worksheet_index, "D4")

    profit1.formula = "B2-C2"
    profit2.formula = "B3-C3"
    profit3.formula = "B4-C4"

    workbook.calculate_formulas()

    q1_profit = profit1.value  # 40
    q2_profit = profit2.value  # 55
    q3_profit = profit3.value  # 25

    print(f"Q1 profit: {q1_profit}")
    print(f"Q2 profit: {q2_profit}")
    print(f"Q3 profit: {q3_profit}")

    chart.chart_data.categories.add(category1)
    chart.chart_data.categories.add(category2)
    chart.chart_data.categories.add(category3)

    profit_series = chart.chart_data.series.add(workbook.get_cell(worksheet_index, "D1"), chart.type)
    profit_series.data_points.add_data_point_for_bar_series(profit1)
    profit_series.data_points.add_data_point_for_bar_series(profit2)
    profit_series.data_points.add_data_point_for_bar_series(profit3)
    profit_series.labels.default_data_label_format.show_value = True

    presentation.save("chart-formulas.pptx", slides.export.SaveFormat.PPTX)
```

จุดข้อมูลของแผนภูมิอ้างอิง `D2:D4` ดังนั้นแผนภูมิจะใช้ค่ากำไรที่คำนวณแล้ว ไม่มีการเรียกเมธอดรีเฟรชแผนภูมิแยกต่างหากในกระบวนการนี้: คำนวณ workbook ก่อน, แล้วใช้หรือบันทึกข้อมูลแผนภูมิที่อ้างอิงถึงเซลล์ที่คำนวณแล้ว

## **Use A1-Style Formulas**

การระบุแบบ A1 ใช้ตัวอักษรแทนคอลัมน์และตัวเลขแทนแถว กำหนดนิพจน์แบบ A1 ผ่าน [IChartDataCell.formula](https://reference.aspose.com/slides/th/python-net/aspose.slides.charts/ichartdatacell/formula/)

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 500, 300)
    workbook = chart.chart_data.chart_data_workbook

    workbook.get_cell(0, "C3").value = 10
    workbook.get_cell(0, "F2").value = 2
    workbook.get_cell(0, "G2").value = 3
    workbook.get_cell(0, "H2").value = 4

    cell = workbook.get_cell(0, "A2")
    cell.formula = "C3+SUM(F2:H2)"

    workbook.calculate_formulas()

    value = cell.value  # 19
```

รูปแบบการอ้างอิง A1 ที่พบบ่อยมีดังนี้:

| Reference | Relative | Absolute | Mixed |
|---|---|---|---|
| Cell | `A2` | `$A$2` | `A$2`, `$A2` |
| Row | `2:2` | `$2:$2` | — |
| Column | `A:A` | `$A:$A` | — |
| Range | `A2:C4` | `$A$2:$C$4` | `A$2:$C4`, `$A2:C$4` |

การอ้างอิงแบบ Relative สามารถเปลี่ยนแปลงเมื่อสูตรถูกย้ายหรือคัดลอกโดยแอปสเปรดชีต การอ้างอิงแบบ Absolute จะคงค่าตำแหน่งทั้งสองคงที่ ส่วน Mixed จะคงแค่แถวหรือคอลัมน์เท่านั้น

## **Use R1C1-Style Formulas**

การระบุแบบ R1C1 ใช้ตัวเลขแทนทั้งแถวและคอลัมน์ การอ้างอิงแบบ Relative ใช้ค่าออฟเซ็ตในวงเล็บสี่เหลี่ยมกำหนด กำหนดไวยากรณ์นี้ผ่าน [IChartDataCell.r1c1_formula](https://reference.aspose.com/slides/th/python-net/aspose.slides.charts/ichartdatacell/r1c1_formula/)

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 500, 300)
    workbook = chart.chart_data.chart_data_workbook

    workbook.get_cell(0, "B2").value = 12
    workbook.get_cell(0, "C2").value = 5

    cell = workbook.get_cell(0, "D2")
    cell.r1c1_formula = "RC[-2]-RC[-1]"

    workbook.calculate_formulas()

    value = cell.value  # 7
```

รูปแบบการอ้างอิง R1C1 ที่พบบ่อยมีดังนี้:

| Reference | Relative | Absolute | Mixed |
|---|---|---|---|
| Cell | `R[2]C[3]` | `R2C3` | `R2C[3]`, `R[2]C3` |
| Row | `R[2]` | `R2` | — |
| Column | `C[3]` | `C3` | — |
| Range | `R[2]C[3]:R[5]C[7]` | `R2C3:R5C7` | `R2C3:R[5]C[7]`, `R[2]C3:R5C[7]` |

ตัวอย่างเช่น ในเซลล์ `D2` คำว่า `RC[-2]` หมายถึงเซลล์ในแถวเดียวกันสองคอลัมน์ทางซ้าย (`B2`)

## **Formula Constants and Operators**

Evaluators ของสูตรในตัวรองรับค่าตรรกะ, ตัวเลขลิเทอรัล, สตริง, ค่าข้อผิดพลาดของสเปรดชีต, ตัวดำเนินการคณิตศาสตร์, และตัวดำเนินการเปรียบเทียบ

### **Constants and Literals**

| Type | Examples | Notes |
|---|---|---|
| Logical | `TRUE`, `FALSE` | สามารถใช้โดยตรงในนิพจน์ตรรกะเช่น `A2=TRUE` |
| Numeric | `1`, `0.5`, `.3`, `1E-2` | รองรับรูปแบบธรรมดาและวิทยาศาสตร์ |
| String | `"abc"`, `"2/3/2020 12:00"` | ลิเทอรัลข้อความต้องอยู่ในเครื่องหมายคำพูดคู่ภายในสูตร |
| Error result | `#DIV/0!`, `#N/A`, `#REF!` | สูตรที่สมบูรณ์อาจให้ผลลัพธ์เป็นค่าข้อผิดพลาดของสเปรดชีตแทนค่าปกติ |

ตัวอย่างนี้ใช้หลายประเภทคอนสแตนท์:

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 500, 300)
    workbook = chart.chart_data.chart_data_workbook

    workbook.get_cell(0, "A2").value = False
    workbook.get_cell(0, "B2").formula = "A2=TRUE"
    workbook.get_cell(0, "C2").formula = "1+0.5"
    workbook.get_cell(0, "D2").formula = ".3*1E-2"
    workbook.get_cell(0, "E2").formula = "\"abc\""
    workbook.get_cell(0, "F2").formula = "2/0"

    workbook.calculate_formulas()

    logical_value = workbook.get_cell(0, "B2").value  # เท็จ
    numeric_value = workbook.get_cell(0, "C2").value  # 1.5
    scientific_value = workbook.get_cell(0, "D2").value  # 0.003
    string_value = workbook.get_cell(0, "E2").value  # abc
    error_value = workbook.get_cell(0, "F2").value  # #DIV/0!
```

### **Arithmetic Operators**

| Operator | Meaning | Example |
|---|---|---|
| `+` | การบวกหรือเครื่องหมายบวกเอกพจน์ | `2+3` |
| `-` | การลบหรือเครื่องหมายลบเอกพจน์ | `2-3`, `-3` |
| `*` | การคูณ | `2*3` |
| `/` | การหาร | `2/3` |
| `%` | เปอร์เซนต์ | `30%` |
| `^` | ยกกำลัง | `2^3` |

ใช้วงเล็บเพื่อกำหนดลำดับการประเมินอย่างชัดเจน เช่น `(A2+B2)*C2`

### **Comparison Operators**

นิพจน์เปรียบเทียบจะคืนค่าตรรกะ

| Operator | Meaning | Example |
|---|---|---|
| `=` | เท่ากับ | `A2=3` |
| `<>` | ไม่เท่ากับ | `A2<>3` |
| `>` | มากกว่า | `A2>3` |
| `>=` | มากกว่าหรือเท่ากับ | `A2>=3` |
| `<` | น้อยกว่า | `A2<3` |
| `<=` | น้อยกว่าหรือเท่ากับ | `A2<=3` |

## **Supported Predefined Functions**

Aspose.Slides มี evaluator สูตรในตัวสำหรับแผ่นงานของแผนภูมิ, แต่ไม่ได้เป็นเอนจินคำนวณ Excel เต็มรูปแบบ ชุดฟังก์ชันที่อธิบายไว้จำกัดอยู่ในตารางด้านล่าง อย่าเชื่อว่าสามารถคำนวณฟังก์ชัน Excel ใด ๆ ด้วย [calculate_formulas](https://reference.aspose.com/slides/th/python-net/aspose.slides.charts/chartdataworkbook/calculate_formulas/)

| Function | Purpose or supported form | Example |
|---|---|---|
| `ABS` | ค่าค่าสัมบูรณ์ | `ABS(A2)` |
| `AVERAGE` | ค่าเฉลี่ยเลขคณิต | `AVERAGE(B2:B5)` |
| `CEILING` | ปัดขึ้นเป็นหลายเท่า | `CEILING(A2,5)` |
| `CHOOSE` | เลือกค่าโดยดัชนี | `CHOOSE(A2,"Low","High")` |
| `CONCAT` | รวมข้อความ | `CONCAT(A2,B2)` |
| `CONCATENATE` | รวมข้อความ | `CONCATENATE(A2," ",B2)` |
| `DATE` | สร้างค่าวันที่โดยใช้ระบบวันที่ 1900 | `DATE(2026,8,19)` |
| `DAYS` | คืนจำนวนวันระหว่างสองวันที่ | `DAYS(B2,A2)` |
| `FIND` | ค้นหาข้อความหนึ่งภายในอีกข้อความหนึ่ง | `FIND("-",A2)` |
| `FINDB` | ค้นหาข้อความโดยอิงไบต์ | `FINDB("a",A2)` |
| `IF` | ผลลัพธ์ตามเงื่อนไข | `IF(A2>0,A2,0)` |
| `INDEX` | รูปแบบอ้างอิง | `INDEX(A2:C4,2,3)` |
| `LOOKUP` | รูปแบบเวกเตอร์ | `LOOKUP(A2,B2:B5,C2:C5)` |
| `MATCH` | รูปแบบเวกเตอร์ | `MATCH(A2,B2:B5,0)` |
| `MAX` | ค่าสูงสุด | `MAX(B2:B5)` |
| `SUM` | ผลรวม | `SUM(B2:B5)` |
| `VLOOKUP` | การค้นหาแบบแนวตั้ง | `VLOOKUP(A2,B2:D10,3,FALSE)` |

ข้อจำกัดที่แสดงในตารางมีความสำคัญ: `INDEX` มีรูปแบบอ้างอิง, ในขณะที่ `LOOKUP` และ `MATCH` มีรูปแบบเวกเตอร์ `DATE` ใช้ระบบวันที่ 1900 ฟีเจอร์หรือฟังก์ชันที่ไม่ได้ระบุในที่นี้ควรถือว่าไม่รองรับโดย evaluator ของ Aspose.Slides เว้นแต่จะมีเอกสารแยกไว้

## **Recalculation and Cached Values**

ไฟล์สเปรดชีตมักจะเก็บทั้งสูตรและค่าที่คำนวณล่าสุด Aspose.Slides จึงสามารถอ่านค่าที่แคชจาก [IChartDataCell.value](https://reference.aspose.com/slides/th/python-net/aspose.slides.charts/ichartdatacell/value/) เมื่อโหลดงานนำเสนอและข้อมูลแผนภูมิที่เกี่ยวข้องไม่ได้ถูกเปลี่ยน

หลังจากเปลี่ยนเซลล์อินพุตหรือสูตร อย่าอ้างอิงค่าที่แคชเก่า ให้เรียก [ChartDataWorkbook.calculate_formulas](https://reference.aspose.com/slides/th/python-net/aspose.slides.charts/chartdataworkbook/calculate_formulas/) ก่อนอ่านค่าที่คำนวณหรือบันทึกข้อมูลแผนภูมิที่พึ่งพามัน

สำหรับสูตรที่อยู่นอกชุดที่รองรับ, Aspose.Slides อาจไม่สามารถพาร์สสูตรหรือกำหนดความขึ้นต่อกันได้ หาก workbook ถูกแก้ไข ค่าแคชก่อนหน้าอาจไม่เชื่อถือได้ ในสถานการณ์นั้น การอ่านค่าเซลล์ที่มีข้อมูลไม่รองรับอาจทำให้เกิด [CellUnsupportedDataException](https://reference.aspose.com/slides/th/python-net/aspose.slides.spreadsheet/cellunsupporteddataexception/)

หากแผนภูมิของคุณต้องพึ่งพาฟังก์ชัน Excel ที่ Aspose.Slides ไม่ประมวลผล ให้คำนวนสูตรเหล่านั้นด้วยเอนจินสเปรดชีตที่รองรับและเขียนค่าที่ได้กลับไปยัง workbook ของแผนภูมิ อย่าแทนสูตรที่ไม่รองรับด้วยค่าที่คาดเดา

## **Handle Formula Errors**

มีสองประเภทของปัญหาที่ต้องแยกแยะ

สูตรอาจถูกต้องแต่ให้ผลลัพธ์เป็นข้อผิดพลาดของสเปรดชีตเช่น `#DIV/0!`, `#N/A`, `#NAME?`, `#NULL!`, `#NUM!`, `#REF!` หรือ `#VALUE!` ในกรณีนี้โทเค็นข้อผิดพลาดเป็นผลลัพธ์ของเซลล์และสามารถส่งคืนผ่าน `value`

สูตรอาจล้มเหลวที่ขั้นตอนการพาร์ส, การอ้างอิง, ความขึ้นต่อ หรือระดับข้อมูลที่รองรับ Aspose.Slides มี exception เฉพาะสเปรดชีตสำหรับกรณีเหล่านี้: [CellInvalidFormulaException](https://reference.aspose.com/slides/th/python-net/aspose.slides.spreadsheet/cellinvalidformulaexception/), [CellInvalidReferenceException](https://reference.aspose.com/slides/th/python-net/aspose.slides.spreadsheet/cellinvalidreferenceexception/), [CellCircularReferenceException](https://reference.aspose.com/slides/th/python-net/aspose.slides.spreadsheet/cellcircularreferenceexception/), และ [CellUnsupportedDataException](https://reference.aspose.com/slides/th/python-net/aspose.slides.spreadsheet/cellunsupporteddataexception/)

เมื่อสูตรมาจากเทมเพลตหรือการป้อนข้อมูลของผู้ใช้ ให้จัดการ exception เหล่านี้รอบการคำนวณใหม่และการเข้าถึงค่า:

```python
import aspose.slides as slides
import aspose.slides.charts as charts
import aspose.slides.spreadsheet as spreadsheet

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 500, 300)
    workbook = chart.chart_data.chart_data_workbook
    cell = workbook.get_cell(0, "A2")
    cell.formula = "SUM(B2:B5)"

    try:
        workbook.calculate_formulas()
        print(cell.value)
    except spreadsheet.CellInvalidFormulaException as ex:
        print(f"Invalid formula: {ex}")
    except spreadsheet.CellInvalidReferenceException as ex:
        print(f"Invalid cell reference: {ex}")
    except spreadsheet.CellCircularReferenceException as ex:
        print(f"Circular reference: {ex}")
    except spreadsheet.CellUnsupportedDataException as ex:
        print(f"Unsupported spreadsheet data: {ex}")
```

## **Practical Limitations**

การสนับสนุนสูตรในแผ่นงานของแผนภูมิมุ่งเน้นที่ชุดย่อยของการคำนวณสเปรดชีต, ไม่ได้ให้ความเข้ากันได้เต็มรูปแบบกับ Excel ควรคำนึงถึงข้อจำกัดเหล่านี้เมื่อออกแบบ workflow การรายงาน:

- ใช้เฉพาะคอนสแตนท์, ตัวดำเนินการ, การอ้างอิง, และฟังก์ชันที่ระบุเอกสารเมื่อคุณต้องการให้ Aspose.Slides คำนวนสูตร
- คำนวนใหม่หลังจากเปลี่ยนเซลล์ที่ผลลัพธ์สูตรพึ่งพา
- ถือว่าค่าแคชจากงานนำเสนอที่โหลดเป็นสแน็ปช็อต, ไม่ใช่การแทนที่การคำนวนใหม่หลังแก้ไข
- ทดสอบสูตรจากเทมเพลตที่มีอยู่ก่อนพึ่งพาค่าที่คำนวนแล้ว, โดยเฉพาะอย่างยิ่งเมื่อใช้ฟังก์ชันที่อยู่นอกรายการที่ระบุ
- สำหรับสูตรที่ต้องการเอนจินคำนวนสเปรดชีตเต็มรูปแบบ, ให้คำนวนภายนอกแล้วอัปเดต workbook ของแผนภูมิด้วยค่าที่ได้

## **FAQ**

**What is the difference between `formula` and `r1c1_formula`?**

[formula](https://reference.aspose.com/slides/th/python-net/aspose.slides.charts/ichartdatacell/formula/) เก็บนิพจน์แบบ A1 เช่น `B2-C2`. [r1c1_formula](https://reference.aspose.com/slides/th/python-net/aspose.slides.charts/ichartdatacell/r1c1_formula/) เก็บนิพจน์แบบ R1C1 เช่น `RC[-2]-RC[-1]`. ใช้รูปแบบที่ตรงกับวิธีการสร้างหรือคัดลอกรูปสูตรของคุณ

**Do I need to read the cell itself or its value after calculation?**

[ChartDataWorkbook.get_cell](https://reference.aspose.com/slides/th/python-net/aspose.slides.charts/chartdataworkbook/get_cell/) คืนค่า `IChartDataCell`. เพื่อรับผลลัพธ์ที่คำนวนแล้ว ให้อ่านคุณสมบัติ [value](https://reference.aspose.com/slides/th/python-net/aspose.slides.charts/ichartdatacell/value/) ของเซลล์นั้นหลังจากคำนวนใหม่

**When should I call `calculate_formulas`?**

เรียก [calculate_formulas](https://reference.aspose.com/slides/th/python-net/aspose.slides.charts/chartdataworkbook/calculate_formulas/) หลังจากเปลี่ยนค่าหรือสูตรอินพุตและก่อนที่คุณจะพึ่งพาผลลัพธ์ที่คำนวนแล้ว นี้จะอัปเดตค่าของสูตรที่ evaluator ในตัวรองรับ

**Does Aspose.Slides support every Excel function?**

ไม่. evaluator ในตัวรองรับเพียงชุดฟังก์ชันที่ระบุในเอกสาร ฟังก์ชันนอกชุดนี้ไม่ควรถือว่าสามารถคำนวนได้อย่างถูกต้อง หากต้องการความเข้ากันได้เต็มรูปแบบกับสูตร Excel ควรทำการคำนวนด้วยเอนจินสเปรดชีตที่เหมาะสมและเขียนค่าที่ได้ลงใน workbook ของแผนภูมิ

**What happens if a loaded presentation contains an unsupported formula?**

หากข้อมูลแผนภูมิไม่ถูกเปลี่ยน, workbook อาจยังคงมีค่าที่แคชจากการคำนวนครั้งก่อน หลังจากข้อมูลที่เกี่ยวข้องถูกแก้ไข ค่าที่แคชอาจไม่ถูกต้อง การเข้าถึงเซลล์ที่สูตรไม่สามารถจัดการได้อาจทำให้เกิด [CellUnsupportedDataException](https://reference.aspose.com/slides/th/python-net/aspose.slides.spreadsheet/cellunsupporteddataexception/)

**Are formula error values the same as Python exceptions?**

ไม่. ผลลัพธ์เช่น `#DIV/0!` เป็นค่าของสเปรดชีตที่มาจากการคำนวนที่ถูกต้อง Exception เช่น [CellInvalidFormulaException](https://reference.aspose.com/slides/th/python-net/aspose.slides.spreadsheet/cellinvalidformulaexception/) หรือ [CellCircularReferenceException](https://reference.aspose.com/slides/th/python-net/aspose.slides.spreadsheet/cellcircularreferenceexception/) แสดงว่าสูตรไม่สามารถประมวลผลได้ตามปกติ

**Does a chart update automatically when a formula cell changes?**

ซีรีส์ของแผนภูมิสามารถอ้างอิงเซลล์ใน workbook ได้ คำนวน workbook ก่อน, แล้วบันทึกหรือเรนเดอร์งานนำเสนอ หากจุดข้อมูลของแผนภูมิอ้างอิงถึงเซลล์ที่คำนวนแล้ว แผนภูมิจะใช้ค่านั้นโดยอัตโนมัติ ไม่ต้องเรียกเมธอดรีเฟรชแผนภูมิแยกต่างหาก

**Can charts use an external Excel workbook?**

ใช่, ข้อมูลแผนภูมิสามารถกำหนดให้ใช้ workbook ภายนอกผ่าน API ของ chart data อย่างไรก็ตาม workflow การคำนวนสูตรที่อธิบายในบทความนี้เกี่ยวกับ workbook ของแผนภูมิและชุดสูตรที่ Aspose.Slides ประเมิน ไม่ควรถือว่า [calculate_formulas](https://reference.aspose.com/slides/th/python-net/aspose.slides.charts/chartdataworkbook/calculate_formulas/) ให้การคำนวนเต็มรูปแบบของสูตรใด ๆ ในไฟล์ XLSX ภายนอก

**Can I use formulas that reference another worksheet or workbook?**

การอ้างอิงแบบ Excel อาจมีใน workbook ของแผนภูมิ, แต่การประเมินสูตรถูกจำกัดโดยพาร์เซอร์และชุดฟังก์ชันที่รองรับ หากต้องอ้างอิงข้ามแผ่นหรือไฟล์ภายนอก ให้ตรวจสอบสูตรนั้นกับเวอร์ชัน Aspose.Slides ที่คุณใช้งาน สำหรับ workflow ที่ต้องการความเข้ากันได้ของการอ้างอิง Excel อย่างกว้างขวาง ควรคำนวน workbook ภายนอกและเขียนค่าที่แก้ไขแล้วกลับไปยังข้อมูลแผนภูมิ

**Should formula strings start with `=`?**

ตัวอย่าง API ของ Aspose.Slides กำหนดนิพจน์เช่น `B2-C2` หรือ `SUM(B2:B5)` โดยไม่มี `=` นำหน้า การใช้รูปแบบนี้ทำให้สูตรที่สร้างสอดคล้องกับตัวอย่าง API ที่ระบุในเอกสาร