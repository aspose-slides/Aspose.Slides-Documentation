---
title: Gestionar transiciones de diapositiva en presentaciones usando Java
linktitle: Transición de diapositiva
type: docs
weight: 80
url: /es/java/slide-transition/
keywords:
- transición de diapositiva
- añadir transición de diapositiva
- aplicar transición de diapositiva
- transición de diapositiva avanzada
- transición morph
- tipo de transición
- efecto de transición
- PowerPoint
- OpenDocument
- presentación
- Java
- Aspose.Slides
description: "Descubra cómo personalizar las transiciones de diapositiva en Aspose.Slides para Java, con una guía paso a paso para presentaciones de PowerPoint y OpenDocument."
---
## **Resumen**

Este artículo explica cómo gestionar las transiciones de diapositiva en presentaciones usando Aspose.Slides. Muestra cómo aplicar tipos de transición a las diapositivas, configurar el comportamiento de la transición como avanzar al hacer clic o después de un tiempo especificado, comprobar y desactivar el avance automático, usar la transición Morph y sus tipos, y establecer opciones de efectos de transición. Los ejemplos demuestran cómo cargar o crear una presentación, modificar la configuración de transición para diapositivas seleccionadas y guardar el resultado como archivo PPTX. El artículo también responde a preguntas habituales sobre la velocidad de la transición, los sonidos de transición, la aplicación de la misma transición a varias diapositivas y cómo comprobar la transición actualmente establecida en una diapositiva.

## **Añadir transición de diapositiva**

Para crear un efecto de transición de diapositiva sencillo, siga los pasos a continuación:

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/java/com.aspose.slides/presentation).
2. Aplique un tipo de transición de diapositiva en la diapositiva a partir de uno de los efectos de transición ofrecidos por Aspose.Slides for Java mediante el enum TransitionType.
3. Guarde el archivo de la presentación modificada.

```java
import com.aspose.slides.*;

// Instanciar la clase Presentation para cargar el archivo de presentación fuente
Presentation presentation = new Presentation("AccessSlides.pptx");
try {
    // Aplicar transición de tipo círculo en la diapositiva 1
    presentation.getSlides().get_Item(0).getSlideShowTransition().setType(TransitionType.Circle);

    // Aplicar transición de tipo peine en la diapositiva 2
    presentation.getSlides().get_Item(1).getSlideShowTransition().setType(TransitionType.Comb);

    // Guardar la presentación en disco
    presentation.save("SampleTransition_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Añadir transición de diapositiva avanzada**

En la sección anterior, solo aplicamos un efecto de transición sencillo en la diapositiva. Ahora, para mejorar y controlar ese efecto de transición sencillo, siga los pasos a continuación:

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/java/com.aspose.slides/presentation).
2. Aplique un tipo de transición de diapositiva en la diapositiva a partir de uno de los efectos de transición ofrecidos por Aspose.Slides for Java.
3. También puede configurar la transición para avanzar al hacer clic, después de un periodo de tiempo específico o ambos.
4. Si la transición de diapositiva está habilitada para avanzar al hacer clic, la transición solo avanzará cuando alguien haga clic con el mouse. Además, si se establece la propiedad Advance After Time, la transición avanzará automáticamente después de que haya transcurrido el tiempo especificado.
5. Guarde la presentación modificada como archivo de presentación.

```java
import com.aspose.slides.*;

