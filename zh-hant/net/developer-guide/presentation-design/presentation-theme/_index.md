---
title: 在 .NET 中管理簡報佈景主題
linktitle: 簡報佈景主題
type: docs
weight: 10
url: /zh-hant/net/presentation-theme/
keywords:
- PowerPoint 佈景主題
- 簡報佈景主題
- 投影片佈景主題
- 設定佈景主題
- 變更佈景主題
- 管理佈景主題
- 佈景顏色
- 其他調色盤
- 佈景字型
- 佈景樣式
- 佈景效果
- PowerPoint
- OpenDocument
- 簡報
- .NET
- C#
- Aspose.Slides
description: "在 Aspose.Slides for .NET 中管理簡報佈景主題，以建立、客製化及轉換具有一致品牌形象的 PowerPoint 檔案。"
---
## **簡介**

簡報佈景主題定義了一組協調的顏色、字型、背景樣式、填充、線條與效果。支援佈景的物件會參考這些共享定義，而不是將每個視覺屬性以固定值儲存，因此變更佈景時可以一次更新許多物件。

在 Aspose.Slides 中，可透過 [Presentation.MasterTheme](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation/mastertheme/) 屬性取得簡報層級的佈景。簡報亦可以在較低層級包含佈景覆寫。主投影片可透過 [MasterThemeManager.OverrideTheme](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.theme/masterthememanager/overridetheme/) 覆寫簡報佈景，版面可透過 [BaseOverrideThemeManager.OverrideTheme](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.theme/baseoverridethememanager/overridetheme/) 覆寫其繼承的佈景，單一投影片亦可如此。實務上，投影片的有效佈景是透過以下繼承鏈解析：簡報佈景 → 主投影片覆寫 → 版面覆寫 → 投影片覆寫。

![佈景組件：顏色、字型、背景樣式與效果](theme-constituents.png)

以下章節說明最常見的佈景工作流程：檢查佈景、變更顏色與字型、複製或套用佈景、更新背景與效果樣式，以及在繼承與覆寫解析後讀取有效值。

## **檢查佈景**

[MasterTheme](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.theme/mastertheme/) 物件會公開佈景的 [ColorScheme](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.theme/mastertheme/colorscheme/)、[FontScheme](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.theme/mastertheme/fontscheme/) 與 [FormatScheme](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.theme/mastertheme/formatscheme/)。在變更之前先檢查這些集合特別有用，因為來自外部來源的簡報其樣式項目的數量與內容可能會不同。

以下範例讀取主要佈景屬性，並回報佈景中儲存的背景、填充、線條與效果樣式的數量：

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

如果檔案使用多個主投影片，請勿假設每張投影片都有相同的有效佈景。檢查與投影片關聯的主投影片，並在版面或投影片可能有覆寫時使用本文稍後說明的有效佈景工作流程。

## **變更佈景顏色**

支援佈景的填充、線條與文字可以參考 [SchemeColor](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/schemecolor/) 列舉中的邏輯顏色。當您變更佈景的 [IColorScheme](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.theme/icolorscheme/) 中對應的項目時，所有仍參考該佈景顏色的物件都會以新值重新解析。直接使用 RGB 顏色的物件不會因佈景顏色更新而變更。

以下端對端範例建立一個使用 `Accent4` 的圖形，將佈景的 `Accent4` 顏色改為紅色，儲存簡報、重新開啟，並列印有效填充顏色：

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

因為矩形仍連結到 `Accent4`，在佈景變更後其可見顏色會變成紅色。如果您在圖形上以直接顏色取代方案顏色，之後對 `Accent4` 的變更將不會再影響該填充。

### **使用額外調色盤的顏色**

PowerPoint 透過應用顏色變換，從佈景色衍生出較亮與較暗的變體。Aspose.Slides 透過 [ColorTransformOperation](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/colortransformoperation/) 暴露這些變換。

![主要佈景顏色以及由額外調色盤產生的較亮與較暗顏色](additional-palette-colors.png)

**1** - 主要佈景顏色。

**2** - 由主要佈景顏色產生的較亮與較暗變體。

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

這些變體仍以佈景顏色為基礎。若稍後 `Accent4` 變更，變換後的顏色會以新的 `Accent4` 值重新計算。

### **將 `SchemeColor` 值映射到 `IColorScheme` 插槽**

