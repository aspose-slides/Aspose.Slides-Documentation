---
title: Gerenciar Rótulos de Dados de Gráficos em Apresentações no .NET
linktitle: Rótulo de Dados
type: docs
url: /pt/net/chart-data-label/
keywords:
- gráfico
- rótulo de dados
- precisão de dados
- percentual
- distância do rótulo
- localização do rótulo
- PowerPoint
- apresentação
- .NET
- C#
- Aspose.Slides
description: "Aprenda a adicionar e formatar rótulos de dados em gráficos em apresentações do PowerPoint usando Aspose.Slides para .NET para slides mais envolventes."
---
## **Introdução**

Os rótulos de dados em um gráfico mostram detalhes sobre a série de dados do gráfico ou pontos de dados individuais. Eles permitem que os leitores identifiquem rapidamente as séries de dados e também facilitam a compreensão dos gráficos.

## **Definir Precisão dos Dados nos Rótulos de Dados do Gráfico**

Este código C# mostra como definir a precisão dos dados em um rótulo de dados de um gráfico:

```c#
using (Presentation pres = new Presentation())
{
	IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Line, 50, 50, 450, 300);
	chart.HasDataTable = true;
	chart.ChartData.Series[0].NumberFormatOfValues = "#,##0.00";

	pres.Save("PrecisionOfDatalabels_out.pptx", SaveFormat.Pptx);
}
```

## **Exibir Percentual como Rótulos**
Aspose.Slides for .NET permite definir rótulos de percentual em gráficos exibidos. Este código C# demonstra a operação:

```c#
 // Cria uma instância da classe Presentation
Presentation presentation = new Presentation();

ISlide slide = presentation.Slides[0];
IChart chart = slide.Shapes.AddChart(ChartType.StackedColumn, 20, 20, 400, 400);
IChartSeries series = chart.ChartData.Series[0];
IChartCategory cat;
double[] total_for_Cat = new double[chart.ChartData.Categories.Count];
for (int k = 0; k < chart.ChartData.Categories.Count; k++)
{
    cat = chart.ChartData.Categories[k];

    for (int i = 0; i < chart.ChartData.Series.Count; i++)
    {
        total_for_Cat[k] = total_for_Cat[k] + Convert.ToDouble(chart.ChartData.Series[i].DataPoints[k].Value.Data);
    }
}

double dataPontPercent = 0f;

for (int x = 0; x < chart.ChartData.Series.Count; x++)
{
    series = chart.ChartData.Series[x];
    series.Labels.DefaultDataLabelFormat.ShowLegendKey = false;

    for (int j = 0; j < series.DataPoints.Count; j++)
    {
        IDataLabel lbl = series.DataPoints[j].Label;
        dataPontPercent = (Convert.ToDouble(series.DataPoints[j].Value.Data) / total_for_Cat[j]) * 100;

        IPortion port = new Portion();
        port.Text = String.Format("{0:F2} %", dataPontPercent);
        port.PortionFormat.FontHeight = 8f;
        lbl.TextFrameForOverriding.Text = "";
        IParagraph para = lbl.TextFrameForOverriding.Paragraphs[0];
        para.Portions.Add(port);

        lbl.DataLabelFormat.ShowSeriesName = false;
        lbl.DataLabelFormat.ShowPercentage = false;
        lbl.DataLabelFormat.ShowLegendKey = false;
        lbl.DataLabelFormat.ShowCategoryName = false;
        lbl.DataLabelFormat.ShowBubbleSize = false;
    }
}

// Salva a apresentação que contém o gráfico
presentation.Save("DisplayPercentageAsLabels_out.pptx", SaveFormat.Pptx);
```

## **Definir Sinal de Percentual nos Rótulos de Dados do Gráfico**
Este código C# mostra como definir o sinal de percentual para um rótulo de dados de um gráfico:

