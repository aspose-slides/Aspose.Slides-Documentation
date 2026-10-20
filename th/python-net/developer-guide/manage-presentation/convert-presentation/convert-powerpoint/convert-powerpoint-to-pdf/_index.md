---
title: แปลง PPT และ PPTX เป็น PDF ใน Python | ตัวเลือกขั้นสูง
linktitle: PowerPoint เป็น PDF
type: docs
weight: 40
url: /th/python-net/convert-powerpoint-to-pdf/
aliases:
  - /python-net/convert-to-pdf/
keywords:
- แปลง PowerPoint
- การนำเสนอ
- PowerPoint เป็น PDF
- PPT เป็น PDF
- PPTX เป็น PDF
- บันทึก PowerPoint เป็น PDF
- ไฟล์แนบ
- PDF/A1a
- PDF/A1b
- PDF/UA
- Python
- Aspose.Slides สำหรับ Python
description: "คู่มือขั้นตอนโดยละเอียดสำหรับการแปลง PPT, PPTX และ ODP เป็น PDF คุณภาพสูงที่สอดคล้องกับ WCAG ใน Python ด้วย Aspose.Slides — รวมการป้องกันด้วยรหัสผ่าน, การเลือกสไลด์, และการควบคุมคุณภาพภาพ."
showReadingTime: true
---
## **ภาพรวม**

การแปลงการนำเสนอ PowerPoint (PPT, PPTX, ODP) เป็นรูปแบบ PDF ใน Python มีข้อได้เปรียบหลายประการ รวมถึงการรับประกันความเข้ากันได้บนอุปกรณ์ต่าง ๆ และการรักษาการจัดวางและการจัดรูปแบบของการนำเสนอของคุณ คู่มือนี้จะแสดงวิธีการแปลงการนำเสนอเป็นเอกสาร PDF ใช้ตัวเลือกต่าง ๆ เพื่อควบคุมคุณภาพภาพ รวมถึงการรวมสไลด์ที่ซ่อนอยู่ การป้องกัน PDF ด้วยรหัสผ่าน การตรวจจับการแทนที่ฟอนต์ การเลือกสไลด์เฉพาะสำหรับการแปลง และการนำมาตรฐานการปฏิบัติตามไปใช้กับเอกสารผลลัพธ์

## **การแปลง PowerPoint เป็น PDF**

โดยใช้ Aspose.Slides คุณสามารถแปลงการนำเสนอในรูปแบบต่อไปนี้เป็น PDF:

* **PPT**
* **PPTX**
* **ODP**

เพื่อแปลงการนำเสนอเป็น PDF ใน Python คุณเพียงแค่ต้องส่งชื่อไฟล์เป็นอาร์กิวเมนต์ให้กับคลาส [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) จากนั้นบันทึกการนำเสนอเป็น PDF ด้วยเมธอด [save](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/save/) . คลาส [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) มีเมธอด [save](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/save/) ที่โดยปกติใช้ในการแปลงการนำเสนอเป็น PDF.

{{% alert color="info" title="Note" %}}
Aspose.Slides for Python จะใส่ข้อมูล API และหมายเลขเวอร์ชันของมันลงในเอกสารผลลัพธ์ ตัวอย่างเช่น เมื่อแปลงการนำเสนอเป็น PDF Aspose.Slides for Python จะเติมค่าในช่อง Application ด้วยค่า '*Aspose.Slides*' และช่อง PDF Producer ด้วยค่าที่มีรูปแบบ '*Aspose.Slides v XX.XX*' **หมายเหตุ** ว่าคุณไม่สามารถสั่งให้ Aspose.Slides for Python เปลี่ยนหรือเอาข้อมูลนี้ออกจากเอกสารผลลัพธ์ได้.
{{% /alert %}}

Aspose.Slides อนุญาตให้คุณแปลง:

* การนำเสนอทั้งหมดเป็น PDF
* สไลด์เฉพาะในการนำเสนอเป็น PDF

