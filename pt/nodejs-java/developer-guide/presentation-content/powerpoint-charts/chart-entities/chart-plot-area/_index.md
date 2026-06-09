---
title: Personalizar áreas de plotagem de gráficos de apresentação em JavaScript
linktitle: Área de Plotagem
type: docs
url: /pt/nodejs-java/chart-plot-area/
keywords:
- gráfico
- área de plotagem
- largura da área de plotagem
- altura da área de plotagem
- tamanho da área de plotagem
- modo de layout
- PowerPoint
- apresentação
- Node.js
- JavaScript
- Aspose.Slides
description: "Descubra como personalizar áreas de plotagem de gráficos em apresentações PowerPoint com JavaScript e Aspose.Slides para Node.js. Melhore visualmente seus slides sem esforço."
---
## **Visão geral**

Este artigo mostra como trabalhar com a área de plotagem de um gráfico no Aspose.Slides. Explica como obter a posição e o tamanho reais da área de plotagem validando o layout do gráfico e, em seguida, lendo seus valores X, Y, largura e altura.

Também demonstra como configurar o modo de layout da área de plotagem quando o layout é definido manualmente, usando `LayoutTargetType` para definir se a área de plotagem é calculada por sua região interna ou por sua região externa juntamente com os eixos e rótulos dos eixos.

## **Obter largura e altura da área de plotagem do gráfico**

Aspose.Slides for Node.js via Java fornece uma API simples para .

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/Presentation).
2. Acesse o primeiro slide.
3. Adicione um gráfico com dados padrão.
4. Chame o método [Chart.validateChartLayout()](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/Chart#validateChartLayout--) antes para obter os valores reais.
5. Obtém a localização X real (esquerda) do elemento do gráfico em relação ao canto superior esquerdo do gráfico.
6. Obtém a posição superior real do elemento do gráfico em relação ao canto superior esquerdo do gráfico.
7. Obtém a largura real do elemento do gráfico.
8. Obtém a altura real do elemento do gráfico.

```javascript
// Crie uma instância da classe Presentation
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 100, 100, 500, 350);
    chart.validateChartLayout();
    var x = chart.getPlotArea().getActualX();
    var y = chart.getPlotArea().getActualY();
    var w = chart.getPlotArea().getActualWidth();
    var h = chart.getPlotArea().getActualHeight();
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Definir modo de layout da área de plotagem do gráfico**

Aspose.Slides for Node.js via Java fornece uma API simples para definir o modo de layout da área de plotagem do gráfico. Os métodos [**setLayoutTargetType**](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/ChartPlotArea#setLayoutTargetType-int-) e [**getLayoutTargetType**](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/ChartPlotArea#getLayoutTargetType--) foram adicionados à classe [**ChartPlotArea**](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/ChartPlotArea). Se o layout da área de plotagem for definido manualmente, esta propriedade especifica se a área será layoutada por seu interior (excluindo eixos e rótulos dos eixos) ou por seu exterior (incluindo eixos e rótulos dos eixos). Existem dois valores possíveis definidos no enum [**LayoutTargetType**](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/LayoutTargetType).

- [**LayoutTargetType.Inner**](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/LayoutTargetType#Inner) – especifica que o tamanho da área de plotagem determina o tamanho da área de plotagem, sem incluir as marcas de escala e os rótulos dos eixos.
- [**LayoutTargetType.Outer**](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/LayoutTargetType#Outer) – especifica que o tamanho da área de plotagem determina o tamanho da área de plotagem, as marcas de escala e os rótulos dos eixos.

Um exemplo de código é fornecido abaixo.

```javascript
// Crie uma instância da classe Presentation
var pres = new aspose.slides.Presentation();
try {
    var slide = pres.getSlides().get_Item(0);
    var chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 20, 100, 600, 400);
    chart.getPlotArea().setX(0.2);
    chart.getPlotArea().setY(0.2);
    chart.getPlotArea().setWidth(0.7);
    chart.getPlotArea().setHeight(0.7);
    chart.getPlotArea().setLayoutTargetType(aspose.slides.LayoutTargetType.Inner);
    pres.save("SetLayoutMode_outer.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **FAQ**

**Em quais unidades são retornados X real, Y real, Largura real e Altura real?**

Em pontos; 1 polegada = 72 pontos. Estas são unidades de coordenadas do Aspose.Slides.

**Como a Área de Plotagem difere da Área do Gráfico em termos de conteúdo?**

A Área de Plotagem é a região de desenho dos dados (séries, linhas de grade, linhas de tendência etc.); a Área do Gráfico inclui os elementos circundantes (título, legenda etc.). Em gráficos 3D, a Área de Plotagem também inclui as paredes/chão e os eixos.

**Como são interpretados X, Y, Largura e Altura da Área de Plotagem quando o layout é manual?**

Eles são frações (0–1) do tamanho total do gráfico; nesse modo, o posicionamento automático é desativado e as frações definidas são usadas.

**Por que a posição da Área de Plotagem mudou após adicionar/mover a legenda?**

A legenda fica na área do gráfico fora da Área de Plotagem, mas afeta o layout e o espaço disponível, de modo que a Área de Plotagem pode ser deslocada quando o posicionamento automático está em vigor. (Esse é o comportamento padrão dos gráficos do PowerPoint.)