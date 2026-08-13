---
title: Gestire tag e dati personalizzati nelle presentazioni su Android
linktitle: Tag e dati personalizzati
type: docs
weight: 300
url: /it/androidjava/managing-tags-and-custom-data
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
- Android
- Java
- Aspose.Slides
description: "Scopri come gestire tag e dati XML personalizzati nelle presentazioni PowerPoint con Aspose.Slides per Android tramite Java, includendo l'aggiunta, la lettura, l'aggiornamento, la verifica e la rimozione di parti XML personalizzate."
---
## **Panoramica**

Questo articolo spiega come Aspose.Slides gestisce i tag e i dati personalizzati nelle presentazioni PowerPoint. I dati specifici della presentazione possono essere memorizzati come tag o parti XML personalizzate. I tag sono semplici coppie di stringa chiave‑valore, mentre le parti XML personalizzate possono memorizzare metadati strutturati e payload XML specifici dell'applicazione.

Aspose.Slides fornisce API per aggiungere, leggere, aggiornare, verificare e rimuovere parti XML personalizzate a livello di presentazione, diapositiva e forma. Le parti XML personalizzate sono utili per integrazioni che archiviano informazioni come identificatori di gestione documenti, stato del flusso di lavoro, metadati di conformità, dati di collegamento a template o altri dati applicativi strutturati all'interno di una presentazione.

## **Archiviazione dei dati nei file di presentazione**

I file PPTX—file con estensione `.pptx`—sono memorizzati nel formato PresentationML, che fa parte della specifica Office Open XML. Office Open XML definisce la struttura del pacchetto e le relazioni utilizzate per archiviare il contenuto della presentazione e i dati correlati.

Una presentazione contiene più parti connesse tramite relazioni. Ad esempio, una parte diapositiva contiene il contenuto di una singola diapositiva e può avere relazioni esplicite a altre parti definite da ISO/IEC 29500.

I dati personalizzati possono essere memorizzati come tag ([ITagCollection](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ITagCollection)) o parti XML personalizzate ([ICustomXmlPartCollection](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ICustomXmlPartCollection)). Entrambi sono disponibili tramite l'interfaccia [`ICustomData`](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ICustomData/) .

{{% alert color="info" %}}
I tag memorizzano semplici coppie chiave‑valore di stringa. Le parti XML personalizzate memorizzano dati XML strutturati e possono essere associate a una presentazione, a una diapositiva o a una forma.
{{% /alert %}}

## **Lavorare con le parti XML personalizzate**

