---
title: Gestionar transiciones de diapositivas en presentaciones usando PHP
linktitle: Transición de diapositiva
type: docs
weight: 80
url: /es/php-java/slide-transition/
keywords:
- transición de diapositiva
- añadir transición de diapositiva
- aplicar transición de diapositiva
- transición de diapositiva avanzada
- transición Morph
- tipo de transición
- efecto de transición
- PowerPoint
- OpenDocument
- presentación
- PHP
- Aspose.Slides
description: "Aplicar transiciones de diapositiva, configurar el avance automático de diapositivas y personalizar Morph y otros efectos de transición con Aspose.Slides para PHP mediante Java."
---
## **Descripción general**

Las transiciones entre diapositivas controlan cómo aparecen las diapositivas durante una presentación. Con Aspose.Slides para PHP mediante Java, puedes elegir un efecto de transición para cada diapositiva, configurar el avance mediante clic del ratón o temporizador, y ajustar opciones específicas de un efecto. Este artículo utiliza ejemplos en PHP para aplicar transiciones, establecer duraciones exactas de transición, gestionar el tiempo de la diapositiva y crear una transición Morph entre dos diapositivas. Los ejemplos también muestran cómo guardar la configuración en un archivo PPTX.

## **Añadir transición a la diapositiva**

Para aplicar una transición, carga una presentación con la clase [Presentation](https://reference.aspose.com/slides/es/php-java/aspose.slides/presentation/) y accede a la configuración de transición de la diapositiva mediante [getSlideShowTransition](https://reference.aspose.com/slides/es/php-java/aspose.slides/baseslide/#getSlideShowTransition). Usa [setType](https://reference.aspose.com/slides/es/php-java/aspose.slides/slideshowtransition/#setType) con un valor del enumerado [TransitionType](https://reference.aspose.com/slides/es/php-java/aspose.slides/transitiontype/), y luego guarda la presentación.

El siguiente ejemplo aplica una transición Circle a la primera diapositiva y una transición Comb a la segunda. Utiliza un archivo `input.pptx` con al menos dos diapositivas.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\TransitionType;

$presentation = new Presentation("input.pptx");
try {
    if (java_values($presentation->getSlides()->size()) >= 2) {
        $presentation->getSlides()->get_Item(0)->getSlideShowTransition()->setType(TransitionType::Circle);
        $presentation->getSlides()->get_Item(1)->getSlideShowTransition()->setType(TransitionType::Comb);

        $presentation->save("slide-transitions.pptx", SaveFormat::Pptx);
    } else {
        echo "The input presentation must contain at least two slides." . PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

## **Añadir transición avanzada a la diapositiva**

Puedes configurar cuánto tiempo permanece una diapositiva en pantalla y si un clic del ratón avanza la presentación. Los siguientes métodos controlan este comportamiento:

- [setAdvanceOnClick](https://reference.aspose.com/slides/es/php-java/aspose.slides/slideshowtransition/#setAdvanceOnClick) permite que el espectador avance haciendo clic con el ratón.
- [setAdvanceAfter](https://reference.aspose.com/slides/es/php-java/aspose.slides/slideshowtransition/#setAdvanceAfter) habilita el avance automático.
- [setAdvanceAfterTime](https://reference.aspose.com/slides/es/php-java/aspose.slides/slideshowtransition/#setAdvanceAfterTime) especifica el retraso antes del avance automático, en milisegundos.

Activa tanto el avance por clic como el temporizado para que el espectador pueda pasar a la siguiente diapositiva con un clic o esperar al temporizador. Para usar solo el temporizador, pasa `false` a [setAdvanceOnClick](https://reference.aspose.com/slides/es/php-java/aspose.slides/slideshowtransition/#setAdvanceOnClick). El retraso controla cuándo avanza la presentación; no establece la duración del efecto visual de transición.

Este ejemplo asigna diferentes efectos a las tres primeras diapositivas y habilita el avance automático después de 3, 5 y 7 segundos, respectivamente. Los clics del ratón también pueden avanzar estas diapositivas. Utiliza un archivo `input.pptx` con al menos tres diapositivas.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\TransitionType;

$presentation = new Presentation("input.pptx");
try {
    if (java_values($presentation->getSlides()->size()) >= 3) {
        $firstTransition = $presentation->getSlides()->get_Item(0)->getSlideShowTransition();
        $firstTransition->setType(TransitionType::Circle);
        $firstTransition->setAdvanceOnClick(true);
        $firstTransition->setAdvanceAfter(true);
        $firstTransition->setAdvanceAfterTime(3000);

        $secondTransition = $presentation->getSlides()->get_Item(1)->getSlideShowTransition();
        $secondTransition->setType(TransitionType::Comb);
        $secondTransition->setAdvanceOnClick(true);
        $secondTransition->setAdvanceAfter(true);
        $secondTransition->setAdvanceAfterTime(5000);

        $thirdTransition = $presentation->getSlides()->get_Item(2)->getSlideShowTransition();
        $thirdTransition->setType(TransitionType::Zoom);
        $thirdTransition->setAdvanceOnClick(true);
        $thirdTransition->setAdvanceAfter(true);
        $thirdTransition->setAdvanceAfterTime(7000);

        $presentation->save("advanced-transitions.pptx", SaveFormat::Pptx);
    } else {
        echo "The input presentation must contain at least three slides." . PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

Para comprobar si el avance temporizado está habilitado, llama a [getAdvanceAfter](https://reference.aspose.com/slides/es/php-java/aspose.slides/slideshowtransition/#getAdvanceAfter). Un retraso almacenado por sí solo no indica que el temporizador esté activo.

El siguiente ejemplo abre el archivo guardado anteriormente, informa de cada temporizador habilitado y desactiva el avance automático para las diapositivas con un retraso mayor a dos segundos. Habilita los clics del ratón para esas diapositivas y guarda la configuración actualizada.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("advanced-transitions.pptx");
try {
    for ($slideIndex = 0; $slideIndex < java_values($presentation->getSlides()->size()); $slideIndex++) {
        $slide = $presentation->getSlides()->get_Item($slideIndex);
        $transition = $slide->getSlideShowTransition();

        if (java_values($transition->getAdvanceAfter())) {
            echo "Slide " . java_values($slide->getSlideNumber()) . ": advance after " . java_values($transition->getAdvanceAfterTime()) . " ms." . PHP_EOL;

            if (java_values($transition->getAdvanceAfterTime()) > 2000) {
                $transition->setAdvanceAfter(false);
                $transition->setAdvanceOnClick(true);
            }
        }
    }

    $presentation->save("adjusted-transitions.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Controlar el tiempo de la transición con precisión**

Utiliza [setDuration](https://reference.aspose.com/slides/es/php-java/aspose.slides/slideshowtransition/#setDuration) para especificar la longitud exacta de un efecto de transición en milisegundos. El método [getSlideShowTransition](https://reference.aspose.com/slides/es/php-java/aspose.slides/baseslide/#getSlideShowTransition) de la diapositiva expone estas configuraciones a través de [SlideShowTransition](https://reference.aspose.com/slides/es/php-java/aspose.slides/slideshowtransition/):

| Método | Propósito |
| --- | --- |
| [setDuration](https://reference.aspose.com/slides/es/php-java/aspose.slides/slideshowtransition/#setDuration) | Establece la duración del propio efecto de transición, en milisegundos. |
| [setAdvanceAfterTime](https://reference.aspose.com/slides/es/php-java/aspose.slides/slideshowtransition/#setAdvanceAfterTime) | Establece el retraso antes de que la diapositiva avance automáticamente, en milisegundos. Pasa `true` a [setAdvanceAfter](https://reference.aspose.com/slides/es/php-java/aspose.slides/slideshowtransition/#setAdvanceAfter) para activar este temporizador. |
| [setSpeed](https://reference.aspose.com/slides/es/php-java/aspose.slides/slideshowtransition/#setSpeed) | Selecciona una categoría de velocidad predefinida del enumerado [TransitionSpeed](https://reference.aspose.com/slides/es/php-java/aspose.slides/transitionspeed/): Slow, Medium o Fast. Se usa cuando no se especifica una duración exacta. |

[setDuration](https://reference.aspose.com/slides/es/php-java/aspose.slides/slideshowtransition/#setDuration) controla solo el efecto de transición; no determina cuánto tiempo permanece visible la diapositiva. Configura el retraso de avance automático por separado. Cuando no se establece una duración explícita, Aspose.Slides determina la duración del efecto a partir del tipo de transición y el valor de [getSpeed](https://reference.aspose.com/slides/es/php-java/aspose.slides/slideshowtransition/#getSpeed).

### **Aplicar la misma duración a todas las diapositivas**

Para una sincronización constante, aplica el mismo efecto y la misma duración exacta a cada diapositiva. Este ejemplo carga `input.pptx`, selecciona Fade del [TransitionType](https://reference.aspose.com/slides/es/php-java/aspose.slides/transitiontype/), y asigna a cada transición una duración de 750 milisegundos. Activa por separado el avance automático después de 5 000 milisegundos y desactiva el avance mediante clic del ratón, y guarda el resultado como PPTX.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\TransitionType;

$presentation = new Presentation("input.pptx");
try {
    for ($slideIndex = 0; $slideIndex < java_values($presentation->getSlides()->size()); $slideIndex++) {
        $slide = $presentation->getSlides()->get_Item($slideIndex);
        $transition = $slide->getSlideShowTransition();
        $transition->setType(TransitionType::Fade);
        $transition->setDuration(750);

        // Configurar el avance automático independientemente de la duración del efecto.
        $transition->setAdvanceAfter(true);
        $transition->setAdvanceAfterTime(5000);
        $transition->setAdvanceOnClick(false);
    }

    $presentation->save("precise-transitions.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **Establecer duraciones diferentes para diapositivas individuales**

Las distintas diapositivas pueden usar duraciones de efecto diferentes. Por ejemplo, utiliza una transición breve para una diapositiva de título y una más larga para la introducción de una sección. Este ejemplo establece 500 milisegundos para la primera diapositiva y 1 200 milisegundos para la segunda. Utiliza un archivo `input.pptx` con al menos dos diapositivas.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\TransitionType;

$presentation = new Presentation("input.pptx");
try {
    if (java_values($presentation->getSlides()->size()) >= 2) {
        $firstTransition = $presentation->getSlides()->get_Item(0)->getSlideShowTransition();
        $firstTransition->setType(TransitionType::Fade);
        $firstTransition->setDuration(500);

        $secondTransition = $presentation->getSlides()->get_Item(1)->getSlideShowTransition();
        $secondTransition->setType(TransitionType::Push);
        $secondTransition->setDuration(1200);

        $presentation->save("individual-transition-durations.pptx", SaveFormat::Pptx);
    } else {
        echo "The input presentation must contain at least two slides." . PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

### **Coordinar transiciones con salida animada**

Al preparar un [GIF animado](/slides/es/php-java/convert-powerpoint-to-animated-gif/), una [presentación HTML5](/slides/es/php-java/export-to-html5/) o un [vídeo](/slides/es/php-java/convert-powerpoint-to-video/), establece duraciones exactas de transición antes de la exportación para que coincidan con el ritmo deseado. Por ejemplo, usa un fundido de 600 ms entre escenas y ajusta cada retraso de avance de la diapositiva por separado para permitir tiempo a la narración o al contenido.

Para GIF y vídeo, coordina la velocidad de fotogramas de salida con la duración del efecto: 600 ms corresponden a 18 fotogramas a 30 fps. En HTML5, habilita transiciones animadas en la configuración de exportación. Consulta los efectos y opciones de temporización compatibles con el formato de exportación elegido y previsualiza la salida para confirmar la sincronización.

### **Leer la duración de una transición existente**

Llama a [getDuration](https://reference.aspose.com/slides/es/php-java/aspose.slides/slideshowtransition/#getDuration) antes de modificar la transición para determinar si se almacena un valor explícito. Un valor de `-1` indica que no se ha establecido una duración explícita; un valor no negativo especifica la duración almacenada en milisegundos. El valor no establecido no es la duración de reproducción calculada: Aspose.Slides utiliza el tipo de transición y el valor de [getSpeed](https://reference.aspose.com/slides/es/php-java/aspose.slides/slideshowtransition/#getSpeed) para determinar esa duración. Establecer un tipo de transición puede inicializar una duración, así que inspecciona primero la configuración original.

```php
use aspose\slides\Presentation;

$presentation = new Presentation("input.pptx");
try {
    for ($slideIndex = 0; $slideIndex < java_values($presentation->getSlides()->size()); $slideIndex++) {
        $slide = $presentation->getSlides()->get_Item($slideIndex);
        $transition = $slide->getSlideShowTransition();
        $duration = java_values($transition->getDuration());

        if ($duration >= 0) {
            echo "Slide " . java_values($slide->getSlideNumber()) . ": stored transition duration is " . $duration . " ms." . PHP_EOL;
        } else {
            echo "Slide " . java_values($slide->getSlideNumber()) . ": no explicit duration; timing depends on transition type " . java_values($transition->getType()) . " and speed " . java_values($transition->getSpeed()) . "." . PHP_EOL;
        }
    }
} finally {
    $presentation->dispose();
}
```

## **Transición Morph**

La transición Morph anima los cambios entre objetos en diapositivas consecutivas. Para crear un efecto Morph sencillo, clona una diapositiva, mueve o redimensiona un objeto en el clon y aplica la transición Morph a la segunda diapositiva. Esto proporciona a los objetos correspondientes la animación entre sus estados original y modificado.

El siguiente ejemplo crea una diapositiva con un rectángulo de texto, clona la diapositiva y cambia la posición y el tamaño del rectángulo en el clon. Luego selecciona Morph del enumerado [TransitionType](https://reference.aspose.com/slides/es/php-java/aspose.slides/transitiontype/) para la segunda diapositiva. Abre el archivo guardado en un visor de presentaciones que admita Morph para ver el efecto durante la presentación.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\TransitionType;

$presentation = new Presentation();
try {
    $firstSlide = $presentation->getSlides()->get_Item(0);
    $rectangle = $firstSlide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 400, 100);
    $rectangle->getTextFrame()->setText("Morph transition");

    $secondSlide = $presentation->getSlides()->addClone($firstSlide);
    $movedRectangle = $secondSlide->getShapes()->get_Item(0);
    $movedRectangle->setX(java_values($movedRectangle->getX()) + 100);
    $movedRectangle->setY(java_values($movedRectangle->getY()) + 50);
    $movedRectangle->setWidth(java_values($movedRectangle->getWidth()) - 200);
    $movedRectangle->setHeight(java_values($movedRectangle->getHeight()) - 10);

    $secondSlide->getSlideShowTransition()->setType(TransitionType::Morph);

    $presentation->save("morph-transition.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Tipos de transición Morph**

El enumerado [TransitionMorphType](https://reference.aspose.com/slides/es/php-java/aspose.slides/transitionmorphtype/) controla cómo Morph empareja y anima el contenido:

- [ByObject](https://reference.aspose.com/slides/es/php-java/aspose.slides/transitionmorphtype/#ByObject) trata cada forma como un objeto completo.
- [ByWord](https://reference.aspose.com/slides/es/php-java/aspose.slides/transitionmorphtype/#ByWord) anima el texto emparejando palabras cuando sea posible.
- [ByChar](https://reference.aspose.com/slides/es/php-java/aspose.slides/transitionmorphtype/#ByChar) anima el texto emparejando caracteres cuando sea posible.

Usa [setType](https://reference.aspose.com/slides/es/php-java/aspose.slides/slideshowtransition/#setType) para seleccionar Morph antes de acceder a [getValue](https://reference.aspose.com/slides/es/php-java/aspose.slides/slideshowtransition/#getValue). El valor proporciona entonces un objeto [MorphTransition](https://reference.aspose.com/slides/es/php-java/aspose.slides/morphtransition/), cuyo método [setMorphType](https://reference.aspose.com/slides/es/php-java/aspose.slides/morphtransition/#setMorphType) selecciona el modo de emparejamiento.

Este ejemplo abre la presentación creada en la sección anterior y configura la segunda diapositiva para usar animación Morph basada en palabras.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\TransitionMorphType;
use aspose\slides\TransitionType;

$presentation = new Presentation("morph-transition.pptx");
try {
    if (java_values($presentation->getSlides()->size()) >= 2) {
        $transition = $presentation->getSlides()->get_Item(1)->getSlideShowTransition();
        $transition->setType(TransitionType::Morph);
        $morphTransition = $transition->getValue();

        if (!java_is_null($morphTransition)) {
            $morphTransition->setMorphType(TransitionMorphType::ByWord);
            $presentation->save("morph-by-word.pptx", SaveFormat::Pptx);
        } else {
            echo "Morph transition options are unavailable." . PHP_EOL;
        }
    } else {
        echo "The input presentation must contain at least two slides." . PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

## **Establecer efectos de transición**

Algunas transiciones exponen opciones adicionales, como la dirección o si el efecto comienza desde una pantalla negra. Las opciones disponibles dependen de la transición seleccionada con [setType](https://reference.aspose.com/slides/es/php-java/aspose.slides/slideshowtransition/#setType). Establece primero el tipo y luego utiliza el objeto de transición apropiado obtenido mediante [getValue](https://reference.aspose.com/slides/es/php-java/aspose.slides/slideshowtransition/#getValue).

El siguiente ejemplo aplica una transición Cut a la primera diapositiva de `input.pptx`. Llama a [setFromBlack](https://reference.aspose.com/slides/es/php-java/aspose.slides/optionalblacktransition/#setFromBlack) a través de [OptionalBlackTransition](https://reference.aspose.com/slides/es/php-java/aspose.slides/optionalblacktransition/) para que la transición comience desde una pantalla negra.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\TransitionType;

$presentation = new Presentation("input.pptx");
try {
    $transition = $presentation->getSlides()->get_Item(0)->getSlideShowTransition();
    $transition->setType(TransitionType::Cut);
    $cutTransition = $transition->getValue();

    if (!java_is_null($cutTransition)) {
        $cutTransition->setFromBlack(true);
        $presentation->save("cut-from-black.pptx", SaveFormat::Pptx);
    } else {
        echo "Cut transition options are unavailable." . PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

## **Preguntas frecuentes**

**¿Puedo controlar la velocidad de reproducción de una transición de diapositiva?**

Sí. Prefiere [setDuration](https://reference.aspose.com/slides/es/php-java/aspose.slides/slideshowtransition/#setDuration) cuando necesites una duración exacta del efecto en milisegundos. Usa [setSpeed](https://reference.aspose.com/slides/es/php-java/aspose.slides/slideshowtransition/#setSpeed) cuando una categoría predefinida de [TransitionSpeed](https://reference.aspose.com/slides/es/php-java/aspose.slides/transitionspeed/) —Slow, Medium o Fast— sea suficiente y no se establezca una duración explícita. Estas configuraciones controlan el efecto de transición independientemente del retraso de avance automático.

**¿Puedo adjuntar audio a una transición y hacerlo reproducir en bucle?**

Sí. Asigna audio incrustado con [setSound](https://reference.aspose.com/slides/es/php-java/aspose.slides/slideshowtransition/#setSound), pasa StartSound del enumerado [TransitionSoundMode](https://reference.aspose.com/slides/es/php-java/aspose.slides/transitionsoundmode/) a [setSoundMode](https://reference.aspose.com/slides/es/php-java/aspose.slides/slideshowtransition/#setSoundMode) y habilita [setSoundLoop](https://reference.aspose.com/slides/es/php-java/aspose.slides/slideshowtransition/#setSoundLoop) con `true`. El audio se repetirá hasta el siguiente evento de sonido en la presentación.

**¿Cuál es la forma más rápida de aplicar la misma transición a todas las diapositivas?**

Recorre la colección [getSlides](https://reference.aspose.com/slides/es/php-java/aspose.slides/presentation/#getSlides) de la presentación y llama a [setType](https://reference.aspose.com/slides/es/php-java/aspose.slides/slideshowtransition/#setType) con el mismo valor para la transición de cada diapositiva. Establece cualquier opción de temporización y efecto dentro del mismo bucle para mantener el comportamiento coherente en todas las diapositivas.

**¿Cómo puedo comprobar qué transición está actualmente establecida en una diapositiva?**

Llama a [getType](https://reference.aspose.com/slides/es/php-java/aspose.slides/slideshowtransition/#getType) sobre el resultado de [getSlideShowTransition](https://reference.aspose.com/slides/es/php-java/aspose.slides/baseslide/#getSlideShowTransition) de la diapositiva. Devuelve un valor del enumerado [TransitionType](https://reference.aspose.com/slides/es/php-java/aspose.slides/transitiontype/); None indica que no se ha aplicado ningún efecto de transición.