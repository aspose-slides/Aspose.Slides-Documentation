---
title: 在 .NET 中管理簡報主題
linktitle: 簡報主題
type: docs
weight: 10
url: /zh-hant/net/presentation-theme/
keywords:
- PowerPoint 主題
- 簡報主題
- 投影片主題
- 設定主題
- 變更主題
- 管理主題
- 主題顏色
- 附加調色盤
- 主題字型
- 主題樣式
- 主題效果
- PowerPoint
- OpenDocument
- 簡報
- .NET
- C#
- Aspose.Slides
description: "在 Aspose.Slides for .NET 中掌握簡報主題，以建立、客製化與轉換具一致品牌形象的 PowerPoint 檔案。"
---
## **簡介**

簡報主題定義了一組協調的顏色、字型、背景樣式、填色、線條與效果。具備主題感知的物件會參考這些共享的定義，而不是將每個視覺屬性以固定值儲存，這樣變更主題即可一次更新許多物件。

在 Aspose.Slides 中，簡報層級的主題可透過 [Presentation.MasterTheme](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation/mastertheme/) 屬性取得。簡報亦可在較低層級包含主題覆寫。母版可以透過 [MasterThemeManager.OverrideTheme](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.theme/masterthememanager/overridetheme/) 覆寫簡報主題，版面配置可透過 [BaseOverrideThemeManager.OverrideTheme](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.theme/baseoverridethememanager/overridetheme/) 覆寫其繼承的主題，個別投影片亦可如此。實務上，投影片的有效主題會依此繼承鏈解析：簡報主題 → 母版覆寫 → 版面配置覆寫 → 投影片覆寫。

![主題組件：顏色、字型、背景樣式與效果](theme-constituents.png)

以下各節展示最常見的主題工作流程：檢視主題、變更顏色與字型、複製或套用主題、更新背景與效果樣式，以及在繼承與覆寫解析後讀取有效值。

## **檢視主題**

[MasterTheme](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.theme/mastertheme/) 物件會公開主題的 [ColorScheme](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.theme/mastertheme/colorscheme/)、[FontScheme](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.theme/mastertheme/fontscheme/) 與 [FormatScheme](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.theme/mastertheme/formatscheme/)。在變更之前先檢查這些集合特別有用，因為從外部來源取得的簡報其樣式項目的數量與內容可能不同。

以下範例讀取主要主題屬性，並回報主題中儲存的背景、填色、線條與效果樣式數量：

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("input.pptx");
var theme = presentation.MasterTheme;

Console.WriteLine($"Theme name: {theme.Name}");
Console.WriteLine($"Accent 1: {theme.ColorScheme.Accent1.Color}");
Console.WriteLine($"Major Latin font: {theme.FontScheme.Major.LatinFont.FontName}");
Console.WriteLine($"Minor Latin font: {theme.FontScheme.Minor.LatinFont.FontName}");
Console.WriteLine($"Background fill styles: {theme.FormatScheme.BackgroundFillStyles.Count}");
Console.WriteLine($"Fill styles: {theme.FormatScheme.FillStyles.Count}");
Console.WriteLine($"Line styles: {theme.FormatScheme.LineStyles.Count}");
Console.WriteLine($"Effect styles: {theme.FormatScheme.EffectStyles.Count}");
```

如果檔案使用多個母版，請勿假設每張投影片都有相同的有效主題。檢查與投影片關聯的母版，並在可能存在版面配置或投影片覆寫時，使用本文後面示範的有效主題工作流程。

## **變更主題顏色**

具備主題感知的填色、線條與文字可以參照 [SchemeColor](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/schemecolor/) 列舉中的邏輯顏色。當您變更主題的 [IColorScheme](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.theme/icolorscheme/) 中的對應項目時，所有仍參照該主題顏色的物件都會以新值重新解析。直接使用 RGB 顏色的物件則不會受到主題顏色更新的影響。

以下端到端範例建立一個使用 `Accent4` 的圖形，將主題的 `Accent4` 顏色變更為紅色，儲存簡報，重新開啟，並印出有效的填色顏色：

```csharp
using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 100, 100);
shape.FillFormat.FillType = FillType.Solid;
shape.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;
presentation.MasterTheme.ColorScheme.Accent4.Color = Color.Red;
presentation.Save("theme-color.pptx", SaveFormat.Pptx);