```c#
// Cria uma instância da classe Presentation
Presentation presentation = new Presentation();

// Obtém a referência de um slide através do seu índice
ISlide slide = presentation.Slides[0];

// Cria o gráfico PercentsStackedColumn em um slide
IChart chart = slide.Shapes.AddChart(ChartType.PercentsStackedColumn, 20, 20, 500, 400);

// Define NumberFormatLinkedToSource como false
chart.Axes.VerticalAxis.IsNumberFormatLinkedToSource = false;
chart.Axes.VerticalAxis.NumberFormat = "0.00%";

chart.ChartData.Series.Clear();
int defaultWorksheetIndex = 0;

// Obtém a planilha de dados do gráfico
IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

// Adiciona nova série
IChartSeries series = chart.ChartData.Series.Add(workbook.GetCell(defaultWorksheetIndex, 0, 1, "Reds"), chart.Type);
series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, 1, 1, 0.30));
series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, 2, 1, 0.50));
series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, 3, 1, 0.80));
series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, 4, 1, 0.65));

// Define a cor de preenchimento da série
series.Format.Fill.FillType = FillType.Solid;
series.Format.Fill.SolidFillColor.Color = Color.Red;

// Define as propriedades de LabelFormat
series.Labels.DefaultDataLabelFormat.ShowValue = true;
series.Labels.DefaultDataLabelFormat.IsNumberFormatLinkedToSource = false;
series.Labels.DefaultDataLabelFormat.NumberFormat = "0.0%";
series.Labels.DefaultDataLabelFormat.TextFormat.PortionFormat.FontHeight = 10;
series.Labels.DefaultDataLabelFormat.TextFormat.PortionFormat.FillFormat.FillType = FillType.Solid;
series.Labels.DefaultDataLabelFormat.TextFormat.PortionFormat.FillFormat.SolidFillColor.Color = Color.White;
series.Labels.DefaultDataLabelFormat.ShowValue = true;

// Adiciona nova série
IChartSeries series2 = chart.ChartData.Series.Add(workbook.GetCell(defaultWorksheetIndex, 0, 2, "Blues"), chart.Type);
series2.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, 1, 2, 0.70));
series2.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, 2, 2, 0.50));
series2.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, 3, 2, 0.20));
series2.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, 4, 2, 0.35));

// Define o tipo de preenchimento e a cor
series2.Format.Fill.FillType = FillType.Solid;
series2.Format.Fill.SolidFillColor.Color = Color.Blue;
series2.Labels.DefaultDataLabelFormat.ShowValue = true;
series2.Labels.DefaultDataLabelFormat.IsNumberFormatLinkedToSource = false;
series2.Labels.DefaultDataLabelFormat.NumberFormat = "0.0%";
series2.Labels.DefaultDataLabelFormat.TextFormat.PortionFormat.FontHeight = 10;
series2.Labels.DefaultDataLabelFormat.TextFormat.PortionFormat.FillFormat.FillType = FillType.Solid;
series2.Labels.DefaultDataLabelFormat.TextFormat.PortionFormat.FillFormat.SolidFillColor.Color = Color.White;

// Salva a apresentação no disco
presentation.Save("SetDataLabelsPercentageSign_out.pptx", SaveFormat.Pptx);
```

## **Definir Distância do Rótulo a partir de um Eixo**
Este código C# mostra como definir a distância do rótulo a partir de um eixo de categoria ao lidar com um gráfico plotado a partir de eixos:

```c#
// Cria uma instância da classe Presentation
Presentation presentation = new Presentation();

// Obtém a referência de um slide
ISlide sld = presentation.Slides[0];

// Cria um gráfico no slide
IChart ch = sld.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 300);

// Define a distância do rótulo a partir de um eixo
ch.Axes.HorizontalAxis.LabelOffset = 500;

// Salva a apresentação no disco
presentation.Save("SetCategoryAxisLabelDistance_out.pptx", SaveFormat.Pptx);
```

## **Ajustar Localização do Rótulo**

Ao criar um gráfico que não depende de nenhum eixo, como um gráfico de pizza, os rótulos de dados do gráfico podem ficar muito próximos da borda. Nesse caso, é necessário ajustar a localização do rótulo de dados para que as linhas de ligação sejam exibidas claramente.

Este código C# mostra como ajustar a localização do rótulo em um gráfico de pizza: 

```c#
using (Presentation pres = new Presentation())
{
    IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Pie, 50, 50, 200, 200);

    IChartSeriesCollection series = chart.ChartData.Series;
    IDataLabel label = series[0].Labels[0];

    label.DataLabelFormat.ShowValue = true;
    label.DataLabelFormat.Position = LegendDataLabelPosition.OutsideEnd;
    label.X = 0.71f;
    label.Y = 0.04f;

    pres.Save("pres.pptx", SaveFormat.Pptx);
}
```

![pie-chart-adjusted-label](pie-chart-adjusted-label.png)

## **Perguntas Frequentes**

**Como posso impedir que os rótulos de dados se sobreponham em gráficos densos?**

Combine posicionamento automático de rótulos, linhas de ligação e redução do tamanho da fonte; se necessário, oculte alguns campos (por exemplo, a categoria) ou exiba rótulos apenas para pontos extremos/chave.

**Como posso desativar rótulos apenas para valores zero, negativos ou vazios?**

Filtre os pontos de dados antes de habilitar os rótulos e desative a exibição para valores 0, valores negativos ou valores ausentes de acordo com uma regra definida.

**Como garantir um estilo de rótulo consistente ao exportar para PDF/imagens?**

Defina explicitamente as fontes (família, tamanho) e verifique se a fonte está disponível no lado da renderização para evitar fallback.