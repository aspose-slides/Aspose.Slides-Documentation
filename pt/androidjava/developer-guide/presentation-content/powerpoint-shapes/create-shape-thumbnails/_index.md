---
title: Criar Miniaturas de Formas de Apresentação no Android
linktitle: Miniaturas de Formas
type: docs
weight: 70
url: /pt/androidjava/create-shape-thumbnails/
keywords:
- miniatura de forma
- imagem da forma
- renderizar forma
- renderização de forma
- PowerPoint
- apresentação
- Android
- Java
- Aspose.Slides
description: "Gere miniaturas de forma de alta qualidade a partir de slides do PowerPoint com Aspose.Slides para Android via Java – crie e exporte facilmente miniaturas de apresentações."
---
## **Introdução**

Aspose.Slides for Android via Java pode ser usado para criar arquivos de apresentação nos quais cada página corresponde a um slide. Os slides podem ser visualizados abrindo os arquivos de apresentação usando o Microsoft PowerPoint. Entretanto, os desenvolvedores às vezes precisam visualizar as imagens das formas separadamente em um visualizador de imagens. Nesses casos, o Aspose.Slides for Android via Java ajuda a gerar miniaturas das formas dos slides.

Neste tópico, mostraremos como gerar miniaturas de slides em diferentes situações:

- Gerar uma miniatura de forma dentro de um slide.
- Gerar uma miniatura de forma para uma forma de slide com dimensões definidas pelo usuário.
- Gerar uma miniatura de forma nos limites da aparência de uma forma.

## **Gerar uma Miniatura de Forma a partir de um Slide**
Para gerar uma miniatura de forma a partir de qualquer slide usando Aspose.Slides for Android via Java, faça o seguinte:

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/presentation).
1. Obtenha a referência de qualquer slide usando seu ID ou índice.
1. [Obtenha a imagem da miniatura da forma](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/IShape#getImage--) do slide referenciado na escala padrão.
1. Salve a imagem da miniatura no formato de imagem de sua preferência.

Este código de exemplo mostra como gerar uma miniatura de forma a partir de um slide:

```java
// Instanciar a classe Presentation que representa o arquivo de apresentação
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
1. Obtenha a referência de qualquer slide usando seu ID ou índice.
1. [Obtenha a imagem da miniatura da forma](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/IShape#getImage-int-float-float-) do slide referenciado com dimensões definidas pelo usuário.
1. Salve a imagem da miniatura no formato de imagem de sua preferência.

Este código de exemplo mostra como gerar uma miniatura de forma baseada em um fator de escala definido:

```java
// Instanciar a classe Presentation que representa o arquivo de apresentação
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

## **Criar uma Miniatura da Aparência da Forma Baseada em Limites**
Este método de criação de miniaturas de formas permite que os desenvolvedores gerem uma miniatura dentro dos limites da aparência da forma. Ele leva em conta todos os efeitos da forma. A miniatura gerada é restrita pelos limites do slide. Para gerar uma miniatura de uma forma de slide dentro dos limites de sua aparência, faça o seguinte:

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/presentation).
1. Obtenha a referência de qualquer slide usando seu ID ou índice.
1. Obtenha a imagem da miniatura do slide referenciado com os limites da forma como aparência.
1. Salve a imagem da miniatura no formato de imagem de sua preferência.

Este código de exemplo baseia‑se nas etapas acima:

```java
// Instanciar a classe Presentation que representa o arquivo de apresentação
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

## **Perguntas Frequentes**

**Quais formatos de imagem podem ser usados ao salvar miniaturas de formas?**

[PNG, JPEG, BMP, GIF, TIFF](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/imageformat/), e outros. As formas também podem ser [exportadas como SVG vetorial](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/shape/#writeAsSvg-java.io.OutputStream-com.aspose.slides.ISVGOptions-) salvando o conteúdo da forma como SVG.

**Qual a diferença entre limites de Forma e de Aparência ao renderizar uma miniatura?**

`Shape` usa a geometria da forma; `Appearance` leva em conta os [efeitos visuais](/slides/pt/androidjava/shape-effect/) (sombras, brilhos etc.).

**O que acontece se uma forma estiver marcada como oculta? Ela ainda será renderizada como miniatura?**

Uma forma oculta continua parte do modelo e pode ser renderizada; a flag de ocultação afeta a exibição na apresentação, mas não impede a geração da imagem da forma.

**Formas de grupo, gráficos, SmartArt e outros objetos complexos são suportados?**

Sim. Qualquer objeto representado como [Shape](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/shape/) (incluindo [GroupShape](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/groupshape/), [Chart](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/chart/) e [SmartArt](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/smartart/)) pode ser salvo como miniatura ou como SVG.

**Fontes instaladas no sistema afetam a qualidade das miniaturas de formas de texto?**

Sim. Você deve [fornecer as fontes necessárias](/slides/pt/androidjava/custom-font/) (ou [configurar substituições de fontes](/slides/pt/androidjava/font-substitution/)) para evitar substituições indesejadas e reflow de texto.