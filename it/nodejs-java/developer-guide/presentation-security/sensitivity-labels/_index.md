---
title: Gestire le etichette di sensibilità nelle presentazioni PowerPoint in JavaScript
linktitle: Etichette di sensibilità
type: docs
weight: 50
url: /it/nodejs-java/sensitivity-labels/
keywords:
- etichetta di sensibilità
- Microsoft Purview
- Microsoft Information Protection
- metadati MIP
- marcatura del contenuto
- protezione delle informazioni
- governance dei documenti
- PowerPoint
- PPTX
- sicurezza della presentazione
- Node.js
- JavaScript
- Aspose.Slides
description: "Leggi, aggiungi, aggiorna, rimuovi e migra le etichette di sensibilità di Microsoft Purview nelle presentazioni PowerPoint PPTX con Aspose.Slides per Node.js via Java."
---
## **Panoramica**

Le etichette di sensibilità di Microsoft Purview aiutano le organizzazioni a classificare e gestire i documenti. Durante l'elaborazione automatica di una presentazione, un'applicazione può dover preservare un'etichetta esistente, applicare un'etichetta selezionata da una policy, aggiornare il suo stato o migrare i metadati dell'etichetta scritti da un flusso di lavoro Microsoft Information Protection (MIP) più vecchio.

