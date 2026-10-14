---
title: Converter Slides do PowerPoint para PNG em PHP
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
description: "Converta apresentações do PowerPoint em imagens PNG de alta qualidade rapidamente com Aspose.Slides para PHP via Java, garantindo resultados precisos e automatizados."
---
## **Visão geral**

Este artigo explica como converter slides de apresentação em imagens PNG usando Aspose.Slides para PHP via Java. Você pode carregar apresentações em formatos como PPT, PPTX e ODP, renderizar cada slide e salvá-lo como uma imagem PNG separada.

Os exemplos abaixo demonstram a renderização na escala padrão, o aumento da escala, a especificação das dimensões de saída em pixels e a escolha de um estilo de renderização de gradiente.

## **Converter PowerPoint para PNG**

Carregue uma apresentação com a classe [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) e acesse seus slides através da coleção [Presentation::getSlides](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/#getSlides). O exemplo renderiza cada slide com [Slide::getImage](https://reference.aspose.com/slides/php-java/aspose.slides/slide/#getImage) sem parâmetros para criar uma miniatura. Em seguida, chama [IImage::save](https://reference.aspose.com/slides/php-java/aspose.slides/iimage/#save) com [ImageFormat::Png](https://reference.aspose.com/slides/php-java/aspose.slides/imageformat/#Png) para salvar cada slide renderizado como uma imagem PNG.

```php
use aspose\slides\ImageFormat;
use aspose\slides\Presentation;

$presentation = new Presentation("presentation.pptx");
try {
    $slideCount = java_values($presentation->getSlides()->size());
    for ($index = 0; $index < $slideCount; $index++) {
        $slide = $presentation->getSlides()->get_Item($index);
        $image = $slide->getImage();
        try {
            $image->save("slide_" . $index . ".png", ImageFormat::Png);
        } finally {
            $image->dispose();
        }
    }
} finally {
    $presentation->dispose();
}
```

{{% alert color="info" title="Note" %}}
A sobrecarga sem parâmetros de [Slide::getImage](https://reference.aspose.com/slides/php-java/aspose.slides/slide/#getImage) renderiza em uma escala de 0,2. Por exemplo, um slide medindo 720 × 540 pontos produz uma miniatura de 144 × 108 pixels. Para controlar as dimensões de saída, use as sobrecargas com fatores de escala ou um tamanho de imagem explícito mostrado abaixo.
{{% /alert %}}

## **Converter PowerPoint para PNG com Dimensões Personalizadas**

Passe fatores de escala horizontal e vertical para [Slide::getImage](https://reference.aspose.com/slides/php-java/aspose.slides/slide/#getImage) para controlar as dimensões renderizadas. Neste exemplo, ambos os fatores são 2, portanto um slide que mede 720 × 540 pontos produz uma imagem de 1440 × 1080 pixels. Fatores de escala iguais preservam a proporção do slide. Cada imagem é salva no formato PNG com [IImage::save](https://reference.aspose.com/slides/php-java/aspose.slides/iimage/#save).

```php
use aspose\slides\ImageFormat;
use aspose\slides\Presentation;

$presentation = new Presentation("presentation.pptx");
try {
    $scaleX = 2.0;
    $scaleY = $scaleX;

    $slideCount = java_values($presentation->getSlides()->size());
    for ($index = 0; $index < $slideCount; $index++) {
        $slide = $presentation->getSlides()->get_Item($index);
        $image = $slide->getImage($scaleX, $scaleY);
        try {
            $image->save("slide_" . $index . ".png", ImageFormat::Png);
        } finally {
            $image->dispose();
        }
    }
} finally {
    $presentation->dispose();
}
```

## **Converter PowerPoint para PNG com Tamanho Personalizado**

Para especificar as dimensões de saída em pixels, passe um tamanho para [Slide::getImage](https://reference.aspose.com/slides/php-java/aspose.slides/slide/#getImage) em vez de fatores de escala. Este exemplo renderiza cada slide em 960 × 720 pixels e salva o resultado com [IImage::save](https://reference.aspose.com/slides/php-java/aspose.slides/iimage/#save). Escolha dimensões que correspondam à proporção do slide para evitar esticar a imagem.

```php
use aspose\slides\ImageFormat;
use aspose\slides\Presentation;

$presentation = new Presentation("presentation.pptx");
try {
    $imageSize = new Java("java.awt.Dimension", 960, 720);

    $slideCount = java_values($presentation->getSlides()->size());
    for ($index = 0; $index < $slideCount; $index++) {
        $slide = $presentation->getSlides()->get_Item($index);
        $image = $slide->getImage($imageSize);
        try {
            $image->save("slide_" . $index . ".png", ImageFormat::Png);
        } finally {
            $image->dispose();
        }
    }
} finally {
    $presentation->dispose();
}
```

## **Escolher um Estilo de Renderização de Gradiente**

Suponha que um slide contenha preenchimentos em gradiente, mas as transições no PNG exportado pareçam mais claras ou diferentes do que você vê no PowerPoint. Você pode usar o método [SaveOptions::setGradientStyle](https://reference.aspose.com/slides/php-java/aspose.slides/saveoptions/#setGradientStyle) herdado por [RenderingOptions](https://reference.aspose.com/slides/php-java/aspose.slides/renderingoptions/) para escolher como os gradientes são renderizados.

Baixe [gradient-styles.pptx](gradient-styles.pptx) e coloque-o no diretório de trabalho da aplicação. Seu primeiro slide contém dois gradientes lineares: ciano para laranja na parte superior e azul para amarelo na parte inferior. Cada gradiente tem duas paradas, em 0% e 100%.

O exemplo a seguir carrega esta apresentação e renderiza o mesmo primeiro slide em ambos os modos com [Slide::getImage](https://reference.aspose.com/slides/php-java/aspose.slides/slide/#getImage).

```php
use aspose\slides\GradientStyle;
use aspose\slides\ImageFormat;
use aspose\slides\Presentation;
use aspose\slides\RenderingOptions;

$presentation = new Presentation("gradient-styles.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $gradientStyles = [GradientStyle::Default, GradientStyle::PowerPointUI];
    foreach ($gradientStyles as $style) {
        $options = new RenderingOptions();
        $options->setGradientStyle($style);

        $styleName = $style == GradientStyle::Default ? "Default" : "PowerPointUI";
        $image = $slide->getImage($options, 1.0, 1.0);
        try {
            $image->save("gradient-" . $styleName . ".png", ImageFormat::Png);
        } finally {
            $image->dispose();
        }
    }
} finally {
    $presentation->dispose();
}
```

As imagens abaixo mostram a saída do mesmo slide, com ambos os gradientes em cada imagem:

| Default | PowerPointUI |
| --- | --- |
| ![Gradientes ciano‑para‑laranja e azul‑para‑amarelo renderizados com Default](gradient-Default.png) | ![Os mesmos gradientes renderizados com PowerPointUI](gradient-PowerPointUI.png) |

Neste exemplo, `Default` produz cores intermediárias mais claras, enquanto `PowerPointUI` produz cores intermediárias mais escuras. A diferença depende das cores e das paradas no gradiente.

Escolha `Default` quando a saída padrão do Aspose.Slides atender às suas necessidades. Experimente `PowerPointUI` quando sua prioridade for corresponder à aparência no PowerPoint. Compare ambas as saídas com o resultado desejado; nenhum modo é universalmente preferível.

## **Perguntas Frequentes**

**Como posso exportar uma forma específica, como um gráfico ou imagem, em vez de todo o slide?**

Aspose.Slides suporta [gerar miniaturas para formas individuais](/slides/pt/php-java/create-shape-thumbnails/), permitindo renderizar uma forma como uma imagem PNG.

**A conversão paralela é suportada em um servidor?**

Sim. Use uma instância de apresentação separada para cada thread ou processo; [não compartilhe uma única instância entre threads](/slides/pt/php-java/multithreading/).

**Quais são as limitações da avaliação ao exportar para PNG?**

O modo de avaliação adiciona uma marca d'água às imagens de saída e aplica [outras restrições](/slides/pt/php-java/licensing/) até que uma licença seja aplicada.