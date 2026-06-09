---
title: Exportar Equações Matemáticas de Apresentações em Python
linktitle: Exportar Equações
type: docs
weight: 30
url: /pt/python-net/exporting-math-equations/
keywords:
- exportar equações matemáticas
- MathML
- LaTeX
- PowerPoint
- apresentação
- Python
- Aspose.Slides
description: "Desbloqueie a exportação perfeita de equações matemáticas do PowerPoint para MathML usando Aspose.Slides for Python via .NET—preserve a formatação e aumente a compatibilidade."
---
## **Introdução**

Aspose.Slides for Python via .NET permite exportar equações matemáticas de apresentações. Por exemplo, pode ser necessário extrair equações de slides específicos e reutilizá‑las em outro programa ou plataforma.

{{% alert color="primary" %}}
Você pode exportar equações para MathML, um padrão amplamente usado para representar conteúdo matemático na web e em muitas aplicações.
{{% /alert %}}

## **Salvar Equações Matemáticas como MathML**

Embora os humanos possam escrever LaTeX facilmente, o MathML geralmente é gerado automaticamente por aplicativos. Como o MathML é baseado em XML, os programas podem lê‑lo e analisá‑lo de forma confiável, sendo comumente usado como formato de saída e impressão em diversos campos.

O código de exemplo a seguir mostra como exportar uma equação matemática de uma apresentação para MathML:

```py
import aspose.slides as slides
import aspose.slides.mathtext as math

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes.add_math_shape(0, 0, 500, 50)
    math_paragraph = auto_shape.text_frame.paragraphs[0].portions[0].math_paragraph

    math_paragraph.add(
        math.MathematicalText("a").
            set_superscript("2").
            join("+").
            join(math.MathematicalText("b").set_superscript("2")).
            join("=").
            join(math.MathematicalText("c").set_superscript("2")))

    with open("mathml.xml", "wb") as file_stream:
        math_paragraph.write_as_math_ml(file_stream)
```

## **Perguntas Frequentes**

**O que exatamente é exportado para MathML—um parágrafo ou um bloco de fórmula individual?**

Você pode exportar tanto um parágrafo matemático inteiro ([MathParagraph](https://reference.aspose.com/slides/pt/python-net/aspose.slides.mathtext/mathparagraph/)) quanto um bloco individual ([MathBlock](https://reference.aspose.com/slides/pt/python-net/aspose.slides.mathtext/mathblock/)) para MathML. Ambos os tipos fornecem um método para gravar em MathML.

**Como saber se um objeto em um slide é uma fórmula matemática em vez de texto comum ou imagem?**

Uma fórmula reside em uma [MathPortion](https://reference.aspose.com/slides/pt/python-net/aspose.slides.mathtext/mathportion/) e possui um [MathParagraph](https://reference.aspose.com/slides/pt/python-net/aspose.slides.mathtext/mathparagraph/). Imagens e trechos de texto comuns sem um [MathParagraph](https://reference.aspose.com/slides/pt/python-net/aspose.slides.mathtext/mathparagraph/) não são fórmulas exportáveis.

**De onde vem o MathML em uma apresentação—é específico do PowerPoint ou um padrão?**

A exportação tem como alvo o MathML padrão (XML). A Aspose usa Presentation MathML—o subconjunto de apresentação do padrão—que é amplamente utilizado em aplicações e na web.

**A exportação de fórmulas dentro de tabelas, SmartArt, grupos etc., é suportada?**

Sim, se esses objetos contiverem trechos de texto com um [MathParagraph](https://reference.aspose.com/slides/pt/python-net/aspose.slides.mathtext/mathparagraph/) (ou seja, fórmulas genuínas do PowerPoint), elas são exportadas. Se a fórmula estiver incorporada como imagem, não será exportada.

**A exportação para MathML modifica a apresentação original?**

Não. Gravar MathML é uma serialização do conteúdo da fórmula; não modifica o arquivo da apresentação.