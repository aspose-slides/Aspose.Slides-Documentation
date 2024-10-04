---
title: Convertir PowerPoint a Video
type: docs
weight: 130
url: /java/convert-powerpoint-to-video/
keywords: "Convertir PowerPoint, PPT, PPTX, Presentación, Video, MP4, PPT a video, PPT a MP4, Java, Aspose.Slides"
description: "Convertir PowerPoint a Video en Java"
---

Al convertir tu presentación de PowerPoint a video, obtienes 

* **Aumento en la accesibilidad:** Todos los dispositivos (independientemente de la plataforma) vienen equipados por defecto con reproductores de video en comparación con aplicaciones para abrir presentaciones, por lo que a los usuarios les resulta más fácil abrir o reproducir videos.
* **Mayor alcance:** A través de videos, puedes alcanzar una gran audiencia y dirigirles información que de otro modo podría parecer tediosa en una presentación. La mayoría de las encuestas y estadísticas sugieren que las personas miran y consumen videos más que otras formas de contenido, y generalmente prefieren dicho contenido.

{{% alert color="primary" %}} 

Quizás desees comprobar nuestro [**Convertidor de PowerPoint a Video en Línea**](https://products.aspose.app/slides/conversion/ppt-to-word) porque es una implementación en vivo y efectiva del proceso descrito aquí.

{{% /alert %}} 

## **Conversión de PowerPoint a Video en Aspose.Slides**

En [Aspose.Slides 22.11](https://docs.aspose.com/slides/java/aspose-slides-for-java-22-11-release-notes/), implementamos soporte para la conversión de presentaciones a video. 

* Usa **Aspose.Slides** para generar un conjunto de fotogramas (de las diapositivas de la presentación) que correspondan a cierta FPS (fotogramas por segundo)
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

4. Ejecuta el código Java de PowerPoint a video.

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

    // Configura la carpeta de ejecutables de ffmpeg. Consulta esta página: https://github.com/rosenbjerg/FFMpegCore#installation
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

## **Efectos de Video**

Puedes aplicar animaciones a objetos en las diapositivas y usar transiciones entre diapositivas. 

{{% alert color="primary" %}} 

Quizás desees ver estos artículos: [Animación de PowerPoint](https://docs.aspose.com/slides/java/powerpoint-animation/), [Animación de Formas](https://docs.aspose.com/slides/java/shape-animation/), y [Efecto de Forma](https://docs.aspose.com/slides/java/shape-effect/).

{{% /alert %}} 

Las animaciones y transiciones hacen que las presentaciones sean más atractivas e interesantes, y lo mismo ocurre con los videos. Vamos a agregar otra diapositiva y una transición al código de la presentación anterior:

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

Aspose.Slides también admite animación para textos. Así que animamos párrafos en objetos, que aparecerán uno tras otro (con un retraso establecido en un segundo):

```java
Presentation presentation = new Presentation();
try {
    // Agrega texto y animaciones
    IAutoShape autoShape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 210, 120, 300, 300);
    Paragraph para1 = new Paragraph();
    para1.getPortions().add(new Portion("Aspose Slides para Java"));
    Paragraph para2 = new Paragraph();
    para2.getPortions().add(new Portion("convertir Presentación de PowerPoint con texto a video"));

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

    // Configura la carpeta de ejecutables de ffmpeg. Consulta esta página: https://github.com/rosenbjerg/FFMpegCore#installation
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

## **Clases de Conversión de Video**

Para permitirte realizar tareas de conversión de PowerPoint a video, Aspose.Slides proporciona las clases [PresentationAnimationsGenerator](https://reference.aspose.com/slides/java/com.aspose.slides/presentationanimationsgenerator/) y [PresentationPlayer](https://reference.aspose.com/slides/java/com.aspose.slides/presentationplayer/).

[PresentationAnimationsGenerator](https://reference.aspose.com/slides/java/com.aspose.slides/presentationanimationsgenerator/) te permite establecer el tamaño del fotograma para el video (que se creará más tarde) a través de su constructor. Si pasas una instancia de la presentación, se utilizará `Presentation.SlideSize` y genera animaciones que usa [PresentationPlayer](https://reference.aspose.com/slides/java/com.aspose.slides/presentationplayer/). 

Cuando se generan animaciones, se genera un evento `NewAnimation` para cada animación subsiguiente, que tiene el parámetro [IPresentationAnimationPlayer](https://reference.aspose.com/slides/java/com.aspose.slides/ipresentationanimationplayer/). Este último es una clase que representa un reproductor para una animación separada.

Para trabajar con [IPresentationAnimationPlayer](https://reference.aspose.com/slides/java/com.aspose.slides/ipresentationanimationplayer/), se utilizan la propiedad [Duration](https://reference.aspose.com/slides/java/com.aspose.slides/ipresentationanimationplayer/#getDuration--) (la duración total de la animación) y el método [SetTimePosition](https://reference.aspose.com/slides/java/com.aspose.slides/ipresentationanimationplayer/#setTimePosition-double-). Cada posición de animación se establece dentro del rango *0 a duración*, y luego el método `GetFrame` devolverá un BufferedImage que corresponde al estado de la animación en ese momento:

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
                // estado inicial de la animación bitmap
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

Para hacer que todas las animaciones en una presentación se reproduzcan a la vez, se utiliza la clase [PresentationPlayer](https://reference.aspose.com/slides/java/com.aspose.slides/presentationplayer/). Esta clase toma una instancia de [PresentationAnimationsGenerator](https://reference.aspose.com/slides/java/com.aspose.slides/presentationanimationsgenerator/) y FPS para efectos en su constructor y luego llama al evento `FrameTick` para que todas las animaciones se reproduzcan:

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

Luego, los fotogramas generados se pueden compilar para producir un video. Consulta la sección [Convertir PowerPoint a Video](https://docs.aspose.com/slides/java/convert-powerpoint-to-video/#convert-powerpoint-to-video).

## **Animaciones y Efectos Admitidos**

**Entrada**:

| Tipo de Animación | Aspose.Slides | PowerPoint |
|---|---|---|
| **Aparecer** | ![no admitido](x.png) | ![admitido](v.png) |
| **Desvanecerse** | ![admitido](v.png) | ![admitido](v.png) |
| **Volar Dentro** | ![admitido](v.png) | ![admitido](v.png) |
| **Flotar Dentro** | ![admitido](v.png) | ![admitido](v.png) |
| **Dividir** | ![admitido](v.png) | ![admitido](v.png) |
| **Barrer** | ![admitido](v.png) | ![admitido](v.png) |
| **Forma** | ![admitido](v.png) | ![admitido](v.png) |
| **Rueda** | ![admitido](v.png) | ![admitido](v.png) |
| **Barras Aleatorias** | ![admitido](v.png) | ![admitido](v.png) |
| **Crecer y Girar** | ![no admitido](x.png) | ![admitido](v.png) |
| **Acercar** | ![admitido](v.png) | ![admitido](v.png) |
| **Girar** | ![admitido](v.png) | ![admitido](v.png) |
| **Rebotar** | ![admitido](v.png) | ![admitido](v.png) |

**Énfasis**:

| Tipo de Animación | Aspose.Slides | PowerPoint |
|---|---|---|
| **Pulsar** | ![no admitido](x.png) | ![admitido](v.png) |
| **Pulsar Colorido** | ![no admitido](x.png) | ![admitido](v.png) |
| **Tobogán** | ![admitido](v.png) | ![admitido](v.png) |
| **Girar** | ![admitido](v.png) | ![admitido](v.png) |
| **Crecer/Encogerse** | ![no admitido](x.png) | ![admitido](v.png) |
| **Desaturar** | ![no admitido](x.png) | ![admitido](v.png) |
| **Oscurecer** | ![no admitido](x.png) | ![admitido](v.png) |
| **Aclarar** | ![no admitido](x.png) | ![admitido](v.png) |
| **Transparencia** | ![no admitido](x.png) | ![admitido](v.png) |
| **Color de Objeto** | ![no admitido](x.png) | ![admitido](v.png) |
| **Color Complementario** | ![no admitido](x.png) | ![admitido](v.png) |
| **Color de Línea** | ![no admitido](x.png) | ![admitido](v.png) |
| **Color de Relleno** | ![no admitido](x.png) | ![admitido](v.png) |

**Salida**:

| Tipo de Animación | Aspose.Slides | PowerPoint |
|---|---|---|
| **Desaparecer** | ![no admitido](x.png) | ![admitido](v.png) |
| **Desvanecerse** | ![admitido](v.png) | ![admitido](v.png) |
| **Volar Fuera** | ![admitido](v.png) | ![admitido](v.png) |
| **Flotar Fuera** | ![admitido](v.png) | ![admitido](v.png) |
| **Dividir** | ![admitido](v.png) | ![admitido](v.png) |
| **Barrer** | ![admitido](v.png) | ![admitido](v.png) |
| **Forma** | ![admitido](v.png) | ![admitido](v.png) |
| **Barras Aleatorias** | ![admitido](v.png) | ![admitido](v.png) |
| **Encogerse y Girar** | ![no admitido](x.png) | ![admitido](v.png) |
| **Acercar** | ![admitido](v.png) | ![admitido](v.png) |
| **Girar** | ![admitido](v.png) | ![admitido](v.png) |
| **Rebotar** | ![admitido](v.png) | ![admitido](v.png) |

**Rutas de Movimiento:**

| Tipo de Animación | Aspose.Slides | PowerPoint |
|---|---|---|
| **Líneas** | ![admitido](v.png) | ![admitido](v.png) |
| **Arcos** | ![admitido](v.png) | ![admitido](v.png) |
| **Giros** | ![admitido](v.png) | ![admitido](v.png) |
| **Formas** | ![admitido](v.png) | ![admitido](v.png) |
| **Bucles** | ![admitido](v.png) | ![admitido](v.png) |
| **Ruta Personalizada** | ![admitido](v.png) | ![admitido](v.png) |