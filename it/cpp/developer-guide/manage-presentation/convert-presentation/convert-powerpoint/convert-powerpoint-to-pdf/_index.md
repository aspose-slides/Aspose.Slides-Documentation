---
title: Converti PPT e PPTX in PDF in C++ [Funzionalità avanzate incluse]
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
description: "Converti PowerPoint PPT/PPTX in PDF di alta qualità e ricercabili in C++ usando Aspose.Slides, con esempi di codice rapidi e opzioni avanzate di conversione."
---
## **Panoramica**

Convertire le presentazioni PowerPoint (PPT, PPTX, ODP, ecc.) in formato PDF in C++ offre diversi vantaggi, tra cui la compatibilità su diversi dispositivi e la conservazione del layout e della formattazione della presentazione. Questa guida mostra come convertire le presentazioni in documenti PDF, utilizzare varie opzioni per controllare la qualità delle immagini, includere diapositive nascoste, proteggere con password i file PDF, rilevare sostituzioni di caratteri, selezionare diapositive specifiche per la conversione e applicare standard di conformità ai documenti di output.

## **Conversioni da PowerPoint a PDF**

Con Aspose.Slides, è possibile convertire le presentazioni nei seguenti formati in PDF:

* **PPT**
* **PPTX**
* **ODP**

