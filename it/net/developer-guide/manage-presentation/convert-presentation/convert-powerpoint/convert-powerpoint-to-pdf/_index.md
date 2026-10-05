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
- allegato
- PDF/A1a
- PDF/A1b
- PDF/UA
- .NET
- C#
- Aspose.Slides
description: "Converti PowerPoint PPT/PPTX in PDF di alta qualità e ricercabili in .NET usando Aspose.Slides, con esempi di codice C# rapidi e opzioni di conversione avanzate."
---
## **Panoramica**

Convertire presentazioni PowerPoint (PPT, PPTX, ODP, ecc.) in formato PDF in C# offre diversi vantaggi, inclusa la compatibilità tra diversi dispositivi e la conservazione del layout e della formattazione della presentazione. Questa guida dimostra come convertire le presentazioni in documenti PDF, utilizzare varie opzioni per controllare la qualità delle immagini, includere diapositive nascoste, proteggere con password i file PDF, rilevare le sostituzioni di caratteri, selezionare diapositive specifiche per la conversione e applicare standard di conformità ai documenti di output.

## **Conversioni da PowerPoint a PDF**

Utilizzando Aspose.Slides, è possibile convertire le presentazioni nei seguenti formati in PDF:

* **PPT**
* **PPTX**
* **ODP**

Per convertire una presentazione in PDF, passa il nome del file come argomento alla classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) e poi salva la presentazione come PDF usando il metodo [Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/). La classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) espone il metodo [Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/) che è tipicamente utilizzato per convertire una presentazione in PDF.

{{% alert color="info" title="Note" %}}

Aspose.Slides per .NET inserisce le informazioni sull'API e il numero di versione nei documenti di output. Ad esempio, durante la conversione di una presentazione in PDF, Aspose.Slides popola il campo Application con "*Aspose.Slides*" e il campo PDF Producer con un valore nella forma "*Aspose.Slides v XX.XX*". **Nota** che non è possibile istruire Aspose.Slides a modificare o rimuovere queste informazioni dai documenti di output.

{{% /alert %}}

Aspose.Slides consente di convertire:

* Intere presentazioni in PDF
* Diapositive specifiche di una presentazione in PDF

Aspose.Slides esporta le presentazioni in PDF, garantendo che i PDF risultanti corrispondano fedelmente alle presentazioni originali. Elementi e attributi vengono renderizzati accuratamente nella conversione, inclusi:

* Immagini
* Caselle di testo e forme
* Formattazione del testo
* Formattazione dei paragrafi
* Collegamenti ipertestuali
* Intestazioni e piè di pagina
* Elenchi puntati
* Tabelle

## **Converti PowerPoint in PDF**

Il processo standard di conversione da PowerPoint a PDF utilizza le opzioni predefinite. In questo caso, Aspose.Slides tenta di convertire la presentazione fornita in PDF usando impostazioni ottimali al massimo livello di qualità.

L'esempio seguente carica una presentazione e salva tutte le diapositive visibili in PDF usando le impostazioni di esportazione predefinite.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("PowerPoint.ppt");
presentation.Save("PDF-result.pdf", SaveFormat.Pdf);
```

{{% alert color="info" title="Note" %}}

Aspose offre un gratuito convertitore online [**Convertitore PowerPoint in PDF**](https://products.aspose.app/slides/conversion/ppt-to-pdf) che dimostra il processo di conversione da presentazione a PDF. Puoi eseguire un test con questo convertitore per una versione live della procedura descritta qui.

{{% /alert %}}

## **Converti PowerPoint in PDF con Opzioni**

Aspose.Slides fornisce opzioni personalizzate—proprietà della classe [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/)—che consentono di personalizzare il PDF risultante, bloccare il PDF con una password o specificare come deve procedere il processo di conversione.

### **Converti PowerPoint in PDF con Opzioni Personalizzate**

Utilizzando opzioni di conversione personalizzate, è possibile definire l'impostazione di qualità preferita per le immagini raster, specificare come gestire i metafile, impostare un livello di compressione per il testo, configurare i DPI per le immagini e altro ancora.

L'esempio seguente esporta una presentazione in PDF 1.5 con qualità JPEG impostata a 90, risoluzione dell'immagine impostata a 300 DPI, metafile salvati come PNG e compressione testo Flate.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

var pdfOptions = new PdfOptions
{
    JpegQuality = 90,
    SufficientResolution = 300,
    SaveMetafilesAsPng = true,
    TextCompression = PdfTextCompression.Flate,
    Compliance = PdfCompliance.Pdf15
};

using var presentation = new Presentation("PowerPoint.pptx");
presentation.Save("PowerPoint-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
```

### **Conserva i file OLE incorporati come allegati PDF**

Se una presentazione contiene una cartella di lavoro Excel incorporata, potresti voler consentire ai destinatari del PDF di accedere ai dati della cartella di lavoro oltre a visualizzare le diapositive. Imposta [PdfOptions.IncludeOleData](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/includeoledata/) su `true` per conservare i file OLE incorporati come allegati nel PDF risultante.

