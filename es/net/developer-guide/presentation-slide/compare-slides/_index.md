---
title: Comparar Diapositivas
type: docs
weight: 50
url: /es/net/compare-slides/
keywords: "Comparar diapositivas de PowerPoint, Comparar dos diapositivas, Presentación, C#, Csharp, .NET, Aspose.Slides"
description: "Comparar diapositivas de presentaciones de PowerPoint en C# o .NET"
---

## **Comparar Dos Diapositivas**
Se ha añadido el método Equals a la interfaz [IBaseSlide](https://reference.aspose.com/slides/net/aspose.slides/ibaseslide) y a la clase [BaseSlide](https://reference.aspose.com/slides/net/aspose.slides/baseslide). Devuelve verdadero para las diapositivas/layout y diapositivas/master que son idénticas en su estructura y contenido estático.

Dos diapositivas son iguales si todos los shapes, estilos, textos, animaciones y otros ajustes, etc. La comparación no tiene en cuenta los valores de identificadores únicos, p. ej. SlideId y contenido dinámico, p. ej. valor de la fecha actual en el marcador de posición de fecha.

```c#
using (Presentation presentation1 = new Presentation("AccessSlides.pptx"))
using (Presentation presentation2 = new Presentation("HelloWorld.pptx"))
{
    for (int i = 0; i < presentation1.Masters.Count; i++)
    {
        for (int j = 0; j < presentation2.Masters.Count; j++)
        {
            if (presentation1.Masters[i].Equals(presentation2.Masters[j]))
                Console.WriteLine(string.Format("SomePresentation1 MasterSlide#{0} es igual a SomePresentation2 MasterSlide#{1}", i, j));
        }
    }
}
```