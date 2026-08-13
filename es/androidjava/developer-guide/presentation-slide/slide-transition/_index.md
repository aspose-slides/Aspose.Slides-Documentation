---
title: Gestionar transiciones de diapositivas en presentaciones en Android
linktitle: Transición de diapositiva
type: docs
weight: 80
url: /es/androidjava/slide-transition/
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
- Android
- Java
- Aspose.Slides
description: "Descubra cómo personalizar las transiciones de diapositivas en Aspose.Slides para Android mediante Java, con una guía paso a paso para presentaciones de PowerPoint y OpenDocument."
---
## **Visión general**

Este artículo explica cómo gestionar las transiciones de diapositivas en presentaciones usando Aspose.Slides. Muestra cómo aplicar tipos de transición a las diapositivas, configurar el comportamiento de la transición, como avanzar al hacer clic o después de un tiempo especificado, usar la transición Morph y sus tipos, y establecer opciones de efecto de transición. Los ejemplos demuestran cómo cargar o crear una presentación, modificar la configuración de transición para diapositivas seleccionadas y guardar el resultado como un archivo PPTX. El artículo también responde a preguntas comunes sobre la velocidad de la transición, los sonidos de transición, la aplicación de la misma transición a varias diapositivas y cómo comprobar la transición actualmente establecida en una diapositiva.

## **Agregar transición de diapositiva**
Para crear un efecto de transición de diapositiva simple, siga los pasos a continuación:

1. Crear una instancia de la clase [Presentación](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/presentation).
1. Aplicar un Tipo de transición de diapositiva en la diapositiva a partir de uno de los efectos de transición ofrecidos por Aspose.Slides para Android mediante Java a través del enum TransitionType.
1. Escribir el archivo de presentación modificado.

```java
import com.aspose.slides.*;

// Instanciar la clase Presentation para cargar el archivo de presentación fuente
Presentation presentation = new Presentation("AccessSlides.pptx");
try {
    // Aplicar transición tipo círculo en la diapositiva 1
    presentation.getSlides().get_Item(0).getSlideShowTransition().setType(TransitionType.Circle);

    // Aplicar transición tipo peine en la diapositiva 2
    presentation.getSlides().get_Item(1).getSlideShowTransition().setType(TransitionType.Comb);

    // Guardar la presentación en disco
    presentation.save("SampleTransition_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Agregar transición de diapositiva avanzada**
En la sección anterior solo aplicamos un efecto de transición simple en la diapositiva. Ahora, para que ese efecto simple sea aún mejor y esté controlado, siga los pasos a continuación:

1. Crear una instancia de la clase [Presentación](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/presentation).
1. Aplicar un Tipo de transición de diapositiva en la diapositiva a partir de uno de los efectos de transición ofrecidos por Aspose.Slides para Android mediante Java.
1. También puede establecer la transición para avanzar al hacer clic, después de un período de tiempo específico o ambos.
1. Si la transición de la diapositiva está habilitada para avanzar al hacer clic, la transición solo avanzará cuando alguien haga clic con el ratón. Además, si se establece la propiedad Advance After Time, la transición avanzará automáticamente después de que transcurra el tiempo de avance especificado.
1. Escribir la presentación modificada como un archivo de presentación.

```java
import com.aspose.slides.*;

