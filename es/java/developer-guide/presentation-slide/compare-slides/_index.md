---
title: Comparar diapositivas de presentación en Java
linktitle: Comparar diapositivas
type: docs
weight: 50
url: /es/java/compare-slides/
keywords:
- comparar diapositivas
- comparación de diapositivas
- PowerPoint
- OpenDocument
- presentación
- Java
- Aspose.Slides
description: "Compare presentaciones PowerPoint y OpenDocument de forma programática con Aspose.Slides para Java. Identifique rápidamente las diferencias de diapositivas en el código."
---

## **Comparar dos diapositivas**
Se ha añadido el método Equals a la interfaz [IBaseSlide](https://reference.aspose.com/slides/java/com.aspose.slides/IBaseSlide) y a la clase [BaseSlide](https://reference.aspose.com/slides/java/com.aspose.slides/BaseSlide). Devuelve true para las diapositivas/layout y las diapositivas maestras que son idénticas por su estructura y contenido estático.

Dos diapositivas son iguales si todas las formas, estilos, textos, animaciones y demás configuraciones, etc., son iguales. La comparación no tiene en cuenta los valores de identificadores únicos, p. ej. SlideId, ni el contenido dinámico, p. ej. el valor de fecha actual en el marcador de posición de fecha.
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
                    System.out.println(String.format("SomePresentation1 MasterSlide#%d is equal to SomePresentation2 MasterSlide#%d", i, j));
            }
        }
    } finally {
        presentation2.dispose();
    }
} finally {
    presentation1.dispose();
}
```


## **Preguntas frecuentes**

**¿El hecho de que una diapositiva esté oculta afecta la comparación de las propias diapositivas?**

[Estado oculto](https://reference.aspose.com/slides/java/com.aspose.slides/slide/#getHidden--) es una propiedad a nivel de presentación/reproducción, no de contenido visual. La igualdad de dos diapositivas específicas se determina por su estructura y contenido estático; el simple hecho de que una diapositiva esté oculta no hace que las diapositivas sean diferentes.

**¿Se tienen en cuenta los hipervínculos y sus parámetros?**

Sí. Los enlaces forman parte del contenido estático de una diapositiva. Si la URL o la acción del hipervínculo difiere, esto normalmente se trata como una diferencia en el contenido estático.

**Si un gráfico hace referencia a un archivo Excel externo, ¿se tendrá en cuenta el contenido de ese archivo?**

No. La comparación se realiza basándose en las propias diapositivas. Las fuentes de datos externas generalmente no se leen en el momento de la comparación; solo se considera lo que está presente en la estructura y el estado estático de la diapositiva.