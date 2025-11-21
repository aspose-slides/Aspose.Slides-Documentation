---
title: Aplicar animaciones de forma en presentaciones con Python
linktitle: Animación de forma
type: docs
weight: 60
url: /es/python-net/shape-animation/
keywords:
- forma
- animación
- efecto
- forma animada
- texto animado
- agregar animación
- obtener animación
- extraer animación
- agregar efecto
- obtener efecto
- extraer efecto
- sonido del efecto
- aplicar animación
- PowerPoint
- presentación
- Python
- Aspose.Slides
description: "Descubra cómo crear y personalizar animaciones de forma en presentaciones de PowerPoint y OpenDocument con Aspose.Slides para Python mediante .NET. ¡Destáquese!"
---

Las animaciones son efectos visuales que pueden aplicarse a textos, imágenes, formas o [gráficos](/slides/es/python-net/animated-charts/). Dan vida a las presentaciones o a sus componentes. 

## **¿Por qué usar animaciones en presentaciones?**

Al usar animaciones, puedes 
* controlar el flujo de información
* enfatizar puntos importantes
* aumentar el interés o la participación de tu audiencia
* hacer que el contenido sea más fácil de leer, asimilar o procesar
* atraer la atención de tus lectores o espectadores a partes importantes en una presentación

PowerPoint ofrece muchas opciones y herramientas para animaciones y efectos de animación en las categorías de **entrada**, **salida**, **énfasis** y **trayectorias de movimiento**. 

## **Animaciones en Aspose.Slides**

* Aspose.Slides proporciona las clases y tipos que necesitas para trabajar con animaciones bajo el espacio de nombres [Aspose.Slides.Animation](https://reference.aspose.com/slides/python-net/aspose.slides.animation/), 
* Aspose.Slides ofrece más de **150 efectos de animación** bajo la enumeración [EffectType](https://reference.aspose.com/slides/python-net/aspose.slides.animation/effecttype/). Estos efectos son esencialmente los mismos (o equivalentes) que se usan en PowerPoint. 

## **Aplicar animación a TextBox**

Aspose.Slides para Python a través de .NET te permite aplicar animación al texto en una forma. 

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/). 
2. Obtén la referencia de una diapositiva mediante su índice. 
3. Añade un `rectangle` [IAutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/iautoshape/). 
4. Añade texto a `IAutoShape.TextFrame`. 
5. Obtén una secuencia principal de efectos. 
6. Añade un efecto de animación a [IAutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/iautoshape/). 
7. Establece la propiedad `TextAnimation.BuildType` al valor de la enumeración `BuildType`. 
8. Guarda la presentación en disco como un archivo PPTX. 

Este código Python muestra cómo aplicar el efecto `Fade` a AutoShape y establecer la animación de texto al valor *By 1st Level Paragraphs*:
```python
import aspose.slides as slides

# Instancia una clase de presentación que representa un archivo de presentación.
with slides.Presentation() as pres:
    sld = pres.slides[0]
    
    # Agrega una nueva AutoShape con texto
    autoShape = sld.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 150, 100)

    textFrame = autoShape.text_frame
    textFrame.text = "First paragraph \nSecond paragraph \n Third paragraph"

    # Obtiene la secuencia principal de la diapositiva.
    sequence = sld.timeline.main_sequence

    # Agrega el efecto de animación Fade a la forma
    effect = sequence.add_effect(autoShape, slides.animation.EffectType.FADE, slides.animation.EffectSubtype.NONE, slides.animation.EffectTriggerType.ON_CLICK)

    # Animar el texto de la forma por párrafos de primer nivel
    effect.text_animation.build_type = slides.animation.BuildType.BY_LEVEL_PARAGRAPHS1

    # Guarda el archivo PPTX en disco
    pres.save("AnimText_out.pptx", slides.export.SaveFormat.PPTX)
```


{{%  alert color="primary"  %}} 
Además de aplicar animaciones al texto, también puedes aplicar animaciones a un solo [Paragraph](https://reference.aspose.com/slides/python-net/aspose.slides/iparagraph/). Consulta [**Animated Text**](/slides/es/python-net/animated-text/).
{{% /alert %}} 

## **Aplicar animación a PictureFrame**

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/). 
2. Obtén la referencia de una diapositiva mediante su índice. 
3. Añade o obtén un [PictureFrame](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframe/) en la diapositiva. 
4. Obtén la secuencia principal de efectos. 
5. Añade un efecto de animación a [PictureFrame](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframe/). 
6. Guarda la presentación en disco como un archivo PPTX. 

Este código Python muestra cómo aplicar el efecto `Fly` a un marco de imagen:
```python
import aspose.slides as slides
import aspose.pydrawing as draw


# Instancia una clase de presentación que representa un archivo de presentación.
with slides.Presentation() as pres:
    # Carga la imagen que se añadirá a la colección de imágenes de la presentación
    img = draw.Bitmap("aspose-logo.jpg")
    image = pres.images.add_image(img)

    # Añade un marco de imagen a la diapositiva
    picFrame = pres.slides[0].shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 50, 50, 100, 100, image)

    # Obtiene la secuencia principal de la diapositiva.
    sequence = pres.slides[0].timeline.main_sequence

    # Añade el efecto de animación Volar desde la izquierda al marco de imagen
    effect = sequence.add_effect(picFrame, slides.animation.EffectType.FLY,  
        slides.animation.EffectSubtype.LEFT, 
        slides.animation.EffectTriggerType.ON_CLICK)

    # Guarda el archivo PPTX en disco
    pres.save("AnimImage_out.pptx", slides.export.SaveFormat.PPTX)
```


## **Aplicar animación a Shape**

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/). 
2. Obtén la referencia de una diapositiva mediante su índice. 
3. Añade un `rectangle` [IAutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/iautoshape/). 
4. Añade un `Bevel` [IAutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/iautoshape/) (cuando se hace clic en este objeto, se reproduce la animación). 
5. Crea una secuencia de efectos en la forma bevel. 
6. Crea un `UserPath` personalizado. 
7. Añade comandos para mover al `UserPath`. 
8. Guarda la presentación en disco como un archivo PPTX. 

