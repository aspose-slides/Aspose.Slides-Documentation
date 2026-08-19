---
title: ใช้สูตรแผ่นงานแผนภูมิในงานนำเสนอด้วย JavaScript
linktitle: สูตรแผ่นงาน
type: docs
weight: 70
url: /th/nodejs-java/chart-worksheet-formulas/
keywords:
- แผนภูมิ สเปรดชีต
- แผ่นงานแผนภูมิ
- สูตรแผนภูมิ
- สูตรแผ่นงาน
- สูตรสเปรดชีต
- เวิร์กบุ๊กข้อมูลแผนภูมิ
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
- Node.js
- JavaScript
- Aspose.Slides
description: "ใช้สูตรแบบ Excel ใน Aspose.Slides สำหรับ Node.js ผ่านแผ่นงานแผนภูมิของ Java, คำนวณค่าซ้ำ และใช้ผลลัพธ์ในแผนภูมิ PowerPoint."
---
## **ภาพรวม**

แผนภูมิ PowerPoint มักเก็บข้อมูลต้นฉบับในเวิร์กชีตที่ฝังอยู่ ใน Aspose.Slides for Node.js via Java คุณสามารถเข้าถึงเวิร์กชีตนั้นผ่าน chart data workbook, เขียนค่าข้อมูลเข้า, กำหนดสูตรให้กับเซลล์, คำนวณสูตรที่รองรับ, และใช้เซลล์ที่คำนวณแล้วเป็นข้อมูลแผนภูมิได้

บทความนี้อธิบายขั้นตอนการทำงานของสูตรอย่างครบถ้วน: สร้างแผนภูมิ, เติมข้อมูลในเวิร์กชีต, กำหนดสูตรแบบ A1 หรือ R1C1, คำนวณสูตรใหม่, อ่านค่าที่คำนวณได้, เชื่อมต่อเซลล์เหล่านั้นกับซีรีส์ของแผนภูมิ, และบันทึกงานนำเสนอ นอกจากนี้ยังอธิบายไวยากรณ์สูตรที่รองรับ, ชุดฟังก์ชันในตัว, ค่าที่แคชไว้, สูตรที่ไม่รองรับ, และข้อผิดพลาดเฉพาะสเปรดชีต

## **แผนภูมิ เวิร์กชีต และสูตร**

แผนภูมิเวิร์กชีตประกอบด้วยประเภท, ชื่อซีรีส์, และค่าที่ใช้โดยแผนภูมิ ใน PowerPoint คุณสามารถตรวจสอบเวิร์กชีตได้โดยเปิด chart data editor:

![PowerPoint chart with its embedded worksheet open, showing category and series data](chart-worksheet-formulas_1.png)

