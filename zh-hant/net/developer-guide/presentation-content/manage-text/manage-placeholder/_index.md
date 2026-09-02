---
title: 管理 .NET 中的簡報占位符
linktitle: 管理占位符
type: docs
weight: 10
url: /zh-hant/net/manage-placeholder/
keywords:
- 占位符
- 文字占位符
- 圖片占位符
- 圖表占位符
- 內容占位符
- 提示文字
- PowerPoint
- 簡報
- .NET
- C#
- Aspose.Slides
description: "了解如何使用 Aspose.Slides for .NET 檢視與編輯文字、圖片、圖表與內容占位符，並理解占位符的繼承關係。"
---
## **概述**

占位符是一種形狀，用於在簡報範本中為特定類型的內容保留位置。常見範例包括標題、內文、圖片、圖表以及一般用途的內容占位符。與普通形狀不同，占位符可以從版面投影片或母片繼承其位置、大小、格式以及其他設定。

Aspose.Slides 透過 [IShape.Placeholder](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ishape/placeholder/) 屬性公開占位符資訊。此屬性會回傳一個 [IPlaceholder](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/iplaceholder/) 物件，若為一般形狀則回傳 `null`。使用 [IPlaceholder.Type](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/iplaceholder/type/) 可判斷占位符預期要容納的內容類型。

了解占位符類型後，形狀介面仍然很重要：

- 空的文字、圖片、圖表或內容占位符通常以 [IAutoShape](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/iautoshape/) 代表。
- 已填入圖片的占位符可以以 [IPictureFrame](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ipictureframe/) 代表。
- 已填入圖表的占位符可以以 [IChart](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.charts/ichart/) 代表。
- 內容占位符可以包含多種內容。請同時檢查 [IPlaceholder.Type](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/iplaceholder/type/) 與執行階段的形狀介面，而不要假設每個占位符都是 [IAutoShape](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/iautoshape/)。

{{% alert color="warning" title="Warning" %}}
[IPlaceholder.Type](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/iplaceholder/type/) 描述占位符的角色；它並不保證形狀的執行階段類型。存取文字、圖片、圖表、表格或媒體相關成員之前，請始終先進行類型檢查。
{{% /alert %}}

## **了解占位符繼承**

占位符形成層級結構：

1. 母片投影片定義可重複使用的樣式，並在某些情況下提供母片層級的占位符。
2. 版面投影片定義一個或多個普通投影片使用的版面配置，且可從母片繼承。
3. 普通投影片包含該投影片的占位符，且可從其版面繼承。

呼叫 [IShape.GetBasePlaceholder](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ishape/getbaseplaceholder/) 可向上移動一層層級。投影片的占位符通常會回傳其版面占位符；版面占位符則可回傳其母片占位符。若形狀沒有基礎占位符，則此方法回傳 `null`。

以下範例會列出第一張投影片上的占位符，並回報它們的基礎占位符：

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

編輯普通投影片上的占位符會為該投影片建立或變更本地覆寫。編輯相關的版面或母片則會影響所有仍從該設定繼承的投影片。普通的本地形狀沒有基礎占位符，僅因為佔用了相同座標而不會開始繼承。

## **變更占位符中的文字**

標題、置中標題、副標題、內文與文字占位符通常支援文字。使用前請先確認是否為 [IAutoShape](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/iautoshape/)，再存取其 [TextFrame](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/iautoshape/textframe/) 屬性。

以下範例會更新第一張投影片上的第一個標題占位符，並儲存結果：

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

此模式避免將圖片、圖表、表格或媒體占位符轉型為 [IAutoShape](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/iautoshape/)。它也會以用途來識別占位符，而不是依賴脆弱的形狀索引。

## **在版面上設定提示文字**

提示文字是空占位符中顯示的設計階段說明，例如 *Click to add title*。請在版面占位符上設定自訂提示文字，而不是透過普通投影片的形狀集合去存取。可透過 [ISlide.LayoutSlide](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/islide/layoutslide/) 取得版面，並遍歷 [ILayoutSlide.Shapes](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ibaseslide/shapes/)。

以下範例會變更第一張投影片所使用版面上的標題與副標題提示文字：

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

