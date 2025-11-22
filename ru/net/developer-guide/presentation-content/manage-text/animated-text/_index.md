---
title: Анимированный текст
type: docs
weight: 60
url: /ru/net/animated-text/
keywords: "Анимированный текст, Эффекты анимации, Презентация PowerPoint, C#, Csharp, Aspose.Slides for .NET"
description: "Добавьте анимированный текст и эффекты в презентацию PowerPoint на C# или .NET"
---

## **Добавление анимационных эффектов в абзацы**

Мы добавили метод [**AddEffect()**](https://reference.aspose.com/slides/net/aspose.slides.animation/sequence/methods/addeffect/index) в классы [**Sequence**](https://reference.aspose.com/slides/net/aspose.slides.animation/sequence) и [**ISequence**](https://reference.aspose.com/slides/net/aspose.slides.animation/isequence). Этот метод позволяет добавлять анимационные эффекты к отдельному абзацу. В этом примере кода показано, как добавить анимационный эффект к отдельному абзацу:
```c#
using (Presentation presentation = new Presentation(dataDir + "Presentation1.pptx"))
{
    // выберите абзац для добавления эффекта
    IAutoShape autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
    IParagraph paragraph = autoShape.TextFrame.Paragraphs[0];

    // добавьте анимационный эффект Fly к выбранному абзацу
    IEffect effect = presentation.Slides[0].Timeline.MainSequence.AddEffect(paragraph, EffectType.Fly, EffectSubtype.Left, EffectTriggerType.OnClick);


    presentation.Save(dataDir + "AnimationEffectinParagraph.pptx", SaveFormat.Pptx);
}
```


## **Получение анимационных эффектов в абзацах**

Возможно, вам понадобится узнать, какие анимационные эффекты добавлены к абзацу — например, в одной ситуации вы хотите получить анимационные эффекты в абзаце, чтобы применить их к другому абзацу или фигуре.  
Aspose.Slides for .NET позволяет получить все анимационные эффекты, применённые к абзацам, содержащимся в текстовом кадре (фигуре). В этом примере кода показано, как получить анимационные эффекты в абзаце:
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


## **FAQ**

**Чем анимации текста отличаются от переходов слайдов и можно ли их комбинировать?**  
Анимации текста управляют поведением объекта во времени на слайде, тогда как [transitions](/slides/ru/net/slide-transition/) управляют тем, как меняются слайды. Они независимы и могут использоваться вместе; порядок воспроизведения определяется временной шкалой анимации и настройками перехода.

**Сохраняются ли анимации текста при экспорте в PDF или изображения?**  
Нет. PDF и растровые изображения являются статичными, поэтому вы увидите единственное состояние слайда без движения. Чтобы сохранить анимацию, используйте экспорт в [video](/slides/ru/net/convert-powerpoint-to-video/) или [HTML](/slides/ru/net/export-to-html5/).

**Работают ли анимации текста в макетах и шаблоне слайда?**  
Эффекты, применённые к объектам макета/шаблона, наследуются слайдами, но их сроки и взаимодействие с анимациями уровня слайда зависят от окончательной последовательности на слайде.