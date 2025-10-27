---
title: Aplicar animaciones de forma en presentaciones con Python
linktitle: Animación de Forma
type: docs
weight: 60
url: /es/python-net/developer-guide/presentation-content/powerpoint-shapes/shape-animation/
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
- sonido de efecto
- aplicar animación
- PowerPoint
- presentación
- Python
- Aspose.Slides
description: "Descubra cómo crear y personalizar animaciones de forma en presentaciones PowerPoint y OpenDocument con Aspose.Slides para Python vía .NET. ¡Sobresalga!"
---

Las animaciones son efectos visuales que se pueden aplicar a textos, imágenes, formas o [gráficos](/slides/es/python-net/animated-charts/). Dan vida a las presentaciones o a sus componentes.

## **¿Por qué usar animaciones en presentaciones?**

Con las animaciones, puedes  

* controlar el flujo de información  
* enfatizar puntos importantes  
* aumentar el interés o la participación de tu audiencia  
* facilitar la lectura o asimilación del contenido  
* atraer la atención de los lectores o espectadores a partes importantes de la presentación  

PowerPoint ofrece muchas opciones y herramientas para animaciones y efectos de animación en las categorías **entrada**, **salida**, **énfasis** y **trayectorias de movimiento**.

## **Animaciones en Aspose.Slides**