ใน Aspose.Slides เวิร์กชีตจะเปิดเผยผ่านคลาส [ChartDataWorkbook](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/chartdataworkbook/) ใช้ [ChartDataCell.setFormula](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/chartdatacell/#setFormula-java.lang.String-) สำหรับสูตรแบบ A1 และ [ChartDataCell.setR1C1Formula](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/chartdatacell/#setR1C1Formula-java.lang.String-) สำหรับสูตรแบบ R1C1 หลังจากเปลี่ยนเซลล์อินพุตหรือสูตร ให้เรียก [ChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/chartdataworkbook/#calculateFormulas--) เพื่อคำนวณสูตรที่รองรับและอัปเดตค่าของเซลล์ที่เกี่ยวข้อง

เซลล์ที่คำนวณแล้วยังคงเปิดเผยผลลัพธ์ผ่าน [ChartDataCell.getValue](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/chartdatacell/#getValue--) ซึ่งสำคัญเมื่อต้องตรวจสอบผลลัพธ์สูตรในโค้ดหรือใช้เซลล์เป็นจุดข้อมูลของแผนภูมิ

## **สร้างแผนภูมิและคำนวณสูตรในเวิร์กชีต**

ตัวอย่างต่อไปนี้แสดงขั้นตอนการทำงานแบบครบวงจร โดยสร้างแผนภูมิคอลัมน์แบบกลุ่ม, ลบข้อมูลตัวอย่าง, เขียนค่ารายได้และค่าใช้จ่ายรายไตรมาส, คำนวณกำไรด้วยสูตร, อ่านผลลัพธ์, ใช้เซลล์ที่คำนวณแล้วเป็นค่าของแผนภูมิ, และบันทึกงานนำเสนอ

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 600, 350);
    const workbook = chart.getChartData().getChartDataWorkbook();
    const worksheetIndex = 0;

    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();
    workbook.clear(worksheetIndex);

    const category1 = workbook.getCell(worksheetIndex, "A2", "Q1");
    const category2 = workbook.getCell(worksheetIndex, "A3", "Q2");
    const category3 = workbook.getCell(worksheetIndex, "A4", "Q3");

    workbook.getCell(worksheetIndex, "B1", "Revenue");
    workbook.getCell(worksheetIndex, "C1", "Expenses");
    workbook.getCell(worksheetIndex, "D1", "Profit");

    workbook.getCell(worksheetIndex, "B2").setValue(120.0);
    workbook.getCell(worksheetIndex, "C2").setValue(80.0);
    workbook.getCell(worksheetIndex, "B3").setValue(150.0);
    workbook.getCell(worksheetIndex, "C3").setValue(95.0);
    workbook.getCell(worksheetIndex, "B4").setValue(135.0);
    workbook.getCell(worksheetIndex, "C4").setValue(110.0);

    const profit1 = workbook.getCell(worksheetIndex, "D2");
    const profit2 = workbook.getCell(worksheetIndex, "D3");
    const profit3 = workbook.getCell(worksheetIndex, "D4");

    profit1.setFormula("B2-C2");
    profit2.setFormula("B3-C3");
    profit3.setFormula("B4-C4");

    workbook.calculateFormulas();

    const q1Profit = profit1.getValue(); // 40
    const q2Profit = profit2.getValue(); // 55
    const q3Profit = profit3.getValue(); // 25

    console.log("Q1 profit: " + q1Profit);
    console.log("Q2 profit: " + q2Profit);
    console.log("Q3 profit: " + q3Profit);

    chart.getChartData().getCategories().add(category1);
    chart.getChartData().getCategories().add(category2);
    chart.getChartData().getCategories().add(category3);

    const profitSeries = chart.getChartData().getSeries().add(workbook.getCell(worksheetIndex, "D1"), chart.getType());
    profitSeries.getDataPoints().addDataPointForBarSeries(profit1);
    profitSeries.getDataPoints().addDataPointForBarSeries(profit2);
    profitSeries.getDataPoints().addDataPointForBarSeries(profit3);
    profitSeries.getLabels().getDefaultDataLabelFormat().setShowValue(true);

    presentation.save("chart-formulas.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

จุดข้อมูลของแผนภูมิอ้างอิง `D2:D4` ดังนั้นแผนภูมิใช้ค่ากำไรที่คำนวณแล้ว ไม่มีการเรียกรีเฟรชแผนภูมิแยกต่างหากในขั้นตอนนี้: คำนวณเวิร์กชีตก่อน, จากนั้นใช้หรือบันทึกข้อมูลแผนภูมิที่อ้างอิงเซลล์ที่คำนวณแล้ว

## **ใช้สูตรแบบ A1**

การอ้างอิงแบบ A1 ใช้ตัวอักษรระบุคอลัมน์และตัวเลขระบุแถว กำหนดนิพจน์แบบ A1 ผ่าน [ChartDataCell.setFormula](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/chartdatacell/#setFormula-java.lang.String-)

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 500, 300);
    const workbook = chart.getChartData().getChartDataWorkbook();

    workbook.getCell(0, "C3").setValue(10);
    workbook.getCell(0, "F2").setValue(2);
    workbook.getCell(0, "G2").setValue(3);
    workbook.getCell(0, "H2").setValue(4);

    const cell = workbook.getCell(0, "A2");
    cell.setFormula("C3+SUM(F2:H2)");

    workbook.calculateFormulas();

    const value = cell.getValue(); // 19
} finally {
    presentation.dispose();
}
```

รูปแบบการอ้างอิง A1 ที่พบบ่อยมีดังนี้:

| การอ้างอิง | เชิงสัมพันธ์ | เชิงอิสระ | ผสม |
|---|---|---|---|
| เซลล์ | `A2` | `$A$2` | `A$2`, `$A2` |
| แถว | `2:2` | `$2:$2` | — |
| คอลัมน์ | `A:A` | `$A:$A` | — |
| ช่วง | `A2:C4` | `$A$2:$C$4` | `A$2:$C4`, `$A2:C$4` |

การอ้างอิงเชิงสัมพันธ์อาจเปลี่ยนเมื่อสูตรถูกย้ายหรือคัดลอกโดยแอปสเปรดชีต การอ้างอิงเชิงอิสระจะคงพิกัดทั้งสองแบบคงที่ ส่วนการอ้างอิงผสมจะคงเพียงแถวหรือคอลัมน์อย่างใดอย่างหนึ่ง

## **ใช้สูตรแบบ R1C1**

การอ้างอิงแบบ R1C1 ใช้ตัวเลขระบุทั้งแถวและคอลัมน์ การอ้างอิงเชิงสัมพันธ์ใช้การออฟเซ็ตในวงเล็บสี่เหลี่ยม กำหนดไวยากรณ์นี้ผ่าน [ChartDataCell.setR1C1Formula](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/chartdatacell/#setR1C1Formula-java.lang.String-)

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 500, 300);
    const workbook = chart.getChartData().getChartDataWorkbook();

    workbook.getCell(0, "B2").setValue(12);
    workbook.getCell(0, "C2").setValue(5);

    const cell = workbook.getCell(0, "D2");
    cell.setR1C1Formula("RC[-2]-RC[-1]");

    workbook.calculateFormulas();

    const value = cell.getValue(); // 7
} finally {
    presentation.dispose();
}
```

รูปแบบการอ้างอิง R1C1 ที่พบบ่อยมีดังนี้:

| การอ้างอิง | เชิงสัมพันธ์ | เชิงอิสระ | ผสม |
|---|---|---|---|
| เซลล์ | `R[2]C[3]` | `R2C3` | `R2C[3]`, `R[2]C3` |
| แถว | `R[2]` | `R2` | — |
| คอลัมน์ | `C[3]` | `C3` | — |
| ช่วง | `R[2]C[3]:R[5]C[7]` | `R2C3:R5C7` | `R2C3:R[5]C[7]`, `R[2]C3:R5C[7]` |

ตัวอย่างเช่น ในเซลล์ `D2` `RC[-2]` หมายถึงเซลล์ในแถวเดียวกันสองคอลัมน์ทางซ้าย (`B2`)

## **ค่าคงที่และตัวดำเนินการในสูตร**

ตัวประเมินสูตรในตัวรองรับค่าสตริงส์แบบตรรกะ, ตัวเลขลิเทอรัล, สตริง, ค่าข้อผิดพลาดของสเปรดชีต, ตัวดำเนินการคณิตศาสตร์, และตัวดำเนินการเปรียบเทียบ

### **ค่าคงที่และลิเทอรัล**

| ชนิด | ตัวอย่าง | หมายเหตุ |
|---|---|---|
| ตรรกะ | `TRUE`, `FALSE` | สามารถใช้โดยตรงในนิพจน์ตรรกะเช่น `A2=TRUE` |
| ตัวเลข | `1`, `0.5`, `.3`, `1E-2` | รองรับการเขียนแบบทั่วไปและวิทยาศาสตร์ |
| สตริง | `"abc"`, `"2/3/2020 12:00"` | ลิเทอรัลข้อความต้องอยู่ในเครื่องหมายอัญประกาศคู่ภายในสูตร |
| ผลลัพธ์ข้อผิดพลาด | `#DIV/0!`, `#N/A`, `#REF!` | สูตรที่สมบูรณ์อาจให้ค่าเป็นข้อผิดพลาดของสเปรดชีตแทนผลลัพธ์ปกติ |

ตัวอย่างนี้ใช้ค่าคงที่หลายประเภท:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 500, 300);
    const workbook = chart.getChartData().getChartDataWorkbook();

    workbook.getCell(0, "A2").setValue(false);
    workbook.getCell(0, "B2").setFormula("A2=TRUE");
    workbook.getCell(0, "C2").setFormula("1+0.5");
    workbook.getCell(0, "D2").setFormula(".3*1E-2");
    workbook.getCell(0, "E2").setFormula("\"abc\"");
    workbook.getCell(0, "F2").setFormula("2/0");

    workbook.calculateFormulas();

    const logicalValue = workbook.getCell(0, "B2").getValue(); // เท็จ
    const numericValue = workbook.getCell(0, "C2").getValue(); // 1.5
    const scientificValue = workbook.getCell(0, "D2").getValue(); // 0.003
    const stringValue = workbook.getCell(0, "E2").getValue(); // abc
    const errorValue = workbook.getCell(0, "F2").getValue(); // #DIV/0!
} finally {
    presentation.dispose();
}
```

### **ตัวดำเนินการคณิตศาสตร์**

| ตัวดำเนินการ | ความหมาย | ตัวอย่าง |
|---|---|---|
| `+` | การบวกหรือเครื่องหมายบวกเอกเทศ | `2+3` |
| `-` | การลบหรือการทำลบเอกเทศ | `2-3`, `-3` |
| `*` | การคูณ | `2*3` |
| `/` | การหาร | `2/3` |
| `%` | เปอร์เซ็นต์ | `30%` |
| `^` | การยกกำลัง | `2^3` |

ใช้วงเล็บเพื่อทำให้ลำดับการประเมินชัดเจน เช่น `(A2+B2)*C2`

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

## **ฟังก์ชันสำเร็จรูปที่รองรับ**

Aspose.Slides มีตัวประเมินสูตรในตัวสำหรับเวิร์กชีตแผนภูมิ แต่ไม่ใช่เอนจิ้นการคำนวณ Excel ครบวงจร ชุดฟังก์ชันที่ระบุไว้จำกัดอยู่ที่ฟังก์ชันต่อไปนี้ อย่าเชื่อว่าฟังก์ชัน Excel ใด ๆ สามารถคำนวณใหม่ได้โดย [ChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/chartdataworkbook/#calculateFormulas--)

| ฟังก์ชัน | จุดประสงค์หรือรูปแบบที่รองรับ | ตัวอย่าง |
|---|---|---|
| `ABS` | ค่าตัวเลขสัมบูรณ์ | `ABS(A2)` |
| `AVERAGE` | ค่าเฉลี่ยเลขคณิต | `AVERAGE(B2:B5)` |
| `CEILING` | ปัดจำนวนขึ้นไปเป็นหลายเท่า | `CEILING(A2,5)` |
| `CHOOSE` | เลือกค่าตามดัชนี | `CHOOSE(A2,"Low","High")` |
| `CONCAT` | เชื่อมต่อข้อความ | `CONCAT(A2,B2)` |
| `CONCATENATE` | เชื่อมต่อข้อความ | `CONCATENATE(A2," ",B2)` |
| `DATE` | สร้างค่าวันโดยใช้ระบบ 1900 | `DATE(2026,8,19)` |
| `DAYS` | จำนวนวันระหว่างวันที่ | `DAYS(B2,A2)` |
| `FIND` | ค้นหาข้อความหนึ่งในอีกข้อความหนึ่ง | `FIND("-",A2)` |
| `FINDB` | ค้นหาข้อความแบบไบต์ | `FINDB("a",A2)` |
| `IF` | ผลลัพธ์ตามเงื่อนไข | `IF(A2>0,A2,0)` |
| `INDEX` | รูปแบบการอ้างอิง | `INDEX(A2:C4,2,3)` |
| `LOOKUP` | รูปแบบเวกเตอร์ | `LOOKUP(A2,B2:B5,C2:C5)` |
| `MATCH` | รูปแบบเวกเตอร์ | `MATCH(A2,B2:B5,0)` |
| `MAX` | ค่ามากสุด | `MAX(B2:B5)` |
| `SUM` | ผลรวมค่า | `SUM(B2:B5)` |
| `VLOOKUP` | การค้นหาแบบแนวตั้ง | `VLOOKUP(A2,B2:D10,3,FALSE)` |

ข้อจำกัดในตารางมีความสำคัญ: `INDEX` ระบุในรูปแบบการอ้างอิง, ส่วน `LOOKUP` และ `MATCH` ระบุในรูปแบบเวกเตอร์, `DATE` ใช้ระบบวันปี 1900 ฟังก์ชันที่ไม่ได้ระบุในที่นี้ควรถือว่าไม่รองรับโดยตัวประเมินสูตรของ Aspose.Slides เว้นแต่จะมีการระบุเป็นพิเศษในเอกสารอื่น

## **การคำนวณใหม่และค่าที่แคชไว้**

ไฟล์สเปรดชีตมักเก็บทั้งสูตรและค่าที่คำนวณล่าสุด Aspose.Slides จึงสามารถอ่านค่าที่แคชจาก [ChartDataCell.getValue](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/chartdatacell/#getValue--) เมื่อโหลดงานนำเสนอและข้อมูลแผนภูมิที่เกี่ยวข้องไม่ได้ถูกเปลี่ยน

หลังจากเปลี่ยนเซลล์อินพุตหรือสูตร อย่าอ้างอิงผลแคชเก่า ให้เรียก [ChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/chartdataworkbook/#calculateFormulas--) ก่อนอ่านค่าที่คำนวณหรือบันทึกข้อมูลแผนภูมิที่พึ่งพาค่านั้น

สำหรับสูตรที่อยู่นอกชุดที่รองรับ Aspose.Slides อาจไม่สามารถพาร์สสูตรหรือกำหนดการพึ่งพาได้ หากเวิร์กชีตถูกแก้ไข ค่าที่แคชไว้ก่อนหน้านี้จึงไม่เชื่อถือได้ ในสถานการณ์นั้น การอ่านค่าของเซลล์ที่มีข้อมูลไม่รองรับอาจทำให้เกิด [CellUnsupportedDataException](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/cellunsupporteddataexception/)

หากแผนภูมิต้องพึ่งพาฟังก์ชัน Excel ที่ Aspose.Slides ไม่ประมวลผล ให้นำสูตรเหล่านั้นคำนวณด้วยเอนจิ้นสเปรดชีตที่รองรับ แล้วเขียนค่าที่ได้กลับไปยังเวิร์กชีตแผนภูมิ อย่าเปลี่ยนสูตรที่ไม่รองรับเป็นค่าที่คาดเดา

## **จัดการข้อผิดพลาดของสูตร**

มีสองประเภทของปัญหาที่ต้องแยกแยะ

สูตรอาจถูกต้องแต่ให้ผลลัพธ์เป็นข้อผิดพลาดของสเปรดชีต เช่น `#DIV/0!`, `#N/A`, `#NAME?`, `#NULL!`, `#NUM!`, `#REF!`, หรือ `#VALUE!` ในกรณีนี้ โทเคนข้อผิดพลาดเป็นผลลัพธ์ของเซลล์และสามารถส่งกลับผ่าน [ChartDataCell.getValue](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/chartdatacell/#getValue--)

