---
title: เพิ่มประสิทธิภาพการจัดการรูปภาพในงานนำเสนอด้วย PHP
linktitle: จัดการภาพ
type: docs
weight: 10
url: /th/php-java/image/
keywords:
- เพิ่มรูปภาพ
- เพิ่มรูป
- แทนที่รูปภาพ
- คอลเลกชันรูปภาพ
- กรอบรูป
- รูปภาพเชื่อมโยง
- พื้นหลัง
- เพิ่ม PNG
- เพิ่ม JPG
- เพิ่ม SVG
- SVG เป็นรูปร่าง
- แหล่งทรัพยากร SVG ภายนอก
- PowerPoint
- OpenDocument
- งานนำเสนอ
- PHP
- Aspose.Slides
description: "เรียนรู้วิธีเพิ่ม ใช้งานซ้ำ เชื่อมโยง แทนที่ และจัดการรูปภาพราสเตอร์และ SVG ในงานนำเสนอ PowerPoint และ OpenDocument ด้วย Aspose.Slides สำหรับ PHP ผ่าน Java."
---
## **บทนำ**

Aspose.Slides for PHP via Java มีวิธีการทำงานกับรูปภาพหลายวิธี และแต่ละวิธีมีวัตถุประสงค์ที่แตกต่างกัน คุณสามารถจัดเก็บรูปภาพในงานนำเสนอ แสดงในกรอบรูป ใช้เป็นพื้นหลังสไลด์ เชื่อมโยงไปยังรูปภาพภายนอก แทนที่ทรัพยากรรูปภาพที่ใช้ร่วมกัน หรือแปลงเนื้อหา SVG ให้เป็นรูปร่างที่แก้ไขได้

บทความนี้มุ่งเน้นที่ทรัพยากรรูปภาพและวิธีการใช้ในงานนำเสนอทั้งหมด หากต้องการข้อมูลเกี่ยวกับการครอปรูปภาพ ความโปร่งใส เอฟเฟกต์ การยืดและการจัดรูปแบบอื่น ๆ ที่ใช้กับกรอบรูปแต่ละกรอบ ให้ดูที่ [Picture Frame](/slides/th/php-java/picture-frame/)

## **ทำความเข้าใจโมเดลรูปภาพ**

แนวคิด API ต่อไปนี้เกี่ยวข้องกันอย่างใกล้ชิดแต่ไม่สามารถทดแทนกันได้:

