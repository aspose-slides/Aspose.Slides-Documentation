---
title: ค้นหาและแทนที่ข้อความในงานนำเสนอ PowerPoint ด้วย Java
linktitle: ค้นหาและแทนที่ข้อความ
type: docs
weight: 55
url: /th/java/search-and-replace-text/
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
- Java
- Aspose.Slides
description: "ค้นหา, ไฮไลท์, และแทนที่ข้อความในงานนำเสนอ PowerPoint พร้อมรวบรวมการจับคู่ทั้งหมดด้วย Aspose.Slides for Java."
---
## **ภาพรวม**

Aspose.Slides for Java สามารถค้นหา ไฮไลท์ และแทนที่ข้อความในกรอบข้อความเดี่ยวหรือทั่วทั้งงานนำเสนอได้ ทุกการดำเนินการสามารถแจ้งแอปพลิเคชันเกี่ยวกับทุกการจับคู่ผ่านผลลัพธ์ callback ทำให้สามารถอัปเดตงานนำเสนอและสร้างบันทึกการตรวจสอบที่ประกอบด้วยข้อความที่ตรงกัน, บริบท, ตำแหน่ง, กรอบข้อความ, และหมายเลขสไลด์ได้พร้อมกัน

ความสามารถเหล่านี้มีประโยชน์สำหรับการตรวจทาน, การบล๊อกข้อความ, การตรวจสอบคำศัพท์, การทำความสะอาดเทมเพลต, และกระบวนการรายงานอัตโนมัติ

ในตัวอย่างแรกด้านล่าง เราใช้ไฟล์ชื่อ “sample.pptx” ซึ่งมีกล่องข้อความเดียวบนสไลด์แรกที่มีข้อความดังต่อไปนี้:

![ข้อความตัวอย่าง](sample_text.png)

## **เลือกขอบเขตการค้นหา**

