---
title: Transición de diapositiva
type: docs
weight: 80
url: /es/nodejs-java/slide-transition/
keywords: "Transición de diapositiva de PowerPoint, transición morph en JavaScript"
description: "Transición de diapositiva de PowerPoint, transición morph de PowerPoint en JavaScript"
---

## **Descripción general**
{{% alert color="primary" %}} 

Aspose.Slides for Node.js via Java también permite a los desarrolladores gestionar o personalizar los efectos de transición de diapositivas. En este tema, hablaremos sobre cómo controlar las transiciones de diapositivas de forma muy sencilla utilizando Aspose.Slides for Node.js via Java.

{{% /alert %}} 

Para facilitar la comprensión, hemos demostrado el uso de Aspose.Slides for Node.js via Java para gestionar transiciones de diapositivas simples. Los desarrolladores pueden no solo aplicar diferentes efectos de transición a las diapositivas, sino también personalizar el comportamiento de dichos efectos.

## **Agregar transición de diapositiva**
Para crear un efecto de transición de diapositiva simple, siga los pasos a continuación:

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation).
2. Aplique un **Slide Transition Type** a la diapositiva eligiendo uno de los efectos de transición ofrecidos por Aspose.Slides for Node.js via Java a través del enumerado **TransitionType**.
3. Guarde el archivo de presentación modificado.
```javascript
// Instanciar la clase Presentation para cargar el archivo de presentación origen
var presentation = new aspose.slides.Presentation("AccessSlides.pptx");
try {
    // Aplicar transición tipo círculo en la diapositiva 1
    presentation.getSlides().get_Item(0).getSlideShowTransition().setType(aspose.slides.TransitionType.Circle);
    // Aplicar transición tipo peine en la diapositiva 2
    presentation.getSlides().get_Item(1).getSlideShowTransition().setType(aspose.slides.TransitionType.Comb);
    // Guardar la presentación en disco
    presentation.save("SampleTransition_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```


## **Agregar transición de diapositiva avanzada**
En la sección anterior solo se aplicó un efecto de transición sencillo a la diapositiva. Ahora, para mejorar y controlar ese efecto simple, siga los pasos a continuación:

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation).
2. Aplique un **Slide Transition Type** a la diapositiva eligiendo uno de los efectos de transición ofrecidos por Aspose.Slides for Node.js via Java.
3. También puede configurar la transición para que avance al hacer clic, después de un período de tiempo específico o ambas.
4. Si la transición está habilitada para **Advance On Click**, solo avanzará cuando alguien haga clic con el mouse. Además, si se establece la propiedad **Advance After Time**, la transición avanzará automáticamente después de transcurrido el tiempo especificado.
5. Guarde la presentación modificada como archivo de presentación.
```javascript
// Instanciar la clase Presentation que representa un archivo de presentación
var pres = new aspose.slides.Presentation("BetterSlideTransitions.pptx");
try {
    // Aplicar transición tipo círculo en la diapositiva 1
    pres.getSlides().get_Item(0).getSlideShowTransition().setType(aspose.slides.TransitionType.Circle);
    // Establecer el tiempo de transición de 3 segundos
    pres.getSlides().get_Item(0).getSlideShowTransition().setAdvanceOnClick(true);
    pres.getSlides().get_Item(0).getSlideShowTransition().setAdvanceAfterTime(3000);
    // Aplicar transición tipo peine en la diapositiva 2
    pres.getSlides().get_Item(1).getSlideShowTransition().setType(aspose.slides.TransitionType.Comb);
    // Establecer el tiempo de transición de 5 segundos
    pres.getSlides().get_Item(1).getSlideShowTransition().setAdvanceOnClick(true);
    pres.getSlides().get_Item(1).getSlideShowTransition().setAdvanceAfterTime(5000);
    // Aplicar transición tipo zoom en la diapositiva 3
    pres.getSlides().get_Item(2).getSlideShowTransition().setType(aspose.slides.TransitionType.Zoom);
    // Establecer el tiempo de transición de 7 segundos
    pres.getSlides().get_Item(2).getSlideShowTransition().setAdvanceOnClick(true);
    pres.getSlides().get_Item(2).getSlideShowTransition().setAdvanceAfterTime(7000);
    // Guardar la presentación en disco
    pres.save("SampleTransition_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```


## **Transición Morph**
{{% alert color="primary" %}} 

Aspose.Slides for Node.js via Java ahora admite la [Morph Transition](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MorphTransition). Representa la nueva transición morph introducida en PowerPoint 2019.

{{% /alert %}} 