สูตรอาจล้มเหลวในขั้นตอนการพาร์ส, การอ้างอิง, การพึ่งพา, หรือระดับข้อมูลที่รองรับ Aspose.Slides มีข้อยกเว้นเฉพาะสเปรดชีตสำหรับกรณีเหล่านี้: [CellInvalidFormulaException](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/cellinvalidformulaexception/), [CellInvalidReferenceException](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/cellinvalidreferenceexception/), [CellCircularReferenceException](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/cellcircularreferenceexception/), และ [CellUnsupportedDataException](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/cellunsupporteddataexception/)

เมื่อสูตรมาจากแม่แบบหรืออินพุตของผู้ใช้ ให้จับข้อผิดพลาดรอบการคำนวณใหม่และการเข้าถึงค่า รายละเอียดข้อผิดพลาดจะระบุปัญหาสเปรดชีตที่เป็นสาเหตุ:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 500, 300);
    const workbook = chart.getChartData().getChartDataWorkbook();
    const cell = workbook.getCell(0, "A2");
    cell.setFormula("SUM(B2:B5)");

    try {
        workbook.calculateFormulas();
        console.log(cell.getValue());
    } catch (error) {
        console.error("Formula processing error: " + error.message);
    }
} finally {
    presentation.dispose();
}
```

## **ข้อจำกัดเชิงปฏิบัติ**

การสนับสนุนสูตรในเวิร์กชีตแผนภูมิมีจุดประสงค์สำหรับชุดย่อยของการคำนวณสเปรดชีต ไม่ได้มุ่งให้เข้ากันได้เต็มรูปแบบกับ Excel ให้คำนึงถึงข้อจำกัดเหล่านี้เมื่อออกแบบกระบวนการรายงาน:

- ใช้เฉพาะค่าคงที่, ตัวดำเนินการ, การอ้างอิง, และฟังก์ชันที่ระบุในเอกสารเมื่อคุณต้องการให้ Aspose.Slides คำนวณสูตรใหม่
- คำนวณใหม่หลังจากเปลี่ยนเซลล์ที่สูตรผลลัพธ์พึ่งพา
- ถือค่าที่แคชจากงานนำเข้าที่โหลดเป็นภาพสแนปช็อต ไม่ใช่การแทนที่การคำนวณใหม่หลังแก้ไข
- ทดสอบสูตรจากแม่แบบที่มีอยู่ก่อนพึ่งพาค่าที่คำนวณได้ โดยเฉพาะเมื่อใช้ฟังก์ชันที่อยู่นอกรายการที่ระบุ
- สำหรับสูตรที่ต้องการเอนจิ้นการคำนวณสเปรดชีตเต็มรูปแบบ ให้คำนวณภายนอกแล้วอัปเดตเวิร์กชีตแผนภูมิด้วยค่าที่ได้

## **คำถามที่พบบ่อย**

**ความแตกต่างระหว่าง [ChartDataCell.setFormula](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/chartdatacell/#setFormula-java.lang.String-) และ [ChartDataCell.setR1C1Formula](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/chartdatacell/#setR1C1Formula-java.lang.String-) คืออะไร?**

[ChartDataCell.setFormula](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/chartdatacell/#setFormula-java.lang.String-) เก็บนิพจน์แบบ A1 เช่น `B2-C2` ส่วน [ChartDataCell.setR1C1Formula](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/chartdatacell/#setR1C1Formula-java.lang.String-) เก็บนิพจน์แบบ R1C1 เช่น `RC[-2]-RC[-1]` ใช้สไตล์ที่สอดคล้องกับวิธีการสร้างหรือคัดลอกสูตรของคุณมากที่สุด

**ต้องอ่านค่าเซลล์หรือค่าผลลัพธ์ของเซลล์หลังจากคำนวณหรือไม่?**

[ChartDataWorkbook.getCell](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/chartdataworkbook/#getCell-int-java.lang.String-) คืนค่า [ChartDataCell](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/chartdatacell/) เพื่อให้ได้ผลลัพธ์ที่คำนวณแล้ว ให้เรียกเมธอด [ChartDataCell.getValue](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/chartdatacell/#getValue--) ของเซลล์นั้นหลังจากคำนวณใหม่

**ควรเรียก [ChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/chartdataworkbook/#calculateFormulas--) เมื่อใด?**

เรียก [ChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/chartdataworkbook/#calculateFormulas--) หลังจากเปลี่ยนค่าข้อมูลเข้าหรือสูตรและก่อนที่คุณจะพึ่งพาผลลัพธ์ที่คำนวณแล้ว ซึ่งจะอัปเดตค่าของสูตรที่ตัวประเมินในตัวรองรับ

**Aspose.Slides รองรับฟังก์ชัน Excel ทุกตัวหรือไม่?**

ไม่ ตัวประเมินในตัวรองรับเพียงชุดฟังก์ชันที่ระบุไว้เท่านั้น ฟังก์ชันที่อยู่นอกชุดนั้นไม่ควรสมมติว่าจะคำนวณใหม่ได้อย่างถูกต้อง หากต้องการความเข้ากันได้เต็มรูปแบบกับสูตร Excel ให้ทำการคำนวณด้วยเอนจิ้นสเปรดชีตที่เหมาะสมแล้วเขียนค่าที่ได้ลงในเวิร์กชีตแผนภูมิ

**ถ้างานนำเสนอที่โหลดมามีสูตรที่ไม่รองรับจะเกิดอะไรขึ้น?**

หากข้อมูลแผนภูมิไม่ได้เปลี่ยน เวิร์กชีตอาจยังคงมีค่าที่แคชจากการคำนวณครั้งก่อน หลังจากที่ข้อมูลที่เกี่ยวข้องถูกแก้ไข ค่าที่แคชนี้อาจไม่ใช่ค่าที่ถูกต้อง การเข้าถึงเซลล์ที่สูตรไม่สามารถจัดการได้อาจทำให้เกิด [CellUnsupportedDataException](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/cellunsupporteddataexception/)

**ค่าข้อผิดพลาดของสูตรเท่ากับข้อยกเว้นหรือไม่?**

ไม่ ผลลัพธ์เช่น `#DIV/0!` เป็นค่าของสเปรดชีตที่เกิดจากการคำนวณที่ถูกต้อง ส่วนข้อยกเว้นเช่น [CellInvalidFormulaException](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/cellinvalidformulaexception/) หรือ [CellCircularReferenceException](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/cellcircularreferenceexception/) แสดงว่าไม่สามารถประมวลผลสูตรได้ตามปกติ

