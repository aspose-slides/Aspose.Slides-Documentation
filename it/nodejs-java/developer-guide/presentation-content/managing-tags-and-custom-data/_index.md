---
title: Gestire Tag e Dati Personalizzati nelle Presentazioni usando JavaScript
linktitle: Tag e Dati Personalizzati
type: docs
weight: 300
url: /it/nodejs-java/managing-tags-and-custom-data/
keywords:
- proprietà del documento
- tag
- dati personalizzati
- XML personalizzato
- parte XML personalizzata
- metadati XML
- ItemId
- aggiungi tag
- coppie di valori
- PowerPoint
- presentazione
- Node.js
- JavaScript
- Aspose.Slides
description: "Scopri come gestire tag e dati XML personalizzati nelle presentazioni PowerPoint con Aspose.Slides per Node.js via Java, inclusa l'aggiunta, la lettura, l'aggiornamento, la verifica e la rimozione di parti XML personalizzate."
---
## **Panoramica**

Questo articolo spiega come Aspose.Slides gestisce i tag e i dati personalizzati nelle presentazioni PowerPoint. I dati specifici della presentazione possono essere memorizzati come tag o parti XML personalizzate. I tag sono semplici coppie chiave‑valore di stringa, mentre le parti XML personalizzate possono archiviare metadati strutturati e payload XML specifici dell'applicazione.

Aspose.Slides fornisce API per aggiungere, leggere, aggiornare, verificare e rimuovere parti XML personalizzate a livello di presentazione, diapositiva e forma. Le parti XML personalizzate sono utili per integrazioni che memorizzano informazioni come identificatori di gestione documenti, stato del flusso di lavoro, metadati di conformità, dati di associazione del modello o altri dati applicativi strutturati all'interno di una presentazione.

## **Archiviazione dei dati nei file di presentazione**

I file PPTX — file con estensione `.pptx` — sono archiviati nel formato PresentationML, che fa parte della specifica Office Open XML. Office Open XML definisce la struttura del pacchetto e le relazioni utilizzate per memorizzare il contenuto della presentazione e i dati correlati.

Una presentazione contiene più parti collegate da relazioni. Ad esempio, una parte di diapositiva contiene il contenuto di una singola diapositiva e può avere relazioni esplicite con altre parti definite da ISO/IEC 29500.

I dati personalizzati possono essere memorizzati come tag ([TagCollection](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/tagcollection/)) o parti XML personalizzate ([CustomXmlPartCollection](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/customxmlpartcollection/)). Entrambi sono disponibili tramite la classe [`CustomData`](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/customdata/).

{{% alert color="primary" %}}
I tag memorizzano semplici coppie chiave‑valore di stringa. Le parti XML personalizzate memorizzano dati XML strutturati e possono essere associate a una presentazione, a una diapositiva o a una forma.
{{% /alert %}}

## **Lavorare con le parti XML personalizzate**

Il metodo `getCustomXmlParts()` di [`CustomData`](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/customdata/) restituisce la collezione di parti XML personalizzate associate a un determinato oggetto di presentazione. Per esempio:

- `presentation.getCustomData().getCustomXmlParts()` contiene le parti XML personalizzate associate alla presentazione stessa.
- `slide.getCustomData().getCustomXmlParts()` contiene le parti XML personalizzate associate a una diapositiva specifica.
- `shape.getCustomData().getCustomXmlParts()` contiene le parti XML personalizzate associate a una forma specifica.

Utilizza [`Presentation.getAllCustomXmlParts()`](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/presentation/) quando è necessario esaminare tutte le parti XML personalizzate nella presentazione, indipendentemente da dove siano associate.

### **Aggiungere una parte XML personalizzata a una presentazione**

Usa il metodo `add` di [`CustomXmlPartCollection`](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/customxmlpartcollection/) per aggiungere dati XML a una collezione di parti XML personalizzate. L'XML deve essere valido e non vuoto.

Il seguente esempio aggiunge metadati strutturati alla collezione di dati personalizzati a livello di presentazione:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const customXmlContent =
    '<?xml version="1.0" encoding="UTF-8"?>' +
    '<metadata xmlns="urn:example:metadata">' +
        '<documentId>DOC-1001</documentId>' +
        '<workflowState>Draft</workflowState>' +
    '</metadata>';

