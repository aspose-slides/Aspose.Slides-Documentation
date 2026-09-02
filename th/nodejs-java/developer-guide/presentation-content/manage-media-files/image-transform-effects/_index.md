---
title: จัดการเอฟเฟ็กต์การแปลงภาพในงานนำเสนอด้วย JavaScript
linktitle: เอฟเฟ็กต์การแปลงภาพ
type: docs
weight: 11
url: /th/nodejs-java/image-transform-effects/
keywords:
- การแปลงภาพ
- เอฟเฟ็กต์รูปภาพ
- ความสว่าง
- ความคอนทราสต์
- สเกลสีเทา
- ดูโทน
- สีสัน
- HSL
- การแทนที่สี
- เบลอ
- ความโปร่งใส
- เอฟเฟ็กต์อัลฟา
- เชนเอฟเฟ็กต์
- PowerPoint
- งานนำเสนอ
- Node.js
- JavaScript
- Aspose.Slides
description: "ใช้, สร้างเชน, ตรวจสอบ, ลบ และตรวจสอบเอฟเฟ็กต์การแปลงภาพสำหรับกรอบรูปภาพด้วย Aspose.Slides สำหรับ Node.js ผ่าน Java."
---
## **ภาพรวม**

Aspose.Slides แสดงการปรับรูปภาพเป็นคอลเลกชันที่เรียงลำดับของการดำเนินการแปลงภาพ สำหรับกรอบรูปภาพ ให้เริ่มต้นด้วยกรอบที่มี [Picture](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/picture/) และเข้าถึง [Picture.getImageTransform](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/picture/). คอลเลกชันที่คืนค่า [ImageTransformOperationCollection](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/imagetransformoperationcollection/) ให้คุณเพิ่ม ลิสต์ ตรวจสอบ เอาออก และล้างเอฟเฟ็กต์โดยไม่ต้องเขียนทับไบต์ของภาพต้นฉบับ

บทความนี้สาธิตขั้นตอนทำงานครบวงจรสำหรับความสว่างและความคอนทราสต์, การแปลงสี, ทำเบลอ, ความโปร่งใส, เชนเอฟเฟ็กต์ตามลำดับ, ค่าที่มีผล, การลบ, และการตรวจสอบรอบ PPTX

## **ทำความเข้าใจการเป็นเจ้าของเอฟเฟ็กต์และการใช้ซ้ำภาพ**

ทรัพยากรภาพและรูปภาพที่แสดงมันเป็นออบเจ็กต์ที่แตกต่างกัน:

- [PPImage](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/ppimage/) เก็บหรืออ้างอิงข้อมูลภาพต้นฉบับที่เป็นของพรีเซนเทชัน
- [Picture](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/picture/) เป็นส่วนของ picture fill และอ้างอิงไปยังทรัพยากรภาพพร้อมกับเก็บคอลเลกชันการแปลงภาพ
- [PictureFrame](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/pictureframe/) คือรูปทรงสไลด์ที่เป็นเจ้าของ picture fill, geometry, การตั้งค่าครอบตัด, และการจัดรูปแบบระดับกรอบอื่น ๆ

ดังนั้นการดำเนินการแปลงภาพจะไม่แก้ไขไบต์ใน [PPImage](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/ppimage/). เมื่อ [PPImage](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/ppimage/) เดียวกันถูกส่งให้กับ [ShapeCollection.addPictureFrame](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/shapecollection/) มากกว่าหนึ่งครั้ง แต่ละ picture frame ใหม่จะได้รับ [Picture](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/picture/) ของตนเองและคอลเลกชันการแปลงของตนเอง การทำให้กรอบหนึ่งเป็นสเกลสีเทาจะไม่ทำให้กรอบอื่นเป็นสเกลสีเทา แม้ว่าทั้งหมดจะใช้ทรัพยากรภาพที่ฝังไว้เดียวกัน

โมเดล [Picture.getImageTransform](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/picture/) นี้ยังใช้โดย picture fill อื่น ๆ เช่น รูปทรงหรือพื้นหลังสไลด์ ตัวอย่างด้านล่างมุ่งเน้นไปที่ picture frame

## **ใช้ช่วงค่าพารามิเตอร์และหน่วยที่ถูกต้อง**

