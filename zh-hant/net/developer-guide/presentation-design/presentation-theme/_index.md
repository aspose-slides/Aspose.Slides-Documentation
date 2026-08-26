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
- 外部佈景主題
- THMX
- 佈景主題顏色
- 附加調色盤
- 佈景主題字型
- 佈景主題樣式
- 佈景主題效果
- PowerPoint
- OpenDocument
- 簡報
- .NET
- C#
- Aspose.Slides
description: "在 Aspose.Slides for .NET 中掌握簡報佈景主題，建立、客製化與轉換具一致品牌形象的 PowerPoint 檔案。"
---
## **簡介**

簡報佈景主題定義了一組協調的顏色、字型、背景樣式、填色、線條與效果。具備佈景主題感知的物件會參照這些共享定義，而不是將每個視覺屬性儲存為固定值，因而一次變更佈景主題即可同時更新多個物件。

在 Aspose.Slides 中，簡報層級的佈景主題可透過 [Presentation.MasterTheme](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation/mastertheme/) 屬性取得。簡報也可以在較低層級擁有佈景主題覆寫。母片可透過 [MasterThemeManager.OverrideTheme](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.theme/masterthememanager/overridetheme/) 覆寫簡報佈景主題，版面配置可透過 [BaseOverrideThemeManager.OverrideTheme](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.theme/baseoverridethememanager/overridetheme/) 覆寫其繼承的佈景主題，個別投影片亦可如此。實務上，投影片的最終佈景主題是透過以下繼承鏈解析：簡報佈景主題 → 母片覆寫 → 版面配置覆寫 → 投影片覆寫。

![佈景主題元件：顏色、字型、背景樣式與效果](theme-constituents.png)

以下章節說明最常見的佈景主題工作流程：檢查佈景主題、變更顏色與字型、複製或套用佈景主題、更新背景與效果樣式，以及在繼承與覆寫解析後讀取實際值。

## **檢查佈景主題**

[MasterTheme](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.theme/mastertheme/) 物件會公開佈景主題的 [ColorScheme](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.theme/mastertheme/colorscheme/)、[FontScheme](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.theme/mastertheme/fontscheme/) 與 [FormatScheme](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.theme/mastertheme/formatscheme/)。在變更之前先檢查這些集合特別有用，因為外部來源的簡報可能在樣式項目的數量與內容上有所差異。

以下範例會讀取主要佈景主題屬性，並回報佈景主題中儲存的背景、填色、線條與效果樣式數量：

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

如果檔案使用多個母片，請勿假設每張投影片都有相同的實際佈景主題。請檢查投影片所屬的母片，並在版面或投影片可能有覆寫時，使用本文稍後說明的實際佈景主題工作流程。

## **變更佈景主題顏色**

具備佈景主題感知的填色、線條與文字可以參照 [SchemeColor](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/schemecolor/) 列舉中的邏輯顏色。當您變更佈景主題的 [IColorScheme](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.theme/icolorscheme/) 中對應的項目時，所有仍參照該佈景主題顏色的物件都會以新值重新解析。直接使用 RGB 顏色的物件不會受到佈景主題顏色更新的影響。

以下端對端範例會建立一個使用 `Accent4` 的圖形，將佈景主題的 `Accent4` 顏色改為紅色，儲存簡報，重新開啟後列印實際填色：

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

由於矩形仍連結至 `Accent4`，佈景主題變更後其可見顏色會變成紅色。若您在圖形上以直接顏色取代方案顏色，之後對 `Accent4` 的變更將不再影響該填色。

### **使用附加調色盤中的顏色**

PowerPoint 會依據佈景主題顏色套用顏色變換，產生較亮與較暗的變體。Aspose.Slides 透過 [ColorTransformOperation](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/colortransformoperation/) 公開這些變換。

![主要佈景主題顏色與由附加調色盤產生的較亮與較暗顏色](additional-palette-colors.png)

**1** - 主要佈景主題顏色。

**2** - 由主要佈景主題顏色產生的較亮與較暗變體。

以下範例會建立六個以 `Accent4` 為基礎的矩形，對其中五個套用亮度變換，並儲存結果：

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape1 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 55, 50);
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

