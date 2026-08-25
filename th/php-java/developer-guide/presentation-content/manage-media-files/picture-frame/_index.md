---
title: จัดการ Picture Frame ในพรีเซนเทชันโดยใช้ PHP
linktitle: กรอบภาพ
type: docs
weight: 10
url: /th/php-java/picture-frame/
keywords:
- กรอบภาพ
- เพิ่มกรอบภาพ
- สร้างกรอบภาพ
- รูปภาพฝัง
- รูปภาพลิงก์
- สกัดรูปภาพ
- รูปเรสเตอร์
- รูป SVG
- ครอปรูปภาพ
- ลบพื้นที่ที่ครอป
- บีบอัดรูปภาพ
- StretchOffset
- การจัดรูปแบบกรอบภาพ
- สเกลเชิงสัมพัทธ์
- เอฟเฟ็กต์รูปภาพ
- อัตราส่วนภาพ
- PowerPoint
- OpenDocument
- พรีเซนเทชัน
- PHP
- Aspose.Slides
description: "สร้าง, จัดรูปแบบ, ทำลิงก์, ครอป, สกัด และบีบอัดกรอบภาพในพรีเซนเทชันด้วย Aspose.Slides สำหรับ PHP ผ่าน Java."
---
## **ภาพรวม**

Picture frame คือรูปทรงสไลด์ที่แสดงรูปภาพ ใน Aspose.Slides, แหล่งข้อมูลรูปภาพและรูปทรงที่แสดงรูปนั้นเป็นอ็อบเจกต์แยกกัน: [Presentation](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentation/) ถือครองรูปภาพที่ฝังอยู่ผ่าน [ImageCollection](https://reference.aspose.com/slides/th/php-java/aspose.slides/imagecollection/), ส่วน [PictureFrame](https://reference.aspose.com/slides/th/php-java/aspose.slides/pictureframe/) ควบคุมตำแหน่ง, ขนาด, การจัดรูปแบบเส้น, การหมุน, การครอป, เอฟเฟ็กต์รูปภาพ, และการตั้งค่าระดับเฟรมอื่น ๆ

การแยกนี้มีประโยชน์เมื่อรูปเดียวกันต้องแสดงหลายครั้ง ให้เพิ่มรูปไปยังพรีเซนเทชันเพียงครั้งเดียว, เก็บ [PPImage](https://reference.aspose.com/slides/th/php-java/aspose.slides/ppimage/) ที่ส่งกลับ, แล้วใช้แหล่งข้อมูลรูปนั้นเมื่สร้าง picture frame

Picture frame สามารถบรรจุรูปเรสเตอร์เช่น PNG หรือ JPEG และรูปเวกเตอร์ SVG ได้เช่นกัน อีกทั้งยังสามารถอ้างอิงรูปที่ลิงก์แทนการเก็บไบต์รูปในพรีเซนเทชัน ตัวเลือกนี้ส่งผลต่อการพกพา, ขนาดไฟล์, การสกัด และพฤติกรรมการส่งออก ดังนั้นควรตัดสินใจวิธีเก็บรูปก่อนทำการจัดรูปแบบหรือการเพิ่มประสิทธิภาพ

## **เพิ่มและจัดรูปแบบรูปภาพที่ฝังไว้**

สำหรับรูปภาพที่ฝังไว้ ให้เพิ่มข้อมูลรูปลงในพรีเซนเทชันและสร้าง picture frame ด้วย [ShapeCollection::addPictureFrame](https://reference.aspose.com/slides/th/php-java/aspose.slides/shapecollection/addpictureframe/) รูปจะกลายเป็นส่วนหนึ่งของแพคเกจพรีเซนเทชัน ดังนั้นพรีเซนเทชันจะยังคงเป็นอิสระเมื่อนำไปย้ายไปยังคอมพิวเตอร์เครื่องอื่น

ตัวอย่างต่อไปนี้เพิ่มรูป JPEG, สร้างเฟรมที่มีขนาดตามมิติเดิมของรูป, และใช้การจัดรูปแบบเส้นและการหมุน:

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

picture frame ควบคุมเรขาคณิตที่แสดง; การเปลี่ยนขนาดเฟรมไม่ทำให้มิติพิกเซลเดิมของแหล่งรูปที่ฝังไว้เปลี่ยนแปลง ความแตกต่างนี้สำคัญเมื่อทำการครอปหรือบีบอัดรูปภายหลัง

## **ใช้การสเกลเชิงสัมพัทธ์**

[PictureFrame](https://reference.aspose.com/slides/th/php-java/aspose.slides/pictureframe/) เปิดเผยการสเกลความกว้างและความสูงเชิงสัมพัทธ์ของเฟรมผ่าน [setRelativeScaleWidth](https://reference.aspose.com/slides/th/php-java/aspose.slides/pictureframe/setrelativescalewidth/) และ [setRelativeScaleHeight](https://reference.aspose.com/slides/th/php-java/aspose.slides/pictureframe/setrelativescaleheight/) ค่า `1.0` แสดงถึง 100% ของขนาดรูปต้นฉบับ การสเกลเชิงสัมพัทธ์มีประโยชน์เมื่อเวิร์กโฟลว์ต้องคงอัตราส่วนกับขนาดรูปต้นฉบับแทนการคำนวณขนาดสุดท้ายด้วยตนเอง

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

การสเกลเชิงสัมพัทธ์เปลี่ยนการตั้งค่าขนาดของเฟรม; ไม่ทำการรีแซมพลิงหรือบีบอัดรูปที่ฝังไว้

## **รูปภาพที่ฝังและรูปภาพที่ลิงก์**

รูปภาพที่ฝังเก็บข้อมูลรูปภายในพรีเซนเทชัน จึงเป็นตัวเลือกที่ปลอดภัยที่สุดสำหรับการพกพาและการเรนเดอร์ที่คาดเดาได้ รูปภาพที่ลิงก์เก็บตำแหน่งภายนอกผ่านเมธอด [Picture::setLinkPathLong](https://reference.aspose.com/slides/th/php-java/aspose.slides/picture/setlinkpathlong/) แทนการฝังข้อมูลรูปแบบเดียวกัน

รูปภาพที่ลิงก์สามารถลดปริมาณข้อมูลรูปที่เก็บใน PPTX ได้ แต่จะเพิ่มการพึ่งพาไฟล์ภายนอก ไฟล์ที่ลิงก์ต้องสามารถเข้าถึงได้โดยแอปพลิเคชันที่เปิดหรือเรนเดอร์พรีเซนเทชัน หากเส้นทางเปลี่ยน, ย้ายไฟล์, หรือไม่สามารถเข้าถึงทรัพยากรได้, รูปที่ลิงก์อาจไม่แสดงตามคาด สำหรับพรีเซนเทชันที่ต้องส่งอีเมล, เก็บถาวร, หรือเรนเดอร์ในสภาพแวดล้อมแยก, รูปที่ฝังมักเชื่อถือได้มากกว่า

### **เพิ่มรูปภาพที่ลิงก์**

ตัวอย่างต่อไปนี้สร้าง picture frame แล้วชี้ไปยังไฟล์รูปภาพในเครื่องโลคัล มุ่งเน้นการลิงก์รูปภาพเท่านั้น; การลิงก์วิดีโอเป็นเวิร์กโฟลว์สื่อแยกต่างหากและไม่ได้ผสมเข้ากับตัวอย่างนี้โดยเจตนา

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

ใช้ลิงก์เมื่อการจัดการไฟล์ภายนอกเป็นเจตนาที่ชัดเจน อย่าใช้เป็นทางลัดแทนการบีบอัด: PPTX ขนาดเล็กที่มีการพึ่งพารูปภาพเสียหายมักไม่มีประโยชน์เท่าพรีเซนเทชันที่มีขนาดใหญ่และเป็นอิสระ

## **สกัดรูปภาพจาก Picture Frame**

ก่อนสกัดรูปจากพรีเซนเทชันที่มีอยู่, ตรวจสอบให้แน่ใจว่า Shape นั้นเป็น [PictureFrame](https://reference.aspose.com/slides/th/php-java/aspose.slides/pictureframe/) และมีรูปที่ฝังอยู่ รูปที่ลิงก์อาจไม่มีไบต์รูปที่สามารถสกัดได้ในแบบเดียวกัน

### **สกัดรูปเรสเตอร์**

API รูปภาพสมัยใหม่ใช้ [IImage](https://reference.aspose.com/slides/th/php-java/aspose.slides/iimage/) โดยตรง ตัวอย่างต่อไปนี้ค้นหารูปเรสเตอร์ที่ฝังอยู่เป็นรูปแรกบนสไลด์และบันทึกเป็น PNG:

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

การบันทึกผ่าน [IImage::save](https://reference.aspose.com/slides/th/php-java/aspose.slides/iimage/#save) จะเปลี่ยนรูปที่สกัดเป็นรูปแบบผลลัพธ์ที่ร้องขอ หากต้องการไบต์ที่เข้ารหัสที่เก็บอยู่ในพรีเซนเทชันแทนไฟล์เรสเตอร์ที่แปลงแล้ว, ให้ใช้ข้อมูลไบนารีของแหล่งรูปแทน

### **สกัดรูป SVG**

สำหรับรูป SVG, [PPImage](https://reference.aspose.com/slides/th/php-java/aspose.slides/ppimage/) เปิดเผยอ็อบเจกต์ [SvgImage](https://reference.aspose.com/slides/th/php-java/aspose.slides/svgimage/) ซึ่งทำให้คุณดึงข้อมูล SVG โดยตรงแทนการแปลงเป็นเรสเตอร์ก่อน

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

การเก็บเนื้อหา SVG เป็น SVG จะคงความเป็นเวกเตอร์ไว้ในพรีเซนเทชัน การส่งออกเป็นเรสเตอร์เช่น PNG หรือ JPEG จะต้องเรนเดอร์เวกเตอร์นั้นเป็นพิกเซล การส่งออกสไลด์เป็น PDF หรือ SVG ก็เป็นกระบวนการเรนเดอร์เช่นกัน ดังนั้นกราฟิกที่ส่งออกไม่ควรถือเป็นสำเนาแบบไบต์ต่อไบต์ของ SVG ที่ฝังไว้; ให้ใช้ข้อมูลจาก [SvgImage::getSvgData](https://reference.aspose.com/slides/th/php-java/aspose.slides/svgimage/getsvgdata/) เมื่อจำเป็นต้องใช้แหล่งเวกเตอร์ดั้งเดิม

## **การครอปภาพ**

การครอปเปลี่ยนส่วนของรูปภาพที่มองเห็นได้ภายในเฟรม ค่า cropping บน [PictureFillFormat](https://reference.aspose.com/slides/th/php-java/aspose.slides/picturefillformat/) เป็นเปอร์เซ็นต์ของมิติรูปต้นฉบับ การครอปไม่ได้ลบพิกเซลที่ซ่อนอยู่จากรูปที่ฝังไว้ในตอนแรก; เพียงเปลี่ยนพื้นที่ที่มองเห็น

ตัวอย่างต่อไปนี้ค้นหา picture frame อย่างปลอดภัยและใช้ค่า cropping:

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

เนื่องจากข้อมูลรูปที่ซ่อนยังคงอยู่, สามารถเปลี่ยนค่าครอปภายหลังโดยไม่สูญเสียพิกเซลเดิม หากขนาดไฟล์สำคัญกว่าการย้อนคืน, สามารถลบพื้นที่ที่ครอปอย่างเป็นทางการตามที่อธิบายในส่วนต่อไป

## **ลบข้อมูลรูปที่ถูกครอป**

[PictureFillFormat::deletePictureCroppedAreas](https://reference.aspose.com/slides/th/php-java/aspose.slides/picturefillformat/#deletePictureCroppedAreas) จะลบข้อมูลรูปที่อยู่นอกสี่เหลี่ยมครอปปัจจุบันและคืนแหล่งรูปที่ได้ ผลลัพธ์นี้ช่วยลดขนาดไฟล์ได้ แต่เป็นการเพิ่มประสิทธิภาพแบบทำลาย: หลังจากพรีเซนเทชันถูกบันทึก, พิกเซลที่ลบจะไม่มีให้ใช้ในการทำ uncrop อีกต่อไป

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

เมธอดนี้อาจเพิ่มแหล่งรูปใหม่ในพรีเซนเทชัน หากรูปต้นฉบับยังถูกใช้โดย picture frame อื่น, เฟรมเหล่านั้นยังคงต้องการแหล่งรูปเดิม, ดังนั้นการลบพื้นที่ที่ครอปไม่จำเป็นต้องทำให้จำนวนรูปทั้งหมดลดลง การครอป WMF หรือ EMF ด้วยเมธอดนี้จะทำให้ผลลัพธ์ที่ครอปถูกแปลงเป็น PNG

## **บีบอัดรูปเรสเตอร์**

[PictureFillFormat::compressImage](https://reference.aspose.com/slides/th/php-java/aspose.slides/picturefillformat/#compressImage_boolean_int_) ลดความละเอียดของรูปเรสเตอร์สัมพันธ์กับขนาดที่รูปแสดง สามารถลบพื้นที่ที่ครอปในขั้นตอนเดียวได้ เมธอดจะคืนค่า `true` เมื่อรูปถูกปรับขนาดหรือครอป และ `false` เมื่อไม่มีการเปลี่ยนแปลงใด ๆ

ใช้ค่า [PicturesCompression](https://reference.aspose.com/slides/th/php-java/aspose.slides/picturescompression/) ที่กำหนดไว้ล่วงหน้าเมื่อความละเอียดเป้าหมายมาตรฐานเพียงพอ:

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

สามารถส่งค่าความละเอียด DPI บวกที่กำหนดเองแทนค่าที่กำหนดไว้ล่วงหน้าเมื่อจำเป็นต้องใช้เป้าหมายเฉพาะ

การบีบอัดมุ่งเน้นที่รูปเรสเตอร์เท่านั้น เนื้อหา SVG และเมตาไฟล์จะไม่ถูกลดลงโดยกระบวนการบีบอัดนี้ นอกจากนี้อย่าลืมว่าความละเอียดต่ำและการลบพื้นที่ที่ครอปไม่สามารถกู้คืนได้จากพรีเซนเทชันที่เพิ่มประสิทธิภาพแล้ว ให้เลือกความละเอียดเป้าหมายตามขนาดสูงสุดที่รูปจะถูกดูหรือส่งออกจริง ๆ แทนการใช้ DPI ต่ำสุดทั่วทั้งไฟล์

## **จัดการเอฟเฟ็กต์การแปลงรูปภาพ**

สำหรับเวิร์กโฟลว์เต็มรูปแบบที่ครอบคลุมความสว่าง, คอนทราสต์, การแปลงสี, บลูร, เอฟเฟ็กต์อัลฟา, โซ่ที่จัดลำดับ, การตรวจสอบ, การลบ, และการตรวจสอบรอบกลับ, ดูที่ [Image Transform Effects](/slides/th/php-java/image-transform-effects/)

## **ล็อคเรขาคณิตของ Picture Frame**

การตั้งค่า [PictureFrameLock](https://reference.aspose.com/slides/th/php-java/aspose.slides/pictureframelock/) ควบคุมการดำเนินการแก้ไขที่ถูกปิดใช้งานสำหรับ picture frame ตัวอย่างเช่น, [setAspectRatioLocked](https://reference.aspose.com/slides/th/php-java/aspose.slides/pictureframelock/setaspectratiolocked/) จะคงอัตราส่วนของรูปทรงขณะปรับขนาด

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

การล็อคนี้ใช้กับ shape ของ picture frame เท่านั้น ไม่บังคับให้รูปต้นฉบับต้องถูกรีแซมพล์หรือเปลี่ยนอัตราส่วนถาวร

## **ปรับค่า StretchOffset**

เมื่อโหมดการเติมรูปเป็น stretch, ค่า stretch‑offset บน [PictureFillFormat](https://reference.aspose.com/slides/th/php-java/aspose.slides/picturefillformat/) จะกำหนดสี่เหลี่ยมเติมสัมพันธ์กับกล่องขอบของ picture frame ค่าเปอร์เซ็นต์บวกจะทำให้เกิดการฝังจากขอบ, ค่าเปอร์เซ็นต์ลบจะทำให้เกิดการขยายออก

นี่ต่างจากการครอป ค่าครอปเลือกส่วนของรูปต้นฉบับที่จะแสดง; stretch offset จะเปลี่ยนสี่เหลี่ยมที่รูปเติมจะถูกขยายไป

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

ใช้ stretch offset สำหรับการวางตำแหน่งการเติม ใช้คุณสมบัติคอร์อปเมื่อเป้าหมายคือการซ่อนขอบของรูปต้นฉบับ

## **การจัดเก็บ, ขนาดไฟล์, และข้อควรพิจารณาการส่งออก**

การพิจารณา trade‑off หลักจะง่ายขึ้นเมื่อการจัดเก็บรูปภาพและการจัดรูปแบบ picture frame แยกกัน:

- **Embedded images** ทำให้พรีเซนเทชันเป็นอิสระและเป็นตัวเลือกที่เชื่อถือได้ที่สุดสำหรับการแชร์และการเรนเดอร์ฝั่งเซิร์ฟเวอร์, แต่รูปเรสเตอร์ขนาดใหญ่ทำให้ PPTX ใหญ่และใช้หน่วยความจำมาก
- **Linked images** สามารถทำให้แพคเกจเล็กลง, แต่พรีเซนเทชันจะพึ่งพาไฟล์ภายนอกที่ต้องคงอยู่ที่เส้นทางหรือสถานที่ที่เก็บไว้
- **Cropping** ในขั้นแรกไม่ทำลาย; พิกเซลที่ซ่อนยังคงฝังอยู่จนกว่าจะลบพื้นที่ที่ครอปโดยชัดเจนหรือระหว่างการบีบอัด
- **Compression** สามารถลดขนาดไฟล์ได้อย่างมหาศาลสำหรับรูปเรสเตอร์ที่ใหญ่เกินขนาด, แต่จะเสียความละเอียดต้นฉบับ ควรทำหลังจากทราบขนาดบนสไลด์ที่ต้องการแล้ว
- **SVG images** ควรคงเป็น SVG เมื่อความคงสภาพของเวกเตอร์สำคัญ; สกัด SVG ที่ฝังไว้โดยตรงเมื่อคุณต้องการทรัพยากรเวกเตอร์เอง การส่งออกสไลด์เป็นเรสเตอร์จะเปลี่ยนสไลด์ที่เรนเดอร์เป็นพิกเซลเสมอ
- **Repeated images** ควรใช้แหล่ง [PPImage](https://reference.aspose.com/slides/th/php-java/aspose.slides/ppimage/) เดิมเมื่อทำได้แทนการโหลดไฟล์เดียวกันหลายครั้งในเวิร์กโฟลว์พรีเซนเทชัน

สำหรับพรีเซนเทชันขนาดใหญ่, การเพิ่มประสิทธิภาพรูปภาพมักได้ผลดีที่สุดเมื่อทำแบบเลือกสรร: เก็บโลโก้และไดอะแกรมเป็นเนื้อหาเวกเตอร์, บีบอัดภาพถ่ายตามขนาดการแสดงจริง, ลบพิกเซลที่ครอปเฉพาะเมื่อไม่ต้องการการแก้ไขต่อ, และหลีกเลี่ยงลิงก์ภายนอกถ้าการจัดการการพึ่งพาไม่เป็นส่วนหนึ่งของการออกแบบการปรับใช้

## **คำถามที่พบบ่อย**

**ความแตกต่างระหว่าง picture frame กับ image resource คืออะไร?**

[PPImage](https://reference.aspose.com/slides/th/php-java/aspose.slides/ppimage/) แทนแหล่งรูปภาพที่เชื่อมโยงกับพรีเซนเทชัน ส่วน [PictureFrame](https://reference.aspose.com/slides/th/php-java/aspose.slides/pictureframe/) เป็นรูปทรงบนสไลด์ที่แสดงรูปภาพและเก็บข้อมูลเรขาคณิตและการจัดรูปแบบระดับเฟรม เช่น ขนาด, การหมุน, ค่าครอป, เอฟเฟ็กต์, และการล็อค

**ควรฝังรูปหรือทำลิงก์รูปดี?**

ฝังรูปเมื่อพรีเซนเทชันต้องการความพกพา, การเก็บถาวร, หรือการเรนเดอร์โดยไม่ต้องอาศัยทรัพยากรภายนอก; ทำลิงก์รูปเฉพาะเมื่อต้องการแยกรูปออกจาก PPTX อย่างตั้งใจและสามารถรักษาตำแหน่งไฟล์ภายนอกได้อย่างเชื่อถือได้

**การครอปลดขนาดไฟล์ PPTX หรือไม่?**

ไม่โดยตรง การตั้งค่าครอปปกติจะซ่อนส่วนของรูปต้นฉบับแต่ยังคงเก็บพิกเซลไว้ ใช้ [PictureFillFormat::deletePictureCroppedAreas](https://reference.aspose.com/slides/th/php-java/aspose.slides/picturefillformat/#deletePictureCroppedAreas) หรือบีบอัดรูปพร้อมการลบพื้นที่ที่ครอปเมื่อสามารถทิ้งพิกเซลเหล่านั้นได้อย่างถาวร

**สามารถกู้คืนคุณภาพรูปหลังบีบอัดได้หรือไม่?**

ไม่ได้ การบีบอัดอาจลดความละเอียดเรสเตอร์ที่เก็บไว้, การลบพื้นที่ที่ครอปจะทำให้ข้อมูลรูปหายไป ควรเก็บรูปต้นฉบับนอกพรีเซนเทชันหากอาจต้องแก้ไขด้วยความละเอียดสูงในภายหลัง

**ควรจัดการรูป SVG อย่างไร?**

เก็บเนื้อหา SVG เป็น SVG เมื่อความคมชัดของเวกเตอร์สำคัญ; สามารถสกัด [SvgImage](https://reference.aspose.com/slides/th/php-java/aspose.slides/svgimage/) ที่ฝังไว้โดยตรงได้ การเรนเดอร์สไลด์เป็นรูปเรสเตอร์เช่น PNG หรือ JPEG จะทำให้ SVG ถูกแปลงเป็นพิกเซล

**จะหลีกเลี่ยงการ cast ที่ไม่ปลอดภัยเมื่ออ่านสไลด์ที่มีอยู่ได้อย่างไร?**

ตรวจสอบประเภทของ shape ก่อนใช้สมาชิกเฉพาะ picture‑frame การตรวจสอบ `java_instanceof` กับ [PictureFrame](https://reference.aspose.com/slides/th/php-java/aspose.slides/pictureframe/) จะช่วยป้องกันการ cast ไม่ถูกต้องและให้โค้ดจัดการสไลด์ที่ไม่มี picture frame ได้อย่างเหมาะสม