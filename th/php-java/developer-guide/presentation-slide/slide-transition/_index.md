---
title: จัดการการเปลี่ยนสไลด์ในการพรีเซนเทชันด้วย PHP
linktitle: การเปลี่ยนสไลด์
type: docs
weight: 80
url: /th/php-java/slide-transition/
keywords:
- การเปลี่ยนสไลด์
- เพิ่มการเปลี่ยนสไลด์
- ใช้การเปลี่ยนสไลด์
- การเปลี่ยนสไลด์ขั้นสูง
- การเปลี่ยน Morph
- ประเภทการเปลี่ยน
- เอฟเฟกต์การเปลี่ยน
- PowerPoint
- OpenDocument
- การนำเสนอ
- PHP
- Aspose.Slides
description: "ค้นพบวิธีปรับแต่งการเปลี่ยนสไลด์ใน Aspose.Slides สำหรับ PHP ผ่าน Java พร้อมคำแนะนำทีละขั้นตอนสำหรับการนำเสนอ PowerPoint และ OpenDocument"
---
## **ภาพรวม**

บทความนี้อธิบายวิธีจัดการการเปลี่ยนสไลด์ในงานพรีเซนเทชันด้วย Aspose.Slides แสดงการใช้ประเภทการเปลี่ยนสไลด์บนสไลด์, การกำหนดพฤติกรรมการเปลี่ยนเช่น การเดินหน้าเมื่อคลิกหรือหลังจากเวลาที่กำหนด, การตรวจสอบและปิดการเดินหน้าอัตโนมัติ, การใช้การเปลี่ยน Morph และประเภทต่าง ๆ, รวมถึงการตั้งค่าเอฟเฟกต์การเปลี่ยน สาธิตตัวอย่างการโหลดหรือสร้างพรีเซนเทชัน, แก้ไขการตั้งค่าการเปลี่ยนสไลด์สำหรับสไลด์ที่เลือก, และบันทึกผลลัพธ์เป็นไฟล์ PPTX บทความยังตอบคำถามทั่วไปเกี่ยวกับความเร็วของการเปลี่ยน, เสียงการเปลี่ยน, การใช้การเปลี่ยนเดียวกันกับหลายสไลด์, และการตรวจสอบการเปลี่ยนที่ตั้งอยู่บนสไลด์ในขณะนี้

## **เพิ่มการเปลี่ยนสไลด์**
เพื่อสร้างเอฟเฟกต์การเปลี่ยนสไลด์อย่างง่าย ให้ทำตามขั้นตอนด้านล่าง:

1. สร้างอินสแตนซ์ของ [Presentation](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentation) class
2. ใช้ Slide Transition Type บนสไลด์จากหนึ่งในเอฟเฟกต์การเปลี่ยนที่ Aspose.Slides for PHP via Java ให้มาโดยผ่าน enum TransitionType
3. เขียนไฟล์พรีเซนเทชันที่แก้ไขแล้ว

```php
  # สร้างอินสแตนซ์ของคลาส Presentation เพื่อโหลดไฟล์พรีเซนเทชันต้นฉบับ
  $presentation = new Presentation("AccessSlides.pptx");
  try {
    # ใช้การเปลี่ยนแบบวงกลมบนสไลด์ที่ 1
    $presentation->getSlides()->get_Item(0)->getSlideShowTransition()->setType(TransitionType::Circle);
    # ใช้การเปลี่ยนแบบคอมบบนสไลด์ที่ 2
    $presentation->getSlides()->get_Item(1)->getSlideShowTransition()->setType(TransitionType::Comb);
    # เขียนพรีเซนเทชันลงดิสก์
    $presentation->save("SampleTransition_out.pptx", SaveFormat::Pptx);
  } finally {
    $presentation->dispose();
  }
```

## **เพิ่มการเปลี่ยนสไลด์ขั้นสูง**
ในส่วนก่อนหน้า เราได้ใช้เอฟเฟกต์การเปลี่ยนแบบง่ายบนสไลด์เท่านั้น ตอนนี้เพื่อทำให้เอฟเฟกต์ดังกล่าวดีขึ้นและควบคุมได้มากขึ้น โปรดทำตามขั้นตอนด้านล่าง:

1. สร้างอินสแตนซ์ของ [Presentation](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentation) class
2. ใช้ Slide Transition Type บนสไลด์จากหนึ่งในเอฟเฟกต์การเปลี่ยนที่ Aspose.Slides for PHP via Java ให้มา
3. คุณสามารถตั้งค่าการเปลี่ยนให้ Advance On Click, หลังจากระยะเวลาที่กำหนด หรือทั้งสองอย่างได้
4. หากการเปลี่ยนสไลด์เปิดใช้งาน Advance On Click การเปลี่ยนจะดำเนินการต่อเมื่อผู้ใช้คลิกเมาส์เท่านั้น นอกจากนี้ หากตั้งค่า Advance After Time การเปลี่ยนจะดำเนินการอัตโนมัติหลังจากเวลาที่กำหนดผ่านไป
5. เขียนพรีเซนเทชันที่แก้ไขแล้วเป็นไฟล์พรีเซนเทชัน

