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
- PDF/A1a
- PDF/A1b
- PDF/UA
- Android
- Java
- Aspose.Slides
description: "Converti PowerPoint PPT/PPTX in PDF di alta qualità, ricercabili in Java usando Aspose.Slides per Android, con esempi di codice veloci e opzioni di conversione avanzate."
---
## **Panoramica**

Convertire le presentazioni PowerPoint (PPT, PPTX, ODP, ecc.) in formato PDF su Android offre diversi vantaggi, tra cui la compatibilità tra dispositivi diversi e la conservazione del layout e della formattazione della presentazione. Questa guida dimostra come convertire le presentazioni in documenti PDF, utilizzare varie opzioni per controllare la qualità delle immagini, includere diapositive nascoste, proteggere con password i file PDF, rilevare sostituzioni di caratteri, selezionare diapositive specifiche per la conversione e applicare standard di conformità ai documenti di output.

## **Conversioni da PowerPoint a PDF**

Utilizzando Aspose.Slides, è possibile convertire le presentazioni nei seguenti formati in PDF:

* **PPT**
* **PPTX**
* **ODP**

Per convertire una presentazione in PDF, passa il nome del file come argomento alla classe [Presentation](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/presentation/) e poi salva la presentazione come PDF usando il metodo `save`. La classe [Presentation](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/presentation/) espone il metodo `save` che è tipicamente usato per convertire una presentazione in PDF.

{{%  alert title="NOTE"  color="warning"   %}} 

Aspose.Slides per Android via Java inserisce le informazioni sull'API e il numero di versione nei documenti di output. Ad esempio, durante la conversione di una presentazione in PDF, Aspose.Slides popola il campo Application con "*Aspose.Slides*" e il campo PDF Producer con un valore nella forma "*Aspose.Slides v XX.XX*". **Nota** che non è possibile istruirе Aspose.Slides a modificare o rimuovere queste informazioni dai documenti di output.

{{% /alert %}}

Aspose.Slides consente di convertire:

* Intere presentazioni in PDF
* Diapositive specifiche da una presentazione in PDF

Aspose.Slides esporta le presentazioni in PDF, garantendo che i PDF risultanti corrispondano fedelmente alle presentazioni originali. Elementi e attributi sono renderizzati accuratamente nella conversione, inclusi:

* Immagini
* Caselle di testo e forme
* Formattazione del testo
* Formattazione dei paragrafi
* Collegamenti ipertestuali
* Intestazioni e piè di pagina
* Elenchi puntati
* Tabelle

## **Converti PowerPoint in PDF**

Il processo standard di conversione da PowerPoint a PDF utilizza le opzioni predefinite. In questo caso, Aspose.Slides tenta di convertire la presentazione fornita in PDF usando impostazioni ottimali al livello massimo di qualità.

Questo codice mostra come convertire una presentazione (PPT, PPTX, ODP, ecc.) in PDF:

```java
import com.aspose.slides.*;

// Istanzia la classe Presentation che rappresenta un file PowerPoint o OpenDocument.
Presentation presentation = new Presentation("PowerPoint.ppt");
try {
    // Salva la presentazione come PDF.
    presentation.save("PPT-to-PDF.pdf", SaveFormat.Pdf);
} finally {
    presentation.dispose();
}
```

{{%  alert  color="info"  %}} 

