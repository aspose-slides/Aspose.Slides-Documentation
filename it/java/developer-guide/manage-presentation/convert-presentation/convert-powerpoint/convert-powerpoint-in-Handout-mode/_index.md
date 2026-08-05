---
title: Converti presentazioni PowerPoint in modalità Handout usando Java
linktitle: Modalità Handout
type: docs
weight: 150
url: /it/java/convert-powerpoint-in-handout-mode/
keywords:
- converti PowerPoint
- converti presentazione
- modalità handout
- handout
- PPT
- PPTX
- PowerPoint
- presentazione
- Java
- Aspose.Slides
description: "Converti le presentazioni in handout con Java. Imposta il numero di diapositive per pagina, conserva le note, esporta in PDF o immagini con Aspose.Slides, con esempio di codice Java. Provalo gratuitamente."
---
## **Introduzione**

Aspose.Slides consente di convertire le presentazioni in formati di output che supportano la modalità Handout. In questa modalità, più diapositive sono disposte su una singola pagina, il che è utile per stampare il materiale delle presentazioni per conferenze, seminari ed eventi simili.

La modalità Handout è configurata tramite il metodo `setSlidesLayoutOptions`, disponibile in [IPdfOptions](https://reference.aspose.com/slides/it/java/com.aspose.slides/ipdfoptions/), [IRenderingOptions](https://reference.aspose.com/slides/it/java/com.aspose.slides/irenderingoptions/), [IHtmlOptions](https://reference.aspose.com/slides/it/java/com.aspose.slides/ihtmloptions/) e [ITiffOptions](https://reference.aspose.com/slides/it/java/com.aspose.slides/itiffoptions/). Per definire il layout dell'handout, utilizzare l’oggetto [HandoutLayoutingOptions](https://reference.aspose.com/slides/it/java/com.aspose.slides/handoutlayoutingoptions/).

## **Esportazione in modalità Handout**

Per esportare una presentazione in modalità Handout, impostare il metodo `setSlidesLayoutOptions` per le opzioni di esportazione di destinazione e assegnare un’istanza di [HandoutLayoutingOptions](https://reference.aspose.com/slides/it/java/com.aspose.slides/handoutlayoutingoptions/) che definisce il numero di diapositive per pagina e i relativi parametri di visualizzazione.

Di seguito è mostrato un esempio di codice che illustra come convertire una presentazione in PDF in modalità Handout.

```java
// Carica una presentazione.
Presentation presentation = new Presentation("sample.pptx");
try {
    // Imposta le opzioni di esportazione.
    HandoutLayoutingOptions slidesLayoutOptions = new HandoutLayoutingOptions();
    slidesLayoutOptions.setHandout(HandoutType.Handouts4Horizontal);  // 4 diapositive su una pagina in orizzontale
    slidesLayoutOptions.setPrintSlideNumbers(true);                   // stampa i numeri delle diapositive
    slidesLayoutOptions.setPrintFrameSlide(true);                     // stampa un contorno attorno alle diapositive
    slidesLayoutOptions.setPrintComments(false);                      // nessun commento

    PdfOptions pdfOptions = new PdfOptions();
    pdfOptions.setSlidesLayoutOptions(slidesLayoutOptions);

    // Esporta la presentazione in PDF con il layout scelto.
    presentation.save("output.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    if (presentation != null) presentation.dispose();    
}
```

{{% alert color="warning" %}} 
Tieni presente che il metodo `setSlidesLayoutOptions` è disponibile solo per alcuni formati di output, come PDF, HTML, TIFF e quando si renderizzano immagini.
{{% /alert %}} 

## **FAQ**

**Qual è il numero massimo di miniature di diapositive per pagina in modalità Handout?**

Aspose.Slides supporta [preset](https://reference.aspose.com/slides/it/java/com.aspose.slides/handouttype/) fino a 9 miniature per pagina con ordinamento orizzontale o verticale: 1, 2, 3, 4 (orizzontale/verticale), 6 (orizzontale/verticale) e 9 (orizzontale/verticale).

**Posso definire una griglia personalizzata, ad esempio 5 o 8 diapositive per pagina?**

No. Il numero e l’ordinamento delle miniature sono controllati rigorosamente dalla classe [HandoutType](https://reference.aspose.com/slides/it/java/com.aspose.slides/handouttype/); layout arbitrari non sono supportati.

**Posso includere diapositive nascoste nell'output Handout?**

Sì. Abilita le diapositive nascoste utilizzando il metodo `setShowHiddenSlides` nelle impostazioni di esportazione per il formato di destinazione, ad esempio [PdfOptions](https://reference.aspose.com/slides/it/java/com.aspose.slides/pdfoptions/), [HtmlOptions](https://reference.aspose.com/slides/it/java/com.aspose.slides/htmloptions/) o [TiffOptions](https://reference.aspose.com/slides/it/java/com.aspose.slides/tiffoptions/).