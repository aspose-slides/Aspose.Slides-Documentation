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
description: "ธีมการนำเสนอหลักใน Aspose.Slides สำหรับ PHP ผ่าน Java เพื่อสร้าง ปรับแต่ง และแปลงไฟล์ PowerPoint ด้วยการสร้างแบรนด์ที่สม่ำเสมอ."
---
## **บทนำ**

ธีมของการนำเสนอกำหนดชุดสี, ตัวอักษร, รูปแบบพื้นหลัง, การเติม, เส้น และเอฟเฟกต์ที่ประสานกัน ธีมที่อิงวัตถุจะอ้างอิงถึงคำนิยามที่ใช้ร่วมกันเหล่านี้ แทนการเก็บคุณสมบัติภาพแต่ละอย่างเป็นค่าคงที่ ดังนั้นการเปลี่ยนธีมจึงสามารถอัปเดตวัตถุหลาย ๆ ตัวพร้อมกัน

ใน Aspose.Slides ธีมระดับการนำเสนอสามารถเข้าถึงได้ผ่าน [Presentation.getMasterTheme](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentation/)。การนำเสนออาจมีการละเมิดธีมในระดับที่ต่ำกว่า มาสเตอร์สามารถละเมิดธีมของการนำเสนอผ่าน [MasterThemeManager.getOverrideTheme](https://reference.aspose.com/slides/th/php-java/aspose.slides/masterthememanager/)，ในขณะที่เลเอาต์หรือสไลด์เดี่ยวสามารถละเมิดธีมที่สืบทอดมาผ่าน [BaseOverrideThemeManager.getOverrideTheme](https://reference.aspose.com/slides/th/php-java/aspose.slides/baseoverridethememanager/)。โดยปฏิบัติ ธีมที่มีผลสำหรับสไลด์หนึ่งจะได้รับการกำหนดผ่านโซ่การสืบทอดนี้: ธีมการนำเสนอ → มาสเตอร์ละเมิด → เลเอาต์ละเมิด → สไลด์ละเมิด

![Theme components: colors, fonts, background styles, and effects](theme-constituents.png)

ส่วนต่อไปนี้แสดงกระบวนการทำงานกับธีมที่พบบ่อยที่สุด: การตรวจสอบธีม, การเปลี่ยนสีและตัวอักษร, การคัดลอกหรือใช้ธีม, การอัปเดตสไตล์พื้นหลังและเอฟเฟกต์, และการอ่านค่าที่มีผลหลังจากการสืบทอดและการละเมิดได้รับการประมวลผล

## **ตรวจธีม**

อ็อบเจ็กต์ [MasterTheme](https://reference.aspose.com/slides/th/php-java/aspose.slides/mastertheme/) เปิดเผยสคีมสี, สคีมตัวอักษร, และสคีมรูปแบบของธีมผ่าน [MasterTheme.getColorScheme](https://reference.aspose.com/slides/th/php-java/aspose.slides/mastertheme/), [MasterTheme.getFontScheme](https://reference.aspose.com/slides/th/php-java/aspose.slides/mastertheme/), และ [MasterTheme.getFormatScheme](https://reference.aspose.com/slides/th/php-java/aspose.slides/mastertheme/)。การตรวจสอบคอลเลกชันเหล่านี้ก่อนทำการเปลี่ยนแปลงมีประโยชน์เป็นพิเศษเมื่อการนำมาจากแหล่งภายนอก เนื่องจากจำนวนและเนื้อหาของรายการสไตล์อาจแตกต่างกัน

ตัวอย่างต่อไปนี้อ่านคุณสมบัติหลักของธีมและรายงานจำนวนสไตล์พื้นหลัง, การเติม, เส้น, และเอฟเฟกต์ที่จัดเก็บในธีม:

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

หากไฟล์ใช้หลายมาสเตอร์ อย่าอ assuming ว่าสไลด์ทุกสไลด์มีธีมที่มีผลเดียวกัน ตรวจสอบมาสเตอร์ที่เชื่อมโยงกับสไลด์ และใช้กระบวนการทำงานของธีมที่มีผลที่แสดงต่อไปนี้เมื่ออาจมีการละเมิดเลเอาต์หรือสไลด์

## **เปลี่ยนสีธีม**

การเติม, เส้น, และข้อความที่อิงธีมสามารถอ้างอิงสีเชิงตรรกะจาก enumeration [SchemeColor](https://reference.aspose.com/slides/th/php-java/aspose.slides/schemecolor/) เมื่อคุณเปลี่ยนรายการที่สอดคล้องใน [ColorScheme](https://reference.aspose.com/slides/th/php-java/aspose.slides/colorscheme/)，วัตถุทั้งหมดที่ยังอ้างอิงสีธีมนั้นจะได้รับการแก้ไขด้วยค่าที่ใหม่ วัตถุที่ใช้สี RGB โดยตรงจะไม่เปลี่ยนแปลงจากการอัปเดตสีธีม

ตัวอย่างต่อไปนี้เป็นกระบวนการแบบต้นถึงปลายที่สร้างรูปทรงที่ใช้ `Accent4`, เปลี่ยนสี `Accent4` ของธีมเป็นสีแดง, บันทึกการนำเสนอ, เปิดใหม่อีกครั้ง, และพิมพ์สีการเติมที่มีผล:

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

เนื่องจากสี่เหลี่ยมยังคงเชื่อมโยงกับ `Accent4` สีที่มองเห็นจะกลายเป็นสีแดงหลังจากธีมถูกเปลี่ยน หากคุณแทนที่สีสกีมด้วยสีโดยตรงบนรูปทรง การเปลี่ยนแปลงต่อมาใน `Accent4` จะไม่มีผลต่อการเติมนั้น

### **ใช้สีจากพาเลตเพิ่มเติม**

PowerPoint สร้างเวอร์ชันสีอ่อนและเข้มจากสีธีมโดยใช้การแปลงสี Aspose.Slides เปิดเผยการแปลงเหล่านี้ผ่าน enumeration [ColorTransformOperation](https://reference.aspose.com/slides/th/php-java/aspose.slides/colortransformoperation/)

![Main theme colors and lighter and darker colors generated from the additional palette](additional-palette-colors.png)

**1** - สีธีมหลัก

**2** - เวอร์ชันสีอ่อนและเข้มที่สร้างจากสีธีมหลัก

ตัวอย่างต่อไปนี้สร้างสี่เหลี่ยมหกรูปโดยอิง `Accent4`, ใช้การแปลงความสว่างกับห้ารูป และบันทึกผลลัพธ์:

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

เวอร์ชันเหล่านี้ยังคงอิงสีธีม หาก `Accent4` เปลี่ยนในภายหลัง สีที่แปลงจะถูกคำนวณใหม่จากค่า `Accent4` ใหม่

### **แมปค่า `SchemeColor` ไปยังช่อง `ColorScheme`**

enumeration [SchemeColor](https://reference.aspose.com/slides/th/php-java/aspose.slides/schemecolor/) ใช้ `Text1`, `Background1`, `Text2`, และ `Background2` ส่วน [ColorScheme](https://reference.aspose.com/slides/th/php-java/aspose.slides/colorscheme/) เปิดเผยช่องธีมเดียวกันเป็น `Dark1`, `Light1`, `Dark2`, และ `Light2` การแมปเป็นค่าคงที่:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

เหล่านี้เป็นชื่อทางเลือกของช่องธีมเดียวกัน; ไม่ได้เป็นค่าที่แปลงแบบไดนามิกจากรูปแบบหนึ่งเป็นอีกรูปแบบหนึ่ง

## **เปลี่ยนฟอนต์ธีม**

สคีมฟอนต์ธีมประกอบด้วยชุดฟอนต์หลักสำหรับหัวเรื่องและชุดฟอนต์รองสำหรับข้อความ 본문 วิธี `FontScheme.getMajor` และ `FontScheme.getMinor` เปิดเผยชุดเหล่านั้น

ตัวระบุฟอนต์ธีมที่เข้ากันกับ PowerPoint สามารถใช้ในรูปแบบข้อความได้:

* `+mn‑lt` - ฟอนต์ 본문 Latin (Minor Latin Font)
* `+mj‑lt` - ฟอนต์หัวเรื่อง Latin (Major Latin Font)
* `+mn‑ea` - ฟอนต์ 본문 East Asian (Minor East Asian Font)
* `+mj‑ea` - ฟอนต์หัวเรื่อง East Asian (Major East Asian Font)

ตัวอย่างต่อไปนี้สร้างหัวเรื่องหนึ่งที่ใช้ฟอนต์ Latin หลักของธีมและบรรทัด 본문หนึ่งที่ใช้ฟอนต์ Latin รองของธีม จากนั้นเปลี่ยนฟอนต์ธีมและบันทึกผลลัพธ์:

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

หัวเรื่องตามฟอนต์หลักและข้อความ 본문ตามฟอนต์รอง ข้อความที่ระบุชื่อฟอนต์โดยตรงแทนตัวระบุธีมจะไม่สลับอัตโนมัติเมื่อสคีมฟอนต์ธีมเปลี่ยน

คอลเลกชันฟอนต์หลักและรองสามารถมีแมปฟอนต์สำหรับ ระบบการเขียนแบบเฉพาะ เช่น Cyrillic, Arabic, Japanese, Georgian, และ Thaana เพื่อตรวจสอบ, เพิ่ม, แทนที่ หรือเอาแมปเหล่านี้ออก ให้ดูที่ [Script‑Specific Theme Fonts](/slides/th/php-java/script-specific-font-mappings/)

{{% alert color="info" title="เคล็ดลับ" %}}
สำหรับข้อมูลเพิ่มเติมเกี่ยวกับฟอนต์การนำเสนอ ดูที่ [PowerPoint Fonts](/slides/th/php-java/powerpoint-fonts/)
{{% /alert %}}

## **คัดลอกหรือใช้ธีม**

กระบวนการต่อไปนี้แก้ปัญหาเรื่องธีมที่แตกต่างกัน

### **ใช้ธีมภายนอกกับสไลด์ที่ขึ้นอยู่กับมาสเตอร์**

ใช้ [MasterSlide::applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/th/php-java/aspose.slides/masterslide/) เมื่อคุณมีไฟล์ธีม PowerPoint (`.thmx`) และต้องการปรับสไตล์สไลด์ทุกสไลด์ที่ขึ้นอยู่กับมาสเตอร์เฉพาะ เลือกมาสเตอร์จากคอลเลกชัน [Presentation::getMasters](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentation/) ที่แสดงโดย [MasterSlideCollection](https://reference.aspose.com/slides/th/php-java/aspose.slides/masterslidecollection/), แล้วส่งพาธไฟล์ธีมไปยังเมธอด

เมธอดทำขั้นตอนต่อไปนี้:

1. สร้างมาสเตอร์สไลด์ใหม่จากมาสเตอร์ที่เลือก
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

ธีมที่ไม่ถูกต้อง, เสียหาย, หรือไม่รองรับอาจทำให้เกิด [PptxReadException](https://reference.aspose.com/slides/th/php-java/aspose.slides/pptxreadexception/) ตรวจสอบพาธที่ผู้ใช้ระบุ, จัดการความล้มเหลวในการเข้าถึงไฟล์ระบบ, และบันทึกการนำเสนอเฉพาะหลังจากธีมถูกใช้สำเร็จ

เฉพาะสไลด์ที่ขึ้นกับมาสเตอร์ที่เลือกเท่านั้นที่จะถูกกำหนดใหม่ สไลด์ที่เชื่อมกับมาสเตอร์อื่นจะรักษามาสเตอร์และธีมเดิมไว้ สี, ฟอนต์, การเติม, เส้น, พื้นหลัง, และเอฟเฟกต์ที่อิงธีมจะได้รับการแก้ไขตามธีมภายนอก สี, ฟอนต์, การเติมและการจัดรูปแบบที่กำหนดโดยตรงอาจไม่เปลี่ยน เลเอาต์‑ระดับและสไลด์‑ระดับที่ละเมิดอาจเหนือค่าที่สืบทอดจากมาสเตอร์ใหม่

ธีมอาจอ้างอิงฟอนต์ที่ไม่มีในสภาพแวดล้อมรันไทม์ เพื่อการเรนเดอร์และการส่งออกที่สอดคล้อง ให้ติดตั้งฟอนต์ที่จำเป็น, จัดหาให้ผ่าน [custom font sources](/slides/th/php-java/custom-font/), หรือกำหนดค่า [font substitution](/slides/th/php-java/font-substitution/)

นี่คือกระบวนการระดับมาสเตอร์โดยตรง: เมธอดรับพาธไฟล์ `.thmx` และไม่ต้องสร้างการละเมิดธีมระดับสไลด์หรือเลเอาต์ด้วยตนเอง

### **ใช้ธีมภายนอกต่างกันในงานนำเสนอหลายมาสเตอร์**

เมื่อมาสเตอร์ที่เกี่ยวข้องไม่ทราบล่วงหน้า ให้ดึงมาสเตอร์จากสไลด์เป็นตัวแทนผ่าน [Slide::getLayoutSlide](https://reference.aspose.com/slides/th/php-java/aspose.slides/slide/) และ [LayoutSlide::getMasterSlide](https://reference.aspose.com/slides/th/php-java/aspose.slides/layoutslide/) เก็บอ้างอิงมาสเตอร์เดิมก่อนใช้ธีมใด ๆ เพราะแต่ละครั้งที่เรียกจะสร้างมาสเตอร์ใหม่ในงานนำเสนอ

ตัวอย่างต่อไปนี้ใช้สไลด์จากสองส่วนเพื่อค้นหามาสเตอร์ของพวกมันและใช้ธีมภายนอกที่แตกต่างกันกับแต่ละกลุ่ม:

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

การเรียกครั้งแรกมีผลต่อสไลด์ที่ขึ้นกับ `$firstGroupMaster` เท่านั้น, การเรียกครั้งที่สองมีผลต่อสไลด์ที่ขึ้นกับ `$secondGroupMaster` เท่านั้น สไลด์ที่เชื่อมกับมาสเตอร์อื่นไม่ได้รับการปรับสไตล์

### **รักษาธีมต้นฉบับเมื่อย้ายสไลด์**

หากต้องการย้ายสไลด์ไปยังงานนำเสนออื่นและรักษาการออกแบบเดิมไว้ ให้คัดลอกมาสเตอร์ต้นฉบับไปยังงานนำหมายด้วย [MasterSlideCollection.addClone](https://reference.aspose.com/slides/th/php-java/aspose.slides/masterslidecollection/), แล้วคัดลอกสไลด์ด้วย [SlideCollection.addClone](https://reference.aspose.com/slides/th/php-java/aspose.slides/slidecollection/) พร้อมมาสเตอร์ที่คัดลอกไว้ วิธีนี้จะนำมาสเตอร์, เลเอาต์, และธีมที่เกี่ยวข้องไปด้วย

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

นี่เป็นกระบวนการที่แนะนำเมื่อสไลด์ต้นทางต้องแสดงผลเหมือนเดิมในปลายทาง การคัดลอกเนื้อหาไปยังมาสเตอร์ปลายทางที่ไม่เกี่ยวข้องอาจทำให้สี, ฟอนต์, พื้นหลัง, และเอฟเฟกต์ที่ขับเคลื่อนด้วยธีมเปลี่ยนแปลง

### **ใช้ค่าธีมกับสไลด์ที่มีอยู่**

หากสไลด์เป้าหมายต้องคงอยู่บนมาสเตอร์และเลเอาต์ปัจจุบัน ให้เริ่มการละเมิดระดับสไลด์จากธีมต้นทาง เมธอด [OverrideTheme.initColorSchemeFrom](https://reference.aspose.com/slides/th/php-java/aspose.slides/overridetheme/), [OverrideTheme.initFontSchemeFrom](https://reference.aspose.com/slides/th/php-java/aspose.slides/overridetheme/), และ [OverrideTheme.initFormatSchemeFrom](https://reference.aspose.com/slides/th/php-java/aspose.slides/overridetheme/) คัดลอกส่วนสำคัญสามส่วนของธีมเข้าสู่การละเมิด

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

วิธีนี้เปลี่ยนธีมที่สไลด์นั้นใช้โดยไม่กระทบธีมที่สืบทอดโดยสไลด์อื่น ๆ เพื่อลบการละเมิดท้องถิ่นและกลับไปใช้ค่าที่สืบทอด ให้เรียก [OverrideTheme.clear](https://reference.aspose.com/slides/th/php-java/aspose.slides/overridetheme/)

### **ใช้การละเมิดธีมกับเลเอาต์**

การละเมิดระดับเลเอาต์ใช้กับสไลด์ที่ใช้เลเอาต์นั้น เว้นแต่สไลด์เฉพาะจะมีการละเมิดของมันเอง วิธีการเริ่มต้นเดียวกันสามารถใช้ผ่าน [LayoutSlideThemeManager](https://reference.aspose.com/slides/th/php-java/aspose.slides/layoutslidethememanager/):

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

ใช้ธีมระดับมาสเตอร์หรือการนำเสนอเมื่อหลายเลเอาต์และสไลด์ควรแชร์การออกแบบฐานเดียวกัน ใช้การละเมิดเลเอาต์เมื่อกลุ่มเลเอาต์ต้องการสไตล์ที่แตกต่าง และใช้การละเมิดสไลด์เฉพาะสำหรับข้อยกเว้นจริง การละเมิดระดับสไลด์มากเกินไปทำให้การเปลี่ยนธีมระดับโลกในภายหลังคาดเดายาก

## **อัปเดตสไตล์พื้นหลังของธีม**

การเติมพื้นหลังของธีมถูกจัดเก็บใน [FormatScheme.getBackgroundFillStyles](https://reference.aspose.com/slides/th/php-java/aspose.slides/formatscheme/)。PowerPoint สามารถแสดงตัวเลือกพื้นหลังได้มากกว่า จำนวนการกำหนดเติมที่จัดเก็บในคอลเลกชันนี้ เนื่องจาก UI สามารถผสานการเติมธีมกับสีธีมและอ้างอิงสไตล์อื่น ๆ

![PowerPoint background style gallery for a presentation theme](presentation-design_8.png)

ก่อนใช้สไตล์พื้นหลัง ให้ตรวจสอบคอลเลกชันที่เก็บและค่า [Background.getStyleIndex](https://reference.aspose.com/slides/th/php-java/aspose.slides/background/) ปัจจุบัน ดัชนีสไตล์ `0` หมายถึงไม่มีการเติมที่อิงธีม; ค่าบวกเป็นอ้างอิงสไตล์พื้นหลังของธีม สิ่งนี้แตกต่างจากการเรียกดัชนีคอลเลกชัน PHP โดยตรงที่ `get_Item(0)` คือรายการแรกที่เก็บ อย่าสันนิษฐานว่าการนำเสนอทุกอันมีจำนวนสไตล์การเติมพื้นหลังเท่ากัน

ตัวอย่างต่อไปนี้รายงานจำนวนการเติมพื้นหลังที่มี, กำหนดอ้างอิงพื้นหลังที่อิงธีมให้กับมาสเตอร์แรก, และบันทึกการนำเสนอ:

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

ผลลัพธ์ที่มองเห็นขึ้นอยู่กับรายการธีมที่มาสเตอร์อ้างอิงและการละเมิดพื้นหลังที่เลเอาต์หรือสไลด์ระดับ หากสไลด์ใช้พื้นหลังของตนเอง การเปลี่ยนพื้นหลังมาสเตอร์อย่างเดียวอาจไม่ส่งผลต่อสไลด์นั้น ใช้ [Background.getEffective](https://reference.aspose.com/slides/th/php-java/aspose.slides/background/) เมื่อคุณต้องการทราบพื้นหลังสุดท้ายหลังจากการสืบทอด

{{% alert color="warning" title="คำเตือน" %}}
อย่าใช้ดัชนีสไตล์เป็นดัชนีคอลเลกชันแบบเริ่มต้นที่ 0 นอกจากนี้หลีกเลี่ยงการกำหนดหมายเลขสไตล์แบบคงที่จากไฟล์หนึ่งและสันนิษฐานว่ามันมีลักษณะเดียวกันในไฟล์อื่น; คำจำกัดความของสไตล์ธีมเป็นลักษณะเฉพาะของการนำเสนอ
{{% /alert %}}

{{% alert color="info" title="เคล็ดลับ" %}}
สำหรับการจัดรูปแบบพื้นหลังโดยตรงและการสืบทอดพื้นหลัง ให้ดูที่ [Presentation Background](/slides/th/php-java/presentation-background/)
{{% /alert %}}

## **อัปเดตเอฟเฟกต์ของธีม**

สคีมรูปแบบของธีมมีคอลเลกชันการเติม, เส้น, และเอฟเฟกต์ที่แยกกัน เปิดเผยผ่าน [FormatScheme.getFillStyles](https://reference.aspose.com/slides/th/php-java/aspose.slides/formatscheme/), [FormatScheme.getLineStyles](https://reference.aspose.com/slides/th/php-java/aspose.slides/formatscheme/), และ [FormatScheme.getEffectStyles](https://reference.aspose.com/slides/th/php-java/aspose.slides/formatscheme/)。ธีมของ Office ส่วนใหญ่มีรายการสไตล์หลักสามรายการที่สอดคล้องกับการจัดรูปแบบแบบ Subtle, Moderate, และ Intense อย่างไรก็ตามโค้ดควรตรวจสอบแต่ละคอลเลกชันแทนการสันนิษฐานจำนวนคงที่

![Subtle, moderate, and intense theme effects applied to the same shape](presentation-design_10.png)

เมื่อเข้าถึงคอลเลกชันเหล่านี้ใน PHP ดัชนีคอลเลกชันเริ่มจากศูนย์: `get_Item(0)` คือสไตล์แรกที่เก็บและ `get_Item(2)` คือสไตล์ที่สาม ดัชนีอ้างอิงสไตล์ของรูปทรงเป็นแนวคิดแยกที่เปิดเผยผ่าน [ShapeStyle](https://reference.aspose.com/slides/th/php-java/aspose.slides/shapestyle/)。การแก้ไขสไตล์ธีมจะส่งผลต่อรูปทรงที่อ้างอิงสไตล์ธีมนั้น; รูปทรงที่มีการจัดรูปแบบโดยตรงอาจคงเดิม

ตัวอย่างต่อไปนี้ตรวจสอบว่ามีรายการสไตล์ที่ต้องการหรือไม่, เปลี่ยนสไตล์เส้นแรก, เปลี่ยนสไตล์เติมที่สาม, เปิดเงานอกในสไตล์เอฟเฟกต์ที่สาม, และบันทึกผลลัพธ์:

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

สำหรับรูปทรงที่อ้างอิงช่องเหล่านี้ สไตล์เส้นธีมแรกจะเป็นสีแดง, สไตล์เติมธีมที่สามจะเป็นสีเขียวป่าแบบทึบ, และสไตล์เอฟเฟกต์ที่สามจะเพิ่มเงานอกที่ระยะ 10 จุด ผลลัพธ์ภาพที่แน่นอนยังคงขึ้นอยู่กับว่ารูปทรงแต่ละอันอ้างอิงช่องใดและว่าการจัดรูปแบบโดยตรงละเมิดธีมหรือไม่

![Theme effect styles after changing line, fill, and shadow settings](presentation-design_11.png)

## **ตรวจสอบว่าการเติมสีทึบที่มีผลใช้สีธีมหรือไม่**

การเติมอาจถูกเก็บโดยตรงบนวัตถุหรือสืบทอดจากย่อหน้า, เลเอาต์, มาสเตอร์, สไตล์ธีม, หรือระดับการจัดรูปแบบอื่น ๆ เรียกใช้ [FillFormat::getEffective](https://reference.aspose.com/slides/th/php-java/aspose.slides/fillformat/) เพื่อแปลงลำดับชั้นนั้นเป็นข้อมูลการเติมที่เป็นคงที่แรก ตรวจสอบผล `getFillType` ก่อน หากผลเป็น `FillType::Solid` จึงอ่านคุณสมบัติการเติมสีทึบ

สำหรับการเติมสีทึบ `getSolidFillColor` จะคืนค่า RGB ที่เรนเดอร์สุดท้ายหลังจากการสืบทอด, การค้นหาธีม, และการแปลงสี `getSolidFillSchemeColor` จะคืนค่าช่อง [SchemeColor](https://reference.aspose.com/slides/th/php-java/aspose.slides/schemecolor/) ที่สอดคล้อง เช่น `Text1` หรือ `Accent6` ค่า `SchemeColor::NotDefined` หมายถึงการเติมสีทึบที่มีผลไม่ได้อิงจากสีสกีม ในเวิร์คโฟลว์ที่การเติมเป็นสีธีมหรือสี RGB โดยตรง ค่านี้บ่งชี้ว่าการเติมเป็นสี RGB โดยตรง

อย่าใช้ค่า [ColorFormat::getSchemeColor](https://reference.aspose.com/slides/th/php-java/aspose.slides/colorformat/) ที่เป็นค่าท้องถิ่นอย่างเดียวเพื่อจำแนกการเติม ตัวอย่างเช่น ส่วนข้อความอาจไม่มีการกำหนดสีสกีมท้องถิ่น จึงค่า `NotDefined` แต่การเติมที่มีผลอาจสืบทอดสีธีมและเป็น `Text1` หรือ `Accent6` ในทางกลับกัน `getSolidFillSchemeColor` บอกว่าช่องธีมเชิงตรรกะใดสร้างสีที่มีผล แต่ไม่บอกว่าช่องนั้นมาจากวัตถุ, ย่อหน้า, เลเอาต์, มาสเตอร์ หรือระดับอื่นของลำดับชั้นการจัดรูปแบบ

ตัวอย่างต่อไปนี้โหลดการนำเสนอ, ตรวจสอบการเติมของทั้งรูปทรงและส่วนข้อความ, พิมพ์ค่า RGB สุดท้ายและสีสกีมที่เกี่ยวข้อง, และทำเครื่องหมายการเติมสีทึบที่ไม่ติดตามการเปลี่ยนแปลงสีธีม:

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

สาขา `NotDefined` ให้รายการการตรวจสอบของการเติมสีทึบที่ไม่ตอบสนองต่อการเปลี่ยนแปลงในช่องสีธีม ตรวจสอบวัตถุเหล่านั้นเมื่อการนำเสนอจะต้องปฏิบัติตามพาเลทแบรนด์ใหม่ ค่า RGB ที่รายงานยังแสดงล appearance ปัจจุบัน ขณะที่ค่าช่องอธิบายว่าการแสดงผลนั้นเชื่อมต่อกับธีมหรือไม่

อ็อบเจ็กต์ที่มีรูปแบบที่มีผลเป็นสแน็ปชอต หลังจากเปลี่ยนธีมการนำเสนอ, การละเมิดธีม, หรือการจัดรูปแบบที่สืบทอดใด ๆ เรียก `getEffective` อีกครั้งและอ่านข้อมูลการเติมที่มีผลใหม่ก่อนเปรียบเทียบหรือรายงานสี

## **อ่านค่าธีมที่มีผล**

อ็อบเจ็กต์ธีมดิบบอกว่าอะไรถูกกำหนดในระดับใดระดับหนึ่ง ค่าที่มีผลบอกว่า สไลด์หรือรูปทรงใช้อะไรจริงหลังจากการสืบทอดและการละเมิดท้องถิ่นถูกประมวลผล สำหรับสไลด์ ให้เรียก [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/th/php-java/aspose.slides/baseoverridethememanager/)。สำหรับพื้นหลัง ใช้ [Background.getEffective](https://reference.aspose.com/slides/th/php-java/aspose.slides/background/), และสำหรับการเติม ใช้ [FillFormat.getEffective](https://reference.aspose.com/slides/th/php-java/aspose.slides/fillformat/)

ตัวอย่างต่อไปนี้อ่านธีมที่มีผล, พื้นหลัง, และการเติมรูปทรงแรกจากสไลด์:

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

ใช้ข้อมูลที่มีผลสำหรับการวินิจฉัยการเรนเดอร์, การตรวจสอบ, และการเปรียบเทียบ หากคุณตรวจสอบเฉพาะ [Presentation.getMasterTheme](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentation/) อาจพลาดมาสเตอร์, เลเอาต์, สไลด์, หรือการละเมิดรูปทรงที่เปลี่ยนล appearance สุดท้าย

## **คำถามที่พบบ่อย**

**การใช้ธีมภายนอกจะส่งผลต่อสไลด์ทุกสไลด์ในงานนำเสนอหรือไม่?**

ไม่ใช่ [MasterSlide::applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/th/php-java/aspose.slides/masterslide/) จะกำหนดใหม่เฉพาะสไลด์ที่ขึ้นกับมาสเตอร์ที่เลือก สไลด์ที่ใช้มาสเตอร์อื่นจะรักษาธีมเดิมไว้

**ฉันสามารถใช้ธีมกับสไลด์เดียวโดยไม่เปลี่ยนมาสเตอร์ได้หรือไม่?**

ได้ ใช้ [SlideThemeManager](https://reference.aspose.com/slides/th/php-java/aspose.slides/slidethememanager/) ของสไลด์และเริ่มต้นธีมละเมิดของมัน การเปลี่ยนแปลงจะอยู่ในระดับสไลด์เท่านั้น สไลด์อื่น ๆ ยังคงสืบทอดธีมเดิมต่อไป

**วิธีที่ปลอดภัยที่สุดในการย้ายธีมจากงานนำเสนอหนึ่งไปยังอีกงานนำเสนอหนึ่งคืออะไร?**

เมื่อย้ายสไลด์และต้องการรักษารูปแบบต้นฉบับ ให้คัดลอกมาสเตอร์ต้นฉบับไปยังปลายทางและคัดลอกสไลด์ด้วยมาสเตอร์นั้นโดยใช้ [MasterSlideCollection.addClone](https://reference.aspose.com/slides/th/php-java/aspose.slides/masterslidecollection/) และ [SlideCollection.addClone](https://reference.aspose.com/slides/th/php-java/aspose.slides/slidecollection/) วิธีนี้ทำให้มาสเตอร์, เลเอาต์, และธีมอยู่ด้วยกัน

**ฉันจะดูค่าที่มีผลหลังจากการสืบทอดและการละเมิดได้อย่างไร?**

ใช้ [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/th/php-java/aspose.slides/baseoverridethememanager/) สำหรับสไลด์หรือเลเอาต์ธีมและเมธอดข้อมูลที่มีผลที่สอดคล้องสำหรับอ็อบเจ็กต์รูปแบบ เช่น [Background.getEffective](https://reference.aspose.com/slides/th/php-java/aspose.slides/background/) และ [FillFormat.getEffective](https://reference.aspose.com/slides/th/php-java/aspose.slides/fillformat/) API เหล่านี้คืนค่าที่ได้รับการแก้ไขหลังจากการสืบทอดและการละเมิดถูกนำไปใช้