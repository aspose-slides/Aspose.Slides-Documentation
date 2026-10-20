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

Convertire presentazioni PowerPoint (PPT, PPTX, ODP, ecc.) in formato PDF in PHP offre diversi vantaggi, tra cui la compatibilità su diversi dispositivi e la conservazione del layout e della formattazione della tua presentazione. Questa guida dimostra come convertire le presentazioni in documenti PDF, utilizzare varie opzioni per controllare la qualità delle immagini, includere diapositive nascoste, proteggere con password i file PDF, rilevare le sostituzioni dei font, selezionare diapositive specifiche per la conversione e applicare standard di conformità ai documenti di output.

## **Conversioni da PowerPoint a PDF**

Usando Aspose.Slides, puoi convertire le presentazioni nei seguenti formati in PDF:

* **PPT**
* **PPTX**
* **ODP**

Per convertire una presentazione in PDF, passa il nome del file come argomento alla classe [Presentazione](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) e poi salva la presentazione come PDF usando il metodo [salva](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/save/). La classe [Presentazione](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) espone il metodo [salva](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/save/) che è tipicamente usato per convertire una presentazione in PDF.

{{% alert color="info" title="Note" %}}
Aspose.Slides per PHP via Java inserisce le informazioni della sua API e il numero di versione nei documenti di output. Ad esempio, durante la conversione di una presentazione in PDF, Aspose.Slides popola il campo Applicazione con "*Aspose.Slides*" e il campo Produttore PDF con un valore nella forma "*Aspose.Slides v XX.XX*". **Nota** che non è possibile istruirre Aspose.Slides a modificare o rimuovere queste informazioni dai documenti di output.
{{% /alert %}}

Aspose.Slides ti consente di convertire:

* Intere presentazioni in PDF
* Diapositive specifiche da una presentazione in PDF

