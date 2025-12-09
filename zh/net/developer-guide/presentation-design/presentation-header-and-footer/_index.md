---
title: 在 .NET 中管理演示文稿标题和页脚
linktitle: 标题和页脚
type: docs
weight: 140
url: /zh/net/presentation-header-and-footer/
keywords:
- 标题
- 标题文本
- 页脚
- 页脚文本
- 设置标题
- 设置页脚
- 讲义
- 备注
- PowerPoint
- OpenDocument
- 演示文稿
- .NET
- C#
- Aspose.Slides
description: "使用 Aspose.Slides for .NET 在 PowerPoint 和 OpenDocument 演示文稿中添加和自定义标题和页脚，以获得专业外观。"
---

{{% alert color="primary" %}} 

[Aspose.Slides](/slides/zh/net/) 提供了在幻灯片母版级别维护的幻灯片标题和页脚文本的支持。

{{% /alert %}} 

[Aspose.Slides for .NET](/slides/zh/net/) 提供了在演示文稿幻灯片内部管理标题和页脚的功能。这些实际上在演示文稿母版级别进行管理。

## **管理标题和页脚文本**
某些特定幻灯片的备注可以按照下面示例进行更新：
```c#
// 加载演示文稿
Presentation pres = new Presentation("headerTest.pptx");

// 设置页脚
pres.HeaderFooterManager.SetAllFootersText("My Footer text");
pres.HeaderFooterManager.SetAllFootersVisibility(true);

// 访问并更新标题
IMasterNotesSlide masterNotesSlide = pres.MasterNotesSlideManager.MasterNotesSlide;
if (null != masterNotesSlide)
{
	UpdateHeaderFooterText(masterNotesSlide);
}

// 保存演示文稿
pres.Save("HeaderFooterJava.pptx", SaveFormat.Pptx);
```

```c#
// 设置标题/页脚文本的方法
public static void UpdateHeaderFooterText(IBaseSlide master)
{
    foreach (IShape shape in master.Shapes)
    {
        if (shape.Placeholder != null)
        {
            if (shape.Placeholder.Type == PlaceholderType.Header)
            {
                ((IAutoShape)shape).TextFrame.Text = "HI there new header";
            }
        }
    }
}
```





## **在讲义和备注幻灯片中管理标题和页脚**
Aspose.Slides for .NET 支持在讲义和备注幻灯片中使用标题和页脚。请按照以下步骤操作：

- 加载包含视频的 [Presentation ](https://reference.aspose.com/slides/net/aspose.slides/presentation)。
- 更改备注母版和所有备注幻灯片的标题和页脚设置。
- 将母版备注幻灯片及所有子页脚占位符设为可见。
- 将母版备注幻灯片及所有子日期和时间占位符设为可见。
- 仅更改第一张备注幻灯片的标题和页脚设置。
- 将备注幻灯片的标题占位符设为可见。
- 为备注幻灯片的标题占位符设置文本。
- 为备注幻灯片的日期时间占位符设置文本。
- 写入修改后的演示文稿文件。

以下示例中提供了代码片段。
```c#
using (Presentation presentation = new Presentation("presentation.pptx"))
{
	// 更改备注母版以及所有备注幻灯片的标题和页脚设置
	IMasterNotesSlide masterNotesSlide = presentation.MasterNotesSlideManager.MasterNotesSlide;
	if (masterNotesSlide != null)
	{
		IMasterNotesSlideHeaderFooterManager headerFooterManager = masterNotesSlide.HeaderFooterManager;

		headerFooterManager.SetHeaderAndChildHeadersVisibility(true); // 使母版备注幻灯片以及所有子页脚占位符可见
		headerFooterManager.SetFooterAndChildFootersVisibility(true); // 使母版备注幻灯片以及所有子标题占位符可见
		headerFooterManager.SetSlideNumberAndChildSlideNumbersVisibility(true); // 使母版备注幻灯片以及所有子幻灯片编号占位符可见
		headerFooterManager.SetDateTimeAndChildDateTimesVisibility(true); // 使母版备注幻灯片以及所有子日期和时间占位符可见

		headerFooterManager.SetHeaderAndChildHeadersText("Header text"); // 将文本设置到母版备注幻灯片以及所有子标题占位符
		headerFooterManager.SetFooterAndChildFootersText("Footer text"); // 将文本设置到母版备注幻灯片以及所有子页脚占位符
		headerFooterManager.SetDateTimeAndChildDateTimesText("Date and time text"); // 将文本设置到母版备注幻灯片以及所有子日期和时间占位符
	}

	// 仅更改第一张备注幻灯片的标题和页脚设置
	INotesSlide notesSlide = presentation.Slides[0].NotesSlideManager.NotesSlide;
	if (notesSlide != null)
	{
		INotesSlideHeaderFooterManager headerFooterManager = notesSlide.HeaderFooterManager;
		if (!headerFooterManager.IsHeaderVisible)
			headerFooterManager.SetHeaderVisibility(true); // 使此备注幻灯片的标题占位符可见

		if (!headerFooterManager.IsFooterVisible)
			headerFooterManager.SetFooterVisibility(true); // 使此备注幻灯片的页脚占位符可见

		if (!headerFooterManager.IsSlideNumberVisible)
			headerFooterManager.SetSlideNumberVisibility(true); // 使此备注幻灯片的幻灯片编号占位符可见

		if (!headerFooterManager.IsDateTimeVisible)
			headerFooterManager.SetDateTimeVisibility(true); // 使此备注幻灯片的日期时间占位符可见

		headerFooterManager.SetHeaderText("New header text"); // 将文本设置到备注幻灯片的标题占位符
		headerFooterManager.SetFooterText("New footer text"); // 将文本设置到备注幻灯片的页脚占位符
		headerFooterManager.SetDateTimeText("New date and time text"); // 将文本设置到备注幻灯片的日期时间占位符
	}
	presentation.Save("testresult.pptx",SaveFormat.Pptx);
}
		
 }
```


## **常见问题**

**我可以在普通幻灯片上添加“标题”吗？**

在 PowerPoint 中，“标题”仅在备注和讲义中存在；在普通幻灯片上，仅支持页脚、日期/时间和幻灯片编号。Aspose.Slides 的限制相同：标题仅用于备注/讲义，普通幻灯片上则为页脚/日期时间/幻灯片编号。

**如果布局中没有页脚区域，我可以“打开”其可见性吗？**

是的。可以通过标题/页脚管理器检查可见性并在需要时启用它。这些 API 标识和方法专为占位符缺失或隐藏的情况设计。

**如何让幻灯片编号从除 1 之外的值开始？**

设置演示文稿的 [first slide number](https://reference.aspose.com/slides/net/aspose.slides/presentation/firstslidenumber/)；随后所有编号会重新计算。例如，可以从 0 或 10 开始，并在标题幻灯片上隐藏编号。

**导出为 PDF/图像/HTML 时标题/页脚会怎样？**

它们会作为演示文稿的常规文本元素进行渲染。也就是说，如果这些元素在幻灯片/备注页上可见，它们也会出现在输出的格式中，与其他内容一起呈现。