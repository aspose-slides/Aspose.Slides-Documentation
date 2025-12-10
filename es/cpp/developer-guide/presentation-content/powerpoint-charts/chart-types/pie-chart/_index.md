---
title: Personalizar gráficos de pastel en presentaciones usando C++
linktitle: Gráfico de pastel
type: docs
url: /es/cpp/pie-chart/
keywords:
- gráfico de pastel
- gestionar gráfico
- personalizar gráfico
- opciones de gráfico
- configuración de gráfico
- opciones de trama
- color de segmento
- PowerPoint
- presentación
- C++
- Aspose.Slides
description: "Aprenda a crear y personalizar gráficos de pastel en C++ con Aspose.Slides, exportables a PowerPoint, impulsando su narración de datos en segundos."
---

## **Opciones de segunda trama para gráficos Pie of Pie y Bar of Pie**
Aspose.Slides para C++ ahora admite opciones de segunda trama para los gráficos Pie of Pie o Bar of Pie. En este tema, veremos con un ejemplo cómo especificar estas opciones usando Aspose.Slides. Para especificar las propiedades, siga los pasos a continuación:

1. Instanciar el objeto de la clase [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).
1. Añadir un gráfico a la diapositiva.
1. Especificar las opciones de segunda trama del gráfico.
1. Guardar la presentación en disco.

En el ejemplo que se muestra a continuación, hemos configurado diferentes propiedades del gráfico Pie of Pie.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SecondPlotOptionsforCharts-SecondPlotOptionsforCharts.cpp" >}}



## **Establecer colores automáticos de segmentos de gráficos de pastel**
Aspose.Slides para C++ proporciona una API sencilla para establecer colores automáticos de segmentos de gráficos de pastel. El código de ejemplo aplica la configuración de las propiedades mencionadas.

1. Crear una instancia de la clase Presentation.
1. Acceder a la primera diapositiva.
1. Añadir un gráfico con datos predeterminados.
1. Establecer el título del gráfico.
1. Configurar la primera serie para Mostrar valores.
1. Establecer el índice de la hoja de datos del gráfico.
1. Obtener la hoja de datos del gráfico.
1. Eliminar las series y categorías generadas por defecto.
1. Añadir nuevas categorías.
1. Añadir nuevas series.

Guardar la presentación modificada en un archivo PPTX.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SettingAutomicPieChartSliceColors-SettingAutomicPieChartSliceColors.cpp" >}}

## **FAQ**

**¿Se admiten las variantes 'Pie of Pie' y 'Bar of Pie'?**

Sí, la biblioteca [admite](https://reference.aspose.com/slides/cpp/aspose.slides.charts/charttype/) una trama secundaria para gráficos de pastel, incluidas los tipos 'Pie of Pie' y 'Bar of Pie'.

**¿Puedo exportar solo el gráfico como una imagen (por ejemplo, PNG)?**

Sí, puede [exportar el gráfico como imagen](https://reference.aspose.com/slides/cpp/aspose.slides/shape/getimage/) (como PNG) sin toda la presentación.