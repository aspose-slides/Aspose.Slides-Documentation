---
title: ใช้สูตรแผ่นงานแผนภูมิในงานนำเสนอบน Android
linktitle: สูตรแผ่นงาน
type: docs
weight: 70
url: /th/androidjava/chart-worksheet-formulas/
keywords:
- แผนภูมิสเปรดชีต
- แผ่นงานแผนภูมิ
- สูตรแผนภูมิ
- สูตรแผ่นงาน
- สูตรสเปรดชีต
- สมุดงานข้อมูลแผนภูมิ
- การคำนวณสูตร
- ค่าคงที่ตรรกะ
- ค่าคงที่จำนวน
- ค่าคงที่สตริง
- ค่าคงที่ข้อผิดพลาด
- ตัวดำเนินการคณิตศาสตร์
- ตัวดำเนินการเปรียบเทียบ
- สไตล์ A1
- สไตล์ R1C1
- ฟังก์ชันที่กำหนดล่วงหน้า
- PowerPoint
- งานนำเสนอ
- Android
- Java
- Aspose.Slides
description: "ใช้สูตรสไตล์ Excel ใน Aspose.Slides สำหรับ Android ผ่านแผ่นงานแผนภูมิ Java, คำนวณค่าซ้ำและใช้ผลลัพธ์ในแผนภูมิ PowerPoint."
---
## **ภาพรวม**

PowerPoint charts ส่วนใหญ่จะเก็บข้อมูลต้นฉบับไว้ในแผ่นงานที่ฝังอยู่ ใน Aspose.Slides สำหรับ Android ผ่าน Java คุณสามารถเข้าถึงแผ่นงานนั้นผ่าน workbook ของข้อมูลแผนภูมิ, เขียนค่าป้อนเข้า, กำหนดสูตรให้กับเซลล์, คำนวณสูตรที่รองรับ, และใช้เซลล์ที่คำนวณแล้วเป็นข้อมูลสำหรับแผนภูมิ

บทความนี้อธิบายขั้นตอนการทำงานของสูตรอย่างครบถ้วน: สร้างแผนภูมิ, เติมข้อมูลในแผ่นงาน, กำหนดสูตรแบบ A1 หรือ R1C1, คำนวณสูตรใหม่, อ่านค่าที่คำนวณ, เชื่อมต่อเซลล์เหล่านั้นกับชุดข้อมูลของแผนภูมิ, และบันทึกงานนำเสนอ นอกจากนี้ยังอธิบายไวยากรณ์สูตรที่สนับสนุน ชุดฟังก์ชันที่ทำมาในตัว ค่าแคช สูตรที่ไม่สนับสนุน และข้อผิดพลาดเฉพาะของสเปรดชีต

## **แผ่นงานแผนภูมิและสูตร**

ใน Aspose.Slides, แผ่นงานถูกเปิดเผยผ่านอินเทอร์เฟซ [IChartDataWorkbook](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ichartdataworkbook/)

