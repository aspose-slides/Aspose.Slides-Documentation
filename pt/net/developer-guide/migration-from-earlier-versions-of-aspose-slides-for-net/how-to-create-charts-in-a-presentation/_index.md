---
title: Como Criar Gráficos em Apresentações em .NET
linktitle: Criar Gráfico
type: docs
weight: 30
url: /pt/net/how-to-create-charts-in-a-presentation/
keywords:
- migração
- criar gráfico
- código legado
- código moderno
- abordagem legada
- abordagem moderna
- PowerPoint
- OpenDocument
- apresentação
- .NET
- C#
- Aspose.Slides
description: "Aprenda como criar gráficos em apresentações PowerPoint PPT, PPTX e ODP em .NET com Aspose.Slides usando tanto APIs de gráficos legadas quanto modernas."
---
{{% alert color="primary" %}}

Uma nova [Aspose.Slides for .NET API](/slides/pt/net/) foi lançada e agora este único produto oferece a capacidade de gerar documentos PowerPoint do zero e editar os existentes.

{{% /alert %}}
## **Suporte para Código Legado**
Para usar o código legado desenvolvido com Aspose.Slides for .NET em versões anteriores à 13.x, você precisa fazer algumas pequenas alterações no seu código e ele funcionará como antes. Todas as classes que estavam presentes no antigo Aspose.Slides for .NET nos namespaces Aspose.Slide e Aspose.Slides.Pptx agora foram combinadas em um único namespace Aspose.Slides. Confira o trecho de código simples a seguir para criar um gráfico normal do zero em uma apresentação usando a API legada do Aspose.Slides e siga os passos que descrevem como migrar para a nova API unificada.
## **Abordagem Legada do Aspose.Slides for .NET**
```c#
	//Instanciar a classe PresentationEx que representa um arquivo PPTX
	using (PresentationEx pres = new PresentationEx())
	{
		//Acessar o primeiro slide
		SlideEx sld = pres.Slides[0];

		// Add gráfico com dados padrão
		ChartEx chart = sld.Shapes.AddChart(ChartTypeEx.ClusteredColumn, 0, 0, 500, 500);

		//Definir o título do gráfico
		chart.ChartTitle.Text.Text = "Sample Title";
		chart.ChartTitle.Text.CenterText = true;
		chart.ChartTitle.Height = 20;
		chart.HasTitle = true;

		//Definir a primeira série para mostrar valores
		chart.ChartData.Series[0].Labels.ShowValue = true;

		//Definir o índice da planilha de dados do gráfico 
		int defaultWorksheetIndex = 0;

		//Obter a planilha de dados do gráfico
		ChartDataCellFactory fact = chart.ChartData.ChartDataCellFactory;

		//Excluir séries e categorias geradas por padrão
		chart.ChartData.Series.Clear();
		chart.ChartData.Categories.Clear();
		int s = chart.ChartData.Series.Count;
		s = chart.ChartData.Categories.Count;

		//Adicionar novas séries
		chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 0, 1, "Series 1"), chart.Type);
		chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 0, 2, "Series 2"), chart.Type);

		//Adicionar novas categorias
		chart.ChartData.Categories.Add(fact.GetCell(defaultWorksheetIndex, 1, 0, "Caetegoty 1"));
		chart.ChartData.Categories.Add(fact.GetCell(defaultWorksheetIndex, 2, 0, "Caetegoty 2"));
		chart.ChartData.Categories.Add(fact.GetCell(defaultWorksheetIndex, 3, 0, "Caetegoty 3"));

		//Obter a primeira série do gráfico
		ChartSeriesEx series = chart.ChartData.Series[0];

		//Agora preenchendo os dados da série
		series.Values.Add(fact.GetCell(defaultWorksheetIndex, 1, 1, 20));
		series.Values.Add(fact.GetCell(defaultWorksheetIndex, 2, 1, 50));
		series.Values.Add(fact.GetCell(defaultWorksheetIndex, 3, 1, 30));

		//Definir a cor de preenchimento para a série
		series.Format.Fill.FillType = FillTypeEx.Solid;
		series.Format.Fill.SolidFillColor.Color = Color.Red;


		//Obter a segunda série do gráfico
		series = chart.ChartData.Series[1];

		//Agora preenchendo os dados da série
		series.Values.Add(fact.GetCell(defaultWorksheetIndex, 1, 2, 30));
		series.Values.Add(fact.GetCell(defaultWorksheetIndex, 2, 2, 10));
		series.Values.Add(fact.GetCell(defaultWorksheetIndex, 3, 2, 60));

		//Definir a cor de preenchimento para a série
		series.Format.Fill.FillType = FillTypeEx.Solid;
		series.Format.Fill.SolidFillColor.Color = Color.Green;


		//Criar rótulos personalizados para cada categoria para a nova série

		//primeiro rótulo exibirá o nome da Categoria
		DataLabelEx lbl = new DataLabelEx(series);
		lbl.ShowCategoryName = true;
		lbl.Id = 0;
		series.Labels.Add(lbl);

		//Exibir nome da série para o segundo rótulo
		lbl = new DataLabelEx(series);
		lbl.ShowSeriesName = true;
		lbl.Id = 1;
		series.Labels.Add(lbl);

		//Exibir valor para o terceiro rótulo
		lbl = new DataLabelEx(series);
		lbl.ShowValue = true;
		lbl.ShowSeriesName = true;
		lbl.Separator = "/";
		lbl.Id = 2;
		series.Labels.Add(lbl);

		//Exibir valor e texto personalizado
		lbl = new DataLabelEx(series);
		lbl.TextFrame.Text = "My text";
		lbl.Id = 3;
		series.Labels.Add(lbl);

		//Salvar apresentação com o gráfico
		pres.Write(@"D:\AsposeChart.pptx");
	}
```



