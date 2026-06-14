---
title: 在 .NET 中管理簡報投影片母片
linktitle: 投影片母片
type: docs
weight: 80
url: /zh-hant/net/slide-master/
keywords:
- 投影片母片
- 投影片母片
- PPT 投影片母片
- 多個投影片母片
- 比較投影片母片
- 背景
- 占位符
- 克隆投影片母片
- 複製投影片母片
- 重製投影片母片
- 未使用的投影片母片
- PowerPoint
- OpenDocument
- 簡報
- .NET
- C#
- Aspose.Slides
description: "在 Aspose.Slides for .NET 中管理投影片母片：存取、編輯、克隆、比較以及移除 PowerPoint 與 OpenDocument 簡報中的母片投影片。"
---
## **概覽**

**投影片母片** 定義了一組投影片的共用設計設定。它可以包含共同的圖形、標誌、背景、文字樣式、佈景主題設定以及頁尾設定。在 PowerPoint 中，編輯投影片母片是保持簡報一致性且不必在每張投影片上重複相同格式的慣用方式。

Aspose.Slides for .NET 支援相同的模型。一份簡報可以包含一個或多個母片，而每個母片可以包含多個版面投影片。普通投影片通常不會直接參考母片。相反地，普通投影片會使用版面投影片，而該版面投影片屬於某個母片。

層級結構如下：

1. **投影片母片** - 定義共用的設計與佈景主題。  
1. **版面投影片** - 定義占位符的具體排列與版面層級的格式設定。  
1. **普通投影片** - 包含實際的簡報內容，使用一個版面投影片。

![投影片母片、版面投影片與普通投影片的層級結構](slide-master_2.jpg)

在 Aspose.Slides 中，投影片母片由 [IMasterSlide](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/imasterslide/) 介面表示。簡報中所有的母片皆可透過 [Presentation.Masters](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation/masters/) 集合存取，該集合實作了 [IMasterSlideCollection](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/imasterslidecollection/)。

{{% alert color="info" title="Inheritance" %}}
當相同屬性在多層級中都有定義時，較具體的層級會優先。舉例來說，如果母片與版面投影片都定義了背景，則基於該版面的投影片會使用版面的背景。欲了解更多版面投影片的資訊，請參閱 [Apply or Change Slide Layouts](/slides/zh-hant/net/slide-layout/)。
{{% /alert %}}

## **存取投影片母片**

在 PowerPoint 中，您可以從 **檢視** > **投影片母片** 開啟投影片母片檢視。

![PowerPoint「檢視」索引標籤上的「投影片母片」指令](slide-master_3.jpg)

在 Aspose.Slides 中，使用 `Masters` 集合來存取母片：

```csharp
using var presentation = new Presentation("presentation.pptx");

var firstMasterSlide = presentation.Masters[0];
var masterSlideCount = presentation.Masters.Count;
var firstMasterLayoutSlideCount = firstMasterSlide.LayoutSlides.Count;

Console.WriteLine("Master slides: " + masterSlideCount);
Console.WriteLine("Layouts in the first master: " + firstMasterLayoutSlideCount);
```

也可以透過普通投影片的版面取得其所使用的母片：

```csharp
using var presentation = new Presentation("presentation.pptx");

var slide = presentation.Slides[0];
var layoutSlide = slide.LayoutSlide;
var masterSlide = layoutSlide.MasterSlide;
var masterSlideName = masterSlide.Name;

Console.WriteLine(masterSlideName);
```

## **投影片母片包含的內容**

母片是一種類似投影片的物件。它實作了 [IBaseSlide](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ibaseslide/)，因此會暴露許多普通投影片與版面投影片使用的相同屬性。母片專屬的成員列於 [IMasterSlide](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/imasterslide/) API 頁面。

常用的母片成員包括：

| 成員 | 目的 |
| --- | --- |
| `Background` | 設定母片層級的投影片背景。 |
| `Shapes` | 儲存放置在母片上的圖形，例如標誌、圖片框與共用文字。 |
| `LayoutSlides` | 儲存屬於該母片的版面投影片。 |
| `ThemeManager` | 提供存取母片佈景主題 API 的功能。 |
| `HeaderFooterManager` | 控制母片及其子版面的頁首、頁尾、日期與投影片編號。 |
| `GetDependingSlides` | 取得透過版面依賴此母片的普通投影片。 |

## **在投影片母片中加入圖片**

將圖片加入母片後，會在使用該母片版面的投影片上顯示。這對於標誌、浮水印、裝飾條帶及其他重複的視覺元素非常有用。

以下範例在第一個母片上加入標誌：

```csharp
using var presentation = new Presentation("presentation.pptx");

var masterSlide = presentation.Masters[0];
var logoBytes = File.ReadAllBytes("logo.png");
var logoImage = presentation.Images.AddImage(logoBytes);

masterSlide.Shapes.AddPictureFrame(
    ShapeType.Rectangle,
    x: 20,
    y: 20,
    width: 80,
    height: 80,
    image: logoImage);

presentation.Save("presentation-with-logo.pptx", SaveFormat.Pptx);
```

