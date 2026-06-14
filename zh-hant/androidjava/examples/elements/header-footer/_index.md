---
title: 頁首與頁腳
type: docs
weight: 220
url: /zh-hant/androidjava/examples/elements/header-footer/
keywords:
- 程式碼範例
- 頁首
- 頁腳
- PowerPoint
- OpenDocument
- 簡報
- Android
- Java
- Aspose.Slides
description: "使用 Aspose.Slides for Android 控制投影片的頁首與頁腳：在 PPT、PPTX 與 ODP 中加入日期、投影片編號與自訂文字的 Java 範例。"
---
本文示範如何使用 **Aspose.Slides for Android via Java** 添加頁腳並更新日期與時間佔位符。

## **新增頁腳**
在投影片的頁腳區域添加文字並使其可見。

```java
static void addHeaderFooter() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        slide.getHeaderFooterManager().setFooterText("My footer");
        slide.getHeaderFooterManager().setFooterVisibility(true);
    } finally {
        presentation.dispose();
    }
}
```

## **更新日期與時間**
修改投影片上的日期與時間佔位符。

```java
static void updateDateTime() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        slide.getHeaderFooterManager().setDateTimeText("01/01/2024");
        slide.getHeaderFooterManager().setDateTimeVisibility(true);
    } finally {
        presentation.dispose();
    }
}
```