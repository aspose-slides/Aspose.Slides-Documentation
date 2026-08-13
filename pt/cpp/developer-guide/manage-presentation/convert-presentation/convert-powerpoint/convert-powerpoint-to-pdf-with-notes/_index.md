---
title: Converter apresentações do PowerPoint para PDF com anotações em C++
linktitle: PowerPoint para PDF com Anotações
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
- anotações do apresentador
- PDF com anotações
- C++
- Aspose.Slides
description: "Converter formatos PPT e PPTX para PDF com anotações usando Aspose.Slides para C++. Preservar layouts e anotações do apresentador para apresentações profissionais."
---
## **Visão geral**

Neste artigo, você aprenderá como converter apresentações do PowerPoint para o formato PDF com anotações do apresentador usando Aspose.Slides. Este guia cobrirá os passos necessários e fornecerá exemplos de código para ajudá‑lo a realizar essa tarefa de forma eficiente. Ao final deste artigo, você será capaz de:

- Implementar o processo de conversão para transformar slides do PowerPoint em documentos PDF preservando as anotações do apresentador.
- Personalizar o PDF de saída para garantir que as anotações do apresentador sejam incluídas e formatadas de acordo com seus requisitos.

## **Converter PowerPoint para PDF com Anotações**

O método `Save` na classe [Presentation](https://reference.aspose.com/slides/pt/cpp/aspose.slides/presentation/) pode ser usado para converter uma apresentação PPT ou PPTX para PDF com anotações do apresentador. Com Aspose.Slides, basta carregar a apresentação, configurar as opções de layout usando a classe [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/pt/cpp/aspose.slides.export/notescommentslayoutingoptions/) para incluir as anotações do apresentador e, em seguida, salvar o arquivo como PDF. O trecho de código a seguir demonstra como converter uma apresentação de exemplo para PDF na visualização de Slides de Anotações.

```cpp
#include <DOM/Presentation.h>
#include <Export/NotesCommentsLayoutingOptions.h>
#include <Export/NotesPositions.h>
#include <Export/PdfOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"sample.pptx");

// Configure PDF options for rendering speaker notes.
auto notesOptions = MakeObject<NotesCommentsLayoutingOptions>();
notesOptions->set_NotesPosition(NotesPositions::BottomFull); // Renderizar anotações do apresentador abaixo do slide.
    
auto pdfOptions = MakeObject<PdfOptions>();
pdfOptions->set_SlidesLayoutOptions(notesOptions);

// Save the presentation to PDF with speaker notes.
presentation->Save(u"output.pdf", SaveFormat::Pdf, pdfOptions);
```

{{% alert color="info" %}} 
Você pode querer conferir o Conversor Online de PowerPoint para PDF da Aspose[Online PowerPoint to PDF Converter](https://products.aspose.app/slides/pt/conversion). 
{{% /alert %}}