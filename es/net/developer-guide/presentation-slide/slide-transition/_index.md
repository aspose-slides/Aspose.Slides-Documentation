---
title: Gestionar transiciones de diapositivas en presentaciones en .NET
linktitle: Transición de diapositiva
type: docs
weight: 90
url: /es/net/slide-transition/
keywords:
- transición de diapositiva
- agregar transición de diapositiva
- aplicar transición de diapositiva
- transición de diapositiva avanzada
- transición morph
- tipo de transición
- efecto de transición
- PowerPoint
- OpenDocument
- presentación
- .NET
- C#
- Aspose.Slides
description: "Aplicar transiciones de diapositiva, configurar el avance automático de diapositivas y personalizar Morph y otros efectos de transición con Aspose.Slides para .NET."
---
## **Visión general**

Las transiciones de diapositiva controlan cómo aparecen las diapositivas durante una presentación. Con Aspose.Slides para .NET, puedes elegir un efecto de transición para cada diapositiva, configurar el avance mediante clic del ratón o temporizador, y ajustar opciones específicas de un efecto. Este artículo utiliza ejemplos en C# para aplicar transiciones, establecer duraciones exactas de transición, gestionar el tiempo de las diapositivas y crear una transición Morph entre dos diapositivas. Los ejemplos también muestran cómo guardar la configuración en un archivo PPTX.

## **Agregar transición de diapositiva**

