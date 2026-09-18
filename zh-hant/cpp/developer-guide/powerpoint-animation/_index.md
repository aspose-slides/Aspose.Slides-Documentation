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
- C++
- Aspose.Slides
description: "了解如何在 Aspose.Slides for C++ 中新增與控制進階動畫效果，以建立動態的 PowerPoint 與 OpenDocument 簡報。"
---
## **介紹**

由於簡報的目的是呈現內容，在建立過程中始終會考慮其視覺外觀與互動行為。

**PowerPoint 動畫** 在使簡報更吸睛且具吸引力方面扮演重要角色。Aspose.Slides 提供多種選項，可將動畫加入 PowerPoint 簡報：

- 套用各種 PowerPoint 動畫效果至圖形、圖表、表格、OLE 物件及其他簡報元素。
- 在單一圖形上使用多個 PowerPoint 動畫效果。
- 利用動畫時間軸來控制動畫效果。
- 建立自訂動畫。

在 Aspose.Slides 中，可對圖形套用各種動畫效果。由於投影片上的每個元素（包括文字、圖片、OLE 物件和表格）皆視為圖形，動畫效果可套用於投影片上的任何元素。

[Aspose::Slides::Animation](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.animation/) 命名空間提供用於處理 PowerPoint 動畫的類別。

## **動畫效果**
Aspose.Slides 支援 **150+ 種動畫效果**，包括 Bounce、PathFootball 與 Zoom 等基本效果，以及 OLEObjectShow 與 OLEObjectOpen 等特定效果。完整清單可參考 [EffectType](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.animation/effecttype/) 列舉。

此外，這些動畫效果可與以下行為組合使用：

- [ColorEffect](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.animation/coloreffect/)
- [CommandEffect](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.animation/commandeffect/)
- [FilterEffect](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.animation/filtereffect/)
- [MotionEffect](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.animation/motioneffect/)
- [PropertyEffect](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.animation/propertyeffect/)
- [RotationEffect](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.animation/rotationeffect/)
- [ScaleEffect](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.animation/scaleeffect/)
- [SetEffect](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.animation/seteffect/)

## **自訂動畫**

欲取得建立、檢視與修改行為及可編輯移動路徑的完整 C++ 範例，請參閱 [Custom Animation](/slides/zh-hant/cpp/custom-animation/)。

在 Aspose.Slides 中可以建立自己的 **自訂動畫**。透過將多個行為組合成新的自訂動畫即可實現。

[Behavior](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.animation/behavior/) 是 PowerPoint 動畫效果的組成基礎。組合多個行為以自訂效果，或加入行為以擴充預先定義的效果。重複次數透過時間設定而非單獨的 repeat 行為來配置。

[Animation Point](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.animation/point/) 是應套用行為的點位。

## **動畫時間軸**
[Sequence](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.animation/sequence/) 是可針對不同圖形的動畫效果集合。

[IAnimationTimeLine](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ianimationtimeline/) 是在特定投影片中使用的一組序列。它是 PowerPoint 2002 之後引入的動畫引擎。早期 PowerPoint 版本中，加入動畫效果相當困難且只能透過各種變通方法實現。時間軸為 PowerPoint 動畫提供更清晰的物件模型。每張投影片僅能有一個動畫時間軸。

## **互動式動畫**
[Trigger](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.animation/effecttriggertype/) 允許您定義使用者操作（例如按鈕點擊），以啟動特定動畫。

## **形狀動畫**
Aspose.Slides 允許您對圖形套用動畫，圖形可包含文字、矩形、線條、框架、OLE 物件等。

{{% alert color="info" title="Note" %}}
了解更多 [**關於形狀動畫**](/slides/zh-hant/cpp/shape-animation/)。
{{% /alert %}}

## **動畫圖表**
若要建立動畫圖表，應使用與圖形相同的類別。然而，PowerPoint 動畫只能套用於圖表類別或系列。您亦可對類別元素或系列元素套用動畫效果。

{{% alert color="info" title="Note" %}}
了解更多 [**關於動畫圖表**](/slides/zh-hant/cpp/animated-charts/)。
{{% /alert %}}

## **動畫文字**
除了動畫文字外，您還可以對段落套用動畫。

{{% alert color="info" title="Note" %}}
了解更多 [**關於動畫文字**](/slides/zh-hant/cpp/animated-text/)。
{{% /alert %}}

## **常見問題**

**匯出為 PDF 時動畫會被保留嗎？**

不會。PDF 為靜態格式，動畫與 [投影片轉場](/slides/zh-hant/cpp/slide-transition/) 皆不會播放。如果需要動態效果，請改為匯出至 [HTML5](/slides/zh-hant/cpp/export-to-html5/)、[動畫 GIF](/slides/zh-hant/cpp/convert-powerpoint-to-animated-gif/) 或 [影片](/slides/zh-hant/cpp/convert-powerpoint-to-video/)。

**我可以將動畫簡報轉換成影片，並控制幀率與解析度嗎？**

可以。您可以 [將簡報渲染為影格](/slides/zh-hant/cpp/convert-powerpoint-to-video/) 再使用影片編碼工具（例如 ffmpeg）將其編碼成影片，並自行選擇幀率與解析度。渲染過程中會播放動畫與投影片轉場。

**在使用 ODP（不僅限於 PPTX）時動畫會保持完整嗎？**

PPT、PPTX 與 ODP 均支援 [讀取](/slides/zh-hant/cpp/open-presentation/) 與 [寫入](/slides/zh-hant/cpp/save-presentation/)，但無法保證動畫會被保留。轉換為 ODP 時可能會遺失自訂動畫資料。請參閱 [Custom Animation](/slides/zh-hant/cpp/custom-animation/) 取得範例與檢查格式相容性的指引。