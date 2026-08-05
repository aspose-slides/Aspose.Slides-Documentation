---
title: Criar miniaturas de formas de apresentação em JavaScript
linktitle: Miniaturas de forma
type: docs
weight: 70
url: /pt/nodejs-java/create-shape-thumbnails/
keywords:
- miniatura de forma
- imagem de forma
- renderizar forma
- renderização de forma
- limites visuais
- limites da forma
- PowerPoint
- apresentação
- Node.js
- JavaScript
- Aspose.Slides
description: "Gerar miniaturas de forma de alta qualidade a partir de slides do PowerPoint com JavaScript e Aspose.Slides para Node.js – crie e exporte facilmente miniaturas de apresentações."
---
## **Introdução**

Aspose.Slides é usado para criar arquivos de apresentação onde cada página é um slide. Esses slides podem ser visualizados ao abrir os arquivos de apresentação usando o Microsoft PowerPoint. Mas, às vezes, os desenvolvedores podem precisar ver as imagens das formas separadamente em um visualizador de imagens. Nesses casos, Aspose.Slides ajuda a gerar imagens em miniatura das formas dos slides. Como usar esse recurso é descrito neste artigo.
Este artigo explica como gerar miniaturas de slides de diferentes maneiras:

- Gerar uma miniatura de forma dentro de um slide.  
- Gerar uma miniatura de forma para uma forma de slide com dimensões definidas pelo usuário.  
- Gerar uma miniatura de forma nos limites da aparência de uma forma.