ใช้ [IChartDataCell.setFormula](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ichartdatacell/#setFormula-java.lang.String-) สำหรับสูตรแบบ A1 และ [IChartDataCell.setR1C1Formula](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ichartdatacell/#setR1C1Formula-java.lang.String-) สำหรับสูตรแบบ R1C1 หลังจากเปลี่ยนเซลล์ป้อนข้อมูลหรือสูตรให้เรียก [IChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ichartdataworkbook/#calculateFormulas--) เพื่อคำนวณสูตรที่รองรับและอัพเดตค่าของเซลล์ที่เกี่ยวข้อง

เซลล์ที่คำนวณแล้วยังคงเปิดเผยผลลัพธ์ผ่าน [IChartDataCell.getValue](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ichartdatacell/#getValue--) ซึ่งสำคัญเมื่อคุณต้องการตรวจสอบผลลัพธ์ของสูตรในโค้ดหรือใช้เซลล์เป็นจุดข้อมูลของแผนภูมิ

![แผนภูมิ PowerPoint พร้อมเปิดแผ่นงานที่ฝังอยู่, แสดงข้อมูลประเภทและชุดข้อมูล](chart-worksheet-formulas_1.png)

## **สร้างแผนภูมิและคำนวณสูตรในแผ่นงาน**

ตัวอย่างต่อไปนี้สาธิตขั้นตอนทำงานตั้งแต่ต้นจนจบ มันสร้างแผนภูมิคอลัมน์แบบคลัสเตอร์, ลบข้อมูลตัวอย่าง, เขียนค่ารายได้และค่าใช้จ่ายต่อไตรมาส, คำนวณกำไรด้วยสูตร, อ่านผลลัพธ์, ใช้เซลล์ที่คำนวณแล้วเป็นค่าของแผนภูมิ, และบันทึกงานนำเสนอ

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 350);
    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    int worksheetIndex = 0;

    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();
    workbook.clear(worksheetIndex);

    IChartDataCell category1 = workbook.getCell(worksheetIndex, "A2", "Q1");
    IChartDataCell category2 = workbook.getCell(worksheetIndex, "A3", "Q2");
    IChartDataCell category3 = workbook.getCell(worksheetIndex, "A4", "Q3");

    workbook.getCell(worksheetIndex, "B1", "Revenue");
    workbook.getCell(worksheetIndex, "C1", "Expenses");
    workbook.getCell(worksheetIndex, "D1", "Profit");

    workbook.getCell(worksheetIndex, "B2").setValue(120.0);
    workbook.getCell(worksheetIndex, "C2").setValue(80.0);
    workbook.getCell(worksheetIndex, "B3").setValue(150.0);
    workbook.getCell(worksheetIndex, "C3").setValue(95.0);
    workbook.getCell(worksheetIndex, "B4").setValue(135.0);
    workbook.getCell(worksheetIndex, "C4").setValue(110.0);

    IChartDataCell profit1 = workbook.getCell(worksheetIndex, "D2");
    IChartDataCell profit2 = workbook.getCell(worksheetIndex, "D3");
    IChartDataCell profit3 = workbook.getCell(worksheetIndex, "D4");

    profit1.setFormula("B2-C2");
    profit2.setFormula("B3-C3");
    profit3.setFormula("B4-C4");

    workbook.calculateFormulas();

    double q1Profit = ((Number) profit1.getValue()).doubleValue(); // 40
    double q2Profit = ((Number) profit2.getValue()).doubleValue(); // 55
    double q3Profit = ((Number) profit3.getValue()).doubleValue(); // 25

    System.out.println("Q1 profit: " + q1Profit);
    System.out.println("Q2 profit: " + q2Profit);
    System.out.println("Q3 profit: " + q3Profit);

    chart.getChartData().getCategories().add(category1);
    chart.getChartData().getCategories().add(category2);
    chart.getChartData().getCategories().add(category3);

    IChartSeries profitSeries = chart.getChartData().getSeries().add(workbook.getCell(worksheetIndex, "D1"), chart.getType());
    profitSeries.getDataPoints().addDataPointForBarSeries(profit1);
    profitSeries.getDataPoints().addDataPointForBarSeries(profit2);
    profitSeries.getDataPoints().addDataPointForBarSeries(profit3);
    profitSeries.getLabels().getDefaultDataLabelFormat().setShowValue(true);

    presentation.save("chart-formulas.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

จุดข้อมูลของแผนภูมิอ้างอิง `D2:D4` ดังนั้นแผนภูมิจึงใช้ค่ากำไรที่คำนวณแล้ว ไม่มีการเรียกรีเฟรชแผนภูมิแยกต่างหากในขั้นตอนนี้: คำนวณ workbook ก่อน, จากนั้นใช้หรือบันทึกข้อมูลแผนภูมิที่ชี้ไปยังเซลล์ที่คำนวณ

## **ใช้สูตรแบบ A1**

A1 notation ระบุคอลัมน์ด้วยตัวอักษรและแถวด้วยตัวเลข กำหนดนิพจน์แบบ A1 ผ่าน [IChartDataCell.setFormula](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ichartdatacell/#setFormula-java.lang.String-)

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 500, 300);
    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();

    workbook.getCell(0, "C3").setValue(10);
    workbook.getCell(0, "F2").setValue(2);
    workbook.getCell(0, "G2").setValue(3);
    workbook.getCell(0, "H2").setValue(4);

    IChartDataCell cell = workbook.getCell(0, "A2");
    cell.setFormula("C3+SUM(F2:H2)");

    workbook.calculateFormulas();

    Object value = cell.getValue(); // 19
} finally {
    presentation.dispose();
}
```

รูปแบบการอ้างอิง A1 ที่พบบ่อยมีดังนี้:

| อ้างอิง | สัมพัทธ์ | แน่นอน | ผสม |
|---|---|---|---|
| เซลล์ | `A2` | `$A$2` | `A$2`, `$A2` |
| แถว | `2:2` | `$2:$2` | — |
| คอลัมน์ | `A:A` | `$A:$A` | — |
| ช่วง | `A2:C4` | `$A$2:$C$4` | `A$2:$C4`, `$A2:C$4` |

การอ้างอิงแบบสัมพัทธ์อาจเปลี่ยนแปลงเมื่อสูตรถูกย้ายหรือคัดลอกโดยแอปพลิเคชันสเปรดชีต การอ้างอิงแบบแน่นอนจะคงค่าพิกัดทั้งสองคงที่ ส่วนการอ้างอิงแบบผสมจะคงที่เฉพาะแถวหรือคอลัมน์หนึ่งเท่านั้น

## **ใช้สูตรแบบ R1C1**

R1C1 notation ระบุทั้งแถวและคอลัมน์เป็นตัวเลข การอ้างอิงแบบสัมพัทธ์ใช้การชดเชยในวงเล็บเหลี่ยม กำหนดไวยากรณ์นี้ผ่าน [IChartDataCell.setR1C1Formula](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ichartdatacell/#setR1C1Formula-java.lang.String-)

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 500, 300);
    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();

    workbook.getCell(0, "B2").setValue(12);
    workbook.getCell(0, "C2").setValue(5);

    IChartDataCell cell = workbook.getCell(0, "D2");
    cell.setR1C1Formula("RC[-2]-RC[-1]");

    workbook.calculateFormulas();

    Object value = cell.getValue(); // 7
} finally {
    presentation.dispose();
}
```

รูปแบบการอ้างอิง R1C1 ที่พบบ่อยมีดังนี้:

| อ้างอิง | สัมพัทธ์ | แน่นอน | ผสม |
|---|---|---|---|
| เซลล์ | `R[2]C[3]` | `R2C3` | `R2C[3]`, `R[2]C3` |
| แถว | `R[2]` | `R2` | — |
| คอลัมน์ | `C[3]` | `C3` | — |
| ช่วง | `R[2]C[3]:R[5]C[7]` | `R2C3:R5C7` | `R2C3:R[5]C[7]`, `R[2]C3:R5C[7]` |

ตัวอย่างเช่น ในเซลล์ `D2` คำว่า `RC[-2]` หมายถึงเซลล์ในแถวเดียวกันสองคอลัมน์ทางซ้าย (`B2`)

## **ค่าคงที่และตัวดำเนินการของสูตร**

ตัวประเมินสูตรในตัวสนับสนุนค่าตรรกะ, ตัวเลขลิเทรัล, สตริง, ค่าข้อผิดพลาดของสเปรดชีต, ตัวดำเนินการคณิตศาสตร์, และตัวดำเนินการเปรียบเทียบ

### **ค่าคงที่และลิเทรัล**

| ประเภท | ตัวอย่าง | หมายเหตุ |
|---|---|---|
| ตรรกะ | `TRUE`, `FALSE` | สามารถใช้โดยตรงในนิพจน์ตรรกะ เช่น `A2=TRUE` |
| จำนวน | `1`, `0.5`, `.3`, `1E-2` | รองรับการเขียนแบบทศนิยมทั่วไปและวิศวกรรม |
| สตริง | `"abc"`, `"2/3/2020 12:00"` | สตริงลิเทรัลจะอยู่ในเครื่องหมายคำพูดสองคู่ภายในสูตร |
| ผลลัพธ์ข้อผิดพลาด | `#DIV/0!`, `#N/A`, `#REF!` | สูตรที่ถูกต้องอาจประเมินผลเป็นค่าข้อผิดพลาดของสเปรดชีตแทนผลลัพธ์ปกติ |

ตัวอย่างนี้ใช้ค่าคงที่หลายประเภท:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 500, 300);
    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();

    workbook.getCell(0, "A2").setValue(false);
    workbook.getCell(0, "B2").setFormula("A2=TRUE");
    workbook.getCell(0, "C2").setFormula("1+0.5");
    workbook.getCell(0, "D2").setFormula(".3*1E-2");
    workbook.getCell(0, "E2").setFormula("\"abc\"");
    workbook.getCell(0, "F2").setFormula("2/0");

    workbook.calculateFormulas();

    Object logicalValue = workbook.getCell(0, "B2").getValue(); // false
    Object numericValue = workbook.getCell(0, "C2").getValue(); // 1.5
    Object scientificValue = workbook.getCell(0, "D2").getValue(); // 0.003
    Object stringValue = workbook.getCell(0, "E2").getValue(); // abc
    Object errorValue = workbook.getCell(0, "F2").getValue(); // #DIV/0!
} finally {
    presentation.dispose();
}
```

### **ตัวดำเนินการคณิตศาสตร์**

| ตัวดำเนินการ | ความหมาย | ตัวอย่าง |
|---|---|---|
| `+` | การบวกหรือบวกเชิงบวก | `2+3` |
| `-` | การลบหรือการทำให้เป็นลบ | `2-3`, `-3` |
| `*` | การคูณ | `2*3` |
| `/` | การหาร | `2/3` |
| `%` | เปอร์เซ็นต์ | `30%` |
| `^` | ยกกำลัง | `2^3` |

ใช้วงเล็บเพื่อบ่งบอกลำดับการประเมินอย่างชัดเจน ตัวอย่างเช่น `(A2+B2)*C2`

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

## **ฟังก์ชันล่วงหน้าที่สนับสนุน**

Aspose.Slides มีตัวประเมินสูตรในตัวสำหรับแผ่นงานแผนภูมิ แต่ไม่ได้เป็นเครื่องยนต์คำนวณ Excel เต็มรูปแบบ ชุดฟังก์ชันที่ระบุไว้จำกัดอยู่ที่ฟังก์ชันด้านล่าง อย่า assume ว่าฟังก์ชัน Excel ใดๆ สามารถคำนวนใหม่ได้ด้วย [IChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ichartdataworkbook/#calculateFormulas--)

| ฟังก์ชัน | วัตถุประสงค์หรือรูปแบบที่สนับสนุน | ตัวอย่าง |
|---|---|---|
| `ABS` | ค่าสัมบูรณ์ | `ABS(A2)` |
| `AVERAGE` | ค่าเฉลี่ยเลขคณิต | `AVERAGE(B2:B5)` |
| `CEILING` | ปัดขึ้นจำนวนให้เป็นหลายของค่า | `CEILING(A2,5)` |
| `CHOOSE` | เลือกค่าตามดัชนี | `CHOOSE(A2,"Low","High")` |
| `CONCAT` | ต่อข้อความ | `CONCAT(A2,B2)` |
| `CONCATENATE` | ต่อข้อความ | `CONCATENATE(A2," ",B2)` |
| `DATE` | สร้างค่าข่าวันโดยใช้ระบบวันที่ 1900 | `DATE(2026,8,19)` |
| `DAYS` | คืนจำนวนวันระหว่างวันที่ | `DAYS(B2,A2)` |
| `FIND` | ค้นหาข้อความหนึ่งภายในอีกข้อความหนึ่ง | `FIND("-",A2)` |
| `FINDB` | การค้นหาข้อความตามไบต์ | `FINDB("a",A2)` |
| `IF` | ผลลัพธ์ตามเงื่อนไข | `IF(A2>0,A2,0)` |
| `INDEX` | รูปแบบอ้างอิง | `INDEX(A2:C4,2,3)` |
| `LOOKUP` | รูปแบบเวกเตอร์ | `LOOKUP(A2,B2:B5,C2:C5)` |
| `MATCH` | รูปแบบเวกเตอร์ | `MATCH(A2,B2:B5,0)` |
| `MAX` | ค่ามากที่สุด | `MAX(B2:B5)` |
| `SUM` | ผลรวมค่า | `SUM(B2:B5)` |
| `VLOOKUP` | การค้นหาแนวตั้ง | `VLOOKUP(A2,B2:D10,3,FALSE)` |

ข้อจำกัดที่แสดงในตารางมีความสำคัญ: `INDEX` ระบุในรูปแบบอ้างอิง, ส่วน `LOOKUP` และ `MATCH` ระบุในรูปแบบเวกเตอร์ `DATE` ใช้ระบบวันที่ 1900 ฟังก์ชันและคุณลักษณะที่ไม่ได้ระบุในที่นี่ควรถือว่าไม่ได้สนับสนุนโดยตัวประเมินสูตรของ Aspose.Slides เว้นแต่จะมีเอกสารแยกต่างหาก

## **การคำนวณใหม่และค่าที่แคช**

ไฟล์สเปรดชีตมักเก็บสูตรและค่าที่คำนวณล่าสุดไว้ Aspose.Slides จึงสามารถอ่านค่าที่แคชจาก [IChartDataCell.getValue](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ichartdatacell/#getValue--) เมื่อโหลดพรีเซนเทชันและข้อมูลแผนภูมิที่เกี่ยวข้องไม่ได้เปลี่ยนแปลง

หลังจากเปลี่ยนเซลล์ป้อนข้อมูลหรือสูตร อย่าอ้างอิงผลลัพธ์แคชเก่า ให้เรียก [IChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ichartdataworkbook/#calculateFormulas--) ก่อนอ่านค่าที่คำนวณหรือบันทึกข้อมูลแผนภูมิที่ขึ้นกับค่าดังกล่าว

สำหรับสูตรที่อยู่นอกชุดที่รองรับ Aspose.Slides อาจไม่สามารถแยกวิเคราะห์สูตรหรือกำหนดการอ้างอิงได้ หาก workbook ถูกแก้ไข ค่าแคชก่อนหน้าอาจไม่เชื่อถือได้ ในกรณีดังกล่าว การอ่านค่าเซลล์ที่มีข้อมูลไม่สนับสนุนอาจทำให้เกิด [CellUnsupportedDataException](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/cellunsupporteddataexception/)

หากแผนภูมิของคุณขึ้นกับฟังก์ชัน Excel ที่ Aspose.Slides ไม่ประเมินค่า ให้คำนวณสูตรเหล่านั้นด้วยเครื่องสเปรดชีตที่สนับสนุนแล้วเขียนค่าที่ได้กลับไปยัง workbook ของแผนภูมิ อย่าทดแทนสูตรที่ไม่สนับสนุนด้วยค่าที่คาดเดา

## **จัดการข้อผิดพลาดของสูตร**

มีปัญหาแบบสองประเภทที่ต้องแยกแยะ

สูตรอาจถูกต้องแต่ให้ผลลัพธ์เป็นค่าข้อผิดพลาดของสเปรดชีต เช่น `#DIV/0!`, `#N/A`, `#NAME?`, `#NULL!`, `#NUM!`, `#REF!`, หรือ `#VALUE!` ในกรณีนี้ โทเคนข้อผิดพลาดคือผลลัพธ์ของเซลล์และสามารถคืนค่าผ่าน [IChartDataCell.getValue](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ichartdatacell/#getValue--) ได้

