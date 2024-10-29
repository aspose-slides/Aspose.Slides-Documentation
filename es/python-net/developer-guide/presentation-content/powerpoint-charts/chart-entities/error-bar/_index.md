---
title: Barra de Error
type: docs
url: /es/python-net/error-bar/
keywords: "Barra de error, valores de barra de error presentación de PowerPoint, Python, Aspose.Slides para Python a través de .NET"
description: "Agregar barra de error a presentaciones de PowerPoint en Python"
---

## **Agregar Barra de Error**
Aspose.Slides para Python a través de .NET proporciona una API simple para gestionar valores de barra de error. El código de muestra se aplica al usar un tipo de valor personalizado. Para especificar un valor, utiliza la propiedad **ErrorBarCustomValues** de un punto de datos específico en la colección **DataPoints** de la serie:

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. Agrega un gráfico de burbujas en la diapositiva deseada.
1. Accede a la primera serie del gráfico y establece el formato de barra de error X.
1. Accede a la primera serie del gráfico y establece el formato de barra de error Y.
1. Establecer los valores y el formato de las barras.
1. Escribe la presentación modificada en un archivo PPTX.

```py
import aspose.slides.charts as charts
import aspose.slides as slides

# Creando presentación vacía
with slides.Presentation() as presentation:
    # Creando un gráfico de burbujas
    chart = presentation.slides[0].shapes.add_chart(charts.ChartType.BUBBLE, 50, 50, 400, 300, True)

    # Agregando barras de error y estableciendo su formato
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

    # Guardando presentación
    presentation.save("ErrorBars_out.pptx", slides.export.SaveFormat.PPTX)
```



## **Agregar Valor de Barra de Error Personalizado**
Aspose.Slides para Python a través de .NET proporciona una API simple para gestionar valores de barra de error personalizados. El código de muestra se aplica cuando la propiedad **IErrorBarsFormat.ValueType** es igual a **Custom**. Para especificar un valor, utiliza la propiedad **ErrorBarCustomValues** de un punto de datos específico en la colección **DataPoints** de la serie:

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. Agrega un gráfico de burbujas en la diapositiva deseada.
1. Accede a la primera serie del gráfico y establece el formato de barra de error X.
1. Accede a la primera serie del gráfico y establece el formato de barra de error Y.
1. Accede a los puntos de datos individuales de la serie del gráfico y establece los valores de la barra de error para el punto de datos de la serie individual.
1. Establecer los valores y el formato de las barras.
1. Escribe la presentación modificada en un archivo PPTX.

```py
import aspose.slides.charts as charts
import aspose.slides as slides

# Creando presentación vacía
with slides.Presentation() as presentation:
    # Creando un gráfico de burbujas
    chart = presentation.slides[0].shapes.add_chart(charts.ChartType.BUBBLE, 50, 50, 400, 300, True)

    # Agregando barras de error personalizadas y estableciendo su formato
    series = chart.chart_data.series[0]
    errBarX = series.error_bars_x_format
    errBarY = series.error_bars_y_format
    errBarX.is_visible = True
    errBarY.is_visible = True
    errBarX.value_type = charts.ErrorBarValueType.CUSTOM
    errBarY.value_type = charts.ErrorBarValueType.CUSTOM

    # Accediendo a los puntos de datos de la serie del gráfico y estableciendo valores de barras de error para el punto individual
    points = series.data_points
    points.data_source_type_for_error_bars_custom_values.data_source_type_for_x_plus_values = charts.DataSourceType.DOUBLE_LITERALS
    points.data_source_type_for_error_bars_custom_values.data_source_type_for_x_minus_values = charts.DataSourceType.DOUBLE_LITERALS
    points.data_source_type_for_error_bars_custom_values.data_source_type_for_y_plus_values = charts.DataSourceType.DOUBLE_LITERALS
    points.data_source_type_for_error_bars_custom_values.data_source_type_for_y_minus_values = charts.DataSourceType.DOUBLE_LITERALS

    # Estableciendo barras de error para los puntos de la serie del gráfico
    for i in range(len(points)):
        points[i].error_bars_custom_values.x_minus.as_literal_double = i + 1
        points[i].error_bars_custom_values.x_plus.as_literal_double = i + 1
        points[i].error_bars_custom_values.y_minus.as_literal_double = i + 1
        points[i].error_bars_custom_values.y_plus.as_literal_double = i + 1

    # Guardando presentación
    presentation.save("ErrorBarsCustomValues_out.pptx", slides.export.SaveFormat.PPTX)
```