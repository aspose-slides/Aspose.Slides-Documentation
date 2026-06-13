---
title: เพิ่มประสิทธิภาพการคำนวณแผนภูมิสำหรับการนำเสนอใน PHP
linktitle: การคำนวณแผนภูมิ
type: docs
weight: 50
url: /th/php-java/chart-calculations/
keywords:
- การคำนวณแผนภูมิ
- องค์ประกอบแผนภูมิ
- ตำแหน่งองค์ประกอบ
- ตำแหน่งจริง
- องค์ประกอบลูก
- องค์ประกอบแม่
- ค่าของแผนภูมิ
- ค่าจริง
- PowerPoint
- งานนำเสนอ
- PHP
- Aspose.Slides
description: "ทำความเข้าใจการคำนวณแผนภูมิ, การอัปเดตข้อมูล, และการควบคุมความแม่นยำใน Aspose.Slides สำหรับ PHP ผ่าน Java สำหรับ PPT และ PPTX พร้อมตัวอย่างโค้ดที่ใช้งานได้จริง."
---
## **ภาพรวม**

Aspose.Slides มี API สำหรับทำงานกับการคำนวณแผนภูมิและข้อมูลการจัดวางในงานนำเสนอ บทความนี้แสดงวิธีดึงค่าจริงขององค์ประกอบแผนภูมิ รวมถึงตำแหน่งและขนาดจริงขององค์ประกอบและค่าจริงของแกนแผนภูมิ นอกจากนี้ยังอธิบายว่าค่าเหล่านี้จะถูกเติมเต็มหลังจากการตรวจสอบการจัดวางแผนภูมิ

นอกจากนี้ บทความยังสาธิตวิธีรับตำแหน่งจริงขององค์ประกอบแผนภูมิแม่และวิธีซ่อนส่วนประกอบของแผนภูมิเช่น ชื่อเรื่อง แกน ตำนาน และเส้นตาราง ตัวอย่างเหล่านี้ช่วยให้คุณตรวจสอบข้อมูลการจัดวางแผนภูมิและควบคุมการมองเห็นขององค์ประกอบแผนภูมิใน PowerPoint อย่างโปรแกรมได้

## **คำนวณค่าจริงขององค์ประกอบแผนภูมิ**
Aspose.Slides for PHP via Java มี API ง่ายๆ สำหรับรับคุณสมบัติเหล่านี้ วิธีของคลาส [Axis](https://reference.aspose.com/slides/th/php-java/aspose.slides/axis/) ให้ข้อมูลเกี่ยวกับตำแหน่งจริงขององค์ประกอบแกนแผนภูมิ ([getActualMaxValue](https://reference.aspose.com/slides/th/php-java/aspose.slides/axis/getactualmaxvalue/), [getActualMinValue](https://reference.aspose.com/slides/th/php-java/aspose.slides/axis/getactualminvalue/), [getActualMajorUnit](https://reference.aspose.com/slides/th/php-java/aspose.slides/axis/getactualmajorunit/), [getActualMinorUnit](https://reference.aspose.com/slides/th/php-java/aspose.slides/axis/getactualminorunit/), [getActualMajorUnitScale](https://reference.aspose.com/slides/th/php-java/aspose.slides/axis/getactualmajorunitscale/), [getActualMinorUnitScale](https://reference.aspose.com/slides/th/php-java/aspose.slides/axis/getactualminorunitscale/)) จำเป็นต้องเรียกเมธอด [Chart.validateChartLayout](https://reference.aspose.com/slides/th/php-java/aspose.slides/chart/validatechartlayout/) ก่อนเพื่อเติมคุณสมบัติกับค่าจริง

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Area, 100, 100, 500, 350);
    $chart->validateChartLayout();
    $maxValue = $chart->getAxes()->getVerticalAxis()->getActualMaxValue();
    $minValue = $chart->getAxes()->getVerticalAxis()->getActualMinValue();
    $majorUnit = $chart->getAxes()->getHorizontalAxis()->getActualMajorUnit();
    $minorUnit = $chart->getAxes()->getHorizontalAxis()->getActualMinorUnit();
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **คำนวณตำแหน่งจริงขององค์ประกอบแผนภูมิแม่**
Aspose.Slides for PHP via Java มี API ง่ายๆ สำหรับรับคุณสมบัติเหล่านี้ วิธีของคลาส `ActualLayout` ให้ข้อมูลเกี่ยวกับตำแหน่งจริงขององค์ประกอบแผนภูมิแม่ (`getActualX`, `getActualY`, `getActualWidth`, `getActualHeight`) จำเป็นต้องเรียกเมธอด [Chart.validateChartLayout](https://reference.aspose.com/slides/th/php-java/aspose.slides/chart/validatechartlayout/) ก่อนเพื่อเติมคุณสมบัติกับค่าจริง

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::ClusteredColumn, 100, 100, 500, 350);
    $chart->validateChartLayout();
    $x = $chart->getPlotArea()->getActualX();
    $y = $chart->getPlotArea()->getActualY();
    $w = $chart->getPlotArea()->getActualWidth();
    $h = $chart->getPlotArea()->getActualHeight();
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **ซ่อนองค์ประกอบแผนภูมิ**
หัวข้อนี้ช่วยให้คุณเข้าใจวิธีซ่อนข้อมูลจากแผนภูมิ ด้วย Aspose.Slides for PHP via Java คุณสามารถซ่อน **Title**, **Vertical Axis**, **Horizontal Axis** และ **Grid Lines** จากแผนภูมิ ตัวอย่างโค้ดด้านล่างแสดงวิธีใช้คุณสมบัติเหล่านี้

