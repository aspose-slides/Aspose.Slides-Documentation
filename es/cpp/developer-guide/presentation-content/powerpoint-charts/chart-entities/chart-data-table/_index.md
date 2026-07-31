---
title: Personalizar tablas de datos de gráficos en presentaciones usando C++
linktitle: Tabla de datos
type: docs
url: /es/cpp/chart-data-table/
keywords:
- datos de gráfico
- tabla de datos
- propiedades de fuente
- PowerPoint
- presentación
- C++
- Aspose.Slides
description: "Personaliza tablas de datos de gráficos en C++ para PPT y PPTX con Aspose.Slides para mejorar la eficiencia y el atractivo en presentaciones."
---
## **Visión general**

Este artículo explica cómo trabajar con tablas de datos de gráfico en Aspose.Slides. Muestra cómo mostrar una tabla de datos para un gráfico y personalizar su formato de texto configurando propiedades de fuente como estilo negrita y altura de fuente. El ejemplo demuestra cómo cargar una presentación, añadir un gráfico, habilitar la tabla de datos del gráfico, aplicar configuraciones de fuente y guardar la presentación actualizada.

## **Establecer propiedades de fuente para una tabla de datos de gráfico**
Aspose.Slides for C++ permite cambiar las propiedades de fuente para una tabla de datos de gráfico. 

1. Instanciar el objeto de la clase [Presentation](https://reference.aspose.com/slides/es/cpp/class/aspose.slides.presentation).
2. Añadir un gráfico en la diapositiva.
3. Establecer la tabla del gráfico.
4. Establecer la altura de la fuente.
5. Guardar la presentación modificada.

A continuación se muestra un ejemplo de muestra. 

``` cpp
auto pres = System::MakeObject<Presentation>(u"test.pptx");
    
auto chart = pres->get_Slides()->idx_get(0)->get_Shapes()->AddChart(ChartType::ClusteredColumn, 50.0f, 50.0f, 600.0f, 400.0f);

chart->set_HasDataTable(true);

chart->get_ChartDataTable()->get_TextFormat()->get_PortionFormat()->set_FontBold(NullableBool::True);
chart->get_ChartDataTable()->get_TextFormat()->get_PortionFormat()->set_FontHeight(20.0f);

pres->Save(u"output.pptx", SaveFormat::Pptx);
```

## **Preguntas frecuentes**

**¿Puedo mostrar pequeñas claves de leyenda junto a los valores en la tabla de datos del gráfico?**

Sí. La tabla de datos admite [claves de leyenda](https://reference.aspose.com/slides/es/cpp/aspose.slides.charts/datatable/set_showlegendkey/), y puedes activarlas o desactivarlas.

**¿Se conservará la tabla de datos al exportar la presentación a PDF, HTML o imágenes?**

Sí. Aspose.Slides renderiza el gráfico como parte de la diapositiva, por lo que el [PDF](/slides/es/cpp/convert-powerpoint-to-pdf/)/[HTML](/slides/es/cpp/convert-powerpoint-to-html/)/[imagen](/slides/es/cpp/convert-powerpoint-to-png/) exportado incluye el gráfico con su tabla de datos.

**¿Se admiten tablas de datos para los gráficos que provienen de un archivo de plantilla?**

Sí. Para cualquier gráfico cargado desde una presentación o plantilla existente, puedes comprobar y cambiar si la tabla de datos [se muestra](https://reference.aspose.com/slides/es/cpp/aspose.slides.charts/chart/set_hasdatatable/) mediante las propiedades del gráfico.

**¿Cómo puedo encontrar rápidamente qué gráficos en un archivo tienen la tabla de datos habilitada?**

Inspecciona la propiedad de cada gráfico que indica si la tabla de datos [se muestra](https://reference.aspose.com/slides/es/cpp/aspose.slides.charts/chart/get_hasdatatable/) e itera a través de las diapositivas para identificar los gráficos donde está habilitada.