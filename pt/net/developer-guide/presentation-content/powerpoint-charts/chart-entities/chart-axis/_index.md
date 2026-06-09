---
title: Personalizar Eixos de Gráficos em Apresentações no .NET
linktitle: Eixo de Gráfico
type: docs
url: /pt/net/chart-axis/
keywords:
- eixo de gráfico
- eixo vertical
- eixo horizontal
- personalizar eixo
- manipular eixo
- gerenciar eixo
- propriedades do eixo
- valor máximo
- valor mínimo
- linha do eixo
- formato de data
- título do eixo
- posição do eixo
- PowerPoint
- apresentação
- .NET
- C#
- Aspose.Slides
description: "Descubra como usar o Aspose.Slides para .NET para personalizar os eixos de gráficos em apresentações do PowerPoint para relatórios e visualizações."
---
## **Visão geral**

Este artigo explica como personalizar os eixos de gráficos no Aspose.Slides. Ele mostra como obter os valores reais dos eixos, trocar dados entre eixos, ocultar o eixo vertical ou horizontal em gráficos de linhas, alterar o tipo do eixo de categoria, definir o formato de data para os valores do eixo de categoria, girar o título de um eixo, definir a posição do eixo e exibir um rótulo de unidade no eixo de valores.

## **Obter os valores máximos no eixo vertical em gráficos**
Aspose.Slides for .NET permite obter os valores mínimo e máximo em um eixo vertical. Siga estas etapas:

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/net/aspose.slides/presentation).
1. Acesse o primeiro slide.
1. Adicione um gráfico com dados padrão.
1. Obtenha o valor máximo real no eixo.
1. Obtenha o valor mínimo real no eixo.
1. Obtenha a unidade principal real do eixo.
1. Obtenha a unidade secundária real do eixo.
1. Obtenha a escala da unidade principal real do eixo.
1. Obtenha a escala da unidade secundária real do eixo.

Este código de exemplo — uma implementação das etapas acima — mostra como obter os valores necessários em C#:

```c#
using (Presentation pres = new Presentation())
{
	Chart chart = (Chart)pres.Slides[0].Shapes.AddChart(ChartType.Area, 100, 100, 500, 350);
	chart.ValidateChartLayout();

	double maxValue = chart.Axes.VerticalAxis.ActualMaxValue;
	double minValue = chart.Axes.VerticalAxis.ActualMinValue;

	double majorUnit = chart.Axes.HorizontalAxis.ActualMajorUnit;
	double minorUnit = chart.Axes.HorizontalAxis.ActualMinorUnit;
	
	// Salva a apresentação
	presentation.Save("ErrorBars_out.pptx", SaveFormat.Pptx);
}
```

## **Trocar os dados entre eixos**
Aspose.Slides permite trocar rapidamente os dados entre eixos — os dados representados no eixo vertical (eixo y) são movidos para o eixo horizontal (eixo x) e vice‑versa.

Este código C# mostra como executar a troca de dados entre eixos em um gráfico:

```c#
// Cria apresentação vazia
using (Presentation pres = new Presentation())
{
	IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 100, 100, 400, 300);

	// Inverte linhas e colunas
	chart.ChartData.SwitchRowColumn();
	   
	// Salva a apresentação
	 pres.Save("SwitchChartRowColumns_out.pptx", SaveFormat.Pptx);
}
```

## **Desativar o eixo vertical para gráficos de linhas**

Este código C# mostra como ocultar o eixo vertical em um gráfico de linhas:

```c#
using (Presentation pres = new Presentation())
{
    IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Line, 100, 100, 400, 300);
    chart.Axes.VerticalAxis.IsVisible = false; 
    
    pres.Save("chart.pptx", SaveFormat.Pptx);
}
```

## **Desativar o eixo horizontal para gráficos de linhas**

Este código mostra como ocultar o eixo horizontal em um gráfico de linhas:

```c#
using (Presentation pres = new Presentation())
{
    IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Line, 100, 100, 400, 300);
    chart.Axes.HorizontalAxis.IsVisible = false; 
    
    pres.Save("chart.pptx", SaveFormat.Pptx);
}
```

## **Alterar um eixo de categoria**

Usando a propriedade **CategoryAxisType**, você pode especificar o tipo de eixo de categoria desejado (**date** ou **text**). Este código em C# demonstra a operação:

