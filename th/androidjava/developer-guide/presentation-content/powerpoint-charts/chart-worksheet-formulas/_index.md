---
title: ใช้สูตร Worksheet ของแผนภูมิในงานนำเสนอบน Android
linktitle: สูตร Worksheet
type: docs
weight: 70
url: /th/androidjava/chart-worksheet-formulas/
keywords:
- แผนภูมิสเปรดชีต
- Worksheet ของแผนภูมิ
- สูตรแผนภูมิ
- สูตร Worksheet
- สูตรสเปรดชีต
- Workbook ข้อมูลแผนภูมิ
- การคำนวนสูตร
- วัฒนธรรมที่ต้องการ
- สูตรที่กำหนดตามวัฒนธรรม
- DBCS
- ค่าคงที่ตรรกะ
- ค่าคงที่เชิงตัวเลข
- ค่าคงที่สตริง
- ค่าคงที่ข้อผิดพลาด
- เครื่องหมายคณิตศาสตร์
- เครื่องหมายเปรียบเทียบ
- รูปแบบ A1
- รูปแบบ R1C1
- ฟังก์ชันกำหนดล่วงหน้า
- PowerPoint
- งานนำเสนอ
- Android
- Java
- Aspose.Slides
description: "ใช้สูตรสไตล์ Excel ใน Aspose.Slides สำหรับ Android ผ่าน worksheet ของแผนภูมิ Java, คำนวนค่าใหม่, และใช้ผลลัพธ์ในแผนภูมิ PowerPoint."
---
## **ภาพรวม**

PowerPoint charts มักจัดเก็บข้อมูลต้นทางใน worksheet ที่ฝังอยู่ในไฟล์ การใช้งาน Aspose.Slides for Android via Java คุณสามารถเข้าถึง worksheet นั้นผ่าน chart data workbook, เขียนค่าอินพุต, กำหนดสูตรให้กับเซลล์, คำนวณสูตรที่สนับสนุน, และใช้เซลล์ที่คำนวณแล้วเป็นข้อมูลสำหรับแผนภูมิ

บทความนี้อธิบายขั้นตอนการทำงานของสูตรอย่างครบถ้วน: สร้างแผนภูมิ, เติมข้อมูลลงใน worksheet, กำหนดสูตรแบบ A1 หรือ R1C1, คำนวนสูตรใหม่, อ่านค่าที่คำนวณแล้ว, เชื่อมต่อเซลล์เหล่านั้นกับ series ของแผนภูมิ, และบันทึกงานนำเสนอ นอกจากนี้ยังอธิบายไวยากรณ์สูตรที่สนับสนุน, ชุดฟังก์ชันที่มีมาให้, ค่าที่แคช, สูตรที่ไม่สนับสนุน, และข้อผิดพลาดที่เกี่ยวกับ spreadsheet

## **Chart Worksheets and Formulas**

Worksheet ของแผนภูมิประกอบด้วยหมวดหมู่, ชื่อ series, และค่า ที่ใช้โดยแผนภูมิ ใน PowerPoint คุณสามารถตรวจสอบ worksheet ได้โดยการเปิด chart data editor:

![PowerPoint chart with its embedded worksheet open, showing category and series data](chart-worksheet-formulas_1.png)

