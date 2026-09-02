---
title: 在 Android 上搜尋與取代 PowerPoint 簡報中的文字
linktitle: 搜尋與取代文字
type: docs
weight: 55
url: /zh-hant/androidjava/search-and-replace-text/
keywords:
- 搜尋文字
- 標記文字
- 取代文字
- 正則表達式
- 結果回呼
- 文字框
- 稽核報告
- PowerPoint
- OpenDocument
- 簡報
- Android
- Java
- Aspose.Slides
description: "使用 Aspose.Slides for Android via Java，在 PowerPoint 簡報中搜尋、標記與取代文字，同時收集每一次匹配。"
---
## **概述**

Aspose.Slides for Android via Java 可以在單一文字框或整個簡報中搜索、標記與取代文字。每個操作也可以透過結果回呼通知應用程式每一個匹配項目。這使得在更新簡報的同時，能同時建立包含匹配文字、其上下文、位置、文字框以及投影片編號的稽核追蹤。

這些功能對於審閱、刪除、術語檢查、範本清理與自動化報告工作流程非常有用。

在以下的第一個範例中，我們使用名為"sample.pptx"的檔案，該檔案在第一張投影片上包含一個文字方塊，其內容如下：

![範例文字](sample_text.png)

## **選擇搜尋範圍**

使用[ITextFrame](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/itextframe/)的方法可將操作限制於單一文字框。使用[IPresentation](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ipresentation/)的方法可處理簡報中所有適用的文字。

