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
- Lingua di correzione
- Lingua predefinita
- PowerPoint
- OpenDocument
- presentazione
- .NET
- C#
- Aspose.Slides
description: "Gestisci le proprietà della presentazione in Aspose.Slides per .NET e ottimizza ricerca, branding e flusso di lavoro nei tuoi file PowerPoint e OpenDocument."
---
## **Introduzione**

Aspose.Slides for .NET supporta due tipi di proprietà dei documenti: **Built-in** e **Custom**. Entrambi questi tipi di proprietà possono essere facilmente accessi e gestiti usando l'API Aspose.Slides per .NET.

Aspose.Slides consente di lavorare con le proprietà dei documenti di presentazione tramite l'interfaccia [IDocumentProperties](https://reference.aspose.com/slides/it/net/aspose.slides/idocumentproperties/). Un'istanza di questa interfaccia viene restituita dalla proprietà [Presentation.DocumentProperties](https://reference.aspose.com/slides/it/net/aspose.slides/presentation/documentproperties/). Gli esempi seguenti mostrano come leggere, modificare e gestire queste proprietà.

{{% alert color="info" %}} 
Si prega di notare che i campi **Application** e **Producer** non possono essere modificati, poiché questi campi mostreranno sempre "Aspose Ltd." e "Aspose.Slides for .NET x.x.x".
{{% /alert %}} 

## **Gestire le proprietà della presentazione**

Microsoft PowerPoint offre una funzionalità per aggiungere proprietà ai file di presentazione. Queste proprietà del documento consentono di memorizzare informazioni utili insieme ai file. Esistono due tipi di proprietà del documento:

- Proprietà definite dal sistema (built-in)
- Proprietà definite dall'utente (custom)

Le proprietà **Built-in** contengono informazioni generali sul documento, come il titolo del documento, il nome dell'autore, le statistiche del documento e altro.

Le proprietà **Custom** sono definite dagli utenti come coppie **Name/Value**, dove sia il nome sia il valore sono specificati dall'utente.

Utilizzando Aspose.Slides per .NET, gli sviluppatori possono accedere e modificare sia le proprietà built-in sia quelle custom.

Microsoft PowerPoint consente agli utenti di gestire le proprietà del documento facendo clic sull'icona Office, quindi selezionando **File → Info → Properties**. Dopo aver scelto **Advanced Properties**, appare una finestra di dialogo dove è possibile gestire tutte le proprietà del documento del file di presentazione.

Nella finestra di dialogo **Properties**, ci sono diverse schede, come **General**, **Summary**, **Statistics**, **Contents** e **Custom**. Ogni scheda offre opzioni per configurare tipi specifici di informazioni relative al file PowerPoint. La scheda **Custom** è utilizzata per gestire le proprietà definite dall'utente.

## **Accedere alle proprietà Built-in**

Queste proprietà, come esposte dall'interfaccia [IDocumentProperties](https://reference.aspose.com/slides/it/net/aspose.slides/idocumentproperties/), includono: **Creator** (Autore), **Description**, **Keywords**, **Created** (Data di creazione), **Modified** (Data di modifica), **Printed** (Data dell'ultima stampa), **LastModifiedBy**, **SharedDoc** (indica se il documento è condiviso tra diversi produttori), **PresentationFormat**, **Subject**, **Title** e altro.

```cs
using Aspose.Slides;

// Instanzia la classe Presentation che rappresenta un file di presentazione.
using Presentation presentation = new Presentation("AccessBuiltInProperties.pptx");

// Get a reference to the object of type IDocumentProperties associated with the presentation.
IDocumentProperties documentProperties = presentation.DocumentProperties;

// Display the Built-in properties.
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

## **Modificare le proprietà Built-in**

Modificare le proprietà built-in dei file di presentazione è altrettanto semplice come accedervi. È sufficiente assegnare un valore stringa a qualsiasi proprietà desiderata e il valore della proprietà verrà aggiornato. Nell'esempio seguente, dimostriamo come modificare le proprietà di documento built-in di un file di presentazione.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

// Istanzia la classe Presentation che rappresenta un file di presentazione.
using Presentation presentation = new Presentation("ModifyBuiltInProperties.pptx");

// Ottieni un riferimento all'oggetto di tipo IDocumentProperties associato alla presentazione.
IDocumentProperties documentProperties = presentation.DocumentProperties;

// Imposta le proprietà Built-in.
documentProperties.Author = "Aspose.Slides for .NET";
documentProperties.Title = "Manage PowerPoint Presentation Properties";
documentProperties.Subject = "Modify Built-in Properties";
documentProperties.Comments = "Aspose description";
documentProperties.Manager = "Aspose manager";

// Salva la presentazione su un file.
presentation.Save("DocumentProperties_output.pptx", SaveFormat.Pptx);
```

## **Aggiungere proprietà Custom alla presentazione**

Le proprietà di presentazione **Custom** consentono agli sviluppatori di memorizzare metadati aggiuntivi o informazioni specifiche all'interno di un file di presentazione. Aspose.Slides rende semplice creare e gestire queste proprietà custom programmaticamente. Gli esempi seguenti dimostrano come aggiungere proprietà custom alle proprie presentazioni.

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

## **Accedere e modificare le proprietà Custom**

Aspose.Slides consente inoltre agli sviluppatori di accedere alle proprietà custom esistenti e di modificarne facilmente i valori. Questa funzionalità aiuta a mantenere metadati accurati e supporta aggiornamenti dinamici basati sull'input dell'utente o sulla logica di business. Gli esempi seguenti illustrano come recuperare e aggiornare i valori delle proprietà custom all'interno di una presentazione.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

// Instanzia la classe Presentation che rappresenta un file PPTX.
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

## ***FAQ**

### Come posso rimuovere una proprietà built-in da una presentazione?

Le proprietà built-in sono una parte integrante della presentazione e non possono essere rimosse completamente. Tuttavia, è possibile modificare i loro valori o impostarli a vuoto se la proprietà specifica lo consente.

### Cosa succede se aggiungo una proprietà custom che esiste già?

Se aggiungi una proprietà custom che esiste già, il suo valore esistente verrà sovrascritto con quello nuovo. Non è necessario rimuovere o verificare la proprietà in anticipo, poiché Aspose.Slides aggiorna automaticamente il valore della proprietà.

### Posso accedere alle proprietà della presentazione senza caricare completamente la presentazione?

Sì, è possibile accedere alle proprietà della presentazione senza caricare completamente la presentazione utilizzando il metodo `GetPresentationInfo` della classe [PresentationFactory](https://reference.aspose.com/slides/it/net/aspose.slides/presentationfactory/). Quindi, utilizzare il metodo `ReadDocumentProperties` fornito dall'interfaccia [IPresentationInfo](https://reference.aspose.com/slides/it/net/aspose.slides/ipresentationinfo/) per leggere le proprietà in modo efficiente, risparmiando memoria e migliorando le prestazioni.