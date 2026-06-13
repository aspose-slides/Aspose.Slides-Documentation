---
title: จัดการการแสดงสไลด์ใน JavaScript
linktitle: การแสดงสไลด์
type: docs
weight: 90
url: /th/nodejs-java/manage-slide-show/
keywords:
- ประเภทการแสดง
- นำเสนอโดยผู้พูด
- เรียกดูโดยบุคคล
- เรียกดูที่คีออส
- ตัวเลือกการแสดง
- วนลูปต่อเนื่อง
- แสดงโดยไม่มีการบรรยาย
- แสดงโดยไม่มีแอนิเมชัน
- สีปากกา
- แสดงสไลด์
- การแสดงแบบกำหนดเอง
- เลื่อนสไลด์ต่อไป
- ด้วยตนเอง
- ใช้การตั้งเวลา
- PowerPoint
- OpenDocument
- การนำเสนอ
- Node.js
- JavaScript
- Aspose.Slides
description: "จัดการการแสดงสไลด์ใน JavaScript ด้วย Aspose.Slides สำหรับ Node.js. ควบคุมการเปลี่ยนสไลด์, การตั้งเวลา และอื่นๆ อย่างง่ายดายในรูปแบบ PPT, PPTX และ ODP."
---
## **บทนำ**

ใน Microsoft PowerPoint การตั้งค่า **Slide Show** เป็นเครื่องมือสำคัญสำหรับการเตรียมและนำเสนอการนำเสนออย่างมืออาชีพ หนึ่งในคุณลักษณะที่สำคัญที่สุดในส่วนนี้คือ **Set Up Show** ซึ่งช่วยให้คุณปรับการนำเสนอให้ตรงกับเงื่อนไขและผู้ชมเฉพาะ ทำให้มีความยืดหยุ่นและสะดวกสบาย ด้วยคุณลักษณะนี้คุณสามารถเลือกประเภทการแสดง (เช่น presented by a speaker, browsed by an individual, หรือ browsed at a kiosk), เปิดหรือปิดการวนลูป, เลือกสไลด์เฉพาะที่ต้องการแสดง, และใช้การตั้งเวลา ขั้นตอนการเตรียมนี้สำคัญต่อการทำให้การนำเสนอของคุณมีประสิทธิภาพและเป็นมืออาชีพมากยิ่งขึ้น.

`getSlideShowSettings` เป็นเมธอดของคลาส [Presentation](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/presentation/) ที่คืนค่าอ็อบเจกต์ประเภท [SlideShowSettings](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/slideshowsettings/) ซึ่งช่วยให้คุณจัดการการตั้งค่า slide show ในการนำเสนอ PowerPoint ในบทความนี้ เราจะสำรวจวิธีใช้เมธอดนี้เพื่อกำหนดค่าและควบคุมแง่มุมต่างๆ ของการตั้งค่า slide show. 

## **เลือกประเภทการแสดง**

`SlideShowSettings.setSlideShowType` กำหนดประเภทของ slide show ซึ่งสามารถเป็นอินสแตนซ์ของคลาสต่างๆ ต่อไปนี้: [PresentedBySpeaker](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/presentedbyspeaker/), [BrowsedByIndividual](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/browsedbyindividual/), หรือ [BrowsedAtKiosk](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/browsedatkiosk/). การใช้เมธอดนี้ช่วยให้คุณปรับการนำเสนอให้เหมาะกับสถานการณ์การใช้งานต่างๆ เช่น คีออสอัตโนมัติหรือการนำเสนอด้วยตนเอง.

ตัวอย่างโค้ดด้านล่างสร้างการนำเสนอใหม่และตั้งค่าประเภทการแสดงเป็น "Browsed by an individual" โดยไม่แสดงแถบเลื่อน.

```js
var presentation = new asposeSlides.Presentation();

var showType = new asposeSlides.BrowsedByIndividual();
showType.setShowScrollbar(false);

presentation.getSlideShowSettings().setSlideShowType(showType);

presentation.save("output.pptx", asposeSlides.SaveFormat.Pptx);
presentation.dispose();
```

## **เปิดใช้งานตัวเลือกการแสดง**

`SlideShowSettings.setLoop` กำหนดว่าการแสดง slide show ควรทำซ้ำในลูปจนกว่าจะหยุดด้วยตนเองหรือไม่ สิ่งนี้มีประโยชน์สำหรับการนำเสนออัตโนมัติที่ต้องทำงานต่อเนื่อง `SlideShowSettings.setShowNarration` กำหนดว่าจะเล่นการบรรยายเสียงระหว่าง slide show หรือไม่ ซึ่งเป็นประโยชน์สำหรับการนำเสนออัตโนมัติที่มีคำแนะนำเสียงสำหรับผู้ชม `SlideShowSettings.setShowAnimation` กำหนดว่าจะเล่นแอนิเมชันที่เพิ่มในวัตถุ slide หรือไม่ ซึ่งช่วยให้ได้เอฟเฟกต์ภาพเต็มของการนำเสนอ.

