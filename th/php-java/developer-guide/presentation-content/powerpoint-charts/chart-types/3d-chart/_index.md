---
title: ปรับแต่งแผนภูมิ 3D ในงานนำเสนอด้วย PHP
linktitle: แผนภูมิ 3D
type: docs
url: /th/php-java/3d-chart/
keywords:
- แผนภูมิ 3D
- การหมุน
- ความลึก
- PowerPoint
- งานนำเสนอ
- PHP
- Aspose.Slides
description: "สร้างแผนภูมิ 3D ในงานนำเสนอ PowerPoint ด้วย Aspose.Slides สำหรับ PHP ผ่าน Java ปรับการหมุน, อัตราส่วนความสูง, ความลึกของแผนภูมิ, และระยะห่างระหว่างชุดข้อมูลด้วยตัวอย่าง PHP."
---
## **ภาพรวม**

Aspose.Slides for PHP via Java ช่วยให้คุณปรับแต่งการมองเห็นของแผนภูมิ 3D ผ่านเมธอด [Chart::getRotation3D](https://reference.aspose.com/slides/php-java/aspose.slides/chart/#getRotation3D) นี้ บทความนี้แสดงวิธีการปรับการหมุน, อัตราส่วนความสูง, ความลึก, แกนมุมฉาก, และระยะห่างระหว่างชุดข้อมูล, แล้วบันทึกงานนำเสนอเป็นรูปแบบ PPTX

## **ตั้งค่าการหมุนและความลึกของแผนภูมิ 3D**

ตัวอย่างด้านล่างสร้าง [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) และใช้ [ShapeCollection::addChart](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/#addChart) เพื่อเพิ่มแผนภูมิกระบอง 3D แบบ stacked ลงในสไลด์แรกของมัน มันจะแทนที่ชุดข้อมูลและประเภทเริ่มต้นด้วยสองชุดที่มีค่าแต่ละค่า 3 ค่า ดัชนี worksheet `0` ระบุ worksheet ข้อมูลแรกของแผนภูมิ; แถว `0` เก็บชื่อชุดข้อมูล, และคอลัมน์ `0` เก็บป้ายชื่อประเภท

เมธอด [setRotationX](https://reference.aspose.com/slides/php-java/aspose.slides/rotation3d/#setRotationX) และ [setRotationY](https://reference.aspose.com/slides/php-java/aspose.slides/rotation3d/#setRotationY) ตั้งค่าการหมุนของแผนภูมิเป็น 40 และ 270 องศาตามลำดับ [setDepthPercents](https://reference.aspose.com/slides/php-java/aspose.slides/rotation3d/#setDepthPercents) ตั้งค่าความลึกเป็น 150% ของความกว้าง, ขณะเดียวกัน [setRightAngleAxes](https://reference.aspose.com/slides/php-java/aspose.slides/rotation3d/#setRightAngleAxes) เปิดใช้งานแกนมุมฉากแทนมุมมองตามมุมมองเชิงลึก งานนำเสนอที่ได้จะมีแผนภูมิที่เติมข้อมูลพร้อมการตั้งค่าการมองเห็น 3D นี้

```php
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::StackedColumn3D, 0, 0, 500, 500);

    $chart->getChartData()->getSeries()->clear();
    $chart->getChartData()->getCategories()->clear();

    $workbook = $chart->getChartData()->getChartDataWorkbook();
    $worksheetIndex = 0;

    $values = [[20, 50, 30], [30, 10, 60]];

    for ($categoryIndex = 0; $categoryIndex < 3; $categoryIndex++) {
        $categoryCell = $workbook->getCell($worksheetIndex, $categoryIndex + 1, 0, "Category " . ($categoryIndex + 1));
        $chart->getChartData()->getCategories()->add($categoryCell);
    }

    for ($seriesIndex = 0; $seriesIndex < 2; $seriesIndex++) {
        $seriesCell = $workbook->getCell($worksheetIndex, 0, $seriesIndex + 1, "Series " . ($seriesIndex + 1));
        $series = $chart->getChartData()->getSeries()->add($seriesCell, $chart->getType());

        for ($categoryIndex = 0; $categoryIndex < 3; $categoryIndex++) {
            $valueCell = $workbook->getCell($worksheetIndex, $categoryIndex + 1, $seriesIndex + 1, $values[$seriesIndex][$categoryIndex]);
            $series->getDataPoints()->addDataPointForBarSeries($valueCell);
        }
    }

    $chart->getRotation3D()->setRightAngleAxes(true);
    $chart->getRotation3D()->setRotationX(40);
    $chart->getRotation3D()->setRotationY(270);
    $chart->getRotation3D()->setDepthPercents(150);

    $presentation->save("Rotation3D_out.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **นำเข้าการเติมรูปภาพบนพื้นผิวของแผนภูมิ 3D**

คุณสามารถเติม [side wall](https://reference.aspose.com/slides/php-java/aspose.slides/chart/getsidewall/), [back wall](https://reference.aspose.com/slides/php-java/aspose.slides/chart/getbackwall/), และ [floor](https://reference.aspose.com/slides/php-java/aspose.slides/chart/getfloor/) ของแผนภูมิ 3D แยกกันได้ ตั้งค่าชนิดการเติมของพื้นผิวที่ [fill type](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/setfilltype/) เป็น `Picture` แล้วกำหนดภาพ ตั้งค่าโหมดการเติมรูปภาพที่ [picture fill mode](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/setpicturefillmode/) และชนิดรูปภาพของพื้นผิวที่ [picture type](https://reference.aspose.com/slides/php-java/aspose.slides/chartwall/setpicturetype/) เป็น `Stretch` เพื่อให้ภาพหนึ่งสำเนาครอบพื้นผิวทั้งหมด

บันทึก [arrow.png](arrow.png) ไว้ข้างไฟล์สคริปต์ PHP ตัวอย่างจะหมุนแผนภูมิและเพิ่มค่าสูงสุดบนแกนแนวตั้งเพื่อให้พื้นมองเห็นระหว่างคอลัมน์ จากนั้นมันจะทำสำเนาสไลด์สองครั้งและใช้ลูกศรบนพื้นผิวที่ต่างกันในแต่ละสไลด์ ทั้งสามแผนภูมิจะรักษาข้อมูล, มุมมอง, และพื้นหลังเดียวกัน

```php
use aspose\slides\ChartType;
use aspose\slides\FillType;
use aspose\slides\Images;
use aspose\slides\PictureFillMode;
use aspose\slides\PictureType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::Column3D, 20, 30, 680, 480);
    $chart->getRotation3D()->setRightAngleAxes(true);
    $chart->getRotation3D()->setRotationX(40);
    $chart->getRotation3D()->setRotationY(30);
    
    $verticalAxis = $chart->getAxes()->getVerticalAxis();
    $verticalAxis->setAutomaticMaxValue(false);
    $verticalAxis->setMaxValue(24);

    $backSlide = $presentation->getSlides()->addClone($slide);
    $floorSlide = $presentation->getSlides()->addClone($slide);
    $backChart = $backSlide->getShapes()->get_Item(0);
    $floorChart = $floorSlide->getShapes()->get_Item(0);

    $image = Images::fromFile(__DIR__ . "/arrow.png");
    try {
        $arrow = $presentation->getImages()->addImage($image);
    } finally {
        $image->dispose();
    }

    $surfaces = [$chart->getSideWall(), $backChart->getBackWall(), $floorChart->getFloor()];
    foreach ($surfaces as $surface) {
        $fill = $surface->getFormat()->getFill();
        $fill->setFillType(FillType::Picture);
        $pictureFill = $fill->getPictureFillFormat();
        $pictureFill->getPicture()->setImage($arrow);
        $pictureFill->setPictureFillMode(PictureFillMode::Stretch);
        $surface->setPictureType(PictureType::Stretch);
    }

    $presentation->save(__DIR__ . "/chart-surfaces.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Microsoft PowerPoint แสดงสไลด์สามสไลด์ดังต่อไปนี้

| ผนังด้านข้าง | ผนังด้านหลัง | พื้น |
| --- | --- | --- |
| ![ลูกศรชี้เข้าไปในแผนภูมิตามผนังด้านข้าง](side-wall.png) | ![ลูกศรชี้ไปทางขวาตลอดผนังด้านหลัง](back-wall.png) | ![ลูกศรชี้ไปทางขวาตลอดพื้นระหว่างคอลัมน์](floor.png) |

## **ปรับอัตราส่วนความสูงของแผนภูมิ 3D**

ใช้ [Rotation3D::setHeightPercents](https://reference.aspose.com/slides/php-java/aspose.slides/rotation3d/#setHeightPercents) เพื่อกำหนดความสูงของแผนภูมิ 3D เป็นเปอร์เซ็นต์ของความกว้าง วิธีนี้จะเปลี่ยนอัตราส่วนของฉาก 3D โดยไม่ต้องปรับขนาดอ็อบเจ็กต์แผนภูมิบนสไลด์

ตัวอย่างต่อไปนี้สร้างแผนภูมิ [Column3D](https://reference.aspose.com/slides/php-java/aspose.slides/charttype/) ด้วยข้อมูลเริ่มต้น: สามชุดและสี่ประเภท มันบันทึกงานนำเสนอสามไฟล์โดยอัตราส่วนความสูง 50%, 100%, และ 200% ตำแหน่ง, ความกว้าง, และความสูงของแผนภูมิก็ยังคงคงที่ ข้อมูล, การหมุน, ความลึก, ระยะห่างชุดข้อมูล, และการจัดรูปแบบเหมือนกันในทุกไฟล์; มีแค่เปอร์เซ็นต์ความสูงที่เปลี่ยน

```php
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::Column3D, 40, 30, 620, 460);
    $chart->getRotation3D()->setRotationX(20);
    $chart->getRotation3D()->setRotationY(30);
    $chart->getRotation3D()->setRightAngleAxes(true);
    $chart->getRotation3D()->setDepthPercents(100);
    $chart->getChartData()->getSeries()->get_Item(0)->getParentSeriesGroup()->setGapDepth(150);

    foreach ([50, 100, 200] as $heightPercent) {
        $chart->getRotation3D()->setHeightPercents($heightPercent);
        $presentation->save("chart_height_" . $heightPercent . ".pptx", SaveFormat::Pptx);
    }
} finally {
    $presentation->dispose();
}
```

ภาพต่อไปนี้แสดงการตั้งค่าความสูงเดียวกันในตัวอย่าง .NET ที่เทียบเท่าและถูกส่งออกโดย Microsoft PowerPoint เปอร์เซ็นต์ที่น้อยลงทำให้ฉากแบนลง, ส่วนเปอร์เซ็นต์ที่มากกว่าจะทำให้ฉากสูงขึ้นภายในอ็อบเจ็กต์แผนภูมิเดียวกัน PowerPoint อาจปรับช่วงการแบ่ง tick ของแกนและตำแหน่งป้ายกำกับให้พอดีกับฉาก

| ความสูง: 50% | ความสูง: 100% | ความสูง: 200% |
| --- | --- | --- |
| ![แผนภูมิคอลัมน์ 3D ที่ตั้งค่าความสูงเป็น 50% ของความกว้างของมัน](height_percent_50.png) | ![แผนภูมิคอลัมน์ 3D ที่ตั้งค่าความสูงเป็น 100% ของความกว้างของมัน](height_percent_100.png) | ![แผนภูมิคอลัมน์ 3D ที่ตั้งค่าความสูงเป็น 200% ของความกว้างของมัน](height_percent_200.png) |

วิธีการเหล่านี้ควบคุมแง่มุมต่างๆ ของแผนภูมิ:

| Method | Effect |
| --- | --- |
| [Rotation3D::setHeightPercents](https://reference.aspose.com/slides/php-java/aspose.slides/rotation3d/#setHeightPercents) | ความสูงของฉาก 3D เป็นเปอร์เซ็นต์ของความกว้าง |
| [Chart::setHeight](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#setHeight) | ความสูงของอ็อบเจ็กต์แผนภูมิบนสไลด์ หน่วยเป็นจุด |
| [Rotation3D::setDepthPercents](https://reference.aspose.com/slides/php-java/aspose.slides/rotation3d/#setDepthPercents) | ความลึกของฉาก 3D เป็นเปอร์เซ็นต์ของความกว้าง |
| [ChartSeriesGroup::setGapDepth](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/#setGapDepth) | ระยะห่างระหว่างชุดข้อมูลตามแกนความลึก เป็นเปอร์เซ็นต์ของความกว้างของมาร์คเกอร์ |

การตั้งค่าความสูงนี้มีผลต่อแผนภูมิคอลัมน์และแผนภูมิบาร์ 3D รวมถึงรูปแบบทรงกระบอก, หน้าโคน, และทรงพีระมิด, รวมถึงแผนภูมิ 3D แบบเส้น, พื้นที่, พาย, และพื้นผิว การเปรียบเทียบข้างต้นใช้ประเภท `Column3D` ที่ได้รับการตรวจสอบ การตั้งค่านี้ไม่ได้เปลี่ยนลักษณะของแผนภูมิ 2D `ClusteredColumn` หรือแผนภูมิ `BubbleWith3D`; ชื่อเหล่านี้เป็นสมาชิกของคลาส [ChartType](https://reference.aspose.com/slides/php-java/aspose.slides/charttype/) สำหรับการตั้งค่าลักษณะอื่นของแผนภูมิ ดูที่ [Chart Formatting](/slides/th/php-java/chart-formatting/)

## **ปรับช่องว่างระหว่างชุดข้อมูล**

ใช้ [ChartSeriesGroup::setGapDepth](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/#setGapDepth) เพื่อควบคุมระยะห่างระหว่างชุดข้อมูลตามแกนความลึกของแผนภูมิ 3D โดยแสดงเป็นเปอร์เซ็นต์ของความกว้างของมาร์คเกอร์ ใช้ค่าตั้งแต่ **0 to 500** รวม: `0` จะลบช่องว่างออก, ค่าที่มากกว่าจะเพิ่มระยะห่าง กับความลึกของแผนภูมิกำหนดไว้ การเพิ่มช่องว่างทำให้มาร์คเกอร์บางลงตามแกนความลึก

เข้าถึงกลุ่มผ่าน [ChartSeries::getParentSeriesGroup](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/#getParentSeriesGroup) การตั้งค่านี้ใช้กับทุกชุดในกลุ่ม ไม่ใช่แค่ชุดที่ใช้เข้าถึงมัน [ChartSeries::getGapDepth](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/#getGapDepth) จะคืนค่าช่องว่างความลึกและสะท้อนการตั้งค่าของกลุ่มแม่

การตั้งค่านี้มีผลต่อแผนภูมิคอลัมน์และบาร์ 3D รวมถึงรูปแบบทรงกระบอก, หน้าโคน, และทรงพีระมิด, รวมถึงแผนภูมิ 3D แบบเส้นและพื้นที่ รูปลักษณ์ขึ้นอยู่กับว่าชุดข้อมูลถูกจัดเรียงเป็นความลึก, เป็นกลุ่ม, หรือเป็นซ้อนกัน สำหรับการเปรียบเทียบช่องว่างระหว่างชุดแยกต่างหากอย่างชัดเจนให้ใช้ `ChartType::Column3D` จากคลาส [ChartType](https://reference.aspose.com/slides/php-java/aspose.slides/charttype/)

| Method | Effect |
| --- | --- |
| [ChartSeriesGroup::setGapDepth](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/#setGapDepth) | ระยะห่างระหว่างชุดข้อมูลตามแกนความลึก เป็นเปอร์เซ็นต์ของความกว้างของมาร์คเกอร์ |
| [ChartSeriesGroup::setGapWidth](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/#setGapWidth) | ระยะห่างระหว่างคลัสเตอร์ของแถบหรือคอลัมน์ที่อยู่ใกล้เคียง เป็นเปอร์เซ็นต์ของความกว้างของแถบหรือคอลัมน์ |
| [setDepthPercents](https://reference.aspose.com/slides/php-java/aspose.slides/rotation3d/#setDepthPercents) | ความลึกโดยรวมของแผนภูมิ เป็นเปอร์เซ็นต์ของความกว้างของแผนภูมิ |

ตัวอย่างต่อไปนี้เป็นตัวอย่างแบบ self‑contained ที่ใช้ข้อมูลแผนภูมิดั้งเดิมซึ่งมีสามชุดและสี่ประเภท มันบันทึกงานนำเสนอสองไฟล์โดยข้อมูล, การหมุน, ความกว้างช่องว่าง, และความลึกของแผนภูมิเหมือนกัน; มีเพียงช่องว่างความลึกที่เปลี่ยน

```php
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::Column3D, 40, 30, 620, 230);

    $chart->getRotation3D()->setRotationX(20);
    $chart->getRotation3D()->setRotationY(30);
    $chart->getRotation3D()->setDepthPercents(100);

    $series = $chart->getChartData()->getSeries()->get_Item(0);
    $group = $series->getParentSeriesGroup();
    $group->setGapWidth(150);

    foreach ([0, 500] as $gapDepth) {
        $group->setGapDepth($gapDepth);

        $fileName = "series_gap_depth_" . $gapDepth . ".pptx";
        $presentation->save($fileName, SaveFormat::Pptx);
    }
} finally {
    $presentation->dispose();
}
```

ภาพต่อไปนี้แสดงการตั้งค่าช่องว่างความลึกเดียวกันในตัวอย่าง .NET ที่เทียบเท่าและถูกส่งออกโดย Microsoft PowerPoint

| ความลึกช่องว่าง: 0% | ความลึกช่องว่าง: 500% |
| --- | --- |
| ![แผนภูมิคอลัมน์ 3D ที่ไม่มีช่องว่างระหว่างชุดข้อมูลตามแกนความลึก](gap_depth_0.png) | ![แผนภูมิคอลัมน์ 3D ที่มีช่องว่าง 500% ระหว่างชุดข้อมูลตามแกนความลึก](gap_depth_500.png) |

## **เปลี่ยนประเภทซีรี่ส์ 3D และรูปร่างของแถบ**

ในแผนภูมิโทร cylinder แบบ clustered ชุดแรกเริ่มด้วยรูปร่างแถบทรงกระบอก ตัวอย่างพิมพ์ค่าตัวเลขที่คืนจาก [ChartSeries::getType](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/gettype/) และ [ChartSeries::getBar3DShape](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/getbar3dshape/) ก่อนและหลังการเปลี่ยนแปลงแต่ละครั้ง ตารางแสดงชื่อคอนสท์แทนที่

```php
use aspose\slides\ChartShapeType;
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    
    $chart = $slide->getShapes()->addChart(ChartType::ClusteredCylinder, 20, 20, 500, 300);
    $series = $chart->getChartData()->getSeries()->get_Item(0);

    echo $series->getType(), " | ", $series->getBar3DShape(), PHP_EOL;

    $series->setType(ChartType::ClusteredCone);
    echo $series->getType(), " | ", $series->getBar3DShape(), PHP_EOL;

    $series->setBar3DShape(ChartShapeType::Box);
    echo $series->getType(), " | ", $series->getBar3DShape(), PHP_EOL;

    $presentation->save("series_shape.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

| การเปลี่ยนแปลงในชุดแรก | Series type | Bar shape |
| --- | --- | --- |
| สร้างแผนภูมิ | `ClusteredCylinder` | `Cylinder` |
| ตั้งค่าชนิดชุดเป็น `ClusteredCone` | `ClusteredCone` | `Cone` |
| ตั้งค่ารูปร่างแถบเป็น `Box` | `ClusteredColumn3D` | `Box` |

การตั้งค่ารูปร่างเป็น `Box` จะทำให้ชนิดชุดเปลี่ยนเป็น `ClusteredColumn3D` หากโค้ดของคุณทำการแยกสาขาตามชนิดชุด ให้เรียก [ChartSeries::getType](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/gettype/) หลังจากเปลี่ยนรูปร่าง ค่าที่เก็บไว้ก่อนการกำหนดค่าอาจยังคงเลือกสาขา `ClusteredCone`

![การเปรียบเทียบ PowerPoint แสดงชุดแรกเป็นทรงกระบอก, รูปกรวย, และคอลัมน์สี่เหลี่ยมจากซ้ายไปขวา](series-shapes.png)

## **คำถามที่พบบ่อย**

**ประเภทแผนภูมิใดบ้างที่รองรับโหมด 3D ใน Aspose.Slides?**

Aspose.Slides รองรับรูปแบบ 3D ของแผนภูมิคอลัมน์ ได้แก่ Column 3D, Clustered Column 3D, Stacked Column 3D, และ 100% Stacked Column 3D พร้อมกับประเภท 3D ที่เกี่ยวข้องที่เปิดให้ใช้ผ่านคลาส [ChartType](https://reference.aspose.com/slides/php-java/aspose.slides/charttype/) สำหรับรายการที่แม่นยำและเป็นปัจจุบัน ให้ตรวจสอบสมาชิกของ [ChartType](https://reference.aspose.com/slides/php-java/aspose.slides/charttype/) ในเอกสารอ้างอิง API ของเวอร์ชันที่คุณติดตั้ง

**ฉันสามารถรับภาพเรสเตอร์ของแผนภูมิ 3D เพื่อใช้ในรายงานหรือเว็บได้ไหม?**

ได้ คุณสามารถส่งออกแผนภูมิเป็นภาพด้วย [Shape::getImage](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getImage) หรือ [render the entire slide](/slides/th/php-java/convert-powerpoint-to-png/) ไปเป็นรูปแบบเช่น PNG หรือ JPEG สิ่งนี้มีประโยชน์เมื่อคุณต้องการดูตัวอย่างแบบเรสเตอร์หรือฝังแผนภูมิลงในเอกสาร, แดชบอร์ด, หรือหน้าเว็บโดยไม่ต้องพึ่งพา PowerPoint

**ประสิทธิภาพการสร้างและแสดงผลแผนภูมิ 3D ขนาดใหญ่เป็นอย่างไร?**

ประสิทธิภาพขึ้นอยู่กับปริมาณข้อมูลและความซับซ้อนของภาพ สำหรับผลลัพธ์ที่ดีที่สุด ให้ใช้เอฟเฟ็กต์ 3D อย่างจำกัด, หลีกเลี่ยงเทกเจอร์หนักบนผนังและพื้นที่พล็อต, จำกัดจำนวนจุดข้อมูลต่อชุดเมื่อเป็นไปได้, และเรนเดอร์เป็นขนาดเอาต์พุตที่เหมาะสม (ความละเอียดและมิติ) เพื่อตรงกับการแสดงผลหรือการพิมพ์ที่ต้องการ