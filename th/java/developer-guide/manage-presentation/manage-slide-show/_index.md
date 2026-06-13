---
title: จัดการการแสดงสไลด์ใน Java
linktitle: การแสดงสไลด์
type: docs
weight: 90
url: /th/java/manage-slide-show/
keywords:
- ชนิดการแสดง
- นำเสนอโดยผู้บรรยาย
- เรียกดูโดยบุคคล
- เรียกดูที่คีออส
- ตัวเลือกการแสดง
- วนลูปต่อเนื่อง
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
- Java
- Aspose.Slides
description: "เรียนรู้วิธีจัดการการแสดงสไลด์ใน Aspose.Slides สำหรับ Java ควบคุมการเปลี่ยนสไลด์, การตั้งเวลาและอื่น ๆ อีกมากมายในรูปแบบ PPT, PPTX และ ODP อย่างง่ายดาย."
---
## **บทนำ**

ใน Microsoft PowerPoint การตั้งค่า **Slide Show** เป็นเครื่องมือสำคัญสำหรับการเตรียมและนำเสนอการนำเสนอระดับมืออาชีพ หนึ่งในฟีเจอร์ที่สำคัญที่สุดในส่วนนี้คือ **Set Up Show** ซึ่งช่วยให้คุณปรับการนำเสนอให้เหมาะกับเงื่อนไขและผู้ชมเฉพาะ ทำให้มีความยืดหยุ่นและสะดวกสบาย ด้วยฟีเจอร์นี้ คุณสามารถเลือกประเภทการแสดง (เช่น presented by a speaker, browsed by an individual, or browsed at a kiosk), เปิดหรือปิดการวนลูป, เลือกสไลด์เฉพาะที่จะให้แสดง, และใช้การตั้งเวลา ขั้นตอนการเตรียมนี้มีความสำคัญต่อการทำให้การนำเสนอของคุณมีประสิทธิภาพและเป็นมืออาชีพมากขึ้น.