วิธีการที่สาธิตใช้ช่วงเชิงความหมายและหน่วยต่อไปนี้ อย่าละเลยค่าที่อยู่ในช่วงเหล่านี้แม้เวอร์ชันไลบรารีบางเวอร์ชันอาจไม่ปฏิเสธค่าที่อยู่นอกช่วงโดยทันที; รูปแบบพรีเซนเทชันเป้าหมายอาจทำให้ค่าปกติ, ลบ, หรือปฏิเสธข้อมูลที่ไม่ถูกต้องระหว่างการบันทึกหรือเมื่อ PowerPoint เปิดไฟล์

| การดำเนินการ | พารามิเตอร์ | ช่วงค่าและหน่วยที่ถูกต้อง |
|---|---|---|
| [addBrightnessContrastEffect](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/imagetransformoperationcollection/) | `brightness`, `contrast` | `-100` ถึง `100`, เปอร์เซ็นต์; `0` ไม่เปลี่ยนส่วนประกอบ |
| [addGrayScaleEffect](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/imagetransformoperationcollection/) | ไม่มี | ไม่มีพารามิเตอร์ตัวเลข ค่าอัลฟาไม่เปลี่ยน |
| [addDuotoneEffect](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/imagetransformoperationcollection/) | `color1`, `color2` | สองสีสำหรับพิกเซลมืดและสีอ่อน ช่องสี RGB และอัลฟาใน `java.awt.Color` ใช้ค่า `0` ถึง `255` |
| [addTintEffect](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/imagetransformoperationcollection/) | `hue`, `amount` | Hue อยู่ระหว่าง `0` รวมถึงถึง `360` ไม่รวม, เป็นองศา; amount อยู่ระหว่าง `-100` ถึง `100`, เปอร์เซ็นต์ |
| [addHSLEffect](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/imagetransformoperationcollection/) | `hue`, `saturation`, `luminance` | Hue อยู่ระหว่าง `0` รวมถึงถึง `360` ไม่รวม, เป็นองศา; saturation และ luminance อยู่ระหว่าง `-100` ถึง `100`, เปอร์เซ็นต์ |
| [addColorReplaceEffect](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/imagetransformoperationcollection/) | `color` | สีที่แทนที่ใช้ค่าช่องจาก `0` ถึง `255` ค่าอัลฟ่าเดิมไม่เปลี่ยน |
| [addBlurEffect](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/imagetransformoperationcollection/) | `radius`, `grow` | radius ต้องไม่เป็นลบและวัดเป็นจุด; `grow` เป็น Boolean ที่กำหนดว่าภาพเบลออาจขยายออกนอกขอบเดิมหรือไม่ |
| [addAlphaModulateFixedEffect](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/imagetransformoperationcollection/) | `amount` | เปอร์เซ็นต์ไม่เป็นลบ ใช้ `0` ถึง `100` สำหรับการปรับความทึบธรรมดา: `0` คือโปร่งใสเต็มและ `100` รักษาอัลฟาเดิม |
| [addAlphaReplaceEffect](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/imagetransformoperationcollection/) | `alpha` | `0` ถึง `100`, เปอร์เซ็นต์ความทึบ |
| [addAlphaBiLevelEffect](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/imagetransformoperationcollection/) | `threshold` | `0` ถึง `100`, เปอร์เซ็นต์ค่าธreshold ของอัลฟา ค่าใต้มันจะกลายเป็นโปร่งใส; ค่าเท่ากับหรือสูงกว่าจะกลายเป็นทึบ |

สำหรับการโมเดลอัลฟ่าคงที่ ความโปร่งใสและความทึบเป็นสิ่งที่ตรงกัน ตัวอย่างเช่น ความโปร่งใส 35% มีค่าโมดูลอัลฟ่าเท่ากับ 65%

## **นำความสว่างและความคอนทราสต์ไปใช้**

[ImageTransformOperationCollection.addBrightnessContrastEffect](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/imagetransformoperationcollection/) คืนค่าอ็อบเจ็กต์ [BrightnessContrast](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/brightnesscontrast/) การตั้งค่าสเกลาร์จะถูกส่งขณะสร้างออบเจ็กต์ [BrightnessContrast.getEffective](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/brightnesscontrast/) คืนค่าที่คำนวณได้แบบอ่านอย่างเดียวซึ่งสามารถตรวจสอบหรือบันทึกได้

