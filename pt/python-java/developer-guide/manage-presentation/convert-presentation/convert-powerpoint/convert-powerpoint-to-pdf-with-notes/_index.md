---
title: Converter Apresentações PowerPoint para PDF com Notas em Python
linktitle: PowerPoint para PDF com Notas
type: docs
weight: 50
url: /pt/python-java/convert-powerpoint-to-pdf-with-notes/
keywords:
- converter PowerPoint
- converter apresentação
- converter PPT
- converter PPTX
- PowerPoint para PDF
- apresentação para PDF
- PPT para PDF
- PPTX para PDF
- salvar apresentação como PDF
- exportar PPT para PDF
- exportar PPTX para PDF
- notas do apresentador
- PDF com notas
- Python
- Java
- Aspose.Slides
description: "Converter apresentações PPT e PPTX para PDF com notas do apresentador usando Aspose.Slides para Python via Java. Configurar a posição das notas e preservar notas longas."
---
## **Visão geral**

Este artigo explica como converter apresentações do PowerPoint para PDF com notas do apresentador usando Aspose.Slides para Python via Java. Você pode incluir notas abaixo de cada slide e permitir que notas longas continuem em páginas adicionais. Para outras configurações de exportação em PDF, veja [Converter PowerPoint para PDF](/slides/pt/python-java/convert-powerpoint-to-pdf/).

Para definir as dimensões e a orientação da página de notas antes da exportação, veja [Tamanho da Página de Notas](/slides/pt/python-java/notes-size/).

## **Converter PowerPoint para PDF com Notas**

Use o método [save](https://reference.aspose.com/slides/pt/python-java/aspose.slides/presentation/#save) da classe [Presentation](https://reference.aspose.com/slides/pt/python-java/aspose.slides/presentation/) para exportar uma apresentação PPT ou PPTX para PDF. Para incluir notas do apresentador, crie um objeto [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/pt/python-java/aspose.slides/notescommentslayoutingoptions/) e configure a posição das notas com seu método [setNotesPosition](https://reference.aspose.com/slides/pt/python-java/aspose.slides/notescommentslayoutingoptions/#setNotesPosition). Atribua esse layout ao [PdfOptions](https://reference.aspose.com/slides/pt/python-java/aspose.slides/pdfoptions/) usando [setSlidesLayoutOptions](https://reference.aspose.com/slides/pt/python-java/aspose.slides/pdfoptions/#setSlidesLayoutOptions).

O exemplo a seguir carrega `sample.pptx` e o exporta para `output.pdf` com notas do apresentador abaixo dos slides:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import NotesCommentsLayoutingOptions, NotesPositions, PdfOptions, Presentation, SaveFormat

presentation = Presentation("sample.pptx")
try:
    # Configure as opções de PDF para renderizar notas do apresentador.
    notes_options = NotesCommentsLayoutingOptions()
    notes_options.setNotesPosition(NotesPositions.BottomFull)

    pdf_options = PdfOptions()
    pdf_options.setSlidesLayoutOptions(notes_options)

    # Salve a apresentação em PDF com notas do apresentador.
    presentation.save("output.pdf", SaveFormat.Pdf, pdf_options)
finally:
    presentation.dispose()
```

{{% alert color="info" title="Note" %}}
Você também pode experimentar o [Conversor Online de PowerPoint para PDF](https://products.aspose.app/slides/pt/conversion).
{{% /alert %}}

## **FAQ**

**Como posso impedir que notas longas do apresentador sejam cortadas?**

Use [NotesPositions.BottomFull](https://reference.aspose.com/slides/pt/python-java/aspose.slides/notespositions/#BottomFull), como no exemplo acima. Essa configuração exibe as notas completas, usando páginas adicionais quando necessário.

**Posso manter cada slide e suas notas em uma única página?**

Use [NotesPositions.BottomTruncated](https://reference.aspose.com/slides/pt/python-java/aspose.slides/notespositions/#BottomTruncated). Essa configuração limita as notas a uma página, podendo truncar notas que não caibam.

**Como exportar slides sem notas do apresentador?**

Omitir a configuração de layout de notas e usar a exportação padrão em PDF descrita em [Converter PowerPoint para PDF](/slides/pt/python-java/convert-powerpoint-to-pdf/).