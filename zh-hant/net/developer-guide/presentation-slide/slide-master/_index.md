---
title: 在 .NET 中管理簡報投影片母片
linktitle: 投影片母片
type: docs
weight: 80
url: /zh-hant/net/slide-master/
keywords:
- 投影片母片
- 母片投影片
- PPT 母片投影片
- 多個母片投影片
- 比較母片投影片
- 背景
- 佔位符
- 複製母片投影片
- 拷貝母片投影片
- 重複母片投影片
- 未使用的母片投影片
- PowerPoint
- OpenDocument
- 簡報
- .NET
- C#
- Aspose.Slides
description: "在 Aspose.Slides for .NET 中管理投影片母片：存取、編輯、複製、比較及移除 PowerPoint 與 OpenDocument 簡報中的母片投影片。"
---
## **概觀**

**投影片母片** 定義一組投影片的共用設計設定。它可以包含共用圖形、徽標、背景、文字樣式、主題設定和頁腳設定。在 PowerPoint 中，編輯投影片母片是保持簡報一致性的常用方式，無需在每張投影片上重複相同的格式設定。

Aspose.Slides for .NET 支援相同的模型。簡報可以包含一個或多個母片，且每個母片可以包含多個版面投影片。一般投影片通常不會直接參照母片。相反地，一般投影片會使用版面投影片，而該版面投影片屬於某個母片。

階層如下：

1. **投影片母片** - 定義共用設計與主題。  
1. **版面投影片** - 定義佔位符的特定排列與版面層級的格式設定。  
1. **一般投影片** - 包含實際的簡報內容，並使用一個版面投影片。

![母片、版面投影片和一般投影片的階層結構](slide-master_2.jpg)

在 Aspose.Slides 中，投影片母片由 [IMasterSlide](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/imasterslide/) 介面表示。簡報中的所有母片可透過 [Presentation.Masters](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation/masters/) 集合存取，該集合實作 [IMasterSlideCollection](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/imasterslidecollection/)。

{{% alert color="info" title="Inheritance" %}}
當同一屬性在多個層級中都有定義時，以較具體的層級為準。例如，若母片和版面投影片皆定義背景，基於該版面的投影片會使用版面背景。欲取得更多關於版面投影片的資訊，請參閱[套用或變更投影片版面配置](/slides/zh-hant/net/slide-layout/)。
{{% /alert %}}

## **存取投影片母片**

在 PowerPoint 中，您可以從 **View** > **Slide Master** 開啟投影片母片檢視。

![PowerPoint 檢視功能表上的投影片母片指令](slide-master_3.jpg)

在 Aspose.Slides 中，使用 `Masters` 集合存取母片：

```csharp
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");

var firstMasterSlide = presentation.Masters[0];
var masterSlideCount = presentation.Masters.Count;
var firstMasterLayoutSlideCount = firstMasterSlide.LayoutSlides.Count;

Console.WriteLine("Master slides: " + masterSlideCount);
Console.WriteLine("Layouts in the first master: " + firstMasterLayoutSlideCount);
```

您也可以透過一般投影片的版面取得其使用的母片：

```csharp
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");

var slide = presentation.Slides[0];
var layoutSlide = slide.LayoutSlide;
var masterSlide = layoutSlide.MasterSlide;
var masterSlideName = masterSlide.Name;

Console.WriteLine(masterSlideName);
```

## **投影片母片的內容**

母片是一種類似投影片的物件。它實作 [IBaseSlide](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ibaseslide/)，因此會公開許多普通投影片與版面投影片使用的相同投影片屬性。母片特有的成員列於 [IMasterSlide](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/imasterslide/) API 頁面。

常用的母片成員包括：

| 成員 | 用途 |
| --- | --- |
| `Background` | 設定母片層級的投影片背景。 |
| `Shapes` | 儲存放置於母片上的圖形，例如徽標、圖片框架與共用文字。 |
| `LayoutSlides` | 儲存屬於該母片的版面投影片。 |
| `ThemeManager` | 提供存取母片主題 API 的功能。 |
| `HeaderFooterManager` | 控制母片及其子版面的頁首、頁腳、日期與投影片編號。 |
| `GetDependingSlides` | 傳回依其版面而依賴於母片的一般投影片。 |

## **將圖片新增至投影片母片**

當您將圖片新增至母片時，使用該母片版面的投影片都會顯示該圖片。這對於徽標、浮水印、裝飾條紋以及其他重複的視覺元素非常有用。

