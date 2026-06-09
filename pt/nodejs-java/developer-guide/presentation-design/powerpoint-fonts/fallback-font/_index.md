---
title: Gerenciar Fontes de Fallback para Apresentações em JavaScript
linktitle: Fonte de Fallback
type: docs
weight: 50
url: /pt/nodejs-java/fallback-font/
keywords:
- fonte de fallback
- fonte disponível
- substituição de glifo
- especificar fonte
- especificar regra
- PowerPoint
- OpenDocument
- apresentação
- Node.js
- JavaScript
- Aspose.Slides
description: "Veja como o Aspose.Slides para Node.js usa fontes de fallback para manter o texto legível em apresentações PowerPoint e OpenDocument quando as fontes originais não estão disponíveis."
---
## **Introdução**

As fontes de fallback sao usadas quando a fonte especificada para o texto esta disponivel no sistema, mas nao contem um glifo necessario. Nesse caso, o Aspose.Slides pode usar uma das fontes de fallback especificadas para substituir o glifo ausente.

## **Fonte de Fallback**

O Aspose.Slides permite criar fontes de fallback, adiciona-las à colecao de fontes de fallback, definir a colecao de fontes de fallback para uma determinada apresentacao, remover fontes de fallback da apresentacao, especificar as regras para aplicar fontes de fallback e outras operacoes.

Para se familiarizar com esses recursos, use os links a seguir:

- [Create Fallback Font](/slides/pt/nodejs-java/create-fallback-font)
- [Create Fallback Fonts Collection](/slides/pt/nodejs-java/create-fallback-fonts-collection)
- [Render Presentation with Fallback Font](/slides/pt/nodejs-java/render-presentation-with-fallback-font)

## **FAQ**

**Como as fontes de fallback diferem da substituicao de fontes?**

O fallback e aplicado por caractere ou por intervalo de Unicode quando a fonte principal nao possui glifos especificos; ele preenche apenas os caracteres ausentes. [Substitution](/slides/pt/nodejs-java/font-substitution/) substitui uma fonte ausente ou indisponivel para toda uma sequencia ou parte do texto por outra fonte. Elas podem ser combinadas, mas seu escopo e logica de selecao sao diferentes.

**As configuracoes de fallback sao salvas dentro do arquivo da apresentacao?**

Nao. A configuracao de fallback existe apenas durante o processamento/renderizacao na biblioteca e nao e serializada no PPTX. A apresentacao nao armazena suas regras de fallback.

**O fallback afeta elementos criados por objetos do PowerPoint (SmartArt, graficos, WordArt)?**

Sim. O texto dentro desses objetos passa pelo mesmo pipeline de renderizacao, portanto as mesmas regras de fallback se aplicam a ele como ao texto normal.