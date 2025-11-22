---
title: Acceder a diapositiva en la presentación
type: docs
weight: 20
url: /es/net/access-slide-in-presentation/
keywords: "Acceder a presentación de PowerPoint, Acceder a diapositiva, Editar propiedades de diapositiva, Cambiar posición de diapositiva, Establecer número de diapositiva, índice, ID, posición, C#, Csharp, .NET, Aspose.Slides"
description: "Acceder a diapositiva de PowerPoint por índice, ID o posición en C# o .NET. Editar propiedades de diapositiva"
---

Aspose.Slides permite acceder a las diapositivas de dos maneras: por índice y por ID.

## **Acceder a la diapositiva por índice**

Todas las diapositivas de una presentación se organizan numéricamente según la posición de la diapositiva comenzando desde 0. La primera diapositiva es accesible mediante el índice 0; la segunda diapositiva se accede mediante el índice 1; etc.

La clase Presentation, que representa un archivo de presentación, expone todas las diapositivas como una colección [ISlideCollection](https://reference.aspose.com/slides/net/aspose.slides/islidecollection) (colección de objetos [ISlide](https://reference.aspose.com/slides/net/aspose.slides/islide/)). Este código C# le muestra cómo acceder a una diapositiva mediante su índice:
```c#
// Instancia un objeto Presentation que representa un archivo de presentación
Presentation presentation = new Presentation("AccessSlides.pptx");

// Obtiene la referencia de una diapositiva mediante su índice
ISlide slide = presentation.Slides[0];
```


## **Acceder a la diapositiva por ID**

Cada diapositiva de una presentación tiene un ID único asociado. Puede utilizar el método [GetSlideById](https://reference.aspose.com/slides/net/aspose.slides/presentation/methods/getslidebyid) (expuesto por la clase [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)) para apuntar a ese ID. Este código C# le muestra cómo proporcionar un ID de diapositiva válido y acceder a esa diapositiva mediante el método [GetSlideById](https://reference.aspose.com/slides/net/aspose.slides/presentation/methods/getslidebyid):
```c#
// Instancia un objeto Presentation que representa un archivo de presentación
Presentation presentation = new Presentation("AccessSlides.pptx");

// Obtiene el ID de una diapositiva
uint id = presentation.Slides[0].SlideId;

// Accede a la diapositiva mediante su ID
IBaseSlide slide = presentation.GetSlideById(id);
```


## **Cambiar la posición de la diapositiva**
Aspose.Slides le permite cambiar la posición de una diapositiva. Por ejemplo, puede especificar que la primera diapositiva debe convertirse en la segunda diapositiva.

1.  Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
1.  Obtenga la referencia de la diapositiva (cuya posición desea cambiar) mediante su índice
1.  Establezca una nueva posición para la diapositiva mediante la propiedad [SlideNumber](https://reference.aspose.com/slides/net/aspose.slides/islide/slidenumber/). 
1.  Guarde la presentación modificada.

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


La primera diapositiva se convirtió en la segunda; la segunda diapositiva se convirtió en la primera. Cuando cambia la posición de una diapositiva, las demás diapositivas se ajustan automáticamente.

## **Establecer el número de diapositiva**
Usando la propiedad [FirstSlideNumber](https://reference.aspose.com/slides/net/aspose.slides/presentation/firstslidenumber/) (expuesta por la clase [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)), puede especificar un nuevo número para la primera diapositiva de una presentación. Esta operación hace que los demás números de diapositiva se recalculen.

1.  Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
1.  Obtenga el número de diapositiva.
1.  Establezca el número de diapositiva.
1.  Guarde la presentación modificada.

Este código C# demuestra una operación donde el número de la primera diapositiva se establece en 10:
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


Si prefiere omitir la primera diapositiva, puede iniciar la numeración a partir de la segunda diapositiva (y ocultar la numeración de la primera diapositiva) de esta manera:
```c#
using (var presentation = new Presentation())
{
    var layoutSlide = presentation.LayoutSlides.GetByType(SlideLayoutType.Blank);
    presentation.Slides.AddEmptySlide(layoutSlide);
    presentation.Slides.AddEmptySlide(layoutSlide);
    presentation.Slides.AddEmptySlide(layoutSlide);

    // Establece el número para la primera diapositiva de la presentación
    presentation.FirstSlideNumber = 0;

    // Muestra los números de diapositiva para todas las diapositivas
    presentation.HeaderFooterManager.SetAllSlideNumbersVisibility(true);

    // Oculta el número de diapositiva de la primera diapositiva
    presentation.Slides[0].HeaderFooterManager.SetSlideNumberVisibility(false);

    // Guarda la presentación modificada
    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```


## **Preguntas frecuentes**

**¿El número de diapositiva que ve el usuario coincide con el índice basado en cero de la colección?**

El número que se muestra en una diapositiva puede comenzar desde un valor arbitrario (p. ej., 10) y no tiene que coincidir con el índice; la relación está controlada por la configuración del [primer número de diapositiva](https://reference.aspose.com/slides/net/aspose.slides/presentation/firstslidenumber/) de la presentación.

**¿Las diapositivas ocultas afectan al indexado?**

Sí. Una diapositiva oculta permanece en la colección y se cuenta en el indexado; "oculta" se refiere a la visualización, no a su posición en la colección.

**¿Cambia el índice de una diapositiva cuando se añaden o eliminan otras diapositivas?**

Sí. Los índices siempre reflejan el orden actual de las diapositivas y se recalculan al insertar, eliminar o mover diapositivas.