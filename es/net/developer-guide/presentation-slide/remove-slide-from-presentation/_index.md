---
title: Eliminar diapositiva de la presentación
type: docs
weight: 30
url: /es/net/remove-slide-from-presentation/
keywords: "Eliminar diapositiva, Borrar diapositiva, PowerPoint, Presentación, C#, Csharp, .NET, Aspose.Slides"
description: "Eliminar diapositiva de PowerPoint por referencia o índice en C# o .NET"

---

Si una diapositiva (o su contenido) se vuelve redundante, puedes eliminarla. Aspose.Slides proporciona la clase [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) que encapsula [ISlideCollection](https://reference.aspose.com/slides/net/aspose.slides/islidecollection), que es un repositorio para todas las diapositivas en una presentación. Usando punteros (referencia o índice) para un objeto [ISlide](https://reference.aspose.com/slides/net/aspose.slides/islide/) conocido, puedes especificar la diapositiva que deseas eliminar.

## **Eliminar diapositiva por referencia**

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
1. Obtén una referencia de la diapositiva que deseas eliminar a través de su ID o índice.
1. Elimina la diapositiva referenciada de la presentación.
1. Guarda la presentación modificada.

Este código C# te muestra cómo eliminar una diapositiva a través de su referencia:

```c#
// Instancia un objeto Presentation que representa un archivo de presentación
using (Presentation pres = new Presentation("RemoveSlideUsingReference.pptx"))
{

    // Accede a una diapositiva a través de su índice en la colección de diapositivas
    ISlide slide = pres.Slides[0];

    // Elimina una diapositiva a través de su referencia
    pres.Slides.Remove(slide);

    // Guarda la presentación modificada
    pres.Save("modified_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```

## **Eliminar diapositiva por índice**

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
1. Elimina la diapositiva de la presentación a través de su posición de índice.
1. Guarda la presentación modificada.

Este código C# te muestra cómo eliminar una diapositiva a través de su índice:

```c#
// Instancia un objeto Presentation que representa un archivo de presentación
using (Presentation pres = new Presentation("RemoveSlideUsingIndex.pptx"))
{

    // Elimina una diapositiva a través de su índice de diapositiva
    pres.Slides.RemoveAt(0);

    // Guarda la presentación modificada
    pres.Save("modified_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```

## **Eliminar diapositiva de diseño no utilizada**

Aspose.Slides proporciona el método [RemoveUnusedLayoutSlides](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/removeunusedlayoutslides/) (de la clase [Compress](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/)) para permitirte eliminar diapositivas de diseño no deseadas y no utilizadas. Este código C# te muestra cómo eliminar una diapositiva de diseño de una presentación de PowerPoint:

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    Aspose.Slides.LowCode.Compress.RemoveUnusedLayoutSlides(pres);
    
    pres.Save("pres-out.pptx", SaveFormat.Pptx);
}
```

## **Eliminar diapositiva maestra no utilizada**

Aspose.Slides proporciona el método [RemoveUnusedMasterSlides](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/removeunusedmasterslides/) (de la clase [Compress](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/)) para permitirte eliminar diapositivas maestras no deseadas y no utilizadas. Este código C# te muestra cómo eliminar una diapositiva maestra de una presentación de PowerPoint:

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    Aspose.Slides.LowCode.Compress.RemoveUnusedMasterSlides(pres);
    
    pres.Save("pres-out.pptx", SaveFormat.Pptx);
}
```