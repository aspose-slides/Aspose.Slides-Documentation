---
title: ค้นหาและแทนที่ข้อความในงานนำเสนอ PowerPoint บน Android
linktitle: ค้นหาและแทนที่ข้อความ
type: docs
weight: 55
url: /th/androidjava/search-and-replace-text/
keywords:
- ค้นหาข้อความ
- เน้นข้อความ
- แทนที่ข้อความ
- นิพจน์ปกติ
- callback ผลลัพธ์
- เฟรมข้อความ
- รายงานการตรวจสอบ
- PowerPoint
- OpenDocument
- งานนำเสนอ
- Android
- Java
- Aspose.Slides
description: "ค้นหา, เน้นและแทนที่ข้อความในงานนำเสนอ PowerPoint พร้อมเก็บบันทึกการจับคู่ทุกครั้งด้วย Aspose.Slides สำหรับ Android ผ่าน Java."
---
## **ภาพรวม**

Aspose.Slides for Android via Java สามารถค้นหา, เน้นสี, และแทนที่ข้อความในเฟรมข้อความเดี่ยวหรือทั่วทั้งงานนำเสนอได้ แต่ละการดำเนินการยังสามารถแจ้งแอปพลิเคชันเกี่ยวกับทุกการจับคู่ผ่านผลลัพธ์คอลแบ็ค ซึ่งทำให้สามารถอัปเดตงานนำเสนอและสร้างเส้นทางการตรวจสอบที่มีข้อความที่จับคู่, บริบท, ตำแหน่ง, เฟรมข้อความ, และหมายเลขสไลด์พร้อมกัน

ความสามารถเหล่านี้มีประโยชน์สำหรับการตรวจทาน, การลบข้อมูล, การตรวจสอบศัพท์, การทำความสะอาดเทมเพลต, และกระบวนการทำรายงานอัตโนมัติ

ในตัวอย่างแรกด้านล่าง เราใช้ไฟล์ชื่อ "sample.pptx" ซึ่งมีกล่องข้อความเดี่ยวบนสไลด์แรกพร้อมข้อความต่อไปนี้:

![ข้อความตัวอย่าง](sample_text.png)

## **เลือกขอบเขตการค้นหา**

ใช้เมธอดบน [ITextFrame](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/itextframe/) เพื่อจำกัดการดำเนินการให้กับเฟรมข้อความหนึ่งเดียว ใช้เมธอดบน [IPresentation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ipresentation/) เพื่อประมวลผลข้อความทั้งหมดที่เกี่ยวข้องในงานนำเสนอ

