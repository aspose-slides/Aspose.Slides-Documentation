---
title: จัดการเอฟเฟกต์การแปลงภาพในงานนำเสนอบน Android
linktitle: เอฟเฟกต์การแปลงภาพ
type: docs
weight: 11
url: /th/androidjava/image-transform-effects/
keywords:
- การแปลงภาพ
- เอฟเฟกต์รูปภาพ
- ความสว่าง
- คอนทราสต์
- ระดับสีเทา
- สองโทน
- สีเฉด
- HSL
- การแทนที่สี
- เบลอ
- ความโปร่งใส
- เอฟเฟกต์แอลฟา
- เชนเอฟเฟกต์
- PowerPoint
- งานนำเสนอ
- Android
- Java
- Aspose.Slides
description: "นำไปใช้, สร้างเชน, ตรวจสอบ, ลบ, และตรวจสอบเอฟเฟกต์การแปลงภาพสำหรับกรอบรูปด้วย Aspose.Slides สำหรับ Android ผ่าน Java."
---
## **ภาพรวม**

Aspose.Slides แสดงการปรับภาพเป็นคอลเลกชันที่เรียงลำดับของการดำเนินการแปลงภาพ สำหรับกรอบรูป ให้เริ่มต้นด้วยกรอบของ [ISlidesPicture](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islidespicture/) และเข้าถึง [ISlidesPicture.getImageTransform](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islidespicture/#getImageTransform--). คอลเลกชันที่คืนค่า [IImageTransformOperationCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/) ให้คุณเพิ่ม, เรียง, ตรวจสอบ, ลบและล้างเอฟเฟกต์โดยไม่ต้องเขียนไบต์ภาพต้นฉบับใหม่

บทความนี้แสดงกระบวนการทำงานครบชุดสำหรับความสว่างและคอนทราสต์, การแปลงสี, เบลอ, ความโปร่งใส, เชนเอฟเฟกต์ที่เรียงลำดับ, ค่าที่มีผล, การลบ, และการตรวจสอบรอบการทำงาน PPTX

## **ทำความเข้าใจการเป็นเจ้าของเอฟเฟกต์และการใช้ภาพซ้ำ**

- [IPPImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ippimage/) เก็บหรืออ้างอิงข้อมูลภาพต้นฉบับที่เป็นของงานนำเสนอ
- [ISlidesPicture](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islidespicture/) เป็นส่วนหนึ่งของการเติมรูปภาพและอ้างอิงถึงทรัพยากรภาพขณะเก็บคอลเลกชันการแปลงภาพ
- [IPictureFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipictureframe/) คือรูปร่างสไลด์ที่เป็นเจ้าของการเติมรูปภาพที่เกี่ยวข้อง, รูปร่างเรขาคณิต, การตั้งค่าการครอบตัด, และการจัดรูปแบบระดับกรอบอื่นๆ

ดังนั้น การดำเนินการแปลงภาพจะไม่แก้ไขไบต์ใน [IPPImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ippimage/). เมื่อ `IPPImage` เดียวกันถูกส่งไปยัง [IShapeCollection.addPictureFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/#addPictureFrame-int-float-float-float-float-com.aspose.slides.IPPImage-) มากกว่าหนึ่งครั้ง, แต่ละกรอบรูปใหม่จะได้รับ `ISlidesPicture` ของตนเองและคอลเลกชันแปลงของตนเอง การนำ grayscale ไปใช้กับกรอบหนึ่งจะไม่ทำให้กรอบอื่นเป็น grayscale แม้ว่าทั้งหมดจะใช้ทรัพยากรภาพที่ฝังด้วยเดียวกัน

โมเดล `ISlidesPicture.getImageTransform` เดียวกันนี้ยังถูกใช้โดยการเติมรูปภาพอื่น ๆ เช่น รูปทรงหรือพื้นหลังสไลด์ ตัวอย่างด้านล่างมุ่งเน้นที่กรอบรูป

## **ใช้ช่วงพารามิเตอร์และหน่วยที่ถูกต้อง**

วิธีที่แสดงใช้ช่วงและหน่วยตามความหมายต่อไปนี้ คงค่าภายในช่วงเหล่านี้แม้ไลบรารีเวอร์ชันใดอาจไม่ปฏิเสธค่าที่อยู่นอกช่วงทันที; รูปแบบการนำเสนอเป้าหมายอาจทำให้ค่าปกติ, ลบ, หรือปฏิเสธข้อมูลที่ไม่ถูกต้องระหว่างการบันทึกหรือเมื่อ PowerPoint เปิดไฟล์

| การดำเนินการ | พารามิเตอร์ | ช่วงและหน่วยที่ถูกต้อง |
|---|---|---|
| [addBrightnessContrastEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addBrightnessContrastEffect-float-float-) | `brightness`, `contrast` | `-100` ถึง `100` เปอร์เซ็นต์; `0` ไม่เปลี่ยนส่วนประกอบ |
| [addGrayScaleEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addGrayScaleEffect--) | None | ไม่มีพารามิเตอร์เชิงตัวเลข. แอลฟ่าจะไม่เปลี่ยน |
| [addDuotoneEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addDuotoneEffect--) | `color1`, `color2` | สองสีสำหรับพิกเซลสีเข้มและสีอ่อน. ค่าช่อง RGB และแอลฟ่าที่ใช้โดย `android.graphics.Color` มีช่วงตั้งแต่ `0` ถึง `255` |
| [addTintEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addTintEffect-float-float-) | `hue`, `amount` | ค่า hue มีตั้งแต่ `0` (รวม) ถึง `360` (ไม่รวม) หน่วยองศา; จำนวน `amount` มีช่วง `-100` ถึง `100` เปอร์เซ็นต์ |
| [addHSLEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addHSLEffect-float-float-float-) | `hue`, `saturation`, `luminance` | ค่า hue มีตั้งแต่ `0` (รวม) ถึง `360` (ไม่รวม) หน่วยองศา; ความอิ่มตัวและความสว่างมีช่วง `-100` ถึง `100` เปอร์เซ็นต์ |
| [addColorReplaceEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addColorReplaceEffect--) | `color` | สีแทนที่ใช้ค่าช่องตั้งแต่ `0` ถึง `255`. ค่าแอลฟ่าที่มีอยู่จะไม่เปลี่ยน |
| [addBlurEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addBlurEffect-double-boolean-) | `radius`, `grow` | รัศมีต้องไม่เป็นค่าติดลบและวัดเป็นจุด; `grow` เป็น Boolean ที่กำหนดว่าภาพเบลออาจขยายเกินขอบเดิมหรือไม่ |
| [addAlphaModulateFixedEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addAlphaModulateFixedEffect-float-) | `amount` | เปอร์เซ็นต์ที่ไม่เป็นค่าติดลบ. ใช้ `0` ถึง `100` สำหรับการปรับความทึบแสงธรรมดา: `0` เป็นโปร่งใสเต็มที่และ `100` รักษาแอลฟ่าที่มีอยู่ |
| [addAlphaReplaceEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addAlphaReplaceEffect-float-) | `alpha` | `0` ถึง `100` เปอร์เซ็นต์ความทึบแสง |
| [addAlphaBiLevelEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addAlphaBiLevelEffect-float-) | `threshold` | `0` ถึง `100` เปอร์เซ็นต์เกณฑ์แอลฟา. ค่าใต้นั้นจะกลายเป็นโปร่งใส; ค่าเท่ากับหรือมากกว่าจะกลายเป็นทึบ |

สำหรับการปรับแอลฟ่าคงที่ ความโปร่งใสและความทึบแสงเป็นค่าตรงกันข้าม ตัวอย่างเช่น ความโปร่งใส 35% ตรงกับจำนวนการปรับแอลฟ่า 65%

## **ใช้ความสว่างและคอนทราสต์**

[IImageTransformOperationCollection.addBrightnessContrastEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addBrightnessContrastEffect-float-float-) คืนค่าการดำเนินการ [IBrightnessContrast](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibrightnesscontrast/). ค่าตัวสเกลจะถูกกำหนดเมื่อสร้างการดำเนินการ. [BrightnessContrast.getEffective](https://reference.aspose.com/slides/androidjava/com.aspose.slides/brightnesscontrast/#getEffective--) คืนค่าที่คำนวณแล้วแบบอ่านอย่างเดียวที่สามารถตรวจสอบหรือบันทึกได้

ตัวอย่างต่อไปนี้เพิ่มความสว่าง 15% และคอนทราสต์ 20% จากนั้นแสดงตัวอย่างโดยไม่แก้ไขภาพที่ฝังไว้

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IPPImage image;
    IImage sourceImage = Images.fromFile("photo.png");
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        sourceImage.dispose();
    }
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

[BrightnessContrast](https://reference.aspose.com/slides/androidjava/com.aspose.slides/brightnesscontrast/) เป็นส่วนขยายเอฟเฟกต์รูปภาพของ Office 2010 และมีความพกพาน้อยกว่าการเอฟเฟกต์ luminance ของ DrawingML มาตรฐาน เมื่อความสว่างและคอนทราสต์ต้องการให้แก้ไขได้หลังการรอบ PPTX ให้ใช้ [IImageTransformOperationCollection.addLuminanceEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addLuminanceEffect-float-float-) และตรวจสอบผลลัพธ์หลังจากเปิดไฟล์ใหม่ ส่วนข้อจำกัดของรูปแบบอธิบายความแตกต่างนี้โดยละเอียด

## **ใช้การแปลงสี**

เอฟเฟกต์สีสามารถนำไปใช้แยกกันกับกรอบรูปต่าง ๆ ที่ใช้ทรัพยากรภาพเดียวกัน ตัวอย่างต่อไปนี้สร้างห้ากรอบและนำไปใช้ grayscale, duotone, tint, การปรับ HSL, และการแทนที่สี

[IDuotone](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iduotone/) มีพารามิเตอร์สีสองตัวที่แก้ไขได้อย่างอิสระ: `color1` ใช้กับพิกเซลสีเข้ม, ส่วน `color2` ใช้กับพิกเซลสีอ่อน ทำให้เป็นตัวอย่างที่ดีของเอฟเฟกต์ที่ตั้งค่าซับซ้อนกว่าค่าตัวสเกลเดียว

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IPPImage image;
    IImage sourceImage = Images.fromFile("photo.png");
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        sourceImage.dispose();
    }

    IPictureFrame grayFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 20, 20, 180, 120, image);
    grayFrame.getPictureFormat().getPicture().getImageTransform().addGrayScaleEffect();

    IPictureFrame duotoneFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 220, 20, 180, 120, image);
    IDuotone duotone = duotoneFrame.getPictureFormat().getPicture().getImageTransform().addDuotoneEffect();
    duotone.getColor1().setColor(Color.rgb(0, 0, 128));
    duotone.getColor2().setColor(Color.rgb(255, 215, 0));

    IPictureFrame tintFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 420, 20, 180, 120, image);
    tintFrame.getPictureFormat().getPicture().getImageTransform().addTintEffect(210f, 35f);

    IPictureFrame hslFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 120, 170, 180, 120, image);
    hslFrame.getPictureFormat().getPicture().getImageTransform().addHSLEffect(30f, 20f, -10f);

    IPictureFrame replacementFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 320, 170, 180, 120, image);
    IColorReplace colorReplacement = replacementFrame.getPictureFormat().getPicture().getImageTransform().addColorReplaceEffect();
    colorReplacement.getColor().setColor(Color.rgb(100, 149, 237));

    presentation.save("color-transformations.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

[addColorReplaceEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addColorReplaceEffect--) แทนที่สีของทุกพิกเซลด้วยสีคงที่หนึ่งสีขณะคงแอลฟ่าไว้ แตกต่างจาก [addColorChangeEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addColorChangeEffect--) ที่แผนที่สีต้นฉบับหนึ่งไปยังสีเป้าหมายและเปิดเผยรูปแบบสีต้นและปลายทางทั้งสอง

### **ใช้เกณฑ์ความสว่าง**

เกณฑ์ความสว่างสามารถทำให้รอยขีดที่สแกนไว้ง่ายต่อการแยกจากพื้นหลังได้ [addGrayScaleEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addGrayScaleEffect--) รักษาเฉดสีเทากลาง [addBiLevelEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addBiLevelEffect-float-) แปลงความสว่างเป็นสีดำหรือสีขาว, ขณะที่ [addAlphaBiLevelEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addAlphaBiLevelEffect-float-) ใช้เกณฑ์กับความทึบแสง

เกณฑ์ความสว่างมีช่วงตั้งแต่ 0% ถึง 100% รวม. พิกเซลใต้นั้นจะเป็นสีดำ. พิกเซลที่เท่ากับหรือมากกว่าจะเป็นสีขาว. การเพิ่มเกณฑ์จะทำให้เฉดสีที่น้อยกว่าแปลงเป็นสีดำมากขึ้นเพราะมีมากกว่าตกต่ำกว่าขีดจำกัด

ดาวน์โหลด [grayscale-swatches.png](grayscale-swatches.png) ไปยังไดเรกทอรีทำงาน แต่ละป้ายกำกับให้ระดับสีเทาต้นฉบับบนสเกลจาก 0 ถึง 255 ตัวอย่างวางต้นฉบับข้างสองสำเนาและบันทึกเกณฑ์ของแต่ละสำเนาในงานนำเสนอ

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    presentation.getSlideSize().setSize(720, 150, SlideSizeScaleType.DoNotScale);
    IShapeCollection shapes = presentation.getSlides().get_Item(0).getShapes();

    IPPImage image;
    IImage sourceImage = Images.fromFile("grayscale-swatches.png");
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        sourceImage.dispose();
    }

    String[] captions = { "Original", "Threshold 20%", "Threshold 60%" };
    IPictureFrame[] frames = new IPictureFrame[captions.length];
    for (int i = 0; i < captions.length; i++) {
        float x = 12 + 240 * i;
        IAutoShape label = shapes.addAutoShape(ShapeType.Rectangle, x, 12, 216, 36);
        label.getTextFrame().setText(captions[i]);
        frames[i] = shapes.addPictureFrame(ShapeType.Rectangle, x, 60, 216, 72, image);
    }

    frames[1].getPictureFormat().getPicture().getImageTransform().addBiLevelEffect(20f);
    frames[2].getPictureFormat().getPicture().getImageTransform().addBiLevelEffect(60f);

    presentation.save("luminance-threshold.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

เปิดงานนำเสนอผลลัพธ์ใน PowerPoint เพื่อเปรียบเทียบสามกรอบ ตัวสว่างที่ถูกป้ายกำกับ 96 มีความสว่างประมาณ 38% (96 จาก 255) จะเป็นสีขาวที่เกณฑ์ 20% และเป็นสีดำที่เกณฑ์ 60%

![ตัวอย่างสีเทาต้นฉบับข้างผลลัพธ์สีขาว-ดำที่เกณฑ์ความสว่าง 20% และ 60%](luminance-threshold.png)

## **เพิ่มเบลอ, ความโปร่งใส, และเอฟเฟกต์แอลฟา**

[addBlurEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addBlurEffect-double-boolean-) มีผลต่อทุกช่องสีรวมถึงแอลฟ่า ตั้งค่า `grow` เป็น `true` เมื่อขอบเบลออาจขยายเกินขอบภาพต้นฉบับ

สำหรับความโปร่งใสที่สม่ำเสมอ ให้ใช้ [addAlphaModulateFixedEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addAlphaModulateFixedEffect-float-). มันคูณค่าแอลฟ่าที่มีอยู่ทุกค่า ทำให้พิกเซลที่โปร่งใสบางส่วนยังคงแตกต่างตามสัดส่วน. [addAlphaReplaceEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addAlphaReplaceEffect-float-) แทนที่ค่าทั้งหมดด้วยแอลฟ่าหนึ่งค่า. [addAlphaBiLevelEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addAlphaBiLevelEffect-float-) แปลงแอลฟ่าเป็นสองระดับตามเกณฑ์

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IPPImage image;
    IImage sourceImage = Images.fromFile("photo.png");
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        sourceImage.dispose();
    }

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

