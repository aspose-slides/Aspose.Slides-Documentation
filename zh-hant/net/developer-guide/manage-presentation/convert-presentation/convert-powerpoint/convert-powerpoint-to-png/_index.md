---
title: 在 .NET 中將 PowerPoint 投影片轉換為 PNG
linktitle: PowerPoint 轉 PNG
type: docs
weight: 30
url: /zh-hant/net/convert-powerpoint-to-png/
keywords:
- 轉換 PowerPoint
- 轉換簡報
- 轉換投影片
- 轉換 PPT
- 轉換 PPTX
- PowerPoint 轉 PNG
- 簡報轉 PNG
- 投影片轉 PNG
- PPT 轉 PNG
- PPTX 轉 PNG
- 將 PPT 儲存為 PNG
- 将 PPTX 儲存為 PNG
- 匯出 PPT 為 PNG
- 匯出 PPTX 為 PNG
- .NET
- C#
- Aspose.Slides
description: "使用 Aspose.Slides for .NET 快速將 PowerPoint 簡報轉換為高品質 PNG 影像，確保精確且自動化的結果。"
---
## **概觀**

本文說明如何使用 Aspose.Slides for .NET 將簡報投影片轉換為 PNG 圖像。您可以載入 PPT、PPTX、ODP 等格式的簡報，將每張投影片渲染並儲存為單獨的 PNG 圖像。

以下範例示範了渲染縮圖、設定比例因子、指定像素單位的輸出尺寸，以及選擇漸層渲染樣式。

## **將 PowerPoint 轉換為 PNG**

使用 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) 類別載入簡報，並透過 [Slides](https://reference.aspose.com/slides/net/aspose.slides/presentation/slides/) 集合存取其投影片。範例使用不帶參數的 [ISlide.GetImage](https://reference.aspose.com/slides/net/aspose.slides/islide/getimage/) 來渲染每張投影片，以建立縮圖。然後使用 [IImage.Save](https://reference.aspose.com/slides/net/aspose.slides/iimage/save/) 搭配 [ImageFormat.Png](https://reference.aspose.com/slides/net/aspose.slides/imageformat/) 將每個渲染後的投影片儲存為 PNG 圖像。

```cs
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");

var slideCount = presentation.Slides.Count;
for (var index = 0; index < slideCount; index++)
{
    var slide = presentation.Slides[index];
    using var image = slide.GetImage();
    image.Save($"slide_{index}.png", ImageFormat.Png);
}
```

{{% alert color="info" title="Note" %}}
不帶參數的 [ISlide.GetImage](https://reference.aspose.com/slides/net/aspose.slides/islide/getimage/) 重載會以 0.2 的比例渲染。例如，尺寸為 720 × 540 點的投影片會產生 144 × 108 像素的縮圖。若要控制輸出尺寸，請使用帶比例因子的重載或下方所示的明確圖像大小。
{{% /alert %}}

## **將 PowerPoint 轉換為 PNG（自訂尺寸）**

將水平和垂直比例因子傳遞給 [ISlide.GetImage](https://reference.aspose.com/slides/net/aspose.slides/islide/getimage/) 以控制渲染尺寸。在此範例中，兩個因子均為 2，因此尺寸為 720 × 540 點的投影片會產生 1440 × 1080 像素的圖像。相等的比例因子會保留投影片的長寬比。每張圖像皆使用 [IImage.Save](https://reference.aspose.com/slides/net/aspose.slides/iimage/save/) 以 PNG 格式儲存。

```cs
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");

var scaleX = 2f;
var scaleY = scaleX;

var slideCount = presentation.Slides.Count;
for (var index = 0; index < slideCount; index++)
{
    var slide = presentation.Slides[index];
    using var image = slide.GetImage(scaleX, scaleY);
    image.Save($"slide_{index}.png", ImageFormat.Png);
}
```

## **將 PowerPoint 轉換為 PNG（自訂大小）**

若要以像素為單位指定輸出尺寸，請將尺寸傳遞給 [ISlide.GetImage](https://reference.aspose.com/slides/net/aspose.slides/islide/getimage/) 而非比例因子。此範例將每張投影片渲染為 960 × 720 像素，並使用 [IImage.Save](https://reference.aspose.com/slides/net/aspose.slides/iimage/save/) 儲存結果。請選擇與投影片長寬比相符的尺寸，以避免圖像拉伸。

```cs
using System.Drawing;
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");

var imageSize = new Size(960, 720);

var slideCount = presentation.Slides.Count;
for (var index = 0; index < slideCount; index++)
{
    var slide = presentation.Slides[index];
    using var image = slide.GetImage(imageSize);
    image.Save($"slide_{index}.png", ImageFormat.Png);
}
```

## **選擇漸層渲染樣式**

假設投影片包含漸層填色，但匯出的 PNG 中的過渡顏色看起來較淡或與 PowerPoint 中的呈現不同。您可以使用 [GradientStyle](https://reference.aspose.com/slides/net/aspose.slides.export/saveoptions/gradientstyle/) 屬性（屬於 [RenderingOptions](https://reference.aspose.com/slides/net/aspose.slides.export/renderingoptions/)）來選擇漸層的渲染方式。

下載 [gradient-styles.pptx](gradient-styles.pptx) 並將其放置於應用程式的工作目錄中。其第一張投影片包含兩個線性漸層：上方由青色漸變為橙色，下方由藍色漸變為黃色。每個漸層都有兩個停點，分別位於 0% 與 100%。

以下範例載入此簡報，並使用 [ISlide.GetImage](https://reference.aspose.com/slides/net/aspose.slides/islide/getimage/) 以兩種模式渲染同一張第一投影片。

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("gradient-styles.pptx");
var slide = presentation.Slides[0];

var gradientStyles = new[] { GradientStyle.Default, GradientStyle.PowerPointUI };
foreach (var style in gradientStyles)
{
    var options = new RenderingOptions { GradientStyle = style };
    using var image = slide.GetImage(options, 1f, 1f);
    image.Save($"gradient-{style}.png", ImageFormat.Png);
}
```

下方圖片顯示同一投影片的輸出結果，每張圖像皆包含兩個漸層：

| Default | PowerPointUI |
| --- | --- |
| ![以 Default 渲染的青色至橙色與藍色至黃色漸層](gradient-Default.png) | ![以 PowerPointUI 渲染的相同漸層](gradient-PowerPointUI.png) |

在此範例中，`Default` 會產生較亮的中間顏色，而 `PowerPointUI` 則產生較暗的中間顏色。差異取決於漸層的顏色與停點。

當標準的 Aspose.Slides 輸出符合需求時，請選擇 `Default`。若您的首要目標是與 PowerPoint 的外觀保持一致，則可嘗試 `PowerPointUI`。將兩種輸出與您的預期結果比較；兩種模式皆無絕對優先之分。

## **常見問題**

**如何匯出特定形狀（例如圖表或圖片）而非整張投影片？**

Aspose.Slides 支援[為個別形狀產生縮圖](/slides/zh-hant/net/create-shape-thumbnails/)，讓您可以將形狀渲染為 PNG 圖像。

**伺服器上是否支援平行轉換？**

是的。對每個執行緒或程序使用獨立的簡報實例；[不要在執行緒之間共享同一個實例](/slides/zh-hant/net/multithreading/)。

**匯出 PNG 時評估版的限制是什麼？**

評估模式會在輸出圖像上加上浮水印，並套用[其他限制](/slides/zh-hant/net/licensing/)，直至套用授權為止。