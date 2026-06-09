---
title: Gerenciar Fontes de Reserva para Apresentações em Java
linktitle: Fonte de Reserva
type: docs
weight: 50
url: /pt/java/fallback-font/
keywords:
- fonte de reserva
- fonte disponível
- substituição de glifo
- especificar fonte
- especificar regra
- PowerPoint
- OpenDocument
- apresentação
- Java
- Aspose.Slides
description: "Veja como o Aspose.Slides para Java usa fontes de reserva para manter o texto legível em apresentações PowerPoint e OpenDocument quando as fontes originais não estão disponíveis."
---
## **Introdução**

Fontes de reserva são usadas quando a fonte especificada para o texto está disponível no sistema, mas não contém o glifo necessário. Nesse caso, o Aspose.Slides pode usar uma das fontes de reserva especificadas para substituir o glifo ausente.

## **Fonte de Reserva**

O Aspose.Slides permite criar fontes de reserva, adicioná‑las à coleção de fontes de reserva, definir a coleção de fontes de reserva para uma determinada apresentação, remover fontes de reserva da apresentação, especificar as regras para aplicar fontes de reserva e outras operações.

Para se familiarizar com esses recursos, use os links a seguir:

- [Criar Fonte de Reserva](/slides/pt/java/create-fallback-font)
- [Criar Coleção de Fontes de Reserva](/slides/pt/java/create-fallback-fonts-collection)
- [Renderizar Apresentação com Fonte de Reserva](/slides/pt/java/render-presentation-with-fallback-font)

## **FAQ**

**Como as fontes de reserva diferem da substituição de fontes?**

A fonte de reserva é aplicada por caractere ou por intervalo de Unicode quando a fonte principal não possui glifos específicos; ela preenche apenas os caracteres ausentes. [Substituição](/slides/pt/java/font-substitution/) substitui uma fonte ausente ou indisponível para toda a sequência ou trecho de texto por outra fonte. Elas podem ser combinadas, mas seu escopo e lógica de seleção são diferentes.

**As configurações de fonte de reserva são salvas dentro do arquivo da apresentação?**

Não. A configuração de fonte de reserva existe apenas durante o processamento/renderização na biblioteca e não é serializada no PPTX. A apresentação não armazena as suas regras de reserva.

**A fonte de reserva afeta elementos criados por objetos do PowerPoint (SmartArt, gráficos, WordArt)?**

Sim. O texto dentro desses objetos passa pelo mesmo pipeline de renderização, portanto as mesmas regras de fonte de reserva são aplicadas a ele como ao texto comum.