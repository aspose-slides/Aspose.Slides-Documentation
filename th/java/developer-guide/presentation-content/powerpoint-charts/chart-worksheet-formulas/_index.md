---
title: ใช้สูตรแผ่นงานของแผนภูมิในงานนำเสนอด้วย Java
linktitle: สูตรแผ่นงาน
type: docs
weight: 70
url: /th/java/chart-worksheet-formulas/
keywords:
- แผนภูมิสเปรดชีต
- แผนงานแผนภูมิ
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
- Java
- Aspose.Slides
description: "ใช้สูตรสไตล์ Excel ในแผ่นงานของแผนภูมิ Aspose.Slides สำหรับ Java, คำนวณค่าซ้ำ, และใช้ผลลัพธ์ในแผนภูมิ PowerPoint."
---
## **ภาพรวม**

แผนภูมิ PowerPoint มักจัดเก็บข้อมูลต้นฉบับไว้ในเวิร์กชีตฝังตัวไว้ ใน Aspose.Slides for Java คุณสามารถเข้าถึงเวิร์กชีตนั้นผ่าน chart data workbook, เขียนค่าตัวแปรเข้า, กำหนดสูตรให้กับเซลล์, คำนวณสูตรที่สนับสนุน, และใช้เซลล์ที่คำนวณแล้วเป็นข้อมูลแผนภูมิ

บทความนี้อธิบายกระบวนการทำงานของสูตรอย่างครบถ้วน: สร้างแผนภูมิ, เติมข้อมูลในเวิร์กชีตของมัน, กำหนดสูตรแบบ A1 หรือ R1C1, คำนวณสูตรใหม่, อ่านค่าที่คำนวณได้, เชื่อมต่อเซลล์เหล่านั้นกับซีรีส์ของแผนภูมิ, และบันทึกงานนำเสนอ นอกจากนี้ยังอธิบายไวยากรณ์สูตรที่สนับสนุน, ชุดฟังก์ชันที่มี built‑in, ค่าที่แคชไว้, สูตรที่ไม่สนับสนุน, และข้อผิดพลาดเฉพาะสเปรดชีต

## **เวิร์กชีตและสูตรของแผนภูมิ**

เวิร์กชีตของแผนภูมิประกอบด้วยหมวดหมู่, ชื่อซีรีส์, และค่าที่ใช้โดยแผนภูมิ ใน PowerPoint คุณสามารถตรวจสอบเวิร์กชีตได้โดยเปิด chart data editor:

![PowerPoint chart with its embedded worksheet open, showing category and series data](chart-worksheet-formulas_1.png)

