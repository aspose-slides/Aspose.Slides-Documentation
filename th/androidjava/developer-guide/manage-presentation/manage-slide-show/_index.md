---
title: จัดการการแสดงสไลด์บน Android
linktitle: การแสดงสไลด์
type: docs
weight: 90
url: /th/androidjava/manage-slide-show/
keywords:
- ประเภทการแสดง
- นำเสนอโดยผู้พูด
- เรียกดูโดยบุคคล
- เรียกดูที่คีออส
- ตัวเลือกการแสดง
- วนซ้ำต่อเนื่อง
- แสดงโดยไม่มีการบรรยาย
- แสดงโดยไม่มีแอนิเมชัน
- สีของปากกา
- แสดงสไลด์
- การแสดงแบบกำหนดเอง
- เลื่อนสไลด์ล่วงหน้า
- ด้วยตนเอง
- ใช้การตั้งเวลา
- PowerPoint
- OpenDocument
- งานนำเสนอ
- Android
- Java
- Aspose.Slides
description: "เรียนรู้วิธีจัดการการแสดงสไลด์ใน Aspose.Slides สำหรับ Android ด้วย Java ควบคุมการเปลี่ยนสไลด์, การตั้งเวลาและอื่น ๆ ได้อย่างง่ายดายในรูปแบบ PPT, PPTX และ ODP"
---
## **บทนำ**

ใน Microsoft PowerPoint การตั้งค่า **Slide Show** เป็นเครื่องมือสำคัญสำหรับการเตรียมและนำเสนอการพรีเซนเทชั่นระดับมืออาชีพ หนึ่งในคุณสมบัติที่สำคัญที่สุดในส่วนนี้คือ **Set Up Show** ซึ่งอนุญาตให้คุณปรับการพรีเซนเทชั่นให้ตรงกับเงื่อนไขและผู้ชมเฉพาะ ทำให้มีความยืดหยุ่นและสะดวกสบาย ด้วยคุณสมบัตินี้ คุณสามารถเลือกประเภทการแสดง (เช่น การนำเสนอโดยผู้พูด, การเรียกดูโดยบุคคลหนึ่ง, หรือการเรียกดูที่คีออส) เปิดหรือปิดการวนซ้ำ, เลือกสไลด์เฉพาะที่จะทำการแสดง, และใช้การตั้งเวลา ขั้นตอนการเตรียมนี้มีความสำคัญต่อการทำให้การพรีเซนเทชั่นของคุณมีประสิทธิภาพและเป็นมืออาชีพยิ่งขึ้น.

`getSlideShowSettings` เป็นเมธอดของคลาส [Presentation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/presentation/) ที่คืนค่าอ็อบเจ็กต์ชนิด [SlideShowSettings](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/slideshowsettings/) ซึ่งช่วยให้คุณจัดการการตั้งค่า slide show ในการพรีเซนเทชั่น PowerPoint ได้ ในบทความนี้เราจะสำรวจวิธีการใช้เมธอดนี้เพื่อกำหนดค่าและควบคุมแง่มุมต่าง ๆ ของการตั้งค่า slide show.

## **เลือกประเภทการแสดง**

`SlideShowSettings.setSlideShowType` กำหนดประเภทของ slide show ซึ่งสามารถเป็นอินสแตนซ์ของคลาสต่อไปนี้: [PresentedBySpeaker](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/presentedbyspeaker/), [BrowsedByIndividual](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/browsedbyindividual/), หรือ [BrowsedAtKiosk](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/browsedatkiosk/). การใช้เมธอดนี้ช่วยให้คุณปรับการพรีเซนเทชั่นให้เหมาะกับสถานการณ์การใช้งานที่แตกต่างกัน เช่น คีออสอัตโนมัติหรือการพรีเซนเทชั่นด้วยมือ.

ตัวอย่างโค้ดด้านล่างสร้างพรีเซนเทชั่นใหม่และตั้งประเภทการแสดงเป็น "Browsed by an individual" โดยไม่แสดงแถบเลื่อน.

```java
Presentation presentation = new Presentation();

BrowsedByIndividual showType = new BrowsedByIndividual();
showType.setShowScrollbar(false);

presentation.getSlideShowSettings().setSlideShowType(showType);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **เปิดใช้งานตัวเลือกการแสดง**

`SlideShowSettings.setLoop` กำหนดว่าการแสดงสไลด์จะทำซ้ำเป็นลูปจนกว่าจะหยุดด้วยตนเองหรือไม่ การตั้งค่านี้เป็นประโยชน์สำหรับการพรีเซนเทชั่นอัตโนมัติที่ต้องทำงานต่อเนื่อง `SlideShowSettings.setShowNarration` กำหนดว่าจะเล่นการบรรยายเสียงระหว่างการแสดงสไลด์หรือไม่ ซึ่งเป็นประโยชน์สำหรับการพรีเซนเทชั่นอัตโนมัติที่มีคำแนะนำด้วยเสียงสำหรับผู้ชม `SlideShowSettings.setShowAnimation` กำหนดว่าจะเล่นแอนิเมชันที่เพิ่มลงในวัตถุสไลด์หรือไม่ ซึ่งช่วยให้ได้เอฟเฟกต์ภาพที่ครบถ้วนของการพรีเซนเทชั่น.

โค้ดตัวอย่างต่อไปนี้สร้างพรีเซนเทชั่นใหม่และทำให้การแสดงสไลด์วนซ้ำ.

```java
Presentation presentation = new Presentation();

