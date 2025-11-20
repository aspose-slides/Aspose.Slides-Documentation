---
title: Convertir presentaciones de PowerPoint a video con Python
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
description: "Aprenda cómo convertir presentaciones de PowerPoint y OpenDocument a video usando Python. Descubra código de ejemplo y técnicas de automatización para simplificar su flujo de trabajo."
---

## **Resumen**

Al convertir su presentación de PowerPoint o OpenDocument a video, usted obtiene:

**Accesibilidad mejorada:** Todos los dispositivos, independientemente de la plataforma, vienen equipados con reproductores de video por defecto, lo que facilita a los usuarios abrir o reproducir videos en comparación con las aplicaciones tradicionales de presentación.

**Alcance más amplio:** Los videos le permiten llegar a una audiencia mayor y presentar la información en un formato más atractivo. Encuestas y estadísticas indican que la gente prefiere ver y consumir contenido de video sobre otras formas, haciendo su mensaje más impactante.

{{% alert color="primary" %}} 

Consulte nuestro [**Convertidor en línea de PowerPoint a Video**](https://products.aspose.app/slides/video) porque ofrece una implementación en vivo y eficaz del proceso descrito aquí.

{{% /alert %}} 

En [Aspose.Slides for Python 24.4](https://releases.aspose.com/slides/python-net/release-notes/2024/aspose-slides-for-python-net-24-4-release-notes/), implementamos soporte para convertir presentaciones a video.

* Utilice Aspose.Slides for Python para generar fotogramas a partir de las diapositivas de la presentación a una velocidad de cuadros especificada (FPS).
* Luego, use una utilidad de terceros como ffmpeg para compilar estos fotogramas en un video.

## **Convertir una presentación de PowerPoint a video**

1. Utilice el comando pip install para agregar Aspose.Slides for Python a su proyecto: `pip install aspose-slides==24.4.0`
2. Descargue ffmpeg desde [aquí](https://ffmpeg.org/download.html) o instálelo mediante el gestor de paquetes.
3. Asegúrese de que ffmpeg esté en la `PATH`. De lo contrario, inicie ffmpeg usando la ruta completa al ejecutable (por ejemplo, `C:\ffmpeg\ffmpeg.exe` en Windows o `/opt/ffmpeg/ffmpeg` en Linux).
4. Ejecute el código de conversión de PowerPoint a video.

Este código Python demuestra cómo convertir una presentación (que contiene una forma y dos efectos de animación) en un video:
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


## **Efectos de video**

Al convertir una presentación de PowerPoint a video usando Aspose.Slides for Python, puede aplicar varios efectos de video para mejorar la calidad visual del resultado. Estos efectos le permiten controlar la apariencia de las diapositivas en el video final añadiendo transiciones suaves, animaciones y otros elementos visuales. Esta sección explica las opciones de efectos de video disponibles y muestra cómo aplicarlos.

{{% alert color="primary" %}} 

Vea [Animación de PowerPoint](https://docs.aspose.com/slides/python-net/powerpoint-animation/), [Animación de forma](https://docs.aspose.com/slides/python-net/shape-animation/), y [Efecto de forma](https://docs.aspose.com/slides/python-net/shape-effect/).

{{% /alert %}} 

Las animaciones y transiciones hacen que las presentaciones sean más atractivas e interesantes — y lo mismo ocurre con los videos. Añadamos otra diapositiva y transición al código de la presentación anterior:
```python
import aspose.pydrawing as drawing

# Añadir una forma de sonrisa y animarla.
# ...

# Añadir una nueva diapositiva y una transición animada.
new_slide = presentation.slides.add_empty_slide(presentation.slides[0].layout_slide)
new_slide.background.type = slides.BackgroundType.OWN_BACKGROUND
new_slide.background.fill_format.fill_type = slides.FillType.SOLID
new_slide.background.fill_format.solid_fill_color.color = drawing.Color.indigo
new_slide.slide_show_transition.type = slides.TransitionType.PUSH
```


Aspose.Slides for Python también admite animaciones de texto. En este ejemplo, animamos párrafos en objetos para que aparezcan uno tras otro, con un retraso de un segundo entre ellos:
```python
import aspose.slides as slides
import subprocess

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # Agregar texto y animaciones.
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


## **Clases de conversión de video**

Para habilitar tareas de conversión de PowerPoint a video, Aspose.Slides for Python ofrece el [PresentationEnumerableAnimationsGenerator](https://reference.aspose.com/slides/python-net/aspose.slides.export/presentationenumerableanimationsgenerator/).

`PresentationEnumerableAnimationsGenerator` le permite establecer el tamaño del fotograma para el video (que se creará posteriormente) y el valor de FPS (cuadros por segundo) a través de su constructor. Si pasa una instancia de una presentación, se usará su `Presentation.SlideSize`.

Para que todas las animaciones en una presentación se reproduzcan a la vez, use el método `PresentationEnumerableAnimationsGenerator.enumerate_frames`. Este método toma una colección de diapositivas y devuelve secuencialmente [EnumerableFrameArgs](https://reference.aspose.com/slides/python-net/aspose.slides.export/enumerableframeargs/). Luego, utilice `EnumerableFrameArgs.get_frame()` para obtener cada fotograma del video.
```python
import aspose.slides as slides

with slides.Presentation("animated.pptx") as presentation:
    fps = 33
    with slides.export.PresentationEnumerableFramesGenerator(presentation, fps) as frames_stream:
        for frame_args in frames_stream.enumerate_frames(presentation.slides):
            frame_args.get_frame().save(f"frame_{frame_args.frames_generator.frame_index:04d}.png")
```


Después, los fotogramas generados pueden compilarse en un video. Para más detalles, consulte la sección [Convertir PowerPoint a Video](https://docs.aspose.com/slides/python-net/convert-powerpoint-to-video/#convert-powerpoint-to-video).

## **Animaciones y efectos compatibles**

Al convertir una presentación de PowerPoint a video usando Aspose.Slides for Python, es importante comprender qué animaciones y efectos son compatibles en el resultado. Aspose.Slides admite una amplia gama de efectos comunes de entrada, salida y énfasis como desvanecimiento, vuelo, zoom y giro. Sin embargo, algunas animaciones avanzadas o personalizadas pueden no preservarse completamente o pueden aparecer de forma diferente en el video final. Esta sección describe las animaciones y efectos compatibles.

**Entrada**:

| Tipo de animación | Aspose.Slides | PowerPoint |
|---|---|---|
| **Aparecer** | ![not supported](x.png) | ![supported](v.png) |
| **Desvanecer** | ![supported](v.png) | ![supported](v.png) |
| **Entrar volando** | ![supported](v.png) | ![supported](v.png) |
| **Flotar al entrar** | ![supported](v.png) | ![supported](v.png) |
| **Dividir** | ![supported](v.png) | ![supported](v.png) |
| **Barrer** | ![supported](v.png) | ![supported](v.png) |
| **Forma** | ![supported](v.png) | ![supported](v.png) |
| **Rueda** | ![supported](v.png) | ![supported](v.png) |
| **Barras aleatorias** | ![supported](v.png) | ![supported](v.png) |
| **Crecer y girar** | ![not supported](x.png) | ![supported](v.png) |
| **Zoom** | ![supported](v.png) | ![supported](v.png) |
| **Giro** | ![supported](v.png) | ![supported](v.png) |
| **Rebote** | ![supported](v.png) | ![supported](v.png) |

**Énfasis**:

| Tipo de animación | Aspose.Slides | PowerPoint |
|---|---|---|
| **Pulso** | ![not supported](x.png) | ![supported](v.png) |
| **Pulso de color** | ![not supported](x.png) | ![supported](v.png) |
| **Balanceo** | ![supported](v.png) | ![supported](v.png) |
| **Giro** | ![supported](v.png) | ![supported](v.png) |
| **Crecer/Encoger** | ![not supported](x.png) | ![supported](v.png) |
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
| **Salir volando** | ![supported](v.png) | ![supported](v.png) |
| **Flotar al salir** | ![supported](v.png) | ![supported](v.png) |
| **Dividir** | ![supported](v.png) | ![supported](v.png) |
| **Barrer** | ![supported](v.png) | ![supported](v.png) |
| **Forma** | ![supported](v.png) | ![supported](v.png) |
| **Barras aleatorias** | ![supported](v.png) | ![supported](v.png) |
| **Encoger y girar** | ![not supported](x.png) | ![supported](v.png) |
| **Zoom** | ![supported](v.png) | ![supported](v.png) |
| **Giro** | ![supported](v.png) | ![supported](v.png) |
| **Rebote** | ![supported](v.png) | ![supported](v.png) |

**Rutas de movimiento**:

| Tipo de animación | Aspose.Slides | PowerPoint |
|---|---|---|
| **Líneas** | ![supported](v.png) | ![supported](v.png) |
| **Arcos** | ![supported](v.png) | ![supported](v.png) |
| **Giros** | ![supported](v.png) | ![supported](v.png) |
| **Formas** | ![supported](v.png) | ![supported](v.png) |
| **Bucles** | ![supported](v.png) | ![supported](v.png) |
| **Ruta personalizada** | ![supported](v.png) | ![supported](v.png) |

## **Efectos de transición de diapositivas compatibles**

Los efectos de transición de diapositivas juegan un papel importante en crear cambios suaves y visualmente atractivos entre diapositivas en un video. Aspose.Slides for Python admite una variedad de efectos de transición de uso común para ayudar a preservar el flujo y estilo de su presentación original. Esta sección destaca qué efectos de transición son compatibles durante el proceso de conversión.

**Sutil**:

| Tipo de animación | Aspose.Slides | PowerPoint |
|---|---|---|
| **Transformar** | ![not supported](x.png) | ![supported](v.png) |
| **Desvanecer** | ![supported](v.png) | ![supported](v.png) |
| **Empujar** | ![supported](v.png) | ![supported](v.png) |
| **Jalar** | ![supported](v.png) | ![supported](v.png) |
| **Barrer** | ![supported](v.png) | ![supported](v.png) |
| **Dividir** | ![supported](v.png) | ![supported](v.png) |
| **Revelar** | ![not supported](x.png) | ![supported](v.png) |
| **Barras aleatorias** | ![supported](v.png) | ![supported](v.png) |
| **Forma** | ![not supported](x.png) | ![supported](v.png) |
| **Descubrir** | ![not supported](x.png) | ![supported](v.png) |
| **Cubrir** | ![supported](v.png) | ![supported](v.png) |
| **Destello** | ![supported](v.png) | ![supported](v.png) |
| **Tiras** | ![supported](v.png) | ![supported](v.png) |

**Emocionante**:

| Tipo de animación | Aspose.Slides | PowerPoint |
|---|---|---|
| **Caerse** | ![not supported](x.png) | ![supported](v.png) |
| **Capa** | ![not supported](x.png) | ![supported](v.png) |
| **Cortinas** | ![not supported](x.png) | ![supported](v.png) |
| **Viento** | ![not supported](x.png) | ![supported](v.png) |
| **Prestigio** | ![not supported](x.png) | ![supported](v.png) |
| **Fractura** | ![not supported](x.png) | ![supported](v.png) |
| **Aplastar** | ![not supported](x.png) | ![supported](v.png) |
| **Desprender** | ![not supported](x.png) | ![supported](v.png) |
| **Curvado de página** | ![not supported](x.png) | ![supported](v.png) |
| **Avión** | ![not supported](x.png) | ![supported](v.png) |
| **Origami** | ![not supported](x.png) | ![supported](v.png) |
| **Disolver** | ![supported](v.png) | ![supported](v.png) |
| **Tablero de damas** | ![not supported](x.png) | ![supported](v.png) |
| **Persianas** | ![not supported](x.png) | ![supported](v.png) |
| **Reloj** | ![supported](v.png) | ![supported](v.png) |
| **Ondulación** | ![not supported](x.png) | ![supported](v.png) |
| **Panel de abeja** | ![not supported](x.png) | ![supported](v.png) |
| **Brillo** | ![not supported](x.png) | ![supported](v.png) |
| **Vórtice** | ![not supported](x.png) | ![supported](v.png) |
| **Desgarrar** | ![not supported](x.png) | ![supported](v.png) |
| **Cambiar** | ![not supported](x.png) | ![supported](v.png) |
| **Voltear** | ![not supported](x.png) | ![supported](v.png) |
| **Galería** | ![not supported](x.png) | ![supported](v.png) |
| **Cubo** | ![not supported](x.png) | ![supported](v.png) |
| **Puertas** | ![not supported](x.png) | ![supported](v.png) |
| **Caja** | ![not supported](x.png) | ![supported](v.png) |
| **Peine** | ![not supported](x.png) | ![supported](v.png) |
| **Zoom** | ![supported](v.png) | ![supported](v.png) |
| **Aleatorio** | ![not supported](x.png) | ![supported](v.png) |

**Contenido dinámico**:

| Tipo de animación | Aspose.Slides | PowerPoint |
|---|---|---|
| **Paneo** | ![not supported](x.png) | ![supported](v.png) |
| **Rueda de la fortuna** | ![supported](v.png) | ![supported](v.png) |
| **Cinta transportadora** | ![not supported](x.png) | ![supported](v.png) |
| **Rotar** | ![not supported](x.png) | ![supported](v.png) |
| **Órbita** | ![not supported](x.png) | ![supported](v.png) |
| **Volar a través** | ![supported](v.png) | ![supported](v.png) |

## **Preguntas frecuentes**

**¿Es posible convertir presentaciones protegidas con contraseña?**

Sí, Aspose.Slides for Python permite trabajar con presentaciones protegidas con contraseña. Al procesar dichos archivos, debe proporcionar la contraseña correcta para que la biblioteca pueda acceder al contenido de la presentación.

**¿Aspose.Slides for Python admite su uso en soluciones en la nube?**

Sí, Aspose.Slides for Python puede integrarse en aplicaciones y servicios en la nube. La biblioteca está diseñada para funcionar en entornos de servidor, garantizando alto rendimiento y escalabilidad para el procesamiento por lotes de archivos.

**¿Existen limitaciones de tamaño para las presentaciones durante la conversión?**

Aspose.Slides for Python es capaz de manejar presentaciones de prácticamente cualquier tamaño. Sin embargo, al trabajar con archivos muy grandes, pueden requerirse recursos del sistema adicionales, y a veces se recomienda optimizar la presentación para mejorar el rendimiento.