ตัวอย่างต่อไปนี้เพิ่มความสว่าง 15% และคอนทราสต์ 20% แล้วแสดงภาพตัวอย่างโดยไม่แก้ไขภาพที่ฝังไว้:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    let image;
    const sourceImage = aspose.slides.Images.fromFile("photo.png");
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        sourceImage.dispose();
    }

    const pictureFrame = slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 50, 50, 400, 260, image);
    const imageTransform = pictureFrame.getPictureFormat().getPicture().getImageTransform();
    const brightnessContrast = imageTransform.addBrightnessContrastEffect(15, 20);

    const effectiveValues = brightnessContrast.getEffective();
    console.log("Brightness: " + effectiveValues.getBrightness() + "%");
    console.log("Contrast: " + effectiveValues.getContrast() + "%");

    const preview = slide.getImage();
    try {
        preview.save("brightness-contrast-preview.png", aspose.slides.ImageFormat.Png);
    } finally {
        preview.dispose();
    }
} finally {
    presentation.dispose();
}
```

[BrightnessContrast](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/brightnesscontrast/) เป็นส่วนขยายเอฟเฟ็กต์รูปภาพของ Office 2010 และมีความพกพาน้อยกว่าการใช้เอฟเฟ็กต์ luminance ของ DrawingML มาตรฐาน หากต้องการให้ความสว่างและคอนทราสต์ยังคงแก้ไขได้หลังรอบ PPTX ให้ใช้ [ImageTransformOperationCollection.addLuminanceEffect](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/imagetransformoperationcollection/) และตรวจสอบผลลัพธ์หลังเปิดไฟล์ใหม่ ส่วนของข้อจำกัดรูปแบบอธิบายความแตกต่างนี้อย่างละเอียด

## **นำการแปลงสีไปใช้**

เอฟเฟ็กต์สีสามารถนำไปใช้แยกกันกับ picture frame ต่าง ๆ ที่ใช้ทรัพยากรภาพเดียวกัน ตัวอย่างต่อไปนี้สร้างห้ากรอบและใช้สเกลสีเทา, duotone, tint, การปรับ HSL, และการแทนที่สี

[Duotone](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/duotone/) มีพารามิเตอร์สีสองตัวที่แก้ไขได้อิสระ: `color1` ใช้สำหรับพิกเซลมืด, `color2` ใช้สำหรับพิกเซลอ่อน ซึ่งทำให้เป็นตัวอย่างที่ดีของเอฟเฟ็กต์ที่การตั้งค่าซับซ้อนกว่าค่าการสเกลเดียว

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    let image;
    const sourceImage = aspose.slides.Images.fromFile("photo.png");
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        sourceImage.dispose();
    }

    const grayFrame = slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 20, 20, 180, 120, image);
    grayFrame.getPictureFormat().getPicture().getImageTransform().addGrayScaleEffect();

    const duotoneFrame = slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 220, 20, 180, 120, image);
    const duotone = duotoneFrame.getPictureFormat().getPicture().getImageTransform().addDuotoneEffect();
    duotone.getColor1().setColor(java.newInstanceSync("java.awt.Color", 0, 0, 128));
    duotone.getColor2().setColor(java.newInstanceSync("java.awt.Color", 255, 215, 0));

    const tintFrame = slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 420, 20, 180, 120, image);
    tintFrame.getPictureFormat().getPicture().getImageTransform().addTintEffect(210, 35);

    const hslFrame = slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 120, 170, 180, 120, image);
    hslFrame.getPictureFormat().getPicture().getImageTransform().addHSLEffect(30, 20, -10);

    const replacementFrame = slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 320, 170, 180, 120, image);
    const colorReplacement = replacementFrame.getPictureFormat().getPicture().getImageTransform().addColorReplaceEffect();
    colorReplacement.getColor().setColor(java.newInstanceSync("java.awt.Color", 100, 149, 237));

    presentation.save("color-transformations.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

[addColorReplaceEffect](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/imagetransformoperationcollection/) แทนที่สีของทุกพิกเซลด้วยสีคงที่หนึ่งสีขณะยังคงอัลฟาไว้ แตกต่างจาก [addColorChangeEffect](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/imagetransformoperationcollection/) ที่ทำการแม็พสีต้นฉบับหนึ่งไปยังอีกสีหนึ่งและเปิดเผยรูปแบบสีต้นฉบับและเป้าหมาย

## **เพิ่มเบลอ, ความโปร่งใส, และเอฟเฟ็กต์อัลฟา**

[addBlurEffect](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/imagetransformoperationcollection/) มีผลต่อทุกช่องสีรวมถึงอัลฟา ตั้งค่า `grow` เป็น `true` เมื่อต้องการให้ขอบเบลอขยายเกินขอบของภาพเดิม

สำหรับความโปร่งใสแบบสม่ำเสมอ ใช้ [addAlphaModulateFixedEffect](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/imagetransformoperationcollection/) ซึ่งทำการคูณค่าที่อัลฟ่าทุกค่าที่มีอยู่ ดังนั้นพิกเซลที่โปร่งใสบางส่วนจะยังคงแตกต่างกันตามสัดส่วน [addAlphaReplaceEffect](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/imagetransformoperationcollection/) แทนที่ค่าอัลฟ่าทั้งหมดด้วยค่าเดียว [addAlphaBiLevelEffect](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/imagetransformoperationcollection/) แปลงอัลฟ่าเป็นสองระดับตาม threshold

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    let image;
    const sourceImage = aspose.slides.Images.fromFile("photo.png");
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        sourceImage.dispose();
    }

    const blurredFrame = slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 20, 20, 200, 140, image);
    const blur = blurredFrame.getPictureFormat().getPicture().getImageTransform().addBlurEffect(4.5, true);
    blur.setRadius(5);

    const transparentFrame = slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 240, 20, 200, 140, image);
    const alphaModulate = transparentFrame.getPictureFormat().getPicture().getImageTransform().addAlphaModulateFixedEffect(65);
    alphaModulate.setAmount(60);

    const uniformAlphaFrame = slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 20, 180, 200, 140, image);
    uniformAlphaFrame.getPictureFormat().getPicture().getImageTransform().addAlphaReplaceEffect(55);

    const binaryAlphaFrame = slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 240, 180, 200, 140, image);
    const alphaBiLevel = binaryAlphaFrame.getPictureFormat().getPicture().getImageTransform().addAlphaBiLevelEffect(50);
    alphaBiLevel.setThreshold(45);
    binaryAlphaFrame.getPictureFormat().getPicture().getImageTransform().addAlphaInverseEffect();

    presentation.save("blur-and-alpha-effects.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

เอฟเฟ็กต์อัลฟ่าอื่น ๆ ที่ไม่มีพารามิเตอร์ ได้แก่ [addAlphaCeilingEffect](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/imagetransformoperationcollection/) ซึ่งทำให้ทุกอัลฟ่าที่ไม่เป็นศูนย์เต็มทึบ; [addAlphaFloorEffect](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/imagetransformoperationcollection/) ซึ่งทำให้อัลฟ่าที่ต่ำกว่า 100% เต็มโปร่งใส; และ [addAlphaInverseEffect](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/imagetransformoperationcollection/) ซึ่งเปลี่ยนอัลฟ่าเป็น `100% - alpha`

## **สร้างเชนเอฟเฟ็กต์ตามลำดับ**

แต่ละเมธอด `add...Effect` จะเพิ่มอ็อบเจ็กต์ใหม่ต่อท้ายคอลเลกชัน ตัวเรนเดอร์ใช้คอลเลกชันเป็นไพรไลน์ตามลำดับ: ผลลัพธ์ของอ็อบเจ็กต์ที่ 0 กลายเป็นอินพุตของอ็อบเจ็กต์ที่ 1 เป็นต้น ดังนั้นการจัดลำดับอ็อบเจ็กต์เดียวกันในลำดับที่ต่างกันอาจให้ภาพที่แตกต่างกัน

ตัวอย่างเช่น การทำสเกลสีเทาก่อน tint จะลบข้อมูลสีอ่อนแล้วทำสีใหม่จากผลลัพธ์ลูมินัส ส่วน tint ก่อนสเกลสีเท่าจะทำให้ tint หายไป อีกตัวอย่างคือการแทนที่อัลฟ่าสามารถเขียนทับค่าอัลฟ่าที่คำนวณจากออปเจ็กต์ก่อนหน้าได้ ในขณะที่การโมเดลอัลฟ่าจะคงความแตกต่างสัมพัทธ์ไว้

ตัวอย่างต่อไปนี้สร้างเชนสี่ออปเจ็กต์ บันทึกเป็น PPTX เปิดพรีเซนเทชันใหม่ ตรวจสอบชนิดออปเจ็กต์และลำดับของพวกมัน แล้วเรนเดอร์ผลลัพธ์ที่เปิดใหม่:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    let image;
    const sourceImage = aspose.slides.Images.fromFile("photo.png");
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        sourceImage.dispose();
    }

    const pictureFrame = slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 50, 50, 400, 260, image);
    const imageTransform = pictureFrame.getPictureFormat().getPicture().getImageTransform();
    imageTransform.addGrayScaleEffect();
    imageTransform.addTintEffect(220, 25);
    imageTransform.addBlurEffect(2.5, false);
    imageTransform.addAlphaModulateFixedEffect(80);

    presentation.save("image-transform-chain.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}

const reopenedPresentation = new aspose.slides.Presentation("image-transform-chain.pptx");
try {
    const reopenedShape = reopenedPresentation.getSlides().get_Item(0).getShapes().get_Item(0);

    if (java.instanceOf(reopenedShape, "com.aspose.slides.IPictureFrame")) {
        const reopenedTransform = reopenedShape.getPictureFormat().getPicture().getImageTransform();
        const orderIsPreserved = reopenedTransform.size() === 4 &&
            java.instanceOf(reopenedTransform.get_Item(0), "com.aspose.slides.IGrayScale") &&
            java.instanceOf(reopenedTransform.get_Item(1), "com.aspose.slides.ITint") &&
            java.instanceOf(reopenedTransform.get_Item(2), "com.aspose.slides.IBlur") &&
            java.instanceOf(reopenedTransform.get_Item(3), "com.aspose.slides.IAlphaModulateFixed");
        console.log(orderIsPreserved ? "The effect chain was preserved." : "The effect chain changed during the round trip.");

        const renderedSlide = reopenedPresentation.getSlides().get_Item(0).getImage();
        try {
            renderedSlide.save("reopened-effect-chain.png", aspose.slides.ImageFormat.Png);
        } finally {
            renderedSlide.dispose();
        }
    } else {
        console.log("The reopened shape is not a picture frame.");
    }
} finally {
    reopenedPresentation.dispose();
}
```

