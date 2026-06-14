---
title: 在 .NET 中比較簡報投影片
linktitle: 比較投影片
type: docs
weight: 50
url: /zh-hant/net/compare-slides/
keywords:
  - 比較投影片
  - 投影片比較
  - PowerPoint
  - OpenDocument
  - 簡報
  - .NET
  - C#
  - Aspose.Slides
description: "使用 Aspose.Slides for .NET 程式化比較 PowerPoint 與 OpenDocument 簡報。快速在程式碼中辨識投影片差異。"
---
## **概觀**

Aspose.Slides 允許您使用 `IBaseSlide` 介面和 `BaseSlide` 類別提供的 `Equals` 方法比較投影片、版面投影片和母片。當比較的投影片在結構和靜態內容上完全相同時，該方法會傳回 `true`。

## **比較兩張投影片**

`Equals` 方法已加入至 [IBaseSlide](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ibaseslide) 介面與 [BaseSlide](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/baseslide) 類別。它會對結構與靜態內容相同的投影片/版面以及投影片/母片傳回 true。

若兩張投影片的所有圖形、樣式、文字、動畫與其他設定皆相同，即視為相等。比較時不會考慮唯一識別碼值，例如 SlideId，亦不會納入動態內容，例如日期占位符中的當前日期值。

```c#
using (Presentation presentation1 = new Presentation("AccessSlides.pptx"))
using (Presentation presentation2 = new Presentation("HelloWorld.pptx"))
{
    for (int i = 0; i < presentation1.Masters.Count; i++)
    {
        for (int j = 0; j < presentation2.Masters.Count; j++)
        {
            if (presentation1.Masters[i].Equals(presentation2.Masters[j]))
                Console.WriteLine(string.Format("SomePresentation1 MasterSlide#{0} is equal to SomePresentation2 MasterSlide#{1}", i, j));
        }
    }
}
```

## **常見問題**

**投影片被隱藏這個事實會影響投影片本身的比較嗎？**

[Hidden status](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/slide/hidden/) 是投影片/播放層級的屬性，而非視覺內容。兩張特定投影片的相等性由其結構與靜態內容決定；僅因投影片被隱藏並不會使它們不同。

**會考慮超連結及其參數嗎？**

會。超連結屬於投影片的靜態內容。若 URL 或超連結動作不同，通常會被視為靜態內容的差異。

**如果圖表引用外部 Excel 檔案，是否會考慮該檔案的內容？**

不會。比較是依據投影片本身進行的。外部資料來源通常不會在比較時讀取；僅考慮投影片結構與靜態狀態中存在的內容。