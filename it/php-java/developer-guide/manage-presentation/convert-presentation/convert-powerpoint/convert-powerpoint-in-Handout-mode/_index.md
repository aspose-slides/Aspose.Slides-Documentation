---
title: Converti presentazioni PowerPoint in modalità Handout usando PHP
linktitle: Modalità Handout
type: docs
weight: 150
url: /it/php-java/convert-powerpoint-in-handout-mode/
keywords:
- converti PowerPoint
- converti presentazione
- modalità handout
- dispensa
- PPT
- PPTX
- PowerPoint
- presentazione
- PHP
- Aspose.Slides
description: "Converti le presentazioni in dispense in PHP. Imposta le diapositive per pagina, conserva le note, esporta in PDF o immagini con Aspose.Slides per PHP, con codice di esempio. Provalo gratis."
---
## **Introduzione**

Aspose.Slides offre la possibilità di convertire presentazioni in vari formati, inclusa la creazione di dispense per la stampa in modalità Handout. Questa modalità consente di configurare come più diapositive appaiono su una singola pagina, risultando utile per conferenze, seminari e altri eventi. È possibile abilitare questa modalità impostando il metodo `setSlidesLayoutOptions` nelle classi [PdfOptions](https://reference.aspose.com/slides/it/php-java/aspose.slides/pdfoptions/), [RenderingOptions](https://reference.aspose.com/slides/it/php-java/aspose.slides/renderingoptions/), [HtmlOptions](https://reference.aspose.com/slides/it/php-java/aspose.slides/htmloptions/) e [TiffOptions](https://reference.aspose.com/slides/it/php-java/aspose.slides/tiffoptions/).

## **Esportazione in modalità Handout**

Per configurare la modalità Handout, utilizzare l'oggetto [HandoutLayoutingOptions](https://reference.aspose.com/slides/it/php-java/aspose.slides/handoutlayoutingoptions/), che determina quante diapositive vengono collocate su una singola pagina e altri parametri di visualizzazione.

Di seguito è riportato un esempio di codice che mostra come convertire una presentazione in PDF in modalità Handout.

```php
// Carica una presentazione.
$presentation = new Presentation("sample.pptx");

// Set the export options.
$slidesLayoutOptions = new HandoutLayoutingOptions();
$slidesLayoutOptions->setHandout(HandoutType::Handouts4Horizontal);  // 4 diapositive su una pagina in orizzontale
$slidesLayoutOptions->setPrintSlideNumbers(true);                    // stampa i numeri delle diapositive
$slidesLayoutOptions->setPrintFrameSlide(true);                      // stampa una cornice attorno alle diapositive
$slidesLayoutOptions->setPrintComments(false);                       // nessun commento

$pdfOptions = new PdfOptions();
$pdfOptions->setSlidesLayoutOptions($slidesLayoutOptions);

// Export the presentation to PDF with the chosen layout.
$presentation->save("output.pdf", SaveFormat::Pdf, $pdfOptions);
$presentation->dispose();
```

{{% alert color="warning" %}} 
Tieni presente che il metodo `setSlidesLayoutOptions` è disponibile solo per alcuni formati di output, come PDF, HTML, TIFF e durante il rendering come immagini.
{{% /alert %}} 

## **FAQ**

**Qual è il numero massimo di miniature diapositive per pagina in modalità Handout?**

Aspose.Slides supporta i [preset](https://reference.aspose.com/slides/it/php-java/aspose.slides/handouttype/) fino a 9 miniature per pagina con ordinamento orizzontale o verticale: 1, 2, 3, 4 (orizzontale/verticale), 6 (orizzontale/verticale) e 9 (orizzontale/verticale).

**Posso definire una griglia personalizzata, ad esempio 5 o 8 diapositive per pagina?**

No. Il numero e l'ordinamento delle miniature sono controllati strettamente dalla classe [HandoutType](https://reference.aspose.com/slides/it/php-java/aspose.slides/handouttype/); layout arbitrari non sono supportati.

**Posso includere diapositive nascoste nell'output Handout?**

Sì. Abilita le diapositive nascoste utilizzando il metodo `setShowHiddenSlides` nelle impostazioni di esportazione per il formato di destinazione, come [PdfOptions](https://reference.aspose.com/slides/it/php-java/aspose.slides/pdfoptions/), [HtmlOptions](https://reference.aspose.com/slides/it/php-java/aspose.slides/htmloptions/) o [TiffOptions](https://reference.aspose.com/slides/it/php-java/aspose.slides/tiffoptions/).