const presentation = new aspose.slides.Presentation();
try {
    const customXmlPart = presentation.getCustomData().getCustomXmlParts().add(customXmlContent);

    // add assegna un identificatore automaticamente. Imposta un UUID specifico solo quando necessario.
    const itemId = java.callStaticMethodSync("java.util.UUID", "randomUUID");
    customXmlPart.setItemId(itemId);

    presentation.save("presentation_with_custom_xml.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Il metodo `add` può anche accettare XML come array di byte, utile quando il contenuto XML è già disponibile in forma binaria.

### **Aggiungere una parte XML personalizzata a una diapositiva o a una forma**

I dati XML personalizzati possono essere associati a una diapositiva o a una forma specifica invece che all'intera presentazione. Ciò è utile quando i metadati descrivono un solo oggetto, ad esempio una chiave di modello, un identificatore di record esterno o informazioni di binding.

Il seguente esempio aggiunge una parte XML personalizzata a una diapositiva e un'altra a una forma:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    slide.getCustomData().getCustomXmlParts().add(
        '<slideMetadata xmlns="urn:example:slides">' +
            '<templateKey>TitleSlide</templateKey>' +
        '</slideMetadata>');

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 250, 80);

    shape.getTextFrame().setText("Customer data");
    shape.getCustomData().getCustomXmlParts().add(
        '<shapeMetadata xmlns="urn:example:shapes">' +
            '<recordId>CRM-4281</recordId>' +
        '</shapeMetadata>');

    presentation.save("object_custom_xml.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Il livello al quale una parte viene aggiunta determina quale collezione `getCustomData().getCustomXmlParts()` dell'oggetto contiene la relazione a quella parte. I dati a livello di presentazione sono appropriati per metadati a livello di documento, i dati a livello di diapositiva per informazioni relative a una specifica diapositiva e i dati a livello di forma per metadati associati a una singola forma.

### **Elencare e verificare tutte le parti XML personalizzate**

Utilizza [`Presentation.getAllCustomXmlParts()`](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/presentation/) per recuperare tutte le parti XML personalizzate da una presentazione. Ogni [`CustomXmlPart`](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/customxmlpart/) espone il suo identificatore, il contenuto XML e gli schemi di namespace associati.

Il seguente esempio elenca tutte le parti XML personalizzate e i loro schemi di namespace:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const customXmlParts = presentation.getAllCustomXmlParts();

    for (let partIndex = 0; partIndex < customXmlParts.length; partIndex++) {
        const customXmlPart = customXmlParts[partIndex];

        console.log("ItemId: " + customXmlPart.getItemId());
        console.log("XML:");
        console.log(customXmlPart.getXmlAsString());

        const namespaceSchemas = customXmlPart.getNamespaceSchemas();
        for (let schemaIndex = 0; schemaIndex < namespaceSchemas.length; schemaIndex++) {
            console.log("Namespace schema: " + namespaceSchemas[schemaIndex]);
        }

        console.log();
    }
} finally {
    presentation.dispose();
}
```

`CustomXmlPart.getNamespaceSchemas()` restituisce gli schemi XML associati alla parte XML personalizzata. queste informazioni possono essere utili quando si verificano presentazioni che contengono XML prodotto da sistemi esterni.

### **Leggere e aggiornare il contenuto XML e ItemId**

Usa `getXmlAsString()` e `setXmlAsString()` da [`CustomXmlPart`](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/customxmlpart/) per lavorare con XML come stringa UTF-8, oppure `getXmlData()` e `setXmlData()` per lavorare con i byte XML grezzi.

Il metodo `getItemId()` restituisce l'UUID che identifica la parte XML personalizzata nel documento Office Open XML. Usa `setItemId()` quando un'integrazione richiede un nuovo identificatore.

Il seguente esempio aggiorna il contenuto XML e l'identificatore:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const customXmlPart = presentation.getAllCustomXmlParts()[0];

    // Leggi l'XML corrente come testo.
    const currentXmlContent = customXmlPart.getXmlAsString();
    console.log(currentXmlContent);

    // Aggiorna l'XML come stringa UTF-8.
    customXmlPart.setXmlAsString(
        '<metadata xmlns="urn:example:metadata">' +
            '<documentId>DOC-1001</documentId>' +
            '<workflowState>Approved</workflowState>' +
        '</metadata>');

    // getXmlData fornisce lo stesso contenuto XML come byte grezzi.
    const customXmlData = customXmlPart.getXmlData();
    console.log(Buffer.from(customXmlData).toString("utf8"));

    // Sostituisci l'identificatore quando richiesto dall'integrazione.
    const itemId = java.callStaticMethodSync("java.util.UUID", "randomUUID");
    customXmlPart.setItemId(itemId);

    presentation.save("updated_custom_xml.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Quando si chiama `setXmlAsString` o `setXmlData`, fornire XML valido e non vuoto. Usa una rappresentazione o l'altra a seconda che l'applicazione lavori principalmente con stringhe o dati binari.

### **Rimuovere una parte XML personalizzata**

Aspose.Slides fornisce diversi modi per rimuovere dati XML personalizzati:

- `CustomXmlPart.remove` rimuove la parte XML personalizzata dalla presentazione.
- `CustomXmlPartCollection.remove` rimuove una parte specifica da una collezione di parti XML personalizzate.
- `CustomXmlPartCollection.removeAt` rimuove la parte all'indice specificato nella collezione.
- `CustomXmlPartCollection.clear` rimuove tutte le parti da una collezione specifica.

Il seguente esempio rimuove una parte XML personalizzata a livello di presentazione per riferimento:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const customXmlParts = presentation.getCustomData().getCustomXmlParts();

    if (customXmlParts.size() > 0) {
        const customXmlPart = customXmlParts.get_Item(0);
        customXmlParts.remove(customXmlPart);
    }

    presentation.save("custom_xml_removed.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Se disponi già di un `CustomXmlPart` e vuoi rimuovere quella parte dalla presentazione invece di indirizzare una collezione specifica, chiama `customXmlPart.remove()`.

Puoi anche rimuovere un elemento per indice:

```javascript
presentation.getCustomData().getCustomXmlParts().removeAt(0);
```

### **Cancellare tutte le parti XML personalizzate da una collezione**

Usa `clear` quando tutte le parti XML personalizzate associate a un determinato oggetto di presentazione devono essere rimosse.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    presentation.getSlides().get_Item(0).getCustomData().getCustomXmlParts().clear();

    presentation.save("slide_custom_xml_cleared.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

`clear` influisce solo sulla collezione selezionata. Ad esempio, cancellare la collezione di una diapositiva non cancella le collezioni a livello di presentazione o di forma.

Per rimuovere ogni parte XML personalizzata nella presentazione, itera su `getAllCustomXmlParts()` e rimuovi ogni parte:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const customXmlParts = presentation.getAllCustomXmlParts();

    for (let partIndex = 0; partIndex < customXmlParts.length; partIndex++) {
        customXmlParts[partIndex].remove();
    }

    presentation.save("all_custom_xml_removed.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Gestire le parti XML personalizzate collegate o condivise**

In una presentazione Office Open XML, la stessa parte XML personalizzata può essere referenziata da più di un oggetto di presentazione. Ad esempio, un file esistente può contenere relazioni da più diapositive o forme alla stessa parte XML personalizzata sottostante.

Una parte condivisa dovrebbe essere trattata come un unico oggetto dati con più riferimenti:

- Aggiornandola con `setXmlAsString`, `setXmlData` o `setItemId` si modifica la parte XML personalizzata sottostante, quindi la modifica si applica ovunque quella parte sia referenziata.
- `getItemId()` può essere usato per identificare la stessa parte XML personalizzata durante la verifica delle collezioni a livello di oggetto.
- La rimozione di una parte da una specifica collezione `getCustomXmlParts()` la elimina da quella collezione. Usa `CustomXmlPart.remove()` quando la parte stessa deve essere rimossa dalla presentazione.
- Prima di eliminare o sostituire una parte condivisa, ispeziona le collezioni a livello di oggetto per determinare se altre diapositive o forme la referenziano ancora.

Le overload di `add` creano una nuova parte XML personalizzata dal contenuto XML; non accettano un `CustomXmlPart` esistente. Pertanto, le relazioni condivise si incontrano più comunemente durante il caricamento di presentazioni che le contengono già.

Il seguente esempio verifica le collezioni a livello di presentazione, diapositiva e forma per `ItemId` e segnala le parti referenziate da più di un luogo:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const referencesByItemId = new Map();

    const registerCustomXmlParts = (ownerName, customXmlParts) => {
        for (let partIndex = 0; partIndex < customXmlParts.size(); partIndex++) {
            const customXmlPart = customXmlParts.get_Item(partIndex);
            const itemId = customXmlPart.getItemId().toString();

            if (!referencesByItemId.has(itemId)) {
                referencesByItemId.set(itemId, []);
            }

            referencesByItemId.get(itemId).push(ownerName);
        }
    };

    registerCustomXmlParts("Presentation", presentation.getCustomData().getCustomXmlParts());

    for (let slideIndex = 0; slideIndex < presentation.getSlides().size(); slideIndex++) {
        const slide = presentation.getSlides().get_Item(slideIndex);

        registerCustomXmlParts("Slide " + (slideIndex + 1), slide.getCustomData().getCustomXmlParts());

        for (let shapeIndex = 0; shapeIndex < slide.getShapes().size(); shapeIndex++) {
            const shape = slide.getShapes().get_Item(shapeIndex);

            registerCustomXmlParts("Slide " + (slideIndex + 1) + ", shape " + shapeIndex, shape.getCustomData().getCustomXmlParts());
        }
    }

    for (const [itemId, owners] of referencesByItemId) {
        if (owners.length > 1) {
            console.log("Shared custom XML part: " + itemId);

            for (const ownerName of owners) {
                console.log("  Referenced by: " + ownerName);
            }
        }
    }
} finally {
    presentation.dispose();
}
```

