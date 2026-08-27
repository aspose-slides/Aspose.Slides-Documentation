---
title: ค้นหาและแทนที่ข้อความในงานนำเสนอ PowerPoint บน Android
linktitle: ค้นหาและแทนที่ข้อความ
type: docs
weight: 55
url: /th/androidjava/search-and-replace-text/
keywords:
- ค้นหาข้อความ
- ไฮไลต์ข้อความ
- แทนที่ข้อความ
- นิพจน์ regular expression
- callback ผลลัพธ์
- กรอบข้อความ
- รายงานการตรวจสอบ
- PowerPoint
- OpenDocument
- งานนำเสนอ
- Android
- Java
- Aspose.Slides
description: "ค้นหา, ไฮไลต์, และแทนที่ข้อความในงานนำเสนอ PowerPoint พร้อมรวบรวมทุกผลลัพธ์ที่ตรงกันด้วย Aspose.Slides for Android via Java."
---
## **ภาพรวม**

Aspose.Slides for Android via Java สามารถค้นหา, ไฮไลต์, และแทนที่ข้อความในกรอบข้อความเดี่ยวหรือทั่วทั้งงานนำเสนอได้ แต่ละการดำเนินการยังสามารถแจ้งแอปพลิเคชันเกี่ยวกับแต่ละผลลัพธ์ผ่าน callback ผลลัพธ์ ซึ่งทำให้สามารถอัปเดตงานนำเสนอและในขณะเดียวกันสร้างบันทึกการตรวจสอบที่มีข้อความที่ตรงกัน, สภาพแวดล้อม, ตำแหน่ง, กรอบข้อความ, และหมายเลขสไลด์ได้

ความสามารถเหล่านี้เป็นประโยชน์สำหรับการตรวจสอบ, การลบข้อมูล, การตรวจสอบคำศัพท์, การทำความสะอาดแม่แบบ, และกระบวนการทำรายงานอัตโนมัติ

ในตัวอย่างแรกด้านล่าง เราใช้ไฟล์ชื่อ "sample.pptx" ซึ่งมีช่องข้อความเดียวบนสไลด์แรกที่มีข้อความต่อไปนี้:

![ข้อความตัวอย่าง](sample_text.png)

## **เลือกขอบเขตการค้นหา**

ใช้เมธอดบน [ITextFrame](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/itextframe/) เพื่อจำกัดการดำเนินการให้กับกรอบข้อความหนึ่งเท่านั้น ใช้เมธอดบน [IPresentation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ipresentation/) เพื่อประมวลผลข้อความทั้งหมดที่เกี่ยวข้องในงานนำเสนอ

