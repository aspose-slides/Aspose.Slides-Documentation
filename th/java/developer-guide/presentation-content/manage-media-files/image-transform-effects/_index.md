---
title: จัดการเอฟเฟกต์การแปลงภาพในงานนำเสนอด้วย Java
linktitle: เอฟเฟกต์การแปลงภาพ
type: docs
weight: 11
url: /th/java/image-transform-effects/
keywords:
- การแปลงภาพ
- เอฟเฟ็กต์ภาพ
- ความสว่าง
- คอนทราสต์
- ระดับสีเทา
- โทนสองสี
- สีสัน
- HSL
- การแทนที่สี
- การเบลอ
- ความโปร่งใส
- เอฟเฟกต์อัลฟา
- โซ่เอฟเฟกต์
- PowerPoint
- งานนำเสนอ
- Java
- Aspose.Slides
description: "ประยุกต์, สร้างโซ่, ตรวจสอบ, ลบ, และตรวจสอบเอฟเฟกต์การแปลงภาพสำหรับกรอบภาพด้วย Aspose.Slides สำหรับ Java."
---
## **ภาพรวม**

Aspose.Slides แทนการปรับภาพเป็นคอลเลกชันที่เรียงลำดับของการดำเนินการแปลงภาพ สำหรับกรอบภาพ ให้เริ่มต้นด้วยกรอบของ [ISlidesPicture](https://reference.aspose.com/slides/th/java/com.aspose.slides/islidespicture/) แล้วเข้าถึง [ISlidesPicture.getImageTransform](https://reference.aspose.com/slides/th/java/com.aspose.slides/islidespicture/#getImageTransform--). คอลเลกชัน [IImageTransformOperationCollection](https://reference.aspose.com/slides/th/java/com.aspose.slides/iimagetransformoperationcollection/) ที่คืนค่ามาให้คุณสามารถเพิ่ม, ตรวจสอบ, ดูรายละเอียด, ลบและเคลียร์เอฟเฟกต์ได้โดยไม่ต้องเขียนไบต์ของรูปภาพต้นฉบับใหม่

บทความนี้สาธิตขั้นตอนการทำงานครบวงจรสำหรับความสว่างและคอนทราสต์, การแปลงสี, การเบลอ, ความโปร่งใส, โซ่เอฟเฟกต์ที่เรียงลำดับ, ค่าที่มีประสิทธิภาพ, การลบ, และการตรวจสอบแบบรอบเวอร์ชัน PPTX

## **เข้าใจการเป็นเจ้าของเอฟเฟ็กต์และการใช้ภาพซ้ำ**

ทรัพยากรภาพและภาพที่แสดงมันเป็นอ็อบเจ็กต์ที่ต่างกัน:

- [IPPImage](https://reference.aspose.com/slides/th/java/com.aspose.slides/ippimage/) เก็บหรืออ้างอิงข้อมูลภาพต้นฉบับที่เป็นของงานนำเสนอ
- [ISlidesPicture](https://reference.aspose.com/slides/th/java/com.aspose.slides/islidespicture/) เป็นส่วนของการเติมรูปภาพและอ้างอิงไปยังทรัพยากรภาพพร้อมเก็บคอลเลกชันการแปลงภาพ
- [IPictureFrame](https://reference.aspose.com/slides/th/java/com.aspose.slides/ipictureframe/) คือรูปร่างบนสไลด์ที่เป็นเจ้าของการเติมรูปภาพ, รูปร่างเรขาคณิต, การครอป, และการจัดรูปแบบระดับกรอบอื่น ๆ

ดังนั้นการดำเนินการแปลงภาพจะไม่แก้ไขไบต์ใน [IPPImage](https://reference.aspose.com/slides/th/java/com.aspose.slides/ippimage/). เมื่อ `IPPImage` เดียวกันถูกส่งไปยัง [IShapeCollection.addPictureFrame](https://reference.aspose.com/slides/th/java/com.aspose.slides/ishapecollection/#addPictureFrame-int-float-float-float-float-com.aspose.slides.IPPImage-) มากกว่าหนึ่งครั้ง ทุกกรอบภาพใหม่จะได้รับ `ISlidesPicture` ของตนเองและคอลเลกชันการแปลงของตนเอง การทำให้กรอบหนึ่งเป็นสีเทาไม่ทำให้กรอบอื่นเป็นสีเทา แม้ว่ากรอบทั้งหมดจะใช้ทรัพยากรภาพที่ฝังไว้เดียวกัน

โมเดล `ISlidesPicture.getImageTransform` เดียวกันนี้ยังใช้ได้กับการเติมรูปภาพอื่น ๆ เช่น รูปร่างหรือพื้นหลังสไลด์ ตัวอย่างด้านล่างมุ่งเน้นไปที่กรอบภาพ

## **ใช้ช่วงค่าพารามิเตอร์และหน่วยที่ถูกต้อง**

วิธีการที่สาธิตใช้ช่วงความหมายและหน่วยต่อไปนี้ ให้รักษาค่าภายในช่วงเหล่านี้แม้ว่ารุ่นไลบรารีบางรุ่นอาจไม่ได้ปฏิเสธค่าที่อยู่นอกช่วงโดยทันที; รูปแบบการนำเสนอเป้าหมายอาจทำให้ค่าปรับให้เป็นมาตรฐาน, ลบออก, หรือปฏิเสธข้อมูลที่ไม่ถูกต้องระหว่างการบันทึกหรือเมื่อ PowerPoint เปิดไฟล์

| การดำเนินการ | พารามิเตอร์ | ช่วงค่าและหน่วยที่ถูกต้อง |
|---|---|---|
| [addBrightnessContrastEffect](https://reference.aspose.com/slides/th/java/com.aspose.slides/iimagetransformoperationcollection/#addBrightnessContrastEffect-float-float-) | `brightness`, `contrast` | `-100` ถึง `100` เปอร์เซ็นต์; `0` ไม่เปลี่ยนแปลงส่วนประกอบ |
| [addGrayScaleEffect](https://reference.aspose.com/slides/th/java/com.aspose.slides/iimagetransformoperationcollection/#addGrayScaleEffect--) | None | ไม่มีพารามิเตอร์เชิงตัวเลข; ค่าอัลฟาไม่เปลี่ยนแปลง |
| [addDuotoneEffect](https://reference.aspose.com/slides/th/java/com.aspose.slides/iimagetransformoperationcollection/#addDuotoneEffect--) | `color1`, `color2` | สองสีสำหรับพิกเซลมืดและสว่าง; ช่องสี RGB และอัลฟาใน `java.awt.Color` ใช้ค่า `0` ถึง `255` |
| [addTintEffect](https://reference.aspose.com/slides/th/java/com.aspose.slides/iimagetransformoperationcollection/#addTintEffect-float-float-) | `hue`, `amount` | Hue มีค่า `0` รวมถึง `360` ไม่รวม, หน่วยเป็นองศา; amount มีค่า `-100` ถึง `100` เปอร์เซ็นต์ |
| [addHSLEffect](https://reference.aspose.com/slides/th/java/com.aspose.slides/iimagetransformoperationcollection/#addHSLEffect-float-float-float-) | `hue`, `saturation`, `luminance` | Hue มีค่า `0` รวมถึง `360` ไม่รวม, หน่วยเป็นองศา; saturation และ luminance มีค่า `-100` ถึง `100` เปอร์เซ็นต์ |
| [addColorReplaceEffect](https://reference.aspose.com/slides/th/java/com.aspose.slides/iimagetransformoperationcollection/#addColorReplaceEffect--) | `color` | สีทดแทนใช้ค่าช่องจาก `0` ถึง `255`; ค่าอัลฟาเดิมไม่เปลี่ยนแปลง |
| [addBlurEffect](https://reference.aspose.com/slides/th/java/com.aspose.slides/iimagetransformoperationcollection/#addBlurEffect-double-boolean-) | `radius`, `grow` | radius ต้องเป็นค่าที่ไม่เป็นลบและวัดเป็นพอยต์; `grow` เป็น Boolean ที่ควบคุมว่าเนื้อหาที่เบลอจะขยายออกนอกขอบเดิมหรือไม่ |
| [addAlphaModulateFixedEffect](https://reference.aspose.com/slides/th/java/com.aspose.slides/iimagetransformoperationcollection/#addAlphaModulateFixedEffect-float-) | `amount` | เปอร์เซ็นต์ที่ไม่เป็นลบ; ใช้ `0` ถึง `100` สำหรับการปรับความทึบแบบปกติ: `0` 完全โปร่งใสและ `100` รักษาอัลฟาเดิม |
| [addAlphaReplaceEffect](https://reference.aspose.com/slides/th/java/com.aspose.slides/iimagetransformoperationcollection/#addAlphaReplaceEffect-float-) | `alpha` | `0` ถึง `100` เปอร์เซ็นต์ความทึบ |
| [addAlphaBiLevelEffect](https://reference.aspose.com/slides/th/java/com.aspose.slides/iimagetransformoperationcollection/#addAlphaBiLevelEffect-float-) | `threshold` | `0` ถึง `100` เปอร์เซ็นต์ค่าเกณฑ์อัลฟา; ค่าที่ต่ำกว่าจะเป็นโปร่งใส; ค่าที่เท่าหรือสูงกว่าจะเป็นทึบ |

สำหรับการปรับอัลฟ่าแบบคงที่ ความโปร่งใสและความทึบเป็นค่าตรงกันข้าม ตัวอย่างเช่น ความโปร่งใส 35% ตรงกับค่าอัลฟ่าปรับ 65%

## **ปรับความสว่างและคอนทราสต**

[IImageTransformOperationCollection.addBrightnessContrastEffect](https://reference.aspose.com/slides/th/java/com.aspose.slides/iimagetransformoperationcollection/#addBrightnessContrastEffect-float-float-) คืนค่าออบเจ็กต์ [IBrightnessContrast](https://reference.aspose.com/slides/th/java/com.aspose.slides/ibrightnesscontrast/) การตั้งค่าสเกลาร์จะถูกจัดหาเมื่อสร้างการดำเนินการ [IBrightnessContrast.getEffective](https://reference.aspose.com/slides/th/java/com.aspose.slides/ibrightnesscontrast/#getEffective--) คืนค่าที่คำนวณแล้วแบบอ่านอย่างเดียวที่สามารถตรวจสอบหรือบันทึกได้

ตัวอย่างต่อไปนี้เพิ่มความสว่าง 15% และคอนทราสต 20% แล้วแสดงตัวอย่างโดยไม่แก้ไขภาพที่ฝังไว้

```java
import com.aspose.slides.*;
import java.nio.file.Files;
import java.nio.file.Paths;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    byte[] imageData = Files.readAllBytes(Paths.get("photo.png"));
    IPPImage image = presentation.getImages().addImage(imageData);
    IPictureFrame pictureFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 50, 400, 260, image);

    IImageTransformOperationCollection imageTransform = pictureFrame.getPictureFormat().getPicture().getImageTransform();
    IBrightnessContrast brightnessContrast = imageTransform.addBrightnessContrastEffect(15f, 20f);

    IBrightnessContrastEffectiveData effectiveValues = brightnessContrast.getEffective();
    System.out.println("Brightness: " + effectiveValues.getBrightness() + "%");
    System.out.println("Contrast: " + effectiveValues.getContrast() + "%");

    IImage preview = slide.getImage();
    try {
        preview.save("brightness-contrast-preview.png", ImageFormat.Png);
    } finally {
        preview.dispose();
    }
} finally {
    presentation.dispose();
}
```

[BrightnessContrast](https://reference.aspose.com/slides/th/java/com.aspose.slides/brightnesscontrast/) เป็นส่วนขยายเอฟเฟกต์รูปภาพของ Office 2010 และมีความพกพาน้อยกว่าการเอฟเฟกต์ luminance ของ DrawingML มาตรฐาน เมื่อความสว่างและคอนทราสตต้องการให้ยังแก้ไขได้หลังการวนรอบ PPTX ให้ใช้ [IImageTransformOperationCollection.addLuminanceEffect](https://reference.aspose.com/slides/th/java/com.aspose.slides/iimagetransformoperationcollection/#addLuminanceEffect-float-float-) และตรวจสอบผลลัพธ์หลังเปิดไฟล์ใหม่ ส่วนข้อจำกัดของรูปแบบอธิบายความแตกต่างนี้อย่างละเอียดเพิ่มขึ้น

## **ปรับการแปลงสี**

เอฟเฟกต์สีสามารถนำไปใช้แยกกันกับกรอบภาพต่าง ๆ ที่ใช้ทรัพยากรภาพเดียวกัน ตัวอย่างต่อไปนี้สร้างห้ากรอบและนำไปใช้ grayscale, duotone, tint, การปรับ HSL, และการเปลี่ยนสี

[IDuotone](https://reference.aspose.com/slides/th/java/com.aspose.slides/iduotone/) มีพารามิเตอร์สีสองตัวที่แก้ไขได้อย่างอิสระ: `color1` ใช้กับพิกเซลมืด, `color2` ใช้กับพิกเซลสว่าง นี่ทำให้เป็นตัวอย่างที่ดีของเอฟเฟกต์ที่การตั้งค่าซับซ้อนกว่าค่าสเกลาร์เดียว

```java
import com.aspose.slides.*;
import java.awt.Color;
import java.nio.file.Files;
import java.nio.file.Paths;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    byte[] imageData = Files.readAllBytes(Paths.get("photo.png"));
    IPPImage image = presentation.getImages().addImage(imageData);

    IPictureFrame grayFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 20, 20, 180, 120, image);
    grayFrame.getPictureFormat().getPicture().getImageTransform().addGrayScaleEffect();

    IPictureFrame duotoneFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 220, 20, 180, 120, image);
    IDuotone duotone = duotoneFrame.getPictureFormat().getPicture().getImageTransform().addDuotoneEffect();
    duotone.getColor1().setColor(new Color(0, 0, 128));
    duotone.getColor2().setColor(new Color(255, 215, 0));

    IPictureFrame tintFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 420, 20, 180, 120, image);
    tintFrame.getPictureFormat().getPicture().getImageTransform().addTintEffect(210f, 35f);

    IPictureFrame hslFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 120, 170, 180, 120, image);
    hslFrame.getPictureFormat().getPicture().getImageTransform().addHSLEffect(30f, 20f, -10f);

    IPictureFrame replacementFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 320, 170, 180, 120, image);
    IColorReplace colorReplacement = replacementFrame.getPictureFormat().getPicture().getImageTransform().addColorReplaceEffect();
    colorReplacement.getColor().setColor(new Color(100, 149, 237));

    presentation.save("color-transformations.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

[addColorReplaceEffect](https://reference.aspose.com/slides/th/java/com.aspose.slides/iimagetransformoperationcollection/#addColorReplaceEffect--) แทนที่สีของทุกพิกเซลด้วยสีคงที่หนึ่งสีขณะรักษาอัลฟา แตกต่างจาก [addColorChangeEffect](https://reference.aspose.com/slides/th/java/com.aspose.slides/iimagetransformoperationcollection/#addColorChangeEffect--) ซึ่งแมปสีต้นฉบับหนึ่งเป็นสีเป้าหมายและเปิดเผยรูปแบบสีต้นฉบับและเป้าหมาย

## **เพิ่มบลอร์, ความโปร่งใส, และเอฟเฟ็กต์อัลฟา**

[addBlurEffect](https://reference.aspose.com/slides/th/java/com.aspose.slides/iimagetransformoperationcollection/#addBlurEffect-double-boolean-) มีผลต่อทุกช่องสีรวมถึงอัลฟา ตั้งค่า `grow` เป็น `true` เมื่อขอบเบลออาจขยายออกนอกขอบภาพเดิม

สำหรับความโปร่งใสสม่ำเสมอ ใช้ [addAlphaModulateFixedEffect](https://reference.aspose.com/slides/th/java/com.aspose.slides/iimagetransformoperationcollection/#addAlphaModulateFixedEffect-float-) ซึ่งคูณค่าอัลฟ่าเดิมทั้งหมด ทำให้พิกเซลที่โปร่งใสบางส่วนยังคงมีอัตราส่วนที่ต่างกัน [addAlphaReplaceEffect](https://reference.aspose.com/slides/th/java/com.aspose.slides/iimagetransformoperationcollection/#addAlphaReplaceEffect-float-) จะกำหนดค่าอัลฟ่าเดียวให้กับทุกพิกเซล [addAlphaBiLevelEffect](https://reference.aspose.com/slides/th/java/com.aspose.slides/iimagetransformoperationcollection/#addAlphaBiLevelEffect-float-) จะเปลี่ยนอัลฟ่าเป็นสองระดับตามค่าเกณฑ์

```java
import com.aspose.slides.*;
import java.nio.file.Files;
import java.nio.file.Paths;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    byte[] imageData = Files.readAllBytes(Paths.get("photo.png"));
    IPPImage image = presentation.getImages().addImage(imageData);

    IPictureFrame blurredFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 20, 20, 200, 140, image);
    IBlur blur = blurredFrame.getPictureFormat().getPicture().getImageTransform().addBlurEffect(4.5, true);
    blur.setRadius(5);

    IPictureFrame transparentFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 240, 20, 200, 140, image);
    IAlphaModulateFixed alphaModulate = transparentFrame.getPictureFormat().getPicture().getImageTransform().addAlphaModulateFixedEffect(65f);
    alphaModulate.setAmount(60f);

    IPictureFrame uniformAlphaFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 20, 180, 200, 140, image);
    uniformAlphaFrame.getPictureFormat().getPicture().getImageTransform().addAlphaReplaceEffect(55f);

    IPictureFrame binaryAlphaFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 240, 180, 200, 140, image);
    IAlphaBiLevel alphaBiLevel = binaryAlphaFrame.getPictureFormat().getPicture().getImageTransform().addAlphaBiLevelEffect(50f);
    alphaBiLevel.setThreshold(45f);
    binaryAlphaFrame.getPictureFormat().getPicture().getImageTransform().addAlphaInverseEffect();

    presentation.save("blur-and-alpha-effects.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

เอฟเฟกต์อัลฟ่าอื่นที่ไม่มีพารามิเตอร์ ได้แก่ [addAlphaCeilingEffect](https://reference.aspose.com/slides/th/java/com.aspose.slides/iimagetransformoperationcollection/#addAlphaCeilingEffect--) ซึ่งทำให้ทุกอัลฟ่าที่ไม่เป็นศูนย์เต็มทึบ; [addAlphaFloorEffect](https://reference.aspose.com/slides/th/java/com.aspose.slides/iimagetransformoperationcollection/#addAlphaFloorEffect--) ทำให้ทุกอัลฟ่าที่ต่ำกว่า 100% โปร่งใสเต็ม; และ [addAlphaInverseEffect](https://reference.aspose.com/slides/th/java/com.aspose.slides/iimagetransformoperationcollection/#addAlphaInverseEffect--) ซึ่งเปลี่ยนอัลฟ่าเป็น `100% - alpha`

## **สร้างโซ่เอฟเฟ็กต์ที่เรียงลำดับ**

ทุกเมธอด `add...Effect` จะเพิ่มการดำเนินการใหม่ต่อท้ายคอลเลกชัน ตัวเรนเดอร์ใช้คอลเลกชันเป็นสายการประมวลผลที่เรียงลำดับ: ผลลัพธ์ของการดำเนินการที่ 0 กลายเป็นอินพุตของการดำเนินการที่ 1, และต่อไป ดังนั้นการเรียงลำดับที่ต่างกันอาจให้ภาพที่ต่างกัน

เช่น การทำ grayscale ก่อน tint จะลบข้อมูลสีแล้วจึงทำสีใหม่บนผลลัพธ์ความสว่าง; การทำ tint ก่อน grayscale จะทำให้สี tint ถูกลบออกอีกครั้ง เช่นเดียวกัน การแทนที่อัลฟ่าสามารถเขียนทับค่าอัลฟ่าที่คำนวณจากการดำเนินการก่อนหน้า, ขณะที่การปรับอัลฟ่าจะคงระดับสัมพัทธ์เดิมไว้

ตัวอย่างต่อไปนี้สร้างโซ่สี่ขั้นตอน, บันทึกเป็น PPTX, เปิดงานนำเสนอใหม่, ตรวจสอบชนิดและลำดับของการดำเนินการ, แล้วเรนเดอร์ผลลัพธ์ที่เปิดใหม่

```java
import com.aspose.slides.*;
import java.nio.file.Files;
import java.nio.file.Paths;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    byte[] imageData = Files.readAllBytes(Paths.get("photo.png"));
    IPPImage image = presentation.getImages().addImage(imageData);
    IPictureFrame pictureFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 50, 400, 260, image);

    IImageTransformOperationCollection imageTransform = pictureFrame.getPictureFormat().getPicture().getImageTransform();
    imageTransform.addGrayScaleEffect();
    imageTransform.addTintEffect(220f, 25f);
    imageTransform.addBlurEffect(2.5, false);
    imageTransform.addAlphaModulateFixedEffect(80f);

    presentation.save("image-transform-chain.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}

Presentation reopenedPresentation = new Presentation("image-transform-chain.pptx");
try {
    IShape reopenedShape = reopenedPresentation.getSlides().get_Item(0).getShapes().get_Item(0);

    if (reopenedShape instanceof IPictureFrame) {
        IPictureFrame reopenedFrame = (IPictureFrame) reopenedShape;
        IImageTransformOperationCollection reopenedTransform = reopenedFrame.getPictureFormat().getPicture().getImageTransform();
        boolean orderIsPreserved = reopenedTransform.size() == 4 && 
                reopenedTransform.get_Item(0) instanceof IGrayScale && 
                reopenedTransform.get_Item(1) instanceof ITint && 
                reopenedTransform.get_Item(2) instanceof IBlur && 
                reopenedTransform.get_Item(3) instanceof IAlphaModulateFixed;
        System.out.println(orderIsPreserved ? "The effect chain was preserved." : "The effect chain changed during the round trip.");

        IImage renderedSlide = reopenedPresentation.getSlides().get_Item(0).getImage();
        try {
            renderedSlide.save("reopened-effect-chain.png", ImageFormat.Png);
        } finally {
            renderedSlide.dispose();
        }
    } else {
        System.out.println("The reopened shape is not a picture frame.");
    }
} finally {
    reopenedPresentation.dispose();
}
```

คอลเลกชันไม่ได้บังคับให้มีเมทริกซ์ความเข้ากันได้ที่จำกัดการดำเนินการสี, อัลฟา, และเบลอให้อยู่แยกโซ่ สามารถผสานรวมได้ แต่การผสานอาจไม่ค่อยมีประโยชน์ การแทนที่สีคงที่จะลบความแปรปรวน RGB ที่สร้างโดยเอฟเฟกต์สีก่อนหน้า; การทำ grayscale หลัง duotone จะลบสองสีที่เลือกไว้; และการทำ ceiling, floor, replacement หรือ bi‑level ของอัลฟ่าสามารถลบรายละเอียดอัลฟ่าที่สร้างมาก่อนได้ สร้างโซ่ตามลำดับการประมวลผลพิกเซลที่ต้องการ แทนการมองว่าเป็นชุดแฟล็กฟอร์แมตที่ไม่ได้เรียงลำดับ

## **ตรวจสอบค่าที่สามารถแก้ไขและค่าที่มีประสิทธิภาพ**

การดำเนินการที่แก้ไขได้คือออบเจ็กต์ที่เก็บไว้ใน `ISlidesPicture.getImageTransform` ขึ้นอยู่กับเอฟเฟกต์, อาจเปิดเผยสมาชิกที่เขียนได้โดยตรง เช่น [IBlur](https://reference.aspose.com/slides/th/java/com.aspose.slides/iblur/) เปิดเผย `radius` และ `grow` ที่เขียนได้, [IAlphaModulateFixed](https://reference.aspose.com/slides/th/java/com.aspose.slides/ialphamodulatefixed/) เปิดเผย `amount` ที่เขียนได้, และ [IAlphaBiLevel](https://reference.aspose.com/slides/th/java/com.aspose.slides/ialphabilevel/) เปิดเผย `threshold` ที่เขียนได้ เอฟเฟกต์สีเช่น [IDuotone](https://reference.aspose.com/slides/th/java/com.aspose.slides/iduotone/) เปิดเผยออบเจ็กต์ [IColorFormat](https://reference.aspose.com/slides/th/java/com.aspose.slides/icolorformat/) ที่แก้ไขได้

อินเทอร์เฟซการดำเนินการบางอย่างรวมถึง [IBrightnessContrast](https://reference.aspose.com/slides/th/java/com.aspose.slides/ibrightnesscontrast/), [IHSL](https://reference.aspose.com/slides/th/java/com.aspose.slides/ihsl/), [ITint](https://reference.aspose.com/slides/th/java/com.aspose.slides/itint/), และ [IAlphaReplace](https://reference.aspose.com/slides/th/java/com.aspose.slides/ialphareplace/) ไม่เปิดเผยสเกลาร์ที่ใช้สร้างเป็นคุณสมบัติที่เขียนได้ เพื่อเปลี่ยนการตั้งค่าเหล่านั้น ให้ลบการดำเนินการแล้วเพิ่มรายการใหม่ในตำแหน่งที่ต้องการ

ข้อมูลที่มีประสิทธิภาพที่คืนโดย `getEffective()` ถูกคำนวณและเป็นแบบอ่านอย่างเดียว มีประโยชน์สำหรับการแก้สีที่ขึ้นกับธีมและการอ่านค่าที่ทำให้เป็นมาตรฐานที่เรนเดอร์ใช้, แต่ไม่ได้เป็นพื้นผิวยังการแก้ไขเพิ่มเติม ตัวอย่างต่อไปนี้วนรอบคอลเลกชันและตรวจสอบค่าที่มีประสิทธิภาพเมื่อ API ที่เกี่ยวข้องให้ข้อมูล

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("image-transform-chain.pptx");
try {
    IPictureFrame pictureFrame = null;

    for (IShape shape : presentation.getSlides().get_Item(0).getShapes()) {
        if (shape instanceof IPictureFrame) {
            pictureFrame = (IPictureFrame) shape;
            break;
        }
    }

    if (pictureFrame != null) {
        IImageTransformOperationCollection imageTransform = pictureFrame.getPictureFormat().getPicture().getImageTransform();

        for (int index = 0; index < imageTransform.size(); index++) {
            IImageTransformOperation operation = imageTransform.get_Item(index);
            System.out.println(index + ": " + operation.getClass().getSimpleName());

            if (operation instanceof IBrightnessContrast) {
                IBrightnessContrastEffectiveData data = ((IBrightnessContrast) operation).getEffective();
                System.out.println("  Brightness: " + data.getBrightness());
                System.out.println("  Contrast: " + data.getContrast());
            } else if (operation instanceof ILuminance) {
                ILuminanceEffectiveData data = ((ILuminance) operation).getEffective();
                System.out.println("  Brightness: " + data.getBrightness());
                System.out.println("  Contrast: " + data.getContrast());
            } else if (operation instanceof IDuotone) {
                IDuotoneEffectiveData data = ((IDuotone) operation).getEffective();
                System.out.println("  Dark color: " + data.getColor1());
                System.out.println("  Light color: " + data.getColor2());
            } else if (operation instanceof IColorReplace) {
                IColorReplaceEffectiveData data = ((IColorReplace) operation).getEffective();
                System.out.println("  Replacement color: " + data.getColor());
            } else if (operation instanceof IHSL) {
                IHSLEffectiveData data = ((IHSL) operation).getEffective();
                System.out.println("  HSL: " + data.getHue() + ", " + data.getSaturation() + ", " + data.getLuminance());
            } else if (operation instanceof ITint) {
                ITintEffectiveData data = ((ITint) operation).getEffective();
                System.out.println("  Tint: " + data.getHue() + ", " + data.getAmount());
            } else if (operation instanceof IBlur) {
                IBlurEffectiveData data = ((IBlur) operation).getEffective();
                System.out.println("  Blur radius: " + data.getRadius() + " pt");
            } else if (operation instanceof IAlphaModulateFixed) {
                IAlphaModulateFixedEffectiveData data = ((IAlphaModulateFixed) operation).getEffective();
                System.out.println("  Alpha amount: " + data.getAmount() + "%");
            } else if (operation instanceof IAlphaReplace) {
                IAlphaReplaceEffectiveData data = ((IAlphaReplace) operation).getEffective();
                System.out.println("  Replacement alpha: " + data.getAlpha() + "%");
            } else if (operation instanceof IAlphaBiLevel) {
                IAlphaBiLevelEffectiveData data = ((IAlphaBiLevel) operation).getEffective();
                System.out.println("  Alpha threshold: " + data.getThreshold() + "%");
            }
        }
    }
} finally {
    presentation.dispose();
}
```

เอฟเฟกต์ที่ไม่มีพารามิเตอร์เช่น grayscale, alpha ceiling, และ alpha inverse ยังมีออบเจ็กต์ข้อมูลที่มีประสิทธิภาพ, แต่ไม่มีการตั้งค่าสเกลาร์ให้พิมพ์ออกมา ความสำคัญอยู่ที่การมีอยู่และตำแหน่งในคอลเลกชัน

## **ลบหรือเคลียร์การแปลงภาพ**

ใช้ [IImageTransformOperationCollection.removeAt](https://reference.aspose.com/slides/th/java/com.aspose.slides/iimagetransformoperationcollection/#removeAt-int-) เพื่อลบการดำเนินการหนึ่งโดยอิงดัชนี เนื่องจากดัชนีจะเปลี่ยนหลังการลบ, ควรค้นหาเป้าหมายก่อนและลบหลังจากวนรอบ ตรวจสอบ [ImageTransformOperationCollection.clear](https://reference.aspose.com/slides/th/java/com.aspose.slides/imagetransformoperationcollection/#clear--) เพื่อลบโซ่ทั้งหมด

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("image-transform-chain.pptx");
try {
    IPictureFrame pictureFrame = null;

    for (IShape shape : presentation.getSlides().get_Item(0).getShapes()) {
        if (shape instanceof IPictureFrame) {
            pictureFrame = (IPictureFrame) shape;
            break;
        }
    }

    if (pictureFrame != null) {
        IImageTransformOperationCollection imageTransform = pictureFrame.getPictureFormat().getPicture().getImageTransform();
        int blurIndex = -1;

        for (int index = 0; index < imageTransform.size(); index++) {
            if (imageTransform.get_Item(index) instanceof IBlur) {
                blurIndex = index;
                break;
            }
        }

        if (blurIndex >= 0) {
            imageTransform.removeAt(blurIndex);
            System.out.println("The blur operation was removed.");
        }

        imageTransform.clear();
        System.out.println("Remaining operations: " + imageTransform.size());
        presentation.save("image-transforms-cleared.pptx", SaveFormat.Pptx);
    }
} finally {
    presentation.dispose();
}
```

การลบหรือเคลียร์การแปลงจะเปลี่ยนเฉพาะการจัดรูปแบบของรูปภาพ ไม่ได้ลบ, บีบอัดใหม่, หรือแก้ไขทรัพยากร [IPPImage](https://reference.aspose.com/slides/th/java/com.aspose.slides/ippimage/) ที่ใช้ซ้ำ

## **พิจารณารูปแบบการนำเสนอและเป้าหมายการส่งออก**

การแปลงภาพเริ่มต้นจาก DrawingML จึงทำให้ PPTX เป็นรูปแบบที่แก้ไขได้ที่แนะนำสำหรับโซ่เอฟเฟกต์ แม้ใน PPTX ก็ไม่ใช่ทุกการดำเนินการที่มีความพกพาเท่ากัน:

- การดำเนินการ DrawingML มาตรฐานเช่น luminance, grayscale, duotone, tint, HSL, blur, และเอฟเฟกต์อัลฟ่าทั่วไป มีโอกาสสูงสุดที่จะคงอยู่หลังการวนรอบ PPTX; ควรเปิดไฟล์ที่สร้างขึ้นใหม่และตรวจสอบคอลเลกชันเมื่อความคงที่เป็นข้อกำหนด
- [BrightnessContrast](https://reference.aspose.com/slides/th/java/com.aspose.slides/brightnesscontrast/) เป็นส่วนขยายของ Office 2010 ไม่ใช่การดำเนินการ luminance ของ DrawingML มาตรฐาน สามารถใช้สำหรับเรนเดอร์ในหน่วยความจำ, แต่ไม่รับประกันว่าจะยังคงเป็น [IBrightnessContrast](https://reference.aspose.com/slides/th/java/com.aspose.slides/ibrightnesscontrast/) ที่แก้ไขได้หลังบันทึกและเปิด PPTX ใหม่ แนะนำให้ใช้ [addLuminanceEffect](https://reference.aspose.com/slides/th/java/com.aspose.slides/iimagetransformoperationcollection/#addLuminanceEffect-float-float-) สำหรับการปรับความสว่างและคอนทราสต์ที่คงอยู่
- รูปแบบไบนารี PPT มีก่อนโมเดลเอฟเฟกต์ DrawingML เต็มรูปแบบ การบันทึกเป็น PPT อาจละเว้นการดำเนินการที่ไม่สนับสนุน, ลดโซ่ให้เป็นส่วนย่อยที่สนับสนุน, หรือประมาณผลลัพธ์ อย่าใช้ PPT เป็นรูปแบบตรวจสอบสำหรับโซ่ที่ซับซ้อนและแก้ไขได้
- การเรนเดอร์เป็น PNG, JPEG, TIFF, PDF, SVG, HTML หรือรูปแบบภาพอื่น ๆ จะใช้โซ่ที่สนับสนุนเพื่อแสดงผลลัพธ์ รูปแบบเหล่านี้ไม่มี `IImageTransformOperationCollection` ที่แก้ไขได้; รูปแบบราสเตอร์จะทำให้ผลลัพธ์แบนเป็นพิกเซล, และการส่งออกเอกสาร/เวกเตอร์จะบันทึกการแสดงผลของตนเอง
- เอฟเฟกต์ไม่ทำให้รูปภาพที่ลิงก์เป็นไฟล์ที่มีตัวเองครบถ้วน การเรนเดอร์รูปภาพที่ลิงก์ยังต้องอาศัยทรัพยากรที่ลิงก์ไว้เมื่อโหลดงานนำเสนอ

ผู้บริโภคงานนำเสนอที่ต่างกันอาจเรนเดอร์กรณีขอบเขตต่างกัน, โดยเฉพาะเมื่อมีการผสานการดำเนินการอัลฟ่าหรือการควอนตั้มสีหลายขั้นตอน สำหรับผลลัพธ์ที่สำคัญ ควรทดสอบทั้งรอบการแก้ไขและรูปแบบส่งออกขั้นสุดท้ายด้วย Aspose.Slides รุ่นเดียวกับที่ใช้ในระบบผลิต

## **คำถามที่พบบ่อย**

**เอฟเฟกต์การแปลงภาพเปลี่ยนแปลงข้อมูลภาพที่ฝังไว้หรือไม่?**

ไม่. การดำเนินการเป็นของ `ISlidesPicture` ที่ใช้โดยการเติมรูปภาพ ไบต์ของ `IPPImage` ภายใต้ยังคงไม่เปลี่ยนแปลง

**สองกรอบภาพที่ใช้ `IPPImage` เดียวกันจะแชร์เอฟเฟกต์กันหรือไม่?**

ไม่. การใช้ `IPPImage` ซ้ำช่วยหลีกเลี่ยงข้อมูลภาพที่ซ้ำกัน, แต่ละกรอบภาพโดยปกติมี `ISlidesPicture` และคอลเลกชันการแปลงภาพของตนเอง

**สามารถผสานเอฟเฟกต์สี, เบลอ, และอัลฟ่าได้หรือไม่?**

ได้. คอลเลกชันรับเอฟเฟกต์เหล่านี้ในโซ่เรียงลำดับหนึ่ง ให้พิจารณาว่าแต่ละการดำเนินการทำอะไรกับผลลัพธ์ของการดำเนินการก่อนหน้า เพราะการแทนที่และการตั้งค่าเกณฑ์อาจลบรายละเอียดสีหรืออัลฟ่าที่สร้างก่อนหน้า

**ทำไมค่าที่มีประสิทธิภาพถึงเป็นแบบอ่าน‑อย่างเดียว?**

ค่าที่มีประสิทธิภาพเป็นค่าที่คำนวณแล้วใช้สำหรับการเรนเดอร์, รวมถึงสีที่ได้รับการแก้ไขแล้ว แก้ไขการดำเนินการที่เก็บในคอลเลกชันที่มีสมาชิกเขียนได้; หากไม่มีให้ลบและเพิ่มการดำเนินการใหม่พร้อมพารามิเตอร์การสร้างใหม่

**ควรใช้รูปแบบใดเพื่อคงโซ่การแปลง?**

ใช้ PPTX และตรวจสอบไฟล์โดยการเปิดใหม่อีกครั้ง PPT รุ่นเก่าไม่สามารถแสดงโมเดลเอฟเฟกต์ DrawingML เต็มรูปแบบ, และรูปแบบส่งออกที่เรนเดอร์จะคงลักษณะภาพเท่านั้น ไม่ได้เก็บการดำเนินการแปลงที่แก้ไขได้