---
title: Personalizar puntos de datos en gráficos de Treemap y Sunburst usando C++
linktitle: Puntos de datos en gráficos de Treemap y Sunburst
type: docs
url: /es/cpp/data-points-of-treemap-and-sunburst-chart/
keywords:
- gráfico treemap
- gráfico sunburst
- punto de datos
- color de etiqueta
- color de rama
- PowerPoint
- presentación
- C++
- Aspose.Slides
description: "Aprenda a administrar puntos de datos en gráficos de treemap y sunburst con Aspose.Slides para C++, compatible con los formatos de PowerPoint."
---


Entre otros tipos de gráficos de PowerPoint, existen dos tipos “jerárquicos”: el gráfico **Treemap** y el gráfico **Sunburst** (también conocido como Gráfico Sunburst, Diagrama Sunburst, Gráfico radial, Gráfico radial o Gráfico de pastel multinivel). Estos gráficos muestran datos jerárquicos organizados como un árbol, desde las hojas hasta la parte superior de la rama. Las hojas se definen por los puntos de datos de la serie, y cada nivel de agrupación anidado posterior se define por la categoría correspondiente. Aspose.Slides for C++ permite formatear los puntos de datos del gráfico Sunburst y del Treemap en C++.

Este es un gráfico Sunburst, donde los datos en la columna Series1 definen los nodos hoja, mientras que las demás columnas definen los puntos de datos jerárquicos:

