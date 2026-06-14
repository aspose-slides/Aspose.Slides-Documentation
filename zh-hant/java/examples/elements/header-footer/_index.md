---
title: 頁眉 頁腳
type: docs
weight: 220
url: /zh-hant/java/examples/elements/header-footer/
keywords:
- 程式碼範例
- 頁眉
- 頁腳
- PowerPoint
- OpenDocument
- 簡報
- Java
- Aspose.Slides
description: "使用 Aspose.Slides for Java 控制投影片的頁眉與頁腳：在 PPT、PPTX 與 ODP 中加入日期、投影片編號與自訂文字的 Java 範例。"
---
本文示範如何使用 **Aspose.Slides for Java** 新增頁腳以及更新日期與時間佔位符。

## **新增頁腳**

在投影片的頁腳區域加入文字並使其可見。

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