---
title: 在 .NET 中使用動畫增強 PowerPoint 簡報
linktitle: PowerPoint 動畫
type: docs
weight: 150
url: /zh-hant/net/powerpoint-animation/
keywords:
- 加入動畫
- 更新動畫
- 變更動畫
- 移除動畫
- 管理動畫
- 控制動畫
- 動畫效果
- PowerPoint 動畫
- 動畫時間軸
- 互動動畫
- 自訂動畫
- 形狀動畫
- 動畫圖表
- 動畫文字
- 動畫形狀
- 動畫 OLE 物件
- 動畫影像
- 動畫表格
- PowerPoint 簡報
- .NET
- C#
- Aspose.Slides
description: "探索 Aspose.Slides for .NET 在處理 PowerPoint 動畫方面的功能。此概覽概述了主要特點，並提供深入見解以提升您的簡報。"
---
## **簡介**

由於簡報的目的是呈現內容，因此在製作時始終會考慮其視覺外觀與互動行為。

**PowerPoint animation** 在使簡報吸引觀眾注意並提升參與感方面扮演重要角色。Aspose.Slides for .NET 提供多種選項，讓您為 PowerPoint 簡報加入動畫：

- 對形狀、圖表、表格、OLE 物件及其他簡報元素套用各種 PowerPoint 動畫效果。
- 在單一形狀上使用多個 PowerPoint 動畫效果。
- 利用動畫時間軸來控制動畫效果。
- 建立自訂動畫。

在 Aspose.Slides for .NET 中，可將各種動畫效果套用於形狀。由於投影片上的每個元素（包括文字、圖片、OLE 物件和表格）皆視為形狀，動畫效果可套用到投影片上的任何元素。

[Aspose.Slides.Animation](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.animation/) 命名空間提供用於處理 PowerPoint 動畫的類別。

## **動畫效果**

Aspose.Slides 支援 **150+ 動畫效果**，包括 Bounce、PathFootball、Zoom 等基本效果，以及 OLEObjectShow、OLEObjectOpen 等特定效果。您可以在 [EffectType](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.animation/effecttype) 列舉中找到完整的動畫效果清單。

此外，這些動畫效果還可以與下列項目結合使用：

- [ColorEffect](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.animation/coloreffect)
- [CommandEffect](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.animation/commandeffect)
- [FilterEffect](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.animation/filtereffect)
- [MotionEffect](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.animation/motioneffect)
- [PropertyEffect](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.animation/propertyeffect)
- [RotationEffect](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.animation/rotationeffect)
- [ScaleEffect](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.animation/scaleeffect)
- [SetEffect](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.animation/seteffect)

## **自訂動畫**

您可以在 Aspose.Slides 中建立自己的 **自訂動畫**。透過將多個行為結合成新的自訂動畫即可實現。

[Behaviour](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.animation/behavior) 是任何 PowerPoint 動畫效果的基本構件。所有動畫效果本質上都是由一組行為組合而成的策略。您可以將行為結合成自訂動畫，然後在其他簡報中重複使用。若將新行為加入標準 PowerPoint 動畫效果，則會形成另一個自訂動畫。例如，您可以為動畫加入重複行為，使其重複數次。

[Animation Point](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.animation/point) 是應用行為的定位點。

## **動畫時間軸**

[Sequence](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.animation/sequence) 是套用於特定形狀的動畫效果集合。

[Timeline](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.animation/animationtimeline) 是在特定投影片中使用的一組序列。它是 PowerPoint 2002 引入的動畫引擎。在較早的 PowerPoint 版本中，為簡報加入動畫效果相當困難，且只能透過各種變通方法實作。時間軸取代了舊的 AnimationSettings 類別，提供更清晰的 PowerPoint 動畫物件模型。每張投影片只能有一個動畫時間軸。

## **互動動畫**

[Trigger](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.animation/effecttriggertype) 允許您定義使用者操作（例如按鈕點擊），以觸發特定動畫。Triggers 是在最新版本的 PowerPoint 中引入的功能。

## **形狀動畫**

Aspose.Slides 允許您對形狀套用動畫，這些形狀可包括文字、矩形、線條、框架、OLE 物件等。

{{% alert color="info" %}} 
閱讀更多 [**關於形狀動畫**](/slides/zh-hant/net/shape-animation/).
{{% /alert %}}

## **動畫圖表**

若要建立動畫圖表，應使用與形狀相同的類別。但 PowerPoint 動畫僅能套用於圖表類別或圖表系列。您也可以對類別元素或系列元素套用動畫效果。

{{% alert color="info" %}} 
閱讀更多 [**關於動畫圖表**](/slides/zh-hant/net/animated-charts/).
{{% /alert %}}

## **動畫文字**

除了動畫文字外，也可以對段落套用動畫。

{{% alert color="info" %}} 
閱讀更多 [**關於動畫文字**](/slides/zh-hant/net/animated-text/).
{{% /alert %}}

## **常見問題**

### 匯出為 PDF 時動畫會被保留嗎？

不會。PDF 為靜態格式，動畫與 [slide transitions](/slides/zh-hant/net/slide-transition/) 不會播放。如果需要動態效果，請匯出為 [HTML5](/slides/zh-hant/net/export-to-html5/)、[animated GIF](/slides/zh-hant/net/convert-powerpoint-to-animated-gif/) 或 [video](/slides/zh-hant/net/convert-powerpoint-to-video/) 。

### 我可以將動畫簡報轉成影片並控制影格率與影格尺寸嗎？

可以。您可以 [render the presentation as frames](/slides/zh-hant/net/convert-powerpoint-to-video/) 並將其編碼為影片（例如使用 ffmpeg），自行選擇 FPS 與解析度。渲染過程中會播放動畫與投影片切換效果。

### 使用 ODP（不僅限 PPTX）時動畫會保持完整嗎？

PPT、PPTX 與 ODP 均支援 [reading](/slides/zh-hant/net/open-presentation/) 與 [writing](/slides/zh-hant/net/save-presentation/)，但由於格式差異，某些效果可能會在外觀或行為上略有不同。請使用實際範本驗證關鍵情況。