**แผนภูมิจะอัปเดตอัตโนมัติเมื่อเซลล์สูตรเปลี่ยนหรือไม่?**

ซีรีส์ของแผนภูมิอาจอ้างอิงเซลล์ในเวิร์กชีต คำนวณเวิร์กชีตก่อน แล้วบันทึกหรือเรนเดอร์งานนำเสนอ หากจุดข้อมูลแผนภูมิอ้างอิงเซลล์ที่คำนวณแล้ว แผนภูมิจะใช้ค่าที่อัปเดตนั้น ไม่จำเป็นต้องมีเมธอดรีเฟรชแผนภูมิแยกต่างหากในขั้นตอนนี้

**แผนภูมิสามารถใช้เวิร์กชีต Excel ภายนอกได้หรือไม่?**

ได้ สามารถกำหนดให้ข้อมูลแผนภูมิใช้เวิร์กชีตภายนอกผ่าน API ของข้อมูลแผนภูมิ อย่างไรก็ตาม ขั้นตอนการคำนวณสูตรที่อธิบายไว้ในบทความนี้เกี่ยวกับเวิร์กชีตข้อมูลแผนภูมิและชุดสูตรที่ Aspose.Slides ประเมิน ไม่ควรสันนิษฐานว่า [ChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/chartdataworkbook/#calculateFormulas--) ให้การคำนวนเต็มรูปแบบของสูตรใด ๆ ในไฟล์ XLSX ภายนอก

**สูตรที่อ้างอิงเวิร์กชีตหรือเวิร์กบุ๊กอื่นได้หรือไม่?**

อ้างอิงสไตล์ Excel อาจปรากฏในเวิร์กชีตแผนภูมิ แต่การประมวลผลสูตรนั้นจำกัดโดยพาร์เซอร์และชุดฟังก์ชันที่รองรับ หากต้องอ้างอิงข้ามชีตหรือไฟล์ภายนอกเป็นสิ่งสำคัญ ให้ตรวจสอบสูตรนั้นกับเวอร์ชัน Aspose.Slides ที่คุณใช้อยู่ สำหรับงานที่ต้องการความเข้ากันได้กับการอ้างอิง Excel อย่างกว้างขวาง ให้คำนวณเวิร์กชีตภายนอกแล้วเขียนค่าที่แก้ไขกลับไปยังข้อมูลแผนภูมิ

**สูตรควรเริ่มต้นด้วย `=` หรือไม่?**

ตัวอย่าง API ของ Aspose.Slides กำหนดนิพจน์เช่น `B2-C2` หรือ `SUM(B2:B5)` โดยไม่มีเครื่องหมาย `=` นำหน้า การใช้รูปแบบนี้ทำให้สูตรที่สร้างสอดคล้องกับตัวอย่างในเอกสาร API อย่างชัดเจน