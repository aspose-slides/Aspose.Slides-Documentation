---
title: Gestisci tag e dati personalizzati nelle presentazioni con Python
linktitle: Tag e dati personalizzati
type: docs
weight: 300
url: /it/python-net/managing-tags-and-custom-data/
keywords:
- proprietà del documento
- tag
- dati personalizzati
- XML personalizzato
- parte XML personalizzata
- metadati XML
- ItemId
- aggiungi tag
- valori di coppia
- PowerPoint
- presentazione
- Python
- Aspose.Slides
description: "Scopri come gestire tag e dati XML personalizzati nelle presentazioni PowerPoint con Aspose.Slides per Python via .NET, inclusa l'aggiunta, lettura, aggiornamento, audit e rimozione di parti XML personalizzate."
---
## **Panoramica**

Questo articolo spiega come Aspose.Slides gestisce tag e dati personalizzati nelle presentazioni PowerPoint. I dati specifici di una presentazione possono essere archiviati come tag o parti XML personalizzate. I tag sono semplici coppie chiave‑valore di stringa, mentre le parti XML personalizzate possono memorizzare metadati strutturati e payload XML specifici dell’applicazione.

Aspose.Slides fornisce API per aggiungere, leggere, aggiornare, eseguire audit e rimuovere parti XML personalizzate a livello di presentazione, diapositiva e forma. Le parti XML personalizzate sono utili per integrazioni che memorizzano informazioni come identificatori di gestione documentale, stato del flusso di lavoro, metadati di conformità, dati di associazione a modelli o altri dati applicativi strutturati all’interno di una presentazione.

## **Memorizzazione dei dati nei file di presentazione**

I file PPTX — file con estensione `.pptx` — sono archiviati nel formato PresentationML, parte della specifica Office Open XML. Office Open XML definisce la struttura del pacchetto e le relazioni usate per memorizzare il contenuto della presentazione e i dati correlati.

Una presentazione contiene più parti collegate tra loro da relazioni. Per esempio, una parte diapositiva contiene il contenuto di una singola diapositiva e può avere relazioni esplicite verso altre parti definite da ISO/IEC 29500.

