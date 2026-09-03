---
title: Gestionar transiciones de diapositivas en presentaciones usando Java
linktitle: Transición de diapositiva
type: docs
weight: 80
url: /es/java/slide-transition/
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
- Java
- Aspose.Slides
description: "Aplicar transiciones de diapositivas, configurar el avance automático de diapositivas y personalizar Morph y otros efectos de transición con Aspose.Slides para Java."
---
## **Visión general**

Las transiciones de diapositivas controlan cómo aparecen las diapositivas durante una presentación. Con Aspose.Slides para Java, puedes elegir un efecto de transición para cada diapositiva, configurar el avance mediante clic del ratón o temporizador, y ajustar opciones específicas de un efecto. Este artículo utiliza ejemplos en Java para aplicar transiciones, establecer duraciones exactas de transición, gestionar el tiempo de diapositiva y crear una transición Morph entre dos diapositivas. Los ejemplos también muestran cómo guardar la configuración en un archivo PPTX.

## **Agregar transición de diapositiva**

Para aplicar una transición, carga una presentación con la clase [Presentation](https://reference.aspose.com/slides/es/java/com.aspose.slides/presentation/) y accede a la configuración de transición de la diapositiva a través de [getSlideShowTransition](https://reference.aspose.com/slides/es/java/com.aspose.slides/ibaseslide/#getSlideShowTransition--). Utiliza [setType](https://reference.aspose.com/slides/es/java/com.aspose.slides/islideshowtransition/#setType-int-) con un valor de la enumeración [TransitionType](https://reference.aspose.com/slides/es/java/com.aspose.slides/transitiontype/), y luego guarda la presentación.

El siguiente ejemplo aplica una transición Circle a la primera diapositiva y una transición Comb a la segunda. Utiliza un archivo `input.pptx` con al menos dos diapositivas.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    if (presentation.getSlides().size() >= 2) {
        presentation.getSlides().get_Item(0).getSlideShowTransition().setType(TransitionType.Circle);
        presentation.getSlides().get_Item(1).getSlideShowTransition().setType(TransitionType.Comb);

        presentation.save("slide-transitions.pptx", SaveFormat.Pptx);
    } else {
        System.out.println("The input presentation must contain at least two slides.");
    }
} finally {
    presentation.dispose();
}
```

## **Agregar transición de diapositiva avanzada**

Puedes configurar cuánto tiempo permanece una diapositiva en pantalla y si un clic del ratón avanza la presentación. Los siguientes métodos controlan este comportamiento:

- [setAdvanceOnClick](https://reference.aspose.com/slides/es/java/com.aspose.slides/islideshowtransition/#setAdvanceOnClick-boolean-) permite al espectador avanzar al hacer clic con el ratón.
- [setAdvanceAfter](https://reference.aspose.com/slides/es/java/com.aspose.slides/islideshowtransition/#setAdvanceAfter-boolean-) habilita el avance automático.
- [setAdvanceAfterTime](https://reference.aspose.com/slides/es/java/com.aspose.slides/islideshowtransition/#setAdvanceAfterTime-long-) especifica el retraso antes del avance automático, en milisegundos.

Habilita tanto el avance por clic como por temporizador para que el espectador continúe con un clic o espere al temporizador. Para usar solo el temporizador, pasa `false` a [setAdvanceOnClick](https://reference.aspose.com/slides/es/java/com.aspose.slides/islideshowtransition/#setAdvanceOnClick-boolean-). El retraso controla cuándo avanza la presentación; no define la duración del efecto visual de transición.

Este ejemplo asigna diferentes efectos a las tres primeras diapositivas y habilita el avance automático después de 3, 5 y 7 segundos, respectivamente. Los clics del ratón también pueden avanzar estas diapositivas. Utiliza un archivo `input.pptx` con al menos tres diapositivas.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    if (presentation.getSlides().size() >= 3) {
        ISlideShowTransition firstTransition = presentation.getSlides().get_Item(0).getSlideShowTransition();
        firstTransition.setType(TransitionType.Circle);
        firstTransition.setAdvanceOnClick(true);
        firstTransition.setAdvanceAfter(true);
        firstTransition.setAdvanceAfterTime(3000);

        ISlideShowTransition secondTransition = presentation.getSlides().get_Item(1).getSlideShowTransition();
        secondTransition.setType(TransitionType.Comb);
        secondTransition.setAdvanceOnClick(true);
        secondTransition.setAdvanceAfter(true);
        secondTransition.setAdvanceAfterTime(5000);

        ISlideShowTransition thirdTransition = presentation.getSlides().get_Item(2).getSlideShowTransition();
        thirdTransition.setType(TransitionType.Zoom);
        thirdTransition.setAdvanceOnClick(true);
        thirdTransition.setAdvanceAfter(true);
        thirdTransition.setAdvanceAfterTime(7000);

        presentation.save("advanced-transitions.pptx", SaveFormat.Pptx);
    } else {
        System.out.println("The input presentation must contain at least three slides.");
    }
} finally {
    presentation.dispose();
}
```