以下範例將徽標新增至第一個母片：

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

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

欲取得更多關於圖片框架的資訊，請參閱[圖片框架](/slides/zh-hant/net/picture-frame/)。

## **控制母片圖形的可見性**

使用 [IBaseSlide.ShowMasterShapes](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ibaseslide/showmastershapes/) 來隱藏繼承自母片的圖形（例如徽標或裝飾形狀），而不必從母片中刪除它們。於應省略這些圖形的投影片上將 [Slide.ShowMasterShapes](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/slide/showmastershapes/) 設為 `false`，而在應顯示的投影片上保持 `true`。

以下獨立範例在母片上建立藍色裝飾條紋，並在使用相同空白版面的兩張投影片上套用。該條紋在第一張投影片上可見，第二張則隱藏。此範例不需要輸入簡報或圖片。

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var masterSlide = presentation.Masters[0];
var layoutSlide = masterSlide.LayoutSlides.GetByType(SlideLayoutType.Blank);
layoutSlide.ShowMasterShapes = true;

var slideHeight = presentation.SlideSize.Size.Height;
var band = masterSlide.Shapes.AddAutoShape(ShapeType.Rectangle, 0, 0, 60, slideHeight);
band.FillFormat.FillType = FillType.Solid;
band.FillFormat.SolidFillColor.Color = Color.SteelBlue;
band.LineFormat.FillFormat.FillType = FillType.NoFill;

var visibleSlide = presentation.Slides[0];
visibleSlide.LayoutSlide = layoutSlide;
visibleSlide.Shapes.Clear();

var hiddenSlide = presentation.Slides.AddEmptySlide(layoutSlide);

visibleSlide.ShowMasterShapes = true;
hiddenSlide.ShowMasterShapes = false;

presentation.Save("master-graphics.pptx", SaveFormat.Pptx);
```

此範例使用新簡報中提供的 **Blank** 版面，並移除初始投影片自己的佔位符。

### **選擇設定的範圍**

一般投影片透過 [ISlide.LayoutSlide](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/islide/layoutslide/) 與 [ILayoutSlide.MasterSlide](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ilayoutslide/masterslide/) 使用其母片。將屬性設定在單一投影片上僅會影響該投影片。將 [LayoutSlide.ShowMasterShapes](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/layoutslide/showmastershapes/) 設為 `false` 會對使用該共用版面的所有投影片隱藏母片圖形，即使它們自己的設定為 `true`。若只想在單一投影片上隱藏圖形，請變更該投影片的屬性，並保持共用版面不變。

此設定在母片本身並不支援作為可見性控制。在母片上它始終返回 `false`，且指派 `true` 會拋出 `NotSupportedException`。請改為將其套用於一般投影片或版面上。

### **將圖形與背景區分**

| 操作 | 效果 |
| --- | --- |
| 隱藏母片圖形 | 隱藏繼承自母片的圖形，且不會刪除它們或變更投影片自身的圖形。 |
| 變更投影片背景填充 | 變更背景顏色、漸層或圖片。母片圖形為獨立形狀，仍可於該背景上顯示。請參閱[簡報背景](/slides/zh-hant/net/presentation-background/)。 |
| 從母片刪除圖形 | 移除共用的來源圖形，因而不再可供任何使用該母片的投影片使用。 |

## **使用佔位符**

佔位符通常在版面投影片上定義。母片提供共用的樣式與主題供這些版面繼承，而每個版面決定哪些佔位符可用以及它們的放置位置。

在 PowerPoint 中，佔位符指令可於投影片母片檢視中使用。

![PowerPoint 投影片母片檢視中的「插入佔位符」指令](slide-master_5.png)

若要使用 Aspose.Slides 新增佔位符，請操作屬於母片的版面投影片：

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

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

您也可以格式化已存在於母片上的佔位符圖形。以下範例尋找標題佔位符並套用線性漸層填充：

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

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

![已格式化的標題佔位符，供一般投影片繼承](slide-master_8.png)

欲取得更多佔位符與文字格式設定選項，請參閱[設定佔位符提示文字](/slides/zh-hant/net/manage-placeholder/)和[文字格式設定](/slides/zh-hant/net/text-formatting/)。

## **變更投影片母片背景**

母片背景會被未覆寫的版面與投影片繼承。以下範例為第一個母片設定純色背景：

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");

var masterSlide = presentation.Masters[0];

masterSlide.Background.Type = BackgroundType.OwnBackground;
masterSlide.Background.FillFormat.FillType = FillType.Solid;
masterSlide.Background.FillFormat.SolidFillColor.Color = Color.ForestGreen;

presentation.Save("presentation-master-background.pptx", SaveFormat.Pptx);
```

