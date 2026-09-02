---
title: จัดการธีมการนำเสนอใน PHP
linktitle: ธีมการนำเสนอ
type: docs
weight: 10
url: /th/php-java/presentation-theme/
keywords:
- ธีม PowerPoint
- ธีมการนำเสนอ
- ธีมสไลด์
- ตั้งค่าธีม
- เปลี่ยนธีม
- จัดการธีม
- ธีมภายนอก
- THMX
- สีธีม
- พาเลตเพิ่มเติม
- ฟอนต์ธีม
- สไตล์ธีม
- เอฟเฟกต์ธีม
- PowerPoint
- OpenDocument
- การนำเสนอ
- PHP
- Aspose.Slides
description: "ควบคุมธีมการนำเสนอหลักใน Aspose.Slides สำหรับ PHP ผ่าน Java เพื่อสร้าง ปรับแต่ง และแปลงไฟล์ PowerPoint ด้วยการสร้างแบรนด์ที่สอดคล้องกัน."
---
## **บทนำ**

ธีมการนำเสนอกำหนดชุดสี, แบบอักษร, สไตล์พื้นหลัง, การเติม, เส้น และเอฟเฟกต์ที่สอดคล้องกัน วัตถุที่รับรู้ธีมจะอ้างอิงถึงคำนิยามที่แชร์เหล่านี้แทนการเก็บคุณสมบัติวิดีโอทุกอย่างเป็นค่าคงที่ ดังนั้นการเปลี่ยนธีมจึงสามารถอัพเดตวัตถุหลายรายการพร้อมกันได้

