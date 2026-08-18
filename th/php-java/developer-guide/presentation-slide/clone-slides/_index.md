---
title: โคลนสไลด์การนำเสนอใน PHP
linktitle: โคลนสไลด์
type: docs
weight: 35
url: /th/php-java/clone-slides/
keywords:
- โคลนสไลด์
- คัดลอกสไลด์
- บันทึกสไลด์
- PowerPoint
- OpenDocument
- presentation
- PHP
- Aspose.Slides
description: "ทำสำเนาสไลด์ PowerPoint อย่างรวดเร็วด้วย Aspose.Slides for PHP ปฏิบัติตามตัวอย่างโค้ดที่ชัดเจนของเราเพื่ออัตโนมัติการสร้าง PPT ในไม่กี่วินาทีและกำจัดงานที่ต้องทำด้วยมือ."
---
## **บทนำ**

การโคลนนคือกระบวนการทำสำเนาที่ตรงกันหรือจำลองของบางอย่าง Aspose.Slides for PHP via Java ยังทำให้สามารถสร้างสำเนาหรือโคลนของสไลด์ใดก็ได้และจากนั้นแทรกสไลด์ที่ถูกโคลนนั้นไปยังงานนำเสนอที่กำลังเปิดอยู่หรือใดก็ได้ กระบวนการโคลนสไลด์สร้างสไลด์ใหม่ที่นักพัฒนาสามารถแก้ไขได้โดยไม่เปลี่ยนแปลงสไลด์ต้นฉบับ มีวิธีการโคลนสไลด์หลายวิธีดังต่อไปนี้:

- โคลนที่ตำแหน่งสุดท้ายภายในงานนำเสนอหนึ่ง
- โคลนที่ตำแหน่งอื่นภายในงานนำเสนอเดียวกัน
- โคลนที่ตำแหน่งสุดท้ายในงานนำเสนออื่น
- โคลนที่ตำแหน่งอื่นในงานนำเสนออื่น
- โคลนที่ตำแหน่งเฉพาะในงานนำเสนออื่น

