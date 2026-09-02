---
title: จัดการเอฟเฟกต์การแปลงภาพในงานนำเสนอด้วย Python
linktitle: เอฟเฟกต์การแปลงภาพ
type: docs
weight: 11
url: /th/python-net/image-transform-effects/
keywords:
- การแปลงภาพ
- เอฟเฟกต์รูปภาพ
- ความสว่าง
- ความคอนทราสต์
- ระดับสีเทา
- โทนคู่
- สีทินท์
- HSL
- การแทนสี
- เบลอ
- ความโปร่งใส
- เอฟเฟกต์อัลฟ่า
- โซ่เอฟเฟกต์
- PowerPoint
- งานนำเสนอ
- Python
- Aspose.Slides
description: "ใช้, สร้างโซ่, ตรวจสอบ, ลบ, และตรวจสอบความถูกต้องของเอฟเฟกต์การแปลงภาพสำหรับกรอบรูปด้วย Aspose.Slides สำหรับ Python ผ่าน .NET."
---
## **ภาพรวม**

Aspose.Slides แสดงการปรับภาพเป็นคอลเลกชันที่เรียงลำดับของการดำเนินงานแปลงรูปภาพ สำหรับกรอบภาพ ให้เริ่มจาก [Picture](https://reference.aspose.com/slides/th/python-net/aspose.slides/picture/) ของกรอบและเข้าถึงคุณสมบัติ [image_transform](https://reference.aspose.com/slides/th/python-net/aspose.slides/picture/image_transform/) ผลลัพธ์ที่คืนค่าคือ [ImageTransformOperationCollection](https://reference.aspose.com/slides/th/python-net/aspose.slides.effects/imagetransformoperationcollection/) ที่ให้คุณเพิ่ม ลิสต์ ตรวจสอบ ลบ และล้างเอฟเฟกต์โดยไม่ต้องเขียนใหม่ไบต์ของรูปภาพต้นฉบับ

บทความนี้สาธิตกระบวนการทำงานครบวงจรสำหรับความสว่างและคอนทราสต์ การแปลงสี การเบลอ ความโปร่งใส โซ่เอฟเฟกต์ที่เรียงลำดับ ค่าที่มีผลจริง การลบ และการตรวจสอบรอบไป‑กลับของ PPTX

## **ทำความเข้าใจการเป็นเจ้าของเอฟเฟกต์และการใช้ซ้ำของภาพ**

ทรัพยากรภาพและรูปภาพที่แสดงมันเป็นออบเจ็กต์ที่ต่างกัน:

- [PPImage](https://reference.aspose.com/slides/th/python-net/aspose.slides/ppimage/) เก็บหรืออ้างอิงข้อมูลภาพต้นฉบับที่เป็นของพรีเซนเทชัน
- [Picture](https://reference.aspose.com/slides/th/python-net/aspose.slides/picture/) เกิดจากการเติมภาพและอ้างอิงทรัพยากรภาพพร้อมเก็บคอลเลกชันการแปลงรูปภาพ
- [PictureFrame](https://reference.aspose.com/slides/th/python-net/aspose.slides/pictureframe/) คือรูปร่างสไลด์ที่เป็นเจ้าของการเติมภาพที่เกี่ยวข้อง, รูปร่าง, การตัด, และการจัดรูปแบบระดับกรอบอื่น ๆ

ดังนั้นการดำเนินงานแปลงรูปภาพจะไม่แก้ไขไบต์ใน [PPImage](https://reference.aspose.com/slides/th/python-net/aspose.slides/ppimage/) เมื่อนำ `PPImage` เดียวกันส่งไปยัง [ShapeCollection.add_picture_frame](https://reference.aspose.com/slides/th/python-net/aspose.slides/shapecollection/add_picture_frame/) มากกว่าหนึ่งครั้ง แต่ละกรอบภาพใหม่จะได้รับ `Picture` ของตนเองและคอลเลกชันการแปลงของตนเอง การนำเอฟเฟกต์ระดับสีเทาไปใช้กับกรอบหนึ่งจะไม่ทำให้กรอบอื่นเป็นระดับสีเทาแม้ว่าแต่ละกรอบจะใช้ทรัพยากรภาพที่ฝังรวมเดียวกัน

โมเดล `Picture.image_transform` นี้ยังใช้ในการเติมภาพอื่น ๆ เช่น รูปร่างหรือพื้นหลังสไลด์ ตัวอย่างต่อไปนี้มุ่งเน้นที่กรอบภาพ

## **ใช้ช่วงพารามิเตอร์และหน่วยที่ถูกต้อง**

วิธีที่สาธิตใช้ช่วงความหมายและหน่วยต่อไปนี้ เก็บค่าภายในช่วงเหล่านี้แม้ว่าเวอร์ชันไลบรารีบางเวอร์ชันอาจไม่ปฏิเสธค่าที่อยู่นอกช่วงโดยทันที; รูปแบบไฟล์เป้าหมายอาจทำการทำให้เป็นมาตรฐาน, ลบ, หรือปฏิเสธข้อมูลที่ไม่ถูกต้องในระหว่างการบันทึกหรือเมื่อ PowerPoint เปิดไฟล์

| การดำเนินการ | พารามิเตอร์ |ช่วงและหน่วยที่ถูกต้อง |
|---|---|---|
| [add_brightness_contrast_effect](https://reference.aspose.com/slides/th/python-net/aspose.slides.effects/imagetransformoperationcollection/add_brightness_contrast_effect/) | `brightness`, `contrast` | `-100` ถึง `100` เปอร์เซ็นต์; `0` ไม่เปลี่ยนส่วนประกอบ |
| [add_gray_scale_effect](https://reference.aspose.com/slides/th/python-net/aspose.slides.effects/imagetransformoperationcollection/add_gray_scale_effect/) | ไม่มี | ไม่มีพารามิเตอร์เชิงตัวเลข อัลฟ่าไม่เปลี่ยน |
| [add_duotone_effect](https://reference.aspose.com/slides/th/python-net/aspose.slides.effects/imagetransformoperationcollection/add_duotone_effect/) | `color1`, `color2` | สองสีสำหรับพิกเซลมืดและสว่าง ช่องสี RGB และอัลฟ่าใช้ค่า `0` ถึง `255` |
| [add_tint_effect](https://reference.aspose.com/slides/th/python-net/aspose.slides.effects/imagetransformoperationcollection/add_tint_effect/) | `hue`, `amount` | Hue อยู่ระหว่าง `0` (รวม) ถึง `360` (ไม่รวม) หน่วยเป็นองศา; amount อยู่ระหว่าง `-100` ถึง `100` เปอร์เซ็นต์ |
| [add_hsl_effect](https://reference.aspose.com/slides/th/python-net/aspose.slides.effects/imagetransformoperationcollection/add_hsl_effect/) | `hue`, `saturation`, `luminance` | Hue อยู่ระหว่าง `0` (รวม) ถึง `360` (ไม่รวม) หน่วยเป็นองศา; saturation และ luminance อยู่ระหว่าง `-100` ถึง `100` เปอร์เซ็นต์ |
| [add_color_replace_effect](https://reference.aspose.com/slides/th/python-net/aspose.slides.effects/imagetransformoperationcollection/add_color_replace_effect/) | `color` | สีทดแทนใช้ค่าในช่อง `0` ถึง `255` ค่าอัลฟ่าเดิมไม่เปลี่ยน |
| [add_blur_effect](https://reference.aspose.com/slides/th/python-net/aspose.slides.effects/imagetransformoperationcollection/add_blur_effect/) | `radius`, `grow` | radius ต้องเป็นจำนวนเต็มบวกหรือศูนย์และวัดเป็น point; `grow` เป็น Boolean ที่กำหนดว่าภาพเบลออาจขยายออกนอกขอบเดิม |
| [add_alpha_modulate_fixed_effect](https://reference.aspose.com/slides/th/python-net/aspose.slides.effects/imagetransformoperationcollection/add_alpha_modulate_fixed_effect/) | `amount` | เปอร์เซ็นต์ที่ไม่เป็นลบ ใช้ `0` ถึง `100` สำหรับสเกลความทึบปกติ: `0` โปร่งใสเต็มและ `100` รักษาอัลฟ่าเดิม |
| [add_alpha_replace_effect](https://reference.aspose.com/slides/th/python-net/aspose.slides.effects/imagetransformoperationcollection/add_alpha_replace_effect/) | `alpha` | `0` ถึง `100` เปอร์เซ็นต์ความทึบ |
| [add_alpha_bi_level_effect](https://reference.aspose.com/slides/th/python-net/aspose.slides.effects/imagetransformoperationcollection/add_alpha_bi_level_effect/) | `threshold` | `0` ถึง `100` เปอร์เซ็นต์เกณฑ์อัลฟ่า ค่าต่ำกว่าจะเป็นโปร่งใส; ค่าสูงกว่าจะเป็นทึบ |

สำหรับการทำโมดูเลตอัลฟ่าแบบคงที่ ความโปร่งใสและความทึบเป็นค่าตรงกันข้าม ตัวอย่างเช่น ความโปร่งใส 35% เทียบกับค่าโมดูเลตอัลฟ่า 65%

## **นำความสว่างและคอนทราสต์ไปใช้**

[ImageTransformOperationCollection.add_brightness_contrast_effect](https://reference.aspose.com/slides/th/python-net/aspose.slides.effects/imagetransformoperationcollection/add_brightness_contrast_effect/) คืนค่าออบเจ็กต์ [BrightnessContrast](https://reference.aspose.com/slides/th/python-net/aspose.slides.effects/brightnesscontrast/) การตั้งค่าสเกลถูกจัดไว้เมื่อสร้างออบเจ็กต์ [BrightnessContrast.get_effective](https://reference.aspose.com/slides/th/python-net/aspose.slides.effects/brightnesscontrast/get_effective/) คืนค่าที่คำนวณแล้วแบบอ่านอย่างเดียว ซึ่งสามารถตรวจสอบหรือบันทึกได้

ตัวอย่างต่อไปนี้เพิ่มความสว่าง 15% และคอนทราสต์ 20% แล้วเรนเดอร์พรีวิวโดยไม่แก้ไขภาพฝังรวม:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    with slides.Images.from_file("photo.png") as source_image:
        image = presentation.images.add_image(source_image)

    picture_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 50, 50, 400, 260, image)
    image_transform = picture_frame.picture_format.picture.image_transform
    brightness_contrast = image_transform.add_brightness_contrast_effect(15, 20)

    effective_values = brightness_contrast.get_effective()
    print("Brightness: " + str(effective_values.brightness) + "%")
    print("Contrast: " + str(effective_values.contrast) + "%")

    with slide.get_image() as preview:
        preview.save("brightness-contrast-preview.png")
```

[BrightnessContrast](https://reference.aspose.com/slides/th/python-net/aspose.slides.effects/brightnesscontrast/) เป็นส่วนขยายนเอฟเฟกต์ภาพของ Office 2010 และพกพาน้อยกว่าการเอฟเฟกต์ luminance ของ DrawingML มาตรฐาน เมื่อความสว่างและคอนทราสต์ต้องการให้แก้ไขได้หลังจากรอบ PPTX ให้ใช้ [ImageTransformOperationCollection.add_luminance_effect](https://reference.aspose.com/slides/th/python-net/aspose.slides.effects/imagetransformoperationcollection/add_luminance_effect/) และตรวจสอบผลลัพธ์หลังจากเปิดไฟล์ใหม่ ส่วนข้อจำกัดของรูปแบบอธิบายความแตกต่างนี้อย่างละเอียดเพิ่มเติม

## **นำการแปลงสีไปใช้**

เอฟเฟกต์สีสามารถนำไปใช้แยกกันกับกรอบภาพต่าง ๆ ที่ใช้ทรัพยากรภาพเดียวกัน ตัวอย่างต่อไปนี้สร้างห้ากรอบและนำเอฟเฟกต์ระดับสีเทา, duotone, tint, ปรับ HSL, และการแทนสีไปใช้

[Duotone](https://reference.aspose.com/slides/th/python-net/aspose.slides.effects/duotone/) มีพารามิเตอร์สีสองตัวที่แก้ไขได้อิสระ: `color1` ใช้สำหรับพิกเซลมืด, `color2` ใช้สำหรับพิกเซลสว่าง ทำให้เป็นตัวอย่างที่ดีของเอฟเฟกต์ที่ตั้งค่าซับซ้อนกว่าค่าสเกลเดียว

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    with slides.Images.from_file("photo.png") as source_image:
        image = presentation.images.add_image(source_image)

    gray_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 20, 20, 180, 120, image)
    gray_frame.picture_format.picture.image_transform.add_gray_scale_effect()

    duotone_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 220, 20, 180, 120, image)
    duotone = duotone_frame.picture_format.picture.image_transform.add_duotone_effect()
    duotone.color1.color = draw.Color.navy
    duotone.color2.color = draw.Color.gold

    tint_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 420, 20, 180, 120, image)
    tint_frame.picture_format.picture.image_transform.add_tint_effect(210, 35)

    hsl_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 120, 170, 180, 120, image)
    hsl_frame.picture_format.picture.image_transform.add_hsl_effect(30, 20, -10)

    replacement_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 320, 170, 180, 120, image)
    color_replacement = replacement_frame.picture_format.picture.image_transform.add_color_replace_effect()
    color_replacement.color.color = draw.Color.cornflower_blue

    presentation.save("color-transformations.pptx", slides.export.SaveFormat.PPTX)
```

[add_color_replace_effect](https://reference.aspose.com/slides/th/python-net/aspose.slides.effects/imagetransformoperationcollection/add_color_replace_effect/) แทนที่สีของทุกพิกเซลด้วยสีคงที่หนึ่งสีในขณะที่คงอัลฟ่าไว้ แตกต่างจาก [add_color_change_effect](https://reference.aspose.com/slides/th/python-net/aspose.slides.effects/imagetransformoperationcollection/add_color_change_effect/) ที่แมปสีต้นฉบับหนึ่งไปยังสีเป้าหมายและเปิดเผยรูปแบบสีของต้นฉบับและเป้าหมาย

## **เพิ่มเอฟเฟกต์เบลอ, ความโปร่งใส, และอัลฟ่า**

[add_blur_effect](https://reference.aspose.com/slides/th/python-net/aspose.slides.effects/imagetransformoperationcollection/add_blur_effect/) มีผลต่อทุกช่องสีรวมอัลฟ่า ตั้งค่า `grow` เป็น `True` เมื่อต้องการให้ขอบเบลอขยายออกนอกขอบรูปภาพเดิม

สำหรับความโปร่งใสแบบสม่ำเสมอ ให้ใช้ [add_alpha_modulate_fixed_effect](https://reference.aspose.com/slides/th/python-net/aspose.slides.effects/imagetransformoperationcollection/add_alpha_modulate_fixed_effect/) ซึ่งคูณค่าที่มีอยู่ของอัลฟ่าแต่ละค่า ทำให้พิกเซลที่เป็นโปร่งใสบางส่วนยังคงแตกต่างอย่างสัดส่วน [add_alpha_replace_effect](https://reference.aspose.com/slides/th/python-net/aspose.slides.effects/imagetransformoperationcollection/add_alpha_replace_effect/) แทนที่อัลฟ่าเดียวกันให้กับทุกพิกเซล [add_alpha_bi_level_effect](https://reference.aspose.com/slides/th/python-net/aspose.slides.effects/imagetransformoperationcollection/add_alpha_bi_level_effect/) แปลงอัลฟ่าเป็นสองระดับตามเกณฑ์

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    with slides.Images.from_file("photo.png") as source_image:
        image = presentation.images.add_image(source_image)

    blurred_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 20, 20, 200, 140, image)
    blur = blurred_frame.picture_format.picture.image_transform.add_blur_effect(4.5, True)
    blur.radius = 5

    transparent_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 240, 20, 200, 140, image)
    alpha_modulate = transparent_frame.picture_format.picture.image_transform.add_alpha_modulate_fixed_effect(65)
    alpha_modulate.amount = 60

    uniform_alpha_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 20, 180, 200, 140, image)
    uniform_alpha_frame.picture_format.picture.image_transform.add_alpha_replace_effect(55)

    binary_alpha_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 240, 180, 200, 140, image)
    alpha_bi_level = binary_alpha_frame.picture_format.picture.image_transform.add_alpha_bi_level_effect(50)
    alpha_bi_level.threshold = 45
    binary_alpha_frame.picture_format.picture.image_transform.add_alpha_inverse_effect()

    presentation.save("blur-and-alpha-effects.pptx", slides.export.SaveFormat.PPTX)
```

เอฟเฟกต์อัลฟ่าอื่น ๆ ที่ไม่มีพารามิเตอร์ ได้แก่ [add_alpha_ceiling_effect](https://reference.aspose.com/slides/th/python-net/aspose.slides.effects/imagetransformoperationcollection/add_alpha_ceiling_effect/) ทำให้ทุกอัลฟ่าไม่เป็นศูนย์กลายเป็นทึบเต็ม; [add_alpha_floor_effect](https://reference.aspose.com/slides/th/python-net/aspose.slides.effects/imagetransformoperationcollection/add_alpha_floor_effect/) ทำให้ทุกอัลฟ่าต่ำกว่า 100% กลายเป็นโปร่งใสเต็ม; และ [add_alpha_inverse_effect](https://reference.aspose.com/slides/th/python-net/aspose.slides.effects/imagetransformoperationcollection/add_alpha_inverse_effect/) พลิกค่าที่เป็น `100% - alpha`

## **สร้างโซ่เอฟเฟกต์ที่เรียงลำดับ**

ทุกเมธอด `add_..._effect` จะต่อออบเจ็กต์ใหม่ที่ตำแหน่งสุดท้ายของคอลเลกชัน ตัวเรนเดอร์ใช้คอลเลกชันเป็นสายงานที่เรียงลำดับ: ผลลัพธ์ของการดำเนินงาน 0 จะเป็นอินพุตของการดำเนินงาน 1 และต่อไป ดังนั้นการจัดลำดับเดียวกันแต่ต่างตำแหน่งอาจทำให้ได้ภาพที่ต่างกัน

เช่น การทำระดับสีเทาก่อน tint จะลบข้อมูลสีก่อนแล้วจึงรีสีผลของ luminance ส่วนการทำ tint ก่อนระดับสีเทาจะลบ tint อีกครั้งเช่นกัน การแทนที่อัลฟ่าอาจเขียนทับค่าที่คำนวณโดยการดำเนินงานก่อนหน้า ส่วนการโมดูเลตอัลฟ่าเก็บความแตกต่างสัมพัทธ์เดิมไว้

ตัวอย่างต่อไปนี้สร้างโซ่สี่การดำเนินงาน บันทึกเป็น PPTX เปิดพรีเซนเทชันใหม่ ตรวจสอบประเภทการดำเนินงานและลำดับของมัน แล้วเรนเดอร์ผลลัพธ์ที่เปิดใหม่:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    with slides.Images.from_file("photo.png") as source_image:
        image = presentation.images.add_image(source_image)

    picture_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 50, 50, 400, 260, image)
    image_transform = picture_frame.picture_format.picture.image_transform
    image_transform.add_gray_scale_effect()
    image_transform.add_tint_effect(220, 25)
    image_transform.add_blur_effect(2.5, False)
    image_transform.add_alpha_modulate_fixed_effect(80)

    presentation.save("image-transform-chain.pptx", slides.export.SaveFormat.PPTX)

with slides.Presentation("image-transform-chain.pptx") as reopened_presentation:
    reopened_shape = reopened_presentation.slides[0].shapes[0]

    if isinstance(reopened_shape, slides.PictureFrame):
        reopened_transform = reopened_shape.picture_format.picture.image_transform
        order_is_preserved = (
            len(reopened_transform) == 4 and
            isinstance(reopened_transform[0], slides.effects.GrayScale) and
            isinstance(reopened_transform[1], slides.effects.Tint) and
            isinstance(reopened_transform[2], slides.effects.Blur) and
            isinstance(reopened_transform[3], slides.effects.AlphaModulateFixed)
        )
        print("The effect chain was preserved." if order_is_preserved else "The effect chain changed during the round trip.")

        with reopened_presentation.slides[0].get_image() as rendered_slide:
            rendered_slide.save("reopened-effect-chain.png")
    else:
        print("The reopened shape is not a picture frame.")
```

คอลเลกชันไม่ได้บังคับใช้เมตริกซ์ความเข้ากันได้ที่แยกเอฟเฟกต์สี, อัลฟ่า, และเบลอออกเป็นโซ่ต่าง ๆ พวกมันสามารถรวมกันได้ แต่การรวมกันไม่จำเป็นต้องมีประโยชน์เสมอ การแทนที่สีคงที่จะลบการแปรผัน RGB ที่สร้างโดยเอฟเฟกต์สีก่อนหน้า; การทำระดับสีเทาหลัง duotone จะลบสีสองสีที่เลือก; และการทำ ceiling, floor, replace หรือ bi‑level ของอัลฟ่าอาจทำให้ข้อมูลอัลฟ่าเดิมหายไป สร้างโซ่ตามลำดับการประมวลผลพิกเซลที่ต้องการ ไม่ใช่พิจารณาเป็นแฟลกการจัดรูปแบบที่ไม่ได้เรียงลำดับ

## **ตรวจสอบค่าที่แก้ไขได้และค่าที่มีผลจริง**

ออบเจ็กต์ที่แก้ไขได้คือออบเจ็กต์ที่เก็บอยู่ใน `Picture.image_transform` ขึ้นอยู่กับเอฟเฟกต์อาจเปิดเผยสมาชิกที่เขียนได้โดยตรง ตัวอย่างเช่น [Blur](https://reference.aspose.com/slides/th/python-net/aspose.slides.effects/blur/) เปิดเผยคุณสมบัติ `radius` และ `grow` ที่เขียนได้, [AlphaModulateFixed](https://reference.aspose.com/slides/th/python-net/aspose.slides.effects/alphamodulatefixed/) เปิดเผยคุณสมบัติ `amount` ที่เขียนได้, และ [AlphaBiLevel](https://reference.aspose.com/slides/th/python-net/aspose.slides.effects/alphabilevel/) เปิดเผยคุณสมบัติ `threshold` ที่เขียนได้ เอฟเฟกต์สีอย่าง [Duotone](https://reference.aspose.com/slides/th/python-net/aspose.slides.effects/duotone/) เปิดเผยออปเจ็กต์ [ColorFormat](https://reference.aspose.com/slides/th/python-net/aspose.slides/colorformat/) ที่แก้ไขได้

บางการดำเนินงาน เช่น [BrightnessContrast](https://reference.aspose.com/slides/th/python-net/aspose.slides.effects/brightnesscontrast/), [HSL](https://reference.aspose.com/slides/th/python-net/aspose.slides.effects/hsl/), [Tint](https://reference.aspose.com/slides/th/python-net/aspose.slides.effects/tint/), และ [AlphaReplace](https://reference.aspose.com/slides/th/python-net/aspose.slides.effects/alphareplace/) ไม่เปิดเผยสเกลการสร้างเป็นคุณสมบัติที่เขียนได้ เพื่อเปลี่ยนการตั้งค่าเหล่านี้ ให้ลบการดำเนินงานและเพิ่มออบเจ็กต์ใหม่ในตำแหน่งที่ต้องการ

ข้อมูลที่มีผลจริงที่คืนโดย `get_effective()` ถูกคำนวณและเป็นแบบอ่าน‑อย่างเดียว มีประโยชน์สำหรับการแก้ไขสีที่อิงตามธีมและอ่านค่าที่ทำให้เป็นมาตรฐานที่เรนเดอร์ใช้ แต่ไม่ใช่พื้นผิวการแก้ไขอีกชั้น ตัวอย่างต่อไปนี้ลิสต์โซ่และตรวจสอบค่าที่มีผลจริงเมื่อ API มีให้:

```python
import aspose.slides as slides

with slides.Presentation("image-transform-chain.pptx") as presentation:
    picture_frame = None

    for shape in presentation.slides[0].shapes:
        if isinstance(shape, slides.PictureFrame):
            picture_frame = shape
            break

    if picture_frame is not None:
        image_transform = picture_frame.picture_format.picture.image_transform

        for index, operation in enumerate(image_transform):
            print(str(index) + ": " + type(operation).__name__)

            if isinstance(operation, slides.effects.BrightnessContrast):
                effect_data = operation.get_effective()
                print("  Brightness: " + str(effect_data.brightness))
                print("  Contrast: " + str(effect_data.contrast))
            elif isinstance(operation, slides.effects.Luminance):
                effect_data = operation.get_effective()
                print("  Brightness: " + str(effect_data.brightness))
                print("  Contrast: " + str(effect_data.contrast))
            elif isinstance(operation, slides.effects.Duotone):
                effect_data = operation.get_effective()
                print("  Dark color: " + str(effect_data.color1))
                print("  Light color: " + str(effect_data.color2))
            elif isinstance(operation, slides.effects.ColorReplace):
                effect_data = operation.get_effective()
                print("  Replacement color: " + str(effect_data.color))
            elif isinstance(operation, slides.effects.HSL):
                effect_data = operation.get_effective()
                print("  HSL: " + str(effect_data.hue) + ", " + str(effect_data.saturation) + ", " + str(effect_data.luminance))
            elif isinstance(operation, slides.effects.Tint):
                effect_data = operation.get_effective()
                print("  Tint: " + str(effect_data.hue) + ", " + str(effect_data.amount))
            elif isinstance(operation, slides.effects.Blur):
                effect_data = operation.get_effective()
                print("  Blur radius: " + str(effect_data.radius) + " pt")
            elif isinstance(operation, slides.effects.AlphaModulateFixed):
                effect_data = operation.get_effective()
                print("  Alpha amount: " + str(effect_data.amount) + "%")
            elif isinstance(operation, slides.effects.AlphaReplace):
                effect_data = operation.get_effective()
                print("  Replacement alpha: " + str(effect_data.alpha) + "%")
            elif isinstance(operation, slides.effects.AlphaBiLevel):
                effect_data = operation.get_effective()
                print("  Alpha threshold: " + str(effect_data.threshold) + "%")
```

เอฟเฟกต์ที่ไม่มีพารามิเตอร์ เช่น ระดับสีเทา, ceiling ของอัลฟ่า, และ inverse ของอัลฟ่า ยังมีออบเจ็กต์ข้อมูลที่มีผลจริง แต่ไม่มีสเกลให้พิมพ์ การมีอยู่และตำแหน่งในคอลเลกชันเป็นข้อมูลสำคัญ

## **ลบหรือเคลียร์การแปลงรูปภาพ**

ใช้ [ImageTransformOperationCollection.remove_at](https://reference.aspose.com/slides/th/python-net/aspose.slides.effects/imagetransformoperationcollection/remove_at/) เพื่อลบการดำเนินงานหนึ่งโดยใช้ดัชนี เนื่องจากดัชนีจะเปลี่ยนหลังการลบ ให้ค้นหาเป้าหมายก่อนแล้วลบหลังจากลิสต์ ใช้ `clear()` เพื่อลบโซ่ทั้งหมด

```python
import aspose.slides as slides

with slides.Presentation("image-transform-chain.pptx") as presentation:
    picture_frame = None

    for shape in presentation.slides[0].shapes:
        if isinstance(shape, slides.PictureFrame):
            picture_frame = shape
            break

    if picture_frame is not None:
        image_transform = picture_frame.picture_format.picture.image_transform
        blur_index = None

        for index, operation in enumerate(image_transform):
            if isinstance(operation, slides.effects.Blur):
                blur_index = index
                break

        if blur_index is not None:
            image_transform.remove_at(blur_index)
            print("The blur operation was removed.")

        image_transform.clear()
        print("Remaining operations: " + str(len(image_transform)))
        presentation.save("image-transforms-cleared.pptx", slides.export.SaveFormat.PPTX)
```

การลบหรือเคลียร์การแปลงจะเปลี่ยนแค่การจัดรูปแบบภาพ ไม่ได้ลบ, บีบอัดใหม่, หรือแก้ไขทรัพยากร [PPImage](https://reference.aspose.com/slides/th/python-net/aspose.slides/ppimage/) ที่ใช้ซ้ำ

## **พิจารณารูปแบบพรีเซนเทชันและเป้าหมายการส่งออก**

การแปลงรูปภาพมีต้นกำเนิดจาก DrawingML ดังนั้น PPTX ถือเป็นรูปแบบที่แก้ไขได้ดีสำหรับโซ่เอฟเฟกต์ แม้ใน PPTX การดำเนินงานแต่ละอย่างก็อาจมีพกพาที่ต่างกัน:

- การดำเนินงาน DrawingML มาตรฐานเช่น luminance, grayscale, duotone, tint, HSL, blur, และเอฟเฟกต์อัลฟ่าทั่วไป มีโอกาสอยู่รอดสูงสุดหลังรอบ PPTX เปิดไฟล์ที่สร้างและตรวจสอบคอลเลกชันเมื่อการคงสภาพเป็นข้อกำหนด
- [BrightnessContrast](https://reference.aspose.com/slides/th/python-net/aspose.slides.effects/brightnesscontrast/) เป็นส่วนขยายนของ Office 2010 ไม่ใช่การดำเนินงาน luminance ของ DrawingML มาตรฐาน สามารถใช้สำหรับเรนเดอร์ในหน่วยความจำ แต่ไม่รับประกันว่าจะยังคงเป็นออบเจ็กต์ `BrightnessContrast` ที่แก้ไขได้หลังจากบันทึกและเปิด PPTX ใหม่ ให้เลือกใช้ [add_luminance_effect](https://reference.aspose.com/slides/th/python-net/aspose.slides.effects/imagetransformoperationcollection/add_luminance_effect/) สำหรับการปรับความสว่างและคอนทราสต์ที่คงอยู่
- รูปแบบไฟล์ PPT แบบไบนารีเกิดมาก่อนโมเดลเอฟเฟกต์ DrawingML เต็มรูปแบบ การบันทึกเป็น PPT อาจละเว้นการดำเนินงานที่ไม่สนับสนุน ลดโซ่ลงเป็นส่วนย่อยที่สนับสนุน หรือประมาณลักษณะ อย่าใช้ PPT เป็นรูปแบบตรวจสอบสำหรับโซ่แก้ไขที่ซับซ้อน
- การเรนเดอร์เป็น PNG, JPEG, TIFF, PDF, SVG, HTML หรือรูปแบบภาพอื่น ๆ จะนำโซ่ที่สนับสนุนไปใช้กับการแสดงผลสุดท้าย รูปแบบเหล่านี้ไม่มี `ImageTransformOperationCollection` ที่แก้ไขได้; รูปแบบราสเตอร์จะทำให้ผลลัพธ์แบนเป็นพิกเซล และการส่งออกเอกสารหรือเวกเตอร์จะเก็บการแสดงผลของตนเอง
- เอฟเฟกต์ไม่ทำให้ภาพที่ลิงก์เป็นแบบอิสระ การเรนเดอร์ภาพที่ลิงก์ยังคงต้องอาศัยทรัพยากรลิงก์ที่พร้อมใช้งานเมื่อพรีเซนเทชันโหลด

ผู้บริโภคพรีเซนเทชันต่าง ๆ อาจเรนเดอร์กรณีขอบต่างกันโดยเฉพาะเมื่อรวมการดำเนินงานอัลฟ่าและการควอนไทซ์สีหลายอย่าง สำหรับผลลัพธ์ที่สำคัญ ควรทดสอบทั้งรอบการแก้ไขและรูปแบบส่งออกสุดท้ายด้วย Aspose.Slides เวอร์ชันเดียวกันที่ใช้ในผลิตภัณฑ์

## **FAQ**

**การดำเนินงานแปลงรูปภาพเปลี่ยนแปลงข้อมูลภาพฝังหรือไม่?**

ไม่ การดำเนินงานเป็นของ `Picture` ที่ใช้เติมภาพ `PPImage` ด้านล่างจะไม่ถูกแก้ไข

**กรอบภาพสองกรอบที่ใช้ภาพเดียวกันจะแชร์เอฟเฟกต์หรือไม่?**

ไม่ การใช้ `PPImage` ร่วมช่วยลดข้อมูลภาพซ้ำ แต่แต่ละกรอบภาพโดยปกติมี `Picture` และคอลเลกชันแปลงแยกกัน

**สามารถรวมเอฟเฟกต์สี, เบลอ, และอัลฟ่าได้หรือไม่?**

ได้ คอลเลกชันรับในโซ่ที่เรียงลำดับ ควรพิจารณาว่าแต่ละการดำเนินงานส่งผลต่อผลลัพธ์ของการดำเนินงานก่อนหน้าอย่างไร เนื่องจากการแทนที่และการกำหนดเกณฑ์อาจลบรายละเอียดสีหรืออัลฟ่าเดิม

**ทำไมค่าที่มีผลจริงจึงเป็นแบบอ่าน‑อย่างเดียว?**

ข้อมูลที่มีผลจริงเป็นค่าที่คำนวณสำหรับการเรนเดอร์ รวมถึงสีที่แก้ไขตามธีม ให้แก้ไขการดำเนินงานที่เก็บในคอลเลกชันเมื่อมีสมาชิกที่เขียนได้ มิฉะนั้นต้องลบและเพิ่มออบเจ็กต์ใหม่ด้วยพารามิเตอร์การสร้างใหม่

**ควรใช้รูปแบบใดเพื่อคงโซ่การแปลง?**

ใช้ PPTX และตรวจสอบไฟล์โดยเปิดใหม่ PPT ดั้งเดิมไม่สามารถแสดงโมเดลเอฟเฟกต์ DrawingML เต็มรูปแบบได้ ส่วนรูปแบบส่งออกที่เรนเดอร์จะคงลักษณะการแสดงผลเท่านั้น ไม่ได้เก็บ `ImageTransformOperationCollection` ที่แก้ไขได้