---
title: จัดรูปแบบข้อความการนำเสนอใน PHP
linktitle: การจัดรูปแบบข้อความ
type: docs
weight: 50
url: /th/php-java/text-formatting/
keywords:
- จัดแนวย่อหน้า
- รูปแบบข้อความ
- พื้นหลังข้อความ
- ความโปร่งใสของข้อความ
- การเว้นระยะห่างอักขระ
- คุณสมบัติโฟอนต์
- ตระกูลฟอนต์
- การหมุนข้อความ
- มุมการหมุน
- กรอบข้อความ
- การเว้นบรรทัด
- คุณสมบัติ autofit
- ตำแหน่งยึดกรอบข้อความ
- การจัดแท็บข้อความ
- ภาษาเริ่มต้น
- PowerPoint
- OpenDocument
- การนำเสนอ
- PHP
- Aspose.Slides
description: "จัดรูปแบบและตกแต่งข้อความในงานนำเสนอ PowerPoint และ OpenDocument ด้วย Aspose.Slides สำหรับ PHP ผ่าน Java ปรับฟอนต์ สี การจัดแนว และอื่น ๆ"
---
## **ภาพรวม**

บทความนี้แสดงวิธีการจัดรูปแบบข้อความในงานนำเสนอ PowerPoint และ OpenDocument โดยใช้ Aspose.Slides สำหรับ PHP ผ่าน Java. มันครอบคลุมสีพื้นหลัง, ความโปร่งใส, การเว้นระยะห่างระหว่างอักษร, คุณสมบัติของฟอนต์, การหมุน, การเว้นระยะห่างระหว่างย่อหน้า, พฤติกรรม autofit, การยึดข้อความ, จุดหยุดแท็บ, และการตั้งค่าภาษา.

หากไม่ได้ระบุเป็นอย่างอื่น ตัวอย่างจะใช้ [sample.pptx](sample.pptx). รูปร่างแรกบนสไลด์แรกเป็นกล่องข้อความ, และย่อหน้าแรกของมันมีข้อความที่แสดงด้านล่าง. ดัชนีของสไลด์และรูปทรงเป็นแบบเริ่มจากศูนย์. ตัวอย่างที่เลือกส่วนที่เป็นตัวหนาจะใช้การจัดรูปแบบที่มีผลจริง, รวมถึงการจัดรูปแบบตัวหนาที่สืบทอดมา:

![ข้อความตัวอย่าง](sample_text.png)

หากต้องการค้นหาและไฮไลต์ข้อความตัวอักษรหรือการจับคู่ด้วย regular-expression, ดูที่ [ค้นหาและแทนที่ข้อความ](/slides/th/php-java/search-and-replace-text/).

## **ตั้งค่าสีพื้นหลังของข้อความ**

