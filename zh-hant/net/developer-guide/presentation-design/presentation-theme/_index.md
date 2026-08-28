---
title: 管理 .NET 中的簡報主題
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
- 外部主題
- THMX
- 主題顏色
- 額外調色盤
- 主題字型
- 主題樣式
- 主題效果
- PowerPoint
- OpenDocument
- 簡報
- .NET
- C#
- Aspose.Slides
description: "在 Aspose.Slides for .NET 中使用母版簡報主題，建立、客製化與轉換具一致品牌形象的 PowerPoint 檔案。"
---
## **簡介**

簡報主題定義了一組協調的顏色、字型、背景樣式、填滿、線條與效果。具備主題感知的物件會參考這些共享定義，而不是將每個視覺屬性儲存為固定值，因而在變更主題時可以一次更新許多物件。

在 Aspose.Slides 中，簡報層級的主題可透過 [Presentation.MasterTheme](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation/mastertheme/) 屬性取得。簡報也可以在較低層級上覆寫主題。母片可以透過 [MasterThemeManager.OverrideTheme](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.theme/masterthememanager/overridetheme/) 覆寫簡報主題，版面配置可以透過 [BaseOverrideThemeManager.OverrideTheme](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.theme/baseoverridethememanager/overridetheme/) 覆寫其繼承的主題，單一投影片亦可如此。實務上，投影片的實際主題是透過以下繼承鏈解析：簡報主題 → 母片覆寫 → 版面配置覆寫 → 投影片覆寫。

![Theme components: colors, fonts, background styles, and effects](theme-constituents.png)

以下各節說明最常見的主題工作流程：檢視主題、變更顏色與字型、複製或套用主題、更新背景與效果樣式，以及在繼承與覆寫完成後讀取實際值。

## **檢視主題**

[MasterTheme](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.theme/mastertheme/) 物件會公開主題的 [ColorScheme](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.theme/mastertheme/colorscheme/)、[FontScheme](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.theme/mastertheme/fontscheme/) 與 [FormatScheme](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.theme/mastertheme/formatscheme/)。在變更之前先檢查這些集合，對於來自外部來源的簡報尤為有用，因為樣式項目的數量與內容可能不同。

以下範例讀取主要主題屬性，並回報主題中儲存的背景、填滿、線條與效果樣式數量：

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

如果檔案使用多個母片，請勿假設每張投影片都有相同的實際主題。應檢查與投影片關聯的母片，並在版面配置或投影片覆寫可能存在時，使用本文後面說明的實際主題工作流程。

## **變更主題顏色**

具備主題感知的填滿、線條與文字可以參照 [SchemeColor](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/schemecolor/) 列舉中的邏輯顏色。當您在主題的 [IColorScheme](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.theme/icolorscheme/) 中變更相應條目時，所有仍參照該主題顏色的物件都會以新值重新解析。使用直接 RGB 顏色的物件不會受到主題顏色更新的影響。

以下端對端範例建立一個使用 `Accent4` 的圖形，將主題的 `Accent4` 顏色改為紅色，儲存簡報、重新開啟，並印出實際填滿顏色：

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

由於矩形仍連結至 `Accent4`，主題變更後其可見顏色會變為紅色。若您在圖形上將配色方案顏色替換為直接顏色，之後對 `Accent4` 的變更將不再影響該填滿。

### **使用額外調色盤的顏色**

PowerPoint 會透過套用顏色變換，從主題顏色衍生較亮或較暗的變體。Aspose.Slides 透過 [ColorTransformOperation](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/colortransformoperation/) 暴露這些變換。

![Main theme colors and lighter and darker colors generated from the additional palette](additional-palette-colors.png)

**1** - 主要主題顏色。

**2** - 由主要主題顏色產生的較亮與較暗變體。

以下範例以 `Accent4` 為基礎建立六個矩形，對其中五個套用亮度變換，並儲存結果：

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

這些變體仍以主題顏色為基礎。如果之後 `Accent4` 變更，變換後的顏色會根據新的 `Accent4` 重新計算。

### **將 `SchemeColor` 值對映至 `IColorScheme` 插槽**

[SchemeColor](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/schemecolor/) 列舉使用 `Text1`、`Background1`、`Text2`、`Background2`，而 [IColorScheme](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.theme/icolorscheme/) 則以 `Dark1`、`Light1`、`Dark2`、`Light2` 暴露相同的主題插槽。對映固定如下：

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

