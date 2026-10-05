---
title: แปลง PPT & PPTX เป็น PDF ด้วย Python | ตัวเลือกขั้นสูง
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
description: "คู่มือขั้นตอนการแปลง PPT, PPTX และ ODP เป็น PDF คุณภาพสูง ที่สอดคล้องกับ WCAG ด้วย Python และ Aspose.Slides — รวมการป้องกันด้วยรหัสผ่าน การเลือกสไลด์ และการควบคุมคุณภาพของภาพ."
showReadingTime: true
---
## **ภาพรวม**

การแปลงงานนำเสนอ PowerPoint (PPT, PPTX, ODP) ไปเป็นรูปแบบ PDF ใน Python มีข้อได้เปรียบหลายประการ รวมถึงการรับประกันความเข้ากันได้กับอุปกรณ์ต่าง ๆ และการรักษาเค้าโครงและรูปแบบของงานนำเสนอของคุณ คู่มือนี้จะแสดงวิธีแปลงงานนำเสนอเป็นเอกสาร PDF ใช้ตัวเลือกต่าง ๆ เพื่อควบคุมคุณภาพของภาพ รวมถึงการรวมสไลด์ที่ซ่อนอยู่ ป้องกันไฟล์ PDF ด้วยรหัสผ่าน ตรวจจับการแทนที่แบบอักษร เลือกสไลด์เฉพาะสำหรับการแปลง และใช้มาตรฐานการปฏิบัติตามสำหรับเอกสารผลลัพธ์

## **การแปลง PowerPoint เป็น PDF**

โดยใช้ Aspose.Slides คุณสามารถแปลงงานนำเสนอในรูปแบบต่อไปนี้เป็น PDF:

* **PPT**
* **PPTX**
* **ODP**

เพื่อแปลงงานนำเสนอเป็น PDF ใน Python คุณเพียงแค่ส่งชื่อไฟล์เป็นอาร์กิวเมนต์ไปยังคลาส [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) แล้วบันทึกงานนำเสนอเป็น PDF โดยใช้เมธอด [save](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/save/) คลาส [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) เปิดเผยเมธอด [save](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/save/) ซึ่งโดยทั่วไปใช้ในการแปลงงานนำเสนอเป็น PDF

{{% alert color="info" title="Note" %}}
Aspose.Slides for Python จะใส่ข้อมูล API และหมายเลขเวอร์ชันลงในเอกสารผลลัพธ์ ตัวอย่างเช่น เมื่อแปลงงานนำเสนอเป็น PDF Aspose.Slides for Python จะเติมฟิลด์ Application ด้วยค่า '*Aspose.Slides*' และฟิลด์ PDF Producer ด้วยค่ารูปแบบ '*Aspose.Slides v XX.XX*' **หมายเหตุ** ว่าคุณไม่สามารถสั่งให้ Aspose.Slides for Python เปลี่ยนหรือเอาข้อมูลนี้ออกจากเอกสารผลลัพธ์ได้.
{{% /alert %}}

Aspose.Slides ให้คุณแปลง:

* งานนำเสนอทั้งหมดเป็น PDF
* สไลด์เฉพาะในงานนำเสนอเป็น PDF

Aspose.Slides ส่งออกงานนำเสนอเป็น PDF โดยรับประกันว่าข้อมูลใน PDF ที่ได้จะตรงกับงานนำเสนอเดิมอย่างใกล้ชิด องค์ประกอบและแอตทริบิวต์จะถูกเรนเดอร์อย่างแม่นยำในการแปลง รวมถึง:

* รูปภาพ
* กล่องข้อความและรูปร่าง
* การจัดรูปแบบข้อความ
* การจัดรูปแบบย่อหน้า
* ไฮเปอร์ลิงก์
* หัวกระดาษและท้ายกระดาษ
* สัญลักษณ์หัวข้อ
* ตาราง

## **แปลง PowerPoint เป็น PDF**

กระบวนการแปลง PowerPoint ไปเป็น PDF มาตรฐานใช้ตัวเลือกเริ่มต้น ในกรณีนี้ Aspose.Slides จะพยายามแปลงงานนำเสนอที่ระบุเป็น PDF ด้วยการตั้งค่าที่เหมาะสมที่สุดและระดับคุณภาพสูงสุด

ตัวอย่างต่อไปนี้โหลดงานนำเสนอและบันทึกสไลด์ที่มองเห็นทั้งหมดเป็น PDF ด้วยการตั้งค่าเริ่มต้นของการส่งออก

```python
import aspose.slides as slides

with slides.Presentation("PowerPoint.ppt") as presentation:
    presentation.save("PPT-to-PDF.pdf", slides.export.SaveFormat.PDF)
```

