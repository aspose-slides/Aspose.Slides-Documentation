---
title: 在 .NET 中管理簡報佔位符
linktitle: 管理佔位符
type: docs
weight: 10
url: /zh-hant/net/manage-placeholder/
keywords:
- 佔位符
- 文字佔位符
- 圖片佔位符
- 圖表佔位符
- 內容佔位符
- 提示文字
- PowerPoint
- 簡報
- .NET
- C#
- Aspose.Slides
description: "了解如何使用 Aspose.Slides for .NET 檢查與編輯文字、圖片、圖表與內容佔位符，並理解佔位符的繼承關係。"
---
## **概覽**

佔位符是一種形狀，用於在簡報範本中保留特定類型內容的位置。常見的範例包括標題、內文、圖片、圖表，以及通用內容佔位符。與普通形狀不同，佔位符可以從版面投影片或母片繼承其位置、大小、格式以及其他設定。

Aspose.Slides 透過 [IShape.Placeholder](https://reference.aspose.com/slides/net/aspose.slides/ishape/placeholder/) 屬性提供佔位符資訊。該屬性會傳回一個 [IPlaceholder](https://reference.aspose.com/slides/net/aspose.slides/iplaceholder/) 物件，若是普通形狀則傳回 `null`。使用 [IPlaceholder.Type](https://reference.aspose.com/slides/net/aspose.slides/iplaceholder/type/) 可判斷佔位符預期包含的內容類型。

了解佔位符類型後，形狀介面仍然很重要：

- 空的文字、圖片、圖表或內容佔位符通常以 [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) 表示。
- 已填入圖片的佔位符可以以 [IPictureFrame](https://reference.aspose.com/slides/net/aspose.slides/ipictureframe/) 表示。
- 已填入圖表的佔位符可以以 [IChart](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/) 表示。
- 內容佔位符可以包含多種內容。請同時檢查 [IPlaceholder.Type](https://reference.aspose.com/slides/net/aspose.slides/iplaceholder/type/) 與執行時的形狀介面，勿假設每個佔位符都是 [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/)。

{{% alert color="warning" title="Warning" %}}
[IPlaceholder.Type](https://reference.aspose.com/slides/net/aspose.slides/iplaceholder/type/) 只描述佔位符的角色；它並不保證形狀的執行時類型。存取文字、圖片、圖表、表格或媒體相關成員前，必須先進行類型檢查。
{{% /alert %}}

## **了解佔位符繼承**

佔位符形成層級結構：

1. 母片定義可重複使用的樣式，並在某些情況下提供母片層級的佔位符。
2. 版面投影片定義供一張或多張普通投影片使用的排列，且可從母片繼承。
3. 普通投影片包含該投影片的佔位符，並可從其版面繼承。

呼叫 [IShape.GetBasePlaceholder](https://reference.aspose.com/slides/net/aspose.slides/ishape/getbaseplaceholder/) 可向上移動一層層級。投影片佔位符通常會傳回其版面佔位符；版面佔位符則可傳回其母片佔位符。若形狀沒有基礎佔位符，該方法會傳回 `null`。

以下範例列出第一張投影片上的佔位符，並回報其基礎佔位符：

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("template.pptx");
var slide = presentation.Slides[0];

foreach (var shape in slide.Shapes)
{
    if (shape.Placeholder == null)
    {
        continue;
    }

    var placeholderType = shape.Placeholder.Type;
    var typeName = shape.GetType().Name;
    Console.WriteLine($"Slide placeholder: {placeholderType}; shape interface: {typeName}");

    var layoutPlaceholder = shape.GetBasePlaceholder();
    if (layoutPlaceholder != null)
    {
        var layoutPlaceholderType = layoutPlaceholder.Placeholder?.Type;
        Console.WriteLine($"  Layout placeholder: {layoutPlaceholderType}");

        var masterPlaceholder = layoutPlaceholder.GetBasePlaceholder();
        if (masterPlaceholder != null)
        {
            var masterPlaceholderType = masterPlaceholder.Placeholder?.Type;
            Console.WriteLine($"  Master placeholder: {masterPlaceholderType}");
        }
    }
}
```

編輯普通投影片上的佔位符會為該投影片建立或變更本機覆寫。編輯相關的版面或母片則可能影響仍然繼承該設定的所有投影片。普通的本機形狀沒有基礎佔位符，也不會僅因為佔據相同座標而開始繼承。

## **移除佔位符狀態**

在調整範本時，使用 [IShape.RemovePlaceholder](https://reference.aspose.com/slides/net/aspose.slides/ishape/removeplaceholder/) 可將現有物件保留為普通形狀。它的 [Placeholder](https://reference.aspose.com/slides/net/aspose.slides/ishape/placeholder/) 屬性會變為 `null`，但形狀仍在投影片集合中。相較之下，[IShapeCollection.Remove](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/remove/) 會從該集合中刪除形狀。

以下範例需要一個包含至少一張投影片且第一張投影片上有非空文字佔位符的 `template.pptx`。使用從版面或母片繼承格式的佔位符，以觀察移除關聯的效果。範例會檢查相同的形狀仍然存在，再對已成為普通形狀的物件再次呼叫此方法，最後儲存結果。

{{% alert color="warning" title="Warning" %}}
移除佔位符狀態不會自動保留繼承的外觀設定。以下範例刻意保留這些設定不變，因而輸出可能看起來不同。若位置與大小完全繼承，呼叫後可能會得到座標與尺寸皆為零的形狀，雖仍在集合中卻會變得不可見。
{{% /alert %}}

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("template.pptx");
var slide = presentation.Slides[0];
var found = false;

for (var index = 0; index < slide.Shapes.Count; index++)
{
    if (slide.Shapes[index] is not IAutoShape shape || 
        shape.Placeholder == null || 
        string.IsNullOrEmpty(shape.TextFrame?.Text))
    {
        continue;
    }

    var shapeCount = slide.Shapes.Count;
    shape.RemovePlaceholder();

    Console.WriteLine($"Placeholder removed: {shape.Placeholder == null}");
    Console.WriteLine($"Same shape retained: {ReferenceEquals(slide.Shapes[index], shape)}");
    Console.WriteLine($"Shape count unchanged: {slide.Shapes.Count == shapeCount}");

    // 在普通形狀上呼叫此方法不會產生任何效果。
    shape.RemovePlaceholder();
    found = true;
    break;
}

if (found)
{
    presentation.Save("placeholder-status-removed.pptx", SaveFormat.Pptx);
}
else
{
    Console.WriteLine("No nonempty text placeholder was found on the first slide.");
}
```

對於匹配的佔位符，三項檢查皆會印出 `True`。文字仍會保留，但繼承的座標、大小、旋轉、字型、段落對齊、文字框邊距、垂直錨點、填色與線條設定在移除佔位符關係後可能會變更。例如，繼承的標題格式可能會退回普通文字格式。請參閱 [Slide Layout](/slides/zh-hant/net/slide-layout/) 以了解更多版面相關內容。

若要保留預期的外觀，請在呼叫之前捕獲解析後的位置、大小與旋轉，並將必要的有效格式值複製到獨立變數。可透過 [IPortionFormat.GetEffective](https://reference.aspose.com/slides/net/aspose.slides/iportionformat/geteffective/)、[IParagraphFormat.GetEffective](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/geteffective/)、[ITextFrameFormat.GetEffective](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/geteffective/)、[IFillFormat.GetEffective](https://reference.aspose.com/slides/net/aspose.slides/ifillformat/geteffective/)、[ILineFormat.GetEffective](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/geteffective/) 取得這些值。不要僅依賴有效格式物件，因為在移除關係後其文字格式值可能會改變。之後必須明確將捕獲的值套用回普通形狀，包括字型族、大小、樣式、顏色、段落設定、文字框設定、填色與線條等。

繼承的形狀幾何也可能需要透過 [IGeometryShape.ShapeType](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/shapetype/) 明確指派。對於矩形文字佔位符，這意味著指定 [ShapeType.Rectangle](https://reference.aspose.com/slides/net/aspose.slides/shapetype/)；僅恢復填色與線條可能無法還原可見的矩形。具備額外效果或較複雜格式的範本亦需同樣處理這些設定。

## **變更佔位符中的文字**

標題、置中標題、副標題、內文與文字佔位符通常支援文字。使用前請先檢查是否為 [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/)，再存取其 [TextFrame](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/textframe/) 屬性。

以下範例更新第一張投影片上的第一個標題佔位符，並儲存結果：

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("template.pptx");
var slide = presentation.Slides[0];
IAutoShape? titleShape = null;

foreach (var shape in slide.Shapes)
{
    if (shape is not IAutoShape autoShape || autoShape.Placeholder == null)
    {
        continue;
    }

    var placeholderType = autoShape.Placeholder.Type;
    if (placeholderType == PlaceholderType.Title || placeholderType == PlaceholderType.CenteredTitle)
    {
        titleShape = autoShape;
        break;
    }
}

if (titleShape == null)
{
    throw new InvalidOperationException("The first slide does not contain a title placeholder.");
}

titleShape.TextFrame.Text = "Quarterly Business Review";
presentation.Save("title-placeholder-updated.pptx", SaveFormat.Pptx);
```

此模式避免將圖片、圖表、表格或媒體佔位符強制轉型為 [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/)。同時也以用途辨識佔位符，而非依賴脆弱的形狀索引。

## **在版面上設定提示文字**

提示文字是在空佔位符中顯示的設計時說明，例如 *Click to add title*。請在版面佔位符上設定自訂提示文字，而不是透過普通投影片的形狀集合去存取。可透過 [ISlide.LayoutSlide](https://reference.aspose.com/slides/net/aspose.slides/islide/layoutslide/) 取得版面，並遍歷 [ILayoutSlide.Shapes](https://reference.aspose.com/slides/net/aspose.slides/ibaseslide/shapes/)。

以下範例變更第一張投影片使用的版面上的標題與副標題提示文字：

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("template.pptx");
var layoutSlide = presentation.Slides[0].LayoutSlide;

foreach (var shape in layoutSlide.Shapes)
{
    if (shape is not IAutoShape autoShape || autoShape.Placeholder == null)
    {
        continue;
    }

    switch (autoShape.Placeholder.Type)
    {
        case PlaceholderType.Title:
        case PlaceholderType.CenteredTitle:
            autoShape.TextFrame.Text = "Enter a concise slide title";
            break;
        case PlaceholderType.Subtitle:
            autoShape.TextFrame.Text = "Enter a subtitle or reporting period";
            break;
    }
}

presentation.Save("custom-placeholder-prompts.pptx", SaveFormat.Pptx);
```

提示文字不是普通投影片的內容。它僅供在 PowerPoint 等編輯應用程式的空佔位符中使用。使用者或程式提供實際內容後，提示文字就不會再顯示。變更提示文字也不會取代已使用該版面的投影片上現有的文字。

## **更新圖片佔位符**

有兩種情況需要處理：

- 若圖片佔位符已經被填入，且以 [IPictureFrame](https://reference.aspose.com/slides/net/aspose.slides/ipictureframe/) 表示，請透過 [IPictureFillFormat.Picture](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/picture/) 與 [ISlidesPicture.Image](https://reference.aspose.com/slides/net/aspose.slides/islidespicture/image/) 取代圖像。
- 若仍是空佔位符，請使用 [IShapeCollection.AddPictureFrame](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addpictureframe/) 在佔位符座標處加入圖片框，並移除空佔位符。

以下範例同時支援上述兩種情況，並儲存簡報：

```csharp
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("picture-template.pptx");
var slide = presentation.Slides[0];
IShape? picturePlaceholder = null;

foreach (var shape in slide.Shapes)
{
    if (shape.Placeholder?.Type == PlaceholderType.Picture)
    {
        picturePlaceholder = shape;
        break;
    }
}

if (picturePlaceholder == null)
{
    throw new InvalidOperationException("The first slide does not contain a picture placeholder.");
}

var imageBytes = File.ReadAllBytes("replacement.png");
var image = presentation.Images.AddImage(imageBytes);

if (picturePlaceholder is IPictureFrame pictureFrame)
{
    pictureFrame.PictureFormat.Picture.Image = image;
}
else
{
    slide.Shapes.AddPictureFrame(ShapeType.Rectangle, picturePlaceholder.X, picturePlaceholder.Y, picturePlaceholder.Width, picturePlaceholder.Height, image);
    slide.Shapes.Remove(picturePlaceholder);
}

presentation.Save("picture-placeholder-updated.pptx", SaveFormat.Pptx);
```

對空佔位符所建立的取代物是一個本機圖片框，而非新佔位符，因為 [IShape.Placeholder](https://reference.aspose.com/slides/net/aspose.slides/ishape/placeholder/) 為唯讀屬性。它會保留保留的位置，但不再繼承佔位符的專屬行為。如果必須保留佔位符關係，請先在 PowerPoint 中預先建立並填入佔位符，再使用 Aspose.Slides 更新產生的 [IPictureFrame](https://reference.aspose.com/slides/net/aspose.slides/ipictureframe/)。

關於圖片透明度、裁切及其他圖片專屬效果，請參閱 [Manage Picture Frames](/slides/zh-hant/net/picture-frame/)。這些操作屬於圖片框或圖片填充，而非佔位符的中繼資料。

## **處理圖表與內容佔位符**

已填入的圖表佔位符可以以 [IChart](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/) 表示。以下範例同時依據佔位符類型與執行時介面找到此圖表，變更其標題，然後儲存檔案：

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation("chart-template.pptx");
var slide = presentation.Slides[0];
IChart? placeholderChart = null;

foreach (var shape in slide.Shapes)
{
    if (shape is IChart chart && shape.Placeholder?.Type == PlaceholderType.Chart)
    {
        placeholderChart = chart;
        break;
    }
}

if (placeholderChart == null)
{
    throw new InvalidOperationException("The first slide does not contain a populated chart placeholder.");
}

placeholderChart.HasTitle = true;
placeholderChart.ChartTitle.AddTextFrameForOverriding("Quarterly Revenue");
presentation.Save("chart-placeholder-updated.pptx", SaveFormat.Pptx);
```

一般內容佔位符通常具有 [PlaceholderType.Object](https://reference.aspose.com/slides/net/aspose.slides/placeholdertype/)。在 PowerPoint 中，它充當多種內容類型的啟動器，包含圖表、表格、圖示、圖片與媒體。內容被填入後，請檢查實際的形狀介面以了解其包含的物件。特定版面也可能公開 [PlaceholderType.Chart](https://reference.aspose.com/slides/net/aspose.slides/placeholdertype/)、[PlaceholderType.Table](https://reference.aspose.com/slides/net/aspose.slides/placeholdertype/)、[PlaceholderType.Picture](https://reference.aspose.com/slides/net/aspose.slides/placeholdertype/)、[PlaceholderType.Media](https://reference.aspose.com/slides/net/aspose.slides/placeholdertype/)、[PlaceholderType.Diagram](https://reference.aspose.com/slides/net/aspose.slides/placeholdertype/)。

Aspose.Slides 並不會僅透過變更 [IPlaceholder.Type](https://reference.aspose.com/slides/net/aspose.slides/iplaceholder/type/)（此屬性為唯讀）就將空的 [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) 佔位符轉換為 [IChart](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/)。若需以程式方式填入空的圖表或內容區域，請在佔位符座標處加入所需的物件，然後移除空佔位符。以下範例示範如何為圖表執行此操作：

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation("content-template.pptx");
var slide = presentation.Slides[0];
IShape? targetPlaceholder = null;

foreach (var shape in slide.Shapes)
{
    if (shape.Placeholder?.Type is PlaceholderType.Chart or PlaceholderType.Object)
    {
        targetPlaceholder = shape;
        break;
    }
}

if (targetPlaceholder == null)
{
    throw new InvalidOperationException("The first slide does not contain a chart or content placeholder.");
}

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, targetPlaceholder.X, targetPlaceholder.Y, targetPlaceholder.Width, targetPlaceholder.Height);
chart.HasTitle = true;
chart.ChartTitle.AddTextFrameForOverriding("Quarterly Revenue");
slide.Shapes.Remove(targetPlaceholder);
presentation.Save("content-placeholder-replaced-with-chart.pptx", SaveFormat.Pptx);
```

所加入的圖表是一個普通本機圖表。它佔用佔位符的區域，但不會繼承版面佔位符的設定。若需更換類別、序列或活頁簿資料，請參考專門的 [chart management articles](/slides/zh-hant/net/powerpoint-charts/)。

## **完整範例：更新文字或影像內容**

以下端到端範例會開啟一個範本，搜尋第一張投影片上的標題或圖片佔位符，檢查佔位符與形狀類型，更新對應的內容，最後儲存輸出。此範例刻意避免假設形狀索引或將所有佔位符強制轉型為同一介面。

```csharp
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("template.pptx");
var slide = presentation.Slides[0];
var updated = false;

foreach (var shape in slide.Shapes)
{
    if (shape.Placeholder == null)
    {
        continue;
    }

    var placeholderType = shape.Placeholder.Type;

    if ((placeholderType == PlaceholderType.Title || placeholderType == PlaceholderType.CenteredTitle) && shape is IAutoShape titleShape)
    {
        titleShape.TextFrame.Text = "Quarterly Business Review";
        updated = true;
        break;
    }

    if (placeholderType == PlaceholderType.Picture)
    {
        var imageBytes = File.ReadAllBytes("replacement.png");
        var image = presentation.Images.AddImage(imageBytes);

        if (shape is IPictureFrame pictureFrame)
        {
            pictureFrame.PictureFormat.Picture.Image = image;
        }
        else
        {
            slide.Shapes.AddPictureFrame(ShapeType.Rectangle, shape.X, shape.Y, shape.Width, shape.Height, image);
            slide.Shapes.Remove(shape);
        }

        updated = true;
        break;
    }
}

if (!updated)
{
    throw new InvalidOperationException("No supported title or picture placeholder was found on the first slide.");
}

presentation.Save("placeholder-content-updated.pptx", SaveFormat.Pptx);
```

## **常見問題**

**什麼是基礎佔位符？**

基礎佔位符是指版面或母片上對應的形狀，其他佔位符會從它繼承設定。請使用 [IShape.GetBasePlaceholder](https://reference.aspose.com/slides/net/aspose.slides/ishape/getbaseplaceholder/) 取得它。普通本機形狀會傳回 `null`，因為它不屬於佔位符層級。

**我可以透過編輯版面佔位符一次變更所有投影片的標題嗎？**

您可以透過版面變更繼承的格式或提示文字，但實際的標題內容儲存在普通投影片上。若要在整份簡報中替換真正的標題文字，必須遍歷投影片並分別更新每個標題佔位符。

**如何管理日期、投影片編號、頁眉與頁腳佔位符？**

請在適當的投影片、版面、母片、備註或講義範圍內使用頁眉與頁腳管理器。詳細範例請參閱 [Manage Presentation Header and Footer](/slides/zh-hant/net/presentation-header-and-footer/)。