這些變體仍以佈景主題顏色為基礎。若稍後 `Accent4` 變更，變換後的顏色會依新 `Accent4` 的值重新計算。

### **將 `SchemeColor` 值對映至 `IColorScheme` 插槽**

[SchemeColor](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/schemecolor/) 列舉使用 `Text1`、`Background1`、`Text2`、`Background2`，而 [IColorScheme](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.theme/icolorscheme/) 以 `Dark1`、`Light1`、`Dark2`、`Light2` 露出相同的佈景主題插槽。對映關係固定：

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

這些是同一佈景主題插槽的別名；它們不是會在執行時相互轉換的值。

## **變更佈景主題字型**

佈景主題字型方案包含標題的主要字型集合與內文的次要字型集合。 [FontScheme.Major](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.theme/fontscheme/major/) 與 [FontScheme.Minor](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.theme/fontscheme/minor/) 屬性會公開這些集合。

PowerPoint 相容的佈景主題字型識別碼可用於文字格式設定：

* `+mn-lt` - 內文字型 Latin（次要 Latin 字型）
* `+mj-lt` - 標題字型 Latin（主要 Latin 字型）
* `+mn-ea` - 內文字型東亞（次要東亞字型）
* `+mj-ea` - 標題字型東亞（主要東亞字型）

以下範例建立一個使用主要 Latin 佈景主題字型的標題，以及一個使用次要 Latin 佈景主題字型的內文行，然後變更佈景主題字型並儲存結果：

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

標題遵循主要字型，內文則遵循次要字型。若文字使用了明確的字型名稱而非佈景主題識別碼，則在佈景主題字型方案變更時不會自動切換。

主要與次要字型集合也可包含針對個別書寫系統的字型對映，例如西里爾文、阿拉伯文、日文、喬治亞文與Thaana。若要檢查、加入、取代或移除這些對映，請參閱 [Script‑Specific Theme Fonts](/slides/zh-hant/net/script-specific-font-mappings/)。

{{% alert color="info" title="提示" %}}

如需更多簡報字型資訊，請參閱 [PowerPoint Fonts](/slides/zh-hant/net/powerpoint-fonts/)。

{{% /alert %}}

## **複製或套用佈景主題**

以下工作流程解決不同的佈景主題相關問題。

### **將外部佈景主題套用至母片相依的投影片**

當您手上有 PowerPoint 佈景主題檔 (`.thmx`) 且想重新樣式化所有相依於特定母片的投影片時，請使用 [IMasterSlide.ApplyExternalThemeToDependingSlides](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/imasterslide/applyexternalthemetodependingslides/)。從 [Presentation.Masters](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation/masters/) 集合中選取母片（該集合實作 [IMasterSlideCollection](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/imasterslidecollection/)），並將佈景主題檔路徑傳給此方法。

此方法執行以下操作：

1. 依所選母片建立新的母片投影片。  
2. 將外部佈景主題套用至新母片。  
3. 將先前相依於所選母片的所有投影片指派給新母片。  
4. 回傳新建立的 [IMasterSlide](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/imasterslide/)。

以下範例將外部佈景主題套用至相依於第一個母片的投影片，儲存簡報，並重新開啟結果：

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

無效、損毀或不支援的佈景主題可能拋出 [PptxException](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/pptxexception/) 或其格式相關子類別。請驗證使用者提供的路徑、處理檔案系統存取失敗，且僅在成功套用佈景主題後才儲存簡報。

只有相依於所選母片的投影片會被重新指派。屬於其他母片的投影片會保留其現有母片與佈景主題。具備佈景主題感知的顏色、字型、填色、線條、背景與效果會依外部佈景主題重新解析。直接指派的顏色、字型、填色與其他明確格式化可能保持不變。版面層級與投影片層級的覆寫也可能優先於新母片繼承的值。

佈景主題可能參考執行環境中不存在的字型。為確保一致的算繪與匯出，請安裝所需字型、透過 [custom font sources](/slides/zh-hant/net/custom-font/) 提供，或設定 [font substitution](/slides/zh-hant/net/font-substitution/)。

此為直接的母片層級工作流程：方法接受 `.thmx` 檔案路徑，無需手動建立投影片層級或版面層級的佈景主題覆寫。

