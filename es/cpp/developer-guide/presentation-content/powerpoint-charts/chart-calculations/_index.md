---
title: Cálculos de Gráficos
type: docs
weight: 50
url: /es/cpp/chart-calculations/
---

## **Calcular Valores Reales de Elementos del Gráfico**
Aspose.Slides para C++ proporciona una API sencilla para obtener estas propiedades. Esto te ayudará a calcular los valores reales de los elementos del gráfico. Los valores reales incluyen la posición de los elementos que implementan la interfaz IActualLayout (IActualLayout::get_ActualX(), IActualLayout::get_ActualY(), IActualLayout::get_ActualWidth(), IActualLayout::get_ActualHeight()) y los valores reales de los ejes (IAxis::get_ActualMaxValue(), IAxis::get_ActualMinValue(), IAxis::get_ActualMajorUnit(), IAxis::get_ActualMinorUnit(), IAxis::get_ActualMajorUnitScale(), IAxis::get_ActualMinorUnitScale()).

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


## **Calcular Posición Real de Elementos de Gráfico Padre**
Aspose.Slides para C++ proporciona una API sencilla para obtener estas propiedades. Los métodos de IActualLayout proporcionan información sobre la posición real del elemento de gráfico padre. Es necesario llamar al método IChart::ValidateChartLayout() previamente para llenar las propiedades con valores reales.

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

## **Ocultar Información del Gráfico**
Este tema te ayuda a entender cómo ocultar información del gráfico. Usando Aspose.Slides para C++ puedes ocultar **Título, Eje Vertical, Eje Horizontal** y **Líneas de Cuadrícula** del gráfico. El siguiente ejemplo de código muestra cómo utilizar estas propiedades.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-HideInformationFromChart-HideInformationFromChart.cpp" >}}

## **Establecer Rango de Datos para el Gráfico**
Aspose.Slides para C++ ha proporcionado la API más sencilla para establecer el rango de datos para el gráfico de la manera más fácil. Para establecer el rango de datos para el gráfico:

- Abre una instancia de la clase Presentation que contenga el gráfico.
- Obtén la referencia de una diapositiva utilizando su índice.
- Recorre todas las formas para encontrar el gráfico deseado.
- Accede a los datos del gráfico y establece el rango.
- Guarda la presentación modificada como un archivo PPTX.

Los ejemplos de código que siguen muestran cómo actualizar un gráfico.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SetDataRange-SetDataRange.cpp" >}}