* Aspose.Slides proporciona las clases y tipos que necesitas para trabajar con animaciones bajo el espacio de nombres [Aspose.Slides.Animation](https://reference.aspose.com/slides/python-net/aspose.slides.animation/),  
* Aspose.Slides ofrece más de **150 efectos de animación** bajo la enumeración [EffectType](https://reference.aspose.com/slides/python-net/aspose.slides.animation/effecttype/). Estos efectos son esencialmente los mismos (o equivalentes) que se usan en PowerPoint.

## **Aplicar animación a TextBox**

Aspose.Slides para Python vía .NET permite aplicar animación al texto dentro de una forma.

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).  
2. Obtén la referencia a una diapositiva mediante su índice.  
3. Añade un `rectangle` [IAutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/iautoshape/).  
4. Añade texto a `IAutoShape.TextFrame`.  
5. Obtén la secuencia principal de efectos.  
6. Añade un efecto de animación a [IAutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/iautoshape/).  
7. Establece la propiedad `TextAnimation.BuildType` con el valor de la enumeración `BuildType`.  
8. Guarda la presentación en disco como archivo PPTX.

Este código Python muestra cómo aplicar el efecto `Fade` a AutoShape y establecer la animación de texto al valor *Por párrafos de nivel 1*:

```python
import aspose.slides as slides

# Instantiates a presentation class that represents a presentation file.
with slides.Presentation() as pres:
    sld = pres.slides[0]
    
    # Adds new AutoShape with text
    autoShape = sld.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 150, 100)

    textFrame = autoShape.text_frame
    textFrame.text = "First paragraph \nSecond paragraph \n Third paragraph"

    # Gets the main sequence of the slide.
    sequence = sld.timeline.main_sequence

    # Adds Fade animation effect to shape
    effect = sequence.add_effect(autoShape, slides.animation.EffectType.FADE, slides.animation.EffectSubtype.NONE, slides.animation.EffectTriggerType.ON_CLICK)

    # Animates shape text by 1st level paragraphs
    effect.text_animation.build_type = slides.animation.BuildType.BY_LEVEL_PARAGRAPHS1

    # Save the PPTX file to disk
    pres.save("AnimText_out.pptx", slides.export.SaveFormat.PPTX)
```

{{%  alert color="primary"  %}}  

Además de aplicar animaciones al texto, también puedes aplicar animaciones a un solo [Paragraph](https://reference.aspose.com/slides/python-net/aspose.slides/iparagraph/). Consulta **Texto animado** (/slides/es/python-net/animated-text/).  

{{% /alert %}}  

## **Aplicar animación a PictureFrame**

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).  
2. Obtén la referencia a una diapositiva mediante su índice.  
3. Añade o recupera un [PictureFrame](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframe/) en la diapositiva.  
4. Obtén la secuencia principal de efectos.  
5. Añade un efecto de animación a [PictureFrame](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframe/).  
6. Guarda la presentación en disco como archivo PPTX.

Este código Python muestra cómo aplicar el efecto `Fly` a un picture frame:

```python
import aspose.slides as slides
import aspose.pydrawing as draw


# Instantiates a presentation class that represents a presentation file.
with slides.Presentation() as pres:
    # Load Image to be added in presentaiton image collection
    img = draw.Bitmap("aspose-logo.jpg")
    image = pres.images.add_image(img)

    # Adds picture frame to slide
    picFrame = pres.slides[0].shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 50, 50, 100, 100, image)

    # Gets the main sequence of the slide.
    sequence = pres.slides[0].timeline.main_sequence

    # Adds Fly from Left animation effect to picture frame
    effect = sequence.add_effect(picFrame, slides.animation.EffectType.FLY,  
        slides.animation.EffectSubtype.LEFT, 
        slides.animation.EffectTriggerType.ON_CLICK)

    # Save the PPTX file to disk
    pres.save("AnimImage_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Aplicar animación a Shape**

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).  
2. Obtén la referencia a una diapositiva mediante su índice.  
3. Añade un `rectangle` [IAutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/iautoshape/).  
4. Añade una `Bevel` [IAutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/iautoshape/) (cuando se hace clic en este objeto, se reproduce la animación).  
5. Crea una secuencia de efectos sobre la forma bevel.  
6. Crea una `UserPath` personalizada.  
7. Añade comandos para mover la `UserPath`.  
8. Guarda la presentación en disco como archivo PPTX.

Este código Python muestra cómo aplicar el efecto `PathFootball` a una forma:

```python
import aspose.slides.animation as anim
import aspose.slides as slides
import aspose.pydrawing as draw

# Instantiates a Prseetation class that represents a PPTX file
with slides.Presentation() as pres:
    sld = pres.slides[0]

    # Creates PathFootball effect for existing shape from scratch.
    ashp = sld.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 150, 150, 250, 25)

    ashp.add_text_frame("Animated TextBox")

    # Adds the PathFootBall animation effect.
    pres.slides[0].timeline.main_sequence.add_effect(ashp, 
        anim.EffectType.PATH_FOOTBALL,
        anim.EffectSubtype.NONE, 
        anim.EffectTriggerType.AFTER_PREVIOUS)

    # Creates some kind of "button".
    shapeTrigger = pres.slides[0].shapes.add_auto_shape(slides.ShapeType.BEVEL, 10, 10, 20, 20)

    # Creates a sequence of effects for the button.
    seqInter = pres.slides[0].timeline.interactive_sequences.add(shapeTrigger)

    # Creates a custom user path. Our object will be moved only after the button is clicked.
    fxUserPath = seqInter.add_effect(ashp, 
        anim.EffectType.PATH_USER, 
        anim.EffectSubtype.NONE, 
        anim.EffectTriggerType.ON_CLICK)

    # Adds commands for moving since created path is empty.
    motionBhv = fxUserPath.behaviors[0]

    pts = [draw.PointF(0.076, 0.59)]
    motionBhv.path.add(anim.MotionCommandPathType.LINE_TO, pts, anim.MotionPathPointsType.AUTO, True)
    pts = [draw.PointF(-0.076, -0.59)]
    motionBhv.path.add(anim.MotionCommandPathType.LINE_TO, pts, anim.MotionPathPointsType.AUTO, False)
    motionBhv.path.add(anim.MotionCommandPathType.END, None, anim.MotionPathPointsType.AUTO, False)

    # Writes the PPTX file to disk
    pres.save("AnimExample_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Obtener los efectos de animación aplicados a una Shape**

Los siguientes ejemplos demuestran cómo usar el método `get_effects_by_shape` de la clase [Sequence](https://reference.aspose.com/slides/python-net/aspose.slides.animation/sequence/) para obtener todos los efectos de animación aplicados a una forma.

**Ejemplo 1: Obtener efectos de animación aplicados a una forma en una diapositiva normal**

Anteriormente aprendiste a añadir efectos de animación a formas en presentaciones PowerPoint. El siguiente fragmento muestra cómo obtener los efectos aplicados a la primera forma de la primera diapositiva normal del archivo `AnimExample_out.pptx`.

```python
import aspose.slides as slides

with slides.Presentation("AnimExample_out.pptx") as presentation:
    first_slide = presentation.slides[0]

    # Gets the main animation sequence of the slide.
    sequence = first_slide.timeline.main_sequence

    # Gets the first shape on the first slide.
    shape = first_slide.shapes[0]

    # Gets animation effects applied to the shape.
    shape_effects = sequence.get_effects_by_shape(shape)

    if len(shape_effects) > 0:
        print("The shape", shape.name, "has", len(shape_effects), "animation effects.")
```

**Ejemplo 2: Obtener todos los efectos de animación, incluidos los heredados de marcadores de posición**

Si una forma en una diapositiva normal tiene marcadores de posición que están en la diapositiva de diseño y/o maestra, y a esos marcadores se les han añadido efectos de animación, entonces todos los efectos de la forma se reproducirán durante la presentación, incluidos los heredados.

Supongamos que tenemos un archivo PowerPoint `sample.pptx` con una diapositiva que contiene solo una forma de pie de página con el texto **“Made with Aspose.Slides”** y se le ha aplicado el efecto **Random Bars**.

![Slide shape animation effect](slide-shape-animation.png)

También asumamos que al marcador de posición del pie de página en la diapositiva **de diseño** se le ha aplicado el efecto **Split**.

![Layout shape animation effect](layout-shape-animation.png)

Y, por último, que al marcador de posición del pie de página en la diapositiva **maestra** se le ha aplicado el efecto **Fly In**.

![Master shape animation effect](master-shape-animation.png)

El siguiente código muestra cómo usar el método `get_base_placeholder` de la clase [Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/) para acceder a los marcadores de posición y obtener los efectos de animación aplicados a la forma del pie de página, incluidos los heredados de los marcadores en la diapositiva de diseño y maestra.

```py
import aspose.slides as slides

def print_effects(effects):
    for effect in effects:
        print(effect.type.name, effect.subtype.name)
```
```py
with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    # Get animation effects of the shape on the normal slide.
    shape = slide.shapes[0]
    shape_effects = slide.timeline.main_sequence.get_effects_by_shape(shape)

    # Get animation effects of the placeholder on the layout slide.
    layout_shape = shape.get_base_placeholder()
    layout_shape_effects = slide.layout_slide.timeline.main_sequence.get_effects_by_shape(layout_shape)

    # Get animation effects of the placeholder on the master slide.
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

Aspose.Slides para Python vía .NET permite cambiar las propiedades de temporización de un efecto de animación.

Este es el panel de temporización de animación en Microsoft PowerPoint:

![example1_image](shape-animation.png)

Correspondencias entre la temporización de PowerPoint y las propiedades `Effect.Timing`:

- La lista desplegable **Start** de PowerPoint coincide con la propiedad [Effect.Timing.TriggerType](https://reference.aspose.com/slides/python-net/aspose.slides.animation/effecttriggertype/).  
- **Duration** coincide con la propiedad `Effect.Timing.Duration`. La duración (en segundos) es el tiempo total que tarda la animación en completar un ciclo.  
- **Delay** coincide con la propiedad `Effect.Timing.TriggerDelayTime`.

Así se cambian las propiedades de temporización:

1. [Aplicar](#apply-animation-to-shape) o obtener el efecto de animación.  
2. Establecer nuevos valores para las propiedades `Effect.Timing` requeridas.  
3. Guardar el archivo PPTX modificado.

Ejemplo en Python:

```python
import aspose.slides as slides

# Instantiates a presentation class that represents a presentation file.
with slides.Presentation("AnimExample_out.pptx") as pres:
    # Gets the main sequence of the slide.
    sequence = pres.slides[0].timeline.main_sequence

    # Gets the first effect of main sequence.
    effect = sequence[0]

    # Changes effect TriggerType to start on click
    effect.timing.trigger_type = slides.animation.EffectTriggerType.ON_CLICK

    # Changes effect Duration
    effect.timing.duration = 3

    # Changes effect TriggerDelayTime
    effect.timing.trigger_delay_time = 0.5

    # Saves the PPTX file to disk
    pres.save("AnimExample_changed.pptx", slides.export.SaveFormat.PPTX)
```

## **Sonido del efecto de animación**

Aspose.Slides proporciona estas propiedades para trabajar con sonidos en efectos de animación:

- `sound`  
- `stop_previous_sound`

### **Agregar sonido al efecto de animación**

Este código Python muestra cómo agregar un sonido a un efecto de animación y detenerlo cuando comienza el siguiente efecto:

```python
import aspose.slides as slides

with Presentation("AnimExample_out.pptx") as pres:
    # Adds audio to presentation audio collection
    effect_sound = pres.audios.add_audio(open("sampleaudio.wav", "rb").read())

    first_slide = pres.slides[0]

    # Gets the main sequence of the slide.
    sequence = first_slide.timeline.main_sequence

    # Gets the first effect of the main sequence
    first_effect = sequence[0]

    # Сhecks the effect for "No Sound"
    if not first_effect.stop_previous_sound and first_effect.sound is None:
        # Adds sound for the first effect
        first_effect.sound = effect_sound

    # Gets the first interactive sequence of the slide.
    interactive_sequence = first_slide.timeline.interactive_sequences[0]

    # Sets the effect "Stop previous sound" flag
    interactive_sequence[0].stop_previous_sound = True

    # Writes the PPTX file to disk
    pres.save("AnimExample_Sound_out.pptx", slides.export.SaveFormat.PPTX)
```

### **Extraer sonido del efecto de animación**

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).  
2. Obtén la referencia a una diapositiva mediante su índice.  
3. Obtén la secuencia principal de efectos.  
4. Extrae el `sound` incrustado en cada efecto de animación.

Este código Python muestra cómo extraer el sonido incrustado en un efecto de animación:

```python
import aspose.slides as slides

# Instantiates a presentation class that represents a presentation file.
with slides.Presentation("EffectSound.pptx") as presentation:
    slide = presentation.slides[0]

    # Gets the main sequence of the slide.
    sequence = slide.timeline.main_sequence

    for effect in sequence:
        if effect.sound is None:
            continue

        # Extracts the effect sound in byte array
        audio = effect.sound.binary_data
```

## **After Animation**

Aspose.Slides para .NET permite cambiar la propiedad **After animation** de un efecto de animación.

Este es el panel de efectos de animación y el menú extendido en Microsoft PowerPoint:

![example1_image](shape-after-animation.png)

La lista desplegable **After animation** de PowerPoint coincide con estas propiedades:

- La propiedad `after_animation_type` que describe el tipo de **After animation**:  
  * **More Colors** coincide con el tipo [COLOR](https://reference.aspose.com/slides/python-net/aspose.slides.animation/afteranimationtype/);  
  * **Don't Dim** coincide con el tipo [DO_NOT_DIM](https://reference.aspose.com/slides/python-net/aspose.slides.animation/afteranimationtype/) (tipo predeterminado);  
  * **Hide After Animation** coincide con el tipo [HIDE_AFTER_ANIMATION](https://reference.aspose.com/slides/python-net/aspose.slides.animation/afteranimationtype/);  
  * **Hide on Next Mouse Click** coincide con el tipo [HIDE_ON_NEXT_MOUSE_CLICK](https://reference.aspose.com/slides/python-net/aspose.slides.animation/afteranimationtype/).  
- La propiedad `after_animation_color` que define el formato de color del after animation. Esta propiedad funciona junto con el tipo [COLOR](https://reference.aspose.com/slides/python-net/aspose.slides.animation/afteranimationtype/). Si cambias el tipo a otro, el color de after animation se borrará.

Ejemplo en Python para cambiar un efecto **After animation**:

```python
import aspose.slides as slides

# Instantiates a presentation class that represents a presentation file
with slides.Presentation("AnimImage_out.pptx") as pres:
    first_slide = pres.slides[0]

    # Gets the first effect of the main sequence
    first_effect = first_slide.timeline.main_sequence[0]

    # Changes the after animation type to Color
    first_effect.after_animation_type = AfterAnimationType.COLOR

    # Sets the after animation dim color
    first_effect.after_animation_color.color = Color.alice_blue

    # Writes the PPTX file to disk
    pres.save("AnimImage_AfterAnimation.pptx", slides.export.SaveFormat.PPTX)
```

## **Animar texto**

Aspose.Slides ofrece estas propiedades para trabajar con el bloque *Animate text* de un efecto de animación:

- `animate_text_type` que describe el tipo de animación de texto del efecto. El texto de la forma puede animarse:  
  - Todo de una vez ([ALL_AT_ONCE](https://reference.aspose.com/slides/python-net/aspose.slides.animation/animatetexttype/))  
  - Por palabra ([BY_WORD](https://reference.aspose.com/slides/python-net/aspose.slides.animation/animatetexttype/))  
  - Por letra ([BY_LETTER](https://reference.aspose.com/slides/python-net/aspose.slides.animation/animatetexttype/))  
- `delay_between_text_parts` establece un retardo entre las partes de texto animadas (palabras o letras). Un valor positivo indica el porcentaje de la duración del efecto; un valor negativo indica el retardo en segundos.

Cómo cambiar las propiedades **Animate text** del efecto:

1. [Aplicar](#apply-animation-to-shape) o obtener el efecto de animación.  
2. Establecer la propiedad `build_type` en el valor [AS_ONE_OBJECT](https://reference.aspose.com/slides/python-net/aspose.slides.animation/buildtype/) para desactivar el modo *By Paragraphs*.  
3. Asignar nuevos valores a `animate_text_type` y `delay_between_text_parts`.  
4. Guardar el archivo PPTX modificado.

Ejemplo en Python:

```python
import aspose.slides as slides

with slides.Presentation("AnimTextBox_out.pptx") as pres:
    first_slide = pres.slides[0]

    # Gets the first effect of the main sequence
    first_effect = first_slide.timeline.main_sequence[0]

    # Changes the effect Text animation type to "As One Object"
    first_effect.text_animation.build_type = slides.animation.BuildType.AS_ONE_OBJECT

    # Changes the effect Animate text type to "By word"
    first_effect.animate_text_type = slides.animation.AnimateTextType.BY_WORD

    # Sets the delay between words to 20% of effect duration
    first_effect.delay_between_text_parts = 20

    # Writes the PPTX file to disk
    pres.save("AnimTextBox_AnimateText.pptx", slides.export.SaveFormat.PPTX)

```

## **FAQ**

**¿Cómo puedo asegurar que las animaciones se conserven al publicar la presentación en la web?**

[Exportar a HTML5](/slides/es/python-net/export-to-html5/) y habilitar las [opciones](https://reference.aspose.com/slides/python-net/aspose.slides.export/html5options/) responsables de animar [formas](/slides/es/python-net/animate_shapes/) y [transiciones](/slides/es/python-net/animate_transitions/). El HTML tradicional no reproduce animaciones de diapositivas, mientras que HTML5 sí.

**¿Cómo afecta el cambio del orden Z (orden de capas) de las formas a la animación?**

El orden de animación y el orden de dibujo son independientes: un efecto controla el momento y tipo de aparición/desaparición, mientras que el [z-order](https://reference.aspose.com/slides/python-net/aspose.slides/shape/z_order_position/) determina qué cubre a qué. El resultado visible se define por su combinación. (Este es el comportamiento general de PowerPoint; el modelo de efectos y formas de Aspose.Slides sigue la misma lógica.)

**¿Existen limitaciones al convertir animaciones a video para ciertos efectos?**

En general, [las animaciones son compatibles](/slides/es/python-net/convert-powerpoint-to-video/), pero casos raros o efectos específicos pueden renderizarse de forma distinta. Se recomienda probar con los efectos que uses y con la versión de la biblioteca.