Para aplicar una transición, carga una presentación con la clase [Presentation](https://reference.aspose.com/slides/es/net/aspose.slides/presentation/) y accede a la propiedad [SlideShowTransition](https://reference.aspose.com/slides/es/net/aspose.slides/ibaseslide/slideshowtransition/) de la diapositiva. Establece su [Type](https://reference.aspose.com/slides/es/net/aspose.slides/islideshowtransition/type/) a un valor de la enumeración [TransitionType](https://reference.aspose.com/slides/es/net/aspose.slides.slideshow/transitiontype/), y luego guarda la presentación.

El siguiente ejemplo aplica una transición Circle a la primera diapositiva y una transición Comb a la segunda. Utiliza un archivo `input.pptx` con al menos dos diapositivas.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SlideShow;

using var presentation = new Presentation("input.pptx");

if (presentation.Slides.Count >= 2)
{
    presentation.Slides[0].SlideShowTransition.Type = TransitionType.Circle;
    presentation.Slides[1].SlideShowTransition.Type = TransitionType.Comb;

    presentation.Save("slide-transitions.pptx", SaveFormat.Pptx);
}
else
{
    Console.WriteLine("The input presentation must contain at least two slides.");
}
```

## **Agregar transición de diapositiva avanzada**

Puedes configurar cuánto tiempo permanece una diapositiva en pantalla y si un clic del ratón avanza la presentación. Las siguientes propiedades controlan este comportamiento:

- [AdvanceOnClick](https://reference.aspose.com/slides/es/net/aspose.slides/islideshowtransition/advanceonclick/) permite al espectador avanzar haciendo clic con el ratón.
- [AdvanceAfter](https://reference.aspose.com/slides/es/net/aspose.slides/islideshowtransition/advanceafter/) habilita el avance automático.
- [AdvanceAfterTime](https://reference.aspose.com/slides/es/net/aspose.slides/islideshowtransition/advanceaftertime/) especifica el retraso antes del avance automático, en milisegundos.

Activa tanto el avance con clic como el avance temporizado para que el espectador pueda avanzar con un clic o esperar al temporizador. Para usar solo el temporizador, establece [AdvanceOnClick] en `false`. El retraso controla cuándo avanza la presentación; no establece la duración del efecto de transición visual.

Este ejemplo asigna diferentes efectos a las tres primeras diapositivas y habilita el avance automático después de 3, 5 y 7 segundos, respectivamente. Los clics del ratón también pueden avanzar estas diapositivas. Utiliza un archivo `input.pptx` con al menos tres diapositivas.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SlideShow;

using var presentation = new Presentation("input.pptx");

if (presentation.Slides.Count >= 3)
{
    var firstTransition = presentation.Slides[0].SlideShowTransition;
    firstTransition.Type = TransitionType.Circle;
    firstTransition.AdvanceOnClick = true;
    firstTransition.AdvanceAfter = true;
    firstTransition.AdvanceAfterTime = 3000;

    var secondTransition = presentation.Slides[1].SlideShowTransition;
    secondTransition.Type = TransitionType.Comb;
    secondTransition.AdvanceOnClick = true;
    secondTransition.AdvanceAfter = true;
    secondTransition.AdvanceAfterTime = 5000;

    var thirdTransition = presentation.Slides[2].SlideShowTransition;
    thirdTransition.Type = TransitionType.Zoom;
    thirdTransition.AdvanceOnClick = true;
    thirdTransition.AdvanceAfter = true;
    thirdTransition.AdvanceAfterTime = 7000;

    presentation.Save("advanced-transitions.pptx", SaveFormat.Pptx);
}
else
{
    Console.WriteLine("The input presentation must contain at least three slides.");
}
```

Para comprobar si el avance temporizado está habilitado, lee [AdvanceAfter](https://reference.aspose.com/slides/es/net/aspose.slides/islideshowtransition/advanceafter/). Un retraso almacenado por sí solo no indica que el temporizador esté activo.

El siguiente ejemplo abre el archivo guardado anteriormente, informa de cada temporizador habilitado y deshabilita el avance automático para las diapositivas con un retraso superior a dos segundos. Habilita los clics del ratón para esas diapositivas y guarda la configuración actualizada.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("advanced-transitions.pptx");

foreach (var slide in presentation.Slides)
{
    var transition = slide.SlideShowTransition;

    if (transition.AdvanceAfter)
    {
        Console.WriteLine($"Slide {slide.SlideNumber}: advance after {transition.AdvanceAfterTime} ms.");

        if (transition.AdvanceAfterTime > 2000)
        {
            transition.AdvanceAfter = false;
            transition.AdvanceOnClick = true;
        }
    }
}

presentation.Save("adjusted-transitions.pptx", SaveFormat.Pptx);
```

## **Controlar el tiempo de la transición con precisión**

Utiliza [Duration](https://reference.aspose.com/slides/es/net/aspose.slides.slideshow/slideshowtransition/duration/) para especificar la longitud exacta de un efecto de transición en milisegundos. La propiedad [SlideShowTransition](https://reference.aspose.com/slides/es/net/aspose.slides/ibaseslide/slideshowtransition/) de la diapositiva expone estas configuraciones a través de [ISlideShowTransition](https://reference.aspose.com/slides/es/net/aspose.slides/islideshowtransition/):

| Propiedad | Propósito |
| --- | --- |
| [Duration](https://reference.aspose.com/slides/es/net/aspose.slides.slideshow/slideshowtransition/duration/) | Establece la duración del propio efecto de transición, en milisegundos. |
| [AdvanceAfterTime](https://reference.aspose.com/slides/es/net/aspose.slides.slideshow/slideshowtransition/advanceaftertime/) | Establece el retraso antes de que la diapositiva avance automáticamente, en milisegundos. Habilita [AdvanceAfter](https://reference.aspose.com/slides/es/net/aspose.slides/islideshowtransition/advanceafter/) para activar este temporizador. |
| [Speed](https://reference.aspose.com/slides/es/net/aspose.slides.slideshow/slideshowtransition/speed/) | Selecciona una categoría de velocidad predefinida de [TransitionSpeed](https://reference.aspose.com/slides/es/net/aspose.slides.slideshow/transitionspeed/): Slow, Medium o Fast. Se usa cuando no se especifica una duración exacta. |

[Duration] controla solo el efecto de transición; no determina cuánto tiempo permanece visible la diapositiva. Configura el retraso de avance automático por separado. Cuando no se establece una duración explícita, Aspose.Slides determina la duración del efecto a partir del tipo de transición y el valor de [Speed].

### **Aplicar la misma duración a cada diapositiva**

Para mantener un ritmo constante, aplica el mismo efecto y la misma duración exacta a cada diapositiva. Este ejemplo carga `input.pptx`, selecciona Fade de [TransitionType](https://reference.aspose.com/slides/es/net/aspose.slides.slideshow/transitiontype/), y asigna a cada transición una duración de 750 milisegundos. Por separado, habilita el avance automático después de 5 000 milisegundos y deshabilita el avance mediante clic del ratón, luego guarda el resultado como PPTX.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SlideShow;

using var presentation = new Presentation("input.pptx");

foreach (var slide in presentation.Slides)
{
    var transition = slide.SlideShowTransition;
    transition.Type = TransitionType.Fade;
    transition.Duration = 750;

    // Configura el avance automático independientemente de la duración del efecto.
    transition.AdvanceAfter = true;
    transition.AdvanceAfterTime = 5000;
    transition.AdvanceOnClick = false;
}

presentation.Save("precise-transitions.pptx", SaveFormat.Pptx);
```

### **Establecer duraciones diferentes para diapositivas individuales**

Las distintas diapositivas pueden usar duraciones de efecto diferentes. Por ejemplo, usa una transición breve para una diapositiva de título y una más larga para la introducción de una sección. Este ejemplo establece 500 milisegundos para la primera diapositiva y 1 200 milisegundos para la segunda. Utiliza un archivo `input.pptx` con al menos dos diapositivas.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SlideShow;

using var presentation = new Presentation("input.pptx");

if (presentation.Slides.Count >= 2)
{
    var firstTransition = presentation.Slides[0].SlideShowTransition;
    firstTransition.Type = TransitionType.Fade;
    firstTransition.Duration = 500;

    var secondTransition = presentation.Slides[1].SlideShowTransition;
    secondTransition.Type = TransitionType.Push;
    secondTransition.Duration = 1200;

    presentation.Save("individual-transition-durations.pptx", SaveFormat.Pptx);
}
else
{
    Console.WriteLine("The input presentation must contain at least two slides.");
}
```

### **Coordinar transiciones con salida animada**

Al preparar un [animated GIF](/slides/es/net/convert-powerpoint-to-animated-gif/), una [HTML5 presentation](/slides/es/net/export-to-html5/) o un [video](/slides/es/net/convert-powerpoint-to-video/), establece duraciones exactas de transición antes de la exportación para que coincidan con el ritmo deseado. Por ejemplo, usa un fundido de 600 milisegundos entre escenas y ajusta el retraso de avance de cada diapositiva por separado para permitir tiempo para su narración o contenido.

Para GIF y video, coordina la velocidad de fotogramas de salida con la duración del efecto: 600 milisegundos corresponden a 18 fotogramas a 30 fps. En HTML5, habilita las transiciones animadas en la configuración de exportación. Verifica los efectos y opciones de temporización compatibles con el formato de exportación elegido y previsualiza la salida para confirmar la sincronización.

### **Leer la duración de una transición existente**

Lee [Duration](https://reference.aspose.com/slides/es/net/aspose.slides.slideshow/slideshowtransition/duration/) antes de modificar la transición para determinar si se almacena un valor explícito. Un valor de `-1` indica que no se ha establecido una duración explícita; un valor no negativo especifica la duración almacenada en milisegundos. El valor no establecido no es la duración calculada de reproducción: Aspose.Slides utiliza el tipo de transición y [Speed](https://reference.aspose.com/slides/es/net/aspose.slides.slideshow/slideshowtransition/speed/) para determinar esa duración. Establecer un tipo de transición puede inicializar una duración, por lo que primero debes inspeccionar la configuración original.

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("input.pptx");

foreach (var slide in presentation.Slides)
{
    var transition = slide.SlideShowTransition;
    var duration = transition.Duration;

    if (duration >= 0)
    {
        Console.WriteLine($"Slide {slide.SlideNumber}: stored transition duration is {duration} ms.");
    }
    else
    {
        Console.WriteLine($"Slide {slide.SlideNumber}: no explicit duration; timing depends on {transition.Type} and {transition.Speed}.");
    }
}
```

## **Transición Morph**

La transición Morph anima los cambios entre objetos en diapositivas consecutivas. Para crear un efecto Morph sencillo, clona una diapositiva, mueve o redimensiona un objeto en la copia y aplica la transición Morph a la segunda diapositiva. Esto proporciona a la transición los objetos correspondientes para animar entre sus estados original y modificado.

El siguiente ejemplo crea una diapositiva con un rectángulo de texto, clona la diapositiva y cambia la posición y el tamaño del rectángulo en la copia. Luego selecciona Morph de la enumeración [TransitionType](https://reference.aspose.com/slides/es/net/aspose.slides.slideshow/transitiontype/) para la segunda diapositiva. Abre el archivo guardado en un visor de presentaciones que admita Morph para ver el efecto durante la presentación.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SlideShow;

using var presentation = new Presentation();

var firstSlide = presentation.Slides[0];
var rectangle = firstSlide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 400, 100);
rectangle.TextFrame.Text = "Morph transition";

var secondSlide = presentation.Slides.AddClone(firstSlide);
var movedRectangle = secondSlide.Shapes[0];
movedRectangle.X += 100;
movedRectangle.Y += 50;
movedRectangle.Width -= 200;
movedRectangle.Height -= 10;

secondSlide.SlideShowTransition.Type = TransitionType.Morph;

presentation.Save("morph-transition.pptx", SaveFormat.Pptx);
```

## **Tipos de transición Morph**

La enumeración [TransitionMorphType](https://reference.aspose.com/slides/es/net/aspose.slides.slideshow/transitionmorphtype/) controla cómo Morph coincide y anima el contenido:

- [ByObject](https://reference.aspose.com/slides/es/net/aspose.slides.slideshow/transitionmorphtype/) trata cada forma como un objeto completo.
- [ByWord](https://reference.aspose.com/slides/es/net/aspose.slides.slideshow/transitionmorphtype/) anima el texto coincidiendo palabras cuando sea posible.
- [ByChar](https://reference.aspose.com/slides/es/net/aspose.slides.slideshow/transitionmorphtype/) anima el texto coincidiendo caracteres cuando sea posible.

Establece la [Type](https://reference.aspose.com/slides/es/net/aspose.slides/islideshowtransition/type/) de la transición a Morph antes de acceder a su [Value](https://reference.aspose.com/slides/es/net/aspose.slides/islideshowtransition/value/). El valor entonces proporciona la interfaz [IMorphTransition](https://reference.aspose.com/slides/es/net/aspose.slides.slideshow/imorphtransition/), cuya propiedad [MorphType](https://reference.aspose.com/slides/es/net/aspose.slides.slideshow/imorphtransition/morphtype/) selecciona el modo de coincidencia.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SlideShow;

using var presentation = new Presentation("morph-transition.pptx");

if (presentation.Slides.Count >= 2)
{
    var transition = presentation.Slides[1].SlideShowTransition;
    transition.Type = TransitionType.Morph;

    if (transition.Value is IMorphTransition morphTransition)
    {
        morphTransition.MorphType = TransitionMorphType.ByWord;
        presentation.Save("morph-by-word.pptx", SaveFormat.Pptx);
    }
    else
    {
        Console.WriteLine("Morph transition options are unavailable.");
    }
}
else
{
    Console.WriteLine("The input presentation must contain at least two slides.");
}
```

## **Establecer efectos de transición**

Algunas transiciones exponen opciones adicionales, como dirección o si el efecto comienza desde una pantalla negra. Las opciones disponibles dependen del [Type](https://reference.aspose.com/slides/es/net/aspose.slides/islideshowtransition/type/) de transición seleccionado. Establece primero el tipo y luego utiliza la interfaz apropiada de su [Value](https://reference.aspose.com/slides/es/net/aspose.slides/islideshowtransition/value/).

El siguiente ejemplo aplica una transición Cut a la primera diapositiva de `input.pptx`. Establece [FromBlack](https://reference.aspose.com/slides/es/net/aspose.slides.slideshow/ioptionalblacktransition/fromblack/) a través de [IOptionalBlackTransition](https://reference.aspose.com/slides/es/net/aspose.slides.slideshow/ioptionalblacktransition/) para que la transición comience desde una pantalla negra.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SlideShow;

using var presentation = new Presentation("input.pptx");
var transition = presentation.Slides[0].SlideShowTransition;
transition.Type = TransitionType.Cut;

if (transition.Value is IOptionalBlackTransition cutTransition)
{
    cutTransition.FromBlack = true;
    presentation.Save("cut-from-black.pptx", SaveFormat.Pptx);
}
else
{
    Console.WriteLine("Cut transition options are unavailable.");
}
```

## **FAQ**

**¿Puedo controlar la velocidad de reproducción de una transición de diapositiva?**

Sí. Prefiere [Duration](https://reference.aspose.com/slides/es/net/aspose.slides.slideshow/slideshowtransition/duration/) cuando necesites una duración exacta del efecto en milisegundos. Usa [Speed](https://reference.aspose.com/slides/es/net/aspose.slides.slideshow/slideshowtransition/speed/) cuando una categoría predefinida de [TransitionSpeed](https://reference.aspose.com/slides/es/net/aspose.slides.slideshow/transitionspeed/) — Slow, Medium o Fast — sea suficiente y no se establezca una duración explícita. Estas configuraciones controlan el efecto de transición independientemente del retraso de avance automático.

**¿Puedo adjuntar audio a una transición y hacer que se repita en bucle?**

Sí. Asigna audio incrustado a [Sound](https://reference.aspose.com/slides/es/net/aspose.slides/islideshowtransition/sound/), establece [SoundMode](https://reference.aspose.com/slides/es/net/aspose.slides/islideshowtransition/soundmode/) en StartSound de la enumeración [TransitionSoundMode](https://reference.aspose.com/slides/es/net/aspose.slides.slideshow/transitionsoundmode/), y habilita [SoundLoop](https://reference.aspose.com/slides/es/net/aspose.slides/islideshowtransition/soundloop/). El audio se repite en bucle hasta el próximo evento de sonido en la presentación.

**¿Cuál es la forma más rápida de aplicar la misma transición a todas las diapositivas?**

Recorre la colección [Slides](https://reference.aspose.com/slides/es/net/aspose.slides/presentation/slides/es/) de la presentación y establece el [Type](https://reference.aspose.com/slides/es/net/aspose.slides/islideshowtransition/type/) de transición de cada diapositiva al mismo valor. Configura cualquier opción de temporización y efecto dentro del mismo bucle para mantener el comportamiento coherente en todas las diapositivas.

**¿Cómo puedo comprobar qué transición está establecida actualmente en una diapositiva?**

Lee la propiedad [Type](https://reference.aspose.com/slides/es/net/aspose.slides/islideshowtransition/type/) de la [SlideShowTransition](https://reference.aspose.com/slides/es/net/aspose.slides/ibaseslide/slideshowtransition/) de la diapositiva. Devuelve un valor de la enumeración [TransitionType](https://reference.aspose.com/slides/es/net/aspose.slides.slideshow/transitiontype/); None indica que no se ha aplicado ningún efecto de transición.