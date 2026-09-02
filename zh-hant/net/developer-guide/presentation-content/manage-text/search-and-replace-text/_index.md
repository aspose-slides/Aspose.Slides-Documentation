---
title: 在 .NET 中搜尋與取代 PowerPoint 簡報文字
linktitle: 搜尋與取代文字
type: docs
weight: 55
url: /zh-hant/net/search-and-replace-text/
keywords:
- 搜尋文字
- 突出顯示文字
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
description: "在 PowerPoint 簡報中搜尋、突出顯示與取代文字，並使用 Aspose.Slides for .NET 收集所有匹配項目。"
---
## **概述**

Aspose.Slides for .NET 可以在單一文字框或整份簡報中搜尋、突出顯示與取代文字。每項作業亦可透過結果回呼通知應用程式每一次匹配。此機制讓您在更新簡報的同時，建立包含匹配文字、其上下文、位置、文字框與投影片編號的稽核追蹤。

這些功能在審閱、遮蔽、術語檢查、範本清理與自動化報表工作流程中非常實用。

在以下範例中，我們使用名為 **"sample.pptx"** 的檔案，其第一張投影片上有一個文字方塊，內容如下：

![範例文字](sample_text.png)

## **選擇搜尋範圍**

使用 [ITextFrame](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/itextframe/) 上的方法將作業限制於單一文字框。使用 [Presentation](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation/) 上的方法則可處理簡報中所有適用的文字。

| 操作 | 單一文字框 | 整個簡報 |
|---|---|---|
| 突出顯示文字字面值 | [ITextFrame.HighlightText](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/itextframe/highlighttext/) | [Presentation.HighlightText](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation/highlighttext/) |
| 突出顯示正規表達式匹配 | [ITextFrame.HighlightRegex](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/itextframe/highlightregex/) | [Presentation.HighlightRegex](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation/highlightregex/) |
| 取代文字字面值 | [ITextFrame.ReplaceText](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/itextframe/replacetext/) | [Presentation.ReplaceText](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation/replacetext/) |
| 取代正規表達式匹配 | [ITextFrame.ReplaceRegex](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/itextframe/replaceregex/) | [Presentation.ReplaceRegex](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation/replaceregex/) |

## **設定文字匹配**

對於文字字面值的作業，使用 [TextSearchOptions](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/textsearchoptions/) 來控制匹配行為：

- [TextSearchOptions.WholeWordsOnly](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/textsearchoptions/wholewordsonly/) 僅限完整詞彙的匹配。  
- [TextSearchOptions.CaseSensitive](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/textsearchoptions/casesensitive/) 控制是否必須匹配字元大小寫。  
- [TextSearchOptions.IncludeNotes](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/textsearchoptions/includenotes/) 在簡報層級的搜尋、取代與突出顯示作業中，包含投影片備註。

正規表達式作業使用 .NET `Regex`，因此大小寫敏感與單字邊界等規則由正則表達式本身與其選項決定。

## **辨識文字框的擁有者**

在搜尋、取代、驗證或匯出文字時，通用的文字處理工作流程常會收到一個 [ITextFrame](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/itextframe/)。使用 [ITextFrame.ParentShape](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/itextframe/parentshape/) 與 [ITextFrame.ParentCell](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/itextframe/parentcell/) 可判斷是哪個簡報物件擁有該文字框。

預期的值取決於擁有者：

| 文字框擁有者 | `ParentShape` | `ParentCell` |
|---|---|---|
| AutoShape 或其他包含文字的圖形 | 擁有的[IShape](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ishape/) | `null` |
| 表格儲存格 | `null` | 擁有的[ICell](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/icell/) |

這兩個屬性皆為唯讀導覽屬性。讀取它們不會搬移文字框或變更其擁有者。通用程式碼應同時檢查兩個值是否為 `null`，並處理兩者皆不可用的情況。

以下範例使用 [SlideUtil.GetAllTextFrames](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.util/slideutil/getalltextframes/) 逐一遍歷簡報中的文字框。對於圖形，會回報圖形名稱、圖形類型與所在投影片；對於表格儲存格，會回報零基礎的欄列座標與所在投影片。

