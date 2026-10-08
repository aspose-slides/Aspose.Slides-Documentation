---
title: Converti PPT e PPTX in PDF in Java [Funzionalità Avanzate Incluse]
linktitle: PowerPoint in PDF
type: docs
weight: 40
url: /it/java/convert-powerpoint-to-pdf/
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
- Java
- Aspose.Slides
description: "Converti PowerPoint PPT/PPTX in PDF di alta qualità e ricercabili in Java usando Aspose.Slides, con esempi di codice rapidi e opzioni di conversione avanzate."
---
## **Panoramica**

Convertire presentazioni PowerPoint (PPT, PPTX, ODP, ecc.) in formato PDF in Java offre diversi vantaggi, tra cui la compatibilità su dispositivi diversi e la preservazione del layout e della formattazione della presentazione. Questa guida mostra come convertire le presentazioni in documenti PDF, utilizzare varie opzioni per controllare la qualità delle immagini, includere diapositive nascoste, proteggere i file PDF con password, rilevare le sostituzioni di caratteri, selezionare diapositive specifiche per la conversione e applicare standard di conformità ai documenti di output.

## **Conversioni da PowerPoint a PDF**

Utilizzando Aspose.Slides, è possibile convertire presentazioni nei seguenti formati in PDF:

* **PPT**
* **PPTX**
* **ODP**

