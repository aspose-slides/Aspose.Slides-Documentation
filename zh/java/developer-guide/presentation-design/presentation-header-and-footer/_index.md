---
title: 在 Java 中管理演示文稿的页眉和页脚
linktitle: 页眉和页脚
type: docs
weight: 140
url: /zh/java/presentation-header-and-footer/
keywords:
- 页眉
- 页眉文本
- 页脚
- 页脚文本
- 设置页眉
- 设置页脚
- 讲义
- 备注
- PowerPoint
- OpenDocument
- 演示文稿
- Java
- Aspose.Slides
description: "使用 Aspose.Slides for Java 在 PowerPoint 和 OpenDocument 演示文稿中添加和自定义页眉和页脚，以获得专业外观。"
---

{{% alert color="primary" %}} 

[Aspose.Slides](/slides/zh/java/) 提供对幻灯片母版层级的页眉和页脚文本的支持。

{{% /alert %}} 

[Aspose.Slides for Java](/slides/zh/java/) 提供在演示文稿幻灯片中管理页眉和页脚的功能。这些实际上在演示文稿母版层级进行管理。

## **在演示文稿中管理页眉和页脚**
可以删除特定幻灯片的备注，如下面示例所示：
```java
// 加载演示文稿
Presentation pres = new Presentation("headerTest.pptx");
try {
    // 设置页脚
    pres.getHeaderFooterManager().setAllFootersText("My Footer text");
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
                ((IAutoShape)shape).getTextFrame().setText("HI there new header");
            }
        }
    }
}
```


## **在讲义和备注幻灯片上管理页眉和页脚**
Aspose.Slides for Java 支持在讲义和备注幻灯片中使用页眉和页脚。请按照以下步骤操作：

- 加载包含视频的[Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation)。
- 更改备注母版和所有备注幻灯片的页眉和页脚设置。
- 将母版备注幻灯片及其所有子页脚占位符设为可见。
- 将母版备注幻灯片及其所有子日期和时间占位符设为可见。
- 仅更改第一张备注幻灯片的页眉和页脚设置。
- 将备注幻灯片的页眉占位符设为可见。
- 为备注幻灯片的页眉占位符设置文本。
- 为备注幻灯片的日期时间占位符设置文本。
- 写入已修改的演示文稿文件。

下面示例提供了代码片段。
```java
Presentation pres = new Presentation("presentation.pptx");
try {
    // 更改备注母版及所有备注幻灯片的页眉和页脚设置
    IMasterNotesSlide masterNotesSlide = pres.getMasterNotesSlideManager().getMasterNotesSlide();
    if (masterNotesSlide != null)
    {
        IMasterNotesSlideHeaderFooterManager headerFooterManager = masterNotesSlide.getHeaderFooterManager();

        headerFooterManager.setHeaderAndChildHeadersVisibility(true); // 使母版备注幻灯片和所有子页脚占位符可见
        headerFooterManager.setFooterAndChildFootersVisibility(true); // 使母版备注幻灯片和所有子页眉占位符可见
        headerFooterManager.setSlideNumberAndChildSlideNumbersVisibility(true); // 使母版备注幻灯片和所有子幻灯片编号占位符可见
        headerFooterManager.setDateTimeAndChildDateTimesVisibility(true); // 使母版备注幻灯片和所有子日期和时间占位符可见

        headerFooterManager.setHeaderAndChildHeadersText("Header text"); // 将文本设置到母版备注幻灯片和所有子页眉占位符
        headerFooterManager.setFooterAndChildFootersText("Footer text"); // 将文本设置到母版备注幻灯片和所有子页脚占位符
        headerFooterManager.setDateTimeAndChildDateTimesText("Date and time text"); // 将文本设置到母版备注幻灯片和所有子日期和时间占位符
    }

    // 更改仅第一张备注幻灯片的页眉和页脚设置
    INotesSlide notesSlide = pres.getSlides().get_Item(0).getNotesSlideManager().getNotesSlide();
    if (notesSlide != null)
    {
        INotesSlideHeaderFooterManager headerFooterManager = notesSlide.getHeaderFooterManager();
        if (!headerFooterManager.isHeaderVisible())
            headerFooterManager.setHeaderVisibility(true); // 使此备注幻灯片的页眉占位符可见

        if (!headerFooterManager.isFooterVisible())
            headerFooterManager.setFooterVisibility(true); // 使此备注幻灯片的页脚占位符可见

        if (!headerFooterManager.isSlideNumberVisible())
            headerFooterManager.setSlideNumberVisibility(true); // 使此备注幻灯片的幻灯片编号占位符可见

        if (!headerFooterManager.isDateTimeVisible())
            headerFooterManager.setDateTimeVisibility(true); // 使此备注幻灯片的日期时间占位符可见

        headerFooterManager.setHeaderText("New header text"); // 将文本设置到备注幻灯片的页眉占位符
        headerFooterManager.setFooterText("New footer text"); // 将文本设置到备注幻灯片的页脚占位符
        headerFooterManager.setDateTimeText("New date and time text"); // 将文本设置到备注幻灯片的日期时间占位符
    }
    pres.save("testresult.pptx",SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **常见问题**

**我可以在普通幻灯片上添加“页眉”吗？**

在 PowerPoint 中，"页眉"仅适用于备注和讲义；在普通幻灯片上，支持的元素是页脚、日期/时间和幻灯片编号。在 Aspose.Slides 中也遵循相同的限制：页眉仅用于备注/讲义，而在幻灯片上只能使用页脚/日期时间/幻灯片编号。

**如果布局不包含页脚区域，我可以“打开”其可见性吗？**

可以。通过页眉/页脚管理器检查可见性，并在需要时启用它。这些 API 标识和方法专为占位符缺失或隐藏的情况设计。

**如何让幻灯片编号从除 1 之外的值开始？**

设置演示文稿的[first slide number](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#setFirstSlideNumber-int-); 之后所有编号会重新计算。例如，可以从 0 或 10 开始，并在标题幻灯片上隐藏编号。

**导出为 PDF/图像/HTML 时，页眉/页脚会怎样？**

它们会作为演示文稿的普通文本元素进行渲染。也就是说，如果这些元素在幻灯片或备注页上可见，则它们也会随同其他内容出现在输出的 PDF、图像或 HTML 中。