Aspose.Slides for Node.js via Java espone i metadati delle etichette di sensibilità moderne tramite [Presentation.getSensitivityLabels](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/presentation/#getSensitivityLabels). Questo metodo restituisce una [SensitivityLabelCollection](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/sensitivitylabelcollection/) che può essere ispezionata e modificata prima che la presentazione venga salvata come PPTX.

{{% alert color="primary" title="Note" %}}

Gli identificatori delle etichette di sensibilità e le informazioni sulla policy sono definiti dalla configurazione di Microsoft Purview. Convalida la disponibilità delle etichette e i requisiti della policy nel tuo ambiente prima di aggiungere o migrare i metadati. I valori di [SensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/sensitivitylabel/#getContentMarkTypes) descrivono le marcature di contenuto associate a un'etichetta; non aggiungono automaticamente testo o forme visibili alle diapositive.

{{% /alert %}}

## **Comprendere le proprietà delle etichette di sensibilità**

Ogni [SensitivityLabel](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/sensitivitylabel/) contiene i seguenti metadati:

| Metodi | Scopo |
| --- | --- |
| [SensitivityLabel.getId](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/sensitivitylabel/#getId) e [SensitivityLabel.setId](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/sensitivitylabel/#setId) | Ottieni o imposta l'identificatore dell'etichetta di sensibilità nella policy di Purview. |
| [SensitivityLabel.getSiteId](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/sensitivitylabel/#getSiteId) e [SensitivityLabel.setSiteId](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/sensitivitylabel/#setSiteId) | Ottieni o imposta il sito associato alla policy dell'etichetta. |
| [SensitivityLabel.isEnabled](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/sensitivitylabel/#isEnabled) e [SensitivityLabel.setEnabled](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/sensitivitylabel/#setEnabled) | Ottieni o imposta se l'etichetta è abilitata. |
| [SensitivityLabel.isRemoved](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/sensitivitylabel/#isRemoved) e [SensitivityLabel.setRemoved](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/sensitivitylabel/#setRemoved) | Ottieni o imposta se l'etichetta è stata rimossa. Imposta il valore su `true` quando lo stato di rimozione deve essere conservato nei metadati. |
| [SensitivityLabel.getAssignmentMethodType](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/sensitivitylabel/#getAssignmentMethodType) e [SensitivityLabel.setAssignmentMethodType](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/sensitivitylabel/#setAssignmentMethodType) | Ottieni o imposta se l'etichetta è stata applicata automaticamente o tramite decisione dell'utente. |
| [SensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/sensitivitylabel/#getContentMarkTypes) | Ottieni i tipi di marcatura di contenuto associati all'etichetta. |

La classe [SensitivityLabelAssignmentType](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/sensitivitylabelassignmenttype/) definisce come è stata assegnata un'etichetta:

- [SensitivityLabelAssignmentType.Standard](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/sensitivitylabelassignmenttype/) rappresenta un'etichetta predefinita o applicata automaticamente.
- [SensitivityLabelAssignmentType.Privileged](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/sensitivitylabelassignmenttype/) rappresenta un'etichetta applicata tramite decisione dell'utente, comprese le etichette applicate manualmente, consigliate e obbligatorie.

La classe [SensitivityLabelContentType](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/sensitivitylabelcontenttype/) definisce la marcatura associata a un'etichetta:

| Valore | Significato |
| --- | --- |
| [SensitivityLabelContentType.None](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/sensitivitylabelcontenttype/) | L'etichetta è stata applicata per impostazione predefinita o automaticamente. |
| [SensitivityLabelContentType.Header](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/sensitivitylabelcontenttype/) | È associata una marcatura di contenuto dell'intestazione. |
| [SensitivityLabelContentType.Footer](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/sensitivitylabelcontenttype/) | È associata una marcatura di contenuto del piè di pagina. |
| [SensitivityLabelContentType.Watermark](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/sensitivitylabelcontenttype/) | È associata una marcatura di contenuto della filigrana. |
| [SensitivityLabelContentType.Encryption](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/sensitivitylabelcontenttype/) | È associata una protezione di crittografia. |

È possibile associare più tipi di marcatura a una singola etichetta.

## **Elencare le etichette di sensibilità esistenti**

Leggi la raccolta di etichette moderne da [Presentation.getSensitivityLabels](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/presentation/#getSensitivityLabels) ed elencala. L'esempio seguente elenca tutte le proprietà e le marcature di contenuto memorizzate per ciascuna etichetta:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const sensitivityLabels = presentation.getSensitivityLabels();
    const labelCount = sensitivityLabels.getCount();

    for (let labelIndex = 0; labelIndex < labelCount; labelIndex++) {
        const sensitivityLabel = sensitivityLabels.get_Item(labelIndex);
        const labelIdentifier = sensitivityLabel.getId();
        const siteIdentifier = sensitivityLabel.getSiteId();
        const isEnabled = sensitivityLabel.isEnabled();
        const isRemoved = sensitivityLabel.isRemoved();
        const assignmentMethod = sensitivityLabel.getAssignmentMethodType();

        console.log("Label ID: " + labelIdentifier);
        console.log("Site ID: " + siteIdentifier);
        console.log("Enabled: " + isEnabled);
        console.log("Removed: " + isRemoved);
        console.log("Assignment method: " + assignmentMethod);

        const contentMarkTypes = sensitivityLabel.getContentMarkTypes();
        const contentMarkCount = contentMarkTypes.size();

        for (let contentMarkIndex = 0; contentMarkIndex < contentMarkCount; contentMarkIndex++) {
            const contentMarkType = contentMarkTypes.get_Item(contentMarkIndex);
            console.log("Content marking: " + contentMarkType);
        }
    }
} finally {
    presentation.dispose();
}
```

## **Aggiungere un'etichetta di sensibilità con marcatura del contenuto**

Usa [SensitivityLabelCollection.add](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/sensitivitylabelcollection/#add) con l'identificatore dell'etichetta, l'identificatore del sito, lo stato abilitato e il metodo di assegnazione. Dopo che il metodo restituisce la nuova [SensitivityLabel](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/sensitivitylabel/), aggiungi i valori di marcatura richiesti tramite l'elenco restituito da [SensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/sensitivitylabel/#getContentMarkTypes).

L'esempio seguente aggiunge un'etichetta selezionata manualmente associata a marcature di piè di pagina e filigrana, quindi salva il risultato come PPTX:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const sensitivityLabels = presentation.getSensitivityLabels();

    const labelIdentifier = "{11111111-2222-3333-4444-555555555555}";
    const siteIdentifier = java.callStaticMethodSync(
        "java.util.UUID",
        "fromString",
        "aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee");
    const isEnabled = true;
    const assignmentMethod = aspose.slides.SensitivityLabelAssignmentType.Privileged;

    const sensitivityLabel = sensitivityLabels.add(
        labelIdentifier,
        siteIdentifier,
        isEnabled,
        assignmentMethod);

    const contentMarkTypes = sensitivityLabel.getContentMarkTypes();
    contentMarkTypes.addItem(aspose.slides.SensitivityLabelContentType.Footer);
    contentMarkTypes.addItem(aspose.slides.SensitivityLabelContentType.Watermark);

    presentation.save("presentation_with_label.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Aggiornare un'etichetta di sensibilità**

I valori di [SensitivityLabel](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/sensitivitylabel/) sono leggibili/scrivibili, eccetto l'elenco restituito da [SensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/sensitivitylabel/#getContentMarkTypes) che viene modificato tramite le sue operazioni di lista. Dopo aver individuato l'etichetta necessaria, è possibile aggiornare il suo identificatore, l'identificatore del sito, lo stato abilitato, il metodo di assegnazione, lo stato di rimozione e i tipi di marcatura del contenuto. Salva la presentazione per rendere persistenti le modifiche.

L'esempio seguente aggiorna lo stato abilitato e il metodo di assegnazione della prima etichetta:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const sensitivityLabels = presentation.getSensitivityLabels();
    const labelCount = sensitivityLabels.getCount();

    if (labelCount > 0) {
        const sensitivityLabel = sensitivityLabels.get_Item(0);
        sensitivityLabel.setEnabled(true);
        sensitivityLabel.setAssignmentMethodType(
            aspose.slides.SensitivityLabelAssignmentType.Privileged);
    }

    presentation.save("presentation_with_updated_label.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Contrassegnare un'etichetta di sensibilità come rimossa**

Per conservare il fatto che un'etichetta è stata rimossa, individua l'etichetta e chiama [SensitivityLabel.setRemoved](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/sensitivitylabel/#setRemoved) con `true`. Questo mantiene la voce dell'etichetta registrando il suo stato di rimozione. Se invece è necessario eliminare una voce dalla raccolta moderna, usa [SensitivityLabelCollection.removeAt](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/sensitivitylabelcollection/#removeAt); usa [SensitivityLabelCollection.clear](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/sensitivitylabelcollection/#clear) per eliminare tutte le voci.

L'esempio seguente contrassegna un'etichetta specifica come rimossa e salva la presentazione aggiornata:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const sensitivityLabels = presentation.getSensitivityLabels();
    const targetLabelIdentifier = "{11111111-2222-3333-4444-555555555555}";
    const labelCount = sensitivityLabels.getCount();

    for (let labelIndex = 0; labelIndex < labelCount; labelIndex++) {
        const sensitivityLabel = sensitivityLabels.get_Item(labelIndex);
        const labelIdentifier = sensitivityLabel.getId();
        const isTargetLabel = labelIdentifier.toLowerCase() === targetLabelIdentifier.toLowerCase();

        if (isTargetLabel) {
            sensitivityLabel.setRemoved(true);
            break;
        }
    }

    presentation.save("presentation_with_removed_label.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Leggere e migrare le etichette di sensibilità MIP legacy**

I flussi di lavoro basati su MIP più vecchi possono memorizzare i metadati delle etichette di sensibilità in proprietà documento personalizzate anziché nella raccolta di etichette moderne. Leggi quei metadati con [DocumentProperties.getSensitivityLabels](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/documentproperties/#getSensitivityLabels). Il metodo analizza le proprietà personalizzate legacy e restituisce un array di oggetti [SensitivityLabel](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/sensitivitylabel/).

Per migrare i metadati, aggiungi ogni etichetta restituita alla moderna [SensitivityLabelCollection](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/sensitivitylabelcollection/) tramite [SensitivityLabelCollection.add](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/sensitivitylabelcollection/#add). Poiché l'aggiunta di un identificatore di etichetta duplicato genera un'eccezione, l'esempio controlla la raccolta di destinazione prima di copiare ciascuna etichetta. È possibile aggiungere ulteriori convalide per confermare che ogni etichetta legacy esista ancora nella policy Purview corrente.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("presentation_with_legacy_labels.pptx");
try {
    const legacySensitivityLabels = presentation.getDocumentProperties().getSensitivityLabels();
    const modernSensitivityLabels = presentation.getSensitivityLabels();

    for (let legacyLabelIndex = 0; legacyLabelIndex < legacySensitivityLabels.length; legacyLabelIndex++) {
        const legacySensitivityLabel = legacySensitivityLabels[legacyLabelIndex];
        const legacyLabelIdentifier = legacySensitivityLabel.getId();
        const modernLabelCount = modernSensitivityLabels.getCount();
        let labelAlreadyExists = false;

        for (let modernLabelIndex = 0; modernLabelIndex < modernLabelCount; modernLabelIndex++) {
            const modernSensitivityLabel = modernSensitivityLabels.get_Item(modernLabelIndex);
            const modernLabelIdentifier = modernSensitivityLabel.getId();

            labelAlreadyExists =
                modernLabelIdentifier.toLowerCase() === legacyLabelIdentifier.toLowerCase();

            if (labelAlreadyExists) {
                break;
            }
        }

        if (!labelAlreadyExists) {
            modernSensitivityLabels.add(legacySensitivityLabel);
        }
    }

    presentation.save("presentation_with_modern_labels.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

La migrazione copia gli oggetti etichetta analizzati nella raccolta moderna. Non è necessario cancellare tutte le proprietà documento personalizzate, quindi i metadati del documento non correlati rimangono intatti. Usa [Presentation.save](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/presentation/#save) con [SaveFormat.Pptx](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/saveformat/) per scrivere i metadati delle etichette moderne in un file PPTX.

## **FAQ**

**L'aggiunta di un tipo di marcatura del contenuto crea un'intestazione, un piè di pagina o una filigrana visibili sulle diapositive?**

No. I valori aggiunti tramite l'elenco restituito da [SensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/sensitivitylabel/#getContentMarkTypes) descrivono le marcature associate all'etichetta di sensibilità. Non creano testo o forme visibili nella presentazione. Aggiungi separatamente il contenuto della diapositiva corrispondente se il tuo flusso di lavoro deve renderizzare tali marcature.

**Qual è la differenza tra contrassegnare un'etichetta come rimossa e eliminarla dalla raccolta?**

Chiamare [SensitivityLabel.setRemoved](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/sensitivitylabel/#setRemoved) con `true` mantiene la voce dell'etichetta e registra il suo stato di rimozione. Chiamare [SensitivityLabelCollection.removeAt](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/sensitivitylabelcollection/#removeAt) elimina la voce dalla raccolta moderna. Scegli l'operazione che corrisponde ai requisiti di conservazione dei metadati della tua organizzazione.

**Una presentazione può contenere sia metadati MIP legacy sia etichette di sensibilità moderne?**

Sì. Le etichette legacy possono rimanere nelle proprietà documento personalizzate, mentre le etichette moderne sono disponibili tramite [Presentation.getSensitivityLabels](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/presentation/#getSensitivityLabels). Usa [DocumentProperties.getSensitivityLabels](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/documentproperties/#getSensitivityLabels) per leggere i metadati legacy e migrare solo le etichette valide che non sono già presenti nella raccolta moderna.

**Cosa accade quando un'etichetta con lo stesso identificatore viene aggiunta più di una volta?**

[SensitivityLabelCollection.add](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/sensitivitylabelcollection/#add) genera un'eccezione quando la raccolta contiene già un'etichetta con lo stesso identificatore. Controlla i valori esistenti restituiti da [SensitivityLabel.getId](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/sensitivitylabel/#getId) prima di aggiungere o migrare le etichette.

**Quale formato di output dovrebbe essere utilizzato per preservare le etichette di sensibilità aggiornate?**

Salva la presentazione come PPTX chiamando [Presentation.save](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/presentation/#save) con [SaveFormat.Pptx](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/saveformat/), come mostrato negli esempi precedenti.