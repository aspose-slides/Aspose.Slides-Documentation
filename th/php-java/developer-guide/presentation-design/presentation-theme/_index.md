---
title: จัดการธีมงานนำเสนอใน PHP
linktitle: ธีมงานนำเสนอ
type: docs
weight: 10
url: /th/php-java/presentation-theme/
keywords:
- ธีม PowerPoint
- ธีมงานนำเสนอ
- ธีมสไลด์
- กำหนดธีม
- เปลี่ยนธีม
- จัดการธีม
- สีธีม
- พาเลตเพิ่มเติม
- แบบอักษรธีม
- สไตล์ธีม
- เอฟเฟ็กต์ธีม
- PowerPoint
- OpenDocument
- งานนำเสนอ
- PHP
- Aspose.Slides
description: "ควบคุมธีมงานนำเสนอใน Aspose.Slides สำหรับ PHP ผ่าน Java เพื่อสร้าง, ปรับแต่งและแปลงไฟล์ PowerPoint พร้อมแบรนด์ที่สอดคล้องกัน."
---
## **บทนำ**

ธีมงานนำเสนอกำหนดชุดสีแบบประสาน, แบบอักษร, สไตล์พื้นหลัง, การเติม, เส้น, และเอฟเฟ็กต์ ธรรมชาติของออบเจ็กต์ที่รับรู้ธีมจะอ้างอิงคำนิยามที่แชร์เหล่านี้แทนการเก็บคุณสมบัติดิจิตอลแต่ละอย่างเป็นค่าคงที่, ดังนั้นการเปลี่ยนธีมสามารถอัปเดตออบเจ็กต์หลาย ๆ ตัวพร้อมกันได้

