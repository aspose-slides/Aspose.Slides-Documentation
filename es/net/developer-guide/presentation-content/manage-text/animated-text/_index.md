---
title: Texto Animado
type: docs
weight: 60
url: /net/animated-text/
keywords: "Texto animado, Efectos de animación, Presentación de PowerPoint, C#, Csharp, Aspose.Slides para .NET"
description: "Agregue texto animado y efectos a la presentación de PowerPoint en C# o .NET"
---

## Agregar Efectos de Animación a Párrafos

Agregamos el [**AddEffect()**](https://reference.aspose.com/slides/net/aspose.slides.animation/sequence/methods/addeffect/index) método a las clases [**Sequence**](https://reference.aspose.com/slides/net/aspose.slides.animation/sequence) y [**ISequence**](https://reference.aspose.com/slides/net/aspose.slides.animation/isequence). Este método le permite agregar efectos de animación a un solo párrafo. Este código de muestra le muestra cómo agregar un efecto de animación a un solo párrafo:

```c#
using (Presentation presentation = new Presentation(dataDir + "Presentation1.pptx"))
{
    // seleccionar párrafo para agregar efecto
    IAutoShape autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
    IParagraph paragraph = autoShape.TextFrame.Paragraphs[0];

    // agregar efecto de animación Fly al párrafo seleccionado
    IEffect effect = presentation.Slides[0].Timeline.MainSequence.AddEffect(paragraph, EffectType.Fly, EffectSubtype.Left, EffectTriggerType.OnClick);


    presentation.Save(dataDir + "AnimationEffectinParagraph.pptx", SaveFormat.Pptx);
}
```



## Obtener los Efectos de Animación en Párrafos

Puede decidir averiguar los efectos de animación añadidos a un párrafo; por ejemplo, en un escenario, desea obtener los efectos de animación en un párrafo porque planea aplicar esos efectos a otro párrafo o forma.

Aspose.Slides para .NET le permite obtener todos los efectos de animación aplicados a los párrafos contenidos en un marco de texto (forma). Este código de muestra le muestra cómo obtener los efectos de animación en un párrafo:

```c#
using (Presentation pres = new Presentation("Test.pptx"))
{
	ISequence sequence = pres.Slides[0].Timeline.MainSequence;
	IAutoShape autoShape = (IAutoShape)pres.Slides[0].Shapes[1];

	foreach (IParagraph paragraph in autoShape.TextFrame.Paragraphs)
	{
		IEffect[] effects = sequence.GetEffectsByParagraph(paragraph);

		if (effects.Length > 0)
			Console.WriteLine("El párrafo \"" + paragraph.Text + "\" tiene el efecto " + effects[0].Type + ".");
	}
}
```