เอฟเฟกต์แอลฟ่าที่ไม่มีพารามิเตอร์อื่น ๆ ได้แก่ [addAlphaCeilingEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addAlphaCeilingEffect--) ซึ่งทำให้แอลฟ่าที่ไม่เป็นศูนย์ทั้งหมดเป็นทึบเต็ม; [addAlphaFloorEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addAlphaFloorEffect--) ซึ่งทำให้แอลฟ่าที่ต่ำกว่า 100% ทั้งหมดเป็นโปร่งใสเต็ม; และ [addAlphaInverseEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addAlphaInverseEffect--) ซึ่งเปลี่ยนแอลฟ่าเป็น `100% - alpha`

## **สร้างเชนเอฟเฟกต์ที่เรียงลำดับ**

แต่ละเมธอด `add...Effect` จะเพิ่มการดำเนินการใหม่ไปที่ส่วนท้ายของคอลเลกชัน เราเรนเดอร์ใช้คอลเลกชันเป็นไอพิโพสจัดลำดับ: ผลลัพธ์ของการดำเนินการ 0 กลายเป็นอินพุตของการดำเนินการ 1 และต่อไป ดังนั้นการจัดลำดับเดียวกันในลำดับที่ต่างกันอาจให้ภาพที่แตกต่างกัน

