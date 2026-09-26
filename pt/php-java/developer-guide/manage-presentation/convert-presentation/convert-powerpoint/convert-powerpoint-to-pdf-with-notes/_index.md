---
title: Converter apresentações PowerPoint para PDF com notas em PHP
linktitle: PowerPoint para PDF com notas
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
- notas do palestrante
- PDF com notas
- PHP
- Aspose.Slides
description: "Converter formatos PPT e PPTX para PDF com notas usando Aspose.Slides para PHP via Java. Preservar layouts e notas do palestrante para apresentações profissionais."
---
## **Visão geral**

Neste artigo, você aprenderá como converter apresentações do PowerPoint para o formato PDF com anotações do palestrante usando Aspose.Slides. Este guia abordará as etapas necessárias e fornecerá exemplos de código para ajudá‑lo a realizar essa tarefa de forma eficiente. Ao final deste artigo, você será capaz de:

- Implementar o processo de conversão para transformar slides do PowerPoint em documentos PDF preservando as anotações do palestrante.
- Personalizar o PDF de saída para garantir que as anotações do palestrante sejam incluídas e formatadas de acordo com seus requisitos.

Para definir as dimensões e a orientação da página de notas antes da exportação, veja [Tamanho da página de notas](/slides/pt/php-java/notes-size/).

## **Converter PowerPoint para PDF com Notas**

O método `save` na classe [Presentation](https://reference.aspose.com/slides/pt/php-java/aspose.slides/presentation/) pode ser usado para converter uma apresentação PPT ou PPTX em um PDF com anotações do palestrante. Com Aspose.Slides, basta carregar a apresentação, configurar as opções de layout usando a classe [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/pt/php-java/aspose.slides/notescommentslayoutingoptions/) para incluir as anotações do palestrante e, em seguida, salvar o arquivo como PDF. O trecho de código a seguir demonstra como converter uma apresentação de exemplo para PDF na visualização de Slides de Notas.

```php
$presentation = new Presentation("sample.pptx");

// Configurar opções de PDF para renderizar notas do palestrante.
$notesOptions = new NotesCommentsLayoutingOptions();
$notesOptions->setNotesPosition(NotesPositions::BottomFull); // Renderizar notas do palestrante abaixo do slide.

$pdfOptions = new PdfOptions();
$pdfOptions->setSlidesLayoutOptions($notesOptions);

// Salvar a apresentação em PDF com notas do palestrante.
$presentation->save("output.pdf", SaveFormat::Pdf, $pdfOptions);
$presentation->dispose();
```

{{% alert color="info" title="Observação" %}}

Você pode querer conferir o Conversor Online de PowerPoint para PDF da Aspose [Online PowerPoint to PDF Converter](https://products.aspose.app/slides/pt/conversion).

{{% /alert %}}