using var savedPresentation = new Presentation("theme-color.pptx");
var savedSlide = savedPresentation.Slides[0];
var savedShape = savedSlide.Shapes[0];
var effectiveFill = savedShape.FillFormat.GetEffective();
Console.WriteLine($"Effective fill color: {effectiveFill.SolidFillColor}");
```

由於矩形仍連結至 `Accent4`，在變更主題後其可見顏色會變為紅色。若您在圖形上以直接顏色取代方案顏色，之後對 `Accent4` 的變更將不再影響該填色。

### **使用附加調色盤的顏色**

PowerPoint 透過套用顏色變換，從主題顏色衍生較亮與較暗的變體。Aspose.Slides 透過 [ColorTransformOperation](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/colortransformoperation/) 公開這些變換。

![主題主要顏色以及由附加調色盤產生的較亮與較暗顏色](additional-palette-colors.png)

**1** - 主題主要顏色。  
**2** - 從主題主要顏色產生的較亮與較暗變體。

以下範例建立六個以 `Accent4` 為基礎的矩形，對其中五個套用亮度變換，並儲存結果：

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape1 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 50, 50);
shape1.FillFormat.FillType = FillType.Solid;
shape1.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;

var shape2 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 70, 50, 50);
shape2.FillFormat.FillType = FillType.Solid;
shape2.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;
shape2.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.MultiplyLuminance, 0.2f);
shape2.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.AddLuminance, 0.8f);

var shape3 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 130, 50, 50);
shape3.FillFormat.FillType = FillType.Solid;
shape3.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;
shape3.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.MultiplyLuminance, 0.4f);
shape3.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.AddLuminance, 0.6f);

var shape4 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 190, 50, 50);
shape4.FillFormat.FillType = FillType.Solid;
shape4.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;
shape4.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.MultiplyLuminance, 0.6f);
shape4.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.AddLuminance, 0.4f);

var shape5 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 250, 50, 50);
shape5.FillFormat.FillType = FillType.Solid;
shape5.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;
shape5.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.MultiplyLuminance, 0.75f);

var shape6 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 310, 50, 50);
shape6.FillFormat.FillType = FillType.Solid;
shape6.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;
shape6.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.MultiplyLuminance, 0.5f);

presentation.Save("theme-color-palette.pptx", SaveFormat.Pptx);
```

這些變體仍以主題顏色為基礎。若之後 `Accent4` 變更，變換後的顏色會根據新的 `Accent4` 值重新計算。

### **將 `SchemeColor` 值對映至 `IColorScheme` 槽位**

[SchemeColor](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/schemecolor/) 列舉使用 `Text1`、`Background1`、`Text2` 與 `Background2`，而 [IColorScheme](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.theme/icolorscheme/) 則以 `Dark1`、`Light1`、`Dark2`、`Light2` 來公開相同的主題槽位。對映是固定的：

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

這些是相同主題槽位的別名；它們並非會在不同形式之間動態轉換的值。

## **變更主題字型**

主題字型方案包含用於標題的主要字型集與用於內文的次要字型集。[FontScheme.Major](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.theme/fontscheme/major/) 與 [FontScheme.Minor](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.theme/fontscheme/minor/) 屬性會公開這些字型集。

PowerPoint 相容的主題字型識別碼可用於文字格式設定：

* `+mn-lt` - 內文字型 Latin（次要 Latin 字型）
* `+mj-lt` - 標題字型 Latin（主要 Latin 字型）
* `+mn-ea` - 內文字型 東亞（次要 東亞字型）
* `+mj-ea` - 標題字型 東亞（主要 東亞字型）

以下範例建立一個使用主要 Latin 主題字型的標題，以及一個使用次要 Latin 主題字型的內文行。接著變更主題字型並儲存結果：

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var heading = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 40, 40, 500, 60);
heading.TextFrame.Text = "Theme heading";
heading.TextFrame.Paragraphs[0].Portions[0].PortionFormat.LatinFont = new FontData("+mj-lt");

