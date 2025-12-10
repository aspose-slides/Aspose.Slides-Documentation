---
title: Анимировать текст PowerPoint в .NET
linktitle: Анимированный текст
type: docs
weight: 60
url: /ru/net/animated-text/
keywords:
- анимированный текст
- анимация текста
- анимированный абзац
- анимация абзаца
- анимационный эффект
- PowerPoint
- презентация
- .NET
- C#
- Aspose.Slides
description: "Создавайте динамический анимированный текст в презентациях PowerPoint и OpenDocument с помощью Aspose.Slides для .NET, используя простые для восприятия, оптимизированные примеры кода C#."
---

## **Добавление анимационных эффектов к абзацам**

Мы добавили метод [**AddEffect()**](https://reference.aspose.com/slides/net/aspose.slides.animation/sequence/methods/addeffect/index) в классы [**Sequence**](https://reference.aspose.com/slides/net/aspose.slides.animation/sequence) и [**ISequence**](https://reference.aspose.com/slides/net/aspose.slides.animation/isequence). Этот метод позволяет добавить анимационный эффект к отдельному абзацу. Пример кода демонстрирует, как добавить анимационный эффект к отдельному абзацу:
```c#
using (Presentation presentation = new Presentation(dataDir + "Presentation1.pptx"))
{
    // выбрать абзац для добавления эффекта
    IAutoShape autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
    IParagraph paragraph = autoShape.TextFrame.Paragraphs[0];

    // добавить анимационный эффект Fly к выбранному абзацу
    IEffect effect = presentation.Slides[0].Timeline.MainSequence.AddEffect(paragraph, EffectType.Fly, EffectSubtype.Left, EffectTriggerType.OnClick);


    presentation.Save(dataDir + "AnimationEffectinParagraph.pptx", SaveFormat.Pptx);
}
```


## **Получение анимационных эффектов для абзацев**

Возможно, вам потребуется определить анимационные эффекты, применённые к абзацу — например, в одной из ситуаций вы хотите получить эффекты абзаца, чтобы применить их к другому абзацу или фигуре.

Aspose.Slides для .NET позволяет получить все анимационные эффекты, применённые к абзацам, содержащимся в текстовом фрейме (shape). Пример кода показывает, как получить анимационные эффекты в абзаце:
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

Анимации текста управляют поведением объектов во времени на слайде, тогда как [transitions](/slides/ru/net/slide-transition/) управляют сменой слайдов. Они независимы и могут использоваться вместе; порядок воспроизведения определяется тайм‑линией анимации и настройками переходов.

**Сохраняются ли анимации текста при экспортировании в PDF или изображения?**

Нет. PDF и растровые изображения статичны, поэтому вы увидите единственное состояние слайда без движения. Чтобы сохранить анимацию, используйте экспорт в [video](/slides/ru/net/convert-powerpoint-to-video/) или [HTML](/slides/ru/net/export-to-html5/).

**Работают ли анимации текста в макетах и мастер‑слайде?**

Эффекты, применённые к объектам макета/мастера, наследуются слайдами, но их тайминг и взаимодействие с анимациями уровня слайда зависят от окончательной последовательности на слайде.