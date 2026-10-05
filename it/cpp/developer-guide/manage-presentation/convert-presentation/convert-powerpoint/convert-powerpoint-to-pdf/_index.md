---
title: Converti PPT e PPTX in PDF in C++ [Funzionalità Avanzate Incluse]
linktitle: PowerPoint in PDF
type: docs
weight: 40
url: /it/cpp/convert-powerpoint-to-pdf/
keywords:
- convertire PowerPoint
- convertire presentazione
- PowerPoint in PDF
- presentazione in PDF
- PPT in PDF
- convertire PPT in PDF
- PPTX in PDF
- convertire PPTX in PDF
- salvare PowerPoint come PDF
- salvare PPT come PDF
- salvare PPTX come PDF
- esportare PPT in PDF
- esportare PPTX in PDF
- allegato
- PDF/A1a
- PDF/A1b
- PDF/UA
- C++
- Aspose.Slides
description: "Converti PowerPoint PPT/PPTX in PDF di alta qualità e ricercabili in C++ usando Aspose.Slides, con esempi di codice rapidi e opzioni di conversione avanzate."
---
## **Panoramica**

Convertire presentazioni PowerPoint (PPT, PPTX, ODP, ecc.) in formato PDF in C++ offre diversi vantaggi, tra cui la compatibilità su diversi dispositivi e la conservazione del layout e della formattazione della presentazione. Questa guida dimostra come convertire le presentazioni in documenti PDF, utilizzare varie opzioni per controllare la qualità delle immagini, includere diapositive nascoste, proteggere con password i file PDF, rilevare le sostituzioni di caratteri, selezionare diapositive specifiche per la conversione e applicare standard di conformità ai documenti di output.

## **Conversioni da PowerPoint a PDF**

Utilizzando Aspose.Slides, è possibile convertire presentazioni nei seguenti formati in PDF:

* **PPT**
* **PPTX**
* **ODP**

Per convertire una presentazione in PDF, passare il nome del file come argomento alla classe [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) e quindi salvare la presentazione come PDF usando il metodo [Save](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/save/). La classe [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) espone il metodo [Save](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/save/) che è tipicamente usato per convertire una presentazione in PDF.

{{% alert color="info" title="Note" %}}
Aspose.Slides per C++ inserisce le informazioni sulla sua API e il numero di versione nei documenti di output. Ad esempio, durante la conversione di una presentazione in PDF, Aspose.Slides popola il campo Application con "*Aspose.Slides*" e il campo PDF Producer con un valore nella forma "*Aspose.Slides v XX.XX*". **Nota** che non è possibile istruire Aspose.Slides a modificare o rimuovere queste informazioni dai documenti di output.
{{% /alert %}}

Aspose.Slides consente di convertire:

* Intere presentazioni in PDF
* Diapositive specifiche da una presentazione in PDF

Aspose.Slides esporta le presentazioni in PDF, garantendo che i PDF risultanti corrispondano fedelmente alle presentazioni originali. Elementi e attributi vengono renderizzati accuratamente nella conversione, includendo:

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

L'esempio seguente carica una presentazione e salva tutte le diapositive visibili in PDF utilizzando le impostazioni di esportazione predefinite.

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"PowerPoint.ppt");
presentation->Save(u"PPT-to-PDF.pdf", SaveFormat::Pdf);
presentation->Dispose();
```

{{% alert color="info" title="Note" %}}
Aspose offre un [**PowerPoint to PDF converter**](https://products.aspose.app/slides/conversion/ppt-to-pdf) online gratuito che dimostra il processo di conversione da presentazione a PDF. È possibile eseguire un test con questo convertitore per una dimostrazione dal vivo della procedura descritta qui.
{{% /alert %}}

## **Converti PowerPoint in PDF con Opzioni**

Aspose.Slides fornisce opzioni personalizzate — proprietà della classe [PdfOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/) — che consentono di personalizzare il PDF risultante, proteggere il PDF con una password o specificare come deve procedere il processo di conversione.

### **Converti PowerPoint in PDF con Opzioni Personalizzate**

Utilizzando opzioni di conversione personalizzate, è possibile definire l'impostazione di qualità preferita per le immagini raster, specificare come gestire i metafile, impostare un livello di compressione per il testo, configurare i DPI per le immagini e altro.

L'esempio seguente esporta una presentazione in PDF 1.5 con qualità JPEG impostata a 90, risoluzione immagine a 300 DPI, metafile salvati come PNG e compressione del testo Flate.

```cpp
#include <DOM/Presentation.h>
#include <Export/PdfCompliance.h>
#include <Export/PdfOptions.h>
#include <Export/PdfTextCompression.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto pdfOptions = MakeObject<PdfOptions>();
pdfOptions->set_JpegQuality(90);
pdfOptions->set_SufficientResolution(300);
pdfOptions->set_SaveMetafilesAsPng(true);
pdfOptions->set_TextCompression(PdfTextCompression::Flate);
pdfOptions->set_Compliance(PdfCompliance::Pdf15);

