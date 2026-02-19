---
title: Gráfico
type: docs
weight: 60
url: /es/cpp/examples/elements/chart/
keywords:
- ejemplo de código
- gráfico
- PowerPoint
- OpenDocument
- presentación
- C++
- Aspose.Slides
description: "Domina los gráficos con Aspose.Slides for C++: crea, formatea, enlaza datos y exporta gráficos en PPT, PPTX y ODP con ejemplos en C++."
---
Ejemplos para añadir, acceder, eliminar y actualizar diferentes tipos de gráfico con **Aspose.Slides for C++**. Los fragmentos a continuación demuestran operaciones básicas con gráficos.

## **Añadir un gráfico**

Este método añade un gráfico de áreas simple a la primera diapositiva.

```cpp
static void AddChart()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    // Añade un gráfico de áreas simple a la primera diapositiva.
    auto chart = slide->get_Shapes()->AddChart(ChartType::Area, 50, 50, 400, 300);

    presentation->Dispose();
}
```

## **Acceder a un gráfico**

Después de crear un gráfico, puedes recuperarlo a través de la colección de formas.

```cpp
static void AccessChart()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto chart = slide->get_Shapes()->AddChart(ChartType::Line, 50, 50, 400, 300);

    // Accede al primer gráfico de la diapositiva.
    auto firstChart = SharedPtr<IChart>();
    for (auto&& shape : slide->get_Shapes())
    {
        if (ObjectExt::Is<IChart>(shape))
        {
            firstChart = ExplicitCast<IChart>(shape);
            break;
        }
    }

    presentation->Dispose();
}
```

## **Eliminar un gráfico**

El siguiente código elimina un gráfico de una diapositiva.

```cpp
static void RemoveChart()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto chart = slide->get_Shapes()->AddChart(ChartType::Pie, 50, 50, 400, 300);

    // Elimina el gráfico.
    slide->get_Shapes()->Remove(chart);

    presentation->Dispose();
}
```

## **Actualizar datos del gráfico**

Puedes cambiar propiedades del gráfico, como el título.

```cpp
static void UpdateChartData()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto chart = slide->get_Shapes()->AddChart(ChartType::Column3D, 50, 50, 400, 300);

    // Cambia el título del gráfico.
    chart->get_ChartTitle()->AddTextFrameForOverriding(u"Sales Report");

    presentation->Dispose();
}
```