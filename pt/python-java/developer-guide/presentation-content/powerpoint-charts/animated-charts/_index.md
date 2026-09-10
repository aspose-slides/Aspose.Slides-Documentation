---
title: Animar Gráficos PowerPoint em Python via Java
linktitle: Gráficos Animados
type: docs
weight: 80
url: /pt/python-java/animated-charts/
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
- Python
- Java
- Aspose.Slides
description: "Crie gráficos animados impressionantes em Python via Java com Aspose.Slides. Impulsione apresentações com recursos visuais dinâmicos em arquivos PPT e PPTX — comece agora."
---
## **Introdução**

Aspose.Slides for Python via Java oferece suporte à animação de elementos de gráfico. **Series**, **Categories**, **Series Elements** e **Category Elements** podem ser animados usando o método [Sequence.addEffect](https://reference.aspose.com/slides/pt/python-java/aspose.slides/sequence/#addEffect) e duas enumerações: [EffectChartMajorGroupingType](https://reference.aspose.com/slides/pt/python-java/aspose.slides/effectchartmajorgroupingtype/) e [EffectChartMinorGroupingType](https://reference.aspose.com/slides/pt/python-java/aspose.slides/effectchartminorgroupingtype/).

## **Animação de Série de Gráfico**

Se você quiser animar uma série de gráfico, escreva o código de acordo com as etapas listadas abaixo:

1. Carregue uma apresentação.
1. Obtenha uma referência ao objeto de gráfico.
1. Anime a série.
1. Grave o arquivo de apresentação no disco.

O exemplo a seguir anima séries de gráfico. O gráfico no arquivo de exemplo possui três séries, portanto um efeito é adicionado para cada índice de 0 a 2. O Aspose.Slides não verifica o índice em relação aos dados do gráfico, e um efeito adicionado para uma série que não existe é gravado no arquivo, mas não anima nada — mantenha o índice abaixo do número de séries no seu próprio gráfico.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import EffectChartMajorGroupingType, EffectSubtype, EffectTriggerType, EffectType, Presentation, SaveFormat

# Carregar a apresentação.
presentation = Presentation("ExistingChart.pptx")
try:
    # Obter uma referência ao objeto de gráfico.
    slide = presentation.getSlides().get_Item(0)
    chart = slide.getShapes().get_Item(0)
    sequence = slide.getTimeline().getMainSequence()

    # Animar os elementos do gráfico.
    sequence.addEffect(chart, EffectType.Fade, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMajorGroupingType.BySeries, 0, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMajorGroupingType.BySeries, 1, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMajorGroupingType.BySeries, 2, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)

    # Gravar a apresentação modificada no disco.
    presentation.save("AnimatingSeries_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Animação de Categoria de Gráfico**

Se você quiser animar uma categoria de gráfico, escreva o código de acordo com as etapas listadas abaixo:

1. Carregue uma apresentação.
1. Obtenha uma referência ao objeto de gráfico.
1. Anime a categoria.
1. Grave o arquivo de apresentação no disco.

O exemplo a seguir anima categorias de gráfico.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import EffectChartMajorGroupingType, EffectSubtype, EffectTriggerType, EffectType, Presentation, SaveFormat

# Carregar a apresentação.
presentation = Presentation("ExistingChart.pptx")
try:
    # Obter uma referência ao objeto de gráfico.
    slide = presentation.getSlides().get_Item(0)
    chart = slide.getShapes().get_Item(0)
    sequence = slide.getTimeline().getMainSequence()

    # Animar os elementos do gráfico.
    sequence.addEffect(chart, EffectType.Fade, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMajorGroupingType.ByCategory, 0, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMajorGroupingType.ByCategory, 1, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMajorGroupingType.ByCategory, 2, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMajorGroupingType.ByCategory, 3, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)

    # Gravar a apresentação modificada no disco.
    presentation.save("Sample_Animation_C.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Animação em um Elemento de Série**

Se você quiser animar elementos de série, escreva o código de acordo com as etapas listadas abaixo:

1. Carregue uma apresentação.
1. Obtenha uma referência ao objeto de gráfico.
1. Anime elementos de série.
1. Grave o arquivo de apresentação no disco.

O exemplo a seguir anima elementos de série.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import EffectChartMinorGroupingType, EffectSubtype, EffectTriggerType, EffectType, Presentation, SaveFormat

# Carregar a apresentação.
presentation = Presentation("ExistingChart.pptx")
try:
    # Obter uma referência ao objeto de gráfico.
    slide = presentation.getSlides().get_Item(0)
    chart = slide.getShapes().get_Item(0)
    sequence = slide.getTimeline().getMainSequence()

    # Animar os elementos do gráfico.
    sequence.addEffect(chart, EffectType.Fade, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 0, 0, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 0, 1, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 0, 2, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 0, 3, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 1, 0, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 1, 1, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 1, 2, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 1, 3, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 2, 0, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 2, 1, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 2, 2, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 2, 3, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)

    # Gravar a apresentação modificada no disco.
    presentation.save("AnimatingSeriesElements_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Animação em um Elemento de Categoria**

Se você quiser animar elementos de categoria, escreva o código de acordo com as etapas listadas abaixo:

1. Carregue uma apresentação.
1. Obtenha uma referência ao objeto de gráfico.
1. Anime elementos de categoria.
1. Grave o arquivo de apresentação no disco.

O exemplo a seguir anima elementos de categoria.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import EffectChartMinorGroupingType, EffectSubtype, EffectTriggerType, EffectType, Presentation, SaveFormat

# Carregar a apresentação.
presentation = Presentation("ExistingChart.pptx")
try:
    # Obter uma referência ao objeto de gráfico.
    slide = presentation.getSlides().get_Item(0)
    chart = slide.getShapes().get_Item(0)
    sequence = slide.getTimeline().getMainSequence()

    # Animar os elementos do gráfico.
    sequence.addEffect(chart, EffectType.Fade, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 0, 0, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 0, 1, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 0, 2, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 0, 3, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 1, 0, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 1, 1, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 1, 2, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 1, 3, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 2, 0, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 2, 1, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 2, 2, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 2, 3, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)

    # Gravar a apresentação modificada no disco.
    presentation.save("AnimatingCategoriesElements_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Perguntas Frequentes**

**Tipos diferentes de efeito (por exemplo, entrada, ênfase, saída) são suportados para gráficos como para formas regulares?**

Sim. Um gráfico é tratado como uma forma, portanto suporta os tipos padrão de efeitos de animação, incluindo entrada, ênfase e saída, com controle total através da linha do tempo do slide e das sequências de animação.

**Posso combinar animação de gráfico com transições de slide?**

Sim. [Transitions](/slides/pt/python-java/slide-transition/) aplicam‑se ao slide, enquanto os efeitos de animação aplicam‑se aos objetos no slide. Você pode usar ambos juntos na mesma apresentação e controlá‑los independentemente.

**As animações de gráfico são preservadas ao salvar em PPTX?**

Sim. Quando você [save to PPTX](/slides/pt/python-java/save-presentation/), todos os efeitos de animação e sua ordem são preservados porque fazem parte do modelo nativo de animação da apresentação.

**Posso ler animações de gráfico existentes de uma apresentação e modificá‑las?**

Sim. A API fornece acesso à linha do tempo do slide, sequências e efeitos, permitindo que você inspecione as animações de gráfico existentes e as ajuste sem precisar recriar tudo do zero.

**Posso gerar um vídeo que inclua animações de gráfico usando Aspose.Slides?**

Sim. Você pode [export a presentation to video](/slides/pt/python-java/convert-powerpoint-to-video/) enquanto preserva as animações, configurando tempos e outras configurações de exportação para que o clipe resultante reflita a reprodução animada.