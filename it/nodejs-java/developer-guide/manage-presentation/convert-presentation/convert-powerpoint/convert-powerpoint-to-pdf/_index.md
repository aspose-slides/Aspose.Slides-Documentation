---
title: Converti PPT e PPTX in PDF in JavaScript [Funzionalità Avanzate Incluse]
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

La conversione di presentazioni PowerPoint e OpenDocument (PPT, PPTX, ODP, ecc.) in formato PDF con JavaScript offre diversi vantaggi, tra cui la compatibilità su diversi dispositivi e la conservazione del layout e della formattazione della presentazione. Questa guida dimostra come convertire le presentazioni in documenti PDF, utilizzare varie opzioni per controllare la qualità delle immagini, includere le diapositive nascoste, proteggere con password i file PDF, rilevare le sostituzioni dei caratteri, selezionare diapositive specifiche per la conversione e applicare standard di conformità ai documenti di output.

## **Conversioni da PowerPoint a PDF**

Utilizzando Aspose.Slides, è possibile convertire presentazioni nei seguenti formati in PDF:

* **PPT**
* **PPTX**
* **ODP**

Per convertire una presentazione in PDF, passa il nome del file come argomento alla classe [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) e quindi salva la presentazione come PDF utilizzando il metodo [save](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/save/). La classe [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) espone il metodo [save](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/save/) che viene tipicamente utilizzato per convertire una presentazione in PDF.

{{% alert color="info" title="Note" %}}
Aspose.Slides for Node.js via Java inserisce le informazioni sulla propria API e il numero di versione nei documenti di output. Ad esempio, quando si converte una presentazione in PDF, Aspose.Slides popola il campo Application con "*Aspose.Slides*" e il campo PDF Producer con un valore nella forma "*Aspose.Slides v XX.XX*". **Nota** che non è possibile istruirere Aspose.Slides a modificare o rimuovere queste informazioni dai documenti di output.
{{% /alert %}}

Aspose.Slides consente di convertire:

* Intere presentazioni in PDF
* Diapositive specifiche da una presentazione in PDF

Aspose.Slides esporta le presentazioni in PDF, garantendo che i PDF risultanti corrispondano fedelmente alle presentazioni originali. Gli elementi e gli attributi vengono renderizzati con precisione nella conversione, includendo:

* Immagini
* Caselle di testo e forme
* Formattazione del testo
* Formattazione dei paragrafi
* Collegamenti ipertestuali
* Intestazioni e piè di pagina
* Elenchi puntati
* Tabelle

## **Converti PowerPoint in PDF**

Il processo standard di conversione da PowerPoint a PDF utilizza le opzioni predefinite. In questo caso, Aspose.Slides tenta di convertire la presentazione fornita in PDF usando impostazioni ottimali ai massimi livelli di qualità.