```c#
using (Presentation presentation = new Presentation("ExistingChart.pptx"))
{
    IChart chart = presentation.Slides[0].Shapes[0] as IChart;
    chart.Axes.HorizontalAxis.CategoryAxisType = CategoryAxisType.Date;
    chart.Axes.HorizontalAxis.IsAutomaticMajorUnit = false;
    chart.Axes.HorizontalAxis.MajorUnit = 1;
    chart.Axes.HorizontalAxis.MajorUnitScale = TimeUnitType.Months;
    presentation.Save("ChangeChartCategoryAxis_out.pptx", SaveFormat.Pptx);
}
```

## **Definir o formato de data para valores do eixo de categoria**
Aspose.Slides for .NET permite definir o formato de data para um valor do eixo de categoria. A operação é demonstrada neste código C#:

```c#
using (Presentation pres = new Presentation())
{
	IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Area, 50, 50, 450, 300);

	IChartDataWorkbook wb = chart.ChartData.ChartDataWorkbook;

	wb.Clear(0);

	chart.ChartData.Categories.Clear();
	chart.ChartData.Series.Clear();
	chart.ChartData.Categories.Add(wb.GetCell(0, "A2", new DateTime(2015, 1, 1).ToOADate()));
	chart.ChartData.Categories.Add(wb.GetCell(0, "A3", new DateTime(2016, 1, 1).ToOADate()));
	chart.ChartData.Categories.Add(wb.GetCell(0, "A4", new DateTime(2017, 1, 1).ToOADate()));
	chart.ChartData.Categories.Add(wb.GetCell(0, "A5", new DateTime(2018, 1, 1).ToOADate()));

	IChartSeries series = chart.ChartData.Series.Add(ChartType.Line);
	series.DataPoints.AddDataPointForLineSeries(wb.GetCell(0, "B2", 1));
	series.DataPoints.AddDataPointForLineSeries(wb.GetCell(0, "B3", 2));
	series.DataPoints.AddDataPointForLineSeries(wb.GetCell(0, "B4", 3));
	series.DataPoints.AddDataPointForLineSeries(wb.GetCell(0, "B5", 4));
	chart.Axes.HorizontalAxis.CategoryAxisType = CategoryAxisType.Date;
	chart.Axes.HorizontalAxis.IsNumberFormatLinkedToSource = false;
	chart.Axes.HorizontalAxis.NumberFormat = "yyyy";
	pres.Save("test.pptx", SaveFormat.Pptx);
}
```

## **Definir um ângulo de rotação para o título do eixo do gráfico**
Aspose.Slides for .NET permite definir o ângulo de rotação para o título de um eixo de gráfico. Este código C# demonstra a operação:

```c#
using (Presentation pres = new Presentation())
{
	IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 450, 300);
	chart.Axes.VerticalAxis.HasTitle = true;
             chart.Axes.VerticalAxis.Title.TextFormat.TextBlockFormat.RotationAngle = 90;

	pres.Save("test.pptx", SaveFormat.Pptx);
}
```

## **Definir a posição do eixo em um eixo de categoria ou de valor**
Aspose.Slides for .NET permite definir a posição do eixo em um eixo de categoria ou de valor. Este código C# mostra como executar a tarefa:

```c#
using (Presentation pres = new Presentation())
{
	IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 450, 300);
	chart.Axes.HorizontalAxis.AxisBetweenCategories = true;

	pres.Save("AsposeScatterChart.pptx", SaveFormat.Pptx);
}
```

## **Habilitar a exibição do rótulo de unidade no eixo de valor do gráfico**
Aspose.Slides for .NET permite configurar um gráfico para mostrar um rótulo de unidade em seu eixo de valores. Este código C# demonstra a operação:

```c#
using (Presentation pres = new Presentation(dataDir+"Test.pptx"))
{
	IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 450, 300);
	chart.Axes.VerticalAxis.DisplayUnit = DisplayUnitType.Millions;
	pres.Save("Result.pptx", SaveFormat.Pptx);
}
```

## **FAQ**

**Como definir o valor no qual um eixo cruza o outro (cruzamento de eixos)?**

Os eixos fornecem uma [configuração de cruzamento](https://reference.aspose.com/slides/pt/net/aspose.slides.charts/axis/crosstype/): você pode escolher cruzar em zero, no valor máximo da categoria/valor ou em um valor numérico específico. Isso é útil para deslocar o eixo X para cima ou para baixo ou para enfatizar uma linha de base.

**Como posicionar os rótulos de marcação em relação ao eixo (ao lado, fora, dentro)?**

Defina a [posição do rótulo](https://reference.aspose.com/slides/pt/net/aspose.slides.charts/axis/majortickmark/) como "cross", "outside" ou "inside". Isso afeta a legibilidade e ajuda a economizar espaço, especialmente em gráficos pequenos.