有關圖片框的更多資訊，請參閱 [Picture Frame](/slides/zh-hant/net/picture-frame/)。

## **使用占位符**

占位符通常在版面投影片上定義。母片提供共用的樣式與佈景主題，版面則決定哪些占位符可用以及其位置。

在 PowerPoint 中，占位符指令可於投影片母片檢視中使用。

![PowerPoint 投影片母片檢視中的「插入占位符」指令](slide-master_5.png)

若要使用 Aspose.Slides 新增占位符，請對屬於母片的版面投影片進行操作：

```csharp
using var presentation = new Presentation("presentation.pptx");

var masterSlide = presentation.Masters[0];
var blankLayoutSlide =
    masterSlide.LayoutSlides.GetByType(SlideLayoutType.Blank) ??
    masterSlide.LayoutSlides.Add(SlideLayoutType.Blank, "Blank");

blankLayoutSlide.PlaceholderManager.AddTextPlaceholder(
    x: 60,
    y: 120,
    width: 600,
    height: 80);

presentation.Slides.AddEmptySlide(blankLayoutSlide);
presentation.Save("presentation-with-placeholder.pptx", SaveFormat.Pptx);
```

您也可以格式化已存在於母片上的占位符圖形。以下範例找出標題占位符並套用線性漸層填色：

```csharp
using var presentation = new Presentation("presentation.pptx");

var masterSlide = presentation.Masters[0];
var titlePlaceholder = FindPlaceholder(masterSlide, PlaceholderType.Title);

if (titlePlaceholder != null)
{
    var redGradientColor = Color.FromArgb(255, 0, 0);
    var purpleGradientColor = Color.FromArgb(128, 0, 128);

    titlePlaceholder.FillFormat.FillType = FillType.Gradient;
    titlePlaceholder.FillFormat.GradientFormat.GradientShape = GradientShape.Linear;
    titlePlaceholder.FillFormat.GradientFormat.GradientStops.Add(0, redGradientColor);
    titlePlaceholder.FillFormat.GradientFormat.GradientStops.Add(255, purpleGradientColor);
}

presentation.Save("presentation-title-style.pptx", SaveFormat.Pptx);

static IAutoShape? FindPlaceholder(IMasterSlide masterSlide, PlaceholderType placeholderType)
{
    foreach (var shape in masterSlide.Shapes)
    {
        if (shape is IAutoShape { Placeholder: not null } autoShape &&
            autoShape.Placeholder.Type == placeholderType)
        {
            return autoShape;
        }
    }

    return null;
}
```

![普通投影片繼承的已格式化標題占位符](slide-master_8.png)

欲取得更多占位符與文字格式化選項，請參閱 [Set Prompt Text in Placeholder](/slides/zh-hant/net/manage-placeholder/) 與 [Text Formatting](/slides/zh-hant/net/text-formatting/)。

## **變更投影片母片背景**

母片背景會被版面與未覆寫背景的投影片繼承。以下範例為第一個母片設定單色背景：

```csharp
using var presentation = new Presentation("presentation.pptx");

var masterSlide = presentation.Masters[0];

masterSlide.Background.Type = BackgroundType.OwnBackground;
masterSlide.Background.FillFormat.FillType = FillType.Solid;
masterSlide.Background.FillFormat.SolidFillColor.Color = Color.ForestGreen;

presentation.Save("presentation-master-background.pptx", SaveFormat.Pptx);
```

相關主題請參閱 [Presentation Background](/slides/zh-hant/net/presentation-background/) 與 [Presentation Theme](/slides/zh-hant/net/presentation-theme/)。

## **將投影片母片克隆至其他簡報**

使用 [IMasterSlideCollection.AddClone](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/imasterslidecollection/addclone/) 可將母片複製到其他簡報。複製後的母片即可被目的簡報中的版面與投影片使用。

```csharp
using var sourcePresentation = new Presentation("source.pptx");
using var destinationPresentation = new Presentation("destination.pptx");

var sourceMasterSlide = sourcePresentation.Masters[0];
var clonedMasterSlide = destinationPresentation.Masters.AddClone(sourceMasterSlide);

destinationPresentation.Save("destination-with-master.pptx", SaveFormat.Pptx);
```

如果需要同時克隆普通投影片及其母片，請參閱 [Clone Slides](/slides/zh-hant/net/clone-slides/)。

## **新增多個投影片母片**

一份簡報可以包含多個母片。當不同章節需要不同品牌、頁面結構或佈景主題設定時，這非常有用。

![PowerPoint 插入與管理母片的指令](slide-master_9.jpg)

