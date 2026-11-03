---
title: จัดการ Placeholder ใน PHP
linktitle: จัดการ Placeholder
type: docs
weight: 10
url: /th/php-java/manage-placeholder/
keywords:
- ตัวจองตำแหน่ง
- ตัวจองตำแหน่งข้อความ
- ตัวจองตำแหน่งรูปภาพ
- ตัวจองตำแหน่งแผนภูมิ
- ตัวจองตำแหน่งเนื้อหา
- ข้อความคำแนะนำ
- PowerPoint
- การนำเสนอ
- PHP
- Aspose.Slides
description: "เรียนรู้วิธีตรวจสอบและแก้ไข placeholder ของข้อความ, รูปภาพ, แผนภูมิและเนื้อหา รวมถึงทำความเข้าใจการสืบทอด placeholder ด้วย Aspose.Slides สำหรับ PHP ผ่าน Java."
---
## **ภาพรวม**

Placeholder คือรูปทรงที่สงวนตำแหน่งสำหรับประเภทเนื้อหาเฉพาะในเทมเพลตการนำเสนอ ตัวอย่างทั่วไปได้แก่ placeholder ของหัวเรื่อง, เนื้อหา, รูปภาพ, แผนภูมิและ placeholder เนื้อหาทั่วไป ไม่เหมือนรูปทรงทั่วไป placeholder สามารถสืบทอดตำแหน่ง, ขนาด, การจัดรูปแบบและการตั้งค่าอื่น ๆ จากสไลด์เลเอาท์หรือสไลด์มาสเตอร์ได้

