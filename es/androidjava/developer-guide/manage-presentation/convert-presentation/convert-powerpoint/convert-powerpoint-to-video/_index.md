---
title: Convertir presentaciones de PowerPoint a vídeo en Android
linktitle: PowerPoint a vídeo
type: docs
weight: 130
url: /es/androidjava/convert-powerpoint-to-video/
keywords:
- convertir PowerPoint
- convertir presentación
- convertir PPT
- convertir PPTX
- PowerPoint a vídeo
- presentación a vídeo
- PPT a vídeo
- PPTX a vídeo
- PowerPoint a MP4
- presentación a MP4
- PPT a MP4
- PPTX a MP4
- guardar PPT como MP4
- guardar PPTX como MP4
- exportar PPT a MP4
- exportar PPTX a MP4
- conversión de vídeo
- PowerPoint
- Android
- Java
- Aspose.Slides
description: "Aprenda cómo convertir presentaciones de PowerPoint a vídeo en Java. Descubra código de ejemplo y técnicas de automatización para optimizar su flujo de trabajo."
---
## **Introducción**

Al convertir su presentación de PowerPoint a vídeo, obtiene 

* **Aumento de la accesibilidad:** Todos los dispositivos (independientemente de la plataforma) vienen equipados con reproductores de vídeo por defecto en comparación con las aplicaciones de apertura de presentaciones, por lo que los usuarios encuentran más fácil abrir o reproducir vídeos.
* **Mayor alcance:** A través de los vídeos, puede llegar a una gran audiencia y dirigirse a ella con información que de otro modo podría parecer tediosa en una presentación. La mayoría de encuestas y estadísticas indican que la gente ve y consume vídeos más que otros tipos de contenido, y generalmente prefieren ese tipo de contenido.

## **Conversión de PowerPoint a vídeo en Aspose.Slides**

Aspose.Slides admite la conversión de presentaciones a vídeo.

