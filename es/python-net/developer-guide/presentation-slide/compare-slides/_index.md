---
title: Comparar Diapositivas
type: docs
weight: 50
url: /python-net/compare-slides/
keywords: "Comparar diapositivas de PowerPoint, Comparar dos diapositivas, Presentación, Python, Aspose.Slides"
description: "Comparar diapositivas de presentaciones de PowerPoint en Python"
---

## **Comparar Dos Diapositivas**
El método Equals ha sido añadido a la interfaz [IBaseSlide](https://reference.aspose.com/slides/python-net/aspose.slides/ibaseslide/) y a la clase [BaseSlide](https://reference.aspose.com/slides/python-net/aspose.slides/baseslide/). Devuelve verdadero para las diapositivas/layout y las diapositivas/master que son idénticas en su estructura y contenido estático.

Dos diapositivas son iguales si todas las formas, estilos, textos, animaciones y otros ajustes, etc. La comparación no tiene en cuenta los valores de identificadores únicos, por ejemplo, SlideId y contenido dinámico, por ejemplo, el valor de la fecha actual en el marcador de posición de fecha.

```py
import aspose.slides as slides

with slides.Presentation(path + "AccessSlides.pptx") as p1:
    with slides.Presentation(path + "HelloWorld.pptx") as p2:
        for i in range(len(p1.masters)):
            for j in range(len(p2.masters)):
                if p1.masters[i] == p2.masters[j]:
                    print("La MasterSlide#{0} de Presentación1 es igual a la MasterSlide#{1} de Presentación2".format(i,j))
```