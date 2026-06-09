---
title: Personalizar Gráficos de Rosca em Apresentações Usando PHP
linktitle: Gráfico de Rosca
type: docs
weight: 30
url: /pt/php-java/doughnut-chart/
keywords:
- gráfico de rosca
- espaço central
- tamanho do buraco
- PowerPoint
- apresentação
- PHP
- Aspose.Slides
description: "Descubra como criar e personalizar gráficos de rosca no Aspose.Slides para PHP via Java, suportando formatos PowerPoint para apresentações dinâmicas."
---
## **Visão geral**

Este artigo mostra como trabalhar com um gráfico de rosca no Aspose.Slides adicionando o gráfico a um slide, definindo o tamanho do buraco central e salvando a apresentação. Ele se concentra no método `setDoughnutHoleSize` e demonstra as etapas básicas necessárias para personalizar esse tipo de gráfico em código.

Ele também inclui uma breve FAQ cobrindo cenários relacionados a gráficos de rosca, como usar várias séries para criar múltiplos anéis, trabalhar com gráficos de rosca explodidos e exportar um gráfico como imagem raster ou SVG.

## **Especificar o Espaço Central em um Gráfico de Rosca**

Para especificar o tamanho do buraco em um gráfico de rosca, siga as etapas abaixo:

1. Instanciar o objeto [Presentation](https://reference.aspose.com/slides/pt/php-java/aspose.slides/presentation).
2. Adicionar um gráfico de rosca ao slide.
3. Especificar o tamanho do buraco em um gráfico de rosca.
4. Gravar a apresentação no disco.

No exemplo abaixo, definimos o tamanho do buraco em um gráfico de rosca.

```php
  # Criar uma instância da classe Presentation
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Doughnut, 50, 50, 400, 400);
    $chart->getChartData()->getSeriesGroups()->get_Item(0)->setDoughnutHoleSize(90);
    # Gravar a apresentação no disco
    $pres->save("DoughnutHoleSize_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **FAQ**

**Posso criar uma rosca de vários níveis com múltiplos anéis?**

Sim. Adicione várias séries a um único gráfico de rosca — cada série torna‑se um anel separado. A ordem dos anéis é determinada pela ordem das séries na coleção.

**Um gráfico de rosca "explodido" (fatias separadas) é suportado?**

Sim. Existe um tipo de gráfico Exploded Doughnut[chart type](https://reference.aspose.com/slides/pt/php-java/aspose.slides/charttype/) e uma propriedade de explosão nos pontos de dados; você pode separar fatias individuais.

**Como posso obter uma imagem de um gráfico de rosca (PNG/SVG) para um relatório?**

Um gráfico é uma forma; você pode renderizá‑lo para uma [raster image](https://reference.aspose.com/slides/pt/php-java/aspose.slides/shape/#getImage) ou exportar o gráfico para uma [SVG image](https://reference.aspose.com/slides/pt/php-java/aspose.slides/shape/#writeAsSvg).