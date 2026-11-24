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
description: "在 Aspose.Slides for .NET 中掌握簡報主題，建立、客製化與轉換具一致品牌形象的 PowerPoint 檔案。"
---
## **簡介**

簡報主題定義了一組協調的顏色、字型、背景樣式、填色、線條與效果。具備主題感知的物件會引用這些共享的定義，而不是將每個視覺屬性儲存為固定值，因而一次變更主題即可更新許多物件。

在 Aspose.Slides 中，簡報層級的主題可透過 [Presentation.MasterTheme](https://reference.aspose.com/slides/net/aspose.slides/presentation/mastertheme/) 屬性取得。簡報也可以在較低層級包含主題覆寫。母片可透過 [MasterThemeManager.OverrideTheme](https://reference.aspose.com/slides/net/aspose.slides.theme/masterthememanager/overridetheme/) 覆寫簡報主題，版面配置可透過 [BaseOverrideThemeManager.OverrideTheme](https://reference.aspose.com/slides/net/aspose.slides.theme/baseoverridethememanager/overridetheme/) 覆寫其繼承的主題，個別投影片亦可如此。實務上，投影片的有效主題會透過以下繼承鏈決定：簡報主題 → 母片覆寫 → 版面覆寫 → 投影片覆寫。

![主題構成：顏色、字型、背景樣式與效果](theme-constituents.png)

以下章節說明最常見的主題工作流程：檢查主題、變更顏色與字型、複製或套用主題、更新背景與效果樣式，以及在繼承與覆寫解析後讀取有效值。

## **檢查主題**

[MasterTheme](https://reference.aspose.com/slides/net/aspose.slides.theme/mastertheme/) 物件會公開主題的 [ColorScheme](https://reference.aspose.com/slides/net/aspose.slides.theme/mastertheme/colorscheme/)、[FontScheme](https://reference.aspose.com/slides/net/aspose.slides.theme/mastertheme/fontscheme/) 與 [FormatScheme](https://reference.aspose.com/slides/net/aspose.slides.theme/mastertheme/formatscheme/)。在變更之前先檢查這些集合特別有用，因為當簡報來自外部來源時，樣式項目的數量與內容可能會不同。

以下範例讀取主要主題屬性，並報告主題中儲存了多少個背景、填色、線條與效果樣式：

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

如果檔案使用多個母片，請勿假設每張投影片都有相同的有效主題。檢查與投影片關聯的母片，並在可能存在版面或投影片覆寫時，使用本文稍後說明的有效主題工作流程。

## **變更主題顏色**

具備主題感知的填色、線條與文字可以參考 [SchemeColor](https://reference.aspose.com/slides/net/aspose.slides/schemecolor/) 列舉中的邏輯顏色。當您在主題的 [IColorScheme](https://reference.aspose.com/slides/net/aspose.slides.theme/icolorscheme/) 中變更對應條目時，所有仍參照該主題顏色的物件都會以新值解析。直接使用 RGB 顏色的物件不會受到主題顏色更新的影響。

以下端對端範例建立一個使用 `Accent4` 的圖形，將主題的 `Accent4` 顏色改為紅色，儲存簡報，重新開啟，並印出有效的填色顏色：

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

因為矩形仍連結至 `Accent4`，主題變更後其可見顏色會變成紅色。若您在圖形上以直接顏色取代該配色，之後對 `Accent4` 的變更就不會再影響該填色。

### **使用額外調色盤的顏色**

PowerPoint 會透過套用顏色變換，從主題顏色衍生出較亮與較暗的變體。Aspose.Slides 透過 [ColorTransformOperation](https://reference.aspose.com/slides/net/aspose.slides/colortransformoperation/) 暴露這些變換。

![主題主要顏色與由額外調色盤產生的較亮與較暗顏色](additional-palette-colors.png)

**1** - 主題主要顏色。  
**2** - 由主要主題顏色產生的較亮與較暗變體。

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

這些變體仍根植於主題顏色。若稍後 `Accent4` 變更，變換後的顏色會根據新的 `Accent4` 值重新計算。

### **將 `SchemeColor` 值對映到 `IColorScheme` 插槽**

[SchemeColor](https://reference.aspose.com/slides/net/aspose.slides/schemecolor/) 列舉使用 `Text1`、`Background1`、`Text2` 與 `Background2`，而 [IColorScheme](https://reference.aspose.com/slides/net/aspose.slides.theme/icolorscheme/) 則以 `Dark1`、`Light1`、`Dark2`、`Light2` 暴露相同的主題插槽。映射是固定的：

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

這些是同一主題插槽的別名；它們不是會動態相互轉換的值。

## **變更主題字型**

主題字型方案包含標題的主要字型集合與正文的次要字型集合。[FontScheme.Major](https://reference.aspose.com/slides/net/aspose.slides.theme/fontscheme/major/) 與 [FontScheme.Minor](https://reference.aspose.com/slides/net/aspose.slides.theme/fontscheme/minor/) 屬性會公開這些集合。

PowerPoint 相容的主題字型識別碼可用於文字格式設定：

* `+mn-lt` - 正文字型 Latin（次要 Latin 字型）
* `+mj-lt` - 標題字型 Latin（主要 Latin 字型）
* `+mn-ea` - 正文字型 East Asian（次要東亞字型）
* `+mj-ea` - 標題字型 East Asian（主要東亞字型）
* `+mn-cs` - 正文字型 Complex Script（次要複合文字字型）
* `+mj-cs` - 標題字型 Complex Script（主要複合文字字型）

以下範例建立一個使用主要 Latin 主題字型的標題，和一個使用次要 Latin 主題字型的正文，接著變更主題字型並儲存結果：

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

標題遵循主要字型，正文遵循次要字型。若文字使用了明確的字型名稱而非主題識別碼，則在主題字型方案變更時不會自動切換。

主要與次要字型集合亦可包含對個別書寫系統（如西里爾、阿拉伯、日文、喬治亞與 Thaana）的字型對映。若要檢查、加入、取代或移除這些對映，請參閱 [Script‑Specific Theme Fonts](/slides/zh-hant/net/script-specific-font-mappings/)。

{{% alert color="info" title="提示" %}}
欲取得更多有關簡報字型的資訊，請參閱 [PowerPoint Fonts](/slides/zh-hant/net/powerpoint-fonts/)。
{{% /alert %}}

### **解析主題字型參照**

在檢查文字時，[IFontData.FontName](https://reference.aspose.com/slides/net/aspose.slides/ifontdata/fontname/) 可能包含類似 `+mn-lt` 的主題參照，而非字型族名稱。使用適當的 [IThemeEffectiveData](https://reference.aspose.com/slides/net/aspose.slides.theme/ithemeeffectivedata/) 呼叫 [IFontData.GetFontName](https://reference.aspose.com/slides/net/aspose.slides/ifontdata/getfontname/) 以解析該參照。`+mj` 與 `+mn` 前綴選擇主要與次要字型集合；`-lt`、`-ea` 與 `-cs` 後綴分別選擇其 Latin、East Asian 與 Complex Script 字型。

先使用 [IThemeable.CreateThemeEffective](https://reference.aspose.com/slides/net/aspose.slides.theme/ithemeable/createthemeeffective/) 取得套用於欲檢查文字之物件的有效主題。對於投影片上的普通文字，使用 `slide.CreateThemeEffective()`，讓上下文包含該投影片的繼承主題與本地覆寫。檢查版面或母片本身時，使用其自身的有效主題。不要假設第一個母片的主題會套用至所有投影片。

以下範例建立一段明確參照次要 Latin 字型的文字。它透過 [IOverrideTheme.InitFontSchemeFromInherited](https://reference.aspose.com/slides/net/aspose.slides.theme/ioverridetheme/initfontschemefrominherited/) 初始化投影片字型方案，並將主要與次要 Latin 家族設定為 `Arial` 與 `Calibri`，使結果可在沒有輸入檔的情況下重現。

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var theme = slide.ThemeManager.OverrideTheme;
theme.InitFontSchemeFromInherited();
theme.FontScheme.Major.LatinFont = new FontData("Arial");
theme.FontScheme.Minor.LatinFont = new FontData("Calibri");

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 400, 60);
shape.TextFrame.Text = "Text using the minor theme font";

var portion = shape.TextFrame.Paragraphs[0].Portions[0];
portion.PortionFormat.LatinFont = new FontData("+mn-lt");

var font = portion.PortionFormat.LatinFont;
var effectiveTheme = slide.CreateThemeEffective();
Console.WriteLine($"{font.FontName} -> {font.GetFontName(effectiveTheme)}");

var explicitFont = new FontData("Verdana");
Console.WriteLine($"{explicitFont.FontName} -> {explicitFont.GetFontName(effectiveTheme)}");
```

輸出為 `+mn-lt -> Calibri`，接著是 `Verdana -> Verdana`。儲存的參照保持不變，而明確的字型名稱則直接回傳。若使用 `+mj-lt`，則會在此主題中解析為 `Arial`。

解析主題參照會找出字型族是由哪個主題插槽指定的。它不會檢查字型可用性，也不會決定在取代或字形回退期間最終使用的字型檔案。請參閱 [Font Selection Sequence](/slides/zh-hant/net/font-selection-sequence/) 與 [Font Substitution](/slides/zh-hant/net/font-substitution/) 了解這些獨立步驟。

## **複製或套用主題**

以下工作流程解決不同的主題相關問題。

### **將外部主題套用至依賴特定母片的投影片**

當您擁有 PowerPoint 主題檔（`.thmx`）且想重新樣式化所有依賴特定母片的投影片時，使用 [IMasterSlide.ApplyExternalThemeToDependingSlides](https://reference.aspose.com/slides/net/aspose.slides/imasterslide/applyexternalthemetodependingslides/)。從 [Presentation.Masters](https://reference.aspose.com/slides/net/aspose.slides/presentation/masters/) 集合中選取母片（該集合實作 [IMasterSlideCollection](https://reference.aspose.com/slides/net/aspose.slides/imasterslidecollection/)），然後將主題檔路徑傳遞給方法。

此方法執行以下操作：

1. 以選取的母片為基礎建立新母片。  
1. 將外部主題套用至新母片。  
1. 將新母片指派給先前依賴選取母片的所有投影片。  
1. 回傳新建立的 [IMasterSlide](https://reference.aspose.com/slides/net/aspose.slides/imasterslide/)。

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

無效、損壞或不支援的主題可能會拋出 [PptxException](https://reference.aspose.com/slides/net/aspose.slides/pptxexception/) 或其與格式相關的子類別。請驗證使用者提供的路徑、處理檔案系統存取失敗，且僅在主題成功套用後才儲存簡報。

僅會重新指派依賴所選母片的投影片。屬於其他母片的投影片會保留原有的母片與主題。具備主題感知的顏色、字型、填色、線條、背景與效果會根據外部主題解析。直接指定的顏色、字型、填色與其他明確格式可能保持不變。版面層級與投影片層級的覆寫亦可能優先於新母片繼承的值。

主題可能會參照執行環境中不存在的字型。為了確保一致的渲染與匯出，請安裝所需字型、透過 [custom font sources](/slides/zh-hant/net/custom-font/) 提供，或設定 [font substitution](/slides/zh-hant/net/font-substitution/)。

這是一個直接的母片層級工作流程：方法接受 `.thmx` 檔案路徑，且不需要手動建立投影片層級或版面層級的主題覆寫。

### **在多母片簡報中套用不同的外部主題**

當事先不知道相關母片時，請透過 [ISlide.LayoutSlide](https://reference.aspose.com/slides/net/aspose.slides/islide/layoutslide/) 與 [ILayoutSlide.MasterSlide](https://reference.aspose.com/slides/net/aspose.slides/ilayoutslide/masterslide/) 從代表性投影片取得母片。於套用任何主題前先儲存原始母片參照，因為每次呼叫都會在簡報中建立另一個母片。

以下範例使用兩個章節的投影片定位其母片，並對每個群組套用不同的外部主題：

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

若要將投影片移至另一個簡報且保留其原始設計，請使用 [IMasterSlideCollection.AddClone](https://reference.aspose.com/slides/net/aspose.slides/imasterslidecollection/addclone/) 將來源母片克隆至目標簡報，然後使用 [ISlideCollection.AddClone](https://reference.aspose.com/slides/net/aspose.slides/islidecollection/addclone/) 與已克隆的母片一起克隆投影片。如此即可將母片、其版面配置與相關主題一起搬移。

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

這是在來源投影片必須在目的地保持相同外觀時的首選工作流程。僅將內容克隆至不相關的目標母片可能會改變主題驅動的顏色、字型、背景與效果。

### **將主題值套用至已存在的投影片**

若目標投影片必須維持現有的母片與版面配置，請從來源主題為投影片層級覆寫初始化。使用 [OverrideTheme.InitColorSchemeFrom](https://reference.aspose.com/slides/net/aspose.slides.theme/overridetheme/initcolorschemefrom/)、[OverrideTheme.InitFontSchemeFrom](https://reference.aspose.com/slides/net/aspose.slides.theme/overridetheme/initfontschemefrom/) 與 [OverrideTheme.InitFormatSchemeFrom](https://reference.aspose.com/slides/net/aspose.slides.theme/overridetheme/initformatschemefrom/) 方法將三大主題組件複製至覆寫。

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

此操作會在不更改其他投影片繼承主題的情況下變更該投影片使用的主題。若要移除本地覆寫並回復至繼承值，請呼叫 [OverrideTheme.Clear](https://reference.aspose.com/slides/net/aspose.slides.theme/overridetheme/clear/)。

### **將主題覆寫套用至版面**

版面層級的覆寫會套用至使用該版面的投影片，除非特定投影片有自己的覆寫。相同的初始化方法可透過版面的 [LayoutSlideThemeManager](https://reference.aspose.com/slides/net/aspose.slides.theme/layoutslidethememanager/) 使用：

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

當多個版面與投影片應共享相同基礎設計時，使用母片或簡報層級的主題；當單一版面族需要不同樣式時，使用版面覆寫；僅在真正例外時使用投影片覆寫。過度的投影片層級覆寫會讓之後的全域主題變更變得難以預測。

## **更新主題背景樣式**

主題的背景填色儲存在 [FormatScheme.BackgroundFillStyles](https://reference.aspose.com/slides/net/aspose.slides.theme/formatscheme/backgroundfillstyles/) 中。PowerPoint 在 UI 中可以呈現比此集合實際儲存的填色定義更多的背景選項，因為 UI 能將主題填色與主題顏色及其他樣式參照結合。

![PowerPoint 簡報主題的背景樣式圖庫](presentation-design_8.png)

在使用背景樣式前，先檢查儲存的集合與目前的 [Background.StyleIndex](https://reference.aspose.com/slides/net/aspose.slides/background/styleindex/)。`StyleIndex` 使用 `0` 代表無主題填色；正值則是主題背景樣式的參照。這與直接索引 .NET 集合不同，`.NET` 中的 `[0]` 代表第一筆儲存的項目。請勿假設每個簡報都有相同數量的背景填色樣式。

以下範例報告可用的背景填色數量，將有主題的背景參照指派給第一個母片，並儲存簡報：

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

最終顯示結果取決於母片參照的主題條目以及版面或投影片層級的任何背景覆寫。如果投影片使用了自己的背景，只變更母片背景可能不會影響該投影片。當需要知道繼承後的最終背景時，請使用 [Background.GetEffective](https://reference.aspose.com/slides/net/aspose.slides/background/geteffective/)。

{{% alert color="warning" title="警告" %}}
請勿將 `StyleIndex` 當作零基索引來使用。也避免硬編碼某檔案的樣式編號，並假設在另一檔案中會有相同外觀；主題樣式定義是依簡報而異的。
{{% /alert %}}

{{% alert color="info" title="提示" %}}
關於直接背景格式設定與背景繼承，請參閱 [Presentation Background](/slides/zh-hant/net/presentation-background/)。
{{% /alert %}}

## **更新主題效果**

主題格式方案包含獨立的 [FillStyles](https://reference.aspose.com/slides/net/aspose.slides.theme/formatscheme/fillstyles/)、[LineStyles](https://reference.aspose.com/slides/net/aspose.slides.theme/formatscheme/linestyles/) 與 [EffectStyles](https://reference.aspose.com/slides/net/aspose.slides.theme/formatscheme/effectstyles/) 集合。典型的 Office 主題常包含三個主要樣式條目，視覺上分別對應微弱、適中與強烈的格式，但程式碼應檢查每個集合，而非假設固定數量。

![在相同圖形上套用的微弱、適中與強烈主題效果](presentation-design_10.png)

在 C# 中存取這些集合時，集合索引是零基的：`[0]` 為第一筆儲存的樣式，`[2]` 為第三筆。圖形的樣式參照索引是另一概念，透過 [IShapeStyle](https://reference.aspose.com/slides/net/aspose.slides/ishapestyle/) 暴露。修改主題樣式會影響引用該主題樣式的圖形；直接格式化的圖形則可能保持不變。

以下範例檢查必要的樣式條目是否存在，變更第一個線條樣式、變更第三個填色樣式，並在第三個效果樣式中啟用外部陰影，最後儲存結果：

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

對於引用這些插槽的圖形，第一個主題線條樣式變為紅色，第三個主題填色樣式變為實心森林綠，第三個效果樣式則獲得距離 10 點的外部陰影。最終的視覺結果仍取決於每個圖形參照的樣式插槽以及是否有直接格式化覆寫主題。

![變更線條、填色與陰影設定後的主題效果樣式](presentation-design_11.png)

## **為圖形選取主題填色與線條樣式**

圖形可以透過 [FillStyleIndex](https://reference.aspose.com/slides/net/aspose.slides/ishapestyle/fillstyleindex/) 與 [LineStyleIndex](https://reference.aspose.com/slides/net/aspose.slides/ishapestyle/linestyleindex/) 分別選取其填色與輪廓。對於兩個屬性，索引 `1` 代表在相對應的主題集合中第一筆條目（`FillStyles[0]` 或 `LineStyles[0]`），索引 `2` 則代表第二筆。

以下範例在新簡報的預設主題中設定兩個填色樣式（金色與天空藍）與兩個線條樣式（深藍 6 pt 與深紅 12 pt）。它會在三個階段儲存投影片，讓您在 PowerPoint 中比較結果。

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var styles = presentation.MasterTheme.FormatScheme;

var goldFill = styles.FillStyles[0];
goldFill.FillType = FillType.Solid;
goldFill.SolidFillColor.Color = Color.Gold;
var blueFill = styles.FillStyles[1];
blueFill.FillType = FillType.Solid;
blueFill.SolidFillColor.Color = Color.SkyBlue;

var thinLine = styles.LineStyles[0];
thinLine.FillFormat.FillType = FillType.Solid;
thinLine.FillFormat.SolidFillColor.Color = Color.DarkBlue;
thinLine.Width = 6;
var thickLine = styles.LineStyles[1];
thickLine.FillFormat.FillType = FillType.Solid;
thickLine.FillFormat.SolidFillColor.Color = Color.DarkRed;
thickLine.Width = 12;

var shapes = presentation.Slides[0].Shapes;
var left = shapes.AddAutoShape(ShapeType.Rectangle, 100, 205, 200, 130);
var right = shapes.AddAutoShape(ShapeType.Rectangle, 420, 205, 200, 130);
left.ShapeStyle.FillStyleIndex = 1;
right.ShapeStyle.FillStyleIndex = 2;
left.ShapeStyle.LineStyleIndex = 1;
right.ShapeStyle.LineStyleIndex = 1;
presentation.Save("01-initial.pptx", SaveFormat.Pptx);

right.ShapeStyle.LineStyleIndex = 2;
presentation.Save("02-line-changed.pptx", SaveFormat.Pptx);

goldFill.SolidFillColor.Color = Color.SeaGreen;
presentation.Save("03-theme-changed.pptx", SaveFormat.Pptx);
```

| 初始樣式 | 變更右側輪廓 | 編輯第一個主題填色 |
|:---:|:---:|:---:|
| ![金色與天空藍矩形，搭配相同的細深藍輪廓](theme-style-initial.png) | ![天空藍矩形現在有粗深紅輪廓](theme-style-line-changed.png) | ![左側矩形變為綠色，兩個輪廓均未變更](theme-style-fill-changed.png) |

選取不同的線條樣式只會改變右側矩形的輪廓。編輯第一個主題填色會更新所有使用該填色的圖形，此例中僅左側矩形變為綠色。

在既有圖形上，局部的填色、線條顏色或線寬可以覆寫該主題樣式的相應部分。若變更樣式索引後沒有可見效果，請檢查圖形的 [direct formatting](/slides/zh-hant/net/shape-formatting/)。

## **判斷有效實心填色是否使用主題顏色**

填色可以直接儲存在物件上，或從段落、版面、母片、主題樣式或其他格式層級繼承。呼叫 [IFillFormat.GetEffective](https://reference.aspose.com/slides/net/aspose.slides/ifillformat/geteffective/) 可將此層級階層解析為不可變的 [IFillFormatEffectiveData](https://reference.aspose.com/slides/net/aspose.slides/ifillformateffectivedata/)。首先檢查 [IFillFormatEffectiveData.FillType](https://reference.aspose.com/slides/net/aspose.slides/ifillformateffectivedata/filltype/)。只有當它為 `FillType.Solid` 時，才應讀取實心填色屬性。

對於實心填色，[IFillFormatEffectiveData.SolidFillColor](https://reference.aspose.com/slides/net/aspose.slides/ifillformateffectivedata/solidfillcolor/) 會在繼承、主題查找與顏色變換之後，回傳最終呈現的 RGB 值。[IFillFormatEffectiveData.SolidFillSchemeColor](https://reference.aspose.com/slides/net/aspose.slides/ifillformateffectivedata/solidfillschemecolor/) 則回傳對應的邏輯 [SchemeColor](https://reference.aspose.com/slides/net/aspose.slides/schemecolor/) 插槽，例如 `Text1` 或 `Accent6`。`SchemeColor.NotDefined` 表示有效實心填色並非基於配色方案。若工作流程僅在主題顏色或直接 RGB 之間切換，該值即可辨識為直接 RGB 填色。

不要僅使用本地的 [IColorFormat.SchemeColor](https://reference.aspose.com/slides/net/aspose.slides/icolorformat/schemecolor/) 來分類填色。例如，文字段落可能沒有本地定義的配色方案顏色，其本地值為 `NotDefined`，但其有效填色可能繼承自主題顏色，解析為 `Text1` 或 `Accent6`。相反地，`SolidFillSchemeColor` 告訴您是哪個邏輯主題插槽產生了有效顏色，但不會說明該插槽是來自物件、段落、版面、母片或其他層級。

以下範例載入簡報，稽核圖形填色與文字段落填色，印出每個最終的 RGB 值與對應的配色方案，並標記不會追蹤主題顏色變更的實心填色：

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

`NotDefined` 分支會提供一份實心填色清單，這些填色在主題配色方案變更時不會回應。檢查這些物件，當簡報必須遵循新的品牌調色盤時尤其重要。報告的 RGB 值仍顯示當前外觀，而配色方案值則說明該外觀是否與主題相連。

有效格式物件是快照。變更簡報主題、主題覆寫或任何繼承格式後，請再次呼叫 `GetEffective`，取得新的 `IFillFormatEffectiveData` 物件，再進行比較或報告顏色。

## **讀取有效主題值**

原始主題物件告訴您在特定層級定義了什麼。有效值則告訴您投影片或圖形在繼承與本地覆寫解析後實際使用了什麼。對於投影片，呼叫 [BaseOverrideThemeManager.CreateThemeEffective](https://reference.aspose.com/slides/net/aspose.slides.theme/baseoverridethememanager/createthemeeffective/)。對於背景，使用 [Background.GetEffective](https://reference.aspose.com/slides/net/aspose.slides/background/geteffective/)，對於填色，使用 [FillFormat.GetEffective](https://reference.aspose.com/slides/net/aspose.slides/fillformat/geteffective/)。

以下範例從投影片讀取有效主題、背景與第一個圖形的填色：

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

使用有效資料進行渲染診斷、驗證與比較。如果僅檢查 [Presentation.MasterTheme](https://reference.aspose.com/slides/net/aspose.slides/presentation/mastertheme/)，可能會錯過母片、版面、投影片或圖形的覆寫，這些覆寫會改變最終外觀。

## **常見問答**

**套用外部主題會影響簡報中的每張投影片嗎？**

不會。[IMasterSlide.ApplyExternalThemeToDependingSlides](https://reference.aspose.com/slides/net/aspose.slides/imasterslide/applyexternalthemetodependingslides/) 只會重新指派依賴所選母片的投影片。使用其他母片的投影片會保留其現有主題。

**我可以在不變更母片的情況下，只對單一投影片套用主題嗎？**

可以。使用投影片的 [SlideThemeManager](https://reference.aspose.com/slides/net/aspose.slides.theme/slidethememanager/) 並初始化其覆寫主題。變更將僅限於該投影片，其餘投影片仍會繼承既有主題。

**將主題從一個簡報搬移到另一個簡報的最安全方式是什麼？**

在搬移投影片且保留來源外觀時，先使用 [IMasterSlideCollection.AddClone](https://reference.aspose.com/slides/net/aspose.slides/imasterslidecollection/addclone/) 將來源母片克隆至目標簡報，然後用 [ISlideCollection.AddClone](https://reference.aspose.com/slides/net/aspose.slides/islidecollection/addclone/) 連同該母片一起克隆投影片。這樣可以同時保留母片、版面與主題。

**我如何看到繼承與覆寫之後的有效值？**

對於投影片或版面主題，使用 [BaseOverrideThemeManager.CreateThemeEffective](https://reference.aspose.com/slides/net/aspose.slides.theme/baseoverridethememanager/createthemeeffective/)。對於格式物件，如背景與填色，分別使用 [Background.GetEffective](https://reference.aspose.com/slides/net/aspose.slides/background/geteffective/) 與 [FillFormat.GetEffective](https://reference.aspose.com/slides/net/aspose.slides/fillformat/geteffective/)。這些 API 會在繼承與覆寫套用後回傳解析後的值。