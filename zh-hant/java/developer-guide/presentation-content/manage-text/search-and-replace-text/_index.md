---
title: 在 Java 中搜尋與取代 PowerPoint 簡報的文字
linktitle: 搜尋與取代文字
type: docs
weight: 55
url: /zh-hant/java/search-and-replace-text/
keywords:
- 搜尋文字
- 標示文字
- 取代文字
- 正則表達式
- 結果回呼
- 文字框
- 稽核報告
- PowerPoint
- OpenDocument
- 簡報
- Java
- Aspose.Slides
description: "使用 Aspose.Slides for Java 在 PowerPoint 簡報中搜尋、標示與取代文字，同時收集所有匹配結果。"
---
## **概觀**

Aspose.Slides for Java 能在單一文字框或整個簡報中搜尋、標示以及取代文字。每項操作還能透過結果回呼通知應用程式每一次匹配。這使得在更新簡報的同時，能同時建立包含匹配文字、其上下文、位置、文字框以及投影片編號的稽核紀錄。

這些功能對於審閱、刪除、術語檢查、範本清理及自動化報告工作流程非常有用。

在以下的第一個範例中，我們使用名為 "sample.pptx" 的檔案，該檔案在第一張投影片上包含一個單一文字盒，內容如下：

![範例文字](sample_text.png)

## **選擇搜尋範圍**

使用 [ITextFrame](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/itextframe/) 方法將操作限制於單一文字框。使用 [Presentation](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/presentation/) 方法處理簡報中所有適用的文字。

