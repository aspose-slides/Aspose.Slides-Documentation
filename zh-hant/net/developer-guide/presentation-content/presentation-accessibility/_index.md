---
title: 管理 .NET 中的簡報可及性
linktitle: 簡報可及性
type: docs
weight: 30
url: /zh-hant/net/presentation-accessibility/
keywords:
- 簡報可及性
- 替代文字
- 替代文字標題
- 替代文字說明
- 標記為裝飾性
- PowerPoint
- OpenDocument
- 簡報
- .NET
- C#
- Aspose.Slides
description: "使用 Aspose.Slides for .NET 自動化檢查 PPT、PPTX 與 ODP 檔案的簡報可及性——提升螢幕閱讀器體驗並增強合規性。"
---
## **簡介**

替代文字可協助使用輔助技術的人士了解圖像、圖表及其他資訊形狀的含義。本文章說明如何使用 Aspose.Slides for .NET 讀取和更新替代文字標題與說明，辨別程式碼中使用的形狀名稱與可及性說明之差異，以及檢查形狀是否已標記為裝飾性。

這些功能有助於提升簡報的可及性，但並不能保證完整符合可及性標準。仍需檢查閱讀順序、色彩對比、文字可讀性以及其他可及性需求。

## **管理替代文字標題與說明**

使用替代文字說明圖像、圖表及其他資訊形狀的意涵，讓看不見這些內容的人也能理解。以下屬性各有不同用途：

| 屬性或內容 | 目的 |
| --- | --- |
| [AlternativeTextTitle](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ishape/alternativetexttitle/) | 替代說明的簡短標題。 |
| [AlternativeText](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ishape/alternativetext/) | 在投影片情境中，對形狀內容或目的的具意義說明。 |
| [Name](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ishape/name/) | 形狀的名稱，程式碼可用於在簡報中尋找特定形狀。 |
| 可見文字 | 投影片上顯示的內容，例如形狀文字或圖表的標題與標籤。更新替代文字不會更改此內容。 |

當簡報被重新用作範本時，程式碼可能會在更新前透過其 [Name] 取得形狀。此名稱的用途與說明視覺內容給讀者的替代文字不同。透過名稱搜尋可讓作者在不影響程式碼尋找形狀的情況下，改進或翻譯說明。名稱可編輯且不保證唯一，請確認名稱對應到預期的形狀；詳情請參閱 [Identify and Find Shapes](/slides/zh-hant/net/shape-manipulations/#identify-and-find-shapes)。

以下範例需要 `input.pptx`，其中第一張投影片的第一個形狀是一張辦公室入口的圖片。此圖片不應標記為裝飾性。範例會讀取並輸出其目前的替代文字標題與說明，更新兩個值，並將簡報另存為 `output.pptx`。請依實際圖片及其傳遞的資訊調整文字說明。

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("input.pptx");
var shape = presentation.Slides[0].Shapes[0];

Console.WriteLine($"Alternative text title: {shape.AlternativeTextTitle}");
Console.WriteLine($"Alternative text description: {shape.AlternativeText}");

shape.AlternativeTextTitle = "Office entrance";
shape.AlternativeText = "The office entrance has a wheelchair ramp to the right of the steps.";

presentation.Save("output.pptx", SaveFormat.Pptx);
```

僅添加替代文字並無法保證簡報的可及性或符合可及性標準。請檢查說明的正確性與相關性，同時審核閱讀順序、色彩對比、文字可讀性與其他可及性需求。資訊性視覺內容不應標記為裝飾性；下一節將示範如何讀取 [IsDecorative](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ishape/isdecorative/)。

## **標記為裝飾性**

「標記為裝飾性」旗標會將純粹裝飾性的視覺元素標示，使螢幕閱讀器略過它們，減少噪音並將焦點放在有意義的內容上。此旗標應用於背景、裝飾圖案與間距物件——絕不要用於傳遞資訊的圖表、圖示或圖片。Aspose.Slides 提供此旗標供偵測與驗證，以支援自動化的可及性檢查與清理。

![標記為裝飾性](mark_as_decorative.png)

以下程式碼範例示範如何判斷形狀是否已標記為裝飾性。

```cs
using Aspose.Slides;

using var presentation = new Presentation("sample.pptx");

var shape = presentation.Slides[0].Shapes[0];
Console.WriteLine($"Is shape decorative: {shape.IsDecorative}");
```

## **常見問題**

**我應該在替代文字標題與說明中放入什麼內容？**

使用簡短的標題以辨識主題，並以說明文字解釋視覺在投影片情境中傳遞的資訊。對於圖表，請描述相關的趨勢或比較，而不要僅寫「圖表」。

**我應該使用替代文字在範本中定位形狀嗎？**

建議透過其 [Name] 來尋找形狀，並確認其為預期的形狀。替代文字可能被編輯或翻譯，會導致搜尋精確說明的程式碼失效；請參閱 [Identify and Find Shapes](/slides/zh-hant/net/shape-manipulations/)。

**何時應將形狀標記為裝飾性？**

對於不提供資訊的視覺元素（例如裝飾性圖案），可使用裝飾性旗標。傳遞意義的圖片與圖表則需提供適當的說明。

**添加替代文字就能讓簡報完全符合可及性嗎？**

不會。替代文字僅涵蓋可及性的一部份。仍需檢查閱讀順序、色彩對比、文字可讀性以及其他相關需求；僅設定這些屬性並無法確保符合標準。