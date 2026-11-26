---
title: Gestire le proprietà della presentazione in .NET
linktitle: Proprietà della presentazione
type: docs
weight: 70
url: /it/net/presentation-properties/
keywords:
- Proprietà PowerPoint
- Proprietà della presentazione
- Proprietà del documento
- Proprietà integrate
- Proprietà personalizzate
- Proprietà avanzate
- Gestire le proprietà
- Modificare le proprietà
- Metadati del documento
- Modificare i metadati
- Lingua di verifica
- Lingua predefinita
- PowerPoint
- OpenDocument
- Presentazione
- .NET
- C#
- Aspose.Slides
description: "Gestisci le proprietà della presentazione in Aspose.Slides per .NET e semplifica la ricerca, il branding e il flusso di lavoro nei tuoi file PowerPoint e OpenDocument."
---
## **Introduzione**

Aspose.Slides per .NET supporta le proprietà del documento **integrate** e **personalizzate**. Usa queste proprietà per leggere e aggiornare i metadati della presentazione, come autore, titolo e valori definiti dall'utente.

Aspose.Slides consente di lavorare con le proprietà del documento di presentazione tramite l'interfaccia [IDocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/) . Un'istanza di questa interfaccia è restituita da [IPresentation.DocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/ipresentation/documentproperties/). I seguenti esempi mostrano come leggere, modificare e gestire queste proprietà.

{{% alert color="info" title="Note" %}}
Aspose.Slides gestisce i metadati dell'applicazione e del produttore durante il salvataggio delle presentazioni; questi campi identificano il software che ha creato il risultato.
{{% /alert %}}

## **Gestire le proprietà della presentazione**

Le proprietà del documento memorizzano informazioni descrittive accanto al contenuto della presentazione. Si dividono in due categorie:

- **Proprietà integrate** contengono metadati standard, come titolo, autore e statistiche del documento.
- **Proprietà personalizzate** memorizzano coppie nome/valore definite dall'utente.

Aspose.Slides per .NET fornisce l'accesso a entrambe le categorie. In PowerPoint, seleziona **File → Info → Properties → Advanced Properties** per ispezionare i metadati del documento. La finestra raggruppa le informazioni in schede come **Summary**, **Statistics**, **Contents** e **Custom**. Usa la scheda **Custom** per gestire le proprietà definite dall'utente.

## **Leggere le proprietà pubbliche da una presentazione crittografata**

Una password di apertura protegge normalmente sia il contenuto della presentazione sia le proprietà del documento. Quando una presentazione è crittografata con [IProtectionManager.EncryptDocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/iprotectionmanager/encryptdocumentproperties/) impostato su `false`, le sue proprietà del documento restano pubbliche. Un'applicazione può quindi impostare [LoadOptions.OnlyLoadDocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/onlyloaddocumentproperties/) su `true` e leggere i metadati pubblici senza fornire la password di apertura.

[LoadOptions.OnlyLoadDocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/onlyloaddocumentproperties/) controlla cosa Aspose.Slides carica; non decritta nulla. Se le proprietà erano incluse nella crittografia, il loro caricamento senza password fallisce. Se la presentazione non è crittografata, l'opzione viene ignorata e viene caricata l'intera presentazione.

L'esempio richiede una presentazione crittografata le cui proprietà del documento sono state lasciate pubbliche. Verifica la modalità di caricamento tramite [IProtectionManager.IsOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/net/aspose.slides/iprotectionmanager/isonlydocumentpropertiesloaded/) e quindi legge le proprietà integrate tramite [IPresentation.DocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/ipresentation/documentproperties/):

```csharp
using System;
using Aspose.Slides;

var loadOptions = new LoadOptions { OnlyLoadDocumentProperties = true };
using var presentation = new Presentation("public-properties-encrypted.pptx", loadOptions);

if (presentation.ProtectionManager.IsOnlyDocumentPropertiesLoaded)
{
    var documentProperties = presentation.DocumentProperties;

    Console.WriteLine("Author: " + documentProperties.Author);
    Console.WriteLine("Title: " + documentProperties.Title);
    Console.WriteLine("Keywords: " + documentProperties.Keywords);
}
else
{
    Console.WriteLine("The presentation was not loaded in document-properties-only mode.");
}
```

In questa modalità, il contenuto delle diapositive non viene caricato. Diapositive, master, layout, forme, media e altri oggetti della presentazione non sono disponibili. Le applicazioni dovrebbero sempre verificare [IProtectionManager.IsOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/net/aspose.slides/iprotectionmanager/isonlydocumentpropertiesloaded/) prima di eseguire un'operazione che richiede il modello completo dell'oggetto presentazione.

