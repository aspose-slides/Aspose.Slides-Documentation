---
title: Comparar Diapositivas
type: docs
weight: 50
url: /es/cpp/compare-slides/
---

## **Comparar Dos Diapositivas**
El método Equals ha sido añadido a la interfaz IBaseSlide y a la clase BaseSlide. Devuelve verdadero para las diapositivas / diapositivas de diseño / diapositivas maestras que son idénticas en su estructura y contenido estático.

Dos diapositivas son iguales si todas las formas, estilos, textos, animaciones y otras configuraciones, etc. La comparación no toma en cuenta los valores de identificadores únicos, por ejemplo, SlideId y contenido dinámico, por ejemplo, el valor de la fecha actual en el marcador de posición de fecha.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CheckSlidesComparison-CheckSlidesComparison.cpp" >}}