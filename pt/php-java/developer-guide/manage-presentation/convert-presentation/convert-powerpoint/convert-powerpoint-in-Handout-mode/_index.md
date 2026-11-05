---
title: Converter apresentações PowerPoint no modo folheto usando PHP
linktitle: Modo Folheto
type: docs
weight: 150
url: /pt/php-java/convert-powerpoint-in-handout-mode/
keywords:
- converter PowerPoint
- converter apresentação
- modo de folheto
- folheto
- PPT
- PPTX
- PowerPoint
- apresentação
- PHP
- Aspose.Slides
description: "Converter apresentações em folhetos no PHP. Definir slides por página, manter notas, exportar para PDF ou imagens com Aspose.Slides para PHP, com código de exemplo. Experimente grátis."
---
## **Introdução**

Aspose.Slides oferece a capacidade de converter apresentações para vários formatos, incluindo a criação de folhetos para impressão no modo Folheto. Esse modo permite configurar quantos slides aparecem em uma única página, sendo útil para conferências, seminários e outros eventos. Você pode habilitar esse modo definindo o método `setSlidesLayoutOptions` nas classes [PdfOptions](https://reference.aspose.com/slides/pt/php-java/aspose.slides/pdfoptions/), [RenderingOptions](https://reference.aspose.com/slides/pt/php-java/aspose.slides/renderingoptions/), [HtmlOptions](https://reference.aspose.com/slides/pt/php-java/aspose.slides/htmloptions/) e [TiffOptions](https://reference.aspose.com/slides/pt/php-java/aspose.slides/tiffoptions/).

Para definir as dimensões e a orientação da página de folheto antes da exportação, veja [Notes Page Size](/slides/pt/php-java/notes-size/).

## **Exportação no Modo Folheto**

Para configurar o modo Folheto, use o objeto [HandoutLayoutingOptions](https://reference.aspose.com/slides/pt/php-java/aspose.slides/handoutlayoutingoptions/), que determina quantos slides são colocados em uma única página e outros parâmetros de exibição.

Abaixo está um exemplo de código que mostra como converter uma apresentação para PDF no modo Folheto.

```php
// Carregar uma apresentação.
$presentation = new Presentation("sample.pptx");

// Set the export options.
$slidesLayoutOptions = new HandoutLayoutingOptions();
$slidesLayoutOptions->setHandout(HandoutType::Handouts4Horizontal);  // 4 slides em uma página horizontalmente
$slidesLayoutOptions->setPrintSlideNumbers(true);                    // imprimir números dos slides
$slidesLayoutOptions->setPrintFrameSlide(true);                      // imprimir uma moldura ao redor dos slides
$slidesLayoutOptions->setPrintComments(false);                       // sem comentários

$pdfOptions = new PdfOptions();
$pdfOptions->setSlidesLayoutOptions($slidesLayoutOptions);

// Export the presentation to PDF with the chosen layout.
$presentation->save("output.pdf", SaveFormat::Pdf, $pdfOptions);
$presentation->dispose();
```

{{% alert color="warning" title="Warning" %}}
Tenha em mente que o método `setSlidesLayoutOptions` está disponível apenas para determinados formatos de saída, como PDF, HTML, TIFF e ao renderizar como imagens.
{{% /alert %}} 

## **Perguntas Frequentes**

**Qual é o número máximo de miniaturas de slides por página no modo Folheto?**

Aspose.Slides suporta [predefinições](https://reference.aspose.com/slides/pt/php-java/aspose.slides/handouttype/) de até 9 miniaturas por página com ordenação horizontal ou vertical: 1, 2, 3, 4 (horizontal/vertical), 6 (horizontal/vertical) e 9 (horizontal/vertical).

**Posso definir uma grade personalizada, como 5 ou 8 slides por página?**

Não. O número e a ordem das miniaturas são controlados estritamente pela classe [HandoutType](https://reference.aspose.com/slides/pt/php-java/aspose.slides/handouttype/); layouts arbitrários não são suportados.

**Posso incluir slides ocultos na saída do Folheto?**

Sim. Habilite os slides ocultos usando o método `setShowHiddenSlides` nas configurações de exportação para o formato de destino, como [PdfOptions](https://reference.aspose.com/slides/pt/php-java/aspose.slides/pdfoptions/), [HtmlOptions](https://reference.aspose.com/slides/pt/php-java/aspose.slides/htmloptions/) ou [TiffOptions](https://reference.aspose.com/slides/pt/php-java/aspose.slides/tiffoptions/).