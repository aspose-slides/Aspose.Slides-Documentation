---
title: Acceder a la Diapositiva en la Presentación
type: docs
weight: 20
url: /net/access-slide-in-presentation/
keywords: "Acceder a la presentación de PowerPoint, Acceder a la diapositiva, Editar propiedades de la diapositiva, Cambiar posición de la diapositiva, Establecer número de diapositiva, índice, ID, posición C#, Csharp, .NET, Aspose.Slides"
description: "Acceder a la diapositiva de PowerPoint por índice, ID o posición en C# o .NET. Editar propiedades de la diapositiva"
---

Aspose.Slides te permite acceder a las diapositivas de dos maneras: por índice y por ID.

## **Acceder a la Diapositiva por Índice**

Todas las diapositivas en una presentación están organizadas numéricamente en función de la posición de la diapositiva comenzando desde 0. La primera diapositiva es accesible a través del índice 0; la segunda diapositiva se accede a través del índice 1; etc.

La clase Presentation, que representa un archivo de presentación, expone todas las diapositivas como una colección de [ISlideCollection](https://reference.aspose.com/slides/net/aspose.slides/islidecollection) (colección de objetos [ISlide](https://reference.aspose.com/slides/net/aspose.slides/islide/)). Este código C# te muestra cómo acceder a una diapositiva a través de su índice:

```c#
// Instancia un objeto Presentation que representa un archivo de presentación
Presentation presentation = new Presentation("AccessSlides.pptx");

// Obtiene la referencia de una diapositiva a través de su índice
ISlide slide = presentation.Slides[0];
```

## **Acceder a la Diapositiva por ID**

Cada diapositiva en una presentación tiene un ID único asociado a ella. Puedes usar el método [GetSlideById](https://reference.aspose.com/slides/net/aspose.slides/presentation/methods/getslidebyid) (expuesto por la clase [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)) para dirigirte a ese ID. Este código C# te muestra cómo proporcionar un ID de diapositiva válido y acceder a esa diapositiva a través del método [GetSlideById](https://reference.aspose.com/slides/net/aspose.slides/presentation/methods/getslidebyid):

```c#
// Instancia un objeto Presentation que representa un archivo de presentación
Presentation presentation = new Presentation("AccessSlides.pptx");

// Obtiene un ID de diapositiva
uint id = presentation.Slides[0].SlideId;

// Accede a la diapositiva a través de su ID
IBaseSlide slide = presentation.GetSlideById(id);
```

## **Cambiar la Posición de la Diapositiva**
Aspose.Slides te permite cambiar la posición de una diapositiva. Por ejemplo, puedes especificar que la primera diapositiva debería convertirse en la segunda diapositiva.

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
1. Obtén la referencia de la diapositiva (cuyo posición deseas cambiar) a través de su índice.
1. Establece una nueva posición para la diapositiva a través de la propiedad [SlideNumber](https://reference.aspose.com/slides/net/aspose.slides/islide/slidenumber/).
1. Guarda la presentación modificada.

Este código C# demuestra una operación en la que la diapositiva en la posición 1 se mueve a la posición 2:

```c#
// Instancia un objeto Presentation que representa un archivo de presentación
using (Presentation pres = new Presentation("ChangePosition.pptx"))
{
    // Obtiene la diapositiva cuya posición será cambiada
    ISlide sld = pres.Slides[0];

    // Establece la nueva posición para la diapositiva
    sld.SlideNumber = 2;

    // Guarda la presentación modificada
    pres.Save("Aspose_out.pptx", SaveFormat.Pptx);
}
```

La primera diapositiva se convirtió en la segunda; la segunda diapositiva se convirtió en la primera. Cuando cambias la posición de una diapositiva, otras diapositivas se ajustan automáticamente.


## **Establecer el Número de la Diapositiva**
Usando la propiedad [FirstSlideNumber](https://reference.aspose.com/slides/net/aspose.slides/presentation/firstslidenumber/) (expuesta por la clase [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)), puedes especificar un nuevo número para la primera diapositiva en una presentación. Esta operación provoca que se recalculen otros números de diapositiva.

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
1. Obtén el número de la diapositiva.
1. Establece el número de la diapositiva.
1. Guarda la presentación modificada.

Este código C# demuestra una operación en la que el número de la primera diapositiva se establece en 10:

```c#
// Instancia un objeto Presentation que representa un archivo de presentación
using (Presentation presentation = new Presentation("HelloWorld.pptx"))
{
    // Obtiene el número de la diapositiva
    int firstSlideNumber = presentation.FirstSlideNumber;

    // Establece el número de la diapositiva
    presentation.FirstSlideNumber=10;
    
    // Guarda la presentación modificada
    presentation.Save("Set_Slide_Number_out.pptx", SaveFormat.Pptx);
}
```

Si prefieres omitir la primera diapositiva, puedes comenzar la numeración desde la segunda diapositiva (y ocultar la numeración para la primera diapositiva) de esta manera:

```c#
using (var presentation = new Presentation())
{
    var layoutSlide = presentation.LayoutSlides.GetByType(SlideLayoutType.Blank);
    presentation.Slides.AddEmptySlide(layoutSlide);
    presentation.Slides.AddEmptySlide(layoutSlide);
    presentation.Slides.AddEmptySlide(layoutSlide);

    // Establece el número para la primera diapositiva de la presentación
    presentation.FirstSlideNumber = 0;

    // Muestra los números de diaposa para todas las diapositivas
    presentation.HeaderFooterManager.SetAllSlideNumbersVisibility(true);

    // Oculta el número de la diapositiva para la primera diapositiva
    presentation.Slides[0].HeaderFooterManager.SetSlideNumberVisibility(false);

    // Guarda la presentación modificada
    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```