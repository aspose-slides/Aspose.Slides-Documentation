---
title: Converti PPT e PPTX in PDF con JavaScript [Funzionalità Avanzate Incluse]
linktitle: PowerPoint in PDF
type: docs
weight: 40
url: /it/nodejs-java/convert-powerpoint-to-pdf/
keywords:
- converti PowerPoint
- converti presentazione
- PowerPoint in PDF
- presentazione in PDF
- PPT in PDF
- converti PPT in PDF
- PPTX in PDF
- converti PPTX in PDF
- salva PowerPoint come PDF
- salva PPT come PDF
- salva PPTX come PDF
- esporta PPT in PDF
- esporta PPTX in PDF
- PDF/A1a
- PDF/A1b
- PDF/UA
- Node.js
- JavaScript
- Aspose.Slides
description: "Converti PowerPoint PPT/PPTX in PDF di alta qualità e ricercabili usando Aspose.Slides per Node.js, con esempi di codice rapidi e opzioni di conversione avanzate."
---
## **Panoramica**

Convertire presentazioni PowerPoint e OpenDocument (PPT, PPTX, ODP, ecc.) in formato PDF con JavaScript offre diversi vantaggi, tra cui la compatibilità su diversi dispositivi e la conservazione del layout e della formattazione della presentazione. Questa guida dimostra come convertire le presentazioni in documenti PDF, utilizzare varie opzioni per controllare la qualità delle immagini, includere le diapositive nascoste, proteggere con password i file PDF, rilevare le sostituzioni di caratteri, selezionare diapositive specifiche per la conversione e applicare standard di conformità ai documenti di output.

## **Conversioni da PowerPoint a PDF**

Usando Aspose.Slides, è possibile convertire le presentazioni nei seguenti formati in PDF:

* **PPT**
* **PPTX**
* **ODP**

Per convertire una presentazione in PDF, passa il nome del file come argomento alla classe [Presentation](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/presentation/) quindi salva la presentazione come PDF utilizzando un metodo `save`. La classe [Presentation](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/presentation/) espone il metodo `save` che è tipicamente usato per convertire una presentazione in PDF.

{{%  alert title="Nota"  color="warning"   %}} 

Aspose.Slides per Node.js via Java inserisce le informazioni sull'API e il numero di versione nei documenti di output. Ad esempio, durante la conversione di una presentazione in PDF, Aspose.Slides popola il campo Application con "*Aspose.Slides*" e il campo PDF Producer con un valore nella forma "*Aspose.Slides v XX.XX*". **Nota** che non è possibile istruire Aspose.Slides a modificare o rimuovere queste informazioni dai documenti di output.

{{% /alert %}}

Aspose.Slides consente di convertire:

* Intere presentazioni in PDF
* Diapositive specifiche da una presentazione in PDF

Aspose.Slides esporta le presentazioni in PDF, garantendo che i PDF risultanti corrispondano fedelmente alle presentazioni originali. Gli elementi e gli attributi vengono renderizzati accuratamente nella conversione, inclusi:

* Immagini
* Caselle di testo e forme
* Formattazione del testo
* Formattazione del paragrafo
* Collegamenti ipertestuali
* Intestazioni e piè di pagina
* Elenco puntato
* Tabelle

## **Convertire PowerPoint in PDF**

Il processo standard di conversione da PowerPoint a PDF utilizza le opzioni predefinite. In questo caso, Aspose.Slides tenta di convertire la presentazione fornita in PDF usando impostazioni ottimali ai massimi livelli di qualità.

Questo codice mostra come convertire una presentazione (PPT, PPTX, ODP, ecc.) in PDF:

```js
// Istanzia la classe Presentation che rappresenta un file PowerPoint o OpenDocument.
let presentation = new aspose.slides.Presentation("PowerPoint.ppt");
try {
    // Salva la presentazione come PDF.
    presentation.save("PPT-to-PDF.pdf", aspose.slides.SaveFormat.Pdf);
} finally {
    presentation.dispose();
}
```

{{%  alert  color="primary"  %}} 

