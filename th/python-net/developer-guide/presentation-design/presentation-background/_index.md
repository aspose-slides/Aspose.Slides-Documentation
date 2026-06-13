---
title: จัดการพื้นหลังการนำเสนอใน Python
linktitle: พื้นหลังสไลด์
type: docs
weight: 20
url: /th/python-net/presentation-background/
keywords:
- พื้นหลังการนำเสนอ
- พื้นหลังสไลด์
- สีทึบ
- สีไล่ระดับ
- พื้นหลังรูปภาพ
- ความโปร่งใสของพื้นหลัง
- คุณสมบัติของพื้นหลัง
- PowerPoint
- OpenDocument
- การนำเสนอ
- Python
- Aspose.Slides
description: "เรียนรู้วิธีการตั้งค่าพื้นหลังแบบไดนามิกในไฟล์ PowerPoint และ OpenDocument ด้วย Aspose.Slides สำหรับ Python ผ่าน .NET พร้อมเคล็ดลับโค้ดเพื่อยกระดับการนำเสนอของคุณ."
---
## **บทนำ**

สีทึบ, การไล่สี, และรูปภาพมักใช้เป็นพื้นหลังของสไลด์ คุณสามารถตั้งค่าพื้นหลังสำหรับ **สไลด์ปกติ** (สไลด์เดี่ยว) หรือ **สไลด์แม่** (ใช้กับหลายสไลด์พร้อมกัน)

![พื้นหลัง PowerPoint](powerpoint-background.png)

## **ตั้งค่าพื้นหลังสีทึบสำหรับสไลด์ปกติ**

