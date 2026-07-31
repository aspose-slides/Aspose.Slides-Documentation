---
title: แปลงงานนำเสนอในโหมด Handout ด้วย Python
linktitle: โหมด Handout
type: docs
weight: 150
url: /th/python-net/convert-powerpoint-in-handout-mode/
keywords:
- แปลง PowerPoint
- แปลงงานนำเสนอ
- โหมด Handout
- เอกสารแจก
- PowerPoint
- งานนำเสนอ
- PPT
- PPTX
- Python
- Aspose.Slides
description: "แปลงงานนำเสนอเป็นเอกสารแจกใน Python. ตั้งค่าสไลด์ต่อหน้า, เก็บบันทึก, ส่งออกเป็น PDF หรือภาพด้วย Aspose.Slides, พร้อมตัวอย่างโค้ด. ทดลองใช้ฟรี."
---
## **บทนำ**

Aspose.Slides ให้ความสามารถในการแปลงงานนำเสนอเป็นรูปแบบต่าง ๆ รวมถึงการสร้างสไลด์แจกพิมพ์ในโหมด Handout โหมดนี้ทำให้คุณกำหนดวิธีการแสดงหลายสไลด์บนหน้ากระดาษเดียวได้ ซึ่งมีประโยชน์สำหรับการประชุม สัมมนา และกิจกรรมอื่น ๆ คุณสามารถเปิดใช้โหมดนี้ได้โดยตั้งค่า `slides_layout_options` ในคลาส [PdfOptions](https://reference.aspose.com/slides/th/python-net/aspose.slides.export/pdfoptions/), [RenderingOptions](https://reference.aspose.com/slides/th/python-net/aspose.slides.export/renderingoptions/), [HtmlOptions](https://reference.aspose.com/slides/th/python-net/aspose.slides.export/htmloptions/), และ [TiffOptions](https://reference.aspose.com/slides/th/python-net/aspose.slides.export/tiffoptions/)

## **การส่งออกโหมด Handout**

เพื่อกำหนดค่าโหมด Handout ให้ใช้วัตถุ [HandoutLayoutingOptions](https://reference.aspose.com/slides/th/python-net/aspose.slides.export/handoutlayoutingoptions/) ซึ่งกำหนดจำนวนสไลด์ที่วางบนหน้ากระดาษเดียวและพารามิเตอร์การแสดงผลอื่น ๆ

ด้านล่างเป็นตัวอย่างโค้ดที่แสดงวิธีแปลงงานนำเสนอเป็น PDF ในโหมด Handout

```py
# โหลดงานนำเสนอ.
with slides.Presentation("sample.pptx") as presentation:

    # ตั้งค่าตัวเลือกการส่งออก.
    slides_layout_options = slides.export.HandoutLayoutingOptions()
    slides_layout_options.handout = slides.export.HandoutType.HANDOUTS_4_HORIZONTAL  # 4 สไลด์บนหนึ่งหน้าในแนวนอน
    slides_layout_options.print_slide_numbers = True                                 # พิมพ์เลขหน้าสไลด์
    slides_layout_options.print_frame_slide = True                                   # พิมพ์กรอบรอบสไลด์
    slides_layout_options.print_comments = False                                     # ไม่มีความคิดเห็น

    pdf_options = slides.export.PdfOptions()
    pdf_options.slides_layout_options = slides_layout_options

    # ส่งออกงานนำเสนอเป็น PDF ด้วยรูปแบบที่เลือก.
    presentation.save("output.pdf", slides.export.SaveFormat.PDF, pdf_options)
```

{{% alert color="warning" %}} 
โปรดจำไว้ว่า property `slides_layout_options` มีให้ใช้งานเฉพาะรูปแบบผลลัพธ์บางรูปแบบเท่านั้น เช่น PDF, HTML, TIFF และเมื่อเรนเดอร์เป็นภาพ
{{% /alert %}} 

## **คำถามที่พบบ่อย**

**จำนวนภาพย่อสไลด์สูงสุดต่อหน้าหนึ่งในโหมด Handout คือเท่าไหร่?**

Aspose.Slides รองรับ [presets](https://reference.aspose.com/slides/th/python-net/aspose.slides.export/handouttype/) สูงสุด 9 ภาพย่อต่อหน้า พร้อมการจัดเรียงแนวนอนหรือแนวตั้ง: 1, 2, 3, 4 (แนวนอน/แนวตั้ง), 6 (แนวนอน/แนวตั้ง) และ 9 (แนวนอน/แนวตั้ง).

**ฉันสามารถกำหนดตารางกำหนดเอง เช่น 5 หรือ 8 สไลด์ต่อหน้าได้หรือไม่?**

ไม่. จำนวนและการจัดเรียงของภาพย่อถูกควบคุมอย่างเข้มงวดโดย enumeration [HandoutType](https://reference.aspose.com/slides/th/python-net/aspose.slides.export/handouttype/); การจัดวางแบบกำหนดเองไม่ได้รับการสนับสนุน.

**ฉันสามารถรวมสไลด์ที่ซ่อนอยู่ในผลลัพธ์ Handout ได้หรือไม่?**

ได้. เปิดใช้ตัวเลือก `show_hidden_slides` ในการตั้งค่าการส่งออกสำหรับรูปแบบเป้าหมาย เช่น [PdfOptions](https://reference.aspose.com/slides/th/python-net/aspose.slides.export/pdfoptions/), [HtmlOptions](https://reference.aspose.com/slides/th/python-net/aspose.slides.export/htmloptions/), หรือ [TiffOptions](https://reference.aspose.com/slides/th/python-net/aspose.slides.export/tiffoptions/).