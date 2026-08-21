---
title: ใช้สูตรแผ่นงานแผนภูมิในงานนำเสนอด้วย Python
linktitle: สูตรแผ่นงาน
type: docs
weight: 70
url: /th/python-net/chart-worksheet-formulas/
keywords:
- สเปรดชีตแผนภูมิ
- แผ่นงานแผนภูมิ
- สูตรแผนภูมิ
- สูตรแผ่นงาน
- สูตรสเปรดชีต
- สมุดงานข้อมูลแผนภูมิ
- การคำนวณสูตร
- วัฒนธรรมที่ต้องการ
- สูตรตามวัฒนธรรม
- DBCS
- ค่าคงที่ตรรกะ
- ค่าคงที่เชิงตัวเลข
- ค่าคงที่สตริง
- ค่าคงที่ข้อผิดพลาด
- ตัวดำเนินการคณิตศาสตร์
- ตัวดำเนินการเปรียบเทียบ
- สไตล์ A1
- สไตล์ R1C1
- ฟังก์ชันกำหนดล่วงหน้า
- PowerPoint
- งานนำเสนอ
- Python
- Aspose.Slides
description: "ใช้สูตรแบบ Excel ใน Aspose.Slides สำหรับ Python ผ่านแผ่นงานแผนภูมิ .NET, คำนวณค่าซ้ำใหม่, และใช้ผลลัพธ์ในแผนภูมิ PowerPoint."
---
## **ภาพรวม**

PowerPoint charts โดยทั่วไปจะเก็บข้อมูลต้นทางในแผ่นงานที่ฝังอยู่ ใน Aspose.Slides for Python via .NET คุณสามารถเข้าถึงแผ่นงานนั้นผ่าน chart data workbook, เขียนค่าตั้งต้น, กำหนดสูตรให้กับเซลล์, คำนวณสูตรที่สนับสนุน, และใช้เซลล์ที่คำนวณแล้วเป็นข้อมูลของแผนภูมิ

บทความนี้อธิบายกระบวนการทำงานของสูตรอย่างครบถ้วน: สร้างแผนภูมิ, เติมข้อมูลในแผ่นงาน, กำหนดสูตรแบบ A1 หรือ R1C1, คำนวณสูตรใหม่, อ่านค่าที่คำนวณได้, เชื่อมต่อเซลล์เหล่านั้นกับชุดข้อมูลของแผนภูมิ, และบันทึกงานนำเสนอ นอกจากนี้ยังอธิบายไวยากรณ์สูตรที่สนับสนุน, ชุดฟังก์ชันในตัว, ค่าที่แคช, สูตรที่ไม่สนับสนุน, และข้อผิดพลาดเฉพาะของสเปรดชีต

## **แผ่นงานกราฟและสูตร**

แผ่นงานกราฟประกอบด้วยหมวดหมู่, ชื่อชุดข้อมูล, และค่าที่ใช้โดยแผนภูมิ ใน PowerPoint คุณสามารถตรวจสอบแผ่นงานได้โดยเปิด chart data editor:

![PowerPoint chart with its embedded worksheet open, showing category and series data](chart-worksheet-formulas_1.png)

