---
title: Recuperare e aggiornare le informazioni della presentazione in C++
linktitle: Informazioni sulla presentazione
type: docs
weight: 30
url: /it/cpp/examine-presentation/
keywords:
- formato della presentazione
- proprietà della presentazione
- proprietà del documento
- ottenere proprietà
- leggere proprietà
- cambiare proprietà
- modificare proprietà
- aggiornare proprietà
- esaminare PPTX
- esaminare PPT
- esaminare ODP
- PowerPoint
- OpenDocument
- presentazione
- C++
- Aspose.Slides
description: "Esplora diapositive, struttura e metadati nelle presentazioni PowerPoint e OpenDocument utilizzando C++ per ottenere approfondimenti più rapidi e audit dei contenuti più intelligenti."
---
## **Panoramica**

Aspose.Slides può identificare il formato di una presentazione e leggere i metadati del documento senza creare un modello completo di oggetti della presentazione. Questo è utile quando è necessario classificare i file, creare un inventario o ispezionare le proprietà prima di decidere se caricare ed elaborare il contenuto della presentazione.

Questo articolo dimostra l'ispezione leggera tramite [PresentationFactory](https://reference.aspose.com/slides/it/cpp/aspose.slides/presentationfactory/) e [IPresentationInfo](https://reference.aspose.com/slides/it/cpp/aspose.slides/ipresentationinfo/), nonché aggiornamenti mirati tramite [IDocumentProperties](https://reference.aspose.com/slides/it/cpp/aspose.slides/idocumentproperties/).

## **Verifica il formato di una presentazione**

