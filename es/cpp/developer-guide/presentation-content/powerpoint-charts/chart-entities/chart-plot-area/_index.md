---
title: Personalizar áreas de trama de los gráficos de presentación en C++
linktitle: Área de trama
type: docs
url: /es/cpp/chart-plot-area/
keywords:
- gráfico
- área de trama
- ancho del área de trama
- altura del área de trama
- tamaño del área de trama
- modo de diseño
- PowerPoint
- presentación
- C++
- Aspose.Slides
description: "Descubra cómo personalizar las áreas de trama de los gráficos en presentaciones de PowerPoint con Aspose.Slides para C++. Mejore visualmente sus diapositivas sin esfuerzo."
---

## **Obtener ancho y altura del área de trama de un gráfico**
Aspose.Slides for C++ proporciona una API simple para .

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation).
2. Acceda a la primera diapositiva.
3. Agregue un gráfico con datos predeterminados.
4. Llame al método IChart::ValidateChartLayout() antes de obtener los valores reales.
5. Obtiene la ubicación X real (izquierda) del elemento del gráfico relativa a la esquina superior izquierda del gráfico.
6. Obtiene la parte superior real del elemento del gráfico relativa a la esquina superior izquierda del gráfico.
7. Obtiene el ancho real del elemento del gráfico.
8. Obtiene la altura real del elemento del gráfico.
``` cpp
auto pres = System::MakeObject<Presentation>(u"test.Pptx");
    
auto chart = System::ExplicitCast<Chart>(pres->get_Slides()->idx_get(0)->get_Shapes()->AddChart(ChartType::ClusteredColumn, 100.0f, 100.0f, 500.0f, 350.0f));
chart->ValidateChartLayout();

double x = chart->get_PlotArea()->get_ActualX();
double y = chart->get_PlotArea()->get_ActualY();
double w = chart->get_PlotArea()->get_ActualWidth();
double h = chart->get_PlotArea()->get_ActualHeight();

// Guardar la presentación con el gráfico
pres->Save(u"Chart_out.pptx", SaveFormat::Pptx);
```


## **Establecer el modo de diseño del área de trama de un gráfico**
Aspose.Slides for C++ proporciona una API simple para establecer el modo de diseño del área de trama del gráfico. La propiedad **LayoutTargetType** se ha añadido a las clases **ChartPlotArea** e **IChartPlotArea**. Si el diseño del área de trama se define manualmente, esta propiedad especifica si el diseño del área de trama se realiza por su interior (sin incluir ejes y etiquetas de ejes) o por su exterior (incluyendo ejes y etiquetas de ejes). Hay dos valores posibles que se definen en el enumerado **LayoutTargetType**.

- **LayoutTargetType.Inner** - especifica que el tamaño del área de trama determinará el tamaño del área de trama, sin incluir las marcas de graduación y las etiquetas de los ejes.
- **LayoutTargetType.Outer** - especifica que el tamaño del área de trama determinará el tamaño del área de trama, las marcas de graduación y las etiquetas de los ejes.

A continuación se muestra el código de ejemplo.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-SetLayoutMode-SetLayoutMode.cpp" >}}

## **Preguntas frecuentes**

**¿En qué unidades se devuelven ActualX, ActualY, ActualWidth y ActualHeight?**

En puntos; 1 pulgada = 72 puntos. Estas son unidades de coordenadas de Aspose.Slides.

**¿En qué se diferencia el área de trama del área del gráfico en cuanto al contenido?**

El área de trama es la región de dibujo de los datos (series, líneas de cuadrícula, líneas de tendencia, etc.); el área del gráfico incluye los elementos circundantes (título, leyenda, etc.). En los gráficos 3D, el área de trama también incluye los muros/piso y los ejes.

**¿Cómo se interpretan X, Y, Width y Height del área de trama cuando el diseño es manual?**

Son fracciones (0–1) del tamaño total del gráfico; en este modo, el posicionamiento automático está deshabilitado y se utilizan las fracciones que usted establece.

**¿Por qué cambió la posición del área de trama después de agregar/mover la leyenda?**

La leyenda se encuentra en el área del gráfico fuera del área de trama, pero afecta el diseño y el espacio disponible, por lo que el área de trama puede desplazarse cuando el posicionamiento automático está en vigor. (Este es un comportamiento estándar de los gráficos de PowerPoint.)