---
title: Transición de Diapositiva
type: docs
weight: 90
url: /es/net/slide-transition/
keywords: "Agregar transición de diapositiva, transición de diapositiva de PowerPoint, transición de morph, transición de diapositiva avanzada, efectos de transición, C#, Csharp, .NET, Aspose.Slides"
description: " Agregue transición de diapositiva de PowerPoint y efectos de transición en C# o .NET "
---

## **Agregar Transición de Diapositiva**
Para facilitar la comprensión, hemos demostrado el uso de Aspose.Slides para .NET para gestionar transiciones de diapositivas simples. Los desarrolladores pueden no solo aplicar diferentes efectos de transición de diapositivas en las diapositivas, sino también personalizar el comportamiento de estos efectos de transición. Para crear un efecto de transición de diapositiva simple, siga los pasos a continuación:

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
1. Aplique un Tipo de Transición de Diapositiva en la diapositiva desde uno de los efectos de transición ofrecidos por Aspose.Slides para .NET a través del enum TransitionType.
1. Escriba el archivo de presentación modificado.

```c#
// Instanciar la clase Presentation para cargar el archivo de presentación fuente
using (Presentation presentation = new Presentation("AccessSlides.pptx"))
{
    // Aplicar transición de tipo círculo en la diapositiva 1
    presentation.Slides[0].SlideShowTransition.Type = TransitionType.Circle;

    // Aplicar transición de tipo peine en la diapositiva 2
    presentation.Slides[1].SlideShowTransition.Type = TransitionType.Comb;

    // Escribir la presentación en el disco
    presentation.Save("SampleTransition_out.pptx", SaveFormat.Pptx);
}
```


## **Agregar Transición de Diapositiva Avanzada**
En la sección anterior, solo aplicamos un efecto de transición simple en la diapositiva. Ahora, para mejorar y controlar aún más ese efecto de transición simple, siga los pasos a continuación:

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
1. Aplique un Tipo de Transición de Diapositiva en la diapositiva desde uno de los efectos de transición ofrecidos por Aspose.Slides para .NET.
1. También puede establecer la transición para Avanzar Al Hacer Clic, después de un período de tiempo específico o ambos.
1. Si la transición de diapositiva está habilitada para Avanzar Al Hacer Clic, la transición solo avanzará cuando alguien haga clic con el mouse. Además, si se establece la propiedad Avanzar Después del Tiempo, la transición avanzará automáticamente una vez transcurrido el tiempo de avance especificado.
1. Escriba la presentación modificada como un archivo de presentación.

```c#
// Instanciar la clase Presentation que representa un archivo de presentación
using (Presentation pres = new Presentation("BetterSlideTransitions.pptx"))
{

    // Aplicar transición de tipo círculo en la diapositiva 1
    pres.Slides[0].SlideShowTransition.Type = TransitionType.Circle;


    // Establecer el tiempo de transición de 3 segundos
    pres.Slides[0].SlideShowTransition.AdvanceOnClick = true;
    pres.Slides[0].SlideShowTransition.AdvanceAfterTime = 3000;

    // Aplicar transición de tipo peine en la diapositiva 2
    pres.Slides[1].SlideShowTransition.Type = TransitionType.Comb;


    // Establecer el tiempo de transición de 5 segundos
    pres.Slides[1].SlideShowTransition.AdvanceOnClick = true;
    pres.Slides[1].SlideShowTransition.AdvanceAfterTime = 5000;

    // Aplicar transición de tipo zoom en la diapositiva 3
    pres.Slides[2].SlideShowTransition.Type = TransitionType.Zoom;


    // Establecer el tiempo de transición de 7 segundos
    pres.Slides[2].SlideShowTransition.AdvanceOnClick = true;
    pres.Slides[2].SlideShowTransition.AdvanceAfterTime = 7000;

    // Escribir la presentación en el disco
    pres.Save("SampleTransition_out.pptx", SaveFormat.Pptx);
}
```

