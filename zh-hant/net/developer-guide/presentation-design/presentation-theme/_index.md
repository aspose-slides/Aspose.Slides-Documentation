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
description: "在 Aspose.Slides for .NET 中管理簡報主題，以建立、客製化及轉換具一致品牌形象的 PowerPoint 檔案。"
---
## **簡介**

簡報主題定義了設計元素的屬性。當您選擇簡報主題時，實際上是在選擇一組特定的視覺元素及其屬性。

在 PowerPoint 中，主題由色彩、[字型](/slides/zh-hant/net/powerpoint-fonts/)、[背景樣式](/slides/zh-hant/net/presentation-background/)和效果組成。

![theme-constituents](theme-constituents.png)

## **變更主題顏色**

PowerPoint 主題使用一組特定的色彩來呈現投影片上的不同元素。如果您不喜歡這些色彩，可以透過套用新色彩來變更主題顏色。為了讓您選取新主題顏色，Aspose.Slides 在 [SchemeColor](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/schemecolor/) 列舉中提供了多種值。

以下 C# 程式碼示範如何變更主題的強調色：

```c#
using Aspose.Slides;

using (Presentation pres = new Presentation())
    
{
    IAutoShape shape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 100, 100);

    shape.FillFormat.FillType = FillType.Solid;

    shape.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;
}
```

您可以透過以下方式取得最終色彩的有效值：

```c#
using Aspose.Slides;

using (Presentation pres = new Presentation())
{
    IAutoShape shape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 100, 100);

    shape.FillFormat.FillType = FillType.Solid;

    shape.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;

    var fillEffective = shape.FillFormat.GetEffective();

    Console.WriteLine($"{fillEffective.SolidFillColor.Name} ({fillEffective.SolidFillColor})"); // ff8064a2 (顏色 [A=255, R=128, G=100, B=162])
}
```

為了更進一步說明顏色變更的操作，我們建立另一個元素，並將先前操作中的強調色指派給它，之後再變更主題中的顏色：

```c#
using System.Drawing;
using Aspose.Slides;

using (Presentation pres = new Presentation())
{
    IAutoShape otherShape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 10, 120, 100, 100);

    otherShape.FillFormat.FillType = FillType.Solid;

    otherShape.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;

    pres.MasterTheme.ColorScheme.Accent4.Color = Color.Red;
}
```

新顏色會自動套用到兩個元素上。

### **從附加調色盤設定主題顏色**

當您對主題主色 (1) 套用亮度變換時，會產生來自附加調色盤 (2) 的色彩。您可以設定與取得這些主題顏色。

![additional-palette-colors](additional-palette-colors.png)

**1** - 主題主要顏色  

**2** - 附加調色盤的顏色

以下 C# 程式碼示範如何從主題主色取得附加調色盤顏色，並在圖形中使用：

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // Accent 4
    IShape shape1 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 50, 50);

    shape1.FillFormat.FillType = FillType.Solid;
    shape1.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;

    // Accent 4, 較淡 80%
    IShape shape2 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 70, 50, 50);

    shape2.FillFormat.FillType = FillType.Solid;
    shape2.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;
    shape2.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.MultiplyLuminance, 0.2f);
    shape2.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.AddLuminance, 0.8f);

    // Accent 4, 較淡 60%
    IShape shape3 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 130, 50, 50);

    shape3.FillFormat.FillType = FillType.Solid;
    shape3.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;
    shape3.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.MultiplyLuminance, 0.4f);
    shape3.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.AddLuminance, 0.6f);

    // Accent 4, 較淡 40%
    IShape shape4 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 190, 50, 50);

    shape4.FillFormat.FillType = FillType.Solid;
    shape4.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;
    shape4.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.MultiplyLuminance, 0.6f);
    shape4.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.AddLuminance, 0.4f);

    // Accent 4, 較暗 25%
    IShape shape5 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 250, 50, 50);

    shape5.FillFormat.FillType = FillType.Solid;
    shape5.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;
    shape5.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.MultiplyLuminance, 0.75f);

    // Accent 4, 較暗 50%
    IShape shape6 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 310, 50, 50);

    shape6.FillFormat.FillType = FillType.Solid;
    shape6.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;
    shape6.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.MultiplyLuminance, 0.5f);

    presentation.Save("example.pptx", SaveFormat.Pptx);
}
```

### **將 `SchemeColor` 映射到 `IColorScheme` 顏色**

當您使用 [SchemeColor](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/schemecolor/) 時，會發現它包含以下主題顏色值：

`Background1`、`Background2`、`Text1` 與 `Text2`。

然而，`Presentation.MasterTheme.ColorScheme` 會回傳 [IColorScheme](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.theme/icolorscheme/)，其對應的顏色名稱為：

`Dark1`、`Dark2`、`Light1` 與 `Light2`。

這只是一個命名差異。這些值對應相同的主題顏色槽，且映射關係固定：

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

`Text`/`Background` 與 `Dark`/`Light` 之間沒有動態轉換，它們僅是同一主題顏色的交替名稱。

此命名差異來源於 Microsoft Office 的術語。較舊的 Office 版本使用 `Dark 1`、`Light 1`、`Dark 2`、`Light 2`，而較新的 UI 版本則以 `Text 1`、`Background 1`、`Text 2`、`Background 2` 顯示相同的槽位。

## **變更主題字型**

為了讓您能為主題及其他用途選取字型，Aspose.Slides 使用了這些特殊識別碼（與 PowerPoint 使用方式類似）：

* **+mn-lt** - 正文字型 拉丁語 (Minor Latin Font)
* **+mj-lt** - 標題字型 拉丁語 (Major Latin Font)
* **+mn-ea** - 正文字型 東亞 (Minor East Asian Font)
* **+mj-ea** - 標題字型 東亞 (Major East Asian Font)

以下 C# 程式碼示範如何將拉丁語字型指派給主題元素：

```c#
using Aspose.Slides;

