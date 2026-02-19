---
title: 页眉页脚
type: docs
weight: 220
url: /zh/java/examples/elements/header-footer/
keywords:
- 代码示例
- 页眉
- 页脚
- PowerPoint
- OpenDocument
- 演示文稿
- Java
- Aspose.Slides
description: "使用 Aspose.Slides for Java 控制幻灯片的页眉和页脚：在 PPT、PPTX 和 ODP 中添加日期、幻灯片编号和自定义文本，附带 Java 示例。"
---
本文演示了如何使用 **Aspose.Slides for Java** 添加页脚并更新日期和时间占位符。

## **添加页脚**

在幻灯片的页脚区域添加文本并使其可见。

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

## **更新日期和时间**

修改幻灯片上的日期和时间占位符。

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