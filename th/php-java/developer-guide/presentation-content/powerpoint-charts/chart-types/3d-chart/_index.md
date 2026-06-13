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
description: "เรียนรู้วิธีสร้างและปรับแต่งแผนภูมิ 3-D ใน Aspose.Slides สำหรับ PHP ผ่าน Java พร้อมการสนับสนุนไฟล์ PPT และ PPTX — ยกระดับการนำเสนอของคุณวันนี้"
---
## **ภาพรวม**

บทความนี้อธิบายวิธีการปรับแต่งแผนภูมิ 3D ใน Aspose.Slides โดยการกำหนดค่าการตั้งค่า `Rotation3D` เช่น `RotationX` , `RotationY` , `DepthPercents` และ `RightAngleAxes` โดยจะอธิบายขั้นตอนการสร้างการนำเสนอ, เพิ่มแผนภูมิ 3D พร้อมข้อมูลเริ่มต้น, กำหนดค่าการมอง 3D ที่จำเป็น, แล้วบันทึกการนำเสนอที่แก้ไขเป็นไฟล์ PPTX

## **ตั้งค่า RotationX, RotationY และ DepthPercents ของแผนภูมิ 3D**
Aspose.Slides for PHP via Java มี API ง่ายสำหรับการตั้งค่าคุณสมบัติเหล่านี้ บทความต่อไปนี้จะช่วยคุณในการตั้งค่าคุณสมบัติต่าง ๆ เช่น **X,Y Rotation, DepthPercents** เป็นต้น ตัวอย่างโค้ดแสดงการตั้งค่าคุณสมบัติที่กล่าวถึงข้างต้น

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentation/)
2. เข้าถึงสไลด์แรก
3. เพิ่มแผนภูมิพร้อมข้อมูลเริ่มต้น
4. ตั้งค่าคุณสมบัติ Rotation3D
5. บันทึกการนำเสนอที่แก้ไขเป็นไฟล์ PPTX

```php
  $pres = new Presentation();
  try {
    # เข้าถึงสไลด์แรก
    $slide = $pres->getSlides()->get_Item(0);
    # เพิ่มแผนภูมิพร้อมข้อมูลเริ่มต้น
    $chart = $slide->getShapes()->addChart(ChartType::StackedColumn3D, 0, 0, 500, 500);
    # กำหนดดัชนีของชีตข้อมูลแผนภูมิ
    $defaultWorksheetIndex = 0;
    # ดึงเวิร์กชีตข้อมูลแผนภูมิ
    $fact = $chart->getChartData()->getChartDataWorkbook();
    # เพิ่มชุดข้อมูล
    $chart->getChartData()->getSeries()->add($fact->getCell($defaultWorksheetIndex, 0, 1, "Series 1"), $chart->getType());
    $chart->getChartData()->getSeries()->add($fact->getCell($defaultWorksheetIndex, 0, 2, "Series 2"), $chart->getType());
    # เพิ่มประเภท
    $chart->getChartData()->getCategories()->add($fact->getCell($defaultWorksheetIndex, 1, 0, "Caetegoty 1"));
    $chart->getChartData()->getCategories()->add($fact->getCell($defaultWorksheetIndex, 2, 0, "Caetegoty 2"));
    $chart->getChartData()->getCategories()->add($fact->getCell($defaultWorksheetIndex, 3, 0, "Caetegoty 3"));
    # ตั้งค่าคุณสมบัติ Rotation3D
    $chart->getRotation3D()->setRightAngleAxes(true);
    $chart->getRotation3D()->setRotationX(40);
    $chart->getRotation3D()->setRotationY(270);
    $chart->getRotation3D()->setDepthPercents(150);
    # ดึงชุดข้อมูลแผนภูมิที่สอง
    $series = $chart->getChartData()->getSeries()->get_Item(1);
    # กำลังเติมข้อมูลชุดข้อมูล
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 1, 1, 20));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 2, 1, 50));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 3, 1, 30));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 1, 2, 30));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 2, 2, 10));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 3, 2, 60));
    # ตั้งค่า OverLap
    $series->getParentSeriesGroup()->setOverlap(100);
    # บันทึกการนำเสนอลงดิสก์
    $pres->save("Rotation3D_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **คำถามที่พบบ่อย**

**ประเภทแผนภูมิใดบ้างที่รองรับโหมด 3D ใน Aspose.Slides?**

Aspose.Slides รองรับรูปแบบ 3D ของแผนภูมิคอลัมน์ ได้แก่ Column 3D, Clustered Column 3D, Stacked Column 3D และ 100% Stacked Column 3D พร้อมกับประเภท 3D ที่เกี่ยวข้องซึ่งเปิดเผยผ่านคลาส [ChartType](https://reference.aspose.com/slides/th/php-java/aspose.slides/charttype/) เพื่อดูรายการที่แม่นยำและเป็นปัจจุบัน ให้ตรวจสอบสมาชิกของ [ChartType](https://reference.aspose.com/slides/th/php-java/aspose.slides/charttype/) ในเอกสารอ้างอิง API ของเวอร์ชันที่คุณติดตั้ง

**ฉันสามารถรับภาพแรสเตอร์ของแผนภูมิ 3D สำหรับรายงานหรือเว็บได้หรือไม่?**

ได้ คุณสามารถส่งออกแผนภูมิเป็นภาพผ่าน [chart API](https://reference.aspose.com/slides/th/php-java/aspose.slides/shape/#getImage) หรือ [เรนเดอร์สไลด์ทั้งหมด](/slides/th/php-java/convert-powerpoint-to-png/) เป็นรูปแบบเช่น PNG หรือ JPEG ซึ่งเป็นประโยชน์เมื่อคุณต้องการตัวอย่างที่พิกเซลสมบูรณ์หรือฝังแผนภูมิลงในเอกสาร, แดชบอร์ดหรือหน้าเว็บโดยไม่ต้องใช้ PowerPoint

**ประสิทธิภาพการสร้างและแสดงผลแผนภูมิ 3D ขนาดใหญ่เป็นอย่างไร?**

ประสิทธิภาพขึ้นอยู่กับปริมาณข้อมูลและความซับซ้อนของภาพ เพื่อให้ได้ผลดีที่สุด ควรลดเอฟเฟกต์ 3D ให้เหลือน้อยที่สุด, หลีกเลี่ยงการใช้พื้นผิวที่มีเท็กซ์เจอร์หนักบนผนังและพื้นที่พล็อต, จำกัดจำนวนจุดข้อมูลต่อชุดเมื่อทำได้, และเรนเดอร์เป็นขนาดเอาต์พุตที่เหมาะสม (ความละเอียดและมิติ) เพื่อให้สอดคล้องกับการแสดงผลหรือการพิมพ์ที่ต้องการ  