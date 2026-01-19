---
title: Convertir presentaciones de PowerPoint a video en Python
linktitle: PowerPoint a video
type: docs
weight: 130
url: /es/python-net/convert-powerpoint-to-video/
keywords:
- PowerPoint a video
- convertir PowerPoint a video
- presentación a video
- convertir presentación a video
- PPT a video
- convertir PPT a video
- PPTX a video
- convertir PPTX a video
- ODP a video
- convertir ODP a video
- PowerPoint a MP4
- convertir PowerPoint a MP4
- presentación a MP4
- convertir presentación a MP4
- PPT a MP4
- convertir PPT a MP4
- PPTX a MP4
- convertir PPTX a MP4
- Conversión de PowerPoint a video
- Conversión de presentación a video
- Conversión de PPT a video
- Conversión de PPTX a video
- Conversión de ODP a video
- Conversión de video con Python
- PowerPoint
- Python
- Aspose.Slides
description: "Aprenda a convertir presentaciones de PowerPoint y OpenDocument a video mediante Python. Descubra código de ejemplo y técnicas de automatización para optimizar su flujo de trabajo."
---

## **Resumen**

Al convertir su presentación de PowerPoint o OpenDocument a video, usted obtiene:

**Accesibilidad mejorada:** Todos los dispositivos, independientemente de la plataforma, incluyen reproductores de vídeo por defecto, lo que facilita a los usuarios abrir o reproducir vídeos en comparación con las aplicaciones tradicionales de presentaciones.

**Alcance más amplio:** Los vídeos le permiten llegar a una audiencia mayor y presentar la información de forma más atractiva. Encuestas y estadísticas indican que la gente prefiere ver y consumir contenido en vídeo frente a otros formatos, lo que hace su mensaje más impactante.

