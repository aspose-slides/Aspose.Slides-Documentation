---
title: Converter slides de apresentação em imagens no Node.js via .NET
linktitle: Slide para Imagem
type: docs
weight: 40
url: /pt/nodejs-net/convert-slide/
keywords:
- converter slide
- slide para imagem
- slide para PNG
- salvar slide como imagem
- renderizar slide
- miniatura de slide
- PowerPoint
- OpenDocument
- apresentação
- Node.js
- JavaScript
- Aspose.Slides
description: "Renderize slides de apresentações PPTX, PPT e ODP como imagens PNG em JavaScript com Aspose.Slides para Node.js via .NET, usando um fator de escala ou um tamanho exato em pixels."
---
## **Visão geral**

Aspose.Slides for Node.js via .NET renderiza slides de apresentações PowerPoint e OpenDocument como imagens, por exemplo para exibir pré‑visualizações de slides em uma página web. Este artigo mostra duas maneiras de escolher o tamanho da imagem: um fator de escala relativo ao tamanho do slide e um tamanho exato em pixels. Ambos os exemplos salvam arquivos PNG.

Os exemplos esperam uma apresentação chamada `sample.pptx` na pasta do projeto que você configurou em [Installation](/slides/pt/nodejs-net/installation/). Qualquer apresentação PowerPoint serve. Salve cada exemplo como um arquivo `.js` na pasta do projeto e execute‑o a partir dessa pasta com `node`.

{{% alert color="info" title="Note" %}}
Aspose.Slides for Node.js via .NET não possui sua própria referência de API. Ele espelha a API do Aspose.Slides para .NET com nomes em camelCase, portanto os links de API neste artigo levam às classes e membros correspondentes na [Aspose.Slides for .NET API reference](https://reference.aspose.com/slides/net/).
{{% /alert %}}

Para converter um slide em uma imagem, siga estas etapas:

1. Abra a apresentação com o construtor [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/presentation/).
1. Obtenha um slide da coleção [slides](https://reference.aspose.com/slides/net/aspose.slides/presentation/slides/) com `get(index)`. Os índices começam em 0.
1. Renderize o slide com `getImageWithScale` ou `getImageWithImageSize`. Na referência da API .NET, ambos são sobrecargas de [Slide.GetImage](https://reference.aspose.com/slides/net/aspose.slides/slide/getimage/). Eles retornam um objeto de imagem que corresponde a [IImage](https://reference.aspose.com/slides/net/aspose.slides/iimage/).
1. Salve a imagem com seu método [save](https://reference.aspose.com/slides/net/aspose.slides/iimage/save/) e um valor [ImageFormat](https://reference.aspose.com/slides/net/aspose.slides/imageformat/), e então chame seu método `dispose`.

## **Converter Cada Slide em uma Imagem PNG**

`getImageWithScale` recebe um fator de escala horizontal e vertical. Em uma escala de 1, um ponto do slide se torna um pixel da imagem. O exemplo a seguir renderiza cada slide em uma escala de 2:

```javascript
const { Presentation, ImageFormat } = require("aspose.slides.via.net");

// Uma escala de 1 renderiza um pixel por ponto; 2 dobra a largura e a altura.
const scaleX = 2;
const scaleY = scaleX;

const presentation = new Presentation("sample.pptx");
try {
    const slideCount = presentation.slides.count;
    for (let index = 0; index < slideCount; index++) {
        const slide = presentation.slides.get(index);
        const image = slide.getImageWithScale(scaleX, scaleY);
        try {
            image.save(`slide_${index + 1}.png`, ImageFormat.Png);
        } finally {
            image.dispose();
        }
    }
    console.log(`Saved ${slideCount} images`);
} finally {
    presentation.dispose();
}
```

O script grava um arquivo por slide, `slide_1.png`, `slide_2.png` e assim por diante, numerados a partir de 1. Para uma apresentação 16:9 com slides de 960 × 540 pontos, cada imagem tem 1920 × 1080 pixels. Slides ocultos também são renderizados; para ignorá‑los, verifique a propriedade [hidden](https://reference.aspose.com/slides/net/aspose.slides/slide/hidden/) do slide. Cada imagem é descartada em seu próprio bloco `finally`, que a libera antes que o próximo slide seja renderizado. Sem licença, as imagens também exibem uma marca d'água de avaliação; veja [Licensing](/slides/pt/nodejs-net/licensing/).

## **Converter um Slide em uma Imagem com um Tamanho Específico**

`getImageWithImageSize` recebe um objeto com `width` e `height` em pixels. O exemplo a seguir renderiza o primeiro slide com 1280 pixels de largura e calcula a altura a partir do tamanho do slide, de modo que a imagem mantém a proporção do slide:

```javascript
const { Presentation, ImageFormat } = require("aspose.slides.via.net");

const imageWidth = 1280;

const presentation = new Presentation("sample.pptx");
try {
    const slideSize = presentation.slideSize.size;
    const imageHeight = Math.round(imageWidth * slideSize.height / slideSize.width);

    const slide = presentation.slides.get(0);
    const image = slide.getImageWithImageSize({ width: imageWidth, height: imageHeight });
    try {
        image.save("slide_1_1280px.png", ImageFormat.Png);
    } finally {
        image.dispose();
    }
    console.log(`Saved a ${imageWidth} x ${imageHeight} image`);
} finally {
    presentation.dispose();
}
```

A propriedade [slideSize.size](https://reference.aspose.com/slides/net/aspose.slides/slidesize/size/) retorna a largura e a altura do slide em pontos. Para uma apresentação 16:9, o script exibe `Saved a 1280 x 720 image` e grava `slide_1_1280px.png`; para uma apresentação 4:3, a imagem tem 1280 × 960 pixels.

## **FAQ**

**Por que a imagem de `getImage` sem argumentos é tão pequena?**

Sem argumentos, `getImage` renderiza o slide em 20% do seu tamanho em pontos, de modo que um slide de 960 × 540 pontos se torna uma imagem de 192 × 108 pixels. Use `getImageWithScale` ou `getImageWithImageSize` para escolher o tamanho.

**Como salvo JPEG ou outros formatos de imagem?**

Passe outro valor `ImageFormat` para o método `save` da imagem, por exemplo `image.save("slide_1.jpg", ImageFormat.Jpeg)`. O formato vem do valor `ImageFormat`, não da extensão do arquivo, portanto mantenha os dois consistentes.

**Por que o texto nas imagens parece diferente no Linux?**

Aspose.Slides só pode usar fontes que estejam instaladas na máquina que renderiza os slides. Quando uma apresentação utiliza uma fonte que está ausente, como a Calibri em um servidor Linux típico, o Aspose.Slides usa uma fonte instalada em seu lugar, o que pode alterar a aparência do texto e a quebra de linhas. Instale as fontes que suas apresentações utilizam para obter as mesmas imagens que no Windows.

**Por que `getThumbnailWithImageSize` falha com um TypeError?**

O README do pacote usa `getThumbnailWithImageSize`, mas o pacote não possui métodos `getThumbnail`. Use `getImageWithImageSize` em vez disso; ele aceita o mesmo argumento `{ width, height }`.