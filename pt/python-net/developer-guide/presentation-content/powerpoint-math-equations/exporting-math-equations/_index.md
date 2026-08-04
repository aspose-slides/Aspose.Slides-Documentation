---
title: Exportar Equações Matemáticas de Apresentações em Python
linktitle: Exportar Equações
type: docs
weight: 30
url: /pt/python-net/exporting-math-equations/
keywords:
- exportar equações matemáticas
- exportar equações para LaTeX
- PowerPoint para LaTeX
- MathML
- LaTeX
- PowerPoint
- apresentação
- Python
- Aspose.Slides
description: "Exportar equações matemáticas de apresentações PowerPoint para LaTeX ou MathML diretamente com Aspose.Slides for Python via .NET."
---
## **Introdução**

Aspose.Slides for Python via .NET permite exportar equações matemáticas de apresentações. Por exemplo, pode ser necessário extrair equações de slides específicos e reutilizá‑las em outro programa ou plataforma.

{{% alert color="primary" %}}
Você pode exportar equações diretamente para LaTeX ou para MathML, um padrão popular para conteúdo matemático usado na web e em muitas aplicações.
{{% /alert %}}

## **Exportar Equações Matemáticas para LaTeX**

Aspose.Slides pode converter uma equação matemática do PowerPoint diretamente para LaTeX; não é necessário um arquivo MathML intermediário nem um conversor externo. A equação matemática é armazenada em um quadro de texto como um [MathPortion](https://reference.aspose.com/slides/pt/python-net/aspose.slides.mathtext/mathportion/). Use [MathPortion.math_paragraph](https://reference.aspose.com/slides/pt/python-net/aspose.slides.mathtext/mathportion/math_paragraph/) para obter um [MathParagraph](https://reference.aspose.com/slides/pt/python-net/aspose.slides.mathtext/mathparagraph/), e então chame [MathParagraph.to_latex](https://reference.aspose.com/slides/pt/python-net/aspose.slides.mathtext/mathparagraph/to_latex/). O método retorna uma string que pode ser salva, exibida, enviada para outra aplicação ou processada posteriormente.

O exemplo a seguir examina cada quadro de texto em cada slide, encontra todas as porções de matemática e grava cada equação em um arquivo `.tex` separado:

```py
import aspose.slides as slides

with slides.Presentation("equations.pptx") as presentation:
    for slide_number, slide in enumerate(presentation.slides, start=1):
        equation_number = 1
        text_frames = slides.util.SlideUtil.get_all_text_boxes(slide)

        for text_frame in text_frames:
            for paragraph in text_frame.paragraphs:
                for portion in paragraph.portions:
                    if not isinstance(portion, slides.mathtext.MathPortion):
                        continue

                    math_paragraph = portion.math_paragraph
                    latex_path = f"slide_{slide_number}_equation_{equation_number}.tex"

                    latex_text = math_paragraph.to_latex()
                    with open(latex_path, "w", encoding="utf-8") as latex_file:
                        latex_file.write(latex_text)
                    equation_number += 1
```

[SlideUtil.get_all_text_boxes](https://reference.aspose.com/slides/pt/python-net/aspose.slides.util/slideutil/get_all_text_boxes/) retorna todos os quadros de texto encontrados em um slide. A verificação de tipo [MathPortion](https://reference.aspose.com/slides/pt/python-net/aspose.slides.mathtext/mathportion/) separa equações editáveis genuínas de texto e imagens comuns.

Os mecanismos LaTeX e os modelos de documento não suportam todos os mesmos comandos, pacotes ou caracteres Unicode. Teste a string retornada com o mecanismo LaTeX usado por sua aplicação. Se um símbolo ou elemento Office Math não tiver uma representação adequada nesse ambiente, substitua‑o na string retornada por um comando específico do projeto ou ignore a equação e registre o problema para revisão.

## **Salvar Equações Matemáticas como MathML**

Embora os humanos possam escrever LaTeX facilmente, o MathML costuma ser gerado automaticamente por aplicações. Como o MathML é baseado em XML, os programas podem lê‑lo e analisá‑lo de forma confiável, sendo comumente usado como formato de saída e impressão em diversas áreas.

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

## **FAQ**

**O que exatamente é exportado para MathML—um parágrafo ou um bloco de fórmula individual?**

Você pode exportar tanto um parágrafo inteiro de matemática ([MathParagraph](https://reference.aspose.com/slides/pt/python-net/aspose.slides.mathtext/mathparagraph/)) quanto um bloco individual ([MathBlock](https://reference.aspose.com/slides/pt/python-net/aspose.slides.mathtext/mathblock/)) para MathML. Ambos os tipos fornecem um método para gravar em MathML.

**Como posso saber se um objeto em um slide é uma fórmula matemática ao invés de texto ou imagem comum?**

Uma fórmula reside em um [MathPortion](https://reference.aspose.com/slides/pt/python-net/aspose.slides.mathtext/mathportion/) e possui um [MathParagraph](https://reference.aspose.com/slides/pt/python-net/aspose.slides.mathtext/mathparagraph/). Imagens e porções de texto regulares sem um [MathParagraph](https://reference.aspose.com/slides/pt/python-net/aspose.slides.mathtext/mathparagraph/) não são fórmulas exportáveis.

**De onde vem o MathML em uma apresentação—é específico do PowerPoint ou um padrão?**

A exportação tem como alvo o MathML padrão (XML). A Aspose usa Presentation MathML—o subconjunto de apresentação do padrão—que é amplamente usado em aplicações e na web.

**A exportação de fórmulas dentro de tabelas, SmartArt, grupos etc., é suportada?**

Sim, se esses objetos contêm porções de texto com um [MathParagraph](https://reference.aspose.com/slides/pt/python-net/aspose.slides.mathtext/mathparagraph/) (ou seja, fórmulas genuínas do PowerPoint), elas são exportadas. Se uma fórmula estiver incorporada como imagem, não será.

**A exportação para MathML modifica a apresentação original?**

Não. Gravar MathML é uma serialização do conteúdo da fórmula; não altera o arquivo da apresentação.