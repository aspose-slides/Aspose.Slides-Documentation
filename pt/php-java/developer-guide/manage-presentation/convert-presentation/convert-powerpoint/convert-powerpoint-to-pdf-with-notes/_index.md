---
title: Converter Apresentações PowerPoint para PDF com Notas em PHP
linktitle: PowerPoint para PDF com Notas
type: docs
weight: 50
url: /pt/php-java/convert-powerpoint-to-pdf-with-notes/
keywords:
- converter PowerPoint
- converter apresentação
- converter slide
- converter PPT
- converter PPTX
- PowerPoint para PDF
- apresentação para PDF
- slide para PDF
- PPT para PDF
- PPTX para PDF
- salvar apresentação como PDF
- salvar PPT como PDF
- salvar PPTX como PDF
- exportar PPT para PDF
- exportar PPTX para PDF
- notas do apresentador
- PDF com notas
- PHP
- Aspose.Slides
description: "Converter formatos PPT e PPTX para PDF com notas usando Aspose.Slides para PHP via Java. Preserve layouts e notas do apresentador para apresentações profissionais."
---
## **Visão geral**

Neste artigo, você aprenderá como converter apresentações do PowerPoint para o formato PDF com notas do apresentador usando Aspose.Slides. Este guia abordará as etapas necessárias e fornecerá exemplos de código para ajudá‑lo a executar essa tarefa de forma eficiente. Ao final deste artigo, você será capaz de:

- Implementar o processo de conversão para transformar slides do PowerPoint em documentos PDF preservando as notas do apresentador.
- Personalizar o PDF de saída para garantir que as notas do apresentador sejam incluídas e formatadas de acordo com seus requisitos.

## **Converter PowerPoint para PDF com Notas**

O método `save` na classe [Presentation](https://reference.aspose.com/slides/pt/php-java/aspose.slides/presentation/) pode ser usado para converter uma apresentação PPT ou PPTX para PDF com notas do apresentador. Com Aspose.Slides, você simplesmente carrega a apresentação, configura as opções de layout usando a classe [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/pt/php-java/aspose.slides/notescommentslayoutingoptions/) para incluir as notas do apresentador e, em seguida, salva o arquivo como PDF. O trecho de código a seguir demonstra como converter uma apresentação de exemplo para PDF na visualização de Slide com Notas.

```php
$presentation = new Presentation("sample.pptx");

// Configurar opções de PDF para renderizar notas do apresentador.
$notesOptions = new NotesCommentsLayoutingOptions();
$notesOptions->setNotesPosition(NotesPositions::BottomFull); // Renderizar notas do apresentador abaixo do slide.

$pdfOptions = new PdfOptions();
$pdfOptions->setSlidesLayoutOptions($notesOptions);

// Salvar a apresentação em PDF com notas do apresentador.
$presentation->save("output.pdf", SaveFormat::Pdf, $pdfOptions);
$presentation->dispose();
```

{{% alert color="primary" %}} 

Você pode querer conferir o [Conversor Online de PowerPoint para PDF da Aspose](https://products.aspose.app/slides/pt/conversion). 

{{% /alert %}}