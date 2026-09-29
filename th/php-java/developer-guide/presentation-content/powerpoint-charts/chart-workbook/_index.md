---
title: จัดการเวิร์กบุ๊กแผนภูมิในการนำเสนอด้วย PHP
linktitle: เวิร์กบุ๊กแผนภูมิ
type: docs
weight: 70
url: /th/php-java/chart-workbook/
keywords:
- เวิร์กบุ๊กแผนภูมิ
- ข้อมูลแผนภูมิ
- เซลล์เวิร์กบุ๊ก
- ป้ายข้อมูล
- แผ่นงาน
- แหล่งข้อมูล
- เวิร์กบุ๊กภายนอก
- ข้อมูลภายนอก
- แคชแผนภูมิ
- การกู้คืนเวิร์กบุ๊ก
- PowerPoint
- การนำเสนอ
- PHP
- Aspose.Slides
description: "ค้นพบ Aspose.Slides สำหรับ PHP ผ่าน Java: จัดการเวิร์กบุ๊กแผนภูมิในรูปแบบ PowerPoint และ OpenDocument อย่างง่ายดายเพื่อปรับปรุงข้อมูลการนำเสนอของคุณ"
---
## **ภาพรวม**

บทความนี้อธิบายวิธีทำงานกับเวิร์กบุ๊กแผนภูมิใน Aspose.Slides แสดงวิธีอ่านและเขียนข้อมูลแผนภูมิผ่านสตรีมเวิร์กบุ๊ก, ใช้เซลล์เวิร์กบุ๊กเป็นป้ายข้อมูลแผนภูมิ, เข้าถึงคอลเลกชันแผ่นงาน, และกำหนดประเภทแหล่งข้อมูลสำหรับค่าของแผนภูมิ

นอกจากนี้ยังครอบคลุมการทำงานกับเวิร์กบุ๊กภายนอกรูปแบบแหล่งข้อมูลของแผนภูมิ ตัวอย่างแสดงวิธีสร้างและกำหนดเวิร์กบุ๊กภายนอก, ดึงเส้นทางของเวิร์กบุ๊กภายนอกที่ลิงก์กับแผนภูมิ, และแก้ไขข้อมูลแผนภูมิเมื่อเวิร์กบุ๊กพร้อมใช้งาน

สำหรับเซลล์เวิร์กบุ๊กที่แสดงข้อมูลที่หายไป ดูที่ [Control the Display of Empty Cells](/slides/th/php-java/chart-series/) เพื่อเรียนรู้ความแตกต่างระหว่างเซลล์ว่างและค่า 0, รวมถึงการเปรียบเทียบแผนภูมิเส้นของโหมดการแสดงผลที่มีอยู่

## **รวมข้อมูลจากแถวและคอลัมน์ที่ซ่อนอยู่**

