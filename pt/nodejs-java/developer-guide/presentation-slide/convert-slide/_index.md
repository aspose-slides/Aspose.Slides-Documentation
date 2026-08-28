---
title: Converter Slides de Apresentação em Imagens em JavaScript
linktitle: Slide para Imagem
type: docs
weight: 35
url: /pt/nodejs-java/convert-slide/
keywords:
- converter slide
- exportar slide
- slide para imagem
- salvar slide como imagem
- slide para EMF
- slide para PNG
- slide para JPEG
- slide para bitmap
- slide para TIFF
- PowerPoint
- OpenDocument
- apresentação
- Node.js
- JavaScript
- Aspose.Slides
description: "Converta slides de apresentações PPT, PPTX e ODP em PNG, JPEG, GIF, TIFF, EMF e outros formatos de imagem em JavaScript com Aspose.Slides."
---
## **Introdução**

Aspose.Slides for Node.js via Java pode renderizar slides individuais de apresentações PowerPoint e OpenDocument como PNG, JPEG, GIF, TIFF e outros formatos de imagem.

Para converter um slide em uma imagem, siga estas etapas:

1. Carregue a apresentação com a classe [Presentation](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/presentation/).
2. Selecione o slide que você deseja renderizar.
3. Se necessário, configure a renderização com a classe [RenderingOptions](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/renderingoptions/) ou [TiffOptions](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/tiffoptions/).
4. Chame o método [Slide.getImage](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/slide/#getImage). Ele retorna um objeto [IImage](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/iimage/).
5. Chame o método [IImage.save](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/iimage/#save) e especifique o formato de saída com um valor [ImageFormat](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/imageformat/).

## **Converter um Slide em Imagem PNG**

A conversão mais simples usa as configurações padrão de renderização. O objeto [IImage](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/iimage/) resultante pode ser processado na memória ou salvo em um arquivo.

O exemplo JavaScript a seguir renderiza o primeiro slide e o salva como imagem PNG:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const image = slide.getImage();
    try {
        image.save("Slide_0.png", aspose.slides.ImageFormat.Png);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

## **Converter Slides em Imagens com Tamanhos Personalizados**

Use a sobrecarga [Slide.getImage](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/slide/#getImage) que aceita um valor `java.awt.Dimension` para renderizar um slide com dimensões de pixels exatas.

O exemplo a seguir cria uma imagem JPEG de 1820 × 1040:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const imageSize = java.newInstanceSync("java.awt.Dimension", 1820, 1040);

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const image = slide.getImage(imageSize);
    try {
        image.save("Slide_0.jpg", aspose.slides.ImageFormat.Jpeg);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

## **Converter Slides com Anotações e Comentários em Imagens**

Por padrão, as imagens dos slides não incluem anotações nem comentários. Passe um objeto [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/notescommentslayoutingoptions/) para o método [RenderingOptions.setSlidesLayoutOptions](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/renderingoptions/#setSlidesLayoutOptions) para controlar onde as anotações e comentários aparecem.

O exemplo a seguir coloca anotações truncadas abaixo do slide e comentários à sua direita:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const scaleX = 2;
const scaleY = scaleX;

const commentsAreaColor = java.newInstanceSync("java.awt.Color", 250, 235, 215);

const layoutOptions = new aspose.slides.NotesCommentsLayoutingOptions();
layoutOptions.setNotesPosition(aspose.slides.NotesPositions.BottomTruncated);
layoutOptions.setCommentsPosition(aspose.slides.CommentsPositions.Right);
layoutOptions.setCommentsAreaWidth(500);
layoutOptions.setCommentsAreaColor(commentsAreaColor);

const renderingOptions = new aspose.slides.RenderingOptions();
renderingOptions.setSlidesLayoutOptions(layoutOptions);

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const image = slide.getImage(renderingOptions, scaleX, scaleY);
    try {
        image.save("Image_with_notes_and_comments_0.gif", aspose.slides.ImageFormat.Gif);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

{{% alert title="Warning" color="warning" %}}
Para a conversão de slide para imagem, não passe [BottomFull](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/notespositions/) para o método [NotesCommentsLayoutingOptions.setNotesPosition](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/notescommentslayoutingoptions/#setNotesPosition). As anotações podem conter mais texto do que o tamanho fixo da imagem comporta. Use [BottomTruncated](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/notespositions/) em vez disso.
{{% /alert %}}

## **Converter Slides em Imagens Usando Opções TIFF**

A classe [TiffOptions](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/tiffoptions/) permite controlar o tamanho, a resolução e outras propriedades da imagem TIFF renderizada.

O exemplo a seguir renderiza o primeiro slide como uma imagem TIFF de 2160 × 2880 a 300 DPI:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const imageSize = java.newInstanceSync("java.awt.Dimension", 2160, 2880);

const tiffOptions = new aspose.slides.TiffOptions();
tiffOptions.setImageSize(imageSize);
tiffOptions.setDpiX(300);
tiffOptions.setDpiY(300);

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const image = slide.getImage(tiffOptions);
    try {
        image.save("output.tiff", aspose.slides.ImageFormat.Tiff);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

{{% alert title="Warning" color="warning" %}}
O suporte a TIFF não é garantido em versões do Java anteriores ao JDK 9.
{{% /alert %}}

## **Converter Todos os Slides em Imagens**

Percorra a coleção de slides para converter toda a apresentação em uma série de imagens. Slides ocultos são incluídos, a menos que você os ignore explicitamente.

O exemplo a seguir renderiza cada slide como uma imagem JPEG com fatores de escala horizontal e vertical iguais a 2:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const scaleX = 2;
const scaleY = scaleX;

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const slideCount = presentation.getSlides().size();
    for (let index = 0; index < slideCount; index++) {
        const slide = presentation.getSlides().get_Item(index);
        const image = slide.getImage(scaleX, scaleY);
        try {
            image.save("Slide_" + index + ".jpg", aspose.slides.ImageFormat.Jpeg);
        } finally {
            image.dispose();
        }
    }
} finally {
    presentation.dispose();
}
```

## **Criar Saída Enhanced Metafile**

Enhanced Metafile (EMF) é útil quando gráficos baseados em vetor precisam ser trocados com o Microsoft Office ou outros aplicativos Windows que suportam metarquivos do Windows. Ao contrário de uma imagem baseada em pixels, um EMF pode reter operações de desenho vetorial que escalam sem a mesma perda de nitidez. No entanto, EMF é principalmente um formato de compatibilidade para aplicativos com suporte a metarquivos do Windows, não um formato de intercâmbio universal. Além disso, conteúdo complexo de slides, como imagens bitmap e alguns efeitos, pode ser armazenado como elementos rasterizados dentro do contêiner vetorial do metarquivo.

### **Exportar um Slide para EMF**

O método [Slide.writeAsEmf](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/slide/#writeAsEmf) grava um slide em um fluxo de destino no formato EMF. O exemplo a seguir carrega uma apresentação, seleciona o primeiro slide e o grava em um fluxo de arquivo EMF:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const emfStream = java.newInstanceSync("java.io.FileOutputStream", "Slide_0.emf");
    try {
        slide.writeAsEmf(emfStream);
    } finally {
        emfStream.close();
    }
} finally {
    presentation.dispose();
}
```

O chamador possui o fluxo passado para [Slide.writeAsEmf](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/slide/#writeAsEmf) e é responsável por fechá‑lo, como demonstrado acima.

### **Converter uma Imagem SVG em EMF e Inserir na Apresentação**

Use [SvgImage.writeAsEmf](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/svgimage/#writeAsEmf) para converter conteúdo SVG em EMF. Os bytes resultantes podem ser adicionados à apresentação através de [ImageCollection.addImage](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/imagecollection/#addImage) e colocados em um slide com [ShapeCollection.addPictureFrame](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/shapecollection/#addPictureFrame).

O exemplo a seguir cria um [SvgImage](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/svgimage/) a partir de marcação SVG, converte‑o em um EMF em memória, insere o metarquivo no primeiro slide e salva a apresentação:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const svgContent = "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"200\" height=\"100\"><rect width=\"200\" height=\"100\" fill=\"#4472C4\"/></svg>";
const svgImage = new aspose.slides.SvgImage(svgContent);

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const emfStream = java.newInstanceSync("java.io.ByteArrayOutputStream");
    try {
        svgImage.writeAsEmf(emfStream);

        const emfData = java.newArray("byte", Array.from(emfStream.toByteArray()));
        const image = presentation.getImages().addImage(emfData);
        slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 20, 20, 200, 100, image);
    } finally {
        emfStream.close();
    }

    presentation.save("Presentation_with_emf.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

[SvgImage.writeAsEmf](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/svgimage/#writeAsEmf) não assume a propriedade do fluxo de destino. Um `java.io.ByteArrayOutputStream` armazena todos os dados gerados na memória, portanto não é necessário redefinir a posição antes de chamar `toByteArray`. O array de bytes retornado permanece válido após o fluxo ser fechado.

A geração de EMF está disponível nos sistemas operacionais suportados pela configuração selecionada do Aspose.Slides for Node.js via Java e JDK, mas a renderização pode variar entre plataformas quando fontes ou dependências gráficas não estão disponíveis. Instale as fontes usadas pelo conteúdo de origem ou configure substituições adequadas, siga os [requisitos de plataforma](/slides/pt/nodejs-java/system-requirements/) para Aspose.Slides for Node.js via Java e valide o resultado no aplicativo de destino que consome EMF. Aplicativos Linux e macOS frequentemente têm suporte limitado ou inconsistente para exibição e edição de metarquivos do Windows.

## **Renderização de Emoji Colorido**

{{% alert title="Note" color="info" %}}
Para renderizar emojis coloridos corretamente ao converter slides de apresentação em imagens, as fontes de emoji usadas na apresentação devem estar instaladas e disponíveis no sistema que realiza a conversão. Por exemplo, se a apresentação usa **Segoe UI Emoji** e essa fonte está ausente, os emojis podem aparecer em monocromático nas imagens de saída.
{{% /alert %}}

## **Perguntas Frequentes**

**O Aspose.Slides suporta renderizar slides com animações?**

Não. O método [Slide.getImage](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/slide/#getImage) renderiza uma imagem estática do slide e não exporta animações.

**Slides ocultos podem ser exportados como imagens?**

Sim. Slides ocultos podem ser renderizados como slides normais. Inclua‑os no loop de processamento, conforme o exemplo acima.

**Sombras e outros efeitos são preservados nas imagens dos slides?**

Sim. Aspose.Slides renderiza sombras, transparência e outros efeitos gráficos suportados nas imagens dos slides.