Además, utilizando la propiedad [AdvanceAfter](https://reference.aspose.com/slides/net/aspose.slides/islideshowtransition/advanceafter/), puede comprobar si se ha configurado una transición de diapositiva para avanzar a la siguiente diapositiva o deshabilitar la configuración.

Este código C# demuestra la operación:

```c#
// Instancia una clase Presentation que representa un archivo de presentación
using (Presentation pres = new Presentation("SampleTransition_out.pptx"))
{
    foreach (ISlide slide in pres.Slides)
    {
        // Obtiene la Transición de la diapositiva
        ISlideShowTransition slideTransition = slide.SlideShowTransition;

        // Verifica si la configuración Avanzar Después del Tiempo está habilitada
        if (slideTransition.AdvanceAfter)
        {
            // Imprime el valor de Avanzar Después del Tiempo
            Console.WriteLine("La diapositiva #" + slide.SlideNumber + " AdvancedAfterTime: " + slideTransition.AdvanceAfterTime);
        }

        // Desactiva la transición después de un tiempo específico si el valor de AdvancedAfterTime es mayor a 2 segundos
        if (slideTransition.AdvanceAfterTime > 2000)
        {
            slideTransition.AdvanceAfter = false;
        }
    }
}
```


## **Transición Morph**
Aspose.Slides para .NET ahora admite la [Transición Morph](https://reference.aspose.com/slides/net/aspose.slides.slideshow/imorphtransition). Representa una nueva transición morph introducida en PowerPoint 2019. La transición Morph permite animar un movimiento suave de una diapositiva a la siguiente. Este artículo describe el concepto y cómo usar la transición Morph. Para usar la transición Morph de manera efectiva, necesitará tener dos diapositivas con al menos un objeto en común. La forma más fácil es duplicar la diapositiva y luego mover el objeto en la segunda diapositiva a un lugar diferente.

El siguiente fragmento de código muestra cómo agregar un clon de la diapositiva con algo de texto a la presentación y establecer una transición de tipo [morph](https://reference.aspose.com/slides/net/aspose.slides.slideshow/imorphtransition/properties/morphtype) en la segunda diapositiva.

```c#
using (Presentation presentation = new Presentation())
{
    AutoShape autoshape = (AutoShape)presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 400, 100);
    autoshape.TextFrame.Text = "Transición Morph en Presentaciones de PowerPoint";

    presentation.Slides.AddClone(presentation.Slides[0]);

    presentation.Slides[1].Shapes[0].X += 100;
    presentation.Slides[1].Shapes[0].Y += 50;
    presentation.Slides[1].Shapes[0].Width -= 200;
    presentation.Slides[1].Shapes[0].Height -= 10;

    presentation.Slides[1].SlideShowTransition.Type = Aspose.Slides.SlideShow.TransitionType.Morph;

    presentation.Save("presentation-out.pptx", SaveFormat.Pptx);
}
```


## **Tipos de Transición Morph**
Se ha añadido un nuevo enum [Aspose.Slides.SlideShow.TransitionMorphType](https://reference.aspose.com/slides/net/aspose.slides.slideshow/transitionmorphtype). Representa diferentes tipos de transición morph de diapositiva.

El enum TransitionMorphType tiene tres miembros:

- ByObject: La transición morph se realizará considerando las formas como objetos indivisibles.
- ByWord: La transición morph se realizará transfiriendo texto por palabras cuando sea posible.
- ByChar: La transición morph se realizará transfiriendo texto por caracteres cuando sea posible.

El siguiente fragmento de código muestra cómo establecer la transición morph en la diapositiva y cambiar el tipo de morph:

```c#
using (Presentation presentation = new Presentation("presentation.pptx"))
{
    presentation.Slides[0].SlideShowTransition.Type = TransitionType.Morph;
    ((IMorphTransition)presentation.Slides[0].SlideShowTransition.Value).MorphType = TransitionMorphType.ByWord;
    presentation.Save("presentation-out.pptx", SaveFormat.Pptx);
}
```


## **Establecer Efectos de Transición**
Aspose.Slides para .NET admite establecer efectos de transición como, desde negro, desde la izquierda, desde la derecha, etc. Para establecer el Efecto de Transición, siga los pasos a continuación:

- Cree una instancia de la clase [Presentation ](https://reference.aspose.com/slides/net/aspose.slides/presentation).
- Obtenga la referencia de la diapositiva.
- Establezca el efecto de transición.
- Escriba la presentación como un archivo [PPTX ](https://docs.fileformat.com/presentation/pptx/).

En el ejemplo dado a continuación, hemos establecido los efectos de transición.

```c#
// Crear una instancia de la clase Presentation
Presentation presentation = new Presentation("AccessSlides.pptx");

// Establecer efecto
presentation.Slides[0].SlideShowTransition.Type = TransitionType.Cut;
((OptionalBlackTransition)presentation.Slides[0].SlideShowTransition.Value).FromBlack = true;

// Escribir la presentación en el disco
presentation.Save("SetTransitionEffects_out.pptx", SaveFormat.Pptx);
```