```cs
using System;
using Aspose.Slides;
using Aspose.Slides.Util;

using var presentation = new Presentation("presentation.pptx");

var textFrames = SlideUtil.GetAllTextFrames(presentation, false);

foreach (var textFrame in textFrames)
{
    var ownerShape = textFrame.ParentShape;
    if (ownerShape != null)
    {
        var shapeName = string.IsNullOrEmpty(ownerShape.Name) ? "(unnamed)" : ownerShape.Name;
        var shapeType = GetShapeType(ownerShape);
        var slideLabel = GetSlideLabel(ownerShape.Slide);
        Console.WriteLine($"Shape: {shapeName}; type: {shapeType}; {slideLabel}");

        continue;
    }

    var ownerCell = textFrame.ParentCell;
    if (ownerCell != null)
    {
        var slideLabel = GetSlideLabel(ownerCell.Slide);
        Console.WriteLine($"Table cell: column {ownerCell.FirstColumnIndex}, row {ownerCell.FirstRowIndex}; {slideLabel}");
        continue;
    }

    Console.WriteLine("The text frame owner is not available as a shape or table cell.");
}

static string GetShapeType(IShape shape)
{
    if (shape is IGeometryShape geometryShape)
    {
        return geometryShape.ShapeType.ToString();
    }

    return shape.GetType().Name;
}

static string GetSlideLabel(IBaseSlide baseSlide)
{
    if (baseSlide is ISlide slide)
    {
        return $"slide {slide.SlideNumber}";
    }

    if (baseSlide is INotesSlide notesSlide)
    {
        return $"notes for slide {notesSlide.ParentSlide.SlideNumber}";
    }

    return baseSlide.GetType().Name;
}
```

對於 SmartArt 內容，可遍歷 [ISmartArtNode.Shapes](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.smartart/ismartartnode/shapes/) 中的圖形，並存取每個 [ISmartArtShape.TextFrame](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.smartart/ismartartshape/textframe/)。文字框可透過 [ITextFrame.ParentShape](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/itextframe/parentshape/) 追溯到其關聯圖形，而 [ITextFrame.ParentCell](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/itextframe/parentcell/) 為 `null`。因此，範例中的圖形分支亦會處理 SmartArt 節點的文字。

## **使用回呼收集匹配資訊**

實作 [IFindResultCallback](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ifindresultcallback/) 以在每一次匹配時接收通知。其 [IFindResultCallback.FoundResult](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ifindresultcallback/foundresult/) 方法會提供相關的文字框、來源文字、匹配文字以及匹配位置。

回呼本身不會直接取得投影片編號。下方實作從父投影片衍生編號，並同時處理投影片備註中的文字。可為 `null` 的投影片編號允許相同的結果模型同時表示其他投影片類型的文字。

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
        var parentSlide = textFrame.ParentShape?.Slide ?? textFrame.ParentCell?.Slide ?? textFrame.Slide;

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

對於取代作業，`FoundText` 仍保留原始匹配文字，因而回呼可以精確記錄哪些詞彙被取代。

## **突出顯示文字**

使用 [ITextFrame.HighlightText](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/itextframe/highlighttext/) 方法在文字框中突出顯示文字字面值匹配。傳入 [TextSearchOptions] 以控制搜尋行為，並提供回呼以收集匹配細節。

下方程式碼範例先突出顯示所有 **"try"** 字元，接著只突出顯示完整單字 **"to"**。兩次搜尋皆會將匹配結果報送至相同的回呼。

```cs
using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");

// 從第一張投影片取得第一個圖形。
var shape = (IAutoShape)presentation.Slides[0].Shapes[0];
var callback = new TextSearchCallback();

var substringSearchOptions = new TextSearchOptions
{
    CaseSensitive = false
};

// 突出顯示文字框中所有出現的 "try"。
shape.TextFrame.HighlightText("try", Color.LightBlue, substringSearchOptions, callback);

var wholeWordSearchOptions = new TextSearchOptions
{
    WholeWordsOnly = true,
    CaseSensitive = false
};

// 僅突出顯示完整的字詞 "to"。
shape.TextFrame.HighlightText("to", Color.Violet, wholeWordSearchOptions, callback);

foreach (var result in callback.Results)
{
    Console.WriteLine($"Found '{result.FoundText}' at position {result.TextPosition} on slide {result.SlideNumber}.");
}

presentation.Save("highlighted_text.pptx", SaveFormat.Pptx);
```

