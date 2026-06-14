---
title: 在 C++ 中比較簡報投影片
linktitle: 比較投影片
type: docs
weight: 50
url: /zh-hant/cpp/compare-slides/
keywords:
- 比較投影片
- 投影片比較
- PowerPoint
- OpenDocument
- 簡報
- C++
- Aspose.Slides
description: "使用 Aspose.Slides for C++ 以程式方式比較 PowerPoint 與 OpenDocument 簡報。快速在程式碼中辨識投影片差異。"
---
## **概觀**

Aspose.Slides 允許您使用 `IBaseSlide` 介面和 `BaseSlide` 類別提供的 `Equals` 方法來比較投影片、版面投影片和母片。當比較的投影片在結構和靜態內容上完全相同時，此方法會傳回 `true`。

## **比較兩張投影片**
已將 `Equals` 方法加入 `IBaseSlide` 介面和 `BaseSlide` 類別。對於結構和靜態內容相同的投影片 / 版面投影片 / 母片，它會傳回 `true`。

如果所有形狀、樣式、文字、動畫及其他設定等皆相同，兩張投影片即被視為相等。比較不會考慮唯一識別碼值，例如 SlideId，亦不會考慮動態內容，例如日期占位符中的目前日期值。

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CheckSlidesComparison-CheckSlidesComparison.cpp" >}}

## **常見問題**

**投影片被隱藏的事實會影響投影片本身的比較嗎？**

[隱藏狀態](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/slide/get_hidden/) 是演示/播放層級的屬性，而非視覺內容。兩張特定投影片的相等性是由它們的結構和靜態內容決定的；僅僅因為投影片被隱藏並不會使它們不同。

**是否會將超連結及其參數納入考慮？**

是。連結是投影片靜態內容的一部份。如果 URL 或超連結動作不同，通常會被視為靜態內容的差異。

**如果圖表參照外部 Excel 檔案，該檔案的內容會被納入考慮嗎？**

不會。比較是根據投影片本身執行的。外部資料來源通常不會在比較時讀取；僅考慮投影片結構和靜態狀態中存在的內容。