---
title: ใช้สูตรแผ่นงานแผนภูมิในงานนำเสนอด้วย JavaScript
linktitle: สูตรแผ่นงาน
type: docs
weight: 70
url: /th/nodejs-java/chart-worksheet-formulas/
keywords:
- สเปรดชีตแผนภูมิ
- แผ่นงานแผนภูมิ
- สูตรแผนภูมิ
- สูตรแผ่นงาน
- สูตรสเปรดชีต
- เวิร์กบุ๊กข้อมูลแผนภูมิ
- การคำนวณสูตร
- วัฒนธรรมที่ต้องการ
- สูตรเฉพาะวัฒนธรรม
- DBCS
- ค่าคงที่ตรรกะ
- ค่าคงที่เชิงตัวเลข
- ค่าคงที่สตริง
- ค่าคงที่ข้อผิดพลาด
- ตัวดำเนินการคณิตศาสตร์
- ตัวดำเนินการเปรียบเทียบ
- รูปแบบ A1
- รูปแบบ R1C1
- ฟังก์ชันกำหนดล่วงหน้า
- PowerPoint
- งานนำเสนอ
- Node.js
- JavaScript
- Aspose.Slides
description: "ใช้สูตรแบบ Excel ใน Aspose.Slides สำหรับ Node.js ผ่านแผ่นงานแผนภูมิ Java, คำนวณค่าซ้ำ และใช้ผลลัพธ์ในแผนภูมิ PowerPoint"
---
## **ภาพรวม**

แผนภูมิ PowerPoint มักจัดเก็บข้อมูลต้นทางไว้ในเวิร์กชีตที่ฝังอยู่ ใน Aspose.Slides สำหรับ Node.js ผ่าน Java คุณสามารถเข้าถึงเวิร์กชีตนั้นผ่าน ChartDataWorkbook, เขียนค่าตัวอินพุต, กำหนดสูตรให้กับเซลล์, คำนวณสูตรที่สนับสนุน, และใช้เซลล์ที่คำนวณแล้วเป็นข้อมูลแผนภูมิได้

บทความนี้อธิบายกระบวนการทำงานของสูตรอย่างครบถ้วน: สร้างแผนภูมิ, เติมข้อมูลในเวิร์กชีต, กำหนดสูตรแบบ A1 หรือ R1C1, คำนวณใหม่, อ่านค่าที่คำนวณ, เชื่อมต่อเซลล์เหล่านั้นกับซีรีส์ของแผนภูมิ, และบันทึกงานนำเสนอ นอกจากนี้ยังอธิบายไวยากรณ์สูตรที่สนับสนุน, ชุดฟังก์ชันในตัว, ค่าที่แคชไว้, สูตรที่ไม่สนับสนุน, และข้อผิดพลาดเฉพาะสเปรดชีต

## **เวิร์กชีตแผนภูมิและสูตร**

เวิร์กชีตของแผนภูมิประกอบด้วยหมวดหมู่, ชื่อซีรีส์, และค่าที่ใช้โดยแผนภูมิ ใน PowerPoint คุณสามารถตรวจสอบเวิร์กชีตได้โดยเปิด Chart Data Editor:

![PowerPoint chart with its embedded worksheet open, showing category and series data](chart-worksheet-formulas_1.png)

