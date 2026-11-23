---
title: Automatizza la personalizzazione delle presentazioni con Mail Merge
linktitle: Mail Merge
type: docs
weight: 233
url: /it/net/mail-merge/
keywords:
- Mail Merge
- personalizzazione della presentazione
- modello di presentazione
- segnaposto di testo
- fonte dati
- CSV
- Excel
- XLSX
- JSON
- XML
- fusione dei dati
- generare presentazioni
- .NET
- C#
- Aspose.Slides
description: "Scopri come utilizzare Mail Merge in Aspose.Slides per .NET per popolare i modelli di presentazione con i dati e generare presentazioni PowerPoint personalizzate da fonti CSV, Excel, JSON e XML."
---
## **Unione di posta in presentazioni PowerPoint**

Aspose.Slides per .NET consente di generare automaticamente presentazioni PowerPoint utilizzando un modello e una fonte di dati. Mail Merge riempie i segnaposto del modello con i dati e crea oppure una singola presentazione contenente diapositive modello ripetute per ogni set di dati, oppure una presentazione separata per ogni set di dati.

Questa funzionalità è utile per generare cataloghi di prodotti, presentazioni personalizzate, report, certificati, proposte, listini prezzi e altri documenti in cui la struttura della presentazione rimane invariata mentre il contenuto varia.

![Mail Merge: prima e dopo](mail-merge-before-after.png)


## **Come funziona Mail Merge**

Mail Merge utilizza una presentazione PowerPoint come modello e sostituisce i segnaposto con i valori provenienti da una fonte di dati.

![Flusso di lavoro Mail Merge](mail-merge-workflow.png)

Un segnaposto è un nome di campo racchiuso tra doppie parentesi graffe, ad esempio `{{title}}` o `{{price}}`. I segnaposto possono essere inseriti nel testo di forme, celle di tabelle, forme raggruppate e note del relatore.

Ad esempio, una diapositiva modello può contenere il seguente testo:

- `Prodotto: {{title}}`
- `Prezzo: {{price}}`
- `Descrizione: {{description}}`

Quando la fonte di dati contiene i seguenti valori:

| Campo | Valore |
|---|---|
| title | Laptop X1 |
| price | $999 |
| description | 14-inch display, 16 GB RAM |

Mail Merge sostituisce i segnaposto con i valori corrispondenti, producendo una diapositiva con le informazioni reali del prodotto.

I nomi dei campi non distinguono tra maiuscole e minuscole, quindi `{{title}}` e `{{Title}}` si riferiscono allo stesso campo.

Le seguenti regole si applicano durante la sostituzione dei segnaposto:

- I segnaposto sono sostituiti nelle diapositive, comprese le forme raggruppate e le celle di tabelle, e nelle note del relatore.
- I segnaposto nelle diapositive master e layout non vengono sostituiti.
- Un segnaposto il cui campo non è presente nel set di dati rimane invariato.
- Un valore di campo vuoto sostituisce il segnaposto con una stringa vuota.
- Il testo inserito eredita la formattazione del primo carattere del segnaposto.
- I valori non devono contenere testo di segnaposto, perché il testo inserito potrebbe essere elaborato nuovamente e sostituito da un altro campo.

La presentazione modello originale non viene modificata durante l'operazione di unione e deve contenere almeno una diapositiva.

## **Origini dati supportate**

Mail Merge supporta due modalità per fornire i dati:

- Creare una fonte di dati programmaticamente utilizzando `IMailMergeDataSource`.
- Leggere i dati da un file o stream CSV, XLSX, JSON o XML.

Il formato dei dati viene rilevato dal contenuto, non dall'estensione del file. Sono supportati anche gli stream che non consentono il seeking.

La fonte di dati deve contenere almeno un set di dati. Ogni set rappresenta una copia del modello da riempire con i propri valori.

Se il contenuto dei dati non può essere riconosciuto come un formato supportato, viene sollevata `NotSupportedException`. Se il contenuto è riconosciuto ma non rispetta i requisiti di formato, viene sollevata `InvalidDataException`. Il messaggio dell'eccezione contiene la posizione dell'errore nei dati.

### **JSON**

La fonte di dati JSON deve avere un oggetto radice contenente un array `sets`. Cada elemento dell'array rappresenta un set di dati e deve contenere un array `fields`. Cada campo deve avere una proprietà `name` e una `value` di tipo stringa.

