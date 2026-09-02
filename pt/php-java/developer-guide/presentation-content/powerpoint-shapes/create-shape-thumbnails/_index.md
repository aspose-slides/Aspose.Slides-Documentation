---
title: Criar miniaturas de formas de apresentação em PHP
linktitle: Miniaturas de Formas
type: docs
weight: 70
url: /pt/php-java/create-shape-thumbnails/
keywords:
- miniatura de forma
- imagem de forma
- renderizar forma
- renderização de forma
- limites visuais
- limites da forma
- PowerPoint
- apresentação
- PHP
- Aspose.Slides
description: "Gere miniaturas de forma de alta qualidade a partir de slides PowerPoint com Aspose.Slides para PHP via Java – crie e exporte facilmente miniaturas de apresentações."
---
## **Introdução**

Aspose.Slides é usado para criar arquivos de apresentação onde cada página é um slide. Esses slides podem ser visualizados abrindo os arquivos de apresentação usando o Microsoft PowerPoint. Mas, às vezes, os desenvolvedores podem precisar visualizar as imagens das formas separadamente em um visualizador de imagens. Nesses casos, o Aspose.Slides ajuda a gerar imagens em miniatura das formas do slide. Como usar esse recurso é descrito neste artigo.

Este artigo explica como gerar miniaturas de slides de diferentes maneiras:

- Gerar uma miniatura de forma dentro de um slide.
- Gerar uma miniatura de forma para uma forma de slide com dimensões definidas pelo usuário.
- Gerar uma miniatura de forma nos limites da aparência de uma forma.

## **Gerar uma Miniatura de Forma a partir de um Slide**
Para gerar uma miniatura de forma a partir de qualquer slide usando Aspose.Slides para PHP via Java, faça o seguinte:

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/php-java/aspose.slides/presentation).
1. Obtenha a referência de qualquer slide usando seu ID ou índice.
1. [Obtenha a imagem em miniatura da forma](https://reference.aspose.com/slides/pt/php-java/aspose.slides/shape/#getImage) do slide referenciado na escala padrão.
1. Salve a imagem em miniatura no formato de imagem de sua preferência.

```php
  # Instanciar uma classe Presentation que representa o arquivo de apresentação
  $pres = new Presentation("Thumbnail.pptx");
  try {
    # Criar uma imagem em escala total
    $slideImage = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0)->getImage();
    # Salvar a imagem no disco em formato PNG
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
Para gerar a miniatura de forma de um slide usando Aspose.Slides para PHP via Java, faça o seguinte:

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/php-java/aspose.slides/presentation).
1. Obtenha a referência de qualquer slide usando seu ID ou índice.
1. [Obtenha a imagem em miniatura da forma](https://reference.aspose.com/slides/pt/php-java/aspose.slides/shape/#getImage) do slide referenciado com dimensões definidas pelo usuário.
1. Salve a imagem em miniatura no formato de imagem de sua preferência.

```php
  # Instanciar uma classe Presentation que representa o arquivo de apresentação
  $pres = new Presentation("Thumbnail.pptx");
  try {
    # Criar uma imagem em escala total
    $slideImage = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0)->getImage(ShapeThumbnailBounds->Shape, 1, 1);
    # Salvar a imagem no disco em formato PNG
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
Este método de criação de miniaturas de formas permite que os desenvolvedores gerem uma miniatura dentro dos limites da aparência da forma. Ele leva em consideração todos os efeitos da forma. A miniatura de forma gerada é restringida pelos limites do slide. Para gerar uma miniatura de uma forma de slide dentro dos limites de sua aparência, faça o seguinte:

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/php-java/aspose.slides/presentation).
1. Obtenha a referência de qualquer slide usando seu ID ou índice.
1. Obtenha a imagem em miniatura do slide referenciado com os limites da forma como aparência.
1. Salve a imagem em miniatura no formato de imagem de sua preferência.

