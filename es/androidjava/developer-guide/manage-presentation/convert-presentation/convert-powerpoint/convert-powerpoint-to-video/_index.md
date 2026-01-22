---
title: Convertir presentaciones de PowerPoint a video en Android
linktitle: PowerPoint a video
type: docs
weight: 130
url: /es/androidjava/convert-powerpoint-to-video/
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
- Android
- Java
- Aspose.Slides
description: "Aprenda a convertir presentaciones de PowerPoint a video en Java. Descubra código de ejemplo y técnicas de automatización para optimizar su flujo de trabajo."
---

Al convertir su presentación de PowerPoint a video, obtiene 

* **Aumento de accesibilidad:** Todos los dispositivos (independientemente de la plataforma) vienen equipados con reproductores de video por defecto, a diferencia de las aplicaciones de apertura de presentaciones, por lo que los usuarios encuentran más fácil abrir o reproducir videos.
* **Mayor alcance:** A través de videos, puede llegar a una gran audiencia y ofrecerles información que de otro modo podría resultar tediosa en una presentación. La mayoría de encuestas y estadísticas sugieren que la gente ve y consume videos más que otros formatos de contenido, y generalmente prefieren este tipo de contenido.

{{% alert color="primary" %}} 

Es posible que desee consultar nuestro [**Convertidor en línea de PowerPoint a video**](https://products.aspose.app/slides/conversion/ppt-to-word) porque es una implementación en vivo y eficaz del proceso descrito aquí.

{{% /alert %}} 

## **Conversión de PowerPoint a video en Aspose.Slides**

Aspose.Slides admite la conversión de presentaciones a video.

* Utilice **Aspose.Slides** para generar un conjunto de fotogramas (a partir de las diapositivas de la presentación) que correspondan a una determinada FPS (cuadros por segundo)
* Utilice una utilidad de terceros como **ffmpeg** ([for java](https://github.com/bramp/ffmpeg-cli-wrapper)) para crear un video a partir de los fotogramas. 

### **Convertir PowerPoint a video**

1. Añada esto a su archivo POM:
```xml
   <dependency>
     <groupId>net.bramp.ffmpeg</groupId>
     <artifactId>ffmpeg</artifactId>
     <version>0.7.0</version>
   </dependency>
```


2. Descargue ffmpeg [aquí](https://ffmpeg.org/download.html).

4. Ejecute el código Java de PowerPoint a video.

Este código Java le muestra cómo convertir una presentación (que contiene una figura y dos efectos de animación) a un video:
```java
Presentation presentation = new Presentation();
try {
    // Añade una forma de sonrisa y luego la anima
    IAutoShape smile = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.SmileyFace, 110, 20, 500, 500);
    ISequence mainSequence = presentation.getSlides().get_Item(0).getTimeline().getMainSequence();
    IEffect effectIn = mainSequence.addEffect(smile, EffectType.Fly, EffectSubtype.TopLeft, EffectTriggerType.AfterPrevious);
    IEffect effectOut = mainSequence.addEffect(smile, EffectType.Fly, EffectSubtype.BottomRight, EffectTriggerType.AfterPrevious);
    effectIn.getTiming().setDuration(2f);
    effectOut.setPresetClassType(EffectPresetClassType.Exit);

    final int fps = 33;
    ArrayList<String> frames = new ArrayList<String>();

    PresentationAnimationsGenerator animationsGenerator = new PresentationAnimationsGenerator(presentation);
    try
    {
        PresentationPlayer player = new PresentationPlayer(animationsGenerator, fps);
        try {
            player.setFrameTick((sender, arguments) ->
            {
                try {
                    String frame = String.format("frame_%04d.png", sender.getFrameIndex());
                    arguments.getFrame().save(frame, ImageFormat.Png);
                    frames.add(frame);
                } catch (IOException e) {
                    throw new RuntimeException(e);
                }
            });
            animationsGenerator.run(presentation.getSlides());
        } finally {
            if (player != null) player.dispose();
        }
    } finally {
        if (animationsGenerator != null) animationsGenerator.dispose();
    }

    // Configura la carpeta de binarios de ffmpeg. Ver esta página: https://github.com/rosenbjerg/FFMpegCore#installation
    FFmpeg ffmpeg = new FFmpeg("path/to/ffmpeg");
    FFprobe ffprobe = new FFprobe("path/to/ffprobe");

    FFmpegBuilder builder = new FFmpegBuilder()
            .addExtraArgs("-start_number", "1")
            .setInput("frame_%04d.png")
            .addOutput("output.avi")
            .setVideoFrameRate(FFmpeg.FPS_24)
            .setFormat("avi")
            .done();

    FFmpegExecutor executor = new FFmpegExecutor(ffmpeg, ffprobe);
    executor.createJob(builder).run();
} catch (IOException e) {
    e.printStackTrace();
}
```


## **Efectos de video**

Puede aplicar animaciones a objetos en las diapositivas y usar transiciones entre ellas. 

{{% alert color="primary" %}} 

Es posible que desee ver estos artículos: [Animación de PowerPoint](https://docs.aspose.com/slides/androidjava/powerpoint-animation/), [Animación de forma](https://docs.aspose.com/slides/androidjava/shape-animation/), y [Efecto de forma](https://docs.aspose.com/slides/androidjava/shape-effect/).

{{% /alert %}} 

Las animaciones y transiciones hacen que las presentaciones sean más atractivas e interesantes, y lo mismo ocurre con los videos. Añadamos otra diapositiva y transición al código de la presentación anterior:
```java
// Añade una forma de sonrisa y la anima

// ...

// Añade una nueva diapositiva y transición animada

ISlide newSlide = presentation.getSlides().addEmptySlide(presentation.getSlides().get_Item(0).getLayoutSlide());

newSlide.getBackground().setType(BackgroundType.OwnBackground);

newSlide.getBackground().getFillFormat().setFillType(FillType.Solid);

newSlide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.MAGENTA);

newSlide.getSlideShowTransition().setType(TransitionType.Push);
```


Aspose.Slides también admite animación de textos. Así que animamos párrafos en objetos, que aparecerán uno tras otro (con el retraso configurado a un segundo):
```java
Presentation presentation = new Presentation();
try {
    // Añade texto y animaciones
    IAutoShape autoShape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 210, 120, 300, 300);
    Paragraph para1 = new Paragraph();
    para1.getPortions().add(new Portion("Aspose Slides for Java"));
    Paragraph para2 = new Paragraph();
    para2.getPortions().add(new Portion("convert PowerPoint Presentation with text to video"));

    Paragraph para3 = new Paragraph();
    para3.getPortions().add(new Portion("paragraph by paragraph"));
    IParagraphCollection paragraphCollection = autoShape.getTextFrame().getParagraphs();
    paragraphCollection.add(para1);
    paragraphCollection.add(para2);
    paragraphCollection.add(para3);
    paragraphCollection.add(new Paragraph());

    ISequence mainSequence = presentation.getSlides().get_Item(0).getTimeline().getMainSequence();
    IEffect effect1 = mainSequence.addEffect(para1, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    IEffect effect2 = mainSequence.addEffect(para2, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    IEffect effect3 = mainSequence.addEffect(para3, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    IEffect effect4 = mainSequence.addEffect(para3, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    effect1.getTiming().setTriggerDelayTime(1f);
    effect2.getTiming().setTriggerDelayTime(1f);
    effect3.getTiming().setTriggerDelayTime(1f);
    effect4.getTiming().setTriggerDelayTime(1f);

    final int fps = 33;
    ArrayList<String> frames = new ArrayList<String>();

    PresentationAnimationsGenerator animationsGenerator = new PresentationAnimationsGenerator(presentation);
    try
    {
        PresentationPlayer player = new PresentationPlayer(animationsGenerator, fps);
        try {
            player.setFrameTick((sender, arguments) ->
            {
                try {
                    String frame = String.format("frame_%04d.png", sender.getFrameIndex());
                    arguments.getFrame().save(frame, ImageFormat.Png);
                    frames.add(frame);
                } catch (IOException e) {
                    throw new RuntimeException(e);
                }
            });
            animationsGenerator.run(presentation.getSlides());
        } finally {
            if (player != null) player.dispose();
        }
    } finally {
        if (animationsGenerator != null) animationsGenerator.dispose();
    }

    // Configura la carpeta de binarios de ffmpeg. Ver esta página: https://github.com/rosenbjerg/FFMpegCore#installation
    FFmpeg ffmpeg = new FFmpeg("path/to/ffmpeg");
    FFprobe ffprobe = new FFprobe("path/to/ffprobe");

    FFmpegBuilder builder = new FFmpegBuilder()
            .addExtraArgs("-start_number", "1")
            .setInput("frame_%04d.png")
            .addOutput("output.avi")
            .setVideoFrameRate(FFmpeg.FPS_24)
            .setFormat("avi")
            .done();

    FFmpegExecutor executor = new FFmpegExecutor(ffmpeg, ffprobe);
    executor.createJob(builder).run();
} catch (IOException e) {
    e.printStackTrace();
}
```


## **Clases de conversión de video**

Para permitirle realizar tareas de conversión de PowerPoint a video, Aspose.Slides proporciona las clases [PresentationAnimationsGenerator](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentationanimationsgenerator/) y [PresentationPlayer](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentationplayer/).

[PresentationAnimationsGenerator](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentationanimationsgenerator/) le permite establecer el tamaño del fotograma para el video (que se creará más adelante) a través de su constructor. Si pasa una instancia de la presentación, se utilizará `Presentation.SlideSize` y generará animaciones que [PresentationPlayer](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentationplayer/) utiliza.

Cuando se generan las animaciones, se genera un evento `NewAnimation` para cada animación sucesiva, que tiene el parámetro [IPresentationAnimationPlayer](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipresentationanimationplayer/). Este último es una clase que representa un reproductor para una animación independiente.

Para trabajar con [IPresentationAnimationPlayer](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipresentationanimationplayer/), se utilizan la propiedad [Duration](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipresentationanimationplayer/#getDuration--) (la duración total de la animación) y el método [SetTimePosition](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipresentationanimationplayer/#setTimePosition-double-). Cada posición de animación se establece dentro del rango *0 a duración*, y luego el método `GetFrame` devolverá un BufferedImage que corresponde al estado de la animación en ese momento:
```java
Presentation presentation = new Presentation();
try {
    // Añade una forma de sonrisa y la anima
    IAutoShape smile = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.SmileyFace, 110, 20, 500, 500);
    ISequence mainSequence = presentation.getSlides().get_Item(0).getTimeline().getMainSequence();
    IEffect effectIn = mainSequence.addEffect(smile, EffectType.Fly, EffectSubtype.TopLeft, EffectTriggerType.AfterPrevious);
    IEffect effectOut = mainSequence.addEffect(smile, EffectType.Fly, EffectSubtype.BottomRight, EffectTriggerType.AfterPrevious);
    effectIn.getTiming().setDuration(2f);
    effectOut.setPresetClassType(EffectPresetClassType.Exit);

    PresentationAnimationsGenerator animationsGenerator = new PresentationAnimationsGenerator(presentation);
    try {
        animationsGenerator.setNewAnimation(animationPlayer ->
        {
            System.out.println(String.format("Animation total duration: %f", animationPlayer.getDuration()));
            animationPlayer.setTimePosition(0); // estado inicial de la animación
            try {
                // mapa de bits del estado inicial de la animación
                animationPlayer.getFrame().save("firstFrame.png", ImageFormat.Png);
            } catch (IOException e) {
                throw new RuntimeException(e);
            }
            animationPlayer.setTimePosition(animationPlayer.getDuration()); // estado final de la animación
            try {
                // último fotograma de la animación
                animationPlayer.getFrame().save("lastFrame.png", ImageFormat.Png);
            } catch (IOException e) {
                throw new RuntimeException(e);
            }
        });
    } finally {
        if (animationsGenerator != null) animationsGenerator.dispose();
    }
} finally {
    if (presentation != null) presentation.dispose();
}
```


Para que todas las animaciones de una presentación se reproduzcan simultáneamente, se utiliza la clase [PresentationPlayer](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentationplayer/). Esta clase toma una instancia de [PresentationAnimationsGenerator](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentationanimationsgenerator/) y FPS para los efectos en su constructor y luego llama al evento `FrameTick` para todas las animaciones y así reproducirlas:
```java
Presentation presentation = new Presentation("animated.pptx");
try {
    PresentationAnimationsGenerator animationsGenerator = new PresentationAnimationsGenerator(presentation);
    try {
        PresentationPlayer player = new PresentationPlayer(animationsGenerator, 33);
        try {
            player.setFrameTick((sender, arguments) ->
            {
                try {
                    arguments.getFrame().save("frame_" + sender.getFrameIndex() + ".png", ImageFormat.Png);
                } catch (IOException e) {
                    throw new RuntimeException(e);
                }
            });
            animationsGenerator.run(presentation.getSlides());
        } finally {
            if (player != null) player.dispose();
        }
    } finally {
        if (animationsGenerator != null) animationsGenerator.dispose();
    }
} finally {
    if (presentation != null) presentation.dispose();
}
```


Luego los fotogramas generados pueden compilarse para producir un video. Consulte la sección [Convertir PowerPoint a video](https://docs.aspose.com/slides/androidjava/convert-powerpoint-to-video/#convert-powerpoint-to-video).

## **Animaciones y efectos compatibles**

**Entrada**:

| Tipo de animación | Aspose.Slides | PowerPoint |
|---|---|---|
| **Appear** | ![no compatible](x.png) | ![compatible](v.png) |
| **Fade** | ![compatible](v.png) | ![compatible](v.png) |
| **Fly In** | ![compatible](v.png) | ![compatible](v.png) |
| **Float In** | ![compatible](v.png) | ![compatible](v.png) |
| **Split** | ![compatible](v.png) | ![compatible](v.png) |
| **Wipe** | ![compatible](v.png) | ![compatible](v.png) |
| **Shape** | ![compatible](v.png) | ![compatible](v.png) |
| **Wheel** | ![compatible](v.png) | ![compatible](v.png) |
| **Random Bars** | ![compatible](v.png) | ![compatible](v.png) |
| **Grow & Turn** | ![no compatible](x.png) | ![compatible](v.png) |
| **Zoom** | ![compatible](v.png) | ![compatible](v.png) |
| **Swivel** | ![compatible](v.png) | ![compatible](v.png) |
| **Bounce** | ![compatible](v.png) | ![compatible](v.png) |

**Énfasis**:

| Tipo de animación | Aspose.Slides | PowerPoint |
|---|---|---|
| **Pulse** | ![no compatible](x.png) | ![compatible](v.png) |
| **Color Pulse** | ![no compatible](x.png) | ![compatible](v.png) |
| **Teeter** | ![compatible](v.png) | ![compatible](v.png) |
| **Spin** | ![compatible](v.png) | ![compatible](v.png) |
| **Grow/Shrink** | ![no compatible](x.png) | ![compatible](v.png) |
| **Desaturate** | ![no compatible](x.png) | ![compatible](v.png) |
| **Darken** | ![no compatible](x.png) | ![compatible](v.png) |
| **Lighten** | ![no compatible](x.png) | ![compatible](v.png) |
| **Transparency** | ![no compatible](x.png) | ![compatible](v.png) |
| **Object Color** | ![no compatible](x.png) | ![compatible](v.png) |
| **Complementary Color** | ![no compatible](x.png) | ![compatible](v.png) |
| **Line Color** | ![no compatible](x.png) | ![compatible](v.png) |
| **Fill Color** | ![no compatible](x.png) | ![compatible](v.png) |

**Salida**:

| Tipo de animación | Aspose.Slides | PowerPoint |
|---|---|---|
| **Disappear** | ![no compatible](x.png) | ![compatible](v.png) |
| **Fade** | ![compatible](v.png) | ![compatible](v.png) |
| **Fly Out** | ![compatible](v.png) | ![compatible](v.png) |
| **Float Out** | ![compatible](v.png) | ![compatible](v.png) |
| **Split** | ![compatible](v.png) | ![compatible](v.png) |
| **Wipe** | ![compatible](v.png) | ![compatible](v.png) |
| **Shape** | ![compatible](v.png) | ![compatible](v.png) |
| **Random Bars** | ![compatible](v.png) | ![compatible](v.png) |
| **Shrink & Turn** | ![no compatible](x.png) | ![compatible](v.png) |
| **Zoom** | ![compatible](v.png) | ![compatible](v.png) |
| **Swivel** | ![compatible](v.png) | ![compatible](v.png) |
| **Bounce** | ![compatible](v.png) | ![compatible](v.png) |

**Rutas de movimiento**:

| Tipo de animación | Aspose.Slides | PowerPoint |
|---|---|---|
| **Lines** | ![compatible](v.png) | ![compatible](v.png) |
| **Arcs** | ![compatible](v.png) | ![compatible](v.png) |
| **Turns** | ![compatible](v.png) | ![compatible](v.png) |
| **Shapes** | ![compatible](v.png) | ![compatible](v.png) |
| **Loops** | ![compatible](v.png) | ![compatible](v.png) |
| **Custom Path** | ![compatible](v.png) | ![compatible](v.png) |

## **Preguntas frecuentes**

**¿Es posible convertir presentaciones protegidas con contraseña?**

Sí, Aspose.Slides permite trabajar con [presentaciones protegidas con contraseña](/slides/es/androidjava/password-protected-presentation/). Al procesar dichos archivos, debe proporcionar la contraseña correcta para que la biblioteca pueda acceder al contenido de la presentación.

**¿Aspose.Slides admite su uso en soluciones en la nube?**

Sí, Aspose.Slides puede integrarse en aplicaciones y servicios en la nube. La biblioteca está diseñada para funcionar en entornos de servidor, garantizando alto rendimiento y escalabilidad para el procesamiento por lotes de archivos.

**¿Existen limitaciones de tamaño para las presentaciones durante la conversión?**

Aspose.Slides es capaz de manejar presentaciones de prácticamente cualquier tamaño. Sin embargo, al trabajar con archivos muy grandes, pueden requerirse recursos del sistema adicionales, y a veces se recomienda optimizar la presentación para mejorar el rendimiento.