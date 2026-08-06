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
- PDF/A1a
- PDF/A1b
- PDF/UA
- Python
- Aspose.Slides for Python
description: "คู่มือขั้นตอนต่อขั้นตอนสำหรับการแปลง PPT, PPTX, และ ODP เป็น PDF คุณภาพสูงที่สอดคล้องกับ WCAG ใน Python ด้วย Aspose.Slides—รวมการป้องกันด้วยรหัสผ่าน, การเลือกสไลด์, และการควบคุมคุณภาพภาพ."
showReadingTime: true
---
## **ภาพรวม**

การแปลงงานนำเสนอ PowerPoint (PPT, PPTX, ODP) เป็นรูปแบบ PDF ด้วย Python มีข้อได้เปรียบหลายประการ รวมถึงการรับรองความเข้ากันได้ระหว่างอุปกรณ์ต่าง ๆ และการคงรูปแบบการจัดวางและการจัดรูปแบบของงานนำเสนอ ไฟล์คู่มือนี้จะแสดงวิธีแปลงงานนำเสนอเป็นเอกสาร PDF ใช้ตัวเลือกต่าง ๆ เพื่อควบคุมคุณภาพภาพ รวมสไลด์ที่ซ่อนอยู่ ป้องกัน PDF ด้วยรหัสผ่าน ตรวจจับการแทนที่แบบอักษร เลือกสไลด์เฉพาะสำหรับการแปลง และใช้มาตรฐานการปฏิบัติตามสำหรับเอกสารผลลัพธ์

## **การติดตั้ง**

```bash
pip install aspose.slides
```

แพคเกจรวม runtime ที่จำเป็นไว้แล้ว ดังนั้น Microsoft PowerPoint ไม่จำเป็นต้องติดตั้งบนเครื่องที่ทำการแปลง

## **การแปลง PowerPoint เป็น PDF**

ใช้ Aspose.Slides คุณสามารถแปลงงานนำเสนอในรูปแบบเหล่านี้เป็น PDF:

* **PPT**
* **PPTX**
* **ODP**