這些是同一主題插槽的別名；它們並非會在執行時相互轉換的值。

## **變更主題字型**

主題字型方案包含標題的主要字型集合與內文的次要字型集合。[FontScheme.Major](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.theme/fontscheme/major/) 與 [FontScheme.Minor](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.theme/fontscheme/minor/) 屬性會公開這兩個集合。

PowerPoint 相容的主題字型識別碼可在文字格式化時使用：

* `+mn-lt` - 內文字型 Latin（次要 Latin 字型）
* `+mj-lt` - 標題字型 Latin（主要 Latin 字型）
* `+mn-ea` - 內文字型 East Asian（次要 East Asian 字型）
* `+mj-ea` - 標題字型 East Asian（主要 East Asian 字型）

以下範例建立一個使用主要 Latin 主題字型的標題與一個使用次要 Latin 主題字型的內文，然後變更主題字型並儲存結果：

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

標題遵循主要字型，內文字則遵循次要字型。若文字明確指定字型名稱而非主題識別碼，則在主題字型方案變更時不會自動切換。

主要與次要字型集合也可以包含針對特定書寫系統（如西里爾文、阿拉伯文、日文、格魯吉亞文與塔納字母）的字型對映。若要檢查、加入、取代或移除這些對映，請參閱 [Script-Specific Theme Fonts](/slides/zh-hant/net/script-specific-font-mappings/)。

{{% alert color="info" title="Tip" %}}

欲取得更多簡報字型資訊，請參考 [PowerPoint Fonts](/slides/zh-hant/net/powerpoint-fonts/)。

{{% /alert %}}

## **複製或套用主題**

以下工作流程解決不同的主題相關問題。

### **將外部主題套用至受特定母片影響的投影片**

當您有 PowerPoint 主題檔（`.thmx`）且想重新樣式化所有依賴特定母片的投影片時，使用 [IMasterSlide.ApplyExternalThemeToDependingSlides](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/imasterslide/applyexternalthemetodependingslides/)。從 [Presentation.Masters](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation/masters/) 集合中選取母片（該集合實作 [IMasterSlideCollection](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/imasterslidecollection/)），然後將主題檔路徑傳入方法。

此方法執行以下操作：

1. 以選取的母片為基礎建立新母片。
1. 將外部主題套用至新母片。
1. 將先前依賴選取母片的所有投影片指派給新母片。
1. 回傳新建立的 [IMasterSlide](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/imasterslide/)。

以下範例將外部主題套用至依賴第一個母片的投影片，儲存簡報，並重新開啟結果：

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");
var selectedMaster = presentation.Masters[0];
var themedMaster = selectedMaster.ApplyExternalThemeToDependingSlides("corporate-theme.thmx");

Console.WriteLine($"Created master: {themedMaster.Name}");
presentation.Save("presentation-with-external-theme.pptx", SaveFormat.Pptx);
```

無效、損毀或不支援的主題可能會拋出 [PptxException](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/pptxexception/) 或其格式相關子類別。請驗證使用者提供的路徑、處理檔案系統存取失敗，並僅在主題成功套用後才儲存簡報。

僅重新指派依賴所選母片的投影片。屬於其他母片的投影片會保留其既有母片與主題。具主題感知的顏色、字型、填滿、線條、背景與效果會以外部主題解析。直接指派的顏色、字型、填滿與其他明確格式化可能保持不變。版面配置層級與投影片層級的覆寫也可能優先於新母片繼承的值。

主題可能參考執行環境中不存在的字型。為確保渲染與匯出一致，請安裝必要字型、透過 [custom font sources](/slides/zh-hant/net/custom-font/) 提供，或設定 [font substitution](/slides/zh-hant/net/font-substitution/)。

此為直接的母片層級工作流程：方法接受 `.thmx` 檔案路徑，無需手動建立投影片層級或版面配置層級的主題覆寫。

### **在多母片簡報中套用不同外部主題**

當事先不知道相關母片時，請透過 [ISlide.LayoutSlide](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/islide/layoutslide/) 與 [ILayoutSlide.MasterSlide](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ilayoutslide/masterslide/) 從具代表性的投影片取得母片。於套用任何主題前先保存原始母片參考，因為每次呼叫都會在簡報中建立另一個母片。

以下範例使用兩個區段的投影片來定位其母片，並對每組套用不同的外部主題：

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("multi-master-presentation.pptx");

if (presentation.Slides.Count < 5)
{
    Console.WriteLine("The presentation does not contain the expected representative slides.");
}
else
{
    var firstGroupMaster = presentation.Slides[0].LayoutSlide.MasterSlide;
    var secondGroupMaster = presentation.Slides[4].LayoutSlide.MasterSlide;

    if (ReferenceEquals(firstGroupMaster, secondGroupMaster))
    {
        Console.WriteLine("The representative slides use the same master.");
    }
    else
    {
        var firstThemedMaster = firstGroupMaster.ApplyExternalThemeToDependingSlides("blue-theme.thmx");
        var secondThemedMaster = secondGroupMaster.ApplyExternalThemeToDependingSlides("green-theme.thmx");

        Console.WriteLine($"First themed master: {firstThemedMaster.Name}");
        Console.WriteLine($"Second themed master: {secondThemedMaster.Name}");
        presentation.Save("multi-master-with-external-themes.pptx", SaveFormat.Pptx);
    }
}
```