var body = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 40, 120, 500, 60);
body.TextFrame.Text = "Theme body text";
body.TextFrame.Paragraphs[0].Portions[0].PortionFormat.LatinFont = new FontData("+mn-lt");

presentation.MasterTheme.FontScheme.Major.LatinFont = new FontData("Aptos Display");
presentation.MasterTheme.FontScheme.Minor.LatinFont = new FontData("Arial");

presentation.Save("theme-fonts.pptx", SaveFormat.Pptx);
```

標題遵循主要字型，內文則遵循次要字型。若文字使用明確的字型名稱而非主題識別碼，則在主題字型方案變更時不會自動切換。

{{% alert color="info" title="提示" %}}
欲取得有關簡報字型的更多資訊，請參閱 [PowerPoint Fonts](/slides/zh-hant/net/powerpoint-fonts/)。
{{% /alert %}}

## **複製或套用主題**

有兩種常見工作流程，它們解決不同的問題。

### **移動投影片時保留來源主題**

若要將投影片移至其他簡報且保留其原始設計，可使用 [IMasterSlideCollection.AddClone](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/imasterslidecollection/addclone/) 將來源母版複製到目標簡報，然後使用 [ISlideCollection.AddClone](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/islidecollection/addclone/) 搭配已複製的母版複製投影片。如此會同時搬移母版、其版面配置及相關的主題。

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var source = new Presentation("source-theme.pptx");
using var target = new Presentation("target.pptx");

var sourceSlide = source.Slides[0];
var sourceMaster = sourceSlide.LayoutSlide.MasterSlide;
var clonedMaster = target.Masters.AddClone(sourceMaster);
target.Slides.AddClone(sourceSlide, clonedMaster, true);

target.Save("theme-preserved.pptx", SaveFormat.Pptx);
```

當來源投影片必須在目的地保持相同外觀時，此為首選工作流程。僅將內容複製到不相關的目的地母版，可能會改變受主題影響的顏色、字型、背景與效果。

### **將主題值套用至現有投影片**

若目標投影片必須保留目前的母版與版面配置，可從來源主題初始化投影片層級的覆寫。[OverrideTheme.InitColorSchemeFrom](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.theme/overridetheme/initcolorschemefrom/)、[OverrideTheme.InitFontSchemeFrom](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.theme/overridetheme/initfontschemefrom/) 與 [OverrideTheme.InitFormatSchemeFrom](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.theme/overridetheme/initformatschemefrom/) 方法會將三個主要主題組件複製到覆寫中。

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var source = new Presentation("source-theme.pptx");
using var target = new Presentation("target.pptx");

var targetSlide = target.Slides[0];
var overrideTheme = targetSlide.ThemeManager.OverrideTheme;
overrideTheme.InitColorSchemeFrom(source.MasterTheme.ColorScheme);
overrideTheme.InitFontSchemeFrom(source.MasterTheme.FontScheme);
overrideTheme.InitFormatSchemeFrom(source.MasterTheme.FormatScheme);

target.Save("theme-applied-to-slide.pptx", SaveFormat.Pptx);
```

此會變更該投影片使用的主題，但不會影響其他投影片繼承的主題。若要移除本地覆寫並回復繼承值，請呼叫 [OverrideTheme.Clear](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.theme/overridetheme/clear/)。

### **將主題覆寫套用至版面配置**

版面配置層級的覆寫會套用至使用該版面配置的投影片，除非個別投影片有自己的覆寫。可透過版面配置的 [LayoutSlideThemeManager](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.theme/layoutslidethememanager/) 使用相同的初始化方法：

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var source = new Presentation("source-theme.pptx");
using var target = new Presentation("target.pptx");

var targetLayout = target.Slides[0].LayoutSlide;
var overrideTheme = targetLayout.ThemeManager.OverrideTheme;
overrideTheme.InitColorSchemeFrom(source.MasterTheme.ColorScheme);
overrideTheme.InitFontSchemeFrom(source.MasterTheme.FontScheme);
overrideTheme.InitFormatSchemeFrom(source.MasterTheme.FormatScheme);

target.Save("theme-applied-to-layout.pptx", SaveFormat.Pptx);
```

