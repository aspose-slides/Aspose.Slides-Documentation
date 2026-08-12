---
title: ค้นหาและแทนที่ข้อความในงานนำเสนอ PowerPoint ด้วย Java
linktitle: ค้นหาและแทนที่ข้อความ
type: docs
weight: 55
url: /th/java/search-and-replace-text/
keywords:
- ค้นหาข้อความ
- เน้นข้อความ
- แทนที่ข้อความ
- นิพจน์ทั่วไป
- การเรียกกลับผลลัพธ์
- กรอบข้อความ
- รายงานการตรวจสอบ
- PowerPoint
- OpenDocument
- งานนำเสนอ
- Java
- Aspose.Slides
description: "ค้นหา, เน้นสี, และแทนที่ข้อความในงานนำเสนอ PowerPoint พร้อมเก็บการจับคู่ทั้งหมดด้วย Aspose.Slides for Java."
---
## **ภาพรวม**

Aspose.Slides for Java สามารถค้นหา, เน้นสี, และแทนที่ข้อความในกรอบข้อความแต่ละกรอบหรือทั่วทั้งงานนำเสนอได้ การดำเนินการแต่ละอย่างยังสามารถแจ้งให้แอปพลิเคชันทราบเกี่ยวกับการจับคู่แต่ละครั้งผ่านการเรียกกลับผลลัพธ์ ทำให้สามารถอัปเดตงานนำเสนอและสร้างบันทึกการตรวจสอบที่มีข้อความที่ตรงกัน, บริบท, ตำแหน่ง, กรอบข้อความ, และหมายเลขสไลด์ได้พร้อมกัน

ความสามารถเหล่านี้มีประโยชน์สำหรับการตรวจสอบ, การลบข้อมูล, การตรวจสอบคำศัพท์, การทำความสะอาดเทมเพลต, และกระบวนการทำรายงานอัตโนมัติ

ในตัวอย่างแรกด้านล่าง เราใช้ไฟล์ชื่อ “sample.pptx” ซึ่งมีกล่องข้อความเดียวบนสไลด์แรกพร้อมข้อความต่อไปนี้:

![ข้อความตัวอย่าง](sample_text.png)

## **เลือกขอบเขตการค้นหา**