Aspose.Slides esporta le presentazioni in PDF, garantendo che i PDF risultanti corrispondano strettamente alle presentazioni originali. Elementi e attributi vengono renderizzati accuratamente nella conversione, includendo:

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
Aspose offre un convertitore online gratuito [**Convertitore da PowerPoint a PDF**](https://products.aspose.app/slides/conversion/ppt-to-pdf) che dimostra il processo di conversione da presentazione a PDF. Puoi eseguire un test con questo convertitore per una implementazione live della procedura descritta qui.
{{% /alert %}}

## **Convertire PowerPoint in PDF con Opzioni**

Aspose.Slides fornisce opzioni personalizzate—proprietà nella classe [PdfOptions](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/)—che ti consentono di personalizzare il PDF risultante, bloccare il PDF con una password o specificare come procedere con il processo di conversione.

### **Convertire PowerPoint in PDF con Opzioni Personalizzate**

Utilizzando opzioni di conversione personalizzate, puoi definire l'impostazione di qualità preferita per le immagini raster, specificare come gestire i metafile, impostare un livello di compressione per il testo, configurare i DPI per le immagini e altro ancora.

L'esempio seguente esporta una presentazione in PDF 1.5 con qualità JPEG impostata a 90, risoluzione immagine impostata a 300 DPI, metafile salvati come PNG e compressione testo Flate.

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

### **Selezionare Automaticamente la Compressione Immagine**

Quando una presentazione contiene molte fotografie o screenshot, ridurre le dimensioni del PDF esportato può facilitarne l'invio via email o il download. Chiama [PdfOptions::setBestImagesCompressionRatio](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/setbestimagescompressionratio/) con `true` per selezionare automaticamente l'algoritmo di compressione più appropriato per ogni immagine durante l'esportazione in PDF.

L'esempio seguente carica una presentazione esistente, abilita la selezione automatica della compressione delle immagini e la salva come documento PDF. Tutte le altre impostazioni di esportazione PDF mantengono i valori predefiniti.

```php
use aspose\slides\PdfOptions;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$pdfOptions = new PdfOptions();
$pdfOptions->setBestImagesCompressionRatio(true);

$presentation = new Presentation("image-heavy.pptx");
try {
    $presentation->save("image-heavy.pdf", SaveFormat::Pdf, $pdfOptions);
} finally {
    $presentation->dispose();
}
```

Questa opzione seleziona un algoritmo di compressione per ogni immagine. Ridurre il valore passato a [setJpegQuality](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/setjpegquality/) diminuisce invece la qualità dell'immagine JPEG, mentre ridurre il valore passato a [setSufficientResolution](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/setsufficientresolution/) consente di campionare le immagini a una risoluzione inferiore, il che può ridurre i dettagli. Abilitare la selezione automatica della compressione non abbassa automaticamente nessuna di queste impostazioni.

La selezione degli algoritmi di compressione delle immagini richiede tempo di elaborazione e memoria aggiuntivi. La riduzione delle dimensioni dipende dalle immagini della presentazione e dalle impostazioni di esportazione; una riduzione fissa non è garantita per ogni presentazione.

### **Conservare i File OLE Incorporati come Allegati PDF**

Se una presentazione contiene un workbook Excel incorporato, potresti desiderare che i destinatari del PDF accedano ai dati del workbook oltre a visualizzare le diapositive. Chiama [setIncludeOleData](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/) con `true` per conservare i file OLE incorporati come allegati nel PDF risultante.

Il valore predefinito è `false`: l'immagine di anteprima o l'icona dell'oggetto OLE viene renderizzata nella pagina PDF, ma il suo file incorporato non è incluso come allegato. Impostare l'opzione a `true` include inoltre i dati del file. L'anteprima rimane una rappresentazione visiva; l'allegato consente ai destinatari di aprire o salvare separatamente il file incorporato. L'oggetto OLE non diventa un foglio di lavoro Excel interattivo nella pagina PDF.

L'esempio seguente carica una presentazione che già contiene un workbook Excel incorporato ed esporta in PDF con il workbook allegato.

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
1. Apri il PDF esportato in un visualizzatore che supporta gli allegati, come Adobe Acrobat Reader.
2. Apri il pannello **Allegati** del visualizzatore e individua il workbook incorporato.
3. Salva l'allegato e aprilo in Excel per ispezionare i dati, oppure aprilo direttamente se il visualizzatore lo consente. L'anteprima nella pagina PDF è separata dall'allegato.

{{% alert color="info" title="Note" %}}
Le norme PDF/A impongono restrizioni sugli allegati: PDF/A-1 vieta i file incorporati, PDF/A-2 consente solo allegati PDF/A, e PDF/A-3 consente altri tipi di file, inclusi i workbook Excel. Questi sono requisiti delle norme, non restrizioni specifiche di Aspose.Slides. Questo esempio utilizza l'impostazione di conformità PDF predefinita e non dimostra l'esportazione PDF/A.
{{% /alert %}}

### **Convertire PowerPoint in PDF con Diapositive Nascoste**

Se una presentazione contiene diapositive nascoste, puoi usare il metodo [setShowHiddenSlides](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/setshowhiddenslides/) della classe [PdfOptions](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/) per includere le diapositive nascoste come pagine nel PDF risultato.

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

### **Convertire PowerPoint in un PDF Protetto da Password**

L'esempio seguente esporta una presentazione in un PDF che richiede la password `password` per l'apertura. Le autorizzazioni di accesso consentono la stampa, inclusa la stampa ad alta qualità.

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

### **Rilevare le Sostituzioni dei Font**

Aspose.Slides fornisce il metodo [setWarningCallback](https://reference.aspose.com/slides/php-java/aspose.slides/saveoptions/) nella classe [PdfOptions](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/), consentendo di rilevare le sostituzioni dei font durante il processo di conversione da presentazione a PDF.

L'esempio seguente esporta una presentazione in PDF e stampa gli avvisi di sostituzione dei font sulla console. Un avviso viene stampato solo quando un font non disponibile viene sostituito durante l'esportazione.

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
Per ulteriori informazioni sulla sostituzione dei font, consulta l'articolo [Sostituzione dei Font](/slides/it/php-java/font-substitution/).
{{% /alert %}} 

### **Gestire i Font Senza un Tipo di Carattere Grassetto Dedicato**

Una presentazione può applicare la formattazione grassetto al testo anche se il suo font non ha un tipo di carattere grassetto dedicato. Il testo può comunque apparire in grassetto tramite grassetto sintetico, che ispessisce artificialmente i glifi regolari. Quando quel testo appare troppo pesante o differente dall'aspetto previsto nel PDF, prova a chiamare [PdfOptions::setRasterizeUnsupportedFontStyles](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/) con `true`. Questa opzione renderizza il testo interessato come bitmap durante l'esportazione PDF e può migliorarne l'aspetto per alcuni font. Il suo valore predefinito è `false`.

La presentazione di esempio contiene due caselle di testo: una con testo normale e una con formattazione grassetto applicata allo stesso font, che non ha un tipo di carattere grassetto dedicato. L'esempio seguente carica la presentazione, abilita la rasterizzazione degli stili di font non supportati e la esporta in PDF:

```php
use aspose\slides\PdfOptions;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$pdfOptions = new PdfOptions();
$pdfOptions->setRasterizeUnsupportedFontStyles(true);

$presentation = new Presentation("unsupported-bold.pptx");
try {
    $presentation->save("rasterized.pdf", SaveFormat::Pdf, $pdfOptions);
} finally {
    $presentation->dispose();
}
```

Le seguenti anteprime mostrano l'output con l'opzione disabilitata e l'output con l'opzione abilitata. In questo esempio, il testo in grassetto ha tratti più spessi con l'opzione disabilitata. Con l'opzione abilitata, i suoi tratti sono più leggeri; il testo normale rimane invariato. Confronta i risultati prima di scegliere l'impostazione per la tua presentazione.

| Opzione disabilitata (`false`, predefinita) | Opzione abilitata (`true`) |
|---|---|
| ![PDF with unsupported font style rasterization disabled](unsupported-bold-disabled.png) | ![PDF with unsupported font style rasterization enabled](unsupported-bold-enabled.png) |

In questo esempio, l'abilitazione dell'opzione trasforma solo il testo in grassetto in bitmap: non può essere selezionato, copiato o cercato come testo senza OCR, e i suoi bordi appaiono più morbidi allo zoom 800%. Il testo normale rimane ricercabile. Con l'opzione disabilitata, entrambe le stringhe rimangono testo.

Questa opzione rasterizza il testo formattato in grassetto quando il suo font non ha un tipo di carattere grassetto dedicato. [Sostituzione dei Font](/slides/it/php-java/font-substitution/) seleziona invece un altro font quando quello originale non è disponibile.

## **Convertire Diapositive Selezionate da PowerPoint a PDF**

L'esempio seguente esporta le diapositive 1 e 3 da una presentazione in PDF. I numeri delle diapositive in questo array partono da 1, e la presentazione di input deve contenere almeno tre diapositive.

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

## **Convertire PowerPoint in PDF con Dimensioni Personalizzate della Diapositiva**

L'esempio seguente copia la prima diapositiva da una presentazione in una nuova presentazione con una dimensione della diapositiva di 612 × 792 punti (8,5 × 11 pollici). Ridimensiona il contenuto della diapositiva per adattarlo ed esporta la singola diapositiva in PDF.

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

L'esempio seguente esporta una presentazione in PDF, posizionando le note del relatore di ciascuna diapositiva sotto la diapositiva stessa. Usa una presentazione contenente note del relatore per vedere il risultato.

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

Aspose.Slides ti permette di utilizzare una procedura di conversione che rispetta le [Linee Guida per l'Accessibilità dei Contenuti Web (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html). Puoi esportare un documento PowerPoint in PDF usando uno di questi standard di conformità: **PDF/A1a**, **PDF/A1b**, e **PDF/UA**.

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
Aspose.Slides ti consente di eseguire conversioni da [PDF in HTML](https://products.aspose.com/slides/php-java/conversion/pdf-to-html/), [PDF in immagine](https://products.aspose.com/slides/php-java/conversion/pdf-to-image/), [PDF in JPG](https://products.aspose.com/slides/php-java/conversion/pdf-to-jpg/), e [PDF in PNG](https://products.aspose.com/slides/php-java/conversion/pdf-to-png/) . Altre operazioni di conversione PDF in formati specializzati—[PDF in SVG](https://products.aspose.com/slides/php-java/conversion/pdf-to-svg/), [PDF in TIFF](https://products.aspose.com/slides/php-java/conversion/pdf-to-tiff/), e [PDF in XML](https://products.aspose.com/slides/php-java/conversion/pdf-to-xml/)—sono anch'esse supportate.
{{% /alert %}}

> **Nota:** Quando si esporta in PDF/UA, Aspose.Slides tratta le grafiche complesse come SmartArt, diagrammi e formule come un'unica figura. Gli elementi di percorso individuali non vengono conservati come contenuti separati e possono essere contrassegnati come artefatti; il testo alternativo è fornito solo per l'intera figura.

## **Domande Frequenti**

**Posso convertire più file PowerPoint in PDF in blocco?**  
Sì, Aspose.Slides supporta la conversione batch di più file PPT o PPTX in PDF. Puoi iterare sui tuoi file e applicare il processo di conversione programmaticamente.

**È possibile proteggere con password il PDF convertito?**  
Sì. Usa la classe [PdfOptions](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/) per impostare una password e definire le autorizzazioni di accesso durante il processo di conversione.

**Come includo le diapositive nascoste nel PDF?**  
Chiama [setShowHiddenSlides](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/setshowhiddenslides/) con `true` nella classe [PdfOptions](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/) per includere le diapositive nascoste nel PDF risultante.

**Aspose.Slides può mantenere alta qualità delle immagini nel PDF?**  
Sì, puoi controllare la qualità delle immagini usando metodi come [setJpegQuality](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/setjpegquality/) e [setSufficientResolution](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/setsufficientresolution/) nella classe [PdfOptions](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/) per garantire immagini ad alta qualità nel tuo PDF.

**Aspose.Slides supporta gli standard di conformità PDF/A?**  
Sì, Aspose.Slides ti consente di esportare PDF che rispettano [vari standard](https://reference.aspose.com/slides/php-java/aspose.slides/pdfcompliance/), inclusi PDF/A1a, PDF/A1b e PDF/UA, garantendo che i tuoi documenti soddisfino i requisiti di accessibilità e archiviazione.

## **Risorse Aggiuntive**

- [Aspose.Slides per PHP via Java Documentazione](/slides/it/php-java/)
- [Aspose.Slides per PHP via Java Riferimento API](https://reference.aspose.com/slides/php-java/)
- [Convertitori Online Gratuiti Aspose](https://products.aspose.app/slides/conversion)