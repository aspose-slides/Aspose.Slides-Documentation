---
title: Gestire le proprietà della presentazione in .NET
linktitle: Proprietà della presentazione
type: docs
weight: 70
url: /it/net/presentation-properties/
keywords:
- Proprietà PowerPoint
- proprietà della presentazione
- proprietà del documento
- proprietà integrate
- proprietà personalizzate
- proprietà avanzate
- gestire le proprietà
- modificare le proprietà
- metadati del documento
- modificare i metadati
- lingua di correzione
- lingua predefinita
- PowerPoint
- OpenDocument
- presentazione
- .NET
- C#
- Aspose.Slides
description: "Gestisci le proprietà della presentazione in Aspose.Slides per .NET e ottimizza la ricerca, il branding e il flusso di lavoro nei tuoi file PowerPoint e OpenDocument."
---
## **Introduzione**

Aspose.Slides for .NET supporta due tipi di proprietà del documento: **Built-in** e **Custom**. Entrambi questi tipi di proprietà possono essere facilmente accessibili e gestiti tramite l'API Aspose.Slides for .NET.

Aspose.Slides consente di lavorare con le proprietà dei documenti di presentazione tramite l'interfaccia [IDocumentProperties](https://reference.aspose.com/slides/it/net/aspose.slides/idocumentproperties/) . Un'istanza di questa interfaccia viene restituita da [IPresentation.DocumentProperties](https://reference.aspose.com/slides/it/net/aspose.slides/ipresentation/documentproperties/) . I seguenti esempi mostrano come leggere, modificare e gestire queste proprietà.

{{% alert color="info" title="Note" %}}
Si noti che i campi **Application** e **Producer** non possono essere modificati, poiché questi campi mostreranno sempre "Aspose Ltd." e "Aspose.Slides for .NET x.x.x".
{{% /alert %}} 

## **Gestire le proprietà della presentazione**

Microsoft PowerPoint fornisce una funzionalità per aggiungere proprietà ai file di presentazione. Queste proprietà del documento consentono di memorizzare informazioni utili insieme ai file. Esistono due tipi di proprietà del documento:

- Proprietà di sistema (built-in)
- Proprietà definite dall'utente (custom)

Le proprietà **Built-in** contengono informazioni generali sul documento, come il titolo del documento, il nome dell'autore, le statistiche del documento e altro.

Le proprietà **Custom** sono definite dagli utenti come coppie **Name/Value**, dove sia il nome che il valore sono specificati dall'utente.

Utilizzando Aspose.Slides for .NET, gli sviluppatori possono accedere e modificare sia le proprietà built-in che quelle custom.

Microsoft PowerPoint consente agli utenti di gestire le proprietà del documento facendo clic sull'icona Office, quindi selezionando **File → Info → Properties**. Dopo aver scelto **Advanced Properties**, appare una finestra di dialogo in cui è possibile gestire tutte le proprietà del documento del file di presentazione.

Nella finestra di dialogo **Properties**, sono presenti diverse schede, come **General**, **Summary**, **Statistics**, **Contents** e **Custom**. Ogni scheda fornisce opzioni per configurare specifici tipi di informazioni relative al file PowerPoint. La scheda **Custom** è utilizzata per gestire le proprietà definite dall'utente.

## **Leggere le proprietà pubbliche da una presentazione crittata**

Una password di apertura normalmente protegge sia il contenuto della presentazione sia le proprietà del documento. Quando una presentazione è crittata con [IProtectionManager.EncryptDocumentProperties](https://reference.aspose.com/slides/it/net/aspose.slides/iprotectionmanager/encryptdocumentproperties/) impostato a `false`, le sue proprietà del documento rimangono pubbliche. Un'applicazione può quindi impostare [LoadOptions.OnlyLoadDocumentProperties](https://reference.aspose.com/slides/it/net/aspose.slides/loadoptions/onlyloaddocumentproperties/) a `true` e leggere i metadati pubblici senza fornire la password di apertura.

`OnlyLoadDocumentProperties` controlla cosa carica Aspose.Slides; non decritta nulla. Se le proprietà erano incluse nella crittografia, il loro caricamento senza password fallisce. Se la presentazione non è crittata, l'opzione viene ignorata e viene caricata l'intera presentazione.

Il seguente esempio verifica la modalità di caricamento tramite [IProtectionManager.IsOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/it/net/aspose.slides/iprotectionmanager/isonlydocumentpropertiesloaded/) e quindi legge le proprietà built-in tramite [IPresentation.DocumentProperties](https://reference.aspose.com/slides/it/net/aspose.slides/ipresentation/documentproperties/):

```csharp
using System;
using Aspose.Slides;

var loadOptions = new LoadOptions { OnlyLoadDocumentProperties = true };
using var presentation = new Presentation("public-properties-encrypted.pptx", loadOptions);

if (presentation.ProtectionManager.IsOnlyDocumentPropertiesLoaded)
{
    var properties = presentation.DocumentProperties;

    Console.WriteLine("Author: " + properties.Author);
    Console.WriteLine("Title: " + properties.Title);
    Console.WriteLine("Keywords: " + properties.Keywords);
}
else
{
    Console.WriteLine("The presentation was not loaded in document-properties-only mode.");
}
```

In questa modalità, il contenuto delle diapositive non viene caricato. Diapositive, master, layout, forme, media e altri oggetti della presentazione non sono disponibili. Le applicazioni devono sempre verificare `IsOnlyDocumentPropertiesLoaded` prima di eseguire un'operazione che richiede il modello oggetto completo della presentazione.

{{% alert color="warning" title="Security" %}}
I metadati pubblici possono rivelare i nomi degli autori, i titoli, gli argomenti, le parole chiave, le informazioni aziendali, i commenti e i valori personalizzati. Crittare le proprietà sensibili insieme alla presentazione. Lasciarle pubbliche solo quando l'indicizzazione, la classificazione, la ricerca o i sistemi di gestione dei documenti hanno una specifica necessità di accedervi senza password.
{{% /alert %}}

## **Aggiornare le proprietà di una presentazione crittata**

Per un file PPTX crittato, una presentazione caricata con `OnlyLoadDocumentProperties` è destinata alla lettura dei metadati pubblici. Aspose.Slides non può salvare le proprietà modificate da quell'oggetto contenente solo i metadati perché le proprietà pubbliche devono rimanere coerenti con i dati corrispondenti all'interno della presentazione crittata. Aggiornarle richiede quindi la password di apertura corretta e un caricamento completo.

Il seguente esempio apre la presentazione con [LoadOptions.Password](https://reference.aspose.com/slides/it/net/aspose.slides/loadoptions/password/), aggiorna le proprietà built-in pubbliche e salva il risultato. Quindi utilizza [IPresentationInfo.IsEncrypted](https://reference.aspose.com/slides/it/net/aspose.slides/ipresentationinfo/isencrypted/) per verificare che la crittografia sia preservata e riapre i metadati pubblici senza password per verificare i nuovi valori:

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

const string inputPath = "public-properties-encrypted.pptx";
const string outputPath = "updated-public-properties-encrypted.pptx";

{
    var loadOptions = new LoadOptions { Password = "open_password" };
    using var presentation = new Presentation(inputPath, loadOptions);

    presentation.DocumentProperties.Title = "Updated Product Roadmap";
    presentation.DocumentProperties.Keywords = "roadmap, planning, indexed";
    presentation.Save(outputPath, SaveFormat.Pptx);
}

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

Se a un'applicazione non è consentito decrittare o caricare il contenuto della presentazione, deve trattare le proprietà pubbliche di un file PPTX crittato come di sola lettura.

## **Accedere alle proprietà built-in**

Queste proprietà, così come esposte dall'interfaccia [IDocumentProperties](https://reference.aspose.com/slides/it/net/aspose.slides/idocumentproperties/), includono: **Creator** (Autore), **Description**, **Keywords**, **Created** (Data di creazione), **Modified** (Data di modifica), **Printed** (Data dell'ultima stampa), **LastModifiedBy**, **SharedDoc** (indica se il documento è condiviso tra diversi produttori), **PresentationFormat**, **Subject**, **Title** e altro.

```cs
using Aspose.Slides;

// Istanzia la classe Presentation che rappresenta un file di presentazione.
using Presentation presentation = new Presentation("AccessBuiltInProperties.pptx");

// Ottieni un riferimento all'oggetto di tipo IDocumentProperties associato alla presentazione.
IDocumentProperties documentProperties = presentation.DocumentProperties;

// Visualizza le proprietà integrate.
Console.WriteLine("Category : " + documentProperties.Category);
Console.WriteLine("Content status : " + documentProperties.ContentStatus);
Console.WriteLine("Creation date : " + documentProperties.CreatedTime);
Console.WriteLine("Author : " + documentProperties.Author);
Console.WriteLine("Comments : " + documentProperties.Comments);
Console.WriteLine("Key words : " + documentProperties.Keywords);
Console.WriteLine("Last modified by : " + documentProperties.LastSavedBy);
Console.WriteLine("Manager : " + documentProperties.Manager);
Console.WriteLine("Modified date : " + documentProperties.LastSavedTime);
Console.WriteLine("Presentation format : " + documentProperties.PresentationFormat);
Console.WriteLine("Last print date : " + documentProperties.LastPrinted);
Console.WriteLine("Is shared between producers : " + documentProperties.SharedDoc);
Console.WriteLine("Subject : " + documentProperties.Subject);
Console.WriteLine("Title : " + documentProperties.Title);
```

## **Modificare le proprietà built-in**

Modificare le proprietà built-in dei file di presentazione è semplice quanto accedervi. È sufficiente assegnare un valore stringa a qualsiasi proprietà desiderata e il valore della proprietà verrà aggiornato. Nell'esempio seguente, dimostriamo come modificare le proprietà built-in del documento di un file di presentazione.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

// Istanzia la classe Presentation che rappresenta un file di presentazione.
using Presentation presentation = new Presentation("ModifyBuiltInProperties.pptx");

// Ottieni un riferimento all'oggetto di tipo IDocumentProperties associato alla presentazione.
IDocumentProperties documentProperties = presentation.DocumentProperties;

// Imposta le proprietà integrate.
documentProperties.Author = "Aspose.Slides for .NET";
documentProperties.Title = "Manage PowerPoint Presentation Properties";
documentProperties.Subject = "Modify Built-in Properties";
documentProperties.Comments = "Aspose description";
documentProperties.Manager = "Aspose manager";

// Salva la presentazione su un file.
presentation.Save("DocumentProperties_output.pptx", SaveFormat.Pptx);
```

## **Aggiungere proprietà personalizzate alla presentazione**

Le proprietà personalizzate della presentazione consentono agli sviluppatori di memorizzare metadati aggiuntivi o informazioni specifiche all'interno di un file di presentazione. Aspose.Slides semplifica la creazione e la gestione di queste proprietà personalizzate tramite programmazione. I seguenti esempi dimostrano come aggiungere proprietà personalizzate alle proprie presentazioni.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

// Istanzia la classe Presentation.
using Presentation presentation = new Presentation();

// Ottieni un riferimento all'oggetto di tipo IDocumentProperties associato alla presentazione.
IDocumentProperties documentProperties = presentation.DocumentProperties;

// Aggiungi proprietà personalizzate.
documentProperties["Reviewed by"] = "John Smith";
documentProperties["Confidentiality level"] = "Internal";
documentProperties["Document version"] = 2;

// Salva la presentazione su un file.
presentation.Save("CustomDocumentProperties_output.pptx", SaveFormat.Pptx);
```

## **Accedere e modificare le proprietà personalizzate**

Aspose.Slides consente anche agli sviluppatori di accedere alle proprietà personalizzate esistenti e di modificarne facilmente i valori. Questa funzionalità aiuta a mantenere metadati accurati e supporta aggiornamenti dinamici basati su input dell'utente o logica di business. Gli esempi seguenti illustrano come recuperare e aggiornare i valori delle proprietà personalizzate in una presentazione.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

// Istanzia la classe Presentation che rappresenta un file PPTX.
using Presentation presentation = new Presentation("AccessAndModifyProperties.pptx");

// Ottieni un riferimento all'oggetto di tipo IDocumentProperties associato alla presentazione.
IDocumentProperties documentProperties = presentation.DocumentProperties;

// Accedi e modifica le proprietà personalizzate.
for (int i = 0; i < documentProperties.CountOfCustomProperties; i++)
{
    string propertyName = documentProperties.GetCustomPropertyName(i);
    object propertyValue = documentProperties[propertyName];

    // Visualizza il nome e il valore della proprietà personalizzata.
    Console.WriteLine("Custom property name : " + propertyName);
    Console.WriteLine("Custom property value : " + propertyValue);

    // Modifica il valore della proprietà personalizzata.
    documentProperties[propertyName] = "New Value " + (i + 1);
}

// Salva la presentazione su un file.
presentation.Save("CustomProperties_output.pptx", SaveFormat.Pptx);
```

## **Esempio live**

Prova l'app online [**View & Edit PowerPoint Metadata**](https://products.aspose.app/slides/it/metadata) per vedere come lavorare con le proprietà del documento usando l'API Aspose.Slides:

[![View & Edit PowerPoint Metadata](slides-metadata.png)](https://products.aspose.app/slides/it/metadata)

## **FAQ**

**Come posso rimuovere una proprietà built-in da una presentazione?**

Le proprietà built-in sono una parte integrante della presentazione e non possono essere rimosse del tutto. Tuttavia, è possibile modificare i loro valori o impostarli a vuoto se la specifica proprietà lo consente.

**Cosa succede se aggiungo una proprietà personalizzata che esiste già?**

Se aggiungi una proprietà personalizzata che esiste già, il suo valore esistente verrà sovrascritto con quello nuovo. Non è necessario rimuovere o verificare la proprietà in anticipo, poiché Aspose.Slides aggiorna automaticamente il valore della proprietà.

**Posso accedere alle proprietà della presentazione senza caricare completamente la presentazione?**

Sì. Usa [PresentationFactory.GetPresentationInfo](https://reference.aspose.com/slides/it/net/aspose.slides/presentationfactory/getpresentationinfo/) e poi [IPresentationInfo.ReadDocumentProperties](https://reference.aspose.com/slides/it/net/aspose.slides/ipresentationinfo/readdocumentproperties/) per leggere i metadati memorizzati del documento senza creare un'istanza di [Presentation](https://reference.aspose.com/slides/it/net/aspose.slides/presentation/). Vedi [Build a Lightweight Presentation Inventory](/slides/it/net/examine-presentation/) per un esempio completo di reportistica e le limitazioni specifiche del formato.

**Posso leggere le proprietà pubbliche di una presentazione crittata senza la sua password di apertura?**

Sì. La presentazione deve essere stata crittata con `EncryptDocumentProperties` impostato a `false`, e deve essere caricata con `OnlyLoadDocumentProperties` impostato a `true`.

**Posso aggiornare un file PPTX crittato in modalità solo proprietà del documento?**

No. I dati delle proprietà pubbliche e crittate devono rimanere coerenti, quindi aggiornare un file PPTX crittato richiede il caricamento dell'intera presentazione con la password di apertura corretta.