La proprietà opzionale `version` deve essere `"1.0"`, e la proprietà opzionale `type` di un campo deve essere `"text"`. I nomi delle proprietà sono sensibili al maiuscolo/minuscolo. Le proprietà sconosciute vengono ignorate.

I dati JSON vengono letti come UTF-8, o come UTF-16 quando i dati iniziano con un byte order mark (BOM).

L'esempio seguente contiene due set di dati:

```json
{
  "version": "1.0",
  "sets": [
    {
      "fields": [
        { "name": "title", "value": "Laptop X1" },
        { "name": "price", "value": "$999" }
      ]
    },
    {
      "fields": [
        { "name": "title", "value": "Tablet S2" },
        { "name": "price", "value": "$499" }
      ]
    }
  ]
}
```

### **XML**

La fonte di dati XML deve avere un elemento radice `template` contenente l'elemento `sets`. Cada elemento `set` contiene elementi `field`, e cada campo deve contenere gli elementi `name` e `value`.

Un elemento `value` vuoto è trattato come una stringa vuota. I nomi degli elementi sono sensibili al maiuscolo/minuscolo. Gli elementi e i commenti sconosciuti vengono ignorati. La codifica è determinata dalla dichiarazione XML. Non sono consentiti DTD.

```xml
<?xml version="1.0" encoding="utf-8"?>
<template>
  <sets>
    <set>
      <field>
        <name>title</name>
        <value>Laptop X1</value>
      </field>
      <field>
        <name>price</name>
        <value>$999</value>
      </field>
    </set>
    <set>
      <field>
        <name>title</name>
        <value>Tablet S2</value>
      </field>
      <field>
        <name>price</name>
        <value>$499</value>
      </field>
    </set>
  </sets>
</template>
```

### **CSV**

I dati CSV utilizzano i punti e virgola come separatori di valore.

La prima riga contiene i nomi dei campi e termina al primo nome di campo vuoto. Cada riga successiva rappresenta un set di dati. I dati terminano alla prima riga vuota.

Si applicano le seguenti regole:

- I valori mancanti alla fine di una riga vengono trattati come stringhe vuote.
- I valori oltre i nomi di campo definiti vengono ignorati.
- Un valore contenente un punto e virgola, virgolette o interruzione di riga deve essere racchiuso tra virgolette.
- Le virgolette all'interno di un valore tra virgolette devono essere raddoppiate.
- I dati vengono letti come UTF-8, oppure come UTF-16 quando iniziano con un byte order mark (BOM).

Esempio:

```csv
title;price;description
Laptop X1;$999;"14"" display; 16 GB RAM"
Tablet S2;$499;
```

### **XLSX**

I dati XLSX vengono letti dal primo foglio di lavoro.

Il foglio di lavoro segue le stesse regole del CSV:

- La prima riga contiene i nomi dei campi e termina alla prima cella vuota.
- Cada riga successiva rappresenta un set di dati.
- I dati terminano alla prima riga vuota.
- Le celle vuote vengono trattate come stringhe vuote.
- I valori numerici vengono convertiti in testo usando la cultura invariante.

## **Creare una singola presentazione**

Il metodo `MergeToSinglePresentation` crea una presentazione contenente una copia delle diapositive modello per ogni set di dati. Cada copia è riempita con i dati corrispondenti.

L'ordine dei set di dati determina l'ordine dei gruppi di diapositive nella presentazione risultante.

### **Unire dati da un file**

L'esempio seguente carica un modello e un file di dati JSON, crea una singola presentazione contenente le diapositive per tutti i set di dati e salva il risultato.

```csharp
using Aspose.Slides;
using Aspose.Slides.MailMerge;

MailMergeProcessor mailMerge = new MailMergeProcessor();

using (Presentation template = new Presentation("template.pptx"))
using (IPresentation result = mailMerge.MergeToSinglePresentation(template, "products.json"))
{
    result.Save("catalog.pptx", SaveFormat.Pptx);
}
```

I dati possono anche essere letti da uno stream. Lo stream viene letto a partire dalla sua posizione corrente e non viene chiuso dall'operazione di Mail Merge.

```csharp
using Aspose.Slides;
using Aspose.Slides.MailMerge;
using System.IO;

MailMergeProcessor mailMerge = new MailMergeProcessor();

using (Stream data = File.OpenRead("products.xml"))
using (Presentation template = new Presentation("template.pptx"))
using (IPresentation result = mailMerge.MergeToSinglePresentation(template, data))
{
    result.Save("catalog.pptx", SaveFormat.Pptx);
}
```