### **在多母片簡報中套用不同的外部佈景主題**

若事先不確定相關母片是哪一個，可透過 [ISlide.LayoutSlide](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/islide/layoutslide/) 與 [ILayoutSlide.MasterSlide](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ilayoutslide/masterslide/) 從具代表性的投影片取得母片。在套用任何佈景主題之前，請先保存原始母片的參考，因為每次呼叫都會在簡報中建立另一個母片。

以下範例使用兩個章節的投影片來定位它們的母片，並分別為每組套用不同的外部佈景主題：

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

第一次呼叫僅影響相依於 `firstGroupMaster` 的投影片，第二次呼叫僅影響相依於 `secondGroupMaster` 的投影片。屬於其他母片的投影片不會被重新樣式化。

### **搬移投影片時保留來源佈景主題**

若要將投影片移至另一個簡報且保留其原始設計，請使用 [IMasterSlideCollection.AddClone](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/imasterslidecollection/addclone/) 將來源母片複製至目標簡報，接著使用 [ISlideCollection.AddClone](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/islidecollection/addclone/) 連同複製的母片一起複製投影片。如此即可同時攜帶母片、其版面配置與相關佈景主題。

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

當來源投影片必須在目的端顯示相同外觀時，這是推薦的工作流程。僅僅將內容克隆到不相關的目的母片，可能會改變佈景主題驅動的顏色、字型、背景與效果。

### **將佈景主題值套用至現有投影片**

若目標投影片必須保留目前的母片與版面，請從來源佈景主題初始化投影片層級的覆寫。[OverrideTheme.InitColorSchemeFrom](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.theme/overridetheme/initcolorschemefrom/)、[OverrideTheme.InitFontSchemeFrom](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.theme/overridetheme/initfontschemefrom/) 與 [OverrideTheme.InitFormatSchemeFrom](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.theme/overridetheme/initformatschemefrom/) 這三個方法會將三大佈景主題組件複製到覆寫中。

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

此作法會變更該投影片使用的佈景主題，而不會影響其他投影片繼承的佈景主題。若要移除本機覆寫並回復繼承值，只需呼叫 [OverrideTheme.Clear](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.theme/overridetheme/clear/)。

### **將佈景主題覆寫套用至版面配置**

版面層級的覆寫會套用至使用該版面的投影片，除非特定投影片自行設定了覆寫。相同的初始化方法可透過版面的 [LayoutSlideThemeManager](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.theme/layoutslidethememanager/) 使用：

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

在需要多個版面與投影片共享相同基礎設計時，使用母片或簡報層級的佈景主題；在單一版面族需要不同樣式時，使用版面覆寫；僅在真實例外情況下才使用投影片覆寫。過度的投影片層級覆寫會使日後的全域佈景主題變更難以預測。

## **更新佈景主題背景樣式**

佈景主題的背景填色儲存在 [FormatScheme.BackgroundFillStyles](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.theme/formatscheme/backgroundfillstyles/)。PowerPoint 在 UI 中可能呈現的背景選項多於此集合實際儲存的填色定義，因為 UI 可以將佈景主題填色與佈景主題顏色以及其他樣式參照組合使用。

![PowerPoint 佈景主題的背景樣式畫廊](presentation-design_8.png)

在使用背景樣式前，請檢查儲存的集合與目前的 [Background.StyleIndex](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/background/styleindex/)。`StyleIndex` 為 `0` 時表示沒有主題填色；正值則為佈景主題背景樣式參照。這與直接以 .NET 集合索引不同，`.NET` 中的 `[0]` 代表第一個儲存項目。請勿假設每個簡報都有相同數量的背景填色樣式。

以下範例會回報可用的背景填色數量，將有主題參照的背景指派給第一個母片，並儲存簡報：

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

最終可見結果取決於母片參照的佈景主題項目，以及版面或投影片層級的任何背景覆寫。若投影片自行設定背景，僅變更母片背景可能不會影響該投影片。當您需要取得繼承後的最終背景時，請使用 [Background.GetEffective](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/background/geteffective/)。

{{% alert color="warning" title="警告" %}}