// Instanciar la clase Presentation que representa un archivo de presentación
Presentation pres = new Presentation("BetterSlideTransitions.pptx");
try {
    // Aplicar transición tipo círculo en la diapositiva 1
    pres.getSlides().get_Item(0).getSlideShowTransition().setType(TransitionType.Circle);

    // Avanzar al hacer clic o automáticamente después de 3 segundos
    pres.getSlides().get_Item(0).getSlideShowTransition().setAdvanceOnClick(true);
    pres.getSlides().get_Item(0).getSlideShowTransition().setAdvanceAfterTime(3000);

    // Aplicar transición tipo peine en la diapositiva 2
    pres.getSlides().get_Item(1).getSlideShowTransition().setType(TransitionType.Comb);
    
    // Avanzar al hacer clic o automáticamente después de 5 segundos
    pres.getSlides().get_Item(1).getSlideShowTransition().setAdvanceOnClick(true);
    pres.getSlides().get_Item(1).getSlideShowTransition().setAdvanceAfterTime(5000);

    // Aplicar transición tipo zoom en la diapositiva 3
    pres.getSlides().get_Item(2).getSlideShowTransition().setType(TransitionType.Zoom);
    
    // Avanzar al hacer clic o automáticamente después de 7 segundos
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

Aspose.Slides para Android mediante Java ahora admite la [Transición Morph](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/IMorphTransition). Representan la nueva transición morph introducida en PowerPoint 2019.

{{% /alert %}} 

La transición Morph le permite animar un movimiento suave de una diapositiva a la siguiente. Este artículo describe el concepto y cómo usar la transición Morph. Para usar la transición Morph de manera eficaz, necesitará dos diapositivas con al menos un objeto en común. La forma más fácil es duplicar la diapositiva y luego mover el objeto en la segunda diapositiva a otro lugar.

El siguiente fragmento de código muestra cómo agregar una copia de la diapositiva con algún texto a la presentación y establecer una transición de [tipo morph](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/TransitionType) en la segunda diapositiva.

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
Se ha añadido el nuevo enum [TransitionMorphType](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/TransitionMorphType). Representa diferentes tipos de transición de diapositiva Morph.

El enum TransitionMorphType tiene tres miembros:

- ByObject: La transición Morph se realizará considerando las formas como objetos indivisibles.
- ByWord: La transición Morph se realizará transfiriendo el texto por palabras cuando sea posible.
- ByChar: La transición Morph se realizará transfiriendo el texto por caracteres cuando sea posible.

El siguiente fragmento de código muestra cómo establecer una transición morph en una diapositiva y cambiar el tipo morph:

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
Aspose.Slides para Android mediante Java admite la configuración de efectos de transición como, desde negro, desde la izquierda, desde la derecha, etc. Para establecer el efecto de transición, siga los pasos a continuación:

- Crear una instancia de la clase [Presentación](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/Presentation).
- Obtener la referencia de la diapositiva.
- Establecer el efecto de transición.
- Escribir la presentación como un archivo [PPTX](https://docs.fileformat.com/presentation/pptx/).

En el ejemplo que se muestra a continuación, hemos establecido los efectos de transición.

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

Sí. Establezca la [velocidad](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/slideshowtransition/#setSpeed-int-) de la transición mediante la configuración [TransitionSpeed](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/transitionspeed/) (p. ej., lento/medio/rápido).

### ¿Puedo adjuntar audio a una transición y hacer que se repita?

Sí. Puede incrustar un sonido para la transición y controlar su comportamiento mediante ajustes como modo de sonido y bucle (p. ej., [setSound](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/slideshowtransition/#setSound-com.aspose.slides.IAudio-), [setSoundMode](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/slideshowtransition/#setSoundMode-int-), [setSoundLoop](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/slideshowtransition/#setSoundLoop-boolean-), además de metadatos como [setSoundIsBuiltIn](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/slideshowtransition/#setSoundIsBuiltIn-boolean-) y [setSoundName](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/slideshowtransition/#setSoundName-java.lang.String-)).

### ¿Cuál es la forma más rápida de aplicar la misma transición a todas las diapositivas?

Configure el tipo de transición deseado en la configuración de transición de cada diapositiva; las transiciones se almacenan por diapositiva, por lo que aplicar el mismo tipo a todas las diapositivas produce un resultado coherente.

### ¿Cómo puedo comprobar qué transición está establecida actualmente en una diapositiva?

Inspeccione la [configuración de transición](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/baseslide/#getSlideShowTransition--) de la diapositiva y lea su [tipo de transición](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/slideshowtransition/#setType-int-); ese valor le indica exactamente qué efecto está aplicado.