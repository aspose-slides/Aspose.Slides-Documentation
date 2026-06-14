---
title: 管理 Python 簡報無障礙
linktitle: 簡報無障礙
type: docs
weight: 30
url: /zh-hant/python-net/presentation-accessibility/
keywords:
- 簡報無障礙
- 標記為裝飾性
- PowerPoint
- OpenDocument
- 簡報
- Python
- Aspose.Slides
description: "了解 Aspose.Slides for Python 如何在 PPT、PPTX 與 ODP 檔案中自動執行簡報無障礙檢查—提升螢幕閱讀器體驗並增強合規性。"
---
## **簡介**

簡報無障礙確保使用輔助技術（例如螢幕閱讀器、點字顯示器或僅鍵盤導航）的人能夠如同視覺正常、使用滑鼠的觀眾般，理解並瀏覽您的投影片。良好的做法著重於清晰的閱讀順序、為資訊性視覺提供具意義的替代文字、足夠的色彩對比、易讀的排版、具描述性的連結文字，並避免僅以顏色或位置傳遞意義。從一開始即規劃無障礙，結果會是更清晰的結構、更一致的視覺，且內容能覆蓋每位觀眾，無需額外的補救措施。

## **標記為裝飾性**

標記為裝飾性將純裝飾性的視覺標記起來，使螢幕閱讀器跳過它們，減少雜訊並將焦點保留在有意義的內容上。將其套用於背景、裝飾圖案和間距元件──絕不可用於圖表、圖示或傳遞資訊的影像。Aspose.Slides 為此旗標提供偵測與驗證功能，能自動執行無障礙檢查與清理。

![標記為裝飾性](mark_as_decorative.png)

以下程式碼範例顯示如何判斷形狀是否已標記為裝飾性。

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]
    print(f"Is shape decorative: {shape.is_decorative}")
```