---
title: Criar miniaturas de formas de apresentação em JavaScript
linktitle: Miniaturas de Formas
type: docs
weight: 70
url: /pt/nodejs-java/create-shape-thumbnails/
keywords:
- miniatura de forma
- imagem de forma
- renderizar forma
- renderização de forma
- PowerPoint
- apresentação
- Node.js
- JavaScript
- Aspose.Slides
description: "Gere miniaturas de forma de alta qualidade a partir de slides do PowerPoint com JavaScript e Aspose.Slides para Node.js – crie e exporte facilmente miniaturas de apresentações."
---
## **Introdução**

Aspose.Slides é usado para criar arquivos de apresentação onde cada página é um slide. Esses slides podem ser visualizados ao abrir os arquivos de apresentação usando o Microsoft PowerPoint. Mas, às vezes, os desenvolvedores podem precisar ver as imagens das formas separadamente em um visualizador de imagens. Nesses casos, o Aspose.Slides ajuda a gerar imagens miniatura das formas do slide. Como usar esse recurso é descrito neste artigo.  
Este artigo explica como gerar miniaturas de slide de diferentes maneiras:

- Gerando uma miniatura de forma dentro de um slide.  
- Gerando uma miniatura de forma para uma forma de slide com dimensões definidas pelo usuário.  
- Gerando uma miniatura de forma nos limites da aparência de uma forma.

## **Gerando miniaturas de forma a partir de slides**
Para gerar uma miniatura de forma de qualquer slide usando Aspose.Slides para Node.js via Java, faça o seguinte:

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/presentation).
1. Obtenha a referência de qualquer slide usando seu ID ou índice.
1. [Obtenha a imagem miniatura da forma](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/Shape#getImage--) do slide referenciado na escala padrão.
1. Salve a imagem miniatura no formato de imagem de sua preferência.

Este código de exemplo mostra como gerar uma miniatura de forma a partir de um slide:

```javascript
// Instanciar uma classe Presentation que representa o arquivo de apresentação
var pres = new aspose.slides.Presentation("Thumbnail.pptx");
try {
    // Criar uma imagem em escala total
    var slideImage = pres.getSlides().get_Item(0).getShapes().get_Item(0).getImage();
    // Salvar a imagem no disco em formato PNG
    try {
        slideImage.save("output.png", aspose.slides.ImageFormat.Png);
    } finally {
        if (slideImage != null) {
            slideImage.dispose();
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Gerando miniaturas de forma com fator de escala definido pelo usuário**
Para gerar a miniatura de forma de um slide usando Aspose.Slides para Node.js via Java, faça o seguinte:

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/presentation).
1. Obtenha a referência de qualquer slide usando seu ID ou índice.
1. [Obtenha a imagem miniatura da forma](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/Shape#getImage-int-float-float-) do slide referenciado com dimensões definidas pelo usuário.
1. Salve a imagem miniatura no formato de imagem de sua preferência.

Este código de exemplo mostra como gerar uma miniatura de forma com base em um fator de escala definido:

```javascript
// Instanciar uma classe Presentation que representa o arquivo de apresentação
var pres = new aspose.slides.Presentation("Thumbnail.pptx");
try {
    // Criar uma imagem em escala total
    var slideImage = pres.getSlides().get_Item(0).getShapes().get_Item(0).getImage(aspose.slides.ShapeThumbnailBounds.Shape, 1, 1);
    // Salvar a imagem no disco em formato PNG
    try {
        slideImage.save("output.png", aspose.slides.ImageFormat.Png);
    } finally {
        if (slideImage != null) {
            slideImage.dispose();
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Gerando miniatura de forma nos limites**
Este método de criação de miniaturas de formas permite que os desenvolvedores gerem uma miniatura nos limites da aparência da forma. Ele leva em conta todos os efeitos da forma. A miniatura gerada é restringida pelos limites do slide. Para gerar uma miniatura de uma forma de slide dentro dos limites de sua aparência, faça o seguinte:

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/presentation).
1. Obtenha a referência de qualquer slide usando seu ID ou índice.
1. Obtenha a imagem miniatura do slide referenciado com os limites da forma como aparência.
1. Salve a imagem miniatura no formato de imagem de sua preferência.

Este código de exemplo baseia‑se nos passos acima:

```javascript
// Instanciar uma classe Presentation que representa o arquivo de apresentação
var pres = new aspose.slides.Presentation("Thumbnail.pptx");
try {
    // Criar uma imagem em escala total
    var slideImage = pres.getSlides().get_Item(0).getShapes().get_Item(0).getImage(aspose.slides.ShapeThumbnailBounds.Appearance, 1, 1);
    // Salvar a imagem no disco em formato PNG
    try {
        slideImage.save("output.png", aspose.slides.ImageFormat.Png);
    } finally {
        if (slideImage != null) {
            slideImage.dispose();
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Perguntas Frequentes**

**Quais formatos de imagem podem ser usados ao salvar miniaturas de forma?**

[PNG, JPEG, BMP, GIF, TIFF](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/imageformat/), e outros. As formas também podem ser [exportadas como SVG vetorial](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/shape/writeassvg/) salvando o conteúdo da forma como SVG.

**Qual é a diferença entre os limites Shape e Appearance ao renderizar uma miniatura?**

`Shape` usa a geometria da forma; `Appearance` leva em conta os [efeitos visuais](/slides/pt/nodejs-java/shape-effect/) (sombras, brilhos, etc.).

**O que acontece se uma forma estiver marcada como oculta? Ela ainda será renderizada como miniatura?**

Uma forma oculta continua fazendo parte do modelo e pode ser renderizada; a flag oculta afeta a exibição da apresentação, mas não impede a geração da imagem da forma.

**Formas agrupadas, gráficos, SmartArt e outros objetos complexos são suportados?**

Sim. Qualquer objeto representado como [Shape](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/shape/) (incluindo [GroupShape](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/groupshape/), [Chart](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/chart/), e [SmartArt](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/smartart/)) pode ser salvo como miniatura ou como SVG.

**Fontes instaladas no sistema afetam a qualidade das miniaturas de formas de texto?**

Sim. Você deve [fornecer as fontes necessárias](/slides/pt/nodejs-java/custom-font/) (ou [configurar substituições de fontes](/slides/pt/nodejs-java/font-substitution/)) para evitar substituições indesejadas e reflow de texto.