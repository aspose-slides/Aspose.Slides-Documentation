---
title: จัดการเอฟเฟกต์การแปลงภาพในงานนำเสนอด้วย PHP
linktitle: เอฟเฟกต์การแปลงภาพ
type: docs
weight: 11
url: /th/php-java/image-transform-effects/
keywords:
- การแปลงภาพ
- เอฟเฟกต์รูปภาพ
- ความสว่าง
- คอนทราสต์
- ระดับสีเทา
- สีคู่
- สีสัน
- HSL
- การแทนที่สี
- เบลอ
- ความโปร่งแสง
- เอฟเฟกต์อัลฟ่า
- โซ่เอฟเฟกต์
- PowerPoint
- การนำเสนอ
- PHP
- Aspose.Slides
description: "ใช้, เชื่อมต่อ, ตรวจสอบ, ลบ, และยืนยันเอฟเฟกต์การแปลงภาพสำหรับเฟรมรูปภาพด้วย Aspose.Slides สำหรับ PHP ผ่าน Java."
---
## **ภาพรวม**

Aspose.Slides แสดงการปรับภาพเป็นคอลเลกชันแบบจัดลำดับของการดำเนินการแปลงรูปภาพ สำหรับเฟรมรูปภาพ ให้เริ่มต้นด้วย [Picture](https://reference.aspose.com/slides/php-java/aspose.slides/picture/) และเข้าถึง [Picture::getImageTransform](https://reference.aspose.com/slides/php-java/aspose.slides/picture/getimagetransform/). คอลเลกชัน [ImageTransformOperationCollection](https://reference.aspose.com/slides/php-java/aspose.slides/imagetransformoperationcollection/) ที่ส่งกลับให้คุณเพิ่ม, อ่านลำดับ, ตรวจสอบ, ลบ, และล้างเอฟเฟกต์โดยไม่ต้องเขียนใหม่ไบต์ของภาพต้นฉบับ

บทความนี้สาธิตเวิร์กโฟลว์สมบูรณ์สำหรับความสว่างและความคอนทราสต์, การแปลงสี, เบลอร์, ความโปร่งแสง, โซ่เอฟเฟกต์แบบจัดลำดับ, ค่าที่มีผล, การลบ, และการตรวจสอบรอบ PPTX

## **ทำความเข้าใจความเป็นเจ้าของเอฟเฟกต์และการใช้ซ้ำภาพ**

- [PPImage](https://reference.aspose.com/slides/php-java/aspose.slides/ppimage/) เก็บหรืออ้างอิงข้อมูลภาพต้นฉบับที่เป็นของการนำเสนอ
- [Picture](https://reference.aspose.com/slides/php-java/aspose.slides/picture/) เป็นส่วนของการเติมรูปภาพและอ้างอิงทรัพยากรภาพขณะเก็บคอลเลกชันการแปลงรูปภาพ
- [PictureFrame](https://reference.aspose.com/slides/php-java/aspose.slides/pictureframe/) คือรูปร่างบนสไลด์ที่เป็นเจ้าของการเติมรูปภาพที่เกี่ยวข้อง, รูปร่าง, การตั้งค่าการครอบ, และการฟอร์แมตระดับเฟรมอื่น ๆ

ดังนั้นการดำเนินการแปลงรูปภาพจะไม่แก้ไขไบต์ใน [PPImage](https://reference.aspose.com/slides/php-java/aspose.slides/ppimage/). เมื่อ `PPImage`เดียวกันถูกส่งไปยัง [ShapeCollection::addPictureFrame](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/addpictureframe/) มากกว่าหนึ่งครั้ง, แต่ละเฟรมรูปภาพใหม่จะได้รับ `Picture` ของตนเองและคอลเลกชันแปลงของตนเอง การนำเอฟเฟกต์ระดับสีเทาไปใช้กับเฟรมหนึ่งจะไม่ทำให้เฟรมอื่นเป็นระดับสีเทา แม้ว่าทั้งหมดจะใช้ทรัพยากรภาพฝังเดียวกัน

โมเดล `Picture::getImageTransform` เดียวกันนี้ยังใช้กับการเติมรูปภาพอื่น ๆ เช่น รูปร่างหรือพื้นหลังสไลด์ ตัวอย่างด้านล่างจึงมุ่งเน้นที่เฟรมรูปภาพ

## **ใช้ช่วงค่าพารามิเตอร์และหน่วยที่ถูกต้อง**

วิธีการที่แสดงใช้ช่วงค่าความหมายและหน่วยต่อไปนี้ เก็บค่าไว้ในช่วงเหล่านี้แม้เวอร์ชันไลบรารีบางรุ่นอาจไม่ปฏิเสธค่าที่อยู่นอกช่วงทันที; ฟอร์แมตการนำเสนอเป้าหมายอาจทำการทำให้เป็นค่าปกติ, ลบ, หรือปฏิเสธข้อมูลที่ไม่ถูกต้องระหว่างการบันทึกหรือเมื่อ PowerPoint เปิดไฟล์

| การดำเนินการ | พารามิเตอร์ | ช่วงและหน่วยที่ถูกต้อง |
|---|---|---|
| [addLuminanceEffect](https://reference.aspose.com/slides/php-java/aspose.slides/imagetransformoperationcollection/addluminanceeffect/) | `brightness`, `contrast` | `-100` ถึง `100` เป็นเปอร์เซ็นต์; `0` ไม่เปลี่ยนคอมโพเนนต์ |
| [addGrayScaleEffect](https://reference.aspose.com/slides/php-java/aspose.slides/imagetransformoperationcollection/addgrayscaleeffect/) | None | ไม่มีพารามิเตอร์เชิงตัวเลข. Alpha ไม่เปลี่ยนแปลง |
| [addDuotoneEffect](https://reference.aspose.com/slides/php-java/aspose.slides/imagetransformoperationcollection/addduotoneeffect/) | `color1`, `color2` | สองสีสำหรับพิกเซลสีเข้มและสีอ่อน. ช่องสี RGB และอัลฟ่าใน `java.awt.Color` ใช้ค่าจาก `0` ถึง `255` |
| [addTintEffect](https://reference.aspose.com/slides/php-java/aspose.slides/imagetransformoperationcollection/addtinteffect/) | `hue`, `amount` | Hue อยู่ที่ `0` รวมถึงถึง `360` ไม่รวม, หน่วยเป็นองศ; amount อยู่ที่ `-100` ถึง `100` เป็นเปอร์เซ็นต์ |
| [addHSLEffect](https://reference.aspose.com/slides/php-java/aspose.slides/imagetransformoperationcollection/addhsleffect/) | `hue`, `saturation`, `luminance` | Hue อยู่ที่ `0` ถึง `360` (ไม่รวม), หน่วยเป็นองศ; saturation และ luminance อยู่ที่ `-100` ถึง `100` เป็นเปอร์เซ็นต์ |
| [addColorReplaceEffect](https://reference.aspose.com/slides/php-java/aspose.slides/imagetransformoperationcollection/addcolorreplaceeffect/) | `color` | สีที่แทนที่ใช้ค่าชานัลจาก `0` ถึง `255`. ค่าที่อัลฟ่าเดิมไม่เปลี่ยนแปลง |
| [addBlurEffect](https://reference.aspose.com/slides/php-java/aspose.slides/imagetransformoperationcollection/addblureffect/) | `radius`, `grow` | Radius เป็นค่าที่ไม่เป็นลบและวัดเป็นจุด; `grow` เป็น Boolean ที่ควบคุมว่าขอบเนื้อหาที่เบลอร์อาจขยายออกนอกขอบเขตต้นฉบับหรือไม่ |
| [addAlphaModulateFixedEffect](https://reference.aspose.com/slides/php-java/aspose.slides/imagetransformoperationcollection/addalphamodulatefixedeffect/) | `amount` | เปอร์เซ็นต์ที่ไม่เป็นลบ. ใช้ `0` ถึง `100` สำหรับการปรับความทึบแบบปกติ: `0` คือโปร่งใสเต็มและ `100` รักษาอัลฟาที่มีอยู่ |
| [addAlphaReplaceEffect](https://reference.aspose.com/slides/php-java/aspose.slides/imagetransformoperationcollection/addalphareplaceeffect/) | `alpha` | `0` ถึง `100` เป็นเปอร์เซ็นต์ความทึบ |
| [addAlphaBiLevelEffect](https://reference.aspose.com/slides/php-java/aspose.slides/imagetransformoperationcollection/addalphabileveleffect/) | `threshold` | `0` ถึง `100` เป็นเปอร์เซ็นต์เกณฑ์อัลฟ่า. ค่าต่ำกว่ากลายเป็นโปร่งใส; ค่าสูงกว่าหรือเท่ากลายเป็นทึบ |

สำหรับการปรับอัลฟ่าแบบคงที่ ความโปร่งแสงและความทึบเป็นค่าตรงกันข้าม ตัวอย่างเช่น ความโปร่งแสง 35% มีค่าอัลฟ่าโมดูเลต 65%

## **ใช้ความสว่างและความคอนทราสต์**

[ImageTransformOperationCollection::addLuminanceEffect](https://reference.aspose.com/slides/php-java/aspose.slides/imagetransformoperationcollection/addluminanceeffect/) คืนค่าออบเจ็กต์ [Luminance](https://reference.aspose.com/slides/php-java/aspose.slides/luminance/) การตั้งค่าสเกลาร์จะถูกส่งเมื่อสร้างออบเจ็กต์ [Luminance::getEffective](https://reference.aspose.com/slides/php-java/aspose.slides/luminance/geteffective/) คืนค่าที่คำนวณได้แบบอ่านอย่างเดียวที่สามารถตรวจสอบหรือบันทึกได้

ตัวอย่างต่อไปนี้เพิ่มความสว่าง 15% และความคอนทราสต์ 20% แล้วแสดงตัวอย่างโดยไม่แก้ไขภาพฝัง:

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

`Luminance` เป็นเอฟเฟกต์ความสว่างและความคอนทราสต์มาตรฐานของ DrawingML เมื่อต้องการให้การตั้งค่าเหล่านี้ยังแก้ไขได้หลังจากรอบ PPTX ให้เปิดไฟล์การนำเสนอที่บันทึกไว้ใหม่และตรวจสอบทั้งประเภทการดำเนินการและค่าที่มีผล

## **ใช้การแปลงสี**

เอฟเฟกต์สีสามารถนำไปใช้แยกกันกับเฟรมรูปภาพต่าง ๆ ที่ใช้ทรัพยากรภาพเดียวกัน ตัวอย่างต่อไปนี้สร้างห้าเฟรมและใช้ระดับสีเทา, ดูโทนสีคู่, สีสัน, การปรับ HSL, และการแทนที่สี

[Duotone](https://reference.aspose.com/slides/php-java/aspose.slides/duotone/) มีพารามิเตอร์สีที่แก้ไขได้สองค่า: `color1` แทนพิกเซลสีเข้ม, `color2` แทนพิกเซลสีอ่อน ซึ่งทำให้เป็นตัวอย่างที่มีการตั้งค่าซับซ้อนกว่าค่าสเกลาร์เดียว

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

[addColorReplaceEffect](https://reference.aspose.com/slides/php-java/aspose.slides/imagetransformoperationcollection/addcolorreplaceeffect/) แทนที่สีของพิกเซลทุกพิกเซลด้วยสีคงที่หนึ่งสีโดยคงค่าอัลฟ่าไว้ ต่างจาก [addColorChangeEffect](https://reference.aspose.com/slides/php-java/aspose.slides/imagetransformoperationcollection/addcolorchangeeffect/) ที่แมปสีต้นฉบับหนึ่งไปยังสีเป้าหมายและเปิดเผยรูปแบบสีต้นฉบับและเป้าหมาย

### **ใช้เกณฑ์ความสว่าง**

เกณฑ์ความสว่างสามารถทำให้เครื่องหมายอ่อนบนหน้าสแกนง่ายต่อการแยกจากพื้นหลังได้ [addGrayScaleEffect](https://reference.aspose.com/slides/php-java/aspose.slides/imagetransformoperationcollection/addgrayscaleeffect/) คงเฉดสีเทากลาง [addBiLevelEffect](https://reference.aspose.com/slides/php-java/aspose.slides/imagetransformoperationcollection/addbileveleffect/) แมพความสว่างเป็นสีดำหรือสีขาว, ขณะที่ [addAlphaBiLevelEffect](https://reference.aspose.com/slides/php-java/aspose.slides/imagetransformoperationcollection/addalphabileveleffect/) ใช้เกณฑ์กับอัลฟ่า

เกณฑ์ความสว่างอยู่ในช่วง 0% ถึง 100% รวม. พิกเซลที่ต่ำกว่าเกณฑ์จะเป็นสีดำ. พิกเซลที่เท่ากับหรือสูงกว่าเกณฑ์จะเป็นสีขาว. การยกเกณฑ์ขึ้นจะทำให้เฉดสีหลาย ๆ เฉดกลายเป็นสีดำมากขึ้นเนื่องจากอยู่ต่ำกว่าเกณฑ์

ดาวน์โหลด [grayscale-swatches.png](grayscale-swatches.png) ไปยังไดเรกทอรีที่มีสคริปต์ PHP แต่ละป้ายกำกับแสดงระดับสีเทาต้นฉบับบนสเกลจาก 0 ถึง 255 ตัวอย่างจะวางต้นฉบับข้างสำเนาสองฉบับและบันทึกเกณฑ์ของแต่ละสำเนาในงานนำเสนอ

```php
use aspose\slides\Images;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\SlideSizeScaleType;

$presentation = new Presentation();
try {
    $presentation->getSlideSize()->setSize(720, 150, SlideSizeScaleType::DoNotScale);
    $shapes = $presentation->getSlides()->get_Item(0)->getShapes();

    $sourceImage = Images::fromFile(__DIR__ . "/grayscale-swatches.png");
    try {
        $image = $presentation->getImages()->addImage($sourceImage);
    } finally {
        $sourceImage->dispose();
    }

    $captions = ["Original", "Threshold 20%", "Threshold 60%"];
    $frames = [];
    foreach ($captions as $index => $caption) {
        $x = 12 + 240 * $index;
        $label = $shapes->addAutoShape(ShapeType::Rectangle, $x, 12, 216, 36);
        $label->getTextFrame()->setText($caption);
        $frames[] = $shapes->addPictureFrame(ShapeType::Rectangle, $x, 60, 216, 72, $image);
    }

    $frames[1]->getPictureFormat()->getPicture()->getImageTransform()->addBiLevelEffect(20);
    $frames[2]->getPictureFormat()->getPicture()->getImageTransform()->addBiLevelEffect(60);

    $presentation->save(__DIR__ . "/luminance-threshold.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

เปิดงานนำเสนอที่ได้จากการเรนเดอร์ใน PowerPoint เพื่อตรวจสอบสามเฟรม สวิทซ์ที่มีป้ายกำกับ 96 มีความสว่างประมาณ 38% (96 จาก 255) จะกลายเป็นสีขาวที่เกณฑ์ 20% และสีดำที่เกณฑ์ 60%

![สีสลับระดับสีเทาต้นฉบับด้านข้างผลลัพธ์สีขาว-ดำที่เกณฑ์ความสว่าง 20% และ 60%](luminance-threshold.png)

## **เพิ่มเอฟเฟกต์เบลอร์, ความโปร่งแสง, และอัลฟ่า**

[addBlurEffect](https://reference.aspose.com/slides/php-java/aspose.slides/imagetransformoperationcollection/addblureffect/) ส่งผลต่อทุกช่องสีรวมอัลฟ่า ตั้งค่า `grow` เป็น `true` เมื่อขอบเบลอร์อาจขยายออกนอกขอบเขตภาพต้นฉบับ

สำหรับความโปร่งแสงแบบสม่ำเสมอ ให้ใช้ [addAlphaModulateFixedEffect](https://reference.aspose.com/slides/php-java/aspose.slides/imagetransformoperationcollection/addalphamodulatefixedeffect/). มันคูณค่าอัลฟ่าเดิมทุกค่าดังนั้นพิกเซลที่บางส่วนโปร่งแสงจะยังคงต่างกันตามสัดส่วน [addAlphaReplaceEffect](https://reference.aspose.com/slides/php-java/aspose.slides/imagetransformoperationcollection/addalphareplaceeffect/) จะกำหนดค่าอัลฟ่าเดียวให้กับพิกเซลทั้งหมด [addAlphaBiLevelEffect](https://reference.aspose.com/slides/php-java/aspose.slides/imagetransformoperationcollection/addalphabileveleffect/) แปลงอัลฟ่าเป็นสองระดับตามเกณฑ์

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

เอฟเฟกต์อัลฟ่าไม่มีพารามิเตอร์อื่น ๆ รวมถึง [addAlphaCeilingEffect](https://reference.aspose.com/slides/php-java/aspose.slides/imagetransformoperationcollection/addalphaceilingeffect/) ที่ทำให้ทุกอัลฟ่าไม่เป็นศูนย์เป็นทึบเต็ม; [addAlphaFloorEffect](https://reference.aspose.com/slides/php-java/aspose.slides/imagetransformoperationcollection/addalphaflooreffect/) ที่ทำให้ทุกอัลฟ่าใต 100% เป็นโปร่งใสเต็ม; และ [addAlphaInverseEffect](https://reference.aspose.com/slides/php-java/aspose.slides/imagetransformoperationcollection/addalphainverseeffect/) ที่เปลี่ยนอัลฟ่าเป็น `100% - alpha`

## **สร้างโซ่เอฟเฟกต์แบบจัดลำดับ**

แต่ละเมธอด `add...Effect` เพิ่มการดำเนินการใหม่ต่อท้ายคอลเลกชัน ตัวเรนเดอร์ใช้คอลเลกชันเป็นสายการประมวลผลที่จัดลำดับ: ผลลัพธ์ของการดำเนินการ 0 จะเป็นอินพุตของการดำเนินการ 1, และต่อไป ดังนั้นการดำเนินการเดียวกันในลำดับที่ต่างกันอาจให้ภาพที่ต่างกัน

เช่น การทำสีเทาตามด้วยสีสันจะลบข้อมูลสีก่อนแล้วทำสีใหม่บนผลลัพธ์ความสว่าง ส่วนการทำสีสันตามด้วยสีเทาจะลบสีสันออกอีกครั้ง อย่างเดียวกัน การแทนที่อัลฟ่าอาจเขียนทับค่าอัลฟ่าโดยการดำเนินการก่อนหน้า ในขณะที่การโมดูเลตอัลฟ่ารักษาความแตกต่างสัมพัทธ์ของพวกมัน

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

คอลเลกชันไม่ได้บังคับแผนภูมิความเข้ากันได้ที่จำกัดสี, อัลฟ่า, และเอฟเฟกต์เบลอร์ให้อยู่ในโซ่แยก พวกมันสามารถรวมกันได้แต่ไม่ใช่ทุกการรวมจะมีประโยชน์ การแทนที่สีคงที่ลบความแปรผัน RGB ที่เกิดจากเอฟเฟกต์สีก่อนหน้า; การทำสีเทาหลังดูโทนสีคู่จะลบสองสีที่เลือก; และการทำอัลฟ่า ceiling, floor, replace หรือ bi-level อาจทิ้งรายละเอียดอัลฟ่า ที่สร้างขึ้นก่อนหน้า สร้างโซ่ตามลำดับการประมวลผลพิกเซลที่ต้องการ แทนการมองเป็นแฟลกการฟอร์แมตที่ไม่มีลำดับ

<!-- visual-explanation:image-transform-effects:start -->
[![The same image passes through grayscale then tint, and tint then grayscale. The two final grayscale images have different tones.](visual-image-transform-effects-49aa72211f3a.svg)](visual-image-transform-effects-49aa72211f3a.svg)

*ในตัวอย่างการเรนเดอร์ Aspose.Slides for .NET 26.11 นี้, สีสันที่ 220° ที่ 25% ไม่ทำให้ภาพสีเทาเปลี่ยนแปลง. การใช้สีสันเดียวกันก่อนสีเทาให้โทนสีที่แตกต่างกัน.*
<!-- visual-explanation:image-transform-effects:end -->

## **ตรวจสอบค่าที่แก้ไขได้และค่าที่มีผล**

การดำเนินการที่แก้ไขได้คือออบเจ็กต์ที่เก็บไว้ใน `Picture::getImageTransform`. ขึ้นอยู่กับเอฟเฟกต์, มันอาจเปิดเผยสมาชิกที่เขียนได้โดยตรง ตัวอย่างเช่น [Blur](https://reference.aspose.com/slides/php-java/aspose.slides/blur/) เปิดเผยค่า `radius` และ `grow` ที่เขียนได้, [AlphaModulateFixed](https://reference.aspose.com/slides/php-java/aspose.slides/alphamodulatefixed/) เปิดเผย `amount` ที่เขียนได้, และ [AlphaBiLevel](https://reference.aspose.com/slides/php-java/aspose.slides/alphabilevel/) เปิดเผย `threshold` ที่เขียนได้ เอฟเฟกต์สีเช่น [Duotone](https://reference.aspose.com/slides/php-java/aspose.slides/duotone/) เปิดเผยอ็อบเจ็กต์ [ColorFormat](https://reference.aspose.com/slides/php-java/aspose.slides/colorformat/) ที่แก้ไขได้

บางการดำเนินการ เช่น [Luminance](https://reference.aspose.com/slides/php-java/aspose.slides/luminance/), [HSL](https://reference.aspose.com/slides/php-java/aspose.slides/hsl/), [Tint](https://reference.aspose.com/slides/php-java/aspose.slides/tint/), และ [AlphaReplace](https://reference.aspose.com/slides/php-java/aspose.slides/alphareplace/) ไม่เปิดเผยสเกลาร์การสร้างเป็นคุณสมบัติที่เขียนได้ เพื่อเปลี่ยนการตั้งค่าเหล่านั้น ให้ลบการดำเนินการและเพิ่มการแทนที่ในตำแหน่งที่ต้องการ

ข้อมูลที่มีผลที่ `getEffective()` คืนมาถูกคำนวณและเป็นแบบอ่านอย่างเดียว มันเป็นประโยชน์สำหรับการแก้สีที่ขึ้นกับธีมและการอ่านค่าที่ทำให้เป็นมาตรฐานที่ตัวเรนเดอร์ใช้ แต่ไม่ได้เป็นพื้นผิวการแก้ไขเพิ่มเติม ตัวอย่างต่อไปนี้อ่านลำดับโซ่และตรวจสอบค่าที่มีผลที่ API ให้มา:

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

เอฟเฟกต์ไม่มีพารามิเตอร์เช่นระดับสีเทา, อัลฟ่า ceiling, และอัลฟ่า inverse ยังมีอ็อบเจ็กต์ข้อมูลที่มีผล แต่ไม่มีการตั้งค่าสเกลาร์ให้พิมพ์ การปรากฏและตำแหน่งของพวกมันในคอลเลกชันคือข้อมูลสำคัญ

## **ลบหรือเคลียร์การแปลงรูปภาพ**

ใช้ [ImageTransformOperationCollection::removeAt](https://reference.aspose.com/slides/php-java/aspose.slides/imagetransformoperationcollection/removeat/) เพื่อลบการดำเนินการหนึ่งตามดัชนี เนื่องจากดัชนีสับเปลี่ยนหลังการลบ, ควรค้นหาเป้าหมายก่อนและลบหลังจากอ่านลำดับ ใช้ [ImageTransformOperationCollection::clear](https://reference.aspose.com/slides/php-java/aspose.slides/imagetransformoperationcollection/clear/) เพื่อลบโซ่ทั้งหมด

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

การลบหรือเคลียร์การแปลงจะเปลี่ยนเฉพาะการฟอร์แมตรูปภาพเท่านั้น ไม่ได้ลบ, ทำการบีบอัดใหม่, หรือแก้ไขทรัพยากร [PPImage](https://reference.aspose.com/slides/php-java/aspose.slides/ppimage/) ที่ใช้ซ้ำ

## **พิจารณาฟอร์แมตการนำเสนอและเป้าหมายการส่งออก**

การแปลงรูปภาพเริ่มต้นจาก DrawingML ดังนั้น PPTX เป็นฟอร์แมตแก้ไขที่แนะนำสำหรับโซ่เอฟเฟกต์ แม้กับ PPTX ไม่ใช่ทุกการดำเนินการจะพกพาได้อย่างเท่าเทียม:

- การดำเนินการ DrawingML มาตรฐานเช่น luminance, grayscale, duotone, tint, HSL, blur, และเอฟเฟกต์อัลฟ่าโดยทั่วไปมีโอกาสอยู่รอดสูงสุดหลังรอบ PPTX. ควรเปิดไฟล์ที่สร้างขึ้นใหม่และตรวจสอบคอลเลกชันเมื่อการคงรักษาเป็นความต้องการ
- ฟอร์แมต PPT ไบนารีมีอายุย้อนไปก่อนโมเดลเอฟเฟกต์ DrawingML เต็มรูปแบบ การบันทึกเป็น PPT อาจละเว้นการดำเนินการที่ไม่รองรับ, ลดโซ่ลงเป็นส่วนย่อยที่รองรับ, หรือประมาณผลลัพธ์ อย่าใช้ PPT เพื่อตรวจสอบโซ่แก้ไขที่ซับซ้อน
- การเรนเดอร์เป็น PNG, JPEG, TIFF, PDF, SVG, HTML หรือเอาต์พุตภาพอื่น ๆ จะใช้โซ่ที่รองรับต่อการแสดงผล ผลลัพธ์เหล่านี้ไม่มี `ImageTransformOperationCollection` ที่แก้ไขได้; ฟอร์แมตเรสเตอร์จะทำให้ผลลัพธ์เป็นพิกเซล, และการส่งออกเอกสารหรือเวกเตอร์จะเก็บการแสดงผลของตนเอง
- เอฟเฟกต์ไม่ทำให้ภาพที่ลิงก์เป็นไฟล์เดียว การเรนเดอร์ภาพที่ลิงก์ยังคงต้องพึ่งพาทรัพยากรที่ลิงก์อยู่เมื่อโหลดการนำเสนอ

ผู้บริโภคการนำเสนอที่ต่างกันอาจเรนเดอร์กรณีขอบโค้งต่างกัน โดยเฉพาะเมื่อรวมหลายการดำเนินการอัลฟ่า หรือการควอนไทซ์สี เพื่อตรวจสอบผลลัพธ์สำคัญ ควรทดสอบทั้งรอบการแก้ไขและฟอร์แมตการส่งออกสุดท้ายด้วย Aspose.Slides เวอร์ชันเดียวกับที่ใช้ในการผลิต

## **คำถามที่พบบ่อย**

**Do image transform effects modify the embedded image data?**

No. The operations belong to the `Picture` used by the picture fill. The underlying `PPImage` bytes remain unchanged.

**Will two picture frames that reuse the same image share their effects?**

No. Reusing a `PPImage` avoids duplicate image data, but each picture frame normally has a separate `Picture` and image transform collection.

**Can color, blur, and alpha effects be combined?**

Yes. The collection accepts them in one ordered chain. Consider what each operation does to the output of the previous one because replacement and threshold operations may discard earlier color or alpha detail.

**Why are effective values read-only?**

Effective data represents calculated values used for rendering, including resolved colors. Edit the operation stored in the transform collection where writable members exist; otherwise remove it and add a replacement with new creation parameters.

**Which format should I use to preserve a transform chain?**

Use PPTX and verify the file by reopening it. Legacy PPT cannot represent the full DrawingML effect model, and rendered export formats preserve appearance rather than editable transform operations.