เพื่อแปลงงานนำเสนอเป็น PDF ใน Python เพียงแค่ส่งชื่อไฟล์เป็นอาร์กิวเมนต์ให้คลาส [Presentation](https://docs.aspose.com/slides/th/python-net/api-reference/aspose.slides/presentation/) แล้วบันทึกงานนำเสนอเป็น PDF โดยใช้เมธอด [Save](https://docs.aspose.com/slides/th/python-net/api-reference/aspose.slides/presentation/#methods) คลาส [Presentation](https://docs.aspose.com/slides/th/python-net/api-reference/aspose.slides/presentation/) เปิดเผยเมธอด [Save](https://docs.aspose.com/slides/th/python-net/api-reference/aspose.slides/presentation/#methods) ที่มักใช้เพื่อแปลงงานนำเสนอเป็น PDF

{{%  alert title="NOTE"  color="warning"   %}} 

Aspose.Slides for Python จะเขียนข้อมูล API และหมายเลขเวอร์ชันลงในเอกสารผลลัพธ์โดยตรง ตัวอย่างเช่น เมื่อแปลงงานนำเสนอเป็น PDF Aspose.Slides for Python จะเติมค่า *Aspose.Slides* ในฟิลด์ Application และเติมค่าในรูปแบบ *Aspose.Slides v XX.XX* ในฟิลด์ PDF Producer **หมายเหตุ** คุณไม่สามารถสั่งให้ Aspose.Slides for Python เปลี่ยนหรือเอาข้อมูลนี้ออกจากเอกสารผลลัพธ์ได้

{{% /alert %}}

Aspose.Slides อนุญาตให้คุณแปลง:

* การแปลงงานนำเสนอทั้งหมดเป็น PDF
* การแปลงสไลด์ที่ระบุในงานนำเสนอเป็น PDF

Aspose.Slides ส่งออกงานนำเสนอเป็น PDF โดยรับประกันว่าขเนื้อหาของ PDF ที่ได้จะตรงกับงานนำเสนอเดิมมากที่สุด สิ่งต่าง ๆ จะถูกแปลงอย่างแม่นยำ รวมถึง:

* รูปภาพ
* กล่องข้อความและรูปร่าง
* การจัดรูปแบบข้อความ
* การจัดรูปแบบย่อหน้า
* ไฮเพอร์ลิงก์
* ส่วนหัวและส่วนท้าย
* รายการหัวข้อย่อย
* ตาราง

## **แปลง PowerPoint เป็น PDF**

การดำเนินการแปลง PowerPoint เป็น PDF มาตรฐานจะใช้ตัวเลือกค่าเริ่มต้น ในกรณีนี้ Aspose.Slides จะพยายามแปลงงานนำเสนอที่ระบุเป็น PDF ด้วยการตั้งค่าที่เหมาะสมที่สุดในระดับคุณภาพสูงสุด โค้ด Python ด้านล่างแสดงวิธีแปลง PowerPoint เป็น PDF:

_Steps: PowerPoint to PDF Conversions in Python_

ตัวอย่างโค้ดต่อไปนี้อธิบายการแปลงเหล่านี้โดยใช้ Python ผ่าน .NET
- <a name="python-net-powerpoint-to-pdf"><strong>ขั้นตอน: แปลง PowerPoint เป็น PDF ด้วย Python ผ่าน .NET</a></strong>
- <a name="python-net-ppt-to-pdf"><strong>ขั้นตอน: แปลง PPT เป็น PDF ด้วย Python ผ่าน .NET</a></strong>
- <a name="python-net-pptx-to-pdf"><strong>ขั้นตอน: แปลง PPTX เป็น PDF ด้วย Python ผ่าน .NET</a></strong>
- <a name="python-net-odp-to-pdf"><strong>ขั้นตอน: แปลง ODP เป็น PDF ด้วย Python ผ่าน .NET</a></strong>
- <a name="python-net-odp-to-pdf"><strong>ขั้นตอน: แปลง PPS เป็น PDF ด้วย Python ผ่าน .NET</a></strong>

_Code Steps:_

- สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/) และระบุไฟล์ PowerPoint ให้กับมัน
  * _.ppt_ ใช้สำหรับโหลดไฟล์ **PPT** ภายในคลาส _Presentation_
  * _.pptx_ ใช้สำหรับโหลดไฟล์ **PPTX** ภายในคลาส _Presentation_
  * _.odp_ ใช้สำหรับโหลดไฟล์ **ODP** ภายในคลาส _Presentation_
  * _.pps_ ใช้สำหรับโหลดไฟล์ **PPS** ภายในคลาส _Presentation_
- บันทึก _Presentation_ ไปเป็นรูปแบบ **PDF** โดยเรียกเมธอด **Save** และใช้ค่าการนับจาก **SaveFormat.PDF**

```python
import aspose.slides as slides

# สร้างอินสแตนซ์ของคลาส Presentation ที่เป็นตัวแทนไฟล์ PowerPoint
presentation = slides.Presentation("PowerPoint.ppt")

# บันทึกงานนำเสนอเป็น PDF
presentation.save("PPT-to-PDF.pdf", slides.export.SaveFormat.PDF)
```

{{%  alert  color="primary"  %}} 