| Operation | One text frame | Entire presentation |
|---|---|---|
| Highlight literal text | [ITextFrame.highlightText](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/itextframe/#highlightText-java.lang.String-java.lang.Integer-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) | [IPresentation.highlightText](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ipresentation/#highlightText-java.lang.String-java.lang.Integer-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) |
| Highlight regular-expression matches | [ITextFrame.highlightRegex](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/itextframe/#highlightRegex-java.util.regex.Pattern-java.lang.Integer-com.aspose.slides.IFindResultCallback-) | [IPresentation.highlightRegex](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ipresentation/#highlightRegex-java.util.regex.Pattern-java.lang.Integer-com.aspose.slides.IFindResultCallback-) |
| Replace literal text | [ITextFrame.replaceText](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/itextframe/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) | [IPresentation.replaceText](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ipresentation/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) |
| Replace regular-expression matches | [ITextFrame.replaceRegex](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/itextframe/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) | [IPresentation.replaceRegex](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ipresentation/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) |

## **設定文字匹配**

對於純文字操作，請使用[TextSearchOptions](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/textsearchoptions/) 來控制匹配方式：

- [TextSearchOptions.setWholeWordsOnly](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/textsearchoptions/#setWholeWordsOnly-boolean-) 將匹配限制為完整單字。
- [TextSearchOptions.setCaseSensitive](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/textsearchoptions/#setCaseSensitive-boolean-) 控制是否必須匹配字元大小寫。
- [TextSearchOptions.setIncludeNotes](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/textsearchoptions/#setIncludeNotes-boolean-) 在簡報層級的搜尋、取代與標記操作中包含投影片備註。

正則表達式操作使用 Java `Pattern`，因此大小寫敏感度與單字邊界等匹配規則由表達式本身及其旗標決定。

## **使用回呼收集匹配資訊**

實作[IFindResultCallback](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ifindresultcallback/) 以接收每一次匹配的通知。其 [IFindResultCallback.foundResult](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ifindresultcallback/#foundResult-com.aspose.slides.ITextFrame-java.lang.String-java.lang.String-int-) 方法會提供相關的文字框、來源文字、匹配文字以及匹配位置。

回呼不會直接收到投影片編號。以下的實作從父投影片取得編號，且也處理投影片備註中的文字。可為空的 `Integer` 允許相同的結果模型表示與其他投影片類型相關的文字。

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

對於取代操作，`foundText` 包含原始匹配文字，因此回呼可以精確記錄哪一些詞彙被取代。

## **標記文字**

使用[ITextFrame.highlightText](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/itextframe/#highlightText-java.lang.String-java.lang.Integer-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) 方法在文字框中標記純文字匹配項目。傳遞[TextSearchOptions](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/textsearchoptions/) 以控制搜尋，並提供回呼以收集匹配細節。

以下程式碼範例會標記所有出現的字元 **"try"**，然後僅標記完整單字 **"to"**。兩個搜尋皆將匹配結果回報給相同的回呼。

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

    // 在文字框中標記所有出現的 "try"。
    shape.getTextFrame().highlightText("try", substringHighlightColor, substringSearchOptions, callback);

    TextSearchOptions wholeWordSearchOptions = new TextSearchOptions();
    wholeWordSearchOptions.setWholeWordsOnly(true);
    wholeWordSearchOptions.setCaseSensitive(false);
    int wholeWordHighlightColor = Color.rgb(238, 130, 238);

    // 僅標記完整單字 "to"。
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

結果：

![已標記的文字](highlighted_text.png)

## **使用正則表達式標記文字**

[ITextFrame.highlightRegex](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/itextframe/#highlightRegex-java.util.regex.Pattern-java.lang.Integer-com.aspose.slides.IFindResultCallback-) 方法會在文字框中標記正則表達式找到的文字匹配項目。

以下程式碼會標記所有包含七個以上字元的單字，並收集每一次匹配：

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

結果：

![使用正則表達式標記的文字](highlighted_text_using_regex.png)

## **跨簡報標記文字**

使用[IPresentation.highlightText](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ipresentation/#highlightText-java.lang.String-java.lang.Integer-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) 與[IPresentation.highlightRegex](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ipresentation/#highlightRegex-java.util.regex.Pattern-java.lang.Integer-com.aspose.slides.IFindResultCallback-) 來搜尋簡報中所有適用的文字框。以下範例標記一個純文字詞彙與所有電子郵件地址，並為兩個搜尋保留分別的結果集合。

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

## **在文字框中取代文字**

對於純文字使用[ITextFrame.replaceText](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/itextframe/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback)，對於基於模式的取代使用[ITextFrame.replaceRegex](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/itextframe/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback)。這些方法會在現有文字框內更新匹配的文字，保留周圍區段的格式，而不是從純文字重新建構文字框。

以下範例會統一拼寫變體，然後取代版本標籤。同一個回呼會記錄兩項操作匹配的原始詞彙。

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

如果某個匹配跨越具有不同格式的區段，請檢查輸出以確認應套用於取代文字的格式。

## **跨簡報取代文字**

使用[IPresentation.replaceText](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ipresentation/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) 與[IPresentation.replaceRegex](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ipresentation/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) 在整個簡報中套用相同的操作。這對於範本清理、術語更新與刪除非常有用。

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

## **將匹配項目分組以產生報告**

由於每個結果都儲存投影片編號與文字框，應用程式可以將匹配項目依據審核、報告或審查流程進行分組。以下範例先依投影片再依文字框分組收集的結果：

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

## **FAQ**

**如何只搜尋單一文字方塊而非整個簡報？**

取得形狀的文字框，並在該文字框上呼叫[ITextFrame.highlightText]、[ITextFrame.highlightRegex]、[ITextFrame.replaceText]或[ITextFrame.replaceRegex]。簡報層級的方法會處理所有適用的文字框。

**如何匹配完整單字且大小寫正確？**

將[TextSearchOptions.setWholeWordsOnly]與[TextSearchOptions.setCaseSensitive]設為 `true`，並將這些選項傳入純文字的標記或取代方法。對於正則表達式，請在 Java `Pattern` 本身定義單字邊界與大小寫敏感度。

**搜尋與取代可以包含投影片備註中的文字嗎？**

可以。於使用簡報層級的純文字操作時，將[TextSearchOptions.setIncludeNotes]設為 `true`。上述的回呼實作會將備註投影片中的匹配對映回其父投影片編號。

**如何在不再次掃描簡報的情況下產生報告？**

將[IFindResultCallback]實作傳入標記或取代操作。回呼在操作執行期間會接收每一次匹配，讓應用程式可儲存來源文字、匹配文字、位置、文字框與衍生的投影片編號，以供稍後分組或匯出產生報告。

**取代文字會保留其格式嗎？**

[ITextFrame.replaceText]與[ITextFrame.replaceRegex]會在現有文字框內修改匹配的文字，並保留周圍區段的格式。如果匹配跨越不同格式的區段，請檢查結果以確保取代文字使用期望的樣式。