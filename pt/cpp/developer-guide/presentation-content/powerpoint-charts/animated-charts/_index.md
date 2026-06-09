---
title: Animar Gráficos PowerPoint em C++
linktitle: Gráficos Animados
type: docs
weight: 80
url: /pt/cpp/animated-charts/
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
- C++
- Aspose.Slides
description: "Crie gráficos animados impressionantes em C++ com Aspose.Slides. Aprimore apresentações com visualizações dinâmicas em arquivos PPT e PPTX—comece agora."
---
## **Introdução**

Aspose.Slides oferece suporte à animação dos elementos do gráfico. **Series**, **Categories**, **Series Elements**, **Categories Elements** podem ser animados com o método [ISequence::AddEffect](https://reference.aspose.com/slides/pt/cpp/aspose.slides.animation/isequence/addeffect/) e dois enums [EffectChartMajorGroupingType](https://reference.aspose.com/slides/pt/cpp/aspose.slides.animation/effectchartmajorgroupingtype/) e [EffectChartMinorGroupingType](https://reference.aspose.com/slides/pt/cpp/aspose.slides.animation/effectchartminorgroupingtype/).

## **Animação de Série de Gráfico**
Se você quiser animar uma série de gráfico, escreva o código de acordo com as etapas listadas abaixo:

1. Carregue uma apresentação.
1. Obtenha a referência do objeto de gráfico.
1. Anime a série.
1. Grave o arquivo da apresentação no disco.

No exemplo abaixo, animamos a série de gráfico.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AnimatingSeries-AnimatingSeries.cpp" >}}

## **Animação em um Elemento de Série**
Se você quiser animar elementos de série, escreva o código de acordo com as etapas listadas abaixo:

1. Carregue uma apresentação.
1. Obtenha a referência do objeto de gráfico.
1. Anime os elementos da série.
1. Grave o arquivo da apresentação no disco.

No exemplo abaixo, animamos os elementos da série.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AnimatingSeriesElements-AnimatingSeriesElements.cpp" >}}

## **Animação de Categoria de Gráfico**
Se você quiser animar uma categoria de gráfico, escreva o código de acordo com as etapas listadas abaixo:

1. Carregue uma apresentação.
1. Obtenha a referência do objeto de gráfico.
1. Anime a Categoria.
1. Grave o arquivo da apresentação no disco.

No exemplo abaixo, animamos a categoria do gráfico.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AnimatingSeries-AnimatingSeries.cpp" >}}

## **Animação em um Elemento de Categoria**
Se você quiser animar elementos de categorias, escreva o código de acordo com as etapas listadas abaixo:

1. Carregue uma apresentação.
1. Obtenha a referência do objeto de gráfico.
1. Anime os elementos de categorias.
1. Grave o arquivo da apresentação no disco.

No exemplo abaixo, animamos os elementos de categorias.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AnimatingCategoriesElements-AnimatingCategoriesElements.cpp" >}}

## **FAQ**

**Tipos de efeito diferentes (por exemplo, entrada, ênfase, saída) são suportados para gráficos assim como para formas regulares?**

Sim. Um gráfico é tratado como uma forma, portanto suporta os tipos padrão de efeitos de animação, incluindo entrada, ênfase e saída, com controle total através da linha do tempo do slide e das sequências de animação.

**Posso combinar animação de gráfico com transições de slide?**

Sim. [Transitions](/slides/pt/cpp/slide-transition/) aplicam‑se ao slide, enquanto os efeitos de animação aplicam‑se aos objetos no slide. Você pode usar ambos juntos na mesma apresentação e controlá‑los independentemente.

**As animações de gráfico são preservadas ao salvar em PPTX?**

Sim. Quando você [save to PPTX](/slides/pt/cpp/save-presentation/), todos os efeitos de animação e sua ordem são preservados porque fazem parte do modelo nativo de animação da apresentação.

**Posso ler animações de gráfico existentes de uma apresentação e modificá‑las?**

Sim. A [API](https://reference.aspose.com/slides/pt/cpp/aspose.slides.animation/) fornece acesso à linha do tempo do slide, sequências e efeitos, permitindo inspecionar as animações de gráfico existentes e ajustá‑las sem recriar tudo do zero.

**Posso gerar um vídeo que inclua animações de gráfico usando Aspose.Slides?**

Sim. Você pode [exportar uma apresentação para vídeo](/slides/pt/cpp/convert-powerpoint-to-video/) preservando as animações, configurando os tempos e outras opções de exportação para que o clip resultante reflita a reprodução animada.