```php
  # Instanciar uma classe Presentation que representa o arquivo de apresentação
  $pres = new Presentation("Thumbnail.pptx");
  try {
    # Criar uma imagem em escala total
    $slideImage = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0)->getImage(ShapeThumbnailBounds->Appearance, 1, 1);
    # Salvar a imagem no disco em formato PNG
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

## **Obter os Limites Visuais Reais de uma Forma**

As propriedades de quadro de [Shape](https://reference.aspose.com/slides/pt/php-java/aspose.slides/shape/) — `Shape::getX()`, `Shape::getY()`, `Shape::getWidth()` e `Shape::getHeight()` — descrevem o retângulo armazenado no modelo da apresentação. O conteúdo que realmente é renderizado pode se estender além desse quadro ou ocupar um retângulo alinhado aos eixos diferente. Rotação, contornos, pontas de seta, layout e transbordamento de texto, geometria de SmartArt gerada e outros efeitos de renderização podem mudar a área ocupada.

Use [Shape::getVisualBounds](https://reference.aspose.com/slides/pt/php-java/aspose.slides/shape/#getVisualBounds) para calcular essa área ocupada sem criar uma imagem. O método retorna um [Rectangle2D.Float](https://docs.oracle.com/javase/8/docs/api/java/awt/geom/Rectangle2D.Float.html) nas coordenadas do slide. O retângulo retornado não é recortado ao slide, portanto suas coordenadas podem ser negativas quando o conteúdo se estende além da origem do slide.

O exemplo a seguir obtém e compara os limites de quadro e visuais:

```php
  $presentation = new Presentation("example.pptx");
  try {
      $slide = $presentation->getSlides()->get_Item(0);
      $shape = $slide->getShapes()->get_Item(0);

      $visualBounds = $shape->getVisualBounds();

      $frameX = $shape->getX();
      $frameY = $shape->getY();
      $frameWidth = $shape->getWidth();
      $frameHeight = $shape->getHeight();

      $visualX = $visualBounds->getX();
      $visualY = $visualBounds->getY();
      $visualWidth = $visualBounds->getWidth();
      $visualHeight = $visualBounds->getHeight();

      echo "Frame bounds (x, y, width, height): $frameX, $frameY, $frameWidth, $frameHeight\n";
      echo "Visual bounds (x, y, width, height): $visualX, $visualY, $visualWidth, $visualHeight\n";
  } finally {
      $presentation->dispose();
  }
```

O mesmo [Rectangle2D.Float](https://docs.oracle.com/javase/8/docs/api/java/awt/geom/Rectangle2D.Float.html) pode ser usado para alinhar formas próximas à sua borda esquerda, direita, superior ou inferior; reservar espaço suficiente em um layout gerado; ou detectar conteúdo fora de uma região permitida. Os limites visuais são especialmente úteis para SmartArt, caixas de texto, setas, imagens, formas giradas e formas agrupadas, onde o quadro armazenado pode não representar o resultado renderizado completo.

Use [Shape::getVisualBounds](https://reference.aspose.com/slides/pt/php-java/aspose.slides/shape/#getVisualBounds) quando precisar de coordenadas para layout ou validação e não precisar de um bitmap. Use [Shape::getImage](https://reference.aspose.com/slides/pt/php-java/aspose.slides/shape/#getImage) quando precisar renderizar a forma. Com [ShapeThumbnailBounds](https://reference.aspose.com/slides/pt/php-java/aspose.slides/shapethumbnailbounds/), `ShapeThumbnailBounds::Shape` dimensiona a imagem a partir dos limites da forma, incluindo configurações de contorno, enquanto `ShapeThumbnailBounds::Appearance` a dimensiona a partir da aparência da forma e restringe o resultado aos limites do slide. Em contraste, `Shape::getVisualBounds` retorna apenas o retângulo calculado e não o recorta ao slide.

## **Perguntas Frequentes**

**Quais formatos de imagem podem ser usados ao salvar miniaturas de forma?**

[PNG, JPEG, BMP, GIF, TIFF](https://reference.aspose.com/slides/pt/php-java/aspose.slides/imageformat/), e outros. As formas também podem ser [exportadas como SVG vetorial](https://reference.aspose.com/slides/pt/php-java/aspose.slides/shape/writeassvg/) salvando o conteúdo da forma como SVG.

**Qual é a diferença entre os limites Shape e Appearance ao renderizar uma miniatura?**

`Shape` usa a geometria da forma; `Appearance` leva em conta os [efeitos visuais](/slides/pt/php-java/shape-effect/) (sombras, brilhos etc.).

**O que acontece se uma forma for marcada como oculta? Ela ainda será renderizada como miniatura?**

Uma forma oculta continua fazendo parte do modelo e pode ser renderizada; a flag oculta afeta a exibição da apresentação, mas não impede a geração da imagem da forma.

**Formas de grupo, gráficos, SmartArt e outros objetos complexos são suportados?**

Sim. Qualquer objeto representado como [Shape](https://reference.aspose.com/slides/pt/php-java/aspose.slides/shape/) (incluindo [GroupShape](https://reference.aspose.com/slides/pt/php-java/aspose.slides/groupshape/), [Chart](https://reference.aspose.com/slides/pt/php-java/aspose.slides/chart/) e [SmartArt](https://reference.aspose.com/slides/pt/php-java/aspose.slides/smartart/)) pode ser salvo como miniatura ou como SVG.

**As fontes instaladas no sistema afetam a qualidade das miniaturas para formas de texto?**

Sim. Você deve [fornecer as fontes necessárias](/slides/pt/php-java/custom-font/) (ou [configurar substituições de fontes](/slides/pt/php-java/font-substitution/)) para evitar substituições indesejadas e reflow de texto.