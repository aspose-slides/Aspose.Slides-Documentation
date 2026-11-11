---
title: "แปลงการนำเสนอในโหมด Handoutด้วย Python"
linktitle: "โหมด Handout"
type: docs
weight: 150
url: /th/python-net/convert-powerpoint-in-handout-mode/
keywords:
- แปลง PowerPoint
- แปลงการนำเสนอ
- โหมด Handout
- แจกจ่าย
- PowerPoint
- การนำเสนอ
- PPT
- PPTX
- Python
- Aspose.Slides
description: "แปลงการนำเสนอเป็นเอกสารแจกจ่ายด้วย Python ตั้งค่าจำนวนสไลด์ต่อหน้า รักษาโน้ต ส่งออกเป็น PDF หรือภาพด้วย Aspose.Slides พร้อมตัวอย่างโค้ด ลองใช้งานฟรี."
---
## **บทนำ**

Aspose.Slides ให้ความสามารถในการแปลงการนำเสนอเป็นรูปแบบต่าง ๆ รวมถึงการสร้างใบแจกสำหรับการพิมพ์ในโหมด Handout โหมดนี้ทำให้คุณกำหนดวิธีที่สไลด์หลายหน้าแสดงบนหน้าเดียว ทำให้เป็นประโยชน์สำหรับการประชุม สัมมนา และกิจกรรมอื่น ๆ คุณสามารถเปิดใช้โหมดนี้ได้โดยตั้งค่าคุณสมบัติ `slides_layout_options` ในคลาส [PdfOptions](https://reference.aspose.com/slides/th/python-net/aspose.slides.export/pdfoptions/), [RenderingOptions](https://reference.aspose.com/slides/th/python-net/aspose.slides.export/renderingoptions/), [HtmlOptions](https://reference.aspose.com/slides/th/python-net/aspose.slides.export/htmloptions/), และ [TiffOptions](https://reference.aspose.com/slides/th/python-net/aspose.slides.export/tiffoptions/) 

หากต้องการตั้งค่าขนาดและการวางแนวของหน้ากระดาษแจกก่อนการส่งออก ให้ดูที่ [Notes Page Size](/slides/th/python-net/notes-size/).

## **การส่งออกในโหมด Handout**

เพื่อกำหนดค่าโหมด Handout ให้ใช้วัตถุ [HandoutLayoutingOptions](https://reference.aspose.com/slides/th/python-net/aspose.slides.export/handoutlayoutingoptions/) ซึ่งกำหนดจำนวนสไลด์ที่วางบนหน้าเดียวและพารามิเตอร์การแสดงผลอื่น ๆ

ด้านล่างเป็นตัวอย่างโค้ดที่แสดงวิธีแปลงการนำเสนอเป็น PDF ในโหมด Handout.

```py
import aspose.slides as slides

# โหลดการนำเสนอ.
with slides.Presentation("sample.pptx") as presentation:

    # ตั้งค่าตัวเลือกการส่งออก.
    slides_layout_options = slides.export.HandoutLayoutingOptions()
    slides_layout_options.handout = slides.export.HandoutType.HANDOUTS_4_HORIZONTAL  # 4 สไลด์ต่อหน้าแบบแนวนอน
    slides_layout_options.print_slide_numbers = True                                 # พิมพ์หมายเลขสไลด์
    slides_layout_options.print_frame_slide = True                                   # พิมพ์กรอบรอบสไลด์
    slides_layout_options.print_comments = False                                     # ไม่มีคอมเมนต์

    pdf_options = slides.export.PdfOptions()
    pdf_options.slides_layout_options = slides_layout_options

    # ส่งออกการนำเสนอเป็น PDF ด้วยการจัดเรียงที่เลือก.
    presentation.save("output.pdf", slides.export.SaveFormat.PDF, pdf_options)
```

{{% alert color="warning" title="Warning" %}}
โปรดจำไว้ว่า property `slides_layout_options` มีให้ใช้เฉพาะสำหรับรูปแบบเอาต์พุตบางประเภท เช่น PDF, HTML, TIFF และเมื่อเรนเดอร์เป็นภาพ.
{{% /alert %}} 

## **คำถามที่พบบ่อย**

**จำนวนภาพย่อยของสไลด์สูงสุดต่อหน้าหนึ่งในโหมด Handout คือเท่าไหร่?**

Aspose.Slides รองรับ [presets](https://reference.aspose.com/slides/th/python-net/aspose.slides.export/handouttype/) สูงสุด 9 ภาพย่อยต่อหน้าโดยจัดเรียงในแนวนอนหรือแนวตั้ง: 1, 2, 3, 4 (แนวนอน/แนวตั้ง), 6 (แนวนอน/แนวตั้ง) และ 9 (แนวนอน/แนวตั้ง).

**ฉันสามารถกำหนดกริดแบบกำหนดเองได้หรือไม่ เช่น 5 หรือ 8 สไลด์ต่อหน้า?**

ไม่ได้. จำนวนและการจัดเรียงของภาพย่อยถูกควบคุมโดย enumeration [HandoutType](https://reference.aspose.com/slides/th/python-net/aspose.slides.export/handouttype/); การจัดวางแบบ任意ไม่ได้รับการสนับสนุน.

**ฉันสามารถรวมสไลด์ที่ซ่อนอยู่ในผลลัพธ์ Handout ได้หรือไม่?**

ได้. เปิดใช้ตัวเลือก `show_hidden_slides` ในการตั้งค่าการส่งออกสำหรับรูปแบบเป้าหมาย เช่น [PdfOptions](https://reference.aspose.com/slides/th/python-net/aspose.slides.export/pdfoptions/), [HtmlOptions](https://reference.aspose.com/slides/th/python-net/aspose.slides.export/htmloptions/), หรือ [TiffOptions](https://reference.aspose.com/slides/th/python-net/aspose.slides.export/tiffoptions/).