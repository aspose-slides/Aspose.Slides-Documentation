---
title: ค้นหาและแทนที่ข้อความในงานนำเสนอ PowerPoint ด้วย JavaScript
linktitle: ค้นหาและแทนที่ข้อความ
type: docs
weight: 55
url: /th/nodejs-java/search-and-replace-text/
keywords:
- ค้นหาข้อความ
- ไฮไลต์ข้อความ
- แทนที่ข้อความ
- นิพจน์ปกติ
- การเรียกกลับผลลัพธ์
- กรอบข้อความ
- รายงานการตรวจสอบ
- PowerPoint
- OpenDocument
- งานนำเสนอ
- Node.js
- JavaScript
- Aspose.Slides
description: "ค้นหา, ไฮไลต์ และแทนที่ข้อความในงานนำเสนอ PowerPoint พร้อมเก็บรวบรวมทุกการจับคู่ด้วย Aspose.Slides for Node.js via Java."
---
## **ภาพรวม**

Aspose.Slides for Node.js via Java สามารถค้นหา ไฮไลต์ และแทนที่ข้อความในกรอบข้อความเดี่ยวหรือทั่วทั้งงานนำเสนอได้ แต่ละการดำเนินการยังสามารถแจ้งให้แอปพลิเคชันทราบทุกผลแมตช์ผ่านการเรียกกลับผลลัพธ์ ทำให้สามารถอัปเดตงานนำเสนอและสร้างร่องรอยการตรวจสอบที่บรรจุข้อความที่ตรงกัน, บริบท, ตำแหน่ง, กรอบข้อความ, และหมายเลขสไลด์ได้พร้อมกัน

ความสามารถเหล่านี้เป็นประโยชน์สำหรับการตรวจทาน, การลบข้อมูล, การตรวจสอบคำศัพท์, การทำความสะอาดเทมเพลต, และกระบวนการรายงานอัตโนมัติ

ในตัวอย่างแรกด้านล่าง เราใช้ไฟล์ชื่อ "sample.pptx" ซึ่งมีกล่องข้อความเดียวบนสไลด์แรกพร้อมข้อความต่อไปนี้:

![ข้อความตัวอย่าง](sample_text.png)

## **เลือกขอบเขตการค้นหา**

ใช้เมธอดบน [TextFrame](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/textframe/) เพื่อจำกัดการดำเนินการให้กับกรอบข้อความหนึ่งใช้เมธอดบน [Presentation](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/presentation/) เพื่อประมวลผลข้อความที่เกี่ยวข้องทั้งหมดในงานนำเสนอ

