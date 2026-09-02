---
title: ใช้สูตรเวิร์กชีตแผนภูมิในงานนำเสนอด้วย PHP
linktitle: สูตรเวิร์กชีต
type: docs
weight: 70
url: /th/php-java/chart-worksheet-formulas/
keywords:
- สเปรดชีตแผนภูมิ
- เวิร์กชีตแผนภูมิ
- สูตรแผนภูมิ
- สูตรเวิร์กชีต
- สูตรสเปรดชีต
- เวิร์กบุ๊กข้อมูลแผนภูมิ
- การคำนวณสูตร
- ค่าคงที่ตรรกะ
- ค่าคงที่จำนวน
- ค่าคงที่สตริง
- ค่าคงที่ข้อผิดพลาด
- ผู้ดำเนินการคณิตศาสตร์
- ผู้ดำเนินการเปรียบเทียบ
- สไตล์ A1
- สไตล์ R1C1
- ฟังก์ชันที่กำหนดไว้ล่วงหน้า
- PowerPoint
- งานนำเสนอ
- PHP
- Aspose.Slides
description: "ใช้สูตรสไตล์ Excel ใน Aspose.Slides สำหรับ PHP ผ่าน Java แผนภูมิเวิร์กชีต, คำนวณค่าใหม่, และใช้ผลลัพธ์ในแผนภูมิ PowerPoint."
---
## **ภาพรวม**

PowerPoint charts usually store their source data in an embedded worksheet. In Aspose.Slides for PHP via Java, you can access that worksheet through the chart data workbook, write input values, assign formulas to cells, calculate supported formulas, and use the calculated cells as chart data.

This article explains the complete formula workflow: create a chart, populate its worksheet, assign A1-style or R1C1-style formulas, recalculate them, read the calculated values, connect those cells to a chart series, and save the presentation. It also describes the supported formula syntax, the built-in function subset, cached values, unsupported formulas, and spreadsheet-specific errors.

## **เวิร์กชีตแผนภูมิและสูตร**

A chart worksheet contains the categories, series names, and values used by a chart. In PowerPoint, you can inspect the worksheet by opening the chart data editor:

![แผนภูมิ PowerPoint พร้อมเวิร์กชีตที่ฝังอยู่เปิดอยู่ แสดงข้อมูลหมวดหมู่และซีรีส์](chart-worksheet-formulas_1.png)

