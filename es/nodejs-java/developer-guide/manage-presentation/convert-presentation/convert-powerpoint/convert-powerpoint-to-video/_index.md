---
title: Convertir presentaciones de PowerPoint a video en JavaScript
linktitle: PowerPoint a video
type: docs
weight: 130
url: /es/nodejs-java/convert-powerpoint-to-video/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Aprenda cómo convertir presentaciones de PowerPoint a video en JavaScript. Descubra código de ejemplo y técnicas de automatización para optimizar su flujo de trabajo."
---

Al convertir su presentación de PowerPoint a vídeo, obtiene 

* **Aumento de accesibilidad:** Todos los dispositivos (independientemente de la plataforma) disponen por defecto de reproductores de vídeo, a diferencia de las aplicaciones de apertura de presentaciones, por lo que a los usuarios les resulta más fácil abrir o reproducir vídeos.
* **Mayor alcance:** Con los vídeos puede llegar a una gran audiencia y dirigirse a ella con información que de otro modo podría parecer tediosa en una presentación. La mayoría de encuestas y estadísticas sugieren que la gente ve y consume vídeos más que otras formas de contenido, y generalmente prefieren ese tipo de contenido.

{{% alert color="primary" %}} 
Es posible que desee consultar nuestro [**PowerPoint to Video Online Converter**](https://products.aspose.app/slides/conversion/ppt-to-word) porque es una implementación en directo y eficaz del proceso descrito aquí.
{{% /alert %}} 

## **Conversión de PowerPoint a vídeo en Aspose.Slides**

Aspose.Slides admite la conversión de presentaciones a vídeo.

* Utilice **Aspose.Slides** para generar un conjunto de fotogramas (a partir de las diapositivas de la presentación) que correspondan a un determinado FPS (fotogramas por segundo)
* Utilice una utilidad de terceros como **ffmpeg** ([for java](https://github.com/bramp/ffmpeg-cli-wrapper)) para crear un vídeo a partir de los fotogramas. 

### **Convertir PowerPoint a vídeo**

1. Descargue ffmpeg [here](https://ffmpeg.org/download.html).
2. Ejecute el código JavaScript de conversión de PowerPoint a vídeo.

Este código JavaScript le muestra cómo convertir una presentación (que contiene una figura y dos efectos de animación) a vídeo:
```javascript
var presentation = new aspose.slides.Presentation();
try {
    // Añade una forma de sonrisa y luego la anima
    var smile = presentation.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.SmileyFace, 110, 20, 500, 500);
    var mainSequence = presentation.getSlides().get_Item(0).getTimeline().getMainSequence();
    var effectIn = mainSequence.addEffect(smile, aspose.slides.EffectType.Fly, aspose.slides.EffectSubtype.TopLeft, aspose.slides.EffectTriggerType.AfterPrevious);
    var effectOut = mainSequence.addEffect(smile, aspose.slides.EffectType.Fly, aspose.slides.EffectSubtype.BottomRight, aspose.slides.EffectTriggerType.AfterPrevious);
    effectIn.getTiming().setDuration(2.0);
    effectOut.setPresetClassType(aspose.slides.EffectPresetClassType.Exit);
    final var fps = 33;
    var frames = java.newInstanceSync("java.util.ArrayList");
    var animationsGenerator = new aspose.slides.PresentationAnimationsGenerator(presentation);
    try {
        var player = new aspose.slides.PresentationPlayer(animationsGenerator, fps);
        try {
            player.setFrameTick((sender, arguments) -> {
                try {
                    var frame = java.callStaticMethodSync("java.lang.String", "format", "frame_%04d.png", sender.getFrameIndex());
                    arguments.getFrame().save(frame, aspose.slides.ImageFormat.Png);
                    frames.add(frame);
                } catch (e) {console.log(e);
                    throw java.newInstanceSync("java.lang.RuntimeException", e);
                }
            });
            animationsGenerator.run(presentation.getSlides());
        } finally {
            if (player != null) {
                player.dispose();
            }
        }
    } finally {
        if (animationsGenerator != null) {
            animationsGenerator.dispose();
        }
    }
    // Configura la carpeta de binarios de ffmpeg. Ver esta página: https://github.com/rosenbjerg/FFMpegCore#installation
    var ffmpeg = java.newInstanceSync("FFmpeg", "path/to/ffmpeg");
    var ffprobe = java.newInstanceSync("FFprobe", "path/to/ffprobe");
    var builder = java.newInstanceSync("FFmpegBuilder").addExtraArgs("-start_number", "1").setInput("frame_%04d.png").addOutput("output.avi").setVideoFrameRate(java.getStaticFieldValue("FFmpeg", "FPS_24")).setFormat("avi").done();
    var executor = java.newInstanceSync("FFmpegExecutor", ffmpeg, ffprobe);
    executor.createJob(builder).run();
} catch (e) {console.log(e);
    console.log(e);
}
```


## **Efectos de vídeo**

Puede aplicar animaciones a los objetos de las diapositivas y usar transiciones entre diapositivas. 

{{% alert color="primary" %}} 
Es posible que desee ver estos artículos: [PowerPoint Animation](https://docs.aspose.com/slides/nodejs-java/powerpoint-animation/), [Shape Animation](https://docs.aspose.com/slides/nodejs-java/shape-animation/), y [Shape Effect](https://docs.aspose.com/slides/nodejs-java/shape-effect/).
{{% /alert %}} 

Las animaciones y transiciones hacen que las presentaciones sean más atractivas e interesantes, y lo mismo ocurre con los vídeos. Añadamos otra diapositiva y transición al código de la presentación anterior:
```javascript
// Añade una forma de sonrisa y la anima
// ...
// Añade una nueva diapositiva y una transición animada
var newSlide = presentation.getSlides().addEmptySlide(presentation.getSlides().get_Item(0).getLayoutSlide());
newSlide.getBackground().setType(aspose.slides.BackgroundType.OwnBackground);
newSlide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
newSlide.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "MAGENTA"));
newSlide.getSlideShowTransition().setType(aspose.slides.TransitionType.Push);
```


Aspose.Slides también admite animación de textos. Así animamos párrafos en objetos, que aparecerán uno tras otro (con el retardo fijado a un segundo):
```javascript
var presentation = new aspose.slides.Presentation();
try {
    // Añade texto y animaciones
    var autoShape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 210, 120, 300, 300);
    var para1 = new aspose.slides.Paragraph();
    para1.getPortions().add(new aspose.slides.Portion("Aspose Slides for Node.js via Java"));
    var para2 = new aspose.slides.Paragraph();
    para2.getPortions().add(new aspose.slides.Portion("convert PowerPoint Presentation with text to video"));
    var para3 = new aspose.slides.Paragraph();
    para3.getPortions().add(new aspose.slides.Portion("paragraph by paragraph"));
    var paragraphCollection = autoShape.getTextFrame().getParagraphs();
    paragraphCollection.add(para1);
    paragraphCollection.add(para2);
    paragraphCollection.add(para3);
    paragraphCollection.add(new aspose.slides.Paragraph());
    var mainSequence = presentation.getSlides().get_Item(0).getTimeline().getMainSequence();
    var effect1 = mainSequence.addEffect(para1, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    var effect2 = mainSequence.addEffect(para2, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    var effect3 = mainSequence.addEffect(para3, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    var effect4 = mainSequence.addEffect(para3, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    effect1.getTiming().setTriggerDelayTime(1.0);
    effect2.getTiming().setTriggerDelayTime(1.0);
    effect3.getTiming().setTriggerDelayTime(1.0);
    effect4.getTiming().setTriggerDelayTime(1.0);
    final var fps = 33;
    var frames = java.newInstanceSync("java.util.ArrayList");
    var animationsGenerator = new aspose.slides.PresentationAnimationsGenerator(presentation);
    try {
        var player = new aspose.slides.PresentationPlayer(animationsGenerator, fps);
        try {
            player.setFrameTick((sender, arguments) -> {
                try {
                    var frame = java.callStaticMethodSync("java.lang.String", "format", "frame_%04d.png", sender.getFrameIndex());
                    arguments.getFrame().save(frame, aspose.slides.ImageFormat.Png);
                    frames.add(frame);
                } catch (e) {console.log(e);
                    throw java.newInstanceSync("java.lang.RuntimeException", e);
                }
            });
            animationsGenerator.run(presentation.getSlides());
        } finally {
            if (player != null) {
                player.dispose();
            }
        }
    } finally {
        if (animationsGenerator != null) {
            animationsGenerator.dispose();
        }
    }
    // Configura la carpeta de binarios de ffmpeg. Ver esta página: https://github.com/rosenbjerg/FFMpegCore#installation
    var ffmpeg = java.newInstanceSync("FFmpeg", "path/to/ffmpeg");
    var ffprobe = java.newInstanceSync("FFprobe", "path/to/ffprobe");
    var builder = java.newInstanceSync("FFmpegBuilder").addExtraArgs("-start_number", "1").setInput("frame_%04d.png").addOutput("output.avi").setVideoFrameRate(java.getStaticFieldValue("FFmpeg", "FPS_24")).setFormat("avi").done();
    var executor = java.newInstanceSync("FFmpegExecutor", ffmpeg, ffprobe);
    executor.createJob(builder).run();
} catch (e) {console.log(e);
    console.log(e);
}
```


## **Clases de conversión de vídeo**

Para permitirle realizar tareas de conversión de PowerPoint a vídeo, Aspose.Slides proporciona las clases [PresentationAnimationsGenerator](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentationanimationsgenerator/) y [PresentationPlayer](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentationplayer/).

[PresentationAnimationsGenerator](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentationanimationsgenerator/) le permite establecer el tamaño del fotograma para el vídeo (que se creará más adelante) a través de su constructor. Si pasa una instancia de la presentación, `Presentation.getSlideSize` se utilizará y genera animaciones que [PresentationPlayer](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentationplayer/) usa.

Cuando se generan animaciones, se genera un evento `NewAnimation` para cada animación sucesiva, que tiene el parámetro del reproductor de animación de la presentación. Este último es una clase que representa un reproductor para una animación independiente.

Para trabajar con el reproductor de animación de la presentación, se utilizan los métodos `getDuration` (la duración completa de la animación) y `setTimePosition`. Cada posición de animación se establece dentro del rango *0 to duration*, y luego el método `getFrame` devolverá un BufferedImage que corresponde al estado de la animación en ese momento:
```javascript
var presentation = new aspose.slides.Presentation();
try {
    // Añade una forma de sonrisa y la anima
    var smile = presentation.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.SmileyFace, 110, 20, 500, 500);
    var mainSequence = presentation.getSlides().get_Item(0).getTimeline().getMainSequence();
    var effectIn = mainSequence.addEffect(smile, aspose.slides.EffectType.Fly, aspose.slides.EffectSubtype.TopLeft, aspose.slides.EffectTriggerType.AfterPrevious);
    var effectOut = mainSequence.addEffect(smile, aspose.slides.EffectType.Fly, aspose.slides.EffectSubtype.BottomRight, aspose.slides.EffectTriggerType.AfterPrevious);
    effectIn.getTiming().setDuration(2.0);
    effectOut.setPresetClassType(aspose.slides.EffectPresetClassType.Exit);
    var animationsGenerator = new aspose.slides.PresentationAnimationsGenerator(presentation);
    try {
        animationsGenerator.setNewAnimation(animationPlayer -> {
            console.log(java.callStaticMethodSync("java.lang.String", "format", "Animation total duration: %f", animationPlayer.getDuration()));
            animationPlayer.setTimePosition(0); // estado inicial de la animación
            try {
                // mapa de bits del estado inicial de la animación
                animationPlayer.getFrame().save("firstFrame.png", aspose.slides.ImageFormat.Png);
            } catch (e) {console.log(e);
                throw java.newInstanceSync("java.lang.RuntimeException", e);
            }
            animationPlayer.setTimePosition(animationPlayer.getDuration()); // estado final de la animación
            try {
                // último fotograma de la animación
                animationPlayer.getFrame().save("lastFrame.png", aspose.slides.ImageFormat.Png);
            } catch (e) {console.log(e);
                throw java.newInstanceSync("java.lang.RuntimeException", e);
            }
        });
    } finally {
        if (animationsGenerator != null) {
            animationsGenerator.dispose();
        }
    }
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```


Para que todas las animaciones de una presentación se reproduzcan a la vez, se utiliza la clase [PresentationPlayer](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentationplayer/). Esta clase toma una instancia de [PresentationAnimationsGenerator](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentationanimationsgenerator/) y FPS para los efectos en su constructor y luego llama al evento `FrameTick` para todas las animaciones para que se reproduzcan:
```javascript
var presentation = new aspose.slides.Presentation("animated.pptx");
try {
    var animationsGenerator = new aspose.slides.PresentationAnimationsGenerator(presentation);
    try {
        var player = new aspose.slides.PresentationPlayer(animationsGenerator, 33);
        try {
            player.setFrameTick((sender, arguments) -> {
                try {
                    arguments.getFrame().save(("frame_" + sender.getFrameIndex()) + ".png", aspose.slides.ImageFormat.Png);
                } catch (e) {console.log(e);
                    throw java.newInstanceSync("java.lang.RuntimeException", e);
                }
            });
            animationsGenerator.run(presentation.getSlides());
        } finally {
            if (player != null) {
                player.dispose();
            }
        }
    } finally {
        if (animationsGenerator != null) {
            animationsGenerator.dispose();
        }
    }
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```


Luego los fotogramas generados pueden compilarse para producir un vídeo. Consulte la sección [Convert PowerPoint to Video](https://docs.aspose.com/slides/nodejs-java/convert-powerpoint-to-video/#convert-powerpoint-to-video).

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

Sí, Aspose.Slides permite trabajar con presentaciones protegidas con contraseña. Al procesar estos archivos, debe proporcionar la contraseña correcta para que la biblioteca pueda acceder al contenido de la presentación.

**¿Aspose.Slides es compatible con su uso en soluciones en la nube?**

Sí, Aspose.Slides puede integrarse en aplicaciones y servicios en la nube. La biblioteca está diseñada para funcionar en entornos de servidor, garantizando alto rendimiento y escalabilidad para el procesamiento por lotes de archivos.

**¿Existen limitaciones de tamaño para las presentaciones durante la conversión?**

Aspose.Slides es capaz de manejar presentaciones de prácticamente cualquier tamaño. Sin embargo, al trabajar con archivos muy grandes, pueden requerirse recursos del sistema adicionales, y a veces se recomienda optimizar la presentación para mejorar el rendimiento.