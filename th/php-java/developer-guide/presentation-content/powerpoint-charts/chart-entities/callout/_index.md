---
title: จัดการคอลเอาท์ในแผนภูมิเสนาะการนำเสนอด้วย PHP
linktitle: คอลเอาท์
type: docs
url: /th/php-java/callout/
keywords:
- คอลเอาท์แผนภูมิ
- ใช้คอลเอาท์
- ป้ายข้อมูล
- รูปแบบป้าย
- PowerPoint
- การนำเสนอ
- PHP
- Aspose.Slides
description: "สร้างและออกแบบคอลเอาท์ใน Aspose.Slides สำหรับ PHP ผ่าน Java ด้วยตัวอย่างโค้ดสั้นๆ รองรับ PPT และ PPTX เพื่อทำงานอัตโนมัติในกระบวนการนำเสนอ"
---
## **ภาพรวม**

บทความนี้อธิบายวิธีการทำงานกับคอลเอาท์สำหรับป้ายข้อมูลแผนภูมิใน Aspose.Slides โดยแสดงวิธีใช้เมธอด `setShowLabelAsDataCallout` เพื่อแสดงป้ายเป็นคอลเอาท์ วิธีกำหนดค่าการตั้งค่าป้ายที่เกี่ยวข้องกับคอลเอาท์สำหรับแผนภูมิโดนัท และบันทึกว่าคอลเอาท์และลักษณะที่ปรากฏของมันจะถูกเก็บไว้เมื่อส่งออกงานนำเสนอเป็น PDF, HTML5, SVG, และรูปภาพแบบราสเตอร์