In Aspose.Slides, the worksheet is exposed through the [ChartDataWorkbook](https://reference.aspose.com/slides/th/php-java/aspose.slides/chartdataworkbook/) class. Use [ChartDataCell::setFormula](https://reference.aspose.com/slides/th/php-java/aspose.slides/chartdatacell/#setFormula) for A1-style formulas and [ChartDataCell::setR1C1Formula](https://reference.aspose.com/slides/th/php-java/aspose.slides/chartdatacell/#setR1C1Formula) for R1C1-style formulas. After changing input cells or formulas, call [ChartDataWorkbook::calculateFormulas](https://reference.aspose.com/slides/th/php-java/aspose.slides/chartdataworkbook/#calculateFormulas) to recalculate supported formulas and update the corresponding cell values.

A calculated cell still exposes its result through [ChartDataCell::getValue](https://reference.aspose.com/slides/th/php-java/aspose.slides/chartdatacell/#getValue). This is important when you need to inspect a formula result in code or use the cell as a chart data point.

## **สร้างแผนภูมิและคำนวณสูตรในเวิร์กชีต**

The following example demonstrates an end-to-end workflow. It creates a clustered column chart, clears the sample data, writes quarterly revenue and expense values, calculates profit with formulas, reads the results, uses the calculated cells as chart values, and saves the presentation.

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 600, 350);
    $workbook = $chart->getChartData()->getChartDataWorkbook();
    $worksheetIndex = 0;

    $chart->getChartData()->getSeries()->clear();
    $chart->getChartData()->getCategories()->clear();
    $workbook->clear($worksheetIndex);

    $category1 = $workbook->getCell($worksheetIndex, "A2", "Q1");
    $category2 = $workbook->getCell($worksheetIndex, "A3", "Q2");
    $category3 = $workbook->getCell($worksheetIndex, "A4", "Q3");

    $workbook->getCell($worksheetIndex, "B1", "Revenue");
    $workbook->getCell($worksheetIndex, "C1", "Expenses");
    $workbook->getCell($worksheetIndex, "D1", "Profit");

    $workbook->getCell($worksheetIndex, "B2")->setValue(120.0);
    $workbook->getCell($worksheetIndex, "C2")->setValue(80.0);
    $workbook->getCell($worksheetIndex, "B3")->setValue(150.0);
    $workbook->getCell($worksheetIndex, "C3")->setValue(95.0);
    $workbook->getCell($worksheetIndex, "B4")->setValue(135.0);
    $workbook->getCell($worksheetIndex, "C4")->setValue(110.0);

    $profit1 = $workbook->getCell($worksheetIndex, "D2");
    $profit2 = $workbook->getCell($worksheetIndex, "D3");
    $profit3 = $workbook->getCell($worksheetIndex, "D4");

    $profit1->setFormula("B2-C2");
    $profit2->setFormula("B3-C3");
    $profit3->setFormula("B4-C4");

    $workbook->calculateFormulas();

    $q1Profit = java_values($profit1->getValue()); // 40
    $q2Profit = java_values($profit2->getValue()); // 55
    $q3Profit = java_values($profit3->getValue()); // 25

    echo "Q1 profit: " . $q1Profit . PHP_EOL;
    echo "Q2 profit: " . $q2Profit . PHP_EOL;
    echo "Q3 profit: " . $q3Profit . PHP_EOL;

    $chart->getChartData()->getCategories()->add($category1);
    $chart->getChartData()->getCategories()->add($category2);
    $chart->getChartData()->getCategories()->add($category3);

    $profitSeries = $chart->getChartData()->getSeries()->add($workbook->getCell($worksheetIndex, "D1"), $chart->getType());
    $profitSeries->getDataPoints()->addDataPointForBarSeries($profit1);
    $profitSeries->getDataPoints()->addDataPointForBarSeries($profit2);
    $profitSeries->getDataPoints()->addDataPointForBarSeries($profit3);
    $profitSeries->getLabels()->getDefaultDataLabelFormat()->setShowValue(true);

    $presentation->save("chart-formulas.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

The chart data points reference `D2:D4`, so the chart uses the calculated profit values. There is no separate chart-refresh call in this workflow: recalculate the workbook first, then use or save the chart data that points to the calculated cells.

## **ใช้สูตรสไตล์ A1**

A1 notation identifies columns with letters and rows with numbers. Assign A1-style expressions through [ChartDataCell::setFormula](https://reference.aspose.com/slides/th/php-java/aspose.slides/chartdatacell/#setFormula).

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 500, 300);
    $workbook = $chart->getChartData()->getChartDataWorkbook();

    $workbook->getCell(0, "C3")->setValue(10);
    $workbook->getCell(0, "F2")->setValue(2);
    $workbook->getCell(0, "G2")->setValue(3);
    $workbook->getCell(0, "H2")->setValue(4);

    $cell = $workbook->getCell(0, "A2");
    $cell->setFormula("C3+SUM(F2:H2)");

    $workbook->calculateFormulas();

    $value = java_values($cell->getValue()); // 19
} finally {
    $presentation->dispose();
}
```

รูปแบบการอ้างอิง A1 ที่พบบ่อยคือ:

| อ้างอิง | สัมพัทธ์ | แน่นอน | ผสม |
|---|---|---|---|
| เซลล์ | `A2` | `$A$2` | `A$2`, `$A2` |
| แถว | `2:2` | `$2:$2` | — |
| คอลัมน์ | `A:A` | `$A:$A` | — |
| ช่วง | `A2:C4` | `$A$2:$C$4` | `A$2:$C4`, `$A2:C$4` |

การอ้างอิงสัมพัทธ์อาจเปลี่ยนเมื่อสูตรถูกย้ายหรือคัดลอกโดยแอปพลิเคชันสเปรดชีต การอ้างอิงแน่นอนจะคงพิกัดทั้งสองคงที่, ส่วนการอ้างอิงผสมนั้นจะคงแถวหรือคอลัมน์เพียงอย่างเดียว.

## **ใช้สูตรสไตล์ R1C1**

R1C1 notation identifies both rows and columns numerically. Relative references use offsets in square brackets. Assign this syntax through [ChartDataCell::setR1C1Formula](https://reference.aspose.com/slides/th/php-java/aspose.slides/chartdatacell/#setR1C1Formula).

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 500, 300);
    $workbook = $chart->getChartData()->getChartDataWorkbook();

    $workbook->getCell(0, "B2")->setValue(12);
    $workbook->getCell(0, "C2")->setValue(5);

    $cell = $workbook->getCell(0, "D2");
    $cell->setR1C1Formula("RC[-2]-RC[-1]");

    $workbook->calculateFormulas();

    $value = java_values($cell->getValue()); // 7
} finally {
    $presentation->dispose();
}
```

รูปแบบการอ้างอิง R1C1 ที่พบบ่อยคือ:

| อ้างอิง | สัมพัทธ์ | แน่นอน | ผสม |
|---|---|---|---|
| เซลล์ | `R[2]C[3]` | `R2C3` | `R2C[3]`, `R[2]C3` |
| แถว | `R[2]` | `R2` | — |
| คอลัมน์ | `C[3]` | `C3` | — |
| ช่วง | `R[2]C[3]:R[5]C[7]` | `R2C3:R5C7` | `R2C3:R[5]C[7]`, `R[2]C3:R5C[7]` |

For example, in cell `D2`, `RC[-2]` means the cell in the same row two columns to the left (`B2`).

## **คอนสtant และผู้ดำเนินการของสูตร**

The built-in formula evaluator supports logical values, numeric literals, strings, spreadsheet error values, arithmetic operators, and comparison operators.

### **ค่าคงที่และลิเทรัล**

| ประเภท | ตัวอย่าง | หมายเหตุ |
|---|---|---|
| ตรรกะ | `TRUE`, `FALSE` | สามารถใช้โดยตรงในนิพจน์ตรรกะเช่น `A2=TRUE`. |
| ตัวเลข | `1`, `0.5`, `.3`, `1E-2` | รองรับการเขียนแบบทั่วไปและแบบวิทยาศาสตร์. |
| สตริง | `"abc"`, `"2/3/2020 12:00"` | ลิเทรัลข้อความจะอยู่ในเครื่องหมายอัญประกาศคู่ภายในสูตร. |
| ผลลัพธ์ข้อผิดพลาด | `#DIV/0!`, `#N/A`, `#REF!` | สูตรที่ถูกต้องอาจประเมินเป็นค่าข้อผิดพลาดของสเปรดชีตแทนผลลัพธ์ปกติ. |

ตัวอย่างนี้ใช้หลายประเภทค่าคงที่:

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 500, 300);
    $workbook = $chart->getChartData()->getChartDataWorkbook();

    $workbook->getCell(0, "A2")->setValue(false);
    $workbook->getCell(0, "B2")->setFormula("A2=TRUE");
    $workbook->getCell(0, "C2")->setFormula("1+0.5");
    $workbook->getCell(0, "D2")->setFormula(".3*1E-2");
    $workbook->getCell(0, "E2")->setFormula("\"abc\"");
    $workbook->getCell(0, "F2")->setFormula("2/0");

    $workbook->calculateFormulas();

    $logicalValue = java_values($workbook->getCell(0, "B2")->getValue()); // เท็จ
    $numericValue = java_values($workbook->getCell(0, "C2")->getValue()); // 1.5
    $scientificValue = java_values($workbook->getCell(0, "D2")->getValue()); // 0.003
    $stringValue = java_values($workbook->getCell(0, "E2")->getValue()); // abc
    $errorValue = java_values($workbook->getCell(0, "F2")->getValue()); // #DIV/0!
} finally {
    $presentation->dispose();
}
```

### **ผู้ดำเนินการคณิตศาสตร์**

| ผู้ดำเนินการ | ความหมาย | ตัวอย่าง |
|---|---|---|
| `+` | บวกหรือบวกเอกเทศ | `2+3` |
| `-` | ลบหรือเป็นลบ | `2-3`, `-3` |
| `*` | คูณ | `2*3` |
| `/` | หาร | `2/3` |
| `%` | เปอร์เซ็นต์ | `30%` |
| `^` | ยกกำลัง | `2^3` |

Use parentheses to make evaluation order explicit, for example `(A2+B2)*C2`.

### **ผู้ดำเนินการเปรียบเทียบ**

Comparison expressions return logical values.

| ผู้ดำเนินการ | ความหมาย | ตัวอย่าง |
|---|---|---|
| `=` | เท่ากับ | `A2=3` |
| `<>` | ไม่เท่ากับ | `A2<>3` |
| `>` | มากกว่า | `A2>3` |
| `>=` | มากกว่าหรือเท่ากับ | `A2>=3` |
| `<` | น้อยกว่า | `A2<3` |
| `<=` | น้อยกว่าหรือเท่ากับ | `A2<=3` |

## **ฟังก์ชันที่กำหนดไว้ล่วงหน้าที่รองรับ**

Aspose.Slides includes a built-in formula evaluator for chart worksheets, but it is not a complete Excel calculation engine. The documented function set is limited to the functions below. Do not assume that an arbitrary Excel function can be recalculated by [ChartDataWorkbook::calculateFormulas](https://reference.aspose.com/slides/th/php-java/aspose.slides/chartdataworkbook/#calculateFormulas).

| ฟังก์ชัน | วัตถุประสงค์หรือรูปแบบที่สนับสนุน | ตัวอย่าง |
|---|---|---|
| `ABS` | ค่าสัมบูรณ์ | `ABS(A2)` |
| `AVERAGE` | ค่าเฉลี่ยคณิตศาสตร์ | `AVERAGE(B2:B5)` |
| `CEILING` | ปัดขึ้นเป็นหลายเท่า | `CEILING(A2,5)` |
| `CHOOSE` | เลือกค่าโดยดัชนี | `CHOOSE(A2,"Low","High")` |
| `CONCAT` | รวมข้อความ | `CONCAT(A2,B2)` |
| `CONCATENATE` | รวมข้อความ | `CONCATENATE(A2," ",B2)` |
| `DATE` | สร้างค่าระบุวันที่โดยใช้ระบบวันที่ 1900 | `DATE(2026,8,19)` |
| `DAYS` | คืนจำนวนวันระหว่างวันที่ | `DAYS(B2,A2)` |
| `FIND` | ค้นหาข้อความหนึ่งภายในอีกข้อความ | `FIND("-",A2)` |
| `FINDB` | ค้นหาข้อความตามไบต์ | `FINDB("a",A2)` |
| `IF` | ผลลัพธ์ตามเงื่อนไข | `IF(A2>0,A2,0)` |
| `INDEX` | รูปแบบการอ้างอิง | `INDEX(A2:C4,2,3)` |
| `LOOKUP` | รูปแบบเวกเตอร์ | `LOOKUP(A2,B2:B5,C2:C5)` |
| `MATCH` | รูปแบบเวกเตอร์ | `MATCH(A2,B2:B5,0)` |
| `MAX` | ค่ามากที่สุด | `MAX(B2:B5)` |
| `SUM` | ผลรวมค่า | `SUM(B2:B5)` |
| `VLOOKUP` | ค้นหาแนวตั้ง | `VLOOKUP(A2,B2:D10,3,FALSE)` |

## **การคำนวณใหม่และค่าที่แคชไว้**

Spreadsheet files commonly store both a formula and its last calculated value. Aspose.Slides can therefore read a cached value from [ChartDataCell::getValue](https://reference.aspose.com/slides/th/php-java/aspose.slides/chartdatacell/#getValue) when a presentation is loaded and the relevant chart data has not been changed.

After changing input cells or formulas, do not rely on an old cached result. Call [ChartDataWorkbook::calculateFormulas](https://reference.aspose.com/slides/th/php-java/aspose.slides/chartdataworkbook/#calculateFormulas) before reading calculated values or saving chart data that depends on them.

For formulas outside the supported subset, Aspose.Slides may be unable to parse the formula or establish its dependencies. If the workbook has been modified, the previous cached value can no longer be considered reliable. In that situation, reading the value of a cell with unsupported data can raise [CellUnsupportedDataException](https://reference.aspose.com/slides/th/php-java/aspose.slides/cellunsupporteddataexception/).

If your chart depends on Excel functions that Aspose.Slides does not evaluate, calculate those formulas with a spreadsheet engine that supports them and write the resulting values back to the chart workbook. Do not replace unsupported formulas with guessed values.

## **จัดการข้อผิดพลาดของสูตร**

There are two different kinds of problems to distinguish.

A formula can be valid but produce a spreadsheet error result such as `#DIV/0!`, `#N/A`, `#NAME?`, `#NULL!`, `#NUM!`, `#REF!`, or `#VALUE!`. In this case, the error token is a cell result and can be returned through [ChartDataCell::getValue](https://reference.aspose.com/slides/th/php-java/aspose.slides/chartdatacell/#getValue).

