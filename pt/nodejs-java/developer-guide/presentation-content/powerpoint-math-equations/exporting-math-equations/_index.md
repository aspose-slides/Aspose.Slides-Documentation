---
title: Exportar Equações Matemáticas de Apresentações em JavaScript
linktitle: Exportar Equações
type: docs
weight: 30
url: /pt/nodejs-java/exporting-math-equations/
keywords:
- exportar equações matemáticas
- exportar equações para LaTeX
- PowerPoint para LaTeX
- MathML
- LaTeX
- PowerPoint
- apresentação
- Node.js
- JavaScript
- Aspose.Slides
description: "Exporte equações matemáticas de apresentações PowerPoint para LaTeX ou MathML diretamente com Aspose.Slides para Node.js via Java."
---
## **Introdução**

Aspose.Slides permite exportar equações matemáticas de apresentações. Por exemplo, pode ser necessário extrair as equações matemáticas dos slides (de uma apresentação específica) e usá‑las em outro programa ou plataforma. 

{{% alert color="primary" %}} 

Você pode exportar equações diretamente para LaTeX ou para MathML, um padrão popular de conteúdo matemático usado na web e em muitas aplicações.

{{% /alert %}}

## **Exportar Equações Matemáticas para LaTeX**

Aspose.Slides pode converter uma equação matemática do PowerPoint diretamente para LaTeX; não é necessário um arquivo intermediário MathML nem um conversor externo. Uma equação matemática é armazenada em um quadro de texto como um [MathPortion](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/mathportion/). Use [MathPortion.getMathParagraph](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/mathportion/#getMathParagraph--) para obter um [MathParagraph](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/mathparagraph/), e então chame [MathParagraph.toLatex](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/mathparagraph/#toLatex--). O método devolve uma string que você pode salvar, exibir, enviar para outra aplicação ou processar adicionalmente.

O exemplo a seguir examina cada quadro de texto em cada slide, encontra todas as porções de matemática e grava cada equação em um arquivo `.tex` separado:

```javascript
const presentation = new aspose.slides.Presentation("equations.pptx");
try {
    const slideCount = presentation.getSlides().size();
    for (let slideIndex = 0; slideIndex < slideCount; slideIndex++) {
        const slide = presentation.getSlides().get_Item(slideIndex);
        const slideNumber = slideIndex + 1;
        let equationNumber = 1;
        const textFrames = aspose.slides.SlideUtil.getAllTextBoxes(slide);

        for (const textFrame of textFrames) {
            const paragraphCount = textFrame.getParagraphs().getCount();
            for (let paragraphIndex = 0; paragraphIndex < paragraphCount; paragraphIndex++) {
                const paragraph = textFrame.getParagraphs().get_Item(paragraphIndex);
                const portionCount = paragraph.getPortions().getCount();
                for (let portionIndex = 0; portionIndex < portionCount; portionIndex++) {
                    const portion = paragraph.getPortions().get_Item(portionIndex);
                    if (!java.instanceOf(portion, "com.aspose.slides.MathPortion")) {
                        continue;
                    }

                    const mathParagraph = portion.getMathParagraph();
                    const latexFileName = `slide_${slideNumber}_equation_${equationNumber}.tex`;

                    const latexText = mathParagraph.toLatex();
                    fileSystem.writeFileSync(latexFileName, latexText, "utf8");
                    equationNumber++;
                }
            }
        }
    }
} finally {
    presentation.dispose();
}
```

[SlideUtil.getAllTextBoxes](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/slideutil/#getAllTextBoxes-aspose.slides.IBaseSlide-) devolve todos os quadros de texto encontrados em um slide. A verificação de tipo [MathPortion](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/mathportion/) separa equações editáveis genuínas de texto comum e imagens.

Os mecanismos LaTeX e os modelos de documento não suportam todos os mesmos comandos, pacotes ou caracteres Unicode. Teste a string retornada com o mecanismo LaTeX usado pela sua aplicação. Se um símbolo ou elemento Office Math não tiver representação adequada naquele ambiente, substitua‑o na string retornada por um comando específico do projeto ou ignore a equação e registre o problema para revisão.

## **Salvar Equações Matemáticas como MathML**

Embora humanos escrevam facilmente o código para alguns formatos de equação como LaTeX, eles têm dificuldade em escrever o código para MathML porque este último deve ser gerado automaticamente por aplicativos. Os programas leem e analisam MathML facilmente porque seu código está em XML, de modo que MathML é comumente usado como formato de saída e impressão em muitas áreas. 

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

## **Perguntas Frequentes**

**O que exatamente é exportado para MathML—um parágrafo ou um bloco de fórmula individual?**

Você pode exportar tanto um parágrafo matemático inteiro ([MathParagraph](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/mathparagraph/)) quanto um bloco individual ([MathBlock](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/mathblock/)) para MathML. Ambos os tipos fornecem um método para escrever em MathML.

**Como posso saber se um objeto em um slide é uma fórmula matemática em vez de texto normal ou imagem?**

Uma fórmula reside em um [MathPortion](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/mathportion/) e possui um [MathParagraph](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/mathparagraph/). Imagens e porções de texto regulares sem um [MathParagraph](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/mathparagraph/) não são fórmulas exportáveis.

**De onde vem o MathML em uma apresentação—é específico do PowerPoint ou um padrão?**

A exportação tem como alvo o MathML padrão (XML). O Aspose usa Presentation MathML—o subconjunto de apresentação do padrão—que é amplamente usado em aplicações e na web.

**A exportação de fórmulas dentro de tabelas, SmartArt, grupos etc. é suportada?**

Sim, se esses objetos contiverem porções de texto com um [MathParagraph](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/mathparagraph/) (ou seja, fórmulas genuínas do PowerPoint), elas são exportadas. Se a fórmula estiver incorporada como imagem, não será.

**A exportação para MathML altera a apresentação original?**

Não. Escrever MathML é uma serialização do conteúdo da fórmula; não modifica o arquivo da apresentação.