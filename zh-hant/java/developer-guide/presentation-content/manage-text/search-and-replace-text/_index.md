---
title: 在 Java 中於 PowerPoint 簡報中搜尋與取代文字
linktitle: 搜尋與取代文字
type: docs
weight: 55
url: /zh-hant/java/search-and-replace-text/
keywords:
- 搜尋文字
- 標記文字
- 取代文字
- 正規表達式
- 結果回呼
- 文字框
- 稽核報告
- PowerPoint
- OpenDocument
- 簡報
- Java
- Aspose.Slides
description: "在 PowerPoint 簡報中搜尋、標記與取代文字，並使用 Aspose.Slides for Java 收集每一次符合。"
---
## **概述**

Aspose.Slides for Java 可以在單一文字框或整個簡報中搜尋、標記及取代文字。每項操作也能透過結果回呼通知應用程式每一次的符合。這使得在更新簡報的同時，能同時建立包含符合文字、其上下文、位置、文字框與投影片編號的稽核追蹤。

這些功能對於審閱、刪除、術語檢查、範本清理以及自動報告工作流程都很有用。

在以下的第一個範例中，我們使用名為「sample.pptx」的檔案，該檔案在第一張投影片上包含一個文字方塊，文字內容如下：

![Sample text](sample_text.png)

## **選擇搜尋範圍**

使用[ITextFrame](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/itextframe/)的方法將操作限制在單一文字框上。使用[Presentation](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/presentation/)的方法可處理簡報中所有適用的文字。

