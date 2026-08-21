---
title: ใช้สูตรเวิร์กชีตแผนภูมิในการนำเสนอใน Java
linktitle: สูตรเวิร์กชีต
type: docs
weight: 70
url: /th/java/chart-worksheet-formulas/
keywords:
- แผนภูมิสเปรดชีต
- เวิร์กชีตแผนภูมิ
- สูตรแผนภูมิ
- สูตรเวิร์กชีต
- สูตรสเปรดชีต
- เวิร์กบุ๊กข้อมูลแผนภูมิ
- การคำนวณสูตร
- วัฒนธรรมที่ต้องการ
- สูตรตามวัฒนธรรม
- DBCS
- ค่าคงที่ตรรกะ
- ค่าคงที่เชิงตัวเลข
- ค่าคงที่สตริง
- ค่าคงที่ข้อผิดพลาด
- ตัวดำเนินการทางคณิตศาสตร์
- ตัวดำเนินการเปรียบเทียบ
- สไตล์ A1
- สไตล์ R1C1
- ฟังก์ชันที่กำหนดล่วงหน้า
- PowerPoint
- การนำเสนอ
- Java
- Aspose.Slides
description: "ใช้สูตรสไตล์ Excel ในเวิร์กชีตแผนภูมิของ Aspose.Slides for Java, คำนวณค่าซ้ำ, และใช้ผลลัพธ์ในแผนภูมิ PowerPoint."
---
## **ภาพรวม**

แผนภูมิ PowerPoint มักจะเก็บข้อมูลต้นแบบไว้ในเวิร์กชีตที่ฝังอยู่ ใน Aspose.Slides for Java คุณสามารถเข้าถึงเวิร์กชีตนั้นผ่าน workbook ของข้อมูลแผนภูมิ, เขียนค่าที่ป้อนเข้า, กำหนดสูตรให้เซลล์, คำนวณสูตรที่สนับสนุน, และใช้เซลล์ที่คำนวณแล้วเป็นข้อมูลแผนภูมิ

บทความนี้อธิบายกระบวนการทำงานเต็มรูปแบบของสูตร: สร้างแผนภูมิ, เติมข้อมูลในเวิร์กชีต, กำหนดสูตรแบบ A1 หรือ R1C1, คำนวณใหม่, อ่านค่าที่คำนวณได้, เชื่อมต่อเซลล์เหล่านั้นกับชุดข้อมูลของแผนภูมิ, และบันทึกงานนำเสนอ นอกจากนี้ยังอธิบายไวยากรณ์สูตรที่รองรับ, ชุดฟังก์ชันในตัว, ค่าที่แคชไว้, สูตรที่ไม่รองรับ, และข้อผิดพลาดเฉพาะสเปรดชีต

## **เวิร์กชีตและสูตรของแผนภูมิ**

เวิร์กชีตของแผนภูมิประกอบด้วยประเภท, ชื่อชุดข้อมูล, และค่าที่แผนภูมิเชื่อมโยง ใน PowerPoint คุณสามารถตรวจสอบเวิร์กชีตได้โดยเปิดตัวแก้ไขข้อมูลแผนภูมิ:

![PowerPoint chart with its embedded worksheet open, showing category and series data](chart-worksheet-formulas_1.png)

