---
title: Aspose.Slides for Python via .NET
second_title: Aspose.Slides for Python
type: docs
weight: 35
url: /th/python-net/
is_root: true
keywords:
- Aspose.Slides for Python
- การทำงานอัตโนมัติ PowerPoint ด้วย Python
- ไลบรารี PPT ของ Python
- ส่งออก PowerPoint เป็น PDF ด้วย Python
- ส่งออก PowerPoint เป็น SVG ด้วย Python
- แก้ไข PowerPoint ด้วย Python
- PowerPoint บน Python โดยไม่ต้องใช้ Microsoft Office
- จัดการไฟล์ PPTX ด้วย Python
- แสดงตัวอย่างสไลด์ด้วย Python
- Python เพิ่มเสียงให้สไลด์
- PowerPoint
- OpenDocument
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET มีชุดคุณสมบัติครบถ้วน รวมถึงการจัดการข้อความ, รูปร่าง, ตารางและแอนิเมชัน, การเพิ่มเสียงและวิดีโอในสไลด์, การแสดงตัวอย่างสไลด์, และการส่งออกเป็น SVG, PDF และอื่นๆ"
---
{{% alert color="info" %}}

**ยินดีต้อนรับสู่ Aspose.Slides for Python via .NET**

![Aspose.Slides for Python via .NET Product Logo](aspose_slides-for-python.png)

Aspose.Slides for Python via .NET เป็นไลบรารีคลาสที่แข็งแรงซึ่งช่วยให้แอปพลิเคชันของคุณอ่านและเขียนงานนำเสนอ PowerPoint® ได้โดยไม่ต้องพึ่งพา Microsoft PowerPoint®.

นี่คือคอมโพเนนต์แรกและเดียวที่ให้การจัดการเอกสาร PowerPoint® อย่างครบถ้วนสำหรับนักพัฒนา Python.

Aspose.Slides for Python via .NET มีคุณสมบัติต่างๆ มากมาย เช่น การทำงานกับข้อความ, รูปร่าง, ตาราง, และแอนิเมชัน; การเพิ่มเสียงและวิดีโอ; การแสดงตัวอย่างสไลด์; และการส่งออกสไลด์เป็นรูปแบบต่างๆ เช่น SVG, PDF และอื่นๆ.

{{% /alert %}}

## ติดตั้ง Aspose.Slides for Python via .NET

```bash
pip install aspose.slides
```

แพ็คเกจมาพร้อมกับ .NET runtime ที่จำเป็นจึงไม่มีสิ่งอื่นต้องติดตั้ง และไม่จำเป็นต้องใช้ Microsoft PowerPoint. รองรับ Python 3.7 หรือใหม่กว่า บน Windows, Linux หรือ macOS.

## สร้างงานนำเสนอ PowerPoint ด้วย Python

ตัวอย่างนี้สร้างงานนำเสนอ, เพิ่มรูปร่างพร้อมข้อความในสไลด์แรก, แล้วบันทึกผลลัพธ์เป็นทั้งไฟล์ PPTX และ PDF.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 150, 600, 100)
    shape.text_frame.text = "Created with Aspose.Slides for Python via .NET"

    presentation.save("presentation.pptx", slides.export.SaveFormat.PPTX)
    presentation.save("presentation.pdf", slides.export.SaveFormat.PDF)
```

เมื่อรันจะเขียนไฟล์ `presentation.pptx` (ประมาณ 34 KB) และ `presentation.pdf` (ประมาณ 36 KB) ไปยังไดเรกทอรีทำงาน.

หากไม่มีใบอนุญาต ไลบรารีจะทำงานในโหมดประเมินผล ซึ่งจะเพิ่มลายน้ำและจำกัดจำนวนสไลด์ ดูที่ [Licensing](/slides/th/python-net/licensing/) เพื่อใช้ใบอนุญาต.

## แหล่งข้อมูล Aspose.Slides for Python via .NET

สำรวจแหล่งข้อมูลที่เป็นประโยชน์ต่อไปนี้:

- [Aspose.Slides for Python via .NET เอกสารออนไลน์](/slides/th/python-net/)
- [Aspose.Slides for Python via .NET คุณสมบัติ](/slides/th/python-net/features-overview/)
- [Aspose.Slides for Python via .NET บันทึกการอัปเดต](https://releases.aspose.com/slides/th/python-net/release-notes/)
- [Aspose.Slides for Python via .NET หน้าผลิตภัณฑ์](https://products.aspose.com/slides/th/python-net/)
- [ดาวน์โหลด Aspose.Slides for Python via .NET](https://releases.aspose.com/slides/th/python-net/)
- [ติดตั้ง Aspose.Slides for Python via .NET PyPi Package](https://pypi.org/project/aspose.slides/)
- [Aspose.Slides for Python via .NET คู่มืออ้างอิง API](https://reference.aspose.com/slides/th/python-net/)
- [Aspose.Slides for Python via .NET ฟอรั่มสนับสนุนฟรี](https://forum.aspose.com/c/slides/th/11)
- [Aspose.Slides for Python via .NET ศูนย์ช่วยเหลือสนับสนุนแบบชำระเงิน](https://helpdesk.aspose.com/)

## คำถามที่พบบ่อย

### Aspose.Slides for Python via .NET คืออะไร?

Aspose.Slides for Python via .NET เป็นไลบรารี Python ที่ทรงพลังซึ่งช่วยให้คุณสร้าง, แก้ไข, และแปลงงานนำเสนอ PowerPoint (PPT, PPTX, ODP) โดยอัตโนมัติโดยไม่ต้องติดตั้ง Microsoft PowerPoint.

### Aspose.Slides รองรับคุณสมบัติงานนำเสนออะไรบ้าง?

ไลบรารีนี้รองรับการจัดการข้อความ, รูปร่าง, ตาราง, แผนภูมิ, แอนิเมชัน, สไลด์หลัก, เสียง, วิดีโอ และอื่นๆ อีกหลายอย่าง นอกจากนี้ยังสามารถแสดงตัวอย่างสไลด์, เรนเดอร์, และส่งออกเป็นรูปแบบต่างๆ เช่น PDF, SVG, HTML และรูปภาพ.

### ฉันสามารถแปลงงานนำเสนอเป็นรูปแบบอื่นด้วย Aspose.Slides ได้หรือไม่?

ได้เลย Aspose.Slides สามารถแปลงไฟล์ PowerPoint ไปเป็น PDF, SVG, HTML, JPG, PNG, TIFF และรูปแบบอื่นๆ ได้ด้วยความแม่นยำและประสิทธิภาพสูง.

### ต้องใช้ Microsoft PowerPoint เพื่อใช้ Aspose.Slides หรือไม่?

ไม่ Aspose.Slides เป็น API แบบสแตนด์อโลนไม่ต้องการ Microsoft Office หรือซอฟต์แวร์ของคนที่สามใดๆ.

### แพลตฟอร์มใดบ้างที่ Aspose.Slides for Python via .NET รองรับ?

มันเป็นแบบข้ามแพลตฟอร์มและทำงานได้บนสภาพแวดล้อม Windows, Linux และ macOS.

### ฉันจะเริ่มต้นกับ Aspose.Slides for Python อย่างไร?

คุณสามารถติดตั้งผ่าน PyPi และสำรวจ [คู่มือผู้พัฒนา](/slides/th/python-net/developer-guide/) เพื่อเริ่มต้นด้วยตัวอย่าง, การอ้างอิง API, และบทแนะนำ.