---
title: Personalizar gráficos de burbujas en presentaciones usando С++
linktitle: Gráfico de burbujas
type: docs
url: /es/cpp/bubble-chart/
keywords:
- gráfico de burbujas
- tamaño de burbuja
- escalado de tamaño
- representación de tamaño
- PowerPoint
- presentación
- С++
- Aspose.Slides
description: "Crea y personaliza potentes gráficos de burbujas en PowerPoint con Aspose.Slides para С++ para mejorar tu visualización de datos fácilmente."
---

## **Escalado del Tamaño del Gráfico de Burbujas**
Aspose.Slides for **C++** proporciona soporte para el escalado del tamaño de los gráficos de burbujas. En Aspose.Slides for **C++** se han añadido las propiedades **IChartSeries.BubbleSizeScale** y **IChartSeriesGroup.BubbleSizeScale**. A continuación se muestra un ejemplo.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SettingBubbleChartScaling-SettingBubbleChartScaling.cpp" >}}

## **Representar datos como tamaños de gráfico de burbujas**
Se ha añadido el nuevo método **get_BubbleSizeRepresentation()** a las clases **IChartSeries** y **ChartSeries**. **BubbleSizeRepresentation** especifica cómo se representan los valores de tamaño de burbuja en el gráfico de burbujas. Los valores posibles son: **BubbleSizeRepresentationType.Area** y **BubbleSizeRepresentationType.Width**. En consecuencia, se ha añadido el enumerado **BubbleSizeRepresentationType** para especificar las posibles formas de representar datos como tamaños de gráfico de burbujas. A continuación se muestra el código de ejemplo.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-SupportOfBubbleSizeRepresentation-SupportOfBubbleSizeRepresentation.cpp" >}}

## **Preguntas frecuentes**

**¿Se admite un "gráfico de burbujas con efecto 3-D" y en qué se diferencia de uno normal?**

Sí. Existe un tipo de gráfico separado, "Bubble with 3-D". Aplica estilo 3‑D a las burbujas pero no añade un eje adicional; los datos siguen siendo X‑Y‑S (tamaño). El tipo está disponible en la [tipo de gráfico](https://reference.aspose.com/slides/cpp/aspose.slides.charts/charttype/) enumeración.

**¿Hay un límite en la cantidad de series y puntos en un gráfico de burbujas?**

No hay un límite estricto a nivel de API; las limitaciones dependen del rendimiento y de la versión de PowerPoint de destino. Se recomienda mantener un número razonable de puntos para garantizar la legibilidad y la velocidad de renderizado.

**¿Cómo afectará la exportación a la apariencia de un gráfico de burbujas (PDF, imágenes)?**

La exportación a formatos compatibles preserva la apariencia del gráfico; el renderizado lo realiza el motor de Aspose.Slides. Para formatos raster/vector, se aplican las reglas generales de renderizado de gráficos (resolución, anti‑aliasing), por lo que se debe elegir un DPI suficiente para la impresión.