Este código Python muestra cómo aplicar el efecto `PathFootball` (ruta de fútbol) a una forma:
```python
import aspose.slides.animation as anim
import aspose.slides as slides
import aspose.pydrawing as draw

# Instancia una clase Presentation que representa un archivo PPTX
with slides.Presentation() as pres:
    sld = pres.slides[0]

    # Crea el efecto PathFootball para una forma existente desde cero.
    ashp = sld.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 150, 150, 250, 25)

    ashp.add_text_frame("Animated TextBox")

    # Agrega el efecto de animación PathFootBall.
    pres.slides[0].timeline.main_sequence.add_effect(ashp, 
        anim.EffectType.PATH_FOOTBALL,
        anim.EffectSubtype.NONE, 
        anim.EffectTriggerType.AFTER_PREVIOUS)

    # Crea algún tipo de "botón".
    shapeTrigger = pres.slides[0].shapes.add_auto_shape(slides.ShapeType.BEVEL, 10, 10, 20, 20)

    # Crea una secuencia de efectos para el botón.
    seqInter = pres.slides[0].timeline.interactive_sequences.add(shapeTrigger)

    # Crea una ruta de usuario personalizada. Nuestro objeto se moverá solo después de que se haga clic en el botón.
    fxUserPath = seqInter.add_effect(ashp, 
        anim.EffectType.PATH_USER, 
        anim.EffectSubtype.NONE, 
        anim.EffectTriggerType.ON_CLICK)

    # Agrega comandos para mover ya que la ruta creada está vacía.
    motionBhv = fxUserPath.behaviors[0]

    pts = [draw.PointF(0.076, 0.59)]
    motionBhv.path.add(anim.MotionCommandPathType.LINE_TO, pts, anim.MotionPathPointsType.AUTO, True)
    pts = [draw.PointF(-0.076, -0.59)]
    motionBhv.path.add(anim.MotionCommandPathType.LINE_TO, pts, anim.MotionPathPointsType.AUTO, False)
    motionBhv.path.add(anim.MotionCommandPathType.END, None, anim.MotionPathPointsType.AUTO, False)

    # Escribe el archivo PPTX en disco
    pres.save("AnimExample_out.pptx", slides.export.SaveFormat.PPTX)
```


## **Obtener los efectos de animación aplicados a Shape**

