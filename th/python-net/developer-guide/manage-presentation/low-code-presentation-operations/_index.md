---
title: การดำเนินการพรีเซนเทชันแบบ Low-Code ด้วย Python
linktitle: API Low-Code
type: docs
weight: 50
url: /th/python-net/low-code-presentation-operations/
keywords:
- API พรีเซนเทชันแบบ Low-Code
- แปลงพรีเซนเทชัน
- รวมพรีเซนเทชัน
- รวบรวมรูปทรง
- บีบอัดพรีเซนเทชัน
- ลบมาสเตอร์สไลด์ที่ไม่ได้ใช้
- ลบเลเอาต์สไลด์ที่ไม่ได้ใช้
- บีบอัดฟอนต์ที่ฝังอยู่
- PowerPoint
- OpenDocument
- พรีเซนเทชัน
- Python
- Aspose.Slides
description: "ใช้ Aspose.Slides low-code API ใน Python เพื่อแปลงและรวมพรีเซนเทชัน, รวบรวมรูปทรง, และลดขนาดพรีเซนเทชัน"
---
## **ภาพรวม**

โมดูล [aspose.slides.lowcode](https://reference.aspose.com/slides/th/python-net/aspose.slides.lowcode/) ให้คลาสช่วยเหลือสำหรับการดำเนินการพรีเซนเทชันทั่วไป คลาสช่วยเหลือนี้ห่อหุ้มขั้นตอนการทำงานของโมเดลวัตถุที่ใช้บ่อยในเมธอดที่มุ่งเน้น ทำให้คุณสามารถแปลงหรือรวมไฟล์ รวบรวมรูปทรง และลบเนื้อหาที่ไม่ได้ใช้ด้วยโค้ดที่สั้นลง

ตัวช่วยแบบ low-code มีประโยชน์สูงสุดเมื่อการดำเนินการใช้กับไฟล์หรือพรีเซนเทชันทั้งหมดและเวิร์กโฟลว์เริ่มต้นตรงกับความต้องการของคุณ ใช้โมเดลวัตถุเต็มของ [Aspose.Slides](https://reference.aspose.com/slides/th/python-net/aspose.slides/) เมื่อคุณต้องการการควบคุมที่ละเอียดระดับสไลด์แต่ละสไลด์ มาสเตอร์ เลเอาต์ รูปทรง การตั้งค่าส่งออก หรือความสัมพันธ์ระหว่างองค์ประกอบของพรีเซนเทชัน

ตารางต่อไปสรุปตัวช่วยที่มีให้:

| เครื่องมือช่วยเหลือ | ใช้สำหรับ |
| --- | --- |
| [Convert](https://reference.aspose.com/slides/th/python-net/aspose.slides.lowcode/convert/) | การแปลงพรีเซนเทชันเป็นรูปแบบอื่นด้วยการเรียกไฟล์ต่อไฟล์โดยตรง |
| [Merger](https://reference.aspose.com/slides/th/python-net/aspose.slides.lowcode/merger/) | การรวมไฟล์พรีเซนเทชันครบชุดที่มีรูปแบบเดียวกัน |
| [Collect](https://reference.aspose.com/slides/th/python-net/aspose.slides.lowcode/collect/) | การดึงรูปทรงจากพรีเซนเทชันทั้งหมดเพื่อการประมวลผลหรือวิเคราะห์ซ้ำ |
| [Compress](https://reference.aspose.com/slides/th/python-net/aspose.slides.lowcode/compress/) | การลบมาสเตอร์และเลเอาต์ที่ไม่ได้ใช้และลดข้อมูลฟอนต์ที่ฝังอยู่ |

## **แปลงพรีเซนเทชัน**

ใช้ [Convert.auto_by_extension](https://reference.aspose.com/slides/th/python-net/aspose.slides.lowcode/convert/auto_by_extension/) เมื่อส่วนขยายของไฟล์ผลลัพธ์เพียงพอที่จะเลือกรูปแบบการส่งออก เมธอดนี้เปิดพรีเซนเทชันต้นฉบับ กำหนดรูปแบบที่ต้องการจากเส้นทางไฟล์ผลลัพธ์ แล้วเขียนผลลัพธ์ออกมา

```python
import aspose.slides as slides

slides.lowcode.Convert.auto_by_extension("input.pptx", "output.pdf")
```

คลาส [Convert](https://reference.aspose.com/slides/th/python-net/aspose.slides.lowcode/convert/) ยังมีเมธอดเฉพาะสำหรับการส่งออกเป็น PDF, SVG, JPEG, PNG และ TIFF ใช้โมเดลวัตถุเต็มเมื่อคุณต้องการตรวจสอบหรือแก้ไขพรีเซนเทชันก่อนการส่งออกหรือกำหนดตัวเลือกการส่งออกที่ไม่ได้เปิดให้กับตัวช่วยที่เลือก ดู [Convert Presentation](/slides/th/python-net/convert-presentation/) สำหรับเวิร์กโฟลว์และตัวเลือกที่เฉพาะเจาะจงตามรูปแบบ

## **รวมพรีเซนเทชัน**

ใช้ [Merger.process](https://reference.aspose.com/slides/th/python-net/aspose.slides.lowcode/merger/process/) เพื่อรวมไฟล์พรีเซนเทชันครบชุดด้วยการเรียกครั้งเดียว พรีเซนเทชันที่นำเข้าต้องเป็นรูปแบบไฟล์เดียวกัน

```python
import aspose.slides as slides

input_files = ["part-1.pptx", "part-2.pptx"]
slides.lowcode.Merger.process(input_files, "merged.pptx")
```

ตัวช่วยนี้เหมาะเมื่อสไลด์ทั้งหมดควรต่อเนื่องเป็นผลลัพธ์เดียวโดยไม่ต้องเลือกหรือแมปใหม่แต่ละสไลด์ ใช้โมเดลวัตถุเต็มเมื่อคุณต้องการรวมสไลด์ที่เลือกใช้มาสเตอร์หรือเลเอาต์ปลายทาง เก็บส่วนต่าง ๆ อย่างชัดเจน หรือปรับขนาดสไลด์ที่แตกต่างกัน ดู [Merge Presentations](/slides/th/python-net/merge-presentation/) สำหรับสถานการณ์เหล่านั้น

## **รวบรวมรูปทรง**

ใช้ [Collect.shapes](https://reference.aspose.com/slides/th/python-net/aspose.slides.lowcode/collect/shapes/) เมื่อคุณต้องการคอลเลกชันของรูปทรงทั้งหมดในพรีเซนเทชัน ซึ่งเป็นประโยชน์เมื่อชุดเดียวกันจะถูกกรอง นับ หรือประมวลผลหลายครั้ง

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    shapes = slides.lowcode.Collect.shapes(presentation)

    for shape in shapes:
        print(f"{shape.name}: {type(shape).__name__}")
```

ใช้ลูปการเก็บโดยตรงเมื่อลำดับการท่องเที่ยว การออกจากลูปล่วงหน้า การกรองก่อนประมวลผล หรือการควบคุมความสัมพันธ์แม่-ลูกอย่างละเอียดมีความสำคัญ

## **บีบอัดเนื้อหาพรีเซนเทชัน**

คลาส [Compress](https://reference.aspose.com/slides/th/python-net/aspose.slides.lowcode/compress/) สามารถลบองค์ประกอบโครงสร้างที่ไม่ได้ใช้และลดข้อมูลฟอนต์ที่ฝังอยู่:

- [Compress.remove_unused_layout_slides](https://reference.aspose.com/slides/th/python-net/aspose.slides.lowcode/compress/remove_unused_layout_slides/) ลบสไลด์เลเอาต์ที่ไม่มีสไลด์ปกติอ้างอิง
- [Compress.remove_unused_master_slides](https://reference.aspose.com/slides/th/python-net/aspose.slides.lowcode/compress/remove_unused_master_slides/) ลบมาสเตอร์สไลด์ที่ไม่ได้ใช้แล้ว
- [Compress.compress_embedded_fonts](https://reference.aspose.com/slides/th/python-net/aspose.slides.lowcode/compress/compress_embedded_fonts/) ลบอักขระที่ไม่ได้ใช้จากฟอนต์ที่ฝังอยู่

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    slides.lowcode.Compress.remove_unused_layout_slides(presentation)
    slides.lowcode.Compress.remove_unused_master_slides(presentation)
    slides.lowcode.Compress.compress_embedded_fonts(presentation)

    presentation.save("compressed.pptx", slides.export.SaveFormat.PPTX)
```

ให้ลบเลเอาต์ที่ไม่ได้ใช้ก่อนมาสเตอร์ที่ไม่ได้ใช้ เพื่อให้มาสเตอร์ที่กลายเป็นไม่มีการอ้างอิงหลังจากทำความสะอาดเลเอาต์สามารถลบได้ด้วย บันทึกพรีเซนเทชันที่ปรับให้เหมาะสมเป็นไฟล์ใหม่หากคุณอาจต้องการมาสเตอร์, เลเอาต์ หรือข้อมูลฟอนต์ที่ฝังทั้งหมดในภายหลัง สำหรับรายละเอียดเพิ่มเติม ดู [Slide Master](/slides/th/python-net/slide-master/) และ [Embedded Font](/slides/th/python-net/embedded-font/)

## **คำถามที่พบบ่อย**

**เมื่อใดที่ฉันควรใช้ low-code API แทนโมเดลวัตถุเต็ม?**

ใช้ตัวช่วย low-code เมื่อการดำเนินการมาตรฐานใช้กับไฟล์หรือพรีเซนเทชันทั้งหมดและไม่ต้องการการควบคุมละเอียดระดับองค์ประกอบแต่ละตัว ใช้โมเดลวัตถุเต็มเมื่อคุณต้องการเลือกสไลด์เฉพาะ ควบคุมความสัมพันธ์ของมาสเตอร์และเลเอาต์ ตรวจสอบสถานะกลาง หรือกำหนดพฤติกรรมที่ตัวช่วยไม่เปิดเผย

**Merger สามารถรวมพรีเซนเทชันในรูปแบบไฟล์ที่ต่างกันได้หรือไม่?**

ไม่ได้ ตัวช่วย [Merger.process](https://reference.aspose.com/slides/th/python-net/aspose.slides.lowcode/merger/process/) ต้องการพรีเซนเทชันอินพุตที่มีรูปแบบเดียวกัน ให้แปลงไฟล์อินพุตเป็นรูปแบบเดียวกันก่อน ตัวอย่างเช่นโดยใช้ [Convert.auto_by_extension](https://reference.aspose.com/slides/th/python-net/aspose.slides.lowcode/convert/auto_by_extension/) แล้วจึงรวมไฟล์ที่แปลงแล้ว

**Collect.shapes มีอะไรบ้าง?**

[Collect.shapes](https://reference.aspose.com/slides/th/python-net/aspose.slides.lowcode/collect/shapes/) ดึงรูปทรงจากพรีเซนเทชันเพื่อให้สามารถเก็บไว้ กรอง นับ หรือท่องเที่ยวหลายครั้งได้ ใช้ลูปการเก็บโดยตรงเมื่อคุณต้องการควบคุมนำทางสไลด์หรืออ็อบเจ็กต์ย่อยที่เยี่ยมชมอย่างแม่นยำ

**Compress ทำให้ไฟล์พรีเซนเทชันเล็กลงทุกครั้งหรือไม่?**

ไม่เสมอ ผลลัพธ์ขึ้นอยู่กับว่าพรีเซนเทชันมีเลเอาต์ที่ไม่ได้ใช้, มาสเตอร์ที่ไม่ได้ใช้ หรือฟอนต์ที่ฝังอยู่พร้อมอักขระที่ไม่ได้ใช้หรือไม่ หากไม่มีสิ่งเหล่านี้ การดำเนินการ [Compress](https://reference.aspose.com/slides/th/python-net/aspose.slides.lowcode/compress/) ที่เกี่ยวข้องอาจไม่ลดขนาดไฟล์

**การเปลี่ยนแปลงที่ทำโดย Compress จะบันทึกโดยอัตโนมัติหรือไม่?**

ไม่ได้ ตัวช่วยเหล่านี้ทำงานกับอ็อบเจ็กต์ [Presentation](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/) ที่โหลดอยู่ในหน่วยความจำ หลังจากเรียก [Compress](https://reference.aspose.com/slides/th/python-net/aspose.slides.lowcode/compress/) ให้เรียก [Presentation.save](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/save/) เพื่อบันทึกผลลัพธ์

## **บทความที่เกี่ยวข้อง**

- [Convert Presentation](/slides/th/python-net/convert-presentation/)
- [Merge Presentations](/slides/th/python-net/merge-presentation/)
- [Slide Master](/slides/th/python-net/slide-master/)
- [Manage Text Box](/slides/th/python-net/manage-textbox/)
- [Embedded Font](/slides/th/python-net/embedded-font/)