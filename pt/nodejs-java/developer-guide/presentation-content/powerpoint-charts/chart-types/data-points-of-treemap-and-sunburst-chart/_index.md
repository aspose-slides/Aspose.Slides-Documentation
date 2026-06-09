---
title: Personalizar Pontos de Dados em Gráficos Treemap e Sunburst Usando JavaScript
linktitle: Pontos de Dados em Gráficos Treemap e Sunburst
type: docs
url: /pt/nodejs-java/data-points-of-treemap-and-sunburst-chart/
weight: 40
keywords:
- gráfico treemap
- gráfico sunburst
- ponto de dado
- cor do rótulo
- cor do ramo
- PowerPoint
- apresentação
- Node.js
- JavaScript
- Aspose.Slides
description: "Aprenda a gerenciar pontos de dados em gráficos treemap e sunburst com JavaScript e Aspose.Slides para Node.js via Java, compatível com os formatos PowerPoint."
---
## **Introdução**

Entre outros tipos de gráficos do PowerPoint, existem dois tipos “hierárquicos” – **Treemap** e **Sunburst** chart (também conhecido como Sunburst Graph, Sunburst Diagram, Radial Chart, Radial Graph ou Multi Level Pie Chart). Esses gráficos exibem dados hierárquicos organizados como uma árvore – das folhas até o topo do ramo. As folhas são definidas pelos pontos de dados da série, e cada nível de agrupamento aninhado subsequente é definido pela categoria correspondente. Aspose.Slides for Node.js via Java permite formatar os pontos de dados do Gráfico Sunburst e Treemap em JavaScript.

Aqui está um Gráfico Sunburst, onde os dados na coluna Series1 definem os nós folha, enquanto as outras colunas definem pontos de dados hierárquicos:

![todo:image_alt_text](https://lh6.googleusercontent.com/TSSU5O7SLOi5NZD9JaubhgGU1QU5tYKc23RQX_cal3tlz5TpOvsgUFLV_rHvruwN06ft1XYgsLhbeEDXzVqdAybPIbpfGy-lwoQf_ydxDwcjAeZHWfw61c4koXezAAlEeCA7x6BZ)

Vamos começar adicionando um novo gráfico Sunburst à apresentação:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Sunburst, 100, 100, 450, 400);
    // ...
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

{{% alert color="primary" title="Veja também" %}} 
- [**Criar ou Atualizar Gráficos de Apresentação PowerPoint em JavaScript**](/slides/pt/nodejs-java/create-chart/)
{{% /alert %}}

Se houver necessidade de formatar os pontos de dados do gráfico, devemos usar o seguinte:

[**ChartDataPointLevelsManager**](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/ChartDataPointLevelsManager), 
[ChartDataPointLevel](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/ChartDataPointLevel) classes 
and [**ChartDataPoint.getDataPointLevels**](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/ChartDataPoint#getDataPointLevels--) method 
provide access to format data points of Treemap and Sunburst charts. 
[**ChartDataPointLevelsManager**](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/ChartDataPointLevelsManager)
is used for accessing multi-level categories - it represents the container of 
[**ChartDataPointLevel**](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/ChartDataPointLevel) objects.
Basically it is a wrapper for 
[**ChartCategoryLevelsManager**](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/ChartCategoryLevelsManager) with
the properties added specific for data points. 
[**ChartDataPointLevel**](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/ChartDataPointLevel) class has
two methods: [**getFormat**](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/ChartDataPointLevel#getFormat--) and 
[**getDataLabel**](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/ChartDataPointLevel#getLabel--) which
provide access to corresponding settings.

## **Mostrar Valor do Ponto de Dados**
Mostrar o valor do ponto de dados "Leaf 4":

```javascript
var dataPoints = chart.getChartData().getSeries().get_Item(0).getDataPoints();
dataPoints.get_Item(3).getDataPointLevels().get_Item(0).getLabel().getDataLabelFormat().setShowValue(true);
```

![todo:image_alt_text](https://lh6.googleusercontent.com/bKHMf5Bj37ZkMwUE1OfXjw7_CRmDhafhQOUuVWDmitwbtdkwD68ibWluY6Q1HQz_z2Q-BR_SBrBPZ_gID5bGH0PUqI5w37S22RT-ZZal6k7qIDstKntYi5QXS8z-SgpnsI78WGiu)

## **Definir Rótulo e Cor do Ponto de Dados**
Defina o rótulo de dados de "Branch 1" para mostrar o nome da série ("Series1") em vez do nome da categoria. Em seguida, defina a cor do texto para amarelo:

```javascript
var branch1Label = dataPoints.get_Item(0).getDataPointLevels().get_Item(0).getLabel();
branch1Label.getDataLabelFormat().setShowCategoryName(false);
branch1Label.getDataLabelFormat().setShowSeriesName(true);
branch1Label.getDataLabelFormat().getTextFormat().getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
branch1Label.getDataLabelFormat().getTextFormat().getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "YELLOW"));
```

![todo:image_alt_text](https://lh6.googleusercontent.com/I9g0kewJnxkhUVlfSWRN39Ng-wzjWyRwF3yTbOD9HhLTLBt_sMJiEfDe7vOfqRNx89o9AVZsYTW3Vv_TIuj4EgM4_UEEi7zQ3jdvaO8FoG2JcsOqNRgbiE5HQZNz8xx_q9qdj8JQ)

## **Definir Cor do Ramo do Ponto de Dados**
Alterar a cor do ramo "Steam 4":

```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Sunburst, 100, 100, 450, 400);
    var dataPoints = chart.getChartData().getSeries().get_Item(0).getDataPoints();
    var stem4branch = dataPoints.get_Item(9).getDataPointLevels().get_Item(1);
    stem4branch.getFormat().getFill().setFillType(java.newByte(aspose.slides.FillType.Solid));
    stem4branch.getFormat().getFill().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
    pres.save("pres.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

![todo:image_alt_text](https://lh5.googleusercontent.com/Zll4cpQ5tTDdgwmJ4yuupolfGaANR8SWWTU3XaJav_ZVXVstV1pI1z1OFH-gov6FxPoDz1cxmMyrgjsdYGS24PlhaYa2daKzlNuL1a0xYcqEiyyO23AE6JMOLavWpvqA6SzOCA6_)

## **Perguntas Frequentes**

**Posso mudar a ordem (classificação) dos segmentos em Sunburst/Treemap?**

Não. O PowerPoint classifica os segmentos automaticamente (normalmente por valores decrescentes, no sentido horário). O Aspose.Slides espelha esse comportamento: você não pode mudar a ordem diretamente; ela é obtida pré-processando os dados.

**Como o tema da apresentação afeta as cores dos segmentos e rótulos?**

As cores do gráfico herdam o [tema/palette](/slides/pt/nodejs-java/presentation-theme/) da apresentação, a menos que você defina explicitamente preenchimentos/fonte. Para resultados consistentes, defina preenchimentos sólidos e formatação de texto nos níveis necessários.

**A exportação para PDF/PNG preservará as cores de ramo personalizadas e as configurações de rótulo?**

Sim. Ao exportar a apresentação, as configurações do gráfico (preenchimentos, rótulos) são preservadas nos formatos de saída porque o Aspose.Slides renderiza com a formatação do gráfico aplicada.

**Posso calcular as coordenadas reais de um rótulo/elemento para posicionamento de sobreposição personalizada sobre o gráfico?**

Sim. Após a validação do layout do gráfico, X real e Y real estão disponíveis para os elementos (por exemplo, um [DataLabel](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/datalabel/)), que ajuda no posicionamento preciso de sobreposições.