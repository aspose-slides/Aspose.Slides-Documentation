---
title: 從簡報中取得整個投影片背景作為圖像
linktitle: 整個投影片背景
type: docs
weight: 95
url: /zh-hant/net/get-the-entire-presentation-slide-background-as-an-image/
keywords:
- 投影片背景
- 最終背景
- 提取背景
- 完整背景
- 背景轉為圖像
- PPT 背景
- PPTX 背景
- ODP 背景
- PowerPoint
- OpenDocument
- 簡報
- .NET
- C#
- Aspose.Slides
description: "使用 Aspose.Slides for .NET 從 PowerPoint 與 OpenDocument 簡報中提取完整投影片背景為圖像，簡化視覺工作流程。"
---
## **概觀**

在 PowerPoint 簡報中，投影片背景可能由多個元素組成，包括投影片背景圖像、簡報主題、配色方案，以及放置在母片或版面投影片上的物件。

本文說明如何使用 Aspose.Slides for .NET 將整個投影片背景匯出為圖像。由於沒有單一方法可直接完成此任務，這種做法包括將所選投影片複製到暫存簡報，移除投影片形狀，然後將結果的投影片背景轉換為圖像。

## **取得整個投影片背景**

Aspose.Slides for .NET 不提供簡單的方法直接提取整個簡報投影片背景為圖像，但您可以依照下列步驟完成：

1. 使用 [Presentation](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation/) 類別載入簡報。
2. 從簡報取得投影片尺寸。
3. 選取一張投影片。
4. 建立暫存簡報。
5. 在暫存簡報中設定相同的投影片尺寸。
6. 將選取的投影片複製至暫存簡報。
7. 刪除複製投影片中的形狀。
8. 將複製的投影片轉換為圖像。

以下程式碼範例將整個簡報投影片背景提取為圖像。
```cs
var slideIndex = 0;
var imageScale = 1;

using var presentation = new Presentation("sample.pptx");

var slideSize = presentation.SlideSize.Size;
var slide = presentation.Slides[slideIndex];

using var tempPresentation = new Presentation();    
tempPresentation.SlideSize.SetSize(slideSize.Width, slideSize.Height, SlideSizeScaleType.DoNotScale);

var clonedSlide = tempPresentation.Slides.AddClone(slide);
clonedSlide.Shapes.Clear();

using var background = clonedSlide.GetImage(imageScale, imageScale);
background.Save("output.png", ImageFormat.Png);
```

## **常見問題**

**來自母片的複雜漸層、紋理或圖片填充會在最終背景圖像中被保留嗎？**

是的。Aspose.Slides 會呈現在投影片、版面或母片上定義的漸層、圖片與紋理填充。如果您需要從繼承的母片中隔離外觀，請在匯出之前於目前投影片[設定自己的背景](/slides/zh-hant/net/presentation-background/)。

**我可以在儲存之前為最終背景圖像加入浮水印嗎？**

可以。您可以在工作[投影片副本](/slides/zh-hant/net/clone-slides/)上[加入浮水印](/slides/zh-hant/net/watermark/)形狀或圖像（放在其他內容之後），然後再匯出。這讓您產生已內嵌浮水印的背景圖像。

**我可以在不依賴現有投影片的情況下取得特定版面或母片的背景嗎？**

可以。存取所需的母片或版面，將其套用到具有所需尺寸的[暫存投影片](/slides/zh-hant/net/clone-slides/)，然後匯出該投影片，即可取得來自該版面或母片的背景。

**圖像匯出是否受到授權限制？**

渲染功能在[有效授權](/slides/zh-hant/net/licensing/)下可完整使用。評估模式下，輸出可能包含如浮水印等限制。請在每個程序第一次執行批次匯出前啟用授權。