Il metodo [`ICustomData.getCustomXmlParts()`](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ICustomData#getCustomXmlParts--) restituisce la collezione di parti XML personalizzate associate a un determinato oggetto della presentazione. Per esempio:

- `presentation.getCustomData().getCustomXmlParts()` contiene le parti XML personalizzate associate alla stessa presentazione.
- `slide.getCustomData().getCustomXmlParts()` contiene le parti XML personalizzate associate a una specifica diapositiva.
- `shape.getCustomData().getCustomXmlParts()` contiene le parti XML personalizzate associate a una specifica forma.

Usa [`Presentation.getAllCustomXmlParts()`](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/Presentation#getAllCustomXmlParts--) quando è necessario esaminare tutte le parti XML personalizzate nella presentazione, indipendentemente da dove siano associate.

### **Aggiungere una parte XML personalizzata a una presentazione**

Usa [`ICustomXmlPartCollection.add`](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ICustomXmlPartCollection#add-java.lang.String-) per aggiungere dati XML a una collezione di parti XML personalizzate. L'XML deve essere valido e non vuoto.

L'esempio seguente aggiunge metadati strutturati alla collezione di dati personalizzati a livello di presentazione:

```java
import com.aspose.slides.*;
import java.util.UUID;

String customXmlContent =
    "<?xml version=\"1.0\" encoding=\"UTF-8\"?>" +
    "<metadata xmlns=\"urn:example:metadata\">" +
        "<documentId>DOC-1001</documentId>" +
        "<workflowState>Draft</workflowState>" +
    "</metadata>";

Presentation presentation = new Presentation();
try {
    ICustomXmlPart customXmlPart = presentation.getCustomData().getCustomXmlParts().add(customXmlContent);

    // add assegna un identificatore automaticamente. Imposta un UUID specifico solo quando necessario.
    customXmlPart.setItemId(UUID.randomUUID());

    presentation.save("presentation_with_custom_xml.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Il metodo `add` può anche accettare XML come array di byte o stream di input, utile quando il contenuto XML è già disponibile in forma binaria.

### **Aggiungere una parte XML personalizzata a una diapositiva o a una forma**

I dati XML personalizzati possono essere associati a una specifica diapositiva o forma anziché all'intera presentazione. Ciò è utile quando i metadati descrivono un solo oggetto, ad esempio una chiave di template, un identificatore di record esterno o informazioni di binding.

L'esempio seguente aggiunge una parte XML personalizzata a una diapositiva e un'altra a una forma:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    slide.getCustomData().getCustomXmlParts().add(
        "<slideMetadata xmlns=\"urn:example:slides\">" +
            "<templateKey>TitleSlide</templateKey>" +
        "</slideMetadata>");

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 250, 80);

    shape.getTextFrame().setText("Customer data");
    shape.getCustomData().getCustomXmlParts().add(
        "<shapeMetadata xmlns=\"urn:example:shapes\">" +
            "<recordId>CRM-4281</recordId>" +
        "</shapeMetadata>");

    presentation.save("object_custom_xml.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Il livello al quale una parte viene aggiunta determina quale collezione `getCustomData().getCustomXmlParts()` dell'oggetto contiene la relazione a quella parte. I dati a livello di presentazione sono appropriati per metadati a livello di documento, i dati a livello di diapositiva per informazioni che appartengono a una specifica diapositiva e i dati a livello di forma per metadati legati a una singola forma.

### **Elencare e verificare tutte le parti XML personalizzate**

Usa [`Presentation.getAllCustomXmlParts()`](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/Presentation#getAllCustomXmlParts--) per recuperare tutte le parti XML personalizzate da una presentazione. Ogni [`ICustomXmlPart`](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ICustomXmlPart/) espone il proprio identificatore, il contenuto XML e gli schemi di namespace associati.

L'esempio seguente elenca tutte le parti XML personalizzate e i loro schemi di namespace:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    for (ICustomXmlPart customXmlPart : presentation.getAllCustomXmlParts()) {
        System.out.println("ItemId: " + customXmlPart.getItemId());
        System.out.println("XML:");
        System.out.println(customXmlPart.getXmlAsString());

        for (String namespaceSchema : customXmlPart.getNamespaceSchemas()) {
            System.out.println("Namespace schema: " + namespaceSchema);
        }

        System.out.println();
    }
} finally {
    presentation.dispose();
}
```

[`ICustomXmlPart.getNamespaceSchemas()`](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ICustomXmlPart#getNamespaceSchemas--) restituisce gli schemi XML associati alla parte XML personalizzata. queste informazioni possono essere utili nella verifica di presentazioni che contengono XML prodotto da sistemi esterni.

### **Leggere e aggiornare il contenuto XML e ItemId**

Usa [`ICustomXmlPart.getXmlAsString()`](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ICustomXmlPart#getXmlAsString--) e [`setXmlAsString()`](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ICustomXmlPart#setXmlAsString-java.lang.String-) per lavorare con l'XML come stringa UTF‑8, oppure [`getXmlData()`](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ICustomXmlPart#getXmlData--) e [`setXmlData()`](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ICustomXmlPart#setXmlData-byte:A-) per gestire i byte grezzi dell'XML.

Il metodo [`ICustomXmlPart.getItemId()`](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ICustomXmlPart#getItemId--) restituisce l'UUID che identifica la parte XML personalizzata nel documento Office Open XML. Usa [`setItemId()`](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ICustomXmlPart#setItemId-java.util.UUID-) quando un'integrazione richiede un nuovo identificatore.

L'esempio seguente aggiorna il contenuto XML e l'identificatore:

```java
import com.aspose.slides.*;
import java.nio.charset.StandardCharsets;
import java.util.UUID;

Presentation presentation = new Presentation("presentation.pptx");
try {
    ICustomXmlPart customXmlPart = presentation.getAllCustomXmlParts()[0];

    // Leggi l'XML corrente come testo.
    String currentXmlContent = customXmlPart.getXmlAsString();
    System.out.println(currentXmlContent);

    // Aggiorna l'XML come stringa UTF-8.
    customXmlPart.setXmlAsString(
        "<metadata xmlns=\"urn:example:metadata\">" +
            "<documentId>DOC-1001</documentId>" +
            "<workflowState>Approved</workflowState>" +
        "</metadata>");

    // getXmlData fornisce lo stesso contenuto XML come byte grezzi.
    byte[] customXmlData = customXmlPart.getXmlData();
    System.out.println(new String(customXmlData, StandardCharsets.UTF_8));

    // Sostituisci l'identificatore quando richiesto dall'integrazione.
    customXmlPart.setItemId(UUID.randomUUID());

    presentation.save("updated_custom_xml.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Quando chiami `setXmlAsString` o `setXmlData`, fornisci XML valido e non vuoto. Usa una rappresentazione o l'altra in base al fatto che l'applicazione lavori principalmente con stringhe o dati binari.

### **Rimuovere una parte XML personalizzata**

Aspose.Slides offre diversi modi per rimuovere dati XML personalizzati:

- [`ICustomXmlPart.remove`](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ICustomXmlPart#remove--) rimuove la parte XML personalizzata dalla presentazione.
- [`ICustomXmlPartCollection.remove`](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ICustomXmlPartCollection#remove-com.aspose.slides.ICustomXmlPart-) rimuove una parte specifica da una collezione di parti XML personalizzate.
- [`ICustomXmlPartCollection.removeAt`](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ICustomXmlPartCollection#removeAt-int--) rimuove la parte all'indice specificato nella collezione.
- [`ICustomXmlPartCollection.clear`](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ICustomXmlPartCollection#clear--) rimuove tutte le parti da una collezione specifica.

L'esempio seguente rimuove una parte XML personalizzata a livello di presentazione per riferimento:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    ICustomXmlPartCollection customXmlParts = presentation.getCustomData().getCustomXmlParts();

    if (customXmlParts.size() > 0) {
        ICustomXmlPart customXmlPart = customXmlParts.get_Item(0);
        customXmlParts.remove(customXmlPart);
    }

    presentation.save("custom_xml_removed.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Se disponi già di un `ICustomXmlPart` e vuoi rimuovere quella parte dalla presentazione anziché da una collezione specifica, chiama `customXmlPart.remove()`.

Puoi anche rimuovere un elemento per indice:

```java
presentation.getCustomData().getCustomXmlParts().removeAt(0);
```

### **Cancellare tutte le parti XML personalizzate da una collezione**

Usa `clear` quando tutte le parti XML personalizzate associate a un determinato oggetto della presentazione devono essere rimosse.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    presentation.getSlides().get_Item(0).getCustomData().getCustomXmlParts().clear();

    presentation.save("slide_custom_xml_cleared.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

`clear` agisce solo sulla collezione selezionata. Ad esempio, cancellare la collezione di una diapositiva non cancella le collezioni a livello di presentazione o di forma.

Per rimuovere ogni parte XML personalizzata nella presentazione, iterare su `getAllCustomXmlParts()` e rimuovere ciascuna parte:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    for (ICustomXmlPart customXmlPart : presentation.getAllCustomXmlParts()) {
        customXmlPart.remove();
    }

    presentation.save("all_custom_xml_removed.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Gestire parti XML personalizzate collegate o condivise**

In una presentazione Office Open XML, la stessa parte XML personalizzata può essere riferita da più di un oggetto della presentazione. Ad esempio, un file esistente può contenere relazioni da più diapositive o forme alla stessa parte XML sottostante.

Una parte condivisa deve essere trattata come un unico oggetto dati con più riferimenti:

- Aggiornandola con `setXmlAsString`, `setXmlData` o `setItemId` si modifica la parte XML sottostante, quindi la modifica si applica ovunque la parte sia referenziata.
- `getItemId()` può essere usato per identificare la stessa parte XML durante la verifica di collezioni a livello di oggetto.
- Rimuovere una parte da una specifica collezione `getCustomXmlParts()` la elimina solo da quella collezione. Usa `ICustomXmlPart.remove()` quando la parte stessa deve essere rimossa dalla presentazione.
- Prima di eliminare o sostituire una parte condivisa, controlla le collezioni a livello di oggetto per determinare se altre diapositive o forme la riferiscono ancora.

Le overload di `add` creano una nuova parte XML personalizzata dal contenuto XML; non accettano un `ICustomXmlPart` già esistente. Pertanto, le relazioni condivise si incontrano più frequentemente durante il caricamento di presentazioni che le contengono già.

L'esempio seguente verifica le collezioni a livello di presentazione, diapositiva e forma per `ItemId` e segnala le parti referenziate da più di un luogo:

```java
import com.aspose.slides.*;
import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import java.util.Map;
import java.util.UUID;
import java.util.function.BiConsumer;

Presentation presentation = new Presentation("presentation.pptx");
try {
    Map<UUID, List<String>> referencesByItemId = new HashMap<>();

    BiConsumer<String, ICustomXmlPartCollection> registerCustomXmlParts =
        (ownerName, customXmlParts) -> {
            for (int i = 0; i < customXmlParts.size(); i++) {
                ICustomXmlPart customXmlPart = customXmlParts.get_Item(i);
                UUID itemId = customXmlPart.getItemId();

                if (!referencesByItemId.containsKey(itemId)) {
                    referencesByItemId.put(itemId, new ArrayList<>());
                }

                referencesByItemId.get(itemId).add(ownerName);
            }
        };

    registerCustomXmlParts.accept("Presentation", presentation.getCustomData().getCustomXmlParts());

    for (int slideIndex = 0; slideIndex < presentation.getSlides().size(); slideIndex++) {
        ISlide slide = presentation.getSlides().get_Item(slideIndex);
        registerCustomXmlParts.accept("Slide " + (slideIndex + 1), slide.getCustomData().getCustomXmlParts());

        for (int shapeIndex = 0; shapeIndex < slide.getShapes().size(); shapeIndex++) {
            IShape shape = slide.getShapes().get_Item(shapeIndex);
            registerCustomXmlParts.accept("Slide " + (slideIndex + 1) + ", shape " + shapeIndex, shape.getCustomData().getCustomXmlParts());
        }
    }

    for (Map.Entry<UUID, List<String>> referenceEntry : referencesByItemId.entrySet()) {
        if (referenceEntry.getValue().size() > 1) {
            System.out.println("Shared custom XML part: " + referenceEntry.getKey());

            for (String ownerName : referenceEntry.getValue()) {
                System.out.println("  Referenced by: " + ownerName);
            }
        }
    }
} finally {
    presentation.dispose();
}
```

Questo tipo di verifica è utile prima di modificare o eliminare dati XML personalizzati in presentazioni create da sistemi esterni, poiché la stessa parte di metadati può partecipare a più relazioni.

## **Ottenere i valori dei tag**

In Slides, un tag corrisponde al metodo `IDocumentProperties.getKeywords()`. Questo esempio di codice mostra come ottenere il valore di un tag con Aspose.Slides per Android tramite Java per [Presentation](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/Presentation):

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    String keywords = presentation.getDocumentProperties().getKeywords();
} finally {
    presentation.dispose();
}
```

## **Aggiungere tag alle presentazioni**

Aspose.Slides consente di aggiungere tag alle presentazioni. Un tag tipicamente consiste di due elementi:

- il nome di una proprietà personalizzata, ad esempio `MyTag`;
- il valore della proprietà personalizzata, ad esempio `My Tag Value`.

Se devi classificare le presentazioni in base a una regola o proprietà specifica, puoi aggiungere tag a tale scopo. Ad esempio, se vuoi categorizzare le presentazioni dei paesi del Nord America, puoi creare un tag North American e assegnare come valore il paese pertinente.

Questo esempio di codice mostra come aggiungere un tag a una [Presentation](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/Presentation) usando Aspose.Slides per Android tramite Java:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    ITagCollection tags = presentation.getCustomData().getTags();
    tags.set_Item("MyTag", "My Tag Value");
} finally {
    presentation.dispose();
}
```

I tag possono essere impostati anche per una [Slide](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ISlide):

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    slide.getCustomData().getTags().set_Item("tag", "value");
} finally {
    presentation.dispose();
}
```

Oppure per una singola [Shape](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/IAutoShape):

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 100, 50);
    shape.getTextFrame().setText("My text");
    shape.getCustomData().getTags().set_Item("tag", "value");
} finally {
    presentation.dispose();
}
```

### **Limitazioni**

I tag aggiunti tramite la collezione `getCustomData().getTags()` vengono salvati solo nel file PowerPoint. Non vengono **trasferiti** alla struttura dei tag PDF quando la presentazione viene esportata in PDF. Di conseguenza, un identificatore personalizzato assegnato come tag non può essere recuperato dal PDF taggato.

**Soluzione alternativa**: è possibile memorizzare un identificatore personalizzato nel **Testo alternativo** dell'oggetto (ad esempio, `shape.setAlternativeText("MyId")`). Dopo l'esportazione in PDF, il Testo alternativo può comparire nella struttura dei tag PDF.

## **FAQ**

**Posso rimuovere tutti i tag da una presentazione, diapositiva o forma in un'unica operazione?**  
Sì. La [tag collection](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/tagcollection/) supporta un'operazione [clear](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/tagcollection/#clear--) che elimina tutte le coppie chiave‑valore in una sola volta.

**Come posso eliminare un singolo tag per nome senza iterare sull'intera collezione?**  
Usa [remove(name)](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/tagcollection/#remove-java.lang.String-) sulla [tag collection](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/tagcollection/) per cancellare il tag mediante la sua chiave.

**Come posso recuperare l'elenco completo dei nomi dei tag per analisi o filtraggio?**  
Usa [getNamesOfTags](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/tagcollection/#getNamesOfTags--) sulla [tag collection](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/tagcollection/); restituisce un array con tutti i nomi dei tag.

**Come posso trovare tutte le parti XML personalizzate indipendentemente da dove siano archiviate?**  
Usa [`Presentation.getAllCustomXmlParts()`](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/Presentation#getAllCustomXmlParts--) per recuperare tutte le parti XML personalizzate nella presentazione.

**Devo usare `getXmlAsString`/`setXmlAsString` o `getXmlData`/`setXmlData` per aggiornare una parte XML personalizzata?**  
Usa `getXmlAsString` e `setXmlAsString` quando l'applicazione lavora con testo XML UTF‑8. Usa `getXmlData` e `setXmlData` quando l'XML è già disponibile come array di byte oppure quando è più comodo un'elaborazione orientata al binario. Entrambe le rappresentazioni si riferiscono al contenuto XML della stessa parte XML personalizzata.