Il valore predefinito è `false`: l'immagine di anteprima o l'icona dell'oggetto OLE viene visualizzata nella pagina PDF, ma il file incorporato non è incluso come allegato. Impostando l'opzione su `true` il file viene aggiunto come allegato. L'anteprima rimane una rappresentazione visiva; l'allegato consente ai destinatari di aprire o salvare il file incorporato separatamente. L'oggetto OLE non diventa un foglio di calcolo Excel interattivo nella pagina PDF.

L'esempio seguente carica una presentazione che contiene già una cartella di lavoro Excel incorporata ed esporta il PDF con la cartella di lavoro allegata.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

var pdfOptions = new PdfOptions { IncludeOleData = true };

using var presentation = new Presentation("presentation.pptx");
presentation.Save("presentation.pdf", SaveFormat.Pdf, pdfOptions);
```

Per verificare il risultato:

1. Apri il PDF esportato in un visualizzatore che supporta gli allegati, come Adobe Acrobat Reader.
2. Apri il pannello **Allegati** del visualizzatore e individua la cartella di lavoro incorporata.
3. Salva l'allegato e aprilo in Excel per ispezionare i dati, o aprilo direttamente se il visualizzatore lo consente. L'anteprima nella pagina PDF è separata dall'allegato.

{{% alert color="info" title="Note" %}}

Gli standard PDF/A impongono restrizioni sugli allegati: PDF/A-1 vieta i file incorporati, PDF/A-2 consente solo allegati PDF/A, e PDF/A-3 ammette altri tipi di file, incluse le cartelle di lavoro Excel. Questi sono requisiti degli standard, non restrizioni specifiche di Aspose.Slides. Questo esempio utilizza l'impostazione di conformità PDF predefinita e non dimostra l'esportazione PDF/A.

{{% /alert %}}

### **Converti PowerPoint in PDF con Diapositive Nascoste**

Se una presentazione contiene diapositive nascoste, è possibile utilizzare la proprietà [ShowHiddenSlides](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/showhiddenslides/) della classe [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/) per includere le diapositive nascoste come pagine nel PDF risultante.

L'esempio seguente esporta una presentazione in PDF, includendo eventuali diapositive nascoste.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

var pdfOptions = new PdfOptions();
pdfOptions.ShowHiddenSlides = true;

using var presentation = new Presentation("PowerPoint.pptx");
presentation.Save("PowerPoint-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
```

### **Converti PowerPoint in un PDF protetto da password**

L'esempio seguente esporta una presentazione in un PDF che richiede la password `password` per l'apertura. Le autorizzazioni di accesso consentono la stampa, inclusa la stampa ad alta qualità.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

var pdfOptions = new PdfOptions();
pdfOptions.Password = "password";
pdfOptions.AccessPermissions = PdfAccessPermissions.PrintDocument | PdfAccessPermissions.HighQualityPrint;

