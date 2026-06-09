---
title: Gerenciar Transições de Slides em Apresentações Usando C++
linktitle: Transição de Slide
type: docs
weight: 80
url: /pt/cpp/slide-transition/
keywords:
- transição de slide
- adicionar transição de slide
- aplicar transição de slide
- transição de slide avançada
- transição morph
- tipo de transição
- efeito de transição
- PowerPoint
- OpenDocument
- apresentação
- C++
- Aspose.Slides
description: "Descubra como personalizar transições de slides no Aspose.Slides para C++, com orientação passo a passo para apresentações PowerPoint e OpenDocument."
---
## **Visão geral**

Este artigo explica como gerenciar transições de slides em apresentações usando Aspose.Slides. Ele mostra como aplicar tipos de transição aos slides, configurar o comportamento da transição, como avançar ao clicar ou após um tempo especificado, verificar e desativar o avanço automático, usar a transição Morph e seus tipos, e definir opções de efeito de transição. Os exemplos demonstram como carregar ou criar uma apresentação, modificar as configurações de transição para slides selecionados e salvar o resultado como um arquivo PPTX. O artigo também responde a perguntas comuns sobre velocidade da transição, sons de transição, aplicação da mesma transição a vários slides e verificação da transição atualmente definida em um slide.

## **Adicionar Transição de Slide**

Para facilitar a compreensão, demonstramos o uso do Aspose.Slides for C++ para gerenciar transições de slide simples. Os desenvolvedores podem não apenas aplicar diferentes efeitos de transição aos slides, mas também personalizar o comportamento desses efeitos de transição. Para criar um efeito de transição de slide simples, siga as etapas abaixo:

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/cpp/class/aspose.slides.presentation).
1. Aplique um Slide Transition Type no slide a partir de um dos efeitos de transição oferecidos pelo Aspose.Slides for C++ através do enum TransitionType.
1. Gravar o arquivo de apresentação modificado.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-ManageSimpleSlideTransitions-ManageSimpleSlideTransitions.cpp" >}}

## **Adicionar Transição de Slide Avançada**

Na seção anterior, aplicamos apenas um efeito de transição simples no slide. Agora, para tornar esse efeito de transição simples ainda melhor e controlado, siga as etapas abaixo:

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/cpp/class/aspose.slides.presentation).
1. Aplique um Slide Transition Type no slide a partir de um dos efeitos de transição oferecidos pelo Aspose.Slides for C++
1. Você também pode definir a transição para Avançar ao Clicar, após um período de tempo específico ou ambos.
1. Se a transição do slide estiver habilitada para Avançar ao Clicar, a transição avançará somente quando alguém clicar o mouse. Além disso, se a propriedade Advance After Time estiver definida, a transição avançará automaticamente após o tempo especificado ser atingido.
1. Gravar a apresentação modificada como um arquivo de apresentação.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-ManagingBetterSlideTransitions-ManagingBetterSlideTransitions.cpp" >}}

## **Transição Morph**

O Aspose.Slides for C++ agora oferece suporte à Transição Morph. Elas representam a nova transição morph introduzida no PowerPoint 2019. A transição Morph permite animar um movimento suave de um slide para o próximo. Este artigo descreve o conceito e como usar a transição Morph. Para usar a transição Morph de forma eficaz, você precisará de dois slides com pelo menos um objeto em comum. A maneira mais fácil é duplicar o slide e então mover o objeto no segundo slide para um local diferente.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-SupportOfMorphTransition-SupportOfMorphTransition.cpp" >}}

## **Tipos de Transição Morph**

Foi adicionado um novo enum Aspose.Slides.SlideShow.TransitionMorphType. Ele representa diferentes tipos de transição Morph de slide.

O enum TransitionMorphType possui três membros:

- ByObject: A transição Morph será executada considerando formas como objetos indivisíveis.
- ByWord: A transição Morph será executada transferindo texto por palavras, onde possível.
- ByChar: A transição Morph será executada transferindo texto por caracteres, onde possível.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-SetTransitionMorphType-SetTransitionMorphType.cpp" >}}

## **Definir Efeitos de Transição**

O Aspose.Slides for C++ oferece suporte à configuração de efeitos de transição, como de preto, da esquerda, da direita etc. Para definir o Efeito de Transição, siga as etapas abaixo:

- Crie uma instância da classe Presentation.
- Obtenha a referência do slide.
- Defina o efeito de transição.
- Grave a apresentação como um arquivo PPTX.

No exemplo abaixo, definimos os efeitos de transição.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SetTransitionEffects-SetTransitionEffects.cpp" >}}

## **FAQ**

**Posso controlar a velocidade de reprodução de uma transição de slide?**

Sim. Defina o [speed] da transição usando a configuração [TransitionSpeed] (por exemplo, slow/medium/fast).

**Posso anexar áudio a uma transição e fazer com que ele repita?**

Sim. Você pode incorporar um som à transição e controlar o comportamento por meio de configurações como modo de som e repetição (por exemplo, [set_Sound](https://reference.aspose.com/slides/pt/cpp/aspose.slides.slideshow/slideshowtransition/set_sound/), [set_SoundMode](https://reference.aspose.com/slides/pt/cpp/aspose.slides.slideshow/slideshowtransition/set_soundmode/), [set_SoundLoop](https://reference.aspose.com/slides/pt/cpp/aspose.slides.slideshow/slideshowtransition/set_soundloop/), além de metadados como [set_SoundIsBuiltIn](https://reference.aspose.com/slides/pt/cpp/aspose.slides.slideshow/slideshowtransition/set_soundisbuiltin/) e [set_SoundName](https://reference.aspose.com/slides/pt/cpp/aspose.slides.slideshow/slideshowtransition/set_soundname/)).

**Qual a maneira mais rápida de aplicar a mesma transição a todos os slides?**

Configure o tipo de transição desejado nas configurações de transição de cada slide; as transições são armazenadas por slide, portanto aplicar o mesmo tipo em todos os slides produz um resultado consistente.

**Como posso verificar qual transição está atualmente definida em um slide?**

Inspecione as [transition settings] do slide e leia seu [transition type]; esse valor indica exatamente qual efeito está aplicado.