---
title: จัดการเอฟเฟกต์การแปลงภาพในงานนำเสนอด้วย JavaScript
linktitle: เอฟเฟกต์การแปลงภาพ
type: docs
weight: 11
url: /th/nodejs-java/image-transform-effects/
keywords:
- การแปลงภาพ
- เอฟเฟกต์รูปภาพ
- ความสว่าง
- ความแตกต่าง
- ระดับสีเทา
- โทนสีคู่
- สีสัน
- HSL
- การแทนที่สี
- เบลอ
- ความโปร่งใส
- เอฟเฟกต์อัลฟา
- เชนเอฟเฟกต์
- PowerPoint
- งานนำเสนอ
- Node.js
- จาวาสคริปต์
- Aspose.Slides
description: "นำไปใช้, เชน, ตรวจสอบ, ลบ, และยืนยันเอฟเฟกต์การแปลงภาพสำหรับกรอบรูปด้วย Aspose.Slides สำหรับ Node.js ผ่าน Java."
---
## **ภาพรวม**

Aspose.Slides แสดงการปรับรูปภาพเป็นคอลเลกชันที่เรียงลำดับของการดำเนินการแปลงภาพ (image transform operations) . สำหรับกรอบรูป ให้เริ่มจาก [Picture](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picture/) ของกรอบและเข้าถึง [Picture.getImageTransform](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picture/). คอลเลกชัน [ImageTransformOperationCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/) ที่ส่งกลับมาจะทำให้คุณสามารถเพิ่ม, ลิสต์, ตรวจสอบ, ลบและล้างเอฟเฟกต์โดยไม่ต้องเขียนทับไบต์ของรูปภาพต้นฉบับใหม่

บทความนี้สาธิตเวิร์คฟลว์เต็มสำหรับความสว่างและคอนทราสต์, การแปลงสี, เบลอ, ความโปร่งใส, เชนเอฟเฟกต์ที่เรียงลำดับ, ค่าที่มีประสิทธิภาพ, การลบ, และการตรวจสอบรอบ PPTX

## **ทำความเข้าใจความเป็นเจ้าของเอฟเฟกต์และการใช้ภาพซ้ำ**

ทรัพยากรภาพและรูปภาพที่แสดงมันเป็นอ็อบเจ็กต์ที่แตกต่างกัน:

- [PPImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ppimage/) เก็บหรืออ้างอิงข้อมูลภาพต้นฉบับที่เป็นของงานนำเสนอ
- [Picture](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picture/) เป็นส่วนของการเติมรูปและอ้างอิงทรัพยากรภาพพร้อมกับเก็บคอลเลกชันการแปลงภาพ
- [PictureFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pictureframe/) คือรูปร่างบนสไลด์ที่เป็นเจ้าของการเติมรูป, รูปร่าง, การตัดครอปและการจัดรูปแบบระดับกรอบอื่น ๆ

ดังนั้นการดำเนินการแปลงภาพจะไม่แก้ไขไบต์ใน [PPImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ppimage/). เมื่อ [PPImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ppimage/) เดียวกันถูกส่งให้กับ [ShapeCollection.addPictureFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/) มากกว่าหนึ่งครั้ง แต่ละกรอบรูปใหม่จะได้รับ [Picture](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picture/) ของตนเองและคอลเลกชันการแปลงของตนเอง การทำให้กรอบหนึ่งเป็นระดับสีเทาไม่ทำให้กรอบอื่นเป็นระดับสีเทา แม้ว่าทั้งหมดจะใช้ทรัพยากรภาพฝังเดียวกัน

โมเดล [Picture.getImageTransform](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picture/) นี้ยังถูกใช้โดยการเติมรูปอื่น ๆ เช่น รูปร่างหรือพื้นหลังสไลด์ ตัวอย่างด้านล่างมุ่งเน้นที่กรอบรูป

## **ใช้ช่วงค่าพารามิเตอร์และหน่วยที่ถูกต้อง**

