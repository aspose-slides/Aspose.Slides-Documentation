---
title: Personalizar barras de error en gráficos de presentación usando Python
linktitle: Barra de error
type: docs
url: /es/python-java/error-bar/
keywords:
- barra de error
- valor personalizado
- PowerPoint
- presentación
- Python
- Java
- Aspose.Slides
description: "Aprende a añadir y personalizar barras de error en gráficos con Aspose.Slides para Python a través de Java—optimiza la visualización de datos en presentaciones de PowerPoint."
---
## **Descripción general**

Este artículo explica cómo trabajar con barras de error en gráficos de presentación mediante Aspose.Slides. Muestra cómo agregar barras de error a una serie de gráfico, configurar los ajustes de barra de error X e Y, y aplicar diferentes tipos de valores como fijo, porcentaje y valores personalizados.

También demuestra cómo asignar valores personalizados de barra de error para puntos de datos individuales en una serie utilizando la colección correspondiente de puntos de datos. Además, el artículo incluye notas breves sobre cómo se comportan las barras de error durante la exportación, su compatibilidad con marcadores y etiquetas de datos, y dónde encontrar las clases y enumeraciones relacionadas en la referencia de la API.

## **Añadir barras de error**

Aspose.Slides para Python a través de Java proporciona una API sencilla para gestionar los valores de las barras de error. El siguiente código de ejemplo utiliza tipos de valor fijo y porcentaje.

1. Crea una instancia de la clase [Presentación](https://reference.aspose.com/slides/es/python-java/aspose.slides/presentation/).
1. Añade un gráfico de burbujas a la diapositiva deseada.
1. Accede a la primera serie del gráfico y establece el formato X de la barra de error.
1. Accede a la primera serie del gráfico y establece el formato Y de la barra de error.
1. Establece los valores y el formato de la barra de error.
1. Guarda la presentación modificada en un archivo PPTX.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, DataSourceType, ErrorBarType, ErrorBarValueType, Presentation, SaveFormat

# Crear una instancia de la clase Presentation.
presentation = Presentation()
try:
    # Crear un gráfico de burbujas.
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Bubble, 50, 50, 400, 300, True)

    # Agregar barras de error y establecer su formato.
    series = chart.getChartData().getSeries().get_Item(0)
    error_bar_x = series.getErrorBarsXFormat()
    error_bar_y = series.getErrorBarsYFormat()

    error_bar_x.setVisible(True)
    error_bar_y.setVisible(True)
    error_bar_x.setValueType(ErrorBarValueType.Fixed)
    error_bar_x.setValue(0.1)
    error_bar_y.setValueType(ErrorBarValueType.Percentage)
    error_bar_y.setValue(5)
    error_bar_x.setType(ErrorBarType.Plus)
    error_bar_y.getFormat().getLine().setWidth(2.0)
    error_bar_x.setEndCap(True)

    # Guardar la presentación.
    presentation.save("ErrorBars.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Agregar valores personalizados de barra de error**

Aspose.Slides para Python a través de Java proporciona una API sencilla para gestionar valores personalizados de barra de error. El siguiente código de ejemplo se aplica cuando [getValueType](https://reference.aspose.com/slides/es/python-java/aspose.slides/errorbarsformat/#getValueType) devuelve [ErrorBarValueType.Custom](https://reference.aspose.com/slides/es/python-java/aspose.slides/errorbarvaluetype/#Custom). Para especificar un valor, utiliza [getErrorBarsCustomValues](https://reference.aspose.com/slides/es/python-java/aspose.slides/chartdatapoint/#getErrorBarsCustomValues) para un punto de datos específico en la colección devuelta por el método de serie [getDataPoints](https://reference.aspose.com/slides/es/python-java/aspose.slides/chartseries/#getDataPoints).

1. Crea una instancia de la clase [Presentación](https://reference.aspose.com/slides/es/python-java/aspose.slides/presentation/).
1. Añade un gráfico de burbujas a la diapositiva deseada.
1. Accede a la primera serie del gráfico y establece el formato X de la barra de error.
1. Accede a la primera serie del gráfico y establece el formato Y de la barra de error.
1. Accede a los puntos de datos individuales en la serie del gráfico y establece sus valores de barra de error.
1. Establece los valores y el formato de la barra de error.
1. Guarda la presentación modificada en un archivo PPTX.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, DataSourceType, ErrorBarType, ErrorBarValueType, Presentation, SaveFormat

    # Crear una instancia de la clase Presentation.
presentation = Presentation()
try:
    # Crear un gráfico de burbujas.
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Bubble, 50, 50, 400, 300, True)

    # Añadir barras de error personalizadas y establecer su formato.
    series = chart.getChartData().getSeries().get_Item(0)
    error_bar_x = series.getErrorBarsXFormat()
    error_bar_y = series.getErrorBarsYFormat()
    error_bar_x.setVisible(True)
    error_bar_y.setVisible(True)
    error_bar_x.setValueType(ErrorBarValueType.Custom)
    error_bar_y.setValueType(ErrorBarValueType.Custom)

    # Acceder a los puntos de datos de la serie del gráfico y configurar sus fuentes de valores de barras de error.
    points = series.getDataPoints()
    data_source = points.getDataSourceTypeForErrorBarsCustomValues()
    data_source.setDataSourceTypeForXPlusValues(jpype.JByte(DataSourceType.DoubleLiterals))
    data_source.setDataSourceTypeForXMinusValues(jpype.JByte(DataSourceType.DoubleLiterals))
    data_source.setDataSourceTypeForYPlusValues(jpype.JByte(DataSourceType.DoubleLiterals))
    data_source.setDataSourceTypeForYMinusValues(jpype.JByte(DataSourceType.DoubleLiterals))

    # Establecer los valores de las barras de error para los puntos de datos de la serie del gráfico.
    for i in range(points.size()):
        custom_values = points.get_Item(i).getErrorBarsCustomValues()
        custom_values.getXMinus().setAsLiteralDouble(i + 1)
        custom_values.getXPlus().setAsLiteralDouble(i + 1)
        custom_values.getYMinus().setAsLiteralDouble(i + 1)
        custom_values.getYPlus().setAsLiteralDouble(i + 1)

    # Guardar la presentación.
    presentation.save("ErrorBarsCustomValues.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Preguntas frecuentes**

**¿Qué ocurre con las barras de error al exportar una presentación a PDF o imágenes?**

Se renderizan como parte del gráfico y se conservan durante la conversión junto con el resto del formato del gráfico, siempre que se utilice una versión o motor compatible.

**¿Se pueden combinar las barras de error con marcadores y etiquetas de datos?**

Sí. Las barras de error son un elemento independiente y son compatibles con marcadores y etiquetas de datos; si los elementos se superponen, puede ser necesario ajustar el formato.

**¿Dónde puedo encontrar la lista de propiedades y clases para trabajar con barras de error en la API?**

En la referencia de la API: la clase [ErrorBarsFormat](https://reference.aspose.com/slides/es/python-java/aspose.slides/errorbarsformat/) y las clases relacionadas [ErrorBarType](https://reference.aspose.com/slides/es/python-java/aspose.slides/errorbartype/) y [ErrorBarValueType](https://reference.aspose.com/slides/es/python-java/aspose.slides/errorbarvaluetype/).