---
title: Criar um Visualizador de Apresentação em JavaScript
linktitle: Visualizador de Apresentação
type: docs
weight: 50
url: /pt/nodejs-java/presentation-viewer/
keywords:
- visualizar apresentação
- visualizador de apresentação
- criar visualizador de apresentação
- visualizar PPT
- visualizar PPTX
- visualizar ODP
- PowerPoint
- OpenDocument
- apresentação
- Node.js
- JavaScript
- Aspose.Slides
description: "Crie um visualizador de apresentação personalizado em JavaScript com Aspose.Slides para Node.js. Exiba facilmente arquivos PowerPoint e OpenDocument sem o Microsoft PowerPoint."
---
## **Introdução**

Aspose.Slides for Node.js via Java é usado para criar arquivos de apresentação com slides. Esses slides podem ser visualizados abrindo apresentações no Microsoft PowerPoint, por exemplo. No entanto, às vezes os desenvolvedores podem precisar visualizar slides como imagens em seu visualizador de imagens preferido ou criar seu próprio visualizador de apresentações. Nesses casos, o Aspose.Slides permite exportar um slide individual como uma imagem. Este artigo descreve como fazer isso.

## **Gerar uma Imagem SVG a partir de um Slide**

Para gerar uma imagem SVG a partir de um slide de apresentação com o Aspose.Slides, siga as etapas abaixo:

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/presentation/).
1. Obtenha a referência do slide pelo seu índice.
1. Abra um stream de arquivo.
1. Salve o slide como uma imagem SVG no stream de arquivo.

```javascript
var slideIndex = 0;

var presentation = new aspose.slides.Presentation("sample.pptx");
var slide = presentation.getSlides().get_Item(slideIndex);

var svgStream = java.newInstanceSync("java.io.FileOutputStream", "output.svg");
slide.writeAsSvg(svgStream);
svgStream.close();

presentation.dispose();
```

## **Gerar um SVG com um ID de Forma Personalizado**

O Aspose.Slides pode ser usado para gerar um [SVG](https://docs.fileformat.com/page-description-language/svg/) a partir de um slide com um ID de forma personalizado. Para isso, use o método `setId` de [SvgShape](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/svgshape/). `CustomSvgShapeFormattingController` pode ser usado para definir o ID da forma.

```javascript
var slideIndex = 0;

var presentation = new aspose.slides.Presentation("sample.pptx");
var slide = presentation.getSlides().get_Item(slideIndex);

var svgOptions = new aspose.slides.SVGOptions();
svgOptions.setShapeFormattingController(new CustomSvgShapeFormattingController(0));

var svgStream = java.newInstanceSync("java.io.FileOutputStream", "output.svg");
slide.writeAsSvg(svgStream, svgOptions);
svgStream.close();

presentation.dispose();
```
```javascript
class CustomSvgShapeFormattingController {
    constructor(shapeStartIndex = 0) {
        this.m_shapeIndex = shapeStartIndex;
    }

    formatShape(svgShape, shape) {
        svgShape.setId(`shape-${this.m_shapeIndex++}`);
    }
}
```

## **Criar uma Imagem Miniatura de um Slide**

O Aspose.Slides ajuda a gerar imagens em miniatura de slides. Para gerar uma miniatura de um slide usando o Aspose.Slides, siga as etapas abaixo:

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/presentation/).
1. Obtenha a referência do slide pelo seu índice.
1. Obtenha a imagem em miniatura do slide referenciado em uma escala definida.
1. Salve a imagem em miniatura em qualquer formato de imagem desejado.

```javascript
const slideIndex = 0;
const scaleX = 1;
const scaleY = scaleX;

var presentation = new aspose.slides.Presentation("sample.pptx");
var slide = presentation.getSlides().get_Item(slideIndex);

var image = slide.getImage(scaleX, scaleY);
image.save("output.jpg", aspose.slides.ImageFormat.Jpeg);
image.dispose();

presentation.dispose();
```

## **Criar uma Miniatura de Slide com Dimensões Definidas pelo Usuário**

Para criar uma imagem em miniatura de slide com dimensões definidas pelo usuário, siga as etapas abaixo:

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/presentation/).
1. Obtenha a referência do slide pelo seu índice.
1. Obtenha a imagem em miniatura do slide referenciado com as dimensões definidas.
1. Salve a imagem em miniatura em qualquer formato de imagem desejado.

```javascript
var slideIndex = 0;
var slideSize = java.newInstanceSync("java.awt.Dimension", 1200, 800);

var presentation = new aspose.slides.Presentation("sample.pptx");
var slide = presentation.getSlides().get_Item(slideIndex);

var image = slide.getImage(slideSize);
image.save("output.jpg", aspose.slides.ImageFormat.Jpeg);
image.dispose();

presentation.dispose();
```

## **Criar uma Miniatura de Slide com Notas do Apresentador**

Para gerar a miniatura de um slide com notas do apresentador usando o Aspose.Slides, siga as etapas abaixo:

1. Crie uma instância da classe [RenderingOptions](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/renderingoptions/).
1. Use o método `RenderingOptions.setSlidesLayoutOptions` para definir a posição das notas do apresentador.
1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/presentation/).
1. Obtenha a referência do slide pelo seu índice.
1. Obtenha a imagem em miniatura do slide referenciado com as opções de renderização.
1. Salve a imagem em miniatura em qualquer formato de imagem desejado.

```javascript
var slideIndex = 0;

var layoutingOptions = new aspose.slides.NotesCommentsLayoutingOptions();
layoutingOptions.setNotesPosition(aspose.slides.NotesPositions.BottomTruncated);

var renderingOptions = new aspose.slides.RenderingOptions();
renderingOptions.setSlidesLayoutOptions(layoutingOptions);

var presentation = new aspose.slides.Presentation("sample.pptx");
var slide = presentation.getSlides().get_Item(slideIndex);

var image = slide.getImage(renderingOptions);
image.save("output.png", aspose.slides.ImageFormat.Png);
image.dispose();

presentation.dispose();
```

## **Exemplo ao Vivo**

Você pode experimentar o aplicativo gratuito [**Aspose.Slides Viewer**](https://products.aspose.app/slides/pt/viewer/) para ver o que pode implementar com a API do Aspose.Slides:

![Online PowerPoint Viewer](online-PowerPoint-viewer.png)

## **FAQ**

**Posso incorporar um visualizador de apresentação em uma aplicação web Node.js?**

Sim. Você pode usar o Aspose.Slides no lado do servidor para renderizar slides como imagens ou HTML e exibi‑los no navegador. Recursos de navegação e zoom podem ser implementados com JavaScript para uma experiência interativa.

**Qual a melhor maneira de exibir slides dentro de um visualizador personalizado?**

A abordagem recomendada é renderizar cada slide como uma imagem (por exemplo, PNG ou SVG) ou convertê‑lo para HTML usando o Aspose.Slides, e então exibir o resultado dentro de um picture box (para desktop) ou de um contêiner HTML (para web).

**Como lidar com apresentações grandes com muitos slides?**

Para decks grandes, considere carregar os slides de forma preguiçosa (lazy‑loading) ou renderizá‑los sob demanda. Isso significa gerar o conteúdo de um slide somente quando o usuário navegar até ele, reduzindo o uso de memória e o tempo de carregamento.