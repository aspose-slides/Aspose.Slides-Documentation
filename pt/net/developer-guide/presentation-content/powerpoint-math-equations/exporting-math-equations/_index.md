---
title: Exportar Equações Matemáticas de Apresentações em .NET
linktitle: Exportar Equações
type: docs
weight: 30
url: /pt/net/exporting-math-equations/
keywords:
- exportar equações matemáticas
- exportar equações para LaTeX
- PowerPoint para LaTeX
- MathML
- LaTeX
- PowerPoint
- apresentação
- .NET
- C#
- Aspose.Slides
description: "Exporte equações matemáticas de apresentações PowerPoint para LaTeX ou MathML diretamente com Aspose.Slides para .NET."
---
## **Introdução**

Aspose.Slides for .NET permite exportar equações matemáticas de apresentações. Por exemplo, você pode precisar extrair as equações matemáticas dos slides (de uma apresentação específica) e usá‑las em outro programa ou plataforma. 

{{% alert color="primary" %}} 

Você pode exportar equações diretamente para LaTeX ou para MathML, um padrão popular para conteúdo matemático usado na web e em muitas aplicações.

{{% /alert %}}

## **Exportar Equações Matemáticas para LaTeX**

Aspose.Slides pode converter uma equação matemática do PowerPoint diretamente para LaTeX; um arquivo intermediário MathML e um conversor externo não são necessários. Uma equação matemática é armazenada em um quadro de texto como um [MathPortion](https://reference.aspose.com/slides/pt/net/aspose.slides.mathtext/mathportion/). Use [MathPortion.MathParagraph](https://reference.aspose.com/slides/pt/net/aspose.slides.mathtext/mathportion/mathparagraph/) para obter um [IMathParagraph](https://reference.aspose.com/slides/pt/net/aspose.slides.mathtext/imathparagraph/), e então chame [IMathParagraph.ToLatex](https://reference.aspose.com/slides/pt/net/aspose.slides.mathtext/imathparagraph/tolatex/). O método retorna uma string que você pode salvar, exibir, enviar para outra aplicação ou processar mais adiante.

O exemplo a seguir examina cada quadro de texto em cada slide, encontra todas as partes matemáticas e grava cada equação em um arquivo `.tex` separado:

```csharp
using var presentation = new Presentation("equations.pptx");

for (var slideIndex = 0; slideIndex < presentation.Slides.Count; slideIndex++)
{
    var slide = presentation.Slides[slideIndex];
    var slideNumber = slideIndex + 1;
    var equationNumber = 1;
    var textFrames = SlideUtil.GetAllTextBoxes(slide);

    foreach (var textFrame in textFrames)
    {
        foreach (var paragraph in textFrame.Paragraphs)
        {
            foreach (var portion in paragraph.Portions)
            {
                if (portion is not MathPortion mathPortion)
                    continue;

                IMathParagraph mathParagraph = mathPortion.MathParagraph;
                var latexPath = $"slide_{slideNumber}_equation_{equationNumber}.tex";

                var latexText = mathParagraph.ToLatex();
                File.WriteAllText(latexPath, latexText);
                equationNumber++;
            }
        }
    }
}
```

[SlideUtil.GetAllTextBoxes](https://reference.aspose.com/slides/pt/net/aspose.slides.util/slideutil/getalltextboxes/) retorna todos os quadros de texto encontrados em um slide. A verificação de tipo [MathPortion](https://reference.aspose.com/slides/pt/net/aspose.slides.mathtext/mathportion/) separa equações editáveis genuínas de texto e imagens comuns.

Os motores LaTeX e os modelos de documento não suportam todos os mesmos comandos, pacotes ou caracteres Unicode. Teste a string retornada com o motor LaTeX usado pela sua aplicação. Se um símbolo ou elemento Office Math não tiver representação adequada nesse ambiente, substitua‑o na string retornada por um comando específico do projeto ou ignore a equação e registre o problema para revisão.

## **Salvar Equações Matemáticas como MathML**

Embora as pessoas escrevam facilmente o código para alguns formatos de equação como LaTeX, elas têm dificuldades para escrever o código para MathML porque este último deve ser gerado automaticamente por aplicativos. Programas leem e analisam MathML facilmente porque seu código está em XML, portanto MathML é comumente usado como formato de saída e impressão em muitas áreas. 

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

**Como posso saber se um objeto em um slide é uma fórmula matemática em vez de texto comum ou uma imagem?**

Uma fórmula reside em um [MathPortion](https://reference.aspose.com/slides/pt/net/aspose.slides.mathtext/mathportion/) e possui um [MathParagraph](https://reference.aspose.com/slides/pt/net/aspose.slides.mathtext/mathparagraph/). Imagens e trechos de texto comuns sem um [MathParagraph](https://reference.aspose.com/slides/pt/net/aspose.slides.mathtext/mathparagraph/) não são fórmulas exportáveis.

**De onde vem o MathML em uma apresentação—é específico do PowerPoint ou um padrão?**

A exportação tem como alvo o MathML padrão (XML). Aspose usa Presentation MathML—o subconjunto de apresentação do padrão—que é amplamente usado em aplicativos e na web.

**A exportação de fórmulas dentro de tabelas, SmartArt, grupos, etc., é suportada?**

Sim, se esses objetos contiverem trechos de texto com um [MathParagraph](https://reference.aspose.com/slides/pt/net/aspose.slides.mathtext/mathparagraph/) (ou seja, fórmulas genuínas do PowerPoint), eles são exportados. Se uma fórmula estiver incorporada como imagem, não será.

**A exportação para MathML modifica a apresentação original?**

Não. Gravar MathML é uma serialização do conteúdo da fórmula; não modifica o arquivo da apresentação.