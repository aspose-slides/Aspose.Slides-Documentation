---
title: 在 JavaScript 中使用動畫增強 PowerPoint 簡報
linktitle: PowerPoint 動畫
type: docs
weight: 150
url: /zh-hant/nodejs-java/powerpoint-animation/
keywords:
- 新增動畫
- 更新動畫
- 更改動畫
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
- Node.js
- JavaScript
- Aspose.Slides
description: "使用 Aspose.Slides for Node.js via Java 來處理 PowerPoint 動畫。本概述突顯主要功能並提供提升簡報的見解。"
---
## **簡介**

由於簡報旨在呈現內容，其視覺外觀和互動行為在建立過程中始終會被考慮。

**PowerPoint 動畫** 在使簡報更具吸引力和引人入勝方面扮演重要角色。Aspose.Slides for Node.js via Java 提供了廣泛的選項，可將動畫添加至 PowerPoint 簡報：

- 將各種 PowerPoint 動畫效果套用至形狀、圖表、表格、OLE 物件及其他簡報元素。
- 在單一形狀上使用多個 PowerPoint 動畫效果。
- 利用動畫時間軸來控制動畫效果。
- 建立自訂動畫。

在 Aspose.Slides for Node.js via Java 中，可將各種動畫效果套用至形狀。由於投影片上的每個元素，包括文字、圖片、OLE 物件和表格，都被視為形狀，因此動畫效果可套用至投影片上的任何元素。

## **動畫效果**
Aspose.Slides 支援 **150+ 個動畫效果**，包括基本效果如 Bounce、PathFootball 和 Zoom，以及特定效果如 OLEObjectShow 和 OLEObjectOpen。您可以在 [EffectType](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/effecttype/) 列舉中找到完整清單。

此外，這些動畫效果可與以下行為結合使用：

- [ColorEffect](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/ColorEffect)
- [CommandEffect](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/CommandEffect)
- [FilterEffect](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/FilterEffect)
- [MotionEffect](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/MotionEffect)
- [PropertyEffect](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/PropertyEffect)
- [RotationEffect](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/RotationEffect)
- [ScaleEffect](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/ScaleEffect)
- [SetEffect](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/SetEffect)

## **自訂動畫**
欲取得完整的 JavaScript 範例（建立、檢查和修改行為與可編輯的移動路徑），請參閱 [Custom Animation](/slides/zh-hant/nodejs-java/custom-animation/)。

在 Aspose.Slides 中可以建立自己的 **自訂動畫**。透過將多個行為組合為新的自訂動畫即可實現此目的。

[Behavior](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/behavior/) 是 PowerPoint 動畫效果的組成單位。結合多個行為以自訂效果，或新增行為以擴充預定義的效果。重複次數是透過時間設定來配置，而非使用單獨的重複行為。

[Animation Point](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/point/) 是應用行為的點。

## **動畫時間軸**
[Sequence](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/sequence/) 是可針對不同形狀的動畫效果集合。

[Timeline](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/animationtimeline/) 是在特定投影片中使用的序列集合。它是 PowerPoint 2002 引入的動畫引擎。在較早的 PowerPoint 版本中，向簡報添加動畫效果相當困難，且只能透過各種變通方法實現。時間軸為 PowerPoint 動畫提供了更清晰的物件模型。每張投影片只能有一個動畫時間軸。

## **互動動畫**
[Trigger](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/effecttriggertype/) 允許您定義使用者操作（例如按鈕點擊），以啟動特定動畫。

## **形狀動畫**
Aspose.Slides 允許您對形狀套用動畫，形狀可包括文字、矩形、線條、框架、OLE 物件等。

{{% alert color="info" title="Note" %}}
閱讀更多 [**關於形狀動畫**](/slides/zh-hant/nodejs-java/shape-animation/)。
{{% /alert %}}

## **動畫圖表**
若要建立動畫圖表，應使用與形狀相同的類別。然而，PowerPoint 動畫只能套用至圖表類別或圖表系列。您也可以將動畫效果套用至類別元素或系列元素。

{{% alert color="info" title="Note" %}}
閱讀更多 [**關於動畫圖表**](/slides/zh-hant/nodejs-java/animated-charts/)。
{{% /alert %}}

## **動畫文字**
除了對文字進行動畫化，您也可以對段落套用動畫。

{{% alert color="info" title="Note" %}}
閱讀更多 [**關於動畫文字**](/slides/zh-hant/nodejs-java/animated-text/)。
{{% /alert %}}

## **常見問題**

**匯出為 PDF 時，動畫會保留嗎？**

不會。PDF 是靜態格式，因此動畫和[投影片過場](/slides/zh-hant/nodejs-java/slide-transition/)不會播放。如果需要動態效果，請改為匯出為[HTML5](/slides/zh-hant/nodejs-java/export-to-html5/)、[animated GIF](/slides/zh-hant/nodejs-java/convert-powerpoint-to-animated-gif/)或[video](/slides/zh-hant/nodejs-java/convert-powerpoint-to-video/)。

**我可以將動畫簡報轉換為影片，並控制幀率和幀大小嗎？**

可以。您可以[將簡報渲染為影格](/slides/zh-hant/nodejs-java/convert-powerpoint-to-video/)並將其編碼為影片（例如使用 ffmpeg），自行選擇 FPS 與解析度。動畫與投影片過場會在渲染過程中播放。

**在使用 ODP（不僅限於 PPTX）時，動畫會保持完整嗎？**

PPT、PPTX 與 ODP 均支援[讀取](/slides/zh-hant/nodejs-java/open-presentation/)與[寫入](/slides/zh-hant/nodejs-java/save-presentation/)，但這並不保證動畫的保留。將檔案轉換為 ODP 時可能會遺失自訂動畫資料。請參閱[Custom Animation](/slides/zh-hant/nodejs-java/custom-animation/)取得範例與檢查格式相容性的指南。