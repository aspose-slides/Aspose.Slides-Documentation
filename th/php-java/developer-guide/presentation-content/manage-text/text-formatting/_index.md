---
title: จัดรูปแบบข้อความการนำเสนอใน PHP
linktitle: การจัดรูปแบบข้อความ
type: docs
weight: 50
url: /th/php-java/text-formatting/
keywords:
- จัดตำแหน่งย่อหน้า
- สไตล์ข้อความ
- พื้นหลังข้อความ
- ความโปร่งใสของข้อความ
- ระยะห่างระหว่างอักขระ
- คุณสมบัติของแบบอักษร
- ตระกูลแบบอักษร
- การหมุนข้อความ
- มุมการหมุน
- กรอบข้อความ
- ระยะห่างบรรทัด
- คุณสมบัติ Autofit
- จุดยึดกรอบข้อความ
- การแท็บของข้อความ
- ภาษาตั้งต้น
- PowerPoint
- OpenDocument
- การนำเสนอ
- PHP
- Aspose.Slides
description: "จัดรูปแบบและสไตล์ข้อความในงานนำเสนอ PowerPoint และ OpenDocument ด้วย Aspose.Slides สำหรับ PHP ผ่าน Java ปรับแบบอักษร สี การจัดตำแหน่งและอื่น ๆ"
---
## **ภาพรวม**

บทความนี้แสดงวิธีการจัดรูปแบบข้อความในงานนำเสนอ PowerPoint และ OpenDocument โดยใช้ Aspose.Slides สำหรับ PHP ผ่าน Java ซึ่งครอบคลุมสีพื้นหลัง ความโปร่งใส ระยะห่างระหว่างอักขระ คุณสมบัติของแบบอักษร การหมุน ระยะห่างระหว่างย่อหน้า พฤติกรรม Autofit การยึดตำแหน่งข้อความ จุดหยุดแท็บ และการตั้งค่าภาษา

ในตัวอย่างด้านล่าง เราจะใช้ไฟล์ชื่อ "sample.pptx" ซึ่งมีกล่องข้อความเพียงหนึ่งกล่องบนสไลด์แรกที่มีข้อความต่อไปนี้:

![ข้อความตัวอย่าง](sample_text.png)

เพื่อค้นหาและเน้นข้อความตามตัวอักษรหรือผลลัพธ์ของ regular-expression ดูที่ [ค้นหาและแทนที่ข้อความ](/slides/th/php-java/search-and-replace-text/).

## **ตั้งค่าสีพื้นหลังของข้อความ**

