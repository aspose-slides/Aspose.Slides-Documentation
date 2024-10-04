---
title: Convertir PowerPoint a Video
type: docs
weight: 130
url: /python-net/convert-powerpoint-to-video/
keywords: "Convertir PowerPoint, PPT, PPTX, Presentación, Video, MP4, PPT a video, PPT a MP4, Python, Aspose.Slides"
description: "Convertir PowerPoint a Video en Python"
---

Al convertir tu presentación de PowerPoint a video, obtienes

* **Aumento en accesibilidad:** Todos los dispositivos (independientemente de la plataforma) vienen equipados con reproductores de video por defecto en comparación con aplicaciones que abren presentaciones, por lo que a los usuarios les resulta más fácil abrir o reproducir videos.
* **Mayor alcance:** A través de videos, puedes alcanzar a una gran audiencia y brindarles información que de otro modo podría parecer tediosa en una presentación. La mayoría de las encuestas y estadísticas sugieren que las personas ven y consumen videos más que otras formas de contenido, y generalmente prefieren dicho contenido.

{{% alert color="primary" %}} 

Es posible que desees consultar nuestro [**Convertidor de PowerPoint a Video Online**](https://products.aspose.app/slides/conversion/ppt-to-word) porque es una implementación en vivo y efectiva del proceso descrito aquí.

{{% /alert %}} 

## **Conversión de PowerPoint a Video en Aspose.Slides**

En [Aspose.Slides 24.4](https://releases.aspose.com/slides/python-net/release-notes/2024/aspose-slides-for-python-net-24-4-release-notes/), implementamos soporte para la conversión de presentaciones a video.

* Usa Aspose.Slides para generar un conjunto de cuadros (de las diapositivas de la presentación) que correspondan a cierta FPS (cuadros por segundo).
* Usa una utilidad de terceros como ffmpeg para crear un video basado en los cuadros.

### **Convertir PowerPoint a Video**

1. Usa el comando de instalación pip para agregar Aspose.Slides a tu proyecto:
   * ejecuta `pip install Aspose.Slides==24.4.0`
2. Descarga ffmpeg [aquí](https://ffmpeg.org/download.html) o instala a través del administrador de paquetes.
3. Asegúrate de que ffmpeg esté en el `PATH`, de lo contrario, inicia ffmpeg utilizando la ruta completa al binario (por ejemplo, `C:\ffmpeg\ffmpeg.exe` en Windows o `/opt/ffmpeg/ffmpeg` en Linux).
4. Ejecuta el código para convertir PowerPoint a video.

Este código Python muestra cómo convertir una presentación (que contiene una figura y dos efectos de animación) a un video:

```python
import aspose.slides as slides
import subprocess

with slides.Presentation() as presentation:
    smile = presentation.slides[0].shapes.add_auto_shape(slides.ShapeType.SMILEY_FACE, 110, 20, 500, 500)
    effect_in = presentation.slides[0].timeline.main_sequence.add_effect(smile, slides.animation.EffectType.FLY, slides.animation.EffectSubtype.TOP_LEFT, slides.animation.EffectTriggerType.AFTER_PREVIOUS)
    effect_out = presentation.slides[0].timeline.main_sequence.add_effect(smile, slides.animation.EffectType.FLY, slides.animation.EffectSubtype.BOTTOM_RIGHT, slides.animation.EffectTriggerType.AFTER_PREVIOUS)
    effect_in.timing.duration = 2
    effect_out.preset_class_type = slides.animation.EffectPresetClassType.EXIT

    fps = 33
    with slides.export.PresentationEnumerableFramesGenerator(presentation, fps) as frames_stream:
        for frame_args in frames_stream.enumerate_frames(presentation.slides):
            frame = "frame_{:04d}.png".format(frame_args.frames_generator.frame_index)
            frame_args.get_frame().save(frame)

    cmd_line = ["ffmpeg", "-r", str(fps), "-i", "frame_%04d.png", "-y", "-s", "720x540", "-pix_fmt", "yuv420p", "smile.webm"]
    subprocess.call(cmd_line)
```

## **Efectos de Video**

Puedes aplicar animaciones a objetos en las diapositivas y usar transiciones entre diapositivas.

{{% alert color="primary" %}} 

Es posible que desees ver estos artículos: [Animación de PowerPoint](https://docs.aspose.com/slides/python-net/powerpoint-animation/), [Animación de Formas](https://docs.aspose.com/slides/python-net/shape-animation/), y [Efecto de Forma](https://docs.aspose.com/slides/python-net/shape-effect/).

{{% /alert %}} 

Las animaciones y transiciones hacen que las presentaciones sean más atractivas e interesantes, y hacen lo mismo para los videos. Agreguemos otra diapositiva y una transición al código de la presentación anterior:

```python
import aspose.pydrawing as drawing
# Agrega una forma de sonrisa y la anima
# ...
# Agrega una nueva diapositiva y transición animada

new_slide = presentation.slides.add_empty_slide(presentation.slides[0].layout_slide)
new_slide.background.type = slides.BackgroundType.OWN_BACKGROUND
new_slide.background.fill_format.fill_type = slides.FillType.SOLID
new_slide.background.fill_format.solid_fill_color.color = drawing.Color.indigo
new_slide.slide_show_transition.type = slides.TransitionType.PUSH
```

Aspose.Slides también soporta animaciones para textos. Así que animamos párrafos en objetos, que aparecerán uno tras otro (con el retraso configurado en un segundo):

```python
import aspose.slides as slides
import subprocess

with slides.Presentation() as presentation:
    # Agrega texto y animaciones
    auto_shape = presentation.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 210, 120, 300, 300)
    para1 = slides.Paragraph()
    para1.portions.add(slides.Portion("Aspose Slides para .NET"))
    para2 = slides.Paragraph()
    para2.portions.add(slides.Portion("convertir presentación de PowerPoint con texto a video"))

    para3 = slides.Paragraph()
    para3.portions.add(slides.Portion("párrafo por párrafo"))
    auto_shape.text_frame.paragraphs.add(para1)
    auto_shape.text_frame.paragraphs.add(para2)
    auto_shape.text_frame.paragraphs.add(para3)
    auto_shape.text_frame.paragraphs.add(slides.Paragraph())

    effect = presentation.slides[0].timeline.main_sequence.add_effect(para1, slides.animation.EffectType.APPEAR, slides.animation.EffectSubtype.NONE, slides.animation.EffectTriggerType.AFTER_PREVIOUS)

    effect2 = presentation.slides[0].timeline.main_sequence.add_effect(para2, slides.animation.EffectType.APPEAR, slides.animation.EffectSubtype.NONE, slides.animation.EffectTriggerType.AFTER_PREVIOUS)

    effect3 = presentation.slides[0].timeline.main_sequence.add_effect(para3, slides.animation.EffectType.APPEAR, slides.animation.EffectSubtype.NONE, slides.animation.EffectTriggerType.AFTER_PREVIOUS)

    effect4 = presentation.slides[0].timeline.main_sequence.add_effect(para3, slides.animation.EffectType.APPEAR, slides.animation.EffectSubtype.NONE, slides.animation.EffectTriggerType.AFTER_PREVIOUS)

    effect.timing.trigger_delay_time = 1
    effect2.timing.trigger_delay_time = 1
    effect3.timing.trigger_delay_time = 1
    effect4.timing.trigger_delay_time = 1

    # Convierte cuadros a video
    fps = 33
    with slides.export.PresentationEnumerableFramesGenerator(presentation, fps) as frames_stream:
        for frame_args in frames_stream.enumerate_frames(presentation.slides):
            frame = "frame_{:04d}.png".format(frame_args.frames_generator.frame_index)
            frame_args.get_frame().save(frame)

    cmd_line = ["ffmpeg", "-r", str(fps), "-i", "frame_%04d.png", "-y", "-s", "720x540", "-pix_fmt", "yuv420p", "text_animation.webm"]
    subprocess.call(cmd_line)
```

## **Clases de Conversión de Video**

Para permitirte realizar tareas de conversión de PowerPoint a video, Aspose.Slides proporciona el [PresentationEnumerableAnimationsGenerator](https://reference.aspose.com/slides/python-net/aspose.slides.export/presentationenumerableanimationsgenerator/).

PresentationEnumerableAnimationsGenerator te permite establecer el tamaño del cuadro para el video (que se creará más tarde) y el valor de FPS (cuadros por segundo) a través de su constructor. Si pasas una instancia de la presentación, se usará `Presentation.SlideSize`.

Para que todas las animaciones en una presentación se reproduzcan a la vez, usa el método PresentationEnumerableAnimationsGenerator.enumerate_frames. Este método toma una colección de diapositivas y permite obtener secuencialmente [EnumerableFrameArgs](https://reference.aspose.com/slides/python-net/aspose.slides.export/enumerableframeargs/). Luego, EnumerableFrameArgs.get_frame() te permite obtener el cuadro de video:

```python
import aspose.slides as slides

with slides.Presentation("animated.pptx") as presentation:
    fps = 33
    with slides.export.PresentationEnumerableFramesGenerator(presentation, fps) as frames_stream:
        for frame_args in frames_stream.enumerate_frames(presentation.slides):
            frame_args.get_frame().save(f"frame_{frame_args.frames_generator.frame_index:04d}.png")
```

Luego, los cuadros generados pueden ser compilados para producir un video. Consulta la sección [Convertir PowerPoint a Video](https://docs.aspose.com/slides/python-net/convert-powerpoint-to-video/#convert-powerpoint-to-video).

## **Animaciones y Efectos Soportados**


**Entrada**:

| Tipo de Animación | Aspose.Slides | PowerPoint |
|---|---|---|
| **Aparecer** | ![no soportado](x.png) | ![soportado](v.png) |
| **Desvanecer** | ![soportado](v.png) | ![soportado](v.png) |
| **Entrar Volando** | ![soportado](v.png) | ![soportado](v.png) |
| **Entrar Flotando** | ![soportado](v.png) | ![soportado](v.png) |
| **Dividir** | ![soportado](v.png) | ![soportado](v.png) |
| **Barrer** | ![soportado](v.png) | ![soportado](v.png) |
| **Forma** | ![soportado](v.png) | ![soportado](v.png) |
| **Rueda** | ![soportado](v.png) | ![soportado](v.png) |
| **Barras Aleatorias** | ![soportado](v.png) | ![soportado](v.png) |
| **Crecer y Girar** | ![no soportado](x.png) | ![soportado](v.png) |
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
| **Crecer/Disminuir** | ![no soportado](x.png) | ![soportado](v.png) |
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
| **Salir Volando** | ![soportado](v.png) | ![soportado](v.png) |
| **Salir Flotando** | ![soportado](v.png) | ![soportado](v.png) |
| **Dividir** | ![soportado](v.png) | ![soportado](v.png) |
| **Barrer** | ![soportado](v.png) | ![soportado](v.png) |
| **Forma** | ![soportado](v.png) | ![soportado](v.png) |
| **Barras Aleatorias** | ![soportado](v.png) | ![soportado](v.png) |
| **Disminuir y Girar** | ![no soportado](x.png) | ![soportado](v.png) |
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

## **Efectos de Transición de Diapositiva Soportados**

**Sutil**:

| Tipo de Animación | Aspose.Slides | PowerPoint |
|---|---|---|
| **Morph** | ![no soportado](x.png) | ![soportado](v.png) |
| **Desvanecer** | ![soportado](v.png) | ![soportado](v.png) |
| **Empujar** | ![soportado](v.png) | ![soportado](v.png) |
| **Tirar** | ![soportado](v.png) | ![soportado](v.png) |
| **Barrer** | ![soportado](v.png) | ![soportado](v.png) |
| **Dividir** | ![soportado](v.png) | ![soportado](v.png) |
| **Revelar** | ![no soportado](x.png) | ![soportado](v.png) |
| **Barras Aleatorias** | ![soportado](v.png) | ![soportado](v.png) |
| **Forma** | ![no soportado](x.png) | ![soportado](v.png) |
| **Descubrir** | ![no soportado](x.png) | ![soportado](v.png) |
| **Cubrir** | ![soportado](v.png) | ![soportado](v.png) |
| **Destello** | ![soportado](v.png) | ![soportado](v.png) |
| **Tiras** | ![soportado](v.png) | ![soportado](v.png) |

**Emocionante**:

| Tipo de Animación | Aspose.Slides | PowerPoint |
|---|---|---|
| **Caer** | ![no soportado](x.png) | ![soportado](v.png) |
| **Drapeado** | ![no soportado](x.png) | ![soportado](v.png) |
| **Cortinas** | ![no soportado](x.png) | ![soportado](v.png) |
| **Viento** | ![no soportado](x.png) | ![soportado](v.png) |
| **Prestigio** | ![no soportado](x.png) | ![soportado](v.png) |
| **Fractura** | ![no soportado](x.png) | ![soportado](v.png) |
| **Aplastar** | ![no soportado](x.png) | ![soportado](v.png) |
| **Desprender** | ![no soportado](x.png) | ![soportado](v.png) |
| **Papel Curl** | ![no soportado](x.png) | ![soportado](v.png) |
| **Avión** | ![no soportado](x.png) | ![soportado](v.png) |
| **Origami** | ![no soportado](x.png) | ![soportado](v.png) |
| **Disolver** | ![soportado](v.png) | ![soportado](v.png) |
| **Damas** | ![no soportado](x.png) | ![soportado](v.png) |
| **Persianas** | ![no soportado](x.png) | ![soportado](v.png) |
| **Reloj** | ![soportado](v.png) | ![soportado](v.png) |
| **Olas** | ![no soportado](x.png) | ![soportado](v.png) |
| **Panal** | ![no soportado](x.png) | ![soportado](v.png) |
| **Brillo** | ![no soportado](x.png) | ![soportado](v.png) |
| **Vórtice** | ![no soportado](x.png) | ![soportado](v.png) |
| **Desgarrar** | ![no soportado](x.png) | ![soportado](v.png) |
| **Cambiar** | ![no soportado](x.png) | ![soportado](v.png) |
| **Girar** | ![no soportado](x.png) | ![soportado](v.png) |
| **Galería** | ![no soportado](x.png) | ![soportado](v.png) |
| **Cubo** | ![no soportado](x.png) | ![soportado](v.png) |
| **Puertas** | ![no soportado](x.png) | ![soportado](v.png) |
| **Caja** | ![no soportado](x.png) | ![soportado](v.png) |
| **Peina** | ![no soportado](x.png) | ![soportado](v.png) |
| **Acercar** | ![soportado](v.png) | ![soportado](v.png) |
| **Aleatorio** | ![no soportado](x.png) | ![soportado](v.png) |

**Contenido Dinámico**:

| Tipo de Animación | Aspose.Slides | PowerPoint |
|---|---|---|
| **Paneo** | ![no soportado](x.png) | ![soportado](v.png) |
| **Rueda de la fortuna** | ![soportado](v.png) | ![soportado](v.png) |
| **Transportador** | ![no soportado](x.png) | ![soportado](v.png) |
| **Rotar** | ![no soportado](x.png) | ![soportado](v.png) |
| **Órbita** | ![no soportado](x.png) | ![soportado](v.png) |
| **Volar a través** | ![soportado](v.png) | ![soportado](v.png) |