---
title: 透過 Java 在 Python 中增強 PowerPoint 簡報的動畫功能
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
- 圖形動畫
- 動畫圖表
- 動畫文字
- 動畫圖形
- 動畫 OLE 物件
- 動畫影像
- 動畫表格
- PowerPoint
- 簡報
- Python
- Java
- Aspose.Slides
description: "探索 Aspose.Slides for Python via Java 在處理 PowerPoint 動畫方面的功能。此概覽突顯關鍵特性，並提供深入見解以增強您的簡報。"
---
## **簡介**

在建立簡報時，同時會考慮視覺外觀與互動行為。

**PowerPoint 動畫** 在使簡報引人注目且吸引觀眾方面扮演重要角色。Aspose.Slides 提供多種選項將動畫加入 PowerPoint 簡報：

- 將各種 PowerPoint 動畫效果套用到圖形、圖表、表格、OLE 物件及其他簡報元素。
- 在單一圖形上使用多個 PowerPoint 動畫效果。
- 使用動畫時間軸來控制動畫效果。
- 建立自訂動畫。

在 Aspose.Slides 中，可將各種動畫效果套用到圖形。由於投影片上的每個元素（包括文字、圖片、OLE 物件與表格）皆視為圖形，動畫效果可套用至投影片上的任何元素。

## **動畫效果**
Aspose.Slides 支援 **150+ 動畫效果**，包括像 Bounce、PathFootball、Zoom 等基本動畫效果，以及 OLEObjectShow、OLEObjectOpen 等專門效果。您可以在 [EffectType](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/effecttype/) 列舉中找到完整的動畫效果清單。

此外，以下動畫效果可與上述列出的效果結合使用：

- [ColorEffect](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/coloreffect/)
- [CommandEffect](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/commandeffect/)
- [FilterEffect](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/filtereffect/)
- [MotionEffect](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/motioneffect/)
- [PropertyEffect](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/propertyeffect/)
- [RotationEffect](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/rotationeffect/)
- [ScaleEffect](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/scaleeffect/)
- [SetEffect](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/seteffect/)

## **自訂動畫**
在 Aspose.Slides 中可以建立您自己的 **自訂動畫**。您可以透過結合多個行為來創建新的自訂動畫。

[Behavior](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/behavior/) 是任何 PowerPoint 動畫效果的組成基礎。每個動畫效果由一組行為組合而成，形成單一策略。您可以將行為組合成自訂動畫，並在其他簡報中重複使用。將新行為加入標準 PowerPoint 動畫效果即會產生另一個自訂動畫。例如，您可以新增 repeat 行為，使動畫重複多次。

[Point](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/point/) 是應套用行為的點。

## **動畫時間軸**
[Sequence](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/sequence/) 是套用於特定圖形的動畫效果集合。

[AnimationTimeLine](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/animationtimeline/) 是在特定投影片上使用的序列集合。它代表 PowerPoint 2002 引入的動畫引擎。在較早的 PowerPoint 版本中，向簡報加入動畫效果非常困難且需使用變通方法。時間軸取代了舊的 AnimationSettings 類別，提供了更清晰的 PowerPoint 動畫物件模型。一張投影片只能擁有一個動畫時間軸。

## **互動動畫**
[EffectTriggerType](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/effecttriggertype/) 允許您定義使用者操作（例如按鈕點擊）以啟動特定動畫。觸發器僅在最新的 PowerPoint 版本中加入。

## **圖形動畫**
Aspose.Slides 允許您將動畫套用到圖形，圖形可以代表文字、矩形、線條、框架、OLE 物件及其他元素。

{{% alert color="info" title="注意" %}}
閱讀更多[關於圖形動畫](/slides/zh-hant/python-java/shape-animation/)。
{{% /alert %}}

## **動畫圖表**
若要建立動畫圖表，請使用與圖形相同的類別。但 PowerPoint 動畫僅能套用於圖表類別或圖表系列。您也可以將動畫效果套用到類別元素或系列元素。

{{% alert color="info" title="注意" %}}
閱讀更多[關於動畫圖表](/slides/zh-hant/python-java/animated-charts/)。
{{% /alert %}}

## **動畫文字**
除了為文字添加動畫之外，您還可以對段落套用動畫。

{{% alert color="info" title="注意" %}}
閱讀更多[關於動畫文字](/slides/zh-hant/python-java/animated-text/)。
{{% /alert %}}

## **常見問題**

**匯出為 PDF 時，動畫會被保留嗎？**

不會。PDF 是靜態格式，因此動畫和[投影片過渡](/slides/zh-hant/python-java/slide-transition/)不會播放。如果需要動態效果，請改為匯出至[HTML5](/slides/zh-hant/python-java/export-to-html5/)、[動畫 GIF](/slides/zh-hant/python-java/convert-powerpoint-to-animated-gif/)或[影片](/slides/zh-hant/python-java/convert-powerpoint-to-video/)。

**我可以將動畫簡報轉換為影片，並控制影格速率與尺寸嗎？**

可以。您可以[將簡報渲染為影格](/slides/zh-hant/python-java/convert-powerpoint-to-video/)，然後將其編碼成影片（例如使用 ffmpeg），自行選擇 FPS 與解析度。渲染過程中會播放動畫與投影片過渡。

**在處理 ODP（不僅是 PPTX）時，動畫會保持完整嗎？**

支援對 PPT、PPTX 和 ODP 進行[讀取](/slides/zh-hant/python-java/open-presentation/)以及[寫入](/slides/zh-hant/python-java/save-presentation/)，但格式差異可能導致某些效果在外觀或行為上略有不同。請使用真實樣本驗證關鍵情況。