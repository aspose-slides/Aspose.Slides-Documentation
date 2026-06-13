---
title: จัดรูปแบบข้อความงานนำเสนอใน PHP
linktitle: การจัดรูปแบบข้อความ
type: docs
weight: 50
url: /th/php-java/text-formatting/
keywords:
- ไฮไลท์ข้อความ
- นิพจน์ปกติ
- จัดแนวย่อหน้า
- สไตล์ข้อความ
- พื้นหลังข้อความ
- ความโปร่งใสของข้อความ
- ระยะห่างอักขระ
- คุณสมบัติฟอนท์
- ตระกูลฟอนท์
- การหมุนข้อความ
- มุมการหมุน
- เฟรมข้อความ
- ระยะห่างบรรทัด
- คุณสมบัติ autofit
- จุดยึดเฟรมข้อความ
- การตั้งค่าแท็บข้อความ
- ภาษาดีฟอลต์
- PowerPoint
- OpenDocument
- งานนำเสนอ
- PHP
- Aspose.Slides
description: "จัดรูปแบบและสไตล์ข้อความในงานนำเสนอ PowerPoint และ OpenDocument โดยใช้ Aspose.Slides สำหรับ PHP ผ่าน Java ปรับแต่งฟอนท์, สี, การจัดแนว และอื่นๆ อีกมากมาย."
---
## **ภาพรวม**

บทความนี้แสดงวิธีการจัดรูปแบบข้อความในงานนำเสนอ PowerPoint และ OpenDocument โดยใช้ Aspose.Slides for PHP ผ่าน Java โดยครอบคลุมการไฮไลท์, สีพื้นหลัง, ความโปร่งใส, ระยะห่างระหว่างอักขระ, คุณสมบัติของฟอนต์, การหมุน, ระยะห่างระหว่างย่อหน้า, พฤติกรรม autofit, การยึดข้อความ, จุดหยุดแท็บ, และการตั้งค่าภาษา

ในตัวอย่างด้านล่าง เราจะใช้ไฟล์ชื่อ “sample.pptx” ซึ่งมีกล่องข้อความเดียวบนสไลด์แรกพร้อมข้อความต่อไปนี้:

![ข้อความตัวอย่าง](sample_text.png)

## **ไฮไลท์ข้อความ**

