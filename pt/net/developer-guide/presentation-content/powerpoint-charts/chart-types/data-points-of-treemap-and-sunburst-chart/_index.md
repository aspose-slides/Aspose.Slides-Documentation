---
title: Personalizar Pontos de Dados em Gráficos Treemap e Sunburst no .NET
linktitle: Pontos de Dados em Gráficos Treemap e Sunburst
type: docs
url: /pt/net/data-points-of-treemap-and-sunburst-chart/
keywords:
- gráfico treemap
- gráfico sunburst
- ponto de dado
- cor do rótulo
- cor do ramo
- PowerPoint
- apresentação
- .NET
- C#
- Aspose.Slides
description: "Aprenda a gerenciar pontos de dados em gráficos treemap e sunburst com Aspose.Slides para .NET, compatível com formatos do PowerPoint."
---
## **Introdução**

Entre outros tipos de gráficos do PowerPoint, existem dois tipos “hierárquicos” – **Treemap** e **Sunburst** (chart, também conhecido como Gráfico Sunburst, Diagrama Sunburst, Gráfico Radial, Gráfico Radial ou Gráfico de Pizza Multinível). Esses gráficos exibem dados hierárquicos organizados como uma árvore – das folhas até o topo do ramo. As folhas são definidas pelos pontos de dados da série, e cada nível de agrupamento aninhado subsequente é definido pela categoria correspondente. Aspose.Slides for .NET permite formatar pontos de dados de Gráficos Sunburst e Treemap em C#.

Aqui está um Gráfico Sunburst, onde os dados na coluna Series1 definem os nós folha, enquanto as outras colunas definem pontos de dados hierárquicos:

