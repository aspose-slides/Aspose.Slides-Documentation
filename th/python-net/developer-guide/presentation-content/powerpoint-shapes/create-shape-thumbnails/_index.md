---
title: "สร้างภาพย่อของรูปร่างการนำเสนอใน Python"
linktitle: "ภาพย่อของรูปร่าง"
type: docs
weight: 70
url: /th/python-net/create-shape-thumbnails/
keywords:
- "ภาพย่อของรูปร่าง"
- "ภาพของรูปร่าง"
- "เรนเดอร์รูปร่าง"
- "การเรนเดอร์รูปร่าง"
- "PowerPoint"
- "การนำเสนอ"
- "Python"
- "Aspose.Slides"
description: "สร้างภาพย่อของรูปร่างคุณภาพสูงจากสไลด์ PowerPoint และ OpenDocument ด้วย Aspose.Slides for Python via .NET - สร้างและส่งออกภาพย่อของงานนำเสนอได้อย่างง่ายดาย."
---
## **แนะนำ**

Aspose.Slides for Python via .NET ใช้เพื่อสร้างไฟล์งานนำเสนอที่แต่ละหน้าคือสไลด์ คุณสามารถดูสไลด์เหล่านี้ใน Microsoft PowerPoint โดยเปิดไฟล์งานนำเสนอ อย่างไรก็ตาม นักพัฒนาบางครั้งอาจต้องการดูภาพของรูปร่างแยกจากกันในโปรแกรมดูรูป ในกรณีดังกล่าว Aspose.Slides สามารถสร้างภาพย่อของรูปร่างในสไลด์ได้ บทความนี้อธิบายวิธีใช้คุณลักษณะนี้

## **สร้างภาพย่อของรูปร่างจากสไลด์**

เมื่อคุณต้องการตัวอย่างของวัตถุเฉพาะแทนการดูสไลด์ทั้งหมด คุณสามารถเรนเดอร์ภาพย่อสำหรับรูปร่างแต่ละอันได้ Aspose.Slides ช่วยให้คุณส่งออกรูปร่างใดก็ได้เป็นภาพ ทำให้สร้างตัวอย่างขนาดเล็ก ไอคอน หรือทรัพยากรสำหรับการประมวลผลต่อไปได้อย่างง่ายดาย

เพื่อสร้างภาพย่อจากรูปร่างใด ๆ:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/)
1. รับอ้างอิงไปยังสไลด์โดยใช้ ID หรือดัชนีของมัน
1. รับอ้างอิงไปยังรูปร่างบนสไลด์นั้น
1. เรนเดอร์ภาพย่อของรูปร่าง
1. บันทึกภาพย่อในรูปแบบที่ต้องการ

```py
import aspose.slides as slides

# สร้างอินสแตนซ์ของคลาส Presentation เพื่อเปิดไฟล์งานนำเสนอ.
with slides.Presentation("hello_world.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]
    
    # สร้างภาพด้วยสเกลเริ่มต้น.
    with shape.get_image() as thumbnail:
        # บันทึกภาพลงดิสก์ในรูปแบบ PNG.
        thumbnail.save("shape_thumbnail.png", slides.ImageFormat.PNG)
```

## **สร้างภาพย่อโดยใช้ปัจจัยสเกลที่กำหนดเอง**

ส่วนนี้แสดงวิธีสร้างภาพย่อของรูปร่างโดยใช้ปัจจัยสเกลที่ผู้ใช้กำหนดใน Aspose.Slides ด้วยการควบคุมสเกล คุณสามารถปรับขนาดภาพย่อให้เหมาะกับการแสดงตัวอย่าง การส่งออก หรือหน้าจอความละเอียดสูง

เพื่อสร้างภาพย่อสำหรับรูปร่างใด ๆ บนสไลด์:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/)
1. รับสไลด์โดยใช้ ID หรือดัชนี
1. รับรูปร่างเป้าหมายบนสไลด์นั้น
1. เรนเดอร์ภาพย่อของรูปร่างด้วยสเกลที่ระบุ
1. บันทึกภาพย่อในรูปแบบที่ต้องการ

```py
import aspose.slides as slides

scale_x = 2.0
scale_y = scale_x

# สร้างอินสแตนซ์ของคลาส Presentation เพื่อเปิดไฟล์งานนำเสนอ.
with slides.Presentation("hello_world.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]
    
    # สร้างภาพด้วยสเกลที่กำหนด.
    with shape.get_image(slides.ShapeThumbnailBounds.SHAPE, scale_x, scale_y) as thumbnail:
        # บันทึกภาพลงดิสก์ในรูปแบบ PNG.
        thumbnail.save("scaling_factor.png", slides.ImageFormat.PNG)
```

