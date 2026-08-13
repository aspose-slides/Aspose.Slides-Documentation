---
title: Aplicar animaciones de forma en presentaciones en Android
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
description: "Descubra cómo crear y personalizar animaciones de forma en presentaciones de PowerPoint con Aspose.Slides para Android mediante Java. ¡Destáquese!"
---
## **Introducción**

Las animaciones son efectos visuales que se pueden aplicar a textos, imágenes, formas o [gráficos](https://docs.aspose.com/slides/es/androidjava/animated-charts/). Dan vida a las presentaciones o a sus componentes.

## **¿Por qué usar animaciones en presentaciones?**

Al usar animaciones, puedes  

* controlar el flujo de información  
* resaltar puntos importantes  
* aumentar el interés o la participación de la audiencia  
* hacer que el contenido sea más fácil de leer, asimilar o procesar  
* atraer la atención de los lectores o espectadores a las partes importantes de una presentación  

PowerPoint ofrece muchas opciones y herramientas para animaciones y efectos de animación en las categorías de **entrada**, **salida**, **énfasis** y **trayectorias de movimiento**. 

## **Animaciones en Aspose.Slides**

* Aspose.Slides proporciona las clases y tipos que necesita para trabajar con animaciones en el espacio de nombres `Aspose.Slides.Animation`,  
* Aspose.Slides ofrece más de **150 efectos de animación** bajo la enumeración [EffectType](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/effecttype). Estos efectos son esencialmente los mismos (o equivalentes) que se usan en PowerPoint.  

## **Aplicar animación a un TextBox**

Aspose.Slides para Android mediante Java le permite aplicar animación al texto dentro de una forma.

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/Presentation).  
2. Obtenga una referencia a una diapositiva mediante su índice.  
3. Añada una [IAutoShape](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/iautoshape) de tipo `rectangle`.  
4. Añada texto al [IAutoShape.TextFrame](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/IAutoShape#addTextFrame-java.lang.String-).  
5. Obtenga la secuencia principal de efectos.  
6. Añada un efecto de animación a [IAutoShape](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/iautoshape).  
7. Establezca la propiedad `TextAnimation.BuildType` al valor de la enumeración `BuildType`.  
8. Guarde la presentación en disco como un archivo PPTX.  

Este código Java le muestra cómo aplicar el efecto `Fade` a AutoShape y establecer la animación del texto al valor *By 1st Level Paragraphs*:

```java
import com.aspose.slides.*;

// Instancia una clase de presentación que representa un archivo de presentación.
Presentation pres = new Presentation();
try {
    ISlide sld = pres.getSlides().get_Item(0);

    // Añade una nueva AutoShape con texto
    IAutoShape autoShape = sld.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 150, 100);

    ITextFrame textFrame = autoShape.getTextFrame();
    textFrame.setText("First paragraph \nSecond paragraph \n Third paragraph");

    // Obtiene la secuencia principal de la diapositiva.
    ISequence sequence = sld.getTimeline().getMainSequence();

    // Añade el efecto de animación Fade a la forma
    IEffect effect = sequence.addEffect(autoShape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);

    // Anima el texto de la forma por párrafos de primer nivel
    effect.getTextAnimation().setBuildType(BuildType.ByLevelParagraphs1);

    // Guarda el archivo PPTX en el disco
    pres.save("AnimText_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

{{%  alert color="info"  %}} 

Además de aplicar animaciones al texto, también puede aplicar animaciones a un único [Paragraph](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/iparagraph). Vea [**Animated Text**](/slides/es/androidjava/animated-text/).

{{% /alert %}} 

## **Aplicar animación a un PictureFrame**

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/Presentation).  
2. Obtenga una referencia a una diapositiva mediante su índice.  
3. Añada o obtenga un [PictureFrame](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/pictureframe) en la diapositiva.  
4. Obtenga la secuencia principal de efectos.  
5. Añada un efecto de animación a [PictureFrame](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/pictureframe).  
6. Guarde la presentación en disco como un archivo PPTX.  

Este código Java le muestra cómo aplicar el efecto `Fly` a un marco de imagen:

```java
import com.aspose.slides.*;

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

    // Guarda el archivo PPTX en el disco
    pres.save("AnimImage_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Aplicar animación a una forma**

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/Presentation).  
2. Obtenga una referencia a una diapositiva mediante su índice.  
3. Añada una [IAutoShape](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/iautoshape) de tipo `rectangle`.  
4. Añada una [IAutoShape](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/iautoshape) `Bevel` (cuando este objeto se hace clic, se reproduce la animación).  
5. Cree una secuencia de efectos en la forma `Bevel`.  
6. Cree una `UserPath` personalizada.  
7. Añada comandos para mover a la `UserPath`.  
8. Guarde la presentación en disco como un archivo PPTX.  

Este código Java le muestra cómo aplicar el efecto `PathFootball` (ruta fútbol) a una forma:

```java
import com.aspose.slides.*;
import java.awt.geom.Point2D;

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

     // Añade comandos para mover ya que la ruta creada está vacía.
    IMotionEffect motionBhv = ((IMotionEffect)fxUserPath.getBehaviors().get_Item(0));

    Point2D.Float[] pts = new Point2D.Float[1];
    pts[0] = new Point2D.Float(0.076f, 0.59f);
    motionBhv.getPath().add(MotionCommandPathType.LineTo, pts, MotionPathPointsType.Auto, true);
    pts[0] = new Point2D.Float(-0.076f, -0.59f);
    motionBhv.getPath().add(MotionCommandPathType.LineTo, pts, MotionPathPointsType.Auto, false);
    motionBhv.getPath().add(MotionCommandPathType.End, null, MotionPathPointsType.Auto, false);

     // Guarda el archivo PPTX en el disco
    pres.save("AnimExample_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Obtener los efectos de animación aplicados a una forma**

Los siguientes ejemplos le muestran cómo usar el método `getEffectsByShape` de la interfaz [ISequence](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/isequence/) para obtener todos los efectos de animación aplicados a una forma.

**Ejemplo 1: Obtener los efectos de animación aplicados a una forma en una diapositiva normal**

Anteriormente, aprendió cómo añadir efectos de animación a las formas en presentaciones de PowerPoint. El siguiente fragmento de código muestra cómo obtener los efectos aplicados a la primera forma de la primera diapositiva normal en la presentación `AnimExample_out.pptx`.

```java
import com.aspose.slides.*;

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

Supongamos que tenemos un archivo de presentación PowerPoint `sample.pptx` con una sola diapositiva que contiene únicamente una forma de pie de página con el texto "Made with Aspose.Slides" y al que se le ha aplicado el efecto **Random Bars**.

![Efecto de animación de forma de diapositiva](slide-shape-animation.png)

Supongamos también que al marcador de posición de pie de página en la diapositiva **layout** se le ha aplicado el efecto **Split**.

![Efecto de animación de forma de diseño](layout-shape-animation.png)

Y finalmente, al marcador de posición de pie de página en la diapositiva **master** se le ha aplicado el efecto **Fly In**.

![Efecto de animación de forma maestra](master-shape-animation.png)

El siguiente fragmento de código muestra cómo usar el método `getBasePlaceholder` de la interfaz [IShape](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/ishape/) para acceder a los marcadores de posición de la forma y obtener los efectos de animación aplicados a la forma de pie de página, incluidos los heredados de los marcadores situados en las diapositivas de diseño y maestra.

```java
import com.aspose.slides.*;

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
for (IEffect[] effects : new IEffect[][] { masterShapeEffects, layoutShapeEffects, shapeEffects }) {
    for (IEffect effect : effects) {
        String typeName = EffectType.getName(EffectType.class, effect.getType());
        String subtypeName = EffectSubtype.getName(EffectSubtype.class, effect.getSubtype());

        System.out.println(typeName + " " + subtypeName);
    }
}

presentation.dispose();
```
```java
import com.aspose.slides.*;

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

## **Cambiar las propiedades de tiempo del efecto de animación**

Aspose.Slides para Android mediante Java le permite cambiar las propiedades de tiempo de un efecto de animación.

Este es el panel de temporización de animación en Microsoft PowerPoint:

![example1_image](shape-animation.png)

Estas son las correspondencias entre PowerPoint Timing y las propiedades [Effect.Timing](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/IEffect#getTiming--):

- La lista desplegable **Start** de PowerPoint Timing coincide con la propiedad [Effect.Timing.TriggerType](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/ITiming#getTriggerType--).  
- PowerPoint Timing **Duration** coincide con la propiedad [Effect.Timing.Duration](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/ITiming#getDuration--). La duración de una animación (en segundos) es el tiempo total que tarda la animación en completar un ciclo.  
- PowerPoint Timing **Delay** coincide con la propiedad [Effect.Timing.TriggerDelayTime](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/ITiming#getTriggerDelayTime--).  

Así es como se cambian las propiedades de temporización del efecto:

1. Aplique ([Apply](#apply-animation-to-shape)) o obtenga el efecto de animación.  
2. Establezca nuevos valores para las propiedades [Effect.Timing](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/IEffect#getTiming--) que necesite.  
3. Guarde el archivo PPTX modificado.  

```java
import com.aspose.slides.*;

// Instancia una clase de presentación que representa un archivo de presentación.
Presentation pres = new Presentation("AnimExample_out.pptx");
try {
    // Obtiene la secuencia principal de la diapositiva.
    ISequence sequence = pres.getSlides().get_Item(0).getTimeline().getMainSequence();

    // Obtiene el primer efecto de la secuencia principal.
    IEffect effect = sequence.get_Item(0);

    // Cambia el TriggerType del efecto para que comience al hacer clic
    effect.getTiming().setTriggerType(EffectTriggerType.OnClick);

    // Cambia la duración del efecto
    effect.getTiming().setDuration(3f);

    // Cambia el TriggerDelayTime del efecto
    effect.getTiming().setTriggerDelayTime(0.5f);

    // Guarda el archivo PPTX en el disco
    pres.save("AnimExample_changed.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Sonido del efecto de animación**

Aspose.Slides proporciona estas propiedades para permitirle trabajar con sonidos en efectos de animación: 

- [setSound(IAudio value)](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/effect/#setSound-com.aspose.slides.IAudio-)  
- [setStopPreviousSound(boolean value)](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/effect/#setStopPreviousSound-boolean-)  

### **Añadir un sonido al efecto de animación**

Este código Java le muestra cómo añadir un sonido al efecto de animación y detenerlo cuando comienza el siguiente efecto:

```java
import com.aspose.slides.*;
import java.nio.file.Files;
import java.nio.file.Paths;

Presentation pres = new Presentation("AnimExample_out.pptx");
try {
    // Añade audio a la colección de audio de la presentación
    IAudio effectSound = pres.getAudios().addAudio(Files.readAllBytes(Paths.get("sampleaudio.wav")));

    ISlide firstSlide = pres.getSlides().get_Item(0);

    // Obtiene la secuencia principal de la diapositiva.
    ISequence sequence = firstSlide.getTimeline().getMainSequence();

    // Obtiene el primer efecto de la secuencia principal
    IEffect firstEffect = sequence.get_Item(0);

    // Comprueba si el efecto está sin sonido
    if (!firstEffect.getStopPreviousSound() && firstEffect.getSound() == null)
    {
        // Añade sonido al primer efecto
        firstEffect.setSound(effectSound);
    }

    // Obtiene la primera secuencia interactiva de la diapositiva.
    ISequence interactiveSequence = firstSlide.getTimeline().getInteractiveSequences().get_Item(0);

    // Establece la bandera "Detener sonido anterior" del efecto
    interactiveSequence.get_Item(0).setStopPreviousSound(true);

    // Escribe el archivo PPTX en el disco
    pres.save("AnimExample_Sound_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **Extraer un sonido del efecto de animación**

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/presentation/).  
2. Obtenga una referencia a una diapositiva mediante su índice.  
3. Obtenga la secuencia principal de efectos.  
4. Extraiga el [setSound(IAudio value)](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/effect/#setSound-com.aspose.slides.IAudio-) incrustado en cada efecto de animación.  

Este código Java le muestra cómo extraer el sonido incrustado en un efecto de animación:

```java
import com.aspose.slides.*;

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

Aspose.Slides para Android mediante Java le permite cambiar la propiedad After animation de un efecto de animación.

Este es el panel de efecto de animación y el menú expandido en Microsoft PowerPoint:

![example1_image](shape-after-animation.png)

La lista desplegable **After animation** del efecto de PowerPoint coincide con estas propiedades: 

- Propiedad [setAfterAnimationType(int value)] que describe el tipo After animation:  
  * PowerPoint **More Colors** coincide con el tipo [AfterAnimationType.Color](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/afteranimationtype/#Color);  
  * PowerPoint **Don't Dim** coincide con el tipo [AfterAnimationType.DoNotDim](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/afteranimationtype/#DoNotDim) (tipo predeterminado de after animation);  
  * PowerPoint **Hide After Animation** coincide con el tipo [AfterAnimationType.HideAfterAnimation](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/afteranimationtype/#HideAfterAnimation);  
  * PowerPoint **Hide on Next Mouse Click** coincide con el tipo [AfterAnimationType.HideOnNextMouseClick](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/afteranimationtype/#HideOnNextMouseClick);  

- Propiedad [setAfterAnimationColor(IColorFormat value)] que define un formato de color para after animation. Esta propiedad funciona junto con el tipo [AfterAnimationType.Color](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/afteranimationtype/#Color). Si cambia el tipo a otro, el color after animation se borrará.  

Este código Java le muestra cómo cambiar un efecto after animation:

```java
import com.aspose.slides.*;
import java.awt.Color;

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

    // Guarda el archivo PPTX en el disco
    pres.save("AnimImage_AfterAnimation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Animar texto**

Aspose.Slides proporciona estas propiedades para permitirle trabajar con el bloque *Animate text* de un efecto de animación:

- Propiedad [setAnimateTextType(int value)] que describe el tipo de animación de texto del efecto. El texto de la forma puede animarse:  
  - Todo a la vez ([AnimateTextType.AllAtOnce](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/animatetexttype/#AllAtOnce))  
  - Por palabra ([AnimateTextType.ByWord](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/animatetexttype/#ByWord))  
  - Por letra ([AnimateTextType.ByLetter](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/animatetexttype/#ByLetter))  

- Propiedad [setDelayBetweenTextParts(float value)] que establece un retraso entre las partes del texto animado (palabras o letras). Un valor positivo especifica el porcentaje de la duración del efecto. Un valor negativo especifica el retraso en segundos.  

Así es como puede cambiar las propiedades *Animate text* del efecto:

1. Aplique ([Apply](#apply-animation-to-shape)) o obtenga el efecto de animación.  
2. Establezca la propiedad [setBuildType(int value)] al valor [BuildType.AsOneObject](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/buildtype/#AsOneObject) para desactivar el modo de animación *By Paragraphs*.  
3. Establezca nuevos valores para las propiedades [setAnimateTextType(int value)] y [setDelayBetweenTextParts(float value)].  
4. Guarde el archivo PPTX modificado.  

```java
import com.aspose.slides.*;

// Instancia una clase de presentación que representa un archivo de presentación.
Presentation pres = new Presentation("AnimText_out.pptx");
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

    // Guarda el archivo PPTX en el disco
    pres.save("AnimTextBox_AnimateText.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Preguntas frecuentes**

### ¿Cómo puedo garantizar que las animaciones se conserven al publicar la presentación en la web?

[Exportar a HTML5](/slides/es/androidjava/export-to-html5/) y habilite las [opciones](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/html5options/) responsables de animaciones de [shape](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/html5options/#setAnimateShapes-boolean-) y [transition](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/html5options/#setAnimateTransitions-boolean-). El HTML plano no reproduce animaciones de diapositivas, mientras que HTML5 sí lo hace.

### ¿Cómo afecta al animación el cambio del orden Z (orden de capas) de las formas?

La animación y el orden de dibujo son independientes: un efecto controla el momento y el tipo de aparición/desaparición, mientras que el [z-order](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/shape/#getZOrderPosition--) determina qué cubre a qué. El resultado visible se define por su combinación. (Este es el comportamiento general de PowerPoint; el modelo de efectos y formas de Aspose.Slides sigue la misma lógica.)

### ¿Existen limitaciones al convertir animaciones a vídeo para ciertos efectos?

En general, [las animaciones están soportadas](/slides/es/androidjava/convert-powerpoint-to-video/), pero casos raros o efectos específicos pueden renderizarse de forma diferente. Se recomienda probar con los efectos que utilice y con la versión de la biblioteca.