---
title: Aplicar animaciones de forma en presentaciones usando Java
linktitle: Animación de forma
type: docs
weight: 60
url: /es/java/shape-animation/
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
- Java
- Aspose.Slides
description: "Descubra cómo crear y personalizar animaciones de forma en presentaciones de PowerPoint con Aspose.Slides para Java. ¡Destáquese!"
---

Las animaciones son efectos visuales que pueden aplicarse a textos, imágenes, formas o [gráficos](https://docs.aspose.com/slides/java/animated-charts/). Dan vida a las presentaciones o a sus componentes. 

## **¿Por qué usar animaciones en presentaciones?**

Usando animaciones, puedes 

* controlar el flujo de información
* enfatizar puntos importantes
* aumentar el interés o la participación de tu audiencia
* hacer que el contenido sea más fácil de leer, asimilar o procesar
* atraer la atención de los lectores o espectadores a partes importantes de una presentación

PowerPoint ofrece muchas opciones y herramientas para animaciones y efectos de animación en las categorías de **entrada**, **salida**, **énfasis** y **trayectorias de movimiento**. 

## **Animaciones en Aspose.Slides**

* Aspose.Slides proporciona las clases y tipos que necesitas para trabajar con animaciones bajo el espacio de nombres `Aspose.Slides.Animation`,
* Aspose.Slides ofrece más de **150 efectos de animación** bajo la enumeración [EffectType](https://reference.aspose.com/slides/java/com.aspose.slides/effecttype). Estos efectos son esencialmente los mismos (o equivalentes) que se usan en PowerPoint.

## **Aplicar animación a un TextBox**

Aspose.Slides for Java permite aplicar animación al texto en una forma. 

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
2. Obtén una referencia a una diapositiva mediante su índice.
3. Añade un `rectangle` [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape). 
4. Añade texto a [IAutoShape.TextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/IAutoShape#addTextFrame-java.lang.String-).
5. Obtén la secuencia principal de efectos.
6. Añade un efecto de animación a [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape). 
7. Establece la propiedad `TextAnimation.BuildType` al valor de la enumeración `BuildType`.
8. Guarda la presentación en disco como un archivo PPTX.

Este código Java muestra cómo aplicar el efecto `Fade` a AutoShape y establecer la animación de texto al valor *By 1st Level Paragraphs*:
```java
// Instancia una clase de presentación que representa un archivo de presentación.
Presentation pres = new Presentation();
try {
    ISlide sld = pres.getSlides().get_Item(0);

    // Agrega una nueva AutoShape con texto
    IAutoShape autoShape = sld.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 150, 100);

    ITextFrame textFrame = autoShape.getTextFrame();
    textFrame.setText("First paragraph \nSecond paragraph \n Third paragraph");

    // Obtiene la secuencia principal de la diapositiva.
    ISequence sequence = sld.getTimeline().getMainSequence();

    // Agrega el efecto de animación Fade a la forma
    IEffect effect = sequence.addEffect(autoShape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);

    // Anima el texto de la forma por párrafos de primer nivel
    effect.getTextAnimation().setBuildType(BuildType.ByLevelParagraphs1);

    // Guarda el archivo PPTX en disco
    pres.save(path + "AnimText_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


{{%  alert color="primary"  %}} 

Además de aplicar animaciones al texto, también puedes aplicar animaciones a un solo [Paragraph](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraph). Vea [**Texto animado**](/slides/es/java/animated-text/).

{{% /alert %}} 

## **Aplicar animación a un PictureFrame**

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
2. Obtén una referencia a una diapositiva mediante su índice.
3. Añade o obtén un [PictureFrame](https://reference.aspose.com/slides/java/com.aspose.slides/pictureframe) en la diapositiva. 
4. Obtén la secuencia principal de efectos.
5. Añade un efecto de animación a [PictureFrame](https://reference.aspose.com/slides/java/com.aspose.slides/pictureframe).
6. Guarda la presentación en disco como un archivo PPTX.

Este código Java muestra cómo aplicar el efecto `Fly` a un marco de imagen:
```java
// Instancia una clase de presentación que representa un archivo de presentación.
Presentation pres = new Presentation();
try {
    // Carga la imagen que se añadirá a la colección de imágenes de la presentación
    IPPImage picture;
    IImage image = Images.fromFile("aspose-logo.jpg");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }

    // Añade un marco de imagen a la diapositiva
    IPictureFrame picFrame = pres.getSlides().get_Item(0).getShapes().addPictureFrame(ShapeType.Rectangle, 50, 50, 100, 100, picture);

    // Obtiene la secuencia principal de la diapositiva.
    ISequence sequence = pres.getSlides().get_Item(0).getTimeline().getMainSequence();

    // Añade el efecto de animación Fly desde la izquierda al marco de imagen
    IEffect effect = sequence.addEffect(picFrame, EffectType.Fly, EffectSubtype.Left, EffectTriggerType.OnClick);

    // Guarda el archivo PPTX en disco
    pres.save(path + "AnimImage_out.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```


## **Aplicar animación a una forma**

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
2. Obtén una referencia a una diapositiva mediante su índice.
3. Añade un `rectangle` [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape). 
4. Añade un `Bevel` [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape) (cuando se hace clic en este objeto, se reproduce la animación).
5. Crea una secuencia de efectos en la forma de bevel.
6. Crea un `UserPath` personalizado.
7. Añade comandos para mover al `UserPath`.
8. Guarda la presentación en disco como un archivo PPTX.

Este código Java muestra cómo aplicar el efecto `PathFootball` (ruta fútbol) a una forma:
```java
// Instancia una clase Presentation que representa un archivo PPTX.
Presentation pres = new Presentation();
try {
    ISlide sld = pres.getSlides().get_Item(0);

    // Crea el efecto PathFootball para una forma existente desde cero.
    IAutoShape ashp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 150, 150, 250, 25);
    ashp.addTextFrame("Animated TextBox");

    // Añade el efecto de animación PathFootBall
    pres.getSlides().get_Item(0).getTimeline().getMainSequence().addEffect(ashp, EffectType.PathFootball,
            EffectSubtype.None, EffectTriggerType.AfterPrevious);

    // Crea una especie de "botón".
    IShape shapeTrigger = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Bevel, 10, 10, 20, 20);

    // Crea una secuencia de efectos para este botón.
    ISequence seqInter = pres.getSlides().get_Item(0).getTimeline().getInteractiveSequences().add(shapeTrigger);

     // Crea una ruta de usuario personalizada. Nuestro objeto se moverá solo después de que se haga clic en el botón.
    IEffect fxUserPath = seqInter.addEffect(ashp, EffectType.PathUser, EffectSubtype.None, EffectTriggerType.OnClick);

     // Añade comandos para mover ya que la ruta creada está vacía.
    IMotionEffect motionBhv = ((IMotionEffect)fxUserPath.getBehaviors().get_Item(0));

    Point2D.Float[] pts = new Point2D.Float[1];
    pts[0] = new Point2D.Float(0.076f, 0.59f);
    motionBhv.getPath().add(MotionCommandPathType.LineTo, pts, MotionPathPointsType.Auto, true);
    pts[0] = new Point2D.Float(-0.076f, -0.59f);
    motionBhv.getPath().add(MotionCommandPathType.LineTo, pts, MotionPathPointsType.Auto, false);
    motionBhv.getPath().add(MotionCommandPathType.End, null, MotionPathPointsType.Auto, false);

     // Escribe el archivo PPTX en disco
    pres.save("AnimExample_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Obtener los efectos de animación aplicados a una forma**

Los siguientes ejemplos muestran cómo usar el método `getEffectsByShape` de la interfaz [ISequence](https://reference.aspose.com/slides/java/com.aspose.slides/isequence/) para obtener todos los efectos de animación aplicados a una forma.

**Ejemplo 1: Obtener efectos de animación aplicados a una forma en una diapositiva normal**

Anteriormente aprendiste cómo añadir efectos de animación a formas en presentaciones de PowerPoint. El siguiente fragmento de código muestra cómo obtener los efectos aplicados a la primera forma de la primera diapositiva normal en la presentación `AnimExample_out.pptx`.
```java
Presentation presentation = new Presentation("AnimExample_out.pptx");
try {
    ISlide firstSlide = presentation.getSlides().get_Item(0);

    // Obtiene la secuencia principal de animación de la diapositiva.
    ISequence sequence = firstSlide.getTimeline().getMainSequence();

    // Obtiene la primera forma en la primera diapositiva.
    IShape shape = firstSlide.getShapes().get_Item(0);

    // Obtiene los efectos de animación aplicados a la forma.
    IEffect[] shapeEffects = sequence.getEffectsByShape(shape);

    if (shapeEffects.length > 0)
        System.out.println("The shape " + shape.getName() + " has " + shapeEffects.length + " animation effects.");
} finally {
    if (presentation != null) presentation.dispose();
}
```


**Ejemplo 2: Obtener todos los efectos de animación, incluidos los heredados de marcadores de posición**

Si una forma en una diapositiva normal tiene marcadores de posición que están en la diapositiva de diseño y/o maestra, y se han añadido efectos de animación a esos marcadores, entonces todos los efectos de la forma se reproducirán durante la presentación, incluidos los heredados de los marcadores.

Supongamos que tenemos un archivo de presentación PowerPoint `sample.pptx` con una sola diapositiva que contiene solo una forma de pie de página con el texto "Made with Aspose.Slides" y se ha aplicado el efecto **Random Bars** a la forma.

![Efecto de animación de forma de diapositiva](slide-shape-animation.png)

Supongamos también que el efecto **Split** se ha aplicado al marcador de posición del pie de página en la diapositiva **de diseño**.

![Efecto de animación de forma de diseño](layout-shape-animation.png)

Y, finalmente, el efecto **Fly In** se ha aplicado al marcador de posición del pie de página en la diapositiva **maestra**.

![Efecto de animación de forma maestra](master-shape-animation.png)

El siguiente fragmento de código muestra cómo usar el método `getBasePlaceholder` de la interfaz [IShape](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/) para acceder a los marcadores de posición de la forma y obtener los efectos de animación aplicados a la forma de pie de página, incluidos los heredados de los marcadores ubicados en las diapositivas de diseño y maestra.
```java
Presentation presentation = new Presentation("sample.pptx");

ISlide slide = presentation.getSlides().get_Item(0);

// Obtener los efectos de animación de la forma en la diapositiva normal.
IShape shape = slide.getShapes().get_Item(0);
IEffect[] shapeEffects = slide.getTimeline().getMainSequence().getEffectsByShape(shape);

// Obtener los efectos de animación del marcador de posición en la diapositiva de diseño.
IShape layoutShape = shape.getBasePlaceholder();
IEffect[] layoutShapeEffects = slide.getLayoutSlide().getTimeline().getMainSequence().getEffectsByShape(layoutShape);

// Obtener los efectos de animación del marcador de posición en la diapositiva maestra.
IShape masterShape = layoutShape.getBasePlaceholder();
IEffect[] masterShapeEffects = slide.getLayoutSlide().getMasterSlide().getTimeline().getMainSequence().getEffectsByShape(masterShape);

System.out.println("Main sequence of shape effects:");
printEffects(masterShapeEffects);
printEffects(layoutShapeEffects);
printEffects(shapeEffects);

presentation.dispose();
```

```java
static void printEffects(IEffect[] effects)
{
    for (IEffect effect : effects)
    {
        String typeName = EffectType.getName(EffectType.class, effect.getType());
        String subtypeName = EffectSubtype.getName(EffectSubtype.class, effect.getSubtype());

        System.out.println(typeName + " " + subtypeName);
    }
}
```


Salida:
```text
Main sequence of shape effects:
Fly Bottom
Split VerticalIn
RandomBars Horizontal
```


## **Cambiar propiedades de tiempo del efecto de animación**

Aspose.Slides for Java permite cambiar las propiedades de tiempo de un efecto de animación.

Este es el panel de Tiempo de Animación en Microsoft PowerPoint:

![example1_image](shape-animation.png)

Estas son las correspondencias entre el Tiempo de PowerPoint y las propiedades [Effect.Timing](https://reference.aspose.com/slides/java/com.aspose.slides/IEffect#getTiming--) :

- La lista desplegable **Start** de PowerPoint coincide con la propiedad [Effect.Timing.TriggerType](https://reference.aspose.com/slides/java/com.aspose.slides/ITiming#getTriggerType--). 
- **Duration** de PowerPoint coincide con la propiedad [Effect.Timing.Duration](https://reference.aspose.com/slides/java/com.aspose.slides/ITiming#getDuration--). La duración de una animación (en segundos) es el tiempo total que tarda la animación en completar un ciclo. 
- **Delay** de PowerPoint coincide con la propiedad [Effect.Timing.TriggerDelayTime](https://reference.aspose.com/slides/java/com.aspose.slides/ITiming#getTriggerDelayTime--). 

Así se cambian las propiedades de Tiempo del efecto:

1. [Aplica](#apply-animation-to-shape) o obtén el efecto de animación.
2. Establece nuevos valores para las propiedades [Effect.Timing](https://reference.aspose.com/slides/java/com.aspose.slides/IEffect#getTiming--) que necesites. 
3. Guarda el archivo PPTX modificado.

Este código Java demuestra la operación:
```java
// Instancia una clase de presentación que representa un archivo de presentación.
Presentation pres = new Presentation("AnimExample_out.pptx");
try {
    // Obtiene la secuencia principal de la diapositiva.
    ISequence sequence = pres.getSlides().get_Item(0).getTimeline().getMainSequence();

    // Obtiene el primer efecto de la secuencia principal.
    IEffect effect = sequence.get_Item(0);

    // Cambia el TriggerType del efecto para iniciar al hacer clic
    effect.getTiming().setTriggerType(EffectTriggerType.OnClick);

    // Cambia la duración del efecto
    effect.getTiming().setDuration(3f);

    // Cambia el TriggerDelayTime del efecto
    effect.getTiming().setTriggerDelayTime(0.5f);

    // Guarda el archivo PPTX en disco
    pres.save("AnimExample_changed.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Sonido del efecto de animación**

Aspose.Slides proporciona estas propiedades para trabajar con sonidos en efectos de animación: 

- [setSound(IAudio value)](https://reference.aspose.com/slides/java/com.aspose.slides/effect/#setSound-com.aspose.slides.IAudio-) 
- [setStopPreviousSound(boolean value)](https://reference.aspose.com/slides/java/com.aspose.slides/effect/#setStopPreviousSound-boolean-) 

### **Agregar un sonido de efecto de animación**

Este código Java muestra cómo agregar un sonido de efecto de animación y detenerlo cuando comienza el siguiente efecto:
```java
Presentation pres = new Presentation("AnimExample_out.pptx");
try {
    // Agrega audio a la colección de audio de la presentación
    IAudio effectSound = pres.getAudios().addAudio(Files.readAllBytes(Paths.get("sampleaudio.wav")));

    ISlide firstSlide = pres.getSlides().get_Item(0);

    // Obtiene la secuencia principal de la diapositiva.
    ISequence sequence = firstSlide.getTimeline().getMainSequence();

    // Obtiene el primer efecto de la secuencia principal
    IEffect firstEffect = sequence.get_Item(0);

    // Verifica el efecto para "No Sound"
    if (!firstEffect.getStopPreviousSound() && firstEffect.getSound() == null)
    {
        // Agrega sonido al primer efecto
        firstEffect.setSound(effectSound);
    }

    // Obtiene la primera secuencia interactiva de la diapositiva.
    ISequence interactiveSequence = firstSlide.getTimeline().getInteractiveSequences().get_Item(0);

    // Establece la bandera "Stop previous sound" del efecto
    interactiveSequence.get_Item(0).setStopPreviousSound(true);

    // Escribe el archivo PPTX en disco
    pres.save("AnimExample_Sound_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


### **Extraer un sonido de efecto de animación**

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/java/aspose.slides/presentation/).
2. Obtén una referencia a una diapositiva mediante su índice. 
3. Obtén la secuencia principal de efectos. 
4. Extrae el sonido [setSound(IAudio value)](https://reference.aspose.com/slides/java/com.aspose.slides/effect/#setSound-com.aspose.slides.IAudio-) incrustado en cada efecto de animación. 

Este código Java muestra cómo extraer el sonido incrustado en un efecto de animación:
```java
// Instancia una clase de presentación que representa un archivo de presentación.
Presentation presentation = new Presentation("EffectSound.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // Obtiene la secuencia principal de la diapositiva.
    ISequence sequence = slide.getTimeline().getMainSequence();

    for (IEffect effect : sequence)
    {
        if (effect.getSound() == null)
            continue;

        // Extrae el sonido del efecto en un arreglo de bytes
        byte[] audio = effect.getSound().getBinaryData();
    }
} finally {
    if (presentation != null) presentation.dispose();
}
```


## **Después de la animación**

Aspose.Slides for Java permite cambiar la propiedad After animation de un efecto de animación.

Este es el panel de Efecto de Animación y el menú extendido en Microsoft PowerPoint:

![example1_image](shape-after-animation.png)

La lista desplegable **After animation** de PowerPoint coincide con estas propiedades: 

- Propiedad [setAfterAnimationType(int value)](https://reference.aspose.com/slides/java/com.aspose.slides/ieffect/#setAfterAnimationType-int-) que describe el tipo de After animation :
  * **More Colors** de PowerPoint coincide con el tipo [AfterAnimationType.Color](https://reference.aspose.com/slides/java/com.aspose.slides/afteranimationtype/#Color);
  * **Don't Dim** de PowerPoint coincide con el tipo [AfterAnimationType.DoNotDim](https://reference.aspose.com/slides/java/com.aspose.slides/afteranimationtype/#DoNotDim) (tipo predeterminado);
  * **Hide After Animation** de PowerPoint coincide con el tipo [AfterAnimationType.HideAfterAnimation](https://reference.aspose.com/slides/java/com.aspose.slides/afteranimationtype/#HideAfterAnimation);
  * **Hide on Next Mouse Click** de PowerPoint coincide con el tipo [AfterAnimationType.HideOnNextMouseClick](https://reference.aspose.com/slides/java/com.aspose.slides/afteranimationtype/#HideOnNextMouseClick);
- Propiedad [setAfterAnimationColor(IColorFormat value)](https://reference.aspose.com/slides/java/com.aspose.slides/ieffect/#setAfterAnimationColor-com.aspose.slides.IColorFormat-) que define un formato de color After animation. Esta propiedad funciona junto con el tipo [AfterAnimationType.Color](https://reference.aspose.com/slides/java/com.aspose.slides/afteranimationtype/#Color). Si cambias el tipo a otro, el color After animation se borrará.

Este código Java muestra cómo cambiar un efecto After animation:
```java
// Instancia una clase Presentation que representa un archivo de presentación
Presentation pres = new Presentation("AnimImage_out.pptx");
try {
    ISlide firstSlide = pres.getSlides().get_Item(0);

    // Obtiene el primer efecto de la secuencia principal
    IEffect firstEffect = firstSlide.getTimeline().getMainSequence().get_Item(0);

    // Cambia el tipo de animación posterior a Color
    firstEffect.setAfterAnimationType(AfterAnimationType.Color);

    // Establece el color de atenuación de la animación posterior
    firstEffect.getAfterAnimationColor().setColor(Color.BLUE);

    // Guarda el archivo PPTX en disco
    pres.save("AnimImage_AfterAnimation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Animar texto**

Aspose.Slides proporciona estas propiedades para trabajar con el bloque *Animate text* de un efecto de animación:

- [setAnimateTextType(int value)](https://reference.aspose.com/slides/java/com.aspose.slides/ieffect/#setAnimateTextType-int-) que describe el tipo de animación de texto del efecto. El texto de la forma puede animarse:
  - Todo a la vez ([AnimateTextType.AllAtOnce](https://reference.aspose.com/slides/java/com.aspose.slides/animatetexttype/#AllAtOnce))
  - Por palabra ([AnimateTextType.ByWord](https://reference.aspose.com/slides/java/com.aspose.slides/animatetexttype/#ByWord))
  - Por letra ([AnimateTextType.ByLetter](https://reference.aspose.com/slides/java/com.aspose.slides/animatetexttype/#ByLetter))
- [setDelayBetweenTextParts(float value)](https://reference.aspose.com/slides/java/com.aspose.slides/ieffect/#setDelayBetweenTextParts-float-) establece un retraso entre las partes de texto animadas (palabras o letras). Un valor positivo especifica el porcentaje de duración del efecto. Un valor negativo especifica el retraso en segundos.

Así puedes cambiar las propiedades Animate text del efecto:

1. [Aplica](#apply-animation-to-shape) o obtén el efecto de animación.
2. Establece la propiedad [setBuildType(int value)](https://reference.aspose.com/slides/java/com.aspose.slides/itextanimation/#setBuildType-int-) a [BuildType.AsOneObject](https://reference.aspose.com/slides/java/com.aspose.slides/buildtype/#AsOneObject) para desactivar el modo *By Paragraphs*.
3. Establece nuevos valores para las propiedades [setAnimateTextType(int value)](https://reference.aspose.com/slides/java/com.aspose.slides/ieffect/#setAnimateTextType-int-) y [setDelayBetweenTextParts(float value)](https://reference.aspose.com/slides/java/com.aspose.slides/ieffect/#setDelayBetweenTextParts-float-).
4. Guarda el archivo PPTX modificado.

Este código Java demuestra la operación:
```java
// Instancia una clase de presentación que representa un archivo de presentación.
Presentation pres = new Presentation("AnimTextBox_out.pptx");
try {
    ISlide firstSlide = pres.getSlides().get_Item(0);

    // Obtiene el primer efecto de la secuencia principal
    IEffect firstEffect = firstSlide.getTimeline().getMainSequence().get_Item(0);

    // Cambia el tipo de animación de texto del efecto a "As One Object"
    firstEffect.getTextAnimation().setBuildType(BuildType.AsOneObject);

    // Cambia el tipo de animación de texto del efecto a "By word"
    firstEffect.setAnimateTextType(AnimateTextType.ByWord);

    // Establece el retraso entre palabras al 20% de la duración del efecto
    firstEffect.setDelayBetweenTextParts(20f);

    // Guarda el archivo PPTX en disco
    pres.save("AnimTextBox_AnimateText.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Preguntas frecuentes**

**¿Cómo puedo asegurar que las animaciones se conserven al publicar la presentación en la web?**

[Exportar a HTML5](/slides/es/java/export-to-html5/) y habilita las [opciones](https://reference.aspose.com/slides/java/com.aspose.slides/html5options/) responsables de las animaciones de [forma](https://reference.aspose.com/slides/java/com.aspose.slides/html5options/#setAnimateShapes-boolean-) y de [transición](https://reference.aspose.com/slides/java/com.aspose.slides/html5options/#setAnimateTransitions-boolean-). El HTML plano no reproduce animaciones de diapositivas, mientras que HTML5 sí lo hace.

**¿Cómo afecta al animación el cambio del orden Z (orden de capas) de las formas?**

El orden de animación y el orden de dibujo son independientes: un efecto controla el momento y tipo de aparición/desaparición, mientras que el [orden Z](https://reference.aspose.com/slides/java/com.aspose.slides/shape/#getZOrderPosition--) determina qué cubre a qué. El resultado visible se define por su combinación. (Este es el comportamiento general de PowerPoint; el modelo de efectos y formas de Aspose.Slides sigue la misma lógica.)

**¿Existen limitaciones al convertir animaciones a video para ciertos efectos?**

En general, [las animaciones son compatibles](/slides/es/java/convert-powerpoint-to-video/), pero casos raros o efectos específicos pueden renderizarse de forma diferente. Se recomienda probar con los efectos que uses y con la versión de la biblioteca.