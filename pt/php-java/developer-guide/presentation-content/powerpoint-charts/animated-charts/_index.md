---
title: Animar Gráficos PowerPoint em PHP
linktitle: Gráficos Animados
type: docs
weight: 80
url: /pt/php-java/animated-charts/
keywords:
- gráfico
- gráfico animado
- animação de gráfico
- série de gráfico
- categoria de gráfico
- elemento de série
- elemento de categoria
- adicionar efeito
- tipo de efeito
- PowerPoint
- apresentação
- PHP
- Aspose.Slides
description: "Crie gráficos animados impressionantes com Aspose.Slides for PHP via Java. Impulsione apresentações com visuais dinâmicos em arquivos PPT e PPTX — comece agora."
---
## **Introdução**

Aspose.Slides for PHP via Java suporta a animação dos elementos do gráfico. **Series**, **Categories**, **Series Elements**, **Categories Elements** podem ser animados com o método [Sequence::addEffect](https://reference.aspose.com/slides/pt/php-java/aspose.slides/sequence/#addEffect) e dois enums [EffectChartMajorGroupingType](https://reference.aspose.com/slides/pt/php-java/aspose.slides/EffectChartMajorGroupingType) e [EffectChartMinorGroupingType](https://reference.aspose.com/slides/pt/php-java/aspose.slides/EffectChartMinorGroupingType).

## **Animação de Série de Gráfico**
Se você quiser animar uma série de gráfico, escreva o código de acordo com as etapas listadas abaixo:

1. Carregue uma apresentação.
1. Obtenha referência do objeto de gráfico.
1. Anime a série.
1. Grave o arquivo de apresentação no disco.

Neste exemplo abaixo, animamos a série do gráfico.

```php
  # Instanciar a classe Presentation que representa um arquivo de apresentação
  $pres = new Presentation("ExistingChart.pptx");
  try {
    # Obter referência do objeto de gráfico
    $slide = $pres->getSlides()->get_Item(0);
    $shapes = $slide->getShapes();
    $chart = $shapes->get_Item(0);
    # Animar a série
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectType::Fade, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMajorGroupingType::BySeries, 0, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMajorGroupingType::BySeries, 1, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMajorGroupingType::BySeries, 2, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMajorGroupingType::BySeries, 3, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    # Gravar a apresentação modificada no disco
    $pres->save("AnimatingSeries_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Animação de Categoria de Gráfico**
Se você quiser animar uma categoria de gráfico, escreva o código de acordo com as etapas listadas abaixo:

1. Carregue uma apresentação.
1. Obtenha referência do objeto de gráfico.
1. Anime a categoria.
1. Grave o arquivo de apresentação no disco.

Neste exemplo abaixo, animamos a categoria do gráfico.

```php
  # Instanciar a classe Presentation que representa um arquivo de apresentação
  $pres = new Presentation("ExistingChart.pptx");
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $shapes = $slide->getShapes();
    $chart = $shapes->get_Item(0);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectType::Fade, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMajorGroupingType::ByCategory, 0, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMajorGroupingType::ByCategory, 1, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMajorGroupingType::ByCategory, 2, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMajorGroupingType::ByCategory, 3, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $pres->save("Sample_Animation_C.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Animação em um Elemento de Série**
Se você quiser animar elementos de série, escreva o código de acordo com as etapas listadas abaixo:

1. Carregue uma apresentação.
1. Obtenha referência do objeto de gráfico.
1. Anime os elementos da série.
1. Grave o arquivo de apresentação no disco.

Neste exemplo abaixo, animamos os elementos da série.

```php
  # Instanciar Presentation class que representa um arquivo de apresentação
  $pres = new Presentation("ExistingChart.pptx");
  try {
    # Obter referência do objeto de gráfico
    $slide = $pres->getSlides()->get_Item(0);
    $shapes = $slide->getShapes();
    $chart = $shapes->get_Item(0);
    # Animar elementos da série
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectType::Fade, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMinorGroupingType::ByElementInSeries, 0, 0, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMinorGroupingType::ByElementInSeries, 0, 1, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMinorGroupingType::ByElementInSeries, 0, 2, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMinorGroupingType::ByElementInSeries, 0, 3, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMinorGroupingType::ByElementInSeries, 1, 0, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMinorGroupingType::ByElementInSeries, 1, 1, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMinorGroupingType::ByElementInSeries, 1, 2, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMinorGroupingType::ByElementInSeries, 1, 3, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMinorGroupingType::ByElementInSeries, 2, 0, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMinorGroupingType::ByElementInSeries, 2, 1, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMinorGroupingType::ByElementInSeries, 2, 2, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMinorGroupingType::ByElementInSeries, 2, 3, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    # Gravar o arquivo de apresentação no disco
    $pres->save("AnimatingSeriesElements_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Animação em um Elemento de Categoria**
Se você quiser animar elementos de categorias, escreva o código de acordo com as etapas listadas abaixo:

1. Carregue uma apresentação.
1. Obtenha referência do objeto de gráfico.
1. Anime os elementos de categorias.
1. Grave o arquivo de apresentação no disco.

Neste exemplo abaixo, animamos os elementos de categorias.

```php
  # Instanciar a classe Presentation que representa um arquivo de apresentação
  $pres = new Presentation("ExistingChart.pptx");
  try {
    # Obter referência do objeto de gráfico
    $slide = $pres->getSlides()->get_Item(0);
    $shapes = $slide->getShapes();
    $chart = $shapes->get_Item(0);
    # Animar os elementos das categorias
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectType::Fade, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMinorGroupingType::ByElementInCategory, 0, 0, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMinorGroupingType::ByElementInCategory, 0, 1, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMinorGroupingType::ByElementInCategory, 0, 2, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMinorGroupingType::ByElementInCategory, 0, 3, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMinorGroupingType::ByElementInCategory, 1, 0, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMinorGroupingType::ByElementInCategory, 1, 1, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMinorGroupingType::ByElementInCategory, 1, 2, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMinorGroupingType::ByElementInCategory, 1, 3, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMinorGroupingType::ByElementInCategory, 2, 0, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMinorGroupingType::ByElementInCategory, 2, 1, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMinorGroupingType::ByElementInCategory, 2, 2, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMinorGroupingType::ByElementInCategory, 2, 3, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    # Gravar o arquivo de apresentação no disco
    $pres->save("AnimatingCategoriesElements_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Perguntas Frequentes**

**Os diferentes tipos de efeito (por exemplo, entrada, ênfase, saída) são suportados para gráficos como para formas regulares?**

Sim. Um gráfico é tratado como uma forma, portanto suporta os tipos padrão de efeito de animação, incluindo entrada, ênfase e saída, com controle total através da linha do tempo do slide e das sequências de animação.

**Posso combinar animação de gráfico com transições de slide?**

Sim. [Transitions](/slides/pt/php-java/slide-transition/) aplicam‑se ao slide, enquanto os efeitos de animação se aplicam aos objetos do slide. Você pode usar ambos juntos na mesma apresentação e controlá‑los independentemente.

**As animações de gráfico são preservadas ao salvar em PPTX?**

Sim. Quando você [save to PPTX](/slides/pt/php-java/save-presentation/), todos os efeitos de animação e sua ordem são preservados porque fazem parte do modelo nativo de animação da apresentação.

**Posso ler animações de gráfico existentes de uma apresentação e modificá‑las?**

Sim. A API fornece acesso à linha do tempo do slide, sequências e efeitos, permitindo inspecionar animações de gráfico existentes e ajustá‑las sem recriar tudo do zero.

**Posso gerar um vídeo que inclua animações de gráfico usando Aspose.Slides?**

Sim. Você pode [export a presentation to video](/slides/pt/php-java/convert-powerpoint-to-video/) preservando as animações, configurando tempos e outras configurações de exportação para que o clipe resultante reflita a reprodução animada.