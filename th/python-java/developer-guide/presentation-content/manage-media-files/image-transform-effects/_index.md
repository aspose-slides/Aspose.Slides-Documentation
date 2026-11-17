---
title: จัดการเอฟเฟกต์การแปลงภาพในงานนำเสนอด้วย Python
linktitle: เอฟเฟกต์การแปลงภาพ
type: docs
weight: 11
url: /th/python-java/image-transform-effects/
keywords:
- การแปลงภาพ
- เอฟเฟกต์รูปภาพ
- ความสว่าง
- ความคอนทราสต์
- เกรย์สเกล
- ดูโทน
- ทินท์
- HSL
- การแทนที่สี
- เบลอ
- ความโปร่งใส
- เอฟเฟกต์อัลฟ่า
- ห่วงโซ่เอฟเฟกต์
- PowerPoint
- งานนำเสนอ
- Python
- Java
- Aspose.Slides
description: "ใช้, เชื่อมต่อ, ตรวจสอบ, ลบ, และตรวจสอบความถูกต้องของเอฟเฟกต์การแปลงภาพสำหรับกรอบรูปภาพด้วย Aspose.Slides สำหรับ Python ผ่าน Java."
---
## **ภาพรวม**

Aspose.Slides แสดงการปรับรูปภาพเป็นคอลเลกชันที่เรียงตามลำดับของการดำเนินการแปลงภาพ. สำหรับกรอบรูปภาพ ให้เริ่มต้นด้วย [Picture](https://reference.aspose.com/slides/python-java/aspose.slides/picture/) ของกรอบและเข้าถึง [Picture.getImageTransform](https://reference.aspose.com/slides/python-java/aspose.slides/picture/#getImageTransform). คอลเลกชัน [ImageTransformOperationCollection](https://reference.aspose.com/slides/python-java/aspose.slides/imagetransformoperationcollection/) ที่ส่งกลับมาช่วยให้คุณเพิ่ม, ทำการวนซ้ำ, ตรวจสอบ, ลบ, และเคลียร์เอฟเฟกต์โดยไม่ต้องเขียนทับไบต์ของภาพต้นฉบับ.

บทความนี้แสดงขั้นตอนการทำงานเต็มรูปแบบสำหรับความสว่างและความคอนทราสต์, การแปลงสี, การเบลอ, ความโปร่งใส, ห่วงโซ่เอฟเฟกต์ตามลำดับ, ค่าที่มีผล, การลบ, และการตรวจสอบรอบ PPTX.

## **ทำความเข้าใจความเป็นเจ้าของเอฟเฟกต์และการใช้ภาพซ้ำ**

ทรัพยากรภาพและรูปภาพที่แสดงมันเป็นอ็อบเจกต์ที่แตกต่างกัน:

- [PPImage](https://reference.aspose.com/slides/python-java/aspose.slides/ppimage/) เก็บหรืออ้างอิงข้อมูลภาพต้นฉบับที่เป็นของงานนำเสนอ.
- [Picture](https://reference.aspose.com/slides/python-java/aspose.slides/picture/) เป็นส่วนของการเติมรูปภาพและอ้างอิงถึงทรัพยากรภาพขณะที่เก็บคอลเลกชันการแปลงภาพ.
- [PictureFrame](https://reference.aspose.com/slides/python-java/aspose.slides/pictureframe/) คือรูปร่างบนสไลด์ที่เป็นเจ้าของการเติมรูปภาพ, เรขาคณิต, การตั้งค่าตัด, และรูปแบบระดับกรอบอื่น ๆ.

ดังนั้นการดำเนินการแปลงภาพจะไม่เปลี่ยนแปลงไบต์ใน [PPImage](https://reference.aspose.com/slides/python-java/aspose.slides/ppimage/). เมื่อ `PPImage` เดียวกันถูกส่งผ่านไปยัง [ShapeCollection.addPictureFrame](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addPictureFrame) มากกว่าหนึ่งครั้ง, แต่ละกรอบรูปภาพใหม่จะได้รับ `Picture` ของตนเองและคอลเลกชันการแปลงของตนเอง. การใช้เกรย์สเกลกับกรอบหนึ่งไม่ได้ทำให้กรอบอื่นเป็นเกรย์สเกล, แม้ว่าทั้งหมดจะใช้ทรัพยากรภาพที่ฝังอยู่เดียวกัน.

แบบจำลอง `Picture.getImageTransform` เดียวกันยังใช้กับการเติมรูปภาพอื่น ๆ เช่น รูปร่างหรือพื้นหลังสไลด์. ตัวอย่างด้านล่างมุ่งเน้นที่กรอบรูปภาพ.

## **ใช้ช่วงค่าและหน่วยที่ถูกต้อง**

วิธีการที่สาธิตใช้ช่วงและหน่วยความหมายต่อไปนี้. ให้ค่าคงอยู่ในช่วงเหล่านี้แม้ว่าเวอร์ชันไลบรารีบางรุ่นอาจไม่ได้ปฏิเสธค่าที่อยู่นอกช่วงทันที; รูปแบบการนำเสนอเป้าหมายอาจทำให้ค่าปกติ, ตัดออก, หรือปฏิเสธข้อมูลที่ไม่ถูกต้องระหว่างการบันทึกหรือเมื่อ PowerPoint เปิดไฟล์.

| การดำเนินการ | พารามิเตอร์ | ช่วงและหน่วยที่ถูกต้อง |
|---|---|---|
| [addBrightnessContrastEffect](https://reference.aspose.com/slides/python-java/aspose.slides/imagetransformoperationcollection/#addBrightnessContrastEffect) | `brightness`, `contrast` | `-100` ถึง `100`, เปอร์เซ็นต์; `0` ทำให้คอมโพเนนท์คงเดิม |
| [addGrayScaleEffect](https://reference.aspose.com/slides/python-java/aspose.slides/imagetransformoperationcollection/#addGrayScaleEffect) | ไม่มี | ไม่มีพารามิเตอร์เชิงตัวเลข. ค่าอัลฟ่าคงเดิม |
| [addDuotoneEffect](https://reference.aspose.com/slides/python-java/aspose.slides/imagetransformoperationcollection/#addDuotoneEffect) | `color1`, `color2` | สองสีสำหรับพิกเซลมืดและสว่าง. ช่องสี RGB และอัลฟ่าใน `java.awt.Color` ใช้ค่า `0` ถึง `255` |
| [addTintEffect](https://reference.aspose.com/slides/python-java/aspose.slides/imagetransformoperationcollection/#addTintEffect) | `hue`, `amount` | Hue ตั้งแต่ `0` รวมถึงถึง `360` ไม่รวม, หน่วยเป็นองศ; amount ตั้งแต่ `-100` ถึง `100`, เปอร์เซ็นต์ |
| [addHSLEffect](https://reference.aspose.com/slides/python-java/aspose.slides/imagetransformoperationcollection/#addHSLEffect) | `hue`, `saturation`, `luminance` | Hue ตั้งแต่ `0` รวมถึงถึง `360` ไม่รวม, หน่วยเป็นองศ; saturation และ luminance ตั้งแต่ `-100` ถึง `100`, เปอร์เซ็นต์ |
| [addColorReplaceEffect](https://reference.aspose.com/slides/python-java/aspose.slides/imagetransformoperationcollection/#addColorReplaceEffect) | `color` | สีที่แทนที่ใช้ค่าช่องตั้งแต่ `0` ถึง `255`. ค่าอัลฟ่าที่มีอยู่คงเดิม |
| [addBlurEffect](https://reference.aspose.com/slides/python-java/aspose.slides/imagetransformoperationcollection/#addBlurEffect) | `radius`, `grow` | รัศมีต้องเป็นค่าที่ไม่เป็นลบและวัดเป็นพอยท์; `grow` เป็น Boolean ที่กำหนดว่าคอนเทนต์ที่เบลออาจขยายออกนอกขอบเดิมหรือไม่ |
| [addAlphaModulateFixedEffect](https://reference.aspose.com/slides/python-java/aspose.slides/imagetransformoperationcollection/#addAlphaModulateFixedEffect) | `amount` | เปอร์เซ็นต์ที่ไม่เป็นลบ. ใช้ `0` ถึง `100` สำหรับการสเกลความทึบปกติ: `0` โปร่งใสเต็ม, `100` คงค่าอัลฟ่าที่มี |
| [addAlphaReplaceEffect](https://reference.aspose.com/slides/python-java/aspose.slides/imagetransformoperationcollection/#addAlphaReplaceEffect) | `alpha` | `0` ถึง `100`, เปอร์เซ็นต์ความทึบ |
| [addAlphaBiLevelEffect](https://reference.aspose.com/slides/python-java/aspose.slides/imagetransformoperationcollection/#addAlphaBiLevelEffect) | `threshold` | `0` ถึง `100`, เปอร์เซ็นต์ค่าอัลฟ่าที่เป็นเกณฑ์. ค่าต่ำกว่าจะโปร่งใส; ค่าที่เท่าหรือสูงกว่าจะทึบ |

สำหรับการมอดูเลตอัลฟ่าคงที่, ความโปร่งใสและความทึบเป็นค่าตรงข้าม. ตัวอย่างเช่น ความโปร่งใส 35% เทียบกับค่ามอดูเลตอัลฟ่า 65%.

## **ใช้ความสว่างและความคอนทราสต์**

[ImageTransformOperationCollection.addBrightnessContrastEffect](https://reference.aspose.com/slides/python-java/aspose.slides/imagetransformoperationcollection/#addBrightnessContrastEffect) จะคืนค่าออบเจกต์ [BrightnessContrast](https://reference.aspose.com/slides/python-java/aspose.slides/brightnesscontrast/) การตั้งค่าสเกลาร์จะถูกส่งเมื่อสร้างออบเจกต์. [BrightnessContrast.getEffective](https://reference.aspose.com/slides/python-java/aspose.slides/brightnesscontrast/#getEffective) คืนค่าที่คำนวณแล้วแบบอ่านอย่างเดียวซึ่งสามารถตรวจสอบหรือบันทึกได้.

ตัวอย่างต่อไปนี้เพิ่มความสว่าง 15% และความคอนทราสต์ 20%, จากนั้นเรนเดอร์พรีวิวโดยไม่แก้ไขภาพฝัง:

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

[BrightnessContrast](https://reference.aspose.com/slides/python-java/aspose.slides/brightnesscontrast/) เป็นส่วนขยายเอฟเฟกต์รูปภาพ Office 2010 และพกพาน้อยกว่าการเอฟเฟกต์ luminance ของ DrawingML มาตรฐาน. เมื่อความสว่างและความคอนทราสต์ต้องการให้แก้ไขได้หลังการรอบ PPTX, ให้ใช้ [ImageTransformOperationCollection.addLuminanceEffect](https://reference.aspose.com/slides/python-java/aspose.slides/imagetransformoperationcollection/#addLuminanceEffect) และตรวจสอบผลหลังเปิดไฟล์ใหม่. ส่วนข้อจำกัดของรูปแบบอธิบายความแตกต่างนี้อย่างละเอียด.

## **ใช้การแปลงสี**

เอฟเฟกต์สีสามารถใช้แยกกันกับกรอบรูปภาพที่ใช้ทรัพยากรภาพเดียวกัน. ตัวอย่างต่อไปนี้สร้างห้าเฟรมและใช้เกรย์สเกล, ดูโทน, ทินท์, การปรับ HSL, และการแทนที่สี.

[Duotone](https://reference.aspose.com/slides/python-java/aspose.slides/duotone/) มีพารามิเตอร์สีสองค่าให้แก้ไขได้อย่างอิสระ: `color1` ใช้กับพิกเซลมืด, `color2` ใช้กับพิกเซลสว่าง. ตัวอย่างนี้จึงเป็นตัวอย่างที่ดีของเอฟเฟกต์ที่การตั้งค่าซับซ้อนกว่าค่าสเกลาร์เดียว.

```python
import jpype
import asposeslides
from pathlib import Path

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    image_data = Path("photo.png").read_bytes()
    image_bytes = jpype.JArray(jpype.JByte)(image_data)
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

[addColorReplaceEffect](https://reference.aspose.com/slides/python-java/aspose.slides/imagetransformoperationcollection/#addColorReplaceEffect) แทนที่สีของทุกพิกเซลด้วยสีคงที่หนึ่งสีขณะคงค่าอัลฟ่าไว้. มันแตกต่างจาก [addColorChangeEffect](https://reference.aspose.com/slides/python-java/aspose.slides/imagetransformoperationcollection/#addColorChangeEffect) ที่แมพสีต้นทางหนึ่งเป็นสีปลายทางและเปิดเผยรูปแบบสีของทั้งสอง.

### **ใช้เกณฑ์ความสว่าง**

เกณฑ์ความสว่างสามารถทำให้เครื่องหมายที่จางบนหน้าสแกนง่ายต่อการแยกจากพื้นหลัง. [addGrayScaleEffect](https://reference.aspose.com/slides/python-java/aspose.slides/imagetransformoperationcollection/#addGrayScaleEffect) คงระดับสีเทากลาง. [addBiLevelEffect](https://reference.aspose.com/slides/python-java/aspose.slides/imagetransformoperationcollection/#addBiLevelEffect) แมพความสว่างเป็นสีดำหรือสีขาว, ในขณะที่ [addAlphaBiLevelEffect](https://reference.aspose.com/slides/python-java/aspose.slides/imagetransformoperationcollection/#addAlphaBiLevelEffect) ใช้เกณฑ์กับความทึบ.

เกณฑ์ความสว่างอยู่ระหว่าง 0% ถึง 100% (รวม). พิกเซลที่ต่ำกว่ากำหนดจะเป็นสีดำ. พิกเซลที่เท่าหรือสูงกว่าจะเป็นสีขาว. การยกเกณฑ์ทำให้เงาที่อยู่ระหว่างสีต่าง ๆ กลายเป็นสีดำมากขึ้นเพราะมากกว่าหนึ่งส่วนตกต่ำกว่าเกณฑ์.

ดาวน์โหลด [grayscale-swatches.png](grayscale-swatches.png) ไปยังโฟลเดอร์ทำงาน. แต่ละป้ายกำกับแสดงระดับสีเทาต้นฉบับบนสเกล 0‑255. ตัวอย่างวางภาพต้นฉบับข้างสองสำเนาและบันทึกเกณฑ์ของแต่ละสำเนาในงานนำเสนอ.

```python
import jpype
import asposeslides
from pathlib import Path

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType, SlideSizeScaleType

presentation = Presentation()
try:
    presentation.getSlideSize().setSize(720.0, 150.0, SlideSizeScaleType.DoNotScale)
    shapes = presentation.getSlides().get_Item(0).getShapes()

    image_data = Path("grayscale-swatches.png").read_bytes()
    image_bytes = jpype.JArray(jpype.JByte)(image_data)
    image = presentation.getImages().addImage(image_bytes)

    frames = []
    for index, caption in enumerate(("Original", "Threshold 20%", "Threshold 60%")):
        x = 12 + 240 * index
        label = shapes.addAutoShape(ShapeType.Rectangle, x, 12, 216, 36)
        label.getTextFrame().setText(caption)
        frame = shapes.addPictureFrame(ShapeType.Rectangle, x, 60, 216, 72, image)
        frames.append(frame)

    frames[1].getPictureFormat().getPicture().getImageTransform().addBiLevelEffect(20.0)
    frames[2].getPictureFormat().getPicture().getImageTransform().addBiLevelEffect(60.0)

    presentation.save("luminance-threshold.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

เปิดงานนำเสนอผลลัพธ์ใน PowerPoint เพื่อเปรียบเทียบสามเฟรม. ตัวอย่างสีเทาที่มีป้ายกำกับ 96 มีความสว่างประมาณ 38% (96 จาก 255). มันกลายเป็นสีขาวที่เกณฑ์ 20% และเป็นสีดำที่เกณฑ์ 60%.

![Original grayscale swatches beside the black-and-white results at luminance thresholds of 20% and 60%](luminance-threshold.png)

## **เพิ่มบลอร์, ความโปร่งใส, และเอฟเฟกต์อัลฟ่า**

[addBlurEffect](https://reference.aspose.com/slides/python-java/aspose.slides/imagetransformoperationcollection/#addBlurEffect) มีผลต่อทุกช่องสีรวมถึงอัลฟ้า. ตั้งค่า `grow` เป็น `True` เมื่อขอบที่เบลออาจขยายออกนอกขอบรูปภาพเดิม.

สำหรับความโปร่งใสแบบสม่ำเสมอ, ใช้ [addAlphaModulateFixedEffect](https://reference.aspose.com/slides/python-java/aspose.slides/imagetransformoperationcollection/#addAlphaModulateFixedEffect). มันคูณค่าอัลฟ่าที่มีอยู่ทุกค่า, ทำให้พิกเซลที่โปร่งใสบางส่วนยังคงต่างกันตามสัดส่วน. [addAlphaReplaceEffect](https://reference.aspose.com/slides/python-java/aspose.slides/imagetransformoperationcollection/#addAlphaReplaceEffect) แทนที่ค่าอัลฟ่าเดียวให้กับทุกพิกเซล. [addAlphaBiLevelEffect](https://reference.aspose.com/slides/python-java/aspose.slides/imagetransformoperationcollection/#addAlphaBiLevelEffect) แปลงอัลฟ่าเป็นสองระดับตามเกณฑ์.

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

การดำเนินการอัลฟ่าอื่น ๆ ที่ไม่มีพารามิเตอร์ ได้แก่ [addAlphaCeilingEffect](https://reference.aspose.com/slides/python-java/aspose.slides/imagetransformoperationcollection/#addAlphaCeilingEffect) ซึ่งทำให้ค่าอัลฟ่าไม่เป็นศูนย์ทั้งหมดเต็มทึบ; [addAlphaFloorEffect](https://reference.aspose.com/slides/python-java/aspose.slides/imagetransformoperationcollection/#addAlphaFloorEffect) ซึ่งทำให้ค่าอัลฟ่าต่ำกว่า 100% ทั้งหมดเป็นโปร่งใสเต็ม; และ [addAlphaInverseEffect](https://reference.aspose.com/slides/python-java/aspose.slides/imagetransformoperationcollection/#addAlphaInverseEffect) ซึ่งเปลี่ยนอัลฟ่าเป็น `100% - alpha`.

## **สร้างห่วงโซ่เอฟเฟกต์ตามลำดับ**

ทุกเมธอด `add...Effect` จะต่อเติมการดำเนินการใหม่ลงท้ายคอลเลกชัน. ตัวเรนเดอร์ใช้คอลเลกชันเป็นสายการประมวลผลตามลำดับ: ผลลัพธ์ของการดำเนินการ 0 จะเป็นอินพุตของการดำเนินการ 1, และต่อไป. ดังนั้นการใช้การดำเนินการเดียวกันในลำดับที่ต่างกันอาจให้ภาพที่แตกต่างกัน.

เช่น เกรย์สเกลตามด้วยทินท์จะลบข้อมูลสีก่อนแล้วค่อยทำสีใหม่บนผลลัพธ์ความสว่าง. ทินท์ตามด้วยเกรย์สเกลจะลบทินท์ออกอีกครั้ง. ในทำนองเดียวกัน การแทนที่อัลฟ่าอาจเขียนทับค่าอัลฟ่าที่คำนวนจากการดำเนินการก่อนหน้า, ในขณะที่การมอดูเลตอัลฟ่าจะคงความแตกต่างสัมพัทธ์ของพวกมันไว้.

ตัวอย่างต่อไปนี้สร้างห่วงโซ่สี่ขั้นตอน, บันทึกเป็น PPTX, เปิดงานนำเสนอใหม่, ตรวจสอบประเภทและลำดับของการดำเนินการ, แล้วเรนเดอร์ผลลัพธ์ที่เปิดใหม่:

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

คอลเลกชันไม่ได้บังคับให้มีเมทริกซ์ความเข้ากันที่จำกัดการทำงานของสี, อัลฟ่า, และบลอร์ให้อยู่ในห่วงโซ่แยกต่างหาก. สามารถรวมกันได้, แต่การรวมอาจไม่ค่อยมีประโยชน์. การแทนที่สีคงที่จะลบความแปรผัน RGB ที่สร้างโดยเอฟเฟกต์สีก่อนหน้า; เกรย์สเกลหลังจากดูโทนจะลบสองสีที่เลือก; การมอดูเลตอัลฟ่า, เพดาน, พื้น, หรือการทำอัลฟ่าแบบสองระดับสามารถทิ้งรายละเอียดอัลฟ่าที่สร้างก่อนหน้า. ให้สร้างห่วงโซ่ตามลำดับการประมวลผลพิกเซลที่ต้องการ แทนที่จะมองรายการเป็นแฟล็กรูปแบบที่ไม่มีลำดับ.

<!-- visual-explanation:image-transform-effects:start -->
[![The same image passes through grayscale then tint, and tint then grayscale. The two final grayscale images have different tones.](visual-image-transform-effects-49aa72211f3a.svg)](visual-image-transform-effects-49aa72211f3a.svg)

*In this illustrative Aspose.Slides for .NET 26.11 render, a 220° tint at 25% leaves the grayscale image unchanged. Applying the same tint before grayscale produces different tones.*
<!-- visual-explanation:image-transform-effects:end -->

## **ตรวจสอบค่าที่แก้ไขได้และค่าที่มีผล**

การดำเนินการที่แก้ไขได้คือออบเจกต์ที่เก็บไว้ใน `Picture.getImageTransform`. ขึ้นอยู่กับเอฟเฟกต์, มันอาจเปิดเผยสมาชิกที่เขียนได้โดยตรง. ตัวอย่างเช่น, [Blur](https://reference.aspose.com/slides/python-java/aspose.slides/blur/) เปิดเผยค่าเขียนได้ `radius` และ `grow`, [AlphaModulateFixed](https://reference.aspose.com/slides/python-java/aspose.slides/alphamodulatefixed/) เปิดเผย `amount`, และ [AlphaBiLevel](https://reference.aspose.com/slides/python-java/aspose.slides/alphabilevel/) เปิดเผย `threshold`. เอฟเฟกต์สีเช่น [Duotone](https://reference.aspose.com/slides/python-java/aspose.slides/duotone/) เปิดเผยออบเจกต์ [ColorFormat](https://reference.aspose.com/slides/python-java/aspose.slides/colorformat/) ที่เปลี่ยนแปลงได้.

คลาสการดำเนินการบางอย่างรวมถึง [BrightnessContrast](https://reference.aspose.com/slides/python-java/aspose.slides/brightnesscontrast/), [HSL](https://reference.aspose.com/slides/python-java/aspose.slides/hsl/), [Tint](https://reference.aspose.com/slides/python-java/aspose.slides/tint/), และ [AlphaReplace](https://reference.aspose.com/slides/python-java/aspose.slides/alphareplace/) ไม่เปิดเผยสเกลาร์การสร้างเป็นคุณสมบัติที่เขียนได้. เพื่อเปลี่ยนการตั้งค่าเหล่านั้น, ให้ลบการดำเนินการแล้วเพิ่มการแทนที่ในตำแหน่งที่ต้องการ.

ข้อมูลที่ได้จาก `getEffective` ถูกคำนวนและเป็นค่าอ่าน‑อย่าง‑เดียว. มันมีประโยชน์สำหรับการแก้ไขสีที่อิงธีมและการอ่านค่าที่ทำให้เป็นมาตรฐานที่เรนเดอร์ใช้, แต่ไม่ใช่พื้นผิวการแก้ไขอื่น. ตัวอย่างต่อไปนี้วนซ้ำห่วงโซ่และตรวจสอบค่าที่มีผลในที่ API ให้:

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

เอฟเฟกต์ที่ไม่มีพารามิเตอร์เช่นเกรย์สเกล, เพดานอัลฟ่า, และอินเวอร์สอัลฟ่ายังมีออบเจกต์ข้อมูลที่มีผล, แต่ไม่มีการตั้งค่าสเกลาร์ให้พิมพ์. การมีอยู่และตำแหน่งของพวกมันในคอลเลกชันคือข้อมูลสำคัญ.

## **ลบหรือเคลียร์การแปลงภาพ**

ใช้ [ImageTransformOperationCollection.removeAt](https://reference.aspose.com/slides/python-java/aspose.slides/imagetransformoperationcollection/#removeAt) เพื่อลบการดำเนินการหนึ่งด้วยดัชนี. เนื่องจากดัชนีจะเปลี่ยนหลังการลบ, ควรค้นหาเป้าหมายก่อนแล้วลบหลังจากวนซ้ำ. ใช้ [ImageTransformOperationCollection.clear](https://reference.aspose.com/slides/python-java/aspose.slides/imagetransformoperationcollection/#clear) เพื่อลบห่วงโซ่ทั้งหมด.

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

การลบหรือเคลียร์การแปลงจะเปลี่ยนเฉพาะการจัดรูปแบบรูปภาพ. มันไม่ได้ลบ, บีบอัดใหม่, หรือแก้ไขทรัพยากร [PPImage](https://reference.aspose.com/slides/python-java/aspose.slides/ppimage/) ที่ใช้ซ้ำ.

## **พิจารณารูปแบบการนำเสนอและเป้าหมายการส่งออก**

การแปลงภาพมาจาก DrawingML, ดังนั้น PPTX เป็นรูปแบบแก้ไขที่แนะนำสำหรับห่วงโซ่เอฟเฟกต์. แม้ใน PPTX, การดำเนินการแต่ละอย่างอาจมีความพกพาที่ต่างกัน:

- การดำเนินการ DrawingML มาตรฐานเช่น luminance, grayscale, duotone, tint, HSL, blur, และเอฟเฟกต์อัลฟ่าทั่วไปมีโอกาสอยู่รอดสูงสุดหลังรอบ PPTX. ควรเปิดไฟล์ที่สร้างใหม่และตรวจสอบคอลเลกชันเมื่อความคงที่เป็นข้อกำหนด.
- [BrightnessContrast](https://reference.aspose.com/slides/python-java/aspose.slides/brightnesscontrast/) เป็นส่วนขยาย Office 2010 แทนการดำเนินการ luminance ของ DrawingML มาตรฐาน. สามารถใช้สำหรับเรนเดอร์ในหน่วยความจำ, แต่ไม่รับประกันว่าจะคงเป็น [BrightnessContrast](https://reference.aspose.com/slides/python-java/aspose.slides/brightnesscontrast/) ที่แก้ไขได้หลังบันทึกและเปิดใหม่ PPTX. ควรใช้ [addLuminanceEffect](https://reference.aspose.com/slides/python-java/aspose.slides/imagetransformoperationcollection/#addLuminanceEffect) สำหรับการปรับความสว่างและความคอนทราสต์ที่คงอยู่.
- รูปแบบ PPT ไบนารีเกิดมาก่อนโมเดลเอฟเฟกต์ DrawingML ครบถ้วน. การบันทึกเป็น PPT อาจละเว้นการดำเนินการที่ไม่รองรับ, ลดห่วงโซ่ลงเป็นส่วนย่อยที่รองรับ, หรือประมาณลักษณะภาพ. อย่าใช้ PPT เป็นรูปแบบตรวจสอบสำหรับห่วงโซ่แก้ไขที่ซับซ้อน.
- การเรนเดอร์เป็น PNG, JPEG, TIFF, PDF, SVG, HTML, หรือรูปแบบภาพอื่น ๆ จะใช้ห่วงโซ่ที่รองรับเพื่อสร้างลักษณะภาพที่เรนเดอร์. ผลลัพธ์เหล่านั้นไม่มี `ImageTransformOperationCollection` ที่แก้ไขได้; รูปแบบราสเตอร์จะทำให้ผลลัพธ์แบนเป็นพิกเซล, และการส่งออกเอกสาร/เวกเตอร์จะเก็บตัวแทนการเรนเดอร์ของตนเอง.
- เอฟเฟกต์ไม่ทำให้ภาพที่ลิงก์เป็นอิสระ. การเรนเดอร์รูปภาพที่ลิงก์ยังคงขึ้นกับทรัพยากรที่ลิงก์ต้องพร้อมใช้งานเมื่อโหลดงานนำเสนอ.

ผู้ใช้การนำเสนอที่ต่างกันอาจเรนเดอร์กรณีขอบต่างกัน, โดยเฉพาะเมื่อรวมหลายการดำเนินการอัลฟ่าหรือการควอนตั้มสี. สำหรับผลลัพธ์สำคัญ, ควรทดสอบทั้งรอบแก้ไขและรูปแบบส่งออกสุดท้ายด้วยเวอร์ชัน Aspose.Slides ที่ใช้ในผลิตภัณฑ์.

## **FAQ**

**เอฟเฟกต์การแปลงภาพแก้ไขข้อมูลภาพฝังหรือไม่?**

ไม่. การดำเนินการเป็นของ `Picture` ที่ใช้โดยการเติมรูปภาพ. ไบต์ `PPImage` พื้นฐานคงเดิมไม่มีการเปลี่ยนแปลง.

**สองกรอบรูปภาพที่ใช้ภาพเดียวกันจะแบ่งปันเอฟเฟกต์หรือไม่?**

ไม่. การใช้ `PPImage` ซ้ำช่วยหลีกเลี่ยงข้อมูลภาพซ้ำซ้อน, แต่แต่ละกรอบรูปภาพโดยปกติมี `Picture` และคอลเลกชันการแปลงภาพแยกกัน.

**สามารถรวมเอฟเฟกต์สี, บลอร์, และอัลฟ่าได้หรือไม่?**

ได้. คอลเลกชันรับพวกมันในห่วงโซ่เรียงลำดับหนึ่ง. ควรพิจารณาว่าแต่ละการดำเนินการทำอะไรกับผลลัพธ์ของการดำเนินการก่อนหน้า เพราะการแทนที่และการทำเกณฑ์อาจลบรายละเอียดสีหรืออัลฟ่าที่สร้างก่อนหน้า.

**ทำไมค่าที่มีผลถึงเป็นแบบอ่าน‑อย่าง‑เดียว?**

ค่าที่มีผลเป็นค่าที่คำนวนเพื่อการเรนเดอร์, รวมถึงสีที่แก้ไขแล้ว. ให้แก้ไขการดำเนินการที่เก็บในคอลเลกชันที่มีสมาชิกเขียนได้; หากไม่มี, ให้ลบแล้วเพิ่มการแทนที่ด้วยพารามิเตอร์สร้างใหม่.

**ควรใช้รูปแบบใดเพื่อคงห่วงโซ่การแปลง?**

ใช้ PPTX และตรวจสอบไฟล์โดยเปิดใหม่. PPT รุ่นเก่าจะไม่สามารถแสดงโมเดลเอฟเฟกต์ DrawingML เต็มรูปแบบ, ส่วนรูปแบบส่งออกที่เรนเดอร์จะคงลักษณะภาพแต่ไม่คงการแปลงที่แก้ไขได้.