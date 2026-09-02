---
title: จัดการเอฟเฟกต์การแปลงภาพในการนำเสนอด้วย PHP
linktitle: เอฟเฟกต์การแปลงภาพ
type: docs
weight: 11
url: /th/php-java/image-transform-effects/
keywords:
- การแปลงภาพ
- เอฟเฟกต์รูปภาพ
- ความสว่าง
- ความคอนทราสต์
- สีเทา
- โทนคู่
- โทนสี
- HSL
- การแทนที่สี
- เบลอ
- ความโปร่งใส
- เอฟเฟกต์อัลฟา
- โซ่เอฟเฟกต์
- PowerPoint
- งานนำเสนอ
- PHP
- Aspose.Slides
description: "ใช้, สร้างโซ่, ตรวจสอบ, ลบ, และยืนยันเอฟเฟกต์การแปลงภาพสำหรับเฟรมรูปภาพด้วย Aspose.Slides สำหรับ PHP ผ่าน Java."
---
## **ภาพรวม**

Aspose.Slides แสดงการปรับรูปภาพเป็นคอลเลกชันที่เรียงลำดับของการดำเนินการแปลงภาพ สำหรับเฟรมรูปภาพ ให้เริ่มต้นที่ [Picture](https://reference.aspose.com/slides/th/php-java/aspose.slides/picture/) ของเฟรม แล้วเข้าถึง [Picture::getImageTransform](https://reference.aspose.com/slides/th/php-java/aspose.slides/picture/getimagetransform/). [ImageTransformOperationCollection](https://reference.aspose.com/slides/th/php-java/aspose.slides/imagetransformoperationcollection/) ที่คืนค่ามาให้คุณสามารถเพิ่ม, เรียกดู, ตรวจสอบ, ลบ และล้างเอฟเฟ็กต์ได้โดยไม่ต้องเขียนทับไบต์ของภาพต้นฉบับ

บทความนี้สาธิตเวิร์กฟลว์ครบวงจรสำหรับการปรับความสว่างและคอนทราสต์, การแปลงสี, เบลอ, ความโปร่งใส, โซ่เอฟเฟ็กต์เรียงลำดับ, ค่าที่มีประสิทธิภาพ, การลบ, และการตรวจสอบการรอบ PPTX

## **ทำความเข้าใจการเป็นเจ้าของเอฟเฟ็กต์และการใช้ซ้ำของภาพ**

ทรัพยากรภาพและรูปภาพที่แสดงภาพนั้นเป็นวัตถุที่แตกต่างกัน:

- [PPImage](https://reference.aspose.com/slides/th/php-java/aspose.slides/ppimage/) เก็บหรืออ้างอิงข้อมูลภาพต้นฉบับที่เป็นของงานนำเสนอ
- [Picture](https://reference.aspose.com/slides/th/php-java/aspose.slides/picture/) เป็นส่วนของการใส่รูปภาพและอ้างอิงทรัพยากรภาพขณะเก็บคอลเลกชันการแปลงภาพ
- [PictureFrame](https://reference.aspose.com/slides/th/php-java/aspose.slides/pictureframe/) คือรูปร่างบนสไลด์ที่เป็นเจ้าของการใส่รูปภาพ, รูปร่างเรขาคณิต, การตั้งค่าการครอป, และการจัดรูปแบบระดับเฟรมอื่น ๆ

ดังนั้นการดำเนินการแปลงภาพจะไม่แก้ไขไบต์ใน [PPImage](https://reference.aspose.com/slides/th/php-java/aspose.slides/ppimage/). เมื่อ `PPImage` ตัวเดียวกันถูกส่งไปยัง [ShapeCollection::addPictureFrame](https://reference.aspose.com/slides/th/php-java/aspose.slides/shapecollection/addpictureframe/) มากกว่าหนึ่งครั้ง แต่ละเฟรมรูปภาพใหม่จะได้รับ `Picture` ของตัวเองและคอลเลกชันการแปลงของตัวเอง การทำให้ภาพเป็นสีเทาในเฟรมหนึ่งจะไม่ทำให้เฟรมอื่นเป็นสีเทา แม้ว่าทั้งหมดจะใช้ทรัพยากรภาพแบบฝังเดียวกัน

โมเดล `Picture::getImageTransform` เดียวกันนี้ยังถูกใช้โดยการใส่รูปแบบอื่น ๆ เช่น รูปร่างหรือพื้นหลังสไลด์ ตัวอย่างด้านล่างมุ่งเน้นที่เฟรมรูปภาพ

## **ใช้ช่วงพารามิเตอร์และหน่วยที่ถูกต้อง**

วิธีการที่สาธิตใช้ช่วงความหมายและหน่วยต่อไปนี้   โปรดรักษาค่าที่อยู่ในช่วงเหล่านี้แม้ว่ารุ่นของไลบรารีบางรุ่นอาจไม่ปฏิเสธค่าที่อยู่นอกช่วงทันที; รูปแบบการนำเสนอเป้าหมายอาจทำให้ค่าปกติ, ลบทิ้ง, หรือปฏิเสธข้อมูลที่ไม่ถูกต้องระหว่างการบันทึกหรือเมื่อ PowerPoint เปิดไฟล์

| การดำเนินการ | พารามิเตอร์ | ช่วงและหน่วยที่ถูกต้อง |
|---|---|---|
| [addLuminanceEffect](https://reference.aspose.com/slides/th/php-java/aspose.slides/imagetransformoperationcollection/addluminanceeffect/) | `brightness`, `contrast` | `-100` ถึง `100` , เป็นเปอร์เซ็นต์; `0` ไม่เปลี่ยนคอมโพเนนต์ |
| [addGrayScaleEffect](https://reference.aspose.com/slides/th/php-java/aspose.slides/imagetransformoperationcollection/addgrayscaleeffect/) | ไม่มี | ไม่มีพารามิเตอร์ตัวเลข; Alpha ไม่เปลี่ยน |
| [addDuotoneEffect](https://reference.aspose.com/slides/th/php-java/aspose.slides/imagetransformoperationcollection/addduotoneeffect/) | `color1`, `color2` | สองสีสำหรับพิกเซลมืดและสว่าง. ช่องสี RGB และ alpha ใน `java.awt.Color` ใช้ค่า `0` ถึง `255` |
| [addTintEffect](https://reference.aspose.com/slides/th/php-java/aspose.slides/imagetransformoperationcollection/addtinteffect/) | `hue`, `amount` | Hue อยู่ระหว่าง `0` (รวม) ถึง `360` (ไม่รวม) หน่วยเป็นองศา; amount อยู่ระหว่าง `-100` ถึง `100` , เป็นเปอร์เซ็นต์ |
| [addHSLEffect](https://reference.aspose.com/slides/th/php-java/aspose.slides/imagetransformoperationcollection/addhsleffect/) | `hue`, `saturation`, `luminance` | Hue อยู่ระหว่าง `0` (รวม) ถึง `360` (ไม่รวม) หน่วยเป็นองศา; saturation และ luminance อยู่ระหว่าง `-100` ถึง `100` , เป็นเปอร์เซ็นต์ |
| [addColorReplaceEffect](https://reference.aspose.com/slides/th/php-java/aspose.slides/imagetransformoperationcollection/addcolorreplaceeffect/) | `color` | สีที่ใช้แทนใช้ค่าช่อง `0` ถึง `255`; ค่า alpha เดิมไม่เปลี่ยน |
| [addBlurEffect](https://reference.aspose.com/slides/th/php-java/aspose.slides/imagetransformoperationcollection/addblureffect/) | `radius`, `grow` | radius ต้องเป็นค่าที่ไม่เป็นลบและวัดเป็น points; `grow` เป็น Boolean ที่กำหนดว่าผลลัพธ์ที่เบลออาจขยายออกนอกขอบเดิมหรือไม่ |
| [addAlphaModulateFixedEffect](https://reference.aspose.com/slides/th/php-java/aspose.slides/imagetransformoperationcollection/addalphamodulatefixedeffect/) | `amount` | เปอร์เซ็นต์ที่ไม่เป็นลบ ใช้ `0` ถึง `100` สำหรับการปรับความทึบแบบทั่วไป: `0` หมายถึงโปร่งใสเต็มที่และ `100` รักษา alpha ปัจจุบัน |
| [addAlphaReplaceEffect](https://reference.aspose.com/slides/th/php-java/aspose.slides/imagetransformoperationcollection/addalphareplaceeffect/) | `alpha` | `0` ถึง `100` , เปอร์เซ็นต์ความทึบ |
| [addAlphaBiLevelEffect](https://reference.aspose.com/slides/th/php-java/aspose.slides/imagetransformoperationcollection/addalphabileveleffect/) | `threshold` | `0` ถึง `100` , เปอร์เซ็นต์ค่าเกณฑ์ alpha; ค่าน้อยกว่าเป็นโปร่งใส; ค่าสูงกว่าหรือเท่ากับเป็นทึบ |

สำหรับการมอดูเลต alpha ที่คงที่ ความโปร่งใสและความทึบเป็นค่าตรงกัน ตัวอย่างเช่น ความโปร่งใส 35% ตรงกับค่าโมดูเลท alpha 65%

## **ปรับความสว่างและคอนทราสต์**

[ImageTransformOperationCollection::addLuminanceEffect](https://reference.aspose.com/slides/th/php-java/aspose.slides/imagetransformoperationcollection/addluminanceeffect/) คืนค่าออบเจ็กต์ [Luminance](https://reference.aspose.com/slides/th/php-java/aspose.slides/luminance/) การตั้งค่าสเกลาร์จะถูกระบุเมื่อสร้างออบเจ็กต์  [Luminance::getEffective](https://reference.aspose.com/slides/th/php-java/aspose.slides/luminance/geteffective/) คืนค่าที่คำนวณแล้วแบบอ่านได้ซึ่งสามารถตรวจสอบหรือบันทึกได้

ตัวอย่างต่อไปนี้เพิ่มความสว่าง 15% และคอนทราสต์ 20% แล้วแสดงตัวอย่างโดยไม่แก้ไขภาพฝัง:

```php
use aspose\slides\ImageFormat;
use aspose\slides\Images;
use aspose\slides\Presentation;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $sourceImage = Images::fromFile("photo.png");
    try {
        $image = $presentation->getImages()->addImage($sourceImage);
    } finally {
        if (!java_is_null($sourceImage)) {
            $sourceImage->dispose();
        }
    }

    $pictureFrame = $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 50, 50, 400, 260, $image);
    $imageTransform = $pictureFrame->getPictureFormat()->getPicture()->getImageTransform();
    $luminance = $imageTransform->addLuminanceEffect(15, 20);

    $effectiveValues = $luminance->getEffective();
    echo "Brightness: " . java_values($effectiveValues->getBrightness()) . "%" . PHP_EOL;
    echo "Contrast: " . java_values($effectiveValues->getContrast()) . "%" . PHP_EOL;

    $preview = $slide->getImage();
    try {
        $preview->save("brightness-contrast-preview.png", ImageFormat::Png);
    } finally {
        if (!java_is_null($preview)) {
            $preview->dispose();
        }
    }
} finally {
    $presentation->dispose();
}
```

`Luminance` เป็นเอฟเฟกต์ความสว่างและคอนทราสต์มาตรฐานของ DrawingML เมื่อการตั้งค่าเหล่านั้นต้องการให้แก้ไขได้หลังการรอบ PPTX ให้เปิดไฟล์ที่บันทึกใหม่และตรวจสอบทั้งประเภทการดำเนินการและค่าที่มีประสิทธิภาพ

## **แปลงสี**

เอฟเฟกต์สีสามารถนำไปใช้แยกกันบนเฟรมรูปภาพต่าง ๆ ที่ใช้ทรัพยากรภาพเดียวกัน ตัวอย่างต่อไปนี้สร้างห้าเฟรมและใช้สีเทา, ดูโทน, โทนสี, การปรับ HSL, และการแทนที่สี

[Duotone](https://reference.aspose.com/slides/th/php-java/aspose.slides/duotone/) มีพารามิเตอร์สีสองตัวที่แก้ไขได้แยกจากกัน: `color1` ใช้สำหรับพิกเซลมืด, `color2` ใช้สำหรับพิกเซลสว่าง ซึ่งทำให้เป็นตัวอย่างที่ดีของเอฟเฟกต์ที่การตั้งค่าซับซ้อนกว่าค่าสเกลาร์เดียว

```php
use aspose\slides\Images;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $sourceImage = Images::fromFile("photo.png");
    try {
        $image = $presentation->getImages()->addImage($sourceImage);
    } finally {
        if (!java_is_null($sourceImage)) {
            $sourceImage->dispose();
        }
    }

    $grayFrame = $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 20, 20, 180, 120, $image);
    $grayFrame->getPictureFormat()->getPicture()->getImageTransform()->addGrayScaleEffect();

    $duotoneFrame = $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 220, 20, 180, 120, $image);
    $duotone = $duotoneFrame->getPictureFormat()->getPicture()->getImageTransform()->addDuotoneEffect();
    $duotone->getColor1()->setColor(new Java("java.awt.Color", 0, 0, 128));
    $duotone->getColor2()->setColor(new Java("java.awt.Color", 255, 215, 0));

    $tintFrame = $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 420, 20, 180, 120, $image);
    $tintFrame->getPictureFormat()->getPicture()->getImageTransform()->addTintEffect(210, 35);

    $hslFrame = $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 120, 170, 180, 120, $image);
    $hslFrame->getPictureFormat()->getPicture()->getImageTransform()->addHSLEffect(30, 20, -10);

    $replacementFrame = $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 320, 170, 180, 120, $image);
    $colorReplacement = $replacementFrame->getPictureFormat()->getPicture()->getImageTransform()->addColorReplaceEffect();
    $colorReplacement->getColor()->setColor(new Java("java.awt.Color", 100, 149, 237));

    $presentation->save("color-transformations.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

[addColorReplaceEffect](https://reference.aspose.com/slides/th/php-java/aspose.slides/imagetransformoperationcollection/addcolorreplaceeffect/) แทนที่สีของทุกพิกเซลด้วยสีคงที่หนึ่งสีโดยคงค่า alpha ไว้ แตกต่างจาก [addColorChangeEffect](https://reference.aspose.com/slides/th/php-java/aspose.slides/imagetransformoperationcollection/addcolorchangeeffect/) ที่แม็พสีต้นทางหนึ่งไปยังสีเป้าหมายและเปิดเผยรูปแบบสีต้นทางและเป้าหมายทั้งสอง

## **เพิ่มเบลอ, ความโปร่งใส, และเอฟเฟกต์ Alpha**

[addBlurEffect](https://reference.aspose.com/slides/th/php-java/aspose.slides/imagetransformoperationcollection/addblureffect/) มีผลต่อทุกช่องสีรวมถึง alpha ตั้งค่า `grow` เป็น `true` เมื่อขอบที่เบลออาจขยายออกนอกขอบภาพเดิม

สำหรับความโปร่งใสสม่ำเสมอ ใช้ [addAlphaModulateFixedEffect](https://reference.aspose.com/slides/th/php-java/aspose.slides/imagetransformoperationcollection/addalphamodulatefixedeffect/) มันคูณค่า alpha ที่มีอยู่ทุกค่า ดังนั้นพิกเซลที่เป็นบางส่วนโปร่งใสจะยังคงแตกต่างตามสัดส่วน [addAlphaReplaceEffect](https://reference.aspose.com/slides/th/php-java/aspose.slides/imagetransformoperationcollection/addalphareplaceeffect/) จะกำหนดค่า alpha หนึ่งค่าให้ทุกพิกเซล [addAlphaBiLevelEffect](https://reference.aspose.com/slides/th/php-java/aspose.slides/imagetransformoperationcollection/addalphabileveleffect/) จะเปลี่ยน alpha เป็นสองระดับตามค่าเกณฑ์

```php
use aspose\slides\Images;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $sourceImage = Images::fromFile("photo.png");
    try {
        $image = $presentation->getImages()->addImage($sourceImage);
    } finally {
        if (!java_is_null($sourceImage)) {
            $sourceImage->dispose();
        }
    }

    $blurredFrame = $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 20, 20, 200, 140, $image);
    $blur = $blurredFrame->getPictureFormat()->getPicture()->getImageTransform()->addBlurEffect(4.5, true);
    $blur->setRadius(5);

    $transparentFrame = $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 240, 20, 200, 140, $image);
    $alphaModulate = $transparentFrame->getPictureFormat()->getPicture()->getImageTransform()->addAlphaModulateFixedEffect(65);
    $alphaModulate->setAmount(60);

    $uniformAlphaFrame = $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 20, 180, 200, 140, $image);
    $uniformAlphaFrame->getPictureFormat()->getPicture()->getImageTransform()->addAlphaReplaceEffect(55);

    $binaryAlphaFrame = $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 240, 180, 200, 140, $image);
    $alphaBiLevel = $binaryAlphaFrame->getPictureFormat()->getPicture()->getImageTransform()->addAlphaBiLevelEffect(50);
    $alphaBiLevel->setThreshold(45);
    $binaryAlphaFrame->getPictureFormat()->getPicture()->getImageTransform()->addAlphaInverseEffect();

    $presentation->save("blur-and-alpha-effects.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

เอฟเฟกต์ alpha ที่ไม่มีพารามิเตอร์อื่น ๆ ได้แก่ [addAlphaCeilingEffect](https://reference.aspose.com/slides/th/php-java/aspose.slides/imagetransformoperationcollection/addalphaceilingeffect/) ซึ่งทำให้ทุกค่า alpha ที่ไม่เป็นศูนย์กลายเป็นทึบเต็ม, [addAlphaFloorEffect](https://reference.aspose.com/slides/th/php-java/aspose.slides/imagetransformoperationcollection/addalphaflooreffect/) ทำให้ทุกค่า alpha ต่ำกว่า 100% กลายเป็นโปร่งใสเต็ม, และ [addAlphaInverseEffect](https://reference.aspose.com/slides/th/php-java/aspose.slides/imagetransformoperationcollection/addalphainverseeffect/) เปลี่ยนค่า alpha เป็น `100% - alpha`

## **สร้างโซ่เอฟเฟกต์เรียงลำดับ**

ทุกเมธอด `add...Effect` จะเพิ่มการดำเนินการใหม่เข้าไปที่ส่วนท้ายของคอลเลกชัน ตัวเรนเดอร์ใช้คอลเลกชันเป็นสายการประมวลผลที่เรียงลำดับ: ผลลัพธ์ของการดำเนินการ 0 เป็นอินพุตของการดำเนินการ 1 และต่อไป ดังนั้นการเรียงลำดับที่แตกต่างอาจทำให้ได้ภาพที่แตกต่างกัน

เช่น สีเทาตามด้วยโทนสีจะลบข้อมูลสีก่อนแล้วจึงทำให้สีสว่างใหม่อีกครั้ง; โทนสีตามด้วยสีเทาจะลบโทนสีอีกครั้งเช่นกัน เช่นเดียวกับการแทนที่ alpha ที่สามารถทับค่าที่คำนวนโดยการดำเนินการก่อนหน้า, ในขณะที่การมอดูเลต alpha จะคงความแตกต่างสัมพัทธ์ไว้

ตัวอย่างต่อไปนี้สร้างโซ่สี่การดำเนินการ, บันทึกเป็น PPTX, เปิดงานนำเสนอใหม่, ตรวจสอบทั้งประเภทการดำเนินการและลำดับ, แล้วเรนเดอร์ผลลัพธ์ที่เปิดใหม่:

```php
use aspose\slides\ImageFormat;
use aspose\slides\Images;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $sourceImage = Images::fromFile("photo.png");
    try {
        $image = $presentation->getImages()->addImage($sourceImage);
    } finally {
        if (!java_is_null($sourceImage)) {
            $sourceImage->dispose();
        }
    }

    $pictureFrame = $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 50, 50, 400, 260, $image);
    $imageTransform = $pictureFrame->getPictureFormat()->getPicture()->getImageTransform();
    $imageTransform->addGrayScaleEffect();
    $imageTransform->addTintEffect(220, 25);
    $imageTransform->addBlurEffect(2.5, false);
    $imageTransform->addAlphaModulateFixedEffect(80);

    $presentation->save("image-transform-chain.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}

$reopenedPresentation = new Presentation("image-transform-chain.pptx");
try {
    $reopenedShape = $reopenedPresentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);

    if (java_instanceof($reopenedShape, new JavaClass("com.aspose.slides.PictureFrame"))) {
        $reopenedTransform = $reopenedShape->getPictureFormat()->getPicture()->getImageTransform();
        $orderIsPreserved = java_values($reopenedTransform->size()) === 4 && 
            java_instanceof($reopenedTransform->get_Item(0), new JavaClass("com.aspose.slides.GrayScale")) && 
            java_instanceof($reopenedTransform->get_Item(1), new JavaClass("com.aspose.slides.Tint")) && 
            java_instanceof($reopenedTransform->get_Item(2), new JavaClass("com.aspose.slides.Blur")) && 
            java_instanceof($reopenedTransform->get_Item(3), new JavaClass("com.aspose.slides.AlphaModulateFixed"));
        echo $orderIsPreserved ? "The effect chain was preserved." : "The effect chain changed during the round trip.";

        $renderedSlide = $reopenedPresentation->getSlides()->get_Item(0)->getImage();
        try {
            $renderedSlide->save("reopened-effect-chain.png", ImageFormat::Png);
        } finally {
            if (!java_is_null($renderedSlide)) {
                $renderedSlide->dispose();
            }
        }
    } else {
        echo "The reopened shape is not a picture frame.";
    }
} finally {
    $reopenedPresentation->dispose();
}
```

คอลเลกชันไม่ได้กำหนดเมทริกซ์ความเข้ากันได้ที่จำกัดเอฟเฟกต์สี, alpha, และเบลอให้อยู่ในโซ่แยกกัน สามารถรวมกันได้แต่บางการรวมอาจไม่เป็นประโยชน์ การแทนที่สีคงที่จะลบความแปรผัน RGB ที่เกิดจากเอฟเฟกต์สีก่อนหน้า; สีเทาหลังดูโทนสีจะลบสองสีที่เลือก; และการมอดูเลต, เพดาน, ลบ, หรือเอฟเฟกต์สองระดับของ alpha สามารถกวาดลบรายละเอียด alpha ที่สร้างขึ้นก่อนหน้า สร้างโซ่ตามลำดับการประมวลผลพิกเซลที่ต้องการ แทนที่จะมองรายการเป็นธงฟอร์แมตที่ไม่มีลำดับ

## **ตรวจสอบค่าที่แก้ไขได้และค่าที่มีประสิทธิภาพ**

การดำเนินการที่แก้ไขได้คือตัวออบเจกต์ที่เก็บใน `Picture::getImageTransform` ขึ้นอยู่กับเอฟเฟกต์อาจเปิดเผยสมาชิกที่เขียนได้โดยตรง ตัวอย่างเช่น [Blur](https://reference.aspose.com/slides/th/php-java/aspose.slides/blur/) เปิดเผย `radius` และ `grow` ที่เขียนได้, [AlphaModulateFixed](https://reference.aspose.com/slides/th/php-java/aspose.slides/alphamodulatefixed/) เปิดเผย `amount` ที่เขียนได้, และ [AlphaBiLevel](https://reference.aspose.com/slides/th/php-java/aspose.slides/alphabilevel/) เปิดเผย `threshold` ที่เขียนได้  เอฟเฟกต์สีเช่น [Duotone](https://reference.aspose.com/slides/th/php-java/aspose.slides/duotone/) เปิดเผยออบเจกต์ [ColorFormat](https://reference.aspose.com/slides/th/php-java/aspose.slides/colorformat/) ที่แก้ไขได้

บางการดำเนินการรวมถึง [Luminance](https://reference.aspose.com/slides/th/php-java/aspose.slides/luminance/), [HSL](https://reference.aspose.com/slides/th/php-java/aspose.slides/hsl/), [Tint](https://reference.aspose.com/slides/th/php-java/aspose.slides/tint/), และ [AlphaReplace](https://reference.aspose.com/slides/th/php-java/aspose.slides/alphareplace/) ไม่เปิดเผยสเกลาร์การสร้างเป็นคุณสมบัติที่เขียนได้ เพื่อเปลี่ยนการตั้งค่าเหล่านั้น ให้ลบการดำเนินการแล้วเพิ่มออบเจกต์ใหม่ในตำแหน่งที่ต้องการ

ข้อมูลที่มีประสิทธิภาพที่คืนค่าจาก `getEffective()` ถูกคำนวนและอ่านได้อย่างเดียว มีประโยชน์สำหรับการแก้สีที่ขึ้นกับธีมและการอ่านค่าที่ทำให้เป็นมาตรฐานที่เรนเดอร์ใช้ แต่ไม่ใช่พื้นผิวการแก้ไขเพิ่มเติม ตัวอย่างต่อไปนี้เรียกดูโซ่และตรวจสอบค่าที่มีประสิทธิภาพเมื่อ API ที่เกี่ยวข้องให้ข้อมูล:

```php
use aspose\slides\Presentation;

$presentation = new Presentation("image-transform-chain.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $pictureFrame = null;
    $shapeCount = java_values($slide->getShapes()->size());

    for ($index = 0; $index < $shapeCount; $index++) {
        $shape = $slide->getShapes()->get_Item($index);
        if (java_instanceof($shape, new JavaClass("com.aspose.slides.PictureFrame"))) {
            $pictureFrame = $shape;
            break;
        }
    }

    if ($pictureFrame !== null) {
        $imageTransform = $pictureFrame->getPictureFormat()->getPicture()->getImageTransform();
        $effectCount = java_values($imageTransform->size());

        for ($index = 0; $index < $effectCount; $index++) {
            $operation = $imageTransform->get_Item($index);
            echo $index . ": " . java_values($operation->getClass()->getSimpleName()) . PHP_EOL;

            if (java_instanceof($operation, new JavaClass("com.aspose.slides.Luminance"))) {
                $data = $operation->getEffective();
                echo "  Brightness: " . java_values($data->getBrightness()) . PHP_EOL;
                echo "  Contrast: " . java_values($data->getContrast()) . PHP_EOL;
            } elseif (java_instanceof($operation, new JavaClass("com.aspose.slides.Duotone"))) {
                $data = $operation->getEffective();
                echo "  Dark color: " . java_values($data->getColor1()->toString()) . PHP_EOL;
                echo "  Light color: " . java_values($data->getColor2()->toString()) . PHP_EOL;
            } elseif (java_instanceof($operation, new JavaClass("com.aspose.slides.ColorReplace"))) {
                $data = $operation->getEffective();
                echo "  Replacement color: " . java_values($data->getColor()->toString()) . PHP_EOL;
            } elseif (java_instanceof($operation, new JavaClass("com.aspose.slides.HSL"))) {
                $data = $operation->getEffective();
                echo "  HSL: " . java_values($data->getHue()) . ", " . java_values($data->getSaturation()) . ", " . java_values($data->getLuminance()) . PHP_EOL;
            } elseif (java_instanceof($operation, new JavaClass("com.aspose.slides.Tint"))) {
                $data = $operation->getEffective();
                echo "  Tint: " . java_values($data->getHue()) . ", " . java_values($data->getAmount()) . PHP_EOL;
            } elseif (java_instanceof($operation, new JavaClass("com.aspose.slides.Blur"))) {
                $data = $operation->getEffective();
                echo "  Blur radius: " . java_values($data->getRadius()) . " pt" . PHP_EOL;
            } elseif (java_instanceof($operation, new JavaClass("com.aspose.slides.AlphaModulateFixed"))) {
                $data = $operation->getEffective();
                echo "  Alpha amount: " . java_values($data->getAmount()) . "%" . PHP_EOL;
            } elseif (java_instanceof($operation, new JavaClass("com.aspose.slides.AlphaReplace"))) {
                $data = $operation->getEffective();
                echo "  Replacement alpha: " . java_values($data->getAlpha()) . "%" . PHP_EOL;
            } elseif (java_instanceof($operation, new JavaClass("com.aspose.slides.AlphaBiLevel"))) {
                $data = $operation->getEffective();
                echo "  Alpha threshold: " . java_values($data->getThreshold()) . "%" . PHP_EOL;
            }
        }
    }
} finally {
    $presentation->dispose();
}
```

เอฟเฟกต์ที่ไม่มีพารามิเตอร์เช่นสีเทา, เพดาน alpha, และอินเวอร์ส alpha ยังคงมีออบเจกต์ข้อมูลที่มีประสิทธิภาพอยู่ แต่ไม่มีการตั้งค่าสเกลาร์ให้พิมพ์ การมีอยู่และตำแหน่งในคอลเลกชันเป็นข้อมูลสำคัญ

## **ลบหรือเคลียร์การแปลงภาพ**

ใช้ [ImageTransformOperationCollection::removeAt](https://reference.aspose.com/slides/th/php-java/aspose.slides/imagetransformoperationcollection/removeat/) เพื่อลบการดำเนินการหนึ่งตามดัชนี เนื่องจากดัชนีจะเปลี่ยนหลังการลบ ให้ค้นหาตัวเป้าหมายก่อนแล้วจึงลบหลังจากเรียกดู ใช้ [ImageTransformOperationCollection::clear](https://reference.aspose.com/slides/th/php-java/aspose.slides/imagetransformoperationcollection/clear/) เพื่อลบโซ่ทั้งหมด

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("image-transform-chain.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $pictureFrame = null;
    $shapeCount = java_values($slide->getShapes()->size());

    for ($index = 0; $index < $shapeCount; $index++) {
        $shape = $slide->getShapes()->get_Item($index);
        if (java_instanceof($shape, new JavaClass("com.aspose.slides.PictureFrame"))) {
            $pictureFrame = $shape;
            break;
        }
    }

    if ($pictureFrame !== null) {
        $imageTransform = $pictureFrame->getPictureFormat()->getPicture()->getImageTransform();
        $effectCount = java_values($imageTransform->size());
        $blurIndex = -1;

        for ($index = 0; $index < $effectCount; $index++) {
            if (java_instanceof($imageTransform->get_Item($index), new JavaClass("com.aspose.slides.Blur"))) {
                $blurIndex = $index;
                break;
            }
        }

        if ($blurIndex >= 0) {
            $imageTransform->removeAt($blurIndex);
            echo "The blur operation was removed." . PHP_EOL;
        }

        $imageTransform->clear();
        echo "Remaining operations: " . java_values($imageTransform->size()) . PHP_EOL;
        $presentation->save("image-transforms-cleared.pptx", SaveFormat::Pptx);
    }
} finally {
    $presentation->dispose();
}
```

การลบหรือเคลียร์การแปลงจะเปลี่ยนเฉพาะรูปแบบรูปภาพ ไม่ได้ลบ, บีบอัดใหม่, หรือเปลี่ยนแปลงทรัพยากร [PPImage](https://reference.aspose.com/slides/th/php-java/aspose.slides/ppimage/) ที่ใช้ซ้ำ

## **พิจารณารูปแบบการนำเสนอและเป้าหมายการส่งออก**

การแปลงภาพมีต้นกำเนิดใน DrawingML ดังนั้น PPTX เป็นรูปแบบที่แก้ไขได้ที่แนะนำสำหรับโซ่เอฟเฟกต์ แม้ใน PPTX ก็ไม่ได้ทุกการดำเนินการมีพกพาเดียวกัน:

- การดำเนินการ DrawingML มาตรฐานเช่น luminance, grayscale, duotone, tint, HSL, blur, และเอฟเฟกต์ alpha ทั่วไป มีโอกาสสูงสุดที่จะรอดผ่านรอบ PPTX  ให้เปิดไฟล์ที่สร้างใหม่และตรวจสอบคอลเลกชันเมื่อต้องการการคงสภาพ
- รูปแบบไบนารี PPT มีอายุเก่ากว่ารุ่นเต็มของโมเดลเอฟเฟกต์ DrawingML การบันทึกเป็น PPT อาจละเว้นการดำเนินการที่ไม่รองรับ, ลดโซ่ลงเป็นส่วนย่อยที่รองรับ, หรือประมาณลักษณะ อย่าใช้ PPT เป็นรูปแบบตรวจสอบสำหรับโซ่แก้ไขที่ซับซ้อน
- การเรนเดอร์เป็น PNG, JPEG, TIFF, PDF, SVG, HTML หรือรูปแบบภาพอื่น ๆ จะใช้โซ่ที่สนับสนุนในการสร้างภาพผลลัพธ์ รูปแบบเหล่านี้ไม่ประกอบด้วย `ImageTransformOperationCollection` ที่แก้ไขได้; รูปแบบเรสเตอร์จะทำให้ผลลัพธ์แบนเป็นพิกเซล, และการส่งออกเอกสารหรือเวกเตอร์จะเก็บตัวแทนการเรนเดอร์ของตนเอง
- เอฟเฟกต์ไม่ได้ทำให้ภาพที่เชื่อมโยงเป็นอิสระ การเรนเดอร์รูปภาพที่เชื่อมโยงยังคงพึ่งพาทรัพยากรที่เชื่อมโยงต้องพร้อมใช้งานเมื่อโหลดงานนำเสนอ

ผู้บริโภคงานนำเสนอที่ต่างกันอาจเรนเดอร์กรณีขอบต่างกันโดยเฉพาะเมื่อมีการรวมหลายเอฟเฟกต์ alpha หรือการควอนตาไซส์สี เพื่อผลลัพธ์ที่สำคัญ ควรทดสอบทั้งรอบการแก้ไขและรูปแบบส่งออกขั้นสุดท้ายด้วย Aspose.Slides รุ่นเดียวกับที่ใช้ในการผลิต

## **คำถามที่พบบ่อย**

**เอฟเฟกต์การแปลงภาพทำให้ข้อมูลภาพฝังเปลี่ยนแปลงหรือไม่?**

ไม่ การดำเนินการเป็นของ `Picture` ที่ใช้โดยการใส่รูปภาพ ไบต์ของ `PPImage` ที่อยู่พื้นฐานไม่ถูกแก้ไข

**สองเฟรมรูปภาพที่ใช้ภาพเดียวกันจะแชร์เอฟเฟกต์กันหรือไม่?**

ไม่ การใช้ `PPImage` ซ้ำช่วยหลีกเลี่ยงข้อมูลภาพซ้ำ, แต่แต่ละเฟรมรูปภาพโดยทั่วไปจะมี `Picture` และคอลเลกชันการแปลงภาพของตนเอง

**สามารถรวมเอฟเฟกต์สี, เบลอ, และ alpha ได้หรือไม่?**

ได้ คอลเลกชันรับเอฟเฟกต์เหล่านี้ในโซ่เรียงลำดับหนึ่ง ให้พิจารณาว่าแต่ละการดำเนินการทำอะไรกับผลลัพธ์ของการดำเนินการก่อนหน้า เนื่องจากเอฟเฟกต์การแทนที่และเกณฑ์อาจลบรายละเอียดสีหรือ alpha ที่เกิดก่อนหน้า

**ทำไมค่าที่มีประสิทธิภาพจึงเป็นอ่านอย่างเดียว?**

ข้อมูลที่มีประสิทธิภาพเป็นค่าที่คำนวนแล้วใช้สำหรับการเรนเดอร์ รวมถึงสีที่แก้ไขตามธีม ให้แก้ไขการดำเนินการที่เก็บในคอลเลกชันเมื่อมีสมาชิกที่เขียนได้; มิฉะนั้นให้ลบและเพิ่มออบเจกต์ใหม่พร้อมพารามิเตอร์การสร้างใหม่

**ควรใช้รูปแบบใดเพื่อคงโซ่การแปลง?**

ใช้ PPTX และตรวจสอบไฟล์โดยเปิดใหม่อีกครั้ง PPT รุ่นเก่าไม่สามารถแสดงโมเดลเอฟเฟกต์ DrawingML ทั้งหมดได้, และรูปแบบส่งออกที่เรนเดอร์จะเก็บเพียงลักษณะที่แสดงผล ไม่ใช่การดำเนินการแปลงที่แก้ไขได้