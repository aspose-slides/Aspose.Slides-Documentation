---
title: Formas de Apresentação em Grupo em C++
linktitle: Grupo de Formas
type: docs
weight: 40
url: /pt/cpp/group/
keywords:
- grupo de forma
- grupo de formas
- adicionar grupo
- texto alternativo
- PowerPoint
- apresentação
- C++
- Aspose.Slides
description: "Aprenda a agrupar e desagrupar formas em apresentações PowerPoint usando Aspose.Slides para C++ — guia rápido, passo a passo, com código C++ gratuito."
---
## **Visão geral**

Este artigo explica como trabalhar com grupos de formas no Aspose.Slides. Ele mostra como adicionar um grupo de formas a um slide, colocar formas dentro dele e salvar a apresentação atualizada. Também demonstra como acessar as formas armazenadas dentro de um grupo e ler seus valores de `AlternativeText`. Além disso, o artigo aborda brevemente recursos relacionados a grupos de formas, como grupos aninhados, ordem Z e opções de bloqueio.

## **Adicionar um Grupo de Formas**
O Aspose.Slides oferece suporte ao trabalho com grupos de formas em slides. Esse recurso auxilia os desenvolvedores a criar apresentações mais ricas. O Aspose.Slides para C++ permite adicionar ou acessar grupos de formas. É possível adicionar formas a um grupo criado para preenchê‑lo ou acessar qualquer propriedade do grupo de formas. Para adicionar um grupo de formas a um slide usando o Aspose.Slides para C++:

1. Crie uma instância da [Presentation](https://reference.aspose.com/slides/pt/cpp/aspose.slides/presentation/) classe.
1. Obtenha a referência de um slide usando seu Índice.
1. Adicione um grupo de formas ao slide.
1. Adicione as formas ao grupo de formas criado.
1. Salve a apresentação modificada como um arquivo PPTX.

O exemplo abaixo adiciona um grupo de formas a um slide.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CreateGroupShape-CreateGroupShape.cpp" >}}

## **Acessar a Propriedade AltText**
Este tópico mostra passos simples, completos com exemplos de código, para adicionar um grupo de formas e acessar a propriedade AltText de grupos de formas em slides. Para acessar o AltText de um grupo de formas em um slide usando o Aspose.Slides para C++:

1. Instancie a classe `Presentation` que representa um arquivo PPTX.
1. Obtenha a referência de um slide usando seu Índice.
1. Acesse a coleção de formas dos slides.
1. Acesse o grupo de formas.
1. Acesse a propriedade AltText.

O exemplo abaixo acessa o texto alternativo do grupo de formas.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AccessingAltTextinGroupshapes-AccessingAltTextinGroupshapes.cpp" >}}

## **FAQ**

**O agrupamento aninhado (um grupo dentro de outro grupo) é suportado?**

Sim. [GroupShape](https://reference.aspose.com/slides/pt/cpp/aspose.slides/groupshape/) tem um método [get_ParentGroup](https://reference.aspose.com/slides/pt/cpp/aspose.slides/shape/get_parentgroup/) que indica diretamente o suporte à hierarquia (um grupo pode ser filho de outro grupo).

**Como controlo a ordem Z do grupo em relação a outros objetos no slide?**

Use a [GroupShape](https://reference.aspose.com/slides/pt/cpp/aspose.slides/groupshape/) [Z-Order position](https://reference.aspose.com/slides/pt/cpp/aspose.slides/shape/get_zorderposition/) para inspecionar sua posição na pilha de exibição.

**Posso impedir mover/editar/desagrupar?**

Sim. A seção de bloqueio do grupo é exposta via [get_GroupShapeLock](https://reference.aspose.com/slides/pt/cpp/aspose.slides/groupshape/get_groupshapelock/), que permite restringir operações sobre o objeto.