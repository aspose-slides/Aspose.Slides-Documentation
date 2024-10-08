---
title: 动画文本
type: docs
weight: 60
url: /net/animated-text/
keywords: "动画文本, 动画效果, PowerPoint 演示文稿, C#, Csharp, Aspose.Slides for .NET"
description: "在 C# 或 .NET 中为 PowerPoint 演示文稿添加动画文本和效果"
---

## 为段落添加动画效果

我们将 [**AddEffect()**](https://reference.aspose.com/slides/net/aspose.slides.animation/sequence/methods/addeffect/index) 方法添加到 [**Sequence**](https://reference.aspose.com/slides/net/aspose.slides.animation/sequence) 和 [**ISequence**](https://reference.aspose.com/slides/net/aspose.slides.animation/isequence) 类中。此方法允许您为单个段落添加动画效果。以下示例代码展示了如何为单个段落添加动画效果：

```c#
using (Presentation presentation = new Presentation(dataDir + "Presentation1.pptx"))
{
    // 选择要添加效果的段落
    IAutoShape autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
    IParagraph paragraph = autoShape.TextFrame.Paragraphs[0];

    // 为选定的段落添加飞入动画效果
    IEffect effect = presentation.Slides[0].Timeline.MainSequence.AddEffect(paragraph, EffectType.Fly, EffectSubtype.Left, EffectTriggerType.OnClick);

    presentation.Save(dataDir + "AnimationEffectinParagraph.pptx", SaveFormat.Pptx);
}
```

## 获取段落中的动画效果

您可能想要了解添加到段落中的动画效果，例如，在一种情况下，您希望获取段落中的动画效果，因为您计划将这些效果应用于另一个段落或形状。

Aspose.Slides for .NET 允许您获取文本框（形状）中包含的段落上应用的所有动画效果。以下示例代码展示了如何获取段落中的动画效果：

```c#
using (Presentation pres = new Presentation("Test.pptx"))
{
	ISequence sequence = pres.Slides[0].Timeline.MainSequence;
	IAutoShape autoShape = (IAutoShape)pres.Slides[0].Shapes[1];

	foreach (IParagraph paragraph in autoShape.TextFrame.Paragraphs)
	{
		IEffect[] effects = sequence.GetEffectsByParagraph(paragraph);

		if (effects.Length > 0)
			Console.WriteLine("段落 \"" + paragraph.Text + "\" 有 " + effects[0].Type + " 效果。");
	}
}
```