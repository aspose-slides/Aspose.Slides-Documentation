---
title: จัดการเอฟเฟกต์การแปลงรูปภาพในงานนำเสนอด้วย Python
linktitle: เอฟเฟกต์การแปลงรูปภาพ
type: docs
weight: 11
url: /th/python-net/image-transform-effects/
keywords:
  - การแปลงรูปภาพ
  - เอฟเฟกต์รูปภาพ
  - ความสว่าง
  - คอนทราสต์
  - สีเทา
  - โทนคู่
  - สีอ่อน
  - HSL
  - การแทนที่สี
  - เบลอ
  - ความโปร่งใส
  - เอฟเฟกต์อัลฟ่า
  - โซ่เอฟเฟกต์
  - PowerPoint
  - งานนำเสนอ
  - Python
  - Aspose.Slides
description: "ใช้, จัดโซ่, ตรวจสอบ, ลบและตรวจสอบความถูกต้องของเอฟเฟกต์การแปลงรูปภาพสำหรับกรอบรูปด้วย Aspose.Slides สำหรับ Python ผ่าน .NET."
---
## **ภาพรวม**

Aspose.Slides แสดงการปรับภาพเป็นคอลเลกชันที่จัดลำดับของการดำเนินการแปลงรูปภาพ สำหรับกรอบรูป ให้เริ่มที่ [รูปภาพ](https://reference.aspose.com/slides/python-net/aspose.slides/picture/) ของกรอบและเข้าถึงคุณสมบัติ [image_transform](https://reference.aspose.com/slides/python-net/aspose.slides/picture/image_transform/) ที่คืนค่า [ImageTransformOperationCollection](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/) ซึ่งทำให้คุณสามารถเพิ่ม, ไวนับ, ตรวจสอบ, ลบและล้างเอฟเฟกต์ได้โดยไม่ต้องเขียนทับไบต์รูปภาพต้นฉบับ

บทความนี้สาธิตการทำงานเต็มรูปแบบสำหรับความสว่างและคอนทราสต์, การแปลงสี, เบลอ, ความโปร่งใส, โซ่เอฟเฟกต์ที่เรียงลำดับ, ค่าที่มีผล, การลบ, และการตรวจสอบรอบการบันทึก PPTX

## **เข้าใจการเป็นเจ้าของเอฟเฟกต์และการใช้รูปภาพซ้ำ**

ทรัพยากรรูปภาพและรูปที่แสดงมันเป็นวัตถุต่างกัน:

- [PPImage](https://reference.aspose.com/slides/python-net/aspose.slides/ppimage/) เก็บหรืออ้างอิงข้อมูลรูปภาพต้นฉบับที่เป็นของงานนำเสนอ
- [Picture](https://reference.aspose.com/slides/python-net/aspose.slides/picture/) เป็นส่วนของการเติมรูปและอ้างอิงไปยังทรัพยากรรูปภาพพร้อมกับเก็บคอลเลกชันการแปลงรูปภาพ
- [PictureFrame](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframe/) เป็นรูปร่างบนสไลด์ที่เป็นเจ้าของการเติมรูปที่เกี่ยวข้อง, รูปร่าง, การตั้งค่าการครอบ และการจัดรูปแบบระดับกรอบอื่น ๆ

ดังนั้น การดำเนินการแปลงรูปภาพจะไม่แก้ไขไบต์ใน [PPImage](https://reference.aspose.com/slides/python-net/aspose.slides/ppimage/) เมื่อ `PPImage` เดียวกันถูกส่งให้กับ [ShapeCollection.add_picture_frame](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_picture_frame/) มากกว่าหนึ่งครั้ง, แต่ละกรอบรูปใหม่จะได้รับ `Picture` ของตนเองและคอลเลกชันการแปลงของตนเอง การใช้สีเทาในกรอบหนึ่งจะไม่ทำให้กรอบอื่นเป็นสีเทา แม้ว่าพวกมันจะใช้ทรัพยากรรูปภาพฝังเดียวกัน

โมเดล `Picture.image_transform` เดียวกันนี้ยังใช้โดยการเติมรูปอื่น ๆ เช่น รูปร่างหรือพื้นหลังสไลด์ ตัวอย่างด้านล่างมุ่งเน้นที่กรอบรูป

## **ใช้ช่วงค่าพารามิเตอร์และหน่วยที่ถูกต้อง**

วิธีการที่แสดงใช้ช่วงเชิงความหมายและหน่วยต่อไปนี้ ให้ค่าตรงอยู่ในช่วงเหล่านี้แม้ว่ารุ่นไลบรารีบางรุ่นอาจไม่ปฏิเสธค่าที่อยู่นอกช่วงทันที; รูปแบบงานนำเสนอเป้าหมายอาจทำให้เป็นมาตรฐาน, ลบ, หรือปฏิเสธข้อมูลที่ไม่ถูกต้องระหว่างการบันทึกหรือเมื่อ PowerPoint เปิดไฟล์

| การดำเนินการ | พารามิเตอร์ | ช่วงที่ถูกต้องและหน่วย |
|---|---|---|
| [add_brightness_contrast_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_brightness_contrast_effect/) | `brightness`, `contrast` | `-100` ถึง `100` เปอร์เซ็นต์; `0` ไม่เปลี่ยนส่วนประกอบ |
| [add_gray_scale_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_gray_scale_effect/) | ไม่มี | ไม่มีพารามิเตอร์ตัวเลข ค่าอัลฟาไม่เปลี่ยน |
| [add_duotone_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_duotone_effect/) | `color1`, `color2` | สองสีสำหรับพิกเซลมืดและสีอ่อน ช่องสี RGB และอัลฟาใช้ค่า `0` ถึง `255` |
| [add_tint_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_tint_effect/) | `hue`, `amount` | Hue มีค่า `0` รวมถึง `360` ไม่รวม, หน่วยเป็นองศา; amount มีค่า `-100` ถึง `100` เปอร์เซ็นต์ |
| [add_hsl_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_hsl_effect/) | `hue`, `saturation`, `luminance` | Hue มีค่า `0` รวมถึง `360` ไม่รวม, หน่วยเป็นองศา; saturation และ luminance มีค่า `-100` ถึง `100` เปอร์เซ็นต์ |
| [add_color_replace_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_color_replace_effect/) | `color` | สีทดแทนใช้ค่าช่องจาก `0` ถึง `255` ค่าอัลฟ่าที่มีอยู่ไม่เปลี่ยน |
| [add_blur_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_blur_effect/) | `radius`, `grow` | รัศมีต้องไม่เป็นลบและหน่วยเป็นจุด; `grow` เป็น Boolean ที่ควบคุมว่าคอนเทนต์ที่เบลออาจขยายออกนอกขอบเดิมหรือไม่ |
| [add_alpha_modulate_fixed_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_alpha_modulate_fixed_effect/) | `amount` | เปอร์เซ็นต์ที่ไม่เป็นลบ ใช้ `0` ถึง `100` สำหรับการปรับความทึบแบบปกติ: `0` โปร่งใสเต็มและ `100` รักษาอัลฟ่าดั้งเดิม |
| [add_alpha_replace_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_alpha_replace_effect/) | `alpha` | `0` ถึง `100` เปอร์เซ็นต์ความทึบ |
| [add_alpha_bi_level_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_alpha_bi_level_effect/) | `threshold` | `0` ถึง `100` เปอร์เซ็นต์อัลฟ่าเป็นเกณฑ์; ค่าต่ำกว่าจะโปร่งใส; ค่าสูงกว่าจะทึบ |

สำหรับการมอดูเลตอัลฟ่าคงที่, ความโปร่งใสและความทึบเป็นค่าตรงกันข้าม ตัวอย่างเช่น ความโปร่งใส 35% เทียบกับการมอดูเลตอัลฟ่าที่ 65%

## **ใช้ความสว่างและคอนทราสต์**

[ImageTransformOperationCollection.add_brightness_contrast_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_brightness_contrast_effect/) คืนค่าออบเจกต์ [BrightnessContrast](https://reference.aspose.com/slides/python-net/aspose.slides.effects/brightnesscontrast/) การตั้งค่าสเกลาร์จะถูกส่งเมื่อสร้างออบเจกต์ [BrightnessContrast.get_effective](https://reference.aspose.com/slides/python-net/aspose.slides.effects/brightnesscontrast/get_effective/) คืนค่าที่คำนวนได้แบบอ่านอย่างเดียว ซึ่งสามารถตรวจสอบหรือบันทึกได้

ตัวอย่างต่อไปนี้เพิ่มความสว่าง 15% และคอนทราสต์ 20% จากนั้นเรนเดอร์ตัวอย่างโดยไม่แก้ไขรูปภาพฝัง:

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

[BrightnessContrast](https://reference.aspose.com/slides/python-net/aspose.slides.effects/brightnesscontrast/) เป็นส่วนขยายของ Office 2010 สำหรับเอฟเฟกต์รูปภาพและมีความพกพาน้อยกว่ามาตรฐาน DrawingML luminance effect เมื่อความสว่างและคอนทราสต์ต้องการให้แก้ไขได้หลังการทำรอบ PPTX ให้ใช้ [ImageTransformOperationCollection.add_luminance_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_luminance_effect/) และตรวจสอบผลลัพธ์หลังจากเปิดไฟล์อีกครั้ง ส่วนข้อจำกัดรูปแบบอธิบายความแตกต่างนี้อย่างละเอียดในส่วน "format limitations"

## **ใช้การแปลงสี**

เอฟเฟกต์สีสามารถนำไปใช้แยกกันกับกรอบรูปที่ใช้ทรัพยากรรูปภาพเดียวกัน ตัวอย่างต่อไปนี้สร้างห้ากรอบและใช้สีเทา, duotone, tint, การปรับ HSL, และการแทนที่สี

[Duotone](https://reference.aspose.com/slides/python-net/aspose.slides.effects/duotone/) มีพารามิเตอร์สีสองตัวที่แก้ไขได้อิสระ: `color1` ใช้สำหรับพิกเซลมืด, `color2` ใช้สำหรับพิกเซลอ่อน ซึ่งทำให้มันเป็นตัวอย่างที่ดีของเอฟเฟ็กต์ที่การตั้งค่าซับซ้อนกว่าค่าที่เป็นสเกลาร์เดียว

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

[add_color_replace_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_color_replace_effect/) แทนที่สีของทุกพิกเซลด้วยสีคงที่หนึ่งสีโดยคงอัลฟ่าไว้ มันแตกต่างจาก [add_color_change_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_color_change_effect/) ซึ่งแมปสีต้นทางหนึ่งเป็นสีเป้าหมายและเปิดเผยรูปแบบสีของต้นทางและเป้าหมาย

### **ใช้เกณฑ์ความสว่าง (Luminance Threshold)**

เกณฑ์ความสว่างสามารถทำให้เครื่องหมายที่ฟางบนหน้าสแกนแยกออกจากพื้นหลังได้ง่ายขึ้น [add_gray_scale_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_gray_scale_effect/) รักษาเฉดสีเทากลาง [add_bi_level_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_bi_level_effect/) แมปความสว่างเป็นสีดำหรือสีขาว, ขณะที่ [add_alpha_bi_level_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_alpha_bi_level_effect/) ใช้เกณฑ์กับความทึบ

เกณฑ์ความสว่างอยู่ในช่วง 0% ถึง 100% รวม ทั้งพิกเซลที่ต่ำกว่าจะเป็นสีดำ พิกเซลที่เท่าหรือสูงกว่าจะเป็นสีขาว การเพิ่มเกณฑ์จะทำให้สีหลายเฉดกลายเป็นสีดำเพราะส่วนมากตกต่ำกว่าขีดจำกัด

ดาวน์โหลด [grayscale-swatches.png](grayscale-swatches.png) ไปยังไดเรกทอรีทำงาน แต่ละป้ายบอกระดับสีเทาต้นฉบับในสเกล 0 ถึง 255 ตัวอย่างวางต้นฉบับข้างสำเนาสองชุดและบันทึกเกณฑ์ของแต่ละสำเนาในงานนำเสนอ

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    presentation.slide_size.set_size(720, 150, slides.SlideSizeScaleType.DO_NOT_SCALE)
    shapes = presentation.slides[0].shapes

    with slides.Images.from_file("grayscale-swatches.png") as source_image:
        image = presentation.images.add_image(source_image)

    def add_frame(x, caption):
        label = shapes.add_auto_shape(slides.ShapeType.RECTANGLE, x, 12, 216, 36)
        label.text_frame.text = caption
        return shapes.add_picture_frame(slides.ShapeType.RECTANGLE, x, 60, 216, 72, image)

    add_frame(12, "Original")

    low_threshold = add_frame(252, "Threshold 20%")
    low_threshold.picture_format.picture.image_transform.add_bi_level_effect(20)
    
    high_threshold = add_frame(492, "Threshold 60%")
    high_threshold.picture_format.picture.image_transform.add_bi_level_effect(60)

    presentation.save("luminance-threshold.pptx", slides.export.SaveFormat.PPTX)
```

เปิดงานนำเสนอผลลัพธ์ใน PowerPoint เพื่อเปรียบเทียบสามกรอบ สวิตช์ที่มีป้าย 96 มีความสว่างประมาณ 38% (96 จาก 255) มันเปลี่ยนเป็นสีขาวที่เกณฑ์ 20% และสีดำที่เกณฑ์ 60%

![Original grayscale swatches beside the black-and-white results at luminance thresholds of 20% and 60%](luminance-threshold.png)

## **เพิ่มเบลอ, ความโปร่งใส, และเอฟเฟกต์อัลฟ่า**

[add_blur_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_blur_effect/) มีผลต่อทุกช่องสีรวมอัลฟ่า ตั้งค่า `grow` เป็น `True` เมื่อตำแหน่งขอบเบลออาจขยายออกนอกขอบรูปต้นฉบับ

สำหรับความโปร่งใสที่สม่ำเสมอ ใช้ [add_alpha_modulate_fixed_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_alpha_modulate_fixed_effect/) มันคูณค่อัลฟ่าที่มีอยู่ทุกค่า ดังนั้นพิกเซลที่โปร่งใสบางส่วนจะคงสัดส่วนแตกต่างกัน [add_alpha_replace_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_alpha_replace_effect/) กลับมาจัดให้พิกเซลทั้งหมดมีค่าอัลฟ่าเดียว [add_alpha_bi_level_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_alpha_bi_level_effect/) แปลงอัลฟ่าเป็นสองระดับตามเกณฑ์

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

เอฟเฟกต์อัลฟ่าอื่น ๆ ที่ไม่มีพารามิเตอร์รวมถึง [add_alpha_ceiling_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_alpha_ceiling_effect/) ซึ่งทำให้ค่าอัลฟ่าที่ไม่เป็นศูนย์ทั้งหมดเป็นทึบเต็ม; [add_alpha_floor_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_alpha_floor_effect/) ทำให้ค่าอัลฟ่าที่ต่ำกว่า 100% เป็นโปร่งใสเต็ม; และ [add_alpha_inverse_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_alpha_inverse_effect/) เปลี่ยนอัลฟ่าเป็น `100% - alpha`

## **สร้างโซ่เอฟเฟกต์ที่จัดลำดับ**

ทุกเมธอด `add_..._effect` จะเพิ่มการดำเนินการใหม่ต่อท้ายคอลเลกชัน ตัวเรนเดอร์ใช้คอลเลกชันเป็นสายการทำงานที่เรียงลำดับ: ผลลัพธ์ของการดำเนินการ 0 จะเป็นอินพุตของการดำเนินการ 1 ฯลฯ ดังนั้น การดำเนินการเดียวกันในลำดับที่ต่างกันอาจให้ภาพที่ต่างกัน

เช่น การทำสีเทาตามด้วย tint จะลบข้อมูลสีก่อนแล้วสีใหม่บนผลลัพธ์ของความสว่าง; การทำ tint ตามด้วยสีเทาจะลบ tint อีกครั้ง เช่นเดียวกัน การแทนที่อัลฟ่าสามารถเขียนทับค่าอัลฟ่าที่คำนวนโดยการดำเนินการก่อนหน้า, ส่วนการมอดูเลตอัลฟ่าจะรักษาความแตกต่างสัมพัทธ์ของมัน

ตัวอย่างต่อไปนี้สร้างโซ่สี่การดำเนินการ, บันทึกเป็น PPTX, เปิดไฟล์อีกครั้ง, ตรวจสอบประเภทและลำดับของการดำเนินการ, และเรนเดอร์ผลลัพธ์ที่เปิดใหม่:

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

คอลเลกชันไม่ได้บังคับให้มีเมทริกซ์ความเข้ากันได้ที่จำกัดสี, อัลฟ่า, และการเบลอให้อยู่ในโซ่แยกกัน พวกมันสามารถรวมกันได้, แต่การผสมอาจไม่ค่อยมีประโยชน์ การแทนที่สีคงที่จะลบความแปรผัน RGB ที่เกิดจากเอฟเฟกต์สีก่อนหน้า; การทำสีเทาหลัง duotone จะลบสองสีที่เลือก; และการมอดูเลตอัลฟ่าแบบ ceiling, floor, replace หรือ bi-level สามารถทิ้งรายละเอียดอัลฟ่าที่สร้างขึ้นก่อนหน้า สร้างโซ่ตามลำดับการประมวลผลพิกเซลที่ต้องการแทนการมองว่าเป็นแฟล็กการจัดรูปแบบที่ไม่เรียงลำดับ

<!-- visual-explanation:image-transform-effects:start -->
[![The same image passes through grayscale then tint, and tint then grayscale. The two final grayscale images have different tones.](visual-image-transform-effects-49aa72211f3a.svg)](visual-image-transform-effects-49aa72211f3a.svg)

*In this illustrative Aspose.Slides for .NET 26.11 render, a 220° tint at 25% leaves the grayscale image unchanged. Applying the same tint before grayscale produces different tones.*
<!-- visual-explanation:image-transform-effects:end -->

## **ตรวจสอบค่าที่แก้ไขได้และค่าที่มีผล**

การดำเนินการที่แก้ไขได้คือออบเจกต์ที่เก็บอยู่ใน `Picture.image_transform` ขึ้นอยู่กับเอฟเฟกต์ อาจเปิดเผยสมาชิกที่เขียนได้โดยตรง ตัวอย่างเช่น [Blur](https://reference.aspose.com/slides/python-net/aspose.slides.effects/blur/) เปิดเผยคุณสมบัติ `radius` และ `grow` ที่เขียนได้, [AlphaModulateFixed](https://reference.aspose.com/slides/python-net/aspose.slides.effects/alphamodulatefixed/) เปิดเผยคุณสมบัติ `amount` ที่เขียนได้, และ [AlphaBiLevel](https://reference.aspose.com/slides/python-net/aspose.slides.effects/alphabilevel/) เปิดเผยคุณสมบัติ `threshold` ที่เขียนได้ เอฟเฟกต์สีเช่น [Duotone](https://reference.aspose.com/slides/python-net/aspose.slides.effects/duotone/) เปิดเผยออบเจกต์ [ColorFormat](https://reference.aspose.com/slides/python-net/aspose.slides/colorformat/) ที่เปลี่ยนแปลงได้

บางการดำเนินการรวมถึง [BrightnessContrast](https://reference.aspose.com/slides/python-net/aspose.slides.effects/brightnesscontrast/), [HSL](https://reference.aspose.com/slides/python-net/aspose.slides.effects/hsl/), [Tint](https://reference.aspose.com/slides/python-net/aspose.slides.effects/tint/), และ [AlphaReplace](https://reference.aspose.com/slides/python-net/aspose.slides.effects/alphareplace/) ไม่เปิดเผยสเกลาร์สร้างเป็นคุณสมบัติที่เขียนได้ เพื่อเปลี่ยนการตั้งค่าเหล่านั้นให้ลบการดำเนินการและเพิ่มการทดแทนในตำแหน่งที่ต้องการ

ข้อมูลที่มีผลที่คืนโดย `get_effective()` ถูกคำนวนและอ่านอย่างเดียว มันมีประโยชน์สำหรับการแก้ไขสีที่ขึ้นกับธีมและการอ่านค่าที่ทำให้มาตรฐานที่เรนเดอร์ใช้, แต่ไม่ใช่พื้นผิวการแก้ไขอื่น ตัวอย่างต่อไปนี้ไวนับโซ่และตรวจสอบค่าที่มีผลเมื่อ API ที่สอดคล้องให้

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

เอฟเฟกต์ที่ไม่มีพารามิเตอร์เช่น สีเทา, ceiling ของอัลฟ่า, และ inverse ของอัลฟ่ายังคงมีออบเจกต์ข้อมูลที่มีผล, แต่ไม่มีการตั้งค่าสเกลาร์ให้พิมพ์ การมีอยู่และตำแหน่งในคอลเลกชันเป็นข้อมูลสำคัญ

## **ลบหรือเคลียร์การแปลงรูปภาพ**

ใช้ [ImageTransformOperationCollection.remove_at](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/remove_at/) เพื่อลบการดำเนินการหนึ่งโดยดัชนี เนื่องจากดัชนีจะเปลี่ยนหลังการลบ, ค้นหาเป้าหมายก่อนและลบหลังจากไวนับ ใช้ `clear()` เพื่อลบโซ่ทั้งหมด

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

การลบหรือเคลียร์การแปลงเปลี่ยนเฉพาะการจัดรูปแบบรูปภาพ ไม่ได้ลบ, บีบอัดใหม่, หรือแก้ไขทรัพยากร [PPImage](https://reference.aspose.com/slides/python-net/aspose.slides/ppimage/) ที่ใช้ซ้ำ

## **พิจารณารูปแบบงานนำเสนอและเป้าหมายการส่งออก**

การแปลงรูปภาพเริ่มต้นจาก DrawingML ดังนั้น PPTX เป็นรูปแบบแก้ไขที่แนะนำสำหรับโซ่เอฟเฟกต์ แม้กับ PPTX ไม่ใช่ทุกการดำเนินการมีความพกพาเท่าเดิม:

- การดำเนินการ DrawingML มาตรฐานเช่น luminance, grayscale, duotone, tint, HSL, blur, และเอฟเฟกต์อัลฟ่าทั่วไปมีโอกาสสูงที่สุดที่จะคงอยู่หลังการทำรอบ PPTX. ควรเปิดไฟล์ที่สร้างขึ้นใหม่และตรวจสอบคอลเลกชันเมื่อการคงรักษาเป็นข้อกำหนด
- [BrightnessContrast](https://reference.aspose.com/slides/python-net/aspose.slides.effects/brightnesscontrast/) เป็นส่วนขยายของ Office 2010 ไม่ใช่การดำเนินการ luminance ของ DrawingML มาตรฐาน สามารถใช้สำหรับเรนเดอร์ในหน่วยความจำ แต่ไม่รับประกันว่าจะคงเป็นการดำเนินการ `BrightnessContrast` ที่แก้ไขได้หลังจากบันทึกและเปิดไฟล์ PPTX อีกครั้ง. แนะนำให้ใช้ [add_luminance_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_luminance_effect/) สำหรับการปรับความสว่างและคอนทราสต์แบบคงที่
- รูปแบบไบนารี PPT มีอายุก่อนโมเดลเอฟเฟกต์ DrawingML อย่างเต็ม. การบันทึกเป็น PPT อาจละเลยการดำเนินการที่ไม่รองรับ, ลดโซ่ลงเป็นส่วนที่รองรับ, หรือประมาณลักษณะการแสดงผล. อย่าใช้ PPT เป็นรูปแบบตรวจสอบสำหรับโซ่แก้ไขที่ซับซ้อน
- การเรนเดอร์เป็น PNG, JPEG, TIFF, PDF, SVG, HTML หรือรูปแบบภาพอื่น ๆ จะใช้โซ่ที่รองรับเพื่อสร้างลักษณะการแสดงผล. ผลลัพธ์เหล่านั้นไม่มี `ImageTransformOperationCollection` ที่แก้ไขได้; รูปแบบ raster จะทำให้ผลลัพธ์แบนเป็นพิกเซล, และการส่งออกเอกสารหรือเวกเตอร์จะเก็บตัวแทนการเรนเดอร์ของตนเอง
- เอฟเฟกต์ไม่ได้ทำให้รูปที่เชื่อมโยงเป็นอิสระ. การเรนเดอร์รูปที่เชื่อมโยงยังคงพึ่งพาทรัพยากรที่เชื่อมโยงอยู่เมื่อโหลดงานนำเสนอ

ผู้ใช้ต่าง ๆ อาจเรนเดอร์กรณีขอบต่างกันโดยเฉพาะเมื่อหลายเอฟเฟกต์อัลฟ่าหรือการควบคุมสีถูกผสานกัน สำหรับผลลัพธ์สำคัญ ควรทดสอบทั้งรอบการแก้ไขและรูปแบบการส่งออกสุดท้ายด้วย Aspose.Slides เวอร์ชันเดียวกันที่ใช้ในการผลิต

## **FAQ**

**ภาพขนาดใดบ้างที่เอฟเฟกต์การแปลงรูปภาพแก้ไขข้อมูลรูปภาพที่ฝังไว้?**

ไม่. การดำเนินการเป็นของ `Picture` ที่ใช้โดยการเติมรูป. ไบต์ของ `PPImage` ใต้พื้นฐานยังคงไม่เปลี่ยน

**สองกรอบรูปที่ใช้รูปภาพเดียวกันจะแบ่งปันเอฟเฟกต์หรือไม่?**

ไม่. การใช้ `PPImage` ทำให้หลีกเลี่ยงข้อมูลรูปภาพซ้ำ, แต่แต่ละกรอบรูปโดยปกติมี `Picture` และคอลเลกชันการแปลงของตนเอง

**สามารถใช้สี, เบลอและเอฟเฟกต์อัลฟ่าได้ร่วมกันได้หรือไม่?**

ใช่. คอลเลกชันรับเข้าตำแหน่งในโซ่เรียงลำดับหนึ่ง. พิจารณาว่าแต่ละการดำเนินการทำอะไรกับผลลัพธ์ของการดำเนินการก่อนหน้าเนื่องจากเอฟเฟกต์แทนที่และเกณฑ์อาจทิ้งรายละเอียดสีหรืออัลฟ่าก่อนหน้า

**ทำไมค่าที่มีผลถึงเป็นแบบอ่านอย่างเดียว?**

ข้อมูลที่มีผลเป็นค่าที่คำนวณแล้วใช้สำหรับการเรนเดอร์ รวมถึงสีที่ได้รับการแก้ไข. ให้แก้ไขการดำเนินการที่เก็บอยู่ในคอลเลกชันการแปลงเมื่อมีสมาชิกที่สามารถเขียนได้; หากไม่มีให้ลบและเพิ่มการทดแทนด้วยพารามิเตอร์การสร้างใหม่

**ควรใช้รูปแบบใดเพื่อรักษาโซ่การแปลง?**

ใช้ PPTX และตรวจสอบไฟล์โดยการเปิดใหม่. PPT แบบเก่าไม่สามารถแสดงโมเดลเอฟเฟกต์ DrawingML ทั้งหมดได้, และรูปแบบส่งออกที่เรนเดอร์จะเก็บลักษณะการแสดงผลแทนการดำเนินการแปลงที่แก้ไขได้