using var presentation = new Presentation("PowerPoint.pptx");
presentation.Save("PPTX-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
```

### **Rileva Sostituzioni di Font**

Aspose.Slides fornisce la proprietà [WarningCallback](https://reference.aspose.com/slides/net/aspose.slides.export/saveoptions/warningcallback/) della classe [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/), che consente di rilevare le sostituzioni di font durante il processo di conversione da presentazione a PDF.

L'esempio seguente esporta una presentazione in PDF e stampa avvisi di sostituzione dei font nella console. Un avviso viene stampato solo quando un font non disponibile viene sostituito durante l'esportazione.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Warnings;
using System;

var pdfOptions = new PdfOptions();
pdfOptions.WarningCallback = new FontSubstitutionHandler();

using var presentation = new Presentation("sample.pptx");
presentation.Save("output.pdf", SaveFormat.Pdf, pdfOptions);

class FontSubstitutionHandler : IWarningCallback
{
    public ReturnAction Warning(IWarningInfo warning)
    {
        if (warning.WarningType == WarningType.DataLoss && warning.Description.StartsWith("Font will be substituted"))
        {
            Console.WriteLine($"Font substitution warning: {warning.Description}");
        }

        return ReturnAction.Continue;
    }
}
```

{{% alert color="info" title="Note" %}}

Per ulteriori informazioni sulla sostituzione dei font, vedi l'articolo [Sostituzione dei Font](/slides/it/net/font-substitution/).

{{% /alert %}} 

## **Converti Diapositive Selezionate da PowerPoint in PDF**

L'esempio seguente esporta le diapositive 1 e 3 da una presentazione in PDF. I numeri delle diapositive in questo array partono da uno, e la presentazione di ingresso deve contenere almeno tre diapositive.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("PowerPoint.pptx");
var slides = new[] { 1, 3 };
presentation.Save("PPTX-to-PDF.pdf", slides, SaveFormat.Pdf);
```

## **Converti PowerPoint in PDF con Dimensioni Diapositiva Personalizzate**

L'esempio seguente copia la prima diapositiva da una presentazione in una nuova presentazione con una dimensione diapositiva di 612 × 792 punti (8,5 × 11 pollici). Scala il contenuto della diapositiva per adattarlo ed esporta la singola diapositiva in PDF.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

var slideWidth = 612;
var slideHeight = 792;

using var presentation = new Presentation("SelectedSlides.pptx");
using var resizedPresentation = new Presentation();

resizedPresentation.SlideSize.SetSize(slideWidth, slideHeight, SlideSizeScaleType.EnsureFit);
var slide = presentation.Slides[0];
resizedPresentation.Slides.InsertClone(0, slide);

// Remove the blank slide that the new presentation was created with.
resizedPresentation.Slides.RemoveAt(1);
resizedPresentation.Save("PDF_with_custom_slide_size.pdf", SaveFormat.Pdf);
```

## **Converti PowerPoint in PDF nella Vista Note Diapositiva**

L'esempio seguente esporta una presentazione in PDF, posizionando le note del relatore di ciascuna diapositiva sotto la diapositiva stessa. Utilizza una presentazione contenente note del relatore per vedere il risultato.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

var pdfOptions = new PdfOptions
{
    SlidesLayoutOptions = new NotesCommentsLayoutingOptions
    {
        NotesPosition = NotesPositions.BottomFull
    }
};

using var presentation = new Presentation("NotesFile.pptx");
presentation.Save("PDF_with_notes.pdf", SaveFormat.Pdf, pdfOptions);
```

## **Accessibilità e Standard di Conformità per PDF**

Aspose.Slides consente di utilizzare una procedura di conversione conforme alle [Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html). È possibile esportare un documento PowerPoint in PDF utilizzando uno di questi standard di conformità: **PDF/A1a**, **PDF/A1b** e **PDF/UA**.

Questo codice C# dimostra un processo di conversione da PowerPoint a PDF che produce più PDF basati su diversi standard di conformità:

```csharp
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

{{% alert color="info" title="Note" %}}

Aspose.Slides consente operazioni di conversione PDF, permettendo di convertire file PDF in formati popolari. È possibile eseguire conversioni [PDF in HTML](https://products.aspose.com/slides/net/conversion/pdf-to-html/), [PDF in immagine](https://products.aspose.com/slides/net/conversion/pdf-to-image/), [PDF in JPG](https://products.aspose.com/slides/net/conversion/pdf-to-jpg/), e [PDF in PNG](https://products.aspose.com/slides/net/conversion/pdf-to-png/). Altre operazioni di conversione PDF in formati specializzati—[PDF in SVG](https://products.aspose.com/slides/net/conversion/pdf-to-svg/), [PDF in TIFF](https://products.aspose.com/slides/net/conversion/pdf-to-tiff/), e [PDF in XML](https://products.aspose.com/slides/net/conversion/pdf-to-xml/)—sono anch'esse supportate.

{{% /alert %}}

> **Nota:** Quando si esporta in PDF/UA, Aspose.Slides tratta le grafiche complesse come SmartArt, grafici e formule come una singola figura. Gli elementi di percorso individuali non vengono conservati come contenuto separato e possono essere contrassegnati come artefatti; il testo alternativo è fornito solo per l'intera figura.

## **FAQ**

**Posso convertire più file PowerPoint in PDF in blocco?**

Sì, Aspose.Slides supporta la conversione batch di più file PPT o PPTX in PDF. È possibile iterare sui file e applicare il processo di conversione programmaticamente.

**È possibile proteggere con password il PDF convertito?**

Sì. Usa la classe [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/) per impostare una password e definire le autorizzazioni di accesso durante il processo di conversione.

**Come includere le diapositive nascoste nel PDF?**

Imposta la proprietà [ShowHiddenSlides](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/showhiddenslides/) nella classe [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/) su `true` per includere le diapositive nascoste nel PDF risultante.

**Aspose.Slides può mantenere alta qualità dell'immagine nel PDF?**

Sì, è possibile controllare la qualità dell'immagine impostando proprietà come [JpegQuality](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/jpegquality/) e [SufficientResolution](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/sufficientresolution/) nella classe [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/) per garantire immagini ad alta qualità nel PDF.

**Aspose.Slides supporta gli standard di conformità PDF/A?**

Sì, Aspose.Slides consente di esportare PDF che rispettano vari standard, inclusi PDF/A1a, PDF/A1b e PDF/UA, garantendo che i documenti soddisfino i requisiti di accessibilità e archiviazione.

## **Risorse Aggiuntive**

- [Documentazione Aspose.Slides per .NET](/slides/it/net/)
- [Riferimento API Aspose.Slides per .NET](https://reference.aspose.com/slides/net/)
- [Convertitori Online Gratuiti Aspose](https://products.aspose.app/slides/conversion)