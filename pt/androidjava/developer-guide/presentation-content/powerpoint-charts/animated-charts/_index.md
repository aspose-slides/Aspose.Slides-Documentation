---
title: Animar gráficos do PowerPoint no Android
linktitle: Gráficos animados
type: docs
weight: 80
url: /pt/androidjava/animated-charts/
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
- Android
- Java
- Aspose.Slides
description: "Crie gráficos animados impressionantes em Java com Aspose.Slides para Android. Impulsione apresentações com visualizações dinâmicas em arquivos PPT e PPTX—comece agora."
---
## **Introdução**

Aspose.Slides for Android via Java oferece suporte à animação dos elementos do gráfico. **Series**, **Categories**, **Series Elements**, **Categories Elements** podem ser animados com o método [ISequence.addEffect](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/ISequence#addEffect-com.aspose.slides.IChart-int-int-int-int-int-) e dois enums [EffectChartMajorGroupingType](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/EffectChartMajorGroupingType) e [EffectChartMinorGroupingType](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/EffectChartMinorGroupingType).

## **Animação da Série de Gráfico**
Se você deseja animar uma série de gráfico, escreva o código de acordo com as etapas listadas abaixo:

1. Carregue uma apresentação.
1. Obtenha a referência do objeto de gráfico.
1. Anime a série.
1. Grave o arquivo da apresentação no disco.

No exemplo abaixo, animamos a série do gráfico.

```java
// Instanciar a classe Presentation que representa um arquivo de apresentação
Presentation pres = new Presentation("ExistingChart.pptx");
try {
    // Obter referência do objeto de gráfico
    ISlide slide = pres.getSlides().get_Item(0);
    IShapeCollection shapes = slide.getShapes();
    IChart chart = (IChart) shapes.get_Item(0);

    // Animar a série
    slide.getTimeline().getMainSequence().addEffect(chart, EffectType.Fade, EffectSubtype.None,
            EffectTriggerType.AfterPrevious);

    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart,
            EffectChartMajorGroupingType.BySeries, 0,
            EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart,
            EffectChartMajorGroupingType.BySeries, 1,
            EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart,
            EffectChartMajorGroupingType.BySeries, 2,
            EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart,
            EffectChartMajorGroupingType.BySeries, 3,
            EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    // Gravar a apresentação modificada no disco
    pres.save("AnimatingSeries_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Animação de Categoria de Gráfico**
Se você deseja animar uma categoria de gráfico, escreva o código de acordo com as etapas listadas abaixo:

1. Carregue uma apresentação.
1. Obtenha a referência do objeto de gráfico.
1. Anime a categoria.
1. Grave o arquivo da apresentação no disco.

No exemplo abaixo, animamos a categoria do gráfico.

```java
// Instanciar a classe Presentation que representa um arquivo de apresentação
Presentation pres = new Presentation("ExistingChart.pptx");
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IShapeCollection shapes = slide.getShapes();
    IChart chart = (IChart) shapes.get_Item(0);

    slide.getTimeline().getMainSequence().addEffect(chart, EffectType.Fade, EffectSubtype.None,
            EffectTriggerType.AfterPrevious);

    ((Sequence) slide.getTimeline().getMainSequence()).addEffect(chart,
            EffectChartMajorGroupingType.ByCategory, 0, 
            EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    
    ((Sequence) slide.getTimeline().getMainSequence()).addEffect(chart, 
            EffectChartMajorGroupingType.ByCategory, 1, 
            EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    
    ((Sequence) slide.getTimeline().getMainSequence()).addEffect(chart, 
            EffectChartMajorGroupingType.ByCategory, 2, 
            EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    
    ((Sequence) slide.getTimeline().getMainSequence()).addEffect(chart, 
            EffectChartMajorGroupingType.ByCategory, 3, 
            EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    pres.save("Sample_Animation_C.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Animação em um Elemento de Série**
Se você deseja animar elementos de série, escreva o código de acordo com as etapas listadas abaixo:

1. Carregue uma apresentação.
1. Obtenha a referência do objeto de gráfico.
1. Anime os elementos da série.
1. Grave o arquivo da apresentação no disco.

No exemplo abaixo, animamos os elementos da série.

```java
// Instanciar a classe Presentation que representa um arquivo de apresentação
Presentation pres = new Presentation("ExistingChart.pptx");
try {
    // Obter referência do objeto de gráfico
    ISlide slide = pres.getSlides().get_Item(0);
    IShapeCollection shapes = slide.getShapes();
    IChart chart = (IChart) shapes.get_Item(0);

    // Animar elementos da série
    slide.getTimeline().getMainSequence().addEffect(chart, EffectType.Fade, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 
            0, 0, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 
            0, 1, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 
            0, 2, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 
            0, 3, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 
            1, 0, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 
            1, 1, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 
            1, 2, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 
            1, 3, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 
            2, 0, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 
            2, 1, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 
            2, 2, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 
            2, 3, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    // Gravar o arquivo da apresentação no disco 
    pres.save("AnimatingSeriesElements_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Animação em um Elemento de Categoria**
Se você deseja animar elementos de categoria, escreva o código de acordo com as etapas listadas abaixo:

1. Carregue uma apresentação.
1. Obtenha a referência do objeto de gráfico.
1. Anime os elementos de categoria.
1. Grave o arquivo da apresentação no disco.

No exemplo abaixo, animamos os elementos de categoria.

```java
// Instanciar a classe Presentation que representa um arquivo de apresentação
Presentation pres = new Presentation("ExistingChart.pptx");
try {
    // Obter referência do objeto de gráfico
    ISlide slide = pres.getSlides().get_Item(0);
    IShapeCollection shapes = slide.getShapes();
    IChart chart = (IChart) shapes.get_Item(0);

    // Animar elementos das categorias
    slide.getTimeline().getMainSequence().addEffect(chart, EffectType.Fade, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 
            0, 0, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 
            0, 1, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 
            0, 2, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 
            0, 3, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 
            1, 0, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 
            1, 1, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 
            1, 2, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 
            1, 3, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 
            2, 0, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 
            2, 1, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 
            2, 2, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 
            2, 3, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    // Gravar o arquivo da apresentação no disco
    pres.save("AnimatingCategoriesElements_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**Tipos diferentes de efeito (por exemplo, entrada, ênfase, saída) são suportados para gráficos como para formas regulares?**

Sim. Um gráfico é tratado como uma forma, portanto suporta os tipos padrão de efeitos de animação, incluindo entrada, ênfase e saída, com controle total por meio da linha do tempo do slide e das sequências de animação.

**Posso combinar animação de gráfico com transições de slide?**

Sim. [Transitions](/slides/pt/androidjava/slide-transition/) aplicam-se ao slide, enquanto os efeitos de animação aplicam-se aos objetos no slide. Você pode usar ambos juntos na mesma apresentação e controlá‑los independentemente.

**As animações de gráfico são preservadas ao salvar em PPTX?**

Sim. Quando você [salvar em PPTX](/slides/pt/androidjava/save-presentation/), todos os efeitos de animação e sua ordem são preservados porque fazem parte do modelo nativo de animação da apresentação.

**Posso ler animações de gráfico existentes de uma apresentação e modificá‑las?**

Sim. A API fornece acesso à linha do tempo do slide, sequências e efeitos, permitindo que você inspeccione as animações de gráfico existentes e as ajuste sem recriar tudo do zero.

**Posso gerar um vídeo que inclua animações de gráfico usando Aspose.Slides?**

Sim. Você pode [exportar uma apresentação para vídeo](/slides/pt/androidjava/convert-powerpoint-to-video/) mantendo as animações, configurando os tempos e outras configurações de exportação para que o clipe resultante reflita a reprodução animada.