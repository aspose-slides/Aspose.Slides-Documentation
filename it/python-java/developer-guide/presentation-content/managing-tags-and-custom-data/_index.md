---
title: Gestire tag e dati personalizzati nelle presentazioni usando Python
linktitle: Tag e dati personalizzati
type: docs
weight: 300
url: /it/python-java/managing-tags-and-custom-data/
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
- Python
- Aspose.Slides
description: "Scopri come gestire tag e dati XML personalizzati nelle presentazioni PowerPoint con Aspose.Slides per Python via Java, includendo l'aggiunta, la lettura, l'aggiornamento, la verifica e la rimozione delle parti XML personalizzate."
---
## **Panoramica**

Questo articolo spiega come Aspose.Slides gestisce i tag e i dati personalizzati nelle presentazioni PowerPoint. I dati specifici di una presentazione possono essere archiviati come tag o come parti XML personalizzate. I tag sono semplici coppie chiave-valore di tipo stringa, mentre le parti XML personalizzate possono contenere metadati strutturati e payload XML specifici dell’applicazione.

Aspose.Slides fornisce API per aggiungere, leggere, aggiornare, verificare e rimuovere parti XML personalizzate a livello di presentazione, diapositiva e forma. Le parti XML personalizzate sono utili per integrazioni che memorizzano informazioni come identificatori di gestione documenti, stato di flusso di lavoro, metadati di conformità, dati di collegamento a modello o altri dati strutturati dell’applicazione all’interno di una presentazione.

## **Archiviazione dei dati nei file di presentazione**

I file PPTX — file con estensione `.pptx` — sono memorizzati nel formato PresentationML, che fa parte della specifica Office Open XML. Office Open XML definisce la struttura del pacchetto e le relazioni utilizzate per archiviare il contenuto della presentazione e i dati correlati.

Una presentazione contiene più parti collegate tra loro mediante relazioni. Ad esempio, una parte diapositiva contiene il contenuto di una singola diapositiva e può avere relazioni esplicite con altre parti definite da ISO/IEC 29500.