{{% alert color="info" title="Note" %}}
Aspose มีตัวแปลงออนไลน์ฟรี [**ตัวแปลง PowerPoint เป็น PDF**](https://products.aspose.app/slides/conversion/ppt-to-pdf) ที่แสดงกระบวนการแปลงงานนำเสนอเป็น PDF สำหรับการใช้งานจริงของขั้นตอนที่อธิบายไว้ที่นี่ คุณสามารถทำการทดสอบด้วยตัวแปลงได้.
{{% /alert %}}

## **แปลง PowerPoint เป็น PDF พร้อมตัวเลือก**

Aspose.Slides มีตัวเลือกที่กำหนดเอง — คุณสมบัติภายใต้คลาส [PdfOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/) — ที่ให้คุณปรับแต่ง PDF (ผลลัพธ์จากกระบวนการแปลง) ล็อก PDF ด้วยรหัสผ่าน หรือแม้กระทั่งกำหนดวิธีการแปลง

### **แปลง PowerPoint เป็น PDF ด้วยตัวเลือกแบบกำหนดเอง**

โดยใช้ตัวเลือกการแปลงแบบกำหนดเอง คุณสามารถตั้งค่าคุณภาพที่ต้องการสำหรับภาพแรสเตอร์ ระบุวิธีการจัดการ metafile ตั้งค่าระดับการบีบอัดสำหรับข้อความ ตั้งค่า DPI สำหรับภาพ ฯลฯ

ตัวอย่างต่อไปนี้ส่งออกงานนำเสนอเป็น PDF 1.5 โดยตั้งค่าคุณภาพ JPEG ที่ 90 ความละเอียดภาพที่ 300 DPI บันทึก metafiles เป็น PNG และบีบอัดข้อความแบบ Flate

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

### **รักษาไฟล์ OLE ฝังไว้เป็นไฟล์แนบ PDF**

หากงานนำเสนอมีเวิร์กบุ๊ก Excel ฝังอยู่ คุณอาจต้องการให้ผู้รับ PDF เข้าถึงข้อมูลของเวิร์กบุ๊กพร้อมกับดูสไลด์ ตั้งค่า [PdfOptions.include_ole_data](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/include_ole_data/) เป็น `True` เพื่อรักษาไฟล์ OLE ที่ฝังไว้เป็นไฟล์แนบใน PDF ที่ได้

ค่าตั้งต้นคือ `False`: ภาพตัวอย่างหรือไอคอนของวัตถุ OLE จะถูกเรนเดอร์บนหน้า PDF แต่ไฟล์ที่ฝังอยู่จะไม่รวมเป็นไฟล์แนบ การตั้งค่าเป็น `True` จะรวมข้อมูลไฟล์ด้วย ตัวอย่างยังคงเป็นการแสดงภาพเท่านั้น; ไฟล์แนบทำให้ผู้รับสามารถเปิดหรือบันทึกไฟล์ที่ฝังไว้แยกจากกัน วัตถุ OLE จะไม่กลายเป็นแผ่นงาน Excel ที่โต้ตอบได้บนหน้า PDF

ตัวอย่างต่อไปนี้โหลดงานนำเสนอที่มีเวิร์กบุ๊ก Excel ฝังอยู่แล้วและส่งออกเป็น PDF พร้อมแนบเวิร์กบุ๊ก

```python
import aspose.slides as slides

pdf_options = slides.export.PdfOptions()
pdf_options.include_ole_data = True

with slides.Presentation("presentation.pptx") as presentation:
    presentation.save("presentation.pdf", slides.export.SaveFormat.PDF, pdf_options)
```

เพื่อเช็กผลลัพธ์:

1. เปิด PDF ที่ส่งออกในตัวดูที่รองรับไฟล์แนบ เช่น Adobe Acrobat Reader.
2. เปิดแผง **Attachments** ของตัวดูและหาวิร์กบุ๊กที่ฝังอยู่.
3. บันทึกไฟล์แนบและเปิดใน Excel เพื่อตรวจสอบข้อมูล หรือเปิดโดยตรงหากตัวดูอนุญาต การแสดงตัวอย่างบนหน้า PDF แยกจากไฟล์แนบ.

{{% alert color="info" title="Note" %}}
มาตรฐาน PDF/A มีข้อจำกัดเกี่ยวกับไฟล์แนบ: PDF/A-1 ห้ามไฟล์ฝัง, PDF/A-2 อนุญาตเฉพาะไฟล์แนบ PDF/A, และ PDF/A-3 อนุญาตไฟล์ประเภทอื่นรวมถึงเวิร์กบุ๊ก Excel สิ่งเหล่านี้เป็นข้อกำหนดของมาตรฐาน ไม่ได้เป็นข้อจำกัดเฉพาะของ Aspose.Slides ตัวอย่างนี้ใช้การตั้งค่าการปฏิบัติตาม PDF เริ่มต้นและไม่ได้สาธิตการส่งออกเป็น PDF/A.
{{% /alert %}}

### **แปลง PowerPoint เป็น PDF พร้อมสไลด์ที่ซ่อนอยู่**

หากงานนำเสนอมีสไลด์ที่ซ่อนอยู่ คุณสามารถใช้ตัวเลือกแบบกำหนดเอง — คุณสมบัติ [show_hidden_slides](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/show_hidden_slides/) ของคลาส [PdfOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/) — เพื่อสั่งให้ Aspose.Slides รวมสไลด์ที่ซ่อนเป็นหน้าต่าง PDF ที่ได้

ตัวอย่างต่อไปนี้ส่งออกงานนำเสนอเป็น PDF โดยรวมสไลด์ที่ซ่อนไว้ทั้งหมด

```python
import aspose.slides as slides

pdf_options = slides.export.PdfOptions()
pdf_options.show_hidden_slides = True

with slides.Presentation("PowerPoint.pptx") as presentation:
    presentation.save("PowerPoint-to-PDF.pdf", slides.export.SaveFormat.PDF, pdf_options)
```

### **แปลง PowerPoint เป็น PDF ที่มีการป้องกันด้วยรหัสผ่าน**

ตัวอย่างต่อไปนี้ส่งออกงานนำเสนอเป็น PDF ที่ต้องใช้รหัสผ่าน `password` เพื่อเปิด การอนุญาตการเข้าถึงอนุญาตการพิมพ์ รวมถึงการพิมพ์คุณภาพสูง

```python
import aspose.slides as slides

pdf_options = slides.export.PdfOptions()
pdf_options.password = "password"
pdf_options.access_permissions = slides.export.PdfAccessPermissions.PRINT_DOCUMENT | slides.export.PdfAccessPermissions.HIGH_QUALITY_PRINT

with slides.Presentation("PowerPoint.pptx") as presentation:
    presentation.save("PPTX-to-PDF.pdf", slides.export.SaveFormat.PDF, pdf_options)
```

## **แปลงสไลด์ที่เลือกใน PowerPoint เป็น PDF**

ตัวอย่างต่อไปนี้ส่งออกสไลด์ที่ 1 และ 3 จากงานนำเสนอเป็น PDF หมายเลขสไลด์ในอาเรย์นี้เริ่มจาก 1 และงานนำเข้าต้องมีสไลด์อย่างน้อยสามสไลด์

```python
import aspose.slides as slides

with slides.Presentation("PowerPoint.pptx") as presentation:
    slide_numbers = [1, 3]
    presentation.save("PPTX-to-PDF.pdf", slide_numbers, slides.export.SaveFormat.PDF)
```

## **แปลง PowerPoint เป็น PDF ด้วยขนาดสไลด์กำหนดเอง**

ตัวอย่างต่อไปนี้คัดลอกสไลด์แรกจากงานนำเข้าไปยังงานนำเสนอใหม่โดยมีขนาดสไลด์ 612 × 792 พิกเซล (8.5 × 11 นิ้ว) ปรับสเกลเนื้อหาสไลด์ให้พอดีและส่งออกสไลด์เดียวเป็น PDF

```python
import aspose.slides as slides

slide_width = 612
slide_height = 792

with slides.Presentation("SelectedSlides.pptx") as presentation:
    with slides.Presentation() as resized_presentation:
        resized_presentation.slide_size.set_size(slide_width, slide_height, slides.SlideSizeScaleType.ENSURE_FIT)
        slide = presentation.slides[0]
        resized_presentation.slides.insert_clone(0, slide)

        # ลบสไลด์เปล่าที่สร้างขึ้นพร้อมการนำเสนอใหม่
        resized_presentation.slides.remove_at(1)

        resized_presentation.save("PDF_with_custom_slide_size.pdf", slides.export.SaveFormat.PDF)
```

## **แปลง PowerPoint เป็น PDF ในมุมมองโน้ตสไลด์**

ตัวอย่างต่อไปนี้ส่งออกงานนำเสนอเป็น PDF โดยวางโน้ตผู้พูดของแต่ละสไลด์ไว้ด้านล่างสไลด์ ใช้งานนำเสนอที่มีโน้ตผู้พูดเพื่อดูผลลัพธ์

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
การสนับสนุนการแปลง PDF ของ Aspose.Slides ทำให้คุณสามารถแปลง PDF ไปเป็นรูปแบบไฟล์ที่นิยมได้ คุณสามารถทำการแปลง [PDF เป็น HTML](https://products.aspose.com/slides/python-net/conversion/pdf-to-html/), [PDF เป็นภาพ](https://products.aspose.com/slides/python-net/conversion/pdf-to-image/), [PDF เป็น JPG](https://products.aspose.com/slides/python-net/conversion/pdf-to-jpg/), และ [PDF เป็น PNG](https://products.aspose.com/slides/python-net/conversion/pdf-to-png/) การแปลงอื่น ๆ ไปยังรูปแบบเฉพาะ — [PDF เป็น SVG](https://products.aspose.com/slides/python-net/conversion/pdf-to-svg/), [PDF เป็น TIFF](https://products.aspose.com/slides/python-net/conversion/pdf-to-tiff/), และ [PDF เป็น XML](https://products.aspose.com/slides/python-net/conversion/pdf-to-xml/) — ก็ได้รับการสนับสนุนเช่นกัน.
{{% /alert %}}

> **หมายเหตุ:** เมื่อส่งออกเป็น PDF/UA, Aspose.Slides จะถือกราฟิกซับซ้อนเช่น SmartArt, แผนภูมิ และสูตรเป็นรูปภาพเดียว ส่วนองค์ประกอบเส้นทางย่อยจะไม่ถูกเก็บเป็นเนื้อหาแยกและอาจถูกระบุเป็นวัสดุเกิน; ข้อความแทนที่จะมีให้เฉพาะรูปภาพทั้งหมดเท่านั้น.

## **คำถามที่พบบ่อย**

**Aspose.Slides for Python สามารถลบข้อมูลแอปพลิเคชันจาก PDF ได้หรือไม่?**

ไม่, Aspose.Slides for Python จะรวมข้อมูล API และหมายเลขเวอร์ชันไว้ใน PDF ที่สร้างโดยอัตโนมัติ ข้อมูลนี้ไม่สามารถแก้ไขหรือเอาออกได้.

**ฉันจะรวมสไลด์เฉพาะในกระบวนการแปลงเป็น PDF ได้อย่างไร?**

คุณสามารถระบุตำแหน่งสไลด์ที่ต้องการแปลงได้โดยส่งอาเรย์ของตำแหน่งสไลด์ไปยังเมธอด [save](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/save/)

**สามารถป้องกัน PDF ด้วยรหัสผ่านระหว่างการแปลงได้หรือไม่?**

ได้, คุณสามารถตั้งรหัสผ่านและกำหนดสิทธิ์การเข้าถึงโดยใช้คลาส [PdfOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/) ก่อนบันทึกงานนำเสนอเป็น PDF.

**Aspose.Slides รองรับการแปลง PDF ไปเป็นรูปแบบอื่นหรือไม่?**

ได้, Aspose.Slides รองรับการแปลง PDF ไปเป็นรูปแบบต่าง ๆ เช่น HTML, รูปภาพ (JPG, PNG), SVG, TIFF, และ XML.

**ฉันจะทำให้ PDF ของฉันสอดคล้องกับมาตรฐานการเข้าถึงได้อย่างไร?**

ตั้งค่าคุณสมบัติ [compliance](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/compliance/) ในคลาส [PdfOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/) เป็นมาตรฐานเช่น `PDF_A1A`, `PDF_A1B` หรือ `PDF_UA` เพื่อให้สอดคล้องกับแนวทางการเข้าถึง.

**ฉันสามารถรวมสไลด์ที่ซ่อนอยู่ใน PDF ที่ส่งออกได้หรือไม่?**

ได้, โดยตั้งค่าคุณสมบัติ [show_hidden_slides](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/show_hidden_slides/) ในคลาส [PdfOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/) เป็น `True` สไลด์ที่ซ่อนอยู่จะถูกรวมใน PDF.

**ฉันจะปรับคุณภาพและความละเอียดของภาพระหว่างการแปลงอย่างไร?**

ใช้คุณสมบัติ [jpeg_quality](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/jpeg_quality/) และ [sufficient_resolution](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/sufficient_resolution/) ในคลาส [PdfOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/) เพื่อควบคุมคุณภาพและความละเอียดของภาพใน PDF ที่ได้.

**Aspose.Slides จัดการการแทนที่แบบอักษรโดยอัตโนมัติหรือไม่?**

Aspose.Slides ตรวจจับการแทนที่แบบอักษรระหว่างการแปลง และคุณสามารถจัดการได้โดยใช้คุณสมบัติ `warning_callback` ใน `SaveOptions` (ขณะนี้มีข้อจำกัด).

## **แหล่งข้อมูลเพิ่มเติม**

- [เอกสาร Aspose.Slides for Python ผ่าน .NET](/slides/th/python-net/)
- [อ้างอิง API Aspose.Slides](https://reference.aspose.com/slides/python-net/)
- [ตัวแปลงออนไลน์ฟรีของ Aspose](https://products.aspose.app/slides/conversion)