```php
  $pres = new Presentation();
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $chart = $slide->getShapes()->addChart(ChartType::LineWithMarkers, 140, 118, 320, 370);
    # ซ่อนชื่อแผนภูมิ
    $chart->setTitle(false);
    # /ซ่อนแกนค่าต่างๆ
    $chart->getAxes()->getVerticalAxis()->setVisible(false);
    # การมองเห็นแกนประเภท
    $chart->getAxes()->getHorizontalAxis()->setVisible(false);
    # ซ่อนคำอธิบาย
    $chart->setLegend(false);
    # ซ่อนเส้นตารางหลัก
    $chart->getAxes()->getHorizontalAxis()->getMajorGridLinesFormat()->getLine()->getFillFormat()->setFillType(FillType::NoFill);
    for($i = 0; $i < java_values($chart->getChartData()->getSeries()->size()) ; $i++) {
      $chart->getChartData()->getSeries()->removeAt($i);
    }
    $series = $chart->getChartData()->getSeries()->get_Item(0);
    $series->getMarker()->setSymbol(MarkerStyleType::Circle);
    $series->getLabels()->getDefaultDataLabelFormat()->setShowValue(true);
    $series->getLabels()->getDefaultDataLabelFormat()->setPosition(LegendDataLabelPosition->Top);
    $series->getMarker()->setSize(15);
    # กำหนดสีเส้นชุดข้อมูล
    $series->getFormat()->getLine()->getFillFormat()->setFillType(FillType::Solid);
    $series->getFormat()->getLine()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->MAGENTA);
    $series->getFormat()->getLine()->setDashStyle(LineDashStyle->Solid);
    $pres->save("HideInformationFromChart.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **คำถามที่พบบ่อย**

**แหล่งข้อมูลจากไฟล์ Excel ภายนอกทำงานได้หรือไม่ และมีผลต่อการคำนวณซ้ำอย่างไร?**

ได้ ไฟล์แผนภูมิสามารถอ้างอิงเวิร์กบุ๊กภายนอกได้: เมื่อคุณเชื่อมต่อหรือรีเฟรชแหล่งข้อมูลภายนอก สูตรและค่า จะถูกดึงจากเวิร์กบุ๊กนั้น และแผนภูมิจะแสดงการอัปเดตระหว่างการเปิด/แก้ไข API ให้คุณ [specify the external workbook](https://reference.aspose.com/slides/th/php-java/aspose.slides/chartdata/setexternalworkbook/) path และจัดการข้อมูลที่เชื่อมโยง

**ฉันสามารถคำนวณและแสดงเส้นแนวโน้มโดยไม่ต้องเขียนการถดถอยเองได้หรือไม่?**

ได้ [Trendlines](/slides/th/php-java/trend-line/) (เช่น เส้นตรง, เส้นเอ็กซ์โพเนนเชียล ฯลฯ) ถูกเพิ่มและอัปเดตโดย Aspose.Slides; พารามิเตอร์ของเส้นแนวโน้มจะคำนวณใหม่จากข้อมูลซีรีส์โดยอัตโนมัติ ดังนั้นคุณไม่จำเป็นต้องเขียนการคำนวณของคุณเอง

**หากงานนำเสนอมีหลายแผนภูมิกับลิงก์ภายนอก ฉันสามารถควบคุมว่าเวิร์กบุ๊กใดจะใช้สำหรับค่าที่คำนวณได้หรือไม่?**

ได้ แต่ละแผนภูมิสามารถชี้ไปยัง [external workbook](https://reference.aspose.com/slides/th/php-java/aspose.slides/chartdata/setexternalworkbook/) ของตนเอง หรือคุณสามารถสร้าง/แทนที่เวิร์กบุ๊กภายนอกสำหรับแต่ละแผนภูมิได้โดยอิสระจากกัน

---
title: เพิ่มประสิทธิภาพการคำนวณแผนภูมิสำหรับการนำเสนอใน PHP
linktitle: การคำนวณแผนภูมิ
type: docs
weight: 50
url: /th/php-java/chart-calculations/
keywords:
- การคำนวณแผนภูมิ
- องค์ประกอบแผนภูมิ
- ตำแหน่งองค์ประกอบ
- ตำแหน่งจริง
- องค์ประกอบลูก
- องค์ประกอบแม่
- ค่าของแผนภูมิ
- ค่าจริง
- PowerPoint
- งานนำเสนอ
- PHP
- Aspose.Slides
description: "ทำความเข้าใจการคำนวณแผนภูมิ, การอัปเดตข้อมูล, และการควบคุมความแม่นยำใน Aspose.Slides สำหรับ PHP ผ่าน Java สำหรับ PPT และ PPTX พร้อมตัวอย่างโค้ดที่ใช้งานได้จริง."
---