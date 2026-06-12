---
title: Converti PPT e PPTX in PDF in PHP [Funzionalità Avanzate Incluse]
linktitle: PowerPoint in PDF
type: docs
weight: 40
url: /it/php-java/convert-powerpoint-to-pdf/
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
- PHP
- Aspose.Slides
description: "Converti PowerPoint PPT/PPTX in PDF di alta qualità e ricercabili in PHP usando Aspose.Slides, con esempi di codice rapidi e opzioni di conversione avanzate."
---
## **Panoramica**

La conversione delle presentazioni PowerPoint (PPT, PPTX, ODP, ecc.) in formato PDF in PHP offre diversi vantaggi, tra cui la compatibilità su diversi dispositivi e la conservazione del layout e della formattazione della presentazione. Questa guida dimostra come convertire le presentazioni in documenti PDF, utilizzare varie opzioni per controllare la qualità delle immagini, includere le diapositive nascoste, proteggere con password i file PDF, rilevare le sostituzioni di caratteri, selezionare diapositive specifiche per la conversione e applicare standard di conformità ai documenti di output.

## **Conversioni da PowerPoint a PDF**

Utilizzando Aspose.Slides, è possibile convertire le presentazioni nei seguenti formati in PDF:

* **PPT**
* **PPTX**
* **ODP**

