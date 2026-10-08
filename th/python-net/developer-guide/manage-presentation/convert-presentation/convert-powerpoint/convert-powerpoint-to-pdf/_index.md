---
title: แปลง PPT & PPTX เป็น PDF ใน Python | ตัวเลือกขั้นสูง
linktitle: PowerPoint เป็น PDF
type: docs
weight: 40
url: /th/python-net/convert-powerpoint-to-pdf/
aliases:
  - /python-net/convert-to-pdf/
keywords:
- แปลง PowerPoint
- งานนำเสนอ
- PowerPoint เป็น PDF
- PPT เป็น PDF
- PPTX เป็น PDF
- บันทึก PowerPoint เป็น PDF
- ไฟล์แนบ
- PDF/A1a
- PDF/A1b
- PDF/UA
- Python
- Aspose.Slides for Python
description: "คำแนะนำแบบขั้นตอนเพื่อแปลง PPT, PPTX และ ODP เป็น PDF คุณภาพสูงที่สอดคล้องกับ WCAG ใน Python ด้วย Aspose.Slides—รวมการป้องกันด้วยรหัสผ่าน, การเลือกสไลด์, และการควบคุมคุณภาพภาพ."
showReadingTime: true
---
## **ภาพรวม**

การแปลงงานนำเสนอ PowerPoint (PPT, PPTX, ODP) เป็นรูปแบบ PDF ใน Python มีข้อได้เปรียบหลายประการ ซึ่งรวมถึงการรับประกันความเข้ากันได้บนอุปกรณ์ต่าง ๆ และการรักษารูปแบบและการจัดวางของงานนำเสนอของคุณ คู่มือนี้จะแสดงวิธีแปลงงานนำเสนอเป็นเอกสาร PDF ใช้ตัวเลือกต่าง ๆ เพื่อควบคุมคุณภาพของภาพ รวมถึงสไลด์ที่ซ่อนอยู่ การป้องกัน PDF ด้วยรหัสผ่าน การตรวจจับการแทนที่ฟอนต์ การเลือกสไลด์เฉพาะสำหรับแปลง และการใช้มาตรฐานความสอดคล้องกับเอกสารผลลัพธ์

## **การแปลง PowerPoint เป็น PDF**

โดยใช้ Aspose.Slides คุณสามารถแปลงงานนำเสนอในรูปแบบเหล่านี้เป็น PDF:

* **PPT**
* **PPTX**
* **ODP**

ในการแปลงงานนำเสนอเป็น PDF ด้วย Python เพียงแค่ส่งชื่อไฟล์เป็นอาร์กิวเมนต์ให้กับคลาส [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) แล้วบันทึกงานนำเสนอเป็น PDF ด้วยเมธอด [save](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/save/) คลาส [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) เปิดเผยเมธอด [save](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/save/) ที่มักใช้เพื่อแปลงงานนำเสนอเป็น PDF

{{% alert color="info" title="Note" %}}
Aspose.Slides สำหรับ Python จะใส่ข้อมูล API และหมายเลขเวอร์ชันลงในเอกสารผลลัพธ์ ตัวอย่างเช่น เมื่อแปลงงานนำเสนอเป็น PDF Aspose.Slides สำหรับ Python จะเติมฟิลด์ Application ด้วยค่า '*Aspose.Slides*' และฟิลด์ PDF Producer ด้วยค่ารูปแบบ '*Aspose.Slides v XX.XX*' **หมายเหตุ** คุณไม่สามารถสั่งให้ Aspose.Slides สำหรับ Python เปลี่ยนหรือเอาข้อมูลนี้ออกจากเอกสารผลลัพธ์ได้.
{{% /alert %}}

Aspose.Slides ช่วยให้คุณสามารถแปลง:

* งานนำเสนอทั้งหมดเป็น PDF
* สไลด์เฉพาะในงานนำเสนอเป็น PDF

