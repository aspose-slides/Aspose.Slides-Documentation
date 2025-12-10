---
title: Animar gráficos de PowerPoint en C++
linktitle: Gráficos animados
type: docs
weight: 80
url: /es/cpp/animated-charts/
keywords:
- gráfico
- gráfico animado
- animación de gráfico
- series de gráficos
- categoría de gráfico
- elemento de serie
- elemento de categoría
- agregar efecto
- tipo de efecto
- PowerPoint
- presentación
- C++
- Aspose.Slides
description: "Crea gráficos animados impresionantes en C++ con Aspose.Slides. Mejora tus presentaciones con visuales dinámicos en archivos PPT y PPTX—comienza ahora."
---

## **Animación de series de gráfico**
Si desea animar una serie de gráfico, escriba el código según los pasos enumerados a continuación:

1. Cargue una presentación.
1. Obtenga una referencia del objeto de gráfico.
1. Anime la serie.
1. Escriba el archivo de presentación en el disco.

En el ejemplo a continuación, animamos series de gráfico.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AnimatingSeries-AnimatingSeries.cpp" >}}

## **Animación en un elemento de serie**
Si desea animar elementos de series, escriba el código según los pasos enumerados a continuación:

1. Cargue una presentación.
1. Obtenga una referencia del objeto de gráfico.
1. Anime los elementos de la serie.
1. Escriba el archivo de presentación en el disco.

En el ejemplo a continuación, hemos animado los elementos de las series.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AnimatingSeriesElements-AnimatingSeriesElements.cpp" >}}

## **Animación de categoría de gráfico**
Si desea animar una categoría de gráfico, escriba el código según los pasos enumerados a continuación:

1. Cargue una presentación.
1. Obtenga una referencia del objeto de gráfico.
1. Anime la categoría.
1. Escriba el archivo de presentación en el disco.

En el ejemplo a continuación, animamos la categoría de gráfico.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AnimatingSeries-AnimatingSeries.cpp" >}}

## **Animación en un elemento de categoría**
Si desea animar elementos de categorías, escriba el código según los pasos enumerados a continuación:

1. Cargue una presentación.
1. Obtenga una referencia del objeto de gráfico.
1. Anime los elementos de las categorías.
1. Escriba el archivo de presentación en el disco.

En el ejemplo a continuación, hemos animado los elementos de categorías.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AnimatingCategoriesElements-AnimatingCategoriesElements.cpp" >}}

## **Preguntas frecuentes**

**¿Se admiten diferentes tipos de efectos (p. ej., entrada, énfasis, salida) para los gráficos como para las formas normales?**  
Sí. Un gráfico se trata como una forma, por lo que admite los tipos estándar de efectos de animación, incluidos entrada, énfasis y salida, con control total a través de la línea de tiempo de la diapositiva y las secuencias de animación.

**¿Puedo combinar la animación de gráficos con transiciones de diapositivas?**  
Sí. [Transitions](/slides/es/cpp/slide-transition/) se aplican a la diapositiva, mientras que los efectos de animación se aplican a los objetos de la diapositiva. Puede usar ambos juntos en la misma presentación y controlarlos de forma independiente.

**¿Se conservan las animaciones de los gráficos al guardar en PPTX?**  
Sí. Cuando [save to PPTX](/slides/es/cpp/save-presentation/), todos los efectos de animación y su orden se conservan porque forman parte del modelo de animación nativo de la presentación.

**¿Puedo leer las animaciones de gráficos existentes de una presentación y modificarlas?**  
Sí. La [API](https://reference.aspose.com/slides/cpp/aspose.slides.animation/) brinda acceso a la línea de tiempo de la diapositiva, secuencias y efectos, lo que le permite inspeccionar las animaciones de gráficos existentes y ajustarlas sin recrear todo desde cero.

**¿Puedo generar un video que incluya animaciones de gráficos usando Aspose.Slides?**  
Sí. Puede [export a presentation to video](/slides/es/cpp/convert-powerpoint-to-video/) conservando las animaciones, configurando los tiempos y otras opciones de exportación para que el clip resultante refleje la reproducción animada.