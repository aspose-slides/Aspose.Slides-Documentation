---
title: Personalizar gráficos de pizza em apresentações no .NET
linktitle: Gráfico de Pizza
type: docs
url: /pt/net/pie-chart/
keywords:
- gráfico de pizza
- gerenciar gráfico
- personalizar gráfico
- opções de gráfico
- configurações de gráfico
- opções de plotagem
- cor da fatia
- PowerPoint
- apresentação
- .NET
- C#
- Aspose.Slides
description: "Aprenda como criar e personalizar gráficos de pizza no .NET com Aspose.Slides, exportáveis para PowerPoint, impulsionando sua narrativa de dados em segundos."
---
## **Visão geral**

Este artigo explica como trabalhar com gráficos de pizza no Aspose.Slides. Ele mostra como configurar opções de plotagem secundária para gráficos Pie of Pie e Bar of Pie, e como habilitar a coloração automática de fatias para um gráfico de pizza padrão.

Os exemplos focam em etapas práticas de personalização de gráficos, como adicionar um gráfico a um slide, ajustar configurações de séries e rótulos, substituir os dados padrão do gráfico por categorias e valores personalizados e salvar a apresentação atualizada.

## **Opções de segundo plot para gráficos Pie of Pie e Bar of Pie**
Aspose.Slides for .NET agora oferece suporte a opções de segundo plot para gráficos Pie of Pie ou Bar of Pie. Neste tópico, veremos com um exemplo como especificar essas opções usando Aspose.Slides. Para especificar as propriedades, siga os passos abaixo:

1. Instanciar o objeto da classe [Presentation](https://reference.aspose.com/slides/pt/net/aspose.slides/presentation).
1. Adicionar gráfico ao slide.
1. Especificar as opções de segundo plot do gráfico.
1. Gravar a apresentação no disco.

No exemplo abaixo, definimos diferentes propriedades do gráfico Pie of Pie.

```c#
// Criar uma instância da classe Presentation
Presentation presentation = new Presentation();

// Adicionar gráfico ao slide
IChart chart = presentation.Slides[0].Shapes.AddChart(ChartType.PieOfPie, 50, 50, 500, 400);
     
// Definir propriedades diferentes
chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowValue = true;
chart.ChartData.Series[0].ParentSeriesGroup.SecondPieSize = 149;
chart.ChartData.Series[0].ParentSeriesGroup.PieSplitBy = Aspose.Slides.Charts.PieSplitType.ByPercentage;
chart.ChartData.Series[0].ParentSeriesGroup.PieSplitPosition = 53;

// Gravar a apresentação no disco
presentation.Save("SecondPlotOptionsforCharts_out.pptx", SaveFormat.Pptx);
```




## **Definir cores automáticas das fatias do gráfico de pizza**
Aspose.Slides for .NET oferece uma API simples para definir cores automáticas das fatias do gráfico de pizza. O código de exemplo aplica as configurações mencionadas acima.

1. Criar uma instância da classe Presentation.
1. Acessar o primeiro slide.
1. Adicionar gráfico com dados padrão.
1. Definir o título do gráfico.
1. Configurar a primeira série para Mostrar Valores.
1. Definir o índice da planilha de dados do gráfico.
1. Obter a planilha de dados do gráfico.
1. Excluir as séries e categorias geradas por padrão.
1. Adicionar novas categorias.
1. Adicionar nova série.

Gravar a apresentação modificada em um arquivo PPTX.

```c#
// Instanciar a classe Presentation que representa o arquivo PPTX
using (Presentation presentation = new Presentation())
{
	// Instanciar a classe Presentation que representa o arquivo PPTX
	Presentation presentation = new Presentation();

	// Acessar o primeiro slide
	ISlide slides = presentation.Slides[0];

	// Adicionar gráfico com dados padrão
	IChart chart = slides.Shapes.AddChart(ChartType.Pie, 100, 100, 400, 400);

	// Definir Título do gráfico
	chart.ChartTitle.AddTextFrameForOverriding("Sample Title");
	chart.ChartTitle.TextFrameForOverriding.TextFrameFormat.CenterText = NullableBool.True;
	chart.ChartTitle.Height = 20;
	chart.HasTitle = true;

	// Definir a primeira série para Mostrar Valores
	chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowValue = true;

	// Definir o índice da planilha de dados do gráfico
	int defaultWorksheetIndex = 0;

	// Obter a planilha de dados do gráfico
	IChartDataWorkbook fact = chart.ChartData.ChartDataWorkbook;

	// Excluir as séries e categorias geradas por padrão
	chart.ChartData.Series.Clear();
	chart.ChartData.Categories.Clear();

	// Adicionar novas categorias
	chart.ChartData.Categories.Add(fact.GetCell(0, 1, 0, "First Qtr"));
	chart.ChartData.Categories.Add(fact.GetCell(0, 2, 0, "2nd Qtr"));
	chart.ChartData.Categories.Add(fact.GetCell(0, 3, 0, "3rd Qtr"));

	// Adicionar nova série
	IChartSeries series = chart.ChartData.Series.Add(fact.GetCell(0, 0, 1, "Series 1"), chart.Type);

	// Agora preenchendo os dados da série
	series.DataPoints.AddDataPointForPieSeries(fact.GetCell(defaultWorksheetIndex, 1, 1, 20));
	series.DataPoints.AddDataPointForPieSeries(fact.GetCell(defaultWorksheetIndex, 2, 1, 50));
	series.DataPoints.AddDataPointForPieSeries(fact.GetCell(defaultWorksheetIndex, 3, 1, 30));

	series.ParentSeriesGroup.IsColorVaried = true;
	presentation.Save("C:\\Aspose Data\\Pie.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```

## **FAQ**

**As variações 'Pie of Pie' e 'Bar of Pie' são suportadas?**

Sim, a biblioteca [suporta](https://reference.aspose.com/slides/pt/net/aspose.slides.charts/charttype/) um plot secundário para gráficos de pizza, incluindo os tipos 'Pie of Pie' e 'Bar of Pie'.

**Posso exportar apenas o gráfico como imagem (por exemplo, PNG)?**

Sim, você pode [exportar o próprio gráfico como imagem](https://reference.aspose.com/slides/pt/net/aspose.slides/shape/getimage/) (por exemplo, PNG) sem a necessidade da apresentação completa.