I dati personalizzati possono essere memorizzati come tag ([TagCollection](https://reference.aspose.com/slides/it/python-net/aspose.slides/tagcollection/)) o parti XML personalizzate ([CustomXmlPartCollection](https://reference.aspose.com/slides/it/python-net/aspose.slides/customxmlpartcollection/)). Entrambi sono disponibili tramite la classe [`CustomData`](https://reference.aspose.com/slides/it/python-net/aspose.slides/customdata/).

{{% alert color="primary" %}}
I tag memorizzano semplici coppie chiave‑valore di stringa. Le parti XML personalizzate memorizzano dati XML strutturati e possono essere associate a una presentazione, a una diapositiva o a una forma.
{{% /alert %}}

## **Lavorare con le parti XML personalizzate**

La proprietà [`CustomData.custom_xml_parts`](https://reference.aspose.com/slides/it/python-net/aspose.slides/customdata/custom_xml_parts/) restituisce la collezione delle parti XML personalizzate associate a un determinato oggetto di presentazione. Per esempio:

- `presentation.custom_data.custom_xml_parts` contiene le parti XML personalizzate associate alla presentazione stessa.
- `slide.custom_data.custom_xml_parts` contiene le parti XML personalizzate associate a una diapositiva specifica.
- `shape.custom_data.custom_xml_parts` contiene le parti XML personalizzate associate a una forma specifica.

Usa [`Presentation.all_custom_xml_parts`](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentation/all_custom_xml_parts/) quando devi ispezionare tutte le parti XML personalizzate nella presentazione, indipendentemente da dove siano associate.

### **Aggiungere una parte XML personalizzata a una presentazione**

Usa [`CustomXmlPartCollection.add`](https://reference.aspose.com/slides/it/python-net/aspose.slides/customxmlpartcollection/add/) per aggiungere dati XML a una collezione di parti XML personalizzate. L’XML deve essere valido e non vuoto.

L’esempio seguente aggiunge metadati strutturati alla collezione di dati personalizzati a livello di presentazione:

```py
import uuid
import aspose.slides as slides

custom_xml_content = (
    '<?xml version="1.0" encoding="UTF-8"?>'
    '<metadata xmlns="urn:example:metadata">'
    '<documentId>DOC-1001</documentId>'
    '<workflowState>Draft</workflowState>'
    '</metadata>'
)

with slides.Presentation() as presentation:
    custom_xml_part = presentation.custom_data.custom_xml_parts.add(custom_xml_content)

    # add assegna automaticamente un identificatore. Imposta un GUID specifico solo quando necessario.
    custom_xml_part.item_id = uuid.uuid4()

    presentation.save("presentation_with_custom_xml.pptx", slides.export.SaveFormat.PPTX)
```

Il metodo `add` può anche accettare XML come array di byte o stream, utile quando il contenuto XML è già disponibile in forma binaria.

### **Aggiungere una parte XML personalizzata a una diapositiva o a una forma**

I dati XML personalizzati possono essere associati a una diapositiva o a una forma specifica invece che all’intera presentazione. Questo è utile quando i metadati descrivono un solo oggetto, ad esempio una chiave di modello, un identificatore di record esterno o informazioni di binding.

L’esempio seguente aggiunge una parte XML personalizzata a una diapositiva e un’altra a una forma:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    slide.custom_data.custom_xml_parts.add(
        '<slideMetadata xmlns="urn:example:slides">'
        '<templateKey>TitleSlide</templateKey>'
        '</slideMetadata>'
    )

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 250, 80)

    shape.text_frame.text = "Customer data"
    shape.custom_data.custom_xml_parts.add(
        '<shapeMetadata xmlns="urn:example:shapes">'
        '<recordId>CRM-4281</recordId>'
        '</shapeMetadata>'
    )

    presentation.save("object_custom_xml.pptx", slides.export.SaveFormat.PPTX)
```

Il livello al quale viene aggiunta una parte determina quale collezione `custom_data.custom_xml_parts` dell’oggetto contiene la relazione a quella parte. I dati a livello di presentazione sono appropriati per metadati a livello di documento, i dati a livello di diapositiva per informazioni appartenenti a una specifica diapositiva e i dati a livello di forma per metadati legati a una singola forma.

### **Elencare e verificare tutte le parti XML personalizzate**

Usa [`Presentation.all_custom_xml_parts`](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentation/all_custom_xml_parts/) per recuperare tutte le parti XML personalizzate da una presentazione. Ogni [`CustomXmlPart`](https://reference.aspose.com/slides/it/python-net/aspose.slides/customxmlpart/) espone il proprio identificatore, il contenuto XML e gli schemi di namespace associati.

L’esempio seguente elenca tutte le parti XML personalizzate e i loro schemi di namespace:

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    for custom_xml_part in presentation.all_custom_xml_parts:
        print("ItemId: " + str(custom_xml_part.item_id))
        print("XML:")
        print(custom_xml_part.xml_as_string)

        for namespace_schema in custom_xml_part.namespace_schemas:
            print("Namespace schema: " + namespace_schema)

        print()
```

[`CustomXmlPart.namespace_schemas`](https://reference.aspose.com/slides/it/python-net/aspose.slides/customxmlpart/namespace_schemas/) restituisce gli schemi XML associati alla parte XML personalizzata. Queste informazioni possono essere utili quando si esegue l’audit di presentazioni contenenti XML prodotto da sistemi esterni.

### **Leggere e aggiornare il contenuto XML e ItemId**

Usa [`CustomXmlPart.xml_as_string`](https://reference.aspose.com/slides/it/python-net/aspose.slides/customxmlpart/xml_as_string/) per lavorare con l’XML come stringa UTF‑8, o [`CustomXmlPart.xml_data`](https://reference.aspose.com/slides/it/python-net/aspose.slides/customxmlpart/xml_data/) per gestire i byte XML grezzi. Entrambe le proprietà possono essere lette e aggiornate.

La proprietà [`CustomXmlPart.item_id`](https://reference.aspose.com/slides/it/python-net/aspose.slides/customxmlpart/item_id/) contiene il GUID che identifica la parte XML personalizzata nel documento Office Open XML. Può anche essere modificato quando un’integrazione richiede un nuovo identificatore.

L’esempio seguente aggiorna il contenuto XML e l’identificatore:

```py
import uuid
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    custom_xml_part = presentation.all_custom_xml_parts[0]

    # Leggi l'XML corrente come testo.
    current_xml_content = custom_xml_part.xml_as_string
    print(current_xml_content)

    # Aggiorna l'XML come stringa UTF-8.
    custom_xml_part.xml_as_string = (
        '<metadata xmlns="urn:example:metadata">'
        '<documentId>DOC-1001</documentId>'
        '<workflowState>Approved</workflowState>'
        '</metadata>'
    )

    # xml_data fornisce lo stesso contenuto XML come byte grezzi.
    custom_xml_data = custom_xml_part.xml_data
    print(custom_xml_data.decode("utf-8"))

    # Sostituisci l'identificatore quando richiesto dall'integrazione.
    custom_xml_part.item_id = uuid.uuid4()

    presentation.save("updated_custom_xml.pptx", slides.export.SaveFormat.PPTX)
```

Quando assegni `xml_as_string` o `xml_data`, fornisci XML valido e non vuoto. Usa una rappresentazione o l’altra a seconda che l’applicazione lavori principalmente con stringhe o con dati binari.

### **Rimuovere una parte XML personalizzata**

Aspose.Slides offre diversi modi per rimuovere dati XML personalizzati:

- [`CustomXmlPart.remove`](https://reference.aspose.com/slides/it/python-net/aspose.slides/customxmlpart/remove/) rimuove la parte XML personalizzata dalla presentazione.
- [`CustomXmlPartCollection.remove`](https://reference.aspose.com/slides/it/python-net/aspose.slides/customxmlpartcollection/remove/) rimuove una parte specifica da una collezione di parti XML personalizzate.
- [`CustomXmlPartCollection.remove_at`](https://reference.aspose.com/slides/it/python-net/aspose.slides/customxmlpartcollection/remove_at/) rimuove la parte all’indice specificato della collezione.
- [`CustomXmlPartCollection.clear`](https://reference.aspose.com/slides/it/python-net/aspose.slides/customxmlpartcollection/clear/) elimina tutte le parti da una collezione specifica.

L’esempio seguente rimuove una parte XML personalizzata a livello di presentazione tramite riferimento:

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    custom_xml_parts = presentation.custom_data.custom_xml_parts

    if len(custom_xml_parts) > 0:
        custom_xml_part = custom_xml_parts[0]
        custom_xml_parts.remove(custom_xml_part)

    presentation.save("custom_xml_removed.pptx", slides.export.SaveFormat.PPTX)
```

Se disponi già di un `CustomXmlPart` e desideri rimuovere quella parte dalla presentazione anziché da una collezione specifica, chiama `custom_xml_part.remove()`.

Puoi anche rimuovere un elemento per indice:

```py
presentation.custom_data.custom_xml_parts.remove_at(0)
```

### **Cancellare tutte le parti XML personalizzate da una collezione**

Usa `clear` quando tutte le parti XML personalizzate associate a un determinato oggetto di presentazione devono essere rimosse.

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    presentation.slides[0].custom_data.custom_xml_parts.clear()

    presentation.save("slide_custom_xml_cleared.pptx", slides.export.SaveFormat.PPTX)
```

`clear` influisce solo sulla collezione selezionata. Per esempio, cancellare la collezione di una diapositiva non rimuove quelle a livello di presentazione o di forma.

Per rimuovere ogni parte XML personalizzata nella presentazione, itera su `all_custom_xml_parts` e rimuovi ciascuna parte:

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    for custom_xml_part in presentation.all_custom_xml_parts:
        custom_xml_part.remove()

    presentation.save("all_custom_xml_removed.pptx", slides.export.SaveFormat.PPTX)
```

### **Gestire parti XML personalizzate collegate o condivise**

In una presentazione Office Open XML, la stessa parte XML personalizzata può essere referenziata da più oggetti di presentazione. Per esempio, un file esistente può contenere relazioni da più diapositive o forme verso la stessa parte XML sottostante.

Una parte condivisa deve essere trattata come un unico oggetto dati con più riferimenti:

- Aggiornare `xml_as_string`, `xml_data` o `item_id` modifica la parte XML sottostante, quindi la modifica si applica ovunque la parte sia referenziata.
- `item_id` può essere usato per identificare la stessa parte XML durante l’audit delle collezioni a livello di oggetto.
- Rimuovere una parte da una collezione `custom_xml_parts` specifica la elimina solo da quella collezione. Usa `CustomXmlPart.remove()` quando la parte stessa deve essere rimossa dall’intera presentazione.
- Prima di eliminare o sostituire una parte condivisa, esamina le collezioni a livello di oggetto per verificare se altre diapositive o forme la riferiscono ancora.

Le overload di `add` creano una nuova parte XML personalizzata a partire dal contenuto XML; non accettano un `CustomXmlPart` esistente. Pertanto, le relazioni condivise si incontrano più frequentemente durante il caricamento di presentazioni che le contengono già.

L’esempio seguente esegue l’audit delle collezioni a livello di presentazione, diapositiva e forma tramite `item_id` e segnala le parti referenziate da più di un luogo:

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    references_by_item_id = {}

    def register_custom_xml_parts(owner_name, custom_xml_parts):
        for custom_xml_part in custom_xml_parts:
            references_by_item_id.setdefault(custom_xml_part.item_id, []).append(owner_name)

    register_custom_xml_parts("Presentation", presentation.custom_data.custom_xml_parts)

    for slide_index, slide in enumerate(presentation.slides):
        register_custom_xml_parts(
            "Slide " + str(slide_index + 1),
            slide.custom_data.custom_xml_parts
        )

        for shape_index, shape in enumerate(slide.shapes):
            register_custom_xml_parts(
                "Slide " + str(slide_index + 1) + ", shape " + str(shape_index),
                shape.custom_data.custom_xml_parts
            )

    for item_id, owner_names in references_by_item_id.items():
        if len(owner_names) > 1:
            print("Shared custom XML part: " + str(item_id))

            for owner_name in owner_names:
                print("  Referenced by: " + owner_name)
```

Questo tipo di audit è utile prima di modificare o eliminare dati XML personalizzati in presentazioni generate da sistemi esterni, poiché la stessa parte di metadati può partecipare a più relazioni.

## **Ottenere i valori dei tag**

In Slides, un tag corrisponde alla proprietà `DocumentProperties.keywords`. Questo esempio mostra come ottenere il valore di un tag con Aspose.Slides per Python via .NET per [Presentation](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentation/):

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    keywords = presentation.document_properties.keywords
```

## **Aggiungere tag alle presentazioni**

Aspose.Slides consente di aggiungere tag alle presentazioni. Un tag tipicamente è composto da due elementi:

- il nome di una proprietà personalizzata, ad esempio `MyTag`;
- il valore della proprietà personalizzata, ad esempio `My Tag Value`.

Se devi classificare le presentazioni in base a una regola o proprietà specifica, puoi aggiungere tag a tale scopo. Per esempio, per categorizzare le presentazioni dei paesi del Nord America, puoi creare un tag “NorthAmerican” e assegnare al valore il nome del paese corrispondente.

Questo esempio mostra come aggiungere un tag a una [Presentation](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentation/) utilizzando Aspose.Slides per Python via .NET:

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    tags = presentation.custom_data.tags
    tags.add("MyTag", "My Tag Value")
```

I tag possono essere impostati anche per una [Slide](https://reference.aspose.com/slides/it/python-net/aspose.slides/slide/):

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    slide.custom_data.tags.add("tag", "value")
```

Oppure per una singola [Shape](https://reference.aspose.com/slides/it/python-net/aspose.slides/shape/):

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, 100, 50)
    shape.text_frame.text = "My text"
    shape.custom_data.tags.add("tag", "value")
```

### **Limitazioni**

I tag aggiunti tramite la collezione `custom_data.tags` sono memorizzati solo nel file PowerPoint. Non vengono **trasferiti** nella struttura dei tag PDF quando la presentazione viene esportata in PDF. Di conseguenza, un identificatore personalizzato assegnato come tag non può essere recuperato dal PDF taggato.

**Soluzione alternativa**: è possibile memorizzare un identificatore personalizzato nell’**Alt Text** dell’oggetto (ad esempio, `shape.alternative_text = "MyId"`). Dopo l’esportazione in PDF, l’Alt Text può apparire nella struttura dei tag del PDF.

## **FAQ**

**Posso rimuovere tutti i tag da una presentazione, diapositiva o forma in un’unica operazione?**

Sì. La [tag collection](https://reference.aspose.com/slides/it/python-net/aspose.slides/tagcollection/) supporta l’operazione [clear](https://reference.aspose.com/slides/it/python-net/aspose.slides/tagcollection/clear/) che elimina tutte le coppie chiave‑valore in una volta.

**Come posso eliminare un singolo tag per nome senza iterare sull’intera collezione?**

Usa [remove(name)](https://reference.aspose.com/slides/it/python-net/aspose.slides/tagcollection/remove/) su [TagCollection](https://reference.aspose.com/slides/it/python-net/aspose.slides/tagcollection/) per cancellare il tag tramite la sua chiave.

**Come posso recuperare l’elenco completo dei nomi dei tag per analisi o filtraggio?**

Usa [get_names_of_tags](https://reference.aspose.com/slides/it/python-net/aspose.slides/tagcollection/get_names_of_tags/) sulla [tag collection](https://reference.aspose.com/slides/it/python-net/aspose.slides/tagcollection/); restituisce un array con tutti i nomi dei tag.

**Come posso trovare tutte le parti XML personalizzate indipendentemente da dove siano archiviate?**

Usa [`Presentation.all_custom_xml_parts`](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentation/all_custom_xml_parts/) per recuperare tutte le parti XML personalizzate nella presentazione.

**Devo usare `xml_as_string` o `xml_data` per aggiornare una parte XML personalizzata?**

Usa `xml_as_string` quando l’applicazione lavora con testo XML UTF‑8. Usa `xml_data` quando l’XML è già disponibile come array di byte o quando è più comodo un’elaborazione basata su dati binari. Entrambe le proprietà rappresentano il contenuto XML della stessa parte XML personalizzata.