* Utilice **Aspose.Slides** para generar un conjunto de fotogramas (a partir de las diapositivas de la presentación) que correspondan a un determinado FPS (fotogramas por segundo)
* Utilice una utilidad de terceros como **ffmpeg** ([para Java](https://github.com/bramp/ffmpeg-cli-wrapper)) para crear un vídeo a partir de los fotogramas. 

### **Convertir PowerPoint a vídeo**

1. Añada esto a su archivo POM:
```xml
   <dependency>
     <groupId>net.bramp.ffmpeg</groupId>
     <artifactId>ffmpeg</artifactId>
     <version>0.7.0</version>
   </dependency>
```

2. Descargue ffmpeg [aquí](https://ffmpeg.org/download.html).

3. Ejecute el código Java que convierte PowerPoint a vídeo.

Este código Java le muestra cómo convertir una presentación (que contiene una figura y dos efectos de animación) a un vídeo:

```java
import com.aspose.slides.*;
import java.io.IOException;
import java.util.ArrayList;

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

    // Configura la carpeta de binarios de ffmpeg. Ver esta página: https://github.com/bramp/ffmpeg-cli-wrapper
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

## **Efectos de vídeo**

Puede aplicar animaciones a objetos en las diapositivas y usar transiciones entre diapositivas. 

{{% alert color="info" %}} 

Puede que le interese ver estos artículos: [Animación de PowerPoint](https://docs.aspose.com/slides/es/androidjava/powerpoint-animation/), [Animación de forma](https://docs.aspose.com/slides/es/androidjava/shape-animation/), y [Efecto de forma](https://docs.aspose.com/slides/es/androidjava/shape-effect/).

{{% /alert %}} 

Las animaciones y transiciones hacen que las presentaciones sean más atractivas e interesantes —y ocurre lo mismo con los vídeos. Añadamos otra diapositiva y transición al código de la presentación anterior:

```java
import com.aspose.slides.*;
import java.awt.Color;

// La presentación con la forma de sonrisa animada creada arriba.
Presentation presentation = new Presentation();
try {
    // Añade una nueva diapositiva y una transición animada

    ISlide newSlide = presentation.getSlides().addEmptySlide(presentation.getSlides().get_Item(0).getLayoutSlide());

    newSlide.getBackground().setType(BackgroundType.OwnBackground);

    newSlide.getBackground().getFillFormat().setFillType(FillType.Solid);

    newSlide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.MAGENTA);

    newSlide.getSlideShowTransition().setType(TransitionType.Push);
} finally {
    if (presentation != null) presentation.dispose();
}
```

Aspose.Slides también admite animación para textos. Así animamos párrafos en objetos, que aparecerán uno tras otro (con un retraso de un segundo):

```java
import com.aspose.slides.*;
import java.io.IOException;
import java.util.ArrayList;

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

    ISequence mainSequence = presentation.getSlides().get_Item(0).getTimeline().getMainSequence();
    IEffect effect1 = mainSequence.addEffect(para1, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    IEffect effect2 = mainSequence.addEffect(para2, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    IEffect effect3 = mainSequence.addEffect(para3, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    effect1.getTiming().setTriggerDelayTime(1f);
    effect2.getTiming().setTriggerDelayTime(1f);
    effect3.getTiming().setTriggerDelayTime(1f);

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

    // Configura la carpeta de binarios de ffmpeg. Ver esta página: https://github.com/bramp/ffmpeg-cli-wrapper
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

## **Clases de conversión de vídeo**

Para permitirle realizar tareas de conversión de PowerPoint a vídeo, Aspose.Slides proporciona las clases [PresentationAnimationsGenerator](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/presentationanimationsgenerator/) y [PresentationPlayer](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/presentationplayer/).

[PresentationAnimationsGenerator](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/presentationanimationsgenerator/) le permite establecer el tamaño del fotograma para el vídeo (que se creará más adelante) a través de su constructor. Si pasa una instancia de la presentación, `Presentation.SlideSize` se utilizará y genera animaciones que [PresentationPlayer](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/presentationplayer/) utiliza.

Cuando se generan animaciones, se crea un evento `NewAnimation` para cada animación subsiguiente, que tiene como parámetro [IPresentationAnimationPlayer](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/ipresentationanimationplayer/). Este último es una clase que representa un reproductor para una animación independiente.

Para trabajar con [IPresentationAnimationPlayer](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/ipresentationanimationplayer/), se utilizan la propiedad [Duration](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/ipresentationanimationplayer/#getDuration--) (la duración total de la animación) y el método [SetTimePosition](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/ipresentationanimationplayer/#setTimePosition-double-). Cada posición de animación se establece dentro del rango *0 a duración*, y entonces el método `getFrame` devolverá un [IImage](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/iimage/) que corresponde al estado de la animación en ese momento:

```java
import com.aspose.slides.*;

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
            // mapa de bits del estado inicial de la animación
            animationPlayer.getFrame().save("firstFrame.png", ImageFormat.Png);

            animationPlayer.setTimePosition(animationPlayer.getDuration()); // estado final de la animación
            // último fotograma de la animación
            animationPlayer.getFrame().save("lastFrame.png", ImageFormat.Png);
        });

        // Genera las animaciones. La devolución de llamada anterior se ejecuta para cada una de ellas.
        animationsGenerator.run(presentation.getSlides());
    } finally {
        if (animationsGenerator != null) animationsGenerator.dispose();
    }
} finally {
    if (presentation != null) presentation.dispose();
}
```

Para que todas las animaciones de una presentación se reproduzcan a la vez, se utiliza la clase [PresentationPlayer](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/presentationplayer/). Esta clase toma una instancia de [PresentationAnimationsGenerator](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/presentationanimationsgenerator/) y FPS para los efectos en su constructor y luego llama al evento `FrameTick` para todas las animaciones y las reproduce:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("animated.pptx");
try {
    PresentationAnimationsGenerator animationsGenerator = new PresentationAnimationsGenerator(presentation);
    try {
        PresentationPlayer player = new PresentationPlayer(animationsGenerator, 33);
        try {
            player.setFrameTick((sender, arguments) ->
            {
                arguments.getFrame().save("frame_" + sender.getFrameIndex() + ".png", ImageFormat.Png);
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

Luego los fotogramas generados pueden compilarse para producir un vídeo. Consulte la sección [Convert PowerPoint to Video](https://docs.aspose.com/slides/es/androidjava/convert-powerpoint-to-video/#convert-powerpoint-to-video).

## **Animaciones y efectos compatibles**

**Entrada**:

| Tipo de animación | Aspose.Slides | PowerPoint |
|---|---|---|
| **Aparecer** | ![not supported](x.png) | ![supported](v.png) |
| **Desvanecer** | ![supported](v.png) | ![supported](v.png) |
| **Volar dentro** | ![supported](v.png) | ![supported](v.png) |
| **Flotar dentro** | ![supported](v.png) | ![supported](v.png) |
| **Dividir** | ![supported](v.png) | ![supported](v.png) |
| **Borrar** | ![supported](v.png) | ![supported](v.png) |
| **Forma** | ![supported](v.png) | ![supported](v.png) |
| **Rueda** | ![supported](v.png) | ![supported](v.png) |
| **Barras aleatorias** | ![supported](v.png) | ![supported](v.png) |
| **Crecer y girar** | ![not supported](x.png) | ![supported](v.png) |
| **Zoom** | ![supported](v.png) | ![supported](v.png) |
| **Girar** | ![supported](v.png) | ![supported](v.png) |
| **Rebotar** | ![supported](v.png) | ![supported](v.png) |

**Énfasis**:

| Tipo de animación | Aspose.Slides | PowerPoint |
|---|---|---|
| **Pulso** | ![not supported](x.png) | ![supported](v.png) |
| **Pulso de color** | ![not supported](x.png) | ![supported](v.png) |
| **Tambaleo** | ![supported](v.png) | ![supported](v.png) |
| **Giro** | ![supported](v.png) | ![supported](v.png) |
| **Crecer/encoger** | ![not supported](x.png) | ![supported](v.png) |
| **Desaturar** | ![not supported](x.png) | ![supported](v.png) |
| **Oscurecer** | ![not supported](x.png) | ![supported](v.png) |
| **Aclarar** | ![not supported](x.png) | ![supported](v.png) |
| **Transparencia** | ![not supported](x.png) | ![supported](v.png) |
| **Color del objeto** | ![not supported](x.png) | ![supported](v.png) |
| **Color complementario** | ![not supported](x.png) | ![supported](v.png) |
| **Color de línea** | ![not supported](x.png) | ![supported](v.png) |
| **Color de relleno** | ![not supported](x.png) | ![supported](v.png) |

**Salida**:

| Tipo de animación | Aspose.Slides | PowerPoint |
|---|---|---|
| **Desaparecer** | ![not supported](x.png) | ![supported](v.png) |
| **Desvanecer** | ![supported](v.png) | ![supported](v.png) |
| **Volar fuera** | ![supported](v.png) | ![supported](v.png) |
| **Flotar fuera** | ![supported](v.png) | ![supported](v.png) |
| **Dividir** | ![supported](v.png) | ![supported](v.png) |
| **Borrar** | ![supported](v.png) | ![supported](v.png) |
| **Forma** | ![supported](v.png) | ![supported](v.png) |
| **Barras aleatorias** | ![supported](v.png) | ![supported](v.png) |
| **Encoger y girar** | ![not supported](x.png) | ![supported](v.png) |
| **Zoom** | ![supported](v.png) | ![supported](v.png) |
| **Girar** | ![supported](v.png) | ![supported](v.png) |
| **Rebotar** | ![supported](v.png) | ![supported](v.png) |

**Trayectorias de movimiento**:

| Tipo de animación | Aspose.Slides | PowerPoint |
|---|---|---|
| **Líneas** | ![supported](v.png) | ![supported](v.png) |
| **Arcos** | ![supported](v.png) | ![supported](v.png) |
| **Giros** | ![supported](v.png) | ![supported](v.png) |
| **Formas** | ![supported](v.png) | ![supported](v.png) |
| **Bucles** | ![supported](v.png) | ![supported](v.png) |
| **Ruta personalizada** | ![supported](v.png) | ![supported](v.png) |

## **Preguntas frecuentes**

### ¿Es posible convertir presentaciones protegidas con contraseña?

Sí, Aspose.Slides permite trabajar con [presentaciones protegidas con contraseña](/slides/es/androidjava/password-protected-presentation/). Al procesar dichos archivos, debe proporcionar la contraseña correcta para que la biblioteca pueda acceder al contenido de la presentación.

### ¿Aspose.Slides admite su uso en soluciones en la nube?

Sí, Aspose.Slides puede integrarse en aplicaciones y servicios en la nube. La biblioteca está diseñada para funcionar en entornos de servidor, garantizando alto rendimiento y escalabilidad para el procesamiento por lotes de archivos.

### ¿Existen limitaciones de tamaño para las presentaciones durante la conversión?

Aspose.Slides es capaz de manejar presentaciones de prácticamente cualquier tamaño. Sin embargo, al trabajar con archivos muy grandes, pueden requerirse recursos del sistema adicionales, y a veces se recomienda optimizar la presentación para mejorar el rendimiento.