---
title: Gerenciar sobrescrito e subscrito em apresentações usando C++
linktitle: Sobrescrito e Subscrito
type: docs
weight: 80
url: /pt/cpp/superscript-and-subscript/
keywords:
- sobrescrito
- subscrito
- adicionar sobrescrito
- adicionar subscrito
- PowerPoint
- OpenDocument
- apresentação
- C++
- Aspose.Slides
description: "Domine sobrescrito e subscrito no Aspose.Slides para C++ e eleve suas apresentações com formatação de texto profissional para máximo impacto."
---
## **Visão geral**

Aspose.Slides oferece recursos para integrar texto em sobrescrito e subscrito em suas apresentações PowerPoint (PPT, PPTX) e OpenDocument (ODP). Seja para destacar fórmulas químicas, equações matemáticas ou anotar conteúdo com notas de rodapé, essas opções de formatação especial ajudam a manter clareza e precisão. Neste artigo, você aprenderá como aplicar estilos de sobrescrito e subscrito de forma contínua e garantir resultados profissionais em cada slide.

## **Gerenciar texto em sobrescrito e subscrito**

Você pode adicionar texto em sobrescrito e subscrito dentro de qualquer porção de parágrafo. Para adicionar texto em Sobrescrito ou Subscrito em um quadro de texto do Aspose.Slides, deve‑se usar as propriedades **Escapement** da classe PortionFormat.

Esta propriedade devolve ou define o texto em sobrescrito ou subscrito (valor de -100 % (subscrito) a 100 % (sobrescrito)). Por exemplo :

- Crie uma instância da classe[Presentation](https://reference.aspose.com/slides/pt/cpp/aspose.slides/presentation/).
- Obtenha a referência de um slide usando seu Índice.
- Adicione um IAutoShape do tipo Rectangle ao slide.
- Acesse o ITextFrame associado ao IAutoShape.
- Limpe os Parágrafos existentes
- Crie um novo objeto de parágrafo para conter texto em sobrescrito e adicione‑o à coleção IParagraphs do ITextFrame.
- Crie um novo objeto Portion
- Defina a propriedade Escapement para a portion entre 0 e 100 para adicionar sobrescrito. (0 significa sem sobrescrito)
- Defina algum texto para a Portion e então adicione‑o na coleção de portions do parágrafo.
- Crie um novo objeto de parágrafo para conter texto em subscrito e adicione‑o à coleção IParagraphs do ITextFrame.
- Crie um novo objeto Portion
- Defina a propriedade Escapement para a portion entre 0 e -100 para adicionar subscrito. (0 significa sem subscrito)
- Defina algum texto para a Portion e então adicione‑o na coleção de portions do parágrafo.
- Salve a apresentação como um arquivo PPTX.

A implementação das etapas acima é fornecida abaixo.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-AddingSuperscriptAndSubscriptTextInTextFrame-AddingSuperscriptAndSubscriptTextInTextFrame.cpp" >}}

## **FAQ**

**A formatação de sobrescrito e subscrito será preservada ao exportar para PDF ou outros formatos?**

Sim, o Aspose.Slides preserva corretamente a formatação de sobrescrito e subscrito ao exportar apresentações para PDF, PPT/PPTX, imagens e outros formatos suportados. A formatação especializada permanece intacta em todos os arquivos de saída.

**É possível combinar sobrescrito e subscrito com outros estilos de formatação, como negrito ou itálico?**

Sim, o Aspose.Slides permite combinar vários estilos de texto dentro de uma única portion. Você pode habilitar negrito, itálico, sublinhado e, simultaneamente, aplicar sobrescrito ou subscrito configurando as propriedades correspondentes em [PortionFormat](https://reference.aspose.com/slides/pt/cpp/aspose.slides/portionformat/).

**A formatação de sobrescrito e subscrito funciona para texto dentro de tabelas, gráficos ou SmartArt?**

Sim, o Aspose.Slides oferece suporte à formatação na maioria dos objetos, incluindo tabelas e elementos de gráficos. Ao trabalhar com SmartArt, é necessário acessar os elementos apropriados (como [SmartArtNode](https://reference.aspose.com/slides/pt/cpp/aspose.slides.smartart/smartartnode/)) e seus contêineres de texto, e então configurar as propriedades [PortionFormat](https://reference.aspose.com/slides/pt/cpp/aspose.slides/portionformat/) de maneira similar.