Per convertire una presentazione in PDF, passare il nome del file come argomento alla classe [Presentation](https://reference.aspose.com/slides/it/php-java/aspose.slides/Presentation) e poi salvare la presentazione come PDF utilizzando il metodo `save`. La classe [Presentation](https://reference.aspose.com/slides/it/php-java/aspose.slides/Presentation) espone il metodo `save` che è tipicamente usato per convertire una presentazione in PDF.

{{%  alert title="NOTE"  color="warning"   %}} 
Aspose.Slides per PHP via Java inserisce le informazioni sull'API e il numero di versione nei documenti di output. Per esempio, durante la conversione di una presentazione in PDF, Aspose.Slides popola il campo Application con "*Aspose.Slides*" e il campo PDF Producer con un valore nella forma "*Aspose.Slides v XX.XX*". **Nota** che non è possibile istruire Aspose.Slides a modificare o rimuovere queste informazioni dai documenti di output.
{{% /alert %}}

Aspose.Slides consente di convertire:

* Tutte le presentazioni in PDF
* Diapositive specifiche di una presentazione in PDF

Aspose.Slides esporta le presentazioni in PDF, garantendo che i PDF risultanti corrispondano fedelmente alle presentazioni originali. Gli elementi e gli attributi sono renderizzati accuratamente nella conversione, includendo:

* Immagini
* Caselle di testo e forme
* Formattazione del testo
* Formattazione dei paragrafi
* Collegamenti ipertestuali
* Intestazioni e piè di pagina
* Elenchi puntati
* Tabelle

## **Converti PowerPoint in PDF**

Il processo standard di conversione da PowerPoint a PDF utilizza le opzioni predefinite. In questo caso, Aspose.Slides tenta di convertire la presentazione fornita in PDF utilizzando impostazioni ottimali al massimo livello di qualità.

Questo codice mostra come convertire una presentazione (PPT, PPTX, ODP, ecc.) in PDF:

```php
# Istanzia la classe Presentation che rappresenta un file PowerPoint o OpenDocument.
$presentation = new Presentation("PowerPoint.pptx");
try {
    # Salva la presentazione come PDF.
    $presentation->save("PPT-to-PDF.pdf", SaveFormat::Pdf);
} finally {
    $presentation->dispose();
}
```

{{%  alert  color="primary"  %}} 
Aspose offre un [**Convertitore PowerPoint in PDF**](https://products.aspose.app/slides/it/conversion/ppt-to-pdf) gratuito online che dimostra il processo di conversione da presentazione a PDF. È possibile eseguire un test con questo convertitore per una implementazione reale della procedura descritta qui.
{{% /alert %}}

## **Converti PowerPoint in PDF con Opzioni**

Aspose.Slides fornisce opzioni personalizzate—proprietà della classe [PdfOptions](https://reference.aspose.com/slides/it/php-java/aspose.slides/PdfOptions)—che consentono di personalizzare il PDF risultante, proteggere il PDF con una password o specificare come deve procedere il processo di conversione.

### **Converti PowerPoint in PDF con Opzioni Personalizzate**

Utilizzando opzioni di conversione personalizzate, è possibile definire l'impostazione di qualità preferita per le immagini raster, specificare come gestire i metafili, impostare un livello di compressione per il testo, configurare i DPI per le immagini e altro ancora.

```php
# Istanzia la classe PdfOptions.
$pdfOptions = new PdfOptions();

# Imposta la qualità per le immagini JPG.
$pdfOptions->setJpegQuality(90);

# Imposta i DPI per le immagini.
$pdfOptions->setSufficientResolution(300);

# Imposta il comportamento per i metafili.
$pdfOptions->setSaveMetafilesAsPng(true);

# Imposta il livello di compressione del testo per il contenuto testuale.
$pdfOptions->setTextCompression(PdfTextCompression::Flate);

# Definisci la modalità di conformità PDF.
$pdfOptions->setCompliance(PdfCompliance::Pdf15);

# Istanzia la classe Presentation che rappresenta un file PowerPoint o OpenDocument.
$presentation = new Presentation("PowerPoint.pptx");
try {
    # Salva la presentazione come documento PDF.
    $presentation->save("PowerPoint-to-PDF.pdf", SaveFormat::Pdf, $pdfOptions);
} finally {
    $presentation->dispose();
}
```

### **Converti PowerPoint in PDF con Diapositive Nascoste**

Se una presentazione contiene diapositive nascoste, è possibile utilizzare il metodo [setShowHiddenSlides](https://reference.aspose.com/slides/it/php-java/aspose.slides/pdfoptions/#setShowHiddenSlides) della classe [PdfOptions](https://reference.aspose.com/slides/it/php-java/aspose.slides/PdfOptions) per includere le diapositive nascoste come pagine nel PDF risultante.

```php
# Istanzia la classe Presentation che rappresenta un file PowerPoint o OpenDocument.
$presentation = new Presentation("PowerPoint.pptx");
try {
    # Istanzia la classe PdfOptions.
    $pdfOptions = new PdfOptions();

    # Aggiungi le diapositive nascoste.
    $pdfOptions->setShowHiddenSlides(true);

    # Salva la presentazione come PDF.
    $presentation->save("PowerPoint-to-PDF.pdf", SaveFormat::Pdf, $pdfOptions);
} finally {
    $presentation->dispose();
}
```

### **Converti PowerPoint in PDF Protetto da Password**

Questo codice dimostra come convertire una presentazione PowerPoint in un PDF protetto da password utilizzando i parametri di protezione della classe [PdfOptions](https://reference.aspose.com/slides/it/php-java/aspose.slides/pdfoptions/):

```php
# Istanzia la classe Presentation che rappresenta un file PowerPoint o OpenDocument.
$presentation = new Presentation("PowerPoint.pptx");
try {
    # Istanzia la classe PdfOptions.
    $pdfOptions = new PdfOptions();

    # Imposta una password PDF e i permessi di accesso.
    $pdfOptions->setPassword("password");
    $pdfOptions->setAccessPermissions(PdfAccessPermissions::PrintDocument | PdfAccessPermissions::HighQualityPrint);

    # Salva la presentazione come PDF.
    $presentation->save("PPTX-to-PDF.pdf", SaveFormat::Pdf, $pdfOptions);
} finally {
    $presentation->dispose();
}
```

### **Rileva Sostituzioni di Font**

Aspose.Slides fornisce il metodo [setWarningCallback](https://reference.aspose.com/slides/it/php-java/aspose.slides/saveoptions/#setWarningCallback) nella classe [PdfOptions](https://reference.aspose.com/slides/it/php-java/aspose.slides/pdfoptions/), permettendo di rilevare le sostituzioni di font durante il processo di conversione da presentazione a PDF.

Questo codice mostra come rilevare le sostituzioni di font:

```php
class FontSubstitutionHandler {
    function warning($warning)
    {
        if (java_values($warning->getWarningType()) == WarningType::DataLoss &&
        $warning->getDescription()->startsWith("Font will be substituted")) {
            echo("Font substitution warning: " . $warning->getDescription());
        }

        return ReturnAction::Continue;
    }
}

// Imposta il callback di avviso nelle opzioni PDF.
$pdfOptions = new PdfOptions();
$warningCallback = java_closure(new FontSubstitutionHandler(), null, java("com.aspose.slides.IWarningCallback"));
$pdfOptions->setWarningCallback($warningCallback);

// Istanzia la classe Presentation che rappresenta un file PowerPoint o OpenDocument.
$presentation = new Presentation("sample.pptx");
try {
    // Salva la presentazione come PDF.
    $presentation->save("output.pdf", SaveFormat::Pdf, $pdfOptions);
} finally {
    $presentation->dispose();
}
```

{{%  alert color="primary"  %}} 
Per ulteriori informazioni sulla sostituzione dei font, consultare l'articolo [Sostituzione dei Font](/slides/it/php-java/font-substitution/).
{{% /alert %}} 

## **Converti Diapositive Selezionate in PowerPoint in PDF**

Questo codice dimostra come convertire solo diapositive specifiche da una presentazione PowerPoint in PDF:

```php
# Istanzia la classe Presentation che rappresenta un file PowerPoint o OpenDocument.
$presentation = new Presentation("PowerPoint.pptx");
try {
    # Imposta l'array dei numeri di diapositiva.
    $slides = array(1, 3);

    # Salva la presentazione come PDF.
    $presentation->save("PPTX-to-PDF.pdf", $slides, SaveFormat::Pdf);
} finally {
    $presentation->dispose();
}
```

## **Converti PowerPoint in PDF con Dimensione Personalizzata della Diapositiva**

Questo codice dimostra come convertire una presentazione PowerPoint in PDF con una dimensione di diapositiva specificata:

```php
$slideWidth = 612.0;
$slideHeight = 792.0;

# Istanzia la classe Presentation che rappresenta un file PowerPoint o OpenDocument.
$presentation = new Presentation("SelectedSlides.pptx");

# Crea una nuova presentazione con una dimensione della diapositiva regolata.
$resizedPresentation = new Presentation();

try {
    # Imposta la dimensione personalizzata della diapositiva.
    $resizedPresentation->getSlideSize()->setSize($slideWidth, $slideHeight, SlideSizeScaleType::EnsureFit);

    # Clona la prima diapositiva dalla presentazione originale.
    $slide = $presentation->getSlides()->get_Item(0);
    $resizedPresentation->getSlides()->insertClone(0, $slide);

    # Salva la presentazione ridimensionata in PDF con le note.
    $resizedPresentation->save("PDFnotes_out.pdf", SaveFormat::Pdf);
} finally {
    $resizedPresentation->dispose();
    $presentation->dispose();
}
```

## **Converti PowerPoint in PDF in Visualizzazione Note delle Diapositive**

Questo codice dimostra come convertire una presentazione PowerPoint in un PDF che include le note:

```php
# Istanzia la classe Presentation che rappresenta un file PowerPoint o OpenDocument.
$presentation = new Presentation("SelectedSlides.pptx");
try {
    # Configura le opzioni PDF con layout delle note.
    $notesOptions = new NotesCommentsLayoutingOptions();
    $notesOptions->setNotesPosition(NotesPositions::BottomFull);
    $pdfOptions = new PdfOptions();
    $pdfOptions->setSlidesLayoutOptions($notesOptions);

    # Salva la presentazione in PDF con le note.
    $presentation->save("PDF_with_notes.pdf", SaveFormat::Pdf, $pdfOptions);
} finally {
    $presentation->dispose();
}
```

## **Accessibilità e Standard di Conformità per PDF**

Aspose.Slides consente di utilizzare una procedura di conversione che conforma alle [Linee Guida per l'Accessibilità dei Contenuti Web (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html). È possibile esportare un documento PowerPoint in PDF utilizzando uno di questi standard di conformità: **PDF/A1a**, **PDF/A1b** e **PDF/UA**.

Questo codice dimostra un processo di conversione da PowerPoint a PDF che produce più PDF basati su diversi standard di conformità:

```php
$presentation = new Presentation("pres.pptx");
try {
    $pdfOptions = new PdfOptions();

    $pdfOptions->setCompliance(PdfCompliance::PdfA1a);
    $presentation->save("pres-a1a-compliance.pdf", SaveFormat::Pdf, $pdfOptions);

    $pdfOptions->setCompliance(PdfCompliance::PdfA1b);
    $presentation->save("pres-a1b-compliance.pdf", SaveFormat::Pdf, $pdfOptions);

    $pdfOptions->setCompliance(PdfCompliance::PdfUa);
    $presentation->save("pres-ua-compliance.pdf", SaveFormat::Pdf, $pdfOptions);
} finally {
    $presentation->dispose();
}
```

{{% alert title="Note" color="warning" %}} 
Aspose.Slides supporta operazioni di conversione PDF, consentendo di convertire i file PDF in formati di file popolari. È possibile eseguire le conversioni [PDF in HTML](https://products.aspose.com/slides/it/php-java/conversion/pdf-to-html/), [PDF in immagine](https://products.aspose.com/slides/it/php-java/conversion/pdf-to-image/), [PDF in JPG](https://products.aspose.com/slides/it/php-java/conversion/pdf-to-jpg/), e [PDF in PNG](https://products.aspose.com/slides/it/php-java/conversion/pdf-to-png/). Altre operazioni di conversione PDF verso formati specializzati—[PDF in SVG](https://products.aspose.com/slides/it/php-java/conversion/pdf-to-svg/), [PDF in TIFF](https://products.aspose.com/slides/it/php-java/conversion/pdf-to-tiff/), e [PDF in XML](https://products.aspose.com/slides/it/php-java/conversion/pdf-to-xml/)—sono anch'esse supportate.
{{% /alert %}}

> **Nota:** Quando si esporta in PDF/UA, Aspose.Slides tratta grafiche complesse come SmartArt, chart e formule come una singola figura. Gli elementi di percorso individuali non sono preservati come contenuto separato e possono essere marcati come artefatti; il testo alternativo è fornito solo per l'intera figura.

## **FAQ**

**Posso convertire più file PowerPoint in PDF in blocco?**  
Sì, Aspose.Slides supporta la conversione batch di più file PPT o PPTX in PDF. È possibile iterare sui file e applicare il processo di conversione programmaticamente.

**È possibile proteggere con password il PDF convertito?**  
Assolutamente. Utilizzare la classe [PdfOptions](https://reference.aspose.com/slides/it/php-java/aspose.slides/pdfoptions/) per impostare una password e definire i permessi di accesso durante il processo di conversione.

**Come includere le diapositive nascoste nel PDF?**  
Utilizzare il metodo `setShowHiddenSlides` nella classe [PdfOptions](https://reference.aspose.com/slides/it/php-java/aspose.slides/pdfoptions/) per includere le diapositive nascoste nel PDF risultante.

**Aspose.Slides può mantenere alta qualità dell'immagine nel PDF?**  
Sì, è possibile controllare la qualità delle immagini utilizzando metodi come `setJpegQuality` e `setSufficientResolution` nella classe [PdfOptions](https://reference.aspose.com/slides/it/php-java/aspose.slides/pdfoptions/) per garantire immagini ad alta qualità nel PDF.

**Aspose.Slides supporta gli standard di conformità PDF/A?**  
Sì, Aspose.Slides consente di esportare PDF conformi a vari standard, tra cui PDF/A1a, PDF/A1b e PDF/UA, assicurando che i documenti soddisfino i requisiti di accessibilità e archiviazione.

## **Risorse Aggiuntive**

- [Documentazione Aspose.Slides per PHP via Java](/slides/it/php-java/)
- [Riferimento API Aspose.Slides per PHP via Java](https://reference.aspose.com/slides/it/php-java/)
- [Convertitori Online Gratuiti Aspose](https://products.aspose.app/slides/it/conversion)