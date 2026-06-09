---
title: Gerenciar Fontes de Fallback para Apresentações no Android
linktitle: Fonte de Fallback
type: docs
weight: 50
url: /pt/androidjava/fallback-font/
keywords:
- fonte de fallback
- fonte disponível
- substituição de glifo
- especificar fonte
- especificar regra
- PowerPoint
- OpenDocument
- apresentação
- Android
- Java
- Aspose.Slides
description: "Veja como o Aspose.Slides para Android via Java usa fontes de fallback para manter o texto legível em apresentações PowerPoint e OpenDocument quando as fontes originais não estão disponíveis."
---
## **Introdução**

A fonte de fallback é usada quando a fonte especificada para o texto está disponível no sistema, mas essa fonte não contém o glifo necessário. Nesse caso, é possível usar uma das fontes de fallback especificadas para a substituição do glifo.

## **Fonte de Fallback**

Aspose.Slides permite criar fontes de fallback, adicioná-las à coleção de fontes de fallback, definir a coleção de fontes de fallback para uma apresentação específica, remover fontes de fallback da apresentação, especificar as regras para aplicar fontes de fallback e outras funcionalidades.

Para se familiarizar com esses recursos, use os links a seguir:

- [Create Fallback Font](/slides/pt/androidjava/create-fallback-font)
- [Create Fallback Fonts Collection](/slides/pt/androidjava/create-fallback-fonts-collection)
- [Render Presentation with Fallback Font](/slides/pt/androidjava/render-presentation-with-fallback-font)

## **FAQ**

**Como as fontes de fallback diferem da substituição de fontes?**

O fallback é aplicado por caractere ou por intervalo de Unicode quando a fonte principal não possui glifos específicos; ele preenche apenas os caracteres ausentes. [Substitution](/slides/pt/androidjava/font-substitution/) substitui uma fonte ausente ou indisponível para um trecho completo ou parte do texto por outra fonte. Elas podem ser combinadas, mas seu escopo e lógica de seleção são diferentes.

**As configurações de fallback são salvas dentro do arquivo da apresentação?**

Não. A configuração de fallback existe apenas no tempo de processamento/renderização na biblioteca e não é serializada no PPTX. A apresentação não armazena suas regras de fallback.

**O fallback afeta elementos criados por objetos do PowerPoint (SmartArt, gráficos, WordArt)?**

Sim. O texto dentro desses objetos passa pelo mesmo pipeline de renderização, portanto as mesmas regras de fallback se aplicam a ele como ao texto normal.