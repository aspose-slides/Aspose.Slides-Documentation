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
- 主題字體
- 主題樣式
- 主題效果
- PowerPoint
- OpenDocument
- 簡報
- .NET
- C#
- Aspose.Slides
description: "在 Aspose.Slides for .NET 中掌控簡報主題，以建立、客製化並轉換具一致品牌形象的 PowerPoint 檔案。"
---
## **簡介**

簡報主題定義了設計元素的屬性。當您選擇簡報主題時，實際上是選擇一組特定的視覺元素及其屬性。

在 PowerPoint 中，主題包含顏色、[字體](/slides/zh-hant/net/powerpoint-fonts/)、[背景樣式](/slides/zh-hant/net/presentation-background/)、以及效果。

![主題構成](theme-constituents.png)

## **更改主題顏色**

PowerPoint 主題在投影片的不同元素上使用特定的一組顏色。如果您不喜歡這些顏色，可以透過套用新顏色來變更主題顏色。為了讓您選擇新的主題顏色，Aspose.Slides 在 [SchemeColor](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/schemecolor/) 列舉中提供了相關值。

以下 C# 程式碼示範如何變更主題的強調色：
```c#
using (Presentation pres = new Presentation())
    
{
    IAutoShape shape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 100, 100);

    shape.FillFormat.FillType = FillType.Solid;

    shape.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;
}
```

您可以透過以下方式取得結果顏色的有效值：
```c#
var fillEffective = shape.FillFormat.GetEffective();

Console.WriteLine($"{fillEffective.SolidFillColor.Name} ({fillEffective.SolidFillColor})"); // ff8064a2 (顏色 [A=255, R=128, G=100, B=162])
```

為了進一步示範顏色變更操作，我們會建立另一個元素並將先前取得的強調色指派給它。接著再變更主題中的顏色：
```c#
IAutoShape otherShape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 10, 120, 100, 100);

otherShape.FillFormat.FillType = FillType.Solid;

otherShape.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;

pres.MasterTheme.ColorScheme.Accent4.Color = Color.Red;
```

新顏色會自動套用至兩個元素上。

### **從附加調色盤設定主題顏色**

當您對主要主題顏色 (1) 套用亮度變換時，會產生來自附加調色盤 (2) 的顏色。之後您可以設定與取得這些主題顏色。

![附加調色盤顏色](additional-palette-colors.png)

**1** - 主要主題顏色  
**2** - 附加調色盤的顏色。

以下 C# 程式碼示範如何從主要主題顏色取得附加調色盤顏色，並在圖形中使用它們：
```c#
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // 強調色 4
    IShape shape1 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 50, 50);

    shape1.FillFormat.FillType = FillType.Solid;
    shape1.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;

    // 強調色 4，較亮 80%
    IShape shape2 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 70, 50, 50);

    shape2.FillFormat.FillType = FillType.Solid;
    shape2.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;
    shape2.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.MultiplyLuminance, 0.2f);
    shape2.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.AddLuminance, 0.8f);

    // 強調色 4，較亮 60%
    IShape shape3 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 130, 50, 50);

    shape3.FillFormat.FillType = FillType.Solid;
    shape3.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;
    shape3.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.MultiplyLuminance, 0.4f);
    shape3.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.AddLuminance, 0.6f);

    // 強調色 4，較亮 40%
    IShape shape4 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 190, 50, 50);

    shape4.FillFormat.FillType = FillType.Solid;
    shape4.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;
    shape4.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.MultiplyLuminance, 0.6f);
    shape4.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.AddLuminance, 0.4f);

    // 強調色 4，較暗 25%
    IShape shape5 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 250, 50, 50);

    shape5.FillFormat.FillType = FillType.Solid;
    shape5.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;
    shape5.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.MultiplyLuminance, 0.75f);

    // 強調色 4，較暗 50%
    IShape shape6 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 310, 50, 50);

    shape6.FillFormat.FillType = FillType.Solid;
    shape6.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;
    shape6.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.MultiplyLuminance, 0.5f);

    presentation.Save("example.pptx", SaveFormat.Pptx);
}
```

### **將 `SchemeColor` 映射至 `IColorScheme` 顏色**

當您使用 [SchemeColor](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/schemecolor/) 時，可能會注意到它包含以下主題顏色值：`Background1`、`Background2`、`Text1` 與 `Text2`。

然而，`Presentation.MasterTheme.ColorScheme` 會回傳 [IColorScheme](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.theme/icolorscheme/)，它以 `Dark1`、`Dark2`、`Light1`、`Light2` 來表示對應的顏色。

這僅是命名上的差異。這些值指向相同的主題顏色槽位，且其對應關係是固定的：

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

在 `Text`/`Background` 與 `Dark`/`Light` 之間沒有動態轉換。它們僅是相同主題顏色的別名。

此命名差異來自 Microsoft Office 的術語。較舊的 Office 版本使用 `Dark 1`、`Light 1`、`Dark 2`、`Light 2`，而較新的 UI 版本則將相同槽位顯示為 `Text 1`、`Background 1`、`Text 2`、`Background 2`。

