---
title: Gerenciar Fontes de Fallback para Apresentações em C++
linktitle: Fonte de Fallback
type: docs
weight: 50
url: /pt/cpp/fallback-font/
keywords:
- fonte de fallback
- fonte disponível
- substituição de glifo
- especificar fonte
- especificar regra
- PowerPoint
- OpenDocument
- apresentação
- C++
- Aspose.Slides
description: "Veja como o Aspose.Slides for C++ usa fontes de fallback para manter o texto legível em apresentações do PowerPoint e OpenDocument quando as fontes originais não estão disponíveis."
---
## **Introdução**

Fonts de fallback são usados quando a fonte especificada para o texto está disponível no sistema, mas não contém o glifo necessário. Nesse caso, o Aspose.Slides pode usar uma das fontes de fallback especificadas para substituir o glifo ausente.

## **Fonte de Fallback**
A fonte de fallback é usada quando a fonte especificada para o texto está disponível no sistema, mas essa fonte não contém o glifo necessário. Nesse caso, é possível usar uma das fontes de fallback especificadas para a substituição do glifo.

O Aspose.Slides permite criar fontes de fallback, adicioná‑las à coleção de fontes de fallback, definir a coleção de fontes de fallback para uma determinada apresentação, remover fontes de fallback da apresentação, especificar as regras para aplicar fontes de fallback e outras operações.

Para familiarizar‑se com esses recursos, use os links a seguir:

- [Criar Fonte de Fallback](/slides/pt/cpp/create-fallback-font)
- [Criar Coleção de Fontes de Fallback](/slides/pt/cpp/create-fallback-fonts-collection)
- [Renderizar Apresentação com Fonte de Fallback](/slides/pt/cpp/render-presentation-with-fallback-font)

## **FAQ**

**Como as fontes de fallback diferem da substituição de fonte?**

O fallback é aplicado por caractere ou por intervalo de Unicode quando a fonte principal não possui glifos específicos; ele preenche apenas os caracteres ausentes. [Substituição](/slides/pt/cpp/font-substitution/) substitui uma fonte ausente ou indisponível por toda a execução ou parte do texto por outra fonte. Eles podem ser combinados, mas seu escopo e lógica de seleção são diferentes.

**As configurações de fallback são salvas dentro do arquivo da apresentação?**

Não. A configuração de fallback vive no tempo de processamento/renderização na biblioteca e não é serializada no PPTX. A apresentação não armazena suas regras de fallback.

**O fallback afeta elementos criados por objetos do PowerPoint (SmartArt, gráficos, WordArt)?**

Sim. O texto dentro desses objetos passa pelo mesmo pipeline de renderização, portanto as mesmas regras de fallback se aplicam a ele como ao texto comum.