{{% alert color="warning" title="Security" %}}
I metadati pubblici possono esporre nomi di autori, titoli, argomenti, parole chiave, informazioni aziendali, commenti e valori personalizzati. Cripta le proprietà sensibili insieme alla presentazione. Lasciale pubbliche solo quando l'indicizzazione, la classificazione, la ricerca o i sistemi di gestione documentale hanno una necessità specifica di accedervi senza password.
{{% /alert %}}

## **Aggiornare le proprietà di una presentazione crittografata**

Per un file PPTX crittografato, una presentazione caricata con [LoadOptions.OnlyLoadDocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/onlyloaddocumentproperties/) è destinata alla lettura dei metadati pubblici. Aspose.Slides non può salvare proprietà modificate da quell'oggetto "solo metadati" perché le proprietà pubbliche devono rimanere coerenti con i dati corrispondenti all'interno della presentazione crittografata. L'aggiornamento richiede quindi la password di apertura corretta e un caricamento completo.

L'esempio richiede una presentazione PPTX crittografata con proprietà del documento pubbliche e una password di apertura nota. Apre la presentazione completa con [LoadOptions.Password](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/password/), aggiorna le proprietà integrate pubbliche e salva il risultato. Poi utilizza [IPresentationInfo.IsEncrypted](https://reference.aspose.com/slides/net/aspose.slides/ipresentationinfo/isencrypted/) per verificare che la crittografia sia preservata e riapre i metadati pubblici senza password per verificare i nuovi valori:

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

const string inputPath = "public-properties-encrypted.pptx";
const string outputPath = "updated-public-properties-encrypted.pptx";

var loadOptions = new LoadOptions { Password = "open_password" };
using var presentation = new Presentation(inputPath, loadOptions);

var documentProperties = presentation.DocumentProperties;
documentProperties.Title = "Updated Product Roadmap";
documentProperties.Keywords = "roadmap, planning, indexed";

presentation.Save(outputPath, SaveFormat.Pptx);

var presentationInfo = PresentationFactory.Instance.GetPresentationInfo(outputPath);
Console.WriteLine("The presentation is encrypted: " + presentationInfo.IsEncrypted);

var metadataLoadOptions = new LoadOptions { OnlyLoadDocumentProperties = true };
using var metadataPresentation = new Presentation(outputPath, metadataLoadOptions);

if (metadataPresentation.ProtectionManager.IsOnlyDocumentPropertiesLoaded)
{
    Console.WriteLine("Title: " + metadataPresentation.DocumentProperties.Title);
    Console.WriteLine("Keywords: " + metadataPresentation.DocumentProperties.Keywords);
}
else
{
    Console.WriteLine("The presentation was not loaded in document-properties-only mode.");
}
```

Se a un'applicazione non è consentito decrittare o caricare il contenuto della presentazione, deve trattare le proprietà pubbliche di un file PPTX crittografato come di sola lettura.

## **Accedere alle proprietà integrate**

L'interfaccia [IDocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/) espone i metadati integrati tramite proprietà tipizzate, tra cui [Author](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/author/), [Title](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/title/) e [CreatedTime](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/createdtime/). Questo esempio apre una presentazione esistente e stampa i metadati memorizzati sulla console. I valori dipendono dalla presentazione di input; alcuni campi possono essere vuoti.

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("AccessBuiltInProperties.pptx");

var documentProperties = presentation.DocumentProperties;

Console.WriteLine("Category: " + documentProperties.Category);
Console.WriteLine("Content status: " + documentProperties.ContentStatus);
Console.WriteLine("Creation date: " + documentProperties.CreatedTime);
Console.WriteLine("Author: " + documentProperties.Author);
Console.WriteLine("Comments: " + documentProperties.Comments);
Console.WriteLine("Keywords: " + documentProperties.Keywords);
Console.WriteLine("Last modified by: " + documentProperties.LastSavedBy);
Console.WriteLine("Manager: " + documentProperties.Manager);
Console.WriteLine("Modified date: " + documentProperties.LastSavedTime);
Console.WriteLine("Presentation format: " + documentProperties.PresentationFormat);
Console.WriteLine("Last print date: " + documentProperties.LastPrinted);
Console.WriteLine("Is shared between producers: " + documentProperties.SharedDoc);
Console.WriteLine("Subject: " + documentProperties.Subject);
Console.WriteLine("Title: " + documentProperties.Title);
```

### **Segnalare numero di revisione e tempo di modifica**

