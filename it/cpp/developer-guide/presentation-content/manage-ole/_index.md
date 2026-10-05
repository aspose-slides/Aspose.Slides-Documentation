---
title: Gestisci OLE nelle presentazioni usando C++
linktitle: Gestisci OLE
type: docs
weight: 40
url: /it/cpp/manage-ole/
keywords:
- Oggetto OLE
- Collegamento e incorporamento di oggetti
- aggiungi OLE
- incorpora OLE
- aggiungi oggetto
- incorpora oggetto
- aggiungi file
- incorpora file
- oggetto collegato
- file collegato
- modifica OLE
- icona OLE
- titolo OLE
- estrai OLE
- estrai oggetto
- estrai file
- PowerPoint
- presentazione
- C++
- Aspose.Slides
description: "Ottimizza la gestione degli oggetti OLE in PowerPoint e nei file OpenDocument con Aspose.Slides per C++. Incorpora, aggiorna ed esporta i contenuti OLE senza problemi."
---
## **Introduzione**

{{% alert color="info" title="Note" %}}

OLE (Object Linking & Embedding) è una tecnologia Microsoft che consente ai dati e agli oggetti creati in un'applicazione di essere inseriti in un'altra applicazione tramite collegamento o incorporamento. 

{{% /alert %}} 

Considera un grafico creato in MS Excel. Il grafico viene poi inserito all'interno di una diapositiva PowerPoint. Quel grafico Excel è considerato un oggetto OLE. 

- Un oggetto OLE può apparire come icona. In questo caso, quando fai doppio clic sull'icona, il grafico viene aperto nella sua applicazione associata (Excel), oppure ti viene chiesto di selezionare un'applicazione per l'apertura o la modifica dell'oggetto. 
- Un oggetto OLE può visualizzare il suo contenuto reale, come il contenuto di un grafico. In questo caso, il grafico viene attivato in PowerPoint, si carica l'interfaccia del grafico e puoi modificare i dati del grafico all'interno di PowerPoint.

