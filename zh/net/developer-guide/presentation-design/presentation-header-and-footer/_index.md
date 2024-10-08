---
title: 演示文稿页眉和页脚
type: docs
weight: 140
url: /net/presentation-header-and-footer/
keywords: "页眉, 页脚, 设置页眉, 设置页脚, 设置页眉和页脚, PowerPoint 演示文稿, C#, Csharp, Aspose.Slides for .NET"
description: "在 C# 或 .NET 中的 PowerPoint 页眉和页脚"
---

{{% alert color="primary" %}} 

[Aspose.Slides](/slides/net/) 提供了对幻灯片的页眉和页脚文本的支持，这些文本实际上是在幻灯片母版级别维护的。

{{% /alert %}} 

[Aspose.Slides for .NET](/slides/net/) 提供了在演示文稿幻灯片中管理页眉和页脚的功能。实际上这些是在演示文稿母版级别管理的。
## **管理页眉和页脚文本**
某些特定幻灯片的注释可以按照下面的示例进行更新：

```c#
// 加载演示文稿
Presentation pres = new Presentation("headerTest.pptx");

// 设置页脚
pres.HeaderFooterManager.SetAllFootersText("我的页脚文本");
pres.HeaderFooterManager.SetAllFootersVisibility(true);

// 访问并更新页眉
IMasterNotesSlide masterNotesSlide = pres.MasterNotesSlideManager.MasterNotesSlide;
if (null != masterNotesSlide)
{
	UpdateHeaderFooterText(masterNotesSlide);
}

// 保存演示文稿
pres.Save("HeaderFooterJava.pptx", SaveFormat.Pptx);
```



```c#
// 设置页眉/页脚文本的方法
public static void UpdateHeaderFooterText(IBaseSlide master)
{
    foreach (IShape shape in master.Shapes)
    {
        if (shape.Placeholder != null)
        {
            if (shape.Placeholder.Type == PlaceholderType.Header)
            {
                ((IAutoShape)shape).TextFrame.Text = "你好，新页眉";
            }
        }
    }
}
```




## **在讲义和笔记幻灯片中管理页眉和页脚**
Aspose.Slides for .NET 支持在讲义和笔记幻灯片中使用页眉和页脚。请按照以下步骤操作：

- 加载一个包含视频的 [演示文稿](https://reference.aspose.com/slides/net/aspose.slides/presentation)。
- 更改笔记母版和所有笔记幻灯片的页眉和页脚设置。
- 使母版笔记幻灯片和所有子页脚占位符可见。
- 使母版笔记幻灯片和所有子日期和时间占位符可见。
- 仅更改第一个笔记幻灯片的页眉和页脚设置。
- 使笔记幻灯片页眉占位符可见。
- 设置文本到笔记幻灯片页眉占位符。
- 设置文本到笔记幻灯片日期时间占位符。
- 写入修改后的演示文稿文件。

下面示例中提供的代码片段。

```c#
using (Presentation presentation = new Presentation("presentation.pptx"))
{
	// 更改笔记母版和所有笔记幻灯片的页眉和页脚设置
	IMasterNotesSlide masterNotesSlide = presentation.MasterNotesSlideManager.MasterNotesSlide;
	if (masterNotesSlide != null)
	{
		IMasterNotesSlideHeaderFooterManager headerFooterManager = masterNotesSlide.HeaderFooterManager;

		headerFooterManager.SetHeaderAndChildHeadersVisibility(true); // 使母版笔记幻灯片和所有子页脚占位符可见
		headerFooterManager.SetFooterAndChildFootersVisibility(true); // 使母版笔记幻灯片和所有子页眉占位符可见
		headerFooterManager.SetSlideNumberAndChildSlideNumbersVisibility(true); // 使母版笔记幻灯片和所有子幻灯片编号占位符可见
		headerFooterManager.SetDateTimeAndChildDateTimesVisibility(true); // 使母版笔记幻灯片和所有子日期和时间占位符可见

		headerFooterManager.SetHeaderAndChildHeadersText("页眉文本"); // 设置母版笔记幻灯片和所有子页眉占位符的文本
		headerFooterManager.SetFooterAndChildFootersText("页脚文本"); // 设置母版笔记幻灯片和所有子页脚占位符的文本
		headerFooterManager.SetDateTimeAndChildDateTimesText("日期和时间文本"); // 设置母版笔记幻灯片和所有子日期和时间占位符的文本
	}

	// 仅更改第一个笔记幻灯片的页眉和页脚设置
	INotesSlide notesSlide = presentation.Slides[0].NotesSlideManager.NotesSlide;
	if (notesSlide != null)
	{
		INotesSlideHeaderFooterManager headerFooterManager = notesSlide.HeaderFooterManager;
		if (!headerFooterManager.IsHeaderVisible)
			headerFooterManager.SetHeaderVisibility(true); // 使此笔记幻灯片页眉占位符可见

		if (!headerFooterManager.IsFooterVisible)
			headerFooterManager.SetFooterVisibility(true); // 使此笔记幻灯片页脚占位符可见

		if (!headerFooterManager.IsSlideNumberVisible)
			headerFooterManager.SetSlideNumberVisibility(true); // 使此笔记幻灯片幻灯片编号占位符可见

		if (!headerFooterManager.IsDateTimeVisible)
			headerFooterManager.SetDateTimeVisibility(true); // 使此笔记幻灯片日期时间占位符可见

		headerFooterManager.SetHeaderText("新页眉文本"); // 设置文本到笔记幻灯片页眉占位符
		headerFooterManager.SetFooterText("新页脚文本"); // 设置文本到笔记幻灯片页脚占位符
		headerFooterManager.SetDateTimeText("新日期和时间文本"); // 设置文本到笔记幻灯片日期时间占位符
	}
	presentation.Save("testresult.pptx",SaveFormat.Pptx);
}
		
 }
```