ตัวอย่างต่อไปนี้สร้างเชนสี่การดำเนินการ, บันทึกเป็น PPTX, เปิดงานนำเสนอใหม่, ตรวจสอบประเภทและลำดับของการดำเนินการ, และเรนเดอร์ผลลัพธ์ที่เปิดใหม่

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IPPImage image;
    IImage sourceImage = Images.fromFile("photo.png");
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        sourceImage.dispose();
    }
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

คอลเลกชันไม่ได้บังคับให้มีเมทริกซ์ความเข้ากันได้ที่จำกัดให้เอฟเฟกต์สี, แอลฟ่า, และเบลออยู่ในเชนแยกกัน พวกมันสามารถรวมกันได้ แต่บางการรวมกันอาจไม่เป็นประโยชน์ การแทนที่สีคงที่จะลบการเปลี่ยนแปลง RGB ที่เกิดจากเอฟเฟกต์สีก่อนหน้า; การทำ grayscale หลัง duotone จะลบสองสีที่เลือก; และเอฟเฟกต์แอลฟ่า ceiling, floor, replace หรือ bi‑level อาจทิ้งรายละเอียดแอลฟ่าที่สร้างขึ้นก่อนหน้า สร้างเชนตามลำดับการประมวลผลพิกเซลที่ต้องการแทนที่จะมองว่าเป็นแฟล็กฟอร์แมตที่ไม่มีลำดับ

