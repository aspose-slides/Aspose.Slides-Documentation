---
title: Convertir PowerPoint a Video
type: docs
weight: 130
url: /androidjava/convert-powerpoint-to-video/
keywords: "Convertir PowerPoint, PPT, PPTX, Presentación, Video, MP4, PPT a video, PPT a MP4, Java, Aspose.Slides"
description: "Convertir PowerPoint a Video en Java"
---

Al convertir tu presentación de PowerPoint a video, obtienes

* **Aumento en accesibilidad:** Todos los dispositivos (independientemente de la plataforma) están equipados por defecto con reproductores de video en comparación con aplicaciones para abrir presentaciones, por lo que los usuarios encuentran más fácil abrir o reproducir videos.
* **Mayor alcance:** A través de videos, puedes llegar a una gran audiencia y dirigirla con información que de otro modo podría parecer tediosa en una presentación. La mayoría de las encuestas y estadísticas sugieren que las personas ven y consumen videos más que otras formas de contenido, y generalmente prefieren dicho contenido.

{{% alert color="primary" %}} 

Puede que quieras consultar nuestro [**Convertidor de PowerPoint a Video Online**](https://products.aspose.app/slides/conversion/ppt-to-word) porque es una implementación en vivo y efectiva del proceso descrito aquí.

{{% /alert %}} 

## **Conversión de PowerPoint a Video en Aspose.Slides**

En [Aspose.Slides 22.11](https://docs.aspose.com/slides/androidjava/aspose-slides-for-java-22-11-release-notes/), implementamos soporte para la conversión de presentaciones a videos.

* Utiliza **Aspose.Slides** para generar un conjunto de fotogramas (de las diapositivas de la presentación) que correspondan a cierta FPS (fotogramas por segundo).
* Usa una utilidad de terceros como **ffmpeg** ([para java](https://github.com/bramp/ffmpeg-cli-wrapper)) para crear un video basado en los fotogramas.

### **Convertir PowerPoint a Video**

1. Agrega esto a tu archivo POM:
```xml
   <dependency>
     <groupId>net.bramp.ffmpeg</groupId>
     <artifactId>ffmpeg</artifactId>
     <version>0.7.0</version>
   </dependency>
```

2. Descarga ffmpeg [aquí](https://ffmpeg.org/download.html).

4. Ejecuta el código Java para convertir PowerPoint a video.

Este código Java te muestra cómo convertir una presentación (que contiene una figura y dos efectos de animación) a un video:

```java
Presentation presentation = new Presentation();
try {
    // Agrega una forma de sonrisa y luego la anima
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

    // Configura la carpeta de binarios de ffmpeg. Consulta esta página: https://github.com/rosenbjerg/FFMpegCore#installation
    FFmpeg ffmpeg = new FFmpeg("ruta/a/ffmpeg");
    FFprobe ffprobe = new FFprobe("ruta/a/ffprobe");

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

## **Efectos de Video**

Puedes aplicar animaciones a objetos en las diapositivas y usar transiciones entre diapositivas.

{{% alert color="primary" %}} 

Puede que quieras ver estos artículos: [Animación de PowerPoint](https://docs.aspose.com/slides/androidjava/powerpoint-animation/), [Animación de Forma](https://docs.aspose.com/slides/androidjava/shape-animation/), y [Efecto de Forma](https://docs.aspose.com/slides/androidjava/shape-effect/).

{{% /alert %}} 

Las animaciones y transiciones hacen que las presentaciones sean más atractivas e interesantes, y hacen lo mismo por los videos. Agreguemos otra diapositiva y una transición al código de la presentación anterior:

```java
// Agrega una forma de sonrisa y la anima

// ...

// Agrega una nueva diapositiva y una transición animada

ISlide newSlide = presentation.getSlides().addEmptySlide(presentation.getSlides().get_Item(0).getLayoutSlide());

newSlide.getBackground().setType(BackgroundType.OwnBackground);

newSlide.getBackground().getFillFormat().setFillType(FillType.Solid);

newSlide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.MAGENTA);

newSlide.getSlideShowTransition().setType(TransitionType.Push);
```

Aspose.Slides también admite animación para textos. Así que animamos los párrafos en objetos, que aparecerán uno tras otro (con el retraso establecido en un segundo):

```java
Presentation presentation = new Presentation();
try {
    // Agrega texto y animaciones
    IAutoShape autoShape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 210, 120, 300, 300);
    Paragraph para1 = new Paragraph();
    para1.getPortions().add(new Portion("Aspose Slides para Java"));
    Paragraph para2 = new Paragraph();
    para2.getPortions().add(new Portion("convertir presentación de PowerPoint con texto a video"));

    Paragraph para3 = new Paragraph();
    para3.getPortions().add(new Portion("párrafo por párrafo"));
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

    // Configura la carpeta de binarios de ffmpeg. Consulta esta página: https://github.com/rosenbjerg/FFMpegCore#installation
    FFmpeg ffmpeg = new FFmpeg("ruta/a/ffmpeg");
    FFprobe ffprobe = new FFprobe("ruta/a/ffprobe");

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

## **Clases de Conversión de Video**

Para permitirte realizar tareas de conversión de PowerPoint a video, Aspose.Slides proporciona las clases [PresentationAnimationsGenerator](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentationanimationsgenerator/) y [PresentationPlayer](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentationplayer/).

[PresentationAnimationsGenerator](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentationanimationsgenerator/) te permite establecer el tamaño de fotograma para el video (que se creará más adelante) a través de su constructor. Si pasas una instancia de la presentación, se utilizará `Presentation.SlideSize` y genera animaciones que utiliza [PresentationPlayer](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentationplayer/).

Cuando se generan animaciones, se genera un evento `NewAnimation` para cada animación subsiguiente, que tiene el parámetro [IPresentationAnimationPlayer](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipresentationanimationplayer/). Este último es una clase que representa un reproductor para una animación separada.

Para trabajar con [IPresentationAnimationPlayer](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipresentationanimationplayer/), se utilizan la propiedad [Duration](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipresentationanimationplayer/#getDuration--) (la duración total de la animación) y el método [SetTimePosition](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipresentationanimationplayer/#setTimePosition-double-). Cada posición de animación se establece dentro del rango *0 a duración*, y luego el método `GetFrame` devolverá un BufferedImage que corresponde al estado de la animación en ese momento:

```java
Presentation presentation = new Presentation();
try {
    // Agrega una forma de sonrisa y la anima
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
            System.out.println(String.format("Duración total de la animación: %f", animationPlayer.getDuration()));
            animationPlayer.setTimePosition(0); // estado inicial de la animación
            try {
                // bitmap del estado inicial de la animación
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

Para hacer que todas las animaciones en una presentación se reproduzcan a la vez, se utiliza la clase [PresentationPlayer](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentationplayer/). Esta clase toma una instancia de [PresentationAnimationsGenerator](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentationanimationsgenerator/) y FPS para efectos en su constructor y luego llama al evento `FrameTick` para todas las animaciones para que se reproduzcan:

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

Luego, los fotogramas generados se pueden compilar para producir un video. Consulta la sección [Convertir PowerPoint a Video](https://docs.aspose.com/slides/androidjava/convert-powerpoint-to-video/#convert-powerpoint-to-video).

## **Animaciones y Efectos Soportados**

**Entrada**:

| Tipo de Animación | Aspose.Slides | PowerPoint |
|---|---|---|
| **Aparecer** | ![no soportado](x.png) | ![soportado](v.png) |
| **Desvanecer** | ![soportado](v.png) | ![soportado](v.png) |
| **Entrar volando** | ![soportado](v.png) | ![soportado](v.png) |
| **Entrar flotando** | ![soportado](v.png) | ![soportado](v.png) |
| **Dividir** | ![soportado](v.png) | ![soportado](v.png) |
| **Limpiar** | ![soportado](v.png) | ![soportado](v.png) |
| **Forma** | ![soportado](v.png) | ![soportado](v.png) |
| **Rueda** | ![soportado](v.png) | ![soportado](v.png) |
| **Barras Aleatorias** | ![soportado](v.png) | ![soportado](v.png) |
| **Crecer y girar** | ![no soportado](x.png) | ![soportado](v.png) |
| **Acercar** | ![soportado](v.png) | ![soportado](v.png) |
| **Girar** | ![soportado](v.png) | ![soportado](v.png) |
| **Rebotar** | ![soportado](v.png) | ![soportado](v.png) |

**Énfasis**:

| Tipo de Animación | Aspose.Slides | PowerPoint |
|---|---|---|
| **Pulso** | ![no soportado](x.png) | ![soportado](v.png) |
| **Pulso de Color** | ![no soportado](x.png) | ![soportado](v.png) |
| **Balancearse** | ![soportado](v.png) | ![soportado](v.png) |
| **Girar** | ![soportado](v.png) | ![soportado](v.png) |
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
| **Salir volando** | ![soportado](v.png) | ![soportado](v.png) |
| **Salir flotando** | ![soportado](v.png) | ![soportado](v.png) |
| **Dividir** | ![soportado](v.png) | ![soportado](v.png) |
| **Limpiar** | ![soportado](v.png) | ![soportado](v.png) |
| **Forma** | ![soportado](v.png) | ![soportado](v.png) |
| **Barras Aleatorias** | ![soportado](v.png) | ![soportado](v.png) |
| **Encoger y girar** | ![no soportado](x.png) | ![soportado](v.png) |
| **Acercar** | ![soportado](v.png) | ![soportado](v.png) |
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