## **สร้างภาพย่อโดยใช้ขอบเขตการแสดงผลของรูปร่าง**

ส่วนนี้แสดงวิธีสร้างภาพย่อภายในขอบเขตการแสดงผลของรูปร่าง โดยคำนึงถึงเอฟเฟกต์ทั้งหมดของรูปร่าง ภาพย่อที่สร้างจะถูกจำกัดโดยขอบเขตของสไลด์

เพื่อสร้างภาพย่อของรูปร่างสไลด์ใด ๆ ภายในขอบเขตการแสดงผลของมัน:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/)
1. รับสไลด์โดยใช้ ID หรือดัชนี
1. รับรูปร่างเป้าหมายบนสไลด์นั้น
1. เรนเดอร์ภาพย่อของรูปร่างด้วยขอบเขตที่ระบุ
1. บันทึกภาพย่อในรูปแบบภาพที่ต้องการ

```py
import aspose.slides as slides

image_bounds = slides.ShapeThumbnailBounds.APPEARANCE

# สร้างอินสแตนซ์ของคลาส Presentation เพื่อเปิดไฟล์งานนำเสนอ.
with slides.Presentation("hello_world.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]

    # สร้างภาพของรูปร่างโดยใช้ขอบเขตการแสดงผล.
    with shape.get_image(image_bounds, 1.0, 1.0) as thumbnail:
        # บันทึกภาพลงดิสก์ในรูปแบบ PNG.
        thumbnail.save("apperance_bounds.png", slides.ImageFormat.PNG)
```

## **คำถามที่พบบ่อย**

**รูปแบบภาพใดบ้างที่สามารถใช้เมื่อบันทึกภาพย่อของรูปร่าง?**

[PNG, JPEG, BMP, GIF, TIFF](https://reference.aspose.com/slides/th/python-net/aspose.slides/imageformat/), และอื่น ๆ รูปร่างยังสามารถ [ส่งออกเป็นเวกเตอร์ SVG](https://reference.aspose.com/slides/th/python-net/aspose.slides/shape/write_as_svg/) โดยบันทึกเนื้อหารูปร่างเป็น SVG

**ความแตกต่างระหว่างขอบเขต SHAPE และ APPEARANCE เมื่อเรนเดอร์ภาพย่อคืออะไร?**

`SHAPE` ใช้เรขาคณิตของรูปร่าง; `APPEARANCE` คิดถึง [visual effects](/slides/th/python-net/shape-effect/) (เงา, แสงเรืองแสง ฯลฯ) ด้วย

**จะเกิดอะไรขึ้นหากรูปร่างถูกทำเครื่องหมายว่าเป็นซ่อน? จะยังคงเรนเดอร์เป็นภาพย่อหรือไม่?**

รูปร่างที่ซ่อนอยู่ยังคงเป็นส่วนหนึ่งของโมเดลและสามารถเรนเดอร์ได้; ธงซ่อนมีผลต่อการแสดงสไลด์โชว์แต่ไม่ได้ป้องกันการสร้างภาพของรูปร่าง

**รูปกลุ่ม, แผนภูมิ, SmartArt และวัตถุซับซ้อนอื่น ๆ รองรับหรือไม่?**

ใช่. วัตถุใด ๆ ที่แสดงเป็น [Shape](https://reference.aspose.com/slides/th/python-net/aspose.slides/shape/) (รวมถึง [GroupShape](https://reference.aspose.com/slides/th/python-net/aspose.slides/groupshape/), [Chart](https://reference.aspose.com/slides/th/python-net/aspose.slides.charts/chart/), และ [SmartArt](https://reference.aspose.com/slides/th/python-net/aspose.slides.smartart/smartart/)) สามารถบันทึกเป็นภาพย่อหรือเป็น SVG ได้

**ฟอนต์ที่ติดตั้งในระบบมีผลต่อคุณภาพของภาพย่อสำหรับรูปร่างข้อความหรือไม่?**

ใช่. คุณควร [provide the required fonts](/slides/th/python-net/custom-font/) (หรือ [configure font substitutions](/slides/th/python-net/font-substitution/)) เพื่อหลีกเลี่ยงการ fallback ที่ไม่ต้องการและการไหลของข้อความ