La transición Morph permite animar un movimiento suave de una diapositiva a la siguiente. Este artículo describe el concepto y cómo usar la transición Morph. Para usarla eficazmente, necesita dos diapositivas que compartan al menos un objeto. La forma más fácil es duplicar la diapositiva y luego mover el objeto en la segunda diapositiva a otra posición.

El siguiente fragmento de código muestra cómo agregar una copia de la diapositiva con texto a la presentación y establecer una transición de [morph type](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TransitionType) en la segunda diapositiva.
```javascript
var presentation = new aspose.slides.Presentation();
try {
    var autoshape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 400, 100);
    autoshape.getTextFrame().setText("Morph Transition in PowerPoint Presentations");
    presentation.getSlides().addClone(presentation.getSlides().get_Item(0));
    var shape = presentation.getSlides().get_Item(1).getShapes().get_Item(0);
    shape.setX(shape.getX() + 100);
    shape.setY(shape.getY() + 50);
    shape.setWidth(shape.getWidth() - 200);
    shape.setHeight(shape.getHeight() - 10);
    presentation.getSlides().get_Item(1).getSlideShowTransition().setType(aspose.slides.TransitionType.Morph);
    presentation.save("presentation-out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```


## **Tipos de transición Morph**
Se ha añadido el nuevo enumerado [TransitionMorphType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TransitionMorphType). Representa los diferentes tipos de transición Morph de diapositiva.

El enumerado **TransitionMorphType** tiene tres miembros:

- **ByObject**: La transición Morph se realizará considerando las formas como objetos indivisibles.
- **ByWord**: La transición Morph se realizará transfiriendo el texto por palabras cuando sea posible.
- **ByChar**: La transición Morph se realizará transfiriendo el texto por caracteres cuando sea posible.

El siguiente fragmento de código muestra cómo establecer una transición morph en una diapositiva y cambiar el tipo morph:
```javascript
var presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    presentation.getSlides().get_Item(0).getSlideShowTransition().setType(aspose.slides.TransitionType.Morph);
    presentation.getSlides().get_Item(0).getSlideShowTransition().getValue().setMorphType(aspose.slides.TransitionMorphType.ByWord);
    presentation.save("presentation-out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```


## **Establecer efectos de transición**
Aspose.Slides for Node.js via Java soporta la configuración de efectos de transición como “from black”, “from left”, “from right”, etc. Para establecer el efecto de transición, siga los pasos a continuación:

- Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation).
- Obtenga la referencia de la diapositiva.
- Configure el efecto de transición.
- Guarde la presentación como un archivo [PPTX](https://docs.fileformat.com/presentation/pptx/).

En el ejemplo que se muestra a continuación, hemos configurado los efectos de transición.
```javascript
// Crear una instancia de la clase Presentation
var presentation = new aspose.slides.Presentation("AccessSlides.pptx");
try {
    // Establecer efecto
    presentation.getSlides().get_Item(0).getSlideShowTransition().setType(aspose.slides.TransitionType.Cut);
    presentation.getSlides().get_Item(0).getSlideShowTransition().getValue().setFromBlack(true);
    // Guardar la presentación en disco
    presentation.save("SetTransitionEffects_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```


## **Preguntas frecuentes**

**¿Puedo controlar la velocidad de reproducción de una transición de diapositiva?**

Sí. Establezca la [speed](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/setspeed/) de la transición mediante la configuración [TransitionSpeed](https://reference.aspose.com/slides/nodejs-java/aspose.slides/transitionspeed/) (por ejemplo, slow/medium/fast).

**¿Puedo adjuntar audio a una transición y hacer que se repita?**

Sí. Puede incrustar un sonido para la transición y controlar su comportamiento mediante configuraciones como modo de sonido y bucle (por ejemplo, [setSound](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/setsound/), [setSoundMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/setsoundmode/), [setSoundLoop](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/setsoundloop/), además de metadatos como [setSoundIsBuiltIn](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/setsoundisbuiltin/) y [setSoundName](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/setsoundname/)).

**¿Cuál es la forma más rápida de aplicar la misma transición a todas las diapositivas?**

Configure el tipo de transición deseado en la configuración de transición de cada diapositiva; las transiciones se almacenan por diapositiva, por lo que aplicar el mismo tipo en todas las diapositivas produce un resultado consistente.

**¿Cómo puedo verificar qué transición está actualmente configurada en una diapositiva?**

Inspeccione la [transition settings](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseslide/#getSlideShowTransition) de la diapositiva y lea su [transition type](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/gettype/); ese valor indica exactamente qué efecto está aplicado.