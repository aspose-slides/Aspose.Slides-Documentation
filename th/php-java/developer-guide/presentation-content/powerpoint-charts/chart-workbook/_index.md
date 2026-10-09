---
title: จัดการ Workbook ของแผนภูมิในงานนำเสนอโดยใช้ PHP
linktitle: Workbook ของแผนภูมิ
type: docs
weight: 70
url: /th/php-java/chart-workbook/
keywords:
- Workbook ของแผนภูมิ
- ข้อมูลแผนภูมิ
- เซลล์ workbook
- ป้ายกำกับข้อมูล
- แผ่นงาน
- แหล่งข้อมูล
- Workbook ภายนอก
- ข้อมูลภายนอก
- แคชของแผนภูมิ
- การกู้คืน Workbook
- PowerPoint
- งานนำเสนอ
- PHP
- Aspose.Slides
description: "ค้นพบ Aspose.Slides สำหรับ PHP ผ่าน Java: จัดการ chart workbook ใน PowerPoint และรูปแบบ OpenDocument อย่างง่ายดายเพื่อปรับปรุงข้อมูลงานนำเสนอของคุณ"
---
## **ภาพรวม**

บทความนี้อธิบายวิธีทำงานกับ chart workbook ใน Aspose.Slides แสดงวิธีอ่านและเขียนข้อมูลแผนภูมิผ่าน workbook stream, ใช้เซลล์ workbook เป็น label ของข้อมูลแผนภูมิ, เข้าถึงคอลเลกชัน worksheet, และระบุประเภทแหล่งข้อมูลสำหรับค่าแผนภูมิ

ยังครอบคลุมการทำงานกับ workbook ภายนอกเป็นแหล่งข้อมูลของแผนภูมิ ตัวอย่างแสดงวิธีสร้างและกำหนด workbook ภายนอก, ดึงเส้นทางของ workbook ภายนอกที่เชื่อมโยงกับแผนภูมิ, และแก้ไขข้อมูลแผนภูมิเมื่อ workbook มีอยู่

สำหรับเซลล์ workbook ที่เป็นข้อมูลที่หายไป ดูที่ [Control the Display of Empty Cells](/slides/th/php-java/chart-series/) เพื่อเข้าใจความแตกต่างระหว่างเซลล์ว่างและค่า 0, รวมถึงการเปรียบเทียบแบบเส้นกราฟของโหมดการแสดงผลที่มีให้เลือก

## **รวมข้อมูลจากแถวและคอลัมน์ที่ซ่อน**