Per segnalare una riga per ogni file PPTX nella cartella `presentations`, chiama [ReadDocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/ipresentationinfo/readdocumentproperties/) per recuperare il suo [IDocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/) senza caricare le diapositive per la modifica. Il formato standard `c` per `TimeSpan` include il conteggio dei giorni quando la durata supera le 24 ore.

```csharp
using System;
using System.IO;
using Aspose.Slides;

Console.WriteLine("File | RevisionNumber | TotalEditingTime");
foreach (var path in Directory.EnumerateFiles("presentations", "*.pptx"))
{
    var info = PresentationFactory.Instance.GetPresentationInfo(path);
    var properties = info.ReadDocumentProperties();
    Console.WriteLine($"{Path.GetFileName(path)} | {properties.RevisionNumber} | {properties.TotalEditingTime:c}");
}
```

Output di esempio per una presentazione con 1 giorno, 2 ore e 5 minuti di tempo di modifica registrato:

```text
File | RevisionNumber | TotalEditingTime
long.pptx | 17 | 1.02:05:00
```

[RevisionNumber](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/revisionnumber/) è un metadato scrivibile. Il suo valore da solo non può stabilire quante volte la presentazione è stata salvata né ricostruire la cronologia delle versioni.

[TotalEditingTime](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/totaleditingtime/) è la durata di modifica registrata nel file. Un valore di `00:00:00` indica che la durata memorizzata è zero. Non dimostra che nessuno abbia modificato la presentazione.

## **Modificare le proprietà integrate**

Per aggiornare i metadati integrati, assegna valori alle proprietà scrivibili esposte da [IPresentation.DocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/ipresentation/documentproperties/). Questo esempio apre una presentazione esistente, imposta [Author](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/author/), [Title](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/title/), [Subject](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/subject/), [Comments](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/comments/) e [Manager](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/manager/), quindi salva la presentazione aggiornata con [Presentation.Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/). Il PPTX salvato contiene i nuovi metadati.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("ModifyBuiltInProperties.pptx");

var documentProperties = presentation.DocumentProperties;

documentProperties.Author = "Aspose.Slides for .NET";
documentProperties.Title = "Manage PowerPoint Presentation Properties";
documentProperties.Subject = "Modify Built-in Properties";
documentProperties.Comments = "Aspose description";
documentProperties.Manager = "Aspose manager";

presentation.Save("DocumentProperties_output.pptx", SaveFormat.Pptx);
```

## **Gestire la base dei collegamenti ipertestuali**

[IDocumentProperties.HyperlinkBase](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/hyperlinkbase/) memorizza la base a livello di documento per i collegamenti ipertestuali relativi. È utile quando si sposta una presentazione e i suoi file collegati in un'altra posizione. È separata dall'URL esterno di un singolo collegamento ([IHyperlink.ExternalUrl](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/externalurl/)): la modifica della base non riscrive gli indirizzi dei collegamenti né cambia le destinazioni assolute.

L'esempio richiede una presentazione che contenga sia un collegamento relativo, ad esempio `target.html`, sia un collegamento assoluto, ad esempio `https://example.org/absolute.html`. Legge la base esistente, assegna un nuovo indirizzo di base e salva e riapre la presentazione per verificare il valore. Poi cancella la base con `string.Empty` e verifica il valore vuoto in un file salvato separato. Sostituisci l'indirizzo di base di esempio con la posizione dei tuoi file collegati.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("hyperlinks.pptx");
Console.WriteLine("Original base: " + presentation.DocumentProperties.HyperlinkBase);

const string newBase = "https://example.com/new/";
presentation.DocumentProperties.HyperlinkBase = newBase;
presentation.Save("hyperlinks-updated.pptx", SaveFormat.Pptx);

using var updatedPresentation = new Presentation("hyperlinks-updated.pptx");
Console.WriteLine("Base preserved: " + (updatedPresentation.DocumentProperties.HyperlinkBase == newBase));

updatedPresentation.DocumentProperties.HyperlinkBase = string.Empty;
updatedPresentation.Save("hyperlinks-cleared.pptx", SaveFormat.Pptx);

