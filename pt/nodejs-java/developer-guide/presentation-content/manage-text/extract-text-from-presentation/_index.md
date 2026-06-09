---
title: Extração avançada de texto de apresentações em JavaScript
linktitle: Extrair texto
type: docs
weight: 90
url: /pt/nodejs-java/extract-text-from-presentation/
keywords:
- extrair texto
- extrair texto de slide
- extrair texto de apresentação
- extrair texto de PowerPoint
- extrair texto de OpenDocument
- extrair texto de PPT
- extrair texto de PPTX
- extrair texto de ODP
- recuperar texto
- recuperar texto de slide
- recuperar texto de apresentação
- recuperar texto de PowerPoint
- recuperar texto de OpenDocument
- recuperar texto de PPT
- recuperar texto de PPTX
- recuperar texto de ODP
- PowerPoint
- OpenDocument
- apresentação
- Node.js
- JavaScript
- Aspose.Slides
description: "Extraia rapidamente texto de apresentações PowerPoint e OpenDocument usando Aspose.Slides para Node.js via Java. Siga nosso guia simples, passo a passo, para economizar tempo."
---
## **Visão geral**

Extrair texto de apresentações é uma tarefa comum, porém essencial, para desenvolvedores que trabalham com conteúdo de slides. Seja lidando com arquivos Microsoft PowerPoint nos formatos PPT ou PPTX, ou com apresentações OpenDocument (ODP), acessar e recuperar dados textuais pode ser crítico para análise, automação, indexação ou migração de conteúdo.

Este artigo fornece um guia abrangente sobre como extrair texto de forma eficiente de vários formatos de apresentação, incluindo PPT, PPTX e ODP, usando Aspose.Slides for Node.js via Java. Você aprenderá como iterar sistematicamente pelos elementos da apresentação para recuperar com precisão o conteúdo de texto que precisa.

## **Extrair Texto de um Slide**

