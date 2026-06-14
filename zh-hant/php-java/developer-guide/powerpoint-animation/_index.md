---
title: 在 PHP 中使用動畫增強 PowerPoint 簡報
linktitle: PowerPoint 動畫
type: docs
weight: 150
url: /zh-hant/php-java/powerpoint-animation/
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
- 互動式動畫
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
- PHP
- Aspose.Slides
description: "探索 Aspose.Slides for PHP via Java 在處理 PowerPoint 動畫方面的功能。關鍵特性與見解，協助您提升簡報品質。"
---
## **簡介**

由於簡報旨在呈現內容，在建立簡報時，始終會考慮其視覺外觀和互動行為。

**PowerPoint 動畫** 在使簡報吸引觀眾目光並具吸引力方面，扮演了重要角色。Aspose.Slides for PHP via Java 提供了廣泛的選項，可將動畫新增至 PowerPoint 簡報：

- 套用各種 PowerPoint 動畫效果於形狀、圖表、表格、OLE 物件及其他簡報元素。
- 在單一形狀上使用多個 PowerPoint 動畫效果。
- 使用動畫時間軸來控制動畫效果。
- 建立自訂動畫。

在 Aspose.Slides for PHP via Java 中，各種動畫效果可套用於形狀。由於投影片上的每個元素（包括文字、圖片、OLE 物件、表格等）皆視為形狀，這表示我們可以對投影片的每個元素套用動畫效果。

## **動畫效果**
Aspose.Slides 支援 **150+ 動畫效果**，包括基本的動畫效果，如 Bounce、PathFootball、Zoom 效果，以及特定的動畫效果如 OLEObjectShow、OLEObjectOpen。您可以在 [**EffectType**](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/effecttype/) 列舉中找到完整的動畫效果清單。

此外，這些動畫效果還可以與以下項目結合使用：

- [ColorEffect](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/ColorEffect)
- [CommandEffect](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/CommandEffect)
- [FilterEffect](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/FilterEffect)
- [MotionEffect](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/MotionEffect)
- [PropertyEffect](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/PropertyEffect)
- [RotationEffect](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/RotationEffect)
- [ScaleEffect](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/ScaleEffect)
- [SetEffect](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/SetEffect)

## **自訂動畫**
在 Aspose.Slides 中可以建立您自己的 **自訂動畫**。只要將多個行為結合成新的自訂動畫，即可實現此目的。

[**Behavior**](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/Behavior) 是任何 PowerPoint 動畫效果的構建單元。所有動畫效果實際上是一組組合成單一策略的行為。您可以一次將行為結合成自訂動畫，並在其他簡報中重複使用。如果您將新行為加入標準 PowerPoint 動畫效果，將形成另一個自訂動畫。例如，您可以為動畫加入重複行為，使其重複數次。

[**Animation Point**](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/Point) 是應用行為的點位。

## **動畫時間軸**
[**Sequence**](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/Sequence) 是套用於特定形狀的一組動畫效果集合。

[**Timeline**](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/AnimationTimeLine) 是在特定投影片中使用的一組 Sequence。它自 PowerPoint 2002 起即作為動畫引擎呈現。在早期的 PowerPoint 版本中，為簡報加入動畫效果相當困難，僅能透過各種變通方法實現。Timeline 用於取代舊的 AnimationSettings 類別，並提供更清晰的 PowerPoint 動畫物件模型。一張投影片只能有一個動畫時間軸。

## **互動式動畫**
[**Trigger**](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/EffectTriggerType) 允許定義使用者操作（例如按鈕點擊），以啟動特定動畫。Triggers 只在最新的 PowerPoint 版本中加入。

## **形狀動畫**
Aspose.Slides 允許對形狀套用動畫，形狀實際上可以是文字、矩形、線條、框架、OLE 物件等。

{{% alert color="primary" %}} 
閱讀更多 [**關於形狀動畫**](/slides/zh-hant/php-java/shape-animation/).
{{% /alert %}}

## **動畫圖表**
若要建立動畫圖表，您應使用與形狀相同的類別。然而，PowerPoint 動畫僅能套用於圖表的類別或系列。您也可以對類別元素或系列元素套用動畫效果。

{{% alert color="primary" %}} 
閱讀更多 [**關於動畫圖表**](/slides/zh-hant/php-java/animated-charts/).
{{% /alert %}}

## **動畫文字**
除了動畫文字之外，也可以對段落套用動畫。

{{% alert color="primary" %}} 
閱讀更多 [**關於動畫文字**](/slides/zh-hant/php-java/animated-text/).
{{% /alert %}}

## **常見問題**
**匯出為 PDF 時會保留動畫嗎？**

不會。PDF 為靜態格式，因而不會播放動畫與[投影片切換](/slides/zh-hant/php-java/slide-transition/)。如果需要動態效果，請改為匯出為[HTML5](/slides/zh-hant/php-java/export-to-html5/)、[動畫 GIF](/slides/zh-hant/php-java/convert-powerpoint-to-animated-gif/)或[影片](/slides/zh-hant/php-java/convert-powerpoint-to-video/)。

**我可以將動畫簡報轉成影片，並控制幀率與幀大小嗎？**

是的。您可以[將簡報渲染為影格](/slides/zh-hant/php-java/convert-powerpoint-to-video/)並將其編碼為影片（例如使用 ffmpeg），選擇幀率與解析度。動畫與投影片切換會在渲染過程中播放。

**在使用 ODP（不僅限 PPTX）時，動畫會保持完整嗎？**

支援 PPT、PPTX 與 ODP 的[讀取](/slides/zh-hant/php-java/open-presentation/)與[寫入](/slides/zh-hant/php-java/save-presentation/)，但由於格式差異，某些效果可能會略有不同的顯示或行為。請以真實樣本驗證關鍵情況。