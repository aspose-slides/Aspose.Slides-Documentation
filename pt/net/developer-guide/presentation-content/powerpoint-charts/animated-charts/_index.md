---
title: Animar Gráficos PowerPoint em .NET
linktitle: Gráficos Animados
type: docs
weight: 80
url: /pt/net/animated-charts/
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
- .NET
- C#
- Aspose.Slides
description: "Crie gráficos animados impressionantes em .NET com Aspose.Slides. Impulsione apresentações com visuais dinâmicos em arquivos PPT e PPTX — comece agora."
---
## **Introdução**

O Aspose.Slides for .NET suporta a animação dos elementos de gráfico. **Séries**, **Categorias**, **Elementos de Série**, **Elementos de Categoria** podem ser animados com o método [ISequence.AddEffect](https://reference.aspose.com/slides/pt/net/aspose.slides.animation/isequence/methods/addeffect) e dois enums [EffectChartMajorGroupingType](https://reference.aspose.com/slides/pt/net/aspose.slides.animation/effectchartmajorgroupingtype) e [EffectChartMinorGroupingType](https://reference.aspose.com/slides/pt/net/aspose.slides.animation/effectchartminorgroupingtype).

## **Animação de Séries de Gráfico**
Se você quiser animar uma série de gráfico, escreva o código de acordo com as etapas listadas abaixo:

1. Carregue uma apresentação.
1. Obtenha a referência do objeto de gráfico.
1. Anime a série.
1. Grave o arquivo de apresentação no disco.

No exemplo abaixo, animamos a série do gráfico.

```c#
 // Instanciar a classe Presentation que representa um arquivo de apresentação 
 using (Presentation presentation = new Presentation("ExistingChart.pptx"))
 {
     // Obter referência do objeto de gráfico
     var slide = presentation.Slides[0] as Slide;
     var shapes = slide.Shapes as ShapeCollection;
     var chart = shapes[0] as IChart;

     // Animar a série
     slide.Timeline.MainSequence.AddEffect(chart, EffectType.Fade, EffectSubtype.None,
     EffectTriggerType.AfterPrevious);

     ((Sequence)slide.Timeline.MainSequence).AddEffect(chart,
     EffectChartMajorGroupingType.BySeries, 0,
     EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

     ((Sequence)slide.Timeline.MainSequence).AddEffect(chart,
     EffectChartMajorGroupingType.BySeries, 1,
     EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

     ((Sequence)slide.Timeline.MainSequence).AddEffect(chart,
     EffectChartMajorGroupingType.BySeries, 2,
     EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

     ((Sequence)slide.Timeline.MainSequence).AddEffect(chart,
     EffectChartMajorGroupingType.BySeries, 3,
     EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

     // Gravar a apresentação modificada no disco 
     presentation.Save("AnimatingSeries_out.pptx", SaveFormat.Pptx);
 }
```


## **Animação de Categoria de Gráfico**
Se você quiser animar uma categoria de gráfico, escreva o código de acordo com as etapas listadas abaixo:

1. Carregue uma apresentação.
1. Obtenha a referência do objeto de gráfico.
1. Anime a categoria.
1. Grave o arquivo de apresentação no disco.

No exemplo abaixo, animamos a categoria do gráfico.

```c#
using (Presentation presentation = new Presentation("ExistingChart.pptx"))
{
    // Obter referência do objeto de gráfico
    var slide = presentation.Slides[0] as Slide;
    var shapes = slide.Shapes as ShapeCollection;
    var chart = shapes[0] as IChart;

    // Animar elementos das categorias
    slide.Timeline.MainSequence.AddEffect(chart, EffectType.Fade, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 0, 0, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 0, 1, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 0, 2, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 0, 3, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 1, 0, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 1, 1, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 1, 2, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 1, 3, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 2, 0, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 2, 1, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 2, 2, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 2, 3, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    // Gravar o arquivo de apresentação no disco
    presentation.Save("AnimatingCategoriesElements_out.pptx", SaveFormat.Pptx);
}
```


## **Animação em um Elemento de Série**
Se você quiser animar elementos de série, escreva o código de acordo com as etapas listadas abaixo:

1. Carregue uma apresentação.
1. Obtenha a referência do objeto de gráfico.
1. Anime os elementos de série.
1. Grave o arquivo de apresentação no disco.

No exemplo abaixo, animamos os elementos das séries.

```c#
 // Load a presentation
using (Presentation presentation = new Presentation("ExistingChart.pptx"))
{
    // Get reference of the chart object
    var slide = presentation.Slides[0] as Slide;
    var shapes = slide.Shapes as ShapeCollection;
    var chart = shapes[0] as IChart;

    // Animate series elements
    slide.Timeline.MainSequence.AddEffect(chart, EffectType.Fade, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 0, 0, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 0, 1, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 0, 2, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 0, 3, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 1, 0, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 1, 1, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 1, 2, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 1, 3, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 2, 0, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 2, 1, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 2, 2, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 2, 3, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    // Write the presentation file to disk 
    presentation.Save("AnimatingSeriesElements_out.pptx", SaveFormat.Pptx);
}
```


## **Animação em um Elemento de Categoria**
Se você quiser animar elementos de categoria, escreva o código de acordo com as etapas listadas abaixo:

1. Carregue uma apresentação.
1. Obtenha a referência do objeto de gráfico.
1. Anime os elementos de categoria.
1. Grave o arquivo de apresentação no disco.

No exemplo abaixo, animamos os elementos de categoria.

```c#
using (Presentation presentation = new Presentation("ExistingChart.pptx"))
{
    // Obter referência do objeto de gráfico
    var slide = presentation.Slides[0] as Slide;
    var shapes = slide.Shapes as ShapeCollection;
    var chart = shapes[0] as IChart;

    // Animar elementos das categorias
    slide.Timeline.MainSequence.AddEffect(chart, EffectType.Fade, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 0, 0, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 0, 1, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 0, 2, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 0, 3, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 1, 0, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 1, 1, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 1, 2, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 1, 3, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 2, 0, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 2, 1, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 2, 2, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 2, 3, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    // Gravar o arquivo de apresentação no disco
    presentation.Save("AnimatingCategoriesElements_out.pptx", SaveFormat.Pptx);
}
```

## **FAQ**

**São suportados diferentes tipos de efeito (por exemplo, entrada, ênfase, saída) para gráficos como para formas regulares?**

Sim. Um gráfico é tratado como uma forma, portanto suporta os tipos padrão de efeitos de animação, incluindo entrada, ênfase e saída, com controle total através da linha do tempo do slide e das sequências de animação.

**Posso combinar animação de gráfico com transições de slide?**

Sim. As [Transitions](/slides/pt/net/slide-transition/) são aplicadas ao slide, enquanto os efeitos de animação são aplicados aos objetos no slide. Você pode usar ambos juntos na mesma apresentação e controlá‑los independentemente.

**As animações de gráfico são preservadas ao salvar em PPTX?**

Sim. Quando você [salva em PPTX](/slides/pt/net/save-presentation/), todos os efeitos de animação e sua ordem são preservados porque fazem parte do modelo de animação nativo da apresentação.

**Posso ler animações de gráfico existentes em uma apresentação e modificá‑las?**

Sim. A [API](https://reference.aspose.com/slides/pt/net/aspose.slides.animation/) fornece acesso à linha do tempo do slide, sequências e efeitos, permitindo inspecionar as animações de gráfico existentes e ajustá‑las sem recriar tudo do zero.

**Posso gerar um vídeo que inclua animações de gráfico usando Aspose.Slides?**

Sim. Você pode [exportar uma apresentação para vídeo](/slides/pt/net/convert-powerpoint-to-video/) mantendo as animações, configurando tempos e outras opções de exportação para que o clipe resultante reflita a reprodução animada.