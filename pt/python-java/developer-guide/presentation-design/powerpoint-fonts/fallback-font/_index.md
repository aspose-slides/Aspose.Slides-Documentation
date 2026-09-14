---
title: Gerenciar Fontes de Fallback para Apresentações em Python via Java
linktitle: Fonte de Fallback
type: docs
weight: 50
url: /pt/python-java/fallback-font/
keywords:
- fonte de fallback
- fonte disponível
- substituição de glifo
- especificar fonte
- especificar regra
- PowerPoint
- OpenDocument
- apresentação
- Python
- Java
- Aspose.Slides
description: "Veja como o Aspose.Slides para Python via Java usa fontes de fallback para manter o texto legível em apresentações do PowerPoint e OpenDocument quando as fontes originais não estão disponíveis."
---
## **Introdução**

Fontes de fallback são usadas quando a fonte especificada para o texto está disponível no sistema, mas não contém o glifo necessário. Nesse caso, o Aspose.Slides pode usar uma das fontes de fallback especificadas para substituir o glifo ausente.

## **Fonte de Fallback**

O Aspose.Slides permite criar fontes de fallback, adicioná‑las a uma coleção de fontes de fallback, definir a coleção de fontes de fallback para uma determinada apresentação, remover fontes de fallback da apresentação, especificar as regras para aplicar fontes de fallback e executar outras operações relacionadas.

Para se familiarizar com esses recursos, use os links a seguir:

- [Create Fallback Font](/slides/pt/python-java/create-fallback-font/)
- [Create Fallback Fonts Collection](/slides/pt/python-java/create-fallback-fonts-collection/)
- [Render Presentation with Fallback Font](/slides/pt/python-java/render-presentation-with-fallback-font/)

## **FAQ**

**Como as fontes de fallback diferem da substituição de fontes?**

O fallback é aplicado por caractere ou por intervalo Unicode quando a fonte principal não possui glifos específicos; ele preenche apenas os caracteres ausentes. [Substitution](/slides/pt/python-java/font-substitution/) substitui uma fonte ausente ou indisponível para toda a sequência ou parte do texto por outra fonte. Elas podem ser combinadas, mas seu escopo e lógica de seleção são diferentes.

**As configurações de fallback são salvas dentro do arquivo da apresentação?**

Não. A configuração de fallback vive no momento de processamento/renderização na biblioteca e não é serializada no PPTX. A apresentação não armazena suas regras de fallback.

**O fallback afeta elementos criados por objetos do PowerPoint (SmartArt, gráficos, WordArt)?**

Sim. O texto dentro desses objetos passa pelo mesmo pipeline de renderização, portanto as mesmas regras de fallback se aplicam a ele como ao texto normal.