![todo:image_alt_text](https://lh6.googleusercontent.com/TSSU5O7SLOi5NZD9JaubhgGU1QU5tYKc23RQX_cal3tlz5TpOvsgUFLV_rHvruwN06ft1XYgsLhbeEDXzVqdAybPIbpfGy-lwoQf_ydxDwcjAeZHWfw61c4koXezAAlEeCA7x6BZ)

Comencemos añadiendo un nuevo gráfico Sunburst a la presentación:
``` cpp
auto pres = System::MakeObject<Presentation>();
auto chart = pres->get_Slides()->idx_get(0)->get_Shapes()->AddChart(ChartType::Sunburst, 100.0f, 100.0f, 450.0f, 400.0f);
// ...
```


{{% alert color="primary" title="Ver también" %}} 
- [**Crear gráfico Sunburst**](/slides/es/cpp/create-chart/#create-sunburst-chart)
{{% /alert %}}

Si es necesario formatear los puntos de datos del gráfico, debemos usar lo siguiente:

[**IChartDataPointLevelsManager**](https://reference.aspose.com/slides/cpp/class/aspose.slides.charts.i_chart_data_point_levels_manager), 
[IChartDataPointLevel](https://reference.aspose.com/slides/cpp/class/aspose.slides.charts.i_chart_data_point_level) clases 
y [**IChartDataPoint::get_DataPointLevels()**](https://reference.aspose.com/slides/cpp/class/aspose.slides.charts.i_chart_data_point#ac619638c85f84a6127a7ce62523e0931) método 
proporcionan acceso para formatear los puntos de datos de los gráficos Treemap y Sunburst. 
[**IChartDataPointLevelsManager**](https://reference.aspose.com/slides/cpp/class/aspose.slides.charts.i_chart_data_point_levels_manager) 
se usa para acceder a categorías de varios niveles; representa el contenedor de 
[**IChartDataPointLevel**](https://reference.aspose.com/slides/cpp/class/aspose.slides.charts.i_chart_data_point_level) objetos. 
Básicamente es un contenedor para 
[**IChartCategoryLevelsManager**](https://reference.aspose.com/slides/cpp/class/aspose.slides.charts.i_chart_category_levels_manager) con 
las propiedades añadidas específicas para los puntos de datos. 
[**IChartDataPointLevel**](https://reference.aspose.com/slides/cpp/class/aspose.slides.charts.i_chart_data_point_level) clase tiene 
dos métodos: [**get_Format()**](https://reference.aspose.com/slides/cpp/class/aspose.slides.charts.i_chart_data_point_level#a00caa6a048ad98a66ab56a5ddb196697) y 
[**get_Label()**](https://reference.aspose.com/slides/cpp/class/aspose.slides.charts.i_chart_data_point_level#a5ab377b372199eb561792e9ba18acf25) que 
proporcionan acceso a la configuración correspondiente.

## **Mostrar el valor de un punto de datos**
Mostrar el valor del punto de datos "Leaf 4":
``` cpp
auto dataPoints = chart->get_ChartData()->get_Series()->idx_get(0)->get_DataPoints();
dataPoints->idx_get(3)->get_DataPointLevels()->idx_get(0)->get_Label()->get_DataLabelFormat()->set_ShowValue(true);
```


![todo:image_alt_text](https://lh6.googleusercontent.com/bKHMf5Bj37ZkMwUE1OfXjw7_CRmDhafhQOUuVWDmitwbtdkwD68ibWluY6Q1HQz_z2Q-BR_SBrBPZ_gID5bGH0PUqI5w37S22RT-ZZal6k7qIDstKntYi5QXS8z-SgpnsI78WGiu)

## **Establecer la etiqueta y el color de un punto de datos**
Configurar la etiqueta de datos de "Branch 1" para que muestre el nombre de la serie ("Series1") en lugar del nombre de la categoría. Luego establecer el color del texto a amarillo:
``` cpp
auto branch1Label = dataPoints->idx_get(0)->get_DataPointLevels()->idx_get(2)->get_Label();
branch1Label->get_DataLabelFormat()->set_ShowCategoryName(false);
branch1Label->get_DataLabelFormat()->set_ShowSeriesName(true);

branch1Label->get_DataLabelFormat()->get_TextFormat()->get_PortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
branch1Label->get_DataLabelFormat()->get_TextFormat()->get_PortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Yellow());
```


![todo:image_alt_text](https://lh6.googleusercontent.com/I9g0kewJnxkhUVlfSWRN39Ng-wzjWyRwF3yTbOD9HhLTLBt_sMJiEfDe7vOfqRNx89o9AVZsYTW3Vv_TIuj4EgM4_UEEi7zQ3jdvaO8FoG2JcsOqNRgbiE5HQZNz8xx_q9qdj8JQ)

## **Establecer el color de la rama del punto de datos**

Cambiar el color de la rama "Stem 4":
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

## **Preguntas frecuentes**

**¿Puedo cambiar el orden (clasificación) de los segmentos en Sunburst/Treemap?**

No. PowerPoint ordena los segmentos automáticamente (normalmente por valores descendentes, en sentido horario). Aspose.Slides replica este comportamiento: no se puede cambiar el orden directamente; se logra preprocesando los datos.

**¿Cómo afecta el tema de la presentación a los colores de los segmentos y las etiquetas?**

Los colores del gráfico heredan el [tema/paleta](/slides/es/cpp/presentation-theme/) de la presentación, a menos que establezca explícitamente rellenos/fuentes. Para obtener resultados consistentes, bloquee los rellenos sólidos y el formato de texto en los niveles necesarios.

**¿La exportación a PDF/PNG mantendrá los colores personalizados de las ramas y la configuración de etiquetas?**

Sí. Al exportar la presentación, la configuración del gráfico (rellenos, etiquetas) se conserva en los formatos de salida porque Aspose.Slides renderiza con el formato del gráfico aplicado.

**¿Puedo calcular las coordenadas reales de una etiqueta/elemento para colocar una superposición personalizada sobre el gráfico?**

Sí. Después de validar el diseño del gráfico, los valores reales de X y Y están disponibles para los elementos (por ejemplo, un [DataLabel](https://reference.aspose.com/slides/cpp/aspose.slides.charts/datalabel/)), lo que ayuda a posicionar con precisión las superposiciones.