---
title: 在 Android 上比較簡報投影片
linktitle: 比較投影片
type: docs
weight: 50
url: /zh-hant/androidjava/compare-slides/
keywords:
- 比較投影片
- 投影片比較
- PowerPoint
- OpenDocument
- 簡報
- Android
- Java
- Aspose.Slides
description: "使用 Aspose.Slides for Android 以程式方式比較 PowerPoint 與 OpenDocument 簡報。快速在 Java 程式碼中辨識投影片差異。"
---
## **概觀**

Aspose.Slides 允許您使用 `IBaseSlide` 介面和 `BaseSlide` 類別提供的 `equals` 方法來比較投影片、版面投影片和母片。當比較的投影片在結構與靜態內容上完全相同時，此方法會回傳 `true`。

## **比較兩張投影片**
已將 `Equals` 方法新增至 [IBaseSlide](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/IBaseSlide) 介面和 [BaseSlide](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/BaseSlide) 類別。它會對結構與靜態內容相同的投影片/版面和投影片/母片回傳 `true`。

當所有形狀、樣式、文字、動畫以及其他設定等全部相同時，兩張投影片即視為相等。比較時不會考慮唯一識別碼的值，例如 `SlideId`，以及動態內容，例如日期佔位符中的當前日期值。

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

**投影片被隱藏會影響投影片本身的比較嗎？**

[隱藏狀態](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/slide/#getHidden--) 是投影片/播放層級的屬性，而非視覺內容。兩張特定投影片的相等性由其結構與靜態內容決定；僅因投影片被隱藏並不會使其不同。

**超連結及其參數會被考慮嗎？**

是的。超連結是投影片靜態內容的一部份。如果 URL 或超連結動作不同，通常會被視為靜態內容的差異。

**如果圖表引用外部 Excel 檔案，該檔案的內容會被考慮嗎？**

不會。比較是根據投影片本身進行的。外部資料來源通常不會在比較時被讀取；僅會考慮投影片結構與靜態狀態中所包含的內容。