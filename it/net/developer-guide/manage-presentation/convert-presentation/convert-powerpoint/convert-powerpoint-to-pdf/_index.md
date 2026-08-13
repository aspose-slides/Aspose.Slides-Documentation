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

Convertire presentazioni PowerPoint (PPT, PPTX, ODP, ecc.) in formato PDF in C# offre diversi vantaggi, tra cui la compatibilità su dispositivi diversi e la conservazione del layout e della formattazione della presentazione. Questa guida mostra come convertire le presentazioni in documenti PDF, utilizzare varie opzioni per controllare la qualità delle immagini, includere diapositive nascoste, proteggere con password i file PDF, rilevare sostituzioni di font, selezionare diapositive specifiche per la conversione e applicare standard di conformità ai documenti di output.

## **Conversioni da PowerPoint a PDF**

Utilizzando Aspose.Slides, è possibile convertire presentazioni nei seguenti formati in PDF:

* **PPT**
* **PPTX**
* **ODP**

Per convertire una presentazione in PDF, passa il nome del file come argomento alla classe [Presentation](https://reference.aspose.com/slides/it/net/aspose.slides/presentation/) e poi salva la presentazione come PDF utilizzando il metodo [Save](https://reference.aspose.com/slides/it/net/aspose.slides/presentation/save/). La classe [Presentation](https://reference.aspose.com/slides/it/net/aspose.slides/presentation/) espone il metodo [Save](https://reference.aspose.com/slides/it/net/aspose.slides/presentation/save/) tipicamente usato per convertire una presentazione in PDF.

{{%  alert title="NOTE"  color="warning"   %}} 

Aspose.Slides per .NET inserisce le informazioni API e il numero di versione nei documenti di output. Ad esempio, durante la conversione di una presentazione in PDF, Aspose.Slides popola il campo Application con "*Aspose.Slides*" e il campo PDF Producer con un valore nella forma "*Aspose.Slides v XX.XX*". **Note** che non è possibile indicare ad Aspose.Slides di modificare o rimuovere queste informazioni dai documenti di output.

{{% /alert %}}

Aspose.Slides ti consente di convertire:

* Presentazioni intere in PDF
* Diapositive specifiche da una presentazione in PDF

Aspose.Slides esporta le presentazioni in PDF, garantendo che i PDF risultanti corrispondano strettamente alle presentazioni originali. Elementi e attributi sono renderizzati accuratamente nella conversione, inclusi:

* Immagini
* Caselle di testo e forme
* Formattazione del testo
* Formattazione del paragrafo
* Collegamenti ipertestuali
* Intestazioni e piè di pagina
* Punti elenco
* Tabelle

## **Convertire PowerPoint in PDF**

Il processo standard di conversione PowerPoint‑to‑PDF utilizza le opzioni predefinite. In questo caso, Aspose.Slides tenta di convertire la presentazione fornita in PDF usando impostazioni ottimali ai massimi livelli di qualità.

Questo codice C# mostra come convertire una presentazione (PPT, PPTX, ODP, ecc.) in PDF:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// Istanzia la classe Presentation che rappresenta un file PowerPoint o OpenDocument.
using var presentation = new Presentation("PowerPoint.ppt");

// Salva la presentazione come PDF.
presentation.Save("PDF-result.pdf", SaveFormat.Pdf);
```

{{%  alert  color="info"  %}} 

Aspose offre un **convertitore gratuito online PowerPoint to PDF**(https://products.aspose.app/slides/it/conversion/ppt-to-pdf) che dimostra il processo di conversione da presentazione a PDF. Puoi eseguire un test con questo convertitore per una implementazione live della procedura descritta qui.

{{% /alert %}}

## **Convertire PowerPoint in PDF con Opzioni**

Aspose.Slides fornisce opzioni personalizzate—proprietà della classe [PdfOptions](https://reference.aspose.com/slides/it/net/aspose.slides.export/pdfoptions/)—che consentono di personalizzare il PDF risultante, bloccarlo con una password o specificare come deve procedere il processo di conversione.

### **Convertire PowerPoint in PDF con Opzioni Personalizzate**

Utilizzando opzioni di conversione personalizzate, è possibile definire l'impostazione di qualità preferita per le immagini raster, specificare come gestire i metafile, impostare un livello di compressione per il testo, configurare i DPI per le immagini e altro.

L'esempio di codice seguente dimostra come convertire una presentazione PowerPoint in PDF con diverse opzioni personalizzate.

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// Istanzia la classe PdfOptions.
var pdfOptions = new PdfOptions
{
    // Imposta la qualità per le immagini JPG.
    JpegQuality = 90,

    // Imposta i DPI per le immagini.
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

### **Convertire PowerPoint in PDF con Diapositive Nascoste**

Se una presentazione contiene diapositive nascoste, è possibile utilizzare la proprietà [ShowHiddenSlides](https://reference.aspose.com/slides/it/net/aspose.slides.export/pdfoptions/showhiddenslides/) della classe [PdfOptions](https://reference.aspose.com/slides/it/net/aspose.slides.export/pdfoptions/) per includere le diapositive nascoste come pagine nel PDF risultante.

Questo codice C# mostra come convertire una presentazione PowerPoint in PDF includendo le diapositive nascoste:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// Istanzia la classe Presentation che rappresenta un file PowerPoint o OpenDocument.
using var presentation = new Presentation("PowerPoint.pptx");

// Istanzia la classe PdfOptions.
var pdfOptions = new PdfOptions();

// Aggiungi diapositive nascoste.
pdfOptions.ShowHiddenSlides = true;

// Salva la presentazione come PDF.
presentation.Save("PowerPoint-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
```

### **Convertire PowerPoint in PDF Protetto da Password**

Questo codice C# dimostra come convertire una presentazione PowerPoint in un PDF protetto da password utilizzando i parametri di protezione della classe [PdfOptions](https://reference.aspose.com/slides/it/net/aspose.slides.export/pdfoptions/):

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// Istanzia la classe Presentation che rappresenta un file PowerPoint o OpenDocument.
using var presentation = new Presentation("PowerPoint.pptx");

// Istanzia la classe PdfOptions.
var pdfOptions = new PdfOptions();

// Imposta una password PDF e le autorizzazioni di accesso.
pdfOptions.Password = "password";
pdfOptions.AccessPermissions = PdfAccessPermissions.PrintDocument | PdfAccessPermissions.HighQualityPrint;

// Salva la presentazione come PDF.
presentation.Save("PPTX-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
```

### **Rilevare Sostituzioni di Font**

Aspose.Slides fornisce la proprietà [WarningCallback](https://reference.aspose.com/slides/it/net/aspose.slides.export/saveoptions/warningcallback/) nella classe [PdfOptions](https://reference.aspose.com/slides/it/net/aspose.slides.export/pdfoptions/) che consente di rilevare le sostituzioni di font durante il processo di conversione da presentazione a PDF.

Questo codice C# mostra come rilevare le sostituzioni di font:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Warnings;

public static void Main()
{
    // Istanzia la classe Presentation che rappresenta un file PowerPoint o OpenDocument.
    using var presentation = new Presentation("sample.pptx");

    // Imposta il callback di avviso nelle opzioni PDF.
    var pdfOptions = new PdfOptions();
    pdfOptions.WarningCallback = new FontSubstitutionHandler();

    // Salva la presentazione come PDF.
    presentation.Save("output.pdf", SaveFormat.Pdf, pdfOptions);
}

// Implementazione del callback di avviso.
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

{{%  alert color="info"  %}} 

Per ulteriori informazioni sulla ricezione di callback per le sostituzioni di font durante il rendering, vedere [Getting Warning Callbacks for Fonts Substitution](/slides/it/net/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/).

Per ulteriori informazioni sulla sostituzione dei font, vedere l'articolo [Font Substitution](/slides/it/net/font-substitution/).

{{% /alert %}} 

## **Convertire Diapositive Selezionate da PowerPoint in PDF**

Questo codice C# dimostra come convertire solo diapositive specifiche da una presentazione PowerPoint in PDF:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// Istanzia la classe Presentation che rappresenta un file PowerPoint o OpenDocument.
using var presentation = new Presentation("PowerPoint.pptx");

// Imposta l'array di numeri delle diapositive.
int[] slides = { 1, 3 };

// Salva la presentazione come PDF.
presentation.Save("PPTX-to-PDF.pdf", slides, SaveFormat.Pdf);
```

## **Convertire PowerPoint in PDF con Dimensione Diapositiva Personalizzata**

Questo codice C# dimostra come convertire una presentazione PowerPoint in PDF con una dimensione diapositiva specificata:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

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

// Remove the blank slide that the new presentation was created with.
resizedPresentation.Slides.RemoveAt(1);

// Save the resized presentation as a PDF.
resizedPresentation.Save("PDF_with_custom_slide_size.pdf", SaveFormat.Pdf);
```

## **Convertire PowerPoint in PDF nella Vista Note Diapositiva**

Questo codice C# dimostra come convertire una presentazione PowerPoint in un PDF che includa le note:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// Carica una presentazione PowerPoint.
using var presentation = new Presentation("NotesFile.pptx");

// Configura le opzioni PDF con layout note.
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

Aspose.Slides consente di utilizzare una procedura di conversione che rispetta le [Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html). È possibile esportare un documento PowerPoint in PDF utilizzando uno dei seguenti standard di conformità: **PDF/A1a**, **PDF/A1b** e **PDF/UA**.

Questo codice C# dimostra un processo di conversione PowerPoint‑to‑PDF che produce più PDF in base a diversi standard di conformità:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

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

{{% alert title="Note" color="warning" %}} 

Aspose.Slides supporta operazioni di conversione PDF, consentendo di convertire file PDF in formati di file popolari. È possibile eseguire conversioni [PDF to HTML](https://products.aspose.com/slides/it/net/conversion/pdf-to-html/), [PDF to image](https://products.aspose.com/slides/it/net/conversion/pdf-to-image/), [PDF to JPG](https://products.aspose.com/slides/it/net/conversion/pdf-to-jpg/) e [PDF to PNG](https://products.aspose.com/slides/it/net/conversion/pdf-to-png/). Sono supportate anche altre operazioni di conversione PDF verso formati specializzati—[PDF to SVG](https://products.aspose.com/slides/it/net/conversion/pdf-to-svg/), [PDF to TIFF](https://products.aspose.com/slides/it/net/conversion/pdf-to-tiff/), e [PDF to XML](https://products.aspose.com/slides/it/net/conversion/pdf-to-xml/)—.

{{% /alert %}}

> **Note:** Quando si esporta in PDF/UA, Aspose.Slides tratta grafica complessa come SmartArt, grafici e formule come un’unica figura. Gli elementi di percorso individuali non sono conservati come contenuti separati e possono essere contrassegnati come artefatti; il testo alternativo è fornito solo per l’intera figura.

## **FAQ**

### Posso convertire più file PowerPoint in PDF in blocco?

Sì, Aspose.Slides supporta la conversione batch di più file PPT o PPTX in PDF. È possibile iterare sui file e applicare il processo di conversione programmaticamente.

### È possibile proteggere con password il PDF convertito?

Assolutamente. Usa la classe [PdfOptions](https://reference.aspose.com/slides/it/net/aspose.slides.export/pdfoptions/) per impostare una password e definire le autorizzazioni di accesso durante il processo di conversione.

### Come includere le diapositive nascoste nel PDF?

Imposta la proprietà `ShowHiddenSlides` nella classe [PdfOptions](https://reference.aspose.com/slides/it/net/aspose.slides.export/pdfoptions/) su `true` per includere le diapositive nascoste nel PDF risultante.

### Aspose.Slides può mantenere alta la qualità delle immagini nel PDF?

Sì, è possibile controllare la qualità delle immagini impostando proprietà come `JpegQuality` e `SufficientResolution` nella classe [PdfOptions](https://reference.aspose.com/slides/it/net/aspose.slides.export/pdfoptions/) per garantire immagini ad alta qualità nel PDF.

### Aspose.Slides supporta gli standard di conformità PDF/A?

Sì, Aspose.Slides consente di esportare PDF conformi a vari standard, inclusi PDF/A1a, PDF/A1b e PDF/UA, assicurando che i documenti soddisfino i requisiti di accessibilità e archiviazione.

## **Risorse Aggiuntive**

- [Aspose.Slides for .NET Documentation](/slides/it/net/)
- [Aspose.Slides for .NET API Reference](https://reference.aspose.com/slides/it/net/)
- [Aspose Free Online Converters](https://products.aspose.app/slides/it/conversion)