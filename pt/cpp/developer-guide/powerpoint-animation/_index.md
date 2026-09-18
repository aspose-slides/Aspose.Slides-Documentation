---
title: Aprimore Apresentações PowerPoint com Animações em C++
linktitle: Animação PowerPoint
type: docs
weight: 150
url: /pt/cpp/powerpoint-animation/
keywords:
- adicionar animação
- atualizar animação
- alterar animação
- remover animação
- gerenciar animação
- controlar animação
- efeito de animação
- animação PowerPoint
- linha do tempo de animação
- animação interativa
- animação personalizada
- animação de forma
- gráfico animado
- texto animado
- forma animada
- objeto OLE animado
- imagem animada
- tabela animada
- PowerPoint
- apresentação
- C++
- Aspose.Slides
description: "Aprenda como adicionar e controlar efeitos avançados de animação no Aspose.Slides para C++ para criar apresentações dinâmicas em PowerPoint e OpenDocument."
---
## **Introdução**

Como as apresentações destinam‑se a apresentar algo, sua aparência visual e o comportamento interativo são sempre levados em consideração durante a criação.

**PowerPoint animation** desempenha um papel importante ao tornar uma apresentação atraente e envolvente para os espectadores. Aspose.Slides fornece uma ampla variedade de opções para adicionar animações a apresentações PowerPoint:

- Aplicar vários tipos de efeitos de animação PowerPoint a formas, gráficos, tabelas, objetos OLE e outros elementos da apresentação.
- Usar múltiplos efeitos de animação PowerPoint em uma única forma.
- Utilizar a linha do tempo de animação para controlar os efeitos de animação.
- Criar animações personalizadas.

No Aspose.Slides, vários efeitos de animação podem ser aplicados a formas. Como cada elemento em um slide, incluindo texto, imagens, objetos OLE e tabelas, é considerado uma forma, os efeitos de animação podem ser aplicados a qualquer elemento do slide.