### **Creare una fonte di dati in codice**

Puoi costruire una fonte di dati programmaticamente usando `MailMergeDataSource` e `MailMergeDataSet`. Aggiungi un set di dati per ogni record e definisci i suoi campi usando il metodo `AddText`.

```csharp
using Aspose.Slides;
using Aspose.Slides.MailMerge;

MailMergeDataSource source = new MailMergeDataSource();

IMailMergeDataSet laptop = source.AddDataSet();
laptop.AddText("title", "Laptop X1");
laptop.AddText("price", "$999");

IMailMergeDataSet tablet = source.AddDataSet();
tablet.AddText("title", "Tablet S2");
tablet.AddText("price", "$499");

MailMergeProcessor mailMerge = new MailMergeProcessor();

using (Presentation template = new Presentation("template.pptx"))
using (IPresentation result = mailMerge.MergeToSinglePresentation(template, source))
{
    result.Save("catalog.pptx", SaveFormat.Pptx);
}
```

In questo esempio, le diapositive modello sono ripetute due volte: una per il laptop e una per il tablet. I segnaposto sono riempiti usando i valori definiti in ogni set di dati.

## **Creare più presentazioni**

Se ti serve una presentazione separata per ogni set di dati, usa il metodo `MergeToMultiplePresentations`.

Questo metodo elabora i set di dati uno alla volta, crea una presentazione dal modello, la riempie con i dati correnti e passa la presentazione risultante a un gestore.

Il gestore è invocato una volta per ogni set di dati, nell'ordine originale dei dati.

### **Salvare ogni presentazione**

L'esempio seguente legge i dati da un file CSV e salva ogni presentazione generata come file separato.

```csharp
using Aspose.Slides;
using Aspose.Slides.MailMerge;

MailMergeProcessor mailMerge = new MailMergeProcessor();

using (Presentation template = new Presentation("template.pptx"))
{
    mailMerge.MergeToMultiplePresentations(
        template,
        "products.csv",
        (presentation, args) =>
        {
            presentation.Save(
                "product_" + (args.Index + 1) + ".pptx",
                SaveFormat.Pptx);
        });
}
```

La proprietà `args.Index` fornisce l'indice basato su zero del set di dati corrente. Nell'esempio, viene usato per generare nomi file sequenziali a partire da `product_1.pptx`.

I dati possono anche essere letti da uno stream:

```csharp
using Aspose.Slides;
using Aspose.Slides.MailMerge;
using System.IO;

MailMergeProcessor mailMerge = new MailMergeProcessor();

using (Stream data = File.OpenRead("products.xlsx"))
using (Presentation template = new Presentation("template.pptx"))
{
    mailMerge.MergeToMultiplePresentations(
        template,
        data,
        (presentation, args) =>
        {
            presentation.Save(
                "product_" + (args.Index + 1) + ".pptx",
                SaveFormat.Pptx);
        });
}
```

### **Usare i valori del set di dati per nominare i file**

Il gestore riceve sia la presentazione generata sia le informazioni sul set di dati usato per crearla. Puoi usare i valori del set di dati per costruire nomi file significativi.

Ad esempio, il codice seguente salva ogni presentazione usando il titolo del prodotto:

```csharp
using Aspose.Slides;
using Aspose.Slides.MailMerge;

MailMergeProcessor mailMerge = new MailMergeProcessor();

using (Presentation template = new Presentation("template.pptx"))
{
    mailMerge.MergeToMultiplePresentations(
        template,
        "products.json",
        (presentation, args) =>
        {
            string title = args.DataSet.GetText("title");
            string fileName = title != null
                ? title
                : "product_" + (args.Index + 1);

            presentation.Save(fileName + ".pptx", SaveFormat.Pptx);
        });
}
```

La proprietà `DataSet` restituisce il set di dati usato per riempire la presentazione corrente. Il metodo `GetText` recupera il valore di un campo specificato, o `null` se il campo non è presente.

Questo ti consente di usare i valori dei dati per nominare i file, organizzare l'output o applicare ulteriori elaborazioni nel gestore.

## **Gestire le presentazioni generate**

`MergeToMultiplePresentations` utilizza il delegato `MailMergedPresentationHandler` per elaborare ogni presentazione generata.

Il gestore riceve due argomenti:

- `presentation` — la presentazione creata dal modello e riempita con il set di dati corrente.
- `args` — informazioni sulla presentazione generata, includendo l'indice del set di dati e il set di dati stesso.