Il seguente esempio carica una presentazione e salva tutte le diapositive visibili in PDF utilizzando le impostazioni di esportazione predefinite.

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
Aspose offre un [**convertitore da PowerPoint a PDF**](https://products.aspose.app/slides/conversion/ppt-to-pdf) gratuito online che dimostra il processo di conversione da presentazione a PDF. È possibile eseguire un test con questo convertitore per una implementazione dal vivo della procedura descritta qui.
{{% /alert %}}

## **Converti PowerPoint in PDF con Opzioni**

Aspose.Slides fornisce opzioni personalizzate — proprietà della classe [PdfOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/) — che consentono di personalizzare il PDF risultante, bloccare il PDF con una password o specificare come dovrebbe procedere il processo di conversione.

### **Converti PowerPoint in PDF con Opzioni Personalizzate**

Utilizzando opzioni di conversione personalizzate, è possibile definire l'impostazione di qualità preferita per le immagini raster, specificare come gestire i metafile, impostare un livello di compressione per il testo, configurare i DPI per le immagini e altro.

Il seguente esempio esporta una presentazione in PDF 1.5 con qualità JPEG impostata a 90, risoluzione dell'immagine impostata a 300 DPI, metafile salvati come PNG e compressione del testo Flate.

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

### **Conserva i file OLE incorporati come allegati PDF**

Se una presentazione contiene una cartella di lavoro Excel incorporata, potrebbe essere desiderabile che i destinatari del PDF possano accedere ai dati della cartella di lavoro così come visualizzare le diapositive. Chiama [setIncludeOleData](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/) con `true` per conservare i file OLE incorporati come allegati nel PDF risultante.

Il valore predefinito è `false`: l'immagine di anteprima o l'icona dell'oggetto OLE viene renderizzata nella pagina PDF, ma il file incorporato non è incluso come allegato. Impostare l'opzione su `true` include inoltre i dati del file. L'anteprima rimane una rappresentazione visiva; l'allegato consente ai destinatari di aprire o salvare il file incorporato separatamente. L'oggetto OLE non diventa un foglio di lavoro Excel interattivo nella pagina PDF.

Il seguente esempio carica una presentazione che contiene già una cartella di lavoro Excel incorporata ed esporta in PDF con la cartella di lavoro allegata.

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

1. Apri il PDF esportato in un visualizzatore che supporta gli allegati, ad esempio Adobe Acrobat Reader.
2. Apri il pannello **Allegati** del visualizzatore e individua la cartella di lavoro incorporata.
3. Salva l'allegato e aprilo in Excel per ispezionarne i dati, oppure aprilo direttamente se il visualizzatore lo consente. L'anteprima nella pagina PDF è separata dall'allegato.

{{% alert color="info" title="Note" %}}
Gli standard PDF/A impongono restrizioni sugli allegati: PDF/A-1 vieta i file incorporati, PDF/A-2 consente solo allegati PDF/A, e PDF/A-3 consente altri tipi di file, incluse le cartelle di lavoro Excel. Questi sono requisiti degli standard, non restrizioni specifiche di Aspose.Slides. Questo esempio utilizza l'impostazione di conformità PDF predefinita e non dimostra l'esportazione PDF/A.
{{% /alert %}}

### **Converti PowerPoint in PDF con Diapositive Nascoste**

Se una presentazione contiene diapositive nascoste, è possibile utilizzare il metodo [setShowHiddenSlides](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/setshowhiddenslides/) della classe [PdfOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/) per includere le diapositive nascoste come pagine nel PDF risultante.

Il seguente esempio esporta una presentazione in PDF, inclusi eventuali slide nascosti.

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

### **Converti PowerPoint in un PDF protetto da password**

Il seguente esempio esporta una presentazione in un PDF che richiede la password `password` per l'apertura. Le autorizzazioni di accesso consentono la stampa, inclusa la stampa ad alta qualità.

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

### **Rileva le Sostituzioni dei Font**

Aspose.Slides fornisce il metodo [setWarningCallback](https://reference.aspose.com/slides/nodejs-java/aspose.slides/saveoptions/) nella classe [PdfOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/) per consentire di rilevare le sostituzioni dei font durante il processo di conversione da presentazione a PDF.

Il seguente esempio esporta una presentazione in PDF e stampa gli avvisi di sostituzione dei font nella console. Un avviso viene stampato solo quando un font non disponibile viene sostituito durante l'esportazione.

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
Per ulteriori informazioni sulla sostituzione dei font, vedere l'articolo [Sostituzione Font](/slides/it/nodejs-java/font-substitution/).
{{% /alert %}}

### **Gestisci i Font senza un Carattere Grassetto Dedicato**

Una presentazione può applicare la formattazione grassetto al testo anche se il suo font non ha un carattere grassetto dedicato. Il testo può comunque apparire in grassetto tramite il grassetto sintetico, che ispessisce artificialmente i glifi regolari. Quando tale testo appare troppo pesante o differente dall'aspetto previsto nel PDF, provare a chiamare [PdfOptions.setRasterizeUnsupportedFontStyles](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/) con `true`. Questa opzione renderizza il testo interessato come bitmap durante l'esportazione PDF e può migliorare il suo aspetto per alcuni font. Il valore predefinito è `false`.

La presentazione di esempio contiene due caselle di testo: una con testo normale e una con formattazione grassetto applicata allo stesso font, che non ha un carattere grassetto dedicato. Il seguente esempio carica la presentazione, abilita la rasterizzazione degli stili di font non supportati e la esporta in PDF:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let pdfOptions = new aspose.slides.PdfOptions();
pdfOptions.setRasterizeUnsupportedFontStyles(true);

let presentation = new aspose.slides.Presentation("unsupported-bold.pptx");
try {
    presentation.save("rasterized.pdf", aspose.slides.SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

Le seguenti anteprime mostrano l'output con l'opzione disabilitata e l'output con l'opzione abilitata. In questo esempio, il testo in grassetto ha tratti più spessi con l'opzione disabilitata. Con l'opzione abilitata, i suoi tratti sono più leggeri; il testo normale rimane invariato. Confronta i risultati prima di scegliere l'impostazione per la tua presentazione.

| Opzione disabilitata (`false`, il valore predefinito) | Opzione abilitata (`true`) |
|---|---|
| ![PDF con rasterizzazione dello stile di font non supportato disabilitata](unsupported-bold-disabled.png) | ![PDF con rasterizzazione dello stile di font non supportato abilitata](unsupported-bold-enabled.png) |

In questo esempio, abilitare l'opzione trasforma solo il testo in grassetto in una bitmap: non può essere selezionato, copiato o ricercato come testo senza OCR, e i suoi bordi appaiono più morbidi allo zoom 800%. Il testo normale rimane ricercabile. Con l'opzione disabilitata, entrambe le stringhe rimangono testo.

Questa opzione rasterizza il testo formattato in grassetto quando il suo font non ha un carattere grassetto dedicato. [Sostituzione Font](/slides/it/nodejs-java/font-substitution/) invece seleziona un altro font quando l'originale non è disponibile.

## **Converti Diapositive Selezionate da PowerPoint in PDF**

Il seguente esempio esporta le diapositive 1 e 3 da una presentazione in PDF. I numeri delle diapositive in questo array partono da 1, e la presentazione di input deve contenere almeno tre diapositive.

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

## **Converti PowerPoint in PDF con Dimensioni Diapositiva Personalizzate**

Il seguente esempio copia la prima diapositiva da una presentazione in una nuova presentazione con una dimensione diapositiva di 612 × 792 punti (8,5 × 11 pollici). Scala il contenuto della diapositiva per adattarlo ed esporta la singola diapositiva in PDF.

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

## **Converti PowerPoint in PDF nella Visualizzazione Note Diapositiva**

Il seguente esempio esporta una presentazione in PDF, posizionando le note del relatore di ciascuna diapositiva sotto la diapositiva stessa. Usa una presentazione contenente note del relatore per vedere il risultato.

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

## **Accessibilità e Standard di Conformità per PDF**

Aspose.Slides consente di utilizzare una procedura di conversione che rispetta le [Linee Guida per l'Accessibilità dei Contenuti Web (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html). È possibile esportare un documento PowerPoint in PDF utilizzando uno di questi standard di conformità: **PDF/A1a**, **PDF/A1b** e **PDF/UA**.

Questo codice dimostra un processo di conversione da PowerPoint a PDF che produce più PDF basati su diversi standard di conformità:

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
Aspose.Slides supporta le operazioni di conversione PDF, consentendo di convertire file PDF in formati di file popolari. È possibile eseguire conversioni da [PDF in HTML](https://products.aspose.com/slides/nodejs-java/conversion/pdf-to-html/), da [PDF in JPG](https://products.aspose.com/slides/nodejs-java/conversion/pdf-to-jpg/), e da [PDF in PNG](https://products.aspose.com/slides/nodejs-java/conversion/pdf-to-png/). Altre operazioni di conversione PDF verso formati specializzati — da [PDF in SVG](https://products.aspose.com/slides/nodejs-java/conversion/pdf-to-svg/), da [PDF in TIFF](https://products.aspose.com/slides/nodejs-java/conversion/pdf-to-tiff/) — sono anch'esse supportate.
{{% /alert %}}

> **Nota:** Quando si esporta in PDF/UA, Aspose.Slides tratta le grafiche complesse come SmartArt, grafici e formule come un'unica figura. Gli elementi di percorso individuali non sono conservati come contenuti separati e possono essere contrassegnati come artefatti; il testo alternativo è fornito solo per l'intera figura.

## **Domande frequenti**

**Posso convertire più file PowerPoint in PDF in blocco?**

Sì, Aspose.Slides supporta la conversione batch di più file PPT o PPTX in PDF. È possibile iterare sui propri file e applicare il processo di conversione programmaticamente.

**È possibile proteggere con password il PDF convertito?**

Sì. Utilizza la classe [PdfOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/) per impostare una password e definire le autorizzazioni di accesso durante il processo di conversione.

**Come includo le diapositive nascoste nel PDF?**

Chiama [setShowHiddenSlides](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/setshowhiddenslides/) con `true` nella classe [PdfOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/) per includere le diapositive nascoste nel PDF risultante.

**Aspose.Slides può mantenere alta qualità dell'immagine nel PDF?**

Sì, è possibile controllare la qualità delle immagini utilizzando metodi come [setJpegQuality](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/setjpegquality/) e [setSufficientResolution](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/setsufficientresolution/) nella classe [PdfOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/) per garantire immagini ad alta qualità nel PDF.

**Aspose.Slides supporta gli standard di conformità PDF/A?**

Sì, Aspose.Slides consente di esportare PDF che rispettano [vari standard](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfcompliance/), inclusi PDF/A1a, PDF/A1b e PDF/UA, garantendo che i documenti soddisfino i requisiti di accessibilità e archiviazione.

## **Risorse aggiuntive**

- [Documentazione Aspose.Slides per Node.js via Java](/slides/it/nodejs-java/)
- [Riferimento API Aspose.Slides per Node.js via Java](https://reference.aspose.com/slides/nodejs-java/)
- [Convertitori online gratuiti Aspose](https://products.aspose.app/slides/conversion)