Per convertire una presentazione in PDF, passa il nome del file come argomento alla classe [Presentazione](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) e quindi salva la presentazione come PDF usando il metodo [salva](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#save-java.lang.String-int-). La classe [Presentazione](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) espone il metodo [salva](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#save-java.lang.String-int-) tipicamente utilizzato per convertire una presentazione in PDF.

{{% alert color="info" title="Note" %}}

Aspose.Slides per Java inserisce le informazioni sulla propria API e il numero di versione nei documenti di output. Ad esempio, durante la conversione di una presentazione in PDF, Aspose.Slides popola il campo Applicazione con "*Aspose.Slides*" e il campo Produttore PDF con un valore nella forma "*Aspose.Slides v XX.XX*". **Nota** che non è possibile istruire Aspose.Slides a modificare o rimuovere queste informazioni dai documenti di output.

{{% /alert %}}

Aspose.Slides consente di convertire:

* Presentazioni intere in PDF
* Diapositive specifiche da una presentazione in PDF

Aspose.Slides esporta le presentazioni in PDF, garantendo che i PDF risultanti corrispondano strettamente alle presentazioni originali. Gli elementi e gli attributi vengono renderizzati con precisione nella conversione, inclusi:

* Immagini
* Caselle di testo e forme
* Formattazione del testo
* Formattazione dei paragrafi
* Collegamenti ipertestuali
* Intestazioni e piè di pagina
* Elenchi puntati
* Tabelle

## **Converti PowerPoint in PDF**

Il processo di conversione standard da PowerPoint a PDF utilizza le opzioni predefinite. In questo caso, Aspose.Slides tenta di convertire la presentazione fornita in PDF usando impostazioni ottimali al massimo livello di qualità.

L’esempio seguente carica una presentazione e salva tutte le diapositive visibili in PDF usando le impostazioni di esportazione predefinite.

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

Aspose offre un [**convertitore online gratuito da PowerPoint a PDF**](https://products.aspose.app/slides/conversion/ppt-to-pdf) che dimostra il processo di conversione da presentazione a PDF. Puoi eseguire un test con questo convertitore per vedere un’implementazione reale della procedura descritta qui.

{{% /alert %}}

## **Converti PowerPoint in PDF con Opzioni**

Aspose.Slides fornisce opzioni personalizzate—proprietà della classe [PdfOptions](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/)—che consentono di personalizzare il PDF risultante, bloccarlo con una password o specificare come deve procedere il processo di conversione.

### **Converti PowerPoint in PDF con Opzioni Personalizzate**

Utilizzando opzioni di conversione personalizzate, è possibile definire l’impostazione di qualità preferita per le immagini raster, specificare come gestire i metafili, impostare un livello di compressione per il testo, configurare DPI per le immagini e altro ancora.

L’esempio seguente esporta una presentazione in PDF 1.5 con qualità JPEG impostata al 90, risoluzione immagine a 300 DPI, metafili salvati come PNG e compressione testo Flate.

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

Se una presentazione contiene una cartella di lavoro Excel incorporata, potresti volere che i destinatari del PDF accedano ai dati della cartella di lavoro oltre a visualizzare le diapositive. Chiama [setIncludeOleData](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/#setIncludeOleData-boolean-) con `true` per conservare i file OLE incorporati come allegati nel PDF risultante.

Il valore predefinito è `false`: l’immagine di anteprima o l’icona dell’oggetto OLE viene renderizzata nella pagina PDF, ma il file incorporato non è incluso come allegato. Impostare l’opzione su `true` include inoltre i dati del file. L’anteprima rimane una rappresentazione visiva; l’allegato consente ai destinatari di aprire o salvare il file incorporato separatamente. L’oggetto OLE non diventa un foglio di calcolo Excel interattivo nella pagina PDF.

L’esempio seguente carica una presentazione che contiene già una cartella di lavoro Excel incorporata ed esporta il tutto in PDF con la cartella di lavoro allegata.

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
2. Apri il pannello **Allegati** del visualizzatore e individua la cartella di lavoro incorporata.
3. Salva l’allegato e aprilo in Excel per ispezionare i dati, oppure aprilo direttamente se il visualizzatore lo consente. L’anteprima nella pagina PDF è separata dall’allegato.

{{% alert color="info" title="Note" %}}

Gli standard PDF/A impongono restrizioni sugli allegati: PDF/A-1 vieta i file incorporati, PDF/A-2 consente solo allegati PDF/A e PDF/A-3 consente altri tipi di file, incluse cartelle di lavoro Excel. Questi sono requisiti degli standard, non limitazioni specifiche di Aspose.Slides. Questo esempio utilizza l’impostazione di conformità PDF predefinita e non dimostra l’esportazione PDF/A.

{{% /alert %}}

### **Converti PowerPoint in PDF con Diapositive Nascoste**

Se una presentazione contiene diapositive nascoste, è possibile utilizzare il metodo [setShowHiddenSlides](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/#setShowHiddenSlides-boolean-) della classe [PdfOptions](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/) per includere le diapositive nascoste come pagine nel PDF risultante.

L’esempio seguente esporta una presentazione in PDF, includendo eventuali diapositive nascoste.

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

### **Converti PowerPoint in PDF Protetto da Password**

L’esempio seguente esporta una presentazione in PDF che richiede la password `password` per l’apertura. Le autorizzazioni di accesso consentono la stampa, inclusa la stampa di alta qualità.

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

### **Rileva Sostituzioni di Font**

Aspose.Slides fornisce il metodo [setWarningCallback](https://reference.aspose.com/slides/java/com.aspose.slides/saveoptions/#setWarningCallback-com.aspose.slides.IWarningCallback-) della classe [PdfOptions](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/), consentendo di rilevare le sostituzioni di font durante il processo di conversione da presentazione a PDF.

L’esempio seguente esporta una presentazione in PDF e stampa gli avvisi di sostituzione dei font nella console. Un avviso viene stampato solo quando un font non disponibile viene sostituito durante l’esportazione.

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

Per ulteriori informazioni sulla sostituzione dei font, vedi l’articolo [Sostituzione dei Font](/slides/it/java/font-substitution/).

{{% /alert %}} 

### **Gestisci Font senza Variante Grassetto Dedicata**

Una presentazione può applicare la formattazione grassetto a del testo anche quando il suo font non dispone di una variante grassetto dedicata. Il testo può comunque apparire in grassetto tramite “grassetto sintetico”, che ispessisce artificialmente i glifi regolari. Quando quel testo risulta troppo pesante o differisce dall’aspetto desiderato nel PDF, prova a chiamare [PdfOptions.setRasterizeUnsupportedFontStyles](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/#setRasterizeUnsupportedFontStyles-boolean-) con `true`. Questa opzione rende il testo interessato come bitmap durante l’esportazione PDF e può migliorarne l’aspetto per alcuni font. Il valore predefinito è `false`.

La presentazione di esempio contiene due caselle di testo: una con testo normale e una con formattazione grassetto applicata allo stesso font, che non ha una variante grassetto dedicata. L’esempio seguente carica la presentazione, abilita la rasterizzazione degli stili di font non supportati e la esporta in PDF:

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

Le anteprime seguenti mostrano l’output con l’opzione disabilitata e quello con l’opzione abilitata. In questo esempio, il testo in grassetto ha tratti più spessi con l’opzione disabilitata. Con l’opzione abilitata, i suoi tratti sono più leggeri; il testo normale rimane invariato. Confronta i risultati prima di scegliere l’impostazione per la tua presentazione.

| Opzione disabilitata (`false`, predefinita) | Opzione abilitata (`true`) |
|---|---|
| ![PDF con rasterizzazione dello stile di font non supportato disabilitata](unsupported-bold-disabled.png) | ![PDF con rasterizzazione dello stile di font non supportato abilitata](unsupported-bold-enabled.png) |

In questo esempio, l’attivazione dell’opzione trasforma solo il testo in grassetto in bitmap: non può essere selezionato, copiato o ricercato come testo senza OCR, e i suoi bordi appaiono più morbidi allo zoom 800 %. Il testo normale rimane ricercabile. Con l’opzione disabilitata, entrambe le stringhe rimangono testo.

Questa opzione rasterizza il testo formattato in grassetto quando il suo font non ha una variante grassetto dedicata. La [sostituzione dei font](/slides/it/java/font-substitution/) invece seleziona un altro font quando quello originale non è disponibile.

## **Converti Diapositive Selezionate da PowerPoint in PDF**

L’esempio seguente esporta le diapositive 1 e 3 da una presentazione in PDF. I numeri di diapositiva in questo array sono basati su 1, e la presentazione di input deve contenere almeno tre diapositive.

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

L’esempio seguente copia la prima diapositiva da una presentazione in una nuova presentazione con dimensioni diapositiva di 612 × 792 punti (8,5 × 11 pollici). Scala il contenuto della diapositiva per adattarlo ed esporta la singola diapositiva in PDF.

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

    // Rimuovi la diapositiva vuota con cui è stata creata la nuova presentazione.
    resizedPresentation.getSlides().removeAt(1);

    resizedPresentation.save("PDF_with_custom_slide_size.pdf", SaveFormat.Pdf);
} finally {
    resizedPresentation.dispose();
    presentation.dispose();
}
```

## **Converti PowerPoint in PDF nella Visualizzazione Note della Diapositiva**

L’esempio seguente esporta una presentazione in PDF, posizionando le note del relatore di ciascuna diapositiva sotto la diapositiva stessa. Usa una presentazione contenente note del relatore per vedere il risultato.

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

## **Accessibilità e Standard di Conformità per PDF**

Aspose.Slides consente di utilizzare una procedura di conversione che rispetta le [Linee Guida per l’Accessibilità dei Contenuti Web (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html). È possibile esportare un documento PowerPoint in PDF utilizzando uno dei seguenti standard di conformità: **PDF/A1a**, **PDF/A1b** e **PDF/UA**.

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

Aspose.Slides supporta operazioni di conversione PDF, consentendo di convertire file PDF in formati di file popolari. È possibile eseguire conversioni [PDF in HTML](https://products.aspose.com/slides/java/conversion/pdf-to-html/), [PDF in immagine](https://products.aspose.com/slides/java/conversion/pdf-to-image/), [PDF in JPG](https://products.aspose.com/slides/java/conversion/pdf-to-jpg/) e [PDF in PNG](https://products.aspose.com/slides/java/conversion/pdf-to-png/). Altre operazioni di conversione PDF verso formati specializzati—[PDF in SVG](https://products.aspose.com/slides/java/conversion/pdf-to-svg/), [PDF in TIFF](https://products.aspose.com/slides/java/conversion/pdf-to-tiff/), e [PDF in XML](https://products.aspose.com/slides/java/conversion/pdf-to-xml/)—sono anch’esse supportate.

{{% /alert %}}

> **Nota:** Quando si esporta in PDF/UA, Aspose.Slides tratta grafica complessa come SmartArt, grafici e formule come una singola figura. Gli elementi di percorso individuali non vengono conservati come contenuti separati e possono essere contrassegnati come artefatti; il testo alternativo è fornito solo per l’intera figura.

## **FAQ**

**Posso convertire più file PowerPoint in PDF in blocco?**

Sì, Aspose.Slides supporta la conversione batch di più file PPT o PPTX in PDF. È possibile iterare sui file e applicare il processo di conversione programmaticamente.

**È possibile proteggere con password il PDF convertito?**

Sì. Usa la classe [PdfOptions](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/) per impostare una password e definire le autorizzazioni di accesso durante il processo di conversione.

**Come includere le diapositive nascoste nel PDF?**

Chiama [setShowHiddenSlides](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/#setShowHiddenSlides-boolean-) con `true` nella classe [PdfOptions](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/) per includere le diapositive nascoste nel PDF risultante.

**Aspose.Slides può mantenere alta qualità dell’immagine nel PDF?**

Sì, è possibile controllare la qualità dell’immagine usando metodi come [setJpegQuality](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/#setJpegQuality-byte-) e [setSufficientResolution](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/#setSufficientResolution-float-) nella classe [PdfOptions](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/) per garantire immagini di alta qualità nel PDF.

**Aspose.Slides supporta gli standard di conformità PDF/A?**

Sì, Aspose.Slides consente di esportare PDF che rispettano [vari standard](https://reference.aspose.com/slides/java/com.aspose.slides/pdfcompliance/), inclusi PDF/A1a, PDF/A1b e PDF/UA, assicurando che i documenti soddisfino i requisiti di accessibilità e archiviazione.

## **Risorse Aggiuntive**

- [Documentazione Aspose.Slides per Java](/slides/it/java/)
- [Riferimento API Aspose.Slides per Java](https://reference.aspose.com/slides/java/)
- [Convertitori Online Gratuiti Aspose](https://products.aspose.app/slides/conversion)