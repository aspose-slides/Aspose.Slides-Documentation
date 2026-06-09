---
title: Converter apresentações do PowerPoint para PDF com anotações em JavaScript
linktitle: PowerPoint para PDF com Anotações
type: docs
weight: 50
url: /pt/nodejs-java/convert-powerpoint-to-pdf-with-notes/
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
- PDF com anotações
- Node.js
- JavaScript
- Aspose.Slides
description: "Converter os formatos PPT e PPTX para PDF com anotações em JavaScript usando Aspose.Slides para Node.js. Preservar layouts e anotações do apresentador para apresentações profissionais."
---
## **Visão geral**

Neste artigo, você aprenderá como converter apresentações do PowerPoint para o formato PDF com anotações do apresentador usando o Aspose.Slides. Este guia cobrirá as etapas necessárias e fornecerá exemplos de código para ajudá‑lo a concluir essa tarefa com eficiência. Ao final deste artigo, você será capaz de:

- Implementar o processo de conversão para transformar slides do PowerPoint em documentos PDF, preservando as anotações do apresentador.
- Personalizar o PDF de saída para garantir que as anotações do apresentador sejam incluídas e formatadas de acordo com seus requisitos.

## **Converter PowerPoint para PDF com Anotações**

O método `save` na classe [Presentation](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/presentation/) pode ser usado para converter uma apresentação PPT ou PPTX em um PDF com anotações do apresentador. Com o Aspose.Slides, você simplesmente carrega a apresentação, configura as opções de layout usando a classe [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/notescommentslayoutingoptions/) para incluir as anotações do apresentador e, em seguida, salva o arquivo como PDF. O trecho de código a seguir demonstra como converter uma apresentação de exemplo para PDF na visualização de Slides com Anotações.

```js
let presentation = new asposeSlides.Presentation("sample.pptx");

// Configure as opções de PDF para renderizar as anotações do apresentador.
let notesOptions = new asposeSlides.NotesCommentsLayoutingOptions();
notesOptions.setNotesPosition(asposeSlides.NotesPositions.BottomFull); // Renderiza as anotações do apresentador abaixo do slide.

let pdfOptions = new asposeSlides.PdfOptions();
pdfOptions.setSlidesLayoutOptions(notesOptions);

// Salve a apresentação em PDF com anotações do apresentador.
presentation.save("output.pdf", asposeSlides.SaveFormat.Pdf, pdfOptions);
presentation.dispose();
```

{{% alert color="primary" %}} 
Você pode querer conferir o [Conversor Online de PowerPoint para PDF da Aspose](https://products.aspose.app/slides/pt/conversion). 
{{% /alert %}}