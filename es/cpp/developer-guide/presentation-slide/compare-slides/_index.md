---
title: Comparar diapositivas de presentación en C++
linktitle: Comparar diapositivas
type: docs
weight: 50
url: /es/cpp/compare-slides/
keywords:
- comparar diapositivas
- comparación de diapositivas
- PowerPoint
- OpenDocument
- presentación
- C++
- Aspose.Slides
description: "Compare presentaciones de PowerPoint y OpenDocument de forma programática con Aspose.Slides para C++. Identifique rápidamente las diferencias de diapositivas en el código."
---

## **Comparar dos diapositivas**
El método Equals se ha añadido a la interfaz IBaseSlide y a la clase BaseSlide. Devuelve true para las diapositivas / diapositivas de diseño / diapositivas maestras que son idénticas por su estructura y contenido estático.

Dos diapositivas son iguales si todas las formas, estilos, textos, animaciones y otras configuraciones, etc., coinciden. La comparación no tiene en cuenta los valores de identificadores únicos, por ejemplo SlideId, ni el contenido dinámico, por ejemplo el valor de fecha actual en el marcador de posición de fecha.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CheckSlidesComparison-CheckSlidesComparison.cpp" >}}

## **Preguntas frecuentes**

**¿El hecho de que una diapositiva esté oculta afecta la comparación de las propias diapositivas?**

[Hidden status](https://reference.aspose.com/slides/cpp/aspose.slides/slide/get_hidden/) es una propiedad a nivel de presentación/reproducción, no de contenido visual. La igualdad de dos diapositivas específicas se determina por su estructura y contenido estático; el simple hecho de que una diapositiva esté oculta no hace que las diapositivas sean diferentes.

**¿Se tienen en cuenta los hipervínculos y sus parámetros?**

Sí. Los enlaces forman parte del contenido estático de una diapositiva. Si la URL o la acción del hipervínculo difieren, normalmente se considera una diferencia en el contenido estático.

**Si un gráfico hace referencia a un archivo externo de Excel, ¿se tendrá en cuenta el contenido de ese archivo?**

No. La comparación se realiza basándose en las propias diapositivas. Las fuentes de datos externas generalmente no se leen en el momento de la comparación; solo se considera lo que está presente en la estructura y el estado estático de la diapositiva.