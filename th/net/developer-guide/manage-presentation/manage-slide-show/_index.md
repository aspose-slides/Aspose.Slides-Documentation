---
title: จัดการการแสดงสไลด์ใน .NET
linktitle: การแสดงสไลด์
type: docs
weight: 90
url: /th/net/manage-slide-show/
keywords:
- ประเภทการแสดง
- นำเสนอโดยผู้พูด
- เรียกดูโดยบุคคล
- เรียกดูที่คีออส
- ตัวเลือกการแสดง
- วนลูปต่อเนื่อง
- แสดงโดยไม่มีการบรรยาย
- แสดงโดยไม่มีการเคลื่อนไหว
- สีปากกา
- แสดงสไลด์
- การแสดงที่กำหนดเอง
- เลื่อนสไลด์ไปข้างหน้า
- ด้วยตนเอง
- ใช้การกำหนดเวลา
- PowerPoint
- OpenDocument
- การนำเสนอ
- .NET
- C#
- Aspose.Slides
description: "เรียนรู้วิธีจัดการการแสดงสไลด์ใน Aspose.Slides สำหรับ .NET ควบคุมการเปลี่ยนสไลด์, การกำหนดเวลาและอื่น ๆ อย่างง่ายดายในรูปแบบ PPT, PPTX และ ODP"
---
## **บทนำ**

ใน Microsoft PowerPoint การตั้งค่า **Slide Show** เป็นเครื่องมือสำคัญสำหรับการเตรียมและนำเสนอการนำเสนอระดับมืออาชีพ หนึ่งในคุณสมบัติที่สำคัญที่สุดในส่วนนี้คือ **Set Up Show** ซึ่งช่วยให้คุณปรับแต่งการนำเสนอให้เหมาะกับเงื่อนไขและผู้ชมเฉพาะ ทำให้มีความยืดหยุ่นและสะดวกสบาย ด้วยคุณลักษณะนี้ คุณสามารถเลือกประเภทการแสดง (เช่น นำเสนอโดยผู้พูด, ดูโดยบุคคลหนึ่ง, หรือดูแบบคีออส) เปิดหรือปิดการวนลูป, เลือกสไลด์ที่ต้องการแสดง, และใช้การกำหนดเวลา ขั้นตอนนี้ในการเตรียมเป็นสิ่งสำคัญในการทำให้การนำเสนอของคุณมีประสิทธิภาพและเป็นมืออาชีพมากขึ้น