คอลเลกชันไม่ได้กำหนดเมทริกซ์ความเข้ากันได้ที่จำกัดให้เอฟเฟ็กต์สี, อัลฟ่า และเบลออยู่ในเชนแยกกัน พวกมันสามารถรวมกันได้ แต่บางการรวมอาจไม่มีประโยชน์ การแทนที่สีคงที่จะลบความแปรปรวนของ RGB ที่เกิดจากเอฟเฟ็กต์สีก่อนหน้า; การทำสเกลสีเทาหลัง duotone จะลบสีที่เลือกสองสี; การ ceiling, floor, replacement หรือ bi-level ของอัลฟ่าสามารถทิ้งรายละเอียดอัลฟ่าที่สร้างมาก่อนได้ สร้างเชนตามลำดับการประมวลผลพิกเซลที่ต้องการ แทนที่จะมองรายการเป็นแฟล็กการจัดรูปแบบที่ไม่มีลำดับ

## **ตรวจสอบค่าที่แก้ไขได้และค่าที่มีผล**

ออปเจ็กต์ที่แก้ไขได้คืออ็อบเจ็กต์ที่เก็บอยู่ใน [Picture.getImageTransform](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/picture/). ตามเอฟเฟ็กต์อาจเปิดเผยสมาชิกที่เขียนได้โดยตรง ตัวอย่างเช่น [Blur](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/blur/) เปิดเผย `radius` และ `grow` ที่เขียนได้, [AlphaModulateFixed](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/alphamodulatefixed/) เปิดเผย `amount`, และ [AlphaBiLevel](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/alphabilevel/) เปิดเผย `threshold`. เอฟเฟ็กต์สีอย่าง [Duotone](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/duotone/) เปิดเผยอ็อบเจ็กต์ [ColorFormat](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/colorformat/) ที่แก้ไขได้

