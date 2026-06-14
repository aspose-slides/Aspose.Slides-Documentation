---
title: 在 .NET 中使用動畫增強 PowerPoint 簡報
linktitle: PowerPoint 動畫
type: docs
weight: 150
url: /zh-hant/net/powerpoint-animation/
keywords:
- 新增動畫
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
- 圖形動畫
- 動畫圖表
- 動畫文字
- 動畫圖形
- 動畫 OLE 物件
- 動畫影像
- 動畫表格
- PowerPoint 簡報
- .NET
- C#
- Aspose.Slides
description: "探索 Aspose.Slides for .NET 在處理 PowerPoint 動畫方面的功能。此概觀概述了主要特色，並提供見解以提升您的簡報。"
---
## **簡介**

由於簡報的目的在於呈現內容，製作時必須同時考量其視覺外觀與互動行為。

**PowerPoint 動畫** 在讓簡報更具吸引力與互動性方面扮演重要角色。Aspose.Slides for .NET 提供多種方式將動畫加入 PowerPoint 簡報：

- 為圖形、圖表、表格、OLE 物件及其他簡報元素套用各種 PowerPoint 動畫效果。
- 在單一圖形上使用多個 PowerPoint 動畫效果。
- 使用動畫時間軸來控制動畫效果。
- 建立自訂動畫。

在 Aspose.Slides for .NET 中，可將各種動畫效果套用至圖形。由於投影片上的每個元素（包括文字、圖片、OLE 物件與表格）皆視為圖形，動畫效果即可套用於投影片上的任何元素。

[Aspose.Slides.Animation](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.animation/) namespace 提供用於操作 PowerPoint 動畫的類別。

## **動畫效果**

Aspose.Slides 支援 **150+ 動畫效果**，包含 Bounce、PathFootball、Zoom 等基本效果，以及 OLEObjectShow、OLEObjectOpen 等特定效果。完整的動畫效果清單可在 [EffectType](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.animation/effecttype) 列舉中找到。

此外，這些動畫效果可與以下項目結合使用：

- [ColorEffect](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.animation/coloreffect)
- [CommandEffect](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.animation/commandeffect)
- [FilterEffect](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.animation/filtereffect)
- [MotionEffect](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.animation/motioneffect)
- [PropertyEffect](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.animation/propertyeffect)
- [RotationEffect](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.animation/rotationeffect)
- [ScaleEffect](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.animation/scaleeffect)
- [SetEffect](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.animation/seteffect)

## **自訂動畫**

在 Aspose.Slides 中可以建立 **自訂動畫**。只要將多個行為組合成新的自訂動畫即可。

[Behaviour](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.animation/behavior) 是任何 PowerPoint 動畫效果的基本構件。所有動畫效果本質上都是一組行為的集合。您可以先將行為組合成自訂動畫，之後在其他簡報中重複使用。若將新行為加入標準 PowerPoint 動畫效果，該效果亦會變成另一種自訂動畫。例如，您可以為動畫加入重複行為，使其重複播放數次。

[Animation Point](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.animation/point) 表示應套用行為的定位點。

## **動畫時間軸**

[Sequence](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.animation/sequence) 是套用於特定圖形的一組動畫效果的集合。

[Timeline](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.animation/animationtimeline) 是在特定投影片中使用的序列集合。此動畫引擎於 PowerPoint 2002 引入。早期 PowerPoint 版本中，為簡報加入動畫效果相當困難，且只能透過各種變通方式實作。時間軸取代了舊的 AnimationSettings 類別，提供了更清晰的 PowerPoint 動畫物件模型。一張投影片只能有一個動畫時間軸。

## **互動動畫**

[Trigger](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.animation/effecttriggertype) 允許您定義使用者動作（例如按鈕點擊），以觸發特定動畫。觸發器是在最新版本的 PowerPoint 中引入的功能。

## **圖形動畫**

Aspose.Slides 允許您對圖形套用動畫，圖形可包括文字、矩形、線條、框架、OLE 物件等。

{{% alert color="primary" %}} 
Read more [**About Shape Animation**](/slides/zh-hant/net/shape-animation/).
{{% /alert %}}

## **動畫圖表**

若要建立動畫圖表，應使用與圖形相同的類別。但 PowerPoint 動畫只能套用於圖表類別或圖表系列。您也可以對類別元素或系列元素套用動畫效果。

{{% alert color="primary" %}} 
Read more [**About Animated Charts**](/slides/zh-hant/net/animated-charts/).
{{% /alert %}}

## **動畫文字**

除了動畫文字外，還可以對段落套用動畫。

{{% alert color="primary" %}} 
Read more [**About Animated Text**](/slides/zh-hant/net/animated-text/).
{{% /alert %}}

## **常見問題**

**匯出為 PDF 時會保留動畫嗎？**

不會。PDF 為靜態格式，動畫與[投影片過場](/slides/zh-hant/net/slide-transition/)不會播放。如需動態效果，請匯出為[HTML5](/slides/zh-hant/net/export-to-html5/)、[Animated GIF](/slides/zh-hant/net/convert-powerpoint-to-animated-gif/)或[影片](/slides/zh-hant/net/convert-powerpoint-to-video/)。

**我可以將動畫簡報轉成影片，並控制幀率與解析度嗎？**

可以。您可以[將簡報渲染為幀](/slides/zh-hant/net/convert-powerpoint-to-video/)，再使用 ffmpeg 等工具編碼為影片，並自行選擇 FPS 與解析度。渲染過程中會播放動畫與投影片過場。

**在處理 ODP（不僅限 PPTX）時，動畫會保持完整嗎？**

PPT、PPTX 與 ODP 均支援[讀取](/slides/zh-hant/net/open-presentation/)與[寫入](/slides/zh-hant/net/save-presentation/)，但由於格式差異，某些效果可能會略有不同。建議使用實際樣本驗證關鍵情況。