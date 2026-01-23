---
title: Aplicar animaciones de forma en presentaciones usando PHP
linktitle: Animación de forma
type: docs
weight: 60
url: /es/php-java/shape-animation/
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
- PHP
- Aspose.Slides
description: "Descubra cómo crear y personalizar animaciones de forma en presentaciones de PowerPoint con Aspose.Slides para PHP a través de Java. ¡Distíngase!"
---

Las animaciones son efectos visuales que pueden aplicarse a textos, imágenes, formas o [gráficos](https://docs.aspose.com/slides/php-java/animated-charts/). Dan vida a las presentaciones o a sus componentes.

## **¿Por qué usar animaciones en presentaciones?**

Usando animaciones, puedes  

* controlar el flujo de información  
* destacar puntos importantes  
* incrementar el interés o la participación de la audiencia  
* hacer que el contenido sea más fácil de leer, asimilar o procesar  
* captar la atención de los lectores o espectadores hacia partes importantes de la presentación  

PowerPoint ofrece muchas opciones y herramientas para animaciones y efectos de animación en las categorías de **entrada**, **salida**, **énfasis** y **trayectorias de movimiento**. 

## **Animaciones en Aspose.Slides**

* Aspose.Slides proporciona las clases y tipos que necesita para trabajar con animaciones bajo el espacio de nombres `Aspose.Slides.Animation`,  
* Aspose.Slides ofrece más de **150 efectos de animación** bajo la enumeración [EffectType](https://reference.aspose.com/slides/php-java/aspose.slides/effecttype). Estos efectos son esencialmente los mismos (o equivalentes) que se utilizan en PowerPoint.  

## **Aplicar animación a un TextBox**

Aspose.Slides para PHP a través de Java le permite aplicar animación al texto de una forma.

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).  
2. Obtenga una referencia a una diapositiva mediante su índice.  
3. Agregue un [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) rectangular.  
4. Añada texto al [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/#getTextFrame) de `AutoShape`.  
5. Obtenga la secuencia principal de efectos.  
6. Agregue un efecto de animación a [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/).  
7. Utilice el método `TextAnimation.setBuildType` y el valor de la enumeración `BuildType`.  
8. Guarde la presentación en disco como un archivo PPTX.  

Este código PHP le muestra cómo aplicar el efecto `Fade` a AutoShape y establecer la animación de texto al valor *By 1st Level Paragraphs*:
```php
  # Instancia una clase de presentación que representa un archivo de presentación.
  $pres = new Presentation();
  try {
    $sld = $pres->getSlides()->get_Item(0);
    # Añade un nuevo AutoShape con texto
    $autoShape = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 20, 150, 100);
    $textFrame = $autoShape->getTextFrame();
    $textFrame->setText("First paragraph \nSecond paragraph \n Third paragraph");
    # Obtiene la secuencia principal de la diapositiva.
    $sequence = $sld->getTimeline()->getMainSequence();
    # Añade efecto de animación Fade a la forma
    $effect = $sequence->addEffect($autoShape, EffectType::Fade, EffectSubType::None, EffectTriggerType::OnClick);
    # Anima el texto de la forma por párrafos de primer nivel
    $effect->getTextAnimation()->setBuildType(BuildType::ByLevelParagraphs1);
    # Guarda el archivo PPTX en disco
    $pres->save($path . "AnimText_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


{{%  alert color="primary"  %}} 

Además de aplicar animaciones al texto, también puede aplicar animaciones a un único [Paragraph](https://reference.aspose.com/slides/php-java/aspose.slides/paragraph/). Vea [**Texto animado**](/slides/es/php-java/animated-text/).

{{% /alert %}} 

## **Aplicar animación a un PictureFrame**

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).  
2. Obtenga una referencia a una diapositiva mediante su índice.  
3. Agregue o obtenga un [PictureFrame](https://reference.aspose.com/slides/php-java/aspose.slides/pictureframe) en la diapositiva.  
4. Obtenga la secuencia principal de efectos.  
5. Añada un efecto de animación a [PictureFrame](https://reference.aspose.com/slides/php-java/aspose.slides/pictureframe).  
6. Guarde la presentación en disco como un archivo PPTX.  

Este código PHP le muestra cómo aplicar el efecto `Fly` a un marco de imagen:
```php
  # Instancia una clase de presentación que representa un archivo de presentación.
  $pres = new Presentation();
  try {
    # Carga la imagen que se añadirá a la colección de imágenes de la presentación
    $picture;
    $image = Images->fromFile("aspose-logo.jpg");
    try {
      $picture = $pres->getImages()->addImage($image);
    } finally {
      if (!java_is_null($image)) {
        $image->dispose();
      }
    }
    # Añade un marco de imagen a la diapositiva
    $picFrame = $pres->getSlides()->get_Item(0)->getShapes()->addPictureFrame(ShapeType::Rectangle, 50, 50, 100, 100, $picture);
    # Obtiene la secuencia principal de la diapositiva.
    $sequence = $pres->getSlides()->get_Item(0)->getTimeline()->getMainSequence();
    # Añade la animación Fly desde la izquierda al marco de imagen
    $effect = $sequence->addEffect($picFrame, EffectType::Fly, EffectSubType::Left, EffectTriggerType::OnClick);
    # Guarda el archivo PPTX en disco
    $pres->save($path . "AnimImage_out.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Aplicar animación a una forma**

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).  
2. Obtenga una referencia a una diapositiva mediante su índice.  
3. Agregue un [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) rectangular.  
4. Agregue una [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) con bisel (cuando se hace clic en este objeto, se reproduce la animación).  
5. Cree una secuencia de efectos en la forma con bisel.  
6. Cree un `UserPath` personalizado.  
7. Añada comandos para mover al `UserPath`.  
8. Guarde la presentación en disco como un archivo PPTX.  

Este código PHP le muestra cómo aplicar el efecto `PathFootball` (ruta de fútbol) a una forma:
```php
  # Instancia una clase Presentation que representa un archivo PPTX.
  $pres = new Presentation();
  try {
    $sld = $pres->getSlides()->get_Item(0);
    # Crea el efecto PathFootball para una forma existente desde cero.
    $ashp = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 150, 150, 250, 25);
    $ashp->addTextFrame("Animated TextBox");
    # Añade el efecto de animación PathFootball
    $pres->getSlides()->get_Item(0)->getTimeline()->getMainSequence()->addEffect($ashp, EffectType::PathFootball, EffectSubType::None, EffectTriggerType::AfterPrevious);
    # Crea una especie de "botón".
    $shapeTrigger = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Bevel, 10, 10, 20, 20);
    # Crea una secuencia de efectos para este botón.
    $seqInter = $pres->getSlides()->get_Item(0)->getTimeline()->getInteractiveSequences()->add($shapeTrigger);
    # Crea una ruta de usuario personalizada. Nuestro objeto se moverá solo después de que se haga clic en el botón.
    $fxUserPath = $seqInter->addEffect($ashp, EffectType::PathUser, EffectSubType::None, EffectTriggerType::OnClick);
    # Añade comandos para mover ya que la ruta creada está vacía.
    $motionBhv = $fxUserPath->getBehaviors()->get_Item(0);
    $pts = new Point2DFloat[1];
    $pts[0] = new Point2DFloat(0.076, 0.59);
    $motionBhv->getPath()->add(MotionCommandPathType::LineTo, $pts, MotionPathPointsType::Auto, true);
    $pts[0] = new Point2DFloat(-0.076, -0.59);
    $motionBhv->getPath()->add(MotionCommandPathType::LineTo, $pts, MotionPathPointsType::Auto, false);
    $motionBhv->getPath()->add(MotionCommandPathType::End, null, MotionPathPointsType::Auto, false);
    # Escribe el archivo PPTX en disco
    $pres->save("AnimExample_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Obtener los efectos de animación aplicados a una forma**

Los siguientes ejemplos le muestran cómo usar el método `getEffectsByShape` de la clase [Sequence](https://reference.aspose.com/slides/php-java/aspose.slides/sequence/) para obtener todos los efectos de animación aplicados a una forma.

**Ejemplo 1: Obtener efectos de animación aplicados a una forma en una diapositiva normal**

Anteriormente, aprendió cómo añadir efectos de animación a formas en presentaciones de PowerPoint. El siguiente fragmento de código muestra cómo obtener los efectos aplicados a la primera forma en la primera diapositiva normal de la presentación `AnimExample_out.pptx`.
```php
  $Array = new java_class("java.lang.reflect.Array");
  $presentation = new Presentation("AnimExample_out.pptx");

  try {
    $firstSlide = $presentation->getSlides()->get_Item(0);

    # Obtiene la secuencia principal de animación de la diapositiva.
    $sequence = $firstSlide->getTimeline()->getMainSequence();

    # Obtiene la primera forma de la primera diapositiva.
    $shape = $firstSlide->getShapes()->get_Item(0);

    # Obtiene los efectos de animación aplicados a la forma.
    $shapeEffects = $sequence->getEffectsByShape($shape);

    if (java_values($Array->getLength($shapeEffects)) > 0) {
      echo("The shape " . $shape->getName() . " has " . $Array->getLength($shapeEffects) . " animation effects.");
    }
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```


**Ejemplo 2: Obtener todos los efectos de animación, incluidos los heredados de los marcadores de posición**

Si una forma en una diapositiva normal tiene marcadores de posición que están en la diapositiva de diseño y/o en la diapositiva maestra, y se han añadido efectos de animación a esos marcadores, entonces todos los efectos de la forma se reproducirán durante la presentación, incluidos los heredados de los marcadores.

Supongamos que tenemos un archivo de presentación PowerPoint `sample.pptx` con una diapositiva que contiene solo una forma de pie de página con el texto "Made with Aspose.Slides" y se ha aplicado el efecto **Random Bars** a la forma.

![Efecto de animación de forma de diapositiva](slide-shape-animation.png)

Supongamos también que el efecto **Split** se ha aplicado al marcador de posición del pie de página en la diapositiva **de diseño**.

![Efecto de animación de forma del diseño](layout-shape-animation.png)

Y, por último, el efecto **Fly In** se ha aplicado al marcador de posición del pie de página en la diapositiva **maestra**.

![Efecto de animación de forma maestra](master-shape-animation.png)

El siguiente fragmento de código muestra cómo usar el método `getBasePlaceholder` de la clase [Shape](https://reference.aspose.com/slides/php-java/aspose.slides/shape/) para acceder a los marcadores de posición de la forma y obtener los efectos de animación aplicados a la forma del pie de página, incluidos los heredados de los marcadores ubicados en las diapositivas de diseño y maestra.
```php
$presentation = new Presentation("sample.pptx");

$slide = $presentation->getSlides()->get_Item(0);

// Obtiene los efectos de animación de la forma en la diapositiva normal.
$shape = $slide->getShapes()->get_Item(0);
$shapeEffects = $slide->getTimeline()->getMainSequence()->getEffectsByShape($shape);

// Obtiene los efectos de animación del marcador de posición en la diapositiva de diseño.
$layoutShape = $shape->getBasePlaceholder();
$layoutShapeEffects = $slide->getLayoutSlide()->getTimeline()->getMainSequence()->getEffectsByShape($layoutShape);

// Obtiene los efectos de animación del marcador de posición en la diapositiva maestra.
$masterShape = $layoutShape->getBasePlaceholder();
$masterShapeEffects = $slide->getLayoutSlide()->getMasterSlide()->getTimeline()->getMainSequence()->getEffectsByShape($masterShape);

echo "Main sequence of shape effects:" . PHP_EOL;
printEffects($masterShapeEffects);
printEffects($layoutShapeEffects);
printEffects($shapeEffects);

$presentation->dispose();
```

```php
function printEffects($effects) {
    foreach ($effects as $effect) {
        echo "Type: " . $effect->getType() . ", subtype: " . $effect->getSubtype() . PHP_EOL;
    }
}
```


Salida:
```text
Main sequence of shape effects:
Type: 47, subtype: 2              // Fly, Abajo
Type: 134, subtype: 45            // Split, VerticalIn
Type: 126, subtype: 22            // RandomBars, Horizontal
```


## **Cambiar los métodos de sincronización de efectos de animación**

Aspose.Slides para PHP a través de Java le permite cambiar las propiedades de sincronización de un efecto de animación.

![example1_image](shape-animation.png)

Estas son las correspondencias entre la sincronización de PowerPoint y las propiedades de [Effect Timing](https://reference.aspose.com/slides/php-java/aspose.slides/effect/#getTiming):

- La lista desplegable **Inicio** de sincronización de PowerPoint coincide con el método [Timing::getTriggerType](https://reference.aspose.com/slides/php-java/aspose.slides/timing/#getTriggerType).  
- La lista desplegable **Duración** de sincronización de PowerPoint coincide con el método [Timing::getDuration](https://reference.aspose.com/slides/php-java/aspose.slides/timing/#getDuration). La duración de una animación (en segundos) es el tiempo total que tarda la animación en completar un ciclo.  
- La lista desplegable **Retraso** de sincronización de PowerPoint coincide con el método [Timing::getTriggerDelayTime](https://reference.aspose.com/slides/php-java/aspose.slides/timing/#getTriggerDelayTime).  

Así es como se cambian las propiedades de sincronización del efecto:

1. [Aplicar](#apply-animation-to-shape) o obtener el efecto de animación.  
2. Establezca los nuevos valores que necesite usando el método [Effect::getTiming](https://reference.aspose.com/slides/php-java/aspose.slides/effect/#getTiming).  
3. Guarde el archivo PPTX modificado.  

Este código PHP demuestra la operación:
```php
  # Instancia una clase de presentación que representa un archivo de presentación.
  $pres = new Presentation("AnimExample_out.pptx");
  try {
    # Obtiene la secuencia principal de la diapositiva.
    $sequence = $pres->getSlides()->get_Item(0)->getTimeline()->getMainSequence();
    # Obtiene el primer efecto de la secuencia principal.
    $effect = $sequence->get_Item(0);
    # Cambia el TriggerType del efecto para iniciar con clic
    $effect->getTiming()->setTriggerType(EffectTriggerType::OnClick);
    # Cambia la duración del efecto
    $effect->getTiming()->setDuration(3.0);
    # Cambia el TriggerDelayTime del efecto
    $effect->getTiming()->setTriggerDelayTime(0.5);
    # Guarda el archivo PPTX en disco
    $pres->save("AnimExample_changed.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Sonido del efecto de animación**

Aspose.Slides proporciona estos métodos para trabajar con sonidos en efectos de animación: 

- [setSound(IAudio value)](https://reference.aspose.com/slides/php-java/aspose.slides/effect/#setSound-com.aspose.slides.IAudio-)  
- [setStopPreviousSound(boolean value)](https://reference.aspose.com/slides/php-java/aspose.slides/effect/#setStopPreviousSound-boolean-)  

### **Agregar sonido a un efecto de animación**

Este código PHP le muestra cómo agregar un sonido a un efecto de animación y detenerlo cuando comienza el siguiente efecto:
```php
  $pres = new Presentation("AnimExample_out.pptx");
  try {
    # Añade audio a la colección de audio de la presentación
$Array = new JavaClass("java.lang.reflect.Array");
$Byte = (new JavaClass("java.lang.Byte"))->TYPE;
try {
    $dis = new Java("java.io.DataInputStream", new Java("java.io.FileInputStream", "sampleaudio.wav"));
    $bytes = $Array->newInstance($Byte, $dis->available());
    $dis->readFully($bytes);
} finally {
    if (!java_is_null($dis)) $dis->close();
}
    $effectSound = $pres->getAudios()->addAudio($bytes);

    $firstSlide = $pres->getSlides()->get_Item(0);
    # Obtiene la secuencia principal de la diapositiva.
    $sequence = $firstSlide->getTimeline()->getMainSequence();
    # Obtiene el primer efecto de la secuencia principal
    $firstEffect = $sequence->get_Item(0);
    # Comprueba el efecto para "Sin sonido"
    if (java_is_null(!$firstEffect->getStopPreviousSound() && $firstEffect->getSound())) {
      # Añade sonido al primer efecto
      $firstEffect->setSound($effectSound);
    }
    # Obtiene la primera secuencia interactiva de la diapositiva.
    $interactiveSequence = $firstSlide->getTimeline()->getInteractiveSequences()->get_Item(0);
    # Establece la bandera "Detener sonido anterior" del efecto
    $interactiveSequence->get_Item(0)->setStopPreviousSound(true);
    # Guarda el archivo PPTX en disco
    $pres->save("AnimExample_Sound_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


### **Extraer el sonido de un efecto de animación**

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).  
2. Obtenga una referencia a una diapositiva mediante su índice.  
3. Obtenga la secuencia principal de efectos.  
4. Extraiga el sonido incrustado en cada efecto de animación mediante [setSound(IAudio value)](https://reference.aspose.com/slides/php-java/aspose.slides/effect/#setSound-com.aspose.slides.IAudio-).  

Este código PHP le muestra cómo extraer el sonido incrustado en un efecto de animación:
```php
  # Instancia una clase de presentación que representa un archivo de presentación.
  $presentation = new Presentation("EffectSound.pptx");
  try {
    $slide = $presentation->getSlides()->get_Item(0);
    # Obtiene la secuencia principal de la diapositiva.
    $sequence = $slide->getTimeline()->getMainSequence();
    foreach($sequence as $effect) {
      if (java_is_null($effect->getSound())) {
        continue;
      }
      # Extrae el sonido del efecto en un array de bytes
      $audio = $effect->getSound()->getBinaryData();
    }
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```


## **Después de la animación**

Aspose.Slides para PHP a través de Java le permite cambiar la propiedad After animation de un efecto de animación.

![example1_image](shape-after-animation.png)

La lista desplegable **After animation** del efecto de PowerPoint coincide con estos métodos: 

- [setAfterAnimationType(int value)](https://reference.aspose.com/slides/php-java/aspose.slides/effect/#setAfterAnimationType) método que describe el tipo After animation:  
  * PowerPoint **More Colors** coincide con el tipo [AfterAnimationType::Color](https://reference.aspose.com/slides/php-java/aspose.slides/afteranimationtype/#Color);  
  * PowerPoint **Don't Dim** coincide con el tipo [AfterAnimationType::DoNotDim](https://reference.aspose.com/slides/php-java/aspose.slides/afteranimationtype/#DoNotDim) (tipo predeterminado);  
  * PowerPoint **Hide After Animation** coincide con el tipo [AfterAnimationType::HideAfterAnimation](https://reference.aspose.com/slides/php-java/aspose.slides/afteranimationtype/#HideAfterAnimation);  
  * PowerPoint **Hide on Next Mouse Click** coincide con el tipo [AfterAnimationType::HideOnNextMouseClick](https://reference.aspose.com/slides/php-java/aspose.slides/afteranimationtype/#HideOnNextMouseClick).  
- [setAfterAnimationColor(IColorFormat value)](https://reference.aspose.com/slides/php-java/aspose.slides/effect/#setAfterAnimationColor) método que define el formato de color After animation. Este método funciona junto con el tipo [AfterAnimationType::Color](https://reference.aspose.com/slides/php-java/aspose.slides/afteranimationtype/#Color). Si cambia el tipo a otro, el color After animation se borrará.  

Este código PHP le muestra cómo cambiar un efecto After animation:
```php
  # Instancia una clase de presentación que representa un archivo de presentación
  $pres = new Presentation("AnimImage_out.pptx");
  try {
    $firstSlide = $pres->getSlides()->get_Item(0);
    # Obtiene el primer efecto de la secuencia principal
    $firstEffect = $firstSlide->getTimeline()->getMainSequence()->get_Item(0);
    # Cambia el tipo de animación posterior a Color
    $firstEffect->setAfterAnimationType(AfterAnimationType::Color);
    # Define el color de atenuación de la animación posterior
    $firstEffect->getAfterAnimationColor()->setColor(java("java.awt.Color")->BLUE);
    # Guarda el archivo PPTX en disco
    $pres->save("AnimImage_AfterAnimation.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Animar texto**

Aspose.Slides proporciona estos métodos para trabajar con el bloque *Animate text* de un efecto de animación:

- [setAnimateTextType(int value)](https://reference.aspose.com/slides/php-java/aspose.slides/effect/#setAnimateTextType) que describe el tipo de animación de texto del efecto. El texto de la forma puede animarse:  
  - Todo a la vez ([AnimateTextType::AllAtOnce](https://reference.aspose.com/slides/php-java/aspose.slides/animatetexttype/#AllAtOnce));  
  - Por palabra ([AnimateTextType::ByWord](https://reference.aspose.com/slides/php-java/aspose.slides/animatetexttype/#ByWord));  
  - Por letra ([AnimateTextType::ByLetter](https://reference.aspose.com/slides/php-java/aspose.slides/animatetexttype/#ByLetter)).  
- [setDelayBetweenTextParts(float value)](https://reference.aspose.com/slides/php-java/aspose.slides/effect/#setDelayBetweenTextParts) establece un retraso entre las partes de texto animado (palabras o letras). Un valor positivo especifica el porcentaje de la duración del efecto. Un valor negativo especifica el retraso en segundos.  

Así es como puede cambiar las propiedades *Animate text* del efecto:

1. [Aplicar](#apply-animation-to-shape) o obtener el efecto de animación.  
2. Use el método [setBuildType(int value)](https://reference.aspose.com/slides/php-java/aspose.slides/textanimation/#setBuildType) y el valor [BuildType::AsOneObject](https://reference.aspose.com/slides/php-java/aspose.slides/buildtype/#AsOneObject) para desactivar el modo de animación *By Paragraphs*.  
3. Establezca nuevos valores usando los métodos [setAnimateTextType(int value)](https://reference.aspose.com/slides/php-java/aspose.slides/effect/#setAnimateTextType) y [setDelayBetweenTextParts(float value)](https://reference.aspose.com/slides/php-java/aspose.slides/effect/#setDelayBetweenTextParts).  
4. Guarde el archivo PPTX modificado.  

Este código PHP demuestra la operación:
```php
  # Instancia una clase de presentación que representa un archivo de presentación.
  $pres = new Presentation("AnimTextBox_out.pptx");
  try {
    $firstSlide = $pres->getSlides()->get_Item(0);
    # Obtiene el primer efecto de la secuencia principal
    $firstEffect = $firstSlide->getTimeline()->getMainSequence()->get_Item(0);
    # Cambia el tipo de animación de texto del efecto a "As One Object"
    $firstEffect->getTextAnimation()->setBuildType(BuildType::AsOneObject);
    # Cambia el tipo de animación de texto del efecto a "By word"
    $firstEffect->setAnimateTextType(AnimateTextType::ByWord);
    # Establece el retraso entre palabras al 20% de la duración del efecto
    $firstEffect->setDelayBetweenTextParts(20.0);
    # Guarda el archivo PPTX en disco
    $pres->save("AnimTextBox_AnimateText.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Preguntas frecuentes**

**¿Cómo puedo garantizar que las animaciones se conserven al publicar la presentación en la web?**

[Exportar a HTML5](/slides/es/php-java/export-to-html5/) y habilite las [opciones](https://reference.aspose.com/slides/php-java/aspose.slides/html5options/) responsables de las animaciones de [forma](https://reference.aspose.com/slides/php-java/aspose.slides/html5options/setanimateshapes/) y de [transición](https://reference.aspose.com/slides/php-java/aspose.slides/html5options/setanimatetransitions/). El HTML plano no reproduce animaciones de diapositivas, mientras que HTML5 sí.

**¿Cómo afecta al cambiar el orden Z (orden de capas) de las formas a la animación?**

El orden Z y el orden de dibujo son independientes: un efecto controla el momento y el tipo de aparición/desaparición, mientras que el [orden Z](https://reference.aspose.com/slides/php-java/aspose.slides/shape/getzorderposition/) determina qué cubre a qué. El resultado visible está definido por su combinación. (Este es el comportamiento general de PowerPoint; el modelo de efectos y formas de Aspose.Slides sigue la misma lógica.)

**¿Existen limitaciones al convertir animaciones a vídeo para ciertos efectos?**

En general, [las animaciones son compatibles](/slides/es/php-java/convert-powerpoint-to-video/), pero casos raros o efectos específicos pueden renderizarse de forma diferente. Se recomienda probar con los efectos que utilice y con la versión de la biblioteca.