Aspose.Slides เปิดเผยข้อมูล placeholder ผ่านเมธอด [Shape::getPlaceholder](https://reference.aspose.com/slides/php-java/aspose.slides/shape/getplaceholder/) เมธอดนี้จะคืนค่าอ็อบเจ็กต์ [Placeholder](https://reference.aspose.com/slides/php-java/aspose.slides/placeholder/) หรือ `null` สำหรับรูปทรงปกติ ใช้ [Placeholder::getType](https://reference.aspose.com/slides/php-java/aspose.slides/placeholder/gettype/) เพื่อกำหนดว่ placeholder มีจุดประสงค์เพื่อบรรจุอะไร

คลาสของรูปทรงยังคงสำคัญหลังจากคุณทราบประเภทของ placeholder:

- Placeholder ของข้อความ, รูปภาพ, แผนภูมิหรือเนื้อหาเปล่ามักจะแสดงเป็น [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/).
- Placeholder รูปภาพที่มีเนื้อหาแล้วสามารถแสดงเป็น [PictureFrame](https://reference.aspose.com/slides/php-java/aspose.slides/pictureframe/).
- Placeholder แผนภูมิที่มีเนื้อหาแล้วสามารถแสดงเป็น [Chart](https://reference.aspose.com/slides/php-java/aspose.slides/chart/).
- Placeholder เนื้อหามักจะบรรจุหลายประเภทของเนื้อหา ตรวจสอบทั้ง [Placeholder::getType](https://reference.aspose.com/slides/php-java/aspose.slides/placeholder/gettype/) และคลาสของรูปทรงในช่วงเวลารันไทม์แทนการสมมติว่าทุก placeholder เป็น [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/).

{{% alert color="warning" title="Warning" %}}
[Placeholder::getType](https://reference.aspose.com/slides/php-java/aspose.slides/placeholder/gettype/) อธิบายบทบาทของ placeholder; ไม่รับประกันคลาสของรูปทรงในช่วงเวลารันไทม์ ควรตรวจสอบประเภทก่อนเข้าถึงสมาชิกของข้อความ, รูปภาพ, แผนภูมิ, ตาราง หรือสื่อเฉพาะ
{{% /alert %}}

## **ทำความเข้าใจการสืบทอด Placeholder**

Placeholder สร้างเป็นลำดับชั้น:

1. สไลด์มาสเตอร์กำหนดสไตล์ที่สามารถใช้ซ้ำและในบางกรณี placeholder ระดับมาสเตอร์
2. สไลด์เลเอาท์กำหนดการจัดวางที่ใช้โดยสไลด์ปกติโดยหนึ่งหรือหลายสไลด์และสามารถสืบทอดจากมาสเตอร์
3. สไลด์ปกติมี placeholder ของสไลด์นั้นและสามารถสืบทอดจากเลเอาท์ของมัน

เรียก [Shape::getBasePlaceholder](https://reference.aspose.com/slides/php-java/aspose.slides/shape/getbaseplaceholder/) เพื่อย้ายหนึ่งระดับขึ้นในลำดับชั้นนี้ Placeholder ของสไลด์โดยทั่วไปจะคืนค่า placeholder ของเลเอาท์; placeholder ของเลเอาท์สามารถคืนค่า placeholder ของมาสเตอร์ได้ เมธอดจะคืนค่า `null` เมื่อรูปทรงไม่มี base placeholder

ตัวอย่างต่อไปนี้แสดงรายการ placeholder บนสไลด์แรกและระบุ base placeholder ของพวกมัน:

```php
use aspose\slides\Presentation;

$presentation = new Presentation("template.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shapes = $slide->getShapes();
    $shapeCountValue = $shapes->size();
    $shapeCount = java_values($shapeCountValue);

    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $shape = $shapes->get_Item($shapeIndex);
        $placeholder = $shape->getPlaceholder();
        if (java_is_null($placeholder)) {
            continue;
        }

        $placeholderTypeValue = $placeholder->getType();
        $placeholderType = java_values($placeholderTypeValue);
        $shapeClass = $shape->getClass();
        $shapeClassNameValue = $shapeClass->getSimpleName();
        $shapeClassName = java_values($shapeClassNameValue);
        echo "Slide placeholder: " . $placeholderType . "; shape class: " . $shapeClassName . PHP_EOL;

        $layoutPlaceholder = $shape->getBasePlaceholder();
        if (!java_is_null($layoutPlaceholder)) {
            $layoutPlaceholderInfo = $layoutPlaceholder->getPlaceholder();
            if (!java_is_null($layoutPlaceholderInfo)) {
                $layoutPlaceholderTypeValue = $layoutPlaceholderInfo->getType();
                $layoutPlaceholderType = java_values($layoutPlaceholderTypeValue);
                echo "  Layout placeholder: " . $layoutPlaceholderType . PHP_EOL;
            }

            $masterPlaceholder = $layoutPlaceholder->getBasePlaceholder();
            if (!java_is_null($masterPlaceholder)) {
                $masterPlaceholderInfo = $masterPlaceholder->getPlaceholder();
                if (!java_is_null($masterPlaceholderInfo)) {
                    $masterPlaceholderTypeValue = $masterPlaceholderInfo->getType();
                    $masterPlaceholderType = java_values($masterPlaceholderTypeValue);
                    echo "  Master placeholder: " . $masterPlaceholderType . PHP_EOL;
                }
            }
        }
    }
} finally {
    $presentation->dispose();
}
```

การแก้ไข placeholder บนสไลด์ปกติจะสร้างหรือเปลี่ยนการแทนที่แบบท้องถิ่นสำหรับสไลด์นั้น การแก้ไขเลเอาท์หรือมาสเตอร์ที่เกี่ยวข้องอาจส่งผลต่อสไลด์ทั้งหมดที่ยังคงสืบทอดการตั้งคินั้น รูปทรงปกติแบบท้องถิ่นไม่มี base placeholder และจะไม่เริ่มสืบทอดเพียงเพราะอยู่ในพิกัดเดียวกัน

## **ลบสถานะ Placeholder**

เมื่อปรับแต่งเทมเพลต ใช้ [Shape::removePlaceholder](https://reference.aspose.com/slides/php-java/aspose.slides/shape/removeplaceholder/) เพื่อรักษาวัตถุที่มีอยู่ให้เป็นรูปทรงปกติ เมธอด [getPlaceholder](https://reference.aspose.com/slides/php-java/aspose.slides/shape/getplaceholder/) ของมันจะคืนค่า `null` แต่รูปทรงยังคงอยู่ในคอลเลกชันของสไลด์ ตรงกันข้าม [ShapeCollection::remove](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/remove/) จะลบรูปทรงออกจากคอลเลกชันนั้น

ตัวอย่างต่อไปนี้ต้องใช้ `template.pptx` ที่มีอย่างน้อยหนึ่งสไลด์และ placeholder ข้อความที่ไม่ว่างเปล่าบนสไลด์แรก ใช้ placeholder ที่มีการจัดรูปแบบสืบทอดจากเลเอาท์หรือมาสเตอร์เพื่อดูผลของการลบความสัมพันธ์ ตัวอย่างตรวจสอบว่ารูปทรงเดียวกันยังคงอยู่ เรียกเมธอดอีกครั้งบนรูปทรงที่กลายเป็นปกติแล้ว และบันทึกผลลัพธ์

{{% alert color="warning" title="Warning" %}}
การลบสถานะ placeholder ไม่ได้รักษาการตั้งค่าการปรากฏที่สืบทอดโดยอัตโนมัติ ตัวอย่างด้านล่างจึงทิ้งการตั้งค่าเหล่านั้นไว้โดยไม่เปลี่ยนแปลง ดังนั้นผลลัพธ์อาจดูต่างออกไป รูปทรงที่ตำแหน่งและขนาดสืบทอดทั้งหมดอาจมีพิกัดและมิติเป็นศูนย์หลังจากเรียกและกลายเป็นไม่มองเห็นได้แม้ว่าจะยังคงอยู่ในคอลเลกชัน
{{% /alert %}}

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("template.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shapeCount = java_values($slide->getShapes()->size());
    $autoShapeClass = new JavaClass("com.aspose.slides.AutoShape");
    $found = false;

    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $shape = $slide->getShapes()->get_Item($shapeIndex);
        if (!java_instanceof($shape, $autoShapeClass)) {
            continue;
        }

        $placeholder = $shape->getPlaceholder();
        $textFrame = $shape->getTextFrame();
        if (java_is_null($placeholder) || java_is_null($textFrame)) {
            continue;
        }

        $textValue = $textFrame->getText();
        if (java_is_null($textValue)) {
            continue;
        }
        $text = java_values($textValue);
        if ($text === "") {
            continue;
        }

        $shape->removePlaceholder();

        $placeholder = $shape->getPlaceholder();
        $retainedShape = $slide->getShapes()->get_Item($shapeIndex);
        $sameShapeValue = $shape->equals($retainedShape);
        $sameShape = java_values($sameShapeValue);
        $remainingCountValue = $slide->getShapes()->size();
        $remainingCount = java_values($remainingCountValue);
        echo "Placeholder removed: " . (java_is_null($placeholder) ? "true" : "false") . PHP_EOL;
        echo "Same shape retained: " . ($sameShape ? "true" : "false") . PHP_EOL;
        echo "Shape count unchanged: " . ($remainingCount === $shapeCount ? "true" : "false") . PHP_EOL;

        // การเรียกเมธอดบนรูปทรงปกติไม่มีผลใด ๆ.
        $shape->removePlaceholder();
        $found = true;
        break;
    }

    if ($found) {
        $presentation->save("placeholder-status-removed.pptx", SaveFormat::Pptx);
    } else {
        echo "No nonempty text placeholder was found on the first slide." . PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

สำหรับ placeholder ที่ตรงกัน การตรวจสอบทั้งสามจะพิมพ์ `true` ข้อความยังคงอยู่ แต่ตำแหน่ง, ขนาด, การหมุน, ฟอนท์, การจัดแนวย่อหน้า, ระยะขอบของ text‑frame, การยึดแนวตั้ง, การเติมสีและการตั้งค่าเส้นอาจเปลี่ยนแปลงเมื่อความสัมพันธ์ของ placeholder ถูกลบ ตัวอย่างเช่น การจัดรูปแบบหัวเรื่องที่สืบทอดอาจกลับไปใช้การจัดรูปแบบข้อความทั่วไป ดู [Slide Layout](/slides/th/php-java/slide-layout/) เพื่อเรียนรู้เพิ่มเติมเกี่ยวกับเลเอาท์

เพื่อรักษาลักษณะที่ตั้งใจไว้ ให้บันทึกตำแหน่ง, ขนาดและการหมุนที่ได้รับการแก้ไขก่อนเรียกเมธอด และคัดลอกค่าการจัดรูปแบบที่มีประสิทธิผลที่จำเป็นลงในตัวแปรแยกต่างหาก ดึงค่าดังกล่าวผ่าน [PortionFormat::getEffective](https://reference.aspose.com/slides/php-java/aspose.slides/portionformat/geteffective/), [ParagraphFormat::getEffective](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/geteffective/), [TextFrameFormat::getEffective](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/geteffective/), [FillFormat::getEffective](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/geteffective/), และ [LineFormat::getEffective](https://reference.aspose.com/slides/php-java/aspose.slides/lineformat/geteffective/). อย่าอาศัยการเก็บอ็อบเจ็กต์ effective‑format เพียงอย่างเดียว เนื่องจากค่าการจัดรูปแบบข้อความของมันอาจเปลี่ยนแปลงหลังจากความสัมพันธ์ถูกลบ ให้ใช้ค่าที่บันทึกไว้กับรูปทรงปกติหลังจากนั้นอย่างชัดเจนรวมถึงตระกูลฟอนท์, ขนาด, สไตล์, สี, การตั้งค่าย่อหน้า, การตั้งค่า text‑frame, การเติมสีและเส้นที่เทมเพลตของคุณใช้

เรขาคณิตของรูปทรงที่สืบทอดอาจต้องกำหนดอย่างชัดเจนผ่าน [GeometryShape::setShapeType](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#setShapeType) สำหรับ placeholder ข้อความสี่เหลี่ยมรูปแบบนี้หมายถึงการกำหนด [ShapeType::Rectangle](https://reference.aspose.com/slides/php-java/aspose.slides/shapetype/) ; การคืนค่าเพียงการเติมสีและเส้นอาจไม่ทำให้สี่เหลี่ยมที่มองเห็นกลับมาชัดเจน เทมเพลตที่มีเอฟเฟกต์เพิ่มเติมหรือการจัดรูปแบบซับซ้อนยิ่งต้องจัดการการตั้งค่าเหล่านั้นด้วย

## **เปลี่ยนข้อความใน Placeholder**

หัวเรื่อง, centered‑title, subtitle, body และ placeholder ข้อความโดยปกติรองรับข้อความ ตรวจสอบว่ามี [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) ก่อนใช้เมธอด [getTextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/gettextframe/) ของมัน

ตัวอย่างนี้อัปเดต placeholder ของหัวเรื่องแรกบนสไลด์แรกและบันทึกผลลัพธ์:

```php
use aspose\slides\PlaceholderType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("template.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shapes = $slide->getShapes();
    $shapeCountValue = $shapes->size();
    $shapeCount = java_values($shapeCountValue);
    $autoShapeClass = new JavaClass("com.aspose.slides.AutoShape");
    $titleShape = null;

    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $shape = $shapes->get_Item($shapeIndex);
        if (!java_instanceof($shape, $autoShapeClass)) {
            continue;
        }

        $placeholder = $shape->getPlaceholder();
        if (java_is_null($placeholder)) {
            continue;
        }

        $placeholderTypeValue = $placeholder->getType();
        $placeholderType = java_values($placeholderTypeValue);
        if ($placeholderType === PlaceholderType::Title || $placeholderType === PlaceholderType::CenteredTitle) {
            $titleShape = $shape;
            break;
        }
    }

    if ($titleShape === null) {
        throw new RuntimeException("The first slide does not contain a title placeholder.");
    }

    $titleShape->getTextFrame()->setText("Quarterly Business Review");
    $presentation->save("title-placeholder-updated.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

รูปแบบนี้หลีกเลี่ยงการถือว่า picture, chart, table หรือ media placeholder เป็นอ็อบเจ็กต์ [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) อีกทั้งยังระบุ placeholder ตามวัตถุประสงค์แทนที่จะพึ่งพาดัชนีรูปทรงที่เปราะบาง

## **กำหนดข้อความ Prompt บน Layout**

Prompt text คือคำแนะนำในระหว่างการออกแบบที่แสดงใน placeholder ว่าง เช่น *Click to add title* ตั้งข้อความ Prompt ที่กำหนดเองบน placeholder ของเลเอาท์แทนการพยายามเข้าถึงผ่านคอลเลกชันรูปทรงของสไลด์ปกติ เข้าถึงเลเอาท์ผ่าน [Slide::getLayoutSlide](https://reference.aspose.com/slides/php-java/aspose.slides/slide/#getLayoutSlide) แล้ววนลูปผ่านคอลเลกชันที่คืนจาก [BaseSlide::getShapes](https://reference.aspose.com/slides/php-java/aspose.slides/baseslide/#getShapes)

ตัวอย่างต่อไปนี้เปลี่ยน Prompt ของหัวเรื่องและ subtitle บนเลเอาท์ที่ใช้โดยสไลด์แรก:

```php
use aspose\slides\PlaceholderType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("template.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $layoutSlide = $slide->getLayoutSlide();
    $shapes = $layoutSlide->getShapes();
    $shapeCountValue = $shapes->size();
    $shapeCount = java_values($shapeCountValue);
    $autoShapeClass = new JavaClass("com.aspose.slides.AutoShape");

    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $shape = $shapes->get_Item($shapeIndex);
        if (!java_instanceof($shape, $autoShapeClass)) {
            continue;
        }

        $placeholder = $shape->getPlaceholder();
        if (java_is_null($placeholder)) {
            continue;
        }

        $placeholderTypeValue = $placeholder->getType();
        $placeholderType = java_values($placeholderTypeValue);
        if ($placeholderType === PlaceholderType::Title || $placeholderType === PlaceholderType::CenteredTitle) {
            $shape->getTextFrame()->setText("Enter a concise slide title");
        } elseif ($placeholderType === PlaceholderType::Subtitle) {
            $shape->getTextFrame()->setText("Enter a subtitle or reporting period");
        }
    }

    $presentation->save("custom-placeholder-prompts.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Prompt text ไม่ได้เป็นเนื้อหาสไลด์ปกติ มันมีจุดประสงค์สำหรับ placeholder ว่างในแอปพลิเคชันการแก้ไขเช่น PowerPoint เมื่อผู้ใช้หรือโปรแกรมใส่เนื้อหาจริงแล้ว Prompt จะไม่แสดงอีก การเปลี่ยน Prompt ยังไม่ทำให้ข้อความที่มีอยู่บนสไลด์ที่ใช้เลเอาท์นั้นถูกแทนที่

## **อัปเดต Placeholder รูปภาพ**

มีสองกรณีที่ต้องจัดการ:

- หาก placeholder รูปภาพมีเนื้อหาแล้วและแสดงเป็น [PictureFrame](https://reference.aspose.com/slides/php-java/aspose.slides/pictureframe/), ให้แทนที่รูปภาพผ่าน [PictureFillFormat::getPicture](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/getpicture/) และ [Picture::setImage](https://reference.aspose.com/slides/php-java/aspose.slides/picture/#setImage)
- หากยังเป็น placeholder ว่าง ให้เพิ่ม picture frame ที่พิกัดของ placeholder ด้วย [ShapeCollection::addPictureFrame](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/addpictureframe/) แล้วลบ placeholder ว่างออก

ตัวอย่างต่อไปนี้รองรับทั้งสองกรณีและบันทึกการพรีเซนเทชัน:

```php
use aspose\slides\PlaceholderType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation("picture-template.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shapes = $slide->getShapes();
    $shapeCountValue = $shapes->size();
    $shapeCount = java_values($shapeCountValue);
    $pictureFrameClass = new JavaClass("com.aspose.slides.PictureFrame");
    $picturePlaceholder = null;

    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $shape = $shapes->get_Item($shapeIndex);
        $placeholder = $shape->getPlaceholder();
        if (java_is_null($placeholder)) {
            continue;
        }

        $placeholderTypeValue = $placeholder->getType();
        $placeholderType = java_values($placeholderTypeValue);
        if ($placeholderType === PlaceholderType::Picture) {
            $picturePlaceholder = $shape;
            break;
        }
    }

    if ($picturePlaceholder === null) {
        throw new RuntimeException("The first slide does not contain a picture placeholder.");
    }

    $imageData = file_get_contents("replacement.png");
    $image = $presentation->getImages()->addImage($imageData);

    if (java_instanceof($picturePlaceholder, $pictureFrameClass)) {
        $picture = $picturePlaceholder->getPictureFormat()->getPicture();
        $picture->setImage($image);
    } else {
        $x = $picturePlaceholder->getX();
        $y = $picturePlaceholder->getY();
        $width = $picturePlaceholder->getWidth();
        $height = $picturePlaceholder->getHeight();
        $shapes->addPictureFrame(ShapeType::Rectangle, $x, $y, $width, $height, $image);
        $shapes->remove($picturePlaceholder);
    }

    $presentation->save("picture-placeholder-updated.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

การแทนที่ที่สร้างสำหรับ placeholder ว่างเป็น picture frame แบบท้องถิ่น ไม่ใช่ placeholder ใหม่ เนื่องจาก [Shape::getPlaceholder](https://reference.aspose.com/slides/php-java/aspose.slides/shape/getplaceholder/) ไม่ให้ setter มันคงตำแหน่งที่สงวนไว้แต่ไม่สืบทอดพฤติกรรมเฉพาะของ placeholder หากการรักษาความสัมพันธ์ของ placeholder มีความสำคัญ ให้เตรียมและเติม placeholder ใน PowerPoint ก่อน แล้วอัปเดต [PictureFrame](https://reference.aspose.com/slides/php-java/aspose.slides/pictureframe/) ที่ได้ด้วย Aspose.Slides

สำหรับความโปร่งใสของรูป, การครอปและเอฟเฟกต์เฉพาะของรูป ดู [Manage Picture Frames](/slides/th/php-java/picture-frame/) การดำเนินการเหล่านี้เป็นของ picture frame หรือ picture fill ไม่ใช่ของข้อมูลเมตา placeholder

## **ทำงานกับ Chart และ Content Placeholder**

Placeholder แผนภูมิที่มีเนื้อหาแล้วสามารถแสดงเป็น [Chart](https://reference.aspose.com/slides/php-java/aspose.slides/chart/) ตัวอย่างนี้ค้นหาแผนภูมิดังกล่าวโดยใช้ประเภท placeholder และคลาสรันไทม์ เปลี่ยนหัวเรื่องของมันและบันทึกไฟล์:

```php
use aspose\slides\PlaceholderType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("chart-template.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shapes = $slide->getShapes();
    $shapeCountValue = $shapes->size();
    $shapeCount = java_values($shapeCountValue);
    $chartClass = new JavaClass("com.aspose.slides.Chart");
    $placeholderChart = null;

    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $shape = $shapes->get_Item($shapeIndex);
        if (!java_instanceof($shape, $chartClass)) {
            continue;
        }

        $placeholder = $shape->getPlaceholder();
        if (java_is_null($placeholder)) {
            continue;
        }

        $placeholderTypeValue = $placeholder->getType();
        $placeholderType = java_values($placeholderTypeValue);
        if ($placeholderType === PlaceholderType::Chart) {
            $placeholderChart = $shape;
            break;
        }
    }

    if ($placeholderChart === null) {
        throw new RuntimeException("The first slide does not contain a populated chart placeholder.");
    }

    $placeholderChart->setTitle(true);
    $placeholderChart->getChartTitle()->addTextFrameForOverriding("Quarterly Revenue");
    $presentation->save("chart-placeholder-updated.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Placeholder เนื้อหาทั่วไปมักมี [PlaceholderType::Object](https://reference.aspose.com/slides/php-java/aspose.slides/placeholdertype/) ใน PowerPoint ทำหน้าที่เป็นตัวเปิดสำหรับหลายประเภทของเนื้อหา รวมถึงแผนภูมิ, ตาราง, ไดอะแกรม, รูปภาพและสื่อ หลังจากที่มันถูกเติมแล้ว ให้ตรวจสอบคลาสของรูปทรงจริงเพื่อทราบว่ามันบรรจุอะไรเลเอาท์พิเศษอาจเปิดเผย [PlaceholderType::Chart](https://reference.aspose.com/slides/php-java/aspose.slides/placeholdertype/), [PlaceholderType::Table](https://reference.aspose.com/slides/php-java/aspose.slides/placeholdertype/), [PlaceholderType::Picture](https://reference.aspose.com/slides/php-java/aspose.slides/placeholdertype/), [PlaceholderType::Media](https://reference.aspose.com/slides/php-java/aspose.slides/placeholdertype/), หรือ [PlaceholderType::Diagram](https://reference.aspose.com/slides/php-java/aspose.slides/placeholdertype/)

Aspose.Slides ไม่ได้แปลง placeholder [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) ว่างให้เป็น [Chart](https://reference.aspose.com/slides/php-java/aspose.slides/chart/) เพียงโดยการเปลี่ยน [Placeholder::getType](https://reference.aspose.com/slides/php-java/aspose.slides/placeholder/gettype/) ; ประเภทไม่สามารถเปลี่ยนได้ผ่านคลาส เพื่อเติมแผนภูมิหรือพื้นที่เนื้อหาว่างโดยโปรแกรม ให้เพิ่มอ็อบเจ็กต์ที่ต้องการที่พิกัดของ placeholder แล้วลบ placeholder ว่างออก ตัวอย่างต่อไปนี้ทำเช่นนั้นสำหรับแผนภูมิ:

```php
use aspose\slides\ChartType;
use aspose\slides\PlaceholderType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("content-template.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shapes = $slide->getShapes();
    $shapeCountValue = $shapes->size();
    $shapeCount = java_values($shapeCountValue);
    $targetPlaceholder = null;

    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $shape = $shapes->get_Item($shapeIndex);
        $placeholder = $shape->getPlaceholder();
        if (java_is_null($placeholder)) {
            continue;
        }

        $placeholderTypeValue = $placeholder->getType();
        $placeholderType = java_values($placeholderTypeValue);
        if ($placeholderType === PlaceholderType::Chart || $placeholderType === PlaceholderType::Object) {
            $targetPlaceholder = $shape;
            break;
        }
    }

    if ($targetPlaceholder === null) {
        throw new RuntimeException("The first slide does not contain a chart or content placeholder.");
    }

    $x = $targetPlaceholder->getX();
    $y = $targetPlaceholder->getY();
    $width = $targetPlaceholder->getWidth();
    $height = $targetPlaceholder->getHeight();
    $chart = $shapes->addChart(ChartType::ClusteredColumn, $x, $y, $width, $height);
    $chart->setTitle(true);
    $chart->getChartTitle()->addTextFrameForOverriding("Quarterly Revenue");
    $shapes->remove($targetPlaceholder);
    $presentation->save("content-placeholder-replaced-with-chart.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

แผนภูมิที่เพิ่มเข้ามาเป็นแผนภูมิท้องถิ่นปกติ มันครอบคลุมพื้นที่ของ placeholder แต่ไม่สืบทอดจาก placeholder ของเลเอาท์ ใช้บทความการจัดการแผนภูมิเฉพาะ [chart management articles](/slides/th/php-java/powerpoint-charts/) เมื่อคุณต้องการแทนที่หมวดหมู่, ซีรีส์ หรือข้อมูลเวิร์คบุ๊กของมัน

## **ตัวอย่างสมบูรณ์: อัปเดตข้อความหรือเนื้อหาภาพ**

ตัวอย่างต่อไปนี้เป็นแบบ end‑to‑end เปิดเทมเพลต, ค้นหาสไลด์แรกสำหรับ placeholder ของหัวเรื่องหรือรูปภาพ, ตรวจสอบประเภทของ placeholder และรูปทรง, อัปเดตเนื้อหาที่เหมาะสมและบันทึกผลลัพธ์ ตัวอย่างตั้งใจหลีกเลี่ยงการสมมติว่ามีดัชนีรูปทรงหรือถือว่า placeholder ทั้งหมดเป็นคลาสเดียวกัน

```php
use aspose\slides\PlaceholderType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation("template.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shapes = $slide->getShapes();
    $shapeCountValue = $shapes->size();
    $shapeCount = java_values($shapeCountValue);
    $autoShapeClass = new JavaClass("com.aspose.slides.AutoShape");
    $pictureFrameClass = new JavaClass("com.aspose.slides.PictureFrame");
    $updated = false;

    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $shape = $shapes->get_Item($shapeIndex);
        $placeholder = $shape->getPlaceholder();
        if (java_is_null($placeholder)) {
            continue;
        }

        $placeholderTypeValue = $placeholder->getType();
        $placeholderType = java_values($placeholderTypeValue);

        if (($placeholderType === PlaceholderType::Title || $placeholderType === PlaceholderType::CenteredTitle) && java_instanceof($shape, $autoShapeClass)) {
            $shape->getTextFrame()->setText("Quarterly Business Review");
            $updated = true;
            break;
        }

        if ($placeholderType === PlaceholderType::Picture) {
            $imageData = file_get_contents("replacement.png");
            $image = $presentation->getImages()->addImage($imageData);

            if (java_instanceof($shape, $pictureFrameClass)) {
                $picture = $shape->getPictureFormat()->getPicture();
                $picture->setImage($image);
            } else {
                $x = $shape->getX();
                $y = $shape->getY();
                $width = $shape->getWidth();
                $height = $shape->getHeight();
                $shapes->addPictureFrame(ShapeType::Rectangle, $x, $y, $width, $height, $image);
                $shapes->remove($shape);
            }

            $updated = true;
            break;
        }
    }

    if (!$updated) {
        throw new RuntimeException("No supported title or picture placeholder was found on the first slide.");
    }

    $presentation->save("placeholder-content-updated.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **คำถามที่พบบ่อย**

**ฐานของ Placeholder คืออะไร?**

ฐานของ placeholder คือรูปทรงที่สอดคล้องบนเลเอาท์หรือมาสเตอร์ซึ่ง placeholder อื่นสืบทอดจากมัน ใช้ [Shape::getBasePlaceholder](https://reference.aspose.com/slides/php-java/aspose.slides/shape/getbaseplaceholder/) เพื่อดึงคืนรูปทรงนั้น รูปทรงท้องถิ่นปกติจะคืนค่า `null` เพราะมันไม่ได้เป็นส่วนหนึ่งของลำดับชั้น placeholder

**ฉันสามารถเปลี่ยนหัวเรื่องทั้งหมดของสไลด์โดยแก้ไข placeholder ของเลเอาท์ได้ไหม?**

คุณสามารถเปลี่ยนการจัดรูปแบบหรือข้อความ Prompt ที่สืบทอดจากเลเอาท์ได้ แต่เนื้อหาหัวเรื่องที่มีอยู่ถูกเก็บบนสไลด์ปกติ เพื่อแทนที่ข้อความหัวเรื่องจริงในพรีเซนเทชันทั้งหมด คุณต้องวนลูปผ่านสไลด์และอัปเดตแต่ละ placeholder ของหัวเรื่อง

**ฉันจะจัดการ placeholder ของวันที่, หมายเลขสไลด์, ส่วนหัวและส่วนท้ายอย่างไร?**

ใช้ผู้จัดการส่วนหัวและส่วนท้ายที่สโคปของสไลด์, เลเอาท์, มาสเตอร์, โน้ต หรือแฮนด์เอาต์ที่เหมาะสม ดู [Manage Presentation Header and Footer](/slides/th/php-java/presentation-header-and-footer/) เพื่อดูตัวอย่างที่ครบถ้วน