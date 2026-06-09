---
title: Extração avançada de texto de apresentações em PHP
linktitle: Extrair texto
type: docs
weight: 90
url: /pt/php-java/extract-text-from-presentation/
keywords:
- extrair texto
- extrair texto do slide
- extrair texto da apresentação
- extrair texto do PowerPoint
- extrair texto do OpenDocument
- extrair texto do PPT
- extrair texto do PPTX
- extrair texto do ODP
- recuperar texto
- recuperar texto do slide
- recuperar texto da apresentação
- recuperar texto do PowerPoint
- recuperar texto do OpenDocument
- recuperar texto do PPT
- recuperar texto do PPTX
- recuperar texto do ODP
- PowerPoint
- OpenDocument
- apresentação
- PHP
- Aspose.Slides
description: "Extraia rapidamente texto de apresentações PowerPoint e OpenDocument usando Aspose.Slides para PHP via Java. Siga nosso guia simples, passo a passo, para economizar tempo."
---
## **Visão geral**

Extrair texto de apresentações é uma tarefa comum, mas essencial, para desenvolvedores que trabalham com conteúdo de slides. Seja lidando com arquivos Microsoft PowerPoint nos formatos PPT ou PPTX, ou apresentações OpenDocument (ODP), acessar e recuperar dados textuais pode ser crítico para análise, automação, indexação ou migração de conteúdo.

Este artigo fornece um guia completo sobre como extrair texto de forma eficiente de vários formatos de apresentação, incluindo PPT, PPTX e ODP, usando Aspose.Slides for PHP via Java. Você aprenderá a percorrer sistematicamente os elementos da apresentação para recuperar com precisão o conteúdo de texto necessário.

## **Extrair texto de um slide**

