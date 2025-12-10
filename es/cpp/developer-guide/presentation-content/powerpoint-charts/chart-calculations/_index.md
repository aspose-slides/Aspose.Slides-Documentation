---
title: Optimizar cálculos de gráficos para presentaciones en C++
linktitle: Cálculos de gráficos
type: docs
weight: 50
url: /es/cpp/chart-calculations/
keywords:
- cálculos de gráficos
- elementos de gráfico
- posición del elemento
- posición real
- elemento hijo
- elemento padre
- valores de gráfico
- valor real
- PowerPoint
- presentación
- C++
- Aspose.Slides
description: "Entienda los cálculos de gráficos, las actualizaciones de datos y el control de precisión en Aspose.Slides para C++ para PPT y PPTX, con ejemplos prácticos de código C++."
---

## **Calcular valores reales de los elementos del gráfico**
Aspose.Slides for C++ proporciona una API simple para obtener estas propiedades. Esto le ayudará a calcular los valores reales de los elementos del gráfico. Los valores reales incluyen la posición de los elementos que implementan la interfaz IActualLayout (IActualLayout::get_ActualX(), IActualLayout::get_ActualY(), IActualLayout::get_ActualWidth(), IActualLayout::get_ActualHeight()) y los valores reales de los ejes (IAxis::get_ActualMaxValue(), IAxis::get_ActualMinValue(), IAxis::get_ActualMajorUnit(), IAxis::get_ActualMinorUnit(), IAxis::get_ActualMajorUnitScale(), IAxis::get_ActualMinorUnitScale()).
``` cpp
auto pres = System::MakeObject<Presentation>(u"test.pptx");
    
auto chart = System::ExplicitCast<Chart>(pres->get_Slides()->idx_get(0)->get_Shapes()->AddChart(ChartType::ClusteredColumn, 100.0f, 100.0f, 500.0f, 350.0f));
chart->ValidateChartLayout();

double x = chart->get_PlotArea()->get_ActualX();
double y = chart->get_PlotArea()->get_ActualY();
double w = chart->get_PlotArea()->get_ActualWidth();
double h = chart->get_PlotArea()->get_ActualHeight();

// Guardando la presentación
pres->Save(u"Result.pptx", SaveFormat::Pptx);
```


## **Calcular la posición real de los elementos de gráfico padre**
Aspose.Slides for C++ proporciona una API simple para obtener estas propiedades. Los métodos de IActualLayout proporcionan información sobre la posición real del elemento de gráfico padre. Es necesario llamar al método IChart::ValidateChartLayout() previamente para rellenar las propiedades con los valores reales.
``` cpp
// Creando presentación vacía
auto pres = System::MakeObject<Presentation>();

auto chart = System::ExplicitCast<Chart>(pres->get_Slides()->idx_get(0)->get_Shapes()->AddChart(ChartType::ClusteredColumn, 100.0f, 100.0f, 500.0f, 350.0f));
chart->ValidateChartLayout();

double x = chart->get_PlotArea()->get_ActualX();
double y = chart->get_PlotArea()->get_ActualY();
double w = chart->get_PlotArea()->get_ActualWidth();
double h = chart->get_PlotArea()->get_ActualHeight();
```


## **Ocultar elementos del gráfico**
Este tema le ayuda a entender cómo ocultar información del gráfico. Con Aspose.Slides for C++ puede ocultar **Título, Eje vertical, Eje horizontal** y **Líneas de cuadrícula** del gráfico. El siguiente ejemplo de código muestra cómo usar estas propiedades.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-HideInformationFromChart-HideInformationFromChart.cpp" >}}

## **Establecer un rango de datos para un gráfico**
Aspose.Slides for C++ ha proporcionado la API más simple para establecer el rango de datos de un gráfico de la manera más fácil. Para establecer el rango de datos del gráfico:

- Abra una instancia de la clase Presentation que contenga el gráfico.
- Obtenga la referencia de una diapositiva mediante su índice.
- Recorra todas las formas para encontrar el gráfico deseado.
- Acceda a los datos del gráfico y establezca el rango.
- Guarde la presentación modificada como un archivo PPTX.

Los ejemplos de código que siguen muestran cómo actualizar un gráfico.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SetDataRange-SetDataRange.cpp" >}}

## **FAQ**

**¿Los libros de Excel externos funcionan como fuente de datos y cómo afecta eso a la recalculación?**

Sí. Un gráfico puede hacer referencia a un libro externo: cuando conecta o actualiza la fuente externa, las fórmulas y valores se toman de ese libro, y el gráfico refleja las actualizaciones durante las operaciones de apertura/edición. La API le permite [especificar el libro externo](https://reference.aspose.com/slides/cpp/aspose.slides.charts/chartdata/setexternalworkbook/) ruta y gestionar los datos vinculados.

**¿Puedo calcular y mostrar líneas de tendencia sin implementar la regresión yo mismo?**

Sí. Las [líneas de tendencia](/slides/es/cpp/trend-line/) (lineales, exponenciales y otras) son añadidas y actualizadas por Aspose.Slides; sus parámetros se recalculan automáticamente a partir de los datos de la serie, por lo que no necesita implementar sus propios cálculos.

**Si una presentación tiene varios gráficos con enlaces externos, ¿puedo controlar qué libro usa cada gráfico para los valores calculados?**

Sí. Cada gráfico puede apuntar a su propio [libro externo](https://reference.aspose.com/slides/cpp/aspose.slides.charts/chartdata/setexternalworkbook/), o puede crear/reemplazar un libro externo por gráfico de forma independiente de los demás.