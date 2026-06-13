---
title: จัดการการแสดงสไลด์ใน Python
linktitle: การแสดงสไลด์
type: docs
weight: 90
url: /th/python-net/manage-slide-show/
keywords:
- ประเภทการแสดง
- นำเสนอโดยผู้พูด
- ดูโดยบุคคล
- ดูที่คีออส
- ตัวเลือกการแสดง
- วนลูปอย่างต่อเนื่อง
- แสดงโดยไม่มีบรรยาย
- แสดงโดยไม่มีแอนิเมชัน
- สีปากกา
- แสดงสไลด์
- การแสดงแบบกำหนดเอง
- เลื่อนสไลด์ล่วงหน้า
- ด้วยตนเอง
- ใช้เวลา
- PowerPoint
- OpenDocument
- การนำเสนอ
- Python
- Aspose.Slides
description: "เรียนรู้วิธีจัดการการแสดงสไลด์ใน Aspose.Slides สำหรับ Python ผ่าน .NET ควบคุมการเปลี่ยนสไลด์, เวลาและอื่น ๆ ในรูปแบบ PPT, PPTX และ ODP อย่างง่ายดาย."
---
## **บทนำ**

ใน Microsoft PowerPoint การตั้งค่า **Slide Show** เป็นเครื่องมือสำคัญสำหรับการเตรียมและนำเสนอการนำเสนอแบบมืออาชีพ หนึ่งในคุณสมบัติที่สำคัญที่สุดในส่วนนี้คือ **Set Up Show** ที่ให้คุณปรับการนำเสนอให้ตรงกับสภาพแวดล้อมและผู้ชมที่เฉพาะเจาะจง ทำให้มีความยืดหยุ่นและสะดวกสบาย ด้วยคุณสมบัตินี้คุณสามารถเลือกประเภทการแสดง (เช่น แสดงโดยผู้พูด, ดูโดยบุคคลหนึ่งคน, หรือดูที่คีออส), เปิดหรือปิดการวนลูป, เลือกสไลด์เฉพาะที่จะแสดง, และใช้การตั้งเวลา ขั้นตอนนี้ในการเตรียมเป็นสิ่งสำคัญเพื่อทำให้การนำเสนอของคุณมีประสิทธิภาพและเป็นมืออาชีพมากขึ้น.

