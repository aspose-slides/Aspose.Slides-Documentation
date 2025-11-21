---
title: Convertir presentaciones de PowerPoint a video en .NET
linktitle: PowerPoint a video
type: docs
weight: 130
url: /es/net/convert-powerpoint-to-video/
keywords:
- convertir PowerPoint
- convertir presentación
- convertir PPT
- convertir PPTX
- PowerPoint a video
- presentación a video
- PPT a video
- PPTX a video
- PowerPoint a MP4
- presentación a MP4
- PPT a MP4
- PPTX a MP4
- guardar PPT como MP4
- guardar PPTX como MP4
- exportar PPT a MP4
- exportar PPTX a MP4
- conversión de video
- PowerPoint
- .NET
- C#
- Aspose.Slides
description: "Aprenda cómo convertir presentaciones de PowerPoint a video en .NET. Descubra código de muestra en C# y técnicas de automatización para optimizar su flujo de trabajo."
---

## **Visión general**

Al convertir su presentación de PowerPoint o OpenDocument a video, obtiene:

**Mayor accesibilidad:** Todos los dispositivos, independientemente de la plataforma, están equipados con reproductores de video por defecto, lo que facilita a los usuarios abrir o reproducir videos en comparación con las aplicaciones tradicionales de presentación.

**Alcance más amplio:** Los videos le permiten llegar a una audiencia mayor y presentar la información en un formato más atractivo. Las encuestas y estadísticas indican que la gente prefiere ver y consumir contenido de video sobre otras formas, haciendo que su mensaje sea más impactante.

{{% alert color="primary" %}} 