ใน Aspose.Slides, เวิร์กชีตถูกเปิดเผยผ่านอินเตอร์เฟส [IChartDataWorkbook](https://reference.aspose.com/slides/th/java/com.aspose.slides/ichartdataworkbook/) ใช้ [IChartDataCell.setFormula](https://reference.aspose.com/slides/th/java/com.aspose.slides/ichartdatacell/#setFormula-java.lang.String-) สำหรับสูตรแบบ A1 และ [IChartDataCell.setR1C1Formula](https://reference.aspose.com/slides/th/java/com.aspose.slides/ichartdatacell/#setR1C1Formula-java.lang.String-) สำหรับสูตรแบบ R1C1 หลังจากเปลี่ยนเซลล์อินพุตหรือสูตร ให้เรียก [IChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/th/java/com.aspose.slides/ichartdataworkbook/#calculateFormulas--) เพื่อคำนวณสูตรที่สนับสนุนและอัปเดตค่าของเซลล์ที่สอดคล้องกัน

เซลล์ที่คำนวณแล้วยังคงเปิดเผยผลลัพธ์ผ่าน [IChartDataCell.getValue](https://reference.aspose.com/slides/th/java/com.aspose.slides/ichartdatacell/#getValue--) ซึ่งสำคัญเมื่อต้องตรวจสอบผลลัพธ์ของสูตรในโค้ดหรือใช้เซลล์เป็นจุดข้อมูลของแผนภูมิ

## **สร้างแผนภูมิและคำนวณสูตรในเวิร์กชีต**

ตัวอย่างต่อไปนี้สาธิตกระบวนการทำงานตั้งแต่ต้นจนจบ มันสร้างแผนภูมิคอลัมน์แบบกลุ่ม, ลบข้อมูลตัวอย่าง, เขียนค่ารายได้และค่าใช้จ่ายรายไตรมาส, คำนวณกำไรด้วยสูตร, อ่านผลลัพธ์, ใช้เซลล์ที่คำนวณเป็นค่าของแผนภูมิ, และบันทึกงานนำเสนอ

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

จุดข้อมูลของแผนภูมิอ้างอิง `D2:D4` ดังนั้นแผนภูมิจะใช้ค่ากำไรที่คำนวณแล้ว ไม่ต้องมีการเรียกรีเฟรชแผนภูมิแยกต่างหากในกระบวนการนี้: คำนวณ workbook ก่อน, จากนั้นใช้หรือบันทึกข้อมูลแผนภูมิที่ชี้ไปยังเซลล์ที่คำนวณแล้ว

## **ใช้สูตรแบบ A1**

การระบุแบบ A1 ใช้อักษรเป็นคอลัมน์และตัวเลขเป็นแถว กำหนดนิพจน์แบบ A1 ผ่าน [IChartDataCell.setFormula](https://reference.aspose.com/slides/th/java/com.aspose.slides/ichartdatacell/#setFormula-java.lang.String-)

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

| อ้างอิง | สัมพัทธ์ | สัมบูรณ์ | ผสม |
|---|---|---|---|
| เซลล์ | `A2` | `$A$2` | `A$2`, `$A2` |
| แถว | `2:2` | `$2:$2` | — |
| คอลัมน์ | `A:A` | `$A:$A` | — |
| ช่วง | `A2:C4` | `$A$2:$C$4` | `A$2:$C4`, `$A2:C$4` |

การอ้างอิงสัมพัทธ์อาจเปลี่ยนเมื่อสูตรถูกย้ายหรือคัดลอกโดยแอปสเปรดชีต ส่วนการอ้างอิงสัมบูรณ์จะคงค่าพิกัดทั้งสองคงที่ ส่วนการอ้างอิงผสมจะตรึงแค่แถวหรือคอลัมน์หนึ่งเท่านั้น

## **ใช้สูตรแบบ R1C1**

การระบุแบบ R1C1 ใช้ตัวเลขระบุทั้งแถวและคอลัมน์ การอ้างอิงสัมพัทธ์ใช้ส่วนชดเชยในวงเล็บเหลี่ยม กำหนดไวยากรณ์นี้ผ่าน [IChartDataCell.setR1C1Formula](https://reference.aspose.com/slides/th/java/com.aspose.slides/ichartdatacell/#setR1C1Formula-java.lang.String-)

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

| อ้างอิง | สัมพัทธ์ | สัมบูรณ์ | ผสม |
|---|---|---|---|
| เซลล์ | `R[2]C[3]` | `R2C3` | `R2C[3]`, `R[2]C3` |
| แถว | `R[2]` | `R2` | — |
| คอลัมน์ | `C[3]` | `C3` | — |
| ช่วง | `R[2]C[3]:R[5]C[7]` | `R2C3:R5C7` | `R2C3:R[5]C[7]`, `R[2]C3:R5C[7]` |

ตัวอย่างเช่น ในเซลล์ `D2`, `RC[-2]` หมายถึงเซลล์ในแถวเดียวกันสองคอลัมน์ทางซ้าย (`B2`)

## **ค่าคงที่และตัวดำเนินการของสูตร**

เครื่องประเมินสูตรในตัวสนับสนุนค่าตรรกะ, ค่าตัวเลข, สตริง, ค่าข้อผิดพลาดของสเปรดชีต, ตัวดำเนินการทางคณิตศาสตร์, และตัวดำเนินการเปรียบเทียบ

### **ค่าคงที่และลิตทีรัล**

| ชนิด | ตัวอย่าง | หมายเหตุ |
|---|---|---|
| ตรรกะ | `TRUE`, `FALSE` | สามารถใช้โดยตรงในนิพจน์ตรรกะเช่น `A2=TRUE` |
| ตัวเลข | `1`, `0.5`, `.3`, `1E-2` | รองรับการเขียนแบบทั่วไปและแบบวิทยาศาสตร์ |
| สตริง | `"abc"`, `"2/3/2020 12:00"` | ลิตทีรัลข้อความต้องอยู่ในเครื่องหมายอัญประกาศคู่ภายในสูตร |
| ผลลัพธ์ข้อผิดพลาด | `#DIV/0!`, `#N/A`, `#REF!` | สูตรที่ถูกต้องอาจประเมินเป็นค่าข้อผิดพลาดของสเปรดชีตได้แทนค่าปกติ |

ตัวอย่างนี้ใช้ค่าคงที่หลายชนิด:

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

### **ตัวดำเนินการทางคณิตศาสตร์**

| ตัวดำเนินการ | ความหมาย | ตัวอย่าง |
|---|---|---|
| `+` | การบวกหรือเครื่องหมายบวกเอกพจน์ | `2+3` |
| `-` | การลบหรือการทำลบเอกพจน์ | `2-3`, `-3` |
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

## **ฟังก์ชันที่กำหนดล่วงหน้าที่รองรับ**

Aspose.Slides มีเครื่องประเมินสูตรในตัวสำหรับเวิร์กชีตของแผนภูมิ, แต่ไม่ใช่เครื่องยนต์คำนวณ Excel เต็มรูปแบบ ชุดฟังก์ชันที่เอกสารระบุมีจำกัดเพียงฟังก์ชันต่อไปนี้ อย่าสมมติว่าฟังก์ชัน Excel ใด ๆ สามารถคำนวณใหม่ได้โดย [IChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/th/java/com.aspose.slides/ichartdataworkbook/#calculateFormulas--)

| ฟังก์ชัน | จุดประสงค์หรือรูปแบบที่รองรับ | ตัวอย่าง |
|---|---|---|
| `ABS` | ค่าตัวเลขสัมบูรณ์ | `ABS(A2)` |
| `AVERAGE` | ค่าเฉลี่ยเลขคณิต | `AVERAGE(B2:B5)` |
| `CEILING` | ปัดเลขขึ้นเป็นหลายเท่า | `CEILING(A2,5)` |
| `CHOOSE` | เลือกค่าตามดัชนี | `CHOOSE(A2,"Low","High")` |
| `CONCAT` | เชื่อมข้อความ | `CONCAT(A2,B2)` |
| `CONCATENATE` | เชื่อมข้อความ | `CONCATENATE(A2," ",B2)` |
| `DATE` | สร้างค่าวันที่โดยใช้ระบบวันที่ 1900 | `DATE(2026,8,19)` |
| `DAYS` | คืนจำนวนวันระหว่างสองวันที่ | `DAYS(B2,A2)` |
| `FIND` | ค้นหาข้อความภายในข้อความอื่น | `FIND("-",A2)` |
| `FINDB` | ค้นหาข้อความแบบไบต์ | `FINDB("a",A2)` |
| `IF` | ผลลัพธ์ตามเงื่อนไข | `IF(A2>0,A2,0)` |
| `INDEX` | รูปแบบอ้างอิง | `INDEX(A2:C4,2,3)` |
| `LOOKUP` | รูปแบบเวกเตอร์ | `LOOKUP(A2,B2:B5,C2:C5)` |
| `MATCH` | รูปแบบเวกเตอร์ | `MATCH(A2,B2:B5,0)` |
| `MAX` | ค่าสูงสุด | `MAX(B2:B5)` |
| `SUM` | ผลรวม | `SUM(B2:B5)` |
| `VLOOKUP` | การค้นหาแนวตั้ง | `VLOOKUP(A2,B2:D10,3,FALSE)` |

ข้อจำกัดในตารางมีความสำคัญ: `INDEX` เอกสารในรูปแบบอ้างอิง, ส่วน `LOOKUP` และ `MATCH` เอกสารในรูปแบบเวกเตอร์ `DATE` ใช้ระบบวันที่ 1900 ฟีเจอร์และฟังก์ชันที่ไม่ได้ระบุในที่นี้ควรถือว่าไม่รองรับโดยเครื่องประเมินสูตรของ Aspose.Slides เว้นแต่จะมีเอกสารแยกต่างหาก

## **คำนวณสูตรด้วยวัฒนธรรมที่ต้องการ**

ฟังก์ชันบางอย่างของ workbook แปลข้อความตามกฎของวัฒนธรรมเฉพาะ ซึ่งสำคัญโดยเฉพาะกับฟังก์ชันที่ออกแบบมาสำหรับภาษาที่ใช้ชุดอักขระสองไบต์ (DBCS) เพื่อคำนวณสูตรเหล่านั้นอย่างถูกต้อง ให้สร้าง [LoadOptions](https://reference.aspose.com/slides/th/java/com.aspose.slides/loadoptions/), ตั้งค่าวัฒนธรรมที่ต้องการด้วย [SpreadsheetOptions.setPreferredCulture](https://reference.aspose.com/slides/th/java/com.aspose.slides/spreadsheetoptions/#setPreferredCulture-java.util.Locale-), กำหนดตัวเลือกสเปรดชีตผ่าน [LoadOptions.setSpreadsheetOptions](https://reference.aspose.com/slides/th/java/com.aspose.slides/loadoptions/#setSpreadsheetOptions-com.aspose.slides.ISpreadsheetOptions-), แล้วโหลดงานนำเสนอ

ตัวอย่างต่อไปนี้เลือกวัฒนธรรมญี่ปุ่น, เปิดงานนำเสนอด้วยตัวเลือกโหลดที่กำหนด, และเรียก [IChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/th/java/com.aspose.slides/ichartdataworkbook/#calculateFormulas--) สำหรับทุก workbook ของแผนภูมิ:

```java
import com.aspose.slides.*;
import java.util.Locale;

Locale japaneseCulture = Locale.forLanguageTag("ja-JP");

ISpreadsheetOptions spreadsheetOptions = new SpreadsheetOptions();
spreadsheetOptions.setPreferredCulture(japaneseCulture);

LoadOptions loadOptions = new LoadOptions();
loadOptions.setSpreadsheetOptions(spreadsheetOptions);

Presentation presentation = new Presentation("presentation.pptx", loadOptions);
try {
    for (ISlide slide : presentation.getSlides()) {
        for (IShape shape : slide.getShapes()) {
            if (shape instanceof IChart) {
                IChart chart = (IChart) shape;
                chart.getChartData().getChartDataWorkbook().calculateFormulas();
            }
        }
    }
} finally {
    presentation.dispose();
}
```

วัฒนธรรมที่ต้องการเป็นส่วนหนึ่งของการกำหนดค่าการโหลดงานนำเสนอ ดังนั้นต้องตั้งค่าก่อนสร้างอ็อบเจ็กต์ [Presentation](https://reference.aspose.com/slides/th/java/com.aspose.slides/presentation/) ใช้วัฒนธรรมที่สูตรของ workbook คาดหวัง เช่น `ja-JP` สำหรับสูตรที่ควรปฏิบัติตามกฎการคำนวณ DBCS ของญี่ปุ่น

## **การคำนวณใหม่และค่าที่แคชไว้**

ไฟล์สเปรดชีตมักจะเก็บทั้งสูตรและค่าที่คำนวณล่าสุด Aspose.Slides จึงสามารถอ่านค่าที่แคชจาก [IChartDataCell.getValue](https://reference.aspose.com/slides/th/java/com.aspose.slides/ichartdatacell/#getValue--) เมื่อโหลดงานนำเสนอและข้อมูลแผนภูมิที่เกี่ยวข้องไม่ได้ถูกเปลี่ยนแปลง

หลังจากเปลี่ยนเซลล์อินพุตหรือสูตร อย่าอาศัยผลลัพธ์แคชเก่า ให้เรียก [IChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/th/java/com.aspose.slides/ichartdataworkbook/#calculateFormulas--) ก่อนอ่านค่าที่คำนวณหรือบันทึกข้อมูลแผนภูมิที่พึ่งพาค่าเหล่านั้น

สำหรับสูตรที่อยู่นอกชุดที่รองรับ Aspose.Slides อาจไม่สามารถแปลสูตรหรือกำหนดการพึ่งพาได้ หาก workbook ถูกแก้ไข ค่าที่แคชไว้ก่อนหน้านั้นจะไม่เชื่อถือได้ ในสถานการณ์นั้น การอ่านค่าของเซลล์ที่มีข้อมูลไม่รองรับอาจทำให้เกิด [CellUnsupportedDataException](https://reference.aspose.com/slides/th/java/com.aspose.slides/cellunsupporteddataexception/)

หากแผนภูมิของคุณพึ่งพาฟังก์ชัน Excel ที่ Aspose.Slides ไม่ประเมินผล ให้คำนวณสูตรเหล่านั้นด้วยเอนจินสเปรดชีตที่รองรับและเขียนค่าที่ได้กลับไปยัง workbook ของแผนภูมิ อย่าแทนที่สูตรที่ไม่รองรับด้วยค่าที่คาดเดา

## **จัดการข้อผิดพลาดของสูตร**

มีปัญหา 2 ประเภทให้แยกแยะ

สูตรอาจถูกต้องแต่ให้ผลลัพธ์เป็นค่าข้อผิดพลาดของสเปรดชีต เช่น `#DIV/0!`, `#N/A`, `#NAME?`, `#NULL!`, `#NUM!`, `#REF!`, หรือ `#VALUE!` ในกรณีนี้ โทเค็นข้อผิดพลาดเป็นผลลัพธ์ของเซลล์และสามารถคืนค่าผ่าน [IChartDataCell.getValue](https://reference.aspose.com/slides/th/java/com.aspose.slides/ichartdatacell/#getValue--)

สูตรอาจล้มเหลวที่ขั้นตอนการแปล, การอ้างอิง, การพึ่งพา, หรือระดับข้อมูลที่รองรับ Aspose.Slides ให้ข้อยกเว้นเฉพาะสเปรดชีตสำหรับกรณีเหล่านี้: [CellInvalidFormulaException](https://reference.aspose.com/slides/th/java/com.aspose.slides/cellinvalidformulaexception/), [CellInvalidReferenceException](https://reference.aspose.com/slides/th/java/com.aspose.slides/cellinvalidreferenceexception/), [CellCircularReferenceException](https://reference.aspose.com/slides/th/java/com.aspose.slides/cellcircularreferenceexception/), และ [CellUnsupportedDataException](https://reference.aspose.com/slides/th/java/com.aspose.slides/cellunsupporteddataexception/)

เมื่อสูตรมาจากเทมเพลตหรือการป้อนของผู้ใช้ ให้จัดการข้อยกเว้นเหล่านี้รอบการคำนวณใหม่และการเข้าถึงค่า:

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

การสนับสนุนสูตรในเวิร์กชีตของแผนภูมิถูกออกแบบมาสำหรับชุดย่อยที่กำหนดของการคำนวณสเปรดชีต ไม่ใช่ความเข้ากันได้เต็มรูปแบบกับ Excel คำนึงถึงข้อจำกัดเหล่านี้เมื่อออกแบบกระบวนการรายงาน:

- ใช้เฉพาะค่าคงที่, ตัวดำเนินการ, การอ้างอิง, และฟังก์ชันที่ระบุในเอกสารเมื่อจำเป็นให้ Aspose.Slides คำนวณสูตรใหม่
- คำนวณใหม่หลังจากเปลี่ยนเซลล์ที่สูตรอิงถึง
- ถือค่าที่แคชจากงานนำเสนอที่โหลดเป็นสแนปช็อต ไม่ใช่การทดแทนการคำนวณใหม่หลังแก้ไข
- ทดสอบสูตรจากเทมเพลตที่มีอยู่ก่อนพึ่งพาค่าที่คำนวณแล้ว โดยเฉพาะเมื่อใช้ฟังก์ชันที่อยู่นอกรายการเอกสาร
- สำหรับสูตรที่ต้องการเครื่องยนต์คำนวณสเปรดชีตเต็มรูปแบบ ให้คำนวณภายนอกแล้วอัปเดตค่าใน workbook ของแผนภูมิ

## **คำถามที่พบบ่อย**

**ความแตกต่างระหว่าง [IChartDataCell.setFormula](https://reference.aspose.com/slides/th/java/com.aspose.slides/ichartdatacell/#setFormula-java.lang.String-) และ [IChartDataCell.setR1C1Formula](https://reference.aspose.com/slides/th/java/com.aspose.slides/ichartdatacell/#setR1C1Formula-java.lang.String-) คืออะไร?**

[IChartDataCell.setFormula](https://reference.aspose.com/slides/th/java/com.aspose.slides/ichartdatacell/#setFormula-java.lang.String-) เก็บนิพจน์แบบ A1 เช่น `B2-C2` ส่วน [IChartDataCell.setR1C1Formula](https://reference.aspose.com/slides/th/java/com.aspose.slides/ichartdatacell/#setR1C1Formula-java.lang.String-) เก็บนิพจน์แบบ R1C1 เช่น `RC[-2]-RC[-1]` ใช้รูปแบบที่สอดคล้องกับวิธีการสร้างหรือคัดลอกสูตรของคุณ

**ฉันต้องอ่านเซลล์เองหรือค่าในเซลล์หลังการคำนวณ?**

[IChartDataWorkbook.getCell](https://reference.aspose.com/slides/th/java/com.aspose.slides/ichartdataworkbook/#getCell-int-java.lang.String-) คืนค่า [IChartDataCell](https://reference.aspose.com/slides/th/java/com.aspose.slides/ichartdatacell/) เพื่อให้ได้ผลลัพธ์ที่คำนวณแล้ว ให้เรียกเมธอด [IChartDataCell.getValue](https://reference.aspose.com/slides/th/java/com.aspose.slides/ichartdatacell/#getValue--) ของเซลล์นั้นหลังการคำนวณใหม่

**ควรเรียก [IChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/th/java/com.aspose.slides/ichartdataworkbook/#calculateFormulas--) เมื่อใด?**

เรียก [IChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/th/java/com.aspose.slides/ichartdataworkbook/#calculateFormulas--) หลังจากเปลี่ยนค่ อินพุตหรือสูตร แล้วก่อนที่คุณจะพึ่งพาผลลัพธ์ที่คำนวณ ซึ่งจะอัปเดตค่าของสูตรที่เครื่องประเมินในตัวรองรับ

**Aspose.Slides รองรับทุกฟังก์ชันของ Excel หรือไม่?**

ไม่ โดยเครื่องประเมินในตัวรองรับชุดฟังก์ชันที่เอกสารกำหนดฟังก์ชันที่อยู่นอกชุดนั้นไม่ควรถือว่าคำนวณได้อย่างถูกต้อง หากต้องการความเข้ากันได้เต็มรูปแบบกับสูตร Excel ให้ทำการคำนวณด้วยเอนจินสเปรดชีตที่เหมาะสมและเขียนค่าที่ได้ลงใน workbook ของแผนภูมิ

**เกิดอะไรขึ้นถ้างานนำเข้าที่โหลดมีสูตรที่ไม่รองรับ?**

หากข้อมูลแผนภูมิไม่เปลี่ยน ค่าที่แคชไว้ใน workbook อาจยังคงอยู่ หลังจากข้อมูลที่เกี่ยวข้องถูกแก้ไข ค่าที่แคชนั้นอาจไม่ถูกต้องแล้ว การเข้าถึงเซลล์ที่สูตรไม่สามารถจัดการได้อาจทำให้เกิด [CellUnsupportedDataException](https://reference.aspose.com/slides/th/java/com.aspose.slides/cellunsupporteddataexception/)

**ค่าข้อผิดพลาดของสูตรคือค่าเดียวกับข้อยกเว้นใน Java หรือไม่?**

ไม่ ผลลัพธ์เช่น `#DIV/0!` เป็นค่าของสเปรดชีตที่ได้จากการคำนวณที่ถูกต้อง ส่วนข้อยกเว้นเช่น [CellInvalidFormulaException](https://reference.aspose.com/slides/th/java/com.aspose.slides/cellinvalidformulaexception/) หรือ [CellCircularReferenceException](https://reference.aspose.com/slides/th/java/com.aspose.slides/cellcircularreferenceexception/) บ่งชี้ว่ารูปแบบสูตรไม่สามารถประมวลผลได้ตามปกติ

**แผนภูมิอัพเดตอัตโนมัติเมื่อเซลล์สูตรเปลี่ยนหรือไม่?**

ชุดข้อมูลของแผนภูมิสามารถอ้างอิงเซลล์ workbook ได้ คำนวณ workbook ก่อน แล้วบันทึกหรือเรนเดอร์งานนำเสนอ หากจุดข้อมูลของแผนภูมิอ้างอิงเซลล์ที่คำนวณแล้ว แผนภูมิจะใช้ค่าที่อัปเดตนั้น ไม่ต้องมีเมธอดรีเฟรชแผนภูมิแยกต่างหาก

**แผนภูมิสามารถใช้ workbook Excel ภายนอกได้หรือไม่?**

ได้, ข้อมูลแผนภูมิสามารถกำหนดให้ใช้ workbook ภายนอกผ่าน API ของข้อมูลแผนภูมิ อย่างไรก็ตาม กระบวนการคำนวณสูตรที่อธิบายในบทความนี้เกี่ยวข้องกับ workbook ของข้อมูลแผนภูมิและชุดสูตรที่ Aspose.Slides ประเมิน ไม่ควรสันนิษฐานว่า [IChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/th/java/com.aspose.slides/ichartdataworkbook/#calculateFormulas--) ให้การคำนวณเต็มรูปแบบของสูตรใด ๆ ในไฟล์ XLSX ภายนอก

**ฉันสามารถใช้สูตรที่อ้างอิงเวิร์กชีตหรือ workbook อื่นได้หรือไม่?**

การอ้างอิงแบบ Excel อาจมีอยู่ใน workbook ของแผนภูมิ แต่การประเมินสูตรจำกัดโดยตัวแปลและชุดฟังก์ชันที่รองรับ หากการอ้างอิงข้ามชีตหรือไฟล์ภายนอกเป็นสิ่งจำเป็น ให้ตรวจสอบสูตรนั้นกับเวอร์ชัน Aspose.Slides ที่คุณใช้งาน สำหรับกระบวนการที่ต้องการความเข้ากันได้ของการอ้างอิง Excel อย่างกว้าง ควรคำนวณ workbook ภายนอกแล้วเขียนค่าที่ได้กลับไปยังข้อมูลแผนภูมิ

**สูตรควรเริ่มด้วย `=` หรือไม่?**

ตัวอย่าง API ของ Aspose.Slides จะกำหนดนิพจน์เช่น `B2-C2` หรือ `SUM(B2:B5)` โดยไม่มีเครื่องหมาย `=` นำหน้า การใช้รูปแบบนี้ทำให้สูตรที่สร้างสอดคล้องกับตัวอย่าง API ที่ระบุไว้