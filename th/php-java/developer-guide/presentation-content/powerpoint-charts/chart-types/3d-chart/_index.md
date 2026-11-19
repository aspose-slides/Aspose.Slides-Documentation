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
description: "สร้างแผนภูมิ 3D ในงานนำเสนอ PowerPoint ด้วย Aspose.Slides สำหรับ PHP ผ่าน Java ปรับการหมุน, สัดส่วนความสูง, ความลึกของแผนภูมิ, และระยะห่างระหว่างซีเรียสด้วยตัวอย่าง PHP."
---
## **ภาพรวม**

Aspose.Slides for PHP via Java ให้คุณปรับแต่งมุมมองของแผนภูมิ 3D ผ่านเมธอด [Chart::getRotation3D](https://reference.aspose.com/slides/php-java/aspose.slides/chart/#getRotation3D) บทความนี้สาธิตวิธีการปรับการหมุน, สัดส่วนความสูง, ความลึก, แกนมุมฉาก, และการเว้นระยะห่างระหว่างซีเรียส, จากนั้นบันทึกงานนำเสนอในรูปแบบ PPTX.

## **ตั้งค่าการหมุนและความลึกของแผนภูมิ 3D**

ตัวอย่างด้านล่างสร้าง [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) และใช้ [ShapeCollection::addChart](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/#addChart) เพื่อเพิ่มแผนภูมิคอลัมน์ 3D แบบสแตคบนสไลด์แรกของมัน มันแทนที่ซีเรียสและประเภทเริ่มต้นด้วยสองซีเรียสที่แต่ละซีเรียสมีสามค่า Worksheet index `0` ระบุตารางข้อมูลแรกของแผนภูมิ; แถว `0` เก็บชื่อซีเรียส, และคอลัมน์ `0` เก็บป้ายกำหนดประเภท.

เมธอด [setRotationX](https://reference.aspose.com/slides/php-java/aspose.slides/rotation3d/#setRotationX) และ [setRotationY](https://reference.aspose.com/slides/php-java/aspose.slides/rotation3d/#setRotationY) กำหนดการหมุนของแผนภูมิเป็น 40 และ 270 องศาตามลำดับ [setDepthPercents](https://reference.aspose.com/slides/php-java/aspose.slides/rotation3d/#setDepthPercents) ตั้งค่าความลึกเป็น 150% ของความกว้าง, ขณะที่ [setRightAngleAxes](https://reference.aspose.com/slides/php-java/aspose.slides/rotation3d/#setRightAngleAxes) เปิดใช้งานแกนมุมฉากแทนการมองภาพเชิงลึก งานนำเสนอที่ได้จะมีแผนภูมิที่เติมข้อมูลพร้อมการตั้งค่ามุมมอง 3D เหล่านี้.

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

## **ปรับสัดส่วนความสูงของแผนภูมิ 3D**

ใช้ [Rotation3D::setHeightPercents](https://reference.aspose.com/slides/php-java/aspose.slides/rotation3d/#setHeightPercents) เพื่อตั้งค่าความสูงของแผนภูมิ 3D เป็นเปอร์เซ็นต์ของความกว้าง วิธีนี้เปลี่ยนสัดส่วนของฉาก 3D โดยไม่ต้องปรับขนาดวัตถุแผนภูมิบนสไลด์.

ตัวอย่างต่อไปนี้สร้างแผนภูมิ [Column3D](https://reference.aspose.com/slides/php-java/aspose.slides/charttype/) โดยใช้ข้อมูลเริ่มต้น: สามซีเรียสและสี่ประเภท มันบันทึกงานนำเสนอสามไฟล์โดยมีสัดส่วนความสูงที่ 50%, 100% และ 200% ตำแหน่ง, ความกว้างและความสูงของแผนภูมิคงที่ ข้อมูล, การหมุน, ความลึก, ระยะห่างระหว่างซีเรียสและการฟอร์แมตเหมือนกันในทุกไฟล์; มีเพียงเปอร์เซ็นต์ความสูงที่เปลี่ยน.

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

ภาพต่อไปนี้แสดงการตั้งค่าสูตรความสูงเดียวกันในตัวอย่าง .NET ที่เทียบเท่าและถูกส่งออกโดยใช้ Microsoft PowerPoint เปอร์เซ็นต์ที่น้อยกว่าจะทำให้ฉากแบนราบ, ส่วนเปอร์เซ็นต์ที่สูงกว่าจะทำให้ฉากสูงขึ้นในวัตถุแผนภูมิเดียวกัน PowerPoint อาจปรับช่วงของสเกลแกนและตำแหน่งป้ายกำกับให้เข้ากับฉากด้วย.

| ความสูง: 50% | ความสูง: 100% | ความสูง: 200% |
| --- | --- | --- |
| ![แผนภูมิคอลัมน์ 3D โดยตั้งค่าความสูงเป็น 50 เปอร์เซ็นต์ของความกว้าง](height_percent_50.png) | ![แผนภูมิคอลัมน์ 3D โดยตั้งค่าความสูงเป็น 100 เปอร์เซ็นต์ของความกว้าง](height_percent_100.png) | ![แผนภูมิคอลัมน์ 3D โดยตั้งค่าความสูงเป็น 200 เปอร์เซ็นต์ของความกว้าง](height_percent_200.png) |

เมธอดเหล่านี้ควบคุมแง่มุมต่าง ๆ ของแผนภูมิ:

| เมธอด | ผล |
| --- | --- |
| [Rotation3D::setHeightPercents](https://reference.aspose.com/slides/php-java/aspose.slides/rotation3d/#setHeightPercents) | ความสูงของฉาก 3D เป็นเปอร์เซ็นต์ของความกว้าง |
| [Chart::setHeight](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#setHeight) | ความสูงของวัตถุแผนภูมิบนสไลด์, หน่วยเป็นพ้อยท์ |
| [Rotation3D::setDepthPercents](https://reference.aspose.com/slides/php-java/aspose.slides/rotation3d/#setDepthPercents) | ความลึกของฉาก 3D เป็นเปอร์เซ็นต์ของความกว้าง |
| [ChartSeriesGroup::setGapDepth](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/#setGapDepth) | ระยะห่างระหว่างซีเรียสตามแกนความลึก, เป็นเปอร์เซ็นต์ของความกว้างมาร์กเกอร์ |

การตั้งค่าความสูงมีผลต่อแผนภูมิคอลัมน์และบาร์ 3D รวมถึงรูปแบบทรงกระบอก, รูปทรงกรวย, และรูปทรงปิรามิด, รวมถึงแผนภูมิ 3D แบบเส้น, พื้นที่, พาย, และพื้นผิว การเปรียบเทียบข้างต้นใช้ประเภท `Column3D` ที่ตรวจสอบแล้ว การตั้งค่านี้ไม่เปลี่ยนลักษณะของแผนภูมิ 2D `ClusteredColumn` หรือแผนภูมิ `BubbleWith3D`; ชื่อเหล่านี้เป็นสมาชิกของคลาส [ChartType](https://reference.aspose.com/slides/php-java/aspose.slides/charttype/) สำหรับการตั้งค่าลักษณะอื่น ๆ ของแผนภูมิเบิ่งที่ [การจัดรูปแบบแผนภูมิ](/slides/th/php-java/chart-formatting/).

## **ปรับช่องว่างระหว่างซีเรียส**

ใช้ [ChartSeriesGroup::setGapDepth](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/#setGapDepth) เพื่อควบคุมระยะห่างระหว่างชุดข้อมูลตามแกนความลึกของแผนภูมิ 3D, แสดงเป็นเปอร์เซ็นต์ของความกว้างมาร์กเกอร์ ใช้ค่าตั้งแต่ **0 ถึง 500**, รวม: `0` จะลบช่องว่าง, ขณะที่ค่าที่มากกว่าจะเพิ่มการเว้นระยะ การเพิ่มช่องว่างในกรณีที่ความลึกของแผนภูมินิ่งจะทำให้มาร์กเกอร์บางลงตามแกนความลึก.

เข้าถึงกลุ่มผ่าน [ChartSeries::getParentSeriesGroup](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/#getParentSeriesGroup) การตั้งค่านี้จะใช้กับทุกซีเรียสในกลุ่มนั้น, ไม่ใช่แค่ซีเรียสที่ใช้เข้าถึง [ChartSeries::getGapDepth](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/#getGapDepth) จะคืนค่าช่องว่างความลึกและสะท้อนการตั้งค่าของกลุ่มแม่.

การตั้งค่านี้มีผลต่อแผนภูมิคอลัมน์และบาร์ 3D รวมถึงรูปแบบทรงกระบอก, กรวย, และปิรามิด, รวมถึงแผนภูมิ 3D แบบเส้นและพื้นที่ ลักษณะการแสดงผลขึ้นอยู่กับว่าซีเรียสถูกจัดเรียงตามความลึก, คลัสเตอร์, หรือสแตก สำหรับการเปรียบเทียบช่องว่างระหว่างซีเรียสแยกกันอย่างชัดเจน ให้ใช้ `ChartType::Column3D` จากคลาส [ChartType](https://reference.aspose.com/slides/php-java/aspose.slides/charttype/).

เมธอดเหล่านี้ควบคุมแง่มุมต่าง ๆ ของแผนภูมิ:

| เมธอด | ผล |
| --- | --- |
| [ChartSeriesGroup::setGapDepth](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/#setGapDepth) | ระยะห่างระหว่างซีเรียสตามแกนความลึก, เป็นเปอร์เซ็นต์ของความกว้างมาร์กเกอร์ |
| [ChartSeriesGroup::setGapWidth](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/#setGapWidth) | ระยะห่างระหว่างกลุ่มบาร์หรือคอลัมน์ที่อยู่ติดกัน, เป็นเปอร์เซ็นต์ของความกว้างบาร์หรือคอลัมน์ |
| [setDepthPercents](https://reference.aspose.com/slides/php-java/aspose.slides/rotation3d/#setDepthPercents) | ความลึกรวมของแผนภูมิ, เป็นเปอร์เซ็นต์ของความกว้างแผนภูมิ |

ตัวอย่างต่อไปนี้ใช้ข้อมูลเริ่มต้นของแผนภูมิซึ่งมีสามซีเรียสและสี่ประเภท มันบันทึกงานนำเสนอสองไฟล์โดยมีข้อมูล, การหมุน, ความกว้างช่องว่าง, และความลึกแผนภูมิที่เหมือนกัน; มีเพียงความลึกช่องว่างที่เปลี่ยน.

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

ภาพต่อไปนี้แสดงการตั้งค่าความลึกช่องว่างเดียวกันในตัวอย่าง .NET ที่เทียบเท่าและถูกส่งออกโดยใช้ Microsoft PowerPoint.

| ความลึกช่องว่าง: 0% | ความลึกช่องว่าง: 500% |
| --- | --- |
| ![แผนภูมิคอลัมน์ 3D โดยไม่มีช่องว่างระหว่างซีเรียสตามแกนความลึก](gap_depth_0.png) | ![แผนภูคิคอลัมน์ 3D โดยมีช่องว่าง 500 เปอร์เซ็นต์ระหว่างซีเรียสตามแกนความลึก](gap_depth_500.png) |

## **เปลี่ยนประเภทซีเรียส 3D และรูปทรงบาร์**

ในแผนภูมิกระบอกสูบที่จัดกลุ่ม, ซีเรียสแรกเริ่มต้นด้วยรูปทรงบาร์ทรงกระบอก ตัวอย่างพิมพ์ค่าจำนวนเต็มที่คืนจาก [ChartSeries::getType](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/gettype/) และ [ChartSeries::getBar3DShape](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/getbar3dshape/) ก่อนและหลังการเปลี่ยนแปลงแต่ละครั้ง ตารางแสดงชื่อคอนสแตนท์ที่สอดคล้องกัน.

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

| การเปลี่ยนแปลงซีเรียสแรก | ประเภทซีเรียส | รูปร่างบาร์ |
| --- | --- | --- |
| สร้างแผนภูมิ | `ClusteredCylinder` | `Cylinder` |
| ตั้งค่าชนิดซีเรียสเป็น `ClusteredCone` | `ClusteredCone` | `Cone` |
| ตั้งค่ารูปร่างบาร์เป็น `Box` | `ClusteredColumn3D` | `Box` |

การตั้งค่ารูปร่างเป็น `Box` จะทำให้ประเภทซีเรียสเปลี่ยนเป็น `ClusteredColumn3D` ด้วย หากโค้ดของคุณใช้เงื่อนไขตามประเภทซีเรียส, ให้เรียก [ChartSeries::getType](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/gettype/) หลังจากเปลี่ยนรูปร่าง ค่าที่เก็บไว้ก่อนการกำหนดจะยังคงเลือกเงื่อนไข `ClusteredCone` อยู่.

![การเปรียบเทียบ PowerPoint แสดงซีเรียสแรกเป็นกระบอก, กรรภ, และคอลัมน์สี่เหลี่ยมจากซ้ายไปขวา](series-shapes.png)

## **คำถามที่พบบ่อย**

**แผนภูมิประเภทใดสนับสนุนโหมด 3D ใน Aspose.Slides?**

Aspose.Slides สนับสนุนรูปแบบ 3D ของแผนภูมิคอลัมน์ รวมถึง Column 3D, Clustered Column 3D, Stacked Column 3D, และ 100% Stacked Column 3D พร้อมกับประเภท 3D ที่เกี่ยวข้องที่เปิดให้เข้าถึงผ่านคลาส [ChartType](https://reference.aspose.com/slides/php-java/aspose.slides/charttype/). สำหรับรายการที่แม่นยำและเป็นปัจจุบัน ตรวจสอบสมาชิกของ [ChartType](https://reference.aspose.com/slides/php-java/aspose.slides/charttype/) ในเอกสาร API ของเวอร์ชันที่คุณติดตั้ง.

**ฉันสามารถรับภาพเรสเตอร์ของแผนภูมิ 3D สำหรับรายงานหรือเว็บได้หรือไม่?**

ได้ คุณสามารถส่งออกแผนภูมิเป็นภาพโดยใช้ [Shape::getImage](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getImage) หรือ [render the entire slide](/slides/th/php-java/convert-powerpoint-to-png/) ไปเป็นรูปแบบเช่น PNG หรือ JPEG วิธีนี้เป็นประโยชน์เมื่อคุณต้องการพรีวิวในรูปแบบเรสเตอร์หรือฝังแผนภูมิลงในเอกสาร, แดชบอร์ด, หรือหน้าเว็บโดยไม่ต้องอาศัย PowerPoint.

**การสร้างและเรนเดอร์แผนภูมิ 3D ขนาดใหญ่มีประสิทธิภาพแค่ไหน?**

ประสิทธิภาพขึ้นอยู่กับปริมาณข้อมูลและความซับซ้อนของภาพ เพื่อให้ได้ผลดีที่สุด ควรลดเอฟเฟกต์ 3D ให้น้อยที่สุด, หลีกเลี่ยงการใช้เท็กซ์เจอร์หนักบนผนังและพื้นที่พล็อต, จำกัดจำนวนจุดข้อมูลต่อซีเรียสเมื่อตามความเป็นไปได้, และเรนเดอร์เป็นขนาดเอาต์พุตที่เหมาะสม (ความละเอียดและมิติ) เพื่อให้ตรงกับการแสดงผลหรือการพิมพ์ที่ต้องการ.