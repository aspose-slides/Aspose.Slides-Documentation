---
title: Personalizar gráficos circulares en presentaciones con C++
linktitle: Gráfico circular
type: docs
url: /es/cpp/pie-chart/
keywords:
- gráfico circular
- gestionar gráfico
- personalizar gráfico
- opciones de gráfico
- configuración de gráfico
- opciones de trazado
- color de sector
- PowerPoint
- presentación
- C++
- Aspose.Slides
description: "Aprenda a crear y personalizar gráficos circulares en C++ con Aspose.Slides, exportables a PowerPoint, impulsando su narrativa de datos en segundos."
---
## **Visión general**

Este artículo explica cómo trabajar con gráficos circulares en Aspose.Slides. Muestra cómo configurar opciones de trama secundaria para los gráficos Pie of Pie y Bar of Pie, y cómo habilitar la coloración automática de los sectores para un gráfico circular estándar.

Los ejemplos se centran en pasos prácticos de personalización de gráficos, como añadir un gráfico a una diapositiva, ajustar la configuración de series y etiquetas, reemplazar los datos predeterminados del gráfico por categorías y valores personalizados, y guardar la presentación actualizada.

## **Opciones de segunda trama para gráficos de Pie of Pie y Bar of Pie**
Aspose.Slides para C++ ahora admite opciones de segunda trama para gráficos de Pie of Pie o Bar of Pie. En este tema, veremos con un ejemplo cómo especificar estas opciones mediante Aspose.Slides. Para especificar las propiedades, siga los pasos a continuación:

1. Instanciar el objeto de la clase [Presentation](https://reference.aspose.com/slides/es/cpp/aspose.slides/presentation/) .
2. Añadir un gráfico a la diapositiva.
3. Especificar las opciones de segunda trama del gráfico.
4. Guardar la presentación en disco.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SecondPlotOptionsforCharts-SecondPlotOptionsforCharts.cpp" >}}

## **Establecer colores automáticos de sectores en gráficos circulares**
Aspose.Slides para C++ proporciona una API sencilla para establecer colores automáticos de sectores en gráficos circulares. El código de ejemplo aplica la configuración de las propiedades mencionadas.

1. Crear una instancia de la clase Presentation.
2. Acceder a la primera diapositiva.
3. Añadir un gráfico con datos predeterminados.
4. Establecer el título del gráfico.
5. Configurar la primera serie para Mostrar valores.
6. Establecer el índice de la hoja de datos del gráfico.
7. Obtener la hoja de cálculo de datos del gráfico.
8. Eliminar las series y categorías generadas por defecto.
9. Añadir nuevas categorías.
10. Añadir nuevas series.

Guardar la presentación modificada en un archivo PPTX.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SettingAutomicPieChartSliceColors-SettingAutomicPieChartSliceColors.cpp" >}}

## **FAQ**

**¿Se admiten las variantes 'Pie of Pie' y 'Bar of Pie'?**

Sí, la biblioteca [admite](https://reference.aspose.com/slides/es/cpp/aspose.slides.charts/charttype/) una trama secundaria para gráficos circulares, incluidas las variantes 'Pie of Pie' y 'Bar of Pie'.

**¿Puedo exportar solo el gráfico como una imagen (por ejemplo, PNG)?**

Sí, puede [exportar el propio gráfico como una imagen](https://reference.aspose.com/slides/es/cpp/aspose.slides/shape/getimage/) (por ejemplo PNG) sin toda la presentación.