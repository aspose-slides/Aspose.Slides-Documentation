---
title: Animación de Formas
type: docs
weight: 60
url: /es/python-net/shape-animation/
keywords: "animación de PowerPoint, presentación de PowerPoint, Python, Aspose.Slides para Python via .NET"
description: "Crear animación de PowerPoint en Python"
---

Las animaciones son efectos visuales que se pueden aplicar a textos, imágenes, formas o [gráficos](/slides/es/python-net/animated-charts/). Dan vida a las presentaciones o sus componentes. 

### **¿Por Qué Usar Animaciones en Presentaciones?**

Usando animaciones, puedes 

* controlar el flujo de información
* enfatizar puntos importantes
* aumentar el interés o la participación entre tu audiencia
* facilitar la lectura o asimilación o procesamiento del contenido
* atraer la atención de tus lectores o espectadores a partes importantes de una presentación

PowerPoint ofrece muchas opciones y herramientas para animaciones y efectos de animación en las categorías de **entrada**, **salida**, **énfasis** y **trayectorias de movimiento**.

### **Animaciones en Aspose.Slides**

* Aspose.Slides proporciona las clases y tipos que necesitas para trabajar con animaciones en el espacio de nombres [Aspose.Slides.Animation](https://reference.aspose.com/slides/python-net/aspose.slides.animation/),
* Aspose.Slides proporciona más de **150 efectos de animación** en la enumeración [EffectType](https://reference.aspose.com/slides/python-net/aspose.slides.animation/effecttype/). Estos efectos son esencialmente los mismos (o equivalentes) efectos utilizados en PowerPoint.

## **Aplicar Animación a TextBox**

Aspose.Slides para Python via .NET te permite aplicar animación al texto en una forma. 

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Obtén la referencia de una diapositiva a través de su índice.
3. Agrega un `rectángulo` [IAutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/iautoshape/). 
4. Agrega texto a `IAutoShape.TextFrame`.
5. Obtén una secuencia principal de efectos.
6. Agrega un efecto de animación a [IAutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/iautoshape/). 
7. Establece la propiedad `TextAnimation.BuildType` al valor de la enumeración `BuildType`.
8. Escribe la presentación en disco como un archivo PPTX.

Este código Python te muestra cómo aplicar el efecto `Fade` a AutoShape y establecer la animación de texto al valor de *Por 1er Nivel de Párrafos*:

```python
import aspose.slides as slides

# Instancia una clase de presentación que representa un archivo de presentación.
with slides.Presentation() as pres:
    sld = pres.slides[0]
    
    # Agrega un nuevo AutoShape con texto
    autoShape = sld.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 150, 100)

    textFrame = autoShape.text_frame
    textFrame.text = "Primer párrafo \nSegundo párrafo \n Tercer párrafo"

    # Obtiene la secuencia principal de la diapositiva.
    sequence = sld.timeline.main_sequence

    # Agrega el efecto de animación Fade a la forma
    effect = sequence.add_effect(autoShape, slides.animation.EffectType.FADE, slides.animation.EffectSubtype.NONE, slides.animation.EffectTriggerType.ON_CLICK)

    # Anima el texto de la forma por párrafos de 1er nivel
    effect.text_animation.build_type = slides.animation.BuildType.BY_LEVEL_PARAGRAPHS1

    # Guarda el archivo PPTX en disco
    pres.save("AnimText_out.pptx", slides.export.SaveFormat.PPTX)
```

{{%  alert color="primary"  %}} 

Además de aplicar animaciones al texto, también puedes aplicar animaciones a un solo [Párrafo](https://reference.aspose.com/slides/python-net/aspose.slides/iparagraph/). Consulta [**Texto Animado**](/slides/es/python-net/animated-text/).

{{% /alert %}} 

## **Aplicar Animación a PictureFrame**

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Obtén la referencia de una diapositiva a través de su índice.
3. Agrega o obtiene un [PictureFrame](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframe/) en la diapositiva. 
4. Obtén la secuencia principal de efectos.
5. Agrega un efecto de animación a [PictureFrame](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframe/).
6. Escribe la presentación en disco como un archivo PPTX.

Este código Python te muestra cómo aplicar el efecto `Fly` a un marco de imagen:

```python
import aspose.slides as slides
import aspose.pydrawing as draw


# Instancia una clase de presentación que representa un archivo de presentación.
with slides.Presentation() as pres:
    # Carga la imagen que se añadirá a la colección de imágenes de la presentación
    img = draw.Bitmap("aspose-logo.jpg")
    image = pres.images.add_image(img)

    # Agrega un marco de imagen a la diapositiva
    picFrame = pres.slides[0].shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 50, 50, 100, 100, image)

    # Obtiene la secuencia principal de la diapositiva.
    sequence = pres.slides[0].timeline.main_sequence

    # Agrega el efecto de animación Fly from Left al marco de imagen
    effect = sequence.add_effect(picFrame, slides.animation.EffectType.FLY,  
        slides.animation.EffectSubtype.LEFT, 
        slides.animation.EffectTriggerType.ON_CLICK)

    # Guarda el archivo PPTX en disco
    pres.save("AnimImage_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Aplicar Animación a Shape**

1. Crea una instancia de la [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) clase.
2. Obtén la referencia de una diapositiva a través de su índice.
3. Agrega un `rectángulo` [IAutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/iautoshape/). 
4. Agrega un `Bevel` [IAutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/iautoshape/) (cuando este objeto sea clicado, la animación se reproducirá).
5. Crea una secuencia de efectos en la forma bevel.
6. Crea un `UserPath` personalizado.
7. Agrega comandos para mover al `UserPath`.
8. Escribe la presentación en disco como un archivo PPTX.

Este código Python te muestra cómo aplicar el efecto `PathFootball` (camino de fútbol) a una forma:

```python
import aspose.slides.animation as anim
import aspose.slides as slides
import aspose.pydrawing as draw

# Instancia una clase de presentación que representa un archivo PPTX
with slides.Presentation() as pres:
    sld = pres.slides[0]

    # Crea un efecto PathFootball para una forma existente desde cero.
    ashp = sld.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 150, 150, 250, 25)

    ashp.add_text_frame("Texto Animado")

    # Agrega el efecto de animación PathFootBall.
    pres.slides[0].timeline.main_sequence.add_effect(ashp, 
        anim.EffectType.PATH_FOOTBALL,
        anim.EffectSubtype.NONE, 
        anim.EffectTriggerType.AFTER_PREVIOUS)

    # Crea algún tipo de "botón".
    shapeTrigger = pres.slides[0].shapes.add_auto_shape(slides.ShapeType.BEVEL, 10, 10, 20, 20)

    # Crea una secuencia de efectos para el botón.
    seqInter = pres.slides[0].timeline.interactive_sequences.add(shapeTrigger)

    # Crea un camino de usuario personalizado. Nuestro objeto se moverá solo después de que se haga clic en el botón.
    fxUserPath = seqInter.add_effect(ashp, 
        anim.EffectType.PATH_USER, 
        anim.EffectSubtype.NONE, 
        anim.EffectTriggerType.ON_CLICK)

    # Agrega comandos para moverse ya que el camino creado está vacío.
    motionBhv = fxUserPath.behaviors[0]

    pts = [draw.PointF(0.076, 0.59)]
    motionBhv.path.add(anim.MotionCommandPathType.LINE_TO, pts, anim.MotionPathPointsType.AUTO, True)
    pts = [draw.PointF(-0.076, -0.59)]
    motionBhv.path.add(anim.MotionCommandPathType.LINE_TO, pts, anim.MotionPathPointsType.AUTO, False)
    motionBhv.path.add(anim.MotionCommandPathType.END, None, anim.MotionPathPointsType.AUTO, False)

    # Escribe el archivo PPTX en disco
    pres.save("AnimExample_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Obtener los Efectos de Animación Aplicados a una Forma**

Puedes decidir averiguar todos los efectos de animación aplicados a una sola forma. 

Este código Python te muestra cómo obtener todos los efectos aplicados a una forma específica:

```python
import aspose.slides as slides

# Instancia una clase de presentación que representa un archivo de presentación.
with slides.Presentation("AnimExample_out.pptx") as pres:
    firstSlide = pres.slides[0]

    # Obtiene la secuencia principal de la diapositiva.
    sequence = firstSlide.timeline.main_sequence

    # Obtiene la primera forma en la diapositiva.
    shape = firstSlide.shapes[0]

    # Obtiene todos los efectos de animación aplicados a la forma.
    shapeEffects = sequence.get_effects_by_shape(shape)

    if len(shapeEffects) > 0:
        print("La forma " + shape.name + " tiene " + str(len(shapeEffects)) + " efectos de animación.")
```

## **Cambiar Propiedades de Tiempo del Efecto de Animación**

Aspose.Slides para Python via .NET te permite cambiar las propiedades de Tiempo de un efecto de animación.

Este es el panel de Tiempo de Animación en Microsoft PowerPoint:

![example1_image](shape-animation.png)

Estas son las correspondencias entre el Tiempo de PowerPoint y las propiedades `Effect.Timing`:

- La lista desplegable **Inicio** de PowerPoint coincide con la propiedad [Effect.Timing.TriggerType](https://reference.aspose.com/slides/python-net/aspose.slides.animation/effecttriggertype/). 
- **Duración** de PowerPoint coincide con la propiedad `Effect.Timing.Duration`. La duración de una animación (en segundos) es el tiempo total que tarda la animación en completar un ciclo. 
- **Retraso** de PowerPoint coincide con la propiedad `Effect.Timing.TriggerDelayTime`. 

Así es como puedes cambiar las propiedades de Tiempo del Efecto:

1. [Aplica](#apply-animation-to-shape) o obtén el efecto de animación.
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

    # Cambia el TriggerType del efecto para que comience al hacer clic
    effect.timing.trigger_type = slides.animation.EffectTriggerType.ON_CLICK

    # Cambia la duración del efecto
    effect.timing.duration = 3

    # Cambia el TriggerDelayTime del efecto
    effect.timing.trigger_delay_time = 0.5

    # Guarda el archivo PPTX en disco
    pres.save("AnimExample_changed.pptx", slides.export.SaveFormat.PPTX)
```

## **Sonido del Efecto de Animación**

Aspose.Slides proporciona estas propiedades para permitirte trabajar con sonidos en efectos de animación: 

- `sound`
- `stop_previous_sound`

### **Agregar Sonido al Efecto de Animación**

Este código Python te muestra cómo agregar un sonido al efecto de animación y detenerlo cuando comience el siguiente efecto:

```python
import aspose.slides as slides

with Presentation("AnimExample_out.pptx") as pres:
    # Agrega audio a la colección de audio de la presentación
    effect_sound = pres.audios.add_audio(open("sampleaudio.wav", "rb").read())

    first_slide = pres.slides[0]

    # Obtiene la secuencia principal de la diapositiva.
    sequence = first_slide.timeline.main_sequence

    # Obtiene el primer efecto de la secuencia principal
    first_effect = sequence[0]

    # Verifica el efecto para "Sin Sonido"
    if not first_effect.stop_previous_sound and first_effect.sound is None:
        # Agrega sonido para el primer efecto
        first_effect.sound = effect_sound

    # Obtiene la primera secuencia interactiva de la diapositiva.
    interactive_sequence = first_slide.timeline.interactive_sequences[0]

    # Establece la bandera "Detener sonido previo"
    interactive_sequence[0].stop_previous_sound = True

    # Escribe el archivo PPTX en disco
    pres.save("AnimExample_Sound_out.pptx", slides.export.SaveFormat.PPTX)
```

### **Extraer Sonido del Efecto de Animación**

1. Crea una instancia de la [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) clase.
2. Obtén la referencia de una diapositiva a través de su índice. 
3. Obtén la secuencia principal de efectos. 
4. Extrae el `sound` incrustado en cada efecto de animación. 

Este código Python te muestra cómo extraer el sonido incrustado en un efecto de animación:

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

        # Extrae el sonido del efecto en un array de bytes
        audio = effect.sound.binary_data
```

## **Después de la Animación**

Aspose.Slides para .NET te permite cambiar la propiedad Después de la animación de un efecto de animación.

Este es el panel del Efecto de Animación y el menú extendido en Microsoft PowerPoint:

![example1_image](shape-after-animation.png)

La lista desplegable **Después de la animación** de PowerPoint coincide con estas propiedades: 

- Propiedad `after_animation_type` que describe el tipo de animación después:
  * **Más Colores** de PowerPoint coincide con el tipo [COLOR](https://reference.aspose.com/slides/python-net/aspose.slides.animation/afteranimationtype/);
  * El elemento **No Dejar de Brillar** de PowerPoint coincide con el tipo [DO_NOT_DIM](https://reference.aspose.com/slides/python-net/aspose.slides.animation/afteranimationtype/) (tipo de animación después predeterminado);
  * El elemento **Ocultar Después de la Animación** de PowerPoint coincide con el tipo [HIDE_AFTER_ANIMATION](https://reference.aspose.com/slides/python-net/aspose.slides.animation/afteranimationtype/) ;
  * El elemento **Ocultar en el Siguiente Clic del Ratón** de PowerPoint coincide con el tipo [HIDE_ON_NEXT_MOUSE_CLICK](https://reference.aspose.com/slides/python-net/aspose.slides.animation/afteranimationtype/);
- Propiedad `after_animation_color` que define un formato de color después de la animación. Esta propiedad funciona en conjunto con el tipo [COLOR](https://reference.aspose.com/slides/python-net/aspose.slides.animation/afteranimationtype/). Si cambias el tipo a otro, el color de la animación después se borrará.

Este código Python te muestra cómo cambiar un efecto de animación después:

```python
import aspose.slides as slides

# Instancia una clase de presentación que representa un archivo de presentación
with slides.Presentation("AnimImage_out.pptx") as pres:
    first_slide = pres.slides[0]

    # Obtiene el primer efecto de la secuencia principal
    first_effect = first_slide.timeline.main_sequence[0]

    # Cambia el tipo de animación después a Color
    first_effect.after_animation_type = AfterAnimationType.COLOR

    # Establece el color de atenuación después de la animación
    first_effect.after_animation_color.color = Color.alice_blue

    # Escribe el archivo PPTX en disco
    pres.save("AnimImage_AfterAnimation.pptx", slides.export.SaveFormat.PPTX)
```

## **Animar Texto**

Aspose.Slides proporciona estas propiedades para permitirte trabajar con el bloque de *Animar texto* de un efecto de animación:

- `animate_text_type` que describe un tipo de animación de texto del efecto. El texto de la forma se puede animar:
  - Todo a la vez ([ALL_AT_ONCE](https://reference.aspose.com/slides/python-net/aspose.slides.animation/animatetexttype/) tipo)
  - Por palabra ([BY_WORD](https://reference.aspose.com/slides/python-net/aspose.slides.animation/animatetexttype/) tipo)
  - Por letra ([BY_LETTER](https://reference.aspose.com/slides/python-net/aspose.slides.animation/animatetexttype/) tipo)
- `delay_between_text_parts` establece un retraso entre las partes de texto animadas (palabras o letras). Un valor positivo especifica el porcentaje de duración del efecto. Un valor negativo especifica el retraso en segundos.

Así es como puedes cambiar las propiedades de Efecto Animar texto:

1. [Aplica](#apply-animation-to-shape) o obtén el efecto de animación.
2. Establece la propiedad `build_type` al valor [AS_ONE_OBJECT](https://reference.aspose.com/slides/python-net/aspose.slides.animation/buildtype/) para desactivar el modo de animación *Por Párrafos*.
3. Establece nuevos valores para las propiedades `animate_text_type` y `delay_between_text_parts`.
4. Guarda el archivo PPTX modificado.

Este código Python demuestra la operación:

```python
import aspose.slides as slides

with slides.Presentation("AnimTextBox_out.pptx") as pres:
    first_slide = pres.slides[0]

    # Obtiene el primer efecto de la secuencia principal
    first_effect = first_slide.timeline.main_sequence[0]

    # Cambia el tipo de animación de texto del efecto a "Como Un Solo Objeto"
    first_effect.text_animation.build_type = slides.animation.BuildType.AS_ONE_OBJECT

    # Cambia el tipo de animación de texto del efecto a "Por palabra"
    first_effect.animate_text_type = slides.animation.AnimateTextType.BY_WORD

    # Establece el retraso entre palabras al 20% de la duración del efecto
    first_effect.delay_between_text_parts = 20

    # Escribe el archivo PPTX en disco
    pres.save("AnimTextBox_AnimateText.pptx", slides.export.SaveFormat.PPTX)

```