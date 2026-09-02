---
title: จัดการเอฟเฟกต์การแปลงภาพในการนำเสนอบน Android
linktitle: เอฟเฟกต์การแปลงภาพ
type: docs
weight: 11
url: /th/androidjava/image-transform-effects/
keywords:
- การแปลงภาพ
- เอฟเฟกต์รูปภาพ
- ความสว่าง
- คอนทราสต์
- สีเทา
- โทนสีคู่
- การเติมสี
- HSL
- การแทนที่สี
- เบลอ
- ความโปร่งใส
- เอฟเฟกต์แอลฟ่า
- ห่วงโซ่เอฟเฟกต์
- PowerPoint
- งานนำเสนอ
- Android
- Java
- Aspose.Slides
description: "ใช้, เชื่อมโยง, ตรวจสอบ, ลบ, และตรวจสอบความถูกต้องของเอฟเฟกต์การแปลงภาพสำหรับกรอบรูปภาพด้วย Aspose.Slides สำหรับ Android ผ่าน Java."
---
## **ภาพรวม**

Aspose.Slides แสดงการปรับภาพเป็นคอลเลกชันที่เรียงลำดับของการดำเนินการแปลงรูปภาพสำหรับกรอบรูปภาพ เริ่มต้นด้วย [ISlidesPicture](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/islidespicture/) ของกรอบรูปและเข้าถึง [ISlidesPicture.getImageTransform](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/islidespicture/#getImageTransform--) คอลเลกชัน [IImageTransformOperationCollection](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iimagetransformoperationcollection/) ที่คืนค่ามาช่วยให้คุณเพิ่ม, แสดงรายการ, ตรวจสอบ, ลบและล้างเอฟเฟกต์โดยไม่ต้องเขียนใหม่ไบต์ของรูปภาพต้นฉบับ

บทความนี้สาธิตกระบวนการทำงานเต็มรูปแบบสำหรับความสว่างและคอนทราสต์, การแปลงสี, เบลอ, ความโปร่งใส, ห่วงโซ่เอฟเฟกต์ที่เรียงลำดับ, ค่าที่มีผล, การลบ, และการตรวจสอบรอบรอบ PPTX

## **ทำความเข้าใจการเป็นเจ้าของเอฟเฟกต์และการใช้ภาพซ้ำ**

ทรัพยากรภาพและรูปภาพที่แสดงมันเป็นวัตถุที่แตกต่างกัน:

- [IPPImage](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ippimage/) เก็บหรืออ้างอิงข้อมูลภาพต้นฉบับที่เป็นของงานนำเสนอ
- [ISlidesPicture](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/islidespicture/) อยู่ในส่วนเติมรูปภาพและอ้างอิงถึงทรัพยากรภาพพร้อมกับเก็บคอลเลกชันการแปลงรูปภาพ
- [IPictureFrame](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ipictureframe/) คือรูปทรงสไลด์ที่เป็นเจ้าของการเติมรูปภาพ, เรขาคณิต, การครอป, และการจัดรูปแบบระดับกรอบอื่น ๆ

ดังนั้นการดำเนินการแปลงรูปภาพจะไม่แก้ไขไบต์ใน [IPPImage](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ippimage/) เมื่อ `IPPImage` เดียวกันถูกส่งให้กับ [IShapeCollection.addPictureFrame](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ishapecollection/#addPictureFrame-int-float-float-float-float-com.aspose.slides.IPPImage-) มากกว่าหนึ่งครั้ง แต่ละกรอบรูปภาพใหม่จะได้รับ `ISlidesPicture` ของตนเองและคอลเลกชันการแปลงของตน การทำให้กรอบหนึ่งเป็นสีเทาจะไม่ทำให้กรอบอื่นเป็นสีเทา แม้ว่าทุกกรอบจะใช้ทรัพยากรภาพที่ฝังไว้เดียวกัน

โมเดล `ISlidesPicture.getImageTransform` เดียวกันยังใช้โดยการเติมรูปภาพอื่น ๆ เช่น รูปร่างหรือพื้นหลังสไลด์ ตัวอย่างด้านล่างเน้นที่กรอบรูปภาพ

## **ใช้ช่วงค่าพารามิเตอร์และหน่วยที่ถูกต้อง**

วิธีการที่แสดงใช้ช่วงเชิงความหมายและหน่วยต่อไปนี้ โปรดรักษาค่าให้อยู่ในช่วงเหล่านี้ แม้ว่ารุ่นของไลบรารีบางรุ่นอาจไม่ปฏิเสธค่าที่อยู่นอกช่วงทันที; รูปแบบการนำเสนอเป้าหมายอาจทำการปรับให้เป็นมาตรฐาน, ละเว้น, หรือปฏิเสธข้อมูลที่ไม่ถูกต้องระหว่างการบันทึกหรือเมื่อ PowerPoint เปิดไฟล์

| การทำงาน | พารามิเตอร์ | ช่วงและหน่วยที่ถูกต้อง |
|---|---|---|
| [addBrightnessContrastEffect](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addBrightnessContrastEffect-float-float-) | `brightness`, `contrast` | `-100` ถึง `100` เป็นเปอร์เซ็นต์; `0` ไม่เปลี่ยนแปลงส่วนประกอบ |
| [addGrayScaleEffect](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addGrayScaleEffect--) | ไม่มี | ไม่มีพารามิเตอร์เชิงตัวเลข แอลฟ่าไม่เปลี่ยนแปลง |
| [addDuotoneEffect](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addDuotoneEffect--) | `color1`, `color2` | สองสีสำหรับพิกเซลมืดและสว่าง ค่า RGB และแอลฟ่าใช้ช่วง `0` ถึง `255` ของ `android.graphics.Color` |
| [addTintEffect](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addTintEffect-float-float-) | `hue`, `amount` | Hue อยู่ในช่วง `0` (รวม) ถึง `360` (ไม่รวม) หน่วยเป็นองศา; amount อยู่ในช่วง `-100` ถึง `100` เปอร์เซ็นต์ |
| [addHSLEffect](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addHSLEffect-float-float-float-) | `hue`, `saturation`, `luminance` | Hue อยู่ในช่วง `0` (รวม) ถึง `360` (ไม่รวม) หน่วยเป็นองศา; saturation และ luminance อยู่ในช่วง `-100` ถึง `100` เปอร์เซ็นต์ |
| [addColorReplaceEffect](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addColorReplaceEffect--) | `color` | สีทดแทนใช้ค่าช่องตั้งแต่ `0` ถึง `255` ค่าแอลฟ่าเดิมไม่เปลี่ยน |
| [addBlurEffect](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addBlurEffect-double-boolean-) | `radius`, `grow` | radius ต้องไม่มีค่าสลบและวัดเป็น point; `grow` เป็น Boolean ที่กำหนดว่าภาพเบลออาจขยายออกนอกขอบเดิมหรือไม่ |
| [addAlphaModulateFixedEffect](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addAlphaModulateFixedEffect-float-) | `amount` | เปอร์เซ็นต์ที่ไม่มีค่าสลบ ใช้ `0` ถึง `100` สำหรับการปรับความโปร่งใสแบบปกติ: `0` สดใสเต็มที่และ `100` คงค่าแอลฟ่าปัจจุบัน |
| [addAlphaReplaceEffect](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addAlphaReplaceEffect-float-) | `alpha` | `0` ถึง `100` เปอร์เซ็นต์ความทึบ |
| [addAlphaBiLevelEffect](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addAlphaBiLevelEffect-float-) | `threshold` | `0` ถึง `100` เปอร์เซ็นต์ค่าผ่านระดับแอลฟ่า ค่าต่ำกว่าจะเป็นโปร่งใส; ค่าสูงกว่าจะเป็นทึบ |

สำหรับการปรับแอลฟ่าคงที่ ความโปร่งใสและความทึบเป็นค่าตรงข้าม ตัวอย่างเช่น ความโปร่งใส 35% เทียบกับการปรับแอลฟ่า 65%

## **ใช้ความสว่างและคอนทราสต์**

[IImageTransformOperationCollection.addBrightnessContrastEffect](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addBrightnessContrastEffect-float-float-) คืนค่าอ็อบเจกต์ [IBrightnessContrast](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ibrightnesscontrast/) การตั้งค่าสเกลาร์จะถูกส่งเมื่อสร้างอ็อบเจกต์นั้น [IBrightnessContrast.getEffective](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ibrightnesscontrast/#getEffective--) คืนค่าที่คำนวณเสร็จแล้วแบบอ่านอย่างเดียวที่สามารถตรวจสอบหรือบันทึกได้

ตัวอย่างต่อไปนี้เพิ่มความสว่าง 15% และคอนทราสต์ 20% แล้วแสดงตัวอย่างโดยไม่เปลี่ยนแปลงภาพที่ฝังไว้

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

[BrightnessContrast](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/brightnesscontrast/) เป็นส่วนขยายเอฟเฟกต์รูปภาพของ Office 2010 และพกพาน้อยกว่าการปรับระดับแสงของ DrawingML มาตรฐาน เมื่อความสว่างและคอนทราสต์ต้องการให้แก้ไขได้หลังจากรอบ PPTX ให้ใช้ [IImageTransformOperationCollection.addLuminanceEffect](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addLuminanceEffect-float-float-) และตรวจสอบผลลัพธ์หลังจากเปิดไฟล์ใหม่ ส่วนข้อจำกัดรูปแบบอธิบายความแตกต่างนี้อย่างละเอียดเพิ่มเติม

## **ใช้การแปลงสี**

เอฟเฟกต์สีสามารถนำไปใช้แยกกันกับกรอบรูปภาพต่าง ๆ ที่ใช้ทรัพยากรภาพเดียวกัน ตัวอย่างต่อไปนี้สร้างห้ากรอบและใช้สีเทา, duotone, tint, การปรับ HSL, และการเปลี่ยนสี

[IDuotone](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iduotone/) มีพารามิเตอร์สีสองตัวที่แก้ไขได้อย่างอิสระ: `color1` ใช้สำหรับพิกเซลมืด, `color2` ใช้สำหรับพิกเซลสว่าง นี่เป็นตัวอย่างที่ดีของเอฟเฟกต์ที่การตั้งค่าซับซ้อนกว่าค่าที่เป็นสเกลาร์เดียว

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

[addColorReplaceEffect](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addColorReplaceEffect--) แทนที่สีของทุกพิกเซลด้วยสีเดียวคงแอลฟ่าไว้ แตกต่างจาก [addColorChangeEffect](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addColorChangeEffect--) ที่ทำการแมปสีต้นทางหนึ่งเป็นสีเป้าหมายและเปิดเผยรูปแบบสีต้นและปลายทั้งสอง

## **เพิ่มเบลอ, ความโปร่งใส, และเอฟเฟกต์แอลฟ่า**

[addBlurEffect](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addBlurEffect-double-boolean-) มีผลต่อทุกช่องสีรวมทั้งแอลฟ่า ตั้งค่า `grow` เป็น `true` เมื่อขอบเบลออาจขยายออกนอกขอบภาพดั้งเดิม

สำหรับความโปร่งใสสม่ำเสมอ ใช้ [addAlphaModulateFixedEffect](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addAlphaModulateFixedEffect-float-) ซึ่งคูณค่าแอลฟ่าที่มีอยู่ทุกค่า จึงทำให้พิกเซลที่บางส่วนโปร่งใสยังคงแตกต่างตามสัดส่วน [addAlphaReplaceEffect](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addAlphaReplaceEffect-float-) จะกำหนดค่าแอลฟ่าหนึ่งค่าให้กับทุกพิกเซล [addAlphaBiLevelEffect](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addAlphaBiLevelEffect-float-) แปลงแอลฟ่าเป็นสองระดับตามค่าเกณฑ์

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

เอฟเฟกต์แอลฟ่าอื่น ๆ ที่ไม่มีพารามิเตอร์รวมถึง [addAlphaCeilingEffect](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addAlphaCeilingEffect--) ที่ทำให้แอลฟ่าใด ๆ ที่ไม่เป็นศูนย์เป็นทึบเต็ม; [addAlphaFloorEffect](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addAlphaFloorEffect--) ที่ทำให้แอลฟ่าต่ำกว่า 100% เป็นโปร่งใสเต็ม; และ [addAlphaInverseEffect](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addAlphaInverseEffect--) ที่แปลงแอลฟ่าเป็น `100% - alpha`

## **สร้างห่วงโซ่เอฟเฟกต์ที่เรียงลำดับ**

ทุกเมธอด `add...Effect` จะเพิ่มการดำเนินการใหม่ที่ส่วนท้ายของคอลเลกชัน ตัวเรนเดอร์ใช้คอลเลกชันเป็นสายการผลิตที่เรียงลำดับ: ผลลัพธ์ของการดำเนินการ 0 จะกลายเป็นอินพุตของการดำเนินการ 1 เป็นต้น ดังนั้นการจัดลำดับเดียวกันในลำดับที่ต่างกันอาจทำให้ได้ภาพที่ต่างกัน

เช่น การทำสีเทาตามด้วย tint จะลบข้อมูลสีก่อนแล้วค่อยทานสีใหม่ให้ผลลำแสง ส่วนการทำ tint ตามด้วยสีเทาจะลบ tint ที่เพิ่งใส่ไว้ อีกตัวอย่างคือการแทนที่แอลฟ่าที่สามารถเขียนทับค่าแอลฟ่าที่คำนวณโดยการดำเนินการก่อนหน้า ในขณะที่การปรับแอลฟ่าแบบโมดูเลตจะคงความแตกต่างสัมพัทธ์เดิมไว้

ตัวอย่างต่อไปนี้สร้างห่วงโซ่สี่ขั้นตอน, บันทึกเป็น PPTX, เปิดงานนำเสนอใหม่, ตรวจสอบชนิดและลำดับของการดำเนินการ, แล้วเรนเดอร์ผลลัพธ์ที่เปิดใหม่

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

คอลเลกชันไม่ได้บังคับใช้เมทริกซ์ความเข้ากันได้ที่แยกการดำเนินการสี, แอลฟ่า, และเบลอออกเป็นห่วงโซ่ต่างหาก สามารถรวมกันได้แต่บางการรวมอาจไม่เป็นประโยชน์ การแทนที่สีคงที่จะลบความแปรผันของ RGB ที่เกิดจากเอฟเฟกต์สีก่อนหน้า; การทำสีเทาหลัง duotone จะลบสองสีที่เลือกไว้; และการใช้เอฟเฟกต์แอลฟ่า ceiling, floor, replace หรือ bi‑level สามารถทิ้งรายละเอียดแอลฟ่าที่สร้างขึ้นก่อนหน้าได้ สร้างห่วงโซ่ตามลำดับการประมวลผลพิกเซลที่ต้องการ แทนที่จะมองรายการเป็นแฟล็กลักษณะฟอร์แมตที่ไม่มีลำดับ

## **ตรวจสอบค่าที่แก้ไขได้และค่าที่มีผล**

การดำเนินการที่แก้ไขได้คืออ็อบเจกต์ที่เก็บอยู่ใน `ISlidesPicture.getImageTransform` ขึ้นอยู่กับเอฟเฟกต์ อาจเปิดเผยสมาชิกที่เขียนได้โดยตรง ตัวอย่างเช่น [IBlur](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iblur/) เปิดเผย `radius` และ `grow` ที่เขียนได้, [IAlphaModulateFixed](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ialphamodulatefixed/) เปิดเผย `amount`, และ [IAlphaBiLevel](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ialphabilevel/) เปิดเผย `threshold` เอฟเฟกต์สีเช่น [IDuotone](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iduotone/) เปิดเผยอ็อบเจกต์ [IColorFormat](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/icolorformat/) ที่แก้ไขได้

บางอินเทอร์เฟซการดำเนินการ เช่น [IBrightnessContrast](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ibrightnesscontrast/), [IHSL](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ihsl/), [ITint](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/itint/), และ [IAlphaReplace](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ialphareplace/) ไม่เปิดเผยสเกลาร์ที่ใช้สร้างเป็นคุณสมบัติที่เขียนได้ เพื่อเปลี่ยนการตั้งค่าเหล่านั้น ให้ลบการดำเนินการและเพิ่มการแทนที่ในตำแหน่งที่ต้องการ

ข้อมูลที่มีผลที่ส่งกลับโดย `getEffective()` ถูกคำนวณและเป็นแบบอ่าน‑อย่างเดียว ใช้เพื่อแก้ไขสีที่ขึ้นกับธีมและอ่านค่าที่ทำให้เป็นมาตรฐานซึ่งตัวเรนเดอร์ใช้ แต่ไม่ใช่พื้นผิวการแก้ไขเพิ่มเติม ตัวอย่างต่อไปนี้แสดงการวนลูปคอลเลกชันและตรวจสอบค่าที่มีผลในที่ที่ API ให้ไว้

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

เอฟเฟกต์ที่ไม่มีพารามิเตอร์ เช่น สีเทา, แอลฟ่า ceiling, และแอลฟ่า inverse แม้จะมีอ็อบเจกต์ข้อมูลที่มีผลอยู่ แต่ไม่มีการตั้งค่าสเกลาร์ให้พิมพ์ เพียงแค่ความมีอยู่และตำแหน่งในคอลเลกชันเป็นข้อมูลสำคัญ

## **ลบหรือเคลียร์การแปลงรูปภาพ**

ใช้ [IImageTransformOperationCollection.removeAt](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iimagetransformoperationcollection/#removeAt-int-) เพื่อลบการดำเนินการหนึ่งตามดัชนี เนื่องจากดัชนีจะเปลี่ยนหลังการลบ จึงควรค้นหาเป้าหมายก่อนและลบหลังจากวนลูป ตรวจสอบ [ImageTransformOperationCollection.clear](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/imagetransformoperationcollection/#clear--) เพื่อลบทั้งห่วงโซ่

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

การลบหรือเคลียร์การแปลงจะเปลี่ยนเฉพาะการจัดรูปแบบรูปภาพ ไม่ได้ลบ, บีบอัดใหม่, หรือแก้ไขทรัพยากร [IPPImage](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ippimage/) ที่ใช้ซ้ำ

## **พิจารณารูปแบบการนำเสนอและเป้าหมายการส่งออก**

การแปลงรูปภาพเริ่มต้นจาก DrawingML ดังนั้น PPTX เป็นรูปแบบที่แก้ไขได้ที่แนะนำสำหรับห่วงโซ่เอฟเฟกต์ แม้กับ PPTX ไม่ใช่ทุกการดำเนินการจะมีความพกพาเท่ากัน:

- การดำเนินการ DrawingML มาตรฐานเช่น luminance, grayscale, duotone, tint, HSL, blur, และเอฟเฟกต์แอลฟ่าแบบทั่วไป มีโอกาสอยู่รอดจากรอบ PPTX มากที่สุด ควรเปิดไฟล์ที่สร้างขึ้นใหม่และตรวจสอบคอลเลกชันเสมอเมื่อความคงที่เป็นข้อกำหนด
- [BrightnessContrast](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/brightnesscontrast/) เป็นส่วนขยายของ Office 2010 ไม่ใช่การดำเนินการ luminance ของ DrawingML มาตรฐาน สามารถใช้เพื่อเรนเดอร์ในหน่วยความจำได้ แต่ไม่รับประกันว่าจะคงเป็น [IBrightnessContrast](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ibrightnesscontrast/) ที่แก้ไขได้หลังการบันทึกและเปิด PPTX ใหม่ แนะนำให้ใช้ [addLuminanceEffect](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addLuminanceEffect-float-float-) สำหรับการปรับความสว่างและคอนทราสต์ที่คงที่
- รูปแบบไบนารี PPT มาก่อนโมเดลเอฟเฟกต์ DrawingML เต็มรูปแบบ การบันทึกเป็น PPT อาจละเว้นการดำเนินการที่ไม่รองรับ, ลดห่วงโซ่ให้เป็นส่วนย่อยที่รองรับ, หรือประมาณภาพ อย่าใช้ PPT เป็นรูปแบบการตรวจสอบสำหรับห่วงโซ่แก้ไขที่ซับซ้อน
- การเรนเดอร์เป็น PNG, JPEG, TIFF, PDF, SVG, HTML หรือรูปแบบแสดงผลอื่น ๆ จะนำห่วงโซ่ที่สนับสนุนไปใช้กับภาพที่เรนเดอร์ ผลลัพธ์เหล่านั้นไม่บรรจุ `IImageTransformOperationCollection` ที่แก้ไขได้; รูปแบบภาพจะทำให้ผลลัพธ์แปรเป็นพิกเซล, และการส่งออกเอกสาร/เวกเตอร์จะเก็บการแสดงผลของตนเอง
- เอฟเฟกต์ไม่ได้ทำให้ภาพเชื่อมโยงเป็นไฟล์ที่รวมเอง การเรนเดอร์รูปภาพที่เชื่อมโยงยังต้องอาศัยทรัพยากรเชื่อมโยงที่มีอยู่เมื่อเปิดงานนำเสนอ

ผู้บริโภคงานนำเสนอที่ต่างกันอาจเรนเดอร์กรณีขอบต่าง ๆ แตกต่างกันโดยเฉพาะเมื่อรวมหลายเอฟเฟกต์แอลฟ่า หรือสี‑ควันลองทดสอบทั้งรอบการแก้ไขและรูปแบบส่งออกสุดท้ายด้วยเวอร์ชัน Aspose.Slides ที่ใช้ในสภาพแวดล้อมการผลิต

## **คำถามที่พบบ่อย**

**การดำเนินการแปลงภาพทำให้ข้อมูลภาพที่ฝังไว้เปลี่ยนหรือไม่?**

ไม่ การดำเนินการเป็นของ `ISlidesPicture` ที่ใช้โดยการเติมรูปภาพ `IPPImage` ดำเนินการโดยพื้นฐานยังคงไม่เปลี่ยนแปลง

**กรอบรูปภาพสองใบที่ใช้ `IPPImage` เดียวกันจะแชร์เอฟเฟกต์กันหรือไม่?**

ไม่ การใช้ `IPPImage` เดียวกันช่วยลดข้อมูลภาพซ้ำซ้อน แต่ละกรอบรูปภาพโดยปกติมี `ISlidesPicture` และคอลเลกชันการแปลงของตนเอง

**สามารถรวมเอฟเฟกต์สี, เบลอ, และแอลฟ่าได้หรือไม่?**

ได้ คอลเลกชันรับเอฟเฟกต์เหล่านี้ในห่วงโซ่ที่เรียงลำดับ พิจารณาว่าการดำเนินการแต่ละขั้นจะทำอะไรกับผลลัพธ์ของขั้นก่อนหน้า เพราะเอฟเฟกต์แทนที่และเกณฑ์อาจทิ้งรายละเอียดสีหรือแอลฟ่าเดิมไป

**ทำไมค่าที่มีผลจึงเป็นแบบอ่าน‑อย่างเดียว?**

ค่าที่มีผลเป็นค่าที่คำนวณแล้วใช้สำหรับการเรนเดอร์ รวมถึงสีที่แก้ไขแล้ว ให้แก้ไขการดำเนินการที่เก็บในคอลเลกชันเมื่อมีสมาชิกที่เขียนได้ มิฉะนั้นลบและเพิ่มโดยใช้พารามิเตอร์การสร้างใหม่

**ควรใช้รูปแบบใดเพื่อคงห่วงโซ่การแปลง?**

ใช้ PPTX และตรวจสอบไฟล์โดยการเปิดใหม่ PPT เก่าไม่สามารถแสดงโมเดลเอฟเฟกต์ DrawingML เต็มรูปแบบได้ และรูปแบบส่งออกที่เรนเดอร์จะเก็บเพียงลักษณะการแสดงผล ไม่ได้เก็บการดำเนินการแปลงที่แก้ไขได้