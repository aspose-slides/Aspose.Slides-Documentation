---
title: Converti presentazioni PowerPoint in modalità Handout in .NET
linktitle: Modalità Handout
type: docs
weight: 150
url: /it/net/convert-powerpoint-in-handout-mode/
keywords:
- converti PowerPoint
- converti presentazione
- modalità handout
- handout
- PowerPoint
- presentazione
- PPT
- PPTX
- .NET
- C#
- Aspose.Slides
description: "Converti le presentazioni in handout in .NET. Imposta il numero di diapositive per pagina, conserva le note, esporta in PDF o immagini con Aspose.Slides, con codice di esempio C#. Provalo gratis."
---
## **Introduzione**

Aspose.Slides consente di convertire le presentazioni in formati di output che supportano la modalità Handout. In questa modalità, più diapositive sono disposte su una singola pagina, utile per stampare il materiale della presentazione per conferenze, seminari e eventi simili.

La modalità Handout è configurata tramite la proprietà `SlidesLayoutOptions`, disponibile in [IPdfOptions](https://reference.aspose.com/slides/it/net/aspose.slides.export/ipdfoptions/), [IRenderingOptions](https://reference.aspose.com/slides/it/net/aspose.slides.export/irenderingoptions/), [IHtmlOptions](https://reference.aspose.com/slides/it/net/aspose.slides.export/ihtmloptions/), e [ITiffOptions](https://reference.aspose.com/slides/it/net/aspose.slides.export/itiffoptions/). Per definire il layout dell'handout, utilizzare l'oggetto [HandoutLayoutingOptions](https://reference.aspose.com/slides/it/net/aspose.slides.export/handoutlayoutingoptions/).

## **Esportazione in modalità Handout**

Per esportare una presentazione in modalità Handout, impostare la proprietà `SlidesLayoutOptions` per le opzioni di esportazione di destinazione e assegnare un'istanza di [HandoutLayoutingOptions](https://reference.aspose.com/slides/it/net/aspose.slides.export/handoutlayoutingoptions/) che definisce il numero di diapositive per pagina e i parametri di visualizzazione correlati.

Di seguito è riportato un esempio di codice che mostra come convertire una presentazione in PDF in modalità Handout.

```c#
// Carica una presentazione.
using var presentation = new Presentation("sample.pptx");

// Set the export options.
var pdfOptions = new PdfOptions
{
    SlidesLayoutOptions = new HandoutLayoutingOptions
    {
        Handout = HandoutType.Handouts4Horizontal,  // 4 diapositive su una pagina orizzontalmente
        PrintSlideNumbers = true,                   // stampa i numeri delle diapositive
        PrintFrameSlide = true,                     // stampa un contorno intorno alle diapositive
        PrintComments = false                       // nessun commento
    }
};

// Export the presentation to PDF with the chosen layout.
presentation.Save("output.pdf", SaveFormat.Pdf, pdfOptions);
```

{{% alert color="warning" %}} 

Tenere presente che la proprietà `SlidesLayoutOptions` è disponibile solo per alcuni formati di output, come PDF, HTML, TIFF e quando si esegue il rendering come immagini.

{{% /alert %}} 

## **FAQ**

**Qual è il numero massimo di miniature di diapositive per pagina nella modalità Handout?**

Aspose.Slides supporta [preset](https://reference.aspose.com/slides/it/net/aspose.slides.export/handouttype/) fino a 9 miniature per pagina con ordinamento orizzontale o verticale: 1, 2, 3, 4 (orizzontale/verticale), 6 (orizzontale/verticale) e 9 (orizontale/verticale).

**Posso definire una griglia personalizzata, ad esempio 5 o 8 diapositive per pagina?**

No. Il numero e l'ordinamento delle miniature sono controllati rigorosamente dall'enumerazione [HandoutType](https://reference.aspose.com/slides/it/net/aspose.slides.export/handouttype/); i layout arbitrari non sono supportati.

**Posso includere diapositive nascoste nell'output Handout?**

Sì. Attivare l'opzione `ShowHiddenSlides` nelle impostazioni di esportazione per il formato di destinazione, come [PdfOptions](https://reference.aspose.com/slides/it/net/aspose.slides.export/pdfoptions/), [HtmlOptions](https://reference.aspose.com/slides/it/net/aspose.slides.export/htmloptions/), o [TiffOptions](https://reference.aspose.com/slides/it/net/aspose.slides.export/tiffoptions/).