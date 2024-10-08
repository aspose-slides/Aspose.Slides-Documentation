---
title: 演示文稿页眉和页脚
type: docs
weight: 140
url: /java/presentation-header-and-footer/
keywords: "Java中的PowerPoint页眉和页脚"
description: "Java中的PowerPoint页眉和页脚"
---

{{% alert color="primary" %}} 

[Aspose.Slides](/slides/java/) 提供对幻灯片页眉和页脚文本的支持，这些文本实际上是在幻灯片母版级别维护的。

{{% /alert %}} 

[Aspose.Slides for Java](/slides/java/) 提供在演示文稿幻灯片中管理页眉和页脚的功能。这些实际上是在演示文稿母版级别进行管理的。

## **在演示文稿中管理页眉和页脚**
某些特定幻灯片的备注可以如下面示例所示被删除：

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
                ((IAutoShape)shape).getTextFrame().setText("你好，新页眉");
            }
        }
    }
}
```

## **在讲义和备注幻灯片中管理页眉和页脚**
Aspose.Slides for Java 支持讲义和备注幻灯片中的页眉和页脚。请按照以下步骤操作：

- 加载一个包含视频的 [演示文稿](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation)。
- 更改备注母版和所有备注幻灯片的页眉和页脚设置。
- 使备注母版幻灯片和所有子页脚占位符可见。
- 使备注母版幻灯片和所有子日期和时间占位符可见。
- 仅更改第一个备注幻灯片的页眉和页脚设置。
- 使备注幻灯片页眉占位符可见。
- 为备注幻灯片页眉占位符设置文本。
- 为备注幻灯片日期时间占位符设置文本。
- 写入修改后的演示文稿文件。

下面的示例提供了代码片段。

```java
Presentation pres = new Presentation("presentation.pptx");
try {
    // 更改备注母版和所有备注幻灯片的页眉和页脚设置
    IMasterNotesSlide masterNotesSlide = pres.getMasterNotesSlideManager().getMasterNotesSlide();
    if (masterNotesSlide != null)
    {
        IMasterNotesSlideHeaderFooterManager headerFooterManager = masterNotesSlide.getHeaderFooterManager();

        headerFooterManager.setHeaderAndChildHeadersVisibility(true); // 使备注母版幻灯片和所有子页脚占位符可见
        headerFooterManager.setFooterAndChildFootersVisibility(true); // 使备注母版幻灯片和所有子页眉占位符可见
        headerFooterManager.setSlideNumberAndChildSlideNumbersVisibility(true); // 使备注母版幻灯片和所有子幻灯片编号占位符可见
        headerFooterManager.setDateTimeAndChildDateTimesVisibility(true); // 使备注母版幻灯片和所有子日期时间占位符可见

        headerFooterManager.setHeaderAndChildHeadersText("页眉文本"); // 为备注母版幻灯片和所有子页眉占位符设置文本
        headerFooterManager.setFooterAndChildFootersText("页脚文本"); // 为备注母版幻灯片和所有子页脚占位符设置文本
        headerFooterManager.setDateTimeAndChildDateTimesText("日期和时间文本"); // 为备注母版幻灯片和所有子日期时间占位符设置文本
    }

    // 仅更改第一个备注幻灯片的页眉和页脚设置
    INotesSlide notesSlide = pres.getSlides().get_Item(0).getNotesSlideManager().getNotesSlide();
    if (notesSlide != null)
    {
        INotesSlideHeaderFooterManager headerFooterManager = notesSlide.getHeaderFooterManager();
        if (!headerFooterManager.isHeaderVisible())
            headerFooterManager.setHeaderVisibility(true); // 使此备注幻灯片页眉占位符可见

        if (!headerFooterManager.isFooterVisible())
            headerFooterManager.setFooterVisibility(true); // 使此备注幻灯片页脚占位符可见

        if (!headerFooterManager.isSlideNumberVisible())
            headerFooterManager.setSlideNumberVisibility(true); // 使此备注幻灯片幻灯片编号占位符可见

        if (!headerFooterManager.isDateTimeVisible())
            headerFooterManager.setDateTimeVisibility(true); // 使此备注幻灯片日期时间占位符可见

        headerFooterManager.setHeaderText("新页眉文本"); // 为备注幻灯片页眉占位符设置文本
        headerFooterManager.setFooterText("新页脚文本"); // 为备注幻灯片页脚占位符设置文本
        headerFooterManager.setDateTimeText("新的日期和时间文本"); // 为备注幻灯片日期时间占位符设置文本
    }
    pres.save("testresult.pptx",SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```