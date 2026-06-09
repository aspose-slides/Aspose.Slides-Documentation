---
title: Otimizar Cálculos de Gráficos para Apresentações em .NET
linktitle: Cálculos de Gráficos
type: docs
weight: 50
url: /pt/net/chart-calculations/
keywords:
- cálculos de gráficos
- elementos do gráfico
- posição do elemento
- posição real
- elemento filho
- elemento pai
- valores do gráfico
- valor real
- PowerPoint
- apresentação
- .NET
- C#
- Aspose.Slides
description: "Entenda os cálculos de gráficos, atualizações de dados e controle de precisão no Aspose.Slides para .NET para PPT e PPTX, com exemplos práticos de código C#."
---
## **Visão geral**

Aspose.Slides fornece APIs para trabalhar com cálculos de gráficos e dados de layout em apresentações. Este artigo mostra como recuperar os valores reais dos elementos do gráfico, incluindo a posição e o tamanho reais dos elementos que implementam `IActualLayout` e os valores reais dos eixos do gráfico. Também explica que esses valores são preenchidos após a validação do layout do gráfico.

Além disso, o artigo demonstra como obter a posição real dos elementos de gráfico pai e como ocultar componentes do gráfico, como o título, eixos, legenda e linhas de grade. Juntos, esses exemplos ajudam a inspecionar as informações de layout do gráfico e controlar a visibilidade dos elementos do gráfico em apresentações do PowerPoint de forma programática.

## **Calcular Valores Reais dos Elementos do Gráfico**
Aspose.Slides para .NET fornece uma API simples para obter essas propriedades. Isso ajudará você a calcular os valores reais dos elementos do gráfico. Os valores reais incluem a posição dos elementos que implementam a interface IActualLayout (IActualLayout.ActualX, IActualLayout.ActualY, IActualLayout.ActualWidth, IActualLayout.ActualHeight) e os valores reais dos eixos (IAxis.ActualMaxValue, IAxis.ActualMinValue, IAxis.ActualMajorUnit, IAxis.ActualMinorUnit, IAxis.ActualMajorUnitScale, IAxis.ActualMinorUnitScale).

```c#
using (Presentation pres = new Presentation("test.pptx"))
{
    Chart chart = (Chart)pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 100, 100, 500, 350);
    chart.ValidateChartLayout();
    double x = chart.PlotArea.ActualX;
    double y = chart.PlotArea.ActualY;
    double w = chart.PlotArea.ActualWidth;
    double h = chart.PlotArea.ActualHeight;
	
	// Salvando a apresentação
	pres.Save("Result.pptx", SaveFormat.Pptx);
}
```

## **Calcular Posição Real dos Elementos de Gráfico Pai**
Aspose.Slides para .NET fornece uma API simples para obter essas propriedades. As propriedades de IActualLayout fornecem informações sobre a posição real do elemento de gráfico pai. É necessário chamar o método IChart.ValidateChartLayout() previamente para preencher as propriedades com os valores reais.

```c#
// Criando apresentação vazia
using (Presentation pres = new Presentation())
{
   Chart chart = (Chart)pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 100, 100, 500, 350);
   chart.ValidateChartLayout();

   double x = chart.PlotArea.ActualX;
   double y = chart.PlotArea.ActualY;
   double w = chart.PlotArea.ActualWidth;
   double h = chart.PlotArea.ActualHeight;
}
```

## **Ocultar Elementos do Gráfico**
Este tópico ajuda a entender como ocultar informações do gráfico. Usando Aspose.Slides para .NET você pode ocultar **Título, Eixo Vertical, Eixo Horizontal** e **Linhas de Grade** do gráfico. O exemplo de código abaixo mostra como usar essas propriedades.

```c#
using (Presentation pres = new Presentation())
{
    ISlide slide = pres.Slides[0];
    IChart chart = slide.Shapes.AddChart(ChartType.LineWithMarkers, 140, 118, 320, 370);

    //Ocultando o título do gráfico
    chart.HasTitle = false;

    ///Ocultando eixo de valores
    chart.Axes.VerticalAxis.IsVisible = false;

    //Visibilidade do eixo de categoria
    chart.Axes.HorizontalAxis.IsVisible = false;

    //Ocultando a legenda
    chart.HasLegend = false;

    //Ocultando linhas de grade principais
    chart.Axes.HorizontalAxis.MajorGridLinesFormat.Line.FillFormat.FillType = FillType.NoFill;

    for (int i = 0; i < chart.ChartData.Series.Count; i++)
    {
        chart.ChartData.Series.RemoveAt(i);
    }

    IChartSeries series = chart.ChartData.Series[0];

    series.Marker.Symbol = MarkerStyleType.Circle;
    series.Labels.DefaultDataLabelFormat.ShowValue = true;
    series.Labels.DefaultDataLabelFormat.Position = LegendDataLabelPosition.Top;
    series.Marker.Size = 15;

    //Definindo a cor da linha da série
    series.Format.Line.FillFormat.FillType = FillType.Solid;
    series.Format.Line.FillFormat.SolidFillColor.Color = Color.Purple;
    series.Format.Line.DashStyle = LineDashStyle.Solid;

    pres.Save("HideInformationFromChart.pptx", SaveFormat.Pptx);
}
```

## **FAQ**

**Os workbooks externos do Excel funcionam como fonte de dados e como isso afeta o recálculo?**

Sim. Um gráfico pode referenciar um workbook externo: ao conectar ou atualizar a fonte externa, as fórmulas e valores são obtidos desse workbook, e o gráfico reflete as atualizações durante as operações de abertura/edição. A API permite que você [especifique o workbook externo](https://reference.aspose.com/slides/pt/net/aspose.slides.charts/chartdata/setexternalworkbook/) caminho e gerencie os dados vinculados.

**Posso calcular e exibir linhas de tendência sem implementar a regressão eu mesmo?**

Sim. [Linhas de tendência](/slides/pt/net/trend-line/) (lineares, exponenciais e outras) são adicionadas e atualizadas pelo Aspose.Slides; seus parâmetros são recalculados automaticamente a partir dos dados da série, portanto você não precisa implementar seus próprios cálculos.

**Se uma apresentação tem vários gráficos com links externos, posso controlar qual workbook cada gráfico usa para os valores calculados?**

Sim. Cada gráfico pode apontar para seu próprio [workbook externo](https://reference.aspose.com/slides/pt/net/aspose.slides.charts/chartdata/setexternalworkbook/), ou você pode criar/substituir um workbook externo por gráfico independentemente dos demais.