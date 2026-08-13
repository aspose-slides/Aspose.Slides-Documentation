---
title: Aplicar animaciones de formas en presentaciones en .NET
linktitle: Animación de forma
type: docs
weight: 60
url: /es/net/shape-animation/
keywords:
- forma
- animación
- efecto
- forma animada
- texto animado
- añadir animación
- obtener animación
- extraer animación
- añadir efecto
- obtener efecto
- extraer efecto
- sonido del efecto
- aplicar animación
- PowerPoint
- presentación
- .NET
- C#
- Aspose.Slides
description: "Descubra cómo crear y personalizar animaciones de forma en presentaciones de PowerPoint con Aspose.Slides para .NET. ¡Destaque!"
---
## **Introducción**

Las animaciones son efectos visuales que pueden aplicarse a textos, imágenes, formas o [gráficos](/slides/es/net/animated-charts/). Dan vida a las presentaciones o a sus constituyentes. 

## **¿Por qué usar animaciones en presentaciones?**

Usando animaciones, puedes 

* controlar el flujo de información
* enfatizar los puntos importantes
* aumentar el interés o la participación de la audiencia
* hacer que el contenido sea más fácil de leer, asimilar o procesar
* atraer la atención de los lectores o espectadores a las partes importantes de una presentación

PowerPoint proporciona muchas opciones y herramientas para animaciones y efectos de animación en las categorías de **entrada**, **salida**, **énfasis** y **trayectorias de movimiento**. 

## **Animaciones en Aspose.Slides**

