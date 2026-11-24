---
title: จัดการเวิร์กบุ๊กแผนภูมิในงานนำเสนอด้วย PHP
linktitle: เวิร์กบุ๊กแผนภูมิ
type: docs
weight: 70
url: /th/php-java/chart-workbook/
keywords:
- เวิร์กบุ๊กแผนภูมิ
- ข้อมูลแผนภูมิ
- เซลล์เวิร์กบุ๊ก
- ป้ายข้อมูล
- เวิร์กชีต
- แหล่งข้อมูล
- เวิร์กบุ๊กภายนอก
- ข้อมูลภายนอก
- แคชแผนภูมิ
- การกู้คืนเวิร์กบุ๊ก
- PowerPoint
- งานนำเสนอ
- PHP
- Aspose.Slides
description: "ค้นพบ Aspose.Slides สำหรับ PHP ผ่าน Java: จัดการเวิร์กบุ๊กแผนภูมิในรูปแบบ PowerPoint และ OpenDocument อย่างง่ายดายเพื่อปรับปรุงข้อมูลงานนำเสนอของคุณ."
---
## **ภาพรวม**

บทความนี้อธิบายวิธีการทำงานกับเวิร์กบุคชาร์ตใน Aspose.Slides โดยแสดงวิธีอ่านและเขียนข้อมูลชาร์ตผ่านสตรีมของเวิร์กบุ๊ก, ใช้เซลล์ของเวิร์กบุ๊กเป็นป้ายชื่อข้อมูลของชาร์ต, เข้าถึงคอลเลกชันของเวิร์กชีต, และระบุประเภทแหล่งข้อมูลสำหรับค่าของชาร์ต

บทความยังครอบคลุมการทำงานกับเวิร์กบุ๊กภายนอกเป็นแหล่งข้อมูลของชาร์ต ตัวอย่างจะแสดงวิธีสร้างและกำหนดเวิร์กบุ๊กภายนอก, ดึงเส้นทางของเวิร์กบุ๊กภายนอกที่เชื่อมโยงกับชาร์ต, และแก้ไขข้อมูลชาร์ตเมื่อเวิร์กบุ๊กพร้อมใช้งาน

สำหรับเซลล์เวิร์กบุ๊กที่เป็นตัวแทนของข้อมูลที่หายไป, ดูที่ [ควบคุมการแสดงผลของเซลล์ว่าง](/slides/th/php-java/chart-series/) เพื่อเรียนรู้ความแตกต่างระหว่างเซลล์ว่างและศูนย์, และเปรียบเทียบแบบแผนภูมิเส้นของโหมดการแสดงผลที่มีอยู่

## **รวมข้อมูลจากแถวและคอลัมน์ที่ซ่อนอยู่**

