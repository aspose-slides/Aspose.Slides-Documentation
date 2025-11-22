---
title: Comparar diapositivas
type: docs
weight: 50
url: /es/net/compare-slides/
keywords: "Comparar diapositivas de PowerPoint, Comparar dos diapositivas, Presentación, C#, Csharp, .NET, Aspose.Slides"
description: "Comparar diapositivas de presentaciones PowerPoint en C# o .NET"
---

## **Comparar dos diapositivas**
Se ha añadido el método Equals a la interfaz [IBaseSlide](https://reference.aspose.com/slides/net/aspose.slides/ibaseslide) y a la clase [BaseSlide](https://reference.aspose.com/slides/net/aspose.slides/baseslide). Devuelve true para las diapositivas/layout y diapositivas/maestras que son idénticas por su estructura y contenido estático.

Dos diapositivas son iguales si todas las formas, estilos, textos, animaciones y demás configuraciones, etc. La comparación no tiene en cuenta los valores de identificadores únicos, por ejemplo SlideId, ni el contenido dinámico, por ejemplo el valor de la fecha actual en el marcador de posición de fecha.
```c#
using (Presentation presentation1 = new Presentation("AccessSlides.pptx"))
using (Presentation presentation2 = new Presentation("HelloWorld.pptx"))
{
    for (int i = 0; i < presentation1.Masters.Count; i++)
    {
        for (int j = 0; j < presentation2.Masters.Count; j++)
        {
            if (presentation1.Masters[i].Equals(presentation2.Masters[j]))
                Console.WriteLine(string.Format("SomePresentation1 MasterSlide#{0} is equal to SomePresentation2 MasterSlide#{1}", i, j));
        }
    }
}
```


## **Preguntas frecuentes**

**¿El hecho de que una diapositiva esté oculta afecta la comparación de las propias diapositivas?**

[Hidden status](https://reference.aspose.com/slides/net/aspose.slides/slide/hidden/) es una propiedad a nivel de presentación/reproducción, no de contenido visual. La igualdad de dos diapositivas específicas se determina por su estructura y contenido estático; el simple hecho de que una diapositiva esté oculta no hace que las diapositivas sean diferentes.

**¿Se tienen en cuenta los hipervínculos y sus parámetros?**

Sí. Los enlaces forman parte del contenido estático de una diapositiva. Si la URL o la acción del hipervínculo difieren, esto suele considerarse una diferencia en el contenido estático.

**Si un gráfico hace referencia a un archivo Excel externo, ¿se tendrá en cuenta el contenido de ese archivo?**

No. La comparación se realiza basándose en las propias diapositivas. Las fuentes de datos externas generalmente no se leen en el momento de la comparación; solo se considera lo que está presente en la estructura y el estado estático de la diapositiva.