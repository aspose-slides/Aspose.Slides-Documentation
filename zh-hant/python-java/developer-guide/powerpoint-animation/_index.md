---
title: 使用 Python 透過 Java 為 PowerPoint 簡報添加動畫
linktitle: PowerPoint 動畫
type: docs
weight: 150
url: /zh-hant/python-java/powerpoint-animation/
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
- Python
- Java
- Aspose.Slides
description: "探索 Aspose.Slides 於 Python 透過 Java 處理 PowerPoint 動畫的功能。此概覽概述了主要特點，並提供提升簡報的見解。"
---
## **簡介**

在建立簡報時會同時考慮視覺外觀與互動行為。

**PowerPoint 動畫** 在讓簡報吸引觀眾目光並具有互動性方面扮演重要角色。Aspose.Slides 提供廣泛的選項，以在 PowerPoint 簡報中加入動畫：

- 套用各種類型的 PowerPoint 動畫效果於形狀、圖表、表格、OLE 物件及其他簡報元素。
- 在單一形狀上使用多個 PowerPoint 動畫效果。
- 利用動畫時間軸來控制動畫效果。
- 建立自訂動畫。

在 Aspose.Slides 中，可將各種動畫效果套用於形狀。由於投影片上的每個元素（包括文字、圖片、OLE 物件與表格）皆視為形狀，因此動畫效果可套用至投影片上的任何元素。

## **動畫效果**

Aspose.Slides 支援 **150+ 個動畫效果**，包括 Bounce、PathFootball、Zoom 等基本效果，以及 OLEObjectShow、OLEObjectOpen 等特定效果。你可以在 [EffectType](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/effecttype/) 類別中找到完整清單。

此外，這些動畫效果可與下列行為結合使用：

- [ColorEffect](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/coloreffect/)
- [CommandEffect](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/commandeffect/)
- [FilterEffect](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/filtereffect/)
- [MotionEffect](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/motioneffect/)
- [PropertyEffect](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/propertyeffect/)
- [RotationEffect](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/rotationeffect/)
- [ScaleEffect](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/scaleeffect/)
- [SetEffect](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/seteffect/)

## **自訂動畫**

欲取得使用 Python 透過 Java 的完整範例，請參閱 [自訂動畫](/slides/zh-hant/python-java/custom-animation/)。

在 Aspose.Slides 中可以建立自己的 **自訂動畫**。這可以透過將多個行為組合成新的自訂動畫來實現。

[Behavior](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/behavior/) 是 PowerPoint 動畫效果的組成元素。將行為組合以自訂效果，或加入行為以擴充預定義效果。重複次數是透過時間設定配置，而非使用單獨的重複行為。

[Point](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/point/) 是應用行為的點。

## **動畫時間軸**

[Sequence](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/sequence/) 是可針對不同形狀的動畫效果集合。

[AnimationTimeLine](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/animationtimeline/) 是用於特定投影片的序列集合。它代表在 PowerPoint 2002 中引入的動畫引擎。早期的 PowerPoint 版本在為簡報新增動畫效果時相當困難且需要變通方法。時間軸提供了更清晰的物件模型來處理 PowerPoint 動畫。每張投影片只能有一個動畫時間軸。

## **互動動畫**

[EffectTriggerType](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/effecttriggertype/) 允許您定義使用者操作（例如按鈕點擊），以啟動特定動畫。

## **形狀動畫**

Aspose.Slides 允許您對形狀套用動畫，形狀可以代表文字、矩形、線條、框架、OLE 物件及其他元素。

{{% alert color="info" title="Note" %}}
閱讀更多[關於形狀動畫](/slides/zh-hant/python-java/shape-animation/)。
{{% /alert %}}

## **動畫圖表**

若要建立動畫圖表，請使用與形狀相同的類別。然而，PowerPoint 動畫只能套用於圖表的類別或系列。您也可以對類別元素或系列元素套用動畫效果。

{{% alert color="info" title="Note" %}}
閱讀更多[關於動畫圖表](/slides/zh-hant/python-java/animated-charts/)。
{{% /alert %}}

## **動畫文字**

除了動畫文字外，您還可以對段落套用動畫。

{{% alert color="info" title="Note" %}}
閱讀更多[關於動畫文字](/slides/zh-hant/python-java/animated-text/)。
{{% /alert %}}

## **常見問答**

**匯出為 PDF 時會保留動畫嗎？**

不會。PDF 為靜態格式，動畫與[投影片過場](/slides/zh-hant/python-java/slide-transition/)不會播放。若需要動態效果，請改為匯出至[HTML5](/slides/zh-hant/python-java/export-to-html5/)、[animated GIF](/slides/zh-hant/python-java/convert-powerpoint-to-animated-gif/)或[video](/slides/zh-hant/python-java/convert-powerpoint-to-video/)。

**我可以將動畫簡報轉換成影片，並控制幀率與幀大小嗎？**

可以。您可以[將簡報渲染為幀](/slides/zh-hant/python-java/convert-powerpoint-to-video/)，再使用如 ffmpeg 的工具將其編碼為影片，並自行選擇 FPS 與解析度。渲染過程中會播放動畫與投影片過場。

**在處理 ODP（不僅是 PPTX）時動畫會保持完整嗎？**

PPT、PPTX 與 ODP 均支援[讀取](/slides/zh-hant/python-java/open-presentation/)與[寫入](/slides/zh-hant/python-java/save-presentation/)，但這不保證動畫會被保留。將檔案轉換為 ODP 時，自訂動畫資料可能會遺失。請參考[自訂動畫](/slides/zh-hant/python-java/custom-animation/)以取得範例與檢查格式相容性的指引。