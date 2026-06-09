---
title: Adicionar linhas de tendência a gráficos de apresentação no Android
linktitle: Linha de tendência
type: docs
url: /pt/androidjava/trend-line/
keywords:
- gráfico
- linha de tendência
- linha de tendência exponencial
- linha de tendência linear
- linha de tendência logarítmica
- linha de tendência de média móvel
- linha de tendência polinomial
- linha de tendência de potência
- linha de tendência personalizada
- PowerPoint
- apresentação
- Android
- Java
- Aspose.Slides
description: "Adicione e personalize rapidamente linhas de tendência em gráficos do PowerPoint com Aspose.Slides para Android via Java — um guia prático para envolver seu público."
---
## **Visão geral**

Este artigo explica como adicionar linhas de tendência a gráficos de apresentação usando Aspose.Slides. Ele mostra como criar um gráfico, adicionar linhas de tendência às séries do gráfico e trabalhar com vários tipos de linhas de tendência, incluindo exponencial, linear, logarítmica, média móvel, polinomial e de potência.

Também descreve como adicionar uma linha personalizada a um gráfico inserindo uma forma de linha e inclui uma breve FAQ sobre os valores de projeção da linha de tendência para frente e para trás e se as linhas de tendência são preservadas ao exportar para PDF ou SVG e ao renderizar gráficos como imagens.

## **Adicionar uma linha de tendência**
Aspose.Slides for Android via Java fornece uma API simples para gerenciar diferentes linhas de tendência de gráfico:

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/Presentation).
2. Obtenha a referência de um slide pelo seu índice.
3. Adicione um gráfico com dados padrão junto com qualquer tipo desejado (este exemplo usa ChartType.ClusteredColumn).
4. Adicionando linha de tendência exponencial para a série 1 do gráfico.
5. Adicionando linha de tendência linear para a série 1 do gráfico.
6. Adicionando linha de tendência logarítmica para a série 2 do gráfico.
7. Adicionando linha de tendência de média móvel para a série 2 do gráfico.
8. Adicionando linha de tendência polinomial para a série 3 do gráfico.
9. Adicionando linha de tendência de potência para a série 3 do gráfico.
10. Grave a apresentação modificada em um arquivo PPTX.

O código a seguir é usado para criar um gráfico com linhas de tendência.

```java
// Crie uma instância da classe Presentation
Presentation pres = new Presentation();
try {
    // Criando um gráfico de colunas agrupadas
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 400);
    
    // Adicionando linha de tendência exponencial para a série 1 do gráfico
    ITrendline tredLinep = chart.getChartData().getSeries().get_Item(0).getTrendLines().add(TrendlineType.Exponential);
    tredLinep.setDisplayEquation(false);
    tredLinep.setDisplayRSquaredValue(false);
    
    // Adicionando linha de tendência linear para a série 1 do gráfico
    ITrendline tredLineLin = chart.getChartData().getSeries().get_Item(0).getTrendLines().add(TrendlineType.Linear);
    tredLineLin.setTrendlineType(TrendlineType.Linear);
    tredLineLin.getFormat().getLine().getFillFormat().setFillType(FillType.Solid);
    tredLineLin.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.RED);
    
    
    // Adicionando linha de tendência logarítmica para a série 2 do gráfico
    ITrendline tredLineLog = chart.getChartData().getSeries().get_Item(1).getTrendLines().add(TrendlineType.Logarithmic);
    tredLineLog.setTrendlineType(TrendlineType.Logarithmic);
    tredLineLog.addTextFrameForOverriding("New log trend line");
    
    // Adicionando linha de tendência de média móvel para a série 2 do gráfico
    ITrendline tredLineMovAvg = chart.getChartData().getSeries().get_Item(1).getTrendLines().add(TrendlineType.MovingAverage);
    tredLineMovAvg.setTrendlineType(TrendlineType.MovingAverage);
    tredLineMovAvg.setPeriod((byte)3);
    tredLineMovAvg.setTrendlineName("New TrendLine Name");
    
    // Adicionando linha de tendência polinomial para a série 3 do gráfico
    ITrendline tredLinePol = chart.getChartData().getSeries().get_Item(2).getTrendLines().add(TrendlineType.Polynomial);
    tredLinePol.setTrendlineType(TrendlineType.Polynomial);
    tredLinePol.setForward(1);
    tredLinePol.setOrder((byte)3);
    
    // Adicionando linha de tendência de potência para a série 3 do gráfico
    ITrendline tredLinePower = chart.getChartData().getSeries().get_Item(1).getTrendLines().add(TrendlineType.Power);
    tredLinePower.setTrendlineType(TrendlineType.Power);
    tredLinePower.setBackward(1);
    
    // Salvando a apresentação
    pres.save("ChartTrendLines_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Adicionar uma linha personalizada**
Aspose.Slides for Android via Java fornece uma API simples para adicionar linhas personalizadas em um gráfico. Para adicionar uma linha simples a um slide selecionado da apresentação, siga os passos abaixo:

- Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/Presentation)
- Obtenha a referência de um slide usando seu Índice
- Crie um novo gráfico usando o método AddChart exposto pelo objeto Shapes
- Adicione um AutoShape do tipo Linha usando o método AddAutoShape exposto pelo objeto Shapes
- Defina a Cor das linhas da forma.
- Grave a apresentação modificada como um arquivo PPTX

O código a seguir é usado para criar um gráfico com linhas personalizadas.

```java
// Crie uma instância da classe Presentation
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 100, 100, 500, 400);
    IAutoShape shape = chart.getUserShapes().getShapes().addAutoShape(ShapeType.Line, 0, chart.getHeight()/2, chart.getWidth(), 0);
    
    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.awt.Color.RED);
    
    pres.save("Presentation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**O que significam ‘forward’ e ‘backward’ em uma linha de tendência?**

São os comprimentos da linha de tendência projetados para frente/para trás: para gráficos de dispersão (XY) — em unidades do eixo; para gráficos que não são de dispersão — em número de categorias. Apenas valores não negativos são permitidos.

**A linha de tendência será preservada ao exportar a apresentação para PDF ou SVG, ou ao renderizar um slide como imagem?**

Sim. O Aspose.Slides converte apresentações para [PDF](/slides/pt/androidjava/convert-powerpoint-to-pdf/)/[SVG](/slides/pt/androidjava/render-a-slide-as-an-svg-image/) e renderiza gráficos como imagens; as linhas de tendência, como parte do gráfico, são preservadas durante essas operações. Também há um método disponível para [exportar uma imagem do gráfico](/slides/pt/androidjava/create-shape-thumbnails/) próprio.