---
title: 在 C++ 中管理簡報無障礙
linktitle: 簡報無障礙
type: docs
weight: 30
url: /zh-hant/cpp/presentation-accessibility/
keywords:
- 簡報無障礙
- 標記為裝飾
- PowerPoint
- OpenDocument
- 簡報
- C++
- Aspose.Slides
description: "了解 Aspose.Slides for C++ 如何協助自動執行 PPT、PPTX 與 ODP 檔案的簡報無障礙檢查——提升螢幕閱讀器體驗並加強合規性。"
---
## **概覽**

簡報的無障礙功能確保使用輔助技術（例如螢幕閱讀器、點字顯示器或僅鍵盤操作）的人員，能如同有視力、使用滑鼠的觀眾一般，順利理解與瀏覽投影片。良好實踐著重於清晰的閱讀順序、資訊性視覺的有意義替代文字、足夠的色彩對比、易讀的排版、具描述性的連結文字，並避免僅以顏色或位置傳遞意義。從一開始就規劃無障礙，將產生更乾淨的結構、更一致的視覺，且內容能直接觸及每位觀眾，而不需另行處理。

## **標記為裝飾**

「標記為裝飾」用於純裝飾性的視覺元素，使螢幕閱讀器略過它們，降低雜訊並將焦點保持在有意義的內容上。將其套用於背景、裝飾圖案與間隔物——絕不可用於傳遞資訊的圖表、圖示或影像。Aspose.Slides 針對此旗標提供偵測與驗證功能，支援自動化的無障礙檢查與清理。

![標記為裝飾](mark_as_decorative.png)

以下程式碼範例顯示如何判斷形狀是否已標記為裝飾。

```cpp
auto presentation = MakeObject<Presentation>(u"sample.pptx");

auto shape = presentation->get_Slide(0)->get_Shape(0);
Console::WriteLine(u"Is shape decorative: {0}", shape->get_IsDecorative());

presentation->Dispose();
```