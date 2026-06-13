---
title: คัดลอกสไลด์การนำเสนอใน PHP
linktitle: คัดลอกสไลด์
type: docs
weight: 35
url: /th/php-java/clone-slides/
keywords:
- คัดลอกสไลด์
- คัดลอกสไลด์
- บันทึกสไลด์
- PowerPoint
- OpenDocument
- การนำเสนอ
- PHP
- Aspose.Slides
description: "คัดลอกสไลด์ PowerPoint อย่างรวดเร็วด้วย Aspose.Slides สำหรับ PHP. ปฏิบัติตามตัวอย่างโค้ดที่ชัดเจนของเราเพื่อทำการสร้าง PPT อัตโนมัติในไม่กี่วินาทีและลบงานทำมือออก."
---
## **บทนำ**

การโคลนนิ่งเป็นกระบวนการทำสำเนาหรือสำเนาที่เหมือนกันอย่างแม่นยำของบางอย่าง Aspose.Slides for PHP via Java ยังทำให้สามารถสร้างสำเนาหรือโคลนของสไลด์ใดก็ได้และจากนั้นแทรกสไลด์ที่โคลนแล้วไปยังการนำเสนอปัจจุบันหรือการนำเสนอที่เปิดอยู่อื่น ๆ กระบวนการโคลนสไลด์จะสร้างสไลด์ใหม่ที่นักพัฒนาสามารถแก้ไขได้โดยไม่เปลี่ยนแปลงสไลด์ต้นฉบับ มีหลายวิธีที่เป็นไปได้ในการโคลนสไลด์:

- โคลนที่ตำแหน่งสุดท้ายภายในการนำเสนอหนึ่ง
- โคลนที่ตำแหน่งอื่นภายในการนำเสนอ
- โคลนที่ตำแหน่งสุดท้ายในการนำเสนออื่น
- โคลนที่ตำแหน่งอื่นในการนำเสนออื่น
- โคลนที่ตำแหน่งเฉพาะในการนำเสนออื่น

