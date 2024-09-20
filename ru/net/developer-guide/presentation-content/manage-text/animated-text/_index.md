---
title: Анимированный текст
type: документы
weight: 60
url: /net/animated-text/
keywords: "Анимированный текст, Эффекты анимации, Презентация PowerPoint, C#, Csharp, Aspose.Slides для .NET"
description: "Добавьте анимированный текст и эффекты в презентацию PowerPoint на C# или .NET"
---

## Добавление эффектов анимации к абзацам

Мы добавили метод [**AddEffect()**](https://reference.aspose.com/slides/net/aspose.slides.animation/sequence/methods/addeffect/index) к классам [**Sequence**](https://reference.aspose.com/slides/net/aspose.slides.animation/sequence) и [**ISequence**](https://reference.aspose.com/slides/net/aspose.slides.animation/isequence). Этот метод позволяет добавлять эффекты анимации к одному абзацу. Этот пример кода показывает, как добавить эффект анимации к одному абзацу:

```c#
using (Presentation presentation = new Presentation(dataDir + "Presentation1.pptx"))
{
    // выбрать абзац для добавления эффекта
    IAutoShape autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
    IParagraph paragraph = autoShape.TextFrame.Paragraphs[0];

    // добавить эффект анимации "Лететь" к выбранному абзацу
    IEffect effect = presentation.Slides[0].Timeline.MainSequence.AddEffect(paragraph, EffectType.Fly, EffectSubtype.Left, EffectTriggerType.OnClick);

    presentation.Save(dataDir + "AnimationEffectinParagraph.pptx", SaveFormat.Pptx);
}
```

## Получение эффектов анимации в абзацах

Вы можете решить выяснить, какие эффекты анимации добавлены к абзацу — например, в одном сценарии вы хотите получить эффекты анимации в абзаце, потому что планируете применить эти эффекты к другому абзацу или фигуре.

Aspose.Slides для .NET позволяет вам получить все эффекты анимации, примененные к абзацам, содержащимся в текстовом фрейме (фигуре). Этот пример кода показывает, как получить эффекты анимации в абзаце:

```c#
using (Presentation pres = new Presentation("Test.pptx"))
{
	ISequence sequence = pres.Slides[0].Timeline.MainSequence;
	IAutoShape autoShape = (IAutoShape)pres.Slides[0].Shapes[1];

	foreach (IParagraph paragraph in autoShape.TextFrame.Paragraphs)
	{
		IEffect[] effects = sequence.GetEffectsByParagraph(paragraph);

		if (effects.Length > 0)
			Console.WriteLine("Абзац \"" + paragraph.Text + "\" имеет эффект " + effects[0].Type + ".");
	}
}
```