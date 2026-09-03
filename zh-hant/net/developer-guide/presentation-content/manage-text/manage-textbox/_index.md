---
title: 在 .NET 中管理簡報的文字方塊
linktitle: 管理文字方塊
type: docs
weight: 20
url: /zh-hant/net/manage-textbox/
keywords:
- 文字方塊
- 文字框
- 新增文字
- 更新文字
- 建立文字方塊
- 檢查文字方塊
- 新增文字欄
- 新增超連結
- PowerPoint
- 簡報
- .NET
- C#
- Aspose.Slides
description: "使用 Aspose.Slides for .NET 在 PowerPoint 與 OpenDocument 簡報中建立、識別、格式化與更新文字方塊。"
---
## **簡介**

在 Aspose.Slides for .NET 中，投影片文字儲存在屬於圖形的文字框中。[IAutoShape](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/iautoshape/) 介面代表最常見的含文字圖形，並透過 [IAutoShape.TextFrame](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/iautoshape/textframe/) 屬性公開其文字。

{{% alert color="info" title="注意" %}}
每個自動圖形皆實作 [IShape](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ishape/)，但不是所有圖形都是自動圖形或支援文字框。處理現有簡報時，請先確認圖形實作 `IAutoShape`，再存取其文字。
{{% /alert %}}

## **在投影片上建立文字方塊**

要建立文字方塊，先將自動圖形加入投影片，於其文字框加入文字，然後儲存簡報。以下範例建立一個矩形文字方塊：

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var textBox = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 150, 75, 300, 50);
textBox.AddTextFrame("Aspose TextBox");

presentation.Save("TextBox.pptx", SaveFormat.Pptx);
```

傳遞給 [IShapeCollection.AddAutoShape](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ishapecollection/addautoshape/) 的座標與尺寸以點為單位。[IAutoShape.AddTextFrame](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/iautoshape/addtextframe/) 會以提供的文字初始化文字框。

## **檢查文字方塊圖形**

使用 [AutoShape.IsTextBox](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/autoshape/istextbox/) 屬性判斷自動圖形是否被視為文字方塊。當簡報同時包含含文字與純圖形的自動圖形時，此功能相當有用。

![文字方塊與圖形](istextbox.png)

以下範例檢查簡報中的每個自動圖形：

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var textBox = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 120, 40);
textBox.AddTextFrame("Text box");
slide.Shapes.AddAutoShape(ShapeType.Ellipse, 150, 10, 40, 40);

foreach (var currentSlide in presentation.Slides)
{
    foreach (var shape in currentSlide.Shapes)
    {
        if (shape is IAutoShape autoShape)
        {
            Console.WriteLine(autoShape.IsTextBox ? "The shape is a text box." : "The shape is not a text box.");
        }
    }
}
```

新加入的自動圖形在包含非空文字之前不會被視為文字方塊。您可以透過 [IAutoShape.AddTextFrame](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/iautoshape/addtextframe/) 或 [ITextFrame.Text](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/itextframe/text/) 提供文字。加入或指派空字串會使 `IsTextBox` 為 `false`：

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape1 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 100, 40);
shape1.AddTextFrame("Shape 1");
Console.WriteLine(shape1.IsTextBox);

var shape2 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 70, 100, 40);
shape2.TextFrame.Text = "Shape 2";
Console.WriteLine(shape2.IsTextBox);

var shape3 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 130, 100, 40);
shape3.AddTextFrame("");
Console.WriteLine(shape3.IsTextBox);

var shape4 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 190, 100, 40);
shape4.TextFrame.Text = "";
Console.WriteLine(shape4.IsTextBox);
```

前兩次呼叫會印出 `True`；後兩次則印出 `False`。

## **尋找擁有文字框的圖形**

通用文字處理程式碼可能收到一個 [ITextFrame](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/itextframe/)，卻不知道是哪個簡報物件擁有它。使用唯讀的 [ITextFrame.ParentShape](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/itextframe/parentshape/) 屬性可返回其擁有者的 [IShape](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ishape/)。

對於由自動圖形或其他含文字圖形擁有的文字框，`ParentShape` 包含所有者，而 [ITextFrame.ParentCell](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/itextframe/parentcell/) 為 `null`。在存取之前先檢查返回值。若需同時識別圖形與表格儲存格的擁有者（包括與 SmartArt 節點關聯的圖形），請參閱 [Search and Replace Text](/slides/zh-hant/net/search-and-replace-text/)。

## **在文字方塊中加入欄位**

[ITextFrameFormat.ColumnCount](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/itextframeformat/columncount/) 屬性將文字框分割成多個欄位，而 [ITextFrameFormat.ColumnSpacing](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/itextframeformat/columnspacing/) 則以點為單位設定欄位間的間距。這兩個設定皆屬於 [ITextFrameFormat](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/itextframeformat/)，可透過既有文字方塊的文字框進行變更。文字在同一圖形內的欄位之間重新流動；不會延伸至其他圖形。

以下範例建立一個三欄文字方塊，欄位間距為 10 點，儲存簡報，並從輸出檔案讀回儲存的設定：

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var textBox = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 300, 200);
textBox.AddTextFrame("This text is distributed automatically across all columns in the text box.");

var textFrameFormat = textBox.TextFrame.TextFrameFormat;
textFrameFormat.ColumnCount = 3;
textFrameFormat.ColumnSpacing = 10;

presentation.Save("TextBoxColumns.pptx", SaveFormat.Pptx);

using var savedPresentation = new Presentation("TextBoxColumns.pptx");
var savedTextBox = (IAutoShape)savedPresentation.Slides[0].Shapes[0];
var savedFormat = savedTextBox.TextFrame.TextFrameFormat;
Console.WriteLine($"Columns: {savedFormat.ColumnCount}; spacing: {savedFormat.ColumnSpacing} points");
```