<!-- visual-explanation:image-transform-effects:start -->
[![รูปภาพเดียวกันผ่าน grayscale แล้วจึง tint, และ tint แล้วจึง grayscale. สองภาพ grayscale ขั้นสุดท้ายมีโทนสีต่างกัน](visual-image-transform-effects-49aa72211f3a.svg)](visual-image-transform-effects-49aa72211f3a.svg)
*ในภาพจำลอง Aspose.Slides for .NET 26.11 นี้ การ tint ที่ 220° ที่ 25% ทำให้ภาพ grayscale ไม่เปลี่ยนแปลง การนำ tint เดียวกันก่อน grayscale จะให้โทนสีที่ต่างกัน*
<!-- visual-explanation:image-transform-effects:end -->

## **ตรวจสอบค่าที่แก้ไขได้และค่าที่มีผล**

การดำเนินการที่แก้ไขได้คืออ็อบเจกต์ที่เก็บใน `ISlidesPicture.getImageTransform`. ขึ้นอยู่กับเอฟเฟกต์, อาจเปิดเผยสมาชิกที่เขียนได้โดยตรง ตัวอย่างเช่น [IBlur](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iblur/) เปิดเผยค่า `radius` และ `grow` ที่เขียนได้, [IAlphaModulateFixed](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ialphamodulatefixed/) เปิดเผย `amount` ที่เขียนได้, และ [IAlphaBiLevel](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ialphabilevel/) เปิดเผย `threshold` ที่เขียนได้. เอฟเฟกต์สีเช่น [IDuotone](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iduotone/) เปิดเผยอ็อบเจกต์ [IColorFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icolorformat/) ที่แก้ไขได้

