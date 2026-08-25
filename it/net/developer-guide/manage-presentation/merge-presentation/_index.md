---
title: Unire presentazioni in .NET in modo efficiente
linktitle: Unire presentazioni
type: docs
weight: 40
url: /it/net/merge-presentation/
keywords:
- unire PowerPoint
- unire presentazioni
- unire diapositive
- unire PPT
- unire PPTX
- unire ODP
- combinare PowerPoint
- combinare presentazioni
- combinare diapositive
- combinare PPT
- combinare PPTX
- combinare ODP
- .NET
- C#
- Aspose.Slides
description: "Scopri come unire presentazioni PowerPoint e OpenDocument in .NET clonando le diapositive, controllando master e layout, ridimensionando il contenuto delle diapositive, preservando le sezioni e gestendo file protetti o di grandi dimensioni."
---
## **Panoramica**

Aspose.Slides per .NET unisce presentazioni clonando diapositive da una [Presentazione](https://reference.aspose.com/slides/it/net/aspose.slides/presentation/) a un'altra. L'operazione principale è [ISlideCollection.AddClone](https://reference.aspose.com/slides/it/net/aspose.slides/islidecollection/addclone/), che può preservare la formattazione della diapositiva di origine o collegare la diapositiva clonata a un master o layout nella presentazione di destinazione.

Questo articolo copre i flussi di lavoro di unione più comuni:

- unire tutte le diapositive conservando la formattazione di origine;
- unire diapositive selezionate;
- applicare un master dalla presentazione di destinazione;
- applicare un layout specifico dalla presentazione di destinazione;
- normalizzare dimensioni diverse delle diapositive prima dell'unione;
- aggiungere diapositive clonate a una sezione;
- unire più presentazioni in un flusso di lavoro end‑to‑end;
- gestire master, risorse, note, commenti, media, caratteri, password, file di grandi dimensioni e considerazioni sul multithreading.

## **Come la clonazione delle diapositive influisce su Master e Layout**

Una diapositiva eredita gran parte del suo aspetto dal layout e dal master. Per questo motivo, il sovraccarico di clonazione che scegli determina come la diapositiva unita viene integrata nella presentazione di destinazione.

Usa [ISlideCollection.AddClone](https://reference.aspose.com/slides/it/net/aspose.slides/islidecollection/addclone/) in uno di questi modi:

- `AddClone(sourceSlide)` — preserva il layout e la formattazione della diapositiva di origine. Se necessario, il master di origine può essere clonato automaticamente nella presentazione di destinazione. Aspose.Slides traccia i master clonate automaticamente in modo che diapositive ripetute che usano lo stesso master di origine non causino la clonazione ripetuta di quel master.
- `AddClone(sourceSlide, destinationMaster, allowCloneMissingLayout)` — collega la diapositiva clonata a uno specifico [IMasterSlide](https://reference.aspose.com/slides/it/net/aspose.slides/imasterslide/) di destinazione. Aspose.Slides cerca un layout corrispondente sotto quel master in base al tipo o al nome del layout.
- `AddClone(sourceSlide, destinationLayout)` — collega direttamente la diapositiva clonata a un [ILayoutSlide](https://reference.aspose.com/slides/it/net/aspose.slides/ilayoutslide/) di destinazione specifico.

Il master o il layout passato a un overload `AddClone` deve appartenere alla **presentazione di destinazione**, non a quella di origine.

## **Unire intere presentazioni preservando la formattazione di origine**

L'unione più semplice copia ogni diapositiva dalla presentazione di origine a quella di destinazione. Questa è la scelta appropriata quando le diapositive importate devono mantenere il tema, il master e le relazioni di layout originali.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var destination = new Presentation("destination.pptx");
using var source = new Presentation("source.pptx");

foreach (var slide in source.Slides)
{
    destination.Slides.AddClone(slide);
}

destination.Save("merged.pptx", SaveFormat.Pptx);
```

La presentazione risultante può contenere più master quando l'origine e la destinazione usano design diversi. Questo è previsto quando la formattazione di origine viene intenzionalmente conservata.

## **Unire diapositive selezionate**

Non è necessario clonare ogni diapositiva. L'esempio seguente importa solo gli indici di diapositiva selezionati dalla presentazione di origine.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var destination = new Presentation("destination.pptx");
using var source = new Presentation("source.pptx");

var slideIndexes = new[] { 0, 2, 4 };

foreach (var index in slideIndexes)
{
    destination.Slides.AddClone(source.Slides[index]);
}

destination.Save("merged-selected-slides.pptx", SaveFormat.Pptx);
```

Convalida gli indici delle diapositive prima di clonare quando provengono da input dell'utente o da configurazioni esterne.

## **Unire diapositive usando un Master di destinazione**

Usa il sovraccarico [AddClone(ISlide, IMasterSlide, Boolean)](https://reference.aspose.com/slides/it/net/aspose.slides/islidecollection/addclone/) quando le diapositive importate devono seguire un master che appartiene già alla presentazione di destinazione.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var destination = new Presentation("destination.pptx");
using var source = new Presentation("source.pptx");

var destinationMaster = destination.Masters[0];

foreach (var slide in source.Slides)
{
    destination.Slides.AddClone(slide, destinationMaster, allowCloneMissingLayout: true);
}

destination.Save("merged-with-destination-master.pptx", SaveFormat.Pptx);
```

Aspose.Slides seleziona un layout appropriato sotto il master specificato corrispondendo al tipo o al nome del layout di origine. Se non esiste un layout adatto e `allowCloneMissingLayout` è `true`, il layout di origine viene clonato così la diapositiva può essere aggiunta. Se è `false`, viene generata una [PptxEditException](https://reference.aspose.com/slides/it/net/aspose.slides/pptxeditexception/).

Usa `false` quando vuoi che l'unione fallisca invece di introdurre un layout aggiuntivo nel master di destinazione.

## **Unire diapositive usando un Layout di destinazione specifico**

Usa il sovraccarico [AddClone(ISlide, ILayoutSlide)](https://reference.aspose.com/slides/it/net/aspose.slides/islidecollection/addclone/) quando sai esattamente quale layout di destinazione devono utilizzare le diapositive importate.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var destination = new Presentation("destination.pptx");
using var source = new Presentation("source.pptx");

var destinationLayout = destination.LayoutSlides[0];

foreach (var slide in source.Slides)
{
    destination.Slides.AddClone(slide, destinationLayout);
}

destination.Save("merged-with-destination-layout.pptx", SaveFormat.Pptx);
```

Applicare un layout di destinazione modifica la relazione di layout ereditata; non ridisegna il contenuto della diapositiva di origine. Se i layout di origine e di destinazione hanno strutture di segnaposto diverse, ispeziona il risultato per confermare che la formattazione ereditata e il comportamento dei segnaposto siano appropriati.

## **Unire presentazioni con dimensioni di diapositiva diverse**

Le presentazioni con dimensioni di diapositiva diverse possono essere unite, ma clonare una diapositiva in una presentazione con un'altra dimensione non ridisegna automaticamente il suo contenuto per la nuova area di lavoro. Le forme possono quindi apparire spostate, scalate in modo inatteso o al di fuori dell'area visibile della diapositiva.

Un approccio pratico è ridimensionare la presentazione di origine prima della clonazione. Il metodo [SlideSize.SetSize](https://reference.aspose.com/slides/it/net/aspose.slides/slidesize/setsize/) può ridimensionare il contenuto esistente cambiando le dimensioni della diapositiva. [SlideSizeScaleType.EnsureFit](https://reference.aspose.com/slides/it/net/aspose.slides/slidesizescaletype/) scala il contenuto per adattarlo alla dimensione richiesta.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var destination = new Presentation("destination.pptx");
using var source = new Presentation("source.pptx");

if (source.SlideSize.Size.Width != destination.SlideSize.Size.Width || 
    source.SlideSize.Size.Height != destination.SlideSize.Size.Height)
{
    source.SlideSize.SetSize(
        destination.SlideSize.Size.Width, 
        destination.SlideSize.Size.Height, 
        SlideSizeScaleType.EnsureFit);
}

foreach (var slide in source.Slides)
{
    destination.Slides.AddClone(slide);
}

destination.Save("merged-same-slide-size.pptx", SaveFormat.Pptx);
```

Il ridimensionamento modifica l'oggetto della presentazione di origine in memoria. Se hai bisogno dell'originale inalterato per altre operazioni, apri un'istanza separata per l'unione.

## **Unire diapositive in una sezione della presentazione**

Il ciclo base di clonazione delle diapositive non ricrea la gerarchia delle sezioni della presentazione di origine. Se le sezioni sono importanti nell'output, crea o seleziona sezioni nella presentazione di destinazione e clona le diapositive in esse esplicitamente con [AddClone(ISlide, ISection)](https://reference.aspose.com/slides/it/net/aspose.slides/islidecollection/addclone/).

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var destination = new Presentation("destination.pptx");
using var source = new Presentation("source.pptx");

var importedSection = destination.Sections.AppendEmptySection("Imported slides");

foreach (var slide in source.Slides)
{
    destination.Slides.AddClone(slide, importedSection);
}

destination.Save("merged-with-section.pptx", SaveFormat.Pptx);
```

Le diapositive clonate vengono aggiunte alla sezione di destinazione specificata. Per preservare più sezioni di origine, enumera [Presentation.Sections](https://reference.aspose.com/slides/it/net/aspose.slides/presentation/sections/), recupera le diapositive correnti di ciascuna sezione di origine con [ISection.GetSlidesListOfSection](https://reference.aspose.com/slides/it/net/aspose.slides/isection/getslideslistofsection/), ricrea le sezioni nella destinazione e clona ogni diapositiva restituita nella sua sezione di destinazione corrispondente. Vedi [Gestire le sezioni delle diapositive](/slides/it/net/slide-section/) per un esempio completo di enumerazione delle sezioni, incluse sezioni vuote e modifiche strutturali.

## **Unire più presentazioni in modo sicuro**

L'esempio end‑to‑end seguente usa la prima presentazione come destinazione, normalizza la dimensione delle diapositive di ciascuna fonte aggiuntiva, mantiene ogni fonte aperta solo durante la copia e salva il file finale una sola volta.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

var inputFiles = new[] { "part1.pptx", "part2.pptx", "part3.pptx" };

using var merged = new Presentation(inputFiles[0]);

for (var fileIndex = 1; fileIndex < inputFiles.Length; fileIndex++)
{
    using var source = new Presentation(inputFiles[fileIndex]);

    if (source.SlideSize.Size.Width != merged.SlideSize.Size.Width || 
        source.SlideSize.Size.Height != merged.SlideSize.Size.Height)
    {
        source.SlideSize.SetSize(
            merged.SlideSize.Size.Width, 
            merged.SlideSize.Size.Height, 
            SlideSizeScaleType.EnsureFit);
    }

    foreach (var slide in source.Slides)
    {
        merged.Slides.AddClone(slide);
    }
}

merged.Save("merged.pptx", SaveFormat.Pptx);
```

Questo è un utile punto di partenza per preservare la formattazione di origine delle diapositive importate. Se il tuo output deve usare un singolo tema di destinazione, sostituisci la semplice chiamata `AddClone(slide)` con il sovraccarico master‑di‑destinazione o layout‑di‑destinazione mostrato in precedenza.

## **Considerazioni pratiche**

### **Master, Layout e fedeltà della formattazione**

La clonazione predefinita delle diapositive può introdurre automaticamente un master di origine richiesto nella presentazione di destinazione. Aspose.Slides mantiene un registro interno per i master clonati automaticamente per evitare di clonare lo stesso master più volte. I master clonati manualmente non sono tracciati da tale registro, quindi evita di pre‑clonare i master a meno che tu non abbia bisogno di un controllo esplicito sulla struttura del master.

Non dare per scontato che due master o layout con lo stesso nome siano visualmente equivalenti. Se un modello aziendale deve controllare l'aspetto finale, scegli esplicitamente un master o layout di destinazione e verifica il risultato dopo l'unione.

### **Note e commenti**

Le note del relatore e i commenti alle diapositive sono associati al contenuto della diapositiva e vengono copiadosi quando una diapositiva è clonata. Aspose.Slides espone inoltre API dedicate per [note di presentazione](/slides/it/net/presentation-notes/) e [commenti di presentazione](/slides/it/net/presentation-comments/).

Se la formattazione della pagina delle note è importante, verifica la presentazione unita perché i master delle note sono oggetti a livello di presentazione e possono differire tra i file di origine. Per i flussi di revisione, verifica anche gli autori dei commenti e i commenti nidificati dopo aver combinato file provenienti da autori o modelli diversi.

### **Immagini, audio, video, oggetti OLE e collegamenti esterni**

Le diapositive possono fare riferimento a risorse a livello di presentazione come immagini, audio incorporato, video incorporato e dati OLE. Clona la diapositiva stessa invece di copiare solo le forme visibili affinché Aspose.Slides possa mantenere le relazioni della diapositiva alle sue risorse.

Le risorse incorporate e quelle collegate devono essere trattate diversamente. Un audio, video, oggetto OLE o collegamento ipertestuale collegato rimane dipendente dal suo bersaglio esterno; clonare una diapositiva non trasforma un collegamento esterno in contenuto incorporato. Verifica i percorsi e gli URL delle risorse collegate nell'ambiente in cui la presentazione unita sarà aperta.

Aspose.Slides traccia esplicitamente i master clonati automaticamente, ma ciò non deve essere interpretato come una garanzia generale che risorse binarie identiche provenienti da presentazioni di origine non correlate vengano sempre de‑duplicate. Se la dimensione del file di output è importante, ispeziona il pacchetto unito e misura il risultato invece di fare affidamento sulla de‑duplicazione implicita.

### **Font incorporati e disponibilità dei font**

I caratteri sono gestiti a livello di presentazione. Se la tipografia deve rimanere coerente su più macchine, non dare per scontato che la sola clonazione delle diapositive garantisca la disponibilità di tutti i caratteri richiesti nell'ambiente di destinazione. Puoi ispezionare i caratteri incorporati con [FontsManager.GetEmbeddedFonts](https://reference.aspose.com/slides/it/net/aspose.slides/fontsmanager/getembeddedfonts/) e gestire l'incorporamento esplicitamente come descritto in [Incorporare i caratteri nelle presentazioni](/slides/it/net/embedded-font/).

Verifica inoltre di avere l'autorizzazione a incorporare i caratteri usati nei file di origine. Le licenze dei caratteri possono limitare l'incorporamento.

### **Presentazioni protette da password**

Una presentazione di origine protetta da password deve essere aperta correttamente prima che le sue diapositive possano essere clonate. Fornisci la password tramite [LoadOptions.Password](https://reference.aspose.com/slides/it/net/aspose.slides/loadoptions/password/).

```csharp
using Aspose.Slides;

var loadOptions = new LoadOptions { Password = "YOUR_PASSWORD" };

using var source = new Presentation("protected.pptx", loadOptions);
```

L'apertura di una fonte crittografata non applica automaticamente la stessa protezione alla presentazione di destinazione. Configura la protezione dell'output separatamente quando necessario.

### **Presentazioni di grandi dimensioni e utilizzo della memoria**

Le presentazioni di grandi dimensioni contenenti immagini ad alta risoluzione, audio, video o altri oggetti binari di grosse dimensioni possono consumare molta memoria. [LoadOptions.BlobManagementOptions](https://reference.aspose.com/slides/it/net/aspose.slides/loadoptions/blobmanagementoptions/) fornisce controlli per la gestione dei BLOB e l'uso di file temporanei. Vedi [Gestire i BLOB di presentazione](/slides/it/net/manage-blob/) per strategie su file di grandi dimensioni.

Per i file grandi, preferisci caricare da percorsi di file quando possibile, elimina ogni presentazione di origine non appena è stata unita e evita di salvare ripetutamente risultati intermedi a meno che il flusso di lavoro non richieda checkpoint.

### **Sicurezza dei thread**

Non caricare, modificare, salvare o clonare la stessa istanza di [Presentation](https://reference.aspose.com/slides/it/net/aspose.slides/presentation/) contemporaneamente da più thread. Mantieni ogni istanza di presentazione confinata a un'operazione di unione. Se parallelizzi attività indipendenti, usa istanze di presentazione indipendenti e segui le [linee guida sul multithreading di Aspose.Slides](/slides/it/net/multithreading/).

## **FAQ**

**Come posso mantenere il design originale di ogni presentazione di origine?**

Usa [AddClone](https://reference.aspose.com/slides/it/net/aspose.slides/islidecollection/addclone/) senza fornire un master o layout di destinazione. Aspose.Slides può clonare automaticamente il master di origine quando è necessario per la diapositiva importata.

**Come faccio a far sì che le diapositive importate usino il tema di destinazione?**

Usa il sovraccarico che accetta un master di destinazione. Passa un master dalla presentazione di destinazione, non da quella di origine. Aspose.Slides cercherà di mappare ogni diapositiva di origine a un layout appropriato sotto quel master.

**Quando dovrei usare un layout di destinazione specifico invece di un master di destinazione?**

Usa un layout specifico quando ogni diapositiva importata deve usare un layout noto. Usa un master quando vuoi che Aspose.Slides selezioni tra i layout di quel master in base al tipo o al nome del layout di origine.

**È possibile unire presentazioni con dimensioni di diapositiva diverse?**

Sì, ma il contenuto della diapositiva non viene ridisegnato automaticamente per le dimensioni di destinazione. Ridimensiona prima la presentazione di origine quando è necessario un posizionamento prevedibile, ad esempio con [SlideSize.SetSize](https://reference.aspose.com/slides/it/net/aspose.slides/slidesize/setsize/) e [SlideSizeScaleType.EnsureFit](https://reference.aspose.com/slides/it/net/aspose.slides/slidesizescaletype/).

**Posso unire presentazioni PPT, PPTX e ODP in un unico file?**

Sì. Carica ogni presentazione di origine, clona le diapositive richieste in un'unica destinazione e salva la destinazione in un formato di output supportato. Poiché i formati di presentazione non supportano esattamente lo stesso set di funzionalità, verifica i contenuti complessi dopo unioni tra formati diversi. Vedi [Formati di file supportati](/slides/it/net/supported-file-formats/).

**Le sezioni di origine vengono preservate automaticamente?**

No, non con un semplice ciclo che clona solo le diapositive. Ricrea le sezioni necessarie nella destinazione e usa il sovraccarico di sezione di [AddClone](https://reference.aspose.com/slides/it/net/aspose.slides/islidecollection/addclone/) quando la struttura delle sezioni deve essere preservata.

**Le note del relatore e i commenti vengono preservati?**

Vengono copiati con la diapositiva clonata. Per i flussi di lavoro che dipendono dallo stile del master delle note, dagli autori dei commenti o dai dati di revisione nidificati, verifica il risultato unito perché tali scenari coinvolgono strutture a livello di presentazione oltre a contenuti a livello di diapositiva.

**Cosa succede a audio, video, oggetti OLE e collegamenti ipertestuali?**

Il contenuto incorporato viene trasportato come parte delle relazioni di risorsa della diapositiva clonata. I collegamenti esterni rimangono esterni, quindi i loro file o URL di destinazione devono comunque essere disponibili dopo l'unione.

**I font incorporati da ogni origine sono garantiti disponibili nella presentazione unita?**

Non fare affidamento solo sulla clonazione delle diapositive per la distribuzione dei font. Ispeziona i font incorporati nella destinazione e gestisci esplicitamente l'incorporamento dei font o la disponibilità di font esterni quando la tipografia è importante.

**Come unisco un file protetto da password?**

Aprilo con il corretto [LoadOptions.Password](https://reference.aspose.com/slides/it/net/aspose.slides/loadoptions/password/), quindi clona le sue diapositive normalmente. La protezione dell'output viene configurata separatamente.

**Come devo gestire presentazioni molto grandi?**

Usa la gestione dei BLOB quando gli oggetti binari di grandi dimensioni dominano l'uso della memoria, preferisci il caricamento da percorsi di file per file molto grandi, elimina prontamente le presentazioni di origine e salva il risultato finale solo quando necessario.

**Posso unire diapositive da più thread?**

Non utilizzare una singola istanza di [Presentation](https://reference.aspose.com/slides/it/net/aspose.slides/presentation/) contemporaneamente da più thread. Mantieni ogni operazione di unione isolata nelle proprie istanze di presentazione.