I dati personalizzati possono essere memorizzati come tag ([TagCollection](https://reference.aspose.com/slides/it/python-java/aspose.slides/tagcollection/)) o come parti XML personalizzate ([CustomXmlPartCollection](https://reference.aspose.com/slides/it/python-java/aspose.slides/customxmlpartcollection/)). Entrambi sono disponibili tramite la classe [CustomData](https://reference.aspose.com/slides/it/python-java/aspose.slides/customdata/).

{{% alert color="info" title="Note" %}}
I tag memorizzano semplici coppie chiave‑valore di tipo stringa. Le parti XML personalizzate memorizzano dati XML strutturati e possono essere associate a una presentazione, a una diapositiva o a una forma.
{{% /alert %}}

## **Lavorare con le parti XML personalizzate**

Il metodo [CustomData.getCustomXmlParts](https://reference.aspose.com/slides/it/python-java/aspose.slides/customdata/#getCustomXmlParts) restituisce la raccolta di parti XML personalizzate associate a un determinato oggetto della presentazione. Per esempio:

- La raccolta [CustomData.getCustomXmlParts](https://reference.aspose.com/slides/it/python-java/aspose.slides/customdata/#getCustomXmlParts) della presentazione contiene le parti XML personalizzate associate alla presentazione stessa.
- La raccolta [CustomData.getCustomXmlParts](https://reference.aspose.com/slides/it/python-java/aspose.slides/customdata/#getCustomXmlParts) della diapositiva contiene le parti XML personalizzate associate a una diapositiva specifica.
- La raccolta [CustomData.getCustomXmlParts](https://reference.aspose.com/slides/it/python-java/aspose.slides/customdata/#getCustomXmlParts) della forma contiene le parti XML personalizzate associate a una forma specifica.

Usa [Presentation.getAllCustomXmlParts](https://reference.aspose.com/slides/it/python-java/aspose.slides/presentation/#getAllCustomXmlParts) quando devi ispezionare tutte le parti XML personalizzate nella presentazione, indipendentemente da dove siano associate.

### **Aggiungere una parte XML personalizzata a una presentazione**

Usa [CustomXmlPartCollection.add](https://reference.aspose.com/slides/it/python-java/aspose.slides/customxmlpartcollection/#add) per aggiungere dati XML a una raccolta di parti XML personalizzate. L’XML deve essere valido e non vuoto.

L’esempio seguente aggiunge metadati strutturati alla raccolta di dati personalizzati a livello di presentazione:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat
from java.util import UUID

presentation = Presentation()
try:
    custom_xml_content = '<?xml version="1.0" encoding="UTF-8"?><metadata xmlns="urn:example:metadata"><documentId>DOC-1001</documentId><workflowState>Draft</workflowState></metadata>'
    custom_xml_part = presentation.getCustomData().getCustomXmlParts().add(custom_xml_content)

    # add assegna un identificatore automaticamente. Imposta un UUID specifico solo quando necessario.
    item_id = UUID.randomUUID()
    custom_xml_part.setItemId(item_id)

    presentation.save("presentation_with_custom_xml.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Il metodo [add](https://reference.aspose.com/slides/it/python-java/aspose.slides/customxmlpartcollection/#add) può inoltre accettare XML come array di byte o stream di input, utile quando il contenuto XML è già disponibile in forma binaria.

### **Aggiungere una parte XML personalizzata a una diapositiva o a una forma**

I dati XML personalizzati possono essere associati a una diapositiva o a una forma specifica invece che all’intera presentazione. Questo è utile quando i metadati descrivono un unico oggetto, ad esempio una chiave di modello, un identificatore di record esterno o informazioni di binding.

L’esempio seguente aggiunge una parte XML personalizzata a una diapositiva e un’altra a una forma:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    slide_xml_content = '<slideMetadata xmlns="urn:example:slides"><templateKey>TitleSlide</templateKey></slideMetadata>'
    slide.getCustomData().getCustomXmlParts().add(slide_xml_content)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 250, 80)
    shape.getTextFrame().setText("Customer data")
    shape_xml_content = '<shapeMetadata xmlns="urn:example:shapes"><recordId>CRM-4281</recordId></shapeMetadata>'
    shape.getCustomData().getCustomXmlParts().add(shape_xml_content)

    presentation.save("object_custom_xml.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Il livello al quale una parte viene aggiunta determina quale raccolta [CustomData.getCustomXmlParts](https://reference.aspose.com/slides/it/python-java/aspose.slides/customdata/#getCustomXmlParts) dell’oggetto contiene la relazione a quella parte. I dati a livello di presentazione sono appropriati per metadati a livello di documento, i dati a livello di diapositiva per informazioni che appartengono a una specifica diapositiva e i dati a livello di forma per metadati legati a una singola forma.

### **Elencare e verificare tutte le parti XML personalizzate**

Usa [Presentation.getAllCustomXmlParts](https://reference.aspose.com/slides/it/python-java/aspose.slides/presentation/#getAllCustomXmlParts) per recuperare tutte le parti XML personalizzate da una presentazione. Ogni [CustomXmlPart](https://reference.aspose.com/slides/it/python-java/aspose.slides/customxmlpart/) espone il proprio identificatore, il contenuto XML e gli schemi di namespace associati.

L’esempio seguente elenca tutte le parti XML personalizzate e i relativi schemi di namespace:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("presentation.pptx")
try:
    for custom_xml_part in presentation.getAllCustomXmlParts():
        print("ItemId:", custom_xml_part.getItemId())
        print("XML:")
        print(custom_xml_part.getXmlAsString())

        for namespace_schema in custom_xml_part.getNamespaceSchemas():
            print("Namespace schema:", namespace_schema)

        print()
finally:
    presentation.dispose()
```

[CustomXmlPart.getNamespaceSchemas](https://reference.aspose.com/slides/it/python-java/aspose.slides/customxmlpart/#getNamespaceSchemas) restituisce gli schemi XML associati alla parte XML personalizzata. Queste informazioni possono essere utili durante la verifica di presentazioni che contengono XML prodotto da sistemi esterni.

### **Leggere e aggiornare il contenuto XML e l’ItemId**

Usa [CustomXmlPart.getXmlAsString](https://reference.aspose.com/slides/it/python-java/aspose.slides/customxmlpart/#getXmlAsString) e [setXmlAsString](https://reference.aspose.com/slides/it/python-java/aspose.slides/customxmlpart/#setXmlAsString) per lavorare con l’XML come stringa UTF‑8, oppure [getXmlData](https://reference.aspose.com/slides/it/python-java/aspose.slides/customxmlpart/#getXmlData) e [setXmlData](https://reference.aspose.com/slides/it/python-java/aspose.slides/customxmlpart/#setXmlData) per gestire i byte XML grezzi.

Il metodo [CustomXmlPart.getItemId](https://reference.aspose.com/slides/it/python-java/aspose.slides/customxmlpart/#getItemId) restituisce l’UUID che identifica la parte XML personalizzata nel documento Office Open XML. Usa [setItemId](https://reference.aspose.com/slides/it/python-java/aspose.slides/customxmlpart/#setItemId) quando un’integrazione richiede un nuovo identificatore.

L’esempio seguente aggiorna il contenuto XML e l’identificatore:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat
from java.util import UUID

presentation = Presentation("presentation.pptx")
try:
    custom_xml_parts = presentation.getAllCustomXmlParts()
    if len(custom_xml_parts) > 0:
        custom_xml_part = custom_xml_parts[0]

        # Leggi l'XML corrente come testo.
        current_xml_content = custom_xml_part.getXmlAsString()
        print(current_xml_content)

        # Aggiorna l'XML come stringa UTF-8.
        custom_xml_content = '<metadata xmlns="urn:example:metadata"><documentId>DOC-1001</documentId><workflowState>Approved</workflowState></metadata>'
        custom_xml_part.setXmlAsString(custom_xml_content)

        # getXmlData fornisce lo stesso contenuto XML come byte grezzi.
        custom_xml_data = custom_xml_part.getXmlData()
        print(bytes(custom_xml_data).decode("utf-8"))

        # Sostituisci l'identificatore quando richiesto dall'integrazione.
        item_id = UUID.randomUUID()
        custom_xml_part.setItemId(item_id)

        presentation.save("updated_custom_xml.pptx", SaveFormat.Pptx)
    else:
        print("No custom XML parts found.")
finally:
    presentation.dispose()
```

Quando chiami [setXmlAsString](https://reference.aspose.com/slides/it/python-java/aspose.slides/customxmlpart/#setXmlAsString) o [setXmlData](https://reference.aspose.com/slides/it/python-java/aspose.slides/customxmlpart/#setXmlData), fornisci XML valido e non vuoto. Usa una rappresentazione o l’altra a seconda che l’applicazione lavori principalmente con stringhe o con dati binari.

### **Rimuovere una parte XML personalizzata**

Aspose.Slides offre diversi modi per rimuovere dati XML personalizzati:

- [CustomXmlPart.remove](https://reference.aspose.com/slides/it/python-java/aspose.slides/customxmlpart/#remove) rimuove la parte XML personalizzata dalla presentazione.
- [CustomXmlPartCollection.remove](https://reference.aspose.com/slides/it/python-java/aspose.slides/customxmlpartcollection/#remove) rimuove una parte specifica da una raccolta di parti XML personalizzate.
- [CustomXmlPartCollection.removeAt](https://reference.aspose.com/slides/it/python-java/aspose.slides/customxmlpartcollection/#removeAt) rimuove la parte all’indice specificato della raccolta.
- [CustomXmlPartCollection.clear](https://reference.aspose.com/slides/it/python-java/aspose.slides/customxmlpartcollection/#clear) rimuove tutte le parti da una raccolta specifica.

L’esempio seguente rimuove una parte XML personalizzata a livello di presentazione tramite riferimento:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    custom_xml_parts = presentation.getCustomData().getCustomXmlParts()
    if custom_xml_parts.size() > 0:
        custom_xml_part = custom_xml_parts.get_Item(0)
        custom_xml_parts.remove(custom_xml_part)

    presentation.save("custom_xml_removed.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Se disponi già di un [CustomXmlPart](https://reference.aspose.com/slides/it/python-java/aspose.slides/customxmlpart/) e desideri rimuovere quella parte dalla presentazione anziché da una raccolta specifica, chiama [CustomXmlPart.remove](https://reference.aspose.com/slides/it/python-java/aspose.slides/customxmlpart/#remove).

Puoi anche rimuovere un elemento per indice:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("presentation.pptx")
try:
    custom_xml_parts = presentation.getCustomData().getCustomXmlParts()
    if custom_xml_parts.size() > 0:
        custom_xml_parts.removeAt(0)
finally:
    presentation.dispose()
```

### **Cancellare tutte le parti XML personalizzate da una raccolta**

Usa [clear](https://reference.aspose.com/slides/it/python-java/aspose.slides/customxmlpartcollection/#clear) quando tutte le parti XML personalizzate associate a un determinato oggetto della presentazione devono essere rimosse.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    presentation.getSlides().get_Item(0).getCustomData().getCustomXmlParts().clear()

    presentation.save("slide_custom_xml_cleared.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

[clear](https://reference.aspose.com/slides/it/python-java/aspose.slides/customxmlpartcollection/#clear) influisce solo sulla raccolta selezionata. Ad esempio, cancellare la raccolta di una diapositiva non elimina quelle a livello di presentazione o di forma.

Per rimuovere ogni parte XML personalizzata nella presentazione, itera su [getAllCustomXmlParts](https://reference.aspose.com/slides/it/python-java/aspose.slides/presentation/#getAllCustomXmlParts) e rimuovi ciascuna parte:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    for custom_xml_part in presentation.getAllCustomXmlParts():
        custom_xml_part.remove()

    presentation.save("all_custom_xml_removed.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Gestire parti XML personalizzate collegate o condivise**

In una presentazione Office Open XML, la stessa parte XML personalizzata può essere referenziata da più oggetti della presentazione. Per esempio, un file esistente può contenere relazioni da più diapositive o forme verso la stessa parte XML personalizzata sottostante.

Una parte condivisa deve essere trattata come un unico oggetto dati con più riferimenti:

- Aggiornarla con [setXmlAsString](https://reference.aspose.com/slides/it/python-java/aspose.slides/customxmlpart/#setXmlAsString), [setXmlData](https://reference.aspose.com/slides/it/python-java/aspose.slides/customxmlpart/#setXmlData) o [setItemId](https://reference.aspose.com/slides/it/python-java/aspose.slides/customxmlpart/#setItemId) modifica la parte XML personalizzata sottostante, quindi la modifica si applica ovunque la parte sia referenziata.
- [getItemId](https://reference.aspose.com/slides/it/python-java/aspose.slides/customxmlpart/#getItemId) può essere usato per identificare la stessa parte XML personalizzata durante la verifica delle raccolte a livello di oggetto.
- Rimuovere una parte da una specifica raccolta [getCustomXmlParts](https://reference.aspose.com/slides/it/python-java/aspose.slides/customdata/#getCustomXmlParts) la elimina solo da quella raccolta. Usa [CustomXmlPart.remove](https://reference.aspose.com/slides/it/python-java/aspose.slides/customxmlpart/#remove) quando la parte stessa deve essere rimossa dalla presentazione.
- Prima di eliminare o sostituire una parte condivisa, verifica le raccolte a livello di oggetto per determinare se altre diapositive o forme la referenziano ancora.

Le overload del metodo [add](https://reference.aspose.com/slides/it/python-java/aspose.slides/customxmlpartcollection/#add) creano una nuova parte XML personalizzata a partire da contenuto XML; non accettano un [CustomXmlPart](https://reference.aspose.com/slides/it/python-java/aspose.slides/customxmlpart/) esistente. Perciò, le relazioni condivise si incontrano più comunemente durante il caricamento di presentazioni che le contengono già.

L’esempio seguente verifica le raccolte a livello di presentazione, diapositiva e forma per `ItemId` e segnala le parti referenziate da più di un luogo:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("presentation.pptx")
try:
    references_by_item_id = {}

    def register_custom_xml_parts(owner_name, custom_xml_parts):
        for i in range(custom_xml_parts.size()):
            custom_xml_part = custom_xml_parts.get_Item(i)
            item_id = str(custom_xml_part.getItemId())
            references_by_item_id.setdefault(item_id, []).append(owner_name)

    register_custom_xml_parts("Presentation", presentation.getCustomData().getCustomXmlParts())

    for slide_index in range(presentation.getSlides().size()):
        slide = presentation.getSlides().get_Item(slide_index)
        register_custom_xml_parts(f"Slide {slide_index + 1}", slide.getCustomData().getCustomXmlParts())

        for shape_index in range(slide.getShapes().size()):
            shape = slide.getShapes().get_Item(shape_index)
            register_custom_xml_parts(f"Slide {slide_index + 1}, shape {shape_index}", shape.getCustomData().getCustomXmlParts())

    for item_id, owner_names in references_by_item_id.items():
        if len(owner_names) > 1:
            print("Shared custom XML part:", item_id)
            for owner_name in owner_names:
                print("  Referenced by:", owner_name)
finally:
    presentation.dispose()
```

Questo tipo di verifica è utile prima di modificare o eliminare dati XML personalizzati in presentazioni generate da sistemi esterni, poiché la stessa parte di metadati può partecipare a più di una relazione.

## **Ottenere i valori dei tag**

In Slides, un tag corrisponde al metodo [DocumentProperties.getKeywords](https://reference.aspose.com/slides/it/python-java/aspose.slides/documentproperties/#getKeywords). Questo esempio mostra come ottenere il valore di un tag con Aspose.Slides per Python via Java per [Presentation](https://reference.aspose.com/slides/it/python-java/aspose.slides/presentation/):

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("presentation.pptx")
try:
    keywords = presentation.getDocumentProperties().getKeywords()
finally:
    presentation.dispose()
```

## **Aggiungere tag alle presentazioni**

Aspose.Slides consente di aggiungere tag alle presentazioni. Un tag è tipicamente composto da due elementi:

- il nome di una proprietà personalizzata, ad esempio `MyTag`;
- il valore della proprietà personalizzata, ad esempio `My Tag Value`.

Se è necessario classificare le presentazioni in base a una regola o a una proprietà specifica, è possibile aggiungere dei tag a tale scopo. Per esempio, se desideri categorizzare le presentazioni dei paesi del Nord America, puoi creare un tag “North American” e assegnare come valore il paese pertinente.

Questo esempio mostra come aggiungere un tag a una [Presentation](https://reference.aspose.com/slides/it/python-java/aspose.slides/presentation/) utilizzando Aspose.Slides per Python via Java:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("presentation.pptx")
try:
    tags = presentation.getCustomData().getTags()
    tags.set_Item("MyTag", "My Tag Value")
finally:
    presentation.dispose()
```

I tag possono essere impostati anche per una [Slide](https://reference.aspose.com/slides/it/python-java/aspose.slides/slide/):

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    slide.getCustomData().getTags().set_Item("tag", "value")
finally:
    presentation.dispose()
```

Oppure per una singola [Shape](https://reference.aspose.com/slides/it/python-java/aspose.slides/shape/):

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 100, 50)
    shape.getTextFrame().setText("My text")
    shape.getCustomData().getTags().set_Item("tag", "value")
finally:
    presentation.dispose()
```

### **Limitazioni**

I tag aggiunti tramite la raccolta [CustomData.getTags](https://reference.aspose.com/slides/it/python-java/aspose.slides/customdata/#getTags) vengono memorizzati solo nel file PowerPoint. Non vengono **trasferiti** alla struttura dei tag PDF quando la presentazione viene esportata in PDF. Di conseguenza, un identificatore personalizzato assegnato come tag non può essere recuperato dal PDF taggato.

**Soluzione alternativa**: è possibile memorizzare un identificatore personalizzato nel **Testo alternativo** dell’oggetto (ad esempio, [Shape.setAlternativeText](https://reference.aspose.com/slides/it/python-java/aspose.slides/shape/#setAlternativeText) con valore `"MyId"`). Dopo l’esportazione in PDF, il Testo alternativo può apparire nella struttura dei tag del PDF.

## **FAQ**

**Posso rimuovere tutti i tag da una presentazione, diapositiva o forma in un’unica operazione?**

Sì. La [tag collection](https://reference.aspose.com/slides/it/python-java/aspose.slides/tagcollection/) supporta l’operazione [clear](https://reference.aspose.com/slides/it/python-java/aspose.slides/tagcollection/#clear) che elimina tutte le coppie chiave‑valore in una volta.

**Come posso eliminare un singolo tag dal suo nome senza scorrere l’intera raccolta?**

Usa [remove](https://reference.aspose.com/slides/it/python-java/aspose.slides/tagcollection/#remove) sulla [tag collection](https://reference.aspose.com/slides/it/python-java/aspose.slides/tagcollection/) per cancellare il tag mediante la sua chiave.

**Come posso recuperare l’elenco completo dei nomi dei tag per analisi o filtraggio?**

Usa [getNamesOfTags](https://reference.aspose.com/slides/it/python-java/aspose.slides/tagcollection/#getNamesOfTags) sulla [tag collection](https://reference.aspose.com/slides/it/python-java/aspose.slides/tagcollection/); restituisce un array con tutti i nomi dei tag.

**Come posso trovare tutte le parti XML personalizzate indipendentemente da dove siano archiviate?**

Usa [Presentation.getAllCustomXmlParts](https://reference.aspose.com/slides/it/python-java/aspose.slides/presentation/#getAllCustomXmlParts) per recuperare tutte le parti XML personalizzate nella presentazione.

**Devo usare [getXmlAsString](https://reference.aspose.com/slides/it/python-java/aspose.slides/customxmlpart/#getXmlAsString)/[setXmlAsString](https://reference.aspose.com/slides/it/python-java/aspose.slides/customxmlpart/#setXmlAsString) o [getXmlData](https://reference.aspose.com/slides/it/python-java/aspose.slides/customxmlpart/#getXmlData)/[setXmlData](https://reference.aspose.com/slides/it/python-java/aspose.slides/customxmlpart/#setXmlData) per aggiornare una parte XML personalizzata?**

Usa [getXmlAsString](https://reference.aspose.com/slides/it/python-java/aspose.slides/customxmlpart/#getXmlAsString) e [setXmlAsString](https://reference.aspose.com/slides/it/python-java/aspose.slides/customxmlpart/#setXmlAsString) quando l’applicazione lavora con testo XML UTF‑8. Usa [getXmlData](https://reference.aspose.com/slides/it/python-java/aspose.slides/customxmlpart/#getXmlData) e [setXmlData](https://reference.aspose.com/slides/it/python-java/aspose.slides/customxmlpart/#setXmlData) quando l’XML è già disponibile come array di byte o quando è più comodo un processamento orientato al binario. Entrambe le rappresentazioni si riferiscono al contenuto XML della stessa parte XML personalizzata.