---
title: Converter Apresentações PowerPoint para PDF com Notas em JavaScript
linktitle: PowerPoint para PDF com Notas
type: docs
weight: 50
url: /pt/nodejs-java/convert-powerpoint-to-pdf-with-notas/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Converter formatos PPT e PPTX para PDF com notas em JavaScript usando Aspose.Slides para Node.js. Preservar layouts e notas do apresentador para apresentações profissionais."
---
## **Visão geral**

Neste artigo, você aprenderá como converter apresentações do PowerPoint para o formato PDF com notas do apresentador usando Aspose.Slides. Este guia cobrirá as etapas necessárias e fornecerá exemplos de código para ajudá‑lo a concluir esta tarefa de forma eficiente. Ao final deste artigo, você será capaz de:

- Implementar o processo de conversão para transformar slides do PowerPoint em documentos PDF mantendo as notas do apresentador.
- Personalizar o PDF de saída para garantir que as notas do apresentador sejam incluídas e formatadas de acordo com seus requisitos.

Para definir as dimensões e a orientação da página de notas antes da exportação, veja [Tamanho da Página de Notas](/slides/pt/nodejs-java/notes-size/).

## **Converter PowerPoint para PDF com Notas**

O método `save` na classe [Apresentação](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/presentation/) pode ser usado para converter uma apresentação PPT ou PPTX em um PDF com notas do apresentador. Com Aspose.Slides, basta carregar a apresentação, configurar as opções de layout usando a classe [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/notescommentslayoutingoptions/) para incluir as notas do apresentador e então salvar o arquivo como PDF. O trecho de código a seguir demonstra como converter uma apresentação de exemplo para PDF na visualização de Slides com Notas.

```js
const asposeSlides = require("aspose.slides.via.java");

let presentation = new asposeSlides.Presentation("sample.pptx");

// Configurar opções de PDF para renderizar notas do apresentador.
let notesOptions = new asposeSlides.NotesCommentsLayoutingOptions();
notesOptions.setNotesPosition(asposeSlides.NotesPositions.BottomFull); // Renderizar notas do apresentador abaixo do slide.

let pdfOptions = new asposeSlides.PdfOptions();
pdfOptions.setSlidesLayoutOptions(notesOptions);

// Salvar a apresentação em PDF com notas do apresentador.
presentation.save("output.pdf", asposeSlides.SaveFormat.Pdf, pdfOptions);
presentation.dispose();
```

{{% alert color="info" title="Note" %}}
Talvez você queira conferir o Aspose [Conversor Online de PowerPoint para PDF](https://products.aspose.app/slides/pt/conversion).
{{% /alert %}}