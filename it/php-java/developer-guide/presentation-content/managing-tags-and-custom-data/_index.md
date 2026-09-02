---
title: Gestire tag e dati personalizzati nelle presentazioni usando PHP
linktitle: Tag e dati personalizzati
type: docs
weight: 300
url: /it/php-java/managing-tags-and-custom-data/
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
- PHP
- Aspose.Slides
description: "Scopri come gestire tag e dati XML personalizzati nelle presentazioni PowerPoint con Aspose.Slides per PHP via Java, inclusa l'aggiunta, lettura, aggiornamento, verifica e rimozione delle parti XML personalizzate."
---
## **Panoramica**

Questo articolo spiega come Aspose.Slides gestisce tag e dati personalizzati nelle presentazioni PowerPoint. I dati specifici della presentazione possono essere archiviati come tag o parti XML personalizzate. I tag sono semplici coppie chiave‑valore di stringa, mentre le parti XML personalizzate possono memorizzare metadati strutturati e payload XML specifici dell'applicazione.

Aspose.Slides fornisce API per aggiungere, leggere, aggiornare, verificare e rimuovere parti XML personalizzate a livello di presentazione, diapositiva e forma. Le parti XML personalizzate sono utili per integrazioni che memorizzano informazioni come identificatori di gestione documenti, stato del flusso di lavoro, metadati di conformità, dati di collegamento a modelli o altri dati applicativi strutturati all'interno di una presentazione.

## **Memorizzazione dei dati nei file di presentazione**

I file PPTX — file con estensione `.pptx` — sono salvati nel formato PresentationML, che fa parte della specifica Office Open XML. Office Open XML definisce la struttura del pacchetto e le relazioni usate per memorizzare il contenuto della presentazione e i dati correlati.

Una presentazione contiene più parti collegate da relazioni. Per esempio, una parte diapositiva contiene il contenuto di una singola diapositiva e può avere relazioni esplicite con altre parti definite da ISO/IEC 29500.