提示文字不是普通投影片的內容。它僅供 PowerPoint 等編輯應用程式在空占位符中顯示。一旦使用者或程式提供實際內容，提示文字即不再顯示。變更提示文字也不會取代使用該版面的投影片上已有的文字。

## **更新圖片占位符**

需要處理兩種情況：

- 若圖片占位符已被填入，且以 [IPictureFrame](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ipictureframe/) 代表，請透過 [IPictureFillFormat.Picture](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ipicturefillformat/picture/) 與 [ISlidesPicture.Image](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/islidespicture/image/) 取代影像。
- 若仍是空占位符，請使用 [IShapeCollection.AddPictureFrame](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ishapecollection/addpictureframe/) 在占位符座標加入圖片框，並移除空占位符。

以下範例同時支援這兩種情況，並儲存簡報：

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

對空占位符所建立的取代物是一個本地圖片框，而非新占位符，因為 [IShape.Placeholder](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ishape/placeholder/) 為唯讀。它保留了保留位置，但不再繼承占位符專屬行為。如果必須保留占位符關係，請先在 PowerPoint 中建立並填入占位符，然後再使用 Aspose.Slides 更新得到的 [IPictureFrame](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ipictureframe/)。

欲了解影像透明度、裁切及其他圖片專屬效果，請參閱 [Manage Picture Frames](/slides/zh-hant/net/picture-frame/)。這些操作屬於圖片框或圖片填充，而非占位符的中繼資料。

## **處理圖表與內容占位符**

已填入的圖表占位符可以以 [IChart](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.charts/ichart/) 代表。以下範例同時依據占位符類型與執行階段介面找到此類圖表、變更其標題，並儲存檔案：

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

一般內容占位符通常具有 [PlaceholderType.Object](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/placeholdertype/)。在 PowerPoint 中，它充當多種內容類型的啟動器，包括圖表、表格、圖示、圖片與媒體。填入後，請檢查實際的形狀介面以了解其包含的內容。特定版面也可能暴露 [PlaceholderType.Chart](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/placeholdertype/)、[PlaceholderType.Table](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/placeholdertype/)、[PlaceholderType.Picture](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/placeholdertype/)、[PlaceholderType.Media](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/placeholdertype/)、[PlaceholderType.Diagram](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/placeholdertype/)。

Aspose.Slides 不會僅透過變更 [IPlaceholder.Type](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/iplaceholder/type/)（此屬性唯讀）就把空的 [IAutoShape](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/iautoshape/) 占位符轉換為 [IChart](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.charts/ichart/)。若要以程式方式填充空的圖表或內容區域，請在占位符座標加入所需的物件，然後移除空占位符。以下範例示範如何為圖表執行此操作：

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

新增的圖表是一個普通本地圖表。它佔用占位符的區域，但不會從版面占位符繼承。若需取代其類別、序列或活頁簿資料，請參考專門的 [chart management articles](/slides/zh-hant/net/powerpoint-charts/)。

## **完整範例：更新文字或影像內容**

以下端對端範例會開啟範本、搜尋第一張投影片上的標題或圖片占位符、檢查占位符與形狀類型、更新相應內容，最後儲存輸出。此範例刻意避免假設形狀索引或將每個占位符都轉型為相同介面。

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

## **常見問與答**

**什麼是基礎占位符？**

基礎占位符是版面或母片上相對應的形狀，其他占位符會從其繼承。使用 [IShape.GetBasePlaceholder](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ishape/getbaseplaceholder/) 可取得它。一般本地形狀會回傳 `null`，因為它不屬於占位符層級。

**我可以透過編輯版面占位符來變更所有投影片的標題嗎？**

您可以透過版面變更繼承的格式或提示文字，但實際的標題內容儲存在普通投影片上。若要在整個簡報中取代標題文字，必須遍歷投影片並更新每個標題占位符。

**如何管理日期、投影片編號、頁眉與頁腳占位符？**

請在相應的投影片、版面、母片、備註或講義範圍使用頁眉與頁腳管理器。完整範例請參閱 [Manage Presentation Header and Footer](/slides/zh-hant/net/presentation-header-and-footer/)。