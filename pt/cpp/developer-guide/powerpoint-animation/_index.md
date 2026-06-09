---
title: Aprimorar Apresentações PowerPoint com Animações em C++
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

Como as apresentações têm o objetivo de apresentar algo, sua aparência visual e comportamento interativo são sempre considerados ao criá‑las.

**Animação do PowerPoint** desempenha um papel importante para tornar a apresentação atraente e chamativa para os espectadores. Aspose.Slides for C++ oferece uma ampla variedade de opções para adicionar animação a uma apresentação PowerPoint:

- aplicar vários tipos de efeitos de animação do PowerPoint em formas, gráficos, tabelas, objetos OLE e outros elementos da apresentação.
- usar múltiplos efeitos de animação do PowerPoint em uma forma.
- usar a linha do tempo de animação para controlar os efeitos de animação.
- criar animação personalizada.

No Aspose.Slides for C++, vários efeitos de animação podem ser aplicados nas formas. Como cada elemento do slide, incluindo texto, imagens, objeto OLE, tabela etc., é considerado uma forma, isso significa que podemos aplicar efeitos de animação em todos os elementos de um slide.

[**Aspose.Slides.Animation**](https://reference.aspose.com/slides/pt/cpp/namespace/aspose.slides.animation) **namespace** fornece classes para trabalhar com animações do PowerPoint.
## **Efeitos de Animação**

Aspose.Slides oferece suporte a **mais de 150 efeitos de animação**, incluindo efeitos básicos como Bounce, PathFootball, efeito Zoom e efeitos específicos como OLEObjectShow, OLEObjectOpen. Você pode encontrar uma lista completa de efeitos de animação em [**EffectType**](https://reference.aspose.com/slides/pt/cpp/namespace/aspose.slides.animation#ae0da11508d382465aa4e7a011df1bf31)enumeration.

Além disso, esses efeitos de animação podem ser usados em combinação com eles:

- [ColorEffect](https://reference.aspose.com/slides/pt/cpp/aspose.slides.animation/coloreffect/)
- [CommandEffect](https://reference.aspose.com/slides/pt/cpp/class/aspose.slides.animation.command_effect)
- [FilterEffect](https://reference.aspose.com/slides/pt/cpp/class/aspose.slides.animation.filter_effect)
- [MotionEffect](https://reference.aspose.com/slides/pt/cpp/class/aspose.slides.animation.motion_effect)
- [PropertyEffect](https://reference.aspose.com/slides/pt/cpp/class/aspose.slides.animation.property_effect)
- [RotationEffect](https://reference.aspose.com/slides/pt/cpp/class/aspose.slides.animation.rotation_effect)
- [ScaleEffect](https://reference.aspose.com/slides/pt/cpp/class/aspose.slides.animation.scale_effect)
- [SetEffect](https://reference.aspose.com/slides/pt/cpp/class/aspose.slides.animation.set_effect)

## **Animação Personalizada**

É possível criar suas próprias **animações personalizadas** no Aspose.Slides. Isso pode ser alcançado se você combinar vários comportamentos em uma nova animação personalizada.

[**Behavior**](https://reference.aspose.com/slides/pt/cpp/class/aspose.slides.animation.behavior) é uma unidade de construção de qualquer efeito de animação do PowerPoint. Todos os efeitos de animação são na verdade um conjunto de comportamentos compostos em uma estratégia única. Você pode combinar comportamentos em uma animação personalizada uma vez e reutilizá‑la em outras apresentações. Se você adicionar um novo comportamento a um efeito de animação padrão do PowerPoint, ele se tornará outra animação personalizada. Por exemplo, você pode adicionar um comportamento de repetição a uma animação para que ela se repita algumas vezes.

[**Animation Point**](https://reference.aspose.com/slides/pt/cpp/class/aspose.slides.animation.point) é um ponto onde o comportamento deve ser aplicado.

## **Linha do Tempo de Animação**

[**Sequence**](https://reference.aspose.com/slides/pt/cpp/class/aspose.slides.animation.sequence) é uma coleção de efeitos de animação, aplicada em uma forma concreta.

[**AnimationTimeLine**](https://reference.aspose.com/slides/pt/cpp/class/aspose.slides.animation.animation_time_line) é um conjunto de Sequences usado em um slide concreto. É um mecanismo de animação representado desde o PowerPoint 2002. Nas versões anteriores do PowerPoint, era difícil adicionar efeitos de animação à apresentação, o que só podia ser feito através de diferentes soluções alternativas. A Timeline substitui a antiga classe AnimationSettings e fornece um modelo de objeto mais claro para a animação do PowerPoint. Um slide pode ter apenas uma timeline de animação.

## **Animação Interativa**

[**EffectTriggerType**](https://reference.aspose.com/slides/pt/cpp/namespace/aspose.slides.animation#add24fb49dd44eb3227aeeb3641fd2e81) permite definir ações do usuário (por exemplo, clique de botão), que iniciarão uma determinada animação. Os gatilhos foram adicionados apenas na versão mais recente do PowerPoint.

## **Animação de Forma**

Aspose.Slides permite aplicar animação a formas, que podem ser texto, retângulo, linha, quadro, objeto OLE etc.

{{% alert color="primary" %}} 
Leia mais [**Sobre Animação de Forma**](/slides/pt/cpp/shape-animation/).
{{% /alert %}}

## **Gráficos Animados**

Para criar gráficos animados, você deve usar as mesmas classes que para as formas. No entanto, é possível usar animação do PowerPoint apenas em categorias de gráfico ou séries de gráfico. Você também pode aplicar efeito de animação a um elemento de categoria ou a um elemento de série.

{{% alert color="primary" %}} 
Leia mais [**Sobre Gráficos Animados**](/slides/pt/cpp/animated-charts/).
{{% /alert %}}

## **Texto Animado**

Além do texto animado, também é possível aplicar animação a um parágrafo.

{{% alert color="primary" %}} 
Leia mais [**Sobre Texto Animado**](/slides/pt/cpp/animated-text/).
{{% /alert %}}

## **Perguntas Frequentes**

**As animações serão preservadas ao exportar para PDF?**

Não. PDF é um formato estático, portanto animações e [transições de slide](/slides/pt/cpp/slide-transition/) não são reproduzidas. Se precisar de movimento, exporte para [HTML5](/slides/pt/cpp/export-to-html5/), [GIF animado](/slides/pt/cpp/convert-powerpoint-to-animated-gif/) ou [vídeo](/slides/pt/cpp/convert-powerpoint-to-video/) em vez disso.

**Posso transformar uma apresentação animada em um vídeo e controlar a taxa de quadros e o tamanho do quadro?**

Sim. Você pode [renderizar a apresentação como quadros](/slides/pt/cpp/convert-powerpoint-to-video/) e codificá‑los em um vídeo (por exemplo, via ffmpeg), escolhendo FPS e resolução. Animações e transições de slide são reproduzidas durante a renderização.

**As animações permanecerão intactas ao trabalhar com ODP (não apenas PPTX)?**

PPT, PPTX e ODP são suportados para [leitura](/slides/pt/cpp/open-presentation/) e [gravação](/slides/pt/cpp/save-presentation/), mas diferenças de formato podem fazer com que certos efeitos pareçam ou se comportem ligeiramente diferentes. Valide casos críticos com amostras reais.