ใช้ [Chart::setPlotVisibleCellsOnly](https://reference.aspose.com/slides/php-java/aspose.slides/chart/setplotvisiblecellsonly/) เพื่อควบคุมว่าชาร์ตจะพล็อตข้อมูลจากแถวและคอลัมน์ของเวิร์กชีตที่ซ่อนอยู่หรือไม่ ตั้งเป็น `true` เพื่อพล็อตเฉพาะเซลล์ที่มองเห็นได้, หรือ `false` เพื่อรวมทั้งเซลล์ที่มองเห็นและที่ซ่อน การตั้งค่านี้ควบคุมการพล็อตของชาร์ต; ไม่ได้ซ่อนหรือแสดงแถวหรือคอลัมน์ของเวิร์กชีต

[ตัวอย่างงานนำเสนอ](hidden-source-data.pptx) มีแผนภูมิคอลัมน์เป็นรูปร่างแรกบนสไลด์แรกของมัน เวิร์กชีตที่ฝังอยู่, `Sheet1`, มีช่วงข้อมูลต้นทาง `A1:C4`. แถว 3 และคอลัมน์ C ถูกซ่อน, แต่เซลล์ของพวกมันยังคงมีค่า

| แถวของเวิร์กชีต | A: เดือน | B: การค้าปลีก | C: การค้าส่ง (คอลัมน์ซ่อน) |
| --- | --- | --- | --- |
| 2 | มกราคม | 10 | 30 |
| 3 (แถวซ่อน) | กุมภาพันธ์ | 40 | 60 |
| 4 | มีนาคม | 20 | 50 |

เข้าถึงเซลล์ต้นทางผ่าน [ChartData::getChartDataWorkbook](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/getchartdataworkbook/) และอ่าน [ChartDataCell::isHidden](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatacell/ishidden/) เพื่อตรวจสอบสถานะการซ่อนของเซลล์ วิธีนี้รายงานสถานะการซ่อนโดยไม่เปลี่ยนแปลงค่า ในไฟล์นี้ B2 มองเห็นได้, B3 อยู่ในแถวที่ซ่อน, และ C2 อยู่ในคอลัมน์ที่ซ่อน; ตัวอย่างพิมพ์ค่า `false`, `true`, และ `true` ตามลำดับ

สำหรับตัวอย่างนี้, รีเฟรชข้อมูลชาร์ตหลังจากเปลี่ยนการตั้งค่าการพล็อต: เก็บเวิร์กบุ๊กที่ฝังไว้ด้วย [readWorkbookStream](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/readworkbookstream/) แล้วโหลดใหม่ด้วย [writeWorkbookStream](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/writeworkbookstream/) เมื่อรวมทุกเซลล์, ใช้ [setRange](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/setrange/) เพื่อกู้คืนช่วงทั้งหมดรวมถึงหมวดหมู่เดือนกุมภาพันธ์ที่ซ่อน การเปลี่ยนค่าสถานะเพียงอย่างเดียวไม่เพียงพอที่จะรีเฟรชข้อมูลชาร์ตที่แคชไว้และป้ายชื่อหมวดหมู่ของตัวอย่างนี้

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

            // รีเฟรชข้อมูลชาร์ตจากเวิร์กบุ๊กที่ฝังอยู่.
            $chart->getChartData()->writeWorkbookStream($workbookData);
            if (!$visibleOnly) {
                // กู้คืนช่วงต้นทางทั้งหมดรวมถึงหมวดหมู่ที่ซ่อนอยู่.
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

ตัวอย่างบันทึกสองเวอร์ชันของงานนำเสนอ: เวอร์ชันแรกมีเฉพาะค่าการค้าปลีกที่มองเห็นได้ (10 และ 20), เวอร์ชันที่สองมีค่าทั้งหกค่า ภาพด้านล่างแสดงโหมดการพล็อตสองแบบ แถว 3 และคอลัมน์ C ยังคงถูกซ่อนในทั้งสองเวิร์กบุ๊กที่ฝังอยู่

| เซลล์ที่มองเห็นเท่านั้น (`true`) | ทุกเซลล์ (`false`) |
| --- | --- |
| ![เซลล์ที่มองเห็นเท่านั้น: ค่าการค้าปลีก 10 และ 20 สำหรับเดือนมกราคมและมีนาคม.](hidden_cells_True.png) | ![ทุกเซลล์: ค่าการค้าปลีกและการค้าส่งสำหรับเดือนมกราคม, กุมภาพันธ์, และมีนาคม.](hidden_cells_False.png) |

เซลล์ที่ซ่อนอยู่และมีค่าแตกต่างจากเซลล์ว่าง [Chart::setDisplayBlanksAs](https://reference.aspose.com/slides/php-java/aspose.slides/chart/setdisplayblanksas/) ควบคุมวิธีการแสดงค่าที่หายไป; ไม่ได้รวมหรือยกเว้นข้อมูลต้นทางที่ซ่อน ดูที่ [ควบคุมการแสดงผลของเซลล์ว่าง](/slides/th/php-java/chart-series/#control-the-display-of-empty-cells) สำหรับตัวอย่าง

## **ดึงช่วงข้อมูลของชาร์ต**

ก่อนอัปเดตข้อมูลเวิร์กบุ๊กในงานนำเสนอที่มีอยู่, ตรวจสอบช่วงต้นทางเพื่อระบุว่าเวิร์กชีตแต่ละเซลล์ที่ชาร์ตใช้คืออะไร วิธี [ChartData::getRange](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/getrange/) คืนค่าช่วงข้อมูลปัจจุบันในรูปสูตรที่อ้างอิงเวิร์กชีต, เช่น `Sheet1!$A$1:$D$5`. ที่นี่ `Sheet1` คือชื่อเวิร์กชีต, `!` แยกจากช่วงเซลล์, และ `$A$1:$D$5` ระบุเซลล์ A1 ถึง D5 รวมทั้งสองค่า เครื่องหมายดอลลาร์บ่งบอกการอ้างอิงแบบคงที่ของแถวและคอลัมน์

เมธอดนี้อ่านช่วงปัจจุบันโดยไม่เปลี่ยนแปลงชาร์ตหรือเวิร์กบุ๊กของมัน หากชาร์ตไม่ได้ใช้เวิร์กบุ๊กเป็นแหล่งข้อมูล จะเกิดข้อยกเว้น สำหรับข้อมูลเพิ่มเติม ดูที่ [ChartData API Reference](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/)

ตัวอย่างนี้เปิดงานนำเสนอและตรวจสอบรูปร่างบนแต่ละสไลด์เพื่อค้นหาชาร์ต โดยพิมพ์ชื่อและช่วงต้นทางของแต่ละชาร์ต หากชาร์ตไม่ใช้เวิร์กบุ๊ก จะพิมพ์ข้อความและดำเนินการต่อไปยังชาร์ตถัดไป

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

## **อ่านและเขียนข้อมูลชาร์ตจากเวิร์กบุ๊ก**

Aspose.Slides for PHP via Java มีเมธอด [readWorkbookStream](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/readworkbookstream/) และ [writeWorkbookStream](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/writeworkbookstream/) ที่ให้คุณอ่านและเขียนเวิร์กบุ๊กข้อมูลชาร์ต (ที่มีข้อมูลชาร์ตแก้ไขด้วย Aspose.Cells) **หมายเหตุ** ข้อมูลชาร์ตต้องถูกจัดเรียงในรูปแบบเดียวกันหรือมีโครงสร้างคล้ายกับต้นฉบับ

ตัวอย่างนี้ใช้งานนำเสนอที่มีชาร์ตเป็นรูปร่างแรกบนสไลด์แรก อ่านเวิร์กบุ๊กที่ฝังอยู่เป็นอาเรย์ไบต์, ลบซีรีส์และหมวดหมู่เดิม, แล้วเขียนเวิร์กบุ๊กเดียวกันกลับไป การเปลี่ยนแปลงจะคงอยู่ในหน่วยความจำ; ตัวอย่างไม่บันทึกงานนำเสนอ

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

### **ตรวจสอบการจัดรูปแบบชาร์ตหลังการแก้ไขเวิร์กบุ๊ก**

เมื่อคุณทดแทนเวิร์กบุ๊กที่ฝังอยู่ด้วยเวิร์กบุ๊กที่แก้ไขแล้ว, ชาร์ตจะยังคงคอลเลกชันซีรีส์และหมวดหมู่เดิม ความไม่ตรงกันนี้อาจทำให้ [Chart::validateChartLayout](https://reference.aspose.com/slides/php-java/aspose.slides/chart/validatechartlayout/) ล้มเหลวด้วยข้อผิดพลาด index-out-of-range ให้ลบซีรีส์และหมวดหมู่เดิมก่อนเขียนเวิร์กบุ๊กที่อัปเดตกลับไปยังชาร์ต ตัวอย่างนี้ใช้ชาร์ตที่เป็นรูปร่างแรกบนสไลด์แรก คอมเมนท์ทำเครื่องหมายตำแหน่งที่จะแก้ไขเวิร์กบุ๊ก; ตัวอย่างที่รันได้เขียนเวิร์กบุ๊กต้นฉบับกลับและตรวจสอบการจัดรูปแบบในหน่วยความจำ

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

        // แก้ไขไบต์ของเวิร์กบุ๊กที่นี่, ตัวอย่างเช่น ใช้ Aspose.Cells.

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

การล้างคอลเลกชันจะลบการอ้างอิงข้อมูลที่ล้าสมัยก่อนที่เวิร์กบุ๊กจะถูกเขียนกลับ สร้างซีรีส์และการแมปหมวดหมู่ใหม่ตามที่ต้องการสำหรับเวิร์กบุ๊กที่อัปเดตก่อนใช้ชาร์ต

## **เลือกวิธีการจัดเก็บป้ายชื่อหมวดหมู่**

เรียก [ChartCategoryCollection::setUseCells](https://reference.aspose.com/slides/php-java/aspose.slides/chartcategorycollection/setusecells/) บนคอลเลกชันหมวดหมู่เปล่าก่อนเพิ่มป้ายชื่อ ใช้เซลล์ของเวิร์กชีตเมื่อป้ายชื่ออ้างอิงข้อมูลเวิร์กบุ๊กหรือประกอบเป็นลำดับขั้น เช่น ไตรมาสที่จัดกลุ่มตามปี ใช้สตริงลิเทอรัลสำหรับระดับเดียวของป้ายชื่อที่ไม่ต้องอ้างอิงเซลล์ การตั้งค่านี้ใช้เฉพาะกับหมวดหมู่ ทั้งสองชาร์ตในตัวอย่างใช้เซลล์ของเวิร์กชีตสำหรับค่าซีรีส์ตัวเลข

ตัวอย่างสร้างแผนภูมิคอลัมน์สองอันและพิมพ์โหมดการจัดเก็บตามด้วย `Q1 Q2 Q3 Q4` สำหรับแต่ละอัน สำหรับป้ายชื่อที่อ้างอิงเวิร์กชีต, [ChartCategory::getAsCell](https://reference.aspose.com/slides/php-java/aspose.slides/chartcategory/getascell/) คืนค่าเซลล์พื้นฐานและ [ChartDataCell::getValue](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatacell/getvalue/) คืนค่าป้ายชื่อ สำหรับป้ายชื่อลิเทอรัล, อ่านสตริงโดยตรงด้วย [ChartCategory::getValue](https://reference.aspose.com/slides/php-java/aspose.slides/chartcategory/getvalue/)

```php
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $shapes = $presentation->getSlides()->get_Item(0)->getShapes();

    foreach ([true, false] as $useCells) {
        $x = $useCells ? 20 : 360;
        $chart = $shapes->addChart(ChartType::ClusteredColumn, $x, 20, 320, 250);
        $data = $chart->getChartData();
        $data->getSeries()->clear();
        $categories = $data->getCategories();
        $categories->clear();
        $categories->setUseCells($useCells);

        $workbook = $data->getChartDataWorkbook();
        $seriesName = $workbook->getCell(0, 0, 1, "Sales");
        $series = $data->getSeries()->add($seriesName, $chart->getType());
        for ($row = 1; $row <= 4; $row++) {
            $label = "Q" . $row;
            if ($useCells) {
                $labelCell = $workbook->getCell(0, $row, 0, $label);
                $categories->add($labelCell);
            } else {
                $categories->add($label);
            }

            $valueCell = $workbook->getCell(0, $row, 1, $row * 10);
            $series->getDataPoints()->addDataPointForBarSeries($valueCell);
        }

        $storedInCells = java_values($categories->getUseCells());
        echo "UseCells = ", ($storedInCells ? "true" : "false"), ":";
        $categoryCount = java_values($categories->size());
        for ($i = 0; $i < $categoryCount; $i++) {
            $category = $categories->get_Item($i);
            $label = $storedInCells ? $category->getAsCell()->getValue() : $category->getValue();
            echo " ", java_values($label);
        }
        echo PHP_EOL;
    }

    $presentation->save("category-labels.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **ตั้งค่าฟอร์แมตตัวเลขแบบกำหนดเองสำหรับเซลล์เวิร์กบุ๊ก**

ใช้ [ChartDataCell::setCustomNumberFormat](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatacell/setcustomnumberformat/) เพื่อควบคุมว่าค่าตัวเลขจะแสดงอย่างไรในเวิร์กบุ๊กที่ฝังของชาร์ต ตัวอย่างเช่น รายงานอาจต้องการแสดงอัตราการแปลงเป็นเปอร์เซ็นต์ด้วยสี่ตำแหน่งทศนิยมและค่าสัมประสิทธิ์ด้วยห้าตำแหน่งทศนิยม เก็บค่าทั้งสองเป็นตัวเลขเพื่อให้ยังคงใช้ในการคำนวณและพล็อตชาร์ตได้

ฟอร์แมตตัวเลขเปลี่ยนการแสดงผล ไม่ได้เปลี่ยนค่าที่เก็บ ฟอร์แมต `0.0000%` จะทำให้ `0.125` แสดงเป็น `12.5000%`; ไม่ได้แทนที่ตัวเลขที่เก็บเป็น `12.5` เช่นกัน `0.00000` จะแสดง `0.1234567` เป็น `0.12346` โดยไม่ปัดค่าที่เก็บ หากฟอร์แมตกำหนดเองเป็นสตริงว่าง (`""`) จะใช้ฟอร์แมตที่ได้จาก [getPresetNumberFormat](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatacell/getpresetnumberformat/) แทน

ตัวอย่างต่อไปสร้างแผนภูมิคอลัมน์และเข้าถึงเซลล์ผ่าน [getChartDataWorkbook](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/getchartdataworkbook/). บนเวิร์กชีต 0, B2 มีอัตราการแปลงและ C2 มีค่าสัมประสิทธิ์ ทั้งสองเซลล์เป็นแหล่งค่าชาร์ต ตัวอย่างยังเปิดใช้งานป้ายค่าที่เชื่อมโยงกับฟอร์แมตต้นทาง

```php
use aspose\slides\Presentation;
use aspose\slides\ChartType;
use aspose\slides\SlideSizeScaleType;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $presentation->getSlideSize()->setSize(720, 270, SlideSizeScaleType::DoNotScale);
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 50, 20, 620, 210);
    $chart->setTitle(false);

    $chart->getAxes()->getVerticalAxis()->setNumberFormatLinkedToSource(false);
    $chart->getAxes()->getVerticalAxis()->setNumberFormat("0.00");
    $chart->getAxes()->getVerticalAxis()->setAutomaticMinValue(false);
    $chart->getAxes()->getVerticalAxis()->setMinValue(0);

    $chart->getChartData()->getSeries()->clear();
    $chart->getChartData()->getCategories()->clear();

    $workbook = $chart->getChartData()->getChartDataWorkbook();
    $workbook->clear(0);

    $categoryCell = $workbook->getCell(0, "A2", "Sample");
    $chart->getChartData()->getCategories()->add($categoryCell);

    $percentageCell = $workbook->getCell(0, "B2", 0.125);
    $percentageCell->setCustomNumberFormat("0.0000%");
    $percentageName = $workbook->getCell(0, "B1", "Conversion rate");
    $percentageSeries = $chart->getChartData()->getSeries()->add($percentageName, $chart->getType());
    $percentageSeries->getDataPoints()->addDataPointForBarSeries($percentageCell);

    $precisionCell = $workbook->getCell(0, "C2", 0.1234567);
    $precisionCell->setCustomNumberFormat("0.00000");
    $precisionName = $workbook->getCell(0, "C1", "Coefficient");
    $precisionSeries = $chart->getChartData()->getSeries()->add($precisionName, $chart->getType());
    $precisionSeries->getDataPoints()->addDataPointForBarSeries($precisionCell);

    for ($seriesIndex = 0; $seriesIndex < java_values($chart->getChartData()->getSeries()->size()); $seriesIndex++) {
        $series = $chart->getChartData()->getSeries()->get_Item($seriesIndex);
        $labelFormat = $series->getDataPoints()->get_Item(0)->getLabel()->getDataLabelFormat();
        $labelFormat->setShowValue(true);
        $labelFormat->setNumberFormatLinkedToSource(true);
    }

    $presentation->save("CustomCellFormats.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

ฟอร์แมตเซลล์ของเวิร์กบุ๊กแยกจากฟอร์แมตที่ตั้งโดยตรงบนแกนชาร์ตหรือป้ายค่าข้อมูล ในตัวอย่างนี้แต่ละป้ายแสดงค่าจากเซลล์ต้นทางเพราะ [setShowValue](https://reference.aspose.com/slides/php-java/aspose.slides/datalabelformat/setshowvalue/) ตั้งเป็น `true` และตามฟอร์แมตตัวเลขต้นทางเพราะ [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/php-java/aspose.slides/datalabelformat/setnumberformatlinkedtosource/) ตั้งเป็น `true` หลังบันทึกและเปิดงานนำเสนอใหม่ ป้ายจะแสดง `12.5000%` และ `0.12346` ตามที่แสดงด้านล่าง แกนแนวตั้งใช้ฟอร์แมตตัวเลขของตนเอง ตั้งด้วย [setNumberFormat](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setnumberformat/) เป็น `0.00` และ [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setnumberformatlinkedtosource/) ตั้งเป็น `false`

หากต้องการฟอร์แมตป้ายค่าตัวเลขอย่างอิสระ ให้ตั้งค่าสถานะเชื่อมต่อกับต้นทางเป็น `false` และกำหนดฟอร์แมตด้วย [setNumberFormat](https://reference.aspose.com/slides/php-java/aspose.slides/datalabelformat/setnumberformat/) วิธีนี้จะไม่เปลี่ยนฟอร์แมตของเซลล์เวิร์กบุ๊ก ตัวอย่างเช่น ฟอร์แมตป้ายอิสระ `0.00` จะแสดงค่าตัวแรกเป็น `0.13` ในขณะที่ B2 ยังคงแสดง `12.5000%` ดูที่ [Chart Data Labels](/slides/th/php-java/chart-data-label/#set-percentage-sign-with-chart-data-labels) สำหรับการฟอร์แมตป้ายโดยตรง

รูปภาพด้านล่างแสดงผลจากงานนำเสนอที่บันทึกแล้วและเปิดใหม่อีกครั้ง:

![แผนภูมิคอลัมน์ที่แสดงป้ายเชื่อมโยงกับต้นทางโดยแสดง 12.5000% และ 0.12346 พร้อมแกนตัวเลขที่ฟอร์แมตอิสระ.](custom-cell-formats.png)

## **ตั้งค่าเซลล์เวิร์กบุ๊กเป็นป้ายข้อมูลของชาร์ต**

คุณสามารถใช้ข้อความจากเซลล์เวิร์กบุ๊กเป็นป้ายข้อมูลของชาร์ตได้

ตัวอย่างนี้เพิ่มแผนภูมิบับเบิลที่มีข้อมูลเริ่มต้นบนสไลด์แรกของงานนำเสนอที่มีอยู่ ใช้เซลล์ A10:A12 บนเวิร์กชีต 0 สำหรับป้ายสามอันแรกของซีรีส์แรก เปิดใช้งานป้ายจากเซลล์และบันทึกงานนำเสนอที่อัปเดต

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

## **จัดการเวิร์กชีต**

เมธอด [ChartDataWorkbook::getWorksheets](https://reference.aspose.com/slides/php-java/aspose.slides/chartdataworkbook/getworksheets/) ให้เข้าถึงเวิร์กชีตในเวิร์กบุ๊กของชาร์ต ตัวอย่างนี้สร้างแผนภูมิโพล์ที่มีข้อมูลเริ่มต้นและพิมพ์ชื่อเวิร์กชีตแต่ละอันไปยังคอนโซล

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

ค่าจุดของซีรีส์สามารถจัดเก็บเป็นลิเทอรัลตัวเลขได้เช่นกัน ดูที่ [Set Series Values Using Numeric Literals](/slides/th/php-java/chart-series/#set-series-values-using-numeric-literals) สำหรับตัวอย่างครบถ้วนที่บันทึกและอ่านค่าเหล่านั้น ประเภทแหล่งข้อมูลของค่าจุดเป็นส่วนแยกจากการกำหนดค่าเวิร์กบุ๊กภายในหรือภายนอกของชาร์ต; การใช้ลิเทอรัลตัวเลขไม่ได้ทำให้เวิร์กบุ๊กที่ฝังหายไปโดยอัตโนมัติ

ตัวอย่างนี้สร้างแผนภูมิคอลัมน์ 3 มิติที่มีข้อมูลเริ่มต้นและกำหนดชื่อซีรีส์สองอันโดยใช้แหล่งข้อมูลต่างกัน ชื่อแรกใช้ลิเทอรัลสตริง; ชื่อที่สองใช้เซลล์ C1 บนเวิร์กชีต 0. การนับประเภทแหล่งข้อมูลจาก [DataSourceType](https://reference.aspose.com/slides/php-java/aspose.slides/datasourcetype/) จะเลือกแหล่งสำหรับแต่ละชื่อ ตัวอย่างบันทึกงานนำเสนอพร้อมชื่อซีรีส์ที่อัปเดต

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

## **ตรวจจับรูปแบบเวิร์กบุ๊กที่ฝังไม่รองรับ**

Aspose.Slides ไม่รองรับรูปแบบเวิร์กบุ๊กไบนารีของ Excel (.xlsb) ที่อาจฝังอยู่ในบางชาร์ต คุณสามารถใช้เมธอด `getEmbeddedWorkbookType` บน [ChartData](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/) พร้อมกับการนับประเภท [WorkbookType](https://reference.aspose.com/slides/php-java/aspose.slides/workbooktype/) เพื่อตรวจจับรูปแบบที่ไม่รองรับและข้ามชาร์ตเหล่านั้น ตัวอย่างตรวจสอบรูปร่างบนสไลด์แรกของงานนำเสนอที่มีอยู่ ข้ามรูปร่างที่ไม่ใช่ชาร์ตและพิมพ์ข้อความวินิจฉัยสำหรับแต่ละชาร์ตที่มีเวิร์กบุ๊ก .xlsb ฝังอยู่

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

        // อ่านหรือแก้ไขข้อมูลเวิร์กบุ๊กของชาร์ตที่รองรับที่นี่.
    }
} finally {
    $presentation->dispose();
}
```

## **เวิร์กบุ๊กภายนอก**

Aspose.Slides รองรับการใช้เวิร์กบุ๊กภายนอกเป็นแหล่งข้อมูลของชาร์ต

### **สร้างเวิร์กบุ๊กภายนอก**

ใช้ [readWorkbookStream](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/readworkbookstream/) และ [setExternalWorkbook](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/setexternalworkbook/) เพื่อส่งออกเวิร์กบุ๊กของชาร์ตที่ฝังเป็นไฟล์และเชื่อมโยงชาร์ตกับเวิร์กบุ๊กภายนอกนั้น

ตัวอย่างนี้สร้างแผนภูมิโพล์ที่มีข้อมูลเริ่มต้นและส่งออกเวิร์กบุ๊กของมัน ทำการเขียนไฟล์ให้เสร็จก่อนกำหนดเวิร์กบุ๊กภายนอกเป็นแหล่งข้อมูลของชาร์ต แล้วบันทึกงานนำเสนอที่เชื่อมโยง

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

โดยใช้เมธอด [setExternalWorkbook](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/setexternalworkbook/) คุณสามารถกำหนดเวิร์กบุ๊กภายนอกให้กับชาร์ตเป็นแหล่งข้อมูลได้ เมธอดนี้ยังสามารถใช้เพื่ออัปเดตเส้นทางไปยังเวิร์กบุ๊กภายนอก (หากไฟล์ถูกย้าย)

แม้ว่าคุณจะไม่สามารถแก้ไขข้อมูลในเวิร์กบุ๊กที่เก็บไว้ในตำแหน่งระยะไกลหรือทรัพยากรได้, คุณยังสามารถใช้เวิร์กบุ๊กเหล่านั้นเป็นแหล่งข้อมูลภายนอกได้ หากระบุเส้นทางสัมพัทธ์สำหรับเวิร์กบุ๊กภายนอก, ระบบจะเปลี่ยนเป็นเส้นทางเต็มโดยอัตโนมัติ

ตัวอย่างนี้ใช้เวิร์กบุ๊กภายนอกที่มีเวิร์กชีตชื่อ `Sheet1` มีชื่อซีรีส์ใน B1, ชื่อหมวดหมู่ใน A2:A4, และค่าตัวเลขใน B2:B4 ตัวอย่างสร้างแผนภูมิโพล์, เชื่อมโยงเวิร์กบุ๊ก, และใช้ [setRange](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/setrange/) เพื่อแมป A1:B4 ให้เป็นซีรีส์หนึ่งและสามหมวดหมู่ แล้วบันทึกงานนำเสนอพร้อมชาร์ตที่เชื่อมโยง

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

พารามิเตอร์ `updateChartData` ของ [setExternalWorkbook](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/setexternalworkbook/) ควบคุมว่าการโหลดเวิร์กบุ๊กหรือไม่

* เมื่อ `updateChartData` เป็น `false`, จะอัปเดตเฉพาะเส้นทางของเวิร์กบุ๊กเท่านั้น ข้อมูลชาร์ตจะไม่ถูกโหลดหรืออัปเดตจากเวิร์กบุ๊กเป้าหมาย, ดังนั้นเวิร์กบุ๊กอาจไม่พร้อมใช้งาน
* เมื่อ `updateChartData` เป็น `true`, ข้อมูลชาร์ตจะอัปเดตจากเวิร์กบุ๊กเป้าหมาย

ตัวอย่างต่อไปกำหนด URL ตัวอย่างโดยตั้งค่า `updateChartData` เป็น `false`. มันคงข้อมูลเริ่มต้นของแผนภูมิโพล์ไว้และบันทึกงานนำเสนอโดยไม่โหลดเวิร์กบุ๊กที่ไม่พร้อมใช้งาน

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

### **รับเส้นทางของเวิร์กบุ๊กแหล่งข้อมูลภายนอกของชาร์ต**

เพื่อระบุเวิร์กบุ๊กที่เชื่อมโยงกับชาร์ต, ตรวจสอบว่าชาร์ตใช้แหล่งข้อมูลภายนอกหรือไม่และดึงเส้นทางเวิร์กบุ๊กของมัน

ตัวอย่างนี้ตรวจสอบรูปร่างแรกบนสไลด์แรกของงานนำเสนอที่มีเวิร์กบุ๊กภายนอกเชื่อมโยง หากเป็นชาร์ตที่เชื่อมโยงกับเวิร์กบุ๊กภายนอก, ตัวอย่างพิมพ์ [getExternalWorkbookPath](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/getexternalworkbookpath/) ไปยังคอนโซล แล้วบันทึกสำเนาของงานนำเสนอ

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

### **แก้ไขข้อมูลชาร์ต**

คุณสามารถแก้ไขข้อมูลในเวิร์กบุ๊กภายนอกได้เช่นเดียวกับที่คุณแก้ไขเนื้อหาในเวิร์กบุ๊กภายใน เมื่อเวิร์กบุ๊กภายนอกไม่สามารถโหลดได้ จะเกิดข้อยกเว้น

ตัวอย่างนี้ใช้ชาร์ตที่เป็นรูปร่างแรกบนสไลด์แรกและเชื่อมโยงกับเวิร์กบุ๊กภายนอกที่เข้าถึงได้ ตั้งค่าค่าที่อ้างอิงเซลล์ของจุดข้อมูลแรกในซีรีส์แรกเป็น 100 และบันทึกงานนำเสนอที่อัปเดต การแก้ไขค่าของเซลล์สามารถอัปเดตไฟล์ XLSX ภายนอกที่เชื่อมโยงได้, ดังนั้นควรใช้สำเนาหากต้องการรักษาเวิร์กบุ๊กต้นฉบับ

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

### **กู้คืนเวิร์กบุ๊กจากแคชของชาร์ต**

หากชาร์ตใช้เวิร์กบุ๊กภายนอกที่หายไปหรือไม่พร้อมใช้งาน, Aspose.Slides สามารถสร้างเวิร์กบุ๊กของชาร์ตจากข้อมูลที่แคชไว้ในงานนำเสนอได้ สร้าง [LoadOptions](https://reference.aspose.com/slides/php-java/aspose.slides/loadoptions/), เรียก [LoadOptions::setSpreadsheetOptions](https://reference.aspose.com/slides/php-java/aspose.slides/loadoptions/setspreadsheetoptions/), และตั้งค่า [SpreadsheetOptions::setRecoverWorkbookFromChartCache](https://reference.aspose.com/slides/php-java/aspose.slides/spreadsheetoptions/setrecoverworkbookfromchartcache/) เป็น `true` ก่อนเปิดงานนำเสนอ

ตัวอย่าง PHP ด้านล่างกู้คืนข้อมูลเวิร์กบุ๊กสำหรับชาร์ตที่เป็นรูปร่างแรกบนสไลด์แรกและอ้างอิงเวิร์กบุ๊กภายนอกที่ไม่พร้อมใช้งาน เข้าถึงข้อมูลที่กู้คืนผ่าน [Chart::getChartData](https://reference.aspose.com/slides/php-java/aspose.slides/chart/getchartdata/) และ [ChartData::getChartDataWorkbook](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/getchartdataworkbook/):

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

        // อ่านหรือแก้ไขข้อมูลเวิร์กบุ๊กที่กู้คืนที่นี่.
    } else {
        echo "The first shape is not a chart.", PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

หากเวิร์กบุ๊กภายนอกไม่พร้อมใช้งานและการกู้คืนถูกปิด, Aspose.Slides จะโยนข้อยกเว้น เปิดใช้งานการกู้คืนเฉพาะเมื่อการใช้ข้อมูลชาร์ตที่แคชเป็นวิธีสำรองที่ยอมรับได้, เพราะแคชอาจไม่มีการเปลี่ยนแปลงที่ทำในเวิร์กบุ๊กภายนอกหลังจากที่งานนำเสนออัปเดตครั้งล่าสุด

## **FAQ**

**ฉันสามารถระบุได้หรือไม่ว่าชาร์ตเฉพาะเจาะจงเชื่อมโยงกับเวิร์กบุ๊กภายนอกหรือเวิร์กบุ๊กที่ฝังอยู่?**

ได้. ชาร์ตมี [data source type](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/getdatasourcetype/) และ [path to an external workbook](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/getexternalworkbookpath/); หากแหล่งเป็นเวิร์กบุ๊กภายนอก, คุณสามารถอ่านเส้นทางเต็มเพื่อให้แน่ใจว่าไฟล์ภายนอกกำลังถูกใช้

**รองรับเส้นทางสัมพัทธ์ไปยังเวิร์กบุ๊กภายนอกหรือไม่, และมันถูกจัดเก็บอย่างไร?**

ได้. หากคุณระบุเส้นทางสัมพัทธ์, ระบบจะเปลี่ยนเป็นเส้นทางเต็มโดยอัตโนมัติ งานนำเสนอจัดเก็บเส้นทางเต็มในไฟล์ PPTX, ดังนั้นการย้ายเวิร์กบุ๊กอาจจำเป็นต้องอัปเดตลิงก์

**ฉันสามารถใช้เวิร์กบุ๊กที่อยู่บนทรัพยากร/แชร์เครือข่ายได้หรือไม่?**

ได้, เวิร์กบุ๊กเหล่านั้นสามารถใช้เป็นแหล่งข้อมูลภายนอกได้ อย่างไรก็ตาม, การแก้ไขเวิร์กบุ๊กระยะไกลโดยตรงจาก Aspose.Slides ไม่ได้รับการสนับสนุน — สามารถใช้เป็นแหล่งข้อมูลได้เท่านั้น

**Aspose.Slides จะเขียนทับไฟล์ XLSX ภายนอกเมื่อบันทึกงานนำเสนอหรือไม่?**

งานนำเสนอจัดเก็บ [link to the external file](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/getexternalworkbookpath/). การแก้ไขข้อมูลชาร์ตที่อ้างอิงเซลล์สามารถอัปเดตไฟล์ XLSX ภายในที่เชื่อมโยงได้ ใช้สำเนาของเวิร์กบุ๊กหากต้องการให้ไฟล์ต้นฉบับไม่เปลี่ยนแปลง

**ฉันควรทำอย่างไรหากไฟล์ภายนอกถูกป้องกันด้วยรหัสผ่าน?**

Aspose.Slides ไม่รับรหัสผ่านเมื่อตั้งลิงก์ วิธีทั่วไปคือถอดการป้องกันล่วงหน้าหรือเตรียมสำเนาที่ถอดรหัสแล้ว (เช่น ใช้ [Aspose.Cells](https://reference.aspose.com/cells/java/)) แล้วลิงก์ไปยังสำเนานั้น

**หลายชาร์ตสามารถอ้างอิงเวิร์กบุ๊กภายนอกเดียวกันได้หรือไม่?**

ได้. แต่ละชาร์ตจัดเก็บลิงก์ของตนเอง หากทั้งหมดชี้ไปยังไฟล์เดียวกัน, การอัปเดตไฟล์นั้นจะสะท้อนในแต่ละชาร์ตเมื่อข้อมูลถูกโหลดครั้งต่อไป