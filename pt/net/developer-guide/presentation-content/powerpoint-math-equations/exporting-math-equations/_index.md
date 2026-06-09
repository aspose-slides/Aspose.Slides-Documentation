---
title: Exportar Equações Matemáticas de Apresentações em .NET
linktitle: Exportar Equações
type: docs
weight: 30
url: /pt/net/exporting-math-equations/
keywords:
- exportar equações matemáticas
- MathML
- LaTeX
- PowerPoint
- apresentação
- .NET
- C#
- Aspose.Slides
description: "Desbloqueie a exportação contínua de equações matemáticas do PowerPoint para MathML usando Aspose.Slides para .NET - preserve a formatação e aumente a compatibilidade."
---
## **Introdução**

Aspose.Slides for .NET permite exportar equações matemáticas de apresentações. Por exemplo, pode ser necessário extrair as equações matemáticas dos slides (de uma apresentação específica) e utilizá‑las em outro programa ou plataforma. 

{{% alert color="primary" %}} 

Você pode exportar equações para MathML, um formato ou padrão popular para equações matemáticas e conteúdo similar visto na web e em muitas aplicações. 

{{% /alert %}}

## **Salvar Equações Matemáticas como MathML**

Embora os humanos escrevam facilmente o código para alguns formatos de equação, como LaTeX, eles têm dificuldade para escrever o código para MathML, pois este deve ser gerado automaticamente por aplicativos. Os programas leem e analisam MathML facilmente porque seu código está em XML, de modo que MathML é comumente usado como formato de saída e impressão em muitos campos. 

Este código de exemplo mostra como exportar uma equação matemática de uma apresentação para MathML:

```c#
using (Presentation pres = new Presentation())
        {
            var autoShape = pres.Slides[0].Shapes.AddMathShape(0, 0, 500, 50);
            var mathParagraph = ((MathPortion)autoShape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;

            mathParagraph.Add(new MathematicalText("a").SetSuperscript("2").Join("+").Join(new MathematicalText("b").SetSuperscript("2")).Join("=").Join(new MathematicalText("c").SetSuperscript("2")));

       using (Stream stream = new FileStream("mathml.xml", FileMode.Create))
                mathParagraph.WriteAsMathMl(stream);
        }
```

## **Perguntas Frequentes**

**O que exatamente é exportado para MathML—um parágrafo ou um bloco de fórmula individual?**

Você pode exportar tanto um parágrafo matemático inteiro ([MathParagraph](https://reference.aspose.com/slides/pt/net/aspose.slides.mathtext/mathparagraph/)) quanto um bloco individual ([MathBlock](https://reference.aspose.com/slides/pt/net/aspose.slides.mathtext/mathblock/)) para MathML. Ambos os tipos fornecem um método para gravar em MathML.

**Como posso identificar se um objeto em um slide é uma fórmula matemática em vez de texto comum ou uma imagem?**

Uma fórmula reside em uma [MathPortion](https://reference.aspose.com/slides/pt/net/aspose.slides.mathtext/mathportion/) e tem um [MathParagraph](https://reference.aspose.com/slides/pt/net/aspose.slides.mathtext/mathparagraph/). Imagens e trechos de texto comuns sem um [MathParagraph](https://reference.aspose.com/slides/pt/net/aspose.slides.mathtext/mathparagraph/) não são fórmulas exportáveis.

**De onde vem o MathML em uma apresentação—é específico do PowerPoint ou um padrão?**

A exportação tem como alvo o MathML padrão (XML). Aspose usa Presentation MathML—o subconjunto de apresentação do padrão—que é amplamente utilizado em aplicativos e na web.

**A exportação de fórmulas dentro de tabelas, SmartArt, grupos etc. é suportada?**

Sim, se esses objetos contiverem trechos de texto com um [MathParagraph](https://reference.aspose.com/slides/pt/net/aspose.slides.mathtext/mathparagraph/) (ou seja, fórmulas genuínas do PowerPoint), eles são exportados. Se uma fórmula estiver incorporada como imagem, não será.

**Exportar para MathML modifica a apresentação original?**

Não. Gerar MathML é uma serialização do conteúdo da fórmula; não modifica o arquivo da apresentação.