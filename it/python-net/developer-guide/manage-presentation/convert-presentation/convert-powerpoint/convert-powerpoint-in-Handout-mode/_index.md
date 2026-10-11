---
title: Convertire le presentazioni in modalità Handout con Python
linktitle: Modalità Handout
type: docs
weight: 150
url: /it/python-net/convert-powerpoint-in-handout-mode/
keywords:
- converti PowerPoint
- converti presentazione
- modalità handout
- dispensa
- PowerPoint
- presentazione
- PPT
- PPTX
- Python
- Aspose.Slides
description: "Converti le presentazioni in dispense con Python. Imposta diapositive per pagina, conserva le note, esporta in PDF o immagini con Aspose.Slides, con codice di esempio. Provalo gratuitamente."
---
## **Introduzione**

Aspose.Slides offre la possibilità di convertire le presentazioni in vari formati, inclusa la creazione di dispense per la stampa in modalità Handout. Questa modalità consente di configurare come più diapositive appaiono su una singola pagina, risultando utile per conferenze, seminari e altri eventi. È possibile abilitare questa modalità impostando la proprietà `slides_layout_options` nelle classi [PdfOptions](https://reference.aspose.com/slides/it/python-net/aspose.slides.export/pdfoptions/), [RenderingOptions](https://reference.aspose.com/slides/it/python-net/aspose.slides.export/renderingoptions/), [HtmlOptions](https://reference.aspose.com/slides/it/python-net/aspose.slides.export/htmloptions/) e [TiffOptions](https://reference.aspose.com/slides/it/python-net/aspose.slides.export/tiffoptions/).

Per impostare le dimensioni e l’orientamento della pagina della dispensa prima dell’esportazione, vedere [Notes Page Size](/slides/it/python-net/notes-size/).

## **Esportazione in modalità Handout**

Per configurare la modalità Handout, utilizzare l’oggetto [HandoutLayoutingOptions](https://reference.aspose.com/slides/it/python-net/aspose.slides.export/handoutlayoutingoptions/), che determina quante diapositive vengono posizionate su una singola pagina e altri parametri di visualizzazione.

Di seguito è mostrato un esempio di codice che converte una presentazione in PDF in modalità Handout.

```py
import aspose.slides as slides

# Carica una presentazione.
with slides.Presentation("sample.pptx") as presentation:

    # Imposta le opzioni di esportazione.
    slides_layout_options = slides.export.HandoutLayoutingOptions()
    slides_layout_options.handout = slides.export.HandoutType.HANDOUTS_4_HORIZONTAL  # 4 diapositive su una pagina in orizzontale
    slides_layout_options.print_slide_numbers = True                                 # stampa i numeri delle diapositive
    slides_layout_options.print_frame_slide = True                                   # stampa un contorno intorno alle diapositive
    slides_layout_options.print_comments = False                                     # nessun commento

    pdf_options = slides.export.PdfOptions()
    pdf_options.slides_layout_options = slides_layout_options

    # Esporta la presentazione in PDF con il layout scelto.
    presentation.save("output.pdf", slides.export.SaveFormat.PDF, pdf_options)
```

{{% alert color="warning" title="Warning" %}}
Tieni presente che la proprietà `slides_layout_options` è disponibile solo per alcuni formati di output, come PDF, HTML, TIFF e durante il rendering come immagini.
{{% /alert %}} 

## **FAQ**

**Qual è il numero massimo di miniature di diapositive per pagina in modalità Handout?**

Aspose.Slides supporta i [preset](https://reference.aspose.com/slides/it/python-net/aspose.slides.export/handouttype/) fino a 9 miniature per pagina con disposizione orizzontale o verticale: 1, 2, 3, 4 (orizzontale/verticale), 6 (orizzontale/verticale) e 9 (orizzontale/verticale).

**Posso definire una griglia personalizzata, ad esempio 5 o 8 diapositive per pagina?**

No. Il numero e l’ordine delle miniature sono controllati rigorosamente dall’enumerazione [HandoutType](https://reference.aspose.com/slides/it/python-net/aspose.slides.export/handouttype/); layout arbitrari non sono supportati.

**Posso includere diapositive nascoste nell’output Handout?**

Sì. Abilita l’opzione `show_hidden_slides` nelle impostazioni di esportazione per il formato di destinazione, come [PdfOptions](https://reference.aspose.com/slides/it/python-net/aspose.slides.export/pdfoptions/), [HtmlOptions](https://reference.aspose.com/slides/it/python-net/aspose.slides.export/htmloptions/) o [TiffOptions](https://reference.aspose.com/slides/it/python-net/aspose.slides.export/tiffoptions/).