Para comprobar si el avance por temporizador está habilitado, llama a [getAdvanceAfter](https://reference.aspose.com/slides/es/java/com.aspose.slides/islideshowtransition/#getAdvanceAfter--). Un retraso almacenado por sí solo no indica que el temporizador esté activo.

El siguiente ejemplo abre el archivo guardado anteriormente, informa de cada temporizador habilitado y deshabilita el avance automático para las diapositivas con un retraso superior a dos segundos. Habilita los clics del ratón para esas diapositivas y guarda la configuración actualizada.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("advanced-transitions.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        ISlideShowTransition transition = slide.getSlideShowTransition();

        if (transition.getAdvanceAfter()) {
            System.out.println("Slide " + slide.getSlideNumber() + ": advance after " + transition.getAdvanceAfterTime() + " ms.");

            if (transition.getAdvanceAfterTime() > 2000) {
                transition.setAdvanceAfter(false);
                transition.setAdvanceOnClick(true);
            }
        }
    }

    presentation.save("adjusted-transitions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Controlar el tiempo de transición con precisión**

Utiliza [setDuration](https://reference.aspose.com/slides/es/java/com.aspose.slides/islideshowtransition/#setDuration-int-) para especificar la longitud exacta de un efecto de transición en milisegundos. El método [getSlideShowTransition](https://reference.aspose.com/slides/es/java/com.aspose.slides/ibaseslide/#getSlideShowTransition--) de la diapositiva expone estas configuraciones a través de [ISlideShowTransition](https://reference.aspose.com/slides/es/java/com.aspose.slides/islideshowtransition/):

| Método | Propósito |
| --- | --- |
| [setDuration](https://reference.aspose.com/slides/es/java/com.aspose.slides/islideshowtransition/#setDuration-int-) | Establece la duración del propio efecto de transición, en milisegundos. |
| [setAdvanceAfterTime](https://reference.aspose.com/slides/es/java/com.aspose.slides/islideshowtransition/#setAdvanceAfterTime-long-) | Establece el retraso antes de que la diapositiva avance automáticamente, en milisegundos. Pasa `true` a [setAdvanceAfter](https://reference.aspose.com/slides/es/java/com.aspose.slides/islideshowtransition/#setAdvanceAfter-boolean-) para activar este temporizador. |
| [setSpeed](https://reference.aspose.com/slides/es/java/com.aspose.slides/islideshowtransition/#setSpeed-int-) | Selecciona una categoría de velocidad predefinida de [TransitionSpeed](https://reference.aspose.com/slides/es/java/com.aspose.slides/transitionspeed/): Lenta, Media o Rápida. Se usa cuando no se especifica una duración exacta. |

[setDuration] controla solo el efecto de transición; no determina cuánto tiempo permanece visible la diapositiva. Configura el retraso de avance automático por separado. Cuando no se establece una duración explícita, Aspose.Slides determina la duración del efecto a partir del tipo de transición y del valor de [getSpeed].

### **Aplicar la misma duración a todas las diapositivas**

Para mantener un ritmo constante, aplica el mismo efecto y la misma duración exacta a cada diapositiva. Este ejemplo carga `input.pptx`, selecciona Fade de [TransitionType] y asigna a cada transición una duración de 750 milisegundos. Además, habilita por separado el avance automático después de 5 000 milisegundos y deshabilita el avance mediante clic del ratón, y luego guarda el resultado como PPTX.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        ISlideShowTransition transition = slide.getSlideShowTransition();
        transition.setType(TransitionType.Fade);
        transition.setDuration(750);

        // Configura el avance automático de forma independiente de la duración del efecto.
        transition.setAdvanceAfter(true);
        transition.setAdvanceAfterTime(5000);
        transition.setAdvanceOnClick(false);
    }

    presentation.save("precise-transitions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Establecer duraciones diferentes para diapositivas individuales**

Las diapositivas pueden usar duraciones de efecto distintas. Por ejemplo, utiliza una transición breve para una diapositiva de título y una más larga para la introducción de una sección. Este ejemplo establece 500 ms para la primera diapositiva y 1 200 ms para la segunda. Usa un archivo `input.pptx` con al menos dos diapositivas.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    if (presentation.getSlides().size() >= 2) {
        ISlideShowTransition firstTransition = presentation.getSlides().get_Item(0).getSlideShowTransition();
        firstTransition.setType(TransitionType.Fade);
        firstTransition.setDuration(500);

        ISlideShowTransition secondTransition = presentation.getSlides().get_Item(1).getSlideShowTransition();
        secondTransition.setType(TransitionType.Push);
        secondTransition.setDuration(1200);

        presentation.save("individual-transition-durations.pptx", SaveFormat.Pptx);
    } else {
        System.out.println("The input presentation must contain at least two slides.");
    }
} finally {
    presentation.dispose();
}
```

### **Coordinar transiciones con salida animada**

Al preparar un [GIF animado](/slides/es/java/convert-powerpoint-to-animated-gif/), una presentación [HTML5](/slides/es/java/export-to-html5/) o un [video](/slides/es/java/convert-powerpoint-to-video/), establece duraciones de transición exactas antes de la exportación para que coincidan con el ritmo deseado. Por ejemplo, usa un fundido de 600 ms entre escenas y ajusta por separado el retraso de avance de cada diapositiva para permitir tiempo a la narración o al contenido.

Para GIF y video, coordina la velocidad de fotogramas de salida con la duración del efecto: 600 ms corresponden a 18 fotogramas a 30 fps. En HTML5, habilita las transiciones animadas en la configuración de exportación. Verifica los efectos y opciones de temporización compatibles con el formato de exportación elegido y visualiza una vista previa para confirmar la sincronización.

### **Leer la duración de una transición existente**

Llama a [getDuration](https://reference.aspose.com/slides/es/java/com.aspose.slides/islideshowtransition/#getDuration--) antes de modificar la transición para saber si está almacenado un valor explícito. Un valor de `-1` indica que no se ha establecido una duración explícita; un valor no negativo especifica la duración almacenada en milisegundos. El valor no establecido no es la duración de reproducción calculada: Aspose.Slides usa el tipo de transición y el valor de [getSpeed] para determinar esa duración. Establecer un tipo de transición puede inicializar una duración, por lo que conviene inspeccionar primero la configuración original.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        ISlideShowTransition transition = slide.getSlideShowTransition();
        int duration = transition.getDuration();

        if (duration >= 0) {
            System.out.println("Slide " + slide.getSlideNumber() + ": stored transition duration is " + duration + " ms.");
        } else {
            System.out.println("Slide " + slide.getSlideNumber() + ": no explicit duration; timing depends on transition type " + transition.getType() + " and speed " + transition.getSpeed() + ".");
        }
    }
} finally {
    presentation.dispose();
}
```

## **Transición Morph**

La transición Morph anima los cambios entre objetos en diapositivas consecutivas. Para crear un efecto Morph sencillo, clona una diapositiva, mueve o redimensiona un objeto en el clon y aplica la transición Morph a la segunda diapositiva. Esto proporciona a los objetos correspondientes la animación entre su estado original y el modificado.

El siguiente ejemplo crea una diapositiva con un rectángulo de texto, clona la diapositiva y cambia la posición y el tamaño del rectángulo en el clon. A continuación, selecciona Morph de la enumeración [TransitionType] para la segunda diapositiva. Abre el archivo guardado en un visor de presentaciones que admita Morph para ver el efecto durante la presentación.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide firstSlide = presentation.getSlides().get_Item(0);
    IAutoShape rectangle = firstSlide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 100);
    rectangle.getTextFrame().setText("Morph transition");

    ISlide secondSlide = presentation.getSlides().addClone(firstSlide);
    IShape movedRectangle = secondSlide.getShapes().get_Item(0);
    movedRectangle.setX(movedRectangle.getX() + 100);
    movedRectangle.setY(movedRectangle.getY() + 50);
    movedRectangle.setWidth(movedRectangle.getWidth() - 200);
    movedRectangle.setHeight(movedRectangle.getHeight() - 10);

    secondSlide.getSlideShowTransition().setType(TransitionType.Morph);

    presentation.save("morph-transition.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Tipos de transición Morph**

La enumeración [TransitionMorphType](https://reference.aspose.com/slides/es/java/com.aspose.slides/transitionmorphtype/) controla cómo Morph coincide y anima el contenido:

- [ByObject](https://reference.aspose.com/slides/es/java/com.aspose.slides/transitionmorphtype/#ByObject) trata cada forma como un objeto completo.
- [ByWord](https://reference.aspose.com/slides/es/java/com.aspose.slides/transitionmorphtype/#ByWord) anima el texto coincidendo palabras cuando sea posible.
- [ByChar](https://reference.aspose.com/slides/es/java/com.aspose.slides/transitionmorphtype/#ByChar) anima el texto coincidendo caracteres cuando sea posible.

Utiliza [setType](https://reference.aspose.com/slides/es/java/com.aspose.slides/islideshowtransition/#setType-int-) para seleccionar Morph antes de acceder a [getValue](https://reference.aspose.com/slides/es/java/com.aspose.slides/islideshowtransition/#getValue--). El valor proporcionado expone la interfaz [IMorphTransition](https://reference.aspose.com/slides/es/java/com.aspose.slides/imorphtransition/), cuyo método [setMorphType](https://reference.aspose.com/slides/es/java/com.aspose.slides/imorphtransition/#setMorphType-int-) elige el modo de coincidencia.

Este ejemplo abre la presentación creada en la sección anterior y configura la segunda diapositiva para que use animación Morph basada en palabras.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("morph-transition.pptx");
try {
    if (presentation.getSlides().size() >= 2) {
        ISlideShowTransition transition = presentation.getSlides().get_Item(1).getSlideShowTransition();
        transition.setType(TransitionType.Morph);
        ITransitionValueBase transitionValue = transition.getValue();

        if (transitionValue instanceof IMorphTransition) {
            IMorphTransition morphTransition = (IMorphTransition) transitionValue;
            morphTransition.setMorphType(TransitionMorphType.ByWord);
            presentation.save("morph-by-word.pptx", SaveFormat.Pptx);
        } else {
            System.out.println("Morph transition options are unavailable.");
        }
    } else {
        System.out.println("The input presentation must contain at least two slides.");
    }
} finally {
    presentation.dispose();
}
```

## **Establecer efectos de transición**

Algunas transiciones exponen opciones adicionales, como dirección o si el efecto comienza desde una pantalla negra. Las opciones disponibles dependen de la transición seleccionada con [setType]. Establece el tipo primero y luego usa la interfaz adecuada obtenida mediante [getValue].

El siguiente ejemplo aplica una transición Cut a la primera diapositiva de `input.pptx`. Llama a [setFromBlack](https://reference.aspose.com/slides/es/java/com.aspose.slides/ioptionalblacktransition/#setFromBlack-boolean-) a través de [IOptionalBlackTransition] para que la transición comience desde una pantalla negra.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    ISlideShowTransition transition = presentation.getSlides().get_Item(0).getSlideShowTransition();
    transition.setType(TransitionType.Cut);
    ITransitionValueBase transitionValue = transition.getValue();

    if (transitionValue instanceof IOptionalBlackTransition) {
        IOptionalBlackTransition cutTransition = (IOptionalBlackTransition) transitionValue;
        cutTransition.setFromBlack(true);
        presentation.save("cut-from-black.pptx", SaveFormat.Pptx);
    } else {
        System.out.println("Cut transition options are unavailable.");
    }
} finally {
    presentation.dispose();
}
```

## **Preguntas frecuentes**

**¿Puedo controlar la velocidad de reproducción de una transición de diapositiva?**

Sí. Prefiere [setDuration] cuando necesites una duración exacta del efecto en milisegundos. Usa [setSpeed] cuando una categoría predefinida de [TransitionSpeed] — Lenta, Media o Rápida — sea suficiente y no se haya establecido una duración explícita. Estas configuraciones controlan el efecto de transición de forma independiente del retraso de avance automático.

**¿Puedo adjuntar audio a una transición y hacer que se reproduzca en bucle?**

Sí. Asigna audio incrustado con [setSound], pasa `StartSound` de la enumeración [TransitionSoundMode] a [setSoundMode] y habilita [setSoundLoop] con `true`. El audio se repite hasta el próximo evento de sonido en la presentación.

**¿Cuál es la forma más rápida de aplicar la misma transición a todas las diapositivas?**

Recorre la colección [getSlides] de la presentación y llama a [setType] con el mismo valor para la transición de cada diapositiva. Establece cualquier opción de temporización y efecto dentro del mismo bucle para mantener el comportamiento coherente en todas las diapositivas.

**¿Cómo puedo comprobar qué transición está establecida actualmente en una diapositiva?**

Llama a [getType] sobre el resultado de [getSlideShowTransition] de la diapositiva. Devuelve un valor de la enumeración [TransitionType]; `None` indica que no se ha aplicado ningún efecto de transición.