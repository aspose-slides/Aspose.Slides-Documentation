---
title: Gestionar transiciones de diapositivas en presentaciones usando JavaScript
linktitle: Transición de diapositiva
type: docs
weight: 80
url: /es/nodejs-java/slide-transition/
keywords:
- transición de diapositiva
- agregar transición de diapositiva
- aplicar transición de diapositiva
- transición de diapositiva avanzada
- transición Morph
- tipo de transición
- efecto de transición
- PowerPoint
- OpenDocument
- presentación
- Node.js
- JavaScript
- Aspose.Slides
description: "Aplicar transiciones de diapositivas, configurar el avance automático de diapositivas y personalizar Morph y otros efectos de transición con Aspose.Slides para Node.js a través de Java."
---
## **Visión general**

Las transiciones de diapositivas controlan cómo aparecen las diapositivas durante una presentación. Con Aspose.Slides para Node.js a través de Java, puedes elegir un efecto de transición para cada diapositiva, configurar el avance mediante clic del ratón o temporizador, y ajustar opciones específicas de un efecto. Este artículo utiliza ejemplos en JavaScript para aplicar transiciones, establecer duraciones exactas de transición, gestionar el tiempo de la diapositiva y crear una transición Morph entre dos diapositivas. Los ejemplos también muestran cómo guardar la configuración en un archivo PPTX.

## **Agregar transición de diapositiva**