## **การใช้คอลเอาท์**
เมธอดใหม่ [**getShowLabelAsDataCallout()**](https://reference.aspose.com/slides/th/php-java/aspose.slides/datalabelformat/getshowlabelasdatacallout/) และ [**setShowLabelAsDataCallout()**](https://reference.aspose.com/slides/th/php-java/aspose.slides/datalabelformat/setshowlabelasdatacallout/) ได้ถูกเพิ่มเข้าไปในคลาส [DataLabelFormat](https://reference.aspose.com/slides/th/php-java/aspose.slides/datalabelformat) เมธอดเหล่านี้กำหนดว่าป้ายข้อมูลของแผนภูมิที่ระบุจะแสดงเป็นคอลเอาท์หรือเป็นป้ายข้อมูลปกติ

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Pie, 50, 50, 500, 400);
    $chart->getChartData()->getSeries()->get_Item(0)->getLabels()->getDefaultDataLabelFormat()->setShowValue(true);
    $chart->getChartData()->getSeries()->get_Item(0)->getLabels()->getDefaultDataLabelFormat()->setShowLabelAsDataCallout(true);
    $chart->getChartData()->getSeries()->get_Item(0)->getLabels()->get_Item(2)->getDataLabelFormat()->setShowLabelAsDataCallout(false);
    $pres->save("DisplayCharts.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **ตั้งค่าคอลเอาท์สำหรับแผนภูมิโดนัท**
Aspose.Slides for PHP via Java ให้การสนับสนุนการตั้งค่ารูปร่างคอลเอาท์ของป้ายข้อมูลซีรีส์สำหรับแผนภูมิโดนัท ตัวอย่างโค้ดด้านล่างเป็นตัวอย่างที่ให้ไว้

```php
  $pres = new Presentation();
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $chart = $slide->getShapes()->addChart(ChartType::Doughnut, 10, 10, 500, 500, false);
    $workBook = $chart->getChartData()->getChartDataWorkbook();
    $chart->getChartData()->getSeries()->clear();
    $chart->getChartData()->getCategories()->clear();
    $chart->setLegend(false);
    $seriesIndex = 0;
    while ($seriesIndex < 15) {
      $series = $chart->getChartData()->getSeries()->add($workBook->getCell(0, 0, $seriesIndex + 1, "SERIES " . $seriesIndex), $chart->getType());
      $series->setExplosion(0);
      $series->getParentSeriesGroup()->setDoughnutHoleSize(20);
      $series->getParentSeriesGroup()->setFirstSliceAngle(351);
      $seriesIndex++;
    } 
    $categoryIndex = 0;
    while ($categoryIndex < 15) {
      $chart->getChartData()->getCategories()->add($workBook->getCell(0, $categoryIndex + 1, 0, "CATEGORY " . $categoryIndex));
      $i = 0;
      while ($i < java_values($chart->getChartData()->getSeries()->size())) {
        $iCS = $chart->getChartData()->getSeries()->get_Item($i);
        $dataPoint = $iCS->getDataPoints()->addDataPointForDoughnutSeries($workBook->getCell(0, $categoryIndex + 1, $i + 1, 1));
        $dataPoint->getFormat()->getFill()->setFillType(FillType::Solid);
        $dataPoint->getFormat()->getLine()->getFillFormat()->setFillType(FillType::Solid);
        $dataPoint->getFormat()->getLine()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->WHITE);
        $dataPoint->getFormat()->getLine()->setWidth(1);
        $dataPoint->getFormat()->getLine()->setStyle(LineStyle->Single);
        $dataPoint->getFormat()->getLine()->setDashStyle(LineDashStyle->Solid);
        if ($i == java_values($chart->getChartData()->getSeries()->size()) - 1) {
          $lbl = $dataPoint->getLabel();
          $lbl->getTextFormat()->getTextBlockFormat()->setAutofitType(TextAutofitType::Shape);
          $lbl->getDataLabelFormat()->getTextFormat()->getPortionFormat()->setFontBold(NullableBool::True);
          $lbl->getDataLabelFormat()->getTextFormat()->getPortionFormat()->setLatinFont(new FontData("DINPro-Bold"));
          $lbl->getDataLabelFormat()->getTextFormat()->getPortionFormat()->setFontHeight(12);
          $lbl->getDataLabelFormat()->getTextFormat()->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
          $lbl->getDataLabelFormat()->getTextFormat()->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->LIGHT_GRAY);
          $lbl->getDataLabelFormat()->getFormat()->getLine()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->WHITE);
          $lbl->getDataLabelFormat()->setShowValue(false);
          $lbl->getDataLabelFormat()->setShowCategoryName(true);
          $lbl->getDataLabelFormat()->setShowSeriesName(false);
          $lbl->getDataLabelFormat()->setShowLeaderLines(true);
          $lbl->getDataLabelFormat()->setShowLabelAsDataCallout(false);
          $chart->validateChartLayout();
          $lbl->setX($lbl->getX() + 0.5);
          $lbl->setY($lbl->getY() + 0.5);
        }
        $i++;
      } 
      $categoryIndex++;
    } 
    $pres->save("chart.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **คำถามที่พบบ่อย**

**คอลเอาท์จะถูกเก็บไว้เมื่อตีรูปพรีเซนเทชันเป็น PDF, HTML5, SVG, หรือรูปภาพหรือไม่?**

ใช่ คอลเอาท์เป็นส่วนหนึ่งของการแสดงผลแผนภูมิ ดังนั้นเมื่อคุณส่งออกเป็น [PDF](/slides/th/php-java/convert-powerpoint-to-pdf/), [HTML5](/slides/th/php-java/export-to-html5/), [SVG](/slides/th/php-java/render-a-slide-as-an-svg-image/), หรือ [raster images](/slides/th/php-java/convert-powerpoint-to-png/) คอลเอาท์จะถูกเก็บไว้พร้อมกับการจัดรูปแบบของสไลด์

**ฟอนต์ที่กำหนดเองทำงานในคอลเอาท์ได้หรือไม่และรูปลักษณ์ของมันจะถูกเก็บไว้เมื่อส่งออกหรือไม่?**

ใช่ Aspose.Slides รองรับการ [embedding fonts](/slides/th/php-java/embedded-font/) ไปยังพรีเซนเทชันและควบคุมการฝังฟอนต์ระหว่างการส่งออกเช่น [PDF](/slides/th/php-java/convert-powerpoint-to-pdf/) เพื่อให้คอลเอาท์มีลักษณะเหมือนกันในระบบต่าง ๆ