Los siguientes ejemplos muestran cómo usar el método `get_effects_by_shape` de la clase [Sequence](https://reference.aspose.com/slides/python-net/aspose.slides.animation/sequence/) para obtener todos los efectos de animación aplicados a una forma. 

**Ejemplo 1: Obtener efectos de animación aplicados a una forma en una diapositiva normal**

Anteriormente, aprendiste cómo añadir efectos de animación a formas en presentaciones de PowerPoint. El siguiente código de ejemplo muestra cómo obtener los efectos aplicados a la primera forma en la primera diapositiva normal de la presentación `AnimExample_out.pptx`.
```python
import aspose.slides as slides

with slides.Presentation("AnimExample_out.pptx") as presentation:
    first_slide = presentation.slides[0]

    # Obtiene la secuencia principal de animación de la diapositiva.
    sequence = first_slide.timeline.main_sequence

    # Obtiene la primera forma en la primera diapositiva.
    shape = first_slide.shapes[0]

    # Obtiene los efectos de animación aplicados a la forma.
    shape_effects = sequence.get_effects_by_shape(shape)

    if len(shape_effects) > 0:
        print("The shape", shape.name, "has", len(shape_effects), "animation effects.")
```


**Ejemplo 2: Obtener todos los efectos de animación, incluidos los heredados de los marcadores de posición**

Si una forma en una diapositiva normal tiene marcadores de posición que están en la diapositiva de diseño y/o en la diapositiva maestra, y se han añadido efectos de animación a esos marcadores de posición, entonces todos los efectos de la forma se reproducirán durante la presentación, incluidos los heredados de los marcadores de posición. 

Supongamos que tenemos un archivo de presentación PowerPoint `sample.pptx` con una diapositiva que contiene solo una forma de pie de página con el texto "Made with Aspose.Slides" y al que se le ha aplicado el efecto **Random Bars**. 
![Animación de forma de diapositiva](slide-shape-animation.png)

Supongamos también que el efecto **Split** se aplica al marcador de posición de pie de página en la diapositiva **layout**. 
![Animación de forma del diseño](layout-shape-animation.png)

Y finalmente, el efecto **Fly In** se aplica al marcador de posición de pie de página en la diapositiva **master**. 
![Animación de forma maestra](master-shape-animation.png)

El siguiente código de ejemplo muestra cómo usar el método `get_base_placeholder` de la clase [Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/) para acceder a los marcadores de posición de la forma y obtener los efectos de animación aplicados a la forma de pie de página, incluidos los heredados de los marcadores de posición ubicados en las diapositivas de diseño y maestra.
```py
import aspose.slides as slides

def print_effects(effects):
    for effect in effects:
        print(effect.type.name, effect.subtype.name)
```

```py
with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    # Obtiene los efectos de animación de la forma en la diapositiva normal.
    shape = slide.shapes[0]
    shape_effects = slide.timeline.main_sequence.get_effects_by_shape(shape)

    # Obtiene los efectos de animación del marcador de posición en la diapositiva de diseño.
    layout_shape = shape.get_base_placeholder()
    layout_shape_effects = slide.layout_slide.timeline.main_sequence.get_effects_by_shape(layout_shape)

    # Obtiene los efectos de animación del marcador de posición en la diapositiva maestra.
    master_shape = layout_shape.get_base_placeholder()
    master_shape_effects = slide.layout_slide.master_slide.timeline.main_sequence.get_effects_by_shape(master_shape)

    print("Main sequence of shape effects:")
    print_effects(master_shape_effects)
    print_effects(layout_shape_effects)
    print_effects(shape_effects)
```


Salida:
```text
Main sequence of shape effects:
FLY BOTTOM
SPLIT VERTICAL_IN
RANDOM_BARS HORIZONTAL
```


## **Cambiar propiedades de tiempo del efecto de animación**

Aspose.Slides para Python a través de .NET permite cambiar las propiedades de tiempo de un efecto de animación. 

Este es el panel de tiempo de animación en Microsoft PowerPoint:
![Panel de tiempo de animación](shape-animation.png)

Estas son las correspondencias entre el tiempo de PowerPoint y las propiedades `Effect.Timing`:
- La lista desplegable **Start** del tiempo de PowerPoint coincide con la propiedad [Effect.Timing.TriggerType](https://reference.aspose.com/slides/python-net/aspose.slides.animation/effecttriggertype/). 
- El **Duration** del tiempo de PowerPoint coincide con la propiedad `Effect.Timing.Duration`. La duración de una animación (en segundos) es el tiempo total que tarda la animación en completar un ciclo. 
- El **Delay** del tiempo de PowerPoint coincide con la propiedad `Effect.Timing.TriggerDelayTime`. 

Así es como cambias las propiedades de tiempo del efecto:
1. [Apply](#apply-animation-to-shape) o recupera el efecto de animación. 
2. Establece nuevos valores para las propiedades `Effect.Timing` que necesites. 
3. Guarda el archivo PPTX modificado. 

Este código Python demuestra la operación:
```python
import aspose.slides as slides

# Instancia una clase de presentación que representa un archivo de presentación.
with slides.Presentation("AnimExample_out.pptx") as pres:
    # Obtiene la secuencia principal de la diapositiva.
    sequence = pres.slides[0].timeline.main_sequence

    # Obtiene el primer efecto de la secuencia principal.
    effect = sequence[0]

    # Cambia el TriggerType del efecto para iniciar al hacer clic
    effect.timing.trigger_type = slides.animation.EffectTriggerType.ON_CLICK

    # Cambia la duración del efecto
    effect.timing.duration = 3

    # Cambia el TriggerDelayTime del efecto
    effect.timing.trigger_delay_time = 0.5

    # Guarda el archivo PPTX en disco
    pres.save("AnimExample_changed.pptx", slides.export.SaveFormat.PPTX)
```


## **Sonido del efecto de animación**

Aspose.Slides proporciona estas propiedades para permitir trabajar con sonidos en efectos de animación: 
- `sound`
- `stop_previous_sound`

### **Agregar sonido al efecto de animación**

Este código Python muestra cómo añadir un sonido al efecto de animación y detenerlo cuando comienza el siguiente efecto:
```python
import aspose.slides as slides

with Presentation("AnimExample_out.pptx") as pres:
    # Añade audio a la colección de audio de la presentación
    effect_sound = pres.audios.add_audio(open("sampleaudio.wav", "rb").read())

    first_slide = pres.slides[0]

    # Obtiene la secuencia principal de la diapositiva.
    sequence = first_slide.timeline.main_sequence

    # Obtiene el primer efecto de la secuencia principal
    first_effect = sequence[0]

    # Comprueba si el efecto no tiene sonido
    if not first_effect.stop_previous_sound and first_effect.sound is None:
        # Añade sonido al primer efecto
        first_effect.sound = effect_sound

    # Obtiene la primera secuencia interactiva de la diapositiva.
    interactive_sequence = first_slide.timeline.interactive_sequences[0]

    # Establece la bandera "Stop previous sound" del efecto
    interactive_sequence[0].stop_previous_sound = True

    # Escribe el archivo PPTX en disco
    pres.save("AnimExample_Sound_out.pptx", slides.export.SaveFormat.PPTX)
```


### **Extraer sonido del efecto de animación**

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/). 
2. Obtén la referencia de una diapositiva mediante su índice. 
3. Obtén la secuencia principal de efectos. 
4. Extrae el `sound` incrustado en cada efecto de animación. 

Este código Python muestra cómo extraer el sonido incrustado en un efecto de animación:
```python
import aspose.slides as slides

# Instancia una clase de presentación que representa un archivo de presentación.
with slides.Presentation("EffectSound.pptx") as presentation:
    slide = presentation.slides[0]

    # Obtiene la secuencia principal de la diapositiva.
    sequence = slide.timeline.main_sequence

    for effect in sequence:
        if effect.sound is None:
            continue

        # Extrae el sonido del efecto en una matriz de bytes
        audio = effect.sound.binary_data
```


## **Después de la animación**

Aspose.Slides para .NET permite cambiar la propiedad After animation de un efecto de animación. 

Este es el panel de efecto de animación después y el menú ampliado en Microsoft PowerPoint:
![Panel de efecto de animación después](shape-after-animation.png)

La lista desplegable **After animation** del efecto PowerPoint coincide con estas propiedades:
- La propiedad `after_animation_type` que describe el tipo de After animation:
  * PowerPoint **More Colors** coincide con el tipo [COLOR](https://reference.aspose.com/slides/python-net/aspose.slides.animation/afteranimationtype/);
  * PowerPoint **Don't Dim** coincide con el tipo [DO_NOT_DIM](https://reference.aspose.com/slides/python-net/aspose.slides.animation/afteranimationtype/) (tipo predeterminado);
  * PowerPoint **Hide After Animation** coincide con el tipo [HIDE_AFTER_ANIMATION](https://reference.aspose.com/slides/python-net/aspose.slides.animation/afteranimationtype/);
  * PowerPoint **Hide on Next Mouse Click** coincide con el tipo [HIDE_ON_NEXT_MOUSE_CLICK](https://reference.aspose.com/slides/python-net/aspose.slides.animation/afteranimationtype/);
- La propiedad `after_animation_color` que define un formato de color para la animación posterior. Esta propiedad funciona en conjunto con el tipo [COLOR](https://reference.aspose.com/slides/python-net/aspose.slides.animation/afteranimationtype/). Si cambias el tipo a otro, el color de la animación posterior se borrará. 

Este código Python muestra cómo cambiar un efecto de animación posterior:
```python
import aspose.slides as slides

# Instancia una clase de presentación que representa un archivo de presentación
with slides.Presentation("AnimImage_out.pptx") as pres:
    first_slide = pres.slides[0]

    # Obtiene el primer efecto de la secuencia principal
    first_effect = first_slide.timeline.main_sequence[0]

    # Cambia el tipo de animación posterior a Color
    first_effect.after_animation_type = AfterAnimationType.COLOR

    # Establece el color de atenuación de la animación posterior
    first_effect.after_animation_color.color = Color.alice_blue

    # Guarda el archivo PPTX en disco
    pres.save("AnimImage_AfterAnimation.pptx", slides.export.SaveFormat.PPTX)
```


## **Animar texto**

Aspose.Slides proporciona estas propiedades para trabajar con el bloque *Animate text* de un efecto de animación:
- `animate_text_type` que describe el tipo de animación de texto del efecto. El texto de la forma puede animarse:
  * Todo a la vez ([ALL_AT_ONCE](https://reference.aspose.com/slides/python-net/aspose.slides.animation/animatetexttype/) tipo)
  * Por palabra ([BY_WORD](https://reference.aspose.com/slides/python-net/aspose.slides.animation/animatetexttype/) tipo)
  * Por letra ([BY_LETTER](https://reference.aspose.com/slides/python-net/aspose.slides.animation/animatetexttype/) tipo)
- `delay_between_text_parts` establece un retraso entre las partes del texto animado (palabras o letras). Un valor positivo especifica el porcentaje de duración del efecto. Un valor negativo especifica el retraso en segundos. 

Así es como puedes cambiar las propiedades *Animate text* del efecto:
1. [Apply](#apply-animation-to-shape) o recupera el efecto de animación. 
2. Establece la propiedad `build_type` al valor [AS_ONE_OBJECT](https://reference.aspose.com/slides/python-net/aspose.slides.animation/buildtype/) para desactivar el modo de animación *By Paragraphs*. 
3. Establece nuevos valores para las propiedades `animate_text_type` y `delay_between_text_parts`. 
4. Guarda el archivo PPTX modificado. 

Este código Python demuestra la operación:
```python
import aspose.slides as slides

with slides.Presentation("AnimTextBox_out.pptx") as pres:
    first_slide = pres.slides[0]

    # Obtiene el primer efecto de la secuencia principal
    first_effect = first_slide.timeline.main_sequence[0]

    # Cambia el tipo de animación de texto del efecto a "Como un solo objeto"
    first_effect.text_animation.build_type = slides.animation.BuildType.AS_ONE_OBJECT

    # Cambia el tipo de animación del texto del efecto a "Por palabra"
    first_effect.animate_text_type = slides.animation.AnimateTextType.BY_WORD

    # Establece el retraso entre palabras al 20% de la duración del efecto
    first_effect.delay_between_text_parts = 20

    # Guarda el archivo PPTX en disco
    pres.save("AnimTextBox_AnimateText.pptx", slides.export.SaveFormat.PPTX)

```


## **Preguntas frecuentes**

**¿Cómo puedo asegurar que las animaciones se conserven al publicar la presentación en la web?**

[Exportar a HTML5](/slides/es/python-net/export-to-html5/) y habilitar las [opciones](https://reference.aspose.com/slides/python-net/aspose.slides.export/html5options/) responsables de las animaciones de [forma](https://reference.aspose.com/slides/python-net/aspose.slides.export/html5options/animate_shapes/) y [transición](https://reference.aspose.com/slides/python-net/aspose.slides.export/html5options/animate_transitions/). El HTML plano no reproduce animaciones de diapositivas, mientras que HTML5 sí. 

**¿Cómo afecta cambiar el orden z (orden de capas) de las formas a la animación?**

El orden de animación y el orden de dibujo son independientes: un efecto controla el momento y el tipo de aparición/desaparición, mientras que el [z-order](https://reference.aspose.com/slides/python-net/aspose.slides/shape/z_order_position/) determina qué cubre a qué. El resultado visible se define por su combinación. (Este es el comportamiento general de PowerPoint; el modelo de efectos y formas de Aspose.Slides sigue la misma lógica.) 

**¿Existen limitaciones al convertir animaciones a video para ciertos efectos?**

En general, [las animaciones son compatibles](/slides/es/python-net/convert-powerpoint-to-video/), pero en casos raros o con efectos específicos pueden renderizarse de manera diferente. Se recomienda probar con los efectos que uses y con la versión de la biblioteca.