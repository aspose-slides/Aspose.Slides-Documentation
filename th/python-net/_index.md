---
title: Aspose.Slides สำหรับ Python ผ่าน .NET
second_title: Aspose.Slides สำหรับ Python
type: docs
weight: 35
url: /th/python-net/
is_root: true
keywords:
- Aspose.Slides สำหรับ Python
- การทำงานอัตโนมัติ PowerPoint ด้วย Python
- ไลบรารี PPT สำหรับ Python
- ส่งออก PowerPoint เป็น PDF ด้วย Python
- ส่งออก PowerPoint เป็น SVG ด้วย Python
- แก้ไข PowerPoint ใน Python
- PowerPoint ของ Python โดยไม่มี Microsoft Office
- จัดการไฟล์ PPTX ด้วย Python
- ดูตัวอย่างสไลด์ใน Python
- Python เพิ่มเสียงในสไลด์
- PowerPoint
- OpenDocument
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET มีชุดคุณสมบัติที่ครบถ้วน รวมถึงการจัดการข้อความ, รูปทรง, ตาราง, และแอนิเมชัน, การเพิ่มเสียงและวิดีโอลงในสไลด์, การดูตัวอย่างสไลด์, และการส่งออกเป็น SVG, PDF และอื่น ๆ อีกมากมาย."
---
{{% alert color="primary" %}}

**ยินดีต้อนรับสู่ Aspose.Slides for Python via .NET**

![โลโก้ผลิตภัณฑ์ Aspose.Slides for Python via .NET](aspose_slides-for-python.png)

Aspose.Slides for Python via .NET เป็นไลบรารีคลาสที่แข็งแกร่งซึ่งช่วยให้แอปพลิเคชันของคุณสามารถอ่านและเขียนไฟล์นำเสนอ PowerPoint® ได้โดยไม่ต้องใช้ Microsoft PowerPoint®.

นี่เป็นคอมโพเนนต์ตัวแรกและตัวเดียวที่ให้การจัดการเอกสาร PowerPoint® แบบครบถ้วนสำหรับนักพัฒนา Python.

Aspose.Slides for Python via .NET มีคุณสมบัติหลากหลาย เช่น การทำงานกับข้อความ, รูปทรง, ตาราง และแอนิเมชัน; การเพิ่มเสียงและวิดีโอ; การดูตัวอย่างสไลด์; และการส่งออกสไลด์เป็นรูปแบบต่าง ๆ เช่น SVG, PDF และอื่น ๆ.

{{% /alert %}}

## ติดตั้ง Aspose.Slides for Python via .NET

```bash
pip install aspose.slides
```

แพคเกจมาพร้อมกับ .NET runtime ที่จำเป็น จึงไม่มีสิ่งอื่นให้ติดตั้งและไม่ต้องใช้ Microsoft PowerPoint. รองรับ Python 3.7 หรือใหม่กว่า บน Windows, Linux หรือ macOS.

## สร้างไฟล์นำเสนอ PowerPoint ด้วย Python

ตัวอย่างนี้สร้างไฟล์นำเสนอ, เพิ่มรูปทรงพร้อมข้อความในสไลด์แรก, และบันทึกผลลัพธ์เป็นทั้ง PPTX และ PDF.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 150, 600, 100)
    shape.text_frame.text = "Created with Aspose.Slides for Python via .NET"

    presentation.save("presentation.pptx", slides.export.SaveFormat.PPTX)
    presentation.save("presentation.pdf", slides.export.SaveFormat.PDF)
