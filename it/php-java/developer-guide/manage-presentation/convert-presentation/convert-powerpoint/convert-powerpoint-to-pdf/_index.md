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
- allegato
- PDF/A1a
- PDF/A1b
- PDF/UA
- PHP
- Aspose.Slides
description: "Converti PowerPoint PPT/PPTX in PDF di alta qualità e ricercabili in PHP usando Aspose.Slides, con esempi di codice rapidi e opzioni di conversione avanzate."
---
## **Panoramica**

Convertire le presentazioni PowerPoint (PPT, PPTX, ODP, ecc.) in formato PDF in PHP offre diversi vantaggi, tra cui la compatibilità su diversi dispositivi e la conservazione del layout e della formattazione della presentazione. Questa guida dimostra come convertire le presentazioni in documenti PDF, utilizzare varie opzioni per controllare la qualità delle immagini, includere le diapositive nascoste, proteggere con password i file PDF, rilevare le sostituzioni di caratteri, selezionare diapositive specifiche per la conversione e applicare standard di conformità ai documenti di output.

## **Conversioni da PowerPoint a PDF**

Utilizzando Aspose.Slides, è possibile convertire le presentazioni nei seguenti formati in PDF:

* **PPT**
* **PPTX**
* **ODP**

Per convertire una presentazione in PDF, passare il nome del file come argomento alla classe [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) e quindi salvare la presentazione come PDF usando il metodo [save](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/#save). La classe [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) espone il metodo [save](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/#save) che è tipicamente usato per convertire una presentazione in PDF.

{{% alert color="info" title="Note" %}}

Aspose.Slides for PHP via Java inserisce le informazioni sull'API e il numero di versione nei documenti di output. Ad esempio, durante la conversione di una presentazione in PDF, Aspose.Slides popola il campo Application con "*Aspose.Slides*" e il campo PDF Producer con un valore nella forma "*Aspose.Slides v XX.XX*". **Nota** che non è possibile istruirе Aspose.Slides a modificare o rimuovere queste informazioni dai documenti di output.

{{% /alert %}}

Aspose.Slides consente di convertire:

* Intere presentazioni in PDF
* Diapositive specifiche da una presentazione in PDF

Aspose.Slides esporta le presentazioni in PDF, garantendo che i PDF risultanti corrispondano fedelmente alle presentazioni originali. Gli elementi e gli attributi vengono resi accuratamente nella conversione, inclusi:

* Immagini
* Caselle di testo e forme
* Formattazione del testo
* Formattazione dei paragrafi
* Collegamenti ipertestuali
* Intestazioni e piè di pagina
* Elenchi puntati
* Tabelle

## **Convertire PowerPoint in PDF**

Il processo standard di conversione da PowerPoint a PDF utilizza le opzioni predefinite. In questo caso, Aspose.Slides tenta di convertire la presentazione fornita in PDF usando impostazioni ottimali ai massimi livelli di qualità.

L'esempio seguente carica una presentazione e salva tutte le diapositive visibili in PDF usando le impostazioni di esportazione predefinite.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("PowerPoint.pptx");
try {
    $presentation->save("PPT-to-PDF.pdf", SaveFormat::Pdf);
} finally {
    $presentation->dispose();
}
```

{{% alert color="info" title="Note" %}}

Aspose offre un gratuito [**convertitore PowerPoint in PDF**](https://products.aspose.app/slides/conversion/ppt-to-pdf) online che dimostra il processo di conversione da presentazione a PDF. È possibile eseguire un test con questo convertitore per una implementazione dal vivo della procedura descritta qui.

{{% /alert %}}

## **Convertire PowerPoint in PDF con Opzioni**

Aspose.Slides fornisce opzioni personalizzate—proprietà della classe [PdfOptions](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/)—che consentono di personalizzare il PDF risultante, proteggere il PDF con una password o specificare come deve procedere il processo di conversione.

### **Convertire PowerPoint in PDF con Opzioni Personalizzate**

Utilizzando opzioni di conversione personalizzate, è possibile definire l'impostazione di qualità preferita per le immagini raster, specificare come gestire i metafile, impostare un livello di compressione per il testo, configurare i DPI per le immagini e altro ancora.

L'esempio seguente esporta una presentazione in PDF 1.5 con qualità JPEG impostata a 90, risoluzione immagine a 300 DPI, metafile salvati come PNG e compressione testo Flate.

```php
use aspose\slides\PdfCompliance;
use aspose\slides\PdfOptions;
use aspose\slides\PdfTextCompression;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$pdfOptions = new PdfOptions();
$pdfOptions->setJpegQuality(90);
$pdfOptions->setSufficientResolution(300);
$pdfOptions->setSaveMetafilesAsPng(true);
$pdfOptions->setTextCompression(PdfTextCompression::Flate);
$pdfOptions->setCompliance(PdfCompliance::Pdf15);

$presentation = new Presentation("PowerPoint.pptx");
try {
    $presentation->save("PowerPoint-to-PDF.pdf", SaveFormat::Pdf, $pdfOptions);
} finally {
    $presentation->dispose();
}
```

### **Preservare i File OLE Incorporati come Allegati PDF**

Se una presentazione contiene una cartella di lavoro Excel incorporata, è possibile consentire ai destinatari del PDF di accedere ai dati della cartella di lavoro oltre a visualizzare le diapositive. Chiamare [setIncludeOleData](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/#setIncludeOleData) con `true` per preservare i file OLE incorporati come allegati nel PDF risultante.

Il valore predefinito è `false`: l'immagine di anteprima o l'icona dell'oggetto OLE viene resa nella pagina PDF, ma il file incorporato non è incluso come allegato. Impostare l'opzione a `true` aggiunge inoltre i dati del file. L'anteprima rimane una rappresentazione visuale; l'allegato consente ai destinatari di aprire o salvare il file incorporato separatamente. L'oggetto OLE non diventa un foglio di lavoro Excel interattivo nella pagina PDF.

L'esempio seguente carica una presentazione che contiene già una cartella di lavoro Excel incorporata ed esporta il PDF con la cartella di lavoro allegata.

```php
use aspose\slides\PdfOptions;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$pdfOptions = new PdfOptions();
$pdfOptions->setIncludeOleData(true);

$presentation = new Presentation("presentation.pptx");
try {
    $presentation->save("presentation.pdf", SaveFormat::Pdf, $pdfOptions);
} finally {
    $presentation->dispose();
}
```

Per verificare il risultato:

1. Aprire il PDF esportato in un visualizzatore che supporta gli allegati, ad esempio Adobe Acrobat Reader.
2. Aprire il pannello **Allegati** del visualizzatore e individuare la cartella di lavoro incorporata.
3. Salvare l'allegato e aprirlo in Excel per ispezionare i dati, oppure aprirlo direttamente se il visualizzatore lo consente. L'anteprima nella pagina PDF è separata dall'allegato.

{{% alert color="info" title="Note" %}}

Gli standard PDF/A impongono restrizioni sugli allegati: PDF/A-1 vieta i file incorporati, PDF/A-2 consente solo allegati PDF/A, e PDF/A-3 permette altri tipi di file, incluse le cartelle di lavoro Excel. Questi sono requisiti degli standard, non limitazioni specifiche di Aspose.Slides. Questo esempio utilizza l'impostazione predefinita di conformità PDF e non dimostra l'esportazione PDF/A.

{{% /alert %}}

### **Convertire PowerPoint in PDF con Diapositive Nascoste**

Se una presentazione contiene diapositive nascoste, è possibile utilizzare il metodo [setShowHiddenSlides](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/#setShowHiddenSlides) della classe [PdfOptions](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/) per includere le diapositive nascoste come pagine nel PDF risultante.

L'esempio seguente esporta una presentazione in PDF, includendo eventuali diapositive nascoste.

```php
use aspose\slides\PdfOptions;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$pdfOptions = new PdfOptions();
$pdfOptions->setShowHiddenSlides(true);

$presentation = new Presentation("PowerPoint.pptx");
try {
    $presentation->save("PowerPoint-to-PDF.pdf", SaveFormat::Pdf, $pdfOptions);
} finally {
    $presentation->dispose();
}
```

### **Convertire PowerPoint in PDF Protetto da Password**

L'esempio seguente esporta una presentazione in PDF che richiede la password `password` per l'apertura. Le autorizzazioni di accesso consentono la stampa, inclusa la stampa ad alta qualità.

```php
use aspose\slides\PdfAccessPermissions;
use aspose\slides\PdfOptions;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$pdfOptions = new PdfOptions();
$pdfOptions->setPassword("password");
$pdfOptions->setAccessPermissions(PdfAccessPermissions::PrintDocument | PdfAccessPermissions::HighQualityPrint);

$presentation = new Presentation("PowerPoint.pptx");
try {
    $presentation->save("PPTX-to-PDF.pdf", SaveFormat::Pdf, $pdfOptions);
} finally {
    $presentation->dispose();
}
```

### **Rilevare le Sostituzioni di Font**

Aspose.Slides fornisce il metodo [setWarningCallback](https://reference.aspose.com/slides/php-java/aspose.slides/saveoptions/#setWarningCallback) nella classe [PdfOptions](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/), consentendo di rilevare le sostituzioni di font durante il processo di conversione da presentazione a PDF.

L'esempio seguente esporta una presentazione in PDF e stampa gli avvisi di sostituzione dei font nella console. Un avviso viene stampato solo quando un font non disponibile è sostituito durante l'esportazione.

```php
use aspose\slides\PdfOptions;
use aspose\slides\Presentation;
use aspose\slides\ReturnAction;
use aspose\slides\SaveFormat;
use aspose\slides\WarningType;

class FontSubstitutionHandler {
    function warning($warning)
    {
        if (java_values($warning->getWarningType()) == WarningType::DataLoss && $warning->getDescription()->startsWith("Font will be substituted")) {
            echo("Font substitution warning: " . $warning->getDescription());
        }

        return ReturnAction::Continue;
    }
}

$warningCallback = java_closure(new FontSubstitutionHandler(), null, java("com.aspose.slides.IWarningCallback"));

$pdfOptions = new PdfOptions();
$pdfOptions->setWarningCallback($warningCallback);

$presentation = new Presentation("sample.pptx");
try {
    $presentation->save("output.pdf", SaveFormat::Pdf, $pdfOptions);
} finally {
    $presentation->dispose();
}
```

{{% alert color="info" title="Note" %}}

Per ulteriori informazioni sulla sostituzione dei font, vedere l'articolo [Font Substitution](/slides/it/php-java/font-substitution/).

{{% /alert %}} 

## **Convertire Diapositive Selezionate da PowerPoint in PDF**

L'esempio seguente esporta le diapositive 1 e 3 da una presentazione in PDF. I numeri delle diapositive in questo array sono basati su indice 1, e la presentazione di input deve contenere almeno tre diapositive.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("PowerPoint.pptx");
try {
    $slides = array(1, 3);
    $presentation->save("PPTX-to-PDF.pdf", $slides, SaveFormat::Pdf);
} finally {
    $presentation->dispose();
}
```

## **Convertire PowerPoint in PDF con Dimensione Diapositiva Personalizzata**

L'esempio seguente copia la prima diapositiva da una presentazione in una nuova presentazione con dimensione diapositiva di 612 × 792 punti (8,5 × 11 pollici). Ridimensiona il contenuto della diapositiva per adattarlo ed esporta la singola diapositiva in PDF.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\SlideSizeScaleType;

$slideWidth = 612.0;
$slideHeight = 792.0;

$presentation = new Presentation("SelectedSlides.pptx");
$resizedPresentation = new Presentation();

try {
    $resizedPresentation->getSlideSize()->setSize($slideWidth, $slideHeight, SlideSizeScaleType::EnsureFit);
    $slide = $presentation->getSlides()->get_Item(0);
    $resizedPresentation->getSlides()->insertClone(0, $slide);

    // Rimuovi la diapositiva vuota con cui è stata creata la nuova presentazione.
    $resizedPresentation->getSlides()->removeAt(1);

    $resizedPresentation->save("PDF_with_custom_slide_size.pdf", SaveFormat::Pdf);
} finally {
    $resizedPresentation->dispose();
    $presentation->dispose();
}
```

## **Convertire PowerPoint in PDF nella Visualizzazione Note della Diapositiva**

L'esempio seguente esporta una presentazione in PDF, posizionando le note del relatore di ogni diapositiva sotto la diapositiva stessa. Utilizzare una presentazione contenente note del relatore per vedere il risultato.

```php
use aspose\slides\NotesCommentsLayoutingOptions;
use aspose\slides\NotesPositions;
use aspose\slides\PdfOptions;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$notesOptions = new NotesCommentsLayoutingOptions();
$notesOptions->setNotesPosition(NotesPositions::BottomFull);

$pdfOptions = new PdfOptions();
$pdfOptions->setSlidesLayoutOptions($notesOptions);

$presentation = new Presentation("SelectedSlides.pptx");
try {
    $presentation->save("PDF_with_notes.pdf", SaveFormat::Pdf, $pdfOptions);
} finally {
    $presentation->dispose();
}
```

## **Accessibilità e Standard di Conformità per PDF**

Aspose.Slides consente di utilizzare una procedura di conversione che rispetta le [Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html). È possibile esportare un documento PowerPoint in PDF utilizzando uno dei seguenti standard di conformità: **PDF/A1a**, **PDF/A1b** e **PDF/UA**.

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

{{% alert color="info" title="Note" %}}

Aspose.Slides supporta operazioni di conversione PDF, consentendo di convertire file PDF in formati di file popolari. È possibile eseguire conversioni [PDF to HTML](https://products.aspose.com/slides/php-java/conversion/pdf-to-html/), [PDF to image](https://products.aspose.com/slides/php-java/conversion/pdf-to-image/), [PDF to JPG](https://products.aspose.com/slides/php-java/conversion/pdf-to-jpg/) e [PDF to PNG](https://products.aspose.com/slides/php-java/conversion/pdf-to-png/). Sono supportate anche altre operazioni di conversione PDF verso formati specializzati—[PDF to SVG](https://products.aspose.com/slides/php-java/conversion/pdf-to-svg/), [PDF to TIFF](https://products.aspose.com/slides/php-java/conversion/pdf-to-tiff/), e [PDF to XML](https://products.aspose.com/slides/php-java/conversion/pdf-to-xml/).

{{% /alert %}}

> **Nota:** Quando si esporta in PDF/UA, Aspose.Slides tratta le grafiche complesse come SmartArt, grafici e formule come una singola figura. Gli elementi di percorso individuali non sono conservati come contenuti separati e possono essere contrassegnati come artefatti; il testo alternativo è fornito solo per l'intera figura.

## **FAQ**

**Posso convertire più file PowerPoint in PDF in blocco?**

Sì, Aspose.Slides supporta la conversione batch di più file PPT o PPTX in PDF. È possibile iterare tra i file e applicare il processo di conversione programmaticamente.

**È possibile proteggere con password il PDF convertito?**

Sì. Utilizzare la classe [PdfOptions](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/) per impostare una password e definire le autorizzazioni di accesso durante il processo di conversione.

**Come includere le diapositive nascoste nel PDF?**

Chiamare [setShowHiddenSlides](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/#setShowHiddenSlides) con `true` nella classe [PdfOptions](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/) per includere le diapositive nascoste nel PDF risultante.

**Aspose.Slides può mantenere alta qualità delle immagini nel PDF?**

Sì, è possibile controllare la qualità delle immagini usando metodi come [setJpegQuality](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/#setJpegQuality) e [setSufficientResolution](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/#setSufficientResolution) nella classe [PdfOptions](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/) per garantire immagini ad alta qualità nel PDF.

**Aspose.Slides supporta gli standard di conformità PDF/A?**

Sì, Aspose.Slides consente di esportare PDF conformi a [vari standard](https://reference.aspose.com/slides/php-java/aspose.slides/pdfcompliance/), tra cui PDF/A1a, PDF/A1b e PDF/UA, assicurando che i documenti soddisfino i requisiti di accessibilità e archiviazione.

## **Risorse Aggiuntive**

- [Aspose.Slides for PHP via Java Documentation](/slides/it/php-java/)
- [Aspose.Slides for PHP via Java API Reference](https://reference.aspose.com/slides/php-java/)
- [Aspose Free Online Converters](https://products.aspose.app/slides/conversion)