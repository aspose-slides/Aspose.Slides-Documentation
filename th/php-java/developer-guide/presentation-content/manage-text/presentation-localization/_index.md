---
title: ทำให้การแปลภาษาของงานนำเสนอเป็นอัตโนมัติใน PHP
linktitle: การแปลภาษาในงานนำเสนอ
type: docs
weight: 100
url: /th/php-java/presentation-localization/
keywords:
- เปลี่ยนภาษา
- ตรวจการสะกด
- ปิดการตรวจการสะกด
- ภาษาการพิสูจน์
- รหัสภาษา
- ข้อความหลายภาษา
- PowerPoint
- งานนำเสนอ
- PHP
- Aspose.Slides
description: "กำหนดภาษาการพิสูจน์สำหรับข้อความงานนำเสนอ PowerPoint และ OpenDocument ใน PHP ด้วย Aspose.Slides รวมถึงค่าปริยายและย่อหน้าหลายภาษา."
---
## **ภาพรวม**

Aspose.Slides for PHP via Java ให้คุณกำหนด metadata การพิสูจน์อักษรสำหรับส่วนข้อความแต่ละส่วน ใช้ [BasePortionFormat::setLanguageId](https://reference.aspose.com/slides/th/php-java/aspose.slides/baseportionformat/#setLanguageId) เพื่อระบุภาษาการพิสูจน์, [BasePortionFormat::setSpellCheck](https://reference.aspose.com/slides/th/php-java/aspose.slides/baseportionformat/#setSpellCheck) เพื่อเปิดหรือปิดการตรวจสอบการสะกด, และ [BasePortionFormat::setProofDisabled](https://reference.aspose.com/slides/th/php-java/aspose.slides/baseportionformat/#setProofDisabled) เพื่อควบคุมสถานะ “ไม่ทำการพิสูจน์” อย่างกว้างขวาง เนื่องจากการตั้งค่าเหล่านี้ถูกนำไปใช้ในระดับส่วน, ย่อหน้าเดียวสามารถมีหลายภาษาและกฎการพิสูจน์อักษรที่แตกต่างกันได้

บทความนี้อธิบายวิธีกำหนดภาษาสำหรับข้อความเฉพาะ, ตั้งค่าภาษาเริ่มต้นสำหรับข้อความใหม่ด้วย [LoadOptions::setDefaultTextLanguage](https://reference.aspose.com/slides/th/php-java/aspose.slides/loadoptions/#setDefaultTextLanguage), สร้างย่อหน้าหลายภาษา, เลือกใช้ `SpellCheck` หรือ `ProofDisabled`, และรักษาการตั้งค่าเดิมเมื่อใช้ [Presentation::joinPortionsWithSameFormatting](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentation/#joinPortionsWithSameFormatting) คุณสมบัติเหล่านี้เก็บ metadata สำหรับแอปพลิเคชันพรีเซนเทชัน; ไม่ได้แปลข้อความ, ทำการตรวจสอบการสะกดโดยใช้พจนานุกรม, หรือคืนคำที่สะกดผิด

## **ตั้งค่าภาษา Proofing สำหรับข้อความ**

สร้างหรือโหลด [Presentation](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentation/), เข้าถึงส่วนข้อความที่ต้องการผ่าน [Portion::getPortionFormat](https://reference.aspose.com/slides/th/php-java/aspose.slides/portion/#getPortionFormat), แล้วกำหนดรหัสภาษาของมัน ตัวอย่างต่อไปนี้สร้างรูปร่าง, ตั้งค่าอังกฤษแบบบริติชเป็นภาษาการพิสูจน์, และบันทึกผลลัพธ์ด้วย [Presentation::save](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentation/#save):

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 320, 80);
    $shape->getTextFrame()->setText("Set the proofing language for this text.");

    $portion = $shape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
    $portion->getPortionFormat()->setLanguageId("en-GB");

    $presentation->save("proofing_language.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **ตั้งค่าภาษาเริ่มต้นสำหรับข้อความใหม่**

ใช้ [LoadOptions::setDefaultTextLanguage](https://reference.aspose.com/slides/th/php-java/aspose.slides/loadoptions/#setDefaultTextLanguage) เพื่อระบุภาษาการพิสูจน์ที่ Aspose.Slides จะกำหนดให้กับข้อความที่สร้างใหม่ การตั้งค่านี้มีประโยชน์เมื่อข้อความใหม่ส่วนใหญ่หรือทั้งหมดในพรีเซนเทชันใช้ภาษาเดียวกัน ไม่ได้เปลี่ยนแปลง metadata ของข้อความที่มีการกำหนดภาษาชัดเจนแล้ว

ตัวอย่างต่อไปนี้สร้างพรีเซนเทชันที่ข้อความใหม่ใช้กฎการพิสูจน์ภาษาเยอรมัน:

```php
use aspose\slides\LoadOptions;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$loadOptions = new LoadOptions();
$loadOptions->setDefaultTextLanguage("de-DE");

$presentation = new Presentation($loadOptions);
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 320, 80);
    $shape->getTextFrame()->setText("Willkommen zur Präsentation");

    $presentation->save("default_text_language.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **ใช้หลายภาษาในย่อหน้าเดียว**

[Paragraph](https://reference.aspose.com/slides/th/php-java/aspose.slides/paragraph/) มีคอลเลกชันของส่วนข้อความ สร้าง [Portion](https://reference.aspose.com/slides/th/php-java/aspose.slides/portion/) แยกกันสำหรับแต่ละภาษาและตั้งค่า `LanguageId` ของแต่ละส่วนอย่างอิสระ

ตัวอย่างนี้สร้างย่อหน้าเดียวที่มีส่วนภาษาอังกฤษและฝรั่งเศส:

```php
use aspose\slides\Portion;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 420, 80);
    $paragraph = $shape->getTextFrame()->getParagraphs()->get_Item(0);
    $paragraph->getPortions()->clear();

    $englishPortion = new Portion("Welcome");
    $englishPortion->getPortionFormat()->setLanguageId("en-US");
    $paragraph->getPortions()->add($englishPortion);

    $frenchPortion = new Portion(" — Bienvenue");
    $frenchPortion->getPortionFormat()->setLanguageId("fr-FR");
    $paragraph->getPortions()->add($frenchPortion);

    $presentation->save("multilingual_text.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **เปิดหรือปิดการตรวจสอบการสะกดสำหรับส่วนย่อยแต่ละส่วน**

[PortionFormat](https://reference.aspose.com/slides/th/php-java/aspose.slides/portionformat/) สืบทอดคุณสมบัติข้อความทั่วไปจาก [BasePortionFormat](https://reference.aspose.com/slides/th/php-java/aspose.slides/baseportionformat/). เข้าถึงรูปแบบของส่วนผ่าน [Portion::getPortionFormat](https://reference.aspose.com/slides/th/php-java/aspose.slides/portion/#getPortionFormat) แล้วใช้ [BasePortionFormat::setSpellCheck](https://reference.aspose.com/slides/th/php-java/aspose.slides/baseportionformat/#setSpellCheck) เพื่อควบคุมว่ามีการตรวจสอบการสะกดคำหรือไม่ ค่าเริ่มต้นคือ `false`: `true` เปิดการตรวจสอบ, `false` ปิดการตรวจสอบ

การตั้งค่านี้ใช้กับส่วนข้อความแต่ละส่วน ส่วนต่าง ๆ ในย่อหน้าเดียวจึงสามารถใช้ค่าต่างกันได้ [BasePortionFormat::setLanguageId](https://reference.aspose.com/slides/th/php-java/aspose.slides/baseportionformat/#setLanguageId) และ `setSpellCheck` ทำหน้าที่เสริมกัน: `setLanguageId` ระบุภาษาการพิสูจน์, ส่วน `setSpellCheck` กำหนดว่าการตรวจสอบการสะกดจะทำได้หรือไม่

[BasePortionFormat::setProofDisabled](https://reference.aspose.com/slides/th/php-java/aspose.slides/baseportionformat/#setProofDisabled) ยังควบคุมการพิสูจน์, แต่เป็นสถานะ “ไม่ทำการพิสูจน์” ที่กว้างกว่าโดยใช้ [NullableBool](https://reference.aspose.com/slides/th/php-java/aspose.slides/nullablebool/). ใช้ `setSpellCheck` เมื่อคุณต้องการสวิตช์แบบ Boolean ตรงสำหรับการตรวจสอบการสะกด ใช้ `setProofDisabled` เมื่อคุณต้องการเก็บหรือควบคุม metadata “ไม่ทำการพิสูจน์” ของพรีเซนเทชันอย่างชัดเจน รวมถึงสถานะ `NotDefined` หากตั้งค่าทั้งสองให้ค่าตรงกัน; อย่าใช้ `setSpellCheck(true)` ร่วมกับ `setProofDisabled(NullableBool::True)`

คุณสมบัติเหล่านี้กำหนด metadata การพิสูจน์ที่ PowerPoint และแอปพลิเคชันพรีเซนเทชันอื่นใช้ Aspose.Slides ไม่ได้ใช้เพื่อรันการตรวจสอบการสะกดโดยพจนานุกรม หรือคืนรายการคำที่สะกดผิด

ตัวอย่างเต็มต่อไปนี้สร้างพรีเซนเทชันต้นฉบับ, โหลดมัน, กำหนดการตั้งค่าการตรวจสอบการสะกดและภาษาการพิสูจน์ที่แตกต่างให้สองส่วนในย่อหน้าเดียว, บันทึกผลลัพธ์, เปิดใหม่, และตรวจสอบค่าที่เก็บไว้:

```php
use aspose\slides\Portion;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$inputFile = "spell_check_input.pptx";
$outputFile = "spell_check_settings.pptx";

$sourcePresentation = new Presentation();
try {
    $sourceSlide = $sourcePresentation->getSlides()->get_Item(0);
    $sourceShape = $sourceSlide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 420, 80);
    $sourceParagraph = $sourceShape->getTextFrame()->getParagraphs()->get_Item(0);
    $sourceParagraph->getPortions()->clear();

    $sourceEnglishPortion = new Portion("Check this text. ");
    $sourceEnglishPortion->getPortionFormat()->setLanguageId("en-US");
    $sourceParagraph->getPortions()->add($sourceEnglishPortion);

    $sourceFrenchPortion = new Portion("Ignorer ce code : ZX-81.");
    $sourceFrenchPortion->getPortionFormat()->setLanguageId("fr-FR");
    $sourceParagraph->getPortions()->add($sourceFrenchPortion);

    $sourcePresentation->save($inputFile, SaveFormat::Pptx);
} finally {
    $sourcePresentation->dispose();
}

$presentation = new Presentation($inputFile);
try {
    $shape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $portions = $shape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions();

    $checkedPortion = $portions->get_Item(0);
    $checkedPortion->getPortionFormat()->setLanguageId("en-US");
    $checkedPortion->getPortionFormat()->setSpellCheck(true);

    $suppressedPortion = $portions->get_Item(1);
    $suppressedPortion->getPortionFormat()->setLanguageId("fr-FR");
    $suppressedPortion->getPortionFormat()->setSpellCheck(false);

    $presentation->save($outputFile, SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}

$reopenedPresentation = new Presentation($outputFile);
try {
    $reopenedShape = $reopenedPresentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $storedPortions = $reopenedShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions();

    $storedPortionCount = java_values($storedPortions->getCount());
    $firstStoredFormat = $storedPortions->get_Item(0)->getPortionFormat();
    $secondStoredFormat = $storedPortions->get_Item(1)->getPortionFormat();

    $firstPortionStored = $storedPortionCount === 2 && 
        java_values($firstStoredFormat->getLanguageId()) === "en-US" && 
        java_values($firstStoredFormat->getSpellCheck());

    $secondPortionStored = $storedPortionCount === 2 && 
        java_values($secondStoredFormat->getLanguageId()) === "fr-FR" && 
        !java_values($secondStoredFormat->getSpellCheck());

    if ($firstPortionStored && $secondPortionStored) {
        echo "The proofing settings were stored correctly.";
    } else {
        echo "The proofing settings could not be verified.";
    }
} finally {
    $reopenedPresentation->dispose();
}
```

[Presentation::joinPortionsWithSameFormatting](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentation/#joinPortionsWithSameFormatting) รวมส่วนที่อยู่ติดกันและมีรูปแบบเดียวกัน ความแตกต่างเพียง `SpellCheck` อย่างเดียวไม่ทำให้ส่วนเหล่านั้นแยกออกจากกัน; หลังจากรวมแล้วส่วนที่ได้จะคงค่าของ `SpellCheck` ของส่วนแรก หากส่วนต้องการการตั้งค่าการตรวจสอบต่างกัน ให้เรียก `joinPortionsWithSameFormatting` ก่อนกำหนดค่าดังกล่าว, หรือสแกนขอบเขตของส่วนที่ได้และตั้งค่าใหม่หลังจากนั้น ส่วนที่มีค่า `LanguageId` แตกต่างกันยังคงแยกจากกัน เพราะรูปแบบภาษาการพิสูจน์ต่างกัน

## **คำถามที่พบบ่อย**

**รหัสภาษา (language ID) ทำให้ข้อความแปลหรือไม่?**

ไม่. [BasePortionFormat::setLanguageId](https://reference.aspose.com/slides/th/php-java/aspose.slides/baseportionformat/#setLanguageId) เก็บ metadata การพิสูจน์สำหรับการสะกดและไวยากรณ์; ไม่ได้เปลี่ยนเนื้อหาข้อความ แปลข้อความแยกต่างหาก แล้วตั้งรหัสภาษาที่เหมาะสมสำหรับแต่ละส่วนที่แปลแล้ว

**ภาษาการพิสูจน์ควบคุมฟอนต์, การแบ่งคำ, หรือการตัดบรรทัดหรือไม่?**

ไม่. รหัสภาษามีไว้เพื่อการพิสูจน์เท่านั้น การเรนเดอร์และการจัดวางข้อความอิงตาม [ฟอนต์](/slides/th/php-java/powerpoint-fonts/), ระบบการเขียน, และการตั้งค่ากรอบข้อความ สำหรับการเรนเดอร์ที่ถูกต้อง ให้จัดเตรียมฟอนต์ที่ต้องการ, กำหนด [การแทนที่ฟอนต์](/slides/th/php-java/font-substitution/), หรือ [ฝังฟอนต์](/slides/th/php-java/embedded-font/) ในพรีเซนเทชัน

**ย่อหน้าเดียวสามารถใช้หลายภาษาการพิสูจน์ได้หรือไม่?**

ได้. กำหนดแต่ละภาษาให้กับส่วนแยกต่างหาก ตามตัวอย่างย่อหน้าหลายภาษา

**ควรใช้ `setDefaultTextLanguage` หรือ `setLanguageId`?**

ใช้ [LoadOptions::setDefaultTextLanguage](https://reference.aspose.com/slides/th/php-java/aspose.slides/loadoptions/#setDefaultTextLanguage) เมื่อคุณต้องการตั้งค่าภาษาเริ่มต้นสำหรับข้อความที่สร้างใหม่ ใช้ [BasePortionFormat::setLanguageId](https://reference.aspose.com/slides/th/php-java/aspose.slides/baseportionformat/#setLanguageId) เมื่อส่วนข้อความใดต้องการภาษาการพิสูจน์เฉพาะ หรือเมื่อย่อหน้ามีหลายภาษา