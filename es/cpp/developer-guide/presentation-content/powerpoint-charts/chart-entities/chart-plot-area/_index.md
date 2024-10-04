---
title: Área de Trazado del Gráfico
type: docs
url: /es/cpp/chart-plot-area/
---

## **Obtener Ancho, Alto del Área de Trazado del Gráfico**
Aspose.Slides para C++ proporciona una API simple para . 

1. Cree una instancia de la [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) clase.
1. Acceda a la primera diapositiva.
1. Agregue un gráfico con datos predeterminados.
1. Llame al método IChart::ValidateChartLayout() antes de obtener los valores actuales.
1. Obtiene la ubicación actual en X (izquierda) del elemento gráfico en relación con la esquina superior izquierda del gráfico.
1. Obtiene la parte superior actual del elemento gráfico en relación con la esquina superior izquierda del gráfico.
1. Obtiene el ancho actual del elemento gráfico.
1. Obtiene la altura actual del elemento gráfico.

``` cpp
auto pres = System::MakeObject<Presentation>(u"test.Pptx");
    
auto chart = System::ExplicitCast<Chart>(pres->get_Slides()->idx_get(0)->get_Shapes()->AddChart(ChartType::ClusteredColumn, 100.0f, 100.0f, 500.0f, 350.0f));
chart->ValidateChartLayout();

double x = chart->get_PlotArea()->get_ActualX();
double y = chart->get_PlotArea()->get_ActualY();
double w = chart->get_PlotArea()->get_ActualWidth();
double h = chart->get_PlotArea()->get_ActualHeight();

// Guardar presentación con gráfico
pres->Save(u"Chart_out.pptx", SaveFormat::Pptx);
```


## **Establecer Modo de Diseño del Área de Trazado del Gráfico**
Aspose.Slides para C++ proporciona una API simple para establecer el modo de diseño del área de trazado del gráfico. La propiedad **LayoutTargetType** se ha añadido a las clases **ChartPlotArea** y **IChartPlotArea**. Si el diseño del área de trazado se define manualmente, esta propiedad especifica si se deberá diseñar el área de trazado por su interior (sin incluir ejes y etiquetas de ejes) o por fuera (incluyendo ejes y etiquetas de ejes). Hay dos valores posibles que están definidos en el enum **LayoutTargetType**.

- **LayoutTargetType.Inner** - especifica que el tamaño del área de trazado determinará el tamaño del área de trazado, sin incluir las marcas de graduación y las etiquetas de los ejes.
- **LayoutTargetType.Outer** - especifica que el tamaño del área de trazado determinará el tamaño del área de trazado, las marcas de graduación y las etiquetas de los ejes.

El código de ejemplo se proporciona a continuación.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-SetLayoutMode-SetLayoutMode.cpp" >}}