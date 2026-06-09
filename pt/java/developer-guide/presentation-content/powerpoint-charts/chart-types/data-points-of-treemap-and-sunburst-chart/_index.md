---
title: Personalizar Pontos de Dados em Gráficos Treemap e Sunburst Usando Java
linktitle: Pontos de Dados em Gráficos Treemap e Sunburst
type: docs
url: /pt/java/data-points-of-treemap-and-sunburst-chart/
weight: 40
keywords:
- gráfico treemap
- gráfico sunburst
- ponto de dado
- cor do rótulo
- cor do ramo
- PowerPoint
- apresentação
- Java
- Aspose.Slides
description: "Saiba como gerenciar pontos de dados em gráficos treemap e sunburst com Aspose.Slides para Java, compatível com formatos PowerPoint."
---
## **Introdução**

Entre outros tipos de gráficos do PowerPoint, existem dois tipos “hierárquicos” – **Treemap** e **Sunburst** (chart, também conhecido como Sunburst Graph, Sunburst Diagram, Radial Chart, Radial Graph ou Multi Level Pie Chart). Esses gráficos exibem dados hierárquicos organizados como uma árvore – das folhas até o topo do ramo. As folhas são definidas pelos pontos de dados da série, e cada nível de agrupamento subsequente aninhado é definido pela categoria correspondente. Aspose.Slides for Java permite formatar os pontos de dados do Sunburst Chart e do Treemap em Java.

Aqui está um Sunburst Chart, onde os dados na coluna Series1 definem os nós folha, enquanto as demais colunas definem pontos de dados hierárquicos:

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

{{% alert color="primary" title="See also" %}} 
- [**Create or Update PowerPoint Presentation Charts in Java**](/slides/pt/java/create-chart/)
{{% /alert %}}

Se houver necessidade de formatar os pontos de dados do gráfico, devemos usar o seguinte:

[**IChartDataPointLevelsManager**](https://reference.aspose.com/slides/pt/java/com.aspose.slides/IChartDataPointLevelsManager), 
[IChartDataPointLevel](https://reference.aspose.com/slides/pt/java/com.aspose.slides/IChartDataPointLevel) classes 
e [**IChartDataPoint.getDataPointLevels**](https://reference.aspose.com/slides/pt/java/com.aspose.slides/IChartDataPoint#getDataPointLevels--) method 
fornecem acesso para formatar os pontos de dados dos gráficos Treemap e Sunburst. 
[**IChartDataPointLevelsManager**](https://reference.aspose.com/slides/pt/java/com.aspose.slides/IChartDataPointLevelsManager) 
é usado para acessar categorias de múltiplos níveis – representa o contêiner de 
[**IChartDataPointLevel**](https://reference.aspose.com/slides/pt/java/com.aspose.slides/IChartDataPointLevel) objetos. 
Basicamente é um wrapper para 
[**IChartCategoryLevelsManager**](https://reference.aspose.com/slides/pt/java/com.aspose.slides/IChartCategoryLevelsManager) com 
as propriedades adicionadas específicas para pontos de dados. 
A classe [**IChartDataPointLevel**](https://reference.aspose.com/slides/pt/java/com.aspose.slides/IChartDataPointLevel) possui 
dois métodos: [**getFormat**](https://reference.aspose.com/slides/pt/java/com.aspose.slides/IChartDataPointLevel#getFormat--) e 
[**getDataLabel**](https://reference.aspose.com/slides/pt/java/com.aspose.slides/IChartDataPointLevel#getLabel--) que 
fornecem acesso às configurações correspondentes.
## **Mostrar o Valor de um Ponto de Dados**
Mostrar o valor do ponto de dados “Leaf 4”:

```java
IChartDataPointCollection dataPoints = chart.getChartData().getSeries().get_Item(0).getDataPoints();
dataPoints.get_Item(3).getDataPointLevels().get_Item(0).getLabel().getDataLabelFormat().setShowValue(true);
```

![todo:image_alt_text](https://lh6.googleusercontent.com/bKHMf5Bj37ZkMwUE1OfXjw7_CRmDhafhQOUuVWDmitwbtdkwD68ibWluY6Q1HQz_z2Q-BR_SBrBPZ_gID5bGH0PUqI5w37S22RT-ZZal6k7qIDstKntYi5QXS8z-SgpnsI78WGiu)

## **Definir Rótulo e Cor de um Ponto de Dados**
Definir o rótulo de dados de “Branch 1” para mostrar o nome da série (“Series1”) em vez do nome da categoria. Em seguida, definir a cor do texto para amarelo:

```java
IDataLabel branch1Label = dataPoints.get_Item(0).getDataPointLevels().get_Item(0).getLabel();
branch1Label.getDataLabelFormat().setShowCategoryName(false);
branch1Label.getDataLabelFormat().setShowSeriesName(true);

branch1Label.getDataLabelFormat().getTextFormat().getPortionFormat().getFillFormat().setFillType(FillType.Solid);
branch1Label.getDataLabelFormat().getTextFormat().getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.YELLOW);
```

![todo:image_alt_text](https://lh6.googleusercontent.com/I9g0kewJnxkhUVlfSWRN39Ng-wzjWyRwF3yTbOD9HhLTLBt_sMJiEfDe7vOfqRNx89o9AVZsYTW3Vv_TIuj4EgM4_UEEi7zQ3jdvaO8FoG2JcsOqNRgbiE5HQZNz8xx_q9qdj8JQ)

## **Definir Cor de Ramo de um Ponto de Dados**
Alterar a cor do ramo “Steam 4”:

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

Não. O PowerPoint classifica os segmentos automaticamente (geralmente por valores decrescentes, no sentido horário). O Aspose.Slides reflete esse comportamento: não é possível alterar a ordem diretamente; você pode fazê-lo pré-processando os dados.

**Como o tema da apresentação afeta as cores dos segmentos e rótulos?**

As cores do gráfico herdam o [theme/palette](/slides/pt/java/presentation-theme/) da apresentação, a menos que você defina explicitamente preenchimentos/fonte. Para resultados consistentes, fixe preenchimentos sólidos e a formatação de texto nos níveis necessários.

**A exportação para PDF/PNG preserva as cores de ramos personalizadas e as configurações de rótulo?**

Sim. Ao exportar a apresentação, as configurações do gráfico (preenchimentos, rótulos) são preservadas nos formatos de saída porque o Aspose.Slides renderiza com a formatação do gráfico aplicada.

**Posso calcular as coordenadas reais de um rótulo/elemento para posicionamento de sobreposição personalizada sobre o gráfico?**

Sim. Após a validação do layout do gráfico, os valores reais de *x* e *y* ficam disponíveis para os elementos (por exemplo, um [DataLabel](https://reference.aspose.com/slides/pt/java/com.aspose.slides/datalabel/)), o que ajuda no posicionamento preciso das sobreposições.