| การดำเนินการ | กรอบข้อความหนึ่ง | งานนำเสนอทั้งหมด |
|---|---|---|
| ไฮไลต์ข้อความตามตัวอักษร | [ITextFrame.highlightText](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/itextframe/#highlightText-java.lang.String-java.lang.Integer-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) | [IPresentation.highlightText](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ipresentation/#highlightText-java.lang.String-java.lang.Integer-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) |
| ไฮไลต์ผลการจับคู่ตาม regular expression | [ITextFrame.highlightRegex](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/itextframe/#highlightRegex-java.util.regex.Pattern-java.lang.Integer-com.aspose.slides.IFindResultCallback-) | [IPresentation.highlightRegex](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ipresentation/#highlightRegex-java.util.regex.Pattern-java.lang.Integer-com.aspose.slides.IFindResultCallback-) |
| แทนที่ข้อความตามตัวอักษร | [ITextFrame.replaceText](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/itextframe/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) | [IPresentation.replaceText](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ipresentation/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) |
| แทนที่ผลการจับคู่ตาม regular expression | [ITextFrame.replaceRegex](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/itextframe/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) | [IPresentation.replaceRegex](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ipresentation/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) |

## **กำหนดค่าการจับคู่ข้อความ**

สำหรับการดำเนินการข้อความตามตัวอักษร ใช้ [TextSearchOptions](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/textsearchoptions/) เพื่อควบคุมการจับคู่:

- [TextSearchOptions.setWholeWordsOnly](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/textsearchoptions/#setWholeWordsOnly-boolean-) จำกัดผลการจับคู่ให้เป็นคำเต็มเท่านั้น.
- [TextSearchOptions.setCaseSensitive](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/textsearchoptions/#setCaseSensitive-boolean-) ควบคุมว่าต้องตรงตามตัวพิมพ์ใหญ่/เล็กหรือไม่.
- [TextSearchOptions.setIncludeNotes](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/textsearchoptions/#setIncludeNotes-boolean-) รวมบันทึกสไลด์ในการค้นหา, แทนที่, และไฮไลต์ระดับงานนำเสนอ.

การดำเนินการ regular expression ใช้ Java `Pattern` ดังนั้นกฎการจับคู่เช่นความไวต่อกรณีและขอบเขตคำจะถูกกำหนดโดยนิพจน์และแฟล็กของมัน.

## **ระบุเจ้าของของกรอบข้อความ**

เวิร์กโฟลว์การประมวลผลข้อความทั่วไปมักได้รับ [ITextFrame](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/itextframe/) ขณะค้นหา, แทนที่, ตรวจสอบ, หรือส่งออกข้อความ ใช้ [ITextFrame.getParentShape](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/itextframe/#getParentShape--) และ [ITextFrame.getParentCell](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/itextframe/#getParentCell--) เพื่อกำหนดว่าวัตถุในงานนำเสนอใดเป็นเจ้าของกรอบข้อความนั้น

ค่าที่คาดหวังขึ้นอยู่กับเจ้าของ:

| เจ้าของกรอบข้อความ | `getParentShape` | `getParentCell` |
|---|---|---|
| AutoShape หรือรูปทรงที่บรรจุข้อความอื่น | เจ้าของ [IShape](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ishape/) | `null` |
| เซลล์ตาราง | `null` | เจ้าของ [ICell](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/icell/) |

ทั้งสองเมธอดให้การนำทางแบบอ่านอย่างเดียว การเรียกใช้ไม่ได้ย้ายกรอบข้อความหรือเปลี่ยนเจ้าของ โค้ดทั่วไปควรตรวจสอบค่า `null` ของทั้งสองและจัดการกรณีที่ไม่มีเจ้าของใด ๆ

ตัวอย่างต่อไปนี้ใช้ [SlideUtil.getAllTextFrames](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/slideutil/#getAllTextFrames-com.aspose.slides.IPresentation-boolean-) เพื่อวนลูปกรอบข้อความในงานนำเสนอ สำหรับรูปทรง จะรายงานชื่อรูปทรง, ประเภทรันไทม์ของ Java, และสไลด์ที่บรรจุไว้ สำหรับเซลล์ตาราง จะรายงานพิกัดคอลัมน์และแถวที่เริ่มจากศูนย์และสไลด์ที่บรรจุ

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

สำหรับเนื้อหา SmartArt ให้วนลูปรูปทรงใน [ISmartArtNode.getShapes](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ismartartnode/#getShapes--) และเข้าถึงแต่ละ [ISmartArtShape.getTextFrame](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ismartartshape/#getTextFrame--). กรอบข้อความสามารถตามรอยไปสู่รูปทรงที่เกี่ยวข้องผ่าน [ITextFrame.getParentShape](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/itextframe/#getParentShape--) ในขณะที่ [ITextFrame.getParentCell](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/itextframe/#getParentCell--) คืนค่า `null` ดังนั้นส่วนของรูปทรงในตัวอย่างจึงจัดการข้อความจากโหนด SmartArt ด้วยเช่นกัน

## **รวบรวมข้อมูลการจับคู่ด้วย Callback**

Implement [IFindResultCallback](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ifindresultcallback/) เพื่อรับการแจ้งเตือนสำหรับแต่ละผลลัพธ์ วิธี [IFindResultCallback.foundResult](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ifindresultcallback/#foundResult-com.aspose.slides.ITextFrame-java.lang.String-java.lang.String-int-) ให้กรอบข้อความที่เกี่ยวข้อง, ข้อความต้นฉบับ, ข้อความที่ตรงกัน, และตำแหน่งของการจับคู่

callback ไม่ได้รับหมายเลขสไลด์โดยตรง การนำไปใช้ด้านล่างได้สกัดหมายเลขสไลด์จากสไลด์แม่และยังจัดการข้อความที่พบในบันทึกสไลด์ด้วย `Integer` nullable ทำให้โมเดลผลลัพธ์เดียวกันสามารถแทนข้อความที่เกี่ยวข้องกับประเภทสไลด์อื่นได้

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

สำหรับการดำเนินการแทนที่ `foundText` จะมีข้อความที่ตรงกันดั้งเดิม ดังนั้น callback สามารถบันทึกคำที่ถูกแทนที่ได้อย่างแม่นยำ

## **ไฮไลต์ข้อความ**

ใช้เมธอด [ITextFrame.highlightText](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/itextframe/#highlightText-java.lang.String-java.lang.Integer-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) เพื่อไฮไลต์ผลการจับคู่ข้อความตามตัวอักษรในกรอบข้อความ ส่ง [TextSearchOptions](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/textsearchoptions/) เพื่อควบคุมการค้นหาและ callback เพื่อรวบรวมรายละเอียดการจับคู่

โค้ดตัวอย่างด้านล่างไฮไลต์ทุกการพบของอักขระ **"try"** แล้วไฮไลต์เฉพาะคำเต็ม **"to"** ทั้งสองการค้นหาจะรายงานผลลัพธ์ไปยัง callback เดียวกัน

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

    // ไฮไลต์ทุกการพบของ "try" ในกรอบข้อความ.
    shape.getTextFrame().highlightText("try", substringHighlightColor, substringSearchOptions, callback);

    TextSearchOptions wholeWordSearchOptions = new TextSearchOptions();
    wholeWordSearchOptions.setWholeWordsOnly(true);
    wholeWordSearchOptions.setCaseSensitive(false);
    int wholeWordHighlightColor = Color.rgb(238, 130, 238);

    // ไฮไลต์เฉพาะคำเต็ม "to".
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

![ข้อความที่ไฮไลต์](highlighted_text.png)

## **ไฮไลต์ข้อความโดยใช้ Regular Expressions**

เมธอด [ITextFrame.highlightRegex](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/itextframe/#highlightRegex-java.util.regex.Pattern-java.lang.Integer-com.aspose.slides.IFindResultCallback-) จะไฮไลต์ข้อความที่ตรงกับ regular expression ในกรอบข้อความ

โค้ดต่อไปนี้ไฮไลต์ทุกคำที่มีความยาวเจ็ดอักขระหรือมากกว่าและรวบรวมแต่ละผลการจับคู่

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

![ข้อความที่ไฮไลต์โดยใช้ regular expression](highlighted_text_using_regex.png)

## **ไฮไลต์ข้อความทั่วทั้งงานนำเสนอ**

ใช้ [IPresentation.highlightText](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ipresentation/#highlightText-java.lang.String-java.lang.Integer-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) และ [IPresentation.highlightRegex](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ipresentation/#highlightRegex-java.util.regex.Pattern-java.lang.Integer-com.aspose.slides.IFindResultCallback-) เพื่อค้นหากรอบข้อความทั้งหมดที่เกี่ยวข้องในงานนำเสนอ ตัวอย่างต่อไปนี้ไฮไลต์คำตามตัวอักษรและที่อยู่อีเมลทั้งหมดโดยเก็บคอลเลกชันผลลัพธ์แยกกันสำหรับการค้นหาแต่ละแบบ

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

## **แทนที่ข้อความในกรอบข้อความ**

ใช้ [ITextFrame.replaceText](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/itextframe/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) สำหรับข้อความตามตัวอักษรและ [ITextFrame.replaceRegex](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/itextframe/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) สำหรับการแทนที่ตาม pattern วิธีเหล่านี้อัปเดตข้อความที่ตรงกันภายในกรอบข้อความเดิม ซึ่งรักษาการจัดรูปแบบของส่วนรอบข้างไว้แทนที่จะสร้างกรอบข้อความใหม่จากสตริงธรรมดา

ตัวอย่างต่อไปนี้ทำให้รูปแบบการสะกดหนึ่งแบบเป็นมาตรฐานแล้วแทนที่ป้ายเวอร์ชันเดียวกัน callback เดียวกันบันทึกคำต้นฉบับที่ตรงกันจากทั้งสองการดำเนินการ

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

หากผลการจับคู่อีกรอบครอบคลุมส่วนที่มีการจัดรูปแบบต่างกัน ให้ตรวจสอบผลลัพธ์เพื่อยืนยันว่าการจัดรูปแบบที่ต้องการใช้กับข้อความที่แทนที่แล้วหรือไม่

## **แทนที่ข้อความทั่วทั้งงานนำเสนอ**

ใช้ [IPresentation.replaceText](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ipresentation/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) และ [IPresentation.replaceRegex](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ipresentation/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) เพื่อประยุกต์การดำเนินการเดียวกันทั่วงานนำเสนอ ซึ่งมีประโยชน์สำหรับการทำความสะอาดแม่แบบ, การอัปเดตศัพท์, และการลบข้อมูล

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

## **จัดกลุ่มผลการจับคู่สำหรับการรายงาน**

เนื่องจากผลลัพธ์ทุกรายการเก็บหมายเลขสไลด์และกรอบข้อความไว้ แอปพลิเคชันจึงสามารถจัดกลุ่มผลลัพธ์เพื่อการตรวจสอบ, รายงาน, หรือเวิร์กโฟลว์การรีวิว ตัวอย่างต่อไปนี้จัดกลุ่มผลลัพธ์ที่รวบรวมไว้ก่อนหน้าโดยแยกตามสไลด์แล้วแยกตามกรอบข้อความ

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

**ฉันจะค้นหาเพียงกล่องข้อความเดียวแทนที่จะค้นหาทั้งงานนำเสนอได้อย่างไร?**

รับกรอบข้อความของรูปทรงแล้วเรียก [ITextFrame.highlightText](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/itextframe/#highlightText-java.lang.String-java.lang.Integer-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-), [ITextFrame.highlightRegex](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/itextframe/#highlightRegex-java.util.regex.Pattern-java.lang.Integer-com.aspose.slides.IFindResultCallback-), [ITextFrame.replaceText](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/itextframe/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-), หรือ [ITextFrame.replaceRegex](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/itextframe/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) กับกรอบข้อความนั้น เมธอดระดับงานนำเสนอจะประมวลผลกรอบข้อความที่เกี่ยวข้องทั้งหมดแทน

**ฉันจะจับคู่คำเต็มพร้อมการใช้ตัวพิมพ์ใหญ่ที่ถูกต้องได้อย่างไร?**

ตั้งค่า [TextSearchOptions.setWholeWordsOnly](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/textsearchoptions/#setWholeWordsOnly-boolean-) และ [TextSearchOptions.setCaseSensitive](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/textsearchoptions/#setCaseSensitive-boolean-) เป็น `true` แล้วส่งตัวเลือกเหล่านี้ไปยังเมธอดไฮไลต์หรือแทนที่ข้อความตามตัวอักษร สำหรับ regular expression ให้กำหนดขอบเขตคำและความไวต่อกรณีใน `Pattern` ของ Java เอง

**การค้นหาและการแทนที่สามารถรวมข้อความในบันทึกสไลด์ได้หรือไม่?**

ได้ ตั้งค่า [TextSearchOptions.setIncludeNotes](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/textsearchoptions/#setIncludeNotes-boolean-) เป็น `true` เมื่อใช้เมธอดระดับงานนำเสนอแบบข้อความตามตัวอักษร Callback ที่แสดงข้างต้นจะแมปผลลัพธ์ที่พบในสไลด์บันทึกกลับไปยังหมายเลขสไลด์แม่ของมัน

**ฉันจะสร้างรายงานโดยไม่ต้องสแกนงานนำเสนออีกครั้งได้อย่างไร?**

ส่งการทำงานของ [IFindResultCallback](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ifindresultcallback/) ไปยังการไฮไลต์หรือการแทนที่ Callback จะรับทุกผลลัพธ์ขณะดำเนินการ ดังนั้นแอปพลิเคชันจึงสามารถเก็บข้อความต้นฉบับ, ข้อความที่ตรงกัน, ตำแหน่ง, กรอบข้อความ, และหมายเลขสไลด์ที่สกัดได้สำหรับการจัดกลุ่มหรือการส่งออกในภายหลัง

**การแทนที่ข้อความทำให้รูปแบบการจัดรูปยังคงอยู่หรือไม่?**

[ITextFrame.replaceText](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/itextframe/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) และ [ITextFrame.replaceRegex](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/itextframe/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) แก้ไขข้อความที่ตรงกันภายในกรอบข้อความเดิมและรักษาการจัดรูปแบบของส่วนรอบข้างไว้ หากผลการจับคู่อีกรอบครอบคลุมส่วนที่มีการจัดรูปแบบต่างกัน โปรดตรวจสอบผลลัพธ์เพื่อให้แน่ใจว่าการแทนที่ใช้สไตล์ที่ต้องการ.