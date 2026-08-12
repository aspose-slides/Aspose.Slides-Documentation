---
title: 在 .NET 中搜尋並取代 PowerPoint 簡報的文字
linktitle: 搜尋並取代文字
type: docs
weight: 55
url: /zh-hant/net/search-and-replace-text/
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
- .NET
- C#
- Aspose.Slides
description: "使用 Aspose.Slides for .NET 在 PowerPoint 簡報中搜尋、標記並取代文字，同時收集每一次符合項目。"
---
## **概述**

Aspose.Slides for .NET 可在單一文字框或整個簡報中搜尋、標記以及取代文字。每項作業也可以透過結果回呼通知應用程式每一次的符合項目。這使得在更新簡報的同時，能夠建立包含符合文字、其情境、位置、文字框與投影片編號的稽核追蹤。

這些功能對於審閱、遮蔽、術語檢查、範本清理以及自動化報告工作流程都很有用。

在以下的第一個範例中，我們使用名為「sample.pptx」的檔案，該檔案在第一張投影片上包含一個文字方塊，內容如下：

![範例文字](sample_text.png)

## **選擇搜尋範圍**

使用 [ITextFrame](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/itextframe/) 上的方法可將作業限制在單一文字框。使用 [Presentation](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation/) 上的方法可處理簡報中所有適用的文字。

| 作業 | 單一文字框 | 整個簡報 |
|---|---|---|
| Highlight literal text | [ITextFrame.HighlightText](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/itextframe/highlighttext/) | [Presentation.HighlightText](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation/highlighttext/) |
| Highlight regular-expression matches | [ITextFrame.HighlightRegex](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/itextframe/highlightregex/) | [Presentation.HighlightRegex](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation/highlightregex/) |
| Replace literal text | [ITextFrame.ReplaceText](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/itextframe/replacetext/) | [Presentation.ReplaceText](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation/replacetext/) |
| Replace regular-expression matches | [ITextFrame.ReplaceRegex](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/itextframe/replaceregex/) | [Presentation.ReplaceRegex](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation/replaceregex/) |

## **設定文字比對**

對於純文字比對的作業，請使用 [TextSearchOptions](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/textsearchoptions/) 來控制比對方式：

- [TextSearchOptions.WholeWordsOnly](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/textsearchoptions/wholewordsonly/) 限制比對僅符合完整單字。
- [TextSearchOptions.CaseSensitive](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/textsearchoptions/casesensitive/) 控制是否必須符合字元大小寫。
- [TextSearchOptions.IncludeNotes](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/textsearchoptions/includenotes/) 在簡報層級的搜尋、取代與標記作業中，包含投影片備註。

正規表達式作業使用 .NET `Regex`，因此大小寫敏感度與單字邊界等比對規則由表達式本身及其選項定義。

## **使用回呼收集符合資訊**

實作 [IFindResultCallback](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ifindresultcallback/) 以接收每一次符合的通知。其 [IFindResultCallback.FoundResult](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ifindresultcallback/foundresult/) 方法會提供相關的文字框、來源文字、符合文字與符合位置。

回呼並不會直接取得投影片編號。以下實作會從父投影片衍生編號，並同時處理投影片備註中的文字。可為 null 的投影片編號允許相同的結果模型表示與其他投影片類型關聯的文字。

```cs
using System.Collections.Generic;
using Aspose.Slides;

public sealed class TextMatch
{
    public TextMatch(ITextFrame textFrame, string sourceText, string foundText, int textPosition, int? slideNumber)
    {
        TextFrame = textFrame;
        SourceText = sourceText;
        FoundText = foundText;
        TextPosition = textPosition;
        SlideNumber = slideNumber;
    }

    public ITextFrame TextFrame { get; }
    public string SourceText { get; }
    public string FoundText { get; }
    public int TextPosition { get; }
    public int? SlideNumber { get; }
}

public sealed class TextSearchCallback : IFindResultCallback
{
    public List<TextMatch> Results { get; } = new();

    public void FoundResult(ITextFrame textFrame, string sourceText, string foundText, int textPosition)
    {
        var slideNumber = GetSlideNumber(textFrame);
        var result = new TextMatch(textFrame, sourceText, foundText, textPosition, slideNumber);

        Results.Add(result);
    }

    private static int? GetSlideNumber(ITextFrame textFrame)
    {
        if (textFrame is not TextFrame concreteTextFrame)
        {
            return null;
        }

        var parentSlide = concreteTextFrame.Slide;

        if (parentSlide is ISlide slide)
        {
            return slide.SlideNumber;
        }

        if (parentSlide is INotesSlide notesSlide)
        {
            return notesSlide.ParentSlide.SlideNumber;
        }

        return null;
    }
}
```

