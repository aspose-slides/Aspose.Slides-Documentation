---
title: Gerenciar fontes de fallback para apresentações em .NET
linktitle: Fonte de Fallback
type: docs
weight: 50
url: /pt/net/fallback-font/
keywords:
- fonte de fallback
- fonte disponível
- substituição de glifo
- especificar fonte
- especificar regra
- PowerPoint
- OpenDocument
- apresentação
- .NET
- C#
- Aspose.Slides
description: "Veja como o Aspose.Slides para .NET usa fontes de fallback para manter o texto legível em apresentações do PowerPoint e OpenDocument quando as fontes originais não estão disponíveis."
---
## **Introdução**

As fontes de fallback são usadas quando a fonte especificada para o texto está disponível no sistema, mas não contém o glifo necessário. Nesse caso, o Aspose.Slides pode usar uma das fontes de fallback especificadas para substituir o glifo ausente.

## **Fonte de Fallback**

O Aspose.Slides permite criar fontes de fallback, adicioná-las à coleção de fontes de fallback, definir a coleção de fontes de fallback para uma determinada apresentação, remover fontes de fallback da apresentação, especificar as regras para aplicar fontes de fallback e outras.

Para se familiarizar com esses recursos, use os links a seguir:

- [Criar Fonte de Fallback](/slides/pt/net/create-fallback-font)
- [Criar Coleção de Fontes de Fallback](/slides/pt/net/create-fallback-fonts-collection)
- [Renderizar Apresentação com Fonte de Fallback](/slides/pt/net/render-presentation-with-fallback-font)

## **FAQ**

**Como as fontes de fallback diferem da substituição de fontes?**

O fallback é aplicado por caractere ou por intervalo de Unicode quando a fonte principal não possui glifos específicos; ele preenche apenas os caracteres ausentes. [Substituição](/slides/pt/net/font-substitution/) substitui uma fonte ausente ou indisponível para uma sequência inteira ou parte do texto por outra fonte. Elas podem ser combinadas, mas seu escopo e lógica de seleção são diferentes.

**As configurações de fallback são salvas dentro do arquivo de apresentação?**

Não. A configuração de fallback existe apenas no momento do processamento/renderização na biblioteca e não é serializada no PPTX. A apresentação não armazena suas regras de fallback.

**O fallback afeta elementos criados por objetos do PowerPoint (SmartArt, gráficos, WordArt)?**

Sim. O texto dentro desses objetos passa pelo mesmo pipeline de renderização, portanto as mesmas regras de fallback se aplicam a ele assim como ao texto comum.