---
title: จัดการเอฟเฟกต์การแปลงรูปภาพในงานนำเสนอด้วย Java
linktitle: เอฟเฟกต์การแปลงรูปภาพ
type: docs
weight: 11
url: /th/java/image-transform-effects/
keywords:
- การแปลงรูปภาพ
- เอฟเฟกต์รูปภาพ
- ความสว่าง
- ความคอนทราสต์
- สีเทา
- สีสองโทน
- สีสัน
- HSL
- การแทนที่สี
- เบลอ
- ความโปร่งใส
- เอฟเฟกต์อัลฟ่า
- โซ่เอฟเฟกต์
- PowerPoint
- การนำเสนอ
- Java
- Aspose.Slides
description: ใช้, สร้างโซ่, ตรวจสอบ, ลบ, และยืนยันเอฟเฟกต์การแปลงรูปภาพสำหรับเฟรมรูปภาพด้วย Aspose.Slides สำหรับ Java.
---
## **ภาพรวม**

Aspose.Slides แสดงการปรับรูปภาพเป็นคอลเลกชันที่เรียงลำดับของการดำเนินการแปลงรูปภาพ สำหรับเฟรมรูปภาพ ให้เริ่มจาก [ISlidesPicture](https://reference.aspose.com/slides/java/com.aspose.slides/islidespicture/) ของเฟรมและเข้าถึง [ISlidesPicture.getImageTransform](https://reference.aspose.com/slides/java/com.aspose.slides/islidespicture/#getImageTransform--) ส่วนที่ส่งคืน [IImageTransformOperationCollection](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/) จะทำให้คุณสามารถเพิ่ม, ลำดับ, ตรวจสอบ, ลบ และล้างเอฟเฟกต์ได้โดยไม่ต้องเขียนทับไบต์ของรูปภาพต้นฉบับ

บทความนี้แสดงกระบวนการทำงานครบวงจรสำหรับความสว่างและความคอนทราสต์, การแปลงสี, เบลอ, ความโปร่งใส, โซ่เอฟเฟกต์ตามลำดับ, ค่าที่มีประสิทธิภาพ, การลบ, และการตรวจสอบรอบกลับ PPTX

## **ทำความเข้าใจการเป็นเจ้าของเอฟเฟกต์และการใช้รูปภาพซ้ำ**

ทรัพยากรรูปภาพและรูปภาพที่แสดงมันเป็นวัตถุที่แตกต่างกัน:

- [IPPImage](https://reference.aspose.com/slides/java/com.aspose.slides/ippimage/) เก็บหรืออ้างอิงข้อมูลรูปภาพต้นทางซึ่งเป็นของพรีเซนเทชัน
- [ISlidesPicture](https://reference.aspose.com/slides/java/com.aspose.slides/islidespicture/) เป็นของการเติมรูปภาพและอ้างอิงทรัพยากรรูปภาพพร้อมกับเก็บคอลเลกชันการแปลงรูปภาพ
- [IPictureFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ipictureframe/) เป็นรูปร่างบนสไลด์ที่เป็นเจ้าของการเติมรูปภาพ, รูปร่าง, การตั้งค่าการครอป, และการจัดรูปแบบระดับเฟรมอื่น ๆ

ดังนั้นการดำเนินการแปลงรูปภาพจะไม่แก้ไขไบต์ใน [IPPImage](https://reference.aspose.com/slides/java/com.aspose.slides/ippimage/) เมื่อ `IPPImage` เดียวกันถูกส่งผ่านไปยัง [IShapeCollection.addPictureFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/#addPictureFrame-int-float-float-float-float-com.aspose.slides.IPPImage-) มากกว่าหนึ่งครั้ง เรเฟรมรูปภาพใหม่แต่ละอันจะได้รับ `ISlidesPicture` ของตนเองและคอลเลกชันการแปลงของตนเอง การทำให้เฟรมหนึ่งเป็นสีเทาจะไม่ทำให้เฟรมอื่นเป็นสีเทา แม้ว่าทั้งหมดจะใช้ทรัพยากรรูปภาพที่ฝังอยู่เดียวกัน

โมเดล `ISlidesPicture.getImageTransform` เดียวกันนี้ยังใช้โดยการเติมรูปภาพอื่น ๆ เช่น รูปร่างหรือพื้นหลังสไลด์ ตัวอย่างด้านล่างมุ่งเน้นที่เฟรมรูปภาพ

## **ใช้ช่วงค่าพารามิเตอร์และหน่วยที่ถูกต้อง**

วิธีที่สาธิตใช้ช่วงและหน่วยตามความหมายต่อไปนี้ ให้คงค่าภายในช่วงเหล่านี้แม้ว่าเวอร์ชันไลบรารีบางเวอร์ชันอาจไม่ปฏิเสธค่าที่อยู่นอกช่วงทันที; รูปแบบพรีเซนเทชันเป้าหมายอาจทำให้ค่าปกติ, ละเลย, หรือปฏิเสธข้อมูลที่ไม่ถูกต้องระหว่างการบันทึกหรือเมื่อ PowerPoint เปิดไฟล์

| การกระทำ | พารามิเตอร์ | ช่วงค่าที่ถูกต้องและหน่วย |
|---|---|---|
| [addBrightnessContrastEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addBrightnessContrastEffect-float-float-) | `brightness`, `contrast` | `-100` ถึง `100` เปอร์เซ็นต์; `0` ไม่เปลี่ยนส่วนประกอบ |
| [addGrayScaleEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addGrayScaleEffect--) | ไม่มี | ไม่มีพารามิเตอร์เชิงตัวเลข อัลฟ่าไม่เปลี่ยน |
| [addDuotoneEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addDuotoneEffect--) | `color1`, `color2` | สองสีสำหรับพิกเซลสีเข้มและสีสว่าง ช่องสี RGB และอัลฟาใน `java.awt.Color` ใช้ค่า `0` ถึง `255` |
| [addTintEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addTintEffect-float-float-) | `hue`, `amount` | Hue มีค่า `0` รวมถึง `360` ไม่รวม, หน่วยเป็นองศ; amount มีค่า `-100` ถึง `100` เปอร์เซ็นต์ |
| [addHSLEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addHSLEffect-float-float-float-) | `hue`, `saturation`, `luminance` | Hue มีค่า `0` รวมถึง `360` ไม่รวม, หน่วยเป็นองศ; saturation และ luminance มีค่า `-100` ถึง `100` เปอร์เซ็นต์ |
| [addColorReplaceEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addColorReplaceEffect--) | `color` | สีทดแทนใช้ค่าช่องจาก `0` ถึง `255` ค่าอัลฟ่าเดิมไม่เปลี่ยน |
| [addBlurEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addBlurEffect-double-boolean-) | `radius`, `grow` | รัศมีต้องเป็นค่าที่ไม่เป็นลบและวัดเป็นจุด; `grow` เป็น Boolean ที่ควบคุมว่าขอบเบลออาจขยายออกนอกขอบเดิมหรือไม่ |
| [addAlphaModulateFixedEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addAlphaModulateFixedEffect-float-) | `amount` | เปอร์เซ็นต์ที่ไม่เป็นลบ ใช้ `0` ถึง `100` สำหรับการปรับความทึบแบบปกติ: `0` โปร่งใสเต็ม, `100` รักษาอัลฟ่าเดิม |
| [addAlphaReplaceEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addAlphaReplaceEffect-float-) | `alpha` | `0` ถึง `100` เปอร์เซ็นต์ของความทึบ |
| [addAlphaBiLevelEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addAlphaBiLevelEffect-float-) | `threshold` | `0` ถึง `100` เปอร์เซ็นต์ของค่าอัลฟ่าเป็นเกณฑ์; ค่าต่ำกว่าจะเป็นโปร่งใส; ค่าสูงกว่าจะเป็นทึบ |

สำหรับการปรับอัลฟ่าแบบคงที่ ความโปร่งใสและความทึบเป็นค่าตรงกันข้าม ตัวอย่างเช่น ความโปร่งใส 35% เทียบเท่ากับค่าอัลฟ่าโมเดูเลท 65%

## **นำไปใช้กับความสว่างและความคอนทราสต์**

[IImageTransformOperationCollection.addBrightnessContrastEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addBrightnessContrastEffect-float-float-) คืนค่าการดำเนินการ [IBrightnessContrast](https://reference.aspose.com/slides/java/com.aspose.slides/ibrightnesscontrast/) การตั้งค่าสเกลาร์ของมันจะถูกส่งเมื่อสร้างการดำเนินการ [BrightnessContrast.getEffective](https://reference.aspose.com/slides/java/com.aspose.slides/brightnesscontrast/#getEffective--) คืนค่าที่คำนวณแล้วแบบอ่านอย่างเดียวที่สามารถตรวจสอบหรือบันทึกได้

ตัวอย่างต่อไปนี้เพิ่มความสว่าง 15% และความคอนทราสต์ 20% แล้วเรนเดอร์พรีวิวโดยไม่แก้ไขรูปภาพที่ฝังอยู่:

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

[BrightnessContrast](https://reference.aspose.com/slides/java/com.aspose.slides/brightnesscontrast/) เป็นส่วนขยายเอฟเฟกต์รูปภาพของ Office 2010 และมีความพกพาน้อยกว่าการเอฟเฟกต์ luminance ของ DrawingML มาตรฐาน หากต้องการให้ความสว่างและความคอนทราสต์ยังคงแก้ไขได้หลังการรอบกลับ PPTX ให้ใช้ [IImageTransformOperationCollection.addLuminanceEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addLuminanceEffect-float-float-) และตรวจสอบผลลัพธ์หลังจากเปิดไฟล์ใหม่ ส่วนข้อจำกัดของรูปแบบอธิบายความแตกต่างนี้อย่างละเอียดต่อไป

## **นำไปใช้กับการแปลงสี**

เอฟเฟกต์สีสามารถนำไปใช้แยกกันกับเฟรมรูปภาพที่ใช้ทรัพยากรรูปเดียวกัน ตัวอย่างต่อไปนี้สร้างห้าเฟรมและนำไปใช้กับสีเทา, duotone, tint, การปรับ HSL, และการเปลี่ยนสี

[IDuotone](https://reference.aspose.com/slides/java/com.aspose.slides/iduotone/) มีพารามิเตอร์สีสองค่าแก้ไขได้อย่างอิสระ: `color1` แทนพิกเซลสีเข้ม, `color2` แทนพิกเซลสีสว่าง ซึ่งทำให้เป็นตัวอย่างที่ดีของเอฟเฟกต์ที่ตั้งค่าซับซ้อนกว่าค่าตัวเลขเดียว

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

[addColorReplaceEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addColorReplaceEffect--) แทนที่สีของทุกพิกเซลด้วยสีคงที่หนึ่งสีขณะรักษาอัลฟ่า แตกต่างจาก [addColorChangeEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addColorChangeEffect--) ที่แมปสีต้นทางหนึ่งไปยังสีปลายทางและเผยรูปแบบสีของต้นทางและปลายทาง

### **นำไปใช้กับเกณฑ์ Luminance**

เกณฑ์ luminance สามารถทำให้เครื่องหมายจางบนหน้าสแกนแยกออกจากพื้นหลังได้ง่ายขึ้น [addGrayScaleEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addGrayScaleEffect--) รักษาเฉดสีเทากลาง [addBiLevelEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addBiLevelEffect-float-) แปลง luminance ให้เป็นสีดำหรือสีขาว ในขณะที่ [addAlphaBiLevelEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addAlphaBiLevelEffect-float-) ใช้เกณฑ์กับความทึบ

เกณฑ์ luminance มีช่วงจาก 0% ถึง 100% รวม ค่าใต่เกณฑ์จะเป็นสีดำ ค่าเท่าหรือเหนือเกณฑ์จะเป็นสีขาว การเพิ่มเกณฑ์ทำให้เฉดสีหลาย ๆ สีกลายเป็นสีดำมากขึ้นเพราะมากกว่าหนึ่งส่วนตกลงมาต่ำกว่าจุดตัด

ดาวน์โหลด [grayscale-swatches.png](grayscale-swatches.png) ไปยังไดเรกทอรีทำงาน แต่ละป้ายกำกับแสดงระดับสีเทาต้นฉบับในช่วง 0 ถึง 255 ตัวอย่างวางต้นฉบับข้างสำเนาสองชุดและบันทึกเกณฑ์ของแต่ละสำเนาในพรีเซนเทชัน

```java
import com.aspose.slides.*;
import java.nio.file.Files;
import java.nio.file.Paths;

Presentation presentation = new Presentation();
try {
    presentation.getSlideSize().setSize(720, 150, SlideSizeScaleType.DoNotScale);
    IShapeCollection shapes = presentation.getSlides().get_Item(0).getShapes();

    byte[] imageData = Files.readAllBytes(Paths.get("grayscale-swatches.png"));
    IPPImage image = presentation.getImages().addImage(imageData);

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

เปิดพรีเซนเทชันผลลัพธ์ใน PowerPoint เพื่อเปรียบเทียบสามเฟรม ตัวสวาตช์ที่มีป้ายกำกับ 96 มี luminance ประมาณ 38% (96 จาก 255) จะเป็นสีขาวที่เกณฑ์ 20% และเป็นสีดำที่เกณฑ์ 60%

![Original grayscale swatches beside the black-and-white results at luminance thresholds of 20% and 60%](luminance-threshold.png)

## **เพิ่ม Blur, Transparency, และ Alpha Effects**

[addBlurEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addBlurEffect-double-boolean-) มีผลต่อทุกช่องสี รวมอัลฟ่า ตั้งค่า `grow` เป็น `true` เมื่อตัวขอบเบลออาจล้ำขอบรูปภาพเดิม

สำหรับความโปร่งใสสม่ำเสมอ ให้ใช้ [addAlphaModulateFixedEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addAlphaModulateFixedEffect-float-) ซึ่งคูณค่าอัลฟ่าเดิมทุกค่า ทำให้พิกเซลที่โปร่งใสบางส่วนยังคงต่างกันตามสัดส่วน [addAlphaReplaceEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addAlphaReplaceEffect-float-) จะกำหนดค่าอัลฟ่าเดียวให้กับทุกพิกเซล [addAlphaBiLevelEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addAlphaBiLevelEffect-float-) แปลงอัลฟ่าเป็นสองระดับตามเกณฑ์

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

การดำเนินการอัลฟ่าไม่มีพารามิเตอร์อื่น ๆ ได้แก่ [addAlphaCeilingEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addAlphaCeilingEffect--) ที่ทำให้ทุกอัลฟ่าไม่เป็นศูนย์เป็นทึบเต็ม; [addAlphaFloorEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addAlphaFloorEffect--) ทำให้ทุกอัลฟ่าต่ำกว่า 100% เป็นโปร่งใสเต็ม; และ [addAlphaInverseEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addAlphaInverseEffect--) ที่เปลี่ยนอัลฟ่าเป็น `100% - alpha`

## **สร้างโซ่เอฟเฟกต์ตามลำดับ**

แต่ละเมธอด `add...Effect` จะเพิ่มการดำเนินการใหม่ไปยังท้ายของคอลเลกชัน ตัวเรนเดอร์ตามลำดับใช้คอลเลกชันเป็นไพป์ไลน์ที่เรียงลำดับ: ผลลัพธ์ของการดำเนินการ 0 กลายเป็นอินพุตของการดำเนินการ 1 และต่อไป ดังนั้นการใช้การดำเนินการเดียวกันในลำดับที่ต่างกันอาจให้ภาพที่ต่างกัน

เช่น สีเทาตามด้วย tint จะลบข้อมูลสีก่อนแล้วจึงทำสีใหม่ให้ luminance ส่วน tint ตามด้วยสีเทาจะลบ tint อีกครั้ง อย่างคล้ายกัน การแทนที่อัลฟ่าอาจเขียนทับค่าอัลฟ่า ที่คำนวนจากการดำเนินการก่อนหน้า ในขณะที่การโมเดูเลทอัลฟ่าเก็บความแตกต่างสัมพัทธ์ไว้

ตัวอย่างต่อไปนี้สร้างโซ่สี่การดำเนินการ บันทึกเป็น PPTX เปิดพรีเซนเทชันใหม่ ตรวจสอบประเภทการดำเนินการและลำดับของมัน และเรนเดอร์ผลลัพธ์ที่เปิดใหม่:

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

คอลเลกชันไม่ได้กำหนดเมทริกซ์ความเข้ากันได้ที่บังคับให้การทำสี, อัลฟ่า, และการเบลออยู่ในโซ่แยกกัน สามารถรวมกันได้ แต่ไม่จำเป็นต้องเป็นประโยชน์เสมอ การแทนที่สีคงที่จะลบการแปรผัน RGB ที่เกิดจากเอฟเฟกต์สีก่อนหน้า; สีเทาหลัง duotone จะลบสองสีที่เลือก; และการดำเนินการอัลฟ่า ceiling, floor, replace หรือ bi‑level สามารถทิ้งรายละเอียดอัลฟ่า ที่สร้างจากก่อนหน้า สร้างโซ่ตามลำดับการประมวลผลพิกเซลที่ต้องการ แทนการถือเป็นแฟล็กการจัดรูปแบบที่ไม่เรียงลำดับ

<!-- visual-explanation:image-transform-effects:start -->
[![The same image passes through grayscale then tint, and tint then grayscale. The two final grayscale images have different tones.](visual-image-transform-effects-49aa72211f3a.svg)](visual-image-transform-effects-49aa72211f3a.svg)

*In this illustrative Aspose.Slides for .NET 26.11 render, a 220° tint at 25% leaves the grayscale image unchanged. Applying the same tint before grayscale produces different tones.*
<!-- visual-explanation:image-transform-effects:end -->

## **ตรวจสอบค่าที่แก้ไขได้และค่าที่มีประสิทธิภาพ**

การดำเนินการที่แก้ไขได้คือออบเจ็กต์ที่เก็บอยู่ใน `ISlidesPicture.getImageTransform` ขึ้นอยู่กับเอฟเฟกต์ อาจเปิดเผยสมาชิกที่เขียนได้โดยตรง ตัวอย่างเช่น [IBlur](https://reference.aspose.com/slides/java/com.aspose.slides/iblur/) เปิดเผยค่า `radius` และ `grow` ที่เขียนได้, [IAlphaModulateFixed](https://reference.aspose.com/slides/java/com.aspose.slides/ialphamodulatefixed/) เปิดเผย `amount`, และ [IAlphaBiLevel](https://reference.aspose.com/slides/java/com.aspose.slides/ialphabilevel/) เปิดเผย `threshold` สีเอฟเฟกต์ เช่น [IDuotone](https://reference.aspose.com/slides/java/com.aspose.slides/iduotone/) เปิดเผยออบเจ็กต์ [IColorFormat](https://reference.aspose.com/slides/java/com.aspose.slides/icolorformat/) ที่แก้ไขได้

บางอินเทอร์เฟซการดำเนินการ เช่น [IBrightnessContrast](https://reference.aspose.com/slides/java/com.aspose.slides/ibrightnesscontrast/), [IHSL](https://reference.aspose.com/slides/java/com.aspose.slides/ihsl/), [ITint](https://reference.aspose.com/slides/java/com.aspose.slides/itint/), และ [IAlphaReplace](https://reference.aspose.com/slides/java/com.aspose.slides/ialphareplace/) ไม่เปิดเผยสเกลาร์การสร้างเป็นคุณสมบัติเขียนได้ เพื่อเปลี่ยนการตั้งค่าเหล่านั้น ต้องลบการดำเนินการและเพิ่มการแทนที่ที่ตำแหน่งที่ต้องการ

ข้อมูลที่มีประสิทธิภาพที่ส่งกลับโดย `getEffective()` ถูกคำนวนและเป็นอ่าน‑อย่างเดียว มีประโยชน์สำหรับการแก้ไขสีที่อิงธีมและการอ่านค่าที่ทำให้เป็นมาตรฐานที่เรนเดอร์ใช้ แต่ไม่ใช่พื้นผิวการแก้ไขอีกหนึ่งจุด ตัวอย่างต่อไปนี้ลิสต์โซ่และตรวจสอบค่าที่มีประสิทธิภาพเมื่อ API ให้ข้อมูลเหล่านั้น:

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

เอฟเฟกต์ที่ไม่มีพารามิเตอร์ เช่น สีเทา, alpha ceiling, และ alpha inverse ยังมีออบเจ็กต์ข้อมูลที่มีประสิทธิภาพอยู่ แต่ไม่มีการตั้งค่าสเกลาร์ให้พิมพ์ การปรากฏและตำแหน่งในคอลเลกชันเป็นข้อมูลสำคัญ

## **ลบหรือเคลียร์การแปลงรูปภาพ**

ใช้ [IImageTransformOperationCollection.removeAt](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#removeAt-int-) เพื่อลบการดำเนินการหนึ่งโดยระบุดัชนี เพราะดัชนีจะเปลี่ยนหลังการลบ ให้ค้นหาตำแหน่งเป้าหมายก่อนและลบหลังจากลิสต์ ใช้ [ImageTransformOperationCollection.clear](https://reference.aspose.com/slides/java/com.aspose.slides/imagetransformoperationcollection/#clear--) เพื่อลบโซ่ทั้งหมด

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

การลบหรือเคลียร์การแปลงเปลี่ยนเฉพาะการจัดรูปแบบของรูปภาพ ไม่ได้ลบ, บีบอัดใหม่, หรือแก้ไขทรัพยากร [IPPImage](https://reference.aspose.com/slides/java/com.aspose.slides/ippimage/) ที่ใช้ซ้ำ

## **พิจารณารูปแบบพรีเซนเทชันและเป้าหมายการส่งออก**

การแปลงรูปภาพเริ่มต้นจาก DrawingML ดังนั้น PPTX เป็นรูปแบบที่แก้ไขได้ที่แนะนำสำหรับโซ่เอฟเฟกต์ แม้กับ PPTX ก็ไม่ได้ทุกการดำเนินการมีพกพาเท่ากัน:

- การดำเนินการ DrawingML มาตรฐานเช่น luminance, grayscale, duotone, tint, HSL, blur, และการดำเนินการอัลฟ่าแบบทั่วไป มีความโอกาสสูงสุดที่จะคงอยู่หลังรอบกลับ PPTX เปิดไฟล์ที่สร้างและตรวจสอบคอลเลกชันเมื่อการคงสภาพเป็นข้อกำหนด
- [BrightnessContrast](https://reference.aspose.com/slides/java/com.aspose.slides/brightnesscontrast/) เป็นส่วนขยายของ Office 2010 แทนการดำเนินการ luminance ของ DrawingML มาตรฐาน สามารถใช้สำหรับการเรนเดอร์ในหน่วยความจำ แต่ไม่รับประกันว่าจะคงเป็น [IBrightnessContrast](https://reference.aspose.com/slides/java/com.aspose.slides/ibrightnesscontrast/) ที่แก้ไขได้หลังบันทึกและเปิด PPTX ใหม่ แนะนำให้ใช้ [addLuminanceEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addLuminanceEffect-float-float-) สำหรับการปรับความสว่างและความคอนทราสต์ที่คงอยู่
- รูปแบบไบนารี PPT มีอายุยาวนานก่อนโมเดลเอฟเฟกต์ DrawingML ครบถ้วน การบันทึกเป็น PPT อาจละเว้นการดำเนินการที่ไม่รองรับ ลดโซ่ลงเป็นส่วนย่อยที่รองรับ หรือประมาณลักษณะการแสดง อย่าใช้ PPT เป็นรูปแบบการตรวจสอบสำหรับโซ่แก้ไขที่ซับซ้อน
- การเรนเดอร์เป็น PNG, JPEG, TIFF, PDF, SVG, HTML หรือรูปแบบภาพอื่น ๆ จะใช้โซ่ที่รองรับเพื่อแสดงผลลัพธ์ รูปแบบเหล่านี้ไม่ได้บรรจุ `IImageTransformOperationCollection` ที่แก้ไขได้; รูปแบบราสเตอร์จะทำให้ผลลัพธ์แบนเป็นพิกเซล และการส่งออกเอกสาร/เวกเตอร์จะเก็บการแสดงผลของตนเอง
- เอฟเฟกต์ไม่ได้ทำให้รูปภาพที่เชื่อมโยงกลายเป็นไฟล์เดียว การเรนเดอร์รูปภาพที่เชื่อมโยงยังคงต้องอาศัยทรัพยากรที่เชื่อมโยงพร้อมใช้งานเมื่อพรีเซนเทชันโหลด

ผู้รับพรีเซนเทชันต่าง ๆ อาจเรนเดอร์กรณีขอบเขตต่างกัน โดยเฉพาะเมื่อรวมการดำเนินการอัลฟ่าหรือการปริมาณสีหลายอย่าง สำหรับผลลัพธ์ที่สำคัญ ควรทดสอบทั้งรอบกลับที่แก้ไขได้และรูปแบบส่งออกขั้นสุดท้ายด้วย Aspose.Slides เวอร์ชันเดียวกันที่ใช้งานในขั้นตอนผลิต

## **คำถามที่พบบ่อย**

**การดำเนินการแปลงรูปภาพทำให้ข้อมูลรูปภาพที่ฝังเปลี่ยนหรือไม่?**

ไม่ การดำเนินการเป็นของ `ISlidesPicture` ที่ใช้โดยการเติมรูปภาพ ไบต์ของ `IPPImage` พื้นฐานคงไม่เปลี่ยน

**เฟรมรูปภาพสองอันที่ใช้รูปภาพเดียวกันจะแชร์เอฟเฟกต์หรือไม่?**

ไม่ การใช้ `IPPImage` ซ้ำช่วยลดข้อมูลรูปภาพซ้ำ แต่แต่ละเฟรมรูปภาพมักจะมี `ISlidesPicture` และคอลเลกชันการแปลงรูปภาพของตนเอง

**สามารถรวมเอฟเฟกต์สี, เบลอ, และอัลฟ่าได้หรือไม่?**

ได้ คอลเลกชันรับเอฟเฟกต์เหล่านี้ในโซ่ตามลำดับ พิจารณาว่าแต่ละการดำเนินการส่งผลต่อผลลัพธ์ของการดำเนินการก่อนหน้าอย่างไร เพราะการแทนที่และเกณฑ์อาจตัดรายละเอียดสีหรืออัลฟ่าเดิมออก

**ทำไมค่าที่มีประสิทธิภาพจึงเป็นอ่าน‑อย่างเดียว?**

ค่าที่มีประสิทธิภาพเป็นค่าที่คำนวนเพื่อการเรนเดอร์ รวมสีที่แก้ไขแล้ว อ่านค่าเหล่านี้สำหรับการแสดงผล แต่ไม่ใช่พื้นผิวการแก้ไข หากต้องการเปลี่ยนค่า ให้แก้ไขการดำเนินการในคอลเลกชันที่มีสมาชิกเขียนได้ หรือถ้าไม่มีให้ลบและเพิ่มการแทนที่ด้วยพารามิเตอร์ใหม่

**ควรใช้รูปแบบไหนเพื่อคงโซ่การแปลง?**

ใช้ PPTX และตรวจสอบไฟล์โดยเปิดใหม่ PPT เก่าจะไม่สามารถแสดงโมเดลเอฟเฟกต์ DrawingML ครบถ้วนได้; รูปแบบการส่งออกที่เรนเดอร์จะคงลักษณะการแสดงเท่านั้น ไม่ได้คงการแปลงที่แก้ไขได้