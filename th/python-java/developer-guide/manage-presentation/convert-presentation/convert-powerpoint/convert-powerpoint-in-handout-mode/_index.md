---
title: แปลงงานนำเสนอ PowerPoint ในโหมด Handout ด้วย Python
linktitle: โหมด Handout
type: docs
weight: 150
url: /th/python-java/convert-powerpoint-in-handout-mode/
keywords:
- แปลง PowerPoint
- แปลงงานนำเสนอ
- โหมด Handout
- Handout
- PPT
- PPTX
- PowerPoint
- งานนำเสนอ
- Python
- Java
- Aspose.Slides
description: "แปลงงานนำเสนอ PowerPoint เป็นแฮนด์เอาท์ด้วย Python ผ่าน Java จัดหลายสไลด์ต่อหน้าและส่งออกเป็น PDF ด้วย Aspose.Slides."
---
## **บทนำ**

Aspose.Slides for Python via Java ให้คุณส่งออกงานนำเสนอในโหมด Handout โดยจัดหลายสไลด์ในหน้าหนึ่ง ซึ่งมีประโยชน์สำหรับการพิมพ์เอกสารงานนำเสนอสำหรับการประชุม สัมมนา และกิจกรรมที่คล้ายกัน

กำหนดค่าเลย์เอาต์ผ่านเมธอด [setSlidesLayoutOptions](https://reference.aspose.com/slides/th/python-java/aspose.slides/pdfoptions/#setSlidesLayoutOptions) . เลย์เอาต์แบบ Handout รองรับโดย [PdfOptions](https://reference.aspose.com/slides/th/python-java/aspose.slides/pdfoptions/), [RenderingOptions](https://reference.aspose.com/slides/th/python-java/aspose.slides/renderingoptions/), [HtmlOptions](https://reference.aspose.com/slides/th/python-java/aspose.slides/htmloptions/), และ [TiffOptions](https://reference.aspose.com/slides/th/python-java/aspose.slides/tiffoptions/). ใช้วัตถุ [HandoutLayoutingOptions](https://reference.aspose.com/slides/th/python-java/aspose.slides/handoutlayoutingoptions/) เพื่อระบุการจัดวางและการตั้งค่าการแสดงผล

หากต้องการตั้งค่าขนาดและแนวของหน้าการแจกจ่ายก่อนการส่งออก โปรดดูที่ [Notes Page Size](/slides/th/python-java/notes-size/)

## **การส่งออกในโหมด Handout**

เพื่อส่งออกงานนำเสนอในโหมด Handout ให้สร้างอินสแตนซ์ของ [HandoutLayoutingOptions](https://reference.aspose.com/slides/th/python-java/aspose.slides/handoutlayoutingoptions/) แล้วกำหนดให้กับตัวเลือกการส่งออกเป้าหมายโดยใช้ [setSlidesLayoutOptions](https://reference.aspose.com/slides/th/python-java/aspose.slides/pdfoptions/#setSlidesLayoutOptions)

ตัวอย่างต่อไปนี้โหลด `sample.pptx` และส่งออกเป็น PDF โดยมีสี่สไลด์ต่อหน้าในลำดับแนวนอน ซึ่งจะรวมหมายเลขสไลด์และกรอบรอบสไลด์ และไม่รวมความคิดเห็น

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import HandoutLayoutingOptions, HandoutType, PdfOptions, Presentation, SaveFormat

# โหลดงานนำเสนอ.
presentation = Presentation("sample.pptx")
try:
    # กำหนดค่าเลย์เอาต์ Handout.
    slides_layout_options = HandoutLayoutingOptions()
    slides_layout_options.setHandout(HandoutType.Handouts4Horizontal)
    slides_layout_options.setPrintSlideNumbers(True)
    slides_layout_options.setPrintFrameSlide(True)
    slides_layout_options.setPrintComments(False)

    pdf_options = PdfOptions()
    pdf_options.setSlidesLayoutOptions(slides_layout_options)

    # ส่งออกงานนำเสนอเป็น PDF พร้อมเลย์เอาต์ที่เลือก.
    presentation.save("output.pdf", SaveFormat.Pdf, pdf_options)
finally:
    presentation.dispose()
```

{{% alert color="warning" title="Warning" %}}
การตั้งค่าเลย์เอาต์ Handout มีผลกับรูปแบบเอาต์พุตที่รองรับ เช่น PDF, HTML, TIFF และภาพที่เรนเดอร์ ไม่ได้จัดเรียงสไลด์ใหม่ในงานนำเสนอเดิม
{{% /alert %}}

## **คำถามที่พบบ่อย**

**จำนวนสูงสุดของภาพขนาดย่อของสไลด์ต่อหน้าในโหมด Handout คือเท่าไหร่?**

Aspose.Slides รองรับภาพขนาดย่อสูงสุดถึงเก้าภาพต่อหน้า ค่าที่กำหนดไว้ล่วงหน้าใน [HandoutType](https://reference.aspose.com/slides/th/python-java/aspose.slides/handouttype/) มีให้เลือกหนึ่ง, สอง, สาม, สี่, หก หรือเก้าสไลด์ต่อหน้า พรีเซ็ตสี่, หก, และเก้าสไลด์ยังรองรับการจัดเรียงในแนวนอนและแนวดิ่ง

**ฉันสามารถกำหนดกริดแบบกำหนดเอง เช่นห้าหรือแปดสไลด์ต่อหน้าได้หรือไม่?**

ไม่ได้. จำนวนและลำดับของภาพขนาดย่อถูกควบคุมโดยค่าที่กำหนดไว้ล่วงหน้าใน [HandoutType](https://reference.aspose.com/slides/th/python-java/aspose.slides/handouttype/) ระบบกริดแบบกำหนดเองเช่นห้าหรือแปดสไลด์ต่อหน้าไม่ได้รับการสนับสนุนโดยการตั้งค่าเลย์เอาต์ Handout เหล่านี้

**ฉันสามารถรวมสไลด์ที่ซ่อนอยู่ในผลลัพธ์ Handout ได้หรือไม่?**

ได้. เปิดใช้งานสไลด์ที่ซ่อนอยู่ในตั้งค่าการส่งออกสำหรับรูปแบบเป้าหมาย สำหรับ PDF ให้เรียก [PdfOptions.setShowHiddenSlides](https://reference.aspose.com/slides/th/python-java/aspose.slides/pdfoptions/#setShowHiddenSlides) ด้วยค่า `True` ก่อนบันทึกงานนำเสนอ