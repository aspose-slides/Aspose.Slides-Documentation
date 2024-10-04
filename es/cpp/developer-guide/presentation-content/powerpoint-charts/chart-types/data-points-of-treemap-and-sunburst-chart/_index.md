---
title: Puntos de Datos de Gráfico de Treemap y Sunburst
type: docs
url: /cpp/data-points-of-treemap-and-sunburst-chart/
keywords: "Gráfico Sunburst"
description: "Gráfico Sunburst, Diagrama Sunburst, Gráfico Sunburst, Gráfico Radial o Gráfico Circular de Múltiples Niveles con Aspose.Slides."
---

Entre otros tipos de gráficos de PowerPoint, hay dos tipos "jerárquicos" - **Treemap** y **Sunburst** (también conocido como Gráfico Sunburst, Diagrama Sunburst, Gráfico Radial o Gráfico Circular de Múltiples Niveles). Estos gráficos muestran datos jerárquicos organizados como un árbol - desde las hojas hasta la parte superior de la rama. Las hojas están definidas por los puntos de datos de la serie, y cada nivel de agrupación anidada subsiguiente está definido por la categoría correspondiente. Aspose.Slides para C++ permite formatear los puntos de datos del Gráfico Sunburst y Treemap en C++.

Aquí hay un Gráfico Sunburst, donde los datos en la columna Series1 definen los nodos hoja, mientras que otras columnas definen los puntos de datos jerárquicos:

![todo:image_alt_text](https://lh6.googleusercontent.com/TSSU5O7SLOi5NZD9JaubhgGU1QU5tYKc23RQX_cal3tlz5TpOvsgUFLV_rHvruwN06ft1XYgsLhbeEDXzVqdAybPIbpfGy-lwoQf_ydxDwcjAeZHWfw61c4koXezAAlEeCA7x6BZ)

Comencemos añadiendo un nuevo gráfico Sunburst a la presentación:



``` cpp
auto pres = System::MakeObject<Presentation>();
auto chart = pres->get_Slides()->idx_get(0)->get_Shapes()->AddChart(ChartType::Sunburst, 100.0f, 100.0f, 450.0f, 400.0f);
// ...
```

{{% alert color="primary" title="Ver también" %}} 
- [**Crear Gráfico Sunburst**](/slides/cpp/create-chart/#create-sunburst-chart)
{{% /alert %}}


Si hay necesidad de formatear los puntos de datos del gráfico, debemos usar lo siguiente:

[**IChartDataPointLevelsManager**](https://reference.aspose.com/slides/cpp/class/aspose.slides.charts.i_chart_data_point_levels_manager), 
[**IChartDataPointLevel**](https://reference.aspose.com/slides/cpp/class/aspose.slides.charts.i_chart_data_point_level) clases 
y [**IChartDataPoint::get_DataPointLevels()**](https://reference.aspose.com/slides/cpp/class/aspose.slides.charts.i_chart_data_point#ac619638c85f84a6127a7ce62523e0931) método 
proporcionan acceso para formatear los puntos de datos de los gráficos Treemap y Sunburst. 
[**IChartDataPointLevelsManager**](https://reference.aspose.com/slides/cpp/class/aspose.slides.charts.i_chart_data_point_levels_manager) 
se utiliza para acceder a categorías multinivel - representa el contenedor de 
[**IChartDataPointLevel**](https://reference.aspose.com/slides/cpp/class/aspose.slides.charts.i_chart_data_point_level) objetos. 
Básicamente es un envoltorio para 
[**IChartCategoryLevelsManager**](https://reference.aspose.com/slides/cpp/class/aspose.slides.charts.i_chart_category_levels_manager) con 
las propiedades específicas añadidas para los puntos de datos. 
La clase [**IChartDataPointLevel**](https://reference.aspose.com/slides/cpp/class/aspose.slides.charts.i_chart_data_point_level) tiene 
dos métodos: [**get_Format()**](https://reference.aspose.com/slides/cpp/class/aspose.slides.charts.i_chart_data_point_level#a00caa6a048ad98a66ab56a5ddb196697) y 
[**get_Label()** ](https://reference.aspose.com/slides/cpp/class/aspose.slides.charts.i_chart_data_point_level#a5ab377b372199eb561792e9ba18acf25)que 
proporcionan acceso a los ajustes correspondientes.
## **Mostrar Valor del Punto de Datos**
Mostrar valor del punto de datos "Hoja 4":



``` cpp
auto dataPoints = chart->get_ChartData()->get_Series()->idx_get(0)->get_DataPoints();
dataPoints->idx_get(3)->get_DataPointLevels()->idx_get(0)->get_Label()->get_DataLabelFormat()->set_ShowValue(true);
```

![todo:image_alt_text](https://lh6.googleusercontent.com/bKHMf5Bj37ZkMwUE1OfXjw7_CRmDhafhQOUuVWDmitwbtdkwD68ibWluY6Q1HQz_z2Q-BR_SBrBPZ_gID5bGH0PUqI5w37S22RT-ZZal6k7qIDstKntYi5QXS8z-SgpnsI78WGiu)
## **Establecer Etiqueta y Color del Punto de Datos**
Establecer la etiqueta de datos de "Rama 1" para mostrar el nombre de la serie ("Series1") en lugar del nombre de la categoría. Luego establecer el color del texto a amarillo:



``` cpp
auto branch1Label = dataPoints->idx_get(0)->get_DataPointLevels()->idx_get(2)->get_Label();
branch1Label->get_DataLabelFormat()->set_ShowCategoryName(false);
branch1Label->get_DataLabelFormat()->set_ShowSeriesName(true);

branch1Label->get_DataLabelFormat()->get_TextFormat()->get_PortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
branch1Label->get_DataLabelFormat()->get_TextFormat()->get_PortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Yellow());
```

![todo:image_alt_text](https://lh6.googleusercontent.com/I9g0kewJnxkhUVlfSWRN39Ng-wzjWyRwF3yTbOD9HhLTLBt_sMJiEfDe7vOfqRNx89o9AVZsYTW3Vv_TIuj4EgM4_UEEi7zQ3jdvaO8FoG2JcsOqNRgbiE5HQZNz8xx_q9qdj8JQ)
## **Establecer Color de Rama del Punto de Datos**

Cambiar el color de la rama "Tallo 4":

``` cpp
auto pres = System::MakeObject<Presentation>();
auto chart = pres->get_Slides()->idx_get(0)->get_Shapes()->AddChart(ChartType::Sunburst, 100.0f, 100.0f, 450.0f, 400.0f);
auto dataPoints = chart->get_ChartData()->get_Series()->idx_get(0)->get_DataPoints();

auto stem4branch = dataPoints->idx_get(9)->get_DataPointLevels()->idx_get(1);
stem4branch->get_Format()->get_Fill()->set_FillType(FillType::Solid);
stem4branch->get_Format()->get_Fill()->get_SolidFillColor()->set_Color(Color::get_Red());

pres->Save(u"pres.pptx", SaveFormat::Pptx);
```

![todo:image_alt_text](https://lh5.googleusercontent.com/Zll4cpQ5tTDdgwmJ4yuupolfGaANR8SWWTU3XaJav_ZVXVstV1pI1z1OFH-gov6FxPoDz1cxmMyrgjsdYGS24PlhaYa2daKzlNuL1a0xYcqEiyyO23AE6JMOLavWpvqA6SzOCA6_)
