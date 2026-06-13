---
title: ปรับแต่งจุดข้อมูลในแผนภูมิ Treemap และ Sunburst ด้วย PHP
linktitle: จุดข้อมูลในแผนภูมิ Treemap และ Sunburst
type: docs
url: /th/php-java/data-points-of-treemap-and-sunburst-chart/
weight: 40
keywords:
- แผนภูมิ treemap
- แผนภูมิ sunburst
- จุดข้อมูล
- สีป้าย
- สีสาขา
- PowerPoint
- การนำเสนอ
- PHP
- Aspose.Slides
description: "เรียนรู้วิธีจัดการจุดข้อมูลในแผนภูมิ treemap และ sunburst ด้วย Aspose.Slides สำหรับ PHP ผ่าน Java ซึ่งรองรับรูปแบบไฟล์ PowerPoint"
---
## **บทนำ**

นอกจากประเภทของแผนภูมิ PowerPoint อื่น ๆ แล้ว ยังมีประเภท “แบบลำดับชั้น” สองประเภท คือแผนภูมิ **Treemap** และ **Sunburst** (ซึ่งยังเรียกอีกชื่อว่า Sunburst Graph, Sunburst Diagram, Radial Chart, Radial Graph หรือ Multi Level Pie Chart) แผนภูมิเหล่านี้แสดงข้อมูลแบบลำดับชั้นที่จัดเป็นต้นไม้ ตั้งแต่ใบไม้จนถึงยอดกิ่ง ใบไม้ถูกกำหนดโดยจุดข้อมูลของซีรีส์ และระดับการจัดกลุ่มที่ซ้อนกันต่อมาจะกำหนดโดยหมวดหมู่ที่สอดคล้องกัน Aspose.Slides for PHP via Java ให้ความสามารถในการจัดรูปแบบจุดข้อมูลของแผนภูมิ Sunburst และ Treemap .

ด้านล่างเป็นแผนภูมิ Sunburst ซึ่งข้อมูลในคอลัมน์ Series1 กำหนดโหนดใบไม้ ส่วนคอลัมน์อื่น ๆ กำหนดจุดข้อมูลแบบลำดับชั้น:

![todo:image_alt_text](https://lh6.googleusercontent.com/TSSU5O7SLOi5NZD9JaubhgGU1QU5tYKc23RQX_cal3tlz5TpOvsgUFLV_rHvruwN06ft1XYgsLhbeEDXzVqdAybPIbpfGy-lwoQf_ydxDwcjAeZHWfw61c4koXezAAlEeCA7x6BZ)

เริ่มต้นด้วยการเพิ่มแผนภูมิ Sunburst ใหม่ลงในงานนำเสนอ:

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Sunburst, 100, 100, 450, 400);
    # ...
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

{{% alert color="primary" title="ดูเพิ่มเติม" %}} 
- [**สร้างหรืออัปเดตแผนภูมิการนำเสนอ PowerPoint ใน PHP**](/slides/th/php-java/create-chart/)
{{% /alert %}}

หากต้องการจัดรูปแบบจุดข้อมูลของแผนภูมิ เราควรใช้สิ่งต่อไปนี้:

