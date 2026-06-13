---
title: ปรับแต่งพื้นที่พล็อตของแผนภูมิในการนำเสนอด้วย PHP
linktitle: พื้นที่พล็อต
type: docs
url: /th/php-java/chart-plot-area/
keywords:
- แผนภูมิ
- พื้นที่พล็อต
- ความกว้างพื้นที่พล็อต
- ความสูงพื้นที่พล็อต
- ขนาดพื้นที่พล็อต
- โหมดการจัดวาง
- PowerPoint
- งานนำเสนอ
- PHP
- Aspose.Slides
description: "ค้นพบวิธีการปรับแต่งพื้นที่พล็อตของแผนภูมิในงานนำเสนอ PowerPoint ด้วย Aspose.Slides สำหรับ PHP ผ่าน Java ปรับปรุงภาพสไลด์ของคุณอย่างง่ายดาย."
---
## **ภาพรวม**

บทความนี้แสดงวิธีทำงานกับพื้นที่พล็อตของแผนภูมิใน Aspose.Slides โดยอธิบายวิธีการรับตำแหน่งและขนาดจริงของพื้นที่พล็อตโดยการตรวจสอบการจัดวางแผนภูมิแล้วอ่านค่า X, Y, ความกว้างและความสูง

มันยังสาธิตวิธีกำหนดโหมดการจัดวางของพื้นที่พล็อตเมื่อการจัดวางตั้งค่าแบบแมนนวล โดยใช้ `LayoutTargetType` เพื่อกำหนดว่าพื้นที่พล็อตจะคำนวณจากพื้นที่ภายในหรือจากพื้นที่ภายนอกพร้อมกับแกนและป้ายแกน

## **รับความกว้างและความสูงของพื้นที่พล็อตแผนภูมิ**
Aspose.Slides for PHP via Java มี API แบบง่ายสำหรับ .  

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/php-java/aspose.slides/Presentation)
2. เข้าถึงสไลด์แรก
3. เพิ่มแผนภูมิกับข้อมูลเริ่มต้น
4. เรียกเมธอด [Chart.validateChartLayout](https://reference.aspose.com/slides/th/php-java/aspose.slides/chart/validatechartlayout/) ก่อนเพื่อรับค่าจริง
5. รับค่าตำแหน่ง X จริง (ด้านซ้าย) ขององค์ประกอบแผนภูมิเกี่ยวกับมุมซ้ายบนของแผนภูมิ
6. รับค่าตำแหน่งบนจริงขององค์ประกอบแผนภูมิเกี่ยวกับมุมซ้ายบนของแผนภูมิ
7. รับค่าความกว้างจริงขององค์ประกอบแผนภูมิ
8. รับค่าความสูงจริงขององค์ประกอบแผนภูมิ

```php
  # สร้างอินสแตนซ์ของคลาส Presentation
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

## **กำหนดโหมดการจัดวางของพื้นที่พล็อตแผนภูมิ**
Aspose.Slides for PHP via Java มี API แบบง่ายเพื่อกำหนดโหมดการจัดวางของพื้นที่พล็อตแผนภูมิ เมธอด [**setLayoutTargetType**](https://reference.aspose.com/slides/th/php-java/aspose.slides/ChartPlotArea#setLayoutTargetType-int-) และ [**getLayoutTargetType**](https://reference.aspose.com/slides/th/php-java/aspose.slides/ChartPlotArea#getLayoutTargetType--) ถูกเพิ่มในคลาส [**ChartPlotArea**](https://reference.aspose.com/slides/th/php-java/aspose.slides/ChartPlotArea) หากการจัดวางของพื้นที่พล็อตกำหนดด้วยตนเอง คุณสมบัตินี้จะระบุว่าจะจัดวางพื้นที่พล็อตโดยใช้ภายใน (ไม่รวมแกนและป้ายแกน) หรือภายนอก (รวมแกนและป้ายแกน) มีสองค่าเป็นไปได้ซึ่งกำหนดใน enum [**LayoutTargetType**](https://reference.aspose.com/slides/th/php-java/aspose.slides/LayoutTargetType)

- [**LayoutTargetType::Inner**](https://reference.aspose.com/slides/th/php-java/aspose.slides/LayoutTargetType#Inner) - ระบุว่าขนาดของพื้นที่พล็อตจะกำหนดขนาดของพื้นที่พล็อตโดยไม่รวมเครื่องหมายวัดและป้ายแกน
- [**LayoutTargetType::Outer**](https://reference.aspose.com/slides/th/php-java/aspose.slides/LayoutTargetType#Outer) - ระบุว่าขนาดของพื้นที่พล็อตจะกำหนดขนาดของพื้นที่พล็อต, เครื่องหมายวัด, และป้ายแกน

ตัวอย่างโค้ดมีดังต่อไปนี้

```php
  # สร้างอินสแตนซ์ของคลาส Presentation
  $pres = new Presentation();
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 20, 100, 600, 400);
    $chart->getPlotArea()->setX(0.2);
    $chart->getPlotArea()->setY(0.2);
    $chart->getPlotArea()->setWidth(0.7);
    $chart->getPlotArea()->setHeight(0.7);
    $chart->getPlotArea()->setLayoutTargetType(LayoutTargetType::Inner);
    $pres->save("SetLayoutMode_outer.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **FAQ**

**หน่วยที่ใช้สำหรับค่าจริงของ x, y, ความกว้างและความสูงคืออะไร?**

เป็นจุด; 1 นิ้ว = 72 จุด ซึ่งเป็นหน่วยพิกัดของ Aspose.Slides

**พื้นที่พล็อตแตกต่างจากพื้นที่แผนภูมิอย่างไรในแง่ของเนื้อหา?**

พื้นที่พล็อตคือบริเวณการวาดข้อมูล (ชุดข้อมูล, เส้นกริด, เส้นแนวโน้ม ฯลฯ) ส่วนพื้นที่แผนภูมิรวมถึงองค์ประกอบรอบข้าง (หัวเรื่อง, คำอธิบาย, ฯลฯ) ในแผนภูมิ 3 มิติ พื้นที่พล็อตยังรวมถึงผนัง/พื้นและแกนด้วย

**ค่าตำแหน่ง x, y, ความกว้างและความสูงของพื้นที่พล็อตถูกตีความอย่างไรเมื่อการจัดวางเป็นแบบแมนนวล?**

เป็นอัตราส่วน (0–1) ของขนาดรวมของแผนภูมิ; ในโหมดนี้การวางตำแหน่งอัตโนมัติจะถูกปิดและใช้ค่าอัตราส่วนที่คุณตั้งไว้

**ทำไมตำแหน่งของพื้นที่พล็อตจึงเปลี่ยนหลังจากเพิ่ม/ย้ายคำอธิบาย?**

คำอธิบายอยู่ในพื้นที่แผนภูมิด้านนอกพื้นที่พล็อตแต่มีผลต่อการจัดวางและพื้นที่ที่ใช้ได้ ดังนั้นพื้นที่พล็อตอาจเลื่อนตำแหน่งเมื่อมีการวางตำแหน่งอัตโนมัติ (นี่เป็นพฤติกรรมมาตรฐานของแผนภูมิ PowerPoint)