`getSlideShowSettings` เป็นเมธอดของคลาส [Presentation](https://reference.aspose.com/slides/th/java/com.aspose.slides/presentation/) ที่คืนค่าเป็นอ็อบเจกต์ประเภท [SlideShowSettings](https://reference.aspose.com/slides/th/java/com.aspose.slides/slideshowsettings/) ซึ่งช่วยให้คุณจัดการการตั้งค่า slide show ในการนำเสนอ PowerPoint ในบทความนี้ เราจะสำรวจวิธีใช้เมธอดนี้เพื่อกำหนดค่าและควบคุมแง่มุมต่าง ๆ ของการตั้งค่า slide show.

## **เลือกประเภทการแสดง**

`SlideShowSettings.setSlideShowType` กำหนดประเภทของ slide show ซึ่งอาจเป็นอินสแตนซ์ของคลาสต่อไปนี้: [PresentedBySpeaker](https://reference.aspose.com/slides/th/java/com.aspose.slides/presentedbyspeaker/), [BrowsedByIndividual](https://reference.aspose.com/slides/th/java/com.aspose.slides/browsedbyindividual/), หรือ [BrowsedAtKiosk](https://reference.aspose.com/slides/th/java/com.aspose.slides/browsedatkiosk/). การใช้เมธอดนี้ทำให้คุณปรับการนำเสนอให้เหมาะกับสถานการณ์การใช้งานต่าง ๆ เช่น คีออสอัตโนมัติหรือการนำเสนอแบบมือ

ตัวอย่างโค้ดด้านล่างสร้างการนำเสนอใหม่และตั้งประเภทการแสดงเป็น "Browsed by an individual" โดยไม่แสดงแถบเลื่อน.

```java
Presentation presentation = new Presentation();

BrowsedByIndividual showType = new BrowsedByIndividual();
showType.setShowScrollbar(false);

presentation.getSlideShowSettings().setSlideShowType(showType);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **เปิดใช้งานตัวเลือกการแสดง**

`SlideShowSettings.setLoop` กำหนดว่า slide show ควรทำซ้ำในลูปจนกว่าจะหยุดโดยมือหรือไม่ ซึ่งเป็นประโยชน์สำหรับการนำเสนออัตโนมัติที่ต้องทำงานต่อเนื่อง `SlideShowSettings.setShowNarration` กำหนดว่าจะเล่นการบรรยายด้วยเสียงระหว่าง slide show หรือไม่ ซึ่งเป็นประโยชน์สำหรับการนำเสนออัตโนมัติที่มีคำแนะนำเสียงสำหรับผู้ชม `SlideShowSettings.setShowAnimation` กำหนดว่าจะเล่นแอนิเมชันที่เพิ่มไปยังวัตถุสไลด์หรือไม่ ซึ่งช่วยให้ได้เอฟเฟกต์ภาพเต็มรูปแบบของการนำเสนอ

ตัวอย่างโค้ดต่อไปนี้สร้างการนำเสนอใหม่และทำให้ slide show ทำวนลูป.

```java
Presentation presentation = new Presentation();

presentation.getSlideShowSettings().setLoop(true);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **เลือกสไลด์ที่จะแสดง**

`SlideShowSettings.setSlides` เมธอดช่วยให้คุณเลือกช่วงของสไลด์ที่จะให้แสดงระหว่างการนำเสนอ ซึ่งเป็นประโยชน์เมื่อคุณต้องการแสดงเฉพาะบางส่วนของการนำเสนอแทนที่จะแสดงทั้งหมด ตัวอย่างโค้ดต่อไปนี้สร้างการนำเสนอใหม่และตั้งช่วงสไลด์ให้แสดงจากสไลด์ `2` ถึง `9`.

```java
Presentation presentation = new Presentation();

SlidesRange slideRange = new SlidesRange();
slideRange.setStart(2);
slideRange.setEnd(9);

presentation.getSlideShowSettings().setSlides(slideRange);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **ใช้สไลด์ล่วงหน้า**

`SlideShowSettings.setUseTimings` เมธอดช่วยให้คุณเปิดหรือปิดการใช้การตั้งเวลาแบบกำหนดล่วงหน้าสำหรับแต่ละสไลด์ ซึ่งเป็นประโยชน์สำหรับการแสดงสไลด์โดยอัตโนมัติตามระยะเวลาที่กำหนดไว้ ตัวอย่างโค้ดด้านล่างสร้างการนำเสนอใหม่และปิดการใช้การตั้งเวลา.

```java
Presentation presentation = new Presentation();

presentation.getSlideShowSettings().setUseTimings(false);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **แสดงการควบคุมสื่อ**

`SlideShowSettings.setShowMediaControls` เมธอดกำหนดว่าควรแสดงการควบคุมสื่อ (เช่น เล่น, หยุดชั่วคราว, และหยุด) ในระหว่าง slide show เมื่อมีเนื้อหามัลติมีเดีย (เช่น วิดีโอหรือเสียง) ถูกเล่นหรือไม่ ซึ่งเป็นประโยชน์เมื่อคุณต้องการให้ผู้นำเสนอควบคุมการเล่นสื่อระหว่างการนำเสนอ

ตัวอย่างโค้ดต่อไปนี้สร้างการนำเสนอใหม่และเปิดใช้งานการแสดงการควบคุมสื่อ.

```java
Presentation presentation = new Presentation();

presentation.getSlideShowSettings().setShowMediaControls(true);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **คำถามที่พบบ่อย**

**ฉันสามารถบันทึกการนำเสนอให้เปิดโดยตรงในโหมดสไลด์โชว์ได้หรือไม่?**

ใช่ บันทึกไฟล์เป็นนามสกุล PPSX หรือ PPSM; ฟอร์แมตเหล่านี้จะเปิดโดยตรงในโหมดสไลด์โชว์เมื่อเปิดใน PowerPoint ใน Aspose.Slides ให้เลือกฟอร์แมตการบันทึกที่สอดคล้องกันระหว่างการส่งออก [during export](/slides/th/java/save-presentation/).

**ฉันสามารถยกเว้นสไลด์เดี่ยวจากการแสดงโดยไม่ลบออกจากไฟล์ได้หรือไม่?**

ใช่ ให้ทำเครื่องหมายสไลด์เป็น [hidden](https://reference.aspose.com/slides/th/java/com.aspose.slides/slide/#setHidden-boolean-). สไลด์ที่ซ่อนอยู่จะยังคงอยู่ในการนำเสนอแต่จะไม่แสดงในระหว่าง slide show.

**Aspose.Slides สามารถเล่นสไลด์โชว์หรือควบคุมการนำเสนอสดบนหน้าจอได้หรือไม่?**

ไม่ Aspose.Slides ทำการแก้ไข วิเคราะห์ และแปลงไฟล์การนำเสนอ; การเล่นจริงจะดำเนินการโดยแอปพลิเคชันผู้ดูเช่น PowerPoint.