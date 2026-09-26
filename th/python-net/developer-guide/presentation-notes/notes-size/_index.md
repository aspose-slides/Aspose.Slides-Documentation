---
title: เปลี่ยนขนาดและทิศทางของหน้าบันทึกใน Python
linktitle: ขนาดหน้าบันทึก
type: docs
weight: 10
url: /th/python-net/notes-size/
keywords:
- ขนาดหน้าบันทึก
- ทิศทางของบันทึก
- บันทึกแนวนอน
- บันทึกแนวตั้ง
- ขนาดเอกสารสรุป
- PowerPoint
- การนำเสนอ
- PPT
- PPTX
- Python
- Aspose.Slides
description: "อ่านและเปลี่ยนขนาดหน้าบันทึกใน Aspose.Slides สำหรับ Python ผ่าน .NET, สลับทิศทาง, ตรวจสอบขนาดที่บันทึกไว้, และส่งออกบันทึกหรือเอกสารสรุปเป็น PDF และรูปภาพ."
---
## **ภาพรวม**

ใช้ [Presentation.notes_size](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/notes_size/) เพื่อเข้าถึงการตั้งค่าหน้าบันทึกของการพรีเซนเทชัน. เมธอดนี้จะส่งคืนอ็อบเจ็กต์ [NotesSize](https://reference.aspose.com/slides/th/python-net/aspose.slides/notessize/) ที่คุณสมบัติ [size](https://reference.aspose.com/slides/th/python-net/aspose.slides/notessize/size/) สามารถเขียนได้. แม้ว่าตัวอ็อบเจ็กต์การตั้งค่าจะเป็นแบบอ่านอย่างเดียว, คุณสามารถกำหนดมิติใหม่ให้กับคุณสมบัติ size ได้.

ความกว้างและความสูงกำหนดเป็น **points** โดยมี 72 points ต่อหนึ่งนิ้ว. ตัวอย่างเช่น 900 × 600 points เท่ากับ 12.5 × 8⅓ นิ้ว. การตั้งค่าเหล่านี้ใช้กับการพรีเซนเทชันทั้งหมด, ไม่ได้ใช้กับบันทึกของสไลด์แต่ละสไลด์.

| การตั้งค่า | วัตถุประสงค์ |
| --- | --- |
| [Presentation.notes_size](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/notes_size/) | ควบคุมมิตหน้าบันทึกและมิตหน้าที่ใช้สำหรับการส่งออกเอกสารสรุป (handout). |
| [Presentation.slide_size](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/slide_size/) | ควบคุมมิตของสไลด์พรีเซนเทชันปกติผ่าน [SlideSize](https://reference.aspose.com/slides/th/python-net/aspose.slides/slidesize/). |

การเปลี่ยนแปลงการตั้งค่าใด ๆ หนึ่งจะไม่ทำให้การตั้งค่าอื่นเปลี่ยนโดยอัตโนมัติ. การเปลี่ยนแปลงทิศทางของหน้าบันทึกยังไม่หมุนสไลด์ปกติ. ดู [Slide Size](/slides/th/python-net/slide-size/) เพื่อปรับขนาดสไลด์ปกติ.

ตัวอย่างต่อไปนี้ใช้ไฟล์ `sample.pptx` ที่มีอยู่แล้ว. สำหรับตัวอย่างการส่งออก, ใช้พรีเซนเทชันที่มีสไลด์อย่างน้อยหนึ่งสไลด์ที่มีโน้ตผู้พูด. ตัวอย่างแต่ละอันสามารถเรียกใช้แยกกันได้.

## **อ่านขนาดและทิศทางของหน้าบันทึก**

อ่านค่าความกว้างและความสูงแล้วเปรียบเทียบเพื่อกำหนดทิศทาง: หน้าแนวกว้างคือแนวนอน, หน้าที่ยาวกว่าความกว้างคือแนวตั้ง, และมิติเท่ากันคือหน้าเป็นสี่เหลี่ยมจัตุรัส. ตัวอย่างนี้พิมพ์มิติจริงเป็น points โดยไม่อิงขนาดกระดาษมาตรฐาน.

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    size = presentation.notes_size.size
    orientation = "Square"

    if size.width > size.height:
        orientation = "Landscape"
    elif size.width < size.height:
        orientation = "Portrait"

    print(f"Notes page: {size.width:g} x {size.height:g} points")
    print(f"Orientation: {orientation}")
```

## **เปลี่ยนเป็นแนวนอนโดยไม่เปลี่ยนขนาดกระดาษ**

เพื่อเปลี่ยนเฉพาะทิศทาง, ให้สลับค่าความกว้างและความสูงที่มีอยู่. วิธีนี้จะรักษาความยาวของทั้งสองด้าน, รวมถึงขนาดกระดาษที่กำหนดเอง. เงื่อนไขด้านล่างจะป้องกันไม่ให้หน้าที่เป็นแนวนอนอยู่แล้วสลับกลับเป็นแนวตั้ง และจะไม่เปลี่ยนหน้าที่เป็นสี่เหลี่ยมจัตุรัส.

```python
import aspose.pydrawing as drawing
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    size = presentation.notes_size.size

    if size.width < size.height:
        presentation.notes_size.size = drawing.SizeF(size.height, size.width)

    presentation.save("landscape-notes.pptx", slides.export.SaveFormat.PPTX)
```

สำหรับทิศทางแนวตั้ง, ใช้การกำหนดค่าเดียวกันเมื่อ `size.width > size.height`. อย่าแทนค่ามิติ A4 หรือ Letter เว้นแต่คุณต้องการเปลี่ยนขนาดกระดาษด้วย.

## **กำหนดและตรวจสอบขนาดหน้าบันทึกแบบกำหนดเอง**

กำหนดมิติทั้งสองพร้อมกัน, จากนั้นใช้ [Presentation.save](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/save/) เพื่อบันทึกพรีเซนเทชัน. ตัวอย่างนี้ตั้งค่าหน้าแนวนอนขนาด 900 × 600 points, บันทึกเป็น PPTX, แล้วเปิดไฟล์ที่บันทึกใหม่อีกครั้งเพื่อตรวจสอบค่าที่บันทึกไว้. การเปรียบเทียบอนุญาตความคลาดเคลื่อน 0.01 point สำหรับค่าทศนิยม; ไม่ได้เป็นการรับประกันความแม่นยำสำหรับทุกฟอร์แมตไฟล์.

```python
import aspose.pydrawing as drawing
import aspose.slides as slides

expected_size = drawing.SizeF(900, 600)

with slides.Presentation("sample.pptx") as presentation:
    presentation.notes_size.size = expected_size
    presentation.save("custom-notes.pptx", slides.export.SaveFormat.PPTX)

with slides.Presentation("custom-notes.pptx") as reopened:
    actual_size = reopened.notes_size.size
    width_matches = abs(actual_size.width - expected_size.width) < 0.01
    height_matches = abs(actual_size.height - expected_size.height) < 0.01
    preserved = width_matches and height_matches

    print(f"Stored notes page: {actual_size.width:g} x {actual_size.height:g} points")
    print(f"Size preserved: {preserved}")
```

ผลลัพธ์ที่คาดหวังคือ `900 x 600 points` และ `Size preserved: True`. การตรวจสอบพรีเซนเทชันที่เปิดใหม่จะยืนยันไฟล์ที่บันทึก, ไม่ใช่แค่การตั้งค่าในหน่วยความจำ.

## **ส่งออกบันทึกและเอกสารสรุป (Handouts)**

มิติของหน้ากำหนดพื้นที่ที่ใช้ได้สำหรับบันทึกหรือการจัดวางเอกสารสรุป. มิติเหล่านี้ไม่ได้ทำให้การจัดวางเหล่านั้นทำงานโดยอัตโนมัติ: ต้องกำหนดตัวเลือกการส่งออกด้วย. การส่งออกสไลด์ปกติยังคงใช้มิติของสไลด์.

### **ส่งออกบันทึกเป็น PDF และ PNG**

กำหนด [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/th/python-net/aspose.slides.export/notescommentslayoutingoptions/) ให้กับ [PdfOptions.slides_layout_options](https://reference.aspose.com/slides/th/python-net/aspose.slides.export/pdfoptions/slides_layout_options/) เพื่อรวมบันทึกในไฟล์ PDF. ตัวอย่างนี้ยังเรนเดอร์สไลด์แรกที่มีบันทึกเป็น PNG โดยใช้ [Slide.get_image](https://reference.aspose.com/slides/th/python-net/aspose.slides/slide/get_image/) และ [RenderingOptions](https://reference.aspose.com/slides/th/python-net/aspose.slides.export/renderingoptions/).

โหมด [BOTTOM_TRUNCATED](https://reference.aspose.com/slides/th/python-net/aspose.slides.export/notespositions/) จะเก็บบันทึกไว้ในหน้าเดียว; บันทึกที่ไม่พอดีจะถูกตัด. PDF ใช้หน้าขนาด 900 × 600 points. ที่สเกลภาพ 1 × 1 ที่ใช้ด้านล่าง, PNG จะมีขนาด 900 × 600 พิกเซล. Points บรรยายรูปทรงของหน้า; พิกเซลบรรยายผลลัพธ์แบบราสเตอร์ ซึ่งมิติขึ้นอยู่กับสเกลการเรนเดอร์.

```python
import aspose.pydrawing as drawing
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    presentation.notes_size.size = drawing.SizeF(900, 600)

    layout = slides.export.NotesCommentsLayoutingOptions()
    layout.notes_position = slides.export.NotesPositions.BOTTOM_TRUNCATED

    pdf_options = slides.export.PdfOptions()
    pdf_options.slides_layout_options = layout

    presentation.save("notes.pdf", slides.export.SaveFormat.PDF, pdf_options)

    rendering_options = slides.export.RenderingOptions()
    rendering_options.slides_layout_options = layout

    with presentation.slides[0].get_image(rendering_options, 1, 1) as image:
        image.save("first-slide-notes.png", slides.ImageFormat.PNG)
```

สำหรับการส่งออก PDF กับบันทึกยาว, [BOTTOM_FULL](https://reference.aspose.com/slides/th/python-net/aspose.slides.export/notespositions/) จะอนุญาตให้เพิ่มหน้าตามความต้องการ. อย่าใช้โหมดนี้กับการเรียกภาพสไลด์เดียวด้านบน, ซึ่งไม่รองรับ. หลังจากปรับขนาด, ตรวจสอบผลลัพธ์สำหรับบันทึกที่ถูกตัดและตำแหน่งของวัตถุ notes-master ที่มีอยู่; การเปลี่ยนมิติของหน้าเพียงอย่างเดียวไม่ควรถือว่าเป็นการรับประกันว่าข้อมูลทั้งหมดจะพอดี. ดู [Convert PowerPoint to PDF with Notes](/slides/th/python-net/convert-powerpoint-to-pdf-with-notes/) เพื่อเรียนรู้เพิ่มเติมเกี่ยวกับการส่งออกบันทึก.

### **ส่งออกเอกสารสรุปเป็น PDF**

ใช้ [HandoutLayoutingOptions](https://reference.aspose.com/slides/th/python-net/aspose.slides.export/handoutlayoutingoptions/) เพื่อแสดงหลายภาพมินิของสไลด์ในหนึ่งหน้า. ตัวอย่างต่อไปนี้ตั้งค่าหน้า 900 × 600 points และใช้ [HandoutType.HANDOUTS_4_HORIZONTAL](https://reference.aspose.com/slides/th/python-net/aspose.slides.export/handouttype/) เพื่อจัดเรียงสูงสุดสี่สไลด์ต่อหน้า. การกำหนดแนวนอนจะควบคุมการจัดลำดับสไลด์; ทิศทางของหน้ามาจากความกว้างและความสูง.

```python
import aspose.pydrawing as drawing
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    presentation.notes_size.size = drawing.SizeF(900, 600)

    layout = slides.export.HandoutLayoutingOptions()
    layout.handout = slides.export.HandoutType.HANDOUTS_4_HORIZONTAL

    pdf_options = slides.export.PdfOptions()
    pdf_options.slides_layout_options = layout

    presentation.save("handouts.pdf", slides.export.SaveFormat.PDF, pdf_options)
```

การเปลี่ยนขนาดหน้าจะเปลี่ยนพื้นที่ที่ใช้สำหรับกริดเอกสารสรุปโดยไม่เปลี่ยนมิติของสไลด์ต้นฉบับ. สำหรับภาพเอกสารสรุป, ใช้ [Presentation.get_images](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/get_images/) พร้อมเลย์เอาต์เอกสารสรุป, แทนเมธอดภาพของสไลด์เดี่ยว. ใน Aspose.Slides, การเรนเดอร์เอกสารสรุประดับพรีเซนเทชันใช้มิติของหน้าบันทึก, ในขณะที่การเรียกภาพสไลด์เดี่ยวไม่ได้สร้างหน้าสรุป. ดู [Handout Mode](/slides/th/python-net/convert-powerpoint-in-handout-mode/) สำหรับตัวเลือกการจัดวาง.

## **ขนาดหน้าในตัวดู, การส่งออกและการพิมพ์**

แยกแยะขนาดพรีเซนเทชันที่จัดเก็บ, ขนาดหน้าที่ส่งออก, และขนาดกระดาษที่พิมพ์ออกให้ชัดเจน:

- **Presentation viewers:** ตัวดูพรีเซนเทชันสามารถแสดงหรือพิมพ์บันทึกโดยใช้กฎการจัดวางของตนเอง. หากแอปพลิเคชันอื่นบันทึกไฟล์, ให้เปิดใหม่และตรวจสอบมิติอีกครั้ง; การแปลงฟอร์แมตของแอปนั้นอาจทำให้ค่ามาตรฐาน.
- **Export formats:** ตัวอย่าง PDF ของบันทึกและเอกสารสรุปด้านบนใช้มิติหน้าที่กำหนดไว้. ภาพราสเตอร์ใช้มิติพิกเซลจำนวนเต็มและสเกลการเรนเดอร์, ดังนั้นค่าจุดทศนิยมอาจถูกปัดเศษในผลลัพธ์ภาพ. การส่งออกสไลด์ปกติไม่ได้ใช้ขนาดหน้าบันทึก.
- **Printer drivers:** การเลือกกระดาษ, การหมุนอัตโนมัติ, และการตั้งค่าให้พอดีกับหน้า สามารถเปลี่ยนผลลัพธ์ทางกายภาพโดยไม่เปลี่ยนมิติที่จัดเก็บในพรีเซนเทชันหรือ PDF. สำหรับขนาดกระดาษเฉพาะ, ปรับให้ตรงกับการตั้งค่าของเครื่องพิมพ์และตรวจสอบตัวอย่างการพิมพ์.

## **คำถามที่พบบ่อย**

**ฉันสามารถตั้งขนาดหน้าบันทึกสำหรับสไลด์เดียวได้หรือไม่?**

ขนาดหน้าบันทึกเป็นการตั้งค่าระดับพรีเซนเทชัน. สไลด์แต่ละสไลด์อาจมีเนื้อหาบันทึกที่ต่างกัน, แต่คุณสมบัตินี้ไม่ให้ขนาดหน้าที่แยกต่างหากสำหรับแต่ละสไลด์.

**ทำไมการเปลี่ยนทิศทางของหน้าบันทึกจึงไม่ส่งผลต่อสไลด์ของฉัน?**

หน้าบันทึกและสไลด์ปกติมีมิติสองชุดที่แยกจากกัน. ใช้การตั้งค่าขนาดสไลด์ปกติเมื่อคุณต้องการปรับขนาดสไลด์เอง.

**ทำไมผลลัพธ์ที่บันทึกหรือพิมพ์จึงมีขนาดต่างกัน?**

ให้เปิดพรีเซนเทชันที่บันทึกใหม่อีกครั้งและเปรียบเทียบมิติของหน้าบันทึก. หากมีการเปลี่ยนแปลง, ตรวจสอบว่าการบันทึกหรือแปลงไฟล์ในแอปพลิเคชันอื่นทำให้การตั้งค่าหน้าถูกเปลี่ยนหรือไม่. หากไม่เปลี่ยน, ให้ตรวจสอบการจัดวางการส่งออก, สเกลภาพ, การตั้งค่าตัวดู, และการเลือกกระดาษของเครื่องพิมพ์.