I dati personalizzati possono essere memorizzati come tag ([TagCollection](https://reference.aspose.com/slides/it/php-java/aspose.slides/tagcollection/)) o parti XML personalizzate ([CustomXmlPartCollection](https://reference.aspose.com/slides/it/php-java/aspose.slides/customxmlpartcollection/)). Entrambi sono disponibili tramite la classe [`CustomData`](https://reference.aspose.com/slides/it/php-java/aspose.slides/customdata/).

{{% alert color="primary" %}}
I tag memorizzano semplici coppie chiave‑valore di stringa. Le parti XML personalizzate memorizzano dati XML strutturati e possono essere associate a una presentazione, a una diapositiva o a una forma.
{{% /alert %}}

## **Lavorare con le parti XML personalizzate**

Il metodo [`CustomData::getCustomXmlParts()`](https://reference.aspose.com/slides/it/php-java/aspose.slides/customdata/#getCustomXmlParts) restituisce la raccolta di parti XML personalizzate associate a un determinato oggetto di presentazione. Per esempio:

- `$presentation->getCustomData()->getCustomXmlParts()` contiene le parti XML personalizzate associate alla presentazione stessa.
- `$slide->getCustomData()->getCustomXmlParts()` contiene le parti XML personalizzate associate a una specifica diapositiva.
- `$shape->getCustomData()->getCustomXmlParts()` contiene le parti XML personalizzate associate a una specifica forma.

Usa [`Presentation::getAllCustomXmlParts()`](https://reference.aspose.com/slides/it/php-java/aspose.slides/presentation/#getAllCustomXmlParts) quando devi ispezionare tutte le parti XML personalizzate nella presentazione, indipendentemente da dove siano associate.

### **Aggiungere una parte XML personalizzata a una presentazione**

Usa [`CustomXmlPartCollection::add`](https://reference.aspose.com/slides/it/php-java/aspose.slides/customxmlpartcollection/#add) per aggiungere dati XML a una raccolta di parti XML personalizzate. L'XML deve essere valido e non vuoto.

L'esempio seguente aggiunge metadati strutturati alla raccolta di dati personalizzati a livello di presentazione:

```php
$customXmlContent =
    '<?xml version="1.0" encoding="UTF-8"?>' .
    '<metadata xmlns="urn:example:metadata">' .
        '<documentId>DOC-1001</documentId>' .
        '<workflowState>Draft</workflowState>' .
    '</metadata>';

$presentation = new Presentation();
try {
    $customXmlPart = $presentation->getCustomData()->getCustomXmlParts()->add($customXmlContent);

    // add assegna un identificatore automaticamente. Imposta un UUID specifico solo quando necessario.
    $UUID = new JavaClass("java.util.UUID");
    $customXmlPart->setItemId($UUID->randomUUID());

    $presentation->save("presentation_with_custom_xml.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Il metodo `add` può anche accettare XML come array di byte o stream di input, il che è utile quando il contenuto XML è già disponibile in forma binaria.

### **Aggiungere una parte XML personalizzata a una diapositiva o a una forma**

I dati XML personalizzati possono essere associati a una specifica diapositiva o forma invece che all'intera presentazione. Questo è utile quando i metadati descrivono solo un oggetto, ad esempio una chiave di modello, un identificatore di record esterno o informazioni di binding.

L'esempio seguente aggiunge una parte XML personalizzata a una diapositiva e un'altra a una forma:

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $slide->getCustomData()->getCustomXmlParts()->add(
        '<slideMetadata xmlns="urn:example:slides">' .
            '<templateKey>TitleSlide</templateKey>' .
        '</slideMetadata>'
    );

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 250, 80);

    $shape->getTextFrame()->setText("Customer data");
    $shape->getCustomData()->getCustomXmlParts()->add(
        '<shapeMetadata xmlns="urn:example:shapes">' .
            '<recordId>CRM-4281</recordId>' .
        '</shapeMetadata>'
    );

    $presentation->save("object_custom_xml.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Il livello al quale viene aggiunta una parte determina quale raccolta `getCustomData()->getCustomXmlParts()` dell'oggetto contiene la relazione a quella parte. I dati a livello di presentazione sono appropriati per metadati a livello di documento, i dati a livello di diapositiva per informazioni che appartengono a una specifica diapositiva e i dati a livello di forma per metadati collegati a una singola forma.

### **Elencare e verificare tutte le parti XML personalizzate**

Usa [`Presentation::getAllCustomXmlParts()`](https://reference.aspose.com/slides/it/php-java/aspose.slides/presentation/#getAllCustomXmlParts) per recuperare tutte le parti XML personalizzate da una presentazione. Ogni [`CustomXmlPart`](https://reference.aspose.com/slides/it/php-java/aspose.slides/customxmlpart/) espone il proprio identificatore, il contenuto XML e gli schemi di namespace associati.

L'esempio seguente elenca tutte le parti XML personalizzate e i loro schemi di namespace:

```php
$presentation = new Presentation("presentation.pptx");
try {
    foreach ($presentation->getAllCustomXmlParts() as $customXmlPart) {
        echo "ItemId: " . $customXmlPart->getItemId() . PHP_EOL;
        echo "XML:" . PHP_EOL;
        echo $customXmlPart->getXmlAsString() . PHP_EOL;

        foreach ($customXmlPart->getNamespaceSchemas() as $namespaceSchema) {
            echo "Namespace schema: " . $namespaceSchema . PHP_EOL;
        }

        echo PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

[`CustomXmlPart::getNamespaceSchemas()`](https://reference.aspose.com/slides/it/php-java/aspose.slides/customxmlpart/#getNamespaceSchemas) restituisce gli schemi XML associati alla parte XML personalizzata. queste informazioni possono essere utili durante la verifica di presentazioni che contengono XML prodotto da sistemi esterni.

### **Leggere e aggiornare il contenuto XML e l'ItemId**

Usa [`CustomXmlPart::getXmlAsString()`](https://reference.aspose.com/slides/it/php-java/aspose.slides/customxmlpart/#getXmlAsString) e [`setXmlAsString()`](https://reference.aspose.com/slides/it/php-java/aspose.slides/customxmlpart/#setXmlAsString) per lavorare con XML come stringa UTF‑8, oppure [`getXmlData()`](https://reference.aspose.com/slides/it/php-java/aspose.slides/customxmlpart/#getXmlData) e [`setXmlData()`](https://reference.aspose.com/slides/it/php-java/aspose.slides/customxmlpart/#setXmlData) per lavorare con i byte XML grezzi.

Il metodo [`CustomXmlPart::getItemId()`](https://reference.aspose.com/slides/it/php-java/aspose.slides/customxmlpart/#getItemId) restituisce l'UUID che identifica la parte XML personalizzata nel documento Office Open XML. Usa [`setItemId()`](https://reference.aspose.com/slides/it/php-java/aspose.slides/customxmlpart/#setItemId) quando un'integrazione richiede un nuovo identificatore.

L'esempio seguente aggiorna il contenuto XML e l'identificatore:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $customXmlPart = $presentation->getAllCustomXmlParts()[0];

    // Leggi l'XML corrente come testo.
    $currentXmlContent = $customXmlPart->getXmlAsString();
    echo $currentXmlContent . PHP_EOL;

    // Aggiorna l'XML come stringa UTF-8.
    $customXmlPart->setXmlAsString(
        '<metadata xmlns="urn:example:metadata">' .
            '<documentId>DOC-1001</documentId>' .
            '<workflowState>Approved</workflowState>' .
        '</metadata>'
    );

    // getXmlData fornisce lo stesso contenuto XML come byte grezzi.
    $customXmlData = $customXmlPart->getXmlData();

    // Sostituisci l'identificatore quando richiesto dall'integrazione.
    $UUID = new JavaClass("java.util.UUID");
    $customXmlPart->setItemId($UUID->randomUUID());

    $presentation->save("updated_custom_xml.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Quando chiami `setXmlAsString` o `setXmlData`, fornisci XML valido e non vuoto. Usa una rappresentazione o l'altra a seconda che l'applicazione lavori principalmente con stringhe o con dati binari.

### **Rimuovere una parte XML personalizzata**

Aspose.Slides offre diversi modi per rimuovere dati XML personalizzati:

- [`CustomXmlPart::remove`](https://reference.aspose.com/slides/it/php-java/aspose.slides/customxmlpart/#remove) rimuove la parte XML personalizzata dalla presentazione.
- [`CustomXmlPartCollection::remove`](https://reference.aspose.com/slides/it/php-java/aspose.slides/customxmlpartcollection/#remove) rimuove una parte specifica da una raccolta di parti XML personalizzate.
- [`CustomXmlPartCollection::removeAt`](https://reference.aspose.com/slides/it/php-java/aspose.slides/customxmlpartcollection/#removeAt) rimuove la parte all'indice specificato della raccolta.
- [`CustomXmlPartCollection::clear`](https://reference.aspose.com/slides/it/php-java/aspose.slides/customxmlpartcollection/#clear) rimuove tutte le parti da una raccolta specifica.

L'esempio seguente rimuove una parte XML personalizzata a livello di presentazione per riferimento:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $customXmlParts = $presentation->getCustomData()->getCustomXmlParts();

    if (java_values($customXmlParts->size()) > 0) {
        $customXmlPart = $customXmlParts->get_Item(0);
        $customXmlParts->remove($customXmlPart);
    }

    $presentation->save("custom_xml_removed.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Se disponi già di un `CustomXmlPart` e vuoi rimuovere quella parte dalla presentazione anziché da una collezione particolare, chiama `$customXmlPart->remove()`.

Puoi anche rimuovere un elemento per indice:

```php
$presentation->getCustomData()->getCustomXmlParts()->removeAt(0);
```

### **Cancellare tutte le parti XML personalizzate da una raccolta**

Usa `clear` quando tutte le parti XML personalizzate associate a un determinato oggetto di presentazione devono essere rimosse.

```php
$presentation = new Presentation("presentation.pptx");
try {
    $presentation->getSlides()->get_Item(0)->getCustomData()->getCustomXmlParts()->clear();

    $presentation->save("slide_custom_xml_cleared.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

`clear` influisce solo sulla raccolta selezionata. Per esempio, cancellare la raccolta di una diapositiva non cancella quelle a livello di presentazione o di forma.

Per rimuovere ogni parte XML personalizzata nella presentazione, itera su `getAllCustomXmlParts()` e rimuovi ciascuna parte:

```php
$presentation = new Presentation("presentation.pptx");
try {
    foreach ($presentation->getAllCustomXmlParts() as $customXmlPart) {
        $customXmlPart->remove();
    }

    $presentation->save("all_custom_xml_removed.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **Gestire parti XML personalizzate collegate o condivise**

In una presentazione Office Open XML, la stessa parte XML personalizzata può essere referenziata da più oggetti della presentazione. Per esempio, un file esistente può contenere relazioni da più diapositive o forme alla stessa parte XML sottostante.

Una parte condivisa dovrebbe essere trattata come un unico oggetto di dati con più riferimenti:

- Aggiornandola con `setXmlAsString`, `setXmlData` o `setItemId` si modifica la parte XML sottostante, quindi la modifica si applica ovunque quella parte sia referenziata.
- `getItemId()` può essere usato per identificare la stessa parte XML durante la verifica delle raccolte a livello di oggetto.
- Rimuovere una parte da una specifica raccolta `getCustomXmlParts()` la elimina solo da quella raccolta. Usa `CustomXmlPart::remove()` quando la parte stessa deve essere rimossa dalla presentazione.
- Prima di eliminare o sostituire una parte condivisa, ispeziona le raccolte a livello di oggetto per determinare se altre diapositive o forme la referenziano ancora.

Le overload di `add` creano una nuova parte XML personalizzata dal contenuto XML; non accettano un `CustomXmlPart` esistente. Pertanto, le relazioni condivise si incontrano più spesso quando si caricano presentazioni che le contengono già.

L'esempio seguente verifica le raccolte a livello di presentazione, diapositiva e forma per `ItemId` e segnala le parti referenziate da più di un luogo:

```php
function registerCustomXmlParts($ownerName, $customXmlParts, &$referencesByItemId) {
    $partCount = java_values($customXmlParts->size());

    for ($i = 0; $i < $partCount; $i++) {
        $customXmlPart = $customXmlParts->get_Item($i);
        $itemId = java_values($customXmlPart->getItemId()->toString());

        if (!isset($referencesByItemId[$itemId])) {
            $referencesByItemId[$itemId] = [];
        }

        $referencesByItemId[$itemId][] = $ownerName;
    }
}

$presentation = new Presentation("presentation.pptx");
try {
    $referencesByItemId = [];

    registerCustomXmlParts(
        "Presentation",
        $presentation->getCustomData()->getCustomXmlParts(),
        $referencesByItemId
    );

    $slideCount = java_values($presentation->getSlides()->size());
    for ($slideIndex = 0; $slideIndex < $slideCount; $slideIndex++) {
        $slide = $presentation->getSlides()->get_Item($slideIndex);
        registerCustomXmlParts(
            "Slide " . ($slideIndex + 1),
            $slide->getCustomData()->getCustomXmlParts(),
            $referencesByItemId
        );

        $shapeCount = java_values($slide->getShapes()->size());
        for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
            $shape = $slide->getShapes()->get_Item($shapeIndex);
            registerCustomXmlParts(
                "Slide " . ($slideIndex + 1) . ", shape " . $shapeIndex,
                $shape->getCustomData()->getCustomXmlParts(),
                $referencesByItemId
            );
        }
    }

    foreach ($referencesByItemId as $itemId => $owners) {
        if (count($owners) > 1) {
            echo "Shared custom XML part: " . $itemId . PHP_EOL;

            foreach ($owners as $ownerName) {
                echo "  Referenced by: " . $ownerName . PHP_EOL;
            }
        }
    }
} finally {
    $presentation->dispose();
}
```

Questo tipo di verifica è utile prima di modificare o eliminare dati XML personalizzati in presentazioni create da sistemi esterni, poiché la stessa parte di metadati può partecipare a più relazioni.

## **Ottenere i valori dei tag**

In Slides, un tag corrisponde al metodo `DocumentProperties::getKeywords()`. Questo esempio di codice mostra come ottenere il valore di un tag con Aspose.Slides per PHP via Java per [Presentation](https://reference.aspose.com/slides/it/php-java/aspose.slides/presentation/):

```php
$presentation = new Presentation("presentation.pptx");
try {
    $keywords = $presentation->getDocumentProperties()->getKeywords();
} finally {
    $presentation->dispose();
}
```

## **Aggiungere tag alle presentazioni**

Aspose.Slides consente di aggiungere tag alle presentazioni. Un tag tipicamente è composto da due elementi:

- il nome di una proprietà personalizzata, ad esempio `MyTag`;
- il valore della proprietà personalizzata, ad esempio `My Tag Value`.

Se devi classificare le presentazioni in base a una regola o proprietà specifica, puoi aggiungere tag a tale scopo. Per esempio, per categorizzare le presentazioni provenienti dai paesi del Nord America, puoi creare un tag “NorthAmerican” e assegnare il paese rilevante come valore.

Questo esempio di codice mostra come aggiungere un tag a una [Presentation](https://reference.aspose.com/slides/it/php-java/aspose.slides/presentation/) usando Aspose.Slides per PHP via Java:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $tags = $presentation->getCustomData()->getTags();
    $tags->set_Item("MyTag", "My Tag Value");
} finally {
    $presentation->dispose();
}
```

I tag possono essere impostati anche per una [Slide](https://reference.aspose.com/slides/it/php-java/aspose.slides/slide/):

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $slide->getCustomData()->getTags()->set_Item("tag", "value");
} finally {
    $presentation->dispose();
}
```

Oppure per una singola [Shape](https://reference.aspose.com/slides/it/php-java/aspose.slides/autoshape/):

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 10, 100, 50);
    $shape->getTextFrame()->setText("My text");
    $shape->getCustomData()->getTags()->set_Item("tag", "value");
} finally {
    $presentation->dispose();
}
```

### **Limitazioni**

I tag aggiunti tramite la collezione `getCustomData()->getTags()` sono memorizzati solo nel file PowerPoint. **Non** vengono trasferiti nella struttura dei tag PDF quando la presentazione viene esportata in PDF. Di conseguenza, un identificatore personalizzato assegnato come tag non può essere recuperato dal PDF taggato.

**Soluzione alternativa**: è possibile memorizzare un identificatore personalizzato nel **Testo alternativo** dell'oggetto (ad esempio, `$shape->setAlternativeText("MyId")`). Dopo l’esportazione in PDF, il Testo alternativo può apparire nella struttura dei tag PDF.

## **FAQ**

**Posso rimuovere tutti i tag da una presentazione, diapositiva o forma in un’unica operazione?**

Sì. La [collezione di tag](https://reference.aspose.com/slides/it/php-java/aspose.slides/tagcollection/) supporta un'operazione [clear](https://reference.aspose.com/slides/it/php-java/aspose.slides/tagcollection/#clear) che elimina tutte le coppie chiave‑valore in una volta.

**Come elimino un singolo tag dal suo nome senza iterare sull’intera collezione?**

Usa [remove(name)](https://reference.aspose.com/slides/it/php-java/aspose.slides/tagcollection/#remove) sulla [collezione di tag](https://reference.aspose.com/slides/it/php-java/aspose.slides/tagcollection/) per cancellare il tag per chiave.

**Come posso recuperare l’elenco completo dei nomi dei tag per analisi o filtraggio?**

Usa [getNamesOfTags](https://reference.aspose.com/slides/it/php-java/aspose.slides/tagcollection/#getNamesOfTags) sulla [collezione di tag](https://reference.aspose.com/slides/it/php-java/aspose.slides/tagcollection/); restituisce un array con tutti i nomi dei tag.

**Come posso trovare tutte le parti XML personalizzate indipendentemente da dove siano archiviate?**

Usa [`Presentation::getAllCustomXmlParts()`](https://reference.aspose.com/slides/it/php-java/aspose.slides/presentation/#getAllCustomXmlParts) per recuperare tutte le parti XML personalizzate nella presentazione.

**Devo usare `getXmlAsString`/`setXmlAsString` o `getXmlData`/`setXmlData` per aggiornare una parte XML personalizzata?**

Usa `getXmlAsString` e `setXmlAsString` quando l’applicazione lavora con testo XML UTF‑8. Usa `getXmlData` e `setXmlData` quando l’XML è già disponibile come array di byte o quando è più comodo un'elaborazione orientata ai dati binari. Entrambe le rappresentazioni si riferiscono al contenuto XML della stessa parte XML personalizzata.