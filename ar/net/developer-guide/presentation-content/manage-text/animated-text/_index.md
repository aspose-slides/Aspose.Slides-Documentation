---
title: نص متحرك
type: docs
weight: 60
url: /ar/net/animated-text/
keywords: "نص متحرك، تأثيرات الرسوم المتحركة، عرض باوربوينت، C#، Csharp، Aspose.Slides لـ .NET"
description: "أضف نصوصًا متحركة وتأثيرات لعرض باوربوينت باستخدام C# أو .NET"
---

## إضافة تأثيرات الرسوم المتحركة إلى الفقرات

أضفنا طريقة [**AddEffect()**](https://reference.aspose.com/slides/net/aspose.slides.animation/sequence/methods/addeffect/index) إلى فئتي [**Sequence**](https://reference.aspose.com/slides/net/aspose.slides.animation/sequence) و [**ISequence**](https://reference.aspose.com/slides/net/aspose.slides.animation/isequence). تتيح لك هذه الطريقة إضافة تأثيرات الرسوم المتحركة إلى فقرة واحدة. يشير هذا الكود المثال إلى كيفية إضافة تأثير رسوم متحركة إلى فقرة واحدة:

```c#
using (Presentation presentation = new Presentation(dataDir + "Presentation1.pptx"))
{
    // اختر الفقرة لإضافة التأثير
    IAutoShape autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
    IParagraph paragraph = autoShape.TextFrame.Paragraphs[0];

    // أضف تأثير الرسوم المتحركة "Fly" إلى الفقرة المحددة
    IEffect effect = presentation.Slides[0].Timeline.MainSequence.AddEffect(paragraph, EffectType.Fly, EffectSubtype.Left, EffectTriggerType.OnClick);


    presentation.Save(dataDir + "AnimationEffectinParagraph.pptx", SaveFormat.Pptx);
}
```



## الحصول على تأثيرات الرسوم المتحركة في الفقرات

قد تقرر معرفة تأثيرات الرسوم المتحركة المضافة إلى فقرة—على سبيل المثال، في سيناريو واحد، تريد الحصول على تأثيرات الرسوم المتحركة في فقرة لأنك تخطط لتطبيق تلك التأثيرات على فقرة أو شكل آخر.

تتيح لك Aspose.Slides لـ .NET الحصول على جميع تأثيرات الرسوم المتحركة المطبقة على الفقرات الموجودة في إطار نص (شكل). يشير هذا الكود المثال إلى كيفية الحصول على تأثيرات الرسوم المتحركة في فقرة:

```c#
using (Presentation pres = new Presentation("Test.pptx"))
{
	ISequence sequence = pres.Slides[0].Timeline.MainSequence;
	IAutoShape autoShape = (IAutoShape)pres.Slides[0].Shapes[1];

	foreach (IParagraph paragraph in autoShape.TextFrame.Paragraphs)
	{
		IEffect[] effects = sequence.GetEffectsByParagraph(paragraph);

		if (effects.Length > 0)
			Console.WriteLine("الفقرة \"" + paragraph.Text + "\" تحتوي على تأثير " + effects[0].Type + ".");
	}
}
```