---
title: Converter apresentações para PDF com anotações em Python
linktitle: Apresentação para PDF com Anotações
type: docs
weight: 50
url: /pt/python-net/convert-powerpoint-to-pdf-with-notes/
keywords:
- converter PowerPoint
- converter OpenDocument
- converter apresentação
- converter PPT
- converter PPTX
- converter ODP
- PowerPoint para PDF
- OpenDocument para PDF
- apresentação para PDF
- PPT para PDF
- PPTX para PDF
- ODP para PDF
- anotações do apresentador
- PDF com anotações
- Python
- Aspose.Slides
description: "Converter formatos PPT, PPTX e ODP para PDF com anotações usando o Aspose.Slides para Python. Preservar layouts e anotações do apresentador para apresentações profissionais."
---
## **Visão geral**

Neste artigo, você aprenderá como converter apresentações do PowerPoint para o formato PDF com anotações do apresentador usando o Aspose.Slides. Este guia abordará as etapas necessárias e fornecerá exemplos de código para ajudá-lo a concluir esta tarefa com eficiência. Ao final deste artigo, você será capaz de:

- Implementar o processo de conversão para transformar slides do PowerPoint em documentos PDF, preservando as anotações do apresentador.
- Personalizar o PDF de saída para garantir que as anotações do apresentador sejam incluídas e formatadas de acordo com seus requisitos.

## **Converter PowerPoint para PDF com Anotações**

O método `save` na classe [Presentation](https://reference.aspose.com/slides/pt/python-net/aspose.slides/presentation/) pode ser usado para converter uma apresentação PPT ou PPTX em um PDF com anotações do apresentador. Com o Aspose.Slides, você simplesmente carrega a apresentação, configura as opções de layout usando a classe [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/pt/python-net/aspose.slides.export/notescommentslayoutingoptions/) para incluir as anotações do apresentador e, em seguida, salva o arquivo como PDF. O trecho de código a seguir demonstra como converter uma apresentação de exemplo para PDF na visualização de Slides de Anotações.

```py
with slides.Presentation("sample.pptx") as presentation:

    # Configure as opções de PDF para renderizar as anotações do apresentador.
    notes_options = slides.export.NotesCommentsLayoutingOptions()
    notes_options.notes_position = slides.export.NotesPositions.BOTTOM_FULL

    pdf_options = slides.export.PdfOptions()
    pdf_options.slides_layout_options = notes_options

    # Salve a apresentação em PDF com as anotações do apresentador.
    presentation.save("output.pdf", slides.export.SaveFormat.PDF, pdf_options)
```

{{% alert color="primary" %}} 
Talvez você queira conferir o [Conversor Online de PowerPoint para PDF da Aspose](https://products.aspose.app/slides/pt/conversion). 
{{% /alert %}}