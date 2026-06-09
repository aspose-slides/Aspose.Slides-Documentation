---
title: Personalizar gráficos 3D em apresentações usando JavaScript
linktitle: Gráfico 3D
type: docs
url: /pt/nodejs-java/3d-chart/
keywords:
- gráfico 3D
- rotação
- profundidade
- PowerPoint
- apresentação
- Node.js
- JavaScript
- Aspose.Slides
description: "Aprenda a criar e personalizar gráficos 3D no Aspose.Slides para Node.js via Java, com suporte a arquivos PPT e PPTX - impulsione suas apresentações hoje."
---
## **Visão geral**

Este artigo explica como personalizar um gráfico 3D no Aspose.Slides configurando as definições `Rotation3D` como `RotationX`, `RotationY`, `DepthPercents` e `RightAngleAxes`. Ele descreve como criar uma apresentação, adicionar um gráfico 3D com dados padrão, aplicar as configurações de visualização 3D necessárias e salvar a apresentação modificada como um arquivo PPTX.

## **Definir propriedades RotationX, RotationY e DepthPercents de um Gráfico 3D**

O Aspose.Slides for Node.js via Java fornece uma API simples para definir essas propriedades. O artigo a seguir ajudará você a definir diferentes propriedades, como **Rotação X,Y, DepthPercents** etc. O código de exemplo aplica a configuração das propriedades mencionadas acima.

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/presentation/).
2. Acesse o primeiro slide.
3. Adicione um gráfico com dados padrão.
4. Defina as propriedades Rotation3D.
5. Grave a apresentação modificada em um arquivo PPTX.

```javascript
var pres = new aspose.slides.Presentation();
try {
    // Acessar primeiro slide
    var slide = pres.getSlides().get_Item(0);
    // Adicionar gráfico com dados padrão
    var chart = slide.getShapes().addChart(aspose.slides.ChartType.StackedColumn3D, 0, 0, 500, 500);
    // Definir o índice da planilha de dados do gráfico
    var defaultWorksheetIndex = 0;
    // Obter a planilha de dados do gráfico
    var fact = chart.getChartData().getChartDataWorkbook();
    // Adicionar séries
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 1, "Series 1"), chart.getType());
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 2, "Series 2"), chart.getType());
    // Adicionar Categorias
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 1, 0, "Caetegoty 1"));
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 2, 0, "Caetegoty 2"));
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 3, 0, "Caetegoty 3"));
    // Definir propriedades Rotation3D
    chart.getRotation3D().setRightAngleAxes(true);
    chart.getRotation3D().setRotationX(40);
    chart.getRotation3D().setRotationY(270);
    chart.getRotation3D().setDepthPercents(150);
    // Obter segunda série do gráfico
    var series = chart.getChartData().getSeries().get_Item(1);
    // Agora preenchendo os dados da série
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 1, 1, 20));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 2, 1, 50));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 3, 1, 30));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 1, 2, 30));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 2, 2, 10));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 3, 2, 60));
    // Definir valor OverLap
    series.getParentSeriesGroup().setOverlap(100);
    // Write presentation to disk
    pres.save("Rotation3D_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Perguntas frequentes**

**Quais tipos de gráfico suportam o modo 3D no Aspose.Slides?**

O Aspose.Slides suporta variantes 3D de gráficos de colunas, incluindo Column 3D, Clustered Column 3D, Stacked Column 3D e 100% Stacked Column 3D, juntamente com tipos 3D relacionados expostos através da enumeração [ChartType](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/charttype/). Para obter uma lista exata e atualizada, verifique os membros da enumeração [ChartType](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/charttype/) na referência da API da sua versão instalada.

**Posso obter uma imagem raster de um gráfico 3D para um relatório ou para a web?**

Sim. Você pode exportar um gráfico para uma imagem através da [chart API](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/shape/#getImage) ou [renderizar o slide inteiro](/slides/pt/nodejs-java/convert-powerpoint-to-png/) para formatos como PNG ou JPEG. Isso é útil quando você precisa de uma visualização pixel-perfect ou deseja incorporar o gráfico em documentos, painéis ou páginas da web sem exigir o PowerPoint.

**Qual é o desempenho ao criar e renderizar gráficos 3D grandes?**

O desempenho depende do volume de dados e da complexidade visual. Para obter os melhores resultados, mantenha os efeitos 3D mínimos, evite texturas pesadas nas paredes e áreas de plotagem, limite o número de pontos de dados por série sempre que possível e renderize para uma saída com tamanho adequado (resolução e dimensões) para corresponder à exibição ou necessidade de impressão desejada.