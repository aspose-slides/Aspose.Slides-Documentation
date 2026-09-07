---
title: แปลงงานนำเสนอ PowerPoint ไปเป็นโหมดแฮนดเอาต์โดยใช้ Python
linktitle: โหมดแฮนดเอาต์
type: docs
weight: 150
url: /th/python-java/convert-powerpoint-in-handout-mode/
keywords:
- แปลง PowerPoint
- แปลงงานนำเสนอ
- โหมดแฮนดเอาต์
- แฮนดเอาต์
- PPT
- PPTX
- PowerPoint
- การนำเสนอ
- Python
- Java
- Aspose.Slides
description: "แปลงงานนำเสนอ PowerPoint เป็นแฮนดเอาต์โดยใช้ Python ผ่าน Java จัดสไลด์หลายสไลด์ต่อหน้าและส่งออกเป็น PDF ด้วย Aspose.Slides."
---
## **บทนำ**

Aspose.Slides for Python via Java ช่วยให้คุณสามารถส่งออกงานนำเสนอในโหมดแฮนดเอาต์ โดยจัดหลายสไลด์บนหน้าหนึ่ง นี่เป็นประโยชน์สำหรับการพิมพ์วัสดุนำเสนอสำหรับการประชุม สัมมนา และงานที่คล้ายกัน  

กำหนดค่าเค้าโครงผ่านเมธอด [setSlidesLayoutOptions](https://reference.aspose.com/slides/th/python-java/aspose.slides/pdfoptions/#setSlidesLayoutOptions) . การจัดเรียงแบบแฮนดเอาต์ได้รับการสนับสนุนโดย [PdfOptions](https://reference.aspose.com/slides/th/python-java/aspose.slides/pdfoptions/), [RenderingOptions](https://reference.aspose.com/slides/th/python-java/aspose.slides/renderingoptions/), [HtmlOptions](https://reference.aspose.com/slides/th/python-java/aspose.slides/htmloptions/), และ [TiffOptions](https://reference.aspose.com/slides/th/python-java/aspose.slides/tiffoptions/) . ใช้วัตถุ [HandoutLayoutingOptions](https://reference.aspose.com/slides/th/python-java/aspose.slides/handoutlayoutingoptions/) เพื่อระบุการจัดวางและการตั้งค่าการแสดงผล

## **การส่งออกโหมดแฮนดเอาต์**

เพื่อส่งออกงานนำเสนอในโหมดแฮนดเอาต์ ให้สร้างอินสแตนซ์ของ [HandoutLayoutingOptions](https://reference.aspose.com/slides/th/python-java/aspose.slides/handoutlayoutingoptions/) และกำหนดให้กับตัวเลือกการส่งออกปลายทางโดยใช้เมธอด [setSlidesLayoutOptions](https://reference.aspose.com/slides/th/python-java/aspose.slides/pdfoptions/#setSlidesLayoutOptions)

ตัวอย่างต่อไปนี้โหลด `sample.pptx` และส่งออกเป็น PDF ด้วยสี่สไลด์ต่อหน้าในลำดับแนวนอน รวมหมายเลขสไลด์และกรอบรอบสไลด์ และไม่รวมความคิดเห็น

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import HandoutLayoutingOptions, HandoutType, PdfOptions, Presentation, SaveFormat

# โหลดงานนำเสนอ.
presentation = Presentation("sample.pptx")
try:
    # กำหนดค่าเค้าโครงแฮนดเอาต์.
    slides_layout_options = HandoutLayoutingOptions()
    slides_layout_options.setHandout(HandoutType.Handouts4Horizontal)
    slides_layout_options.setPrintSlideNumbers(True)
    slides_layout_options.setPrintFrameSlide(True)
    slides_layout_options.setPrintComments(False)

    pdf_options = PdfOptions()
    pdf_options.setSlidesLayoutOptions(slides_layout_options)

    # ส่งออกงานนำเสนอเป็น PDF ด้วยเค้าโครงที่เลือก.
    presentation.save("output.pdf", SaveFormat.Pdf, pdf_options)
finally:
    presentation.dispose()
```

{{% alert color="warning" title="คำเตือน" %}}
การตั้งค่าเค้าโครงแฮนดเอาต์จะใช้กับรูปแบบเอาต์พุตที่รองรับ เช่น PDF, HTML, TIFF และภาพที่เรนเดอร์ ไม่ได้ทำการจัดเรียงสไลด์ใหม่ในงานนำเสนอต้นฉบับ
{{% /alert %}}

## **คำถามที่พบบ่อย**

**จำนวนสูงสุดของภาพย่อสไลด์ต่อหน้าที่สามารถแสดงในโหมดแฮนดเอาต์ได้คือเท่าไหร่?**

Aspose.Slides รองรับสูงสุดเก้าภาพย่อต่อหน้า ค่าที่กำหนดไว้ล่วงหน้าของ [HandoutType](https://reference.aspose.com/slides/th/python-java/aspose.slides/handouttype/) มีให้เลือกแบบหนึ่ง, สอง, สาม, สี่, หก หรือเก้าสตไลด์ต่อหน้า ค่ากำหนดสี่, หก และเก้าสตไลด์มีการจัดเรียงทั้งแนวนอนและแนวตั้ง

**ฉันสามารถกำหนดตารางแบบกำหนดเอง เช่น ห้าหรือแปดสไลด์ต่อหน้าได้หรือไม่?**

ไม่ได้ จำนวนและลำดับของภาพย่อถูกควบคุมโดยค่าที่กำหนดไว้ล่วงหน้าของ [HandoutType](https://reference.aspose.com/slides/th/python-java/aspose.slides/handouttype/) ไม่รองรับตารางแบบกำหนดเองในการตั้งค่าเค้าโครงแฮนดเอาต์นี้

**ฉันสามารถรวมสไลด์ที่ซ่อนอยู่ในผลลัพธ์แฮนดเอาต์ได้หรือไม่?**

ได้ ให้เปิดใช้งานสไลด์ที่ซ่อนอยู่ในการตั้งค่าการส่งออกสำหรับรูปแบบเป้าหมาย สำหรับ PDF ให้เรียกใช้ [PdfOptions.setShowHiddenSlides](https://reference.aspose.com/slides/th/python-java/aspose.slides/pdfoptions/#setShowHiddenSlides) พร้อมค่า `True` ก่อนบันทึกงานนำเสนอ