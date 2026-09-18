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
- PHP
- Aspose.Slides
description: "探索 Aspose.Slides for PHP via Java 在處理 PowerPoint 動畫方面的功能。關鍵特性與見解，助您提升簡報品質。"
---
## **簡介**

由於簡報旨在呈現資訊，因此在建立過程中會同時考量其視覺外觀與互動行為。

**PowerPoint 動畫** 在使簡報吸引觀眾目光並提升互動性方面扮演重要角色。Aspose.Slides for PHP via Java 提供多種方式將動畫加入 PowerPoint 簡報：

- 對形狀、圖表、表格、OLE 物件及其他簡報元件套用各種 PowerPoint 動畫效果。
- 在單一形狀上使用多個 PowerPoint 動畫效果。
- 使用動畫時間軸來控制動畫效果。
- 建立自訂動畫。

在 Aspose.Slides for PHP via Java 中，動畫效果可套用於形狀。由於投影片上的每個元素（包括文字、圖片、OLE 物件與表格）皆視為形狀，動畫效果可套用於投影片上的任何元素。

## **動畫效果**
Aspose.Slides 支援 **150 多種動畫效果**，包括 Bounce、PathFootball、Zoom 等基本效果，以及 OLEObjectShow、OLEObjectOpen 等特定效果。完整列表請參考 [EffectType](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/effecttype/) 類別。

此外，這些動畫效果還能與以下行為結合使用：

- [ColorEffect](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/ColorEffect)
- [CommandEffect](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/CommandEffect)
- [FilterEffect](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/FilterEffect)
- [MotionEffect](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/MotionEffect)
- [PropertyEffect](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/PropertyEffect)
- [RotationEffect](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/RotationEffect)
- [ScaleEffect](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/ScaleEffect)
- [SetEffect](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/SetEffect)

## **自訂動畫**

欲取得建立、檢查與修改行為及可編輯移動路徑的完整 PHP 範例，請參閱 [Custom Animation](/slides/zh-hant/php-java/custom-animation/)。

在 Aspose.Slides 中可以建立您自己的 **自訂動畫**。這可透過將多個行為組合成新的自訂動畫來實現。

[Behavior](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/behavior/) 是 PowerPoint 動畫效果的組成單元。結合行為即可自訂效果，或加入行為以擴充預定義效果。重複次數透過計時設定來配置，而非使用單獨的重複行為。

[Animation Point](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/point/) 是應用行為的定位點。

## **動畫時間軸**
[Sequence](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/sequence/) 是一組可針對不同形狀的動畫效果。

[Timeline](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/animationtimeline/) 是在特定投影片中使用的序列集合。它是 PowerPoint 2002 引入的動畫引擎。於較早期的 PowerPoint 中，為簡報加入動畫效果相當困難，且只能透過各種變通方式實現。時間軸提供了更清晰的物件模型。一張投影片只能擁有一個動畫時間軸。

## **互動動畫**
[Trigger](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/effecttriggertype/) 允許您定義使用者動作（例如按鈕點擊），以啟動特定動畫。

## **形狀動畫**
Aspose.Slides 允許您對形狀套用動畫，形狀可包括文字、矩形、線條、框架、OLE 物件等。

{{% alert color="info" title="Note" %}}
閱讀更多 [**關於形狀動畫**](/slides/zh-hant/php-java/shape-animation/)。
{{% /alert %}}

## **動畫圖表**
若要建立動畫圖表，應使用與形狀相同的類別。但 PowerPoint 動畫只能套用於圖表類別或圖表系列。您也可以將動畫效果套用於單一類別元素或系列元素。

{{% alert color="info" title="Note" %}}
閱讀更多 [**關於動畫圖表**](/slides/zh-hant/php-java/animated-charts/)。
{{% /alert %}}

## **動畫文字**
除了對文字本身做動畫之外，您還可以對段落套用動畫。

{{% alert color="info" title="Note" %}}
閱讀更多 [**關於動畫文字**](/slides/zh-hant/php-java/animated-text/)。
{{% /alert %}}

## **常見問題**

**將動畫匯出為 PDF 時會被保留嗎？**

不會。PDF 為靜態格式，故不會播放動畫與 [slide transitions](/slides/zh-hant/php-java/slide-transition/)。如需動態效果，請改匯出為 [HTML5](/slides/zh-hant/php-java/export-to-html5/)、[animated GIF](/slides/zh-hant/php-java/convert-powerpoint-to-animated-gif/) 或 [video](/slides/zh-hant/php-java/convert-powerpoint-to-video/)。

**我可以將動畫簡報轉成影片，並控制幀率與畫面大小嗎？**

可以。您可以 [render the presentation as frames](/slides/zh-hant/php-java/convert-powerpoint-to-video/)，再使用 ffmpeg 等工具編碼為影片，自行設定 FPS 與解析度。渲染過程中會播放動畫與投影片轉場。

**在處理 ODP（不只是 PPTX）時動畫會保持完整嗎？**

PPT、PPTX 與 ODP 均支援[讀取](/slides/zh-hant/php-java/open-presentation/)與[寫入](/slides/zh-hant/php-java/save-presentation/)，但這並不保證動畫一定會被保留。將檔案轉為 ODP 時可能會遺失自訂動畫資料。請參考 [Custom Animation](/slides/zh-hant/php-java/custom-animation/) 以取得範例與檢查格式相容性的指引。