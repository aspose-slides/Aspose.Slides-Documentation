---
title: ใช้สูตรแผ่นงานแผนภูมิในพรีเซนเทชันด้วย PHP
linktitle: สูตรแผ่นงาน
type: docs
weight: 70
url: /th/php-java/chart-worksheet-formulas/
keywords:
- สเปรดชีตแผนภูมิ
- แผ่นงานแผนภูมิ
- สูตรแผนภูมิ
- สูตรแผ่นงาน
- สูตรสเปรดชีต
- เวิร์กบุ๊กข้อมูลแผนภูมิ
- การคำนวณสูตร
- วัฒนธรรมที่ต้องการ
- สูตรตามวัฒนธรรม
- DBCS
- คงที่ตรรกะ
- คงที่เชิงตัวเลข
- คงที่สตริง
- คงที่ข้อผิดพลาด
- ตัวดำเนินการคณิตศาสตร์
- ตัวดำเนินการเปรียบเทียบ
- สไตล์ A1
- สไตล์ R1C1
- ฟังก์ชันที่กำหนดล่วงหน้า
- PowerPoint
- พรีเซนเทชัน
- PHP
- Aspose.Slides
description: "ใช้สูตรสไตล์ Excel ใน Aspose.Slides สำหรับ PHP ผ่านแผ่นงานแผนภูมิ Java, คำนวณค่าซ้ำ, และใช้ผลลัพธ์ในแผนภูมิ PowerPoint."
---
## **ภาพรวม**

แผนภูมิใน PowerPoint ส่วนใหญ่จะเก็บข้อมูลต้นทางไว้ในแผ่นงานที่ฝังอยู่ ใน Aspose.Slides สำหรับ PHP ผ่าน Java คุณสามารถเข้าถึงแผ่นงานนั้นผ่าน ChartDataWorkbook, เขียนค่าข้อมูลเข้า, กำหนดสูตรให้กับเซลล์, คำนวณสูตรที่รองรับ, และใช้เซลล์ที่คำนวณแล้วเป็นข้อมูลของแผนภูมิได้

บทความนี้อธิบายกระบวนการทำงานของสูตรอย่างครบถ้วน: สร้างแผนภูมิ, เติมข้อมูลให้กับแผ่นงาน, กำหนดสูตรแบบ A1‑style หรือ R1C1‑style, คำนวณสูตรใหม่, อ่านค่าที่คำนวณได้, เชื่อมต่อเซลล์เหล่านั้นกับ series ของแผนภูมิ, และบันทึกพรีเซนเทชัน นอกจากนี้ยังอธิบายไวยากรณ์สูตรที่รองรับ, ชุดฟังก์ชันที่มีมาในตัว, ค่าที่แคชไว้, สูตรที่ไม่รองรับ, และข้อผิดพลาดเฉพาะของสเปรดชีต

## **แผ่นงานแผนภูมิและสูตร**

แผ่นงานของแผนภูมิประกอบด้วยหมวดหมู่, ชื่อ series, และค่า ที่ใช้โดยแผนภูมิ ใน PowerPoint คุณสามารถตรวจสอบแผ่นงานได้โดยเปิด chart data editor:

![แผนภูมิ PowerPoint พร้อมแผ่นงานฝังเปิดแสดงข้อมูลหมวดหมู่และ series](chart-worksheet-formulas_1.png)