```

การรันจะเขียนไฟล์ `presentation.pptx` (ประมาณ 34 KB) และ `presentation.pdf` (ประมาณ 36 KB) ไปยังไดเรกทอรีทำงาน.

หากไม่มีใบอนุญาต ไลบรารีจะทำงานในโหมดประเมินผล ซึ่งจะเพิ่มลายน้ำและจำกัดจำนวนสไลด์ ดูที่ [การให้ลิขสิทธิ์](/slides/th/python-net/licensing/) เพื่อใช้ใบอนุญาต.

## แหล่งข้อมูล Aspose.Slides for Python via .NET

สำรวจแหล่งข้อมูลที่เป็นประโยชน์ต่อไปนี้:

- [เอกสารออนไลน์ Aspose.Slides for Python via .NET](/slides/th/python-net/)
- [คุณสมบัติ Aspose.Slides for Python via .NET](/slides/th/python-net/features-overview/)
- [บันทึกเวอร์ชัน Aspose.Slides for Python via .NET](https://releases.aspose.com/slides/th/python-net/release-notes/)
- [หน้าผลิตภัณฑ์ Aspose.Slides for Python via .NET](https://products.aspose.com/slides/th/python-net/)
- [ดาวน์โหลด Aspose.Slides for Python via .NET](https://releases.aspose.com/slides/th/python-net/)
- [ติดตั้งแพคเกจ PyPi Aspose.Slides for Python via .NET](https://pypi.org/project/aspose.slides/)
- [คู่มืออ้างอิง API Aspose.Slides for Python via .NET](https://reference.aspose.com/slides/th/python-net/)
- [ฟอรัมสนับสนุนฟรี Aspose.Slides for Python via .NET](https://forum.aspose.com/c/slides/th/11)
- [ศูนย์ช่วยเหลือสนับสนุนจ่ายเงิน Aspose.Slides for Python via .NET](https://helpdesk.aspose.com/)

## คำถามที่พบบ่อย

### Aspose.Slides for Python via .NET คืออะไร?

Aspose.Slides for Python via .NET เป็นไลบรารี Python ที่มีประสิทธิภาพซึ่งช่วยให้คุณสร้าง, แก้ไข, และแปลงไฟล์นำเสนอ PowerPoint (PPT, PPTX, ODP) ด้วยโปรแกรมโดยไม่ต้องติดตั้ง Microsoft PowerPoint.

### ฟีเจอร์การนำเสนอใดที่ Aspose.Slides รองรับ?

ไลบรารีสนับสนุนการจัดการข้อความ, รูปทรง, ตาราง, แผนภูมิ, แอนิเมชัน, มาสเตอร์สไลด์, เสียง, วิดีโอ, และอื่น ๆ อีกหลายอย่าง นอกจากนี้ยังสามารถดูตัวอย่างสไลด์, เรนเดอร์, พิมพ์, และส่งออกเป็นรูปแบบต่าง ๆ เช่น PDF, SVG, HTML, และรูปภาพ.

### ฉันสามารถแปลงไฟล์นำเสนอเป็นรูปแบบอื่นโดยใช้ Aspose.Slides ได้หรือไม่?

ได้ค่ะ. Aspose.Slides สามารถแปลงไฟล์ PowerPoint เป็น PDF, SVG, HTML, JPG, PNG, TIFF, และรูปแบบอื่น ๆ ด้วยความแม่นยำและประสิทธิภาพสูง.

### จำเป็นต้องใช้ Microsoft PowerPoint เพื่อใช้ Aspose.Slides หรือไม่?

ไม่จำเป็น. Aspose.Slides เป็น API แบบสแตนด์อโลนและไม่ต้องการ Microsoft Office หรือซอฟต์แวร์ของบุคคลที่สามใด ๆ.

### แพลตฟอร์มใดบ้างที่ Aspose.Slides for Python via .NET รองรับ?

มันเป็นแบบข้ามแพลตฟอร์มและทำงานบนสภาพแวดล้อม Windows, Linux, และ macOS.

### ฉันจะเริ่มต้นกับ Aspose.Slides for Python ได้อย่างไร?

คุณสามารถติดตั้งผ่าน PyPi และสำรวจ [คู่มือผู้พัฒนา](/slides/th/python-net/developer-guide/) เพื่อเริ่มต้นด้วยตัวอย่าง, เอกสารอ้างอิง API, และบทเรียน.