對於取代作業，`FoundText` 包含原始符合文字，因此回呼可以精確記錄哪些詞彙被取代。

## **標記文字**

使用 [ITextFrame.HighlightText](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/itextframe/highlighttext/) 方法在文字框中標記純文字符合項目。傳入 [TextSearchOptions](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/textsearchoptions/) 以控制搜尋，並提供回呼以收集符合細節。

以下程式碼範例先標記所有 **"try"** 字元的出現，接著只標記完整單字 **"to"**。兩次搜尋皆將符合項目回報給同一個回呼。

```cs
using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");

// Get the first shape from the first slide.
var shape = (IAutoShape)presentation.Slides[0].Shapes[0];
var callback = new TextSearchCallback();

var substringSearchOptions = new TextSearchOptions
{
    CaseSensitive = false
};

// Highlight every occurrence of "try" in the text frame.
shape.TextFrame.HighlightText("try", Color.LightBlue, substringSearchOptions, callback);

var wholeWordSearchOptions = new TextSearchOptions
{
    WholeWordsOnly = true,
    CaseSensitive = false
};

// Highlight only the complete word "to".
shape.TextFrame.HighlightText("to", Color.Violet, wholeWordSearchOptions, callback);

foreach (var result in callback.Results)
{
    Console.WriteLine($"Found '{result.FoundText}' at position {result.TextPosition} on slide {result.SlideNumber}.");
}

presentation.Save("highlighted_text.pptx", SaveFormat.Pptx);
```

結果：

![已標記的文字](highlighted_text.png)

## **使用正規表示式標記文字**

[ITextFrame.HighlightRegex](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/itextframe/highlightregex/) 方法會在文字框中標記符合正規表示式的文字。

以下程式碼標記所有包含七個以上字元的單字，並收集每一次符合：

```cs
using System.Drawing;
using System.Text.RegularExpressions;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");

var shape = (IAutoShape)presentation.Slides[0].Shapes[0];
var callback = new TextSearchCallback();
var regex = new Regex(@"\b[^\s]{7,}\b");

shape.TextFrame.HighlightRegex(regex, Color.Yellow, callback);

presentation.Save("highlighted_text_using_regex.pptx", SaveFormat.Pptx);
```

結果：

![使用正規表示式標記的文字](highlighted_text_using_regex.png)

## **跨簡報標記文字**

使用 [Presentation.HighlightText](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation/highlighttext/) 與 [Presentation.HighlightRegex](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation/highlightregex/) 可在簡報中搜尋所有適用的文字框。以下範例同時標記純文字詞彙與所有電子郵件地址，並為兩項搜尋保留各自的結果集合。

```cs
using System.Drawing;
using System.Text.RegularExpressions;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");

var termCallback = new TextSearchCallback();
var searchOptions = new TextSearchOptions
{
    WholeWordsOnly = true,
    CaseSensitive = false
};

presentation.HighlightText("confidential", Color.Orange, searchOptions, termCallback);

var emailCallback = new TextSearchCallback();
var emailRegex = new Regex(@"\b[A-Z0-9._%+-]+@[A-Z0-9.-]+\.[A-Z]{2,}\b", RegexOptions.IgnoreCase);

presentation.HighlightRegex(emailRegex, Color.Yellow, emailCallback);

presentation.Save("highlighted_presentation.pptx", SaveFormat.Pptx);
```

## **在文字框中取代文字**

使用 [ITextFrame.ReplaceText](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/itextframe/replacetext/) 處理純文字取代，使用 [ITextFrame.ReplaceRegex](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/itextframe/replaceregex/) 處理基於模式的取代。這些方法會在既有文字框內更新符合的文字，保留其前後區段的格式，而不是從純字串重新建立文字框。

以下範例先統一拼寫變體，接著取代版本標籤。同一個回呼會記錄兩項作業匹配的原始詞彙。

