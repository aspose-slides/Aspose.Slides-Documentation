---
title: จัดการ Placeholder ของการนำเสนอใน PHP
linktitle: จัดการ Placeholder
type: docs
weight: 10
url: /th/php-java/manage-placeholder/
keywords:
- ตัวจัดเก็บตำแหน่ง
- ตัวจัดเก็บตำแหน่งข้อความ
- ตัวจัดเก็บตำแหน่งรูปภาพ
- ตัวจัดเก็บตำแหน่งแผนภูมิ
- ตัวจัดเก็บตำแหน่งเนื้อหา
- ข้อความแนะนำ
- PowerPoint
- งานนำเสนอ
- PHP
- Aspose.Slides
description: "เรียนรู้วิธีตรวจสอบและแก้ไข placeholder ของข้อความ, รูปภาพ, แผนภูมิ, และเนื้อหา พร้อมทำความเข้าใจการสืบทอด placeholder ด้วย Aspose.Slides สำหรับ PHP ผ่าน Java."
---
## **ภาพรวม**

Placeholder คือรูปทรงที่สงวนตำแหน่งสำหรับประเภทเนื้อหาเฉพาะในแม่แบบการนำเสนอ ตัวอย่างทั่วไปได้แก่ placeholder ของชื่อเรื่อง, เนื้อหา, รูปภาพ, แผนภูมิ, และ placeholder เนื้อหาทั่วไป ต่างจากรูปทรงธรรมดา placeholder สามารถสืบทอดตำแหน่ง, ขนาด, การจัดรูปแบบ และการตั้งค่าอื่น ๆ จากสไลด์เลย์เอาต์หรือสไลด์มาสเตอร์ได้