บางออปเจ็กต์ เช่น [BrightnessContrast](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/brightnesscontrast/), [HSL](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/hsl/), [Tint](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/tint/), และ [AlphaReplace](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/alphareplace/) ไม่เปิดเผยสเกลาร์ที่ใช้สร้างเป็นคุณสมบัติที่เขียนได้ เพื่อตั้งค่าดังกล่าว ให้ลบออปเจ็กต์นั้นและเพิ่มออปเจ็กต์ใหม่ในตำแหน่งที่ต้องการ

ข้อมูลที่ได้จาก `getEffective()` คำนวณและเป็นแบบอ่านอย่างเดียว มีประโยชน์ในการแก้ไขสีที่ขึ้นกับธีมและอ่านค่าที่ทำให้เป็นมาตรฐานที่เรนเดอร์ใช้ แต่ไม่ใช่พื้นผิวนการแก้ไขอีกชั้น ตัวอย่างต่อไปนี้ลิสต์เชนและตรวจสอบค่าที่มีผลที่ API ให้มา:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation("image-transform-chain.pptx");
try {
    const shapes = presentation.getSlides().get_Item(0).getShapes();
    let pictureFrame = null;

    for (let index = 0; index < shapes.size(); index++) {
        const shape = shapes.get_Item(index);
        if (java.instanceOf(shape, "com.aspose.slides.IPictureFrame")) {
            pictureFrame = shape;
            break;
        }
    }

    if (pictureFrame != null) {
        const imageTransform = pictureFrame.getPictureFormat().getPicture().getImageTransform();

        for (let index = 0; index < imageTransform.size(); index++) {
            const operation = imageTransform.get_Item(index);
            console.log(index + ": " + operation.getClass().getSimpleName());

            if (java.instanceOf(operation, "com.aspose.slides.IBrightnessContrast")) {
                const data = operation.getEffective();
                console.log("  Brightness: " + data.getBrightness());
                console.log("  Contrast: " + data.getContrast());
            } else if (java.instanceOf(operation, "com.aspose.slides.ILuminance")) {
                const data = operation.getEffective();
                console.log("  Brightness: " + data.getBrightness());
                console.log("  Contrast: " + data.getContrast());
            } else if (java.instanceOf(operation, "com.aspose.slides.IDuotone")) {
                const data = operation.getEffective();
                console.log("  Dark color: " + data.getColor1());
                console.log("  Light color: " + data.getColor2());
            } else if (java.instanceOf(operation, "com.aspose.slides.IColorReplace")) {
                const data = operation.getEffective();
                console.log("  Replacement color: " + data.getColor());
            } else if (java.instanceOf(operation, "com.aspose.slides.IHSL")) {
                const data = operation.getEffective();
                console.log("  HSL: " + data.getHue() + ", " + data.getSaturation() + ", " + data.getLuminance());
            } else if (java.instanceOf(operation, "com.aspose.slides.ITint")) {
                const data = operation.getEffective();
                console.log("  Tint: " + data.getHue() + ", " + data.getAmount());
            } else if (java.instanceOf(operation, "com.aspose.slides.IBlur")) {
                const data = operation.getEffective();
                console.log("  Blur radius: " + data.getRadius() + " pt");
            } else if (java.instanceOf(operation, "com.aspose.slides.IAlphaModulateFixed")) {
                const data = operation.getEffective();
                console.log("  Alpha amount: " + data.getAmount() + "%");
            } else if (java.instanceOf(operation, "com.aspose.slides.IAlphaReplace")) {
                const data = operation.getEffective();
                console.log("  Replacement alpha: " + data.getAlpha() + "%");
            } else if (java.instanceOf(operation, "com.aspose.slides.IAlphaBiLevel")) {
                const data = operation.getEffective();
                console.log("  Alpha threshold: " + data.getThreshold() + "%");
            }
        }
    }
} finally {
    presentation.dispose();
}
```

เอฟเฟ็กต์ที่ไม่มีพารามิเตอร์เช่นสเกลสีเทา, alpha ceiling, และ alpha inverse ยังมีอ็อบเจ็กต์ข้อมูลที่มีผล แต่ไม่มีการตั้งค่าสเกลาร์ให้พิมพ์ ความสำคัญอยู่ที่การมีอยู่และตำแหน่งในคอลเลกชัน

## **ลบหรือเคลียร์การแปลงภาพ**

ใช้ [ImageTransformOperationCollection.removeAt](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/imagetransformoperationcollection/) เพื่อลบออปเจ็กต์หนึ่งตามดัชนี เนื่องจากดัชนีจะสลับหลังการลบ ให้ค้นหาเป้าหมายก่อนแล้วลบหลังจากลิสต์ ใช้ [ImageTransformOperationCollection.clear](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/imagetransformoperationcollection/) เพื่อลบเชนทั้งหมด

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation("image-transform-chain.pptx");
try {
    const shapes = presentation.getSlides().get_Item(0).getShapes();
    let pictureFrame = null;

    for (let index = 0; index < shapes.size(); index++) {
        const shape = shapes.get_Item(index);
        if (java.instanceOf(shape, "com.aspose.slides.IPictureFrame")) {
            pictureFrame = shape;
            break;
        }
    }

    if (pictureFrame != null) {
        const imageTransform = pictureFrame.getPictureFormat().getPicture().getImageTransform();
        let blurIndex = -1;

        for (let index = 0; index < imageTransform.size(); index++) {
            if (java.instanceOf(imageTransform.get_Item(index), "com.aspose.slides.IBlur")) {
                blurIndex = index;
                break;
            }
        }

        if (blurIndex >= 0) {
            imageTransform.removeAt(blurIndex);
            console.log("The blur operation was removed.");
        }

        imageTransform.clear();
        console.log("Remaining operations: " + imageTransform.size());
        presentation.save("image-transforms-cleared.pptx", aspose.slides.SaveFormat.Pptx);
    }
} finally {
    presentation.dispose();
}
```