當多個版面配置與投影片需共享相同基礎設計時，使用母版或簡報層級的主題；若某一版面配置族需要不同樣式，則使用版面配置覆寫；僅在真正的例外情況下才使用投影片覆寫。過度的投影片層級覆寫會使之後的全域主題變更難以預測。

## **更新主題背景樣式**

主題的背景填色儲存在 [FormatScheme.BackgroundFillStyles](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.theme/formatscheme/backgroundfillstyles/) 中。PowerPoint 在 UI 中呈現的背景選項可能多於此集合實際儲存的填色定義，因為 UI 可將主題填色與主題顏色及其他樣式參考結合。

![PowerPoint 簡報主題的背景樣式圖庫](presentation-design_8.png)

在使用背景樣式之前，請檢查已儲存的集合以及目前的 [Background.StyleIndex](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/background/styleindex/)。`StyleIndex` 以 `0` 表示無主題填色；正值則代表主題背景樣式參考。這與直接索引 .NET 集合的方式不同，`[0]` 代表第一個儲存的項目。請勿假設每個簡報都有相同數量的背景填色樣式。

以下範例回報可用的背景填色數量，將主題背景參考指派給第一個母版，並儲存簡報：

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("input.pptx");
var backgroundStyles = presentation.MasterTheme.FormatScheme.BackgroundFillStyles;
Console.WriteLine($"Background fill styles: {backgroundStyles.Count}");

if (backgroundStyles.Count == 0)
{
    throw new InvalidOperationException("The presentation theme does not contain background fill styles.");
}

presentation.Masters[0].Background.Type = BackgroundType.Themed;
presentation.Masters[0].Background.StyleIndex = 1;

presentation.Save("theme-background.pptx", SaveFormat.Pptx);
```

可見結果取決於母版所參照的主題項目以及版面配置或投影片層級的任何背景覆寫。若投影片使用自己的背景，僅變更母版背景可能不會影響該投影片。若需取得套用繼承後的最終背景，請使用 [Background.GetEffective](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/background/geteffective/)。

{{% alert color="warning" title="警告" %}}
不要將 `StyleIndex` 視為零基索引集合。亦避免從一個檔案硬編碼樣式編號，然後假設在另一個檔案中會呈現相同外觀；主題樣式定義是依簡報而異的。
{{% /alert %}}

{{% alert color="info" title="提示" %}}
若需直接的背景格式設定與背景繼承，請參閱 [Presentation Background](/slides/zh-hant/net/presentation-background/)。
{{% /alert %}}

## **更新主題效果**

主題格式方案包含獨立的 [FillStyles](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.theme/formatscheme/fillstyles/)、[LineStyles](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.theme/formatscheme/linestyles/) 與 [EffectStyles](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.theme/formatscheme/effectstyles/) 集合。一般 Office 主題常包含三個主要樣式項目，分別對應微妙、適中與強烈的格式，但程式碼應檢查每個集合，而非假設固定的數量。

![對同一圖形套用的微妙、適中與強烈主題效果](presentation-design_10.png)

在 C# 中存取這些集合時，集合索引為零基：`[0]` 為第一個儲存的樣式，`[2]` 為第三個。圖形的樣式參考索引是另一個概念，可透過 [IShapeStyle](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ishapestyle/) 取得。修改主題樣式會影響參考該主題樣式的圖形；直接格式設定的圖形可能保持不變。

以下範例檢查必要的樣式項目是否存在，變更第一個線條樣式、變更第三個填色樣式，在第三個效果樣式中啟用外部陰影，並儲存結果：

```csharp
using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("Subtle_Moderate_Intense.pptx");
var formatScheme = presentation.MasterTheme.FormatScheme;

