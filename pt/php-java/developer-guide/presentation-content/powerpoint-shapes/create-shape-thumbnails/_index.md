---
title: Criar miniaturas de formas de apresentação em PHP
linktitle: Miniaturas de Forma
type: docs
weight: 70
url: /pt/php-java/create-shape-thumbnails/
keywords:
- miniatura de forma
- imagem de forma
- renderizar forma
- renderização de forma
- PowerPoint
- apresentação
- PHP
- Aspose.Slides
description: "Gere miniaturas de forma de alta qualidade a partir de slides PowerPoint com Aspose.Slides for PHP via Java – crie e exporte miniaturas de apresentação com facilidade."
---
## **Introdução**

Aspose.Slides é usado para criar arquivos de apresentação onde cada página é um slide. Esses slides podem ser visualizados abrindo os arquivos de apresentação usando o Microsoft PowerPoint. Mas às vezes, os desenvolvedores podem precisar visualizar as imagens das formas separadamente em um visualizador de imagens. Nesses casos, o Aspose.Slides ajuda a gerar imagens em miniatura das formas do slide. Como usar esse recurso é descrito neste artigo.  
Este artigo explica como gerar miniaturas de slide de diferentes maneiras:

- Gerando uma miniatura de forma dentro de um slide.  
- Gerando uma miniatura de forma para uma forma de slide com dimensões definidas pelo usuário.  
- Gerando uma miniatura de forma nos limites da aparência de uma forma.

## **Gerar uma Miniatura de Forma a partir de um Slide**
Para gerar uma miniatura de forma a partir de qualquer slide usando Aspose.Slides for PHP via Java, faça o seguinte:

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/php-java/aspose.slides/presentation).  
1. Obtenha a referência de qualquer slide usando seu ID ou índice.  
1. Obtenha a [imagem miniatura da forma](https://reference.aspose.com/slides/pt/php-java/aspose.slides/shape/#getImage) do slide referenciado na escala padrão.  
1. Salve a imagem miniatura no formato de imagem de sua preferência.

```php
  # Instanciar uma classe Presentation que representa o arquivo de apresentação
  $pres = new Presentation("Thumbnail.pptx");
  try {
    # Criar uma imagem em escala completa
    $slideImage = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0)->getImage();
    # Salvar a imagem no disco no formato PNG
    try {
      $slideImage->save("output.png", ImageFormat::Png);
    } finally {
      if (!java_is_null($slideImage)) {
        $slideImage->dispose();
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Gerar uma Miniatura com Fator de Escala Definido pelo Usuário**
Para gerar a miniatura de forma de um slide usando Aspose.Slides for PHP via Java, faça o seguinte:

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/php-java/aspose.slides/presentation).  
1. Obtenha a referência de qualquer slide usando seu ID ou índice.  
1. Obtenha a [imagem miniatura da forma](https://reference.aspose.com/slides/pt/php-java/aspose.slides/shape/#getImage) do slide referenciado com dimensões definidas pelo usuário.  
1. Salve a imagem miniatura no formato de imagem de sua preferência.

```php
  # Instanciar uma classe Presentation que representa o arquivo de apresentação
  $pres = new Presentation("Thumbnail.pptx");
  try {
    # Criar uma imagem em escala completa
    $slideImage = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0)->getImage(ShapeThumbnailBounds->Shape, 1, 1);
    # Salvar a imagem no disco no formato PNG
    try {
      $slideImage->save("output.png", ImageFormat::Png);
    } finally {
      if (!java_is_null($slideImage)) {
        $slideImage->dispose();
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Criar uma Miniatura de Aparência de Forma Baseada em Limites**
Este método de criação de miniaturas de formas permite que os desenvolvedores gerem uma miniatura dentro dos limites da aparência da forma. Ele leva em conta todos os efeitos da forma. A miniatura gerada é restrita pelos limites do slide. Para gerar uma miniatura de uma forma de slide nos limites de sua aparência, faça o seguinte:

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/php-java/aspose.slides/presentation).  
1. Obtenha a referência de qualquer slide usando seu ID ou índice.  
1. Obtenha a imagem miniatura do slide referenciado usando os limites da forma como aparência.  
1. Salve a imagem miniatura no formato de imagem de sua preferência.

```php
  # Instanciar uma classe Presentation que representa o arquivo de apresentação
  $pres = new Presentation("Thumbnail.pptx");
  try {
    # Criar uma imagem em escala completa
    $slideImage = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0)->getImage(ShapeThumbnailBounds->Appearance, 1, 1);
    # Salvar a imagem no disco no formato PNG
    try {
      $slideImage->save("output.png", ImageFormat::Png);
    } finally {
      if (!java_is_null($slideImage)) {
        $slideImage->dispose();
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **FAQ**

**Quais formatos de imagem podem ser usados ao salvar miniaturas de forma?**

[PNG, JPEG, BMP, GIF, TIFF](https://reference.aspose.com/slides/pt/php-java/aspose.slides/imageformat/), entre outros. As formas também podem ser [exportadas como SVG vetorial](https://reference.aspose.com/slides/pt/php-java/aspose.slides/shape/writeassvg/) salvando o conteúdo da forma como SVG.

**Qual é a diferença entre limites de Shape e Appearance ao renderizar uma miniatura?**

`Shape` usa a geometria da forma; `Appearance` leva em conta os [efeitos visuais](/slides/pt/php-java/shape-effect/) (sombras, brilhos, etc.).

**O que acontece se uma forma for marcada como oculta? Ela ainda será renderizada como miniatura?**

Uma forma oculta permanece parte do modelo e pode ser renderizada; o sinalizador de ocultação afeta a exibição da apresentação, mas não impede a geração da imagem da forma.

**Formas de grupo, gráficos, SmartArt e outros objetos complexos são suportados?**

Sim. Qualquer objeto representado como [Shape](https://reference.aspose.com/slides/pt/php-java/aspose.slides/shape/) (incluindo [GroupShape](https://reference.aspose.com/slides/pt/php-java/aspose.slides/groupshape/), [Chart](https://reference.aspose.com/slides/pt/php-java/aspose.slides/chart/) e [SmartArt](https://reference.aspose.com/slides/pt/php-java/aspose.slides/smartart/)) pode ser salvo como miniatura ou como SVG.

**Fontes instaladas no sistema afetam a qualidade das miniaturas de formas de texto?**

Sim. Você deve [fornecer as fontes necessárias](/slides/pt/php-java/custom-font/) (ou [configurar substituições de fontes](/slides/pt/php-java/font-substitution/)) para evitar substituições indesejadas e refluxo de texto.