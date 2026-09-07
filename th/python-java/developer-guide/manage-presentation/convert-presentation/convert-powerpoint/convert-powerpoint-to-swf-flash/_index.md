---
title: แปลงงานนำเสนอ PowerPoint ไปเป็น SWF Flash ใน Python ผ่าน Java
linktitle: PowerPoint ไปเป็น SWF
type: docs
weight: 80
url: /th/python-java/convert-powerpoint-to-swf-flash/
keywords:
- แปลง PowerPoint
- แปลงงานนำเสนอ
- แปลงสไลด์
- แปลง PPT
- แปลง PPTX
- PowerPoint ไปเป็น SWF
- งานนำเสนอไปเป็น SWF
- สไลด์ไปเป็น SWF
- PPT ไปเป็น SWF
- PPTX ไปเป็น SWF
- PowerPoint ไปเป็น Flash
- งานนำเสนอไปเป็น Flash
- สไลด์ไปเป็น Flash
- PPT ไปเป็น Flash
- PPTX ไปเป็น Flash
- บันทึก PPT เป็น SWF
- บันทึก PPTX เป็น SWF
- ส่งออก PPT ไปเป็น SWF
- ส่งออก PPTX ไปเป็น SWF
- Python
- Java
- Aspose.Slides
description: "แปลงงานนำเสนอ PowerPoint ไปเป็น SWF Flash ใน Python ผ่าน Java ด้วย Aspose.Slides. กำหนดค่าผู้ดู, บันทึกย่อ, สไลด์ที่ซ่อน, การบีบอัด, และฟอนต์."
---
## **ภาพรวม**

Aspose.Slides for Python via Java ช่วยให้คุณแปลงงานนำเสนอ PowerPoint ไปเป็น SWF โดยไม่ต้องใช้ Microsoft PowerPoint. ใช้ [Presentation.save](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentation/#save) เพื่อส่งออกงานนำเสนอและ [SwfOptions](https://reference.aspose.com/slides/th/python-java/aspose.slides/swfoptions/) เพื่อกำหนดค่า settings ของ viewer, คุณภาพภาพ, และการจัดวางของบันทึกย่อหรือคอมเมนท์.

## **แปลงงานนำเสนอเป็น Flash**

โหลดไฟล์ต้นฉบับด้วย [Presentation](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentation/), กำหนดค่า [SwfOptions](https://reference.aspose.com/slides/th/python-java/aspose.slides/swfoptions/) และบันทึกโดยใช้ [SaveFormat.Swf](https://reference.aspose.com/slides/th/python-java/aspose.slides/saveformat/#Swf).

ตัวอย่างต่อไปนี้ส่งออก `presentation.pptx` ไปเป็น `presentation.swf`. มันปิดการทำงานของตัวดูที่ฝังไว้ด้วย [setViewerIncluded](https://reference.aspose.com/slides/th/python-java/aspose.slides/swfoptions/#setViewerIncluded) และรวมบันทึกย่อของผู้พูดด้านล่างสไลด์โดยใช้ [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/th/python-java/aspose.slides/notescommentslayoutingoptions/).

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import NotesCommentsLayoutingOptions, NotesPositions, Presentation, SaveFormat, SwfOptions

presentation = Presentation("presentation.pptx")
try:
    layout_options = NotesCommentsLayoutingOptions()
    layout_options.setNotesPosition(NotesPositions.BottomFull)

    swf_options = SwfOptions()
    swf_options.setViewerIncluded(False)
    swf_options.setSlidesLayoutOptions(layout_options)

    presentation.save("presentation.swf", SaveFormat.Swf, swf_options)
finally:
    presentation.dispose()
```

ก่อนรันตัวอย่าง, [install Aspose.Slides for Python via Java](/slides/th/python-java/installation/) และวาง `presentation.pptx` ในไดเรกทอรีทำงาน. JVM จะเริ่มต้นหนึ่งครั้งต่อกระบวนการ Python.

ตัวอย่างใช้ [NotesPositions.BottomFull](https://reference.aspose.com/slides/th/python-java/aspose.slides/notespositions/#BottomFull) ผ่าน [setNotesPosition](https://reference.aspose.com/slides/th/python-java/aspose.slides/notescommentslayoutingoptions/#setNotesPosition) และส่งค่า layout ไปยัง [SwfOptions.setSlidesLayoutOptions](https://reference.aspose.com/slides/th/python-java/aspose.slides/swfoptions/#setSlidesLayoutOptions). เพื่อรวมคอมเมนท์ด้วย, กำหนดค่า [NotesCommentsLayoutingOptions.setCommentsPosition](https://reference.aspose.com/slides/th/python-java/aspose.slides/notescommentslayoutingoptions/#setCommentsPosition) ก่อนการส่งออก.

## **คำถามที่พบบ่อย**

**ฉันสามารถรวมสไลด์ที่ซ่อนอยู่ใน SWF ได้หรือไม่?**

ใช่. เรียก [SwfOptions.setShowHiddenSlides](https://reference.aspose.com/slides/th/python-java/aspose.slides/swfoptions/#setShowHiddenSlides) พร้อมค่า `True`. โดยค่าเริ่มต้น สไลด์ที่ซ่อนจะไม่ถูกส่งออก.

**ฉันจะควบคุมการบีบอัดและขนาดสุดท้ายของ SWF ได้อย่างไร?**

ใช้ [SwfOptions.setCompressed](https://reference.aspose.com/slides/th/python-java/aspose.slides/swfoptions/#setCompressed) เพื่อเปิดหรือปิดการบีบอัดและใช้ [SwfOptions.setJpegQuality](https://reference.aspose.com/slides/th/python-java/aspose.slides/swfoptions/#setJpegQuality) เพื่อปรับคุณภาพภาพ JPEG. คุณภาพ JPEG ที่ต่ำลงสามารถลดขนาดไฟล์ได้แต่เสียความคมชัดของภาพ.

**ตัวดูที่ฝังอยู่มีไว้ทำอะไร และควรปิดมันเมื่อใด?**

[SwfOptions.setViewerIncluded](https://reference.aspose.com/slides/th/python-java/aspose.slides/swfoptions/#setViewerIncluded) ควบคุมว่าการสร้าง SWF จะรวมตัวดูหรือไม่. ส่งค่า `False` เมื่อคุณต้องการสไลด์ที่ส่งออกโดยไม่มีตัวดูที่ฝังไว้, เช่นในตัวอย่างด้านบน.

**จะเกิดอะไรขึ้นหากฟอนต์ต้นฉบับหายไปบนเครื่องที่ทำการส่งออก?**

คุณสามารถระบุฟอนต์ปกติเริ่มต้นด้วย [setDefaultRegularFont](https://reference.aspose.com/slides/th/python-java/aspose.slides/saveoptions/#setDefaultRegularFont), ซึ่งสืบทอดโดย [SwfOptions](https://reference.aspose.com/slides/th/python-java/aspose.slides/swfoptions/). เลือกฟอนต์ที่สามารถใช้ได้ในกระบวนการส่งออก; การแทนที่ฟอนต์อาจทำให้ลักษณะข้อความและการจัดวางเปลี่ยนแปลง.