auto presentation = MakeObject<Presentation>(u"PowerPoint.pptx");
presentation->Save(u"PowerPoint-to-PDF.pdf", SaveFormat::Pdf, pdfOptions);
presentation->Dispose();
```

### **Conserva i file OLE incorporati come allegati PDF**

Se una presentazione contiene un foglio di lavoro Excel incorporato, potrebbe essere necessario che i destinatari del PDF accedano ai dati del foglio oltre a visualizzare le diapositive. Chiamare [PdfOptions::set_IncludeOleData](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/set_includeoledata/) con `true` per conservare i file OLE incorporati come allegati nel PDF risultante.

Il valore predefinito è `false`: l'immagine di anteprima o l'icona dell'oggetto OLE viene renderizzata nella pagina PDF, ma il file incorporato non è incluso come allegato. Impostare l'opzione su `true` aggiunge anche i dati del file. L'anteprima rimane una rappresentazione visiva; l'allegato consente ai destinatari di aprire o salvare il file incorporato separatamente. L'oggetto OLE non diventa un foglio di lavoro Excel interattivo nella pagina PDF.

L'esempio seguente carica una presentazione che contiene già un foglio di lavoro Excel incorporato ed esporta il PDF con il workbook allegato.

```cpp
#include <DOM/Presentation.h>
#include <Export/PdfOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto pdfOptions = MakeObject<PdfOptions>();
pdfOptions->set_IncludeOleData(true);

auto presentation = MakeObject<Presentation>(u"presentation.pptx");
presentation->Save(u"presentation.pdf", SaveFormat::Pdf, pdfOptions);
presentation->Dispose();
```

Per verificare il risultato:

1. Aprire il PDF esportato in un visualizzatore che supporta gli allegati, come Adobe Acrobat Reader.
2. Aprire il pannello **Allegati** del visualizzatore e individuare il workbook incorporato.
3. Salvare l'allegato e aprirlo in Excel per ispezionare i dati, oppure aprirlo direttamente se il visualizzatore lo consente. L'anteprima nella pagina PDF è separata dall'allegato.

{{% alert color="info" title="Note" %}}
Gli standard PDF/A impongono restrizioni sugli allegati: PDF/A-1 vieta i file incorporati, PDF/A-2 consente solo allegati PDF/A, e PDF/A-3 consente altri tipi di file, inclusi i workbook Excel. Questi sono requisiti degli standard, non limitazioni specifiche di Aspose.Slides. Questo esempio utilizza l'impostazione di conformità PDF predefinita e non dimostra l'esportazione PDF/A.
{{% /alert %}}

### **Converti PowerPoint in PDF con Diapositive Nascoste**

Se una presentazione contiene diapositive nascoste, è possibile utilizzare il metodo [set_ShowHiddenSlides](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/set_showhiddenslides/) della classe [PdfOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/) per includere le diapositive nascoste come pagine nel PDF risultante.

L'esempio seguente esporta una presentazione in PDF, includendo eventuali diapositive nascoste.

```cpp
#include <DOM/Presentation.h>
#include <Export/PdfOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto pdfOptions = MakeObject<PdfOptions>();
pdfOptions->set_ShowHiddenSlides(true);

