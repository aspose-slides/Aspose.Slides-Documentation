---
title: Comparar Diapositivas
type: docs
weight: 50
url: /java/compare-slides/
---

## **Comparar Dos Diapositivas**
El método Equals ha sido agregado a la interfaz [IBaseSlide](https://reference.aspose.com/slides/java/com.aspose.slides/IBaseSlide) y a la clase [BaseSlide](https://reference.aspose.com/slides/java/com.aspose.slides/BaseSlide). Devuelve verdadero para las diapositivas/layout y diapositivas/master que son idénticas en su estructura y contenido estático.

Dos diapositivas son iguales si todas las formas, estilos, textos, animaciones y otros ajustes, etc. son iguales. La comparación no toma en cuenta los valores de identificador único, por ejemplo, SlideId y contenido dinámico, por ejemplo, el valor de la fecha actual en el Marcador de Fecha.

```java
Presentation presentation1 = new Presentation("AccessSlides.pptx");
try {
    Presentation presentation2 = new Presentation("HelloWorld.pptx");
    try {
        for (int i = 0; i < presentation1.getMasters().size(); i++)
        {
            for (int j = 0; j < presentation2.getMasters().size(); j++)
            {
                if (presentation1.getMasters().get_Item(i).equals(presentation2.getMasters().get_Item(j)))
                    System.out.println(String.format("La Diapositiva Maestra#%d de SomePresentation1 es igual a la Diapositiva Maestra#%d de SomePresentation2", i, j));
            }
        }
    } finally {
        presentation2.dispose();
    }
} finally {
    presentation1.dispose();
}
```