* Aspose.Slides proporciona las clases y tipos que necesitas para trabajar con animaciones bajo el espacio de nombres [Aspose.Slides.Animation](https://reference.aspose.com/slides/es/net/aspose.slides.animation/).
* Aspose.Slides ofrece más de **150 efectos de animación** bajo la enumeración [EffectType](https://reference.aspose.com/slides/es/net/aspose.slides.animation/effecttype). Estos efectos son esencialmente los mismos (o equivalentes) que se utilizan en PowerPoint.

## **Aplicar animación a un TextBox**

Aspose.Slides para .NET permite aplicar animación al texto en una forma. 

1. Crea una instancia de la clase [Presentation](http://www.aspose.com/api/net/slides/es/aspose.slides/).
2. Obtén una referencia a una diapositiva mediante su índice.
3. Añade una `rectangle` [IAutoShape](https://reference.aspose.com/slides/es/net/aspose.slides/iautoshape). 
4. Añade texto a [IAutoShape.TextFrame](https://reference.aspose.com/slides/es/net/aspose.slides/iautoshape/properties/textframe).
5. Obtén la secuencia principal de efectos.
6. Añade un efecto de animación a [IAutoShape](https://reference.aspose.com/slides/es/net/aspose.slides/iautoshape).
7. Establece la propiedad [TextAnimation.BuildType](https://reference.aspose.com/slides/es/net/aspose.slides.animation/textanimation/properties/buildtype) al valor de la [enumeración BuildType](https://reference.aspose.com/slides/es/net/aspose.slides.animation/buildtype).
8. Guarda la presentación en disco como archivo PPTX.

```c#
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

// Instancia una clase de presentación que representa un archivo de presentación.
using (Presentation pres = new Presentation())
{
    ISlide sld = pres.Slides[0];

    // Añade una nueva AutoShape con texto
    IAutoShape autoShape = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 150, 100);

    // Añade tres párrafos para que la construcción por párrafo tenga algo que recorrer.
    ITextFrame textFrame = autoShape.TextFrame;
    textFrame.Text = "First paragraph";
    textFrame.Paragraphs.Add(new Paragraph { Text = "Second paragraph" });
    textFrame.Paragraphs.Add(new Paragraph { Text = "Third paragraph" });

    // Obtiene la secuencia principal de la diapositiva.
    ISequence sequence = sld.Timeline.MainSequence;

    // Añade el efecto de animación Fade a la forma
    IEffect effect = sequence.AddEffect(autoShape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);

    // Anima el texto de la forma por párrafos de primer nivel
    effect.TextAnimation.BuildType = BuildType.ByLevelParagraphs1;

    // Guarda el archivo PPTX en disco
    pres.Save("AnimTextBox_out.pptx", SaveFormat.Pptx);
}
```

{{%  alert color="info"  %}} 

Además de aplicar animaciones al texto, también puedes aplicar animaciones a un único [Paragraph](https://reference.aspose.com/slides/es/net/aspose.slides/iparagraph). Consulta [**Texto animado**](/slides/es/net/animated-text/).

{{% /alert %}} 

## **Aplicar animación a un PictureFrame**

1. Crea una instancia de la clase [Presentation](http://www.aspose.com/api/net/slides/es/aspose.slides/).
2. Obtén una referencia a una diapositiva mediante su índice.
3. Añade o obtiene un [PictureFrame](https://reference.aspose.com/slides/es/net/aspose.slides/ipictureframe) en la diapositiva. 
5. Obtén la secuencia principal de efectos.
6. Añade un efecto de animación a [PictureFrame](https://reference.aspose.com/slides/es/net/aspose.slides/ipictureframe).
8. Guarda la presentación en disco como archivo PPTX.

```c#
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

// Instancia una clase de presentación que representa un archivo de presentación.
using (Presentation pres = new Presentation())
{
    // Cargar imagen para añadir a la colección de imágenes de la presentación
    IImage image = Images.FromFile("aspose-logo.jpg");
    IPPImage ppImage = pres.Images.AddImage(image);
    image.Dispose();

    // Añade un marco de imagen a la diapositiva
    IPictureFrame picFrame = pres.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 50, 100, 100, ppImage);

    // Obtiene la secuencia principal de la diapositiva.
    ISequence sequence = pres.Slides[0].Timeline.MainSequence;

    // Añade el efecto de animación Fly from Left al marco de imagen
    IEffect effect = sequence.AddEffect(picFrame, EffectType.Fly, EffectSubtype.Left, EffectTriggerType.OnClick);

    // Guarda el archivo PPTX en disco
    pres.Save("AnimImage_out.pptx", SaveFormat.Pptx);
}
```

## **Aplicar animación a una forma**

1. Crea una instancia de la clase [Presentation](http://www.aspose.com/api/net/slides/es/aspose.slides/).
2. Obtén una referencia a una diapositiva mediante su índice.
3. Añade una `rectangle` [IAutoShape](https://reference.aspose.com/slides/es/net/aspose.slides/iautoshape). 
4. Añade una `Bevel` [IAutoShape](https://reference.aspose.com/slides/es/net/aspose.slides/iautoshape) (cuando este objeto se hace clic, la animación se reproduce).
5. Crea una secuencia de efectos en la forma de bisel.
6. Crea una `UserPath` personalizada.
7. Añade comandos para moverse a la `UserPath`.
8. Guarda la presentación en disco como archivo PPTX.

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

// Instancia una clase Presentation que representa un archivo de presentación.
using (Presentation pres = new Presentation())
{
    ISlide sld = pres.Slides[0];

    // Crea el efecto PathFootball para la forma existente desde cero.
    IAutoShape ashp = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 150, 150, 250, 25);

    ashp.AddTextFrame("Animated TextBox");

    // Añade el efecto de animación PathFootball.
    pres.Slides[0].Timeline.MainSequence.AddEffect(ashp, EffectType.PathFootball,
                           EffectSubtype.None, EffectTriggerType.AfterPrevious);

    // Crea una especie de "botón".
    IShape shapeTrigger = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Bevel, 10, 10, 20, 20);

    // Crea una secuencia de efectos para el botón.
    ISequence seqInter = pres.Slides[0].Timeline.InteractiveSequences.Add(shapeTrigger);

    // Crea una ruta de usuario personalizada. Nuestro objeto se moverá solo después de que se haga clic en el botón.
    IEffect fxUserPath = seqInter.AddEffect(ashp, EffectType.PathUser, EffectSubtype.None, EffectTriggerType.OnClick);

    // Añade comandos para mover ya que la ruta creada está vacía.
    IMotionEffect motionBhv = ((IMotionEffect)fxUserPath.Behaviors[0]);

    PointF[] pts = new PointF[1];
    pts[0] = new PointF(0.076f, 0.59f);
    motionBhv.Path.Add(MotionCommandPathType.LineTo, pts, MotionPathPointsType.Auto, true);
    pts[0] = new PointF(-0.076f, -0.59f);
    motionBhv.Path.Add(MotionCommandPathType.LineTo, pts, MotionPathPointsType.Auto, false);
    motionBhv.Path.Add(MotionCommandPathType.End, null, MotionPathPointsType.Auto, false);

    // Escribe el archivo PPTX en disco
    pres.Save("AnimExample_out.pptx", SaveFormat.Pptx);
}
```

## **Obtener los efectos de animación aplicados a una forma**

Los siguientes ejemplos muestran cómo usar el método `GetEffectsByShape` de la interfaz [ISequence](https://reference.aspose.com/slides/es/net/aspose.slides.animation/isequence/) para obtener todos los efectos de animación aplicados a una forma.

**Ejemplo 1: Obtener los efectos de animación aplicados a una forma en una diapositiva normal**

Previamente, aprendiste cómo añadir efectos de animación a formas en presentaciones de PowerPoint. El siguiente código de ejemplo muestra cómo obtener los efectos aplicados a la primera forma de la primera diapositiva normal en la presentación `AnimExample_out.pptx`.

```c#
using Aspose.Slides;
using Aspose.Slides.Animation;

using (Presentation presentation = new Presentation("AnimExample_out.pptx"))
{
    ISlide firstSlide = presentation.Slides[0];

    // Obtiene la secuencia principal de animación de la diapositiva.
    ISequence sequence = firstSlide.Timeline.MainSequence;

    // Obtiene la primera forma en la primera diapositiva.
    IShape shape = firstSlide.Shapes[0];

    // Obtiene los efectos de animación aplicados a la forma.
    IEffect[] shapeEffects = sequence.GetEffectsByShape(shape);

    if (shapeEffects.Length > 0)
        Console.WriteLine($"The shape {shape.Name} has {shapeEffects.Length} animation effects.");
}
```

**Ejemplo 2: Obtener todos los efectos de animación, incluidos los heredados de los marcadores de posición**

Si una forma en una diapositiva normal tiene marcadores de posición que están en la diapositiva de diseño y/o en la diapositiva maestra, y se han añadido efectos de animación a esos marcadores de posición, entonces todos los efectos de la forma se reproducirán durante la presentación, incluidos los heredados de los marcadores de posición.

Supongamos que tenemos un archivo de presentación PowerPoint `sample.pptx` con una diapositiva que contiene solo una forma de pie de página con el texto "Made with Aspose.Slides" y al que se le ha aplicado el efecto **Random Bars**.

![Slide shape animation effect](slide-shape-animation.png)

Supongamos también que el efecto **Split** se ha aplicado al marcador de posición del pie de página en la diapositiva **layout**.

![Layout shape animation effect](layout-shape-animation.png)

Y finalmente, el efecto **Fly In** se ha aplicado al marcador de posición del pie de página en la diapositiva **master**.

![Master shape animation effect](master-shape-animation.png)

El siguiente código de ejemplo muestra cómo usar el método `GetBasePlaceholder` de la interfaz [IShape](https://reference.aspose.com/slides/es/net/aspose.slides/ishape/) para acceder a los marcadores de posición de la forma y obtener los efectos de animación aplicados a la forma de pie de página, incluidos los heredados de los marcadores de posición situados en las diapositivas de diseño y maestra.

```cs
using System;
using System.Collections.Generic;
using Aspose.Slides;
using Aspose.Slides.Animation;

using (Presentation presentation = new Presentation("sample.pptx"))
{
    ISlide slide = presentation.Slides[0];

    // Obtener los efectos de animación de la forma en la diapositiva normal.
    IShape shape = slide.Shapes[0];
    IEffect[] shapeEffects = slide.Timeline.MainSequence.GetEffectsByShape(shape);

    // Obtener los efectos de animación del marcador de posición en la diapositiva de diseño.
    IShape layoutShape = shape.GetBasePlaceholder();
    IEffect[] layoutShapeEffects = slide.LayoutSlide.Timeline.MainSequence.GetEffectsByShape(layoutShape);

    // Obtener los efectos de animación del marcador de posición en la diapositiva maestra.
    IShape masterShape = layoutShape.GetBasePlaceholder();
    IEffect[] masterShapeEffects = slide.LayoutSlide.MasterSlide.Timeline.MainSequence.GetEffectsByShape(masterShape);

    Console.WriteLine("Main sequence of shape effects:");
    PrintEffects(masterShapeEffects);
    PrintEffects(layoutShapeEffects);
    PrintEffects(shapeEffects);
}

static void PrintEffects(IEnumerable<IEffect> effects)
{
    foreach (IEffect effect in effects)
    {
        Console.WriteLine($"{effect.Type} {effect.Subtype}");
    }
}
```
```cs
using Aspose.Slides.Animation;

static void PrintEffects(IEnumerable<IEffect> effects)
{
    foreach (IEffect effect in effects)
    {
        Console.WriteLine($"{effect.Type} {effect.Subtype}");
    }
}
```

Output:
```text
Main sequence of shape effects:
Fly Bottom
Split VerticalIn
RandomBars Horizontal
```

## **Cambiar las propiedades de sincronización del efecto de animación**

Aspose.Slides para .NET permite cambiar las propiedades de sincronización de un efecto de animación.

Esta es la ventana de **Animation Timing** y el menú extendido en Microsoft PowerPoint:

![example1_image](shape-animation.png)

Estas son las correspondencias entre PowerPoint Timing y las propiedades [Effect.Timing](https://reference.aspose.com/slides/es/net/aspose.slides.animation/effect/properties/timing):

- La lista desplegable **Start** de PowerPoint Timing coincide con la propiedad [Effect.Timing.TriggerType](https://reference.aspose.com/slides/es/net/aspose.slides.animation/itiming/properties/triggertype). 
- La lista desplegable **Duration** de PowerPoint Timing coincide con la propiedad [Effect.Timing.Duration](https://reference.aspose.com/slides/es/net/aspose.slides.animation/itiming/properties/duration). La duración de una animación (en segundos) es el tiempo total que tarda la animación en completar un ciclo. 
- La lista desplegable **Delay** de PowerPoint Timing coincide con la propiedad [Effect.Timing.TriggerDelayTime](https://reference.aspose.com/slides/es/net/aspose.slides.animation/itiming/properties/triggerdelaytime). 
- La lista desplegable **Repeat** de PowerPoint Timing coincide con estas propiedades: 
  * la propiedad [Effect.Timing.RepeatCount](https://reference.aspose.com/slides/es/net/aspose.slides.animation/itiming/repeatcount) que describe el *número* de veces que se repite el efecto;
  * la bandera [Effect.Timing.RepeatUntilEndSlide](https://reference.aspose.com/slides/es/net/aspose.slides.animation/itiming/repeatuntilendslide) que especifica si el efecto se repite hasta el final de la diapositiva;
  * la bandera [Effect.Timing.RepeatUntilNextClick](https://reference.aspose.com/slides/es/net/aspose.slides.animation/itiming/repeatuntilnextclick) que especifica si el efecto se repite hasta el siguiente clic.
- La casilla de verificación **Rewind when done playing** de PowerPoint Timing coincide con la propiedad [Effect.Timing.Rewind](https://reference.aspose.com/slides/es/net/aspose.slides.animation/itiming/rewind/). 

Así es como cambias las propiedades de sincronización del efecto:

1. [Aplicar](#apply-animation-to-shape) o obtén el efecto de animación.
2. Establece nuevos valores para las propiedades [Effect.Timing](https://reference.aspose.com/slides/es/net/aspose.slides.animation/effect/properties/timing) que necesites. 
3. Guarda el archivo PPTX modificado.

```c#
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

// Instancia una clase de presentación que representa un archivo de presentación.
using (Presentation pres = new Presentation("AnimExample_out.pptx"))
{
    // Obtiene la secuencia principal de la diapositiva.
    ISequence sequence = pres.Slides[0].Timeline.MainSequence;

    // Obtiene el primer efecto de la secuencia principal.
    IEffect effect = sequence[0];

    // Cambia el TriggerType del efecto para iniciar al hacer clic
    effect.Timing.TriggerType = EffectTriggerType.OnClick;

    // Cambia la duración del efecto
    effect.Timing.Duration = 3f;

    // Cambia el TriggerDelayTime del efecto
    effect.Timing.TriggerDelayTime = 0.5f;

    // Si el valor Repeat del efecto es "none"
    if (effect.Timing.RepeatCount == 1f)
    {
        // Cambia Repeat del efecto a "Until Next Click"
        effect.Timing.RepeatUntilNextClick = true;
    }
    else
    {
        // Cambia Repeat del efecto a "Until End of Slide"
        effect.Timing.RepeatUntilEndSlide = true;
    }

    // Activa la opción Rewind del efecto
        effect.Timing.Rewind = true;
    
    // Guarda el archivo PPTX en disco
    pres.Save("AnimExample_changed.pptx", SaveFormat.Pptx);
}
```

## **Sonido del efecto de animación**

Aspose.Slides ofrece estas propiedades para trabajar con sonidos en los efectos de animación: 
- [IEffect.Sound](https://reference.aspose.com/slides/es/net/aspose.slides.animation/effect/sound/) 
- [IEffect.StopPreviousSound](https://reference.aspose.com/slides/es/net/aspose.slides.animation/effect/stopprevioussound/) 

### **Añadir un sonido a un efecto de animación**

Este código C# muestra cómo añadir un sonido a un efecto de animación y detenerlo cuando empieza el siguiente efecto:

```c#
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation("AnimExample_out.pptx"))
{
	// Añade audio a la colección de audio de la presentación.
	IAudio effectSound = pres.Audios.AddAudio(File.ReadAllBytes("sampleaudio.wav"));

	ISlide firstSlide = pres.Slides[0];

	// Obtiene la secuencia principal de la diapositiva.
	ISequence sequence = firstSlide.Timeline.MainSequence;

	// Obtiene el primer efecto de la secuencia principal
	IEffect firstEffect = sequence[0];

	// Comprueba el efecto para "Sin sonido"
	if (!firstEffect.StopPreviousSound && firstEffect.Sound == null)
	{
		// Añade sonido al primer efecto.
		firstEffect.Sound = effectSound;
	}

	// Obtiene la primera secuencia interactiva de la diapositiva.
	ISequence interactiveSequence = firstSlide.Timeline.InteractiveSequences[0];

	// Establece la bandera "Stop previous sound" del efecto
	interactiveSequence[0].StopPreviousSound = true;

	// Escribe el archivo PPTX en disco
	pres.Save("AnimExample_Sound_out.pptx", SaveFormat.Pptx);
}
```

### **Extraer un sonido de un efecto de animación**

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/net/aspose.slides/presentation/).
2. Obtén una referencia a una diapositiva mediante su índice. 
3. Obtén la secuencia principal de efectos. 
4. Extrae el [Sound](https://reference.aspose.com/slides/es/net/aspose.slides.animation/effect/sound/) incrustado en cada efecto de animación. 

Este código C# muestra cómo extraer el sonido incrustado en un efecto de animación:

```c#
using Aspose.Slides;
using Aspose.Slides.Animation;

// Instancia una clase de presentación que representa un archivo de presentación.
using (Presentation presentation = new Presentation("EffectSound.pptx"))
{
    ISlide slide = presentation.Slides[0];

    // Obtiene la secuencia principal de la diapositiva.
    ISequence sequence = slide.Timeline.MainSequence;

    foreach (IEffect effect in sequence)
    {
        if (effect.Sound == null)
            continue;

        // Extrae el sonido del efecto en un array de bytes
        byte[] audio = effect.Sound.BinaryData;
    }
}
```

## **Después de la animación**

Aspose.Slides para .NET permite cambiar la propiedad After animation de un efecto de animación.

Esta es la ventana de **Animation Effect** y el menú extendido en Microsoft PowerPoint:

![example1_image](shape-after-animation.png)

La lista desplegable **After animation** de PowerPoint Effect coincide con estas propiedades: 

- la propiedad [IEffect.AfterAnimationType](https://reference.aspose.com/slides/es/net/aspose.slides.animation/ieffect/afteranimationtype/) que describe el tipo de animación posterior:
  * PowerPoint **More Colors** coincide con el tipo [AfterAnimationType.Color](https://reference.aspose.com/slides/es/net/aspose.slides.animation/afteranimationtype/);
  * PowerPoint **Don't Dim** coincide con el tipo [AfterAnimationType.DoNotDim](https://reference.aspose.com/slides/es/net/aspose.slides.animation/afteranimationtype/) (tipo de animación posterior predeterminado);
  * PowerPoint **Hide After Animation** coincide con el tipo [AfterAnimationType.HideAfterAnimation](https://reference.aspose.com/slides/es/net/aspose.slides.animation/afteranimationtype/);
  * PowerPoint **Hide on Next Mouse Click** coincide con el tipo [AfterAnimationType.HideOnNextMouseClick](https://reference.aspose.com/slides/es/net/aspose.slides.animation/afteranimationtype/);
- la propiedad [IEffect.AfterAnimationColor](https://reference.aspose.com/slides/es/net/aspose.slides.animation/ieffect/afteranimationcolor/) que define un formato de color después de la animación. Esta propiedad funciona en conjunto con el tipo [AfterAnimationType.Color](https://reference.aspose.com/slides/es/net/aspose.slides.animation/afteranimationtype/). Si cambias el tipo a otro, el color después de la animación se borrará.

Este código C# muestra cómo cambiar un efecto de animación posterior:

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

// Instancia una clase de presentación que representa un archivo de presentación
using (Presentation pres = new Presentation("AnimImage_out.pptx"))
{
    ISlide firstSlide = pres.Slides[0];

    // Obtiene el primer efecto de la secuencia principal
    IEffect firstEffect = firstSlide.Timeline.MainSequence[0];

    // Cambia el tipo de animación posterior a Color
    firstEffect.AfterAnimationType = AfterAnimationType.Color;

    // Establece el color de atenuación después de la animación
    firstEffect.AfterAnimationColor.Color = Color.AliceBlue;

    // Guarda el archivo PPTX en disco
    pres.Save("AnimImage_AfterAnimation.pptx", SaveFormat.Pptx);
}
```

## **Animar texto**

Aspose.Slides ofrece estas propiedades para trabajar con el bloque *Animate text* de un efecto de animación:

- la propiedad [IEffect.AnimateTextType](https://reference.aspose.com/slides/es/net/aspose.slides.animation/ieffect/animatetexttype/) que describe el tipo de animación de texto del efecto. El texto de la forma puede animarse:
  - Todo a la vez ([AnimateTextType.AllAtOnce](https://reference.aspose.com/slides/es/net/aspose.slides.animation/animatetexttype/) tipo)
  - Por palabra ([AnimateTextType.ByWord](https://reference.aspose.com/slides/es/net/aspose.slides.animation/animatetexttype/) tipo)
  - Por letra ([AnimateTextType.ByLetter](https://reference.aspose.com/slides/es/net/aspose.slides.animation/animatetexttype/) tipo)
- la propiedad [IEffect.DelayBetweenTextParts](https://reference.aspose.com/slides/es/net/aspose.slides.animation/ieffect/delaybetweentextparts/) establece un retardo entre las partes de texto animado (palabras o letras). Un valor positivo especifica el porcentaje de la duración del efecto. Un valor negativo especifica el retardo en segundos.

Así es como puedes cambiar las propiedades *Animate text* del efecto:

1. [Aplicar](#apply-animation-to-shape) o obtén el efecto de animación.
2. Establece la propiedad [IEffect.TextAnimation.BuildType](https://reference.aspose.com/slides/es/net/aspose.slides.animation/itextanimation/buildtype/) al valor [BuildType.AsOneObject](https://reference.aspose.com/slides/es/net/aspose.slides.animation/buildtype/) para desactivar el modo de animación *By Paragraphs*.
3. Establece nuevos valores para las propiedades [IEffect.AnimateTextType](https://reference.aspose.com/slides/es/net/aspose.slides.animation/ieffect/animatetexttype/) y [IEffect.DelayBetweenTextParts](https://reference.aspose.com/slides/es/net/aspose.slides.animation/ieffect/delaybetweentextparts/).
4. Guarda el archivo PPTX modificado.

Este código C# demuestra la operación:

```c#
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

// Instancia una clase de presentación que representa un archivo de presentación.
using (Presentation pres = new Presentation("AnimTextBox_out.pptx"))
{
	ISlide firstSlide = pres.Slides[0];

	// Obtiene el primer efecto de la secuencia principal
	IEffect firstEffect = firstSlide.Timeline.MainSequence[0];

	// Cambia el tipo de animación de texto del efecto a "As One Object"
	firstEffect.TextAnimation.BuildType = BuildType.AsOneObject;

	// Cambia el tipo de animación de texto del efecto a "By word"
	firstEffect.AnimateTextType = AnimateTextType.ByWord;

	// Establece el retardo entre palabras al 20% de la duración del efecto
	firstEffect.DelayBetweenTextParts = 20f;

	// Guarda el archivo PPTX en disco
	pres.Save("AnimTextBox_AnimateText.pptx", SaveFormat.Pptx);
}
```

## **FAQ**

### ¿Cómo puedo asegurar que las animaciones se conserven al publicar la presentación en la web?

[Exportar a HTML5](/slides/es/net/export-to-html5/) y habilita las [opciones](https://reference.aspose.com/slides/es/net/aspose.slides.export/html5options/) responsables de las animaciones de [forma](https://reference.aspose.com/slides/es/net/aspose.slides.export/html5options/animateshapes/) y de [transición](https://reference.aspose.com/slides/es/net/aspose.slides.export/html5options/animatetransitions/). El HTML simple no reproduce las animaciones de diapositivas, mientras que HTML5 sí.

### ¿Cómo afecta cambiar el orden Z (orden de capas) de las formas a la animación?

El orden de animación y el orden de dibujo son independientes: un efecto controla el tiempo y el tipo de aparición/desaparición, mientras que el [z-order](https://reference.aspose.com/slides/es/net/aspose.slides/shape/zorderposition/) determina qué cubre a qué. El resultado visible está definido por su combinación. (Este es el comportamiento general de PowerPoint; el modelo de efectos y formas de Aspose.Slides sigue la misma lógica.)

### ¿Existen limitaciones al convertir animaciones a video para ciertos efectos?

En general, [las animaciones son compatibles](/slides/es/net/convert-powerpoint-to-video/), pero casos raros o efectos específicos pueden renderizarse de forma distinta. Se recomienda probar con los efectos que utilizas y con la versión de la biblioteca.