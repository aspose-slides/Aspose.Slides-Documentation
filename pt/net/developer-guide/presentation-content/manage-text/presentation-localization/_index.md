---
title: Automatizar localização de apresentações em .NET
linktitle: Localização de Apresentações
type: docs
weight: 100
url: /pt/net/presentation-localization/
keywords:
- alterar idioma
- verificação ortográfica
- ID de idioma
- PowerPoint
- apresentação
- .NET
- C#
- Aspose.Slides
description: "Automatize a localização de slides PowerPoint e OpenDocument em .NET com Aspose.Slides, usando exemplos de código C# práticos e dicas para uma implantação global mais rápida."
---
## **Visão geral**

Este artigo explica como definir o `LanguageId` para texto em uma apresentação usando Aspose.Slides. Ele mostra como abrir uma apresentação, adicionar uma forma com texto, atribuir um identificador de idioma a uma parte do texto e salvar o resultado como um arquivo PPTX.

## **Alterar idioma para texto de uma apresentação e forma**
- Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/net/aspose.slides/presentation).
- Obtenha a referência de um slide usando seu Índice.
- Adicione um AutoShape do tipo Retângulo ao slide.
- Adicione algum texto ao TextFrame.
- Defina o LanguageId no texto.
- Grave a apresentação como um arquivo PPTX.

A implementação das etapas acima é demonstrada abaixo em um exemplo.

```c#
using (Presentation pres = new Presentation("test0.pptx"))
{
    IAutoShape shape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 200, 50);
    shape.AddTextFrame("Text to apply spellcheck language");
    shape.TextFrame.Paragraphs[0].Portions[0].PortionFormat.LanguageId = "en-EN";

    pres.Save("test1.pptx",Aspose.Slides.Export.SaveFormat.Pptx);
}
```

## **Perguntas frequentes**

**A ID de idioma aciona a tradução automática de texto?**

Não. O [LanguageId](https://reference.aspose.com/slides/pt/net/aspose.slides/baseportionformat/languageid/) no Aspose.Slides armazena o idioma para verificação ortográfica e correção gramatical, mas não traduz nem altera o conteúdo do texto. É um metadado que o PowerPoint entende para revisão.

**A ID de idioma afeta a hifenização e quebras de linha durante a renderização?**

No Aspose.Slides, o [LanguageId](https://reference.aspose.com/slides/pt/net/aspose.slides/baseportionformat/languageid/) é usado para revisão. A qualidade da hifenização e a quebra de linha dependem principalmente da disponibilidade de [fonte adequadas](/slides/pt/net/powerpoint-fonts/) e das configurações de layout/quebra de linha para o sistema de escrita. Para garantir a renderização correta, disponibilize as fontes necessárias, configure as [regras de substituição de fontes](/slides/pt/net/font-substitution/) e/ou [incorpore fontes](/slides/pt/net/embedded-font/) na apresentação.

**Posso definir idiomas diferentes dentro de um único parágrafo?**

Sim. O [LanguageId](https://reference.aspose.com/slides/pt/net/aspose.slides/baseportionformat/languageid/) é aplicado ao nível da porção de texto, portanto um único parágrafo pode misturar vários idiomas com configurações de revisão distintas.