---
title: Criar Miniaturas de Formas de Apresentação no Android
linktitle: Miniaturas de Formas
type: docs
weight: 70
url: /pt/androidjava/create-shape-thumbnails/
keywords:
- miniatura de forma
- imagem de forma
- renderizar forma
- renderização de forma
- limites visuais
- limites da forma
- PowerPoint
- apresentação
- Android
- Java
- Aspose.Slides
description: "Gere miniaturas de forma de alta qualidade a partir de slides do PowerPoint com Aspose.Slides para Android via Java – crie e exporte miniaturas de apresentações com facilidade."
---
## **Introdução**

Aspose.Slides for Android via Java pode ser usado para criar arquivos de apresentação nos quais cada página corresponde a um slide. Os slides podem ser visualizados abrindo os arquivos de apresentação usando o Microsoft PowerPoint. No entanto, os desenvolvedores às vezes precisam visualizar as imagens das formas separadamente em um visualizador de imagens. Nesses casos, o Aspose.Slides for Android via Java ajuda a gerar imagens em miniatura das formas dos slides.

Neste tópico, mostraremos como gerar miniaturas de slides em diferentes situações:

- Gerar uma miniatura de forma dentro de um slide.
- Gerar uma miniatura de forma para uma forma de slide com dimensões definidas pelo usuário.
- Gerar uma miniatura de forma nos limites da aparência de uma forma.

