---
title: 在 Java 中使用動畫增強 PowerPoint 簡報
linktitle: PowerPoint 動畫
type: docs
weight: 150
url: /zh-hant/java/powerpoint-animation/
keywords:
- 添加動畫
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
- PowerPoint
- 簡報
- Java
- Aspose.Slides
description: "探索 Aspose.Slides for Java 在處理 PowerPoint 動畫方面的功能。本概述重點說明主要特性，並提供提升簡報效果的見解。"
---
## **簡介**

由於簡報的目的是呈現內容，在製作過程中始終會考慮其視覺外觀與互動行為。

**PowerPoint animation** 在使簡報更吸引觀眾、提升參與感方面扮演重要角色。Aspose.Slides 提供多種選項，讓您為 PowerPoint 簡報加入動畫：

- 將各種 PowerPoint 動畫效果套用於形狀、圖表、表格、OLE 物件以及其他簡報元素。
- 在單一形狀上使用多個 PowerPoint 動畫效果。
- 利用動畫時間軸來控制動畫效果。
- 建立自訂動畫。

在 Aspose.Slides 中，可將各種動畫效果套用於形狀。由於投影片上的每個元素（包括文字、圖片、OLE 物件和表格）皆視為形狀，動畫效果即可套用於投影片上的任何元素。

## **動畫效果**
Aspose.Slides 支援 **150+** 種動畫效果，包含基本的動畫效果，如 Bounce、PathFootball、Zoom 效果，以及特定的動畫效果如 OLEObjectShow、OLEObjectOpen。您可在[**EffectType**](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/effecttype/)列舉中找到完整的動畫效果清單。

此外，這些動畫效果還可以與以下效果結合使用：

- [ColorEffect](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ColorEffect)
- [CommandEffect](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/CommandEffect)
- [FilterEffect](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/FilterEffect)
- [MotionEffect](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/MotionEffect)
- [PropertyEffect](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/PropertyEffect)
- [RotationEffect](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/RotationEffect)
- [ScaleEffect](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ScaleEffect)
- [SetEffect](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/SetEffect)

## **自訂動畫**
在 Aspose.Slides 中可以建立您自己的 **自訂動畫**。只要將多個行為結合成新的自訂動畫，即可達成此目的。

[**Behavior**](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/Behavior) 是任何 PowerPoint 動畫效果的組成單元。所有動畫效果實際上是一組行為組合成的策略。您可以將行為結合成自訂動畫，之後在其他簡報中重複使用。若將新行為加入標準 PowerPoint 動畫效果，即會形成另一個自訂動畫。例如，您可以為動畫加入重複行為，使其重複數次。

[**Animation Point**](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/Point) 是應用行為的點位。

## **動畫時間軸**
[**Sequence**](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/Sequence) 是套用於特定形狀的動畫效果集合。

[**Timeline**](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/AnimationTimeLine) 是在特定投影片中使用的 Sequence 集合。自 PowerPoint 2002 起即成為動畫引擎。過去的 PowerPoint 版本很難為簡報加入動畫效果，只能透過各種變通方法。Timeline 取代了舊的 AnimationSettings 類別，提供更清晰的 PowerPoint 動畫物件模型。每張投影片只能有一個動畫時間軸。

## **互動動畫**
[**Trigger**](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/EffectTriggerType) 允許定義使用者操作（例如按鈕點擊），以觸發特定動畫的開始。Trigger 僅在最新的 PowerPoint 版本中加入。

## **形狀動畫**
Aspose.Slides 允許對形狀套用動畫，形狀實際上可以是文字、矩形、線條、框架、OLE 物件等。

{{% alert color="primary" %}} 
閱讀更多 [**關於形狀動畫**](/slides/zh-hant/java/shape-animation/)
{{% /alert %}}

## **動畫圖表**
要建立動畫圖表，您應使用與形狀相同的類別。然而，PowerPoint 動畫只能套用於圖表類別或圖表系列。您也可以將動畫效果套用於類別元素或系列元素。

{{% alert color="primary" %}} 
閱讀更多 [**關於動畫圖表**](/slides/zh-hant/java/animated-charts/)
{{% /alert %}}

## **動畫文字**
除了動畫文字之外，也可以對段落套用動畫。

{{% alert color="primary" %}} 
閱讀更多 [**關於動畫文字**](/slides/zh-hant/java/animated-text/)
{{% /alert %}}

## **常見問題**

**在匯出為 PDF 時，動畫會被保留嗎？**

不會。PDF 為靜態格式，動畫和 [投影片切換](/slides/zh-hant/java/slide-transition/) 不會播放。如果需要動態效果，請改為匯出至 [HTML5](/slides/zh-hant/java/export-to-html5/)、[動畫 GIF](/slides/zh-hant/java/convert-powerpoint-to-animated-gif/) 或 [影片](/slides/zh-hant/java/convert-powerpoint-to-video/)。

**我可以將動畫簡報轉換為影片，並控制幀率與畫面大小嗎？**

可以。您可以 [將簡報渲染為影格](/slides/zh-hant/java/convert-powerpoint-to-video/) 並使用影片編碼工具（例如 ffmpeg）將其編碼為影片，並自行選擇 FPS 以及解析度。渲染過程中會播放動畫與投影片切換。

**在處理 ODP（不僅是 PPTX）時，動畫會保持完整嗎？**

PPT、PPTX 與 ODP 都支援[讀取](/slides/zh-hant/java/open-presentation/)與[寫入](/slides/zh-hant/java/save-presentation/)，但因格式差異，某些效果可能在外觀或行為上略有不同。請使用真實樣本驗證關鍵情況。