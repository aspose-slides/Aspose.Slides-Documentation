---
title: Unire presentazioni in modo efficiente in .NET
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

Aspose.Slides per .NET unisce presentazioni clonando diapositive da una [Presentation](https://reference.aspose.com/slides/it/net/aspose.slides/presentation/) a un’altra. L’operazione principale è [ISlideCollection.AddClone](https://reference.aspose.com/slides/it/net/aspose.slides/islidecollection/addclone/), che può conservare la formattazione della diapositiva di origine o collegare la diapositiva clonata a un master o a un layout nella presentazione di destinazione.

Questo articolo copre i flussi di lavoro di unione più comuni:

- unire tutte le diapositive mantenendo la formattazione di origine;
- unire diapositive selezionate;
- applicare un master dalla presentazione di destinazione;
- applicare un layout specifico dalla presentazione di destinazione;
- normalizzare dimensioni diverse delle diapositive prima dell’unione;
- aggiungere diapositive clonate a una sezione;
- unire più presentazioni in un unico flusso end‑to‑end;
- gestire master, risorse, note, commenti, media, font, password, file di grandi dimensioni e problematiche di multithreading.

## **Come la clonazione delle diapositive influisce su master e layout**

Una diapositiva eredita gran parte del suo aspetto dal layout e dal master. Per questo motivo, l’overload di clonazione scelto determina come la diapositiva unita viene integrata nella presentazione di destinazione.

Usa [ISlideCollection.AddClone](https://reference.aspose.com/slides/it/net/aspose.slides/islidecollection/addclone/) in uno dei seguenti modi:

- `AddClone(sourceSlide)` — conserva il layout e la formattazione della diapositiva di origine. Se necessario, il master di origine può essere clonato automaticamente nella presentazione di destinazione. Aspose.Slides tiene traccia dei master clonati automaticamente in modo che diapositive ripetute che usano lo stesso master di origine non causino una clonazione ripetuta di quel master.
- `AddClone(sourceSlide, destinationMaster, allowCloneMissingLayout)` — collega la diapositiva clonata a uno specifico [IMasterSlide](https://reference.aspose.com/slides/it/net/aspose.slides/imasterslide/) di destinazione. Aspose.Slides cerca un layout corrispondente sotto quel master per tipo o nome di layout.
- `AddClone(sourceSlide, destinationLayout)` — collega direttamente la diapositiva clonata a uno specifico [ILayoutSlide](https://reference.aspose.com/slides/it/net/aspose.slides/ilayoutslide/) di destinazione.

Il master o il layout passati a un overload `AddClone` deve appartenere alla **presentazione di destinazione**, non a quella di origine.

## **Unire presentazioni intere mantenendo la formattazione di origine**

L’unione più semplice copia ogni diapositiva dalla presentazione di origine a quella di destinazione. Questa è la scelta appropriata quando le diapositive importate devono mantenere il tema, il master e le relazioni di layout originali.

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

La presentazione risultante può contenere più master quando l’origine e la destinazione usano design differenti. Questo è previsto quando la formattazione di origine viene intenzionalmente preservata.

## **Unire diapositive selezionate**

Non è necessario clonare ogni diapositiva. L’esempio seguente importa solo gli indici di diapositiva selezionati dalla presentazione di origine.

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

Convalida gli indici delle diapositive prima di clonare quando provengono da input dell’utente o da configurazioni esterne.

## **Unire diapositive usando un master di destinazione**

Usa l’overload [AddClone(ISlide, IMasterSlide, Boolean)](https://reference.aspose.com/slides/it/net/aspose.slides/islidecollection/addclone/) quando le diapositive importate devono seguire un master che già appartiene alla presentazione di destinazione.

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

Aspose.Slides seleziona un layout appropriato sotto il master specificato corrispondendo al tipo o al nome del layout di origine. Se non esiste un layout adatto e `allowCloneMissingLayout` è `true`, il layout di origine viene clonato così la diapositiva può essere aggiunta. Se è `false`, viene lanciata una [PptxEditException](https://reference.aspose.com/slides/it/net/aspose.slides/pptxeditexception/).

Usa `false` quando vuoi che l’unione fallisca anziché introdurre un layout aggiuntivo nel master di destinazione.

## **Unire diapositive usando un layout di destinazione specifico**

Usa l’overload [AddClone(ISlide, ILayoutSlide)](https://reference.aspose.com/slides/it/net/aspose.slides/islidecollection/addclone/) quando sai esattamente quale layout di destinazione devono usare le diapositive importate.

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

Applicare un layout di destinazione cambia la relazione di layout ereditata; non ridisegna il contenuto della diapositiva di origine. Se i layout di origine e di destinazione hanno strutture di segnaposto diverse, ispeziona il risultato per confermare che la formattazione ereditata e il comportamento dei segnaposto siano appropriati.

## **Unire presentazioni con dimensioni di diapositiva diverse**

Le presentazioni con dimensioni di diapositiva differenti possono essere unite, ma clonare una diapositiva in una presentazione con un’altra dimensione non ridisegna automaticamente il contenuto per il nuovo canvas. Le forme possono quindi apparire spostate, scalate in modo inatteso o fuori dall’area visibile della diapositiva.

Un approccio pratico è ridimensionare la presentazione di origine prima della clonazione. Il metodo [SlideSize.SetSize](https://reference.aspose.com/slides/it/net/aspose.slides/slidesize/setsize/) può scalare il contenuto esistente cambiando le dimensioni della diapositiva. [SlideSizeScaleType.EnsureFit](https://reference.aspose.com/slides/it/net/aspose.slides/slidesizescaletype/) scala il contenuto per adattarlo alla dimensione richiesta.

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

Il ridimensionamento modifica l’oggetto della presentazione di origine in memoria. Se hai bisogno che la presentazione di origine rimanga invariata per altre operazioni, apri un’istanza separata per l’unione.

## **Unire diapositive in una sezione di presentazione**

Il ciclo base di clonazione delle diapositive non ricrea la gerarchia di sezioni della presentazione di origine. Se le sezioni sono rilevanti nell’output, crea o seleziona le sezioni nella presentazione di destinazione e clona le diapositive in esse esplicitamente con [AddClone(ISlide, ISection)](https://reference.aspose.com/slides/it/net/aspose.slides/islidecollection/addclone/).

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

Le diapositive clonate vengono aggiunte alla sezione di destinazione specificata. Per preservare più sezioni di origine, ricrea quelle sezioni nella destinazione e mappa ogni diapositiva di origine alla sezione di destinazione corrispondente.

## **Unire più presentazioni in modo sicuro**

L’esempio end‑to‑end seguente utilizza la prima presentazione come destinazione, normalizza la dimensione delle diapositive di ogni presentazione di origine aggiuntiva, mantiene aperta ciascuna origine solo mentre viene copiata e salva il file finale una sola volta.

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

Questo è un utile punto di partenza per preservare la formattazione di origine delle diapositive importate. Se il tuo output deve usare un tema di destinazione unico, sostituisci la semplice chiamata `AddClone(slide)` con l’overload master‑di‑destinazione o layout‑di‑destinazione mostrato in precedenza.

## **Considerazioni pratiche**

### **Master, layout e fedeltà della formattazione**

La clonazione predefinita delle diapositive può inserire automaticamente un master richiesto nella presentazione di destinazione. Aspose.Slides mantiene un registro interno per i master clonati automaticamente, evitando di clonare lo stesso master più volte. I master clonati manualmente non vengono tracciati da quel registro, quindi evita di pre‑clonare i master a meno che non sia necessario un controllo esplicito sulla struttura del master.

Non presumere che due master o layout con lo stesso nome siano visualmente equivalenti. Se un modello aziendale deve controllare l’aspetto finale, scegli esplicitamente un master o un layout di destinazione e verifica il risultato dopo l’unione.

### **Note e commenti**

Le note del relatore e i commenti delle diapositive sono associati al contenuto della diapositiva e vengono copiati quando una diapositiva è clonata. Aspose.Slides espone inoltre API dedicate per [presentation notes](https://docs.aspose.com/slides/it/net/presentation-notes/) e [presentation comments](https://docs.aspose.com/slides/it/net/presentation-comments/).

Se la formattazione della pagina delle note è importante, verifica la presentazione unita perché i master delle note sono oggetti a livello di presentazione e possono differire tra i file di origine. Per i flussi di revisione, verifica anche gli autori dei commenti e i commenti annidati dopo aver combinato file provenienti da autori o modelli diversi.

### **Immagini, audio, video, oggetti OLE e collegamenti esterni**

Le diapositive possono fare riferimento a risorse a livello di presentazione come immagini, audio incorporato, video incorporato e dati OLE. Clona l’intera diapositiva anziché copiare solo le forme visibili così Aspose.Slides può mantenere le relazioni della diapositiva con le sue risorse.

Le risorse incorporate e quelle collegate devono essere trattate in modo diverso. Un audio, video, oggetto OLE o collegamento ipertestuale collegato rimane dipendente dal suo target esterno; clonare una diapositiva non trasforma un collegamento esterno in contenuto incorporato. Testa i percorsi e gli URL delle risorse collegate nell’ambiente in cui la presentazione unita sarà aperta.

Aspose.Slides traccia esplicitamente i master clonati automaticamente, ma ciò non costituisce una garanzia generale che risorse binarie identiche provenienti da presentazioni di origine non correlate vengano sempre deduplicate. Se la dimensione del file di output è importante, ispeziona il pacchetto unito e misura il risultato invece di basarti su una deduplicazione implicita.

### **Font incorporati e disponibilità dei font**

I font sono gestiti a livello di presentazione. Se la tipografia deve rimanere coerente su più macchine, non presumere che la sola clonazione delle diapositive garantisca la presenza di tutti i font richiesti nell’ambiente di destinazione. Puoi ispezionare i font incorporati con [FontsManager.GetEmbeddedFonts](https://reference.aspose.com/slides/it/net/aspose.slides/fontsmanager/getembeddedfonts/) e gestire l’incorporamento esplicitamente come descritto in [Embed Fonts in Presentations](https://docs.aspose.com/slides/it/net/embedded-font/).

Verifica anche di avere i diritti per incorporare i font utilizzati nei file di origine. Le licenze dei font possono limitare l’incorporamento.

### **Presentazioni protette da password**

Una sorgente protetta da password deve essere aperta con successo prima che le sue diapositive possano essere clonate. Fornisci la password tramite [LoadOptions.Password](https://reference.aspose.com/slides/it/net/aspose.slides/loadoptions/password/).

```csharp
using Aspose.Slides;

var loadOptions = new LoadOptions { Password = "YOUR_PASSWORD" };

using var source = new Presentation("protected.pptx", loadOptions);
```

Aprire una sorgente crittografata non applica automaticamente la stessa protezione alla presentazione di destinazione. Configura la protezione dell’output separatamente quando necessario.

### **Presentazioni di grandi dimensioni e utilizzo della memoria**

Le presentazioni di grandi dimensioni contenenti immagini ad alta risoluzione, audio, video o altri oggetti binari voluminosi possono consumare molta memoria. [LoadOptions.BlobManagementOptions](https://reference.aspose.com/slides/it/net/aspose.slides/loadoptions/blobmanagementoptions/) fornisce controlli per la gestione dei BLOB e l’uso di file temporanei. Consulta [Manage Presentation BLOBs](https://docs.aspose.com/slides/it/net/manage-blob/) per le strategie con file di grandi dimensioni.

Per file di grandi dimensioni, preferisci il caricamento da percorsi file quando possibile, rilascia ogni presentazione di origine appena è stata unita e evita di salvare ripetutamente risultati intermedi a meno che il flusso di lavoro non richieda checkpoint.

### **Sicurezza dei thread**

Non caricare, modificare, salvare o clonare la stessa istanza di [Presentation](https://reference.aspose.com/slides/it/net/aspose.slides/presentation/) contemporaneamente da più thread. Mantieni ogni istanza di presentazione confinata a un’unica operazione di unione. Se parallelizzi lavori indipendenti, usa istanze di presentazione indipendenti e segui le [Aspose.Slides multithreading guidance](https://docs.aspose.com/slides/it/net/multithreading/).

## **FAQ**

**Come mantenere il design originale di ciascuna presentazione di origine?**

Usa [`AddClone(sourceSlide)`](https://reference.aspose.com/slides/it/net/aspose.slides/islidecollection/addclone/) senza fornire un master o un layout di destinazione. Aspose.Slides può clonare automaticamente il master di origine quando è necessario per la diapositiva importata.

**Come faccio a far usare alle diapositive importate il tema di destinazione?**

Usa l’overload che accetta un master di destinazione. Passa un master della presentazione di destinazione, non quello di origine. Aspose.Slides proverà a mappare ciascuna diapositiva di origine a un layout appropriato sotto quel master.

**Quando devo usare un layout di destinazione specifico invece di un master di destinazione?**

Usa un layout specifico quando ogni diapositiva importata deve utilizzare un unico layout noto. Usa un master quando desideri che Aspose.Slides selezioni tra i layout del master in base al tipo o al nome del layout di origine.

**Possono essere unite presentazioni con dimensioni di diapositiva diverse?**

Sì, ma il contenuto della diapositiva non viene ridisegnato automaticamente per le dimensioni di destinazione. Ridimensiona prima la presentazione di origine quando hai bisogno di un posizionamento prevedibile, ad esempio con [SlideSize.SetSize](https://reference.aspose.com/slides/it/net/aspose.slides/slidesize/setsize/) e [SlideSizeScaleType.EnsureFit](https://reference.aspose.com/slides/it/net/aspose.slides/slidesizescaletype/).


**Posso unire file PPT, PPTX e ODP in un unico file?**

Sì. Carica ogni presentazione di origine, clona le diapositive richieste in una destinazione e salva la destinazione in un formato di output supportato. Poiché i formati di presentazione non supportano esattamente lo stesso insieme di funzionalità, verifica il contenuto complesso dopo unioni tra formati diversi. Vedi [Supported File Formats](https://docs.aspose.com/slides/it/net/supported-file-formats/).

**Le sezioni di origine sono preservate automaticamente?**

No, non con un semplice ciclo che clona solo le diapositive. Ricrea le sezioni richieste nella destinazione e utilizza l’overload di sezione di [AddClone](https://reference.aspose.com/slides/it/net/aspose.slides/islidecollection/addclone/) quando la struttura delle sezioni deve essere preservata.

**Le note del relatore e i commenti sono preservati?**

Vengono copiati con la diapositiva clonata. Per i flussi di lavoro che dipendono dallo styling del master delle note, dagli autori dei commenti o dai dati di revisione annidati, verifica il risultato unito perché tali scenari coinvolgono strutture a livello di presentazione oltre al contenuto delle diapositive.

**Cosa succede a audio, video, oggetti OLE e collegamenti ipertestuali?**

Il contenuto incorporato viene trasportato come parte delle relazioni di risorsa della diapositiva clonata. I collegamenti esterni rimangono esterni, quindi i loro file o URL di destinazione devono comunque essere disponibili dopo l’unione.

**I font incorporati da ogni origine sono garantiti disponibili nella presentazione unita?**

Non fare affidamento solo sulla clonazione delle diapositive per la distribuzione dei font. Ispeziona i font incorporati nella destinazione e gestisci esplicitamente l’incorporamento dei font o la disponibilità di font esterni quando la tipografia è importante.

**Come unisco un file protetto da password?**

Aprilo con il corretto [LoadOptions.Password](https://reference.aspose.com/slides/it/net/aspose.slides/loadoptions/password/), quindi clona le sue diapositive normalmente. La protezione dell’output viene configurata separatamente.

**Come gestire presentazioni molto grandi?**

Usa la gestione dei BLOB quando gli oggetti binari di grandi dimensioni dominano l’utilizzo della memoria, preferisci il caricamento da percorsi file per file molto grandi, rilascia prontamente le presentazioni di origine e salva il risultato finale solo quando necessario.

**Posso unire diapositive da più thread?**

Non utilizzare una singola istanza di [Presentation](https://reference.aspose.com/slides/it/net/aspose.slides/presentation/) contemporaneamente da più thread. Mantieni ogni operazione di unione isolata con proprie istanze di presentazione.