using var clearedPresentation = new Presentation("hyperlinks-cleared.pptx");
Console.WriteLine("Base cleared: " + (clearedPresentation.DocumentProperties.HyperlinkBase == string.Empty));
```

I due messaggi di verifica dovrebbero stampare `True`. La cancellazione della base lascia intatti gli indirizzi dei singoli collegamenti ipertestuali.

Un collegamento relativo a `target.pptx` apriva `old/target.pptx` quando la base puntava alla cartella `old`. Dopo aver cambiato la base nella cartella `new`, salvato e riaperto la presentazione, lo stesso collegamento apriva `new/target.pptx`. Un collegamento assoluto continuava ad aprire lo stesso file. Testa i tuoi collegamenti relativi in PowerPoint prima e dopo aver spostato la presentazione o cambiato la sua base.

## **Aggiungere proprietà personalizzate alla presentazione**

Le proprietà personalizzate memorizzano metadati che non hanno un campo integrato corrispondente. L'[indice di IDocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/item/) consente di assegnare un valore per nome di proprietà. Questo esempio crea una presentazione, aggiunge due valori di testo e un valore intero di versione, e salva la presentazione con [Presentation.Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/). Assegnare un valore a un nome esistente sovrascrive il valore di quella proprietà.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();

var documentProperties = presentation.DocumentProperties;

documentProperties["Reviewed by"] = "John Smith";
documentProperties["Confidentiality level"] = "Internal";
documentProperties["Document version"] = 2;

presentation.Save("CustomDocumentProperties_output.pptx", SaveFormat.Pptx);
```

## **Accedere e modificare le proprietà personalizzate**

Questo esempio apre una presentazione contenente proprietà personalizzate e utilizza [CountOfCustomProperties](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/countofcustomproperties/) per iterarle. [GetCustomPropertyName](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/getcustompropertyname/) accetta un indice basato su zero e restituisce il nome usato dall'[indice di IDocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/item/). L'esempio stampa ogni nome e valore originale, sostituisce ogni valore con una stringa numerata indipendentemente dal tipo originale e salva le modifiche. Se non ci sono proprietà personalizzate, il ciclo non apporta modifiche.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("AccessAndModifyProperties.pptx");

var documentProperties = presentation.DocumentProperties;

for (var i = 0; i < documentProperties.CountOfCustomProperties; i++)
{
    var propertyName = documentProperties.GetCustomPropertyName(i);
    var propertyValue = documentProperties[propertyName];

    Console.WriteLine("Custom property name: " + propertyName);
    Console.WriteLine("Custom property value: " + propertyValue);

    documentProperties[propertyName] = "New Value " + (i + 1);
}

presentation.Save("CustomProperties_output.pptx", SaveFormat.Pptx);
```

## **Esempio live**

Prova l'app online [**Visualizza e modifica i metadati PowerPoint**](https://products.aspose.app/slides/metadata) per vedere come lavorare con le proprietà del documento usando le API di Aspose.Slides:

[![Visualizza e modifica i metadati PowerPoint](slides-metadata.png)](https://products.aspose.app/slides/metadata)

## **FAQ**

**Come posso rimuovere una proprietà integrata da una presentazione?**

Le proprietà integrate fanno parte integrante della presentazione e non possono essere rimosse completamente. Tuttavia, è possibile modificarne i valori o impostarle a vuoto se la proprietà lo consente.

**Cosa succede se aggiungo una proprietà personalizzata che esiste già?**

Se aggiungi una proprietà personalizzata che esiste già, il valore esistente verrà sovrascritto con il nuovo. Non è necessario rimuovere o verificare la proprietà in anticipo, poiché Aspose.Slides aggiorna automaticamente il valore della proprietà.

**Posso accedere alle proprietà della presentazione senza caricarla completamente?**

Sì. Usa [PresentationFactory.GetPresentationInfo](https://reference.aspose.com/slides/net/aspose.slides/presentationfactory/getpresentationinfo/) e poi [IPresentationInfo.ReadDocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/ipresentationinfo/readdocumentproperties/) per leggere i metadati del documento memorizzati senza creare un'istanza di [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/). Vedi [Creare un inventario di presentazioni leggero](/slides/it/net/examine-presentation/) per un esempio completo di reporting e le limitazioni specifiche del formato.

**Posso leggere le proprietà pubbliche di una presentazione crittografata senza la password di apertura?**

Sì. La presentazione deve essere stata crittografata con [IProtectionManager.EncryptDocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/iprotectionmanager/encryptdocumentproperties/) impostato su `false`, e deve essere caricata con [LoadOptions.OnlyLoadDocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/onlyloaddocumentproperties/) impostato su `true`.

**Posso aggiornare un file PPTX crittografato in modalità solo proprietà del documento?**

No. I dati delle proprietà pubbliche e criptate devono rimanere coerenti, quindi l'aggiornamento di un file PPTX crittografato richiede il caricamento completo della presentazione con la password di apertura corretta.