La presentazione generata è di proprietà dell'operazione di Mail Merge e viene eliminata subito dopo che il gestore restituisce. Pertanto, devi salvarla o copiare i dati necessari all'interno del gestore. Non conservare un riferimento dopo il ritorno del gestore né eliminarla manualmente.

Il gestore viene eseguito sul thread chiamante, una presentazione alla volta, nell'ordine dei set di dati. Solo una presentazione generata è tenuta in memoria alla volta, rendendo questo approccio adatto all'elaborazione di grandi fonti di dati senza mantenere tutte le presentazioni in memoria contemporaneamente.

Se il gestore solleva un'eccezione, l'operazione di Mail Merge si interrompe e l'eccezione viene propagata al chiamante invariata. Le presentazioni già elaborate rimangono inalterate e i set di dati rimanenti non vengono elaborati.

L'esempio seguente salva le presentazioni generate in una directory dedicata:

```csharp
using Aspose.Slides;
using Aspose.Slides.MailMerge;
using System.IO;

string outputFolder = "output";
Directory.CreateDirectory(outputFolder);

MailMergeProcessor mailMerge = new MailMergeProcessor();

using (Presentation template = new Presentation("template.pptx"))
{
    mailMerge.MergeToMultiplePresentations(
        template,
        "products.json",
        (presentation, args) =>
        {
            string path = Path.Combine(
                outputFolder,
                "product_" + (args.Index + 1) + ".pptx");

            presentation.Save(path, SaveFormat.Pptx);
        });
}
```

## **Lavorare con i dati di Mail Merge**

La classe `MailMergeDataSource` rappresenta una collezione ordinata di set di dati. Può essere usata per creare dati in codice, ispezionare il numero di set di dati e accedere a set di dati individuali per indice.

### **Ottenere il numero di set di dati**

La proprietà `Count` restituisce il numero di set di dati nella fonte.

```csharp
MailMergeDataSource source = new MailMergeDataSource();

source.AddDataSet().AddText("title", "Laptop X1");
source.AddDataSet().AddText("title", "Tablet S2");

Console.WriteLine("Presentations to create: " + source.Count);
```

### **Accedere a un set di dati per indice**

La proprietà `Item(int)` fornisce l'accesso a un set di dati all'indice specificato (indice basato su zero).

```csharp
MailMergeDataSource source = new MailMergeDataSource();

source.AddDataSet().AddText("title", "Laptop X1");
source.AddDataSet().AddText("title", "Tablet S2");

Console.WriteLine(source[1].GetText("title"));
```

Questo esempio recupera il titolo del secondo set di dati.

### **Aggiungere campi di testo**

Il metodo `AddText` aggiunge un campo di testo nominato a un set di dati. Il valore del campo sostituisce tutti i segnaposto corrispondenti nel modello.

```csharp
MailMergeDataSource source = new MailMergeDataSource();

IMailMergeDataSet dataSet = source.AddDataSet();
dataSet.AddText("title", "Laptop X1");
dataSet.AddText("subtitle", string.Empty);
```

Un valore vuoto rimuove il segnaposto corrispondente dal testo risultante. Se il campo non è aggiunto al set di dati, il segnaposto rimane invariato.

### **Leggere campi di testo**

Il metodo `GetText` recupera il valore di un campo per nome. I nomi dei campi non distinguono tra maiuscole e minuscole.

```csharp
IMailMergeDataSet dataSet = source[0];

string title = dataSet.GetText("title");
string price = dataSet.GetText("price");
```

Se il campo non esiste o il nome del campo specificato è `null`, `GetText` restituisce `null`.

## **Riepilogo**

Mail Merge in Aspose.Slides per .NET fornisce un modo comodo per generare presentazioni guidate dai dati a partire da un modello riutilizzabile.

Puoi usarlo per:

- Popolare i modelli di presentazione con valori provenienti da fonti di dati.
- Generare una singola presentazione contenente diapositive modello ripetute per più set di dati.
- Creare una presentazione separata per ogni set di dati.
- Leggere i dati da file o stream CSV, XLSX, JSON e XML.
- Costruire fonti di dati direttamente nel codice.
- Elaborare e salvare le presentazioni generate in sequenza usando un gestore.

Combinando modelli riutilizzabili con dati strutturati, puoi automatizzare la creazione di un gran numero di presentazioni mantenendo separati il design del modello e la logica di elaborazione dei dati.

