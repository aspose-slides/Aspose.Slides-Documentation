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

在 Aspose.Slides for .NET 中，投影片文字儲存在屬於形狀的文字框中。 [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) 介面代表最常見的帶文字形狀，並透過其 [IAutoShape.TextFrame](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/textframe/) 屬性公開文字。

{{% alert color="info" title="Note" %}}
每個自動形狀都實作 [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape/)，但並非所有形狀都是自動形狀或支援文字框。處理現有簡報時，請先檢查形狀是否實作 `IAutoShape`，再存取其文字。
{{% /alert %}}

## **在投影片上建立文字方塊**

要建立文字方塊，先在投影片上新增自動形狀，將文字加入其文字框，然後儲存簡報。以下範例建立一個矩形文字方塊：

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var textBox = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 150, 75, 300, 50);
textBox.AddTextFrame("Aspose TextBox");

presentation.Save("TextBox.pptx", SaveFormat.Pptx);
```

傳遞給 [IShapeCollection.AddAutoShape](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addautoshape/) 的座標與尺寸以點為單位。[IAutoShape.AddTextFrame](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/addtextframe/) 會以提供的文字初始化文字框。

## **檢查文字方塊形狀**

使用 [AutoShape.IsTextBox](https://reference.aspose.com/slides/net/aspose.slides/autoshape/istextbox/) 屬性判斷自動形狀是否被視為文字方塊。當簡報同時包含帶文字與純圖形的自動形狀時，這很有用。

![文字方塊與形狀](istextbox.png)

以下範例檢查簡報中每個自動形狀：

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

新加入的自動形狀在未包含非空文字時不會被視為文字方塊。您可以透過 [IAutoShape.AddTextFrame](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/addtextframe/) 或 [ITextFrame.Text](https://reference.aspose.com/slides/net/aspose.slides/itextframe/text/) 提供文字。加入或指派空字串會使 `IsTextBox` 為 `false`：

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

前兩次呼叫會輸出 `True`；後兩次會輸出 `False`。

## **找出擁有文字框的形狀**

一般的文字處理程式碼可能會取得 [ITextFrame](https://reference.aspose.com/slides/net/aspose.slides/itextframe/)，但不知道它屬於哪個簡報物件。使用唯讀的 [ITextFrame.ParentShape](https://reference.aspose.com/slides/net/aspose.slides/itextframe/parentshape/) 屬性可回溯到其擁有的 [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape/)。

若文字框屬於自動形狀或其他帶文字形狀，`ParentShape` 會包含擁有者，而 [ITextFrame.ParentCell](https://reference.aspose.com/slides/net/aspose.slides/itextframe/parentcell/) 為 `null`。在存取前請先檢查回傳值。若要辨識形狀與表格儲存格的擁有者（包含與 SmartArt 節點相關的形狀），請參考 [搜尋與取代文字](/slides/zh-hant/net/search-and-replace-text/)。

## **取得形狀的文字矩形**

自 Aspose.Slides for .NET 26.11 版起，[ITextFrame.GetTextRect](https://reference.aspose.com/slides/net/aspose.slides/itextframe/gettextrect/) 會回傳由父形狀幾何定義的文字區域。其座標與尺寸以點為單位，相對於該形狀的左上角。例如，橢圓的文字矩形比其外圍更小。

此矩形描述形狀本身，而非實際呈現的字元。變更文字或文字框邊距不會使其成為已佔用文字的測量。請使用 [段落邊界](/slides/zh-hant/net/paragraph-bounds/) 或 [區段邊界](/slides/zh-hant/net/portion-bounds/) 取得渲染文字的測量值。

在 [安裝 Aspose.Slides for .NET](/slides/zh-hant/net/installation/) 26.11 或之後的版本安裝完成後，執行此範例以紅色繪製幾何文字矩形。形狀未旋轉且未群組，只需加上它們的 X/Y 位置即可將覆蓋層放置於投影片上。

```csharp
using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

foreach (var shapeType in new[] { ShapeType.Rectangle, ShapeType.Ellipse })
{
    var x = shapeType == ShapeType.Rectangle ? 50 : 300;
    var shape = slide.Shapes.AddAutoShape(shapeType, x, 200, 200, 100);
    shape.AddTextFrame("Text area");
    var rectangle = shape.TextFrame.GetTextRect();
    Console.WriteLine($"{shapeType}: {rectangle}");

    var overlayX = shape.X + rectangle.X;
    var overlayY = shape.Y + rectangle.Y;
    var outline = slide.Shapes.AddAutoShape(ShapeType.Rectangle, overlayX, overlayY, rectangle.Width, rectangle.Height);
    outline.FillFormat.FillType = FillType.NoFill;
    outline.LineFormat.FillFormat.FillType = FillType.Solid;
    outline.LineFormat.FillFormat.SolidFillColor.Color = Color.Red;
}