ใน Aspose.Slides แผ่นงานจะถูกเปิดเผยผ่านคลาส [ChartDataWorkbook](https://reference.aspose.com/slides/th/php-java/aspose.slides/chartdataworkbook/) ใช้ [ChartDataCell::setFormula](https://reference.aspose.com/slides/th/php-java/aspose.slides/chartdatacell/#setFormula) สำหรับสูตรแบบ A1 และ [ChartDataCell::setR1C1Formula](https://reference.aspose.com/slides/th/php-java/aspose.slides/chartdatacell/#setR1C1Formula) สำหรับสูตรแบบ R1C1 หลังจากเปลี่ยนเซลล์อินพุตหรือสูตร ให้เรียก [ChartDataWorkbook::calculateFormulas](https://reference.aspose.com/slides/th/php-java/aspose.slides/chartdataworkbook/#calculateFormulas) เพื่อคำนวณสูตรที่รองรับใหม่และอัปเดตค่าของเซลล์ที่เกี่ยวข้อง

เซลล์ที่คำนวณแล้วยังคงเปิดเผยผลลัพธ์ผ่าน [ChartDataCell::getValue](https://reference.aspose.com/slides/th/php-java/aspose.slides/chartdatacell/#getValue) ซึ่งสำคัญเมื่อคุณต้องการตรวจสอบผลลัพธ์ของสูตรในโค้ดหรือใช้เซลล์เป็นจุดข้อมูลของแผนภูมิ

## **สร้างแผนภูมิและคำนวณสูตรในแผ่นงาน**

ตัวอย่างต่อไปนี้สาธิตกระบวนการทำงานตั้งแต่ต้นจนจบ มันสร้างแผนภูมิคอลัมน์แบบคลัสเตอร์, ล้างข้อมูลตัวอย่าง, เขียนค่ารายได้และค่าใช้จ่ายรายไตรมาส, คำนวณกำไรด้วยสูตร, อ่านผลลัพธ์, ใช้เซลล์ที่คำนวณแล้วเป็นค่าของแผนภูมิ, และบันทึกพรีเซนเทชัน

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

จุดข้อมูลของแผนภูมิอ้างอิง `D2:D4` ดังนั้นแผนภูมิจะใช้ค่ากำไรที่คำนวณแล้ว ไม่จำเป็นต้องเรียกเมธอดรีเฟรชแผนภูมิแยกต่างหากในขั้นตอนนี้: คำนวณสูตรในเวิร์กบุ๊กก่อน แล้วจึงใช้หรือบันทึกข้อมูลแผนภูมิที่อ้างอิงเซลล์ที่คำนวณแล้ว

## **ใช้สูตรแบบ A1‑Style**

การระบุแบบ A1 ใช้ตัวอักษรแทนคอลัมน์และตัวเลขแทนแถว กำหนดนิพจน์แบบ A1 ผ่าน [ChartDataCell::setFormula](https://reference.aspose.com/slides/th/php-java/aspose.slides/chartdatacell/#setFormula)

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

รูปแบบอ้างอิง A1 ที่พบบ่อยมีดังนี้:

| อ้างอิง | สัมพัทธ์ | แน่นอน | ผสม |
|---|---|---|---|
| Cell | `A2` | `$A$2` | `A$2`, `$A2` |
| Row | `2:2` | `$2:$2` | — |
| Column | `A:A` | `$A:$A` | — |
| Range | `A2:C4` | `$A$2:$C$4` | `A$2:$C4`, `$A2:C$4` |

อ้างอิงสัมพัทธ์จะเปลี่ยนแปลงเมื่อสูตรถูกย้ายหรือคัดลอกโดยแอปสเปรดชีต ส่วนอ้างอิงแน่นอนจะคงค่าพิกัดทั้งสองคงที่ ส่วนอ้างอิงผสมจะคงแค่แถวหรือคอลัมน์เท่านั้น

## **ใช้สูตรแบบ R1C1‑Style**

การระบุแบบ R1C1 ใช้ตัวเลขแทนทั้งแถวและคอลัมน์ อ้างอิงสัมพัทธ์ใช้การเยื้องเป็นออฟเซ็ตในวงเล็บเหลี่ยม กำหนดไวยากรณ์นี้ผ่าน [ChartDataCell::setR1C1Formula](https://reference.aspose.com/slides/th/php-java/aspose.slides/chartdatacell/#setR1C1Formula)

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

รูปแบบอ้างอิง R1C1 ที่พบบ่อยมีดังนี้:

| อ้างอิง | สัมพัทธ์ | แน่นอน | ผสม |
|---|---|---|---|
| Cell | `R[2]C[3]` | `R2C3` | `R2C[3]`, `R[2]C3` |
| Row | `R[2]` | `R2` | — |
| Column | `C[3]` | `C3` | — |
| Range | `R[2]C[3]:R[5]C[7]` | `R2C3:R5C7` | `R2C3:R[5]C[7]`, `R[2]C3:R5C[7]` |

ตัวอย่างเช่น ในเซลล์ `D2` คำว่า `RC[-2]` หมายถึงเซลล์ในแถวเดียวกันสองคอลัมน์ทางซ้าย (`B2`)

## **สูตรคงที่และตัวดำเนินการ**

เครื่องมือประเมินสูตรในตัวรองรับค่าตรรกะ, ลิเทรัลตัวเลข, สตริง, ค่าข้อผิดพลาดของสเปรดชีต, ตัวดำเนินการคณิตศาสตร์, และตัวดำเนินการเปรียบเทียบ

### **คงที่และลิเทรัล**

| ประเภท | ตัวอย่าง | หมายเหตุ |
|---|---|---|
| Logical | `TRUE`, `FALSE` | สามารถใช้โดยตรงในนิพจน์ตรรกะ เช่น `A2=TRUE` |
| Numeric | `1`, `0.5`, `.3`, `1E-2` | รองรับรูปแบบทั่วไปและวิทยาศาสตร์ |
| String | `"abc"`, `"2/3/2020 12:00"` | ลิเทรัลข้อความต้องอยู่ในเครื่องหมายอัญประกาศคู่ภายในสูตร |
| Error result | `#DIV/0!`, `#N/A`, `#REF!` | สูตรที่ถูกต้องอาจประเมินเป็นค่าข้อผิดพลาดของสเปรดชีตแทนผลลัพธ์ปกติ |

ตัวอย่างนี้ใช้คงที่หลายประเภท:

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

    $logicalValue = java_values($workbook->getCell(0, "B2")->getValue()); // false
    $numericValue = java_values($workbook->getCell(0, "C2")->getValue()); // 1.5
    $scientificValue = java_values($workbook->getCell(0, "D2")->getValue()); // 0.003
    $stringValue = java_values($workbook->getCell(0, "E2")->getValue()); // abc
    $errorValue = java_values($workbook->getCell(0, "F2")->getValue()); // #DIV/0!
} finally {
    $presentation->dispose();
}
```

### **ตัวดำเนินการคณิตศาสตร์**

| โอเปอเรเตอร์ | ความหมาย | ตัวอย่าง |
|---|---|---|
| `+` | การบวกหรือ unary plus | `2+3` |
| `-` | การลบหรือการทำลบ | `2-3`, `-3` |
| `*` | การคูณ | `2*3` |
| `/` | การหาร | `2/3` |
| `%` | เปอร์เซ็นต์ | `30%` |
| `^` | ยกกำลัง | `2^3` |

ใช้วงเล็บเพื่อระบุลำดับการประเมินอย่างชัดเจน ตัวอย่างเช่น `(A2+B2)*C2`

### **ตัวดำเนินการเปรียบเทียบ**

นิพจน์เปรียบเทียบจะคืนค่าตรรกะ

| โอเปอเรเตอร์ | ความหมาย | ตัวอย่าง |
|---|---|---|
| `=` | เท่ากับ | `A2=3` |
| `<>` | ไม่เท่ากับ | `A2<>3` |
| `>` | มากกว่า | `A2>3` |
| `>=` | มากกว่าหรือเท่ากับ | `A2>=3` |
| `<` | น้อยกว่า | `A2<3` |
| `<=` | น้อยกว่าหรือเท่ากับ | `A2<=3` |

## **ฟังก์ชันที่กำหนดไว้ล่วงหน้าที่รองรับ**

Aspose.Slides มีเครื่องมือประเมินสูตรในตัวสำหรับแผ่นงานแผนภูมิ แต่ไม่ใช่เอนจินคำนวณ Excel เต็มรูปแบบ ชุดฟังก์ชันที่อธิบายไว้จำกัดอยู่ที่ฟังก์ชันด้านล่าง อย่า Assume ว่าฟังก์ชัน Excel ใด ๆ สามารถคำนวณใหม่ได้ด้วย [ChartDataWorkbook::calculateFormulas](https://reference.aspose.com/slides/th/php-java/aspose.slides/chartdataworkbook/#calculateFormulas)

| ฟังก์ชัน | วัตถุประสงค์หรือรูปแบบที่รองรับ | ตัวอย่าง |
|---|---|---|
| `ABS` | ค่าตัวแน่นอน | `ABS(A2)` |
| `AVERAGE` | ค่าเฉลี่ยเลขคณิต | `AVERAGE(B2:B5)` |
| `CEILING` | ปัดจำนวนขึ้นไปเป็นจำนวนที่หารลงตัว | `CEILING(A2,5)` |
| `CHOOSE` | เลือกค่าตามดัชนี | `CHOOSE(A2,"Low","High")` |
| `CONCAT` | รวมค่าข้อความ | `CONCAT(A2,B2)` |
| `CONCATENATE` | รวมค่าข้อความ | `CONCATENATE(A2," ",B2)` |
| `DATE` | สร้างค่า วันที่โดยใช้ระบบวันที่ 1900 | `DATE(2026,8,19)` |
| `DAYS` | คืนจำนวนวันระหว่างวันที่ | `DAYS(B2,A2)` |
| `FIND` | ค้นหาข้อความหนึ่งในอีกข้อความหนึ่ง | `FIND("-",A2)` |
| `FINDB` | ค้นหาข้อความแบบไบต์ | `FINDB("a",A2)` |
| `IF` | ผลลัพธ์ตามเงื่อนไข | `IF(A2>0,A2,0)` |
| `INDEX` | รูปแบบอ้างอิง | `INDEX(A2:C4,2,3)` |
| `LOOKUP` | รูปแบบเวกเตอร์ | `LOOKUP(A2,B2:B5,C2:C5)` |
| `MATCH` | รูปแบบเวกเตอร์ | `MATCH(A2,B2:B5,0)` |
| `MAX` | ค่ามากสุด | `MAX(B2:B5)` |
| `SUM` | ผลรวมค่า | `SUM(B2:B5)` |
| `VLOOKUP` | การค้นหาแนวตั้ง | `VLOOKUP(A2,B2:D10,3,FALSE)` |

ข้อจำกัดในตารางมีความสำคัญ: `INDEX` ถูกอธิบายในรูปแบบอ้างอิง ในขณะที่ `LOOKUP` และ `MATCH` ถูกอธิบายในรูปแบบเวกเตอร์ `DATE` ใช้ระบบวันที่ 1900 ฟีเจอร์และฟังก์ชันที่ไม่ได้ระบุไว้ที่นี่ควรถูกถือว่าไม่รองรับโดยเครื่องประเมินสูตรของ Aspose.Slides เว้นแต่จะมีเอกสารแยกต่างหาก

## **คำนวณสูตรโดยกำหนดวัฒนธรรมที่ต้องการ**

ฟังก์ชันบางตัวในเวิร์กบุ๊กแผนภูมิจะแปลข้อความตามกฎของวัฒนธรรม ซึ่งสำคัญโดยเฉพาะสำหรับฟังก์ชันที่ออกแบบมาสำหรับภาษาที่ใช้ชุดอักขระสองไบต์ (DBCS) เพื่อคำนวณสูตรเหล่านั้นอย่างถูกต้อง ให้สร้าง [LoadOptions](https://reference.aspose.com/slides/th/php-java/aspose.slides/loadoptions/), ตั้งค่าวัฒนธรรมที่ต้องการด้วย [SpreadsheetOptions::setPreferredCulture](https://reference.aspose.com/slides/th/php-java/aspose.slides/spreadsheetoptions/#setPreferredCulture), กำหนดตัวเลือกสเปรดชีตผ่าน [LoadOptions::setSpreadsheetOptions](https://reference.aspose.com/slides/th/php-java/aspose.slides/loadoptions/#setSpreadsheetOptions) แล้วโหลดพรีเซนเทชัน

ตัวอย่างต่อไปนี้เลือกวัฒนธรรมญี่ปุ่น, เปิดพรีเซนเทชันด้วย LoadOptions ที่กำหนด, และเรียก [ChartDataWorkbook::calculateFormulas](https://reference.aspose.com/slides/th/php-java/aspose.slides/chartdataworkbook/#calculateFormulas) สำหรับทุกแผ่นงานแผนภูมิ:

```php
use aspose\slides\LoadOptions;
use aspose\slides\Presentation;
use aspose\slides\SpreadsheetOptions;

$japaneseCulture = new Java("java.util.Locale", "ja", "JP");

$spreadsheetOptions = new SpreadsheetOptions();
$spreadsheetOptions->setPreferredCulture($japaneseCulture);

$loadOptions = new LoadOptions();
$loadOptions->setSpreadsheetOptions($spreadsheetOptions);

$chartClass = new JavaClass("com.aspose.slides.IChart");
$presentation = new Presentation("presentation.pptx", $loadOptions);
try {
    $slideCount = java_values($presentation->getSlides()->size());
    for ($slideIndex = 0; $slideIndex < $slideCount; $slideIndex++) {
        $slide = $presentation->getSlides()->get_Item($slideIndex);
        $shapeCount = java_values($slide->getShapes()->size());
        for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
            $shape = $slide->getShapes()->get_Item($shapeIndex);
            if (java_instanceof($shape, $chartClass)) {
                $shape->getChartData()->getChartDataWorkbook()->calculateFormulas();
            }
        }
    }
} finally {
    $presentation->dispose();
}
```

วัฒนธรรมที่ต้องการเป็นส่วนหนึ่งของการกำหนดค่าการโหลดพรีเซนเทชัน ดังนั้นให้กำหนดก่อนสร้างอินสแตนซ์ [Presentation](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentation/) ใช้วัฒนธรรมที่สูตรเวิร์กบุ๊กคาดหวัง ตัวอย่างเช่นใช้ `ja-JP` สำหรับสูตรที่ต้องปฏิบัติตามกฎการคำนวณ DBCS ของญี่ปุ่น

## **การคำนวณซ้ำและค่าที่แคชไว้**

ไฟล์สเปรดชีตมักจะเก็บทั้งสูตรและค่าที่คำนวณล่าสุด Aspose.Slides จึงสามารถอ่านค่าที่แคชจาก [ChartDataCell::getValue](https://reference.aspose.com/slides/th/php-java/aspose.slides/chartdatacell/#getValue) เมื่อพรีเซนเทชันถูกโหลดและข้อมูลแผนภูมิที่เกี่ยวข้องไม่ได้ถูกเปลี่ยน

หลังจากเปลี่ยนเซลล์อินพุตหรือสูตร อย่าพึ่งพาผลลัพธ์ที่แคชเก่า ให้เรียก [ChartDataWorkbook::calculateFormulas](https://reference.aspose.com/slides/th/php-java/aspose.slides/chartdataworkbook/#calculateFormulas) ก่อนอ่านค่าที่คำนวณหรือบันทึกข้อมูลแผนภูมิที่อิงค่าเหล่านั้น

สำหรับสูตรที่อยู่นอกชุดที่รองรับ Aspose.Slides อาจไม่สามารถแยกสูตรหรือกำหนดการพึ่งพาได้ หากเวิร์กบุ๊กถูกแก้ไข ค่าที่แคชไว้ก่อนหน้านี้จะไม่ถือว่าเชื่อถือได้ ในสถานการณ์นั้น การอ่านค่าของเซลล์ที่มีข้อมูลไม่รองรับอาจทำให้เกิด [CellUnsupportedDataException](https://reference.aspose.com/slides/th/php-java/aspose.slides/cellunsupporteddataexception/)

หากแผนภูมิของคุณพึ่งพาฟังก์ชัน Excel ที่ Aspose.Slides ไม่ประเมิน คุณควรคำนวณสูตรเหล่านั้นด้วยเอนจินสเปรดชีตที่รองรับ แล้วเขียนค่าที่ได้กลับไปยังเวิร์กบุ๊กแผนภูมิ อย่าทดแทนสูตรที่ไม่รองรับด้วยค่าที่คาดเดา

## **จัดการข้อผิดพลาดของสูตร**

มีสองประเภทของปัญหาที่ต้องแยกแยะ

สูตรอาจถูกต้องแต่ให้ผลลัพธ์เป็นค่าข้อผิดพลาดของสเปรดชีต เช่น `#DIV/0!`, `#N/A`, `#NAME?`, `#NULL!`, `#NUM!`, `#REF!`, หรือ `#VALUE!` ในกรณีนี้ โทเคนข้อผิดพลาดเป็นผลลัพธ์ของเซลล์และสามารถคืนค่าผ่าน [ChartDataCell::getValue](https://reference.aspose.com/slides/th/php-java/aspose.slides/chartdatacell/#getValue)

สูตรอาจล้มเหลวที่ระดับการแยก, การอ้างอิง, การพึ่งพา, หรือข้อมูลที่รองรับ Aspose.Slides มีข้อยกเว้นเฉพาะสเปรดชีตสำหรับกรณีเหล่านี้: [CellInvalidFormulaException](https://reference.aspose.com/slides/th/php-java/aspose.slides/cellinvalidformulaexception/), [CellInvalidReferenceException](https://reference.aspose.com/slides/th/php-java/aspose.slides/cellinvalidreferenceexception/), [CellCircularReferenceException](https://reference.aspose.com/slides/th/php-java/aspose.slides/cellcircularreferenceexception/), และ [CellUnsupportedDataException](https://reference.aspose.com/slides/th/php-java/aspose.slides/cellunsupporteddataexception/)

ใน PHP ผ่าน Java ข้อยกเว้นของ Java จะถูกนำเสนอผ่าน `JavaException` เมื่อสูตรมาจากเทมเพลตหรือข้อมูลผู้ใช้ ให้จัดการข้อยกเว้นรอบการคำนวณซ้ำและการเข้าถึงค่า การยกเว้นของ Java ที่แสดงในสแตคเทรซจะบ่งบอกถึงความล้มเหลวของสเปรดชีตที่เฉพาะเจาะจง:

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

การสนับสนุนสูตรในแผ่นงานแผนภูมิมีจุดมุ่งหมายเพื่อชุดย่อยของการคำนวณสเปรดชีต ไม่ใช่ความเข้ากันได้เต็มรูปแบบกับ Excel โปรดคำนึงถึงข้อจำกัดเหล่านี้เมื่อออกแบบกระบวนการรายงาน:

- ใช้คงที่, ตัวดำเนินการ, อ้างอิง, และฟังก์ชันที่ระบุในเอกสารเท่านั้นเมื่อคุณต้องการให้ Aspose.Slides คำนวณสูตรใหม่
- คำนวณซ้ำหลังจากเปลี่ยนเซลล์ที่ผลลัพธ์สูตรพึ่งพา
- ถือค่าที่แคชจากพรีเซนเทชันที่โหลดเป็นภาพ snapshot ไม่ใช่การแทนที่การคำนวณใหม่หลังการแก้ไข
- ทดสอบสูตรจากเทมเพลตที่มีอยู่ก่อนพึ่งพาค่าที่คำนวณได้ โดยเฉพาะอย่างยิ่งเมื่อใช้ฟังก์ชันที่อยู่นอกรายการที่ระบุ
- สำหรับสูตรที่ต้องการเอนจินคำนวณสเปรดชีตเต็มรูปแบบ ให้คำนวณภายนอกแล้วอัปเดตเวิร์กบุ๊กแผนภูมิด้วยค่าที่ได้

## **FAQ**

**ความแตกต่างระหว่าง [ChartDataCell::setFormula](https://reference.aspose.com/slides/th/php-java/aspose.slides/chartdatacell/#setFormula) และ [ChartDataCell::setR1C1Formula](https://reference.aspose.com/slides/th/php-java/aspose.slides/chartdatacell/#setR1C1Formula) คืออะไร?**

[ChartDataCell::setFormula](https://reference.aspose.com/slides/th/php-java/aspose.slides/chartdatacell/#setFormula) เก็บนิพจน์แบบ A1‑style เช่น `B2-C2` ส่วน [ChartDataCell::setR1C1Formula](https://reference.aspose.com/slides/th/php-java/aspose.slides/chartdatacell/#setR1C1Formula) เก็บนิพจน์แบบ R1C1‑style เช่น `RC[-2]-RC[-1]` ใช้รูปแบบที่ตรงกับวิธีที่คุณสร้างหรือคัดลอกสูตรมากที่สุด

**ต้องอ่านเซลล์เองหรือค่าของมันหลังการคำนวณหรือไม่?**

[ChartDataWorkbook::getCell](https://reference.aspose.com/slides/th/php-java/aspose.slides/chartdataworkbook/#getCell) คืนค่า [ChartDataCell](https://reference.aspose.com/slides/th/php-java/aspose.slides/chartdatacell/) เพื่อให้ได้ผลลัพธ์ที่คำนวณแล้ว ให้เรียกเมธอด [ChartDataCell::getValue](https://reference.aspose.com/slides/th/php-java/aspose.slides/chartdatacell/#getValue) ของเซลล์นั้นหลังการคำนวณซ้ำ

**ควรเรียก [ChartDataWorkbook::calculateFormulas](https://reference.aspose.com/slides/th/php-java/aspose.slides/chartdataworkbook/#calculateFormulas) เมื่อไร?**

ให้เรียก [ChartDataWorkbook::calculateFormulas](https://reference.aspose.com/slides/th/php-java/aspose.slides/chartdataworkbook/#calculateFormulas) หลังจากเปลี่ยนค่าอินพุตหรือสูตรและก่อนที่คุณจะพึ่งพาผลลัพธ์ที่คำนวณแล้ว เมธอดนี้จะอัปเดตค่าของสูตรที่เครื่องมือประเมินในตัวรองรับ

**Aspose.Slides รองรับทุกฟังก์ชันของ Excel หรือไม่?**

ไม่ เครื่องมือประเมินในตัวรองรับเพียงชุดฟังก์ชันที่ระบุในเอกสาร ฟังก์ชันที่อยู่นอกชุดนั้นไม่ควรถือว่าจะคำนวณได้อย่างถูกต้อง หากต้องการความเข้ากันได้เต็มรูปแบบของสูตร Excel ให้ทำการคำนวณด้วยเอนจินสเปรดชีตที่เหมาะสมแล้วเขียนค่าผลลัพธ์กลับไปที่เวิร์กบุ๊กแผนภูมิ

**จะเกิดอะไรขึ้นหากพรีเซนเทชันที่โหลดมามีสูตรที่ไม่รองรับ?**

หากข้อมูลแผนภูมิไม่ได้เปลี่ยน แฝงค่าแคชที่คำนวณไว้ก่อนหน้านี้อาจยังคงอยู่ หลังจากข้อมูลที่เกี่ยวข้องถูกแก้ไข ค่าที่แคชไว้จะอาจไม่ถูกต้อง การเข้าถึงเซลล์ที่สูตรไม่สามารถจัดการได้อาจทำให้เกิด [CellUnsupportedDataException](https://reference.aspose.com/slides/th/php-java/aspose.slides/cellunsupporteddataexception/)

**ค่าข้อผิดพลาดของสูตรเป็นเหมือนข้อยกเว้นใน PHP หรือไม่?**

ไม่ ผลลัพธ์เช่น `#DIV/0!` เป็นค่าของสเปรดชีตที่เกิดจากการคำนวณที่ถูกต้อง ส่วนการล้มเหลวของการประมวลผลสเปรดชีต เช่น [CellInvalidFormulaException](https://reference.aspose.com/slides/th/php-java/aspose.slides/cellinvalidformulaexception/) หรือ [CellCircularReferenceException](https://reference.aspose.com/slides/th/php-java/aspose.slides/cellcircularreferenceexception/) เป็นข้อยกเว้นของ Java ที่ถูกนำเสนอให้ PHP ผ่าน `JavaException`

**แผนภูมิจะอัปเดตอัตโนมัติเมื่อเซลล์สูตรเปลี่ยนหรือไม่?**

Series ของแผนภูมิสามารถอ้างอิงเซลล์ในเวิร์กบุ๊กได้ ให้คำนวณสูตรในเวิร์กบุ๊กก่อน แล้วจึงบันทึกหรือแสดงพรีเซนเทชัน หากจุดข้อมูลของแผนภูมิอ้างอิงเซลล์ที่คำนวณแล้ว แผนภูมิจะใช้ค่าที่อัปเดตเหล่านั้น ไม่จำเป็นต้องเรียกเมธอดรีเฟรชแผนภูมิแยกต่างหากสำหรับขั้นตอนนี้

**แผนภูมิสามารถใช้เวิร์กบุ๊ก Excel ภายนอกได้หรือไม่?**

ได้ ข้อมูลแผนภูมิสามารถกำหนดให้ใช้เวิร์กบุ๊กภายนอกผ่าน API ของข้อมูลแผนภูมิ อย่างไรก็ตาม กระบวนการคำนวณสูตรที่อธิบายในบทความนี้เกี่ยวกับเวิร์กบุ๊กข้อมูลแผนภูมิและชุดสูตรที่ Aspose.Slides ประเมิน อย่า Assume ว่า [ChartDataWorkbook::calculateFormulas](https://reference.aspose.com/slides/th/php-java/aspose.slides/chartdataworkbook/#calculateFormulas) ให้การคำนวณเต็มรูปแบบของสูตรใด ๆ ในนไฟล์ XLSX ภายนอก

**สูตรสามารถอ้างอิงแผ่นงานหรือเวิร์กบุ๊กอื่นได้หรือไม่?**

อ้างอิงแบบ Excel อาจมีอยู่ในเวิร์กบุ๊กแผนภูมิ แต่การประเมินสูตรถูกจำกัดโดยตัวแยกสูตรและชุดฟังก์ชันที่รองรับ หากต้องการอ้างอิงข้ามชีตหรือภายนอกที่สำคัญ ให้ตรวจสอบสูตรนั้นกับรุ่น Aspose.Slides ที่คุณใช้ สำหรับกระบวนการที่ต้องการความเข้ากันได้กว้างของการอ้างอิง Excel ให้คำนวณเวิร์กบุ๊กภายนอกแล้วเขียนค่าที่แก้ไขแล้วกลับไปยังข้อมูลแผนภูมิ

**สูตรควรเริ่มด้วย `=` หรือไม่?**

ตัวอย่าง API ของ Aspose.Slides จะกำหนดนิพจน์ เช่น `B2-C2` หรือ `SUM(B2:B5)` โดยไม่มีเครื่องหมาย `=` นำหน้า การใช้รูปแบบนี้ทำให้สูตรที่สร้างสอดคล้องกับตัวอย่าง API ที่ระบุในเอกสาร**