using (Presentation pres = new Presentation())
{
    IAutoShape shape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 100, 100);

    Paragraph paragraph = new Paragraph();

    Portion portion = new Portion("Theme text format");

    paragraph.Portions.Add(portion);

    shape.TextFrame.Paragraphs.Add(paragraph);

    portion.PortionFormat.LatinFont = new FontData("+mn-lt");
}
```

以下 C# 程式碼示範如何變更簡報主題的字型：

```c#
using Aspose.Slides;

using (Presentation pres = new Presentation())
{
    pres.MasterTheme.FontScheme.Minor.LatinFont = new FontData("Arial");
}
```

所有文字方塊的字型都將被更新。

{{% alert color="info" title="TIP" %}} 
您可能想參考 [PowerPoint 字型](/slides/zh-hant/net/powerpoint-fonts/)。
{{% /alert %}}

## **變更主題背景樣式**

預設情況下，PowerPoint 應用程式提供 12 種預定義背景，但在一般簡報中只會儲存其中的 3 種。

![todo:image_alt_text](presentation-design_8.png)

例如，當您在 PowerPoint 應用程式中儲存簡報後，可以執行以下 C# 程式碼，找出簡報中包含的預定義背景數量：

```c#
using Aspose.Slides;

using (Presentation pres = new Presentation("pres.pptx"))

{
    int numberOfBackgroundFills = pres.MasterTheme.FormatScheme.BackgroundFillStyles.Count;

    Console.WriteLine($"Number of background fill styles for theme is {numberOfBackgroundFills}");
}
```

{{% alert color="warning" %}} 
使用來自 [FormatScheme](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.theme/formatscheme/) 類別的 [BackgroundFillStyles](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.theme/formatscheme/backgroundfillstyles/) 屬性，您可以在 PowerPoint 主題中加入或存取背景樣式。 
{{% /alert %}}

以下 C# 程式碼示範如何為簡報設定背景：

```c#
using Aspose.Slides;

using (Presentation pres = new Presentation("pres.pptx"))
{
    pres.Masters[0].Background.StyleIndex = 2;
}
```

**索引說明**：0 表示無填滿。索引值從 1 開始。

{{% alert color="info" title="TIP" %}} 
您可能想參考 [PowerPoint 背景](/slides/zh-hant/net/presentation-background/)。
{{% /alert %}}

## **變更主題效果**

PowerPoint 主題通常為每個樣式陣列包含 3 個值，這些陣列會組合成 3 種效果：細緻、適度與強烈。例如，以下是將效果套用到特定圖形時的結果：

![todo:image_alt_text](presentation-design_10.png)

透過 [FormatScheme](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.theme/formatscheme) 類別的 3 個屬性（[FillStyles](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.theme/formatscheme/fillstyles)、[LineStyles](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.theme/formatscheme/linestyles) 與 [EffectStyles](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.theme/formatscheme/effectstyles)），您可以比 PowerPoint 提供的選項更靈活地變更主題中的元素。

以下 C# 程式碼示範如何透過調整元素部份來變更主題效果：

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation("Subtle_Moderate_Intense.pptx"))
{
    pres.MasterTheme.FormatScheme.LineStyles[0].FillFormat.SolidFillColor.Color = Color.Red;

    pres.MasterTheme.FormatScheme.FillStyles[2].FillType = FillType.Solid;

    pres.MasterTheme.FormatScheme.FillStyles[2].SolidFillColor.Color = Color.ForestGreen;

    pres.MasterTheme.FormatScheme.EffectStyles[2].EffectFormat.OuterShadowEffect.Distance = 10f;

    pres.Save("Design_04_Subtle_Moderate_Intense-out.pptx", SaveFormat.Pptx);
}
```

變更後的填色、填充類型、陰影效果等：

![todo:image_alt_text](presentation-design_11.png)

## **常見問題**

### 我可以在不變更母片的情況下，將主題套用於單一投影片嗎？

可以。Aspose.Slides 支援投影片層級的主題覆寫，您可以只對該投影片套用本地主題，同時保留母片主題不變（透過 [SlideThemeManager](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.theme/slidethememanager/)）。

### 從一個簡報搬移主題到另一個簡報，最安全的做法是什麼？

使用 [Clone slides](/slides/zh-hant/net/clone-slides/) 連同其母片一起複製到目標簡報。這會保留原始的母片、版面配置以及相關的主題，使外觀保持一致。

### 如何在所有繼承與覆寫之後，看到「有效」的值？

使用 API 的「[effective]」檢視（/slides/zh-hant/net/shape-effective-properties/）取得主題/顏色/字型/效果的最終解析屬性。這些檢視會回傳套用母片與任何本地覆寫後的最終結果。