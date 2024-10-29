---
title: Transición de Diapositiva
type: docs
weight: 80
url: /es/androidjava/slide-transition/
keywords: "transición de diapositivas PowerPoint, transición de morfología en Java"
description: "transición de diapositivas PowerPoint, transición de morfología de PowerPoint en Java"
---


## **Descripción General**
{{% alert color="primary" %}} 

Aspose.Slides para Android a través de Java también permite a los desarrolladores gestionar o personalizar los efectos de transición de las diapositivas. En este tema, discutiremos cómo controlar las transiciones de diapositivas con gran facilidad utilizando Aspose.Slides para Android a través de Java.

{{% /alert %}} 

Para facilitar la comprensión, hemos demostrado el uso de Aspose.Slides para Android a través de Java para gestionar transiciones de diapositivas simples. Los desarrolladores pueden no solo aplicar diferentes efectos de transición de diaposiativas, sino también personalizar el comportamiento de estos efectos de transición.

## **Agregar Transición de Diapositiva**
Para crear un efecto de transición de diapositiva simple, siga los pasos a continuación:

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation).
1. Aplique un Tipo de Transición de Diapositiva en la diapositiva de uno de los efectos de transición ofrecidos por Aspose.Slides para Android a través de Java a través de la enumeración TransitionType.
1. Escriba el archivo de presentación modificado.

```java
// Instanciar la clase Presentation para cargar el archivo de presentación fuente
Presentation presentation = new Presentation("AccessSlides.pptx");
try {
    // Aplicar transición de tipo círculo en la diapositiva 1
    presentation.getSlides().get_Item(0).getSlideShowTransition().setType(TransitionType.Circle);

    // Aplicar transición de tipo combinación en la diapositiva 2
    presentation.getSlides().get_Item(1).getSlideShowTransition().setType(TransitionType.Comb);

    // Escribir la presentación en el disco
    presentation.save("SampleTransition_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Agregar Transición de Diapositiva Avanzada**
En la sección anterior, solo aplicamos un efecto de transición simple en la diapositiva. Ahora, para mejorar aún más ese efecto de transición simple y controlarlo, siga los pasos a continuación:

1. Cree una instancia de [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation).
1. Aplique un Tipo de Transición de Diapositiva en la diapositiva de uno de los efectos de transición ofrecidos por Aspose.Slides para Android a través de Java.
1. También puede configurar la transición para Avanzar al Hacer Clic, después de un período de tiempo específico o ambos.
1. Si la transición de diapositiva está habilitada para Avanzar al Hacer Clic, la transición solo avanzará cuando alguien haga clic con el mouse. Además, si la propiedad Avanzar Después de Tiempo está configurada, la transición avanzará automáticamente después de que pase el tiempo de avance especificado.
1. Escriba la presentación modificada como un archivo de presentación.

```java
// Instanciar la clase Presentation que representa un archivo de presentación
Presentation pres = new Presentation("BetterSlideTransitions.pptx");
try {
    // Aplicar transición de tipo círculo en la diapositiva 1
    pres.getSlides().get_Item(0).getSlideShowTransition().setType(TransitionType.Circle);

    // Configurar el tiempo de transición de 3 segundos
    pres.getSlides().get_Item(0).getSlideShowTransition().setAdvanceOnClick(true);
    pres.getSlides().get_Item(0).getSlideShowTransition().setAdvanceAfterTime(3000);

    // Aplicar transición de tipo combinación en la diapositiva 2
    pres.getSlides().get_Item(1).getSlideShowTransition().setType(TransitionType.Comb);
    
    // Configurar el tiempo de transición de 5 segundos
    pres.getSlides().get_Item(1).getSlideShowTransition().setAdvanceOnClick(true);
    pres.getSlides().get_Item(1).getSlideShowTransition().setAdvanceAfterTime(5000);

    // Aplicar transición de tipo zoom en la diapositiva 3
    pres.getSlides().get_Item(2).getSlideShowTransition().setType(TransitionType.Zoom);
    
    // Configurar el tiempo de transición de 7 segundos
    pres.getSlides().get_Item(2).getSlideShowTransition().setAdvanceOnClick(true);
    pres.getSlides().get_Item(2).getSlideShowTransition().setAdvanceAfterTime(7000);

    // Escribir la presentación en el disco
    pres.save("SampleTransition_out.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **Transición de Morfología**
{{% alert color="primary" %}} 

Aspose.Slides para Android a través de Java ahora soporta la [Transición de Morfología](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMorphTransition). Representan la nueva transición de morfología introducida en PowerPoint 2019.

{{% /alert %}} 

La transición de morfología permite animar un movimiento suave de una diapositiva a la siguiente. Este artículo describe el concepto y cómo usar la transición de morfología. Para usar la transición de morfología de manera efectiva, necesitará tener dos diapositivas con al menos un objeto en común. La manera más fácil es duplicar la diapositiva y luego mover el objeto en la segunda diapositiva a un lugar diferente.

El siguiente fragmento de código muestra cómo agregar un clon de la diapositiva con algo de texto a la presentación y establecer una transición de [tipo morfología](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TransitionType) a la segunda diapositiva.

```java
Presentation presentation = new Presentation();
try {
    AutoShape autoshape = (AutoShape)presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 100);
    autoshape.getTextFrame().setText("Transición de Morfología en Presentaciones de PowerPoint");

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

## **Tipos de Transición de Morfología**
Se ha añadido la nueva enumeración [TransitionMorphType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TransitionMorphType). Representa diferentes tipos de transición de diapositiva de morfología.

La enumeración TransitionMorphType tiene tres miembros:

- ByObject: La transición de morfología se realizará considerando las formas como objetos indivisibles.
- ByWord: La transición de morfología se realizará transfiriendo el texto por palabras donde sea posible.
- ByChar: La transición de morfología se realizará transfiriendo el texto por caracteres donde sea posible.

El siguiente fragmento de código muestra cómo establecer la transición de morfología a la diapositiva y cambiar el tipo de morfología:

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

## **Establecer Efectos de Transición**
Aspose.Slides para Android a través de Java soporta establecer los efectos de transición como, de negro, de izquierda, de derecha, etc. Para establecer el Efecto de Transición, siga los pasos a continuación:

- Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
- Obtenga la referencia de la diapositiva.
- Establezca el efecto de transición.
- Escriba la presentación como un archivo [PPTX ](https://docs.fileformat.com/presentation/pptx/).

En el ejemplo dado a continuación, hemos establecido los efectos de transición.

```java
// Crear una instancia de la clase Presentation
Presentation presentation = new Presentation("AccessSlides.pptx");
try {
    // Establecer efecto
    presentation.getSlides().get_Item(0).getSlideShowTransition().setType(TransitionType.Cut);
    ((OptionalBlackTransition)presentation.getSlides().get_Item(0).getSlideShowTransition().getValue()).setFromBlack(true);
    
    // Escribir la presentación en el disco
    presentation.save("SetTransitionEffects_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```