```php
  # สร้างอินสแตนซ์ของคลาส Presentation ที่แสดงถึงไฟล์พรีเซนเทชัน
  $pres = new Presentation("BetterSlideTransitions.pptx");
  try {
    # ใช้การเปลี่ยนแบบวงกลมบนสไลด์ที่ 1
    $pres->getSlides()->get_Item(0)->getSlideShowTransition()->setType(TransitionType::Circle);
    # ตั้งค่าเวลาการเปลี่ยนเป็น 3 วินาที
    $pres->getSlides()->get_Item(0)->getSlideShowTransition()->setAdvanceOnClick(true);
    $pres->getSlides()->get_Item(0)->getSlideShowTransition()->setAdvanceAfterTime(3000);
    # ใช้การเปลี่ยนแบบคอมบบนสไลด์ที่ 2
    $pres->getSlides()->get_Item(1)->getSlideShowTransition()->setType(TransitionType::Comb);
    # ตั้งค่าเวลาการเปลี่ยนเป็น 5 วินาที
    $pres->getSlides()->get_Item(1)->getSlideShowTransition()->setAdvanceOnClick(true);
    $pres->getSlides()->get_Item(1)->getSlideShowTransition()->setAdvanceAfterTime(5000);
    # ใช้การเปลี่ยนแบบซูมบนสไลด์ที่ 3
    $pres->getSlides()->get_Item(2)->getSlideShowTransition()->setType(TransitionType::Zoom);
    # ตั้งค่าเวลาการเปลี่ยนเป็น 7 วินาที
    $pres->getSlides()->get_Item(2)->getSlideShowTransition()->setAdvanceOnClick(true);
    $pres->getSlides()->get_Item(2)->getSlideShowTransition()->setAdvanceAfterTime(7000);
    # เขียนพรีเซนเทชันลงดิสก์
    $pres->save("SampleTransition_out.pptx", SaveFormat::Pptx);
  } finally {
    $pres->dispose();
  }
```

## **การเปลี่ยนรูปแบบ Morph**
{{% alert color="primary" %}} 