Para aplicar una transición, carga una presentación con la clase [Presentation](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/presentation/) y accede a la configuración de transición de la diapositiva a través de [getSlideShowTransition](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/baseslide/#getSlideShowTransition). Usa [setType](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/slideshowtransition/#setType) con un valor de la enumeración [TransitionType](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/transitiontype/), luego guarda la presentación.

El siguiente ejemplo aplica una transición Circle a la primera diapositiva y una transición Comb a la segunda. Utiliza un archivo `input.pptx` con al menos dos diapositivas.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("input.pptx");
try {
    if (presentation.getSlides().size() >= 2) {
        presentation.getSlides().get_Item(0).getSlideShowTransition().setType(slides.TransitionType.Circle);
        presentation.getSlides().get_Item(1).getSlideShowTransition().setType(slides.TransitionType.Comb);

        presentation.save("slide-transitions.pptx", slides.SaveFormat.Pptx);
    } else {
        console.log("The input presentation must contain at least two slides.");
    }
} finally {
    presentation.dispose();
}
```

## **Agregar transición de diapositiva avanzada**

Puedes configurar cuánto tiempo permanece una diapositiva en pantalla y si un clic del ratón avanza la presentación. Los siguientes métodos controlan este comportamiento:

- [setAdvanceOnClick](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/slideshowtransition/#setAdvanceOnClick) permite al espectador avanzar haciendo clic con el ratón.
- [setAdvanceAfter](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/slideshowtransition/#setAdvanceAfter) habilita el avance automático.
- [setAdvanceAfterTime](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/slideshowtransition/#setAdvanceAfterTime) especifica el retardo antes del avance automático, en milisegundos.

Habilita tanto el avance por clic como el temporizado para que el espectador pueda pasar con un clic o esperar al temporizador. Para usar solo el temporizador, pasa `false` a [setAdvanceOnClick]. El retardo controla cuándo avanza la presentación; no establece la duración del efecto visual de transición.

Este ejemplo asigna diferentes efectos a las tres primeras diapositivas y habilita el avance automático después de 3, 5 y 7 segundos, respectivamente. Los clics del ratón también pueden avanzar estas diapositivas. Utiliza un archivo `input.pptx` con al menos tres diapositivas.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("input.pptx");
try {
    if (presentation.getSlides().size() >= 3) {
        const firstTransition = presentation.getSlides().get_Item(0).getSlideShowTransition();
        firstTransition.setType(slides.TransitionType.Circle);
        firstTransition.setAdvanceOnClick(true);
        firstTransition.setAdvanceAfter(true);
        firstTransition.setAdvanceAfterTime(3000);

        const secondTransition = presentation.getSlides().get_Item(1).getSlideShowTransition();
        secondTransition.setType(slides.TransitionType.Comb);
        secondTransition.setAdvanceOnClick(true);
        secondTransition.setAdvanceAfter(true);
        secondTransition.setAdvanceAfterTime(5000);

        const thirdTransition = presentation.getSlides().get_Item(2).getSlideShowTransition();
        thirdTransition.setType(slides.TransitionType.Zoom);
        thirdTransition.setAdvanceOnClick(true);
        thirdTransition.setAdvanceAfter(true);
        thirdTransition.setAdvanceAfterTime(7000);

        presentation.save("advanced-transitions.pptx", slides.SaveFormat.Pptx);
    } else {
        console.log("The input presentation must contain at least three slides.");
    }
} finally {
    presentation.dispose();
}
```

Para comprobar si el avance temporizado está habilitado, llama a [getAdvanceAfter](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/slideshowtransition/#getAdvanceAfter). Un retardo almacenado por sí solo no indica que el temporizador esté activo.

El siguiente ejemplo abre el archivo guardado arriba, informa de cada temporizador habilitado y deshabilita el avance automático para las diapositivas con un retardo superior a dos segundos. Habilita los clics del ratón para esas diapositivas y guarda la configuración actualizada.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("advanced-transitions.pptx");
try {
    for (let i = 0; i < presentation.getSlides().size(); i++) {
        const slide = presentation.getSlides().get_Item(i);
        const transition = slide.getSlideShowTransition();

        if (transition.getAdvanceAfter()) {
            console.log("Slide " + slide.getSlideNumber() + ": advance after " + transition.getAdvanceAfterTime() + " ms.");

            if (transition.getAdvanceAfterTime() > 2000) {
                transition.setAdvanceAfter(false);
                transition.setAdvanceOnClick(true);
            }
        }
    }

    presentation.save("adjusted-transitions.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Controlar el tiempo de transición con precisión**

Usa [setDuration](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/slideshowtransition/#setDuration) para especificar la longitud exacta de un efecto de transición en milisegundos. El método [getSlideShowTransition](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/baseslide/#getSlideShowTransition) de la diapositiva expone estas configuraciones a través de [SlideShowTransition](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/slideshowtransition/):

| Método | Propósito |
| --- | --- |
| [setDuration](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/slideshowtransition/#setDuration) | Establece la duración del propio efecto de transición, en milisegundos. |
| [setAdvanceAfterTime](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/slideshowtransition/#setAdvanceAfterTime) | Establece el retardo antes de que la diapositiva avance automáticamente, en milisegundos. Pasa `true` a [setAdvanceAfter](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/slideshowtransition/#setAdvanceAfter) para activar este temporizador. |
| [setSpeed](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/slideshowtransition/#setSpeed) | Selecciona una categoría de velocidad predefinida de [TransitionSpeed](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/transitionspeed/): Lenta, Media o Rápida. Se usa cuando no se especifica una duración exacta. |

[setDuration] controla solo el efecto de transición; no determina cuánto tiempo permanece visible la diapositiva. Configura el retardo de avance automático por separado. Cuando no se establece una duración explícita, Aspose.Slides determina la duración del efecto a partir del tipo de transición y el valor de [getSpeed].

### **Aplicar la misma duración a todas las diapositivas**

Para mantener un ritmo constante, aplica el mismo efecto y la misma duración exacta a todas las diapositivas. Este ejemplo carga `input.pptx`, selecciona Fade de [TransitionType], y asigna a cada transición una duración de 750 milisegundos. Por separado habilita el avance automático después de 5 000 milisegundos y deshabilita el avance mediante clic del ratón, luego guarda el resultado como PPTX.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("input.pptx");
try {
    for (let i = 0; i < presentation.getSlides().size(); i++) {
        const slide = presentation.getSlides().get_Item(i);
        const transition = slide.getSlideShowTransition();
        transition.setType(slides.TransitionType.Fade);
        transition.setDuration(750);

        // Configurar el avance automático de forma independiente a la duración del efecto.
        transition.setAdvanceAfter(true);
        transition.setAdvanceAfterTime(5000);
        transition.setAdvanceOnClick(false);
    }

    presentation.save("precise-transitions.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Establecer duraciones diferentes para diapositivas individuales**

Las distintas diapositivas pueden usar duraciones de efecto diferentes. Por ejemplo, utiliza una transición breve para una diapositiva de título y una más larga para la introducción de una sección. Este ejemplo establece 500 milisegundos para la primera diapositiva y 1,200 milisegundos para la segunda. Usa un archivo `input.pptx` con al menos dos diapositivas.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("input.pptx");
try {
    if (presentation.getSlides().size() >= 2) {
        const firstTransition = presentation.getSlides().get_Item(0).getSlideShowTransition();
        firstTransition.setType(slides.TransitionType.Fade);
        firstTransition.setDuration(500);

        const secondTransition = presentation.getSlides().get_Item(1).getSlideShowTransition();
        secondTransition.setType(slides.TransitionType.Push);
        secondTransition.setDuration(1200);

        presentation.save("individual-transition-durations.pptx", slides.SaveFormat.Pptx);
    } else {
        console.log("The input presentation must contain at least two slides.");
    }
} finally {
    presentation.dispose();
}
```

### **Coordinar transiciones con salida animada**

Al preparar un [animated GIF](/slides/es/nodejs-java/convert-powerpoint-to-animated-gif/), una [HTML5 presentation](/slides/es/nodejs-java/export-to-html5/) o un [video](/slides/es/nodejs-java/convert-powerpoint-to-video/), establece duraciones de transición exactas antes de la exportación para que coincidan con el ritmo previsto. Por ejemplo, usa un fundido de 600 milisegundos entre escenas y ajusta el retardo de avance de cada diapositiva por separado para permitir tiempo a su narración o contenido.

Para GIF y video, coordina la frecuencia de fotogramas de salida con la duración del efecto: 600 milisegundos corresponden a 18 fotogramas a 30 fps. En HTML5, habilita transiciones animadas en la configuración de exportación. Verifica los efectos y opciones de tiempo admitidos por el formato de exportación elegido y visualiza la salida para confirmar la sincronización.

### **Leer una duración de transición existente**

Llama a [getDuration](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/slideshowtransition/#getDuration) antes de modificar la transición para determinar si se almacena un valor explícito. Un valor de `-1` indica que no se ha establecido una duración explícita; un valor no negativo especifica la duración almacenada en milisegundos. El valor no establecido no es la duración calculada de reproducción: Aspose.Slides usa el tipo de transición y el valor de [getSpeed] para determinar esa duración. Establecer un tipo de transición puede inicializar una duración, así que inspecciona primero la configuración original.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("input.pptx");
try {
    for (let i = 0; i < presentation.getSlides().size(); i++) {
        const slide = presentation.getSlides().get_Item(i);
        const transition = slide.getSlideShowTransition();
        const duration = transition.getDuration();

        if (duration >= 0) {
            console.log("Slide " + slide.getSlideNumber() + ": stored transition duration is " + duration + " ms.");
        } else {
            console.log("Slide " + slide.getSlideNumber() + ": no explicit duration; timing depends on transition type " + transition.getType() + " and speed " + transition.getSpeed() + ".");
        }
    }
} finally {
    presentation.dispose();
}
```

## **Transición Morph**

La transición Morph anima los cambios entre objetos en diapositivas consecutivas. Para crear un efecto Morph sencillo, clona una diapositiva, mueve o redimensiona un objeto en el clon y aplica la transición Morph a la segunda diapositiva. Esto permite que los objetos correspondientes se animen entre su estado original y el modificado.

El siguiente ejemplo crea una diapositiva con un rectángulo de texto, clona la diapositiva y cambia la posición y el tamaño del rectángulo en el clon. Luego selecciona Morph de la enumeración [TransitionType] para la segunda diapositiva. Abre el archivo guardado en un visor de presentaciones que admita Morph para ver el efecto durante la presentación.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation();
try {
    const firstSlide = presentation.getSlides().get_Item(0);
    const rectangle = firstSlide.getShapes().addAutoShape(slides.ShapeType.Rectangle, 100, 100, 400, 100);
    rectangle.getTextFrame().setText("Morph transition");

    const secondSlide = presentation.getSlides().addClone(firstSlide);
    const movedRectangle = secondSlide.getShapes().get_Item(0);
    movedRectangle.setX(movedRectangle.getX() + 100);
    movedRectangle.setY(movedRectangle.getY() + 50);
    movedRectangle.setWidth(movedRectangle.getWidth() - 200);
    movedRectangle.setHeight(movedRectangle.getHeight() - 10);

    secondSlide.getSlideShowTransition().setType(slides.TransitionType.Morph);

    presentation.save("morph-transition.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Tipos de transición Morph**

La enumeración [TransitionMorphType](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/transitionmorphtype/) controla cómo Morph empareja y anima el contenido:

- [ByObject](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/transitionmorphtype/#ByObject) trata cada forma como un objeto completo.
- [ByWord](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/transitionmorphtype/#ByWord) anima el texto coincidiendo palabras cuando sea posible.
- [ByChar](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/transitionmorphtype/#ByChar) anima el texto coincidiendo caracteres cuando sea posible.

Usa [setType](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/slideshowtransition/#setType) para seleccionar Morph antes de acceder a [getValue](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/slideshowtransition/#getValue). El valor proporciona entonces un objeto [MorphTransition], cuyo método [setMorphType](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/morphtransition/#setMorphType) selecciona el modo de coincidencia.

```javascript
const java = require("java");
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("morph-transition.pptx");
try {
    if (presentation.getSlides().size() >= 2) {
        const transition = presentation.getSlides().get_Item(1).getSlideShowTransition();
        transition.setType(slides.TransitionType.Morph);
        const transitionValue = transition.getValue();

        if (java.instanceOf(transitionValue, "com.aspose.slides.IMorphTransition")) {
            transitionValue.setMorphType(slides.TransitionMorphType.ByWord);
            presentation.save("morph-by-word.pptx", slides.SaveFormat.Pptx);
        } else {
            console.log("Morph transition options are unavailable.");
        }
    } else {
        console.log("The input presentation must contain at least two slides.");
    }
} finally {
    presentation.dispose();
}
```

## **Establecer efectos de transición**

Algunas transiciones exponen opciones adicionales, como dirección o si el efecto comienza desde una pantalla negra. Las opciones disponibles dependen de la transición seleccionada con [setType]. Establece el tipo primero y luego usa el objeto de transición apropiado obtenido mediante [getValue].

El siguiente ejemplo aplica una transición Cut a la primera diapositiva de `input.pptx`. Llama a [setFromBlack](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/optionalblacktransition/#setFromBlack) a través de [OptionalBlackTransition] para que la transición comience desde una pantalla negra.

```javascript
const java = require("java");
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("input.pptx");
try {
    const transition = presentation.getSlides().get_Item(0).getSlideShowTransition();
    transition.setType(slides.TransitionType.Cut);
    const transitionValue = transition.getValue();

    if (java.instanceOf(transitionValue, "com.aspose.slides.IOptionalBlackTransition")) {
        transitionValue.setFromBlack(true);
        presentation.save("cut-from-black.pptx", slides.SaveFormat.Pptx);
    } else {
        console.log("Cut transition options are unavailable.");
    }
} finally {
    presentation.dispose();
}
```

## **Preguntas frecuentes**

**¿Puedo controlar la velocidad de reproducción de una transición de diapositiva?**

Sí. Prefiere [setDuration] cuando necesites una duración exacta del efecto en milisegundos. Usa [setSpeed] cuando una categoría predefinida de [TransitionSpeed] — Lenta, Media o Rápida — sea suficiente y no se establezca una duración explícita. Estas configuraciones controlan el efecto de transición independientemente del retardo de avance automático.

**¿Puedo adjuntar audio a una transición y hacerlo en bucle?**

Sí. Asigna audio incrustado con [setSound], pasa StartSound de la enumeración [TransitionSoundMode] a [setSoundMode] y habilita [setSoundLoop] con `true`. El audio se reproducirá en bucle hasta el siguiente evento de sonido en la presentación.

**¿Cuál es la forma más rápida de aplicar la misma transición a todas las diapositivas?**

Recorre la colección [getSlides] de la presentación y llama a [setType] con el mismo valor para la transición de cada diapositiva. Configura cualquier temporización y opciones de efecto en el mismo bucle para mantener el comportamiento consistente en todas las diapositivas.

**¿Cómo puedo comprobar qué transición está establecida actualmente en una diapositiva?**

Llama a [getType] sobre el resultado de [getSlideShowTransition] de la diapositiva. Devuelve un valor de la enumeración [TransitionType]; None indica que no se ha aplicado ningún efecto de transición.