```cs
using System.Text.RegularExpressions;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");

var shape = (IAutoShape)presentation.Slides[0].Shapes[0];
var callback = new TextSearchCallback();
var searchOptions = new TextSearchOptions
{
    WholeWordsOnly = true,
    CaseSensitive = false
};

shape.TextFrame.ReplaceText("colour", "color", searchOptions, callback);

var versionRegex = new Regex(@"\bv\d+(?:\.\d+)*\b", RegexOptions.IgnoreCase);
shape.TextFrame.ReplaceRegex(versionRegex, "current version", callback);

presentation.Save("updated_text_frame.pptx", SaveFormat.Pptx);
```

如果一個符合項目跨越格式不同的區段，請檢查輸出以確認取代文字應使用哪種格式。

## **跨簡報取代文字**

使用 [Presentation.ReplaceText](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation/replacetext/) 與 [Presentation.ReplaceRegex](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation/replaceregex/) 可在整個簡報套用相同的作業。此功能適用於範本清理、術語更新與遮蔽。

```cs
using System.Text.RegularExpressions;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");

var callback = new TextSearchCallback();
var searchOptions = new TextSearchOptions
{
    WholeWordsOnly = true,
    CaseSensitive = true
};

presentation.ReplaceText("Contoso", "Example Corp", searchOptions, callback);

var accountNumberRegex = new Regex(@"\bACCT-\d{6}\b");
presentation.ReplaceRegex(accountNumberRegex, "ACCT-REDACTED", callback);

presentation.Save("updated_presentation.pptx", SaveFormat.Pptx);
```

## **彙總符合項目以供報告**

因為每筆結果都儲存了投影片編號與文字框，應用程式可以依據審核、報告或檢閱工作流程將符合項目分組。以下範例先依投影片，再依文字框分組已收集的結果：

```cs
using System;
using System.Linq;

var matchesBySlide = callback.Results.GroupBy(result => result.SlideNumber);

foreach (var slideGroup in matchesBySlide)
{
    var slideLabel = slideGroup.Key.HasValue ? slideGroup.Key.Value.ToString() : "Other";
    Console.WriteLine($"Slide: {slideLabel}");

    var matchesByTextFrame = slideGroup.GroupBy(result => result.TextFrame);
    foreach (var textFrameGroup in matchesByTextFrame)
    {
        Console.WriteLine($"  Text frame: {textFrameGroup.Key.Text}");

        foreach (var result in textFrameGroup)
        {
            Console.WriteLine($"    '{result.FoundText}' at position {result.TextPosition}; context: '{result.SourceText}'");
        }
    }
}
```

## **常見問題**

**如何只搜尋單一文字框而非整個簡報？**

取得圖形的文字框，並對該文字框呼叫 [ITextFrame.HighlightText](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/itextframe/highlighttext/)、[ITextFrame.HighlightRegex](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/itextframe/highlightregex/)、[ITextFrame.ReplaceText](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/itextframe/replacetext/)，或 [ITextFrame.ReplaceRegex](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/itextframe/replaceregex/)。簡報層級的方法則會處理所有適用的文字框。

**如何匹配完整單字且符合正確大小寫？**

將 [TextSearchOptions.WholeWordsOnly](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/textsearchoptions/wholewordsonly/) 與 [TextSearchOptions.CaseSensitive](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/textsearchoptions/casesensitive/) 設為 `true`，並將這些選項傳遞給純文字的標記或取代方法。對於正規表示式，請在 .NET `Regex` 本身定義單字邊界與大小寫敏感度。

**搜尋與取代可以包含投影片備註中的文字嗎？**

可以。於使用簡報層級的純文字作業時，將 [TextSearchOptions.IncludeNotes](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/textsearchoptions/includenotes/) 設為 `true`。上述回呼實作會將備註投影片中的符合項目映射回其父投影片編號。

**如何在不再次掃描簡報的情況下產生報告？**

將 [IFindResultCallback](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ifindresultcallback/) 實作傳遞給標記或取代作業。回呼在作業執行時即接收每一次符合，允許應用程式儲存來源文字、符合文字、位置、文字框與衍生的投影片編號，稍後再進行分組或匯出。

**取代文字時會保留其格式嗎？**

[ITextFrame.ReplaceText](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/itextframe/replacetext/) 與 [ITextFrame.ReplaceRegex](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/itextframe/replaceregex/) 會在既有文字框內修改符合的文字，並保留其前後區段的格式。如果符合項目跨越格式不同的區段，請檢查結果以確保取代文字使用所需的樣式。