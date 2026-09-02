---
title: Gestisci le proprietà della presentazione in .NET
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
- Modifica metadati
- Lingua di correzione
- Lingua predefinita
- PowerPoint
- OpenDocument
- presentazione
- .NET
- C#
- Aspose.Slides
description: "Domina le proprietà di presentazione in Aspose.Slides per .NET e ottimizza ricerca, branding e flusso di lavoro nei tuoi file PowerPoint e OpenDocument."
---
## **Introduzione**

Aspose.Slides for .NET supporta due tipi di proprietà del documento: **Built-in** e **Custom**. Entrambi i tipi di proprietà possono essere facilmente accessibili e gestiti tramite l'API di Aspose.Slides for .NET.

Aspose.Slides consente di lavorare con le proprietà del documento di presentazione tramite l'interfaccia [IDocumentProperties](https://reference.aspose.com/slides/it/net/aspose.slides/idocumentproperties/) . Un'istanza di questa interfaccia viene restituita dalla proprietà [Presentation.DocumentProperties](https://reference.aspose.com/slides/it/net/aspose.slides/presentation/documentproperties/) . I seguenti esempi mostrano come leggere, modificare e gestire queste proprietà.

{{% alert color="info" title="Nota" %}}

Si prega di notare che i campi **Application** e **Producer** non possono essere modificati, poiché questi campi mostreranno sempre "Aspose Ltd." e "Aspose.Slides for .NET x.x.x".

{{% /alert %}} 

## **Gestisci le proprietà della presentazione**

Microsoft PowerPoint fornisce una funzionalità per aggiungere proprietà ai file di presentazione. Queste proprietà del documento consentono di memorizzare informazioni utili insieme ai file. Esistono due tipi di proprietà del documento:

- Proprietà di sistema (built-in)
- Proprietà definite dall'utente (custom)

Le proprietà **Built-in** contengono informazioni generali sul documento, come il titolo del documento, il nome dell'autore, le statistiche del documento e altro.

Le proprietà **Custom** sono definite dagli utenti come coppie **Name/Value**, dove sia il nome sia il valore sono specificati dall'utente.

Utilizzando Aspose.Slides for .NET, gli sviluppatori possono accedere e modificare sia le proprietà built-in sia quelle custom.

Microsoft PowerPoint consente agli utenti di gestire le proprietà del documento facendo clic sull'icona Office, quindi selezionando **File → Info → Properties**. Dopo aver scelto **Advanced Properties**, appare una finestra di dialogo in cui è possibile gestire tutte le proprietà del documento del file di presentazione.

Nella finestra di dialogo **Properties**, sono presenti diverse schede, come **General**, **Summary**, **Statistics**, **Contents** e **Custom**. Ogni scheda fornisce opzioni per configurare tipi specifici di informazioni relative al file PowerPoint. La scheda **Custom** è utilizzata per gestire le proprietà definite dall'utente.

## **Accedi alle proprietà Built-in**

Queste proprietà, così come esposte dall'interfaccia [IDocumentProperties](https://reference.aspose.com/slides/it/net/aspose.slides/idocumentproperties/) , includono: **Creator** (Autore), **Description**, **Keywords**, **Created** (Data di creazione), **Modified** (Data di modifica), **Printed** (Data dell'ultima stampa), **LastModifiedBy**, **SharedDoc** (indica se il documento è condiviso tra diversi produttori), **PresentationFormat**, **Subject**, **Title** e altro.

```cs
using Aspose.Slides;

// Istanzia la classe Presentation che rappresenta un file di presentazione.
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

## **Modifica le proprietà Built-in**

Modificare le proprietà built-in dei file di presentazione è semplice quanto accedervi. È sufficiente assegnare un valore stringa a qualsiasi proprietà desiderata e il valore della proprietà verrà aggiornato. Nell'esempio seguente, dimostriamo come modificare le proprietà built-in di un file di presentazione.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

// Istanzia la classe Presentation che rappresenta il file di presentazione.
using Presentation presentation = new Presentation("ModifyBuiltInProperties.pptx");

// Ottieni un riferimento all'oggetto di tipo IDocumentProperties associato alla presentazione.
IDocumentProperties documentProperties = presentation.DocumentProperties;

// Imposta le proprietà Built-in.
documentProperties.Author = "Aspose.Slides for .NET";
documentProperties.Title = "Manage PowerPoint Presentation Properties";
documentProperties.Subject = "Modify Built-in Properties";
documentProperties.Comments = "Aspose description";
documentProperties.Manager = "Aspose manager";

presentation.Save("DocumentProperties_output.pptx", SaveFormat.Pptx);
```

## **Aggiungi proprietà Custom alla presentazione**

Le proprietà Custom della presentazione consentono agli sviluppatori di memorizzare metadati aggiuntivi o informazioni specifiche all'interno di un file di presentazione. Aspose.Slides rende semplice creare e gestire programmaticamente queste proprietà custom. I seguenti esempi dimostrano come aggiungere proprietà custom alle proprie presentazioni.

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

// Salva la presentazione in un file.
presentation.Save("CustomDocumentProperties_output.pptx", SaveFormat.Pptx);
```

## **Accedi e modifica le proprietà Custom**

Aspose.Slides consente inoltre agli sviluppatori di accedere alle proprietà custom esistenti e di modificarne facilmente i valori. Questa funzionalità aiuta a mantenere metadati accurati e supporta aggiornamenti dinamici basati su input dell'utente o logica di business. Gli esempi seguenti illustrano come recuperare e aggiornare i valori delle proprietà custom all'interno di una presentazione.

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

// Salva la presentazione in un file.
presentation.Save("CustomProperties_output.pptx", SaveFormat.Pptx);
```

## **Esempio live**

Prova l'app online [**View & Edit PowerPoint Metadata**](https://products.aspose.app/slides/it/metadata) per vedere come lavorare con le proprietà del documento utilizzando l'API di Aspose.Slides:

[![Visualizza e modifica i metadati PowerPoint](slides-metadata.png)](https://products.aspose.app/slides/it/metadata)

## **FAQ**

**Come posso rimuovere una proprietà built-in da una presentazione?**

Le proprietà built-in sono una parte integrante della presentazione e non possono essere rimosse completamente. Tuttavia, è possibile modificarne i valori o impostarle a vuoto, se la proprietà specifica lo consente.

**Cosa succede se aggiungo una proprietà custom che esiste già?**

Se aggiungi una proprietà custom che esiste già, il suo valore esistente verrà sovrascritto con quello nuovo. Non è necessario rimuovere o verificare la proprietà in anticipo, poiché Aspose.Slides aggiorna automaticamente il valore della proprietà.

**Posso accedere alle proprietà della presentazione senza caricare completamente la presentazione?**

Sì. Utilizza [PresentationFactory.GetPresentationInfo](https://reference.aspose.com/slides/it/net/aspose.slides/presentationfactory/getpresentationinfo/) e quindi [IPresentationInfo.ReadDocumentProperties](https://reference.aspose.com/slides/it/net/aspose.slides/ipresentationinfo/readdocumentproperties/) per leggere i metadati del documento memorizzati senza creare un'istanza di [Presentation](https://reference.aspose.com/slides/it/net/aspose.slides/presentation/). Consulta [Build a Lightweight Presentation Inventory](/slides/it/net/examine-presentation/) per un esempio completo di report e le limitazioni specifiche del formato.