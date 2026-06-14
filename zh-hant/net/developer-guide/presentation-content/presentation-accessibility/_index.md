---
title: 在 .NET 中管理簡報可存取性
linktitle: 簡報可存取性
type: docs
weight: 30
url: /zh-hant/net/presentation-accessibility/
keywords:
- 簡報可存取性
- 標記為裝飾性
- PowerPoint
- OpenDocument
- 簡報
- .NET
- C#
- Aspose.Slides
description: "使用 Aspose.Slides for .NET 自動執行 PPT、PPTX 與 ODP 檔案的簡報可存取性檢查—提升螢幕閱讀器體驗並加強合規性。"
---
## **簡介**

簡報可存取性確保使用輔助技術的使用者—例如螢幕閱讀器、點字顯示器或僅鍵盤導覽—能夠如同視覺正常、使用滑鼠的觀眾般，理解並瀏覽您的投影片。良好的做法著重於清晰的閱讀順序、對資訊性視覺提供有意義的替代文字、足夠的顏色對比度、易讀的排版、具描述性的連結文字，並避免僅透過顏色或位置傳遞意義。當可存取性從一開始就規劃時，結果會是更乾淨的結構、更一致的視覺效果，以及能夠讓每位觀眾在不需另行處理的情況下取得內容。

## **標記為裝飾性**

「標記為裝飾性」旗標用於純粹裝飾性的視覺元素，使螢幕閱讀器跳過它們，減少雜訊並將焦點保持在有意義的內容上。將其應用於背景、花紋和間距—絕不應用於圖表、圖示或傳遞資訊的圖片。Aspose.Slides 會公開此旗標以供偵測和驗證，從而實現自動化的可存取性檢查與清理。

![標記為裝飾性](mark_as_decorative.png)

以下程式碼範例示範如何判斷形狀是否已標記為裝飾性。

```cs
using var presentation = new Presentation("sample.pptx");

var shape = presentation.Slides[0].Shapes[0];
Console.WriteLine($"Is shape decorative: {shape.IsDecorative}");
```