[Aspose.Slides for C++](https://products.aspose.com/slides/cpp/) permette di inserire oggetti OLE nelle diapositive come frame di oggetti OLE ([OleObjectFrame](https://reference.aspose.com/slides/cpp/aspose.slides/oleobjectframe/)).

## **Aggiungi frame di oggetti OLE alle diapositive**

Supponendo di aver già creato un grafico in Microsoft Excel e di volerlo incorporare in una diapositiva come frame di oggetto OLE usando Aspose.Slides per C++, è possibile farlo in questo modo:

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) .
2. Ottieni il riferimento di una diapositiva tramite il suo indice.
3. Leggi il file Excel come array di byte.
4. Aggiungi il [OleObjectFrame](https://reference.aspose.com/slides/cpp/aspose.slides/oleobjectframe/) alla diapositiva contenente l'array di byte e altre informazioni sull'oggetto OLE.
5. Scrivi la presentazione modificata come file PPTX.

Nell'esempio seguente, abbiamo aggiunto un grafico da un file Excel a una diapositiva come [OleObjectFrame](https://reference.aspose.com/slides/cpp/aspose.slides/oleobjectframe/) utilizzando Aspose.Slides per C++. **Nota** che il costruttore [OleEmbeddedDataInfo](https://reference.aspose.com/slides/cpp/aspose.slides.dom.ole/oleembeddeddatainfo/) accetta un'estensione di oggetto incorporabile come secondo parametro. Questa estensione consente a PowerPoint di interpretare correttamente il tipo di file e di scegliere l'applicazione giusta per aprire questo oggetto OLE.

``` cpp
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideSize.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <Ole/OleEmbeddedDataInfo.h>
#include <drawing/size_f.h>
#include <system/io/file.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::DOM::Ole;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>();
auto slideSize = presentation->get_SlideSize()->get_Size();
auto slide = presentation->get_Slide(0);

// Prepare data for the OLE object.
auto fileData = File::ReadAllBytes(u"book.xlsx");
auto dataInfo = MakeObject<OleEmbeddedDataInfo>(fileData, u"xlsx");

// Add the OLE object frame to the slide.
slide->get_Shapes()->AddOleObjectFrame(0, 0, slideSize.get_Width(), slideSize.get_Height(), dataInfo);

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

### **Aggiungi frame di oggetti OLE collegati**

Aspose.Slides for C++ consente di aggiungere un [OleObjectFrame](https://reference.aspose.com/slides/cpp/aspose.slides/oleobjectframe/) senza incorporare dati ma solo con un collegamento al file.

Questo codice C++ mostra come aggiungere un [OleObjectFrame](https://reference.aspose.com/slides/cpp/aspose.slides/oleobjectframe/) con un file Excel collegato a una diapositiva:

```cpp
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

// Aggiungi un frame di oggetto OLE con un file Excel collegato.
slide->get_Shapes()->AddOleObjectFrame(20, 20, 200, 150, u"Excel.Sheet.12", u"book.xlsx");

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Accedi ai frame di oggetti OLE**

Se un oggetto OLE è già incorporato in una diapositiva, è possibile trovarlo o accedervi facilmente in questo modo:

1. Carica una presentazione con l'oggetto OLE incorporato creando un'istanza della classe [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) .
2. Ottieni il riferimento della diapositiva usando il suo indice. 
3. Accedi alla forma [OleObjectFrame](https://reference.aspose.com/slides/cpp/aspose.slides/oleobjectframe/) . Nel nostro esempio, abbiamo usato il PPTX precedentemente creato che contiene una sola forma sulla prima diapositiva. Abbiamo quindi *castato* quell'oggetto come [IOleObjectFrame](https://reference.aspose.com/slides/cpp/aspose.slides/ioleobjectframe/). Questo era il frame di oggetto OLE desiderato da accedere.
4. Una volta acceduto al frame dell'oggetto OLE, è possibile eseguire qualsiasi operazione su di esso.

Nell'esempio seguente, viene accessato un frame di oggetto OLE (un oggetto grafico Excel incorporato in una diapositiva) e i suoi dati di file sono accessati.

``` cpp
#include <DOM/IOleEmbeddedDataInfo.h>
#include <DOM/IOleObjectFrame.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <system/object_ext.h>
using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shape(0);

if (ObjectExt::Is<IOleObjectFrame>(shape))
{ 
    auto oleFrame = ExplicitCast<IOleObjectFrame>(shape);

    // Ottieni i dati del file incorporato.
    // Ottieni l'estensione del file incorporato.
    // ...
}
```

### **Accedi alle proprietà del frame di oggetto OLE collegato**

Aspose.Slides consente di accedere alle proprietà del frame di oggetto OLE collegato.

Questo codice C++ mostra come verificare se un oggetto OLE è collegato e poi ottenere il percorso del file collegato:

```cpp
#include <DOM/IOleObjectFrame.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <system/object_ext.h>
#include <system/string.h>
using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"sample.ppt");
auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shape(0);

if (ObjectExt::Is<IOleObjectFrame>(shape))
{
    auto oleFrame = ExplicitCast<IOleObjectFrame>(shape);

    // Verifica se l'oggetto OLE è collegato.
    if (oleFrame->get_IsObjectLink())
    {
        // Stampa il percorso completo del file collegato.
        std::wcout << L"OLE object frame is linked to: " << oleFrame->get_LinkPathLong() << std::endl;

        // Stampa il percorso relativo del file collegato se presente.
        // Solo le presentazioni PPT possono contenere il percorso relativo.
        if (!String::IsNullOrEmpty(oleFrame->get_LinkPathRelative()))
        {
            std::wcout << L"OLE object frame relative path: " << oleFrame->get_LinkPathRelative() << std::endl;
        }
    }
}
```

## **Modifica i dati dell'oggetto OLE**

{{% alert color="info" title="Note" %}}

In questa sezione, l'esempio di codice seguente utilizza [Aspose.Cells for C++](https://docs.aspose.com/cells/cpp/).

{{% /alert %}}

Se un oggetto OLE è già incorporato in una diapositiva, è possibile accedere facilmente a quell'oggetto e modificarne i dati in questo modo:

1. Carica una presentazione con l'oggetto OLE incorporato creando un'istanza della classe [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) .
2. Ottieni il riferimento della diapositiva tramite il suo indice.
3. Accedi alla forma [OLEObjectFrame](https://reference.aspose.com/slides/cpp/aspose.slides/oleobjectframe/) . Nel nostro esempio, abbiamo usato il PPTX precedentemente creato che ha una forma sulla prima diapositiva. Abbiamo quindi *castato* quell'oggetto come [IOleObjectFrame](https://reference.aspose.com/slides/cpp/aspose.slides/ioleobjectframe/). Questo era il frame di oggetto OLE desiderato da accedere.
4. Una volta acceduto al frame dell'oggetto OLE, è possibile eseguire qualsiasi operazione su di esso.
5. Crea un oggetto `Workbook` e accedi ai dati OLE.
6. Accedi al `Worksheet` desiderato e modifica i dati.
7. Salva il `Workbook` aggiornato in uno stream.
8. Cambia i dati dell'oggetto OLE dallo stream.

Nell'esempio seguente, viene accessato un frame di oggetto OLE (un oggetto grafico Excel incorporato in una diapositiva) e i suoi dati di file vengono modificati per aggiornare i dati del grafico.

``` cpp
#include <DOM/IOleObjectFrame.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <Ole/OleEmbeddedDataInfo.h>
#include <system/io/memory_stream.h>
#include <system/smart_ptr.h>
#include "Aspose.Cells/Cell.h"
#include "Aspose.Cells/Cells.h"
#include "Aspose.Cells/Initializer.h"
#include "Aspose.Cells/OoxmlSaveOptions.h"
#include "Aspose.Cells/SaveFormat.h"
#include "Aspose.Cells/U16String.h"
#include "Aspose.Cells/Vector.h"
#include "Aspose.Cells/Workbook.h"
#include "Aspose.Cells/Worksheet.h"
#include "Aspose.Cells/WorksheetCollection.h"
using namespace Aspose::Slides;
using namespace Aspose::Slides::DOM::Ole;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

// Aspose.Cells per C++ deve essere avviato prima di utilizzare qualsiasi suo tipo.
Aspose::Cells::Startup();

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(0);

// Get the first shape as an OLE object frame.
auto oleFrame = AsCast<IOleObjectFrame>(slide->get_Shape(0));

if (oleFrame != nullptr)
{
    auto oleStream = MakeObject<MemoryStream>(oleFrame->get_EmbeddedData()->get_EmbeddedFileData());

    // Leggi i dati dell'oggetto OLE come oggetto Workbook.
    auto oleArray = oleStream->ToArray();
    std::vector<uint8_t> workbookData(oleArray->data().begin(), oleArray->data().end());
    Aspose::Cells::Workbook workbook(Aspose::Cells::Vector<uint8_t>(workbookData.data(), workbookData.size()));

    // Modify the workbook data.
    auto worksheet = workbook.GetWorksheets().Get(0);
    worksheet.GetCells().Get(0, 4).PutValue(Aspose::Cells::U16String("E"));
    worksheet.GetCells().Get(1, 4).PutValue(12);
    worksheet.GetCells().Get(2, 4).PutValue(14);
    worksheet.GetCells().Get(3, 4).PutValue(15);

    Aspose::Cells::OoxmlSaveOptions fileOptions(Aspose::Cells::SaveFormat::Xlsx);
    auto newWorkbookData = workbook.Save(fileOptions);

    auto newOleStream = MakeObject<MemoryStream>();
    newOleStream->Write(
        MakeArray<uint8_t>(std::vector<uint8_t>(newWorkbookData.GetData(), newWorkbookData.GetData() + newWorkbookData.GetLength())),
        0, newWorkbookData.GetLength());

    // Modifica i dati dell'oggetto frame OLE.
    auto newData = MakeObject<OleEmbeddedDataInfo>(newOleStream->ToArray(), oleFrame->get_EmbeddedData()->get_EmbeddedFileExtension());
    oleFrame->SetEmbeddedData(newData);
}

presentation->Save(u"output.pptx", SaveFormat::Pptx);

Aspose::Cells::Cleanup();
```

## **Incorpora altri tipi di file nelle diapositive**

Oltre ai grafici Excel, Aspose.Slides per C++ consente di incorporare altri tipi di file nelle diapositive. Ad esempio, è possibile inserire file HTML, PDF e ZIP come oggetti. Quando un utente fa doppio clic sull'oggetto inserito, questo si apre automaticamente nel programma pertinente, oppure viene chiesto all'utente di selezionare un programma appropriato per aprirlo.

Questo codice C++ mostra come incorporare HTML e ZIP in una diapositiva:

``` cpp
#include <DOM/IOleObjectFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <Ole/OleEmbeddedDataInfo.h>
#include <system/io/file.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::DOM::Ole;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto htmlData = File::ReadAllBytes(u"sample.html");
auto htmlDataInfo = MakeObject<OleEmbeddedDataInfo>(htmlData, u"html");
auto htmlOleFrame = slide->get_Shapes()->AddOleObjectFrame(150, 120, 50, 50, htmlDataInfo);
htmlOleFrame->set_IsObjectIcon(true);

auto zipData = File::ReadAllBytes(u"sample.zip");
auto zipDataInfo = MakeObject<OleEmbeddedDataInfo>(zipData, u"zip");
auto zipOleFrame = slide->get_Shapes()->AddOleObjectFrame(150, 220, 50, 50, zipDataInfo);
zipOleFrame->set_IsObjectIcon(true);

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Imposta i tipi di file per gli oggetti incorporati**

Durante la gestione delle presentazioni, potresti dover sostituire vecchi oggetti OLE con nuovi o sostituire un oggetto OLE non supportato con uno supportato. Aspose.Slides per C++ consente di impostare il tipo di file per un oggetto incorporato, permettendo di aggiornare i dati del frame OLE o la sua estensione.

Questo codice C++ mostra come impostare il tipo di file per un oggetto OLE incorporato a `zip`:

``` cpp
#include <DOM/IOleObjectFrame.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <Ole/OleEmbeddedDataInfo.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::DOM::Ole;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(0);
auto oleFrame = ExplicitCast<IOleObjectFrame>(slide->get_Shape(0));

auto fileExtension = oleFrame->get_EmbeddedData()->get_EmbeddedFileExtension();
auto fileData = oleFrame->get_EmbeddedData()->get_EmbeddedFileData();

std::wcout << L"Current embedded file extension is: " << fileExtension << std::endl;

// Cambia il tipo di file in ZIP.
oleFrame->SetEmbeddedData(MakeObject<OleEmbeddedDataInfo>(fileData, u"zip"));

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Imposta immagini icona e titoli per gli oggetti incorporati**

Dopo aver incorporato un oggetto OLE, viene aggiunta automaticamente un'anteprima composta da un'immagine icona. Questa anteprima è ciò che gli utenti vedono prima di accedere o aprire l'oggetto OLE. Se desideri utilizzare un'immagine e un testo specifici come elementi dell'anteprima, puoi impostare l'immagine icona e il titolo usando Aspose.Slides per C++.

Questo codice C++ mostra come impostare l'immagine icona e il titolo per un oggetto incorporato: 

``` cpp
#include <DOM/IImageCollection.h>
#include <DOM/IOleObjectFrame.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/io/file.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(0);
auto oleFrame = ExplicitCast<IOleObjectFrame>(slide->get_Shape(0));

// Add an image to the presentation resources.
auto imageData = File::ReadAllBytes(u"image.png");
auto oleImage = presentation->get_Images()->AddImage(imageData);

// Set a title and the image for the OLE preview.
oleFrame->set_SubstitutePictureTitle(u"My title");
oleFrame->get_SubstitutePictureFormat()->get_Picture()->set_Image(oleImage);
oleFrame->set_IsObjectIcon(true);

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Impedisci il ridimensionamento e lo spostamento di un frame di oggetto OLE**

After aver aggiunto un oggetto OLE collegato a una diapositiva della presentazione, quando apri la presentazione in PowerPoint, potresti vedere un messaggio che ti chiede di aggiornare i collegamenti. Cliccando sul pulsante "Update Links" la dimensione e la posizione del frame dell'oggetto OLE possono cambiare perché PowerPoint aggiorna i dati dall'oggetto OLE collegato e rinfresca l'anteprima dell'oggetto. Per impedire a PowerPoint di chiedere l'aggiornamento dei dati dell'oggetto, chiama il metodo [set_UpdateAutomatic](https://reference.aspose.com/slides/cpp/aspose.slides/ioleobjectframe/set_updateautomatic/) dell'interfaccia [IOleObjectFrame](https://reference.aspose.com/slides/cpp/aspose.slides/ioleobjectframe/) con `false`:

```cpp
#include <DOM/IOleObjectFrame.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(0);
auto oleFrame = ExplicitCast<IOleObjectFrame>(slide->get_Shape(0));

oleFrame->set_UpdateAutomatic(false);
```

## **Estrai i file incorporati**

Aspose.Slides per C++ consente di estrarre i file incorporati nelle diapositive come oggetti OLE in questo modo:

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) contenente gli oggetti OLE che desideri estrarre.
2. Scorri tutte le forme nella presentazione e accedi alle forme [OLEObjectFrame](https://reference.aspose.com/slides/cpp/aspose.slides/oleobjectframe/) .
3. Accedi ai dati dei file incorporati dai frame OLE e scrivili su disco.

Questo codice C++ mostra come estrarre i file incorporati in una diapositiva come oggetti OLE:

``` cpp
#include <DOM/IOleEmbeddedDataInfo.h>
#include <DOM/IOleObjectFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <system/io/file.h>
#include <system/object_ext.h>
#include <system/string.h>
using namespace Aspose::Slides;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(0);

for (int index = 0; index < slide->get_Shapes()->get_Count(); index++)
{
    auto shape = slide->get_Shape(index);

    if (ObjectExt::Is<IOleObjectFrame>(shape))
    { 
        auto oleFrame = ExplicitCast<IOleObjectFrame>(shape);

        auto fileData = oleFrame->get_EmbeddedData()->get_EmbeddedFileData();
        auto fileExtension = oleFrame->get_EmbeddedData()->get_EmbeddedFileExtension();

        auto fileName = String::Format(u"OLE_object_{0}{1}", index, fileExtension);
        File::WriteAllBytes(fileName, fileData);
    }
}

presentation->Dispose();
```

## **FAQ**

**Il contenuto OLE verrà renderizzato quando si esportano le diapositive in PDF/immagini?**

Ciò che è visibile sulla diapositiva viene renderizzato—l'icona/immagine sostitutiva (anteprima). Il contenuto OLE "live" non viene eseguito durante il rendering. Se necessario, imposta la tua immagine di anteprima per garantire l'aspetto previsto nel PDF esportato.

Per preservare anche il file incorporato come allegato PDF, chiama [PdfOptions::set_IncludeOleData](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/set_includeoledata/) con `true`. Questa opzione è disabilitata per impostazione predefinita. Per un esempio e istruzioni su come verificare l'allegato, vedi [Preserve Embedded OLE Files as PDF Attachments](/slides/it/cpp/convert-powerpoint-to-pdf/#preserve-embedded-ole-files-as-pdf-attachments).

**Come posso bloccare un oggetto OLE su una diapositiva affinché gli utenti non possano spostarlo/modificarlo in PowerPoint?**

Blocca la forma: Aspose.Slides fornisce [shape-level locks](/slides/it/cpp/applying-protection-to-presentation/). Non si tratta di crittografia, ma impedisce efficacemente modifiche accidentali e spostamenti.

**Perché un oggetto Excel collegato "salta" o cambia dimensione quando apro la presentazione?**

PowerPoint potrebbe aggiornare l'anteprima dell'OLE collegato. Per un aspetto stabile, segui le pratiche della [Working Solution for Worksheet Resizing](/slides/it/cpp/working-solution-for-worksheet-resizing/)—adatta il frame all'intervallo, o scala l'intervallo a un frame fisso e imposta un'immagine sostitutiva appropriata.

**I percorsi relativi per gli oggetti OLE collegati saranno conservati nel formato PPTX?**

Nel PPTX le informazioni sul "percorso relativo" non sono disponibili—solo il percorso completo. I percorsi relativi sono presenti nel formato PPT più vecchio. Per la portabilità, preferisci percorsi assoluti affidabili/URI accessibili o l'incorporamento.