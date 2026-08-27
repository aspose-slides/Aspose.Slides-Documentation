---
title: ค้นหาและแทนที่ข้อความในงานนำเสนอ PowerPoint ด้วย PHP
linktitle: ค้นหาและแทนที่ข้อความ
type: docs
weight: 55
url: /th/php-java/search-and-replace-text/
keywords:
- ค้นหาข้อความ
- ไฮไลท์ข้อความ
- แทนที่ข้อความ
- นิพจน์ทั่วไป
- callback ผลลัพธ์
- กรอบข้อความ
- รายงานการตรวจสอบ
- PowerPoint
- OpenDocument
- งานนำเสนอ
- PHP
- Aspose.Slides
description: "ค้นหา ไฮไลท์ และแทนที่ข้อความในงานนำเสนอ PowerPoint พร้อมรวบรวมการจับคู่ทุกครั้งด้วย Aspose.Slides for PHP via Java."
---
## **ภาพรวม**

Aspose.Slides for PHP via Java สามารถค้นหา ไฮไลท์ และแทนที่ข้อความในกรอบข้อความเดี่ยวหรือทั่วทั้งงานนำเสนอได้ ทุกการทำงานยังสามารถแจ้งแอปพลิเคชันเกี่ยวกับการจับคู่แต่ละรายการผ่านการเรียกคืนผลลัพธ์ ซึ่งทำให้สามารถอัปเดตงานนำเสนอและสร้างบันทึกการตรวจสอบที่ประกอบด้วยข้อความที่ตรงกัน บริบท ของข้อความ ตำแหน่ง กรอบข้อความ และหมายเลขสไลด์พร้อมกัน

ความสามารถเหล่านี้มีประโยชน์สำหรับการตรวจทาน การทำลบข้อมูล การตรวจสอบคำศัพท์ การทำความสะอาดเทมเพลต และกระบวนการทำรายงานอัตโนมัติ

ในตัวอย่างแรกด้านล่าง เราใช้ไฟล์ชื่อ "sample.pptx" ซึ่งมีกล่องข้อความเดียวบนสไลด์แรกพร้อมข้อความต่อไปนี้:

![ข้อความตัวอย่าง](sample_text.png)

## **เลือกขอบเขตการค้นหา**

