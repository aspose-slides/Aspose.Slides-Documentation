---
title: Gráfico
type: docs
weight: 60
url: /pt/cpp/examples/elements/chart/
keywords:
- exemplo de código
- gráfico
- PowerPoint
- OpenDocument
- apresentação
- C++
- Aspose.Slides
description: "Domine gráficos com Aspose.Slides para C++: crie, formate, vincule dados e exporte gráficos em PPT, PPTX e ODP com exemplos em C++."
---
Exemplos de adição, acesso, remoção e atualização de diferentes tipos de gráfico com **Aspose.Slides for C++**. Os trechos abaixo demonstram operações básicas com gráficos.

## **Add a Chart**

Este método adiciona um gráfico de área simples ao primeiro slide.

```cpp
static void AddChart()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    // Adiciona um gráfico de área simples ao primeiro slide.
    auto chart = slide->get_Shapes()->AddChart(ChartType::Area, 50, 50, 400, 300);

    presentation->Dispose();
}
```

## **Access a Chart**

Depois de criar um gráfico, você pode recuperá-lo através da coleção de formas.

```cpp
static void AccessChart()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto chart = slide->get_Shapes()->AddChart(ChartType::Line, 50, 50, 400, 300);

    // Acesse o primeiro gráfico no slide.
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

## **Remove a Chart**

O código a seguir remove um gráfico de um slide.

```cpp
static void RemoveChart()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto chart = slide->get_Shapes()->AddChart(ChartType::Pie, 50, 50, 400, 300);

    // Remove o gráfico.
    slide->get_Shapes()->Remove(chart);

    presentation->Dispose();
}
```

## **Update Chart Data**

Você pode alterar propriedades do gráfico, como o título.

```cpp
static void UpdateChartData()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto chart = slide->get_Shapes()->AddChart(ChartType::Column3D, 50, 50, 400, 300);

    // Altere o título do gráfico.
    chart->get_ChartTitle()->AddTextFrameForOverriding(u"Sales Report");

    presentation->Dispose();
}
```