## **Gerando Miniaturas de Forma a partir de Slides**
Para gerar uma miniatura de forma a partir de qualquer slide usando Aspose.Slides para Node.js via Java, faça o seguinte:

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/presentation).  
1. Obtenha a referência de qualquer slide usando seu ID ou índice.  
1. [Obter a imagem em miniatura da forma](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/Shape#getImage--) do slide referenciado na escala padrão.  
1. Salve a imagem em miniatura no formato de imagem de sua preferência.

Este código de exemplo mostra como gerar uma miniatura de forma a partir de um slide:

```javascript
// Instanciar uma classe Presentation que representa o arquivo de apresentação
var pres = new aspose.slides.Presentation("Thumbnail.pptx");
try {
    // Criar uma imagem em escala total
    var slideImage = pres.getSlides().get_Item(0).getShapes().get_Item(0).getImage();
    // Salvar a imagem no disco no formato PNG
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

## **Gerando Miniaturas de Forma com Fator de Escala Definido pelo Usuário**
Para gerar a miniatura de forma de um slide usando Aspose.Slides para Node.js via Java, siga estas etapas:

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/presentation).  
1. Obtenha a referência de qualquer slide usando seu ID ou índice.  
1. [Obter a imagem em miniatura da forma](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/Shape#getImage-int-float-float-) do slide referenciado com dimensões definidas pelo usuário.  
1. Salve a imagem em miniatura no formato de imagem de sua preferência.

Este código de exemplo mostra como gerar uma miniatura de forma com base em um fator de escala definido:

```javascript
// Instanciar uma classe Presentation que representa o arquivo de apresentação
var pres = new aspose.slides.Presentation("Thumbnail.pptx");
try {
    // Criar uma imagem em escala total
    var slideImage = pres.getSlides().get_Item(0).getShapes().get_Item(0).getImage(aspose.slides.ShapeThumbnailBounds.Shape, 1, 1);
    // Salvar a imagem no disco no formato PNG
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

## **Gerando Miniatura de Forma nos Limites**
Este método de criação de miniaturas de formas permite que os desenvolvedores gerem uma miniatura dentro dos limites da aparência da forma. Ele leva em conta todos os efeitos da forma. A miniatura gerada é restrita pelos limites do slide. Para gerar uma miniatura de uma forma de slide dentro dos limites de sua aparência, faça o seguinte:

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/presentation).  
1. Obtenha a referência de qualquer slide usando seu ID ou índice.  
1. Obtenha a imagem em miniatura do slide referenciado com os limites da forma como aparência.  
1. Salve a imagem em miniatura no formato de imagem de sua preferência.

Este código de exemplo baseia‑se nas etapas acima:

```javascript
// Instanciar uma classe Presentation que representa o arquivo de apresentação
var pres = new aspose.slides.Presentation("Thumbnail.pptx");
try {
    // Criar uma imagem em escala total
    var slideImage = pres.getSlides().get_Item(0).getShapes().get_Item(0).getImage(aspose.slides.ShapeThumbnailBounds.Appearance, 1, 1);
    // Salvar a imagem no disco no formato PNG
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

## **Obter os Limites Visuais Reais de uma Forma**

As propriedades de quadro de uma [Shape](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/shape/) — seus métodos `getX()`, `getY()`, `getWidth()` e `getHeight()` — descrevem o retângulo armazenado no modelo da apresentação. O conteúdo que realmente é renderizado pode se estender além desse quadro ou ocupar um retângulo alinhado a eixos diferente. Rotação, contornos, cabeças de seta, layout e transbordamento de texto, geometria de SmartArt gerada e outros efeitos de renderização podem alterar a área ocupada.

Use [Shape.getVisualBounds](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/shape/#getVisualBounds--) para calcular essa área ocupada sem criar uma imagem. O método devolve um objeto [Rectangle2D.Float](https://docs.oracle.com/javase/8/docs/api/java/awt/geom/Rectangle2D.Float.html) nas coordenadas do slide. O retângulo retornado não é recortado ao slide, portanto suas coordenadas podem ser negativas quando o conteúdo se estende além da origem do slide.

O exemplo a seguir obtém e compara os limites de quadro e os limites visuais:

```javascript
const presentation = new aspose.slides.Presentation("example.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().get_Item(0);

    const visualBounds = shape.getVisualBounds();

    const frameBounds = {
        x: shape.getX(),
        y: shape.getY(),
        width: shape.getWidth(),
        height: shape.getHeight()
    };
    const visualBoundsValues = {
        x: visualBounds.getX(),
        y: visualBounds.getY(),
        width: visualBounds.getWidth(),
        height: visualBounds.getHeight()
    };

    console.log(
        `Frame bounds (x, y, width, height): ${frameBounds.x}, ${frameBounds.y}, ${frameBounds.width}, ${frameBounds.height}`
    );
    console.log(
        `Visual bounds (x, y, width, height): ${visualBoundsValues.x}, ${visualBoundsValues.y}, ${visualBoundsValues.width}, ${visualBoundsValues.height}`
    );
} finally {
    presentation.dispose();
}
```

O mesmo retângulo pode ser usado para alinhar formas próximas ao seu lado esquerdo, direito, superior ou inferior; reservar espaço suficiente em um layout gerado; ou detectar conteúdo fora de uma região permitida. Os limites visuais são especialmente úteis para SmartArt, caixas de texto, setas, imagens, formas giradas e formas agrupadas, onde o quadro armazenado pode não representar o resultado renderizado completo.

Use [Shape.getVisualBounds](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/shape/#getVisualBounds--) quando precisar de coordenadas para layout ou validação e não precisar de um bitmap. Use [Shape.getImage](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/shape/#getImage--) quando precisar renderizar a forma. Com [ShapeThumbnailBounds](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/shapethumbnailbounds/), `ShapeThumbnailBounds.Shape` dimensiona a imagem a partir dos limites da forma, incluindo configurações de contorno, enquanto `ShapeThumbnailBounds.Appearance` a dimensiona a partir da aparência da forma e restringe o resultado aos limites do slide. Em contraste, [Shape.getVisualBounds](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/shape/#getVisualBounds--) devolve apenas o retângulo calculado e não o recorta ao slide.

## **FAQ**

**Quais formatos de imagem podem ser usados ao salvar miniaturas de forma?**

[PNG, JPEG, BMP, GIF, TIFF](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/imageformat/), e outros. As formas também podem ser [exportadas como SVG vetorial](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/shape/writeassvg/) salvando o conteúdo da forma como SVG.

**Qual a diferença entre os limites de Forma e Aparência ao renderizar uma miniatura?**

`Shape` usa a geometria da forma; `Appearance` leva em conta os [efeitos visuais](/slides/pt/nodejs-java/shape-effect/) (sombras, brilhos, etc.).

**O que acontece se uma forma for marcada como oculta? Ela ainda será renderizada como miniatura?**

Uma forma oculta permanece parte do modelo e pode ser renderizada; o sinalizador de ocultação afeta a exibição da apresentação, mas não impede a geração da imagem da forma.

**Formas agrupadas, gráficos, SmartArt e outros objetos complexos são suportados?**

Sim. Qualquer objeto representado como [Shape](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/shape/) (incluindo [GroupShape](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/groupshape/), [Chart](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/chart/) e [SmartArt](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/smartart/)) pode ser salvo como miniatura ou como SVG.

**Fontes instaladas no sistema afetam a qualidade das miniaturas para formas de texto?**

Sim. Você deve [fornecer as fontes necessárias](/slides/pt/nodejs-java/custom-font/) (ou [configurar substituições de fontes](/slides/pt/nodejs-java/font-substitution/)) para evitar substituições indesejadas e reflow de texto.