Aspose.Slides for PHP via Java ตอนนี้สนับสนุน [Morph Transition](https://reference.aspose.com/slides/th/php-java/aspose.slides/morphtransition/) ซึ่งเป็นการเปลี่ยน Morph ใหม่ที่แนะนำใน PowerPoint 2019

{{% /alert %}} 

การเปลี่ยน Morph ทำให้คุณสามารถทำแอนิเมชันการเคลื่อนที่อย่างราบรื่นจากสไลด์หนึ่งไปยังอีกสไลด์หนึ่ง บทความนี้อธิบายแนวคิดและวิธีการใช้การเปลี่ยน Morph เพื่อให้ใช้ได้อย่างมีประสิทธิภาพ คุณต้องมีสไลด์สองสไลด์ที่มีอ็อบเจ็กต์อย่างน้อยหนึ่งอันร่วมกัน วิธีที่ง่ายที่สุดคือทำสำเนาสไลด์แล้วย้ายอ็อบเจ็กต์ในสไลด์ที่สองไปยังตำแหน่งใหม่

โค้ดตัวอย่างต่อไปนี้แสดงวิธีเพิ่มสไลด์ที่คัดลอกพร้อมข้อความบางส่วนลงในพรีเซนเทชันและตั้งค่าการเปลี่ยนเป็น [morph type](https://reference.aspose.com/slides/th/php-java/aspose.slides/TransitionType) บนสไลด์ที่สอง

```php
  $presentation = new Presentation();
  try {
    $autoshape = $presentation->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 400, 100);
    $autoshape->getTextFrame()->setText("Morph Transition in PowerPoint Presentations");
    $presentation->getSlides()->addClone($presentation->getSlides()->get_Item(0));
    $shape = $presentation->getSlides()->get_Item(1)->getShapes()->get_Item(0);
    $shape->setX($shape->getX() + 100);
    $shape->setY($shape->getY() + 50);
    $shape->setWidth($shape->getWidth() - 200);
    $shape->setHeight($shape->getHeight() - 10);
    $presentation->getSlides()->get_Item(1)->getSlideShowTransition()->setType(TransitionType::Morph);
    $presentation->save("presentation-out.pptx", SaveFormat::Pptx);
  } finally {
    $presentation->dispose();
  }
```

## **ประเภทการเปลี่ยน Morph**
ได้เพิ่ม enum [TransitionMorphType](https://reference.aspose.com/slides/th/php-java/aspose.slides/TransitionMorphType) ใหม่ ซึ่งแทนประเภทต่าง ๆ ของการเปลี่ยนสไลด์แบบ Morph

enum TransitionMorphType มีสามสมาชิก:

- ByObject: การเปลี่ยน Morph จะดำเนินการโดยพิจารณา shape เป็นอ็อบเจ็กต์ที่ไม่แยกย่อยได้
- ByWord: การเปลี่ยน Morph จะดำเนินการโดยถ่ายทอดข้อความตามคำเมื่อเป็นไปได้
- ByChar: การเปลี่ยน Morph จะดำเนินการโดยถ่ายทอดข้อความตามอักขระเมื่อเป็นไปได้

โค้ดตัวอย่างต่อไปนี้แสดงวิธีตั้งค่า Morph transition ให้สไลด์และเปลี่ยนประเภท Morph:

```php
  $presentation = new Presentation("presentation.pptx");
  try {
    $presentation->getSlides()->get_Item(0)->getSlideShowTransition()->setType(TransitionType::Morph);
    $presentation->getSlides()->get_Item(0)->getSlideShowTransition()->getValue()->setMorphType(TransitionMorphType::ByWord);
    $presentation->save("presentation-out.pptx", SaveFormat::Pptx);
  } finally {
    $presentation->dispose();
  }
```

## **ตั้งค่าเอฟเฟกต์การเปลี่ยนสไลด์**
Aspose.Slides for PHP via Java รองรับการตั้งค่าเอฟเฟกต์การเปลี่ยน เช่น from black, from left, from right เป็นต้น เพื่อกำหนด Transition Effect โปรดทำตามขั้นตอนด้านล่าง:

- สร้างอินสแตนซ์ของ [Presentation](https://reference.aspose.com/slides/th/php-java/aspose.slides/Presentation) class
- ดึงอ้างอิงของสไลด์
- ตั้งค่าเอฟเฟกต์การเปลี่ยน
- เขียนพรีเซนเทชันเป็น [PPTX](https://docs.fileformat.com/presentation/pptx/) file

ในตัวอย่างด้านล่าง เราได้ตั้งค่าเอฟเฟกต์การเปลี่ยนแล้ว

```php
  # สร้างอินสแตนซ์ของคลาส Presentation
  $presentation = new Presentation("AccessSlides.pptx");
  try {
    # ตั้งค่าเอฟเฟกต์
    $presentation->getSlides()->get_Item(0)->getSlideShowTransition()->setType(TransitionType::Cut);
    $presentation->getSlides()->get_Item(0)->getSlideShowTransition()->getValue()->setFromBlack(true);
    # เขียนพรีเซนเทชันลงดิสก์
    $presentation->save("SetTransitionEffects_out.pptx", SaveFormat::Pptx);
  } finally {
    $presentation->dispose();
  }
```

## **คำถามที่พบบ่อย**

**ฉันสามารถควบคุมความเร็วการเล่นของการเปลี่ยนสไลด์ได้หรือไม่?**  
ได้โดยตั้ง [speed](https://reference.aspose.com/slides/th/php-java/aspose.slides/slideshowtransition/setspeed/) ของการเปลี่ยนผ่านการตั้งค่า [TransitionSpeed](https://reference.aspose.com/slides/th/php-java/aspose.slides/transitionspeed/) (เช่น ช้า/ปานกลาง/เร็ว)

**ฉันสามารถแนบไฟล์เสียงให้กับการเปลี่ยนและทำให้วนซ้ำได้หรือไม่?**  
ได้ คุณสามารถฝังเสียงสำหรับการเปลี่ยนและควบคุมพฤติกรรมผ่านการตั้งค่าเช่น โหมดเสียงและการวนซ้ำ (เช่น [setSound](https://reference.aspose.com/slides/th/php-java/aspose.slides/slideshowtransition/setsound/), [setSoundMode](https://reference.aspose.com/slides/th/php-java/aspose.slides/slideshowtransition/setsoundmode/), [setSoundLoop](https://reference.aspose.com/slides/th/php-java/aspose.slides/slideshowtransition/setsoundloop/), รวมถึงเมทาดาต้าเช่น [setSoundIsBuiltIn](https://reference.aspose.com/slides/th/php-java/aspose.slides/slideshowtransition/setsoundisbuiltin/) และ [setSoundName](https://reference.aspose.com/slides/th/php-java/aspose.slides/slideshowtransition/setsoundname/))

**วิธีที่เร็วที่สุดในการใช้การเปลี่ยนเดียวกันกับทุกสไลด์คืออะไร?**  
กำหนดประเภทการเปลี่ยนที่ต้องการในแต่ละสไลด์ผ่านการตั้งค่าการเปลี่ยนของสไลด์; เนื่องจากการเปลี่ยนถูกเก็บแยกตามสไลด์ การใช้ประเภทเดียวกันกับทุกสไลด์จะให้ผลลัพธ์ที่สอดคล้องกัน

**ฉันจะตรวจสอบว่าการเปลี่ยนใดตั้งอยู่บนสไลด์ขณะนี้ได้อย่างไร?**  
ตรวจสอบ [transition settings](https://reference.aspose.com/slides/th/php-java/aspose.slides/baseslide/#getSlideShowTransition) ของสไลด์และอ่านค่า [transition type](https://reference.aspose.com/slides/th/php-java/aspose.slides/slideshowtransition/settype/) ค่านั้นบ่งบอกถึงเอฟเฟกต์ที่ใช้อยู่อย่างชัดเจน