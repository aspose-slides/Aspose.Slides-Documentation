---
title: Personalizar tabelas de dados de gráfico em apresentações usando PHP
linktitle: Tabela de Dados
type: docs
url: /pt/php-java/chart-data-table/
keywords:
- dados de gráfico
- tabela de dados
- propriedades de fonte
- PowerPoint
- apresentação
- PHP
- Aspose.Slides
description: "Personalize tabelas de dados de gráfico para PPT e PPTX com Aspose.Slides for PHP via Java para aumentar a eficiência e o apelo nas apresentações."
---
## **Visão geral**

Este artigo explica como trabalhar com tabelas de dados de gráfico no Aspose.Slides. Ele mostra como exibir uma tabela de dados para um gráfico e personalizar a formatação de texto definindo propriedades de fonte, como estilo negrito e altura da fonte. O exemplo demonstra como carregar uma apresentação, adicionar um gráfico, habilitar a tabela de dados do gráfico, aplicar as configurações de fonte e salvar a apresentação atualizada.

Também inclui respostas breves às perguntas comuns sobre exibir chaves de legenda em uma tabela de dados de gráfico, preservar a tabela de dados durante a exportação, trabalhar com gráficos carregados de apresentações ou modelos existentes e identificar gráficos onde a tabela de dados está habilitada.

## **Definir propriedades de fonte para uma tabela de dados de gráfico**
Aspose.Slides for PHP via Java oferece suporte para alterar a cor das categorias em uma cor de série.  

1. Instanciar objeto da classe [Presentation](https://reference.aspose.com/slides/pt/php-java/aspose.slides/Presentation).
1. Adicionar gráfico no slide.
1. Definir a tabela do gráfico.
1. Definir a altura da fonte.
1. Salvar a apresentação modificada.

A seguir, um exemplo de código é apresentado.  

```php
  # Criando apresentação vazia
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 600, 400);
    $chart->setDataTable(true);
    $chart->getChartDataTable()->getTextFormat()->getPortionFormat()->setFontBold(NullableBool::True);
    $chart->getChartDataTable()->getTextFormat()->getPortionFormat()->setFontHeight(20);
    $pres->save("output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Perguntas frequentes**

**Posso mostrar pequenas chaves de legenda ao lado dos valores na tabela de dados do gráfico?**

Sim. A tabela de dados oferece suporte a [legend keys](https://reference.aspose.com/slides/pt/php-java/aspose.slides/datatable/setshowlegendkey/), e você pode ativá‑las ou desativá‑las.

**A tabela de dados será preservada ao exportar a apresentação para PDF, HTML ou imagens?**

Sim. O Aspose.Slides renderiza o gráfico como parte do slide, portanto o [PDF](/slides/pt/php-java/convert-powerpoint-to-pdf/)/[HTML](/slides/pt/php-java/convert-powerpoint-to-html/)/[image](/slides/pt/php-java/convert-powerpoint-to-png/) exportado inclui o gráfico com sua tabela de dados.

**Tabelas de dados são suportadas para gráficos que vêm de um arquivo de modelo?**

Sim. Para qualquer gráfico carregado de uma apresentação ou modelo existente, você pode verificar e alterar se uma tabela de dados está [is shown](https://reference.aspose.com/slides/pt/php-java/aspose.slides/chart/hasdatatable/) usando as propriedades do gráfico.

**Como posso encontrar rapidamente quais gráficos em um arquivo têm a tabela de dados habilitada?**

Inspecione a propriedade de cada gráfico que indica se a tabela de dados está [is shown](https://reference.aspose.com/slides/pt/php-java/aspose.slides/chart/hasdatatable/) e percorra os slides para identificar os gráficos em que ela está habilitada.