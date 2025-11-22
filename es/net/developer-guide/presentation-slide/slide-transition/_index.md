---
title: Transición de diapositiva
type: docs
weight: 90
url: /es/net/slide-transition/
keywords: "Agregar transición de diapositiva, Transición de diapositiva de PowerPoint, Transición morph, Transición de diapositiva avanzada, Efectos de transición, C#, Csharp, .NET, Aspose.Slides"
description: "Agregar transición de diapositiva de PowerPoint y efectos de transición en C# o .NET"
---

## **Agregar transición de diapositiva**
Para facilitar la comprensión, hemos demostrado el uso de Aspose.Slides for .NET para administrar transiciones de diapositivas simples. Los desarrolladores pueden no solo aplicar diferentes efectos de transición de diapositiva en las diapositivas, sino también personalizar el comportamiento de estos efectos de transición. Para crear un efecto de transición de diapositiva simple, siga los pasos a continuación:

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
2. Aplique un tipo de transición de diapositiva en la diapositiva a partir de uno de los efectos de transición ofrecidos por Aspose.Slides for .NET mediante el enum TransitionType.
3. Guarde el archivo de presentación modificado.
```c#
// Instanciar la clase Presentation para cargar el archivo de presentación origen
using (Presentation presentation = new Presentation("AccessSlides.pptx"))
{
    // Aplicar transición tipo círculo en la diapositiva 1
    presentation.Slides[0].SlideShowTransition.Type = TransitionType.Circle;

    // Aplicar transición tipo peine en la diapositiva 2
    presentation.Slides[1].SlideShowTransition.Type = TransitionType.Comb;

    // Guardar la presentación en disco
    presentation.Save("SampleTransition_out.pptx", SaveFormat.Pptx);
}
```


## **Agregar transición de diapositiva avanzada**
En la sección anterior, solo aplicamos un efecto de transición simple en la diapositiva. Ahora, para mejorar y controlar ese efecto de transición simple, siga los pasos a continuación:

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
2. Aplique un tipo de transición de diapositiva en la diapositiva a partir de uno de los efectos de transición ofrecidos por Aspose.Slides for .NET.
3. También puede configurar la transición para Avanzar al hacer clic, después de un periodo de tiempo específico o ambos.
4. Si la transición de diapositiva está habilitada para Avanzar al hacer clic, la transición solo avanzará cuando alguien haga clic con el ratón. Además, si se establece la propiedad Advance After Time, la transición avanzará automáticamente después de que transcurra el tiempo especificado.
5. Guarde la presentación modificada como un archivo de presentación.
```c#
// Instanciar la clase Presentation que representa un archivo de presentación
using (Presentation pres = new Presentation("BetterSlideTransitions.pptx"))
{

    // Aplicar transición tipo círculo en la diapositiva 1
    pres.Slides[0].SlideShowTransition.Type = TransitionType.Circle;


    // Establecer el tiempo de transición de 3 segundos
    pres.Slides[0].SlideShowTransition.AdvanceOnClick = true;
    pres.Slides[0].SlideShowTransition.AdvanceAfterTime = 3000;

    // Aplicar transición tipo peine en la diapositiva 2
    pres.Slides[1].SlideShowTransition.Type = TransitionType.Comb;


    // Establecer el tiempo de transición de 5 segundos
    pres.Slides[1].SlideShowTransition.AdvanceOnClick = true;
    pres.Slides[1].SlideShowTransition.AdvanceAfterTime = 5000;

    // Aplicar transición tipo zoom en la diapositiva 3
    pres.Slides[2].SlideShowTransition.Type = TransitionType.Zoom;


    // Establecer el tiempo de transición de 7 segundos
    pres.Slides[2].SlideShowTransition.AdvanceOnClick = true;
    pres.Slides[2].SlideShowTransition.AdvanceAfterTime = 7000;

    // Guardar la presentación en disco
    pres.Save("SampleTransition_out.pptx", SaveFormat.Pptx);
}
```


