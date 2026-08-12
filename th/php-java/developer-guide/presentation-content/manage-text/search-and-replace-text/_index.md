---
title: ค้นหาและแทนที่ข้อความในงานนำเสนอ PowerPoint ด้วย PHP
linktitle: ค้นหาและแทนที่ข้อความ
type: docs
weight: 55
url: /th/php-java/search-and-replace-text/
keywords:
- ค้นหาข้อความ
- เน้นข้อความ
- แทนที่ข้อความ
- นิพจน์ทั่วไป
- การเรียกกลับผลลัพธ์
- กรอบข้อความ
- รายงานตรวจสอบ
- PowerPoint
- OpenDocument
- งานนำเสนอ
- PHP
- Aspose.Slides
description: "ค้นหา, เน้นและแทนที่ข้อความในงานนำเสนอ PowerPoint พร้อมรวบรวมผลการจับคู่ทุกรายการด้วย Aspose.Slides for PHP via Java."
---
## **ภาพรวม**

Aspose.Slides for PHP via Java สามารถค้นหา เน้นสี และแทนที่ข้อความในกรอบข้อความเดียว หรือทั่วทั้งงานนำเสนอได้ แต่ละการดำเนินการยังสามารถแจ้งแอปพลิเคชันเกี่ยวกับแต่ละผลลัพธ์ผ่านการเรียกกลับผลลัพธ์ (result callback) ทำให้สามารถอัปเดตงานนำเสนอพร้อมสร้างบันทึกตรวจสอบที่บรรจุข้อความที่ตรงกัน, บริบท, ตำแหน่ง, กรอบข้อความ, และหมายเลขสไลด์ได้

ความสามารถเหล่านี้เป็นประโยชน์สำหรับการตรวจทาน, การทำลบข้อมูล, การตรวจสอบคำศัพท์, การทำความสะอาดเทมเพลต, และกระบวนการรายงานอัตโนมัติ

ในตัวอย่างแรกด้านล่าง เราใช้ไฟล์ชื่อ “sample.pptx” ซึ่งมีกล่องข้อความเดียวบนสไลด์แรกพร้อมข้อความต่อไปนี้:

![ข้อความตัวอย่าง](sample_text.png)

## **เลือกขอบเขตการค้นหา**