| การดำเนินการ | เฟรมข้อความเดียว | งานนำเสนอทั้งหมด |
|---|---|---|
| เน้นข้อความตามตัวอักษร | [ITextFrame.highlightText](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/itextframe/#highlightText-java.lang.String-java.lang.Integer-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) | [IPresentation.highlightText](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ipresentation/#highlightText-java.lang.String-java.lang.Integer-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) |
| เน้นการจับคู่แบบ regular‑expression | [ITextFrame.highlightRegex](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/itextframe/#highlightRegex-java.util.regex.Pattern-java.lang.Integer-com.aspose.slides.IFindResultCallback-) | [IPresentation.highlightRegex](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ipresentation/#highlightRegex-java.util.regex.Pattern-java.lang.Integer-com.aspose.slides.IFindResultCallback-) |
| แทนที่ข้อความตามตัวอักษร | [ITextFrame.replaceText](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/itextframe/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) | [IPresentation.replaceText](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ipresentation/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) |
| แทนที่การจับคู่แบบ regular‑expression | [ITextFrame.replaceRegex](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/itextframe/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) | [IPresentation.replaceRegex](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ipresentation/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) |

## **กำหนดการจับข้อความ**

สำหรับการดำเนินการข้อความตามตัวอักษร ใช้ [TextSearchOptions](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/textsearchoptions/) เพื่อควบคุมการจับคู่:

- [TextSearchOptions.setWholeWordsOnly](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/textsearchoptions/#setWholeWordsOnly-boolean-) จำกัดการจับคู่ให้เป็นคำเต็ม
- [TextSearchOptions.setCaseSensitive](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/textsearchoptions/#setCaseSensitive-boolean-) ควบคุมว่าต้องตรงตามตัวพิมพ์ใหญ่‑เล็กหรือไม่
- [TextSearchOptions.setIncludeNotes](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/textsearchoptions/#setIncludeNotes-boolean-) รวมโน้ตสไลด์ในการค้นหา, แทนที่, และเน้นบนระดับงานนำเสนอ

การดำเนินการแบบ regular‑expression ใช้ `Pattern` ของ Java ดังนั้นกฎการจับคู่เช่นการแยกตัวพิมพ์ใหญ่‑เล็กและขอบเขตคำจะถูกกำหนดโดยนิพจน์และแฟล็กของมัน

## **เก็บข้อมูลการจับคู่ด้วยคอลแบ็ค**

ใช้ [IFindResultCallback](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ifindresultcallback/) เพื่อรับการแจ้งเตือนสำหรับแต่ละการจับคู่ เมธอด [IFindResultCallback.foundResult](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ifindresultcallback/#foundResult-com.aspose.slides.ITextFrame-java.lang.String-java.lang.String-int-) ให้ข้อมูลเฟรมข้อความที่เกี่ยวข้อง, ข้อความต้นฉบับ, ข้อความที่จับคู่, และตำแหน่งการจับคู่

คอลแบ็คไม่รับหมายเลขสไลด์โดยตรง การทำงานด้านล่างสืบค้นหมายเลขจากสไลด์พาเรนท์และจัดการข้อความที่พบในโน้ตสไลด์ `Integer` ที่เป็น nullable ทำให้โมเดลผลลัพธ์เดียวกันสามารถแทนข้อความที่เชื่อมโยงกับประเภทสไลด์อื่นได้

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

สำหรับการดำเนินการแทนที่, `foundText` จะมีข้อความที่จับคู่ดั้งเดิม ดังนั้นคอลแบ็คสามารถบันทึกได้อย่างแม่นยำว่าคำใดถูกแทนที่

## **เน้นข้อความ**

ใช้เมธอด [ITextFrame.highlightText](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/itextframe/#highlightText-java.lang.String-java.lang.Integer-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) เพื่อเน้นการจับคู่ข้อความตามตัวอักษรในเฟรมข้อความ ส่ง [TextSearchOptions](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/textsearchoptions/) เพื่อควบคุมการค้นหาและคอลแบ็คเพื่อเก็บรายละเอียดการจับคู่

ตัวอย่างโค้ดด้านล่างเน้นทุกการปรากฏของอักขระ **"try"** แล้วต่อมเน้นเฉพาะคำเต็ม **"to"** ทั้งสองการค้นหารายงานการจับคู่ไปยังคอลแบ็คเดียวกัน

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = (IAutoShape) slide.getShapes().get_Item(0);
    TextSearchCallback callback = new TextSearchCallback();

    TextSearchOptions substringSearchOptions = new TextSearchOptions();
    substringSearchOptions.setCaseSensitive(false);
    int substringHighlightColor = Color.rgb(173, 216, 230);

    // เน้นทุกการปรากฏของ "try" ในเฟรมข้อความ.
    shape.getTextFrame().highlightText("try", substringHighlightColor, substringSearchOptions, callback);

    TextSearchOptions wholeWordSearchOptions = new TextSearchOptions();
    wholeWordSearchOptions.setWholeWordsOnly(true);
    wholeWordSearchOptions.setCaseSensitive(false);
    int wholeWordHighlightColor = Color.rgb(238, 130, 238);

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

![ข้อความที่ถูกเน้น](highlighted_text.png)

## **เน้นข้อความโดยใช้ Regular Expressions**

เมธอด [ITextFrame.highlightRegex](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/itextframe/#highlightRegex-java.util.regex.Pattern-java.lang.Integer-com.aspose.slides.IFindResultCallback-) จะเน้นข้อความที่ตรงกับนิพจน์ regular expression ในเฟรมข้อความ

โค้ดต่อไปนี้จะเน้นทุกคำที่มีอักขระเจ็ดตัวหรือมากกว่าและเก็บข้อมูลการจับคู่แต่ละรายการ:

```java
import com.aspose.slides.*;
import android.graphics.Color;
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

![ข้อความที่ถูกเน้นโดยใช้ regular expression](highlighted_text_using_regex.png)

## **เน้นข้อความทั่วทั้งงานนำเสนอ**

ใช้ [IPresentation.highlightText](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ipresentation/#highlightText-java.lang.String-java.lang.Integer-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) และ [IPresentation.highlightRegex](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ipresentation/#highlightRegex-java.util.regex.Pattern-java.lang.Integer-com.aspose.slides.IFindResultCallback-) เพื่อค้นหาเฟรมข้อความทั้งหมดที่เกี่ยวข้องในงานนำเสนอ ตัวอย่างต่อไปนี้จะเน้นคำตามตัวอักษรและที่อยู่อีเมลทั้งหมดโดยแยกผลลัพธ์สำหรับการค้นหาแต่ละแบบ

```java
import com.aspose.slides.*;
import android.graphics.Color;
import java.util.regex.Pattern;

Presentation presentation = new Presentation("presentation.pptx");
try {
    TextSearchCallback termCallback = new TextSearchCallback();
    TextSearchOptions searchOptions = new TextSearchOptions();
    searchOptions.setWholeWordsOnly(true);
    searchOptions.setCaseSensitive(false);

    int termHighlightColor = Color.rgb(255, 165, 0);
    presentation.highlightText("confidential", termHighlightColor, searchOptions, termCallback);

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

## **แทนที่ข้อความในเฟรมข้อความ**

ใช้ [ITextFrame.replaceText](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/itextframe/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) สำหรับข้อความตามตัวอักษรและ [ITextFrame.replaceRegex](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/itextframe/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) สำหรับการแทนที่แบบรูปแบบ วิธีนี้จะอัปเดตข้อความที่จับคู่ภายในเฟรมข้อความที่มีอยู่ซึ่งรักษาการฟอร์แมตของส่วนที่อยู่รอบ ๆ แทนการสร้างเฟรมข้อความใหม่จากสตริงธรรมดา

ตัวอย่างต่อไปนี้ทำให้รูปแบบการสะกดสอดคล้องกันแล้วแทนที่ป้ายกำกับเวอร์ชัน คอลแบ็คเดียวกันบันทึกคำเดิมที่จับคู่โดยทั้งสองการดำเนินการ

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

หากการจับคู่หนึ่งครอบคลุมส่วนที่มีการฟอร์แมตต่างกัน โปรดตรวจสอบผลลัพธ์เพื่อยืนยันว่าฟอร์แมตใดควรใช้กับข้อความที่แทนที่

## **แทนที่ข้อความทั่วทั้งงานนำเสนอ**

ใช้ [IPresentation.replaceText](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ipresentation/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) และ [IPresentation.replaceRegex](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ipresentation/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) เพื่อทำการดำเนินการเดียวกันทั่วทั้งงานนำเสนอ เหมาะสำหรับการทำความสะอาดเทมเพลต, การอัปเดตศัพท์, และการลบข้อมูล

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

เนื่องจากผลลัพธ์แต่ละรายการบันทึกหมายเลขสไลด์และเฟรมข้อความ แอปพลิเคชันสามารถจัดกลุ่มการจับคู่เพื่อการตรวจสอบ, รายงาน, หรือกระบวนการตรวจทาน ตัวอย่างต่อไปนี้จัดกลุ่มผลลัพธ์ที่เก็บไว้ตามสไลด์ก่อนแล้วตามเฟรมข้อความ:

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

**ฉันจะค้นหาเพียงกล่องข้อความเดียวแทนที่จะค้นทั้งงานนำเสนอได้อย่างไร?**

รับเฟรมข้อความของ shape แล้วเรียก [ITextFrame.highlightText](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/itextframe/#highlightText-java.lang.String-java.lang.Integer-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-), [ITextFrame.highlightRegex](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/itextframe/#highlightRegex-java.util.regex.Pattern-java.lang.Integer-com.aspose.slides.IFindResultCallback-), [ITextFrame.replaceText](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/itextframe/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-), หรือ [ITextFrame.replaceRegex](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/itextframe/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) บนเฟรมข้อความนั้น เมธอดระดับงานนำเสนอจะประมวลผลทุกเฟรมข้อความที่เกี่ยวข้องแทน

**ฉันจะจับคู่คำเต็มพร้อมการใช้ตัวอักษรใหญ่‑เล็กที่ถูกต้องได้อย่างไร?**

ตั้งค่า [TextSearchOptions.setWholeWordsOnly](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/textsearchoptions/#setWholeWordsOnly-boolean-) และ [TextSearchOptions.setCaseSensitive](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/textsearchoptions/#setCaseSensitive-boolean-) เป็น `true` แล้วส่งตัวเลือกเหล่านี้ไปยังเมธอดเน้นหรือแทนที่ข้อความตามตัวอักษร สำหรับ regular expression ให้กำหนดขอบเขตคำและการแยกตัวพิมพ์ใหญ่‑เล็กใน `Pattern` ของ Java เอง

**การค้นหาและการแทนที่สามารถรวมข้อความในโน้ตสไลด์ได้หรือไม่?**

ใช่ ตั้งค่า [TextSearchOptions.setIncludeNotes](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/textsearchoptions/#setIncludeNotes-boolean-) เป็น `true` เมื่อใช้การดำเนินการข้อความตามตัวอักษรระดับงานนำเสนอ คอลแบ็คที่แสดงด้านบนจะแมพการจับคู่ในโน้ตสไลด์กลับไปยังหมายเลขสไลด์พาเรนท์

**ฉันจะสร้างรายงานโดยไม่ต้องสแกนงานนำเสนอครั้งที่สองได้อย่างไร?**

ส่งการนำไปใช้ของ [IFindResultCallback](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ifindresultcallback/) ไปยังการดำเนินการเน้นหรือแทนที่ คอลแบ็คจะรับการจับคู่ทุกรายการขณะดำเนินการ ทำให้แอปพลิเคชันสามารถเก็บข้อความต้นฉบับ, ข้อความที่จับคู่, ตำแหน่ง, เฟรมข้อความ, และหมายเลขสไลด์ที่ได้จากการคำนวณ เพื่อนำไปจัดกลุ่มหรือส่งออกในภายหลัง

**การแทนที่ข้อความจะรักษาการฟอร์แมตของมันหรือไม่?**

[ITextFrame.replaceText](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/itextframe/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) และ [ITextFrame.replaceRegex](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/itextframe/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) จะปรับเปลี่ยนข้อความที่จับคู่ภายในเฟรมข้อความที่มีอยู่และรักษาการฟอร์แมตของส่วนที่อยู่รอบ ๆ หากการจับคู่ครอบคลุมส่วนที่มีการฟอร์แมตต่างกัน ให้ตรวจสอบผลลัพธ์เพื่อให้แน่ใจว่าการแทนที่ใช้สไตล์ที่ต้องการ