---
title: Aplicar animaciones de formas en presentaciones en Android
linktitle: Animación de forma
type: docs
weight: 60
url: /es/androidjava/shape-animation/
keywords:
- forma
- animación
- efecto
- forma animada
- texto animado
- añadir animación
- obtener animación
- extraer animación
- añadir efecto
- obtener efecto
- extraer efecto
- sonido del efecto
- aplicar animación
- PowerPoint
- presentación
- Android
- Java
- Aspose.Slides
description: "Descubre cómo crear y personalizar animaciones de formas en presentaciones de PowerPoint con Aspose.Slides para Android mediante Java. ¡Destaca!"
---

Las animaciones son efectos visuales que pueden aplicarse a textos, imágenes, formas o [gráficos](https://docs.aspose.com/slides/androidjava/animated-charts/). Dan vida a las presentaciones o a sus componentes.

## **¿Por qué usar animaciones en presentaciones?**

Usando animaciones, puedes

* controlar el flujo de información
* destacar puntos importantes
* aumentar el interés o la participación de tu audiencia
* hacer que el contenido sea más fácil de leer, asimilar o procesar
* llamar la atención de tus lectores o espectadores a las partes importantes de una presentación

PowerPoint ofrece muchas opciones y herramientas para animaciones y efectos de animación en las categorías **entrada**, **salida**, **énfasis** y **trayectorias de movimiento**. 

## **Animaciones en Aspose.Slides**

* Aspose.Slides proporciona las clases y tipos que necesitas para trabajar con animaciones en el espacio de nombres `Aspose.Slides.Animation`,
* Aspose.Slides ofrece más de **150 efectos de animación** bajo la enumeración [EffectType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/effecttype). Estos efectos son esencialmente los mismos (o equivalentes) que se usan en PowerPoint.

## **Aplicar animación a un TextBox**

Aspose.Slides para Android mediante Java te permite aplicar animación al texto de una forma.

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
2. Obtén una referencia a una diapositiva mediante su índice.
3. Añade un `rectangle` [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape).
4. Añade texto a [IAutoShape.TextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IAutoShape#addTextFrame-java.lang.String-).
5. Obtén la secuencia principal de efectos.
6. Añade un efecto de animación a [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape).
7. Establece la propiedad `TextAnimation.BuildType` al valor de la enumeración `BuildType`.
8. Guarda la presentación en disco como un archivo PPTX.

Este código Java muestra cómo aplicar el efecto `Fade` a AutoShape y establecer la animación del texto al valor *By 1st Level Paragraphs*:
```java
// Instancia una clase de presentación que representa un archivo de presentación.
Presentation pres = new Presentation();
try {
    ISlide sld = pres.getSlides().get_Item(0);

    // Añade un nuevo AutoShape con texto
    IAutoShape autoShape = sld.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 150, 100);

    ITextFrame textFrame = autoShape.getTextFrame();
    textFrame.setText("First paragraph \nSecond paragraph \n Third paragraph");

    // Obtiene la secuencia principal de la diapositiva.
    ISequence sequence = sld.getTimeline().getMainSequence();

    // Añade el efecto de animación Fade a la forma
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
Además de aplicar animaciones al texto, también puedes aplicar animaciones a un único [Paragraph](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraph). Consulta [**Animated Text**](/slides/es/androidjava/animated-text/).
{{% /alert %}} 

## **Aplicar animación a un PictureFrame**

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
2. Obtén una referencia a una diapositiva mediante su índice.
3. Añade o obtén un [PictureFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pictureframe) en la diapositiva.
4. Obtén la secuencia principal de efectos.
5. Añade un efecto de animación a [PictureFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pictureframe).
6. Guarda la presentación en disco como un archivo PPTX.

Este código Java muestra cómo aplicar el efecto `Fly` a un picture frame:
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


## **Aplicar animación a una Shape**

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
2. Obtén una referencia a una diapositiva mediante su índice.
3. Añade un `rectangle` [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape).
4. Añade un `Bevel` [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape) (cuando se hace clic en este objeto, se reproduce la animación).
5. Crea una secuencia de efectos en la forma bevel.
6. Crea un `UserPath` personalizado.
7. Añade comandos para mover al `UserPath`.
8. Guarda la presentación en disco como un archivo PPTX.

Este código Java muestra cómo aplicar el efecto `PathFootball` (path football) a una forma:
```java
// Instancia una clase Presentation que representa un archivo PPTX.
Presentation pres = new Presentation();
try {
    ISlide sld = pres.getSlides().get_Item(0);

    // Crea el efecto PathFootball para una forma existente desde cero.
    IAutoShape ashp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 150, 150, 250, 25);
    ashp.addTextFrame("Animated TextBox");

    // Añade el efecto de animación PathFootball
    pres.getSlides().get_Item(0).getTimeline().getMainSequence().addEffect(ashp, EffectType.PathFootball,
            EffectSubtype.None, EffectTriggerType.AfterPrevious);

    // Crea una especie de "botón".
    IShape shapeTrigger = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Bevel, 10, 10, 20, 20);

    // Crea una secuencia de efectos para este botón.
    ISequence seqInter = pres.getSlides().get_Item(0).getTimeline().getInteractiveSequences().add(shapeTrigger);

     // Crea una ruta de usuario personalizada. Nuestro objeto se moverá solo después de que se haga clic en el botón.
    IEffect fxUserPath = seqInter.addEffect(ashp, EffectType.PathUser, EffectSubtype.None, EffectTriggerType.OnClick);

     // Añade comandos de movimiento ya que la ruta creada está vacía.
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


## **Obtener los efectos de animación aplicados a una Shape**

Los siguientes ejemplos muestran cómo usar el método `getEffectsByShape` de la interfaz [ISequence](https://reference.aspose.com/slides/androidjava/com.aspose.slides/isequence/) para obtener todos los efectos de animación aplicados a una forma.

**Ejemplo 1: Obtener efectos de animación aplicados a una forma en una diapositiva normal**

Previamente, aprendiste cómo añadir efectos de animación a formas en presentaciones de PowerPoint. El siguiente fragmento de código muestra cómo obtener los efectos aplicados a la primera forma de la primera diapositiva normal de la presentación `AnimExample_out.pptx`.
```java
Presentation presentation = new Presentation("AnimExample_out.pptx");
try {
    ISlide firstSlide = presentation.getSlides().get_Item(0);

    // Obtiene la secuencia principal de animación de la diapositiva.
    ISequence sequence = firstSlide.getTimeline().getMainSequence();

    // Obtiene la primera forma de la primera diapositiva.
    IShape shape = firstSlide.getShapes().get_Item(0);

    // Obtiene los efectos de animación aplicados a la forma.
    IEffect[] shapeEffects = sequence.getEffectsByShape(shape);

    if (shapeEffects.length > 0)
        System.out.println("The shape " + shape.getName() + " has " + shapeEffects.length + " animation effects.");
} finally {
    if (presentation != null) presentation.dispose();
}
```


**Ejemplo 2: Obtener todos los efectos de animación, incluidos los heredados de los marcadores de posición**

Si una forma en una diapositiva normal tiene marcadores de posición que están en la diapositiva de diseño y/o maestra, y se han añadido efectos de animación a esos marcadores, entonces todos los efectos de la forma se reproducirán durante la presentación, incluidos los heredados de los marcadores.

Supongamos que tenemos un archivo de presentación PowerPoint `sample.pptx` con una diapositiva que contiene solo una forma de pie de página con el texto "Made with Aspose.Slides" y al que se le ha aplicado el efecto **Random Bars**.

![Efecto de animación de forma de diapositiva](slide-shape-animation.png)

Supongamos también que el efecto **Split** se ha aplicado al marcador de posición del pie de página en la diapositiva de **diseño**.

![Efecto de animación de forma de diseño](layout-shape-animation.png)

Y, finalmente, el efecto **Fly In** se ha aplicado al marcador de posición del pie de página en la diapositiva **maestra**.

![Efecto de animación de forma maestra](master-shape-animation.png)

El siguiente fragmento de código muestra cómo usar el método `getBasePlaceholder` de la interfaz [IShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/) para acceder a los marcadores de posición de la forma y obtener los efectos de animación aplicados a la forma de pie de página, incluidos los heredados de los marcadores ubicados en las diapositivas de diseño y maestra.
```java
Presentation presentation = new Presentation("sample.pptx");

ISlide slide = presentation.getSlides().get_Item(0);

// Obtiene los efectos de animación de la forma en la diapositiva normal.
IShape shape = slide.getShapes().get_Item(0);
IEffect[] shapeEffects = slide.getTimeline().getMainSequence().getEffectsByShape(shape);

// Obtiene los efectos de animación del marcador de posición en la diapositiva de diseño.
IShape layoutShape = shape.getBasePlaceholder();
IEffect[] layoutShapeEffects = slide.getLayoutSlide().getTimeline().getMainSequence().getEffectsByShape(layoutShape);

// Obtiene los efectos de animación del marcador de posición en la diapositiva maestra.
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


Output:
```text
Main sequence of shape effects:
Fly Bottom
Split VerticalIn
RandomBars Horizontal
```


## **Cambiar las propiedades de temporización del efecto de animación**

Aspose.Slides para Android mediante Java permite cambiar las propiedades de Timing de un efecto de animación.

Este es el panel de temporización de animación en Microsoft PowerPoint:

![Panel de temporización de animación](shape-animation.png)

Estas son las correspondencias entre el Timing de PowerPoint y las propiedades [Effect.Timing](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IEffect#getTiming--):

- La lista desplegable **Start** de temporización de PowerPoint coincide con la propiedad [Effect.Timing.TriggerType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITiming#getTriggerType--).
- La **Duration** de temporización de PowerPoint coincide con la propiedad [Effect.Timing.Duration](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITiming#getDuration--). La duración de una animación (en segundos) es el tiempo total que tarda la animación en completar un ciclo.
- El **Delay** de temporización de PowerPoint coincide con la propiedad [Effect.Timing.TriggerDelayTime](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITiming#getTriggerDelayTime--).

Así es como cambias las propiedades de temporización del efecto:

1. [Aplicar](#apply-animation-to-shape) o obtén el efecto de animación.
2. Establece nuevos valores para las propiedades [Effect.Timing](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IEffect#getTiming--) que necesites.
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

Aspose.Slides proporciona estas propiedades para trabajar con sonidos en los efectos de animación: 

- [setSound(IAudio value)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/effect/#setSound-com.aspose.slides.IAudio-)
- [setStopPreviousSound(boolean value)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/effect/#setStopPreviousSound-boolean-)

### **Añadir un sonido a un efecto de animación**

Este código Java muestra cómo añadir un sonido a un efecto de animación y detenerlo cuando comienza el siguiente efecto:
```java
Presentation pres = new Presentation("AnimExample_out.pptx");
try {
    // Añade audio a la colección de audio de la presentación
    IAudio effectSound = pres.getAudios().addAudio(Files.readAllBytes(Paths.get("sampleaudio.wav")));

    ISlide firstSlide = pres.getSlides().get_Item(0);

    // Obtiene la secuencia principal de la diapositiva.
    ISequence sequence = firstSlide.getTimeline().getMainSequence();

    // Obtiene el primer efecto de la secuencia principal
    IEffect firstEffect = sequence.get_Item(0);

    // Comprueba si el efecto tiene "No Sound"
    if (!firstEffect.getStopPreviousSound() && firstEffect.getSound() == null)
    {
        // Añade sonido al primer efecto
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


### **Extraer el sonido de un efecto de animación**

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/).
2. Obtén una referencia a una diapositiva mediante su índice. 
3. Obtén la secuencia principal de efectos. 
4. Extrae el [setSound(IAudio value)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/effect/#setSound-com.aspose.slides.IAudio-) incrustado en cada efecto de animación.

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

        // Extrae el sonido del efecto en un array de bytes
        byte[] audio = effect.getSound().getBinaryData();
    }
} finally {
    if (presentation != null) presentation.dispose();
}
```


## **Después de la animación**

Aspose.Slides para Android mediante Java permite cambiar la propiedad After animation de un efecto de animación.

Este es el panel de efecto de animación y el menú extendido en Microsoft PowerPoint:

![Panel de efecto de animación](shape-after-animation.png)

La lista desplegable **After animation** del efecto de PowerPoint coincide con estas propiedades: 

- Propiedad [setAfterAnimationType(int value)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ieffect/#setAfterAnimationType-int-) que describe el tipo de After animation :
  * PowerPoint **More Colors** coincide con el tipo [AfterAnimationType.Color](https://reference.aspose.com/slides/androidjava/com.aspose.slides/afteranimationtype/#Color);
  * PowerPoint **Don't Dim** coincide con el tipo [AfterAnimationType.DoNotDim](https://reference.aspose.com/slides/androidjava/com.aspose.slides/afteranimationtype/#DoNotDim) (tipo de animación posterior predeterminado);
  * PowerPoint **Hide After Animation** coincide con el tipo [AfterAnimationType.HideAfterAnimation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/afteranimationtype/#HideAfterAnimation);
  * PowerPoint **Hide on Next Mouse Click** coincide con el tipo [AfterAnimationType.HideOnNextMouseClick](https://reference.aspose.com/slides/androidjava/com.aspose.slides/afteranimationtype/#HideOnNextMouseClick);
- Propiedad [setAfterAnimationColor(IColorFormat value)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ieffect/#setAfterAnimationColor-com.aspose.slides.IColorFormat-) que define un formato de color After animation. Esta propiedad funciona junto con el tipo [AfterAnimationType.Color](https://reference.aspose.com/slides/androidjava/com.aspose.slides/afteranimationtype/#Color). Si cambias el tipo a otro, el color After animation se borrará.

Este código Java muestra cómo cambiar un efecto de animación posterior:
```java
// Instancia una clase de presentación que representa un archivo de presentación
Presentation pres = new Presentation("AnimImage_out.pptx");
try {
    ISlide firstSlide = pres.getSlides().get_Item(0);

    // Obtiene el primer efecto de la secuencia principal
    IEffect firstEffect = firstSlide.getTimeline().getMainSequence().get_Item(0);

    // Cambia el tipo de animación posterior a Color
    firstEffect.setAfterAnimationType(AfterAnimationType.Color);

    // Establece el color de atenuación de la animación posterior
    firstEffect.getAfterAnimationColor().setColor(Color.BLUE);

    // Escribe el archivo PPTX en disco
    pres.save("AnimImage_AfterAnimation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Animar texto**

Aspose.Slides proporciona estas propiedades para trabajar con el bloque *Animate text* de un efecto de animación:

- [setAnimateTextType(int value)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ieffect/#setAnimateTextType-int-) que describe el tipo de animación de texto del efecto. El texto de la forma puede animarse:
  * Todo a la vez ([AnimateTextType.AllAtOnce](https://reference.aspose.com/slides/androidjava/com.aspose.slides/animatetexttype/#AllAtOnce) tipo)
  * Por palabra ([AnimateTextType.ByWord](https://reference.aspose.com/slides/androidjava/com.aspose.slides/animatetexttype/#ByWord) tipo)
  * Por letra ([AnimateTextType.ByLetter](https://reference.aspose.com/slides/androidjava/com.aspose.slides/animatetexttype/#ByLetter) tipo)
- [setDelayBetweenTextParts(float value)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ieffect/#setDelayBetweenTextParts-float-) establece un retraso entre las partes del texto animado (palabras o letras). Un valor positivo especifica el porcentaje de la duración del efecto. Un valor negativo especifica el retraso en segundos.

Así es como puedes cambiar las propiedades *Animate text* del efecto:

1. [Aplicar](#apply-animation-to-shape) o obtén el efecto de animación.
2. Establece la propiedad [setBuildType(int value)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextanimation/#setBuildType-int-) a [BuildType.AsOneObject](https://reference.aspose.com/slides/androidjava/com.aspose.slides/buildtype/#AsOneObject) para desactivar el modo de animación *By Paragraphs*.
3. Establece nuevos valores para las propiedades [setAnimateTextType(int value)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ieffect/#setAnimateTextType-int-) y [setDelayBetweenTextParts(float value)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ieffect/#setDelayBetweenTextParts-float-).
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

    // Establece el retardo entre palabras al 20% de la duración del efecto
    firstEffect.setDelayBetweenTextParts(20f);

    // Escribe el archivo PPTX en disco
    pres.save("AnimTextBox_AnimateText.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **FAQ**

**¿Cómo puedo asegurar que las animaciones se conserven al publicar la presentación en la web?**

[Exportar a HTML5](/slides/es/androidjava/export-to-html5/) y habilita las [opciones](https://reference.aspose.com/slides/androidjava/com.aspose.slides/html5options/) responsables de las animaciones de [shape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/html5options/#setAnimateShapes-boolean-) y de [transition](https://reference.aspose.com/slides/androidjava/com.aspose.slides/html5options/#setAnimateTransitions-boolean-). El HTML simple no reproduce animaciones de diapositiva, mientras que HTML5 sí.

**¿Cómo afecta al cambiar el orden Z (orden de capas) de las formas a la animación?**

El orden Z y el orden de dibujo son independientes: un efecto controla la temporización y el tipo de aparición/desaparición, mientras que el orden Z determina qué cubre a qué. El resultado visible está definido por su combinación. (Este es el comportamiento general de PowerPoint; el modelo de efectos y formas de Aspose.Slides sigue la misma lógica.)

**¿Existen limitaciones al convertir animaciones a vídeo para ciertos efectos?**

En general, [las animaciones son compatibles](/slides/es/androidjava/convert-powerpoint-to-video/), pero casos raros o efectos específicos pueden renderizarse de forma diferente. Se recomienda probar con los efectos que utilizas y con la versión de la biblioteca.