## **Nova Abordagem Aspose.Slides for .NET 13.x**
``` csharp
//Instanciar a classe Presentation que representa um arquivo PPTX//Instanciar a classe Presentation que representa um arquivo PPTX
Presentation pres = new Presentation();

//Acessar o primeiro slide
ISlide sld = pres.Slides[0];

// Adicionar gráfico com dados padrão
IChart chart = sld.Shapes.AddChart(ChartType.ClusteredColumn, 0, 0, 500, 500);

//Definir título do gráfico
//chart.ChartTitle.TextFrameForOverriding.Text = "Sample Title";
chart.ChartTitle.AddTextFrameForOverriding("Sample Title");
chart.ChartTitle.TextFrameForOverriding.TextFrameFormat.CenterText = NullableBool.True;
chart.ChartTitle.Height = 20;
chart.HasTitle = true;

//Definir a primeira série para mostrar valores
chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowValue = true;

//Definir o índice da planilha de dados do gráfico
int defaultWorksheetIndex = 0;

//Obter a planilha de dados do gráfico
IChartDataWorkbook fact = chart.ChartData.ChartDataWorkbook;

//Excluir séries e categorias geradas por padrão
chart.ChartData.Series.Clear();
chart.ChartData.Categories.Clear();
int s = chart.ChartData.Series.Count;
s = chart.ChartData.Categories.Count;

//Adicionar novas séries
chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 0, 1, "Series 1"), chart.Type);
chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 0, 2, "Series 2"), chart.Type);

//Adicionar novas categorias
chart.ChartData.Categories.Add(fact.GetCell(defaultWorksheetIndex, 1, 0, "Caetegoty 1"));
chart.ChartData.Categories.Add(fact.GetCell(defaultWorksheetIndex, 2, 0, "Caetegoty 2"));
chart.ChartData.Categories.Add(fact.GetCell(defaultWorksheetIndex, 3, 0, "Caetegoty 3"));

//Obter a primeira série do gráfico
IChartSeries series = chart.ChartData.Series[0];

//Agora preenchendo os dados da série

series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 1, 1, 20));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 2, 1, 50));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 3, 1, 30));

//Definir cor de preenchimento para a série
series.Format.Fill.FillType = FillType.Solid;
series.Format.Fill.SolidFillColor.Color = Color.Red;


//Obter a segunda série do gráfico
series = chart.ChartData.Series[1];

//Agora preenchendo os dados da série
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 1, 2, 30));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 2, 2, 10));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 3, 2, 60));

//Definir cor de preenchimento para a série
series.Format.Fill.FillType = FillType.Solid;
series.Format.Fill.SolidFillColor.Color = Color.Green;


//Criar rótulos personalizados para cada categoria para a nova série

//primeiro rótulo exibirá o nome da Categoria
IDataLabel lbl = series.DataPoints[0].Label;
lbl.DataLabelFormat.ShowCategoryName = true;

lbl = series.DataPoints[1].Label;
lbl.DataLabelFormat.ShowSeriesName = true;

//Exibir valor para o terceiro rótulo
lbl = series.DataPoints[2].Label;
lbl.DataLabelFormat.ShowValue = true;
lbl.DataLabelFormat.ShowSeriesName = true;
lbl.DataLabelFormat.Separator = "/";

//Salvar apresentação com o gráfico
pres.Save("AsposeChart.pptx", SaveFormat.Pptx);
```

Confira o trecho de código simples a seguir para criar um gráfico de dispersão do zero em uma apresentação usando a API legada do Aspose.Slides e como obtê‑lo com a nova API unificada.

