---
title: Converti PPT e PPTX in PDF in C++ [Funzionalità Avanzate Incluse]
linktitle: PowerPoint in PDF
type: docs
weight: 40
url: /it/cpp/convert-powerpoint-to-pdf/
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
- C++
- Aspose.Slides
description: "Converti PowerPoint PPT/PPTX in PDF di alta qualità e ricercabili in C++ usando Aspose.Slides, con esempi di codice rapidi e opzioni di conversione avanzate."
---
## **Panoramica**

Convertire le presentazioni PowerPoint (PPT, PPTX, ODP, ecc.) in formato PDF in C++ offre diversi vantaggi, tra cui la compatibilità su dispositivi diversi e la conservazione del layout e della formattazione della presentazione. Questa guida dimostra come convertire le presentazioni in documenti PDF, utilizzare varie opzioni per controllare la qualità dell'immagine, includere diapositive nascoste, proteggere i file PDF con password, rilevare sostituzioni di caratteri, selezionare diapositive specifiche per la conversione e applicare standard di conformità ai documenti di output.

## **Conversioni da PowerPoint a PDF**

Utilizzando Aspose.Slides, è possibile convertire le presentazioni nei seguenti formati in PDF:

* **PPT**
* **PPTX**
* **ODP**

Per convertire una presentazione in PDF, passa il nome del file come argomento alla classe [Presentation](https://reference.aspose.com/slides/it/cpp/aspose.slides/presentation/) e poi salva la presentazione come PDF usando il metodo `Save`. La classe [Presentation](https://reference.aspose.com/slides/it/cpp/aspose.slides/presentation/) espone il metodo `Save` tipicamente utilizzato per convertire una presentazione in PDF.

{{%  alert title="NOTE"  color="warning"   %}} 

Aspose.Slides per C++ inserisce le informazioni sull'API e il numero di versione nei documenti di output. Ad esempio, durante la conversione di una presentazione in PDF, Aspose.Slides popola il campo Application con "*Aspose.Slides*" e il campo PDF Producer con un valore nella forma "*Aspose.Slides v XX.XX*". **Nota** che non è possibile istruirе Aspose.Slides a modificare o rimuovere queste informazioni dai documenti di output.

{{% /alert %}}

Aspose.Slides consente di convertire:

* Intere presentazioni in PDF
* Diapositive specifiche da una presentazione in PDF

Aspose.Slides esporta le presentazioni in PDF, garantendo che i PDF risultanti corrispondano fedelmente alle presentazioni originali. Elementi e attributi vengono resi accuratamente nella conversione, inclusi:

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

Questo codice C++ mostra come convertire una presentazione (PPT, PPTX, ODP, ecc.) in PDF:

```c++
// Instanzia la classe Presentation che rappresenta un file PowerPoint o OpenDocument.
auto presentation = MakeObject<Presentation>(u"PowerPoint.ppt");

// Salva la presentazione come PDF.
presentation->Save(u"PPT-to-PDF.pdf", SaveFormat::Pdf);

presentation->Dispose();
```

{{%  alert  color="primary"  %}} 

Aspose offre un **PowerPoint to PDF converter** online gratuito <https://products.aspose.app/slides/it/conversion/ppt-to-pdf> che dimostra il processo di conversione da presentazione a PDF. Puoi eseguire un test con questo convertitore per una dimostrazione reale della procedura descritta qui.

{{% /alert %}}

## **Converti PowerPoint in PDF con Opzioni**

Aspose.Slides fornisce opzioni personalizzate—proprietà nella classe [PdfOptions](https://reference.aspose.com/slides/it/cpp/aspose.slides.export/pdfoptions/)—che consentono di personalizzare il PDF risultante, bloccarlo con una password o specificare come deve procedere il processo di conversione.

### **Converti PowerPoint in PDF con Opzioni Personalizzate**

Utilizzando opzioni di conversione personalizzate, è possibile definire l'impostazione di qualità preferita per le immagini raster, specificare come gestire i metafile, impostare un livello di compressione per il testo, configurare i DPI per le immagini e altro ancora.

L'esempio di codice riportato di seguito dimostra come convertire una presentazione PowerPoint in PDF con diverse opzioni personalizzate.

```c++
// Istanzia la classe PdfOptions.
auto pdfOptions = MakeObject<PdfOptions>();

// Imposta la qualità per le immagini JPG.
pdfOptions->set_JpegQuality(90);

// Imposta i DPI per le immagini.
pdfOptions->set_SufficientResolution(300);

// Imposta il comportamento per i metafile.
pdfOptions->set_SaveMetafilesAsPng(true);

// Imposta il livello di compressione del testo per il contenuto testuale.
pdfOptions->set_TextCompression(PdfTextCompression::Flate);

// Definisci la modalità di conformità PDF.
pdfOptions->set_Compliance(PdfCompliance::Pdf15);

// Istanzia la classe Presentation che rappresenta un file PowerPoint o OpenDocument.
auto presentation = MakeObject<Presentation>(u"PowerPoint.pptx");

// Salva la presentazione come documento PDF.
presentation->Save(u"PowerPoint-to-PDF.pdf", SaveFormat::Pdf, pdfOptions);

presentation->Dispose();
```

### **Converti PowerPoint in PDF con Diapositive Nascoste**

Se una presentazione contiene diapositive nascoste, è possibile utilizzare il metodo [set_ShowHiddenSlides](https://reference.aspose.com/slides/it/cpp/aspose.slides.export/pdfoptions/set_showhiddenslides/) della classe [PdfOptions](https://reference.aspose.com/slides/it/cpp/aspose.slides.export/pdfoptions/) per includere le diapositive nascoste come pagine nel PDF risultante.

Questo codice C++ mostra come convertire una presentazione PowerPoint in PDF includendo le diapositive nascoste:

```c++
// Instanzia la classe Presentation che rappresenta un file PowerPoint o OpenDocument.
auto presentation = MakeObject<Presentation>(u"PowerPoint.pptx");

// Instanzia la classe PdfOptions.
auto pdfOptions = MakeObject<PdfOptions>();

// Aggiungi diapositive nascoste.
pdfOptions->set_ShowHiddenSlides(true);

// Salva la presentazione come PDF.
presentation->Save(u"PowerPoint-to-PDF.pdf", SaveFormat::Pdf, pdfOptions);

presentation->Dispose();
```

### **Converti PowerPoint in PDF con Protezione Password**

Questo codice C++ dimostra come convertire una presentazione PowerPoint in un PDF protetto da password usando i parametri di protezione della classe [PdfOptions](https://reference.aspose.com/slides/it/cpp/aspose.slides.export/pdfoptions/):

```c++
// Istanzia la classe Presentation che rappresenta un file PowerPoint o OpenDocument.
auto presentation = MakeObject<Presentation>(u"PowerPoint.pptx");

// Istanzia la classe PdfOptions.
auto pdfOptions = MakeObject<PdfOptions>();

// Imposta una password PDF e i permessi di accesso.
pdfOptions->set_Password(u"password");
pdfOptions->set_AccessPermissions(PdfAccessPermissions::PrintDocument | PdfAccessPermissions::HighQualityPrint);

// Salva la presentazione come PDF.
presentation->Save(u"PPTX-to-PDF.pdf", SaveFormat::Pdf, pdfOptions);

presentation->Dispose();
```

### **Rileva Sostituzioni di Font**

Aspose.Slides fornisce il metodo [set_WarningCallback](https://reference.aspose.com/slides/it/cpp/aspose.slides.export/saveoptions/set_warningcallback/) nella classe [PdfOptions](https://reference.aspose.com/slides/it/cpp/aspose.slides.export/pdfoptions/), consentendo di rilevare le sostituzioni di font durante il processo di conversione da presentazione a PDF.

Questo codice C++ mostra come rilevare le sostituzioni di font:

```c++
// Implementazione del callback di avviso.
class FontSubstitutionHandler : public IWarningCallback
{
public:
    ReturnAction Warning(SharedPtr<IWarningInfo> warning) override;
};

ReturnAction FontSubstitutionHandler::Warning(SharedPtr<IWarningInfo> warning)
{
    if (warning->get_WarningType() == WarningType::DataLoss && 
        warning->get_Description().StartsWith(u"Font will be substituted"))
    {
        Console::WriteLine(u"Font substitution warning: {0}", warning->get_Description());
    }

    return ReturnAction::Continue;
}

int main()
{
    // Istanzia la classe Presentation che rappresenta un file PowerPoint o OpenDocument.
    auto presentation = MakeObject<Presentation>(u"sample.pptx");

    // Imposta il callback di avviso nelle opzioni PDF.
    auto pdfOptions = MakeObject<PdfOptions>();
    pdfOptions->set_WarningCallback(MakeObject<FontSubstitutionHandler>());

    // Salva la presentazione come PDF.
    presentation->Save(u"output.pdf", SaveFormat::Pdf, pdfOptions);
    
    presentation->Dispose();

    return 0;
}
```

{{%  alert color="primary"  %}} 

Per ulteriori informazioni su come ricevere callback per le sostituzioni di font durante il rendering, vedere [Getting Warning Callbacks for Fonts Substitution](/slides/it/cpp/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/).

Per ulteriori informazioni sulla sostituzione dei font, consultare l'articolo [Font Substitution](/slides/it/cpp/font-substitution/).

{{% /alert %}} 

## **Converti Diapositive Selezionate da PowerPoint in PDF**

Questo codice C++ dimostra come convertire solo diapositive specifiche da una presentazione PowerPoint in PDF:

```C++
// Istanzia la classe Presentation che rappresenta un file PowerPoint o OpenDocument.
auto presentation = MakeObject<Presentation>(u"PowerPoint.pptx");

// Imposta l'array dei numeri di diapositiva.
auto slides = MakeArray<int32_t>({ 1, 3 });

// Salva la presentazione come PDF.
presentation->Save(u"PPTX-to-PDF.pdf", slides, SaveFormat::Pdf);

presentation->Dispose();
```

## **Converti PowerPoint in PDF con Dimensione Personalizzata della Diapositiva**

Questo codice C++ dimostra come convertire una presentazione PowerPoint in PDF con una dimensione di diapositiva specificata:

```C++
auto slideWidth = 612;
auto slideHeight = 792;

// Istanzia la classe Presentation che rappresenta un file PowerPoint o OpenDocument.
auto presentation = MakeObject<Presentation>(u"SelectedSlides.pptx");

// Crea una nuova presentazione con una dimensione della diapositiva regolata.
auto resizedPresentation = MakeObject<Presentation>();

// Imposta la dimensione personalizzata della diapositiva.
resizedPresentation->get_SlideSize()->SetSize(slideWidth, slideHeight, SlideSizeScaleType::EnsureFit);

// Clona la prima diapositiva dalla presentazione originale.
auto slide = presentation->get_Slide(0);
resizedPresentation->get_Slides()->InsertClone(0, slide);

// Salva la presentazione ridimensionata in un PDF con le note.
resizedPresentation->Save(u"PDF_with_notes.pdf", SaveFormat::Pdf);

resizedPresentation->Dispose();
presentation->Dispose();
```

## **Converti PowerPoint in PDF nella Visualizzazione Note Diapositive**

Questo codice C++ dimostra come convertire una presentazione PowerPoint in un PDF che include le note:

```C++
// Istanzia la classe Presentation che rappresenta un file PowerPoint o OpenDocument.
auto presentation = MakeObject<Presentation>(u"SelectedSlides.pptx");

// Configura le opzioni PDF con il layout delle note.
auto notesOptions = MakeObject<NotesCommentsLayoutingOptions>();
notesOptions->set_NotesPosition(NotesPositions::BottomFull);
auto pdfOptions = MakeObject<PdfOptions>();
pdfOptions->set_SlidesLayoutOptions(notesOptions);

// Salva la presentazione in un PDF con le note.
presentation->Save(u"PDF_with_notes.tiff", SaveFormat::Pdf, pdfOptions);

presentation->Dispose();
```

## **Accessibilità e Standard di Conformità per PDF**

Aspose.Slides consente di utilizzare una procedura di conversione che rispetta le [Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html). È possibile esportare un documento PowerPoint in PDF utilizzando uno dei seguenti standard di conformità: **PDF/A1a**, **PDF/A1b** e **PDF/UA**.

Questo codice C++ dimostra un processo di conversione da PowerPoint a PDF che produce più PDF in base a diversi standard di conformità:

```C++
auto presentation = MakeObject<Presentation>(u"pres.pptx");

auto pdfOptionsA1a = MakeObject<PdfOptions>();

pdfOptionsA1a->set_Compliance(PdfCompliance::PdfA1a);
presentation->Save(u"pres-a1a-compliance.pdf", SaveFormat::Pdf, pdfOptionsA1a);

auto pdfOptionsA1b = MakeObject<PdfOptions>();
pdfOptionsA1b->set_Compliance(PdfCompliance::PdfA1b);
presentation->Save(u"pres-a1b-compliance.pdf", SaveFormat::Pdf, pdfOptionsA1b);

auto pdfOptionsUa = MakeObject<PdfOptions>();
pdfOptionsUa->set_Compliance(PdfCompliance::PdfUa);

presentation->Save(u"pres-ua-compliance.pdf", SaveFormat::Pdf, pdfOptionsUa);

presentation->Dispose();
```

{{% alert title="Note" color="warning" %}} 

Aspose.Slides supporta le operazioni di conversione PDF, consentendo di convertire file PDF in formati di file popolari. È possibile eseguire conversioni [PDF to HTML](https://products.aspose.com/slides/it/cpp/conversion/pdf-to-html/), [PDF to image](https://products.aspose.com/slides/it/cpp/conversion/pdf-to-image/), [PDF to JPG](https://products.aspose.com/slides/it/cpp/conversion/pdf-to-jpg/), e [PDF to PNG](https://products.aspose.com/slides/it/cpp/conversion/pdf-to-png/). Altre operazioni di conversione PDF verso formati specializzati—[PDF to SVG](https://products.aspose.com/slides/it/cpp/conversion/pdf-to-svg/), [PDF to TIFF](https://products.aspose.com/slides/it/cpp/conversion/pdf-to-tiff/), e [PDF to XML](https://products.aspose.com/slides/it/cpp/conversion/pdf-to-xml/)—sono anch'esse supportate.

{{% /alert %}}

> **Nota:** Quando si esporta in PDF/UA, Aspose.Slides tratta grafica complessa come SmartArt, diagrammi e formule come un'unica figura. Gli elementi di percorso individuali non vengono conservati come contenuto separato e possono essere contrassegnati come artefatti; il testo alternativo è fornito solo per l'intera figura.

## **FAQ**

**Posso convertire più file PowerPoint in PDF in blocco?**

Sì, Aspose.Slides supporta la conversione batch di più file PPT o PPTX in PDF. È possibile iterare sui file e applicare il processo di conversione programmaticamente.

**È possibile proteggere con password il PDF convertito?**

Assolutamente. Utilizza la classe [PdfOptions](https://reference.aspose.com/slides/it/cpp/aspose.slides.export/pdfoptions/) per impostare una password e definire i permessi di accesso durante il processo di conversione.

**Come includere le diapositive nascoste nel PDF?**

Usa il metodo `set_ShowHiddenSlides` nella classe [PdfOptions](https://reference.aspose.com/slides/it/cpp/aspose.slides.export/pdfoptions/) per includere le diapositive nascoste nel PDF risultante.

**Aspose.Slides può mantenere alta qualità dell'immagine nel PDF?**

Sì, è possibile controllare la qualità dell'immagine usando metodi come `set_JpegQuality` e `set_SufficientResolution` nella classe [PdfOptions](https://reference.aspose.com/slides/it/cpp/aspose.slides.export/pdfoptions/) per garantire immagini di alta qualità nel PDF.

**Aspose.Slides supporta gli standard di conformità PDF/A?**

Sì, Aspose.Slides consente di esportare PDF che rispettano vari standard, inclusi PDF/A1a, PDF/A1b e PDF/UA, garantendo che i documenti soddisfino i requisiti di accessibilità e archiviazione.

## **Risorse Aggiuntive**

- [Aspose.Slides for C++ Documentation](/slides/it/cpp/)
- [Aspose.Slides for C++ API Reference](https://reference.aspose.com/slides/it/cpp/)
- [Aspose Free Online Converters](https://products.aspose.app/slides/it/conversion)