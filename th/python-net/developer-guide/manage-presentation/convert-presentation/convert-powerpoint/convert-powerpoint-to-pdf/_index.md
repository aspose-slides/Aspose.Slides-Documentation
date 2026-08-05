---
title: แปลง PPT & PPTX เป็น PDF ใน Python | ตัวเลือกขั้นสูง
linktitle: PowerPointเป็น PDF
type: docs
weight: 40
url: /th/python-net/convert-powerpoint-to-pdf/
aliases:
  - /python-net/convert-to-pdf/
keywords:
- แปลง PowerPoint
- การนำเสนอ
- PowerPointเป็น PDF
- PPTเป็น PDF
- PPTXเป็น PDF
- บันทึก PowerPointเป็น PDF
- PDF/A1a
- PDF/A1b
- PDF/UA
- Python
- Aspose.Slides for Python
description: "คู่มือทีละขั้นตอนสำหรับการแปลง PPT, PPTX, และ ODP เป็น PDF คุณภาพสูงที่สอดคล้องกับ WCAG ใน Python ด้วย Aspose.Slides — รวมการป้องกันด้วยรหัสผ่าน, การเลือกสไลด์, และการควบคุมคุณภาพภาพ"
showReadingTime: true
---
## **ภาพรวม**

การแปลงงานนำเสนอ PowerPoint (PPT, PPTX, ODP) เป็น PDF ใน Python มีข้อได้เปรียบหลายประการ รวมถึงการรับรองความเข้ากันได้กับอุปกรณ์ต่างๆ และการรักษาเค้าโครงและรูปแบบของงานนำเสนอ คำแนะนำนี้แสดงวิธีแปลงงานนำเสนอเป็นเอกสาร PDF ใช้ตัวเลือกต่างๆ เพื่อควบคุมคุณภาพของภาพ รวมถึงสไลด์ที่ซ่อนไว้ ป้องกัน PDF ด้วยรหัสผ่าน ตรวจจับการแทนที่ฟอนต์ เลือกสไลด์เฉพาะสำหรับการแปลง และปรับใช้มาตรฐานการปฏิบัติตามในเอกสารผลลัพธ์

## **การแปลง PowerPoint เป็น PDF**

ด้วย Aspose.Slides คุณสามารถแปลงงานนำเสนอในรูปแบบต่อไปนี้เป็น PDF:

* **PPT**
* **PPTX**
* **ODP**

