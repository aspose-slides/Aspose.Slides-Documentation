---
title: Tabla de Datos del Gráfico
type: docs
url: /es/cpp/chart-data-table/
---

## **Establecer Propiedades de Fuente para la Tabla de Datos del Gráfico**
Aspose.Slides para C++ permite cambiar las propiedades de fuente para una tabla de datos del gráfico. 

1. Instanciar [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) como objeto.
1. Agregar un gráfico en la diapositiva.
1. Establecer la tabla del gráfico.
1. Establecer la altura de la fuente.
1. Guardar la presentación modificada.

A continuación se muestra un ejemplo de código. 

``` cpp
auto pres = System::MakeObject<Presentation>(u"test.pptx");
    
auto chart = pres->get_Slides()->idx_get(0)->get_Shapes()->AddChart(ChartType::ClusteredColumn, 50.0f, 50.0f, 600.0f, 400.0f);

chart->set_HasDataTable(true);

chart->get_ChartDataTable()->get_TextFormat()->get_PortionFormat()->set_FontBold(NullableBool::True);
chart->get_ChartDataTable()->get_TextFormat()->get_PortionFormat()->set_FontHeight(20.0f);

pres->Save(u"output.pptx", SaveFormat::Pptx);
```