第一次呼叫僅影響依賴 `firstGroupMaster` 的投影片，第二次呼叫僅影響依賴 `secondGroupMaster` 的投影片。屬於其他母片的投影片不會被重新樣式化。

### **移動投影片時保留來源主題**

若要將投影片移至另一個簡報且保留其原始設計，請先使用 [IMasterSlideCollection.AddClone](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/imasterslidecollection/addclone/) 將來源母片複製到目標簡報，然後使用 [ISlideCollection.AddClone](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/islidecollection/addclone/) 連同複製的母片一起複製投影片。如此即可同時攜帶母片、其版面配置與相關主題。

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

此為在目的端保持來源投影片外觀的最佳工作流程。僅將內容克隆至不相關的目的母片可能會改變主題驅動的顏色、字型、背景與效果。

### **將主題值套用至現有投影片**

如果目標投影片必須保留目前的母片與版面配置，請從來源主題初始化投影片層級的覆寫。使用 [OverrideTheme.InitColorSchemeFrom](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.theme/overridetheme/initcolorschemefrom/)、[OverrideTheme.InitFontSchemeFrom](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.theme/overridetheme/initfontschemefrom/) 與 [OverrideTheme.InitFormatSchemeFrom](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.theme/overridetheme/initformatschemefrom/) 方法，將三個主要主題元件複製到覆寫中。

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

此會變更該投影片使用的主題，而不會影響其他投影片繼承的主題。若要移除本機覆寫並回復至繼承值，請呼叫 [OverrideTheme.Clear](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.theme/overridetheme/clear/)。

### **將主題覆寫套用至版面配置**

版面配置層級的覆寫會套用至使用該版面配置的投影片，除非特定投影片有自己的覆寫。可透過版面配置的 [LayoutSlideThemeManager](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.theme/layoutslidethememanager/) 使用相同的初始化方法：

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

當多個版面配置與投影片應共享相同基礎設計時，使用母片或簡報層級的主題；若只有單一版面配置族需要不同樣式，則使用版面配置覆寫；僅在真正例外情況下才使用投影片覆寫。過度的投影片層級覆寫會使之後的全域主題變更變得難以預測。

## **更新主題背景樣式**

主題的背景填滿儲存在 [FormatScheme.BackgroundFillStyles](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.theme/formatscheme/backgroundfillstyles/)。PowerPoint 在 UI 中可以呈現的背景選項，往往多於此集合實際儲存的填滿定義，因為 UI 能將主題填滿與主題顏色及其他樣式參照結合。

![PowerPoint background style gallery for a presentation theme](presentation-design_8.png)

使用背景樣式前，請檢查已儲存的集合以及目前的 [Background.StyleIndex](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/background/styleindex/)。`StyleIndex` 為 `0` 表示沒有主題填滿；正值則為主題背景樣式參照。這與 .NET 集合的索引不同，後者的 `[0]` 代表第一筆儲存項目。請勿假設每個簡報都有相同數量的背景填滿樣式。

以下範例回報可用的背景填滿數量，將主題背景參照指派給第一個母片，並儲存簡報：

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

最終呈現取決於母片參照的主題項目以及版面配置或投影片層級的任何背景覆寫。如果投影片使用自己的背景，僅變更母片背景可能不會影響該投影片。需要取得繼承後最終背景時，請使用 [Background.GetEffective](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/background/geteffective/)。

{{% alert color="warning" title="Warning" %}}

