---
title: Personalizar áreas de trazado de gráficos de presentaciones en C++
linktitle: Área de trazado
type: docs
url: /es/cpp/chart-plot-area/
keywords:
- gráfico
- área de trazado
- anchura del área de trazado
- altura del área de trazado
- tamaño del área de trazado
- modo de diseño
- PowerPoint
- presentación
- C++
- Aspose.Slides
description: "Descubre cómo personalizar las áreas de trazado de los gráficos en presentaciones de PowerPoint con Aspose.Slides para C++. Mejora tus visuales de diapositivas sin esfuerzo."
---
## **Visión general**

Este artículo muestra cómo trabajar con el área de trazado de un gráfico en Aspose.Slides. Explica cómo obtener la posición y el tamaño reales del área de trazado validando el diseño del gráfico y luego leyendo sus valores X, Y, anchura y altura.

También demuestra cómo configurar el modo de diseño del área de trazado cuando el diseño se establece manualmente, usando `LayoutTargetType` para definir si el área de trazado se calcula por su región interior o por su región exterior junto con los ejes y las etiquetas de los ejes.

## **Obtener ancho y altura del área de trazado de un gráfico**
Aspose.Slides para C++ ofrece una API sencilla para .

1. Cree una instancia de la clase[Presentation](https://reference.aspose.com/slides/es/cpp/class/aspose.slides.presentation).
1. Acceda a la primera diapositiva.
1. Añada un gráfico con datos predeterminados.
1. Llame al método IChart::ValidateChartLayout() antes para obtener los valores reales.
1. Obtenga la posición X real (izquierda) del elemento del gráfico respecto a la esquina superior izquierda del mismo.
1. Obtenga la posición Y real (superior) del elemento del gráfico respecto a la esquina superior izquierda del mismo.
1. Obtenga la anchura real del elemento del gráfico.
1. Obtenga la altura real del elemento del gráfico.

``` cpp
auto pres = System::MakeObject<Presentation>(u"test.Pptx");
    
auto chart = System::ExplicitCast<Chart>(pres->get_Slides()->idx_get(0)->get_Shapes()->AddChart(ChartType::ClusteredColumn, 100.0f, 100.0f, 500.0f, 350.0f));
chart->ValidateChartLayout();

double x = chart->get_PlotArea()->get_ActualX();
double y = chart->get_PlotArea()->get_ActualY();
double w = chart->get_PlotArea()->get_ActualWidth();
double h = chart->get_PlotArea()->get_ActualHeight();

// Guardar presentación con el gráfico
pres->Save(u"Chart_out.pptx", SaveFormat::Pptx);
```

## **Establecer el modo de diseño del área de trazado de un gráfico**
Aspose.Slides para C++ ofrece una API sencilla para establecer el modo de diseño del área de trazado del gráfico. La propiedad **LayoutTargetType** se ha añadido a las clases **ChartPlotArea** e **IChartPlotArea**. Si el diseño del área de trazado se define manualmente, esta propiedad especifica si el área se dispone por su interior (sin incluir ejes y etiquetas de ejes) o por su exterior (incluyendo ejes y etiquetas de ejes). Existen dos valores posibles que se definen en el enumerado **LayoutTargetType**.

- **LayoutTargetType.Inner** – especifica que el tamaño del área de trazado determinará el tamaño del área, sin incluir las marcas de graduación y las etiquetas de los ejes.
- **LayoutTargetType.Outer** – especifica que el tamaño del área de trazado determinará el tamaño del área, las marcas de graduación y las etiquetas de los ejes.

A continuación se muestra el código de ejemplo.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-SetLayoutMode-SetLayoutMode.cpp" >}}

## **Preguntas frecuentes**

**¿En qué unidades se devuelven ActualX, ActualY, ActualWidth y ActualHeight?**

En puntos; 1 pulgada = 72 puntos. Estas son unidades de coordenadas de Aspose.Slides.

**¿En qué se diferencia el área de trazado del área del gráfico en cuanto al contenido?**

El área de trazado es la zona donde se dibujan los datos (series, líneas de cuadrícula, líneas de tendencia, etc.); el área del gráfico incluye los elementos circundantes (título, leyenda, etc.). En los gráficos 3D, el área de trazado también incluye las paredes/suelo y los ejes.

**¿Cómo se interpretan X, Y, ancho y altura del área de trazado cuando el diseño es manual?**

Son fracciones (0‑1) del tamaño total del gráfico; en este modo, el posicionamiento automático está desactivado y se utilizan las fracciones establecidas.

**¿Por qué cambió la posición del área de trazado después de añadir/mover la leyenda?**

La leyenda se sitúa en el área del gráfico fuera del área de trazado pero afecta al diseño y al espacio disponible, por lo que el área de trazado puede desplazarse cuando el posicionamiento automático está activo. (Este es el comportamiento estándar de los gráficos de PowerPoint.)