| 操作 | 單一文字框 | 整個簡報 |
|---|---|---|
| Highlight literal text | [ITextFrame.highlightText](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/itextframe/#highlightText-java.lang.String-java.awt.Color-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) | [Presentation.highlightText](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/presentation/#highlightText-java.lang.String-java.awt.Color-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) |
| Highlight regular-expression matches | [ITextFrame.highlightRegex](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/itextframe/#highlightRegex-java.util.regex.Pattern-java.awt.Color-com.aspose.slides.IFindResultCallback-) | [Presentation.highlightRegex](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/presentation/#highlightRegex-java.util.regex.Pattern-java.awt.Color-com.aspose.slides.IFindResultCallback-) |
| Replace literal text | [ITextFrame.replaceText](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/itextframe/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) | [Presentation.replaceText](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/presentation/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) |
| Replace regular-expression matches | [ITextFrame.replaceRegex](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/itextframe/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) | [Presentation.replaceRegex](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/presentation/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) |

## **設定文字匹配**

對於文字字面值操作，使用[TextSearchOptions](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/textsearchoptions/)來控制匹配方式：

- [TextSearchOptions.setWholeWordsOnly](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/textsearchoptions/#setWholeWordsOnly-boolean-) 限制符合僅為完整的單詞。
- [TextSearchOptions.setCaseSensitive](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/textsearchoptions/#setCaseSensitive-boolean-) 控制是否必須匹配字元大小寫。
- [TextSearchOptions.setIncludeNotes](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/textsearchoptions/#setIncludeNotes-boolean-) 在簡報層級的搜尋、取代與標記操作中包含投影片備註。

正規表達式操作使用 Java `Pattern`，因此大小寫敏感度與單詞邊界等規則由表達式本身及其旗標決定。

## **使用回呼收集符合資訊**

實作[IFindResultCallback](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ifindresultcallback/)以接收每一次符合的通知。其[IFindResultCallback.foundResult](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ifindresultcallback/#foundResult-com.aspose.slides.ITextFrame-java.lang.String-java.lang.String-int-) 方法提供相關的文字框、來源文字、符合文字以及符合位置。

回呼不會直接收到投影片編號。以下實作從父投影片取得編號，並同時處理投影片備註中的文字。可為 `Integer` 使用可為 null 的型別，以讓相同的結果模型也能表達其他類型投影片的文字。

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

對於取代操作，`foundText` 會包含原始的符合文字，回呼因此可以精確記錄被取代的詞彙。

## **標記文字**

使用[ITextFrame.highlightText](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/itextframe/#highlightText-java.lang.String-java.awt.Color-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) 方法在文字框中標記文字字面值的符合。將[TextSearchOptions](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/textsearchoptions/)傳入以控制搜尋，並提供回呼以收集符合細節。

以下程式碼範例先標記所有 **"try"** 出現的字元，然後僅標記完整單詞 **"to"**。兩次搜尋皆將符合結果回報給同一個回呼。

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

    // 在文字框中突顯每一次出現的 "try"。
    shape.getTextFrame().highlightText("try", substringHighlightColor, substringSearchOptions, callback);

    TextSearchOptions wholeWordSearchOptions = new TextSearchOptions();
    wholeWordSearchOptions.setWholeWordsOnly(true);
    wholeWordSearchOptions.setCaseSensitive(false);
    Color wholeWordHighlightColor = new Color(238, 130, 238);

    // 只突顯完整的單詞 "to"。
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

![The highlighted text](highlighted_text.png)

## **使用正規表達式標記文字**

[ITextFrame.highlightRegex](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/itextframe/#highlightRegex-java.util.regex.Pattern-java.awt.Color-com.aspose.slides.IFindResultCallback-) 方法會標記文字框中符合正規表達式的文字。

以下程式碼標記所有包含七個或以上字元的單詞，並收集每一次符合：

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

結果：

![The highlighted text using the regular expression](highlighted_text_using_regex.png)

## **跨簡報標記文字**

使用[Presentation.highlightText](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/presentation/#highlightText-java.lang.String-java.awt.Color-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) 與[Presentation.highlightRegex](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/presentation/#highlightRegex-java.util.regex.Pattern-java.awt.Color-com.aspose.slides.IFindResultCallback-) 於簡報中搜尋所有適用的文字框。以下範例同時標記一個文字字面值以及所有電子郵件地址，且為兩個搜尋保留分別的結果集合。

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

## **在文字框中取代文字**

使用[ITextFrame.replaceText](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/itextframe/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) 取代文字字面值，使用[ITextFrame.replaceRegex](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/itextframe/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) 進行模式式取代。這兩個方法會在現有文字框內更新符合的文字，保留周圍段落的格式，而非從純文字重新建立文字框。

以下範例先統一拼寫變體，接著取代版本標籤。相同的回呼會記錄兩個操作所匹配的原始詞彙。

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

如果一次符合跨越了格式不同的段落，請檢查輸出以確認哪種格式應套用於取代後的文字。

## **跨簡報取代文字**

使用[Presentation.replaceText](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/presentation/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) 與[Presentation.replaceRegex](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/presentation/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) 在整個簡報中執行相同的取代操作。此功能適用於範本清理、術語更新與刪除。

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

## **將符合分組以產生報告**

因為每筆結果都儲存了投影片編號與文字框，應用程式可以依據審核、報告或審閱工作流程將符合分組。以下範例先依投影片，再依文字框將收集的結果分組：

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

## **常見問題**

**How can I search only one text box instead of the entire presentation?**  
如何只搜尋單一文字方塊而非整個簡報？

取得形狀的文字框後，呼叫[ITextFrame.highlightText](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/itextframe/#highlightText-java.lang.String-java.awt.Color-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-)、[ITextFrame.highlightRegex](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/itextframe/#highlightRegex-java.util.regex.Pattern-java.awt.Color-com.aspose.slides.IFindResultCallback-)、[ITextFrame.replaceText](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/itextframe/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-)、或[ITextFrame.replaceRegex](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/itextframe/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) 於該文字框上。簡報層級的方法則會處理所有適用的文字框。

**How can I match complete words with the correct capitalization?**  
如何在匹配完整單詞時同時保留正確的大小寫？

將[TextSearchOptions.setWholeWordsOnly](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/textsearchoptions/#setWholeWordsOnly-boolean-) 與[TextSearchOptions.setCaseSensitive](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/textsearchoptions/#setCaseSensitive-boolean-) 設為 `true`，並將此選項傳入文字字面值的標記或取代方法。對於正規表達式，請在 Java `Pattern` 本身定義單詞邊界與大小寫敏感度。

**Can search and replacement include text in slide notes?**  
搜尋與取代是否可以包含投影片備註中的文字？

可以。於使用簡報層級的文字字面值操作時，將[TextSearchOptions.setIncludeNotes](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/textsearchoptions/#setIncludeNotes-boolean-) 設為 `true`。上述回呼實作會將備註投影片中的符合映射回其父投影片編號。

**How can I create a report without scanning the presentation a second time?**  
如何在不再次掃描簡報的情況下產生報告？

將[IFindResultCallback](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ifindresultcallback/) 實作傳入標記或取代操作。回呼會在操作執行期間即接收每一次符合，因而讓應用程式儲存來源文字、符合文字、位置、文字框以及衍生的投影片編號，以供之後分組或匯出。

**Does replacing text preserve its formatting?**  
取代文字時會保留原有格式嗎？

[ITextFrame.replaceText](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/itextframe/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) 與[ITextFrame.replaceRegex](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/itextframe/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) 會在現有文字框內修改符合的文字，並保留周圍段落的格式。如果一次符合跨越了格式不同的段落，請檢查結果以確保取代使用了期望的樣式。