[SchemeColor](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/schemecolor/) 列舉使用 `Text1`、`Background1`、`Text2`、`Background2`，而 [IColorScheme](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.theme/icolorscheme/) 則以 `Dark1`、`Light1`、`Dark2`、`Light2` 露出相同的佈景插槽。映射是固定的：

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

這些只是同一佈景插槽的別名，並非會在執行時相互轉換的值。

## **變更佈景字型**

佈景字型方案包含用於標題的主要字型集合與用於正文的次要字型集合。[FontScheme.Major](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.theme/fontscheme/major/) 與 [FontScheme.Minor](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.theme/fontscheme/minor/) 屬性會公開這些集合。

PowerPoint 相容的佈景字型識別碼可用於文字格式化：

* `+mn-lt` - 正文字型 Latin（次要 Latin 字型）
* `+mj-lt` - 標題字型 Latin（主要 Latin 字型）
* `+mn-ea` - 正文字型 East Asian（次要 East Asian 字型）
* `+mj-ea` - 標題字型 East Asian（主要 East Asian 字型）

以下範例建立一個使用主要 Latin 佈景字型的標題，以及一行使用次要 Latin 佈景字型的正文。然後變更佈景字型並儲存結果：

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

標題遵循主要字型，正文遵循次要字型。若文字使用明確的字型名稱而非佈景識別碼，則在佈景字型方案變更時不會自動切換。

主要與次要字型集合也可以包含針對個別書寫系統（例如西里爾文、阿拉伯文、日文、喬治亞文與塔安文）的字型映射。若要檢查、加入、取代或移除這些映射，請參閱 [Script-Specific Theme Fonts](/slides/zh-hant/net/script-specific-font-mappings/)。

{{% alert color="info" title="Tip" %}}
如需取得有關簡報字型的更多資訊，請參閱 [PowerPoint Fonts](/slides/zh-hant/net/powerpoint-fonts/)。
{{% /alert %}}

## **複製或套用佈景**

有兩種常見的工作流程，且解決的問題不同。

### **在移動投影片時保留來源佈景**

若要將投影片移至其他簡報且保留其原始設計，請使用 [IMasterSlideCollection.AddClone](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/imasterslidecollection/addclone/) 將來源主投影片克隆至目標簡報，然後使用 [ISlideCollection.AddClone](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/islidecollection/addclone/) 與已克隆的主投影片一起克隆投影片。這會將主投影片、其版面與相關佈景一起帶入。

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

當來源投影片必須在目的地呈現相同外觀時，此為首選工作流程。僅將內容克隆到不相關的目的地主投影片，可能會變更以佈景驅動的顏色、字型、背景與效果。

### **將佈景值套用至現有投影片**

若目標投影片必須保留目前的主投影片與版面，請從來源佈景初始化投影片層級的覆寫。[OverrideTheme.InitColorSchemeFrom](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.theme/overridetheme/initcolorschemefrom/)、[OverrideTheme.InitFontSchemeFrom](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.theme/overridetheme/initfontschemefrom/) 與 [OverrideTheme.InitFormatSchemeFrom](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.theme/overridetheme/initformatschemefrom/) 方法會將三個主要佈景元件複製至覆寫。

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

此變更只會影響該投影片使用的佈景，不會改變其他投影片繼承的佈景。若要移除本地覆寫並返回繼承值，請呼叫 [OverrideTheme.Clear](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.theme/overridetheme/clear/)。

### **將佈景覆寫套用至版面**

版面層級的覆寫會作用於使用該版面的投影片，除非特定投影片有自己的覆寫。相同的初始化方法可透過版面的 [LayoutSlideThemeManager](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.theme/layoutslidethememanager/) 使用：

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

當許多版面與投影片應共享相同基礎設計時，使用主投影片或簡報層級的佈景；當單一版面族需要不同樣式時使用版面覆寫；僅在真正例外的情況下使用投影片覆寫。過度的投影片層級覆寫會使之後的全域佈景變更難以預測。

## **更新佈景背景樣式**

佈景的背景填充儲存在 [FormatScheme.BackgroundFillStyles](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.theme/formatscheme/backgroundfillstyles/)。PowerPoint 在 UI 中提供的背景選項可能多於此集合實際儲存的填充定義，因為 UI 可以將佈景填充與佈景顏色及其他樣式參考結合。

![PowerPoint 佈景主題的背景樣式圖庫](presentation-design_8.png)