ใช้ [ParagraphFormat::getDefaultPortionFormat](https://reference.aspose.com/slides/th/php-java/aspose.slides/paragraphformat/#getDefaultPortionFormat) เพื่อกำหนดสีไฮไลท์เริ่มต้นสำหรับย่อหน้า หรือใช้ [BasePortionFormat::getHighlightColor](https://reference.aspose.com/slides/th/php-java/aspose.slides/baseportionformat/#getHighlightColor) สำหรับส่วนข้อความแต่ละส่วน

ตัวอย่างโค้ดต่อไปนี้แสดงวิธีตั้งค่าสีพื้นหลังสำหรับ **ย่อหน้าเต็ม**:

```php
$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $autoShape = $slide->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);
    $highlightColor = java("java.awt.Color")->LIGHT_GRAY;

    // ตั้งค่าสีไฮไลท์สำหรับย่อหน้าเต็ม
    $paragraph->getParagraphFormat()->getDefaultPortionFormat()->getHighlightColor()->setColor($highlightColor);

    $presentation->save("gray_paragraph.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

ผลลัพธ์:

![ย่อหน้าสีเทา](gray_paragraph.png)

ตัวอย่างโค้ดด้านล่างแสดงวิธีตั้งค่าสีพื้นหลังสำหรับ **ส่วนข้อความที่มีฟอนต์หนา**:

```php
$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $autoShape = $slide->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);
    $highlightColor = java("java.awt.Color")->LIGHT_GRAY;

    $portionCount = java_values($paragraph->getPortions()->getCount());
    for ($portionIndex = 0; $portionIndex < $portionCount; $portionIndex++) {
        $portion = $paragraph->getPortions()->get_Item($portionIndex);
        if (java_values($portion->getPortionFormat()->getEffective()->getFontBold()) === NullableBool::True) {
            // ตั้งค่าสีไฮไลท์สำหรับส่วนข้อความ.
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

## **จัดตำแหน่งย่อข้อความ**

ใช้ [ParagraphFormat::setAlignment](https://reference.aspose.com/slides/th/php-java/aspose.slides/paragraphformat/#setAlignment) เพื่อกำหนดการจัดตำแหน่งย่อหน้าในกรอบข้อความ ค่าอาจเป็นการจัดกึ่งกลาง จัดซ้าย จัดขวา จัดแนวเต็มบรรทัด ฯลฯ

ตัวอย่างโค้ดต่อไปนี้แสดงวิธีจัดตำแหน่งย่อหน้าให้ **กึ่งกลาง**:

```php
$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $autoShape = $slide->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);

    // ตั้งค่าการจัดตำแหน่งของย่อหน้าเป็นกึ่งกลาง.
    $paragraph->getParagraphFormat()->setAlignment(TextAlignment::Center);

    $presentation->save("aligned_paragraph.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

ผลลัพธ์:

![ย่อหน้าที่จัดตำแหน่ง](aligned_paragraph.png)

## **ตั้งค่าความโปร่งใสของข้อความ**

ความโปร่งใสของข้อความถูกควบคุมโดยส่วนประกอบอัลฟ่าของสีที่กำหนดให้กับ [BasePortionFormat::getFillFormat](https://reference.aspose.com/slides/th/php-java/aspose.slides/baseportionformat/#getFillFormat) ในตัวอย่างด้านล่าง `alpha = 50` คือค่าอัลฟ่าในรูปแบบ ARGB บนสเกล 0–255 ไม่ใช่เปอร์เซ็นต์ความโปร่งใส

ตัวอย่างโค้ดด้านล่างแสดงวิธีใช้ความโปร่งใสกับ **ย่อหน้าเต็ม**:

```php
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

ตัวอย่างโค้ดต่อไปนี้แสดงวิธีใช้ความโปร่งใสกับ **ส่วนข้อความที่มีฟอนต์หนา**:

```php
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
        if (java_values($portion->getPortionFormat()->getEffective()->getFontBold()) === NullableBool::True) {
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

## **ตั้งค่าระยะห่างระหว่างอักขระของข้อความ**

ใช้ [BasePortionFormat::setSpacing](https://reference.aspose.com/slides/th/php-java/aspose.slides/baseportionformat/#setSpacing) เพื่อเพิ่มหรือหดระยะห่างระหว่างอักขระในกล่องข้อความ

โค้ด PHP ต่อไปนี้แสดงวิธีเพิ่มระยะห่างระหว่างอักขระใน **ย่อหน้าเต็ม**:

```php
$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $autoShape = $slide->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);

    // หมายเหตุ: ใช้ค่าลบเพื่อบีบอัดระยะห่างระหว่างอักขระ.
    $paragraph->getParagraphFormat()->getDefaultPortionFormat()->setSpacing(3); // ขยายระยะห่างระหว่างอักขระ.

    $presentation->save("character_spacing_in_paragraph.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

ผลลัพธ์:

![ระยะห่างระหว่างอักขระในย่อหน้า](character_spacing_in_paragraph.png)

ตัวอย่างโค้ดด้านล่างแสดงวิธีเพิ่มระยะห่างระหว่างอักขระใน **ส่วนข้อความที่มีฟอนต์หนา**:

```php
$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $autoShape = $slide->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);

    $portionCount = java_values($paragraph->getPortions()->getCount());
    for ($portionIndex = 0; $portionIndex < $portionCount; $portionIndex++) {
        $portion = $paragraph->getPortions()->get_Item($portionIndex);
        if (java_values($portion->getPortionFormat()->getEffective()->getFontBold()) === NullableBool::True) {
            // หมายเหตุ: ใช้ค่าลบเพื่อบีบอัดระยะห่างระหว่างอักขระ.
            $portion->getPortionFormat()->setSpacing(3); // ขยายระยะห่างระหว่างอักขระ.
        }
    }

    $presentation->save("character_spacing_in_text_portions.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

ผลลัพธ์:

![ระยะห่างระหว่างอักขระในส่วนข้อความ](character_spacing_in_text_portions.png)

### **ปิดการ Kerning สำหรับแบบอักษรเฉพาะ**

ในบางกรณี ข้อความที่เรนเดอร์โดย Aspose.Slides อาจดูแคบเกินกว่าข้อความเดียวกันที่แสดงใน PowerPoint สิ่งนี้อาจเกิดขึ้นเนื่องจาก PowerPoint อาจละเว้นข้อมูล kerning ของแบบอักษรบางแบบ แม้ว่าแบบอักษรจะมีข้อมูล kerning ที่ถูกต้องและเปิดใช้งาน kerning ในการตั้งค่าของ PowerPoint

เพื่อทำให้ผลลัพธ์ที่เรนเดอร์ใกล้เคียงกับ PowerPoint มากขึ้นในกรณีเช่นนี้ คุณสามารถปิดการทำ kerning สำหรับส่วนข้อความที่ใช้แบบอักษรที่ได้รับผลกระทบ ตั้งค่า [BasePortionFormat::setKerningMinimalSize](https://reference.aspose.com/slides/th/php-java/aspose.slides/baseportionformat/#setKerningMinimalSize) ให้เป็นค่าที่ใหญ่กว่าขนาดแบบอักษรจริงอย่างมีนัยสำคัญ:

```php
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

การตั้งค่านี้จะป้องกันไม่ให้ kerning ถูกนำไปใช้กับส่วนข้อความที่ตรงกันและสามารถช่วยทำให้การเรนเดอร์ของ Aspose.Slides สอดคล้องกับผลลัพธ์ภาพของ PowerPoint สำหรับแบบอักษรที่ได้รับผลกระทบจากพฤติกรรมเฉพาะของ PowerPoint นี้

## **จัดการคุณสมบัติแบบอักษรของข้อความ**

คุณสมบัติของแบบอักษรสามารถตั้งค่าได้ระดับย่อหน้าผ่าน [ParagraphFormat::getDefaultPortionFormat](https://reference.aspose.com/slides/th/php-java/aspose.slides/paragraphformat/#getDefaultPortionFormat) หรือบนส่วนย่อยแต่ละส่วนผ่าน [PortionFormat](https://reference.aspose.com/slides/th/php-java/aspose.slides/portionformat/)

โค้ดต่อไปนี้ตั้งค่าแบบอักษรและสไตล์ข้อความสำหรับย่อหน้าเต็ม: มันกำหนดขนาดแบบอักษร, ตัวหนา, ตัวเอียง, ขีดเส้นใต้แบบจุด, และแบบอักษร Times New Roman ให้กับทุกส่วนในย่อหน้า

```php
$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $autoShape = $slide->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);
    $defaultPortionFormat = $paragraph->getParagraphFormat()->getDefaultPortionFormat();
    $font = new FontData("Times New Roman");

    // ตั้งค่าคุณสมบัติแบบอักษรสำหรับย่อหน้า.
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

![คุณสมบัติแบบอักษรของย่อหน้า](font_properties_for_paragraph.png)

ตัวอย่างโค้ดด้านล่างประยุกต์คุณสมบัติเช่นเดียวกันกับ **ส่วนข้อความที่มีฟอนต์หนา**:

```php
$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $autoShape = $slide->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);
    $font = new FontData("Times New Roman");

    $portionCount = java_values($paragraph->getPortions()->getCount());
    for ($portionIndex = 0; $portionIndex < $portionCount; $portionIndex++) {
        $portion = $paragraph->getPortions()->get_Item($portionIndex);
        if (java_values($portion->getPortionFormat()->getEffective()->getFontBold()) === NullableBool::True) {
            // ตั้งค่าคุณสมบัติแบบอักษรสำหรับส่วนข้อความ.
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

![คุณสมบัติแบบอักษรของส่วนข้อความ](font_properties_for_text_portions.png)

## **ตั้งค่าการหมุนข้อความ**

ใช้ [TextFrameFormat::setTextVerticalType](https://reference.aspose.com/slides/th/php-java/aspose.slides/textframeformat/#setTextVerticalType) เพื่อกำหนดการจัดตำแหน่งข้อความล่วงหน้าภายในรูปร่าง

ตัวอย่างโค้ดต่อไปนี้กำหนดการจัดตำแหน่งข้อความในรูปร่างเป็น `Vertical270` ซึ่งทำให้ข้อความ **90 องศาตรงข้ามเข็มนาฬิกา**:

```php
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

![การหมุนข้อความ](text_rotation.png)

## **ตั้งค่าการหมุนแบบกำหนดเองสำหรับ Text Frame**

ใช้ [TextFrameFormat::setRotationAngle](https://reference.aspose.com/slides/th/php-java/aspose.slides/textframeformat/#setRotationAngle) เพื่อตั้งค่ามุมการหมุนแบบกำหนดเองสำหรับ [TextFrame](https://reference.aspose.com/slides/th/php-java/aspose.slides/textframe/)

ตัวอย่างโค้ดด้านล่างหมุน Text Frame ไป 3 องศาตามเข็มนาฬิกาภายในรูปร่าง:

```php
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

## **ตั้งค่าระยะห่างบรรทัดของย่อหน้า**

Aspose.Slides มี [ParagraphFormat::setSpaceAfter](https://reference.aspose.com/slides/th/php-java/aspose.slides/paragraphformat/#setSpaceAfter), [ParagraphFormat::setSpaceBefore](https://reference.aspose.com/slides/th/php-java/aspose.slides/paragraphformat/#setSpaceBefore) และ [ParagraphFormat::setSpaceWithin](https://reference.aspose.com/slides/th/php-java/aspose.slides/paragraphformat/#setSpaceWithin) เพื่อควบคุมระยะห่างของย่อหน้า คุณสมบัติเหล่านี้ใช้ดังต่อไปนี้:

* ใช้ค่าเป็นบวกเพื่อระบุระยะห่างบรรทัดเป็นเปอร์เซ็นต์ของความสูงบรรทัด
* ใช้ค่าเป็นลบเพื่อระบุระยะห่างบรรทัดเป็นหน่วยพ้อยท์

ตัวอย่างโค้ดต่อไปนี้แสดงวิธีระบุระยะห่างบรรทัดภายในย่อหน้า:

```php
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

![ระยะห่างบรรทัดภายในย่อหน้า](line_spacing.png)

## **ตั้งค่าชนิด Autofit สำหรับ Text Frame**

[TextFrameFormat::setAutofitType](https://reference.aspose.com/slides/th/php-java/aspose.slides/textframeformat/#setAutofitType) กำหนดว่าข้อความจะทำอย่างไรเมื่อเกินขอบเขตของคอนเทนเนอร์ ใช้มันเพื่อควบคุมว่าข้อความจะหดลง, ล้นออก, หรือปรับขนาดรูปร่างโดยอัตโนมัติ

```php
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

## **ตั้งค่าตำแหน่งยึดของ Text Frame**

[TextFrameFormat::setAnchoringType](https://reference.aspose.com/slides/th/php-java/aspose.slides/textframeformat/#setAnchoringType) กำหนดว่าข้อความจะถูกจัดตำแหน่งแนวตั้งภายในรูปร่างอย่างไร เช่น อยู่บนสุด กลาง หรือด้านล่าง

```php
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

## **ตั้งค่าการแท็บของข้อความ**

ใช้ [ParagraphFormat::setDefaultTabSize](https://reference.aspose.com/slides/th/php-java/aspose.slides/paragraphformat/#setDefaultTabSize) และ [ParagraphFormat::getTabs](https://reference.aspose.com/slides/th/php-java/aspose.slides/paragraphformat/#getTabs) เพื่อกำหนดจุดหยุดแท็บในย่อหน้า

```php
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

## **ตั้งค่าภาษาตรวจสอบการพิมพ์**

Aspose.Slides มี [BasePortionFormat::setLanguageId](https://reference.aspose.com/slides/th/php-java/aspose.slides/baseportionformat/#setLanguageId) ซึ่งช่วยให้คุณตั้งค่าภาษา proofing สำหรับส่วนข้อความ ภาษ proofing จะกำหนดภาษาที่ใช้ในการตรวจสอบการสะกดและไวยากรณ์ใน PowerPoint

ตัวอย่างโค้ดต่อไปนี้แสดงวิธีตั้งค่าภาษา proofing สำหรับส่วนข้อความ:

```php
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

    // ตั้งค่า Id ของภาษาตรวจสอบ.
    $textPortion->getPortionFormat()->setLanguageId("zh-CN");

    $textPortion->setText("1。");
    $paragraph->getPortions()->add($textPortion);

    $presentation->save("proofing_language.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **ตั้งค่าภาษาเริ่มต้น**

ใช้ [LoadOptions::setDefaultTextLanguage](https://reference.aspose.com/slides/th/php-java/aspose.slides/loadoptions/#setDefaultTextLanguage) เพื่อกำหนดภาษาตั้งต้นสำหรับข้อความที่สร้างในระหว่างการโหลดหรือสร้างงานนำเสนอ

```php
$loadOptions = new LoadOptions();
$loadOptions->setDefaultTextLanguage("en-US");

$presentation = new Presentation($loadOptions);
try {
    $slide = $presentation->getSlides()->get_Item(0);

    // เพิ่มรูปร่างสี่เหลี่ยมใหม่พร้อมข้อความ.
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

เพื่อประยุกต์การจัดรูปแบบข้อความเริ่มต้นในระดับงานนำเสนอ ใช้ [Presentation::getDefaultTextStyle](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentation/#getDefaultTextStyle)

ตัวอย่างโค้ดต่อไปนี้แสดงวิธีตั้งค่าแบบอักษรหนาเริ่มต้นขนาด 14 pt สำหรับข้อความทั้งหมดในทุกสไลด์ของงานนำเสนอใหม่

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

## **ดึงข้อความพร้อมเอฟเฟกต์ All-Caps**

ใน PowerPoint การใช้เอฟเฟกต์แบบ **All Caps** ทำให้ข้อความแสดงเป็นตัวพิมพ์ใหญ่บนสไลด์แม้ว่าต้นฉบับจะพิมพ์ด้วยตัวพิมพ์เล็ก เมื่อคุณดึงส่วนข้อความนั้นด้วย Aspose.Slides ไลบรารีจะคืนค่าข้อความตามที่ป้อนไว้ เพื่อให้ตรงกับข้อความที่แสดง ให้ตรวจสอบ [TextCapType](https://reference.aspose.com/slides/th/php-java/aspose.slides/textcaptype/) และเปลี่ยนสตริงที่คืนค่าเป็นตัวพิมพ์ใหญ่เมื่อค่ามีค่า `All`

สมมติว่าเรามีกล่องข้อความต่อไปนี้บนสไลด์แรกของไฟล์ sample2.pptx

![เอฟเฟกต์ All Caps](all_caps_effect.png)

ตัวอย่างโค้ดด้านล่างแสดงวิธีดึงข้อความพร้อมเอฟเฟกต์ **All Caps** ที่ใช้แล้ว:

```php
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

ผลลัพธ์:

```text
Original text: Hello, Aspose!
All-Caps effect: HELLO, ASPOSE!
```

## **FAQ**

**จะแก้ไขข้อความในตารางบนสไลด์อย่างไร?**

เพื่อแก้ไขข้อความในตารางบนสไลด์ ให้ใช้ [Table](https://reference.aspose.com/slides/th/php-java/aspose.slides/table/). วนรอบผ่านเซลล์และอัปเดตแต่ละเซลล์โดยใช้ [Cell::getTextFrame](https://reference.aspose.com/slides/th/php-java/aspose.slides/cell/#getTextFrame) และกำหนดรูปแบบย่อหน้าผ่าน [Paragraph::getParagraphFormat](https://reference.aspose.com/slides/th/php-java/aspose.slides/paragraph/#getParagraphFormat).

**จะใช้สีไล่ระดับกับข้อความในสไลด์ PowerPoint อย่างไร?**

เพื่อใช้สีไล่ระดับกับข้อความ ให้ใช้ [BasePortionFormat::getFillFormat](https://reference.aspose.com/slides/th/php-java/aspose.slides/baseportionformat/#getFillFormat). ตั้งค่า [FillFormat::setFillType](https://reference.aspose.com/slides/th/php-java/aspose.slides/fillformat/#setFillType) เป็น [FillType::Gradient](https://reference.aspose.com/slides/th/php-java/aspose.slides/filltype/) แล้วกำหนดจุดหยุดไล่ระดับ, ทิศทาง, และความโปร่งใส.