ใช้ [Chart::setPlotVisibleCellsOnly](https://reference.aspose.com/slides/php-java/aspose.slides/chart/setplotvisiblecellsonly/) เพื่อควบคุมว่ากราฟจะ plot ข้อมูลจากแถวและคอลัมน์ worksheet ที่ซ่อนหรือไม่ ตั้งค่าเป็น `true` เพื่อ plot เฉพาะเซลล์ที่มองเห็น, หรือ `false` เพื่อรวมทั้งเซลล์ที่มองเห็นและที่ซ่อน การตั้งค่านี้ควบคุมการ plot ของกราฟ; ไม่ได้ซ่อนหรือแสดงแถวหรือคอลัมน์ worksheet

[ตัวอย่างการพรีเซนเทชัน](hidden-source-data.pptx) มี column chart เป็น shape แรกบนสไลด์แรก Worksheet ที่ฝังอยู่, `Sheet1`, มีช่วงแหล่งข้อมูล `A1:C4`. แถว 3 และคอลัมน์ C ถูกซ่อน, แต่เซลล์ของพวกมันยังคงมีค่า

| แถว Worksheet | เดือน | ค้าปลีก | ค้าส่ง (คอลัมน์ซ่อน) |
| --- | --- | --- | --- |
| 2 | มกราคม | 10 | 30 |
| 3 (แถวซ่อน) | กุมภาพันธ์ | 40 | 60 |
| 4 | มีนาคม | 20 | 50 |

เข้าถึงเซลล์แหล่งข้อมูลผ่าน [ChartData::getChartDataWorkbook](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/getchartdataworkbook/) และอ่าน [ChartDataCell::isHidden](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatacell/ishidden/) เพื่อตรวจสอบสถานะซ่อนของเซลล์ วิธีนี้รายงานสถานะซ่อนได้โดยไม่เปลี่ยนค่า ในไฟล์นี้ B2 มองเห็น, B3 อยู่ในแถวซ่อน, และ C2 อยู่ในคอลัมน์ซ่อน; ตัวอย่างพิมพ์ `false`, `true`, และ `true` ตามลำดับ

สำหรับตัวอย่างนี้, รีเฟรชข้อมูลกราฟหลังการเปลี่ยนการตั้งค่า plot: รักษา workbook ที่ฝังด้วย [readWorkbookStream](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/readworkbookstream/) และโหลดใหม่ด้วย [writeWorkbookStream](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/writeworkbookstream/) เมื่อรวมทุกเซลล์, ใช้ [setRange](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/setrange/) เพื่อคืนช่วงเต็มรวมถึงหมวดหมู่เดือนกุมภาพันธ์ที่ซ่อน การเปลี่ยนค่า flag อย่างเดียวไม่เพียงพอที่จะรีเฟรชข้อมูลแคชของกราฟและ label หมวดหมู่ในตัวอย่างนี้

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

            // รีเฟรชข้อมูลแผนภูมิจาก workbook ที่ฝังอยู่.
            $chart->getChartData()->writeWorkbookStream($workbookData);
            if (!$visibleOnly) {
                // คืนค่าช่วงแหล่งข้อมูลทั้งหมดรวมถึงหมวดหมู่ที่ซ่อนอยู่.
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

ตัวอย่างบันทึกพรีเซนเทชันสองเวอร์ชัน: เวอร์ชันหนึ่งมีค่า Retail ที่มองเห็นเท่านั้น (10 และ 20), อีกเวอร์ชันหนึ่งมีค่าทั้งหกค่า รูปภาพด้านล่างแสดงสองโหมดการ plot แถว 3 และคอลัมน์ C ยังคงซ่อนในทั้งสอง workbook ที่ฝัง

| เฉพาะเซลล์ที่มองเห็น (`true`) | ทุกเซลล์ (`false`) |
| --- | --- |
| ![เฉพาะเซลล์ที่มองเห็น: ค่ารายการค้าปลีก 10 และ 20 สำหรับเดือนมกราคมและมีนาคม.](hidden_cells_True.png) | ![ทุกเซลล์: ค่ารายการค้าปลีกและค้าส่งสำหรับเดือนมกราคม, กุมภาพันธ์, และมีนาคม.](hidden_cells_False.png) |

เซลล์ที่ซ่อนและมีค่าแตกต่างจากเซลล์ว่าง [Chart::setDisplayBlanksAs](https://reference.aspose.com/slides/php-java/aspose.slides/chart/setdisplayblanksas/) ควบคุมวิธีการแสดงค่าที่หายไป; ไม่ได้รวมหรือแยกแหล่งข้อมูลที่ซ่อน ดูที่ [Control the Display of Empty Cells](/slides/th/php-java/chart-series/#control-the-display-of-empty-cells) สำหรับตัวอย่าง

## **ดึงช่วงข้อมูลของแผนภูมิ**

ก่อนอัปเดตข้อมูล workbook ในพรีเซนเทชันที่มีอยู่, ตรวจสอบช่วงแหล่งข้อมูลเพื่อระบุว่า worksheet ใดเป็นแหล่งข้อมูลของแต่ละแผนภูมิ วิธี [ChartData::getRange](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/getrange/) คืนช่วงข้อมูลปัจจุบันในรูปสูตรที่ระบุ worksheet, เช่น `Sheet1!$A$1:$D$5`. ที่นี่ `Sheet1` คือชื่อ worksheet, `!` แยกจากช่วงเซลล์, และ `$A$1:$D$5` ระบุเซลล์ A1 ถึง D5 รวมถึงสัญลักษณ์ `$` แสดงการอ้างอิงคงที่

วิธีนี้อ่านช่วงปัจจุบันโดยไม่เปลี่ยนแปลงแผนภูมิหรือ workbook หากแผนภูมิไม่ใช้ workbook เป็นแหล่งข้อมูล จะเกิดข้อยกเว้น สำหรับข้อมูลเพิ่มเติมดูที่ [ChartData API Reference](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/)

ตัวอย่างนี้เปิดพรีเซนเทชันและตรวจสอบ shape แต่ละอันบนสไลด์เพื่อค้นหาแผนภูมิ พิมพ์ชื่อแผนภูมิและช่วงแหล่งข้อมูล หากแผนภูมิไม่ใช้ workbook จะพิมพ์ข้อความและดำเนินการต่อไปยังแผนภูมถัดไป

```php
use aspose\slides\Presentation;

$presentation = new Presentation("presentation.pptx");
try {
    $slideCount = java_values($presentation->getSlides()->size());
    for ($slideIndex = 0; $slideIndex < $slideCount; $slideIndex++) {
        $slide = $presentation->getSlides()->get_Item($slideIndex);
        $shapeCount = java_values($slide->getShapes()->size());
        for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
            $shape = $slide->getShapes()->get_Item($shapeIndex);
            if (java_instanceof($shape, new JavaClass("com.aspose.slides.IChart"))) {
                $chart = $shape;
                try {
                    $range = $chart->getChartData()->getRange();
                    echo $chart->getName() . ": " . $range, PHP_EOL;
                } catch (JavaException $exception) {
                    if (java_instanceof($exception, new JavaClass("com.aspose.slides.exceptions.InvalidOperationException"))) {
                        echo $chart->getName() . ": The chart does not use a workbook as its data source.", PHP_EOL;
                    } else {
                        echo $chart->getName() . ": " . $exception->getMessage(), PHP_EOL;
                    }
                }
            }
        }
    }
} finally {
    $presentation->dispose();
}
```

## **อ่านและเขียนข้อมูลแผนภูมิจาก Workbook**

Aspose.Slides for PHP via Java มีเมธอด [readWorkbookStream](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/readworkbookstream/) และ [writeWorkbookStream](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/writeworkbookstream/) ที่ให้คุณอ่านและเขียน workbook ของข้อมูลแผนภูมิ (ซึ่งอาจแก้ไขด้วย Aspose.Cells) **Note** ว่าข้อมูลแผนภูมิต้องจัดเรียงในรูปแบบเดียวกันหรือมีโครงสร้างคล้ายกับแหล่งข้อมูล

ตัวอย่างนี้ใช้พรีเซนเทชันที่มีแผนภูมิเป็น shape แรกบนสไลด์แรก อ่าน workbook ที่ฝังเป็นอาเรย์ไบต์, ล้าง series และ categories ที่มีอยู่, แล้วเขียน workbook เดิมกลับไป การเปลี่ยนแปลงอยู่ในหน่วยความจำ; ตัวอย่างไม่บันทึกพรีเซนเทชัน

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

### **ตรวจสอบ Layout ของแผนภูมิหลังการแก้ไข Workbook**

เมื่อคุณแทนที่ workbook ที่ฝังด้วย workbook ที่แก้ไข, แผนภูมิจะยังคงมี series และ collection ของ category ดั้งเดิม ความไม่ตรงนี้อาจทำให้ [Chart::validateChartLayout](https://reference.aspose.com/slides/php-java/aspose.slides/chart/validatechartlayout/) ล้มเหลวด้วยข้อผิดพลาด index-out-of-range ล้าง series และ categories ที่มีอยู่ก่อนเขียน workbook ที่อัปเดตกลับไปยังแผนภูมิ ตัวอย่างนี้ใช้แผนภูมิที่เป็น shape แรกบนสไลด์แรก คอมเมนต์ชี้ตำแหน่งที่ควรแก้ไข workbook; ตัวอย่างที่ทำงานได้เขียน workbook ดั้งเดิมกลับไปและตรวจสอบ layout ในหน่วยความจำ

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

        // แก้ไขไบต์ของ workbook ที่นี่, ตัวอย่างเช่น ใช้ Aspose.Cells.

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

การล้าง collection จะลบการอ้างอิงข้อมูลที่ล้าสมัยก่อนเขียน workbook กลับไป สร้าง series และ mapping ของ category ที่จำเป็นสำหรับ workbook ที่อัปเดตก่อนใช้แผนภูมิ

## **ตั้งค่า Workbook Cell เป็น Label ของข้อมูลแผนภูมิ**

คุณสามารถใช้ข้อความจากเซลล์ workbook เป็น label ของข้อมูลแผนภูมิ

ตัวอย่างนี้เพิ่ม bubble chart พร้อมข้อมูลเริ่มต้นบนสไลด์แรกของพรีเซนเทชันที่มีอยู่ ใช้เซลล์ A10:A12 ใน worksheet 0 เป็น label แรกของ series แรก, เปิดใช้งาน label จากเซลล์, และบันทึกรายการที่อัปเดต

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

## **จัดการ Worksheets**

เมธอด [ChartDataWorkbook::getWorksheets](https://reference.aspose.com/slides/php-java/aspose.slides/chartdataworkbook/getworksheets/) ให้เข้าถึง worksheets ใน chart workbook ตัวอย่างนี้สร้าง pie chart พร้อมข้อมูลเริ่มต้นและพิมพ์ชื่อแต่ละ worksheet ไปยังคอนโซล

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

## **ระบุประเภทแหล่งข้อมูล**

ตัวอย่างนี้สร้าง 3D column chart พร้อมข้อมูลเริ่มต้นและตั้งชื่อ series สองชื่อโดยใช้แหล่งข้อมูลต่างกัน ชื่อแรกใช้สตริงลิเทรัล, ชื่อที่สองใช้เซล C1 ใน worksheet 0 ค่าตัวเลือก [DataSourceType](https://reference.aspose.com/slides/php-java/aspose.slides/datasourcetype/) กำหนดแหล่งสำหรับแต่ละชื่อ ตัวอย่างบันทึกพรีเซนเทชันพร้อมชื่อ series ที่อัปเดต

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

## **ตรวจจับรูปแบบ Workbook ที่ฝังไม่ได้รับการสนับสนุน**

Aspose.Slides ไม่รองรับรูปแบบ Excel binary workbook (.xlsb) ที่อาจฝังในบางแผนภูมิ คุณสามารถใช้เมธอด `getEmbeddedWorkbookType` บน [ChartData](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/) ร่วมกับ enumeration [WorkbookType](https://reference.aspose.com/slides/php-java/aspose.slides/workbooktype/) เพื่อตรวจจับรูปแบบที่ไม่ได้รับการสนับสนุนและข้ามแผนภูมินั้น ตัวอย่างตรวจสอบ shape บนสไลด์แรกของพรีเซนเทชันที่มีอยู่, ข้าม shape ที่ไม่ใช่แผนภูมิ, และพิมพ์ข้อความวินิจฉัยสำหรับแต่ละแผนภูมิที่มี workbook .xlsb ฝัง

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

        // อ่านหรือแก้ไขข้อมูล workbook ของแผนภูมิที่สนับสนุนที่นี่.
    }
} finally {
    $presentation->dispose();
}
```

## **Workbook ภายนอก**

Aspose.Slides รองรับการใช้ workbook ภายนอกเป็นแหล่งข้อมูลของแผนภูมิ

### **สร้าง Workbook ภายนอก**

ใช้ [readWorkbookStream](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/readworkbookstream/) และ [setExternalWorkbook](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/setexternalworkbook/) เพื่อส่งออก workbook ของแผนภูมิที่ฝังเป็นไฟล์และเชื่อมโยงแผนภูมิไปยัง workbook ภายนอกนั้น

ตัวอย่างนี้สร้าง pie chart พร้อมข้อมูลเริ่มต้นและส่งออก workbook ของมัน เสร็จสิ้นการเขียนไฟล์ก่อนกำหนด workbook ภายนอกเป็นแหล่งข้อมูลของแผนภูมิ, จากนั้นบันทึกพรีเซนเทชันที่เชื่อมโยง

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

### **ตั้งค่า Workbook ภายนอก**

โดยใช้เมธอด [setExternalWorkbook](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/setexternalworkbook/) คุณสามารถกำหนด workbook ภายนอกให้กับแผนภูมิเป็นแหล่งข้อมูลได้ เมธอดนี้ยังใช้เพื่ออัปเดตเส้นทางไปยัง workbook ภายนอก (หากไฟล์ถูกย้าย)

แม้คุณจะไม่สามารถแก้ไขข้อมูลใน workbook ที่เก็บไว้ในตำแหน่งระยะไกลหรือแหล่งทรัพยากรได้, คุณยังสามารถใช้ workbook เหล่านั้นเป็นแหล่งข้อมูลภายนอกได้ หากให้เส้นทางสัมพันธ์สำหรับ workbook ภายนอก, ระบบจะเปลี่ยนเป็นเส้นทางเต็มโดยอัตโนมัติ

ตัวอย่างนี้ใช้ workbook ภายนอกที่ worksheet ชื่อ `Sheet1` มีชื่อ series ใน B1, ชื่อหมวดหมู่ใน A2:A4, และค่าตัวเลขใน B2:B4 ตัวอย่างสร้าง pie chart, เชื่อมโยง workbook, และใช้ [setRange](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/setrange/) เพื่อแมป A1:B4 เป็น series หนึ่งและสามหมวดหมู่ จากนั้นบันทึกพรีเซนเทชันพร้อมแผนภูมิที่เชื่อมโยง

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

พารามิเตอร์ `updateChartData` ของเมธอด [setExternalWorkbook](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/setexternalworkbook/) ควบคุมว่าควรโหลด workbook หรือไม่

* เมื่อ `updateChartData` เป็น `false`, จะอัปเดตเฉพาะเส้นทางของ workbook เท่านั้น ข้อมูลแผนภูมิจะไม่ถูกโหลดหรืออัปเดตจาก workbook ปลายทาง, ดังนั้น workbook สามารถไม่มีได้
* เมื่อ `updateChartData` เป็น `true`, ข้อมูลแผนภูมิจะอัปเดตจาก workbook ปลายทาง

ตัวอย่างต่อไปกำหนด URL ตัวแทนพร้อม `updateChartData` เป็น `false`. จะคงข้อมูลเริ่มต้นของ pie chart และบันทึกพรีเซนเทชันโดยไม่โหลด workbook ที่ไม่มี

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

### **ดึงเส้นทาง Workbook ของแหล่งข้อมูลภายนอกจากแผนภูมิ**

เพื่อระบุ workbook ที่เชื่อมโยงกับแผนภูมิ, ตรวจสอบว่าแผนภูมิโใช้แหล่งข้อมูลภายนอกหรือไม่และดึงเส้นทาง workbook ของมัน

ตัวอย่างนี้ตรวจสอบ shape แรกบนสไลด์แรกของพรีเซนเทชันที่มี workbook ภายนอกเชื่อมโยง หากเป็นแผนภูมิที่เชื่อมกับ workbook ภายนอก, จะพิมพ์ [getExternalWorkbookPath](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/getexternalworkbookpath/) ไปยังคอนโซล แล้วบันทึกสำเนาพรีเซนเทชัน

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

คุณสามารถแก้ไขข้อมูลใน workbook ภายนอกได้เช่นเดียวกับการเปลี่ยนแปลงเนื้อหาใน workbook ภายใน เมื่อ workbook ภายนอกไม่สามารถโหลดได้ จะเกิดข้อยกเว้น

ตัวอย่างนี้ใช้แผนภูมิที่เป็น shape แรกบนสไลด์แรกและเชื่อมกับ workbook ภายนอกที่เข้าถึงได้ ตั้งค่าค่าในเซลล์ของจุดข้อมูลแรกใน series แรกเป็น 100 และบันทึกพรีเซนเทชันที่อัปเดต การแก้ไขค่าเซลล์สามารถอัปเดตไฟล์ XLSX ภายนอกที่เชื่อมโยง, ดังนั้นควรใช้สำเนา หากต้องการรักษา workbook ดั้งเดิม

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

### **กู้คืน Workbook จากแคชของแผนภูมิ**

หากแผนภูมิใช้ workbook ภายนอกที่หายไปหรือไม่พร้อมใช้งาน, Aspose.Slides สามารถสร้างใหม่จากข้อมูลที่แคชไว้ในพรีเซนเทชัน สร้าง [LoadOptions](https://reference.aspose.com/slides/php-java/aspose.slides/loadoptions/), เรียก [LoadOptions::setSpreadsheetOptions](https://reference.aspose.com/slides/php-java/aspose.slides/loadoptions/setspreadsheetoptions/), และตั้งค่า [SpreadsheetOptions::setRecoverWorkbookFromChartCache](https://reference.aspose.com/slides/php-java/aspose.slides/spreadsheetoptions/setrecoverworkbookfromchartcache/) เป็น `true` ก่อนเปิดพรีเซนเทชัน

ตัวอย่าง PHP ด้านล่างกู้คืนข้อมูล workbook สำหรับแผนภูมิที่เป็น shape แรกบนสไลด์แรกและอ้างอิง workbook ภายนอกที่ไม่มีอยู่ เข้าถึงข้อมูลที่กู้คืนผ่าน [Chart::getChartData](https://reference.aspose.com/slides/php-java/aspose.slides/chart/getchartdata/) และ [ChartData::getChartDataWorkbook](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/getchartdataworkbook/):

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

        // อ่านหรือแก้ไขข้อมูล workbook ที่กู้คืนที่นี่.
    } else {
        echo "The first shape is not a chart.", PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

หาก workbook ภายนอกไม่พร้อมและการกู้คืนถูกปิด, Aspose.Slides จะโยนข้อยกเว้น เปิดใช้งานการกู้คืนเฉพาะเมื่อการใช้ข้อมูลแคชของแผนภูมิเป็นทางเลือกที่ยอมรับได้, เนื่องจากแคชอาจไม่รวมการเปลี่ยนแปลงที่ทำใน workbook ภายนอกหลังจากพรีเซนเทชันอัปเดตเป็นครั้งล่าสุด

## **FAQ**

**ฉันสามารถตรวจสอบได้หรือไม่ว่าแผนภูมิเฉพาะเชื่อมโยงกับ workbook ภายนอกหรือฝังอยู่?**

ได้. แผนภูมิมี [data source type](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/getdatasourcetype/) และ [path to an external workbook](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/getexternalworkbookpath/); หากแหล่งเป็น workbook ภายนอก คุณสามารถอ่านเส้นทางเต็มเพื่อยืนยันว่าไฟล์ภายนอกกำลังถูกใช้

**รองรับเส้นทางสัมพันธ์ไปยัง workbook ภายนอกหรือไม่, แล้วจัดเก็บอย่างไร?**

ได้. หากคุณระบุเส้นทางสัมพันธ์, ระบบจะเปลี่ยนเป็นเส้นทางเต็มโดยอัตโนมัติ พรีเซนเทชันจะเก็บเส้นทางเต็มในไฟล์ PPTX, ดังนั้นการย้าย workbook อาจต้องอัปเดตลิงก์

**ฉันสามารถใช้ workbook ที่อยู่บนทรัพยากรเครือข่าย/แชร์ได้หรือไม่?**

ได้, workbook เหล่านั้นสามารถใช้เป็นแหล่งข้อมูลภายนอกได้ อย่างไรก็ตาม การแก้ไข workbook ระยะไกลโดยตรงจาก Aspose.Slides ไม่ได้รับการสนับสนุน — อาจใช้ได้เฉพาะเป็นแหล่งข้อมูลเท่านั้น

**Aspose.Slides จะเขียนทับไฟล์ XLSX ภายนอกเมื่อบันทึกพรีเซนเทชันหรือไม่?**

พรีเซนเทชันจะเก็บ [link to the external file](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/getexternalworkbookpath/). การแก้ไขข้อมูลแผนภูมิที่อ้างอิงเซลล์อาจอัปเดตไฟล์ XLSX ภายในที่เชื่อมโยง ใช้สำเนาของ workbook หากต้องการให้ไฟล์ต้นฉบับคงเดิม

**ควรทำอย่างไรหากไฟล์ภายนอกถูกป้องกันด้วยรหัสผ่าน?**

Aspose.Slides ไม่รับรหัสผ่านเมื่อเชื่อมโยง วิธีทั่วไปคือถอดการป้องกันล่วงหน้า หรือเตรียมสำเนาที่ถอดรหัสแล้ว (เช่น ใช้ [Aspose.Cells](https://reference.aspose.com/cells/java/)) แล้วเชื่อมโยงไปยังสำเนานั้น

**หลายแผนภูมิสามารถอ้างอิง workbook ภายนอกเดียวกันได้หรือไม่?**

ได้. แต่ละแผนภูมิเก็บลิงก์ของตนเอง หากทั้งหมดชี้ไปยังไฟล์เดียวกัน การอัปเดตไฟล์นั้นจะสะท้อนในแต่ละแผนภูมิเมื่อโหลดข้อมูลครั้งต่อไป