if (formatScheme.LineStyles.Count < 1 || formatScheme.FillStyles.Count < 3 || formatScheme.EffectStyles.Count < 3)
{
    throw new InvalidOperationException("The theme does not contain the style entries required by this example.");
}

formatScheme.LineStyles[0].FillFormat.FillType = FillType.Solid;
formatScheme.LineStyles[0].FillFormat.SolidFillColor.Color = Color.Red;
formatScheme.FillStyles[2].FillType = FillType.Solid;
formatScheme.FillStyles[2].SolidFillColor.Color = Color.ForestGreen;
formatScheme.EffectStyles[2].EffectFormat.EnableOuterShadowEffect();
formatScheme.EffectStyles[2].EffectFormat.OuterShadowEffect.Distance = 10f;

presentation.Save("theme-effects.pptx", SaveFormat.Pptx);
```

對參考這些槽位的圖形而言，第一個主題線條樣式會變為紅色，第三個主題填色樣式會變為實心森林綠，第三個效果樣式會獲得距離 10 點的外部陰影。最終視覺結果仍取決於每個圖形參考的樣式槽位以及是否有直接格式覆寫主題。

![變更線條、填色與陰影設定後的主題效果樣式](presentation-design_11.png)

## **讀取有效主題值**

原始的主題物件會告訴您在特定層級定義了什麼。有效值則告訴您投影片或圖形在繼承與本地覆寫解析後實際使用的內容。對於投影片，請呼叫 [BaseOverrideThemeManager.CreateThemeEffective](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.theme/baseoverridethememanager/createthemeeffective/)。對於背景，使用 [Background.GetEffective](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/background/geteffective/)，對於填色則使用 [FillFormat.GetEffective](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/fillformat/geteffective/)。

以下範例從投影片讀取有效的主題、背景與第一個圖形的填色：

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("input.pptx");
var slide = presentation.Slides[0];
var effectiveTheme = slide.ThemeManager.CreateThemeEffective();
var effectiveBackground = slide.Background.GetEffective();

Console.WriteLine($"Effective major Latin font: {effectiveTheme.FontScheme.Major.LatinFont.FontName}");
Console.WriteLine($"Effective minor Latin font: {effectiveTheme.FontScheme.Minor.LatinFont.FontName}");
Console.WriteLine($"Effective background fill type: {effectiveBackground.FillFormat.FillType}");

if (slide.Shapes.Count > 0)
{
    var effectiveFill = slide.Shapes[0].FillFormat.GetEffective();
    Console.WriteLine($"First shape effective fill type: {effectiveFill.FillType}");
    if (effectiveFill.FillType == FillType.Solid)
    {
        Console.WriteLine($"First shape effective fill color: {effectiveFill.SolidFillColor}");
    }
}
```

使用有效資料進行呈現診斷、驗證與比對。若僅檢查 [Presentation.MasterTheme](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation/mastertheme/)，可能會遺漏會改變最終外觀的母版、版面配置、投影片或圖形覆寫。

## **FAQ**

**我可以在不變更母版的情況下，將主題套用至單一投影片嗎？**

可以。使用投影片的 [SlideThemeManager](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.theme/slidethememanager/) 並初始化其覆寫主題。變更僅限於該投影片；其他投影片仍會繼承其現有的主題。

**將主題從一個簡報傳遞至另一個簡報的最安全方式是什麼？**

在移動投影片並保留其來源外觀時，使用 [IMasterSlideCollection.AddClone](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/imasterslidecollection/addclone/) 將來源母版複製至目標，並使用 [ISlideCollection.AddClone](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/islidecollection/addclone/) 搭配該母版複製投影片。如此可同時保留母版、版面配置與主題。

**我如何在繼承與覆寫之後查看有效值？**

對於投影片或版面配置主題，使用 [BaseOverrideThemeManager.CreateThemeEffective](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.theme/baseoverridethememanager/createthemeeffective/)，對於格式物件則使用相對應的有效資料方法，例如 [Background.GetEffective](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/background/geteffective/) 與 [FillFormat.GetEffective](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/fillformat/geteffective/)。這些 API 會在套用繼承與覆寫後回傳解析後的值。