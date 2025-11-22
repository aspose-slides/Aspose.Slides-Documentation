---
title: Texto animado
type: docs
weight: 60
url: /es/net/animated-text/
keywords: "Texto animado, Efectos de animación, Presentación de PowerPoint, C#, Csharp, Aspose.Slides for .NET"
description: "Añade texto animado y efectos a una presentación de PowerPoint en C# o .NET"
---

## **Agregar efectos de animación a los párrafos**

Agregamos el método [**AddEffect()**](https://reference.aspose.com/slides/net/aspose.slides.animation/sequence/methods/addeffect/index) a las clases [**Sequence**](https://reference.aspose.com/slides/net/aspose.slides.animation/sequence) y [**ISequence**](https://reference.aspose.com/slides/net/aspose.slides.animation/isequence). Este método le permite añadir efectos de animación a un solo párrafo. El siguiente código de ejemplo muestra cómo añadir un efecto de animación a un solo párrafo:
```c#
using (Presentation presentation = new Presentation(dataDir + "Presentation1.pptx"))
{
    // seleccionar párrafo para añadir efecto
    IAutoShape autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
    IParagraph paragraph = autoShape.TextFrame.Paragraphs[0];

    // agregar efecto de animación Fly al párrafo seleccionado
    IEffect effect = presentation.Slides[0].Timeline.MainSequence.AddEffect(paragraph, EffectType.Fly, EffectSubtype.Left, EffectTriggerType.OnClick);


    presentation.Save(dataDir + "AnimationEffectinParagraph.pptx", SaveFormat.Pptx);
}
```


## **Obtener los efectos de animación en los párrafos**

Puede que desee averiguar los efectos de animación añadidos a un párrafo—por ejemplo, en un caso desea obtener los efectos de animación en un párrafo porque planea aplicar esos efectos a otro párrafo o forma. Aspose.Slides para .NET le permite obtener todos los efectos de animación aplicados a los párrafos contenidos en un marco de texto (forma). El siguiente código de ejemplo muestra cómo obtener los efectos de animación en un párrafo:
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


## **Preguntas frecuentes**

**¿En qué se diferencian las animaciones de texto de las transiciones de diapositiva, y pueden combinarse?**

Las animaciones de texto controlan el comportamiento de los objetos a lo largo del tiempo en una diapositiva, mientras que las [transiciones](/slides/es/net/slide-transition/) controlan cómo cambian las diapositivas. Son independientes y pueden usarse juntas; el orden de reproducción lo determina la línea de tiempo de la animación y la configuración de la transición.

**¿Se conservan las animaciones de texto al exportar a PDF o imágenes?**

No. Los PDF y las imágenes rasterizadas son estáticas, por lo que verá un único estado de la diapositiva sin movimiento. Para conservar el movimiento, use la exportación a [video](/slides/es/net/convert-powerpoint-to-video/) o [HTML](/slides/es/net/export-to-html5/).

**¿Funcionan las animaciones de texto en los diseños y la diapositiva maestra?**

Los efectos aplicados a objetos de diseño/maestra se heredan en las diapositivas, pero su sincronización e interacción con las animaciones a nivel de diapositiva dependen de la secuencia final en la diapositiva.