ใช้เมธอด [TextFrame](https://reference.aspose.com/slides/th/php-java/aspose.slides/textframe/)`::highlightText` เมื่อคุณต้องการไฮไลท์ข้อความที่ตรงกับตัวอย่างเฉพาะภายใน TextFrame เมธอดนี้จะใส่สีไฮไลท์ให้กับส่วนของข้อความที่ตรงกัน และสามารถใช้ร่วมกับ [TextHighlightingOptions](https://reference.aspose.com/slides/th/php-java/aspose.slides/texthighlightingoptions/) เพื่อควบคุมวิธีการค้นหา ตัวอย่างเช่น เพื่อให้ตรงกับเฉพาะคำเต็มเท่านั้น

โค้ดตัวอย่างด้านล่างไฮไลท์ทุกการปรากฏของอักขระ **"try"** แล้วจึงไฮไลท์เฉพาะคำเต็ม **"to"** เท่านั้น

```php
$presentation = new Presentation("sample.pptx");
try {
    // ดึงรูปทรงแรกจากสไลด์แรก.
    $shape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $lightBlue = new Java("java.awt.Color", 173, 216, 230);
    $violet = new Java("java.awt.Color", 238, 130, 238);

    // ไฮไลท์คำ "try" ในรูปทรง.
    $shape->getTextFrame()->highlightText("try", $lightBlue);

    $searchOptions = new TextHighlightingOptions();
    $searchOptions->setWholeWordsOnly(true);

    // ไฮไลท์คำ "to" ในรูปทรง.
    $shape->getTextFrame()->highlightText("to", $violet, $searchOptions);

    $presentation->save("highlighted_text.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

ผลลัพธ์:

![ข้อความที่ไฮไลท์แล้ว](highlighted_text.png)

## **ไฮไลท์ข้อความโดยใช้ Regular Expressions**

เมธอด [TextFrame](https://reference.aspose.com/slides/th/php-java/aspose.slides/textframe/)`::highlightRegex` จะไฮไลท์ข้อความที่ตรงกับผลลัพธ์ของ regular expression

โค้ดตัวอย่างด้านล่างไฮไลท์ทุกคำที่มี **เจ็ดอักขระหรือมากกว่า** :

```php
$presentation = new Presentation("sample.pptx");
try {
    $shape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);

    // ไฮไลท์คำทั้งหมดที่มีอักขระเจ็ดตัวหรือมากกว่า.
    $shape->getTextFrame()->highlightRegex("\\b[^\\s]{7,}\\b", java("java.awt.Color")->YELLOW, null);

    $presentation->save("highlighted_text_using_regex.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

ผลลัพธ์:

![ข้อความที่ไฮไลท์โดยใช้ regular expression](highlighted_text_using_regex.png)

## **กำหนดสีพื้นหลังของข้อความ**

ใช้รูปแบบส่วนย่อยเริ่มต้นของ [ParagraphFormat](https://reference.aspose.com/slides/th/php-java/aspose.slides/paragraphformat/) เพื่อกำหนดสีไฮไลท์เริ่มต้นสำหรับย่อหน้า หรือใช้ [PortionFormat](https://reference.aspose.com/slides/th/php-java/aspose.slides/portionformat/) สำหรับส่วนข้อความแต่ละส่วน

โค้ดตัวอย่างต่อไปนี้แสดงวิธีตั้งค่าสีพื้นหลังสำหรับ **ย่อหน้าทั้งหมด** :

```php
$presentation = new Presentation("sample.pptx");
try {
    $autoShape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);

    // ตั้งค่าสีไฮไลท์สำหรับย่อหน้าทั้งหมด.
    $paragraph->getParagraphFormat()->getDefaultPortionFormat()->getHighlightColor()->setColor(java("java.awt.Color")->LIGHT_GRAY);

    $presentation->save("gray_paragraph.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

ผลลัพธ์:

![ย่อหน้าสีเทา](gray_paragraph.png)

โค้ดตัวอย่างด้านล่างแสดงวิธีตั้งค่าสีพื้นหลังสำหรับ **ส่วนข้อความที่ใช้ฟอนต์ตัวหนา** :

```php
$presentation = new Presentation("sample.pptx");
try {
    $autoShape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);

    $portionCount = java_values($paragraph->getPortions()->getCount());
    for ($portionIndex = 0; $portionIndex < $portionCount; $portionIndex++) {
        $portion = $paragraph->getPortions()->get_Item($portionIndex);
        if (java_values($portion->getPortionFormat()->getEffective()->getFontBold()) === NullableBool::True) {
            // ตั้งค่าสีไฮไลท์สำหรับส่วนข้อความ.
            $portion->getPortionFormat()->getHighlightColor()->setColor(java("java.awt.Color")->LIGHT_GRAY);
        }
    }

    $presentation->save("gray_text_portions.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

ผลลัพธ์:

![ส่วนข้อความสีเทา](gray_text_portions.png)

## **จัดแนวย่อหน้าข้อความ**

ใช้เมธอด [ParagraphFormat](https://reference.aspose.com/slides/th/php-java/aspose.slides/paragraphformat/)`::setAlignment` เพื่อกำหนดการจัดแนวย่อหน้าใน TextFrame ค่าที่ตั้งอาจเป็นการจัดกึ่งกลาง, ชิดซ้าย, ชิดขวา, จัดบรรทัดเต็ม ฯลฯ

โค้ดตัวอย่างต่อไปนี้แสดงวิธีจัดแนวย่อหน้าไปที่ **กึ่งกลาง** :

```php
$presentation = new Presentation("sample.pptx");
try {
    $autoShape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);

    // ตั้งค่าการจัดแนวของย่อหน้าให้เป็นกึ่งกลาง.
    $paragraph->getParagraphFormat()->setAlignment(TextAlignment::Center);

    $presentation->save("aligned_paragraph.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

ผลลัพธ์:

![ย่อหน้าที่จัดแนวแล้ว](aligned_paragraph.png)

## **กำหนดความโปร่งใสสำหรับข้อความ**

ความโปร่งใสของข้อความควบคุมผ่านค่าส่วนประกอบแอลฟ่า (alpha) ของสีที่กำหนดให้กับรูปแบบการเติมของ [PortionFormat](https://reference.aspose.com/slides/th/php-java/aspose.slides/portionformat/) ในตัวอย่างต่อไปนี้ `alpha = 50` คือค่าช่องแอลฟ่า ARGB บนสเกล 0‑255 ไม่ใช่เปอร์เซ็นต์ความโปร่งใส

โค้ดตัวอย่างด้านล่างแสดงวิธีใช้ความโปร่งใสกับ **ย่อหน้าทั้งหมด** :

```php
$alpha = 50;

$presentation = new Presentation("sample.pptx");
try {
    $autoShape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);
    $fillFormat = $paragraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat();

    // ตั้งค่าสีเติมของข้อความเป็นสีโปร่งใส.
    $fillFormat->setFillType(FillType::Solid);
    $fillFormat->getSolidFillColor()->setColor(new Java("java.awt.Color", 0, 0, 0, $alpha));

    $presentation->save("transparent_paragraph.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

ผลลัพธ์:

![ย่อหน้าที่โปร่งใส](transparent_paragraph.png)

โค้ดตัวอย่างต่อไปนี้แสดงวิธีใช้ความโปร่งใสกับ **ส่วนข้อความที่ใช้ฟอนต์ตัวหนา** :

```php
$alpha = 50;

$presentation = new Presentation("sample.pptx");
try {
    $autoShape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);

    $portionCount = java_values($paragraph->getPortions()->getCount());
    for ($portionIndex = 0; $portionIndex < $portionCount; $portionIndex++) {
        $portion = $paragraph->getPortions()->get_Item($portionIndex);
        if (java_values($portion->getPortionFormat()->getEffective()->getFontBold()) === NullableBool::True) {
            // ตั้งค่าความโปร่งใสของส่วนข้อความ.
            $fillFormat = $portion->getPortionFormat()->getFillFormat();
            $fillFormat->setFillType(FillType::Solid);
            $fillFormat->getSolidFillColor()->setColor(new Java("java.awt.Color", 0, 0, 0, $alpha));
        }
    }

    $presentation->save("transparent_text_portions.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

ผลลัพธ์:

![ส่วนข้อความที่โปร่งใส](transparent_text_portions.png)

## **กำหนดระยะห่างระหว่างอักขระสำหรับข้อความ**

ใช้เมธอด [BasePortionFormat](https://reference.aspose.com/slides/th/php-java/aspose.slides/baseportionformat/)`::setSpacing` เพื่อขยายหรือบีบอัดระยะห่างระหว่างอักขระในกล่องข้อความ

โค้ด PHP ต่อไปนี้แสดงวิธีขยายระยะห่างอักขระใน **ย่อหน้าทั้งหมด** :

```php
$presentation = new Presentation("sample.pptx");
try {
    $autoShape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);

    // หมายเหตุ: ใช้ค่าลบเพื่อบีบอัดระยะห่างอักขระ.
    $paragraph->getParagraphFormat()->getDefaultPortionFormat()->setSpacing(3); // ขยายระยะห่างอักขระ.

    $presentation->save("character_spacing_in_paragraph.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

ผลลัพธ์:

![ระยะห่างอักขระในย่อหน้า](character_spacing_in_paragraph.png)

โค้ดตัวอย่างด้านล่างแสดงวิธีขยายระยะห่างอักขระใน **ส่วนข้อความที่ใช้ฟอนต์ตัวหนา** :

```php
$presentation = new Presentation("sample.pptx");
try {
    $autoShape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);

    $portionCount = java_values($paragraph->getPortions()->getCount());
    for ($portionIndex = 0; $portionIndex < $portionCount; $portionIndex++) {
        $portion = $paragraph->getPortions()->get_Item($portionIndex);
        if (java_values($portion->getPortionFormat()->getEffective()->getFontBold()) === NullableBool::True) {
            // หมายเหตุ: ใช้ค่าลบเพื่อบีบอัดระยะห่างอักขระ.
            $portion->getPortionFormat()->setSpacing(3); // ขยายระยะห่างอักขระ.
        }
    }

    $presentation->save("character_spacing_in_text_portions.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

ผลลัพธ์:

![ระยะห่างอักขระในส่วนข้อความ](character_spacing_in_text_portions.png)

### **ปิดการทำ Kerning สำหรับฟอนต์เฉพาะ**

ในบางกรณี ข้อความที่เรนเดอร์โดย Aspose.Slides อาจดูคับแคบกว่าข้อความเดียวกันที่แสดงใน PowerPoint เนื่องจาก PowerPoint อาจละเลยข้อมูล kerning ของฟอนต์บางตัว แม้ว่าฟอนต์จะมีข้อมูล kerning ที่ถูกต้องและเปิดใช้งานในการตั้งค่าของ PowerPoint

เพื่อทำให้ผลลัพธ์ที่เรนเดรใกล้เคียงกับ PowerPoint มากขึ้น คุณสามารถปิดการทำ kerning สำหรับส่วนข้อความที่ใช้ฟอนต์ที่ได้รับผลกระทบได้ ตั้งค่าเมธอด [BasePortionFormat](https://reference.aspose.com/slides/th/php-java/aspose.slides/baseportionformat/)`::setKerningMinimalSize` ให้เป็นค่าที่ใหญ่กว่าขนาดฟอนต์จริงอย่างมีนัยสำคัญ :

```php
$presentation = new Presentation("presentation.pptx");
try {
    $autoShape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $targetFont = "Roboto";

    $paragraphCount = java_values($autoShape->getTextFrame()->getParagraphs()->getCount());
    for ($paragraphIndex = 0; $paragraphIndex < $paragraphCount; $paragraphIndex++) {
        $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item($paragraphIndex);
        $portionCount = java_values($paragraph->getPortions()->getCount());
        for ($portionIndex = 0; $portionIndex < $portionCount; $portionIndex++) {
            $portion = $paragraph->getPortions()->get_Item($portionIndex);
            $portionFormat = $portion->getPortionFormat();
            $latinFont = $portionFormat->getLatinFont();
            $eastAsianFont = $portionFormat->getEastAsianFont();
            $complexScriptFont = $portionFormat->getComplexScriptFont();

            if ((!java_is_null($latinFont) && $latinFont->getFontName() == $targetFont) ||
                (!java_is_null($eastAsianFont) && $eastAsianFont->getFontName() == $targetFont) ||
                (!java_is_null($complexScriptFont) && $complexScriptFont->getFontName() == $targetFont)) {
                $portionFormat->setKerningMinimalSize(100);
            }
        }
    }

    $presentation->save("output.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

การตั้งค่านี้จะป้องกันไม่ให้ kerning ถูกนำไปใช้กับส่วนข้อความที่ตรงกันและช่วยให้การแสดงผลของ Aspose.Slides สอดคล้องกับผลลัพธ์ภาพของ PowerPoint สำหรับฟอนต์ที่ได้รับผลกระทบจากพฤติกรรมของ PowerPoint นี้

## **จัดการคุณสมบัติฟอนต์ของข้อความ**

คุณสมบัติของฟอนต์สามารถกำหนดได้ที่ระดับย่อหน้าโดยใช้รูปแบบส่วนย่อยเริ่มต้นของ [ParagraphFormat](https://reference.aspose.com/slides/th/php-java/aspose.slides/paragraphformat/) หรือบนส่วนย่อยแต่ละส่วนโดยใช้ [PortionFormat](https://reference.aspose.com/slides/th/php-java/aspose.slides/portionformat/)

โค้ดต่อไปนี้ตั้งค่าฟอนต์และสไตล์ข้อความสำหรับ **ย่อหน้าทั้งหมด**: จะตั้งค่าขนาดฟอนต์, ตัวหนา, ตัวเอียง, ขีดเส้นใต้แบบจุด, และฟอนต์ Times New Roman ให้กับส่วนทั้งหมดในย่อหน้า

```php
$presentation = new Presentation("sample.pptx");
try {
    $autoShape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);
    $defaultPortionFormat = $paragraph->getParagraphFormat()->getDefaultPortionFormat();

    // ตั้งค่าคุณสมบัติฟอนต์สำหรับย่อหน้า.
    $defaultPortionFormat->setFontHeight(12);
    $defaultPortionFormat->setFontBold(NullableBool::True);
    $defaultPortionFormat->setFontItalic(NullableBool::True);
    $defaultPortionFormat->setFontUnderline(TextUnderlineType::Dotted);
    $defaultPortionFormat->setLatinFont(new FontData("Times New Roman"));

    $presentation->save("font_properties_for_paragraph.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

ผลลัพธ์:

![คุณสมบัติฟอนต์ของย่อหน้า](font_properties_for_paragraph.png)

โค้ดตัวอย่างด้านล่างใช้คุณสมบัติเดียวกันกับ **ส่วนข้อความที่ใช้ฟอนต์ตัวหนา** :

```php
$presentation = new Presentation("sample.pptx");
try {
    $autoShape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);

    $portionCount = java_values($paragraph->getPortions()->getCount());
    for ($portionIndex = 0; $portionIndex < $portionCount; $portionIndex++) {
        $portion = $paragraph->getPortions()->get_Item($portionIndex);
        if (java_values($portion->getPortionFormat()->getEffective()->getFontBold()) === NullableBool::True) {
            // ตั้งค่าคุณสมบัติฟอนต์สำหรับส่วนข้อความ.
            $portionFormat = $portion->getPortionFormat();
            $portionFormat->setFontHeight(13);
            $portionFormat->setFontItalic(NullableBool::True);
            $portionFormat->setFontUnderline(TextUnderlineType::Dotted);
            $portionFormat->setLatinFont(new FontData("Times New Roman"));
        }
    }

    $presentation->save("font_properties_for_text_portions.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

ผลลัพธ์:

![คุณสมบัติฟอนต์ของส่วนข้อความ](font_properties_for_text_portions.png)

## **กำหนดการหมุนข้อความ**

ใช้เมธอด [TextFrameFormat](https://reference.aspose.com/slides/th/php-java/aspose.slides/textframeformat/)`::setTextVerticalType` เพื่อกำหนดทิศทางข้อความที่กำหนดไว้ล่วงหน้าในรูปร่าง

โค้ดตัวอย่างต่อไปนี้ตั้งค่าการวางแนวข้อความในรูปร่างเป็น `Vertical270` ซึ่งจะหมุนข้อความ **90 องศาทวนเข็มนาฬิกา** :

```php
$presentation = new Presentation("sample.pptx");
try {
    $autoShape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);

    $autoShape->getTextFrame()->getTextFrameFormat()->setTextVerticalType(TextVerticalType::Vertical270);

    $presentation->save("text_rotation.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

ผลลัพธ์:

![การหมุนข้อความ](text_rotation.png)

## **กำหนดการหมุนแบบกำหนดเองสำหรับ Text Frame**

ใช้เมธอด [TextFrameFormat](https://reference.aspose.com/slides/th/php-java/aspose.slides/textframeformat/)`::setRotationAngle` เพื่อกำหนดมุมการหมุนแบบกำหนดเองสำหรับ [TextFrame](https://reference.aspose.com/slides/th/php-java/aspose.slides/textframe/)

โค้ดตัวอย่างด้านล่างหมุน Text Frame 3 องศาในทิศทางตามเข็มนาฬิกาภายในรูปร่าง :

```php
$presentation = new Presentation("sample.pptx");
try {
    $autoShape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);

    $autoShape->getTextFrame()->getTextFrameFormat()->setRotationAngle(3);

    $presentation->save("custom_text_rotation.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

ผลลัพธ์:

![การหมุนข้อความแบบกำหนดเอง](custom_text_rotation.png)

## **กำหนดระยะบรรทัดของย่อหน้า**

Aspose.Slides มีเมธอด [ParagraphFormat](https://reference.aspose.com/slides/th/php-java/aspose.slides/paragraphformat/)`::setSpaceAfter`, `ParagraphFormat::setSpaceBefore`, และ `ParagraphFormat::setSpaceWithin` เพื่อควบคุมระยะบรรทัดของย่อหน้า วิธีการใช้ดังนี้

* ใช้ค่าบวกเพื่อระบุระยะบรรทัดเป็นเปอร์เซ็นต์ของความสูงบรรทัด
* ใช้ค่าลบเพื่อระบุระยะบรรทัดเป็นพอยต์

โค้ดตัวอย่างต่อไปนี้แสดงวิธีระบุระยะบรรทัดภายในย่อหน้า :

```php
$presentation = new Presentation("sample.pptx");
try {
    $autoShape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);

    $paragraph->getParagraphFormat()->setSpaceWithin(200);

    $presentation->save("line_spacing.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

ผลลัพธ์:

![ระยะบรรทัดภายในย่อหน้า](line_spacing.png)

## **กำหนดประเภท Autofit สำหรับ Text Frame**

เมธอด [TextFrameFormat](https://reference.aspose.com/slides/th/php-java/aspose.slides/textframeformat/)`::setAutofitType` กำหนดวิธีการที่ข้อความทำงานเมื่อเกินขอบเขตของคอนเทนเนอร์ ใช้เพื่อควบคุมว่าข้อความจะหดตัว, ล้น, หรือปรับขนาดรูปร่างโดยอัตโนมัติ

```php
$presentation = new Presentation("sample.pptx");
try {
    $autoShape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);

    $autoShape->getTextFrame()->getTextFrameFormat()->setAutofitType(TextAutofitType::Shape);

    $presentation->save("autofit_type.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **กำหนดจุดยึดของ Text Frame**

เมธอด [TextFrameFormat](https://reference.aspose.com/slides/th/php-java/aspose.slides/textframeformat/)`::setAnchoringType` นิยามว่าข้อความจะถูกจัดตำแหน่งแนวตั้งภายในรูปร่างอย่างไร เช่น ที่ด้านบน, กลาง, หรือด้านล่าง

```php
$presentation = new Presentation("sample.pptx");
try {
    $autoShape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);

    $autoShape->getTextFrame()->getTextFrameFormat()->setAnchoringType(TextAnchorType::Bottom);

    $presentation->save("text_anchor.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **กำหนดการแท็บของข้อความ**

ใช้เมธอด [ParagraphFormat](https://reference.aspose.com/slides/th/php-java/aspose.slides/paragraphformat/)`::setDefaultTabSize` และคอลเลกชันแท็บของมันเพื่อกำหนดจุดหยุดแท็บในย่อหน้า

```php
$presentation = new Presentation("sample.pptx");
try {
    $autoShape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
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

## **กำหนดภาษาการตรวจสอบ**

Aspose.Slides มีเมธอด [BasePortionFormat](https://reference.aspose.com/slides/th/php-java/aspose.slides/baseportionformat/)`::setLanguageId` ซึ่งอนุญาตให้คุณกำหนดภาษาการตรวจสอบสำหรับส่วนข้อความ ภาษาการตรวจสอบกำหนดภาษาที่ใช้สำหรับการตรวจสอบการสะกดและไวยากรณ์ใน PowerPoint

โค้ดตัวอย่างต่อไปนี้แสดงวิธีตั้งค่าภาษาการตรวจสอบสำหรับส่วนข้อความ :

```php
$presentation = new Presentation("presentation.pptx");
try {
    $autoShape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);

    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);
    $paragraph->getPortions()->clear();

    $font = new FontData("SimSun");

    $textPortion = new Portion();
    $textPortion->getPortionFormat()->setComplexScriptFont($font);
    $textPortion->getPortionFormat()->setEastAsianFont($font);
    $textPortion->getPortionFormat()->setLatinFont($font);

    // ตั้งค่า ID ของภาษาการตรวจสอบ.
    $textPortion->getPortionFormat()->setLanguageId("zh-CN");

    $textPortion->setText("1.");
    $paragraph->getPortions()->add($textPortion);

    $presentation->save("proofing_language.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **กำหนดภาษาดีฟอลต์**

ใช้เมธอด [LoadOptions](https://reference.aspose.com/slides/th/php-java/aspose.slides/loadoptions/)`::setDefaultTextLanguage` เพื่อกำหนดภาษาดีฟอลต์สำหรับข้อความที่สร้างขณะโหลดหรือสร้างงานนำเสนอ

```php
$loadOptions = new LoadOptions();
$loadOptions->setDefaultTextLanguage("en-US");

$presentation = new Presentation($loadOptions);
try {
    $slide = $presentation->getSlides()->get_Item(0);

    // เพิ่มรูปร่างสี่เหลี่ยมผืนผ้าใหม่พร้อมข้อความ.
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 20, 150, 50);
    $shape->getTextFrame()->setText("Sample text");

    // ตรวจสอบภาษาของส่วนข้อความแรก.
    $portion = $shape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
    echo $portion->getPortionFormat()->getLanguageId();
} finally {
    $presentation->dispose();
}
```

## **กำหนดสไตล์ข้อความดีฟอลต์**

เพื่อใช้การจัดรูปแบบข้อความดีฟอลต์ในระดับงานนำเสนอ ให้ใช้สไตล์ข้อความดีฟอลต์ของ [Presentation](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentation/)

โค้ดตัวอย่างต่อไปนี้แสดงวิธีตั้งค่าฟอนต์ตัวหนาขนาด 14 pt เป็นค่าเริ่มต้นสำหรับข้อความทั้งหมดในสไลด์ของงานนำเสนอใหม่

```php
$presentation = new Presentation();
try {
    // ดึงรูปแบบย่อหน้าระดับบนสุด.
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

## **สกัดข้อความพร้อมเอฟเฟกต์ All‑Caps**

ใน PowerPoint การใช้เอฟเฟกต์ฟอนต์ **All Caps** ทำให้ข้อความปรากฏเป็นตัวพิมพ์ใหญ่ทั้งหมดบนสไลด์ แม้ว่าต้นฉบับจะพิมพ์เป็นตัวพิมพ์เล็กก็ตาม เมื่อคุณดึงส่วนข้อความแบบนี้ด้วย Aspose.Slides ไลบรารีจะคืนข้อความตามที่พิมพ์ไว้ เพื่อให้ตรงกับข้อความที่แสดง ให้ตรวจสอบ [TextCapType](https://reference.aspose.com/slides/th/php-java/aspose.slides/textcaptype/) และแปลงสตริงที่คืนค่าเป็นตัวพิมพ์ใหญ่เมื่อค่าเป็น `All`

สมมติว่ามีกล่องข้อความดังต่อไปนี้บนสไลด์แรกของไฟล์ sample2.pptx

![เอฟเฟกต์ All Caps](all_caps_effect.png)

โค้ดตัวอย่างด้านล่างแสดงวิธีสกัดข้อความที่มีเอฟเฟกต์ **All Caps** ใบใช้ :

```php
$presentation = new Presentation("sample2.pptx");
try {
    $autoShape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $textPortion = $autoShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);

    echo "Original text: ", $textPortion->getText(), "\n";

    $textFormat = $textPortion->getPortionFormat()->getEffective();
    if (java_values($textFormat->getTextCapType()) === TextCapType::All) {
        $text = strtoupper($textPortion->getText());
        echo "All-Caps effect: ", $text, "\n";
    }
} finally {
    $presentation->dispose();
}
```

ผลลัพธ์ :

```text
Original text: Hello, Aspose!
All-Caps effect: HELLO, ASPOSE!
```

## **คำถามที่พบบ่อย**

**จะแก้ไขข้อความในตารางบนสไลด์อย่างไร?**

เพื่อแก้ไขข้อความในตารางบนสไลด์ ให้ใช้ [Table](https://reference.aspose.com/slides/th/php-java/aspose.slides/table/). วนลูปผ่านเซลล์แต่ละเซลล์และอัปเดตข้อความของเซลล์ผ่าน TextFrame และการจัดรูปแบบย่อหน้าของ [Cell](https://reference.aspose.com/slides/th/php-java/aspose.slides/cell/) ผ่านรูปแบบย่อหน้าของ [Paragraph](https://reference.aspose.com/slides/th/php-java/aspose.slides/paragraph/)

**จะใส่สีไล่ระดับให้กับข้อความในสไลด์ PowerPoint อย่างไร?**

เพื่อใส่สีไล่ระดับให้กับข้อความ ให้ใช้รูปแบบการเติมของ [PortionFormat](https://reference.aspose.com/slides/th/php-java/aspose.slides/portionformat/). ตั้งค่า fill type ของ [FillFormat](https://reference.aspose.com/slides/th/php-java/aspose.slides/fillformat/) ให้เป็น [FillType](https://reference.aspose.com/slides/th/php-java/aspose.slides/filltype/) `Gradient` แล้วกำหนดจุดไล่ระดับ, ทิศทาง, และความโปร่งใส.