การลบหรือเคลียร์การแปลงจะเปลี่ยนเฉพาะการจัดรูปแบบของ picture เท่านั้น ไม่ได้ลบ, บีบอัดใหม่, หรือแก้ไขทรัพยากร [PPImage](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/ppimage/) ที่ใช้ซ้ำ

## **พิจารณารูปแบบพรีเซนเทชันและเป้าหมายการส่งออก**

การแปลงภาพมีต้นกำเนิดจาก DrawingML ดังนั้น PPTX จึงเป็นรูปแบบที่แก้ไขได้แนะนำสำหรับเชนเอฟเฟ็กต์ แม้ใช้ PPTX ยังไม่ทุกออปเจ็กต์มีพกพาเท่ากัน:

- ออปเจ็กต์ DrawingML มาตรฐานเช่น luminance, grayscale, duotone, tint, HSL, blur, และออปเจ็กต์อัลฟ่าทั่วไป มีโอกาสอยู่รอดจากรอบ PPTX สูงสุด ควรเปิดไฟล์ที่สร้างแล้วและตรวจสอบคอลเลกชันเมื่อต้องการให้คงที่
- [BrightnessContrast](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/brightnesscontrast/) เป็นส่วนขยาย Office 2010 ไม่ใช่ออปเจ็กต์ luminance ของ DrawingML มาตรฐาน สามารถใช้สำหรับการเรนเดอร์ในหน่วยความจำได้ แต่ไม่รับประกันว่าจะคงเป็นออปเจ็กต์ [BrightnessContrast](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/brightnesscontrast/) ที่แก้ไขได้หลังบันทึกและเปิด PPTX ใหม่ ควรใช้ [addLuminanceEffect](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/imagetransformoperationcollection/) สำหรับการปรับความสว่างและคอนทราสต์ที่คงที่
- รูปแบบไบนารี PPT มีอายุก่อนโมเดลเอฟเฟ็กต์ DrawingML เต็มรูปแบบ การบันทึกเป็น PPT อาจละทิ้งออปเจ็กต์ที่ไม่รองรับ ลดเชนให้อยู่ในส่วนที่สนับสนุน หรือประมาณลักษณะไม่ครบถ้วน อย่าใช้ PPT เป็นรูปแบบตรวจสอบสำหรับเชนที่แก้ไขได้ซับซ้อน
- การเรนเดอร์เป็น PNG, JPEG, TIFF, PDF, SVG, HTML หรือเอาต์พุตภาพอื่น ๆ จะใช้เชนที่รองรับเพื่อสร้างภาพผลลัพธ์ เอาต์พุตเหล่านี้ไม่บรรจุ [ImageTransformOperationCollection](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/imagetransformoperationcollection/); รูปแบบราสเตอร์จะทำให้ผลลัพธ์ฟลัตเทนเป็นพิกเซล และการส่งออกเอกสาร/เวกเตอร์จะเก็บการเรนเดอร์ของตนเอง
- เอฟเฟ็กต์ไม่ทำให้ภาพที่ลิงก์เป็นอิสระ การเรนเดอร์ภาพที่ลิงก์ยังคงพึ่งพาทรัพยากรที่ลิงก์อยู่เมื่อพรีเซนเทชันโหลด

