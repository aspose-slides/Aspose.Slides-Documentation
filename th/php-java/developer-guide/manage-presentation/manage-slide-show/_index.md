---
title: จัดการการแสดงสไลด์ใน PHP
linktitle: การแสดงสไลด์
type: docs
weight: 90
url: /th/php-java/manage-slide-show/
keywords:
- ประเภทการแสดง
- นำเสนอโดยวิทยากร
- เรียกดูโดยบุคคล
- เรียกดูที่คีออส
- ตัวเลือกการแสดง
- วนลูปอย่างต่อเนื่อง
- แสดงโดยไม่มีการบรรยาย
- แสดงโดยไม่มีแอนิเมชัน
- สีปากกา
- แสดงสไลด์
- การแสดงแบบกำหนดเอง
- เลื่อนสไลด์ล่วงหน้า
- ด้วยตนเอง
- ใช้การตั้งเวลา
- PowerPoint
- OpenDocument
- การนำเสนอ
- PHP
- Aspose.Slides
description: "เรียนรู้วิธีจัดการการแสดงสไลด์ใน Aspose.Slides สำหรับ PHP ผ่าน Java ควบคุมการเปลี่ยนสไลด์ การตั้งเวลาและอื่น ๆ อย่างง่ายดายสำหรับรูปแบบ PPT, PPTX และ ODP"
---
## **บทนำ**

ใน Microsoft PowerPoint การตั้งค่า **Slide Show** เป็นเครื่องมือสำคัญสำหรับการเตรียมและนำเสนองานอย่างมืออาชีพ หนึ่งในคุณสมบัติที่สำคัญที่สุดในส่วนนี้คือ **Set Up Show** ซึ่งช่วยให้คุณปรับการนำเสนอให้ตรงกับเงื่อนไขและผู้ชมเฉพาะ ทำให้มีความยืดหยุ่นและสะดวกสบาย ด้วยคุณสมบัตินี้ คุณสามารถเลือกประเภทการแสดง (เช่น นำเสนอโดยวิทยากร, เรียกดูโดยบุคคลหนึ่ง, หรือเรียกดูที่คีออส), เปิดหรือปิดการวนลูป, เลือกสไลด์เฉพาะที่จะแสดง, และใช้การตั้งค่าการเวลา ขั้นตอนนี้เป็นสิ่งสำคัญในการทำให้การนำเสนอของคุณมีประสิทธิภาพและเป็นมืออาชีพมากขึ้น.