結果：

![突出顯示的文字](highlighted_text.png)

## **使用正規表達式突出顯示文字**

[ITextFrame.HighlightRegex](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/itextframe/highlightregex/) 方法會在文字框中突出顯示由正規表達式找到的文字匹配。

以下程式碼會突出顯示所有包含七個或以上字元的單字，並收集每一次匹配：

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

![使用正規表達式突出顯示的文字](highlighted_text_using_regex.png)

## **跨簡報突出顯示文字**

使用 [Presentation.HighlightText](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation/highlighttext/) 與 [Presentation.HighlightRegex](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation/highlightregex/) 可在簡報中所有適用的文字框執行搜尋。下例同時突出顯示一個文字字面值與所有電子郵件地址，並為兩個搜尋保留分開的結果集合。

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

使用 [ITextFrame.ReplaceText](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/itextframe/replacetext/) 處理文字字面值取代，使用 [ITextFrame.ReplaceRegex](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/itextframe/replaceregex/) 處理基於模式的取代。這些方法會在既有文字框內直接更新匹配文字，保留其周圍部分的格式，而不是以純文字重新建構文字框。

以下範例先統一拼寫變體，接著取代版本標記。相同的回呼會記錄兩項作業匹配到的原始詞彙。

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

如果一次匹配跨越了格式不同的段落，請檢查輸出以確認替換文字應採用哪種格式。

## **跨簡報取代文字**

使用 [Presentation.ReplaceText](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation/replacetext/) 與 [Presentation.ReplaceRegex](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation/replaceregex/) 可在整份簡報中套用相同的取代操作。這在範本清理、術語更新與遮蔽時相當有用。

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

## **將匹配結果分組以供報告**

因為每個結果都儲存了投影片編號與文字框，應用程式可以依照審核、報告或審閱工作流程將匹配結果分組。以下範例先依投影片，再依文字框分組收集到的結果：

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

取得圖形的文字框，然後在該文字框上呼叫 [ITextFrame.HighlightText](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/itextframe/highlighttext/)、[ITextFrame.HighlightRegex](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/itextframe/highlightregex/)、[ITextFrame.ReplaceText](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/itextframe/replacetext/) 或 [ITextFrame.ReplaceRegex](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/itextframe/replaceregex/)。簡報層級的方法則會處理所有適用的文字框。

**如何匹配完整的單字且保持正確的大小寫？**

將 [TextSearchOptions.WholeWordsOnly](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/textsearchoptions/wholewordsonly/) 與 [TextSearchOptions.CaseSensitive](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/textsearchoptions/casesensitive/) 設為 `true`，並將選項傳遞給文字字面值的突出顯示或取代方法。對於正規表達式，請在 .NET `Regex` 本身定義單字邊界與大小寫敏感性。

**搜尋與取代可以包含投影片備註中的文字嗎？**

可以。於簡報層級的文字字面值作業中，將 [TextSearchOptions.IncludeNotes](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/textsearchoptions/includenotes/) 設為 `true`。上述的回呼實作會將備註投影片中的匹配映射回其父投影片編號。

**如何在不再次掃描簡報的情況下建立報告？**

將 [IFindResultCallback](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ifindresultcallback/) 實作傳遞給突出顯示或取代作業。回呼會在作業執行期間即時收到每一次匹配，允許應用程式儲存來源文字、匹配文字、位置、文字框以及衍生出的投影片編號，之後再進行分組或匯出。

**取代文字時會保留其格式嗎？**

[ITextFrame.ReplaceText](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/itextframe/replacetext/) 與 [ITextFrame.ReplaceRegex](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/itextframe/replaceregex/) 會在既有文字框內直接修改匹配文字，並保留周圍部分的格式。如果一次匹配跨越了格式不同的段落，請檢查結果以確保替換使用了所需的樣式。