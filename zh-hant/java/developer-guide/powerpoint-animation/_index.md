---
title: 使用 Java 為 PowerPoint 簡報加入動畫以提升效果
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
- 形狀動畫
- 圖表動畫
- 文字動畫
- 動畫形狀
- 動畫 OLE 物件
- 動畫圖像
- 動畫表格
- PowerPoint
- 簡報
- Java
- Aspose.Slides
description: "探索 Aspose.Slides for Java 處理 PowerPoint 動畫的功能。本概觀說明主要特色，並提供提升簡報的見解。"
---
## **簡介**

由於簡報的目的在於呈現資訊，在製作過程中必然會考慮其視覺外觀與互動行為。

**PowerPoint 動畫** 在使簡報更具吸引力與互動性方面扮演重要角色。Aspose.Slides 提供多種方式為 PowerPoint 簡報加入動畫：

- 將各種類型的 PowerPoint 動畫效果套用到形狀、圖表、表格、OLE 物件及其他簡報元素。
- 在單一形狀上使用多個 PowerPoint 動畫效果。
- 利用動畫時間軸來控制動畫效果。
- 建立自訂動畫。

在 Aspose.Slides 中，可將各種動畫效果套用到形狀上。由於投影片上的每個元素，包括文字、圖片、OLE 物件和表格，都被視為形狀，所以動畫效果可以套用到投影片上的任何元素。

## **動畫效果**
Aspose.Slides 支援 **150+ 動畫效果**，包括如 Bounce、PathFootball、Zoom 等基本動畫效果，以及 OLEObjectShow、OLEObjectOpen 等特定動畫效果。您可以在[**EffectType**](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/effecttype/)列舉中找到完整的動畫效果清單。

此外，這些動畫效果還可以與以下效果結合使用：

- [ColorEffect](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ColorEffect)
- [CommandEffect](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/CommandEffect)
- [FilterEffect](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/FilterEffect)
- [MotionEffect](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/MotionEffect)
- [PropertyEffect](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/PropertyEffect)
- [RotationEffect](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/RotationEffect)
- [ScaleEffect](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ScaleEffect)
- [SetEffect](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/SetEffect)

## **自訂動畫**
您可以在 Aspose.Slides 中建立自己的 **自訂動畫**。只要將多個行為組合成新的自訂動畫，即可實現此目的。

[**Behavior**](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/Behavior) 是任何 PowerPoint 動畫效果的構建單位。所有動畫效果實際上是一組行為組成的策略。您可以將行為一次性組合成自訂動畫，並在其他簡報中重複使用。若將新行為加入標準 PowerPoint 動畫效果，則會產生另一個自訂動畫。例如，您可以為動畫新增重複行為，使其重複播放數次。

[**Animation Point**](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/Point) 是應用行為的點。

## **動畫時間軸**
[**Sequence**](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/Sequence) 是一組套用於特定形狀的動畫效果的集合。

[**Timeline**](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/AnimationTimeLine) 是在特定投影片中使用的 Sequence 集合。自 PowerPoint 2002 起，Timeline 作為動畫引擎被引入。以前的 PowerPoint 版本在為簡報加入動畫效果時相當困難，只能透過各種變通方法。Timeline 用來取代舊有的 AnimationSettings 類別，並提供更清晰的 PowerPoint 動畫物件模型。一張投影片只能擁有一個動畫時間軸。

## **互動式動畫**
[**Trigger**](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/EffectTriggerType) 允許定義使用者操作（例如按鈕點擊），以啟動特定動畫。Trigger 只在最新的 PowerPoint 版本中加入。

## **形狀動畫**
Aspose.Slides 允許對形狀套用動畫，形狀實際上可以是文字、矩形、線條、框架、OLE 物件等。

{{% alert color="info" %}} 
閱讀更多[**關於形狀動畫**](/slides/zh-hant/java/shape-animation/)。
{{% /alert %}}

## **圖表動畫**
要為圖表建立動畫，您應使用與形狀相同的類別。不過，PowerPoint 動畫僅能套用於圖表的類別或系列。您也可以對類別元素或系列元素套用動畫效果。

{{% alert color="info" %}} 
閱讀更多[**關於圖表動畫**](/slides/zh-hant/java/animated-charts/)。
{{% /alert %}}

## **文字動畫**
除了文字動畫之外，亦可對段落套用動畫。

{{% alert color="info" %}} 
閱讀更多[**關於文字動畫**](/slides/zh-hant/java/animated-text/)。
{{% /alert %}}

## **FAQ**

### 匯出為 PDF 時，動畫會被保留嗎？

不會。PDF 為靜態格式，因此動畫和[投影片過場](/slides/zh-hant/java/slide-transition/)不會播放。若需要動態效果，請改為匯出為[HTML5](/slides/zh-hant/java/export-to-html5/)、[動畫 GIF](/slides/zh-hant/java/convert-powerpoint-to-animated-gif/)或[影片](/slides/zh-hant/java/convert-powerpoint-to-video/)等格式。

### 我可以將動畫簡報轉換為影片並控制幀率與幀大小嗎？

可以。您可以[將簡報渲染為幀](/slides/zh-hant/java/convert-powerpoint-to-video/)並使用如 ffmpeg 等工具將其編碼為影片，並自行選擇 FPS 與解析度。動畫與投影片過場會在渲染時播放。

### 在使用 ODP（不僅是 PPTX）時，動畫會保持完整嗎？

PPT、PPTX 以及 ODP 均支援[讀取](/slides/zh-hant/java/open-presentation/)與[寫入](/slides/zh-hant/java/save-presentation/)，但格式差異可能導致某些效果的外觀或行為略有不同。請使用真實樣本驗證關鍵情況。