ใช้เมธอดบน [TextFrame](https://reference.aspose.com/slides/th/php-java/aspose.slides/textframe/) เพื่อจำกัดการทำงานให้กับกรอบข้อความหนึ่งเดียว ใช้เมธอดบน [Presentation](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentation/) เพื่อประมวลผลข้อความที่เกี่ยวข้องทั้งหมดในงานนำเสนอ

| การดำเนินการ | กรอบข้อความหนึ่ง | งานนำเสนอทั้งหมด |
|---|---|---|
| ไฮไลท์ข้อความตามตัวอักษร | [TextFrame::highlightText](https://reference.aspose.com/slides/th/php-java/aspose.slides/textframe/#highlightText) | [Presentation::highlightText](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentation/#highlightText) |
| ไฮไลท์การจับคู่ regex | [TextFrame::highlightRegex](https://reference.aspose.com/slides/th/php-java/aspose.slides/textframe/#highlightRegex) | [Presentation::highlightRegex](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentation/#highlightRegex) |
| แทนที่ข้อความตามตัวอักษร | [TextFrame::replaceText](https://reference.aspose.com/slides/th/php-java/aspose.slides/textframe/#replaceText) | [Presentation::replaceText](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentation/#replaceText) |
| แทนที่การจับคู่ regex | [TextFrame::replaceRegex](https://reference.aspose.com/slides/th/php-java/aspose.slides/textframe/#replaceRegex) | [Presentation::replaceRegex](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentation/#replaceRegex) |

## **กำหนดการจับคู่ข้อความ**

การดำเนินการข้อความตามตัวอักษร ให้ใช้ [TextSearchOptions](https://reference.aspose.com/slides/th/php-java/aspose.slides/textsearchoptions/) เพื่อควบคุมการจับคู่:

- [TextSearchOptions::setWholeWordsOnly](https://reference.aspose.com/slides/th/php-java/aspose.slides/textsearchoptions/#setWholeWordsOnly) จำกัดการจับคู่ให้เป็นคำเต็มเท่านั้น
- [TextSearchOptions::setCaseSensitive](https://reference.aspose.com/slides/th/php-java/aspose.slides/textsearchoptions/#setCaseSensitive) ควบคุมว่าต้องตรงตามตัวอักษรใหญ่/เล็กหรือไม่
- [TextSearchOptions::setIncludeNotes](https://reference.aspose.com/slides/th/php-java/aspose.slides/textsearchoptions/#setIncludeNotes) รวมบันทึกสไลด์ในการค้นหา การแทนที่ และการไฮไลท์ระดับงานนำเสนอ

การดำเนินการด้วย regular expression ใช้ Java `Pattern` ดังนั้นกฎการจับคู่ เช่น ความไวต่อกรณีอักษรและขอบเขตคำ จะถูกกำหนดโดยนิพจน์และแฟล็กของมัน

## **ระบุเจ้าของของกรอบข้อความ**

กระบวนการประมวลผลข้อความทั่วไปมักได้รับ [TextFrame](https://reference.aspose.com/slides/th/php-java/aspose.slides/textframe/) ขณะค้นหา แทนที่ ตรวจสอบ หรือส่งออกข้อความ ใช้ [TextFrame::getParentShape](https://reference.aspose.com/slides/th/php-java/aspose.slides/textframe/#getParentShape) และ [TextFrame::getParentCell](https://reference.aspose.com/slides/th/php-java/aspose.slides/textframe/#getParentCell) เพื่อกำหนดว่าวัตถุงานนำเสนอใดเป็นเจ้าของกรอบข้อความ

| เจ้าของกรอบข้อความ | `getParentShape` | `getParentCell` |
|---|---|---|
| AutoShape หรือรูปร่างที่บรรจุข้อความอื่น | รูปร่างที่เป็นเจ้าของ [Shape](https://reference.aspose.com/slides/th/php-java/aspose.slides/shape/) | `null` |
| เซลล์ตาราง | `null` | เซลล์ที่เป็นเจ้าของ [Cell](https://reference.aspose.com/slides/th/php-java/aspose.slides/cell/) |

ทั้งสองเมธอดให้การนำทางแบบอ่านอย่างเดียว การเรียกใช้ไม่ทำให้กรอบข้อความเคลื่อนย้ายหรือเปลี่ยนเจ้าของ โค้ดทั่วไปควรตรวจสอบค่าทั้งสองด้วย `java_is_null` และจัดการกรณีที่ไม่มีเจ้าของใด ๆ

ตัวอย่างต่อไปนี้ใช้ [SlideUtil::getAllTextFrames](https://reference.aspose.com/slides/th/php-java/aspose.slides/slideutil/#getAllTextFrames) เพื่อวนรอบกรอบข้อความในงานนำเสนอ สำหรับรูปร่าง รายงานชื่อรูปร่าง ชนิดรันไทม์ของ Java และสไลด์ที่บรรจุ สำหรับเซลล์ตาราง รายงานพิกัดคอลัมน์และแถวที่เริ่มจากศูนย์และสไลด์ที่บรรจุ

```php
use aspose\slides\Presentation;
use aspose\slides\SlideUtil;

$presentation = new Presentation("presentation.pptx");
$arrayClass = new java_class("java.lang.reflect.Array");

try {
    $textFrames = SlideUtil::getAllTextFrames($presentation, false);
    $textFrameCount = java_values($arrayClass->getLength($textFrames));

    for ($textFrameIndex = 0; $textFrameIndex < $textFrameCount; $textFrameIndex++) {
        $textFrame = $textFrames[$textFrameIndex];
        $ownerShape = $textFrame->getParentShape();
        if (!java_is_null($ownerShape)) {
            $shapeName = java_values($ownerShape->getName());
            $shapeName = $shapeName === "" ? "(unnamed)" : $shapeName;
            $shapeType = java_values($ownerShape->getClass()->getSimpleName());
            $baseSlide = $ownerShape->getSlide();
            $slideClassName = java_values($baseSlide->getClass()->getName());

            if ($slideClassName === "com.aspose.slides.Slide") {
                $slideLabel = "slide " . java_values($baseSlide->getSlideNumber());
            } elseif ($slideClassName === "com.aspose.slides.NotesSlide") {
                $slideLabel = "notes for slide " . java_values($baseSlide->getParentSlide()->getSlideNumber());
            } else {
                $slideLabel = java_values($baseSlide->getClass()->getSimpleName());
            }

            echo("Shape: " . $shapeName . "; type: " . $shapeType . "; " . $slideLabel . "\n");
            continue;
        }

        $ownerCell = $textFrame->getParentCell();
        if (!java_is_null($ownerCell)) {
            $baseSlide = $ownerCell->getSlide();
            $slideClassName = java_values($baseSlide->getClass()->getName());

            if ($slideClassName === "com.aspose.slides.Slide") {
                $slideLabel = "slide " . java_values($baseSlide->getSlideNumber());
            } elseif ($slideClassName === "com.aspose.slides.NotesSlide") {
                $slideLabel = "notes for slide " . java_values($baseSlide->getParentSlide()->getSlideNumber());
            } else {
                $slideLabel = java_values($baseSlide->getClass()->getSimpleName());
            }

            echo("Table cell: column " . java_values($ownerCell->getFirstColumnIndex()) . ", row " . java_values($ownerCell->getFirstRowIndex()) . "; " . $slideLabel . "\n");
            continue;
        }

        echo("The text frame owner is not available as a shape or table cell.\n");
    }
} finally {
    $presentation->dispose();
}
```

สำหรับเนื้อหา SmartArt ให้วนรอบรูปร่างใน [SmartArtNode::getShapes](https://reference.aspose.com/slides/th/php-java/aspose.slides/smartartnode/#getShapes) และเข้าถึงแต่ละ [SmartArtShape::getTextFrame](https://reference.aspose.com/slides/th/php-java/aspose.slides/smartartshape/#getTextFrame) กรอบข้อความสามารถตามรอยไปยังรูปร่างที่เกี่ยวข้องผ่าน [TextFrame::getParentShape](https://reference.aspose.com/slides/th/php-java/aspose.slides/textframe/#getParentShape) ส่วน [TextFrame::getParentCell](https://reference.aspose.com/slides/th/php-java/aspose.slides/textframe/#getParentCell) จะคืน `null` ดังนั้นส่วนของรูปร่างในตัวอย่างยังจัดการข้อความจากโหนด SmartArt ด้วย

## **รวบรวมข้อมูลการจับคู่ด้วย Callback**

ส่ง callback ของ Java proxy ไปยังเมธอดไฮไลท์หรือแทนที่เพื่อรับการแจ้งเตือนสำหรับทุกการจับคู่ Callback จะได้รับกรอบข้อความที่เกี่ยวข้อง ข้อความต้นฉบับ ข้อความที่ตรงกัน และตำแหน่งของการจับคู่

Callback ไม่ได้รับหมายเลขสไลด์โดยตรง การทำงานด้านล่างจะสกัดหมายเลขจากสไลด์พาเรนต์และยังจัดการข้อความที่พบในบันทึกสไลด์ด้วย อาร์เรย์ผลลัพธ์จะใช้ `null` เมื่อข้อความเชื่อมโยงกับประเภทสไลด์อื่น

```php
class TextSearchCallback {
    private $results = [];

    public function getResults() {
        return $this->results;
    }

    public function foundResult($textFrame, $sourceText, $foundText, $textPosition) {
        $slideNumber = $this->getSlideNumber($textFrame);
        $this->results[] = [
            "textFrame" => $textFrame,
            "sourceText" => java_values($sourceText),
            "foundText" => java_values($foundText),
            "textPosition" => java_values($textPosition),
            "slideNumber" => $slideNumber
        ];
    }

    private function getSlideNumber($textFrame) {
        $parentShape = $textFrame->getParentShape();
        $parentCell = $textFrame->getParentCell();

        if (!java_is_null($parentShape)) {
            $parentSlide = $parentShape->getSlide();
        } elseif (!java_is_null($parentCell)) {
            $parentSlide = $parentCell->getSlide();
        } else {
            $parentSlide = $textFrame->getSlide();
        }

        if (java_is_null($parentSlide)) {
            return null;
        }

        $parentSlideClass = $parentSlide->getClass();
        $classNameValue = $parentSlideClass->getName();
        $className = java_values($classNameValue);

        if ($className === "com.aspose.slides.Slide") {
            $slideNumber = $parentSlide->getSlideNumber();
            return java_values($slideNumber);
        }

        if ($className === "com.aspose.slides.NotesSlide") {
            $slide = $parentSlide->getParentSlide();
            $slideNumber = $slide->getSlideNumber();
            return java_values($slideNumber);
        }

        return null;
    }
}
```

สร้าง proxy สำหรับอ็อบเจ็กต์ PHP นี้ก่อนที่จะส่งไปยังการดำเนินการ:

```php
$callbackHandler = new TextSearchCallback();
$callbackInterface = java("com.aspose.slides.IFindResultCallback");
$callback = java_closure(
    $callbackHandler,
    null,
    $callbackInterface
);
```

สำหรับการดำเนินการแทนที่ `foundText` จะบรรจุข้อความที่ตรงกันต้นฉบับ ดังนั้น callback สามารถบันทึกได้อย่างแม่นยำว่าตัว term ใดถูกแทนที่

## **ไฮไลท์ข้อความ**

ใช้เมธอด [TextFrame::highlightText](https://reference.aspose.com/slides/th/php-java/aspose.slides/textframe/#highlightText) เพื่อไฮไลท์การจับคู่ข้อความตามตัวอักษรในกรอบข้อความ ส่ง [TextSearchOptions](https://reference.aspose.com/slides/th/php-java/aspose.slides/textsearchoptions/) เพื่อควบคุมการค้นหา

ตัวอย่างโค้ดด้านล่างไฮไลท์การปรากฏของอักขระ **"try"** ทั้งหมดแล้วจึงไฮไลท์เฉพาะคำเต็ม **"to"**

```php
$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->get_Item(0);
    $callbackHandler = new TextSearchCallback();
    $callbackInterface = java("com.aspose.slides.IFindResultCallback");
    $callback = java_closure(
        $callbackHandler,
        null,
        $callbackInterface
    );

    $substringSearchOptions = new TextSearchOptions();
    $substringSearchOptions->setCaseSensitive(false);
    $substringHighlightColor = new Java("java.awt.Color", 173, 216, 230);

    // ไฮไลท์ทุกการปรากฏของ "try" ในกรอบข้อความ.
    $shape->getTextFrame()->highlightText(
        "try",
        $substringHighlightColor,
        $substringSearchOptions,
        $callback
    );

    $wholeWordSearchOptions = new TextSearchOptions();
    $wholeWordSearchOptions->setWholeWordsOnly(true);
    $wholeWordSearchOptions->setCaseSensitive(false);
    $wholeWordHighlightColor = new Java("java.awt.Color", 238, 130, 238);

    // ไฮไลท์เฉพาะคำเต็ม "to".
    $shape->getTextFrame()->highlightText(
        "to",
        $wholeWordHighlightColor,
        $wholeWordSearchOptions,
        $callback
    );

    foreach ($callbackHandler->getResults() as $result) {
        echo(
            "Found '" . $result["foundText"] . "' at position " .
            $result["textPosition"] . " on slide " .
            $result["slideNumber"] . ".\n"
        );
    }

    $presentation->save("highlighted_text.pptx", SaveFormat::Pptx);
}
finally {
    $presentation->dispose();
}
```

ผลลัพธ์:

![ข้อความที่ถูกไฮไลท์](highlighted_text.png)

## **ไฮไลท์ข้อความโดยใช้ Regular Expressions**

เมธอด [TextFrame::highlightRegex](https://reference.aspose.com/slides/th/php-java/aspose.slides/textframe/#highlightRegex) จะไฮไลท์ข้อความที่พบโดย regular expression ในกรอบข้อความ

โค้ดต่อไปนี้ไฮไลท์ทุกคำที่มีความยาวเจ็ดอักขระหรือมากกว่า:

```php
$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->get_Item(0);
    $regex = java("java.util.regex.Pattern")->compile("\\b[^\\s]{7,}\\b");
    $highlightColor = java("java.awt.Color")->YELLOW;

    $shape->getTextFrame()->highlightRegex($regex, $highlightColor, null);

    $presentation->save("highlighted_text_using_regex.pptx", SaveFormat::Pptx);
}
finally {
    $presentation->dispose();
}
```

ผลลัพธ์:

![ข้อความที่ถูกไฮไลท์โดยใช้ regular expression](highlighted_text_using_regex.png)

## **ไฮไลท์ข้อความทั่วทั้งงานนำเสนอ**

ใช้ [Presentation::highlightText](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentation/#highlightText) และ [Presentation::highlightRegex](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentation/#highlightRegex) เพื่อค้นหากรอบข้อความที่เกี่ยวข้องทั้งหมดในงานนำเสนอ ตัวอย่างต่อไปนี้ไฮไลท์คำตามตัวอักษรและที่อยู่อีเมลทั้งหมด:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $searchOptions = new TextSearchOptions();
    $searchOptions->setWholeWordsOnly(true);
    $searchOptions->setCaseSensitive(false);
    $termHighlightColor = java("java.awt.Color")->ORANGE;

    $presentation->highlightText(
        "confidential",
        $termHighlightColor,
        $searchOptions,
        null
    );

    $patternClass = java("java.util.regex.Pattern");
    $emailPattern = "\\b[A-Z0-9._%+-]+@[A-Z0-9.-]+\\.[A-Z]{2,}\\b";
    $emailRegex = $patternClass->compile(
        $emailPattern,
        $patternClass->CASE_INSENSITIVE
    );
    $emailHighlightColor = java("java.awt.Color")->YELLOW;

    $presentation->highlightRegex($emailRegex, $emailHighlightColor, null);
    $presentation->save("highlighted_presentation.pptx", SaveFormat::Pptx);
}
finally {
    $presentation->dispose();
}
```

## **แทนที่ข้อความในกรอบข้อความ**

ใช้ [TextFrame::replaceText](https://reference.aspose.com/slides/th/php-java/aspose.slides/textframe/#replaceText) สำหรับข้อความตามตัวอักษรและ [TextFrame::replaceRegex](https://reference.aspose.com/slides/th/php-java/aspose.slides/textframe/#replaceRegex) สำหรับการแทนที่แบบ pattern วิธีเหล่านี้จะอัปเดตข้อความที่ตรงกันภายในกรอบข้อความเดิม ซึ่งรักษาการจัดรูปแบบส่วนโดยรอบแทนการสร้างกรอบข้อความใหม่จากสตริงธรรมดา

ตัวอย่างต่อไปนี้ทำให้รูปแบบการสะกดแบบต่าง ๆ มีความสอดคล้องกันแล้วแทนที่ป้ายเวอร์ชัน:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->get_Item(0);

    $searchOptions = new TextSearchOptions();
    $searchOptions->setWholeWordsOnly(true);
    $searchOptions->setCaseSensitive(false);

    $shape->getTextFrame()->replaceText(
        "colour",
        "color",
        $searchOptions,
        null
    );

    $patternClass = java("java.util.regex.Pattern");
    $versionPattern = "\\bv\\d+(?:\\.\\d+)*\\b";
    $versionRegex = $patternClass->compile(
        $versionPattern,
        $patternClass->CASE_INSENSITIVE
    );
    $shape->getTextFrame()->replaceRegex(
        $versionRegex,
        "current version",
        null
    );

    $presentation->save("updated_text_frame.pptx", SaveFormat::Pptx);
}
finally {
    $presentation->dispose();
}
```

หากการจับคู่หนึ่งครอบคลุมส่วนที่มีการจัดรูปแบบต่างกัน ควรตรวจสอบผลลัพธ์เพื่อยืนยันว่าการจัดรูปแบบใดควรใช้กับข้อความที่แทนที่

## **แทนที่ข้อความทั่วทั้งงานนำเสนอ**

ใช้ [Presentation::replaceText](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentation/#replaceText) และ [Presentation::replaceRegex](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentation/#replaceRegex) เพื่อทำการเดียวกันทั่วทั้งงานนำเสนอ สิ่งนี้มีประโยชน์สำหรับการทำความสะอาดเทมเพลต การอัปเดตคำศัพท์ และการทำลบข้อมูล

```php
$presentation = new Presentation("presentation.pptx");
try {
    $searchOptions = new TextSearchOptions();
    $searchOptions->setWholeWordsOnly(true);
    $searchOptions->setCaseSensitive(true);

    $presentation->replaceText(
        "Contoso",
        "Example Corp",
        $searchOptions,
        null
    );

    $accountNumberRegex = java("java.util.regex.Pattern")->compile(
        "\\bACCT-\\d{6}\\b"
    );
    $presentation->replaceRegex(
        $accountNumberRegex,
        "ACCT-REDACTED",
        null
    );

    $presentation->save("updated_presentation.pptx", SaveFormat::Pptx);
}
finally {
    $presentation->dispose();
}
```

## **จัดกลุ่มการจับคู่เพื่อการรายงาน**

เนื่องจากแต่ละผลลัพธ์บันทึกหมายเลขสไลด์และกรอบข้อความไว้ แอปพลิเคชันจึงสามารถจัดกลุ่มการจับคู่เพื่อการตรวจสอบ รายงาน หรือกระบวนการทบทวน ตัวอย่างต่อไปนี้จัดกลุ่มผลลัพธ์ที่รวบรวมไว้ตามสไลด์ก่อน แล้วตามกรอบข้อความ:

```php
$matchesBySlide = [];
$systemClass = java("java.lang.System");

foreach ($callbackHandler->getResults() as $result) {
    $slideNumber = $result["slideNumber"];
    $slideLabel = $slideNumber === null ? "Other" : (string) $slideNumber;
    $textFrame = $result["textFrame"];
    $textFrameHash = $systemClass->identityHashCode($textFrame);
    $textFrameKey = (string) java_values($textFrameHash);

    if (!isset($matchesBySlide[$slideLabel])) {
        $matchesBySlide[$slideLabel] = [];
    }

    if (!isset($matchesBySlide[$slideLabel][$textFrameKey])) {
        $matchesBySlide[$slideLabel][$textFrameKey] = [
            "textFrame" => $textFrame,
            "matches" => []
        ];
    }

    $matchesBySlide[$slideLabel][$textFrameKey]["matches"][] = $result;
}

foreach ($matchesBySlide as $slideLabel => $textFrameGroups) {
    echo("Slide: " . $slideLabel . "\n");

    foreach ($textFrameGroups as $textFrameGroup) {
        $textFrame = $textFrameGroup["textFrame"];
        echo("  Text frame: " . $textFrame->getText() . "\n");

        foreach ($textFrameGroup["matches"] as $result) {
            echo(
                "    '" . $result["foundText"] . "' at position " .
                $result["textPosition"] . "; context: '" .
                $result["sourceText"] . "'\n"
            );
        }
    }
}
```

## **คำถามที่พบบ่อย**

**ฉันจะค้นหาเพียงกล่องข้อความเดียวแทนที่จะค้นทั่วทั้งงานนำเสนอได้อย่างไร?**

รับกรอบข้อความของรูปร่างและเรียกใช้ [TextFrame::highlightText](https://reference.aspose.com/slides/th/php-java/aspose.slides/textframe/#highlightText), [TextFrame::highlightRegex](https://reference.aspose.com/slides/th/php-java/aspose.slides/textframe/#highlightRegex), [TextFrame::replaceText](https://reference.aspose.com/slides/th/php-java/aspose.slides/textframe/#replaceText) หรือ [TextFrame::replaceRegex](https://reference.aspose.com/slides/th/php-java/aspose.slides/textframe/#replaceRegex) บนกรอบข้อความนั้น เมธอดระดับงานนำเสนอจะประมวลผลกรอบข้อความทั้งหมดที่เกี่ยวข้องแทน

**ฉันจะจับคู่คำเต็มพร้อมการใช้ตัวพิมพ์ใหญ่‑เล็กที่ถูกต้องได้อย่างไร?**

ตั้งค่า [TextSearchOptions::setWholeWordsOnly](https://reference.aspose.com/slides/th/php-java/aspose.slides/textsearchoptions/#setWholeWordsOnly) และ [TextSearchOptions::setCaseSensitive](https://reference.aspose.com/slides/th/php-java/aspose.slides/textsearchoptions/#setCaseSensitive) เป็น `true` แล้วส่งอ็อปชันเหล่านั้นไปยังเมธอดไฮไลท์หรือแทนที่ข้อความตามตัวอักษร สำหรับ regular expression ให้กำหนดขอบเขตคำและความไวต่อกรณีอักษรใน `Pattern` ของ Java เอง

**การค้นหาและแทนที่สามารถรวมข้อความในบันทึกสไลด์ได้หรือไม่?**

ได้ ให้ตั้งค่า [TextSearchOptions::setIncludeNotes](https://reference.aspose.com/slides/th/php-java/aspose.slides/textsearchoptions/#setIncludeNotes) เป็น `true` เมื่อใช้การดำเนินการระดับงานนำเสนอที่เป็นข้อความตามตัวอักษร

**ฉันจะสร้างรายงานโดยไม่ต้องสแกนงานนำเสนออีกครั้งได้อย่างไร?**

ส่ง callback ของ Java proxy ไปยังการไฮไลท์หรือแทนที่ Callback จะได้รับทุกการจับคู่ขณะดำเนินการ ทำให้แอปพลิเคชันสามารถบันทึกข้อความต้นฉบับ ข้อความที่ตรงกัน ตำแหน่ง กรอบข้อความ และหมายเลขสไลด์ที่ได้จากการคำนวณเพื่อการจัดกลุ่มหรือส่งออกในภายหลัง

**การแทนที่ข้อความทำให้รูปแบบของข้อความคงอยู่หรือไม่?**

[TextFrame::replaceText](https://reference.aspose.com/slides/th/php-java/aspose.slides/textframe/#replaceText) และ [TextFrame::replaceRegex](https://reference.aspose.com/slides/th/php-java/aspose.slides/textframe/#replaceRegex) ปรับข้อความที่ตรงกันภายในกรอบข้อความเดิมและรักษาการจัดรูปแบบส่วนโดยรอบ หากการจับคู่ครอบคลุมส่วนที่มีรูปแบบต่างกัน ให้ตรวจสอบผลลัพธ์เพื่อให้แน่ใจว่าการแทนที่ใช้สไตล์ที่ต้องการ