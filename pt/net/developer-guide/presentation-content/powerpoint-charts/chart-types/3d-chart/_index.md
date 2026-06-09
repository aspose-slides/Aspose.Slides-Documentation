---
title: Personalizar gráficos 3D em apresentações no .NET
linktitle: Gráfico 3D
type: docs
url: /pt/net/3d-chart/
keywords:
- gráfico 3D
- rotação
- profundidade
- PowerPoint
- apresentação
- .NET
- C#
- Aspose.Slides
description: "Aprenda como criar e personalizar gráficos 3D no Aspose.Slides para .NET, com suporte a arquivos PPT e PPTX — impulsione suas apresentações hoje."
---
## **Visão geral**

Este artigo explica como personalizar um gráfico 3D no Aspose.Slides configurando as definições `Rotation3D` como `RotationX`, `RotationY`, `DepthPercents` e `RightAngleAxes`. Ele mostra como criar uma apresentação, adicionar um gráfico 3D com dados padrão, aplicar as configurações de visualização 3D necessárias e salvar a apresentação modificada como um arquivo PPTX.

## **Definir as propriedades RotationX, RotationY e DepthPercents de um gráfico 3D**
Aspose.Slides for .NET fornece uma API simples para definir essas propriedades. O artigo a seguir ajudará você a definir diferentes propriedades como rotação X, Y, **DepthPercents** etc. O código de exemplo aplica a configuração das propriedades mencionadas.

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/net/aspose.slides/presentation).
2. Acesse o primeiro slide.
3. Adicione um gráfico com dados padrão.
4. Defina as propriedades Rotation3D.
5. Grave a apresentação modificada em um arquivo PPTX.

```c#
// Crie uma instância da classe Presentation
Presentation presentation = new Presentation();
           
// Acesse o primeiro slide
ISlide slide = presentation.Slides[0];

// Adicione um gráfico com dados padrão
IChart chart = slide.Shapes.AddChart(ChartType.StackedColumn3D, 0, 0, 500, 500);

// Defina o índice da planilha de dados do gráfico
int defaultWorksheetIndex = 0;

// Obtenha a planilha de dados do gráfico
IChartDataWorkbook fact = chart.ChartData.ChartDataWorkbook;

// Adicione séries
chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 0, 1, "Series 1"), chart.Type);
chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 0, 2, "Series 2"), chart.Type);

// Adicione categorias
chart.ChartData.Categories.Add(fact.GetCell(defaultWorksheetIndex, 1, 0, "Caetegoty 1"));
chart.ChartData.Categories.Add(fact.GetCell(defaultWorksheetIndex, 2, 0, "Caetegoty 2"));
chart.ChartData.Categories.Add(fact.GetCell(defaultWorksheetIndex, 3, 0, "Caetegoty 3"));

// Defina as propriedades Rotation3D
chart.Rotation3D.RightAngleAxes = true;
chart.Rotation3D.RotationX = 40;
chart.Rotation3D.RotationY = 270;
chart.Rotation3D.DepthPercents = 150;

// Obtenha a segunda série do gráfico
IChartSeries series = chart.ChartData.Series[1];

// Agora preenchendo os dados da série
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 1, 1, 20));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 2, 1, 50));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 3, 1, 30));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 1, 2, 30));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 2, 2, 10));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 3, 2, 60));

// Defina o valor OverLap
series.ParentSeriesGroup.Overlap = 100;         

// Salve a apresentação no disco
presentation.Save("Rotation3D_out.pptx", SaveFormat.Pptx);
```

## **Perguntas frequentes**

**Quais tipos de gráfico suportam o modo 3D no Aspose.Slides?**

Aspose.Slides suporta variantes 3D de gráficos de coluna, incluindo Column 3D, Clustered Column 3D, Stacked Column 3D e 100% Stacked Column 3D, juntamente com tipos 3D relacionados expostos através da enumeração [ChartType](https://reference.aspose.com/slides/pt/net/aspose.slides.charts/charttype/). Para obter uma lista exata e atualizada, verifique os membros de [ChartType](https://reference.aspose.com/slides/pt/net/aspose.slides.charts/charttype/) na referência da API da sua versão instalada.

**Posso obter uma imagem raster de um gráfico 3D para um relatório ou a web?**

Sim. Você pode exportar um gráfico para uma imagem via a [chart API](https://reference.aspose.com/slides/pt/net/aspose.slides/shape/getimage/) ou [renderizar o slide inteiro](/slides/pt/net/convert-powerpoint-to-png/) para formatos como PNG ou JPEG. Isso é útil quando você precisa de uma visualização pixel-perfeita ou deseja incorporar o gráfico em documentos, painéis ou páginas da web sem precisar do PowerPoint.

**Quão eficiente é a criação e renderização de gráficos 3D grandes?**

O desempenho depende do volume de dados e da complexidade visual. Para obter os melhores resultados, mantenha os efeitos 3D ao mínimo, evite texturas pesadas nas paredes e áreas de plotagem, limite o número de pontos de dados por série quando possível e renderize para uma saída de tamanho adequado (resolução e dimensões) para corresponder à exibição ou às necessidades de impressão do alvo.