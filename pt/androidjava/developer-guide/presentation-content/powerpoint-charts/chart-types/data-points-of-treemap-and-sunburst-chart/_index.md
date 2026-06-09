---
title: Personalizar Pontos de Dados em Gráficos Treemap e Sunburst no Android
linktitle: Pontos de Dados em Gráficos Treemap e Sunburst
type: docs
url: /pt/androidjava/data-points-of-treemap-and-sunburst-chart/
weight: 40
keywords:
- gráfico treemap
- gráfico sunburst
- ponto de dado
- cor do rótulo
- cor do ramo
- PowerPoint
- apresentação
- Android
- Java
- Aspose.Slides
description: "Aprenda como gerenciar pontos de dados em gráficos treemap e sunburst com Aspose.Slides para Android via Java, compatível com formatos PowerPoint."
---
## **Introdução**

Entre outros tipos de gráficos do PowerPoint, existem dois tipos “hierárquicos” – **Treemap** e **Sunburst** (chart (também conhecido como Sunburst Graph, Sunburst Diagram, Gráfico Radial, Gráfico Radial ou Gráfico de Pizza de Níveis Múltiplos)). Esses gráficos exibem dados hierárquicos organizados como uma árvore – das folhas até o topo do ramo. As folhas são definidas pelos pontos de dados da série, e cada nível de agrupamento aninhado subsequente é definido pela categoria correspondente. Aspose.Slides for Android via Java permite formatar pontos de dados dos gráficos Sunburst e Treemap em Java.

Aqui está um gráfico Sunburst, onde os dados na coluna Series1 definem os nós folha, enquanto as outras colunas definem pontos de dados hierárquicos:

