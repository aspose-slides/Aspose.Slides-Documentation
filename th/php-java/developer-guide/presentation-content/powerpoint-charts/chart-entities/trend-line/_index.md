---
title: เพิ่มเส้นแนวโน้มในแผนภูมิการนำเสนอด้วย PHP
linktitle: เส้นแนวโน้ม
type: docs
url: /th/php-java/trend-line/
keywords:
- แผนภูมิ
- เส้นแนวโน้ม
- เส้นแนวโน้มแบบเอ็กซ์โปเนนเชียล
- เส้นแนวโน้มเชิงเส้น
- เส้นแนวโน้มลอการิทึม
- เส้นแนวโน้มค่าเฉลี่ยเคลื่อนที่
- เส้นแนวโน้มแบบพหุนาม
- เส้นแนวโน้มกำลัง
- เส้นแนวโน้มกำหนดเอง
- PowerPoint
- การนำเสนอ
- PHP
- Aspose.Slides
description: "เพิ่มและปรับแต่งเส้นแนวโน้มในแผนภูมิ PowerPoint ด้วย Aspose.Slides for PHP via Java อย่างรวดเร็ว — คำแนะนำที่เป็นประโยชน์เพื่อดึงดูดผู้ชมของคุณ."
---
## **ภาพรวม**

บทความนี้อธิบายว่าจะแทรกเส้นแนวโน้มลงในแผนภูมิการนำเสนอโดยใช้ Aspose.Slides อย่างไร แสดงวิธีสร้างแผนภูมิ, เพิ่มเส้นแนวโน้มให้กับชุดข้อมูลของแผนภูมิ, และทำงานกับประเภทเส้นแนวโน้มหลายประเภท รวมถึงเส้นแนวโน้มแบบเอ็กซ์โปเนนเชียล, เส้นตรง, ลอการิทึม, ค่าเฉลี่ยเคลื่อนที่, พหุนาม, และกำลัง

นอกจากนี้ยังอธิบายวิธีเพิ่มเส้นกำหนดเองลงในแผนภูมิโดยการแทรกรูปร่างเส้น และมีส่วน FAQ สั้นเกี่ยวกับค่าการฉายเส้นแนวโน้มแบบต่อหน้าและถอยหลัง และว่าการส่งออกเป็น PDF หรือ SVG หรือการเรนเดอร์แผนภูมิเป็นภาพ จะคงเส้นแนวโน้มไว้หรือไม่

## **เพิ่มเส้นแนวโน้ม**
Aspose.Slides for PHP via Java มี API ที่ง่ายสำหรับจัดการเส้นแนวโน้มของแผนภูมิต่าง ๆ:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/php-java/aspose.slides/Presentation).
2. รับอ้างอิงสไลด์โดยใช้ดัชนีของมัน.
3. เพิ่มแผนภูมิที่มีข้อมูลเริ่มต้นพร้อมกับประเภทที่ต้องการ (ตัวอย่างนี้ใช้ ChartType::ClusteredColumn).
4. เพิ่มเส้นแนวโน้มแบบเอ็กซ์โปเนนเชียลสำหรับชุดข้อมูลแผนภูมิที่ 1.
5. เพิ่มเส้นแนวโน้มเชิงเส้นสำหรับชุดข้อมูลแผนภูมิที่ 1.
6. เพิ่มเส้นแนวโน้มแบบลอการิทึมสำหรับชุดข้อมูลแผนภูมิที่ 2.
7. เพิ่มเส้นแนวโน้มค่าเฉลี่ยเคลื่อนที่สำหรับชุดข้อมูลแผนภูมิที่ 2.
8. เพิ่มเส้นแนวโน้มแบบพหุนามสำหรับชุดข้อมูลแผนภูมิที่ 3.
9. เพิ่มเส้นแนวโน้มแบบกำลังสำหรับชุดข้อมูลแผนภูมิที่ 3.
10. บันทึกการนำเสนอที่แก้ไขเป็นไฟล์ PPTX.

โค้ดต่อไปนี้ใช้เพื่อสร้างแผนภูมิพร้อมเส้นแนวโน้ม.

