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
description: "Aprenda a añadir, inspeccionar y personalizar animaciones de formas, temporización, sonidos, comportamiento después de la animación y texto animado con Aspose.Slides para .NET."
---
## **Visión general**

Aspose.Slides para .NET representa las animaciones de diapositiva como efectos en una línea de tiempo de la diapositiva. Un efecto tiene una forma de destino, un tipo y subtipo de animación, un disparador, ajustes de temporización y propiedades opcionales como sonido o comportamiento después de la animación.

La línea de tiempo contiene dos tipos de secuencias:

- La **secuencia principal** se reproduce mientras avanza la diapositiva.
- Una **secuencia interactiva** comienza cuando se hace clic en su forma disparadora.

Dado que los cuadros de texto, imágenes, gráficos, tablas y otros objetos de diapositiva implementan [IShape](https://reference.aspose.com/slides/es/net/aspose.slides/ishape/), se utiliza el mismo método [ISequence.AddEffect](https://reference.aspose.com/slides/es/net/aspose.slides.animation/isequence/addeffect/) para la mayor parte del contenido de la diapositiva. Los efectos disponibles se enumeran en la enumeración [EffectType](https://reference.aspose.com/slides/es/net/aspose.slides.animation/effecttype/).

## **Añadir animaciones a formas**

Para añadir una animación, obtenga la secuencia principal de la diapositiva y llame a [ISequence.AddEffect](https://reference.aspose.com/slides/es/net/aspose.slides.animation/isequence/addeffect/) con la forma de destino, el tipo de efecto, el subtipo y el disparador. Para un efecto que comienza cuando se hace clic en otra forma, cree una secuencia interactiva cuyo disparador sea esa otra forma.

El siguiente ejemplo crea ambos tipos de animación y guarda el resultado en `shape-animations.pptx`.

```csharp
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var targetShape = slide.Shapes.AddAutoShape(ShapeType.RoundCornerRectangle, 120, 100, 320, 80);
targetShape.TextFrame.Text = "Click to animate this shape";

var mainSequence = slide.Timeline.MainSequence;
var entranceEffect = mainSequence.AddEffect(targetShape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);
entranceEffect.Timing.Duration = 1.5f;

var triggerShape = slide.Shapes.AddAutoShape(ShapeType.Bevel, 20, 20, 100, 40);
triggerShape.TextFrame.Text = "Move";

var interactiveSequence = slide.Timeline.InteractiveSequences.Add(triggerShape);
interactiveSequence.AddEffect(targetShape, EffectType.PathFootball, EffectSubtype.None, EffectTriggerType.OnClick);

presentation.Save("shape-animations.pptx", SaveFormat.Pptx);
```

El disparador controla cuándo comienza un efecto:

- [EffectTriggerType.OnClick](https://reference.aspose.com/slides/es/net/aspose.slides.animation/effecttriggertype/) espera un clic en la secuencia principal, o un clic en la forma disparadora en una secuencia interactiva.
- [EffectTriggerType.WithPrevious](https://reference.aspose.com/slides/es/net/aspose.slides.animation/effecttriggertype/) inicia con el efecto precedente.
- [EffectTriggerType.AfterPrevious](https://reference.aspose.com/slides/es/net/aspose.slides.animation/effecttriggertype/) inicia cuando el efecto precedente termina.

Para animar una imagen, un gráfico u otro tipo de forma, pase ese objeto a [ISequence.AddEffect](https://reference.aspose.com/slides/es/net/aspose.slides.animation/isequence/addeffect/) en lugar de `targetShape`. Para opciones de agrupación específicas de gráficos, consulte [Animated Charts](/slides/es/net/animated-charts/).

## **Leer animaciones de formas**

Utilice [ISequence.GetEffectsByShape](https://reference.aspose.com/slides/es/net/aspose.slides.animation/isequence/geteffectsbyshape/) cuando conozca la forma de destino. Para inspeccionar cada efecto, recorra la secuencia principal y cada secuencia interactiva. La enumeración evita suponer que una secuencia contiene un efecto en el índice `0`.

El siguiente ejemplo crea una forma con efectos de secuencia principal e interactiva, obtiene los efectos que tienen como destino la forma y luego recorre todas las secuencias de la diapositiva.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Animation;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var targetShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 120, 100, 320, 80);
targetShape.TextFrame.Text = "Animated shape";

var mainSequence = slide.Timeline.MainSequence;
mainSequence.AddEffect(targetShape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);

var triggerShape = slide.Shapes.AddAutoShape(ShapeType.Bevel, 20, 20, 100, 40);
triggerShape.TextFrame.Text = "Move";

var interactiveSequence = slide.Timeline.InteractiveSequences.Add(triggerShape);
interactiveSequence.AddEffect(targetShape, EffectType.PathFootball, EffectSubtype.None, EffectTriggerType.OnClick);

var targetEffects = mainSequence.GetEffectsByShape(targetShape);
Console.WriteLine($"The main sequence contains {targetEffects.Length} effect(s) for {targetShape.Name}.");

PrintSequence("Main sequence", mainSequence);

var interactiveIndex = 1;
foreach (var sequence in slide.Timeline.InteractiveSequences)
{
    var triggerName = sequence.TriggerShape == null ? "unknown" : sequence.TriggerShape.Name;
    var sequenceLabel = $"Interactive sequence {interactiveIndex}, trigger: {triggerName}";
    PrintSequence(sequenceLabel, sequence);
    interactiveIndex++;
}

static void PrintSequence(string label, ISequence sequence)
{
    Console.WriteLine($"  {label}: {sequence.Count} effect(s)");

    foreach (var effect in sequence)
    {
        var targetName = effect.TargetShape == null ? "unknown" : effect.TargetShape.Name;
        var effectDescription = $"{effect.Type} {effect.Subtype}; target: {targetName}; trigger: {effect.Timing.TriggerType}";
        Console.WriteLine($"    {effectDescription}");
    }
}
```

Si solo necesita los efectos para una forma, identifique primero la forma por nombre, tipo de marcador de posición u otra propiedad estable; a continuación, llame a [ISequence.GetEffectsByShape](https://reference.aspose.com/slides/es/net/aspose.slides.animation/isequence/geteffectsbyshape/). No asuma que [IShapeCollection.Item](https://reference.aspose.com/slides/es/net/aspose.slides/ishapecollection/item/) en el índice `0` sea siempre el objeto previsto.

## **Trabajar con efectos heredados de marcadores de posición**

Un marcador de posición en una diapositiva normal puede heredar el comportamiento de animación del marcador de posición correspondiente en su diapositiva de diseño y diapositiva maestra. [IShape.GetBasePlaceholder](https://reference.aspose.com/slides/es/net/aspose.slides/ishape/getbaseplaceholder/) devuelve ese marcador de posición padre, o `null` cuando no existe padre.

En la siguiente presentación de ejemplo, el pie de página tiene **Random Bars** en la diapositiva normal, **Split** en la diapositiva de diseño y **Fly In** en la diapositiva maestra.

![Efecto de animación del pie de página en la diapositiva normal](slide-shape-animation.png)

![Efecto de animación del marcador de posición del pie de página en la diapositiva de diseño](layout-shape-animation.png)

![Efecto de animación del marcador de posición del pie de página en la diapositiva maestra](master-shape-animation.png)

El siguiente ejemplo construye la jerarquía de marcadores de posición. Añade efectos a un marcador de posición maestro, a un marcador de posición de diseño y al marcador de posición correspondiente en una diapositiva normal. Cada llamada a [IShape.GetBasePlaceholder](https://reference.aspose.com/slides/es/net/aspose.slides/ishape/getbaseplaceholder/) se verifica antes de utilizar la forma devuelta.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var layoutSlide = presentation.LayoutSlides.GetByType(SlideLayoutType.Blank);
var layoutPlaceholder = layoutSlide.PlaceholderManager.AddTextPlaceholder(100, 100, 400, 80);
layoutSlide.Timeline.MainSequence.AddEffect(layoutPlaceholder, EffectType.Split, EffectSubtype.VerticalIn, EffectTriggerType.OnClick);

var masterPlaceholder = layoutPlaceholder.GetBasePlaceholder();
if (masterPlaceholder != null)
{
    var masterSequence = layoutSlide.MasterSlide.Timeline.MainSequence;
    masterSequence.AddEffect(masterPlaceholder, EffectType.Fly, EffectSubtype.Bottom, EffectTriggerType.OnClick);
}

var slide = presentation.Slides.AddEmptySlide(layoutSlide);
var slidePlaceholder = FindPlaceholderWithBase(slide);

if (slidePlaceholder == null)
{
    throw new InvalidOperationException("The slide does not contain a placeholder linked to its layout slide.");
}

slide.Timeline.MainSequence.AddEffect(slidePlaceholder, EffectType.RandomBars, EffectSubtype.Horizontal, EffectTriggerType.OnClick);
PrintEffects("Normal slide", slide.Timeline.MainSequence.GetEffectsByShape(slidePlaceholder));

var baseLayoutPlaceholder = slidePlaceholder.GetBasePlaceholder();
if (baseLayoutPlaceholder != null)
{
    PrintEffects("Layout slide", layoutSlide.Timeline.MainSequence.GetEffectsByShape(baseLayoutPlaceholder));

    var baseMasterPlaceholder = baseLayoutPlaceholder.GetBasePlaceholder();
    if (baseMasterPlaceholder != null)
    {
        PrintEffects("Master slide", layoutSlide.MasterSlide.Timeline.MainSequence.GetEffectsByShape(baseMasterPlaceholder));
    }
}

presentation.Save("placeholder-animations.pptx", SaveFormat.Pptx);

static IShape FindPlaceholderWithBase(ISlide slide)
{
    foreach (var shape in slide.Shapes)
    {
        if (shape.GetBasePlaceholder() != null)
        {
            return shape;
        }
    }

    return null;
}

static void PrintEffects(string source, IEffect[] effects)
{
    Console.WriteLine($"{source}: {effects.Length} effect(s)");

    foreach (var effect in effects)
    {
        Console.WriteLine($"  {effect.Type} {effect.Subtype}");
    }
}
```

## **Cambiar la temporización de la animación**

El cuadro de diálogo **Timing** de PowerPoint se corresponde con las propiedades de [ITiming](https://reference.aspose.com/slides/es/net/aspose.slides.animation/itiming/).

![Cuadro de diálogo Timing de PowerPoint para un efecto de animación](shape-animation.png)

- **Start** se corresponde con [ITiming.TriggerType](https://reference.aspose.com/slides/es/net/aspose.slides.animation/itiming/triggertype/).
- **Duration** se corresponde con [ITiming.Duration](https://reference.aspose.com/slides/es/net/aspose.slides.animation/itiming/duration/), en segundos.
- **Delay** se corresponde con [ITiming.TriggerDelayTime](https://reference.aspose.com/slides/es/net/aspose.slides.animation/itiming/triggerdelaytime/), en segundos.
- **Repeat** se corresponde con [ITiming.RepeatCount](https://reference.aspose.com/slides/es/net/aspose.slides.animation/itiming/repeatcount/), [ITiming.RepeatUntilNextClick](https://reference.aspose.com/slides/es/net/aspose.slides.animation/itiming/repeatuntilnextclick/) o [ITiming.RepeatUntilEndSlide](https://reference.aspose.com/slides/es/net/aspose.slides.animation/itiming/repeatuntilendslide/).
- **Rewind when done playing** se corresponde con [ITiming.Rewind](https://reference.aspose.com/slides/es/net/aspose.slides.animation/itiming/rewind/).

Este ejemplo independiente añade un efecto, cambia su temporización mediante el objeto devuelto por [ISequence.AddEffect](https://reference.aspose.com/slides/es/net/aspose.slides.animation/isequence/addeffect/) y guarda el resultado. Mantener la referencia devuelta a [IEffect](https://reference.aspose.com/slides/es/net/aspose.slides.animation/ieffect/) evita un índice de colección innecesario.

```csharp
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 120, 100, 320, 80);
shape.TextFrame.Text = "Timed animation";

var effect = slide.Timeline.MainSequence.AddEffect(shape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);
effect.Timing.TriggerType = EffectTriggerType.OnClick;
effect.Timing.Duration = 2.0f;
effect.Timing.TriggerDelayTime = 0.5f;
effect.Timing.RepeatUntilNextClick = false;
effect.Timing.RepeatUntilEndSlide = false;
effect.Timing.RepeatCount = 2.0f;
effect.Timing.Rewind = true;

presentation.Save("shape-animation-timing.pptx", SaveFormat.Pptx);
```

Utilice un modo de repetición de forma intencionada. Combinar un recuento de repeticiones con una bandera “until” puede producir resultados confusos en diferentes visores. Al cambiar los modos de repetición, establezca primero [ITiming.RepeatUntilNextClick](https://reference.aspose.com/slides/es/net/aspose.slides.animation/itiming/repeatuntilnextclick/) y [ITiming.RepeatUntilEndSlide](https://reference.aspose.com/slides/es/net/aspose.slides.animation/itiming/repeatuntilendslide/) y después [ITiming.RepeatCount](https://reference.aspose.com/slides/es/net/aspose.slides.animation/itiming/repeatcount/), porque establecer cualquiera de las banderas también cambia el modo de repetición activo.

## **Añadir y extraer sonidos de animación**

Un efecto de animación puede hacer referencia a audio incrustado a través de [IEffect.Sound](https://reference.aspose.com/slides/es/net/aspose.slides.animation/ieffect/sound/). [IEffect.StopPreviousSound](https://reference.aspose.com/slides/es/net/aspose.slides.animation/ieffect/stopprevioussound/) indica a un efecto que detenga el audio iniciado por un efecto anterior.

### **Añadir un sonido a un efecto**

El siguiente ejemplo espera un archivo de audio local llamado `animation-sound.wav`. Crea dos efectos, incrusta ese archivo como sonido del primer efecto y configura el segundo efecto para que detenga el sonido. Utiliza los objetos devueltos por [ISequence.AddEffect](https://reference.aspose.com/slides/es/net/aspose.slides.animation/isequence/addeffect/), por lo que no se necesita ningún índice de secuencia.

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var firstShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 80, 100, 240, 80);
var secondShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 400, 100, 240, 80);
firstShape.TextFrame.Text = "Starts sound";
secondShape.TextFrame.Text = "Stops sound";

var sequence = slide.Timeline.MainSequence;
var firstEffect = sequence.AddEffect(firstShape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);
var secondEffect = sequence.AddEffect(secondShape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);

var audioData = File.ReadAllBytes("animation-sound.wav");
var effectSound = presentation.Audios.AddAudio(audioData);
firstEffect.Sound = effectSound;
secondEffect.StopPreviousSound = true;

presentation.Save("shape-animation-sound.pptx", SaveFormat.Pptx);
```

### **Extraer sonidos incrustados de efectos**

El siguiente ejemplo espera una presentación local llamada `presentation-with-animation-sounds.pptx`. Explora tanto las secuencias principales como las interactivas y escribe cada sonido de efecto incrustado en el directorio `extracted-animation-sounds`. La extensión se selecciona a partir del tipo MIME de audio expuesto por [IAudio.ContentType](https://reference.aspose.com/slides/es/net/aspose.slides/iaudio/contenttype/).

```csharp
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Animation;

var inputPath = "presentation-with-animation-sounds.pptx";
var outputDirectory = "extracted-animation-sounds";

Directory.CreateDirectory(outputDirectory);

using var presentation = new Presentation(inputPath);
var soundIndex = 1;

foreach (var slide in presentation.Slides)
{
    SaveSounds(slide.Timeline.MainSequence, outputDirectory, ref soundIndex);

    foreach (var sequence in slide.Timeline.InteractiveSequences)
    {
        SaveSounds(sequence, outputDirectory, ref soundIndex);
    }
}

Console.WriteLine($"Extracted {soundIndex - 1} sound file(s) to {Path.GetFullPath(outputDirectory)}.");

static void SaveSounds(ISequence sequence, string outputDirectory, ref int soundIndex)
{
    foreach (var effect in sequence)
    {
        if (effect.Sound == null)
            continue;

        var extension = GetAudioExtension(effect.Sound.ContentType);
        var outputPath = Path.Combine(outputDirectory, $"effect-sound-{soundIndex}{extension}");
        File.WriteAllBytes(outputPath, effect.Sound.BinaryData);
        soundIndex++;
    }
}

static string GetAudioExtension(string contentType)
{
    var normalizedType = contentType == null ? string.Empty : contentType.ToLowerInvariant();

    if (normalizedType == "audio/mpeg")
        return ".mp3";

    if (normalizedType == "audio/mp4")
        return ".m4a";

    if (normalizedType == "audio/ogg")
        return ".ogg";

    if (normalizedType == "audio/wav" || normalizedType == "audio/x-wav")
        return ".wav";

    return ".bin";
}
```

Para objetos de audio grandes, utilice [IAudio.GetStream](https://reference.aspose.com/slides/es/net/aspose.slides/iaudio/getstream/) y copie la secuencia a un archivo en lugar de cargar todo el objeto en una matriz de bytes.

## **Establecer el comportamiento después de la animación**

La opción **After animation** controla lo que ocurre con una forma después de que su efecto finaliza.

![Cuadro de diálogo de opciones de efecto de PowerPoint que muestra la configuración After animation](shape-after-animation.png)

La enumeración [AfterAnimationType](https://reference.aspose.com/slides/es/net/aspose.slides.animation/afteranimationtype/) permite dejar la forma sin cambios, cambiar su color, ocultarla después de la animación o ocultarla en el siguiente clic. Cuando el tipo es [AfterAnimationType.Color](https://reference.aspose.com/slides/es/net/aspose.slides.animation/afteranimationtype/), también establezca [IEffect.AfterAnimationColor](https://reference.aspose.com/slides/es/net/aspose.slides.animation/ieffect/afteranimationcolor/).

Este ejemplo independiente crea un efecto, establece su comportamiento después de la animación mediante el objeto de efecto devuelto y guarda el resultado.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 120, 100, 320, 80);
shape.TextFrame.Text = "Dim after animation";

var effect = slide.Timeline.MainSequence.AddEffect(shape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);
effect.AfterAnimationType = AfterAnimationType.Color;
effect.AfterAnimationColor.Color = Color.LightGray;

presentation.Save("shape-animation-after-effect.pptx", SaveFormat.Pptx);
```

Cambiar el tipo fuera de [AfterAnimationType.Color](https://reference.aspose.com/slides/es/net/aspose.slides.animation/afteranimationtype/) borra la configuración de color después de la animación.

## **Animar texto**

La animación de texto tiene dos controles relacionados:

- [ITextAnimation.BuildType](https://reference.aspose.com/slides/es/net/aspose.slides.animation/itextanimation/buildtype/) controla si los párrafos aparecen juntos o por nivel de párrafo.
- [IEffect.AnimateTextType](https://reference.aspose.com/slides/es/net/aspose.slides.animation/ieffect/animatetexttype/) controla si el texto aparece de una sola vez, por palabra o por letra. [IEffect.DelayBetweenTextParts](https://reference.aspose.com/slides/es/net/aspose.slides.animation/ieffect/delaybetweentextparts/) establece el retraso entre palabras o letras. Un valor positivo es un porcentaje de la duración del efecto; un valor negativo es un retraso en segundos.

El siguiente ejemplo independiente anima las palabras en un cuadro de texto. [BuildType.AsOneObject](https://reference.aspose.com/slides/es/net/aspose.slides.animation/buildtype/) desactiva la construcción párrafo a párrafo para que la configuración por palabra se aplique a todo el marco de texto.

```csharp
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var textBox = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 80, 80, 560, 100);
textBox.TextFrame.Text = "Aspose.Slides animates this sentence word by word.";

var effect = slide.Timeline.MainSequence.AddEffect(textBox, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);
effect.TextAnimation.BuildType = BuildType.AsOneObject;
effect.AnimateTextType = AnimateTextType.ByWord;
effect.DelayBetweenTextParts = 20.0f;

presentation.Save("animated-text.pptx", SaveFormat.Pptx);
```

Para construir un cuadro de texto por párrafo, establezca [BuildType.ByLevelParagraphs1](https://reference.aspose.com/slides/es/net/aspose.slides.animation/buildtype/) (u otro nivel de párrafo). Para orientar un único párrafo con su propio efecto, utilice la sobrecarga de [ISequence.AddEffect](https://reference.aspose.com/slides/es/net/aspose.slides.animation/isequence/addeffect/) que acepta un [IParagraph](https://reference.aspose.com/slides/es/net/aspose.slides/iparagraph/). Consulte [Animated Text](/slides/es/net/animated-text/) para ejemplos a nivel de párrafo.

## **Exportar y notas de compatibilidad**

- Guardar en PPT o PPTX conserva el modelo de animación, pero la reproducción final depende del visor de la presentación.
- PDF e imágenes estáticas no reproducen animaciones. Utilice la [exportación a HTML5](/slides/es/net/export-to-html5/), GIF animado o la [conversión a video](/slides/es/net/convert-powerpoint-to-video/) cuando la salida deba mostrar movimiento.
- Para HTML5, habilite [Html5Options.AnimateShapes](https://reference.aspose.com/slides/es/net/aspose.slides.export/html5options/animateshapes/) y, cuando sea necesario, [Html5Options.AnimateTransitions](https://reference.aspose.com/slides/es/net/aspose.slides.export/html5options/animatetransitions/).
- La renderización de video admite muchos efectos comunes de entrada, énfasis, salida y trayectoria de movimiento, pero no todos los efectos de PowerPoint están soportados. Consulte la tabla actual de [animaciones y efectos compatibles](/slides/es/net/convert-powerpoint-to-video/#supported-animations-and-effects) y pruebe presentaciones críticas con la versión de Aspose.Slides que va a utilizar.
- Los efectos personalizados avanzados y los efectos importados de otros formatos de presentación pueden preservarse en el archivo pero renderizarse de forma distinta en PowerPoint, HTML5 o video. Valide el resultado exportado en lugar de confiar solo en el nombre del efecto.

## **FAQ**

**¿Por qué una animación aparece en PowerPoint pero no en un PDF?**

PDF es un formato estático, por lo que las animaciones y transiciones de diapositiva no se reproducen. Exporte a HTML5, GIF animado o video cuando sea necesario conservar el movimiento.

**¿Por qué un efecto se reproduce de manera diferente en un video?**

La exportación a video renderiza las animaciones en lugar de almacenar el comportamiento original de PowerPoint. Algunos efectos avanzados no están soportados o se aproximan. Revise la tabla de efectos compatibles y pruebe la presentación real antes de su uso en producción.

**¿Mover una forma hacia adelante o atrás cambia su orden de animación?**

No. El orden Z de la forma controla la superposición, mientras que el orden de la secuencia y los disparadores controlan la reproducción de la animación. Modifique la línea de tiempo si necesita un orden de reproducción distinto.