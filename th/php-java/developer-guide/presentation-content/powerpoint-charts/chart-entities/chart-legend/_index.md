---
title: ปรับแต่งคำอธิบายภาพกราฟในงานนำเสนอโดยใช้ PHP
linktitle: คำอธิบายภาพกราฟ
type: docs
url: /th/php-java/chart-legend/
keywords:
- คำอธิบายภาพกราฟ
- ตำแหน่งคำอธิบายภาพกราฟ
- ขนาดตัวอักษร
- PowerPoint
- การนำเสนอ
- PHP
- Aspose.Slides
description: "ปรับแต่งคำอธิบายภาพกราฟด้วย Aspose.Slides สำหรับ PHP ผ่าน Java เพื่อเพิ่มประสิทธิภาพงานนำเสนอ PowerPoint ด้วยการจัดรูปแบบ legend ที่กำหนดเอง."
---
## **Overview**

Aspose.Slides มีตัวเลือกสำหรับการปรับแต่งคำอธิบายภาพกราฟ (legend) ในการนำเสนอ PowerPoint บทความนี้จะแสดงวิธีกำหนดตำแหน่งและขนาดของ legend ตั้งค่าขนาดตัวอักษรสำหรับ legend ทั้งหมด และกำหนดรูปแบบให้กับรายการ legend รายการเดียว

นอกจากนี้ยังครอบคลุมพฤติกรรมที่เกี่ยวข้องหลายอย่างในส่วนคำถามที่พบบ่อย (FAQ) ได้แก่ การใช้โหมดไม่ซ้อนทับเพื่อให้พื้นที่พล็อตทำให้มีที่ว่างสำหรับ legend การให้ป้าย legend ยาวห่อข้อความหรือใช้การขึ้นบรรทัดใหม่ได้ และการทำให้การกำหนดรูปแบบของ legend สืบทอดจากธีมการนำเสนอเมื่อไม่ได้กำหนดสีข้อความและการเติมอย่างชัดเจน

## **Legend Positioning**
เพื่อกำหนดคุณสมบัติของ legend โปรดทำตามขั้นตอนด้านล่าง:

- สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/php-java/aspose.slides/Presentation)
- รับอ้างอิงของสไลด์
- เพิ่มแผนภูมิลงบนสไลด์
- ตั้งค่าคุณสมบัติของ legend
- เขียนไฟล์การนำเสนอเป็นไฟล์ PPTX

ในตัวอย่างด้านล่าง เราได้ตั้งค่าตำแหน่งและขนาดของ legend ของแผนภูมิ

```php
  # สร้างอินสแตนซ์ของคลาส Presentation
  $pres = new Presentation();
  try {
    # รับอ้างอิงของสไลด์
    $slide = $pres->getSlides()->get_Item(0);
    # เพิ่มแผนภูมิคอลัมน์แบบกลุ่มบนสไลด์
    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 500, 500);
    # ตั้งค่าคุณสมบัติของ Legend
    $chart->getLegend()->setX(50 / $chart->getWidth());
    $chart->getLegend()->setY(50 / $chart->getHeight());
    $chart->getLegend()->setWidth(100 / $chart->getWidth());
    $chart->getLegend()->setHeight(100 / $chart->getHeight());
    # เขียนการนำเสนอไปยังดิสก์
    $pres->save("Legend_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Set the Font Size of a Legend**
Aspose.Slides for PHP via Java ให้ผู้พัฒนาสามารถตั้งค่าขนาดตัวอักษรของ legend ได้ โปรดทำตามขั้นตอนด้านล่าง:

- สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/php-java/aspose.slides/Presentation)
- สร้างแผนภูมิเบื้องต้น
- ตั้งค่าขนาดตัวอักษร
- ตั้งค่าค่าต่ำสุดของแกน
- ตั้งค่าค่าสูงสุดของแกน
- เขียนไฟล์การนำเสนอลงดิสก์

```php
  # สร้างอินสแตนซ์ของคลาส Presentation
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 600, 400);
    $chart->getLegend()->getTextFormat()->getPortionFormat()->setFontHeight(20);
    $chart->getAxes()->getVerticalAxis()->setAutomaticMinValue(false);
    $chart->getAxes()->getVerticalAxis()->setMinValue(-5);
    $chart->getAxes()->getVerticalAxis()->setAutomaticMaxValue(false);
    $chart->getAxes()->getVerticalAxis()->setMaxValue(10);
    $pres->save("output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Set the Font Size of an Individual Legend**
Aspose.Slides for PHP via Java ให้ผู้พัฒนาสามารถตั้งค่าขนาดตัวอักษรของรายการ legend แต่ละรายการได้ โปรดทำตามขั้นตอนด้านล่าง:

- สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/php-java/aspose.slides/Presentation)
- สร้างแผนภูมิเบื้องต้น
- เข้าถึงรายการ legend
- ตั้งค่าขนาดตัวอักษร
- ตั้งค่าค่าต่ำสุดของแกน
- ตั้งค่าค่าสูงสุดของแกน
- เขียนไฟล์การนำเสนอลงดิสก์

```php
  # สร้างอินสแตนซ์ของคลาส Presentation
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 600, 400);
    $tf = $chart->getLegend()->getEntries()->get_Item(1)->getTextFormat();
    $tf->getPortionFormat()->setFontBold(NullableBool::True);
    $tf->getPortionFormat()->setFontHeight(20);
    $tf->getPortionFormat()->setFontItalic(NullableBool::True);
    $tf->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $tf->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    $pres->save("output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **FAQ**

**ฉันสามารถเปิดใช้งาน legend เพื่อให้แผนภูมิจัดสรรพื้นที่ให้โดยอัตโนมัติแทนการซ้อนทับได้หรือไม่?**

ใช่ ใช้โหมดไม่ซ้อนทับ ([setOverlay(false)](https://reference.aspose.com/slides/th/php-java/aspose.slides/legend/setoverlay/)) ในกรณีนี้พื้นที่พล็อตจะลดลงเพื่อให้พอดีกับ legend

**ฉันสามารถทำให้ป้าย legend มีหลายบรรทัดได้หรือไม่?**

ใช่ ป้ายที่ยาวจะห่ออัตโนมัติเมื่อพื้นที่ไม่พอ การบังคับขึ้นบรรทัดใหม่รองรับด้วยอักขระ newline ในชื่อชุดข้อมูล

**ฉันจะทำให้ legend ติดตามโทนสีของธีมการนำเสนอได้อย่างไร?**

อย่ากำหนดสี/การเติม/ฟอนต์อย่างชัดเจนสำหรับ legend หรือข้อความของมัน ระบบจะสืบทอดจากธีมและจะปรับอัปเดตอย่างถูกต้องเมื่อเปลี่ยนการออกแบบ