ใน Aspose.Slides, เวิร์กชีตเปิดให้เข้าถึงผ่าน interface [IChartDataWorkbook](https://reference.aspose.com/slides/th/java/com.aspose.slides/ichartdataworkbook/) ใช้ [IChartDataCell.setFormula](https://reference.aspose.com/slides/th/java/com.aspose.slides/ichartdatacell/#setFormula-java.lang.String-) สำหรับสูตรแบบ A1 และ [IChartDataCell.setR1C1Formula](https://reference.aspose.com/slides/th/java/com.aspose.slides/ichartdatacell/#setR1C1Formula-java.lang.String-) สำหรับสูตรแบบ R1C1 หลังจากเปลี่ยนเซลล์อินพุตหรือสูตรแล้ว ให้เรียก [IChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/th/java/com.aspose.slides/ichartdataworkbook/#calculateFormulas--) เพื่อคำนวณสูตรที่สนับสนุนและอัปเดตค่าของเซลล์ที่สอดคล้องกัน

เซลล์ที่คำนวณแล้วยังคงเปิดให้เข้าถึงผลลัพธ์ผ่าน [IChartDataCell.getValue](https://reference.aspose.com/slides/th/java/com.aspose.slides/ichartdatacell/#getValue--) ซึ่งสำคัญเมื่อคุณต้องตรวจสอบผลของสูตรในโค้ดหรือใช้เซลล์เป็นจุดข้อมูลของแผนภูมิ

## **สร้างแผนภูมิและคำนวณสูตรในเวิร์กชีต**

ตัวอย่างต่อไปนี้แสดงกระบวนการทำงานแบบครบวงจร มันสร้างแผนภูมิคอลัมน์แบบ clustered, ลบข้อมูลตัวอย่าง, เขียนค่ารายได้และค่าใช้จ่ายไตรมาส, คำนวณกำไรด้วยสูตร, อ่านผลลัพธ์, ใช้เซลล์ที่คำนวณแล้วเป็นค่าของแผนภูมิ, และบันทึกงานนำเสนอ

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

จุดข้อมูลของแผนภูมิอ้างอิง `D2:D4` ดังนั้นแผนภูมิจะใช้ค่ากำไรที่คำนวณแล้ว ในกระบวนการนี้ไม่มีการเรียก refresh แผนภูมิแยกต่างหาก: คำนวณเวิร์กชีตก่อน, จากนั้นจึงใช้หรือบันทึกข้อมูลแผนภูมิที่ชี้ไปยังเซลล์ที่คำนวณแล้ว

## **ใช้สูตรแบบ A1**

การระบุแบบ A1 ใช้ตัวอักษรเพื่อบ่งชี้คอลัมน์และตัวเลขเพื่อบ่งชี้แถว กำหนดนิพจน์แบบ A1 ผ่าน [IChartDataCell.setFormula](https://reference.aspose.com/slides/th/java/com.aspose.slides/ichartdatacell/#setFormula-java.lang.String-)

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

| อ้างอิง | สัมพันธ์ | สัมบูรณ์ | ผสม |
|---|---|---|---|
| เซลล์ | `A2` | `$A$2` | `A$2`, `$A2` |
| แถว | `2:2` | `$2:$2` | — |
| คอลัมน์ | `A:A` | `$A:$A` | — |
| ช่วง | `A2:C4` | `$A$2:$C$4` | `A$2:$C4`, `$A2:C$4` |

การอ้างอิงสัมพันธ์สามารถเปลี่ยนแปลงได้เมื่อสูตรถูกย้ายหรือคัดลอกโดยแอปสเปรดชีต การอ้างอิงสัมบูรณ์จะตรึงพิกัดทั้งสองไว้คงที่ ในขณะที่การอ้างอิงผสมจะตรึงแค่แถวหรือคอลัมน์เท่านั้น

## **ใช้สูตรแบบ R1C1**

การระบุแบบ R1C1 ใช้ตัวเลขเพื่อบ่งชี้ทั้งแถวและคอลัมน์ การอ้างอิงสัมพันธ์ใช้การชดเชยในวงเล็บเหลี่ยม กำหนดไวยากรณ์นี้ผ่าน [IChartDataCell.setR1C1Formula](https://reference.aspose.com/slides/th/java/com.aspose.slides/ichartdatacell/#setR1C1Formula-java.lang.String-)

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

| อ้างอิง | สัมพันธ์ | สัมบูรณ์ | ผสม |
|---|---|---|---|
| เซลล์ | `R[2]C[3]` | `R2C3` | `R2C[3]`, `R[2]C3` |
| แถว | `R[2]` | `R2` | — |
| คอลัมน์ | `C[3]` | `C3` | — |
| ช่วง | `R[2]C[3]:R[5]C[7]` | `R2C3:R5C7` | `R2C3:R[5]C[7]`, `R[2]C3:R5C[7]` |

เช่น ในเซลล์ `D2`, `RC[-2]` หมายถึงเซลล์เดียวกันในแถวเดียวกันที่สองคอลัมน์ทางซ้าย (`B2`)

## **ค่าคงที่และตัวดำเนินการของสูตร**

ตัวประเมินสูตร built‑in รองรับค่าตรรกะ, ตัวเลขลิตเติล, สตริง, ค่าข้อผิดพลาดของสเปรดชีต, ตัวดำเนินการคณิตศาสตร์, และตัวดำเนินการเปรียบเทียบ

### **ค่าคงที่และลิตเติล**

| ประเภท | ตัวอย่าง | หมายเหตุ |
|---|---|---|
| ตรรกะ | `TRUE`, `FALSE` | สามารถใช้โดยตรงในนิพจน์ตรรกะ เช่น `A2=TRUE` |
| ตัวเลข | `1`, `0.5`, `.3`, `1E-2` | รองรับการเขียนแบบธรรมดาและแบบวิทยาศาสตร์ |
| สตริง | `"abc"`, `"2/3/2020 12:00"` | ลิตเติลข้อความต้องอยู่ในเครื่องหมายอัญประกาศคู่ภายในสูตร |
| ผลลัพธ์ข้อผิดพลาด | `#DIV/0!`, `#N/A`, `#REF!` | สูตรที่ถูกต้องอาจประเมินเป็นค่าข้อผิดพลาดของสเปรดชีตแทนผลลัพธ์ปกติ |

ตัวอย่างนี้ใช้ประเภทค่าคงที่หลายแบบ:

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

    Object logicalValue = workbook.getCell(0, "B2").getValue(); // เท็จ
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
| `+` | การบวกหรือเครื่องหมายบวกเอกพจน์ | `2+3` |
| `-` | การลบหรือเครื่องหมายลบเอกพจน์ | `2-3`, `-3` |
| `*` | การคูณ | `2*3` |
| `/` | การหาร | `2/3` |
| `%` | เปอร์เซ็นต์ | `30%` |
| `^` | ยกกำลัง | `2^3` |

ใช้วงเล็บเพื่อทำให้ลำดับการประเมินชัดเจน เช่น `(A2+B2)*C2`

### **ตัวดำเนินการเปรียบเทียบ**

นิพจน์เปรียบเทียบจะคืนค่าเชิงตรรกะ

| ตัวดำเนินการ | ความหมาย | ตัวอย่าง |
|---|---|---|
| `=` | เท่ากับ | `A2=3` |
| `<>` | ไม่เท่ากับ | `A2<>3` |
| `>` | มากกว่า | `A2>3` |
| `>=` | มากกว่าหรือเท่ากับ | `A2>=3` |
| `<` | น้อยกว่า | `A2<3` |
| `<=` | น้อยกว่าหรือเท่ากับ | `A2<=3` |

## **ฟังก์ชันที่กำหนดไว้ล่วงหน้าที่สนับสนุน**

Aspose.Slides มีตัวประเมินสูตร built‑in สำหรับเวิร์กชีตของแผนภูมิ แต่ไม่ได้เป็นเอนจินคำนวณ Excel ที่ครบถ้วน ชุดฟังก์ชันที่ระบุในเอกสารจำกัดอยู่ที่ฟังก์ชันต่อไปนี้ อย่าคาดว่าฟังก์ชัน Excel ใด ๆ สามารถคำนวณใหม่ได้โดย [IChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/th/java/com.aspose.slides/ichartdataworkbook/#calculateFormulas--)

| ฟังก์ชัน | จุดประสงค์หรือรูปแบบที่สนับสนุน | ตัวอย่าง |
|---|---|---|
| `ABS` | ค่าสัมบูรณ์ | `ABS(A2)` |
| `AVERAGE` | ค่าเฉลี่ยคณิตศาสตร์ | `AVERAGE(B2:B5)` |
| `CEILING` | ปัดขึ้นเป็นจำนวนที่เป็นพหุคูณ | `CEILING(A2,5)` |
| `CHOOSE` | เลือกค่าตามดัชนี | `CHOOSE(A2,"Low","High")` |
| `CONCAT` | รวมค่าข้อความ | `CONCAT(A2,B2)` |
| `CONCATENATE` | รวมค่าข้อความ | `CONCATENATE(A2," ",B2)` |
| `DATE` | สร้างค่าที่เป็นวันที่โดยใช้ระบบวันที่ 1900 | `DATE(2026,8,19)` |
| `DAYS` | คืนจำนวนวันระหว่างสองวันที่ | `DAYS(B2,A2)` |
| `FIND` | ค้นหาข้อความหนึ่งภายในอีกข้อความ | `FIND("-",A2)` |
| `FINDB` | การค้นหาข้อความแบบไบต์ | `FINDB("a",A2)` |
| `IF` | ผลลัพธ์ตามเงื่อนไข | `IF(A2>0,A2,0)` |
| `INDEX` | รูปแบบอ้างอิง | `INDEX(A2:C4,2,3)` |
| `LOOKUP` | รูปแบบเวกเตอร์ | `LOOKUP(A2,B2:B5,C2:C5)` |
| `MATCH` | รูปแบบเวกเตอร์ | `MATCH(A2,B2:B5,0)` |
| `MAX` | ค่าสูงสุด | `MAX(B2:B5)` |
| `SUM` | ผลรวม | `SUM(B2:B5)` |
| `VLOOKUP` | การค้นหาแนวตั้ง | `VLOOKUP(A2,B2:D10,3,FALSE)` |

ข้อจำกัดที่ระบุในตารางสำคัญ: `INDEX` ระบุในรูปแบบอ้างอิง, ส่วน `LOOKUP` และ `MATCH` ระบุในรูปแบบเวกเตอร์ `DATE` ใช้ระบบวันที่ 1900 ฟีเจอร์และฟังก์ชันที่ไม่อยู่ในรายการนี้ควรถือว่าไม่ได้รับการสนับสนุนโดยตัวประเมินสูตรของ Aspose.Slides เว้นแต่จะมีการระบุแยกต่างหาก

## **การคำนวณใหม่และค่าที่แคชไว้**

ไฟล์สเปรดชีตมักจะเก็บทั้งสูตรและค่าที่คำนวณล่าสุดไว้ Aspose.Slides จึงสามารถอ่านค่าที่แคชจาก [IChartDataCell.getValue](https://reference.aspose.com/slides/th/java/com.aspose.slides/ichartdatacell/#getValue--) เมื่อโหลดงานนำเสนอและข้อมูลแผนภูมิกังวลไม่ได้ถูกเปลี่ยน

หลังจากเปลี่ยนเซลล์อินพุตหรือสูตร อย่าพึ่งพาค่าแคชเก่า ให้เรียก [IChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/th/java/com.aspose.slides/ichartdataworkbook/#calculateFormulas--) ก่อนอ่านค่าที่คำนวณใหม่หรือบันทึกข้อมูลแผนภูมิที่ขึ้นกับค่าดังกล่าว

สำหรับสูตรที่อยู่นอกชุดที่สนับสนุน Aspose.Slides อาจไม่สามารถพาร์สสูตรหรือกำหนดการอ้างอิงได้ หากเวิร์กชีตถูกแก้ไข ค่าที่แคชไว้ก่อนหน้านั้นจะไม่เชื่อถือได้อีก ในสถานการณ์นั้น การอ่านค่าของเซลล์ที่มีข้อมูลไม่สนับสนุนอาจทำให้เกิด [CellUnsupportedDataException](https://reference.aspose.com/slides/th/java/com.aspose.slides/cellunsupporteddataexception/)

หากแผนภูมิกังวลต่อฟังก์ชัน Excel ที่ Aspose.Slides ไม่ประเมิน ให้คำนวณสูตรเหล่านั้นด้วยเอนจินสเปรดชีตที่สนับสนุนและเขียนค่าที่ได้กลับไปยัง chart workbook อย่าแทนสูตรที่ไม่สนับสนุนด้วยค่าที่คาดเดา

## **จัดการข้อผิดพลาดของสูตร**

มีสองประเภทของปัญหาที่ต้องแยกแยะ

สูตรอาจถูกต้องแต่ให้ผลลัพธ์เป็นค่าข้อผิดพลาดของสเปรดชีต เช่น `#DIV/0!`, `#N/A`, `#NAME?`, `#NULL!`, `#NUM!`, `#REF!`, หรือ `#VALUE!` ในกรณีนี้ โทเคนข้อผิดพลาดเป็นผลลัพธ์ของเซลล์และสามารถคืนค่าผ่าน [IChartDataCell.getValue](https://reference.aspose.com/slides/th/java/com.aspose.slides/ichartdatacell/#getValue--)

สูตรอาจล้มเหลวที่ขั้นตอนการพาร์ส, การอ้างอิง, การพึ่งพา, หรือระดับข้อมูลที่สนับสนุน Aspose.Slides มีข้อยกเว้นเฉพาะสเปรดชีตสำหรับกรณีเหล่านี้: [CellInvalidFormulaException](https://reference.aspose.com/slides/th/java/com.aspose.slides/cellinvalidformulaexception/), [CellInvalidReferenceException](https://reference.aspose.com/slides/th/java/com.aspose.slides/cellinvalidreferenceexception/), [CellCircularReferenceException](https://reference.aspose.com/slides/th/java/com.aspose.slides/cellcircularreferenceexception/), และ [CellUnsupportedDataException](https://reference.aspose.com/slides/th/java/com.aspose.slides/cellunsupporteddataexception/)

เมื่อสูตรมาจากเทมเพลตหรืออินพุตของผู้ใช้ ให้วนรอบข้อยกเว้นเหล่านี้รอบการคำนวณใหม่และการเข้าถึงค่า:

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

การสนับสนุนสูตรในเวิร์กชีตของแผนภูมิมีวัตถุประสงค์เพื่อรองรับชุดย่อยที่กำหนดของการคำนวณสเปรดชีต ไม่ได้ครอบคลุมความเข้ากันได้เต็มรูปแบบของ Excel ควรคำนึงถึงข้อจำกัดเหล่านี้เมื่อตั้งค่าเวิร์กโฟลว์การรายงาน:

- ใช้ค่าคงที่, ตัวดำเนินการ, การอ้างอิง, และฟังก์ชันที่ระบุในเอกสารเท่านั้นเมื่อคุณต้องการให้ Aspose.Slides คำนวณสูตรใหม่
- คำนวณใหม่หลังจากเปลี่ยนเซลล์ที่สูตรอ้างอิงถึง
- ถือค่าที่แคชจากงานนำเข้าที่โหลดแล้วเป็นภาพนิ่ง ไม่ใช่การแทนที่การคำนวณใหม่หลังแก้ไข
- ทดสอบสูตรจากเทมเพลตที่มีอยู่ก่อนพึ่งพาค่าที่คำนวณได้ โดยเฉพาะเมื่อใช้ฟังก์ชันที่อยู่นอกรายการที่ระบุ
- สำหรับสูตรที่ต้องการเอนจินคำนวณสเปรดชีตเต็มรูปแบบ ให้คำนวณภายนอกแล้วอัปเดตค่าใน chart workbook

## **คำถามที่พบบ่อย**

**ความแตกต่างระหว่าง [IChartDataCell.setFormula](https://reference.aspose.com/slides/th/java/com.aspose.slides/ichartdatacell/#setFormula-java.lang.String-) และ [IChartDataCell.setR1C1Formula](https://reference.aspose.com/slides/th/java/com.aspose.slides/ichartdatacell/#setR1C1Formula-java.lang.String-) คืออะไร?**

[IChartDataCell.setFormula](https://reference.aspose.com/slides/th/java/com.aspose.slides/ichartdatacell/#setFormula-java.lang.String-) เก็บนิพจน์แบบ A1 เช่น `B2-C2` ในขณะที่ [IChartDataCell.setR1C1Formula](https://reference.aspose.com/slides/th/java/com.aspose.slides/ichartdatacell/#setR1C1Formula-java.lang.String-) เก็บนิพจน์แบบ R1C1 เช่น `RC[-2]-RC[-1]` ใช้รูปแบบที่สอดคล้องกับวิธีการสร้างหรือคัดลอกสูตรของคุณ

**ฉันต้องอ่านเซลล์เองหรือค่า after การคำนวณหรือไม่?**

[IChartDataWorkbook.getCell](https://reference.aspose.com/slides/th/java/com.aspose.slides/ichartdataworkbook/#getCell-int-java.lang.String-) คืนค่า [IChartDataCell](https://reference.aspose.com/slides/th/java/com.aspose.slides/ichartdatacell/) เพื่อให้ได้ผลลัพธ์ที่คำนวณแล้ว ให้เรียกเมธอด [IChartDataCell.getValue](https://reference.aspose.com/slides/th/java/com.aspose.slides/ichartdatacell/#getValue--) ของเซลล์นั้นหลังจากคำนวณใหม่

**ควรเรียก [IChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/th/java/com.aspose.slides/ichartdataworkbook/#calculateFormulas--) เมื่อใด?**

เรียก [IChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/th/java/com.aspose.slides/ichartdataworkbook/#calculateFormulas--) หลังจากเปลี่ยนค่ อินพุตหรือสูตรและก่อนที่คุณจะพึ่งพาผลลัพธ์ที่คำนวณได้ ซึ่งจะอัปเดตค่าของสูตรที่ตัวประเมิน built‑in รองรับ

**Aspose.Slides รองรับทุกฟังก์ชันของ Excel หรือไม่?**

ไม่ ตัวประเมิน built‑in รองรับเพียงชุดฟังก์ชันที่ระบุในเอกสาร ฟังก์ชันที่อยู่นอกชุดนั้นไม่ควรถือว่าจะคำนวณได้อย่างถูกต้อง หากต้องการความเข้ากันได้เต็มรูปแบบของสูตร Excel ให้ทำการคำนวณด้วยเอนจินสเปรดชีตที่เหมาะสมแล้วเขียนค่าที่ได้ลงใน chart workbook

**อะไรจะเกิดขึ้นหากงานนำเข้าที่โหลดมามีสูตรที่ไม่สนับสนุน?**

หากข้อมูลแผนภูมิไม่เปลี่ยนแปลง เวิร์กชีตอาจยังคงมีค่าที่แคชจากการคำนวณก่อนหน้า หลังจากข้อมูลที่เกี่ยวข้องถูกแก้ไข ค่าที่แคชนั้นอาจไม่ถูกต้องอีกต่อไป การเข้าถึงเซลล์ที่สูตรไม่สามารถจัดการได้อาจทำให้เกิด [CellUnsupportedDataException](https://reference.aspose.com/slides/th/java/com.aspose.slides/cellunsupporteddataexception/)

**ค่าข้อผิดพลาดของสูตรเหมือนกับข้อยกเว้นของ Java หรือไม่?**

ไม่ ผลลัพธ์เช่น `#DIV/0!` เป็นค่าของสเปรดชีตที่เกิดจากการคำนวณที่ถูกต้อง ส่วนข้อยกเว้นเช่น [CellInvalidFormulaException](https://reference.aspose.com/slides/th/java/com.aspose.slides/cellinvalidformulaexception/) หรือ [CellCircularReferenceException](https://reference.aspose.com/slides/th/java/com.aspose.slides/cellcircularreferenceexception/) บ่งชี้ว่าระบบไม่สามารถประมวลผลสูตรได้ตามปกติ

**แผนภูมิอัปเดตอัตโนมัติเมื่อเซลล์สูตรเปลี่ยนหรือไม่?**

ซีรีส์ของแผนภูมิอาจอ้างอิงเซลล์ในเวิร์กชีต คำนวณเวิร์กชีตก่อน จากนั้นบันทึกหรือเรนเดอร์งานนำเสนอ หากจุดข้อมูลของแผนภูมิอ้างอิงเซลล์ที่คำนวณแล้ว แผนภูมิจะใช้ค่าที่อัปเดตเหล่านั้น ไม่ต้องเรียกเมธอด refresh แยกต่างหากสำหรับเวิร์กโฟลว์นี้

**แผนภูมิสามารถใช้เวิร์กชีต Excel ภายนอกได้หรือไม่?**

ได้ ข้อมูลแผนภูมิสามารถกำหนดให้ใช้เวิร์กชีตภายนอกผ่าน API ของ chart data อย่างไรก็ตาม กระบวนการคำนวณสูตรที่อธิบายในบทความนี้เกี่ยวข้องกับ chart data workbook และชุดสูตรที่ Aspose.Slides ประเมิน ไม่ควรสมมติว่า [IChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/th/java/com.aspose.slides/ichartdataworkbook/#calculateFormulas--) ทำการคำนวณเต็มรูปแบบของสูตรใด ๆ ในไฟล์ XLSX ภายนอก

**ฉันสามารถใช้สูตรที่อ้างอิงเวิร์กชีตหรือเวิร์กบุ๊กอื่นได้หรือไม่?**

การอ้างอิงแบบ Excel อาจมีอยู่ใน chart workbook แต่การประเมินสูตรถูกจำกัดโดยพาร์สเซอร์และชุดฟังก์ชันที่สนับสนุน หากการอ้างอิงข้ามชีตหรือภายนอกเป็นสิ่งจำเป็น ควรตรวจสอบสูตรนั้นกับเวอร์ชัน Aspose.Slides ที่ใช้ สำหรับเวิร์กโฟลว์ที่ต้องการความเข้ากันได้ของการอ้างอิง Excel อย่างกว้าง ควรคำนวณเวิร์กชีตภายนอกแล้วเขียนค่าที่ได้กลับไปยังข้อมูลแผนภูมิ

**สูตรควรเริ่มต้นด้วย `=` หรือไม่?**

ตัวอย่าง API ของ Aspose.Slides กำหนดนิพจน์เช่น `B2-C2` หรือ `SUM(B2:B5)` โดยไม่มี `=` นำหน้า การใช้รูปแบบนี้ทำให้สูตรที่สร้างสอดคล้างกับตัวอย่าง API ที่ระบุในเอกสาร