`slide_show_settings` เป็นคุณสมบัติของคลาส [Presentation](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/) ชนิด [SlideShowSettings](https://reference.aspose.com/slides/th/python-net/aspose.slides/slideshowsettings/) ที่ช่วยให้คุณจัดการการตั้งค่า slide show ในการนำเสนอ PowerPoint ในบทความนี้เราจะสำรวจวิธีใช้คุณสมบัตินี้เพื่อกำหนดค่าและควบคุมด้านต่าง ๆ ของการตั้งค่า slide show. 

## **เลือกประเภทการแสดง**

`SlideShowSettings.slide_show_type` กำหนดประเภทของ slide show ซึ่งสามารถเป็นอินสแตนซ์ของคลาสต่อไปนี้: [PresentedBySpeaker](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentedbyspeaker/), [BrowsedByIndividual](https://reference.aspose.com/slides/th/python-net/aspose.slides/browsedbyindividual/), หรือ [BrowsedAtKiosk](https://reference.aspose.com/slides/th/python-net/aspose.slides/browsedatkiosk/). การใช้คุณสมบัตินี้ช่วยให้คุณปรับการนำเสนอให้เหมาะกับสถานการณ์การใช้งานต่าง ๆ เช่น คีออสอัตโนมัติหรือการนำเสนอด้วยมือ.

ตัวอย่างโค้ดด้านล่างสร้างการนำเสนอใหม่และตั้งค่าประเภทการแสดงเป็น “Browsed by an individual” โดยไม่แสดงแถบเลื่อน.

```py
with slides.Presentation() as presentation:

    show_type = slides.BrowsedByIndividual()
    show_type.show_scrollbar = False

    presentation.slide_show_settings.slide_show_type = show_type

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **เปิดใช้งานตัวเลือกการแสดง**

`SlideShowSettings.loop` กำหนดว่าจะให้ slide show ทำซ้ำในลูปจนกว่าจะหยุดด้วยตนเองหรือไม่ ซึ่งเป็นประโยชน์สำหรับการนำเสนออัตโนมัติที่ต้องทำงานต่อเนื่อง `SlideShowSettings.show_narration` กำหนดว่าจะให้มีการเล่นบรรยายเสียงระหว่าง slide show หรือไม่ ซึ่งมีประโยชน์สำหรับการนำเสนออัตโนมัติที่มีคำแนะนำด้วยเสียงสำหรับผู้ชม `SlideShowSettings.show_animation` กำหนดว่าจะให้แอนิเมชันที่เพิ่มเข้าไปในวัตถุสไลด์ทำงานหรือไม่ ซึ่งช่วยให้ได้เอฟเฟกต์ภาพเต็มรูปแบบของการนำเสนอ.

ตัวอย่างโค้ดต่อไปนี้สร้างการนำเสนอใหม่และทำให้ slide show ทำซ้ำ.

```py
with slides.Presentation() as presentation:

    presentation.slide_show_settings.loop = True

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **เลือกสไลด์ที่จะแสดง**

`SlideShowSettings.slides` เป็นคุณสมบัติที่ให้คุณเลือกช่วงของสไลด์ที่จะถูกแสดงในการนำเสนอ ซึ่งมีประโยชน์เมื่อคุณต้องการแสดงเฉพาะส่วนของการนำเสนอแทนที่จะแสดงทั้งหมด ตัวอย่างโค้ดต่อไปนี้สร้างการนำเสนอใหม่และตั้งค่าช่วงสไลด์ให้แสดงตั้งแต่สไลด์ `2` ถึง `9`.

```py
with slides.Presentation() as presentation:
    
    slide_range = slides.SlidesRange()
    slide_range.start = 2
    slide_range.end = 9

    presentation.slide_show_settings.slides = slide_range

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **ใช้การเลื่อนสไลด์ล่วงหน้า**

`SlideShowSettings.use_timings` เป็นคุณสมบัติที่ให้คุณเปิดหรือปิดการใช้เวลาที่กำหนดไว้ล่วงหน้าสำหรับแต่ละสไลด์ ซึ่งเป็นประโยชน์สำหรับการแสดงสไลด์โดยอัตโนมัติพร้อมระยะเวลาการแสดงที่กำหนดไว้ ตัวอย่างโค้ดด้านล่างสร้างการนำเสนอใหม่และปิดการใช้เวลาที่กำหนด.

```py
with slides.Presentation() as presentation:

    presentation.slide_show_settings.use_timings = False

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **แสดงการควบคุมสื่อ**

`SlideShowSettings.show_media_controls` เป็นคุณสมบัติที่กำหนดว่าจะให้แสดงการควบคุมสื่อ (เช่น เล่น, หยุดชั่วคราว, และหยุด) ระหว่าง slide show เมื่อมีการเล่นเนื้อหามัลติมีเดีย (เช่น วิดีโอหรือเสียง) หรือไม่ ซึ่งมีประโยชน์เมื่อคุณต้องการให้ผู้นำเสนอควบคุมการเล่นสื่อระหว่างการนำเสนอ.

ตัวอย่างโค้ดต่อไปนี้สร้างการนำเสนอใหม่และเปิดใช้การแสดงการควบคุมสื่อ.

```py
with slides.Presentation() as presentation:

    presentation.slide_show_settings.show_media_controls = True

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **คำถามที่พบบ่อย**

**ฉันสามารถบันทึกการนำเสนอให้เปิดโดยตรงในโหมด slide show ได้หรือไม่?**

ใช่. บันทึกไฟล์เป็น PPSX หรือ PPSM; รูปแบบเหล่านี้จะเปิดโดยตรงใน slide show เมื่อเปิดใน PowerPoint. ใน Aspose.Slides ให้เลือกรูปแบบการบันทึกที่สอดคล้องกัน [during export](/slides/th/python-net/save-presentation/).

**ฉันสามารถยกเว้นสไลด์เดี่ยวจากการแสดงโดยไม่ลบออกจากไฟล์ได้หรือไม่?**

ใช่. ทำเครื่องหมายสไลด์เป็น [hidden](https://reference.aspose.com/slides/th/python-net/aspose.slides/slide/hidden/). สไลด์ที่ซ่อนจะยังคงอยู่ในการนำเสนอแต่จะไม่ปรากฏระหว่าง slide show.

**Aspose.Slides สามารถเล่น slide show หรือควบคุมการนำเสนอสดบนหน้าจอได้หรือไม่?**

ไม่. Aspose.Slides ทำการแก้ไข, วิเคราะห์, และแปลงไฟล์การนำเสนอ; การเล่นจริงจะถูกดำเนินการโดยแอปพลิเคชันผู้ชมเช่น PowerPoint.