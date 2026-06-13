---
title: จัดการการแสดงสไลด์ใน C++
linktitle: การแสดงสไลด์
type: docs
weight: 90
url: /th/cpp/manage-slide-show/
keywords:
- ประเภทการแสดง
- นำเสนอโดยผู้บรรยาย
- ดูโดยบุคคลทั่วไป
- ดูที่คีออส
- ตัวเลือกการแสดง
- วนลูปต่อเนื่อง
- แสดงโดยไม่มีคำบรรยาย
- แสดงโดยไม่มีการเคลื่อนไหว
- สีปากกา
- แสดงสไลด์
- การแสดงแบบกำหนดเอง
- เลื่อนสไลด์ล่วงหน้า
- ด้วยตนเอง
- ใช้การตั้งเวลา
- PowerPoint
- OpenDocument
- การนำเสนอ
- C++
- Aspose.Slides
description: "เรียนรู้วิธีจัดการการแสดงสไลด์ใน Aspose.Slides สำหรับ C++. ควบคุมการเปลี่ยนสไลด์, การตั้งเวลาและอื่น ๆ อย่างง่ายดายในรูปแบบ PPT, PPTX และ ODP"
---
## **บทนำ**

ใน Microsoft PowerPoint การตั้งค่า **Slide Show** เป็นเครื่องมือสำคัญสำหรับการเตรียมและนำเสนอการนำเสนอระดับมืออาชีพ. หนึ่งในคุณสมบัติที่สำคัญที่สุดในส่วนนี้คือ **Set Up Show** ซึ่งช่วยให้คุณปรับการนำเสนอให้เหมาะกับสภาพแวดล้อมและผู้ชมเฉพาะเจาะจง เพื่อให้มีความยืดหยุ่นและความสะดวกสบาย. ด้วยคุณลักษณะนี้ คุณสามารถเลือกประเภทการแสดง (เช่น แสดงโดยผู้บรรยาย, ดูโดยบุคคลทั่วไป, หรือดูแบบคีออส), เปิดหรือปิดการวนลูป, เลือกสไลด์เฉพาะที่จะแสดง, และใช้การตั้งเวลา. ขั้นตอนนี้ในการเตรียมการเป็นสิ่งสำคัญสำหรับทำให้การนำเสนอของคุณมีประสิทธิภาพและเป็นมืออาชีพมากขึ้น.

