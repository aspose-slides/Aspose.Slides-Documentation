---
title: Exportar Equações Matemáticas de Apresentações em JavaScript
linktitle: Exportar Equações
type: docs
weight: 30
url: /pt/nodejs-java/exporting-math-equations/
keywords:
- exportar equações matemáticas
- MathML
- LaTeX
- PowerPoint
- apresentação
- Node.js
- JavaScript
- Aspose.Slides
description: "Desbloqueie a exportação perfeita de equações matemáticas do PowerPoint para MathML usando JavaScript e Aspose.Slides para Node.js—preserve a formatação e aumente a compatibilidade."
---
## **Introdução**

O Aspose.Slides permite exportar equações matemáticas de apresentações. Por exemplo, você pode precisar extrair as equações matemáticas dos slides (de uma apresentação específica) e usá‑las em outro programa ou plataforma. 

{{% alert color="primary" %}} 
Você pode exportar equações para MathML, um formato ou padrão popular para equações matemáticas e conteúdo semelhante visto na web e em muitas aplicações. 
{{% /alert %}}

## **Salvar equações matemáticas como MathML**

Embora as pessoas escrevam facilmente o código para alguns formatos de equação, como LaTeX, tenham dificuldade em escrever o código para MathML, pois este último deve ser gerado automaticamente por aplicativos. Os programas leem e analisam MathML facilmente porque seu código está em XML, portanto MathML é comumente usado como formato de saída e impressão em muitos campos. 

Este código de exemplo mostra como exportar uma equação matemática de uma apresentação para MathML:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var autoShape = pres.getSlides().get_Item(0).getShapes().addMathShape(0, 0, 500, 50);
    var mathParagraph = autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getMathParagraph();
    mathParagraph.add(new aspose.slides.MathematicalText("a").setSuperscript("2").join("+").join(new aspose.slides.MathematicalText("b").setSuperscript("2")).join("=").join(new aspose.slides.MathematicalText("c").setSuperscript("2")));
    var stream = null;
    mathParagraph.writeAsMathMl(stream);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Perguntas frequentes**

**O que exatamente é exportado para MathML—um parágrafo ou um bloco de fórmula individual?**

Você pode exportar tanto um parágrafo completo de matemática ([MathParagraph](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/mathparagraph/)) quanto um bloco individual ([MathBlock](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/mathblock/)) para MathML. Ambos os tipos fornecem um método para escrever em MathML.

**Como posso saber se um objeto em um slide é uma fórmula matemática em vez de texto comum ou uma imagem?**

Uma fórmula reside em um [MathPortion](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/mathportion/) e tem um [MathParagraph](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/mathparagraph/). Imagens e porções de texto normais sem um [MathParagraph](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/mathparagraph/) não são fórmulas exportáveis.

**De onde vem o MathML em uma apresentação — é específico do PowerPoint ou um padrão?**

A exportação tem como alvo o MathML padrão (XML). O Aspose usa Presentation MathML — o subconjunto de apresentação do padrão — que é amplamente usado em aplicativos e na web.

**Exportar fórmulas dentro de tabelas, SmartArt, grupos, etc., é suportado?**

Sim, se esses objetos contiverem porções de texto com um [MathParagraph](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/mathparagraph/) (ou seja, verdadeiras fórmulas do PowerPoint), elas são exportadas. Se a fórmula estiver incorporada como imagem, não será.

**Exportar para MathML modifica a apresentação original?**

Não. Escrever MathML é uma serialização do conteúdo da fórmula; não modifica o arquivo da apresentação.