ใช้ [ParagraphFormat::getDefaultPortionFormat](https://reference.aspose.com/slides/th/php-java/aspose.slides/paragraphformat/#getDefaultPortionFormat) เพื่อกำหนดสีไฮไลต์เริ่มต้นสำหรับย่อหน้า, หรือใช้ [BasePortionFormat::getHighlightColor](https://reference.aspose.com/slides/th/php-java/aspose.slides/baseportionformat/#getHighlightColor) สำหรับส่วนข้อความแต่ละส่วน.

ตัวอย่างต่อไปนี้กำหนดสีไฮไลต์สีเทาอ่อนเป็นค่าเริ่มต้นสำหรับย่อหน้าแรก. สีไฮไลต์ที่ระบุโดยตรงบนส่วนข้อความแต่ละส่วนจะเหนือกว่าค่าเริ่มต้นนี้:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $autoShape = $slide->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);
    $highlightColor = java("java.awt.Color")->LIGHT_GRAY;

    // ตั้งค่าสีไฮไลต์สำหรับย่อหน้าทั้งหมด.
    $paragraph->getParagraphFormat()->getDefaultPortionFormat()->getHighlightColor()->setColor($highlightColor);

    $presentation->save("gray_paragraph.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

ผลลัพธ์:

![ย่อหน้าเทา](gray_paragraph.png)

ตัวอย่างโค้ดด้านล่างแสดงวิธีตั้งค่าสีพื้นหลังสำหรับ **ส่วนข้อความที่มีตัวหนา**:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $autoShape = $slide->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);
    $highlightColor = java("java.awt.Color")->LIGHT_GRAY;

    $portionCount = java_values($paragraph->getPortions()->getCount());
    for ($portionIndex = 0; $portionIndex < $portionCount; $portionIndex++) {
        $portion = $paragraph->getPortions()->get_Item($portionIndex);
        if (java_values($portion->getPortionFormat()->getEffective()->getFontBold())) {
            // ตั้งค่าสีไฮไลต์สำหรับส่วนข้อความ.
            $portion->getPortionFormat()->getHighlightColor()->setColor($highlightColor);
        }
    }

    $presentation->save("gray_text_portions.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

ผลลัพธ์:

![ส่วนข้อความสีเทา](gray_text_portions.png)

## **จัดตำแหน่งย่อหน้าข้อความ**

ใช้ [ParagraphFormat::setAlignment](https://reference.aspose.com/slides/th/php-java/aspose.slides/paragraphformat/#setAlignment) เพื่อตั้งค่าการจัดตำแหน่งย่อหน้าในกรอบข้อความ. ค่าที่ตั้งได้อาจเป็นการจัดกึ่งกลาง, ชิดซ้าย, ชิดขวา, จัดแนวเต็ม, ฯลฯ.

ตัวอย่างโค้ดต่อไปนี้แสดงวิธีจัดตำแหน่งย่อหน้าให้ **กึ่งกลาง**:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\TextAlignment;

$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $autoShape = $slide->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);

    // ตั้งค่าการจัดตำแหน่งของย่อหน้าให้เป็นกึ่งกลาง.
    $paragraph->getParagraphFormat()->setAlignment(TextAlignment::Center);

    $presentation->save("aligned_paragraph.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

ผลลัพธ์:

![ย่อหน้าที่จัดตำแหน่งแล้ว](aligned_paragraph.png)

## **ตั้งค่าความโปร่งใสสำหรับข้อความ**

ความโปร่งใสของข้อความควบคุมผ่านส่วน alpha ของสีที่กำหนดให้กับ [BasePortionFormat::getFillFormat](https://reference.aspose.com/slides/th/php-java/aspose.slides/baseportionformat/#getFillFormat). ในตัวอย่างด้านล่าง, `alpha = 50` เป็นค่าช่อง alpha ของ ARGB ในช่วง 0–255, ไม่ใช่เปอร์เซ็นต์ความโปร่งใส.

ตัวอย่างโค้ดด้านล่างแสดงวิธีใช้ความโปร่งใสกับ **ย่อหน้าทั้งหมด**:

```php
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$alpha = 50;

$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $autoShape = $slide->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);
    $fillFormat = $paragraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat();

    // ตั้งค่าสีเติมของข้อความเป็นสีโปร่งใส.
    $fillFormat->setFillType(FillType::Solid);
    $transparentColor = new Java("java.awt.Color", 0, 0, 0, $alpha);
    $fillFormat->getSolidFillColor()->setColor($transparentColor);

    $presentation->save("transparent_paragraph.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

ผลลัพธ์:

![ย่อหน้าที่โปร่งใส](transparent_paragraph.png)

ตัวอย่างโค้ดต่อไปนี้แสดงวิธีใช้ความโปร่งใสกับ **ส่วนข้อความที่มีตัวหนา**:

```php
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$alpha = 50;

$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $autoShape = $slide->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);
    $transparentColor = new Java("java.awt.Color", 0, 0, 0, $alpha);

    $portionCount = java_values($paragraph->getPortions()->getCount());
    for ($portionIndex = 0; $portionIndex < $portionCount; $portionIndex++) {
        $portion = $paragraph->getPortions()->get_Item($portionIndex);
        if (java_values($portion->getPortionFormat()->getEffective()->getFontBold())) {
            // ตั้งค่าความโปร่งใสของส่วนข้อความ.
            $fillFormat = $portion->getPortionFormat()->getFillFormat();
            $fillFormat->setFillType(FillType::Solid);
            $fillFormat->getSolidFillColor()->setColor($transparentColor);
        }
    }

    $presentation->save("transparent_text_portions.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

ผลลัพธ์:

![ส่วนข้อความที่โปร่งใส](transparent_text_portions.png)

## **ตั้งค่าการเว้นระยะห่างของอักขระสำหรับข้อความ**

ใช้ [BasePortionFormat::setSpacing](https://reference.aspose.com/slides/th/php-java/aspose.slides/baseportionformat/#setSpacing) เพื่อขยายหรือทำให้การเว้นระยะห่างระหว่างอักขระในกล่องข้อความแคบลง. ตัวอย่างเพิ่มระยะห่าง 3 พอยต์; ค่าลบจะทำให้ข้อความแน่นขึ้น.

โค้ด PHP ต่อไปนี้แสดงวิธีขยายการเว้นระยะห่างอักขระใน **ย่อหน้าทั้งหมด**:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $autoShape = $slide->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);

    // หมายเหตุ: ใช้ค่าลบเพื่อบีบอัดระยะห่างของอักขระ.
    $paragraph->getParagraphFormat()->getDefaultPortionFormat()->setSpacing(3); // ขยายระยะห่างของอักขระ.

    $presentation->save("character_spacing_in_paragraph.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

ผลลัพธ์:

![การเว้นระยะห่างของอักขระในย่อหน้า](character_spacing_in_paragraph.png)

ตัวอย่างโค้ดด้านล่างแสดงวิธีขยายการเว้นระยะห่างอักขระใน **ส่วนข้อความที่มีตัวหนา**:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $autoShape = $slide->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);

    $portionCount = java_values($paragraph->getPortions()->getCount());
    for ($portionIndex = 0; $portionIndex < $portionCount; $portionIndex++) {
        $portion = $paragraph->getPortions()->get_Item($portionIndex);
        if (java_values($portion->getPortionFormat()->getEffective()->getFontBold())) {
            // หมายเหตุ: ใช้ค่าลบเพื่อบีบอัดระยะห่างของอักขระ.
            $portion->getPortionFormat()->setSpacing(3); // ขยายระยะห่างของอักขระ.
        }
    }

    $presentation->save("character_spacing_in_text_portions.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

ผลลัพธ์:

![การเว้นระยะห่างของอักขระในส่วนข้อความ](character_spacing_in_text_portions.png)

### **ปิดการใช้ Kerning สำหรับฟอนต์เฉพาะ**

ในบางกรณี, ข้อความที่เรนเดอร์โดย Aspose.Slides อาจดูแคบกว่าข้อความเดียวกันที่แสดงใน PowerPoint เล็กน้อย. สิ่งนี้อาจเกิดขึ้นเนื่องจาก PowerPoint อาจละเลยข้อมูล kerning สำหรับฟอนต์บางตัว, แม้ว่าฟอนต์จะมีข้อมูล kerning ที่ถูกต้องและมีการเปิดใช้งาน kerning ในการตั้งค่าของ PowerPoint.

เพื่อทำให้ผลลัพธ์ที่เรนเดอร์ใกล้เคียงกับ PowerPoint มากขึ้นในกรณีเช่นนั้น, คุณสามารถปิดการใช้ kerning สำหรับส่วนข้อความที่ใช้ฟอนต์ที่ได้รับผลกระทบ. ตั้งค่า [BasePortionFormat::setKerningMinimalSize](https://reference.aspose.com/slides/th/php-java/aspose.slides/baseportionformat/#setKerningMinimalSize) เป็นค่าที่ใหญ่กว่าขนาดฟอนต์จริง. ตัวอย่างนี้ต้องการไฟล์ "presentation.pptx" ที่มีกล่องข้อความเป็นรูปทรงแรกบนสไลด์แรก. มันตรวจสอบชื่อฟอนต์ที่มีผล, รวมถึงฟอนต์ที่สืบทอด, และตั้งค่าขีดจำกัด 100 พอยต์สำหรับส่วนที่ใช้ Roboto. สิ่งนี้จะปิด kerning สำหรับส่วนที่ตรงกันที่มีขนาดฟอนต์ต่ำกว่า 100 พอยต์:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("presentation.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $autoShape = $slide->getShapes()->get_Item(0);
    $targetFont = "Roboto";

    $paragraphCount = java_values($autoShape->getTextFrame()->getParagraphs()->getCount());
    for ($paragraphIndex = 0; $paragraphIndex < $paragraphCount; $paragraphIndex++) {
        $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item($paragraphIndex);
        $portionCount = java_values($paragraph->getPortions()->getCount());
        for ($portionIndex = 0; $portionIndex < $portionCount; $portionIndex++) {
            $portion = $paragraph->getPortions()->get_Item($portionIndex);
            $portionFormat = $portion->getPortionFormat()->getEffective();
            $latinFont = $portionFormat->getLatinFont();
            $eastAsianFont = $portionFormat->getEastAsianFont();
            $complexScriptFont = $portionFormat->getComplexScriptFont();

            if ((!java_is_null($latinFont) && $latinFont->getFontName() == $targetFont) ||
                (!java_is_null($eastAsianFont) && $eastAsianFont->getFontName() == $targetFont) ||
                (!java_is_null($complexScriptFont) && $complexScriptFont->getFontName() == $targetFont)) {
                $portion->getPortionFormat()->setKerningMinimalSize(100);
            }
        }
    }

    $presentation->save("output.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

สำหรับข้อความที่ตรงกับเกณฑ์และอยู่ต่ำกว่าขีดจำกัด, การตั้งค่านี้จะป้องกัน kerning และสามารถช่วยให้การเรนเดอร์ของ Aspose.Slides สอดคล้องกับผลลัพธ์ภาพของ PowerPoint สำหรับฟอนต์ที่ได้รับผลจากพฤติกรรมเฉพาะของ PowerPoint นี้.

## **จัดการคุณสมบัติโฟอนต์ของข้อความ**

ฟอนต์สามารถตั้งค่าที่ระดับย่อหน้าได้ผ่าน [ParagraphFormat::getDefaultPortionFormat](https://reference.aspose.com/slides/th/php-java/aspose.slides/paragraphformat/#getDefaultPortionFormat) หรือในส่วนข้อความแต่ละส่วนผ่าน [PortionFormat](https://reference.aspose.com/slides/th/php-java/aspose.slides/portionformat/).

ตัวอย่างต่อไปนี้กำหนดฟอนต์เริ่มต้นของย่อหน้าแรกเป็น Times New Roman ขนาด 12 พอยต์ พร้อมการจัดรูปแบบตัวหนา, ตัวเอียง, และขีดเส้นใต้เป็นจุด. การจัดรูปแบบที่ระบุโดยตรงบนส่วนข้อความแต่ละส่วนจะเหนือกว่าค่าเริ่มต้นเหล่านี้:

```php
use aspose\slides\FontData;
use aspose\slides\NullableBool;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\TextUnderlineType;

$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $autoShape = $slide->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);
    $defaultPortionFormat = $paragraph->getParagraphFormat()->getDefaultPortionFormat();
    $font = new FontData("Times New Roman");

    // ตั้งค่าคุณสมบัติฟอนต์สำหรับย่อหน้า.
    $defaultPortionFormat->setFontHeight(12);
    $defaultPortionFormat->setFontBold(NullableBool::True);
    $defaultPortionFormat->setFontItalic(NullableBool::True);
    $defaultPortionFormat->setFontUnderline(TextUnderlineType::Dotted);
    $defaultPortionFormat->setLatinFont($font);

    $presentation->save("font_properties_for_paragraph.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

ผลลัพธ์:

![คุณสมบัติโฟอนต์ของย่อหน้า](font_properties_for_paragraph.png)

ตัวอย่างต่อไปนี้ใช้ Times New Roman ขนาด 13 พอยต์, การจัดรูปแบบตัวเอียง, และขีดเส้นใต้เป็นจุดกับส่วนที่มีการจัดรูปแบบตัวหนาแบบมีผล:

```php
use aspose\slides\FontData;
use aspose\slides\NullableBool;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\TextUnderlineType;

$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $autoShape = $slide->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);
    $font = new FontData("Times New Roman");

    $portionCount = java_values($paragraph->getPortions()->getCount());
    for ($portionIndex = 0; $portionIndex < $portionCount; $portionIndex++) {
        $portion = $paragraph->getPortions()->get_Item($portionIndex);
        if (java_values($portion->getPortionFormat()->getEffective()->getFontBold())) {
            // ตั้งค่าคุณสมบัติฟอนต์สำหรับส่วนข้อความ.
            $portionFormat = $portion->getPortionFormat();
            $portionFormat->setFontHeight(13);
            $portionFormat->setFontItalic(NullableBool::True);
            $portionFormat->setFontUnderline(TextUnderlineType::Dotted);
            $portionFormat->setLatinFont($font);
        }
    }

    $presentation->save("font_properties_for_text_portions.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

ผลลัพธ์:

![คุณสมบัติโฟอนต์ของส่วนข้อความ](font_properties_for_text_portions.png)

## **ตั้งค่าการหมุนของข้อความ**

ใช้ [TextFrameFormat::setTextVerticalType](https://reference.aspose.com/slides/th/php-java/aspose.slides/textframeformat/#setTextVerticalType) เพื่อกำหนดการวางแนวข้อความที่กำหนดล่วงหน้าภายในรูปทรง.

ตัวอย่างโค้ดต่อไปนี้ตั้งทิศทางข้อความในรูปทรงเป็น [TextVerticalType::Vertical270](https://reference.aspose.com/slides/th/php-java/aspose.slides/textverticaltype/), ซึ่งหมุนข้อความ **90 องศาตรงกันข้ามเข็มนาฬิกา**:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\TextVerticalType;

$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $autoShape = $slide->getShapes()->get_Item(0);
    $autoShape->getTextFrame()->getTextFrameFormat()->setTextVerticalType(TextVerticalType::Vertical270);

    $presentation->save("text_rotation.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

ผลลัพธ์:

![การหมุนของข้อความ](text_rotation.png)

## **ตั้งค่าการหมุนแบบกำหนดเองสำหรับกรอบข้อความ**

ใช้ [TextFrameFormat::setRotationAngle](https://reference.aspose.com/slides/th/php-java/aspose.slides/textframeformat/#setRotationAngle) เพื่อกำหนดมุมการหมุนแบบกำหนดเองสำหรับ [TextFrame](https://reference.aspose.com/slides/th/php-java/aspose.slides/textframe/).

ตัวอย่างโค้ดด้านล่างหมุนกรอบข้อความไป 3 องศาในทิศทางตามเข็มนาฬิกาภายในรูปทรง:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $autoShape = $slide->getShapes()->get_Item(0);
    $autoShape->getTextFrame()->getTextFrameFormat()->setRotationAngle(3);

    $presentation->save("custom_text_rotation.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

ผลลัพธ์:

![การหมุนข้อความแบบกำหนดเอง](custom_text_rotation.png)

## **ตั้งค่าการเว้นบรรทัดของย่อหน้า**

Aspose.Slides ให้ [ParagraphFormat::setSpaceAfter](https://reference.aspose.com/slides/th/php-java/aspose.slides/paragraphformat/#setSpaceAfter), [ParagraphFormat::setSpaceBefore](https://reference.aspose.com/slides/th/php-java/aspose.slides/paragraphformat/#setSpaceBefore), และ [ParagraphFormat::setSpaceWithin](https://reference.aspose.com/slides/th/php-java/aspose.slides/paragraphformat/#setSpaceWithin) เพื่อควบคุมการเว้นระยะห่างระหว่างย่อหน้า. วิธีใช้งานดังนี้:

* ใช้ค่าบวกเพื่อระบุการเว้นบรรทัดเป็นเปอร์เซ็นต์ของความสูงบรรทัด.
* ใช้ค่าลบเพื่อระบุการเว้นบรรทัดเป็นหน่วยพอยต์.

ตัวอย่างต่อไปนี้ตั้งค่าการเว้นระยะห่างภายในย่อหน้าแรกเป็น 200% ของความสูงบรรทัด (เว้นบรรทัดเป็นสองเท่า):

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $autoShape = $slide->getShapes()->get_Item(0);

    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);
    $paragraph->getParagraphFormat()->setSpaceWithin(200);

    $presentation->save("line_spacing.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

ผลลัพธ์:

![การเว้นบรรทัดภายในย่อหน้า](line_spacing.png)

## **ควบคุมการตัดบรรทัด**

กฎการตัดบรรทัดของย่อหน้าเป็นประโยชน์ในบล็อกข้อความแคบและงานนำเสนอที่ผสานข้อความละตินและเอเชียตะวันออก. วิธีต่อไปนี้เป็นของ [ParagraphFormat](https://reference.aspose.com/slides/th/php-java/aspose.slides/paragraphformat/), จึงใช้ได้กับย่อหน้าเต็ม:

- [setLatinLineBreak](https://reference.aspose.com/slides/th/php-java/aspose.slides/paragraphformat/#setLatinLineBreak) ควบคุมกฎการตัดบรรทัดของละติน. ในข้อความผสม, การเปลี่ยนแปลงนี้อาจทำให้การตัดบรรทัดของข้อความเอเชียตะวันออกและเครื่องหมายวรรคตอนที่อยู่ใกล้เคียงเปลี่ยนไปด้วย.
- [setEastAsianLineBreak](https://reference.aspose.com/slides/th/php-java/aspose.slides/paragraphformat/#setEastAsianLineBreak) ควบคุมกฎการตัดบรรทัดของเอเชียตะวันออก, รวมถึงการจำกัดอักขระที่อยู่ต้นหรือท้ายบรรทัด.

กฎเหล่านี้ไม่แทนที่ [TextFrameFormat::setWrapText](https://reference.aspose.com/slides/th/php-java/aspose.slides/textframeformat/#setWrapText), ซึ่งเปิดใช้งานการตัดบรรทัดอัตโนมัติภายในกรอบข้อความ. พวกมันมีผลต่อการจัดวางเมื่อมีการตัดบรรทัด; พวกมันไม่ได้แทรกอักขระการตัดบรรทัด. การตัดบรรทัดโดยชัดเจนจะบังคับให้เกิดบรรทัดใหม่ภายในย่อหน้าที่ไม่ขึ้นกับความกว้างที่มีอยู่.

ตัวอย่างต่อไปนี้สร้างบล็อกข้อความแคบที่ประกอบด้วยภาษาจีนและละติน. มันตั้งค่าตัวเลือกการตัดบรรทัดทั้งสองอย่างอย่างชัดแจ้งและบันทึกเป็น "line_breaking.pptx". เพื่อทดลองกับกฎใดกฎหนึ่ง, ให้เปลี่ยนค่าโดยที่ยังคงค่าของอีกกฎหนึ่งคงที่. ตัวอย่างใช้ Arial ขนาด 24 พอยต์และ SimSun กับความกว้างกรอบ 160 พอยต์และไม่มีระยะขอบแนวนอนของกรอบข้อความ. [TextFrameFormat::setAutofitType](https://reference.aspose.com/slides/th/php-java/aspose.slides/textframeformat/#setAutofitType) ถูกเรียกด้วย [TextAutofitType::None](https://reference.aspose.com/slides/th/php-java/aspose.slides/textautofittype/) เพื่อให้ขนาดข้อความและขนาดกรอบคงที่:

```php
use aspose\slides\FillType;
use aspose\slides\FontData;
use aspose\slides\NullableBool;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\TextAlignment;
use aspose\slides\TextAutofitType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 160, 300);
    $shape->getFillFormat()->setFillType(FillType::NoFill);

    $textFrame = $shape->getTextFrame();
    $textFrame->getTextFrameFormat()->setWrapText(NullableBool::True);
    $textFrame->getTextFrameFormat()->setAutofitType(TextAutofitType::None);
    $textFrame->getTextFrameFormat()->setMarginLeft(0);
    $textFrame->getTextFrameFormat()->setMarginRight(0);

    $paragraph = $textFrame->getParagraphs()->get_Item(0);
    $paragraph->setText("中文排版测试，PowerPoint 中文演示。");

    $format = $paragraph->getParagraphFormat();
    $format->setAlignment(TextAlignment::Left);
    $format->getDefaultPortionFormat()->setFontHeight(24);
    $latinFont = new FontData("Arial");
    $format->getDefaultPortionFormat()->setLatinFont($latinFont);
    $eastAsianFont = new FontData("SimSun");
    $format->getDefaultPortionFormat()->setEastAsianFont($eastAsianFont);
    $format->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $blackColor = java("java.awt.Color")->BLACK;
    $format->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor($blackColor);
    $format->setLatinLineBreak(NullableBool::False);
    $format->setEastAsianLineBreak(NullableBool::True);

    $presentation->save("line_breaking.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **ควบคุมการวางเครื่องหมายวรรคตอนลอย**

[ParagraphFormat::setHangingPunctuation](https://reference.aspose.com/slides/th/php-java/aspose.slides/paragraphformat/#setHangingPunctuation) อนุญาตให้เครื่องหมายวรรคตอนที่เหมาะสมยืดออกไปเกินขอบขวาของบรรทัดข้อความแทนที่จะอยู่ในบรรทัดถัดไป. มันใช้กับย่อหน้าเต็มและแตกต่างจากการเยื้องลอย.

ตัวอย่างต่อไปนี้เปิดใช้งานการวางเครื่องหมายวรรคตอนลอยในกรอบข้อความกว้าง 100 พอยต์และบันทึกเป็น "hanging_punctuation.pptx". ด้วย Arial ขนาด 24 พอยต์และไม่มีระยะขอบแนวนอนของกรอบข้อความ, จุดจุดสุดท้ายจะคงอยู่หลังคำ "sentence" และยืดออกเกินขอบขวาของข้อความ. ตั้งค่าคุณสมบัตินี้เป็น [NullableBool::False](https://reference.aspose.com/slides/th/php-java/aspose.slides/nullablebool/) เพื่อเปรียบเทียบ: เมื่อตั้งเป็นค่าเหล่านี้ จุดสุดท้ายจะอยู่ในบรรทัดแยก. การตัดบรรทัดเปิดใช้งานและ autofit ปิดเพื่อให้ความกว้างที่มีคงที่.

```php
use aspose\slides\FillType;
use aspose\slides\FontData;
use aspose\slides\NullableBool;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\TextAlignment;
use aspose\slides\TextAutofitType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 100, 200);
    $shape->getFillFormat()->setFillType(FillType::NoFill);

    $textFrame = $shape->getTextFrame();
    $textFrame->getTextFrameFormat()->setWrapText(NullableBool::True);
    $textFrame->getTextFrameFormat()->setAutofitType(TextAutofitType::None);
    $textFrame->getTextFrameFormat()->setMarginLeft(0);
    $textFrame->getTextFrameFormat()->setMarginRight(0);

    $paragraph = $textFrame->getParagraphs()->get_Item(0);
    $paragraph->setText("Simple text, next sentence.");

    $format = $paragraph->getParagraphFormat();
    $format->setAlignment(TextAlignment::Left);
    $format->getDefaultPortionFormat()->setFontHeight(24);
    $latinFont = new FontData("Arial");
    $format->getDefaultPortionFormat()->setLatinFont($latinFont);
    $format->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $blackColor = java("java.awt.Color")->BLACK;
    $format->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor($blackColor);
    $format->setHangingPunctuation(NullableBool::True);

    $presentation->save("hanging_punctuation.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

ไม่ใช่ทุกเครื่องหมายวรรคตอนจะสามารถลอยได้. ผลลัพธ์ที่มองเห็นขึ้นอยู่กับการมีอยู่ของฟอนต์และการจัดวาง: การเปลี่ยนฟอนต์, ความกว้างที่มี, ระยะขอบ, หรือการตั้งค่า autofit อาจทำให้ความแตกต่างที่มองเห็นหายไป.

## **ตั้งค่าชนิด Autofit สำหรับกรอบข้อความ**

[TextFrameFormat::setAutofitType](https://reference.aspose.com/slides/th/php-java/aspose.slides/textframeformat/#setAutofitType) กำหนดว่าข้อความทำพฤติกรรมอย่างไรเมื่อเกินขอบเขตของคอนเทนเนอร์. ใช้มันเพื่อควบคุมว่าข้อความจะหด, แสดงส่วนเกิน, หรือปรับขนาดรูปทรงโดยอัตโนมัติ. ตัวอย่างต่อไปนี้กำหนดให้รูปทรงปรับขนาดตามข้อความและบันทึกผลลัพธ์เป็น "autofit_type.pptx".

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\TextAutofitType;

$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $autoShape = $slide->getShapes()->get_Item(0);
    $autoShape->getTextFrame()->getTextFrameFormat()->setAutofitType(TextAutofitType::Shape);

    $presentation->save("autofit_type.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

เพื่อให้นับจำนวนบรรทัดหลังจากการตัดบรรทัดอัตโนมัติและดูว่าขนาดข้อความหรือความกว้างของรูปทรงเปลี่ยนผลลัพธ์อย่างไร, ดูที่ [Count Rendered Lines](/slides/th/php-java/manage-paragraph/). จำนวนบรรทัดเพียงอย่างเดียวไม่บ่งบอกว่าข้อความเกินคอนเทนเนอร์หรือไม่.

## **ตั้งค่าตำแหน่งยึดของกรอบข้อความ**

[TextFrameFormat::setAnchoringType](https://reference.aspose.com/slides/th/php-java/aspose.slides/textframeformat/#setAnchoringType) กำหนดว่าข้อความวางอยู่ในแนวตั้งภายในรูปทรงอย่างไร, ตัวอย่างเช่น ที่ด้านบน, กลาง, หรือด้านล่าง. ตัวอย่างต่อไปนี้ยึดข้อความไว้ที่ด้านล่างของรูปทรงแรกและบันทึกผลลัพธ์เป็น "text_anchor.pptx".

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\TextAnchorType;

$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $autoShape = $slide->getShapes()->get_Item(0);
    $autoShape->getTextFrame()->getTextFrameFormat()->setAnchoringType(TextAnchorType::Bottom);

    $presentation->save("text_anchor.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **ตั้งค่าการเว้นแท็บของข้อความ**

ใช้ [ParagraphFormat::setDefaultTabSize](https://reference.aspose.com/slides/th/php-java/aspose.slides/paragraphformat/#setDefaultTabSize) และ [ParagraphFormat::getTabs](https://reference.aspose.com/slides/th/php-java/aspose.slides/paragraphformat/#getTabs) เพื่อกำหนดตำแหน่งหยุดแท็บในย่อหน้า. ตัวอย่างต่อไปนี้กำหนดช่วงแท็บเริ่มต้นเป็น 100 พอยต์และเพิ่มตำแหน่งหยุดแท็บชิดซ้ายที่ 30 พอยต์. การตั้งค่าเหล่านี้ส่งผลต่อข้อความที่มีอักขระแท็บ.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\TabAlignment;

$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $autoShape = $slide->getShapes()->get_Item(0);

    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);
    $paragraph->getParagraphFormat()->setDefaultTabSize(100);
    $paragraph->getParagraphFormat()->getTabs()->add(30, TabAlignment::Left);

    $presentation->save("paragraph_tabs.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

ผลลัพธ์:

![แท็บของย่อหน้า](paragraph_tabs.png)

## **ตั้งค่าภาษา Proofing**

Aspose.Slides ให้ [BasePortionFormat::setLanguageId](https://reference.aspose.com/slides/th/php-java/aspose.slides/baseportionformat/#setLanguageId), ซึ่งทำให้คุณตั้งค่าภาษา proofing สำหรับส่วนข้อความ. ภาษา proofing กำหนดภาษาที่ใช้ตรวจสอบการสะกดและไวยากรณ์ใน PowerPoint.

ตัวอย่างต่อไปนี้ต้องการไฟล์ "presentation.pptx" ที่มีกล่องข้อความเป็นรูปทรงแรกบนสไลด์แรกและอย่างน้อยหนึ่งย่อหน้า. มันแทนที่เนื้อหาของย่อหน้าแรกด้วย "1。", ตั้งฟอนต์เป็น SimSun, แล้วกำหนดภาษา proofing เป็นภาษาจีนกลางแบบเรียบง่าย (`zh-CN`). บันทึกผลลัพธ์เป็น "proofing_language.pptx":

```php
use aspose\slides\FontData;
use aspose\slides\Portion;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("presentation.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $autoShape = $slide->getShapes()->get_Item(0);

    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);
    $paragraph->getPortions()->clear();

    $font = new FontData("SimSun");

    $textPortion = new Portion();
    $textPortion->getPortionFormat()->setComplexScriptFont($font);
    $textPortion->getPortionFormat()->setEastAsianFont($font);
    $textPortion->getPortionFormat()->setLatinFont($font);

    // ตั้งค่า Id ของภาษา proofing.
    $textPortion->getPortionFormat()->setLanguageId("zh-CN");

    $textPortion->setText("1。");
    $paragraph->getPortions()->add($textPortion);

    $presentation->save("proofing_language.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **ตั้งค่าภาษาเริ่มต้น**

ใช้ [LoadOptions::setDefaultTextLanguage](https://reference.aspose.com/slides/th/php-java/aspose.slides/loadoptions/#setDefaultTextLanguage) เพื่อกำหนดภาษาเริ่มต้นสำหรับข้อความที่สร้างขณะโหลดหรือสร้างงานนำเสนอ. ตัวอย่างต่อไปนี้สร้างงานนำเสนอโดยตั้งภาษาข้อความเริ่มต้นเป็นภาษาอังกฤษสหรัฐ, เพิ่มกล่องข้อความ, และพิมพ์ `en-US` สำหรับส่วนข้อความแรกของมัน.

```php
use aspose\slides\LoadOptions;
use aspose\slides\Presentation;
use aspose\slides\ShapeType;

$loadOptions = new LoadOptions();
$loadOptions->setDefaultTextLanguage("en-US");

$presentation = new Presentation($loadOptions);
try {
    $slide = $presentation->getSlides()->get_Item(0);

    // เพิ่มรูปสี่เหลี่ยมผืนผ้าใหม่พร้อมข้อความ.
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 20, 150, 50);
    $shape->getTextFrame()->setText("Sample text");

    // ตรวจสอบภาษาของส่วนแรก.
    $portion = $shape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
    echo $portion->getPortionFormat()->getLanguageId();
} finally {
    $presentation->dispose();
}
```

## **ตั้งค่าสไตล์ข้อความเริ่มต้น**

เพื่อใช้การจัดรูปแบบข้อความเริ่มต้นระดับงานนำเสนอ, ใช้ [Presentation::getDefaultTextStyle](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentation/#getDefaultTextStyle).

ตัวอย่างต่อไปนี้ตั้งฟอนต์หนาขนาด 14 พอยต์เป็นค่าเริ่มต้นสำหรับย่อหน้าในระดับบนสุดของงานนำเสนอใหม่และบันทึกเป็น "default_text_style.pptx". ข้อความสามารถสืบทอดค่าเริ่มต้นเหล่านี้ได้เว้นแต่การจัดรูปแบบที่เฉพาะเจาะจงจะเขียนทับ.

```php
use aspose\slides\NullableBool;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    // รับรูปแบบย่อหน้าระดับบนสุด.
    $paragraphFormat = $presentation->getDefaultTextStyle()->getLevel(0);

    if (!java_is_null($paragraphFormat)) {
        $paragraphFormat->getDefaultPortionFormat()->setFontHeight(14);
        $paragraphFormat->getDefaultPortionFormat()->setFontBold(NullableBool::True);
    }

    $presentation->save("default_text_style.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **ดึงข้อความที่มีเอฟเฟกต์ All-Caps**

ใน PowerPoint, การใช้เอฟเฟกต์ฟอนต์ **All Caps** ทำให้ข้อความปรากฏเป็นตัวพิมพ์ใหญ่บนสไลด์แม้ว่าจะพิมพ์เป็นตัวพิมพ์เล็กต้นฉบับ. เมื่อคุณดึงส่วนข้อความเช่นนี้ด้วย Aspose.Slides, ไลบรารีจะคืนข้อความตามที่พิมพ์ไว้. เพื่อให้ตรงกับข้อความที่แสดง, ตรวจสอบ [TextCapType](https://reference.aspose.com/slides/th/php-java/aspose.slides/textcaptype/) และแปลงสตริงที่คืนค่าเป็นตัวพิมพ์ใหญ่เมื่อค่าเป็น `All`.

ตัวอย่างนี้ต้องการไฟล์ "sample2.pptx" ที่มีกล่องข้อความเป็นรูปทรงแรกบนสไลด์แรก. ส่วนแรกของย่อหน้าแรกมีข้อความ "Hello, Aspose!" พร้อมเอฟเฟกต์ All Caps, ตามที่แสดงด้านล่าง.

![เอฟเฟกต์ All Caps](all_caps_effect.png)

ตัวอย่างโค้ดด้านล่างแสดงวิธีดึงข้อความที่มีเอฟเฟกต์ **All Caps**:

```php
use aspose\slides\Presentation;
use aspose\slides\TextCapType;

$presentation = new Presentation("sample2.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    
    $autoShape = $slide->getShapes()->get_Item(0);
    $textPortion = $autoShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);

    $originalText = $textPortion->getText();
    echo "Original text: ", $originalText, "\n";

    $textFormat = $textPortion->getPortionFormat()->getEffective();
    if (java_values($textFormat->getTextCapType()) === TextCapType::All) {
        $text = strtoupper($originalText);
        echo "All-Caps effect: ", $text, "\n";
    }
} finally {
    $presentation->dispose();
}
```

Output:

```text
Original text: Hello, Aspose!
All-Caps effect: HELLO, ASPOSE!
```

## **คำถามที่พบบ่อย**

**ฉันจะแก้ไขข้อความในตารางบนสไลด์ได้อย่างไร?**

เพื่อแก้ไขข้อความในตารางบนสไลด์, ใช้ [Table](https://reference.aspose.com/slides/th/php-java/aspose.slides/table/). วนลูปผ่านเซลล์และอัปเดตแต่ละเซลล์โดยใช้ [Cell::getTextFrame](https://reference.aspose.com/slides/th/php-java/aspose.slides/cell/#getTextFrame) และจัดรูปแบบย่อหน้าผ่าน [Paragraph::getParagraphFormat](https://reference.aspose.com/slides/th/php-java/aspose.slides/paragraph/#getParagraphFormat).

**ฉันจะใช้สีไล่ระดับบนข้อความในสไลด์ PowerPoint อย่างไร?**

เพื่อใช้สีไล่ระดับบนข้อความ, ใช้ [BasePortionFormat::getFillFormat](https://reference.aspose.com/slides/th/php-java/aspose.slides/baseportionformat/#getFillFormat). ตั้งค่า [FillFormat::setFillType](https://reference.aspose.com/slides/th/php-java/aspose.slides/fillformat/#setFillType) เป็น [FillType::Gradient](https://reference.aspose.com/slides/th/php-java/aspose.slides/filltype/) และกำหนดจุดไล่ระดับ, ทิศทาง, และความโปร่งใส.