- [presentation image collection](https://reference.aspose.com/slides/th/php-java/aspose.slides/imagecollection/) เก็บทรัพยากรรูปภาพที่ใช้ในงานนำเสนอ ใช้ [ImageCollection::addImage](https://reference.aspose.com/slides/th/php-java/aspose.slides/imagecollection/) เพื่อเพิ่มข้อมูลรูปภาพและรับทรัพยากร [PPImage](https://reference.aspose.com/slides/th/php-java/aspose.slides/ppimage/)
- [picture frame](https://reference.aspose.com/slides/th/php-java/aspose.slides/pictureframe/) คือรูปร่างที่แสดงรูปภาพบนสไลด์ เลย์เอาต์ หรือมาสเตอร์ ใช้ [ShapeCollection::addPictureFrame](https://reference.aspose.com/slides/th/php-java/aspose.slides/shapecollection/addpictureframe/) เพื่อวางทรัพยากรรูปภาพบนสไลด์
- พื้นหลังสไลด์ใช้รูปภาพเป็นส่วนหนึ่งของการเติมสไลด์ แทนที่จะแทนเป็นรูปร่าง ดังนั้นจึงไม่ทำงานเหมือนกรอบรูป
- [PPImage::replaceImage](https://reference.aspose.com/slides/th/php-java/aspose.slides/ppimage/) แทนที่ทรัพยากรรูปภาพ หากหลายองค์ประกอบในงานนำใช้ทรัพยากรนั้น ทั้งหมดจะใช้รูปภาพที่แทนที่
- การแปลง SVG ให้เป็นรูปร่างสร้างรูปร่างสไลด์ที่แก้ไขได้ หลังจากการแปลงเนื้อหาจะไม่ถูกจัดการเป็นรูปภาพเดียวอีกต่อไป

ดังนั้นขั้นตอนการทำงานทั่วไปคือ: เพิ่มข้อมูลรูปภาพลงใน image collection รับ [PPImage](https://reference.aspose.com/slides/th/php-java/aspose.slides/ppimage/) แล้วใช้ทรัพยากรนั้นในกรอบรูปหรือการเติมหลาย ๆ อย่าง

## **เพิ่มภาพแบบฝัง**

เพื่อลงรูปภาพจากไฟล์ในเครื่อง ให้โหลดไฟล์ เพิ่มลงใน image collection และสร้างกรอบรูปที่ใช้ `PPImage` ที่คืนค่า

```php
use aspose\slides\Images;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $image = Images::fromFile("photo.png");
    try {
        $ppImage = $presentation->getImages()->addImage($image);
    } finally {
        if (!java_is_null($image)) {
            $image->dispose();
        }
    }

    $slide = $presentation->getSlides()->get_Item(0);
    $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 20, 20, 320, 180, $ppImage);

    $presentation->save("presentation.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

ภาพที่เพิ่มด้วยวิธีนี้จะฝังอยู่ในงานนำเสนอ ดังนั้นไฟล์ที่ได้จึงไม่ต้องพึ่งพาไฟล์รูปภาพต้นฉบับอีกต่อไป

### **เพิ่มภาพจากเว็บ**

เมื่อรูปภาพพร้อมให้บริการผ่าน HTTP หรือ HTTPS ให้ดาวน์โหลดไบต์ของรูปนั้น เพิ่มลงใน presentation image collection และใช้ทรัพยากรรูปภาพที่คืนค่าในลักษณะเดียวกับรูปภาพในเครื่อง

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $imageUrl = new Java("java.net.URL", "https://example.com/image.png");
    $connection = $imageUrl->openConnection();
    $connection->setConnectTimeout(10000);
    $connection->setReadTimeout(10000);

    $inputStream = $connection->getInputStream();
    $outputStream = new Java("java.io.ByteArrayOutputStream");
    $Array = new JavaClass("java.lang.reflect.Array");
    $Byte = (new JavaClass("java.lang.Byte"))->TYPE;

    try {
        $buffer = $Array->newInstance($Byte, 8192);
        $bufferLength = $Array->getLength($buffer);

        while (($bytesRead = java_values($inputStream->read($buffer, 0, $bufferLength))) != -1) {
            $outputStream->write($buffer, 0, $bytesRead);
        }

        $ppImage = $presentation->getImages()->addImage($outputStream->toByteArray());
        $slide = $presentation->getSlides()->get_Item(0);
        $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 20, 20, 320, 180, $ppImage);
    } finally {
        if (!java_is_null($inputStream)) {
            $inputStream->close();
        }
        $outputStream->close();
    }

    $presentation->save("presentation-from-web.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

ในแอปพลิเคชันที่ทำงานต่อเนื่อง ควรใช้ HTTP client หรือกลยุทธ์การจัดการการเชื่อมต่อที่เหมาะสมกับแอปพลิเคชันแทนการสร้างโครงสร้างเครือข่ายที่ไม่จำเป็นซ้ำ ๆ ตรวจสอบ URL ไกล้เคียง ขนาดการตอบกลับ และชนิดของเนื้อหาเมื่อแหล่งที่มานั้นไม่น่าเชื่อถือ

## **ใช้ภาพซ้ำหลายสไลด์**

หากต้องการใช้รูปภาพเดียวกันหลายครั้ง ให้เพิ่มรูปนั้นในงานนำเสนอเพียงครั้งเดียว แล้วนำ [PPImage](https://reference.aspose.com/slides/th/php-java/aspose.slides/ppimage/) ที่ได้กลับมาใช้เมื่อต้องสร้างกรอบรูปเพิ่มเติม วิธีนี้จะช่วยหลีกเลี่ยงการโหลดข้อมูลต้นทางซ้ำ ๆ และทำให้ความสัมพันธ์ระหว่างทรัพยากรรูปภาพที่ใช้ร่วมกับการใช้งานต่าง ๆ ชัดเจน

สำหรับกราฟิกที่ควรปรากฏอัตโนมัติกับหลายสไลด์ เช่น โลโก้บริษัท ให้พิจารณาวางกรอบรูปบน [slide master](/slides/th/php-java/slide-master/) หรือเลย์เอาต์แทนการเพิ่มรูปร่างเทียบเท่าในทุกสไลด์

## **ใช้ภาพเป็นพื้นหลังสไลด์**

รูปภาพพื้นหลังจะถูกกำหนดให้กับการเติมสไลด์ ไม่ได้ถูกเพิ่มเป็นรูปร่างแบบกรอบรูป นี่เป็นประโยชน์เมื่อต้องการให้รูปภาพครอบพื้นหลังสไลด์และไม่ต้องการให้จัดการเป็นอ็อบเจ็กต์สไลด์ปกติ

```php
use aspose\slides\BackgroundType;
use aspose\slides\FillType;
use aspose\slides\Images;
use aspose\slides\PictureFillMode;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $image = Images::fromFile("background.jpg");
    try {
        $ppImage = $presentation->getImages()->addImage($image);
    } finally {
        if (!java_is_null($image)) {
            $image->dispose();
        }
    }

    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Picture);
    $slide->getBackground()->getFillFormat()->getPictureFillFormat()->setPictureFillMode(PictureFillMode::Stretch);
    $slide->getBackground()->getFillFormat()->getPictureFillFormat()->getPicture()->setImage($ppImage);

    $presentation->save("background-image.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

สำหรับตัวเลือกพื้นหลังเพิ่มเติม รวมถึงพื้นหลังมาสเตอร์และเลย์เอาต์ ให้ดูที่ [Presentation Background](/slides/th/php-java/presentation-background/)

## **ภาพฝังและภาพเชื่อมโยง**

ภาพฝังและภาพเชื่อมโยงมีข้อดีข้อเสียด้านการพกพาและขนาดไฟล์ที่แตกต่างกัน:

- **ภาพฝัง:** ข้อมูลรูปภาพถูกเก็บไว้ภายในงานนำเสนอ งานนำเสนอจึงเป็นไฟล์ที่ทำงานได้ด้วยตัวเอง แต่ไฟล์จะมีขนาดรวมข้อมูลรูปภาพ
- **ภาพเชื่อมโยง:** งานนำเสนอเก็บพาธหรือ URL ไปยังรูปภาพภายนอก สามารถลดขนาดไฟล์งานนำเสนอได้ แต่ต้องแน่ใจว่าทรัพยากรภายนอกยังคงเข้าถึงได้เมื่อเปิดหรือเรนเดอร์งานนำเสนอ

สามารถสร้างรูปภาพเชื่อมโยงได้โดยกำหนดพาธหรือ URL ภายนอกผ่าน [Picture::setLinkPathLong](https://reference.aspose.com/slides/th/php-java/aspose.slides/picture/) แทนการฝังข้อมูลรูปภาพ

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $pictureFrame = $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 20, 20, 320, 180, null);
    $pictureFrame->getPictureFormat()->getPicture()->setLinkPathLong("https://example.com/image.png");

    $presentation->save("linked-image.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

ใช้ภาพเชื่อมโยงเฉพาะเมื่อสภาพแวดล้อมการปรับใช้สามารถเข้าถึงทรัพยากรภายนอกได้อย่างมั่นคง สำหรับงานนำเสนอที่ต้องทำงานแบบออฟไลน์หรือย้ายระหว่างระบบ ภาพฝังมักจะปลอดภัยกว่า

## **ทำงานกับภาพ SVG**

SVG เป็นรูปแบบเวกเตอร์ จึงเหมาะสำหรับไอคอน แผนภาพ และกราฟิกอื่น ๆ ที่ต้องการขยายโดยไม่สูญเสียรายละเอียดเท่าภาพราสเตอร์ Aspose.Slides รองรับ SVG ทั้งเป็นทรัพยากรรูปภาพและเป็นแหล่งสำหรับรูปร่างสไลด์ที่แก้ไขได้

### **เพิ่ม SVG เป็นภาพ**

สร้าง [SvgImage](https://reference.aspose.com/slides/th/php-java/aspose.slides/svgimage/) เพิ่มลงใน image collection แล้ววางทรัพยากรรูปภาพที่ได้ในกรอบรูป

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\SvgImage;

$presentation = new Presentation();
try {
    $svgContent = file_get_contents("icon.svg");
    $svgImage = new SvgImage($svgContent);

    $ppImage = $presentation->getImages()->addImage($svgImage);
    $slide = $presentation->getSlides()->get_Item(0);
    $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 20, 20, 200, 200, $ppImage);

    $presentation->save("svg-image.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **ไฟล์ SVG พร้อมทรัพยากรภายนอก**

SVG สามารถอ้างอิงรูปภาพ ภาพสไตล์ชีต หรือฟอนต์ภายนอก สำหรับกรณีเหล่านี้ [SvgImage](https://reference.aspose.com/slides/th/php-java/aspose.slides/svgimage/) มีคอนสตรัคเตอร์ที่รับ [ExternalResourceResolver](https://reference.aspose.com/slides/th/php-java/aspose.slides/externalresourceresolver/) และ URI ฐาน ตัวแก้ไขสามารถแมป URI ที่เป็นสัมพัทธ์เป็น URI แบบเต็มที่อนุญาตและคืนค่า stream สำหรับทรัพยากรที่ร้องขอ

ตัวแก้ไขทำให้ทรัพยากรภายนอกพร้อมใช้งานขณะ Aspose.Slides ประมวลผล SVG แต่ไม่ได้เขียนใหม่เป็นเอกสารที่ทำงานได้ด้วยตัวเอง หากต้องการให้ SVG พกพาได้ ควรฝังทรัพยากรที่จำเป็นลงใน SVG เอง เช่น ใช้ `data:` URI สำหรับรูปภาพเชื่อมโยง

เมื่อไฟล์ SVG มาจากแหล่งที่ไม่เชื่อถือ ควรจำกัดสกีม, ที่ตั้งไฟล์, และโฮสต์ที่ตัวแก้ไขสามารถเข้าถึงได้ ตัวแก้ไขเครือข่ายควรกำหนด timeout, ขีดจำกัดขนาดการตอบกลับ, และการตรวจสอบความถูกต้องของเนื้อหา

### **แปลง SVG เป็นรูปแบบที่แก้ไขได้**

Aspose.Slides สามารถแปลง SVG ให้เป็นกลุ่มของรูปร่างสไลด์ที่แก้ไขได้ คล้ายกับคำสั่งใน PowerPoint

![PowerPoint Popup Menu](img_01_01.png)

ใช้ overload ของ [ShapeCollection::addGroupShape](https://reference.aspose.com/slides/th/php-java/aspose.slides/shapecollection/addgroupshape/) ที่รับ [SvgImage](https://reference.aspose.com/slides/th/php-java/aspose.slides/svgimage/) เพื่อทำการแปลง

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\SvgImage;

$presentation = new Presentation();
try {
    $svgContent = file_get_contents("diagram.svg");
    $svgImage = new SvgImage($svgContent);

    $slideSize = $presentation->getSlideSize()->getSize();
    $slide = $presentation->getSlides()->get_Item(0);
    $slide->getShapes()->addGroupShape($svgImage, 0, 0, $slideSize->getWidth(), $slideSize->getHeight());

    $presentation->save("editable-svg-shapes.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

ใช้การแปลง SVG‑to‑shapes เมื่อองค์ประกอบเวกเตอร์แต่ละอันต้องการแก้ไขเป็นรูปร่าง PowerPoint หาก SVG เพียงต้องการแสดง ให้เก็บไว้เป็นภาพก็ง่ายกว่าและหลีกเลี่ยงการสร้างรูปร่างแยกหลาย ๆ รูป

## **แทนที่ทรัพยากรภาพที่มีอยู่**

ใช้ [PPImage::replaceImage](https://reference.aspose.com/slides/th/php-java/aspose.slides/ppimage/) เมื่อต้องการแทนที่ทรัพยากรภาพที่มีอยู่ ซึ่งมีประโยชน์อย่างยิ่งสำหรับกราฟิกที่ใช้ร่วมกัน เช่น โลโก้

```php
use aspose\slides\Images;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("input.pptx");
try {
    $imageToReplace = $presentation->getImages()->get_Item(0);

    $replacementImage = Images::fromFile("new-logo.png");
    try {
        $imageToReplace->replaceImage($replacementImage);
    } finally {
        if (!java_is_null($replacementImage)) {
            $replacementImage->dispose();
        }
    }

    $presentation->save("output.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

หากหลายกรอบรูป, พื้นหลัง, มาสเตอร์ หรือเลย์เอาต์ใช้ทรัพยากรภาพเดียวกัน การแทนที่ทรัพยากรนั้นจะอัปเดตการใช้งานทั้งหมด หากต้องการเปลี่ยนเพียงกรอบรูปเดียว ให้กำหนดภาพอื่นให้กับกรอบรูปนั้นแทนการแทนที่ทรัพยากรที่ใช้ร่วม

`PPImage::replaceImage` ยังมี overload ที่รับอาร์เรย์ไบต์หรือ [PPImage](https://reference.aspose.com/slides/th/php-java/aspose.slides/ppimage/) อื่น

## **แนวทางการจัดการภาพเชิงปฏิบัติ**

### **ควบคุมขนาดงานนำเสนอ**

ภาพราสเตอร์ขนาดใหญ่สามารถทำให้งานนำเสนอใหญ่มากเกินจำเป็น ใช้ภาพต้นฉบับที่มีขนาดเหมาะสมกับการแสดงที่ต้องการ, ใช้ทรัพยากรภาพที่ใช้ร่วมกันเมื่อเป็นไปได้, และหลีกเลี่ยงการฝังสำเนาซ้ำของกราฟิกความละเอียดเต็ม

สำหรับภาพราสเตอร์ที่ได้วางไว้ในกรอบรูปแล้ว [PictureFillFormat::compressImage](https://reference.aspose.com/slides/th/php-java/aspose.slides/picturefillformat/) สามารถลดข้อมูลภาพตามความละเอียดและการตั้งค่าการครอปที่เลือกได้ นี่คือการประมวลผลกรอบรูป ไม่ใช่การจัดการ image‑collection ดังนั้นดูที่ [Picture Frame](/slides/th/php-java/picture-frame/) สำหรับการจัดรูปแบบที่เกี่ยวข้อง

### **เลือกระหว่างเนื้อหาแบบฝังและแบบเชื่อมโยง**

การฝังทำให้งานนำพาพกพาได้ เพราะข้อมูลรูปภาพทั้งหมดเดินทางไปกับไฟล์ การเชื่อมโยงอาจลดขนาดไฟล์ได้ แต่จะสร้างการพึ่งพาภายนอก ใช้ลิงก์เฉพาะเมื่อการพึ่งพานั้นยอมรับได้และเสถียร

### **ใช้แบรนด์ร่วมกัน**

สำหรับโลโก้, ลายน้ำ หรือกราฟิกตกแต่งที่ซ้ำกัน ให้ใช้ทรัพยากรรูปภาพเดียวและใช้งานซ้ำ หากกราฟิกเป็นส่วนของการออกแบบงานนำเสนอ ไม่ใช่เนื้อหาสไลด์ ให้วางไว้บนมาสเตอร์หรือเลย์เอาต์เพื่อให้สไลด์ที่เกี่ยวข้องสืบทอดมา

### **ทำให้ทรัพยากร SVG พกพาได้**

SVG ที่เป็นอิสระจะย้ายและเรนเดอร์ได้สม่ำเสมอกว่าที่พึ่งพาไฟล์หรือทรัพยากรเครือข่ายภายนอก เมื่อเป็นไปได้ให้ฝังทรัพยากรที่จำเป็นก่อนนำเข้า SVG แปลง SVG เป็นรูปร่างเฉพาะเมื่อต้องการแก้ไของค์ประกอบเวกเตอร์แต่ละอัน

### **ใช้ API ภาพแบบสมัยใหม่ข้ามแพลตฟอร์ม**

สำหรับโค้ด PHP via Java ใหม่ ให้ใช้ API Aspose.Slides [IImage](https://reference.aspose.com/slides/th/php-java/aspose.slides/iimage/) และ [Images](https://reference.aspose.com/slides/th/php-java/aspose.slides/images/) แทนการใช้ API สาธารณะรุ่นเก่าที่อิง `java.awt.image.BufferedImage` ดูที่ [Modern API](/slides/th/php-java/modern-api/) สำหรับคำแนะนำการย้าย

WMF และ EMF ต้องพิจารณาเป็นพิเศษ เมื่อรูปแบบเหล่านี้ถูกส่งผ่าน [IImage](https://reference.aspose.com/slides/th/php-java/aspose.slides/iimage/) [ImageCollection::addImage](https://reference.aspose.com/slides/th/php-java/aspose.slides/imagecollection/) จะทำการแปลงเมตาฟายล์เป็นภาพ PNG แบบราสเตอร์ก่อนแทรก หากต้องการรักษาข้อมูลเมตาฟายล์ ควรใช้ overload ของ [ImageCollection::addImage](https://reference.aspose.com/slides/th/php-java/aspose.slides/imagecollection/) ที่รับ stream การสร้างเนื้อหา EMF จากสเปรดชีตหรือผลิตภัณฑ์อื่นเป็นกระบวนการรวมกันแยกต่างหากและอยู่นอกขอบเขตของบทความนี้

## **คำถามที่พบบ่อย**

**ความแตกต่างระหว่าง image collection กับ picture frame คืออะไร?**

image collection เก็บทรัพยากรรูปภาพที่นำกลับมาใช้ใหม่ได้ picture frame คือรูปร่างบนสไลด์ที่แสดงหนึ่งในทรัพยากรเหล่านั้นและให้การจัดรูปแบบเฉพาะรูปภาพเช่นการครอปและเอฟเฟกต์

**วิธีที่ดีที่สุดในการแทนที่โลโก้เดียวกันทุกที่คืออะไร?**

หากโลโก้ถูกแชร์เป็นทรัพยากรรูปภาพเดียว ให้แทนที่ทรัพยากรนั้นด้วย [PPImage::replaceImage](https://reference.aspose.com/slides/th/php-java/aspose.slides/ppimage/) สำหรับการสร้างแบรนด์ทั่วทั้งงานนำเสนอ การวางโลโก้บนมาสเตอร์หรือเลย์เอาต์ก็สามารถลดเนื้อหาสไลด์ที่ซ้ำกันได้

**ทำไมภาพเชื่อมโยงถึงหายไปบนคอมพิวเตอร์เครื่องอื่น?**

ภาพเชื่อมโยงพึ่งพาไฟล์หรือ URL ภายนอก หากไม่สามารถเข้าถึงทรัพยากรนั้นจากคอมพิวเตอร์เครื่องอื่น ภาพเชื่อมโยงอาจไม่แสดงได้ ให้นำเข้าภาพเมื่อจำเป็นต้องให้งานนำเสนอเป็นไฟล์เดียว

**สามารถแก้ไข SVG ที่แทรกเข้าไปเป็นรูปร่าง PowerPoint ได้หรือไม่?**

ได้ สามารถแปลง SVG ด้วย [ShapeCollection::addGroupShape](https://reference.aspose.com/slides/th/php-java/aspose.slides/shapecollection/addgroupshape/) ผลลัพธ์ที่ได้เป็นกลุ่มของรูปร่างสไลด์ที่แก้ไขได้ แทนการเป็นรูปภาพ SVG เดียว

**ทำอย่างไรให้งานนำเสนอที่มีรูปภาพหลายรูปมีขนาดเล็กลง?**

ใช้ทรัพยากรรูปภาพที่ใช้ร่วมกัน, หลีกเลี่ยงแหล่งราสเตอร์ที่ใหญ่เกินไป, บีบอัดรูปภาพราสเตอร์ที่เหมาะสมเมื่อจำเป็น, เก็บแบรนด์ที่ซ้ำกันบนมาสเตอร์หรือเลย์เอาต์, และใช้ภาพเชื่อมโยงเฉพาะเมื่อการพึ่งพาภายนอกยอมรับได้