Aspose.Slides for PHP via Java fornece a classe [SlideUtil](https://reference.aspose.com/slides/pt/php-java/aspose.slides/slideutil/). Essa classe expõe vários métodos estáticos sobrecarregados para extrair todo o texto de uma apresentação ou slide. Para extrair texto de um slide em uma apresentação, use o método [getAllTextBoxes](https://reference.aspose.com/slides/pt/php-java/aspose.slides/slideutil/#getAllTextBoxes). Esse método aceita um objeto do tipo [BaseSlide](https://reference.aspose.com/slides/pt/php-java/aspose.slides/baseslide/) como parâmetro. Quando executado, o método varre todo o slide em busca de texto e retorna um array de objetos do tipo [TextFrame](https://reference.aspose.com/slides/pt/php-java/aspose.slides/textframe/), preservando qualquer formatação de texto.

O trecho de código a seguir extrai todo o texto do primeiro slide da apresentação:

```php
$slideIndex = 0;

$presentation = new Presentation("demo.pptx");
$arrayClass = new java_class("java.lang.reflect.Array");

try {
    $slide = $presentation->getSlides()->get_Item($slideIndex);

    $textFrames = SlideUtil::getAllTextBoxes($slide);
    $textFrameCount = java_values($arrayClass->getLength($textFrames));

    for ($textFrameIndex = 0; $textFrameIndex < $textFrameCount; $textFrameIndex++) {
        foreach ($textFrames[$textFrameIndex]->getParagraphs() as $paragraph) {
            foreach ($paragraph->getPortions() as $portion) {
                $portionText = $portion->getText();
                echo($portionText);

                $portionFormat = $portion->getPortionFormat();
                $fontHeight = $portionFormat->getFontHeight();
                echo($fontHeight);

                $latinFont = $portionFormat->getLatinFont();
                if (!java_is_null($latinFont)) {
                    $fontName = $latinFont->getFontName();
                    echo($fontName);
                }
            }
        }
    }
} finally {
    $presentation->dispose();
}
```

## **Extrair texto de uma apresentação**

Para escanear texto de toda a apresentação, use o método estático [getAllTextFrames](https://reference.aspose.com/slides/pt/php-java/aspose.slides/slideutil/#getAllTextFrames) exposto pela classe [SlideUtil](https://reference.aspose.com/slides/pt/php-java/aspose.slides/slideutil/). Ele aceita dois parâmetros:

1. Primeiro, um objeto [Presentation](https://reference.aspose.com/slides/pt/php-java/aspose.slides/presentation/) que representa uma apresentação PowerPoint ou OpenDocument da qual o texto será extraído.  
2. Segundo, um valor `boolean` que indica se os slides mestres devem ser incluídos ao escanear o texto da apresentação.

O método retorna um array de objetos do tipo [TextFrame](https://reference.aspose.com/slides/pt/php-java/aspose.slides/textframe/), incluindo informações de formatação de texto. O código abaixo escaneia o texto e os detalhes de formatação de uma apresentação, incluindo os slides mestres.

```php
$presentation = new Presentation("demo.pptx");
$arrayClass = new java_class("java.lang.reflect.Array");

try {
    $includeMasterSlides = true;
    $textFrames = SlideUtil::getAllTextFrames($presentation, $includeMasterSlides);
    $textFrameCount = java_values($arrayClass->getLength($textFrames));

    for ($textFrameIndex = 0; $textFrameIndex < $textFrameCount; $textFrameIndex++) {
        foreach ($textFrames[$textFrameIndex]->getParagraphs() as $paragraph) {
            foreach ($paragraph->getPortions() as $portion) {
                $portionText = $portion->getText();
                echo($portionText);

                $portionFormat = $portion->getPortionFormat();
                $fontHeight = $portionFormat->getFontHeight();
                echo($fontHeight);

                $latinFont = $portionFormat->getLatinFont();
                if (!java_is_null($latinFont)) {
                    $fontName = $latinFont->getFontName();
                    echo($fontName);
                }
            }
        }
    }
} finally {
    $presentation->dispose();
}
```

## **Extração de texto categorizada e rápida**

A classe [PresentationFactory](https://reference.aspose.com/slides/pt/php-java/aspose.slides/presentationfactory/) também fornece métodos para extrair todo o texto de apresentações:

```php
PresentationText getPresentationText(String, int);
PresentationText getPresentationText(InputStream, int);
PresentationText getPresentationText(InputStream, int, LoadOptions);
```

O argumento enum [TextExtractionArrangingMode](https://reference.aspose.com/slides/pt/php-java/aspose.slides/textextractionarrangingmode/) indica o modo de organização do resultado da extração de texto e pode ser definido com os seguintes valores:
- `Unarranged` – O texto bruto, sem considerar sua posição no slide.  
- `Arranged` – O texto é organizado na mesma ordem em que aparece no slide.

O modo *unarranged* pode ser usado quando a velocidade é crítica; ele é mais rápido que o modo *arranged*.

[PresentationText](https://reference.aspose.com/slides/pt/php-java/aspose.slides/presentationtext/) representa o texto bruto extraído da apresentação. Seu método `getSlidesText` retorna um array de objetos onde cada objeto representa o texto no slide correspondente. Cada objeto retornado possui os seguintes métodos:

- `getText` – O texto dentro das formas do slide.  
- `getMasterText` – O texto dentro das formas do slide mestre associado a este slide.  
- `getLayoutText` – O texto dentro das formas do slide de layout associado a este slide.  
- `getNotesText` – O texto dentro das formas do slide de notas associado a este slide.  
- `getCommentsText` – O texto dentro dos comentários associados a este slide.

```php
$presentationPath = "presentation.ppt";
$arrangingMode = TextExtractionArrangingMode::Unarranged;
$presentationText = PresentationFactory::getInstance()->getPresentationText($presentationPath, $arrangingMode);
$slidesText = $presentationText->getSlidesText();
$firstSlideText = $slidesText[0];

echo($firstSlideText->getText());
echo($firstSlideText->getLayoutText());
echo($firstSlideText->getMasterText());
echo($firstSlideText->getNotesText());
echo($firstSlideText->getCommentsText());
```

## **FAQ**

**Quão rápido o Aspose.Slides processa apresentações grandes durante a extração de texto?**

Aspose.Slides está otimizado para alto desempenho e pode processar até mesmo [apresentações grandes](/slides/pt/php-java/open-presentation/), tornando‑se adequado para cenários de processamento em tempo real ou em lote.

**O Aspose.Slides pode extrair texto de tabelas e gráficos dentro das apresentações?**

Sim. Aspose.Slides pode extrair texto de muitos elementos de slide, incluindo tabelas e objetos relacionados a gráficos, permitindo que você acesse e analise o conteúdo textual em estruturas comuns de apresentações.

**Preciso de uma licença especial do Aspose.Slides para extrair texto de apresentações?**

É possível extrair texto usando a versão de avaliação gratuita do Aspose.Slides, embora ela possua [certas limitações](/slides/pt/php-java/licensing/), como o processamento de um número limitado de slides. Para uso ilimitado e para lidar com apresentações maiores, recomenda‑se a aquisição de uma licença completa.