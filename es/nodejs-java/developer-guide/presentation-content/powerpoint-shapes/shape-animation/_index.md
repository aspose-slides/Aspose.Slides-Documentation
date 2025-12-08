---
title: Animación de forma
type: docs
weight: 60
url: /es/nodejs-java/shape-animation/
keywords:
- forma
- animación
- efecto
- agregar efectos
- obtener efectos
- extraer efectos
- aplicar animación
- PowerPoint
- presentación
- Node.js
- Java
- Aspose.Slides para Node.js vía Java
description: "Aplicar animación de PowerPoint en JavaScript"
---

Las animaciones son efectos visuales que pueden aplicarse a textos, imágenes, formas o [gráficos](/slides/es/nodejs-java/animated-charts/). Dan vida a las presentaciones o a sus componentes.

## **¿Por qué usar animaciones en presentaciones?**

Usando animaciones, puede  

* controlar el flujo de información  
* resaltar puntos importantes  
* aumentar el interés o la participación de su audiencia  
* hacer que el contenido sea más fácil de leer, asimilar o procesar  
* llamar la atención de sus lectores o espectadores a partes importantes de una presentación  

PowerPoint ofrece muchas opciones y herramientas para animaciones y efectos de animación en las categorías de **entrada**, **salida**, **énfasis** y **trayectorias de movimiento**. 

## **Animaciones en Aspose.Slides**

* Aspose.Slides proporciona las clases y tipos que necesita para trabajar con animaciones bajo el espacio de nombres `Aspose.Slides.Animation`,  
* Aspose.Slides ofrece más de **150 efectos de animación** bajo la enumeración [EffectType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effecttype). Estos efectos son esencialmente los mismos (o equivalentes) que se usan en PowerPoint.  

## **Aplicar animación a TextBox**

Aspose.Slides para Node.js a través de Java le permite aplicar animación al texto dentro de una forma.

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation).  
2. Obtenga una referencia a la diapositiva mediante su índice.  
3. Agregue una [AutoShape] de tipo `rectangle` (https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape).  
4. Agregue texto usando [AutoShape.addTextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/AutoShape#addTextFrame-java.lang.String-).  
5. Obtenga la secuencia principal de efectos.  
6. Agregue un efecto de animación a [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape).  
7. Llame al método `TextAnimation.setBuildType` con el valor de la enumeración `BuildType`.  
8. Guarde la presentación en disco como un archivo PPTX.  

Este código Javascript le muestra cómo aplicar el efecto `Fade` a AutoShape y establecer la animación del texto al valor *By 1st Level Paragraphs*:
```javascript
// Crea una instancia de una clase de presentación que representa un archivo de presentación.
var pres = new aspose.slides.Presentation();
try {
    var sld = pres.getSlides().get_Item(0);
    // Agrega una AutoShape nueva con texto
    var autoShape = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 20, 150, 100);
    var textFrame = autoShape.getTextFrame();
    textFrame.setText("First paragraph \nSecond paragraph \n Third paragraph");
    // Obtiene la secuencia principal de la diapositiva.
    var sequence = sld.getTimeline().getMainSequence();
    // Añade el efecto de animación Fade a la forma
    var effect = sequence.addEffect(autoShape, aspose.slides.EffectType.Fade, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.OnClick);
    // Anima el texto de la forma por párrafos de primer nivel
    effect.getTextAnimation().setBuildType(aspose.slides.BuildType.ByLevelParagraphs1);
    // Guarda el archivo PPTX en disco
    pres.save(path + "AnimText_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


{{%  alert color="primary"  %}} 

Además de aplicar animaciones al texto, también puede aplicar animaciones a un [Párrafo](/slides/es/nodejs-java/animated-text/) único. Vea [**Texto animado**](/slides/es/nodejs-java/animated-text/).

{{% /alert %}} 

## **Aplicar animación a PictureFrame**

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation).  
2. Obtenga una referencia a la diapositiva mediante su índice.  
3. Agregue o obtenga un [PictureFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pictureframe) en la diapositiva.  
4. Obtenga la secuencia principal de efectos.  
5. Agregue un efecto de animación a [PictureFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pictureframe).  
6. Guarde la presentación en disco como un archivo PPTX.  

Este código Javascript le muestra cómo aplicar el efecto `Fly` a un marco de imagen:
```javascript
// Instancia una clase de presentación que representa un archivo de presentación.
var pres = new aspose.slides.Presentation();
try {
    // Carga la imagen que se añadirá a la colección de imágenes de la presentación
    var picture;
    var image = aspose.slides.Images.fromFile("aspose-logo.jpg");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) {
            image.dispose();
        }
    }
    // Añade un marco de imagen a la diapositiva
    var picFrame = pres.getSlides().get_Item(0).getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 50, 50, 100, 100, picture);
    // Obtiene la secuencia principal de la diapositiva.
    var sequence = pres.getSlides().get_Item(0).getTimeline().getMainSequence();
    // Añade el efecto de animación Fly desde la izquierda al marco de imagen
    var effect = sequence.addEffect(picFrame, aspose.slides.EffectType.Fly, aspose.slides.EffectSubtype.Left, aspose.slides.EffectTriggerType.OnClick);
    // Guarda el archivo PPTX en disco
    pres.save(path + "AnimImage_out.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Aplicar animación a Shape**

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation).  
2. Obtenga una referencia a la diapositiva mediante su índice.  
3. Agregue una [AutoShape] de tipo `rectangle`.  
4. Agregue una [AutoShape] `Bevel` (cuando este objeto se hace clic, se reproduce la animación).  
5. Cree una secuencia de efectos en la forma bevel.  
6. Cree una `UserPath` personalizada.  
7. Agregue comandos para mover a la `UserPath`.  
8. Guarde la presentación en disco como un archivo PPTX.  

