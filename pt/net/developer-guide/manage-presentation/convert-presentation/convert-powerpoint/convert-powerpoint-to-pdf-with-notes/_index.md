---
title: Converter apresentações PowerPoint para PDF com notas em .NET
linktitle: PowerPoint para PDF com notas
type: docs
weight: 50
url: /pt/net/convert-powerpoint-to-pdf-with-notes/
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
- .NET
- C#
- Aspose.Slides
description: "Converter formatos PPT e PPTX para PDF com notas usando Aspose.Slides para .NET. Preservar layouts e notas do apresentador para apresentações profissionais."
---
## **Visão geral**

Neste artigo, você aprenderá a converter apresentações PowerPoint para formato PDF com notas do apresentador usando Aspose.Slides. Este guia abordará as etapas necessárias e fornecerá exemplos de código para ajudá‑lo a concluir essa tarefa de forma eficiente. Ao final deste artigo, você será capaz de:

- Implementar o processo de conversão para transformar slides do PowerPoint em documentos PDF preservando as notas do apresentador.
- Personalizar o PDF de saída para garantir que as notas do apresentador sejam incluídas e formatadas de acordo com seus requisitos.

## **Converter PowerPoint para PDF com Notas**

O método `Save` na classe [Presentation](https://reference.aspose.com/slides/pt/net/aspose.slides/presentation/) pode ser usado para converter uma apresentação PPT ou PPTX para PDF com notas do apresentador. Com Aspose.Slides, você simplesmente carrega a apresentação, configura as opções de layout usando a classe [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/pt/net/aspose.slides.export/notescommentslayoutingoptions/) para incluir as notas do apresentador e, em seguida, salva o arquivo como PDF. O trecho de código a seguir demonstra como converter uma apresentação de exemplo para PDF na visualização de Slides de Notas.

```cs
using (Presentation presentation = new Presentation("sample.pptx"))
{
    // Configurar opções de PDF para renderizar notas do apresentador.
    PdfOptions pdfOptions = new PdfOptions
    {
        SlidesLayoutOptions = new NotesCommentsLayoutingOptions
        {
            NotesPosition = NotesPositions.BottomFull // Renderizar notas do apresentador abaixo do slide.
        }
    };

    // Salvar a apresentação em PDF com notas do apresentador.
    presentation.Save("output.pdf", SaveFormat.Pdf, pdfOptions);
}
```

{{% alert color="primary" %}} 
Você pode querer conferir o [Conversor Online de PowerPoint para PDF da Aspose](https://products.aspose.app/slides/pt/conversion). 
{{% /alert %}}