auto presentation = MakeObject<Presentation>(u"PowerPoint.pptx");
presentation->Save(u"PowerPoint-to-PDF.pdf", SaveFormat::Pdf, pdfOptions);
presentation->Dispose();
```

### **Converti PowerPoint in un PDF protetto da password**

L'esempio seguente esporta una presentazione in un PDF che richiede la password `password` per l'apertura. Le autorizzazioni di accesso consentono la stampa, inclusa la stampa ad alta qualità.

```cpp
#include <DOM/Presentation.h>
#include <Export/PdfAccessPermissions.h>
#include <Export/PdfOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto pdfOptions = MakeObject<PdfOptions>();
pdfOptions->set_Password(u"password");
pdfOptions->set_AccessPermissions(PdfAccessPermissions::PrintDocument | PdfAccessPermissions::HighQualityPrint);

auto presentation = MakeObject<Presentation>(u"PowerPoint.pptx");
presentation->Save(u"PPTX-to-PDF.pdf", SaveFormat::Pdf, pdfOptions);
presentation->Dispose();
```

### **Rileva sostituzioni di caratteri**

Aspose.Slides fornisce il metodo [set_WarningCallback](https://reference.aspose.com/slides/cpp/aspose.slides.export/saveoptions/set_warningcallback/) nella classe [PdfOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/) che consente di rilevare le sostituzioni di caratteri durante il processo di conversione da presentazione a PDF.

L'esempio seguente esporta una presentazione in PDF e stampa gli avvisi di sostituzione dei caratteri sulla console. Un avviso viene stampato solo quando un carattere non disponibile è sostituito durante l'esportazione.

```cpp
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

class FontSubstitutionHandler : public IWarningCallback
{
public:
    ReturnAction Warning(SharedPtr<IWarningInfo> warning) override
    {
        if (warning->get_WarningType() == WarningType::DataLoss && warning->get_Description().StartsWith(u"Font will be substituted"))
        {
            Console::WriteLine(u"Font substitution warning: {0}", warning->get_Description());
        }

        return ReturnAction::Continue;
    }
};

auto pdfOptions = MakeObject<PdfOptions>();
auto warningHandler = MakeObject<FontSubstitutionHandler>();
pdfOptions->set_WarningCallback(warningHandler);

auto presentation = MakeObject<Presentation>(u"sample.pptx");
presentation->Save(u"output.pdf", SaveFormat::Pdf, pdfOptions);
presentation->Dispose();
```

{{% alert color="info" title="Note" %}}
Per ulteriori informazioni sulla sostituzione dei caratteri, vedere l'articolo [Font Substitution](/slides/it/cpp/font-substitution/).
{{% /alert %}} 

## **Converti diapositive selezionate da PowerPoint in PDF**

L'esempio seguente esporta le diapositive 1 e 3 da una presentazione in PDF. I numeri delle diapositive in questo array partono da 1, e la presentazione di input deve contenere almeno tre diapositive.

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/array.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"PowerPoint.pptx");
auto slides = MakeArray<int32_t>({ 1, 3 });
presentation->Save(u"PPTX-to-PDF.pdf", slides, SaveFormat::Pdf);
presentation->Dispose();
```

## **Converti PowerPoint in PDF con dimensione diapositiva personalizzata**

L'esempio seguente copia la prima diapositiva da una presentazione in una nuova presentazione con una dimensione diapositiva di 612 × 792 punti (8,5 × 11 pollici). Scala il contenuto della diapositiva per adattarlo ed esporta la singola diapositiva in PDF.

```cpp
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

auto presentation = MakeObject<Presentation>(u"SelectedSlides.pptx");
auto resizedPresentation = MakeObject<Presentation>();

resizedPresentation->get_SlideSize()->SetSize(slideWidth, slideHeight, SlideSizeScaleType::EnsureFit);

auto slide = presentation->get_Slide(0);
resizedPresentation->get_Slides()->InsertClone(0, slide);

// Remove the blank slide that the new presentation was created with.
resizedPresentation->get_Slides()->RemoveAt(1);

resizedPresentation->Save(u"PDF_with_custom_slide_size.pdf", SaveFormat::Pdf);

resizedPresentation->Dispose();
presentation->Dispose();
```

## **Converti PowerPoint in PDF nella visualizzazione note diapositiva**