Este código Javascript le muestra cómo aplicar el efecto `PathFootball` (ruta de fútbol) a una forma:
```javascript
// Instancia una clase Presentation que representa un archivo PPTX.
var pres = new aspose.slides.Presentation();
try {
    var sld = pres.getSlides().get_Item(0);
    // Crea el efecto PathFootball para una forma existente desde cero.
    var ashp = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 150, 150, 250, 25);
    ashp.addTextFrame("Animated TextBox");
    // Añade el efecto de animación PathFootBall
    pres.getSlides().get_Item(0).getTimeline().getMainSequence().addEffect(ashp, aspose.slides.EffectType.PathFootball, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    // Crea una especie de "botón".
    var shapeTrigger = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Bevel, 10, 10, 20, 20);
    // Crea una secuencia de efectos para este botón.
    var seqInter = pres.getSlides().get_Item(0).getTimeline().getInteractiveSequences().add(shapeTrigger);
    // Crea una ruta personalizada del usuario. Nuestro objeto se moverá solo después de que se haga clic en el botón.
    var fxUserPath = seqInter.addEffect(ashp, aspose.slides.EffectType.PathUser, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.OnClick);
    // Añade comandos para mover ya que la ruta creada está vacía.
    var motionBhv = fxUserPath.getBehaviors().get_Item(0);
    var pts = java.newArray("com.aspose.slides.Point2DFloat", [java.newInstanceSync("com.aspose.slides.Point2DFloat", 0.076, 0.59)]);
    motionBhv.getPath().add(aspose.slides.MotionCommandPathType.LineTo, pts, aspose.slides.MotionPathPointsType.Auto, true);
    pts[0] = java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(-0.076), java.newFloat(-0.59));
    motionBhv.getPath().add(aspose.slides.MotionCommandPathType.LineTo, pts, aspose.slides.MotionPathPointsType.Auto, false);
    motionBhv.getPath().add(aspose.slides.MotionCommandPathType.End, null, aspose.slides.MotionPathPointsType.Auto, false);
    // Escribe el archivo PPTX en disco
    pres.save("AnimExample_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Obtener los efectos de animación aplicados a Shape**

Los siguientes ejemplos le muestran cómo usar el método `getEffectsByShape` de la clase [Sequence](https://reference.aspose.com/slides/nodejs-java/aspose.slides/sequence/) para obtener todos los efectos de animación aplicados a una forma.

**Ejemplo 1: Obtener los efectos de animación aplicados a una forma en una diapositiva normal**

Previamente aprendió cómo agregar efectos de animación a formas en presentaciones de PowerPoint. El siguiente código de ejemplo le muestra cómo obtener los efectos aplicados a la primera forma de la primera diapositiva normal en la presentación `AnimExample_out.pptx`.
```javascript
var presentation = new aspose.slides.Presentation("AnimExample_out.pptx");
try {
    var firstSlide = presentation.getSlides().get_Item(0);

    // Obtiene la secuencia principal de animación de la diapositiva.
    var sequence = firstSlide.getTimeline().getMainSequence();

    // Obtiene la primera forma de la primera diapositiva.
    var shape = firstSlide.getShapes().get_Item(0);

    // Obtiene los efectos de animación aplicados a la forma.
    var shapeEffects = sequence.getEffectsByShape(shape);

    if (shapeEffects.length > 0) {
        console.log("The shape", shape.getName(), "has", shapeEffects.length, "animation effects.");
    }
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```


**Ejemplo 2: Obtener todos los efectos de animación, incluidos los heredados de marcadores de posición**

Si una forma en una diapositiva normal tiene marcadores de posición que están en la diapositiva de diseño y/o maestra, y se han agregado efectos de animación a esos marcadores, entonces todos los efectos de la forma se reproducirán durante la presentación, incluidos los heredados de los marcadores.

Supongamos que tenemos un archivo de presentación PowerPoint `sample.pptx` con una diapositiva que contiene solo una forma de pie de página con el texto "Made with Aspose.Slides" y se le ha aplicado el efecto **Random Bars** a la forma.

![Efecto de animación de forma de diapositiva](slide-shape-animation.png)

Supongamos también que el efecto **Split** se ha aplicado al marcador de posición del pie de página en la diapositiva **de diseño**.

![Efecto de animación de forma de diseño](layout-shape-animation.png)

Y finalmente, el efecto **Fly In** se ha aplicado al marcador de posición del pie de página en la diapositiva **maestra**.

![Efecto de animación de forma maestra](master-shape-animation.png)

El siguiente código de ejemplo le muestra cómo usar el método `getBasePlaceholder` de la clase [Shape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/) para acceder a los marcadores de posición de la forma y obtener los efectos de animación aplicados a la forma de pie de página, incluidos los heredados de los marcadores ubicados en las diapositivas de diseño y maestra.
```js
var presentation = new aspose.slides.Presentation("sample.pptx");

var slide = presentation.getSlides().get_Item(0);

// Get animation effects of the shape on the normal slide.
var shape = slide.getShapes().get_Item(0);
var shapeEffects = slide.getTimeline().getMainSequence().getEffectsByShape(shape);

// Get animation effects of the placeholder on the layout slide.
var layoutShape = shape.getBasePlaceholder();
var layoutShapeEffects = slide.getLayoutSlide().getTimeline().getMainSequence().getEffectsByShape(layoutShape);

// Get animation effects of the placeholder on the master slide.
var masterShape = layoutShape.getBasePlaceholder();
var masterShapeEffects = slide.getLayoutSlide().getMasterSlide().getTimeline().getMainSequence().getEffectsByShape(masterShape);

console.log("Main sequence of shape effects:");
printEffects(masterShapeEffects);
printEffects(layoutShapeEffects);
printEffects(shapeEffects);

presentation.dispose();
```

```js
function printEffects(effects) {
    for (const effect of effects) {
        console.log("Type:", effect.getType() + ", subtype:", effect.getSubtype());
    }
}
```


Salida:
```text
Main sequence of shape effects:
Type: 47, subtype: 2              // Volar, Inferior
Type: 134, subtype: 45            // Dividir, EntradaVertical
Type: 126, subtype: 22            // BarrasAleatorias, Horizontal
```


## **Cambiar propiedades de tiempo del efecto de animación**

Aspose.Slides para Node.js a través de Java le permite cambiar las propiedades de Tiempo de un efecto de animación.

Este es el panel de Tiempo de Animación en Microsoft PowerPoint:

![example1_image](shape-animation.png)

Estas son las correspondencias entre el Tiempo de PowerPoint y las propiedades de [Effect.Timing](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Effect#getTiming--):

- La lista desplegable **Start** de PowerPoint coincide con la propiedad [Effect.Timing.TriggerType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Timing#getTriggerType--).  
- El **Duration** de PowerPoint coincide con la propiedad [Effect.Timing.Duration](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Timing#getDuration--). La duración de una animación (en segundos) es el tiempo total que tarda la animación en completar un ciclo.  
- El **Delay** de PowerPoint coincide con la propiedad [Effect.Timing.TriggerDelayTime](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Timing#getTriggerDelayTime--).  

Así es como cambia las propiedades de Tiempo del efecto:

1. [Aplique](#apply-animation-to-shape) o obtenga el efecto de animación.  
2. Establezca nuevos valores para las propiedades de [Effect.Timing](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Effect#getTiming--) que necesite.  
3. Guarde el archivo PPTX modificado.  

Este código Javascript demuestra la operación:
```javascript
// Instancia una clase de presentación que representa un archivo de presentación.
var pres = new aspose.slides.Presentation("AnimExample_out.pptx");
try {
    // Obtiene la secuencia principal de la diapositiva.
    var sequence = pres.getSlides().get_Item(0).getTimeline().getMainSequence();
    // Obtiene el primer efecto de la secuencia principal.
    var effect = sequence.get_Item(0);
    // Cambia el TriggerType del efecto para iniciar al hacer clic
    effect.getTiming().setTriggerType(aspose.slides.EffectTriggerType.OnClick);
    // Cambia la duración del efecto
    effect.getTiming().setDuration(3.0);
    // Cambia el TriggerDelayTime del efecto
    effect.getTiming().setTriggerDelayTime(0.5);
    // Guarda el archivo PPTX en disco
    pres.save("AnimExample_changed.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Sonido del efecto de animación**

Aspose.Slides proporciona estas propiedades para trabajar con sonidos en efectos de animación: 

- `setSound(IAudio value)` para establecer el sonido asociado al efecto.  
- `setStopPreviousSound(boolean value)` para detener el sonido previo cuando se inicia un nuevo efecto.  

### **Agregar sonido al efecto de animación**

Este código Javascript le muestra cómo agregar un sonido al efecto de animación y detenerlo cuando comienza el siguiente efecto:
```javascript
var pres = new aspose.slides.Presentation("AnimExample_out.pptx");
try {
    // Añade audio a la colección de audio de la presentación
    var effectSound = pres.getAudios().addAudio(java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "sampleaudio.wav")));
    var firstSlide = pres.getSlides().get_Item(0);
    // Obtiene la secuencia principal de la diapositiva.
    var sequence = firstSlide.getTimeline().getMainSequence();
    // Obtiene el primer efecto de la secuencia principal
    var firstEffect = sequence.get_Item(0);
    // Verifica el efecto para "Sin sonido"
    if ((!firstEffect.getStopPreviousSound()) && (firstEffect.getSound() == null)) {
        // Añade sonido al primer efecto
        firstEffect.setSound(effectSound);
    }
    // Obtiene la primera secuencia interactiva de la diapositiva.
    var interactiveSequence = firstSlide.getTimeline().getInteractiveSequences().get_Item(0);
    // Establece la bandera del efecto "Stop previous sound"
    interactiveSequence.get_Item(0).setStopPreviousSound(true);
    // Guarda el archivo PPTX en disco
    pres.save("AnimExample_Sound_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


### **Extraer sonido del efecto de animación**

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/).  
2. Obtenga una referencia a la diapositiva mediante su índice.  
3. Obtenga la secuencia principal de efectos.  
4. Extraiga el método `setSound(IAudio value)` incrustado en cada efecto de animación.  

Este código Javascript le muestra cómo extraer el sonido incrustado en un efecto de animación:
```javascript
// Instancia una clase de presentación que representa un archivo de presentación.
var presentation = new aspose.slides.Presentation("EffectSound.pptx");
try {
    var slide = presentation.getSlides().get_Item(0);
    // Obtiene la secuencia principal de la diapositiva.
    var sequence = slide.getTimeline().getMainSequence();
    for (var i = 0; i < sequence.getCount(); i++) {
        var effect = sequence.get_Item(i);
        if (effect.getSound() == null) {
            continue;
        }
        // Extrae el sonido del efecto como matriz de bytes
        var audio = effect.getSound().getBinaryData();
    }
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```


## **Después de la animación**

Aspose.Slides para Node.js a través de Java le permite cambiar la propiedad Después de animación de un efecto de animación.

Este es el panel de Efecto de Animación y el menú ampliado en Microsoft PowerPoint:

![example1_image](shape-after-animation.png)

La lista desplegable **After animation** de PowerPoint coincide con estas propiedades: 

- El método [setAfterAnimationType(int value)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effect/#setAfterAnimationType-int-) que describe el tipo de después de animación;  
  * PowerPoint **More Colors** coincide con el tipo [AfterAnimationType.Color](https://reference.aspose.com/slides/nodejs-java/aspose.slides/afteranimationtype/#Color).  
  * PowerPoint **Don't Dim** coincide con el tipo [AfterAnimationType.DoNotDim](https://reference.aspose.com/slides/nodejs-java/aspose.slides/afteranimationtype/#DoNotDim) (tipo predeterminado).  
  * PowerPoint **Hide After Animation** coincide con el tipo [AfterAnimationType.HideAfterAnimation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/afteranimationtype/#HideAfterAnimation).  
  * PowerPoint **Hide on Next Mouse Click** coincide con el tipo [AfterAnimationType.HideOnNextMouseClick](https://reference.aspose.com/slides/nodejs-java/aspose.slides/afteranimationtype/#HideOnNextMouseClick).  
- El método [setAfterAnimationColor(IColorFormat value)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effect/#setAfterAnimationColor-aspose.slides.IColorFormat-) que define un formato de color después de la animación. Este método funciona en conjunto con el tipo [AfterAnimationType.Color](https://reference.aspose.com/slides/nodejs-java/aspose.slides/afteranimationtype/#Color). Si cambia el tipo a otro, el color después de la animación se borrará.  

Este código Javascript le muestra cómo cambiar un efecto después de la animación:
```javascript
// Instancia una clase de presentación que representa un archivo de presentación
var pres = new aspose.slides.Presentation("AnimImage_out.pptx");
try {
    var firstSlide = pres.getSlides().get_Item(0);
    // Obtiene el primer efecto de la secuencia principal
    var firstEffect = firstSlide.getTimeline().getMainSequence().get_Item(0);
    // Cambia el tipo de animación posterior a Color
    firstEffect.setAfterAnimationType(aspose.slides.AfterAnimationType.Color);
    // Establece el color de atenuación de la animación posterior
    firstEffect.getAfterAnimationColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    // Guarda el archivo PPTX en disco
    pres.save("AnimImage_AfterAnimation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Animar texto**

Aspose.Slides proporciona estas propiedades para trabajar con el bloque *Animar texto* de un efecto de animación:

- `setAnimateTextType(int value)` que describe el tipo de animación de texto del efecto. El texto de la forma puede animarse:  
  - Todo a la vez ([AnimateTextType.AllAtOnce](https://reference.aspose.com/slides/nodejs-java/aspose.slides/animatetexttype/#AllAtOnce)).  
  - Por palabra ([AnimateTextType.ByWord](https://reference.aspose.com/slides/nodejs-java/aspose.slides/animatetexttype/#ByWord)).  
  - Por letra ([AnimateTextType.ByLetter](https://reference.aspose.com/slides/nodejs-java/aspose.slides/animatetexttype/#ByLetter)).  
- `setDelayBetweenTextParts(float value)` establece un retraso entre las partes de texto animadas (palabras o letras). Un valor positivo especifica el porcentaje de la duración del efecto. Un valor negativo especifica el retraso en segundos.  

Así es como puede cambiar las propiedades de animar texto del efecto:

1. Aplique o obtenga el efecto de animación.  
2. Establezca el método `setBuildType(int value)` al valor [BuildType.AsOneObject](https://reference.aspose.com/slides/nodejs-java/aspose.slides/buildtype/#AsOneObject) para desactivar el modo *By Paragraphs*.  
3. Establezca nuevos valores para las propiedades `setAnimateTextType(int value)` y `setDelayBetweenTextParts(float value)`.  
4. Guarde el archivo PPTX modificado.  

Este código Javascript demuestra la operación:
```javascript
// Instancia una clase de presentación que representa un archivo de presentación.
var pres = new aspose.slides.Presentation("AnimTextBox_out.pptx");
try {
    var firstSlide = pres.getSlides().get_Item(0);
    // Obtiene el primer efecto de la secuencia principal
    var firstEffect = firstSlide.getTimeline().getMainSequence().get_Item(0);
    // Cambia el tipo de animación de texto del efecto a "Como un solo objeto"
    firstEffect.getTextAnimation().setBuildType(aspose.slides.BuildType.AsOneObject);
    // Cambia el tipo de animación de texto del efecto a "Por palabra"
    firstEffect.setAnimateTextType(aspose.slides.AnimateTextType.ByWord);
    // Establece el retraso entre palabras al 20% de la duración del efecto
    firstEffect.setDelayBetweenTextParts(20.0);
    // Guarda el archivo PPTX en disco
    pres.save("AnimTextBox_AnimateText.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Preguntas frecuentes**

**¿Cómo puedo asegurar que las animaciones se conserven al publicar la presentación en la web?**

[Exportar a HTML5](/slides/es/nodejs-java/export-to-html5/) y habilite las [opciones](/slides/es/nodejs-java/aspose.slides/html5options/) responsables de las animaciones de [shape](/slides/es/nodejs-java/aspose.slides/html5options/setanimateshapes/) y de [transition](/slides/es/nodejs-java/aspose.slides/html5options/setanimatetransitions/). El HTML simple no reproduce animaciones de diapositivas, mientras que HTML5 sí.

**¿Cómo afecta cambiar el orden Z (orden de capas) de las formas a la animación?**

La animación y el orden de dibujo son independientes: un efecto controla el momento y el tipo de aparición/desaparición, mientras que el [z-order](/slides/es/nodejs-java/aspose.slides/shape/getzorderposition/) determina qué cubre a qué. El resultado visible se define por su combinación. (Este es el comportamiento general de PowerPoint; el modelo de efectos y formas de Aspose.Slides sigue la misma lógica.)

**¿Existen limitaciones al convertir animaciones a video para ciertos efectos?**

En general, [las animaciones son compatibles](/slides/es/nodejs-java/convert-powerpoint-to-video/), pero casos raros o efectos específicos pueden renderizarse de manera diferente. Se recomienda probar con los efectos que use y con la versión de la biblioteca.