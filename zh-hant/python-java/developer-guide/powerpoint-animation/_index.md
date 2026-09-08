---
title: 使用 Python (via Java) 增強 PowerPoint 簡報的動畫
linktitle: PowerPoint 動畫
type: docs
weight: 150
url: /zh-hant/python-java/powerpoint-animation/
keywords:
- 添加動畫
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
description: "探索 Aspose.Slides for Python via Java 處理 PowerPoint 動畫的功能。本概述闡述主要特性，並提供提升簡報的見解。"
---
## **簡介**

由於簡報旨在展示內容，在建立過程中始終會考慮其視覺外觀與互動行為。

**PowerPoint 動畫** 在讓簡報吸引觀眾目光並提升互動性方面扮演重要角色。Aspose.Slides 提供多種選項，以在 PowerPoint 簡報中加入動畫：

- 套用各種 PowerPoint 動畫效果於形狀、圖表、表格、OLE 物件及其他簡報元素。
- 在單一形狀上使用多個 PowerPoint 動畫效果。
- 使用動畫時間軸控制動畫效果。
- 建立自訂動畫。

在 Aspose.Slides 中，各種動畫效果可套用於形狀。由於投影片上的每個元素，包括文字、圖片、OLE 物件和表格，都被視為形狀，因此動畫效果可套用於投影片上的任何元素。

## **動畫效果**

Aspose.Slides 支援 **150+ 動畫效果**，包括基本動畫效果如 Bounce、PathFootball、Zoom 效果，以及特定動畫效果如 OLEObjectShow、OLEObjectOpen。您可以在[EffectType](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/effecttype/) 列舉中找到完整的動畫效果清單。

此外，這些動畫效果還可以與以下效果結合使用：

- [ColorEffect](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/coloreffect/)
- [CommandEffect](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/commandeffect/)
- [FilterEffect](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/filtereffect/)
- [MotionEffect](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/motioneffect/)
- [PropertyEffect](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/propertyeffect/)
- [RotationEffect](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/rotationeffect/)
- [ScaleEffect](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/scaleeffect/)
- [SetEffect](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/seteffect/)

## **自訂動畫**

在 Aspose.Slides 中可以建立自己的 **自訂動畫**。只要將多個行為組合成新的自訂動畫，即可達成此目的。

[Behavior](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/behavior/) 是任何 PowerPoint 動畫效果的組成單元。所有動畫效果實際上是一組行為組成的策略。您可以將行為組合成一次的自訂動畫，之後在其他簡報中重複使用。若在標準 PowerPoint 動畫效果中加入新的行為，即會產生另一個自訂動畫。例如，您可以為動畫加入重複行為，使其重複播放數次。

[Point](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/point/) 是應用行為的點。

## **動畫時間軸**

[Sequence](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/sequence/) 是套用於特定形狀的動畫效果集合。

[AnimationTimeLine](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/animationtimeline/) 是在特定投影片中使用的 Sequence 集合。自 PowerPoint 2002 起即作為動畫引擎實作。先前的 PowerPoint 版本在加入動畫效果時相當困難，僅能透過各種變通方法完成。時間軸取代了舊的 AnimationSettings 類別，提供更清晰的 PowerPoint 動畫物件模型。一張投影片只能有一個動畫時間軸。

## **互動動畫**

[EffectTriggerType](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/effecttriggertype/) 允許定義使用者動作（例如按鈕點擊），以啟動特定動畫。觸發器僅在最新的 PowerPoint 版本中加入。

## **形狀動畫**

Aspose.Slides 允許對形狀套用動畫，而形狀實際上可以是文字、矩形、線條、框架、OLE 物件等。

{{% alert color="info" title="Note" %}} 
閱讀更多 [關於形狀動畫](/slides/zh-hant/python-java/shape-animation/).
{{% /alert %}}

## **動畫圖表**

若要建立動畫圖表，應使用與形狀相同的類別。然而，PowerPoint 動畫只能套用於圖表類別或系列。您也可以對類別元素或系列元素套用動畫效果。

{{% alert color="info" title="Note" %}} 
閱讀更多 [關於動畫圖表](/slides/zh-hant/python-java/animated-charts/).
{{% /alert %}}

## **動畫文字**

除了動畫文字之外，也可以對段落套用動畫。

{{% alert color="info" title="Note" %}} 
閱讀更多 [關於動畫文字](/slides/zh-hant/python-java/animated-text/).
{{% /alert %}}

## **常見問題**

**匯出為 PDF 時，動畫會被保留嗎？**

不會。PDF 為靜態格式，動畫及[投影片轉場](/slides/zh-hant/python-java/slide-transition/)不會播放。如需動態效果，請改為匯出至[HTML5](/slides/zh-hant/python-java/export-to-html5/)、[animated GIF](/slides/zh-hant/python-java/convert-powerpoint-to-animated-gif/)或[影片](/slides/zh-hant/python-java/convert-powerpoint-to-video/)。

**我可以將動畫簡報轉換為影片，並控制幀率與幀大小嗎？**

可以。您可以[將簡報渲染為幀](/slides/zh-hant/python-java/convert-powerpoint-to-video/)並以影片格式編碼（例如使用 ffmpeg），自行選擇 FPS 與解析度。動畫和投影片轉場會在渲染時播放。

**在使用 ODP（而非僅 PPTX）時，動畫會保持完整嗎？**

PPT、PPTX 與 ODP 均支援[讀取](/slides/zh-hant/python-java/open-presentation/)與[寫入](/slides/zh-hant/python-java/save-presentation/)，但格式差異可能導致某些效果的外觀或行為略有不同。請以真實樣本驗證關鍵情況。