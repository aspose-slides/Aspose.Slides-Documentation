---
title: 演示文稿页眉和页脚
type: docs
weight: 140
url: /zh/nodejs-java/presentation-header-and-footer/
keywords: "JavaScript 中的 PowerPoint 页眉和页脚"
description: "JavaScript 中的 PowerPoint 页眉和页脚"
---

{{% alert color="primary" %}}

[Aspose.Slides](/slides/zh/nodejs-java/) 提供对幻灯片页眉和页脚文本的支持，这些文本实际上在幻灯片母版层面维护。

{{% /alert %}}

[Aspose.Slides for Node.js via Java](/slides/zh/nodejs-java/) 提供在演示文稿幻灯片中管理页眉和页脚的功能。这些实际上在演示文稿母版层面管理。

## **在演示文稿中管理页眉和页脚**
可以删除某些特定幻灯片的备注，如下例所示：
```javascript
// 加载演示文稿
var pres = new aspose.slides.Presentation("headerTest.pptx");
try {
    // 设置页脚
    pres.getHeaderFooterManager().setAllFootersText("My Footer text");
    pres.getHeaderFooterManager().setAllFootersVisibility(true);
    // 访问并更新页眉
    var masterNotesSlide = pres.getMasterNotesSlideManager().getMasterNotesSlide();
    if (null != masterNotesSlide) {
        updateHeaderFooterText(masterNotesSlide);
    }
    // 保存演示文稿
    pres.save("HeaderFooterJava.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

```javascript
function updateHeaderFooterText(master) {
    let shapes = master.getShapes();
    for (let i = 0; i < shapes.size(); i++) {
        let shape = shapes.get_Item(i); 
        if (shape.getPlaceholder() !== null) {
            if (shape.getPlaceholder().getType() === aspose.PlaceholderType.Header) {
                shape.getTextFrame().setText("HI there new header");
            }
        }
    }
}
```


## **在讲义和备注幻灯片中管理页眉和页脚**
Aspose.Slides for Node.js via Java 支持讲义和备注幻灯片中的页眉和页脚。请按照以下步骤操作：

- 加载包含视频的[Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation)。
- 更改备注母版和所有备注幻灯片的页眉和页脚设置。
- 将母版备注幻灯片和所有子级页脚占位符设置为可见。
- 将母版备注幻灯片和所有子级日期和时间占位符设置为可见。
- 仅更改第一张备注幻灯片的页眉和页脚设置。
- 将备注幻灯片的页眉占位符设置为可见。
- 为备注幻灯片的页眉占位符设置文本。
- 为备注幻灯片的日期时间占位符设置文本。
- 写入修改后的演示文稿文件。

下面示例提供了代码片段。
```javascript
var pres = new aspose.slides.Presentation("presentation.pptx");
try {
    // 更改笔记母版和所有笔记幻灯片的页眉和页脚设置
    var masterNotesSlide = pres.getMasterNotesSlideManager().getMasterNotesSlide();
    if (masterNotesSlide != null) {
        var headerFooterManager = masterNotesSlide.getHeaderFooterManager();
        headerFooterManager.setHeaderAndChildHeadersVisibility(true);// 使母版笔记幻灯片和所有子级页脚占位符可见
        headerFooterManager.setFooterAndChildFootersVisibility(true);// 使母版笔记幻灯片和所有子级页眉占位符可见
        headerFooterManager.setSlideNumberAndChildSlideNumbersVisibility(true);// 使母版笔记幻灯片和所有子级幻灯片编号占位符可见
        headerFooterManager.setDateTimeAndChildDateTimesVisibility(true);// 使母版笔记幻灯片和所有子级日期和时间占位符可见
        headerFooterManager.setHeaderAndChildHeadersText("Header text");// 将文本设置到母版笔记幻灯片和所有子级页眉占位符
        headerFooterManager.setFooterAndChildFootersText("Footer text");// 将文本设置到母版笔记幻灯片和所有子级页脚占位符
        headerFooterManager.setDateTimeAndChildDateTimesText("Date and time text");// 将文本设置到母版笔记幻灯片和所有子级日期和时间占位符
    }
    // 仅更改第一张笔记幻灯片的页眉和页脚设置
    var notesSlide = pres.getSlides().get_Item(0).getNotesSlideManager().getNotesSlide();
    if (notesSlide != null) {
        var headerFooterManager = notesSlide.getHeaderFooterManager();
        if (!headerFooterManager.isHeaderVisible()) {
            headerFooterManager.setHeaderVisibility(true);
        }// 使此笔记幻灯片的页眉占位符可见
        if (!headerFooterManager.isFooterVisible()) {
            headerFooterManager.setFooterVisibility(true);
        }// 使此笔记幻灯片的页脚占位符可见
        if (!headerFooterManager.isSlideNumberVisible()) {
            headerFooterManager.setSlideNumberVisibility(true);
        }// 使此笔记幻灯片的幻灯片编号占位符可见
        if (!headerFooterManager.isDateTimeVisible()) {
            headerFooterManager.setDateTimeVisibility(true);
        }// 使此笔记幻灯片的日期时间占位符可见
        headerFooterManager.setHeaderText("New header text");// 将文本设置到笔记幻灯片的页眉占位符
        headerFooterManager.setFooterText("New footer text");// 将文本设置到笔记幻灯片的页脚占位符
        headerFooterManager.setDateTimeText("New date and time text");// 将文本设置到笔记幻灯片的日期时间占位符
    }
    pres.save("testresult.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **常见问题**

**我可以在普通幻灯片上添加“页眉”吗？**

在 PowerPoint 中，“页眉”仅在备注和讲义中存在；在普通幻灯片上，支持的元素是页脚、日期/时间和幻灯片编号。在 Aspose.Slides 中也遵循相同的限制：页眉仅用于备注/讲义，而在幻灯片上支持页脚、日期时间和幻灯片编号。

**如果布局不包含页脚区域——我可以“打开”它的可见性吗？**

可以。通过页眉/页脚管理器检查可见性，并在需要时启用它。这些 API 指示器和方法旨在处理占位符缺失或隐藏的情况。

**如何让幻灯片编号从除 1 之外的其他值开始？**

设置演示文稿的[first slide number](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/setfirstslidenumber/)；之后，所有编号都会重新计算。例如，可以从 0 或 10 开始，并在标题幻灯片上隐藏编号。

**导出为 PDF/图像/HTML 时，页眉/页脚会怎样？**

它们会作为演示文稿的普通文本元素进行渲染。也就是说，如果这些元素在幻灯片/备注页上可见，它们也会随同其余内容一起出现在输出的 PDF、图像或 HTML 中。