เพื่อแปลงงานนำเสนอเป็น PDF ใน Python เพียงแค่ส่งชื่อไฟล์เป็นอาร์กิวเมนต์ให้คลาส [การนำเสนอ](https://docs.aspose.com/slides/th/python-net/api-reference/aspose.slides/presentation/) แล้วบันทึกงานนำเสนอเป็น PDF ด้วยเมธอด [บันทึก](https://docs.aspose.com/slides/th/python-net/api-reference/aspose.slides/presentation/#methods) คลาส [การนำเสนอ](https://docs.aspose.com/slides/th/python-net/api-reference/aspose.slides/presentation/) แสดงเมธอด [บันทึก](https://docs.aspose.com/slides/th/python-net/api-reference/aspose.slides/presentation/#methods) ที่โดยทั่วไปใช้เพื่อแปลงงานนำเสนอเป็น PDF

{{%  alert title="NOTE"  color="warning"   %}} 

Aspose.Slides for Python จะเพิ่มข้อมูล API และหมายเลขเวอร์ชันในเอกสารผลลัพธ์โดยตรง ตัวอย่างเช่น เมื่อทำการแปลงงานนำเสนอเป็น PDF Aspose.Slides for Python จะใส่ค่า '*Aspose.Slides*' ในฟิลด์ Application และใส่ค่าในฟอร์ม '*Aspose.Slides v XX.XX*' ในฟิลด์ PDF Producer **หมายเหตุ** ว่าคุณไม่สามารถบังคับให้ Aspose.Slides for Python เปลี่ยนหรือเอาข้อมูลนี้ออกจากเอกสารผลลัพธ์ได้

{{% /alert %}}

Aspose.Slides อนุญาตให้คุณแปลง:

* งานนำเสนอทั้งหมดเป็น PDF
* สไลด์เฉพาะในงานนำเสนอเป็น PDF

Aspose.Slides ส่งออกงานนำเสนอเป็น PDF โดยทำให้เนื้อหาใน PDF ที่ได้ตรงกับงานนำเสนอเดิมอย่างใกล้ชิด ส่วนประกอบและแอตทริบิวต์จะถูกแสดงผลอย่างถูกต้องในการแปลง รวมถึง:

* ภาพ
* กล่องข้อความและรูปร่าง
* การจัดรูปแบบข้อความ
* การจัดรูปแบบย่อหน้า
* ไฮเปอร์ลิงก์
* ส่วนหัวและส่วนท้าย
* จุดหัวข้อ
* ตาราง

## **แปลง PowerPoint เป็น PDF**

การดำเนินการแปลง PowerPoint เป็น PDF มาตรฐานทำโดยใช้ตัวเลือกค่าเริ่มต้น ในกรณีนี้ Aspose.Slides จะพยายามแปลงงานนำเสนอที่ระบุเป็น PDF ด้วยการตั้งค่าที่เหมาะที่สุดและคุณภาพสูงสุด โค้ด Python ด้านล่างแสดงวิธีแปลง PowerPoint เป็น PDF:

_ขั้นตอน: การแปลง PowerPoint เป็น PDF ใน Python_

ตัวอย่างโค้ดต่อไปนี้อธิบายการแปลงเหล่านี้ด้วย Python ผ่าน .NET
- <a name="python-net-powerpoint-to-pdf"><strong>ขั้นตอน: แปลง PowerPoint เป็น PDF ด้วย Python ผ่าน .NET</strong></a>
- <a name="python-net-ppt-to-pdf"><strong>ขั้นตอน: แปลง PPT เป็น PDF ด้วย Python ผ่าน .NET</strong></a>
- <a name="python-net-pptx-to-pdf"><strong>ขั้นตอน: แปลง PPTX เป็น PDF ด้วย Python ผ่าน .NET</strong></a>
- <a name="python-net-odp-to-pdf"><strong>ขั้นตอน: แปลง ODP เป็น PDF ด้วย Python ผ่าน .NET</strong></a>
- <a name="python-net-odp-to-pdf"><strong>ขั้นตอน: แปลง PPS เป็น PDF ด้วย Python ผ่าน .NET</strong></a>

_ขั้นตอนโค้ด:_

- สร้างอินสแตนซ์ของคลาส [การนำเสนอ](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/) และระบุไฟล์ PowerPoint ให้กับมัน
  * ส่วนขยาย _.ppt_ เพื่อโหลดไฟล์ **PPT** เข้าในคลาส _Presentation_
  * ส่วนขยาย _.pptx_ เพื่อโหลดไฟล์ **PPTX** เข้าในคลาส _Presentation_
  * ส่วนขยาย _.odp_ เพื่อโหลดไฟล์ **ODP** เข้าในคลาส _Presentation_
  * ส่วนขยาย _.pps_ เพื่อโหลดไฟล์ **PPS** เข้าในคลาส _Presentation_
- บันทึก _Presentation_ เป็นรูปแบบ **PDF** โดยเรียกเมธอด **บันทึก** และใช้ค่าคงที่ **SaveFormat.PDF**

```python
import aspose.slides as slides

# สร้างอินสแตนซ์ของคลาส Presentation ที่แทนไฟล์ PowerPoint
presentation = slides.Presentation("PowerPoint.ppt")

# บันทึกงานนำเสนอเป็น PDF
presentation.save("PPT-to-PDF.pdf", slides.export.SaveFormat.PDF)
```

{{%  alert  color="primary"  %}} 

Aspose มีตัวแปลงออนไลน์ฟรี [**PowerPoint to PDF converter**](https://products.aspose.app/slides/th/conversion/ppt-to-pdf) ที่แสดงกระบวนการแปลงงานนำเสนอเป็น PDF สำหรับการทดสอบการทำงานจริงของขั้นตอนที่อธิบายไว้ที่นี่ คุณสามารถทดลองใช้ตัวแปลงได้

{{% /alert %}}

## **แปลง PowerPoint เป็น PDF พร้อมตัวเลือก**

Aspose.Slides มีตัวเลือกแบบกำหนดเอง—คุณสมบัติภายใต้คลาส [PdfOptions](https://docs.aspose.com/slides/th/python-net/api-reference/aspose.slides.export/pdfoptions/)—ที่ให้คุณปรับแต่ง PDF (ผลลัพธ์จากกระบวนการแปลง) ล็อค PDF ด้วยรหัสผ่าน หรือแม้กระทั่งระบุวิธีการทำงานของกระบวนการแปลง

### **แปลง PowerPoint เป็น PDF พร้อมตัวเลือกแบบกำหนดเอง**

โดยใช้ตัวเลือกการแปลงแบบกำหนดเอง คุณสามารถตั้งค่าคุณภาพที่ต้องการสำหรับภาพเรสเตอร์ ระบุวิธีจัดการเมตาไฟล์ ตั้งค่าระดับการบีบอัดสำหรับข้อความ ตั้งค่า DPI สำหรับภาพ ฯลฯ

ตัวอย่างโค้ดด้านล่างแสดงการดำเนินการที่แปลงงานนำเสนอ PowerPoint เป็น PDF พร้อมตัวเลือกหลายอย่าง:

```python
import aspose.slides as slides

# สร้างอินสแตนซ์ของคลาส PdfOptions
pdf_options = slides.export.PdfOptions()

# ตั้งค่าคุณภาพสำหรับภาพ JPG
pdf_options.jpeg_quality = 90

# ตั้งค่า DPI สำหรับภาพ
pdf_options.sufficient_resolution = 300

# ตั้งค่าพฤติกรรมของเมต้าไฟล์
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

### **แปลง PowerPoint เป็น PDF พร้อมสไลด์ที่ซ่อน**

หากงานนำเสนอมีสไลด์ที่ซ่อนอยู่ คุณสามารถใช้ตัวเลือกแบบกำหนดเอง—คุณสมบัติ `show_hidden_slides` จากคลาส [PdfOptions](https://docs.aspose.com/slides/th/python-net/api-reference/aspose.slides.export/pdfoptions/)—เพื่อสั่งให้ Aspose.Slides รวมสไลด์ที่ซ่อนเป็นหน้าใน PDF ผลลัพธ์

โค้ด Python ด้านล่างแสดงวิธีแปลงงานนำเสนอ PowerPoint เป็น PDF พร้อมรวมสไลด์ที่ซ่อน:

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

โค้ด Python ด้านล่างแสดงวิธีแปลง PowerPoint เป็น PDF ที่มีการป้องกันด้วยรหัสผ่าน (โดยใช้พารามิเตอร์การป้องกันจากคลาส [PdfOptions](https://docs.aspose.com/slides/th/python-net/api-reference/aspose.slides.export/pdfoptions/)):

```python
import aspose.slides as slides

# สร้างอินสแตนซ์ของอ็อบเจ็กต์ Presentation ที่แทนไฟล์ PowerPoint
presentation = slides.Presentation("PowerPoint.pptx")

# สร้างอินสแตนซ์ของคลาส PdfOptions
pdfOptions = slides.export.PdfOptions()

# ตั้งค่ารหัสผ่าน PDF และสิทธิ์การเข้าถึง
pdfOptions.password = "password"
pdfOptions.access_permissions = slides.export.PdfAccessPermissions.PRINT_DOCUMENT | slides.export.PdfAccessPermissions.HIGH_QUALITY_PRINT

# บันทึกงานนำเสนอเป็น PDF
presentation.save("PPTX-to-PDF.pdf", slides.export.SaveFormat.PDF, pdfOptions)
```

## **แปลงสไลด์ที่เลือกใน PowerPoint เป็น PDF**

โค้ด Python ด้านล่างแสดงวิธีแปลงสไลด์เฉพาะในงานนำเสนอ PowerPoint เป็น PDF:

```python
import aspose.slides as slides

# สร้างอินสแตนซ์ของอ็อบเจ็กต์ Presentation ที่แทนไฟล์ PowerPoint
presentation = slides.Presentation("PowerPoint.pptx")

# ตั้งค่าอาเรย์ของตำแหน่งสไลด์
slides_array = [ 1, 3 ]

# บันทึกงานนำเสนอเป็น PDF
presentation.save("PPTX-to-PDF.pdf", slides_array, slides.export.SaveFormat.PDF)
```

## **แปลง PowerPoint เป็น PDF ด้วยขนาดสไลด์ที่กำหนดเอง**

โค้ด Python ด้านล่างแสดงวิธีแปลง PowerPoint ที่มีการระบุขนาดสไลด์เป็น PDF:

```python
import aspose.slides as slides

slide_width = 612
slide_height = 792

# สร้างอินสแตนซ์ของคลาส Presentation ที่แทนไฟล์ PowerPoint หรือ OpenDocument
with slides.Presentation("SelectedSlides.pptx") as presentation:

    # สร้างงานนำเสนอใหม่โดยปรับขนาดสไลด์
    with slides.Presentation() as resized_presentation:

        # ตั้งค่าขนาดสไลด์แบบกำหนดเอง.
        resized_presentation.slide_size.set_size(slide_width, slide_height, slides.SlideSizeScaleType.ENSURE_FIT)

        # คัดลอกสไลด์แรกจากงานนำเสนอเดิม.
        slide = presentation.slides[0]
        resized_presentation.slides.insert_clone(0, slide)

        # บันทึกงานนำเสนอที่ปรับขนาดเป็น PDF พร้อมบันทึกย่อ.
        resized_presentation.save("PDF_with_notes.pdf", slides.export.SaveFormat.PDF)
```

## **แปลง PowerPoint เป็น PDF ในมุมมองสไลด์บันทึกย่อ**

โค้ด Python ด้านล่างแสดงวิธีแปลง PowerPoint เป็น PDF พร้อมบันทึกย่อ:

```python
import aspose.slides as slides

# สร้างอินสแตนซ์ของคลาส Presentation ที่แทนไฟล์ PowerPoint
presentation = slides.Presentation("NotesFile.pptx")

pdfOptions = slides.export.PdfOptions()
pdfOptions.notes_comments_layouting.notes_position = slides.export.NotesPositions.BOTTOM_FULL

# บันทึกงานนำเสนอเป็น PDF พร้อมบันทึกย่อ
presentation.Save("Pdf_Notes_out.tiff", slides.export.SaveFormat.PDF, pdfOptions)
```

## **มาตรฐานการเข้าถึงและการปฏิบัติตามสำหรับ PDF**

Aspose.Slides ให้คุณใช้กระบวนการแปลงที่สอดคล้องกับ [Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html) คุณสามารถส่งออกเอกสาร PowerPoint ไปยัง PDF ด้วยมาตรฐานการปฏิบัติตามใดก็ได้: **PDF/A1a**, **PDF/A1b**, และ **PDF/UA**

โค้ด Python ด้านล่างแสดงการดำเนินการแปลง PowerPoint เป็น PDF ที่ได้รับ PDF หลายไฟล์ตามมาตรฐานการปฏิบัติตามที่ต่างกัน:

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

การสนับสนุนการแปลง PDF ของ Aspose.Slides ขยายไปถึงการให้คุณแปลง PDF ไปยังรูปแบบไฟล์ยอดนิยมอื่น ๆ คุณสามารถทำการแปลง [PDF to HTML](https://products.aspose.com/slides/th/python-net/conversion/pdf-to-html/), [PDF to image](https://products.aspose.com/slides/th/python-net/conversion/pdf-to-image/), [PDF to JPG](https://products.aspose.com/slides/th/python-net/conversion/pdf-to-jpg/), และ [PDF to PNG](https://products.aspose.com/slides/th/python-net/conversion/pdf-to-png/) อีกทั้งยังรองรับการแปลง PDF ไปยังรูปแบบเฉพาะอื่น ๆ เช่น [PDF to SVG](https://products.aspose.com/slides/th/python-net/conversion/pdf-to-svg/), [PDF to TIFF](https://products.aspose.com/slides/th/python-net/conversion/pdf-to-tiff/), และ [PDF to XML](https://products.aspose.com/slides/th/python-net/conversion/pdf-to-xml/)

{{% /alert %}}

> **หมายเหตุ:** เมื่อส่งออกเป็น PDF/UA, Aspose.Slides จะจัดการกราฟิกที่ซับซ้อนเช่น SmartArt, แผนภูมิ, และสูตรเป็นรูปเดียว องค์ประกอบเส้นทางแยกจะไม่ถูกเก็บเป็นเนื้อหาแยกและอาจถูกระบุเป็นสิ่งประดิษฐ์; ข้อความแทนที่จะมีเฉพาะสำหรับรูปทั้งหมดเท่านั้น

## **คำถามที่พบบ่อย**

**Aspose.Slides for Python สามารถลบข้อมูลแอปพลิเคชันออกจาก PDF ได้หรือไม่?**

ไม่ได้ Aspose.Slides for Python จะใส่ข้อมูล API และหมายเลขเวอร์ชันใน PDF ผลลัพธ์โดยอัตโนมัติ ข้อมูลนี้ไม่สามารถแก้ไขหรือเอาออกได้

**ฉันจะรวมเฉพาะสไลด์บางสไลด์ในกระบวนการแปลง PDF ได้อย่างไร?**

คุณสามารถระบุดัชนีของสไลด์ที่ต้องการแปลงโดยส่งอาร์เรย์ตำแหน่งสไลด์ไปยังเมธอด `save`

**สามารถกำหนดรหัสผ่านให้กับ PDF ระหว่างการแปลงได้หรือไม่?**

ได้ คุณสามารถตั้งรหัสผ่านและกำหนดสิทธิ์การเข้าถึงโดยใช้คลาส `PdfOptions` ก่อนบันทึกงานนำเสนอเป็น PDF

**Aspose.Slides รองรับการแปลง PDF ไปยังรูปแบบอื่น ๆ หรือไม่?**

ได้ Aspose.Slides รองรับการแปลง PDF ไปยังรูปแบบเช่น HTML, รูปภาพ (JPG, PNG), SVG, TIFF และ XML

**ฉันจะทำให้ PDF ของฉันสอดคล้องกับมาตรฐานการเข้าถึงได้อย่างไร?**

ตั้งค่าคุณสมบัติ `compliance` ใน `PdfOptions` ให้เป็นมาตรฐานเช่น `PDF_A1A`, `PDF_A1B` หรือ `PDF_UA` เพื่อให้สอดคล้องกับแนวทางการเข้าถึง

**ฉันสามารถรวมสไลด์ที่ซ่อนในผลลัพธ์ PDF ได้หรือไม่?**

ได้ โดยการตั้งค่าคุณสมบัติ `show_hidden_slides` ใน `PdfOptions` เป็น `True` สไลด์ที่ซ่อนจะถูกรวมใน PDF

**ฉันจะปรับคุณภาพและความละเอียดของภาพระหว่างการแปลงอย่างไร?**

ใช้คุณสมบัติ `jpeg_quality` และ `sufficient_resolution` ใน `PdfOptions` เพื่อควบคุมคุณภาพและความละเอียดของภาพใน PDF ที่ได้

**Aspose.Slides จัดการการแทนที่ฟอนต์อัตโนมัติหรือไม่?**

Aspose.Slides ตรวจจับการแทนที่ฟอนต์ระหว่างการแปลงและคุณสามารถจัดการได้ผ่านคุณสมบัติ `warning_callback` ใน `SaveOptions` (ขณะนี้มีข้อจำกัด)

## **แหล่งข้อมูลเพิ่มเติม**

- [เอกสาร Aspose.Slides for .NET](https://docs.aspose.com/slides/th/python-net/)
- [อ้างอิง API ของ Aspose.Slides](https://reference.aspose.com/slides/th/python-net/)
- [ตัวแปลงออนไลน์ฟรีของ Aspose](https://products.aspose.app/slides/th/conversion)