不要將 `StyleIndex` 當作零基索引來使用。也請避免硬編碼某個檔案的樣式編號，並假設在其他檔案中會呈現相同外觀；佈景主題樣式定義是依簡報而異的。

{{% /alert %}}

{{% alert color="info" title="提示" %}}

有關直接背景格式設定與背景繼承，請參閱 [Presentation Background](/slides/zh-hant/net/presentation-background/)。

{{% /alert %}}

## **更新佈景主題效果**

佈景主題格式方案包含獨立的 [FillStyles](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.theme/formatscheme/fillstyles/)、[LineStyles](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.theme/formatscheme/linestyles/) 與 [EffectStyles](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.theme/formatscheme/effectstyles/) 集合。一般 Office 佈景主題常包含三個主要樣式項目，分別對應微妙、適中與強烈的視覺效果，但程式碼應自行檢查每個集合，而非假設固定數量。

![微妙、適中與強烈的佈景主題效果套用於相同圖形](presentation-design_10.png)

在 C# 中存取這些集合時，集合索引採零基：`[0]` 為第一個儲存樣式，`[2]` 為第三個。圖形的樣式參照索引是另一概念，透過 [IShapeStyle](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ishapestyle/) 暴露。修改佈景主題樣式會影響參照該主題樣式的圖形；直接格式化的圖形則可能保持不變。

以下範例會檢查必要的樣式項目是否存在，變更第一個線條樣式、變更第三個填色樣式、在第三個效果樣式中啟用外部陰影，最後儲存結果：

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

對於參照這些插槽的圖形而言，第一個主題線條樣式會變成紅色，第三個主題填色樣式會變成實心森林綠，第三個效果樣式會加入距離為 10 點的外部陰影。實際視覺結果仍取決於每個圖形參照的樣式插槽以及是否有直接格式化覆寫主題。

![變更線條、填色與陰影設定後的佈景主題效果樣式](presentation-design_11.png)

## **讀取實際佈景主題值**

原始佈景主題物件告訴您在特定層級中定義了什麼。實際值則告訴您投影片或圖形在繼承與本機覆寫解析後實際使用的內容。對於投影片，呼叫 [BaseOverrideThemeManager.CreateThemeEffective](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.theme/baseoverridethememanager/createthemeeffective/)。對於背景，使用 [Background.GetEffective](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/background/geteffective/)，對於填色則使用 [FillFormat.GetEffective](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/fillformat/geteffective/)。

以下範例會讀取投影片的實際佈景主題、背景與第一個圖形的填色：

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

將實際資料用於算繪偵錯、驗證與比較。如果僅檢查 [Presentation.MasterTheme](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation/mastertheme/)，可能會遺漏母片、版面、投影片或圖形的覆寫，導致錯過最終外觀的變化。

## **常見問題**

**套用外部佈景主題會影響簡報中的每一張投影片嗎？**

不會。[IMasterSlide.ApplyExternalThemeToDependingSlides](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/imasterslide/applyexternalthemetodependingslides/) 僅重新指派相依於所選母片的投影片。使用其他母片的投影片會保留既有佈景主題。

**我可以在不變更母片的情況下，只對單一投影片套用佈景主題嗎？**

可以。使用投影片的 [SlideThemeManager](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.theme/slidethememanager/) 並初始化其覆寫佈景主題。變更將僅限於該投影片，其餘投影片仍會繼承現有佈景主題。

**將佈景主題從一個簡報搬移到另一個簡報的最安全方式是什麼？**

在搬移投影片且需保留來源外觀時，先將來源母片以 [IMasterSlideCollection.AddClone](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/imasterslidecollection/addclone/) 複製至目標簡報，然後以 [ISlideCollection.AddClone](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/islidecollection/addclone/) 搭配該母片複製投影片。如此即可同時保留母片、版面與佈景主題。

**我要如何在繼承與覆寫之後看到實際值？**

對於投影片或版面佈景主題，使用 [BaseOverrideThemeManager.CreateThemeEffective](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.theme/baseoverridethememanager/createthemeeffective/)；對於格式物件，如 [Background.GetEffective](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/background/geteffective/) 與 [FillFormat.GetEffective](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/fillformat/geteffective/)，則使用相應的實際資料方法。這些 API 會在繼承與覆寫完成後回傳解析後的值。