```php
  # สร้างอินสแตนซ์ของคลาส Presentation
  $pres = new Presentation();
  try {
    # สร้างแผนภูมิประเภทคอลัมน์กลุ่ม
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::ClusteredColumn, 20, 20, 500, 400);
    # เพิ่มเส้นแนวโน้มแบบเอ็กซ์โปเนนเชียลสำหรับชุดข้อมูลแผนภูมิที่ 1
    $tredLinep = $chart->getChartData()->getSeries()->get_Item(0)->getTrendLines()->add(TrendlineType::Exponential);
    $tredLinep->setDisplayEquation(false);
    $tredLinep->setDisplayRSquaredValue(false);
    # เพิ่มเส้นแนวโน้มเชิงเส้นสำหรับชุดข้อมูลแผนภูมิที่ 1
    $tredLineLin = $chart->getChartData()->getSeries()->get_Item(0)->getTrendLines()->add(TrendlineType::Linear);
    $tredLineLin->setTrendlineType(TrendlineType::Linear);
    $tredLineLin->getFormat()->getLine()->getFillFormat()->setFillType(FillType::Solid);
    $tredLineLin->getFormat()->getLine()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
    # เพิ่มเส้นแนวโน้มแบบลอการิทึมสำหรับชุดข้อมูลแผนภูมิที่ 2
    $tredLineLog = $chart->getChartData()->getSeries()->get_Item(1)->getTrendLines()->add(TrendlineType::Logarithmic);
    $tredLineLog->setTrendlineType(TrendlineType::Logarithmic);
    $tredLineLog->addTextFrameForOverriding("New log trend line");
    # เพิ่มเส้นแนวโน้มค่าเฉลี่ยเคลื่อนที่สำหรับชุดข้อมูลแผนภูมิที่ 2
    $tredLineMovAvg = $chart->getChartData()->getSeries()->get_Item(1)->getTrendLines()->add(TrendlineType::MovingAverage);
    $tredLineMovAvg->setTrendlineType(TrendlineType::MovingAverage);
    $tredLineMovAvg->setPeriod(3);
    $tredLineMovAvg->setTrendlineName("New TrendLine Name");
    # เพิ่มเส้นแนวโน้มแบบพหุนามสำหรับชุดข้อมูลแผนภูมิที่ 3
    $tredLinePol = $chart->getChartData()->getSeries()->get_Item(2)->getTrendLines()->add(TrendlineType::Polynomial);
    $tredLinePol->setTrendlineType(TrendlineType::Polynomial);
    $tredLinePol->setForward(1);
    $tredLinePol->setOrder(3);
    # เพิ่มเส้นแนวโน้มแบบกำลังสำหรับชุดข้อมูลแผนภูมิที่ 3
    $tredLinePower = $chart->getChartData()->getSeries()->get_Item(1)->getTrendLines()->add(TrendlineType::Power);
    $tredLinePower->setTrendlineType(TrendlineType::Power);
    $tredLinePower->setBackward(1);
    # บันทึกการนำเสนอ
    $pres->save("ChartTrendLines_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **เพิ่มเส้นกำหนดเอง**
Aspose.Slides for PHP via Java มี API ที่ง่ายสำหรับเพิ่มเส้นกำหนดเองในแผนภูมิ เพื่อเพิ่มเส้นธรรมดาในสไลด์ที่เลือกของการนำเสนอ โปรดทำตามขั้นตอนด้านล่าง:

- สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/php-java/aspose.slides/Presentation)
- รับอ้างอิงของสไลด์โดยใช้ Index ของมัน
- สร้างแผนภูมิใหม่โดยใช้เมธอด AddChart ที่เปิดให้ใช้งานจากอ็อบเจกต์ Shapes
- เพิ่ม AutoShape ประเภท Line โดยใช้เมธอด AddAutoShape ที่เปิดให้ใช้งานจากอ็อบเจกต์ Shapes
- ตั้งค่า Color ของเส้นรูปร่าง.
- บันทึกการนำเสนอที่แก้ไขเป็นไฟล์ PPTX

โค้ดต่อไปนี้ใช้เพื่อสร้างแผนภูมิพร้อมเส้นกำหนดเอง.

```php
  # สร้างอินสแตนซ์ของคลาส Presentation
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::ClusteredColumn, 100, 100, 500, 400);
    $shape = $chart->getUserShapes()->getShapes()->addAutoShape(ShapeType::Line, 0, $chart->getHeight() / 2, $chart->getWidth(), 0);
    $shape->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $shape->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
    $pres->save("Presentation.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **คำถามที่พบบ่อย**

**'forward' และ 'backward' มีความหมายอย่างไรสำหรับเส้นแนวโน้ม?**

เป็นความยาวของเส้นแนวโน้มที่ฉายไปข้างหน้า/ข้างหลัง: สำหรับแผนภูมิสเก็ตเตอร์ (XY) — หน่วยแกน; สำหรับแผนภูมิที่ไม่ใช่สเก็ตเตอร์ — จำนวนหมวดหมู่. ค่าต้องไม่เป็นลบ.

**เส้นแนวโน้มจะคงอยู่หรือไม่เมื่อตัวส่งออกการนำเสนอเป็น PDF หรือ SVG หรือเมื่อตัวเรนเดอร์สไลด์เป็นภาพ?**

ใช่. Aspose.Slides แปลงการนำเสนอเป็น [PDF](/slides/th/php-java/convert-powerpoint-to-pdf/)/[SVG](/slides/th/php-java/render-a-slide-as-an-svg-image/) และเรนเดอร์แผนภูมิเป็นภาพ; เส้นแนวโน้มซึ่งเป็นส่วนหนึ่งของแผนภูมิจะถูกรักษาไว้ระหว่างการดำเนินการเหล่านี้. อีกหนึ่งเมธอดยังพร้อมให้ใช้เพื่อ [ส่งออกรูปภาพของแผนภูมิ](/slides/th/php-java/create-shape-thumbnails/) ด้วย.