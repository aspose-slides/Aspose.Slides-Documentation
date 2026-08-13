---
title: 在 C++ 中使用動畫增強 PowerPoint 簡報
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
- 互動動畫
- 自訂動畫
- 形狀動畫
- 圖表動畫
- 文字動畫
- 動畫形狀
- 動畫 OLE 物件
- 動畫圖像
- 動畫表格
- PowerPoint
- 簡報
- C++
- Aspose.Slides
description: "了解如何在 Aspose.Slides for C++ 中加入與控制進階動畫效果，以建立動態的 PowerPoint 與 OpenDocument 簡報。"
---
## **簡介**

由於簡報的目的在於呈現資訊，製作時總會考慮其視覺外觀與互動行為。

**PowerPoint 動畫** 在讓簡報更吸睛、具吸引力方面扮演重要角色。Aspose.Slides for C++ 提供多種方式將動畫加入 PowerPoint 簡報：

- 為形狀、圖表、表格、OLE 物件及其他簡報元素套用各種 PowerPoint 動畫效果。
- 在同一形狀上使用多個 PowerPoint 動畫效果。
- 使用動畫時間軸控制動畫效果。
- 建立自訂動畫。

在 Aspose.Slides for C++ 中，可對形狀套用各種動畫效果。因投影片上的每個元素（文字、圖片、OLE 物件、表格等）皆視為形狀，意味著可以對投影片上的任何元素套用動畫效果。

[**Aspose.Slides.Animation**](https://reference.aspose.com/slides/zh-hant/cpp/namespace/aspose.slides.animation) **名稱空間** 提供處理 PowerPoint 動畫的類別。
## **動畫效果**
Aspose.Slides 支援 **150+ 動畫效果**，包含基本效果如 Bounce、PathFootball、Zoom，及特定效果如 OLEObjectShow、OLEObjectOpen。完整的效果清單可參考 [**EffectType**](https://reference.aspose.com/slides/zh-hant/cpp/namespace/aspose.slides.animation#ae0da11508d382465aa4e7a011df1bf31) 列舉。

此外，這些動畫效果可與下列類別結合使用：

- [ColorEffect](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.animation/coloreffect/)
- [CommandEffect](https://reference.aspose.com/slides/zh-hant/cpp/class/aspose.slides.animation.command_effect)
- [FilterEffect](https://reference.aspose.com/slides/zh-hant/cpp/class/aspose.slides.animation.filter_effect)
- [MotionEffect](https://reference.aspose.com/slides/zh-hant/cpp/class/aspose.slides.animation.motion_effect)
- [PropertyEffect](https://reference.aspose.com/slides/zh-hant/cpp/class/aspose.slides.animation.property_effect)
- [RotationEffect](https://reference.aspose.com/slides/zh-hant/cpp/class/aspose.slides.animation.rotation_effect)
- [ScaleEffect](https://reference.aspose.com/slides/zh-hant/cpp/class/aspose.slides.animation.scale_effect)
- [SetEffect](https://reference.aspose.com/slides/zh-hant/cpp/class/aspose.slides.animation.set_effect)

## **自訂動畫**
在 Aspose.Slides 中可以建立 **自訂動畫**。只要將多個行為組合成新的自訂動畫即可實現。

[**Behavior**](https://reference.aspose.com/slides/zh-hant/cpp/class/aspose.slides.animation.behavior) 是任何 PowerPoint 動畫效果的組成單位。所有動畫效果實際上都是一組行為的集合。您可以先將多個行為組合成自訂動畫，之後在其他簡報中重複使用。如果在標準 PowerPoint 動畫效果中加入新的行為，就會形成另一種自訂動畫。例如，您可以加入「重複」行為，使動畫重複播放多次。

[**Animation Point**](https://reference.aspose.com/slides/zh-hant/cpp/class/aspose.slides.animation.point) 表示應用行為的點位。

## **動畫時間軸**
[**Sequence**](https://reference.aspose.com/slides/zh-hant/cpp/class/aspose.slides.animation.sequence) 是針對特定形狀所套用的動畫效果集合。

[**AnimationTimeLine**](https://reference.aspose.com/slides/zh-hant/cpp/class/aspose.slides.animation.animation_time_line) 是在具體投影片中使用的 Sequence 集合。自 PowerPoint 2002 起即成為動畫引擎。早期的 PowerPoint 版本在加入動畫效果時相當困難，只能透過各種變通方法。時間軸取代舊有的 AnimationSettings 類別，提供更清晰的物件模型。每張投影片只能有 **一個** 動畫時間軸。

## **互動動畫**
[**EffectTriggerType**](https://reference.aspose.com/slides/zh-hant/cpp/namespace/aspose.slides.animation#add24fb49dd44eb3227aeeb3641fd2e81) 允許定義使用者操作（例如按鈕點擊）以啟動特定動畫。觸發器僅在最新的 PowerPoint 版本中加入。

## **形狀動畫**
Aspose.Slides 允許對形狀套用動畫，形狀可以是文字、矩形、線條、框架、OLE 物件等。

{{% alert color="info" %}} 
閱讀更多 [**關於形狀動畫**](/slides/zh-hant/cpp/shape-animation/)。
{{% /alert %}}

## **圖表動畫**
建立圖表動畫時，使用的類別與形狀相同。不過，PowerPoint 動畫只能套用於圖表的類別或系列。您也可以對單一類別元素或系列元素套用動畫效果。

{{% alert color="info" %}} 
閱讀更多 [**關於圖表動畫**](/slides/zh-hant/cpp/animated-charts/)。
{{% /alert %}}

## **文字動畫**
除了文字動畫，亦可對段落套用動畫。

{{% alert color="info" %}} 
閱讀更多 [**關於文字動畫**](/slides/zh-hant/cpp/animated-text/)。
{{% /alert %}}

## **常見問題**

### 匯出為 PDF 時動畫會被保留嗎？

不會。PDF 為靜態格式，動畫與[投影片過渡](/slides/zh-hant/cpp/slide-transition/)不會播放。若需動態效果，請改匯出為[HTML5](/slides/zh-hant/cpp/export-to-html5/)、[動畫 GIF](/slides/zh-hant/cpp/convert-powerpoint-to-animated-gif/)或[影片](/slides/zh-hant/cpp/convert-powerpoint-to-video/)。

### 我可以將動畫簡報轉為影片，並控制影格率與畫面尺寸嗎？

可以。您可以[將簡報渲染為影格](/slides/zh-hant/cpp/convert-powerpoint-to-video/)，再使用 ffmpeg 等工具將影格編碼為影片，自行設定 FPS 與解析度。渲染過程中會播放動畫與投影片過渡。

### 在處理 ODP（不只是 PPTX）時動畫會保持完整嗎？

PPT、PPTX 與 ODP 均支援[讀取](/slides/zh-hant/cpp/open-presentation/)與[寫入](/slides/zh-hant/cpp/save-presentation/)，但格式差異可能導致部分效果呈現或行為上略有不同。建議使用實際樣本驗證關鍵情境。