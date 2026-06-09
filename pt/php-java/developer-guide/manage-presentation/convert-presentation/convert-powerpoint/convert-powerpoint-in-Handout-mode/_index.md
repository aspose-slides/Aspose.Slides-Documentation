---
title: Converter apresentações PowerPoint no modo Handout usando PHP
linktitle: Modo Handout
type: docs
weight: 150
url: /pt/php-java/convert-powerpoint-in-Handout-mode/
keywords:
- converter PowerPoint
- converter apresentação
- modo handout
- folheto
- PPT
- PPTX
- PowerPoint
- apresentação
- PHP
- Aspose.Slides
description: "Converter apresentações em folhetos em PHP. Defina slides por página, mantenha notas, exporte para PDF ou imagens com Aspose.Slides para PHP, com código de exemplo. Experimente grátis."
---
## **Introdução**

O Aspose.Slides oferece a capacidade de converter apresentações em vários formatos, incluindo a criação de folhetos para impressão no modo Handout. Esse modo permite configurar como múltiplos slides aparecem em uma única página, tornando‑o útil para conferências, seminários e outros eventos. Você pode ativar esse modo definindo o método `setSlidesLayoutOptions` nas classes [PdfOptions](https://reference.aspose.com/slides/pt/php-java/aspose.slides/pdfoptions/), [RenderingOptions](https://reference.aspose.com/slides/pt/php-java/aspose.slides/renderingoptions/), [HtmlOptions](https://reference.aspose.com/slides/pt/php-java/aspose.slides/htmloptions/) e [TiffOptions](https://reference.aspose.com/slides/pt/php-java/aspose.slides/tiffoptions/).

## **Exportação no modo Handout**

Para configurar o modo Handout, use o objeto [HandoutLayoutingOptions](https://reference.aspose.com/slides/pt/php-java/aspose.slides/handoutlayoutingoptions/), que determina quantos slides são colocados em uma única página e outros parâmetros de exibição.

Abaixo está um exemplo de código que mostra como converter uma apresentação para PDF no modo Handout.

```php
// Carregar uma apresentação.
$presentation = new Presentation("sample.pptx");

// Definir as opções de exportação.
$slidesLayoutOptions = new HandoutLayoutingOptions();
$slidesLayoutOptions->setHandout(HandoutType::Handouts4Horizontal);  // 4 slides em uma página horizontalmente
$slidesLayoutOptions->setPrintSlideNumbers(true);                    // imprimir números dos slides
$slidesLayoutOptions->setPrintFrameSlide(true);                      // imprimir uma moldura ao redor dos slides
$slidesLayoutOptions->setPrintComments(false);                       // sem comentários

$pdfOptions = new PdfOptions();
$pdfOptions->setSlidesLayoutOptions($slidesLayoutOptions);

// Exportar a apresentação para PDF com o layout escolhido.
$presentation->save("output.pdf", SaveFormat::Pdf, $pdfOptions);
$presentation->dispose();
```

{{% alert color="warning" %}} 
Lembre‑se de que o método `setSlidesLayoutOptions` está disponível apenas para certos formatos de saída, como PDF, HTML, TIFF, e ao renderizar como imagens.
{{% /alert %}} 

## **FAQ**

**Qual é o número máximo de miniaturas de slide por página no modo Handout?**

O Aspose.Slides suporta [presets](https://reference.aspose.com/slides/pt/php-java/aspose.slides/handouttype/) de até 9 miniaturas por página com ordenação horizontal ou vertical: 1, 2, 3, 4 (horizontal/vertical), 6 (horizontal/vertical) e 9 (horizontal/vertical).

**Posso definir uma grade personalizada, como 5 ou 8 slides por página?**

Não. O número e a ordenação das miniaturas são controlados estritamente pela classe [HandoutType](https://reference.aspose.com/slides/pt/php-java/aspose.slides/handouttype/); layouts arbitrários não são suportados.

**Posso incluir slides ocultos na saída Handout?**

Sim. Ative os slides ocultos usando o método `setShowHiddenSlides` nas configurações de exportação para o formato de destino, como [PdfOptions](https://reference.aspose.com/slides/pt/php-java/aspose.slides/pdfoptions/), [HtmlOptions](https://reference.aspose.com/slides/pt/php-java/aspose.slides/htmloptions/) ou [TiffOptions](https://reference.aspose.com/slides/pt/php-java/aspose.slides/tiffoptions/).