สูตรอาจล้มเหลวที่ระดับการแยกวิเคราะห์, การอ้างอิง, การพึ่งพา, หรือข้อมูลที่รองรับ Aspose.Slides มีข้อยกเว้นเฉพาะสเปรดชีตสำหรับกรณีเหล่านี้: [CellInvalidFormulaException](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/cellinvalidformulaexception/), [CellInvalidReferenceException](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/cellinvalidreferenceexception/), [CellCircularReferenceException](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/cellcircularreferenceexception/), และ [CellUnsupportedDataException](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/cellunsupporteddataexception/)

เมื่อสูตรมาจากเทมเพลตหรืออินพุตของผู้ใช้ ให้จัดการข้อยกเว้นเหล่านี้รอบการคำนวณใหม่และการเข้าถึงค่า:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 500, 300);
    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    IChartDataCell cell = workbook.getCell(0, "A2");
    cell.setFormula("SUM(B2:B5)");

    try {
        workbook.calculateFormulas();
        System.out.println(cell.getValue());
    } catch (CellInvalidFormulaException ex) {
        System.err.println("Invalid formula: " + ex.getMessage());
    } catch (CellInvalidReferenceException ex) {
        System.err.println("Invalid cell reference: " + ex.getMessage());
    } catch (CellCircularReferenceException ex) {
        System.err.println("Circular reference: " + ex.getMessage());
    } catch (CellUnsupportedDataException ex) {
        System.err.println("Unsupported spreadsheet data: " + ex.getMessage());
    }
} finally {
    presentation.dispose();
}
```

## **ข้อจำกัดเชิงปฏิบัติ**

การสนับสนุนสูตรในแผ่นงานแผนภูมิถูกออกแบบมาสำหรับชุดส่วนย่อยของการคำนวณสเปรดชีต ไม่ใช่เพื่อความเข้ากันได้เต็มรูปแบบกับ Excel ให้คำนึงถึงข้อจำกัดเหล่านี้เมื่อตั้งค่าเวิร์กโฟลว์การรายงาน:

- ใช้เฉพาะค่าคงที่, ตัวดำเนินการ, การอ้างอิงและฟังก์ชันที่ระบุในเอกสารเมื่อคุณต้องการให้ Aspose.Slides คำนวณสูตรใหม่
- คำนวณใหม่หลังจากเปลี่ยนเซลล์ที่สูตรอ้างอิง
- พิจารณาค่าที่แคชจากพรีเซนเทชันที่โหลดเป็นภาพถ่าย, ไม่ใช่การแทนที่การคำนวณใหม่หลังแก้ไข
- ทดสอบสูตรจากเทมเพลตที่มีอยู่ก่อนพึ่งพาค่าที่คำนวณ, โดยเฉพาะอย่างยิ่งเมื่อใช้ฟังก์ชันที่อยู่นอกรายการที่ระบุ
- สำหรับสูตรที่ต้องการเครื่องคำนวณสเปรดชีตเต็ม, คำนวณภายนอกแล้วอัปเดต workbook ของแผนภูมิด้วยค่าที่ได้

## **คำถามที่พบบ่อย**

**ความแตกต่างระหว่าง [IChartDataCell.setFormula](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ichartdatacell/#setFormula-java.lang.String-) กับ [IChartDataCell.setR1C1Formula](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ichartdatacell/#setR1C1Formula-java.lang.String-) คืออะไร?**

[IChartDataCell.setFormula](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ichartdatacell/#setFormula-java.lang.String-) เก็บนิพจน์แบบ A1 เช่น `B2-C2` ส่วน [IChartDataCell.setR1C1Formula](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ichartdatacell/#setR1C1Formula-java.lang.String-) เก็บนิพจน์แบบ R1C1 เช่น `RC[-2]-RC[-1]` ใช้แบบที่ตรงกับวิธีที่คุณสร้างหรือคัดลอกสูตร

**ต้องอ่านเซลล์เองหรือค่าของเซลล์หลังการคำนวณหรือไม่?**

[IChartDataWorkbook.getCell](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ichartdataworkbook/#getCell-int-java.lang.String-) คืนค่าเป็น [IChartDataCell](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ichartdatacell/) เพื่อรับผลลัพธ์ที่คำนวณ ให้เรียกเมธอด [IChartDataCell.getValue](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ichartdatacell/#getValue--) ของเซลล์นั้นหลังจากคำนวณใหม่

**ควรเรียก [IChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ichartdataworkbook/#calculateFormulas--) เมื่อไร?**

เรียก [IChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ichartdataworkbook/#calculateFormulas--) หลังจากเปลี่ยนค่าป้อนหรือสูตร และก่อนที่คุณจะพึ่งพาผลลัพธ์ที่คำนวณ ซึ่งจะอัปเดตค่าของสูตรที่ตัวประเมินในตัวรองรับ

**Aspose.Slides สนับสนุนทุกฟังก์ชันของ Excel หรือไม่?**

ไม่ ตัวประเมินในตัวสนับสนุนเพียงชุดฟังก์ชันที่ระบุในเอกสาร ฟังก์ชันที่อยู่นอกชุดนั้นไม่ควรถือว่าคำนวณได้อย่างถูกต้อง หากต้องการความเข้ากันได้เต็มรูปแบบของสูตร Excel ให้ทำการคำนวณด้วยเครื่องสเปรดชีตที่เหมาะสมและเขียนค่าที่ได้ลงใน workbook ของแผนภูมิ

**อะไรจะเกิดขึ้นหากพรีเซนเทชันที่โหลดมามีสูตรที่ไม่สนับสนุน?**

หากข้อมูลแผนภูมิไม่ได้เปลี่ยนแปลง workbook อาจยังคงมีค่าที่แคชจากการคำนวนก่อนหน้า หลังจากข้อมูลที่เกี่ยวข้องถูกแก้ไข ค่าที่แคชนั้นอาจไม่ถูกต้องอีกต่อไป การเข้าถึงเซลล์ที่สูตรไม่สามารถจัดการได้อาจทำให้เกิด [CellUnsupportedDataException](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/cellunsupporteddataexception/)

**ค่าข้อผิดพลาดของสูตรเป็นเหมือนข้อยกเว้นใน Java หรือไม่?**

ไม่ ผลลัพธ์เช่น `#DIV/0!` เป็นค่าของสเปรดชีตที่เกิดจากการคำนวณที่ถูกต้อง ส่วนข้อยกเว้นเช่น [CellInvalidFormulaException](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/cellinvalidformulaexception/) หรือ [CellCircularReferenceException](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/cellcircularreferenceexception/) บ่งชี้ว่ารูปแบบสูตรไม่สามารถประมวลผลได้ตามปกติ