Per convertire una presentazione in PDF, passare il nome del file come argomento alla classe [Presentation](https://reference.aspose.com/slides/it/cpp/aspose.slides/presentation/) e quindi salvare la presentazione come PDF usando il metodo `Save`. La classe [Presentation](https://reference.aspose.com/slides/it/cpp/aspose.slides/presentation/) espone il metodo `Save` che è tipicamente usato per convertire una presentazione in PDF.

{{%  alert title="NOTE"  color="warning"   %}} 

Aspose.Slides per C++ inserisce le informazioni sull'API e il numero di versione nei documenti di output. Ad esempio, durante la conversione di una presentazione in PDF, Aspose.Slides popola il campo Application con "*Aspose.Slides*" e il campo PDF Producer con un valore nella forma "*Aspose.Slides v XX.XX*". **Nota**: non è possibile istruirе Aspose.Slides a modificare o rimuovere queste informazioni dai documenti di output.

{{% /alert %}}

Aspose.Slides consente di convertire:

* Intere presentazioni in PDF
* Diapositive specifiche di una presentazione in PDF

Aspose.Slides esporta le presentazioni in PDF, assicurando che i PDF risultanti corrispondano fedelmente alle presentazioni originali. Gli elementi e gli attributi sono renderizzati accuratamente nella conversione, inclusi:

* Immagini
* Caselle di testo e forme
* Formattazione del testo
* Formattazione dei paragrafi
* Collegamenti ipertestuali
* Intestazioni e piè di pagina
* Elenchi puntati
* Tabelle

## **Convertire PowerPoint in PDF**

Il processo standard di conversione da PowerPoint a PDF utilizza le opzioni predefinite. In questo caso, Aspose.Slides tenta di convertire la presentazione fornita in PDF usando impostazioni ottimali al massimo livello di qualità.

Questo codice C++ mostra come convertire una presentazione (PPT, PPTX, ODP, ecc.) in PDF:

```c++
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// Istanzia la classe Presentation che rappresenta un file PowerPoint o OpenDocument.
auto presentation = MakeObject<Presentation>(u"PowerPoint.ppt");

// Salva la presentazione come PDF.
presentation->Save(u"PPT-to-PDF.pdf", SaveFormat::Pdf);

presentation->Dispose();
```

{{%  alert  color="info"  %}} 

Aspose offre un gratuito [**convertitore online PowerPoint in PDF**](https://products.aspose.app/slides/it/conversion/ppt-to-pdf) che dimostra il processo di conversione da presentazione a PDF. È possibile eseguire un test con questo convertitore per un'implementazione reale della procedura descritta qui.

{{% /alert %}}

## **Convertire PowerPoint in PDF con Opzioni**

Aspose.Slides fornisce opzioni personalizzate—proprietà della classe [PdfOptions](https://reference.aspose.com/slides/it/cpp/aspose.slides.export/pdfoptions/)—che consentono di personalizzare il PDF risultante, bloccarlo con una password o specificare come deve procedere il processo di conversione.

### **Convertire PowerPoint in PDF con Opzioni Personalizzate**

Utilizzando opzioni di conversione personalizzate, è possibile definire l'impostazione di qualità preferita per le immagini raster, specificare come gestire i metafile, impostare un livello di compressione per il testo, configurare DPI per le immagini e altro ancora.

L'esempio di codice seguente dimostra come convertire una presentazione PowerPoint in PDF con diverse opzioni personalizzate.

```c++
#include <DOM/Presentation.h>
#include <Export/PdfCompliance.h>
#include <Export/PdfOptions.h>
#include <Export/PdfTextCompression.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// Instanzia la classe PdfOptions.
auto pdfOptions = MakeObject<PdfOptions>();

// Imposta la qualità per le immagini JPG.
pdfOptions->set_JpegQuality(90);

// Imposta DPI per le immagini.
pdfOptions->set_SufficientResolution(300);

// Imposta il comportamento per i metafile.
pdfOptions->set_SaveMetafilesAsPng(true);

// Imposta il livello di compressione del testo per il contenuto testuale.
pdfOptions->set_TextCompression(PdfTextCompression::Flate);

// Definisci la modalità di conformità PDF.
pdfOptions->set_Compliance(PdfCompliance::Pdf15);

// Instanzia la classe Presentation che rappresenta un file PowerPoint o OpenDocument.
auto presentation = MakeObject<Presentation>(u"PowerPoint.pptx");

// Salva la presentazione come documento PDF.
presentation->Save(u"PowerPoint-to-PDF.pdf", SaveFormat::Pdf, pdfOptions);

presentation->Dispose();
```

### **Convertire PowerPoint in PDF con Diapositive Nascoste**

Se una presentazione contiene diapositive nascoste, è possibile utilizzare il metodo [set_ShowHiddenSlides](https://reference.aspose.com/slides/it/cpp/aspose.slides.export/pdfoptions/set_showhiddenslides/) della classe [PdfOptions](https://reference.aspose.com/slides/it/cpp/aspose.slides.export/pdfoptions/) per includere le diapositive nascoste come pagine nel PDF risultante.

Questo codice C++ mostra come convertire una presentazione PowerPoint in PDF includendo le diapositive nascoste:

```c++
#include <DOM/Presentation.h>
#include <Export/PdfOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

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

### **Convertire PowerPoint in PDF Protetto da Password**

Questo codice C++ dimostra come convertire una presentazione PowerPoint in un PDF protetto da password utilizzando i parametri di protezione della classe [PdfOptions](https://reference.aspose.com/slides/it/cpp/aspose.slides.export/pdfoptions/):

```c++
#include <DOM/Presentation.h>
#include <Export/PdfAccessPermissions.h>
#include <Export/PdfOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// Instanzia la classe Presentation che rappresenta un file PowerPoint o OpenDocument.
auto presentation = MakeObject<Presentation>(u"PowerPoint.pptx");

// Instanzia la classe PdfOptions.
auto pdfOptions = MakeObject<PdfOptions>();

// Imposta una password PDF e le autorizzazioni di accesso.
pdfOptions->set_Password(u"password");
pdfOptions->set_AccessPermissions(PdfAccessPermissions::PrintDocument | PdfAccessPermissions::HighQualityPrint);

// Salva la presentazione come PDF.
presentation->Save(u"PPTX-to-PDF.pdf", SaveFormat::Pdf, pdfOptions);

presentation->Dispose();
```

### **Rilevare Sostituzioni di Font**

Aspose.Slides fornisce il metodo [set_WarningCallback](https://reference.aspose.com/slides/it/cpp/aspose.slides.export/saveoptions/set_warningcallback/) nella classe [PdfOptions](https://reference.aspose.com/slides/it/cpp/aspose.slides.export/pdfoptions/), consentendo di rilevare le sostituzioni di font durante il processo di conversione da presentazione a PDF.

Questo codice C++ mostra come rilevare le sostituzioni di font:

```c++
#include <DOM/Presentation.h>
#include <Export/PdfOptions.h>
#include <Export/SaveFormat.h>
#include <Warnings/IWarningCallback.h>
#include <Warnings/IWarningInfo.h>
#include <Warnings/ReturnAction.h>
#include <Warnings/WarningType.h>
#include <system/console.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::Warnings;
using namespace System;

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
    // Instanzia la classe Presentation che rappresenta un file PowerPoint o OpenDocument.
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

{{%  alert color="info"  %}} 

Per ulteriori informazioni sul ricevere callback per le sostituzioni di font durante il rendering, vedere [Getting Warning Callbacks for Fonts Substitution](/slides/it/cpp/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/).

Per maggiori dettagli sulla sostituzione dei font, consultare l'articolo [Font Substitution](/slides/it/cpp/font-substitution/).

{{% /alert %}} 

## **Convertire Diapositive Selezionate da PowerPoint in PDF**

Questo codice C++ dimostra come convertire solo diapositive specifiche da una presentazione PowerPoint in PDF:

```C++
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/array.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// Instanzia la classe Presentation che rappresenta un file PowerPoint o OpenDocument.
auto presentation = MakeObject<Presentation>(u"PowerPoint.pptx");

// Imposta l'array di numeri di diapositiva.
auto slides = MakeArray<int32_t>({ 1, 3 });

// Salva la presentazione come PDF.
presentation->Save(u"PPTX-to-PDF.pdf", slides, SaveFormat::Pdf);

presentation->Dispose();
```

## **Convertire PowerPoint in PDF con Dimensione Diapositiva Personalizzata**

Questo codice C++ dimostra come convertire una presentazione PowerPoint in PDF con una dimensione di diapositiva specificata:

```C++
#include <DOM/ISlideCollection.h>
#include <DOM/ISlideSize.h>
#include <DOM/Presentation.h>
#include <DOM/SlideSizeScaleType.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto slideWidth = 612;
auto slideHeight = 792;

// Instanzia la classe Presentation che rappresenta un file PowerPoint o OpenDocument.
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

## **Convertire PowerPoint in PDF in Visualizzazione Note della Diapositiva**

Questo codice C++ dimostra come convertire una presentazione PowerPoint in un PDF che include le note:

```C++
#include <DOM/Presentation.h>
#include <Export/NotesCommentsLayoutingOptions.h>
#include <Export/NotesPositions.h>
#include <Export/PdfOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// Instanzia la classe Presentation che rappresenta un file PowerPoint o OpenDocument.
auto presentation = MakeObject<Presentation>(u"SelectedSlides.pptx");

// Configura le opzioni PDF con layout delle note.
auto notesOptions = MakeObject<NotesCommentsLayoutingOptions>();
notesOptions->set_NotesPosition(NotesPositions::BottomFull);
auto pdfOptions = MakeObject<PdfOptions>();
pdfOptions->set_SlidesLayoutOptions(notesOptions);

// Salva la presentazione in un PDF con le note.
presentation->Save(u"PDF_with_notes.tiff", SaveFormat::Pdf, pdfOptions);

presentation->Dispose();
```

## **Accessibilità e Standard di Conformità per PDF**

Aspose.Slides consente di utilizzare una procedura di conversione che rispetta le [Linee Guida per l'Accessibilità dei Contenuti Web (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html). È possibile esportare un documento PowerPoint in PDF utilizzando uno qualsiasi di questi standard di conformità: **PDF/A1a**, **PDF/A1b** e **PDF/UA**.

Questo codice C++ dimostra un processo di conversione da PowerPoint a PDF che produce più PDF basati su diversi standard di conformità:

```C++
#include <DOM/Presentation.h>
#include <Export/PdfCompliance.h>
#include <Export/PdfOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

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

Aspose.Slides supporta operazioni di conversione PDF, consentendo di convertire file PDF in formati di file popolari. È possibile eseguire conversioni [PDF a HTML](https://products.aspose.com/slides/it/cpp/conversion/pdf-to-html/), [PDF a immagine](https://products.aspose.com/slides/it/cpp/conversion/pdf-to-image/), [PDF a JPG](https://products.aspose.com/slides/it/cpp/conversion/pdf-to-jpg/), e [PDF a PNG](https://products.aspose.com/slides/it/cpp/conversion/pdf-to-png/). Altre operazioni di conversione PDF verso formati specializzati—[PDF a SVG](https://products.aspose.com/slides/it/cpp/conversion/pdf-to-svg/), [PDF a TIFF](https://products.aspose.com/slides/it/cpp/conversion/pdf-to-tiff/), e [PDF a XML](https://products.aspose.com/slides/it/cpp/conversion/pdf-to-xml/)—sono anch'esse supportate.

{{% /alert %}}

> **Nota:** Quando si esporta in PDF/UA, Aspose.Slides tratta grafica complessa come SmartArt, grafici e formule come una singola figura. Gli elementi di percorso individuali non sono preservati come contenuto separato e possono essere contrassegnati come artefatti; il testo alternativo è fornito solo per l'intera figura.

## **FAQ**

### Posso convertire più file PowerPoint in PDF in blocco?

Sì, Aspose.Slides supporta la conversione batch di più file PPT o PPTX in PDF. È possibile iterare sui propri file e applicare il processo di conversione programmaticamente.

### È possibile proteggere con password il PDF convertito?

Assolutamente. Utilizzare la classe [PdfOptions](https://reference.aspose.com/slides/it/cpp/aspose.slides.export/pdfoptions/) per impostare una password e definire le autorizzazioni di accesso durante il processo di conversione.

### Come includere le diapositive nascoste nel PDF?

Usare il metodo `set_ShowHiddenSlides` nella classe [PdfOptions](https://reference.aspose.com/slides/it/cpp/aspose.slides.export/pdfoptions/) per includere le diapositive nascoste nel PDF risultante.

### Aspose.Slides può mantenere alta qualità delle immagini nel PDF?

Sì, è possibile controllare la qualità delle immagini utilizzando metodi come `set_JpegQuality` e `set_SufficientResolution` nella classe [PdfOptions](https://reference.aspose.com/slides/it/cpp/aspose.slides.export/pdfoptions/) per garantire immagini di alta qualità nel PDF.

### Aspose.Slides supporta gli standard di conformità PDF/A?

Sì, Aspose.Slides consente di esportare PDF conformi a vari standard, tra cui PDF/A1a, PDF/A1b e PDF/UA, garantendo che i documenti soddisfino i requisiti di accessibilità e archiviazione.

## **Risorse Aggiuntive**

- [Documentazione Aspose.Slides per C++](/slides/it/cpp/)
- [Riferimento API Aspose.Slides per C++](https://reference.aspose.com/slides/it/cpp/)
- [Convertitori Online Gratuiti Aspose](https://products.aspose.app/slides/it/conversion)