---
title: Automatizar localização de apresentações em Java
linktitle: Localização de Apresentação
type: docs
weight: 100
url: /pt/java/presentation-localization/
keywords:
- alterar idioma
- verificação ortográfica
- ID de idioma
- PowerPoint
- OpenDocument
- apresentação
- Java
- Aspose.Slides
description: "Automatize a localização de slides PowerPoint e OpenDocument em Java com Aspose.Slides, usando exemplos de código práticos e dicas para uma implantação global mais rápida."
---
## **Visão geral**

Este artigo explica como definir o `LanguageId` para texto em uma apresentação usando Aspose.Slides. Ele mostra como abrir uma apresentação, adicionar uma forma com texto, atribuir um identificador de idioma a uma porção de texto e salvar o resultado como um arquivo PPTX.

## **Alterar idioma de uma apresentação e texto de forma**
- Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/java/com.aspose.slides/Presentation).
- Obtenha a referência de um slide usando seu índice.
- Adicione um [IAutoShape](https://reference.aspose.com/slides/pt/java/com.aspose.slides/IAutoShape) do tipo [Rectangle](https://reference.aspose.com/slides/pt/java/com.aspose.slides/ShapeType#Rectangle) ao slide.
- Adicione algum texto ao TextFrame.
- [Setting Language Id](https://reference.aspose.com/slides/pt/java/com.aspose.slides/IBasePortionFormat#setLanguageId-java.lang.String-) ao texto.
- Grave a apresentação como um arquivo PPTX.

A implementação das etapas acima é demonstrada abaixo em um exemplo.

```java
Presentation pres = new Presentation("test.pptx");
try {
    IAutoShape shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 200, 50);
    shape.addTextFrame("Text to apply spellcheck language");

    shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().setLanguageId("en-EN");

    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**O ID de idioma aciona a tradução automática de texto?**

Não. [Language ID](https://reference.aspose.com/slides/pt/java/com.aspose.slides/baseportionformat/#setLanguageId-java.lang.String-) no Aspose.Slides armazena o idioma para verificação ortográfica e correção gramatical, mas não traduz nem altera o conteúdo do texto. É uma metadado que o PowerPoint entende para revisão.

**O ID de idioma afeta a hifenização e quebras de linha durante a renderização?**

No Aspose.Slides, [language ID](https://reference.aspose.com/slides/pt/java/com.aspose.slides/baseportionformat/#setLanguageId-java.lang.String-) serve para revisão. A qualidade da hifenização e a quebra de linha dependem principalmente da disponibilidade de [proper fonts](/slides/pt/java/powerpoint-fonts/) e das configurações de layout/quebra de linha para o sistema de escrita. Para garantir a renderização correta, disponibilize as fontes necessárias, configure [font substitution rules](/slides/pt/java/font-substitution/) e/ou [embed fonts](/slides/pt/java/embedded-font/) na apresentação.

**Posso definir diferentes idiomas dentro de um único parágrafo?**

Sim. [Language ID](https://reference.aspose.com/slides/pt/java/com.aspose.slides/baseportionformat/#setLanguageId-java.lang.String-) é aplicado ao nível da porção de texto, portanto um único parágrafo pode misturar vários idiomas com configurações de revisão distintas.