`getSlideShowSettings` เป็นเมธอดของคลาส [Presentation](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentation/) ที่ส่งกลับอ็อบเจกต์ประเภท [SlideShowSettings](https://reference.aspose.com/slides/th/php-java/aspose.slides/slideshowsettings/) ซึ่งช่วยให้คุณจัดการการตั้งค่า slide show ในไฟล์ PowerPoint ในบทความนี้ เราจะสำรวจวิธีใช้เมธอดนี้เพื่อกำหนดค่าและควบคุมแง่มุมต่าง ๆ ของการตั้งค่า slide show. 

## **เลือกประเภทการแสดง**

`SlideShowSettings->setSlideShowType` กำหนดประเภทของ slide show ซึ่งสามารถเป็นอินสแตนซ์ของคลาสต่อไปนี้: [PresentedBySpeaker](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentedbyspeaker/), [BrowsedByIndividual](https://reference.aspose.com/slides/th/php-java/aspose.slides/browsedbyindividual/), หรือ [BrowsedAtKiosk](https://reference.aspose.com/slides/th/php-java/aspose.slides/browsedatkiosk/). การใช้เมธอดนี้ทำให้คุณปรับการนำเสนอให้เหมาะกับสถานการณ์การใช้งานที่ต่างกัน เช่น คีออสอัตโนมัติหรือการนำเสนอด้วยตนเอง.

ตัวอย่างโค้ดด้านล่างสร้างการนำเสนอใหม่และตั้งค่าประเภทการแสดงเป็น "Browsed by an individual" โดยไม่แสดงแถบเลื่อน.

```php
$presentation = new Presentation();

$showType = new BrowsedByIndividual();
$showType->setShowScrollbar(false);

$presentation->getSlideShowSettings()->setSlideShowType($showType);

$presentation->save("output.pptx", SaveFormat::Pptx);
$presentation->dispose();
```

## **เปิดใช้งานตัวเลือกการแสดง**

`SlideShowSettings->setLoop` กำหนดว่าการแสดงสไลด์จะทำซ้ำในลูปจนกว่าจะหยุดแบบแมนนวลหรือไม่ ซึ่งเป็นประโยชน์สำหรับการนำเสนออัตโนมัติที่ต้องทำงานต่อเนื่อง `SlideShowSettings->setShowNarration` กำหนดว่าควรเล่นการบรรยายเสียงระหว่าง slide show หรือไม่ ซึ่งมีประโยชน์สำหรับการนำเสนออัตโนมัติที่มีคำแนะนำเสียงสำหรับผู้ชม `SlideShowSettings->setShowAnimation` กำหนดว่าควรเล่นแอนิเมชันที่เพิ่มเข้าไปในวัตถุสไลด์หรือไม่ ซึ่งช่วยให้ได้เอฟเฟกต์ภาพเต็มรูปแบบของการนำเสนอ.

ตัวอย่างโค้ดต่อไปนี้สร้างการนำเสนอใหม่และทำให้ slide show ทำการวนลูป.

```php
$presentation = new Presentation();

$presentation->getSlideShowSettings()->setLoop(true);

$presentation->save("output.pptx", SaveFormat::Pptx);
$presentation->dispose();
```

## **เลือกสไลด์ที่จะแสดง**

เมธอด `SlideShowSettings->setSlides` ให้คุณเลือกช่วงสไลด์ที่จะถูกแสดงระหว่างการนำเสนอ ซึ่งเป็นประโยชน์เมื่อคุณต้องการแสดงเพียงบางส่วนของการนำเสนอ ไม่ใช่ทั้งหมด ตัวอย่างโค้ดต่อไปนี้สร้างการนำเสนอใหม่และตั้งค่าช่วงสไลด์ให้แสดงตั้งแต่สไลด์ `2` ถึง `9`.

```php
$presentation = new Presentation();

$slideRange = new SlidesRange();
$slideRange->setStart(2);
$slideRange->setEnd(9);

$presentation->getSlideShowSettings()->setSlides($slideRange);

$presentation->save("output.pptx", SaveFormat::Pptx);
$presentation->dispose();
```

## **ใช้การเลื่อนสไลด์ล่วงหน้า**

เมธอด `SlideShowSettings->setUseTimings` ให้คุณเปิดหรือปิดการใช้เวลาที่กำหนดล่วงหน้าสำหรับแต่ละสไลด์ ซึ่งเป็นประโยชน์สำหรับการแสดงสไลด์โดยอัตโนมัติที่มีระยะเวลาแสดงที่กำหนดไว้ ตัวอย่างโค้ดด้านล่างสร้างการนำเสนอใหม่และปิดการใช้เวลาที่กำหนดล่วงหน้า.

```php
$presentation = new Presentation();

$presentation->getSlideShowSettings()->setUseTimings(false);

$presentation->save("output.pptx", SaveFormat::Pptx);
$presentation->dispose();
```

## **แสดงการควบคุมสื่อ**

เมธอด `SlideShowSettings->setShowMediaControls` กำหนดว่าการควบคุมสื่อ (เช่น เล่น, หยุดชั่วคราว, และหยุด) ควรแสดงระหว่าง slide show หรือไม่เมื่อมีเนื้อหามัลติมีเดีย (เช่น วิดีโอหรือเสียง) ถูกเล่น ซึ่งเป็นประโยชน์เมื่อคุณต้องการให้ผู้นำเสนอควบคุมการเล่นสื่อในระหว่างการนำเสนอ.

ตัวอย่างโค้ดต่อไปนี้สร้างการนำเสนอใหม่และเปิดการแสดงการควบคุมสื่อ.

```php
$presentation = new Presentation();

$presentation->getSlideShowSettings()->setShowMediaControls(true);

$presentation->save("output.pptx", SaveFormat::Pptx);
$presentation->dispose();
```

## **FAQ**

**ฉันสามารถบันทึกการนำเสนอให้เปิดโดยตรงในโหมด slide show ได้หรือไม่?**

ใช่. บันทึกไฟล์เป็นรูปแบบ PPSX หรือ PPSM; รูปแบบเหล่านี้จะเปิดโดยตรงในโหมด slide show เมื่อเปิดใน PowerPoint ใน Aspose.Slides ให้เลือกรูปแบบการบันทึกที่สอดคล้องกัน [ระหว่างการส่งออก](/slides/th/php-java/save-presentation/).

**ฉันสามารถยกเว้นสไลด์เฉพาะจากการแสดงโดยไม่ลบออกจากไฟล์ได้หรือไม่?**

ใช่. ทำเครื่องหมายสไลด์เป็น [hidden](https://reference.aspose.com/slides/th/php-java/aspose.slides/slide/sethidden/). สไลด์ที่ซ่อนจะยังคงอยู่ในการนำเสนอแต่จะไม่แสดงระหว่าง slide show.

**Aspose.Slides สามารถเล่น slide show หรือควบคุมการนำเสนอสดบนหน้าจอได้หรือไม่?**

ไม่. Aspose.Slides แก้ไข วิเคราะห์ และแปลงไฟล์การนำเสนอ; การเล่นจริงจะถูกจัดการโดยแอพพลิเคชันผู้ชมเช่น PowerPoint.