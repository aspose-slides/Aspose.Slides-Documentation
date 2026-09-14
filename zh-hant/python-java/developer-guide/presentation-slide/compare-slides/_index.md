---
title: 在 Python 中比較簡報投影片
linktitle: 比較投影片
type: docs
weight: 50
url: /zh-hant/python-java/compare-slides/
keywords:
- 比較投影片
- 投影片比較
- PowerPoint
- OpenDocument
- 簡報
- Python
- Aspose.Slides
description: "使用 Aspose.Slides for Python via Java 程式化比較 PowerPoint 與 OpenDocument 簡報。快速在程式碼中辨識投影片差異。"
---
## **概述**

Aspose.Slides 允許您使用由 [BaseSlide](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/baseslide/) 類別提供的 [equals](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/baseslide/#equals) 方法比較投影片、版面投影片和母片。當比較的投影片在結構和靜態內容上完全相同時，此方法會回傳 `True`。

## **比較兩張投影片**

[equals](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/baseslide/#equals) 方法在 [BaseSlide](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/baseslide/) 類別中，對於結構和靜態內容相同的投影片、版面投影片與母片回傳 `True`。

兩張投影片相等，當它們的所有圖形、樣式、文字、動畫及其他設定皆相同。比較不會考慮唯一識別值（例如投影片 ID）或動態內容（例如日期佔位字元中的目前日期）。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

source_presentation = Presentation("AccessSlides.pptx")
try:
    target_presentation = Presentation("HelloWorld.pptx")
    try:
        for i in range(source_presentation.getMasters().size()):
            for j in range(target_presentation.getMasters().size()):
                if source_presentation.getMasters().get_Item(i).equals(target_presentation.getMasters().get_Item(j)):
                    print(f"AccessSlides MasterSlide#{i} is equal to HelloWorld MasterSlide#{j}")
    finally:
        target_presentation.dispose()
finally:
    source_presentation.dispose()
```

## **常見問題**

**投影片被隱藏會影響投影片本身的比較嗎？**

[Hidden status](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/slide/#getHidden) 是投影片/播放層級的屬性，而非視覺內容。兩張特定投影片的相等性取決於它們的結構與靜態內容；僅僅因為投影片被隱藏並不會使兩張投影片不同。

**超連結以及其參數會被考慮嗎？**

會。連結屬於投影片的靜態內容。如果 URL 或超連結動作不同，通常會被視為靜態內容的差異。

**如果圖表參考外部 Excel 檔案，是否會考慮該檔案的內容？**

不會。比較是僅基於投影片本身進行。外部資料來源通常不會在比較時讀取；只會考慮投影片結構與靜態狀態中存在的內容。