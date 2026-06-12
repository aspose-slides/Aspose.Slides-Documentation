---
title: Converti presentazioni PowerPoint in modalità Handout su Android
linktitle: Modalità Handout
type: docs
weight: 150
url: /it/androidjava/convert-powerpoint-in-Handout-mode/
keywords:
- converti PowerPoint
- converti presentazione
- modalità handout
- handout
- PPT
- PPTX
- PowerPoint
- presentazione
- Android
- Java
- Aspose.Slides
description: "Converti le presentazioni in dispense in Java. Imposta il numero di diapositive per pagina, conserva le note, esporta in PDF o immagini con Aspose.Slides per Android, con codice di esempio. Provalo gratis."
---
## **Introduzione**

Aspose.Slides fornisce la possibilità di convertire le presentazioni in vari formati, inclusa la creazione di dispense per la stampa in modalità Handout. Questa modalità consente di configurare come più diapositive appaiono su una singola pagina, rendendola utile per conferenze, seminari e altri eventi. È possibile abilitare questa modalità impostando il metodo `setSlidesLayoutOptions` nelle interfacce [IPdfOptions](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ipdfoptions/), [IRenderingOptions](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/irenderingoptions/), [IHtmlOptions](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ihtmloptions/) e [ITiffOptions](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/itiffoptions/).

## **Esportazione in modalità Handout**

Per configurare la modalità Handout, utilizzare l'oggetto [HandoutLayoutingOptions](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/handoutlayoutingoptions/), che determina quante diapositive vengono posizionate su una singola pagina e altri parametri di visualizzazione.

Di seguito è riportato un esempio di codice che mostra come convertire una presentazione in PDF in modalità Handout.

```java
// Carica una presentazione.
Presentation presentation = new Presentation("sample.pptx");
try {
	// Imposta le opzioni di esportazione.
	HandoutLayoutingOptions slidesLayoutOptions = new HandoutLayoutingOptions();
	slidesLayoutOptions.setHandout(HandoutType.Handouts4Horizontal);  // 4 diapositive su una pagina in orizzontale
	slidesLayoutOptions.setPrintSlideNumbers(true);                   // stampa i numeri delle diapositive
	slidesLayoutOptions.setPrintFrameSlide(true);                     // stampa un riquadro attorno alle diapositive
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
Tieni presente che il metodo `setSlidesLayoutOptions` è disponibile solo per alcuni formati di output, come PDF, HTML, TIFF e durante il rendering come immagini.
{{% /alert %}} 

## **FAQ**

**Qual è il numero massimo di miniature diapositive per pagina in modalità Handout?**

Aspose.Slides supporta [preset](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/handouttype/) fino a 9 miniature per pagina con ordinamento orizzontale o verticale: 1, 2, 3, 4 (orizzontale/verticale), 6 (orizzontale/verticale) e 9 (orizzontale/verticale).

**Posso definire una griglia personalizzata, ad esempio 5 o 8 diapositive per pagina?**

No. Il numero e l'ordinamento delle miniature sono controllati rigorosamente dalla classe [HandoutType](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/handouttype/); layout arbitrari non sono supportati.

**Posso includere diapositive nascoste nell'output Handout?**

Sì. Abilita le diapositive nascoste utilizzando il metodo `setShowHiddenSlides` nelle impostazioni di esportazione per il formato di destinazione, come [PdfOptions](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/pdfoptions/), [HtmlOptions](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/htmloptions/) o [TiffOptions](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/tiffoptions/).