ผู้ใช้งานพรีเซนเทชันต่างกันอาจเรนเดอร์กรณีขอบเขตที่แตกต่างกัน โดยเฉพาะเมื่อรวมหลายออปเจ็กต์อัลฟ่าหรือการควอนไนต์สี สำหรับผลลัพธ์สำคัญ ควรทดสอบทั้งรอบการแก้ไขและรูปแบบส่งออกสุดท้ายด้วย Aspose.Slides เวอร์ชันเดียวกับที่ใช้ในการผลิต

## **คำถามที่พบบ่อย**

**เอฟเฟ็กต์การแปลงภาพทำให้ข้อมูลภาพฝังเปลี่ยนหรือไม่?**

ไม่ การดำเนินการเป็นของ [Picture](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/picture/) ที่ใช้โดย picture fill ไบต์ของ [PPImage](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/ppimage/) พื้นฐานยังคงไม่เปลี่ยน

**สอง picture frame ที่ใช้ [PPImage](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/ppimage/) เดียวกันจะแชร์เอฟเฟ็กต์หรือไม่?**

ไม่ การใช้ซ้ำ [PPImage](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/ppimage/) ช่วยลดข้อมูลภาพซ้ำซ้อน แต่แต่ละ picture frame ปกติมี [Picture](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/picture/) และคอลเลกชันการแปลงภาพของตนเอง

