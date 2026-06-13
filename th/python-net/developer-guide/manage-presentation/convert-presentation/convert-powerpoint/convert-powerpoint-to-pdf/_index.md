---
title: แปลง PPT & PPTX เป็น PDF ใน Python | ตัวเลือกขั้นสูง
linktitle: PowerPoint เป็น PDF
type: docs
weight: 40
url: /th/python-net/convert-powerpoint-to-pdf/
keywords:
- แปลง PowerPoint
- งานนำเสนอ
- PowerPoint เป็น PDF
- PPT เป็น PDF
- PPTX เป็น PDF
- บันทึก PowerPoint เป็น PDF
- PDF/A1a
- PDF/A1b
- PDF/UA
- Python
- Aspose.Slides for Python
description: "คู่มือขั้นตอนต่อขั้นตอนในการแปลง PPT, PPTX และ ODP เป็น PDF คุณภาพสูงที่สอดคล้องกับ WCAG ใน Python ด้วย Aspose.Slides—รวมถึงการป้องกันด้วยรหัสผ่าน การเลือกสไลด์ และการควบคุมคุณภาพภาพ."
showReadingTime: true
---
## **ภาพรวม**

การแปลงงานนำเสนอ PowerPoint (PPT, PPTX, ODP) เป็นรูปแบบ PDF ใน Python มีประโยชน์หลายประการ รวมถึงการรับรองความเข้ากันได้กับอุปกรณ์ต่างๆ และการรักษาเค้าโครงและการฟอร์แมตของงานนำเสนอ คำแนะนำนี้จะแสดงวิธีแปลงงานนำเสนอเป็นเอกสาร PDF ใช้ตัวเลือกต่างๆ เพื่อควบคุมคุณภาพของภาพ รวมถึงการรวมสไลด์ที่ซ่อนไว้ ป้องกัน PDF ด้วยรหัสผ่าน ตรวจจับการแทนที่ฟอนต์ เลือกสไลด์เฉพาะสำหรับการแปลง และใช้มาตรฐานการปฏิบัติตามสำหรับเอกสารผลลัพธ์

## **การแปลง PowerPoint เป็น PDF**

โดยใช้ Aspose.Slides คุณสามารถแปลงงานนำเสนอในรูปแบบเหล่านี้เป็น PDF:

* **PPT**
* **PPTX**
* **ODP**