Questo tipo di verifica è utile prima di modificare o eliminare dati XML personalizzati in presentazioni create da sistemi esterni, poiché la stessa parte di metadati può partecipare a più di una relazione.

## **Ottenere i valori dei tag**

In slides, un tag corrisponde al metodo `DocumentProperties.getKeywords()`. Questo esempio di codice mostra come ottenere il valore di un tag con Aspose.Slides per Node.js via Java per [Presentation](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/presentation/):

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const keywords = presentation.getDocumentProperties().getKeywords();
} finally {
    presentation.dispose();
}
```

## **Aggiungere tag alle presentazioni**

Aspose.Slides consente di aggiungere tag alle presentazioni. Un tag tipicamente è composto da due elementi:

- il nome di una proprietà personalizzata, ad esempio `MyTag`;
- il valore della proprietà personalizzata, ad esempio `My Tag Value`.

Se è necessario classificare le presentazioni in base a una regola o proprietà specifica, è possibile aggiungere tag a tale scopo. Ad esempio, se vuoi categorizzare le presentazioni dei paesi del Nord America, puoi creare un tag Nord Americano e assegnare il paese pertinente come valore.

Questo esempio di codice mostra come aggiungere un tag a una [Presentation](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/presentation/) usando Aspose.Slides per Node.js via Java:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const tags = presentation.getCustomData().getTags();
    tags.set_Item("MyTag", "My Tag Value");
} finally {
    presentation.dispose();
}
```

