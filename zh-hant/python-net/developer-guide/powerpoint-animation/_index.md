---
title: 加強 Python 中的 PowerPoint 簡報動畫
linktitle: PowerPoint 動畫
type: docs
weight: 150
url: /zh-hant/python-net/powerpoint-animation/
keywords:
- 添加動畫
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
- 圖形動畫
- 動畫圖表
- 動畫文字
- 動畫圖形
- 動畫 OLE 物件
- 動畫影像
- 動畫表格
- PowerPoint 簡報
- Python
- Aspose.Slides
description: "探索 Aspose.Slides for Python via .NET 在處理 PowerPoint 動畫方面的功能。此概覽著重於關鍵特性，並提供提升簡報的見解。"
---
## **簡介**

簡報的設計目的是傳遞資訊，因此在製作過程中，視覺外觀與互動行為是重要的考量因素。

**PowerPoint 動畫** 在使簡報吸引觀眾、提升參與度方面扮演重要角色。Aspose.Slides for Python via .NET 提供多種選項來為 PowerPoint 簡報加入動畫。您可以：

- 將各種動畫效果套用於圖形、圖表、表格、OLE 物件及其他元素。
- 在單一圖形上使用多個動畫效果。
- 透過動畫時間軸控制效果。
- 建立自訂動畫。

在 Aspose.Slides for Python via .NET 中，動畫效果可套用於圖形。由於投影片上的每個元素──包括文字、圖片、OLE 物件和表格──皆被視為圖形，因此您可以對投影片上的任何元素套用動畫效果。

The [aspose.slides.animation](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.animation/) 命名空間提供用於操作 PowerPoint 動畫的類別。

## **安裝**

```bash
pip install aspose.slides
```

## **在 Python 中為圖形新增動畫效果**

動畫效果存在於投影片的主要序列中。先新增一個圖形，然後在 `slide.timeline.main_sequence` 上呼叫 `add_effect`，傳入效果類型、子類型以及觸發此效果的觸發條件。

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 150, 300, 100)
    shape.text_frame.text = "Animated shape"

    sequence = slide.timeline.main_sequence
    effect = sequence.add_effect(
        shape,
        slides.animation.EffectType.FLY,
        slides.animation.EffectSubtype.LEFT,
        slides.animation.EffectTriggerType.ON_CLICK,
    )
    effect.timing.duration = 2.0

    presentation.save("animated.pptx", slides.export.SaveFormat.PPTX)
```

保存的檔案在第一張投影片上包含一個效果：當簡報者點擊時，矩形會從左側飛入，持續兩秒。重新開啟檔案並讀取 `slide.timeline.main_sequence` 時會返回該效果，表示動畫會在往返過程中保留下來，而不僅僅存在於記憶體中。

## **動畫效果**

Aspose.Slides 支援 **150 多種動畫效果**，包括 Bounce、PathFootball、Zoom 等基本效果，以及 OLEObjectShow、OLEObjectOpen 等特殊效果。完整清單可在 [EffectType](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.animation/effecttype/) 列舉中找到。

此外，這些動畫效果還可以與以下效果結合使用：

- [顏色效果](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.animation/coloreffect/)
- [指令效果](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.animation/commandeffect/)
- [濾鏡效果](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.animation/filtereffect/)
- [動作效果](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.animation/motioneffect/)
- [屬性效果](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.animation/propertyeffect/)
- [旋轉效果](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.animation/rotationeffect)
- [縮放效果](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.animation/scaleeffect/)
- [設定效果](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.animation/seteffect/)

## **自訂動畫**

您可以在 Aspose.Slides 中透過將多個行為組合成單一效果，建立自己的 **自訂動畫**。

[行為](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.animation/behavior/) 是任何 PowerPoint 動畫效果的基本構件。每個動畫效果本質上是一組行為，排列成一個策略或時間軸。您可以一次組合行為成自訂動畫，並在其他簡報中重複使用。若對標準 PowerPoint 動畫效果新增行為，即會成為自訂動畫──例如，加入重複行為使動畫播放多次。

[動畫點](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.animation/point/) 標示套用行為的時間或位置（關鍵影格）。

## **動畫時間軸**

[序列](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.animation/sequence/) 是套用於特定圖形的動畫效果集合。

[時間軸](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.animation/animationtimeline/) 是在特定投影片上使用的序列集合。它於 PowerPoint 2002 引入。在較早的 PowerPoint 版本中，新增動畫效果相當困難且常需變通方法。時間軸取代了舊的 `AnimationSettings` 類別，提供更清晰的 PowerPoint 動畫物件模型。每張投影片只能有一個動畫時間軸。

## **互動動畫**

[觸發條件](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.animation/effecttriggertype/) 讓您定義使用者動作（例如按鈕點擊）以啟動特定動畫。觸發條件僅在最新版本的 PowerPoint 中加入。

## **圖形動畫**

Aspose.Slides 允許您對圖形套用動畫，例如文字、矩形、線條、框架、OLE 物件等。

{{% alert color="primary" %}}
Read more [**關於圖形動畫**](/slides/zh-hant/python-net/shape-animation/)
{{% /alert %}}

## **動畫圖表**

若要建立動畫圖表，可使用與圖形相同的類別。然而，PowerPoint 動畫只能套用於圖表類別或圖表系列，亦可對單一類別元素或系列元素套用動畫效果。

{{% alert color="primary" %}}
Read more [**關於動畫圖表**](/slides/zh-hant/python-net/animated-charts/)
{{% /alert %}}

## **動畫文字**

除了動畫文字之外，您還可以對段落套用動畫。

{{% alert color="primary" %}}
Read more [**關於動畫文字**](/slides/zh-hant/python-net/animated-text/)
{{% /alert %}}

## **常見問題**

### 匯出為 PDF 時動畫會被保留嗎？

不會。PDF 為靜態格式，動畫與[投影片切換](/slides/zh-hant/python-net/slide-transition/)不會播放。如需動態效果，請改為匯出為[HTML5](/slides/zh-hant/python-net/export-to-html5/)、[動畫 GIF](/slides/zh-hant/python-net/convert-powerpoint-to-animated-gif/)或[影片](/slides/zh-hant/python-net/convert-powerpoint-to-video/)。

### 我可以將動畫簡報轉成影片，並控制幀率與幀大小嗎？

可以。您可以[將簡報渲染為幀](/slides/zh-hant/python-net/convert-powerpoint-to-video/)，再以影片編碼器（例如 ffmpeg）將其編碼為影片，並自行選擇 FPS 與解析度。動畫與投影片切換會在渲染時播放。

### 在使用 ODP（不僅限於 PPTX）時，動畫會保持完整嗎？

PPT、PPTX 與 ODP 均支援[讀取](/slides/zh-hant/python-net/open-presentation/)與[寫入](/slides/zh-hant/python-net/save-presentation/)，但格式差異可能導致某些效果的外觀或行為略有不同。請以實際樣本驗證關鍵案例。