---
title: 演示文稿页眉和页脚
type: docs
weight: 140
url: /zh/androidjava/presentation-header-and-footer/
keywords: "Java中的PowerPoint页眉和页脚"
description: "Java中的PowerPoint页眉和页脚"
---

{{% alert color="primary" %}} 

[Aspose.Slides](/slides/zh/androidjava/) 提供支持，可以处理实际上在幻灯片母版级别维护的幻灯片的页眉和页脚文本。

{{% /alert %}} 

[Aspose.Slides for Android via Java](/slides/zh/androidjava/) 提供了在演示文稿幻灯片中管理页眉和页脚的功能。这些实际上是在演示文稿母版级别管理的。

## **在演示文稿中管理页眉和页脚**
可以按以下示例删除某个特定幻灯片的注释：

```java
// 加载演示文稿
Presentation pres = new Presentation("headerTest.pptx");
try {
    // 设置页脚
    pres.getHeaderFooterManager().setAllFootersText("我的页脚文本");
    pres.getHeaderFooterManager().setAllFootersVisibility(true);

    // 访问并更新页眉
    IMasterNotesSlide masterNotesSlide = pres.getMasterNotesSlideManager().getMasterNotesSlide();
    if (null != masterNotesSlide)
    {
        updateHeaderFooterText(masterNotesSlide);
    }

    // 保存演示文稿
    pres.save("HeaderFooterJava.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```
```java
// 设置页眉/页脚文本的方法
public static void updateHeaderFooterText(IBaseSlide master)
{
    for (IShape shape : master.getShapes())
    {
        if (shape.getPlaceholder() != null)
        {
            if (shape.getPlaceholder().getType() == PlaceholderType.Header)
            {
                ((IAutoShape)shape).getTextFrame().setText("你好，新的页眉");
            }
        }
    }
}
```

## **在讲义和注释幻灯片中管理页眉和页脚**
Aspose.Slides for Android via Java 支持讲义和注释幻灯片中的页眉和页脚。请按照以下步骤操作：

- 加载一个包含视频的 [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation)。
- 更改注释母版和所有注释幻灯片的页眉和页脚设置。
- 设置母版注释幻灯片和所有子页脚占位符可见。
- 设置母版注释幻灯片和所有子日期和时间占位符可见。
- 仅更改第一个注释幻灯片的页眉和页脚设置。
- 设置注释幻灯片页眉占位符可见。
- 设置注释幻灯片页眉占位符的文本。
- 设置注释幻灯片日期时间占位符的文本。
- 写入修改后的演示文稿文件。

代码片段在以下示例中提供。

```java
Presentation pres = new Presentation("presentation.pptx");
try {
    // 更改注释母版和所有注释幻灯片的页眉和页脚设置
    IMasterNotesSlide masterNotesSlide = pres.getMasterNotesSlideManager().getMasterNotesSlide();
    if (masterNotesSlide != null)
    {
        IMasterNotesSlideHeaderFooterManager headerFooterManager = masterNotesSlide.getHeaderFooterManager();

        headerFooterManager.setHeaderAndChildHeadersVisibility(true); // 使母版注释幻灯片和所有子页脚占位符可见
        headerFooterManager.setFooterAndChildFootersVisibility(true); // 使母版注释幻灯片和所有子页眉占位符可见
        headerFooterManager.setSlideNumberAndChildSlideNumbersVisibility(true); // 使母版注释幻灯片和所有子幻灯片编号占位符可见
        headerFooterManager.setDateTimeAndChildDateTimesVisibility(true); // 使母版注释幻灯片和所有子日期和时间占位符可见

        headerFooterManager.setHeaderAndChildHeadersText("页眉文本"); // 设置母版注释幻灯片和所有子页眉占位符的文本
        headerFooterManager.setFooterAndChildFootersText("页脚文本"); // 设置母版注释幻灯片和所有子页脚占位符的文本
        headerFooterManager.setDateTimeAndChildDateTimesText("日期和时间文本"); // 设置母版注释幻灯片和所有子日期和时间占位符的文本
    }

    // 仅更改第一个注释幻灯片的页眉和页脚设置
    INotesSlide notesSlide = pres.getSlides().get_Item(0).getNotesSlideManager().getNotesSlide();
    if (notesSlide != null)
    {
        INotesSlideHeaderFooterManager headerFooterManager = notesSlide.getHeaderFooterManager();
        if (!headerFooterManager.isHeaderVisible())
            headerFooterManager.setHeaderVisibility(true); // 使该注释幻灯片页眉占位符可见

        if (!headerFooterManager.isFooterVisible())
            headerFooterManager.setFooterVisibility(true); // 使该注释幻灯片页脚占位符可见

        if (!headerFooterManager.isSlideNumberVisible())
            headerFooterManager.setSlideNumberVisibility(true); // 使该注释幻灯片幻灯片编号占位符可见

        if (!headerFooterManager.isDateTimeVisible())
            headerFooterManager.setDateTimeVisibility(true); // 使该注释幻灯片日期时间占位符可见

        headerFooterManager.setHeaderText("新页眉文本"); // 设置文本到注释幻灯片页眉占位符
        headerFooterManager.setFooterText("新页脚文本"); // 设置文本到注释幻灯片页脚占位符
        headerFooterManager.setDateTimeText("新的日期和时间文本"); // 设置文本到注释幻灯片日期时间占位符
    }
    pres.save("testresult.pptx",SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```