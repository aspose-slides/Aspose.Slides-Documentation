---
title: Converti PPT e PPTX in PDF su Android [Funzionalità Avanzate Incluse]
linktitle: PowerPoint in PDF
type: docs
weight: 40
url: /it/androidjava/convert-powerpoint-to-pdf/
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
- Android
- Java
- Aspose.Slides
description: "Converti PowerPoint PPT/PPTX in PDF di alta qualità e ricercabili in Java usando Aspose.Slides per Android, con esempi di codice rapidi e opzioni di conversione avanzate."
---
## **Panoramica**

Convertire le presentazioni PowerPoint (PPT, PPTX, ODP, ecc.) in formato PDF su Android offre diversi vantaggi, tra cui la compatibilità tra diversi dispositivi e la conservazione del layout e della formattazione della tua presentazione. Questa guida dimostra come convertire le presentazioni in documenti PDF, utilizzare varie opzioni per controllare la qualità delle immagini, includere diapositive nascoste, proteggere con password i file PDF, rilevare le sostituzioni dei caratteri, selezionare diapositive specifiche per la conversione e applicare standard di conformità ai documenti di output.

## **Conversioni da PowerPoint a PDF**

Utilizzando Aspose.Slides, è possibile convertire le presentazioni nei seguenti formati in PDF:

* **PPT**
* **PPTX**
* **ODP**

Per convertire una presentazione in PDF, passa il nome del file come argomento alla classe [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) e poi salva la presentazione come PDF usando il metodo [save](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-). La classe [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) espone il metodo [save](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-) tipicamente usato per convertire una presentazione in PDF.

{{% alert color="info" title="Note" %}}

Aspose.Slides for Android via Java inserisce le informazioni della sua API e il numero di versione nei documenti di output. Ad esempio, durante la conversione di una presentazione in PDF, Aspose.Slides popola il campo Application con "*Aspose.Slides*" e il campo PDF Producer con un valore nella forma "*Aspose.Slides v XX.XX*". **Nota** che non è possibile istruire Aspose.Slides a modificare o rimuovere queste informazioni dai documenti di output.

{{% /alert %}}

Aspose.Slides consente di convertire:

* Intere presentazioni in PDF
* Diapositive specifiche di una presentazione in PDF

Aspose.Slides esporta le presentazioni in PDF, garantendo che i PDF risultanti corrispondano fedelmente alle presentazioni originali. Elementi e attributi vengono renderizzati accuratamente durante la conversione, inclusi:

* Immagini
* Caselle di testo e forme
* Formattazione del testo
* Formattazione dei paragrafi
* Collegamenti ipertestuali
* Intestazioni e piè di pagina
* Elenchi puntati
* Tabelle

## **Converti PowerPoint in PDF**

Il processo standard di conversione da PowerPoint a PDF utilizza le opzioni predefinite. In questo caso, Aspose.Slides tenta di convertire la presentazione fornita in PDF utilizzando impostazioni ottimali ai massimi livelli di qualità.

L'esempio seguente carica una presentazione e salva tutte le diapositive visibili in PDF usando le impostazioni di esportazione predefinite.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("PowerPoint.ppt");
try {
    presentation.save("PPT-to-PDF.pdf", SaveFormat.Pdf);
} finally {
    presentation.dispose();
}
```

{{% alert color="info" title="Note" %}}

Aspose offre un gratuito [**Convertitore PowerPoint in PDF**](https://products.aspose.app/slides/conversion/ppt-to-pdf) online che dimostra il processo di conversione da presentazione a PDF. Puoi eseguire un test con questo convertitore per vedere un'implementazione reale della procedura descritta qui.

{{% /alert %}}

## **Converti PowerPoint in PDF con Opzioni**

Aspose.Slides fornisce opzioni personalizzate—proprietà della classe [PdfOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/)—che consentono di personalizzare il PDF risultante, bloccarlo con una password o specificare come deve procedere il processo di conversione.

### **Converti PowerPoint in PDF con Opzioni Personalizzate**

Utilizzando opzioni di conversione personalizzate, è possibile definire le impostazioni di qualità preferite per le immagini raster, specificare come gestire i metafile, impostare un livello di compressione per il testo, configurare i DPI per le immagini e altro ancora.

L'esempio seguente esporta una presentazione in PDF 1.5 con qualità JPEG impostata al 90, risoluzione dell'immagine a 300 DPI, metafile salvati come PNG e compressione testo Flate.

```java
import com.aspose.slides.*;

PdfOptions pdfOptions = new PdfOptions();
pdfOptions.setJpegQuality((byte)90);
pdfOptions.setSufficientResolution(300);
pdfOptions.setSaveMetafilesAsPng(true);
pdfOptions.setTextCompression(PdfTextCompression.Flate);
pdfOptions.setCompliance(PdfCompliance.Pdf15);

