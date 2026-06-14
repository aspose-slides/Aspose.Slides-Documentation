---
title: 使用 C++ 為 PowerPoint 簡報增強動畫
linktitle: PowerPoint 動畫
type: docs
weight: 150
url: /zh-hant/cpp/powerpoint-animation/
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
- 動畫影像
- 動畫表格
- PowerPoint
- 簡報
- C++
- Aspose.Slides
description: "了解如何在 Aspose.Slides for C++ 中新增與控制進階動畫效果，以建立動態的 PowerPoint 與 OpenDocument 簡報。"
---
## **簡介**

由於簡報的目的是呈現內容，製作時始終會考慮其視覺外觀與互動行為。

**PowerPoint 動畫** 在使簡報吸引觀眾、提升視覺效果方面扮演重要角色。Aspose.Slides for C++ 提供多種選項以 在 PowerPoint 簡報中加入動畫：

- 套用各種 PowerPoint 動畫效果於形狀、圖表、表格、OLE 物件以及其他簡報元素。
- 在單一形狀上使用多個 PowerPoint 動畫效果。
- 使用動畫時間軸來控制動畫效果。
- 建立自訂動畫。

在 Aspose.Slides for C++ 中，可於形狀套用各種動畫效果。由於投影片上的每個元素（包括文字、圖片、OLE 物件、表格等）皆被視為形狀，意味著我們可以對投影片的每個元素套用動畫效果。

[**Aspose.Slides.Animation**](https://reference.aspose.com/slides/zh-hant/cpp/namespace/aspose.slides.animation) **namespace** 提供用於處理 PowerPoint 動畫的類別。

## **動畫效果**

Aspose.Slides 支援 **150+ 動畫效果**，包括基本動畫效果如 Bounce、PathFootball、Zoom 效果，及特定動畫效果如 OLEObjectShow、OLEObjectOpen。您可在 [**EffectType**](https://reference.aspose.com/slides/zh-hant/cpp/namespace/aspose.slides.animation#ae0da11508d382465aa4e7a011df1bf31) 列舉中找到完整的動畫效果清單。

此外，這些動畫效果可以與以下項目結合使用：

- [ColorEffect](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.animation/coloreffect/)
- [CommandEffect](https://reference.aspose.com/slides/zh-hant/cpp/class/aspose.slides.animation.command_effect)
- [FilterEffect](https://reference.aspose.com/slides/zh-hant/cpp/class/aspose.slides.animation.filter_effect)
- [MotionEffect](https://reference.aspose.com/slides/zh-hant/cpp/class/aspose.slides.animation.motion_effect)
- [PropertyEffect](https://reference.aspose.com/slides/zh-hant/cpp/class/aspose.slides.animation.property_effect)
- [RotationEffect](https://reference.aspose.com/slides/zh-hant/cpp/class/aspose.slides.animation.rotation_effect)
- [ScaleEffect](https://reference.aspose.com/slides/zh-hant/cpp/class/aspose.slides.animation.scale_effect)
- [SetEffect](https://reference.aspose.com/slides/zh-hant/cpp/class/aspose.slides.animation.set_effect)

## **自訂動畫**

可以在 Aspose.Slides 中建立您自己的 **自訂動畫**。只要將多個行為組合成新的自訂動畫，即可達成此目的。

[**Behavior**](https://reference.aspose.com/slides/zh-hant/cpp/class/aspose.slides.animation.behavior) 是任何 PowerPoint 動畫效果的構建單位。所有動畫效果實際上是一組組合成單一策略的行為。您可以將行為組合成一次性的自訂動畫，並在其他簡報中重複使用。若將新行為加入標準 PowerPoint 動畫效果，即會產生另一個自訂動畫。例如，您可以為動畫加入重複行為，使其重複數次。

[**Animation Point**](https://reference.aspose.com/slides/zh-hant/cpp/class/aspose.slides.animation.point) 是應用行為的點。

## **動畫時間軸**

[**Sequence**](https://reference.aspose.com/slides/zh-hant/cpp/class/aspose.slides.animation.sequence) 是套用於特定形狀的動畫效果集合。

[**AnimationTimeLine**](https://reference.aspose.com/slides/zh-hant/cpp/class/aspose.slides.animation.animation_time_line) 是在特定投影片中使用的 Sequence 集合。它自 PowerPoint 2002 起即作為動畫引擎。過去的 PowerPoint 版本在為簡報加入動畫效果時相當困難，只能透過各種變通方法。時間軸取代了舊的 AnimationSettings 類別，提供更清晰的 PowerPoint 動畫物件模型。每張投影片只能有一個動畫時間軸。

## **互動動畫**

[**EffectTriggerType**](https://reference.aspose.com/slides/zh-hant/cpp/namespace/aspose.slides.animation#add24fb49dd44eb3227aeeb3641fd2e81) 允許定義使用者操作（例如按鈕點擊），以觸發特定動畫開始。觸發器僅在最新的 PowerPoint 版本中加入。

## **形狀動畫**

Aspose.Slides 允許對形狀套用動畫，形狀實際上可以是文字、矩形、線條、框架、OLE 物件等。

{{% alert color="primary" %}} 
閱讀更多 [**關於形狀動畫**](/slides/zh-hant/cpp/shape-animation/).
{{% /alert %}}

## **動畫圖表**

若要建立動畫圖表，您應使用與形狀相同的類別。然而，PowerPoint 動畫只能套用於圖表的類別或系列。您亦可對類別元素或系列元素套用動畫效果。

{{% alert color="primary" %}} 
閱讀更多 [**關於動畫圖表**](/slides/zh-hant/cpp/animated-charts/).
{{% /alert %}}

## **動畫文字**

除了動畫文字外，也可以對段落套用動畫。

{{% alert color="primary" %}} 
閱讀更多 [**關於動畫文字**](/slides/zh-hant/cpp/animated-text/).
{{% /alert %}}

## **常見問題**

**匯出為 PDF 時動畫會被保留嗎？**

不會。PDF 為靜態格式，動畫與[投影片轉場](/slides/zh-hant/cpp/slide-transition/)不會播放。若需要動態效果，請改為匯出至[HTML5](/slides/zh-hant/cpp/export-to-html5/)、[動畫 GIF](/slides/zh-hant/cpp/convert-powerpoint-to-animated-gif/)或[影片](/slides/zh-hant/cpp/convert-powerpoint-to-video/)。

**我可以將動畫簡報轉換為影片，並控制幀率與畫面大小嗎？**

可以。您可以[將簡報渲染為影格](/slides/zh-hant/cpp/convert-powerpoint-to-video/) 並使用影片編碼工具（例如 ffmpeg）將其編碼為影片，並自行選擇 FPS 與解析度。渲染過程中會播放動畫與投影片轉場。

**在處理 ODP（不僅限於 PPTX）時動畫會保持完整嗎？**

PPT、PPTX 與 ODP 都支援[讀取](/slides/zh-hant/cpp/open-presentation/)與[寫入](/slides/zh-hant/cpp/save-presentation/)，但格式差異可能導致某些效果在外觀或行為上略有不同。請使用實際樣本驗證關鍵情況。