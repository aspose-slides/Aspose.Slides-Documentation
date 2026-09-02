---
title: สร้างภาพตัวอย่างขนาดย่อของรูปร่างในพรีเซนเทชันด้วย Python
linktitle: ภาพตัวอย่างของรูปร่าง
type: docs
weight: 70
url: /th/python-net/create-shape-thumbnails/
keywords:
- ภาพตัวอย่างของรูปร่าง
- ภาพของรูปร่าง
- เรนเดอร์รูปร่าง
- การเรนเดอร์รูปร่าง
- ขอบเขตการแสดงผล
- ขอบเขตของรูปร่าง
- PowerPoint
- การนำเสนอ
- Python
- Aspose.Slides
description: "สร้างภาพตัวอย่างขนาดย่อของรูปร่างคุณภาพสูงจากสไลด์ PowerPoint และ OpenDocument ด้วย Aspose.Slides for Python via .NET – สร้างและส่งออกรูปตัวอย่างพรีเซนเทชันได้อย่างง่ายดาย."
---
## **บทนำ**

Aspose.Slides for Python via .NET ถูกใช้เพื่อสร้างไฟล์พรีเซนเทชันที่แต่ละหน้าเป็นสไลด์ คุณสามารถดูสไลด์เหล่านี้ใน Microsoft PowerPoint โดยการเปิดไฟล์พรีเซนเทชัน อย่างไรก็ตามนักพัฒนาอาจต้องการดูภาพของรูปร่างแยกจากกันในโปรแกรมดูภาพ ในกรณีเช่นนี้ Aspose.Slides สามารถสร้างภาพตัวอย่างขนาดย่อสำหรับรูปร่างในสไลด์ได้ บทความนี้อธิบายวิธีใช้ฟีเจอร์นี้

## **สร้างภาพตัวอย่างของรูปร่างจากสไลด์**

เมื่อคุณต้องการดูตัวอย่างของออบเจ็กต์เฉพาะแทนสไลด์ทั้งหมด คุณสามารถเรนเดอร์ภาพตัวอย่างขนาดย่อสำหรับรูปร่างแต่ละชิ้นได้ Aspose.Slides ให้คุณส่งออกรูปร่างใด  ๆ เป็นภาพ ทำให้สะดวกในการสร้างตัวอย่างเบา ๆ ไอคอน หรือทรัพยากรสำหรับการประมวลผลต่อเนื่อง

เพื่อสร้างภาพตัวอย่างจากรูปร่างใด  ๆ:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/)  
2. รับอ้างอิงไปยังสไลด์โดยใช้ ID หรือดัชนี  
3. รับอ้างอิงไปยังรูปร่างบนสไลด์นั้น  
4. เรนเดอร์ภาพตัวอย่างขนาดย่อของรูปร่าง  
5. บันทึกภาพตัวอย่างขนาดย่อในรูปแบบที่ต้องการ  

ตัวอย่างด้านล่างสร้างภาพตัวอย่างของรูปร่าง

```py
import aspose.slides as slides

# สร้างอินสแตนซ์ของคลาส Presentation เพื่อเปิดไฟล์พรีเซนเทชัน.
with slides.Presentation("hello_world.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]
    
    # สร้างภาพด้วยสเกลเริ่มต้น.
    with shape.get_image() as thumbnail:
        # บันทึกภาพลงดิสก์ในรูปแบบ PNG.
        thumbnail.save("shape_thumbnail.png", slides.ImageFormat.PNG)
```

## **สร้างภาพตัวอย่างด้วยอัตราสเกลที่กำหนดเอง**

ส่วนนี้แสดงวิธีสร้างภาพตัวอย่างของรูปร่างโดยใช้อัตราสเกลที่กำหนดโดยผู้ใช้ใน Aspose.Slides โดยการควบคุมสเกล คุณสามารถปรับขนาดภาพตัวอย่างให้เหมาะกับการดูตัวอย่าง การส่งออก หรือการแสดงผลบนจอแบบ DPI สูง

เพื่อสร้างภาพตัวอย่างสำหรับรูปร่างใด  ๆ บนสไลด์:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/)  
2. รับสไลด์โดยใช้ ID หรือดัชนี  
3. รับรูปร่างเป้าหมายบนสไลด์นั้น  
4. เรนเดอร์ภาพตัวอย่างขนาดย่อของรูปร่างด้วยสเกลที่ระบุ  
5. บันทึกภาพตัวอย่างขนาดย่อในรูปแบบที่ต้องการ  

ตัวอย่างด้านล่างสร้างภาพตัวอย่างด้วยอัตราสเกลที่กำหนดเอง