// Instanciar la clase Presentation que representa un archivo de presentación
Presentation pres = new Presentation("BetterSlideTransitions.pptx");
try {
    // Aplicar transición de tipo círculo en la diapositiva 1
    pres.getSlides().get_Item(0).getSlideShowTransition().setType(TransitionType.Circle);

    // Establecer el tiempo de transición a 3 segundos
    pres.getSlides().get_Item(0).getSlideShowTransition().setAdvanceOnClick(true);
    pres.getSlides().get_Item(0).getSlideShowTransition().setAdvanceAfterTime(3000);

    // Aplicar transición de tipo peine en la diapositiva 2
    pres.getSlides().get_Item(1).getSlideShowTransition().setType(TransitionType.Comb);
    
    // Establecer el tiempo de transición a 5 segundos
    pres.getSlides().get_Item(1).getSlideShowTransition().setAdvanceOnClick(true);
    pres.getSlides().get_Item(1).getSlideShowTransition().setAdvanceAfterTime(5000);

    // Aplicar transición de tipo zoom en la diapositiva 3
    pres.getSlides().get_Item(2).getSlideShowTransition().setType(TransitionType.Zoom);
    
    // Establecer el tiempo de transición a 7 segundos
    pres.getSlides().get_Item(2).getSlideShowTransition().setAdvanceOnClick(true);
    pres.getSlides().get_Item(2).getSlideShowTransition().setAdvanceAfterTime(7000);

    // Guardar la presentación en disco
    pres.save("SampleTransition_out.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **Transición Morph**

{{% alert color="info" %}} 
Aspose.Slides for Java ahora admite la [Morph Transition](https://reference.aspose.com/slides/es/java/com.aspose.slides/IMorphTransition). Representan la nueva transición morph introducida en PowerPoint 2019.
{{% /alert %}} 

La transición Morph le permite animar un movimiento suave de una diapositiva a la siguiente. Este artículo describe el concepto y cómo usar la transición Morph. Para usar la transición Morph de manera eficaz, necesitará dos diapositivas que compartan al menos un objeto. La forma más fácil es duplicar la diapositiva y luego mover el objeto en la segunda diapositiva a una posición distinta.

El siguiente fragmento de código muestra cómo añadir un clon de la diapositiva con texto a la presentación y establecer una transición de [tipo morph](https://reference.aspose.com/slides/es/java/com.aspose.slides/TransitionType) en la segunda diapositiva.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    AutoShape autoshape = (AutoShape)presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 100);
    autoshape.getTextFrame().setText("Morph Transition in PowerPoint Presentations");

    presentation.getSlides().addClone(presentation.getSlides().get_Item(0));

    IShape shape = presentation.getSlides().get_Item(1).getShapes().get_Item(0);
    shape.setX(shape.getX() + 100);
    shape.setY(shape.getY() + 50);
    shape.setWidth(shape.getWidth() - 200);
    shape.setHeight(shape.getHeight() - 10);

    presentation.getSlides().get_Item(1).getSlideShowTransition().setType(com.aspose.slides.TransitionType.Morph);

    presentation.save("presentation-out.pptx", SaveFormat.Pptx);
}
finally {
    presentation.dispose();
}
```

## **Tipos de transición Morph**

Se ha añadido un nuevo enum [TransitionMorphType](https://reference.aspose.com/slides/es/java/com.aspose.slides/TransitionMorphType). Representa diferentes tipos de transición Morph de diapositiva.

El enum TransitionMorphType tiene tres miembros:

- ByObject: La transición Morph se realizará considerando las formas como objetos indivisibles.
- ByWord: La transición Morph se realizará transfiriendo el texto por palabras cuando sea posible.
- ByChar: La transición Morph se realizará transfiriendo el texto por caracteres cuando sea posible.

El siguiente fragmento de código muestra cómo establecer la transición morph en una diapositiva y cambiar el tipo de morph:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    presentation.getSlides().get_Item(0).getSlideShowTransition().setType(TransitionType.Morph);
    ((IMorphTransition)presentation.getSlides().get_Item(0).getSlideShowTransition().getValue()).setMorphType(TransitionMorphType.ByWord);
    presentation.save("presentation-out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Establecer efectos de transición**

Aspose.Slides for Java permite establecer efectos de transición como desde negro, desde la izquierda, desde la derecha, etc. Para establecer el efecto de transición, siga los pasos a continuación:

- Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/java/com.aspose.slides/Presentation).
- Obtenga la referencia de la diapositiva.
- Establezca el efecto de transición.
- Guarde la presentación como un archivo [PPTX ](https://docs.fileformat.com/presentation/pptx/).

En el ejemplo mostrado a continuación, hemos establecido los efectos de transición.

```java
import com.aspose.slides.*;

// Crear una instancia de la clase Presentation
Presentation presentation = new Presentation("AccessSlides.pptx");
try {
    // Establecer efecto
    presentation.getSlides().get_Item(0).getSlideShowTransition().setType(TransitionType.Cut);
    ((OptionalBlackTransition)presentation.getSlides().get_Item(0).getSlideShowTransition().getValue()).setFromBlack(true);
    
    // Guardar la presentación en disco
    presentation.save("SetTransitionEffects_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Preguntas frecuentes**

### ¿Puedo controlar la velocidad de reproducción de una transición de diapositiva?

Sí. Establezca la [velocidad](https://reference.aspose.com/slides/es/java/com.aspose.slides/slideshowtransition/#setSpeed-int-) de la transición utilizando el ajuste [TransitionSpeed](https://reference.aspose.com/slides/es/java/com.aspose.slides/transitionspeed/) (p. ej., lento/medio/rápido).

### ¿Puedo adjuntar audio a una transición y hacer que se repita en bucle?

Sí. Puede incrustar un sonido para la transición y controlar su comportamiento mediante ajustes como el modo de sonido y la reproducción en bucle (p. ej., [setSound](https://reference.aspose.com/slides/es/java/com.aspose.slides/slideshowtransition/#setSound-com.aspose.slides.IAudio-), [setSoundMode](https://reference.aspose.com/slides/es/java/com.aspose.slides/slideshowtransition/#setSoundMode-int-), [setSoundLoop](https://reference.aspose.com/slides/es/java/com.aspose.slides/slideshowtransition/#setSoundLoop-boolean-), además de metadatos como [setSoundIsBuiltIn](https://reference.aspose.com/slides/es/java/com.aspose.slides/slideshowtransition/#setSoundIsBuiltIn-boolean-) y [setSoundName](https://reference.aspose.com/slides/es/java/com.aspose.slides/slideshowtransition/#setSoundName-java.lang.String-)).

### ¿Cuál es la forma más rápida de aplicar la misma transición a todas las diapositivas?

Configure el tipo de transición deseado en la configuración de transición de cada diapositiva; las transiciones se almacenan por diapositiva, por lo que aplicar el mismo tipo a todas las diapositivas produce un resultado coherente.

### ¿Cómo puedo comprobar qué transición está establecida actualmente en una diapositiva?

Examine la [configuración de transición](https://reference.aspose.com/slides/es/java/com.aspose.slides/baseslide/#getSlideShowTransition--) de la diapositiva y lea su [tipo de transición](https://reference.aspose.com/slides/es/java/com.aspose.slides/slideshowtransition/#setType-int-); ese valor le indica exactamente qué efecto está aplicado.