---
title: Exportar Equações Matemáticas de Apresentações no Android
linktitle: Exportar Equações
type: docs
weight: 30
url: /pt/androidjava/exporting-math-equations/
keywords:
- exportar equações matemáticas
- MathML
- LaTeX
- PowerPoint
- apresentação
- Android
- Java
- Aspose.Slides
description: "Desbloqueie a exportação perfeita de equações matemáticas do PowerPoint para MathML usando Aspose.Slides para Android via Java — preserve a formatação e aumente a compatibilidade."
---
## **Introdução**

Aspose.Slides para Android via Java permite exportar equações matemáticas de apresentações. Por exemplo, pode ser necessário extrair as equações matemáticas dos slides (de uma apresentação específica) e usá-las em outro programa ou plataforma.

{{% alert color="primary" %}} 
Você pode exportar equações para MathML, um formato ou padrão popular para equações matemáticas e conteúdo semelhante visto na web e em muitas aplicações. 
{{% /alert %}}

## **Exportar Equações Matemáticas de Apresentações**

Enquanto os humanos escrevem facilmente o código para alguns formatos de equação como LaTeX, eles têm dificuldade em escrever o código para MathML, pois este último foi projetado para ser gerado automaticamente por aplicativos. Os programas leem e analisam MathML facilmente porque seu código está em XML, portanto MathML é comumente usado como formato de saída e impressão em muitos campos. 

Este código de exemplo mostra como exportar uma equação matemática de uma apresentação para MathML:

```java
Presentation pres = new Presentation();
try {
    IAutoShape autoShape = pres.getSlides().get_Item(0).getShapes().addMathShape(0, 0, 500, 50);
    IMathParagraph mathParagraph = ((MathPortion)autoShape.getTextFrame().getParagraphs().get_Item(0).
            getPortions().get_Item(0)).getMathParagraph();

    mathParagraph.add(new MathematicalText("a").
            setSuperscript("2").
            join("+").
            join(new MathematicalText("b").setSuperscript("2")).
            join("=").
            join(new MathematicalText("c").setSuperscript("2")));

    FileOutputStream stream = new FileOutputStream("mathml.xml");
    mathParagraph.writeAsMathMl(stream);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **Perguntas Frequentes**

**O que exatamente é exportado para MathML — um parágrafo ou um bloco de fórmula individual?**

Você pode exportar tanto um parágrafo matemático inteiro ([MathParagraph](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/mathparagraph/)) quanto um bloco individual ([MathBlock](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/mathblock/)) para MathML. Ambos os tipos fornecem um método para gravar em MathML.

**Como posso saber se um objeto em um slide é uma fórmula matemática e não texto comum ou uma imagem?**

Uma fórmula está em uma [MathPortion](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/mathportion/) e possui um [MathParagraph](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/mathparagraph/). Imagens e porções de texto comuns sem um [MathParagraph](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/mathparagraph/) não são fórmulas exportáveis.

**De onde vem o MathML em uma apresentação — é específico do PowerPoint ou um padrão?**

A exportação tem como alvo o MathML padrão (XML). A Aspose utiliza Presentation MathML — o subconjunto de apresentação do padrão — que é amplamente usado em várias aplicações e na web.

**A exportação de fórmulas dentro de tabelas, SmartArt, grupos, etc., é suportada?**

Sim, se esses objetos contiverem porções de texto com um [MathParagraph](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/mathparagraph/) (ou seja, fórmulas genuínas do PowerPoint), elas são exportadas. Se uma fórmula estiver incorporada como imagem, não será.

**A exportação para MathML modifica a apresentação original?**

Não. Gerar MathML é uma serialização do conteúdo da fórmula; não modifica o arquivo da apresentação.