{{% alert color="primary" %}} 
Consulte nuestro [**Convertidor en línea de PowerPoint a Video**](https://products.aspose.app/slides/video) porque ofrece una implementación en tiempo real y eficaz del proceso descrito aquí.
{{% /alert %}} 

En [Aspose.Slides for Python 24.4](https://releases.aspose.com/slides/python-net/release-notes/2024/aspose-slides-for-python-net-24-4-release-notes/), implementamos soporte para convertir presentaciones a vídeo.

* Utilice Aspose.Slides for Python para generar fotogramas a partir de las diapositivas de la presentación a una velocidad de fotogramas especificada (FPS).
* Luego, utilice una herramienta de terceros como ffmpeg para compilar esos fotogramas en un vídeo.

## **Convertir una presentación PowerPoint a vídeo**

1. Utilice el comando pip install para añadir Aspose.Slides for Python a su proyecto: `pip install aspose-slides==24.4.0`
2. Descargue ffmpeg desde [aquí](https://ffmpeg.org/download.html) o instálelo mediante el gestor de paquetes.
3. Asegúrese de que ffmpeg esté en la `PATH`. De lo contrario, lance ffmpeg usando la ruta completa al ejecutable (p. ej., `C:\ffmpeg\ffmpeg.exe` en Windows o `/opt/ffmpeg/ffmpeg` en Linux).
4. Ejecute el código de conversión de PowerPoint a vídeo.

Este código Python demuestra cómo convertir una presentación (que contiene una forma y dos efectos de animación) en un vídeo:
```python
import aspose.slides as slides
import subprocess

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    smile_shape = slide.shapes.add_auto_shape(slides.ShapeType.SMILEY_FACE, 110, 20, 500, 500)

    effect_in = slide.timeline.main_sequence.add_effect(
        smile_shape,
        slides.animation.EffectType.FLY,
        slides.animation.EffectSubtype.TOP_LEFT,
        slides.animation.EffectTriggerType.AFTER_PREVIOUS)

    effect_out = slide.timeline.main_sequence.add_effect(
        smile_shape,
        slides.animation.EffectType.FLY,
        slides.animation.EffectSubtype.BOTTOM_RIGHT,
        slides.animation.EffectTriggerType.AFTER_PREVIOUS)

    effect_in.timing.duration = 2
    effect_out.preset_class_type = slides.animation.EffectPresetClassType.EXIT

    fps = 33
    with slides.export.PresentationEnumerableFramesGenerator(presentation, fps) as frames_stream:
        for frame_args in frames_stream.enumerate_frames(presentation.slides):
            frame = "frame_{:04d}.png".format(frame_args.frames_generator.frame_index)
            frame_args.get_frame().save(frame)

    cmd_line = ["ffmpeg", "-r", str(fps), "-i", "frame_%04d.png", "-y", "-s", "720x540", "-pix_fmt", "yuv420p",
                "smile.webm"]
    subprocess.call(cmd_line)
```


## **Efectos de vídeo**

Al convertir una presentación de PowerPoint a vídeo usando Aspose.Slides for Python, puede aplicar varios efectos de vídeo para mejorar la calidad visual del resultado. Estos efectos le permiten controlar la apariencia de las diapositivas en el vídeo final añadiendo transiciones suaves, animaciones y otros elementos visuales. Esta sección explica las opciones de efectos de vídeo disponibles y muestra cómo aplicarlas.

{{% alert color="primary" %}} 
Consulte [Animación de PowerPoint](https://docs.aspose.com/slides/python-net/powerpoint-animation/), [Animación de forma](https://docs.aspose.com/slides/python-net/shape-animation/) y [Efecto de forma](https://docs.aspose.com/slides/python-net/shape-effect/).
{{% /alert %}} 

Las animaciones y transiciones hacen que las presentaciones sean más atractivas e interesantes — y lo mismo ocurre con los vídeos. Añadamos otra diapositiva y transición al código de la presentación anterior:
```python
import aspose.pydrawing as drawing

# Añadir una forma sonriente y animarla.
# ...

# Añadir una nueva diapositiva y una transición animada.
new_slide = presentation.slides.add_empty_slide(presentation.slides[0].layout_slide)
new_slide.background.type = slides.BackgroundType.OWN_BACKGROUND
new_slide.background.fill_format.fill_type = slides.FillType.SOLID
new_slide.background.fill_format.solid_fill_color.color = drawing.Color.indigo
new_slide.slide_show_transition.type = slides.TransitionType.PUSH
```


Aspose.Slides for Python también admite animaciones de texto. En este ejemplo, animamos párrafos en objetos para que aparezcan uno tras otro, con una demora de un segundo entre ellos:
```python
import aspose.slides as slides
import subprocess

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # Añadir texto y animaciones.
    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 210, 120, 300, 300)
    para1 = slides.Paragraph()
    para1.portions.add(slides.Portion("Aspose.Slides for Python"))
    para2 = slides.Paragraph()
    para2.portions.add(slides.Portion("Convert a PowerPoint presentation with text to video"))

    para3 = slides.Paragraph()
    para3.portions.add(slides.Portion("paragraph by paragraph"))
    auto_shape.text_frame.paragraphs.add(para1)
    auto_shape.text_frame.paragraphs.add(para2)
    auto_shape.text_frame.paragraphs.add(para3)
    auto_shape.text_frame.paragraphs.add(slides.Paragraph())

    effect = slide.timeline.main_sequence.add_effect(
        para1,
        slides.animation.EffectType.APPEAR,
        slides.animation.EffectSubtype.NONE,
        slides.animation.EffectTriggerType.AFTER_PREVIOUS)

    effect2 = slide.timeline.main_sequence.add_effect(
        para2,
        slides.animation.EffectType.APPEAR,
        slides.animation.EffectSubtype.NONE,
        slides.animation.EffectTriggerType.AFTER_PREVIOUS)

    effect3 = slide.timeline.main_sequence.add_effect(
        para3,
        slides.animation.EffectType.APPEAR,
        slides.animation.EffectSubtype.NONE,
        slides.animation.EffectTriggerType.AFTER_PREVIOUS)

    effect4 = slide.timeline.main_sequence.add_effect(
        para3,
        slides.animation.EffectType.APPEAR,
        slides.animation.EffectSubtype.NONE,
        slides.animation.EffectTriggerType.AFTER_PREVIOUS)

    effect.timing.trigger_delay_time = 1
    effect2.timing.trigger_delay_time = 1
    effect3.timing.trigger_delay_time = 1
    effect4.timing.trigger_delay_time = 1

    # Convertir fotogramas a video.
    fps = 33
    with slides.export.PresentationEnumerableFramesGenerator(presentation, fps) as frames_stream:
        for frame_args in frames_stream.enumerate_frames(presentation.slides):
            frame = "frame_{:04d}.png".format(frame_args.frames_generator.frame_index)
            frame_args.get_frame().save(frame)

    cmd_line = ["ffmpeg", "-r", str(fps), "-i", "frame_%04d.png", "-y", "-s", "720x540", "-pix_fmt", "yuv420p", "text_animation.webm"]
    subprocess.call(cmd_line)
```


## **Clases de conversión de vídeo**

Para habilitar tareas de conversión de PowerPoint a vídeo, Aspose.Slides for Python proporciona el [PresentationEnumerableFramesGenerator](https://reference.aspose.com/slides/python-net/aspose.slides.export/presentationenumerableframesgenerator/).

`PresentationEnumerableFramesGenerator` le permite establecer el tamaño del fotograma para el vídeo (que se creará más adelante) y el valor de FPS (fotogramas por segundo) a través de su constructor. Si pasa una instancia de una presentación, se utilizará su `Presentation.SlideSize`.

Para que todas las animaciones de una presentación se reproduzcan a la vez, use el método `PresentationEnumerableFramesGenerator.enumerate_frames`. Este método toma una colección de diapositivas y devuelve secuencialmente [EnumerableFrameArgs](https://reference.aspose.com/slides/python-net/aspose.slides.export/enumerableframeargs/). Luego, use `EnumerableFrameArgs.get_frame()` para obtener cada fotograma de vídeo.
```python
import aspose.slides as slides

with slides.Presentation("animated.pptx") as presentation:
    fps = 33
    with slides.export.PresentationEnumerableFramesGenerator(presentation, fps) as frames_stream:
        for frame_args in frames_stream.enumerate_frames(presentation.slides):
            frame_args.get_frame().save(f"frame_{frame_args.frames_generator.frame_index:04d}.png")
```


Luego, los fotogramas generados pueden compilarse en un vídeo. Para más detalles, consulte la sección [Convert PowerPoint to Video](https://docs.aspose.com/slides/python-net/convert-powerpoint-to-video/#convert-powerpoint-to-video).

## **Animaciones y efectos compatibles**

Al convertir una presentación de PowerPoint a vídeo usando Aspose.Slides for Python, es importante comprender qué animaciones y efectos son compatibles en el resultado. Aspose.Slides admite una amplia gama de efectos comunes de entrada, salida y énfasis, como desvanecimiento, entrada en vuelo, zoom y rotación. Sin embargo, algunas animaciones avanzadas o personalizadas pueden no preservarse totalmente o pueden aparecer de forma diferente en el vídeo final. Esta sección describe las animaciones y efectos compatibles.

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

**Trayectorias de movimiento**:

| Tipo de animación | Aspose.Slides | PowerPoint |
|---|---|---|
| **Lines** | ![supported](v.png) | ![supported](v.png) |
| **Arcs** | ![supported](v.png) | ![supported](v.png) |
| **Turns** | ![supported](v.png) | ![supported](v.png) |
| **Shapes** | ![supported](v.png) | ![supported](v.png) |
| **Loops** | ![supported](v.png) | ![supported](v.png) |
| **Custom Path** | ![supported](v.png) | ![supported](v.png) |

## **Efectos de transición de diapositivas compatibles**

Los efectos de transición de diapositivas juegan un papel importante en crear cambios fluidos y visualmente atractivos entre diapositivas en un vídeo. Aspose.Slides for Python admite una variedad de efectos de transición comunes para ayudar a preservar el flujo y estilo de su presentación original. Esta sección destaca los efectos de transición compatibles durante el proceso de conversión.

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

Sí, Aspose.Slides for Python permite trabajar con presentaciones protegidas con contraseña. Al procesar dichos archivos, es necesario proporcionar la contraseña correcta para que la biblioteca pueda acceder al contenido de la presentación.

**¿Aspose.Slides for Python es compatible con su uso en soluciones en la nube?**

Sí, Aspose.Slides for Python puede integrarse en aplicaciones y servicios en la nube. La biblioteca está diseñada para funcionar en entornos de servidor, garantizando alto rendimiento y escalabilidad para el procesamiento por lotes de archivos.

**¿Existen limitaciones de tamaño para las presentaciones durante la conversión?**

Aspose.Slides for Python es capaz de manejar presentaciones de prácticamente cualquier tamaño. No obstante, al trabajar con archivos muy grandes pueden ser necesarios recursos del sistema adicionales, y a veces se recomienda optimizar la presentación para mejorar el rendimiento.