## **Abordagem Legada do Aspose.Slides for .NET**
```c#
using (PresentationEx pres = new PresentationEx())
{
    SlideEx slide = pres.Slides[0];

    //Criando o gráfico padrão
    ChartEx chart = slide.Shapes.AddChart(ChartTypeEx.ScatterWithSmoothLines, 0, 0, 400, 400);

    //Obtendo o índice da planilha de dados padrão do gráfico
    int defaultWorksheetIndex = 0;

    //Acessando a planilha de dados do gráfico
    ChartDataCellFactory fact = chart.ChartData.ChartDataCellFactory;

    //Excluir séries de demonstração
    chart.ChartData.Series.Clear();

    //Adicionar novas séries
    chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 1, 1, "Series 1"), chart.Type);
    chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 1, 3, "Series 2"), chart.Type);

    //Obter a primeira série do gráfico
    ChartSeriesEx series = chart.ChartData.Series[0];

    //Adicionar novo ponto (1:3) aqui.
    series.XValues.Add(fact.GetCell(defaultWorksheetIndex, 2, 1, 1));
    series.YValues.Add(fact.GetCell(defaultWorksheetIndex, 2, 2, 3));

    //Adicionar novo ponto (2:10)
    series.XValues.Add(fact.GetCell(defaultWorksheetIndex, 3, 1, 2));
    series.YValues.Add(fact.GetCell(defaultWorksheetIndex, 3, 2, 10));

    //Editar o tipo da série
    series.Type = ChartTypeEx.ScatterWithStraightLinesAndMarkers;

    //Alterando o marcador da série do gráfico
    series.MarkerSize = 10;
    series.MarkerSymbol = MarkerStyleTypeEx.Star;

    //Obter a segunda série do gráfico
    series = chart.ChartData.Series[1];

    //Adicionar novo ponto (5:2) aqui.
    series.XValues.Add(fact.GetCell(defaultWorksheetIndex, 2, 3, 5));
    series.YValues.Add(fact.GetCell(defaultWorksheetIndex, 2, 4, 2));

    //Adicionar novo ponto (3:1)
    series.XValues.Add(fact.GetCell(defaultWorksheetIndex, 3, 3, 3));
    series.YValues.Add(fact.GetCell(defaultWorksheetIndex, 3, 4, 1));

    //Adicionar novo ponto (2:2)
    series.XValues.Add(fact.GetCell(defaultWorksheetIndex, 4, 3, 2));
    series.YValues.Add(fact.GetCell(defaultWorksheetIndex, 4, 4, 2));

    //Adicionar novo ponto (5:1)
    series.XValues.Add(fact.GetCell(defaultWorksheetIndex, 5, 3, 5));
    series.YValues.Add(fact.GetCell(defaultWorksheetIndex, 5, 4, 1));

    //Alterando o marcador da série do gráfico
    series.MarkerSize = 10;
    series.MarkerSymbol = MarkerStyleTypeEx.Circle;

    pres.Write("D:\\AsposeSeriesChart.pptx");
}
```


## **Nova Abordagem Aspose.Slides for .NET 13.x**
``` csharp
Presentation pres = new Presentation();

ISlide slide = pres.Slides[0];

//Criando o gráfico padrão
IChart chart = slide.Shapes.AddChart(ChartType.ScatterWithSmoothLines, 0, 0, 400, 400);

//Obtendo o índice da planilha de dados padrão do gráfico
int defaultWorksheetIndex = 0;

//Acessando a planilha de dados do gráfico
IChartDataWorkbook fact = chart.ChartData.ChartDataWorkbook;

//Excluir séries de demonstração
chart.ChartData.Series.Clear();

//Adicionar novas séries
chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 1, 1, "Series 1"), chart.Type);
chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 1, 3, "Series 2"), chart.Type);

//Obter a primeira série do gráfico
IChartSeries series = chart.ChartData.Series[0];

//Adicionar novo ponto (1:3) aqui.
series.DataPoints.AddDataPointForScatterSeries(fact.GetCell(defaultWorksheetIndex, 2, 1, 1), fact.GetCell(defaultWorksheetIndex, 2, 2, 3));

//Adicionar novo ponto (2:10)
series.DataPoints.AddDataPointForScatterSeries(fact.GetCell(defaultWorksheetIndex, 3, 1, 2), fact.GetCell(defaultWorksheetIndex, 3, 2, 10));

//Editar o tipo da série
series.Type = ChartType.ScatterWithStraightLinesAndMarkers;

//Alterando o marcador da série do gráfico
series.Marker.Size = 10;
series.Marker.Symbol = MarkerStyleType.Star;

//Obter a segunda série do gráfico
series = chart.ChartData.Series[1];

//Adicionar novo ponto (5:2) aqui.
series.DataPoints.AddDataPointForScatterSeries(fact.GetCell(defaultWorksheetIndex, 2, 3, 5), fact.GetCell(defaultWorksheetIndex, 2, 4, 2));

//Adicionar novo ponto (3:1)
series.DataPoints.AddDataPointForScatterSeries(fact.GetCell(defaultWorksheetIndex, 3, 3, 3), fact.GetCell(defaultWorksheetIndex, 3, 4, 1));

//Adicionar novo ponto (2:2)
series.DataPoints.AddDataPointForScatterSeries(fact.GetCell(defaultWorksheetIndex, 4, 3, 2), fact.GetCell(defaultWorksheetIndex, 4, 4, 2));

//Adicionar novo ponto (5:1)
series.DataPoints.AddDataPointForScatterSeries(fact.GetCell(defaultWorksheetIndex, 5, 3, 5), fact.GetCell(defaultWorksheetIndex, 5, 4, 1));

//Alterando o marcador da série do gráfico
series.Marker.Size = 10;
series.Marker.Symbol = MarkerStyleType.Circle;

pres.Save("AsposeScatterChart.pptx", SaveFormat.Pptx);
```