Aspose.Slides ส่งออกงานนำเสนอเป็น PDF โดยทำให้เนื้อหาของ PDF ที่ได้ตรงกับงานนำเสนอเดิมอย่างใกล้เคียง องค์ประกอบและคุณลักษณะต่าง ๆ ถูกแสดงผลอย่างแม่นยำในการแปลง รวมถึง:

* รูปภาพ
* กล่องข้อความและรูปร่าง
* การจัดรูปแบบข้อความ
* การจัดรูปแบบย่อหน้า
* ลิงก์
* ส่วนหัวและส่วนท้าย
* สัญลักษณ์หัวข้อ
* ตาราง

## **แปลง PowerPoint เป็น PDF**

กระบวนการแปลง PowerPoint เป็น PDF มาตรฐานใช้ตัวเลือกเริ่มต้น ในกรณีนี้ Aspose.Slides จะพยายามแปลงงานนำเสนอที่ให้เป็น PDF ด้วยการตั้งค่าที่เหมาะที่สุดในระดับคุณภาพสูงสุด

ตัวอย่างต่อไปนี้โหลดงานนำเสนอและบันทึกสไลด์ที่มองเห็นทั้งหมดเป็น PDF โดยใช้การตั้งค่าการส่งออกเริ่มต้น

```python
import aspose.slides as slides

with slides.Presentation("PowerPoint.ppt") as presentation:
    presentation.save("PPT-to-PDF.pdf", slides.export.SaveFormat.PDF)
```