`get_SlideShowSettings` เป็นเมธอดของคลาส [Presentation](https://reference.aspose.com/slides/th/cpp/aspose.slides/presentation/) ที่คืนค่าเป็นอ็อบเจกต์ประเภท [SlideShowSettings](https://reference.aspose.com/slides/th/cpp/aspose.slides/slideshowsettings/) ซึ่งช่วยให้คุณจัดการการตั้งค่า slide show ในการนำเสนอ PowerPoint. ในบทความนี้ เราจะสำรวจวิธีใช้เมธอดนี้เพื่อกำหนดค่าและควบคุมแง่มุมต่าง ๆ ของการตั้งค่า slide show.

## **เลือกประเภทการแสดง**

`SlideShowSettings.set_SlideShowType` กำหนดประเภทของ slide show ซึ่งสามารถเป็นอินสแตนซ์ของคลาสต่อไปนี้: [PresentedBySpeaker](https://reference.aspose.com/slides/th/cpp/aspose.slides/presentedbyspeaker/), [BrowsedByIndividual](https://reference.aspose.com/slides/th/cpp/aspose.slides/browsedbyindividual/), หรือ [BrowsedAtKiosk](https://reference.aspose.com/slides/th/cpp/aspose.slides/browsedatkiosk/). การใช้เมธอดนี้ช่วยให้คุณปรับการนำเสนอให้เข้ากับสถานการณ์การใช้งานต่าง ๆ เช่น คีออสอัตโนมัติหรือการนำเสนอด้วยตนเอง.

ตัวอย่างโค้ดด้านล่างสร้างการนำเสนอใหม่และตั้งประเภทการแสดงเป็น “Browsed by an individual” โดยไม่แสดงแถบเลื่อน.

```cpp
auto presentation = MakeObject<Presentation>();

auto showType = MakeObject<BrowsedByIndividual>();
showType->set_ShowScrollbar(false);

presentation->get_SlideShowSettings()->set_SlideShowType(showType);

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **เปิดใช้งานตัวเลือกการแสดง**

`SlideShowSettings.set_Loop` กำหนดว่าการแสดง slide ควรวนซ้ำในลูปจนกว่าจะหยุดด้วยตนเองหรือไม่ ซึ่งเป็นประโยชน์สำหรับการนำเสนออัตโนมัติที่ต้องทำงานต่อเนื่อง. `SlideShowSettings.set_ShowNarration` กำหนดว่าจะเล่นการบรรยายด้วยเสียงระหว่างการแสดง slide หรือไม่ ซึ่งเป็นประโยชน์สำหรับการนำเสนออัตโนมัติที่มีคำแนะนำด้วยเสียงสำหรับผู้ชม. `SlideShowSettings.set_ShowAnimation` กำหนดว่าจะเล่นการเคลื่อนไหวที่เพิ่มเข้าไปในวัตถุ slide หรือไม่ ซึ่งช่วยให้ได้ผลภาพเต็มรูปแบบของการนำเสนอ.

ตัวอย่างโค้ดต่อไปนี้สร้างการนำเสนอใหม่และทำให้การแสดง slide วนลูป.

```cpp
auto presentation = MakeObject<Presentation>();

presentation->get_SlideShowSettings()->set_Loop(true);

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **เลือกสไลด์ที่จะแสดง**

`SlideShowSettings.set_Slides` เมธอดช่วยให้คุณเลือกช่วงของสไลด์ที่จะถูกแสดงระหว่างการนำเสนอ ซึ่งเป็นประโยชน์เมื่อคุณต้องการแสดงเพียงบางส่วนของการนำเสนอแทนที่จะเป็นสไลด์ทั้งหมด. ตัวอย่างโค้ดต่อไปนี้สร้างการนำเสนอใหม่และตั้งช่วงสไลด์ให้แสดงตั้งแต่สไลด์ `2` ถึง `9`.

```cpp
auto presentation = MakeObject<Presentation>();

auto slideRange = MakeObject<SlidesRange>();
slideRange->set_Start(2);
slideRange->set_End(9);

presentation->get_SlideShowSettings()->set_Slides(slideRange);

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **ใช้การเลื่อนสไลด์ล่วงหน้า**

`SlideShowSettings.set_UseTimings` เมธอดช่วยให้คุณเปิดหรือปิดการใช้เวลาที่กำหนดไว้ล่วงหน้าสำหรับแต่ละสไลด์ ซึ่งเป็นประโยชน์สำหรับการแสดงสไลด์อัตโนมัติด้วยช่วงเวลาแสดงที่กำหนดไว้ล่วงหน้า. ตัวอย่างโค้ดด้านล่างสร้างการนำเสนอใหม่และปิดการใช้เวลาที่กำหนด.

```cpp
auto presentation = MakeObject<Presentation>();

presentation->get_SlideShowSettings()->set_UseTimings(false);

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **แสดงการควบคุมสื่อ**

`SlideShowSettings.set_ShowMediaControls` เมธอดกำหนดว่าการควบคุมสื่อ (เช่น เล่น, หยุดชั่วคราว, และหยุด) ควรแสดงระหว่างการแสดง slide เมื่อมีการเล่นเนื้อหามัลติมีเดีย (เช่น วิดีโอหรือเสียง) หรือไม่ ซึ่งเป็นประโยชน์เมื่อคุณต้องการให้ผู้นำเสนอควบคุมการเล่นสื่อระหว่างการนำเสนอ.

ตัวอย่างโค้ดต่อไปนี้สร้างการนำเสนอใหม่และเปิดการแสดงการควบคุมสื่อ.

```cpp
auto presentation = MakeObject<Presentation>();

presentation->get_SlideShowSettings()->set_ShowMediaControls(true);

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **คำถามที่พบบ่อย**

**ฉันสามารถบันทึกการนำเสนอให้เปิดโดยตรงในโหมด slide show ได้หรือไม่?**

ใช่. บันทึกไฟล์เป็น PPSX หรือ PPSM; ฟอร์แมตเหล่านี้จะเปิดโดยตรงในโหมด slide show เมื่อเปิดใน PowerPoint. ใน Aspose.Slides ให้เลือกฟอร์แมตการบันทึกที่สอดคล้องกัน [during export](/slides/th/cpp/save-presentation/).

**ฉันสามารถละเว้นสไลด์แต่ละอันออกจากการแสดงโดยไม่ลบออกจากไฟล์ได้หรือไม่?**

ใช่. ทำเครื่องหมายสไลด์เป็น [hidden](https://reference.aspose.com/slides/th/cpp/aspose.slides/slide/set_hidden/). สไลด์ที่ถูกซ่อนจะยังคงอยู่ในการนำเสนอแต่จะไม่แสดงในระหว่าง slide show.

**Aspose.Slides สามารถเล่น slide show หรือควบคุมการนำเสนอสดบนหน้าจอได้หรือไม่?**

ไม่. Aspose.Slides ทำการแก้ไข, วิเคราะห์, และแปลงไฟล์การนำเสนอ; การเล่นจริงจะถูกจัดการโดยแอปพลิเคชันดูไฟล์เช่น PowerPoint.