เมธอดที่นำเสนอใช้ช่วงความหมายและหน่วยต่อไปนี้ . ให้คงค่าภายในช่วงเหล่านี้แม้เวอร์ชันไลบรารีบางเวอร์ชันอาจไม่ปฏิเสธค่าที่อยู่นอกช่วงทันที; รูปแบบการนำเสนอเป้าหมายอาจทำให้ค่าถูกทำให้เป็นมาตรฐาน, ลบ, หรือปฏิเสธข้อมูลที่ไม่ถูกต้องระหว่างการบันทึกหรือเมื่อ PowerPoint เปิดไฟล์

| การดำเนินการ | พารามิเตอร์ | ช่วงและหน่วยที่ถูกต้อง |
|---|---|---|
| [addBrightnessContrastEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/) | `brightness`, `contrast` | `-100` ถึง `100` เปอร์เซ็นต์; `0` จะไม่เปลี่ยนแปลงส่วนประกอบ |
| [addGrayScaleEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/) | None | ไม่มีพารามิเตอร์ตัวเลข; แอลฟาไม่เปลี่ยนแปลง |
| [addDuotoneEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/) | `color1`, `color2` | สองสีสำหรับพิกเซลสีมืดและสีอ่อน; ค่าชannels ของ RGB และแอลฟาใน `java.awt.Color` อยู่ระหว่าง `0` ถึง `255` |
| [addTintEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/) | `hue`, `amount` | Hue อยู่ระหว่าง `0` (รวม) ถึง `360` (ไม่รวม) หน่วยเป็นองศา; amount อยู่ระหว่าง `-100` ถึง `100` เปอร์เซ็นต์ |
| [addHSLEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/) | `hue`, `saturation`, `luminance` | Hue อยู่ระหว่าง `0` ถึง `360` (ไม่รวม) หน่วยเป็นองศา; saturation และ luminance อยู่ระหว่าง `-100` ถึง `100` เปอร์เซ็นต์ |
| [addColorReplaceEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/) | `color` | สีทดแทนใช้ค่า channel ตั้งแต่ `0` ถึง `255`; ค่าแอลฟาเดิมไม่เปลี่ยน |
| [addBlurEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/) | `radius`, `grow` | รัศมีเป็นค่าที่ไม่เป็นลบและวัดเป็น points; `grow` เป็น Boolean ที่ควบคุมว่าภาพเบลออาจขยายออกนอกขอบเดิมหรือไม่ |
| [addAlphaModulateFixedEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/) | `amount` | เปอร์เซ็นต์ที่ไม่เป็นลบ ใช้ `0` ถึง `100` สำหรับการปรับความโปร่งใสแบบปกติ: `0` คือโปร่งใสเต็มและ `100` คงค่าที่มีอยู่ |
| [addAlphaReplaceEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/) | `alpha` | `0` ถึง `100` เปอร์เซ็นต์ความทึบ |
| [addAlphaBiLevelEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/) | `threshold` | `0` ถึง `100` เปอร์เซ็นต์ค่าแอลฟาเกณฑ์; ค่าต่ำกว่าจะกลายเป็นโปร่งใส; ค่าที่เท่าหรือสูงกว่าจะเป็นทึบเต็ม |

สำหรับการปรับแอลฟ่าคงที่ ความโปร่งใสและความทึบเป็นค่าตรงกันข้าม ตัวอย่างเช่น ความโปร่งใส 35% ตรงกับค่าการปรับแอลฟ่า 65%

## **ใช้ความสว่างและคอนทราสต์**