ใน Aspose.Slides ธีมระดับการนำเสนอสามารถเข้าถึงได้ผ่าน [Presentation.getMasterTheme](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentation/). การนำเสนออาจมีการแทนที่ธีมในระดับที่ต่ำกว่าได้เช่นกัน มาสเตอร์สามารถแทนที่ธีมการนำเสนอผ่าน [MasterThemeManager.getOverrideTheme](https://reference.aspose.com/slides/th/php-java/aspose.slides/masterthememanager/), ส่วนเลย์เอาต์หรือสไลด์เดี่ยวสามารถแทนที่ธีมที่สืบทอดมาผ่าน [BaseOverrideThemeManager.getOverrideTheme](https://reference.aspose.com/slides/th/php-java/aspose.slides/baseoverridethememanager/). ในทางปฏิบัติ ธีมที่มีผลสำหรับสไลด์หนึ่งจะถูกแก้ไขผ่านโซ่การสืบทอดนี้: ธีมการนำเสนอ → การแทนที่ของมาสเตอร์ → การแทนที่ของเลย์เอาต์ → การแทนที่ของสไลด์

![Theme components: colors, fonts, background styles, and effects](theme-constituents.png)

ส่วนต่อไปนี้แสดงการทำงานของธีมที่พบบ่อยที่สุด: ตรวจสอบธีม, เปลี่ยนสีและแบบอักษร, คัดลอกหรือใช้ธีม, อัปเดตสไตล์พื้นหลังและเอฟเฟกต์, และอ่านค่าที่มีผลหลังจากการสืบทอดและการแทนที่ถูกแก้ไขแล้ว

## **ตรวจสอบธีม**

อ็อบเจ็กต์ [MasterTheme](https://reference.aspose.com/slides/th/php-java/aspose.slides/mastertheme/) เปิดเผยสกีมสี, สกีมแบบอักษร, และสกีมรูปแบบของธีมผ่าน [MasterTheme.getColorScheme](https://reference.aspose.com/slides/th/php-java/aspose.slides/mastertheme/), [MasterTheme.getFontScheme](https://reference.aspose.com/slides/th/php-java/aspose.slides/mastertheme/), และ [MasterTheme.getFormatScheme](https://reference.aspose.com/slides/th/php-java/aspose.slides/mastertheme/). การตรวจสอบคอลเลกชันเหล่านี้ก่อนเปลี่ยนเป็นประโยชน์อย่างยิ่งเมื่อการนำเข้ามาจากแหล่งภายนอก เนื่องจากจำนวนและเนื้อหาของรายการสไตล์อาจแตกต่างกัน

ตัวอย่างต่อไปนี้อ่านคุณสมบัติหลักของธีมและรายงานว่ามีสไตล์พื้นหลัง, เติม, เส้น, และเอฟเฟกต์กี่รายการที่ถูกเก็บไว้ในธีม:

```php
use aspose\slides\Presentation;

$presentation = new Presentation("input.pptx");
try {
    $theme = $presentation->getMasterTheme();
    echo "Theme name: " . $theme->getName() . PHP_EOL;
    echo "Accent 1: " . $theme->getColorScheme()->getAccent1()->getColor() . PHP_EOL;
    echo "Major Latin font: " . $theme->getFontScheme()->getMajor()->getLatinFont()->getFontName() . PHP_EOL;
    echo "Minor Latin font: " . $theme->getFontScheme()->getMinor()->getLatinFont()->getFontName() . PHP_EOL;
    echo "Background fill styles: " . java_values($theme->getFormatScheme()->getBackgroundFillStyles()->size()) . PHP_EOL;
    echo "Fill styles: " . java_values($theme->getFormatScheme()->getFillStyles()->size()) . PHP_EOL;
    echo "Line styles: " . java_values($theme->getFormatScheme()->getLineStyles()->size()) . PHP_EOL;
    echo "Effect styles: " . java_values($theme->getFormatScheme()->getEffectStyles()->size()) . PHP_EOL;
} finally {
    $presentation->dispose();
}
```

หากไฟล์ใช้มาสเตอร์หลายตัว อย่า assumes ว่าสไลด์ทุกสไลด์มีธีมที่มีผลเดียวกัน ตรวจสอบมาสเตอร์ที่เชื่อมโยงกับสไลด์ และใช้กระบวนการธีมที่มีผลที่แสดงต่อไปนี้เมื่อมีการแทนที่ที่เลย์เอาต์หรือสไลด์

## **เปลี่ยนสีของธีม**

การเติม, เส้น, และข้อความที่รับรู้ธีมสามารถอ้างอิงสีเชิงตรรกะจาก enumeration [SchemeColor](https://reference.aspose.com/slides/th/php-java/aspose.slides/schemecolor/) ได้ เมื่อคุณเปลี่ยนรายการที่สอดคล้องกันใน [ColorScheme](https://reference.aspose.com/slides/th/php-java/aspose.slides/colorscheme/) วัตถุทั้งหมดที่ยังอ้างอิงสีธีมนั้นจะถูกแก้ไขให้ใช้ค่าที่ใหม่ วัตถุที่ใช้สี RGB โดยตรงจะไม่ถูกเปลี่ยนโดยการอัปเดตสีธีม

ตัวอย่างต่อไปนี้เป็นกระบวนการครบวงจรที่สร้างรูปร่างที่ใช้ `Accent4`, เปลี่ยนสี `Accent4` ของธีมเป็นสีแดง, บันทึกการนำเสนอ, เปิดใหม่อีกครั้ง, แล้วพิมพ์สีเติมที่มีผล:

```php
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\SchemeColor;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 10, 100, 100);
    $shape->getFillFormat()->setFillType(FillType::Solid);
    $shape->getFillFormat()->getSolidFillColor()->setSchemeColor(SchemeColor::Accent4);
    $presentation->getMasterTheme()->getColorScheme()->getAccent4()->setColor(java("java.awt.Color")->RED);
    $presentation->save("theme-color.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}

$savedPresentation = new Presentation("theme-color.pptx");
try {
    $savedSlide = $savedPresentation->getSlides()->get_Item(0);
    $savedShape = $savedSlide->getShapes()->get_Item(0);
    $effectiveColor = $savedShape->getFillFormat()->getEffective()->getSolidFillColor();
    echo sprintf("Effective fill color: A=%d, R=%d, G=%d, B=%d", java_values($effectiveColor->getAlpha()), java_values($effectiveColor->getRed()), java_values($effectiveColor->getGreen()), java_values($effectiveColor->getBlue())) . PHP_EOL;
} finally {
    $savedPresentation->dispose();
}
```

เนื่องจากสี่เหลี่ยมยังคงเชื่อมโยงกับ `Accent4` สีที่มองเห็นจึงกลายเป็นสีแดงหลังจากธีมถูกเปลี่ยน หากคุณแทนที่สีสกีมด้วยสีโดยตรงบนรูปร่าง การเปลี่ยน `Accent4` ในภายหลังจะไม่ส่งผลต่อการเติมนั้นอีกต่อไป

### **ใช้สีจากพาเลตเพิ่มเติม**

PowerPoint สร้างเวอร์ชันสีอ่อนและเข้มจากสีธีมโดยใช้การแปลงสี Aspose.Slides เปิดเผยการแปลงเหล่านี้ผ่าน enumeration [ColorTransformOperation](https://reference.aspose.com/slides/th/php-java/aspose.slides/colortransformoperation/).

![Main theme colors and lighter and darker colors generated from the additional palette](additional-palette-colors.png)

**1** - สีหลักของธีม  

**2** - เวอร์ชันสีอ่อนและเข้มที่สร้างจากสีหลักของธีม

ตัวอย่างต่อไปนี้สร้างสี่เหลี่ยมหกรูปโดยอิงจาก `Accent4`, ใช้การแปลงแสงสว่างต่อห้ารูป, แล้วบันทึกผลลัพธ์:

```php
use aspose\slides\ColorTransformOperation;
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\SchemeColor;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape1 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 10, 50, 50);
    $shape1->getFillFormat()->setFillType(FillType::Solid);
    $shape1->getFillFormat()->getSolidFillColor()->setSchemeColor(SchemeColor::Accent4);

    $shape2 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 70, 50, 50);
    $shape2->getFillFormat()->setFillType(FillType::Solid);
    $shape2->getFillFormat()->getSolidFillColor()->setSchemeColor(SchemeColor::Accent4);
    $shape2->getFillFormat()->getSolidFillColor()->getColorTransform()->add(ColorTransformOperation::MultiplyLuminance, 0.2);
    $shape2->getFillFormat()->getSolidFillColor()->getColorTransform()->add(ColorTransformOperation::AddLuminance, 0.8);

    $shape3 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 130, 50, 50);
    $shape3->getFillFormat()->setFillType(FillType::Solid);
    $shape3->getFillFormat()->getSolidFillColor()->setSchemeColor(SchemeColor::Accent4);
    $shape3->getFillFormat()->getSolidFillColor()->getColorTransform()->add(ColorTransformOperation::MultiplyLuminance, 0.4);
    $shape3->getFillFormat()->getSolidFillColor()->getColorTransform()->add(ColorTransformOperation::AddLuminance, 0.6);

    $shape4 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 190, 50, 50);
    $shape4->getFillFormat()->setFillType(FillType::Solid);
    $shape4->getFillFormat()->getSolidFillColor()->setSchemeColor(SchemeColor::Accent4);
    $shape4->getFillFormat()->getSolidFillColor()->getColorTransform()->add(ColorTransformOperation::MultiplyLuminance, 0.6);
    $shape4->getFillFormat()->getSolidFillColor()->getColorTransform()->add(ColorTransformOperation::AddLuminance, 0.4);

    $shape5 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 250, 50, 50);
    $shape5->getFillFormat()->setFillType(FillType::Solid);
    $shape5->getFillFormat()->getSolidFillColor()->setSchemeColor(SchemeColor::Accent4);
    $shape5->getFillFormat()->getSolidFillColor()->getColorTransform()->add(ColorTransformOperation::MultiplyLuminance, 0.75);

    $shape6 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 310, 50, 50);
    $shape6->getFillFormat()->setFillType(FillType::Solid);
    $shape6->getFillFormat()->getSolidFillColor()->setSchemeColor(SchemeColor::Accent4);
    $shape6->getFillFormat()->getSolidFillColor()->getColorTransform()->add(ColorTransformOperation::MultiplyLuminance, 0.5);

    $presentation->save("theme-color-palette.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

เวอร์ชันเหล่านี้ยังคงอิงจากสีธีม หาก `Accent4` เปลี่ยนในภายหลัง สีที่แปลงจะถูกคำนวณใหม่จากค่า `Accent4` ใหม่

### **แมปค่าของ `SchemeColor` ไปยังสล็อตของ `ColorScheme`**

enumeration [SchemeColor](https://reference.aspose.com/slides/th/php-java/aspose.slides/schemecolor/) ใช้ `Text1`, `Background1`, `Text2`, และ `Background2` ในขณะที่ [ColorScheme](https://reference.aspose.com/slides/th/php-java/aspose.slides/colorscheme/) เปิดเผยสล็อตธีมเดียวกันเป็น `Dark1`, `Light1`, `Dark2`, และ `Light2`. การแมปนี้คงที่:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

นี่เป็นชื่อทางเลือกของสล็อตธีมเดียวกัน; ไม่ได้เป็นค่าที่แปลงแบบไดนามิกจากรูปแบบหนึ่งเป็นอีกรูปแบบหนึ่ง

## **เปลี่ยนแบบอักษรของธีม**

สกีมแบบอักษรของธีมประกอบด้วยชุดแบบอักษรหลักสำหรับหัวเรื่องและชุดแบบอักษรรองสำหรับข้อความตัว본문. วิธีการ [FontScheme.getMajor](https://reference.aspose.com/slides/th/php-java/aspose.slides/fontscheme/) และ [FontScheme.getMinor](https://reference.aspose.com/slides/th/php-java/aspose.slides/fontscheme/) เปิดเผยชุดเหล่านั้น

ตัวระบุแบบอักษรที่เข้ากันกับ PowerPoint สามารถใช้ในรูปแบบข้อความได้:

* `+mn-lt` - แบบอักษรตัว本文 Latin (Minor Latin Font)
* `+mj-lt` - แบบอักษรหัวเรื่อง Latin (Major Latin Font)
* `+mn-ea` - แบบอักษรตัว本文 East Asian (Minor East Asian Font)
* `+mj-ea` - แบบอักษรหัวเรื่อง East Asian (Major East Asian Font)

ตัวอย่างต่อไปนี้สร้างหัวเรื่องหนึ่งที่ใช้แบบอักษร Latin หลักและบรรทัดตัว본문หนึ่งที่ใช้แบบอักษร Latin รอง จากนั้นเปลี่ยนแบบอักษรของธีมและบันทึกผลลัพธ์:

```php
use aspose\slides\FontData;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $heading = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 40, 40, 500, 60);
    $heading->getTextFrame()->setText("Theme heading");
    $heading->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->getPortionFormat()->setLatinFont(new FontData("+mj-lt"));

    $body = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 40, 120, 500, 60);
    $body->getTextFrame()->setText("Theme body text");
    $body->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->getPortionFormat()->setLatinFont(new FontData("+mn-lt"));

    $presentation->getMasterTheme()->getFontScheme()->getMajor()->setLatinFont(new FontData("Aptos Display"));
    $presentation->getMasterTheme()->getFontScheme()->getMinor()->setLatinFont(new FontData("Arial"));
    $presentation->save("theme-fonts.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

หัวเรื่องจะใช้แบบอักษรหลักและข้อความตัว본문จะใช้แบบอักษรรอง ข้อความที่ระบุชื่อแบบอักษรโดยตรงแทนตัวระบุธีมจะไม่สลับอัตโนมัติเมื่อสกีมแบบอักษรของธีมเปลี่ยน

คอลเลกชันแบบอักษรหลักและรองยังสามารถมีการแมปแบบอักษรสำหรับระบบเขียนแต่ละระบบ เช่น Cyrillic, Arabic, Japanese, Georgian, และ Thaana เพื่อดู วิธีการตรวจสอบ, เพิ่ม, แทนที่หรือเอาการแมปเหล่านี้ออก, ดูที่ [Script-Specific Theme Fonts](/slides/th/php-java/script-specific-font-mappings/).

{{% alert color="info" title="Tip" %}}
สำหรับข้อมูลเพิ่มเติมเกี่ยวกับแบบอักษรของการนำเสนอ ดูที่ [PowerPoint Fonts](/slides/th/php-java/powerpoint-fonts/).
{{% /alert %}}

## **คัดลอกหรือใช้ธีม**

กระบวนการต่อไปนี้แก้ปัญหาที่เกี่ยวข้องกับธีมต่าง ๆ

### **ใช้ธีมภายนอกกับสไลด์ที่ขึ้นอยู่กับมาสเตอร์**

ใช้ [MasterSlide::applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/th/php-java/aspose.slides/masterslide/) เมื่อคุณมีไฟล์ธีม PowerPoint (`.thmx`) และต้องการปรับสไตล์ทุกสไลด์ที่ขึ้นกับมาสเตอร์ที่กำหนด เลือกมาสเตอร์จากคอลเลกชัน [Presentation::getMasters](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentation/) ซึ่งเป็นส่วนของ [MasterSlideCollection](https://reference.aspose.com/slides/th/php-java/aspose.slides/masterslidecollection/) แล้วส่งพาธไฟล์ธีมไปยังเมธอด

เมธอดทำงานดังนี้:

1. สร้างสไลด์มาสเตอร์ใหม่จากมาสเตอร์ที่เลือก
1. ใช้ธีมภายนอกกับมาสเตอร์ใหม่
1. กำหนดมาสเตอร์ใหม่ให้กับสไลด์ทั้งหมดที่เคยขึ้นกับมาสเตอร์ที่เลือก
1. คืนค่า [MasterSlide](https://reference.aspose.com/slides/th/php-java/aspose.slides/masterslide/) ที่สร้างใหม่

ตัวอย่างต่อไปนี้ใช้ธีมภายนอกกับสไลด์ที่ขึ้นกับมาสเตอร์แรกและบันทึกการนำเสนอ:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("presentation.pptx");
try {
    $selectedMaster = $presentation->getMasters()->get_Item(0);
    $themedMaster = $selectedMaster->applyExternalThemeToDependingSlides("corporate-theme.thmx");

    echo "Created master: " . java_values($themedMaster->getName()) . PHP_EOL;
    $presentation->save("presentation-with-external-theme.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

ธีมที่ไม่ถูกต้อง, เสียหาย, หรือไม่รองรับอาจทำให้เกิด [PptxReadException](https://reference.aspose.com/slides/th/php-java/aspose.slides/pptxreadexception/). ตรวจสอบพาธที่ผู้ใช้ส่งมา, จัดการความล้มเหลวในการเข้าถึงระบบไฟล์, และบันทึกการนำเสนอหลังจากธีมถูกนำไปใช้สำเร็จ

เฉพาะสไลด์ที่ขึ้นกับมาสเตอร์ที่เลือกเท่านั้นที่จะถูกกำหนดใหม่ สไลด์ที่เชื่อมโยงกับมาสเตอร์อื่นจะรักษามาสเตอร์และธีมเดิมไว้ สี, แบบอักษร, เติม, เส้น, พื้นหลัง, และเอฟเฟกต์ที่รับรู้ธีมจะถูกแก้ไขตามธีมภายนอก สี, แบบอักษร, เติม, และการจัดรูปแบบที่กำหนดโดยตรงอาจยังคงไม่เปลี่ยน การแทนที่ระดับเลย์เอาต์และระดับสไลด์อาจยังคงมีลำดับความสำคัญเหนือค่าที่สืบทอดจากมาสเตอร์ใหม่

ธีมอาจอ้างอิงแบบอักษรที่ไม่มีในสภาพแวดล้อมการทำงาน สำหรับการเรนเดอร์และการส่งออกที่สม่ำเสมอ, ให้ติดตั้งแบบอักษรที่จำเป็น, จัดหาแบบอักษรผ่าน [custom font sources](/slides/th/php-java/custom-font/), หรือกำหนดค่า [font substitution](/slides/th/php-java/font-substitution/).

นี่คือการทำงานโดยตรงระดับมาสเตอร์: เมธอดรับพาธไฟล์ `.thmx` และไม่ต้องสร้างการแทนที่ธีมระดับสไลด์หรือเลย์เอาต์ด้วยตนเอง

### **ใช้ธีมภายนอกที่แตกต่างในงานนำเสนอหลายมาสเตอร์**

เมื่อไม่ทราบมาสเตอร์ที่เกี่ยวข้องล่วงหน้า, หาได้จากสไลด์ตัวอย่างผ่าน [Slide::getLayoutSlide](https://reference.aspose.com/slides/th/php-java/aspose.slides/slide/) และ [LayoutSlide::getMasterSlide](https://reference.aspose.com/slides/th/php-java/aspose.slides/layoutslide/). เก็บอ้างอิงมาสเตอร์เดิมก่อนใช้ธีมใด ๆ เนื่องจากแต่ละครั้งที่เรียกจะสร้างมาสเตอร์ใหม่ในงานนำเสนอ

ตัวอย่างต่อไปนี้ใช้สไลด์จากสองส่วนเพื่อระบุมาสเตอร์และใช้ธีมภายนอกที่แตกต่างกันกับแต่ละกลุ่ม:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("multi-master-presentation.pptx");
try {
    if (java_values($presentation->getSlides()->size()) < 5) {
        echo "The presentation does not contain the expected representative slides." . PHP_EOL;
    } else {
        $firstGroupMaster = $presentation->getSlides()->get_Item(0)->getLayoutSlide()->getMasterSlide();
        $secondGroupMaster = $presentation->getSlides()->get_Item(4)->getLayoutSlide()->getMasterSlide();

        if (java_values($firstGroupMaster->getSlideId()) === java_values($secondGroupMaster->getSlideId())) {
            echo "The representative slides use the same master." . PHP_EOL;
        } else {
            $firstThemedMaster = $firstGroupMaster->applyExternalThemeToDependingSlides("blue-theme.thmx");
            $secondThemedMaster = $secondGroupMaster->applyExternalThemeToDependingSlides("green-theme.thmx");

            echo "First themed master: " . java_values($firstThemedMaster->getName()) . PHP_EOL;
            echo "Second themed master: " . java_values($secondThemedMaster->getName()) . PHP_EOL;
            $presentation->save("multi-master-with-external-themes.pptx", SaveFormat::Pptx);
        }
    }
} finally {
    $presentation->dispose();
}
```

การเรียกครั้งแรกส่งผลเฉพาะสไลด์ที่ขึ้นกับ `$firstGroupMaster`, การเรียกครั้งที่สองส่งผลเฉพาะสไลด์ที่ขึ้นกับ `$secondGroupMaster`. สไลด์ที่อยู่ภายใต้มาสเตอร์อื่น ๆ จะไม่ถูกปรับสไตล์ใหม่

### **คงธีมต้นฉบับเมื่อย้ายสไลด์**

หากต้องการย้ายสไลด์ไปยังงานนำเสนออื่นและคงการออกแบบเดิม, ให้โคลนมาสเตอร์ต้นฉบับไปยังงานนำหมายาด้วย [MasterSlideCollection.addClone](https://reference.aspose.com/slides/th/php-java/aspose.slides/masterslidecollection/), แล้วโคลนสไลด์ด้วย [SlideCollection.addClone](https://reference.aspose.com/slides/th/php-java/aspose.slides/slidecollection/) พร้อมมาสเตอร์ที่โคลนไว้ วิธีนี้จะพิมพ์มาสเตอร์, เลย์เอาต์, และธีมที่เกี่ยวข้องไปด้วย

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$source = new Presentation("source-theme.pptx");
try {
    $target = new Presentation("target.pptx");
    try {
        $sourceSlide = $source->getSlides()->get_Item(0);
        $sourceMaster = $sourceSlide->getLayoutSlide()->getMasterSlide();
        $clonedMaster = $target->getMasters()->addClone($sourceMaster);
        $target->getSlides()->addClone($sourceSlide, $clonedMaster, true);
        $target->save("theme-preserved.pptx", SaveFormat::Pptx);
    } finally {
        $target->dispose();
    }
} finally {
    $source->dispose();
}
```

นี่เป็นวิธีที่แนะนำเมื่อสไลด์ต้นฉบับต้องการรูปลักษณ์เดียวกันในจุดหมาย การโคลนเนื้อหาไปยังมาสเตอร์ที่ไม่เกี่ยวข้องอาจทำให้สี, แบบอักษร, พื้นหลัง, และเอฟเฟกต์ที่ขับเคลื่อนด้วยธีมเปลี่ยนแปลงได้

### **ใช้ค่าธีมกับสไลด์ที่มีอยู่**

หากสไลด์เป้าหมายต้องคงมาสเตอร์และเลย์เอาต์เดิม, ให้เริ่มต้นการแทนที่ระดับสไลด์จากธีมต้นฉบับ วิธีการ [OverrideTheme.initColorSchemeFrom](https://reference.aspose.com/slides/th/php-java/aspose.slides/overridetheme/), [OverrideTheme.initFontSchemeFrom](https://reference.aspose.com/slides/th/php-java/aspose.slides/overridetheme/), และ [OverrideTheme.initFormatSchemeFrom](https://reference.aspose.com/slides/th/php-java/aspose.slides/overridetheme/) จะคัดลอกส่วนประกอบธีมหลักสามส่วนเข้าสู่การแทนที่

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$source = new Presentation("source-theme.pptx");
try {
    $target = new Presentation("target.pptx");
    try {
        $targetSlide = $target->getSlides()->get_Item(0);
        $overrideTheme = $targetSlide->getThemeManager()->getOverrideTheme();
        $overrideTheme->initColorSchemeFrom($source->getMasterTheme()->getColorScheme());
        $overrideTheme->initFontSchemeFrom($source->getMasterTheme()->getFontScheme());
        $overrideTheme->initFormatSchemeFrom($source->getMasterTheme()->getFormatScheme());
        $target->save("theme-applied-to-slide.pptx", SaveFormat::Pptx);
    } finally {
        $target->dispose();
    }
} finally {
    $source->dispose();
}
```

การทำเช่นนี้จะเปลี่ยนธีมที่สไลด์นั้นใช้โดยไม่กระทบธีมที่สืบทอดโดยสไลด์อื่น ๆ เพื่อลบการแทนที่ในระดับท้องถิ่นและคืนสู่ค่าที่สืบทอด, ให้เรียก [OverrideTheme.clear](https://reference.aspose.com/slides/th/php-java/aspose.slides/overridetheme/)

### **ใช้การแทนที่ธีมกับเลย์เอาต์**

การแทนที่ระดับเลย์เอาต์จะส่งผลต่อสไลด์ที่ใช้เลย์เอาต์นั้น, ยกเว้นสไลด์ที่มีการแทนที่ของตนเอง วิธีการเริ่มต้นเดียวกันนี้สามารถใช้ผ่าน [LayoutSlideThemeManager](https://reference.aspose.com/slides/th/php-java/aspose.slides/layoutslidethememanager/):

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$source = new Presentation("source-theme.pptx");
try {
    $target = new Presentation("target.pptx");
    try {
        $targetSlide = $target->getSlides()->get_Item(0);
        $overrideTheme = $targetSlide->getLayoutSlide()->getThemeManager()->getOverrideTheme();
        $overrideTheme->initColorSchemeFrom($source->getMasterTheme()->getColorScheme());
        $overrideTheme->initFontSchemeFrom($source->getMasterTheme()->getFontScheme());
        $overrideTheme->initFormatSchemeFrom($source->getMasterTheme()->getFormatScheme());
        $target->save("theme-applied-to-layout.pptx", SaveFormat::Pptx);
    } finally {
        $target->dispose();
    }
} finally {
    $source->dispose();
}
```

ใช้ธีมระดับมาสเตอร์หรือการนำเสนอเมื่อหลายเลย์เอาต์และสไลด์ต้องการการออกแบบฐานเดียวกัน, ใช้การแทนที่ระดับเลย์เอาต์เมื่อครอบครัวเลย์เอาต์ต้องการสไตล์ต่างกัน, และใช้การแทนที่ระดับสไลด์เฉพาะเมื่อมีข้อยกเว้นจริง การแทนที่ระดับสไลด์มากเกินไปจะทำให้การเปลี่ยนแปลงธีมทั่วโลกในภายหลังคาดเดายาก

## **อัปเดตสไตล์พื้นหลังของธีม**

การเติมพื้นหลังของธีมถูกเก็บไว้ใน [FormatScheme.getBackgroundFillStyles](https://reference.aspose.com/slides/th/php-java/aspose.slides/formatscheme/). PowerPoint สามารถแสดงตัวเลือกพื้นหลังมากกว่าจำนวนการเติมที่เก็บจริงในคอลเลกชันนี้ เพราะ UI สามารถผสานเติมธีมกับสีธีมและการอ้างอิงสไตล์อื่น ๆ

![PowerPoint background style gallery for a presentation theme](presentation-design_8.png)

ก่อนใช้สไตล์พื้นหลัง, ตรวจสอบคอลเลกชันที่เก็บและค่า [Background.getStyleIndex](https://reference.aspose.com/slides/th/php-java/aspose.slides/background/) ปัจจุบัน ค่าดัชนีสไตล์ `0` หมายถึงไม่มีการเติมที่มีธีม; ค่าบวกเป็นการอ้างอิงสไตล์พื้นหลังของธีม สิ่งนี้ต่างจากการดัชนีคอลเลกชัน PHP โดยตรงที่ `get_Item(0)` หมายถึงรายการแรกที่เก็บ อย่าสมมติว่าการนำเสนอทุกไฟล์มีจำนวนสไตล์เติมพื้นหลังเท่ากัน

ตัวอย่างต่อไปนี้รายงานจำนวนการเติมพื้นหลังที่มี, กำหนดการอ้างอิงพื้นหลังที่มีธีมให้กับมาสเตอร์แรก, แล้วบันทึกการนำเสนอ:

```php
use aspose\slides\BackgroundType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("input.pptx");
try {
    $backgroundStyleCount = java_values($presentation->getMasterTheme()->getFormatScheme()->getBackgroundFillStyles()->size());
    echo "Background fill styles: " . $backgroundStyleCount . PHP_EOL;
    if ($backgroundStyleCount === 0) {
        throw new RuntimeException("The presentation theme does not contain background fill styles.");
    }

    $masterSlide = $presentation->getMasters()->get_Item(0);
    $masterSlide->getBackground()->setType(BackgroundType::Themed);
    $masterSlide->getBackground()->setStyleIndex(1);
    $presentation->save("theme-background.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

ผลลัพธ์ที่มองเห็นขึ้นอยู่กับรายการธีมที่มาสเตอร์อ้างอิงและการแทนที่พื้นหลังที่ระดับเลย์เอาต์หรือสไลด์ หากสไลด์ใช้พื้นหลังของตนเอง การเปลี่ยนพื้นหลังของมาสเตอร์อย่างเดียวอาจไม่ส่งผลต่อสไลด์นั้น ใช้ [Background.getEffective](https://reference.aspose.com/slides/th/php-java/aspose.slides/background/) เมื่อคุณต้องการทราบพื้นหลังสุดท้ายหลังจากการสืบทอด

{{% alert color="warning" title="Warning" %}}
อย่าอ้างอิงดัชนีสไตล์เป็นดัชนีของคอลเลกชันที่เริ่มจากศูนย์ อีกทั้งหลีกเลี่ยงการกำหนดหมายเลขสไตล์จากไฟล์หนึ่งและสมมติว่ามันมีลักษณะเดียวกันในไฟล์อื่น; คำกำหนดสไตล์ของธีมเป็นลักษณะเฉพาะของการนำเสนอ
{{% /alert %}}

{{% alert color="info" title="Tip" %}}
สำหรับการจัดรูปแบบพื้นหลังโดยตรงและการสืบทอดพื้นหลัง, ดูที่ [Presentation Background](/slides/th/php-java/presentation-background/)
{{% /alert %}}

## **อัปเดตเอฟเฟกต์ของธีม**

สกีมรูปแบบของธีมมีคอลเลกชันเติม, เส้น, และเอฟเฟกต์แยกกันที่เปิดเผยผ่าน [FormatScheme.getFillStyles](https://reference.aspose.com/slides/th/php-java/aspose.slides/formatscheme/), [FormatScheme.getLineStyles](https://reference.aspose.com/slides/th/php-java/aspose.slides/formatscheme/), และ [FormatScheme.getEffectStyles](https://reference.aspose.com/slides/th/php-java/aspose.slides/formatscheme/). ธีม Office ทั่วไปมักมีรายการสไตล์หลักสามรายการที่สอดคล้องกับการจัดรูปแบบละเอียด, ปานกลาง, และเข้ม, แต่โค้ดควรตรวจสอบแต่ละคอลเลกชันแทนการสันนิษฐานว่ามีจำนวนคงที่

![Subtle, moderate, and intense theme effects applied to the same shape](presentation-design_10.png)

เมื่อเข้าถึงคอลเลกชันเหล่านี้ใน PHP, ดัชนีคอลเลกชันเริ่มที่ศูนย์: `get_Item(0)` คือสไตล์ที่เก็บเป็นแรกและ `get_Item(2)` คือสไตล์ลำดับที่สาม ดัชนีการอ้างอิงสไตล์ของรูปร่างเป็นแนวคิดแยกต่างหาก, เปิดเผยผ่าน [ShapeStyle](https://reference.aspose.com/slides/th/php-java/aspose.slides/shapestyle/). การแก้ไขสไตล์ธีมจะส่งผลต่อรูปร่างที่อ้างอิงสไตล์นั้น; รูปร่างที่มีการจัดรูปแบบโดยตรงอาจไม่เปลี่ยน

ตัวอย่างต่อไปนี้ตรวจสอบว่ามีรายการสไตล์ที่ต้องการหรือไม่, เปลี่ยนสไตล์เส้นแรก, เปลี่ยนสไตล์เติมที่สาม, เปิดใช้งานเงานอกในสไตล์เอฟเฟกต์ที่สาม, แล้วบันทึกผลลัพธ์:

```php
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("Subtle_Moderate_Intense.pptx");
try {
    $formatScheme = $presentation->getMasterTheme()->getFormatScheme();
    if (java_values($formatScheme->getLineStyles()->size()) < 1 || java_values($formatScheme->getFillStyles()->size()) < 3 || java_values($formatScheme->getEffectStyles()->size()) < 3) {
        throw new RuntimeException("The theme does not contain the style entries required by this example.");
    }

    $formatScheme->getLineStyles()->get_Item(0)->getFillFormat()->setFillType(FillType::Solid);
    $formatScheme->getLineStyles()->get_Item(0)->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
    $formatScheme->getFillStyles()->get_Item(2)->setFillType(FillType::Solid);
    $formatScheme->getFillStyles()->get_Item(2)->getSolidFillColor()->setColor(new Java("java.awt.Color", 34, 139, 34));
    $effectFormat = $formatScheme->getEffectStyles()->get_Item(2)->getEffectFormat();
    $effectFormat->enableOuterShadowEffect();
    $effectFormat->getOuterShadowEffect()->setDistance(10.0);
    $presentation->save("theme-effects.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

สำหรับรูปร่างที่อ้างอิงสล็อตเหล่านี้, สไตล์เส้นธีมแรกจะกลายเป็นสีแดง, สไตล์เติมธีมที่สามจะเป็นสีเขียวป่าแบบทึบ, และสไตล์เอฟเฟกต์ที่สามจะเพิ่มเงานอกที่ระยะ 10 จุด ผลลัพธ์ที่มองเห็นจริงยังคงขึ้นกับสไตล์ที่แต่ละรูปร่างอ้างอิงและว่าการจัดรูปแบบโดยตรงจะทับธีมหรือไม่

![Theme effect styles after changing line, fill, and shadow settings](presentation-design_11.png)

## **อ่านค่าธีมที่มีผล**

อ็อบเจ็กต์ธีมดิบบอกว่ามีอะไรถูกกำหนดไว้ในระดับใดระดับหนึ่ง ค่าที่มีผลบอกว่าหน่วยหรือรูปร่างใช้ค่าอะไรจริง ๆ หลังจากการสืบทอดและการแทนที่ในระดับท้องถิ่นได้ถูกแก้ไขแล้ว สำหรับสไลด์, เรียก [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/th/php-java/aspose.slides/baseoverridethememanager/). สำหรับพื้นหลัง, ใช้ [Background.getEffective](https://reference.aspose.com/slides/th/php-java/aspose.slides/background/), และสำหรับการเติม, ใช้ [FillFormat.getEffective](https://reference.aspose.com/slides/th/php-java/aspose.slides/fillformat/)

ตัวอย่างต่อไปนี้อ่านธีมที่มีผล, พื้นหลัง, และการเติมของรูปทรงแรกจากสไลด์:

```php
use aspose\slides\FillType;
use aspose\slides\Presentation;

$presentation = new Presentation("input.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $effectiveTheme = $slide->getThemeManager()->createThemeEffective();
    $effectiveBackground = $slide->getBackground()->getEffective();
    echo "Effective major Latin font: " . $effectiveTheme->getFontScheme()->getMajor()->getLatinFont()->getFontName() . PHP_EOL;
    echo "Effective minor Latin font: " . $effectiveTheme->getFontScheme()->getMinor()->getLatinFont()->getFontName() . PHP_EOL;
    echo "Effective background fill type: " . java_values($effectiveBackground->getFillFormat()->getFillType()) . PHP_EOL;
    if (java_values($slide->getShapes()->size()) > 0) {
        $effectiveFill = $slide->getShapes()->get_Item(0)->getFillFormat()->getEffective();
        echo "First shape effective fill type: " . java_values($effectiveFill->getFillType()) . PHP_EOL;
        if (java_values($effectiveFill->getFillType()) == FillType::Solid) {
            $effectiveColor = $effectiveFill->getSolidFillColor();
            echo sprintf("First shape effective fill color: A=%d, R=%d, G=%d, B=%d", java_values($effectiveColor->getAlpha()), java_values($effectiveColor->getRed()), java_values($effectiveColor->getGreen()), java_values($effectiveColor->getBlue())) . PHP_EOL;
        }
    }
} finally {
    $presentation->dispose();
}
```

ใช้ข้อมูลที่มีผลสำหรับการวินิจฉัยการเรนเดอร์, การตรวจสอบ, และการเปรียบเทียบ หากคุณตรวจสอบเฉพาะ [Presentation.getMasterTheme](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentation/) คุณอาจพลาดการแทนที่จากมาสเตอร์, เลย์เอาต์, สไลด์, หรือรูปร่างที่เปลี่ยนลักษณะสุดท้าย

## **คำถามที่พบบ่อย**

**การใช้ธีมภายนอกมีผลต่อสไลด์ทุกสไลด์ในงานนำเสนอหรือไม่?**

ไม่. [MasterSlide::applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/th/php-java/aspose.slides/masterslide/) จะกำหนดใหม่เฉพาะสไลด์ที่ขึ้นกับมาสเตอร์ที่เลือกเท่านั้น สไลด์ที่ใช้มาสเตอร์อื่นจะคงธีมเดิมไว้

**ฉันสามารถใช้ธีมกับสไลด์เดียวโดยไม่เปลี่ยนมาสเตอร์ได้หรือไม่?**

ได้. ใช้ [SlideThemeManager](https://reference.aspose.com/slides/th/php-java/aspose.slides/slidethememanager/) ของสไลด์และเริ่มต้นธีมแทนที่ของมัน การเปลี่ยนแปลงจะอยู่เฉพาะสไลด์นั้น; สไลด์อื่น ๆ จะสืบทอดธีมเดิมต่อไป

**วิธีที่ปลอดภัยที่สุดในการย้ายธีมจากงานนำเสนอหนึ่งไปยังอีกงานนำเสนอหนึ่งคืออะไร?**

เมื่อต้องย้ายสไลด์และคงรูปลักษณ์ต้นฉบับ, ให้โคลนมาสเตอร์ต้นฉบับไปยังปลายทางและโคลนสไลด์พร้อมมาสเตอร์นั้นโดยใช้ [MasterSlideCollection.addClone](https://reference.aspose.com/slides/th/php-java/aspose.slides/masterslidecollection/) และ [SlideCollection.addClone](https://reference.aspose.com/slides/th/php-java/aspose.slides/slidecollection/). วิธีนี้ทำให้มาสเตอร์, เลย์เอาต์, และธีมอยู่ด้วยกัน

**ฉันจะดูค่าที่มีผลหลังจากการสืบทอดและการแทนที่ได้อย่างไร?**

ใช้ [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/th/php-java/aspose.slides/baseoverridethememanager/) สำหรับสไลด์หรือธีมเลย์เอาต์และเมธอดข้อมูลที่มีผลที่สอดคล้องสำหรับอ็อบเจ็กต์รูปแบบ เช่น [Background.getEffective](https://reference.aspose.com/slides/th/php-java/aspose.slides/background/) และ [FillFormat.getEffective](https://reference.aspose.com/slides/th/php-java/aspose.slides/fillformat/). API เหล่านี้จะคืนค่าที่แก้ไขแล้วหลังจากการสืบทอดและการแทนที่ถูกนำไปใช้.