請勿將 `StyleIndex` 當作零基集合索引使用。也避免將來自單一檔案的樣式編號硬編碼到其他檔案，因為主題樣式定義是簡報特有的。

{{% /alert %}}

{{% alert color="info" title="Tip" %}}

有關直接背景格式化與背景繼承，請參閱 [Presentation Background](/slides/zh-hant/net/presentation-background/)。

{{% /alert %}}

## **更新主題效果**

主題格式方案包含獨立的 [FillStyles](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.theme/formatscheme/fillstyles/)、[LineStyles](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.theme/formatscheme/linestyles/) 與 [EffectStyles](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.theme/formatscheme/effectstyles/) 集合。典型的 Office 主題常包含三個主要樣式條目，視覺上對應微妙、適中與強烈的格式化，但程式碼應檢查每個集合，而非假設固定數量。

![Subtle, moderate, and intense theme effects applied to the same shape](presentation-design_10.png)

在 C# 中存取這些集合時，集合索引為零基：`[0]` 為第一筆儲存樣式，`[2]` 為第三筆。圖形的樣式參照索引則是另一概念，透過 [IShapeStyle](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ishapestyle/) 暴露。修改主題樣式會影響引用該樣式的圖形；直接格式化的圖形可能保持不變。

以下範例檢查必要的樣式條目是否存在，變更第一個線條樣式、變更第三個填滿樣式、在第三個效果樣式中啟用外部陰影，並儲存結果：

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

對於引用這些插槽的圖形而言，第一個主題線條樣式會變成紅色，第三個主題填滿樣式會變為實心森林綠，第三個效果樣式會加入距離為 10 點的外部陰影。最終視覺結果仍取決於每個圖形參照的樣式插槽以及是否有直接格式化覆寫主題。

![Theme effect styles after changing line, fill, and shadow settings](presentation-design_11.png)

## **判斷實際實心填滿是否使用主題顏色**

填滿可以直接儲存在物件上，或由段落、版面配置、母片、主題樣式或其他格式層級繼承。呼叫 [IFillFormat.GetEffective](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ifillformat/geteffective/) 可將該層級階層解析為不可變的 [IFillFormatEffectiveData](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ifillformateffectivedata/)。首先檢查 [IFillFormatEffectiveData.FillType](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ifillformateffectivedata/filltype/)。只有在其為 `FillType.Solid` 時才讀取實心填滿屬性。

對於實心填滿，[IFillFormatEffectiveData.SolidFillColor](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ifillformateffectivedata/solidfillcolor/) 會在繼承、主題查找與顏色變換完成後回傳最終渲染的 RGB 值。[IFillFormatEffectiveData.SolidFillSchemeColor](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ifillformateffectivedata/solidfillschemecolor/) 則回傳對應的邏輯 [SchemeColor](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/schemecolor/) 插槽，例如 `Text1` 或 `Accent6`。`SchemeColor.NotDefined` 表示實際實心填滿並非基於配色方案顏色。於僅使用主題顏色或直接 RGB 顏色的工作流程中，該值即代表直接 RGB 填滿。

請勿僅以本地的 [IColorFormat.SchemeColor](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/icolorformat/schemecolor/) 判斷填滿。例如文字片段可能本地未定義配色方案顏色（`NotDefined`），但其實有效填滿繼承自主題顏色，最終會解析為 `Text1` 或 `Accent6`。相對地，`SolidFillSchemeColor` 告訴您是哪個邏輯主題插槽產生了最終顏色，但不會說明該插槽來源於物件、段落、版面配置、母片或其他層級。

以下範例載入簡報、稽核圖形填滿與文字片段填滿，印出每個最終 RGB 值與相關配色方案顏色，並標示不會追蹤主題顏色變更的實心填滿：

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("input.pptx");

var slideCount = presentation.Slides.Count;
for (var slideIndex = 0; slideIndex < slideCount; slideIndex++)
{
    var slide = presentation.Slides[slideIndex];

    var shapeCount = slide.Shapes.Count;
    for (var shapeIndex = 0; shapeIndex < shapeCount; shapeIndex++)
    {
        var shape = slide.Shapes[shapeIndex];
        var shapeName = $"Slide {slideIndex + 1}, shape {shapeIndex + 1}";
        AuditFill(shapeName, shape.FillFormat);

        if (shape is IAutoShape autoShape)
        {
            var paragraphCount = autoShape.TextFrame.Paragraphs.Count;
            for (var paragraphIndex = 0; paragraphIndex < paragraphCount; paragraphIndex++)
            {
                var paragraph = autoShape.TextFrame.Paragraphs[paragraphIndex];

                var portionCount = paragraph.Portions.Count;
                for (var portionIndex = 0; portionIndex < portionCount; portionIndex++)
                {
                    var portion = paragraph.Portions[portionIndex];
                    var portionName = $"{shapeName}, paragraph {paragraphIndex + 1}, portion {portionIndex + 1}";
                    AuditFill(portionName, portion.PortionFormat.FillFormat);
                }
            }
        }
    }
}

