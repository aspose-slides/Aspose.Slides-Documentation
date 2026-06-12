---
title: Converti PPT e PPTX in PDF in .NET [Funzionalità Avanzate Incluse]
linktitle: PowerPoint in PDF
type: docs
weight: 40
url: /it/net/convert-powerpoint-to-pdf/
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
- .NET
- C#
- Aspose.Slides
description: "Converti PowerPoint PPT/PPTX in PDF di alta qualità e ricercabili in .NET usando Aspose.Slides, con esempi di codice C# veloci e opzioni di conversione avanzate."
---
## **Panoramica**

Convertire presentazioni PowerPoint (PPT, PPTX, ODP, ecc.) in formato PDF in C# offre diversi vantaggi, tra cui la compatibilità su dispositivi diversi e la conservazione del layout e della formattazione della presentazione. Questa guida dimostra come convertire le presentazioni in documenti PDF, utilizzare varie opzioni per controllare la qualità delle immagini, includere diapositive nascoste, proteggere con password i file PDF, rilevare le sostituzioni di caratteri, selezionare diapositive specifiche per la conversione e applicare standard di conformità ai documenti di output.

## **Conversioni da PowerPoint a PDF**

Utilizzando Aspose.Slides, è possibile convertire presentazioni nei seguenti formati in PDF:

* **PPT**
* **PPTX**
* **ODP**

