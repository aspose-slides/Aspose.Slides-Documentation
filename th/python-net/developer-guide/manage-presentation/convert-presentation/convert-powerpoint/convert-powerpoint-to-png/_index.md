---
title: แปลงสไลด์ PowerPoint เป็น PNG ใน Python
linktitle: สไลด์เป็น PNG
type: docs
weight: 30
url: /th/python-net/convert-powerpoint-to-png/
keywords:
- แปลง PowerPoint เป็น PNG
- แปลงการนำเสนอเป็น PNG
- แปลงสไลด์เป็น PNG
- แปลง PPT เป็น PNG
- แปลง PPTX เป็น PNG
- แปลง ODP เป็น PNG
- PowerPoint เป็น PNG
- การนำเสนอเป็น PNG
- สไลด์เป็น PNG
- PPT เป็น PNG
- PPTX เป็น PNG
- ODP เป็น PNG
- Python
- Aspose.Slides
description: "แปลงการนำเสนอ PowerPoint และ OpenDocument ให้เป็นภาพ PNG คุณภาพสูงอย่างรวดเร็วด้วย Aspose.Slides for Python via .NET พร้อมรับประกันผลลัพธ์ที่แม่นยำและอัตโนมัติ"
---
## **ภาพรวม**

Aspose.Slides for Python via .NET ทำให้การแปลงการนำเสนอ PowerPoint เป็น PNG เป็นเรื่องง่าย คุณโหลดการนำเสนอ, วนลูปรายการสไลด์, เรนเดอร์แต่ละสไลด์เป็นภาพแรสเตอร์, และบันทึกผลลัพธ์เป็นไฟล์ PNG เหมาะสำหรับการสร้างภาพพรีวิวสไลด์, ฝังสไลด์ในหน้าเว็บ, หรือสร้างทรัพยากรคงที่เพื่อการประมวลผลต่อไป

## **แปลงสไลด์เป็น PNG**

ส่วนนี้แสดงตัวอย่างที่ง่ายที่สุดในการแปลงการนำเสนอ PowerPoint เป็นภาพ PNG โดยใช้ Aspose.Slides for Python via .NET

ทำตามขั้นตอนเหล่านี้:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/) .
1. รับสไลด์จากคอลเลกชัน `Presentation.slides` (ดูคลาส [Slide](https://reference.aspose.com/slides/th/python-net/aspose.slides/slide/) ) .
1. ใช้เมธอด `Slide.get_image` เพื่อสร้างภาพย่อของสไลด์ .
1. ใช้เมธอด `Presentation.save` เพื่อบันทึกภาพย่อสไลด์ในรูปแบบ PNG .

โค้ด Python นี้แสดงวิธีแปลง PowerPoint เป็น PNG:

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    for index, slide in enumerate(presentation.slides):
        with slide.get_image() as image:
            image.save(f"slide_{index}.png", slides.ImageFormat.PNG)
```

## **แปลงสไลด์เป็น PNG พร้อมขนาดกำหนดเอง**

เพื่อส่งออกสไลด์เป็น PNG ด้วยสเกลที่กำหนดเอง ให้เรียก `Slide.get_image` พร้อมปัจจัยสเกลในแนวนอนและแนวดิ่ง ตัวคูณเหล่านี้ปรับขนาดผลลัพธ์เปรียบเทียบกับมิติเดิมของสไลด์ เช่น `2.0` จะทำให้ความกว้างและความสูงเพิ่มเป็นสองเท่า ใช้ค่าที่เท่ากันสำหรับ `scale_x` และ `scale_y` เพื่อคงอัตราส่วนภาพ

โค้ด Python นี้แสดงการทำงานที่อธิบายไว้:

```py
import aspose.slides as slides

scale_x = 2
scale_y = scale_x

with slides.Presentation("presentation.pptx") as presentation:
    for index, slide in enumerate(presentation.slides):
        with slide.get_image(scale_x, scale_y) as image:
            image.save(f"slide_{index}.png", slides.ImageFormat.PNG)
```

## **แปลงสไลด์เป็น PNG ด้วยขนาดกำหนดเอง**

หากคุณต้องการสร้างไฟล์ PNG ด้วยขนาดที่กำหนด ให้ส่งค่า `width` และ `height` ตามที่ต้องการ โค้ดด้านล่างแสดงวิธีแปลง PowerPoint เป็น PNG โดยระบุขนาดภาพ: 

```py
import aspose.slides as slides
import aspose.pydrawing as drawing

size = drawing.Size(960, 720)

with slides.Presentation("presentation.pptx") as presentation:
    for index, slide in enumerate(presentation.slides):
        with slide.get_image(size) as image:
            image.save(f"slide_{index}.png", slides.ImageFormat.PNG)
```

{{% alert title="Tip" color="primary" %}}
คุณอาจต้องการลองใช้ **ตัวแปลง PowerPoint เป็น PNG** ฟรีของ Aspose—[PPTX to PNG](https://products.aspose.app/slides/th/conversion/pptx-to-png) และ [PPT to PNG](https://products.aspose.app/slides/th/conversion/ppt-to-png) พวกมันให้การทำงานแบบสดของกระบวนการที่อธิบายในหน้านี้
{{% /alert %}}

## **คำถามที่พบบ่อย**

**ฉันจะส่งออกเฉพาะรูปร่างที่ต้องการ (เช่น แผนภูมิหรือรูปภาพ) แทนสไลด์ทั้งหมดได้อย่างไร?**

Aspose.Slides รองรับการ [สร้างภาพย่อสำหรับรูปร่างเดี่ยว](/slides/th/python-net/create-shape-thumbnails/) ; คุณสามารถเรนเดอร์รูปร่างเป็นภาพ PNG

**การแปลงพร้อมกันหลายงานบนเซิร์ฟเวอร์รองรับหรือไม่?**

ใช่, แต่ต้อง [ไม่แชร์](/slides/th/python-net/multithreading/) อินสแตนซ์การนำเสนอเดียวกันข้ามเธรด ควรใช้อินสแตนซ์แยกต่อแต่ละเธรดหรือกระบวนการ

**ข้อจำกัดของรุ่นทดลองเมื่อส่งออกเป็น PNG มีอะไรบ้าง?**

โหมดประเมินจะเพิ่มลายน้ำลงในภาพผลลัพธ์และบังคับใช้ [ข้อจำกัดอื่น](/slides/th/python-net/licensing/) จนกว่าจะมีการใช้ใบอนุญาต