Aspose.Slides เปิดเผยข้อมูล placeholder ผ่านเมธอด [Shape::getPlaceholder](https://reference.aspose.com/slides/th/php-java/aspose.slides/shape/getplaceholder/) เมธอดนี้จะคืนค่าเป็นอ็อบเจ็กต์ [Placeholder](https://reference.aspose.com/slides/th/php-java/aspose.slides/placeholder/) หรือ `null` สำหรับรูปทรงปกติ ใช้ [Placeholder::getType](https://reference.aspose.com/slides/th/php-java/aspose.slides/placeholder/gettype/) เพื่อกำหนดว่าภายใน placeholder ควรมีเนื้อหาอะไร

ประเภทของคลาสรูปทรงยังคงมีความสำคัญหลังจากที่คุณทราบประเภทของ placeholder:
- Placeholder ของข้อความ, รูปภาพ, แผนภูมิ หรือเนื้อหาที่ว่างเปล่ามักจะแสดงเป็น [AutoShape](https://reference.aspose.com/slides/th/php-java/aspose.slides/autoshape/).
- Placeholder รูปภาพที่มีเนื้อหาแล้วสามารถแสดงเป็น [PictureFrame](https://reference.aspose.com/slides/th/php-java/aspose.slides/pictureframe/).
- Placeholder แผนภูมิที่มีเนื้อหาแล้วสามารถแสดงเป็น [Chart](https://reference.aspose.com/slides/th/php-java/aspose.slides/chart/).
- Placeholder เนื้อหาอาจประกอบด้วยหลายประเภทของเนื้อหา ตรวจสอบทั้ง [Placeholder::getType](https://reference.aspose.com/slides/th/php-java/aspose.slides/placeholder/gettype/) และคลาสรูปทรงขณะทำงานแทนการสันนิษฐานว่า placeholder ทุกตัวเป็น [AutoShape](https://reference.aspose.com/slides/th/php-java/aspose.slides/autoshape/).

{{% alert color="warning" title="Warning" %}}
[Placeholder::getType](https://reference.aspose.com/slides/th/php-java/aspose.slides/placeholder/gettype/) อธิบายบทบาทของ placeholder; ไม่รับประกันว่ารูปทรงจะเป็นคลาสขณะทำงานจริง ใช้วิธีตรวจสอบประเภทเสมอก่อนเข้าถึงสมาชิกที่เป็นข้อความ, รูปภาพ, แผนภูมิ, ตาราง หรือสื่อ
{{% /alert %}}

## **ทำความเข้าใจการสืบทอด Placeholder**

Placeholder ถูกจัดเรียงในลำดับชั้น:
1. สไลด์มาสเตอร์กำหนดสไตล์ที่นำกลับมาใช้ได้และในบางกรณีจะมี placeholder ระดับมาสเตอร์
2. สไลด์เลย์เอาต์กำหนดการจัดวางที่ใช้โดยสไลด์ปกติเพียงหนึ่งหรือหลายสไลด์และสามารถสืบทอดจากมาสเตอร์ได้
3. สไลด์ปกติบรรจุ placeholder สำหรับสไลด์นั้นและสามารถสืบทอดจากเลย์เอาต์ของมันได้

เรียกใช้ [Shape::getBasePlaceholder](https://reference.aspose.com/slides/th/php-java/aspose.slides/shape/getbaseplaceholder/) เพื่อย้ายขึ้นหนึ่งระดับในลำดับชั้นนี้ Placeholder ของสไลด์โดยปกติจะคืนค่าเป็น placeholder ของเลย์เอาต์; placeholder ของเลย์เอาต์สามารถคืนค่าเป็น placeholder ของมาสเตอร์ เมธอดจะคืนค่า `null` เมื่อรูปทรงไม่มี base placeholder

ตัวอย่างต่อไปนี้แสดงรายการ placeholder บนสไลด์แรกและรายงาน base placeholder ของพวกมัน:
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

การแก้ไข placeholder บนสไลด์ปกติจะสร้างหรือเปลี่ยนการกำหนดท้องถิ่นสำหรับสไลด์นั้น การแก้ไขเลย์เอ็ตหรือมาสเตอร์ที่เกี่ยวข้องอาจส่งผลต่อสไลด์ทั้งหมดที่ยังคงสืบทอดการตั้งค่านั้น รูปทรงปกติที่เป็นท้องถิ่นไม่มี base placeholder และไม่เริ่มสืบทอดเพียงเพราะอยู่ในพิกัดเดียวกัน

## **เปลี่ยนข้อความใน Placeholder**

Placeholder ของหัวเรื่อง, หัวเรื่องกึ่งกลาง, หัวเรื่องย่อย, เนื้อหาและข้อความโดยทั่วไปรองรับข้อความ ตรวจสอบว่ารูปเป็น [AutoShape](https://reference.aspose.com/slides/th/php-java/aspose.slides/autoshape/) ก่อนใช้เมธอด [getTextFrame](https://reference.aspose.com/slides/th/php-java/aspose.slides/autoshape/gettextframe/) ของมัน

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

รูปแบบนี้หลีกเลี่ยงการพิจารณา placeholder ของรูปภาพ, แผนภูมิ, ตาราง หรือสื่อเป็นอ็อบเจ็กต์ [AutoShape](https://reference.aspose.com/slides/th/php-java/aspose.slides/autoshape/) อีกทั้งยังระบุ placeholder ตามวัตถุประสงค์แทนการพึ่งพาดัชนีรูปทรงที่เปราะบาง

## **กำหนดข้อความ Prompt บนเลย์เอาต์**

Prompt text คือคำแนะนำในขั้นตอนออกแบบที่แสดงใน placeholder ว่าง เช่น *Click to add title* ตั้งข้อความ prompt แบบกำหนดเองบน placeholder ของเลย์เอาต์แทนการพยายามเข้าถึงผ่านคอลเลกชันรูปทรงของสไลด์ปกติ เข้าถึงเลย์เอาต์โดยใช้ [Slide::getLayoutSlide](https://reference.aspose.com/slides/th/php-java/aspose.slides/slide/#getLayoutSlide) และวนลูปผ่านคอลเลกชันที่คืนจาก [BaseSlide::getShapes](https://reference.aspose.com/slides/th/php-java/aspose.slides/baseslide/#getShapes).

ตัวอย่างต่อไปนี้เปลี่ยนข้อความ prompt ของหัวเรื่องและหัวเรื่องย่อยบนเลย์เอาต์ที่ใช้โดยสไลด์แรก:
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

Prompt text ไม่ใช่เนื้อหาของสไลด์ปกติ มันมีไว้สำหรับ placeholder ที่ว่างเปล่าในโปรแกรมแก้ไขเช่น PowerPoint เมื่อผู้ใช้หรือโปรแกรมใส่เนื้อหาจริงแล้ว prompt จะไม่แสดงอีก การเปลี่ยน prompt ยังไม่ได้แทนที่ข้อความที่มีอยู่บนสไลด์ที่ใช้เลย์เอาต์ดังกล่าว

## **อัปเดต Placeholder ของรูปภาพ**

มีสองกรณีที่ต้องจัดการ:
- หาก placeholder ของรูปภาพมีเนื้อหาอยู่แล้วและแสดงเป็น [PictureFrame](https://reference.aspose.com/slides/th/php-java/aspose.slides/pictureframe/), ให้เปลี่ยนรูปภาพโดยใช้ [PictureFillFormat::getPicture](https://reference.aspose.com/slides/th/php-java/aspose.slides/picturefillformat/getpicture/) และ [SlidesPicture::setImage](https://reference.aspose.com/slides/th/php-java/aspose.slides/slidespicture/setimage/).
- หากยังเป็น placeholder ว่าง ให้เพิ่ม picture frame ที่พิกัดของ placeholder ด้วย [ShapeCollection::addPictureFrame](https://reference.aspose.com/slides/th/php-java/aspose.slides/shapecollection/addpictureframe/) แล้วลบ placeholder ว่างออก

ตัวอย่างต่อไปนี้รองรับทั้งสองกรณีและบันทึกการนำเสนอ:
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

การแทนที่ที่สร้างขึ้นสำหรับ placeholder ว่างเป็น picture frame ท้องถิ่น ไม่ใช่ placeholder ใหม่ เนื่องจาก [Shape::getPlaceholder](https://reference.aspose.com/slides/th/php-java/aspose.slides/shape/getplaceholder/) ไม่มีตัวตั้งค่า (setter) มันยังคงตำแหน่งที่สงวนไว้แต่ไม่สืบทอดพฤติกรรมเฉพาะของ placeholder อีกต่อไป หากต้องการรักษาความสัมพันธ์ของ placeholder เป็นสิ่งสำคัญ ให้เตรียมและเติมข้อมูล placeholder ใน PowerPoint ก่อน แล้วอัปเดต [PictureFrame](https://reference.aspose.com/slides/th/php-java/aspose.slides/pictureframe/) ที่ได้ด้วย Aspose.Slides

สำหรับความโปร่งใสของรูปภาพ, การครอป, และเอฟเฟกต์เฉพาะของรูปภาพอื่น ๆ ดูที่ [Manage Picture Frames](/slides/th/php-java/picture-frame/). การดำเนินการเหล่านั้นเป็นของ picture frame หรือ picture fill ไม่ใช่เมทาดาต้า placeholder

## **ทำงานกับ Chart และ Content Placeholder**

Placeholder ของแผนภูมิที่มีเนื้อหาแล้วสามารถแสดงเป็น [Chart](https://reference.aspose.com/slides/th/php-java/aspose.slides/chart/). ตัวอย่างนี้ค้นหาแผนภูมินั้นโดยอาศัยทั้งประเภทของ placeholder และคลาสขณะทำงาน, เปลี่ยนชื่อแผนภูมิ, และบันทึกไฟล์:
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

Content placeholder ทั่วไปมักมีประเภทเป็น [PlaceholderType::Object](https://reference.aspose.com/slides/th/php-java/aspose.slides/placeholdertype/). ใน PowerPoint มันทำหน้าที่เป็นตัวเปิดสำหรับหลายประเภทของเนื้อหา ได้แก่ แผนภูมิ, ตาราง, แผนภาพ, รูปภาพ และสื่อ หลังจากที่ได้ถูกเติมข้อมูลแล้ว ให้ตรวจสอบคลาสรูปทรงจริงเพื่อทราบว่าเก็บอะไรอยู่ เลย์เอาต์ที่กำหนดเฉพาะยังสามารถเปิดเผย [PlaceholderType::Chart](https://reference.aspose.com/slides/th/php-java/aspose.slides/placeholdertype/), [PlaceholderType::Table](https://reference.aspose.com/slides/th/php-java/aspose.slides/placeholdertype/), [PlaceholderType::Picture](https://reference.aspose.com/slides/th/php-java/aspose.slides/placeholdertype/), [PlaceholderType::Media](https://reference.aspose.com/slides/th/php-java/aspose.slides/placeholdertype/), หรือ [PlaceholderType::Diagram](https://reference.aspose.com/slides/th/php-java/aspose.slides/placeholdertype/).

Aspose.Slides ไม่ได้แปลง placeholder ของ [AutoShape](https://reference.aspose.com/slides/th/php-java/aspose.slides/autoshape/) ที่ว่างเปล่าให้เป็น [Chart](https://reference.aspose.com/slides/th/php-java/aspose.slides/chart/) เพียงแค่เปลี่ยน [Placeholder::getType](https://reference.aspose.com/slides/th/php-java/aspose.slides/placeholder/gettype/); ไม่สามารถเปลี่ยนประเภทได้ผ่านคลาส เพื่อเติมแผนภูมิหรือพื้นที่เนื้อหาที่ว่างเปล่าโปรแกรมmatically ให้เพิ่มอ็อบเจ็กต์ที่ต้องการที่พิกัดของ placeholder แล้วลบ placeholder ว่างออก ตัวอย่างต่อไปนี้ทำเช่นนั้นสำหรับแผนภูมิ:
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

แผนภูมิที่เพิ่มจะเป็นแผนภูมิท้องถิ่นทั่วไป มันครอบคลุมพื้นที่ของ placeholder แต่ไม่ได้สืบทอดจาก placeholder ของเลย์เอตต์ ใช้บทความการจัดการแผนภูมิที่เฉพาะเจาะจง [chart management articles](/slides/th/php-java/powerpoint-charts/) เมื่อคุณต้องการแทนที่ประเภท, ซีรีส์, หรือข้อมูล workbook ของแผนภูมิ

## **ตัวอย่างเต็ม: อัปเดตข้อความหรือเนื้อหารูปภาพ**

ตัวอย่างครบวงจรต่อไปนี้เปิดเทมเพลต, ค้นหาในสไลด์แรกสำหรับ placeholder ของหัวเรื่องหรือรูปภาพ, ตรวจสอบประเภทของ placeholder และรูปทรง, อัปเดตเนื้อหาที่เหมาะสม, แล้วบันทึกผลลัพธ์ ตัวอย่างนี้ตั้งใจหลีกเลี่ยงการสันนิษฐานว่ามีดัชนีรูปทรงหรือการพิจารณา placeholder ทั้งหมดเป็นคลาสเดียวกัน:
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

## **FAQ**

**Base placeholder คืออะไร?**

Base placeholder คือรูปทรงที่สอดคล้องกันบนเลย์เออต์หรือมาสเตอร์ที่ placeholder อื่นสืบทอดมา ใช้ [Shape::getBasePlaceholder](https://reference.aspose.com/slides/th/php-java/aspose.slides/shape/getbaseplaceholder/) เพื่อดึงค่า รูปทรงท้องถิ่นทั่วไปจะคืนค่า `null` เนื่องจากไม่ได้เป็นส่วนของลำดับชั้น placeholder

**ฉันสามารถเปลี่ยนหัวเรื่องทั้งหมดของสไลด์โดยแก้ไข layout placeholder ได้หรือไม่?**

คุณสามารถเปลี่ยนการจัดรูปแบบที่สืบทอดหรือข้อความ prompt ผ่านเลย์เออต์ได้ แต่เนื้อหาหัวเรื่องที่มีอยู่แล้วจะถูกเก็บไว้บนสไลด์ปกติ หากต้องการแทนที่ข้อความหัวเรื่องจริง ๆ ทั่วทั้งงานนำเสนอ ให้วนลูปผ่านสไลด์ทั้งหมดและอัปเดตแต่ละ title placeholder

**ฉันจะจัดการ placeholder ของวันที่, เลขสไลด์, ส่วนหัวและส่วนท้ายอย่างไร?**

ใช้ตัวจัดการส่วนหัวและส่วนท้ายในสไลด์, เลย์เอาต์, มาสเตอร์, โน้ต หรือชุดเอกสารที่เหมาะสม ดูตัวอย่างเต็มได้ที่ [Manage Presentation Header and Footer](/slides/th/php-java/presentation-header-and-footer/)