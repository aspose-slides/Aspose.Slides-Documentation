---
title: Personalizar barras de error en gráficos de presentación con Python
linktitle: Barra de error
type: docs
url: /es/python-net/error-bar/
keywords:
- barra de error
- valor personalizado
- PowerPoint
- OpenDocument
- presentación
- Python
- Aspose.Slides
description: "Aprenda a agregar y personalizar barras de error en gráficos con Aspose.Slides para Python mediante .NET: optimice visualizaciones de datos en presentaciones de PowerPoint y OpenDocument."
---

## **Agregar barra de error**
Aspose.Slides for Python via .NET proporciona una API simple para gestionar los valores de las barras de error. El código de ejemplo se aplica cuando se usa un tipo de valor personalizado. Para especificar un valor, utilice la propiedad **ErrorBarCustomValues** de un punto de datos específico en la colección **DataPoints** de la serie:

1. Crear una instancia de la [Presentación](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) clase.
1. Agregar un gráfico de burbujas en la diapositiva deseada.
1. Acceder a la primera serie del gráfico y establecer el formato de la barra de error X.
1. Acceder a la primera serie del gráfico y establecer el formato de la barra de error Y.
1. Establecer valores y formato de las barras.
1. Guardar la presentación modificada en un archivo PPTX.

```py
import aspose.slides.charts as charts
import aspose.slides as slides

# Creando presentación vacía
with slides.Presentation() as presentation:
    # Creando un gráfico de burbujas
    chart = presentation.slides[0].shapes.add_chart(charts.ChartType.BUBBLE, 50, 50, 400, 300, True)

    # Agregando barras de error y configurando su formato
    errBarX = chart.chart_data.series[0].error_bars_x_format
    errBarY = chart.chart_data.series[0].error_bars_y_format
    errBarX.is_visible = True
    errBarY.is_visible = True
    errBarX.value_type = charts.ErrorBarValueType.FIXED
    errBarX.value = 0.1
    errBarY.value_type = charts.ErrorBarValueType.PERCENTAGE
    errBarY.value = 5
    errBarX.type = charts.ErrorBarType.PLUS
    errBarY.format.line.width = 2
    errBarX.has_end_cap = True

    # Guardando la presentación
    presentation.save("ErrorBars_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Agregar valor de barra de error personalizado**
Aspose.Slides for Python via .NET proporciona una API simple para gestionar valores personalizados de barras de error. El código de ejemplo se aplica cuando la propiedad **IErrorBarsFormat.ValueType** es igual a **Custom**. Para especificar un valor, utilice la propiedad **ErrorBarCustomValues** de un punto de datos específico en la colección **DataPoints** de la serie:

1. Crear una instancia de la [Presentación](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) clase.
1. Agregar un gráfico de burbujas en la diapositiva deseada.
1. Acceder a la primera serie del gráfico y establecer el formato de la barra de error X.
1. Acceder a la primera serie del gráfico y establecer el formato de la barra de error Y.
1. Acceder a los puntos de datos individuales de la serie del gráfico y establecer los valores de la barra de error para cada punto.
1. Establecer valores y formato de las barras.
1. Guardar la presentación modificada en un archivo PPTX.

```py
import aspose.slides.charts as charts
import aspose.slides as slides

# Creando presentación vacía
with slides.Presentation() as presentation:
    # Creando un gráfico de burbujas
    chart = presentation.slides[0].shapes.add_chart(charts.ChartType.BUBBLE, 50, 50, 400, 300, True)

    # Agregando barras de error personalizadas y configurando su formato
    series = chart.chart_data.series[0]
    errBarX = series.error_bars_x_format
    errBarY = series.error_bars_y_format
    errBarX.is_visible = True
    errBarY.is_visible = True
    errBarX.value_type = charts.ErrorBarValueType.CUSTOM
    errBarY.value_type = charts.ErrorBarValueType.CUSTOM

    # Accediendo al punto de datos de la serie del gráfico y estableciendo valores de barras de error para cada punto
    points = series.data_points
    points.data_source_type_for_error_bars_custom_values.data_source_type_for_x_plus_values = charts.DataSourceType.DOUBLE_LITERALS
    points.data_source_type_for_error_bars_custom_values.data_source_type_for_x_minus_values = charts.DataSourceType.DOUBLE_LITERALS
    points.data_source_type_for_error_bars_custom_values.data_source_type_for_y_plus_values = charts.DataSourceType.DOUBLE_LITERALS
    points.data_source_type_for_error_bars_custom_values.data_source_type_for_y_minus_values = charts.DataSourceType.DOUBLE_LITERALS

    # Configurando barras de error para los puntos de la serie del gráfico
    for i in range(len(points)):
        points[i].error_bars_custom_values.x_minus.as_literal_double = i + 1
        points[i].error_bars_custom_values.x_plus.as_literal_double = i + 1
        points[i].error_bars_custom_values.y_minus.as_literal_double = i + 1
        points[i].error_bars_custom_values.y_plus.as_literal_double = i + 1

    # Guardando la presentación
    presentation.save("ErrorBarsCustomValues_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Preguntas frecuentes**

**¿Qué ocurre con las barras de error al exportar una presentación a PDF o imágenes?**

Se renderizan como parte del gráfico y se conservan durante la conversión junto con el resto del formato del gráfico, siempre que se use una versión o renderizador compatible.

**¿Pueden combinarse las barras de error con marcadores y etiquetas de datos?**

Sí. Las barras de error son un elemento separado y son compatibles con marcadores y etiquetas de datos; si los elementos se superponen, es posible que sea necesario ajustar el formato.

**¿Dónde puedo encontrar la lista de propiedades y enumeraciones para trabajar con barras de error en la API?**

En la referencia de la API: la clase [ErrorBarsFormat](https://reference.aspose.com/slides/python-net/aspose.slides.charts/errorbarsformat/) y los enums relacionados [ErrorBarType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/errorbartype/) y [ErrorBarValueType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/errorbarvaluetype/).