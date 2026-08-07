---
title: Gestire tag e dati personalizzati nelle presentazioni in .NET
linktitle: Tag e dati personalizzati
type: docs
weight: 300
url: /it/net/managing-tags-and-custom-data/
keywords:
- proprietà del documento
- tag
- dati personalizzati
- XML personalizzato
- parte XML personalizzata
- metadati XML
- ItemId
- aggiungere tag
- coppie di valori
- PowerPoint
- presentazione
- .NET
- C#
- Aspose.Slides
description: "Scopri come gestire tag e dati XML personalizzati nelle presentazioni PowerPoint con Aspose.Slides per .NET, incluse aggiunta, lettura, aggiornamento, audit e rimozione di parti XML personalizzate."
---
## **Panoramica**

Questo articolo spiega come Aspose.Slides gestisce tag e dati personalizzati nelle presentazioni PowerPoint. I dati specifici della presentazione possono essere archiviati come tag o parti XML personalizzate. I tag sono semplici coppie chiave‑valore di stringa, mentre le parti XML personalizzate possono memorizzare metadati strutturati e payload XML specifici dell'applicazione.

Aspose.Slides fornisce API per aggiungere, leggere, aggiornare, eseguire audit e rimuovere parti XML personalizzate a livello di presentazione, diapositiva e forma. Le parti XML personalizzate sono utili per integrazioni che memorizzano informazioni come identificatori di gestione documenti, stato del flusso di lavoro, metadati di conformità, dati di associazione del modello o altri dati applicativi strutturati all'interno di una presentazione.

## **Archiviazione dei dati nei file di presentazione**

I file PPTX — file con estensione `.pptx` — sono archiviati nel formato PresentationML, che fa parte della specifica Office Open XML. Office Open XML definisce la struttura del pacchetto e le relazioni utilizzate per memorizzare il contenuto della presentazione e i dati correlati.

Una presentazione contiene più parti collegate da relazioni. Ad esempio, una parte di diapositiva contiene il contenuto di una singola diapositiva e può avere relazioni esplicite verso altre parti definite da ISO/IEC 29500.