presentation.Save("text-rectangles.pptx", SaveFormat.Pptx);
```

對於上述 200 × 100 點的形狀，矩形會回傳 `(0, 0, 200, 100)`；橢圓則約為 `(29.289, 14.645, 141.421, 70.711)`。此方法亦會讀取自訂幾何聲明的文字矩形。它不會套用投影片空間的旋轉或群組變換；在定位覆蓋層時需自行考慮這些因素。沒有幾何形狀的文字框（例如表格儲存格文字框）可能拋出 `InvalidOperationException`。

## **在文字方塊中加入欄**

[ITextFrameFormat.ColumnCount](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/columncount/) 屬性將文字框分割為多個欄，而 [ITextFrameFormat.ColumnSpacing](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/columnspacing/) 則以點為單位設定欄與欄之間的間距。這兩個設定皆屬於 [ITextFrameFormat](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/)，可透過既有文字方塊的文字框進行變更。文字會在同一形狀內的欄之間重新排版；不會流至其他形狀。

以下範例建立一個三欄文字方塊，欄間距為 10 點，儲存簡報，並從輸出檔案讀回設定值：

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

## **從個別欄位擷取文字**

使用 [TextFrame.SplitTextByColumns](https://reference.aspose.com/slides/net/aspose.slides/textframe/splittextbycolumns/) 取得現有文字框中每個可視欄位的文字。此方法會依欄位閱讀順序為每個欄位回傳一個字串。單欄文字框會產生僅含一個元素的陣列，空欄位則以空字串表示。回傳的字串僅包含純文字；不會保留區段層級的格式設定。

當您需要以下情況時此功能很有用：
- 在保留欄位閱讀順序的同時擷取文字。
- 為多欄投影片的內容建立索引或進行比較。
- 將每個欄位匯出至個別檔案、資料庫欄位或其他目的地。
- 檢查在變更 [ITextFrameFormat.ColumnCount](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/columncount/)、[ITextFrameFormat.ColumnSpacing](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/columnspacing/)、字型或文字框大小後，文字如何重新分配。

此方法回報目前 [ITextFrame](https://reference.aspose.com/slides/net/aspose.slides/itextframe/) 內的文字分布；不會自動在不同形狀或文字方塊之間流動文字。欄位分佈可能受可用字型及其他文字版面設定影響，因此在需要一致結果時，請確保所需字型可用。

以下範例載入簡報，找到第一個具有文字框的多欄自動形狀，讀取其設定的欄數，並將每個欄位的文字寫入個別檔案。不提供文字框的形狀會被略過。

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

要在整個簡報中更新文字，可遍歷投影片與形狀，挑選自動形狀，然後編輯其文字區段。在區段層級作業可同時變更文字與字元格式設定。

以下範例將自動形狀文字中所有出現的 `years` 替換為 `months`，並將每個受影響的區段設為粗體：

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

此遍歷僅會更新自動形狀中的文字。儲存在表格、圖表、SmartArt 或群組形狀中的文字則需遍歷那些物件各自的集合。

## **加入帶有超連結的文字方塊**

超連結可以指派給特定的文字區段，只有該文字會成為可點擊的連結。使用 [IHyperlinkManager.SetExternalHyperlinkClick](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkmanager/setexternalhyperlinkclick/) 將區段與外部 URL 間關聯。

以下範例建立連結文字並儲存至簡報：

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

## **常見問題**

**文字方塊與母片或版面投影片上的文字佔位符有何差異？**

[A佔位符](/slides/zh-hant/net/manage-placeholder/) 可以從 [母片](https://reference.aspose.com/slides/net/aspose.slides/masterslide/) 或 [版面投影片](https://reference.aspose.com/slides/net/aspose.slides/layoutslide/) 繼承其位置與格式。一般的文字方塊是創建於投影片上的獨立形狀，當版面變更時不會取得佔位符的行為。

**如何在不更改圖表、表格或 SmartArt 文字的情況下取代文字？**

將遍歷限制於實作 [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) 的形狀，如同在「更新文字」範例所示。圖表、表格與 SmartArt 會在各自的物件模型中儲存文字，因此不會被該迴圈修改。