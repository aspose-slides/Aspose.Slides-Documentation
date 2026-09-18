---
title: 在 Android 上使用動畫增強 PowerPoint 簡報
linktitle: PowerPoint 動畫
type: docs
weight: 150
url: /zh-hant/androidjava/powerpoint-animation/
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
- PowerPoint
- 簡報
- Android
- Java
- Aspose.Slides
description: "探索 Aspose.Slides 在 Android（透過 Java）處理 PowerPoint 動畫的功能。此概覽突顯主要特點。"
---
## **簡介**

由於簡報的目的是用來展示內容，在建立過程中必須始終考慮其視覺外觀與互動行為。

PowerPoint 動畫在使簡報吸引目光、提升觀眾參與度方面扮演重要角色。Aspose.Slides 提供多種選項，讓您為 PowerPoint 簡報加入動畫：

- 將各種 PowerPoint 動畫效果套用於圖形、圖表、表格、OLE 物件以及其他簡報元素。
- 在單一圖形上使用多個 PowerPoint 動畫效果。
- 利用動畫時間軸來控制動畫效果。
- 建立自訂動畫。

在 Aspose.Slides 中，各種動畫效果可套用於圖形。由於投影片上的每個元素，包括文字、圖片、OLE 物件與表格，都被視為圖形，動畫效果因此可套用於投影片上的任何元素。

## **動畫效果**
Aspose.Slides 支援 **150+ 動畫效果**，包括諸如 Bounce、PathFootball、Zoom 等基本效果，以及 OLEObjectShow、OLEObjectOpen 等特定效果。完整列表可參考 [EffectType](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/effecttype/) 類別。

此外，這些動畫效果可與以下行為結合使用：

- [ColorEffect](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ColorEffect)
- [CommandEffect](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/CommandEffect)
- [FilterEffect](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/FilterEffect)
- [MotionEffect](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/MotionEffect)
- [PropertyEffect](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/PropertyEffect)
- [RotationEffect](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/RotationEffect)
- [ScaleEffect](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ScaleEffect)
- [SetEffect](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/SetEffect)

## **自訂動畫**

欲取得完整的 Java 範例（建立、檢查與修改行為以及可編輯的移動路徑），請參閱 [Custom Animation](/slides/zh-hant/java/custom-animation/)。

在 Aspose.Slides 中可以建立自己的 **自訂動畫**。這可透過將多個行為組合為新的自訂動畫來實現。

[Behavior](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/behavior/) 是 PowerPoint 動畫效果的構件。結合多個行為以自訂效果，或加入行為以擴充預先定義的效果。重複次數是透過時間設定來配置，而非使用單獨的重複行為。

[Animation Point](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/point/) 是應用行為的點。

## **動畫時間軸**
[Sequence](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/sequence/) 是一組可針對不同圖形的動畫效果集合。

[Timeline](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/animationtimeline/) 是用於特定投影片的一組序列。它是 PowerPoint 2002 引入的動畫引擎。在較早的 PowerPoint 版本中，為簡報加入動畫效果相當困難且只能透過各種變通方法實現。時間軸為 PowerPoint 動畫提供了更清晰的物件模型。每張投影片只能有一個動畫時間軸。

## **互動動畫**
[Trigger](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/effecttriggertype/) 允許您定義使用者動作（例如按鈕點擊），以啟動特定動畫。

## **圖形動畫**
Aspose.Slides 允許您對圖形套用動畫，這些圖形可包含文字、矩形、線條、框架、OLE 物件等。

{{% alert color="info" title="Note" %}}
閱讀更多 [**關於圖形動畫**](/slides/zh-hant/androidjava/shape-animation/)。
{{% /alert %}}

## **動畫圖表**
若要建立動畫圖表，應使用與圖形相同的類別。但 PowerPoint 動畫只能套用於圖表類別或圖表系列。您亦可將動畫效果套用於類別元素或系列元素。

{{% alert color="info" title="Note" %}}
閱讀更多 [**關於動畫圖表**](/slides/zh-hant/androidjava/animated-charts/)。
{{% /alert %}}

## **動畫文字**
除了對文字進行動畫外，您還可以對段落套用動畫。

{{% alert color="info" title="Note" %}}
閱讀更多 [**關於動畫文字**](/slides/zh-hant/androidjava/animated-text/)。
{{% /alert %}}

## **FAQ**

**匯出為 PDF 時，動畫會被保留嗎？**

不會。PDF 為靜態格式，故動畫與 [投影片轉場](/slides/zh-hant/androidjava/slide-transition/) 不會播放。若需要動態效果，請改為匯出至 [HTML5](/slides/zh-hant/androidjava/export-to-html5/)、[animated GIF](/slides/zh-hant/androidjava/convert-powerpoint-to-animated-gif/) 或 [video](/slides/zh-hant/androidjava/convert-powerpoint-to-video/)。

**我可以將動畫簡報轉換為影片，並控制幀率與畫面尺寸嗎？**

可以。您可以 [將簡報渲染為影格](/slides/zh-hant/androidjava/convert-powerpoint-to-video/) 並將其編碼成影片（例如使用 ffmpeg），自行選擇 FPS 與解析度。動畫與投影片轉場會在渲染過程中播放。

**在處理 ODP（不僅限 PPTX）時，動畫會保持完整嗎？**

PPT、PPTX 與 ODP 均支援[讀取](/slides/zh-hant/androidjava/open-presentation/)與[寫入](/slides/zh-hant/androidjava/save-presentation/)，但這並不保證能保留動畫。將檔案轉換為 ODP 時可能會遺失自訂動畫資料。請參閱 [Java 自訂動畫](/slides/zh-hant/java/custom-animation/) 取得範例與檢查格式相容性的指引。