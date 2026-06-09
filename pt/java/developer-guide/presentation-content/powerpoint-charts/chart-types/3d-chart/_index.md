---
title: Personalize Gráficos 3D em Apresentações Usando Java
linktitle: Gráfico 3D
type: docs
url: /pt/java/3d-chart/
keywords:
- gráfico 3D
- rotação
- profundidade
- PowerPoint
- apresentação
- Java
- Aspose.Slides
description: "Aprenda a criar e personalizar gráficos 3D no Aspose.Slides para Java, com suporte a arquivos PPT e PPTX — impulsione suas apresentações hoje."
---
## **Visão geral**

Este artigo explica como personalizar um gráfico 3D no Aspose.Slides configurando as propriedades `Rotation3D` como `RotationX`, `RotationY`, `DepthPercents` e `RightAngleAxes`. Ele descreve a criação de uma apresentação, a adição de um gráfico 3D com dados padrão, a aplicação das configurações de visualização 3D necessárias e a gravação da apresentação modificada como um arquivo PPTX.

## **Definir as propriedades RotationX, RotationY e DepthPercents de um gráfico 3D**
O Aspose.Slides for Java fornece uma API simples para definir essas propriedades. Este artigo ajudará você a definir diferentes propriedades como **Rotação X, Rotação Y, DepthPercents** etc. O código de exemplo aplica as configurações das propriedades mencionadas acima.

1. Crie uma instância da classe [Apresentação](https://reference.aspose.com/slides/pt/java/com.aspose.slides/presentation/).
1. Acesse o primeiro slide.
1. Adicione um gráfico com dados padrão.
1. Defina as propriedades Rotation3D.
1. Grave a apresentação modificada em um arquivo PPTX.

```java
Presentation pres = new Presentation();
try {
    // Acessar o primeiro slide
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Adicionar gráfico com dados padrão
    IChart chart = slide.getShapes().addChart(ChartType.StackedColumn3D, 0, 0, 500, 500);
    
    // Definir o índice da planilha de dados do gráfico
    int defaultWorksheetIndex = 0;
    
    // Obter a planilha de dados do gráfico
    IChartDataWorkbook fact = chart.getChartData().getChartDataWorkbook();
    
    // Adicionar séries
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 1, "Series 1"), chart.getType());
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 2, "Series 2"), chart.getType());
    
    // Adicionar categorias
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 1, 0, "Caetegoty 1"));
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 2, 0, "Caetegoty 2"));
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 3, 0, "Caetegoty 3"));
    
    // Definir propriedades Rotation3D
    chart.getRotation3D().setRightAngleAxes(true);
    chart.getRotation3D().setRotationX((byte)40);
    chart.getRotation3D().setRotationY(270);
    chart.getRotation3D().setDepthPercents(150);
    
    // Obter a segunda série do gráfico
    IChartSeries series = chart.getChartData().getSeries().get_Item(1);
    
    // Agora preenchendo os dados da série
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 1, 1, 20));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 2, 1, 50));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 3, 1, 30));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 1, 2, 30));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 2, 2, 10));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 3, 2, 60));
    
    // Definir valor OverLap
    series.getParentSeriesGroup().setOverlap((byte)100);
    
    // Gravar apresentação no disco
    pres.save("Rotation3D_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**Quais tipos de gráfico suportam o modo 3D no Aspose.Slides?**

O Aspose.Slides suporta variantes 3D de gráficos de colunas, incluindo Column 3D, Clustered Column 3D, Stacked Column 3D e 100% Stacked Column 3D, além de tipos 3D relacionados expostos através da classe [ChartType](https://reference.aspose.com/slides/pt/java/com.aspose.slides/charttype/). Para uma lista exata e atualizada, verifique os membros da classe [ChartType](https://reference.aspose.com/slides/pt/java/com.aspose.slides/charttype/) na referência da API da versão instalada.

**Posso obter uma imagem raster de um gráfico 3D para um relatório ou a web?**

Sim. Você pode exportar um gráfico para uma imagem via a [API de gráfico](https://reference.aspose.com/slides/pt/java/com.aspose.slides/shape/#getImage-int-float-float-) ou [renderizar o slide inteiro](/slides/pt/java/convert-powerpoint-to-png/) para formatos como PNG ou JPEG. Isso é útil quando você precisa de uma pré-visualização pixel-perfect ou deseja incorporar o gráfico em documentos, painéis ou páginas da web sem exigir o PowerPoint.

**Quão eficiente é a criação e renderização de grandes gráficos 3D?**

O desempenho depende do volume de dados e da complexidade visual. Para melhores resultados, mantenha os efeitos 3D mínimos, evite texturas pesadas nas paredes e áreas de plotagem, limite o número de pontos de dados por série quando possível e renderize para um tamanho de saída adequado (resolução e dimensões) que corresponda ao dispositivo de exibição ou impressão de destino.