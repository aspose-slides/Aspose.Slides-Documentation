---
title: Animated Text
type: docs
weight: 50
url: /net/animated-text/
keywords: "Animated text in PowerPoint"
description: "Animated text in PowerPoint presentation with Aspose.Slides"
---

## Adding Animation Effects to Paragraphs

We added the [**AddEffect()**](https://apireference.aspose.com/net/slides/aspose.slides.animation/sequence/methods/addeffect/index) method to the [**Sequence**](https://apireference.aspose.com/net/slides/aspose.slides.animation/sequence) and [**ISequence**](https://apireference.aspose.com/net/slides/aspose.slides.animation/isequence) classes. This method allows you to add animation effects to a single paragraph. This sample code shows you how to add an animation effect to a single paragraph:

```c#
using (Presentation presentation = new Presentation(dataDir + "Presentation1.pptx"))
{
    // select paragraph to add effect
    IAutoShape autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
    IParagraph paragraph = autoShape.TextFrame.Paragraphs[0];

    // add Fly animation effect to selected paragraph
    IEffect effect = presentation.Slides[0].Timeline.MainSequence.AddEffect(paragraph, EffectType.Fly, EffectSubtype.Left, EffectTriggerType.OnClick);


    presentation.Save(dataDir + "AnimationEffectinParagraph.pptx", SaveFormat.Pptx);
}
```



## Getting the Animation Effects in Paragraphs

You may decide to find out the animation effects added to a paragraph—for example, in one scenario, you want to get the animation effects in a paragraph because you plan to apply those effects to another paragraph or shape.

Aspose.Slides for .NET allows you to get all the animation effects applied to paragraphs contained in a text frame (shape). This sample code shows you how to get the animation effects in a paragraph:

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

