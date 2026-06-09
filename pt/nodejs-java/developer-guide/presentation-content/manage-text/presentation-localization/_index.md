---
title: Automatizar a localização de apresentações em JavaScript
linktitle: Localização de Apresentações
type: docs
weight: 100
url: /pt/nodejs-java/presentation-localization/
keywords:
- mudar idioma
- verificação ortográfica
- id de idioma
- PowerPoint
- OpenDocument
- apresentação
- Node.js
- JavaScript
- Aspose.Slides
description: "Automatize a localização de slides PowerPoint e OpenDocument em JavaScript com Aspose.Slides, usando exemplos de código práticos e dicas para um rollout global mais rápido."
---
## **Visão geral**

Este artigo explica como definir o `LanguageId` para texto em uma apresentação usando Aspose.Slides. Ele mostra como abrir uma apresentação, adicionar uma forma com texto, atribuir um identificador de idioma a uma porção de texto e salvar o resultado como um arquivo PPTX.

## **Alterar idioma da apresentação e do texto da forma**

- Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/Presentation).
- Obtenha a referência de um slide usando seu Índice.
- Adicione um [AutoShape](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/AutoShape) do tipo [Rectangle](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/ShapeType#Rectangle) ao slide.
- Adicione algum texto ao TextFrame.
- [Definir ID de idioma](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/BasePortionFormat#setLanguageId-java.lang.String-) ao texto.
- Salve a apresentação como um arquivo PPTX.

A implementação das etapas acima é demonstrada abaixo em um exemplo.

```javascript
var pres = new aspose.slides.Presentation("test.pptx");
try {
    var shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 200, 50);
    shape.addTextFrame("Text to apply spellcheck language");
    shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().setLanguageId("en-EN");
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **FAQ**

**Definir o ID de idioma aciona a tradução automática do texto?**

Não. [setLanguageId](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/baseportionformat/#setLanguageId) no Aspose.Slides armazena o idioma para verificação ortográfica e correção gramatical, mas não traduz nem altera o conteúdo do texto. É um metadado que o PowerPoint entende para revisão.

**Definir o ID de idioma afeta a hifenização e quebras de linha durante a renderização?**

No Aspose.Slides, [setLanguageId](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/baseportionformat/#setLanguageId) serve para revisão. A qualidade da hifenização e a quebra de linha dependem principalmente da disponibilidade de [proper fonts](/slides/pt/nodejs-java/powerpoint-fonts/) e das configurações de layout/quebra de linha para o sistema de escrita. Para garantir a renderização correta, disponibilize as fontes necessárias, configure as [font substitution rules](/slides/pt/nodejs-java/font-substitution/) e/ou [embed fonts](/slides/pt/nodejs-java/embedded-font/) na apresentação.

**Posso definir diferentes idiomas dentro de um único parágrafo?**

Sim. [setLanguageId](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/baseportionformat/#setLanguageId) é aplicado ao nível da porção de texto, portanto um único parágrafo pode misturar vários idiomas com configurações de revisão distintas.