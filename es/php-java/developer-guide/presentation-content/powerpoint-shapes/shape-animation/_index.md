---
title: Animación de Formas
type: docs
weight: 60
url: /es/php-java/shape-animation/
keywords: "animación de PowerPoint, efecto de animación, aplicar animación, presentación de PowerPoint, Java, Aspose.Slides para PHP a través de Java"
description: "Aplicar animación de PowerPoint"
---

Las animaciones son efectos visuales que se pueden aplicar a textos, imágenes, formas o [gráficos](https://docs.aspose.com/slides/php-java/animated-charts/). Le dan vida a las presentaciones o a sus componentes.

### **¿Por qué usar animaciones en presentaciones?**

Usando animaciones, puedes 

* controlar el flujo de información
* enfatizar puntos importantes
* aumentar el interés o la participación entre tu audiencia
* hacer que el contenido sea más fácil de leer, asimilar o procesar
* atraer la atención de tus lectores o espectadores a partes importantes de una presentación

PowerPoint ofrece muchas opciones y herramientas para animaciones y efectos de animación en las categorías de **entrada**, **salida**, **énfasis** y **trayectorias de movimiento**. 

### **Animaciones en Aspose.Slides**

* Aspose.Slides proporciona las clases y tipos que necesitas para trabajar con animaciones bajo el espacio de nombres `Aspose.Slides.Animation`,
* Aspose.Slides proporciona más de **150 efectos de animación** bajo la enumeración [EffectType](https://reference.aspose.com/slides/php-java/aspose.slides/effecttype). Estos efectos son esencialmente los mismos (o equivalentes) que los usados en PowerPoint.

## **Aplicar animación a TextBox**

Aspose.Slides para PHP a través de Java te permite aplicar animación al texto en una forma.

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
2. Obtén una referencia a la diapositiva a través de su índice.
3. Agrega una [IAutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/iautoshape) `rectángulo`.
4. Agrega texto a [IAutoShape.TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/IAutoShape#addTextFrame-java.lang.String-).
5. Obtén una secuencia principal de efectos.
6. Agrega un efecto de animación a [IAutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/iautoshape).
7. Establece la propiedad `TextAnimation.BuildType` al valor de la enumeración `BuildType`.
8. Escribe la presentación en disco como un archivo PPTX.

Este código PHP muestra cómo aplicar el efecto `Desvanecer` a AutoShape y establecer la animación de texto al valor *Por párrafos de 1er nivel*:

```php
  # Instancia una clase de presentación que representa un archivo de presentación.
  $pres = new Presentation();
  try {
    $sld = $pres->getSlides()->get_Item(0);
    # Agrega un nuevo AutoShape con texto
    $autoShape = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 20, 150, 100);
    $textFrame = $autoShape->getTextFrame();
    $textFrame->setText("Primer párrafo \nSegundo párrafo \n Tercer párrafo");
    # Obtiene la secuencia principal de la diapositiva.
    $sequence = $sld->getTimeline()->getMainSequence();
    # Agrega efecto de animación Desvanecer a la forma
    $effect = $sequence->addEffect($autoShape, EffectType::Fade, EffectSubType::None, EffectTriggerType::OnClick);
    # Anima el texto de la forma por párrafos de 1er nivel
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

Además de aplicar animaciones al texto, también puedes aplicar animaciones a un solo [Párrafo](https://reference.aspose.com/slides/php-java/aspose.slides/iparagraph). Consulta [**Texto Animado**](/slides/es/php-java/animated-text/).

{{% /alert %}} 

## **Aplicar animación a PictureFrame**

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
2. Obtén una referencia de la diapositiva a través de su índice.
3. Agrega o obtiene un [PictureFrame](https://reference.aspose.com/slides/php-java/aspose.slides/pictureframe) en la diapositiva.
4. Obtén la secuencia principal de efectos.
5. Agrega un efecto de animación a [PictureFrame](https://reference.aspose.com/slides/php-java/aspose.slides/pictureframe).
6. Escribe la presentación en disco como un archivo PPTX.

Este código PHP muestra cómo aplicar el efecto `Volante` a un marco de imagen:

```php
  # Instancia una clase de presentación que representa un archivo de presentación.
  $pres = new Presentation();
  try {
    # Carga la imagen que se va a agregar a la colección de imágenes de la presentación
    $picture;
    $image = Images->fromFile("aspose-logo.jpg");
    try {
      $picture = $pres->getImages()->addImage($image);
    } finally {
      if (!java_is_null($image)) {
        $image->dispose();
      }
    }
    # Agrega el marco de imagen a la diapositiva
    $picFrame = $pres->getSlides()->get_Item(0)->getShapes()->addPictureFrame(ShapeType::Rectangle, 50, 50, 100, 100, $picture);
    # Obtiene la secuencia principal de la diapositiva.
    $sequence = $pres->getSlides()->get_Item(0)->getTimeline()->getMainSequence();
    # Agrega efecto de animación Volar desde la izquierda al marco de imagen
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

## **Aplicar animación a forma**

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
2. Obtén una referencia de la diapositiva a través de su índice.
3. Agrega una [IAutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/iautoshape) `rectángulo`.
4. Agrega una [IAutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/iautoshape) `Bevel` (cuando se haga clic en este objeto, se reproducirá la animación).
5. Crea una secuencia de efectos en la forma bevel.
6. Crea una `UserPath` personalizada.
7. Agrega comandos para mover a la `UserPath`.
8. Escribe la presentación en disco como un archivo PPTX.

Este código PHP muestra cómo aplicar el efecto `PathFootball` (camino de fútbol) a una forma:

```php
  # Instancia una clase de presentación que representa un archivo PPTX.
  $pres = new Presentation();
  try {
    $sld = $pres->getSlides()->get_Item(0);
    # Crea un efecto PathFootball para la forma existente desde cero.
    $ashp = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 150, 150, 250, 25);
    $ashp->addTextFrame("Cuadro de texto animado");
    # Agrega el efecto de animación PathFootBall
    $pres->getSlides()->get_Item(0)->getTimeline()->getMainSequence()->addEffect($ashp, EffectType::PathFootball, EffectSubType::None, EffectTriggerType::AfterPrevious);
    # Crea una especie de "botón".
    $shapeTrigger = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Bevel, 10, 10, 20, 20);
    # Crea una secuencia de efectos para este botón.
    $seqInter = $pres->getSlides()->get_Item(0)->getTimeline()->getInteractiveSequences()->add($shapeTrigger);
    # Crea un camino de usuario personalizado. Nuestro objeto solo se moverá después de que se haga clic en el botón.
    $fxUserPath = $seqInter->addEffect($ashp, EffectType::PathUser, EffectSubType::None, EffectTriggerType::OnClick);
    # Agrega comandos para mover ya que el camino creado está vacío.
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

Puedes decidir averiguar todos los efectos de animación aplicados a una sola forma. 

Este código PHP muestra cómo obtener todos los efectos aplicados a una forma específica:

```php
  # Instancia una clase de presentación que representa un archivo de presentación.
  $pres = new Presentation("AnimExample_out.pptx");
  $Array = new java_class("java.lang.reflect.Array");
  try {
    $firstSlide = $pres->getSlides()->get_Item(0);
    # Obtiene la secuencia principal de la diapositiva.
    $sequence = $firstSlide->getTimeline()->getMainSequence();
    # Obtiene la primera forma en la diapositiva.
    $shape = $firstSlide->getShapes()->get_Item(0);
    # Obtiene todos los efectos de animación aplicados a la forma.
    $shapeEffects = $sequence->getEffectsByShape($shape);
    if (java_values($Array->getLength($shapeEffects)) > 0) {
      echo("La forma " . $shape->getName() . " tiene " . $Array->getLength($shapeEffects) . " efectos de animación.");
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Cambiar propiedades de tiempo del efecto de animación**

Aspose.Slides para PHP a través de Java te permite cambiar las propiedades de tiempo de un efecto de animación.

Este es el panel de tiempo de animación en Microsoft PowerPoint:

![example1_image](shape-animation.png)

Estas son las correspondencias entre las propiedades de tiempo de PowerPoint y [Effect.Timing](https://reference.aspose.com/slides/php-java/aspose.slides/IEffect#getTiming--) :

- La lista desplegable de **Inicio** de PowerPoint coincide con la propiedad [Effect.Timing.TriggerType](https://reference.aspose.com/slides/php-java/aspose.slides/ITiming#getTriggerType--) .
- La **Duración** de PowerPoint coincide con la propiedad [Effect.Timing.Duration](https://reference.aspose.com/slides/php-java/aspose.slides/ITiming#getDuration--) . La duración de una animación (en segundos) es el tiempo total que tarda la animación en completar un ciclo.
- El **Retraso** de PowerPoint coincide con la propiedad [Effect.Timing.TriggerDelayTime](https://reference.aspose.com/slides/php-java/aspose.slides/ITiming#getTriggerDelayTime--) .

Así es como cambias las propiedades de tiempo del efecto:

1. [Aplica](#apply-animation-to-shape) o obtén el efecto de animación.
2. Establece nuevos valores para las propiedades [Effect.Timing](https://reference.aspose.com/slides/php-java/aspose.slides/IEffect#getTiming--) que necesites.
3. Guarda el archivo PPTX modificado.

Este código PHP demuestra la operación:

```php
  # Instancia una clase de presentación que representa un archivo de presentación.
  $pres = new Presentation("AnimExample_out.pptx");
  try {
    # Obtiene la secuencia principal de la diapositiva.
    $sequence = $pres->getSlides()->get_Item(0)->getTimeline()->getMainSequence();
    # Obtiene el primer efecto de la secuencia principal.
    $effect = $sequence->get_Item(0);
    # Cambia el TriggerType del efecto para que comience al hacer clic
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

Aspose.Slides proporciona estas propiedades para permitirte trabajar con sonidos en efectos de animación: 

- [setSound(IAudio value)](https://reference.aspose.com/slides/php-java/aspose.slides/effect/#setSound-com.aspose.slides.IAudio-)
- [setStopPreviousSound(boolean value)](https://reference.aspose.com/slides/php-java/aspose.slides/effect/#setStopPreviousSound-boolean-)

### **Agregar sonido al efecto de animación**

Este código PHP muestra cómo agregar un sonido al efecto de animación y detenerlo cuando comienza el siguiente efecto:

```php
  $pres = new Presentation("AnimExample_out.pptx");
  try {
    # Agrega audio a la colección de audio de la presentación
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
    # Verifica el efecto para "Sin sonido"
    if (java_is_null(!$firstEffect->getStopPreviousSound() && $firstEffect->getSound())) {
      # Agrega sonido para el primer efecto
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

### **Extraer el sonido del efecto de animación**

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) .
2. Obtén la referencia de una diapositiva a través de su índice. 
3. Obtén la secuencia principal de efectos. 
4. Extrae el [setSound(IAudio value)](https://reference.aspose.com/slides/php-java/aspose.slides/effect/#setSound-com.aspose.slides.IAudio-) incrustado en cada efecto de animación.

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
      # Extrae el sonido del efecto en un arreglo de bytes
      $audio = $effect->getSound()->getBinaryData();
    }
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

## **Después de la animación**

Aspose.Slides para PHP a través de Java te permite cambiar la propiedad Después de la animación de un efecto de animación.

Este es el panel de Efecto de animación y el menú extendido en Microsoft PowerPoint:

![example1_image](shape-after-animation.png)

La lista desplegable de **Después de la animación** de PowerPoint coincide con estas propiedades: 

- La propiedad [setAfterAnimationType(int value)](https://reference.aspose.com/slides/php-java/aspose.slides/ieffect/#setAfterAnimationType-int-) que describe el tipo de animación después de:
  * La opción **Más colores** de PowerPoint coincide con el tipo [AfterAnimationType::Color](https://reference.aspose.com/slides/php-java/aspose.slides/afteranimationtype/#Color);
  * La opción **No atenuar** de PowerPoint coincide con el tipo [AfterAnimationType::DoNotDim](https://reference.aspose.com/slides/php-java/aspose.slides/afteranimationtype/#DoNotDim) (tipo de animación después predeterminado);
  * La opción **Ocultar después de la animación** de PowerPoint coincide con el tipo [AfterAnimationType::HideAfterAnimation](https://reference.aspose.com/slides/php-java/aspose.slides/afteranimationtype/#HideAfterAnimation);
  * La opción **Ocultar en el siguiente clic del mouse** de PowerPoint coincide con el tipo [AfterAnimationType::HideOnNextMouseClick](https://reference.aspose.com/slides/php-java/aspose.slides/afteranimationtype/#HideOnNextMouseClick);
- La propiedad [setAfterAnimationColor(IColorFormat value)](https://reference.aspose.com/slides/php-java/aspose.slides/ieffect/#setAfterAnimationColor-com.aspose.slides.IColorFormat-) que define un formato de color después de la animación. Esta propiedad funciona en conjunto con el tipo [AfterAnimationType::Color](https://reference.aspose.com/slides/php-java/aspose.slides/afteranimationtype/#Color). Si cambias el tipo a otro, el color después de la animación se borrará.

Este código PHP muestra cómo cambiar un efecto de animación después:

```php
  # Instancia una clase de presentación que representa un archivo de presentación
  $pres = new Presentation("AnimImage_out.pptx");
  try {
    $firstSlide = $pres->getSlides()->get_Item(0);
    # Obtiene el primer efecto de la secuencia principal
    $firstEffect = $firstSlide->getTimeline()->getMainSequence()->get_Item(0);
    # Cambia el tipo de animación posterior a Color
    $firstEffect->setAfterAnimationType(AfterAnimationType::Color);
    # Establece el color de atenuación después de la animación
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

Aspose.Slides proporciona estas propiedades para permitirte trabajar con el bloque *Animar texto* de un efecto de animación:

- [setAnimateTextType(int value)](https://reference.aspose.com/slides/php-java/aspose.slides/ieffect/#setAnimateTextType-int-) que describe un tipo de animación de texto del efecto. El texto de la forma puede ser animado:
  - Todo a la vez ([AnimateTextType::AllAtOnce](https://reference.aspose.com/slides/php-java/aspose.slides/animatetexttype/#AllAtOnce) tipo)
  - Por palabra ([AnimateTextType::ByWord](https://reference.aspose.com/slides/php-java/aspose.slides/animatetexttype/#ByWord) tipo)
  - Por letra ([AnimateTextType::ByLetter](https://reference.aspose.com/slides/php-java/aspose.slides/animatetexttype/#ByLetter) tipo)
- [setDelayBetweenTextParts(float value)](https://reference.aspose.com/slides/php-java/aspose.slides/ieffect/#setDelayBetweenTextParts-float-) establece un retraso entre las partes de texto animadas (palabras o letras). Un valor positivo especifica el porcentaje de duración del efecto. Un valor negativo especifica el retraso en segundos.

Así es como puedes cambiar las propiedades del efecto de animar texto:

1. [Aplica](#apply-animation-to-shape) o obtén el efecto de animación.
2. Establece la propiedad [setBuildType(int value)](https://reference.aspose.com/slides/php-java/aspose.slides/itextanimation/#setBuildType-int-) al valor [BuildType::AsOneObject](https://reference.aspose.com/slides/php-java/aspose.slides/buildtype/#AsOneObject) para desactivar el modo de animación *Por párrafos*.
3. Establece nuevos valores para las propiedades [setAnimateTextType(int value)](https://reference.aspose.com/slides/php-java/aspose.slides/ieffect/#setAnimateTextType-int-) y [setDelayBetweenTextParts(float value)](https://reference.aspose.com/slides/php-java/aspose.slides/ieffect/#setDelayBetweenTextParts-float-).
4. Guarda el archivo PPTX modificado.

Este código PHP demuestra la operación:

```php
  # Instancia una clase de presentación que representa un archivo de presentación.
  $pres = new Presentation("AnimTextBox_out.pptx");
  try {
    $firstSlide = $pres->getSlides()->get_Item(0);
    # Obtiene el primer efecto de la secuencia principal
    $firstEffect = $firstSlide->getTimeline()->getMainSequence()->get_Item(0);
    # Cambia el tipo de animación del texto del efecto a "Como un objeto"
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