| 操作 | 單一文字框 | 整個簡報 |
|---|---|---|
| 突出顯示純文字 | [ITextFrame.highlightText](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/itextframe/#highlightText-java.lang.String-java.awt.Color-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) | [Presentation.highlightText](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/presentation/#highlightText-java.lang.String-java.awt.Color-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) |
| 突出顯示正規表達式匹配 | [ITextFrame.highlightRegex](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/itextframe/#highlightRegex-java.util.regex.Pattern-java.awt.Color-com.aspose.slides.IFindResultCallback-) | [Presentation.highlightRegex](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/presentation/#highlightRegex-java.util.regex.Pattern-java.awt.Color-com.aspose.slides.IFindResultCallback-) |
| 取代純文字 | [ITextFrame.replaceText](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/itextframe/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) | [Presentation.replaceText](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/presentation/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) |
| 取代正規表達式匹配 | [ITextFrame.replaceRegex](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/itextframe/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) | [Presentation.replaceRegex](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/presentation/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) |

## **設定文字匹配**

對於純文字操作，使用 [TextSearchOptions](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/textsearchoptions/) 來控制匹配方式：

- [TextSearchOptions.setWholeWordsOnly](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/textsearchoptions/#setWholeWordsOnly-boolean-) 限制匹配僅限完整單字。
- [TextSearchOptions.setCaseSensitive](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/textsearchoptions/#setCaseSensitive-boolean-) 控制是否必須符合字元大小寫。
- [TextSearchOptions.setIncludeNotes](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/textsearchoptions/#setIncludeNotes-boolean-) 將投影片備註納入簡報層級的搜尋、取代與標示操作。

正規表達式操作使用 Java `Pattern`，因此如大小寫敏感度與單字邊界等匹配規則由表達式本身及其旗標定義。

## **識別文字框的擁有者**

一般的文字處理工作流程在搜尋、取代、驗證或匯出文字時常會收到一個 [ITextFrame](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/itextframe/)。使用 [ITextFrame.getParentShape](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/itextframe/#getParentShape--) 和 [ITextFrame.getParentCell](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/itextframe/#getParentCell--) 可判斷是哪個簡報物件擁有該文字框。

預期的值取決於擁有者：

| 文字框擁有者 | `getParentShape` | `getParentCell` |
|---|---|---|
| AutoShape 或其他包含文字的形狀 | 擁有的 [IShape](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ishape/) | `null` |
| 表格儲存格 | `null` | 擁有的 [ICell](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/icell/) |

兩個方法皆提供唯讀的導覽。呼叫它們不會移動文字框或變更其擁有者。通用程式碼應同時檢查兩個值是否為 `null`，並處理兩者皆不可用的情況。

以下範例使用 [SlideUtil.getAllTextFrames](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/slideutil/#getAllTextFrames-com.aspose.slides.IPresentation-boolean-) 迭代簡報中的文字框。對於形狀，它會報告形狀名稱、Java 執行時類型，以及所屬投影片。對於表格儲存格，它會報告零基礎的列與行座標以及所屬投影片。

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

對於 SmartArt 內容，遍歷 [ISmartArtNode.getShapes](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ismartartnode/#getShapes--) 中的形狀，並存取每個 [ISmartArtShape.getTextFrame](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ismartartshape/#getTextFrame--)。文字框可透過 [ITextFrame.getParentShape](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/itextframe/#getParentShape--) 追溯至其相關形狀，而 [ITextFrame.getParentCell](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/itextframe/#getParentCell--) 會傳回 `null`。因此，範例中的形狀分支亦會處理 SmartArt 節點的文字。

## **使用回呼收集匹配資訊**

實作 [IFindResultCallback](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ifindresultcallback/) 可於每次匹配時收到通知。其 [IFindResultCallback.foundResult](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ifindresultcallback/#foundResult-com.aspose.slides.ITextFrame-java.lang.String-java.lang.String-int-) 方法會提供相關的文字框、來源文字、匹配文字以及匹配位置。

回呼不會直接收到投影片編號。下面的實作會從父投影片推導編號，並同時處理投影片備註中的文字。可為 `null` 的 `Integer` 允許相同的結果模型也能代表其他類型的投影片。

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

對於取代操作，`foundText` 包含原始的匹配文字，回呼因此能精確記錄哪些詞彙被取代。

## **標示文字**

使用 [ITextFrame.highlightText](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/itextframe/#highlightText-java.lang.String-java.awt.Color-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) 方法在文字框中突顯純文字匹配。傳入 [TextSearchOptions](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/textsearchoptions/) 以控制搜尋，並提供回呼以收集匹配細節。

以下程式碼範例先突顯所有 **"try"** 字元，接著僅突顯完整單字 **"to"**。兩次搜尋皆將匹配結果回報給同一個回呼。

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

    // 在文字框中突顯每一次出現的「try」。
    shape.getTextFrame().highlightText("try", substringHighlightColor, substringSearchOptions, callback);

    TextSearchOptions wholeWordSearchOptions = new TextSearchOptions();
    wholeWordSearchOptions.setWholeWordsOnly(true);
    wholeWordSearchOptions.setCaseSensitive(false);
    Color wholeWordHighlightColor = new Color(238, 130, 238);

    // 僅標示完整單字「to」。
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

![已標示的文字](highlighted_text.png)

## **使用正規表達式標示文字**

[ITextFrame.highlightRegex](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/itextframe/#highlightRegex-java.util.regex.Pattern-java.awt.Color-com.aspose.slides.IFindResultCallback-) 方法會在文字框中突顯符合正規表達式的文字匹配。

以下程式碼突顯所有包含七個以上字元的單字，並收集每個匹配項目：

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

![使用正規表達式標示的文字](highlighted_text_using_regex.png)

## **跨簡報標示文字**

使用 [Presentation.highlightText](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/presentation/#highlightText-java.lang.String-java.awt.Color-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) 和 [Presentation.highlightRegex](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/presentation/#highlightRegex-java.util.regex.Pattern-java.awt.Color-com.aspose.slides.IFindResultCallback-) 搜尋簡報中所有適用的文字框。以下範例同時突顯一個純文字詞彙與所有電子郵件地址，並為兩個搜尋保留獨立的結果集合。

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

使用 [ITextFrame.replaceText](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/itextframe/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) 進行純文字取代，或使用 [ITextFrame.replaceRegex](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/itextframe/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) 進行基於模式的取代。這些方法會在現有文字框內更新匹配的文字，保留其周圍文字的格式，而不是以純字串重新建立文字框。

以下範例先統一拼寫變體，然後取代版本標籤。相同的回呼會記錄兩個操作匹配的原始詞彙。

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

如果一次匹配跨越不同格式的區段，請檢查輸出以確認替換文字應採用哪種格式。

## **跨簡報取代文字**

使用 [Presentation.replaceText](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/presentation/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) 和 [Presentation.replaceRegex](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/presentation/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) 在整個簡報上套用相同的操作。此功能適用於範本清理、術語更新與刪除。

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

## **分組匹配以進行報告**

由於每個結果都儲存了投影片編號與文字框，應用程式可以依照審核、報告或審閱工作流程將匹配結果分組。以下範例首先依投影片，再依文字框分組收集的結果：

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

**如何僅搜尋單一文字框而非整個簡報？**

取得形狀的文字框，然後對該文字框呼叫 [ITextFrame.highlightText](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/itextframe/#highlightText-java.lang.String-java.awt.Color-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-)、[ITextFrame.highlightRegex](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/itextframe/#highlightRegex-java.util.regex.Pattern-java.awt.Color-com.aspose.slides.IFindResultCallback-)、[ITextFrame.replaceText](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/itextframe/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) 或 [ITextFrame.replaceRegex](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/itextframe/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) 方法。簡報層級的方法則會處理所有適用的文字框。

**如何匹配完整單字且符合正確的大小寫？**

將 [TextSearchOptions.setWholeWordsOnly](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/textsearchoptions/#setWholeWordsOnly-boolean-) 與 [TextSearchOptions.setCaseSensitive](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/textsearchoptions/#setCaseSensitive-boolean-) 設為 `true`，並將這些選項傳遞給純文字的標示或取代方法。對於正規表達式，請在 Java `Pattern` 本身定義單字邊界與大小寫敏感性。

**搜尋與取代是否可包含投影片備註中的文字？**

可以。於簡報層級的純文字操作時，將 [TextSearchOptions.setIncludeNotes](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/textsearchoptions/#setIncludeNotes-boolean-) 設為 `true`。上述的回呼實作會將備註投影片中的匹配映射回其父投影片編號。

**如何在不再次掃描簡報的情況下產生報告？**

將 [IFindResultCallback](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ifindresultcallback/) 實作傳遞給標示或取代操作。回呼在操作執行期間即收到每個匹配，讓應用程式可以儲存來源文字、匹配文字、位置、文字框與衍生的投影片編號，供之後的分組或匯出使用。

**取代文字時是否保留其格式？**

[ITextFrame.replaceText](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/itextframe/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) 與 [ITextFrame.replaceRegex](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/itextframe/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) 會在現有文字框內修改匹配的文字，保留周圍文字的格式。若一次匹配跨越不同格式的區段，請檢查結果以確保替換使用的是期望的樣式。