ใช้เมธอดบน [ITextFrame](https://reference.aspose.com/slides/th/java/com.aspose.slides/itextframe/) เพื่อจำกัดการดำเนินการให้กับกรอบข้อความเดียว ใช้เมธอดบน [Presentation](https://reference.aspose.com/slides/th/java/com.aspose.slides/presentation/) เพื่อประมวลผลข้อความที่ใช้ได้ทั้งหมดในงานนำเสนอ

| การดำเนินการ | กรอบข้อความเดียว | งานนำเสนอทั้งหมด |
|---|---|---|
| ไฮไลท์ข้อความตามตัวอักษร | [ITextFrame.highlightText](https://reference.aspose.com/slides/th/java/com.aspose.slides/itextframe/#highlightText-java.lang.String-java.awt.Color-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) | [Presentation.highlightText](https://reference.aspose.com/slides/th/java/com.aspose.slides/presentation/#highlightText-java.lang.String-java.awt.Color-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) |
| ไฮไลท์ผลลัพธ์ที่ตรงกับ regular‑expression | [ITextFrame.highlightRegex](https://reference.aspose.com/slides/th/java/com.aspose.slides/itextframe/#highlightRegex-java.util.regex.Pattern-java.awt.Color-com.aspose.slides.IFindResultCallback-) | [Presentation.highlightRegex](https://reference.aspose.com/slides/th/java/com.aspose.slides/presentation/#highlightRegex-java.util.regex.Pattern-java.awt.Color-com.aspose.slides.IFindResultCallback-) |
| แทนที่ข้อความตามตัวอักษร | [ITextFrame.replaceText](https://reference.aspose.com/slides/th/java/com.aspose.slides/itextframe/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) | [Presentation.replaceText](https://reference.aspose.com/slides/th/java/com.aspose.slides/presentation/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) |
| แทนที่ผลลัพธ์ที่ตรงกับ regular‑expression | [ITextFrame.replaceRegex](https://reference.aspose.com/slides/th/java/com.aspose.slides/itextframe/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) | [Presentation.replaceRegex](https://reference.aspose.com/slides/th/java/com.aspose.slides/presentation/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) |

## **กำหนดการจับคูข้อความ**

สำหรับการดำเนินการที่ใช้ข้อความตามตัวอักษร ให้ใช้ [TextSearchOptions](https://reference.aspose.com/slides/th/java/com.aspose.slides/textsearchoptions/) เพื่อควบคุมการจับคู่:

- [TextSearchOptions.setWholeWordsOnly](https://reference.aspose.com/slides/th/java/com.aspose.slides/textsearchoptions/#setWholeWordsOnly-boolean-) จำกัดผลลัพธ์ให้เป็นคำเต็มเท่านั้น
- [TextSearchOptions.setCaseSensitive](https://reference.aspose.com/slides/th/java/com.aspose.slides/textsearchoptions/#setCaseSensitive-boolean-) ควบคุมว่าต้องตรงกับตัวพิมพ์ใหญ่/เล็กหรือไม่
- [TextSearchOptions.setIncludeNotes](https://reference.aspose.com/slides/th/java/com.aspose.slides/textsearchoptions/#setIncludeNotes-boolean-) รวมบันทึกสไลด์ในระดับงานนำเสนอในการค้นหา การแทนที่ และการไฮไลท์

การดำเนินการที่ใช้ regular‑expression ใช้ `Pattern` ของ Java ดังนั้นกฎการจับคูเช่นการแยกตัวอักษรใหญ่/เล็กและขอบเขตคำจะถูกกำหนดโดยนิพจน์และแฟล็กของมัน

## **ระบุเจ้าของของกรอบข้อความ**

เวิร์กโฟลว์การประมวลผลข้อความทั่วไปมักได้รับ [ITextFrame](https://reference.aspose.com/slides/th/java/com.aspose.slides/itextframe/) ขณะค้นหา, แทนที่, ตรวจสอบ, หรือส่งออกข้อความ ใช้ [ITextFrame.getParentShape](https://reference.aspose.com/slides/th/java/com.aspose.slides/itextframe/#getParentShape--) และ [ITextFrame.getParentCell](https://reference.aspose.com/slides/th/java/com.aspose.slides/itextframe/#getParentCell--) เพื่อระบุว่าวัตถุงานนำเสนอใดเป็นเจ้าของกรอบข้อความ

ค่าที่คาดหวังขึ้นอยู่กับเจ้าของ:

| เจ้าของกรอบข้อความ | `getParentShape` | `getParentCell` |
|---|---|---|
| AutoShape หรือรูปร่างอื่นที่มีข้อความ | IShape ที่เป็นเจ้าของ | `null` |
| เซลล์ตาราง | `null` | ICell ที่เป็นเจ้าของ |

ทั้งสองเมธอดให้การนำทางแบบอ่านอย่างเดียว การเรียกใช้ไม่ได้ย้ายกรอบข้อความหรือเปลี่ยนเจ้าของ โค้ดทั่วไปควรตรวจสอบค่าทั้งสองสำหรับ `null` และจัดการกรณีที่ไม่มีเจ้าของใด ๆ พร้อมใช้งาน

ตัวอย่างต่อไปนี้ใช้ [SlideUtil.getAllTextFrames](https://reference.aspose.com/slides/th/java/com.aspose.slides/slideutil/#getAllTextFrames-com.aspose.slides.IPresentation-boolean-) เพื่อวนลูปกรอบข้อความทั้งหมดในงานนำเสนอ สำหรับรูปร่าง จะแสดงชื่อรูปร่าง, ประเภท runtime ของ Java, และสไลด์ที่บรรจุ สำหรับเซลล์ตาราง จะแสดงคอลัมน์และแถวที่เริ่มจากศูนย์ และสไลด์ที่บรรจุ

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    ITextFrame[] textFrames = SlideUtil.getAllTextFrames(presentation, false);

    for (ITextFrame textFrame : textFrames) {
        IShape ownerShape = textFrame.getParentShape();
        if (ownerShape != null) {
            String shapeName = ownerShape.getName().isEmpty() ? "(unnamed)" : ownerShape.getName();
            String shapeType = ownerShape.getClass().getSimpleName();
            IBaseSlide baseSlide = ownerShape.getSlide();
            String slideLabel;
            if (baseSlide instanceof ISlide) {
                slideLabel = "slide " + ((ISlide) baseSlide).getSlideNumber();
            } else if (baseSlide instanceof INotesSlide) {
                slideLabel = "notes for slide " + ((INotesSlide) baseSlide).getParentSlide().getSlideNumber();
            } else {
                slideLabel = baseSlide.getClass().getSimpleName();
            }
            System.out.println("Shape: " + shapeName + "; type: " + shapeType + "; " + slideLabel);
            continue;
        }

        ICell ownerCell = textFrame.getParentCell();
        if (ownerCell != null) {
            IBaseSlide baseSlide = ownerCell.getSlide();
            String slideLabel;
            if (baseSlide instanceof ISlide) {
                slideLabel = "slide " + ((ISlide) baseSlide).getSlideNumber();
            } else if (baseSlide instanceof INotesSlide) {
                slideLabel = "notes for slide " + ((INotesSlide) baseSlide).getParentSlide().getSlideNumber();
            } else {
                slideLabel = baseSlide.getClass().getSimpleName();
            }
            System.out.println("Table cell: column " + ownerCell.getFirstColumnIndex() + ", row " + ownerCell.getFirstRowIndex() + "; " + slideLabel);
            continue;
        }

        System.out.println("The text frame owner is not available as a shape or table cell.");
    }
} finally {
    presentation.dispose();
}
```

สำหรับเนื้อหา SmartArt ให้วนลูปรูปร่างใน [ISmartArtNode.getShapes](https://reference.aspose.com/slides/th/java/com.aspose.slides/ismartartnode/#getShapes--) แล้วเข้าถึงแต่ละ [ISmartArtShape.getTextFrame](https://reference.aspose.com/slides/th/java/com.aspose.slides/ismartartshape/#getTextFrame--) กรอบข้อความสามารถเชื่อมต่อกับรูปร่างที่เกี่ยวข้องผ่าน [ITextFrame.getParentShape](https://reference.aspose.com/slides/th/java/com.aspose.slides/itextframe/#getParentShape--) ในขณะที่ [ITextFrame.getParentCell](https://reference.aspose.com/slides/th/java/com.aspose.slides/itextframe/#getParentCell--) จะคืนค่า `null` ดังนั้นสาขารูปร่างในตัวอย่างจึงจัดการข้อความจากโหนด SmartArt ด้วย

## **รวบรวมข้อมูลการจับคู่ด้วย Callback**

ทำการ Implement [IFindResultCallback](https://reference.aspose.com/slides/th/java/com.aspose.slides/ifindresultcallback/) เพื่อรับการแจ้งเตือนสำหรับทุกการจับคู่ เมธอด [IFindResultCallback.foundResult](https://reference.aspose.com/slides/th/java/com.aspose.slides/ifindresultcallback/#foundResult-com.aspose.slides.ITextFrame-java.lang.String-java.lang.String-int-) จะให้กรอบข้อความที่เกี่ยวข้อง, ข้อความต้นฉบับ, ข้อความที่ตรงกัน, และตำแหน่งของการจับคู่

Callback ไม่ได้รับหมายเลขสไลด์โดยตรง การทำงานด้านล่างจึงสรุปหมายเลขสไลด์จากสไลด์พาเรนต์และยังจัดการข้อความที่พบในบันทึกสไลด์ด้วย `Integer` ที่อาจเป็น `null` ทำให้โมเดลผลลัพธ์เดียวกันสามารถแสดงข้อความที่เกี่ยวข้องกับชนิดสไลด์อื่นได้

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

    private Integer getSlideNumber(ITextFrame textFrame) {
        IShape parentShape = textFrame.getParentShape();
        ICell parentCell = textFrame.getParentCell();
        IBaseSlide parentSlide = parentShape != null ? parentShape.getSlide() : parentCell != null ? parentCell.getSlide() : textFrame.getSlide();

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

สำหรับการดำเนินการแทนที่ `foundText` จะมีข้อความที่ตรงกันดั้งเดิม ดังนั้น Callback สามารถบันทึกว่าเงื่อนไขใดบ้างที่ถูกแทนที่

## **ไฮไลท์ข้อความ**

ใช้เมธอด [ITextFrame.highlightText](https://reference.aspose.com/slides/th/java/com.aspose.slides/itextframe/#highlightText-java.lang.String-java.awt.Color-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) เพื่อไฮไลท์ผลลัพธ์ที่ตรงกับข้อความตามตัวอักษรในกรอบข้อความ ส่ง [TextSearchOptions](https://reference.aspose.com/slides/th/java/com.aspose.slides/textsearchoptions/) เพื่อควบคุมการค้นหาและ Callback เพื่อรวบรวมรายละเอียดการจับคู่

โค้ดตัวอย่างด้านล่างไฮไลท์ทุกการปรากฏของอักขระ **"try"** แล้วจึงไฮไลท์เฉพาะคำเต็ม **"to"** ทั้งสองการค้นหารายงานผลลัพธ์ให้ Callback เดียวกัน

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

    // ไฮไลท์ทุกการปรากฏของ "try" ในกรอบข้อความ.
    shape.getTextFrame().highlightText("try", substringHighlightColor, substringSearchOptions, callback);

    TextSearchOptions wholeWordSearchOptions = new TextSearchOptions();
    wholeWordSearchOptions.setWholeWordsOnly(true);
    wholeWordSearchOptions.setCaseSensitive(false);
    Color wholeWordHighlightColor = new Color(238, 130, 238);

    // ไฮไลท์เฉพาะคำเต็ม "to".
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

![ข้อความที่ไฮไลท์](highlighted_text.png)

## **ไฮไลท์ข้อความด้วยการใช้ Regular Expressions**

เมธอด [ITextFrame.highlightRegex](https://reference.aspose.com/slides/th/java/com.aspose.slides/itextframe/#highlightRegex-java.util.regex.Pattern-java.awt.Color-com.aspose.slides.IFindResultCallback-) จะไฮไลท์ข้อความที่ตรงกับ regular expression ในกรอบข้อความ

โค้ดต่อไปนี้ไฮไลท์ทุกคำที่มีความยาวเจ็ดตัวอักษรหรือมากกว่าและรวบรวมแต่ละการจับคู่

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

![ข้อความที่ไฮไลท์โดยใช้ regular expression](highlighted_text_using_regex.png)

## **ไฮไลท์ข้อความทั่วทั้งงานนำเสนอ**

ใช้ [Presentation.highlightText](https://reference.aspose.com/slides/th/java/com.aspose.slides/presentation/#highlightText-java.lang.String-java.awt.Color-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) และ [Presentation.highlightRegex](https://reference.aspose.com/slides/th/java/com.aspose.slides/presentation/#highlightRegex-java.util.regex.Pattern-java.awt.Color-com.aspose.slides.IFindResultCallback-) เพื่อค้นหากรอบข้อความที่ใช้ได้ทั้งหมดในงานนำเสนอ ตัวอย่างต่อไปนี้ไฮไลท์คำตามตัวอักษรและที่อยู่อีเมลทั้งหมด พร้อมแยกคอลเลกชันผลลัพธ์ของสองการค้นหา

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

ใช้ [ITextFrame.replaceText](https://reference.aspose.com/slides/th/java/com.aspose.slides/itextframe/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) สำหรับข้อความตามตัวอักษรและ [ITextFrame.replaceRegex](https://reference.aspose.com/slides/th/java/com.aspose.slides/itextframe/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) สำหรับการแทนที่โดยใช้แพทเทิร์น เมธอดเหล่านี้จะอัปเดตข้อความที่ตรงกันภายในกรอบข้อความที่มีอยู่ ซึ่งรักษาการฟอร์แมตของส่วนที่เหลือไว้แทนการสร้างกรอบข้อความใหม่จากสตริงเปล่า

ตัวอย่างต่อไปนี้ทำมาตรฐานการสะกดคำและจากนั้นแทนที่ป้ายเวอร์ชันเดียวกัน Callback จะบันทึกเงื่อนไขต้นฉบับที่ตรงกับทั้งสองการดำเนินการ

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

หากการจับคู่หนึ่งครอบคลุมส่วนที่มีฟอร์แมตต่างกัน โปรดตรวจสอบผลลัพธ์เพื่อยืนยันว่าฟอร์แมตที่ต้องการใช้กับข้อความที่แทนที่คืออะไร

## **แทนที่ข้อความทั่วทั้งงานนำเสนอ**

ใช้ [Presentation.replaceText](https://reference.aspose.com/slides/th/java/com.aspose.slides/presentation/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) และ [Presentation.replaceRegex](https://reference.aspose.com/slides/th/java/com.aspose.slides/presentation/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) เพื่อทำการดำเนินการเดียวกันทั่วทั้งงานนำเสนอ สิ่งนี้มีประโยชน์สำหรับการทำความสะอาดเทมเพลต, การอัปเดตศัพท์, และการบล๊อกข้อความ

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

## **จัดกลุ่มผลจับคู่เพื่อการรายงาน**

เนื่องจากผลลัพธ์แต่ละรายการจะเก็บหมายเลขสไลด์และกรอบข้อความไว้ แอปพลิเคชันจึงสามารถจัดกลุ่มผลจับคู่เพื่อการตรวจสอบ, รายงาน, หรือเวิร์กโฟลว์ตรวจทาน ตัวอย่างต่อไปนี้จัดกลุ่มผลที่รวบรวมโดยแรกตามสไลด์แล้วตามกรอบข้อความ

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

## **ถามตอบ**

**ฉันจะค้นหาเฉพาะกล่องข้อความเดียวแทนการค้นหาทั้งงานนำเสนอได้อย่างไร?**

รับกรอบข้อความของรูปร่างและเรียกใช้ [ITextFrame.highlightText](https://reference.aspose.com/slides/th/java/com.aspose.slides/itextframe/#highlightText-java.lang.String-java.awt.Color-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-), [ITextFrame.highlightRegex](https://reference.aspose.com/slides/th/java/com.aspose.slides/itextframe/#highlightRegex-java.util.regex.Pattern-java.awt.Color-com.aspose.slides.IFindResultCallback-), [ITextFrame.replaceText](https://reference.aspose.com/slides/th/java/com.aspose.slides/itextframe/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-), หรือ [ITextFrame.replaceRegex](https://reference.aspose.com/slides/th/java/com.aspose.slides/itextframe/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) บนกรอบข้อความนั้น เมธอดระดับ Presentation จะประมวลผลกรอบข้อความทั้งหมดที่ใช้ได้แทน

**ฉันจะจับคู่คำเต็มพร้อมการใช้ตัวพิมพ์ใหญ่/เล็กที่ถูกต้องได้อย่างไร?**

ตั้งค่า [TextSearchOptions.setWholeWordsOnly](https://reference.aspose.com/slides/th/java/com.aspose.slides/textsearchoptions/#setWholeWordsOnly-boolean-) และ [TextSearchOptions.setCaseSensitive](https://reference.aspose.com/slides/th/java/com.aspose.slides/textsearchoptions/#setCaseSensitive-boolean-) ให้เป็น `true` แล้วส่ง options ไปยังเมธอดไฮไลท์หรือแทนที่ข้อความตามตัวอักษร สำหรับ regular expressions ให้กำหนดขอบเขตคำและความไวต่อตัวพิมพ์ใหญ่/เล็กใน `Pattern` ของ Java เอง

**การค้นหาและแทนที่สามารถรวมข้อความในบันทึกสไลด์ได้หรือไม่?**

ได้ ตั้งค่า [TextSearchOptions.setIncludeNotes](https://reference.aspose.com/slides/th/java/com.aspose.slides/textsearchoptions/#setIncludeNotes-boolean-) เป็น `true` เมื่อใช้เมธอดระดับ Presentation ที่ทำงานกับข้อความตามตัวอักษร Callback implementation ที่แสดงด้านบนจะทำแผนที่การจับคู่ในสไลด์บันทึกกลับไปยังหมายเลขสไลด์พาเรนต์

**ฉันจะสร้างรายงานโดยไม่ต้องสแกนงานนำเสนอซ้ำได้อย่างไร?**

ส่ง implementation ของ [IFindResultCallback](https://reference.aspose.com/slides/th/java/com.aspose.slides/ifindresultcallback/) ไปกับการไฮไลท์หรือการแทนที่ Callback จะรับทุกการจับคู่ขณะดำเนินการ ทำให้แอปพลิเคชันสามารถเก็บข้อความต้นฉบับ, ข้อความที่ตรงกัน, ตำแหน่ง, กรอบข้อความ, และหมายเลขสไลด์ที่สรุปไว้สำหรับการจัดกลุ่มหรือส่งออกภายหลัง

**การแทนที่ข้อความจะรักษารูปแบบไว้หรือไม่?**

[ITextFrame.replaceText](https://reference.aspose.com/slides/th/java/com.aspose.slides/itextframe/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) และ [ITextFrame.replaceRegex](https://reference.aspose.com/slides/th/java/com.aspose.slides/itextframe/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) ปรับข้อความที่ตรงกันภายในกรอบข้อความที่มีอยู่และรักษาการฟอร์แมตของส่วนที่ล้อมรอบไว้ หากการจับคู่ครอบคลุมส่วนที่มีฟอร์แมตต่างกัน โปรดตรวจสอบผลลัพธ์เพื่อให้แน่ใจว่าการแทนที่จะใช้สไตล์ที่ต้องการ