ใน Aspose.Slides worksheet จะถูกเปิดให้เข้าถึงผ่านอินเทอร์เฟซ [IChartDataWorkbook](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ichartdataworkbook/) ใช้ [IChartDataCell.setFormula](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ichartdatacell/#setFormula-java.lang.String-) สำหรับสูตรแบบ A1 และใช้ [IChartDataCell.setR1C1Formula](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ichartdatacell/#setR1C1Formula-java.lang.String-) สำหรับสูตรแบบ R1C1 หลังจากเปลี่ยนเซลล์อินพุตหรือสูตร ให้เรียก [IChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ichartdataworkbook/#calculateFormulas--) เพื่อคำนวณสูตรที่สนับสนุนและอัปเดตค่าเซลล์ที่สอดคล้องกัน

เซลล์ที่คำนวณแล้วยังคงเปิดเผยผลลัพธ์ผ่าน [IChartDataCell.getValue](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ichartdatacell/#getValue--) ซึ่งสำคัญเมื่อคุณต้องการตรวจสอบผลลัพธ์ของสูตรในโค้ดหรือใช้เซลล์เป็นจุดข้อมูลของแผนภูมิ

## **Create a Chart and Calculate Worksheet Formulas**

ตัวอย่างต่อไปนี้สาธิตขั้นตอนทำงานตั้งแต่ต้นจนจบ มันสร้างแผนภูมิคอลัมน์แบบกลุ่ม, ลบข้อมูลตัวอย่าง, เขียนค่ารายได้และค่าใช้จ่ายไตรมาส, คำนวณกำไรด้วยสูตร, อ่านผลลัพธ์, ใช้เซลล์ที่คำนวณแล้วเป็นค่าของแผนภูมิ, และบันทึกงานนำเสนอ

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

จุดข้อมูลของแผนภูมิอ้างอิง `D2:D4` ดังนั้นแผนภูมิจะใช้ค่ากำไรที่คำนวณแล้ว ไม่ต้องมีการเรียกรีเฟรชแผนภูมิแยกต่างหากในขั้นตอนนี้: คำนวน workbook ก่อน, แล้วจึงใช้หรือบันทึกข้อมูลแผนภูมิที่อ้างอิงเซลล์ที่คำนวณ

## **Use A1-Style Formulas**

รูปแบบ A1 ระบุคอลัมน์ด้วยตัวอักษรและแถวด้วยตัวเลข กำหนดนิพจน์แบบ A1 ผ่าน [IChartDataCell.setFormula](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ichartdatacell/#setFormula-java.lang.String-).

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

รูปแบบการอ้างอิง A1 ที่พบบ่อยคือ:

| อ้างอิง | สัมพัทธ์ | คงที่ | ผสม |
|---|---|---|---|
| Cell | `A2` | `$A$2` | `A$2`, `$A2` |
| Row | `2:2` | `$2:$2` | — |
| Column | `A:A` | `$A:$A` | — |
| Range | `A2:C4` | `$A$2:$C$4` | `A$2:$C4`, `$A2:C$4` |

การอ้างอิงแบบสัมพัทธ์อาจเปลี่ยนเมื่อสูตรถูกย้ายหรือคัดลอกโดยแอปพลิเคชัน spreadsheet. การอ้างอิงแบบคงที่จะคงค่าพิกัดทั้งสองไว้, ส่วนการอ้างอิงแบบผสมจะคงแค่แถวหรือคอลัมน์หนึ่ง

## **Use R1C1-Style Formulas**

รูปแบบ R1C1 ระบุทั้งแถวและคอลัมน์ด้วยตัวเลข การอ้างอิงแบบสัมพัทธ์ใช้การยกเว้นในวงเล็บเหลี่ยม [] กำหนดไวยากรณ์นี้ผ่าน [IChartDataCell.setR1C1Formula](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ichartdatacell/#setR1C1Formula-java.lang.String-).

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

รูปแบบการอ้างอิง R1C1 ที่พบบ่อยคือ:

| อ้างอิง | สัมพัทธ์ | คงที่ | ผสม |
|---|---|---|---|
| Cell | `R[2]C[3]` | `R2C3` | `R2C[3]`, `R[2]C3` |
| Row | `R[2]` | `R2` | — |
| Column | `C[3]` | `C3` | — |
| Range | `R[2]C[3]:R[5]C[7]` | `R2C3:R5C7` | `R2C3:R[5]C[7]`, `R[2]C3:R5C[7]` |

ตัวอย่างเช่น ในเซลล์ `D2` คำว่า `RC[-2]` หมายถึงเซลล์เดียวกันในแถวเดียวกันสองคอลัมน์ทางซ้าย (`B2`).

## **Formula Constants and Operators**

ตัวประเมินสูตรในตัวสนับสนุนค่าตรรกะ, ค่าตัวเลข, สตริง, ค่าข้อผิดพลาดของ spreadsheet, ตัวดำเนินการคณิตศาสตร์, และตัวดำเนินการเปรียบเทียบ

### **ค่าคงที่และลิเทอรัล**

| ประเภท | ตัวอย่าง | หมายเหตุ |
|---|---|---|
| Logical | `TRUE`, `FALSE` | สามารถใช้โดยตรงในนิพจน์ตรรกะ เช่น `A2=TRUE`. |
| Numeric | `1`, `0.5`, `.3`, `1E-2` | รองรับการเขียนแบบธรรมดาและวิทยาศาสตร์. |
| String | `"abc"`, `"2/3/2020 12:00"` | ลิเทอรัลข้อความอยู่ในเครื่องหมายอัญประกาศคู่ภายในสูตร. |
| Error result | `#DIV/0!`, `#N/A`, `#REF!` | สูตรที่ถูกต้องอาจให้ค่าข้อผิดพลาดของ spreadsheet แทนผลลัพธ์ปกติ. |

ตัวอย่างนี้ใช้หลายประเภทค่าคงที่:

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
| `+` | บวกหรือเครื่องหมายบวกยูนรี | `2+3` |
| `-` | ลบหรือเครื่องหมายลบยูนรี | `2-3`, `-3` |
| `*` | คูณ | `2*3` |
| `/` | หาร | `2/3` |
| `%` | เปอร์เซ็นต์ | `30%` |
| `^` | ยกกำลัง | `2^3` |

ใช้วงเล็บเพื่อระบุลำดับการประเมินอย่างชัดเจน เช่น `(A2+B2)*C2`.

### **ตัวดำเนินการเปรียบเทียบ**

| ตัวดำเนินการ | ความหมาย | ตัวอย่าง |
|---|---|---|
| `=` | เท่ากับ | `A2=3` |
| `<>` | ไม่เท่ากับ | `A2<>3` |
| `>` | มากกว่า | `A2>3` |
| `>=` | มากกว่า หรือเท่ากับ | `A2>=3` |
| `<` | น้อยกว่า | `A2<3` |
| `<=` | น้อยกว่า หรือเท่ากับ | `A2<=3` |

## **Supported Predefined Functions**

Aspose.Slides มีตัวประเมินสูตรในตัวสำหรับ worksheet ของแผนภูมิ แต่ไม่ใช่เครื่องมือคำนวน Excel ครบวงจร ชุดฟังก์ชันที่ระบุไว้จำกัดอยู่ที่ฟังก์ชันด้านล่าง อย่าเชื่อว่าฟังก์ชัน Excel ใด ๆ สามารถคำนวนใหม่ได้โดย [IChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ichartdataworkbook/#calculateFormulas--).

| ฟังก์ชัน | วัตถุประสงค์หรือรูปแบบที่สนับสนุน | ตัวอย่าง |
|---|---|---|
| `ABS` | ค่าตัวเลขค่าสัมบูรณ์ | `ABS(A2)` |
| `AVERAGE` | ค่าเฉลี่ยทางคณิตศาสตร์ | `AVERAGE(B2:B5)` |
| `CEILING` | ปัดเลขขึ้นเป็นหลายของจำนวน | `CEILING(A2,5)` |
| `CHOOSE` | เลือกค่าตามดัชนี | `CHOOSE(A2,"Low","High")` |
| `CONCAT` | เชื่อมต่อค่าข้อความ | `CONCAT(A2,B2)` |
| `CONCATENATE` | เชื่อมต่อค่าข้อความ | `CONCATENATE(A2," ",B2)` |
| `DATE` | สร้างค่าวันที่โดยใช้ระบบวันที่ 1900 | `DATE(2026,8,19)` |
| `DAYS` | คืนจำนวนวันที่ห่างกันระหว่างวันที่ | `DAYS(B2,A2)` |
| `FIND` | ค้นหาค่าข้อความหนึ่งภายในอีกค่า | `FIND("-",A2)` |
| `FINDB` | ค้นหาข้อความแบบไบท์ | `FINDB("a",A2)` |
| `IF` | ผลลัพธ์ตามเงื่อนไข | `IF(A2>0,A2,0)` |
| `INDEX` | รูปแบบการอ้างอิง | `INDEX(A2:C4,2,3)` |
| `LOOKUP` | รูปแบบเวกเตอร์ | `LOOKUP(A2,B2:B5,C2:C5)` |
| `MATCH` | รูปแบบเวกเตอร์ | `MATCH(A2,B2:B5,0)` |
| `MAX` | ค่ามากที่สุด | `MAX(B2:B5)` |
| `SUM` | ผลรวมของค่า | `SUM(B2:B5)` |
| `VLOOKUP` | ค้นหาตามแนวตั้ง | `VLOOKUP(A2,B2:D10,3,FALSE)` |

ข้อจำกัดที่แสดงในตารางมีความสำคัญ: `INDEX` ระบุในรูปแบบการอ้างอิง, ส่วน `LOOKUP` และ `MATCH` ระบุในรูปแบบเวกเตอร์. `DATE` ใช้ระบบวันที่ 1900. ฟังก์ชันและคุณลักษณะที่ไม่ได้ระบุที่นี่ควรถือว่าไม่สนับสนุนโดยตัวประเมินสูตรของ Aspose.Slides ยกเว้นว่าจะมีการระบุแยกต่างหาก

## **Calculate Formulas with a Preferred Culture**

ฟังก์ชันบางตัวของ chart workbook จะตีความข้อความตามกฎของวัฒนธรรมเฉพาะ ซึ่งสำคัญเป็นพิเศษสำหรับฟังก์ชันที่ออกแบบสำหรับภาษาที่ใช้ชุดอักขระสองไบต์ (DBCS) เพื่อคำนวณสูตรเหล่านี้อย่างถูกต้อง ให้สร้าง [LoadOptions](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/loadoptions/), ตั้งค่าวัฒนธรรมที่ต้องการด้วย [SpreadsheetOptions.setPreferredCulture](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/spreadsheetoptions/#setPreferredCulture-java.util.Locale-), กำหนดตัวเลือก spreadsheet ผ่าน [LoadOptions.setSpreadsheetOptions](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/loadoptions/#setSpreadsheetOptions-com.aspose.slides.ISpreadsheetOptions-), แล้วโหลดงานนำเสนอ

ตัวอย่างต่อไปนี้เลือกวัฒนธรรมญี่ปุ่น, เปิดงานนำเสนอด้วยตัวเลือกการโหลดที่กำหนด, และเรียก [IChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ichartdataworkbook/#calculateFormulas--) สำหรับทุก chart workbook:

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

วัฒนธรรมที่ต้องการเป็นส่วนหนึ่งของการกำหนดค่าการโหลดงานนำเสนอ ดังนั้นให้ระบุก่อนสร้างอินสแตนซ์ของ [Presentation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/presentation/) ใช้วัฒนธรรมที่สูตรใน workbook คาดหวัง; ตัวอย่างเช่น ใช้ `ja-JP` สำหรับสูตรที่ต้องปฏิบัติตามกฎการคำนวน DBCS ของญี่ปุ่น

## **Recalculation and Cached Values**

ไฟล์ spreadsheet มักเก็บทั้งสูตรและค่าที่คำนวนล่าสุด Aspose.Slides จึงสามารถอ่านค่าที่แคชจาก [IChartDataCell.getValue](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ichartdatacell/#getValue--) เมื่อโหลดงานนำเสนอและข้อมูลแผนภูมิที่เกี่ยวข้องไม่ได้ถูกเปลี่ยนแปลง

หลังจากเปลี่ยนเซลล์อินพุตหรือสูตร อย่าอ้างอิงค่าที่แคชเก่า ให้เรียก [IChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ichartdataworkbook/#calculateFormulas--) ก่อนอ่านค่าที่คำนวนแล้วหรือบันทึกข้อมูลแผนภูมิที่ขึ้นกับค่านั้น

สำหรับสูตรที่อยู่นอกชุดที่สนับสนุน Aspose.Slides อาจไม่สามารถแยกวิเคราะห์สูตรหรือระบุการพึ่งพาได้ หาก workbook ถูกแก้ไข ค่าที่แคชก่อนหน้านี้จะไม่ถือว่าเชื่อถือได้ ในสถานการณ์นั้น การอ่านค่าของเซลล์ที่มีข้อมูลที่ไม่สนับสนุนอาจทำให้เกิด [CellUnsupportedDataException](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/cellunsupporteddataexception/).

หากแผนภูมิของคุณพึ่งพาฟังก์ชัน Excel ที่ Aspose.Slides ไม่ประมวลผล ให้คำนวนสูตรเหล่านั้นด้วยเอนจิ้น spreadsheet ที่สนับสนุนและเขียนค่าที่ได้กลับไปยัง chart workbook อย่าแทนสูตรที่ไม่สนับสนุนด้วยค่าที่คาดเดา

## **Handle Formula Errors**

มีสองประเภทของปัญหาที่ต้องแยกแยะ

สูตรอาจถูกต้องแต่ให้ผลลัพธ์เป็นข้อผิดพลาดของ spreadsheet เช่น `#DIV/0!`, `#N/A`, `#NAME?`, `#NULL!`, `#NUM!`, `#REF!`, หรือ `#VALUE!` ในกรณีนี้ โทเคนข้อผิดพลาดเป็นผลลัพธ์ของเซลล์และสามารถคืนค่าผ่าน [IChartDataCell.getValue](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ichartdatacell/#getValue--)

สูตรอาจล้มเหลวที่ขั้นตอนการแยกวิเคราะห์, การอ้างอิง, การพึ่งพา, หรือระดับข้อมูลที่สนับสนุน Aspose.Slides มีข้อยกเว้นเฉพาะ spreadsheet สำหรับกรณีเหล่านี้: [CellInvalidFormulaException](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/cellinvalidformulaexception/), [CellInvalidReferenceException](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/cellinvalidreferenceexception/), [CellCircularReferenceException](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/cellcircularreferenceexception/), และ [CellUnsupportedDataException](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/cellunsupporteddataexception/)

เมื่อสูตรมาจากเทมเพลตหรืออินพุตของผู้ใช้ ให้จัดการกับข้อยกเว้นเหล่านี้รอบการคำนวนใหม่และการเข้าถึงค่า:

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

## **Practical Limitations**

การสนับสนุนสูตรใน worksheet ของแผนภูมิมุ่งเน้นที่ชุดย่อยที่กำหนดของการคำนวน spreadsheet ไม่ใช่ความเข้ากันได้เต็มรูปแบบกับ Excel โปรดจำข้อจำกัดเหล่านี้เมื่อออกแบบ workflow ของการรายงาน:

- ใช้เฉพาะค่าคงที่, ตัวดำเนินการ, การอ้างอิง, และฟังก์ชันที่ระบุไว้เมื่อคุณต้องการให้ Aspose.Slides คำนวนสูตรใหม่.
- คำนวนใหม่หลังจากเปลี่ยนเซลล์ที่ผลลัพธ์สูตรขึ้นกับ.
- ถือค่าที่แคชจากงานนำเข้าที่โหลดเป็นสแนปชอต, ไม่ใช่การแทนที่การคำนวนใหม่หลังการแก้ไข.
- ทดสอบสูตรจากเทมเพลตที่มีอยู่ก่อนพึ่งพาค่าที่คำนวนแล้ว, โดยเฉพาะเมื่อใช้ฟังก์ชันนอกรายการที่ระบุ.
- สำหรับสูตรที่ต้องการเอนจิ้นคำนวน spreadsheet เต็มรูปแบบ, คำนวนสูตรนั้นภายนอกแล้วอัปเดต chart workbook ด้วยค่าที่ได้.

## **FAQ**

**ความแตกต่างระหว่าง [IChartDataCell.setFormula](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ichartdatacell/#setFormula-java.lang.String-) กับ [IChartDataCell.setR1C1Formula](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ichartdatacell/#setR1C1Formula-java.lang.String-)?**

[IChartDataCell.setFormula] เก็บนิพจน์แบบ A1 เช่น `B2-C2`. [IChartDataCell.setR1C1Formula] เก็บนิพจน์แบบ R1C1 เช่น `RC[-2]-RC[-1]`. ใช้รูปแบบที่ตรงกับวิธีที่คุณสร้างหรือคัดลอกสูตร.

**ฉันต้องอ่านเซลล์เองหรือค่าของมันหลังการคำนวนหรือไม่?**

[IChartDataWorkbook.getCell] คืนค่า [IChartDataCell]. เพื่อให้ได้ผลลัพธ์ที่คำนวนแล้ว ให้เรียกเมธอด [IChartDataCell.getValue] ของเซลล์นั้นหลังการคำนวนใหม่.

**ฉันควรเรียก [IChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ichartdataworkbook/#calculateFormulas--) เมื่อไหร่?**

ให้เรียก [IChartDataWorkbook.calculateFormulas] หลังจากเปลี่ยนค่าอินพุตหรือสูตรและก่อนที่คุณจะพึ่งพาผลลัพธ์ที่คำนวนแล้ว. การเรียกนี้จะอัปเดตค่าของสูตรที่ตัวประเมินในตัวสนับสนุน.

**Aspose.Slides รองรับทุกฟังก์ชันของ Excel หรือไม่?**

ไม่. ตัวประเมินในตัวสนับสนุนชุดฟังก์ชันที่ระบุไว้เท่านั้น ฟังก์ชันนอกชุดนั้นไม่ควรถือว่าคำนวนได้อย่างถูกต้อง. หากต้องการความเข้ากันได้เต็มรูปแบบของสูตร Excel, ให้คำนวนด้วยเอนจิ้น spreadsheet ที่เหมาะสมและเขียนค่าที่ได้ไปยัง chart workbook.

**จะเกิดอะไรขึ้นหากงานนำเสนอที่โหลดมีสูตรที่ไม่สนับสนุน?**

หากข้อมูลแผนภูมิไม่ได้เปลี่ยน แบคค่าที่คำนวนไว้ก่อนหน้าอาจยังคงอยู่. หลังจากข้อมูลที่เกี่ยวข้องถูกแก้ไข แบคค่านั้นอาจไม่ถูกต้องแล้ว. การเข้าถึงเซลล์ที่สูตรไม่สามารถจัดการได้อาจทำให้เกิด [CellUnsupportedDataException](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/cellunsupporteddataexception/).

**ค่าข้อผิดพลาดของสูตรเป็นเหมือนกับข้อยกเว้นของ Java หรือไม่?**

ไม่. ผลลัพธ์เช่น `#DIV/0!` เป็นค่าของ spreadsheet ที่เกิดจากการคำนวนที่ถูกต้อง. ข้อยกเว้นเช่น [CellInvalidFormulaException](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/cellinvalidformulaexception/) หรือ [CellCircularReferenceException](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/cellcircularreferenceexception/) แสดงว่ารูปแบบสูตรไม่สามารถประมวลผลได้ตามปกติ.

**แผนภูมิจะอัปเดตโดยอัตโนมัติเมื่อเซลล์สูตรเปลี่ยนหรือไม่?**

Series ของแผนภูมิสามารถอ้างอิงเซลล์ workbook. คำนวน workbook ก่อนแล้วบันทึกหรือแสดงงานนำเสนอ. หากจุดข้อมูลของแผนภูมิอ้างอิงเซลล์ที่คำนวนแล้ว แผนภูมิจะใช้ค่าเหล่านั้น; ไม่ต้องมีเมธอดรีเฟรชแผนภูมิแยกต่างหากใน workflow นี้.

**แผนภูมิสามารถใช้ workbook Excel ภายนอกได้หรือไม่?**

ได้, ข้อมูลแผนภูมิสามารถกำหนดให้ใช้ workbook ภายนอกผ่าน API ของข้อมูลแผนภูมิ. อย่างไรก็ตาม workflow การคำนวนสูตรที่อธิบายในบทความนี้เกี่ยวกับ chart data workbook และชุดสูตรที่ Aspose.Slides ประเมิน. อย่าคาดว่า [IChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ichartdataworkbook/#calculateFormulas--) จะคำนวนสูตรทั้งหมดในไฟล์ XLSX ภายนอกอย่างเต็มที่.

**ฉันสามารถใช้สูตรที่อ้างอิง worksheet หรือ workbook อื่นได้หรือไม่?**

การอ้างอิงแบบ Excel อาจมีอยู่ใน chart workbook, แต่การประเมินสูตรถูกจำกัดโดย parser และชุดฟังก์ชันที่สนับสนุน. หากการอ้างอิงข้าม sheet หรือภายนอกเป็นสิ่งจำเป็น ให้ตรวจสอบสูตรนั้นกับเวอร์ชัน Aspose.Slides ที่คุณใช้. สำหรับ workflow ที่ต้องการความเข้ากันได้ของการอ้างอิง Excel อย่างกว้างขวาง, คำนวน workbook ภายนอกและเขียนค่าที่ได้กลับไปยังข้อมูลแผนภูมิ.

**สูตรควรขึ้นต้นด้วย `=` หรือไม่?**

ตัวอย่าง API ของ Aspose.Slides กำหนดนิพจน์เช่น `B2-C2` หรือ `SUM(B2:B5)` โดยไม่ต้องมี `=` นำหน้า การใช้รูปแบบนี้ทำให้สูตรที่สร้างสอดคล้องกับตัวอย่าง API ที่ระบุ.