ใน Aspose.Slides for PHP via Java, (คอลเลกชันของ [Slide](https://reference.aspose.com/slides/th/php-java/aspose.slides/Slide) อ็อบเจ็กต์) ที่ถูกเปิดเผยโดยอ็อบเจ็กต์ [Presentation](https://reference.aspose.com/slides/th/php-java/aspose.slides/Presentation) ให้เมธอด [addClone](https://reference.aspose.com/slides/th/php-java/aspose.slides/SlideCollection/#addClone) และ [insertClone](https://reference.aspose.com/slides/th/php-java/aspose.slides/SlideCollection/#insertClone) เพื่อทำการโคลนสไลด์ตามประเภทที่กล่าวข้างต้น

## **โคลนสไลด์ที่ตำแหน่งสุดท้ายของการนำเสนอ**
หากคุณต้องการโคลนสไลด์แล้วใช้มันภายในไฟล์การนำเสนอเดียวกันที่ตำแหน่งสุดท้ายของสไลด์ที่มีอยู่ ให้ใช้เมธอด [addClone](https://reference.aspose.com/slides/th/php-java/aspose.slides/SlideCollection/#addClone) ตามขั้นตอนที่ระบุด้านล่าง:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/php-java/aspose.slides/Presentation)
1. รับอ็อบเจ็กต์ [SlideCollection](https://reference.aspose.com/slides/th/php-java/aspose.slides/Presentation/#getSlides) โดยอ้างอิงคอลเลกชันสไลด์ที่เปิดเผยโดยอ็อบเจ็กต์ [Presentation](https://reference.aspose.com/slides/th/php-java/aspose.slides/Presentation)
1. เรียกเมธอด [addClone](https://reference.aspose.com/slides/th/php-java/aspose.slides/SlideCollection/#addClone) ที่เปิดเผยโดยอ็อบเจ็กต์ [SlideCollection](https://reference.aspose.com/slides/th/php-java/aspose.slides/Presentation/#getSlides) และส่งสไลด์ที่ต้องการโคลนเป็นพารามิเตอร์ให้เมธอด [addClone](https://reference.aspose.com/slides/th/php-java/aspose.slides/SlideCollection/#addClone)
1. เขียนไฟล์การนำเสนอที่แก้ไขแล้ว

ในตัวอย่างที่ให้ด้านล่าง เราได้โคลนสไลด์ (อยู่ที่ตำแหน่งแรก – ดัชนีศูนย์ – ของการนำเสนอ) ไปยังตำแหน่งสุดท้ายของการนำเสนอ

```php
  # สร้างอินสแตนซ์ของคลาส Presentation ที่แทนไฟล์การนำเสนอ
  $pres = new Presentation("CloneWithinSamePresentationToEnd.pptx");
  try {
    # โคลนสไลด์ที่ต้องการไปยังตำแหน่งสุดท้ายของคอลเลกชันสไลด์ในการนำเสนอเดียวกัน
    $slds = $pres->getSlides();
    $slds->addClone($pres->getSlides()->get_Item(0));
    # บันทึกการนำเสนอที่แก้ไขแล้วลงดิสก์
    $pres->save("Aspose_CloneWithinSamePresentationToEnd_out.pptx", SaveFormat::Pptx);
  } finally {
    $pres->dispose();
  }
```

## **โคลนสไลด์ไปยังตำแหน่งอื่นภายในการนำเสนอ**
หากคุณต้องการโคลนสไลด์แล้วใช้มันภายในไฟล์การนำเสนอเดียวกันแต่ที่ตำแหน่งต่างกัน ให้ใช้เมธอด [insertClone](https://reference.aspose.com/slides/th/php-java/aspose.slides/SlideCollection/#insertClone) :

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/php-java/aspose.slides/Presentation)
1. รับอ็อบเจ็กต์ [SlideCollection](https://reference.aspose.com/slides/th/php-java/aspose.slides/SlideCollection) โดยอ้างอิงคอลเลกชัน [**สไลด์**](https://reference.aspose.com/slides/th/php-java/aspose.slides/Presentation/#getSlides) ที่เปิดเผยโดยอ็อบเจ็กต์ [Presentation](https://reference.aspose.com/slides/th/php-java/aspose.slides/Presentation)
1. เรียกเมธอด [insertClone](https://reference.aspose.com/slides/th/php-java/aspose.slides/SlideCollection/#insertClone) ที่เปิดเผยโดยอ็อบเจ็กต์ [SlideCollection](https://reference.aspose.com/slides/th/php-java/aspose.slides/Presentation/#getSlides) และส่งสไลด์ที่ต้องการโคลนพร้อมกับดัชนีตำแหน่งใหม่เป็นพารามิเตอร์ให้เมธอด [insertClone](https://reference.aspose.com/slides/th/php-java/aspose.slides/SlideCollection/#insertClone)
1. เขียนการนำเสนอที่แก้ไขแล้วเป็นไฟล์ PPTX

ในตัวอย่างที่ให้ด้านล่าง เราได้โคลนสไลด์ (อยู่ที่ดัชนีศูนย์ – ตำแหน่ง 1 – ของการนำเสนอ) ไปยังดัชนี 1 – ตำแหน่ง 2 – ของการนำเสนอ

```php
  # สร้างอินสแตนซ์ของคลาส Presentation ที่แทนไฟล์การนำเสนอ
  $pres = new Presentation("CloneWithInSamePresentation.pptx");
  try {
    # โคลนสไลด์ที่ต้องการไปยังตำแหน่งสุดท้ายของคอลเลกชันสไลด์ในการนำเสนอเดียวกัน
    $slds = $pres->getSlides();
    # โคลนสไลด์ที่ต้องการไปยังดัชนีที่ระบุในการนำเสนอเดียวกัน
    $slds->insertClone(2, $pres->getSlides()->get_Item(1));
    # บันทึกการนำเสนอที่แก้ไขแล้วลงดิสก์
    $pres->save("Aspose_CloneWithInSamePresentation_out.pptx", SaveFormat::Pptx);
  } finally {
    $pres->dispose();
  }
```

## **โคลนสไลด์ที่ตำแหน่งสุดท้ายของการนำเสนออื่น**
หากคุณต้องการโคลนสไลด์จากการนำเสนอหนึ่งและใช้ในไฟล์การนำเสนออื่น ที่ตำแหน่งสุดท้ายของสไลด์ที่มีอยู่:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/php-java/aspose.slides/Presentation) ที่มีการนำเสนอซึ่งสไลด์จะถูกโคลนจากนั้น
1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/php-java/aspose.slides/Presentation) ที่มีการนำเสนอปลายทางที่สไลด์จะถูกเพิ่มเข้าไป
1. รับอ็อบเจ็กต์ [SlideCollection](https://reference.aspose.com/slides/th/php-java/aspose.slides/SlideCollection) โดยอ้างอิงคอลเลกชัน [**สไลด์**](https://reference.aspose.com/slides/th/php-java/aspose.slides/Presentation/#getSlides) ที่เปิดเผยโดยอ็อบเจ็กต์ Presentation ของการนำเสนอปลายทาง
1. เรียกเมธอด [addClone](https://reference.aspose.com/slides/th/php-java/aspose.slides/SlideCollection/#addClone) ที่เปิดเผยโดยอ็อบเจ็กต์ [SlideCollection](https://reference.aspose.com/slides/th/php-java/aspose.slides/Presentation/#getSlides) และส่งสไลด์จากการนำเสนอแหล่งที่มาเป็นพารามิเตอร์ให้เมธอด [addClone](https://reference.aspose.com/slides/th/php-java/aspose.slides/SlideCollection/#addClone)
1. เขียนไฟล์การนำเสนอปลายทางที่แก้ไขแล้ว

ในตัวอย่างที่ให้ด้านล่าง เราได้โคลนสไลด์ (จากดัชนีแรกของการนำเสนอแหล่งที่มา) ไปยังตำแหน่งสุดท้ายของการนำเสนอปลายทาง

```php
  # สร้างอินสแตนซ์ของคลาส Presentation เพื่อโหลดไฟล์การนำเสนอแหล่งที่มา
  $srcPres = new Presentation("CloneAtEndOfAnother.pptx");
  try {
    # สร้างอินสแตนซ์ของคลาส Presentation สำหรับ PPTX ปลายทาง (ที่สไลด์จะถูกโคลน)
    $destPres = new Presentation();
    try {
      # โคลนสไลด์ที่ต้องการจากการนำเสนอแหล่งที่มาที่ตำแหน่งสุดท้ายของคอลเลกชันสไลด์ในการนำเสนอปลายทาง
      $slds = $destPres->getSlides();
      $slds->addClone($srcPres->getSlides()->get_Item(0));
      # บันทึกการนำเสนอปลายทางลงดิสก์
      $destPres->save("Aspose2_out.pptx", SaveFormat::Pptx);
    } finally {
      $destPres->dispose();
    }
  } finally {
    $srcPres->dispose();
  }
```

## **โคลนสไลด์ไปยังตำแหน่งอื่นในการนำเสนออื่น**
หากคุณต้องการโคลนสไลด์จากการนำเสนอหนึ่งและใช้ในไฟล์การนำเสนออื่น ที่ตำแหน่งเฉพาะ:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/php-java/aspose.slides/Presentation) ที่มีการนำเสนอแหล่งที่มาที่สไลด์จะถูกโคลนจาก
1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/php-java/aspose.slides/Presentation) ที่มีการนำเสนอปลายทางที่สไลด์จะถูกเพิ่มเข้าไป
1. รับคลาส [SlideCollection](https://reference.aspose.com/slides/th/php-java/aspose.slides/Presentation/#getSlides) โดยอ้างอิงคอลเลกชัน Slides ที่เปิดเผยโดยอ็อบเจ็กต์ Presentation ของการนำเสนอปลายทาง
1. เรียกเมธอด [insertClone](https://reference.aspose.com/slides/th/php-java/aspose.slides/SlideCollection/#insertClone) ที่เปิดเผยโดยอ็อบเจ็กต์ [SlideCollection](https://reference.aspose.com/slides/th/php-java/aspose.slides/Presentation/#getSlides) และส่งสไลด์จากการนำเสนอแหล่งที่มาพร้อมตำแหน่งที่ต้องการเป็นพารามิเตอร์ให้เมธอด [insertClone](https://reference.aspose.com/slides/th/php-java/aspose.slides/SlideCollection/#insertClone)
1. เขียนไฟล์การนำเสนอปลายทางที่แก้ไขแล้ว

ในตัวอย่างที่ให้ด้านล่าง เราได้โคลนสไลด์ (จากดัชนีศูนย์ของการนำเสนอแหล่งที่มา) ไปยังดัชนี 1 (ตำแหน่ง 2) ของการนำเสนอปลายทาง

```php
  # สร้างอินสแตนซ์ของคลาส Presentation เพื่อโหลดไฟล์การนำเสนอแหล่งที่มา
  $srcPres = new Presentation("CloneAtEndOfAnother.pptx");
  try {
    # สร้างอินสแตนซ์ของคลาส Presentation สำหรับ PPTX ปลายทาง (ที่สไลด์จะถูกโคลน)
    $destPres = new Presentation();
    try {
      # โคลนสไลด์ที่ต้องการจากการนำเสนอแหล่งที่มาที่ตำแหน่งสุดท้ายของคอลเลกชันสไลด์ในการนำเสนอปลายทาง
      $slds = $destPres->getSlides();
      $slds->insertClone(2, $srcPres->getSlides()->get_Item(0));
      # บันทึกการนำเสนอปลายทางลงดิสก์
      $destPres->save("Aspose2_out.pptx", SaveFormat::Pptx);
    } finally {
      $destPres->dispose();
    }
  } finally {
    $srcPres->dispose();
  }
```

## **โคลนสไลด์ที่ตำแหน่งเฉพาะในการนำเสนออื่น**
หากคุณต้องการโคลนสไลด์ที่มีมาสเตอร์สไลด์จากการนำเสนอหนึ่งและใช้ในการนำเสนออื่น คุณต้องโคลนมาสเตอร์สไลด์ที่ต้องการจากการนำเสนอแหล่งที่มามาที่การนำเสนอปลายทางก่อน แล้วจึงใช้มาสเตอร์สไลด์นั้นสำหรับการโคลนสไลด์พร้อมมาสเตอร์ เมธอด [**addClone(Slide, MasterSlide, boolean)**](https://reference.aspose.com/slides/th/php-java/aspose.slides/slidecollection/addclone/) คาดหวังมาสเตอร์สไลด์จากการนำเสนอปลายทางไม่ใช่จากแหล่งที่มา เพื่อโคลนสไลด์พร้อมมาสเตอร์ โปรดทำตามขั้นตอนด้านล่าง:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/php-java/aspose.slides/Presentation) ที่มีการนำเสนอแหล่งที่มาที่สไลด์จะถูกโคลนจาก
1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/php-java/aspose.slides/Presentation) ที่มีการนำเสนอปลายทางที่สไลด์จะถูกโคลนไป
1. เข้าถึงสไลด์ที่ต้องการโคลนพร้อมกับมาสเตอร์สไลด์
1. สร้างอินสแตนซ์ของคลาส [MasterSlideCollection](https://reference.aspose.com/slides/th/php-java/aspose.slides/MasterSlideCollection) โดยอ้างอิงคอลเลกชัน Masters ที่เปิดเผยโดยอ็อบเจ็กต์ [Presentation](https://reference.aspose.com/slides/th/php-java/aspose.slides/Presentation) ของการนำเสนอปลายทาง
1. เรียกเมธอด [addClone](https://reference.aspose.com/slides/th/php-java/aspose.slides/SlideCollection/#addClone) ที่เปิดเผยโดยอ็อบเจ็กต์ [MasterSlideCollection](https://reference.aspose.com/slides/th/php-java/aspose.slides/MasterSlideCollection) และส่งมาสเตอร์จาก PPTX แหล่งที่มาที่ต้องการโคลนเป็นพารามิเตอร์ให้เมธอด [addClone](https://reference.aspose.com/slides/th/php-java/aspose.slides/SlideCollection/#addClone)
1. สร้างอินสแตนซ์ของคลาส [SlideCollection](https://reference.aspose.com/slides/th/php-java/aspose.slides/Presentation/#getSlides) โดยตั้งค่าการอ้างอิงไปยังคอลเลกชัน Slides ที่เปิดเผยโดยอ็อบเจ็กต์ [Presentation](https://reference.aspose.com/slides/th/php-java/aspose.slides/Presentation) ของการนำเสนอปลายทาง
1. เรียกเมธอด [addClone](https://reference.aspose.com/slides/th/php-java/aspose.slides/SlideCollection/#addClone) ที่เปิดเผยโดยอ็อบเจ็กต์ [SlideCollection](https://reference.aspose.com/slides/th/php-java/aspose.slides/Presentation/#getSlides) และส่งสไลด์จากการนำเสนอแหล่งที่มาที่ต้องการโคลนและมาสเตอร์สไลด์เป็นพารามิเตอร์ให้เมธอด [addClone](https://reference.aspose.com/slides/th/php-java/aspose.slides/SlideCollection/#addClone)
1. เขียนไฟล์การนำเสนอปลายทางที่แก้ไขแล้ว

ในตัวอย่างที่ให้ด้านล่าง เราได้โคลนสไลด์พร้อมมาสเตอร์ (อยู่ที่ดัชนีศูนย์ของการนำเสนอแหล่งที่มา) ไปยังตำแหน่งสุดท้ายของการนำเสนอปลายทางโดยใช้มาสเตอร์จากสไลด์แหล่งที่มา

```php
  # สร้างอินสแตนซ์ของคลาส Presentation เพื่อโหลดไฟล์การนำเสนอแหล่งที่มา
  $srcPres = new Presentation("CloneToAnotherPresentationWithMaster.pptx");
  try {
    # สร้างอินสแตนซ์ของคลาส Presentation สำหรับการนำเสนอปลายทาง (ที่สไลด์จะถูกโคลน)
    $destPres = new Presentation();
    try {
      # สร้างอินสแตนซ์ของ ISlide จากคอลเลกชันสไลด์ในการนำเสนอแหล่งที่มาพร้อมกับ
      # มาสเตอร์สไลด์
      $SourceSlide = $srcPres->getSlides()->get_Item(0);
      $SourceMaster = $SourceSlide->getLayoutSlide()->getMasterSlide();
      # โคลนมาสเตอร์สไลด์ที่ต้องการจากการนำเสนอแหล่งที่มาลงในคอลเลกชันมาสเตอร์ของ
      # การนำเสนอปลายทาง
      $masters = $destPres->getMasters();
      $DestMaster = $SourceSlide->getLayoutSlide()->getMasterSlide();
      # โคลนมาสเตอร์สไลด์ที่ต้องการจากการนำเสนอแหล่งที่มาลงในคอลเลกชันมาสเตอร์ของ
      # การนำเสนอปลายทาง
      $iSlide = $masters->addClone($SourceMaster);
      # โคลนสไลด์ที่ต้องการจากการนำเสนอแหล่งที่มาพร้อมมาสเตอร์ที่ต้องการไปยังตำแหน่งสุดท้ายของ
      # คอลเลกชันสไลด์ในการนำเสนอปลายทาง
      $slds = $destPres->getSlides();
      $slds->addClone($SourceSlide, $iSlide, true);
      # บันทึกการนำเสนอปลายทางลงดิสก์
      $destPres->save("CloneToAnotherPresentationWithMaster_out.pptx", SaveFormat::Pptx);
    } finally {
      $destPres->dispose();
    }
  } finally {
    $srcPres->dispose();
  }
```

## **โคลนสไลด์ที่ตำแหน่งสุดท้ายของส่วนที่ระบุ**
หากคุณต้องการโคลนสไลด์แล้วใช้มันภายในไฟล์การนำเสนอเดียวกันแต่ในส่วนที่แตกต่างกัน แล้วใช้เมธอด [addClone](https://reference.aspose.com/slides/th/php-java/aspose.slides/SlideCollection/#addClone) ที่เปิดเผยโดยคลาส [SlideCollection](https://reference.aspose.com/slides/th/php-java/aspose.slides/SlideCollection) Aspose.Slides for PHP via Java ทำให้สามารถโคลนสไลด์จากส่วนแรกและจากนั้นแทรกสไลด์ที่โคลนไปยังส่วนที่สองของการนำเสนอเดียวกัน

โค้ดตัวอย่างต่อไปนี้จะแสดงวิธีโคลนสไลด์และแทรกสไลด์ที่โคลนเข้าไปในส่วนที่ระบุ

```php
  $presentation = new Presentation();
  try {
    $presentation->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 50, 300, 100);
    $presentation->getSections()->addSection("Section 1", $presentation->getSlides()->get_Item(0));
    $section2 = $presentation->getSections()->appendEmptySection("Section 2");
    $presentation->getSlides()->addClone($presentation->getSlides()->get_Item(0), $section2);
    # บันทึกการนำเสนอปลายทางลงดิสก์
    $presentation->save($dataDir . "CloneSlideIntoSpecifiedSection.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

## **คำถามที่พบบ่อย**

**บันทึกผู้บรรยายและความคิดเห็นของผู้ตรวจสอบจะถูกโคลนหรือไม่?**

ใช่. หน้าโน้ตและความคิดเห็นการตรวจสอบจะถูกรวมอยู่ในคลอน หากคุณไม่ต้องการ them, [ลบออก](/slides/th/php-java/presentation-notes/) หลังจากแทรก

**ข้อมูลแผนภูมิและแหล่งข้อมูลของมันถูกจัดการอย่างไร?**

อ็อบเจ็กต์แผนภูมิ การจัดรูปแบบ และข้อมูลที่ฝังจะถูกคัดลอก หากแผนภูมิถูกเชื่อมโยงกับแหล่งภายนอก (เช่น งานเวิร์กบุ๊กที่ฝัง OLE) การเชื่อมโยงนั้นจะยังคงเป็น [วัตถุ OLE](/slides/th/php-java/manage-ole/) หลังจากย้ายระหว่างไฟล์ ให้ตรวจสอบความพร้อมใช้งานของข้อมูลและพฤติกรรมการรีเฟรช

**ฉันสามารถควบคุมตำแหน่งการแทรกและส่วนสำหรับคลอนได้หรือไม่?**

ใช่. คุณสามารถแทรกคลอนที่ดัชนีสไลด์เฉพาะและวางลงใน [ส่วน](/slides/th/php-java/slide-section/) ที่เลือกได้ หากส่วนเป้าหมายไม่มีอยู่ ให้สร้างส่วนนั้นก่อนแล้วค่อยย้ายสไลด์เข้าไปในนั้น