Per convertire una presentazione in PDF, passare il nome del file come argomento alla classe [Presentation](https://reference.aspose.com/slides/it/net/aspose.slides/presentation/) e quindi salvare la presentazione come PDF utilizzando il metodo [Save](https://reference.aspose.com/slides/it/net/aspose.slides/presentation/save/). La classe [Presentation](https://reference.aspose.com/slides/it/net/aspose.slides/presentation/) espone il metodo [Save](https://reference.aspose.com/slides/it/net/aspose.slides/presentation/save/) che è generalmente usato per convertire una presentazione in PDF.

{{%  alert title="Nota"  color="warning"   %}} 

Aspose.Slides per .NET inserisce le informazioni sull'API e il numero di versione nei documenti di output. Ad esempio, durante la conversione di una presentazione in PDF, Aspose.Slides popola il campo Application con "*Aspose.Slides*" e il campo PDF Producer con un valore nella forma "*Aspose.Slides v XX.XX*". **Nota** che non è possibile istruire Aspose.Slides a modificare o rimuovere queste informazioni dai documenti di output.

{{% /alert %}}

Aspose.Slides consente di convertire:

* Intere presentazioni in PDF
* Diapositive specifiche di una presentazione in PDF

Aspose.Slides esporta le presentazioni in PDF, garantendo che i PDF risultanti corrispondano strettamente alle presentazioni originali. Gli elementi e gli attributi vengono renderizzati accuratamente nella conversione, includendo:

* Immagini
* Caselle di testo e forme
* Formattazione del testo
* Formattazione dei paragrafi
* Collegamenti ipertestuali
* Intestazioni e piè di pagina
* Elenchi puntati
* Tabelle

## **Converti PowerPoint in PDF**

La procedura standard di conversione da PowerPoint a PDF utilizza le opzioni predefinite. In questo caso, Aspose.Slides tenta di convertire la presentazione fornita in PDF utilizzando impostazioni ottimali al livello di massima qualità.

Questo codice C# mostra come convertire una presentazione (PPT, PPTX, ODP, ecc.) in PDF:

```c#
// Istanzia la classe Presentation che rappresenta un file PowerPoint o OpenDocument.
using var presentation = new Presentation("PowerPoint.ppt");

// Salva la presentazione come PDF.
presentation.Save("PDF-result.pdf", SaveFormat.Pdf);
```

{{%  alert  color="primary"  %}} 

Aspose offre un [**convertitore PowerPoint in PDF**](https://products.aspose.app/slides/it/conversion/ppt-to-pdf) gratuito online che dimostra il processo di conversione da presentazione a PDF. È possibile eseguire un test con questo convertitore per una implementazione reale della procedura descritta qui.

{{% /alert %}}

## **Converti PowerPoint in PDF con Opzioni**

Aspose.Slides fornisce opzioni personalizzate—proprietà della classe [PdfOptions](https://reference.aspose.com/slides/it/net/aspose.slides.export/pdfoptions/)—che consentono di personalizzare il PDF risultante, bloccare il PDF con una password o specificare come deve procedere il processo di conversione.

### **Converti PowerPoint in PDF con Opzioni Personalizzate**

Utilizzando opzioni di conversione personalizzate, è possibile definire le impostazioni di qualità preferite per le immagini raster, specificare come gestire i metafile, impostare un livello di compressione per il testo, configurare DPI per le immagini e altro.

L'esempio di codice seguente dimostra come convertire una presentazione PowerPoint in PDF con diverse opzioni personalizzate.

```c#
 // Istanzia la classe PdfOptions.
 var pdfOptions = new PdfOptions
 {
     // Imposta la qualità per le immagini JPG.
     JpegQuality = 90,

     // Imposta DPI per le immagini.
     SufficientResolution = 300,

     // Imposta il comportamento per i metafili.
     SaveMetafilesAsPng = true,

     // Imposta il livello di compressione del testo per il contenuto testuale.
     TextCompression = PdfTextCompression.Flate,

     // Definisci la modalità di conformità PDF.
     Compliance = PdfCompliance.Pdf15
 };

 // Istanzia la classe Presentation che rappresenta un file PowerPoint o OpenDocument.
 using var presentation = new Presentation("PowerPoint.pptx");

 // Salva la presentazione come documento PDF.
 presentation.Save("PowerPoint-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
```

### **Converti PowerPoint in PDF con Diapositive Nascoste**

Se una presentazione contiene diapositive nascoste, è possibile utilizzare la proprietà [ShowHiddenSlides](https://reference.aspose.com/slides/it/net/aspose.slides.export/pdfoptions/showhiddenslides/) della classe [PdfOptions](https://reference.aspose.com/slides/it/net/aspose.slides.export/pdfoptions/) per includere le diapositive nascoste come pagine nel PDF risultante.

Questo codice C# mostra come convertire una presentazione PowerPoint in PDF includendo le diapositive nascoste:

```c#
// Istanzia la classe Presentation che rappresenta un file PowerPoint o OpenDocument.
using var presentation = new Presentation("PowerPoint.pptx");

// Istanzia la classe PdfOptions.
var pdfOptions = new PdfOptions();

// Aggiungi le diapositive nascoste.
pdfOptions.ShowHiddenSlides = true;

// Salva la presentazione come PDF.
presentation.Save("PowerPoint-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
```

### **Converti PowerPoint in PDF Protetto da Password**

Questo codice C# dimostra come convertire una presentazione PowerPoint in un PDF protetto da password utilizzando i parametri di protezione della classe [PdfOptions](https://reference.aspose.com/slides/it/net/aspose.slides.export/pdfoptions/):

```c#
 // Istanzia la classe Presentation che rappresenta un file PowerPoint o OpenDocument.
 using var presentation = new Presentation("PowerPoint.pptx");

 // Istanzia la classe PdfOptions.
 var pdfOptions = new PdfOptions();

 // Imposta una password PDF e i permessi di accesso.
 pdfOptions.Password = "password";
 pdfOptions.AccessPermissions = PdfAccessPermissions.PrintDocument | PdfAccessPermissions.HighQualityPrint;

 // Salva la presentazione come PDF.
 presentation.Save("PPTX-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
```

### **Rileva Sostituzioni di Font**

Aspose.Slides fornisce la proprietà [WarningCallback](https://reference.aspose.com/slides/it/net/aspose.slides.export/saveoptions/warningcallback/) nella classe [PdfOptions](https://reference.aspose.com/slides/it/net/aspose.slides.export/pdfoptions/), consentendo di rilevare le sostituzioni di font durante il processo di conversione da presentazione a PDF.

Questo codice C# mostra come rilevare le sostituzioni di font:

```c#
public static void Main()
{
    // Istanzia la classe Presentation che rappresenta un file PowerPoint o OpenDocument. 
    using var presentation = new Presentation("sample.pptx");

    // Imposta la callback di avviso nelle opzioni PDF.
    var pdfOptions = new PdfOptions();
    pdfOptions.WarningCallback = new FontSubstitutionHandler();

    // Salva la presentazione come PDF.
    presentation.Save("output.pdf", SaveFormat.Pdf, pdfOptions);
}

// Implementazione della callback di avviso.
private class FontSubstitutionHandler : IWarningCallback
{
    public ReturnAction Warning(IWarningInfo warning)
    {
        if (warning.WarningType == WarningType.DataLoss &&
            warning.Description.StartsWith("Font will be substituted"))
        {
            Console.WriteLine($"Font substitution warning: {warning.Description}");
        }

        return ReturnAction.Continue;
    }
}
```

{{%  alert color="primary"  %}} 

Per ulteriori informazioni su come ricevere callback per le sostituzioni di font durante il processo di rendering, vedere [Ottenere Callback di Avviso per la Sostituzione dei Font](/slides/it/net/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/).

Per ulteriori informazioni sulla sostituzione di font, vedere l'articolo [Font Substitution](/slides/it/net/font-substitution/).

{{% /alert %}} 

## **Converti Diapositive Selezionate da PowerPoint in PDF**

Questo codice C# dimostra come convertire solo diapositive specifiche da una presentazione PowerPoint in PDF:

```c#
// Istanzia la classe Presentation che rappresenta un file PowerPoint o OpenDocument.
using var presentation = new Presentation("PowerPoint.pptx");

// Imposta l'array dei numeri di diapositiva.
int[] slides = { 1, 3 };

// Salva la presentazione come PDF.
presentation.Save("PPTX-to-PDF.pdf", slides, SaveFormat.Pdf);
```

## **Converti PowerPoint in PDF con Dimensione Diapositiva Personalizzata**

Questo codice C# dimostra come convertire una presentazione PowerPoint in PDF con una dimensione diapositiva specificata:

```c#
var slideWidth = 612;
var slideHeight = 792;

// Load a PowerPoint presentation.
using var presentation = new Presentation("SelectedSlides.pptx");

// Create a new presentation with an adjusted slide size.
using var resizedPresentation = new Presentation();

// Set the custom slide size.
resizedPresentation.SlideSize.SetSize(slideWidth, slideHeight, SlideSizeScaleType.EnsureFit);

// Clone the first slide from the original presentation.
var slide = presentation.Slides[0];
resizedPresentation.Slides.InsertClone(0, slide);

// Save the resized presentation to a PDF with notes.
resizedPresentation.Save("PDF_with_notes.pdf", SaveFormat.Pdf);
```

## **Converti PowerPoint in PDF nella Vista Note di Diapositiva**

Questo codice C# dimostra come convertire una presentazione PowerPoint in un PDF che include le note:

```c#
// Carica una presentazione PowerPoint.
using var presentation = new Presentation("NotesFile.pptx");

// Configura le opzioni PDF con layout delle note.
var pdfOptions = new PdfOptions
{
    SlidesLayoutOptions = new NotesCommentsLayoutingOptions
    {
        NotesPosition = NotesPositions.BottomFull
    }
};

// Salva la presentazione in un PDF con note.
presentation.Save("PDF_with_notes.pdf", SaveFormat.Pdf, pdfOptions);
```

## **Accessibilità e Standard di Conformità per PDF**

Aspose.Slides consente di utilizzare una procedura di conversione che rispetta le [Linee Guida per l'Accessibilità dei Contenuti Web (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html). È possibile esportare un documento PowerPoint in PDF utilizzando uno qualsiasi di questi standard di conformità: **PDF/A1a**, **PDF/A1b** e **PDF/UA**.

Questo codice C# dimostra un processo di conversione da PowerPoint a PDF che produce più PDF basati su diversi standard di conformità:

```c#
using var presentation = new Presentation("pres.pptx");

presentation.Save("pres-a1a-compliance.pdf", SaveFormat.Pdf, new PdfOptions
{
    Compliance = PdfCompliance.PdfA1a
});

presentation.Save("pres-a1b-compliance.pdf", SaveFormat.Pdf, new PdfOptions
{
    Compliance = PdfCompliance.PdfA1b
});

presentation.Save("pres-ua-compliance.pdf", SaveFormat.Pdf, new PdfOptions
{
    Compliance = PdfCompliance.PdfUa
});
```

{{% alert title="Nota" color="warning" %}} 

Aspose.Slides supporta le operazioni di conversione PDF, consentendo di convertire i file PDF in formati di file popolari. È possibile eseguire conversioni da [PDF in HTML](https://products.aspose.com/slides/it/net/conversion/pdf-to-html/), [PDF in immagine](https://products.aspose.com/slides/it/net/conversion/pdf-to-image/), [PDF in JPG](https://products.aspose.com/slides/it/net/conversion/pdf-to-jpg/), e [PDF in PNG](https://products.aspose.com/slides/it/net/conversion/pdf-to-png/). Altre operazioni di conversione PDF verso formati specializzati—[PDF in SVG](https://products.aspose.com/slides/it/net/conversion/pdf-to-svg/), [PDF in TIFF](https://products.aspose.com/slides/it/net/conversion/pdf-to-tiff/), e [PDF in XML](https://products.aspose.com/slides/it/net/conversion/pdf-to-xml/)—sono anch'esse supportate.

{{% /alert %}}

> **Nota:** Durante l'esportazione in PDF/UA, Aspose.Slides tratta le grafiche complesse come SmartArt, diagrammi e formule come un'unica figura. Gli elementi di percorso individuali non sono conservati come contenuti separati e potrebbero essere contrassegnati come artefatti; il testo alternativo è fornito solo per l'intera figura.

## **FAQ**

**Posso convertire più file PowerPoint in PDF in batch?**

Sì, Aspose.Slides supporta la conversione batch di più file PPT o PPTX in PDF. È possibile iterare sui propri file e applicare il processo di conversione programmaticamente.

**È possibile proteggere con password il PDF convertito?**

Assolutamente. Utilizzare la classe [PdfOptions](https://reference.aspose.com/slides/it/net/aspose.slides.export/pdfoptions/) per impostare una password e definire i permessi di accesso durante il processo di conversione.

**Come includere le diapositive nascoste nel PDF?**

Impostare la proprietà `ShowHiddenSlides` nella classe [PdfOptions](https://reference.aspose.com/slides/it/net/aspose.slides.export/pdfoptions/) a `true` per includere le diapositive nascoste nel PDF risultante.

**Aspose.Slides può mantenere alta qualità delle immagini nel PDF?**

Sì, è possibile controllare la qualità dell'immagine impostando proprietà come `JpegQuality` e `SufficientResolution` nella classe [PdfOptions](https://reference.aspose.com/slides/it/net/aspose.slides.export/pdfoptions/) per garantire immagini ad alta qualità nel PDF.

**Aspose.Slides supporta gli standard di conformità PDF/A?**

Sì, Aspose.Slides permette di esportare PDF conformi a vari standard, inclusi PDF/A1a, PDF/A1b e PDF/UA, assicurando che i documenti soddisfino i requisiti di accessibilità e archivio.

## **Risorse Aggiuntive**

- [Documentazione Aspose.Slides per .NET](/slides/it/net/)
- [Riferimento API Aspose.Slides per .NET](https://reference.aspose.com/slides/it/net/)
- [Convertitori Online Gratuiti Aspose](https://products.aspose.app/slides/it/conversion)