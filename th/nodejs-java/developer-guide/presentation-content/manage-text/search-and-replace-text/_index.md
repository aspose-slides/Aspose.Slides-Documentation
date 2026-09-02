---
title: ค้นหาและแทนที่ข้อความในงานนำเสนอ PowerPoint ด้วย JavaScript
linktitle: ค้นหาและแทนที่ข้อความ
type: docs
weight: 55
url: /th/nodejs-java/search-and-replace-text/
keywords:
- ค้นหาข้อความ
- ไฮไลท์ข้อความ
- แทนที่ข้อความ
- นิพจน์ปกติ
- callback ผลลัพธ์
- กรอบข้อความ
- รายงานการตรวจสอบ
- PowerPoint
- OpenDocument
- งานนำเสนอ
- Node.js
- JavaScript
- Aspose.Slides
description: "ค้นหา, เน้นและแทนที่ข้อความในงานนำเสนอ PowerPoint พร้อมเก็บบันทึกการจับคู่ทุกครั้งด้วย Aspose.Slides สำหรับ Node.js ผ่าน Java."
---
## **ภาพรวม**

Aspose.Slides for Node.js via Java สามารถค้นหา, ไฮไลท์ และแทนที่ข้อความในกรอบข้อความเดี่ยวหรือทั่วทั้งงานนำเสนอได้ แต่ละการดำเนินการยังสามารถแจ้งแอปพลิเคชันเกี่ยวกับการจับคู่ทั้งหมดผ่าน callback ของผลลัพธ์ ซึ่งทำให้สามารถอัปเดตงานนำเสนอและในขณะเดียวกันสร้างบันทึกการตรวจสอบที่บรรจุข้อความที่จับคู่, บริบท, ตำแหน่ง, กรอบข้อความ, และหมายเลขสไลด์ได้

ความสามารถเหล่านี้มีประโยชน์สำหรับการตรวจทาน, การลบข้อมูล, การตรวจสอบคำศัพท์, การทำความสะอาดเทมเพลต, และกระบวนการทำรายงานอัตโนมัติ

ในตัวอย่างแรกด้านล่าง เราใช้ไฟล์ชื่อ “sample.pptx” ซึ่งมีกล่องข้อความเดียวบนสไลด์แรกพร้อมข้อความต่อไปนี้:

![ข้อความตัวอย่าง](sample_text.png)

## **เลือกขอบเขตการค้นหา**

ใช้เมธอดบน [TextFrame](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/textframe/) เพื่อจำกัดการดำเนินการให้กับกรอบข้อความหนึ่งกรอบ ใช้เมธอดบน [Presentation](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/presentation/) เพื่อประมวลผลข้อความทั้งหมดที่เกี่ยวข้องในงานนำเสนอ