[**ChartDataPointLevelsManager**](https://reference.aspose.com/slides/th/php-java/aspose.slides/chartdatapointlevelsmanager/), [**ChartDataPointLevel**](https://reference.aspose.com/slides/th/php-java/aspose.slides/chartdatapointlevel/) classes และเมธอด [**ChartDataPoint::getDataPointLevels**](https://reference.aspose.com/slides/th/php-java/aspose.slides/chartdatapoint/#getDataPointLevels) ให้การเข้าถึงการจัดรูปแบบจุดข้อมูลของแผนภูมิ Treemap และ Sunburst. [**ChartDataPointLevelsManager**](https://reference.aspose.com/slides/th/php-java/aspose.slides/chartdatapointlevelsmanager/) ใช้สำหรับเข้าถึงหมวดหมู่หลายระดับ – มันเป็นคอนเทนเนอร์ของวัตถุ [**ChartDataPointLevel**](https://reference.aspose.com/slides/th/php-java/aspose.slides/chartdatapointlevel/) objects. โดยพื้นฐานแล้วมันเป็น wrapper สำหรับ [**ChartCategoryLevelsManager**](https://reference.aspose.com/slides/th/php-java/aspose.slides/chartcategorylevelsmanager/) พร้อมคุณสมบัติที่เพิ่มขึ้นเฉพาะสำหรับจุดข้อมูล. คลาส [**ChartDataPointLevel**](https://reference.aspose.com/slides/th/php-java/aspose.slides/chartdatapointlevel/) มีสองเมธอด: [**getFormat**](https://reference.aspose.com/slides/th/php-java/aspose.slides/chartdatapointlevel/#getFormat) และ [**getDataLabel**](https://reference.aspose.com/slides/th/php-java/aspose.slides/chartdatapointlevel/#getLabel) ซึ่งให้การเข้าถึงการตั้งค่าที่สอดคล้องกัน.

## **แสดงค่าจุดข้อมูล**

แสดงค่าของจุดข้อมูล "Leaf 4":

```php
  $dataPoints = $chart->getChartData()->getSeries()->get_Item(0)->getDataPoints();
  $dataPoints->get_Item(3)->getDataPointLevels()->get_Item(0)->getLabel()->getDataLabelFormat()->setShowValue(true);

```

![todo:image_alt_text](https://lh6.googleusercontent.com/bKHMf5Bj37ZkMwUE1OfXjw7_CRmDhafhQOUuVWDmitwbtdkwD68ibWluY6Q1HQz_z2Q-BR_SBrBPZ_gID5bGH0PUqI5w37S22RT-ZZal6k7qIDstKntYi5QXS8z-SgpnsI78WGiu)

## **ตั้งป้ายและสีของจุดข้อมูล**

ตั้งป้ายข้อมูลของ "Branch 1" ให้แสดงชื่อซีรีส์ ("Series1") แทนชื่อหมวดหมู่ จากนั้นตั้งค่าสีข้อความเป็นสีเหลือง:

```php
  $branch1Label = $dataPoints->get_Item(0)->getDataPointLevels()->get_Item(0)->getLabel();
  $branch1Label->getDataLabelFormat()->setShowCategoryName(false);
  $branch1Label->getDataLabelFormat()->setShowSeriesName(true);
  $branch1Label->getDataLabelFormat()->getTextFormat()->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
  $branch1Label->getDataLabelFormat()->getTextFormat()->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->YELLOW);

```

![todo:image_alt_text](https://lh6.googleusercontent.com/I9g0kewJnxkhUVlfSWRN39Ng-wzjWyRwF3yTbOD9HhLTLBt_sMJiEfDe7vOfqRNx89o9AVZsYTW3Vv_TIuj4EgM4_UEEi7zQ3jdvaO8FoG2JcsOqNRgbiE5HQZNz8xx_q9qdj8JQ)

## **ตั้งสีสาขาของจุดข้อมูล**

เปลี่ยนสีของสาขา "Steam 4":

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Sunburst, 100, 100, 450, 400);
    $dataPoints = $chart->getChartData()->getSeries()->get_Item(0)->getDataPoints();
    $stem4branch = $dataPoints->get_Item(9)->getDataPointLevels()->get_Item(1);
    $stem4branch->getFormat()->getFill()->setFillType(FillType::Solid);
    $stem4branch->getFormat()->getFill()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
    $pres->save("pres.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

![todo:image_alt_text](https://lh5.googleusercontent.com/Zll4cpQ5tTDdgwmJ4yuupolfGaANR8SWWTU3XaJav_ZVXVstV1pI1z1OFH-gov6FxPoDz1cxmMyrgjsdYGS24PlhaYa2daKzlNuL1a0xYcqEiyyO23AE6JMOLavWpvqA6SzOCA6_)

## **คำถามที่พบบ่อย**

**ฉันสามารถเปลี่ยนลำดับ (การจัดเรียง) ของส่วนใน Sunburst/Treemap ได้หรือไม่?**

ไม่ PowerPoint จะจัดเรียงส่วนโดยอัตโนมัติ (โดยทั่วไปเรียงจากค่ามากไปน้อยตามเข็มนาฬิกา) Aspose.Slides ทำตามพฤติกรรมนี้เช่นกัน: คุณไม่สามารถเปลี่ยนลำดับโดยตรงได้; ต้องทำโดยการเตรียมข้อมูลล่วงหน้า

**ธีมของงานนำเสนอมีผลต่อสีของส่วนและป้ายอย่างไร?**

สีของแผนภูมิจะสืบทอดจาก [ธีม/พาเลต](/slides/th/php-java/presentation-theme/) ของงานนำเสนอ ถ้าคุณไม่ได้ตั้งค่าเติมสี/ฟอนต์ด้วยตนเอง เพื่อให้ผลลัพธ์สม่ำเสมอ ควรกำหนดการเติมสีทึบและการจัดรูปแบบข้อความที่ระดับที่ต้องการ

**การส่งออกเป็น PDF/PNG จะคงสีสาขาที่กำหนดเองและการตั้งค่าป้ายไว้หรือไม่?**

ใช่ เมื่อส่งออกงานนำเสนอ การตั้งค่าของแผนภูมิ (การเติมสี, ป้าย) จะถูกคงไว้ในรูปแบบผลลัพธ์ เนื่องจาก Aspose.Slides จะเรนเดอร์โดยใช้การจัดรูปแบบของแผนภูมิ

**ฉันสามารถคำนวณพิกัดจริงของป้าย/องค์ประกอบเพื่อวางโอเวอร์เลย์แบบกำหนดเองบนแผนภูมิได้หรือไม่?**

ได้ หลังจากการจัดวางแผนภูมิได้รับการตรวจสอบแล้ว พิกัด *x* และ *y* จริงจะพร้อมใช้งานสำหรับองค์ประกอบ (เช่น [DataLabel](https://reference.aspose.com/slides/th/php-java/aspose.slides/datalabel/)) ซึ่งช่วยในการวางตำแหน่งโอเวอร์เลย์อย่างแม่นยำ