![todo:image_alt_text](https://lh6.googleusercontent.com/TSSU5O7SLOi5NZD9JaubhgGU1QU5tYKc23RQX_cal3tlz5TpOvsgUFLV_rHvruwN06ft1XYgsLhbeEDXzVqdAybPIbpfGy-lwoQf_ydxDwcjAeZHWfw61c4koXezAAlEeCA7x6BZ)

Vamos começar adicionando um novo gráfico Sunburst à apresentação:

```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Sunburst, 100, 100, 450, 400);

    // ...
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert color="primary" title="Veja também" %}} 
- [**Create or Update PowerPoint Presentation Charts on Android**](/slides/pt/androidjava/create-chart/)
{{% /alert %}}

Se houver necessidade de formatar os pontos de dados do gráfico, devemos usar o seguinte:

[**IChartDataPointLevelsManager**](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/IChartDataPointLevelsManager), [**IChartDataPointLevel**](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/IChartDataPointLevel) classes e o método [**IChartDataPoint.getDataPointLevels**](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/IChartDataPoint#getDataPointLevels--) fornecem acesso para formatar os pontos de dados dos gráficos Treemap e Sunburst. [**IChartDataPointLevelsManager**](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/IChartDataPointLevelsManager) é usado para acessar categorias de múltiplos níveis – ele representa o contêiner de objetos [**IChartDataPointLevel**](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/IChartDataPointLevel). Basicamente, ele é um wrapper para [**IChartCategoryLevelsManager**](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/IChartCategoryLevelsManager) com propriedades adicionadas específicas para pontos de dados. A classe [**IChartDataPointLevel**](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/IChartDataPointLevel) possui dois métodos: [**getFormat**](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/IChartDataPointLevel#getFormat--) e [**getDataLabel**](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/IChartDataPointLevel#getLabel--) que fornecem acesso às configurações correspondentes.

## **Mostrar o Valor de um Ponto de Dados**

Mostrar o valor do ponto de dados "Leaf 4":

```java
IChartDataPointCollection dataPoints = chart.getChartData().getSeries().get_Item(0).getDataPoints();
dataPoints.get_Item(3).getDataPointLevels().get_Item(0).getLabel().getDataLabelFormat().setShowValue(true);
```

![todo:image_alt_text](https://lh6.googleusercontent.com/bKHMf5Bj37ZkMwUE1OfXjw7_CRmDhafhQOUuVWDmitwbtdkwD68ibWluY6Q1HQz_z2Q-BR_SBrBPZ_gID5bGH0PUqI5w37S22RT-ZZal6k7qIDstKntYi5QXS8z-SgpnsI78WGiu)

## **Definir Rótulo e Cor de um Ponto de Dados**

Defina o rótulo de dados de "Branch 1" para exibir o nome da série ("Series1") em vez do nome da categoria. Em seguida, defina a cor do texto para amarelo:

```java
IDataLabel branch1Label = dataPoints.get_Item(0).getDataPointLevels().get_Item(0).getLabel();
branch1Label.getDataLabelFormat().setShowCategoryName(false);
branch1Label.getDataLabelFormat().setShowSeriesName(true);

branch1Label.getDataLabelFormat().getTextFormat().getPortionFormat().getFillFormat().setFillType(FillType.Solid);
branch1Label.getDataLabelFormat().getTextFormat().getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.YELLOW);
```

![todo:image_alt_text](https://lh6.googleusercontent.com/I9g0kewJnxkhUVlfSWRN39Ng-wzjWyRwF3yTbOD9HhLTLBt_sMJiEfDe7vOfqRNx89o9AVZsYTW3Vv_TIuj4EgM4_UEEi7zQ3jdvaO8FoG2JcsOqNRgbiE5HQZNz8xx_q9qdj8JQ)

## **Definir a Cor do Ramo do Ponto de Dados**

Alterar a cor do ramo "Steam 4":

```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Sunburst, 100, 100, 450, 400);

    IChartDataPointCollection dataPoints = chart.getChartData().getSeries().get_Item(0).getDataPoints();

    IChartDataPointLevel stem4branch = dataPoints.get_Item(9).getDataPointLevels().get_Item(1);

    stem4branch.getFormat().getFill().setFillType(FillType.Solid);
    stem4branch.getFormat().getFill().getSolidFillColor().setColor(Color.RED);

    pres.save("pres.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

![todo:image_alt_text](https://lh5.googleusercontent.com/Zll4cpQ5tTDdgwmJ4yuupolfGaANR8SWWTU3XaJav_ZVXVstV1pI1z1OFH-gov6FxPoDz1cxmMyrgjsdYGS24PlhaYa2daKzlNuL1a0xYcqEiyyO23AE6JMOLavWpvqA6SzOCA6_)

## **FAQ**

**Posso alterar a ordem (classificação) dos segmentos em Sunburst/Treemap?**

Não. O PowerPoint ordena os segmentos automaticamente (geralmente por valores decrescentes, no sentido horário). O Aspose.Slides reproduz esse comportamento: não é possível alterar a ordem diretamente; você deve fazê-lo pré‑processando os dados.

**Como o tema da apresentação afeta as cores dos segmentos e rótulos?**

As cores dos gráficos herdam o [tema/paleta](/slides/pt/androidjava/presentation-theme/) da apresentação, a menos que você defina explicitamente preenchimentos ou fontes. Para resultados consistentes, fixe preenchimentos sólidos e formatação de texto nos níveis necessários.

**A exportação para PDF/PNG preserva cores de ramo personalizadas e configurações de rótulo?**

Sim. Ao exportar a apresentação, as configurações do gráfico (preenchimentos, rótulos) são preservadas nos formatos de saída, pois o Aspose.Slides renderiza com a formatação do gráfico aplicada.

**Posso calcular as coordenadas reais de um rótulo/elemento para posicionamento de sobreposição personalizada sobre o gráfico?**

Sim. Após a disposição do gráfico ser validada, os valores reais de *x* e *y* ficam disponíveis para os elementos (por exemplo, um [DataLabel](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/datalabel/)), o que auxilia no posicionamento preciso de sobreposições.