ใน Aspose.Slides แผ่นงานถูกเปิดเผยผ่าน [สมุดงานข้อมูลแผนภูมิ](https://reference.aspose.com/slides/th/python-net/aspose.slides.charts/ichartdataworkbook/)。ใช้คุณสมบัติ [formula](https://reference.aspose.com/slides/th/python-net/aspose.slides.charts/ichartdatacell/formula/) สำหรับสูตรแบบ A1 และคุณสมบัติ [r1c1_formula](https://reference.aspose.com/slides/th/python-net/aspose.slides.charts/ichartdatacell/r1c1_formula/) สำหรับสูตรแบบ R1C1 หลังจากเปลี่ยนเซลล์อินพุตหรือสูตร ให้เรียก [calculate_formulas](https://reference.aspose.com/slides/th/python-net/aspose.slides.charts/chartdataworkbook/calculate_formulas/) เพื่อคำนวณสูตรที่สนับสนุนและอัปเดตค่าของเซลล์ที่สอดคล้องกัน

เซลล์ที่คำนวณแล้วยังคงเปิดเผยผลลัพธ์ผ่านคุณสมบัติ [value](https://reference.aspose.com/slides/th/python-net/aspose.slides.charts/ichartdatacell/value/) สิ่งนี้สำคัญเมื่อคุณต้องการตรวจสอบผลลัพธ์ของสูตรในโค้ดหรือใช้เซลล์เป็นจุดข้อมูลของแผนภูมิ

## **สร้างแผนภูมิและคำนวณสูตรในแผ่นงาน**

ตัวอย่างต่อไปนี้แสดงกระบวนการทำงานแบบครบวงจร มันสร้างแผนภูมิคอลัมน์แบบคลัสเตอร์, ลบข้อมูลตัวอย่าง, เขียนค่ารายได้และค่าใช้จ่ายรายไตรมาส, คำนวณกำไรด้วยสูตร, อ่านผลลัพธ์, ใช้เซลล์ที่คำนวณเป็นค่าของแผนภูมิ, และบันทึกงานนำเสนอ

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

จุดข้อมูลของแผนภูมิอ้างอิง `D2:D4` ดังนั้นแผนภูมิจะใช้ค่ากำไรที่คำนวณแล้ว ไม่มีการเรียกเมธอดรีเฟรชแผนภูมิแยกต่างหากในกระบวนการนี้: คำนวณสมุดงานก่อน, จากนั้นใช้หรือบันทึกข้อมูลแผนภูมิที่ชี้ไปยังเซลล์ที่คำนวณแล้ว

## **ใช้สูตรแบบ A1**

การระบุแบบ A1 ระบุคอลัมป์ด้วยตัวอักษรและแถวด้วยตัวเลข กำหนดนิพจน์แบบ A1 ผ่าน [IChartDataCell.formula](https://reference.aspose.com/slides/th/python-net/aspose.slides.charts/ichartdatacell/formula/)

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

รูปแบบการอ้างอิง A1 ที่พบได้บ่อยคือ:

| อ้างอิง | สัมพัทธ์ | คงที่ | ผสม |
|---|---|---|---|
| เซลล์ | `A2` | `$A$2` | `A$2`, `$A2` |
| แถว | `2:2` | `$2:$2` | — |
| คอลัมน์ | `A:A` | `$A:$A` | — |
| ช่วง | `A2:C4` | `$A$2:$C$4` | `A$2:$C4`, `$A2:C$4` |

การอ้างอิงสัมพัทธ์อาจเปลี่ยนแปลงเมื่อสูตรถูกย้ายหรือคัดลอกโดยแอปสเปรดชีต การอ้างอิงคงที่จะคงค่าพิกัดทั้งสองคงที่ ส่วนการอ้างอิงผสมจะคงแค่แถวหรือคอลัมน์เดียว

## **ใช้สูตรแบบ R1C1**

การระบุแบบ R1C1 ระบุทั้งแถวและคอลัมน์ด้วยตัวเลข การอ้างอิงสัมพัทธ์ใช้การเยื้องในวงเล็บเหลี่ยม กำหนดไวยากรณ์นี้ผ่าน [IChartDataCell.r1c1_formula](https://reference.aspose.com/slides/th/python-net/aspose.slides.charts/ichartdatacell/r1c1_formula/)

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

รูปแบบการอ้างอิง R1C1 ที่พบได้บ่อยคือ:

| อ้างอิง | สัมพัทธ์ | คงที่ | ผสม |
|---|---|---|---|
| เซลล์ | `R[2]C[3]` | `R2C3` | `R2C[3]`, `R[2]C3` |
| แถว | `R[2]` | `R2` | — |
| คอลัมน์ | `C[3]` | `C3` | — |
| ช่วง | `R[2]C[3]:R[5]C[7]` | `R2C3:R5C7` | `R2C3:R[5]C[7]`, `R[2]C3:R5C[7]` |

เช่น ในเซลล์ `D2`, `RC[-2]` หมายถึงเซลล์ในแถวเดียวกันสองคอลัมน์ไปทางซ้าย (`B2`)

## **ค่าคงที่และตัวดำเนินการสูตร**

ตัวตรวจสอบสูตรในตัวสนับสนุนค่าตรรกะ, ตัวเลขเชิงตำแหน่ง, สตริง, ค่าข้อผิดพลาดของสเปรดชีต, ตัวดำเนินการคณิตศาสตร์, และตัวดำเนินการเปรียบเทียบ

### **ค่าคงที่และลิเทรัล**

| ประเภท | ตัวอย่าง | หมายเหตุ |
|---|---|---|
| ตรรกะ | `TRUE`, `FALSE` | สามารถใช้โดยตรงในนิพจน์ตรรกะเช่น `A2=TRUE` |
| ตัวเลข | `1`, `0.5`, `.3`, `1E-2` | รองรับรูปแบบธรรมดาและวิทยาศาสตร์ |
| สตริง | `"abc"`, `"2/3/2020 12:00"` | ตัวอักษรลิตเชอร์อยู่ในเครื่องหมายอัญประกาศคู่ภายในสูตร |
| ผลลัพธ์ข้อผิดพลาด | `#DIV/0!`, `#N/A`, `#REF!` | สูตรที่ถูกต้องอาจให้ค่าข้อผิดพลาดของสเปรดชีตแทนผลลัพธ์ปกติ |

ตัวอย่างนี้ใช้ค่าคงที่หลายประเภท:

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

### **ตัวดำเนินการคณิตศาสตร์**

| ตัวดำเนินการ | ความหมาย | ตัวอย่าง |
|---|---|---|
| `+` | การบวกหรือบวกเชิงยูเนียรี | `2+3` |
| `-` | การลบหรือทำเครื่องหมายลบ | `2-3`, `-3` |
| `*` | การคูณ | `2*3` |
| `/` | การหาร | `2/3` |
| `%` | เปอร์เซ็นต์ | `30%` |
| `^` | ยกกำลัง | `2^3` |

ใช้วงเล็บเพื่อทำให้ลำดับการประเมินชัดเจน เช่น `(A2+B2)*C2`

### **ตัวดำเนินการเปรียบเทียบ**

นิพจน์การเปรียบเทียบให้ค่าตรรกะ

| ตัวดำเนินการ | ความหมาย | ตัวอย่าง |
|---|---|---|
| `=` | เท่ากับ | `A2=3` |
| `<>` | ไม่เท่ากับ | `A2<>3` |
| `>` | มากกว่า | `A2>3` |
| `>=` | มากกว่าหรือเท่ากับ | `A2>=3` |
| `<` | น้อยกว่า | `A2<3` |
| `<=` | น้อยกว่าหรือเท่ากับ | `A2<=3` |

## **ฟังก์ชันที่กำหนดล่วงหน้าที่รองรับ**

Aspose.Slides มีตัวตรวจสอบสูตรในตัวสำหรับแผ่นงานกราฟ แต่ไม่ได้เป็นเครื่องมือคำนวณ Excel เต็มรูปแบบ ชุดฟังก์ชันที่ถูกบันทึกไว้จำกัดอยู่ที่ฟังก์ชันต่อไปนี้ อย่าสันนิษฐานว่าฟังก์ชัน Excel ใด ๆ สามารถคำนวณใหม่ได้โดย [calculate_formulas](https://reference.aspose.com/slides/th/python-net/aspose.slides.charts/chartdataworkbook/calculate_formulas/)

| ฟังก์ชัน | วัตถุประสงค์หรือรูปแบบที่รองรับ | ตัวอย่าง |
|---|---|---|
| `ABS` | ค่าสัมบูรณ์ | `ABS(A2)` |
| `AVERAGE` | ค่าเฉลี่ยเลขคณิต | `AVERAGE(B2:B5)` |
| `CEILING` | ปัดจำนวนขึ้นเป็นหลายของ | `CEILING(A2,5)` |
| `CHOOSE` | เลือกค่าตามดัชนี | `CHOOSE(A2,"Low","High")` |
| `CONCAT` | รวมค่าข้อความ | `CONCAT(A2,B2)` |
| `CONCATENATE` | รวมค่าข้อความ | `CONCATENATE(A2," ",B2)` |
| `DATE` | สร้างค่าวันที่โดยใช้ระบบวันที่ 1900 | `DATE(2026,8,19)` |
| `DAYS` | คืนจำนวนวันระหว่างสองวันที่ | `DAYS(B2,A2)` |
| `FIND` | ค้นหาข้อความหนึ่งภายในอีกข้อความหนึ่ง | `FIND("-",A2)` |
| `FINDB` | การค้นหาข้อความแบบไบต์ | `FINDB("a",A2)` |
| `IF` | ผลลัพธ์ตามเงื่อนไข | `IF(A2>0,A2,0)` |
| `INDEX` | รูปแบบอ้างอิง | `INDEX(A2:C4,2,3)` |
| `LOOKUP` | รูปแบบเวกเตอร์ | `LOOKUP(A2,B2:B5,C2:C5)` |
| `MATCH` | รูปแบบเวกเตอร์ | `MATCH(A2,B2:B5,0)` |
| `MAX` | ค่าสูงสุด | `MAX(B2:B5)` |
| `SUM` | ผลรวมค่า | `SUM(B2:B5)` |
| `VLOOKUP` | การค้นหาแบบแนวตั้ง | `VLOOKUP(A2,B2:D10,3,FALSE)` |

ข้อจำกัดในตารางมีความสำคัญ: `INDEX` ถูกอธิบายในรูปแบบอ้างอิง, ส่วน `LOOKUP` และ `MATCH` อยู่ในรูปแบบเวกเตอร์ `DATE` ใช้ระบบวันที่ 1900 ฟังก์ชันหรือคุณลักษณะที่ไม่อยู่ในรายการนี้ควรถือว่าไม่ได้รับการสนับสนุนโดยตัวตรวจสอบสูตรของ Aspose.Slides นอกจากว่าจะมีการบันทึกแยกต่างหาก

## **คำนวณสูตรด้วยวัฒนธรรมที่ต้องการ**

ฟังก์ชันบางอย่างของสมุดงานแผนภูมิจะแปลข้อความตามกฎของวัฒนธรรมที่กำหนด ซึ่งสำคัญอย่างยิ่งสำหรับฟังก์ชันที่ออกแบบมาสำหรับภาษาที่ใช้ชุดอักษรสองไบต์ (DBCS) เพื่อคำนวณสูตรเหล่านี้อย่างถูกต้อง ให้สร้าง [LoadOptions](https://reference.aspose.com/slides/th/python-net/aspose.slides/loadoptions/), ตั้งค่า [SpreadsheetOptions.preferred_culture](https://reference.aspose.com/slides/th/python-net/aspose.slides/spreadsheetoptions/) ผ่าน [LoadOptions.spreadsheet_options](https://reference.aspose.com/slides/th/python-net/aspose.slides/loadoptions/spreadsheet_options/), แล้วโหลดงานนำเสนอ

ตัวอย่างต่อไปนี้เลือกวัฒนธรรมญี่ปุ่น, เปิดงานนำเสนอด้วย LoadOptions ที่กำหนดค่า, และเรียก [ChartDataWorkbook.calculate_formulas](https://reference.aspose.com/slides/th/python-net/aspose.slides.charts/chartdataworkbook/calculate_formulas/) สำหรับทุกสมุดงานแผนภูมิ:

```python
import aspose.slides as slides
import aspose.slides.charts as charts

load_options = slides.LoadOptions()
load_options.spreadsheet_options.preferred_culture = "ja-JP"

with slides.Presentation("presentation.pptx", load_options) as presentation:
    for slide in presentation.slides:
        for shape in slide.shapes:
            if isinstance(shape, charts.Chart):
                shape.chart_data.chart_data_workbook.calculate_formulas()
```

วัฒนธรรมที่ต้องการเป็นส่วนหนึ่งของการกำหนดค่าการโหลดงานนำเสนอ ดังนั้นให้ระบุก่อนสร้างอ็อบเจกต์ [Presentation](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/) ใช้วัฒนธรรมที่สูตรของสมุดงานคาดหวัง ตัวอย่างเช่น ใช้ `ja-JP` สำหรับสูตรที่ต้องปฏิบัติตามกฎการคำนวณ DBCS ของญี่ปุ่น

## **การคำนวณใหม่และค่าที่แคช**

ไฟล์สเปรดชีตมักจะเก็บสูตรพร้อมค่าที่คำนวณแล้วล่าสุด Aspose.Slides จึงสามารถอ่านค่าที่แคชจาก [IChartDataCell.value](https://reference.aspose.com/slides/th/python-net/aspose.slides.charts/ichartdatacell/value/) เมื่อโหลดงานนำเสนอและข้อมูลแผนภูมิที่เกี่ยวข้องไม่ได้ถูกเปลี่ยนแปลง

หลังจากเปลี่ยนค่าอินพุตหรือสูตร อย่าพึ่งพาค่าที่แคชเก่า ให้เรียก [ChartDataWorkbook.calculate_formulas](https://reference.aspose.com/slides/th/python-net/aspose.slides.charts/chartdataworkbook/calculate_formulas/) ก่อนอ่านค่าที่คำนวณหรือบันทึกข้อมูลแผนภูมิที่พึ่งพาค่าเหล่านั้น

สำหรับสูตรที่อยู่นอกชุดที่สนับสนุน Aspose.Slides อาจไม่สามารถแยกสูตรหรือกำหนดการพึ่งพาได้ หากสมุดงานถูกแก้ไข ค่าแคชก่อนหน้าอาจไม่เชื่อถือได้ ในสถานการณ์นั้น การอ่านค่าเซลล์ที่มีข้อมูลที่ไม่สนับสนุนอาจทำให้เกิด [CellUnsupportedDataException](https://reference.aspose.com/slides/th/python-net/aspose.slides.spreadsheet/cellunsupporteddataexception/)

หากแผนภูมิของคุณพึ่งพาฟังก์ชัน Excel ที่ Aspose.Slides ไม่ประมวลผล ให้คำนวณสูตรเหล่านั้นด้วยเอนจินสเปรดชีตที่รองรับ แล้วเขียนค่าที่ได้กลับไปยังสมุดงานแผนภูมิ อย่าแทนสูตรที่ไม่สนับสนุนด้วยค่าที่คาดเดา

## **จัดการข้อผิดพลาดสูตร**

มีสองประเภทของปัญหาที่ต้องแยกแยะ

สูตรอาจถูกต้องแต่ให้ผลลัพธ์เป็นข้อผิดพลาดของสเปรดชีตเช่น `#DIV/0!`, `#N/A`, `#NAME?`, `#NULL!`, `#NUM!`, `#REF!`, หรือ `#VALUE!` ในกรณีนี้ โทเค็นข้อผิดพลาดเป็นผลลัพธ์ของเซลล์และสามารถส่งกลับผ่าน `value`

สูตรอาจล้มเหลวในขั้นตอนการพาร์ส, การอ้างอิง, การพึ่งพา, หรือระดับข้อมูลที่สนับสนุน Aspose.Slides ให้ข้อยกเว้นเฉพาะสเปรดชีตสำหรับกรณีเหล่านี้: [CellInvalidFormulaException](https://reference.aspose.com/slides/th/python-net/aspose.slides.spreadsheet/cellinvalidformulaexception/), [CellInvalidReferenceException](https://reference.aspose.com/slides/th/python-net/aspose.slides.spreadsheet/cellinvalidreferenceexception/), [CellCircularReferenceException](https://reference.aspose.com/slides/th/python-net/aspose.slides.spreadsheet/cellcircularreferenceexception/), และ [CellUnsupportedDataException](https://reference.aspose.com/slides/th/python-net/aspose.slides.spreadsheet/cellunsupporteddataexception/)

เมื่อสูตรมาจากเทมเพลตหรืออินพุตของผู้ใช้ ให้จัดการข้อยกเว้นเหล่านี้รอบการคำนวณใหม่และการเข้าถึงค่า:

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

## **ข้อจำกัดเชิงปฏิบัติ**

การสนับสนุนสูตรในแผ่นงานกราฟออกแบบมาสำหรับชุดย่อยของการคำนวณสเปรดชีต ไม่ได้สำหรับความเข้ากันได้เต็มรูปแบบกับ Excel ให้คำนึงถึงข้อจำกัดเหล่านี้เมื่อออกแบบกระบวนการรายงาน:

- ใช้เฉพาะค่าคงที่, ตัวดำเนินการ, การอ้างอิง, และฟังก์ชันที่บันทึกไว้เมื่อคุณต้องการให้ Aspose.Slides คำนวณสูตรใหม่
- คำนวณใหม่หลังจากเปลี่ยนเซลล์ที่สูตรอิงผล
- ถือว่าค่าที่แคชจากงานนำเข้าที่โหลดเป็นภาพถ่าย ณ จุดนัั้น ไม่ใช่การแทนที่การคำนวณใหม่หลังแก้ไข
- ทดสอบสูตรจากเทมเพลตที่มีอยู่ก่อนพึ่งพาผลลัพธ์ที่คำนวณแล้ว โดยเฉพาะอย่างยิ่งเมื่อใช้ฟังก์ชันที่อยู่นอกรายการที่บันทึกไว้
- สำหรับสูตรที่ต้องการเครื่องมือคำนวณสเปรดชีตเต็มรูปแบบ ให้คำนวณภายนอกแล้วอัปเดตสมุดงานแผนภูมิกับค่าที่ได้

## **คำถามที่พบบ่อย**

**สูตร `formula` กับ `r1c1_formula` แตกต่างกันอย่างไร?**

[formula](https://reference.aspose.com/slides/th/python-net/aspose.slides.charts/ichartdatacell/formula/) เก็บนิพจน์แบบ A1 เช่น `B2-C2` ส่วน [r1c1_formula](https://reference.aspose.com/slides/th/python-net/aspose.slides.charts/ichartdatacell/r1c1_formula/) เก็บนิพจน์แบบ R1C1 เช่น `RC[-2]-RC[-1]` ใช้รูปแบบที่ตรงกับวิธีที่คุณสร้างหรือคัดลอกสูตร

**ต้องอ่านเซลล์เองหรือค่า (`value`) หลังการคำนวณหรือไม่?**

[ChartDataWorkbook.get_cell](https://reference.aspose.com/slides/th/python-net/aspose.slides.charts/chartdataworkbook/get_cell/) คืนค่า `IChartDataCell` เพื่อให้ได้ผลลัพธ์ที่คำนวณแล้ว อ่านคุณสมบัติ [value](https://reference.aspose.com/slides/th/python-net/aspose.slides.charts/ichartdatacell/value/) ของเซลล์นั้นหลังการคำนวณใหม่

**ควรเรียก `calculate_formulas` เมื่อใด?**

เรียก [calculate_formulas](https://reference.aspose.com/slides/th/python-net/aspose.slides.charts/chartdataworkbook/calculate_formulas/) หลังจากเปลี่ยนค่าหรือสูตรอินพุตและก่อนที่คุณจะพึ่งพาผลลัพธ์ที่คำนวณ มันจะอัปเดตค่าของสูตรที่ตัวตรวจสอบในตัวสนับสนุน

**Aspose.Slides รองรับฟังก์ชัน Excel ทุกตัวหรือไม่?**

ไม่ ตัวตรวจสอบในตัวรองรับชุดฟังก์ชันที่บันทึกไว้เท่านั้น ฟังก์ชันที่อยู่นอกชุดนั้นไม่ควรสันนิษฐานว่าจะคำนวณใหม่ได้อย่างถูกต้อง หากต้องการความเข้ากันได้เต็มรูปแบบของสูตร Excel ให้ทำการคำนวณด้วยเอนจินสเปรดชีตที่เหมาะสมแล้วเขียนค่าที่ได้ลงในสมุดงานแผนภูมิ

**ถ้างานนำเข้าที่โหลดมีสูตรที่ไม่ได้สนับสนุน จะเกิดอะไรขึ้น?**

หากข้อมูลแผนภูมิไม่เปลี่ยนแปลง สมุดงานอาจยังคงมีค่าที่แคชจากการคำนวณก่อนหน้า หลังจากแก้ไขข้อมูลที่เกี่ยวข้อง ค่าที่แคชนั้นอาจใช้ไม่ได้แล้ว การเข้าถึงเซลล์ที่สูตรไม่สามารถจัดการได้อาจทำให้เกิด [CellUnsupportedDataException](https://reference.aspose.com/slides/th/python-net/aspose.slides.spreadsheet/cellunsupporteddataexception/)

**ค่าข้อผิดพลาดสูตรเท่ากับข้อยกเว้นของ Python หรือไม่?**

ไม่ ผลลัพธ์เช่น `#DIV/0!` เป็นค่าของสเปรดชีตที่เกิดจากการคำนวณที่ถูกต้อง ข้อยกเว้นเช่น [CellInvalidFormulaException](https://reference.aspose.com/slides/th/python-net/aspose.slides.spreadsheet/cellinvalidformulaexception/) หรือ [CellCircularReferenceException](https://reference.aspose.com/slides/th/python-net/aspose.slides.spreadsheet/cellcircularreferenceexception/) ระบุว่สูตรไม่สามารถประมวลผลตามปกติได้

**แผนภูมิจะอัปเดตอัตโนมัติเมื่อเซลล์สูตรเปลี่ยนหรือไม่?**

ชุดข้อมูลของแผนภูมิสามารถอ้างอิงเซลล์ในสมุดงานได้ คำนวณสมุดงานก่อน แล้วบันทึกหรือเรนเดอร์งานนำเสนอ ถ้าจุดข้อมูลของแผนภูมิอ้างอิงเซลล์ที่คำนวณแล้ว แผนภูมิจะใช้ค่าที่อัปเดตเหล่านั้น ไม่ต้องมีเมธอดรีเฟรชแผนภูมิแยกต่างหากในกระบวนการนี้

**แผนภูมิสามารถใช้สมุดงาน Excel ภายนอกได้หรือไม่?**

ได้ ข้อมูลแผนภูมิสามารถตั้งค่าให้ใช้สมุดงานภายนอกผ่าน API ของข้อมูลแผนภูมิ อย่างไรก็ตาม กระบวนการคำนวณสูตรที่อธิบายในบทความนี้เกี่ยวกับสมุดงานข้อมูลแผนภูมิและชุดสูตรที่ Aspose.Slides ตรวจสอบ ไม่ควรสันนิษฐานว่า [calculate_formulas](https://reference.aspose.com/slides/th/python-net/aspose.slides.charts/chartdataworkbook/calculate_formulas/) ให้การคำนวณเต็มรูปแบบของสูตรใด ๆ ในไฟล์ XLSX ภายนอก

**สามารถใช้สูตรที่อ้างอิงแผ่นงานหรือสมุดงานอื่นได้หรือไม่?**

อ้างอิงสไตล์ Excel อาจมีในสมุดงานแผนภูมิ แต่การประเมินสูตรนั้นจำกัดโดยพาร์เซอร์และชุดฟังก์ชันที่สนับสนุน หากต้องอ้างอิงข้ามแผ่นหรือไฟล์ภายนอก จำเป็นต้องตรวจสอบสูตรนั้นกับเวอร์ชัน Aspose.Slides ที่ใช้ สำหรับกระบวนการที่ต้องการความเข้ากันได้ของการอ้างอิง Excel อย่างกว้าง ควรคำนวณสมุดงานภายนอกแล้วเขียนค่าที่แก้ไขแล้วกลับไปยังข้อมูลแผนภูมิ

**สูตรควรเริ่มต้นด้วย `=` หรือไม่?**

ตัวอย่าง API ของ Aspose.Slides กำหนดนิพจน์เช่น `B2-C2` หรือ `SUM(B2:B5)` โดยไม่มี `=` นำหน้า การใช้รูปแบบนี้ทำให้สูตรที่สร้างสอดคล้องกับตัวอย่าง API ที่บันทึกไว้