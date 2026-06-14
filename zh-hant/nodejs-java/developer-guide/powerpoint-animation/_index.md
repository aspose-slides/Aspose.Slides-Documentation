---
title: 使用 JavaScript 為 PowerPoint 簡報加入動畫以提升效果
linktitle: PowerPoint 動畫
type: docs
weight: 150
url: /zh-hant/nodejs-java/powerpoint-animation/
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
- 形狀動畫
- 動畫圖表
- 動畫文字
- 動畫形狀
- 動畫 OLE 物件
- 動畫圖像
- 動畫表格
- PowerPoint
- 簡報
- Node.js
- JavaScript
- Aspose.Slides
description: "使用 Aspose.Slides for Node.js via Java 來處理 PowerPoint 動畫。本概述強調主要功能，並提供提升簡報的見解。"
---
## **簡介**

由於簡報的目的是展示內容，在製作時始終會考慮其視覺外觀與互動行為。

**PowerPoint animation** 在使簡報更吸引觀眾方面扮演重要角色。Aspose.Slides for Node.js via Java 提供多種選項，以 將動畫加入 PowerPoint 簡報：

- 套用各種 PowerPoint 動畫效果於形狀、圖表、表格、OLE 物件以及其他簡報元素。
- 在單一形狀上使用多個 PowerPoint 動畫效果。
- 使用動畫時間軸來控制動畫效果。
- 建立自訂動畫。

在 Aspose.Slides for Node.js via Java 中，可將各種動畫效果套用於形狀。由於投影片上的每個元素（包括文字、圖片、OLE 物件、表格等）皆視為形狀，這表示我們可以對投影片的每個元素套用動畫效果。

## **動畫效果**

Aspose.Slides 支援 **150+ 動畫效果**，包括基本動畫效果如 Bounce、PathFootball、Zoom 效果，以及特定動畫效果如 OLEObjectShow、OLEObjectOpen。您可以在 [**EffectType**](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/effecttype/) 列舉中找到完整的動畫效果清單。

此外，這些動畫效果可與以下項目結合使用：

- [ColorEffect](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/ColorEffect)
- [CommandEffect](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/CommandEffect)
- [FilterEffect](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/FilterEffect)
- [MotionEffect](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/MotionEffect)
- [PropertyEffect](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/PropertyEffect)
- [RotationEffect](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/RotationEffect)
- [ScaleEffect](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/ScaleEffect)
- [SetEffect](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/SetEffect)

## **自訂動畫**

在 Aspose.Slides 中可以建立您自己的 **自訂動畫**。只要將多個行為結合成新的自訂動畫即可達成此目標。

[**Behavior**](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/Behavior) 是任何 PowerPoint 動畫效果的構成單元。所有動畫效果實際上是一組行為組成的策略。您可以一次將行為結合成自訂動畫，並於其他簡報中重複使用。若將新行為加入標準 PowerPoint 動畫效果，則會形成另一個自訂動畫。例如，您可以為動畫加入重複行為，使其重複執行數次。

[**Animation Point**](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/Point) 是應用行為的定位點。

## **動畫時間軸**

[**Sequence**](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/Sequence) 是套用在特定形狀上的動畫效果集合。

[**Timeline**](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/AnimationTimeLine) 是在特定投影片中使用的 Sequence 集合。它是自 PowerPoint 2002 起的動畫引擎。於早期 PowerPoint 版本中，添加動畫效果相當困難，僅能透過各種變通方式實現。Timeline 用來取代舊有的 AnimationSettings 類別，提供更清晰的 PowerPoint 動畫物件模型。每張投影片只能擁有一個動畫時間軸。

## **互動動畫**

[**Trigger**](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/EffectTriggerType) 允許定義使用者動作（例如按鈕點擊），以觸發特定動畫開始。Triggers 僅在最新的 PowerPoint 版本中加入。

## **形狀動畫**

Aspose.Slides 允許將動畫套用於形狀，形狀實際上可以是文字、矩形、線條、框架、OLE 物件等。

{{% alert color="primary" %}} 
閱讀更多 [**關於形狀動畫**](/slides/zh-hant/nodejs-java/shape-animation/).
{{% /alert %}}

## **動畫圖表**

若要建立動畫圖表，您應使用與形狀相同的類別。然而，PowerPoint 動畫只能套用於圖表類別或系列。您也可以將動畫效果套用於類別元素或系列元素。

{{% alert color="primary" %}} 
閱讀更多 [**關於動畫圖表**](/slides/zh-hant/nodejs-java/animated-charts/).
{{% /alert %}}

## **動畫文字**

除了動畫文字外，也可以將動畫套用於段落。

{{% alert color="primary" %}} 
閱讀更多 [**關於動畫文字**](/slides/zh-hant/nodejs-java/animated-text/).
{{% /alert %}}

## **常見問題**

**將動畫匯出為 PDF 時會保留嗎？**

不會。PDF 為靜態格式，故動畫與 [投影片過場](/slides/zh-hant/nodejs-java/slide-transition/) 不會播放。如果需要動態效果，請改為匯出至 [HTML5](/slides/zh-hant/nodejs-java/export-to-html5/)、[動畫 GIF](/slides/zh-hant/nodejs-java/convert-powerpoint-to-animated-gif/)，或 [影片](/slides/zh-hant/nodejs-java/convert-powerpoint-to-video/)。

**我可以將動畫簡報轉換為影片，並控制影格速率與大小嗎？**

可以。您可以 [將簡報渲染為影格](/slides/zh-hant/nodejs-java/convert-powerpoint-to-video/) 並將其編碼成影片（例如使用 ffmpeg），選擇 FPS 與解析度。渲染過程中會播放動畫與投影片過場。

**在處理 ODP（不僅限於 PPTX）時，動畫會保持完整嗎？**

PPT、PPTX 與 ODP 均支援[讀取](/slides/zh-hant/nodejs-java/open-presentation/)與[寫入](/slides/zh-hant/nodejs-java/save-presentation/)，但格式差異可能導致某些效果的外觀或行為略有不同。請使用真實樣本驗證關鍵情況。