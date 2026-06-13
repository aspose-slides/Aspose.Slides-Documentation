---
title: แปลงงานนำเสนอ PowerPoint เป็น SWF Flash ด้วย Python
linktitle: PowerPoint เป็น SWF Flash
type: docs
weight: 80
url: /th/python-net/convert-powerpoint-to-swf-flash/
keywords:
- แปลง PowerPoint
- แปลงงานนำเสนอ
- แปลงสไลด์
- PowerPoint เป็น SWF
- งานนำเสนอเป็น SWF
- สไลด์เป็น SWF
- PPT เป็น SWF
- PPTX เป็น SWF
- PowerPoint
- งานนำเสนอ
- Python
- Aspose.Slides
description: "แปลง PowerPoint (PPT/PPTX) เป็น SWF Flash ด้วย Python และ Aspose.Slides ตัวอย่างโค้ดแบบขั้นตอน รายงานคุณภาพเร็ว ไม่ต้องใช้การทำงานอัตโนมัติของ PowerPoint."
---
## **ภาพรวม**

บทความนี้อธิบายวิธีแปลงงานนำเสนอ PowerPoint ไปเป็น SWF ด้วยการใช้ Aspose.Slides แสดงวิธีบันทึกงานนำเสนอเป็นไฟล์ SWF ด้วยเมธอด [Presentation.save](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/save/) และวิธีกำหนดค่าการส่งออกด้วย [SwfOptions](https://reference.aspose.com/slides/th/python-net/aspose.slides.export/swfoptions/) รวมถึงการตั้งค่าผู้ชมและเค้าโครงของหมายเหตุหรือความคิดเห็น

## **แปลงงานนำเสนอเป็น Flash**

เมธอด [save](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/save/) ที่เปิดให้ใช้งานโดยคลาส [Presentation](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/) สามารถใช้เพื่อแปลงงานนำเสนอทั้งหมดเป็นเอกสาร SWF คุณยังสามารถรวมความคิดเห็นใน SWF ที่สร้างขึ้นโดยใช้คลาส [SWFOptions](https://reference.aspose.com/slides/th/python-net/aspose.slides.export/swfoptions/) และคลาส [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/th/python-net/aspose.slides.export/notescommentslayoutingoptions/) ตัวอย่างต่อไปนี้แสดงวิธีแปลงงานนำเสนอเป็นเอกสาร SWF โดยใช้ตัวเลือกที่มาจากคลาส SWFOptions

```py
import aspose.slides as slides

# สร้างอ็อบเจกต์ Presentation ที่เป็นตัวแทนของไฟล์งานนำเสนอ
presentation = slides.Presentation("pres.pptx")

swfOptions = slides.export.SwfOptions()
swfOptions.viewer_included = False
swfOptions.notes_comments_layouting.notes_position = slides.export.NotesPositions.BOTTOM_FULL

# บันทึกงานนำเสนอและหน้าบันทึกหมายเหตุ
presentation.save("SaveAsSwf_out.swf", slides.export.SaveFormat.SWF, swfOptions)
swfOptions.viewer_included = True
presentation.save("SaveNotes_out.swf", slides.export.SaveFormat.SWF, swfOptions)
```

## **คำถามที่พบบ่อย**

**ฉันสามารถรวมสไลด์ที่ซ่อนอยู่ใน SWF ได้หรือไม่?**

ใช่. เปิดใช้งานตัวเลือก [show_hidden_slides](https://reference.aspose.com/slides/th/python-net/aspose.slides.export/swfoptions/show_hidden_slides/) ใน [SwfOptions](https://reference.aspose.com/slides/th/python-net/aspose.slides.export/swfoptions/) โดยค่าเริ่มต้น สไลด์ที่ซ่อนจะไม่ถูกส่งออก

**ฉันจะควบคุมการบีบอัดและขนาดสุดท้ายของ SWF ได้อย่างไร?**

ใช้แฟล็ก [compressed](https://reference.aspose.com/slides/th/python-net/aspose.slides.export/swfoptions/compressed/) (เปิดใช้งานโดยค่าเริ่มต้น) และปรับค่า [jpeg_quality](https://reference.aspose.com/slides/th/python-net/aspose.slides.export/swfoptions/jpeg_quality/) เพื่อสมดุลระหว่างขนาดไฟล์และคุณภาพภาพ

**'viewer_included' มีไว้ทำอะไรและควรปิดใช้งานเมื่อใด?**

[viewer_included](https://reference.aspose.com/slides/th/python-net/aspose.slides.export/swfoptions/viewer_included/) เพิ่ม UI ตัวเล่นแบบฝัง (การควบคุมการนำทาง, แพงล, การค้นหา) ปิดใช้งานหากคุณต้องการใช้ตัวเล่นของคุณเองหรือจำเป็นต้องมีกรอบ SWF เปล่าไม่มี UI

**จะเกิดอะไรขึ้นหากฟอนท์ต้นแบบหายไปบนเครื่องที่ทำการส่งออก?**

Aspose.Slides จะทดแทนฟอนท์ที่คุณระบุผ่าน [default_regular_font](https://reference.aspose.com/slides/th/python-net/aspose.slides.export/swfoptions/default_regular_font/) ใน [SwfOptions](https://reference.aspose.com/slides/th/python-net/aspose.slides.export/swfoptions/) เพื่อหลีกเลี่ยงการใช้ฟอนท์สำรองโดยไม่ได้ตั้งใจ