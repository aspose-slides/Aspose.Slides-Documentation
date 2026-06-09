---
title: Gráfico
type: docs
weight: 60
url: /pt/net/examples/elements/chart/
keywords:
- gráfico
- adicionar gráfico
- acessar gráfico
- remover gráfico
- atualizar gráfico
- exemplo de código
- PowerPoint
- OpenDocument
- apresentação
- .NET
- C#
- Aspose.Slides
description: "Domine gráficos com Aspose.Slides para .NET: crie, formate, ligue dados e exporte gráficos em PPT, PPTX e ODP com exemplos em C#."
---
Exemplos de como adicionar, acessar, remover e atualizar diferentes tipos de gráfico com **Aspose.Slides for .NET**. Os trechos abaixo demonstram operações básicas com gráficos.

## **Adicionar um Gráfico**

Este método adiciona um gráfico de área simples ao primeiro slide.

```csharp
static void AddChart()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    // Adicionar um gráfico de área simples ao primeiro slide.
    var chart = slide.Shapes.AddChart(ChartType.Area, 50, 50, 400, 300);
}
```

## **Acessar um Gráfico**

Depois de criar um gráfico, você pode recuperá‑lo através da coleção de formas.

```csharp
static void AccessChart()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var chart = slide.Shapes.AddChart(ChartType.Line, 50, 50, 400, 300);

    // Acessar o primeiro gráfico no slide.
    var firstChart = slide.Shapes.OfType<IChart>().First();
}
```

## **Remover um Gráfico**

O código a seguir remove um gráfico de um slide.

```csharp
static void RemoveChart()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var chart = slide.Shapes.AddChart(ChartType.Pie, 50, 50, 400, 300);

    // Remover o gráfico.
    slide.Shapes.Remove(chart);
}
```

## **Atualizar Dados do Gráfico**

Você pode alterar propriedades do gráfico, como o título.

```csharp
static void UpdateChartData()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];
    
    var chart = slide.Shapes.AddChart(ChartType.Column3D, 50, 50, 400, 300);

    // Alterar o título do gráfico.
    chart.ChartTitle.AddTextFrameForOverriding("Sales Report");
}
```