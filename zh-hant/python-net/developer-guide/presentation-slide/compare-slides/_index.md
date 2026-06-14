---
title: 在 Python 中比較簡報投影片
linktitle: 比較投影片
type: docs
weight: 50
url: /zh-hant/python-net/compare-slides/
keywords:
- 比較投影片
- 投影片比較
- PowerPoint
- OpenDocument
- 簡報
- Python
- Aspose.Slides
description: "使用 Aspose.Slides for Python 透過 .NET 程式化比較 PowerPoint 與 OpenDocument 簡報。快速在程式碼中識別投影片差異。"
---
## **概觀**

Aspose.Slides 允許您使用 `BaseSlide` 類別提供的 `equals` 方法來比較投影片、版面投影片和母片投影片。當比較的投影片在結構和靜態內容上完全相同時，該方法會回傳 `True`。

## **比較兩張投影片**
`equals` 方法已新增至 [BaseSlide](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/baseslide/) 類別。對於在結構和靜態內容上相同的投影片/版面投影片以及投影片/母片投影片，該方法會回傳 true。

當所有形狀、樣式、文字、動畫及其他設定皆相同時，兩張投影片即被視為相等。比較不會考慮唯一識別碼值，例如 SlideId，亦不會考慮動態內容，例如日期佔位符中的目前日期值。

```py
import aspose.slides as slides

with slides.Presentation(path + "AccessSlides.pptx") as p1:
    with slides.Presentation(path + "HelloWorld.pptx") as p2:
        for i in range(len(p1.masters)):
            for j in range(len(p2.masters)):
                if p1.masters[i].equals(p2.masters[j]):
                    print("Presentation1 MasterSlide#{0} is equal to Presentation2 MasterSlide#{1}".format(i,j))
```

## **常見問題**

**投影片被隱藏會影響投影片本身的比較嗎？**

[Hidden status](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/slide/hidden/) 是屬於簡報/播放層級的屬性，而非視覺內容。兩張特定投影片的相等性取決於其結構與靜態內容；僅僅因為投影片被隱藏，並不會使兩張投影片不同。

**超連結及其參數會被納入比較嗎？**

是。超連結屬於投影片的靜態內容之一。如果 URL 或超連結動作不同，通常會被視為靜態內容的差異。

**如果圖表引用外部 Excel 檔案，是否會將該檔案的內容納入比較？**

否。比較僅基於投影片本身進行。外部資料來源通常不會在比較時讀取；僅會考慮投影片結構與靜態狀態中存在的內容。