```py
import aspose.slides as slides

scale_x = 2.0
scale_y = scale_x

# สร้างอินสแตนซ์ของคลาส Presentation เพื่อเปิดไฟล์พรีเซนเทชัน.
with slides.Presentation("hello_world.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]
    
    # สร้างภาพด้วยสเกลที่กำหนด.
    with shape.get_image(slides.ShapeThumbnailBounds.SHAPE, scale_x, scale_y) as thumbnail:
        # บันทึกภาพลงดิสก์ในรูปแบบ PNG.
        thumbnail.save("scaling_factor.png", slides.ImageFormat.PNG)
```

## **สร้างภาพตัวอย่างโดยใช้ขอบเขตการแสดงผลของรูปร่าง**

ส่วนนี้แสดงวิธีสร้างภาพตัวอย่างภายในขอบเขตการแสดงผลของรูปร่าง โดยคำนึงถึงเอฟเฟกต์ทั้งหมดของรูปร่าง ภาพตัวอย่างที่สร้างจะถูกจำกัดโดยขอบเขตของสไลด์

เพื่อสร้างภาพตัวอย่างของรูปร่างใด  ๆ บนสไลด์ภายในขอบเขตการแสดงผลของมัน:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/)  
2. รับสไลด์โดยใช้ ID หรือดัชนี  
3. รับรูปร่างเป้าหมายบนสไลด์นั้น  
4. เรนเดอร์ภาพตัวอย่างขนาดย่อของรูปร่างด้วยขอบเขตที่ระบุ  
5. บันทึกภาพตัวอย่างขนาดย่อในรูปแบบภาพที่ต้องการ  

ตัวอย่างด้านล่างสร้างภาพตัวอย่างด้วยขอบเขตที่กำหนดเอง

```py
import aspose.slides as slides

image_bounds = slides.ShapeThumbnailBounds.APPEARANCE

# สร้างอินสแตนซ์ของคลาส Presentation เพื่อเปิดไฟล์พรีเซนเทชัน.
with slides.Presentation("hello_world.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]

    # สร้างภาพรูปร่างโดยใช้ขอบเขตการแสดงผล.
    with shape.get_image(image_bounds, 1.0, 1.0) as thumbnail:
        # บันทึกภาพลงดิสก์ในรูปแบบ PNG.
        thumbnail.save("apperance_bounds.png", slides.ImageFormat.PNG)
```

## **รับขอบเขตการแสดงผลจริงของรูปร่าง**