| การดำเนินการ | กรอบข้อความหนึ่ง | งานนำเสนอทั้งหมด |
|---|---|---|
| ไฮไลต์ข้อความตามตัวอักษร | [TextFrame.highlightText](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/textframe/#highlightText-java.lang.String-java.awt.Color-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) | [Presentation.highlightText](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/presentation/#highlightText-java.lang.String-java.awt.Color-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) |
| ไฮไลต์ผลการจับคู่แบบนิพจน์ปกติ | [TextFrame.highlightRegex](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/textframe/#highlightRegex-java.util.regex.Pattern-java.awt.Color-com.aspose.slides.IFindResultCallback-) | [Presentation.highlightRegex](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/presentation/#highlightRegex-java.util.regex.Pattern-java.awt.Color-com.aspose.slides.IFindResultCallback-) |
| แทนที่ข้อความตามตัวอักษร | [TextFrame.replaceText](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/textframe/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) | [Presentation.replaceText](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/presentation/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) |
| แทนที่ผลการจับคู่แบบนิพจน์ปกติ | [TextFrame.replaceRegex](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/textframe/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) | [Presentation.replaceRegex](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/presentation/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) |

## **กำหนดค่าการจับคูข้อความ**

สำหรับการดำเนินการข้อความตามอักษร ให้ใช้ [TextSearchOptions](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/textsearchoptions/) เพื่อควบคุมการจับคู่:

- [TextSearchOptions.setWholeWordsOnly](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/textsearchoptions/#setWholeWordsOnly-boolean-) จำกัดการจับคู่ให้เป็นคำเต็มเท่านั้น
- [TextSearchOptions.setCaseSensitive](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/textsearchoptions/#setCaseSensitive-boolean-) ควบคุมว่าต้องตรงกับตัวพิมพ์ใหญ่/เล็กหรือไม่
- [TextSearchOptions.setIncludeNotes](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/textsearchoptions/#setIncludeNotes-boolean-) รวมบันทึกย่อของสไลด์ในการค้นหา, การแทนที่และการไฮไลต์ระดับงานนำเสนอ

การดำเนินการแบบนิพจน์ปกติใช้ `Pattern` ของ Java ดังนั้นกฎการจับคู่เช่น ความไวต่อกรณีและขอบเขตคำจะถูกกำหนดโดยนิพจน์และแฟล็กของมัน

## **เก็บข้อมูลการจับคู่ด้วย Callback**

สร้างโปรกซี Java สำหรับการเรียกกลับผลลัพธ์เพื่อรับการแจ้งเตือนสำหรับทุกแมตช์ ฟังก์ชันโปรกซีจะรับกรอบข้อความที่เกี่ยวข้อง, ข้อความต้นฉบับ, ข้อความที่ตรงกัน, และตำแหน่งของแมตช์

Callback ไม่ได้รับหมายเลขสไลด์โดยตรง การทำงานด้านล่างจะสรุปหมายเลขสไลด์ผ่าน [TextFrame.getSlide](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/textframe/#getSlide--), [Slide.getSlideNumber](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/slide/#getSlideNumber--), และ [NotesSlide.getParentSlide](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/notesslide/#getParentSlide--). มันยังจัดการข้อความที่พบในบันทึกย่อของสไลด์ด้วย

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

function getSlideNumber(textFrame) {
    const parentSlide = textFrame.getSlide();

    if (java.instanceOf(parentSlide, "com.aspose.slides.Slide")) {
        return parentSlide.getSlideNumber();
    }

    if (java.instanceOf(parentSlide, "com.aspose.slides.NotesSlide")) {
        return parentSlide.getParentSlide().getSlideNumber();
    }

    return null;
}

function createTextSearchCallback(results) {
    return java.newProxy("com.aspose.slides.IFindResultCallback", {
        foundResult: function(textFrame, sourceText, foundText, textPosition) {
            results.push({
                textFrame: textFrame,
                sourceText: sourceText,
                foundText: foundText,
                textPosition: textPosition,
                slideNumber: getSlideNumber(textFrame)
            });
        }
    });
}
```

สำหรับการดำเนินการแทนที่ `foundText` จะบรรจุข้อความที่ตรงกันดั้งเดิม ดังนั้น Callback สามารถบันทึกได้อย่างแม่นยำว่าคำใดถูกแทนที่

## **ไฮไลต์ข้อความ**

ใช้เมธอด [TextFrame.highlightText](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/textframe/#highlightText-java.lang.String-java.awt.Color-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) เพื่อไฮไลต์ผลการจับคู่ข้อความตามอักษรในกรอบข้อความ ส่งผ่าน [TextSearchOptions](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/textsearchoptions/) เพื่อควบคุมการค้นหา

โค้ดตัวอย่างด้านล่างจะไฮไลต์ทุกการเกิดของอักขระ **"try"** แล้วจึงไฮไลต์เฉพาะคำเต็ม **"to"**

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().get_Item(0);

    const substringSearchOptions = new aspose.slides.TextSearchOptions();
    substringSearchOptions.setCaseSensitive(false);
    const substringHighlightColor = java.getStaticFieldValue("java.awt.Color", "LIGHT_GRAY");

    // ไฮไลต์ทุกการปรากฏของ "try" ในกรอบข้อความ.
    shape.getTextFrame().highlightText(
        "try", substringHighlightColor, substringSearchOptions, null);

    const wholeWordSearchOptions = new aspose.slides.TextSearchOptions();
    wholeWordSearchOptions.setWholeWordsOnly(true);
    wholeWordSearchOptions.setCaseSensitive(false);
    const wholeWordHighlightColor = java.getStaticFieldValue("java.awt.Color", "MAGENTA");

    // ไฮไลต์เฉพาะคำเต็ม "to" เท่านั้น.
    shape.getTextFrame().highlightText(
        "to", wholeWordHighlightColor, wholeWordSearchOptions, null);

    presentation.save("highlighted_text.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

ผลลัพธ์:

![ข้อความที่ไฮไลต์](highlighted_text.png)

## **ไฮไลต์ข้อความโดยใช้ Regular Expressions**

เมธอด [TextFrame.highlightRegex](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/textframe/#highlightRegex-java.util.regex.Pattern-java.awt.Color-com.aspose.slides.IFindResultCallback-) จะไฮไลต์ข้อความที่พบโดยนิพจน์ปกติในกรอบข้อความ

โค้ดต่อไปนี้ไฮไลต์ทุกคำที่มีความยาวเจ็ดอักขระหรือมากกว่า:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");
const Pattern = java.import("java.util.regex.Pattern");

const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().get_Item(0);
    const regex = Pattern.compile("\\b[^\\s]{7,}\\b");
    const highlightColor = java.getStaticFieldValue("java.awt.Color", "YELLOW");

    shape.getTextFrame().highlightRegex(regex, highlightColor, null);

    presentation.save(
        "highlighted_text_using_regex.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

ผลลัพธ์:

![ข้อความที่ไฮไลต์โดยใช้ regular expression](highlighted_text_using_regex.png)

## **ไฮไลต์ข้อความทั่วทั้งงานนำเสนอ**

ใช้ [Presentation.highlightText](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/presentation/#highlightText-java.lang.String-java.awt.Color-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) และ [Presentation.highlightRegex](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/presentation/#highlightRegex-java.util.regex.Pattern-java.awt.Color-com.aspose.slides.IFindResultCallback-) เพื่อค้นหากรอบข้อความทั้งหมดที่เกี่ยวข้องในงานนำเสนอ ตัวอย่างต่อไปนี้ไฮไลต์คำตามอักษรและที่อยู่อีเมลทั้งหมด:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");
const Pattern = java.import("java.util.regex.Pattern");

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const searchOptions = new aspose.slides.TextSearchOptions();
    searchOptions.setWholeWordsOnly(true);
    searchOptions.setCaseSensitive(false);
    const termHighlightColor = java.getStaticFieldValue("java.awt.Color", "ORANGE");

    presentation.highlightText(
        "confidential", termHighlightColor, searchOptions, null);

    const emailRegex = Pattern.compile(
        "\\b[A-Z0-9._%+-]+@[A-Z0-9.-]+\\.[A-Z]{2,}\\b",
        Pattern.CASE_INSENSITIVE);
    const emailHighlightColor = java.getStaticFieldValue("java.awt.Color", "YELLOW");

    presentation.highlightRegex(emailRegex, emailHighlightColor, null);
    presentation.save("highlighted_presentation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **แทนที่ข้อความในกรอบข้อความ**

ใช้ [TextFrame.replaceText](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/textframe/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) สำหรับข้อความตามอักษรและ [TextFrame.replaceRegex](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/textframe/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) สำหรับการแทนที่ตามรูปแบบ เมธอดเหล่านี้อัปเดตข้อความที่ตรงกันภายในกรอบข้อความเดิม ซึ่งยังคงรูปแบบส่วนโดยรอบแทนการสร้างกรอบข้อความใหม่จากสตริงธรรมดา

ตัวอย่างต่อไปนี้ทำให้รูปแบบการสะกดแบบต่างกันเป็นมาตรฐานแล้วแทนที่ป้ายรุ่น:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");
const Pattern = java.import("java.util.regex.Pattern");

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().get_Item(0);
    const searchOptions = new aspose.slides.TextSearchOptions();
    searchOptions.setWholeWordsOnly(true);
    searchOptions.setCaseSensitive(false);

    shape.getTextFrame().replaceText(
        "colour", "color", searchOptions, null);

    const versionRegex = Pattern.compile(
        "\\bv\\d+(?:\\.\\d+)*\\b", Pattern.CASE_INSENSITIVE);
    shape.getTextFrame().replaceRegex(versionRegex, "current version", null);

    presentation.save("updated_text_frame.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

หากแมตช์หนึ่งครอบคลุมส่วนที่มีรูปแบบแตกต่างกัน ให้ตรวจสอบผลลัพธ์เพื่อยืนยันว่ารูแบบใดควรใช้กับข้อความที่แทนที่

## **แทนที่ข้อความทั่วทั้งงานนำเสนอ**

ใช้ [Presentation.replaceText](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/presentation/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) และ [Presentation.replaceRegex](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/presentation/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) เพื่อดำเนินการเดียวกันทั่วงานนำเสนอ นี่เป็นประโยชน์สำหรับการทำความสะอาดเทมเพลต, การอัปเดตศัพท์, และการลบข้อมูล

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");
const Pattern = java.import("java.util.regex.Pattern");

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const searchOptions = new aspose.slides.TextSearchOptions();
    searchOptions.setWholeWordsOnly(true);
    searchOptions.setCaseSensitive(true);

    presentation.replaceText(
        "Contoso", "Example Corp", searchOptions, null);

    const accountNumberRegex = Pattern.compile("\\bACCT-\\d{6}\\b");
    presentation.replaceRegex(accountNumberRegex, "ACCT-REDACTED", null);

    presentation.save("updated_presentation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **จัดกลุ่มการจับคู่สำหรับการรายงาน**

เนื่องจากผลลัพธ์ที่เก็บรวบรวมแต่ละรายการบันทึกหมายเลขสไลด์และกรอบข้อความ แอปพลิเคชันจึงสามารถจัดกลุ่มการจับคู่เพื่อการตรวจสอบ, รายงาน หรือกระบวนการตรวจทาน ตัวอย่างต่อไปนี้จัดกลุ่มผลลัพธ์โดยแรกตามสไลด์แล้วตามกรอบข้อความ:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

function getSlideNumber(textFrame) {
    const parentSlide = textFrame.getSlide();

    if (java.instanceOf(parentSlide, "com.aspose.slides.Slide")) {
        return parentSlide.getSlideNumber();
    }

    if (java.instanceOf(parentSlide, "com.aspose.slides.NotesSlide")) {
        return parentSlide.getParentSlide().getSlideNumber();
    }

    return null;
}

const results = [];
const callback = java.newProxy("com.aspose.slides.IFindResultCallback", {
    foundResult: function(textFrame, sourceText, foundText, textPosition) {
        results.push({
            textFrame: textFrame,
            sourceText: sourceText,
            foundText: foundText,
            textPosition: textPosition,
            slideNumber: getSlideNumber(textFrame)
        });
    }
});

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const searchOptions = new aspose.slides.TextSearchOptions();
    searchOptions.setCaseSensitive(false);
    const highlightColor = java.getStaticFieldValue("java.awt.Color", "YELLOW");

    presentation.highlightText(
        "confidential", highlightColor, searchOptions, callback);

    const matchesBySlide = new Map();

    for (const result of results) {
        const slideLabel = result.slideNumber === null ? "Other" : result.slideNumber;

        if (!matchesBySlide.has(slideLabel)) {
            matchesBySlide.set(slideLabel, new Map());
        }

        const matchesByTextFrame = matchesBySlide.get(slideLabel);
        if (!matchesByTextFrame.has(result.textFrame)) {
            matchesByTextFrame.set(result.textFrame, []);
        }

        matchesByTextFrame.get(result.textFrame).push(result);
    }

    for (const [slideLabel, matchesByTextFrame] of matchesBySlide) {
        console.log("Slide: " + slideLabel);

        for (const [textFrame, textFrameMatches] of matchesByTextFrame) {
            console.log("  Text frame: " + textFrame.getText());

            for (const result of textFrameMatches) {
                console.log(
                    "    '" + result.foundText + "' at position " +
                    result.textPosition + "; context: '" + result.sourceText + "'");
            }
        }
    }
} finally {
    presentation.dispose();
}
```

## **คำถามที่พบบ่อย**

**ฉันจะค้นหาเพียงกล่องข้อความเดียวแทนที่จะค้นทั่วทั้งหมดได้อย่างไร?**

รับกรอบข้อความของรูปร่างแล้วเรียกใช้ [TextFrame.highlightText](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/textframe/#highlightText-java.lang.String-java.awt.Color-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-), [TextFrame.highlightRegex](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/textframe/#highlightRegex-java.util.regex.Pattern-java.awt.Color-com.aspose.slides.IFindResultCallback-), [TextFrame.replaceText](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/textframe/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-), หรือ [TextFrame.replaceRegex](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/textframe/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) บนกรอบข้อความนั้น เมธอดระดับงานนำเสนอจะประมวลผลกรอบข้อความที่เกี่ยวข้องทั้งหมดแทน

**ฉันจะจับคู่คำเต็มโดยคำนึงถึงการใช้ตัวพิมพ์ใหญ่/เล็กได้อย่างไร?**

ตั้งค่า [TextSearchOptions.setWholeWordsOnly](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/textsearchoptions/#setWholeWordsOnly-boolean-) และ [TextSearchOptions.setCaseSensitive](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/textsearchoptions/#setCaseSensitive-boolean-) เป็น `true` แล้วส่งตัวเลือกไปยังเมธอดไฮไลต์หรือแทนที่ข้อความตามอักษร สำหรับนิพจน์ปกติ ให้กำหนดขอบเขตคำและความไวต่อกรณีใน `Pattern` ของ Java เอง

**การค้นหาและแทนที่สามารถรวมข้อความในบันทึกย่อของสไลด์ได้หรือไม่?**

ได้ ตั้งค่า [TextSearchOptions.setIncludeNotes](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/textsearchoptions/#setIncludeNotes-boolean-) เป็น `true` เมื่อใช้การดำเนินการข้อความตามอักษรระดับงานนำเสนอ การทำงานของ Callback ที่แสดงด้านบนจะแมปผลการจับคู่ในสไลด์บันทึกย่อกลับไปยังหมายเลขสไลด์หลัก

**ฉันจะสร้างรายงานโดยไม่ต้องสแกนงานนำเสนออีกครั้งได้อย่างไร?**

ส่งโปรกซี Java result‑callback ไปยังการไฮไลต์หรือการแทนที่ Callback จะรับทุกแมตช์ขณะดำเนินการ ทำให้แอปพลิเคชันสามารถบันทึกข้อความต้นฉบับ, ข้อความที่ตรงกัน, ตำแหน่ง, กรอบข้อความ, และหมายเลขสไลด์ที่ได้สำหรับการจัดกลุ่มหรือส่งออกภายหลัง

**การแทนที่ข้อความจะรักษารูปแบบเดิมหรือไม่?**

[TextFrame.replaceText](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/textframe/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) และ [TextFrame.replaceRegex](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/textframe/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) แก้ไขข้อความที่ตรงกันภายในกรอบข้อความเดิมและรักษารูปแบบส่วนโดยรอบ หากแมตช์ครอบคลุมส่วนที่มีรูปแบบต่างกัน ให้ตรวจสอบผลลัพธ์เพื่อให้แน่ใจว่าการแทนที่จะใช้สไตล์ที่ต้องการ