欲取得相關主題，請參閱[簡報背景](/slides/zh-hant/net/presentation-background/)和[簡報主題](/slides/zh-hant/net/presentation-theme/)。

## **將投影片母片複製至其他簡報**

使用 [IMasterSlideCollection.AddClone](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/imasterslidecollection/addclone/) 可將母片複製至其他簡報。複製後的母片即可被目標簡報中的版面與投影片使用。

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var sourcePresentation = new Presentation("source.pptx");
using var destinationPresentation = new Presentation("destination.pptx");

var sourceMasterSlide = sourcePresentation.Masters[0];
var clonedMasterSlide = destinationPresentation.Masters.AddClone(sourceMasterSlide);

destinationPresentation.Save("destination-with-master.pptx", SaveFormat.Pptx);
```

若需同時複製包含其母片的一般投影片，請參閱[複製投影片](/slides/zh-hant/net/clone-slides/)。

## **新增多個投影片母片**

簡報可以包含多個母片。當不同章節需要不同的品牌、頁面結構或主題設定時，此功能非常有用。

![PowerPoint 插入與管理母片的指令](slide-master_9.jpg)

以下範例複製預設母片、為複製品設定不同背景、在該複製母片下建立版面，並新增一張基於該版面的投影片：

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

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

可使用繼承自 [IBaseSlide](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ibaseslide/) 的 `Equals` 方法比較母片。比較會檢查結構與靜態內容，如圖形、文字、格式設定、動畫以及其他投影片設定。它不會比較唯一識別碼（例如投影片 ID）或動態佔位符值（例如當前日期）。

```csharp
using Aspose.Slides;

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

欲取得更多資訊，請參閱[比較簡報投影片](/slides/zh-hant/net/compare-slides/)。

## **將投影片母片檢視設為預設檢視**

使用 [ViewProperties](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/viewproperties/) 上的 `LastView` 屬性可控制 PowerPoint 首次開啟的檢視。以下範例在投影片母片檢視中開啟簡報：

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");

presentation.ViewProperties.LastView = ViewType.SlideMasterView;
presentation.Save("presentation-master-view.pptx", SaveFormat.Pptx);
```

欲取得更多檢視設定，請參閱[儲存簡報](/slides/zh-hant/net/save-presentation/)。

## **移除未使用的母片**

簡報有時會包含已不再被任何一般投影片使用的母片。移除未使用的母片可減少檔案大小並簡化範本維護。

使用 [MasterSlideCollection.RemoveUnused](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/masterslidecollection/removeunused/) 可從 `Masters` 集合中移除未使用的母片：

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");

presentation.Masters.RemoveUnused(ignorePreserveField: true);
presentation.Save("presentation-clean.pptx", SaveFormat.Pptx);
```

也可以使用低程式碼的 [Compress.RemoveUnusedMasterSlides](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.lowcode/compress/removeunusedmasterslides/) 方法：

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");

Aspose.Slides.LowCode.Compress.RemoveUnusedMasterSlides(presentation);
presentation.Save("presentation-clean.pptx", SaveFormat.Pptx);
```

## **FAQ**

**投影片母片與版面投影片有何不同？**

投影片母片定義共用的設計設定，如主題、背景、共用圖形與文字樣式。版面投影片屬於母片，定義佔位符的特定排列。一般投影片使用版面投影片，因而同時繼承版面與母片的設定。

**一個簡報可以包含多個投影片母片嗎？**

可以。簡報可以包含多個投影片母片。當不同章節需要不同的視覺系統或品牌時，請使用多個母片。

**應該在母片還是版面投影片上新增佔位符？**

大多數情況下，請在版面投影片上新增佔位符。將共用的視覺元素與共用格式放在母片上，然後在一般投影片將使用的版面上放置內容佔位符。

**我可以刪除仍在使用中的母片嗎？**

不能。具有相依投影片的母片無法直接安全刪除。請先將這些投影片移至其他母片下的版面，或使用僅移除未使用母片的清理方法。