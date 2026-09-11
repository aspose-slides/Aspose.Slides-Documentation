---
title: 使用 Java 的 Python 管理簡報無障礙
linktitle: 簡報無障礙
type: docs
weight: 30
url: /zh-hant/python-java/presentation-accessibility/
keywords:
- 簡報無障礙
- 標記為裝飾性
- PowerPoint
- OpenDocument
- 簡報
- Python
- Java
- Aspose.Slides
description: "了解 Aspose.Slides for Python via Java 如何協助自動執行 PPT、PPTX 與 ODP 檔案的簡報無障礙檢查—提升螢幕閱讀器體驗並加強合規性。"
---
## **簡介**

簡報的無障礙功能確保使用輔助技術的使用者——例如螢幕閱讀器、點字顯示器或僅鍵盤操作——能夠像視覺正常、使用滑鼠的觀眾一樣，理解並瀏覽您的投影片。最佳實踐著重於清晰的閱讀順序、對說明性視覺圖的有意義替代文字、足夠的色彩對比度、可讀的排版、具描述性的連結文字，並避免僅透過顏色或位置傳遞意義。從一開始就規劃無障礙，最終會得到更清晰的結構、更一致的視覺效果，且內容能夠在不需額外變通的情況下觸及每位觀眾。

## **標記為裝飾性**

「標記為裝飾性」用於純粹裝飾性的視覺元素，讓螢幕閱讀器跳過它們，減少干擾並將焦點保持在有意義的內容上。將此標記套用於背景、花紋和間距元件——絕不可用於傳遞資訊的圖表、圖示或影像。Aspose.Slides 針對此標記提供偵測與驗證功能，支援自動化的無障礙檢查與清理。

![標記為裝飾性](mark_as_decorative.png)

以下程式碼範例示範如何判斷形狀是否已標記為裝飾性。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("sample.pptx")
try:
    shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0)
    print(f"Is shape decorative: {shape.isDecorative()}")
finally:
    presentation.dispose()
```