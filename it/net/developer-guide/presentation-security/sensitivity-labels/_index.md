---
title: Gestire le etichette di sensibilità nelle presentazioni PowerPoint in .NET
linktitle: Etichette di Sensibilità
type: docs
weight: 50
url: /it/net/sensitivity-labels/
keywords:
- etichetta di sensibilità
- Microsoft Purview
- Microsoft Information Protection
- metadati MIP
- marcatura del contenuto
- protezione delle informazioni
- gestione dei documenti
- PowerPoint
- PPTX
- sicurezza della presentazione
- .NET
- C#
- Aspose.Slides
description: "Leggi, aggiungi, aggiorna, rimuovi e migra le etichette di sensibilità Microsoft Purview nelle presentazioni PowerPoint PPTX con Aspose.Slides per .NET."
---
## **Panoramica**

Microsoft Purview sensitivity labels aiutano le organizzazioni a classificare e gestire i documenti. Durante l'elaborazione automatica di una presentazione, un'applicazione potrebbe dover conservare un'etichetta esistente, applicare un'etichetta selezionata da una policy, aggiornarne lo stato o migrare i metadati dell'etichetta scritti da un flusso di lavoro Microsoft Information Protection (MIP) più vecchio.

Aspose.Slides espone i metadati delle etichette di sensibilità moderne tramite [Presentation.SensitivityLabels](https://reference.aspose.com/slides/it/net/aspose.slides/presentation/sensitivitylabels/). Questa proprietà restituisce un [ISensitivityLabelCollection](https://reference.aspose.com/slides/it/net/aspose.slides/isensitivitylabelcollection/) che può essere ispezionato e modificato prima che la presentazione venga salvata come PPTX.

{{% alert color="primary" title="Note" %}}

Gli identificatori delle etichette di sensibilità e le informazioni sulla policy sono definiti dalla configurazione di Microsoft Purview. Convalida la disponibilità delle etichette e i requisiti della policy nel tuo ambiente prima di aggiungere o migrare i metadati. I valori di [ISensitivityLabel.ContentMarkTypes](https://reference.aspose.com/slides/it/net/aspose.slides/isensitivitylabel/contentmarktypes/) descrivono le marcature di contenuto associate a un'etichetta; non aggiungono di per sé testo o forme visibili alle diapositive.

{{% /alert %}}

## **Comprendere le proprietà delle etichette di sensibilità**

Ogni [ISensitivityLabel](https://reference.aspose.com/slides/it/net/aspose.slides/isensitivitylabel/) contiene i seguenti metadati:

| Proprietà | Scopo |
| --- | --- |
| [ISensitivityLabel.Id](https://reference.aspose.com/slides/it/net/aspose.slides/isensitivitylabel/id/) | Identifica l'etichetta di sensibilità nella policy Purview. |
| [ISensitivityLabel.SiteId](https://reference.aspose.com/slides/it/net/aspose.slides/isensitivitylabel/siteid/) | Identifica il sito associato alla policy dell'etichetta. |
| [ISensitivityLabel.IsEnabled](https://reference.aspose.com/slides/it/net/aspose.slides/isensitivitylabel/isenabled/) | Indica se l'etichetta è abilitata. |
| [ISensitivityLabel.IsRemoved](https://reference.aspose.com/slides/it/net/aspose.slides/isensitivitylabel/isremoved/) | Indica che l'etichetta è stata rimossa. Imposta questa proprietà su `true` quando lo stato di rimozione deve essere conservato nei metadati. |
| [ISensitivityLabel.AssignmentMethodType](https://reference.aspose.com/slides/it/net/aspose.slides/isensitivitylabel/assignmentmethodtype/) | Specifica se l'etichetta è stata applicata automaticamente o mediante una decisione dell'utente. |
| [ISensitivityLabel.ContentMarkTypes](https://reference.aspose.com/slides/it/net/aspose.slides/isensitivitylabel/contentmarktypes/) | Elenca i tipi di marcatura di contenuto associati all'etichetta. |

L'enumerazione [SensitivityLabelAssignmentType](https://reference.aspose.com/slides/it/net/aspose.slides/sensitivitylabelassignmenttype/) descrive come è stata assegnata un'etichetta:

- [SensitivityLabelAssignmentType.Standard](https://reference.aspose.com/slides/it/net/aspose.slides/sensitivitylabelassignmenttype/) rappresenta un'etichetta predefinita o applicata automaticamente.
- [SensitivityLabelAssignmentType.Privileged](https://reference.aspose.com/slides/it/net/aspose.slides/sensitivitylabelassignmenttype/) rappresenta un'etichetta applicata tramite decisione dell'utente, comprese etichette applicate manualmente, consigliate e obbligatorie.

L'enumerazione [SensitivityLabelContentType](https://reference.aspose.com/slides/it/net/aspose.slides/sensitivitylabelcontenttype/) identifica la marcatura associata a un'etichetta:

| Valore | Significato |
| --- | --- |
| [SensitivityLabelContentType.None](https://reference.aspose.com/slides/it/net/aspose.slides/sensitivitylabelcontenttype/) | L'etichetta è stata applicata per impostazione predefinita o automaticamente. |
| [SensitivityLabelContentType.Header](https://reference.aspose.com/slides/it/net/aspose.slides/sensitivitylabelcontenttype/) | Una marcatura di contenuto dell'intestazione è associata all'etichetta. |
| [SensitivityLabelContentType.Footer](https://reference.aspose.com/slides/it/net/aspose.slides/sensitivitylabelcontenttype/) | Una marcatura di contenuto del piè di pagina è associata all'etichetta. |
| [SensitivityLabelContentType.Watermark](https://reference.aspose.com/slides/it/net/aspose.slides/sensitivitylabelcontenttype/) | Una marcatura di contenuto di filigrana è associata all'etichetta. |
| [SensitivityLabelContentType.Encryption](https://reference.aspose.com/slides/it/net/aspose.slides/sensitivitylabelcontenttype/) | Una protezione di crittografia è associata all'etichetta. |

Possono essere associate più tipologie di marcatura a una singola etichetta.

## **Elencare le etichette di sensibilità esistenti**

Leggi la raccolta di etichette moderne da [Presentation.SensitivityLabels](https://reference.aspose.com/slides/it/net/aspose.slides/presentation/sensitivitylabels/) e enumerala. L'esempio seguente elenca ogni proprietà e marcatura di contenuto memorizzata per ciascuna etichetta:

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");
var sensitivityLabels = presentation.SensitivityLabels;

foreach (var sensitivityLabel in sensitivityLabels)
{
    Console.WriteLine("Label ID: " + sensitivityLabel.Id);
    Console.WriteLine("Site ID: " + sensitivityLabel.SiteId);
    Console.WriteLine("Enabled: " + sensitivityLabel.IsEnabled);
    Console.WriteLine("Removed: " + sensitivityLabel.IsRemoved);
    Console.WriteLine("Assignment method: " + sensitivityLabel.AssignmentMethodType);

    foreach (var contentMarkType in sensitivityLabel.ContentMarkTypes)
    {
        Console.WriteLine("Content marking: " + contentMarkType);
    }
}
```

## **Aggiungere un'etichetta di sensibilità con marcatura di contenuto**

Utilizza [ISensitivityLabelCollection.Add](https://reference.aspose.com/slides/it/net/aspose.slides/isensitivitylabelcollection/add/) fornendo l'identificatore dell'etichetta, l'identificatore del sito, lo stato abilitato e il metodo di assegnazione. Dopo che il metodo restituisce la nuova [ISensitivityLabel](https://reference.aspose.com/slides/it/net/aspose.slides/isensitivitylabel/), aggiungi i valori di marcatura richiesti tramite [ISensitivityLabel.ContentMarkTypes](https://reference.aspose.com/slides/it/net/aspose.slides/isensitivitylabel/contentmarktypes/).

L'esempio seguente aggiunge un'etichetta selezionata manualmente associata a marcature di piè di pagina e filigrana, quindi salva il risultato come PPTX:

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");
var sensitivityLabels = presentation.SensitivityLabels;

var labelIdentifier = "{11111111-2222-3333-4444-555555555555}";
var siteIdentifier = Guid.Parse("{aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee}");
var isEnabled = true;
var assignmentMethod = SensitivityLabelAssignmentType.Privileged;

var sensitivityLabel = sensitivityLabels.Add(
    labelIdentifier,
    siteIdentifier,
    isEnabled,
    assignmentMethod);

sensitivityLabel.ContentMarkTypes.Add(SensitivityLabelContentType.Footer);
sensitivityLabel.ContentMarkTypes.Add(SensitivityLabelContentType.Watermark);

presentation.Save("presentation_with_label.pptx", SaveFormat.Pptx);
```

## **Aggiornare un'etichetta di sensibilità**

Le proprietà di [ISensitivityLabel](https://reference.aspose.com/slides/it/net/aspose.slides/isensitivitylabel/) sono in lettura/scrittura, tranne che la raccolta restituita da [ISensitivityLabel.ContentMarkTypes](https://reference.aspose.com/slides/it/net/aspose.slides/isensitivitylabel/contentmarktypes/) viene modificata tramite le sue operazioni di elenco. Dopo aver individuato l'etichetta necessaria, è possibile aggiornare il suo identificatore, l'identificatore del sito, lo stato abilitato, il metodo di assegnazione, lo stato di rimozione e i tipi di marcatura di contenuto. Salva la presentazione per rendere persistenti le modifiche.

L'esempio seguente aggiorna lo stato abilitato e il metodo di assegnazione della prima etichetta:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");
var sensitivityLabels = presentation.SensitivityLabels;

if (sensitivityLabels.Count > 0)
{
    var sensitivityLabel = sensitivityLabels[0];
    sensitivityLabel.IsEnabled = true;
    sensitivityLabel.AssignmentMethodType = SensitivityLabelAssignmentType.Privileged;
}

presentation.Save("presentation_with_updated_label.pptx", SaveFormat.Pptx);
```

## **Contrassegnare un'etichetta di sensibilità come rimossa**

Per conservare il fatto che un'etichetta è stata rimossa, trova l'etichetta e imposta [ISensitivityLabel.IsRemoved](https://reference.aspose.com/slides/it/net/aspose.slides/isensitivitylabel/isremoved/) su `true`. Questo mantiene la voce dell'etichetta registrando il suo stato rimosso. Se invece devi eliminare una voce dalla raccolta moderna, utilizza [ISensitivityLabelCollection.RemoveAt](https://reference.aspose.com/slides/it/net/aspose.slides/isensitivitylabelcollection/removeat/); usa [ISensitivityLabelCollection.Clear](https://reference.aspose.com/slides/it/net/aspose.slides/isensitivitylabelcollection/clear/) per cancellare tutte le voci.

L'esempio seguente contrassegna un'etichetta specifica come rimossa e salva la presentazione aggiornata:

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");
var sensitivityLabels = presentation.SensitivityLabels;
var targetLabelIdentifier = "{11111111-2222-3333-4444-555555555555}";

foreach (var sensitivityLabel in sensitivityLabels)
{
    var isTargetLabel = string.Equals(
        sensitivityLabel.Id,
        targetLabelIdentifier,
        StringComparison.OrdinalIgnoreCase);

    if (isTargetLabel)
    {
        sensitivityLabel.IsRemoved = true;
        break;
    }
}

presentation.Save("presentation_with_removed_label.pptx", SaveFormat.Pptx);
```

## **Leggere e migrare le etichette di sensibilità MIP legacy**

I flussi di lavoro basati su MIP più vecchi possono memorizzare i metadati delle etichette di sensibilità in proprietà documento personalizzate anziché nella raccolta di etichette moderne. Leggi tali metadati con [IDocumentProperties.GetSensitivityLabels](https://reference.aspose.com/slides/it/net/aspose.slides/idocumentproperties/getsensitivitylabels/). Il metodo analizza le proprietà personalizzate legacy e restituisce un array di oggetti [ISensitivityLabel](https://reference.aspose.com/slides/it/net/aspose.slides/isensitivitylabel/).

Per migrare i metadati, aggiungi ogni etichetta restituita alla moderna [ISensitivityLabelCollection](https://reference.aspose.com/slides/it/net/aspose.slides/isensitivitylabelcollection/) tramite [ISensitivityLabelCollection.Add](https://reference.aspose.com/slides/it/net/aspose.slides/isensitivitylabelcollection/add/). Poiché l'aggiunta di un identificatore di etichetta duplicato genera un'eccezione, l'esempio verifica la raccolta di destinazione prima di copiare ogni etichetta. È possibile aggiungere ulteriori convalide per confermare che ciascuna etichetta legacy esista ancora nella policy Purview corrente.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation_with_legacy_labels.pptx");
var legacySensitivityLabels = presentation.DocumentProperties.GetSensitivityLabels();
var modernSensitivityLabels = presentation.SensitivityLabels;

foreach (var legacySensitivityLabel in legacySensitivityLabels)
{
    var labelAlreadyExists = false;

    foreach (var modernSensitivityLabel in modernSensitivityLabels)
    {
        labelAlreadyExists = string.Equals(
            modernSensitivityLabel.Id,
            legacySensitivityLabel.Id,
            StringComparison.OrdinalIgnoreCase);

        if (labelAlreadyExists)
        {
            break;
        }
    }

    if (!labelAlreadyExists)
    {
        modernSensitivityLabels.Add(legacySensitivityLabel);
    }
}

presentation.Save("presentation_with_modern_labels.pptx", SaveFormat.Pptx);
```

La migrazione copia gli oggetti etichetta analizzati nella raccolta moderna. Non è necessario cancellare tutte le proprietà documento personalizzate, quindi i metadati del documento non correlati rimangono intatti. Usa [IPresentation.Save](https://reference.aspose.com/slides/it/net/aspose.slides/ipresentation/save/) con [SaveFormat.Pptx](https://reference.aspose.com/slides/it/net/aspose.slides.export/saveformat/) per scrivere i metadati delle etichette moderne in un file PPTX.

## **FAQ**

**L'aggiunta di un tipo di marcatura di contenuto crea un'intestazione, un piè di pagina o una filigrana visibili sulle diapositive?**

No. I valori aggiunti tramite [ISensitivityLabel.ContentMarkTypes](https://reference.aspose.com/slides/it/net/aspose.slides/isensitivitylabel/contentmarktypes/) descrivono le marcature associate all'etichetta di sensibilità. Non creano testo o forme visibili nella presentazione. Aggiungi il contenuto corrispondente alle diapositive separatamente se il tuo flusso di lavoro deve renderizzare tali marcature.

**Qual è la differenza tra contrassegnare un'etichetta come rimossa e eliminarla dalla raccolta?**

Impostare [ISensitivityLabel.IsRemoved](https://reference.aspose.com/slides/it/net/aspose.slides/isensitivitylabel/isremoved/) su `true` mantiene la voce dell'etichetta e registra il suo stato rimosso. Chiamare [ISensitivityLabelCollection.RemoveAt](https://reference.aspose.com/slides/it/net/aspose.slides/isensitivitylabelcollection/removeat/) elimina la voce dalla raccolta moderna. Scegli l'operazione che corrisponde ai requisiti di conservazione dei metadati della tua organizzazione.

**Una presentazione può contenere sia metadati MIP legacy sia etichette di sensibilità moderne?**

Sì. Le etichette legacy possono rimanere nelle proprietà documento personalizzate mentre le etichette moderne sono disponibili tramite [Presentation.SensitivityLabels](https://reference.aspose.com/slides/it/net/aspose.slides/presentation/sensitivitylabels/). Usa [IDocumentProperties.GetSensitivityLabels](https://reference.aspose.com/slides/it/net/aspose.slides/idocumentproperties/getsensitivitylabels/) per leggere i metadati legacy e migrare solo le etichette valide che non sono già presenti nella raccolta moderna.

** Cosa succede quando un'etichetta con lo stesso identificatore viene aggiunta più di una volta?**

[ISensitivityLabelCollection.Add](https://reference.aspose.com/slides/it/net/aspose.slides/isensitivitylabelcollection/add/) lancia un'`ArgumentException` quando la raccolta contiene già un'etichetta con lo stesso identificatore. Controlla i valori di [ISensitivityLabel.Id](https://reference.aspose.com/slides/it/net/aspose.slides/isensitivitylabel/id/) esistenti prima di aggiungere o migrare le etichette.

**Quale formato di output dovrebbe essere usato per conservare le etichette di sensibilità aggiornate?**

Salva la presentazione come PPTX chiamando [IPresentation.Save](https://reference.aspose.com/slides/it/net/aspose.slides/ipresentation/save/) con [SaveFormat.Pptx](https://reference.aspose.com/slides/it/net/aspose.slides.export/saveformat/), come mostrato negli esempi precedenti.