ใช้เมธอดบน [TextFrame](https://reference.aspose.com/slides/th/php-java/aspose.slides/textframe/) เพื่อจำกัดการดำเนินการให้กับกรอบข้อความเดียว ใช้เมธอดบน [Presentation](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentation/) เพื่อประมวลผลข้อความทั้งหมดที่เกี่ยวข้องในงานนำเสนอ

| การดำเนินการ | หนึ่งกรอบข้อความ | งานนำเสนอทั้งหมด |
|---|---|---|
| เน้นข้อความตามตัวอักษร | [TextFrame::highlightText](https://reference.aspose.com/slides/th/php-java/aspose.slides/textframe/#highlightText) | [Presentation::highlightText](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentation/#highlightText) |
| เน้นผลการจับคู่แบบ regular‑expression | [TextFrame::highlightRegex](https://reference.aspose.com/slides/th/php-java/aspose.slides/textframe/#highlightRegex) | [Presentation::highlightRegex](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentation/#highlightRegex) |
| แทนที่ข้อความตามตัวอักษร | [TextFrame::replaceText](https://reference.aspose.com/slides/th/php-java/aspose.slides/textframe/#replaceText) | [Presentation::replaceText](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentation/#replaceText) |
| แทนที่ผลการจับคู่แบบ regular‑expression | [TextFrame::replaceRegex](https://reference.aspose.com/slides/th/php-java/aspose.slides/textframe/#replaceRegex) | [Presentation::replaceRegex](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentation/#replaceRegex) |

## **กำหนดค่าการจับคู่ข้อความ**

สำหรับการดำเนินการตามตัวอักษร ให้ใช้ [TextSearchOptions](https://reference.aspose.com/slides/th/php-java/aspose.slides/textsearchoptions/) เพื่อควบคุมการจับคู่:

- [TextSearchOptions::setWholeWordsOnly](https://reference.aspose.com/slides/th/php-java/aspose.slides/textsearchoptions/#setWholeWordsOnly) จำกัดผลลัพธ์ให้เป็นคำเต็มเท่านั้น
- [TextSearchOptions::setCaseSensitive](https://reference.aspose.com/slides/th/php-java/aspose.slides/textsearchoptions/#setCaseSensitive) ควบคุมว่าตัวพิมพ์ใหญ่‑เล็กต้องตรงกันหรือไม่
- [TextSearchOptions::setIncludeNotes](https://reference.aspose.com/slides/th/php-java/aspose.slides/textsearchoptions/#setIncludeNotes) รวมบันทึกสไลด์ในการค้นหา, แทนที่, และการเน้นระดับงานนำเสนอ

การดำเนินการแบบ regular‑expression ใช้ `Pattern` ของ Java ดังนั้นกฎการจับคู่ เช่น ความไวต่อกรณีและขอบเขตคำ จะกำหนดโดยนิพจน์และแฟล็กของมันเอง

## **รวบรวมข้อมูลการจับคู่ด้วยการเรียกกลับ**

ส่ง callback ตัวแทน Java ไปยังเมธอดเน้นสีหรือแทนที่เพื่อรับการแจ้งเตือนสำหรับแต่ละผลลัพธ์ Callback จะได้รับกรอบข้อความที่เกี่ยวข้อง, ข้อความต้นฉบับ, ข้อความที่ตรงกัน, และตำแหน่งของผลลัพธ์

Callback จะไม่ได้รับหมายเลขสไลด์โดยตรง การทำงานด้านล่างจะสรุปหมายเลขสไลด์จากสไลด์แม่และยังจัดการข้อความที่พบในบันทึกสไลด์ด้วย อาเรย์ผลลัพธ์จะใช้ `null` เมื่อข้อความเชื่อมโยงกับประเภทสไลด์อื่น

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
        $parentSlide = $textFrame->getSlide();
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

สร้างตัวแทนสำหรับอ็อบเจกต์ PHP นี้ก่อนส่งไปยังการดำเนินการ:

```php
$callbackHandler = new TextSearchCallback();
$callbackInterface = java("com.aspose.slides.IFindResultCallback");
$callback = java_closure(
    $callbackHandler,
    null,
    $callbackInterface
);
```

สำหรับการดำเนินการแทนที่ `foundText` จะมีข้อความที่ตรงกันเดิม ดังนั้น callback สามารถบันทึกได้ว่าเทอมใดถูกแทนที่อย่างแม่นยำ

## **เน้นข้อความ**

ใช้เมธอด [TextFrame::highlightText](https://reference.aspose.com/slides/th/php-java/aspose.slides/textframe/#highlightText) เพื่อเน้นผลลัพธ์การจับคู่ตามตัวอักษรในกรอบข้อความ ส่ง [TextSearchOptions](https://reference.aspose.com/slides/th/php-java/aspose.slides/textsearchoptions/) เพื่อควบคุมการค้นหา

โค้ดตัวอย่างด้านล่างจะเน้นทุกตำแหน่งของอักขระ **"try"** แล้วต่อด้วยการเน้นเฉพาะคำเต็ม **"to"**

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

    // ไฮไลท์เฉพาะคำเต็ม "to" เท่านั้น.
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

![ข้อความที่ถูกเน้นสี](highlighted_text.png)

## **เน้นข้อความโดยใช้ Regular Expressions**

เมธอด [TextFrame::highlightRegex](https://reference.aspose.com/slides/th/php-java/aspose.slides/textframe/#highlightRegex) จะเน้นข้อความที่ตรงกับ regular expression ในกรอบข้อความ

โค้ดต่อไปนี้จะเน้นทุกคำที่มีความยาวเกี่บกับเจ็ดตัวอักษรหรือมากกว่า:

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

![ข้อความที่ถูกเน้นสีด้วย regular expression](highlighted_text_using_regex.png)

## **เน้นข้อความทั่วทั้งงานนำเสนอ**

ใช้ [Presentation::highlightText](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentation/#highlightText) และ [Presentation::highlightRegex](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentation/#highlightRegex) เพื่อค้นหากรอบข้อความทั้งหมดที่เกี่ยวข้องในงานนำเสนอ ตัวอย่างต่อไปนี้จะเน้นคำตามตัวอักษรและที่อยู่อีเมลทั้งหมด:

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

ใช้ [TextFrame::replaceText](https://reference.aspose.com/slides/th/php-java/aspose.slides/textframe/#replaceText) สำหรับข้อความตามตัวอักษรและ [TextFrame::replaceRegex](https://reference.aspose.com/slides/th/php-java/aspose.slides/textframe/#replaceRegex) สำหรับการแทนที่ตามแพทเทิร์น เมธอดเหล่านี้อัปเดตข้อความที่ตรงกันภายในกรอบข้อความเดิม ทำให้รูปแบบส่วนที่เหลืออยู่ไม่ถูกสร้างใหม่จากสตริงเปล่า

ตัวอย่างต่อไปนี้ทำมาตรฐานสำเนียงการสะกดแล้วแทนที่ป้ายรุ่น:

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

หากผลลัพธ์หนึ่งครอบคลุมส่วนที่มีรูปแบบต่างกัน โปรดตรวจสอบผลลัพธ์เพื่อยืนยันว่าควรใช้รูปแบบใดกับข้อความที่แทนที่

## **แทนที่ข้อความทั่วทั้งงานนำเสนอ**

ใช้ [Presentation::replaceText](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentation/#replaceText) และ [Presentation::replaceRegex](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentation/#replaceRegex) เพื่อทำการเดียวกันทั่วงานนำเสนอ นี่เป็นประโยชน์สำหรับการทำความสะอาดเทมเพลต, การอัปเดตคำศัพท์, และการลบข้อมูล

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

## **จัดกลุ่มผลลัพธ์สำหรับการรายงาน**

เนื่องจากแต่ละผลลัพธ์บันทึกหมายเลขสไลด์และกรอบข้อความ แอปพลิเคชันสามารถจัดกลุ่มผลลัพธ์เพื่อการตรวจสอบ, รายงาน หรือกระบวนการรีวิว ตัวอย่างต่อไปนี้จัดกลุ่มผลลัพธ์ที่รวบรวมไว้ตามสไลด์แล้วตามกรอบข้อความ:

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

**ฉันจะค้นหาในกล่องข้อความเดียวแทนที่จะค้นในงานนำเสนอทั้งหมดได้อย่างไร?**

รับกรอบข้อความของ Shape แล้วเรียก [TextFrame::highlightText](https://reference.aspose.com/slides/th/php-java/aspose.slides/textframe/#highlightText), [TextFrame::highlightRegex](https://reference.aspose.com/slides/th/php-java/aspose.slides/textframe/#highlightRegex), [TextFrame::replaceText](https://reference.aspose.com/slides/th/php-java/aspose.slides/textframe/#replaceText) หรือ [TextFrame::replaceRegex](https://reference.aspose.com/slides/th/php-java/aspose.slides/textframe/#replaceRegex) บนกรอบข้อความนั้น เมธอดระดับงานนำเสนอจะประมวลผลกรอบข้อความทั้งหมดที่เกี่ยวข้องแทน

**ฉันจะจับคำเต็มพร้อมการพิมพ์ตัวอักษรที่ถูกต้องได้อย่างไร?**

ตั้งค่า [TextSearchOptions::setWholeWordsOnly](https://reference.aspose.com/slides/th/php-java/aspose.slides/textsearchoptions/#setWholeWordsOnly) และ [TextSearchOptions::setCaseSensitive](https://reference.aspose.com/slides/th/php-java/aspose.slides/textsearchoptions/#setCaseSensitive) ให้เป็น `true` แล้วส่งตัวเลือกไปยังเมธอดเน้นหรือแทนที่ข้อความตามตัวอักษร สำหรับ regular expression ให้กำหนดขอบเขตคำและความไวต่อกรณีใน `Pattern` ของ Java เอง

**การค้นหาและการแทนที่รวมข้อความในบันทึกสไลด์ได้หรือไม่?**

ได้ ตั้งค่า [TextSearchOptions::setIncludeNotes](https://reference.aspose.com/slides/th/php-java/aspose.slides/textsearchoptions/#setIncludeNotes) ให้เป็น `true` เมื่อใช้การดำเนินการตามตัวอักษรระดับงานนำเสนอ

**ฉันจะสร้างรายงานโดยไม่ต้องสแกนงานนำเสนอครั้งที่สองได้อย่างไร?**

ส่ง callback ตัวแทน Java ไปยังการดำเนินการเน้นหรือแทนที่ มันจะรับทุกผลลัพธ์ขณะดำเนินการ ทำให้แอปสามารถเก็บข้อความต้นฉบับ, ข้อความที่ตรงกัน, ตำแหน่ง, กรอบข้อความ, และหมายเลขสไลด์ที่สกัดมาสำหรับการจัดกลุ่มหรือส่งออกในภายหลัง

**การแทนที่ข้อความจะรักษาการฟอร์แมตไว้หรือไม่?**

[TextFrame::replaceText](https://reference.aspose.com/slides/th/php-java/aspose.slides/textframe/#replaceText) และ [TextFrame::replaceRegex](https://reference.aspose.com/slides/th/php-java/aspose.slides/textframe/#replaceRegex) แก้ไขข้อความที่ตรงกันภายในกรอบข้อความเดิมและรักษาฟอร์แมตของส่วนรอบข้างไว้ หากผลลัพธ์หนึ่งครอบคลุมส่วนที่มีฟอร์แมตต่างกัน ให้ตรวจสอบผลลัพธ์เพื่อให้แน่ใจว่าการแทนที่ใช้สไตล์ที่ต้องการ