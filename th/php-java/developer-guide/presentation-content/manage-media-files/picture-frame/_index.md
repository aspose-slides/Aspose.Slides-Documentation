---  
title: จัดการ Picture Frame ในงานนำเสนอด้วย PHP  
linktitle: กรอบภาพ  
type: docs  
weight: 10  
url: /th/php-java/picture-frame/  
keywords:  
- กรอบภาพ  
- เพิ่มกรอบภาพ  
- สร้างกรอบภาพ  
- ภาพฝัง  
- ภาพเชื่อมโยง  
- สกัดภาพ  
- ภาพแรสเตอร์  
- ภาพ SVG  
- ครอปภาพ  
- ลบพื้นที่ที่ครอป  
- บีบอัดภาพ  
- StretchOffset  
- การจัดรูปแบบกรอบภาพ  
- สเกลสัมพันธ์  
- เอฟเฟกต์ภาพ  
- อัตราส่วนภาพ  
- PowerPoint  
- OpenDocument  
- งานนำเสนอ  
- PHP  
- Aspose.Slides  
description: "สร้าง, จัดรูปแบบ, เชื่อมโยง, ครอป, สกัด, และบีบอัดกรอบภาพในงานนำเสนอด้วย Aspose.Slides สำหรับ PHP ผ่าน Java."  
---
## **ภาพรวม**

