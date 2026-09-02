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
- สีธีม
- พาเลตเพิ่มเติม
- แบบอักษรธีม
- สไตล์ธีม
- เอฟเฟกต์ธีม
- PowerPoint
- OpenDocument
- การนำเสนอ
- PHP
- Aspose.Slides
description: "ควบคุมธีมการนำเสนอใน Aspose.Slides สำหรับ PHP ผ่าน Java เพื่อสร้าง ปรับแต่ง และแปลงไฟล์ PowerPoint ด้วยแบรนด์ที่สอดคล้องกัน"
---
## **บทนำ**

ธีมการนำเสนอกำหนดชุดสี, แบบอักษร, สไตล์พื้นหลัง, การเติม, เส้น, และเอฟเฟกต์ที่สอดคล้องกัน วัตถุที่รับรู้ธีมจะอ้างอิงคำนิยามที่แชร์เหล่านี้แทนการเก็บค่าคุณสมบัติดีสัยทุกอย่างเป็นค่าคงที่ ดังนั้นการเปลี่ยนธีมจึงสามารถอัปเดตวัตถุหลายรายการพร้อมกันได้

ใน Aspose.Slides, ธีมระดับการนำเสนอสามารถเข้าถึงได้ผ่าน [Presentation.getMasterTheme](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentation/). การนำเสนออาจมีการแทนที่ธีมในระดับล่างได้ด้วย มาสเตอร์อาจแทนที่ธีมการนำเสนอผ่าน [MasterThemeManager.getOverrideTheme](https://reference.aspose.com/slides/th/php-java/aspose.slides/masterthememanager/), ในขณะที่เลเอาต์หรือสไลด์เดี่ยวอาจแทนที่ธีมที่สืบทอดมาผ่าน [BaseOverrideThemeManager.getOverrideTheme](https://reference.aspose.com/slides/th/php-java/aspose.slides/baseoverridethememanager/). โดยปฏิบัติ ธีมที่ใช้งานจริงสำหรับสไลด์จะถูกแก้ไขผ่านสายการสืบทอดนี้: ธีมการนำเสนอ → การแทนที่มาสเตอร์ → การแทนที่เลเอาต์ → การแทนที่สไลด์

![Theme components: colors, fonts, background styles, and effects](theme-constituents.png)

ส่วนต่อไปนี้แสดงขั้นตอนการทำงานกับธีมที่พบบ่อยที่สุด: ตรวจสอบธีม, เปลี่ยนสีและแบบอักษร, คัดลอกหรือใช้ธีม, ปรับปรุงสไตล์พื้นหลังและเอฟเฟกต์, และอ่านค่าที่ได้จริงหลังจากการสืบทอดและการแทนที่ได้รับการแก้ไขแล้ว

## **ตรวจสอบธีม**

วัตถุ [MasterTheme](https://reference.aspose.com/slides/th/php-java/aspose.slides/mastertheme/) จะเปิดเผยสกีมสี, สกีมแบบอักษร, และสกีมรูปแบบของธีมผ่าน [MasterTheme.getColorScheme](https://reference.aspose.com/slides/th/php-java/aspose.slides/mastertheme/), [MasterTheme.getFontScheme](https://reference.aspose.com/slides/th/php-java/aspose.slides/mastertheme/), และ [MasterTheme.getFormatScheme](https://reference.aspose.com/slides/th/php-java/aspose.slides/mastertheme/). การตรวจสอบคอลเลกชันเหล่านี้ก่อนทำการเปลี่ยนแปลงเป็นประโยชน์โดยเฉพาะเมื่อการนำเสนอมาจากแหล่งภายนอก เพราะจำนวนและเนื้อหาของรายการสไตล์อาจแตกต่างกัน

ตัวอย่างต่อไปนี้อ่านคุณสมบัติธีมหลักและรายงานจำนวนสไตล์พื้นหลัง, การเติม, เส้น, และเอฟเฟกต์ที่ถูกจัดเก็บในธีม:

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

หากไฟล์ใช้มาสเตอร์หลายตัว อย่าสมมติว่าทุกสไลด์มีธีมที่ได้ผลเท่ากัน ตรวจสอบมาสเตอร์ที่เชื่อมโยงกับสไลด์ และใช้ขั้นตอนการทำงานธีมที่ได้ผลที่แสดงต่อไปนี้เมื่ออาจมีการแทนที่เลเอาต์หรือสไลด์

## **เปลี่ยนสีธีม**

การเติม, เส้น, และข้อความที่รับรู้ธีมสามารถอ้างอิงสีตรรกะจาก enumeration [SchemeColor](https://reference.aspose.com/slides/th/php-java/aspose.slides/schemecolor/). เมื่อคุณเปลี่ยนรายการที่สอดคล้องใน [ColorScheme](https://reference.aspose.com/slides/th/php-java/aspose.slides/colorscheme/), วัตถุทั้งหมดที่ยังอ้างอิงสีธีมนั้นจะถูกแก้ไขให้ใช้ค่ใหม่ วัตถุที่ใช้สี RGB โดยตรงจะไม่เปลี่ยนแปลงจากการอัปเดตสีธีม

ตัวอย่างต่อไปนี้เป็นการสร้างรูปทรงที่ใช้ `Accent4`, เปลี่ยนสี `Accent4` ของธีมเป็นสีแดง, บันทึกการนำเสนอ, เปิดใหม่อีกครั้ง, และพิมพ์สีการเติมที่ได้ผล:

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

เนื่องจากสี่เหลี่ยมยังคงเชื่อมโยงกับ `Accent4` สีที่มองเห็นจึงกลายเป็นสีแดงหลังจากธีมเปลี่ยน หากคุณแทนที่สีสกีมด้วยสีโดยตรงบนรูปทรง การเปลี่ยนแปลงต่อมาใน `Accent4` จะไม่ส่งผลต่อการเติมนั้นอีกต่อไป

### **ใช้สีจากพาเลตเพิ่มเติม**

PowerPoint สร้างเวอร์ชันสีอ่อนและเข้มจากสีธีมโดยใช้การแปลงสี Aspose.Slides เปิดเผยการแปลงเหล่านี้ผ่าน enumeration [ColorTransformOperation](https://reference.aspose.com/slides/th/php-java/aspose.slides/colortransformoperation/).

![Main theme colors and lighter and darker colors generated from the additional palette](additional-palette-colors.png)

**1** - สีธีมหลัก

**2** - เวอร์ชันสีอ่อนและเข้มที่สร้างจากสีธีมหลัก

ตัวอย่างต่อไปนี้สร้างสี่เหลี่ยมรูป 6 รูปโดยอิงจาก `Accent4`, ประยุกต์การแปลงความสว่างกับห้ารูป และบันทึกผลลัพธ์:

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

### **แมปค่า `SchemeColor` ไปยังช่อง `ColorScheme`**

enumeration [SchemeColor](https://reference.aspose.com/slides/th/php-java/aspose.slides/schemecolor/) ใช้ `Text1`, `Background1`, `Text2`, และ `Background2`, ในขณะที่ [ColorScheme](https://reference.aspose.com/slides/th/php-java/aspose.slides/colorscheme/) เปิดเผยช่องธีมเดียวกันเป็น `Dark1`, `Light1`, `Dark2`, และ `Light2`. การแมปเป็นแบบคงที่:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

เหล่านี้คือชื่อทางเลือกของช่องธีมเดียวกัน; ไม่ได้เป็นค่าที่แปลงแบบไดนามิกจากรูปแบบหนึ่งไปยังอีกรูปแบบหนึ่ง

## **เปลี่ยนแบบอักษรธีม**

สกีมแบบอักษรของธีมประกอบด้วยชุดแบบอักษรหลักสำหรับหัวเรื่องและชุดแบบอักษรรองสำหรับข้อความตัวหลัก วิธี [FontScheme.getMajor](https://reference.aspose.com/slides/th/php-java/aspose.slides/fontscheme/) และ [FontScheme.getMinor](https://reference.aspose.com/slides/th/php-java/aspose.slides/fontscheme/) เปิดเผยชุดเหล่านั้น

ตัวระบุแบบอักษรธีมที่เข้ากันได้กับ PowerPoint สามารถใช้ในการจัดรูปแบบข้อความ:

* `+mn-lt` - แบบอักษรตัวอักษรลาตินสำหรับเนื้อหา (Minor Latin Font)
* `+mj-lt` - แบบอักษรหัวเรื่องลาติน (Major Latin Font)
* `+mn-ea` - แบบอักษรตัวอักษรเอเชียตะวันออกสำหรับเนื้อหา (Minor East Asian Font)
* `+mj-ea` - แบบอักษรหัวเรื่องเอเชียตะวันออก (Major East Asian Font)

ตัวอย่างต่อไปนี้สร้างหัวเรื่องหนึ่งที่ใช้แบบอักษรลาตินหลักและบรรทัดเนื้อหาหนึ่งที่ใช้แบบอักษรลาตินรอง จากนั้นเปลี่ยนแบบอักษรธีมและบันทึกผลลัพธ์:

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

หัวเรื่องใช้แบบอักษรหลักและข้อความใช้แบบอักษรรอง ข้อความที่ระบุชื่อแบบอักษรโดยตรงแทนตัวระบุธีมจะไม่เปลี่ยนอัตโนมัติเมื่อสกีมแบบอักษรธีมเปลี่ยน

คอลเลกชันแบบอักษรหลักและรองยังสามารถมีการแมปแบบอักษรสำหรับระบบการเขียนแต่ละระบบได้ เช่น Cyrillic, Arabic, Japanese, Georgian, และ Thaana หากต้องการตรวจสอบ, เพิ่ม, แทนที่, หรือเอาการแมปเหล่านี้ออก ให้ดูที่ [Script-Specific Theme Fonts](/slides/th/php-java/script-specific-font-mappings/).

{{% alert color="info" title="Tip" %}}
สำหรับข้อมูลเพิ่มเติมเกี่ยวกับแบบอักษรการนำเสนอ ดูที่ [ฟอนต์ PowerPoint](/slides/th/php-java/powerpoint-fonts/).
{{% /alert %}}

## **คัดลอกหรือใช้ธีม**

มีสองขั้นตอนการทำงานทั่วไป และแต่ละขั้นตอนแก้ไขปัญหาที่แตกต่างกัน

### **รักษาธีมต้นทางเมื่อนำสไลด์ไปยังการนำเสนออื่น**

หากต้องการย้ายสไลด์ไปยังการนำเสนออื่นและรักษาการออกแบบเดิม ให้คัดลอกมาสเตอร์ต้นทางเข้าสู่การนำเสนอเป้าหมายด้วย [MasterSlideCollection.addClone](https://reference.aspose.com/slides/th/php-java/aspose.slides/masterslidecollection/), แล้วคัดลอกสไลด์ด้วย [SlideCollection.addClone](https://reference.aspose.com/slides/th/php-java/aspose.slides/slidecollection/) พร้อมมาสเตอร์ที่คัดลอกไว้ วิธีนี้จะพามาสเตอร์, เลเอาต์, และธีมที่เกี่ยวข้องไปด้วย

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

นี่เป็นขั้นตอนที่แนะนำเมื่อสไลด์ต้นทางต้องแสดงผลเหมือนเดิมในปลายทาง การคัดลอกเนื้อหาไปยังมาสเตอร์ปลายทางที่ไม่มีความเกี่ยวข้องอาจทำให้สี, แบบอักษร, พื้นหลัง, และเอฟเฟกต์ที่ขับเคลื่อนด้วยธีมเปลี่ยนแปลงได้

### **ใช้ค่าธีมกับสไลด์ที่มีอยู่แล้ว**

หากสไลด์เป้าหมายต้องคงอยู่บนมาสเตอร์และเลเอาต์ปัจจุบัน ให้เริ่มต้นการแทนที่ระดับสไลด์จากธีมต้นทาง วิธี [OverrideTheme.initColorSchemeFrom](https://reference.aspose.com/slides/th/php-java/aspose.slides/overridetheme/), [OverrideTheme.initFontSchemeFrom](https://reference.aspose.com/slides/th/php-java/aspose.slides/overridetheme/), และ [OverrideTheme.initFormatSchemeFrom](https://reference.aspose.com/slides/th/php-java/aspose.slides/overridetheme/) จะคัดลอกส่วนประกอบธีมหลักสามส่วนเข้าสู่การแทนที่

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

วิธีนี้เปลี่ยนธีมที่สไลด์นั้นใช้โดยไม่กระทบต่อธีมที่สไลด์อื่นสืบทอดไว้ หากต้องการลบการแทนที่ในระดับท้องถิ่นและกลับสู่ค่าที่สืบทอด ให้เรียก [OverrideTheme.clear](https://reference.aspose.com/slides/th/php-java/aspose.slides/overridetheme/)

### **ใช้การแทนที่ธีมกับเลเอาต์**

การแทนที่ระดับเลเอาต์จะส่งผลกับสไลด์ที่ใช้เลเอาต์นั้น ยกเว้นสไลด์ที่มีการแทนที่ของตนเอง วิธีการเริ่มต้นเดียวกันสามารถใช้ผ่าน [LayoutSlideThemeManager](https://reference.aspose.com/slides/th/php-java/aspose.slides/layoutslidethememanager/):

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

ใช้ธีมระดับมาสเตอร์หรือการนำเสนอเมื่อหลายเลเอาต์และสไลด์ต้องแชร์การออกแบบฐานเดียวกัน ใช้การแทนที่เลเอาต์เมื่อชุดเลเอาต์หนึ่งต้องการสไตลิงที่แตกต่าง และใช้การแทนที่สไลด์เฉพาะกรณีพิเศษเท่านั้น การแทนที่ระดับสไลด์มากเกินไปทำให้การเปลี่ยนธีมทั่วโลกในภายหลังคาดเดาได้ยาก

## **อัปเดตสไตล์พื้นหลังของธีม**

การเติมพื้นหลังของธีมถูกจัดเก็บใน [FormatScheme.getBackgroundFillStyles](https://reference.aspose.com/slides/th/php-java/aspose.slides/formatscheme/). PowerPoint สามารถแสดงตัวเลือกพื้นหลังได้มากกว่าจำนวนการกำหนดการเติมที่จัดเก็บจริงในคอลเลกชันนี้ เพราะ UI สามารถรวมการเติมธีมกับสีธีมและการอ้างอิงสไตล์อื่น ๆ

![PowerPoint background style gallery for a presentation theme](presentation-design_8.png)

ก่อนใช้สไตล์พื้นหลัง ให้ตรวจสอบคอลเลกชันที่จัดเก็บและค่า [Background.getStyleIndex](https://reference.aspose.com/slides/th/php-java/aspose.slides/background/) ปัจจุบัน ดัชนีสไตล์ `0` หมายถึงไม่มีการเติมที่มีธีม; ค่าบวกเป็นการอ้างอิงสไตล์พื้นหลังของธีม นี้แตกต่างจากการใช้ดัชนีของคอลเลกชัน PHP โดยตรงที่ `get_Item(0)` หมายถึงรายการแรกที่จัดเก็บ อย่าสมมติว่าการนำเสนอทุกไฟล์มีจำนวนสไตล์การเติมพื้นหลังเท่ากัน

ตัวอย่างต่อไปนี้รายงานจำนวนการเติมพื้นหลังที่มี, กำหนดการอ้างอิงพื้นหลังธีมให้กับมาสเตอร์แรก, และบันทึกการนำเสนอ:

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

ผลลัพธ์ที่มองเห็นขึ้นอยู่กับรายการธีมที่มาสเตอร์อ้างอิงและการแทนที่พื้นหลังที่อาจมีในระดับเลเอาต์หรือสไลด์ หากสไลด์ใช้พื้นหลังของตนเอง การเปลี่ยนพื้นหลังมาสเตอร์อย่างเดียวอาจไม่กระทบสไลด์นั้น ใช้ [Background.getEffective](https://reference.aspose.com/slides/th/php-java/aspose.slides/background/) เมื่อจำเป็นต้องทราบพื้นหลังสุดท้ายหลังจากการสืบทอด

{{% alert color="warning" title="Warning" %}}
อย่าพิจารณาดัชนีสไตล์เป็นดัชนีคอลเลกชันที่เริ่มจากศูนย์ อีกทั้งหลีกเลี่ยงการกำหนดหมายเลขสไตล์แบบคงที่จากไฟล์หนึ่งและสมมติว่ามันมีลักษณะเดียวกันในไฟล์อื่น; คำจำกัดความสไตล์ของธีมเป็นเรื่องเฉพาะการนำเสนอ
{{% /alert %}}

{{% alert color="info" title="Tip" %}}
สำหรับการฟอร์แมตพื้นหลังโดยตรงและการสืบทอดพื้นหลัง ดูที่ [Presentation Background](/slides/th/php-java/presentation-background/)
{{% /alert %}}

## **อัปเดตเอฟเฟกต์ของธีม**

สกีมรูปแบบของธีมประกอบด้วยคอลเลกชันการเติม, เส้น, และเอฟเฟกต์ที่แยกจากกัน ซึ่งเปิดเผยผ่าน [FormatScheme.getFillStyles](https://reference.aspose.com/slides/th/php-java/aspose.slides/formatscheme/), [FormatScheme.getLineStyles](https://reference.aspose.com/slides/th/php-java/aspose.slides/formatscheme/), และ [FormatScheme.getEffectStyles](https://reference.aspose.com/slides/th/php-java/aspose.slides/formatscheme/). ธีม Office ปกติมักมีรายการสไตล์หลักสามรายการที่สอดคล้องกับการฟอร์แมตแบบ Subtle, Moderate, และ Intense อย่างไรก็ตาม ควรตรวจสอบแต่ละคอลเลกชันแทนการสมมติจำนวนคงที่

![Subtle, moderate, and intense theme effects applied to the same shape](presentation-design_10.png)

เมื่อเข้าถึงคอลเลกชันเหล่านี้ใน PHP ดัชนีคอลเลกชันจะเริ่มจากศูนย์: `get_Item(0)` เป็นสไตล์แรกที่จัดเก็บและ `get_Item(2)` เป็นสไตล์ที่สาม ดัชนีการอ้างอิงสไตล์ของรูปทรงเป็นแนวคิดแยกต่างหาก ซึ่งเปิดเผยผ่าน [ShapeStyle](https://reference.aspose.com/slides/th/php-java/aspose.slides/shapestyle/). การแก้ไขสไตล์ธีมจะส่งผลต่อรูปทรงที่อ้างอิงสไตล์ธีมนั้น; รูปทรงที่มีการฟอร์แมตโดยตรงอาจไม่เปลี่ยนแปลง

ตัวอย่างต่อไปนี้ตรวจสอบว่ามีรายการสไตล์ที่จำเป็นหรือไม่, เปลี่ยนสไตล์เส้นแรก, เปลี่ยนสไตล์การเติมที่สาม, เปิดใช้งานเงาภายนอกในสไตล์เอฟเฟกต์ที่สาม, แล้วบันทึกผลลัพธ์:

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

สำหรับรูปทรงที่อ้างอิงช่องเหล่านี้ สไตล์เส้นธีมแรกจะกลายเป็นสีแดง, สไตล์การเติมธีมที่สามจะเป็นสีเขียวป่าขาวทึบ, และสไตล์เอฟเฟกต์ที่สามจะเพิ่มเงาภายนอกที่ระยะ 10 จุด ผลลัพธ์ภาพที่แน่นอนยังคงขึ้นอยู่กับว่ารูปทรงแต่ละรูปอ้างอิงช่องสไตล์ใด และว่าการฟอร์แมตโดยตรงได้แทนที่ธีมหรือไม่

![Theme effect styles after changing line, fill, and shadow settings](presentation-design_11.png)

## **อ่านค่าธีมที่ได้ผล**

วัตถุธีมดิบบอกคุณว่าอะไรถูกกำหนดไว้ที่ระดับใด ระดับที่ได้ผลบอกคุณว่าหน้า หรือรูปทรงใช้ค่าอะไรจริงหลังจากการสืบทอดและการแทนที่ในท้องถิ่นได้รับการแก้ไขแล้ว สำหรับสไลด์ เรียก [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/th/php-java/aspose.slides/baseoverridethememanager/). สำหรับพื้นหลัง ใช้ [Background.getEffective](https://reference.aspose.com/slides/th/php-java/aspose.slides/background/), และสำหรับการเติม ใช้ [FillFormat.getEffective](https://reference.aspose.com/slides/th/php-java/aspose.slides/fillformat/)

ตัวอย่างต่อไปนี้อ่านธีมที่ได้ผล, พื้นหลัง, และการเติมรูปทรงแรกจากสไลด์:

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

ใช้ข้อมูลที่ได้ผลสำหรับการถอดรหัสการ render, การตรวจสอบ, และการเปรียบเทียบ หากคุณตรวจสอบเฉพาะ [Presentation.getMasterTheme](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentation/) คุณอาจพลาดมาสเตอร์, เลเอาต์, สไลด์, หรือการแทนที่รูปทรงที่เปลี่ยนลักษณะสุดท้ายได้

## **คำถามที่พบบ่อย**

**ฉันสามารถใช้ธีมกับสไลด์เดียวโดยไม่เปลี่ยนมาสเตอร์ได้หรือไม่?**

ได้ ใช้ [SlideThemeManager](https://reference.aspose.com/slides/th/php-java/aspose.slides/slidethememanager/) ของสไลด์และเริ่มต้นการแทนที่ธีมของมัน การเปลี่ยนแปลงจะอยู่ในระดับท้องถิ่นของสไลด์นั้น; สไลด์อื่นจะยังคงสืบทอดธีมที่มีอยู่

**วิธีที่ปลอดภัยที่สุดในการย้ายธีมจากการนำเสนอหนึ่งไปยังอีกการนำเสนอหนึ่งคืออะไร?**

เมื่อย้ายสไลด์และรักษาการแสดงผลต้นทาง ให้คัดลอกมาสเตอร์ต้นทางเข้าสู่ปลายทางและคัดลอกสไลด์ด้วยมาสเตอร์นั้นโดยใช้ [MasterSlideCollection.addClone](https://reference.aspose.com/slides/th/php-java/aspose.slides/masterslidecollection/) และ [SlideCollection.addClone](https://reference.aspose.com/slides/th/php-java/aspose.slides/slidecollection/). วิธีนี้ทำให้มาสเตอร์, เลเอาต์, และธีมอยู่ด้วยกัน

**ฉันจะดูค่าที่ได้ผลหลังจากการสืบทอดและการแทนที่ได้อย่างไร?**

ใช้ [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/th/php-java/aspose.slides/baseoverridethememanager/) สำหรับสไลด์หรือธีมเลเอาต์และใช้เมธอดข้อมูลที่ได้ผลที่สอดคล้องสำหรับวัตถุรูปแบบ เช่น [Background.getEffective](https://reference.aspose.com/slides/th/php-java/aspose.slides/background/) และ [FillFormat.getEffective](https://reference.aspose.com/slides/th/php-java/aspose.slides/fillformat/). API เหล่านี้จะคืนค่าที่แก้ไขแล้วหลังจากการสืบทอดและการแทนที่ถูกนำไปใช้