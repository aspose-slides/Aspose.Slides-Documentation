---
title: ทำแอนิเมชันแผนภูมิ PowerPoint ใน PHP
linktitle: แผนภูมิแอนิเมชัน
type: docs
weight: 80
url: /th/php-java/animated-charts/
keywords:
- แผนภูมิ
- แผนภูมิแอนิเมชัน
- แอนิเมชันแผนภูมิ
- ซีรีส์แผนภูมิ
- หมวดหมู่แผนภูมิ
- องค์ประกอบซีรีส์
- องค์ประกอบหมวดหมู่
- เพิ่มเอฟเฟกต์
- ประเภทเอฟเฟกต์
- PowerPoint
- งานนำเสนอ
- PHP
- Aspose.Slides
description: "สร้างแผนภูมิแอนิเมชันที่สวยงามด้วย Aspose.Slides สำหรับ PHP ผ่าน Java เพิ่มประสิทธิภาพการนำเสนอด้วยภาพเคลื่อนไหวในไฟล์ PPT และ PPTX — เริ่มต้นได้ทันที"
---
## **บทนำ**

Aspose.Slides for PHP via Java รองรับการทำให้ส่วนประกอบของแผนภูมิเคลื่อนไหว **Series**, **Categories**, **Series Elements**, **Categories Elements** สามารถทำให้เคลื่อนไหวได้ด้วยเมธอด [Sequence::addEffect](https://reference.aspose.com/slides/th/php-java/aspose.slides/sequence/#addEffect) และสองอีมนัม [EffectChartMajorGroupingType](https://reference.aspose.com/slides/th/php-java/aspose.slides/EffectChartMajorGroupingType) และ [EffectChartMinorGroupingType](https://reference.aspose.com/slides/th/php-java/aspose.slides/EffectChartMinorGroupingType).

## **การเคลื่อนไหวของซีรีส์แผนภูมิ**
หากคุณต้องการทำแอนิเมชันให้กับซีรีส์ของแผนภูมิ ให้เขียนโค้ดตามขั้นตอนที่ระบุด้านล่าง:

1. โหลดพรีเซนเทชัน
1. รับอ้างอิงของอ็อบเจกต์แผนภูมิ
1. ทำแอนิเมชันให้กับซีรีส์
1. เขียนไฟล์พรีเซนเทชันลงดิสก์

ในตัวอย่างด้านล่าง เราได้ทำแอนิเมชันให้กับซีรีส์ของแผนภูมิ

```php
  # สร้างอินสแตนซ์ของคลาส Presentation ที่แทนไฟล์พรีเซนเทชัน
  $pres = new Presentation("ExistingChart.pptx");
  try {
    # รับอ้างอิงของอ็อบเจกต์แผนภูมิ
    $slide = $pres->getSlides()->get_Item(0);
    $shapes = $slide->getShapes();
    $chart = $shapes->get_Item(0);
    # ทำแอนิเมชันให้กับซีรีส์
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectType::Fade, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMajorGroupingType::BySeries, 0, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMajorGroupingType::BySeries, 1, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMajorGroupingType::BySeries, 2, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMajorGroupingType::BySeries, 3, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    # บันทึกพรีเซนเทชันที่แก้ไขแล้วลงดิสก์
    $pres->save("AnimatingSeries_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **การเคลื่อนไหวของ Category แผนภูมิ**
หากคุณต้องการทำแอนิเมชันให้กับ Category ของแผนภูมิ ให้เขียนโค้ดตามขั้นตอนที่ระบุด้านล่าง:

1. โหลดพรีเซนเทชัน
1. รับอ้างอิงของอ็อบเจกต์แผนภูมิ
1. ทำแอนิเมชันให้กับ Category
1. เขียนไฟล์พรีเซนเทชันลงดิสก์

ในตัวอย่างด้านล่าง เราได้ทำแอนิเมชันให้กับ Category ของแผนภูมิ

```php
  # สร้างอินสแตนซ์ของคลาส Presentation ที่แทนไฟล์พรีเซนเทชัน
  $pres = new Presentation("ExistingChart.pptx");
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $shapes = $slide->getShapes();
    $chart = $shapes->get_Item(0);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectType::Fade, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMajorGroupingType::ByCategory, 0, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMajorGroupingType::ByCategory, 1, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMajorGroupingType::ByCategory, 2, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMajorGroupingType::ByCategory, 3, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $pres->save("Sample_Animation_C.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **การเคลื่อนไหวในองค์ประกอบของซีรีส์**
หากคุณต้องการทำแอนิเมชันให้กับองค์ประกอบของซีรีส์ ให้เขียนโค้ดตามขั้นตอนที่ระบุด้านล่าง:

1. โหลดพรีเซนเทชัน
1. รับอ้างอิงของอ็อบเจกต์แผนภูมิ
1. ทำแอนิเมชันให้กับองค์ประกอบของซีรีส์
1. เขียนไฟล์พรีเซนเทชันลงดิสก์

ในตัวอย่างด้านล่าง เราได้ทำแอนิเมชันให้กับองค์ประกอบของซีรีส์

```php
  # สร้างอินสแตนซ์ของคลาส Presentation ที่แทนไฟล์พรีเซนเทชัน
  $pres = new Presentation("ExistingChart.pptx");
  try {
    # รับอ้างอิงของอ็อบเจกต์แผนภูมิ
    $slide = $pres->getSlides()->get_Item(0);
    $shapes = $slide->getShapes();
    $chart = $shapes->get_Item(0);
    # ทำแอนิเมชันให้กับองค์ประกอบของซีรีส์
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectType::Fade, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMinorGroupingType::ByElementInSeries, 0, 0, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMinorGroupingType::ByElementInSeries, 0, 1, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMinorGroupingType::ByElementInSeries, 0, 2, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMinorGroupingType::ByElementInSeries, 0, 3, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMinorGroupingType::ByElementInSeries, 1, 0, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMinorGroupingType::ByElementInSeries, 1, 1, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMinorGroupingType::ByElementInSeries, 1, 2, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMinorGroupingType::ByElementInSeries, 1, 3, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMinorGroupingType::ByElementInSeries, 2, 0, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMinorGroupingType::ByElementInSeries, 2, 1, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMinorGroupingType::ByElementInSeries, 2, 2, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMinorGroupingType::ByElementInSeries, 2, 3, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    # บันทึกไฟล์พรีเซนเทชันลงดิสก์
    $pres->save("AnimatingSeriesElements_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **การเคลื่อนไหวในองค์ประกอบของ Category**
หากคุณต้องการทำแอนิเมชันให้กับองค์ประกอบของ Category ให้เขียนโค้ดตามขั้นตอนที่ระบุด้านล่าง:

1. โหลดพรีเซนเทชัน
1. รับอ้างอิงของอ็อบเจกต์แผนภูมิ
1. ทำแอนิเมชันให้กับองค์ประกอบของ Category
1. เขียนไฟล์พรีเซนเทชันลงดิสก์

ในตัวอย่างด้านล่าง เราได้ทำแอนิเมชันให้กับองค์ประกอบของ Category

```php
  # สร้างอินสแตนซ์ของคลาส Presentation ที่แทนไฟล์พรีเซนเทชัน
  $pres = new Presentation("ExistingChart.pptx");
  try {
    # รับอ้างอิงของอ็อบเจกต์แผนภูมิ
    $slide = $pres->getSlides()->get_Item(0);
    $shapes = $slide->getShapes();
    $chart = $shapes->get_Item(0);
    # ทำแอนิเมชันให้กับองค์ประกอบของหมวดหมู่
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectType::Fade, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMinorGroupingType::ByElementInCategory, 0, 0, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMinorGroupingType::ByElementInCategory, 0, 1, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMinorGroupingType::ByElementInCategory, 0, 2, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMinorGroupingType::ByElementInCategory, 0, 3, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMinorGroupingType::ByElementInCategory, 1, 0, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMinorGroupingType::ByElementInCategory, 1, 1, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMinorGroupingType::ByElementInCategory, 1, 2, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMinorGroupingType::ByElementInCategory, 1, 3, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMinorGroupingType::ByElementInCategory, 2, 0, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMinorGroupingType::ByElementInCategory, 2, 1, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMinorGroupingType::ByElementInCategory, 2, 2, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMinorGroupingType::ByElementInCategory, 2, 3, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    # บันทึกไฟล์พรีเซนเทชันลงดิสก์
    $pres->save("AnimatingCategoriesElements_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **คำถามที่พบบ่อย**

**ประเภทเอฟเฟกต์ที่แตกต่างกัน (เช่น entrance, emphasis, exit) รองรับสำหรับแผนภูมิเช่นเดียวกับรูปทรงทั่วไปหรือไม่?**
ใช่ แผนภูมิถือเป็นรูปทรงหนึ่ง ดังนั้นจึงรองรับประเภทเอฟเฟกต์แอนิเมชันมาตรฐาน รวมถึง entrance, emphasis, และ exit พร้อมการควบคุมเต็มที่ผ่านไทม์ไลน์ของสไลด์และลำดับแอนิเมชัน

**ฉันสามารถผสานแอนิเมชันของแผนภูมิร่วมกับการเปลี่ยนสไลด์ได้หรือไม่?**
ใช่ [Transitions](/slides/th/php-java/slide-transition/) จะทำงานกับสไลด์ ในขณะที่เอฟเฟกต์แอนิเมชันทำงานกับอ็อบเจกต์บนสไลด์ คุณสามารถใช้ทั้งสองร่วมกันในพรีเซนเทชันเดียวกันและควบคุมแยกจากกันได้

**แอนิเมชันของแผนภูมิจะถูกเก็บไว้เมื่อบันทึกเป็น PPTX หรือไม่?**
ใช่ เมื่อคุณ [save to PPTX](/slides/th/php-java/save-presentation/) เอฟเฟกต์แอนิเมชันทั้งหมดและลำดับของมันจะถูกเก็บไว้เนื่องจากเป็นส่วนหนึ่งของโมเดลแอนิเมชันดั้งเดิมของพรีเซนเทชัน

**ฉันสามารถอ่านแอนิเมชันของแผนภูมิที่มีอยู่ในพรีเซนเทชันและแก้ไขได้หรือไม่?**
ใช่ API ให้การเข้าถึงไทม์ไลน์ของสไลด์ ลำดับและเอฟเฟกต์ ทำให้คุณสามารถตรวจสอบแอนิเมชันของแผนภูมิที่มีอยู่และปรับเปลี่ยนได้โดยไม่ต้องสร้างใหม่ทั้งหมดจากศูนย์

**ฉันสามารถสร้างวิดีโอที่รวมแอนิเมชันของแผนภูมิด้วย Aspose.Slides ได้หรือไม่?**
ใช่ คุณสามารถ [export a presentation to video](/slides/th/php-java/convert-powerpoint-to-video/) โดยคงแอนิเมชันไว้ ปรับแต่งเวลาและการตั้งค่าอื่น ๆ ของการส่งออก เพื่อให้คลิปที่ได้สะท้อนการเล่นแอนิเมชัน