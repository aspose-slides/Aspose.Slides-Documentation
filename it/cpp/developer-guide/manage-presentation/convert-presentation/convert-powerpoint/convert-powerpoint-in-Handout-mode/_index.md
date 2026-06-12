---
title: Converti presentazioni PowerPoint in modalità Handout usando C++
linktitle: Modalità Handout
type: docs
weight: 150
url: /it/cpp/convert-powerpoint-in-Handout-mode/
keywords:
- convertire PowerPoint
- convertire presentazione
- modalità handout
- dispensa
- PPT
- PPTX
- PowerPoint
- presentazione
- C++
- Aspose.Slides
description: "Converti le presentazioni in dispense in C++. Imposta il numero di diapositive per pagina, conserva le note, esporta in PDF o immagini con Aspose.Slides, con codice di esempio. Provalo gratuitamente."
---
## **Introduzione**

Aspose.Slides offre la possibilità di convertire presentazioni in vari formati, inclusa la creazione di dispense per la stampa in modalità Handout. Questa modalità consente di configurare come più diapositive appaiono su una singola pagina, risultando utile per conferenze, seminari e altri eventi. È possibile attivare questa modalità impostando il metodo `set_SlidesLayoutOptions` nelle interfacce [IPdfOptions](https://reference.aspose.com/slides/it/cpp/aspose.slides.export/ipdfoptions/), [IRenderingOptions](https://reference.aspose.com/slides/it/cpp/aspose.slides.export/irenderingoptions/), [IHtmlOptions](https://reference.aspose.com/slides/it/cpp/aspose.slides.export/ihtmloptions/) e [ITiffOptions](https://reference.aspose.com/slides/it/cpp/aspose.slides.export/itiffoptions/).

## **Esportazione in modalità Dispensa**

Per configurare la modalità Handout, utilizzare l'oggetto [HandoutLayoutingOptions](https://reference.aspose.com/slides/it/cpp/aspose.slides.export/handoutlayoutingoptions/), che determina quante diapositive vengono collocate su una singola pagina e altri parametri di visualizzazione.

Di seguito è riportato un esempio di codice che mostra come convertire una presentazione in PDF in modalità Handout.

```cpp
// Carica una presentazione.
auto presentation = MakeObject<Presentation>(u"sample.pptx");

// Set the export options.
auto slidesLayoutOptions = MakeObject<HandoutLayoutingOptions>();
slidesLayoutOptions->set_Handout(HandoutType::Handouts4Horizontal);  // 4 diapositive su una pagina in orizzontale
slidesLayoutOptions->set_PrintSlideNumbers(true);                    // stampa i numeri delle diapositive
slidesLayoutOptions->set_PrintFrameSlide(true);                      // stampa un contorno intorno alle diapositive
slidesLayoutOptions->set_PrintComments(false);                       // nessun commento

auto pdfOptions = MakeObject<PdfOptions>();
pdfOptions->set_SlidesLayoutOptions(slidesLayoutOptions);

// Esporta la presentazione in PDF con il layout scelto.
presentation->Save(u"output.pdf", SaveFormat::Pdf, pdfOptions);
presentation->Dispose();
```

{{% alert color="warning" %}} 
Tenere presente che il metodo `set_SlidesLayoutOptions` è disponibile solo per alcuni formati di output, come PDF, HTML, TIFF, e durante il rendering come immagini.
{{% /alert %}} 

## **FAQ**

**Qual è il numero massimo di miniature di diapositive per pagina nella modalità Handout?**

Aspose.Slides supporta i [preset](https://reference.aspose.com/slides/it/cpp/aspose.slides.export/handouttype/) fino a 9 miniature per pagina con ordine orizzontale o verticale: 1, 2, 3, 4 (orizzontale/verticale), 6 (orizzontale/verticale) e 9 (orizzontale/verticale).

**Posso definire una griglia personalizzata, ad esempio 5 o 8 diapositive per pagina?**

No. Il numero e l'ordine delle miniature sono controllati rigorosamente dall'enumerazione [HandoutType](https://reference.aspose.com/slides/it/cpp/aspose.slides.export/handouttype/); i layout arbitrari non sono supportati.

**Posso includere diapositive nascoste nell'output Handout?**

Sì. Utilizzare il metodo `set_ShowHiddenSlides` nelle impostazioni di esportazione per il formato di destinazione, ad esempio [PdfOptions](https://reference.aspose.com/slides/it/cpp/aspose.slides.export/pdfoptions/), [HtmlOptions](https://reference.aspose.com/slides/it/cpp/aspose.slides.export/htmloptions/) o [TiffOptions](https://reference.aspose.com/slides/it/cpp/aspose.slides.export/tiffoptions/).