A formula can also fail at the parsing, reference, dependency, or supported-data level. Aspose.Slides provides spreadsheet-specific exceptions for these cases: [CellInvalidFormulaException](https://reference.aspose.com/slides/th/php-java/aspose.slides/cellinvalidformulaexception/), [CellInvalidReferenceException](https://reference.aspose.com/slides/th/php-java/aspose.slides/cellinvalidreferenceexception/), [CellCircularReferenceException](https://reference.aspose.com/slides/th/php-java/aspose.slides/cellcircularreferenceexception/), and [CellUnsupportedDataException](https://reference.aspose.com/slides/th/php-java/aspose.slides/cellunsupporteddataexception/).

In PHP via Java, Java exceptions are surfaced through `JavaException`. When formulas come from templates or user input, handle it around recalculation and value access. The Java exception reported in the stack trace identifies the specific spreadsheet failure:

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 500, 300);
    $workbook = $chart->getChartData()->getChartDataWorkbook();
    $cell = $workbook->getCell(0, "A2");
    $cell->setFormula("SUM(B2:B5)");

    try {
        $workbook->calculateFormulas();
        echo java_values($cell->getValue()) . PHP_EOL;
    } catch (JavaException $ex) {
        $ex->printStackTrace();
    }
} finally {
    $presentation->dispose();
}
```

## **ข้อจำกัดเชิงปฏิบัติ**

The formula support in chart worksheets is intended for a defined subset of spreadsheet calculations, not for full Excel compatibility. Keep these constraints in mind when designing a reporting workflow:

- Use only the documented constants, operators, references, and functions when you need Aspose.Slides to recalculate formulas.
- Recalculate after changing cells that formula results depend on.
- Treat cached values from loaded presentations as snapshots, not as a replacement for recalculation after edits.
- Test formulas from existing templates before relying on their calculated values, especially when they use functions outside the documented list.
- For formulas that require a full spreadsheet calculation engine, calculate them externally and then update the chart workbook with the resulting values.

## **คำถามที่พบบ่อย**

**ความแตกต่างระหว่าง [ChartDataCell::setFormula](https://reference.aspose.com/slides/th/php-java/aspose.slides/chartdatacell/#setFormula) และ [ChartDataCell::setR1C1Formula](https://reference.aspose.com/slides/th/php-java/aspose.slides/chartdatacell/#setR1C1Formula) คืออะไร?**

[ChartDataCell::setFormula](https://reference.aspose.com/slides/th/php-java/aspose.slides/chartdatacell/#setFormula) เก็บนิพจน์สไตล์ A1 เช่น `B2-C2`. [ChartDataCell::setR1C1Formula](https://reference.aspose.com/slides/th/php-java/aspose.slides/chartdatacell/#setR1C1Formula) เก็บนิพจน์สไตล์ R1C1 เช่น `RC[-2]-RC[-1]`. ใช้รูปแบบที่ตรงกับวิธีที่คุณสร้างหรือคัดลอกสูตร.

**ฉันจำเป็นต้องอ่านเซลล์เองหรือค่าของมันหลังการคำนวณหรือไม่?**

[ChartDataWorkbook::getCell](https://reference.aspose.com/slides/th/php-java/aspose.slides/chartdataworkbook/#getCell) คืนค่าเป็น [ChartDataCell](https://reference.aspose.com/slides/th/php-java/aspose.slides/chartdatacell/). เพื่อรับผลลัพธ์ที่คำนวณแล้ว, เรียกเมธอด [ChartDataCell::getValue](https://reference.aspose.com/slides/th/php-java/aspose.slides/chartdatacell/#getValue) ของเซลล์นั้นหลังการคำนวณใหม่.

**เมื่อใดควรเรียก [ChartDataWorkbook::calculateFormulas](https://reference.aspose.com/slides/th/php-java/aspose.slides/chartdataworkbook/#calculateFormulas)?**

เรียก [ChartDataWorkbook::calculateFormulas](https://reference.aspose.com/slides/th/php-java/aspose.slides/chartdataworkbook/#calculateFormulas) หลังจากเปลี่ยนค่าป้อนหรือสูตรและก่อนที่คุณจะพึ่งพาผลลัพธ์ที่คำนวณ. วิธีนี้จะอัปเดตค่าของสูตรที่เครื่องมือประเมินในตัวรองรับ.

**Aspose.Slides รองรับทุกฟังก์ชันของ Excel หรือไม่?**

No. The built-in evaluator supports a documented subset of functions. Functions outside that subset should not be assumed to recalculate correctly. If full Excel formula compatibility is required, perform the calculation with an appropriate spreadsheet engine and write the final values to the chart workbook.

**ถ้างานนำเสนอที่โหลดมามีสูตรที่ไม่รองรับจะเกิดอะไรขึ้น?**

If the chart data has not changed, the workbook may still contain a previously calculated cached value. After related data is modified, that cached value may no longer be valid. Accessing a cell whose formula cannot be handled can raise [CellUnsupportedDataException](https://reference.aspose.com/slides/th/php-java/aspose.slides/cellunsupporteddataexception/).

**ค่าข้อผิดพลาดของสูตรเท่ากับข้อยกเว้นของ PHP หรือไม่?**

No. A result such as `#DIV/0!` is a spreadsheet value produced by a valid calculation. Spreadsheet-processing failures such as [CellInvalidFormulaException](https://reference.aspose.com/slides/th/php-java/aspose.slides/cellinvalidformulaexception/) or [CellCircularReferenceException](https://reference.aspose.com/slides/th/php-java/aspose.slides/cellcircularreferenceexception/) are Java exceptions surfaced to PHP through `JavaException`.