以下範例克隆預設母片、為克隆後的母片設定不同背景、在該克隆母片下建立版面，並根據該版面新增投影片：

```csharp
using var presentation = new Presentation("presentation.pptx");

var defaultMasterSlide = presentation.Masters[0];
var sectionMasterSlide = presentation.Masters.AddClone(defaultMasterSlide);

sectionMasterSlide.Background.Type = BackgroundType.OwnBackground;
sectionMasterSlide.Background.FillFormat.FillType = FillType.Solid;
sectionMasterSlide.Background.FillFormat.SolidFillColor.Color = Color.LightSteelBlue;

var sourceBlankLayout =
    defaultMasterSlide.LayoutSlides.GetByType(SlideLayoutType.Blank) ??
    defaultMasterSlide.LayoutSlides[0];
var sectionBlankLayout = sectionMasterSlide.LayoutSlides.AddClone(sourceBlankLayout);

presentation.Slides.AddEmptySlide(sectionBlankLayout);
presentation.Save("presentation-with-multiple-masters.pptx", SaveFormat.Pptx);
```

## **比較投影片母片**

母片可以使用從 [IBaseSlide](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ibaseslide/) 繼承的 `Equals` 方法進行比較。比較會檢查結構與靜態內容，例如圖形、文字、格式、動畫及其他投影片設定。它不會比較唯一識別碼（如投影片 ID）或動態占位符值（如當前日期）。

```csharp
using var firstPresentation = new Presentation("first.pptx");
using var secondPresentation = new Presentation("second.pptx");

var firstPresentationMasterCount = firstPresentation.Masters.Count;
var secondPresentationMasterCount = secondPresentation.Masters.Count;

for (var firstMasterIndex = 0; firstMasterIndex < firstPresentationMasterCount; firstMasterIndex++)
{
    for (var secondMasterIndex = 0; secondMasterIndex < secondPresentationMasterCount; secondMasterIndex++)
    {
        var firstMasterSlide = firstPresentation.Masters[firstMasterIndex];
        var secondMasterSlide = secondPresentation.Masters[secondMasterIndex];
        var areMasterSlidesEqual = firstMasterSlide.Equals(secondMasterSlide);

        if (areMasterSlidesEqual)
        {
            Console.WriteLine(
                "first.pptx master #{0} equals second.pptx master #{1}",
                firstMasterIndex,
                secondMasterIndex);
        }
    }
}
```

欲了解更多資訊，請參閱 [Compare Presentation Slides](/slides/zh-hant/net/compare-slides/)。

## **將投影片母片檢視設為預設檢視**

使用 [ViewProperties](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/viewproperties/) 上的 `LastView` 屬性可控制 PowerPoint 首次開啟時的檢視模式。以下範例在投影片母片檢視中開啟簡報：

```csharp
using var presentation = new Presentation("presentation.pptx");

presentation.ViewProperties.LastView = ViewType.SlideMasterView;
presentation.Save("presentation-master-view.pptx", SaveFormat.Pptx);
```

更多檢視設定，請參閱 [Save Presentation](/slides/zh-hant/net/save-presentation/)。

## **移除未使用的投影片母片**

簡報有時會包含已不再被任何普通投影片使用的母片。移除未使用的母片可減少檔案大小並簡化範本維護。

使用 [MasterSlideCollection.RemoveUnused](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/masterslidecollection/removeunused/) 從 `Masters` 集合中移除未使用的母片：

```csharp
using var presentation = new Presentation("presentation.pptx");

presentation.Masters.RemoveUnused(ignorePreserveField: true);
presentation.Save("presentation-clean.pptx", SaveFormat.Pptx);
```

您也可以使用低程式碼的 [Compress.RemoveUnusedMasterSlides](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.lowcode/compress/removeunusedmasterslides/) 方法：

```csharp
using var presentation = new Presentation("presentation.pptx");

Aspose.Slides.LowCode.Compress.RemoveUnusedMasterSlides(presentation);
presentation.Save("presentation-clean.pptx", SaveFormat.Pptx);
```

## **常見問題**

**投影片母片與版面投影片有何差異？**

投影片母片定義共享的設計設定，例如佈景主題、背景、共用圖形與文字樣式。版面投影片屬於母片，定義占位符的具體排列。普通投影片使用版面投影片，因而同時繼承版面與母片的設定。

**一份簡報可以包含多個投影片母片嗎？**

可以。簡報可包含多個投影片母片。當不同章節需要不同視覺系統或品牌時，請使用多個母片。

**應該在母片還是版面投影片上加入占位符？**

大多數情況下，請在版面投影片上加入占位符。將共享的視覺元素與共用格式放在母片上，然後在普通投影片會使用的版面上放置內容占位符。

**我可以刪除仍被使用的母片嗎？**

不能。具有相依投影片的母片無法直接安全刪除。請先將那些投影片移至其他母片的版面，或使用只移除未使用母片的清理方法。