Aspose offre un gratuito [**convertitore PowerPoint in PDF**](https://products.aspose.app/slides/it/conversion/ppt-to-pdf) online che dimostra il processo di conversione da presentazione a PDF. Puoi eseguire un test con questo convertitore per una implementazione live della procedura descritta qui.

{{% /alert %}}

## **Converti PowerPoint in PDF con Opzioni**

Aspose.Slides fornisce opzioni personalizzate — proprietà nella classe [PdfOptions](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/pdfoptions/) — che consentono di personalizzare il PDF risultante, bloccare il PDF con una password o specificare come deve procedere il processo di conversione.

### **Converti PowerPoint in PDF con Opzioni Personalizzate**

Utilizzando opzioni di conversione personalizzate, è possibile definire le impostazioni di qualità preferite per le immagini raster, specificare come gestire i metafile, impostare un livello di compressione per il testo, configurare i DPI per le immagini e altro ancora.

Il codice di esempio sottostante dimostra come convertire una presentazione PowerPoint in PDF con diverse opzioni personalizzate.

```java
import com.aspose.slides.*;

// Istanzia la classe PdfOptions.
PdfOptions pdfOptions = new PdfOptions();

// Imposta la qualità per le immagini JPG.
pdfOptions.setJpegQuality((byte)90);

// Imposta i DPI per le immagini.
pdfOptions.setSufficientResolution(300);

/// Imposta il comportamento per i metafili.
pdfOptions.setSaveMetafilesAsPng(true);

// Imposta il livello di compressione del testo per il contenuto testuale.
pdfOptions.setTextCompression(PdfTextCompression.Flate);

// Definisci la modalità di conformità PDF.
pdfOptions.setCompliance(PdfCompliance.Pdf15);

// Istanzia la classe Presentation che rappresenta un file PowerPoint o OpenDocument.
Presentation presentation = new Presentation("PowerPoint.pptx");
try {
    // Salva la presentazione come documento PDF.
    presentation.save("PowerPoint-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

### **Converti PowerPoint in PDF con Diapositive Nascoste**

Se una presentazione contiene diapositive nascoste, puoi usare il metodo [setShowHiddenSlides](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/pdfoptions/#setShowHiddenSlides-boolean-) della classe [PdfOptions](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/pdfoptions/) per includere le diapositive nascoste come pagine nel PDF risultante.

Questo codice mostra come convertire una presentazione PowerPoint in PDF includendo le diapositive nascoste:

```java
import com.aspose.slides.*;

// Istanzia la classe Presentation che rappresenta un file PowerPoint o OpenDocument.
Presentation presentation = new Presentation("PowerPoint.pptx");
try {
    // Istanzia la classe PdfOptions.
    PdfOptions pdfOptions = new PdfOptions();

    // Aggiungi diapositive nascoste.
    pdfOptions.setShowHiddenSlides(true);

    // Salva la presentazione come PDF.
    presentation.save("PowerPoint-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

### **Converti PowerPoint in PDF Protetto da Password**

Questo codice dimostra come convertire una presentazione PowerPoint in un PDF protetto da password utilizzando i parametri di protezione della classe [PdfOptions](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/pdfoptions/):

```java
import com.aspose.slides.*;

// Istanzia la classe Presentation che rappresenta un file PowerPoint o OpenDocument.
Presentation presentation = new Presentation("PowerPoint.pptx");
try {
    // Istanzia la classe PdfOptions.
    PdfOptions pdfOptions = new PdfOptions();

    // Imposta una password PDF e i permessi di accesso.
    pdfOptions.setPassword("password");
    pdfOptions.setAccessPermissions(PdfAccessPermissions.PrintDocument | PdfAccessPermissions.HighQualityPrint);

    // Salva la presentazione come PDF.
    presentation.save("PPTX-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

### **Rileva Sostituzioni di Font**

Aspose.Slides fornisce il metodo [setWarningCallback](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/saveoptions/#setWarningCallback-com.aspose.slides.IWarningCallback-) nella classe [PdfOptions](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/pdfoptions/) che consente di rilevare le sostituzioni di font durante il processo di conversione da presentazione a PDF.

Questo codice mostra come rilevare le sostituzioni di font:

```java
import com.aspose.slides.*;

public static void main(String[] args) {
    // Istanzia la classe Presentation che rappresenta un file PowerPoint o OpenDocument.
    Presentation presentation = new Presentation("sample.pptx");

    // Imposta il callback di avviso nelle opzioni PDF.
    PdfOptions pdfOptions = new PdfOptions();
    pdfOptions.setWarningCallback(new FontSubstitutionHandler());

    // Salva la presentazione come PDF.
    presentation.save("output.pdf", SaveFormat.Pdf, pdfOptions);
}

// Implementazione del callback di avviso.
private static class FontSubstitutionHandler implements IWarningCallback {
    public int warning(IWarningInfo warning) {
        if (warning.getWarningType() == WarningType.DataLoss &&
                warning.getDescription().startsWith("Font will be substituted")) {
            System.out.println("Font substitution warning: " + warning.getDescription());
        }

        return ReturnAction.Continue;
    }
}
```

{{%  alert color="info"  %}} 

Per ulteriori informazioni sulla sostituzione dei font, consulta l'articolo [Sostituzione dei Font](/slides/it/androidjava/font-substitution/).

{{% /alert %}} 

## **Converti Diapositive Selezionate da PowerPoint in PDF**

Questo codice dimostra come convertire solo diapositive specifiche da una presentazione PowerPoint in PDF:

```java
import com.aspose.slides.*;

// Istanzia la classe Presentation che rappresenta un file PowerPoint o OpenDocument.
Presentation presentation = new Presentation("PowerPoint.pptx");
try {
    // Imposta l'array di numeri di diapositive.
    int[] slides = { 1, 3 };

    // Salva la presentazione come PDF.
    presentation.save("PPTX-to-PDF.pdf", slides, SaveFormat.Pdf);
} finally {
    presentation.dispose();
}
```

## **Converti PowerPoint in PDF con Dimensione Personalizzata della Diapositiva**

Questo codice dimostra come convertire una presentazione PowerPoint in PDF con una dimensione della diapositiva specificata:

```java
import com.aspose.slides.*;

float slideWidth = 612;
float slideHeight = 792;

// Istanzia la classe Presentation che rappresenta un file PowerPoint o OpenDocument.
Presentation presentation = new Presentation("SelectedSlides.pptx");

// Crea una nuova presentazione con una dimensione di diapositiva regolata.
Presentation resizedPresentation = new Presentation();

try {
    // Imposta la dimensione personalizzata della diapositiva.
    resizedPresentation.getSlideSize().setSize(slideWidth, slideHeight, SlideSizeScaleType.EnsureFit);

    // Clona la prima diapositiva dalla presentazione originale.
    ISlide slide = presentation.getSlides().get_Item(0);
    resizedPresentation.getSlides().insertClone(0, slide);

    // Rimuovi la diapositiva vuota con cui è stata creata la nuova presentazione.
    resizedPresentation.getSlides().removeAt(1);

    // Salva la presentazione ridimensionata come PDF.
    resizedPresentation.save("PDF_with_custom_slide_size.pdf", SaveFormat.Pdf);
} finally {
    resizedPresentation.dispose();
    presentation.dispose();
}
```

## **Converti PowerPoint in PDF nella Visualizzazione Note della Diapositiva**

Questo codice dimostra come convertire una presentazione PowerPoint in un PDF che include le note:

```java
import com.aspose.slides.*;

// Istanzia la classe Presentation che rappresenta un file PowerPoint o OpenDocument.
Presentation presentation = new Presentation("SelectedSlides.pptx");
try {
    // Configura le opzioni PDF con layout delle note.
    NotesCommentsLayoutingOptions notesOptions = new NotesCommentsLayoutingOptions();
    notesOptions.setNotesPosition(NotesPositions.BottomFull);
    PdfOptions pdfOptions = new PdfOptions();
    pdfOptions.setSlidesLayoutOptions(notesOptions);

    // Salva la presentazione in un PDF con note.
    presentation.save("PDF_with_notes.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

## **Standard di Accessibilità e Conformità per PDF**

Aspose.Slides consente di utilizzare una procedura di conversione che rispetta le [Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html). È possibile esportare un documento PowerPoint in PDF utilizzando uno qualsiasi di questi standard di conformità: **PDF/A1a**, **PDF/A1b** e **PDF/UA**.

Questo codice dimostra un processo di conversione da PowerPoint a PDF che produce più PDF basati su diversi standard di conformità:

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

{{% alert title="Note" color="warning" %}} 

Aspose.Slides supporta operazioni di conversione PDF, consentendo di convertire i file PDF in formati di file popolari. È possibile eseguire conversioni da [PDF a HTML](https://products.aspose.com/slides/it/java/conversion/pdf-to-html/), [PDF a immagine](https://products.aspose.com/slides/it/java/conversion/pdf-to-image/), [PDF a JPG](https://products.aspose.com/slides/it/java/conversion/pdf-to-jpg/) e [PDF a PNG](https://products.aspose.com/slides/it/java/conversion/pdf-to-png/). Altre operazioni di conversione PDF verso formati specializzati — [PDF a SVG](https://products.aspose.com/slides/it/java/conversion/pdf-to-svg/), [PDF a TIFF](https://products.aspose.com/slides/it/java/conversion/pdf-to-tiff/), e [PDF a XML](https://products.aspose.com/slides/it/java/conversion/pdf-to-xml/) — sono anch'esse supportate.

{{% /alert %}}

> **Nota:** Quando si esporta in PDF/UA, Aspose.Slides tratta grafici complessi come SmartArt, diagrammi e formule come una singola figura. Gli elementi di percorso individuali non sono preservati come contenuto separato e possono essere contrassegnati come artefatti; il testo alternativo è fornito solo per l'intera figura.

## **FAQ**

### Posso convertire più file PowerPoint in PDF in batch?

Sì, Aspose.Slides supporta la conversione batch di più file PPT o PPTX in PDF. Puoi iterare sui tuoi file e applicare il processo di conversione programmaticamente.

### È possibile proteggere con password il PDF convertito?

Assolutamente. Usa la classe [PdfOptions](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/pdfoptions/) per impostare una password e definire i permessi di accesso durante il processo di conversione.

### Come includere le diapositive nascoste nel PDF?

Utilizza il metodo `setShowHiddenSlides` nella classe [PdfOptions](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/pdfoptions/) per includere le diapositive nascoste nel PDF risultante.

### Aspose.Slides può mantenere alta qualità delle immagini nel PDF?

Sì, è possibile controllare la qualità delle immagini usando metodi come `setJpegQuality` e `setSufficientResolution` nella classe [PdfOptions](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/pdfoptions/) per garantire immagini di alta qualità nel PDF.

### Aspose.Slides supporta gli standard di conformità PDF/A?

Sì, Aspose.Slides consente di esportare PDF che rispettano vari standard, inclusi PDF/A1a, PDF/A1b e PDF/UA, assicurando che i documenti soddisfino i requisiti di accessibilità e archiviazione.

## **Risorse Aggiuntive**

- [Documentazione di Aspose.Slides per Android via Java](/slides/it/androidjava/)
- [Riferimento API di Aspose.Slides per Android via Java](https://reference.aspose.com/slides/it/androidjava/)
- [Convertitori Online Gratuiti di Aspose](https://products.aspose.app/slides/it/conversion)