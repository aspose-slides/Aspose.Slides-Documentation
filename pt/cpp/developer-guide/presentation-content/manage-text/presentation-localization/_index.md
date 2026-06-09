---
title: Automatizar Localização de Apresentação em C++
linktitle: Localização de Apresentação
type: docs
weight: 100
url: /pt/cpp/presentation-localization/
keywords:
- alterar idioma
- verificação ortográfica
- id de idioma
- PowerPoint
- OpenDocument
- apresentação
- C++
- Aspose.Slides
description: "Automatize a localização de slides PowerPoint e OpenDocument em C++ com Aspose.Slides, usando exemplos de código práticos e dicas para uma implantação global mais rápida."
---
## **Visão geral**

Este artigo explica como definir o `LanguageId` para texto em uma apresentação usando Aspose.Slides. Ele mostra como abrir uma apresentação, adicionar uma forma com texto, atribuir um identificador de idioma a uma parte do texto e salvar o resultado como um arquivo PPTX.

## **Alterar idioma para texto de apresentação e forma**
- Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/cpp/aspose.slides/presentation/).
- Obtenha a referência de um slide usando seu Index.
- Adicione um AutoShape do tipo Rectangle ao slide.
- Adicione algum texto ao TextFrame.
- Definindo Language Id ao texto.
- Grave a apresentação como um arquivo PPTX.

A implementação das etapas acima é demonstrada a seguir em um exemplo.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-TextBoxOnSlideProgram-TextBoxOnSlideProgram.cpp" >}}

## **Perguntas frequentes**

**O ID de idioma aciona a tradução automática de texto?**

Não. [Language ID](https://reference.aspose.com/slides/pt/cpp/aspose.slides/baseportionformat/set_languageid/) no Aspose.Slides armazena o idioma para verificação ortográfica e correção gramatical, mas não traduz nem altera o conteúdo do texto. É uma metadado que o PowerPoint entende para revisão.

**O ID de idioma afeta a hifenização e quebras de linha durante a renderização?**

No Aspose.Slides, [Language ID](https://reference.aspose.com/slides/pt/cpp/aspose.slides/baseportionformat/set_languageid/) é para revisão. A qualidade da hifenização e a quebra de linha dependem principalmente da disponibilidade de [fonts adequados](/slides/pt/cpp/powerpoint-fonts/) e das configurações de layout/quebra de linha para o sistema de escrita. Para garantir renderização correta, disponibilize as fontes necessárias, configure [regras de substituição de fontes](/slides/pt/cpp/font-substitution/), e/ou [incorpore fontes](/slides/pt/cpp/embedded-font/) na apresentação.

**Posso definir idiomas diferentes dentro de um único parágrafo?**

Sim. [Language ID](https://reference.aspose.com/slides/pt/cpp/aspose.slides/baseportionformat/set_languageid/) é aplicado ao nível da porção de texto, portanto um único parágrafo pode misturar vários idiomas com configurações de revisão distintas.