Aspose offre un **convertitore gratuito online PowerPoint in PDF** che dimostra il processo di conversione da presentazione a PDF. Puoi eseguire un test con questo convertitore per una dimostrazione live della procedura descritta qui.

{{% /alert %}}

## **Convertire PowerPoint in PDF con Opzioni**

Aspose.Slides fornisce opzioni personalizzate — proprietà della classe [PdfOptions](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/pdfoptions/) — che consentono di personalizzare il PDF risultante, bloccare il PDF con una password o specificare come deve procedere il processo di conversione.

### **Convertire PowerPoint in PDF con Opzioni Personalizzate**

Utilizzando opzioni di conversione personalizzate, è possibile definire le impostazioni di qualità preferite per le immagini raster, specificare come gestire i metafile, impostare un livello di compressione per il testo, configurare DPI per le immagini e altro.

L'esempio di codice seguente dimostra come convertire una presentazione PowerPoint in PDF con diverse opzioni personalizzate.

```js
// Istanzia la classe PdfOptions.
let pdfOptions = new aspose.slides.PdfOptions();

// Imposta la qualità per le immagini JPG.
pdfOptions.setJpegQuality(java.newByte(90));

// Imposta DPI per le immagini.
pdfOptions.setSufficientResolution(300);

// Imposta il comportamento per i metafile.
pdfOptions.setSaveMetafilesAsPng(true);

// Imposta il livello di compressione del testo per i contenuti testuali.
pdfOptions.setTextCompression(aspose.slides.PdfTextCompression.Flate);

// Definisci la modalità di conformità PDF.
pdfOptions.setCompliance(aspose.slides.PdfCompliance.Pdf15);

// Istanzia la classe Presentation che rappresenta un file PowerPoint o OpenDocument.
let presentation = new aspose.slides.Presentation("PowerPoint.pptx");
try {
    // Salva la presentazione come documento PDF.
    presentation.save("PowerPoint-to-PDF.pdf", aspose.slides.SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

### **Convertire PowerPoint in PDF con Diapositive Nascoste**

Se una presentazione contiene diapositive nascoste, è possibile utilizzare il metodo [setShowHiddenSlides](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/PdfOptions#setShowHiddenSlides) della classe [PdfOptions](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/PdfOptions) per includere le diapositive nascoste come pagine nel PDF risultante.

Questo codice JavaScript mostra come convertire una presentazione PowerPoint in PDF includendo le diapositive nascoste:

```js
// Istanzia la classe Presentation che rappresenta un file PowerPoint o OpenDocument.
let presentation = new aspose.slides.Presentation("PowerPoint.pptx");
try {
    // Istanzia la classe PdfOptions.
    let pdfOptions = new aspose.slides.PdfOptions();

    // Aggiungi diapositive nascoste.
    pdfOptions.setShowHiddenSlides(true);

    // Salva la presentazione come PDF.
    presentation.save("PowerPoint-to-PDF.pdf", aspose.slides.SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

### **Convertire PowerPoint in PDF Protetto da Password**

Questo codice JavaScript dimostra come convertire una presentazione PowerPoint in un PDF protetto da password utilizzando i parametri di protezione della classe [PdfOptions](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/PdfOptions):

```js
// Istanzia la classe Presentation che rappresenta un file PowerPoint o OpenDocument.
let presentation = new aspose.slides.Presentation("PowerPoint.pptx");
try {
    // Istanzia la classe PdfOptions.
    let pdfOptions = new aspose.slides.PdfOptions();

    // Imposta una password PDF e le autorizzazioni di accesso.
    pdfOptions.setPassword("password");
    pdfOptions.setAccessPermissions(aspose.slides.PdfAccessPermissions.PrintDocument | aspose.slides.PdfAccessPermissions.HighQualityPrint);

    // Salva la presentazione come PDF.
    presentation.save("PPTX-to-PDF.pdf", aspose.slides.SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

### **Rilevare Sostituzioni di Font**

Aspose.Slides fornisce il metodo [setWarningCallback](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/saveoptions/#setWarningCallback) nella classe [PdfOptions](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/PdfOptions), consentendo di rilevare le sostituzioni di font durante il processo di conversione da presentazione a PDF.

Questo codice JavaScript mostra come rilevare le sostituzioni di font:

```js
// Imposta la callback di avviso nelle opzioni PDF.
let pdfOptions = new aspose.slides.PdfOptions();
pdfOptions.setWarningCallback(FontSubstitutionHandler);

// Istanzia la classe Presentation che rappresenta un file PowerPoint o OpenDocument.
let presentation = new aspose.slides.Presentation("sample.pptx");

// Salva la presentazione come PDF.
presentation.save("output.pdf", aspose.slides.SaveFormat.Pdf, pdfOptions);
presentation.dispose();
```
```js
const FontSubstitutionHandler = java.newProxy("com.aspose.slides.IWarningCallback", {
	warning: function (warning) {
		if (warning.getWarningType() === aspose.slides.WarningType.DataLoss) {
			console.warn("Font substitution warning: " + warning.getDescription());
		}
		return aspose.slides.ReturnAction.Continue;
	}
});
```

{{%  alert color="primary"  %}} 

Per ulteriori informazioni sulla sostituzione dei font, vedere l'articolo [Sostituzione Font](/slides/it/nodejs-java/font-substitution/).

{{% /alert %}} 

## **Convertire Diapositive Selezionate in PowerPoint in PDF**

Questo codice JavaScript dimostra come convertire solo diapositive specifiche da una presentazione PowerPoint in PDF:

```js
// Istanzia la classe Presentation che rappresenta un file PowerPoint o OpenDocument.
let presentation = new aspose.slides.Presentation("PowerPoint.pptx");
try {
    // Imposta l'array dei numeri delle diapositive.
    let slides = java.newArray("int", [1, 3]);

    // Salva la presentazione come PDF.
    presentation.save("PPTX-to-PDF.pdf", slides, aspose.slides.SaveFormat.Pdf);
} finally {
    presentation.dispose();
}
```

## **Convertire PowerPoint in PDF con Dimensione Diapositiva Personalizzata**

Questo codice JavaScript dimostra come convertire una presentazione PowerPoint in PDF con una dimensione di diapositiva specificata:

```js
const slideWidth = 612;
const slideHeight = 792;

// Istanzia la classe Presentation che rappresenta un file PowerPoint o OpenDocument.
let presentation = new aspose.slides.Presentation("SelectedSlides.pptx");

// Crea una nuova presentazione con una dimensione diapositiva adattata.
let resizedPresentation = new aspose.slides.Presentation();

try {
    // Imposta la dimensione personalizzata della diapositiva.
    resizedPresentation.getSlideSize().setSize(slideWidth, slideHeight, aspose.slides.SlideSizeScaleType.EnsureFit);

    // Clona la prima diapositiva dalla presentazione originale.
    let slide = presentation.getSlides().get_Item(0);
    resizedPresentation.getSlides().insertClone(0, slide);

    // Salva la presentazione ridimensionata in un PDF con note.
    resizedPresentation.save("PDF_with_notes.pdf", aspose.slides.SaveFormat.Pdf);
} finally {
    resizedPresentation.dispose();
    presentation.dispose();
}
```

## **Convertire PowerPoint in PDF in Visualizzazione Note Diapositiva**

Questo codice JavaScript dimostra come convertire una presentazione PowerPoint in PDF includendo le note:

```js
// Istanzia la classe Presentation che rappresenta un file PowerPoint o OpenDocument.
let presentation = new aspose.slides.Presentation("SelectedSlides.pptx");
try {
    // Configura le opzioni PDF con il layout delle note.
    let notesOptions = new aspose.slides.NotesCommentsLayoutingOptions();
    notesOptions.setNotesPosition(aspose.slides.NotesPositions.BottomFull);
    let pdfOptions = new aspose.slides.PdfOptions();
    pdfOptions.setSlidesLayoutOptions(notesOptions);

    // Salva la presentazione in un PDF con le note.
    presentation.save("PDF_with_notes.pdf", aspose.slides.SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

## **Standard di Accessibilità e Conformità per PDF**

Aspose.Slides consente di utilizzare una procedura di conversione che rispetta le [Linee Guida per l'Accessibilità dei Contenuti Web (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html). È possibile esportare un documento PowerPoint in PDF usando uno di questi standard di conformità: **PDF/A1a**, **PDF/A1b** e **PDF/UA**.

Questo codice JavaScript dimostra un processo di conversione da PowerPoint a PDF che produce più PDF in base a diversi standard di conformità:

```js
let presentation = new aspose.slides.Presentation("pres.pptx");
try {
    let pdfOptions = new aspose.slides.PdfOptions();
    pdfOptions.setCompliance(aspose.slides.PdfCompliance.PdfA1a);
    presentation.save("pres-a1a-compliance.pdf", aspose.slides.SaveFormat.Pdf, pdfOptions);
    pdfOptions.setCompliance(aspose.slides.PdfCompliance.PdfA1b);
    presentation.save("pres-a1b-compliance.pdf", aspose.slides.SaveFormat.Pdf, pdfOptions);
    pdfOptions.setCompliance(aspose.slides.PdfCompliance.PdfUa);
    presentation.save("pres-ua-compliance.pdf", aspose.slides.SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

{{% alert title="Nota" color="warning" %}} 

Aspose.Slides supporta le operazioni di conversione PDF, consentendo di convertire i file PDF in formati di file popolari. È possibile eseguire conversioni da [PDF a HTML](https://products.aspose.com/slides/it/nodejs-java/conversion/pdf-to-html/), da [PDF a JPG](https://products.aspose.com/slides/it/nodejs-java/conversion/pdf-to-jpg/) e da [PDF a PNG](https://products.aspose.com/slides/it/nodejs-java/conversion/pdf-to-png/). Altre operazioni di conversione PDF verso formati specializzati — da [PDF a SVG](https://products.aspose.com/slides/it/nodejs-java/conversion/pdf-to-svg/), da [PDF a TIFF](https://products.aspose.com/slides/it/nodejs-java/conversion/pdf-to-tiff/) — sono anch'esse supportate.

{{% /alert %}}

> **Nota:** Quando si esporta in PDF/UA, Aspose.Slides tratta le grafiche complesse come SmartArt, diagrammi e formule come una singola figura. Gli elementi di percorso individuali non sono conservati come contenuto separato e possono essere contrassegnati come artefatti; il testo alternativo è fornito solo per l'intera figura.

## **FAQ**

**Posso convertire più file PowerPoint in PDF in blocco?**

Sì, Aspose.Slides supporta la conversione batch di più file PPT o PPTX in PDF. È possibile iterare tra i file e applicare il processo di conversione programmaticamente.

**È possibile proteggere con password il PDF convertito?**

Assolutamente. Utilizza la classe [PdfOptions](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/PdfOptions) per impostare una password e definire le autorizzazioni di accesso durante il processo di conversione.

**Come includere le diapositive nascoste nel PDF?**

Utilizza il metodo `setShowHiddenSlides` nella classe [PdfOptions](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/PdfOptions) per includere le diapositive nascoste nel PDF risultante.

**Aspose.Slides può mantenere alta qualità delle immagini nel PDF?**

Sì, è possibile controllare la qualità delle immagini utilizzando metodi come `setJpegQuality` e `setSufficientResolution` nella classe [PdfOptions](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/PdfOptions) per garantire immagini ad alta qualità nel PDF.

**Aspose.Slides supporta gli standard di conformità PDF/A?**

Sì, Aspose.Slides consente di esportare PDF che rispettano vari standard, inclusi PDF/A1a, PDF/A1b e PDF/UA, garantendo che i documenti soddisfino i requisiti di accessibilità e archiviazione.

## **Risorse Aggiuntive**

- [Documentazione Aspose.Slides per Node.js via Java](/slides/it/nodejs-java/)
- [Riferimento API Aspose.Slides per Node.js via Java](https://reference.aspose.com/slides/it/nodejs-java/)
- [Convertitori Online Gratuiti Aspose](https://products.aspose.app/slides/it/conversion)