---
title: จัดการกรอบรูปในงานนำเสนอด้วย PHP
linktitle: กรอบรูป
type: docs
weight: 10
url: /th/php-java/picture-frame/
keywords:
- กรอบรูป
- เพิ่มกรอบรูป
- สร้างกรอบรูป
- ภาพที่ฝังเอาไว้
- ภาพที่เชื่อมโยง
- สกัดภาพ
- ภาพเรสเตอร์
- ภาพ SVG
- ตัดภาพ
- ลบพื้นที่ที่ตัดออก
- บีบอัดภาพ
- StretchOffset
- การจัดรูปแบบกรอบรูป
- สเกลสัมพัทธ์
- เอฟเฟกต์ภาพ
- อัตราส่วนภาพ
- PowerPoint
- OpenDocument
- งานนำเสนอ
- PHP
- Aspose.Slides
description: "สร้าง, จัดรูปแบบ, เชื่อมโยง, ตัด, สกัด, และบีบอัดกรอบรูปในงานนำเสนอด้วย Aspose.Slides สำหรับ PHP ผ่าน Java."
---
## **ภาพรวม**

กรอบรูปเป็นรูปร่างสไลด์ที่แสดงภาพ ใน Aspose.Slides แหล่งข้อมูลภาพและรูปร่างที่แสดงภาพเป็นอ็อบเจกต์แยกกัน: [Presentation](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentation/) ถือครองทรัพยากรภาพที่ฝังอยู่ผ่าน [ImageCollection](https://reference.aspose.com/slides/th/php-java/aspose.slides/imagecollection/) ของมัน ในขณะที่ [PictureFrame](https://reference.aspose.com/slides/th/php-java/aspose.slides/pictureframe/) ควบคุมตำแหน่งของภาพ, ขนาด, การจัดรูปแบบเส้น, การหมุน, การตัด, เอฟเฟกต์รูปภาพ, และการตั้งค่าอื่น ๆ ระดับกรอบ

การแยกนี้มีประโยชน์เมื่อภาพเดียวกันถูกแสดงหลายครั้ง เพิ่มภาพลงในงานนำเสนอครั้งเดียว, เก็บ [PPImage](https://reference.aspose.com/slides/th/php-java/aspose.slides/ppimage/) ที่คืนค่า, แล้วใช้ทรัพยากรภาพนั้นเมื่อสร้างกรอบรูป

กรอบรูปสามารถบรรจุภาพเรสเตอร์เช่น PNG หรือ JPEG และภาพเวกเตอร์ SVG ได้ นอกจากนี้ยังสามารถอ้างอิงถึงภาพที่เชื่อมโยงแทนการเก็บไบต์ของภาพไว้ในงานนำเสนอ ตัวเลือกนี้ส่งผลต่อความพกพา, ขนาดไฟล์, การสกัด, และพฤติกรรมการส่งออก ดังนั้นจึงควรตัดสินใจว่าภาพควรเก็บอย่างไรก่อนทำการจัดรูปแบบหรือการเพิ่มประสิทธิภาพ

## **เพิ่มและจัดรูปแบบภาพที่ฝังเอาไว้**

สำหรับภาพที่ฝังเอาไว้ ให้เพิ่มข้อมูลภาพลงในงานนำเสนอและสร้างกรอบรูปด้วย [ShapeCollection::addPictureFrame](https://reference.aspose.com/slides/th/php-java/aspose.slides/shapecollection/addpictureframe/) ภาพจะกลายเป็นส่วนหนึ่งของแพ็กเกจงานนำเสนอ ดังนั้นงานนำเสนอจะยังคงเป็นแบบอิสระเมื่อนำไปย้ายไปยังคอมพิวเตอร์เครื่องอื่น

ตัวอย่างต่อไปนี้เพิ่มภาพ JPEG, สร้างกรอบที่มีขนาดตามมิติพื้นฐานของภาพ, และใช้การจัดรูปแบบเส้นและการหมุน:

```php
use aspose\slides\FillType;
use aspose\slides\Images;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $sourceImage = Images::fromFile("photo.jpg");
    try {
        $image = $presentation->getImages()->addImage($sourceImage);
    } finally {
        if (!java_is_null($sourceImage)) {
            $sourceImage->dispose();
        }
    }

    $pictureFrame = $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 50, 100, $image->getWidth(), $image->getHeight(), $image);
    $pictureFrame->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $pictureFrame->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    $pictureFrame->getLineFormat()->setWidth(3);
    $pictureFrame->setRotation(15);

    $presentation->save("picture-frame.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

กรอบรูปควบคุมเรขาคณิตที่แสดง; การเปลี่ยนขนาดกรอบจะไม่เปลี่ยนมิติพิกเซลต้นฉบับที่เก็บในทรัพยากรภาพที่ฝังเอาไว้ ความแตกต่างนี้สำคัญเมื่อทำการตัดหรือบีบอัดภาพในภายหลัง

## **ใช้สเกลสัมพัทธ์**

[PictureFrame](https://reference.aspose.com/slides/th/php-java/aspose.slides/pictureframe/) เปิดเผยการสเกลความกว้างและความสูงสัมพัทธ์สำหรับกรอบผ่าน [setRelativeScaleWidth](https://reference.aspose.com/slides/th/php-java/aspose.slides/pictureframe/setrelativescalewidth/) และ [setRelativeScaleHeight](https://reference.aspose.com/slides/th/php-java/aspose.slides/pictureframe/setrelativescaleheight/) ค่า `1.0` หมายถึง 100% ของขนาดรูปภาพต้นฉบับ สเกลสัมพัทธ์มีประโยชน์เมื่อเวิร์กโฟลว์ต้องรักษาความสัมพันธ์กับขนาดภาพต้นฉบับแทนการคำนวณขนาดสุดท้ายด้วยตนเอง

```php
use aspose\slides\Images;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $sourceImage = Images::fromFile("photo.jpg");
    try {
        $image = $presentation->getImages()->addImage($sourceImage);
    } finally {
        if (!java_is_null($sourceImage)) {
            $sourceImage->dispose();
        }
    }

    $pictureFrame = $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 50, 50, 100, 100, $image);
    $pictureFrame->setRelativeScaleWidth(1.35);
    $pictureFrame->setRelativeScaleHeight(0.8);

    $presentation->save("relative-scale.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

สเกลสัมพัทธ์เปลี่ยนการตั้งค่าขนาดกรอบ; มันไม่ได้ทำการรีแซมพล หรือบีบอัดภาพที่ฝังเอาไว้

## **ภาพที่ฝังและภาพที่เชื่อมโยง**

ภาพที่ฝังเอาไว้เก็บข้อมูลภาพภายในงานนำเสนอและจึงเป็นทางเลือกที่ปลอดภัยที่สุดสำหรับความพกพาและการเรนเดอร์ที่คาดเดาได้ ภาพที่เชื่อมโยงเก็บตำแหน่งภายนอกผ่านเมธอด [Picture::setLinkPathLong](https://reference.aspose.com/slides/th/php-java/aspose.slides/picture/setlinkpathlong/) แทนการฝังข้อมูลภาพในลักษณะเดียวกัน

ภาพที่เชื่อมโยงสามารถลดปริมาณข้อมูลภาพที่เก็บใน PPTX ได้ แต่ก็ทำให้เกิดการพึ่งพาไฟล์ภายนอก ไฟล์ที่เชื่อมโยงต้องสามารถเข้าถึงได้โดยแอปพลิเคชันที่เปิดหรือเรนเดอร์งานนำเสนอ หากเส้นทางเปลี่ยน, ไฟล์ถูกย้าย, หรือทรัพยากรไม่พร้อมใช้ ภาพที่เชื่อมโยงอาจไม่แสดงตามที่คาดหวัง สำหรับงานนำเสนอที่ต้องส่งอีเมล, จัดเก็บ, หรือเรนเดอร์ในสภาพแวดล้อมแยก, ภาพที่ฝังเอาไว้มักจะเชื่อถือได้มากกว่า

### **เพิ่มภาพที่เชื่อมโยง**

ตัวอย่างต่อไปนี้สร้างกรอบรูปและชี้ไปยังไฟล์ภาพภายในเครื่อง มุ่งเน้นที่การเชื่อมโยงภาพเท่านั้น; การเชื่อมโยงวิดีโอเป็นเวิร์กโฟลว์สื่อแยกต่างหากและไม่ได้รวมไว้ในตัวอย่างนี้

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $pictureFrame = $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 50, 50, 320, 180, null);
    $linkedImageFile = new Java("java.io.File", "linked-image.jpg");
    $pictureFrame->getPictureFormat()->getPicture()->setLinkPathLong($linkedImageFile->getAbsolutePath());

    $presentation->save("linked-image.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

ใช้ลิงก์เมื่อการจัดการไฟล์ภายนอกเป็นเจตนา อย่าใช้เป็นการแทนที่การบีบอัด: PPTX เล็กที่มีการพึ่งพาภาพเสียหายมักจะใช้งานได้น้อยกว่าเมื่อเทียบกับงานนำเสนอที่มีขนาดใหญ่และเป็นอิสระ

## **สกัดภาพจากกรอบรูป**

ก่อนสกัดภาพจากงานนำเสนอที่มีอยู่, ตรวจสอบว่ารูปร่างเป็น [PictureFrame](https://reference.aspose.com/slides/th/php-java/aspose.slides/pictureframe/) จริงและว่ามีภาพที่ฝังเอาไว้ ภาพที่เชื่อมโยงอาจไม่มีไบต์ของภาพที่สามารถสกัดได้ในแบบเดียวกัน

### **สกัดภาพเรสเตอร์**

API ภาพสมัยใหม่ใช้ [IImage](https://reference.aspose.com/slides/th/php-java/aspose.slides/iimage/) โดยตรง ตัวอย่างต่อไปนี้ค้นหาภาพเรสเตอร์ที่ฝังแรกบนสไลด์และบันทึกเป็น PNG:

```php
use aspose\slides\ImageFormat;
use aspose\slides\Presentation;

$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shapeCount = java_values($slide->getShapes()->size());

    for ($index = 0; $index < $shapeCount; $index++) {
        $shape = $slide->getShapes()->get_Item($index);
        if (!java_instanceof($shape, new JavaClass("com.aspose.slides.PictureFrame"))) {
            continue;
        }

        $embeddedImage = $shape->getPictureFormat()->getPicture()->getImage();
        if (java_is_null($embeddedImage) || !java_is_null($embeddedImage->getSvgImage())) {
            continue;
        }

        $rasterImage = $embeddedImage->getImage();
        try {
            $rasterImage->save("extracted-image.png", ImageFormat::Png);
        } finally {
            if (!java_is_null($rasterImage)) {
                $rasterImage->dispose();
            }
        }
        break;
    }
} finally {
    $presentation->dispose();
}
```

การบันทึกผ่าน [IImage::save](https://reference.aspose.com/slides/th/php-java/aspose.slides/iimage/#save) จะเปลี่ยนภาพที่สกัดเป็นรูปแบบเอาต์พุตที่ร้องขอ หากต้องการไบต์ที่เข้ารหัสที่เก็บในงานนำเสนอแทนไฟล์เรสเตอร์ที่แปลงแล้ว ให้ใช้ข้อมูลไบนารีของทรัพยากรภาพแทน

### **สกัดภาพ SVG**

สำหรับภาพ SVG, [PPImage](https://reference.aspose.com/slides/th/php-java/aspose.slides/ppimage/) เปิดเผยอ็อบเจกต์ [SvgImage](https://reference.aspose.com/slides/th/php-java/aspose.slides/svgimage/) ซึ่งทำให้คุณดึงข้อมูล SVG โดยตรง แทนการเรสเตอร์ไอคอนภาพก่อน

```php
use aspose\slides\Presentation;

$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shapeCount = java_values($slide->getShapes()->size());

    for ($index = 0; $index < $shapeCount; $index++) {
        $shape = $slide->getShapes()->get_Item($index);
        if (!java_instanceof($shape, new JavaClass("com.aspose.slides.PictureFrame"))) {
            continue;
        }

        $embeddedImage = $shape->getPictureFormat()->getPicture()->getImage();
        $svgImage = java_is_null($embeddedImage) ? null : $embeddedImage->getSvgImage();
        if ($svgImage === null || java_is_null($svgImage)) {
            continue;
        }

        $outputStream = new Java("java.io.FileOutputStream", "extracted-image.svg");
        try {
            $outputStream->write($svgImage->getSvgData());
        } finally {
            $outputStream->close();
        }
        break;
    }
} finally {
    $presentation->dispose();
}
```

การเก็บเนื้อหา SVG เป็น SVG จะรักษาแหล่งเวกเตอร์ภายในงานนำเสนอไว้ การส่งออกเป็นเรสเตอร์เช่น PNG หรือ JPEG จำเป็นต้องเรนเดอร์เนื้อหาเวกเตอร์เป็นพิกเซล การส่งออกสไลด์เป็น PDF หรือ SVG ก็เป็นการเรนเดอร์เช่นกัน ดังนั้นกราฟิกที่ส่งออกไม่ควรถือเป็นสำเนาแบบไบต์ต่อไบต์ของ SVG ที่ฝังไว้; ใช้ข้อมูลจาก [SvgImage::getSvgData](https://reference.aspose.com/slides/th/php-java/aspose.slides/svgimage/getsvgdata/) เมื่อจำเป็นต้องใช้แหล่งเวกเตอร์เดิม

## **ตัดภาพ**

การตัดเปลี่ยนส่วนของภาพที่มองเห็นได้ในกรอบ ค่าการตัดบน [PictureFillFormat](https://reference.aspose.com/slides/th/php-java/aspose.slides/picturefillformat/) เป็นเปอร์เซ็นต์ของมิติภาพต้นฉบับ การตัดไม่ได้ลบพิกเซลที่ซ่อนจากภาพที่ฝังเอาไว้ทันที; มันเพียงเปลี่ยนพื้นที่ที่มองเห็น

ตัวอย่างต่อไปนี้ค้นหากรอบรูปอย่างปลอดภัยและใช้ค่าเพื่อตัด:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("sample.pptx");
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
        $pictureFrame->getPictureFormat()->setCropLeft(23.6);
        $pictureFrame->getPictureFormat()->setCropRight(21.5);
        $pictureFrame->getPictureFormat()->setCropTop(3);
        $pictureFrame->getPictureFormat()->setCropBottom(31);
        $presentation->save("cropped-image.pptx", SaveFormat::Pptx);
    }
} finally {
    $presentation->dispose();
}
```

เนื่องจากข้อมูลภาพที่ซ่อนยังคงอยู่ การตัดสามารถเปลี่ยนแปลงได้ในภายหลังโดยไม่สูญเสียพิกเซลต้นฉบับ หากขนาดไฟล์เป็นสิ่งสำคัญกว่าการย้อนกลับ มีวิธีการลบพื้นที่ที่ตัดออกตามที่อธิบายในส่วนต่อไป

## **ลบข้อมูลภาพที่ตัดออก**

[PictureFillFormat::deletePictureCroppedAreas](https://reference.aspose.com/slides/th/php-java/aspose.slides/picturefillformat/#deletePictureCroppedAreas) จะลบข้อมูลภาพที่อยู่นอกสี่เหลี่ยมตัดปัจจุบันและคืนทรัพยากรภาพที่ได้ผลลัพธ์ วิธีนี้สามารถลดขนาดไฟล์ได้ แต่เป็นการเพิ่มประสิทธิภาพทำลาย: หลังจากบันทึกงานนำเสนอ พิกเซลที่ลบจะไม่สามารถกู้คืนเพื่อการยกเลิกการตัดได้อีก

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("cropped-image.pptx");
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
        $croppedImage = $pictureFrame->getPictureFormat()->deletePictureCroppedAreas();
        if (!java_is_null($croppedImage)) {
            $presentation->save("cropped-data-removed.pptx", SaveFormat::Pptx);
        }
    }
} finally {
    $presentation->dispose();
}
```

เมธอดอาจเพิ่มทรัพยากรภาพใหม่ไปยังงานนำเสนอ หากภาพต้นฉบับยังถูกใช้โดยกรอบรูปอื่น ๆ กรอบเหล่านั้นยังคงต้องการทรัพยากรเดิม ดังนั้นการลบพื้นที่ที่ตัดออกไม่ได้จำเป็นต้องลดจำนวนภาพทั้งหมด การตัดเนื้อหา WMF หรือ EMF ด้วยวิธีนี้จะทำให้ผลลัพธ์ที่ตัดเป็น PNG

## **บีบอัดภาพเรสเตอร์**

[PictureFillFormat::compressImage](https://reference.aspose.com/slides/th/php-java/aspose.slides/picturefillformat/#compressImage_boolean_int_) ลดความละเอียดของภาพเรสเตอร์สัมพันธ์กับขนาดที่ภาพแสดง นอกจากนี้ยังสามารถลบพื้นที่ที่ตัดในขั้นตอนเดียว เมธอดคืนค่า `true` เมื่อภาพถูกปรับขนาดหรือถูกตัดและ `false` เมื่อไม่จำเป็นต้องเปลี่ยนแปลง

ใช้ค่าที่กำหนดไว้ล่วงหน้าใน [PicturesCompression](https://reference.aspose.com/slides/th/php-java/aspose.slides/picturescompression/) เมื่อความละเอียดเป้าหมายมาตรฐานเพียงพอ:

```php
use aspose\slides\PicturesCompression;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("sample.pptx");
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
        $compressed = $pictureFrame->getPictureFormat()->compressImage(true, PicturesCompression::Dpi150);
        echo $compressed ? "The image was compressed." : "No compression was necessary.";
        $presentation->save("compressed-image.pptx", SaveFormat::Pptx);
    }
} finally {
    $presentation->dispose();
}
```

หากต้องการค่า DPI บวกที่กำหนดเองสามารถส่งค่าแทนค่าที่กำหนดไว้ล่วงหน้าเมื่อจำเป็นต้องมีเป้าหมายเฉพาะ

การบีบอัดมุ่งเน้นที่ภาพเรสเตอร์ SVG และเนื้อหาเมตาไฟล์จะไม่ถูกลดลงด้วยกระบวนการบีบอัดนี้ จำไว้ว่าความละเอียดที่ต่ำลงและการลบพื้นที่ที่ตัดออกไม่สามารถกู้คืนจากงานนำเสนอที่ทำให้เป็น Optimized ได้ เลือกความละเอียดเป้าหมายตามขนาดสูงสุดที่ภาพจะถูกมองเห็นหรือส่งออกจริง ๆ แทนการใช้ DPI ต่ำสุดทั่วทั้งเอกสาร

## **จัดการเอฟเฟกต์การแปลงภาพ**

สำหรับเวิร์กโฟลว์ครบถ้วนที่ครอบคลุมความสว่าง, คอนทราสต์, การแปลงสี, เบลอ, เอฟเฟกต์อัลฟา, โซ่ที่จัดลำดับ, การตรวจสอบ, การลบ, และการตรวจสอบแบบ round‑trip ดูที่ [Image Transform Effects](/php-java/image-transform-effects/)

## **ล็อกเรขาคณิตของกรอบรูป**

การตั้งค่า [PictureFrameLock](https://reference.aspose.com/slides/th/php-java/aspose.slides/pictureframelock/) ควบคุมว่าการดำเนินการแก้ไขใดถูกปิดการใช้งานสำหรับกรอบรูป ตัวอย่างเช่น [setAspectRatioLocked](https://reference.aspose.com/slides/th/php-java/aspose.slides/pictureframelock/setaspectratiolocked/) จะรักษาส่วนของรูปร่างขณะปรับขนาด

```php
use aspose\slides\Images;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $sourceImage = Images::fromFile("photo.jpg");
    try {
        $image = $presentation->getImages()->addImage($sourceImage);
    } finally {
        if (!java_is_null($sourceImage)) {
            $sourceImage->dispose();
        }
    }

    $pictureFrame = $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 50, 100, $image->getWidth(), $image->getHeight(), $image);
    $pictureFrame->getPictureFrameLock()->setAspectRatioLocked(true);

    $presentation->save("locked-picture-frame.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

การล็อกนี้ใช้กับรูปร่างกรอบรูป ไม่ได้บังคับให้ภาพต้นฉบับต้องรีแซมพลหรือเปลี่ยนเป็นสัดส่วนเดียวกันอย่างถาวร

## **ปรับค่า StretchOffset**

เมื่อโหมดเติมภาพเป็น stretch, ค่าการยืดออฟเซ็ตบน [PictureFillFormat](https://reference.aspose.com/slides/th/php-java/aspose.slides/picturefillformat/) กำหนดสี่เหลี่ยมเติมสัมพันธ์กับกล่องขอบของกรอบรูป ค่าที่เป็นเปอร์เซ็นต์บวกสร้างการยืดเข้าไปจากขอบ, ส่วนค่าที่เป็นเปอร์เซ็นต์ลบสร้างการยืดออก

สิ่งนี้แตกต่างจากการตัด ค่าแบบตัดเลือกส่วนของภาพต้นฉบับที่ต้องการให้มองเห็น; การยืดออฟเซ็ตเปลี่ยนสี่เหลี่ยมที่ภาพเติมจะถูกยืดเข้าไป

```php
use aspose\slides\Images;
use aspose\slides\PictureFillMode;
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

    $pictureFrame = $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 10, 10, 400, 300, $image);
    $pictureFrame->getPictureFormat()->setPictureFillMode(PictureFillMode::Stretch);
    $pictureFrame->getPictureFormat()->setStretchOffsetLeft(12);
    $pictureFrame->getPictureFormat()->setStretchOffsetRight(12);
    $pictureFrame->getPictureFormat()->setStretchOffsetTop(8);
    $pictureFrame->getPictureFormat()->setStretchOffsetBottom(8);

    $presentation->save("stretch-offsets.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

ใช้การยืดออฟเซ็ตสำหรับการจัดตำแหน่งการเติม ใช้คุณสมบัติตัดเมื่อเป้าหมายคือซ่อนขอบของภาพต้นฉบับ

## **การจัดเก็บ, ขนาดไฟล์, และข้อพิจารณาการส่งออก**

ข้อดีข้อเสียจะจัดการได้ง่ายขึ้นเมื่อการจัดเก็บภาพและการจัดรูปแบบกรอบรูปแยกออกจากกัน:

- **ภาพที่ฝังเอาไว้** ทำให้งานนำเสนอเป็นอิสระและเป็นทางเลือกที่น่าเชื่อถือที่สุดสำหรับการแชร์และการเรนเดอร์บนเซิร์ฟเวอร์ แต่ภาพเรสเตอร์ขนาดใหญ่จะเพิ่มขนาด PPTX และการใช้หน่วยความจำ
- **ภาพที่เชื่อมโยง** สามารถทำให้แพ็กเกจเล็กลงได้ แต่งานนำเสนอขึ้นกับไฟล์ภายนอกที่ต้องคงอยู่ที่เส้นทางหรือที่ตั้งที่บันทึกไว้
- **การตัด** ในตอนแรกไม่ทำลายข้อมูล พิกเซลที่ซ่อนยังคงฝังเอาไว้จนกว่าจะมีการลบพื้นที่ที่ตัดออกอย่างชัดเจนหรือระหว่างการบีบอัด
- **การบีบอัด** สามารถลดขนาดไฟล์ได้อย่างมากสำหรับภาพเรสเตอร์ขนาดใหญ่เกินไป แต่จะสูญเสียความละเอียดของแหล่งข้อมูล ควรทำหลังจากรู้ขนาดบนสไลด์ที่ต้องการแสดงแล้ว
- **ภาพ SVG** ควรคงเป็น SVG เมื่อความสำคัญของการรักษาเวกเตอร์สูง สกัด SVG ที่ฝังโดยตรงเมื่อคุณต้องการทรัพยากรเวกเตอร์เอง การส่งออกสไลด์เป็นเรสเตอร์จะเปลี่ยนสไลด์ที่เรนเดอร์เป็นพิกเซลเสมอ
- **ภาพซ้ำ** ควรใช้ทรัพยากร [PPImage](https://reference.aspose.com/slides/th/php-java/aspose.slides/ppimage/) ที่มีอยู่แล้วเมื่อเป็นไปได้ แทนการโหลดไฟล์เดียวกันหลายครั้งในเวิร์กโฟลว์ของงานนำเสนอ

สำหรับงานนำเสนอขนาดใหญ่ การเพิ่มประสิทธิภาพภาพมักจะได้ผลดีที่สุดเมื่อทำอย่างเลือกสรร: เก็บโลโก้และไดอะแกรมเป็นเนื้อหาเวกเตอร์, บีบอัดภาพถ่ายตามขนาดการแสดงผลจริง, ลบพิกเซลที่ตัดออกเฉพาะเมื่อไม่ต้องการการแก้ไขต่อภายหลัง, และหลีกเลี่ยงลิงก์ภายนอกเว้นแต่ว่าการจัดการการพึ่งพาจะเป็นส่วนหนึ่งของการออกแบบการปรับใช้

## **FAQ**

**กรอบรูปและแหล่งข้อมูลภาพต่างกันอย่างไร?**

[PPImage](https://reference.aspose.com/slides/th/php-java/aspose.slides/ppimage/) แสดงถึงแหล่งข้อมูลภาพที่เชื่อมโยงกับงานนำเสนอ [PictureFrame](https://reference.aspose.com/slides/th/php-java/aspose.slides/pictureframe/) เป็นรูปร่างบนสไลด์ที่แสดงภาพและเก็บเรขาคณิตและการจัดรูปแบบระดับกรอบ เช่น ขนาด, การหมุน, ค่าเพื่อตัด, เอฟเฟกต์, และการล็อก

**ควรฝังหรือเชื่อมโยงภาพ?**

ฝังภาพเมื่อจำเป็นต้องให้งานนำเสนอพกพา, จัดเก็บ, หรือเรนเดอร์โดยไม่ต้องพึ่งพาแหล่งภายนอก เชื่อมโยงภาพเฉพาะเมื่อต้องการเก็บไฟล์ภาพแยกจาก PPTX อย่างตั้งใจและตำแหน่งภายนอกสามารถดูแลได้อย่างเชื่อถือได้

**การตัดลดขนาดไฟล์ PPTX หรือไม่?**

ไม่โดยตรง การตั้งค่าตัดปกติจะซ่อนส่วนของภาพต้นฉบับแต่ยังคงเก็บพิกเซลอยู่ ใช้ [PictureFillFormat::deletePictureCroppedAreas](https://reference.aspose.com/slides/th/php-java/aspose.slides/picturefillformat/#deletePictureCroppedAreas) หรือการบีบอัดภาพพร้อมการลบพื้นที่ที่ตัดออกเมื่อพิกเซลเหล่านั้นสามารถทิ้งได้อย่างถาวร

**ฉันสามารถคืนคุณภาพภาพหลังการบีบอัดได้หรือไม่?**

ไม่ได้ การบีบอัดอาจลดความละเอียดเรสเตอร์ที่เก็บและการลบพื้นที่ที่ตัดออกจะทำให้ข้อมูลภาพหายไป เก็บภาพต้นฉบับไว้ภายนอกงานนำเสนอหากอาจต้องแก้ไขด้วยความละเอียดสูงในภายหลัง

**ควรจัดการภาพ SVG อย่างไร?**

เก็บเนื้อหา SVG เป็น SVG เมื่อความแม่นยำของเวกเตอร์สำคัญ สามารถสกัด [SvgImage](https://reference.aspose.com/slides/th/php-java/aspose.slides/svgimage/) ที่ฝังได้โดยตรง การเรนเดอร์สไลด์เป็นรูปแบบเรสเตอร์เช่น PNG หรือ JPEG จะทำให้ SVG ถูกแปลงเป็นพิกเซล

**จะหลีกเลี่ยงการแคสไม่ปลอดภัยเมื่ออ่านสไลด์ที่มีอยู่ได้อย่างไร?**

ตรวจสอบประเภทของรูปร่างก่อนใช้สมาชิกที่เฉพาะเจาะจงกับกรอบรูป การตรวจสอบ `java_instanceof` กับ [PictureFrame](https://reference.aspose.com/slides/th/php-java/aspose.slides/pictureframe/) จะช่วยป้องกันการแคสที่ไม่ถูกต้องและทำให้โค้ดจัดการกับสไลด์ที่ไม่มีกรอบรูปได้อย่างปลอดภัย