## **從各單獨欄位擷取文字**

使用 [TextFrame.SplitTextByColumns](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/textframe/splittextbycolumns/) 可取得既有文字框中每個視覺欄位的文字。此方法會依欄位閱讀順序為每個欄位回傳一個字串。單欄文字框會產生僅含一個元素的陣列，空欄位則以空字串表示。回傳的字串僅包含純文字；不會保留片段層級的格式資訊。

此功能在以下情境特別有用：

- 在保留欄位閱讀順序的同時擷取文字。
- 索引或比較多欄投影片的內容。
- 將每個欄位匯出至獨立檔案、資料庫欄位或其他目的地。
- 檢查在變更 [ITextFrameFormat.ColumnCount](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/itextframeformat/columncount/)、[ITextFrameFormat.ColumnSpacing](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/itextframeformat/columnspacing/)、字型或文字框大小後，文字如何重新分配。

此方法僅報告目前 [ITextFrame](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/itextframe/) 內的文字分配情況，並不會自動在不同圖形或文字方塊之間流動文字。欄位分配可能受可用字型及其他文字排版設定影響，若結果一致性很重要，請確保必要的字型已安裝。

以下範例載入簡報，找到第一個具有多欄文字框的自動圖形，讀取其設定的欄位數，並將每個欄位的文字寫入獨立檔案。未提供文字框的圖形會被略過。

```csharp
using System;
using System.IO;
using Aspose.Slides;

using var presentation = new Presentation("MultiColumnText.pptx");

IAutoShape? textBox = null;
foreach (var shape in presentation.Slides[0].Shapes)
{
    if (shape is IAutoShape autoShape && autoShape.TextFrame is not null)
    {
        var columnCount = autoShape.TextFrame.TextFrameFormat.ColumnCount;
        if (columnCount > 1)
        {
            textBox = autoShape;
            break;
        }
    }
}

if (textBox is null)
{
    Console.WriteLine("No multi-column text frame was found.");
}
else
{
    var textFrame = textBox.TextFrame;
    var configuredColumnCount = textFrame.TextFrameFormat.ColumnCount;
    var columnTexts = textFrame.SplitTextByColumns();

    Console.WriteLine($"Configured columns: {configuredColumnCount}");

    for (var columnIndex = 0; columnIndex < columnTexts.Length; columnIndex++)
    {
        var columnNumber = columnIndex + 1;
        var columnText = columnTexts[columnIndex];
        Console.WriteLine($"Column {columnNumber}: {columnText}");
        File.WriteAllText($"Column-{columnNumber}.txt", columnText);
    }
}
```

## **更新文字**

要在整個簡報中更新文字，遍歷投影片與圖形，選取自動圖形，然後編輯其文字片段。以片段層級操作可同時變更文字與字元格式。

以下範例將自動圖形文字中的所有 `years` 替換為 `months`，並將受影響的片段設為粗體：

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("Text.pptx");

foreach (var slide in presentation.Slides)
{
    foreach (var shape in slide.Shapes)
    {
        if (shape is not IAutoShape autoShape)
        {
            continue;
        }

        foreach (var paragraph in autoShape.TextFrame.Paragraphs)
        {
            foreach (var portion in paragraph.Portions)
            {
                portion.Text = portion.Text.Replace("years", "months");
                portion.PortionFormat.FontBold = NullableBool.True;
            }
        }
    }
}

presentation.Save("TextChanged.pptx", SaveFormat.Pptx);
```

此遍歷僅會更新自動圖形中的文字。儲存在表格、圖表、SmartArt 或群組圖形中的文字，需要遍歷這些物件各自的集合。

## **加入帶有超連結的文字方塊**

超連結可以指派給特定的文字片段，只有該片段會成為可點擊的連結。使用 [IHyperlinkManager.SetExternalHyperlinkClick](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ihyperlinkmanager/setexternalhyperlinkclick/) 可將片段與外部 URL 相關聯。

以下範例建立帶有超連結的文字，並將其儲存至簡報：

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var textBox = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 150, 150, 200, 50);
textBox.AddTextFrame("Aspose.Slides");

var textPortion = textBox.TextFrame.Paragraphs[0].Portions[0];
textPortion.PortionFormat.HyperlinkManager.SetExternalHyperlinkClick("https://www.aspose.com/");

presentation.Save("Hyperlink.pptx", SaveFormat.Pptx);
```

## **常見問答**

**文字方塊與母片或版面投影片上的文字佔位區有何差異？**

[placeholder](/slides/zh-hant/net/manage-placeholder/) 可以從 [master slide](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/masterslide/) 或 [layout slide](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/layoutslide/) 繼承其位置與格式。一般的文字方塊則是建立所在投影片上的獨立圖形，版面變更時不會取得佔位區的行為。

**如何在不變更圖表、表格或 SmartArt 中文字的情況下取代文字？**

將遍歷限制於實作 `IAutoShape` 的圖形，如「更新文字」範例所示。圖表、表格與 SmartArt 皆在各自的物件模型中儲存文字，因而不會被該迴圈修改。