I tag possono anche essere impostati per una [Slide](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/slide/):

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    slide.getCustomData().getTags().set_Item("tag", "value");
} finally {
    presentation.dispose();
}
```

Oppure per una singola [Shape](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/autoshape/):

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 10, 100, 50);

    shape.getTextFrame().setText("My text");
    shape.getCustomData().getTags().set_Item("tag", "value");
} finally {
    presentation.dispose();
}
```

### **Limitazioni**

I tag aggiunti tramite la collezione `getCustomData().getTags()` vengono memorizzati solo nel file PowerPoint. **Non** vengono trasferiti nella struttura dei tag PDF quando la presentazione viene esportata in PDF. Di conseguenza, un identificatore personalizzato assegnato come tag non può essere recuperato dal PDF con tag.

**Soluzione alternativa**: È possibile memorizzare un identificatore personalizzato nel **Alt Text** dell'oggetto (ad esempio, `shape.setAlternativeText("MyId")`). Dopo l'esportazione in PDF, l'Alt Text potrebbe apparire nella struttura dei tag PDF.

## **FAQ**

**Posso rimuovere tutti i tag da una presentazione, diapositiva o forma in un'unica operazione?**

Sì. La [collezione di tag](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/tagcollection/) supporta un'operazione [clear](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/tagcollection/) che elimina tutte le coppie chiave‑valore in una volta.

**Come posso eliminare un singolo tag per nome senza iterare sull'intera collezione?**

Usa `remove(name)` sulla [collezione di tag](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/tagcollection/) per eliminare il tag per chiave.

**Come posso recuperare l'elenco completo dei nomi dei tag per analisi o filtraggio?**

Usa `getNamesOfTags()` sulla [collezione di tag](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/tagcollection/); restituisce un array di tutti i nomi dei tag.

**Come posso trovare tutte le parti XML personalizzate indipendentemente da dove siano archiviate?**

Usa [`Presentation.getAllCustomXmlParts()`](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/presentation/) per recuperare tutte le parti XML personalizzate nella presentazione.

**Devo usare `getXmlAsString`/`setXmlAsString` o `getXmlData`/`setXmlData` per aggiornare una parte XML personalizzata?**

Usa `getXmlAsString` e `setXmlAsString` quando l'applicazione lavora con testo XML UTF-8. Usa `getXmlData` e `setXmlData` quando l'XML è già disponibile come array di byte o quando è più comodo un'elaborazione orientata al binario. Entrambe le rappresentazioni si riferiscono al contenuto XML della stessa parte XML personalizzata.