| การดำเนินการ | หนึ่งกรอบข้อความ | งานนำเสนอทั้งหมด |
|---|---|---|
| ไฮไลท์ข้อความตามตัวอักษร | [TextFrame.highlightText](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/textframe/#highlightText-java.lang.String-java.awt.Color-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) | [Presentation.highlightText](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/presentation/#highlightText-java.lang.String-java.awt.Color-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) |
| ไฮไลท์ผลลัพธ์จาก regular‑expression | [TextFrame.highlightRegex](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/textframe/#highlightRegex-java.util.regex.Pattern-java.awt.Color-com.aspose.slides.IFindResultCallback-) | [Presentation.highlightRegex](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/presentation/#highlightRegex-java.util.regex.Pattern-java.awt.Color-com.aspose.slides.IFindResultCallback-) |
| แทนที่ข้อความตามตัวอักษร | [TextFrame.replaceText](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/textframe/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) | [Presentation.replaceText](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/presentation/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) |
| แทนที่ผลลัพธ์จาก regular‑expression | [TextFrame.replaceRegex](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/textframe/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) | [Presentation.replaceRegex](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/presentation/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) |

## **กำหนดค่าการจับคู่ข้อความ**

สำหรับการดำเนินการแบบข้อความตามตัวอักษร ใช้ [TextSearchOptions](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/textsearchoptions/) เพื่อควบคุมการจับคู่:

- [TextSearchOptions.setWholeWordsOnly](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/textsearchoptions/#setWholeWordsOnly-boolean-) จำกัดผลลัพธ์ให้เป็นคำเต็มเท่านั้น
- [TextSearchOptions.setCaseSensitive](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/textsearchoptions/#setCaseSensitive-boolean-) ควบคุมว่าจะต้องตรงกับรูปพิมพ์ของอักษรหรือไม่
- [TextSearchOptions.setIncludeNotes](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/textsearchoptions/#setIncludeNotes-boolean-) รวมโน้ตของสไลด์ในการค้นหา, การแทนที่, และการไฮไลท์ระดับงานนำเสนอ

การดำเนินการแบบ regular‑expression ใช้ `Pattern` ของ Java ดังนั้นกฎการจับคู่เช่นความไวต่อรูปพิมพ์และขอบเขตคำจะถูกกำหนดโดยนิพจน์และแฟล็กของมันเอง

## **ระบุเจ้าของของกรอบข้อความ**

เวิร์กโฟลว์การประมวลผลข้อความทั่วไปมักจะได้รับ [TextFrame](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/textframe/) ขณะค้นหา, แทนที่, ตรวจสอบ หรือส่งออกข้อความ ใช้ [TextFrame.getParentShape](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/textframe/#getParentShape--) และ [TextFrame.getParentCell](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/textframe/#getParentCell--) เพื่อกำหนดว่าออบเจกต์งานนำเสนอใดเป็นเจ้าของกรอบข้อความนั้น

ค่าที่คาดว่าจะได้ขึ้นอยู่กับเจ้าของ:

| เจ้าของกรอบข้อความ | `getParentShape` | `getParentCell` |
|---|---|---|
| AutoShape หรือรูปทรงที่มีข้อความอื่น | [Shape](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/shape/) ที่เป็นเจ้าของ | `null` |
| เซลล์ของตาราง | `null` | [Cell](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/cell/) ที่เป็นเจ้าของ |

ทั้งสองเมธอดให้การนำทางแบบอ่าน‑อย่างเท่านั้น การเรียกใช้ไม่ได้ย้ายกรอบข้อความหรือเปลี่ยนเจ้าของ โค้ดทั่วไปควรตรวจสอบค่า `null` ของทั้งสองและจัดการกรณีที่ไม่มีเจ้าของใด ๆ

ตัวอย่างต่อไปนี้ใช้ [SlideUtil.getAllTextFrames](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/slideutil/#getAllTextFrames-aspose.slides.IPresentation-boolean-) เพื่อวนลูปกรอบข้อความทั้งหมดในงานนำเสนอ สำหรับรูปทรง จะรายงานชื่อรูปทรง, ประเภท runtime ของ Java, และสไลด์ที่บรรจุ ส่วนสำหรับเซลล์ของตาราง จะรายงานพิกัดคอลัมน์และแถวที่นับจากศูนย์พร้อมสไลด์ที่บรรจุ

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

function getSlideLabel(baseSlide) {
    if (java.instanceOf(baseSlide, "com.aspose.slides.Slide")) {
        return "slide " + baseSlide.getSlideNumber();
    }

    if (java.instanceOf(baseSlide, "com.aspose.slides.NotesSlide")) {
        return "notes for slide " + baseSlide.getParentSlide().getSlideNumber();
    }

    return baseSlide.getClass().getSimpleName();
}

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const textFrames = aspose.slides.SlideUtil.getAllTextFrames(presentation, false);

    for (let index = 0; index < textFrames.length; index++) {
        const textFrame = textFrames[index];
        const ownerShape = textFrame.getParentShape();
        if (ownerShape !== null) {
            const shapeName = ownerShape.getName() === "" ? "(unnamed)" : ownerShape.getName();
            const shapeType = ownerShape.getClass().getSimpleName();
            const slideLabel = getSlideLabel(ownerShape.getSlide());
            console.log("Shape: " + shapeName + "; type: " + shapeType + "; " + slideLabel);
            continue;
        }

        const ownerCell = textFrame.getParentCell();
        if (ownerCell !== null) {
            const slideLabel = getSlideLabel(ownerCell.getSlide());
            console.log("Table cell: column " + ownerCell.getFirstColumnIndex() + ", row " + ownerCell.getFirstRowIndex() + "; " + slideLabel);
            continue;
        }

        console.log("The text frame owner is not available as a shape or table cell.");
    }
} finally {
    presentation.dispose();
}
```

สำหรับเนื้อหา SmartArt ให้วนลูปรูปทรงใน [SmartArtNode.getShapes](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/smartartnode/#getShapes--) และเข้าถึงแต่ละ [SmartArtShape.getTextFrame](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/smartartshape/#getTextFrame--) กรอบข้อความสามารถตามรอยไปยังรูปทรงที่เชื่อมโยงผ่าน [TextFrame.getParentShape](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/textframe/#getParentShape--) ในขณะที่ [TextFrame.getParentCell](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/textframe/#getParentCell--) คืนค่า `null` ดังนั้นสาขารูปทรงในตัวอย่างจึงจัดการข้อความจากโหนด SmartArt ด้วย

## **เก็บข้อมูลการจับคู่ด้วย Callback**

สร้าง proxy ของ Java สำหรับ callback ของผลลัพธ์เพื่อรับการแจ้งเตือนสำหรับทุกการจับคู่ ฟังก์ชัน proxy จะรับกรอบข้อความที่เกี่ยวข้อง, ข้อความต้นฉบับ, ข้อความที่จับคู่, และตำแหน่งของการจับคู่

callback จะไม่ได้รับหมายเลขสไลด์โดยตรง การทำงานด้านล่างสรุปหมายเลขสไลด์จากรูปทรงหรือเซลล์ของตารางที่เป็นเจ้าของกรอบข้อความ ผ่าน [TextFrame.getSlide](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/textframe/#getSlide--) เป็นวิธีสำรอง นอกจากนี้ยังรองรับข้อความที่พบในโน้ตของสไลด์ด้วย

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

function getSlideNumber(textFrame) {
    const parentShape = textFrame.getParentShape();
    const parentCell = textFrame.getParentCell();
    let parentSlide = textFrame.getSlide();
    if (parentShape !== null) {
        parentSlide = parentShape.getSlide();
    } else if (parentCell !== null) {
        parentSlide = parentCell.getSlide();
    }

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

สำหรับการดำเนินการแทนที่ `foundText` จะมีข้อความต้นฉบับที่จับคู่อยู่ ดังนั้น callback สามารถบันทึกว่าข้อความใดถูกแทนที่อย่างแม่นยำ

## **ไฮไลท์ข้อความ**

ใช้เมธอด [TextFrame.highlightText](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/textframe/#highlightText-java.lang.String-java.awt.Color-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) เพื่อไฮไลท์ผลลัพธ์ที่ตรงกับข้อความตามตัวอักษรในกรอบข้อความหนึ่ง ให้ส่ง [TextSearchOptions](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/textsearchoptions/) เพื่อควบคุมการค้นหา

ตัวอย่างโค้ดด้านล่างไฮไลท์ทุกตำแหน่งของอักขระ **"try"** แล้วจึงไฮไลท์เฉพาะคำเต็ม **"to"** เท่านั้น

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

    // เน้นทุกการปรากฏของ "try" ในกรอบข้อความ
    shape.getTextFrame().highlightText(
        "try", substringHighlightColor, substringSearchOptions, null);

    const wholeWordSearchOptions = new aspose.slides.TextSearchOptions();
    wholeWordSearchOptions.setWholeWordsOnly(true);
    wholeWordSearchOptions.setCaseSensitive(false);
    const wholeWordHighlightColor = java.getStaticFieldValue("java.awt.Color", "MAGENTA");

    // เน้นเฉพาะคำเต็ม "to" เท่านั้น
    shape.getTextFrame().highlightText(
        "to", wholeWordHighlightColor, wholeWordSearchOptions, null);

    presentation.save("highlighted_text.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

ผลลัพธ์:

![ข้อความที่ไฮไลท์](highlighted_text.png)

## **ไฮไลท์ข้อความด้วย Regular Expressions**

เมธอด [TextFrame.highlightRegex](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/textframe/#highlightRegex-java.util.regex.Pattern-java.awt.Color-com.aspose.slides.IFindResultCallback-) จะไฮไลท์ข้อความที่ตรงกับ regular expression ในกรอบข้อความหนึ่ง

โค้ดต่อไปนี้ไฮไลท์ทุกคำที่มีตัวอักษรเจ็ดตัวหรือมากกว่า:

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

![ข้อความที่ไฮไลท์โดยใช้ regular expression](highlighted_text_using_regex.png)

## **ไฮไลท์ข้อความทั่วทั้งงานนำเสนอ**

ใช้ [Presentation.highlightText](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/presentation/#highlightText-java.lang.String-java.awt.Color-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) และ [Presentation.highlightRegex](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/presentation/#highlightRegex-java.util.regex.Pattern-java.awt.Color-com.aspose.slides.IFindResultCallback-) เพื่อค้นหากรอบข้อความที่เกี่ยวข้องทั้งหมดในงานนำเสนอ ตัวอย่างต่อไปนี้ไฮไลท์คำที่เป็นลิตอรัลและที่อยู่อีเมลทั้งหมด:

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

ใช้ [TextFrame.replaceText](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/textframe/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) สำหรับข้อความตามตัวอักษร และ [TextFrame.replaceRegex](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/textframe/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) สำหรับการแทนที่โดยใช้แพตเทิร์น วิธีเหล่านี้จะอัปเดตข้อความที่จับคู่ภายในกรอบข้อความที่มีอยู่แล้ว ซึ่งจะรักษาการจัดรูปแบบของส่วนที่ล้อมรอบไว้ แทนที่จะสร้างกรอบข้อความใหม่จากสตริงธรรมดา

ตัวอย่างต่อไปนี้ทำให้รูปแบบการสะกดสอดคล้องกันแล้วแทนที่ป้ายเวอร์ชัน:

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

หากการจับคู่หนึ่งครอบคลุมส่วนที่มีการจัดรูปแบบต่างกัน โปรดตรวจสอบผลลัพธ์เพื่อยืนยันว่าการจัดรูปแบบใดควรนำไปใช้กับข้อความที่แทนที่

## **แทนที่ข้อความทั่วทั้งงานนำเสนอ**

ใช้ [Presentation.replaceText](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/presentation/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) และ [Presentation.replaceRegex](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/presentation/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) เพื่อดำเนินการเดียวกันทั่วงานนำเสนอ ซึ่งมีประโยชน์สำหรับการทำความสะอาดเทมเพลต, การอัปเดตคำศัพท์, และการลบข้อมูล

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

## **จัดกลุ่มการจับคู่เพื่อรายงาน**

เนื่องจากผลลัพธ์ที่เก็บรวบรวมทุกรายการจะมีหมายเลขสไลด์และกรอบข้อความ แอปพลิเคชันจึงสามารถจัดกลุ่มการจับคู่เพื่อการตรวจสอบ, รายงาน, หรือกระบวนการทบทวน ตัวอย่างต่อไปนี้จัดกลุ่มผลลัพธ์โดยสไลด์ก่อน แล้วจึงตามด้วยกรอบข้อความ:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

function getSlideNumber(textFrame) {
    const parentShape = textFrame.getParentShape();
    const parentCell = textFrame.getParentCell();
    let parentSlide = textFrame.getSlide();
    if (parentShape !== null) {
        parentSlide = parentShape.getSlide();
    } else if (parentCell !== null) {
        parentSlide = parentCell.getSlide();
    }

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

**ฉันจะค้นหาเพียงกล่องข้อความเดียวแทนที่จะค้นหาทั้งงานนำเสนอได้อย่างไร?**

รับกรอบข้อความของรูปร่างและเรียกใช้ [TextFrame.highlightText](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/textframe/#highlightText-java.lang.String-java.awt.Color-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-), [TextFrame.highlightRegex](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/textframe/#highlightRegex-java.util.regex.Pattern-java.awt.Color-com.aspose.slides.IFindResultCallback-), [TextFrame.replaceText](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/textframe/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-), หรือ [TextFrame.replaceRegex](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/textframe/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) บนกรอบข้อความนั้น เมธอดระดับงานนำเสนอจะดำเนินการกับกรอบข้อความทั้งหมดที่เกี่ยวข้องแทน

**ฉันจะจับคู่คำเต็มพร้อมการใช้ตัวพิมพ์ใหญ่‑เล็กที่ถูกต้องได้อย่างไร?**

ตั้งค่า [TextSearchOptions.setWholeWordsOnly](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/textsearchoptions/#setWholeWordsOnly-boolean-) และ [TextSearchOptions.setCaseSensitive](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/textsearchoptions/#setCaseSensitive-boolean-) ให้เป็น `true` แล้วส่งตัวเลือกเหล่านั้นไปยังเมธอดไฮไลท์หรือแทนที่ข้อความตามตัวอักษร สำหรับ regular expression ให้กำหนดขอบเขตคำและความไวต่อรูปพิมพ์ใน `Pattern` ของ Java เอง

**การค้นหาและแทนที่สามารถรวมข้อความในโน้ตของสไลด์ได้หรือไม่?**

ได้ กำหนดค่า [TextSearchOptions.setIncludeNotes](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/textsearchoptions/#setIncludeNotes-boolean-) ให้เป็น `true` เมื่อใช้เมธอดระดับงานนำเสนอแบบข้อความตามตัวอักษร Callback implementation ด้านบนจะแปลงการจับคู่ในสไลด์โน้ตกลับไปยังหมายเลขสไลด์หลัก

**ฉันจะสร้างรายงานโดยไม่ต้องสแกนงานนำเสนอซ้ำได้อย่างไร?**

ส่ง proxy ของ Java result‑callback ไปยังการไฮไลท์หรือการแทนที่ Callback จะรับทุกการจับคู่ขณะดำเนินการ ดังนั้นแอปพลิเคชันสามารถเก็บข้อความต้นฉบับ, ข้อความที่จับคู่, ตำแหน่ง, กรอบข้อความ, และหมายเลขสไลด์ที่สกัดมาไว้สำหรับการจัดกลุ่มหรือส่งออกในภายหลัง

**การแทนที่ข้อความทำให้รูปแบบของข้อความคงเดิมหรือไม่?**

[TextFrame.replaceText](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/textframe/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) และ [TextFrame.replaceRegex](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/textframe/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) ปรับข้อความที่จับคู่ภายในกรอบข้อความที่มีอยู่และรักษาการจัดรูปแบบของส่วนโดยรอบ หากการจับคู่ครอบคลุมส่วนที่มีการจัดรูปแบบต่างกัน ให้ตรวจสอบผลลัพธ์เพื่อให้แน่ใจว่าการแทนที่ใช้สไตล์ที่ต้องการ