ใน Aspose.Slides for PHP via Java (คอลเลกชันของวัตถุ [Slide](https://reference.aspose.com/slides/th/php-java/aspose.slides/Slide) ) ที่เปิดเผยโดยวัตถุ [Presentation](https://reference.aspose.com/slides/th/php-java/aspose.slides/Presentation) มีเมธอด [addClone](https://reference.aspose.com/slides/th/php-java/aspose.slides/SlideCollection/#addClone) และ [insertClone](https://reference.aspose.com/slides/th/php-java/aspose.slides/SlideCollection/#insertClone) เพื่อดำเนินการโคลนสไลด์ตามประเภทที่กล่าวข้างต้น

## **โคลนสไลด์ที่ตำแหน่งสุดท้ายของงานนำเสนอ**
ถ้าต้องการโคลนสไลด์แล้วใช้ในไฟล์งานนำเสนอเดียวกันที่ตำแหน่งท้ายของสไลด์ที่มีอยู่ ใช้เมธอด [addClone](https://reference.aspose.com/slides/th/php-java/aspose.slides/SlideCollection/#addClone) ตามขั้นตอนต่อไปนี้:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/php-java/aspose.slides/Presentation)
2. รับอ็อบเจ็กต์ [SlideCollection](https://reference.aspose.com/slides/th/php-java/aspose.slides/Presentation/#getSlides) โดยอ้างอิงคอลเลกชันสไลด์ที่เปิดเผยโดยวัตถุ [Presentation](https://reference.aspose.com/slides/th/php-java/aspose.slides/Presentation)
3. เรียกเมธอด [addClone](https://reference.aspose.com/slides/th/php-java/aspose.slides/SlideCollection/#addClone) ที่เปิดเผยโดยอ็อบเจ็กต์ [SlideCollection](https://reference.aspose.com/slides/th/php-java/aspose.slides/Presentation/#getSlides) และส่งสไลด์ที่ต้องการโคลนเป็นพารามิวเตอร์ให้เมธอด [addClone](https://reference.aspose.com/slides/th/php-java/aspose.slides/SlideCollection/#addClone)
4. บันทึกไฟล์งานนำเสนอที่แก้ไขแล้ว

ในตัวอย่างด้านล่าง เราได้โคลนสไลด์ (อยู่ที่ตำแหน่งแรก – ดัชนีศูนย์ – ของงานนำเสนอ) ไปยังตำแหน่งสุดท้ายของงานนำเสนอ

```php
  # สร้างอินสแตนซ์ของคลาส Presentation ที่เป็นตัวแทนไฟล์งานนำเสนอ
  $pres = new Presentation("CloneWithinSamePresentationToEnd.pptx");
  try {
    # โคลนสไลด์ที่ต้องการไปยังตำแหน่งสุดท้ายของคอลเลกชันสไลด์ในงานนำเสนอเดียวกัน
    $slds = $pres->getSlides();
    $slds->addClone($pres->getSlides()->get_Item(0));
    # บันทึกงานนำเสนอที่แก้ไขแล้วลงดิสก์
    $pres->save("Aspose_CloneWithinSamePresentationToEnd_out.pptx", SaveFormat::Pptx);
  } finally {
    $pres->dispose();
  }
```

## **โคลนสไลด์ไปยังตำแหน่งอื่นภายในงานนำเสนอ**
ถ้าต้องการโคลนสไลด์แล้วใช้ในไฟล์งานนำเสนอเดียวกันแต่ตำแหน่งต่างออกไป ใช้เมธอด [insertClone](https://reference.aspose.com/slides/th/php-java/aspose.slides/SlideCollection/#insertClone) :

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/php-java/aspose.slides/Presentation)
2. รับอ็อบเจ็กต์ [SlideCollection](https://reference.aspose.com/slides/th/php-java/aspose.slides/SlideCollection) โดยอ้างอิงคอลเลกชัน [**Slides**](https://reference.aspose.com/slides/th/php-java/aspose.slides/Presentation/#getSlides) ที่เปิดเผยโดยวัตถุ [Presentation](https://reference.aspose.com/slides/th/php-java/aspose.slides/Presentation)
3. เรียกเมธอด [insertClone](https://reference.aspose.com/slides/th/php-java/aspose.slides/SlideCollection/#insertClone) ที่เปิดเผยโดยอ็อบเจ็กต์ [SlideCollection](https://reference.aspose.com/slides/th/php-java/aspose.slides/Presentation/#getSlides) และส่งสไลด์ที่ต้องการโคลนพร้อมกับดัชนีของตำแหน่งใหม่เป็นพารามิวเตอร์ให้เมธอด [insertClone](https://reference.aspose.com/slides/th/php-java/aspose.slides/SlideCollection/#insertClone)
4. บันทึกไฟล์งานนำเสนอที่แก้ไขแล้วเป็นไฟล์ PPTX

ในตัวอย่างด้านล่าง เราได้โคลนสไลด์ (อยู่ที่ดัชนีศูนย์ – ตำแหน่ง 1 – ของงานนำเสนอ) ไปยังดัชนี 1 – ตำแหน่ง 2 – ของงานนำเสนอ

```php
  # สร้างอินสแตนซ์ของคลาส Presentation ที่เป็นตัวแทนไฟล์งานนำเสนอ
  $pres = new Presentation("CloneWithInSamePresentation.pptx");
  try {
    # โคลนสไลด์ที่ต้องการไปยังตำแหน่งสุดท้ายของคอลเลกชันสไลด์ในงานนำเสนอเดียวกัน
    $slds = $pres->getSlides();
    # โคลนสไลด์ที่ต้องการไปยังดัชนีที่ระบุในงานนำเสนอเดียวกัน
    $slds->insertClone(2, $pres->getSlides()->get_Item(1));
    # บันทึกงานนำเสนอที่แก้ไขแล้วลงดิสก์
    $pres->save("Aspose_CloneWithInSamePresentation_out.pptx", SaveFormat::Pptx);
  } finally {
    $pres->dispose();
  }
```

## **โคลนสไลด์ที่ตำแหน่งสุดท้ายของงานนำเสนออื่น**
ถ้าต้องการโคลนสไลด์จากงานนำเสนอหนึ่งและใช้ในไฟล์งานนำเสนออื่น ที่ตำแหน่งสุดท้ายของสไลด์ที่มีอยู่:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/php-java/aspose.slides/Presentation) ที่ประกอบด้วยงานนำเสนอซึ่งสไลด์จะถูกโคลนจาก
2. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/php-java/aspose.slides/Presentation) ที่ประกอบด้วยงานนำเสนอปลายทางที่สไลด์จะถูกเพิ่มเข้าไป
3. รับอ็อบเจ็กต์ [SlideCollection](https://reference.aspose.com/slides/th/php-java/aspose.slides/SlideCollection) โดยอ้างอิงคอลเลกชัน [**Slides**](https://reference.aspose.com/slides/th/php-java/aspose.slides/Presentation/#getSlides) ที่เปิดเผยโดยวัตถุ Presentation ของงานนำเสนอปลายทาง
4. เรียกเมธอด [addClone](https://reference.aspose.com/slides/th/php-java/aspose.slides/SlideCollection/#addClone) ที่เปิดเผยโดยอ็อบเจ็กต์ [SlideCollection](https://reference.aspose.com/slides/th/php-java/aspose.slides/Presentation/#getSlides) และส่งสไลด์จากงานนำเสนอแหล่งที่มเป็นพารามิวเตอร์ให้เมธอด [addClone](https://reference.aspose.com/slides/th/php-java/aspose.slides/SlideCollection/#addClone)
5. บันทึกไฟล์งานนำเสนอปลายทางที่แก้ไขแล้ว

ในตัวอย่างด้านล่าง เราได้โคลนสไลด์ (จากดัชนีแรกของงานนำเสนอแหล่งที่มา) ไปยังตำแหน่งสุดท้ายของงานนำเสนอปลายทาง

```php
  # สร้างอินสแตนซ์ของคลาส Presentation เพื่อโหลดไฟล์งานนำเสนอแหล่งที่มา
  $srcPres = new Presentation("CloneAtEndOfAnother.pptx");
  try {
    # สร้างอินสแตนซ์ของคลาส Presentation สำหรับไฟล์ PPTX ปลายทาง (ที่สไลด์จะถูกโคลน)
    $destPres = new Presentation();
    try {
      # โคลนสไลด์ที่ต้องการจากงานนำเสนอแหล่งที่มาไปยังตำแหน่งสุดท้ายของคอลเลกชันสไลด์ในงานนำเสนอปลายทาง
      $slds = $destPres->getSlides();
      $slds->addClone($srcPres->getSlides()->get_Item(0));
      # บันทึกงานนำเสนอปลายทางลงดิสก์
      $destPres->save("Aspose2_out.pptx", SaveFormat::Pptx);
    } finally {
      $destPres->dispose();
    }
  } finally {
    $srcPres->dispose();
  }
```

## **โคลนสไลด์ไปยังตำแหน่งอื่นในงานนำเสนออื่น**
ถ้าต้องการโคลนสไลด์จากงานนำเสนอหนึ่งและใช้ในงานนำเสนออื่นที่ตำแหน่งเฉพาะ:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/php-java/aspose.slides/Presentation) ที่ประกอบด้วยงานนำเสนอแหล่งที่มาที่สไลด์จะถูกโคลนจาก
2. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/php-java/aspose.slides/Presentation) ที่ประกอบด้วยงานนำเสนอที่สไลด์จะถูกเพิ่มเข้าไป
3. รับคลาส [SlideCollection](https://reference.aspose.com/slides/th/php-java/aspose.slides/Presentation/#getSlides) โดยอ้างอิงคอลเลกชัน Slides ที่เปิดเผยโดยวัตถุ Presentation ของงานนำเสนอปลายทาง
4. เรียกเมธอด [insertClone](https://reference.aspose.com/slides/th/php-java/aspose.slides/SlideCollection/#insertClone) ที่เปิดเผยโดยอ็อบเจ็กต์ [SlideCollection](https://reference.aspose.com/slides/th/php-java/aspose.slides/Presentation/#getSlides) และส่งสไลด์จากงานนำเสนอแหล่งที่มาพร้อมกับตำแหน่งที่ต้องการเป็นพารามิวเตอร์ให้เมธอด [insertClone](https://reference.aspose.com/slides/th/php-java/aspose.slides/SlideCollection/#insertClone)
5. บันทึกไฟล์งานนำเสนอปลายทางที่แก้ไขแล้ว

ในตัวอย่างด้านล่าง เราได้โคลนสไลด์ (จากดัชนีศูนย์ของงานนำเสนอแหล่งที่มา) ไปยังดัชนี 1 (ตำแหน่ง 2) ของงานนำเสนอปลายทาง

```php
  # สร้างอินสแตนซ์ของคลาส Presentation เพื่อโหลดไฟล์งานนำเสนอแหล่งที่มา
  $srcPres = new Presentation("CloneAtEndOfAnother.pptx");
  try {
    # สร้างอินสแตนซ์ของคลาส Presentation สำหรับไฟล์ PPTX ปลายทาง (ที่สไลด์จะถูกโคลน)
    $destPres = new Presentation();
    try {
      # โคลนสไลด์ที่ต้องการจากงานนำเสนอแหล่งที่มาไปยังตำแหน่งสุดท้ายของคอลเลกชันสไลด์ในงานนำเสนอปลายทาง
      $slds = $destPres->getSlides();
      $slds->insertClone(2, $srcPres->getSlides()->get_Item(0));
      # บันทึกงานนำเสนอปลายทางลงดิสก์
      $destPres->save("Aspose2_out.pptx", SaveFormat::Pptx);
    } finally {
      $destPres->dispose();
    }
  } finally {
    $srcPres->dispose();
  }
```

## **โคลนสไลด์ที่ตำแหน่งเฉพาะในงานนำเสนออื่น**
ถ้าต้องการโคลนสไลด์พร้อมมาสเตอร์สไลด์จากงานนำเสนอหนึ่งและใช้ในงานนำเสนออื่น คุณต้องโคลนมาสเตอร์สไลด์ที่ต้องการจากงานนำเสนอแหล่งที่มาลงในงานนำเสนอปลายทางก่อน แล้วจึงใช้มาสเตอร์สไลด์นั้นเพื่อโคลนสไลด์ที่มีมาสเตอร์ [**addClone(Slide, MasterSlide, boolean)**](https://reference.aspose.com/slides/th/php-java/aspose.slides/slidecollection/addclone/) ต้องการมาสเตอร์สไลด์จากงานนำเสนอปลายทางไม่ใช่จากแหล่งที่มา เพื่อโคลนสไลด์พร้อมมาสเตอร์ ให้ทำตามขั้นตอนต่อไปนี้:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/php-java/aspose.slides/Presentation) ที่ประกอบด้วยงานนำเสนอแหล่งที่มาที่สไลด์จะถูกโคลนจาก
2. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/php-java/aspose.slides/Presentation) ที่ประกอบด้วยงานนำเสนอปลายทางที่สไลด์จะถูกโคลนไป
3. เข้าถึงสไลด์ที่ต้องการโคลนพร้อมกับมาสเตอร์สไลด์
4. สร้างอ็อบเจ็กต์ [MasterSlideCollection](https://reference.aspose.com/slides/th/php-java/aspose.slides/MasterSlideCollection) โดยอ้างอิงคอลเลกชัน Masters ที่เปิดเผยโดยวัตถุ [Presentation](https://reference.aspose.com/slides/th/php-java/aspose.slides/Presentation) ของงานนำเสนอปลายทาง
5. เรียกเมธอด [addClone](https://reference.aspose.com/slides/th/php-java/aspose.slides/SlideCollection/#addClone) ที่เปิดเผยโดยอ็อบเจ็กต์ [MasterSlideCollection](https://reference.aspose.com/slides/th/php-java/aspose.slides/MasterSlideCollection) และส่งมาสเตอร์จากไฟล์ PPTX แหล่งที่มาที่จะถูกโคลนเป็นพารามิวเตอร์ให้เมธอด [addClone](https://reference.aspose.com/slides/th/php-java/aspose.slides/SlideCollection/#addClone)
6. สร้างอ็อบเจ็กต์ [SlideCollection](https://reference.aspose.com/slides/th/php-java/aspose.slides/Presentation/#getSlides) โดยตั้งค่าอ้างอิงไปยังคอลเลกชัน Slides ที่เปิดเผยโดยวัตถุ [Presentation](https://reference.aspose.com/slides/th/php-java/aspose.slides/Presentation) ของงานนำเสนอปลายทาง
7. เรียกเมธอด [addClone](https://reference.aspose.com/slides/th/php-java/aspose.slides/SlideCollection/#addClone) ที่เปิดเผยโดยอ็อบเจ็กต์ [SlideCollection](https://reference.aspose.com/slides/th/php-java/aspose.slides/Presentation/#getSlides) และส่งสไลด์จากงานนำเสนอแหล่งที่มาที่จะถูกโคลนพร้อมมาสเตอร์สไลด์เป็นพารามิวเตอร์ให้เมธอด [addClone](https://reference.aspose.com/slides/th/php-java/aspose.slides/SlideCollection/#addClone)
8. บันทึกไฟล์งานนำเสนอปลายทางที่แก้ไขแล้ว

ในตัวอย่างด้านล่าง เราได้โคลนสไลด์พร้อมมาสเตอร์ (อยู่ที่ดัชนีศูนย์ของงานนำเสนอแหล่งที่มา) ไปยังตำแหน่งสุดท้ายของงานนำเสนอปลายทางโดยใช้มาสเตอร์จากสไลด์แหล่งที่มา

```php
  # สร้างอินสแตนซ์ของคลาส Presentation เพื่อโหลดไฟล์งานนำเสนอแหล่งที่มา
  $srcPres = new Presentation("CloneToAnotherPresentationWithMaster.pptx");
  try {
    # สร้างอินสแตนซ์ของคลาส Presentation สำหรับงานนำเสนอปลายทาง (ที่สไลด์จะถูกโคลน)
    $destPres = new Presentation();
    try {
      # สร้างอินสแตนซ์ของ ISlide จากคอลเลกชันสไลด์ในงานนำเสนอแหล่งที่มาตามด้วย
      # มาสเตอร์สไลด์
      $SourceSlide = $srcPres->getSlides()->get_Item(0);
      $SourceMaster = $SourceSlide->getLayoutSlide()->getMasterSlide();
      # โคลนมาสเตอร์สไลด์ที่ต้องการจากงานนำเสนอแหล่งที่มาไปยังคอลเลกชันมาสเตอร์ใน
      # งานนำเสนอปลายทาง
      $masters = $destPres->getMasters();
      $DestMaster = $SourceSlide->getLayoutSlide()->getMasterSlide();
      # โคลนมาสเตอร์สไลด์ที่ต้องการจากงานนำเสนอแหล่งที่มาไปยังคอลเลกชันมาสเตอร์ใน
      # งานนำเสนอปลายทาง
      $iSlide = $masters->addClone($SourceMaster);
      # โคลนสไลด์ที่ต้องการจากงานนำเสนอแหล่งที่มาตามด้วยมาสเตอร์ที่ต้องการไปยังตำแหน่งสุดท้ายของ
      # คอลเลกชันสไลด์ในงานนำเสนอปลายทาง
      $slds = $destPres->getSlides();
      $slds->addClone($SourceSlide, $iSlide, true);
      # บันทึกงานนำเสนอปลายทางลงดิสก์
      $destPres->save("CloneToAnotherPresentationWithMaster_out.pptx", SaveFormat::Pptx);
    } finally {
      $destPres->dispose();
    }
  } finally {
    $srcPres->dispose();
  }
```

## **โคลนสไลด์ที่ตำแหน่งสุดท้ายของส่วนที่ระบุ**
ถ้าต้องการโคลนสไลด์แล้วใช้ในไฟล์งานนำเสนอเดียวกันแต่ในส่วนที่ต่างออกไป ให้ใช้เมธอด [addClone](https://reference.aspose.com/slides/th/php-java/aspose.slides/SlideCollection/#addClone) ที่เปิดเผยโดยคลาส [SlideCollection](https://reference.aspose.com/slides/th/php-java/aspose.slides/SlideCollection) Aspose.Slides for PHP via Java ทำให้สามารถโคลนสไลด์จากส่วนแรกแล้วแทรกสไลด์ที่ถูกโคลนไปยังส่วนที่สองของงานนำเสนอเดียวกันได้

โค้ดตัวอย่างต่อไปนี้แสดงวิธีโคลนสไลด์และแทรกสไลด์ที่ถูกโคลนลงในส่วนที่ระบุ

```php
  $presentation = new Presentation();
  try {
    $presentation->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 50, 300, 100);
    $presentation->getSections()->addSection("Section 1", $presentation->getSlides()->get_Item(0));
    $section2 = $presentation->getSections()->appendEmptySection("Section 2");
    $presentation->getSlides()->addClone($presentation->getSlides()->get_Item(0), $section2);
    # บันทึกงานนำเสนอปลายทางลงดิสก์
    $presentation->save("CloneSlideIntoSpecifiedSection.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

## **ตรวจสอบให้ขนาดสไลด์ตรงกัน**

เมื่อโคลนสไลด์ไปยังงานนำเสนออื่น ให้ตรวจสอบว่าขนาดสไลด์ของงานนำเสนอปลายทางตรงกับงานนำเสนอแหล่งที่มาหรือไม่ หากขนาดสไลด์แตกต่างกัน Aspose.Slides จะไม่ปรับขนาดรูปทรงที่ถูกโคลนโดยอัตโนมัติ – พิกัดและมิติเดิมจะคงอยู่ ซึ่งอาจทำให้เนื้อหาเห็นเบี่ยงเบนหรือยืดเกินขอบสไลด์

คุณสามารถตั้งค่าขนาดสไลด์ของงานนำเสนอปลายทางให้ตรงกับแหล่งที่มาก่อนทำการโคลนมาสเตอร์และสไลด์ได้:

```php
$sourceSize = $sourcePresentation->getSlideSize()->getSize();

$targetPresentation->getSlideSize()->setSize(
    $sourceSize->getWidth(), $sourceSize->getHeight(), SlideSizeScaleType::DoNotScale);
```

ทำขั้นตอนนี้ก่อนโคลนมาสเตอร์และสไลด์

## **คำถามที่พบบ่อย**

**โน้ตของผู้พูดและความคิดเห็นของผู้ตรวจสอบจะถูกโคลนหรือไม่?**

ใช่. หน้าจดหมายเหตุและความคิดเห็นการรีวิวจะถูกรวมอยู่ในโคลน หากคุณไม่ต้องการให้มีเหล่านั้น ให้ [ลบออก](/slides/th/php-java/presentation-notes/) หลังจากแทรก

**แผนภูมิและแหล่งข้อมูลของพวกมันจะถูกจัดการอย่างไร?**

อ็อบเจ็กต์ของแผนภูมิ การจัดรูปแบบ และข้อมูลที่ฝังจะถูกคัดลอก หากแผนภูมิถูกเชื่อมโยงกับแหล่งข้อมูลภายนอก (เช่น เวิร์กบุ๊กที่ฝังเป็น OLE) การเชื่อมโยงนั้นจะถูกเก็บเป็น [OLE object](/slides/th/php-java/manage-ole/). หลังจากย้ายไฟล์ ควรตรวจสอบความพร้อมของข้อมูลและพฤติกรรมการรีเฟรช

**ฉันสามารถควบคุมตำแหน่งการแทรกและส่วนต่าง ๆ ของการโคลนได้หรือไม่?**

ได้. คุณสามารถแทรกโคลนที่ดัชนีสไลด์ที่ระบุและวางลงใน [section](/slides/th/php-java/slide-section/) ที่เลือกได้ หากส่วนเป้าหมายยังไม่มี ให้สร้างส่วนนั้นก่อนแล้วย้ายสไลด์เข้าไปในส่วนนั้น