เพื่อแปลงงานนำเสนอเป็น PDF ใน Python คุณเพียงแค่ส่งชื่อไฟล์เป็นอาร์กิวเมนต์ในคลาส[Presentation](https://docs.aspose.com/slides/th/python-net/api-reference/aspose.slides/presentation/)แล้วบันทึกงานนำเสนอเป็น PDF โดยใช้เมธอด[Save](https://docs.aspose.com/slides/th/python-net/api-reference/aspose.slides/presentation/#methods) คลาส[Presentation](https://docs.aspose.com/slides/th/python-net/api-reference/aspose.slides/presentation/)เปิดเผยเมธอด[Save](https://docs.aspose.com/slides/th/python-net/api-reference/aspose.slides/presentation/#methods)ซึ่งโดยทั่วไปใช้เพื่อแปลงงานนำเสนอเป็น PDF

{{%  alert title="NOTE"  color="warning"   %}} 

Aspose.Slides for Python จะเขียนข้อมูล API และหมายเลขเวอร์ชันลงในเอกสารผลลัพธ์โดยตรง ตัวอย่างเช่น เมื่อแปลงงานนำเสนอเป็น PDF Aspose.Slides for Python จะเติมค่าในฟิลด์ Application ด้วยค่า '*Aspose.Slides*' และฟิลด์ PDF Producer ด้วยค่าในรูปแบบ '*Aspose.Slides v XX.XX*' **Note** ว่าคุณไม่สามารถสั่งให้ Aspose.Slides for Python เปลี่ยนหรือเอาข้อมูลนี้ออกจากเอกสารผลลัพธ์ได้

{{% /alert %}}

Aspose.Slides อนุญาตให้คุณแปลง:

* งานนำเสนอทั้งหมดเป็น PDF
* สไลด์เฉพาะในงานนำเสนอเป็น PDF

Aspose.Slides ส่งออกงานนำเสนอเป็น PDF โดยทำให้เนื้อหาใน PDF ที่ได้ตรงกับงานนำเสนอเดิมอย่างใกล้เคียง องค์ประกอบและแอตทริบิวต์จะถูกเรนเดอร์อย่างแม่นยำในกระบวนการแปลง รวมถึง:

* รูปภาพ
* กล่องข้อความและรูปร่าง
* การฟอร์แมตข้อความ
* การฟอร์แมตย่อหน้า
* ไฮเปอร์ลิงก์
* ส่วนหัวและส่วนท้าย
* จุดสัญลักษณ์
* ตาราง

## **แปลง PowerPoint เป็น PDF**

การดำเนินการแปลง PowerPoint เป็น PDF มาตรฐานจะทำโดยใช้ตัวเลือกค่าเริ่มต้น ในกรณีนี้ Aspose.Slides จะพยายามแปลงงานนำเสนอที่ให้เป็น PDF ด้วยการตั้งค่าที่เหมาะสมที่สุดในระดับคุณภาพสูงสุด โค้ด Python นี้แสดงวิธีแปลง PowerPoint เป็น PDF:

_Steps: PowerPoint to PDF Conversions in Python_

โค้ดตัวอย่างต่อไปนี้อธิบายการแปลงเหล่านี้โดยใช้ Python ผ่าน .NET
- <a name="python-net-powerpoint-to-pdf"><strong>ขั้นตอน: แปลง PowerPoint เป็น PDF ด้วย Python ผ่าน .NET</a></strong>
- <a name="python-net-ppt-to-pdf"><strong>ขั้นตอน: แปลง PPT เป็น PDF ด้วย Python ผ่าน .NET</a></strong>
- <a name="python-net-pptx-to-pdf"><strong>ขั้นตอน: แปลง PPTX เป็น PDF ด้วย Python ผ่าน .NET</a></strong>
- <a name="python-net-odp-to-pdf"><strong>ขั้นตอน: แปลง ODP เป็น PDF ด้วย Python ผ่าน .NET</a></strong>
- <a name="python-net-odp-to-pdf"><strong>ขั้นตอน: แปลง PPS เป็น PDF ด้วย Python ผ่าน .NET</a></strong>

**ขั้นตอนโค้ด:**

- สร้างอินสแตนซ์ของคลาส[Presentation](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/)และให้ไฟล์ PowerPoint เป็นอินพุต
  * ส่วนขยาย _.ppt_ เพื่อโหลดไฟล์ **PPT** ลงในคลาส _Presentation_
  * ส่วนขยาย _.pptx_ เพื่อโหลดไฟล์ **PPTX** ลงในคลาส _Presentation_
  * ส่วนขยาย _.odp_ เพื่อโหลดไฟล์ **ODP** ลงในคลาส _Presentation_
  * ส่วนขยาย _.pps_ เพื่อโหลดไฟล์ **PPS** ลงในคลาส _Presentation_
- บันทึก _Presentation_ เป็นรูปแบบ **PDF** โดยเรียกเมธอด **Save** และใช้ค่าเอนุมเมอร์ชัน **SaveFormat.PDF**

```python
import aspose.slides as slides

# สร้างอินสแตนซ์ของคลาส Presentation ที่แทนไฟล์ PowerPoint
presentation = slides.Presentation("PowerPoint.ppt")

# บันทึกงานนำเสนอเป็น PDF
presentation.save("PPT-to-PDF.pdf", slides.export.SaveFormat.PDF)
```

{{%  alert  color="primary"  %}} 

Aspose มีตัวแปลงออนไลน์ฟรี [**PowerPoint to PDF converter**](https://products.aspose.app/slides/th/conversion/ppt-to-pdf) ที่แสดงกระบวนการแปลงงานนำเสนอเป็น PDF สำหรับการทำงานจริงตามขั้นตอนที่อธิบายไว้ที่นี่ คุณสามารถทดสอบได้ด้วยตัวแปลง

{{% /alert %}}

## **แปลง PowerPoint เป็น PDF ด้วยตัวเลือก**

Aspose.Slides มีตัวเลือกกำหนดเอง—คุณสมบัติภายใต้คลาส[PdfOptions](https://docs.aspose.com/slides/th/python-net/api-reference/aspose.slides.export/pdfoptions/)—ที่อนุญาตให้คุณปรับแต่ง PDF (ผลลัพธ์จากกระบวนการแปลง) ล็อก PDF ด้วยรหัสผ่าน หรือแม้กระทั่งระบุวิธีการทำงานของกระบวนการแปลง

### **แปลง PowerPoint เป็น PDF ด้วยตัวเลือกกำหนดเอง**

โดยใช้ตัวเลือกการแปลงกำหนดเอง คุณสามารถตั้งค่าคุณภาพที่ต้องการสำหรับภาพเรสเตอร์ ระบุวิธีการจัดการเมตาไฟล์ ตั้งค่าระดับการบีบอัดสำหรับข้อความ กำหนด DPI สำหรับภาพ ฯลฯ

โค้ดตัวอย่างด้านล่างแสดงการดำเนินการที่แปลงงานนำเสนอ PowerPoint เป็น PDF พร้อมตัวเลือกกำหนดเองหลายอย่าง:

```python
import aspose.slides as slides

# สร้างอินสแตนซ์ของคลาส PdfOptions
pdf_options = slides.export.PdfOptions()

# ตั้งค่าคุณภาพสำหรับภาพ JPG
pdf_options.jpeg_quality = 90

# ตั้งค่า DPI สำหรับภาพ
pdf_options.sufficient_resolution = 300

# ตั้งค่าการทำงานของเมต้าไฟล์
pdf_options.save_metafiles_as_png = True

# ตั้งค่าระดับการบีบอัดข้อความสำหรับเนื้อหาข้อความ
pdf_options.text_compression = slides.export.PdfTextCompression.FLATE

# กำหนดโหมดการปฏิบัติตาม PDF
pdf_options.compliance = slides.export.PdfCompliance.PDF15

# สร้างอินสแตนซ์ของคลาส Presentation ที่แทนเอกสาร PowerPoint
with slides.Presentation("PowerPoint.pptx") as presentation:
    # บันทึกงานนำเสนอเป็นเอกสาร PDF
    presentation.save("PowerPoint-to-PDF.pdf", slides.export.SaveFormat.PDF, pdf_options)
```

### **แปลง PowerPoint เป็น PDF พร้อมสไลด์ที่ซ่อนอยู่**

หากงานนำเสนอมีสไลด์ที่ซ่อนอยู่ คุณสามารถใช้ตัวเลือกกำหนดเอง—คุณสมบัติ `show_hidden_slides` จากคลาส[PdfOptions](https://docs.aspose.com/slides/th/python-net/api-reference/aspose.slides.export/pdfoptions/)—เพื่อสั่งให้ Aspose.Slides รวมสไลด์ที่ซ่อนอยู่เป็นหน้าต่าง PDF ผลลัพธ์

โค้ด Python นี้แสดงวิธีแปลงงานนำเสนอ PowerPoint เป็น PDF พร้อมสไลด์ที่ซ่อนอยู่รวมอยู่ด้วย:

```python
import aspose.slides as slides

# สร้างอินสแตนซ์ของคลาส Presentation ที่แทนไฟล์ PowerPoint
presentation = slides.Presentation("PowerPoint.pptx")

# สร้างอินสแตนซ์ของคลาส PdfOptions
pdfOptions = slides.export.PdfOptions()

# เพิ่มสไลด์ที่ซ่อนอยู่
pdfOptions.show_hidden_slides = True

# บันทึกงานนำเสนอเป็น PDF
presentation.save("PowerPoint-to-PDF.pdf", slides.export.SaveFormat.PDF, pdfOptions)
```

### **แปลง PowerPoint เป็น PDF ที่มีการป้องกันด้วยรหัสผ่าน**

โค้ด Python นี้แสดงวิธีแปลง PowerPoint เป็น PDF ที่มีการป้องกันด้วยรหัสผ่าน (โดยใช้พารามิเตอร์การปกป้องจากคลาส[PdfOptions](https://docs.aspose.com/slides/th/python-net/api-reference/aspose.slides.export/pdfoptions/)):

```python
import aspose.slides as slides

# สร้างอินสแตนซ์ของวัตถุ Presentation ที่แทนไฟล์ PowerPoint
presentation = slides.Presentation("PowerPoint.pptx")

# สร้างอินสแตนซ์ของคลาส PdfOptions
pdfOptions = slides.export.PdfOptions()

# ตั้งรหัสผ่านและสิทธิ์การเข้าถึงสำหรับ PDF
pdfOptions.password = "password"
pdfOptions.access_permissions = slides.export.PdfAccessPermissions.PRINT_DOCUMENT | slides.export.PdfAccessPermissions.HIGH_QUALITY_PRINT

# บันทึกงานนำเสนอเป็น PDF
presentation.save("PPTX-to-PDF.pdf", slides.export.SaveFormat.PDF, pdfOptions)
```

## **แปลงสไลด์ที่เลือกใน PowerPoint เป็น PDF**

โค้ด Python นี้แสดงวิธีแปลงสไลด์เฉพาะในงานนำเสนอ PowerPoint เป็น PDF:

```python
import aspose.slides as slides

# สร้างอินสแตนซ์ของวัตถุ Presentation ที่แทนไฟล์ PowerPoint
presentation = slides.Presentation("PowerPoint.pptx")

# ตั้งค่าอาร์เรย์ของตำแหน่งสไลด์
slides_array = [ 1, 3 ]

# บันทึกงานนำเสนอเป็น PDF
presentation.save("PPTX-to-PDF.pdf", slides_array, slides.export.SaveFormat.PDF)
```

## **แปลง PowerPoint เป็น PDF ด้วยขนาดสไลด์กำหนดเอง**

โค้ด Python นี้แสดงวิธีแปลง PowerPoint เมื่อกำหนดขนาดสไลด์เป็น PDF:

```python
import aspose.slides as slides

slide_width = 612
slide_height = 792

# สร้างอินสแตนซ์ของคลาส Presentation ที่แทนไฟล์ PowerPoint หรือ OpenDocument
with slides.Presentation("SelectedSlides.pptx") as presentation:

    # สร้างงานนำเสนอใหม่พร้อมขนาดสไลด์ที่ปรับแล้ว
    with slides.Presentation() as resized_presentation:

        # ตั้งค่าขนาดสไลด์ที่กำหนดเอง
        resized_presentation.slide_size.set_size(slide_width, slide_height, slides.SlideSizeScaleType.ENSURE_FIT)

        # คัดลอกสไลด์แรกจากงานนำเสนอเดิม
        slide = presentation.slides[0]
        resized_presentation.slides.insert_clone(0, slide)

        # บันทึกงานนำเสนอที่ปรับขนาดเป็น PDF พร้อมโนต
        resized_presentation.save("PDF_with_notes.pdf", slides.export.SaveFormat.PDF)
```

## **แปลง PowerPoint เป็น PDF ในมุมมองสไลด์บันทึกโน트**

โค้ด Python นี้แสดงวิธีแปลง PowerPoint เป็น PDF บันทึกโนต:

```python
import aspose.slides as slides

# สร้างอินสแตนซ์ของคลาส Presentation ที่แทนไฟล์ PowerPoint
presentation = slides.Presentation("NotesFile.pptx")

pdfOptions = slides.export.PdfOptions()
pdfOptions.notes_comments_layouting.notes_position = slides.export.NotesPositions.BOTTOM_FULL

# บันทึกงานนำเสนอเป็น PDF พร้อมโนต
presentation.Save("Pdf_Notes_out.tiff", slides.export.SaveFormat.PDF, pdfOptions)
```

## **มาตรฐานการเข้าถึงและการปฏิบัติตามสำหรับ PDF**

Aspose.Slides อนุญาตให้คุณใช้กระบวนการแปลงที่สอดคล้องกับ[แนวทางการเข้าถึงเนื้อหาเว็บ (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html) คุณสามารถส่งออกเอกสาร PowerPoint เป็น PDF ด้วยมาตรฐานการปฏิบัติตามใดก็ได้ต่อไปนี้: **PDF/A1a**, **PDF/A1b**, และ **PDF/UA**.

โค้ด Python นี้สาธิตการแปลง PowerPoint เป็น PDF ที่ได้ PDF หลายไฟล์ตามมาตรฐานการปฏิบัติตามที่แตกต่างกัน:

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

{{% alert title="Note" color="warning" %}} 

การสนับสนุนของ Aspose.Slides สำหรับการแปลง PDF ครอบคลุมการแปลง PDF ไปยังรูปแบบไฟล์ที่นิยมที่สุด คุณสามารถทำการแปลง[PDF to HTML](https://products.aspose.com/slides/th/python-net/conversion/pdf-to-html/), [PDF to image](https://products.aspose.com/slides/th/python-net/conversion/pdf-to-image/), [PDF to JPG](https://products.aspose.com/slides/th/python-net/conversion/pdf-to-jpg/), และ [PDF to PNG](https://products.aspose.com/slides/th/python-net/conversion/pdf-to-png/) อีกทั้งยังสนับสนุนการแปลง PDF ไปยังรูปแบบพิเศษเช่น[PDF to SVG](https://products.aspose.com/slides/th/python-net/conversion/pdf-to-svg/), [PDF to TIFF](https://products.aspose.com/slides/th/python-net/conversion/pdf-to-tiff/), และ[PDF to XML](https://products.aspose.com/slides/th/python-net/conversion/pdf-to-xml/)

{{% /alert %}}

> **หมายเหตุ:** เมื่อนำออกเป็น PDF/UA, Aspose.Slides จะจัดการกราฟิกที่ซับซ้อนเช่น SmartArt, แผนภูมิ และสูตรเป็นรูปภาพเดียว ๆ รายการพาธส่วนบุคคลจะไม่ถูกเก็บเป็นเนื้อหาแยกและอาจถูกทำเครื่องหมายว่าเป็นศูนย์เสีย; ข้อความแทนจะมีเฉพาะสำหรับรูปภาพทั้งหมดเท่านั้น

## **คำถามที่พบบ่อย**

**Aspose.Slides for Python สามารถลบข้อมูลแอปพลิเคชันออกจาก PDF ได้หรือไม่?**

ไม่ได้, Aspose.Slides for Python จะรวมข้อมูล API และหมายเลขเวอร์ชันลงใน PDF โดยอัตโนมัติ ไม่สามารถแก้ไขหรือเอาข้อมูลนี้ออกได้

**ฉันจะรวมสไลด์เฉพาะในกระบวนการแปลง PDF ได้อย่างไร?**

คุณสามารถระบุดัชนีสไลด์ที่ต้องการแปลงโดยส่งอาเรย์ของตำแหน่งสไลด์ไปยังเมธอด `save`

**สามารถตั้งรหัสผ่านให้กับ PDF ได้ในระหว่างการแปลงหรือไม่?**

ได้, คุณสามารถตั้งรหัสผ่านและกำหนดสิทธิ์การเข้าถึงโดยใช้คลาส `PdfOptions` ก่อนบันทึกงานนำเสนอเป็น PDF

**Aspose.Slides รองรับการแปลง PDF ไปยังรูปแบบอื่นหรือไม่?**

ได้, Aspose.Slides รองรับการแปลง PDF ไปยังรูปแบบต่าง ๆ เช่น HTML, รูปภาพ (JPG, PNG), SVG, TIFF, และ XML

**ฉันจะทำให้ PDF ของฉันสอดคล้องกับมาตรฐานการเข้าถึงได้อย่างไร?**

ตั้งค่าคุณสมบัติ `compliance` ใน `PdfOptions` เป็นมาตรฐานเช่น `PDF_A1A`, `PDF_A1B` หรือ `PDF_UA` เพื่อให้สอดคล้องกับแนวทางการเข้าถึง

**สามารถรวมสไลด์ที่ซ่อนอยู่ในผลลัพธ์ PDF ได้หรือไม่?**

ได้, โดยตั้งคุณสมบัติ `show_hidden_slides` ใน `PdfOptions` เป็น `True` สไลด์ที่ซ่อนจะถูกรวมใน PDF

**ฉันจะปรับคุณภาพและความละเอียดของภาพระหว่างการแปลงอย่างไร?**

ใช้คุณสมบัติ `jpeg_quality` และ `sufficient_resolution` ใน `PdfOptions` เพื่อควบคุมคุณภาพและความละเอียดของภาพใน PDF ที่ได้

**Aspose.Slides จัดการการแทนที่ฟอนต์โดยอัตโนมัติหรือไม่?**

Aspose.Slides ตรวจจับการแทนที่ฟอนต์ระหว่างการแปลง และคุณสามารถจัดการได้ด้วยคุณสมบัติ `warning_callback` ใน `SaveOptions` (ในขณะนี้มีข้อจำกัด)

## **แหล่งข้อมูลเพิ่มเติม**

- [Aspose.Slides for .NET Documentation](https://docs.aspose.com/slides/th/python-net/)
- [Aspose.Slides API Reference](https://reference.aspose.com/slides/th/python-net/)
- [Aspose Free Online Converters](https://products.aspose.app/slides/th/conversion)