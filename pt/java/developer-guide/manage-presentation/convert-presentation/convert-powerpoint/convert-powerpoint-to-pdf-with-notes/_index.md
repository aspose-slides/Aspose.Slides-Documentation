---
title: Converter apresentações PowerPoint para PDF com notas em Java
linktitle: PowerPoint para PDF com notas
type: docs
weight: 50
url: /pt/java/convert-powerpoint-to-pdf-with-notes/
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
- anotações do apresentador
- PDF com notas
- Java
- Aspose.Slides
description: "Converter formatos PPT e PPTX para PDF com notas usando Aspose.Slides para Java. Preservar layouts e anotações do apresentador para apresentações profissionais."
---
## **Visão geral**

Neste artigo, você aprenderá como converter apresentações do PowerPoint para o formato PDF com anotações do apresentador usando Aspose.Slides. Este guia cobrirá as etapas necessárias e fornecerá exemplos de código para ajudá‑lo a concluir essa tarefa de forma eficiente. Ao final deste artigo, você será capaz de:

- Implementar o processo de conversão para transformar slides do PowerPoint em documentos PDF preservando as anotações do apresentador.
- Personalizar o PDF de saída para garantir que as anotações do apresentador sejam incluídas e formatadas de acordo com seus requisitos.

## **Converter PowerPoint para PDF com notas**

O método `save` na classe [Presentation](https://reference.aspose.com/slides/pt/java/com.aspose.slides/presentation/) pode ser usado para converter uma apresentação PPT ou PPTX para PDF com anotações do apresentador. Com Aspose.Slides, basta carregar a apresentação, configurar as opções de layout usando a classe [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/pt/java/com.aspose.slides/notescommentslayoutingoptions/) para incluir as anotações do apresentador e, em seguida, salvar o arquivo como PDF. O trecho de código a seguir demonstra como converter uma apresentação de exemplo para PDF na visualização de Slides de Notas.

```java
Presentation presentation = new Presentation("sample.pptx");

// Configurar opções de PDF para renderizar notas do apresentador.
NotesCommentsLayoutingOptions notesOptions = new NotesCommentsLayoutingOptions();
notesOptions.setNotesPosition(NotesPositions.BottomFull); // Renderizar notas do apresentador abaixo do slide.

PdfOptions pdfOptions = new PdfOptions();
pdfOptions.setSlidesLayoutOptions(notesOptions);

// Salvar a apresentação em PDF com notas do apresentador.
presentation.save("output.pdf", SaveFormat.Pdf, pdfOptions);
presentation.dispose();
```

{{% alert color="primary" %}} 
Você pode querer conferir o Conversor Online de PowerPoint para PDF da Aspose. 
{{% /alert %}}