Aspose.Slides ส่งออกการนำเสนอเป็น PDF โดยทำให้เนื้อหาของ PDF ที่ได้ตรงกับการนำเสนอเดิมอย่างใกล้ชิด สมาชิกและแอตทริบิวต์จะถูกเรนเดอร์อย่างแม่นยำในการแปลง รวมถึง:

* รูปภาพ
* กล่องข้อความและรูปร่าง
* การจัดรูปแบบข้อความ
* การจัดรูปแบบย่อหน้า
* ลิงก์
* หัวกระดาษและท้ายกระดาษ
* หัวข้อย่อย
* ตาราง

## **แปลง PowerPoint เป็น PDF**

กระบวนการแปลง PowerPoint เป็น PDF มาตรฐานใช้ตัวเลือกค่าเริ่มต้น ในกรณีนี้ Aspose.Slides จะพยายามแปลงการนำเสนอที่ให้เป็น PDF ด้วยการตั้งค่าที่เหมาะสมที่สุดในระดับคุณภาพสูงสุด.

ตัวอย่างต่อไปนี้โหลดการนำเสนอและบันทึกสไลด์ที่มองเห็นทั้งหมดเป็น PDF โดยใช้การตั้งค่าการส่งออกค่าเริ่มต้น.

```python
import aspose.slides as slides

with slides.Presentation("PowerPoint.ppt") as presentation:
    presentation.save("PPT-to-PDF.pdf", slides.export.SaveFormat.PDF)
```

