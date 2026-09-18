---
title: 使用 .NET 動畫增強 PowerPoint 簡報
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
description: "探索 Aspose.Slides for .NET 在處理 PowerPoint 動畫方面的功能。此概覽概述了主要特徵，並提供提升簡報的見解。"
---
## **簡介**

由於簡報旨在呈現內容，於建立過程中必須考慮其視覺外觀與互動行為。

**PowerPoint 動畫** 在使簡報吸引觀眾目光並提升互動性方面扮演重要角色。Aspose.Slides for .NET 提供了廣泛的選項，讓您為 PowerPoint 簡報加入動畫：

- 將各種 PowerPoint 動畫效果套用於圖形、圖表、表格、OLE 物件及其他簡報元素。
- 在單一圖形上使用多個 PowerPoint 動畫效果。
- 利用動畫時間軸來控制動畫效果。
- 建立自訂動畫。

在 Aspose.Slides for .NET 中，可將各種動畫效果套用於圖形。因為投影片上的每個元素（包括文字、圖片、OLE 物件與表格）皆視為圖形，所以動畫效果可套用於投影片上的任何元素。

[Aspose.Slides.Animation](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.animation/) 命名空間提供用於操作 PowerPoint 動畫的類別。

## **動畫效果**

Aspose.Slides 支援 **150+ 個動畫效果**，包括 Bounce、PathFootball、Zoom 等基本效果，以及 OLEObjectShow、OLEObjectOpen 等特定效果。您可在 [EffectType](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.animation/effecttype) 列舉中找到完整的動畫效果清單。

此外，這些動畫效果還可與下列項目結合使用：

- [ColorEffect](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.animation/coloreffect)
- [CommandEffect](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.animation/commandeffect)
- [FilterEffect](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.animation/filtereffect)
- [MotionEffect](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.animation/motioneffect)
- [PropertyEffect](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.animation/propertyeffect)
- [RotationEffect](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.animation/rotationeffect)
- [ScaleEffect](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.animation/scaleeffect)
- [SetEffect](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.animation/seteffect)

## **自訂動畫**

欲取得完整的 C# 示例，說明如何建立、檢查與修改行為和可編輯的運動路徑，請參閱 [Custom Animation](/slides/zh-hant/net/custom-animation/)。

在 Aspose.Slides 中可以建立您自己的 **自訂動畫**。透過將多個行為組合成新的自訂動畫即可達成此目的。

[Behavior](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.animation/behavior) 是 PowerPoint 動畫效果的構件。結合多個行為以自訂效果，或加入行為來擴充預定義效果。重複次數是透過時間設定來配置，而非使用獨立的 repeat 行為。

[Animation Point](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.animation/point) 是應用行為的點位。

## **動畫時間線**

[Sequence](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.animation/sequence) 是可針對不同圖形的動畫效果集合。

[Timeline](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.animation/animationtimeline) 是在特定投影片中使用的序列集合。它是於 PowerPoint 2002 引入的動畫引擎。早期 PowerPoint 版本中，為簡報加入動畫效果相當困難且只能透過各種變通方式實作。時間軸取代了舊的 AnimationSettings 類別，提供了更清晰的 PowerPoint 動畫物件模型。一張投影片只能有一個動畫時間軸。

## **互動動畫**

[Trigger](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.animation/effecttriggertype) 讓您定義使用者行為（例如按鈕點擊），以啟動特定動畫。Triggers 在最新版本的 PowerPoint 中首次加入。

## **圖形動畫**

Aspose.Slides 允許您為圖形套用動畫，圖形可包含文字、矩形、線條、框架、OLE 物件等等。

{{% alert color="info" title="Note" %}}
閱讀更多 [**關於圖形動畫**](/slides/zh-hant/net/shape-animation/)。
{{% /alert %}}

## **動畫圖表**

若要建立動畫圖表，應使用與圖形相同的類別。然而，PowerPoint 動畫只能套用於圖表類別或圖表系列。您也可以將動畫效果套用於類別元素或系列元素。

{{% alert color="info" title="Note" %}}
閱讀更多 [**關於動畫圖表**](/slides/zh-hant/net/animated-charts/)。
{{% /alert %}}

## **動畫文字**

除了為文字加入動畫外，亦可對段落套用動畫。

{{% alert color="info" title="Note" %}}
閱讀更多 [**關於動畫文字**](/slides/zh-hant/net/animated-text/)。
{{% /alert %}}

## **常見問題**

**匯出為 PDF 時，動畫會被保留嗎？**

不會。PDF 為靜態格式，故動畫與[投影片切換](/slides/zh-hant/net/slide-transition/)不會播放。如需動態效果，可改為匯出至[HTML5](/slides/zh-hant/net/export-to-html5/)、[animated GIF](/slides/zh-hant/net/convert-powerpoint-to-animated-gif/)或[video](/slides/zh-hant/net/convert-powerpoint-to-video/)。

**我可以將動畫簡報轉成影片，並控制影格率與影格大小嗎？**

可以。您可以[將簡報渲染為影格](/slides/zh-hant/net/convert-powerpoint-to-video/)並以影片編碼（例如使用 ffmpeg），選擇 FPS 與解析度。在渲染過程中會播放動畫與投影片切換。

**在使用 ODP（不僅限 PPTX）時，動畫會保持完整嗎？**

支援 PPT、PPTX 與 ODP 的[讀取](/slides/zh-hant/net/open-presentation/)與[寫入](/slides/zh-hant/net/save-presentation/)，但無法保證動畫會被保留。轉換為 ODP 時可能會遺失自訂動畫資料。請參閱[自訂動畫](/slides/zh-hant/net/custom-animation/)以獲得測試範例與格式限制。