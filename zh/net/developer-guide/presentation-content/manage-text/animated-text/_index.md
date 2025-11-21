---
title: 在 .NET 中为 PowerPoint 文本添加动画
linktitle: 动画文本
type: docs
weight: 60
url: /zh/net/animated-text/
keywords:
- 动画文本
- 文本动画
- 动画段落
- 段落动画
- 动画效果
- PowerPoint
- 演示文稿
- .NET
- C#
- Aspose.Slides
description: "使用 Aspose.Slides for .NET 在 PowerPoint 和 OpenDocument 演示文稿中创建动态动画文本，提供易于遵循、经过优化的 C# 代码示例。"
---

## **向段落添加动画效果**

我们在 [**Sequence**](https://reference.aspose.com/slides/net/aspose.slides.animation/sequence) 和 [**ISequence**](https://reference.aspose.com/slides/net/aspose.slides.animation/isequence) 类中添加了 [**AddEffect()**](https://reference.aspose.com/slides/net/aspose.slides.animation/sequence/methods/addeffect/index) 方法。此方法允许您向单个段落添加动画效果。以下示例代码演示如何向单个段落添加动画效果：
```c#
using (Presentation presentation = new Presentation(dataDir + "Presentation1.pptx"))
{
    // 选择要添加效果的段落
    IAutoShape autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
    IParagraph paragraph = autoShape.TextFrame.Paragraphs[0];

    // 为选中的段落添加 Fly 动画效果
    IEffect effect = presentation.Slides[0].Timeline.MainSequence.AddEffect(paragraph, EffectType.Fly, EffectSubtype.Left, EffectTriggerType.OnClick);


    presentation.Save(dataDir + "AnimationEffectinParagraph.pptx", SaveFormat.Pptx);
}
```


## **获取段落中的动画效果**

您可能需要查找已添加到段落的动画效果——例如，在某些情况下，您想获取段落中的动画效果，以便将这些效果应用到另一个段落或形状。

Aspose.Slides for .NET 允许您获取文本框（形状）中段落所应用的所有动画效果。以下示例代码演示如何获取段落中的动画效果：
```c#
using (Presentation pres = new Presentation("Test.pptx"))
{
	ISequence sequence = pres.Slides[0].Timeline.MainSequence;
	IAutoShape autoShape = (IAutoShape)pres.Slides[0].Shapes[1];

	foreach (IParagraph paragraph in autoShape.TextFrame.Paragraphs)
	{
		IEffect[] effects = sequence.GetEffectsByParagraph(paragraph);

		if (effects.Length > 0)
			Console.WriteLine("Paragraph \"" + paragraph.Text + "\" has " + effects[0].Type + " effect.");
	}
}
```


## **常见问题**

**文本动画与幻灯片切换有何不同，能够组合使用吗？**

文本动画控制对象在幻灯片上的随时间变化，而[transitions](/slides/zh/net/slide-transition/) 控制幻灯片之间的切换方式。它们相互独立，但可以一起使用；播放顺序由动画时间轴和切换设置决定。

**导出为 PDF 或图像时，文本动画会保留吗？**

不会。PDF 和栅格图像是静态的，因此您只能看到幻灯片的单一状态，没有动画。若要保留动画，请使用[video](/slides/zh/net/convert-powerpoint-to-video/)或[HTML](/slides/zh/net/export-to-html5/) 导出。

**文本动画在布局和母版中有效吗？**

应用于布局/母版对象的效果会被幻灯片继承，但它们的时间安排以及与幻灯片级别动画的交互取决于幻灯片上的最终序列。