Consulte nuestro [**Convertidor en línea de PowerPoint a Video**](https://products.aspose.app/slides/video) porque ofrece una implementación en vivo y eficaz del proceso descrito aquí.

{{% /alert %}} 

En Aspose.Slides for .NET, implementamos soporte para convertir presentaciones a video.

* Utilice Aspose.Slides for .NET para generar fotogramas a partir de las diapositivas de la presentación a una velocidad de fotogramas especificada (FPS).
* Luego, utilice una utilidad de terceros como ffmpeg para compilar estos fotogramas en un video.

## **Convertir una presentación de PowerPoint a video**

1. Utilice el comando `dotnet add package` para agregar Aspose.Slides y la biblioteca FFMpegCore a su proyecto:
   * ejecute `dotnet add package Aspose.Slides.NET --version 22.11.0`
   * ejecute `dotnet add package FFMpegCore --version 4.8.0`
2. Descargue ffmpeg desde [aquí](https://ffmpeg.org/download.html).
3. FFMpegCore requiere que indique la ruta al ffmpeg descargado (p. ej., extraído en "C:\tools\ffmpeg"):  
```cs
    GlobalFFOptions.Configure(new FFOptions { BinaryFolder = @"c:\tools\ffmpeg\bin" });
```

4. Ejecute el código de conversión de PowerPoint a video.

Este código C# muestra cómo convertir una presentación (que contiene una forma y dos efectos de animación) en un video:
```c#
using System.Collections.Generic;
using Aspose.Slides;
using FFMpegCore; // usará los binarios de FFmpeg que extrajimos a C:\tools\ffmpeg anteriormente.
using Aspose.Slides.Animation;

using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // Añadir una forma sonriente y luego animarla.
    IAutoShape smile = slide.Shapes.AddAutoShape(ShapeType.SmileyFace, 110, 20, 500, 500);

    IEffect effectIn = slide.Timeline.MainSequence.AddEffect(
        smile, EffectType.Fly, EffectSubtype.TopLeft, EffectTriggerType.AfterPrevious);

    IEffect effectOut = slide.Timeline.MainSequence.AddEffect(
        smile, EffectType.Fly, EffectSubtype.BottomRight, EffectTriggerType.AfterPrevious);

    effectIn.Timing.Duration = 2f;
    effectOut.PresetClassType = EffectPresetClassType.Exit;

    const int Fps = 33;
    List<string> frames = new List<string>();

    using (var animationsGenerator = new PresentationAnimationsGenerator(presentation))
    using (var player = new PresentationPlayer(animationsGenerator, Fps))
    {
        player.FrameTick += (sender, args) =>
        {
            string frame = $"frame_{(sender.FrameIndex):D4}.png";
            args.GetFrame().Save(frame);
            frames.Add(frame);
        };
        animationsGenerator.Run(presentation.Slides);
    }

    // Configurar la carpeta de los binarios ffmpeg. Ver esta página: https://github.com/rosenbjerg/FFMpegCore#installation
    GlobalFFOptions.Configure(new FFOptions { BinaryFolder = @"c:\tools\ffmpeg\bin" });

    // Convertir los fotogramas a un video webm.
    FFMpeg.JoinImageSequence("smile.webm", Fps, frames.Select(frame => ImageInfo.FromPath(frame)).ToArray());
}
```


## **Efectos de video**

Al convertir una presentación de PowerPoint a video usando Aspose.Slides for .NET, puede aplicar varios efectos de video para mejorar la calidad visual del resultado. Estos efectos le permiten controlar la apariencia de las diapositivas en el video final añadiendo transiciones suaves, animaciones y otros elementos visuales. Esta sección explica las opciones de efectos de video disponibles y muestra cómo aplicarlas.

{{% alert color="primary" %}} 

Ver:
- [Mejorar presentaciones de PowerPoint con animaciones en C#](https://docs.aspose.com/slides/net/powerpoint-animation/)
- [Animación de forma](https://docs.aspose.com/slides/net/shape-animation/)
- [Aplicar efectos de forma en PowerPoint usando C#](https://docs.aspose.com/slides/net/shape-effect/)

{{% /alert %}} 

Las animaciones y transiciones hacen que las presentaciones sean más atractivas e interesantes — y lo mismo ocurre con los videos. Añadamos otra diapositiva y transición al código de la presentación anterior:
```c#
 // Agregar una forma sonriente y animarla.
 // ...
 // Agregar una nueva diapositiva y una transición animada.
 ISlide newSlide = presentation.Slides.AddEmptySlide(presentation.Slides[0].LayoutSlide);
 newSlide.Background.Type = BackgroundType.OwnBackground;
 newSlide.Background.FillFormat.FillType = FillType.Solid;
 newSlide.Background.FillFormat.SolidFillColor.Color = Color.Indigo;
 newSlide.SlideShowTransition.Type = TransitionType.Push;
```


Aspose.Slides también admite animaciones de texto. En este ejemplo, animamos párrafos en objetos para que aparezcan uno tras otro, con un retraso de un segundo entre ellos:
```c#
using System.Collections.Generic;
using Aspose.Slides.Export;
using Aspose.Slides;
using FFMpegCore;
using Aspose.Slides.Animation;

using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // Agregar texto y animaciones.
    IAutoShape autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 210, 120, 300, 300);
    Paragraph para1 = new Paragraph();
    para1.Portions.Add(new Portion("Aspose Slides for .NET"));
    Paragraph para2 = new Paragraph();
    para2.Portions.Add(new Portion("Convert a PowerPoint presentation with text to video"));

    Paragraph para3 = new Paragraph();
    para3.Portions.Add(new Portion("paragraph by paragraph"));
    autoShape.TextFrame.Paragraphs.Add(para1);
    autoShape.TextFrame.Paragraphs.Add(para2);
    autoShape.TextFrame.Paragraphs.Add(para3);
    autoShape.TextFrame.Paragraphs.Add(new Paragraph());

    IEffect effect1 = slide.Timeline.MainSequence.AddEffect(
        para1, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    IEffect effect2 = slide.Timeline.MainSequence.AddEffect(
        para2, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    IEffect effect3 = slide.Timeline.MainSequence.AddEffect(
        para3, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    IEffect effect4 = slide.Timeline.MainSequence.AddEffect(
        para3, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    effect1.Timing.TriggerDelayTime = 1f;
    effect2.Timing.TriggerDelayTime = 1f;
    effect3.Timing.TriggerDelayTime = 1f;
    effect4.Timing.TriggerDelayTime = 1f;

    const int Fps = 33;
    List<string> frames = new List<string>();

    using (var animationsGenerator = new PresentationAnimationsGenerator(presentation))
    using (var player = new PresentationPlayer(animationsGenerator, Fps))
    {
        player.FrameTick += (sender, args) =>
        {
            string frame = $"frame_{(sender.FrameIndex):D4}.png";
            args.GetFrame().Save(frame);
            frames.Add(frame);
        };

        animationsGenerator.Run(presentation.Slides);
    }

    // Configurar la carpeta de binarios ffmpeg. Ver esta página: https://github.com/rosenbjerg/FFMpegCore#installation
    GlobalFFOptions.Configure(new FFOptions { BinaryFolder = @"c:\tools\ffmpeg\bin" });

    // Convertir los fotogramas a un video webm.
    FFMpeg.JoinImageSequence("text_animation.webm", Fps, frames.Select(frame => ImageInfo.FromPath(frame)).ToArray());
}
```


## **Clases de conversión de video**

Para habilitar tareas de conversión de PowerPoint a video, Aspose.Slides for .NET proporciona las clases [PresentationAnimationsGenerator](https://reference.aspose.com/slides/net/aspose.slides.export/presentationanimationsgenerator/) y [PresentationPlayer](https://reference.aspose.com/slides/net/aspose.slides.export/presentationplayer/).

`PresentationAnimationsGenerator` le permite establecer el tamaño del fotograma para el video (que se creará más tarde) y el valor FPS (fotogramas por segundo) a través de su constructor. Si pasa una instancia de una presentación, se utilizará su `Presentation.SlideSize` y genera animaciones que [PresentationPlayer](https://reference.aspose.com/slides/net/aspose.slides.export/presentationplayer/) utiliza.

Cuando se generan animaciones, se dispara un evento `NewAnimation` para cada animación subsiguiente, que incluye un parámetro [IPresentationAnimationPlayer](https://reference.aspose.com/slides/net/aspose.slides.export/ipresentationanimationplayer/). Esta clase representa un reproductor para una animación individual.

Para trabajar con [IPresentationAnimationPlayer](https://reference.aspose.com/slides/net/aspose.slides.export/ipresentationanimationplayer/), utilice la propiedad [Duration](https://reference.aspose.com/slides/net/aspose.slides.export/ipresentationanimationplayer/duration/) (que brinda la duración completa de la animación) y el método [SetTimePosition](https://reference.aspose.com/slides/net/aspose.slides.export/ipresentationanimationplayer/settimeposition/). Cada posición de animación se establece dentro del rango *0 a duración*, y el método `GetFrame` devuelve un Bitmap que representa el estado de la animación en ese momento.
```c#
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // Añadir una forma sonriente y animarla.
    IAutoShape smile = slide.Shapes.AddAutoShape(ShapeType.SmileyFace, 110, 20, 500, 500);

    IEffect effectIn = slide.Timeline.MainSequence.AddEffect(
        smile, EffectType.Fly, EffectSubtype.TopLeft, EffectTriggerType.AfterPrevious);

    IEffect effectOut = slide.Timeline.MainSequence.AddEffect(
        smile, EffectType.Fly, EffectSubtype.BottomRight, EffectTriggerType.AfterPrevious);

    effectIn.Timing.Duration = 2f;
    effectOut.PresetClassType = EffectPresetClassType.Exit;

    using (var animationsGenerator = new PresentationAnimationsGenerator(presentation))
    {
        animationsGenerator.NewAnimation += animationPlayer =>
        {
            Console.WriteLine($"Total animation duration: {animationPlayer.Duration}");

            animationPlayer.SetTimePosition(0);          // El estado inicial de la animación.
            Bitmap bitmap = animationPlayer.GetFrame();  // El bitmap del estado inicial de la animación.

            animationPlayer.SetTimePosition(animationPlayer.Duration);          // El estado final de la animación.
            Bitmap lastBitmap = animationPlayer.GetFrame();             // El último fotograma de la animación.
            lastBitmap.Save("last.png");
        };
    }
}
```


Para reproducir todas las animaciones de una presentación a la vez, se utiliza la clase [PresentationPlayer](https://reference.aspose.com/slides/net/aspose.slides.export/presentationplayer/). Esta clase recibe una instancia de [PresentationAnimationsGenerator](https://reference.aspose.com/slides/net/aspose.slides.export/presentationanimationsgenerator/) y un valor FPS para los efectos en su constructor, y luego llama al evento `FrameTick` para todas las animaciones para reproducirlas:
```c#
using (Presentation presentation = new Presentation("animated.pptx"))
{
    using (var animationsGenerator = new PresentationAnimationsGenerator(presentation))
    using (var player = new PresentationPlayer(animationsGenerator, 33))
    {
        player.FrameTick += (sender, args) =>
        {
            args.GetFrame().Save($"frame_{sender.FrameIndex}.png");
        };
        animationsGenerator.Run(presentation.Slides);
    }
}
```


Luego, los fotogramas generados pueden compilarse para producir un video. Consulte la sección [Convertir una presentación de PowerPoint a video](/slides/es/net/convert-powerpoint-to-video/#convert-a-powerpoint-presentation-to-video).

## **Animaciones y efectos compatibles**

Al convertir una presentación de PowerPoint a video usando Aspose.Slides for .NET, es importante comprender qué animaciones y efectos son compatibles en el resultado. Aspose.Slides admite una amplia gama de efectos comunes de entrada, salida y énfasis, como desvanecer, volar, acercar y girar. Sin embargo, algunas animaciones avanzadas o personalizadas pueden no preservarse completamente o pueden aparecer de forma diferente en el video final. Esta sección describe las animaciones y efectos compatibles.

**Entrada**:

| Tipo de animación | Aspose.Slides | PowerPoint |
|---|---|---|
| **Appear** | ![not supported](x.png) | ![supported](v.png) |
| **Fade** | ![supported](v.png) | ![supported](v.png) |
| **Fly In** | ![supported](v.png) | ![supported](v.png) |
| **Float In** | ![supported](v.png) | ![supported](v.png) |
| **Split** | ![supported](v.png) | ![supported](v.png) |
| **Wipe** | ![supported](v.png) | ![supported](v.png) |
| **Shape** | ![supported](v.png) | ![supported](v.png) |
| **Wheel** | ![supported](v.png) | ![supported](v.png) |
| **Random Bars** | ![supported](v.png) | ![supported](v.png) |
| **Grow & Turn** | ![not supported](x.png) | ![supported](v.png) |
| **Zoom** | ![supported](v.png) | ![supported](v.png) |
| **Swivel** | ![supported](v.png) | ![supported](v.png) |
| **Bounce** | ![supported](v.png) | ![supported](v.png) |

**Énfasis**:

| Tipo de animación | Aspose.Slides | PowerPoint |
|---|---|---|
| **Pulse** | ![not supported](x.png) | ![supported](v.png) |
| **Color Pulse** | ![not supported](x.png) | ![supported](v.png) |
| **Teeter** | ![supported](v.png) | ![supported](v.png) |
| **Spin** | ![supported](v.png) | ![supported](v.png) |
| **Grow/Shrink** | ![not supported](x.png) | ![supported](v.png) |
| **Desaturate** | ![not supported](x.png) | ![supported](v.png) |
| **Darken** | ![not supported](x.png) | ![supported](v.png) |
| **Lighten** | ![not supported](x.png) | ![supported](v.png) |
| **Transparency** | ![not supported](x.png) | ![supported](v.png) |
| **Object Color** | ![not supported](x.png) | ![supported](v.png) |
| **Complementary Color** | ![not supported](x.png) | ![supported](v.png) |
| **Line Color** | ![not supported](x.png) | ![supported](v.png) |
| **Fill Color** | ![not supported](x.png) | ![supported](v.png) |

**Salida**:

| Tipo de animación | Aspose.Slides | PowerPoint |
|---|---|---|
| **Disappear** | ![not supported](x.png) | ![supported](v.png) |
| **Fade** | ![supported](v.png) | ![supported](v.png) |
| **Fly Out** | ![supported](v.png) | ![supported](v.png) |
| **Float Out** | ![supported](v.png) | ![supported](v.png) |
| **Split** | ![supported](v.png) | ![supported](v.png) |
| **Wipe** | ![supported](v.png) | ![supported](v.png) |
| **Shape** | ![supported](v.png) | ![supported](v.png) |
| **Random Bars** | ![supported](v.png) | ![supported](v.png) |
| **Shrink & Turn** | ![not supported](x.png) | ![supported](v.png) |
| **Zoom** | ![supported](v.png) | ![supported](v.png) |
| **Swivel** | ![supported](v.png) | ![supported](v.png) |
| **Bounce** | ![supported](v.png) | ![supported](v.png) |

**Rutas de movimiento**:

| Tipo de animación | Aspose.Slides | PowerPoint |
|---|---|---|
| **Lines** | ![supported](v.png) | ![supported](v.png) |
| **Arcs** | ![supported](v.png) | ![supported](v.png) |
| **Turns** | ![supported](v.png) | ![supported](v.png) |
| **Shapes** | ![supported](v.png) | ![supported](v.png) |
| **Loops** | ![supported](v.png) | ![supported](v.png) |
| **Custom Path** | ![supported](v.png) | ![supported](v.png) |

## **Efectos de transición de diapositivas compatibles**

Los efectos de transición de diapositivas juegan un papel importante en la creación de cambios suaves y visualmente atractivos entre diapositivas en un video. Aspose.Slides for .NET admite una variedad de efectos de transición de uso común para ayudar a preservar el flujo y el estilo de su presentación original. Esta sección destaca los efectos de transición compatibles durante el proceso de conversión.

**Sutil**:

| Tipo de animación | Aspose.Slides | PowerPoint |
|---|---|---|
| **Morph** | ![not supported](x.png) | ![supported](v.png) |
| **Fade** | ![supported](v.png) | ![supported](v.png) |
| **Push** | ![supported](v.png) | ![supported](v.png) |
| **Pull** | ![supported](v.png) | ![supported](v.png) |
| **Wipe** | ![supported](v.png) | ![supported](v.png) |
| **Split** | ![supported](v.png) | ![supported](v.png) |
| **Reveal** | ![not supported](x.png) | ![supported](v.png) |
| **Random Bars** | ![supported](v.png) | ![supported](v.png) |
| **Shape** | ![not supported](x.png) | ![supported](v.png) |
| **Uncover** | ![not supported](x.png) | ![supported](v.png) |
| **Cover** | ![supported](v.png) | ![supported](v.png) |
| **Flash** | ![supported](v.png) | ![supported](v.png) |
| **Strips** | ![supported](v.png) | ![supported](v.png) |

**Emocionante**:

| Tipo de animación | Aspose.Slides | PowerPoint |
|---|---|---|
| **Fall Over** | ![not supported](x.png) | ![supported](v.png) |
| **Drape** | ![not supported](x.png) | ![supported](v.png) |
| **Curtains** | ![not supported](x.png) | ![supported](v.png) |
| **Wind** | ![not supported](x.png) | ![supported](v.png) |
| **Prestige** | ![not supported](x.png) | ![supported](v.png) |
| **Fracture** | ![not supported](x.png) | ![supported](v.png) |
| **Crush** | ![not supported](x.png) | ![supported](v.png) |
| **Peel Off** | ![not supported](x.png) | ![supported](v.png) |
| **Page Curl** | ![not supported](x.png) | ![supported](v.png) |
| **Airplane** | ![not supported](x.png) | ![supported](v.png) |
| **Origami** | ![not supported](x.png) | ![supported](v.png) |
| **Dissolve** | ![supported](v.png) | ![supported](v.png) |
| **Checkerboard** | ![not supported](x.png) | ![supported](v.png) |
| **Blinds** | ![not supported](x.png) | ![supported](v.png) |
| **Clock** | ![supported](v.png) | ![supported](v.png) |
| **Ripple** | ![not supported](x.png) | ![supported](v.png) |
| **Honeycomb** | ![not supported](x.png) | ![supported](v.png) |
| **Glitter** | ![not supported](x.png) | ![supported](v.png) |
| **Vortex** | ![not supported](x.png) | ![supported](v.png) |
| **Shred** | ![not supported](x.png) | ![supported](v.png) |
| **Switch** | ![not supported](x.png) | ![supported](v.png) |
| **Flip** | ![not supported](x.png) | ![supported](v.png) |
| **Gallery** | ![not supported](x.png) | ![supported](v.png) |
| **Cube** | ![not supported](x.png) | ![supported](v.png) |
| **Doors** | ![not supported](x.png) | ![supported](v.png) |
| **Box** | ![not supported](x.png) | ![supported](v.png) |
| **Comb** | ![not supported](x.png) | ![supported](v.png) |
| **Zoom** | ![supported](v.png) | ![supported](v.png) |
| **Random** | ![not supported](x.png) | ![supported](v.png) |

**Contenido dinámico**:

| Tipo de animación | Aspose.Slides | PowerPoint |
|---|---|---|
| **Pan** | ![not supported](x.png) | ![supported](v.png) |
| **Ferris Wheel** | ![supported](v.png) | ![supported](v.png) |
| **Conveyor** | ![not supported](x.png) | ![supported](v.png) |
| **Rotate** | ![not supported](x.png) | ![supported](v.png) |
| **Orbit** | ![not supported](x.png) | ![supported](v.png) |
| **Fly Through** | ![supported](v.png) | ![supported](v.png) |

## **Preguntas frecuentes**

**¿Es posible convertir presentaciones protegidas con contraseña?**

Sí, Aspose.Slides for .NET permite trabajar con presentaciones protegidas con contraseña. Al procesar dichos archivos, debe proporcionar la contraseña correcta para que la biblioteca pueda acceder al contenido de la presentación.

**¿Aspose.Slides for .NET admite su uso en soluciones en la nube?**

Sí, Aspose.Slides for .NET puede integrarse en aplicaciones y servicios en la nube. La biblioteca está diseñada para funcionar en entornos de servidor, asegurando alto rendimiento y escalabilidad para el procesamiento por lotes de archivos.

**¿Existen limitaciones de tamaño para las presentaciones durante la conversión?**

Aspose.Slides for .NET es capaz de manejar presentaciones de prácticamente cualquier tamaño. Sin embargo, al trabajar con archivos muy grandes, pueden requerirse recursos del sistema adicionales, y a veces se recomienda optimizar la presentación para mejorar el rendimiento.