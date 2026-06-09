---
title: Exportar gráficos de apresentação em PHP
linktitle: Exportar Gráfico
type: docs
weight: 90
url: /pt/php-java/export-chart/
keywords:
- gráfico
- gráfico para imagem
- gráfico como imagem
- extrair imagem do gráfico
- PowerPoint
- apresentação
- PHP
- Aspose.Slides
description: "Aprenda como exportar gráficos de apresentação com Aspose.Slides para PHP via Java, suportando os formatos PPT e PPTX, e simplifique a geração de relatórios em qualquer fluxo de trabalho."
---
## **Visão geral**

Aspose.Slides permite exportar um gráfico de uma apresentação como imagem. Este artigo mostra como obter uma imagem de um gráfico e salvá-la, o que é útil quando você precisa reutilizar os gráficos fora de uma apresentação do PowerPoint.

## **Obter uma imagem de gráfico**
Aspose.Slides for PHP via Java oferece suporte para extrair a imagem de um gráfico específico. Abaixo é apresentado um exemplo de amostra.

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 600, 400);
    $slideImage = $chart->getImage();
    try {
      $slideImage->save("image.jpg", ImageFormat::Jpeg);
    } finally {
      if (!java_is_null($slideImage)) {
        $slideImage->dispose();
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Perguntas frequentes**

**Posso exportar um gráfico como vetor (SVG) em vez de uma imagem raster?**

Sim. Um gráfico é uma forma, e seu conteúdo pode ser salvo em SVG usando o [método de salvamento shape-to-SVG](https://reference.aspose.com/slides/pt/php-java/aspose.slides/shape/writeassvg/).

**Como posso definir o tamanho exato do gráfico exportado em pixels?**

Use as sobrecargas de renderização de imagem que permitem especificar tamanho ou escala - a biblioteca oferece suporte à renderização de objetos com dimensões/escala definidas.

**O que devo fazer se as fontes em rótulos e na legenda ficarem incorretas após a exportação?**

[Carregue as fontes necessárias](/slides/pt/php-java/custom-font/) via [FontsLoader](https://reference.aspose.com/slides/pt/php-java/aspose.slides/fontsloader/) para que a renderização do gráfico preserve as métricas e a aparência do texto.

**A exportação respeita o tema, estilos e efeitos do PowerPoint?**

Sim. O renderizador do Aspose.Slides segue a formatação da apresentação (temas, estilos, preenchimentos, efeitos), de modo que a aparência do gráfico seja preservada.

**Onde posso encontrar recursos de renderização/exportação disponíveis além de imagens de gráficos?**

Consulte a [API](https://reference.aspose.com/slides/pt/php-java/aspose.slides/)/[documentação](/slides/pt/php-java/convert-powerpoint/) para destinos de saída ([PDF](/slides/pt/php-java/convert-powerpoint-to-pdf/), [SVG](/slides/pt/php-java/render-a-slide-as-an-svg-image/), [XPS](/slides/pt/php-java/convert-powerpoint-to-xps/), [HTML](/slides/pt/php-java/convert-powerpoint-to-html/), etc.) e opções de renderização relacionadas.