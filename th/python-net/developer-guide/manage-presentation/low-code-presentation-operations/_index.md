---
title: การดำเนินการพรีเซนเทชันแบบ Low-Code ใน Python
linktitle: API Low-Code
type: docs
weight: 50
url: /th/python-net/low-code-presentation-operations/
keywords:
- API พรีเซนเทชัน Low-Code
- แปลงพรีเซนเทชัน
- รวมพรีเซนเทชัน
- รวบรวมรูปร่าง
- บีบอัดพรีเซนเทชัน
- ลบสไลด์มาสเตอร์ที่ไม่ได้ใช้
- ลบสไลด์การจัดวางที่ไม่ได้ใช้
- บีบอัดฟอนต์ฝังอยู่
- PowerPoint
- OpenDocument
- พรีเซนเทชัน
- Python
- Aspose.Slides
description: "ใช้ API Low-Code ของ Aspose.Slides ใน Python เพื่อแปลงและรวมพรีเซนเทชัน, รวบรวมรูปร่าง, และลดขนาดพรีเซนเทชัน."
---
## **ภาพรวม**

โมดูล [aspose.slides.lowcode](https://reference.aspose.com/slides/th/python-net/aspose.slides.lowcode/) ให้คลาสช่วยเหลือสำหรับการดำเนินการพรีเซนเทชันทั่วไป ตัวช่วยเหลือนี้หุ้มกระบวนการทำงานของโมเดลวัตถุที่ใช้บ่อยในเมธอดที่มุ่งเน้น ทำให้คุณสามารถแปลงหรือรวมไฟล์ รวบรวมรูปร่าง และลบเนื้อหาไม่ใช้ได้ด้วยโค้ดที่น้อยลง

ตัวช่วย Low-code มีประโยชน์ที่สุดเมื่อการดำเนินการใช้กับไฟล์หรือพรีเซนเทชันทั้งหมดและกระบวนการทำงานเริ่มต้นตรงกับความต้องการของคุณ ใช้ [Aspose.Slides object model](https://reference.aspose.com/slides/th/python-net/aspose.slides/) แบบเต็มเมื่อคุณต้องการการควบคุมระดับรายละเอียดในสไลด์แต่ละสไลด์ มาสเตอร์ การจัดวาง รูปร่าง การตั้งค่าการส่งออก หรือความสัมพันธ์ระหว่างองค์ประกอบของพรีเซนเทชัน

ตารางต่อไปนี้สรุปตัวช่วยที่มีอยู่:

| ตัวช่วย | ใช้สำหรับ |
| --- | --- |
| [Convert](https://reference.aspose.com/slides/th/python-net/aspose.slides.lowcode/convert/) | แปลงพรีเซนเทชันเป็นรูปแบบอื่นโดยเรียกโดยตรงจากไฟล์ไปยังไฟล์ |
| [Merger](https://reference.aspose.com/slides/th/python-net/aspose.slides.lowcode/merger/) | รวมไฟล์พรีเซนเทชันทั้งหมดที่มีรูปแบบเดียวกัน |
| [Collect](https://reference.aspose.com/slides/th/python-net/aspose.slides.lowcode/collect/) | ดึงรูปร่างจากพรีเซนเทชันทั้งหมดเพื่อการประมวลผลหรือวิเคราะห์ซ้ำ |
| [Compress](https://reference.aspose.com/slides/th/python-net/aspose.slides.lowcode/compress/) | ลบมาสเตอร์และการจัดวางที่ไม่ได้ใช้และลดข้อมูลฟอนต์ฝังอยู่ |

## **แปลงพรีเซนเทชัน**

ใช้ [Convert.auto_by_extension](https://reference.aspose.com/slides/th/python-net/aspose.slides.lowcode/convert/auto_by_extension/) เมื่อส่วนขยายไฟล์ผลลัพธ์เพียงพอที่จะเลือกรูปแบบการส่งออก เมธอดนี้จะเปิดพรีเซนเทชันต้นฉบับ กำหนดรูปแบบที่ต้องการจากเส้นทางไฟล์ผลลัพธ์ และเขียนผลลัพธ์ออกมา

```python
import aspose.slides as slides

slides.lowcode.Convert.auto_by_extension("input.pptx", "output.pdf")
```

คลาส [Convert](https://reference.aspose.com/slides/th/python-net/aspose.slides.lowcode/convert/) ยังให้เมธอดเฉพาะสำหรับการส่งออกเป็น PDF, SVG, JPEG, PNG และ TIFF ใช้โมเดลวัตถุแบบเต็มเมื่อคุณต้องการตรวจสอบหรือแก้ไขพรีเซนเทชันก่อนการส่งออกหรือกำหนดค่าตัวเลือกการส่งออกที่ตัวช่วยที่เลือกไม่เปิดเผย ดูที่ [Convert Presentation](/python-net/convert-presentation/) สำหรับกระบวนการทำงานและตัวเลือกตามรูปแบบ

## **รวมพรีเซนเทชัน**

ใช้ [Merger.process](https://reference.aspose.com/slides/th/python-net/aspose.slides.lowcode/merger/process/) เพื่อรวมไฟล์พรีเซนเทชันทั้งหมดด้วยการเรียกครั้งเดียว พรีเซนเทชันอินพุตต้องมีรูปแบบไฟล์เดียวกัน

```python
import aspose.slides as slides

input_files = ["part-1.pptx", "part-2.pptx"]
slides.lowcode.Merger.process(input_files, "merged.pptx")
```

ตัวช่วยนี้เหมาะเมื่อสไลด์ทั้งหมดควรต่อเติมเป็นผลลัพธ์เดียวโดยไม่ต้องเลือกหรือแมปใหม่แต่ละสไลด์ ใช้โมเดลวัตถุแบบเต็มเมื่อคุณต้องการรวมสไลด์ที่เลือกใช้ มาสเตอร์หรือการจัดวางปลายทาง รักษาภาคอย่างชัดเจน หรือปรับขนาดสไลด์ที่แตกต่างกัน ดูที่ [Merge Presentations](/python-net/merge-presentation/) สำหรับสถานการณ์เหล่านั้น

## **รวบรวมรูปร่าง**

ใช้ [Collect.shapes](https://reference.aspose.com/slides/th/python-net/aspose.slides.lowcode/collect/shapes/) เมื่อคุณต้องการคอลเลกชันของรูปร่างทั้งหมดในพรีเซนเทชัน ซึ่งมีประโยชน์เมื่อชุดเดียวกันจะต้องกรอง นับ หรือประมวลผลหลายครั้ง

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    shapes = slides.lowcode.Collect.shapes(presentation)

    for shape in shapes:
        print(f"{shape.name}: {type(shape).__name__}")
```

ใช้ลูปคอลเลกชันโดยตรงเมื่อลำดับการเดินผ่าน การออกก่อนเวลา การกรองก่อนประมวลผล หรือการควบคุมความสัมพันธ์พ่อแม่-ลูกอย่างละเอียดเป็นสิ่งสำคัญ

## **บีบอัดเนื้อหาพรีเซนเทชัน**

คลาส [Compress](https://reference.aspose.com/slides/th/python-net/aspose.slides.lowcode/compress/) สามารถลบองค์ประกอบโครงสร้างที่ไม่ใช้และลดข้อมูลฟอนต์ฝังอยู่ได้:

- [Compress.remove_unused_layout_slides](https://reference.aspose.com/slides/th/python-net/aspose.slides.lowcode/compress/remove_unused_layout_slides/) ลบสไลด์เลย์เอาต์ที่ไม่มีสไลด์ธรรมดาใดอ้างอิง
- [Compress.remove_unused_master_slides](https://reference.aspose.com/slides/th/python-net/aspose.slides.lowcode/compress/remove_unused_master_slides/) ลบมาสเตอร์สไลด์ที่ไม่ได้ใช้แล้ว
- [Compress.compress_embedded_fonts](https://reference.aspose.com/slides/th/python-net/aspose.slides.lowcode/compress/compress_embedded_fonts/) ลบอักขระที่ไม่ได้ใช้จากฟอนต์ฝังอยู่

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    slides.lowcode.Compress.remove_unused_layout_slides(presentation)
    slides.lowcode.Compress.remove_unused_master_slides(presentation)
    slides.lowcode.Compress.compress_embedded_fonts(presentation)

    presentation.save("compressed.pptx", slides.export.SaveFormat.PPTX)
```

ลบการจัดวางที่ไม่ได้ใช้ก่อนมาสเตอร์ที่ไม่ได้ใช้ เพื่อให้มาสเตอร์ที่กลายเป็นไม่มีการอ้างอิงหลังจากทำความสะอาดการจัดวางก็สามารถลบได้ ให้บันทึกพรีเซนเทชันที่ปรับแต่งแล้วเป็นไฟล์ใหม่หากคุณอาจต้องการมาสเตอร์ การจัดวางต้นฉบับ หรือข้อมูลฟอนต์ฝังทั้งหมดในภายหลัง สำหรับรายละเอียดเพิ่มเติม ดูที่ [Slide Master](/python-net/slide-master/) และ [Embedded Font](/python-net/embedded-font/)

## **คำถามที่พบบ่อย**

**เมื่อใดที่ควรใช้ low-code API แทนการใช้โมเดลวัตถุแบบเต็ม?**

ใช้ตัวช่วย low-code เมื่อการดำเนินการมาตรฐานใช้กับไฟล์หรือพรีเซนเทชันทั้งหมดและไม่ต้องการการควบคุมระดับละเอียดในแต่ละองค์ประกอบ ใช้โมเดลวัตถุแบบเต็มเมื่อคุณต้องการเลือกสไลด์เฉพาะ ควบคุมความสัมพันธ์ของมาสเตอร์และการจัดวาง ตรวจสอบสถานะระหว่างขั้นตอน หรือกำหนดพฤติกรรมที่ตัวช่วยไม่ได้เปิดเผย

**Merger สามารถรวมพรีเซนเทชันในรูปแบบไฟล์ที่ต่างกันได้หรือไม่?**

ไม่. [Merger.process](https://reference.aspose.com/slides/th/python-net/aspose.slides.lowcode/merger/process/) จำเป็นต้องใช้พรีเซนเทชันอินพุตที่มีรูปแบบเดียวกัน ก่อนอื่นให้แปลงไฟล์อินพุตเป็นรูปแบบเดียวกันก่อน เช่นด้วย [Convert.auto_by_extension](https://reference.aspose.com/slides/th/python-net/aspose.slides.lowcode/convert/auto_by_extension/) แล้วจึงรวมไฟล์ที่แปลงแล้ว

**Collect.shapes มีอะไรบ้าง?**

[Collect.shapes](https://reference.aspose.com/slides/th/python-net/aspose.slides.lowcode/collect/shapes/) ดึงรูปร่างจากพรีเซนเทชันเพื่อให้สามารถเก็บไว้ กรอง นับ หรือเดินผ่านหลายครั้ง ใช้ลูปคอลเลกชันโดยตรงเมื่อคุณต้องการการควบคุมที่แม่นยำว่าควรเยี่ยมชมสไลด์ประเภทใดหรือวัตถุที่ซ้อนกัน

**Compress ทำให้ไฟล์พรีเซนเทชันเล็กลงเสมอหรือไม่?**

ไม่จำเป็นผลลัพธ์ขึ้นอยู่กับว่าพรีเซนเทชันมีการจัดวางที่ไม่ได้ใช้ มาสเตอร์ที่ไม่ได้ใช้ หรือฟอนต์ฝังที่มีอักขระไม่ได้ใช้หรือไม่ หากไม่มีสิ่งใดเหล่านี้ การดำเนินการของ [Compress](https://reference.aspose.com/slides/th/python-net/aspose.slides.lowcode/compress/) ที่เกี่ยวข้องอาจไม่ทำให้ขนาดไฟล์ลดลง

**การเปลี่ยนแปลงโดย Compress จะบันทึกโดยอัตโนมัติหรือไม่?**

ไม่. ตัวช่วยเหล่านี้ทำงานกับอ็อบเจ็กต์ [Presentation](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/) ที่โหลดในหน่วยความจำ หลังจากเรียกใช้ [Compress](https://reference.aspose.com/slides/th/python-net/aspose.slides.lowcode/compress/) ให้เรียก [Presentation.save](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/save/) เพื่อบันทึกผลลัพธ์

## **บทความที่เกี่ยวข้อง**

- [แปลงพรีเซนเทชัน](/python-net/convert-presentation/)
- [รวมพรีเซนเทชัน](/python-net/merge-presentation/)
- [มาสเตอร์สไลด์](/python-net/slide-master/)
- [จัดการกล่องข้อความ](/python-net/manage-textbox/)
- [ฟอนต์ฝังอยู่](/python-net/embedded-font/)