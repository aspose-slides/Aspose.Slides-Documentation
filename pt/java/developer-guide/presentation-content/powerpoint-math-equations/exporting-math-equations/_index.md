---
title: Exportar Equações Matemáticas de Apresentações em Java
linktitle: Exportar Equações
type: docs
weight: 30
url: /pt/java/exporting-math-equations/
keywords:
- exportar equações matemáticas
- exportar equações para LaTeX
- PowerPoint para LaTeX
- MathML
- LaTeX
- PowerPoint
- apresentação
- Java
- Aspose.Slides
description: "Exportar equações matemáticas de apresentações PowerPoint para LaTeX ou MathML diretamente com Aspose.Slides para Java."
---
## **Introdução**

O Aspose.Slides permite que você exporte equações matemáticas de apresentações. Por exemplo, pode ser necessário extrair as equações matemáticas dos slides (de uma apresentação específica) e usá‑las em outro programa ou plataforma. 

{{% alert color="info" %}} 

É possível exportar equações diretamente para LaTeX ou para MathML, um padrão popular de conteúdo matemático usado na web e em muitas aplicações.

{{% /alert %}}

## **Exportar Equações Matemáticas para LaTeX**

O Aspose.Slides pode converter uma equação matemática do PowerPoint diretamente para LaTeX; não é necessário um arquivo intermediário MathML nem um conversor externo. Uma equação matemática é armazenada em uma caixa de texto como um [IMathPortion](https://reference.aspose.com/slides/pt/java/com.aspose.slides/imathportion/). Use [IMathPortion.getMathParagraph](https://reference.aspose.com/slides/pt/java/com.aspose.slides/imathportion/#getMathParagraph--) para obter um [IMathParagraph](https://reference.aspose.com/slides/pt/java/com.aspose.slides/imathparagraph/), e então chame [IMathParagraph.toLatex](https://reference.aspose.com/slides/pt/java/com.aspose.slides/imathparagraph/#toLatex--). O método retorna uma string que você pode salvar, exibir, enviar para outra aplicação ou processar ulteriormente.

O exemplo a seguir examina todas as caixas de texto em cada slide, encontra todas as partes matemáticas e grava cada equação em um arquivo `.tex` separado:

```java
Presentation presentation = new Presentation("equations.pptx");
try {
    int slideCount = presentation.getSlides().size();
    for (int slideIndex = 0; slideIndex < slideCount; slideIndex++) {
        ISlide slide = presentation.getSlides().get_Item(slideIndex);
        int slideNumber = slideIndex + 1;
        int equationNumber = 1;
        ITextFrame[] textFrames = SlideUtil.getAllTextBoxes(slide);

        for (ITextFrame textFrame : textFrames) {
            for (IParagraph paragraph : textFrame.getParagraphs()) {
                for (IPortion portion : paragraph.getPortions()) {
                    if (!(portion instanceof IMathPortion))
                        continue;

                    IMathPortion mathPortion = (IMathPortion) portion;
                    IMathParagraph mathParagraph = mathPortion.getMathParagraph();
                    String latexFileName = "slide_" + slideNumber + "_equation_" + equationNumber + ".tex";

                    String latexText = mathParagraph.toLatex();
                    Path latexPath = Paths.get(latexFileName);
                    byte[] latexBytes = latexText.getBytes(StandardCharsets.UTF_8);
                    Files.write(latexPath, latexBytes);
                    equationNumber++;
                }
            }
        }
    }
} finally {
    presentation.dispose();
}
```

[SlideUtil.getAllTextBoxes](https://reference.aspose.com/slides/pt/java/com.aspose.slides/slideutil/#getAllTextBoxes-com.aspose.slides.IBaseSlide-) retorna todas as caixas de texto encontradas em um slide. A verificação de tipo [IMathPortion](https://reference.aspose.com/slides/pt/java/com.aspose.slides/imathportion/) separa equações editáveis genuínas de texto e imagens comuns.

Os mecanismos LaTeX e os modelos de documento não suportam todos os mesmos comandos, pacotes ou caracteres Unicode. Teste a string retornada com o mecanismo LaTeX usado pela sua aplicação. Se um símbolo ou elemento Office Math não tiver representação adequada nesse ambiente, substitua‑o na string retornada por um comando específico do projeto ou ignore a equação e registre o problema para análise.

## **Salvar Equações Matemáticas como MathML**

Embora os humanos escrevam facilmente o código para alguns formatos de equação como LaTeX, eles têm dificuldade em escrever o código para MathML, pois este último deve ser gerado automaticamente por aplicativos. Os programas leem e analisam MathML facilmente porque seu código está em XML, portanto MathML é comumente usado como formato de saída e impressão em muitos campos. 

Este código de exemplo mostra como exportar uma equação matemática de uma apresentação para MathML:

```java
import com.aspose.slides.*;
import java.io.FileOutputStream;
import java.io.IOException;

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

## **FAQ**

**O que exatamente é exportado para MathML—um parágrafo ou um bloco de fórmula individual?**

Você pode exportar tanto um parágrafo matemático completo ([MathParagraph](https://reference.aspose.com/slides/pt/java/com.aspose.slides/mathparagraph/)) quanto um bloco individual ([MathBlock](https://reference.aspose.com/slides/pt/java/com.aspose.slides/mathblock/)) para MathML. Ambos os tipos fornecem um método para gravar em MathML.

**Como posso identificar que um objeto em um slide é uma fórmula matemática e não texto comum ou uma imagem?**

Uma fórmula está contida em um [MathPortion](https://reference.aspose.com/slides/pt/java/com.aspose.slides/mathportion/) e possuí um [MathParagraph](https://reference.aspose.com/slides/pt/java/com.aspose.slides/mathparagraph/). Imagens e trechos de texto regulares sem um [MathParagraph](https://reference.aspose.com/slides/pt/java/com.aspose.slides/mathparagraph/) não são fórmulas exportáveis.

**De onde vem o MathML em uma apresentação—é específico do PowerPoint ou um padrão?**

A exportação tem como alvo o MathML padrão (XML). O Aspose usa Presentation MathML—o subconjunto de apresentação do padrão—que é amplamente utilizado em aplicativos e na web.

**A exportação de fórmulas dentro de tabelas, SmartArt, grupos, etc., é suportada?**

Sim, se esses objetos contiverem trechos de texto com um [MathParagraph](https://reference.aspose.com/slides/pt/java/com.aspose.slides/mathparagraph/) (ou seja, fórmulas genuínas do PowerPoint), eles são exportados. Se a fórmula estiver incorporada como imagem, não será exportada.

**A exportação para MathML modifica a apresentação original?**

Não. Gravar MathML é uma serialização do conteúdo da fórmula; não altera o arquivo da apresentação.