Aspose.Slides ให้คุณตั้งค่าสีทึบเป็นพื้นหลังสำหรับสไลด์เฉพาะในงานนำเสนอ — แม้ว่างานนำเสนอจะใช้สไลด์แม่ การเปลี่ยนแปลงจะใช้เฉพาะกับสไลด์ที่เลือกเท่านั้น

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/) .
2. ตั้งค่า [BackgroundType](https://reference.aspose.com/slides/th/python-net/aspose.slides/backgroundtype/) ของสไลด์เป็น `OWN_BACKGROUND` .
3. ตั้งค่า [FillType](https://reference.aspose.com/slides/th/python-net/aspose.slides/filltype/) ของพื้นหลังสไลด์เป็น `SOLID` .
4. ใช้ property `solid_fill_color` บน [FillFormat](https://reference.aspose.com/slides/th/python-net/aspose.slides/fillformat/) เพื่อระบุสีพื้นหลังทึบ .
5. บันทึกงานนำเสนอที่แก้ไขแล้ว .

ตัวอย่าง Python ด้านล่างแสดงวิธีตั้งค่าสีทึบสีฟ้าเป็นพื้นหลังสำหรับสไลด์ปกติ:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

# สร้างอินสแตนซ์ของคลาส Presentation.
with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # ตั้งค่าสีพื้นหลังของสไลด์เป็นสีฟ้า.
    slide.background.type = slides.BackgroundType.OWN_BACKGROUND
    slide.background.fill_format.fill_type = slides.FillType.SOLID
    slide.background.fill_format.solid_fill_color.color = draw.Color.blue

    # บันทึกการนำเสนอไปยังดิสก์.
    presentation.save("SolidColorBackground.pptx", slides.export.SaveFormat.PPTX)
```

## **ตั้งค่าพื้นหลังสีทึบสำหรับสไลด์แม่**

Aspose.Slides ให้คุณตั้งค่าสีทึบเป็นพื้นหลังสำหรับสไลด์แม่ในงานนำเสนอ สไลด์แม่ทำหน้าที่เป็นแม่แบบที่ควบคุมการจัดรูปแบบสำหรับสไลด์ทั้งหมด ดังนั้นเมื่อคุณเลือกสีทึบเป็นพื้นหลังของสไลด์แม่ มันจะใช้กับทุกสไลด์

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/) .
2. ตั้งค่า [BackgroundType](https://reference.aspose.com/slides/th/python-net/aspose.slides/backgroundtype/) ของสไลด์แม่ (ผ่าน `masters`) เป็น `OWN_BACKGROUND` .
3. ตั้งค่า [FillType](https://reference.aspose.com/slides/th/python-net/aspose.slides/filltype/) ของพื้นหลังสไลด์แม่เป็น `SOLID` .
4. ใช้ property `solid_fill_color` บน [FillFormat](https://reference.aspose.com/slides/th/python-net/aspose.slides/fillformat/) เพื่อระบุสีพื้นหลังทึบ .
5. บันทึกงานนำเสนอที่แก้ไขแล้ว .

ตัวอย่าง Python ด้านล่างแสดงวิธีตั้งค่าสีทึบ (สีเขียวป่า) เป็นพื้นหลังสำหรับสไลด์แม่:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

# สร้างอินสแตนซ์ของคลาส Presentation.
with slides.Presentation() as presentation:
    master_slide = presentation.masters[0]

    # ตั้งค่าสีพื้นหลังสำหรับสไลด์แม่เป็นสีเขียวป่า.
    master_slide.background.type = slides.BackgroundType.OWN_BACKGROUND
    master_slide.background.fill_format.fill_type = slides.FillType.SOLID
    master_slide.background.fill_format.solid_fill_color.color = draw.Color.forest_green

    # บันทึกการนำเสนอไปยังดิสก์.
    presentation.save("MasterSlideBackground.pptx", slides.export.SaveFormat.PPTX)
```

## **ตั้งค่าพื้นหลังไล่สีสำหรับสไลด์**

ไล่สีเป็นเอฟเฟกต์กราฟิกที่สร้างจากการเปลี่ยนแปลงสีอย่างค่อยเป็นค่อยไป เมื่อใช้เป็นพื้นหลังสไลด์ ไล่สีสามารถทำให้งานนำเสนอดูศิลป์และเป็นมืออาชีพมากขึ้น Aspose.Slides ให้คุณตั้งค่าสีไล่สีเป็นพื้นหลังสำหรับสไลด์

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/) .
2. ตั้งค่า [BackgroundType](https://reference.aspose.com/slides/th/python-net/aspose.slides/backgroundtype/) ของสไลด์เป็น `OWN_BACKGROUND` .
3. ตั้งค่า [FillType](https://reference.aspose.com/slides/th/python-net/aspose.slides/filltype/) ของพื้นหลังสไลด์เป็น `GRADIENT` .
4. ใช้ property `gradient_format` บน [FillFormat](https://reference.aspose.com/slides/th/python-net/aspose.slides/fillformat/) เพื่อกำหนดการตั้งค่าไล่สีตามที่ต้องการ .
5. บันทึกงานนำเสนอที่แก้ไขแล้ว .

ตัวอย่าง Python ด้านล่างแสดงวิธีตั้งค่าสีไล่สีเป็นพื้นหลังสำหรับสไลด์:

```python
import aspose.slides as slides

# สร้างอินสแตนซ์ของคลาส Presentation.
with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # ใช้เอฟเฟกต์ไล่สีบนพื้นหลัง.
    slide.background.type = slides.BackgroundType.OWN_BACKGROUND
    slide.background.fill_format.fill_type = slides.FillType.GRADIENT
    slide.background.fill_format.gradient_format.tile_flip = slides.TileFlip.FLIP_BOTH

    # บันทึกการนำเสนอไปยังดิสก์.
    presentation.save("GradientBackground.pptx", slides.export.SaveFormat.PPTX)
```

## **ตั้งรูปภาพเป็นพื้นหลังสไลด์**

นอกจากการเติมสีทึบและไล่สีแล้ว Aspose.Slides ยังให้คุณใช้รูปภาพเป็นพื้นหลังสไลด์ได้

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/) .
2. ตั้งค่า [BackgroundType](https://reference.aspose.com/slides/th/python-net/aspose.slides/backgroundtype/) ของสไลด์เป็น `OWN_BACKGROUND` .
3. ตั้งค่า [FillType](https://reference.aspose.com/slides/th/python-net/aspose.slides/filltype/) ของพื้นหลังสไลด์เป็น `PICTURE` .
4. โหลดรูปภาพที่คุณต้องการใช้เป็นพื้นหลังสไลด์ .
5. เพิ่มรูปภาพไปยังคอลเลกชันรูปภาพของงานนำเสนอ .
6. ใช้ property `picture_fill_format` บน [FillFormat](https://reference.aspose.com/slides/th/python-net/aspose.slides/fillformat/) เพื่อกำหนดรูปภาพเป็นพื้นหลัง .
7. บันทึกงานนำเสนอที่แก้ไขแล้ว .

ตัวอย่าง Python ด้านล่างแสดงวิธีตั้งรูปภาพเป็นพื้นหลังสำหรับสไลด์:

```python
import aspose.slides as slides

# สร้างอินสแตนซ์ของคลาส Presentation.
with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # ตั้งค่าคุณสมบัติของภาพพื้นหลัง.
    slide.background.type = slides.BackgroundType.OWN_BACKGROUND
    slide.background.fill_format.fill_type = slides.FillType.PICTURE
    slide.background.fill_format.picture_fill_format.picture_fill_mode = slides.PictureFillMode.STRETCH

    # โหลดภาพ.
    with slides.Images.from_file("Tulips.jpg") as image:
        # เพิ่มภาพไปยังคอลเลกชันของภาพในงานนำเสนอ.
        pp_image = presentation.images.add_image(image)

    slide.background.fill_format.picture_fill_format.picture.image = pp_image

    # บันทึกการนำเสนอไปยังดิสก์.
    presentation.save("ImageAsBackground.pptx", slides.export.SaveFormat.PPTX)
```

ตัวอย่างโค้ดด้านล่างแสดงวิธีตั้งค่าชนิดการเติมพื้นหลังเป็นภาพแบบต่อกระเบื้องและแก้ไขคุณสมบัติการต่อกระเบื้อง:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:

    first_slide = presentation.slides[0]

    background = first_slide.background

    background.type = slides.BackgroundType.OWN_BACKGROUND
    background.fill_format.fill_type = slides.FillType.PICTURE

    with slides.Images.from_file("image.png") as new_image:
        pp_image = presentation.images.add_image(new_image)

    # ตั้งค่าภาพที่ใช้สำหรับเติมพื้นหลัง.
    back_picture_fill_format = background.fill_format.picture_fill_format
    back_picture_fill_format.picture.image = pp_image

    # ตั้งค่าโหมดการเติมภาพเป็นแบบต่อกระเบื้องและปรับคุณสมบัติกระเบื้อง.
    back_picture_fill_format.picture_fill_mode = slides.PictureFillMode.TILE
    back_picture_fill_format.tile_offset_x = 15.0
    back_picture_fill_format.tile_offset_y = 15.0
    back_picture_fill_format.tile_scale_x = 46.0
    back_picture_fill_format.tile_scale_y = 87.0
    back_picture_fill_format.tile_alignment = slides.RectangleAlignment.CENTER
    back_picture_fill_format.tile_flip = slides.TileFlip.FLIP_Y

    presentation.save("TileBackground.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert color="primary" %}}
อ่านเพิ่มเติม: [**ภาพต่อกระเบื้องเป็นพื้นผิว**](/slides/th/python-net/shape-formatting/#tile-picture-as-texture).
{{% /alert %}}

### **เปลี่ยนความโปร่งใสของภาพพื้นหลัง**

คุณอาจต้องการปรับความโปร่งใสของภาพพื้นหลังสไลด์เพื่อให้เนื้อหาของสไลด์โดดเด่นขึ้น โค้ด Python ด้านล่างจะแสดงวิธีเปลี่ยนความโปร่งใสของภาพพื้นหลังสไลด์:

```python
transparency_value = 30  # ตัวอย่างเช่น.

# รับคอลเลกชันของการดำเนินการแปลงรูปภาพ.
image_transform = slide.background.fill_format.picture_fill_format.picture.image_transform

transparency_operation = None

# ค้นหาผลกระทบความโปร่งใสที่กำหนดเป็นเปอร์เซ็นต์คงที่ที่มีอยู่.
for operation in image_transform:
    if type(operation) is slides.AlphaModulateFixed:
        transparency_operation = operation
        break

# ตั้งค่าค่าความโปร่งใสใหม่.
if transparency_operation is None:
    image_transform.add_alpha_modulate_fixed_effect(100 - transparency_value)
else:
    transparency_operation.amount = 100 - transparency_value
```

## **รับค่าพื้นหลังสไลด์**

Aspose.Slides มีคลาส [IBackgroundEffectiveData](https://reference.aspose.com/slides/th/python-net/aspose.slides/ibackgroundeffectivedata/) สำหรับการดึงค่าพื้นหลังที่มีผลของสไลด์ คลาสนี้ให้ข้อมูล [FillFormat](https://reference.aspose.com/slides/th/python-net/aspose.slides/fillformat/) และ [EffectFormat](https://reference.aspose.com/slides/th/python-net/aspose.slides/effectformat/) ที่มีผล

โดยใช้ property `background` ของคลาส [BaseSlide](https://reference.aspose.com/slides/th/python-net/aspose.slides/baseslide/) คุณสามารถรับพื้นหลังที่มีผลของสไลด์ได้

ตัวอย่าง Python ด้านล่างแสดงวิธีรับค่าพื้นหลังที่มีผลของสไลด์:

```python
import aspose.slides as slides

# สร้างอินสแตนซ์ของคลาส Presentation.
with slides.Presentation("Sample.pptx") as presentation:
    slide = presentation.slides[0]

    # ดึงพื้นหลังที่มีผลโดยคำนึงถึงสไลด์แม่, เลย์เอาต์, และธีม.
    effective_background = slide.background.get_effective()

    if effective_background.fill_format.fill_type == slides.FillType.SOLID:
        color = effective_background.fill_format.solid_fill_color
        print(f"Fill color: Color [A={color.a}, R={color.r}, G={color.g}, B={color.b}]")
    else:
        print("Fill type:", str(effective_background.fill_format.fill_type))
```

## **คำถามที่พบบ่อย**

**ฉันสามารถรีเซ็ตพื้นหลังที่กำหนดเองและคืนค่าเป็นพื้นหลังของธีม/เลย์เอาต์ได้หรือไม่?**

ใช่. ลบการเติมสีที่กำหนดเองของสไลด์ แล้วพื้นหลังจะถูกสืบทอดใหม่จากสไลด์ [layout](/slides/th/python-net/slide-layout/)/[master](/slides/th/python-net/slide-master/) ที่สอดคล้องกัน (คือ [theme background](/slides/th/python-net/presentation-theme/)).

**จะเกิดอะไรขึ้นกับพื้นหลังหากฉันเปลี่ยนธีมของงานนำเสนอในภายหลัง?**

ถ้าสไลด์มีการเติมสีของตัวเอง มันจะคงเดิมอยู่ หากพื้นหลังถูกสืบทอดจาก [layout](/slides/th/python-net/slide-layout/)/[master](/slides/th/python-net/slide-master/) มันจะอัปเดตให้ตรงกับ [ธีมใหม่](/slides/th/python-net/presentation-theme/).