## **Gerar uma Miniatura de Forma a partir de um Slide**
Para gerar uma miniatura de forma a partir de qualquer slide usando Aspose.Slides for Android via Java, faça o seguinte:

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/presentation).
1. Obtenha a referência de qualquer slide usando seu ID ou índice.
1. [Obter a imagem em miniatura da forma](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/IShape#getImage--) do slide referenciado na escala padrão.
1. Salve a imagem em miniatura no formato de imagem de sua preferência.

Este exemplo de código mostra como gerar uma miniatura de forma a partir de um slide:

```java
// Instanciar uma classe Presentation que representa o arquivo de apresentação
Presentation pres = new Presentation("Thumbnail.pptx");
try {
    // Criar uma imagem em escala total
    IImage slideImage = pres.getSlides().get_Item(0).getShapes().get_Item(0).getImage();
    
    // Salvar a imagem no disco no formato PNG
    try {
          slideImage.save("output.png", ImageFormat.Png);
    } finally {
         if (slideImage != null) slideImage.dispose();
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **Gerar uma Miniatura com Fator de Escala Definido pelo Usuário**
Para gerar a miniatura da forma de um slide usando Aspose.Slides for Android via Java, faça o seguinte:

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/presentation).
1. Obtenha a referência de qualquer slide usando seu ID.
1. [Obter a imagem em miniatura da forma](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/IShape#getImage-int-float-float-) do slide referenciado com dimensões definidas pelo usuário.
1. Salve a imagem em miniatura no formato de imagem de sua preferência.

Este exemplo de código mostra como gerar uma miniatura de forma com base em um fator de escala definido:

```java
// Instanciar uma classe Presentation que representa o arquivo de apresentação
Presentation pres = new Presentation("Thumbnail.pptx");
try {
    // Criar uma imagem em escala total
    IImage slideImage = pres.getSlides().get_Item(0).getShapes().get_Item(0).getImage(ShapeThumbnailBounds.Shape, 1, 1);

    // Salvar a imagem no disco no formato PNG
    try {
          slideImage.save("output.png", ImageFormat.Png);
    } finally {
         if (slideImage != null) slideImage.dispose();
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **Criar uma Miniatura de Aparência de Forma Baseada em Limites**
Este método de criação de miniaturas de formas permite que os desenvolvedores gerem uma miniatura nos limites da aparência da forma. Ele leva em conta todos os efeitos da forma. A miniatura gerada é restringida pelos limites do slide. Para gerar uma miniatura de uma forma de slide dentro dos limites de sua aparência, faça o seguinte:

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/presentation).
1. Obtenha a referência de qualquer slide usando seu ID.
1. Obtenha a imagem em miniatura do slide referenciado usando os limites da forma como aparência.
1. Salve a imagem em miniatura no formato de imagem de sua preferência.

Este exemplo de código baseia‑se nas etapas acima:

```java
// Instanciar uma classe Presentation que representa o arquivo de apresentação
Presentation pres = new Presentation("Thumbnail.pptx");
try {
    // Criar uma imagem em escala total
    IImage slideImage = pres.getSlides().get_Item(0).getShapes().get_Item(0).getImage(ShapeThumbnailBounds.Appearance, 1, 1);

    // Salvar a imagem no disco no formato PNG
    try {
          slideImage.save("output.png", ImageFormat.Png);
    } finally {
         if (slideImage != null) slideImage.dispose();
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **Obter os Limites Visuais Reais de uma Forma**

As propriedades de quadro de [IShape](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/ishape/)—seus métodos `getX()`, `getY()`, `getWidth()` e `getHeight()`—descrevem o retângulo armazenado no modelo da apresentação. O conteúdo realmente renderizado pode se estender além desse quadro ou ocupar um retângulo alinhado a eixos diferente. Rotação, contornos, pontas de setas, layout e transbordamento de texto, geometria de SmartArt gerada e outros efeitos de renderização podem alterar a área ocupada.

Use [Shape.getVisualBounds](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/shape/#getVisualBounds--) para calcular essa área ocupada sem criar uma imagem. O método devolve um [RectF](https://developer.android.com/reference/android/graphics/RectF) em coordenadas do slide. O retângulo devolvido não é recortado ao slide, portanto suas coordenadas podem ser negativas quando o conteúdo se estende além da origem do slide.

[Shape.getVisualBounds](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/shape/#getVisualBounds--) não está atualmente declarado pela interface [IShape](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/ishape/). Portanto, mantenha a forma obtida da coleção de formas do slide como um valor de interface e faça o cast apenas ao chamar o método.

O exemplo a seguir obtém e compara os limites de quadro e os limites visuais:

```java
Presentation presentation = new Presentation("example.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IShape shape = slide.getShapes().get_Item(0);

    RectF visualBounds = ((Shape) shape).getVisualBounds();

    float frameLeft = shape.getX();
    float frameTop = shape.getY();
    float frameRight = frameLeft + shape.getWidth();
    float frameBottom = frameTop + shape.getHeight();
    RectF frameBounds = new RectF(frameLeft, frameTop, frameRight, frameBottom);

    System.out.println("Frame bounds: " + frameBounds);
    System.out.println("Visual bounds: " + visualBounds);
} finally {
    presentation.dispose();
}
```

O mesmo [RectF](https://developer.android.com/reference/android/graphics/RectF) pode ser usado para alinhar formas próximas à sua borda esquerda, direita, superior ou inferior; reservar espaço suficiente em um layout gerado; ou detectar conteúdo fora de uma região permitida. Os limites visuais são especialmente úteis para SmartArt, caixas de texto, setas, imagens, formas rotacionadas e formas agrupadas, onde o quadro armazenado pode não representar o resultado renderizado completo.

Use [Shape.getVisualBounds](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/shape/#getVisualBounds--) quando precisar de coordenadas para layout ou validação e não precisar de um bitmap. Use [IShape.getImage](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/ishape/#getImage--) quando precisar renderizar a forma. Com [ShapeThumbnailBounds](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/shapethumbnailbounds/), `ShapeThumbnailBounds.Shape` dimensiona a imagem a partir dos limites da forma, incluindo configurações de contorno, enquanto `ShapeThumbnailBounds.Appearance` a dimensiona a partir da aparência da forma e restringe o resultado aos limites do slide. Em contraste, [Shape.getVisualBounds](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/shape/#getVisualBounds--) devolve apenas o retângulo calculado e não o recorta ao slide.

## **Perguntas Frequentes**

**Quais formatos de imagem podem ser usados ao salvar miniaturas de formas?**

[PNG, JPEG, BMP, GIF, TIFF](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/imageformat/), e outros. As formas também podem ser [exportadas como SVG vetorial](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/shape/#writeAsSvg-java.io.OutputStream-com.aspose.slides.ISVGOptions-) salvando o conteúdo da forma como SVG.

**Qual é a diferença entre os limites Shape e Appearance ao renderizar uma miniatura?**

`Shape` usa a geometria da forma; `Appearance` leva em conta os efeitos visuais (sombras, brilhos, etc.).

**O que acontece se uma forma for marcada como oculta? Ela ainda será renderizada como miniatura?**

Uma forma oculta permanece parte do modelo e pode ser renderizada; a flag oculta afeta a exibição da apresentação, mas não impede a geração da imagem da forma.

**Grupos de formas, gráficos, SmartArt e outros objetos complexos são suportados?**

Sim. Qualquer objeto representado como [Shape](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/shape/) (incluindo [GroupShape](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/groupshape/), [Chart](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/chart/), e [SmartArt](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/smartart/)) pode ser salvo como miniatura ou como SVG.

**As fontes instaladas no sistema afetam a qualidade das miniaturas para formas de texto?**

Sim. Você deve [fornecer as fontes necessárias](/slides/pt/androidjava/custom-font/) (ou [configurar substituições de fontes](/slides/pt/androidjava/font-substitution/)) para evitar substituições indesejadas e reformatação de texto.