บางอินเตอร์เฟซการดำเนินการ เช่น [IBrightnessContrast](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibrightnesscontrast/), [IHSL](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihsl/), [ITint](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itint/), และ [IAlphaReplace](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ialphareplace/) ไม่เปิดเผยสเกลาการสร้างเป็นสมบัติที่เขียนได้ เพื่อเปลี่ยนค่าดังกล่าว ให้ลบการดำเนินการและเพิ่มการแทนที่ในตำแหน่งที่ต้องการ

ข้อมูลที่มีผลที่คืนโดย `getEffective()` ถูกคำนวณและอ่านอย่างเดียว มันมีประโยชน์สำหรับการแก้ไขสีที่ขึ้นกับธีมและการอ่านค่าที่ทำให้เป็นมาตรฐานที่เรนเดอร์ใช้, แต่ไม่ใช่พื้นผิวการแก้ไขอื่น ตัวอย่างต่อไปนี้เรียงเชนและตรวจสอบค่าที่มีผลเมื่อ API ที่เกี่ยวข้องให้ข้อมูลเหล่านั้น

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

เอฟเฟกต์ที่ไม่มีพารามิเตอร์เช่น grayscale, alpha ceiling, และ alpha inverse ยังมีอ็อบเจกต์ข้อมูลที่มีผล, แต่ไม่มีการตั้งค่าสเกลให้พิมพ์ การมีอยู่และตำแหน่งในคอลเลกชันเป็นข้อมูลสำคัญ