**สามารถรวมเอฟเฟ็กต์สี, เบลอ, และอัลฟ่าได้หรือไม่?**

ได้ คอลเลกชันรับเอฟเฟ็กต์เหล่านั้นในเชนตามลำดับหนึ่ง พิจารณาผลของแต่ละการดำเนินการต่อผลของการดำเนินการก่อนหน้า เนื่องจากการแทนที่และการตั้งค่าขีดจำกัดอาจลบรายละเอียดสีหรืออัลฟ่าที่สร้างมาก่อน

**ทำไมค่าที่มีผลจึงเป็นแบบอ่านอย่างเดียว?**

ข้อมูลที่มีผลเป็นค่าที่คำนวณสำหรับการเรนเดอร์ รวมถึงสีที่แก้ไขตามธีม แก้ไขออปเจ็กต์ที่เก็บในคอลเลกชันเมื่อมีสมาชิกที่เขียนได้; หากไม่มีให้ลบและเพิ่มออปเจ็กต์ใหม่พร้อมพารามิเตอร์การสร้างใหม่

**ควรใช้รูปแบบใดเพื่อคงเชนการแปลง?**

ใช้ PPTX และตรวจสอบไฟล์โดยการเปิดใหม่ ไม่แนะนำให้ใช้ PPT เก่าเนื่องจากไม่สามารถแสดงโมเดลเอฟเฟ็กต์ DrawingML อย่างเต็มรูปแบบ และรูปแบบการส่งออกที่เรนเดอร์จะเก็บเฉพาะรูปลักษณ์ ไม่ได้เก็บเอฟเฟ็กต์การแปลงที่แก้ไขได้