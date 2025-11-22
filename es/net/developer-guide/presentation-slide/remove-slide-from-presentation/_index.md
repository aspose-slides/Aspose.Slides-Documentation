---
title: Eliminar diapositiva de la presentación
type: docs
weight: 30
url: /es/net/remove-slide-from-presentation/
keywords: "Eliminar diapositiva, Borrar diapositiva, PowerPoint, Presentación, C#, Csharp, .NET, Aspose.Slides"
description: "Eliminar diapositiva de PowerPoint por referencia o índice en C# o .NET"
---

Si una diapositiva (o su contenido) se vuelve redundante, puede eliminarla. Aspose.Slides proporciona la clase [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) que encapsula [ISlideCollection](https://reference.aspose.com/slides/net/aspose.slides/islidecollection), que es un repositorio de todas las diapositivas de una presentación. Usando punteros (referencia o índice) para un objeto [ISlide](https://reference.aspose.com/slides/net/aspose.slides/islide/) conocido, puede especificar la diapositiva que desea eliminar. 

## **Eliminar diapositiva por referencia**

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) .
1. Obtenga una referencia de la diapositiva que desea eliminar mediante su ID o índice.
1. Elimine la diapositiva referenciada de la presentación.
1. Guarde la presentación modificada. 

Este código C# le muestra cómo eliminar una diapositiva mediante su referencia:
```c#
// Instancia un objeto Presentation que representa un archivo de presentación
using (Presentation pres = new Presentation("RemoveSlideUsingReference.pptx"))
{

    // Accede a una diapositiva mediante su índice en la colección de diapositivas
    ISlide slide = pres.Slides[0];

    // Elimina una diapositiva mediante su referencia
    pres.Slides.Remove(slide);

    // Guarda la presentación modificada
    pres.Save("modified_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```


## **Eliminar diapositiva por índice**

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) .
1. Elimine la diapositiva de la presentación mediante su posición de índice.
1. Guarde la presentación modificada. 

Este código C# le muestra cómo eliminar una diapositiva mediante su índice:
```c#
// Instancia un objeto Presentation que representa un archivo de presentación
using (Presentation pres = new Presentation("RemoveSlideUsingIndex.pptx"))
{

    // Elimina una diapositiva mediante su índice
    pres.Slides.RemoveAt(0);

    // Guarda la presentación modificada
    pres.Save("modified_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```


## **Eliminar diapositiva de diseño no utilizada**

Aspose.Slides proporciona el método [RemoveUnusedLayoutSlides](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/removeunusedlayoutslides/) (de la clase [Compress](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/)) para permitirle eliminar diapositivas de diseño no deseadas y no utilizadas. Este código C# le muestra cómo eliminar una diapositiva de diseño de una presentación PowerPoint:
```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    Aspose.Slides.LowCode.Compress.RemoveUnusedLayoutSlides(pres);
    
    pres.Save("pres-out.pptx", SaveFormat.Pptx);
}
```


## **Eliminar diapositiva maestra no utilizada**

Aspose.Slides proporciona el método [RemoveUnusedMasterSlides](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/removeunusedmasterslides/) (de la clase [Compress](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/)) para permitirle eliminar diapositivas maestras no deseadas y no utilizadas. Este código C# le muestra cómo eliminar una diapositiva maestra de una presentación PowerPoint:
```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    Aspose.Slides.LowCode.Compress.RemoveUnusedMasterSlides(pres);
    
    pres.Save("pres-out.pptx", SaveFormat.Pptx);
}
```


## **Preguntas frecuentes**

**¿Qué ocurre con los índices de diapositivas después de eliminar una diapositiva?**

Después de la eliminación, la [colección](https://reference.aspose.com/slides/net/aspose.slides/slidecollection/) se vuelve a indexar: cada diapositiva posterior se desplaza una posición a la izquierda, por lo que los números de índice anteriores quedan desactualizados. Si necesita una referencia estable, utilice el ID persistente de cada diapositiva en lugar de su índice.

**¿El ID de una diapositiva es diferente de su índice, y cambia cuando se eliminan diapositivas vecinas?**

Sí. El índice es la posición de la diapositiva y cambiará cuando se añadan o eliminen diapositivas. El ID de la diapositiva es un identificador persistente y no cambia cuando se eliminan otras diapositivas.

**¿Cómo afecta la eliminación de una diapositiva a las secciones de diapositivas?**

Si la diapositiva pertenecía a una sección, esa sección simplemente contendrá una diapositiva menos. La estructura de la sección se mantiene; si una sección queda vacía, puede [eliminar o reorganizar secciones](/slides/es/net/slide-section/) según sea necesario.

**¿Qué ocurre con las notas y los comentarios adjuntos a una diapositiva cuando se elimina?**

[Notes](/slides/es/net/presentation-notes/) y [comments](/slides/es/net/presentation-comments/) están vinculados a esa diapositiva específica y se eliminan junto con ella. El contenido de otras diapositivas no se ve afectado.

**¿En qué se diferencia la eliminación de diapositivas de la limpieza de diseños/maestros no usados?**

Eliminar quita diapositivas normales específicas del conjunto. La limpieza de diseños/maestros no usados elimina diapositivas de diseño o maestras que no son referenciadas por nada, reduciendo el tamaño del archivo sin cambiar el contenido de las diapositivas restantes. Estas acciones son complementarias: normalmente se elimina primero y luego se limpia.