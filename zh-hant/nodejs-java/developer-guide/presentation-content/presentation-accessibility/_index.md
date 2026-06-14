---
title: 在 JavaScript 中管理簡報無障礙性
linktitle: 簡報無障礙性
type: docs
weight: 30
url: /zh-hant/nodejs-java/presentation-accessibility/
keywords:
- 簡報無障礙性
- 標記為裝飾性
- PowerPoint
- OpenDocument
- 簡報
- Node.js
- JavaScript
- Aspose.Slides
description: "使用 Aspose.Slides for Node.js 自動化 PPT、PPTX 與 ODP 檔案的簡報無障礙檢查，提升螢幕閱讀器體驗並加強合規性。"
---
## **概述**

簡報的無障礙設計確保使用輔助技術（例如螢幕閱讀器、點字顯示器或僅鍵盤導覽）的人，能如同有視力、使用滑鼠的觀眾般，順利理解與導覽您的投影片。良好實踐著重於清晰的閱讀順序、對具資訊性的視覺元素提供有意義的替代文字、足夠的色彩對比度、易讀的排版、具描述性的連結文字，以及避免僅以顏色或位置傳遞意義。從一開始即規劃無障礙設計，最終會得到更清晰的結構、更一致的視覺效果，且內容能在不需要任何變通的情況下，觸及每一位觀眾。

## **標記為裝飾性**

「標記為裝飾性」旗標用於純粹裝飾性的視覺元素，使螢幕閱讀器跳過它們，降低噪音並將焦點維持在有意義的內容上。請將其套用於背景、裝飾圖案與間隔物——絕不要用於圖表、圖示或傳遞資訊的圖像。Aspose.Slides 為此旗標提供偵測與驗證功能，支援自動化的無障礙檢查與清理。

![標記為裝飾性](mark_as_decorative.png)

以下程式碼範例示範如何判斷形狀是否已標記為裝飾性。

```js
let presentation = new aspose.slides.Presentation("sample.pptx");
try {
    let shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    console.log("Is shape decorative:", shape.isDecorative());
} finally {
    presentation.dispose();
}
```