I dati personalizzati possono essere memorizzati come tag ([ITagCollection](https://reference.aspose.com/slides/it/net/aspose.slides/itagcollection)) o parti XML personalizzate ([ICustomXmlPartCollection](https://reference.aspose.com/slides/it/net/aspose.slides/icustomxmlpartcollection)). Entrambi sono disponibili tramite l'interfaccia [`ICustomData`](https://reference.aspose.com/slides/it/net/aspose.slides/icustomdata/) .

{{% alert color="primary" %}}
I tag memorizzano semplici coppie chiave‑valore di stringa. Le parti XML personalizzate memorizzano dati XML strutturati e possono essere associate a una presentazione, diapositiva o forma.
{{% /alert %}}

## **Lavorare con le parti XML personalizzate**

La proprietà [`ICustomData.CustomXmlParts`](https://reference.aspose.com/slides/it/net/aspose.slides/icustomdata/customxmlparts/) restituisce la raccolta delle parti XML personalizzate associate a un determinato oggetto della presentazione. Ad esempio:

- `presentation.CustomData.CustomXmlParts` contiene le parti XML personalizzate associate alla presentazione stessa.
- `slide.CustomData.CustomXmlParts` contiene le parti XML personalizzate associate a una diapositiva specifica.
- `shape.CustomData.CustomXmlParts` contiene le parti XML personalizzate associate a una forma specifica.

Usa [`Presentation.AllCustomXmlParts`](https://reference.aspose.com/slides/it/net/aspose.slides/presentation/allcustomxmlparts/) quando è necessario esaminare tutte le parti XML personalizzate nella presentazione, indipendentemente da dove siano associate.

### **Aggiungere una parte XML personalizzata a una presentazione**

Usa [`ICustomXmlPartCollection.Add`](https://reference.aspose.com/slides/it/net/aspose.slides/icustomxmlpartcollection/add/) per aggiungere dati XML a una raccolta di parti XML personalizzate. L'XML deve essere valido e non vuoto.

Il seguente esempio aggiunge metadati strutturati alla raccolta di dati personalizzati a livello di presentazione:

```csharp
using System;
using Aspose.Slides;

var customXmlContent =
    "<?xml version=\"1.0\" encoding=\"UTF-8\"?>" +
    "<metadata xmlns=\"urn:example:metadata\">" +
        "<documentId>DOC-1001</documentId>" +
        "<workflowState>Draft</workflowState>" +
    "</metadata>";

using var presentation = new Presentation();
var customXmlPart = presentation.CustomData.CustomXmlParts.Add(customXmlContent);

// Add assegna un identificatore automaticamente. Imposta un GUID specifico solo quando necessario.
customXmlPart.ItemId = Guid.NewGuid();

presentation.Save("presentation_with_custom_xml.pptx", SaveFormat.Pptx);
```

Il metodo `Add` può anche accettare XML come array di byte o stream, utile quando il contenuto XML è già disponibile in forma binaria.

### **Aggiungere una parte XML personalizzata a una diapositiva o a una forma**

I dati XML personalizzati possono essere associati a una diapositiva o forma specifica invece che all'intera presentazione. Ciò è utile quando i metadati descrivono un solo oggetto, ad esempio una chiave del modello, un identificatore di record esterno o informazioni di binding.

Il seguente esempio aggiunge una parte XML personalizzata a una diapositiva e un'altra a una forma:

```csharp
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

slide.CustomData.CustomXmlParts.Add(
    "<slideMetadata xmlns=\"urn:example:slides\">" +
        "<templateKey>TitleSlide</templateKey>" +
    "</slideMetadata>");

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 250, 80);

shape.TextFrame.Text = "Customer data";
shape.CustomData.CustomXmlParts.Add(
    "<shapeMetadata xmlns=\"urn:example:shapes\">" +
        "<recordId>CRM-4281</recordId>" +
    "</shapeMetadata>");

presentation.Save("object_custom_xml.pptx", SaveFormat.Pptx);
```

Il livello al quale viene aggiunta una parte determina quale collezione `CustomData.CustomXmlParts` dell'oggetto contiene la relazione a quella parte. I dati a livello di presentazione sono appropriati per metadati a livello di documento, i dati a livello di diapositiva per informazioni relative a una diapositiva specifica e i dati a livello di forma per metadati collegati a una singola forma.

### **Elencare e verificare tutte le parti XML personalizzate**

Usa [`Presentation.AllCustomXmlParts`](https://reference.aspose.com/slides/it/net/aspose.slides/presentation/allcustomxmlparts/) per recuperare tutte le parti XML personalizzate da una presentazione. Ogni [`ICustomXmlPart`](https://reference.aspose.com/slides/it/net/aspose.slides/icustomxmlpart/) espone il suo identificatore, il contenuto XML e gli schemi di namespace associati.

Il seguente esempio elenca tutte le parti XML personalizzate e i loro schemi di namespace:

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");

foreach (var customXmlPart in presentation.AllCustomXmlParts)
{
    Console.WriteLine("ItemId: " + customXmlPart.ItemId);
    Console.WriteLine("XML:");
    Console.WriteLine(customXmlPart.XmlAsString);

    foreach (var namespaceSchema in customXmlPart.NamespaceSchemas)
    {
        Console.WriteLine("Namespace schema: " + namespaceSchema);
    }

    Console.WriteLine();
}
```

`ICustomXmlPart.NamespaceSchemas` restituisce gli schemi XML associati alla parte XML personalizzata. Questa informazione può essere utile quando si effettuano audit di presentazioni che contengono XML prodotto da sistemi esterni.

### **Leggere e aggiornare il contenuto XML e ItemId**

Usa [`ICustomXmlPart.XmlAsString`](https://reference.aspose.com/slides/it/net/aspose.slides/icustomxmlpart/xmlasstring/) per lavorare con XML come stringa UTF‑8, o [`ICustomXmlPart.XmlData`](https://reference.aspose.com/slides/it/net/aspose.slides/icustomxmlpart/xmldata/) per lavorare con i byte XML grezzi. Entrambe le proprietà possono essere lette e aggiornate.

La proprietà [`ICustomXmlPart.ItemId`](https://reference.aspose.com/slides/it/net/aspose.slides/icustomxmlpart/itemid/) contiene il GUID che identifica la parte XML personalizzata nel documento Office Open XML. Può anche essere modificata quando un'integrazione richiede un nuovo identificatore.

Il seguente esempio aggiorna il contenuto XML e l'identificatore:

```csharp
using System;
using System.Text;
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");
var customXmlPart = presentation.AllCustomXmlParts[0];

// Leggi l'XML corrente come testo.
var currentXmlContent = customXmlPart.XmlAsString;
Console.WriteLine(currentXmlContent);

// Aggiorna l'XML come stringa UTF-8.
customXmlPart.XmlAsString =
    "<metadata xmlns=\"urn:example:metadata\">" +
        "<documentId>DOC-1001</documentId>" +
        "<workflowState>Approved</workflowState>" +
    "</metadata>";

// XmlData fornisce lo stesso contenuto XML come byte grezzi.
var customXmlData = customXmlPart.XmlData;
Console.WriteLine(Encoding.UTF8.GetString(customXmlData));

// Sostituisci l'identificatore quando richiesto dall'integrazione.
customXmlPart.ItemId = Guid.NewGuid();

presentation.Save("updated_custom_xml.pptx", SaveFormat.Pptx);
```

Quando si assegna `XmlAsString` o `XmlData`, fornire XML valido e non vuoto. Usa una rappresentazione o l'altra a seconda che l'applicazione lavori principalmente con stringhe o dati binari.

### **Rimuovere una parte XML personalizzata**

Aspose.Slides fornisce diversi modi per rimuovere dati XML personalizzati:

- [`ICustomXmlPart.Remove`](https://reference.aspose.com/slides/it/net/aspose.slides/icustomxmlpart/remove/) rimuove la parte XML personalizzata dalla presentazione.
- [`ICustomXmlPartCollection.Remove`](https://reference.aspose.com/slides/it/net/aspose.slides/icustomxmlpartcollection/remove/) rimuove una parte specifica da una raccolta di parti XML personalizzate.
- [`ICustomXmlPartCollection.RemoveAt`](https://reference.aspose.com/slides/it/net/aspose.slides/icustomxmlpartcollection/removeat/) rimuove la parte all'indice specificato nella raccolta.
- [`ICustomXmlPartCollection.Clear`](https://reference.aspose.com/slides/it/net/aspose.slides/icustomxmlpartcollection/clear/) rimuove tutte le parti da una raccolta specifica.

Il seguente esempio rimuove una parte XML personalizzata a livello di presentazione per riferimento:

```csharp
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");
var customXmlParts = presentation.CustomData.CustomXmlParts;

if (customXmlParts.Count > 0)
{
    var customXmlPart = customXmlParts[0];
    customXmlParts.Remove(customXmlPart);
}

presentation.Save("custom_xml_removed.pptx", SaveFormat.Pptx);
```

Se hai già un `ICustomXmlPart` e desideri rimuovere quella parte dalla presentazione anziché indirizzare una raccolta specifica, chiama `customXmlPart.Remove()`.

Puoi anche rimuovere un elemento per indice:

```csharp
presentation.CustomData.CustomXmlParts.RemoveAt(0);
```

### **Rimuovere tutte le parti XML personalizzate da una collezione**

Usa `Clear` quando tutte le parti XML personalizzate associate a un determinato oggetto della presentazione devono essere rimosse.

```csharp
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");
presentation.Slides[0].CustomData.CustomXmlParts.Clear();

presentation.Save("slide_custom_xml_cleared.pptx", SaveFormat.Pptx);
```

`Clear` influisce solo sulla collezione selezionata. Ad esempio, svuotare la collezione di una diapositiva non svuota le collezioni a livello di presentazione o di forma.

Per rimuovere ogni parte XML personalizzata nella presentazione, itera su `AllCustomXmlParts` e rimuovi ciascuna parte:

```csharp
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");

foreach (var customXmlPart in presentation.AllCustomXmlParts)
{
    customXmlPart.Remove();
}

presentation.Save("all_custom_xml_removed.pptx", SaveFormat.Pptx);
```

### **Gestire le parti XML personalizzate collegate o condivise**

In una presentazione Office Open XML, la stessa parte XML personalizzata può essere referenziata da più di un oggetto della presentazione. Ad esempio, un file esistente può contenere relazioni da più diapositive o forme allo stesso XML personalizzato sottostante.

Una parte condivisa dovrebbe essere trattata come un unico oggetto dati con più riferimenti:

- Aggiornare il suo `XmlAsString`, `XmlData` o `ItemId` modifica la parte XML personalizzata sottostante, quindi la modifica si applica ovunque la parte sia referenziata.
- `ItemId` può essere usato per identificare la stessa parte XML personalizzata durante l'audit delle collezioni a livello di oggetto.
- Rimuovere una parte da una specifica collezione `CustomXmlParts` la rimuove da quella collezione. Usa `ICustomXmlPart.Remove()` quando la parte stessa deve essere rimossa dalla presentazione.
- Prima di eliminare o sostituire una parte condivisa, controlla le collezioni a livello di oggetto per determinare se altre diapositive o forme la referenziano ancora.

Le sovraccarichi `Add` creano una nuova parte XML personalizzata dal contenuto XML; non accettano un `ICustomXmlPart` esistente. Pertanto, le relazioni condivise si incontrano più comunemente quando si caricano presentazioni che le contengono già.

Il seguente esempio esegue un audit delle collezioni a livello di presentazione, diapositiva e forma per `ItemId` e segnala le parti referenziate da più di un luogo:

```csharp
using System;
using System.Collections.Generic;
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");
var referencesByItemId = new Dictionary<Guid, List<string>>();

var registerCustomXmlParts = (string ownerName, ICustomXmlPartCollection customXmlParts) =>
    {
        foreach (var customXmlPart in customXmlParts)
        {
            if (!referencesByItemId.ContainsKey(customXmlPart.ItemId))
            {
                referencesByItemId[customXmlPart.ItemId] = new List<string>();
            }

            referencesByItemId[customXmlPart.ItemId].Add(ownerName);
        }
    };

registerCustomXmlParts("Presentation", presentation.CustomData.CustomXmlParts);

for (var slideIndex = 0; slideIndex < presentation.Slides.Count; slideIndex++)
{
    var slide = presentation.Slides[slideIndex];
    registerCustomXmlParts("Slide " + (slideIndex + 1), slide.CustomData.CustomXmlParts);

    for (var shapeIndex = 0; shapeIndex < slide.Shapes.Count; shapeIndex++)
    {
        var shape = slide.Shapes[shapeIndex];
        registerCustomXmlParts("Slide " + (slideIndex + 1) + ", shape " + shapeIndex, shape.CustomData.CustomXmlParts);
    }
}

foreach (var referenceEntry in referencesByItemId)
{
    if (referenceEntry.Value.Count > 1)
    {
        Console.WriteLine("Shared custom XML part: " + referenceEntry.Key);

        foreach (var ownerName in referenceEntry.Value)
        {
            Console.WriteLine("  Referenced by: " + ownerName);
        }
    }
}
```

Questo tipo di audit è utile prima di modificare o eliminare dati XML personalizzati in presentazioni create da sistemi esterni, poiché la stessa parte di metadati può partecipare a più di una relazione.

## **Ottenere i valori dei tag**

In Slides, un tag corrisponde alla proprietà `IDocumentProperties.Keywords`. Questo esempio di codice mostra come ottenere il valore di un tag con Aspose.Slides per .NET per [Presentation](https://reference.aspose.com/slides/it/net/aspose.slides/presentation):

```csharp
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");
var keywords = presentation.DocumentProperties.Keywords;
```

## **Aggiungere tag alle presentazioni**

Aspose.Slides consente di aggiungere tag alle presentazioni. Un tag tipicamente consiste di due elementi:

- il nome di una proprietà personalizzata, ad esempio `MyTag`;
- il valore della proprietà personalizzata, ad esempio `My Tag Value`.

Se devi classificare le presentazioni in base a una regola o proprietà specifica, puoi aggiungere tag a tale scopo. Ad esempio, se vuoi categorizzare le presentazioni dei paesi del Nord America, puoi creare un tag North American e assegnare il relativo paese come valore.

Questo esempio di codice mostra come aggiungere un tag a una [Presentation](https://reference.aspose.com/slides/it/net/aspose.slides/presentation) usando Aspose.Slides per .NET:

```csharp
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");
var tags = presentation.CustomData.Tags;
tags["MyTag"] = "My Tag Value";
```

I tag possono essere impostati anche per una [Slide](https://reference.aspose.com/slides/it/net/aspose.slides/slide):

```csharp
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
slide.CustomData.Tags["tag"] = "value";
```

Oppure per una singola [Shape](https://reference.aspose.com/slides/it/net/aspose.slides/shape):

```csharp
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 100, 50);
shape.TextFrame.Text = "My text";
shape.CustomData.Tags["tag"] = "value";
```

### **Limitazioni**

I tag aggiunti tramite la collezione `CustomData.Tags` sono memorizzati solo nel file PowerPoint. Non sono **trasferiti** alla struttura dei tag PDF quando la presentazione viene esportata in PDF. Di conseguenza, un identificatore personalizzato assegnato come tag non può essere recuperato dal PDF con tag.

**Soluzione alternativa**: è possibile memorizzare un identificatore personalizzato nel **Alt Text** dell'oggetto (ad esempio, `shape.AlternativeText = "MyId"`). Dopo l'esportazione in PDF, l'Alt Text può apparire nella struttura dei tag PDF.

## **FAQ**

**Posso rimuovere tutti i tag da una presentazione, diapositiva o forma in un'unica operazione?**  
Sì. La [collezione dei tag](https://reference.aspose.com/slides/it/net/aspose.slides/tagcollection/) supporta l'operazione [Clear](https://reference.aspose.com/slides/it/net/aspose.slides/tagcollection/clear/) che elimina tutte le coppie chiave‑valore contemporaneamente.

**Come posso eliminare un singolo tag per nome senza iterare l'intera collezione?**  
Usa [Remove(name)](https://reference.aspose.com/slides/it/net/aspose.slides/tagcollection/remove/) su [TagCollection](https://reference.aspose.com/slides/it/net/aspose.slides/tagcollection/) per eliminare il tag per la sua chiave.

**Come posso recuperare l'elenco completo dei nomi dei tag per analisi o filtraggio?**  
Usa [GetNamesOfTags](https://reference.aspose.com/slides/it/net/aspose.slides/tagcollection/getnamesoftags/) sulla [collezione dei tag](https://reference.aspose.com/slides/it/net/aspose.slides/tagcollection/); restituisce un array con tutti i nomi dei tag.

**Come posso trovare tutte le parti XML personalizzate indipendentemente da dove siano archiviate?**  
Usa [`Presentation.AllCustomXmlParts`](https://reference.aspose.com/slides/it/net/aspose.slides/presentation/allcustomxmlparts/) per recuperare tutte le parti XML personalizzate nella presentazione.

**Devo usare `XmlAsString` o `XmlData` per aggiornare una parte XML personalizzata?**  
Usa `XmlAsString` quando l'applicazione lavora con testo XML UTF‑8. Usa `XmlData` quando l'XML è già disponibile come array di byte o quando è più comodo un'elaborazione orientata ai dati binari. Entrambe le proprietà rappresentano il contenuto XML della stessa parte XML personalizzata.