`SlideShowSettings` เป็นคุณสมบัติของคลาส [Presentation](https://reference.aspose.com/slides/th/net/aspose.slides/presentation/) ชนิด [SlideShowSettings](https://reference.aspose.com/slides/th/net/aspose.slides/presentation/slideshowsettings/) ซึ่งช่วยให้คุณจัดการการตั้งค่า slide show ในการนำเสนอ PowerPoint ในบทความนี้ เราจะสำรวจวิธีใช้คุณสมบัตินี้เพื่อกำหนดค่าและควบคุมแง่มุมต่าง ๆ ของการตั้งค่า slide show

## **เลือกประเภทการแสดง**

`SlideShowSettings.SlideShowType` กำหนดประเภทของ slide show ซึ่งอาจเป็นอินสแตนซ์ของคลาสต่อไปนี้: [PresentedBySpeaker](https://reference.aspose.com/slides/th/net/aspose.slides/presentedbyspeaker/), [BrowsedByIndividual](https://reference.aspose.com/slides/th/net/aspose.slides/browsedbyindividual/), หรือ [BrowsedAtKiosk](https://reference.aspose.com/slides/th/net/aspose.slides/browsedatkiosk/). การใช้คุณสมบัตินี้ช่วยให้คุณปรับการนำเสนอให้เหมาะกับสถานการณ์การใช้งานต่าง ๆ เช่น คีออสอัตโนมัติหรือการนำเสนอด้วยมือ

ตัวอย่างโค้ดด้านล่างสร้างการนำเสนอใหม่และตั้งค่าประเภทการแสดงเป็น “Browsed by an individual” โดยไม่แสดงแถบเลื่อน

```cs
using var presentation = new Presentation();

var showType = new BrowsedByIndividual
{
    ShowScrollbar = false
};

presentation.SlideShowSettings.SlideShowType = showType;

presentation.Save("output.pptx", SaveFormat.Pptx);
```

## **เปิดใช้งานตัวเลือกการแสดง**

`SlideShowSettings.Loop` กำหนดว่าการแสดง slide show ควรวนลูปจนกว่าจะหยุดด้วยตนเองหรือไม่ ซึ่งมีประโยชน์สำหรับการนำเสนออัตโนมัติที่ต้องทำงานต่อเนื่อง `SlideShowSettings.ShowNarration` กำหนดว่าจะเล่นการบรรยายเสียงระหว่างการแสดงหรือไม่ ซึ่งเป็นประโยชน์สำหรับการนำเสนออัตโนมัติที่มีคำแนะนำเสียงสำหรับผู้ชม `SlideShowSettings.ShowAnimation` กำหนดว่าจะเล่นการเคลื่อนไหวที่เพิ่มเข้าไปในวัตถุ slide หรือไม่ ซึ่งช่วยให้ได้เอฟเฟกต์ภาพเต็มรูปแบบของการนำเสนอ

ตัวอย่างโค้ดต่อไปนี้สร้างการนำเสนอใหม่และทำให้ slide show วนลูป

```cs
using var presentation = new Presentation();

presentation.SlideShowSettings.Loop = true;

presentation.Save("output.pptx", SaveFormat.Pptx);
```

## **เลือกสไลด์ที่จะแสดง**

คุณสมบัติ `SlideShowSettings.Slides` อนุญาตให้คุณเลือกช่วงของสไลด์ที่จะถูกแสดงระหว่างการนำเสนอ ซึ่งมีประโยชน์เมื่อคุณต้องการแสดงเฉพาะบางส่วนของการนำเสนอแทนที่จะแสดงทั้งหมด ตัวอย่างโค้ดต่อไปนี้สร้างการนำเสนอใหม่และตั้งค่าช่วงสไลด์ให้แสดงตั้งแต่สไลด์ `2` ถึง `9`

```cs
using var presentation = new Presentation();

var slideRange = new SlidesRange 
{
    Start = 2,
    End = 9
};

presentation.SlideShowSettings.Slides = slideRange;

presentation.Save("output.pptx", SaveFormat.Pptx);
```

## **ใช้การเปลี่ยนสไลด์อัตโนมัติ**

คุณสมบัติ `SlideShowSettings.UseTimings` อนุญาตให้คุณเปิดหรือปิดการใช้เวลาที่กำหนดล่วงหน้าสำหรับแต่ละสไลด์ ซึ่งเป็นประโยชน์สำหรับการแสดงสไลด์โดยอัตโนมัติตามระยะเวลาที่กำหนดไว้ ตัวอย่างโค้ดด้านล่างสร้างการนำเสนอใหม่และปิดการใช้เวลาที่กำหนด

```cs
using var presentation = new Presentation();

presentation.SlideShowSettings.UseTimings = false;

presentation.Save("output.pptx", SaveFormat.Pptx);
```

## **แสดงการควบคุมสื่อ**

คุณสมบัติ `SlideShowSettings.ShowMediaControls` กำหนดว่าจะต้องแสดงการควบคุมสื่อ (เช่น เล่น, หยุดชั่วคราว, และหยุด) ระหว่างการแสดง slide show เมื่อมีเนื้อหามัลติมีเดีย (เช่น วิดีโอหรือเสียง) ถูกเล่นหรือไม่ ซึ่งเป็นประโยชน์เมื่อคุณต้องการให้ผู้นำเสนอควบคุมการเล่นสื่อระหว่างการนำเสนอ

ตัวอย่างโค้ดต่อไปนี้สร้างการนำเสนอใหม่และเปิดใช้งานการแสดงการควบคุมสื่อ

```cs
using var presentation = new Presentation();

presentation.SlideShowSettings.ShowMediaControls = true;

presentation.Save("output.pptx", SaveFormat.Pptx);
```

## **FAQ**

**ฉันสามารถบันทึกการนำเสนอให้เปิดโดยตรงในโหมด slide show ได้หรือไม่?**

ได้ บันทึกไฟล์เป็นรูปแบบ PPSX หรือ PPSM; รูปแบบเหล่านี้จะเปิดโดยตรงในโหมด slide show เมื่อเปิดใน PowerPoint ใน Aspose.Slides ให้เลือกรูปแบบการบันทึกที่สอดคล้องกัน [ในระหว่างการส่งออก](/slides/th/net/save-presentation/)

**ฉันสามารถยกเว้นสไลด์เดี่ยวจากการแสดงโดยไม่ต้องลบออกจากไฟล์ได้หรือไม่?**

ได้ ทำเครื่องหมายสไลด์เป็น [Hidden](https://reference.aspose.com/slides/th/net/aspose.slides/slide/hidden/) สไลด์ที่ซ่อนอยู่จะยังคงอยู่ในการนำเสนอแต่จะไม่แสดงระหว่างการแสดง slide show

**Aspose.Slides สามารถเล่น slide show หรือควบคุมการนำเสนอสดบนหน้าจอได้หรือไม่?**

ไม่ได้ Aspose.Slides ทำการแก้ไข, วิเคราะห์และแปลงไฟล์การนำเสนอ; การเล่นจริงจะดำเนินการโดยแอปพลิเคชันตัวดูเช่น PowerPoint