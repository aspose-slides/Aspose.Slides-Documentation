---
title: Converter apresentações PowerPoint para SWF Flash em PHP
linktitle: PowerPoint para SWF
type: docs
weight: 80
url: /pt/php-java/convert-powerpoint-to-swf-flash/
keywords:
- converter PowerPoint
- converter apresentação
- converter slide
- converter PPT
- converter PPTX
- PowerPoint para SWF
- apresentação para SWF
- slide para SWF
- PPT para SWF
- PPTX para SWF
- PowerPoint para Flash
- apresentação para Flash
- slide para Flash
- PPT para Flash
- PPTX para Flash
- salvar PPT como SWF
- salvar PPTX como SWF
- exportar PPT para SWF
- exportar PPTX para SWF
- PowerPoint
- apresentação
- PHP
- Aspose.Slides
description: "Converta PowerPoint (PPT/PPTX) para SWF Flash em PHP com Aspose.Slides. Exemplos de código passo a passo, saída de alta qualidade e rápida, sem automação do PowerPoint."
---
## **Visão geral**

Este artigo explica como converter apresentações do PowerPoint para SWF usando o Aspose.Slides. Ele mostra como salvar uma apresentação como um arquivo SWF usando o método [Presentation::save](https://reference.aspose.com/slides/pt/php-java/aspose.slides/presentation/save/) e como configurar a exportação com [SwfOptions](https://reference.aspose.com/slides/pt/php-java/aspose.slides/swfoptions/), incluindo as configurações do visualizador e o layout de notas ou comentários.

## **Converter apresentações para Flash**

O método [save](https://reference.aspose.com/slides/pt/php-java/aspose.slides/presentation/save/) exposto pela classe [Presentation](https://reference.aspose.com/slides/pt/php-java/aspose.slides/presentation/) pode ser usado para converter toda a apresentação em um documento **SWF**. O exemplo a seguir demonstra como converter uma apresentação em um documento **SWF** usando as opções fornecidas pela classe [SWFOptions](https://reference.aspose.com/slides/pt/php-java/aspose.slides/swfoptions/). Você também pode incluir comentários no SWF gerado usando a classe [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/pt/php-java/aspose.slides/notescommentslayoutingoptions/).

```php
  $pres = new Presentation("Sample.pptx");
  try {
    $swfOptions = new SwfOptions();
    $swfOptions->setViewerIncluded(false);
    $swfOptions->getNotesCommentsLayouting()->setNotesPosition(NotesPositions::BottomFull);
    # Salvando apresentação
    $pres->save("Sample.swf", SaveFormat::Swf, $swfOptions);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **FAQ**

**Posso incluir slides ocultos no SWF?**

Sim. Habilite os slides ocultos usando o método [setShowHiddenSlides](https://reference.aspose.com/slides/pt/php-java/aspose.slides/swfoptions/setshowhiddenslides/) em [SwfOptions](https://reference.aspose.com/slides/pt/php-java/aspose.slides/swfoptions/). Por padrão, os slides ocultos não são exportados.

**Como posso controlar a compressão e o tamanho final do SWF?**

Use o método [setCompressed](https://reference.aspose.com/slides/pt/php-java/aspose.slides/swfoptions/setcompressed/) e [adjust JPEG quality](https://reference.aspose.com/slides/pt/php-java/aspose.slides/swfoptions/setjpegquality/) para equilibrar o tamanho do arquivo e a fidelidade da imagem.

**Para que serve 'setViewerIncluded' e quando devo desativá-lo?**

[setViewerIncluded](https://reference.aspose.com/slides/pt/php-java/aspose.slides/swfoptions/setviewerincluded/) adiciona uma interface de usuário de player incorporada (controles de navegação, painéis, busca). Desative-a se pretender usar seu próprio player ou precisar de um quadro SWF sem interface.

**O que acontece se uma fonte de origem estiver ausente na máquina de exportação?**

O Aspose.Slides substituirá a fonte que você especificar via [setDefaultRegularFont](https://reference.aspose.com/slides/pt/php-java/aspose.slides/saveoptions/#setDefaultRegularFont) em [SwfOptions](https://reference.aspose.com/slides/pt/php-java/aspose.slides/swfoptions/) para evitar um fallback inesperado.