ใช้เมธอดบน [ITextFrame](https://reference.aspose.com/slides/th/java/com.aspose.slides/itextframe/) เพื่อจำกัดการดำเนินการให้กับกรอบข้อความหนึ่ง ใช้เมธอดบน [Presentation](https://reference.aspose.com/slides/th/java/com.aspose.slides/presentation/) เพื่อประมวลผลข้อความทั้งหมดที่เกี่ยวข้องในงานนำเสนอ

| การดำเนินการ | กรอบข้อความหนึ่ง | งานนำเสนอทั้งหมด |
|---|---|---|
| เน้นข้อความตามตัวอักษร | [ITextFrame.highlightText](https://reference.aspose.com/slides/th/java/com.aspose.slides/itextframe/#highlightText-java.lang.String-java.awt.Color-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) | [Presentation.highlightText](https://reference.aspose.com/slides/th/java/com.aspose.slides/presentation/#highlightText-java.lang.String-java.awt.Color-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) |
| เน้นการจับคู่แบบ regular‑expression | [ITextFrame.highlightRegex](https://reference.aspose.com/slides/th/java/com.aspose.slides/itextframe/#highlightRegex-java.util.regex.Pattern-java.awt.Color-com.aspose.slides.IFindResultCallback-) | [Presentation.highlightRegex](https://reference.aspose.com/slides/th/java/com.aspose.slides/presentation/#highlightRegex-java.util.regex.Pattern-java.awt.Color-com.aspose.slides.IFindResultCallback-) |
| แทนที่ข้อความตามตัวอักษร | [ITextFrame.replaceText](https://reference.aspose.com/slides/th/java/com.aspose.slides/itextframe/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) | [Presentation.replaceText](https://reference.aspose.com/slides/th/java/com.aspose.slides/presentation/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) |
| แทนที่การจับคู่แบบ regular‑expression | [ITextFrame.replaceRegex](https://reference.aspose.com/slides/th/java/com.aspose.slides/itextframe/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) | [Presentation.replaceRegex](https://reference.aspose.com/slides/th/java/com.aspose.slides/presentation/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) |

## **กำหนดการจับคู่ข้อความ**

สำหรับการดำเนินการแบบข้อความตามตัวอักษร ใช้ [TextSearchOptions](https://reference.aspose.com/slides/th/java/com.aspose.slides/textsearchoptions/) เพื่อควบคุมการจับคู่:

- [TextSearchOptions.setWholeWordsOnly](https://reference.aspose.com/slides/th/java/com.aspose.slides/textsearchoptions/#setWholeWordsOnly-boolean-) จำกัดการจับคู่ให้เป็นคำเต็มเท่านั้น
- [TextSearchOptions.setCaseSensitive](https://reference.aspose.com/slides/th/java/com.aspose.slides/textsearchoptions/#setCaseSensitive-boolean-) ควบคุมว่าตัวอักษรต้องตรงตามกรณีหรือไม่
- [TextSearchOptions.setIncludeNotes](https://reference.aspose.com/slides/th/java/com.aspose.slides/textsearchoptions/#setIncludeNotes-boolean-) รวมบันทึกสไลด์ในการค้นหา, แทนที่, และการเน้นระดับงานนำเสนอ

การดำเนินการแบบ regular‑expression ใช้ `Pattern` ของ Java ดังนั้นกฎการจับคู่เช่นความไวต่อกรณีและขอบเขตคำจะกำหนดโดยนิพจน์และแฟล็กของมันเอง

## **รวบรวมข้อมูลการจับคู่ด้วยการเรียกกลับ**

ใช้การสร้าง [IFindResultCallback](https://reference.aspose.com/slides/th/java/com.aspose.slides/ifindresultcallback/) เพื่อรับการแจ้งเตือนสำหรับการจับคู่แต่ละครั้ง วิธี [IFindResultCallback.foundResult](https://reference.aspose.com/slides/th/java/com.aspose.slides/ifindresultcallback/#foundResult-com.aspose.slides.ITextFrame-java.lang.String-java.lang.String-int-) จะให้กรอบข้อความที่เกี่ยวข้อง, ข้อความต้นฉบับ, ข้อความที่จับคู่, และตำแหน่งของการจับคู่

การเรียกกลับจะไม่ได้รับหมายเลขสไลด์โดยตรง ตัวอย่างการทำงานด้านล่างดึงหมายเลขสไลด์จากสไลด์แม่และยังจัดการข้อความที่พบในบันทึกสไลด์ด้วย `Integer` ที่เป็นค่า nullable ทำให้โมเดลผลลัพธ์เดียวสามารถแสดงข้อความที่เกี่ยวข้องกับประเภทสไลด์อื่นได้เช่นกัน

```java
import com.aspose.slides.*;
import java.util.ArrayList;
import java.util.List;

final class TextMatch {
    private final ITextFrame textFrame;
    private final String sourceText;
    private final String foundText;
    private final int textPosition;
    private final Integer slideNumber;

    TextMatch(ITextFrame textFrame, String sourceText, String foundText, int textPosition, Integer slideNumber) {
        this.textFrame = textFrame;
        this.sourceText = sourceText;
        this.foundText = foundText;
        this.textPosition = textPosition;
        this.slideNumber = slideNumber;
    }

    ITextFrame getTextFrame() {
        return textFrame;
    }

    String getSourceText() {
        return sourceText;
    }

    String getFoundText() {
        return foundText;
    }

    int getTextPosition() {
        return textPosition;
    }

    Integer getSlideNumber() {
        return slideNumber;
    }
}

final class TextSearchCallback implements IFindResultCallback {
    private final List<TextMatch> results = new ArrayList<TextMatch>();

    List<TextMatch> getResults() {
        return results;
    }

    @Override
    public void foundResult(ITextFrame textFrame, String sourceText, String foundText, int textPosition) {
        Integer slideNumber = getSlideNumber(textFrame);
        TextMatch result = new TextMatch(textFrame, sourceText, foundText, textPosition, slideNumber);
        results.add(result);
    }

    private static Integer getSlideNumber(ITextFrame textFrame) {
        if (!(textFrame instanceof TextFrame)) {
            return null;
        }

        IBaseSlide parentSlide = ((TextFrame) textFrame).getSlide();

        if (parentSlide instanceof ISlide) {
            return ((ISlide) parentSlide).getSlideNumber();
        }

        if (parentSlide instanceof INotesSlide) {
            return ((INotesSlide) parentSlide).getParentSlide().getSlideNumber();
        }

        return null;
    }
}
```

สำหรับการดำเนินการแทนที่ `foundText` จะมีข้อความที่ตรงกันเดิม ดังนั้นการเรียกกลับสามารถบันทึกได้ว่าคำใดบ้างที่ถูกแทนที่

## **เน้นข้อความ**

ใช้เมธอด [ITextFrame.highlightText](https://reference.aspose.com/slides/th/java/com.aspose.slides/itextframe/#highlightText-java.lang.String-java.awt.Color-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) เพื่อเน้นการจับคู่ข้อความตามตัวอักษรในกรอบข้อความ ส่งผ่าน [TextSearchOptions](https://reference.aspose.com/slides/th/java/com.aspose.slides/textsearchoptions/) เพื่อควบคุมการค้นหาและส่งการเรียกกลับเพื่อรวบรวมรายละเอียดการจับคู่

ตัวอย่างโค้ดด้านล่างเน้นทุกการเกิดของอักขระ **"try"** แล้วจึงเน้นเฉพาะคำเต็ม **"to"** ทั้งสองการค้นหาจะรายงานการจับคู่ให้กับการเรียกกลับเดียวกัน

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = (IAutoShape) slide.getShapes().get_Item(0);
    TextSearchCallback callback = new TextSearchCallback();

    TextSearchOptions substringSearchOptions = new TextSearchOptions();
    substringSearchOptions.setCaseSensitive(false);
    Color substringHighlightColor = new Color(173, 216, 230);

    // เน้นทุกการปรากฏของ "try" ในกรอบข้อความ.
    shape.getTextFrame().highlightText("try", substringHighlightColor, substringSearchOptions, callback);

    TextSearchOptions wholeWordSearchOptions = new TextSearchOptions();
    wholeWordSearchOptions.setWholeWordsOnly(true);
    wholeWordSearchOptions.setCaseSensitive(false);
    Color wholeWordHighlightColor = new Color(238, 130, 238);

    // เน้นเฉพาะคำเต็ม "to" เท่านั้น.
    shape.getTextFrame().highlightText("to", wholeWordHighlightColor, wholeWordSearchOptions, callback);

    for (TextMatch result : callback.getResults()) {
        System.out.println("Found '" + result.getFoundText() + "' at position " +
                result.getTextPosition() + " on slide " + result.getSlideNumber() + ".");
    }

    presentation.save("highlighted_text.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

ผลลัพธ์:

![ข้อความที่เน้นสี](highlighted_text.png)

## **เน้นข้อความโดยใช้ Regular Expressions**

เมธอด [ITextFrame.highlightRegex](https://reference.aspose.com/slides/th/java/com.aspose.slides/itextframe/#highlightRegex-java.util.regex.Pattern-java.awt.Color-com.aspose.slides.IFindResultCallback-) จะเน้นข้อความที่ตรงกับนิพจน์ประจำในกรอบข้อความ

โค้ดต่อไปนี้จะเน้นทุกคำที่มีความยาวเจ็ดอักขระหรือมากกว่าและรวบรวมการจับคู่แต่ละครั้ง

```java
import com.aspose.slides.*;
import java.awt.Color;
import java.util.regex.Pattern;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = (IAutoShape) slide.getShapes().get_Item(0);
    TextSearchCallback callback = new TextSearchCallback();
    Pattern regex = Pattern.compile("\\b[^\\s]{7,}\\b");

    shape.getTextFrame().highlightRegex(regex, Color.YELLOW, callback);

    presentation.save("highlighted_text_using_regex.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

ผลลัพธ์:

![ข้อความที่เน้นสีโดยใช้ regular expression](highlighted_text_using_regex.png)

## **เน้นข้อความทั่วทั้งงานนำเสนอ**

ใช้เมธอด [Presentation.highlightText](https://reference.aspose.com/slides/th/java/com.aspose.slides/presentation/#highlightText-java.lang.String-java.awt.Color-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) และ [Presentation.highlightRegex](https://reference.aspose.com/slides/th/java/com.aspose.slides/presentation/#highlightRegex-java.util.regex.Pattern-java.awt.Color-com.aspose.slides.IFindResultCallback-) เพื่อค้นหาทุกกรอบข้อความที่เกี่ยวข้องในงานนำเสนอ ตัวอย่างต่อไปนี้จะเน้นคำตามตัวอักษรและที่อยู่อีเมลทั้งหมดโดยแยกคอลเลกชันผลลัพธ์สำหรับการค้นหาแต่ละรายการ

```java
import com.aspose.slides.*;
import java.awt.Color;
import java.util.regex.Pattern;

Presentation presentation = new Presentation("presentation.pptx");
try {
    TextSearchCallback termCallback = new TextSearchCallback();
    TextSearchOptions searchOptions = new TextSearchOptions();
    searchOptions.setWholeWordsOnly(true);
    searchOptions.setCaseSensitive(false);

    presentation.highlightText("confidential", Color.ORANGE, searchOptions, termCallback);

    TextSearchCallback emailCallback = new TextSearchCallback();
    Pattern emailRegex = Pattern.compile(
            "\\b[A-Z0-9._%+-]+@[A-Z0-9.-]+\\.[A-Z]{2,}\\b",
            Pattern.CASE_INSENSITIVE);

    presentation.highlightRegex(emailRegex, Color.YELLOW, emailCallback);
    presentation.save("highlighted_presentation.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **แทนที่ข้อความในกรอบข้อความ**

ใช้เมธอด [ITextFrame.replaceText](https://reference.aspose.com/slides/th/java/com.aspose.slides/itextframe/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) สำหรับข้อความตามตัวอักษรและ [ITextFrame.replaceRegex](https://reference.aspose.com/slides/th/java/com.aspose.slides/itextframe/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) สำหรับการแทนที่โดยใช้รูปแบบ เมธอดเหล่านี้จะอัปเดตข้อความที่จับคู่ภายในกรอบข้อความที่มีอยู่ซึ่งจะรักษาการฟอร์แมตของส่วนที่อยู่รอบ ๆ แทนที่จะสร้างกรอบข้อความใหม่จากสตริงธรรมดา

ตัวอย่างต่อไปนี้ทำให้รูปแบบการสะกดมาตรฐานและจากนั้นแทนที่ป้ายกำกับเวอร์ชันเดียวกัน การเรียกกลับเดียวกันบันทึกคำเดิมที่จับได้จากทั้งสองการดำเนินการ

```java
import com.aspose.slides.*;
import java.util.regex.Pattern;

Presentation presentation = new Presentation("presentation.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = (IAutoShape) slide.getShapes().get_Item(0);
    TextSearchCallback callback = new TextSearchCallback();
    TextSearchOptions searchOptions = new TextSearchOptions();
    searchOptions.setWholeWordsOnly(true);
    searchOptions.setCaseSensitive(false);

    shape.getTextFrame().replaceText("colour", "color", searchOptions, callback);

    Pattern versionRegex = Pattern.compile("\\bv\\d+(?:\\.\\d+)*\\b", Pattern.CASE_INSENSITIVE);
    shape.getTextFrame().replaceRegex(versionRegex, "current version", callback);

    presentation.save("updated_text_frame.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

หากการจับคู่หนึ่งครอบคลุมส่วนที่มีฟอร์แมตแตกต่างกัน ให้ตรวจสอบผลลัพธ์เพื่อยืนยันว่าฟอร์แมตที่ควรใช้กับข้อความที่แทนที่เป็นแบบใด

## **แทนที่ข้อความทั่วทั้งงานนำเสนอ**

ใช้เมธอด [Presentation.replaceText](https://reference.aspose.com/slides/th/java/com.aspose.slides/presentation/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) และ [Presentation.replaceRegex](https://reference.aspose.com/slides/th/java/com.aspose.slides/presentation/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) เพื่อใช้การดำเนินการเดียวกันทั่วทั้งงานนำเสนอ สิ่งนี้มีประโยชน์สำหรับการทำความสะอาดเทมเพลต, การอัปเดตคำศัพท์, และการลบข้อมูล

```java
import com.aspose.slides.*;
import java.util.regex.Pattern;

Presentation presentation = new Presentation("presentation.pptx");
try {
    TextSearchCallback callback = new TextSearchCallback();
    TextSearchOptions searchOptions = new TextSearchOptions();
    searchOptions.setWholeWordsOnly(true);
    searchOptions.setCaseSensitive(true);

    presentation.replaceText("Contoso", "Example Corp", searchOptions, callback);

    Pattern accountNumberRegex = Pattern.compile("\\bACCT-\\d{6}\\b");
    presentation.replaceRegex(accountNumberRegex, "ACCT-REDACTED", callback);

    presentation.save("updated_presentation.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **จัดกลุ่มการจับคู่สำหรับการรายงาน**

เนื่องจากผลลัพธ์แต่ละรายการเก็บหมายเลขสไลด์และกรอบข้อความไว้ แอปพลิเคชันจึงสามารถจัดกลุ่มการจับคู่สำหรับการตรวจสอบ, การรายงาน, หรือกระบวนการทบทวน ตัวอย่างต่อไปนี้จัดกลุ่มผลลัพธ์ที่รวบรวมไว้ก่อนหน้าโดยแรกตามสไลด์และต่อด้วยกรอบข้อความ

```java
import com.aspose.slides.ITextFrame;
import java.util.LinkedHashMap;
import java.util.List;
import java.util.Map;

Map<Integer, Map<ITextFrame, List<TextMatch>>> matchesBySlide =
        new LinkedHashMap<Integer, Map<ITextFrame, List<TextMatch>>>();

for (TextMatch result : callback.getResults()) {
    Integer slideNumber = result.getSlideNumber();
    Map<ITextFrame, List<TextMatch>> matchesByTextFrame = matchesBySlide.get(slideNumber);

    if (matchesByTextFrame == null) {
        matchesByTextFrame = new LinkedHashMap<ITextFrame, List<TextMatch>>();
        matchesBySlide.put(slideNumber, matchesByTextFrame);
    }

    ITextFrame textFrame = result.getTextFrame();
    List<TextMatch> textFrameMatches = matchesByTextFrame.get(textFrame);

    if (textFrameMatches == null) {
        textFrameMatches = new java.util.ArrayList<TextMatch>();
        matchesByTextFrame.put(textFrame, textFrameMatches);
    }

    textFrameMatches.add(result);
}

for (Map.Entry<Integer, Map<ITextFrame, List<TextMatch>>> slideEntry : matchesBySlide.entrySet()) {
    String slideLabel = slideEntry.getKey() == null ? "Other" : slideEntry.getKey().toString();
    System.out.println("Slide: " + slideLabel);

    for (Map.Entry<ITextFrame, List<TextMatch>> textFrameEntry : slideEntry.getValue().entrySet()) {
        System.out.println("  Text frame: " + textFrameEntry.getKey().getText());

        for (TextMatch result : textFrameEntry.getValue()) {
            System.out.println("    '" + result.getFoundText() + "' at position " +
                    result.getTextPosition() + "; context: '" + result.getSourceText() + "'");
        }
    }
}
```

## **คำถามที่พบบ่อย**

**ฉันจะค้นหาเพียงกล่องข้อความเดียวแทนการค้นหาทั้งงานนำเสนอได้อย่างไร?**

รับกรอบข้อความของ shape แล้วเรียก [ITextFrame.highlightText](https://reference.aspose.com/slides/th/java/com.aspose.slides/itextframe/#highlightText-java.lang.String-java.awt.Color-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-), [ITextFrame.highlightRegex](https://reference.aspose.com/slides/th/java/com.aspose.slides/itextframe/#highlightRegex-java.util.regex.Pattern-java.awt.Color-com.aspose.slides.IFindResultCallback-), [ITextFrame.replaceText](https://reference.aspose.com/slides/th/java/com.aspose.slides/itextframe/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-), หรือ [ITextFrame.replaceRegex](https://reference.aspose.com/slides/th/java/com.aspose.slides/itextframe/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) บนกรอบข้อความนั้น เมธอดระดับงานนำเสนอจะประมวลผลกรอบข้อความทั้งหมดที่เกี่ยวข้องแทน

**ฉันจะจับคู่คำเต็มพร้อมการใช้ตัวพิมพ์ใหญ่‑เล็กที่ถูกต้องได้อย่างไร?**

ตั้งค่า [TextSearchOptions.setWholeWordsOnly](https://reference.aspose.com/slides/th/java/com.aspose.slides/textsearchoptions/#setWholeWordsOnly-boolean-) และ [TextSearchOptions.setCaseSensitive](https://reference.aspose.com/slides/th/java/com.aspose.slides/textsearchoptions/#setCaseSensitive-boolean-) เป็น `true` แล้วส่งตัวเลือกไปยังเมธอดเน้นหรือแทนที่ข้อความตามตัวอักษร สำหรับ regular expressions ให้กำหนดขอบเขตคำและความไวต่อกรณีใน `Pattern` ของ Java เอง

**การค้นหาและการแทนที่สามารถรวมข้อความในบันทึกสไลด์ได้หรือไม่?**

ได้ ตั้งค่า [TextSearchOptions.setIncludeNotes](https://reference.aspose.com/slides/th/java/com.aspose.slides/textsearchoptions/#setIncludeNotes-boolean-) เป็น `true` เมื่อใช้การดำเนินการข้อความตามตัวอักษรระดับงานนำเสนอ การทำงานของการเรียกกลับที่แสดงด้านบนจะแปลงการจับคู่ในสไลด์บันทึกกลับไปยังหมายเลขสไลด์แม่ของมัน

**ฉันจะสร้างรายงานโดยไม่ต้องสแกนงานนำเสนอครั้งที่สองได้อย่างไร?**

ส่งการทำงานของ [IFindResultCallback](https://reference.aspose.com/slides/th/java/com.aspose.slides/ifindresultcallback/) ไปยังการเน้นหรือการแทนที่ การเรียกกลับจะรับทุกการจับคู่ขณะดำเนินการดังนั้นแอปพลิเคชันจึงสามารถเก็บข้อความต้นฉบับ, ข้อความที่จับคู่, ตำแหน่ง, กรอบข้อความ, และหมายเลขสไลด์ที่ได้เพื่อใช้ในการจัดกลุ่มหรือส่งออกในภายหลังได้

**การแทนที่ข้อความจะรักษาฟอร์แมตของมันไว้หรือไม่?**

[ITextFrame.replaceText](https://reference.aspose.com/slides/th/java/com.aspose.slides/itextframe/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) และ [ITextFrame.replaceRegex](https://reference.aspose.com/slides/th/java/com.aspose.slides/itextframe/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) ปรับเปลี่ยนข้อความที่จับคู่ภายในกรอบข้อความที่มีอยู่และรักษาฟอร์แมตของส่วนโดยรอบ หากการจับคู่อยู่บนส่วนที่มีฟอร์แมตแตกต่างกัน ให้ตรวจสอบผลลัพธ์เพื่อให้แน่ใจว่าการแทนที่ใช้สไตล์ที่ต้องการ