**แผนภูมิมีการอัปเดตอัตโนมัติเมื่อเซลล์สูตรเปลี่ยนหรือไม่?**

A chart series can reference workbook cells. Recalculate the workbook first, then save or render the presentation. If the chart data points reference the calculated cells, the chart uses those updated cell values; no separate chart-refresh method is required for this workflow.

**แผนภูมิสามารถใช้ไฟล์ Excel ภายนอกได้หรือไม่?**

Yes, chart data can be configured to use an external workbook through the chart data API. However, the formula calculation workflow described in this article concerns the chart data workbook and the formula subset evaluated by Aspose.Slides. Do not assume that [ChartDataWorkbook::calculateFormulas](https://reference.aspose.com/slides/th/php-java/aspose.slides/chartdataworkbook/#calculateFormulas) provides full recalculation of arbitrary formulas in an external XLSX file.

**ฉันสามารถใช้สูตรที่อ้างอิงเวิร์กชีตหรือเวิร์กบุ๊กอื่นได้หรือไม่?**

Excel-style references may exist in chart workbooks, but formula evaluation is limited by the supported parser and function set. If a cross-sheet or external reference is essential, validate that exact formula with your target Aspose.Slides version. For workflows that require broad Excel reference compatibility, calculate the workbook externally and write the resolved values back to the chart data.

**สูตรควรเริ่มด้วย `=` หรือไม่?**

The Aspose.Slides API examples assign expressions such as `B2-C2` or `SUM(B2:B5)` without a leading `=`. Using that form keeps generated formulas consistent with the documented API examples.