Aspose มีตัวแปลงออนไลน์ฟรี [**ตัวแปลง PowerPoint เป็น PDF**](https://products.aspose.app/slides/th/conversion/ppt-to-pdf) ที่แสดงกระบวนการแปลงงานนำเสนอเป็น PDF สำหรับการใช้งานจริงของขั้นตอนที่อธิบายไว้ที่นี่ คุณสามารถทดสอบได้ด้วยตัวแปลงนี้

{{% /alert %}}

## **แปลง PowerPoint เป็น PDF พร้อมตัวเลือก**

Aspose.Slides ให้ตัวเลือกแบบกำหนดเอง—คุณสมบัติต่าง ๆ ภายใต้คลาส [PdfOptions](https://docs.aspose.com/slides/th/python-net/api-reference/aspose.slides.export/pdfoptions/)—ที่ช่วยให้คุณปรับแต่ง PDF (ผลลัพธ์จากกระบวนการแปลง) ล็อก PDF ด้วยรหัสผ่าน หรือแม้แต่ระบุวิธีการแปลงที่ต้องการ

### **แปลง PowerPoint เป็น PDF ด้วยตัวเลือกแบบกำหนดเอง**

โดยใช้ตัวเลือกการแปลงแบบกำหนดเอง คุณสามารถตั้งค่าคุณภาพที่ต้องการสำหรับภาพระดับราสเตอร์ ระบุวิธีจัดการกับเมตาไฟล์ ตั้งค่าระดับการบีบอัดสำหรับข้อความ ตั้งค่า DPI สำหรับภาพ ฯลฯ

ตัวอย่างโค้ดด้านล่างแสดงการทำงานที่แปลงงานนำเสนอ PowerPoint เป็น PDF พร้อมตัวเลือกแบบกำหนดเองหลายอย่าง:

```python
import aspose.slides as slides

# สร้างอินสแตนซ์ของคลาส PdfOptions
pdf_options = slides.export.PdfOptions()

# กำหนดคุณภาพสำหรับภาพ JPG
pdf_options.jpeg_quality = 90

# กำหนด DPI สำหรับภาพ
pdf_options.sufficient_resolution = 300

# กำหนดพฤติกรรมสำหรับเมตาไฟล์
pdf_options.save_metafiles_as_png = True

# กำหนดระดับการบีบอัดข้อความสำหรับเนื้อหาข้อความ
pdf_options.text_compression = slides.export.PdfTextCompression.FLATE

# กำหนดโหมดการปฏิบัติตาม PDF
pdf_options.compliance = slides.export.PdfCompliance.PDF15

# สร้างอินสแตนซ์ของคลาส Presentation ที่เป็นตัวแทนเอกสาร PowerPoint
with slides.Presentation("PowerPoint.pptx") as presentation:
    # บันทึกงานนำเสนอเป็นเอกสาร PDF
    presentation.save("PowerPoint-to-PDF.pdf", slides.export.SaveFormat.PDF, pdf_options)
```

### **แปลง PowerPoint เป็น PDF พร้อมสไลด์ที่ซ่อนอยู่**

หากงานนำเสนอมีสไลด์ที่ซ่อนอยู่ คุณสามารถใช้ตัวเลือกแบบกำหนดเอง—คุณสมบัติ `show_hidden_slides` จากคลาส [PdfOptions](https://docs.aspose.com/slides/th/python-net/api-reference/aspose.slides.export/pdfoptions/)—เพื่อบบอกให้ Aspose.Slides รวมสไลด์ที่ซ่อนอยู่เป็นหน้าใน PDF ที่ได้

โค้ด Python นี้แสดงวิธีแปลงงานนำเสนอ PowerPoint เป็น PDF ที่รวมสไลด์ที่ซ่อนอยู่:

```python
import aspose.slides as slides

# สร้างอินสแตนซ์ของคลาส Presentation ที่เป็นตัวแทนไฟล์ PowerPoint
presentation = slides.Presentation("PowerPoint.pptx")

# สร้างอินสแตนซ์ของคลาส PdfOptions
pdfOptions = slides.export.PdfOptions()

# เพิ่มสไลด์ที่ซ่อนอยู่
pdfOptions.show_hidden_slides = True

# บันทึกงานนำเสนอเป็น PDF
presentation.save("PowerPoint-to-PDF.pdf", slides.export.SaveFormat.PDF, pdfOptions)
```

### **แปลง PowerPoint เป็น PDF ที่มีการป้องกันด้วยรหัสผ่าน**

โค้ด Python นี้แสดงวิธีแปลง PowerPoint เป็น PDF ที่มีการป้องกันด้วยรหัสผ่าน (โดยใช้พารามิเตอร์การป้องกันจากคลาส [PdfOptions](https://docs.aspose.com/slides/th/python-net/api-reference/aspose.slides.export/pdfoptions/)):

```python
import aspose.slides as slides

# สร้างอินสแตนซ์ของอ็อบเจกต์ Presentation ที่เป็นตัวแทนไฟล์ PowerPoint
presentation = slides.Presentation("PowerPoint.pptx")

# สร้างอินสแตนซ์ของคลาส PdfOptions
pdfOptions = slides.export.PdfOptions()

# ตั้งค่ารหัสผ่านและสิทธิ์การเข้าถึงของ PDF
pdfOptions.password = "password"
pdfOptions.access_permissions = slides.export.PdfAccessPermissions.PRINT_DOCUMENT | slides.export.PdfAccessPermissions.HIGH_QUALITY_PRINT

# บันทึกงานนำเสนอเป็น PDF
presentation.save("PPTX-to-PDF.pdf", slides.export.SaveFormat.PDF, pdfOptions)
```

## **แปลงสไลด์ที่เลือกใน PowerPoint เป็น PDF**

โค้ด Python นี้แสดงวิธีแปลงสไลด์เฉพาะในงานนำเสนอ PowerPoint เป็น PDF:

```python
import aspose.slides as slides

# สร้างอินสแตนซ์ของอ็อบเจกต์ Presentation ที่เป็นตัวแทนไฟล์ PowerPoint
presentation = slides.Presentation("PowerPoint.pptx")

# ตั้งค่าอาร์เรย์ของตำแหน่งสไลด์
slides_array = [ 1, 3 ]

# บันทึกงานนำเสนอเป็น PDF
presentation.save("PPTX-to-PDF.pdf", slides_array, slides.export.SaveFormat.PDF)
```

## **แปลง PowerPoint เป็น PDF ด้วยขนาดสไลด์ที่กำหนดเอง**

โค้ด Python นี้แสดงวิธีแปลง PowerPoint เมื่อกำหนดขนาดสไลด์ให้เป็น PDF:

```python
import aspose.slides as slides

slide_width = 612
slide_height = 792

# สร้างอินสแตนซ์ของคลาส Presentation ที่เป็นตัวแทนไฟล์ PowerPoint หรือ OpenDocument
with slides.Presentation("SelectedSlides.pptx") as presentation:

    # สร้างงานนำเสนอใหม่พร้อมขนาดสไลด์ที่ปรับแล้ว
    with slides.Presentation() as resized_presentation:

        # ตั้งค่าขนาดสไลด์แบบกำหนดเอง
        resized_presentation.slide_size.set_size(slide_width, slide_height, slides.SlideSizeScaleType.ENSURE_FIT)

        # คัดลอกสไลด์แรกจากงานนำเสนอเดิมและลบสไลด์ว่างเปล่าตามค่าเริ่มต้น
        slide = presentation.slides[0]
        resized_presentation.slides.insert_clone(0, slide)
        resized_presentation.slides.remove_at(1)

        # บันทึกงานนำเสนอที่ปรับขนาดเป็น PDF.
        resized_presentation.save("PDF_with_custom_slide_size.pdf", slides.export.SaveFormat.PDF)
```

## **แปลง PowerPoint เป็น PDF ในมุมมองโน๊ตของสไลด์**

โค้ด Python นี้แสดงวิธีแปลง PowerPoint เป็น PDF พร้อมโน๊ตของสไลด์:

```python
import aspose.slides as slides

# สร้างอินสแตนซ์ของคลาส Presentation ที่เป็นตัวแทนไฟล์ PowerPoint
presentation = slides.Presentation("NotesFile.pptx")

# กำหนดค่าตัวเลือก PDF ด้วยรูปแบบโน้ต
pdfOptions = slides.export.PdfOptions()
pdfOptions.slides_layout_options = slides.export.NotesCommentsLayoutingOptions()
pdfOptions.slides_layout_options.notes_position = slides.export.NotesPositions.BOTTOM_FULL

# บันทึกงานนำเสนอเป็น PDF พร้อมโน้ต
presentation.save("Pdf_Notes_out.pdf", slides.export.SaveFormat.PDF, pdfOptions)
```

## **การเข้าถึงและมาตรฐานการปฏิบัติตามสำหรับ PDF**

Aspose.Slides อนุญาตให้คุณใช้กระบวนการแปลงที่สอดคล้องกับ [Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html) คุณสามารถส่งออกเอกสาร PowerPoint เป็น PDF ด้วยมาตรฐานการปฏิบัติตามใดมาตรฐานก็ได้: **PDF/A1a**, **PDF/A1b**, และ **PDF/UA**

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

การสนับสนุนของ Aspose.Slides สำหรับการแปลง PDF ขยายให้คุณสามารถแปลง PDF ไปยังรูปแบบไฟล์ที่ได้รับความนิยมสูงสุดได้ คุณสามารถทำการแปลง [PDF ไปยัง HTML](https://products.aspose.com/slides/th/python-net/conversion/pdf-to-html/), [PDF ไปยัง image](https://products.aspose.com/slides/th/python-net/conversion/pdf-to-image/), [PDF ไปยัง JPG](https://products.aspose.com/slides/th/python-net/conversion/pdf-to-jpg/), และ [PDF ไปยัง PNG](https://products.aspose.com/slides/th/python-net/conversion/pdf-to-png/) รูปแบบอื่น ๆ ที่เชี่ยวชาญ เช่น [PDF ไปยัง SVG](https://products.aspose.com/slides/th/python-net/conversion/pdf-to-svg/), [PDF ไปยัง TIFF](https://products.aspose.com/slides/th/python-net/conversion/pdf-to-tiff/), และ [PDF ไปยัง XML](https://products.aspose.com/slides/th/python-net/conversion/pdf-to-xml/) ก็ได้รับการสนับสนุนเช่นกัน

{{% /alert %}}

> **หมายเหตุ:** เมื่อส่งออกเป็น PDF/UA, Aspose.Slides จะจัดการกราฟิกที่ซับซ้อนเช่น SmartArt, แผนภูมิ, และสูตรเป็นรูปภาพเดียว ไม่ได้รักษาองค์ประกอบเส้นทางแต่ละเส้นแยกออกเป็นเนื้อหาและอาจถูกทำเครื่องหมายว่าเป็นศิลปะ; ข้อความทางเลือกจะให้เฉพาะสำหรับรูปภาพทั้งหมดเท่านั้น

## **คำถามที่พบบ่อย**

### Aspose.Slides for Python สามารถลบข้อมูลแอปพลิเคชันออกจาก PDF ได้หรือไม่?

ไม่ได้, Aspose.Slides for Python จะใส่ข้อมูล API และหมายเลขเวอร์ชันลงใน PDF อัตโนมัติ ข้อมูลนี้ไม่สามารถแก้ไขหรือเอาออกได้

### ฉันจะรวมสไลด์ที่ต้องการเท่านั้นในการแปลงเป็น PDF อย่างไร?

คุณสามารถระบุดัชนีสไลด์ที่ต้องการแปลงโดยส่งอาร์เรย์ของตำแหน่งสไลด์ไปยังเมธอด `save`

### สามารถตั้งค่าการป้องกันด้วยรหัสผ่านให้กับ PDF ระหว่างการแปลงได้หรือไม่?

ได้, คุณสามารถตั้งรหัสผ่านและกำหนดสิทธิ์การเข้าถึงได้โดยใช้คลาส `PdfOptions` ก่อนบันทึกงานนำเสนอเป็น PDF

### Aspose.Slides รองรับการแปลง PDF ไปยังรูปแบบอื่น ๆ หรือไม่?

รองรับ, Aspose.Slides สามารถแปลง PDF ไปยังรูปแบบต่าง ๆ เช่น HTML, รูปภาพ (JPG, PNG), SVG, TIFF, และ XML

### ฉันจะทำให้ PDF ของฉันสอดคล้องกับมาตรฐานการเข้าถึงได้อย่างไร?

ตั้งค่า `compliance` ใน `PdfOptions` เป็นมาตรฐานเช่น `PDF_A1A`, `PDF_A1B` หรือ `PDF_UA` เพื่อให้สอดคล้องกับแนวทางการเข้าถึง

### สามารถรวมสไลด์ที่ซ่อนอยู่ในผลลัพธ์ PDF ได้หรือไม่?

ได้, เพียงตั้งค่าคุณสมบัติ `show_hidden_slides` ใน `PdfOptions` เป็น `True` สไลด์ที่ซ่อนจะถูกรวมอยู่ใน PDF

### จะปรับคุณภาพและความละเอียดของภาพระหว่างการแปลงอย่างไร?

ใช้คุณสมบัติ `jpeg_quality` และ `sufficient_resolution` ใน `PdfOptions` เพื่อควบคุมคุณภาพและความละเอียดของภาพใน PDF ที่ได้

### Aspose.Slides จัดการการแทนที่แบบอักษรโดยอัตโนมัติหรือไม่?

Aspose.Slides ตรวจจับการแทนที่แบบอักษรระหว่างการแปลง และคุณสามารถจัดการได้ผ่านคุณสมบัติ `warning_callback` ใน `SaveOptions` (ขณะนี้มีข้อจำกัด)

## **แหล่งข้อมูลเพิ่มเติม**

- [Aspose.Slides for .NET Documentation](https://docs.aspose.com/slides/th/python-net/)
- [Aspose.Slides API Reference](https://reference.aspose.com/slides/th/python-net/)
- [Aspose Free Online Converters](https://products.aspose.app/slides/th/conversion)