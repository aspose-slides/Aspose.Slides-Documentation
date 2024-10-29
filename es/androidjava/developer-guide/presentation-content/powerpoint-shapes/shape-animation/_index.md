---
title: Animación de Formas
type: docs
weight: 60
url: /es/androidjava/shape-animation/
keywords: "animación de PowerPoint, efecto de animación, aplicar animación, presentación de PowerPoint, Java, Aspose.Slides para Android a través de Java"
description: "Aplica animación de PowerPoint en Java"
---

Las animaciones son efectos visuales que se pueden aplicar a textos, imágenes, formas o [gráficos](https://docs.aspose.com/slides/androidjava/animated-charts/). Dan vida a las presentaciones o a sus componentes.

### **¿Por qué usar animaciones en presentaciones?**

Usando animaciones, puedes 

* controlar el flujo de información
* enfatizar puntos importantes
* aumentar el interés o la participación entre tu audiencia
* hacer que el contenido sea más fácil de leer, asimilar o procesar
* atraer la atención de tus lectores o espectadores a partes importantes de una presentación

PowerPoint proporciona muchas opciones y herramientas para animaciones y efectos de animación en las categorías de **entrada**, **salida**, **énfasis** y **rutas de movimiento**.

### **Animaciones en Aspose.Slides**

* Aspose.Slides proporciona las clases y tipos que necesitas para trabajar con animaciones bajo el espacio de nombres `Aspose.Slides.Animation`,
* Aspose.Slides ofrece más de **150 efectos de animación** bajo la enumeración [EffectType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/effecttype). Estos efectos son esencialmente los mismos (o equivalentes) efectos utilizados en PowerPoint.

## **Aplicar Animación a TextBox**

Aspose.Slides para Android a través de Java te permite aplicar animación al texto en una forma.

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
2. Obtén una referencia de la diapositiva a través de su índice.
3. Agrega una [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape) `rectángulo`.
4. Agrega texto a [IAutoShape.TextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IAutoShape#addTextFrame-java.lang.String-).
5. Obtén una secuencia principal de efectos.
6. Agrega un efecto de animación a [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape).
7. Establece la propiedad `TextAnimation.BuildType` al valor de la enumeración `BuildType`.
8. Escribe la presentación en disco como un archivo PPTX.

Este código Java muestra cómo aplicar el efecto `Fade` a AutoShape y establecer la animación de texto en el valor *Por párrafos de 1er nivel*:

```java
// Instancia una clase de presentación que representa un archivo de presentación.
Presentation pres = new Presentation();
try {
    ISlide sld = pres.getSlides().get_Item(0);

    // Agrega nuevo AutoShape con texto
    IAutoShape autoShape = sld.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 150, 100);

    ITextFrame textFrame = autoShape.getTextFrame();
    textFrame.setText("Primer párrafo \nSegundo párrafo \nTercer párrafo");

    // Obtiene la secuencia principal de la diapositiva.
    ISequence sequence = sld.getTimeline().getMainSequence();

    // Agrega el efecto de animación Fade a la forma
    IEffect effect = sequence.addEffect(autoShape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);

    // Anima el texto de la forma por párrafos de 1er nivel
    effect.getTextAnimation().setBuildType(BuildType.ByLevelParagraphs1);

    // Guarda el archivo PPTX en disco
    pres.save(path + "AnimText_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

{{%  alert color="primary"  %}} 

Además de aplicar animaciones a texto, también puedes aplicar animaciones a un solo [Párrafo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraph). Consulta [**Texto Animado**](/slides/es/androidjava/animated-text/).

{{% /alert %}} 

## **Aplicar Animación a PictureFrame**

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
2. Obtén una referencia de la diapositiva a través de su índice.
3. Agrega o obtiene un [PictureFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pictureframe) en la diapositiva.
4. Obtén la secuencia principal de efectos.
5. Agrega un efecto de animación a [PictureFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pictureframe).
6. Escribe la presentación en disco como un archivo PPTX.

Este código Java muestra cómo aplicar el efecto `Fly` a un marco de imagen:

```java
// Instancia una clase de presentación que representa un archivo de presentación.
Presentation pres = new Presentation();
try {
    // Carga la imagen para ser agregada a la colección de imágenes de la presentación
    IPPImage picture;
    IImage image = Images.fromFile("aspose-logo.jpg");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }

    // Agrega el marco de imagen a la diapositiva
    IPictureFrame picFrame = pres.getSlides().get_Item(0).getShapes().addPictureFrame(ShapeType.Rectangle, 50, 50, 100, 100, picture);

    // Obtiene la secuencia principal de la diapositiva.
    ISequence sequence = pres.getSlides().get_Item(0).getTimeline().getMainSequence();

    // Agrega el efecto de animación Fly desde la izquierda al marco de imagen
    IEffect effect = sequence.addEffect(picFrame, EffectType.Fly, EffectSubtype.Left, EffectTriggerType.OnClick);

    // Guarda el archivo PPTX en disco
    pres.save(path + "AnimImage_out.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **Aplicar Animación a Forma**

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
2. Obtén una referencia de la diapositiva a través de su índice.
3. Agrega una [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape) `rectángulo`.
4. Agrega un [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape) `Bevel` (cuando se hace clic en este objeto, se reproduce la animación).
5. Crea una secuencia de efectos en la forma de bisel.
6. Crea una `UserPath` personalizada.
7. Agrega comandos para moverte a la `UserPath`.
8. Escribe la presentación en disco como un archivo PPTX.

Este código Java muestra cómo aplicar el efecto `PathFootball` (camino de fútbol) a una forma:

```java
// Instancia una clase de presentación que representa un archivo PPTX.
Presentation pres = new Presentation();
try {
    ISlide sld = pres.getSlides().get_Item(0);

    // Crea un efecto PathFootball para una forma existente desde cero.
    IAutoShape ashp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 150, 150, 250, 25);
    ashp.addTextFrame("Cuadro de texto animado");

    // Agrega el efecto de animación PathFootBall
    pres.getSlides().get_Item(0).getTimeline().getMainSequence().addEffect(ashp, EffectType.PathFootball,
            EffectSubtype.None, EffectTriggerType.AfterPrevious);

    // Crea algún tipo de "botón".
    IShape shapeTrigger = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Bevel, 10, 10, 20, 20);

    // Crea una secuencia de efectos para este botón.
    ISequence seqInter = pres.getSlides().get_Item(0).getTimeline().getInteractiveSequences().add(shapeTrigger);

     // Crea un camino de usuario personalizado. Nuestro objeto se moverá solo después de que se haga clic en el botón.
    IEffect fxUserPath = seqInter.addEffect(ashp, EffectType.PathUser, EffectSubtype.None, EffectTriggerType.OnClick);

     // Agrega comandos para moverse ya que el camino creado está vacío.
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

## **Obtener los Efectos de Animación Aplicados a la Forma**

Puedes decidir averiguar todos los efectos de animación aplicados a una sola forma. 

Este código Java muestra cómo obtener todos los efectos aplicados a una forma específica:

```java
// Instancia una clase de presentación que representa un archivo de presentación.
Presentation pres = new Presentation("AnimExample_out.pptx");
try {
    ISlide firstSlide = pres.getSlides().get_Item(0);

    // Obtiene la secuencia principal de la diapositiva.
    ISequence sequence = firstSlide.getTimeline().getMainSequence();

    // Obtiene la primera forma en la diapositiva.
    IShape shape = firstSlide.getShapes().get_Item(0);

    // Obtiene todos los efectos de animación aplicados a la forma.
    IEffect[] shapeEffects = sequence.getEffectsByShape(shape);

    if (shapeEffects.length > 0)
        System.out.println("La forma " + shape.getName() + " tiene " + shapeEffects.length + " efectos de animación.");
} finally {
    if (pres != null) pres.dispose();
}
```

## **Cambiar Propiedades de Tiempo del Efecto de Animación**

Aspose.Slides para Android a través de Java te permite cambiar las propiedades de Tiempo de un efecto de animación.

Este es el panel de Tiempo de Animación en Microsoft PowerPoint:

![example1_image](shape-animation.png)

Estas son las correspondencias entre el Tiempo de PowerPoint y las propiedades de [Effect.Timing](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IEffect#getTiming--) :

- La lista desplegable de **Inicio** de PowerPoint coincide con la propiedad [Effect.Timing.TriggerType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITiming#getTriggerType--) .
- La **Duración** del Tiempo de PowerPoint coincide con la propiedad [Effect.Timing.Duration](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITiming#getDuration--) . La duración de una animación (en segundos) es el tiempo total que toma completar un ciclo de animación.
- El **Retraso** del Tiempo de PowerPoint coincide con la propiedad [Effect.Timing.TriggerDelayTime](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITiming#getTriggerDelayTime--) .

Así es como cambias las propiedades de Tiempo del Efecto:

1. [Aplica](#apply-animation-to-shape) o obtén el efecto de animación.
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

    // Cambia el TriggerType del efecto para que comience al hacer clic
    effect.getTiming().setTriggerType(EffectTriggerType.OnClick);

    // Cambia la Duración del efecto
    effect.getTiming().setDuration(3f);

    // Cambia el TriggerDelayTime del efecto
    effect.getTiming().setTriggerDelayTime(0.5f);

    // Guarda el archivo PPTX en disco
    pres.save("AnimExample_changed.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Sonido del Efecto de Animación**

Aspose.Slides proporciona estas propiedades para permitirte trabajar con sonidos en efectos de animación: 

- [setSound(IAudio value)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/effect/#setSound-com.aspose.slides.IAudio-)
- [setStopPreviousSound(boolean value)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/effect/#setStopPreviousSound-boolean-)

### **Agregar Sonido al Efecto de Animación**

Este código Java muestra cómo agregar un sonido al efecto de animación y detenerlo cuando comienza el siguiente efecto:

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

    // Verifica el efecto para "Sin Sonido"
    if (!firstEffect.getStopPreviousSound() && firstEffect.getSound() == null)
    {
        // Agrega sonido para el primer efecto
        firstEffect.setSound(effectSound);
    }

    // Obtiene la primera secuencia interactiva de la diapositiva.
    ISequence interactiveSequence = firstSlide.getTimeline().getInteractiveSequences().get_Item(0);

    // Establece la bandera "Detener sonido anterior" del efecto
    interactiveSequence.get_Item(0).setStopPreviousSound(true);

    // Escribe el archivo PPTX en disco
    pres.save("AnimExample_Sound_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **Extraer Sonido del Efecto de Animación**

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/androidjava/aspose.slides/presentation/) .
2. Obtén una referencia de la diapositiva a través de su índice. 
3. Obtén la secuencia principal de efectos. 
4. Extrae el [setSound(IAudio value)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/effect/#setSound-com.aspose.slides.IAudio-) embebido en cada efecto de animación.

Este código Java muestra cómo extraer el sonido embebido en un efecto de animación:

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

## **Después de la Animación**

Aspose.Slides para Android a través de Java te permite cambiar la propiedad Después de la animación de un efecto de animación.

Este es el panel del Efecto de Animación y el menú extendido en Microsoft PowerPoint:

![example1_image](shape-after-animation.png)

La lista desplegable **Después de la animación** de PowerPoint coincide con estas propiedades: 

- [setAfterAnimationType(int value)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ieffect/#setAfterAnimationType-int-) propiedad que describe el tipo de animación después de:
  * PowerPoint **Más Colores** coincide con el tipo [AfterAnimationType.Color](https://reference.aspose.com/slides/androidjava/com.aspose.slides/afteranimationtype/#Color) ;
  * El ítem de lista **No Atenuar** de PowerPoint coincide con el tipo [AfterAnimationType.DoNotDim](https://reference.aspose.com/slides/androidjava/com.aspose.slides/afteranimationtype/#DoNotDim) (tipo de animación después de predeterminado);
  * El ítem de lista **Esconder Después de la Animación** coincide con el tipo [AfterAnimationType.HideAfterAnimation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/afteranimationtype/#HideAfterAnimation) ;
  * El ítem de lista **Esconder en el Siguiente Clic del Ratón** coincide con el tipo [AfterAnimationType.HideOnNextMouseClick](https://reference.aspose.com/slides/androidjava/com.aspose.slides/afteranimationtype/#HideOnNextMouseClick) ;
- [setAfterAnimationColor(IColorFormat value)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ieffect/#setAfterAnimationColor-com.aspose.slides.IColorFormat-) propiedad que define un formato de color después de la animación. Esta propiedad trabaja en conjunto con el tipo [AfterAnimationType.Color](https://reference.aspose.com/slides/androidjava/com.aspose.slides/afteranimationtype/#Color) . Si cambias el tipo a otro, el color después de la animación se borrará.

Este código Java muestra cómo cambiar un efecto después de la animación:

```java
// Instancia una clase de presentación que representa un archivo de presentación
Presentation pres = new Presentation("AnimImage_out.pptx");
try {
    ISlide firstSlide = pres.getSlides().get_Item(0);

    // Obtiene el primer efecto de la secuencia principal
    IEffect firstEffect = firstSlide.getTimeline().getMainSequence().get_Item(0);

    // Cambia el tipo de animación después a Color
    firstEffect.setAfterAnimationType(AfterAnimationType.Color);

    // Establece el color de atenuación después de la animación
    firstEffect.getAfterAnimationColor().setColor(Color.BLUE);

    // Escribe el archivo PPTX en disco
    pres.save("AnimImage_AfterAnimation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Animar Texto**

Aspose.Slides proporciona estas propiedades para permitirte trabajar con el bloque *Animar texto* de un efecto de animación:

- [setAnimateTextType(int value)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ieffect/#setAnimateTextType-int-) que describe un tipo de texto animado del efecto. El texto de la forma puede ser animado:
  - Todo a la vez ([AnimateTextType.AllAtOnce](https://reference.aspose.com/slides/androidjava/com.aspose.slides/animatetexttype/#AllAtOnce) tipo)
  - Por palabra ([AnimateTextType.ByWord](https://reference.aspose.com/slides/androidjava/com.aspose.slides/animatetexttype/#ByWord) tipo)
  - Por letra ([AnimateTextType.ByLetter](https://reference.aspose.com/slides/androidjava/com.aspose.slides/animatetexttype/#ByLetter) tipo)
- [setDelayBetweenTextParts(float value)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ieffect/#setDelayBetweenTextParts-float-) establece un retraso entre las partes de texto animadas (palabras o letras). Un valor positivo especifica el porcentaje de duración del efecto. Un valor negativo especifica el retraso en segundos.

Así es como puedes cambiar las propiedades de Efecto de Animar texto:

1. [Aplica](#apply-animation-to-shape) o obtén el efecto de animación.
2. Establece la propiedad [setBuildType(int value)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextanimation/#setBuildType-int-) al valor [BuildType.AsOneObject](https://reference.aspose.com/slides/androidjava/com.aspose.slides/buildtype/#AsOneObject) para desactivar el modo de animación *Por Párrafos*.
3. Establece nuevos valores para las propiedades [setAnimateTextType(int value)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ieffect/#setAnimateTextType-int-) y [setDelayBetweenTextParts(float value)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ieffect/#setDelayBetweenTextParts-float-) .
4. Guarda el archivo PPTX modificado.

Este código Java demuestra la operación:

```java
// Instancia una clase de presentación que representa un archivo de presentación.
Presentation pres = new Presentation("AnimTextBox_out.pptx");
try {
    ISlide firstSlide = pres.getSlides().get_Item(0);

    // Obtiene el primer efecto de la secuencia principal
    IEffect firstEffect = firstSlide.getTimeline().getMainSequence().get_Item(0);

    // Cambia el tipo de animación de texto del efecto a "Como Un Solo Objeto"
    firstEffect.getTextAnimation().setBuildType(BuildType.AsOneObject);

    // Cambia el tipo de animación de texto del efecto a "Por palabra"
    firstEffect.setAnimateTextType(AnimateTextType.ByWord);

    // Establece el retraso entre palabras al 20% de la duración del efecto
    firstEffect.setDelayBetweenTextParts(20f);

    // Escribe el archivo PPTX en disco
    pres.save("AnimTextBox_AnimateText.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```