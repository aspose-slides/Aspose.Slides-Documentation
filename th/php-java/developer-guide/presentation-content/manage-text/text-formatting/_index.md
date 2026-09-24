---
title: จัดรูปแบบข้อความพรีเซนเทชันใน PHP
linktitle: การจัดรูปแบบข้อความ
type: docs
weight: 50
url: /th/php-java/text-formatting/
keywords:
- จัดย่อหน้า
- สไตล์ข้อความ
- พื้นหลังข้อความ
- ความโปร่งใสของข้อความ
- ระยะห่างอักขระ
- คุณสมบัติเชิงตัวอักษร
- ตระกูลฟอนต์
- การหมุนข้อความ
- มุมการหมุน
- กรอบข้อความ
- ระยะห่างบรรทัด
- คุณสมบัติ Autofit
- จุดยึดกรอบข้อความ
- การจัด Tab ของข้อความ
- ภาษาตั้งต้น
- PowerPoint
- OpenDocument
- การนำเสนอ
- PHP
- Aspose.Slides
description: "จัดรูปแบบและสไตล์ข้อความในงานนำเสนอ PowerPoint และ OpenDocument โดยใช้ Aspose.Slides สำหรับ PHP ผ่าน Java ปรับแต่งฟอนต์, สี, การจัดแนว และอื่นๆ"
---
## **ภาพรวม**

บทความนี้แสดงวิธีจัดรูปแบบข้อความในงานนำเสนอ PowerPoint และ OpenDocument โดยใช้ Aspose.Slides for PHP via Java ครอบคลุมสีพื้นหลัง, ความโปร่งแสง, ระยะห่างระหว่างอักขระ, คุณสมบัติตัวอักษร, การหมุน, ระยะห่างระหว่างย่อหน้า, พฤติกรรม Autofit, การยึดข้อความ, ตำแหน่ง Tab, และการตั้งค่าภาษา

ในตัวอย่างต่อไปนี้ เราจะใช้ไฟล์ชื่อ “sample.pptx” ซึ่งมีกล่องข้อความเดียวบนสไลด์แรกที่มีข้อความดังต่อไปนี้:

![Sample text](sample_text.png)

เพื่อค้นหาและเน้นข้อความจริงหรือตรงตามนิพจน์ทั่วไป ดูที่ [ค้นหาและแทนที่ข้อความ](/slides/th/php-java/search-and-replace-text/)

## **ตั้งค่าสีพื้นหลังของข้อความ**