![todo:image_alt_text](https://lh6.googleusercontent.com/TSSU5O7SLOi5NZD9JaubhgGU1QU5tYKc23RQX_cal3tlz5TpOvsgUFLV_rHvruwN06ft1XYgsLhbeEDXzVqdAybPIbpfGy-lwoQf_ydxDwcjAeZHWfw61c4koXezAAlEeCA7x6BZ)

Vamos começar adicionando um novo gráfico Sunburst à apresentação:

```c#
using (Presentation pres = new Presentation())
{
    IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Sunburst, 100, 100, 450, 400);
    // ...
}
```

{{% alert color="primary" title="Veja também" %}} 
- [**Creating Sunburst Chart**](/slides/pt/net/adding-charts/#addingcharts-creatingsunburstchart)
{{% /alert %}}

Se houver necessidade de formatar pontos de dados do gráfico, devemos usar o seguinte:

[**IChartDataPointLevelsManager**](https://reference.aspose.com/slides/pt/net/aspose.slides.charts/IChartDataPointLevelsManager), 
[IChartDataPointLevel](https://reference.aspose.com/slides/pt/net/aspose.slides.charts/ichartdatapointlevel) classes 
e [**IChartDataPoint.DataPointLevels**](https://reference.aspose.com/slides/pt/net/aspose.slides.charts/ichartdatapoint/properties/datapointlevels) property 
fornecem acesso para formatar pontos de dados de Treemap e Sunburst charts. 
[**IChartDataPointLevelsManager**](https://reference.aspose.com/slides/pt/net/aspose.slides.charts/IChartDataPointLevelsManager) 
é usado para acessar categorias de múltiplos níveis – representa o contêiner de 
[**IChartDataPointLevel**](https://reference.aspose.com/slides/pt/net/aspose.slides.charts/IChartDataPointLevel) objects. 
Basicamente é um wrapper para 
[**IChartCategoryLevelsManager**](https://reference.aspose.com/slides/pt/net/aspose.slides.charts/IChartCategoryLevelsManager) com 
as propriedades adicionadas específicas para pontos de dados. 
[**IChartDataPointLevel**](https://reference.aspose.com/slides/pt/net/aspose.slides.charts/IChartDataPointLevel) class tem 
duas propriedades: [**Format**](https://reference.aspose.com/slides/pt/net/aspose.slides.charts/ichartdatapointlevel/properties/format) e 
[**DataLabel**](https://reference.aspose.com/slides/pt/net/aspose.slides.charts/ichartdatapointlevel/properties/label) que 
fornecem acesso às configurações correspondentes.
## **Exibir o Valor de um Ponto de Dados**
Exibir o valor do ponto de dados “Leaf 4”:

```c#
IChartDataPointCollection dataPoints = chart.ChartData.Series[0].DataPoints;
dataPoints[3].DataPointLevels[0].Label.DataLabelFormat.ShowValue = true;
```

![todo:image_alt_text](https://lh6.googleusercontent.com/bKHMf5Bj37ZkMwUE1OfXjw7_CRmDhafhQOUuVWDmitwbtdkwD68ibWluY6Q1HQz_z2Q-BR_SBrBPZ_gID5bGH0PUqI5w37S22RT-ZZal6k7qIDstKntYi5QXS8z-SgpnsI78WGiu)
## **Definir Rótulo e Cor de um Ponto de Dados**
Defina o rótulo de dados “Branch 1” para exibir o nome da série (“Series1”) em vez do nome da categoria. Em seguida, defina a cor do texto como amarelo:

```c#
IDataLabel branch1Label = dataPoints[0].DataPointLevels[2].Label;
branch1Label.DataLabelFormat.ShowCategoryName = false;
branch1Label.DataLabelFormat.ShowSeriesName = true;

branch1Label.DataLabelFormat.TextFormat.PortionFormat.FillFormat.FillType = FillType.Solid;
branch1Label.DataLabelFormat.TextFormat.PortionFormat.FillFormat.SolidFillColor.Color = Color.Yellow;
```

![todo:image_alt_text](https://lh6.googleusercontent.com/I9g0kewJnxkhUVlfSWRN39Ng-wzjWyRwF3yTbOD9HhLTLBt_sMJiEfDe7vOfqRNx89o9AVZsYTW3Vv_TIuj4EgM4_UEEi7zQ3jdvaO8FoG2JcsOqNRgbiE5HQZNz8xx_q9qdj8JQ)
## **Definir a Cor de um Ramo de Ponto de Dados**

Altere a cor do ramo “Stem 4”:

```csharp
using (Presentation pres = new Presentation())
{
    IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Sunburst, 100, 100, 450, 400);
    
    IChartDataPointCollection dataPoints = chart.ChartData.Series[0].DataPoints;

    IChartDataPointLevel stem4branch = dataPoints[9].DataPointLevels[1];
    
    stem4branch.Format.Fill.FillType = FillType.Solid;
    stem4branch.Format.Fill.SolidFillColor.Color = Color.Red;
      
    pres.Save("pres.pptx", SaveFormat.Pptx);
}
```

![todo:image_alt_text](https://lh5.googleusercontent.com/Zll4cpQ5tTDdgwmJ4yuupolfGaANR8SWWTU3XaJav_ZVXVstV1pI1z1OFH-gov6FxPoDz1cxmMyrgjsdYGS24PlhaYa2daKzlNuL1a0xYcqEiyyO23AE6JMOLavWpvqA6SzOCA6_)
## **FAQ**

**Posso mudar a ordem (classificação) dos segmentos em Sunburst/Treemap?**

Não. O PowerPoint classifica os segmentos automaticamente (geralmente por valores descendentes, no sentido horário). O Aspose.Slides reproduz esse comportamento: não é possível mudar a ordem diretamente; você deve fazê‑lo pré‑processando os dados.

**Como o tema da apresentação afeta as cores dos segmentos e rótulos?**

As cores do gráfico herdam o [theme/palette](/slides/pt/net/presentation-theme/) da apresentação, a menos que você defina preenchimentos ou fontes explicitamente. Para resultados consistentes, fixe preenchimentos sólidos e formatação de texto nos níveis necessários.

**A exportação para PDF/PNG preserva cores de ramos e configurações de rótulos personalizados?**

Sim. Ao exportar a apresentação, as configurações do gráfico (preenchimentos, rótulos) são preservadas nos formatos de saída porque o Aspose.Slides renderiza com a formatação do gráfico aplicada.

**Posso calcular as coordenadas reais de um rótulo/elemento para posicionamento personalizado sobre o gráfico?**

Sim. Depois que o layout do gráfico é validado, `ActualX`/`ActualY` estão disponíveis para os elementos (por exemplo, um [DataLabel](https://reference.aspose.com/slides/pt/net/aspose.slides.charts/datalabel/)), o que ajuda no posicionamento preciso de sobreposições.