Además, utilizando la propiedad [AdvanceAfter](https://reference.aspose.com/slides/net/aspose.slides/islideshowtransition/advanceafter/) puede comprobar si una transición de diapositiva ha sido configurada para pasar a la siguiente diapositiva o desactivar la configuración.

Este código C# demuestra la operación:
```c#
 // Instancia una clase Presentation que representa un archivo de presentación
 using (Presentation pres = new Presentation("SampleTransition_out.pptx"))
 {
     foreach (ISlide slide in pres.Slides)
     {
         // Obtiene la transición de la diapositiva
         ISlideShowTransition slideTransition = slide.SlideShowTransition;

         // Verifica si la configuración Advance After Time está habilitada
         if (slideTransition.AdvanceAfter)
         {
             // Imprime el valor de Advance After Time
             Console.WriteLine("The slide #" + slide.SlideNumber + " AdvancedAfterTime: " + slideTransition.AdvanceAfterTime);
         }

         // Desactiva la transición después de un tiempo específico si el valor AdvancedAfterTime es mayor a 2 segundos
         if (slideTransition.AdvanceAfterTime > 2000)
         {
             slideTransition.AdvanceAfter = false;
         }
     }
 }
```


## **Transición Morph**
Aspose.Slides for .NET ahora admite la [Morph Transition](https://reference.aspose.com/slides/net/aspose.slides.slideshow/imorphtransition). Representa una nueva transición morph introducida en PowerPoint 2019. La transición Morph le permite animar un movimiento suave de una diapositiva a la siguiente. Este artículo describe el concepto y cómo usar la transición Morph. Para utilizar la transición Morph de manera eficaz, necesitará dos diapositivas que compartan al menos un objeto. La forma más fácil es duplicar la diapositiva y luego mover el objeto en la segunda diapositiva a otro lugar.

El siguiente fragmento de código muestra cómo agregar un clon de la diapositiva con texto a la presentación y establecer una transición de [morph type](https://reference.aspose.com/slides/net/aspose.slides.slideshow/imorphtransition/properties/morphtype) en la segunda diapositiva.
```c#
using (Presentation presentation = new Presentation())
{
    AutoShape autoshape = (AutoShape)presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 400, 100);
    autoshape.TextFrame.Text = "Morph Transition in PowerPoint Presentations";

    presentation.Slides.AddClone(presentation.Slides[0]);

    presentation.Slides[1].Shapes[0].X += 100;
    presentation.Slides[1].Shapes[0].Y += 50;
    presentation.Slides[1].Shapes[0].Width -= 200;
    presentation.Slides[1].Shapes[0].Height -= 10;

    presentation.Slides[1].SlideShowTransition.Type = Aspose.Slides.SlideShow.TransitionType.Morph;

    presentation.Save("presentation-out.pptx", SaveFormat.Pptx);
}
```


## **Tipos de transición Morph**
Se ha añadido el nuevo enumerado [Aspose.Slides.SlideShow.TransitionMorphType](https://reference.aspose.com/slides/net/aspose.slides.slideshow/transitionmorphtype). Representa diferentes tipos de transición de diapositiva Morph.

El enumerado TransitionMorphType tiene tres miembros:

- ByObject: La transición Morph se realizará considerando las formas como objetos indivisibles.
- ByWord: La transición Morph se realizará transfiriendo el texto palabra por palabra cuando sea posible.
- ByChar: La transición Morph se realizará transfiriendo el texto carácter por carácter cuando sea posible.

El siguiente fragmento de código muestra cómo establecer la transición morph en una diapositiva y cambiar el tipo de morph:
```c#
using (Presentation presentation = new Presentation("presentation.pptx"))
{
    presentation.Slides[0].SlideShowTransition.Type = TransitionType.Morph;
    ((IMorphTransition)presentation.Slides[0].SlideShowTransition.Value).MorphType = TransitionMorphType.ByWord;
    presentation.Save("presentation-out.pptx", SaveFormat.Pptx);
}
```


## **Establecer efectos de transición**
Aspose.Slides for .NET permite establecer efectos de transición como, desde negro, desde la izquierda, desde la derecha, etc. Para establecer el efecto de transición, siga los pasos a continuación:

- Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
- Obtenga la referencia de la diapositiva.
- Establezca el efecto de transición.
- Guarde la presentación como un archivo [PPTX](https://docs.fileformat.com/presentation/pptx/).

En el ejemplo a continuación, hemos configurado los efectos de transición.
```c#
// Crear una instancia de la clase Presentation
Presentation presentation = new Presentation("AccessSlides.pptx");

// Establecer efecto
presentation.Slides[0].SlideShowTransition.Type = TransitionType.Cut;
((OptionalBlackTransition)presentation.Slides[0].SlideShowTransition.Value).FromBlack = true;

// Guardar la presentación en disco
presentation.Save("SetTransitionEffects_out.pptx", SaveFormat.Pptx);
```


## **Preguntas frecuentes**

**¿Puedo controlar la velocidad de reproducción de una transición de diapositiva?**

Sí. Establezca la [Speed](https://reference.aspose.com/slides/net/aspose.slides.slideshow/slideshowtransition/speed/) de la transición usando la configuración [TransitionSpeed](https://reference.aspose.com/slides/net/aspose.slides.slideshow/transitionspeed/) (por ejemplo, lento/medio/rápido).

**¿Puedo adjuntar audio a una transición y hacer que se repita?**

Sí. Puede incrustar un sonido para la transición y controlar su comportamiento mediante configuraciones como modo de sonido y bucle (por ejemplo, [Sound](https://reference.aspose.com/slides/net/aspose.slides.slideshow/slideshowtransition/sound/), [SoundMode](https://reference.aspose.com/slides/net/aspose.slides.slideshow/slideshowtransition/soundmode/), [SoundLoop](https://reference.aspose.com/slides/net/aspose.slides.slideshow/slideshowtransition/soundloop/), además de metadatos como [SoundIsBuiltIn](https://reference.aspose.com/slides/net/aspose.slides.slideshow/slideshowtransition/soundisbuiltin/) y [SoundName](https://reference.aspose.com/slides/net/aspose.slides.slideshow/slideshowtransition/soundname/)).

**¿Cuál es la forma más rápida de aplicar la misma transición a todas las diapositivas?**

Configure el tipo de transición deseado en la configuración de transición de cada diapositiva; las transiciones se almacenan por diapositiva, por lo que aplicar el mismo tipo en todas las diapositivas brinda un resultado consistente.

**¿Cómo puedo comprobar qué transición está configurada actualmente en una diapositiva?**

Inspeccione la [transition settings](https://reference.aspose.com/slides/net/aspose.slides/baseslide/slideshowtransition/) de la diapositiva y lea su [transition type](https://reference.aspose.com/slides/net/aspose.slides.slideshow/slideshowtransition/type/); ese valor le indica exactamente qué efecto está aplicado.