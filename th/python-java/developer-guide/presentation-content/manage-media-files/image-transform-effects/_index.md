---
title: จัดการเอฟเฟกต์การแปลงภาพในงานพรีเซนเทชันด้วย Python
linktitle: เอฟเฟกต์การแปลงภาพ
type: docs
weight: 11
url: /th/python-java/image-transform-effects/
keywords:
- การแปลงภาพ
- เอฟเฟกต์รูปภาพ
- ความสว่าง
- ความคอนทราสต์
- สเกลเทา
- ดูโทน
- สีสัน
- HSL
- การแทนที่สี
- เบลอ
- ความโปร่งใส
- เอฟเฟกต์อัลฟ่า
- โซ่เอฟเฟกต์
- PowerPoint
- การนำเสนอ
- Python
- Java
- Aspose.Slides
description: "ใช้, สร้างโซ่, ตรวจสอบ, ลบ และตรวจสอบความถูกต้องของเอฟเฟกต์การแปลงภาพสำหรับกรอบรูปภาพด้วย Aspose.Slides สำหรับ Python ผ่าน Java."
---
## **ภาพรวม**

Aspose.Slides แสดงการปรับรูปภาพเป็นคอลเลกชันที่เรียงลำดับของการดำเนินการแปลงภาพ สำหรับกรอบรูป ให้เริ่มจาก [Picture](https://reference.aspose.com/slides/th/python-java/aspose.slides/picture/) ของกรอบและเข้าถึง [Picture.getImageTransform](https://reference.aspose.com/slides/th/python-java/aspose.slides/picture/#getImageTransform). [ImageTransformOperationCollection](https://reference.aspose.com/slides/th/python-java/aspose.slides/imagetransformoperationcollection/) ที่คืนค่ามาให้คุณสามารถเพิ่ม, แสดงรายการ, ตรวจสอบ, ลบ, และล้างเอฟเฟกต์โดยไม่ต้องเขียนทับไบต์ของภาพต้นฉบับ

บทความนี้แสดงกระบวนการทำงานครบถ้วนสำหรับการปรับความสว่างและคอนทราสต์, การแปลงสี, ความเบลอ, ความโปร่งใส, การจัดลำดับเอฟเฟกต์, ค่าที่ได้จริง, การลบ, และการตรวจสอบรอบ‑trip ของ PPTX

## **ทำความเข้าใจการเป็นเจ้าของเอฟเฟกต์และการใช้ภาพซ้ำ**

แหล่งภาพและรูปภาพที่แสดงภาพนั้นเป็นอ็อบเจ็กต์ที่แตกต่างกัน:

- [PPImage](https://reference.aspose.com/slides/th/python-java/aspose.slides/ppimage/) เก็บหรืออ้างอิงข้อมูลภาพต้นฉบับที่เป็นเจ้าของของพรีเซนเทชัน
- [Picture](https://reference.aspose.com/slides/th/python-java/aspose.slides/picture/) เป็นส่วนเติมรูปภาพและอ้างอิงถึงแหล่งภาพในขณะที่เก็บคอลเลกชันการแปลงภาพ
- [PictureFrame](https://reference.aspose.com/slides/th/python-java/aspose.slides/pictureframe/) เป็นรูปทรงบนสไลด์ที่เป็นเจ้าของส่วนเติมรูปภาพที่เกี่ยวข้อง, รูปร่าง, การตั้งค่าการครอป, และการจัดรูปแบบระดับกรอบอื่น ๆ

ดังนั้นการดำเนินการแปลงภาพจะไม่แก้ไขไบต์ใน [PPImage](https://reference.aspose.com/slides/th/python-java/aspose.slides/ppimage/). เมื่อ `PPImage` เดียวกันถูกส่งไปยัง [ShapeCollection.addPictureFrame](https://reference.aspose.com/slides/th/python-java/aspose.slides/shapecollection/#addPictureFrame) มากกว่าหนึ่งครั้ง, แต่ละกรอบรูปใหม่จะได้รับ `Picture` ของตนเองและคอลเลกชันการแปลงของตนเอง การนำเอาเอฟเฟกต์สเกลเทาไปใช้กับกรอบหนึ่งจะไม่ทำให้กรอบอื่นสเกลเทาแม้ทั้งหมดจะใช้แหล่งภาพที่ฝังเดียวกัน

โมเดล `Picture.getImageTransform` เดียวกันยังใช้โดยส่วนเติมรูปภาพอื่น ๆ เช่น รูปร่างหรือพื้นหลังสไลด์ ตัวอย่างด้านล่างมุ่งเน้นไปที่กรอบรูปภาพ

## **ใช้ช่วงค่าพารามิเตอร์และหน่วยที่ถูกต้อง**

วิธีการที่แสดงใช้ช่วงความหมายและหน่วยต่อไปนี้. ให้รักษาค่าภายในช่วงเหล่านี้แม้เวอร์ชันไลบรารีบางเวอร์ชันอาจไม่ปฏิเสธค่าผิดช่วงทันที; รูปแบบพรีเซนเทชันเป้าหมายอาจทำให้ค่าปกติ, ลบ, หรือปฏิเสธข้อมูลที่ไม่ถูกต้องระหว่างการบันทึกหรือเมื่อ PowerPoint เปิดไฟล์

| Operation | Parameters | ช่วงค่าที่ถูกต้องและหน่วย |
|---|---|---|
| [addBrightnessContrastEffect](https://reference.aspose.com/slides/th/python-java/aspose.slides/imagetransformoperationcollection/#addBrightnessContrastEffect) | `brightness`, `contrast` | `-100` ถึง `100`, เปอร์เซนต์; `0` ไม่เปลี่ยนส่วนประกอบ |
| [addGrayScaleEffect](https://reference.aspose.com/slides/th/python-java/aspose.slides/imagetransformoperationcollection/#addGrayScaleEffect) | ไม่มี | ไม่มีพารามิเตอร์เชิงตัวเลข. Alpha ไม่เปลี่ยน |
| [addDuotoneEffect](https://reference.aspose.com/slides/th/python-java/aspose.slides/imagetransformoperationcollection/#addDuotoneEffect) | `color1`, `color2` | สองสีสำหรับพิกเซลมืดและสว่าง. ช่องสี RGB และอัลฟ่าใน `java.awt.Color` ใช้ค่า `0` ถึง `255` |
| [addTintEffect](https://reference.aspose.com/slides/th/python-java/aspose.slides/imagetransformoperationcollection/#addTintEffect) | `hue`, `amount` | hue ตั้งแต่ `0` (รวม) ถึง `360` (ไม่รวม) ระดับองศา; amount ตั้งแต่ `-100` ถึง `100` เปอร์เซนต์ |
| [addHSLEffect](https://reference.aspose.com/slides/th/python-java/aspose.slides/imagetransformoperationcollection/#addHSLEffect) | `hue`, `saturation`, `luminance` | hue ตั้งแต่ `0` (รวม) ถึง `360` (ไม่รวม) ระดับองศา; saturation และ luminance ตั้งแต่ `-100` ถึง `100` เปอร์เซนต์ |
| [addColorReplaceEffect](https://reference.aspose.com/slides/th/python-java/aspose.slides/imagetransformoperationcollection/#addColorReplaceEffect) | `color` | สีแทนที่ใช้ค่าช่องจาก `0` ถึง `255`. ค่าอัลฟ่าเดิมไม่เปลี่ยน |
| [addBlurEffect](https://reference.aspose.com/slides/th/python-java/aspose.slides/imagetransformoperationcollection/#addBlurEffect) | `radius`, `grow` | radius ต้องไม่เป็นค่าติดลบและวัดเป็นจุด; `grow` เป็น Boolean ที่กำหนดว่าภาพเบลออาจขยายนอกขอบเดิมหรือไม่ |
| [addAlphaModulateFixedEffect](https://reference.aspose.com/slides/th/python-java/aspose.slides/imagetransformoperationcollection/#addAlphaModulateFixedEffect) | `amount` | เปอร์เซนต์ไม่เป็นค่าติดลบ. ใช้ `0` ถึง `100` สำหรับการปรับความทึบปกติ: `0` โปร่งแสงเต็มและ `100` รักษาอัลฟ่าที่มีอยู่ |
| [addAlphaReplaceEffect](https://reference.aspose.com/slides/th/python-java/aspose.slides/imagetransformoperationcollection/#addAlphaReplaceEffect) | `alpha` | `0` ถึง `100` เปอร์เซนต์ความทึบ |
| [addAlphaBiLevelEffect](https://reference.aspose.com/slides/th/python-java/aspose.slides/imagetransformoperationcollection/#addAlphaBiLevelEffect) | `threshold` | `0` ถึง `100` เปอร์เซนต์ค่าเกณฑ์อัลฟ่า. ค่าต่ำกว่าจะเป็นโปร่งแสง; ค่าสูงกว่าหรือเท่าจะเป็นทึบ |

สำหรับการมอดูเลตอัลฟ่าแบบคงที่, ความโปร่งใสและความทึบเป็นค่าตรงกันข้าม ตัวอย่างเช่น ความโปร่งใส 35% เทียบกับปริมาณมอดูเลตอัลฟ่า 65%

## **ใช้ความสว่างและคอนทราสต์**

[ImageTransformOperationCollection.addBrightnessContrastEffect](https://reference.aspose.com/slides/th/python-java/aspose.slides/imagetransformoperationcollection/#addBrightnessContrastEffect) คืนค่าอ็อบเจ็กต์ [BrightnessContrast](https://reference.aspose.com/slides/th/python-java/aspose.slides/brightnesscontrast/) การตั้งค่าสเกลาร์ถูกกำหนดในขณะสร้างอ็อบเจ็กต์. [BrightnessContrast.getEffective](https://reference.aspose.com/slides/th/python-java/aspose.slides/brightnesscontrast/#getEffective) คืนค่าที่คำนวณแล้วแบบอ่านอย่างเดียวซึ่งสามารถตรวจสอบหรือบันทึกได้

ตัวอย่างต่อไปนี้เพิ่มความสว่าง 15% และคอนทราสต์ 20% แล้วแสดงตัวอย่างโดยไม่แก้ไขภาพที่ฝังไว้:

```python
import jpype
import asposeslides
from pathlib import Path

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    image_data = Path("photo.png").read_bytes()
    image_bytes = jpype.JArray(jpype.JByte)(image_data)
    image = presentation.getImages().addImage(image_bytes)
    picture_frame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 50, 400, 260, image)

    image_transform = picture_frame.getPictureFormat().getPicture().getImageTransform()
    brightness_contrast = image_transform.addBrightnessContrastEffect(15.0, 20.0)

    effective_values = brightness_contrast.getEffective()
    print("Brightness: ", effective_values.getBrightness(), "%", sep="")
    print("Contrast: ", effective_values.getContrast(), "%", sep="")

    preview = slide.getImage()
    try:
        preview.save("brightness-contrast-preview.png", ImageFormat.Png)
    finally:
        preview.dispose()
finally:
    presentation.dispose()
```

[BrightnessContrast](https://reference.aspose.com/slides/th/python-java/aspose.slides/brightnesscontrast/) เป็นส่วนขยายเอฟเฟกต์รูปภาพของ Office 2010 และมีความพกพาน้อยกว่ามาตรฐาน DrawingML luminance. เมื่อความสว่างและคอนทราสต์ต้องการให้แก้ไขได้หลังการ round‑trip ของ PPTX, ให้ใช้ [ImageTransformOperationCollection.addLuminanceEffect](https://reference.aspose.com/slides/th/python-java/aspose.slides/imagetransformoperationcollection/#addLuminanceEffect) และตรวจสอบผลลัพธ์หลังจากเปิดไฟล์ใหม่. ส่วน “format limitations” ให้รายละเอียดเพิ่มเติมเกี่ยวกับความแตกต่างนี้

## **ใช้การแปลงสี**

เอฟเฟกต์สีสามารถนำไปใช้แยกต่างหากกับกรอบรูปภาพหลายกรอบที่ใช้แหล่งภาพเดียวกัน ตัวอย่างต่อไปนี้สร้างห้ากรอบและนำไปใช้สเกลเทา, ดูโทน, สีสัน, การปรับ HSL, และการแทนที่สี

[Duotone](https://reference.aspose.com/slides/th/python-java/aspose.slides/duotone/) มีพารามิเตอร์สีสองตัวที่แก้ไขได้อิสระ: `color1` ใช้กับพิกเซลมืด, `color2` ใช้กับพิกเซลสว่าง. ทำให้เป็นตัวอย่างที่ดีของเอฟเฟกต์ที่การตั้งค่าซับซ้อนกว่าค่าสเกลาร์เดียว

```python
import jpile
import asposeslides
from pathlib import Path

if not jpile.isJVMStarted():
    jpile.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    image_data = Path("photo.png").read_bytes()
    image_bytes = jpile.JArray(jpile.JByte)(image_data)
    image = presentation.getImages().addImage(image_bytes)

    gray_frame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 20, 20, 180, 120, image)
    gray_frame.getPictureFormat().getPicture().getImageTransform().addGrayScaleEffect()

    duotone_frame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 220, 20, 180, 120, image)
    duotone = duotone_frame.getPictureFormat().getPicture().getImageTransform().addDuotoneEffect()
    duotone.getColor1().setColor(Color(0, 0, 128))
    duotone.getColor2().setColor(Color(255, 215, 0))

    tint_frame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 420, 20, 180, 120, image)
    tint_frame.getPictureFormat().getPicture().getImageTransform().addTintEffect(210.0, 35.0)

    hsl_frame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 120, 170, 180, 120, image)
    hsl_frame.getPictureFormat().getPicture().getImageTransform().addHSLEffect(30.0, 20.0, -10.0)

    replacement_frame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 320, 170, 180, 120, image)
    color_replacement = replacement_frame.getPictureFormat().getPicture().getImageTransform().addColorReplaceEffect()
    color_replacement.getColor().setColor(Color(100, 149, 237))

    presentation.save("color-transformations.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

[addColorReplaceEffect](https://reference.aspose.com/slides/th/python-java/aspose.slides/imagetransformoperationcollection/#addColorReplaceEffect) แทนที่สีของทุกพิกเซลด้วยสีคงที่หนึ่งสีในขณะที่รักษาอัลฟ่า. มันแตกต่างจาก [addColorChangeEffect](https://reference.aspose.com/slides/th/python-java/aspose.slides/imagetransformoperationcollection/#addColorChangeEffect) ที่แมปสีต้นทางหนึ่งไปยังสีเป้าหมายและเปิดเผยรูปแบบสีของแหล่งและเป้าหมาย

## **เพิ่มความเบลอ, ความโปร่งใส, และเอฟเฟกต์อัลฟ่า**

[addBlurEffect](https://reference.aspose.com/slides/th/python-java/aspose.slides/imagetransformoperationcollection/#addBlurEffect) มีผลต่อทุกช่องสีรวมถึงอัลฟ่า. ตั้งค่า `grow` เป็น `True` เมื่อขอบเบลออาจขยายออกนอกขอบภาพเดิม

สำหรับความโปร่งใสสม่ำเสมอ, ใช้ [addAlphaModulateFixedEffect](https://reference.aspose.com/slides/th/python-java/aspose.slides/imagetransformoperationcollection/#addAlphaModulateFixedEffect). มันคูณค่าอัลฟ่าเดิมทั้งหมด, ดังนั้นพิกเซลที่โปร่งใสบางส่วนจะคงสัดส่วนความโปร่งใส. [addAlphaReplaceEffect](https://reference.aspose.com/slides/th/python-java/aspose.slides/imagetransformoperationcollection/#addAlphaReplaceEffect) แทนที่ค่าต้นที่เป็นอัลฟ่าเดียวกันทั้งหมด. [addAlphaBiLevelEffect](https://reference.aspose.com/slides/th/python-java/aspose.slides/imagetransformoperationcollection/#addAlphaBiLevelEffect) แปลงอัลฟ่าเป็นสองระดับตามค่าเกณฑ์

```python
import jpype
import asposeslides
from pathlib import Path

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    image_data = Path("photo.png").read_bytes()
    image_bytes = jpype.JArray(jpype.JByte)(image_data)
    image = presentation.getImages().addImage(image_bytes)

    blurred_frame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 20, 20, 200, 140, image)
    blur = blurred_frame.getPictureFormat().getPicture().getImageTransform().addBlurEffect(4.5, True)
    blur.setRadius(5)

    transparent_frame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 240, 20, 200, 140, image)
    alpha_modulate = transparent_frame.getPictureFormat().getPicture().getImageTransform().addAlphaModulateFixedEffect(65.0)
    alpha_modulate.setAmount(60.0)

    uniform_alpha_frame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 20, 180, 200, 140, image)
    uniform_alpha_frame.getPictureFormat().getPicture().getImageTransform().addAlphaReplaceEffect(55.0)

    binary_alpha_frame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 240, 180, 200, 140, image)
    alpha_bi_level = binary_alpha_frame.getPictureFormat().getPicture().getImageTransform().addAlphaBiLevelEffect(50.0)
    alpha_bi_level.setThreshold(45.0)
    binary_alpha_frame.getPictureFormat().getPicture().getImageTransform().addAlphaInverseEffect()

    presentation.save("blur-and-alpha-effects.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

เอฟเฟกต์อัลฟ่าอื่น ๆ ที่ไม่มีพารามิเตอร์ ได้แก่ [addAlphaCeilingEffect](https://reference.aspose.com/slides/th/python-java/aspose.slides/imagetransformoperationcollection/#addAlphaCeilingEffect) ซึ่งทำให้ทุกอัลฟ่าไม่เป็นศูนย์เป็นทึบเต็ม; [addAlphaFloorEffect](https://reference.aspose.com/slides/th/python-java/aspose.slides/imagetransformoperationcollection/#addAlphaFloorEffect) ซึ่งทำให้ทุกอัลฟ่าใต 100% เป็นโปร่งใสเต็ม; และ [addAlphaInverseEffect](https://reference.aspose.com/slides/th/python-java/aspose.slides/imagetransformoperationcollection/#addAlphaInverseEffect) ซึ่งเปลี่ยนอัลฟ่าเป็น `100% - alpha`

## **สร้างโซ่เอฟเฟกต์ที่เรียงลำดับ**

แต่ละเมธอด `add...Effect` จะเพิ่มการดำเนินการใหม่ต่อท้ายคอลเลกชัน. เร็นเดอร์ใช้คอลเลกชันเป็นสายการประมวลผลที่เรียงลำดับ: ผลลัพธ์ของการดำเนินการ 0 จะเป็นอินพุตของการดำเนินการ 1, และต่อไป ดังนั้นการจัดลำดับเดียวกันในลำดับที่ต่างกันอาจได้ภาพที่แตกต่างกัน

เช่น สเกลเท้าตามด้วยสีสันจะลบข้อมูลสีก่อนแล้วเปลี่ยนสีของผลลัพธ์ความสว่าง. สีสันตามด้วยสเกลเท้าจะทำให้สีสันหายไปอีกครั้ง. เช่นเดียวกัน การแทนที่อัลฟ่าอาจเขียนทับค่าอัลฟ่าโดยการดำเนินการก่อนหน้า, ขณะที่การมอดูเลตอัลฟ่าเก็บความแตกต่างสัมพัทธ์ไว้

ตัวอย่างต่อไปนี้สร้างโซ่สี่การดำเนินการ, บันทึกเป็น PPTX, เปิดพรีเซนเทชันใหม่, ตรวจสอบทั้งประเภทการดำเนินการและลำดับ, แล้วเร็นเดอร์ผลลัพธ์ที่เปิดใหม่:

```python
import jpype
import asposeslides
from pathlib import Path

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AlphaModulateFixed, Blur, GrayScale, ImageFormat, PictureFrame, Presentation, SaveFormat, ShapeType, Tint

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    image_data = Path("photo.png").read_bytes()
    image_bytes = jpype.JArray(jpype.JByte)(image_data)
    image = presentation.getImages().addImage(image_bytes)
    picture_frame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 50, 400, 260, image)

    image_transform = picture_frame.getPictureFormat().getPicture().getImageTransform()
    image_transform.addGrayScaleEffect()
    image_transform.addTintEffect(220.0, 25.0)
    image_transform.addBlurEffect(2.5, False)
    image_transform.addAlphaModulateFixedEffect(80.0)

    presentation.save("image-transform-chain.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()

reopened_presentation = Presentation("image-transform-chain.pptx")
try:
    reopened_shape = reopened_presentation.getSlides().get_Item(0).getShapes().get_Item(0)

    if isinstance(reopened_shape, PictureFrame):
        reopened_transform = reopened_shape.getPictureFormat().getPicture().getImageTransform()
        expected_types = (GrayScale, Tint, Blur, AlphaModulateFixed)
        order_is_preserved = reopened_transform.size() == len(expected_types)
        for index, expected_type in enumerate(expected_types):
            order_is_preserved = order_is_preserved and isinstance(reopened_transform.get_Item(index), expected_type)
        print("The effect chain was preserved." if order_is_preserved else "The effect chain changed during the round trip.")

        rendered_slide = reopened_presentation.getSlides().get_Item(0).getImage()
        try:
            rendered_slide.save("reopened-effect-chain.png", ImageFormat.Png)
        finally:
            rendered_slide.dispose()
    else:
        print("The reopened shape is not a picture frame.")
finally:
    reopened_presentation.dispose()
```

คอลเลกชันไม่ได้กำหนดเมทริกซ์ความเข้ากันได้ที่จำกัดให้เอฟเฟกต์สี, อัลฟ่า, และความเบลออยู่ในโซ่แยกกัน. พวกมันสามารถรวมกันได้, แต่บางการรวมอาจไม่ค่อยมีประโยชน์. การแทนที่สีคงที่จะลบความแปรผัน RGB ที่สร้างโดยเอฟเฟกต์สีก่อนหน้า; สเกลเท้าหลังดูโทนจะลบสองสีที่เลือก; และเอฟเฟกต์อัลฟ่า ceiling, floor, replacement หรือ bi‑level สามารถทิ้งรายละเอียดอัลฟ่าได้. สร้างโซ่ตามลำดับการประมวลผลพิกเซลที่ต้องการแทนที่จะถือว่าเป็นแฟล็กการจัดรูปแบบที่ไม่มีลำดับ

## **ตรวจสอบค่าที่แก้ไขได้และค่าที่ได้จริง**

การดำเนินการที่แก้ไขได้คืออ็อบเจ็กต์ที่เก็บไว้ใน `Picture.getImageTransform`. ขึ้นอยู่กับเอฟเฟกต์, อาจเปิดเผยสมาชิกที่เขียนได้โดยตรง. ตัวอย่างเช่น, [Blur](https://reference.aspose.com/slides/th/python-java/aspose.slides/blur/) เปิดเผย `radius` และ `grow` ที่เขียนได้, [AlphaModulateFixed](https://reference.aspose.com/slides/th/python-java/aspose.slides/alphamodulatefixed/) เปิดเผย `amount`, และ [AlphaBiLevel](https://reference.aspose.com/slides/th/python-java/aspose.slides/alphabilevel/) เปิดเผย `threshold`. เอฟเฟกต์สีเช่น [Duotone](https://reference.aspose.com/slides/th/python-java/aspose.slides/duotone/) เปิดเผยวัตถุ [ColorFormat](https://reference.aspose.com/slides/th/python-java/aspose.slides/colorformat/) ที่แก้ไขได้

บางคลาสการดำเนินการ, รวมถึง [BrightnessContrast](https://reference.aspose.com/slides/th/python-java/aspose.slides/brightnesscontrast/), [HSL](https://reference.aspose.com/slides/th/python-java/aspose.slides/hsl/), [Tint](https://reference.aspose.com/slides/th/python-java/aspose.slides/tint/), และ [AlphaReplace](https://reference.aspose.com/slides/th/python-java/aspose.slides/alphareplace/), ไม่เปิดเผยสเกลาร์ที่สร้างเป็นคุณสมบัติที่เขียนได้. เพื่อเปลี่ยนการตั้งค่าเหล่านั้น, ให้ลบการดำเนินการและเพิ่มการแทนที่ในตำแหน่งที่ต้องการ

ข้อมูลที่ได้จริงที่ `getEffective` คืนค่ามาเป็นค่าที่คำนวณแล้วและอ่าน‑อย่างเดียว. มันมีประโยชน์สำหรับการแก้ไขสีที่ขึ้นกับธีมและการอ่านค่าที่ทำให้มาตรฐานซึ่งเร็นเดอร์ใช้, แต่ไม่ได้เป็นพื้นผิวการแก้ไขอื่น. ตัวอย่างต่อไปนี้แสดงรายการโซ่และตรวจสอบค่าที่ได้จริงในที่ API ให้ข้อมูล:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AlphaBiLevel, AlphaModulateFixed, AlphaReplace, Blur, BrightnessContrast, ColorReplace, Duotone, HSL, Luminance, PictureFrame, Presentation, Tint

presentation = Presentation("image-transform-chain.pptx")
try:
    picture_frame = None

    for shape in presentation.getSlides().get_Item(0).getShapes():
        if isinstance(shape, PictureFrame):
            picture_frame = shape
            break

    if picture_frame is not None:
        image_transform = picture_frame.getPictureFormat().getPicture().getImageTransform()

        for index in range(image_transform.size()):
            operation = image_transform.get_Item(index)
            print(index, ": ", operation.getClass().getSimpleName(), sep="")

            if isinstance(operation, BrightnessContrast):
                data = operation.getEffective()
                print("  Brightness: ", data.getBrightness(), sep="")
                print("  Contrast: ", data.getContrast(), sep="")
            elif isinstance(operation, Luminance):
                data = operation.getEffective()
                print("  Brightness: ", data.getBrightness(), sep="")
                print("  Contrast: ", data.getContrast(), sep="")
            elif isinstance(operation, Duotone):
                data = operation.getEffective()
                print("  Dark color: ", data.getColor1(), sep="")
                print("  Light color: ", data.getColor2(), sep="")
            elif isinstance(operation, ColorReplace):
                data = operation.getEffective()
                print("  Replacement color: ", data.getColor(), sep="")
            elif isinstance(operation, HSL):
                data = operation.getEffective()
                print("  HSL: ", data.getHue(), ", ", data.getSaturation(), ", ", data.getLuminance(), sep="")
            elif isinstance(operation, Tint):
                data = operation.getEffective()
                print("  Tint: ", data.getHue(), ", ", data.getAmount(), sep="")
            elif isinstance(operation, Blur):
                data = operation.getEffective()
                print("  Blur radius: ", data.getRadius(), " pt", sep="")
            elif isinstance(operation, AlphaModulateFixed):
                data = operation.getEffective()
                print("  Alpha amount: ", data.getAmount(), "%", sep="")
            elif isinstance(operation, AlphaReplace):
                data = operation.getEffective()
                print("  Replacement alpha: ", data.getAlpha(), "%", sep="")
            elif isinstance(operation, AlphaBiLevel):
                data = operation.getEffective()
                print("  Alpha threshold: ", data.getThreshold(), "%", sep="")
finally:
    presentation.dispose()
```

เอฟเฟกต์ที่ไม่มีพารามิเตอร์เช่นสเกลเท้า, alpha ceiling, และ alpha inverse ยังมีอ็อบเจ็กต์ข้อมูลที่ได้จริง, แต่ไม่มีการตั้งค่าสเกลาร์ให้พิมพ์. การมีอยู่และตำแหน่งของมันในคอลเลกชันเป็นข้อมูลสำคัญ

## **ลบหรือเคลียร์การแปลงภาพ**

ใช้ [ImageTransformOperationCollection.removeAt](https://reference.aspose.com/slides/th/python-java/aspose.slides/imagetransformoperationcollection/#removeAt) เพื่อลบการดำเนินการหนึ่งโดยใช้ดัชนี. เนื่องจากดัชนีจะเปลี่ยนหลังการลบ, ควรค้นหาเป้าหมายก่อนแล้วลบหลังจากแสดงรายการ. ใช้ [ImageTransformOperationCollection.clear](https://reference.aspose.com/slides/th/python-java/aspose.slides/imagetransformoperationcollection/#clear) เพื่อลบโซ่ทั้งหมด

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Blur, PictureFrame, Presentation, SaveFormat

presentation = Presentation("image-transform-chain.pptx")
try:
    picture_frame = None

    for shape in presentation.getSlides().get_Item(0).getShapes():
        if isinstance(shape, PictureFrame):
            picture_frame = shape
            break

    if picture_frame is not None:
        image_transform = picture_frame.getPictureFormat().getPicture().getImageTransform()
        blur_index = -1

        for index in range(image_transform.size()):
            if isinstance(image_transform.get_Item(index), Blur):
                blur_index = index
                break

        if blur_index >= 0:
            image_transform.removeAt(blur_index)
            print("The blur operation was removed.")

        image_transform.clear()
        print("Remaining operations: ", image_transform.size(), sep="")
        presentation.save("image-transforms-cleared.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

การลบหรือเคลียร์การแปลงเปลี่ยนเฉพาะการจัดรูปแบบรูปภาพ. มันไม่ได้ลบ, บีบอัดใหม่, หรือแก้ไขแหล่ง [PPImage](https://reference.aspose.com/slides/th/python-java/aspose.slides/ppimage/) ที่ใช้ซ้ำ

## **พิจารณารูปแบบพรีเซนเทชันและเป้าหมายการส่งออก**

การแปลงภาพมาจาก DrawingML, ดังนั้น PPTX เป็นรูปแบบที่แนะนำสำหรับการแก้ไขโซ่เอฟเฟกต์. แม้กับ PPTX, ไม่ใช่ทุกการดำเนินการที่มีพกพาเดียวกัน:

- การดำเนินการ DrawingML มาตรฐานเช่น luminance, grayscale, duotone, tint, HSL, blur, และเอฟเฟกต์อัลฟ่าทั่วไปมีโอกาสสูงสุดที่จะคงอยู่หลังการ round‑trip ของ PPTX. ควรเปิดไฟล์ที่สร้างใหม่และตรวจสอบคอลเลกชันเมื่อการเก็บรักษาเป็นข้อกำหนด
- [BrightnessContrast](https://reference.aspose.com/slides/th/python-java/aspose.slides/brightnesscontrast/) เป็นส่วนขยาย Office 2010 ไม่ใช่มาตรฐาน DrawingML luminance. สามารถใช้สำหรับเร็นเดอร์ในหน่วยความจำ, แต่ไม่รับประกันว่าจะยังคงเป็น [BrightnessContrast](https://reference.aspose.com/slides/th/python-java/aspose.slides/brightnesscontrast/) ที่แก้ไขได้หลังการบันทึกและเปิด PPTX อีกครั้ง. ควรใช้ [addLuminanceEffect](https://reference.aspose.com/slides/th/python-java/aspose.slides/imagetransformoperationcollection/#addLuminanceEffect) สำหรับการปรับความสว่างและคอนทราสต์ที่คงอยู่
- รูปแบบไบนารี PPT มีอายุยาวนานกว่ารุ่นเต็มของโมเดลเอฟเฟกต์ DrawingML. การบันทึกเป็น PPT อาจละเว้นการดำเนินการที่ไม่ได้รับการสนับสนุน, ลดโซ่ให้เหลือส่วนที่สนับสนุน, หรือประมาณลักษณะการแสดงผล. อย่าใช้ PPT เป็นรูปแบบการตรวจสอบสำหรับโซ่แก้ไขที่ซับซ้อน
- การเร็นเดอร์เป็น PNG, JPEG, TIFF, PDF, SVG, HTML, หรือรูปแบบภาพอื่น ๆ จะนำโซ่ที่สนับสนุนไปใช้กับการแสดงผลที่เร็นเดอร์. ผลลัพธ์เหล่านั้นไม่มี `ImageTransformOperationCollection` ที่แก้ไขได้; รูปแบบราสเตอร์ทำให้ผลลัพธ์แบนเป็นพิกเซล, ส่วนส่งออกเอกสาร/เวกเตอร์เก็บตัวแทนการเร็นเดอร์ของตนเอง
- เอฟเฟกต์ไม่ทำให้ภาพที่ลิงก์มาเป็นอิสระ. การเร็นเดอร์รูปที่ลิงก์ยังคงต้องพึ่งพาแหล่งที่ลิงก์อยู่ในขณะที่พรีเซนเทชันโหลด

ผู้ใช้พรีเซนเทชันต่าง ๆ อาจเร็นเดอร์กรณีขอบแตกต่างกัน, โดยเฉพาะเมื่อหลายเอฟเฟกต์อัลฟ่า หรือการควบคุมสีถูกรวมกัน. สำหรับผลลัพธ์สำคัญ, ควรทดสอบทั้งรอบการแก้ไขและรูปแบบส่งออกสุดท้ายด้วยเวอร์ชัน Aspose.Slides ที่ใช้ในผลิตภัณฑ์

## **FAQ**

**เอฟเฟกต์การแปลงภาพแก้ไขข้อมูลภาพที่ฝังหรือไม่?**

ไม่. การดำเนินการเป็นของ `Picture` ที่ใช้โดยส่วนเติมรูปภาพ. ไบต์ของ `PPImage` พื้นฐานยังคงไม่เปลี่ยน

**สองกรอบรูปที่ใช้แหล่งภาพเดียวกันจะแชร์เอฟเฟกต์หรือไม่?**

ไม่. การใช้ `PPImage` เดียวกันช่วยลดข้อมูลภาพซ้ำ, แต่แต่ละกรอบรูปโดยปกติมี `Picture` และคอลเลกชันการแปลงภาพแยกกัน

**สามารถรวมเอฟเฟกต์สี, ความเบลอ, และอัลฟ่าได้หรือไม่?**

ได้. คอลเลกชันรับพวกมันในโซ่ที่เรียงลำดับ. ควรพิจารณาว่าการดำเนินการแต่ละอย่างทำอะไรกับผลลัพธ์ของการดำเนินการก่อนหน้า เนื่องจากการแทนที่และการตั้งค่าขั้นreshold อาจตัดรายละเอียดสีหรืออัลฟ่าเดิมออก

**ทำไมค่าที่ได้จริงจึงเป็นแบบอ่าน‑อย่างเดียว?**

ข้อมูลที่ได้จริงเป็นค่าที่คำนวณแล้วใช้สำหรับการเร็นเดอร์, รวมถึงสีที่แก้ไขตามธีม. ให้แก้ไขการดำเนินการที่เก็บในคอลเลกชันเมื่อมีสมาชิกที่เขียนได้; หากไม่มีให้ลบและเพิ่มการแทนที่ด้วยพารามิเตอร์การสร้างใหม่

**ควรใช้รูปแบบใดเพื่อเก็บโซ่การแปลง?**

ใช้ PPTX และตรวจสอบไฟล์โดยการเปิดใหม่. PPT แบบเก่าไม่สามารถแสดงโมเดลเอฟเฟกต์ DrawingML ทั้งหมดได้, และรูปแบบส่งออกที่เร็นเดอร์จะเก็บเพียงการแสดงผล ไม่ใช่การแปลงที่แก้ไขได้