## **Domande frequenti**

**Posso usare lo stesso segnaposto più volte in un modello?**

Sì. Cada occorrenza di un segnaposto con un nome campo corrispondente viene sostituita con il valore corrispondente dal set di dati corrente.

**I nomi dei campi sono sensibili al maiuscolo/minuscolo?**

No. I nomi dei segnaposto e dei campi dati non distinguono tra maiuscole e minuscole. Ad esempio, `{{title}}`, `{{Title}}` e `{{TITLE}}` si riferiscono allo stesso campo.

**Cosa succede se un campo è mancante in un set di dati?**

Se il set di dati non contiene un campo riferito da un segnaposto, quel segnaposto rimane invariato nella presentazione generata.

**Cosa succede se un campo ha un valore vuoto?**

Un valore di campo vuoto sostituisce il segnaposto con una stringa vuota. Il testo del segnaposto viene rimosso, lasciando nessun testo al suo posto.

**Posso preservare la formattazione di un segnaposto durante la sostituzione?**

Il testo di sostituzione eredita la formattazione del primo carattere del segnaposto. Applica la formattazione desiderata al testo del segnaposto nel modello prima di eseguire l'unione.

**Mail Merge sostituisce i segnaposto nelle diapositive master o layout?**

No. Mail Merge sostituisce i segnaposto nei contenuti supportati delle diapositive della presentazione, incluse forme, forme raggruppate, celle di tabelle e note del relatore. I segnaposto nelle diapositive master e layout non vengono sostituiti.

**La presentazione modello viene modificata durante l'unione?**

No. Il modello originale non viene modificato dall'operazione di unione. Puoi riutilizzarlo per generare presentazioni dallo stesso o da diversi set di dati.

**Posso generare una presentazione separata per ogni set di dati?**

Sì. Usa `MergeToMultiplePresentations` e salva ogni presentazione generata all'interno del gestore. Il gestore viene chiamato in sequenza per ogni set di dati.

**Posso combinare tutti i set di dati in una singola presentazione?**

Sì. Usa `MergeToSinglePresentation`. Crea una singola presentazione di output contenente una copia delle diapositive modello per ogni set di dati, nell'ordine della fonte dati.

**Posso usare una fonte di dati senza salvarla su un file?**

Sì. Puoi creare un `MailMergeDataSource` in codice, aggiungere set di dati e popolare i campi usando `AddText`. Questo è utile quando i dati sono già disponibili nella tua applicazione.

**Mail Merge rileva il formato dei dati dall'estensione del file?**

No. Il formato dei dati viene rilevato dal contenuto, quindi una fonte dati supportata non deve utilizzare una particolare estensione di file.

**Posso leggere dati da uno stream che non supporta il seeking?**

Sì. Mail Merge supporta stream non ricercabili.

**Cosa succede se la fonte dati è vuota o non contiene set di dati?**

La fonte dati deve contenere almeno un set di dati. Assicurati che includa almeno un record prima di avviare l'operazione di unione.

**Cosa succede se la fonte dati ha un formato non valido?**

Se il contenuto non è riconosciuto come uno dei formati di dati supportati, viene sollevata `NotSupportedException`. Se è riconosciuto ma malformato, viene sollevata `InvalidDataException`. Il messaggio dell'eccezione include informazioni sulla posizione dell'errore.

**Posso usare la presentazione generata dopo che il gestore ha restituito?**

La presentazione passata al gestore `MergeToMultiplePresentations` è di proprietà di Mail Merge e viene eliminata dopo che il gestore restituisce. Salvala o copia il contenuto necessario all'interno del gestore, e non mantenere o eliminare manualmente quella presentazione.

**Il gestore viene chiamato in parallelo?**

No. Le presentazioni generate vengono elaborate in sequenza, sul thread del chiamante. Solo una presentazione generata è mantenuta in memoria alla volta da questa operazione.

**Cosa succede se si verifica un'eccezione all'interno del gestore?**

L'operazione di unione si interrompe e l'eccezione viene propagata al chiamante invariata. Le presentazioni già elaborate non sono influenzate e i set di dati successivi non vengono elaborati.

**Posso usare i valori dei campi per generare nomi di file di output?**

Sì. Il gestore fornisce il set di dati corrente tramite i suoi argomenti. Usa `GetText` per recuperare i campi e costruire un nome file per ogni presentazione generata. Assicurati che i valori siano validi come nomi di file nell'ambiente di destinazione.