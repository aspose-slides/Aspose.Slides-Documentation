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
- พาเล็ตเพิ่มเติม
- ฟอนต์ธีม
- สไตล์ธีม
- เอฟเฟกต์ธีม
- PowerPoint
- OpenDocument
- การนำเสนอ
- PHP
- Aspose.Slides
description: "ควบคุมธีมการนำเสนอใน Aspose.Slides สำหรับ PHP ผ่าน Java เพื่อสร้าง ปรับแต่ง และแปลงไฟล์ PowerPoint ให้มีการแบรนด์ที่สอดคล้องกัน."
---
## **บทนำ**

ธีมงานนำเสนอกำหนดชุดสี, ฟอนต์, สไตล์พื้นหลัง, การเติม, เส้น, และเอฟเฟกต์ที่สอดคล้องกัน วัตถุที่รับรู้ธีมจะอ้างอิงถึงการกำหนดที่ใช้ร่วมกันเหล่านี้แทนการเก็บค่าคุณสมบัติวิดีโอแต่ละอย่างเป็นค่าคงที่ ดังนั้นการเปลี่ยนธีมจึงสามารถอัพเดตหลายวัตถุพร้อมกันได้

ใน Aspose.Slides ธีมระดับงานนำเสนอสามารถเข้าถึงได้ผ่าน [Presentation::getMasterTheme](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) งานนำเสนออาจมีการเขียนทับธีมในระดับที่ต่ำกว่า มาสเตอร์สามารถเขียนทับธีมงานนำเสนอผ่าน [MasterThemeManager::getOverrideTheme](https://reference.aspose.com/slides/php-java/aspose.slides/masterthememanager/) ขณะที่เลเอาต์หรือสไลด์แต่ละสไลด์สามารถเขียนทับธีมที่สืบทอดมาผ่าน [BaseOverrideThemeManager::getOverrideTheme](https://reference.aspose.com/slides/php-java/aspose.slides/baseoverridethememanager/) ในการปฏิบัติธีมที่ได้ผลสำหรับสไลด์หนึ่งจะถูกแก้ไขผ่านสายการสืบทอดนี้: ธีมงานนำเสนอ → การเขียนทับมาสเตอร์ → การเขียนทับเลเอาต์ → การเขียนทับสไลด์

![ส่วนประกอบของธีม: สี, ฟอนต์, สไตล์พื้นหลัง, และเอฟเฟกต์](theme-constituents.png)

ส่วนต่อไปนี้แสดงขั้นตอนการทำงานกับธีมที่พบมากที่สุด: ตรวจสอบธีม, เปลี่ยนสีและฟอนต์, คัดลอกหรือใช้ธีม, อัปเดตสไตล์พื้นหลังและเอฟเฟกต์, และอ่านค่าที่มีผลหลังจากสืบทอดและการเขียนทับได้รับการแก้ไข

## **ตรวจสอบธีม**

วัตถุ [MasterTheme](https://reference.aspose.com/slides/php-java/aspose.slides/mastertheme/) เปิดเผยโครงการสี, โครงการฟอนต์, และโครงการรูปแบบของธีมผ่าน [MasterTheme::getColorScheme](https://reference.aspose.com/slides/php-java/aspose.slides/mastertheme/), [MasterTheme::getFontScheme](https://reference.aspose.com/slides/php-java/aspose.slides/mastertheme/), และ [MasterTheme::getFormatScheme](https://reference.aspose.com/slides/php-java/aspose.slides/mastertheme/) การตรวจสอบคอลเล็กชันเหล่านี้ก่อนทำการเปลี่ยนแปลงเป็นประโยชน์เป็นพิเศษเมื่อไฟล์งานนำมาจากแหล่งภายนอก เพราะจำนวนและเนื้อหาของรายการสไตล์อาจแตกต่างกัน

ตัวอย่างต่อไปนี้อ่านคุณสมบัติธีมหลักและรายงานจำนวนสไตล์พื้นหลัง, การเติม, เส้น, และเอฟเฟกต์ที่จัดเก็บไว้ในธีม:

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

หากไฟล์ใช้หลายมาสเตอร์ อย่าสมมติว่าสไลด์ทุกสไลด์มีธีมที่ได้ผลเดียวกัน ตรวจสอบมาสเตอร์ที่เชื่อมโยงกับสไลด์, และใช้ขั้นตอนการทำงานกับธีมที่ได้ผลที่แสดงต่อไปในบทนี้เมื่ออาจมีการเขียนทับที่ระดับเลเอาต์หรือสไลด์อยู่

## **เปลี่ยนสีธีม**

การเติม, เส้น, และข้อความที่รับรู้ธีมสามารถอ้างอิงถึงสีเชิงตรรกะจากรายการ [SchemeColor](https://reference.aspose.com/slides/php-java/aspose.slides/schemecolor/) เมื่อคุณเปลี่ยนรายการที่สอดคล้องกันใน [ColorScheme](https://reference.aspose.com/slides/php-java/aspose.slides/colorscheme/) วัตถุทั้งหมดที่ยังอ้างอิงสีธีมนั้นจะถูกแก้ไขให้ตรงกับค่าที่ใหม่ วัตถุที่ใช้สี RGB โดยตรงจะไม่ถูกเปลี่ยนแปลงโดยการอัพเดตสีธีม

ตัวอย่างต่อไปนี้สร้างรูปทรงที่ใช้ `Accent4`, เปลี่ยนสีธีม `Accent4` เป็นสีแดง, บันทึกงานนำเสนอ, เปิดใหม่, และพิมพ์สีเติมที่ได้ผล:

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

เนื่องจากสี่เหลี่ยมยังคงเชื่อมต่อกับ `Accent4` สีที่มองเห็นจึงกลายเป็นสีแดงหลังจากเปลี่ยนธีม หากคุณแทนที่สีสคีมด้วยสีโดยตรงบนรูปทรง การเปลี่ยนแปลงต่อ `Accent4` ในภายหลังจะไม่ส่งผลต่อการเติมนั้นอีกต่อไป

### **ใช้สีจากพาเล็ตเพิ่มเติม**

PowerPoint สร้างสีที่อ่อนและสีที่เข้มจากสีธีมโดยใช้การแปลงสี Aspose.Slides เปิดเผยการแปลงเหล่านี้ผ่านรายการ [ColorTransformOperation](https://reference.aspose.com/slides/php-java/aspose.slides/colortransformoperation/)

![สีธีมหลักและสีที่อ่อนและเข้มที่สร้างจากพาเล็ตเพิ่มเติม](additional-palette-colors.png)

**1** – สีธีมหลัก

**2** – สีอ่อนและสีเข้าที่ผลิตจากสีธีมหลัก

ตัวอย่างต่อไปนี้สร้างสี่เหลี่ยมแบบหกรูปที่อิงจาก `Accent4`, ใช้การแปลงความสว่างกับห้ารูป, และบันทึกผลลัพธ์:

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

ตัวแปรเหล่านี้ยังคงอิงจากสีธีม หาก `Accent4` เปลี่ยนภายหลัง สีที่ถูกแปลงจะถูกคำนวณใหม่จากค่า `Accent4` ใหม่

### **แมปค่า `SchemeColor` ไปยังช่อง `ColorScheme`**

รายการ [SchemeColor](https://reference.aspose.com/slides/php-java/aspose.slides/schemecolor/) ใช้ `Text1`, `Background1`, `Text2`, และ `Background2` ขณะที่ [ColorScheme](https://reference.aspose.com/slides/php-java/aspose.slides/colorscheme/) เปิดเผยช่องธีมเดียวกันเป็น `Dark1`, `Light1`, `Dark2`, และ `Light2` การแมปคงที่ดังนี้:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

เหล่านี้เป็นชื่อทางเลือกของช่องธีมเดียวกัน; ไม่ได้เป็นค่าที่แปลงแบบไดนามิกระหว่างรูปแบบต่าง ๆ

## **เปลี่ยนฟอนต์ธีม**

โครงการฟอนต์ธีมประกอบด้วยชุดฟอนต์หลักสำหรับหัวเรื่องและชุดฟอนต์รองสำหรับข้อความหลัก วิธี [FontScheme::getMajor](https://reference.aspose.com/slides/php-java/aspose.slides/fontscheme/) และ [FontScheme::getMinor](https://reference.aspose.com/slides/php-java/aspose.slides/fontscheme/) เปิดเผยชุดเหล่านั้น

ตัวระบุฟอนต์ธีมที่เข้ากันกับ PowerPoint สามารถใช้ในการจัดรูปแบบข้อความได้:

* `+mn-lt` – ฟอนต์ Body Latin (ฟอนต์ Latin รอง)
* `+mj-lt` – ฟอนต์ Heading Latin (ฟอนต์ Latin หลัก)
* `+mn-ea` – ฟอนต์ Body East Asian (ฟอนต์ East Asian รอง)
* `+mj-ea` – ฟอนต์ Heading East Asian (ฟอนต์ East Asian หลัก)
* `+mn-cs` – ฟอนต์ Body Complex Script (ฟอนต์ Complex Script รอง)
* `+mj-cs` – ฟอนต์ Heading Complex Script (ฟอนต์ Complex Script หลัก)

ตัวอย่างต่อไปนี้สร้างหัวเรื่องหนึ่งที่ใช้ฟอนต์ Latin หลักของธีมและบรรทัดข้อความหลักหนึ่งที่ใช้ฟอนต์ Latin รองของธีม จากนั้นเปลี่ยนฟอนต์ธีมและบันทึกผลลัพธ์:

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

หัวเรื่องจะตามฟอนต์หลักและข้อความหลักจะตามฟอนต์รอง ข้อความที่มีการระบุชื่อฟอนต์โดยตรงแทนตัวระบุธีมจะไม่สลับโดยอัตโนมัติเมื่อโครงการฟอนต์ธีมเปลี่ยน

คอลเล็กชันฟอนต์หลักและรองยังสามารถมีการแมปฟอนต์สำหรับระบบการเขียนแบบบุคคล เช่น Cyrillic, Arabic, Japanese, Georgian, และ Thaana เพื่อดู, เพิ่ม, แทนที่, หรือเอาการแมปเหล่านี้ออก ดู [Script-Specific Theme Fonts](/slides/th/php-java/script-specific-font-mappings/)

{{% alert color="info" title="Tip" %}}
สำหรับข้อมูลเพิ่มเติมเกี่ยวกับฟอนต์ในงานนำเสนอ ดูที่ [PowerPoint Fonts](/slides/th/php-java/powerpoint-fonts/)
{{% /alert %}}

### **แก้ไขการอ้างอิงฟอนต์ธีม**

เมื่อทำการตรวจสอบข้อความ, [FontData::getFontName](https://reference.aspose.com/slides/php-java/aspose.slides/fontdata/) สามารถคืนค่าการอ้างอิงธีมเช่น `+mn-lt` แทนชื่อฟอนต์ครอบครัว ใช้ [FontData::getFontName](https://reference.aspose.com/slides/php-java/aspose.slides/fontdata/) พร้อมข้อมูลธีมที่ได้ผลที่เหมาะสมเพื่อตีความการอ้างอิงนั้น คำ prefix `+mj` และ `+mn` เลือกชุดฟอนต์หลักและรอง; suffix `-lt`, `-ea`, และ `-cs` เลือกฟอนต์ Latin, East Asian, และ Complex Script ตามลำดับ

รับธีมที่ได้ผลผ่าน [Slide::createThemeEffective](https://reference.aspose.com/slides/php-java/aspose.slides/slide/) บนวัตถุที่ธีมของมันนำไปใช้กับข้อความที่ตรวจสอบ สำหรับข้อความทั่วไปบนสไลด์ เรียกเมธอดนี้บนสไลด์เพื่อให้บริบทรวมถึงธีมที่สืบทอดจากสไลด์นั้นและการเขียนทับท้องถิ่น เมื่อทำการตรวจสอบเลเอาต์หรือมาสเตอร์โดยตรง ให้ใช้ธีมที่ได้ผลของมันเอง อย่าสมมติว่าธีมของมาสเตอร์คนแรกจะใช้กับสไลด์ทุกสไลด์

ตัวอย่างต่อไปนี้สร้างส่วนข้อความที่อ้างอิงฟอนต์ Latin รองอย่างชัดเจน เริ่มต้นโครงการฟอนต์สไลด์ผ่าน [OverrideTheme::initFontSchemeFromInherited](https://reference.aspose.com/slides/php-java/aspose.slides/overridetheme/) และกำหนดครอบครัว Latin หลักและรองเป็น `Arial` และ `Calibri` ทำให้ผลลัพธ์สืบเนื่องได้โดยไม่ต้องมีไฟล์อินพุต:

```php
use aspose\slides\FontData;
use aspose\slides\Presentation;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $theme = $slide->getThemeManager()->getOverrideTheme();
    $theme->initFontSchemeFromInherited();
    $theme->getFontScheme()->getMajor()->setLatinFont(new FontData("Arial"));
    $theme->getFontScheme()->getMinor()->setLatinFont(new FontData("Calibri"));

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 20, 400, 60);
    $shape->getTextFrame()->setText("Text using the minor theme font");

    $portion = $shape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
    $portion->getPortionFormat()->setLatinFont(new FontData("+mn-lt"));

    $font = $portion->getPortionFormat()->getLatinFont();
    $effectiveTheme = $slide->createThemeEffective();
    echo $font->getFontName() . " -> " . $font->getFontName($effectiveTheme) . PHP_EOL;

    $explicitFont = new FontData("Verdana");
    echo $explicitFont->getFontName() . " -> " . $explicitFont->getFontName($effectiveTheme) . PHP_EOL;
} finally {
    $presentation->dispose();
}
```

ผลลัพธ์คือ `+mn-lt -> Calibri` ตามด้วย `Verdana -> Verdana` การอ้างอิงที่เก็บอยู่ยังคงไม่เปลี่ยนแปลง ในขณะที่ชื่อครอบครัวที่ระบุโดยตรงจะถูกคืนค่าไว้ หากส่วนนี้ใช้ `+mj-lt` จะตีความเป็น `Arial` ในธีมนี้

การตีความการอ้างอิงธีมจะบอกฟอนต์ครอบครัวที่ธีกําหนด ไม่ได้ตรวจสอบว่าฟอนต์นั้นพร้อมใช้หรือระบุไฟล์ฟอนต์ที่ใช้จริงหลังจากการแทนที่หรือการ fallback ของ glyph ระหว่างการเรนเดอร์ ดูที่ [Font Selection Sequence](/slides/th/php-java/font-selection-sequence/) และ [Font Substitution](/slides/th/php-java/font-substitution/) สำหรับขั้นตอนแยกต่างหากเหล่านี้

## **คัดลอกหรือใช้ธีม**

ขั้นตอนต่อไปนี้แก้ไขปัญหาที่เกี่ยวข้องกับธีมต่าง ๆ

### **ใช้ธีมภายนอกกับสไลด์ที่ขึ้นอยู่กับมาสเตอร์**

ใช้ [MasterSlide::applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/php-java/aspose.slides/masterslide/) เมื่อคุณมีไฟล์ธีม PowerPoint (`.thmx`) และต้องการปรับสไตล์ทุกสไลด์ที่ขึ้นอยู่กับมาสเตอร์เฉพาะ เลือกมาสเตอร์จากคอลเล็กชัน [Presentation::getMasters](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) ซึ่งเป็นตัวแทนโดย [MasterSlideCollection](https://reference.aspose.com/slides/php-java/aspose.slides/masterslidecollection/) แล้วส่งพาธไฟล์ธีมไปยังเมธอด

เมธอดทำงานต่อไปนี้:

1. สร้างมาสเตอร์สไลด์ใหม่โดยอิงจากมาสเตอร์ที่เลือก
1. ใช้ธีมภายนอกกับมาสเตอร์ใหม่
1. กำหนดมาสเตอร์ใหม่ให้กับสไลด์ทั้งหมดที่เคยขึ้นอยู่กับมาสเตอร์ที่เลือก
1. คืนค่า [MasterSlide](https://reference.aspose.com/slides/php-java/aspose.slides/masterslide/) ที่สร้างใหม่

ตัวอย่างต่อไปนี้ใช้ธีมภายนอกกับสไลด์ที่ขึ้นอยู่กับมาสเตอร์แรกและบันทึกงานนำเสนอ:

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

ธีมที่ไม่ถูกต้อง, เสียหาย, หรือไม่รองรับอาจทำให้เกิด [PptxReadException](https://reference.aspose.com/slides/php-java/aspose.slides/pptxreadexception/) ตรวจสอบพาธที่ผู้ใช้ระบุ, จัดการข้อผิดพลาดการเข้าถึงระบบไฟล์, และบันทึกงานนำเสนอเฉพาะหลังจากธีมถูกนำไปใช้สำเร็จ

เฉพาะสไลด์ที่ขึ้นอยู่กับมาสเตอร์ที่เลือกเท่านั้นที่ถูกกำหนดใหม่ สไลด์ที่เชื่อมโยงกับมาสเตอร์อื่นจะคงมาสเตอร์และธีมเดิมไว้ สี, ฟอนต์, การเติม, เส้น, พื้นหลัง, และเอฟเฟกต์ที่รับรู้ธีมจะอิงกับธีมภายนอก สีหรือฟอนต์ที่กำหนดโดยตรงอาจคงอยู่ การเขียนทับระดับเลเอาต์และระดับสไลด์อาจมีลำดับความสำคัญเหนือค่าที่สืบทอดจากมาสเตอร์ใหม่

ธีมอาจอ้างอิงฟอนต์ที่ไม่มีในสภาพแวดล้อมรันไทม์ เพื่อให้การเรนเดอร์และการส่งออกสอดคล้องกัน ให้ติดตั้งฟอนต์ที่จำเป็น, ให้บริการผ่าน [custom font sources](/slides/th/php-java/custom-font/), หรือกำหนด [font substitution](/slides/th/php-java/font-substitution/)

นี่เป็นขั้นตอนการทำงานระดับมาสเตอร์โดยตรง: เมธอดรับพาธไฟล์ `.thmx` และไม่ต้องสร้างการเขียนทับธีมระดับสไลด์หรือเลเอาต์ด้วยตนเอง

### **ใช้ธีมภายนอกต่าง ๆในงานนำเสนอหลายมาสเตอร์**

เมื่อไม่ทราบมาสเตอร์ที่เกี่ยวข้องล่วงหน้า ให้ดึงมาสเตอร์นั้นจากสไลด์ตัวอย่างผ่าน [Slide::getLayoutSlide](https://reference.aspose.com/slides/php-java/aspose.slides/slide/) และ [LayoutSlide::getMasterSlide](https://reference.aspose.com/slides/php-java/aspose.slides/layoutslide/) เก็บอ้างอิงมาสเตอร์เดิมก่อนทำการใช้ธีมใด ๆ เนื่องจากแต่ละการเรียกจะสร้างมาสเตอร์ใหม่ในงานนำเสนอ

ตัวอย่างต่อไปนี้ใช้สไลด์จากสองส่วนเพื่อระบุมาสเตอร์ของพวกมันและใช้ธีมภายนอกที่แตกต่างกันกับแต่ละกลุ่ม:

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

การเรียกครั้งแรกมีผลต่อสไลด์ที่ขึ้นอยู่กับ `$firstGroupMaster` เท่านั้น, การเรียกครั้งที่สองมีผลต่อสไลด์ที่ขึ้นอยู่กับ `$secondGroupMaster` เท่านั้น สไลด์ที่เชื่อมโยงกับมาสเตอร์อื่นจะไม่ถูกปรับสไตล์

### **รักษาธีมต้นฉบับเมื่อย้ายสไลด์**

หากต้องการย้ายสไลด์ไปยังงานนำเสนออื่นและคงการออกแบบเดิม ให้คัดลอกมาสเตอร์ต้นฉบับไปยังงานนำเป้าหมายด้วย [MasterSlideCollection::addClone](https://reference.aspose.com/slides/php-java/aspose.slides/masterslidecollection/) จากนั้นคัดลอกสไลด์ด้วย [SlideCollection::addClone](https://reference.aspose.com/slides/php-java/aspose.slides/slidecollection/) และมาสเตอร์ที่คัดลอกมา วิธีนี้จะนำมาสเตอร์, เลเอาต์, และธีมที่เกี่ยวข้องมาด้วยกัน

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

นี่เป็นขั้นตอนที่แนะนำเมื่อสไลด์ต้นฉบับต้องดูเหมือนเดิมในปลายทาง การคัดลอกเนื้อหาไปยังมาสเตอร์ปลายทางที่ไม่มีความสัมพันธ์อาจทำให้สี, ฟอนต์, พื้นหลัง, และเอฟเฟกต์ที่อิงธีมเปลี่ยนไป

### **ใช้ค่าธีมกับสไลด์ที่มีอยู่**

หากสไลด์เป้าหมายต้องคงอยู่บนมาสเตอร์และเลเอาต์ปัจจุบัน ให้เริ่มการเขียนทับระดับสไลด์จากธีมต้นฉบับ เมธอด [OverrideTheme::initColorSchemeFrom](https://reference.aspose.com/slides/php-java/aspose.slides/overridetheme/), [OverrideTheme::initFontSchemeFrom](https://reference.aspose.com/slides/php-java/aspose.slides/overridetheme/), และ [OverrideTheme::initFormatSchemeFrom](https://reference.aspose.com/slides/php-java/aspose.slides/overridetheme/) คัดลอกส่วนประกอบธีมหลักสามส่วนเข้าสู่การเขียนทับ

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

การทำเช่นนี้เปลี่ยนธีมที่สไลด์ใช้โดยไม่กระทบธีมที่สืบทอดโดยสไลด์อื่น ๆ เพื่อเอาการเขียนทับท้องถิ่นออกและกลับสู่ค่าที่สืบทอด ให้เรียก [OverrideTheme::clear](https://reference.aspose.com/slides/php-java/aspose.slides/overridetheme/)

### **ใช้การเขียนทับธีมกับเลเอาต์**

การเขียนทับระดับเลเอาต์จะใช้กับสไลด์ที่ใช้เลเอาต์นั้น เว้นแต่สไลด์ใด ๆ จะมีการเขียนทับของตนเอง วิธีการเริ่มต้นเดียวกันสามารถใช้ผ่าน [LayoutSlideThemeManager](https://reference.aspose.com/slides/php-java/aspose.slides/layoutslidethememanager/):

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

ใช้ธีมระดับมาสเตอร์หรือระดับงานนำเสนอเมื่อหลายเลเอาต์และสไลด์ต้องการใช้การออกแบบฐานเดียวกัน, ใช้การเขียนทับเลเอาต์เมื่อครอบครัวเลเอาต์หนึ่งต้องการสไตล์ที่แตกต่าง, และใช้การเขียนทับสไลด์เฉพาะเมื่อเป็นข้อยกเว้นจริง ๆ การเขียนทับระดับสไลด์มากเกินไปทำให้การเปลี่ยนแปลงธีมทั่วโลกในภายหลังคาดเดายาก

## **อัปเดตสไตล์พื้นหลังของธีม**

การเติมพื้นหลังของธีมถูกจัดเก็บใน [FormatScheme::getBackgroundFillStyles](https://reference.aspose.com/slides/php-java/aspose.slides/formatscheme/) PowerPoint สามารถแสดงตัวเลือกพื้นหลังมากกว่าที่มีการกำหนดในคอลเล็กชันนี้ เนื่องจาก UI สามารถผสานการเติมธีมกับสีธีมและการอ้างอิงสไตล์อื่น ๆ

![แกลเลอรีสไตล์พื้นหลังของ PowerPoint สำหรับธีมงานนำเสนอ](presentation-design_8.png)

ก่อนใช้สไตล์พื้นหลัง, ตรวจสอบคอลเล็กชันที่จัดเก็บและค่า [Background::getStyleIndex](https://reference.aspose.com/slides/php-java/aspose.slides/background/) ปัจจุบัน ดัชนีสไตล์ `0` หมายถึงไม่มีการเติมธีม; ค่าบวกเป็นการอ้างอิงสไตล์พื้นหลังของธีม ซึ่งต่างจากการทำดัชนีคอลเล็กชัน PHP โดยตรงที่ `get_Item(0)` หมายถึงรายการแรกที่จัดเก็บ อย่าสมมติว่าทุกงานนำเสนอมีจำนวนสไตล์เติมพื้นหลังเท่าเดียวกัน

ตัวอย่างต่อไปนี้รายงานจำนวนการเติมพื้นหลังที่มี, กำหนดการอ้างอิงพื้นหลังธีมให้กับมาสเตอร์แรก, และบันทึกงานนำเสนอ:

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

ผลลัพธ์ที่มองเห็นขึ้นอยู่กับรายการธีมที่มาสเตอร์อ้างอิงและการเขียนทับพื้นหลังที่เลเออต์หรือสไลด์ หากสไลด์ใช้พื้นหลังของตนเอง การเปลี่ยนเฉพาะพื้นหลังมาสเตอร์อาจไม่ทำให้สไลด์นั้นเปลี่ยน ใช้ [Background::getEffective](https://reference.aspose.com/slides/php-java/aspose.slides/background/) เมื่อคุณต้องการทราบพื้นหลังสุดท้ายหลังจากการสืบทอดถูกนำไปใช้

{{% alert color="warning" title="Warning" %}}
อย่าอ้างอิงดัชนีสไตล์เป็นดัชนีคอลเล็กชันที่เริ่มจากศูนย์ และหลีกเลี่ยงการกำหนดหมายเลขสไตล์จากไฟล์หนึ่งแล้วสมมติว่ามีลักษณะเดียวกันในอีกไฟล์หนึ่ง; การกำหนดสไตล์ธีมเป็นลักษณะเฉพาะของงานนำเสนอ
{{% /alert %}}

{{% alert color="info" title="Tip" %}}
สำหรับการจัดรูปแบบพื้นหลังโดยตรงและการสืบทอดพื้นหลัง ดูที่ [Presentation Background](/slides/th/php-java/presentation-background/)
{{% /alert %}}

## **อัปเดตเอฟเฟกต์ของธีม**

โครงการรูปแบบธีมประกอบด้วยคอลเล็กชันการเติม, เส้น, และเอฟเฟกต์ที่แยกกัน ซึ่งเปิดเผยผ่าน [FormatScheme::getFillStyles](https://reference.aspose.com/slides/php-java/aspose.slides/formatscheme/), [FormatScheme::getLineStyles](https://reference.aspose.com/slides/php-java/aspose.slides/formatscheme/), และ [FormatScheme::getEffectStyles](https://reference.aspose.com/slides/php-java/aspose.slides/formatscheme/) ธีมของ Office ส่วนใหญ่มีรายการสไตล์หลักสามรายการที่ตรงกับการจัดรูปแบบแบบละเอียด, ปานกลาง, และเข้ม อย่างไรก็ตามโค้ดควรตรวจสอบแต่ละคอลเล็กชันแทนการสมมติว่ามีจำนวนคงที่

![เอฟเฟกต์ธีมแบบละเอียด, ปานกลาง, และเข้มที่ใช้กับรูปเดียวกัน](presentation-design_10.png)

เมื่อเข้าถึงคอลเล็กชันเหล่านี้ใน PHP ดัชนีคอลเล็กชันเริ่มจากศูนย์: `get_Item(0)` คือสไตล์แรกที่จัดเก็บและ `get_Item(2)` คือสไตล์ที่สาม Shape’s style‑reference indexes เป็นแนวคิดแยกที่เผยผ่าน [ShapeStyle](https://reference.aspose.com/slides/php-java/aspose.slides/shapestyle/) การแก้ไขสไตล์ธีมจะส่งผลต่อรูปที่อ้างอิงสไตล์ธีมนั้น; รูปที่มีการจัดรูปแบบโดยตรงอาจคงเดิม

ตัวอย่างต่อไปนี้ตรวจสอบว่ามีรายการสไตล์ที่ต้องการหรือไม่, เปลี่ยนสไตล์เส้นแรก, เปลี่ยนสไตล์การเติมที่สาม, เปิดใช้งานเงานอกในสไตล์เอฟเฟกต์ที่สาม, และบันทึกผลลัพธ์:

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

สำหรับรูปที่อ้างอิงช่องเหล่านี้ สไตล์เส้นธีมแรกจะกลายเป็นสีแดง, สไตล์การเติมธีมที่สามจะเป็นสีเขียวป่าแบบทึบ, และสไตล์เอฟเฟกต์ที่สามจะเพิ่มเงานอกระยะ 10 pt ผลลัพธ์ภาพที่แน่นอนยังคงขึ้นกับว่ารูปใดอ้างอิงช่องสไตล์ใดและการจัดรูปแบบโดยตรงอาจเขียนทับธีมหรือไม่

![สไตล์เอฟเฟกต์ธีมหลังจากเปลี่ยนการตั้งค่าเส้น, การเติม, และเงา](presentation-design_11.png)

## **เลือกสไตล์เติมและเส้นของธีมสำหรับรูปร่าง**

รูปร่างสามารถเลือกการเติมและขอบโดยอิสระผ่าน [ShapeStyle::setFillStyleIndex](https://reference.aspose.com/slides/php-java/aspose.slides/shapestyle/#setFillStyleIndex) และ [ShapeStyle::setLineStyleIndex](https://reference.aspose.com/slides/php-java/aspose.slides/shapestyle/#setLineStyleIndex) สำหรับเมธอดใด ๆ ดัชนี `1` เลือกรายการแรกในคอลเล็กชันธีมที่สอดคล้อง (`get_Item(0)`), และดัชนี `2` เลือกรายการที่สอง (`get_Item(1)`)

ตัวอย่างต่อไปนี้ตั้งค่าสไตล์เติมสองแบบ (สีทองและสีฟ้าอ่อน) และสไตล์เส้นสองแบบ (สีน้ำเงินเข้ม 6 pt และสีแดงเข้ม 12 pt) ในธีมเริ่มต้นของงานนำเสนอใหม่ จากนั้นบันทึกสไลด์ในสามขั้นตอนเพื่อให้คุณเปรียบเทียบผลใน PowerPoint

```php
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $styles = $presentation->getMasterTheme()->getFormatScheme();

    $goldFill = $styles->getFillStyles()->get_Item(0);
    $goldFill->setFillType(FillType::Solid);
    $goldFill->getSolidFillColor()->setColor(new Java("java.awt.Color", 255, 215, 0));
    $blueFill = $styles->getFillStyles()->get_Item(1);
    $blueFill->setFillType(FillType::Solid);
    $blueFill->getSolidFillColor()->setColor(new Java("java.awt.Color", 135, 206, 235));

    $thinLine = $styles->getLineStyles()->get_Item(0);
    $thinLine->getFillFormat()->setFillType(FillType::Solid);
    $thinLine->getFillFormat()->getSolidFillColor()->setColor(new Java("java.awt.Color", 0, 0, 139));
    $thinLine->setWidth(6);
    $thickLine = $styles->getLineStyles()->get_Item(1);
    $thickLine->getFillFormat()->setFillType(FillType::Solid);
    $thickLine->getFillFormat()->getSolidFillColor()->setColor(new Java("java.awt.Color", 139, 0, 0));
    $thickLine->setWidth(12);

    $shapes = $presentation->getSlides()->get_Item(0)->getShapes();
    $left = $shapes->addAutoShape(ShapeType::Rectangle, 100, 205, 200, 130);
    $right = $shapes->addAutoShape(ShapeType::Rectangle, 420, 205, 200, 130);
    $left->getShapeStyle()->setFillStyleIndex(1);
    $right->getShapeStyle()->setFillStyleIndex(2);
    $left->getShapeStyle()->setLineStyleIndex(1);
    $right->getShapeStyle()->setLineStyleIndex(1);
    $presentation->save("01-initial.pptx", SaveFormat::Pptx);

    $right->getShapeStyle()->setLineStyleIndex(2);
    $presentation->save("02-line-changed.pptx", SaveFormat::Pptx);

    $goldFill->getSolidFillColor()->setColor(new Java("java.awt.Color", 46, 139, 87));
    $presentation->save("03-theme-changed.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

| สไตล์เริ่มต้น | เปลี่ยนขอบด้านขวา | แก้ไขการเติมธีมแรก |
|:---:|:---:|:---:|
| ![สี่เหลี่ยมสีทองและสีฟ้าอ่อนกับขอบสีน้ำเงินเข้มเรียบบางที่ตรงกัน](theme-style-initial.png) | ![สี่เหลี่ยมสีฟ้าอ่อนตอนนี้มีขอบสีแดงเข้มหนา](theme-style-line-changed.png) | ![สี่เหลี่ยมทางซ้ายตอนนี้เป็นสีเขียวและขอบทั้งสองคงเดิม](theme-style-fill-changed.png) |

การเลือกสไตล์เส้นที่ต่างกันจะเปลี่ยนเฉพาะขอบของสี่เหลี่ยมขวา การแก้ไขการเติมธีมแรกจะอัพเดตทุกรูปที่ใช้มัน ที่นี่เพียงสี่เหลี่ยมซ้ายเท่านั้นที่เปลี่ยนเป็นสีเขียว

บนรูปที่มีอยู่แล้ว สีเติมท้องถิ่น, สีเส้น, หรือความกว้างเส้นสามารถเขียนทับส่วนของสไตล์ธีมนั้นได้ หากการเปลี่ยนดัชนีสไตล์ไม่มีผลปรากฏ ตรวจสอบ [direct formatting](/slides/th/php-java/shape-formatting/) ของรูป

## **ตรวจสอบว่าการเติมสีทึบที่ได้ผลใช้สีธีมหรือไม่**

การเติมอาจถูกจัดเก็บโดยตรงบนวัตถุหรือสืบทอดจากย่อหน้า, เลเอาต์, มาสเตอร์, สไตล์ธีม, หรือระดับการจัดรูปแบบอื่น เรียก [FillFormat::getEffective](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/) เพื่อแก้ไขลำดับชั้นนั้นเป็นข้อมูลการเติมที่คงที่ หลังจากนั้นตรวจสอบผลลัพธ์ `getFillType` เพียงเมื่อเป็น `FillType::Solid` จึงอ่านคุณสมบัติการเติมสีทึบ

สำหรับการเติมสีทึบ `getSolidFillColor` คืนค่ารหัส RGB สุดท้ายหลังจากสืบทอด, การค้นหาธีม, และการแปลงสี `getSolidFillSchemeColor` คืนค่าช่อง [SchemeColor](https://reference.aspose.com/slides/php-java/aspose.slides/schemecolor/) ตรงกัน เช่น `Text1` หรือ `Accent6` ค่า `SchemeColor::NotDefined` หมายความว่าการเติมสีทึบที่ได้ผลไม่ได้อิงจากสีสคีม ในเวิร์กฟลว์ที่เติมเป็นสีธีมหรือสี RGB โดยตรง ค่านี้จะแยกเป็นการเติมสี RGB โดยตรง

อย่าใช้ค่า [ColorFormat::getSchemeColor](https://reference.aspose.com/slides/php-java/aspose.slides/colorformat/) ของระดับท้องถิ่นเพียงอย่างเดียวเพื่อจำแนกการเติม ตัวอย่างเช่น ส่วนข้อความอาจไม่มีสีสคีมที่กำหนดในระดับท้องถิ่น ดังนั้นค่าท้องถิ่นจะเป็น `NotDefined` ในขณะที่การเติมที่ได้ผลสืบทอดสีธีมและแก้เป็น `Text1` หรือ `Accent6` ตรงกันข้าม `getSolidFillSchemeColor` บอกว่าช่องธีมเชิงตรรกะใดสร้างสีที่ได้ผล แต่ไม่บอกว่าช่องนั้นมาจากวัตถุ, ย่อหน้า, เลเอาต์, มาสเตอร์ หรือระดับอื่นของลำดับชั้นการจัดรูปแบบ

ตัวอย่างต่อไปนี้โหลดงานนำเสนอ, ตรวจสอบการเติมของรูปและการเติมของส่วนข้อความ, พิมพ์ค่า RGB สุดท้ายและสคีมที่เกี่ยวข้อง, และทำเครื่องหมายการเติมสีทึบที่ไม่ติดตามการเปลี่ยนแปลงสีธีม:

```php
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SchemeColor;

$auditFill = function (string $objectName, $localFill): void {
    $effectiveFill = $localFill->getEffective();

    if (java_values($effectiveFill->getFillType()) != FillType::Solid) {
        echo $objectName . ": fill type = " . java_values($effectiveFill->getFillType()) . "; not a solid fill." . PHP_EOL;
        return;
    }

    $rgb = $effectiveFill->getSolidFillColor();
    $effectiveSchemeColor = java_values($effectiveFill->getSolidFillSchemeColor());
    $localSchemeColor = java_values($localFill->getSolidFillColor()->getSchemeColor());

    echo sprintf("%s: RGB = #%02X%02X%02X", $objectName, java_values($rgb->getRed()), java_values($rgb->getGreen()), java_values($rgb->getBlue())) . PHP_EOL;
    echo $objectName . ": local scheme = " . $localSchemeColor . ", effective scheme = " . $effectiveSchemeColor . PHP_EOL;

    if ($effectiveSchemeColor == SchemeColor::NotDefined) {
        echo $objectName . ": direct RGB or another non-scheme fill; audit as theme-independent." . PHP_EOL;
    } else {
        echo $objectName . ": theme-dependent through " . $effectiveSchemeColor . "." . PHP_EOL;
    }
};

$autoShapeClass = new JavaClass("com.aspose.slides.AutoShape");
$presentation = new Presentation("input.pptx");
try {
    $slideCount = java_values($presentation->getSlides()->size());
    for ($slideIndex = 0; $slideIndex < $slideCount; $slideIndex++) {
        $slide = $presentation->getSlides()->get_Item($slideIndex);

        $shapeCount = java_values($slide->getShapes()->size());
        for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
            $shape = $slide->getShapes()->get_Item($shapeIndex);
            $shapeName = "Slide " . ($slideIndex + 1) . ", shape " . ($shapeIndex + 1);
            $auditFill($shapeName, $shape->getFillFormat());

            if (java_instanceof($shape, $autoShapeClass)) {
                $paragraphCount = java_values($shape->getTextFrame()->getParagraphs()->getCount());
                for ($paragraphIndex = 0; $paragraphIndex < $paragraphCount; $paragraphIndex++) {
                    $paragraph = $shape->getTextFrame()->getParagraphs()->get_Item($paragraphIndex);

                    $portionCount = java_values($paragraph->getPortions()->getCount());
                    for ($portionIndex = 0; $portionIndex < $portionCount; $portionIndex++) {
                        $portion = $paragraph->getPortions()->get_Item($portionIndex);
                        $portionName = $shapeName . ", paragraph " . ($paragraphIndex + 1) . ", portion " . ($portionIndex + 1);
                        $auditFill($portionName, $portion->getPortionFormat()->getFillFormat());
                    }
                }
            }
        }
    }
} finally {
    $presentation->dispose();
}
```

สาขา `NotDefined` ให้รายการตรวจสอบของการเติมสีทึบที่ไม่ตอบสนองต่อการเปลี่ยนแปลงช่องสีธีม ตรวจสอบวัตถุเหล่านั้นเมื่องานนำเสนอจำเป็นต้องสอดคล้องกับพาเล็ตแบรนด์ใหม่ ค่า RGB ที่รายงานยังแสดงลักษณะปัจจุบัน ส่วนค่าสคีมอธิบายว่าลักษณะนั้นเชื่อมต่อกับธีมหรือไม่

วัตถุที่ได้ผลเป็นสแนปชอต หลังจากเปลี่ยนธีมงานนำเสนอ, การเขียนทับธีมหรือการจัดรูปแบบที่สืบทอดใด ๆ ให้เรียก `getEffective` อีกครั้งและอ่านข้อมูลการเติมที่ได้ผลใหม่ก่อนทำการเปรียบเทียบหรือรายงานสี

## **อ่านค่าธีมที่ได้ผล**

วัตถุธีมดิบบอกสิ่งที่กำหนดที่ระดับใดระดับหนึ่ง ค่าที่ได้ผลบอกสิ่งที่สไลด์หรือรูปใช้จริงหลังจากสืบทอดและการเขียนทับท้องถิ่นได้รับการแก้ไข สำหรับสไลด์ ให้เรียก [BaseOverrideThemeManager::createThemeEffective](https://reference.aspose.com/slides/php-java/aspose.slides/baseoverridethememanager/) สำหรับพื้นหลัง ใช้ [Background::getEffective](https://reference.aspose.com/slides/php-java/aspose.slides/background/) และสำหรับการเติม ใช้ [FillFormat::getEffective](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/)

ตัวอย่างต่อไปนี้อ่านธีมที่ได้ผล, พื้นหลัง, และการเติมรูปแรกจากสไลด์:

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

ใช้ข้อมูลที่ได้ผลสำหรับการวินิจฉัยการเรนเดอร์, การตรวจสอบคุณภาพ, และการเปรียบเทียบ หากคุณตรวจสอบเฉพาะ [Presentation::getMasterTheme](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) อาจพลาดการเขียนทับที่มาจากมาสเตอร์, เลเอาต์, สไลด์, หรือรูปที่เปลี่ยนลักษณะสุดท้าย

## **คำถามที่พบบ่อย**

**การใช้ธีมภายนอกมีผลต่อทุกสไลด์ในงานนำเสนอหรือไม่?**

ไม่. [MasterSlide::applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/php-java/aspose.slides/masterslide/) จะกำหนดใหม่เฉพาะสไลด์ที่ขึ้นกับมาสเตอร์ที่เลือก สไลด์ที่ใช้มาสเตอร์อื่นจะคงธีมเดิม

**ฉันสามารถใช้ธีมกับสไลด์เดียวโดยไม่เปลี่ยนมาสเตอร์ได้หรือไม่?**

ได้. ใช้ [SlideThemeManager](https://reference.aspose.com/slides/php-java/aspose.slides/slidethememanager/) ของสไลด์และเริ่มต้นการเขียนทับธีม การเปลี่ยนแปลงจะอยู่เฉพาะสไลด์นั้น; สไลด์อื่น ๆ ยังคงสืบทอดธีมเดิม

**วิธีที่ปลอดภัยที่สุดในการพาธีมจากงานนำเสนอหนึ่งไปยังงานนำเสนออื่นคืออะไร?**

เมื่อย้ายสไลด์และคงลักษณะต้นฉบับ, ให้คัดลอกมาสเตอร์ต้นฉบับไปยังปลายทางและคัดลอกสไลด์ด้วยมาสเตอร์นั้นโดยใช้ [MasterSlideCollection::addClone](https://reference.aspose.com/slides/php-java/aspose.slides/masterslidecollection/) และ [SlideCollection::addClone](https://reference.aspose.com/slides/php-java/aspose.slides/slidecollection/) วิธีนี้ทำให้มาสเตอร์, เลเอาต์, และธีมอยู่ด้วยกัน

**ฉันจะดูค่าที่ได้ผลหลังจากสืบทอดและการเขียนทับได้อย่างไร?**

ใช้ [BaseOverrideThemeManager::createThemeEffective](https://reference.aspose.com/slides/php-java/aspose.slides/baseoverridethememanager/) สำหรับสไลด์หรือธีมเลเอาต์ และเมธอดข้อมูลที่ได้ผลที่สอดคล้องสำหรับวัตถุรูปแบบเช่น [Background::getEffective](https://reference.aspose.com/slides/php-java/aspose.slides/background/) และ [FillFormat::getEffective](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/) API เหล่านี้จะคืนค่าที่แก้ไขแล้วหลังจากสืบทอดและการเขียนทับถูกนำไปใช้