在使用背景樣式前，請檢查已儲存的集合以及目前的 [Background.StyleIndex](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/background/styleindex/)。`StyleIndex` 使用 `0` 代表無佈景填充；正值代表佈景背景樣式參照。這與直接索引 .NET 集合不同，後者的 `[0]` 表示第一個儲存項目。請勿假設每個簡報都有相同數量的背景填充樣式。

以下範例回報可用的背景填充數量，將佈景背景參照指派給第一個主投影片，並儲存簡報：

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

最終顯示結果取決於主投影片參照的佈景項目以及版面或投影片層級的任何背景覆寫。若投影片使用自己的背景，只變更主投影片背景可能不會影響該投影片。需要得知繼承後最終背景時，請使用 [Background.GetEffective](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/background/geteffective/)。

{{% alert color="warning" title="Warning" %}}
請勿將 `StyleIndex` 視為零基集合索引。也避免從一個檔案硬編碼樣式編號，並假設在另一個檔案中會有相同外觀；佈景樣式定義是與簡報相依的。
{{% /alert %}}

{{% alert color="info" title="Tip" %}}
欲直接格式化背景與背景繼承，請參閱 [Presentation Background](/slides/zh-hant/net/presentation-background/)。
{{% /alert %}}

## **更新佈景效果**

佈景格式方案包含獨立的 [FillStyles](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.theme/formatscheme/fillstyles/)、[LineStyles](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.theme/formatscheme/linestyles/) 與 [EffectStyles](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.theme/formatscheme/effectstyles/) 集合。典型的 Office 佈景常包含三個主要樣式項目，視覺上分別對應微妙、適中與強烈的格式，但程式碼應檢查每個集合，而非假設固定數量。

![在同一圖形上套用微妙、適中與強烈的佈景效果](presentation-design_10.png)

在 C# 中存取這些集合時，集合索引為零基：`[0]` 為第一個儲存的樣式，`[2]` 為第三個。圖形的樣式參照索引是另一概念，透過 [IShapeStyle](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ishapestyle/) 暴露。修改佈景樣式會影響參照該佈景樣式的圖形；直接格式化的圖形可能保持不變。

以下範例檢查必要的樣式項目是否存在，變更第一個線條樣式、變更第三個填充樣式、在第三個效果樣式中啟用外部陰影，並儲存結果：

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

對於參照這些插槽的圖形而言，第一個佈景線條樣式將變成紅色，第三個佈景填充樣式將變成實心森林綠，第三個效果樣式則會添加距離為 10 點的外部陰影。最終的視覺結果仍取決於每個圖形參照的樣式插槽以及是否有直接格式化覆寫佈景。

## **讀取有效的佈景值**

原始佈景物件告訴您在特定層級定義了什麼。有效值則告訴您投影片或圖形在繼承與本地覆寫解析後實際使用的內容。對於投影片，呼叫 [BaseOverrideThemeManager.CreateThemeEffective](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.theme/baseoverridethememanager/createthemeeffective/)。對於背景，使用 [Background.GetEffective](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/background/geteffective/)，對於填充則使用 [FillFormat.GetEffective](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/fillformat/geteffective/)。

以下範例從投影片讀取有效佈景、背景以及第一個圖形的填充：

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

使用有效資料進行渲染偵測、驗證與比較。如果僅檢查 [Presentation.MasterTheme](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation/mastertheme/)，可能會錯過會改變最終外觀的主投影片、版面、投影片或圖形覆寫。

## **常見問題**

**我可以在不變更主投影片的情況下套用佈景至單一投影片嗎？**

可以。使用投影片的 [SlideThemeManager](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.theme/slidethememanager/) 並初始化其覆寫佈景。變更僅會影響該投影片，其他投影片仍會繼承現有佈景。

**將佈景從一個簡報搬移到另一個簡報的最安全方式是什麼？**

在搬移投影片且需保留來源外觀時，將來源主投影片克隆至目標簡報，然後使用 [IMasterSlideCollection.AddClone](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/imasterslidecollection/addclone/) 與 [ISlideCollection.AddClone](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/islidecollection/addclone/) 連同該主投影片一起克隆投影片。這會同時保留主投影片、版面與佈景。

**如何查看繼承與覆寫後的有效值？**

對於投影片或版面佈景，使用 [BaseOverrideThemeManager.CreateThemeEffective](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.theme/baseoverridethememanager/createthemeeffective/)。對於格式物件（如 [Background.GetEffective](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/background/geteffective/) 與 [FillFormat.GetEffective](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/fillformat/geteffective/)），使用對應的有效資料方法。這些 API 會在繼承與覆寫套用後返回解析後的值。