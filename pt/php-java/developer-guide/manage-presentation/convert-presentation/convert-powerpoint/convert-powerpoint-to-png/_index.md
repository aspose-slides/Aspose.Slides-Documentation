---
title: Converter slides PowerPoint para PNG em PHP
linktitle: PowerPoint para PNG
type: docs
weight: 30
url: /pt/php-java/convert-powerpoint-to-png/
keywords:
- converter PowerPoint
- converter apresentação
- converter slide
- converter PPT
- converter PPTX
- PowerPoint para PNG
- apresentação para PNG
- slide para PNG
- PPT para PNG
- PPTX para PNG
- salvar PPT como PNG
- salvar PPTX como PNG
- exportar PPT para PNG
- exportar PPTX para PNG
- PHP
- Aspose.Slides
description: "Converter apresentações PowerPoint em imagens PNG de alta qualidade rapidamente com Aspose.Slides para PHP via Java, garantindo resultados precisos e automatizados."
---
## **Visão geral**

Este artigo explica como converter apresentações PowerPoint em imagens PNG usando Aspose.Slides. Ele mostra como carregar arquivos de apresentação em formatos como PPT, PPTX e ODP, renderizar slides como imagens e salvar os resultados no formato PNG.

O artigo também demonstra como personalizar as imagens PNG geradas definindo valores de escala ou especificando a largura e a altura desejadas.

## **Converter PowerPoint para PNG**

Siga estas etapas:

1. Instancie a classe [Presentation](https://reference.aspose.com/slides/pt/php-java/aspose.slides/presentation/).
2. Obtenha o objeto slide da coleção [Presentation.getSlides()](https://reference.aspose.com/slides/pt/php-java/aspose.slides/presentation/#getSlides) na classe [Slide](https://reference.aspose.com/slides/pt/php-java/aspose.slides/slide/).
3. Use o método [Slide.getImage()](https://reference.aspose.com/slides/pt/php-java/aspose.slides/slide/#getImage) para obter a miniatura de cada slide.
4. Use o método [IImage.save(String formatName, int imageFormat)](https://reference.aspose.com/slides/pt/php-java/aspose.slides/iimage/#save) para salvar a miniatura do slide no formato PNG.

Este código PHP mostra como converter uma apresentação PowerPoint para PNG:

```php
  $pres = new Presentation("pres.pptx");
  try {
    for($index = 0; $index < java_values($pres->getSlides()->size()) ; $index++) {
      $slide = $pres->getSlides()->get_Item($index);
      $slideImage = $slide->getImage();
      try {
        $slideImage->save("image_java_" . $index . ".png", ImageFormat::Png);
      } finally {
        if (!java_is_null($slideImage)) {
          $slideImage->dispose();
        }
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Converter PowerPoint para PNG com dimensões personalizadas**

Se desejar obter arquivos PNG em uma certa escala, você pode definir os valores para `desiredX` e `desiredY`, que determinam as dimensões da miniatura resultante.

Este código demonstra a operação descrita:

```php
  $pres = new Presentation("pres.pptx");
  try {
    $scaleX = 2.0;
    $scaleY = 2.0;
    for($index = 0; $index < java_values($pres->getSlides()->size()) ; $index++) {
      $slide = $pres->getSlides()->get_Item($index);
      $slideImage = $slide->getImage($scaleX, $scaleY);
      try {
        $slideImage->save("image_java_" . $index . ".png", ImageFormat::Png);
      } finally {
        if (!java_is_null($slideImage)) {
          $slideImage->dispose();
        }
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Converter PowerPoint para PNG com tamanho personalizado**

Se desejar obter arquivos PNG em um tamanho específico, você pode passar os argumentos `width` e `height` preferidos para `ImageSize`.

Este código mostra como converter um PowerPoint para PNG especificando o tamanho das imagens:

```php
  $pres = new Presentation("pres.pptx");
  try {
    $size = new Java("java.awt.Dimension", 960, 720);
    for($index = 0; $index < java_values($pres->getSlides()->size()) ; $index++) {
      $slide = $pres->getSlides()->get_Item($index);
      $slideImage = $slide->getImage($size);
      try {
        $slideImage->save("image_java_" . $index . ".png", ImageFormat::Png);
      } finally {
        if (!java_is_null($slideImage)) {
          $slideImage->dispose();
        }
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **FAQ**

**Como exportar apenas uma forma específica (por exemplo, gráfico ou imagem) em vez de todo o slide?**

Aspose.Slides oferece suporte a [geração de miniaturas para formas individuais](/slides/pt/php-java/create-shape-thumbnails/); você pode renderizar uma forma para uma imagem PNG.

**A conversão paralela é suportada em um servidor?**

Sim, mas [não compartilhe](/slides/pt/php-java/multithreading/) uma única instância de apresentação entre threads. Use uma instância separada por thread ou processo.

**Quais são as limitações da versão de avaliação ao exportar para PNG?**

O modo de avaliação adiciona uma marca d'água às imagens de saída e impõe [outras restrições](/slides/pt/php-java/licensing/) até que uma licença seja aplicada.