ใน Aspose.Slides, ธีมระดับงานนำเสนอสามารถเรียกใช้ได้ผ่าน [Presentation.getMasterTheme](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentation/). งานนำเสนออาจมีการเขียนทับธีมในระดับล่างได้เช่นกัน ตัว Master สามารถเขียนทับธีมของงานนำเสนอผ่าน [MasterThemeManager.getOverrideTheme](https://reference.aspose.com/slides/th/php-java/aspose.slides/masterthememanager/), ส่วน Layout หรือสไลด์เดี่ยวสามารถเขียนทับธีมที่สืบทอดมาได้ผ่าน [BaseOverrideThemeManager.getOverrideTheme](https://reference.aspose.com/slides/th/php-java/aspose.slides/baseoverridethememanager/). ในการปฏิบัติ, ธีมที่มีผลต่อสไลด์หนึ่งจะถูกกำหนดโดยการสืบทอดตามลำดับนี้: ธีมของงานนำเสนอ, การเขียนทับของ Master, การเขียนทับของ Layout, และการเขียนทับของสไลด์

![ส่วนประกอบของธีม: สี, แบบอักษร, สไตล์พื้นหลัง, และเอฟเฟ็กต์](theme-constituents.png)

ส่วนต่อไปนี้แสดงวิธีการทำงานกับธีมที่พบบ่อยที่สุด: ตรวจสอบธีม, เปลี่ยนสีและแบบอักษร, คัดลอกหรือใช้ธีม, ปรับสไตล์พื้นหลังและเอฟเฟ็กต์, และอ่านค่าที่มีผลหลังจากการสืบทอดและการเขียนทับเสร็จสมบูรณ์

## **ตรวจสอบธีม**

ออบเจ็กต์ [MasterTheme](https://reference.aspose.com/slides/th/php-java/aspose.slides/mastertheme/) เปิดเผยโครงสร้างสี, โครงสร้างแบบอักษร, และโครงสร้างรูปแบบของธีมผ่าน [MasterTheme.getColorScheme](https://reference.aspose.com/slides/th/php-java/aspose.slides/mastertheme/), [MasterTheme.getFontScheme](https://reference.aspose.com/slides/th/php-java/aspose.slides/mastertheme/), และ [MasterTheme.getFormatScheme](https://reference.aspose.com/slides/th/php-java/aspose.slides/mastertheme/). การตรวจสอบคอลเลกชันเหล่านี้ก่อนทำการเปลี่ยนแปลงเป็นประโยชน์อย่างยิ่งเมื่อได้รับงานนำเสนอจากแหล่งภายนอก เพราะจำนวนและเนื้อหาของรายการสไตล์อาจแตกต่างกัน

ตัวอย่างต่อไปนี้อ่านคุณสมบัติหลักของธีมและรายงานจำนวนสไตล์พื้นหลัง, เติม, เส้น, และเอฟเฟ็กต์ที่จัดเก็บไว้ในธีม:

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

หากไฟล์ใช้ Master หลายชุด, อย่าสมมติว่าสไลด์แต่ละสไลด์มีธีมที่มีผลเหมือนกัน ตรวจสอบ Master ที่เชื่อมโยงกับสไลด์, แล้วใช้กระบวนการธีมที่มีผลตามที่แสดงต่อไปนี้เมื่ออาจมีการเขียนทับที่ Layout หรือสไลด์

## **เปลี่ยนสีธีม**

การเติม, เส้น, และข้อความที่รับรู้ธีมสามารถอ้างอิงสีเชิงตรรกะจาก enumeration [SchemeColor](https://reference.aspose.com/slides/th/php-java/aspose.slides/schemecolor/) เมื่อคุณเปลี่ยนรายการที่สอดคล้องใน [ColorScheme](https://reference.aspose.com/slides/th/php-java/aspose.slides/colorscheme/), ทุกออบเจ็กต์ที่ยังอ้างอิงสีธีมนั้นจะได้รับการแก้ไขตามค่าที่ใหม่. ออบเจ็กต์ที่ใช้สี RGB โดยตรงจะไม่ถูกเปลี่ยนแปลงโดยการอัพเดตสีธีม

ตัวอย่างต่อไปนี้เป็นการทำงานแบบครบวงจร: สร้างรูปทรงที่ใช้ `Accent4`, เปลี่ยนสี `Accent4` ของธีมเป็นสีแดง, บันทึกงานนำเสนอ, เปิดใหม่, และพิมพ์สีการเติมที่มีผล:

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

เพราะสี่เหลี่ยมยังคงเชื่อมโยงกับ `Accent4`, สีที่มองเห็นจะกลายเป็นสีแดงหลังจากเปลี่ยนธีม. หากคุณแทนที่สีจากสกีมด้วยสีโดยตรงบนรูปทรง, การเปลี่ยน `Accent4` ภายหลังจะไม่มีผลต่อการเติมนั้นอีกต่อไป

### **ใช้สีจากพาเลตเพิ่มเติม**

PowerPoint สร้างเวอร์ชันสีอ่อนและสีเข้มจากสีธีมโดยใช้การแปลงสี. Aspose.Slides แสดงการแปลงเหล่านี้ผ่าน enumeration [ColorTransformOperation](https://reference.aspose.com/slides/th/php-java/aspose.slides/colortransformoperation/).

![สีธีมหลักและสีอ่อน‑สีเข้มที่สร้างจากพาเลตเพิ่มเติม](additional-palette-colors.png)

**1** - สีธีมหลัก

**2** - เวอร์ชันสีอ่อนและสีเข้มที่สร้างจากสีธีมหลัก

ตัวอย่างต่อไปนี้สร้างสี่เหลี่ยมหกรูปที่อิงจาก `Accent4`, ทำการแปลงความสว่างให้ห้าอัน, และบันทึกผลลัพธ์:

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

เวอร์ชันเหล่านี้ยังคงอิงตามสีธีม. หาก `Accent4` มีการเปลี่ยนแปลงในภายหลัง, สีที่แปลงจะถูกคำนวณใหม่จากค่า `Accent4` ใหม่

### **แมปค่า `SchemeColor` ไปยังช่อง `ColorScheme`**

enumeration [SchemeColor](https://reference.aspose.com/slides/th/php-java/aspose.slides/schemecolor/) ใช้ `Text1`, `Background1`, `Text2`, และ `Background2`, ในขณะที่ [ColorScheme](https://reference.aspose.com/slides/th/php-java/aspose.slides/colorscheme/) เปิดเผยช่องธีมเดียวกันเป็น `Dark1`, `Light1`, `Dark2`, และ `Light2`. การแมปนี้คงที่:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

นี่เป็นชื่อทางเลือกของช่องธีมเดียวกัน; ไม่ได้เป็นค่าที่ถูกแปลงแบบไดนามิกจากรูปแบบหนึ่งไปยังอีกรูปแบบหนึ่ง

## **เปลี่ยนแบบอักษรธีม**

สกีมแบบอักษรของธีมประกอบด้วยชุดแบบอักษรหลักสำหรับหัวเรื่องและชุดแบบอักษรรองสำหรับเนื้อหา. วิธีการ [FontScheme.getMajor](https://reference.aspose.com/slides/th/php-java/aspose.slides/fontscheme/) และ [FontScheme.getMinor](https://reference.aspose.com/slides/th/php-java/aspose.slides/fontscheme/) เปิดเผยชุดเหล่านี้

ตัวระบุแบบอักษรธีมที่เข้ากันกับ PowerPoint สามารถใช้ได้ในการจัดรูปแบบข้อความ:

* `+mn-lt` - แบบอักษรตัวอักษรภาษาละติน (Minor Latin Font)
* `+mj-lt` - แบบอักษรหัวเรื่องภาษาละติน (Major Latin Font)
* `+mn-ea` - แบบอักษรภาษาตะวันออกเอเชีย (Minor East Asian Font)
* `+mj-ea` - แบบอักษรหัวเรื่องภาษาตะวันออกเอเชีย (Major East Asian Font)

ตัวอย่างต่อไปนี้สร้างหัวเรื่องหนึ่งที่ใช้แบบอักษรละตินหลักและบรรทัดเนื้อหาหนึ่งที่ใช้แบบอักษรละตินรอง. จากนั้นเปลี่ยนแบบอักษรธีมและบันทึกผลลัพธ์:

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

หัวเรื่องจะใช้แบบอักษรหลักและข้อความทั่วไปจะใช้แบบอักษรรอง. ข้อความที่ระบุชื่อแบบอักษรโดยตรงแทนตัวระบุธีมจะไม่สลับอัตโนมัติเมื่อสกีมแบบอักษรธีมเปลี่ยน

{{% alert color="info" title="Tip" %}}

สำหรับข้อมูลเพิ่มเติมเกี่ยวกับแบบอักษรในงานนำเสนอ, ดูที่ [PowerPoint Fonts](/slides/th/php-java/powerpoint-fonts/).

{{% /alert %}}

## **คัดลอกหรือใช้ธีม**

มีสองกระบวนการทำงานทั่วไป, และแต่ละแบบแก้ปัญหาที่แตกต่างกัน

### **คงธีมต้นฉบับเมื่อย้ายสไลด์**

หากต้องการย้ายสไลด์ไปยังงานนำเสนออื่นและคงการออกแบบเดิมไว้, ให้ทำการโคลน Master ต้นฉบับเข้าไปในงานนำเป้าหมายด้วย [MasterSlideCollection.addClone](https://reference.aspose.com/slides/th/php-java/aspose.slides/masterslidecollection/), จากนั้นโคลนสไลด์ด้วย [SlideCollection.addClone](https://reference.aspose.com/slides/th/php-java/aspose.slides/slidecollection/) และ Master ที่โคลนมา. วิธีนี้จะพา Master, Layouts, และธีมที่เกี่ยวข้องไปด้วย

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

นี่เป็นกระบวนการที่แนะนำเมื่อสไลด์ต้นฉบับต้องการลักษณะเหมือนกันในปลายทาง. การโคลนเนื้อหาไปยัง Master เป้าหมายที่ไม่มีความสัมพันธ์อาจทำให้สี, แบบอักษร, พื้นหลัง, และเอฟเฟ็กต์ที่ขับเคลื่อนด้วยธีมเปลี่ยนแปลงไป

### **ใช้ค่าธีมกับสไลด์ที่มีอยู่**

หากสไลด์เป้าหมายต้องคงอยู่บน Master และ Layout ปัจจุบัน, ให้เริ่มต้นการเขียนทับระดับสไลด์จากธีมต้นฉบับ. วิธีการ [OverrideTheme.initColorSchemeFrom](https://reference.aspose.com/slides/th/php-java/aspose.slides/overridetheme/), [OverrideTheme.initFontSchemeFrom](https://reference.aspose.com/slides/th/php-java/aspose.slides/overridetheme/), และ [OverrideTheme.initFormatSchemeFrom](https://reference.aspose.com/slides/th/php-java/aspose.slides/overridetheme/) จะคัดลอกสามส่วนหลักของธีมเข้าสู่การเขียนทับ

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

วิธีนี้จะเปลี่ยนธีมที่ใช้โดยสไลด์นั้นโดยไม่กระทบต่อธีมที่สืบทอดโดยสไลด์อื่น. เพื่อเอาการเขียนทับระดับโลคัลออกและคืนค่าเป็นค่าที่สืบทอด, เรียกใช้ [OverrideTheme.clear](https://reference.aspose.com/slides/th/php-java/aspose.slides/overridetheme/)

### **ใช้การเขียนทับธีมกับ Layout**

การเขียนทับระดับ Layout จะมีผลกับสไลด์ที่ใช้ Layout นั้น, ยกเว้นสไลด์บางสไลด์ที่มีการเขียนทับของตนเอง. วิธีการเริ่มต้นเดียวกันสามารถใช้ผ่าน [LayoutSlideThemeManager](https://reference.aspose.com/slides/th/php-java/aspose.slides/layoutslidethememanager/):

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

ใช้ธีมระดับ Master หรือระดับงานนำเสนอเมื่อหลาย Layout และสไลด์ควรแชร์การออกแบบพื้นฐานเดียวกัน, ใช้การเขียนทับระดับ Layout เมื่อชุด Layout หนึ่งต้องการสไตล์ที่แตกต่าง, และใช้การเขียนทับระดับสไลด์เฉพาะกรณีพิเศษจริง ๆ. การเขียนทับระดับสไลด์มากเกินไปทำให้การเปลี่ยนธีมโดยรวมในภายหลังยากต่อการคาดการณ์

## **อัปเดตสไตล์พื้นหลังของธีม**

การเติมพื้นหลังของธีมถูกจัดเก็บใน [FormatScheme.getBackgroundFillStyles](https://reference.aspose.com/slides/th/php-java/aspose.slides/formatscheme/). PowerPoint สามารถแสดงตัวเลือกพื้นหลังได้มากกว่าจำนวนการเติมที่จริง ๆ ถูกจัดเก็บในคอลเลกชันนี้ เพราะ UI สามารถผสานการเติมธีมกับสีธีมและการอ้างอิงสไตล์อื่น ๆ

![แกลเลอรีสไตล์พื้นหลังของ PowerPoint สำหรับธีมงานนำเสนอ](presentation-design_8.png)

ก่อนใช้สไตล์พื้นหลัง, ตรวจสอบคอลเลกชันที่จัดเก็บและค่า [Background.getStyleIndex](https://reference.aspose.com/slides/th/php-java/aspose.slides/background/) ปัจจุบัน. ดัชนีสไตล์ค่า `0` หมายถึงไม่มีการเติมตามธีม; ค่าบวกเป็นการอ้างอิงสไตล์พื้นหลังของธีม. สิ่งนี้แตกต่างจากการใช้ดัชนีของคอลเลกชัน PHP โดยตรง, ที่ `get_Item(0)` หมายถึงรายการแรกที่จัดเก็บ. อย่าสมมติว่างานนำเสนอทุกไฟล์มีจำนวนสไตล์การเติมพื้นหลังเท่าเดียวกัน

ตัวอย่างต่อไปนี้รายงานจำนวนการเติมพื้นหลังที่มี, กำหนดการอ้างอิงพื้นหลังตามธีมให้กับ Master ตัวแรก, และบันทึกงานนำเสนอ:

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

ผลลัพธ์ที่มองเห็นขึ้นอยู่กับรายการธีมที่ Master อ้างอิงและการเขียนทับพื้นหลังที่ Layout หรือสไลด์. หากสไลด์ใช้พื้นหลังของตนเอง, การเปลี่ยนแค่พื้นหลังของ Master อาจไม่กระทบต่อสไลด์นั้น. ใช้ [Background.getEffective](https://reference.aspose.com/slides/th/php-java/aspose.slides/background/) เมื่อคุณต้องการทราบพื้นหลังสุดท้ายหลังจากการสืบทอด

{{% alert color="warning" title="Warning" %}}

อย่าถือว่าดัชนีสไตล์เป็นดัชนีของคอลเลกชันที่เริ่มจากศูนย์. อย่าฮาร์ดโค๊ดหมายเลขสไตล์จากไฟล์หนึ่งและสมมติว่ามันจะมีลักษณะเดียวกันในไฟล์อื่น; คำจำกัดความสไตล์ของธีมเป็นเฉพาะงานนำเสนอ

{{% /alert %}}

{{% alert color="info" title="Tip" %}}

สำหรับการจัดรูปแบบพื้นหลังโดยตรงและการสืบทอดพื้นหลัง, ดูที่ [Presentation Background](/slides/th/php-java/presentation-background/).

{{% /alert %}}

## **อัปเดตเอฟเฟ็กต์ของธีม**

สกีมรูปแบบของธีมมีคอลเลกชันการเติม, เส้น, และเอฟเฟ็กต์แยกกันที่เปิดเผยผ่าน [FormatScheme.getFillStyles](https://reference.aspose.com/slides/th/php-java/aspose.slides/formatscheme/), [FormatScheme.getLineStyles](https://reference.aspose.com/slides/th/php-java/aspose.slides/formatscheme/), และ [FormatScheme.getEffectStyles](https://reference.aspose.com/slides/th/php-java/aspose.slides/formatscheme/). ธีม Office อย่างทั่วไปมักมีรายการสไตล์หลักสามรายการที่สอดคล้องกับการจัดรูปแบบแบบ Subtle, Moderate, และ Intense, แต่โค้ดควรตรวจสอบแต่ละคอลเลกชันแทนการสมมติว่ามีจำนวนคงที่

![เอฟเฟ็กต์ธีมแบบ Subtle, Moderate, และ Intense ที่ประยุกต์กับรูปทรงเดียวกัน](presentation-design_10.png)

เมื่อคุณเข้าถึงคอลเลกชันเหล่านี้ใน PHP, ดัชนีของคอลเลกชันเริ่มจากศูนย์: `get_Item(0)` คือสไตล์แรกที่จัดเก็บและ `get_Item(2)` คือสไตล์ที่สาม. ดัชนีการอ้างอิงสไตล์ของรูปทรงเป็นแนวคิดแยกหนึ่ง, เปิดเผยผ่าน [ShapeStyle](https://reference.aspose.com/slides/th/php-java/aspose.slides/shapestyle/). การแก้ไขสไตล์ธีมจะส่งผลต่อรูปทรงที่อ้างอิงสไตล์ธีมนั้น; รูปทรงที่มีการจัดรูปแบบโดยตรงอาจคงเดิม

ตัวอย่างต่อไปนี้ตรวจสอบว่ามีรายการสไตล์ที่ต้องการหรือไม่, เปลี่ยนสไตล์เส้นแรก, เปลี่ยนสไตล์เติมที่สาม, เปิดใช้งานเงาแบบนอกในสไตล์เอฟเฟ็กต์ที่สาม, และบันทึกผลลัพธ์:

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

สำหรับรูปทรงที่อ้างอิงช่องเหล่านี้, สไตล์เส้นแรกของธีมจะเป็นสีแดง, สไตล์เติมที่สามของธีมจะเป็นสีเขียวป่าแบบทึบ, และสไตล์เอฟเฟ็กต์ที่สามจะเพิ่มเงานอกที่ระยะ 10 จุด. ผลลัพธ์ภาพที่แน่นอนยังคงขึ้นกับว่ารูปทรงแต่ละอันอ้างอิงช่องสไตล์ใดและว่าการจัดรูปแบบโดยตรงได้เขียนทับธีมหรือไม่

![สไตล์เอฟเฟ็กต์ของธีมหลังจากเปลี่ยนการตั้งค่าเส้น, เติม, และเงา](presentation-design_11.png)

## **อ่านค่าธีมที่มีผล**

ออบเจ็กต์ธีมดิบบอกคุณว่าอะไรที่กำหนดไว้ในระดับหนึ่ง. ค่าที่มีผลบอกคุณว่าสไลด์หรือรูปทรงใช้ค่าใดจริงหลังจากการสืบทอดและการเขียนทับท้องถิ่นเสร็จ. สำหรับสไลด์, เรียก [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/th/php-java/aspose.slides/baseoverridethememanager/). สำหรับพื้นหลัง, ใช้ [Background.getEffective](https://reference.aspose.com/slides/th/php-java/aspose.slides/background/), และสำหรับการเติม, ใช้ [FillFormat.getEffective](https://reference.aspose.com/slides/th/php-java/aspose.slides/fillformat/)

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

ใช้ข้อมูลที่มีผลสำหรับการวินิจฉัยการเรนเดอร์, การตรวจสอบ, และการเปรียบเทียบ. หากคุณตรวจสอบเฉพาะ [Presentation.getMasterTheme](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentation/), คุณอาจพลาดการเขียนทับของ Master, Layout, สไลด์, หรือรูปทรงที่เปลี่ยนรูปลักษณ์สุดท้าย

## **FAQ**

**Can I apply a theme to a single slide without changing the master?**

Yes. Use the slide's [SlideThemeManager](https://reference.aspose.com/slides/th/php-java/aspose.slides/slidethememanager/) and initialize its override theme. The change remains local to that slide; other slides continue to inherit their existing themes.

**What is the safest way to carry a theme from one presentation to another?**

When moving a slide and preserving its source appearance, clone the source master into the destination and clone the slide with that master using [MasterSlideCollection.addClone](https://reference.aspose.com/slides/th/php-java/aspose.slides/masterslidecollection/) and [SlideCollection.addClone](https://reference.aspose.com/slides/th/php-java/aspose.slides/slidecollection/). This keeps the master, layouts, and theme together.

**How can I see the effective values after inheritance and overrides?**

Use [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/th/php-java/aspose.slides/baseoverridethememanager/) for a slide or layout theme and the corresponding effective-data methods for format objects such as [Background.getEffective](https://reference.aspose.com/slides/th/php-java/aspose.slides/background/) and [FillFormat.getEffective](https://reference.aspose.com/slides/th/php-java/aspose.slides/fillformat/). These APIs return the resolved values after inheritance and overrides are applied.