ใน Aspose.Slides, เวิร์กชีตถูกเปิดเผยผ่านคลาส [ChartDataWorkbook](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/chartdataworkbook/) ใช้เมธอด [ChartDataCell.setFormula](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/chartdatacell/#setFormula-java.lang.String-) สำหรับสูตรแบบ A1 และ [ChartDataCell.setR1C1Formula](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/chartdatacell/#setR1C1Formula-java.lang.String-) สำหรับสูตรแบบ R1C1 หลังจากเปลี่ยนเซลล์อินพุตหรือสูตร ให้เรียกเมธอด [ChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/chartdataworkbook/#calculateFormulas--) เพื่อคำนวณสูตรที่สนับสนุนและอัปเดตค่าของเซลล์ที่เกี่ยวข้อง

เซลล์ที่คำนวณแล้วยังคงให้ผลลัพธ์ผ่านเมธอด [ChartDataCell.getValue](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/chartdatacell/#getValue--) สิ่งนี้สำคัญเมื่อคุณต้องตรวจสอบผลลัพธ์ของสูตรในโค้ดหรือใช้เซลล์เป็นจุดข้อมูลของแผนภูมิ

## **สร้างแผนภูมิและคำนวณสูตรในเวิร์กชีต**

ตัวอย่างต่อไปนี้แสดงกระบวนการทำงานจากต้นจนจบ มันสร้างแผนภูมิคอลัมน์แบบคลัสเตอร์, ลบข้อมูลตัวอย่าง, เขียนค่ารายได้และค่าใช้จ่ายไตรมาส, คำนวณกำไรด้วยสูตร, อ่านผลลัพธ์, ใช้เซลล์ที่คำนวณเป็นค่าของแผนภูมิ, แล้วบันทึกงานนำเสนอ

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

จุดข้อมูลของแผนภูมิเก็บอ้างอิง `D2:D4` ดังนั้นแผนภูมิจะใช้ค่ากำไรที่คำนวณแล้ว ในเวิร์กโฟลว์นี้ไม่มีการเรียกเมธอดรีเฟรชแผนภูมิแยกต่างหาก: คำนวณเวิร์กบุ๊กก่อน, จากนั้นใช้หรือบันทึกข้อมูลแผนภูมิที่อ้างอิงเซลล์ที่คำนวณ

## **ใช้สูตรแบบ A1**

การอ้างอิงแบบ A1 ระบุคอลัมน์ด้วยตัวอักษรและแถวด้วยตัวเลข กำหนดนิพจน์แบบ A1 ผ่านเมธอด [ChartDataCell.setFormula](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/chartdatacell/#setFormula-java.lang.String-)

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

รูปแบบการอ้างอิง A1 ที่พบบ่อยมีดังนี้

| อ้างอิง | สัมพัทธ์ | คงที่ | ผสม |
|---|---|---|---|
| Cell | `A2` | `$A$2` | `A$2`, `$A2` |
| Row | `2:2` | `$2:$2` | — |
| Column | `A:A` | `$A:$A` | — |
| Range | `A2:C4` | `$A$2:$C$4` | `A$2:$C4`, `$A2:C$4` |

การอ้างอิงสัมพัทธ์อาจเปลี่ยนเมื่อสูตรถูกย้ายหรือคัดลอกโดยแอปพลิเคชันสเปรดชีต การอ้างอิงคงที่จะคงค่าพิกัดทั้งสองไว้ ส่วนการอ้างอิงผสมจะคงแค่แถวหรือคอลัมน์หนึ่งเท่านั้น

## **ใช้สูตรแบบ R1C1**

การอ้างอิงแบบ R1C1 ระบุทั้งแถวและคอลัมน์เป็นตัวเลข การอ้างอิงสัมพัทธ์ใช้การชดเชยในวงเล็บสี่เหลี่ยม กำหนดไวยากรณ์นี้ผ่านเมธอด [ChartDataCell.setR1C1Formula](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/chartdatacell/#setR1C1Formula-java.lang.String-)

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

รูปแบบการอ้างอิง R1C1 ที่พบบ่อยมีดังนี้

| อ้างอิง | สัมพัทธ์ | คงที่ | ผสม |
|---|---|---|---|
| Cell | `R[2]C[3]` | `R2C3` | `R2C[3]`, `R[2]C3` |
| Row | `R[2]` | `R2` | — |
| Column | `C[3]` | `C3` | — |
| Range | `R[2]C[3]:R[5]C[7]` | `R2C3:R5C7` | `R2C3:R[5]C[7]`, `R[2]C3:R5C[7]` |

ตัวอย่างเช่น ในเซลล์ `D2` `RC[-2]` หมายถึงเซลล์ในแถวเดียวกันสองคอลัมน์ทางซ้าย (`B2`)

## **ค่าคงที่และตัวดำเนินการของสูตร**

ตัวประเมินสูตรในตัวสนับสนุนค่าตรรกะ, ลิเทรัลตัวเลข, สตริง, ค่าข้อผิดพลาดของสเปรดชีต, ตัวดำเนินการคณิตศาสตร์, และตัวดำเนินการเปรียบเทียบ

### **ค่าคงที่และลิเทรัล**

| ประเภท | ตัวอย่าง | หมายเหตุ |
|---|---|---|
| Logical | `TRUE`, `FALSE` | สามารถใช้โดยตรงในนิพจน์ตรรกะเช่น `A2=TRUE` |
| Numeric | `1`, `0.5`, `.3`, `1E-2` | รองรับการเขียนแบบธรรมดาและวิทยาศาสตร์ |
| String | `"abc"`, `"2/3/2020 12:00"` | ลิเทรัลข้อความต้องอยู่ในเครื่องหมายคำพูดคู่ภายในสูตร |
| Error result | `#DIV/0!`, `#N/A`, `#REF!` | สูตรที่สมบูรณ์สามารถประเมินเป็นค่าข้อผิดพลาดของสเปรดชีตแทนผลลัพธ์ปกติได้ |

ตัวอย่างนี้ใช้ค่าคงที่หลายประเภท

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
| `+` | การบวกหรือเครื่องหมายบวกเชิงยูเนอรี | `2+3` |
| `-` | การลบหรือการกลับเครื่องหมาย | `2-3`, `-3` |
| `*` | การคูณ | `2*3` |
| `/` | การหาร | `2/3` |
| `%` | เปอร์เซ็นต์ | `30%` |
| `^` | ยกกำลัง | `2^3` |

ใช้วงเล็บเพื่อทำให้ลำดับการประเมินชัดเจน เช่น `(A2+B2)*C2`

### **ตัวดำเนินการเปรียบเทียบ**

การเปรียบเทียบส่งคืนค่าตรรกะ

| ตัวดำเนินการ | ความหมาย | ตัวอย่าง |
|---|---|---|
| `=` | เท่ากับ | `A2=3` |
| `<>` | ไม่เท่ากับ | `A2<>3` |
| `>` | มากกว่า | `A2>3` |
| `>=` | มากกว่าหรือเท่ากับ | `A2>=3` |
| `<` | น้อยกว่า | `A2<3` |
| `<=` | น้อยกว่าหรือเท่ากับ | `A2<=3` |

## **ฟังก์ชันที่กำหนดล่วงหน้าที่สนับสนุน**

Aspose.Slides มีตัวประเมินสูตรในตัวสำหรับเวิร์กชีตของแผนภูมิ แต่ไม่ใช่เครื่องมือคำนวณ Excel แบบเต็ม ชุดฟังก์ชันที่ถูกบันทึกไว้จำกัดอยู่เพียงฟังก์ชันต่อไปนี้ อย่า Assume ว่า Excel ฟังก์ชันใดๆ สามารถคำนวณใหม่ด้วย [ChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/chartdataworkbook/#calculateFormulas--) ได้

| ฟังก์ชัน | วัตถุประสงค์หรือรูปแบบที่สนับสนุน | ตัวอย่าง |
|---|---|---|
| `ABS` | Absolute value | `ABS(A2)` |
| `AVERAGE` | Arithmetic mean | `AVERAGE(B2:B5)` |
| `CEILING` | Round a number upward to a multiple | `CEILING(A2,5)` |
| `CHOOSE` | Select a value by index | `CHOOSE(A2,"Low","High")` |
| `CONCAT` | Join text values | `CONCAT(A2,B2)` |
| `CONCATENATE` | Join text values | `CONCATENATE(A2," ",B2)` |
| `DATE` | Create a date value using the 1900 date system | `DATE(2026,8,19)` |
| `DAYS` | Return the number of days between dates | `DAYS(B2,A2)` |
| `FIND` | Find one text value inside another | `FIND("-",A2)` |
| `FINDB` | Byte-oriented text search | `FINDB("a",A2)` |
| `IF` | Conditional result | `IF(A2>0,A2,0)` |
| `INDEX` | Reference form | `INDEX(A2:C4,2,3)` |
| `LOOKUP` | Vector form | `LOOKUP(A2,B2:B5,C2:C5)` |
| `MATCH` | Vector form | `MATCH(A2,B2:B5,0)` |
| `MAX` | Maximum value | `MAX(B2:B5)` |
| `SUM` | Sum values | `SUM(B2:B5)` |
| `VLOOKUP` | Vertical lookup | `VLOOKUP(A2,B2:D10,3,FALSE)` |

ข้อจำกัดที่แสดงในตารางมีความสำคัญ: `INDEX` ถูกบันทึกในรูปแบบอ้างอิง, ในขณะที่ `LOOKUP` และ `MATCH` เป็นรูปแบบเวกเตอร์ `DATE` ใช้ระบบวันที่ 1900 ฟีเจอร์และฟังก์ชันที่ไม่ได้ระบุที่นี่ควรถือว่าไม่สนับสนุนโดยตัวประเมินสูตรของ Aspose.Slides เว้นแต่จะมีการบันทึกไว้แยกต่างหาก

## **คำนวณสูตรด้วยวัฒนธรรมที่ต้องการ**

ฟังก์ชันบางอย่างของเวิร์กบุ๊กแผนภูมิอาจตีความข้อความตามกฎของวัฒนธรรมเฉพาะ นี่สำคัญโดยเฉพาะสำหรับฟังก์ชันที่ออกแบบมาสำหรับภาษาที่ใช้ชุดอักขระสองไบต์ (DBCS) เพื่อคำนวณสูตรเหล่านี้อย่างถูกต้อง ให้สร้าง [LoadOptions](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/loadoptions/), ตั้งวัฒนธรรมที่ต้องการด้วยเมธอด [SpreadsheetOptions.setPreferredCulture](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/spreadsheetoptions/#setPreferredCulture), กำหนดตัวเลือกสเปรดชีตผ่านเมธอด [LoadOptions.setSpreadsheetOptions](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/loadoptions/#setSpreadsheetOptions), จากนั้นโหลดงานนำเสนอ

ตัวอย่างต่อไปนี้เลือกวัฒนธรรมญี่ปุ่น, เปิดงานนำเสนอด้วย LoadOptions ที่กำหนด, แล้วเรียกเมธอด [ChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/chartdataworkbook/#calculateFormulas--) สำหรับทุกเวิร์กบุ๊กแผนภูมิ

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const japaneseCulture = java.newInstanceSync("java.util.Locale", "ja", "JP");

const spreadsheetOptions = new aspose.slides.SpreadsheetOptions();
spreadsheetOptions.setPreferredCulture(japaneseCulture);

const loadOptions = new aspose.slides.LoadOptions();
loadOptions.setSpreadsheetOptions(spreadsheetOptions);

const presentation = new aspose.slides.Presentation("presentation.pptx", loadOptions);
try {
    const slides = presentation.getSlides();
    for (let slideIndex = 0; slideIndex < slides.size(); slideIndex++) {
        const shapes = slides.get_Item(slideIndex).getShapes();
        for (let shapeIndex = 0; shapeIndex < shapes.size(); shapeIndex++) {
            const shape = shapes.get_Item(shapeIndex);
            if (java.instanceOf(shape, "com.aspose.slides.IChart")) {
                shape.getChartData().getChartDataWorkbook().calculateFormulas();
            }
        }
    }
} finally {
    presentation.dispose();
}
```

วัฒนธรรมที่ต้องการเป็นส่วนหนึ่งของการกำหนดค่าการโหลดงานนำเสนอ ดังนั้นให้ระบุก่อนสร้างอินสแตนซ์ [Presentation](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/presentation/) ใช้วัฒนธรรมที่สูตรเวิร์กบุ๊กคาดหวัง; ตัวอย่างเช่นใช้ `ja-JP` สำหรับสูตรที่ต้องการกฎการคำนวณ DBCS ของญี่ปุ่น

## **การคำนวณใหม่และค่าที่แคชไว้**

ไฟล์สเปรดชีตมักเก็บทั้งสูตรและค่าที่คำนวณล่าสุด Aspose.Slides จึงสามารถอ่านค่าที่แคชไว้จากเมธอด [ChartDataCell.getValue](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/chartdatacell/#getValue--) เมื่อโหลดงานนำเสนอและข้อมูลแผนภูมิที่เกี่ยวข้องไม่ได้ถูกเปลี่ยน

หลังจากเปลี่ยนเซลล์อินพุตหรือสูตร อย่าพึ่งพาผลลัพธ์ที่แคชเก่า ให้เรียกเมธอด [ChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/chartdataworkbook/#calculateFormulas--) ก่อนอ่านค่าที่คำนวณหรือบันทึกข้อมูลแผนภูมิที่ขึ้นกับค่าเหล่านั้น

สำหรับสูตรที่อยู่นอกชุดที่สนับสนุน Aspose.Slides อาจไม่สามารถพาร์สสูตรหรือระบุการพึ่งพาได้ หากเวิร์กบุ๊กถูกแก้ไขค่าที่แคชไว้ก่อนหน้านี้จะไม่เชื่อถือได้อีกแล้ว ในกรณีนั้น การอ่านค่าของเซลล์ที่มีสูตรที่ไม่สนับสนุนอาจทำให้เกิดข้อยกเว้น [CellUnsupportedDataException](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/cellunsupporteddataexception/)

หากแผนภูมิของคุณพึ่งพาฟังก์ชัน Excel ที่ Aspose.Slides ไม่ประเมิน ให้คำนวณสูตรเหล่านั้นด้วยเครื่องมือสเปรดชีตที่สนับสนุนแล้วเขียนค่าที่ได้กลับไปยังเวิร์กบุ๊กแผนภูมิ อย่าแทนที่สูตรที่ไม่สนับสนุนด้วยค่าที่คาดเดา

## **จัดการข้อผิดพลาดของสูตร**

มีสองประเภทของปัญหาที่ต้องแยกแยะ

สูตรอาจถูกต้องแต่ให้ผลลัพธ์เป็นข้อผิดพลาดของสเปรดชีต เช่น `#DIV/0!`, `#N/A`, `#NAME?`, `#NULL!`, `#NUM!`, `#REF!`, หรือ `#VALUE!` ในกรณีนี้โทเคนข้อผิดพลาดเป็นผลลัพธ์ของเซลล์และสามารถส่งกลับผ่านเมธอด [ChartDataCell.getValue](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/chartdatacell/#getValue--)

สูตรอาจล้มเหลวในขั้นตอนการพาร์ส, การอ้างอิง, การพึ่งพา, หรือระดับข้อมูลที่สนับสนุน Aspose.Slides ให้ข้อยกเว้นเฉพาะสเปรดชีตสำหรับกรณีเหล่านี้ ได้แก่ [CellInvalidFormulaException](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/cellinvalidformulaexception/), [CellInvalidReferenceException](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/cellinvalidreferenceexception/), [CellCircularReferenceException](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/cellcircularreferenceexception/), และ [CellUnsupportedDataException](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/cellunsupporteddataexception/)

เมื่อสูตรมาจากเทมเพลตหรืออินพุตของผู้ใช้ ควรดักจับข้อผิดพลาดรอบการคำนวณใหม่และการเข้าถึงค่า รายละเอียดข้อผิดพลาดจะแจ้งปัญหาสเปรดชีตเบื้องลึก

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

การสนับสนุนสูตรในเวิร์กชีตของแผนภูมิออกแบบมาสำหรับชุดย่อยที่กำหนดไว้ ไม่ใช่เพื่อความเข้ากันได้เต็มรูปแบบกับ Excel ควรคำนึงถึงข้อจำกัดเหล่านี้เมื่อออกแบบกระบวนการรายงาน:

- ใช้ค่าคงที่, ตัวดำเนินการ, การอ้างอิง, และฟังก์ชันที่บันทึกไว้เท่านั้นเมื่อคุณต้องการให้ Aspose.Slides คำนวณสูตรใหม่
- คำนวณใหม่หลังจากแก้ไขเซลล์ที่ผลลัพธ์สูตรอิงถึง
- ถือค่าที่แคชจากงานนำเข้าที่โหลดเป็นภาพถ่าย ณ ขณะนั้น ไม่ใช่การแทนที่การคำนวณใหม่หลังแก้ไข
- ทดสอบสูตรจากเทมเพลตที่มีอยู่ก่อนพึ่งพาค่าที่คำนวณ, โดยเฉพาะเมื่อใช้ฟังก์ชันที่อยู่นอกรายการที่บันทึกไว้
- สำหรับสูตรที่ต้องการเครื่องมือคำนวณสเปรดชีตเต็มรูปแบบ ให้คำนวณภายนอกแล้วอัปเดตเวิร์กบุ๊กแผนภูมิกับค่าที่ได้

## **คำถามที่พบบ่อย**

**ความแตกต่างระหว่าง [ChartDataCell.setFormula](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/chartdatacell/#setFormula-java.lang.String-) และ [ChartDataCell.setR1C1Formula](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/chartdatacell/#setR1C1Formula-java.lang.String-) คืออะไร?**

[ChartDataCell.setFormula](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/chartdatacell/#setFormula-java.lang.String-) เก็บนิพจน์แบบ A1 เช่น `B2-C2` ส่วน [ChartDataCell.setR1C1Formula](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/chartdatacell/#setR1C1Formula-java.lang.String-) เก็บนิพจน์แบบ R1C1 เช่น `RC[-2]-RC[-1]` ให้ใช้รูปแบบที่สอดคล้องกับวิธีที่คุณสร้างหรือคัดลอกสูตร

**ฉันต้องอ่านเซลล์เองหรือค่าในเซลล์หลังการคำนวณหรือไม่?**

[ChartDataWorkbook.getCell](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/chartdataworkbook/#getCell-int-java.lang.String-) ส่งคืนวัตถุ [ChartDataCell](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/chartdatacell/) เพื่อรับผลลัพธ์ที่คำนวณ ให้เรียกเมธอด [ChartDataCell.getValue](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/chartdatacell/#getValue--) ของเซลล์นั้นหลังการคำนวณใหม่

**ควรเรียก [ChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/chartdataworkbook/#calculateFormulas--) เวลาใด?**

ให้เรียก [ChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/chartdataworkbook/#calculateFormulas--) หลังจากเปลี่ยนค่าตัวอินพุตหรือสูตร และก่อนที่คุณจะพึ่งพาผลลัพธ์ที่คำนวณ ซึ่งจะอัปเดตค่าของสูตรที่ตัวประเมินในตัวสนับสนุน

**Aspose.Slides สนับสนุนทุกฟังก์ชันของ Excel หรือไม่?**

ไม่ ตัวประเมินในตัวสนับสนุนเพียงชุดฟังก์ชันที่บันทึกไว้ ฟังก์ชันที่อยู่นอกชุดนั้นไม่ควรสมมติว่าจะคำนวณใหม่ได้อย่างถูกต้อง หากต้องการความเข้ากันได้เต็มรูปแบบกับสูตร Excel ให้ทำการคำนวณด้วยเครื่องมือสเปรดชีตที่เหมาะสมแล้วเขียนค่าที่ได้ลงในเวิร์กบุ๊กแผนภูมิ

**จะเกิดอะไรขึ้นหากงานนำเข้าที่โหลดมีสูตรที่ไม่สนับสนุน?**

หากข้อมูลแผนภูมิไม่เปลี่ยนแปลง เวิร์กบุ๊กอาจยังคงมีค่าที่แคชจากการคำนวณก่อนหน้า หลังจากข้อมูลที่เกี่ยวข้องถูกแก้ไข ค่าที่แคชนั้นอาจไม่ถูกต้องอีกต่อไป การเข้าถึงเซลล์ที่สูตรไม่สามารถจัดการได้อาจทำให้เกิดข้อยกเว้น [CellUnsupportedDataException](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/cellunsupporteddataexception/)

**ค่าข้อผิดพลาดของสูตรคือเดียวกับข้อยกเว้นหรือไม่?**

ไม่ ผลลัพธ์เช่น `#DIV/0!` เป็นค่าของสเปรดชีตที่เกิดจากการคำนวณที่ถูกต้อง ส่วนข้อยกเว้นเช่น [CellInvalidFormulaException](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/cellinvalidformulaexception/) หรือ [CellCircularReferenceException](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/cellcircularreferenceexception/) ระบุว่ารูปแบบสูตรไม่สามารถประมวลผลได้ตามปกติ

**แผนภูมิจะอัปเดตอัตโนมัติเมื่อเซลล์สูตรเปลี่ยนหรือไม่?**

ซีรีส์ของแผนภูมิสามารถอ้างอิงเซลล์ในเวิร์กบุ๊กได้ ให้คำนวณเวิร์กบุ๊กก่อน แล้วบันทึกหรือเรนเดอร์งานนำเสนอ หากจุดข้อมูลของแผนภูมิเก็บอ้างอิงเซลล์ที่คำนวณแล้ว แผนภูมิจะใช้ค่าที่อัปเดตเหล่านั้น; ไม่จำเป็นต้องเรียกเมธอดรีเฟรชแผนภูมิแยกต่างหากสำหรับเวิร์กโฟลว์นี้

**แผนภูมิสามารถใช้เวิร์กบุ๊ก Excel ภายนอกได้หรือไม่?**

ได้ ข้อมูลแผนภูมิสามารถกำหนดค่าให้ใช้เวิร์กบุ๊กภายนอกผ่าน API ของข้อมูลแผนภูมิได้ อย่างไรก็ตาม กระบวนการคำนวณสูตรที่อธิบายในบทความนี้เกี่ยวกับเวิร์กบุ๊กข้อมูลแผนภูมิและชุดสูตรที่ Aspose.Slides ประเมิน ไม่ควรสมมติว่า [ChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/chartdataworkbook/#calculateFormulas--) ให้การคำนวณเต็มรูปแบบของสูตรใดๆ ในไฟล์ XLSX ภายนอก

**ฉันสามารถใช้สูตรที่อ้างอิงเวิร์กชีตหรือเวิร์กบุ๊กอื่นได้หรือไม่?**

การอ้างอิงแบบ Excel อาจมีอยู่ในเวิร์กบุ๊กแผนภูมิ แต่การประเมินสูตรถูกจำกัดโดยพาร์สเซอร์และชุดฟังก์ชันที่สนับสนุน หากการอ้างอิงข้ามชีตหรือภายนอกเป็นสิ่งสำคัญ ให้ตรวจสอบสูตรนั้นกับเวอร์ชัน Aspose.Slides ที่คุณใช้ สำหรับเวิร์กโฟลว์ที่ต้องการความเข้ากันได้กับการอ้างอิง Excel อย่างกว้างขวาง ให้คำนวณเวิร์กบุ๊กภายนอกแล้วเขียนค่าที่ได้กลับไปยังข้อมูลแผนภูมิ

**สูตรควรเริ่มด้วย `=` หรือไม่?**

ตัวอย่าง API ของ Aspose.Slides กำหนดนิพจน์เช่น `B2-C2` หรือ `SUM(B2:B5)` โดยไม่มี `=` นำหน้า การใช้รูปแบบนี้ทำให้สูตรที่สร้างสอดคลคล้องกับตัวอย่าง API ที่บันทึกไว้