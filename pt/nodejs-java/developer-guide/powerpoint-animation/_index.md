---
title: Aprimore Apresentações PowerPoint com Animações em JavaScript
linktitle: Animação PowerPoint
type: docs
weight: 150
url: /pt/nodejs-java/powerpoint-animation/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Use Aspose.Slides for Node.js via Java para manipular animações do PowerPoint. Esta visão geral destaca recursos principais e oferece insights para aprimorar suas apresentações."
---
## **Introdução**

Como as apresentações destinam‑se a apresentar algo, sua aparência visual e comportamento interativo são sempre considerados ao criá‑las.

**Animação do PowerPoint** desempenha um papel importante para tornar a apresentação atraente e cativante para os espectadores. Aspose.Slides for Node.js via Java oferece uma ampla variedade de opções para adicionar animação a uma apresentação PowerPoint:

- aplicar vários tipos de efeitos de animação do PowerPoint em formas, gráficos, tabelas, objetos OLE e outros elementos da apresentação.
- usar vários efeitos de animação do PowerPoint em uma forma.
- usar a linha do tempo de animação para controlar os efeitos de animação.
- criar animação personalizada.

No Aspose.Slides for Node.js via Java, vários efeitos de animação podem ser aplicados nas formas. Como todo elemento no slide, incluindo texto, imagens, objeto OLE, tabela etc., é considerado uma forma, isso significa que podemos aplicar efeitos de animação em cada elemento de um slide.

## **Efeitos de Animação**
Aspose.Slides suporta **mais de 150 efeitos de animação**, incluindo efeitos básicos como Bounce, PathFootball, efeito Zoom e efeitos de animação específicos como OLEObjectShow, OLEObjectOpen. Você pode encontrar uma lista completa de efeitos de animação na enumeração [**EffectType**](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/effecttype/).

Além disso, esses efeitos de animação podem ser usados em combinação com eles:

- [ColorEffect](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/ColorEffect)
- [CommandEffect](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/CommandEffect)
- [FilterEffect](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/FilterEffect)
- [MotionEffect](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/MotionEffect)
- [PropertyEffect](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/PropertyEffect)
- [RotationEffect](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/RotationEffect)
- [ScaleEffect](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/ScaleEffect)
- [SetEffect](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/SetEffect)

## **Animação Personalizada**
É possível criar suas próprias **animações personalizadas** no Aspose.Slides.  
Isso pode ser alcançado se você combinar vários comportamentos em uma nova animação personalizada.  

[**Behavior**](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/Behavior) é a unidade de construção de qualquer efeito de animação do PowerPoint. Todos os efeitos de animação são, na verdade, um conjunto de comportamentos compostos em uma única estratégia. Você pode combinar comportamentos em uma animação personalizada uma vez e reutilizá‑la em outras apresentações. Se você adicionar um novo comportamento a um efeito de animação padrão do PowerPoint, ele se tornará outra animação personalizada. Por exemplo, você pode adicionar o comportamento de repetição a uma animação para que ela se repita algumas vezes.  

[**Animation Point**](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/Point) é um ponto onde o comportamento deve ser aplicado.

## **Linha do Tempo de Animação**
[**Sequence**](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/Sequence) é uma coleção de efeitos de animação, aplicados em uma forma concreta.  

[**Timeline**](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/AnimationTimeLine) é um conjunto de Sequences usado em um slide concreto. É um mecanismo de animação representado desde o PowerPoint 2002. Nas versões anteriores do PowerPoint, era difícil adicionar efeitos de animação à apresentação, o que só podia ser feito com diferentes soluções alternativas. A Timeline substitui a antiga classe AnimationSettings e fornece um modelo de objeto mais claro para animação do PowerPoint. Um slide pode ter somente uma timeline de animação.

## **Animação Interativa**
[**Trigger**](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/EffectTriggerType) permite definir ações do usuário (por exemplo, clique de botão), que iniciarão uma determinada animação. Os gatilhos foram adicionados apenas na versão mais recente do PowerPoint.

## **Animação de Formas**
Aspose.Slides permite aplicar animação a formas, que podem ser texto, retângulo, linha, quadro, objeto OLE, etc.

{{% alert color="primary" %}} 
Leia mais [**Sobre Animação de Formas**](/slides/pt/nodejs-java/shape-animation/).
{{% /alert %}}

## **Gráficos Animados**
Para criar gráficos animados, você deve usar as mesmas classes que para as formas. No entanto, é possível usar animação do PowerPoint apenas em categorias de gráfico ou séries de gráfico. Você também pode aplicar efeito de animação a um elemento de categoria ou elemento de série.

{{% alert color="primary" %}} 
Leia mais [**Sobre Gráficos Animados**](/slides/pt/nodejs-java/animated-charts/).
{{% /alert %}}

## **Texto Animado**
Além do texto animado, também é possível aplicar animação a um parágrafo.

{{% alert color="primary" %}} 
Leia mais [**Sobre Texto Animado**](/slides/pt/nodejs-java/animated-text/).
{{% /alert %}}

## **FAQ**

**As animações serão preservadas ao exportar para PDF?**

Não. PDF é um formato estático, portanto as animações e as [transições de slide](/slides/pt/nodejs-java/slide-transition/) não são reproduzidas. Se precisar de movimento, exporte para [HTML5](/slides/pt/nodejs-java/export-to-html5/), [GIF animado](/slides/pt/nodejs-java/convert-powerpoint-to-animated-gif/), ou [vídeo](/slides/pt/nodejs-java/convert-powerpoint-to-video/) em vez disso.

**Posso transformar uma apresentação animada em um vídeo e controlar a taxa de quadros e o tamanho do quadro?**

Sim. Você pode [renderizar a apresentação como quadros](/slides/pt/nodejs-java/convert-powerpoint-to-video/) e codificá‑los em um vídeo (por exemplo, via ffmpeg), escolhendo os FPS e a resolução. As animações e as transições de slide são reproduzidas durante a renderização.

**As animações permanecerão intactas ao trabalhar com ODP (não apenas PPTX)?**

PPT, PPTX e ODP são suportados para [leitura](/slides/pt/nodejs-java/open-presentation/) e [gravação](/slides/pt/nodejs-java/save-presentation/), mas as diferenças de formato significam que certos efeitos podem parecer ou se comportar levemente diferentes. Valide os casos críticos com amostras reais.