{{% alert color="info" title="Note" %}}
Aspose มีตัวแปลง [**PowerPoint to PDF converter**](https://products.aspose.app/slides/conversion/ppt-to-pdf) ออนไลน์ฟรีที่แสดงกระบวนการแปลงงานนำเสนอเป็น PDF สำหรับการนำไปใช้จริงของขั้นตอนที่อธิบายไว้ที่นี่ คุณสามารถทดสอบด้วยตัวแปลงได้.
{{% /alert %}}

## **แปลง PowerPoint เป็น PDF พร้อมตัวเลือก**

Aspose.Slides มีตัวเลือกที่กำหนดเอง—คุณสมบัติภายใต้คลาส [PdfOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/)—ที่ช่วยให้คุณปรับแต่ง PDF (ที่ได้จากกระบวนการแปลง) ล็อก PDF ด้วยรหัสผ่าน หรือแม้กระทั่งกำหนดวิธีการแปลง

### **แปลง PowerPoint เป็น PDF ด้วยตัวเลือกแบบกำหนดเอง**

โดยใช้ตัวเลือกการแปลงแบบกำหนดเอง คุณสามารถตั้งค่าคุณภาพที่ต้องการสำหรับภาพเรสเตอร์ ระบุวิธีการจัดการเมต้าไฟล์ ตั้งระดับการบีบอัดข้อความ ตั้งค่า DPI สำหรับภาพ เป็นต้น

ตัวอย่างต่อไปนี้ส่งออกงานนำเสนอเป็น PDF 1.5 โดยตั้งค่าคุณภาพ JPEG ที่ 90 ความละเอียดภาพที่ 300 DPI เมต้าไฟล์บันทึกเป็น PNG และใช้การบีบอัดข้อความแบบ Flate

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

### **เก็บไฟล์ OLE ฝังเป็นไฟล์แนบ PDF**

หากงานนำเสนอมีเวิร์กบุ๊ก Excel ฝังอยู่ คุณอาจต้องการให้ผู้รับ PDF เข้าถึงข้อมูลของเวิร์กบุ๊กพร้อมกับดูสไลด์ ตั้งค่า [PdfOptions.include_ole_data](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/include_ole_data/) เป็น `True` เพื่อเก็บไฟล์ OLE ฝังเป็นไฟล์แนบใน PDF ที่ได้

ค่าเริ่มต้นคือ `False` : ภาพหรือไอคอนตัวอย่างของอ็อบเจกต์ OLE จะถูกแสดงบนหน้า PDF แต่ไฟล์ฝังจะไม่รวมเป็นไฟล์แนบ การตั้งค่าเป็น `True` จะเพิ่มไฟล์ข้อมูลเข้าไป การแสดงตัวอย่างยังคงเป็นภาพแบบเห็นได้; ไฟล์แนบทำให้ผู้รับเปิดหรือบันทึกไฟล์ฝังแยกจากกัน อ็อบเจกต์ OLE จะไม่กลายเป็นแผ่นงาน Excel แบบโต้ตอบบนหน้า PDF

ตัวอย่างต่อไปนี้โหลดงานนำเสนอที่มีเวิร์กบุ๊ก Excel ฝังแล้วส่งออกเป็น PDF พร้อมแนบเวิร์กบุ๊ก

```python
import aspose.slides as slides

pdf_options = slides.export.PdfOptions()
pdf_options.include_ole_data = True

with slides.Presentation("presentation.pptx") as presentation:
    presentation.save("presentation.pdf", slides.export.SaveFormat.PDF, pdf_options)
```

เพื่อที่จะตรวจสอบผลลัพธ์:

1. เปิด PDF ที่ส่งออกในโปรแกรมดูที่รองรับไฟล์แนบ เช่น Adobe Acrobat Reader.
2. เปิดแผง **Attachments** ของโปรแกรมดูและค้นหาเวิร์กบุ๊กที่ฝังอยู่.
3. บันทึกไฟล์แนบแล้วเปิดใน Excel เพื่อตรวจสอบข้อมูล หรือเปิดโดยตรงหากโปรแกรมดูอนุญาต การแสดงตัวอย่างบนหน้า PDF จะเป็นส่วนแยกจากไฟล์แนบ.

{{% alert color="info" title="Note" %}}
มาตรฐาน PDF/A มีข้อจำกัดเกี่ยวกับไฟล์แนบ: PDF/A-1 ห้ามไฟล์ฝัง, PDF/A-2 อนุญาตเฉพาะไฟล์แนบ PDF/A, และ PDF/A-3 อนุญาตไฟล์ประเภทอื่นรวมถึงเวิร์กบุ๊ก Excel นี่เป็นข้อกำหนดของมาตรฐาน ไม่ใช่ข้อจำกัดของ Aspose.Slides ตัวอย่างนี้ใช้การตั้งค่าการปฏิบัติตาม PDF เริ่มต้นและไม่ได้แสดงการส่งออก PDF/A.
{{% /alert %}}

### **แปลง PowerPoint เป็น PDF พร้อมสไลด์ที่ซ่อน**

หากงานนำเสนอมีสไลด์ที่ซ่อน คุณสามารถใช้ตัวเลือกกำหนดเอง—คุณสมบัติ [show_hidden_slides](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/show_hidden_slides/) จากคลาส [PdfOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/) เพื่อบังคับให้ Aspose.Slides รวมสไลด์ที่ซ่อนเป็นหน้าใน PDF ที่ได้

ตัวอย่างต่อไปนี้ส่งออกงานนำเสนอเป็น PDF โดยรวมสไลด์ที่ซ่อนทั้งหมด

```python
import aspose.slides as slides

pdf_options = slides.export.PdfOptions()
pdf_options.show_hidden_slides = True

with slides.Presentation("PowerPoint.pptx") as presentation:
    presentation.save("PowerPoint-to-PDF.pdf", slides.export.SaveFormat.PDF, pdf_options)
```

### **แปลง PowerPoint เป็น PDF ที่ป้องกันด้วยรหัสผ่าน**

ตัวอย่างต่อไปนี้ส่งออกงานนำเสนอเป็น PDF ที่ต้องใช้รหัสผ่าน `password` เพื่อเปิด การอนุญาตการเข้าถึงอนุญาตการพิมพ์ รวมถึงการพิมพ์คุณภาพสูง

```python
import aspose.slides as slides

pdf_options = slides.export.PdfOptions()
pdf_options.password = "password"
pdf_options.access_permissions = slides.export.PdfAccessPermissions.PRINT_DOCUMENT | slides.export.PdfAccessPermissions.HIGH_QUALITY_PRINT

with slides.Presentation("PowerPoint.pptx") as presentation:
    presentation.save("PPTX-to-PDF.pdf", slides.export.SaveFormat.PDF, pdf_options)
```

### **จัดการฟอนต์ที่ไม่มีรูปแบบหนาแยก**

งานนำเสนอสามารถกำหนดรูปแบบตัวหนาให้กับข้อความได้แม้ฟอนต์ของมันจะไม่มีรูปแบบหนาแยก ข้อความยังคงดูเป็นตัวหนาผ่านการทำตัวหนาสังเคราะห์ที่ทำให้รูปลักษณ์ของ glyph ปกติหนาขึ้น เมื่อข้อความนั้นดูหนามากเกินไปหรือแตกต่างจากลักษณะที่ต้องการใน PDF ให้ลองตั้งค่า [PdfOptions.rasterize_unsupported_font_styles](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/rasterize_unsupported_font_styles/) เป็น `True` ตัวเลือกนี้จะแปลงข้อความที่ได้รับผลกระทบเป็นภาพบิตแมพระหว่างการส่งออก PDF และอาจทำให้ลักษณะของฟอนต์บางชนิดดีขึ้น ค่าเริ่มต้นคือ `False`

ตัวอย่างงานนำเสนอมีกล่องข้อความสองกล่อง: หนึ่งกล่องมีข้อความปกติและอีกหนึ่งมีการกำหนดรูปแบบตัวหนาให้กับฟอนต์เดียวกันที่ไม่มีรูปแบบหนาแยก ตัวอย่างต่อไปนี้โหลดงานนำเสนอ เปิดการเรสเตอร์ไลซ์ฟอนต์ที่ไม่รองรับรูปแบบหนา และส่งออกเป็น PDF:

```python
import aspose.slides as slides

pdf_options = slides.export.PdfOptions()
pdf_options.rasterize_unsupported_font_styles = True

with slides.Presentation("unsupported-bold.pptx") as presentation:
    presentation.save("rasterized.pdf", slides.export.SaveFormat.PDF, pdf_options)
```

ตัวอย่างที่แสดงต่อไปนี้แสดงผลลัพธ์เมื่อปิดและเปิดตัวเลือก ในตัวอย่างนี้ข้อความหนามีเส้นหนาขึ้นเมื่อปิดตัวเลือก เมื่อเปิดตัวเลือกเส้นจะบางลง; ข้อความปกติไม่เปลี่ยนแปลง เปรียบเทียบผลลัพธ์ก่อนเลือกการตั้งค่าสำหรับงานนำเสนอของคุณ

| ตัวเลือกปิด (`False`, ค่าเริ่มต้น) | ตัวเลือกเปิด (`True`) |
|---|---|
| ![PDF with unsupported font style rasterization disabled](unsupported-bold-disabled.png) | ![PDF with unsupported font style rasterization enabled](unsupported-bold-enabled.png) |

ในตัวอย่างนี้ การเปิดตัวเลือกทำให้ข้อความหนาเท่านั้นแปลงเป็นภาพบิตแมพ: ไม่สามารถเลือก คัดลอก หรือค้นหาเป็นข้อความได้โดยไม่มี OCR และขอบของข้อความดูอ่อนลงที่การขยาย 800% ข้อความปก่ายังคงสามารถค้นหาได้ เมื่อปิดตัวเลือก ทั้งสองข้อความจะยังคงเป็นข้อความ

ตัวเลือกนี้ทำให้ข้อความที่กำหนดรูปแบบเป็นตัวหนาเมื่อฟอนต์ไม่มีรูปแบบหนาแยกเป็นภาพบิตแมพ [Font substitution](/slides/th/python-net/font-substitution/) จะเลือกฟอนต์อื่นเมื่อฟอนต์เดิมไม่สามารถใช้ได้

## **แปลงสไลด์ที่เลือกใน PowerPoint เป็น PDF**

ตัวอย่างต่อไปนี้ส่งออกสไลด์ที่ 1 และ 3 จากงานนำเสนอเป็น PDF ตัวเลขสไลด์ในอาร์เรย์นี้เริ่มจาก 1 และงานนำเข้าต้องมีอย่างน้อยสามสไลด์

```python
import aspose.slides as slides

with slides.Presentation("PowerPoint.pptx") as presentation:
    slide_numbers = [1, 3]
    presentation.save("PPTX-to-PDF.pdf", slide_numbers, slides.export.SaveFormat.PDF)
```

## **แปลง PowerPoint เป็น PDF ด้วยขนาดสไลด์กำหนดเอง**

ตัวอย่างต่อไปนี้คัดลอกสไลด์แรกจากงานนำเสนอไปยังงานนำเสนอใหม่ที่มีขนาดสไลด์ 612 × 792 จุด (8.5 × 11 นิ้ว) มันปรับขนาดเนื้อหาสไลด์ให้พอดีและส่งออกสไลด์เดียวเป็น PDF

```python
import aspose.slides as slides

slide_width = 612
slide_height = 792

with slides.Presentation("SelectedSlides.pptx") as presentation:
    with slides.Presentation() as resized_presentation:
        resized_presentation.slide_size.set_size(slide_width, slide_height, slides.SlideSizeScaleType.ENSURE_FIT)
        slide = presentation.slides[0]
        resized_presentation.slides.insert_clone(0, slide)

        # ลบสไลด์เปล่าที่สร้างในพรีเซนเทชันใหม่
        resized_presentation.slides.remove_at(1)

        resized_presentation.save("PDF_with_custom_slide_size.pdf", slides.export.SaveFormat.PDF)
```

## **แปลง PowerPoint เป็น PDF ในโหมดโน้ตสไลด์**

ตัวอย่างต่อไปนี้ส่งออกงานนำเสนอเป็น PDF โดยวางโน้ตบรรยายของแต่ละสไลด์ด้านล่างสไลด์ ใช้งานนำเสนอที่มีโน้ตบรรยายเพื่อดูผลลัพธ์

```python
import aspose.slides as slides

pdf_options = slides.export.PdfOptions()
pdf_options.slides_layout_options = slides.export.NotesCommentsLayoutingOptions()
pdf_options.slides_layout_options.notes_position = slides.export.NotesPositions.BOTTOM_FULL

with slides.Presentation("NotesFile.pptx") as presentation:
    presentation.save("Pdf_Notes_out.pdf", slides.export.SaveFormat.PDF, pdf_options)
```

## **มาตรฐานการเข้าถึงและความสอดคล้องสำหรับ PDF**

Aspose.Slides ให้คุณใช้กระบวนการแปลงที่สอดคล้องกับ [Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html) คุณสามารถส่งออกเอกสาร PowerPoint เป็น PDF โดยใช้มาตรฐานความสอดคล้องเหล่านี้: **PDF/A1a**, **PDF/A1b**, และ **PDF/UA**

โค้ด Python นี้แสดงการทำงานแปลง PowerPoint เป็น PDF ที่ได้ PDF หลายไฟล์ตามมาตรฐานความสอดคล้องต่าง ๆ:

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
การสนับสนุนการแปลง PDF ของ Aspose.Slides ช่วยให้คุณแปลง PDF ไปยังรูปแบบไฟล์ที่นิยมที่สุด คุณสามารถทำการแปลง [PDF to HTML](https://products.aspose.com/slides/python-net/conversion/pdf-to-html/), [PDF to image](https://products.aspose.com/slides/python-net/conversion/pdf-to-image/), [PDF to JPG](https://products.aspose.com/slides/python-net/conversion/pdf-to-jpg/) และ [PDF to PNG](https://products.aspose.com/slides/python-net/conversion/pdf-to-png/) การแปลงอื่น ๆ ไปยังรูปแบบเฉพาะ—[PDF to SVG](https://products.aspose.com/slides/python-net/conversion/pdf-to-svg/), [PDF to TIFF](https://products.aspose.com/slides/python-net/conversion/pdf-to-tiff/), และ [PDF to XML](https://products.aspose.com/slides/python-net/conversion/pdf-to-xml/)—ก็ได้รับการสนับสนุนเช่นกัน
{{% /alert %}}

> **หมายเหตุ:** เมื่อส่งออกเป็น PDF/UA Aspose.Slides จัดการกราฟิกซับซ้อนเช่น SmartArt, แผนภูมิ และสูตรเป็นรูปเดียว ส่วนประกอบเส้นทางแต่ละอันจะไม่ถูกเก็บเป็นเนื้อหาแยกและอาจถูกทำเครื่องหมายเป็น artefacts; ข้อความแทนที่จะให้เฉพาะสำหรับรูปทั้งหมด.

## **คำถามที่พบบ่อย**

**Aspose.Slides สำหรับ Python สามารถลบข้อมูลแอปพลิเคชันออกจาก PDF ได้หรือไม่?**

ไม่, Aspose.Slides สำหรับ Python จะใส่ข้อมูล API และหมายเลขเวอร์ชันโดยอัตโนมัติใน PDF ที่ส่งออก ข้อมูลนี้ไม่สามารถแก้ไขหรือเอาออกได้.

**ฉันจะรวมสไลด์เฉพาะในการแปลงเป็น PDF อย่างไร?**

คุณสามารถระบุตำแหน่งสไลด์ที่ต้องการแปลงโดยส่งอาร์เรย์ของตำแหน่งสไลด์ไปยังเมธอด [save](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/save/) .

**สามารถป้องกัน PDF ด้วยรหัสผ่านระหว่างการแปลงได้หรือไม่?**

ได้, คุณสามารถตั้งรหัสผ่านและกำหนดสิทธิ์การเข้าถึงโดยใช้คลาส [PdfOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/) ก่อนบันทึกงานนำเสนอเป็น PDF.

**Aspose.Slides สนับสนุนการแปลง PDF เป็นรูปแบบอื่น ๆ หรือไม่?**

ใช่, Aspose.Slides รองรับการแปลง PDF ไปเป็นรูปแบบต่าง ๆ เช่น HTML, รูปภาพ (JPG, PNG), SVG, TIFF และ XML.

**ฉันจะทำให้ PDF ของฉันสอดคล้องกับมาตรฐานการเข้าถึงได้อย่างไร?**

ตั้งค่าคุณสมบัติ [compliance](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/compliance/) ใน [PdfOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/) เป็นมาตรฐานเช่น `PDF_A1A`, `PDF_A1B` หรือ `PDF_UA` เพื่อให้สอดคล้องกับแนวทางการเข้าถึง.

**ฉันสามารถรวมสไลด์ที่ซ่อนอยู่ในผลลัพธ์ PDF ได้หรือไม่?**

ได้, โดยตั้งค่าคุณสมบัติ [show_hidden_slides](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/show_hidden_slides/) ใน [PdfOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/) เป็น `True` สไลด์ที่ซ่อนจะถูกรวมใน PDF.

**ฉันจะปรับคุณภาพและความละเอียดของภาพระหว่างการแปลงอย่างไร?**

ใช้คุณสมบัติ [jpeg_quality](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/jpeg_quality/) และ [sufficient_resolution](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/sufficient_resolution/) ใน [PdfOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/) เพื่อควบคุมคุณภาพและความละเอียดของภาพใน PDF ที่ได้.

**Aspose.Slides จัดการการแทนที่ฟอนต์โดยอัตโนมัติหรือไม่?**

Aspose.Slides ตรวจจับการแทนที่ฟอนต์ระหว่างการแปลง และคุณสามารถจัดการได้โดยใช้คุณสมบัติ `warning_callback` ใน `SaveOptions` (ขณะนี้มีข้อจำกัด).

## **แหล่งข้อมูลเพิ่มเติม**

- [เอกสาร Aspose.Slides for Python via .NET](/slides/th/python-net/)
- [อ้างอิง API ของ Aspose.Slides](https://reference.aspose.com/slides/python-net/)
- [ตัวแปลงออนไลน์ฟรีของ Aspose](https://products.aspose.app/slides/conversion)