presentation.getSlideShowSettings().setLoop(true);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **เลือกสไลด์ที่จะแสดง**

`SlideShowSettings.setSlides` เมธอดนี้อนุญาตให้คุณเลือกช่วงของสไลด์ที่จะถูกแสดงระหว่างการพรีเซนเทชั่น ซึ่งเป็นประโยชน์เมื่อคุณต้องการแสดงเพียงบางส่วนของการพรีเซนเทชั่นแทนที่จะแสดงทั้งหมด ตัวอย่างโค้ดต่อไปนี้สร้างพรีเซนเทชั่นใหม่และกำหนดช่วงสไลด์ให้แสดงตั้งแต่สไลด์ `2` ถึง `9`.

```java
Presentation presentation = new Presentation();

SlidesRange slideRange = new SlidesRange();
slideRange.setStart(2);
slideRange.setEnd(9);

presentation.getSlideShowSettings().setSlides(slideRange);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **ใช้การเลื่อนสไลด์ล่วงหน้า**

`SlideShowSettings.setUseTimings` เมธอดนี้อนุญาตให้คุณเปิดหรือปิดการใช้การตั้งเวลาแบบกำหนดล่วงหน้าสำหรับแต่ละสไลด์ ซึ่งเป็นประโยชน์สำหรับการแสดงสไลด์โดยอัตโนมัติที่มีระยะเวลาการแสดงที่กำหนดไว้ ตัวอย่างโค้ดด้านล่างสร้างพรีเซนเทชั่นใหม่และปิดการใช้การตั้งเวลา.

```java
Presentation presentation = new Presentation();

presentation.getSlideShowSettings().setUseTimings(false);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **แสดงการควบคุมสื่อ**

`SlideShowSettings.setShowMediaControls` เมธอดนี้กำหนดว่าจะมีการแสดงการควบคุมสื่อ (เช่น เล่น, หยุดชั่วคราว, หยุด) ระหว่างการแสดงสไลด์เมื่อมีการเล่นเนื้อหามัลติมีเดีย (เช่น วิดีโอหรือเสียง) หรือไม่ ซึ่งเป็นประโยชน์เมื่อคุณต้องการให้ผู้บรรยายควบคุมการเล่นสื่อระหว่างการพรีเซนเทชั่น

โค้ดตัวอย่างต่อไปนี้สร้างพรีเซนเทชั่นใหม่และเปิดใช้งานการแสดงการควบคุมสื่อ.

```java
Presentation presentation = new Presentation();

presentation.getSlideShowSettings().setShowMediaControls(true);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **คำถามที่พบบ่อย**

**ฉันสามารถบันทึกพรีเซนเทชั่นเพื่อให้เปิดโดยตรงในโหมด slide show ได้หรือไม่?**

ใช่. บันทึกไฟล์เป็นรูปแบบ PPSX หรือ PPSM; รูปแบบเหล่านี้จะเปิดโดยตรงในโหมด slide show เมื่อเปิดใน PowerPoint. ใน Aspose.Slides ให้เลือกรูปแบบการบันทึกที่สอดคล้องกัน [during export](/slides/th/androidjava/save-presentation/).

**ฉันสามารถยกเว้นสไลด์บุคคลหนึ่งจากการแสดงโดยไม่ลบออกจากไฟล์ได้หรือไม่?**

ใช่. ทำเครื่องหมายสไลด์เป็น [hidden](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/slide/#setHidden-boolean-). สไลด์ที่ซ่อนอยู่จะยังคงอยู่ในพรีเซนเทชั่นแต่จะไม่แสดงระหว่างการแสดงสไลด์.

**Aspose.Slides สามารถเล่น slide show หรือควบคุมการพรีเซนเทชั่นสดบนหน้าจอได้หรือไม่?**

ไม่. Aspose.Slides ทำการแก้ไข, วิเคราะห์, และแปลงไฟล์พรีเซนเทชั่น; การเล่นจริงจะจัดการโดยแอปพลิเคชันผู้ชมเช่น PowerPoint.