static void AuditFill(string objectName, IFillFormat localFill)
{
    var effectiveFill = localFill.GetEffective();

    if (effectiveFill.FillType != FillType.Solid)
    {
        Console.WriteLine($"{objectName}: fill type = {effectiveFill.FillType}; not a solid fill.");
        return;
    }

    var rgb = effectiveFill.SolidFillColor;
    var effectiveSchemeColor = effectiveFill.SolidFillSchemeColor;
    var localSchemeColor = localFill.SolidFillColor.SchemeColor;

    Console.WriteLine($"{objectName}: RGB = #{rgb.R:X2}{rgb.G:X2}{rgb.B:X2}");
    Console.WriteLine($"{objectName}: local scheme = {localSchemeColor}, effective scheme = {effectiveSchemeColor}");

    if (effectiveSchemeColor == SchemeColor.NotDefined)
    {
        Console.WriteLine($"{objectName}: direct RGB or another non-scheme fill; audit as theme-independent.");
    }
    else
    {
        Console.WriteLine($"{objectName}: theme-dependent through {effectiveSchemeColor}.");
    }
}
```

`NotDefined` 分支提供一份稽核清單，列出在更換品牌調色盤時不會回應主題顏色變更的實心填滿。檢視這些物件以確保簡報符合新品牌需求。報告的 RGB 值仍顯示當前外觀，而配色方案值說明該外觀是否與主題相連。

實際格式物件是快照。在變更簡報主題、主題覆寫或任何繼承格式後，請再次呼叫 `GetEffective` 並取得新的 `IFillFormatEffectiveData` 物件，再進行比較或報告。

## **讀取實際主題值**

原始主題物件只告訴您在特定層級定義了什麼。實際值則告訴您投影片或圖形在繼承與本機覆寫解析後實際使用的內容。對於投影片，呼叫 [BaseOverrideThemeManager.CreateThemeEffective](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.theme/baseoverridethememanager/createthemeeffective/)。對於背景，使用 [Background.GetEffective](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/background/geteffective/)，對於填滿，使用 [FillFormat.GetEffective](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/fillformat/geteffective/)。

以下範例讀取投影片的實際主題、背景與第一個圖形的填滿：

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

使用實際資料進行渲染診斷、驗證與比較。若僅檢查 [Presentation.MasterTheme](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation/mastertheme/)，可能會遺漏母片、版面配置、投影片或圖形的覆寫，導致最終外觀與預期不符。

## **常見問題**

**套用外部主題會影響簡報內的每張投影片嗎？**

不會。[IMasterSlide.ApplyExternalThemeToDependingSlides](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/imasterslide/applyexternalthemetodependingslides/) 僅重新指派依賴所選母片的投影片。使用其他母片的投影片會保留其既有主題。

**我可以在不變更母片的情況下，只對單一投影片套用主題嗎？**

可以。使用該投影片的 [SlideThemeManager](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.theme/slidethememanager/) 並初始化其覆寫主題。變更僅限於該投影片；其他投影片仍會繼承既有主題。

**將主題從一個簡報搬移到另一個簡報的最安全方式是什麼？**

在搬移投影片且需保留來源外觀時，請先使用 [IMasterSlideCollection.AddClone](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/imasterslidecollection/addclone/) 將來源母片複製至目標簡報，然後使用 [ISlideCollection.AddClone](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/islidecollection/addclone/) 搭配該母片複製投影片。如此即可同時保留母片、版面配置與主題。

**如何查看繼承與覆寫後的實際值？**

對於投影片或版面配置主題，使用 [BaseOverrideThemeManager.CreateThemeEffective](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.theme/baseoverridethememanager/createthemeeffective/)，對於格式物件則使用相應的實際資料方法，例如 [Background.GetEffective](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/background/geteffective/) 與 [FillFormat.GetEffective](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/fillformat/geteffective/)。這些 API 會在繼承與覆寫完成後回傳解析後的值。