ใช้ [Chart::setPlotVisibleCellsOnly](https://reference.aspose.com/slides/th/php-java/aspose.slides/chart/setplotvisiblecellsonly/) เพื่อควบคุมว่าผังจะแสดงข้อมูลจากแถวและคอลัมน์ในแผ่นงานที่ซ่อนหรือไม่ ตั้งค่าเป็น `true` เพื่อวางแผนที่เฉพาะเซลล์ที่มองเห็นได้, หรือ `false` เพื่อรวมทั้งเซลล์ที่มองเห็นและที่ซ่อน การตั้งค่านี้ควบคุมการพล็อตแผนภูมิ; ไม่ได้ทำให้แถวหรือคอลัมน์ในแผ่นงานซ่อนหรือแสดง

ดาวน์โหลด [hidden-source-data.pptx](hidden-source-data.pptx) แล้ววางไว้ในไดเรกทอรีทำงาน สไลด์แรกมีแผนภูมิกลุ่มเป็นรูปทรงแรก แผ่นงานฝังตัว `Sheet1` มีช่วงต้นแบบ `A1:C4` แถวที่ 3 และคอลัมน์ C ถูกซ่อน, แต่เซลล์ของพวกมันยังคงมีค่า

| แถวแผ่นงาน | A: เดือน | B: รีเทล | C: โฮลเซลล์ (คอลัมน์ซ่อน) |
| --- | --- | --- | --- |
| 2 | มกราคม | 10 | 30 |
| 3 (แถวซ่อน) | กุมภาพันธ์ | 40 | 60 |
| 4 | มีนาคม | 20 | 50 |

เข้าถึงเซลล์ต้นแบบผ่าน [ChartData::getChartDataWorkbook](https://reference.aspose.com/slides/th/php-java/aspose.slides/chartdata/getchartdataworkbook/) และอ่าน [ChartDataCell::isHidden](https://reference.aspose.com/slides/th/php-java/aspose.slides/chartdatacell/ishidden/) เพื่อตรวจสอบสถานะการซ่อน วิธีนี้รายงานสถานะการซ่อนโดยไม่เปลี่ยนแปลง ในไฟล์นี้ B2 มองเห็นได้, B3 อยู่ในแถวที่ซ่อน, และ C2 อยู่ในคอลัมน์ที่ซ่อน; ตัวอย่างพิมพ์ `false`, `true`, และ `true` ตามลำดับ

สำหรับตัวอย่างนี้, รีเฟรชข้อมูลแผนภูมิหลังเปลี่ยนการตั้งค่าการพล็อต: เก็บเวิร์กบุ๊กฝังด้วย [readWorkbookStream](https://reference.aspose.com/slides/th/php-java/aspose.slides/chartdata/readworkbookstream/) และโหลดใหม่ด้วย [writeWorkbookStream](https://reference.aspose.com/slides/th/php-java/aspose.slides/chartdata/writeworkbookstream/) เมื่อรวมทุกเซลล์, ใช้ [setRange](https://reference.aspose.com/slides/th/php-java/aspose.slides/chartdata/setrange/) เพื่อคืนช่วงเต็มรวมถึงหมวดเดือนกุมภาพันธ์ที่ซ่อนอยู่ การเปลี่ยนแฟล็กอย่างเดียวไม่เพียงพอที่จะรีเฟรชข้อมูลแคชของแผนภูมิและป้ายหมวดในตัวอย่างนี้

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("hidden-source-data.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shapeCount = java_values($slide->getShapes()->size());
    if ($shapeCount > 0 && java_instanceof($slide->getShapes()->get_Item(0), new JavaClass("com.aspose.slides.IChart"))) {
        $chart = $slide->getShapes()->get_Item(0);
        $workbook = $chart->getChartData()->getChartDataWorkbook();
        echo "B2 hidden: " . (java_values($workbook->getCell(0, "B2")->isHidden()) ? "true" : "false"), PHP_EOL;
        echo "B3 hidden: " . (java_values($workbook->getCell(0, "B3")->isHidden()) ? "true" : "false"), PHP_EOL;
        echo "C2 hidden: " . (java_values($workbook->getCell(0, "C2")->isHidden()) ? "true" : "false"), PHP_EOL;

        $workbookData = $chart->getChartData()->readWorkbookStream();
        foreach ([true, false] as $visibleOnly) {
            $chart->setPlotVisibleCellsOnly($visibleOnly);

            // รีเฟรชข้อมูลแผนภูมิจากเวิร์กบุ๊กที่ฝังอยู่.
            $chart->getChartData()->writeWorkbookStream($workbookData);
            if (!$visibleOnly) {
                // คืนช่วงต้นฉบับเต็มรวมถึงหมวดที่ซ่อนอยู่.
                $chart->getChartData()->setRange('Sheet1!$A$1:$C$4');
            }

            $presentation->save("hidden_cells_" . ($visibleOnly ? "true" : "false") . ".pptx", SaveFormat::Pptx);
        }
    } else {
        echo "The first shape is not a chart.", PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

ตัวอย่างบันทึก `hidden_cells_true.pptx` ที่มีเพียงค่าริเทลที่มองเห็น (`true`) (10 และ 20) และ `hidden_cells_false.pptx` ที่มีค่าทั้งหกค่า ภาพด้านล่างแสดงสองโหมดการพล็อต แถวที่ 3 และคอลัมน์ C ยังคงซ่อนในทั้งสองเวิร์กบุ๊กฝัง

| เฉพาะเซลล์ที่มองเห็น (`true`) | ทุกเซลล์ (`false`) |
| --- | --- |
| ![Only visible cells: Retail values 10 and 20 for January and March.](hidden_cells_True.png) | ![All cells: Retail and Wholesale values for January, February, and March.](hidden_cells_False.png) |

เซลล์ที่ซ่อนและมีค่าแตกต่างจากเซลล์ว่าง [Chart::setDisplayBlanksAs](https://reference.aspose.com/slides/th/php-java/aspose.slides/chart/setdisplayblanksas/) ควบคุมวิธีการแสดงค่าที่หายไป; ไม่ได้รวมหรือยกเว้นข้อมูลต้นแบบที่ซ่อน ดูที่ [Control the Display of Empty Cells](/slides/th/php-java/chart-series/#control-the-display-of-empty-cells) เพื่อดูตัวอย่าง

## **อ่านและเขียนข้อมูลแผนภูมิจากเวิร์กบุ๊ก**

Aspose.Slides for PHP via Java มีเมธอด [readWorkbookStream](https://reference.aspose.com/slides/th/php-java/aspose.slides/chartdata/readworkbookstream/) และ [writeWorkbookStream](https://reference.aspose.com/slides/th/php-java/aspose.slides/chartdata/writeworkbookstream/) ที่ให้คุณอ่านและเขียนเวิร์กบุ๊กข้อมูลแผนภูมิ (ซึ่งอาจแก้ไขด้วย Aspose.Cells) **หมายเหตุ** ข้อมูลแผนภูมิต้องจัดเรียงในลักษณะเดียวกันหรือมีโครงสร้างคล้ายกับแหล่งข้อมูล

ตัวอย่างนี้เปิด `chart.pptx` ซึ่งต้องมีแผนภูมิเป็นรูปทรงแรกบนสไลด์แรก อ่านเวิร์กบุ๊กฝังเป็นอาร์เรย์ไบต์, ลบซีรีส์และหมวดเดิม, แล้วเขียนเวิร์กบุ๊กเดิมกลับ การเปลี่ยนแปลงยังคงอยู่ในหน่วยความจำ; ตัวอย่างไม่ได้บันทึกงานนำเสนอ

```php
use aspose\slides\Presentation;

$presentation = new Presentation("chart.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shapeCount = java_values($slide->getShapes()->size());
    if ($shapeCount > 0 && java_instanceof($slide->getShapes()->get_Item(0), new JavaClass("com.aspose.slides.IChart"))) {
        $chart = $slide->getShapes()->get_Item(0);
        $chartData = $chart->getChartData();
        $workbookData = $chartData->readWorkbookStream();

        $chartData->getSeries()->clear();
        $chartData->getCategories()->clear();

        $chartData->writeWorkbookStream($workbookData);
    } else {
        echo "The first shape is not a chart.", PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

### **ตรวจสอบเค้าโครงแผนภูมิหลังแก้ไขเวิร์กบุ๊ก**

เมื่อคุณแทนที่เวิร์กบุ๊กฝังด้วยเวิร์กบุ๊กที่แก้ไข, แผนภูมิมักจะยังคงคอลเลกชันซีรีส์และหมวดเดิม ความไม่ตรงกันนี้อาจทำให้ [Chart::validateChartLayout](https://reference.aspose.com/slides/th/php-java/aspose.slides/chart/validatechartlayout/) ล้มเหลวด้วยข้อผิดพลาด index-out-of-range ลบซีรีส์และหมวดเดิมก่อนเขียนเวิร์กบุ๊กอัปเดตกลับไปยังแผนภูมิ ตัวอย่างนี้ต้องการ `chart.pptx` ที่มีแผนภูมิเป็นรูปทรงแรกบนสไลด์แรก คอมเมนต์ระบุที่จะแก้ไขเวิร์กบุ๊ก; ตัวอย่างทำงานเขียนเวิร์กบุ๊กเดิมกลับและตรวจสอบเค้าโครงในหน่วยความจำ

```php
use aspose\slides\Presentation;

$presentation = new Presentation("chart.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shapeCount = java_values($slide->getShapes()->size());
    if ($shapeCount > 0 && java_instanceof($slide->getShapes()->get_Item(0), new JavaClass("com.aspose.slides.IChart"))) {
        $chart = $slide->getShapes()->get_Item(0);
        $chartData = $chart->getChartData();
        $workbookData = $chartData->readWorkbookStream();

        // แก้ไขไบต์ของเวิร์กบุ๊กที่นี่, ตัวอย่างเช่น, ใช้ Aspose.Cells.

        $chartData->getSeries()->clear();
        $chartData->getCategories()->clear();

        $chartData->writeWorkbookStream($workbookData);
        $chart->validateChartLayout();
    } else {
        echo "The first shape is not a chart.", PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

การลบคอลเลกชันจะกำจัดการอ้างอิงข้อมูลเก่าก่อนที่เวิร์กบุ๊กจะถูกบันทึกกลับ สร้างแมปซีรีส์และหมวดที่จำเป็นสำหรับเวิร์กบุ๊กอัปเดตก่อนใช้แผนภูมิ

## **กำหนดเซลล์เวิร์กบุ๊กเป็นป้ายข้อมูลแผนภูมิ**

คุณสามารถใช้ข้อความจากเซลล์เวิร์กบุ๊กเป็นป้ายข้อมูลแผนภูมิ ขั้นตอนต่อไปนี้แสดงวิธีเชื่อมป้ายในแผนภูมิบับเบิลกับเซลล์ในเวิร์กบุ๊กข้อมูล

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentation/)
2. เข้าถึงสไลด์แรกโดยใช้ดัชนีเริ่มจากศูนย์
3. เพิ่มแผนภูมิบับเบิลด้วยข้อมูลเริ่มต้น
4. เข้าถึงซีรีส์ของแผนภูมิ
5. ตั้งค่าเซลล์เวิร์กบุ๊กเป็นป้ายข้อมูล
6. บันทึกงานนำเสนอ

ตัวอย่างนี้เปิด `chart2.pptx` ซึ่งต้องมีอย่างน้อยหนึ่งสไลด์, แล้วเพิ่มแผนภูมิบับเบิลด้วยข้อมูลเริ่มต้น ใช้เซลล์ A10:A12 บนแผ่นงาน 0 เป็นป้ายสามรายการแรกในซีรีส์แรก, เปิดใช้งานป้ายจากเซลล์, และบันทึกผลลัพธ์เป็น `resultchart.pptx`

```php
use aspose\slides\Presentation;
use aspose\slides\ChartType;
use aspose\slides\SaveFormat;

$presentation = new Presentation("chart2.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::Bubble, 50, 50, 600, 400, true);
    $series = $chart->getChartData()->getSeries()->get_Item(0);
    $workbook = $chart->getChartData()->getChartDataWorkbook();

    $series->getLabels()->getDefaultDataLabelFormat()->setShowLabelValueFromCell(true);
    $series->getLabels()->get_Item(0)->setValueFromCell($workbook->getCell(0, "A10", "Label 0 cell value"));
    $series->getLabels()->get_Item(1)->setValueFromCell($workbook->getCell(0, "A11", "Label 1 cell value"));
    $series->getLabels()->get_Item(2)->setValueFromCell($workbook->getCell(0, "A12", "Label 2 cell value"));

    $presentation->save("resultchart.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **จัดการแผ่นงาน**

เมธอด [ChartDataWorkbook::getWorksheets](https://reference.aspose.com/slides/th/php-java/aspose.slides/chartdataworkbook/getworksheets/) ให้เข้าถึงแผ่นงานในเวิร์กบุ๊กแผนภูมิ ตัวอย่างนี้สร้างแผนภูมิโพรงด้วยข้อมูลเริ่มต้นและพิมพ์ชื่อแผ่นงานแต่ละชื่อลงคอนโซล

```php
use aspose\slides\Presentation;
use aspose\slides\ChartType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::Pie, 50, 50, 400, 500);
    $workbook = $chart->getChartData()->getChartDataWorkbook();

    for ($i = 0; $i < java_values($workbook->getWorksheets()->size()); $i++) {
        echo $workbook->getWorksheets()->get_Item($i)->getName(), PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

## **กำหนดประเภทแหล่งข้อมูล**

ตัวอย่างนี้สร้างแผนภูมิคอลัมน์ 3 มิติด้วยข้อมูลเริ่มต้นและตั้งชื่อซีรีส์สองชื่อโดยใช้แหล่งข้อมูลที่ต่างกัน ชื่อแรกใช้สตริงลิตเตรัล; ชื่อที่สองใช้เซลล์ C1 บนแผ่นงาน 0 [DataSourceType](https://reference.aspose.com/slides/th/php-java/aspose.slides/datasourcetype/) กำหนดแหล่งสำหรับแต่ละชื่อ ผลลัพธ์บันทึกเป็น `pres.pptx`

```php
use aspose\slides\Presentation;
use aspose\slides\ChartType;
use aspose\slides\SaveFormat;
use aspose\slides\DataSourceType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::Column3D, 50, 50, 600, 400, true);
    $literalName = $chart->getChartData()->getSeries()->get_Item(0)->getName();

    $literalName->setDataSourceType(DataSourceType::StringLiterals);
    $literalName->setData("LiteralString");

    $cellName = $chart->getChartData()->getSeries()->get_Item(1)->getName();
    $nameCell = $chart->getChartData()->getChartDataWorkbook()->getCell(0, "C1", "NewCell");
    $cellName->setDataSourceType(DataSourceType::Worksheet);
    $cellName->setData($nameCell);

    $presentation->save("pres.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **ตรวจจับรูปแบบเวิร์กบุ๊กฝังที่ไม่รองรับ**

Aspose.Slides ไม่รองรับรูปแบบเวิร์กบุ๊ก Excel แบบไบนารี (.xlsb) ที่อาจฝังในบางแผนภูมิ คุณสามารถใช้เมธอด `getEmbeddedWorkbookType` บน [ChartData](https://reference.aspose.com/slides/th/php-java/aspose.slides/chartdata/) ร่วมกับ enumeration [WorkbookType](https://reference.aspose.com/slides/th/php-java/aspose.slides/workbooktype/) เพื่อค้นหารูปแบบที่ไม่รองรับและข้ามแผนภูมิเหล่านั้น ตัวอย่างนี้ตรวจสอบรูปทรงบนสไลด์แรกของ `sample.pptx`, ข้ามรูปทรงที่ไม่ใช่แผนภูมิ, แล้วพิมพ์ข้อความวินิจฉัยสำหรับแต่ละแผนภูมิที่มีเวิร์กบุ๊ก .xlsb ฝัง

```php
use aspose\slides\Presentation;
use aspose\slides\ChartDataSourceType;
use aspose\slides\WorkbookType;

$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shapeCount = java_values($slide->getShapes()->size());
    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $shape = $slide->getShapes()->get_Item($shapeIndex);
        if (!java_instanceof($shape, new JavaClass("com.aspose.slides.IChart"))) {
            continue;
        }

        $chart = $shape;
        $chartData = $chart->getChartData();
        $isInternalWorkbook = java_values($chartData->getDataSourceType()) == ChartDataSourceType::InternalWorkbook;
        $isBinaryMacro = java_values($chartData->getEmbeddedWorkbookType()) == WorkbookType::WorkbookBinaryMacro;

        if ($isInternalWorkbook && $isBinaryMacro) {
            echo "Skipping a chart with an unsupported .xlsb workbook.", PHP_EOL;
            continue;
        }

        // อ่านหรือแก้ไขข้อมูลเวิร์กบุ๊กแผนภูมิที่รองรับที่นี่.
    }
} finally {
    $presentation->dispose();
}
```

## **เวิร์กบุ๊กภายนอก**

Aspose.Slides รองรับการใช้เวิร์กบุ๊กภายนอกรูปแบบแหล่งข้อมูลสำหรับแผนภูมิ

### **สร้างเวิร์กบุ๊กภายนอก**

ใช้ [readWorkbookStream](https://reference.aspose.com/slides/th/php-java/aspose.slides/chartdata/readworkbookstream/) และ [setExternalWorkbook](https://reference.aspose.com/slides/th/php-java/aspose.slides/chartdata/setexternalworkbook/) เพื่อส่งออกเวิร์กบุ๊กแผนภูมิกฝังเป็นไฟล์และลิงก์แผนภูมิกับเวิร์กบุ๊กภายนอกนั้น

ตัวอย่างนี้สร้างแผนภูมิโพรงด้วยข้อมูลเริ่มต้น, เขียนเวิร์กบุ๊กเป็น `externalWorkbook1.xlsx`, แล้วรอจนการเขียนไฟล์เสร็จก่อนกำหนดไฟล์เป็นแหล่งข้อมูลของแผนภูมิ บันทึกงานนำเสนอที่ลิงก์ไว้เป็น `externalWorkbook.pptx`

```php
use aspose\slides\Presentation;
use aspose\slides\ChartType;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::Pie, 50, 50, 400, 600);
    $workbookPath = new Java("java.io.File", "externalWorkbook1.xlsx");
    $workbookData = $chart->getChartData()->readWorkbookStream();
    try {
        $fileStream = new Java("java.io.FileOutputStream", $workbookPath);
        try {
            $fileStream->write($workbookData);
        } finally {
            $fileStream->close();
        }
        $chart->getChartData()->setExternalWorkbook($workbookPath->getAbsolutePath());
        $presentation->save("externalWorkbook.pptx", SaveFormat::Pptx);
    } catch (JavaException $exception) {
        echo "Could not write the external workbook: " . $exception->getMessage(), PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

### **กำหนดเวิร์กบุ๊กภายนอก**

โดยใช้เมธอด [setExternalWorkbook](https://reference.aspose.com/slides/th/php-java/aspose.slides/chartdata/setexternalworkbook/) คุณสามารถกำหนดเวิร์กบุ๊กภายนอกให้กับแผนภูมิเป็นแหล่งข้อมูลได้ เมธอดนี้ยังใช้เพื่ออัปเดตเส้นทางของเวิร์กบุ๊กภายนอก (หากไฟล์ถูกย้าย)

แม้ว่าจะไม่สามารถแก้ไขข้อมูลในเวิร์กบุ๊กที่เก็บในตำแหน่งระยะไกลหรือทรัพยากรได้, คุณยังสามารถใช้เวิร์กบุ๊กเหล่านั้นเป็นแหล่งข้อมูลภายนอกได้ หากระบุเส้นทางสัมพัทธ์สำหรับเวิร์กบุ๊กภายนอก, ระบบจะแปลงเป็นเส้นทางเต็มโดยอัตโนมัติ

ตัวอย่างนี้ต้องมี `externalWorkbook.xlsx` ในไดเรกทอรีทำงาน แผ่นงาน `Sheet1` ต้องมีชื่อซีรีส์ใน B1, ชื่อหมวดใน A2:A4, และค่าตัวเลขใน B2:B4 ตัวอย่างสร้างแผนภูมิโพรง, ลิงก์เวิร์กบุ๊ก, และใช้ [setRange](https://reference.aspose.com/slides/th/php-java/aspose.slides/chartdata/setrange/) เพื่อแมป A1:B4 เป็นหนึ่งซีรีส์และสามหมวด บันทึกผลเป็น `Presentation_with_externalWorkbook.pptx`

```php
use aspose\slides\Presentation;
use aspose\slides\ChartType;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::Pie, 50, 50, 400, 600, true);
    $chartData = $chart->getChartData();
    $workbookFile = new Java("java.io.File", "externalWorkbook.xlsx");
    $workbookPath = $workbookFile->getAbsolutePath();

    $chartData->setExternalWorkbook($workbookPath);
    $chartData->setRange('Sheet1!$A$1:$B$4');

    $presentation->save("Presentation_with_externalWorkbook.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

พารามิเตอร์ `updateChartData` ของ [setExternalWorkbook](https://reference.aspose.com/slides/th/php-java/aspose.slides/chartdata/setexternalworkbook/) ควบคุมว่าจะโหลดเวิร์กบุ๊กหรือไม่

* เมื่อ `updateChartData` เป็น `false`, จะอัปเดตเฉพาะเส้นทางเวิร์กบุ๊ก เท่านั้น แผนภูมิจะไม่โหลดหรืออัปเดตข้อมูลจากเวิร์กบุ๊กเป้าหมาย, ดังนั้นเวิร์กบุ๊กสามารถไม่มีอยู่ได้
* เมื่อ `updateChartData` เป็น `true`, แผนภูมิจะอัปเดตข้อมูลจากเวิร์กบุ๊กเป้าหมาย

ตัวอย่างต่อไปกำหนด URL ตัวอย่างโดยตั้ง `updateChartData` เป็น `false` แผนภูมิโพรงจะคงข้อมูลเริ่มต้นและบันทึกงานนำเสนอโดยไม่โหลดเวิร์กบุ๊กที่ไม่มีอยู่

```php
use aspose\slides\Presentation;
use aspose\slides\ChartType;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::Pie, 50, 50, 400, 600, true);
    $chart->getChartData()->setExternalWorkbook("https://example.com/unavailable-workbook.xlsx", false);

    $presentation->save("SetExternalWorkbookWithUpdateChartData.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **รับเส้นทางเวิร์กบุ๊กแหล่งข้อมูลภายนอกของแผนภูมิ**

เพื่อระบุเวิร์กบุ๊กที่ลิงก์กับแผนภูมิ, ให้ตรวจสอบก่อนว่าแผนภูมิมีแหล่งข้อมูลภายนอกหรือไม่ หากมี, สามารถดึงเส้นทางเวิร์กบุ๊กได้ตามขั้นตอนต่อไปนี้

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentation/)
2. เข้าถึงสไลด์แรกโดยใช้ดัชนีเริ่มจากศูนย์
3. ตรวจสอบว่ารูปทรงแรกเป็นแผนภูมิหรือไม่
4. อ่านประเภทแหล่งข้อมูลของแผนภูมิ
5. หากเป็นเวิร์กบุ๊กภายนอก, อ่านเส้นทางของมัน

ตัวอย่างนี้เปิด `externalWorkbook.pptx` ที่สร้างในตัวอย่างก่อนหน้า, ตรวจสอบรูปทรงแรกบนสไลด์แรก หากเป็นแผนภูมิลิงก์กับเวิร์กบุ๊กภายนอก, ตัวอย่างพิมพ์ [getExternalWorkbookPath](https://reference.aspose.com/slides/th/php-java/aspose.slides/chartdata/getexternalworkbookpath/) ไปที่คอนโซล แล้วบันทึกสำเนาของงานนำเสนอเป็น `Result.pptx`

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ChartDataSourceType;

$presentation = new Presentation("externalWorkbook.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shapeCount = java_values($slide->getShapes()->size());
    if ($shapeCount > 0 && java_instanceof($slide->getShapes()->get_Item(0), new JavaClass("com.aspose.slides.IChart"))) {
        $chart = $slide->getShapes()->get_Item(0);
        $chartData = $chart->getChartData();
        if (java_values($chartData->getDataSourceType()) == ChartDataSourceType::ExternalWorkbook) {
            echo $chartData->getExternalWorkbookPath(), PHP_EOL;
        } else {
            echo "The chart does not use an external workbook.", PHP_EOL;
        }
    } else {
        echo "The first shape is not a chart.", PHP_EOL;
    }

    $presentation->save("Result.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **แก้ไขข้อมูลแผนภูมิ**

คุณสามารถแก้ไขข้อมูลในเวิร์กบุ๊กภายนอกได้เช่นเดียวกับการเปลี่ยนแปลงเนื้อหาในเวิร์กบุ๊กภายใน หากเวิร์กบุ๊กภายนอกโหลดไม่สำเร็จ จะเกิดข้อยกเว้น

ตัวอย่างนี้ต้องการ `presentation.pptx` ที่มีแผนภูมิเป็นรูปทรงแรกบนสไลด์แรกและเวิร์กบุ๊กภายนอกที่เข้าถึงได้ ตั้งค่าค่าแบ็กจากเซลล์ของจุดข้อมูลแรกในซีรีส์แรกเป็น 100 แล้วบันทึกงานนำเสนอเป็น `presentation_out.pptx` การแก้ไขค่าเซลล์สามารถอัปเดตไฟล์ XLSX ที่ลิงก์ได้, ดังนั้นควรใช้สำเนาหากต้องการรักษาเวิร์กบุ๊กต้นฉบับ

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("presentation.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shapeCount = java_values($slide->getShapes()->size());
    if ($shapeCount > 0 && java_instanceof($slide->getShapes()->get_Item(0), new JavaClass("com.aspose.slides.IChart"))) {
        $chart = $slide->getShapes()->get_Item(0);
        $series = $chart->getChartData()->getSeries();
        if (java_values($series->size()) > 0 && java_values($series->get_Item(0)->getDataPoints()->size()) > 0) {
            $valueCell = $series->get_Item(0)->getDataPoints()->get_Item(0)->getValue()->getAsCell();
            if (!java_is_null($valueCell)) {
                $valueCell->setValue(100);
                $presentation->save("presentation_out.pptx", SaveFormat::Pptx);
            } else {
                echo "The first data point is not linked to a workbook cell.", PHP_EOL;
            }
        } else {
            echo "The chart has no data points to edit.", PHP_EOL;
        }
    } else {
        echo "The first shape is not a chart.", PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

### **กู้คืนเวิร์กบุ๊กจากแคชแผนภูมิ**

หากแผนภูมิกำหนดเวิร์กบุ๊กภายนอกที่หายไปหรือไม่สามารถเข้าถึงได้, Aspose.Slides สามารถสร้างเวิร์กบุ๊กแผนภูมิกจากข้อมูลที่แคชไว้ในงานนำเสนอได้ สร้าง [LoadOptions](https://reference.aspose.com/slides/th/php-java/aspose.slides/loadoptions/), เรียก [LoadOptions::setSpreadsheetOptions](https://reference.aspose.com/slides/th/php-java/aspose.slides/loadoptions/setspreadsheetoptions/), และตั้งค่า [SpreadsheetOptions::setRecoverWorkbookFromChartCache](https://reference.aspose.com/slides/th/php-java/aspose.slides/spreadsheetoptions/setrecoverworkbookfromchartcache/) เป็น `true` ก่อนเปิดงานนำเสนอ

ตัวอย่าง PHP ต่อไปนี้เปิด `presentation.pptx` ซึ่งรูปทรงแรกบนสไลด์แรกต้องเป็นแผนภูมิที่อ้างอิงเวิร์กบุ๊กภายนอกที่ไม่สามารถเข้าถึงได้, แล้วเข้าถึงข้อมูลที่กู้คืนผ่าน [Chart::getChartData](https://reference.aspose.com/slides/th/php-java/aspose.slides/chart/getchartdata/) และ [ChartData::getChartDataWorkbook](https://reference.aspose.com/slides/th/php-java/aspose.slides/chartdata/getchartdataworkbook/):

```php
use aspose\slides\Presentation;
use aspose\slides\SpreadsheetOptions;
use aspose\slides\LoadOptions;

$spreadsheetOptions = new SpreadsheetOptions();
$spreadsheetOptions->setRecoverWorkbookFromChartCache(true);

$loadOptions = new LoadOptions();
$loadOptions->setSpreadsheetOptions($spreadsheetOptions);

$presentation = new Presentation("presentation.pptx", $loadOptions);
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shapeCount = java_values($slide->getShapes()->size());
    if ($shapeCount > 0 && java_instanceof($slide->getShapes()->get_Item(0), new JavaClass("com.aspose.slides.IChart"))) {
        $chart = $slide->getShapes()->get_Item(0);
        $recoveredWorkbook = $chart->getChartData()->getChartDataWorkbook();

        // อ่านหรือแก้ไขข้อมูลเวิร์กบุ๊กที่กู้คืนได้ที่นี่.
    } else {
        echo "The first shape is not a chart.", PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

หากเวิร์กบุ๊กภายนอกไม่สามารถเข้าถึงได้และการกู้คืนถูกปิด, Aspose.Slides จะโยนข้อยกเว้น เปิดการกู้คืนเฉพาะเมื่อต้องการใช้ข้อมูลแคชของแผนภูมิเป็นวิธีสำรองที่ยอมรับได้, เนื่องจากแคชอาจไม่มีการเปลี่ยนแปลงที่ทำในเวิร์กบุ๊กภายนอกหลังจากการอัปเดตครั้งล่าสุดของงานนำเสนอ

## **คำถามที่พบบ่อย**

**ฉันจะตรวจสอบได้หรือไม่ว่าแผนภูมิเฉพาะลิงก์กับเวิร์กบุ๊กภายนอกหรือฝังอยู่?**

ได้. แผนภูมิมี [data source type](https://reference.aspose.com/slides/th/php-java/aspose.slides/chartdata/getdatasourcetype/) และ [path to an external workbook](https://reference.aspose.com/slides/th/php-java/aspose.slides/chartdata/getexternalworkbookpath/); หากเป็นเวิร์กบุ๊กภายนอก, คุณสามารถอ่านเส้นทางเต็มเพื่อยืนยันว่าไฟล์ภายนอกถูกใช้

**รองรับเส้นทางสัมพัทธ์ไปยังเวิร์กบุ๊กภายนอกหรือไม่, และจัดเก็บอย่างไร?**

รองรับ. หากระบุเส้นทางสัมพัทธ์, ระบบจะเปลี่ยนเป็นเส้นทางเต็มอัตโนมัติ งานนำเสนอจะเก็บเส้นทางเต็มในไฟล์ PPTX, ดังนั้นการย้ายเวิร์กบุ๊กอาจต้องอัปเดตลิงก์

**สามารถใช้เวิร์กบุ๊กที่อยู่บนทรัพยากรเครือข่าย/แชร์ได้หรือไม่?**

ได้, เวิร์กบุ๊กเหล่านี้สามารถใช้เป็นแหล่งข้อมูลภายนอกได้ อย่างไรก็ตามการแก้ไขเวิร์กบุ๊กระยะไกลโดยตรงจาก Aspose.Slides ไม่ได้รับการสนับสนุน – สามารถใช้เป็นแหล่งข้อมูลเท่านั้น

**Aspose.Slides จะเขียนทับไฟล์ XLSX ภายนอกเมื่อบันทึกงานนำเสนอหรือไม่?**

งานนำเสนอจะเก็บ [link to the external file](https://reference.aspose.com/slides/th/php-java/aspose.slides/chartdata/getexternalworkbookpath/). การแก้ไขข้อมูลแผนภูมิที่อ้างอิงเซลล์อาจอัปเดตไฟล์ XLSX ภายในเครื่องที่ลิงก์อยู่ ใช้สำเนาของเวิร์กบุ๊กหากต้องการให้ต้นฉบับคงเดิม

**ต้องทำอย่างไรหากไฟล์ภายนอกถูกป้องกันด้วยรหัสผ่าน?**

Aspose.Slides ไม่รับรหัสผ่านเมื่อทำการลิงก์ วิธีที่พบบ่อยคือถอดการป้องกันล่วงหน้า หรือเตรียมสำเนาที่ถอดรหัส (เช่นใช้ [Aspose.Cells](https://reference.aspose.com/cells/java/)) แล้วลิงก์ไปยังสำเนานั้น

**หลายแผนภูมิสามารถอ้างอิงเวิร์กบุ๊กภายนอกเดียวกันได้หรือไม่?**

ได้. แต่ละแผนภูมิจะเก็บลิงก์ของตนเอง หากทั้งหมดลิงก์ไปยังไฟล์เดียวกัน, การอัปเดตไฟล์นั้นจะสะท้อนต่อทุกแผนภูมิในการโหลดข้อมูลครั้งถัดไป