L'esempio seguente esporta una presentazione in PDF, posizionando le note del relatore di ogni diapositiva sotto la diapositiva stessa. Utilizzare una presentazione contenente note del relatore per vedere il risultato.

```cpp
#include <DOM/Presentation.h>
#include <Export/NotesCommentsLayoutingOptions.h>
#include <Export/NotesPositions.h>
#include <Export/PdfOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto notesOptions = MakeObject<NotesCommentsLayoutingOptions>();
notesOptions->set_NotesPosition(NotesPositions::BottomFull);

auto pdfOptions = MakeObject<PdfOptions>();
pdfOptions->set_SlidesLayoutOptions(notesOptions);

auto presentation = MakeObject<Presentation>(u"NotesFile.pptx");
presentation->Save(u"PDF_with_notes.pdf", SaveFormat::Pdf, pdfOptions);
presentation->Dispose();
```

## **Standard di accessibilità e conformità per PDF**

Aspose.Slides consente di utilizzare una procedura di conversione che rispetta le [Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html). È possibile esportare un documento PowerPoint in PDF utilizzando uno dei seguenti standard di conformità: **PDF/A1a**, **PDF/A1b** e **PDF/UA**.

Questo codice C++ dimostra un processo di conversione da PowerPoint a PDF che produce più PDF basati su diversi standard di conformità:

```cpp
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

{{% alert color="info" title="Note" %}}
Aspose.Slides supporta le operazioni di conversione PDF, consentendo di convertire file PDF in formati di file popolari. È possibile eseguire conversioni [PDF to HTML](https://products.aspose.com/slides/cpp/conversion/pdf-to-html/), [PDF to image](https://products.aspose.com/slides/cpp/conversion/pdf-to-image/), [PDF to JPG](https://products.aspose.com/slides/cpp/conversion/pdf-to-jpg/), e [PDF to PNG](https://products.aspose.com/slides/cpp/conversion/pdf-to-png/) . Altre operazioni di conversione PDF verso formati specializzati — [PDF to SVG](https://products.aspose.com/slides/cpp/conversion/pdf-to-svg/), [PDF to TIFF](https://products.aspose.com/slides/cpp/conversion/pdf-to-tiff/), e [PDF to XML](https://products.aspose.com/slides/cpp/conversion/pdf-to-xml/) — sono anch'esse supportate.
{{% /alert %}}

> **Nota:** Quando si esporta in PDF/UA, Aspose.Slides tratta grafica complessa come SmartArt, grafici e formule come una singola figura. Gli elementi di percorso individuali non sono conservati come contenuti separati e possono essere contrassegnati come artefatti; il testo alternativo è fornito solo per l'intera figura.

## **FAQ**

**Posso convertire più file PowerPoint in PDF in blocco?**

Sì, Aspose.Slides supporta la conversione batch di più file PPT o PPTX in PDF. È possibile iterare sui file e applicare il processo di conversione programmaticamente.

**È possibile proteggere con password il PDF convertito?**

Sì. Utilizzare la classe [PdfOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/) per impostare una password e definire le autorizzazioni di accesso durante il processo di conversione.

**Come includere le diapositive nascoste nel PDF?**

Utilizzare il metodo [set_ShowHiddenSlides](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/set_showhiddenslides/) nella classe [PdfOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/) per includere le diapositive nascoste nel PDF risultante.

**Aspose.Slides può mantenere alta qualità dell'immagine nel PDF?**

Sì, è possibile controllare la qualità dell'immagine utilizzando metodi come [set_JpegQuality](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/set_jpegquality/) e [set_SufficientResolution](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/set_sufficientresolution/) nella classe [PdfOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/) per garantire immagini ad alta qualità nel PDF.

**Aspose.Slides supporta gli standard di conformità PDF/A?**

Sì, Aspose.Slides consente di esportare PDF che rispettano vari standard, inclusi PDF/A1a, PDF/A1b e PDF/UA, assicurando che i documenti soddisfino i requisiti di accessibilità e archiviazione.

## **Risorse aggiuntive**

- [Documentazione di Aspose.Slides per C++](/slides/it/cpp/)
- [Riferimento API di Aspose.Slides per C++](https://reference.aspose.com/slides/cpp/)
- [Convertitori online gratuiti Aspose](https://products.aspose.app/slides/conversion)