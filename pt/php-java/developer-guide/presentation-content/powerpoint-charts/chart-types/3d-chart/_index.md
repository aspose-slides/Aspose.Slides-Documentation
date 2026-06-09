---
title: Personalizar Gráficos 3D em Apresentações Usando PHP
linktitle: Gráfico 3D
type: docs
url: /pt/php-java/3d-chart/
keywords:
- gráfico 3D
- rotação
- profundidade
- PowerPoint
- apresentação
- PHP
- Aspose.Slides
description: "Aprenda como criar e personalizar gráficos 3-D no Aspose.Slides for PHP via Java, com suporte a arquivos PPT e PPTX — potencialize suas apresentações hoje."
---
## **Visão Geral**

Este artigo explica como personalizar um gráfico 3D no Aspose.Slides configurando as definições `Rotation3D` como `RotationX`, `RotationY`, `DepthPercents` e `RightAngleAxes`. Ele mostra como criar uma apresentação, adicionar um gráfico 3D com dados padrão, aplicar as configurações de visualização 3D necessárias e salvar a apresentação modificada como um arquivo PPTX.

## **Definir as propriedades RotationX, RotationY e DepthPercents de um gráfico 3D**
Aspose.Slides for PHP via Java fornece uma API simples para definir essas propriedades. Este artigo a seguir ajudará você a definir diferentes propriedades como **X,Y Rotation, DepthPercents** etc. O código de exemplo aplica a definição das propriedades mencionadas acima.

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/php-java/aspose.slides/presentation/) .
1. Acesse o primeiro slide.
1. Adicione um gráfico com dados padrão.
1. Defina as propriedades Rotation3D.
1. Grave a apresentação modificada em um arquivo PPTX.

```php
  $pres = new Presentation();
  try {
    # Acessar o primeiro slide
    $slide = $pres->getSlides()->get_Item(0);
    # Adicionar gráfico com dados padrão
    $chart = $slide->getShapes()->addChart(ChartType::StackedColumn3D, 0, 0, 500, 500);
    # Definir o índice da planilha de dados do gráfico
    $defaultWorksheetIndex = 0;
    # Obter a planilha de dados do gráfico
    $fact = $chart->getChartData()->getChartDataWorkbook();
    # Adicionar séries
    $chart->getChartData()->getSeries()->add($fact->getCell($defaultWorksheetIndex, 0, 1, "Series 1"), $chart->getType());
    $chart->getChartData()->getSeries()->add($fact->getCell($defaultWorksheetIndex, 0, 2, "Series 2"), $chart->getType());
    # Adicionar categorias
    $chart->getChartData()->getCategories()->add($fact->getCell($defaultWorksheetIndex, 1, 0, "Caetegoty 1"));
    $chart->getChartData()->getCategories()->add($fact->getCell($defaultWorksheetIndex, 2, 0, "Caetegoty 2"));
    $chart->getChartData()->getCategories()->add($fact->getCell($defaultWorksheetIndex, 3, 0, "Caetegoty 3"));
    # Definir propriedades Rotation3D
    $chart->getRotation3D()->setRightAngleAxes(true);
    $chart->getRotation3D()->setRotationX(40);
    $chart->getRotation3D()->setRotationY(270);
    $chart->getRotation3D()->setDepthPercents(150);
    # Obter a segunda série do gráfico
    $series = $chart->getChartData()->getSeries()->get_Item(1);
    # Agora preenchendo os dados da série
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 1, 1, 20));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 2, 1, 50));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 3, 1, 30));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 1, 2, 30));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 2, 2, 10));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 3, 2, 60));
    # Definir valor Overlap
    $series->getParentSeriesGroup()->setOverlap(100);
    # Salvar apresentação no disco
    $pres->save("Rotation3D_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **FAQ**

**Quais tipos de gráfico suportam o modo 3D no Aspose.Slides?**

O Aspose.Slides suporta variantes 3D de gráficos de colunas, incluindo Column 3D, Clustered Column 3D, Stacked Column 3D e 100% Stacked Column 3D, juntamente com tipos 3D relacionados expostos através da classe [ChartType](https://reference.aspose.com/slides/pt/php-java/aspose.slides/charttype/). Para uma lista exata e atualizada, verifique os membros de [ChartType](https://reference.aspose.com/slides/pt/php-java/aspose.slides/charttype/) na referência da API da versão instalada.

**Posso obter uma imagem raster de um gráfico 3D para um relatório ou para a web?**

Sim. Você pode exportar um gráfico para uma imagem via a [chart API](https://reference.aspose.com/slides/pt/php-java/aspose.slides/shape/#getImage) ou [renderizar o slide inteiro](/slides/pt/php-java/convert-powerpoint-to-png/) para formatos como PNG ou JPEG. Isso é útil quando você precisa de uma pré‑visualização pixel‑perfeita ou deseja incorporar o gráfico em documentos, painéis ou páginas web sem exigir o PowerPoint.

**Qual é o desempenho ao criar e renderizar gráficos 3D grandes?**

O desempenho depende do volume de dados e da complexidade visual. Para obter os melhores resultados, mantenha os efeitos 3D ao mínimo, evite texturas pesadas nas paredes e áreas de plotagem, limite o número de pontos de dados por série quando possível e renderize para uma saída de tamanho adequado (resolução e dimensões) que corresponda à exibição ou impressão alvo.