Presentation presentation = new Presentation("PowerPoint.pptx");

try {
    presentation.save("PowerPoint-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

### **Conserva i File OLE Incorporati come Allegati PDF**

Se una presentazione contiene un foglio di lavoro Excel incorporato, potresti voler consentire ai destinatari del PDF di accedere ai dati del foglio oltre a visualizzare le diapositive. Chiama [setIncludeOleData](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/#setIncludeOleData-boolean-) con `true` per conservare i file OLE incorporati come allegati nel PDF risultante.

Il valore predefinito è `false`: l'immagine di anteprima o l'icona dell'oggetto OLE viene renderizzata nella pagina PDF, ma il file incorporato non è incluso come allegato. Impostando l'opzione su `true` viene inoltre incluso il file. L'anteprima rimane una rappresentazione visiva; l'allegato consente ai destinatari di aprire o salvare il file incorporato separatamente. L'oggetto OLE non diventa un foglio di lavoro Excel interattivo nella pagina PDF.

L'esempio seguente carica una presentazione che contiene già un foglio di lavoro Excel incorporato ed esporta il PDF con il foglio allegato.

```java
import com.aspose.slides.*;

PdfOptions pdfOptions = new PdfOptions();
pdfOptions.setIncludeOleData(true);

Presentation presentation = new Presentation("presentation.pptx");
try {
    presentation.save("presentation.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

Per verificare il risultato:

1. Apri il PDF esportato in un visualizzatore che supporti gli allegati, ad esempio Adobe Acrobat Reader.
2. Apri il pannello **Allegati** del visualizzatore e individua il foglio di lavoro incorporato.
3. Salva l'allegato e aprilo in Excel per ispezionarne i dati, oppure aprilo direttamente se il visualizzatore lo consente. L'anteprima nella pagina PDF è separata dall'allegato.

{{% alert color="info" title="Note" %}}

Gli standard PDF/A impongono restrizioni sugli allegati: PDF/A‑1 vieta i file incorporati, PDF/A‑2 consente solo allegati PDF/A, e PDF/A‑3 consente altri tipi di file, inclusi i fogli di lavoro Excel. Si tratta di requisiti degli standard, non di restrizioni specifiche di Aspose.Slides. Questo esempio utilizza l'impostazione di conformità PDF predefinita e non dimostra l'esportazione PDF/A.

{{% /alert %}}

### **Converti PowerPoint in PDF con Diapositive Nascoste**

Se una presentazione contiene diapositive nascoste, puoi usare il metodo [setShowHiddenSlides](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/#setShowHiddenSlides-boolean-) della classe [PdfOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/) per includere le diapositive nascoste come pagine nel PDF risultante.

L'esempio seguente esporta una presentazione in PDF, includendo eventuali diapositive nascoste.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("PowerPoint.pptx");
try {
    PdfOptions pdfOptions = new PdfOptions();
    pdfOptions.setShowHiddenSlides(true);

    presentation.save("PowerPoint-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

### **Converti PowerPoint in un PDF Protetto da Password**

L'esempio seguente esporta una presentazione in un PDF che richiede la password `password` per l'apertura. Le autorizzazioni di accesso consentono la stampa, inclusa la stampa ad alta qualità.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("PowerPoint.pptx");
try {
    PdfOptions pdfOptions = new PdfOptions();
    pdfOptions.setPassword("password");
    pdfOptions.setAccessPermissions(PdfAccessPermissions.PrintDocument | PdfAccessPermissions.HighQualityPrint);

    presentation.save("PPTX-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

### **Rileva le Sostituzioni dei Caratteri**

Aspose.Slides fornisce il metodo [setWarningCallback](https://reference.aspose.com/slides/androidjava/com.aspose.slides/saveoptions/#setWarningCallback-com.aspose.slides.IWarningCallback-) nella classe [PdfOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/) che permette di rilevare le sostituzioni dei caratteri durante il processo di conversione da presentazione a PDF.

L'esempio seguente esporta una presentazione in PDF e stampa gli avvisi di sostituzione dei caratteri nella console. Un avviso viene stampato solo quando un carattere non disponibile viene sostituito durante l'esportazione.

```java
import com.aspose.slides.*;

class FontSubstitutionHandler implements IWarningCallback {
    public int warning(IWarningInfo warning) {
        if (warning.getWarningType() == WarningType.DataLoss && warning.getDescription().startsWith("Font will be substituted")) {
            System.out.println("Font substitution warning: " + warning.getDescription());
        }
        return ReturnAction.Continue;
    }
}

PdfOptions pdfOptions = new PdfOptions();
pdfOptions.setWarningCallback(new FontSubstitutionHandler());

Presentation presentation = new Presentation("sample.pptx");
try {
    presentation.save("output.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

{{% alert color="info" title="Note" %}}

Per ulteriori informazioni sulla sostituzione dei caratteri, consulta l'articolo [Sostituzione dei caratteri](/slides/it/androidjava/font-substitution/).

{{% /alert %}} 

### **Gestisci i Caratteri senza una Variante Grassetto Dedicata**

Una presentazione può applicare la formattazione grassetto a del testo anche quando il suo carattere non dispone di una variante grassetto dedicata. Il testo può comunque apparire in grassetto tramite un grassetto sintetico, che ispessisce artificialmente i glifi regolari. Quando quel testo appare troppo pesante o differisce dall'aspetto previsto nel PDF, prova a chiamare [PdfOptions.setRasterizeUnsupportedFontStyles](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/#setRasterizeUnsupportedFontStyles-boolean-) con `true`. Questa opzione rende il testo interessato come bitmap durante l'esportazione PDF e può migliorarne l'aspetto per alcuni caratteri. Il valore predefinito è `false`.

La presentazione di esempio contiene due caselle di testo: una con testo normale e una con formattazione grassetto applicata allo stesso carattere, che non ha una variante grassetto dedicata. L'esempio seguente carica la presentazione, abilita la rasterizzazione degli stili di carattere non supportati e la esporta in PDF:

```java
import com.aspose.slides.PdfOptions;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

PdfOptions pdfOptions = new PdfOptions();
pdfOptions.setRasterizeUnsupportedFontStyles(true);

Presentation presentation = new Presentation("unsupported-bold.pptx");
try {
    presentation.save("rasterized.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

Le anteprime seguenti mostrano rispettivamente l'output con l'opzione disabilitata e abilitata. In questo esempio, il testo in grassetto presenta tratti più pesanti con l'opzione disabilitata. Con l'opzione abilitata, i tratti sono più leggeri; il testo normale rimane invariato. Confronta i risultati prima di scegliere l'impostazione per la tua presentazione.

| Opzione disabilitata (`false`, il valore predefinito) | Opzione abilitata (`true`) |
|---|---|
| ![PDF con rasterizzazione di stile di carattere non supportato disabilitata](unsupported-bold-disabled.png) | ![PDF con rasterizzazione di stile di carattere non supportato abilitata](unsupported-bold-enabled.png) |

In questo esempio, abilitare l'opzione trasforma solo il testo in grassetto in bitmap: non può essere selezionato, copiato o ricercato come testo senza OCR, e i suoi bordi appaiono più morbidi a zoom 800 %. Il testo normale rimane ricercabile. Con l'opzione disabilitata, entrambe le stringhe rimangono testo.

Questa opzione rasterizza il testo formattato in grassetto quando il carattere non ha una variante grassetto dedicata. [Sostituzione dei caratteri](/slides/it/androidjava/font-substitution/) invece seleziona un altro carattere quando quello originale non è disponibile.

## **Converti Diapositive Selezionate da PowerPoint in PDF**

L'esempio seguente esporta le diapositive 1 e 3 di una presentazione in PDF. I numeri di diapositiva in questo array sono basati su 1, e la presentazione di input deve contenere almeno tre diapositive.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("PowerPoint.pptx");
try {
    int[] slides = { 1, 3 };
    presentation.save("PPTX-to-PDF.pdf", slides, SaveFormat.Pdf);
} finally {
    presentation.dispose();
}
```

## **Converti PowerPoint in PDF con Dimensione Diapositiva Personalizzata**

L'esempio seguente copia la prima diapositiva di una presentazione in una nuova presentazione con dimensione diapositiva di 612 × 792 punti (8,5 × 11 pollici). Scala il contenuto della diapositiva per adattarlo e esporta la singola diapositiva in PDF.

```java
import com.aspose.slides.*;

float slideWidth = 612;
float slideHeight = 792;

Presentation presentation = new Presentation("SelectedSlides.pptx");
Presentation resizedPresentation = new Presentation();

try {
    resizedPresentation.getSlideSize().setSize(slideWidth, slideHeight, SlideSizeScaleType.EnsureFit);

    ISlide slide = presentation.getSlides().get_Item(0);
    resizedPresentation.getSlides().insertClone(0, slide);

    // Rimuovi la diapositiva vuota creata nella nuova presentazione.
    resizedPresentation.getSlides().removeAt(1);

    resizedPresentation.save("PDF_with_custom_slide_size.pdf", SaveFormat.Pdf);
} finally {
    resizedPresentation.dispose();
    presentation.dispose();
}
```

## **Converti PowerPoint in PDF nella Visualizzazione Note Diapositiva**

L'esempio seguente esporta una presentazione in PDF, posizionando le note del relatore di ciascuna diapositiva sotto la diapositiva stessa. Usa una presentazione contenente note del relatore per vedere il risultato.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("SelectedSlides.pptx");
try {
    NotesCommentsLayoutingOptions notesOptions = new NotesCommentsLayoutingOptions();
    notesOptions.setNotesPosition(NotesPositions.BottomFull);

    PdfOptions pdfOptions = new PdfOptions();
    pdfOptions.setSlidesLayoutOptions(notesOptions);

    presentation.save("PDF_with_notes.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

## **Standard di Accessibilità e Conformità per PDF**

Aspose.Slides consente di utilizzare una procedura di conversione che rispetta le [Linee guida per l'accessibilità dei contenuti web (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html). È possibile esportare un documento PowerPoint in PDF adottando uno dei seguenti standard di conformità: **PDF/A1a**, **PDF/A1b** e **PDF/UA**.

Il codice seguente dimostra un processo di conversione da PowerPoint a PDF che produce più PDF in base a diversi standard di conformità:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("pres.pptx");
try {
    PdfOptions pdfOptions = new PdfOptions();

    pdfOptions.setCompliance(PdfCompliance.PdfA1a);
    presentation.save("pres-a1a-compliance.pdf", SaveFormat.Pdf, pdfOptions);

    pdfOptions.setCompliance(PdfCompliance.PdfA1b);
    presentation.save("pres-a1b-compliance.pdf", SaveFormat.Pdf, pdfOptions);

    pdfOptions.setCompliance(PdfCompliance.PdfUa);
    presentation.save("pres-ua-compliance.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

{{% alert color="info" title="Note" %}}

Aspose.Slides supporta le operazioni di conversione PDF, consentendo di convertire file PDF nei formati più diffusi. È possibile eseguire conversioni [PDF a HTML](https://products.aspose.com/slides/java/conversion/pdf-to-html/), [PDF a immagine](https://products.aspose.com/slides/java/conversion/pdf-to-image/), [PDF a JPG](https://products.aspose.com/slides/java/conversion/pdf-to-jpg/) e [PDF a PNG](https://products.aspose.com/slides/java/conversion/pdf-to-png/). Altre operazioni di conversione PDF verso formati specializzati—[PDF a SVG](https://products.aspose.com/slides/java/conversion/pdf-to-svg/), [PDF a TIFF](https://products.aspose.com/slides/java/conversion/pdf-to-tiff/), e [PDF a XML](https://products.aspose.com/slides/java/conversion/pdf-to-xml/)—sono anch'esse supportate.

{{% /alert %}}

> **Nota:** Quando si esporta in PDF/UA, Aspose.Slides tratta grafica complessa come SmartArt, diagrammi e formule come una singola figura. Gli elementi di percorso individuali non vengono preservati come contenuti separati e possono essere contrassegnati come artefatti; il testo alternativo è fornito solo per l'intera figura.

## **FAQ**

**Posso convertire più file PowerPoint in PDF in batch?**

Sì, Aspose.Slides supporta la conversione batch di più file PPT o PPTX in PDF. È possibile iterare sui file e applicare il processo di conversione programmaticamente.

**È possibile proteggere con password il PDF convertito?**

Sì. Usa la classe [PdfOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/) per impostare una password e definire le autorizzazioni di accesso durante il processo di conversione.

**Come includere le diapositive nascoste nel PDF?**

Chiama [setShowHiddenSlides](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/#setShowHiddenSlides-boolean-) con `true` nella classe [PdfOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/) per includere le diapositive nascoste nel PDF risultante.

**Aspose.Slides può mantenere alta la qualità delle immagini nel PDF?**

Sì, è possibile controllare la qualità delle immagini utilizzando metodi come [setJpegQuality](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/#setJpegQuality-byte-) e [setSufficientResolution](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/#setSufficientResolution-float-) nella classe [PdfOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/) per garantire immagini di alta qualità nel PDF.

**Aspose.Slides supporta gli standard di conformità PDF/A?**

Sì, Aspose.Slides consente di esportare PDF conformi a [vari standard](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfcompliance/), inclusi PDF/A1a, PDF/A1b e PDF/UA, assicurando che i documenti soddisfino i requisiti di accessibilità e archiviazione.

## **Risorse Aggiuntive**

- [Documentazione di Aspose.Slides per Android via Java](/slides/it/androidjava/)
- [Riferimento API di Aspose.Slides per Android via Java](https://reference.aspose.com/slides/androidjava/)
- [Convertitori Online Gratuiti di Aspose](https://products.aspose.app/slides/conversion)