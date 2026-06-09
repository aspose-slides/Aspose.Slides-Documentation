---
title: Converter apresentações PowerPoint para PDF com notas em C++
linktitle: PowerPoint para PDF com notas
type: docs
weight: 50
url: /pt/cpp/convert-powerpoint-to-pdf-with-notes/
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
- C++
- Aspose.Slides
description: "Converta formatos PPT e PPTX para PDF com notas usando Aspose.Slides para C++. Preserve layouts e notas do apresentador para apresentações profissionais."
---
## **Visão geral**

Neste artigo, você aprenderá como converter apresentações do PowerPoint para o formato PDF com notas do apresentador usando Aspose.Slides. Este guia abordará as etapas necessárias e fornecerá exemplos de código para ajudá-lo a concluir essa tarefa de forma eficiente. Ao final deste artigo, você será capaz de:

- Implementar o processo de conversão para transformar slides do PowerPoint em documentos PDF mantendo as notas do apresentador.
- Personalizar o PDF de saída para garantir que as notas do apresentador sejam incluídas e formatadas de acordo com seus requisitos.

## **Converter PowerPoint para PDF com notas**

O método `Save` na classe [Presentation](https://reference.aspose.com/slides/pt/cpp/aspose.slides/presentation/) pode ser usado para converter uma apresentação PPT ou PPTX em PDF com notas do apresentador. Com Aspose.Slides, você simplesmente carrega a apresentação, configura as opções de layout usando a classe [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/pt/cpp/aspose.slides.export/notescommentslayoutingoptions/) para incluir as notas do apresentador e, em seguida, salva o arquivo como PDF. O trecho de código a seguir demonstra como converter uma apresentação de exemplo para PDF na visualização de Slides com Notas.

```cpp
auto presentation = MakeObject<Presentation>(u"sample.pptx");

// Configurar opções de PDF para renderizar notas do apresentador.
auto notesOptions = MakeObject<NotesCommentsLayoutingOptions>();
notesOptions->set_NotesPosition(NotesPositions::BottomFull); // Renderizar notas do apresentador abaixo do slide.
    
auto pdfOptions = MakeObject<PdfOptions>();
pdfOptions->set_SlidesLayoutOptions(notesOptions);

// Salvar a apresentação em PDF com notas do apresentador.
presentation->Save(u"output.pdf", SaveFormat::Pdf, pdfOptions);
```

{{% alert color="primary" %}} 

Você pode querer conferir o Conversor Online de PowerPoint para PDF da Aspose [Online PowerPoint to PDF Converter](https://products.aspose.app/slides/pt/conversion). 

{{% /alert %}}