**แผนภูมิจะอัปเดตโดยอัตโนมัติเมื่อเซลล์สูตรเปลี่ยนหรือไม่?**

ชุดข้อมูลของแผนภูมิสามารถอ้างอิงเซลล์ใน workbook ได้ คำนวณ workbook ก่อน, แล้วบันทึกหรือเรนเดอร์พรีเซนเทชัน หากจุดข้อมูลของแผนภูมิอ้างอิงเซลล์ที่คำนวณแล้ว แผนภูมิจะใช้ค่าที่อัปเดตเหล่านั้น; ไม่จำเป็นต้องมีเมธอดรีเฟรชแผนภูมิแยกต่างหากสำหรับเวิร์กโฟลว์นี้

**แผนภูมิสามารถใช้ workbook Excel ภายนอกได้หรือไม่?**

ได้, ข้อมูลแผนภูมิสามารถกำหนดให้ใช้ workbook ภายนอกผ่าน API ของข้อมูลแผนภูมิ อย่างไรก็ตาม เวิร์กโฟลว์การคำนวณสูตรที่อธิบายในบทความนี้เป็นเรื่องของ workbook ของข้อมูลแผนภูมิและชุดสูตรที่ Aspose.Slides ประเมิน อย่า assume ว่า [IChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ichartdataworkbook/#calculateFormulas--) จะคำนวณสูตรใด ๆ อย่างเต็มรูปแบบในไฟล์ XLSX ภายนอก

**สามารถใช้สูตรที่อ้างอิงแผ่นงานหรือ workbook อื่นได้หรือไม่?**

อ้างอิงสไตล์ Excel อาจมีใน workbook ของแผนภูมิ แต่การประเมินสูตรจำกัดโดยพาร์เซอร์และชุดฟังก์ชันที่สนับสนุน หากการอ้างอิงข้ามชีทหรือภายนอกเป็นสิ่งจำเป็น ให้ตรวจสอบสูตรนั้นกับเวอร์ชัน Aspose.Slides ที่คุณใช้ สำหรับเวิร์กโฟลว์ที่ต้องการความเข้ากันได้ของการอ้างอิง Excel อย่างกว้างขวาง คำนวณ workbook ภายนอกแล้วเขียนค่าที่แก้ไขกลับไปยังข้อมูลแผนภูมิ

**สูตรต้องเริ่มต้นด้วย `=` หรือไม่?**

ตัวอย่าง API ของ Aspose.Slides กำหนดให้กำหนดสูตรเช่น `B2-C2` หรือ `SUM(B2:B5)` โดยไม่ต้องเริ่มด้วย `=` การใช้รูปแบบนี้ทำให้สูตรที่สร้างสอดคล้องกับตัวอย่าง API ที่ระบุ