[ImageTransformOperationCollection.addBrightnessContrastEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/) คืนค่าอ็อบเจ็กต์ [BrightnessContrast](https://reference.aspose.com/slides/nodejs-java/aspose.slides/brightnesscontrast/) การตั้งค่าสเกลาร์ถูกส่งเมื่อสร้างอ็อบเจ็กต์ . [BrightnessContrast.getEffective](https://reference.aspose.com/slides/nodejs-java/aspose.slides/brightnesscontrast/) คืนค่าที่คำนวณได้แบบอ่านอย่างเดียวซึ่งสามารถตรวจสอบหรือบันทึกได้

ตัวอย่างต่อไปนี้เพิ่มความสว่าง 15% และคอนทราสต์ 20% แล้วเรนเดอร์พรีวิวโดยไม่แก้ไขรูปภาพฝัง

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

[BrightnessContrast](https://reference.aspose.com/slides/nodejs-java/aspose.slides/brightnesscontrast/) เป็นส่วนขยายเอฟเฟกต์รูปภาพของ Office 2010 และมีความพกพาน้อยกว่าการปรับระดับความสว่างมาตรฐานของ DrawingML . เมื่อความสว่างและคอนทราสต์ต้องการให้แก้ไขได้หลังการวนรอบ PPTX ให้ใช้ [ImageTransformOperationCollection.addLuminanceEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/) และตรวจสอบผลลัพธ์หลังจากเปิดไฟล์ใหม่ . ส่วนข้อจำกัดของรูปแบบอธิบายความแตกต่างนี้เพิ่มเติม

## **ใช้การแปลงสี**

เอฟเฟกต์สีสามารถนำไปใช้แยกจากกันกับกรอบรูปต่าง ๆ ที่ใช้ทรัพยากรภาพเดียวกัน ตัวอย่างต่อไปนี้สร้างห้ากรอบและใช้ระดับสีเทา, duotone, tint, การปรับ HSL, และการแทนที่สี

[Duotone](https://reference.aspose.com/slides/nodejs-java/aspose.slides/duotone/) มีพารามิเตอร์สีสองตัวที่แก้ไขได้อย่างอิสระ: `color1` ใช้สำหรับพิกเซลสีมืด, `color2` ใช้สำหรับพิกเซลสีอ่อน . นี้ทำให้เป็นตัวอย่างที่ดีของเอฟเฟกต์ที่ตั้งค่าซับซ้อนกว่าเพียงค่าสเกลาร์เดียว

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

[addColorReplaceEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/) แทนที่สีของทุกพิกเซลด้วยสีคงที่หนึ่งตัวพร้อมคงค่าแอลฟา . มันจะแตกต่างจาก [addColorChangeEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/) ซึ่งแมปสีต้นทางหนึ่งไปยังสีเป้าหมายและเปิดเผยรูปแบบสีต้นทางและเป้าหมายทั้งสอง

### **ใช้เกณฑ์ความสว่าง (Luminance Threshold)**

เกณฑ์ความสว่างสามารถทำให้เครื่องหมายอ่อนบนหน้าสแกนง่ายต่อการแยกจากพื้นหลัง . [addGrayScaleEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/) คงเฉดสีเทาแบบกลาง; [addBiLevelEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/) แมปความสว่างเป็นสีดำหรือสีขาว, ส่วน [addAlphaBiLevelEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/) ใช้เกณฑ์กับค่าแอลฟา

เกณฑ์ความสว่างอยู่ในช่วง 0% ถึง 100% รวม . พิกเซลที่ต่ำกว่าเกณฑ์จะเป็นสีดำ, พิกเซลที่เท่าหรือสูงกว่าเกณฑ์จะเป็นสีขาว . การเพิ่มเกณฑ์ทำให้เฉดสีหลายสีกลายเป็นสีดำเพราะมากกว่าที่ต่ำกว่าจุดตัด

ดาวน์โหลด [grayscale-swatches.png](grayscale-swatches.png) ไปยังไดเรกทอรีทำงาน . แต่ละป้ายบ่งบอกระดับสีเทาต้นฉบับบนสเกล 0‑255 . ตัวอย่างจะวางต้นฉบับข้างสำเนาสองชุดและบันทึกเกณฑ์ของแต่ละสำเนาในงานนำเสนอ

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation();
try {
    presentation.getSlideSize().setSize(720, 150, slides.SlideSizeScaleType.DoNotScale);
    const shapes = presentation.getSlides().get_Item(0).getShapes();

    const sourceImage = slides.Images.fromFile("grayscale-swatches.png");
    let image;
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        sourceImage.dispose();
    }

    const captions = ["Original", "Threshold 20%", "Threshold 60%"];
    const frames = [];
    for (let i = 0; i < captions.length; i++) {
        const x = 12 + 240 * i;
        const label = shapes.addAutoShape(slides.ShapeType.Rectangle, x, 12, 216, 36);
        label.getTextFrame().setText(captions[i]);
        const frame = shapes.addPictureFrame(slides.ShapeType.Rectangle, x, 60, 216, 72, image);
        frames.push(frame);
    }

    frames[1].getPictureFormat().getPicture().getImageTransform().addBiLevelEffect(20);
    frames[2].getPictureFormat().getPicture().getImageTransform().addBiLevelEffect(60);
    
    presentation.save("luminance-threshold.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

เปิดงานนำเสนอผลลัพธ์ใน PowerPoint เพื่อเปรียบเทียบสามกรอบ . สเวชที่มีป้าย 96 มีความสว่างประมาณ 38% (96 จาก 255) . มันจะกลายเป็นสีขาวที่เกณฑ์ 20% และเป็นสีดำที่เกณฑ์ 60%

![Original grayscale swatches beside the black-and-white results at luminance thresholds of 20% and 60%](luminance-threshold.png)

## **เพิ่มเบลอ, ความโปร่งใส, และเอฟเฟกต์แอลฟ่า**

[addBlurEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/) มีผลต่อทุกช่องสีรวมทั้งแอลฟา . ตั้งค่า `grow` เป็น `true` เมื่อขอบเบลออาจขยายออกนอกขอบรูปต้นฉบับ

สำหรับความโปร่งใสแบบสม่ำเสมอ ให้ใช้ [addAlphaModulateFixedEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/) . มันคูณค่าแอลฟ่าที่มีอยู่ทุกค่า ทำให้พิกเซลที่โปร่งใสบางส่วนยังคงมีอัตราส่วนต่างกันอย่างสัดส่วน . [addAlphaReplaceEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/) จะกำหนดค่าแอลฟ่าเดียวให้กับทุกพิกเซล . [addAlphaBiLevelEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/) แปลงแอลฟ่าเป็นสองระดับตามเกณฑ์

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

เอฟเฟกต์แอลฟ่าที่ไม่มีพารามิเตอร์อื่นรวมถึง [addAlphaCeilingEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/) – ทำให้แอลฟ่าที่ไม่เป็นศูนย์ทั้งหมดเต็มทึบ; [addAlphaFloorEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/) – ทำให้แอลฟ่าต่ำกว่า 100% ทั้งหมดเต็มโปร่งใส; และ [addAlphaInverseEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/) – แปลงแอลฟ่าเป็น `100% - alpha`

## **สร้างเชนเอฟเฟกต์ที่เรียงลำดับ**

แต่ละเมธอด `add...Effect` จะเพิ่มอ็อบเจ็กต์ใหม่ลงท้ายคอลเลกชัน . ตัวเรนเดอร์ใช้คอลเลกชันเป็นสายการผลิตที่เรียงลำดับ: ผลลัพธ์ของอ็อบเจ็กต์ 0 เป็นอินพุตของอ็อบเจ็กต์ 1, เป็นต้น . ดังนั้นการใช้เอฟเฟกต์เดียวกันในลำดับที่ต่างกันอาจสร้างภาพที่แตกต่างกัน

เช่น หากทำระดับสีเทาก่อน tint จะลบข้อมูลสีก่อนแล้วจึงทาตำแหน่งสีใหม่ . ถ้า tint มาก่อนระดับสีเท้า จะลบ tint ไป . เช่นเดียวกัน การแทนที่แอลฟ่าสามารถเขียนทับค่าแอลฟ่าที่คำนวณโดยออบเจ็กต์ก่อนหน้าได้, ขณะที่การปรับแอลฟ่าจะคงความแตกต่างสัมพัทธ์ไว้

ตัวอย่างต่อไปสร้างเชนสี่ขั้นตอน, บันทึกเป็น PPTX, เปิดงานนำเสนอใหม่, ตรวจสอบประเภทอ็อบเจ็กต์และลำดับ, แล้วเรนเดอร์ผลลัพธ์ที่เปิดใหม่:

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

คอลเลกชันไม่ได้บังคับให้มีเมทริกซ์ความเข้ากันได้ที่แยกเอฟเฟกต์สี, แอลฟ่า, และเบลอให้อยู่อย่างแยกกัน . สามารถผสมผสานได้, แต่บางการผสมอาจไม่มีประโยชน์ . ตัวอย่างเช่น การแทนที่สีคงที่จะลบการแปรผัน RGB ที่เกิดจากสีก่อนหน้า; การทำระดับสีเทาหลัง duotone จะลบสีสองสีที่เลือก; และเอฟเฟกต์แอลฟ่าแบบ ceiling, floor, replace หรือ bi‑level สามารถกำจัดรายละเอียดแอลฟ่าที่สร้างขึ้นก่อนหน้า . ควรสร้างเชนตามลำดับการประมวลผลพิกเซลที่ต้องการ, ไม่ใช่พิจารณาเป็นแฟล็กการจัดรูปแบบที่ไม่มีลำดับ

<!-- visual-explanation:image-transform-effects:start -->
[![The same image passes through grayscale then tint, and tint then grayscale. The two final grayscale images have different tones.](visual-image-transform-effects-49aa72211f3a.svg)](visual-image-transform-effects-49aa72211f3a.svg)

*ในภาพจำลอง Aspose.Slides for .NET 26.11 นี้, การใส่สี tint 220° ที่ 25% จะไม่เปลี่ยนภาพระดับสีเทา. การใส่ tint ก่อนระดับสีเทาจะให้โทนสีที่ต่างกัน*
<!-- visual-explanation:image-transform-effects:end -->

## **ตรวจสอบค่าที่แก้ไขได้และค่าที่มีประสิทธิภาพ**

อ็อบเจ็กต์ที่แก้ไขได้คืออ็อบเจ็กต์ที่เก็บอยู่ใน [Picture.getImageTransform](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picture/) . ขึ้นอยู่กับเอฟเฟกต์, อาจเปิดเผยสมาชิกที่เขียนได้โดยตรง . ตัวอย่างเช่น, [Blur](https://reference.aspose.com/slides/nodejs-java/aspose.slides/blur/) เปิดเผย `radius` และ `grow` ที่เขียนได้, [AlphaModulateFixed](https://reference.aspose.com/slides/nodejs-java/aspose.slides/alphamodulatefixed/) เปิดเผย `amount` ที่เขียนได้, และ [AlphaBiLevel](https://reference.aspose.com/slides/nodejs-java/aspose.slides/alphabilevel/) เปิดเผย `threshold` ที่เขียนได้ . เอฟเฟกต์สีเช่น [Duotone](https://reference.aspose.com/slides/nodejs-java/aspose.slides/duotone/) เปิดเผยอ็อบเจ็กต์ [ColorFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/colorformat/) ที่แก้ไขได้

บางอ็อบเจ็กต์ เช่น [BrightnessContrast](https://reference.aspose.com/slides/nodejs-java/aspose.slides/brightnesscontrast/), [HSL](https://reference.aspose.com/slides/nodejs-java/aspose.slides/hsl/), [Tint](https://reference.aspose.com/slides/nodejs-java/aspose.slides/tint/), และ [AlphaReplace](https://reference.aspose.com/slides/nodejs-java/aspose.slides/alphareplace/) ไม่เปิดเผยสเกลาร์การสร้างเป็นคุณสมบัติที่เขียนได้ . เพื่อเปลี่ยนการตั้งค่าเหล่านั้น, ให้ลบเอฟเฟกต์แล้วเพิ่มอ็อบเจ็กต์ทดแทนในตำแหน่งที่ต้องการ

ข้อมูลที่มีประสิทธิภาพที่ `getEffective()` คืนค่ามานั้นเป็นการคำนวณและอ่าน‑อย่าง‑เดียว . มันมีประโยชน์สำหรับการแก้ไขสีที่ขึ้นกับธีมและการอ่านค่าที่ทำให้มาตรฐานซึ่งตัวเรนเดอร์ใช้, แต่ไม่ใช่พื้นผิวการแก้ไขอีกชั้นหนึ่ง . ตัวอย่างต่อไปลิสต์เชนและตรวจสอบค่าที่มีประสิทธิภาพในที่ที่ API ให้ไว้:

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

เอฟเฟกต์ที่ไม่มีพารามิเตอร์เช่นระดับสีเทา, แอลฟ้า ceiling, และแอลฟ้า inverse ยังมีอ็อบเจ็กต์ข้อมูลที่มีประสิทธิภาพ, แต่ไม่มีการตั้งค่าสเกลาร์ให้พิมพ์ . การมีอยู่และตำแหน่งในคอลเลกชันคือข้อมูลสำคัญ

## **ลบหรือทำความสะอาดการแปลงภาพ**

ใช้ [ImageTransformOperationCollection.removeAt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/) เพื่อลบอ็อบเจ็กต์หนึ่งตามดัชนี . เนื่องจากดัชนีจะเปลี่ยนหลังจากการลบ, ควรค้นหาเป้าหมายก่อนแล้วลบหลังจากลิสต์ . ใช้ [ImageTransformOperationCollection.clear](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/) เพื่อลบเชนทั้งหมด

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

การลบหรือทำความสะอาดการแปลงเปลี่ยนเฉพาะการจัดรูปแบบของรูปภาพเท่านั้น . ไม่ได้ลบ, บีบอัด, หรือแก้ไขทรัพยากร [PPImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ppimage/) ที่ใช้ซ้ำ

## **พิจารณารูปแบบงานนำเสนอและเป้าหมายการส่งออก**

การแปลงภาพเกิดจาก DrawingML, ดังนั้น PPTX เป็นรูปแบบที่ควรแก้ไขสำหรับเชนเอฟเฟกต์ . แม้กับ PPTX, ไม่ใช่ทุกอ็อบเจ็กต์มีพกพาเท่ากัน:

- เอฟเฟกต์ DrawingML มาตรฐานเช่น luminance, grayscale, duotone, tint, HSL, blur, และเอฟเฟกต์แอลฟ่าทั่วไปมีโอกาสอยู่รอดจากรอบ PPTX มากที่สุด . ควรเปิดไฟล์ที่สร้างใหม่และตรวจสอบคอลเลกชันเมื่อการคงค่าเป็นข้อกำหนด
- [BrightnessContrast](https://reference.aspose.com/slides/nodejs-java/aspose.slides/brightnesscontrast/) เป็นส่วนขยาย Office 2010 ไม่ใช่เอฟเฟกต์ luminance ของ DrawingML มาตรฐาน . สามารถใช้สำหรับการเรนเดอร์ในหน่วยความจำ, แต่ไม่รับประกันว่าจะยังคงเป็นอ็อบเจ็กต์ [BrightnessContrast](https://reference.aspose.com/slides/nodejs-java/aspose.slides/brightnesscontrast/) ที่แก้ไขได้หลังบันทึกและเปิด PPTX ใหม่ . ให้เลือกใช้ [addLuminanceEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/) สำหรับการปรับความสว่างและคอนทราสต์ที่คงอยู่
- รูปแบบไบนารี PPT มีอายุย้อนไปก่อนโมเดลเอฟเฟกต์ DrawingML เต็มรูป . การบันทึกเป็น PPT อาจละเว้นอ็อบเจ็กต์ที่ไม่รองรับ, ลดเชนลงเป็นส่วนที่รองรับ, หรือประมาณลักษณะ . อย่าใช้ PPT เป็นรูปแบบตรวจสอบสำหรับเชนแก้ไขที่ซับซ้อน
- การเรนเดอร์เป็น PNG, JPEG, TIFF, PDF, SVG, HTML หรือรูปแบบภาพอื่น ๆ จะใช้เชนที่รองรับเพื่อสร้างภาพที่เรนเดอร์ . รูปแบบเหล่านี้ไม่บรรจุ [ImageTransformOperationCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/) ที่แก้ไขได้; รูปแบบราสเตอร์ทำให้ผลลัพธ์เป็นพิกเซล, การส่งออกเอกสาร/เวกเตอร์เก็บการแสดงผลของตนเอง
- เอฟเฟกต์ไม่ทำให้ภาพเชื่อมต่อเป็นอิสระ . การเรนเดอร์ภาพเชื่อมต่อยังคงต้องอ้างอิงทรัพยากรที่เชื่อมต่อเมื่อเปิดงานนำเสนอ

ผู้บริโภคงานนำเสนอที่ต่างกันอาจเรนเดอร์กรณีขอบต่าง ๆ แตกต่างกัน, โดยเฉพาะเมื่อรวมเอฟเฟกต์แอลฟ่าหรือการลดสีหลายออบเจ็กต์ . สำหรับผลลัพธ์สำคัญ, ควรทดสอบทั้งรอบการแก้ไขและรูปแบบส่งออกสุดท้ายด้วยเวอร์ชัน Aspose.Slides ที่ใช้ในระบบการผลิต

## **คำถามที่พบบ่อย**

**เอฟเฟกต์การแปลงภาพแก้ไขข้อมูลภาพฝังหรือไม่?**

ไม่ . การดำเนินการเป็นของ [Picture](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picture/) ที่ใช้โดยการเติมรูป . ไบต์ของ [PPImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ppimage/) ด้านล่างคงไม่เปลี่ยน

**สองกรอบรูปที่ใช้ภาพเดียวกันจะแบ่งเอฟเฟกต์กันหรือไม่?**

ไม่ . การใช้ซ้ำ [PPImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ppimage/) ช่วยหลีกเลี่ยงข้อมูลภาพซ้ำ, แต่แต่ละกรอบรูปโดยทั่วไปจะมี [Picture](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picture/) และคอลเลกชันการแปลงภาพของตนเอง

**สามารถผสมสี, เบลอ, และเอฟเฟกต์แอลฟ่าได้หรือไม่?**

ได้ . คอลเลกชันรับพวกมันในเชนที่เรียงลำดับ . พิจารณาว่าแต่ละการดำเนินการทำอะไรกับผลลัพธ์ของอ็อบเจ็กต์ก่อนหน้า, เนื่องจากเอฟเฟกต์แทนที่และเกณฑ์อาจลบรายละเอียดสีหรือแอลฟ่าที่เกิดขึ้นก่อนหน้า

**ทำไมค่าที่มีประสิทธิภาพจึงเป็นอ่าน‑อย่าง‑เดียว?**

ข้อมูลที่มีประสิทธิภาพเป็นค่าที่คำนวณสำหรับการเรนเดอร์, รวมถึงสีที่ได้จากธีม . แก้ไขอ็อบเจ็กต์ที่เก็บในคอลเลกชันที่มีสมาชิกเขียนได้; ถ้าไม่มี, ให้ลบและเพิ่มอ็อบเจ็กต์ทดแทนด้วยพารามิเตอร์การสร้างใหม่

**ควรใช้รูปแบบใดเพื่อคงเชนการแปลง?**

ใช้ PPTX และตรวจสอบไฟล์โดยเปิดใหม่ . PPT เดิมไม่สามารถแสดงโมเดลเอฟเฟกต์ DrawingML เต็มรูปได้, และรูปแบบส่งออกที่เรนเดอร์จะคงลักษณะภาพแต่ไม่คงการแปลงที่แก้ไขได้