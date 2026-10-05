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
- allegato
- PDF/A1a
- PDF/A1b
- PDF/UA
- Node.js
- JavaScript
- Aspose.Slides
description: "Converti PowerPoint PPT/PPTX in PDF di alta qualità e ricercabili usando Aspose.Slides per Node.js, con esempi di codice rapidi e opzioni di conversione avanzate."
---
## **Panoramica**

Convertire presentazioni PowerPoint e OpenDocument (PPT, PPTX, ODP, ecc.) in formato PDF con JavaScript offre diversi vantaggi, tra cui la compatibilità su dispositivi diversi e la conservazione del layout e della formattazione della presentazione. Questa guida dimostra come convertire le presentazioni in documenti PDF, utilizzare varie opzioni per controllare la qualità delle immagini, includere diapositive nascoste, proteggere con password i file PDF, rilevare le sostituzioni di caratteri, selezionare diapositive specifiche per la conversione e applicare standard di conformità ai documenti di output.

## **Conversioni da PowerPoint a PDF**

Utilizzando Aspose.Slides, è possibile convertire le presentazioni nei seguenti formati in PDF:

* **PPT**
* **PPTX**
* **ODP**

Per convertire una presentazione in PDF, passa il nome del file come argomento alla classe [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) e poi salva la presentazione come PDF utilizzando il metodo [save](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/#save). La classe [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) espone il metodo [save](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/#save) solitamente utilizzato per convertire una presentazione in PDF.

{{% alert color="info" title="Note" %}}
Aspose.Slides per Node.js via Java inserisce le informazioni sull'API e il numero di versione nei documenti di output. Ad esempio, durante la conversione di una presentazione in PDF, Aspose.Slides popola il campo Application con "*Aspose.Slides*" e il campo PDF Producer con un valore nella forma "*Aspose.Slides v XX.XX*". **Nota** che non è possibile istruire Aspose.Slides a modificare o rimuovere queste informazioni dai documenti di output.
{{% /alert %}}

Aspose.Slides consente di convertire:

* Intere presentazioni in PDF
* Diapositive specifiche di una presentazione in PDF

Aspose.Slides esporta le presentazioni in PDF, garantendo che i PDF risultanti corrispondano fedelmente alle presentazioni originali. Elementi e attributi vengono renderizzati accuratamente nella conversione, includendo:

* Immagini
* Caselle di testo e forme
* Formattazione del testo
* Formattazione dei paragrafi
* Collegamenti ipertestuali
* Intestazioni e piè di pagina
* Elenco puntato
* Tabelle

## **Convertire PowerPoint in PDF**

Il processo standard di conversione da PowerPoint a PDF utilizza le opzioni predefinite. In questo caso, Aspose.Slides tenta di convertire la presentazione fornita in PDF usando impostazioni ottimali al massimo livello di qualità.

L'esempio seguente carica una presentazione e salva tutte le diapositive visibili in PDF utilizzando le impostazioni di esportazione predefinite.

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation("PowerPoint.ppt");
try {
    presentation.save("PPT-to-PDF.pdf", aspose.slides.SaveFormat.Pdf);
} finally {
    presentation.dispose();
}
```

{{% alert color="info" title="Note" %}}
Aspose offre un [**convertitore da PowerPoint a PDF**](https://products.aspose.app/slides/conversion/ppt-to-pdf) gratuito online che dimostra il processo di conversione da presentazione a PDF. È possibile eseguire un test con questo convertitore per una implementazione reale della procedura descritta qui.
{{% /alert %}}

## **Convertire PowerPoint in PDF con Opzioni**

Aspose.Slides fornisce opzioni personalizzate—proprietà nella classe [PdfOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/)—che consentono di personalizzare il PDF risultante, bloccare il PDF con una password o specificare come deve procedere il processo di conversione.

### **Convertire PowerPoint in PDF con Opzioni Personalizzate**

Utilizzando opzioni di conversione personalizzate, è possibile definire l'impostazione di qualità preferita per le immagini raster, specificare come gestire i metafili, impostare un livello di compressione per il testo, configurare DPI per le immagini e molto altro.

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

let pdfOptions = new aspose.slides.PdfOptions();
pdfOptions.setJpegQuality(java.newByte(90));
pdfOptions.setSufficientResolution(300);
pdfOptions.setSaveMetafilesAsPng(true);
pdfOptions.setTextCompression(aspose.slides.PdfTextCompression.Flate);
pdfOptions.setCompliance(aspose.slides.PdfCompliance.Pdf15);

let presentation = new aspose.slides.Presentation("PowerPoint.pptx");
try {
    presentation.save("PowerPoint-to-PDF.pdf", aspose.slides.SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

### **Conservare i File OLE Incorporati come Allegati PDF**

Se una presentazione contiene un foglio di lavoro Excel incorporato, potresti voler consentire ai destinatari del PDF di accedere ai dati del foglio oltre a visualizzare le diapositive. Chiama [setIncludeOleData](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/#setIncludeOleData) con `true` per conservare i file OLE incorporati come allegati nel PDF risultante.

Il valore predefinito è `false`: l'immagine di anteprima o l'icona dell'oggetto OLE viene renderizzata nella pagina PDF, ma il file incorporato non è incluso come allegato. Impostando l'opzione su `true` si includono anche i dati del file. L'anteprima rimane una rappresentazione visiva; l'allegato consente ai destinatari di aprire o salvare il file incorporato separatamente. L'oggetto OLE non diventa un foglio di calcolo Excel interattivo nella pagina PDF.

L'esempio seguente carica una presentazione che contiene già un foglio di lavoro Excel incorporato ed esporta il PDF con il foglio allegato.

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let pdfOptions = new aspose.slides.PdfOptions();
pdfOptions.setIncludeOleData(true);

let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    presentation.save("presentation.pdf", aspose.slides.SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

Per verificare il risultato:

1. Apri il PDF esportato in un visualizzatore che supporta gli allegati, come Adobe Acrobat Reader.
2. Apri il pannello **Allegati** del visualizzatore e individua la cartella di lavoro incorporata.
3. Salva l'allegato e aprilo in Excel per ispezionare i dati, o aprilo direttamente se il visualizzatore lo consente. L'anteprima nella pagina PDF è separata dall'allegato.

{{% alert color="info" title="Note" %}}
Gli standard PDF/A impongono restrizioni sugli allegati: PDF/A-1 proibisce i file incorporati, PDF/A-2 consente solo allegati PDF/A, e PDF/A-3 consente altri tipi di file, inclusi i fogli di lavoro Excel. Queste sono richieste degli standard, non restrizioni specifiche di Aspose.Slides. Questo esempio utilizza l'impostazione predefinita di conformità PDF e non dimostra l'esportazione PDF/A.
{{% /alert %}}

### **Convertire PowerPoint in PDF con Diapositive Nascoste**

Se una presentazione contiene diapositive nascoste, è possibile utilizzare il metodo [setShowHiddenSlides](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/#setShowHiddenSlides) della classe [PdfOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/) per includere le diapositive nascoste come pagine nel PDF risultante.

L'esempio seguente esporta una presentazione in PDF, includendo tutte le diapositive nascoste.

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let pdfOptions = new aspose.slides.PdfOptions();
pdfOptions.setShowHiddenSlides(true);

let presentation = new aspose.slides.Presentation("PowerPoint.pptx");
try {
    presentation.save("PowerPoint-to-PDF.pdf", aspose.slides.SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

### **Convertire PowerPoint in un PDF Protetto da Password**

L'esempio seguente esporta una presentazione in un PDF che richiede la password `password` per l'apertura. Le autorizzazioni di accesso consentono la stampa, inclusa la stampa ad alta qualità.

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let pdfOptions = new aspose.slides.PdfOptions();
pdfOptions.setPassword("password");
pdfOptions.setAccessPermissions(aspose.slides.PdfAccessPermissions.PrintDocument | aspose.slides.PdfAccessPermissions.HighQualityPrint);

let presentation = new aspose.slides.Presentation("PowerPoint.pptx");
try {
    presentation.save("PPTX-to-PDF.pdf", aspose.slides.SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

### **Rilevare le Sostituzioni di Font**

Aspose.Slides fornisce il metodo [setWarningCallback](https://reference.aspose.com/slides/nodejs-java/aspose.slides/saveoptions/#setWarningCallback) nella classe [PdfOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/) che consente di rilevare le sostituzioni di font durante il processo di conversione da presentazione a PDF.

L'esempio seguente esporta una presentazione in PDF e stampa gli avvisi di sostituzione dei font nella console. Un avviso viene stampato solo quando un font non disponibile viene sostituito durante l'esportazione.

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const FontSubstitutionHandler = java.newProxy("com.aspose.slides.IWarningCallback", {
	warning: function (warning) {
		if (warning.getWarningType() === aspose.slides.WarningType.DataLoss && warning.getDescription().startsWith("Font will be substituted")) {
			console.warn("Font substitution warning: " + warning.getDescription());
		}
		return aspose.slides.ReturnAction.Continue;
	}
});

let pdfOptions = new aspose.slides.PdfOptions();
pdfOptions.setWarningCallback(FontSubstitutionHandler);

let presentation = new aspose.slides.Presentation("sample.pptx");
try {
    presentation.save("output.pdf", aspose.slides.SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

{{% alert color="info" title="Note" %}}
Per ulteriori informazioni sulla sostituzione dei font, consulta l'articolo [Sostituzione dei Font](/slides/it/nodejs-java/font-substitution/).
{{% /alert %}} 

## **Convertire Diapositive Selezionate da PowerPoint in PDF**

L'esempio seguente esporta le diapositive 1 e 3 da una presentazione in PDF. I numeri delle diapositive in questo array partono da 1 e la presentazione di input deve contenere almeno tre diapositive.

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

let presentation = new aspose.slides.Presentation("PowerPoint.pptx");
try {
    let slides = java.newArray("int", [1, 3]);
    presentation.save("PPTX-to-PDF.pdf", slides, aspose.slides.SaveFormat.Pdf);
} finally {
    presentation.dispose();
}
```

## **Convertire PowerPoint in PDF con Dimensione Personalizzata della Diapositiva**

L'esempio seguente copia la prima diapositiva da una presentazione in una nuova presentazione con una dimensione diapositiva di 612 × 792 punti (8,5 × 11 pollici). Scala il contenuto della diapositiva per adattarlo e esporta la singola diapositiva in PDF.

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

const slideWidth = 612;
const slideHeight = 792;

let presentation = new aspose.slides.Presentation("SelectedSlides.pptx");
let resizedPresentation = new aspose.slides.Presentation();

try {
    resizedPresentation.getSlideSize().setSize(slideWidth, slideHeight, aspose.slides.SlideSizeScaleType.EnsureFit);
    let slide = presentation.getSlides().get_Item(0);
    resizedPresentation.getSlides().insertClone(0, slide);

    // Rimuovi la diapositiva vuota con cui è stata creata la nuova presentazione.
    resizedPresentation.getSlides().removeAt(1);

    resizedPresentation.save("PDF_with_custom_slide_size.pdf", aspose.slides.SaveFormat.Pdf);
} finally {
    resizedPresentation.dispose();
    presentation.dispose();
}
```

## **Convertire PowerPoint in PDF nella Vista Note della Diapositiva**

L'esempio seguente esporta una presentazione in PDF, posizionando le note del relatore di ciascuna diapositiva sotto la diapositiva stessa. Utilizza una presentazione contenente note del relatore per vedere il risultato.

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let notesOptions = new aspose.slides.NotesCommentsLayoutingOptions();
notesOptions.setNotesPosition(aspose.slides.NotesPositions.BottomFull);

let pdfOptions = new aspose.slides.PdfOptions();
pdfOptions.setSlidesLayoutOptions(notesOptions);

let presentation = new aspose.slides.Presentation("SelectedSlides.pptx");
try {
    presentation.save("PDF_with_notes.pdf", aspose.slides.SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

## **Standard di Accessibilità e Conformità per PDF**

Aspose.Slides consente di utilizzare una procedura di conversione conforme alle [Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html). È possibile esportare un documento PowerPoint in PDF utilizzando uno di questi standard di conformità: **PDF/A1a**, **PDF/A1b** e **PDF/UA**.

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

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

{{% alert color="info" title="Note" %}}
Aspose.Slides supporta le operazioni di conversione PDF, consentendo di convertire file PDF in formati di file popolari. È possibile eseguire conversioni da [PDF in HTML](https://products.aspose.com/slides/nodejs-java/conversion/pdf-to-html/), da [PDF in JPG](https://products.aspose.com/slides/nodejs-java/conversion/pdf-to-jpg/) e da [PDF in PNG](https://products.aspose.com/slides/nodejs-java/conversion/pdf-to-png/). Altre operazioni di conversione PDF verso formati specializzati—[PDF in SVG](https://products.aspose.com/slides/nodejs-java/conversion/pdf-to-svg/), [PDF in TIFF](https://products.aspose.com/slides/nodejs-java/conversion/pdf-to-tiff/)—sono anch'esse supportate.
{{% /alert %}}

> **Nota:** Quando si esporta in PDF/UA, Aspose.Slides tratta grafica complessa come SmartArt, diagrammi e formule come una singola figura. Gli elementi di percorso individuali non sono preservati come contenuto separato e potrebbero essere contrassegnati come artefatti; il testo alternativo è fornito solo per l'intera figura.

## **FAQ**

**Posso convertire più file PowerPoint in PDF in blocco?**

Sì, Aspose.Slides supporta la conversione batch di più file PPT o PPTX in PDF. È possibile iterare sui file e applicare il processo di conversione programmaticamente.

**È possibile proteggere con password il PDF convertito?**

Sì. Usa la classe [PdfOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/) per impostare una password e definire le autorizzazioni di accesso durante il processo di conversione.

**Come includere le diapositive nascoste nel PDF?**

Chiama [setShowHiddenSlides](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/#setShowHiddenSlides) con `true` nella classe [PdfOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/) per includere le diapositive nascoste nel PDF risultante.

**Aspose.Slides può mantenere alta la qualità delle immagini nel PDF?**

Sì, è possibile controllare la qualità delle immagini usando metodi come [setJpegQuality](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/#setJpegQuality) e [setSufficientResolution](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/#setSufficientResolution) nella classe [PdfOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/) per garantire immagini ad alta qualità nel PDF.

**Aspose.Slides supporta gli standard di conformità PDF/A?**

Sì, Aspose.Slides consente di esportare PDF conformi a [vari standard](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfcompliance/), inclusi PDF/A1a, PDF/A1b e PDF/UA, garantendo che i documenti soddisfino i requisiti di accessibilità e archiviazione.

## **Risorse Aggiuntive**

- [Documentazione Aspose.Slides per Node.js via Java](/slides/it/nodejs-java/)
- [Riferimento API Aspose.Slides per Node.js via Java](https://reference.aspose.com/slides/nodejs-java/)
- [Convertitori Online Gratuiti Aspose](https://products.aspose.app/slides/conversion)