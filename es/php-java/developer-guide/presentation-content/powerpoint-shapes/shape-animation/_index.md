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
description: "Descubre cómo crear y personalizar animaciones de forma en presentaciones de PowerPoint con Aspose.Slides para PHP a través de Java. ¡Destaca!"
---

Las animaciones son efectos visuales que pueden aplicarse a textos, imágenes, formas o [gráficos](https://docs.aspose.com/slides/php-java/animated-charts/). Dan vida a las presentaciones o a sus componentes.

## **¿Por qué usar animaciones en presentaciones?**

Con animaciones, puedes  

* controlar el flujo de la información  
* resaltar puntos importantes  
* aumentar el interés o la participación de tu audiencia  
* hacer que el contenido sea más fácil de leer, asimilar o procesar  
* atraer la atención de los lectores o espectadores a las partes importantes de una presentación  

PowerPoint ofrece muchas opciones y herramientas para animaciones y efectos de animación en las categorías **entrada**, **salida**, **énfasis** y **trayectorias de movimiento**.  

## **Animaciones en Aspose.Slides**

* Aspose.Slides proporciona las clases y tipos que necesitas para trabajar con animaciones bajo el espacio de nombres `Aspose.Slides.Animation`,  
* Aspose.Slides ofrece más de **150 efectos de animación** bajo la enumeración [EffectType](https://reference.aspose.com/slides/php-java/aspose.slides/effecttype). Estos efectos son esencialmente los mismos (o equivalentes) que se utilizan en PowerPoint.  

## **Aplicar animación a un TextBox**

Aspose.Slides for PHP via Java permite aplicar animación al texto de una forma.

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).  
2. Obtén una referencia a una diapositiva mediante su índice.  
3. Añade una `rectangle` [IAutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/iautoshape).  
4. Añade texto a [IAutoShape.TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/IAutoShape#addTextFrame-java.lang.String-).  
5. Obtén la secuencia principal de efectos.  
6. Añade un efecto de animación a [IAutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/iautoshape).  
7. Establece la propiedad `TextAnimation.BuildType` al valor de la enumeración `BuildType`.  
8. escribe la presentación en disco como archivo PPTX.  

Este código PHP muestra cómo aplicar el efecto `Fade` a AutoShape y establecer la animación de texto al valor *By 1st Level Paragraphs*:
```php
  # Instancia una clase de presentación que representa un archivo de presentación.
  $pres = new Presentation();
  try {
    $sld = $pres->getSlides()->get_Item(0);
    # Añade una nueva AutoShape con texto
    $autoShape = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 20, 150, 100);
    $textFrame = $autoShape->getTextFrame();
    $textFrame->setText("First paragraph \nSecond paragraph \n Third paragraph");
    # Obtiene la secuencia principal de la diapositiva.
    $sequence = $sld->getTimeline()->getMainSequence();
    # Añade el efecto de animación Fade a la forma
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

Además de aplicar animaciones al texto, también puedes aplicarlas a un solo [Paragraph](https://reference.aspose.com/slides/php-java/aspose.slides/iparagraph). Consulta [**Texto animado**](/slides/es/php-java/animated-text/).  

{{% /alert %}}  

## **Aplicar animación a un PictureFrame**

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).  
2. Obtén una referencia a una diapositiva mediante su índice.  
3. Añade o recupera un [PictureFrame](https://reference.aspose.com/slides/php-java/aspose.slides/pictureframe) en la diapositiva.  
4. Obtén la secuencia principal de efectos.  
5. Añade un efecto de animación a [PictureFrame](https://reference.aspose.com/slides/php-java/aspose.slides/pictureframe).  
6. escribe la presentación en disco como archivo PPTX.  

Este código PHP muestra cómo aplicar el efecto `Fly` a un marco de imagen:
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
    # Añade el efecto de animación Fly from Left al marco de imagen
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


## **Aplicar animación a una Shape**

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).  
2. Obtén una referencia a una diapositiva mediante su índice.  
3. Añade una `rectangle` [IAutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/iautoshape).  
4. Añade un `Bevel` [IAutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/iautoshape) (al hacer clic en este objeto, se reproducirá la animación).  
5. Crea una secuencia de efectos sobre la forma de bisel.  
6. Crea una `UserPath` personalizada.  
7. Añade comandos para mover a la `UserPath`.  
8. escribe la presentación en disco como archivo PPTX.  

Este código PHP muestra cómo aplicar el efecto `PathFootball` (ruta de fútbol) a una forma:
```php
  # Instancia una clase Presentation que representa un archivo PPTX.
  $pres = new Presentation();
  try {
    $sld = $pres->getSlides()->get_Item(0);
    # Crea el efecto PathFootball para una forma existente desde cero.
    $ashp = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 150, 150, 250, 25);
    $ashp->addTextFrame("Animated TextBox");
    # Añade el efecto de animación PathFootBall
    $pres->getSlides()->get_Item(0)->getTimeline()->getMainSequence()->addEffect($ashp, EffectType::PathFootball, EffectSubType::None, EffectTriggerType::AfterPrevious);
    # Crea algún tipo de "button".
    $shapeTrigger = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Bevel, 10, 10, 20, 20);
    # Crea una secuencia de efectos para este botón.
    $seqInter = $pres->getSlides()->get_Item(0)->getTimeline()->getInteractiveSequences()->add($shapeTrigger);
    # Crea una ruta de usuario personalizada. Nuestro objeto se moverá solo después de que se haga clic en el botón.
    $fxUserPath = $seqInter->addEffect($ashp, EffectType::PathUser, EffectSubType::None, EffectTriggerType::OnClick);
    # Añade comandos de movimiento ya que la ruta creada está vacía.
    $motionBvh = $fxUserPath->getBehaviors()->get_Item(0);
    $pts = new Point2DFloat[1];
    $pts[0] = new Point2DFloat(0.076, 0.59);
    $motionBvh->getPath()->add(MotionCommandPathType::LineTo, $pts, MotionPathPointsType::Auto, true);
    $pts[0] = new Point2DFloat(-0.076, -0.59);
    $motionBvh->getPath()->add(MotionCommandPathType::LineTo, $pts, MotionPathPointsType::Auto, false);
    $motionBvh->getPath()->add(MotionCommandPathType::End, null, MotionPathPointsType::Auto, false);
    # Escribe el archivo PPTX en disco
    $pres->save("AnimExample_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Obtener los efectos de animación aplicados a una Shape**

Los ejemplos siguientes muestran cómo usar el método `getEffectsByShape` de la clase [Sequence](https://reference.aspose.com/slides/php-java/aspose.slides/sequence/) para obtener todos los efectos de animación aplicados a una forma.

**Ejemplo 1: Obtener efectos de animación aplicados a una forma en una diapositiva normal**

Anteriormente aprendiste cómo añadir efectos de animación a formas en presentaciones de PowerPoint. El siguiente fragmento de código muestra cómo obtener los efectos aplicados a la primera forma de la primera diapositiva normal en la presentación `AnimExample_out.pptx`.
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


**Ejemplo 2: Obtener todos los efectos de animación, incluidos los heredados de marcadores de posición**

Si una forma en una diapositiva normal tiene marcadores de posición que están en la diapositiva de diseño y/o en la diapositiva maestra, y se han añadido efectos de animación a esos marcadores, entonces todos los efectos de la forma se reproducirán durante la presentación, incluidos los heredados.

Supongamos que tenemos una presentación PowerPoint `sample.pptx` con una diapositiva que contiene solo una forma de pie de página con el texto "Made with Aspose.Slides" y se le ha aplicado el efecto **Random Bars**.

![Slide shape animation effect](slide-shape-animation.png)

Supongamos también que el efecto **Split** está aplicado al marcador de posición del pie de página en la diapositiva **de diseño**.

![Layout shape animation effect](layout-shape-animation.png)

Y, por último, el efecto **Fly In** está aplicado al marcador de posición del pie de página en la diapositiva **maestra**.

![Master shape animation effect](master-shape-animation.png)

El siguiente fragmento de código muestra cómo usar el método `getBasePlaceholder` de la clase [Shape](https://reference.aspose.com/slides/php-java/aspose.slides/shape/) para acceder a los marcadores de posición de la forma y obtener los efectos de animación aplicados a la forma de pie de página, incluidos los heredados de los marcadores ubicados en las diapositivas de diseño y maestra.
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
Type: 47, subtype: 2              // Vuelo, Inferior
Type: 134, subtype: 45            // Dividir, EntradaVertical
Type: 126, subtype: 22            // BarrasAleatorias, Horizontal
```


## **Cambiar las propiedades de tiempo del efecto de animación**

Aspose.Slides for PHP via Java permite cambiar las propiedades de Timing de un efecto de animación.

Este es el panel de Timing de animación en Microsoft PowerPoint:

![example1_image](shape-animation.png)

Correspondencias entre Timing de PowerPoint y las propiedades de [Effect.Timing](https://reference.aspose.com/slides/php-java/aspose.slides/IEffect#getTiming--):

- La lista desplegable **Start** de PowerPoint coincide con la propiedad [Effect.Timing.TriggerType](https://reference.aspose.com/slides/php-java/aspose.slides/ITiming#getTriggerType--).  
- **Duration** coincide con la propiedad [Effect.Timing.Duration](https://reference.aspose.com/slides/php-java/aspose.slides/ITiming#getDuration--). La duración de una animación (en segundos) es el tiempo total que tarda en completarse un ciclo.  
- **Delay** coincide con la propiedad [Effect.Timing.TriggerDelayTime](https://reference.aspose.com/slides/php-java/aspose.slides/ITiming#getTriggerDelayTime--).  

Cómo cambiar las propiedades de Timing del efecto:

1. [Aplicar](#apply-animation-to-shape) o obtener el efecto de animación.  
2. Establecer nuevos valores para las propiedades de [Effect.Timing](https://reference.aspose.com/slides/php-java/aspose.slides/IEffect#getTiming--) que necesites.  
3. Guardar el archivo PPTX modificado.  

Este código PHP demuestra la operación:
```php
  # Instancia una clase de presentación que representa un archivo de presentación.
  $pres = new Presentation("AnimExample_out.pptx");
  try {
    # Obtiene la secuencia principal de la diapositiva.
    $sequence = $pres->getSlides()->get_Item(0)->getTimeline()->getMainSequence();
    # Obtiene el primer efecto de la secuencia principal.
    $effect = $sequence->get_Item(0);
    # Cambia el tipo de activación del efecto a iniciar al hacer clic
    $effect->getTiming()->setTriggerType(EffectTriggerType::OnClick);
    # Cambia la duración del efecto
    $effect->getTiming()->setDuration(3.0);
    # Cambia el tiempo de retraso del activador del efecto
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

Aspose.Slides ofrece estas propiedades para trabajar con sonidos en efectos de animación:  

- [setSound(IAudio value)](https://reference.aspose.com/slides/php-java/aspose.slides/effect/#setSound-com.aspose.slides.IAudio-)  
- [setStopPreviousSound(boolean value)](https://reference.aspose.com/slides/php-java/aspose.slides/effect/#setStopPreviousSound-boolean-)  

### **Añadir un sonido a un efecto de animación**

Este código PHP muestra cómo añadir un sonido a un efecto de animación y detenerlo cuando comienza el siguiente efecto:
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
      # Añade sonido para el primer efecto
      $firstEffect->setSound($effectSound);
    }
    # Obtiene la primera secuencia interactiva de la diapositiva.
    $interactiveSequence = $firstSlide->getTimeline()->getInteractiveSequences()->get_Item(0);
    # Establece la bandera "Detener sonido anterior" del efecto
    $interactiveSequence->get_Item(0)->setStopPreviousSound(true);
    # Escribe el archivo PPTX en disco
    $pres->save("AnimExample_Sound_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


### **Extraer el sonido de un efecto de animación**

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).  
2. Obtén una referencia a una diapositiva mediante su índice.  
3. Obtén la secuencia principal de efectos.  
4. Extrae el método [setSound(IAudio value)](https://reference.aspose.com/slides/php-java/aspose.slides/effect/#setSound-com.aspose.slides.IAudio-) incrustado en cada efecto de animación.  

Este código PHP muestra cómo extraer el sonido incrustado en un efecto de animación:
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


## **After Animation**

Aspose.Slides for PHP via Java permite cambiar la propiedad After animation de un efecto de animación.

Este es el panel de Efectos de animación y el menú ampliado en Microsoft PowerPoint:

![example1_image](shape-after-animation.png)

La lista desplegable **After animation** de PowerPoint coincide con estas propiedades:  

- Propiedad [setAfterAnimationType(int value)](https://reference.aspose.com/slides/php-java/aspose.slides/ieffect/#setAfterAnimationType-int-) que describe el tipo de After animation:  
  * **More Colors** de PowerPoint coincide con el tipo [AfterAnimationType::Color](https://reference.aspose.com/slides/php-java/aspose.slides/afteranimationtype/#Color);  
  * **Don't Dim** coincide con [AfterAnimationType::DoNotDim](https://reference.aspose.com/slides/php-java/aspose.slides/afteranimationtype/#DoNotDim) (tipo predeterminado);  
  * **Hide After Animation** coincide con [AfterAnimationType::HideAfterAnimation](https://reference.aspose.com/slides/php-java/aspose.slides/afteranimationtype/#HideAfterAnimation);  
  * **Hide on Next Mouse Click** coincide con [AfterAnimationType::HideOnNextMouseClick](https://reference.aspose.com/slides/php-java/aspose.slides/afteranimationtype/#HideOnNextMouseClick).  
- Propiedad [setAfterAnimationColor(IColorFormat value)](https://reference.aspose.com/slides/php-java/aspose.slides/ieffect/#setAfterAnimationColor-com.aspose.slides.IColorFormat-) que define un formato de color After animation. Esta propiedad funciona junto con el tipo [AfterAnimationType::Color](https://reference.aspose.com/slides/php-java/aspose.slides/afteranimationtype/#Color). Si cambias el tipo a otro, el color After animation se borrará.  

Este código PHP muestra cómo cambiar un efecto After animation:
```php
  # Instancia una clase de presentación que representa un archivo de presentación
  $pres = new Presentation("AnimImage_out.pptx");
  try {
    $firstSlide = $pres->getSlides()->get_Item(0);
    # Obtiene el primer efecto de la secuencia principal
    $firstEffect = $firstSlide->getTimeline()->getMainSequence()->get_Item(0);
    # Cambia el tipo de animación posterior a Color
    $firstEffect->setAfterAnimationType(AfterAnimationType::Color);
    # Establece el color de atenuación de la animación posterior
    $firstEffect->getAfterAnimationColor()->setColor(java("java.awt.Color")->BLUE);
    # Escribe el archivo PPTX en disco
    $pres->save("AnimImage_AfterAnimation.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Animar texto**

Aspose.Slides ofrece estas propiedades para trabajar con el bloque *Animate text* de un efecto de animación:  

- [setAnimateTextType(int value)](https://reference.aspose.com/slides/php-java/aspose.slides/ieffect/#setAnimateTextType-int-) que describe el tipo de animación de texto del efecto. El texto de la forma puede animarse:  
  - Todo a la vez ([AnimateTextType::AllAtOnce](https://reference.aspose.com/slides/php-java/aspose.slides/animatetexttype/#AllAtOnce))  
  - Por palabra ([AnimateTextType::ByWord](https://reference.aspose.com/slides/php-java/aspose.slides/animatetexttype/#ByWord))  
  - Por letra ([AnimateTextType::ByLetter](https://reference.aspose.com/slides/php-java/aspose.slides/animatetexttype/#ByLetter))  
- [setDelayBetweenTextParts(float value)](https://reference.aspose.com/slides/php-java/aspose.slides/ieffect/#setDelayBetweenTextParts-float-) establece un retraso entre las partes animadas del texto (palabras o letras). Un valor positivo indica el porcentaje de la duración del efecto. Un valor negativo indica el retraso en segundos.  

Cómo cambiar las propiedades *Animate text* del efecto:

1. [Aplicar](#apply-animation-to-shape) o obtener el efecto de animación.  
2. Establecer la propiedad [setBuildType(int value)](https://reference.aspose.com/slides/php-java/aspose.slides/itextanimation/#setBuildType-int-) a [BuildType::AsOneObject](https://reference.aspose.com/slides/php-java/aspose.slides/buildtype/#AsOneObject) para desactivar el modo *By Paragraphs*.  
3. Establecer nuevos valores para las propiedades [setAnimateTextType(int value)](https://reference.aspose.com/slides/php-java/aspose.slides/ieffect/#setAnimateTextType-int-) y [setDelayBetweenTextParts(float value)](https://reference.aspose.com/slides/php-java/aspose.slides/ieffect/#setDelayBetweenTextParts-float-).  
4. Guardar el archivo PPTX modificado.  

Este código PHP demuestra la operación:
```php
  # Instancia una clase de presentación que representa un archivo de presentación.
  $pres = new Presentation("AnimTextBox_out.pptx");
  try {
    $firstSlide = $pres->getSlides()->get_Item(0);
    # Obtiene el primer efecto de la secuencia principal
    $firstEffect = $firstSlide->getTimeline()->getMainSequence()->get_Item(0);
    # Cambia el tipo de animación de texto del efecto a "Como un solo objeto"
    $firstEffect->getTextAnimation()->setBuildType(BuildType::AsOneObject);
    # Cambia el tipo de animación de texto del efecto a "Por palabra"
    $firstEffect->setAnimateTextType(AnimateTextType::ByWord);
    # Establece el retraso entre palabras al 20% de la duración del efecto
    $firstEffect->setDelayBetweenTextParts(20.0);
    # Escribe el archivo PPTX en disco
    $pres->save("AnimTextBox_AnimateText.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **FAQ**

**¿Cómo puedo asegurar que las animaciones se conserven al publicar la presentación en la web?**

[Export to HTML5](/slides/es/php-java/export-to-html5/) y habilita las [opciones](https://reference.aspose.com/slides/php-java/aspose.slides/html5options/) responsables de animaciones de [shape](https://reference.aspose.com/slides/php-java/aspose.slides/html5options/setanimateshapes/) y de [transition](https://reference.aspose.com/slides/php-java/aspose.slides/html5options/setanimatetransitions/). El HTML plano no reproduce animaciones de diapositivas, mientras que HTML5 sí.

**¿Cómo afecta el cambio del orden Z (orden de capas) de las formas a la animación?**

El orden de animación y el orden de dibujo son independientes: un efecto controla el momento y el tipo de aparición/desaparición, mientras que el [z-order](https://reference.aspose.com/slides/php-java/aspose.slides/shape/getzorderposition/) determina qué cubre a qué. El resultado visible se define por su combinación. (Este es el comportamiento general de PowerPoint; el modelo de efectos y formas de Aspose.Slides sigue la misma lógica.)

**¿Existen limitaciones al convertir animaciones a video para ciertos efectos?**

En general, [las animaciones son compatibles](/slides/es/php-java/convert-powerpoint-to-video/), pero casos raros o efectos específicos pueden renderizarse de forma distinta. Se recomienda probar con los efectos que uses y con la versión de la biblioteca.