Picture frame คือรูปทรงสไลด์ที่แสดงภาพหนึ่งภาพ ใน Aspose.Slides แหล่งข้อมูลภาพและรูปทรงที่แสดงภาพนั้นเป็นออบเจ็กต์แยกกัน: a [Presentation](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentation/) เป็นเจ้าของแหล่งข้อมูลภาพฝังด้วยผ่าน [ImageCollection](https://reference.aspose.com/slides/th/php-java/aspose.slides/imagecollection/) ของมัน, ส่วน [PictureFrame](https://reference.aspose.com/slides/th/php-java/aspose.slides/pictureframe/) ควบคุมตำแหน่ง, ขนาด, การจัดรูปแบบเส้น, การหมุน, การครอป, เอฟเฟกต์ภาพ, และการตั้งค่าระดับเฟรมอื่น ๆ

การแยกนี้มีประโยชน์เมื่อภาพเดียวกันต้องแสดงหลายครั้ง ให้นำภาพเข้ามาในงานนำเสนอเพียงครั้งเดียว, เก็บ [PPImage](https://reference.aspose.com/slides/th/php-java/aspose.slides/ppimage/) ที่ส่งกลับ, แล้วใช้แหล่งข้อมูลภาพนั้นเมื่อต้องสร้าง picture frame

Picture frame สามารถบรรจุภาพแรสเตอร์เช่น PNG หรือ JPEG และภาพเวกเตอร์ SVG ได้ ทั้งยังสามารถอ้างอิงภาพที่เชื่อมโยง (linked) แทนการเก็บไบต์ของภาพไว้ในงานนำเสนอ การเลือกนี้ส่งผลต่อความพกพา, ขนาดไฟล์, การสกัด, และพฤติกรรมการส่งออก ดังนั้นจึงควรตัดสินใจว่าภาพควรถูกเก็บอย่างไรก่อนทำการจัดรูปแบบหรือการเพิ่มประสิทธิภาพ

## **เพิ่มและจัดรูปแบบภาพฝัง**

สำหรับภาพฝัง ให้นำข้อมูลภาพเข้าไปในงานนำเสนอและสร้าง picture frame ด้วย [ShapeCollection::addPictureFrame](https://reference.aspose.com/slides/th/php-java/aspose.slides/shapecollection/addpictureframe/) ภาพจะกลายเป็นส่วนหนึ่งของแพ็คเกจงานนำเสนอ ดังนั้นงานนำเสนอจะยังคงเป็นอิสระเมื่อย้ายไปยังคอมพิวเตอร์เครื่องอื่น

ตัวอย่างต่อไปนี้เพิ่มภาพ JPEG, สร้างเฟรมโดยใช้ขนาดดั้งเดิมของภาพ, และใช้การจัดรูปแบบเส้นและการหมุน:

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

picture frame ควบคุมเรขาคณิตที่แสดง; การเปลี่ยนขนาดเฟรมจะไม่เปลี่ยนมิติพิกเซลดั้งเดิมที่จัดเก็บในแหล่งข้อมูลภาพฝัง ความแตกต่างนี้สำคัญเมื่อทำการครอปหรือบีบอัดภาพในภายหลัง

## **ใช้การสเกลแบบสัมพันธ์**

[PictureFrame](https://reference.aspose.com/slides/th/php-java/aspose.slides/pictureframe/) แสดงการสเกลความกว้างและความสูงสัมพันธ์ของเฟรมผ่าน [setRelativeScaleWidth](https://reference.aspose.com/slides/th/php-java/aspose.slides/pictureframe/setrelativescalewidth/) และ [setRelativeScaleHeight](https://reference.aspose.com/slides/th/php-java/aspose.slides/pictureframe/setrelativescaleheight/). ค่าที่ `1.0` หมายถึง 100% ของขนาดรูปภาพดั้งเดิม การสเกลแบบสัมพันธ์มีประโยชน์เมื่อเวิร์กโฟลว์ต้องรักษาความสัมพันธ์กับขนาดภาพต้นฉบับแทนการคำนวณขนาดสุดท้ายด้วยตนเอง

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

การสเกลแบบสัมพันธ์เปลี่ยนการตั้งค่าการสเกลของเฟรม; มันไม่ได้ทำการรีแซมป์หรือบีบอัดภาพฝัง

## **ภาพฝังและภาพเชื่อมโยง**

ภาพฝังเก็บข้อมูลภาพภายในงานนำเสนอและจึงเป็นทางเลือกที่ปลอดภัยที่สุดสำหรับความพกพาและการเรนเดอร์ที่คาดเดาได้ ภาพเชื่อมโยงเก็บตำแหน่งภายนอกผ่านเมธอด [Picture::setLinkPathLong](https://reference.aspose.com/slides/th/php-java/aspose.slides/picture/setlinkpathlong/) แทนการฝังข้อมูลภาพในลักษณะเดียวกัน

ภาพเชื่อมโยงสามารถลดปริมาณข้อมูลภาพที่เก็บใน PPTX แต่จะสร้างการพึ่งพาภายนอก ไฟล์เชื่อมโยงต้องสามารถเข้าถึงได้โดยแอปพลิเคชันที่เปิดหรือเรนเดอร์งานนำเสนอ หากเส้นทางเปลี่ยน, ไฟล์ย้าย, หรือทรัพยากรไม่สามารถเข้าถึงได้, ภาพเชื่อมโยงอาจไม่แสดงตามคาด สำหรับงานนำเสนอที่ต้องส่งอีเมล, จัดเก็บ, หรือเรนเดอร์ในสภาพแวดล้อมที่แยกจากกัน, ภาพฝังมักจะเชื่อถือได้มากกว่า

### **เพิ่มภาพเชื่อมโยง**

ตัวอย่างต่อไปนี้สร้าง picture frame และชี้ไปยังไฟล์ภาพในเครื่องโลคัล มันจัดการเฉพาะการเชื่อมโยงภาพ; การเชื่อมโยงวิดีโอเป็นเวิร์กโฟลว์สื่อแยกต่างหากและไม่ได้รวมไว้ในตัวอย่างนี้โดยเจตนา

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

ใช้ลิงก์เมื่อการจัดการไฟล์ภายนอกเป็นเจตนา ไม่ควรใช้เป็นวิธีแทนการบีบอัด: PPTX เล็กๆ ที่มีการพึ่งพาภาพเสียหายมักจะไม่มีประโยชน์เท่ากับงานนำเสนอที่มีขนาดใหญ่แต่เป็นอิสระ

## **สกัดภาพจาก Picture Frame**

ก่อนสกัดภาพจากงานนำเสนอที่มีอยู่, ตรวจสอบให้แน่ใจว่า shape เป็น [PictureFrame](https://reference.aspose.com/slides/th/php-java/aspose.slides/pictureframe/) จริงและมีภาพฝังอยู่ Picture frame ที่เชื่อมโยงอาจไม่มีไบต์ของภาพที่สามารถสกัดได้ในลักษณะเดียวกัน

### **สกัดภาพแรสเตอร์**

API ภาพสมัยใหม่ใช้ [IImage](https://reference.aspose.com/slides/th/php-java/aspose.slides/iimage/) โดยตรง ตัวอย่างต่อไปนี้ค้นหาภาพแรสเตอร์ฝังตัวแรกบนสไลด์และบันทึกเป็น PNG:

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

การบันทึกผ่าน [IImage::save](https://reference.aspose.com/slides/th/php-java/aspose.slides/iimage/#save) จะเปลี่ยนภาพที่สกัดเป็นรูปแบบเอาต์พุตที่ร้องขอ หากต้องการไบต์ที่เข้ารหัสเก็บในงานนำเสนอแทนไฟล์แรสเตอร์ที่แปลงแล้ว, ให้ใช้ข้อมูลไบนารีของแหล่งภาพแทน

### **สกัดภาพ SVG**

สำหรับภาพ SVG, [PPImage](https://reference.aspose.com/slides/th/php-java/aspose.slides/ppimage/) ให้บริการออบเจ็กต์ [SvgImage](https://reference.aspose.com/slides/th/php-java/aspose.slides/svgimage/) ซึ่งทำให้คุณดึงข้อมูล SVG ได้โดยตรงโดยไม่ต้องเรสเตอร์ไลซ์ภาพก่อน

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

เก็บเนื้อหา SVG เป็น SVG จะรักษาแหล่งเวกเตอร์ไว้ในงานนำเสนอ การส่งออกแรสเตอร์เช่น PNG หรือ JPEG จะต้องเรนเดอร์เวกเตอร์นั้นเป็นพิกเซล การส่งออกสไลด์เป็น PDF หรือ SVG ก็เป็นการเรนเดอร์เช่นกัน ดังนั้นกราฟิกที่ส่งออกไม่ควรถือเป็นสำเนาไบต์ต่อไบต์ของ SVG ฝัง; ให้ใช้ข้อมูลจาก [SvgImage::getSvgData](https://reference.aspose.com/slides/th/php-java/aspose.slides/svgimage/getsvgdata/) เมื่อจำเป็นต้องใช้แหล่งเวกเตอร์ต้นฉบับจริง

## **ครอปภาพ**

การครอปเปลี่ยนส่วนของภาพที่มองเห็นได้ภายในเฟรม ค่าครอปบน [PictureFillFormat](https://reference.aspose.com/slides/th/php-java/aspose.slides/picturefillformat/) เป็นเปอร์เซ็นต์ของมิติภาพต้นฉบับ การครอปเริ่มแรกไม่ลบพิกเซลที่ซ่อนอยู่จากภาพฝัง; มันเพียงเปลี่ยนพื้นที่ที่มองเห็น

ตัวอย่างต่อไปนี้ค้นหา picture frame อย่างปลอดภัยและใช้ค่าครอป:

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

เนื่องจากข้อมูลภาพที่ซ่อนยังคงมีอยู่, สามารถเปลี่ยนค่าครอปภายหลังได้โดยไม่สูญเสียพิกเซลต้นฉบับ หากขนาดไฟล์สำคัญกว่าการย้อนกลับ, พื้นที่ที่ครอปสามารถลบออกได้จริงตามที่อธิบายในส่วนต่อไป

## **ลบข้อมูลภาพที่ครอปแล้ว**

[PictureFillFormat::deletePictureCroppedAreas](https://reference.aspose.com/slides/th/php-java/aspose.slides/picturefillformat/#deletePictureCroppedAreas) จะลบข้อมูลภาพที่อยู่นอกสี่เหลี่ยมครอปปัจจุบันและคืนแหล่งภาพที่ได้ ผลลัพธ์สามารถลดขนาดไฟล์ได้, แต่เป็นการเพิ่มประสิทธิภาพแบบทำลาย: หลังจากบันทึกงานนำเสนอแล้ว พิกเซลที่ลบจะไม่สามารถกู้คืนเพื่อทำการยกเลิกครอปได้

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

เมธอดนี้อาจเพิ่มแหล่งภาพใหม่เข้าสู่งานนำเสนอ หากภาพต้นฉบับยังถูกใช้โดย picture frame อื่น ๆ, เฟรมเหล่านั้นยังคงต้องการแหล่งเดิม, ดังนั้นการลบพื้นที่ครอปไม่ได้จำเป็นต้องลดจำนวนภาพทั้งหมด การครอป WMF หรือ EMF ด้วยเมธอดนี้จะทำให้ผลลัพธ์ที่ครอปเป็น PNG

## **บีบอัดภาพแรสเตอร์**

[PictureFillFormat::compressImage](https://reference.aspose.com/slides/th/php-java/aspose.slides/picturefillformat/#compressImage_boolean_int_) ลดความละเอียดภาพแรสเตอร์สัมพันธ์กับขนาดที่ภาพถูกแสดง นอกจากนี้ยังสามารถลบพื้นที่ที่ครอปได้ในขั้นตอนเดียว เมธอดจะคืนค่า `true` เมื่อภาพถูกปรับขนาดหรือครอปและ `false` เมื่อไม่มีการเปลี่ยนแปลงใด ๆ จำเป็น

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

สามารถส่งค่า DPI บวกที่กำหนดเองแทนค่าที่กำหนดไว้ล่วงหน้าเมื่อจำเป็นต้องมีเป้าหมายเฉพาะ

การบีบอัดมุ่งเน้นที่ภาพแรสเตอร์; เนื้อหา SVG และเมตาไฟล์ไม่ถูกลดลงโดยขั้นตอนบีบอัดนี้ นอกจากนี้จงจำไว้ว่า ความละเอียดที่ต่ำลงและพื้นที่ที่ครอปที่ลบแล้วไม่สามารถกู้คืนจากงานนำเสนอที่ได้ทำการเพิ่มประสิทธิภาพแล้ว ให้เลือกความละเอียดเป้าหมายตามขนาดสูงสุดที่ภาพจะถูกดูหรือส่งออกจริง ๆ แทนการใช้ DPI ต่ำสุดทั่วทั้งไฟล์

## **ตรวจสอบเอฟเฟกต์ภาพ**

เอฟเฟกต์ภาพถูกเก็บบน picture ที่ใช้โดยเฟรม คอลเลคชันการแปลงภาพอาจมีเอฟเฟกต์เช่นการมอดูเลตอัลฟ่าแบบคงที่สำหรับความโปร่งแสงและลูมินานซ์สำหรับความสว่างและคอนทราสต์ ตัวอย่างด้านล่างอ่านเอฟเฟกต์ทั้งสองประเภทจาก picture frame แรกบนสไลด์อย่างปลอดภัย:

```php
use aspose\slides\Presentation;

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
        $imageTransform = $pictureFrame->getPictureFormat()->getPicture()->getImageTransform();
        $effectCount = java_values($imageTransform->size());

        for ($index = 0; $index < $effectCount; $index++) {
            $effect = $imageTransform->get_Item($index);

            if (java_instanceof($effect, new JavaClass("com.aspose.slides.AlphaModulateFixed"))) {
                $transparency = 100 - java_values($effect->getAmount());
                echo "Transparency: " . $transparency . PHP_EOL;
            }

            if (java_instanceof($effect, new JavaClass("com.aspose.slides.Luminance"))) {
                $luminance = $effect->getEffective();
                echo "Brightness: " . java_values($luminance->getBrightness()) . PHP_EOL;
                echo "Contrast: " . java_values($luminance->getContrast()) . PHP_EOL;
            }
        }
    }
} finally {
    $presentation->dispose();
}
```

เอฟเฟกต์เหล่านี้เปลี่ยนวิธีการเรนเดอร์ภาพในเฟรม; พวกมันไม่เขียนทับไบต์ของภาพฝังต้นฉบับ

## **ล็อกเรขาคณิตของ Picture Frame**

การตั้งค่าใน [PictureFrameLock](https://reference.aspose.com/slides/th/php-java/aspose.slides/pictureframelock/) ควบคุมการดำเนินการแก้ไขที่ถูกปิดใช้งานสำหรับ picture frame ตัวอย่างเช่น [setAspectRatioLocked](https://reference.aspose.com/slides/th/php-java/aspose.slides/pictureframelock/setaspectratiolocked/) จะรักษาสัดส่วนของรูปทรงขณะปรับขนาด

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

การล็อกนี้ใช้กับ shape ของ picture frame เท่านั้น ไม่ได้บังคับให้ภาพต้นแบบต้องรีแซมป์หรือเปลี่ยนสัดส่วนอย่างถาวร

## **ปรับค่า StretchOffset**

เมื่อโหมดเติมภาพเป็น stretch, ค่า stretch‑offset บน [PictureFillFormat](https://reference.aspose.com/slides/th/php-java/aspose.slides/picturefillformat/) จะกำหนดสี่เหลี่ยมเติมสัมพันธ์กับกล่องขอบของ picture frame เปอร์เซ็นต์บวกสร้างการเว้นจากขอบ, ส่วนเปอร์เซ็นต์ลบสร้างการขยายออก

สิ่งนี้แตกต่างจากการครอป ค่าครอปเลือกส่วนของภาพต้นฉบับที่มองเห็น, ส่วน stretch offsets เปลี่ยนสี่เหลี่ยมที่ภาพเติมที่มองเห็นจะถูกยืด

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

ใช้ stretch offsets สำหรับการวางตำแหน่งเติม ใช้คุณสมบัติครอปเมื่อเป้าหมายคือซ่อนขอบของภาพต้นฉบับ

## **การจัดเก็บ, ขนาดไฟล์, และการพิจารณาการส่งออก**

ข้อแลกเปลี่ยนหลักจะจัดการได้ง่ายขึ้นเมื่อการจัดเก็บภาพและการจัดรูปแบบ picture‑frame ถูกแยกกัน:

- **Embedded images** ทำให้งานนำเสนอเป็นอิสระและเป็นตัวเลือกที่เชื่อถือได้ที่สุดสำหรับการแชร์และการเรนเดอร์บนเซิร์ฟเวอร์, แต่ภาพแรสเตอร์ขนาดใหญ่จะทำให้ขนาด PPTX และการใช้หน่วยความจำเพิ่มขึ้น
- **Linked images** สามารถทำให้แพ็คเกจเล็กลง, แต่การนำเสนอขึ้นอยู่กับไฟล์ภายนอกที่ต้องคงอยู่ที่เส้นทางหรือสถานที่ที่จัดเก็บไว้
- **Cropping** เริ่มต้นเป็นแบบไม่ทำลาย; พิกเซลที่ซ่อนยังคงฝังอยู่จนกว่าจะลบพื้นที่ที่ครอปอย่างชัดเจนหรือถูกลบระหว่างการบีบอัด
- **Compression** สามารถลดขนาดไฟล์ได้อย่างมากสำหรับภาพแรสเตอร์ที่ใหญ่เกินไป, แต่จะสูญเสียความละเอียดของแหล่งต้น. ควรใช้หลังจากรู้ขนาดบนสไลด์ที่ต้องการแล้ว
- **SVG images** ควรคงเป็น SVG เมื่อการรักษาเวกเตอร์เป็นเรื่องสำคัญ. สกัด SVG ฝังโดยตรงเมื่อต้องการทรัพยากรเวกเตอร์นั้นเอง. การส่งออกสไลด์เป็นแรสเตอร์จะเปลี่ยนสไลด์ที่เรนเดอร์เป็นพิกเซลเสมอ
- **Repeated images** ควรใช้แหล่งข้อมูล [PPImage](https://reference.aspose.com/slides/th/php-java/aspose.slides/ppimage/) ที่มีอยู่แทนการโหลดไฟล์เดียวกันหลายครั้งในเวิร์กโฟลว์ของงานนำเสนอ

สำหรับงานนำเสนอขนาดใหญ่ การเพิ่มประสิทธิภาพภาพมักจะได้ผลดีที่สุดเมื่อทำแบบเลือกสรร: เก็บโลโก้และไดอะแกรมเป็นเนื้อหาเวกเตอร์, บีบอัดภาพถ่ายตามขนาดการแสดงจริง, ลบพิกเซลที่ครอปเมื่อไม่ต้องการการแก้ไขต่อไป, และหลีกเลี่ยงลิงก์ภายนอก เว้นแต่การจัดการการพึ่งพาจะเป็นส่วนหนึ่งของการออกแบบการปรับใช้

## **FAQ**

**ความแตกต่างระหว่าง picture frame กับแหล่งข้อมูลภาพคืออะไร?**

[PPImage](https://reference.aspose.com/slides/th/php-java/aspose.slides/ppimage/) แทนแหล่งข้อมูลภาพที่เชื่อมโยงกับงานนำเสนอ ส่วน [PictureFrame](https://reference.aspose.com/slides/th/php-java/aspose.slides/pictureframe/) คือรูปทรงบนสไลด์ที่แสดงภาพและเก็บเรขาคณิตระดับเฟรมและการจัดรูปแบบ เช่น ขนาด, การหมุน, ค่าครอป, เอฟเฟกต์, และการล็อก

**ควรฝังหรือเชื่อมโยงภาพ?**

ฝังภาพเมื่องานนำเสนอจำเป็นต้องพกพา, จัดเก็บ, หรือเรนเดอร์โดยไม่ต้องเข้าถึงแหล่งภายนอก. เชื่อมโยงภาพเฉพาะเมื่อต้องการเก็บไฟล์ภาพแยกจาก PPTX อย่างตั้งใจและตำแหน่งภายนอกสามารถจัดการได้อย่างเชื่อถือได้

**การครอปลดขนาดไฟล์ PPTX หรือไม่?**

ไม่โดยตรง การตั้งค่าครอปทั่วไปซ่อนส่วนของภาพต้นฉบับแต่ยังคงเก็บพิกเซลไว้ ใช้ [PictureFillFormat::deletePictureCroppedAreas](https://reference.aspose.com/slides/th/php-java/aspose.slides/picturefillformat/#deletePictureCroppedAreas) หรือการบีบอัดภาพพร้อมการลบพื้นที่ที่ครอปเมื่อพิกเซลเหล่านั้นสามารถลบทิ้งได้อย่างถาวร

**สามารถกู้คืนคุณภาพภาพหลังการบีบอัดได้หรือไม่?**

ไม่ได้ การบีบอัดอาจลดความละเอียดแรสเตอร์ที่จัดเก็บและการลบพื้นที่ที่ครอปจะทิ้งข้อมูลภาพออกไป เก็บภาพต้นฉบับนอกงานนำเสนอหากอาจต้องการแก้ไขความละเอียดสูงในภายหลัง

**ควรจัดการกับภาพ SVG อย่างไร?**

เก็บเนื้อหา SVG เป็น SVG เมื่อความแม่นยำของเวกเตอร์สำคัญ. แหล่ง [SvgImage](https://reference.aspose.com/slides/th/php-java/aspose.slides/svgimage/) ที่ฝังสามารถสกัดได้โดยตรง. การเรนเดอร์สไลด์เป็นรูปแบบแรสเตอร์เช่น PNG หรือ JPEG จะทำให้ SVG ถูกแปลงเป็นพิกเซล

**จะหลีกเลี่ยงการแคสต์ที่ไม่ปลอดภัยเมื่ออ่านสไลด์ที่มีอยู่ได้อย่างไร?**

ตรวจสอบประเภทของ shape ก่อนใช้สมาชิกที่เฉพาะกับ picture‑frame การตรวจสอบ `java_instanceof` กับ [PictureFrame](https://reference.aspose.com/slides/th/php-java/aspose.slides/pictureframe/) จะช่วยป้องกันการแคสต์ที่ไม่ถูกต้องและทำให้โค้ดจัดการกับสไลด์ที่ไม่มี picture frame ได้อย่างเหมาะสม