## **更改主題字體**

為了讓您為主題及其他用途選擇字體，Aspose.Slides 使用以下特殊識別碼（類似於 PowerPoint 中的使用方式）：

* **+mn-lt** - 正文字體 Latin（次要 Latin 字體）
* **+mj-lt** - 標題字體 Latin（主要 Latin 字體）
* **+mn-ea** - 正文字體 東亞（次要東亞字體）
* **+mj-ea** - 標題字體 東亞（主要東亞字體）

以下 C# 程式碼示範如何將 Latin 字體指派給主題元素：
```c#
IAutoShape shape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 100, 100);

Paragraph paragraph = new Paragraph();

Portion portion = new Portion("Theme text format");

paragraph.Portions.Add(portion);

shape.TextFrame.Paragraphs.Add(paragraph);

portion.PortionFormat.LatinFont = new FontData("+mn-lt");
```

以下 C# 程式碼示範如何變更簡報主題字體：
```c#
pres.MasterTheme.FontScheme.Minor.LatinFont = new FontData("Arial");
```

所有文字方塊中的字體都會被更新。

{{% alert color="primary" title="TIP" %}} 
您可能想參考 [PowerPoint 字體](/slides/zh-hant/net/powerpoint-fonts/)。
{{% /alert %}}

## **更改主題背景樣式**

預設情況下，PowerPoint 應用程式提供 12 種預設背景，但在一般簡報中只會儲存其中的 3 種背景。

![範例圖片](presentation-design_8.png)

例如，當您在 PowerPoint 應用程式中儲存簡報後，可以執行以下 C# 程式碼，以取得簡報中預設背景的數量：
```c#
using (Presentation pres = new Presentation("pres.pptx"))

{
    int numberOfBackgroundFills = pres.MasterTheme.FormatScheme.BackgroundFillStyles.Count;

    Console.WriteLine($"Number of background fill styles for theme is {numberOfBackgroundFills}");
}
```

{{% alert color="warning" %}} 
使用來自 [FormatScheme](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.theme/formatscheme/) 類別的 [BackgroundFillStyles](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.theme/formatscheme/backgroundfillstyles/) 屬性，您可以在 PowerPoint 主題中新增或存取背景樣式。 
{{% /alert %}}

以下 C# 程式碼示範如何為簡報設定背景：
```c#
pres.Masters[0].Background.StyleIndex = 2;
```

**索引說明**：0 代表無填色。索引值從 1 開始。

{{% alert color="primary" title="TIP" %}} 
您可能想參考 [PowerPoint 背景](/slides/zh-hant/net/presentation-background/)。
{{% /alert %}}

## **更改主題效果**

PowerPoint 主題通常對每個樣式陣列包含 3 個值。這些陣列會結合成 3 種效果：細緻、適中與強烈。例如，將這些效果套用到特定圖形時的結果如下：

![範例圖片](presentation-design_10.png)

使用 [FormatScheme](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.theme/formatscheme) 類別中的 3 個屬性（[FillStyles](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.theme/formatscheme/fillstyles)、[LineStyles](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.theme/formatscheme/linestyles)、[EffectStyles](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.theme/formatscheme/effectstyles)），您可以變更主題中的元素（比 PowerPoint 提供的選項更具彈性）。

以下 C# 程式碼示範如何透過變更元素的部分屬性來改變主題效果：
```c#
using (Presentation pres = new Presentation("Subtle_Moderate_Intense.pptx"))
{
    pres.MasterTheme.FormatScheme.LineStyles[0].FillFormat.SolidFillColor.Color = Color.Red;

    pres.MasterTheme.FormatScheme.FillStyles[2].FillType = FillType.Solid;

    pres.MasterTheme.FormatScheme.FillStyles[2].SolidFillColor.Color = Color.ForestGreen;

    pres.MasterTheme.FormatScheme.EffectStyles[2].EffectFormat.OuterShadowEffect.Distance = 10f;

    pres.Save("Design_04_Subtle_Moderate_Intense-out.pptx", SaveFormat.Pptx);
}
```

結果會顯示填色、填充類型、陰影效果等的變更：

![範例圖片](presentation-design_11.png)

## **常見問題**

**我可以在不更改母片的情況下，僅對單一投影片套用主題嗎？**
可以。Aspose.Slides 支援投影片層級的主題覆寫，您可以僅對該投影片套用本機主題，同時保持母片主題不變（透過 [SlideThemeManager](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.theme/slidethememanager/)）。

**將主題從一個簡報安全地移植至另一個簡報的最佳方式是什麼？**
[Clone slides](/slides/zh-hant/net/clone-slides/) 連同其母片一起複製到目標簡報中。這樣可保留原始的母片、版面配置以及相關的主題，確保外觀保持一致。

**如何在全部繼承與覆寫之後，看到「有效」的值？**
使用 API 的 [「effective」視圖](/slides/zh-hant/net/shape-effective-properties/) 來檢視主題、顏色、字體、效果的最終值。這些視圖會在套用母片與任何本機覆寫後，回傳解析後的最終屬性。