ตัวอย่างโค้ดต่อไปนี้สร้างการนำเสนอใหม่และทำให้ slide show วนลูป.

```js
var presentation = new asposeSlides.Presentation();

presentation.getSlideShowSettings().setLoop(true);

presentation.save("output.pptx", asposeSlides.SaveFormat.Pptx);
presentation.dispose();
```

## **เลือกสไลด์ที่จะแสดง**

`SlideShowSettings.setSlides` เมธอดช่วยให้คุณเลือกช่วงสไลด์ที่จะแสดงระหว่างการนำเสนอ ซึ่งเป็นประโยชน์เมื่อคุณต้องการแสดงเพียงบางส่วนของการนำเสนอแทนที่จะแสดงทั้งหมด ตัวอย่างโค้ดต่อไปนี้สร้างการนำเสนอใหม่และตั้งค่าช่วงสไลด์ให้แสดงตั้งแต่สไลด์ `2` ถึง `9`.

```js
var presentation = new asposeSlides.Presentation();

var slideRange = new asposeSlides.SlidesRange();
slideRange.setStart(2);
slideRange.setEnd(9);

presentation.getSlideShowSettings().setSlides(slideRange);

presentation.save("output.pptx", asposeSlides.SaveFormat.Pptx);
presentation.dispose();
```

## **ใช้การเลื่อนสไลด์ล่วงหน้า**

`SlideShowSettings.setUseTimings` เมธอดช่วยให้คุณเปิดหรือปิดการใช้เวลาที่กำหนดล่วงหน้าสำหรับแต่ละสไลด์ ซึ่งเป็นประโยชน์สำหรับการแสดงสไลด์โดยอัตโนมัติด้วยระยะเวลาแสดงที่กำหนดไว้ ตัวอย่างโค้ดด้านล่างสร้างการนำเสนอใหม่และปิดการใช้เวลา.

```js
var presentation = new asposeSlides.Presentation();

presentation.getSlideShowSettings().setUseTimings(false);

presentation.save("output.pptx", asposeSlides.SaveFormat.Pptx);
presentation.dispose();
```

## **แสดงการควบคุมสื่อ**

`SlideShowSettings.setShowMediaControls` เมธอดกำหนดว่าจะต้องแสดงการควบคุมสื่อ (เช่น เล่น, หยุดชั่วคราว, และหยุด) ระหว่าง slide show เมื่อมีการเล่นเนื้อหามัลติเมเดีย (เช่น วิดีโอหรือเสียง) หรือไม่ ซึ่งเป็นประโยชน์เมื่อคุณต้องการให้ผู้นำเสนอควบคุมการเล่นสื่อระหว่างการนำเสนอ.

ตัวอย่างโค้ดต่อไปนี้สร้างการนำเสนอใหม่และเปิดใช้งานการแสดงการควบคุมสื่อ.

```js
var presentation = new asposeSlides.Presentation();

presentation.getSlideShowSettings().setShowMediaControls(true);

presentation.save("output.pptx", asposeSlides.SaveFormat.Pptx);
presentation.dispose();
```

## **FAQ**

**Can I save a presentation so it opens directly in slide show mode?**

ใช่. บันทึกไฟล์เป็นรูปแบบ PPSX หรือ PPSM; รูปแบบเหล่านี้จะเปิดโดยตรงในโหมด slide show เมื่อเปิดใน PowerPoint. ใน Aspose.Slides ให้เลือกรูปแบบการบันทึกที่สอดคล้องกัน [ระหว่างการส่งออก](/slides/th/nodejs-java/save-presentation/).

**Can I exclude individual slides from the show without deleting them from the file?**

ใช่. ทำเครื่องหมายสไลด์เป็น [ซ่อน](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/slide/sethidden/). สไลด์ที่ซ่อนจะยังคงอยู่ในการนำเสนอแต่จะไม่แสดงระหว่าง slide show.

**Can Aspose.Slides play a slide show or control a live presentation on screen?**

ไม่. Aspose.Slides ทำการแก้ไข, วิเคราะห์, และแปลงไฟล์การนำเสนอ; การเล่นจริงจะถูกจัดการโดยแอปพลิเคชันผู้ชมเช่น PowerPoint.