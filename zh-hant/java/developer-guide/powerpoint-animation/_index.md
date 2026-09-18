---
title: 在 Java 中使用動畫強化 PowerPoint 簡報
linktitle: PowerPoint 動畫
type: docs
weight: 150
url: /zh-hant/java/powerpoint-animation/
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
- 圖形動畫
- 動畫圖表
- 動畫文字
- 動畫圖形
- 動畫 OLE 物件
- 動畫影像
- 動畫表格
- PowerPoint
- 簡報
- Java
- Aspose.Slides
description: "探索 Aspose.Slides for Java 在處理 PowerPoint 動畫方面的功能。此概覽概述了主要特點，並提供增強簡報的見解。"
---
## **簡介**

由於簡報的目的是呈現內容，在創建過程中始終會考慮其視覺外觀和互動行為。

**PowerPoint 動畫** 在使簡報引人注目、吸引觀眾方面扮演重要角色。Aspose.Slides 提供了多種方式為 PowerPoint 簡報加入動畫：

- 對形狀、圖表、表格、OLE 物件及其他簡報元素套用各種 PowerPoint 動畫效果。
- 在單一形狀上使用多個 PowerPoint 動畫效果。
- 利用動畫時間軸控制動畫效果。
- 建立自訂動畫。

在 Aspose.Slides 中，可對形狀套用各種動畫效果。由於投影片上的每個元素（包括文字、圖片、OLE 物件與表格）皆視為形狀，動畫效果可套用於投影片上的任何元素。

## **動畫效果**
Aspose.Slides 支援 **150+ 動畫效果**，包含基本效果如 Bounce、PathFootball、Zoom，以及特定效果如 OLEObjectShow、OLEObjectOpen。完整清單可參考 [EffectType](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/effecttype/) 類別。

此外，這些動畫效果還能與下列行為結合使用：

- [ColorEffect](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ColorEffect)
- [CommandEffect](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/CommandEffect)
- [FilterEffect](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/FilterEffect)
- [MotionEffect](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/MotionEffect)
- [PropertyEffect](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/PropertyEffect)
- [RotationEffect](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/RotationEffect)
- [ScaleEffect](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ScaleEffect)
- [SetEffect](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/SetEffect)

## **自訂動畫**

如需完整的 Java 範例以建立、檢查和修改行為與可編輯的動作路徑，請參閱 [自訂動畫](/slides/zh-hant/java/custom-animation/)。

在 Aspose.Slides 中可以自行建立 **自訂動畫**。這可以透過將多個行為組合成新的自訂動畫來實現。

[Behavior](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/behavior/) 是 PowerPoint 動畫效果的構件。組合行為即可自訂效果，或加入行為以擴充預設效果。重複次數透過時間設定調整，而非獨立的 repeat 行為。

[Animation Point](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/point/) 是應用行為的點位。

## **動畫時間軸**
[Sequence](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/sequence/) 是可針對不同形狀的動畫效果集合。

[Timeline](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/animationtimeline/) 是在特定投影片中使用的序列集合。它是 PowerPoint 2002 引入的動畫引擎。早期版本的 PowerPoint 在為簡報加入動畫效果時相當困難，且只能透過各種變通方式實現。時間軸為 PowerPoint 動畫提供了更清晰的物件模型。每張投影片只能有一個動畫時間軸。

## **互動式動畫**
[Trigger](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/effecttriggertype/) 允許您定義使用者操作（例如按鈕點擊），以啟動特定動畫。

## **圖形動畫**
Aspose.Slides 允許您對形狀套用動畫，形狀可以是文字、矩形、線條、框架、OLE 物件等。

{{% alert color="info" title="Note" %}}
閱讀更多 [**關於圖形動畫**](/slides/zh-hant/java/shape-animation/)。
{{% /alert %}}

## **動畫圖表**
若要建立動畫圖表，您應使用與形狀相同的類別。但是，PowerPoint 動畫只能套用於圖表類別或圖表系列。您也可以對類別元素或系列元素套用動畫效果。

{{% alert color="info" title="Note" %}}
閱讀更多 [**關於動畫圖表**](/slides/zh-hant/java/animated-charts/)。
{{% /alert %}}

## **動畫文字**
除了為文字加入動畫外，還可以為段落套用動畫。

{{% alert color="info" title="Note" %}}
閱讀更多 [**關於動畫文字**](/slides/zh-hant/java/animated-text/)。
{{% /alert %}}

## **常見問題**

**將簡報匯出為 PDF 時會保留動畫嗎？**

不會。PDF 為靜態格式，動畫與 [slide transitions](/slides/zh-hant/java/slide-transition/) 不會播放。如果需要動態效果，請改為匯出為 [HTML5](/slides/zh-hant/java/export-to-html5/)、[animated GIF](/slides/zh-hant/java/convert-powerpoint-to-animated-gif/) 或 [video](/slides/zh-hant/java/convert-powerpoint-to-video/)。

**我可以將動畫簡報轉成影片，並控制幀率與幀大小嗎？**

可以。您可以 [render the presentation as frames](/slides/zh-hant/java/convert-powerpoint-to-video/) 並使用 ffmpeg 等工具將幀編碼成影片，自行選擇 FPS 與解析度。渲染過程中會播放動畫與投影片過渡。

**使用 ODP（而非 PPTX）時動畫會保持完整嗎？**

PPT、PPTX 與 ODP 均支援 [reading](/slides/zh-hant/java/open-presentation/) 與 [writing](/slides/zh-hant/java/save-presentation/)，但這並不保證動畫會被保留。將檔案轉為 ODP 時，可能會遺失自訂動畫資料。請參閱 [自訂動畫](/slides/zh-hant/java/custom-animation/) 了解範例與檢查格式相容性的指引。