O namespace [Aspose::Slides::Animation](https://reference.aspose.com/slides/pt/cpp/aspose.slides.animation/) fornece classes para trabalhar com animações PowerPoint.

## **Efeitos de Animação**
Aspose.Slides oferece **mais de 150 efeitos de animação**, incluindo efeitos básicos como Bounce, PathFootball e Zoom, e efeitos específicos como OLEObjectShow e OLEObjectOpen. Você pode encontrar uma lista completa na enumeração [EffectType](https://reference.aspose.com/slides/pt/cpp/aspose.slides.animation/effecttype/).

Além disso, esses efeitos de animação podem ser usados em combinação com os seguintes comportamentos:

- [ColorEffect](https://reference.aspose.com/slides/pt/cpp/aspose.slides.animation/coloreffect/)
- [CommandEffect](https://reference.aspose.com/slides/pt/cpp/aspose.slides.animation/commandeffect/)
- [FilterEffect](https://reference.aspose.com/slides/pt/cpp/aspose.slides.animation/filtereffect/)
- [MotionEffect](https://reference.aspose.com/slides/pt/cpp/aspose.slides.animation/motioneffect/)
- [PropertyEffect](https://reference.aspose.com/slides/pt/cpp/aspose.slides.animation/propertyeffect/)
- [RotationEffect](https://reference.aspose.com/slides/pt/cpp/aspose.slides.animation/rotationeffect/)
- [ScaleEffect](https://reference.aspose.com/slides/pt/cpp/aspose.slides.animation/scaleeffect/)
- [SetEffect](https://reference.aspose.com/slides/pt/cpp/aspose.slides.animation/seteffect/)

## **Animação Personalizada**

Para exemplos completos em C++ que criam, inspecionam e modificam comportamentos e caminhos de movimento editáveis, veja [Animação Personalizada](/slides/pt/cpp/custom-animation/).

É possível criar suas próprias **animações personalizadas** no Aspose.Slides. Isso pode ser alcançado combinando vários comportamentos em uma nova animação personalizada.

[Behavior](https://reference.aspose.com/slides/pt/cpp/aspose.slides.animation/behavior/) é um bloco de construção de um efeito de animação PowerPoint. Combine comportamentos para personalizar um efeito, ou adicione um comportamento para estender um efeito predefinido. A repetição é configurada através das configurações de tempo, em vez de um comportamento de repetição separado.

[Animation Point](https://reference.aspose.com/slides/pt/cpp/aspose.slides.animation/point/) é um ponto no qual um comportamento deve ser aplicado.

## **Linha do Tempo de Animação**
[Sequence](https://reference.aspose.com/slides/pt/cpp/aspose.slides.animation/sequence/) é uma coleção de efeitos de animação que podem atingir diferentes formas.

[IAnimationTimeLine](https://reference.aspose.com/slides/pt/cpp/aspose.slides/ianimationtimeline/) é um conjunto de sequências usado em um slide específico. É um motor de animação introduzido no PowerPoint 2002. Nas versões anteriores do PowerPoint, adicionar efeitos de animação a apresentações era desafiador e só podia ser conseguido com várias soluções alternativas. A linha do tempo fornece um modelo de objeto mais claro para animações PowerPoint. Um slide pode ter apenas uma linha do tempo de animação.

## **Animação Interativa**
[Trigger](https://reference.aspose.com/slides/pt/cpp/aspose.slides.animation/effecttriggertype/) permite definir ações do usuário, como um clique de botão, que iniciam uma animação específica.

## **Animação de Forma**
Aspose.Slides permite aplicar animações a formas, que podem incluir texto, retângulos, linhas, quadros, objetos OLE e muito mais.

{{% alert color="info" title="Note" %}}
Saiba mais [**Sobre Animação de Forma**](/slides/pt/cpp/shape-animation/).
{{% /alert %}}

## **Gráficos Animados**
Para criar gráficos animados, você deve usar as mesmas classes que para formas. No entanto, as animações PowerPoint só podem ser aplicadas a categorias de gráfico ou séries de gráfico. Você também pode aplicar efeitos de animação a um elemento de categoria ou a um elemento de série.

{{% alert color="info" title="Note" %}}
Saiba mais [**Sobre Gráficos Animados**](/slides/pt/cpp/animated-charts/).
{{% /alert %}}

## **Texto Animado**
Além de animar texto, você pode aplicar animação a um parágrafo.

{{% alert color="info" title="Note" %}}
Saiba mais [**Sobre Texto Animado**](/slides/pt/cpp/animated-text/).
{{% /alert %}}

## **Perguntas Frequentes**

**As animações serão preservadas ao exportar para PDF?**

Não. PDF é um formato estático, portanto animações e [transições de slides](/slides/pt/cpp/slide-transition/) não são reproduzidas. Se precisar de movimento, exporte para [HTML5](/slides/pt/cpp/export-to-html5/), [GIF animado](/slides/pt/cpp/convert-powerpoint-to-animated-gif/), ou [vídeo](/slides/pt/cpp/convert-powerpoint-to-video/) em vez disso.

**Posso transformar uma apresentação animada em vídeo e controlar a taxa de quadros e o tamanho do quadro?**

Sim. Você pode [renderizar a apresentação como quadros](/slides/pt/cpp/convert-powerpoint-to-video/) e codificá‑los em um vídeo (por exemplo, via ffmpeg), escolhendo os FPS e a resolução. As animações e as transições de slides são reproduzidas durante a renderização.

**As animações permanecerão intactas ao trabalhar com ODP (não apenas PPTX)?**

PPT, PPTX e ODP são suportados para [leitura](/slides/pt/cpp/open-presentation/) e [gravação](/slides/pt/cpp/save-presentation/), mas isso não garante a preservação das animações. Dados de animação personalizada podem ser perdidos ao converter para ODP. Consulte [Custom Animation](/slides/pt/cpp/custom-animation/) para exemplos e orientações sobre como verificar a compatibilidade de formatos.