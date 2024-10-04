---
title: Convertir PowerPoint a Video
type: docs
weight: 130
url: /net/convert-powerpoint-to-video/
keywords: "Convertir PowerPoint, PPT, PPTX, Presentación, Video, MP4, PPT a video, PPT a MP4, C#, Csharp, .NET, Aspose.Slides"
description: "Convertir PowerPoint a Video en C# o .NET"
---

Al convertir tu presentación de PowerPoint a video, obtienes 

* **Aumento en accesibilidad:** Todos los dispositivos (independientemente de la plataforma) vienen equipados con reproductores de video por defecto en comparación con las aplicaciones para abrir presentaciones, por lo que a los usuarios les resulta más fácil abrir o reproducir videos.
* **Mayor alcance:** A través de los videos, puedes alcanzar a una gran audiencia y dirigirla con información que de otro modo podría parecer tediosa en una presentación. La mayoría de las encuestas y estadísticas sugieren que las personas ven y consumen videos más que otras formas de contenido, y generalmente prefieren dicho contenido.

{{% alert color="primary" %}} 

Es posible que desees revisar nuestro [**Convertidor de PowerPoint a Video en Línea**](https://products.aspose.app/slides/conversion/ppt-to-word) porque es una implementación en vivo y efectiva del proceso descrito aquí.

{{% /alert %}} 

## **Conversión de PowerPoint a Video en Aspose.Slides**

En [Aspose.Slides 22.11](https://docs.aspose.com/slides/net/aspose-slides-for-net-22-11-release-notes/), implementamos soporte para la conversión de presentación a video. 

* Usa Aspose.Slides para generar un conjunto de cuadros (de las diapositivas de la presentación) que correspondan a un cierto FPS (cuadros por segundo).
* Usa una utilidad de terceros como FFMpegCore (ffmpeg) para crear un video basado en los cuadros. 

### **Convertir PowerPoint a Video**

1. Usa el comando dotnet add package para agregar Aspose.Slides y la biblioteca FFMpegCore a tu proyecto:
   * ejecuta `dotnet add package Aspose.Slides.NET --version 22.11.0`
   * ejecuta `dotnet add package FFMpegCore --version 4.8.0`
2. Descarga ffmpeg [aquí](https://ffmpeg.org/download.html).
3. FFMpegCore requiere que especifiques la ruta al ffmpeg descargado (por ejemplo, extraído a "C:\tools\ffmpeg"): `GlobalFFOptions.Configure(new FFOptions { BinaryFolder = @"c:\tools\ffmpeg\bin",} );`
4. Ejecuta el código de PowerPoint a video.

Este código C# te muestra cómo convertir una presentación (que contiene una figura y dos efectos de animación) a un video:

```c#
using System.Collections.Generic;
using Aspose.Slides;
using FFMpegCore; // Usará los binarios de FFmpeg que extrajimos a "c:\tools\ffmpeg" anteriormente
using Aspose.Slides.Animation;
using (Presentation presentation = new Presentation())

{
    // Agrega una forma de sonrisa y luego la anima
    IAutoShape smile = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.SmileyFace, 110, 20, 500, 500);
    IEffect effectIn = presentation.Slides[0].Timeline.MainSequence.AddEffect(smile, EffectType.Fly, EffectSubtype.TopLeft, EffectTriggerType.AfterPrevious);
    IEffect effectOut = presentation.Slides[0].Timeline.MainSequence.AddEffect(smile, EffectType.Fly, EffectSubtype.BottomRight, EffectTriggerType.AfterPrevious);
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

    // Configura la carpeta de binarios de ffmpeg. Consulta esta página: https://github.com/rosenbjerg/FFMpegCore#installation
    GlobalFFOptions.Configure(new FFOptions { BinaryFolder = @"c:\tools\ffmpeg\bin", });
    // Convierte los cuadros a video webm
    FFMpeg.JoinImageSequence("smile.webm", Fps, frames.Select(frame => ImageInfo.FromPath(frame)).ToArray());

}
```

## **Efectos de Video**

Puedes aplicar animaciones a objetos en las diapositivas y usar transiciones entre diapositivas. 

{{% alert color="primary" %}} 

Es posible que desees ver estos artículos: [Animación de PowerPoint](https://docs.aspose.com/slides/net/powerpoint-animation/), [Animación de Forma](https://docs.aspose.com/slides/net/shape-animation/), y [Efecto de Forma](https://docs.aspose.com/slides/net/shape-effect/).

{{% /alert %}} 

Las animaciones y transiciones hacen que las presentaciones sean más atractivas e interesantes, y hacen lo mismo por los videos. Agreguemos otra diapositiva y transición al código de la presentación anterior:

```c#
// Agrega una forma de sonrisa y la anima

// ...

// Agrega una nueva diapositiva y transición animada

ISlide newSlide = presentation.Slides.AddEmptySlide(presentation.Slides[0].LayoutSlide);

newSlide.Background.Type = BackgroundType.OwnBackground;

newSlide.Background.FillFormat.FillType = FillType.Solid;

newSlide.Background.FillFormat.SolidFillColor.Color = Color.Indigo;

newSlide.SlideShowTransition.Type = TransitionType.Push;
```

Aspose.Slides también admite animaciones para textos. Así que animamos párrafos en objetos, que aparecerán uno tras otro (con el retraso establecido en un segundo):

```c#
using System.Collections.Generic;
using Aspose.Slides.Export;
using Aspose.Slides;
using FFMpegCore;
using Aspose.Slides.Animation;

using (Presentation presentation = new Presentation())
{
    // Agrega texto y animaciones
    IAutoShape autoShape = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 210, 120, 300, 300);
    Paragraph para1 = new Paragraph();
    para1.Portions.Add(new Portion("Aspose Slides for .NET"));
    Paragraph para2 = new Paragraph();
    para2.Portions.Add(new Portion("convertir la Presentación de PowerPoint con texto a video"));

    Paragraph para3 = new Paragraph();
    para3.Portions.Add(new Portion("párrafo por párrafo"));
    autoShape.TextFrame.Paragraphs.Add(para1);
    autoShape.TextFrame.Paragraphs.Add(para2);
    autoShape.TextFrame.Paragraphs.Add(para3);
    autoShape.TextFrame.Paragraphs.Add(new Paragraph());

    IEffect effect = presentation.Slides[0].Timeline.MainSequence.AddEffect(para1, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    IEffect effect2 = presentation.Slides[0].Timeline.MainSequence.AddEffect(para2, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    IEffect effect3 = presentation.Slides[0].Timeline.MainSequence.AddEffect(para3, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    IEffect effect4 = presentation.Slides[0].Timeline.MainSequence.AddEffect(para3, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    effect.Timing.TriggerDelayTime = 1f;
    effect2.Timing.TriggerDelayTime = 1f;
    effect3.Timing.TriggerDelayTime = 1f;
    effect4.Timing.TriggerDelayTime = 1f;

    // Convierte los cuadros a video
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
    // Configura la carpeta de binarios de ffmpeg. Consulta esta página: https://github.com/rosenbjerg/FFMpegCore#installation

    GlobalFFOptions.Configure(new FFOptions { BinaryFolder = @"c:\tools\ffmpeg\bin", });
    // Convierte los cuadros a video webm
    FFMpeg.JoinImageSequence("text_animation.webm", Fps, frames.Select(frame => ImageInfo.FromPath(frame)).ToArray());

}
```

## **Clases de Conversión de Video**

Para permitirte realizar tareas de conversión de PowerPoint a video, Aspose.Slides proporciona las clases [PresentationAnimationsGenerator](https://reference.aspose.com/slides/net/aspose.slides.export/presentationanimationsgenerator/) y [PresentationPlayer](https://reference.aspose.com/slides/net/aspose.slides.export/presentationplayer/).

PresentationAnimationsGenerator permite establecer el tamaño del cuadro para el video (que se creará más tarde) a través de su constructor. Si pasas una instancia de la presentación, `Presentation.SlideSize` se utilizará y genera animaciones que [PresentationPlayer](https://reference.aspose.com/slides/net/aspose.slides.export/presentationplayer/) usa. 

Cuando se generan animaciones, se genera un evento `NewAnimation` para cada animación subsiguiente, que tiene el parámetro [IPresentationAnimationPlayer](https://reference.aspose.com/slides/net/aspose.slides.export/ipresentationanimationplayer/). Este último es una clase que representa un reproductor para una animación separada.

Para trabajar con [IPresentationAnimationPlayer](https://reference.aspose.com/slides/net/aspose.slides.export/ipresentationanimationplayer/), se utilizan la propiedad [Duration](https://reference.aspose.com/slides/net/aspose.slides.export/ipresentationanimationplayer/duration/) (la duración total de la animación) y el método [SetTimePosition](https://reference.aspose.com/slides/net/aspose.slides.export/ipresentationanimationplayer/settimeposition/). Se establece cada posición de animación dentro del rango *0 a duración*, y luego el método `GetFrame` devolverá un Bitmap que corresponde al estado de la animación en ese momento.

```c#
using (Presentation presentation = new Presentation())
{
    // Agrega una forma de sonrisa y la anima
    IAutoShape smile = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.SmileyFace, 110, 20, 500, 500);
    IEffect effectIn = presentation.Slides[0].Timeline.MainSequence.AddEffect(smile, EffectType.Fly, EffectSubtype.TopLeft, EffectTriggerType.AfterPrevious);
    IEffect effectOut = presentation.Slides[0].Timeline.MainSequence.AddEffect(smile, EffectType.Fly, EffectSubtype.BottomRight, EffectTriggerType.AfterPrevious);
    effectIn.Timing.Duration = 2f;
    effectOut.PresetClassType = EffectPresetClassType.Exit;

    using (var animationsGenerator = new PresentationAnimationsGenerator(presentation))
    {
        animationsGenerator.NewAnimation += animationPlayer =>
        {
            Console.WriteLine($"Duración total de la animación: {animationPlayer.Duration}");
            
            animationPlayer.SetTimePosition(0); // estado inicial de la animación
            Bitmap bitmap = animationPlayer.GetFrame(); // bitmap del estado inicial de la animación

            animationPlayer.SetTimePosition(animationPlayer.Duration); // estado final de la animación
            Bitmap lastBitmap = animationPlayer.GetFrame(); // último cuadro de la animación
            lastBitmap.Save("last.png");
        };
    }
}
```

Para hacer que todas las animaciones en una presentación se reproduzcan a la vez, se utiliza la clase [PresentationPlayer](https://reference.aspose.com/slides/net/aspose.slides.export/presentationplayer/). Esta clase toma una instancia de [PresentationAnimationsGenerator](https://reference.aspose.com/slides/net/aspose.slides.export/presentationanimationsgenerator/) y FPS para efectos en su constructor y luego llama al evento `FrameTick` para todas las animaciones para que se reproduzcan:

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

Luego, los cuadros generados pueden compilarse para producir un video. Consulta la sección [Convertir PowerPoint a Video](https://docs.aspose.com/slides/net/convert-powerpoint-to-video/#convert-powerpoint-to-video).

## **Animaciones y Efectos Soportados**


**Entrada**:

| Tipo de Animación | Aspose.Slides | PowerPoint |
|---|---|---|
| **Aparecer** | ![no soportado](x.png) | ![soportado](v.png) |
| **Desvanecer** | ![soportado](v.png) | ![soportado](v.png) |
| **Entrar volando** | ![soportado](v.png) | ![soportado](v.png) |
| **Entrar flotando** | ![soportado](v.png) | ![soportado](v.png) |
| **Dividir** | ![soportado](v.png) | ![soportado](v.png) |
| **Barrer** | ![soportado](v.png) | ![soportado](v.png) |
| **Forma** | ![soportado](v.png) | ![soportado](v.png) |
| **Rueda** | ![soportado](v.png) | ![soportado](v.png) |
| **Barras aleatorias** | ![soportado](v.png) | ![soportado](v.png) |
| **Crecer y girar** | ![no soportado](x.png) | ![soportado](v.png) |
| **Zoom** | ![soportado](v.png) | ![soportado](v.png) |
| **Girar** | ![soportado](v.png) | ![soportado](v.png) |
| **Rebotar** | ![soportado](v.png) | ![soportado](v.png) |


**Énfasis**:

| Tipo de Animación | Aspose.Slides | PowerPoint |
|---|---|---|
| **Latido** | ![no soportado](x.png) | ![soportado](v.png) |
| **Latido de Color** | ![no soportado](x.png) | ![soportado](v.png) |
| **Balancín** | ![soportado](v.png) | ![soportado](v.png) |
| **Giro** | ![soportado](v.png) | ![soportado](v.png) |
| **Crecer/Encoger** | ![no soportado](x.png) | ![soportado](v.png) |
| **Desaturar** | ![no soportado](x.png) | ![soportado](v.png) |
| **Oscurecer** | ![no soportado](x.png) | ![soportado](v.png) |
| **Aclarar** | ![no soportado](x.png) | ![soportado](v.png) |
| **Transparencia** | ![no soportado](x.png) | ![soportado](v.png) |
| **Color de Objeto** | ![no soportado](x.png) | ![soportado](v.png) |
| **Color Complementario** | ![no soportado](x.png) | ![soportado](v.png) |
| **Color de Línea** | ![no soportado](x.png) | ![soportado](v.png) |
| **Color de Relleno** | ![no soportado](x.png) | ![soportado](v.png) |

**Salida**:

| Tipo de Animación | Aspose.Slides | PowerPoint |
|---|---|---|
| **Desaparecer** | ![no soportado](x.png) | ![soportado](v.png) |
| **Desvanecer** | ![soportado](v.png) | ![soportado](v.png) |
| **Saliendo volando** | ![soportado](v.png) | ![soportado](v.png) |
| **Saliendo flotando** | ![soportado](v.png) | ![soportado](v.png) |
| **Dividir** | ![soportado](v.png) | ![soportado](v.png) |
| **Barrer** | ![soportado](v.png) | ![soportado](v.png) |
| **Forma** | ![soportado](v.png) | ![soportado](v.png) |
| **Barras aleatorias** | ![soportado](v.png) | ![soportado](v.png) |
| **Encoger y girar** | ![no soportado](x.png) | ![soportado](v.png) |
| **Zoom** | ![soportado](v.png) | ![soportado](v.png) |
| **Girar** | ![soportado](v.png) | ![soportado](v.png) |
| **Rebotar** | ![soportado](v.png) | ![soportado](v.png) |

**Rutas de Movimiento:**

| Tipo de Animación | Aspose.Slides | PowerPoint |
|---|---|---|
| **Líneas** | ![soportado](v.png) | ![soportado](v.png) |
| **Arcos** | ![soportado](v.png) | ![soportado](v.png) |
| **Giros** | ![soportado](v.png) | ![soportado](v.png) |
| **Formas** | ![soportado](v.png) | ![soportado](v.png) |
| **Bucles** | ![soportado](v.png) | ![soportado](v.png) |
| **Ruta Personalizada** | ![soportado](v.png) | ![soportado](v.png) |

## **Efectos de Transición de Diapositivas Soportados**

**Sutil**:

| Tipo de Animación | Aspose.Slides | PowerPoint |
|---|---|---|
| **Morfología** | ![no soportado](x.png) | ![soportado](v.png) |
| **Desvanecer** | ![soportado](v.png) | ![soportado](v.png) |
| **Empujar** | ![soportado](v.png) | ![soportado](v.png) |
| **Tirar** | ![soportado](v.png) | ![soportado](v.png) |
| **Barrer** | ![soportado](v.png) | ![soportado](v.png) |
| **Dividir** | ![soportado](v.png) | ![soportado](v.png) |
| **Revelar** | ![no soportado](x.png) | ![soportado](v.png) |
| **Barras aleatorias** | ![soportado](v.png) | ![soportado](v.png) |
| **Forma** | ![no soportado](x.png) | ![soportado](v.png) |
| **Descubrir** | ![no soportado](x.png) | ![soportado](v.png) |
| **Cubrir** | ![soportado](v.png) | ![soportado](v.png) |
| **Destello** | ![soportado](v.png) | ![soportado](v.png) |
| **Tiras** | ![soportado](v.png) | ![soportado](v.png) |

**Emocionante**:

| Tipo de Animación | Aspose.Slides | PowerPoint |
|---|---|---|
| **Caer** | ![no soportado](x.png) | ![soportado](v.png) |
| **Cortina** | ![no soportado](x.png) | ![soportado](v.png) |
| **Cortinas** | ![no soportado](x.png) | ![soportado](v.png) |
| **Viento** | ![no soportado](x.png) | ![soportado](v.png) |
| **Prestigio** | ![no soportado](x.png) | ![soportado](v.png) |
| **Fractura** | ![no soportado](x.png) | ![soportado](v.png) |
| **Aplastar** | ![no soportado](x.png) | ![soportado](v.png) |
| **Despegar** | ![no soportado](x.png) | ![soportado](v.png) |
| **Curva de Página** | ![no soportado](x.png) | ![soportado](v.png) |
| **Avión** | ![no soportado](x.png) | ![soportado](v.png) |
| **Origami** | ![no soportado](x.png) | ![soportado](v.png) |
| **Disolver** | ![soportado](v.png) | ![soportado](v.png) |
| **Tablero de Ajedrez** | ![no soportado](x.png) | ![soportado](v.png) |
| **Persianas** | ![no soportado](x.png) | ![soportado](v.png) |
| **Reloj** | ![soportado](v.png) | ![soportado](v.png) |
| **Ripple** | ![no soportado](x.png) | ![soportado](v.png) |
| **Panal** | ![no soportado](x.png) | ![soportado](v.png) |
| **Brillo** | ![no soportado](x.png) | ![soportado](v.png) |
| **Vórtice** | ![no soportado](x.png) | ![soportado](v.png) |
| **Rasgar** | ![no soportado](x.png) | ![soportado](v.png) |
| **Cambiar** | ![no soportado](x.png) | ![soportado](v.png) |
| **Girar** | ![no soportado](x.png) | ![soportado](v.png) |
| **Galería** | ![no soportado](x.png) | ![soportado](v.png) |
| **Cubo** | ![no soportado](x.png) | ![soportado](v.png) |
| **Puertas** | ![no soportado](x.png) | ![soportado](v.png) |
| **Caja** | ![no soportado](x.png) | ![soportado](v.png) |
| **Peina** | ![no soportado](x.png) | ![soportado](v.png) |
| **Zoom** | ![soportado](v.png) | ![soportado](v.png) |
| **Aleatorio** | ![no soportado](x.png) | ![soportado](v.png) |

**Contenido Dinámico**:

| Tipo de Animación | Aspose.Slides | PowerPoint |
|---|---|---|
| **Paneo** | ![no soportado](x.png) | ![soportado](v.png) |
| **Noria** | ![soportado](v.png) | ![soportado](v.png) |
| **Cinta Transportadora** | ![no soportado](x.png) | ![soportado](v.png) |
| **Rotar** | ![no soportado](x.png) | ![soportado](v.png) |
| **Órbita** | ![no soportado](x.png) | ![soportado](v.png) |
| **Voladura** | ![soportado](v.png) | ![soportado](v.png) |