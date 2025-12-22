---
title: Administrar transiciones de diapositivas en presentaciones en Android
linktitle: Transición de diapositiva
type: docs
weight: 80
url: /es/androidjava/slide-transition/
keywords:
- transición de diapositiva
- agregar transición de diapositiva
- aplicar transición de diapositiva
- transición de diapositiva avanzada
- transición morph
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
{{% alert color="primary" %}} 

Aspose.Slides for Android vía Java también permite a los desarrolladores gestionar o personalizar los efectos de transición de diapositivas. En este tema, hablaremos sobre cómo controlar las transiciones de diapositivas con gran facilidad usando Aspose.Slides for Android vía Java.

{{% /alert %}} 

Para facilitar la comprensión, hemos demostrado el uso de Aspose.Slides for Android vía Java para gestionar transiciones simples de diapositivas. Los desarrolladores pueden no solo aplicar diferentes efectos de transición a las diapositivas, sino también personalizar el comportamiento de dichos efectos.

## **Agregar transición de diapositiva**
Para crear un efecto de transición de diapositiva simple, siga los pasos a continuación:

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation).
1. Aplique un tipo de transición de diapositiva en la diapositiva a partir de uno de los efectos de transición ofrecidos por Aspose.Slides for Android vía Java mediante el enum TransitionType.
1. Guarde el archivo de presentación modificado.
```java
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


## **Agregar transición avanzada de diapositiva**
En la sección anterior aplicamos un efecto de transición simple a la diapositiva. Ahora, para mejorar y controlar aún más esa transición simple, siga los pasos a continuación:

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation).
1. Aplique un tipo de transición de diapositiva en la diapositiva a partir de uno de los efectos de transición ofrecidos por Aspose.Slides for Android vía Java.
1. También puede configurar la transición para avanzar al hacer clic, después de un período de tiempo específico o ambos.
1. Si la transición de diapositiva está configurada para avanzar al hacer clic, la transición solo avanzará cuando alguien haga clic con el ratón. Además, si se establece la propiedad Advance After Time, la transición avanzará automáticamente después de que transcurra el tiempo especificado.
1. Guarde la presentación modificada como un archivo de presentación.
```java
// Instanciar la clase Presentation que representa un archivo de presentación
Presentation pres = new Presentation("BetterSlideTransitions.pptx");
try {
    // Aplicar transición tipo círculo en la diapositiva 1
    pres.getSlides().get_Item(0).getSlideShowTransition().setType(TransitionType.Circle);

    // Establecer el tiempo de transición a 3 segundos
    pres.getSlides().get_Item(0).getSlideShowTransition().setAdvanceOnClick(true);
    pres.getSlides().get_Item(0).getSlideShowTransition().setAdvanceAfterTime(3000);

    // Aplicar transición tipo peine en la diapositiva 2
    pres.getSlides().get_Item(1).getSlideShowTransition().setType(TransitionType.Comb);
    
    // Establecer el tiempo de transición a 5 segundos
    pres.getSlides().get_Item(1).getSlideShowTransition().setAdvanceOnClick(true);
    pres.getSlides().get_Item(1).getSlideShowTransition().setAdvanceAfterTime(5000);

    // Aplicar transición tipo zoom en la diapositiva 3
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


## **Morph Transition**
{{% alert color="primary" %}} 

Aspose.Slides for Android vía Java ahora admite la [Morph Transition](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMorphTransition). Representa la nueva transición morph introducida en PowerPoint 2019.

{{% /alert %}} 

La transición Morph le permite animar un movimiento suave de una diapositiva a la siguiente. Este artículo describe el concepto y cómo usar la transición Morph. Para usar la transición Morph de manera eficaz, necesitará dos diapositivas que compartan al menos un objeto. La forma más fácil es duplicar la diapositiva y luego mover el objeto en la segunda diapositiva a otro lugar.

El siguiente fragmento de código muestra cómo agregar una copia de la diapositiva con texto a la presentación y establecer una transición de [morph type](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TransitionType) en la segunda diapositiva.
```java
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
Se ha añadido el nuevo enum [TransitionMorphType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TransitionMorphType). Representa diferentes tipos de transición de diapositivas Morph.

El enum TransitionMorphType tiene tres miembros:

- ByObject: La transición Morph se realizará considerando las formas como objetos indivisibles.
- ByWord: La transición Morph se realizará transfiriendo el texto por palabras cuando sea posible.
- ByChar: La transición Morph se realizará transfiriendo el texto por caracteres cuando sea posible.

El siguiente fragmento de código muestra cómo establecer una transición Morph en la diapositiva y cambiar el tipo de morph:
```java
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
Aspose.Slides for Android vía Java admite la configuración de efectos de transición como, desde negro, desde la izquierda, desde la derecha, etc. Para establecer el efecto de transición, siga los pasos a continuación:

- Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
- Obtenga la referencia de la diapositiva.
- Configure el efecto de transición.
- Guarde la presentación como un archivo [PPTX](https://docs.fileformat.com/presentation/pptx/).

En el ejemplo que se muestra a continuación, hemos configurado los efectos de transición.
```java
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


## **FAQ**

**¿Puedo controlar la velocidad de reproducción de una transición de diapositiva?**

Sí. Establezca la [speed](https://reference.aspose.com/slides/androidjava/com.aspose.slides/slideshowtransition/#setSpeed-int-) de la transición usando la configuración [TransitionSpeed](https://reference.aspose.com/slides/androidjava/com.aspose.slides/transitionspeed/) (por ejemplo, lento/medio/rápido).

**¿Puedo adjuntar audio a una transición y hacer que se repita en bucle?**

Sí. Puede incrustar un sonido para la transición y controlar su comportamiento mediante configuraciones como modo de sonido y bucle (por ejemplo, [setSound](https://reference.aspose.com/slides/androidjava/com.aspose.slides/slideshowtransition/#setSound-com.aspose.slides.IAudio-), [setSoundMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/slideshowtransition/#setSoundMode-int-), [setSoundLoop](https://reference.aspose.com/slides/androidjava/com.aspose.slides/slideshowtransition/#setSoundLoop-boolean-), además de metadatos como [setSoundIsBuiltIn](https://reference.aspose.com/slides/androidjava/com.aspose.slides/slideshowtransition/#setSoundIsBuiltIn-boolean-) y [setSoundName](https://reference.aspose.com/slides/androidjava/com.aspose.slides/slideshowtransition/#setSoundName-java.lang.String-)).

**¿Cuál es la forma más rápida de aplicar la misma transición a todas las diapositivas?**

Configure el tipo de transición deseado en la configuración de transición de cada diapositiva; las transiciones se almacenan por diapositiva, por lo que aplicar el mismo tipo en todas las diapositivas brinda un resultado consistente.

**¿Cómo puedo verificar qué transición está actualmente establecida en una diapositiva?**

Inspeccione la [transition settings](https://reference.aspose.com/slides/androidjava/com.aspose.slides/baseslide/#getSlideShowTransition--) de la diapositiva y lea su [transition type](https://reference.aspose.com/slides/androidjava/com.aspose.slides/slideshowtransition/#setType-int-); ese valor indica exactamente qué efecto está aplicado.