## **ลบหรือเคลียร์การแปลงภาพ**

ใช้ [IImageTransformOperationCollection.removeAt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#removeAt-int-) เพื่อลบการดำเนินการหนึ่งโดยใช้ดัชนี เนื่องจากดัชนีจะเคลื่อนที่หลังจากการลบ, ควรค้นหาเป้าหมายก่อนและลบหลังจากเรียงรายการ ใช้ [ImageTransformOperationCollection.clear](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imagetransformoperationcollection/#clear--) เพื่อลบเชนทั้งหมด

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

การลบหรือเคลียร์การแปลงจะเปลี่ยนเฉพาะการจัดรูปแบบรูปภาพ ไม่ได้ลบ, บีบอัดใหม่, หรือแก้ไขทรัพยากร [IPPImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ippimage/) ที่ใช้ซ้ำ

## **พิจารณารูปแบบงานนำเสนอและเป้าหมายการส่งออก**

การแปลงภาพเกิดจาก DrawingML ดังนั้น PPTX เป็นรูปแบบที่แนะนำสำหรับการแก้ไขเชนเอฟเฟกต์ แม้ใน PPTX ก็อาจมีบางการดำเนินการที่พกพาไม่เหมือนกัน

- การดำเนินการ DrawingML มาตรฐานเช่น luminance, grayscale, duotone, tint, HSL, blur, และเอฟเฟกต์แอลฟ่าทั่วไป มีโอกาสดีที่สุดที่จะอยู่หลังการรอบ PPTX. ควรเปิดไฟล์ที่สร้างใหม่และตรวจสอบคอลเลกชันเสมอเมื่อการคงสภาพเป็นข้อกำหนด
- [BrightnessContrast](https://reference.aspose.com/slides/androidjava/com.aspose.slides/brightnesscontrast/) เป็นส่วนขยายของ Office 2010 ไม่ใช่การดำเนินการ luminance ของ DrawingML มาตรฐาน สามารถใช้สำหรับเรนเดอร์ในหน่วยความจำได้ แต่ไม่รับประกันว่าจะคงเป็น [IBrightnessContrast](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibrightnesscontrast/) ที่แก้ไขได้หลังการบันทึกและเปิดใหม่ PPTX. แนะนำให้ใช้ [addLuminanceEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addLuminanceEffect-float-float-) สำหรับการปรับความสว่างและคอนทราสต์อย่างถาวร
- รูปแบบ PPT ไบนารีมีอายุยาวกว่ารุ่น DrawingML ทั้งหมด การบันทึกเป็น PPT อาจละเว้นการดำเนินการที่ไม่รองรับ, ลดเชนลงเป็นส่วนที่รองรับ, หรือประมาณการลักษณะ. ไม่ควรใช้ PPT เป็นรูปแบบตรวจสอบสำหรับเชนที่ซับซ้อนและแก้ไขได้
- การเรนเดอร์เป็น PNG, JPEG, TIFF, PDF, SVG, HTML หรือเอาต์พุตภาพอื่น ๆ ใช้เชนที่รองรับเพื่อสร้างลักษณะที่เรนเดอร์ เอาต์พุตเหล่านี้ไม่มี `IImageTransformOperationCollection` ที่แก้ไขได้; รูปแบบเรสเตอร์จะทำให้ผลลัพธ์แบนเป็นพิกเซล, และการส่งออกเอกสาร/เวกเตอร์จะเก็บการแสดงผลของตนเอง
- เอฟเฟกต์ไม่ทำให้ภาพที่เชื่อมโยงเป็นไฟล์อิสระ การเรนเดอร์ภาพที่เชื่อมโยงยังคงต้องอาศัยทรัพยากรที่เชื่อมโยงต้องพร้อมใช้งานเมื่อโหลดงานนำเสนอ

ผู้ใช้งานนำเสนอที่ต่างกันอาจเรนเดอร์กรณีขอบเขตต่างกัน, โดยเฉพาะเมื่อมีการรวมเอฟเฟกต์แอลฟ่าหรือการควอนไทส์สีหลายอย่าง สำหรับผลลัพธ์ที่สำคัญ ควรทดสอบทั้งรอบการแก้ไขและรูปแบบส่งออกสุดท้ายด้วยเวอร์ชัน Aspose.Slides ที่ใช้ในผลิตภัณฑ์

## **คำถามที่พบบ่อย**

**Do image transform effects modify the embedded image data?**

ไม่. การดำเนินการเป็นของ `ISlidesPicture` ที่ใช้โดยการเติมรูปภาพ. ไบต์ `IPPImage` ด้านล่างคงไม่เปลี่ยน

**Will two picture frames that reuse the same image share their effects?**

ไม่. การใช้ `IPPImage` ซ้ำช่วยหลีกเลี่ยงข้อมูลภาพซ้ำ, แต่ละกรอบรูปโดยทั่วไปจะมี `ISlidesPicture` และคอลเลกชันการแปลงภาพของตนเองแยกกัน

**Can color, blur, and alpha effects be combined?**

ได้. คอลเลกชันรับเอฟเฟกต์เหล่านี้ในเชนที่เรียงลำดับ. ควรพิจารณาว่าแต่ละการดำเนินการทำอะไรกับผลลัพธ์ของก่อนหน้า เพราะการแทนที่และการกำหนดเกณฑ์อาจลบรายละเอียดสีหรือแอลฟ่าก่อนหน้า

**Why are effective values read‑only?**

ข้อมูลที่มีผลเป็นค่าที่คำนวณสำหรับการเรนเดอร์, รวมถึงสีที่แก้ไขแล้ว. แก้ไขการดำเนินการที่เก็บในคอลเลกชันเมื่อมีสมาชิกที่เขียนได้; ถ้าไม่มี ให้ลบและเพิ่มการแทนที่พร้อมพารามิเตอร์ใหม่

**Which format should I use to preserve a transform chain?**

ใช้ PPTX และตรวจสอบไฟล์โดยเปิดใหม่. PPT ดั้งเดิมไม่สามารถแสดงโมเดลเอฟเฟกต์ DrawingML ทั้งหมด, และรูปแบบส่งออกที่แสดงผลจะเก็บภาพแบบแสดงผลเท่านั้น ไม่ได้เก็บ `IImageTransformOperationCollection` ที่แก้ไขได้