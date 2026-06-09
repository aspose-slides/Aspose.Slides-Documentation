---
title: Personalizar áreas de plotagem de gráficos de apresentações no Android
linktitle: Área de Plotagem
type: docs
url: /pt/androidjava/chart-plot-area/
keywords:
- gráfico
- área de plotagem
- largura da área de plotagem
- altura da área de plotagem
- tamanho da área de plotagem
- modo de layout
- PowerPoint
- apresentação
- Android
- Java
- Aspose.Slides
description: "Descubra como personalizar áreas de plotagem de gráficos em apresentações PowerPoint com Aspose.Slides para Android via Java. Melhore visualmente seus slides com facilidade."
---
## **Visão geral**

Este artigo mostra como trabalhar com a área de plotagem de um gráfico no Aspose.Slides. Ele explica como obter a posição e o tamanho reais da área de plotagem validando o layout do gráfico e, em seguida, lendo seus valores de X, Y, largura e altura.

Também demonstra como configurar o modo de layout da área de plotagem quando o layout é definido manualmente, usando `LayoutTargetType` para definir se a área de plotagem é calculada por sua região interna ou por sua região externa juntamente com os eixos e rótulos dos eixos.

## **Obter Largura e Altura de uma Área de Plotagem de Gráfico**
Aspose.Slides para Android via Java fornece uma API simples para .

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/Presentation).
2. Acesse o primeiro slide.
3. Adicione um gráfico com dados padrão.
4. Chame o método [IChart.validateChartLayout()](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/IChart#validateChartLayout--) antes para obter os valores reais.
5. Obtém a localização X real (esquerda) do elemento do gráfico em relação ao canto superior esquerdo do gráfico.
6. Obtém a parte superior real do elemento do gráfico em relação ao canto superior esquerdo do gráfico.
7. Obtém a largura real do elemento do gráfico.
8. Obtém a altura real do elemento do gráfico.

```java
// Criar uma instância da classe Presentation
Presentation pres = new Presentation();
try {
    Chart chart = (Chart)pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 100, 100, 500, 350);
    chart.validateChartLayout();

    double x = chart.getPlotArea().getActualX();
    double y = chart.getPlotArea().getActualY();
    double w = chart.getPlotArea().getActualWidth();
    double h = chart.getPlotArea().getActualHeight();
} finally {
    if (pres != null) pres.dispose();
}
```

## **Definir o Modo de Layout de uma Área de Plotagem de Gráfico**
Aspose.Slides para Android via Java fornece uma API simples para definir o modo de layout da área de plotagem do gráfico. Os métodos [**setLayoutTargetType**](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/ChartPlotArea#setLayoutTargetType-int-) e [**getLayoutTargetType**](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/ChartPlotArea#getLayoutTargetType--) foram adicionados à classe [**ChartPlotArea**](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/ChartPlotArea) e à interface [**IChartPlotArea**](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/IChartPlotArea). Se o layout da área de plotagem for definido manualmente, esta propriedade especifica se a área de plotagem deve ser layoutada por seu interior (não incluindo eixo e rótulos dos eixos) ou por seu exterior (incluindo eixo e rótulos dos eixos). Existem dois valores possíveis que são definidos no enum [**LayoutTargetType**](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/LayoutTargetType).

- [**LayoutTargetType.Inner**](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/LayoutTargetType#Inner) - especifica que o tamanho da área de plotagem determina o tamanho da área de plotagem, não incluindo as marcas de intervalos e os rótulos dos eixos.
- [**LayoutTargetType.Outer**](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/LayoutTargetType#Outer) - especifica que o tamanho da área de plotagem determina o tamanho da área de plotagem, as marcas de intervalos e os rótulos dos eixos.

Um exemplo de código é fornecido abaixo.

```java
// Criar uma instância da classe Presentation
Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 100, 600, 400);
    chart.getPlotArea().setX(0.2f);
    chart.getPlotArea().setY(0.2f);
    chart.getPlotArea().setWidth(0.7f);
    chart.getPlotArea().setHeight(0.7f);
    chart.getPlotArea().setLayoutTargetType(LayoutTargetType.Inner);

    pres.save("SetLayoutMode_outer.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Perguntas frequentes**

**Em quais unidades são retornados x real, y real, largura real e altura real?**

Em pontos; 1 polegada = 72 pontos. Estas são unidades de coordenadas do Aspose.Slides.

**Como a Área de Plotagem difere da Área do Gráfico em termos de conteúdo?**

A Área de Plotagem é a região de desenho dos dados (séries, linhas de grade, linhas de tendência etc.); a Área do Gráfico inclui os elementos ao redor (título, legenda etc.). Em gráficos 3D, a Área de Plotagem também inclui as paredes/chão e os eixos.

**Como são interpretados x, y, largura e altura da Área de Plotagem quando o layout é manual?**

Eles são frações (0–1) do tamanho total do gráfico; nesse modo, o posicionamento automático é desativado e as frações definidas são usadas.

**Por que a posição da Área de Plotagem mudou após adicionar/mover a legenda?**

A legenda fica na área do gráfico fora da Área de Plotagem, mas afeta o layout e o espaço disponível, de modo que a Área de Plotagem pode deslocar‑se quando o posicionamento automático está em vigor. (Este é o comportamento padrão dos gráficos do PowerPoint.)