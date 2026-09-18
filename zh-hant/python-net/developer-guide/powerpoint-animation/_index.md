---
title: 在 Python 中使用動畫增強 PowerPoint 簡報
linktitle: PowerPoint 動畫
type: docs
weight: 150
url: /zh-hant/python-net/powerpoint-animation/
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
- PowerPoint 簡報
- Python
- Aspose.Slides
description: "探索 Aspose.Slides for Python via .NET 處理 PowerPoint 動畫的功能。本概覽概述了主要特點，並提供洞見以增強您的簡報。"
---
## **簡介**

簡報的設計目的是傳遞資訊，因此在建立過程中視覺外觀與互動行為是重要考量。

**PowerPoint 動畫** 在使簡報吸引觀眾目光並提升互動性方面扮演關鍵角色。Aspose.Slides for Python via .NET 提供廣泛的選項，讓您為 PowerPoint 簡報加入動畫。您可以：

- 為形狀、圖表、表格、OLE 物件以及其他元素套用各種動畫效果。
- 在同一個形狀上使用多個動畫效果。
- 透過動畫時間軸控制效果。
- 建立自訂動畫。

在 Aspose.Slides for Python via .NET 中，動畫效果可以套用於形狀。因為投影片上的每個元素──文字、圖片、OLE 物件與表格──皆視為形狀，所以您可以對投影片上的任何元素套用動畫效果。

[aspose.slides.animation](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.animation/) 名稱空間提供用於處理 PowerPoint 動畫的類別。

## **安裝**

```bash
pip install aspose.slides
```

## **在 Python 中為形狀加入動畫效果**

動畫效果位於投影片的主序列上。先加入形狀，然後在 `slide.timeline.main_sequence` 上呼叫 `add_effect`，傳入效果類型、子類型以及觸發方式。

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

儲存的檔案在第一張投影片上包含一個效果：矩形從左側飛入，持續兩秒，當簡報者點擊時啟動。重新開啟並讀取 `slide.timeline.main_sequence` 會返回該效果，表示動畫在往返過程中仍然存在，而不是僅存在於記憶體中。

## **動畫效果**

Aspose.Slides 支援 **150 多種動畫效果**，包括 Bounce、PathFootball、Zoom 等基本效果，以及 OLEObjectShow、OLEObjectOpen 等專屬效果。完整清單可在 [EffectType](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.animation/effecttype/) 列舉中取得。

此外，這些動畫效果還可以與以下效果結合使用：

- [ColorEffect](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.animation/coloreffect/)
- [CommandEffect](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.animation/commandeffect/)
- [FilterEffect](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.animation/filtereffect/)
- [MotionEffect](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.animation/motioneffect/)
- [PropertyEffect](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.animation/propertyeffect/)
- [RotationEffect](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.animation/rotationeffect)
- [ScaleEffect](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.animation/scaleeffect/)
- [SetEffect](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.animation/seteffect/)

## **自訂動畫**

欲取得完整的 Python 範例（建立、檢查與修改行為與可編輯的運動路徑），請參閱 [Custom Animation](/slides/zh-hant/python-net/custom-animation/)。

您可以透過將多個行為組合成單一效果，於 Aspose.Slides 中建立 **自訂動畫**。

[Behavior](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.animation/behavior/) 是 PowerPoint 動畫效果的組成單元。將行為組合以自訂效果，或加入行為以擴充預定義效果。重複次數透過時間設定來配置，而非使用獨立的重複行為。

[Animation Point](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.animation/point/) 標示行為套用的時刻或位置（關鍵影格）。

## **動畫時間軸**

[Sequence](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.animation/sequence/) 是可針對不同形狀的動畫效果集合。

[Timeline](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.animation/animationtimeline/) 是特定投影片上使用的序列集合。此概念於 PowerPoint 2002 引入。早期 PowerPoint 中，加入動畫效果相當困難且常需變通方案。Timeline 取代了舊的 `AnimationSettings` 類別，提供更清晰的 PowerPoint 動畫物件模型。每張投影片只能擁有一個動畫時間軸。

## **互動式動畫**

[Trigger](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.animation/effecttriggertype/) 允許您定義使用者動作（例如按鈕點擊）以啟動特定動畫。觸發器僅在最新版本的 PowerPoint 中加入。

## **形狀動畫**

Aspose.Slides 允許您為形狀（如文字、矩形、線條、框架、OLE 物件等）套用動畫。

{{% alert color="info" title="Note" %}}

閱讀更多 [**關於形狀動畫**](/slides/zh-hant/python-net/shape-animation/).

{{% /alert %}}

## **動畫圖表**

若要建立動畫圖表，使用與形狀相同的類別。然而，PowerPoint 動畫只能套用於圖表類別或圖表系列。您亦可將動畫效果套用於單一類別元素或系列元素。

{{% alert color="info" title="Note" %}}

閱讀更多 [**關於動畫圖表**](/slides/zh-hant/python-net/animated-charts/).

{{% /alert %}}

## **動畫文字**

除了為文字加入動畫外，您還可以為段落套用動畫。

{{% alert color="info" title="Note" %}}

閱讀更多 [**關於動畫文字**](/slides/zh-hant/python-net/animated-text/).

{{% /alert %}}

## **FAQ**

**匯出為 PDF 時動畫會被保留嗎？**

不會。PDF 為靜態格式，動畫與[投影片轉場](/slides/zh-hant/python-net/slide-transition/)不會播放。如需動態效果，請匯出為[HTML5](/slides/zh-hant/python-net/export-to-html5/)、[動畫 GIF](/slides/zh-hant/python-net/convert-powerpoint-to-animated-gif/)或[影片](/slides/zh-hant/python-net/convert-powerpoint-to-video/)。

**我可以將動畫簡報轉為影片，並控制影格速率與尺寸嗎？**

可以。您可以[將簡報渲染為影格](/slides/zh-hant/python-net/convert-powerpoint-to-video/)，再透過 ffmpeg 等工具編碼成影片，自行選擇 FPS 與解析度。渲染過程中會播放動畫與投影片轉場。

**在處理 ODP（不僅是 PPTX）時動畫會保持完整嗎？**

PPT、PPTX 與 ODP 均支援[讀取](/slides/zh-hant/python-net/open-presentation/)與[寫入](/slides/zh-hant/python-net/save-presentation/)，但不保證動畫完整保留。轉換為 ODP 時可能遺失自訂動畫資料。請參閱[自訂動畫](/slides/zh-hant/python-net/custom-animation/)以取得範例與檢查格式相容性的指引。