Utilizza [IPresentationFactory::GetPresentationInfo](https://reference.aspose.com/slides/it/cpp/aspose.slides/ipresentationfactory/getpresentationinfo/) per ispezionare un file senza creare un'istanza di [Presentation](https://reference.aspose.com/slides/it/cpp/aspose.slides/presentation/). Il metodo [IPresentationInfo::get_LoadFormat](https://reference.aspose.com/slides/it/cpp/aspose.slides/ipresentationinfo/get_loadformat/) restituisce il formato rilevato, ad esempio PPTX, PPT o ODP.

```cpp
#include <DOM/IPresentationInfo.h>
#include <DOM/PresentationFactory.h>
#include <LoadFormat.h>
#include <system/array.h>
#include <system/console.h>
#include <system/object_ext.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace System;

auto fileNames = MakeArray<String>({u"pres.pptx", u"pres.ppt", u"pres.odp"});

for (const auto& fileName : fileNames)
{
    auto presentationInfo = PresentationFactory::get_Instance()->GetPresentationInfo(fileName);
    Console::WriteLine(String::Format(u"{0}: {1}", fileName, ObjectExt::ToString(presentationInfo->get_LoadFormat())));
}
```

## **Crea un inventario leggero delle presentazioni**

Quando elabori molti file di presentazione, potresti aver bisogno di un inventario compatto per convalida, indicizzazione o un sistema di gestione dei documenti. In questo scenario, utilizza [IPresentationFactory::GetPresentationInfo](https://reference.aspose.com/slides/it/cpp/aspose.slides/ipresentationfactory/getpresentationinfo/) per ottenere un oggetto [IPresentationInfo](https://reference.aspose.com/slides/it/cpp/aspose.slides/ipresentationinfo/), e quindi chiama [IPresentationInfo::ReadDocumentProperties](https://reference.aspose.com/slides/it/cpp/aspose.slides/ipresentationinfo/readdocumentproperties/) per leggere i metadati del documento. Questo approccio non crea un'istanza di [Presentation](https://reference.aspose.com/slides/it/cpp/aspose.slides/presentation/) né richiede di attraversare l'intero modello di oggetti della presentazione.

Le proprietà estese esposte da [IDocumentProperties](https://reference.aspose.com/slides/it/cpp/aspose.slides/idocumentproperties/) forniscono i seguenti valori di inventario:

| Metodo | Valore dell'inventario |
| --- | --- |
| [get_Slides](https://reference.aspose.com/slides/it/cpp/aspose.slides/idocumentproperties/get_slides/) | Numero totale di diapositive. |
| [get_HiddenSlides](https://reference.aspose.com/slides/it/cpp/aspose.slides/idocumentproperties/get_hiddenslides/) | Numero di diapositive nascoste. |
| [get_Notes](https://reference.aspose.com/slides/it/cpp/aspose.slides/idocumentproperties/get_notes/) | Numero di diapositive che contengono note. |
| [get_Paragraphs](https://reference.aspose.com/slides/it/cpp/aspose.slides/idocumentproperties/get_paragraphs/) | Numero totale di paragrafi, se disponibile. |
| [get_Words](https://reference.aspose.com/slides/it/cpp/aspose.slides/idocumentproperties/get_words/) | Numero totale di parole. |
| [get_MultimediaClips](https://reference.aspose.com/slides/it/cpp/aspose.slides/idocumentproperties/get_multimediaclips/) | Numero totale di clip audio e video. |

Il seguente esempio legge questi valori senza creare un oggetto [Presentation](https://reference.aspose.com/slides/it/cpp/aspose.slides/presentation/) e stampa un inventario compatto. Combina inoltre [IDocumentProperties::get_HeadingPairs](https://reference.aspose.com/slides/it/cpp/aspose.slides/idocumentproperties/get_headingpairs/) con [IDocumentProperties::get_TitlesOfParts](https://reference.aspose.com/slides/it/cpp/aspose.slides/idocumentproperties/get_titlesofparts/) per visualizzare gruppi di contenuti come caratteri, temi e titoli delle diapositive.

```cpp
#include <DOM/IDocumentProperties.h>
#include <DOM/IHeadingPair.h>
#include <DOM/IPresentationInfo.h>
#include <DOM/PresentationFactory.h>
#include <LoadFormat.h>
#include <system/console.h>
#include <system/io/path.h>
#include <system/object_ext.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace System;
using namespace System::IO;

auto filePath = String(u"sample.pptx");
auto presentationInfo = PresentationFactory::get_Instance()->GetPresentationInfo(filePath);
auto documentProperties = presentationInfo->ReadDocumentProperties();

Console::WriteLine(String::Format(u"File: {0}", Path::GetFileName(filePath)));
Console::WriteLine(String::Format(u"Format: {0}", ObjectExt::ToString(presentationInfo->get_LoadFormat())));
Console::WriteLine(String::Format(u"Title: {0}", documentProperties->get_Title()));
Console::WriteLine(String::Format(u"Author: {0}", documentProperties->get_Author()));
Console::WriteLine(u"Statistics:");
Console::WriteLine(String::Format(u"  Slides: {0}", documentProperties->get_Slides()));
Console::WriteLine(String::Format(u"  Hidden slides: {0}", documentProperties->get_HiddenSlides()));
Console::WriteLine(String::Format(u"  Slides with notes: {0}", documentProperties->get_Notes()));
Console::WriteLine(String::Format(u"  Paragraphs: {0}", documentProperties->get_Paragraphs()));
Console::WriteLine(String::Format(u"  Words: {0}", documentProperties->get_Words()));
Console::WriteLine(String::Format(u"  Multimedia clips: {0}", documentProperties->get_MultimediaClips()));

auto headingPairs = documentProperties->get_HeadingPairs();
auto titlesOfParts = documentProperties->get_TitlesOfParts();
auto partIndex = 0;

if (headingPairs == nullptr || titlesOfParts == nullptr || headingPairs->get_Length() == 0 || titlesOfParts->get_Length() == 0)
{
    Console::WriteLine(u"Content groups: not available");
}
else
{
    Console::WriteLine(u"Content groups:");

    for (const auto& headingPair : headingPairs)
    {
        auto partCount = headingPair->get_Count();
        Console::WriteLine(String::Format(u"  {0} ({1})", headingPair->get_Name(), partCount));

        for (auto partOffset = 0; partOffset < partCount && partIndex < titlesOfParts->get_Length(); partOffset++)
        {
            Console::WriteLine(String::Format(u"    - {0}", titlesOfParts[partIndex]));
            partIndex++;
        }
    }

    if (partIndex < titlesOfParts->get_Length())
    {
        Console::WriteLine(u"  Other parts:");

        while (partIndex < titlesOfParts->get_Length())
        {
            Console::WriteLine(String::Format(u"    - {0}", titlesOfParts[partIndex]));
            partIndex++;
        }
    }
}
```

Ogni [IHeadingPair](https://reference.aspose.com/slides/it/cpp/aspose.slides/iheadingpair/) fornisce un nome di gruppo tramite [IHeadingPair::get_Name](https://reference.aspose.com/slides/it/cpp/aspose.slides/iheadingpair/get_name/) e il numero di elementi in quel gruppo tramite [IHeadingPair::get_Count](https://reference.aspose.com/slides/it/cpp/aspose.slides/iheadingpair/get_count/). [IDocumentProperties::get_TitlesOfParts](https://reference.aspose.com/slides/it/cpp/aspose.slides/idocumentproperties/get_titlesofparts/) restituisce un array piatto e ordinato, quindi consuma il numero di titoli consecutivi specificato da ciascuna coppia di intestazione.

### **Metadati memorizzati e limitazioni del formato**

Le proprietà di inventario restituite da [IPresentationInfo::ReadDocumentProperties](https://reference.aspose.com/slides/it/cpp/aspose.slides/ipresentationinfo/readdocumentproperties/) riflettono i metadati disponibili nel documento di origine. Aspose.Slides non carica e attraversa il modello di oggetti della presentazione per ricalcolare questi valori per questa chiamata. Le proprietà mancanti sono rappresentate da valori predefiniti e i valori memorizzati possono essere obsoleti se l'applicazione che ha salvato per ultima il file non ha aggiornato le proprietà del documento.

- **PPTX:** Il formato fornisce proprietà di documento estese per conteggi di diapositive, note, diapositive nascoste, paragrafi, parole e contenuti multimediali, nonché coppie di intestazioni e titoli delle parti. La disponibilità dipende dalle proprietà scritte dal produttore del documento.
- **PPT:** Il formato binario può memorizzare le corrispondenti proprietà di riepilogo del documento. Se una proprietà è assente o non è stata aggiornata dal produttore del documento, Aspose.Slides restituisce il valore memorizzato o predefinito anziché calcolarlo dalle diapositive.
- **ODP:** I metadati OpenDocument forniscono statistiche generali del documento, come conteggi di pagine, paragrafi e parole, ma questi valori non corrispondono a tutte le proprietà estese specifiche di PowerPoint. I metadati di diapositive nascoste, diapositive con note, multimediali, coppie di intestazioni e titoli delle parti potrebbero non essere disponibili, e le proprietà di inventario potrebbero restituire valori predefiniti. Non considerare un valore zero o un array vuoto come prova definitiva dell'assenza del contenuto corrispondente.

Utilizza il metodo dei metadati leggeri per inventari e controlli preliminari. Carica la presentazione e ispeziona il suo modello di oggetti live quando il risultato deve riflettere le modifiche in memoria o quando è necessario verificare il contenuto effettivo della presentazione.

## **Aggiorna le proprietà della presentazione**

Le proprietà restituite da [IPresentationInfo::ReadDocumentProperties](https://reference.aspose.com/slides/it/cpp/aspose.slides/ipresentationinfo/readdocumentproperties/) possono anche essere modificate senza creare un'istanza di [Presentation](https://reference.aspose.com/slides/it/cpp/aspose.slides/presentation/). Applica le modifiche con [IPresentationInfo::UpdateDocumentProperties](https://reference.aspose.com/slides/it/cpp/aspose.slides/ipresentationinfo/updatedocumentproperties/), quindi scrivi la presentazione legata con [IPresentationInfo::WriteBindedPresentation](https://reference.aspose.com/slides/it/cpp/aspose.slides/ipresentationinfo/writebindedpresentation/).

L'immagine seguente mostra le proprietà originali del documento della presentazione PowerPoint.

![Proprietà originali del documento della presentazione PowerPoint](input_properties.png)

L'esempio seguente modifica il titolo e l'ora dell'ultimo salvataggio e scrive il risultato in un nuovo file:

```cpp
#include <DOM/IDocumentProperties.h>
#include <DOM/IPresentationInfo.h>
#include <DOM/PresentationFactory.h>
#include <system/date_time.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace System;

auto sourceFile = String(u"sample.pptx");
auto outputFile = String(u"sample_with_updated_properties.pptx");
auto presentationInfo = PresentationFactory::get_Instance()->GetPresentationInfo(sourceFile);
auto documentProperties = presentationInfo->ReadDocumentProperties();

documentProperties->set_Title(u"Quarterly sales report");
documentProperties->set_LastSavedTime(DateTime::get_UtcNow());

presentationInfo->UpdateDocumentProperties(documentProperties);
presentationInfo->WriteBindedPresentation(outputFile);
```

L'immagine seguente mostra le proprietà del documento modificate della presentazione PowerPoint.

![Proprietà del documento modificate della presentazione PowerPoint](output_properties.png)

## **Link utili**

Per controlli di sicurezza correlati e impostazioni di protezione, consulta i seguenti articoli:

- [Presentazioni protette da password](/slides/it/cpp/password-protected-presentation/)
- [Presentazioni protette in scrittura](/slides/it/cpp/write-protected-presentation/)

## **FAQ**

**Come posso verificare se i caratteri sono incorporati e quali sono?**

Carica la presentazione e usa [Presentation::get_FontsManager](https://reference.aspose.com/slides/it/cpp/aspose.slides/presentation/get_fontsmanager/). Chiama [FontsManager::GetEmbeddedFonts](https://reference.aspose.com/slides/it/cpp/aspose.slides/fontsmanager/getembeddedfonts/) per ottenere i caratteri incorporati e [FontsManager::GetFonts](https://reference.aspose.com/slides/it/cpp/aspose.slides/fontsmanager/getfonts/) per ottenere i caratteri utilizzati dalla presentazione. Confronta i due risultati per individuare i caratteri richiesti per il rendering ma non incorporati.

**Come posso capire rapidamente se il file contiene diapositive nascoste e quante?**

Quando i metadati del documento memorizzati sono sufficienti, leggi [IDocumentProperties::get_HiddenSlides](https://reference.aspose.com/slides/it/cpp/aspose.slides/idocumentproperties/get_hiddenslides/) tramite [IPresentationFactory::GetPresentationInfo](https://reference.aspose.com/slides/it/cpp/aspose.slides/ipresentationfactory/getpresentationinfo/) e [IPresentationInfo::ReadDocumentProperties](https://reference.aspose.com/slides/it/cpp/aspose.slides/ipresentationinfo/readdocumentproperties/). Questo è adatto per un inventario leggero. Se la presentazione è stata modificata in memoria, i metadati memorizzati potrebbero mancare o essere obsoleti, oppure è necessario verificare i valori live; in tal caso, itera attraverso [Presentation::get_Slides](https://reference.aspose.com/slides/it/cpp/aspose.slides/presentation/get_slides/) e controlla il metodo [Slide::get_Hidden](https://reference.aspose.com/slides/it/cpp/aspose.slides/slide/get_hidden/) di ciascuna diapositiva.

**Posso rilevare se è utilizzata una dimensione e un'orientazione di diapositiva personalizzate e se differiscono dalle impostazioni predefinite?**

Sì. Carica la presentazione e leggi [Presentation::get_SlideSize](https://reference.aspose.com/slides/it/cpp/aspose.slides/presentation/get_slidesize/). Esamina [ISlideSize::get_Type](https://reference.aspose.com/slides/it/cpp/aspose.slides/islidesize/get_type/), [ISlideSize::get_Size](https://reference.aspose.com/slides/it/cpp/aspose.slides/islidesize/get_size/) e [ISlideSize::get_Orientation](https://reference.aspose.com/slides/it/cpp/aspose.slides/islidesize/get_orientation/) per confrontare le impostazioni correnti con quelle predefinite e le dimensioni attese.

**Esiste un modo rapido per vedere se i grafici fanno riferimento a fonti dati esterne?**

Sì. Individua ogni [Chart](https://reference.aspose.com/slides/it/cpp/aspose.slides.charts/chart/) e controlla [ChartData::get_DataSourceType](https://reference.aspose.com/slides/it/cpp/aspose.slides.charts/chartdata/get_datasourcetype/). Per una cartella di lavoro esterna, leggi [ChartData::get_ExternalWorkbookPath](https://reference.aspose.com/slides/it/cpp/aspose.slides.charts/chartdata/get_externalworkbookpath/). Il tipo di fonte dati e il percorso identificano un riferimento esterno, ma verificare la disponibilità del file di destinazione richiede un controllo di risorse separato.

**Come posso valutare le diapositive “pesanti” che potrebbero rallentare il rendering o l'esportazione in PDF?**

Non esiste una singola proprietà di complessità. Scorri [Presentation::get_Slides](https://reference.aspose.com/slides/it/cpp/aspose.slides/presentation/get_slides/) e la collezione [IBaseSlide::get_Shapes](https://reference.aspose.com/slides/it/cpp/aspose.slides/ibaseslide/get_shapes/) di ciascuna diapositiva. Usa il conteggio delle forme e la presenza di immagini di grandi dimensioni, effetti, animazioni o contenuti multimediali come segnali di screening, e misura un rendering o un'esportazione rappresentativa prima di considerare una diapositiva un vero collo di bottiglia di prestazioni.