---
title: 在 Android 上使用動畫增強 PowerPoint 簡報
linktitle: PowerPoint 動畫
type: docs
weight: 150
url: /zh-hant/androidjava/powerpoint-animation/
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
- PowerPoint
- 簡報
- Android
- Java
- Aspose.Slides
description: "探索 Aspose.Slides for Android via Java 處理 PowerPoint 動畫的功能。此概覽概述了主要特性。"
---
## **簡介**

由於簡報的目的是呈現內容，在建立簡報時總是會考慮其視覺外觀與互動行為。

**PowerPoint 動畫** 在使簡報吸引觀眾目光與具吸引力方面扮演重要角色。Aspose.Slides for Android via Java 提供了多種將動畫加入 PowerPoint 簡報的選項：

- 套用各種 PowerPoint 動畫效果於形狀、圖表、表格、OLE 物件及其他簡報元素。
- 在單一形狀上使用多個 PowerPoint 動畫效果。
- 使用動畫時間軸來控制動畫效果。
- 建立自訂動畫。

在 Aspose.Slides for Android via Java 中，可對形狀套用各種動畫效果。由於投影片上的每個元素（包括文字、圖片、OLE 物件、表格等）皆被視為形狀，這表示我們可以對投影片的每個元素套用動畫效果。

## **動畫效果**

Aspose.Slides 支援 **150+ 動畫效果**，包括基本動畫效果如 Bounce、PathFootball、Zoom，以及特定動畫效果如 OLEObjectShow、OLEObjectOpen。您可以在 [**EffectType**](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/effecttype/) 列舉中找到完整的動畫效果清單。

此外，這些動畫效果可與以下效果結合使用：

- [ColorEffect](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ColorEffect)
- [CommandEffect](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/CommandEffect)
- [FilterEffect](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/FilterEffect)
- [MotionEffect](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/MotionEffect)
- [PropertyEffect](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/PropertyEffect)
- [RotationEffect](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/RotationEffect)
- [ScaleEffect](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ScaleEffect)
- [SetEffect](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/SetEffect)

## **自訂動畫**

在 Aspose.Slides 中可以建立自己的 **自訂動畫**。只要將多個行為結合成新的自訂動畫，即可達成此目的。

[**Behavior**](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/Behavior) 是任何 PowerPoint 動畫效果的組成單位。所有動畫效果實際上都是由一組行為組合成的策略。您可以將行為組合成自訂動畫，之後在其他簡報中重複使用。若將新行為加入標準的 PowerPoint 動畫效果，即會產生另一個自訂動畫。例如，您可以為動畫加入重複行為，使其重複播放數次。

[**Animation Point**](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/Point) 是應用行為的點位。

## **動畫時間軸**

[**Sequence**](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/Sequence) 是套用於特定形狀的動畫效果集合。

[**Timeline**](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/AnimationTimeLine) 是在特定投影片中使用的 Sequence 集合。自 PowerPoint 2002 起即作為動畫引擎呈現。於早期 PowerPoint 版本中，加入動畫效果十分困難，只能透過各種變通方法。Timeline 取代了舊的 AnimationSettings 類別，提供更清晰的 PowerPoint 動畫物件模型。一張投影片只能有一個動畫時間軸。

## **互動式動畫**

[**Trigger**](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/EffectTriggerType) 允許定義使用者操作（例如按鈕點擊），以啟動特定動畫。Trigger 僅在最新的 PowerPoint 版本中加入。

## **形狀動畫**

Aspose.Slides 允許對形狀套用動畫，這些形狀實際上可以是文字、矩形、線條、框架、OLE 物件等。

{{% alert color="primary" %}} 
閱讀更多 [**關於形狀動畫**](/slides/zh-hant/androidjava/shape-animation/).
{{% /alert %}}

## **動畫化圖表**

若要建立動畫化圖表，您應使用與形狀相同的類別。但只能在圖表類別或圖表系列上套用 PowerPoint 動畫。您也可以將動畫效果套用於類別元素或系列元素。

{{% alert color="primary" %}} 
閱讀更多 [**關於動畫化圖表**](/slides/zh-hant/androidjava/animated-charts/).
{{% /alert %}}

## **動畫文字**

除了動畫文字外，亦可對段落套用動畫。

{{% alert color="primary" %}} 
閱讀更多 [**關於動畫文字**](/slides/zh-hant/androidjava/animated-text/).
{{% /alert %}}

## **常見問題**

**匯出為 PDF 時動畫會被保留嗎？**

不會。PDF 為靜態格式，故動畫與[投影片過場](/slides/zh-hant/androidjava/slide-transition/)不會播放。若需要動態效果，請改為匯出為[HTML5](/slides/zh-hant/androidjava/export-to-html5/)、[動畫 GIF](/slides/zh-hant/androidjava/convert-powerpoint-to-animated-gif/)或[影片](/slides/zh-hant/androidjava/convert-powerpoint-to-video/)。

**我可以將動畫簡報轉換為影片，並控制幀率與幀大小嗎？**

可以。您可以[將簡報渲染為影格](/slides/zh-hant/androidjava/convert-powerpoint-to-video/)並使用影片編碼工具（例如 ffmpeg）將其編碼為影片，並自行選擇 FPS 與解析度。渲染過程中會播放動畫與投影片過場。

**在使用 ODP（而非僅 PPTX）時，動畫會保持完整嗎？**

PPT、PPTX 與 ODP 都支援[讀取](/slides/zh-hant/androidjava/open-presentation/)與[寫入](/slides/zh-hant/androidjava/save-presentation/)，但格式差異可能導致某些效果在外觀或行為上略有不同。請使用真實樣本驗證關鍵情況。