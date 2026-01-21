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
description: "Aprenda cómo gestionar los puntos de datos en los gráficos de Treemap y Sunburst con Aspose.Slides para C++, compatible con los formatos de PowerPoint."
---

Entre otros tipos de gráficos de PowerPoint, existen dos tipos «jerárquicos»: el gráfico **Treemap** y el gráfico **Sunburst** (también conocido como Gráfico Sunburst, Diagrama Sunburst, Gráfico radial, Gráfico radial o Gráfico de pastel multinivel). Estos gráficos muestran datos jerárquicos organizados como un árbol, desde las hojas hasta la parte superior de la rama. Las hojas se definen mediante los puntos de datos de la serie, y cada nivel de agrupación anidado posterior se define por la categoría correspondiente. Aspose.Slides para C++ permite dar formato a los puntos de datos del gráfico Sunburst y Treemap en C++.

Aquí tienes un gráfico Sunburst, donde los datos en la columna Series1 definen los nodos hoja, mientras que las demás columnas definen los puntos de datos jerárquicos:

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

[**IChartDataPointLevelsManager**](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdatapointlevelsmanager/), [**IChartDataPointLevel**](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdatapointlevel/) classes and [**IChartDataPoint::get_DataPointLevels()**](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdatapoint/get_datapointlevels/) method provide access to format data points of Treemap and Sunburst charts.
[**IChartDataPointLevelsManager**](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdatapointlevelsmanager/) se utiliza para acceder a categorías multinivel - representa el contenedor de objetos [**IChartDataPointLevel**](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdatapointlevel/). 
Básicamente es un contenedor de [**IChartCategoryLevelsManager**](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartcategorylevelsmanager/) con propiedades añadidas específicas para los puntos de datos. 
La clase [**IChartDataPointLevel**](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdatapointlevel/) tiene dos métodos: [**get_Format()**](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdatapointlevel/get_format/) y [**get_Label()**](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdatapointlevel/get_label/) que proporcionan acceso a la configuración correspondiente.

## **Mostrar el valor de un punto de datos**
Mostrar el valor del punto de datos "Leaf 4":
``` cpp
auto dataPoints = chart->get_ChartData()->get_Series()->idx_get(0)->get_DataPoints();
dataPoints->idx_get(3)->get_DataPointLevels()->idx_get(0)->get_Label()->get_DataLabelFormat()->set_ShowValue(true);
```


![todo:image_alt_text](https://lh6.googleusercontent.com/bKHMf5Bj37ZkMwUE1OfXjw7_CRmDhafhQOUuVWDmitwbtdkwD68ibWluY6Q1HQz_z2Q-BR_SBrBPZ_gID5bGH0PUqI5w37S22RT-ZZal6k7qIDstKntYi5QXS8z-SgpnsI78WGiu)

## **Establecer la etiqueta y el color de un punto de datos**
Establecer la etiqueta de datos "Branch 1" para que muestre el nombre de la serie ("Series1") en lugar del nombre de la categoría. Después, establecer el color del texto a amarillo:
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

**¿Puedo cambiar el orden (ordenación) de los segmentos en Sunburst/Treemap?**

No. PowerPoint ordena los segmentos automáticamente (normalmente por valores descendentes, en sentido horario). Aspose.Slides replica este comportamiento: no se puede cambiar el orden directamente; se logra preprocesando los datos.

**¿Cómo afecta el tema de la presentación a los colores de los segmentos y las etiquetas?**

Los colores del gráfico heredan el [tema/paleta](/slides/es/cpp/presentation-theme/) de la presentación a menos que se establezcan explícitamente rellenos/fuentes. Para obtener resultados consistentes, fije rellenos sólidos y el formato de texto en los niveles necesarios.

**¿La exportación a PDF/PNG conservará los colores de rama personalizados y la configuración de etiquetas?**

Sí. Al exportar la presentación, la configuración del gráfico (rellenos, etiquetas) se conserva en los formatos de salida porque Aspose.Slides renderiza con el formato del gráfico aplicado.

**¿Puedo calcular las coordenadas reales de una etiqueta/elemento para colocar una superposición personalizada sobre el gráfico?**

Sí. Después de validar la disposición del gráfico, están disponibles X real y Y real para los elementos (por ejemplo, una [DataLabel](https://reference.aspose.com/slides/cpp/aspose.slides.charts/datalabel/)), lo que ayuda a posicionar con precisión las superposiciones.