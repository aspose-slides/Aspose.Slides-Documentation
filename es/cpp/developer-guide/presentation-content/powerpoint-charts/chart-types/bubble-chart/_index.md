---
title: Personalizar gráficos de burbujas en presentaciones usando C++
linktitle: Gráfico de burbuja
type: docs
url: /es/cpp/bubble-chart/
keywords:
- gráfico de burbujas
- tamaño de burbuja
- escalado de tamaño
- representación de tamaño
- PowerPoint
- presentación
- C++
- Aspose.Slides
description: "Crea y personaliza potentes gráficos de burbujas en PowerPoint con Aspose.Slides para C++ y mejora tu visualización de datos fácilmente."
---
## **Visión general**

Este artículo muestra cómo trabajar con gráficos de burbujas en Aspose.Slides. Cubre dos opciones de personalización específicas: escalar el tamaño de las burbujas mediante el método `set_BubbleSizeScale` y controlar cómo se representan los valores de tamaño de las burbujas mediante el método `set_BubbleSizeRepresentation`.

Los ejemplos demuestran cómo crear un gráfico de burbujas, ajustar el escalado del tamaño y cambiar la representación del tamaño de la burbuja para que use el ancho. El artículo también incluye una breve sección de Preguntas frecuentes que aclara el soporte del tipo de gráfico “Bubble with 3‑D”, indica que los límites prácticos del gráfico dependen del rendimiento y de la versión de PowerPoint de destino, y explica que la exportación conserva la apariencia del gráfico mediante el motor de renderizado de Aspose.Slides.

## **Escalado del tamaño del gráfico de burbujas**
Aspose.Slides para C++ ofrece soporte para el escalado del tamaño de los gráficos de burbujas. En Aspose.Slides para **C++ IChartSeries.BubbleSizeScale** y **IChartSeriesGroup.BubbleSizeScale** se han añadido propiedades. A continuación se muestra un ejemplo de muestra. 

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SettingBubbleChartScaling-SettingBubbleChartScaling.cpp" >}}

## **Representar datos como tamaños de gráfico de burbujas**
Se ha añadido un nuevo método **get_BubbleSizeRepresentation()** a las clases **IChartSeries** y **ChartSeries**. **BubbleSizeRepresentation** especifica cómo se representan los valores de tamaño de la burbuja en el gráfico de burbujas. Los valores posibles son: **BubbleSizeRepresentationType.Area** y **BubbleSizeRepresentationType.Width**. En consecuencia, se ha añadido el enum **BubbleSizeRepresentationType** para especificar las formas posibles de representar los datos como tamaños de gráfico de burbujas. A continuación se muestra el código de ejemplo.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-SupportOfBubbleSizeRepresentation-SupportOfBubbleSizeRepresentation.cpp" >}}

## **Preguntas frecuentes**

**¿Se admite un "gráfico de burbujas con efecto 3‑D" y en qué se diferencia de uno normal?**

Sí. Existe un tipo de gráfico separado, "Bubble with 3‑D". Aplica un estilo 3‑D a las burbujas pero no añade un eje adicional; los datos siguen siendo X‑Y‑S (tamaño). El tipo está disponible en la enumeración [tipo de gráfico](https://reference.aspose.com/slides/es/cpp/aspose.slides.charts/charttype/).

**¿Existe un límite en el número de series y puntos en un gráfico de burbujas?**

No hay un límite estricto a nivel de API; las restricciones dependen del rendimiento y de la versión de PowerPoint de destino. Se recomienda mantener un número razonable de puntos para garantizar la legibilidad y la velocidad de renderizado.

**¿Cómo afecta la exportación a la apariencia de un gráfico de burbujas (PDF, imágenes)?**

La exportación a los formatos compatibles conserva la apariencia del gráfico; el renderizado lo realiza el motor de Aspose.Slides. Para formatos raster/vector, se aplican las reglas generales de renderizado de gráficos (resolución, antialiasing), por lo que debe elegirse un DPI suficiente para la impresión.