---
title: 在 Android 上管理演示文稿页眉和页脚
linktitle: 页眉和页脚
type: docs
weight: 140
url: /zh/androidjava/presentation-header-and-footer/
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
- Android
- Java
- Aspose.Slides
description: "使用 Aspose.Slides for Android via Java 为 PowerPoint 和 OpenDocument 演示文稿添加并自定义页眉和页脚，以实现专业外观。"
---

{{% alert color="primary" %}} 

[Aspose.Slides](/slides/zh/androidjava/) 提供对幻灯片页眉和页脚文本的支持，这些文本实际上在幻灯片母版级别进行维护。

{{% /alert %}} 

[Aspose.Slides for Android via Java](/slides/zh/androidjava/) 提供在演示文稿幻灯片中管理页眉和页脚的功能。这些实际上在演示文稿母版级别进行管理。

## **在演示文稿中管理页眉和页脚**
某些特定幻灯片的备注可以如下面示例所示删除：
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
// 设置页眉/页脚文本
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


## **在讲义页和备注页上管理页眉和页脚**
Aspose.Slides for Android via Java 支持讲义页和备注页的页眉和页脚。请按以下步骤操作：

- 加载包含视频的 [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation)。
- 更改备注母版和所有备注页的页眉和页脚设置。
- 使主备注页以及所有子页的 Footer 占位符可见。
- 使主备注页以及所有子页的 Date 和 Time 占位符可见。
- 仅更改第一页备注的页眉和页脚设置。
- 设置备注页的 Header 占位符可见。
- 为备注页的 Header 占位符设置文本。
- 为备注页的 Date‑time 占位符设置文本。
- 写入修改后的演示文稿文件。

下面示例提供了代码片段。
```java
Presentation pres = new Presentation("presentation.pptx");
try {
    // 更改备注母版及所有备注幻灯片的页眉和页脚设置
    IMasterNotesSlide masterNotesSlide = pres.getMasterNotesSlideManager().getMasterNotesSlide();
    if (masterNotesSlide != null)
    {
        IMasterNotesSlideHeaderFooterManager headerFooterManager = masterNotesSlide.getHeaderFooterManager();

        headerFooterManager.setHeaderAndChildHeadersVisibility(true); // 使主备注幻灯片及所有子页脚占位符可见
        headerFooterManager.setFooterAndChildFootersVisibility(true); // 使主备注幻灯片及所有子页眉占位符可见
        headerFooterManager.setSlideNumberAndChildSlideNumbersVisibility(true); // 使主备注幻灯片及所有子幻灯片编号占位符可见
        headerFooterManager.setDateTimeAndChildDateTimesVisibility(true); // 使主备注幻灯片及所有子日期和时间占位符可见

        headerFooterManager.setHeaderAndChildHeadersText("Header text"); // 将文本设置到主备注幻灯片及所有子页眉占位符
        headerFooterManager.setFooterAndChildFootersText("Footer text"); // 将文本设置到主备注幻灯片及所有子页脚占位符
        headerFooterManager.setDateTimeAndChildDateTimesText("Date and time text"); // 将文本设置到主备注幻灯片及所有子日期和时间占位符
    }

    // 仅更改第一张备注幻灯片的页眉和页脚设置
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


## **FAQ**

**我可以在普通幻灯片上添加“页眉”吗？**

在 PowerPoint 中，“页眉”仅在备注和讲义页存在；在普通幻灯片上，仅支持页脚、日期/时间和幻灯片编号。Aspose.Slides 的限制与此相同：页眉仅用于备注/讲义页，普通幻灯片上只能使用 Footer/DateTime/SlideNumber。

**如果布局中没有页脚区域，我可以“打开”其可见性吗？**

可以。通过页眉/页脚管理器检查可见性，并在需要时启用。这些 API 指标和方法专为占位符缺失或隐藏的情况设计。

**如何让幻灯片编号从除 1 之外的其他值开始？**

设置演示文稿的 [first slide number](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#setFirstSlideNumber-int-)；随后所有编号都会重新计算。例如，可从 0 或 10 开始，并在标题幻灯片上隐藏编号。

**导出为 PDF/图片/HTML 时，页眉/页脚会怎样？**

它们会作为演示文稿的普通文本元素进行渲染。也就是说，如果这些元素在幻灯片/备注页上可见，输出格式中也会随其他内容一起显示。