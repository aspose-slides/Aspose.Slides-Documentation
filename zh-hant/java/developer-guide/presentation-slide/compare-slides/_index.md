---
title: 在 Java 中比較簡報投影片
linktitle: 比較投影片
type: docs
weight: 50
url: /zh-hant/java/compare-slides/
keywords:
- 比較投影片
- 投影片比較
- PowerPoint
- OpenDocument
- 簡報
- Java
- Aspose.Slides
description: "使用 Aspose.Slides for Java 以程式方式比較 PowerPoint 和 OpenDocument 簡報。快速在程式碼中辨識投影片差異。"
---
## **概述**

Aspose.Slides 允許您使用 `IBaseSlide` 介面和 `BaseSlide` 類別提供的 `equals` 方法來比較投影片、版面投影片以及母片投影片。當比較的投影片在結構與靜態內容上完全相同時，該方法會傳回 `true`。

## **比較兩張投影片**
已在 [IBaseSlide](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/IBaseSlide) 介面和 [BaseSlide](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/BaseSlide) 類別中加入 Equals 方法。此方法會對結構與靜態內容相同的投影片/版面投影片與投影片/母片投影片傳回 true。

兩張投影片相等，當且僅當所有圖形、樣式、文字、動畫以及其他設定等全部相同。比較時不會考慮唯一識別碼值，例如 SlideId，亦不會考慮動態內容，例如日期佔位符中的目前日期值。

```java
Presentation presentation1 = new Presentation("AccessSlides.pptx");
try {
    Presentation presentation2 = new Presentation("HelloWorld.pptx");
    try {
        for (int i = 0; i < presentation1.getMasters().size(); i++)
        {
            for (int j = 0; j < presentation2.getMasters().size(); j++)
            {
                if (presentation1.getMasters().get_Item(i).equals(presentation2.getMasters().get_Item(j)))
                    System.out.println(String.format("SomePresentation1 MasterSlide#%d is equal to SomePresentation2 MasterSlide#%d", i, j));
            }
        }
    } finally {
        presentation2.dispose();
    }
} finally {
    presentation1.dispose();
}
```

## **常見問題**

**投影片隱藏的事實會影響投影片本身的比較嗎？**

[Hidden status](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/slide/#getHidden--) 是投影片/播放層級的屬性，而非視覺內容。兩張特定投影片的相等性由其結構與靜態內容決定；僅僅因為投影片被隱藏並不會使投影片不同。

**超連結及其參數會被考慮嗎？**

會。連結屬於投影片的靜態內容。如果 URL 或超連結動作不同，通常會被視為靜態內容的差異。

**如果圖表引用外部 Excel 檔案，該檔案的內容會被考慮嗎？**

不會。比較是基於投影片本身執行的。外部資料來源通常不會在比較時讀取；僅考慮投影片結構與靜態狀態中出現的內容。