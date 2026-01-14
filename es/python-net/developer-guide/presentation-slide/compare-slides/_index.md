---
title: Comparar diapositivas de presentación en Python
linktitle: Comparar diapositivas
type: docs
weight: 50
url: /es/python-net/compare-slides/
keywords:
- comparar diapositivas
- comparación de diapositivas
- PowerPoint
- OpenDocument
- presentación
- Python
- Aspose.Slides
description: "Compare presentaciones de PowerPoint y OpenDocument programáticamente con Aspose.Slides para Python a través de .NET. Identifique rápidamente las diferencias de diapositivas en el código."
---

## **Comparar dos diapositivas**
El método `equals` se ha añadido a la clase [BaseSlide](https://reference.aspose.com/slides/python-net/aspose.slides/baseslide/). Devuelve true para las diapositivas/plantilla y diapositivas maestras que son idénticas por su estructura y contenido estático.

Dos diapositivas son iguales si todas las formas, estilos, textos, animaciones y otras configuraciones, etc. La comparación no tiene en cuenta los valores de identificadores únicos, por ejemplo SlideId, ni el contenido dinámico, por ejemplo el valor de fecha actual en el Marcador de posición de fecha.
```py
import aspose.slides as slides

with slides.Presentation(path + "AccessSlides.pptx") as p1:
    with slides.Presentation(path + "HelloWorld.pptx") as p2:
        for i in range(len(p1.masters)):
            for j in range(len(p2.masters)):
                if p1.masters[i] == p2.masters[j]:
                    print("Presentation1 MasterSlide#{0} is equal to Presentation2 MasterSlide#{1}".format(i,j))
```


## **Preguntas frecuentes**

**¿El hecho de que una diapositiva esté oculta afecta a la comparación de las propias diapositivas?**

El [estado oculto](https://reference.aspose.com/slides/python-net/aspose.slides/slide/hidden/) es una propiedad a nivel de presentación/reproducción, no de contenido visual. La igualdad de dos diapositivas específicas se determina por su estructura y contenido estático; el simple hecho de que una diapositiva esté oculta no hace que las diapositivas sean diferentes.

**¿Se tienen en cuenta los hipervínculos y sus parámetros?**

Sí. Los enlaces forman parte del contenido estático de una diapositiva. Si la URL o la acción del hipervínculo difieren, normalmente se considera una diferencia en el contenido estático.

**Si un gráfico hace referencia a un archivo de Excel externo, ¿se tendrán en cuenta los contenidos de ese archivo?**

No. La comparación se realiza sobre la base de las propias diapositivas. Las fuentes de datos externas generalmente no se leen en el momento de la comparación; solo se considera lo que está presente en la estructura y el estado estático de la diapositiva.