{{% alert color="info" title="Note" %}}
Aspose ให้บริการ [**ตัวแปลง PowerPoint เป็น PDF**](https://products.aspose.app/slides/conversion/ppt-to-pdf) ออนไลน์ฟรีที่แสดงกระบวนการแปลงการนำเสนอเป็น PDF สำหรับการใช้งานจริงของขั้นตอนที่อธิบายในที่นี่ คุณสามารถทดสอบด้วยตัวแปลงได้.
{{% /alert %}}

## **แปลง PowerPoint เป็น PDF ด้วยตัวเลือก**

Aspose.Slides มีตัวเลือกที่กำหนดเอง—คุณสมบัติภายใต้คลาส [PdfOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/)—ที่ให้คุณปรับแต่ง PDF (ที่ได้จากกระบวนการแปลง) ล็อก PDF ด้วยรหัสผ่าน หรือแม้กระทั่งกำหนดวิธีการทำงานของกระบวนการแปลง.

### **แปลง PowerPoint เป็น PDF ด้วยตัวเลือกที่กำหนดเอง**

โดยใช้ตัวเลือกการแปลงที่กำหนดเอง คุณสามารถตั้งค่าคุณภาพที่ต้องการสำหรับภาพแรสเตอร์ กำหนดวิธีการจัดการเมตาไฟล์ ตั้งค่าระดับการบีบอัดข้อความ กำหนด DPI สำหรับภาพ ฯลฯ

```python
import aspose.slides as slides

pdf_options = slides.export.PdfOptions()
pdf_options.jpeg_quality = 90
pdf_options.sufficient_resolution = 300
pdf_options.save_metafiles_as_png = True
pdf_options.text_compression = slides.export.PdfTextCompression.FLATE
pdf_options.compliance = slides.export.PdfCompliance.PDF15

with slides.Presentation("PowerPoint.pptx") as presentation:
    presentation.save("PowerPoint-to-PDF.pdf", slides.export.SaveFormat.PDF, pdf_options)
```

### **เลือกการบีบอัดภาพโดยอัตโนมัติ**

เมื่อการนำเสนอมีรูปภาพหรือภาพหน้าจอจำนวนมาก การลดขนาดของ PDF ที่ส่งออกลงสามารถทำให้ส่งอีเมลหรือดาวน์โหลดได้ง่ายขึ้น ตั้งค่า [PdfOptions.best_images_compression_ratio](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/best_images_compression_ratio/) เป็น `True` เพื่อให้ระบบเลือกอัลกอริทึมการบีบอัดที่เหมาะสมที่สุดสำหรับแต่ละภาพโดยอัตโนมัติในระหว่างการส่งออก PDF.

ตัวอย่างต่อไปนี้โหลดการนำเสนอที่มีอยู่แล้ว เปิดใช้งานการเลือกการบีบอัดภาพอัตโนมัติ และบันทึกเป็นเอกสาร PDF การตั้งค่าอื่น ๆ ของการส่งออก PDF จะคงค่าเริ่มต้น.

```python
import aspose.slides as slides

pdf_options = slides.export.PdfOptions()
pdf_options.best_images_compression_ratio = True

with slides.Presentation("image-heavy.pptx") as presentation:
    presentation.save("image-heavy.pdf", slides.export.SaveFormat.PDF, pdf_options)
```

ตัวเลือกนี้เลือกอัลกอริทึมการบีบอัดสำหรับแต่ละภาพ การลดค่า [jpeg_quality](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/jpeg_quality/) จะทำให้คุณภาพภาพ JPEG ต่ำลง ในขณะที่การลดค่า [sufficient_resolution](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/sufficient_resolution/) จะทำให้ภาพถูกลดความละเอียดลง ซึ่งอาจทำให้รายละเอียดลดลง การเปิดใช้งานการเลือกการบีบอัดอัตโนมัติไม่ได้ทำให้ค่าทั้งสองนี้ลดลงโดยอัตโนมัติ.

การเลือกอัลกอริทึมการบีบอัดภาพต้องใช้เวลาและหน่วยความจำเพิ่มเติม การลดขนาดขึ้นอยู่กับภาพและการตั้งค่าการส่งออกของการนำเสนอ; การลดขนาดแบบคงที่ไม่สามารถรับประกันได้สำหรับทุกการนำเสนอ.

### **คงไฟล์ OLE ที่ฝังอยู่เป็นไฟล์แนบ PDF**

หากการนำเสนอมีเวิร์กบุ๊ก Excel ฝังอยู่ คุณอาจต้องการให้ผู้รับ PDF สามารถเข้าถึงข้อมูลของเวิร์กบุ๊กนั้นได้พร้อมกับดูสไลด์ ตั้งค่า [PdfOptions.include_ole_data](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/include_ole_data/) เป็น `True` เพื่อคงไฟล์ OLE ที่ฝังไว้เป็นไฟล์แนบใน PDF ที่ได้.

ค่าเริ่มต้นคือ `False`: ภาพตัวอย่างหรือไอคอนของอ็อบเจ็กต์ OLE จะถูกเรนเดอร์บนหน้า PDF แต่ไฟล์ที่ฝังอยู่จะไม่รวมเป็นไฟล์แนบ การตั้งค่าตัวเลือกเป็น `True` จะเพิ่มการรวมข้อมูลไฟล์ด้วย ตัวอย่างยังคงเป็นการแสดงภาพ; ไฟล์แนบทำให้ผู้รับสามารถเปิดหรือบันทึกไฟล์ที่ฝังแยกต่างหากได้ อ็อบเจ็กต์ OLE จะไม่กลายเป็นเวิร์กชีต Excel ที่โต้ตอบได้บนหน้า PDF.

ตัวอย่างต่อไปนี้โหลดการนำเสนอที่มีเวิร์กบุ๊ก Excel ฝังอยู่แล้วและส่งออกเป็น PDF พร้อมแนบเวิร์กบุ๊ก.

```python
import aspose.slides as slides

pdf_options = slides.export.PdfOptions()
pdf_options.include_ole_data = True

with slides.Presentation("presentation.pptx") as presentation:
    presentation.save("presentation.pdf", slides.export.SaveFormat.PDF, pdf_options)
```

เพื่อดูผลลัพธ์:

1. เปิด PDF ที่ส่งออกในโปรแกรมดูที่รองรับไฟล์แนบ เช่น Adobe Acrobat Reader.
2. เปิดแผง **Attachments** ของโปรแกรมดูและค้นหาเวิร์กบุ๊กที่ฝังอยู่.
3. บันทึกไฟล์แนบและเปิดใน Excel เพื่อตรวจสอบข้อมูล, หรือเปิดโดยตรงหากโปรแกรมดูอนุญาต. ตัวอย่างบนหน้า PDF เป็นส่วนแยกจากไฟล์แนบ.

{{% alert color="info" title="Note" %}}
มาตรฐาน PDF/A กำหนดข้อจำกัดสำหรับไฟล์แนบ: PDF/A-1 ห้ามไฟล์ฝัง, PDF/A-2 อนุญาตเฉพาะไฟล์แนบ PDF/A, และ PDF/A-3 อนุญาตประเภทไฟล์อื่น ๆ รวมถึงเวิร์กบุ๊ก Excel นี้คือข้อกำหนดของมาตรฐาน ไม่ได้เป็นข้อจำกัดเฉพาะของ Aspose.Slides ตัวอย่างนี้ใช้การตั้งค่าการปฏิบัติตาม PDF เริ่มต้นและไม่ได้สาธิตการส่งออก PDF/A.
{{% /alert %}}

### **แปลง PowerPoint เป็น PDF พร้อมสไลด์ที่ซ่อนอยู่**

หากการนำเสนอมีสไลด์ที่ซ่อนอยู่ คุณสามารถใช้ตัวเลือกที่กำหนดเอง—คุณสมบัติ [show_hidden_slides](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/show_hidden_slides/) จากคลาส [PdfOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/)—เพื่อสั่งให้ Aspose.Slides รวมสไลด์ที่ซ่อนไว้เป็นหน้าใน PDF ที่ได้.

ตัวอย่างต่อไปนี้ส่งออกการนำเสนอเป็น PDF พร้อมรวมสไลด์ที่ซ่อนอยู่ทั้งหมด.

```python
import aspose.slides as slides

pdf_options = slides.export.PdfOptions()
pdf_options.show_hidden_slides = True

with slides.Presentation("PowerPoint.pptx") as presentation:
    presentation.save("PowerPoint-to-PDF.pdf", slides.export.SaveFormat.PDF, pdf_options)
```

### **แปลง PowerPoint เป็น PDF ที่มีการป้องกันด้วยรหัสผ่าน**

ตัวอย่างต่อไปนี้ส่งออกการนำเสนอเป็น PDF ที่ต้องใช้รหัสผ่าน `password` เพื่อเปิด การอนุญาตการเข้าถึงอนุญาตให้พิมพ์รวมถึงการพิมพ์คุณภาพสูง.

```python
import aspose.slides as slides

pdf_options = slides.export.PdfOptions()
pdf_options.password = "password"
pdf_options.access_permissions = slides.export.PdfAccessPermissions.PRINT_DOCUMENT | slides.export.PdfAccessPermissions.HIGH_QUALITY_PRINT

with slides.Presentation("PowerPoint.pptx") as presentation:
    presentation.save("PPTX-to-PDF.pdf", slides.export.SaveFormat.PDF, pdf_options)
```

### **จัดการฟอนต์ที่ไม่มีรูปแบบตัวหนาเฉพาะ**

การนำเสนอสามารถใช้รูปแบบตัวหนาสำหรับข้อความได้แม้ฟอนต์นั้นจะไม่มีรูปแบบตัวหนาเฉพาะ ข้อความยังคงดูเป็นตัวหนาผ่านการทำตัวหนาสังเคราะห์ ซึ่งทำให้ตัวอักษรปกติหนาขึ้น หากข้อความนั้นดูหนามากเกินไปหรือแตกต่างจากลักษณะที่ต้องการใน PDF ให้ลองตั้งค่า [PdfOptions.rasterize_unsupported_font_styles](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/rasterize_unsupported_font_styles/) เป็น `True` ตัวเลือกนี้จะเรนเดอร์ข้อความที่ได้รับผลกระทบเป็นบิตแมพในการส่งออก PDF และอาจทำให้ลักษณะของฟอนต์บางตัวดีขึ้น ค่าเริ่มต้นคือ `False`.

ตัวอย่างการนำเสนอมีสองกล่องข้อความ: หนึ่งกล่องมีข้อความปกติและอีกหนึ่งกล่องมีรูปแบบตัวหนาที่ใช้ฟอนต์เดียวกันซึ่งไม่มีรูปแบบตัวหนาเฉพาะ ตัวอย่างต่อไปนี้โหลดการนำเสนอ, เปิดใช้งานการเรเซอร์ไทซ์รูปแบบฟอนต์ที่ไม่รองรับ, และส่งออกเป็น PDF:

```python
import aspose.slides as slides

pdf_options = slides.export.PdfOptions()
pdf_options.rasterize_unsupported_font_styles = True

with slides.Presentation("unsupported-bold.pptx") as presentation:
    presentation.save("rasterized.pdf", slides.export.SaveFormat.PDF, pdf_options)
```

ภาพตัวอย่างต่อไปนี้แสดงผลลัพธ์ที่ปิดการใช้งานและเปิดการใช้งาน ตัวอย่างนี้ข้อความตัวหนามีเส้นหนากว่าเมื่อปิดตัวเลือก เมื่อเปิดตัวเลือกเส้นจะบางลง; ข้อความปกติคงเดิม เปรียบเทียบผลลัพธ์ก่อนเลือกการตั้งค่าสำหรับการนำเสนอของคุณ.

| ตัวเลือกปิด (`False`, ค่าเริ่มต้น) | ตัวเลือกเปิด (`True`) |
|---|---|
| ![PDF with unsupported font style rasterization disabled](unsupported-bold-disabled.png) | ![PDF with unsupported font style rasterization enabled](unsupported-bold-enabled.png) |

ในตัวอย่างนี้ การเปิดใช้งานตัวเลือกจะทำให้ข้อความตัวหนาแปลงเป็นบิตแมพเท่านั้น: ไม่สามารถเลือก, คัดลอก หรือค้นหาเป็นข้อความได้โดยไม่มี OCR และขอบของมันดูอ่อนลงที่การซูม 800% ข้อความปกติยังคงสามารถค้นหาได้ หากปิดตัวเลือก สตริงทั้งสองยังคงเป็นข้อความ.

ตัวเลือกนี้เรเซอร์ไทซ์ข้อความที่จัดรูปแบบเป็นตัวหนาเมื่อฟอนต์ไม่มีรูปแบบตัวหนาเฉพาะ [การแทนที่ฟอนต์](/slides/th/python-net/font-substitution/) จะเลือกฟอนต์อื่นเมื่อฟอนต์ต้นฉบับไม่พร้อมใช้งาน.

## **แปลงสไลด์ที่เลือกใน PowerPoint เป็น PDF**

ตัวอย่างต่อไปนี้ส่งออกสไลด์ที่ 1 และ 3 จากการนำเสนอเป็น PDF ตัวเลขสไลด์ในอาร์เรย์นี้เริ่มจาก 1 และการนำเข้าต้องมีสไลด์อย่างน้อยสามสไลด์.

```python
import aspose.slides as slides

with slides.Presentation("PowerPoint.pptx") as presentation:
    slide_numbers = [1, 3]
    presentation.save("PPTX-to-PDF.pdf", slide_numbers, slides.export.SaveFormat.PDF)
```

## **แปลง PowerPoint เป็น PDF ด้วยขนาดสไลด์ที่กำหนดเอง**

ตัวอย่างต่อไปนี้คัดลอกสไลด์แรกจากการนำเสนอไปยังการนำเสนอใหม่ที่มีขนาดสไลด์ 612 × 792 จุด (8.5 × 11 นิ้ว) มันปรับสเกลเนื้อหาสไลด์ให้พอดีและส่งออกสไลด์เดียวเป็น PDF.

```python
import aspose.slides as slides

slide_width = 612
slide_height = 792

with slides.Presentation("SelectedSlides.pptx") as presentation:
    with slides.Presentation() as resized_presentation:
        resized_presentation.slide_size.set_size(slide_width, slide_height, slides.SlideSizeScaleType.ENSURE_FIT)
        slide = presentation.slides[0]
        resized_presentation.slides.insert_clone(0, slide)

        # ลบสไลด์ว่างที่สร้างขึ้นพร้อมกับการนำเสนอใหม่.
        resized_presentation.slides.remove_at(1)

        resized_presentation.save("PDF_with_custom_slide_size.pdf", slides.export.SaveFormat.PDF)
```

## **แปลง PowerPoint เป็น PDF ในมุมมองโน้ตสไลด์**

ตัวอย่างต่อไปนี้ส่งออกการนำเสนอเป็น PDF โดยวางโน้ตของผู้พูดของแต่ละสไลด์ไว้ใต้สไลด์ ใช้การนำเสนอที่มีโน้ตผู้พูดเพื่อดูผลลัพธ์.

```python
import aspose.slides as slides

pdf_options = slides.export.PdfOptions()
pdf_options.slides_layout_options = slides.export.NotesCommentsLayoutingOptions()
pdf_options.slides_layout_options.notes_position = slides.export.NotesPositions.BOTTOM_FULL

with slides.Presentation("NotesFile.pptx") as presentation:
    presentation.save("Pdf_Notes_out.pdf", slides.export.SaveFormat.PDF, pdf_options)
```

## **มาตรฐานการเข้าถึงและการปฏิบัติตามสำหรับ PDF**

Aspose.Slides อนุญาตให้คุณใช้ขั้นตอนการแปลงที่สอดคล้องกับ [แนวทางการเข้าถึงเนื้อหาเว็บ (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html) คุณสามารถส่งออกเอกสาร PowerPoint เป็น PDF โดยใช้มาตรฐานการปฏิบัติตามเหล่านี้: **PDF/A1a**, **PDF/A1b**, และ **PDF/UA**.

โค้ด Python นี้แสดงการดำเนินการแปลง PowerPoint เป็น PDF ที่ได้ PDF หลายไฟล์ตามมาตรฐานการปฏิบัติตามที่ต่างกัน:

```python
import aspose.slides as slides

pres = slides.Presentation("pres.pptx")

options = slides.export.PdfOptions()

options.compliance = slides.export.PdfCompliance.PDF_A1A
pres.save("pres-a1a-compliance.pdf", slides.export.SaveFormat.PDF, options)

options.compliance = slides.export.PdfCompliance.PDF_A1B
pres.save("pres-a1b-compliance.pdf", slides.export.SaveFormat.PDF, options)

options.compliance = slides.export.PdfCompliance.PDF_UA
pres.save("pres-ua-compliance.pdf", slides.export.SaveFormat.PDF, options)
```

{{% alert color="info" title="Note" %}}
การสนับสนุนการแปลง PDF ของ Aspose.Slides ให้คุณแปลง PDF ไปยังรูปแบบไฟล์ที่นิยมที่สุด คุณสามารถทำการแปลง [PDF เป็น HTML](https://products.aspose.com/slides/python-net/conversion/pdf-to-html/), [PDF เป็นภาพ](https://products.aspose.com/slides/python-net/conversion/pdf-to-image/), [PDF เป็น JPG](https://products.aspose.com/slides/python-net/conversion/pdf-to-jpg/) และ [PDF เป็น PNG](https://products.aspose.com/slides/python-net/conversion/pdf-to-png/) ได้ การแปลง PDF ไปยังรูปแบบพิเศษอื่น ๆ — [PDF เป็น SVG](https://products.aspose.com/slides/python-net/conversion/pdf-to-svg/), [PDF เป็น TIFF](https://products.aspose.com/slides/python-net/conversion/pdf-to-tiff/), และ [PDF เป็น XML](https://products.aspose.com/slides/python-net/conversion/pdf-to-xml/) — ก็ได้รับการสนับสนุนเช่นกัน.
{{% /alert %}}

> **หมายเหตุ:** เมื่อส่งออกเป็น PDF/UA Aspose.Slides จะถือกราฟิกซับซ้อนเช่น SmartArt, แผนภูมิ, และสูตรเป็นรูปเดียว ส่วนองค์ประกอบเส้นทางแยกไม่ถูกเก็บเป็นเนื้อหาแยกและอาจถูกทำเครื่องหมายเป็นส่วนเกิน; ข้อความแทนที่จะมีเฉพาะสำหรับรูปทั้งหมดเท่านั้น.

## **คำถามที่พบบ่อย**

**Aspose.Slides for Python สามารถลบข้อมูลแอปพลิเคชันออกจาก PDF ได้หรือไม่?**

ไม่, Aspose.Slides for Python จะรวมข้อมูล API และหมายเลขเวอร์ชันลงใน PDF ที่ส่งออกโดยอัตโนมัติ ข้อมูลนี้ไม่สามารถแก้ไขหรือเอาออกได้.

**ฉันจะรวมสไลด์เฉพาะในการแปลงเป็น PDF ได้อย่างไร?**

คุณสามารถระบุดัชนีสไลด์ที่ต้องการแปลงได้โดยส่งอาร์เรย์ของตำแหน่งสไลด์ไปยังเมธอด [save](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/save/).

**สามารถปกป้อง PDF ด้วยรหัสผ่านระหว่างการแปลงได้หรือไม่?**

ได้, คุณสามารถตั้งรหัสผ่านและกำหนดสิทธิ์การเข้าถึงโดยใช้คลาส [PdfOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/) ก่อนบันทึกการนำเสนอเป็น PDF.

**Aspose.Slides รองรับการแปลง PDF ไปยังรูปแบบอื่นหรือไม่?**

ใช่, Aspose.Slides รองรับการแปลง PDF ไปยังรูปแบบเช่น HTML, รูปแบบภาพ (JPG, PNG), SVG, TIFF, และ XML.

**ฉันจะทำให้แน่ใจว่า PDF ของฉันสอดคล้องกับมาตรฐานการเข้าถึงได้อย่างไร?**

ตั้งค่าคุณสมบัติ [compliance](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/compliance/) ใน [PdfOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/) เป็นมาตรฐานเช่น `PDF_A1A`, `PDF_A1B`, หรือ `PDF_UA` เพื่อให้สอดคล้องกับแนวทางการเข้าถึง.

**ฉันสามารถรวมสไลด์ที่ซ่อนอยู่ใน PDF ที่ส่งออกได้หรือไม่?**

ได้, โดยตั้งค่าคุณสมบัติ [show_hidden_slides](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/show_hidden_slides/) ใน [PdfOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/) เป็น `True` สไลด์ที่ซ่อนจะรวมอยู่ใน PDF.

**ฉันจะปรับคุณภาพและความละเอียดของภาพระหว่างการแปลงอย่างไร?**

ใช้คุณสมบัติ [jpeg_quality](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/jpeg_quality/) และ [sufficient_resolution](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/sufficient_resolution/) ใน [PdfOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/) เพื่อควบคุมคุณภาพและความละเอียดของภาพใน PDF ที่ได้.

**Aspose.Slides จัดการการแทนที่ฟอนต์โดยอัตโนมัติหรือไม่?**

Aspose.Slides ตรวจจับการแทนที่ฟอนต์ระหว่างการแปลง และคุณสามารถจัดการได้โดยใช้คุณสมบัติ `warning_callback` ใน `SaveOptions` (ขณะนี้มีข้อจำกัด).

## **แหล่งข้อมูลเพิ่มเติม**

- [เอกสาร Aspose.Slides สำหรับ Python ผ่าน .NET](/slides/th/python-net/)
- [อ้างอิง API Aspose.Slides](https://reference.aspose.com/slides/python-net/)
- [เครื่องแปลงออนไลน์ฟรีของ Aspose](https://products.aspose.app/slides/conversion)