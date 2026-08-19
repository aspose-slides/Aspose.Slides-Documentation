---
title: Unire Efficientemente le Presentazioni in C++
linktitle: Unisci Presentazioni
type: docs
weight: 40
url: /it/cpp/merge-presentation/
keywords:
- unisci PowerPoint
- unisci presentazioni
- unisci diapositive
- unisci PPT
- unisci PPTX
- unisci ODP
- combina PowerPoint
- combina presentazioni
- combina diapositive
- combina PPT
- combina PPTX
- combina ODP
- C++
- Aspose.Slides
description: "Scopri come unire presentazioni PowerPoint e OpenDocument in C++ clonando le diapositive, controllando master e layout, ridimensionando il contenuto delle diapositive, preservando le sezioni e gestendo file protetti o di grandi dimensioni."
---
## **Panoramica**

Aspose.Slides per C++ unisce presentazioni clonando le diapositive da una [Presentazione](https://reference.aspose.com/slides/it/cpp/aspose.slides/presentation/) a un'altra. L'operazione principale è [ISlideCollection::AddClone](https://reference.aspose.com/slides/it/cpp/aspose.slides/islidecollection/addclone/), che può preservare la formattazione della diapositiva di origine o collegare la diapositiva clonata a un master o a un layout nella presentazione di destinazione.

- unire tutte le diapositive preservando la formattazione di origine;
- unire diapositive selezionate;
- applicare un master dalla presentazione di destinazione;
- applicare un layout specifico dalla presentazione di destinazione;
- normalizzare le diverse dimensioni delle diapositive prima dell'unione;
- aggiungere diapositive clonate a una sezione;
- unire più presentazioni in un unico flusso di lavoro end-to-end;
- gestire master, risorse, note, commenti, media, font, password, file di grandi dimensioni e problematiche di multithreading.

## **Come la clonazione delle diapositive influenza master e layout**

Una diapositiva eredita gran parte del suo aspetto dal layout e dal master. Per questo motivo, la sovraccarico di clonazione che scegli determina come la diapositiva unita viene integrata nella presentazione di destinazione.

Usa [ISlideCollection::AddClone](https://reference.aspose.com/slides/it/cpp/aspose.slides/islidecollection/addclone/) in uno di questi modi:

- `AddClone(sourceSlide)` — preserva il layout e la formattazione della diapositiva di origine. Quando necessario, il master di origine può essere clonato nella presentazione di destinazione automaticamente. Aspose.Slides tiene traccia dei master clonati automaticamente in modo che le diapositive ripetute che usano lo stesso master di origine non causino il riclonamento di quel master.
- `AddClone(sourceSlide, destinationMaster, allowCloneMissingLayout)` — collega la diapositiva clonata a un [IMasterSlide](https://reference.aspose.com/slides/it/cpp/aspose.slides/imasterslide/) di destinazione specifico. Aspose.Slides cerca un layout corrispondente sotto quel master per tipo o nome del layout.
- `AddClone(sourceSlide, destinationLayout)` — collega direttamente la diapositiva clonata a un [ILayoutSlide](https://reference.aspose.com/slides/it/cpp/aspose.slides/ilayoutslide/) di destinazione specifico.

Il master o il layout passato a una sovraccarico `AddClone` deve appartenere alla presentazione **di destinazione**, non a quella di origine.

## **Unire presentazioni intere e preservare la formattazione di origine**

L'unione più semplice copia ogni diapositiva dalla presentazione di origine a quella di destinazione. Questa è la scelta appropriata quando le diapositive importate devono mantenere il tema, il master e le relazioni di layout originali.

```cpp
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto destination = System::MakeObject<Presentation>(u"destination.pptx");
auto source = System::MakeObject<Presentation>(u"source.pptx");

for (const auto& slide : source->get_Slides())
{
    destination->get_Slides()->AddClone(slide);
}

destination->Save(u"merged.pptx", SaveFormat::Pptx);
```

La presentazione risultante può contenere più master quando l'origine e la destinazione usano design diversi. Questo è previsto quando la formattazione di origine viene preservata intenzionalmente.

## **Unire diapositive selezionate**

Non è necessario clonare tutte le diapositive. Il seguente esempio importa solo gli indici di diapositiva selezionati dalla presentazione di origine.

```cpp
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto destination = System::MakeObject<Presentation>(u"destination.pptx");
auto source = System::MakeObject<Presentation>(u"source.pptx");

int32_t slideIndexes[] = {0, 2, 4};

for (auto index : slideIndexes)
{
    destination->get_Slides()->AddClone(source->get_Slide(index));
}

destination->Save(u"merged-selected-slides.pptx", SaveFormat::Pptx);
```

Convalida gli indici delle diapositive prima della clonazione quando provengono da input dell'utente o da configurazioni esterne.

## **Unire diapositive usando un master di destinazione**

Usa la sovraccarico [AddClone(ISlide, IMasterSlide, bool)](https://reference.aspose.com/slides/it/cpp/aspose.slides/islidecollection/addclone/) quando le diapositive importate devono seguire un master che già appartiene alla presentazione di destinazione.

```cpp
#include <DOM/IMasterSlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto destination = System::MakeObject<Presentation>(u"destination.pptx");
auto source = System::MakeObject<Presentation>(u"source.pptx");

auto destinationMaster = destination->get_Master(0);

for (const auto& slide : source->get_Slides())
{
    destination->get_Slides()->AddClone(slide, destinationMaster, true);
}

destination->Save(u"merged-with-destination-master.pptx", SaveFormat::Pptx);
```

Aspose.Slides seleziona un layout appropriato sotto il master specificato corrispondendo al tipo o al nome del layout di origine. Se non esiste un layout adatto e `allowCloneMissingLayout` è `true`, il layout di origine viene clonato così la diapositiva può essere aggiunta. Se è `false`, viene sollevata un'[PptxEditException](https://reference.aspose.com/slides/it/cpp/aspose.slides/details_pptxeditexception/).

Usa `false` quando vuoi che l'unione fallisca invece di introdurre un layout aggiuntivo nel master di destinazione.

## **Unire diapositive usando un layout di destinazione specifico**

Usa la sovraccarico [AddClone(ISlide, ILayoutSlide)](https://reference.aspose.com/slides/it/cpp/aspose.slides/islidecollection/addclone/) quando sai esattamente quale layout di destinazione le diapositive importate dovrebbero usare.

```cpp
#include <DOM/ILayoutSlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto destination = System::MakeObject<Presentation>(u"destination.pptx");
auto source = System::MakeObject<Presentation>(u"source.pptx");

auto destinationLayout = destination->get_LayoutSlide(0);

for (const auto& slide : source->get_Slides())
{
    destination->get_Slides()->AddClone(slide, destinationLayout);
}

destination->Save(u"merged-with-destination-layout.pptx", SaveFormat::Pptx);
```

Applicare un layout di destinazione cambia la relazione di layout ereditata; non ridisegna il contenuto della diapositiva di origine. Se i layout di origine e destinazione hanno strutture di segnaposto diverse, verifica il risultato per confermare che la formattazione ereditata e il comportamento dei segnaposti siano appropriati.

## **Unire presentazioni con dimensioni delle diapositive diverse**

Le presentazioni con dimensioni delle diapositive diverse possono essere unite, ma clonare una diapositiva in una presentazione con un'altra dimensione non ridisegna automaticamente il contenuto per la nuova area. Le forme possono quindi apparire spostate, scalate in modo inatteso o fuori dall'area visibile della diapositiva.

Un approccio pratico è ridimensionare la presentazione di origine prima della clonazione. Il metodo [SlideSize::SetSize](https://reference.aspose.com/slides/it/cpp/aspose.slides/slidesize/setsize/) può scalare il contenuto esistente cambiando le dimensioni della diapositiva. [SlideSizeScaleType::EnsureFit](https://reference.aspose.com/slides/it/cpp/aspose.slides/slidesizescaletype/) scala il contenuto per adattarlo alla dimensione richiesta.

```cpp
#include <DOM/ISlideCollection.h>
#include <DOM/ISlideSize.h>
#include <DOM/Presentation.h>
#include <DOM/SlideSizeScaleType.h>
#include <Export/SaveFormat.h>
#include <drawing/size_f.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto destination = System::MakeObject<Presentation>(u"destination.pptx");
auto source = System::MakeObject<Presentation>(u"source.pptx");

auto destinationSize = destination->get_SlideSize()->get_Size();
auto sourceSize = source->get_SlideSize()->get_Size();

if (sourceSize.get_Width() != destinationSize.get_Width() || 
    sourceSize.get_Height() != destinationSize.get_Height())
{
    source->get_SlideSize()->SetSize(
        destinationSize.get_Width(), 
        destinationSize.get_Height(), 
        SlideSizeScaleType::EnsureFit);
}

for (const auto& slide : source->get_Slides())
{
    destination->get_Slides()->AddClone(slide);
}

destination->Save(u"merged-same-slide-size.pptx", SaveFormat::Pptx);
```

Il ridimensionamento modifica l'oggetto della presentazione di origine in memoria. Se hai bisogno che la presentazione di origine rimanga invariata per altre operazioni, apri un'istanza separata per l'unione.

## **Unire diapositive in una sezione della presentazione**

Il ciclo base di clonazione delle diapositive non ricrea la gerarchia delle sezioni della presentazione di origine. Se le sezioni sono importanti nell'output, crea o seleziona sezioni nella presentazione di destinazione e clona le diapositive in esse esplicitamente con [AddClone(ISlide, ISection)](https://reference.aspose.com/slides/it/cpp/aspose.slides/islidecollection/addclone/).

```cpp
#include <DOM/ISectionCollection.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto destination = System::MakeObject<Presentation>(u"destination.pptx");
auto source = System::MakeObject<Presentation>(u"source.pptx");

auto importedSection = destination->get_Sections()->AppendEmptySection(u"Imported slides");

for (const auto& slide : source->get_Slides())
{
    destination->get_Slides()->AddClone(slide, importedSection);
}

destination->Save(u"merged-with-section.pptx", SaveFormat::Pptx);
```

Le diapositive clonate vengono aggiunte alla sezione di destinazione specificata. Per preservare più sezioni di origine, ricrea quelle sezioni nella destinazione e mappa ogni diapositiva di origine alla corrispondente sezione di destinazione.

## **Unire più presentazioni in modo sicuro**

Il seguente esempio end-to-end utilizza la prima presentazione come destinazione, normalizza la dimensione della diapositiva di ogni fonte aggiuntiva, mantiene ogni fonte aperta solo durante la copia e salva il file finale una sola volta.

```cpp
#include <DOM/ISlideCollection.h>
#include <DOM/ISlideSize.h>
#include <DOM/Presentation.h>
#include <DOM/SlideSizeScaleType.h>
#include <Export/SaveFormat.h>
#include <drawing/size_f.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

System::String inputFiles[] = {u"part1.pptx", u"part2.pptx", u"part3.pptx"};
const int32_t inputFileCount = 3;

auto merged = System::MakeObject<Presentation>(inputFiles[0]);
auto mergedSize = merged->get_SlideSize()->get_Size();

for (int32_t fileIndex = 1; fileIndex < inputFileCount; fileIndex++)
{
    auto source = System::MakeObject<Presentation>(inputFiles[fileIndex]);
    auto sourceSize = source->get_SlideSize()->get_Size();

    if (sourceSize.get_Width() != mergedSize.get_Width() || 
        sourceSize.get_Height() != mergedSize.get_Height())
    {
        source->get_SlideSize()->SetSize(
            mergedSize.get_Width(), 
            mergedSize.get_Height(), 
            SlideSizeScaleType::EnsureFit);
    }

    for (const auto& slide : source->get_Slides())
    {
        merged->get_Slides()->AddClone(slide);
    }
}

merged->Save(u"merged.pptx", SaveFormat::Pptx);
```

Questo è un utile punto di partenza per preservare la formattazione di origine delle diapositive importate. Se l'output deve utilizzare un unico tema di destinazione, sostituisci la semplice chiamata `AddClone(slide)` con la sovraccarico di master o layout di destinazione appropriata mostrata in precedenza.

## **Considerazioni pratiche**

### **Master, layout e fedeltà della formattazione**

La clonazione predefinita delle diapositive può portare automaticamente un master di origine necessario nella presentazione di destinazione. Aspose.Slides mantiene un registro interno per i master clonati automaticamente per evitare di clonare lo stesso master più volte. I master clonati manualmente non sono tracciati da quel registro, quindi evita di preclonare i master a meno che non sia necessario un controllo esplicito sulla struttura del master.

Non presumere che due master o layout con lo stesso nome siano visualmente equivalenti. Se un modello aziendale deve controllare l'aspetto finale, scegli esplicitamente un master o layout di destinazione e verifica il risultato dopo l'unione.

### **Note e commenti**

Le note del relatore e i commenti alle diapositive sono associate al contenuto della diapositiva e vengono copiate quando una diapositiva è clonata. Aspose.Slides espone anche API dedicate per [note di presentazione](https://docs.aspose.com/slides/it/cpp/presentation-notes/) e [commenti di presentazione](https://docs.aspose.com/slides/it/cpp/presentation-comments/).

Se la formattazione della pagina delle note è importante, verifica la presentazione unita poiché i master delle note sono oggetti a livello di presentazione e possono differire tra i file di origine. Per i flussi di revisione, verifica anche gli autori dei commenti e i commenti a filo dopo aver combinato file da autori o modelli diversi.

### **Immagini, audio, video, oggetti OLE e collegamenti esterni**

Le diapositive possono fare riferimento a risorse a livello di presentazione come immagini, audio incorporato, video incorporato e dati OLE. Clona la diapositiva stessa anziché copiare solo le sue forme visibili affinché Aspose.Slides mantenga le relazioni della diapositiva alle sue risorse.

Le risorse incorporate e collegate devono essere trattate diversamente. Un audio, video, oggetto OLE o collegamento ipertestuale collegato rimane dipendente dal suo target esterno; la clonazione di una diapositiva non trasforma un collegamento esterno in contenuto incorporato. Verifica i percorsi e gli URL delle risorse collegate nell'ambiente in cui la presentazione unita sarà aperta.

Aspose.Slides traccia esplicitamente i master clonati automaticamente, ma ciò non deve essere considerato una garanzia generale che le risorse binarie identiche da presentazioni di origine non correlate vengano sempre deduplicate. Se la dimensione del file di output è importante, ispeziona il pacchetto unito e misura il risultato invece di fare affidamento sulla deduplicazione implicita.

### **Font incorporati e disponibilità dei font**

I font sono gestiti a livello di presentazione. Se la tipografia deve rimanere coerente tra i computer, non presumere che la clonazione delle diapositive garantisca che tutti i font richiesti siano disponibili nell'ambiente di destinazione. Puoi ispezionare i font incorporati con [FontsManager::GetEmbeddedFonts](https://reference.aspose.com/slides/it/cpp/aspose.slides/fontsmanager/getembeddedfonts/) e gestire l'incorporamento esplicitamente come descritto in [Incorpora font nelle presentazioni](https://docs.aspose.com/slides/it/cpp/embedded-font/).

Verifica anche di avere l'autorizzazione per incorporare i font utilizzati nei file di origine. Le licenze dei font possono limitare l'incorporamento.

### **Presentazioni protette da password**

Una sorgente protetta da password deve essere aperta correttamente prima che le sue diapositive possano essere clonate. Fornisci la password tramite [LoadOptions::set_Password](https://reference.aspose.com/slides/it/cpp/aspose.slides/loadoptions/set_password/).

```cpp
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>

using namespace Aspose::Slides;

auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->set_Password(u"YOUR_PASSWORD");

auto source = System::MakeObject<Presentation>(u"protected.pptx", loadOptions);
```

Aprire una sorgente crittografata non applica automaticamente la stessa protezione alla presentazione di destinazione. Configura la protezione dell'output separatamente quando necessario.

### **Presentazioni di grandi dimensioni e uso della memoria**

Le presentazioni di grandi dimensioni contenenti immagini ad alta risoluzione, audio, video o altri grandi oggetti binari possono consumare molta memoria. [LoadOptions::set_BlobManagementOptions](https://reference.aspose.com/slides/it/cpp/aspose.slides/loadoptions/set_blobmanagementoptions/) fornisce controlli per la gestione dei BLOB e l'uso di file temporanei. Vedi [Gestisci BLOB di presentazione](https://docs.aspose.com/slides/it/cpp/manage-blob/) per strategie su file di grandi dimensioni.

Per i file di grandi dimensioni, preferisci il caricamento da percorsi di file quando possibile, elimina ogni presentazione di origine non appena è stata unita e evita di salvare ripetutamente risultati intermedi a meno che il flusso di lavoro non richieda punti di controllo.

### **Sicurezza dei thread**

Non caricare, modificare, salvare o clonare la stessa istanza di [Presentation](https://reference.aspose.com/slides/it/cpp/aspose.slides/presentation/) contemporaneamente da più thread. Mantieni ogni istanza di presentazione confinata a un'unica operazione di unione. Se parallelizzi lavori indipendenti, usa istanze di presentazione indipendenti e segui le [linee guida sul multithreading di Aspose.Slides](https://docs.aspose.com/slides/it/cpp/multithreading/).

## **FAQ**

**Come mantengo il design originale di ogni presentazione di origine?**

Usa [`AddClone(sourceSlide)`](https://reference.aspose.com/slides/it/cpp/aspose.slides/islidecollection/addclone/) senza fornire un master o un layout di destinazione. Aspose.Slides può clonare automaticamente il master di origine quando è necessario per la diapositiva importata.

**Come faccio a far usare alle diapositive importate il tema di destinazione?**

Usa la sovraccarico che accetta un master di destinazione. Passa un master dalla presentazione di destinazione, non da quella di origine. Aspose.Slides cercherà di mappare ogni diapositiva di origine a un layout appropriato sotto quel master.

**Quando dovrei usare un layout di destinazione specifico invece di un master di destinazione?**

Usa un layout specifico quando ogni diapositiva importata deve utilizzare un layout noto. Usa un master quando desideri che Aspose.Slides selezioni tra i layout di quel master in base al tipo o al nome del layout di origine.

**Le presentazioni con dimensioni delle diapositive diverse possono essere unite?**

Sì, ma il contenuto delle diapositive non viene ridisegnato automaticamente per le dimensioni di destinazione. Ridimensiona prima la presentazione di origine quando hai bisogno di un posizionamento prevedibile, ad esempio con [SlideSize::SetSize](https://reference.aspose.com/slides/it/cpp/aspose.slides/slidesize/setsize/) e [SlideSizeScaleType::EnsureFit](https://reference.aspose.com/slides/it/cpp/aspose.slides/slidesizescaletype/).

**Posso unire presentazioni PPT, PPTX e ODP in un unico file?**

Sì. Carica ogni presentazione di origine, clona le diapositive richieste in una destinazione unica e salva la destinazione in un formato di output supportato. Poiché i formati di presentazione non supportano esattamente lo stesso set di funzionalità, verifica i contenuti complessi dopo le unioni cross‑format. Vedi [Supported File Formats](https://docs.aspose.com/slides/it/cpp/supported-file-formats/).

**Le sezioni di origine vengono preservate automaticamente?**

No, non con un ciclo base che clona solo le diapositive. Ricrea le sezioni necessarie nella destinazione e usa la sovraccarico di sezione di [AddClone](https://reference.aspose.com/slides/it/cpp/aspose.slides/islidecollection/addclone/) quando la struttura delle sezioni deve essere preservata.

**Le note del relatore e i commenti vengono preservati?**

Vengono copiati con la diapositiva clonata. Per i flussi di lavoro che dipendono dallo styling del master delle note, dagli autori dei commenti o dai dati di revisione a filo, verifica il risultato unito poiché questi scenari coinvolgono strutture a livello di presentazione oltre al contenuto a livello di diapositiva.

**Cosa succede a audio, video, oggetti OLE e collegamenti ipertestuali?**

Il contenuto incorporato viene mantenuto come parte delle relazioni di risorse della diapositiva clonata. I collegamenti esterni rimangono esterni, quindi i file o gli URL di destinazione devono ancora essere disponibili dopo l'unione.

**I font incorporati da ogni origine sono garantiti disponibili nella presentazione unita?**

Non fare affidamento solo sulla clonazione delle diapositive per il deployment dei font. Ispeziona i font incorporati nella destinazione e gestisci esplicitamente l'incorporamento dei font o la disponibilità di font esterni quando la tipografia è importante.

**Come unisco un file protetto da password?**

Aprila con il corretto [LoadOptions::set_Password](https://reference.aspose.com/slides/it/cpp/aspose.slides/loadoptions/set_password/), poi clona le sue diapositive normalmente. La protezione dell'output viene configurata separatamente.

**Come devo gestire presentazioni molto grandi?**

Usa la gestione dei BLOB quando i grandi oggetti binari dominano l'uso della memoria, preferisci il caricamento da percorsi di file per file molto grandi, elimina rapidamente le presentazioni di origine e salva il risultato finale solo quando necessario.

**Posso unire diapositive da più thread?**

Non usare una singola istanza di [Presentation](https://reference.aspose.com/slides/it/cpp/aspose.slides/presentation/) contemporaneamente da più thread. Mantieni ogni operazione di unione isolata alle proprie istanze di presentazione.