คุณสมบัติกรอบของ [Shape](https://reference.aspose.com/slides/th/python-net/aspose.slides/shape/) — `Shape.x`, `Shape.y`, `Shape.width`, และ `Shape.height` — อธิบายสี่เหลี่ยมที่เก็บไว้ในโมเดลพรีเซนเทชัน เนื้อหาที่ถูกเรนเดอร์จริงอาจขยายเกินกรอบนั้นหรืออยู่ในสี่เหลี่ยมที่จัดแนวตามแกนที่ต่างออกไป การหมุน, โครงร่าง, ปลายลูกศร, การจัดวางข้อความและการล้น, รูปทรง SmartArt ที่สร้างขึ้น, และเอฟเฟกต์การเรนเดอร์อื่น ๆ สามารถเปลี่ยนพื้นที่ที่ครอบครองได้

ใช้ [Shape.get_visual_bounds](https://reference.aspose.com/slides/th/python-net/aspose.slides/shape/get_visual_bounds/) เพื่อคำนวณพื้นที่ที่ครอบครองโดยไม่ต้องสร้างภาพ วิธีนี้จะคืนสี่เหลี่ยมแบบ floating-point ในพิกัดสไลด์ สี่เหลี่ยมที่คืนค่าไม่ได้ถูกคลิปให้เข้ากับสไลด์ ดังนั้นพิกัดของมันอาจเป็นค่าลบเมื่อเนื้อหาขยายเกินจุดเริ่มต้นของสไลด์

ตัวอย่างต่อไปนี้รับและเปรียบเทียบกรอบและขอบเขตการแสดงผล:

```py
import aspose.pydrawing as drawing
import aspose.slides as slides

with slides.Presentation("example.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]

    visual_bounds = shape.get_visual_bounds()

    frame_values = (shape.x, shape.y, shape.width, shape.height)
    visual_values = (visual_bounds.x, visual_bounds.y, visual_bounds.width, visual_bounds.height)

    print(f"Frame bounds (x, y, width, height): {frame_values}")
    print(f"Visual bounds (x, y, width, height): {visual_values}")
```

สี่เหลี่ยมเดียวกันสามารถใช้เพื่อจัดตำแหน่งรูปร่างที่อยู่ใกล้เคียงให้สอดคล้องกับขอบ `left`, `right`, `top` หรือ `bottom` ของมัน; จองพื้นที่พอเพียงในเลย์เอาต์ที่สร้างขึ้น; หรือตรวจจับเนื้อหานอกพื้นที่ที่อนุญาต ขอบเขตการแสดงผลมีประโยชน์โดยเฉพาะสำหรับ SmartArt, กล่องข้อความ, ลูกศร, รูปภาพ, รูปร่างที่หมุน, และกลุ่มรูปร่าง ซึ่งกรอบที่เก็บไว้อาจไม่สอดคล้องกับผลลัพธ์ที่เรนเดอร์เต็มรูปแบบ

ใช้ [Shape.get_visual_bounds](https://reference.aspose.com/slides/th/python-net/aspose.slides/shape/get_visual_bounds/) เมื่อคุณต้องการพิกัดสำหรับการจัดเลย์เอาต์หรือการตรวจสอบและไม่ต้องการบิทแมพ ใช้ [Shape.get_image](https://reference.aspose.com/slides/th/python-net/aspose.slides/shape/get_image/) เมื่อคุณต้องการเรนเดอร์รูปร่าง ด้วย [ShapeThumbnailBounds](https://reference.aspose.com/slides/th/python-net/aspose.slides/shapethumbnailbounds/) `ShapeThumbnailBounds.SHAPE` กำหนดขนาดภาพจากกรอบของรูปร่างรวมถึงการตั้งค่าโครงร่าง ในขณะที่ `ShapeThumbnailBounds.APPEARANCE` กำหนดขนาดจากการแสดงผลของรูปร่างและจำกัดผลลัพธ์ให้อยู่ในขอบเขตของสไลด์ ตรงกันข้าม `Shape.get_visual_bounds` จะคืนสี่เหลี่ยมที่คำนวณเท่านั้นและจะไม่คลิปให้เข้ากับสไลด์

## **คำถามที่พบบ่อย**

**รูปแบบภาพใดที่สามารถใช้เมื่อบันทึกภาพตัวอย่างของรูปร่าง?**

[PNG, JPEG, BMP, GIF, TIFF](https://reference.aspose.com/slides/th/python-net/aspose.slides/imageformat/), และอื่น ๆ รูปร่างยังสามารถ [ส่งออกเป็น SVG เวกเตอร์](https://reference.aspose.com/slides/th/python-net/aspose.slides/shape/write_as_svg/) โดยการบันทึกเนื้อหารูปร่างเป็น SVG

**ความแตกต่างระหว่างขอบเขต SHAPE และ APPEARANCE เมื่อเรนเดอร์ภาพตัวอย่างคืออะไร?**

`SHAPE` ใช้รูปทรงของรูปร่าง; `APPEARANCE` พิจารณา [visual effects](/slides/th/python-net/shape-effect/) (เงา, ปล่อยแสง, ฯลฯ) เข้าไปด้วย

**ถ้ารูปร่างถูกทำเครื่องหมายว่าเป็น hidden จะเกิดอะไรขึ้น? มันยังจะเรนเดอร์เป็นภาพตัวอย่างหรือไม่?**

รูปร่างที่ถูกซ่อนยังคงเป็นส่วนหนึ่งของโมเดลและสามารถเรนเดอร์ได้; ธง hidden มีผลต่อการแสดงสไลด์โชว์แต่ไม่ได้ป้องกันการสร้างภาพของรูปร่าง

**รูปร่างกลุ่ม, แผนภูมิ, SmartArt, และวัตถุซับซ้อนอื่น ๆ รองรับหรือไม่?**

ใช่ วัตถุใด  ๆ ที่แสดงเป็น [Shape](https://reference.aspose.com/slides/th/python-net/aspose.slides/shape/) (รวมถึง [GroupShape](https://reference.aspose.com/slides/th/python-net/aspose.slides/groupshape/), [Chart](https://reference.aspose.com/slides/th/python-net/aspose.slides.charts/chart/), และ [SmartArt](https://reference.aspose.com/slides/th/python-net/aspose.slides.smartart/smartart/)) สามารถบันทึกเป็นภาพตัวอย่างหรือเป็น SVG ได้

**ฟอนต์ที่ติดตั้งในระบบมีผลต่อคุณภาพของภาพตัวอย่างสำหรับรูปร่างข้อความหรือไม่?**

ใช่ คุณควร [ให้บริการฟอนต์ที่จำเป็น](/slides/th/python-net/custom-font/) (หรือ [กำหนดค่าการทดแทนฟอนต์](/slides/th/python-net/font-substitution/)) เพื่อหลีกเลี่ยงการ fallback ที่ไม่ต้องการและการจัดเรียงข้อความใหม่