Aspose.Slides for Node.js via Java fornece a classe [SlideUtil](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/slideutil/) . Esta classe expõe vários métodos estáticos sobrecarregados para extrair todo o texto de uma apresentação ou slide. Para extrair texto de um slide em uma apresentação, use o método [getAllTextBoxes](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/slideutil/#getAllTextBoxes-aspose.slides.IBaseSlide-) . Este método aceita um objeto slide como parâmetro. Ao ser executado, o método varre todo o slide em busca de texto e retorna um array de objetos [TextFrame](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/textframe/) , preservando qualquer formatação de texto.

O trecho de código a seguir extrai todo o texto do primeiro slide da apresentação:

```javascript
const slideIndex = 0;

const presentation = new aspose.slides.Presentation("demo.pptx");
try {
    const slide = presentation.getSlides().get_Item(slideIndex);

    const textFrames = aspose.slides.SlideUtil.getAllTextBoxes(slide);

    for (let textFrameIndex = 0; textFrameIndex < textFrames.length; textFrameIndex++) {
        const textFrame = textFrames[textFrameIndex];

        const paragraphs = textFrame.getParagraphs();
        const paragraphCount = paragraphs.getCount();
        for (let paragraphIndex = 0; paragraphIndex < paragraphCount; paragraphIndex++) {
            const paragraph = paragraphs.get_Item(paragraphIndex);

            const portions = paragraph.getPortions();
            const portionCount = portions.getCount();
            for (let portionIndex = 0; portionIndex < portionCount; portionIndex++) {
                const portion = portions.get_Item(portionIndex);

                const portionText = portion.getText();
                console.log(portionText);

                const portionFormat = portion.getPortionFormat();
                const fontHeight = portionFormat.getFontHeight();
                console.log(fontHeight);

                const latinFont = portionFormat.getLatinFont();
                if (latinFont !== null) {
                    const fontName = latinFont.getFontName();
                    console.log(fontName);
                }
            }
        }
    }
} finally {
    presentation.dispose();
}
```

## **Extrair Texto de uma Apresentação**

Para percorrer o texto de toda a apresentação, use o método estático [getAllTextFrames](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/slideutil/#getAllTextFrames-aspose.slides.IPresentation-boolean-) exposto pela classe [SlideUtil](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/slideutil/) . Ele aceita dois parâmetros:

1. Primeiro, um objeto [Presentation](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/presentation/) que representa uma apresentação PowerPoint ou OpenDocument da qual o texto será extraído.
1. Segundo, um valor `boolean` que indica se os slides mestre devem ser incluídos ao percorrer o texto da apresentação.

O método retorna um array de objetos [TextFrame](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/textframe/) , incluindo informações de formatação de texto. O código abaixo percorre o texto e os detalhes de formatação de uma apresentação, incluindo os slides mestre.

```javascript
const presentation = new aspose.slides.Presentation("demo.pptx");
try {
    const includeMasterSlides = true;
    const textFrames = aspose.slides.SlideUtil.getAllTextFrames(presentation, includeMasterSlides);

    for (let textFrameIndex = 0; textFrameIndex < textFrames.length; textFrameIndex++) {
        const textFrame = textFrames[textFrameIndex];

        const paragraphs = textFrame.getParagraphs();
        const paragraphCount = paragraphs.getCount();
        for (let paragraphIndex = 0; paragraphIndex < paragraphCount; paragraphIndex++) {
            const paragraph = paragraphs.get_Item(paragraphIndex);

            const portions = paragraph.getPortions();
            const portionCount = portions.getCount();
            for (let portionIndex = 0; portionIndex < portionCount; portionIndex++) {
                const portion = portions.get_Item(portionIndex);

                const portionText = portion.getText();
                console.log(portionText);

                const portionFormat = portion.getPortionFormat();
                const fontHeight = portionFormat.getFontHeight();
                console.log(fontHeight);

                const latinFont = portionFormat.getLatinFont();
                if (latinFont !== null) {
                    const fontName = latinFont.getFontName();
                    console.log(fontName);
                }
            }
        }
    }
} finally {
    presentation.dispose();
}
```

## **Extração de Texto Categorizada e Rápida**

A classe [PresentationFactory](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/presentationfactory/) também fornece métodos para extrair todo o texto de apresentações:

```javascript
PresentationText getPresentationText(String file, int mode);
PresentationText getPresentationText(InputStream stream, int mode);
PresentationText getPresentationText(InputStream stream, int mode, LoadOptions options);
```

O argumento enum [TextExtractionArrangingMode](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/textextractionarrangingmode/) indica o modo de organização do resultado da extração de texto e pode ser definido com os seguintes valores:
- `Unarranged` - O texto bruto sem consideração da sua posição no slide.
- `Arranged` - O texto é organizado na mesma ordem em que aparece no slide.

O modo desorganizado pode ser usado quando a velocidade é crítica; ele é mais rápido que o modo organizado.

[PresentationText](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/presentationtext/) representa o texto bruto extraído da apresentação. Seu método `getSlidesText` retorna um array de objetos, cada um representando o texto do slide correspondente. Cada objeto de texto de slide possui os seguintes métodos:

- Seu método `getText` retorna o texto dentro das formas do slide.
- Seu método `getMasterText` retorna o texto dentro das formas do slide mestre associado a este slide.
- Seu método `getLayoutText` retorna o texto dentro das formas do slide de layout associado a este slide.
- Seu método `getNotesText` retorna o texto dentro das formas do slide de notas associado a este slide.
- Seu método `getCommentsText` retorna o texto dentro dos comentários associados a este slide.

```javascript
const presentationPath = "presentation.ppt";
const arrangingMode = aspose.slides.TextExtractionArrangingMode.Unarranged;
const presentationText = aspose.slides.PresentationFactory.getInstance().getPresentationText(presentationPath, arrangingMode);
const firstSlideText = presentationText.getSlidesText()[0];

console.log(firstSlideText.getText());
console.log(firstSlideText.getLayoutText());
console.log(firstSlideText.getMasterText());
console.log(firstSlideText.getNotesText());
console.log(firstSlideText.getCommentsText());
```

## **Perguntas Frequentes**

**Quão rápido o Aspose.Slides processa apresentações grandes durante a extração de texto?**

O Aspose.Slides está otimizado para alto desempenho e pode processar até mesmo [apresentações grandes](/slides/pt/nodejs-java/open-presentation/), tornando-o adequado para cenários de processamento em tempo real ou em lote.

**O Aspose.Slides pode extrair texto de tabelas e gráficos dentro das apresentações?**

Sim. O Aspose.Slides pode extrair texto de vários elementos de slide, incluindo tabelas e objetos relacionados a gráficos, permitindo que você acesse e analise o conteúdo textual em estruturas comuns de apresentação.

**Preciso de uma licença especial do Aspose.Slides para extrair texto de apresentações?**

Você pode extrair texto usando a versão de avaliação gratuita do Aspose.Slides, embora ela tenha [certas limitações](/slides/pt/nodejs-java/licensing/), como processar apenas um número limitado de slides. Para uso sem restrições e para lidar com apresentações maiores, recomenda-se adquirir uma licença completa.