ใช้ [ParagraphFormat::getDefaultPortionFormat](https://reference.aspose.com/slides/th/php-java/aspose.slides/paragraphformat/#getDefaultPortionFormat) เพื่อตั้งค่าสีไฮไลต์ค่าเริ่มต้นสำหรับย่อหน้า หรือใช้ [BasePortionFormat::getHighlightColor](https://reference.aspose.com/slides/th/php-java/aspose.slides/baseportionformat/#getHighlightColor) สำหรับส่วนข้อความแต่ละส่วน

โค้ดตัวอย่างต่อไปนี้แสดงวิธีตั้งค่าสีพื้นหลังสำหรับ **ย่อหน้าเต็ม**:

```php
$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $autoShape = $slide->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);
    $highlightColor = java("java.awt.Color")->LIGHT_GRAY;

    // ตั้งค่าสีไฮไลต์สำหรับย่อหน้าเต็ม.
    $paragraph->getParagraphFormat()->getDefaultPortionFormat()->getHighlightColor()->setColor($highlightColor);

    $presentation->save("gray_paragraph.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

ผลลัพธ์:

![The gray paragraph](gray_paragraph.png)

โค้ดตัวอย่างด้านล่างแสดงวิธีตั้งค่าสีพื้นหลังสำหรับ **ส่วนข้อความที่ใช้ฟอนต์หนา**:

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

![The gray text portions](gray_text_portions.png)

## **จัดแนวกย่อหน้าข้อความ**

ใช้ [ParagraphFormat::setAlignment](https://reference.aspose.com/slides/th/php-java/aspose.slides/paragraphformat/#setAlignment) เพื่อตั้งค่าการจัดแนวย่อหน้าภายในกรอบข้อความ ค่าอาจเป็นศูนย์กลาง, ชิดซ้าย, ชิดขวา, จัดเต็ม, เป็นต้น

โค้ดตัวอย่างต่อไปนี้แสดงวิธีจัดแนวย่อหน้าให้อยู่ **กึ่งกลาง**:

```php
$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $autoShape = $slide->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);

    // ตั้งค่าการจัดแนวย่อหน้าให้อยู่กึ่งกลาง.
    $paragraph->getParagraphFormat()->setAlignment(TextAlignment::Center);

    $presentation->save("aligned_paragraph.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

ผลลัพธ์:

![The aligned paragraph](aligned_paragraph.png)

## **ตั้งค่าความโปร่งแสงของข้อความ**

ความโปร่งแสงของข้อความถูกควบคุมผ่านส่วนประกอบอัลฟ่า ของสีที่กำหนดให้กับ [BasePortionFormat::getFillFormat](https://reference.aspose.com/slides/th/php-java/aspose.slides/baseportionformat/#getFillFormat) ตัวอย่างด้านล่าง `alpha = 50` คือค่าช่องอัลฟ่า ARGB ที่มีช่วง 0–255 ไม่ใช่เปอร์เซ็นต์ความโปร่งใส

โค้ดตัวอย่างต่อไปนี้แสดงวิธีนำความโปร่งแสงไปใช้กับ **ย่อหน้าเต็ม**:

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

![The transparent paragraph](transparent_paragraph.png)

โค้ดตัวอย่างต่อไปนี้แสดงวิธีนำความโปร่งแสงไปใช้กับ **ส่วนข้อความที่ใช้ฟอนต์หนา**:

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

![The transparent text portions](transparent_text_portions.png)

## **ตั้งค่าระยะห่างระหว่างอักขระของข้อความ**

ใช้ [BasePortionFormat::setSpacing](https://reference.aspose.com/slides/th/php-java/aspose.slides/baseportionformat/#setSpacing) เพื่อขยายหรือย่อระยะห่างระหว่างอักขระในกล่องข้อความ

โค้ด PHP ด้านล่างแสดงวิธีขยายระยะห่างอักขระใน **ย่อหน้าเต็ม**:

```php
$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $autoShape = $slide->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);

    // หมายเหตุ: ใช้ค่าติดลบเพื่อบีบอัดระยะห่างอักขระ.
    $paragraph->getParagraphFormat()->getDefaultPortionFormat()->setSpacing(3); // ขยายระยะห่างอักขระ.

    $presentation->save("character_spacing_in_paragraph.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

ผลลัพธ์:

![The character spacing in the paragraph](character_spacing_in_paragraph.png)

โค้ดตัวอย่างต่อไปนี้แสดงวิธีขยายระยะห่างอักขระใน **ส่วนข้อความที่ใช้ฟอนต์หนา**:

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
            // หมายเหตุ: ใช้ค่าติดลบเพื่อบีบอัดระยะห่างอักขระ.
            $portion->getPortionFormat()->setSpacing(3); // ขยายระยะห่างอักขระ.
        }
    }

    $presentation->save("character_spacing_in_text_portions.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

ผลลัพธ์:

![The character spacing in the text portions](character_spacing_in_text_portions.png)

### **ปิดการใช้งาน Kerning สำหรับฟอนต์เฉพาะ**

ในบางกรณี ข้อความที่เรนเดอร์โดย Aspose.Slides อาจดูแน่นกว่าข้อความเดียวกันใน PowerPoint นี่อาจเกิดจาก PowerPoint เพิกเฉยต่อข้อมูล kerning ของฟอนต์บางตัว แม้ว่าฟอนต์จะมีข้อมูล kerning ที่ถูกต้องและการตั้งค่า Kerning ใน PowerPoint จะเปิดอยู่ก็ตาม

เพื่อให้ผลลัพธ์ที่เรนเดอร์ใกล้เคียงกับ PowerPoint มากขึ้น คุณสามารถปิดการใช้งาน kerning สำหรับส่วนข้อความที่ใช้ฟอนต์ที่ได้รับผลกระทบได้ ตั้งค่า [BasePortionFormat::setKerningMinimalSize](https://reference.aspose.com/slides/th/php-java/aspose.slides/baseportionformat/#setKerningMinimalSize) ให้มีค่ามากกว่าขนาดฟอนต์จริงอย่างชัดเจน:

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

การตั้งค่านี้จะป้องกันไม่ให้ kerning ถูกนำไปใช้กับส่วนข้อความที่ตรงกันและช่วยให้การเรนเดอร์ของ Aspose.Slides สอดคล้องกับการแสดงผลของ PowerPoint สำหรับฟอนต์ที่ได้รับผลกระทบจากพฤติกรรมเฉพาะของ PowerPoint นี้

## **จัดการคุณสมบัติตัวอักษรของข้อความ**

คุณสมบัติตัวอักษรสามารถตั้งค่าได้ระดับย่อหน้าโดยผ่าน [ParagraphFormat::getDefaultPortionFormat](https://reference.aspose.com/slides/th/php-java/aspose.slides/paragraphformat/#getDefaultPortionFormat) หรือบนส่วนเฉพาะโดยผ่าน [PortionFormat](https://reference.aspose.com/slides/th/php-java/aspose.slides/portionformat/)

โค้ดต่อไปนี้ตั้งค่าแบบอักษรและสไตล์ข้อความสำหรับย่อหน้าเต็ม: กำหนดขนาดฟอนต์, ตัวหนา, ตัวเอียง, เส้นใต้แบบจุด, และฟอนต์ Times New Roman ให้กับทุกส่วนในย่อหน้า

```php
$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $autoShape = $slide->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);
    $defaultPortionFormat = $paragraph->getParagraphFormat()->getDefaultPortionFormat();
    $font = new FontData("Times New Roman");

    // ตั้งค่าคุณสมบัติตัวอักษรสำหรับย่อหน้า.
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

![The font properties for the paragraph](font_properties_for_paragraph.png)

โค้ดตัวอย่างด้านล่างนำคุณสมบัติเดียวกันไปใช้กับ **ส่วนข้อความที่ใช้ฟอนต์หนา**:

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
            // ตั้งค่าคุณสมบัติตัวอักษรสำหรับส่วนข้อความ.
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

![The font properties for text portions](font_properties_for_text_portions.png)

## **ตั้งค่าการหมุนของข้อความ**

ใช้ [TextFrameFormat::setTextVerticalType](https://reference.aspose.com/slides/th/php-java/aspose.slides/textframeformat/#setTextVerticalType) เพื่อตั้งค่าทิศทางข้อความที่กำหนดล่วงหน้าในรูปทรง

โค้ดต่อไปนี้ตั้งค่าทิศทางข้อความในรูปทรงเป็น `Vertical270` ซึ่งหมุนข้อความ **90 องศาตรงข้ามเข็มนาฬิกา**:

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

![The text rotation](text_rotation.png)

## **ตั้งค่าการหมุนแบบกำหนดเองสำหรับกรอบข้อความ**

ใช้ [TextFrameFormat::setRotationAngle](https://reference.aspose.com/slides/th/php-java/aspose.slides/textframeformat/#setRotationAngle) เพื่อตั้งค่ามุมการหมุนแบบกำหนดเองสำหรับ [TextFrame](https://reference.aspose.com/slides/th/php-java/aspose.slides/textframe/)

โค้ดตัวอย่างด้านล่างหมุนกรอบข้อความ 3 องศาตามเข็มนาฬิกาภายในรูปทรง:

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

![The custom text rotation](custom_text_rotation.png)

## **ตั้งค่าระยะห่างบรรทัดของย่อหน้า**

Aspose.Slides มี [ParagraphFormat::setSpaceAfter](https://reference.aspose.com/slides/th/php-java/aspose.slides/paragraphformat/#setSpaceAfter), [ParagraphFormat::setSpaceBefore](https://reference.aspose.com/slides/th/php-java/aspose.slides/paragraphformat/#setSpaceBefore) และ [ParagraphFormat::setSpaceWithin](https://reference.aspose.com/slides/th/php-java/aspose.slides/paragraphformat/#setSpaceWithin) เพื่อควบคุมระยะห่างระหว่างย่อหน้า คุณสมบัติเหล่านี้ใช้ดังนี้

* ใช้ค่าบวกเพื่อระบุระยะห่างบรรทัดเป็นเปอร์เซ็นต์ของความสูงบรรทัด
* ใช้ค่าลบเพื่อระบุระยะห่างบรรทัดเป็นจุด

โค้ดต่อไปนี้แสดงวิธีระบุระยะห่างบรรทัดภายในย่อหน้า:

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

![The line spacing within the paragraph](line_spacing.png)

## **ตั้งค่า Autofit Type สำหรับกรอบข้อความ**

[TextFrameFormat::setAutofitType](https://reference.aspose.com/slides/th/php-java/aspose.slides/textframeformat/#setAutofitType) กำหนดว่าข้อความจะทำอย่างไรเมื่อเกินขอบเขตของคอนเทนเนอร์ ใช้เพื่อควบคุมว่าข้อความจะหด, แพร่กระจาย หรือปรับขนาดรูปทรงโดยอัตโนมัติ

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

เพื่อดูจำนวนบรรทัดหลังจากการตัดบรรทัดอัตโนมัติและสังเกตว่าความกว้างของข้อความหรือรูปทรงเปลี่ยนแปลงอย่างไร ให้ดูที่ [Count Rendered Lines](/slides/th/php-java/manage-paragraph/) จำนวนบรรทัดเพียงอย่างเดียวไม่ได้บ่งบอกว่าข้อความล้นคอนเทนเนอร์หรือไม่

## **ตั้งค่าตำแหน่งยึดของกรอบข้อความ**

[TextFrameFormat::setAnchoringType](https://reference.aspose.com/slides/th/php-java/aspose.slides/textframeformat/#setAnchoringType) กำหนดว่าข้อความจะจัดตำแหน่งแนวตั้งอย่างไรภายในรูปทรง เช่น ที่ด้านบน, กลาง หรือด้านล่าง

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

## **ตั้งค่าการ Tabulation ของข้อความ**

ใช้ [ParagraphFormat::setDefaultTabSize](https://reference.aspose.com/slides/th/php-java/aspose.slides/paragraphformat/#setDefaultTabSize) และ [ParagraphFormat::getTabs](https://reference.aspose.com/slides/th/php-java/aspose.slides/paragraphformat/#getTabs) เพื่อตั้งค่าตำแหน่ง Tab ในย่อหน้า

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

![The paragraph tabs](paragraph_tabs.png)

## **ตั้งค่าภาษา Proofing**

Aspose.Slides มี [BasePortionFormat::setLanguageId](https://reference.aspose.com/slides/th/php-java/aspose.slides/baseportionformat/#setLanguageId) ซึ่งให้คุณตั้งค่าภาษา proofing สำหรับส่วนข้อความ ภาษานี้กำหนดภาษาที่ใช้ตรวจการสะกดและไวยากรณ์ใน PowerPoint

โค้ดต่อไปนี้แสดงวิธีตั้งค่าภาษา proofing สำหรับส่วนข้อความ:

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

ใช้ [LoadOptions::setDefaultTextLanguage](https://reference.aspose.com/slides/th/php-java/aspose.slides/loadoptions/#setDefaultTextLanguage) เพื่อกำหนดภาษาตั้งต้นสำหรับข้อความที่สร้างขณะโหลดหรือสร้างงานนำเสนอใหม่

```php
$loadOptions = new LoadOptions();
$loadOptions->setDefaultTextLanguage("en-US");

$presentation = new Presentation($loadOptions);
try {
    $slide = $presentation->getSlides()->get_Item(0);

    // เพิ่มรูปสี่เหลี่ยมผืนผ้าใหม่พร้อมข้อความ.
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 20, 150, 50);
    $shape->getTextFrame()->setText("Sample text");

    // ตรวจสอบภาษาของส่วนข้อความแรก.
    $portion = $shape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
    echo $portion->getPortionFormat()->getLanguageId();
} finally {
    $presentation->dispose();
}
```

## **ตั้งค่าสไตล์ข้อความเริ่มต้น**

เพื่อใช้รูปแบบข้อความเริ่มต้นระดับงานนำเสนอ ใช้ [Presentation::getDefaultTextStyle](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentation/#getDefaultTextStyle)

โค้ดต่อไปนี้แสดงวิธีตั้งค่าฟอนต์หนาขนาด 14 pt เป็นค่าเริ่มต้นสำหรับข้อความทั้งหมดในสไลด์ของงานนำเสนอใหม่

```php
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

## **สกัดข้อความพร้อมเอฟเฟกต์ All-Caps**

ใน PowerPoint การใช้เอฟเฟกต์ฟอนต์ **All Caps** ทำให้ข้อความแสดงเป็นพิมพ์ใหญ่ทั้งหมดแม้พิมพ์ด้วยตัวพิมพ์เล็กเมื่อต้องดึงข้อความส่วนนี้ออกด้วย Aspose.Slides ไลบรารีจะคืนค่าข้อความตามที่พิมพ์ไว้ เพื่อให้ตรงกับที่แสดงบนสไลด์ ให้ตรวจสอบ [TextCapType](https://reference.aspose.com/slides/th/php-java/aspose.slides/textcaptype/) และแปลงสตริงที่คืนค่าเป็นพิมพ์ใหญ่เมื่อค่าเป็น `All`

สมมติว่าเรามีกล่องข้อความดังต่อไปนี้บนสไลด์แรกของไฟล์ sample2.pptx

![The All Caps effect](all_caps_effect.png)

โค้ดตัวอย่างด้านล่างแสดงวิธีสกัดข้อความพร้อมเอฟเฟกต์ **All Caps** ที่ได้เปิดใช้:

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

**ทำอย่างไรจึงจะแก้ไขข้อความในตารางบนสไลด์?**

เพื่อแก้ไขข้อความในตารางบนสไลด์ ให้ใช้ [Table](https://reference.aspose.com/slides/th/php-java/aspose.slides/table/) วนลูปผ่านเซลล์และอัปเดตแต่ละเซลล์ผ่าน [Cell::getTextFrame](https://reference.aspose.com/slides/th/php-java/aspose.slides/cell/#getTextFrame) และจัดรูปแบบย่อหน้าผ่าน [Paragraph::getParagraphFormat](https://reference.aspose.com/slides/th/php-java/aspose.slides/paragraph/#getParagraphFormat)

**ทำอย่างไรจึงจะใส่สีไล่โทนลงไปในข้อความบนสไลด์ PowerPoint?**

เพื่อใส่สีไล่โทนลงในข้อความ ให้ใช้ [BasePortionFormat::getFillFormat](https://reference.aspose.com/slides/th/php-java/aspose.slides/baseportionformat/#getFillFormat) ตั้งค่า [FillFormat::setFillType](https://reference.aspose.com/slides/th/php-java/aspose.slides/fillformat/#setFillType) เป็น [FillType::Gradient](https://reference.aspose.com/slides/th/php-java/aspose.slides/filltype/) และกำหนดจุดไล่สี, ทิศทาง, และความโปร่งแสง