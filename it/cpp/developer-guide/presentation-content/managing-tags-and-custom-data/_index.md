---
title: Gestire tag e dati personalizzati nelle presentazioni usando C++
linktitle: Tag e dati personalizzati
type: docs
weight: 300
url: /it/cpp/managing-tags-and-custom-data/
keywords:
- proprietà del documento
- tag
- dati personalizzati
- XML personalizzato
- parte XML personalizzata
- metadati XML
- ItemId
- aggiungere tag
- coppie valore
- PowerPoint
- presentazione
- C++
- Aspose.Slides
description: "Scopri come gestire tag e dati XML personalizzati nelle presentazioni PowerPoint con Aspose.Slides per C++, includendo aggiunta, lettura, aggiornamento, verifica e rimozione di parti XML personalizzate."
---
## **Panoramica**

Questo articolo spiega come Aspose.Slides gestisce i tag e i dati personalizzati nelle presentazioni PowerPoint. I dati specifici della presentazione possono essere archiviati come tag o parti XML personalizzate. I tag sono semplici coppie chiave‑valore di tipo stringa, mentre le parti XML personalizzate possono contenere metadati strutturati e payload XML specifici dell’applicazione.

Aspose.Slides fornisce API per aggiungere, leggere, aggiornare, verificare e rimuovere parti XML personalizzate a livello di presentazione, diapositiva e forma. Le parti XML personalizzate sono utili per integrazioni che memorizzano informazioni quali identificatori di gestione documentale, stato del flusso di lavoro, metadati di conformità, dati di binding del modello o altri dati strutturati dell’applicazione all’interno di una presentazione.

## **Archiviazione dei dati nei file di presentazione**

I file PPTX—file con estensione `.pptx`—sono archiviati nel formato PresentationML, che fa parte della specifica Office Open XML. Office Open XML definisce la struttura del pacchetto e le relazioni usate per memorizzare il contenuto della presentazione e i dati correlati.

Una presentazione contiene più parti connesse mediante relazioni. Ad esempio, una parte slide contiene il contenuto di una singola diapositiva e può avere relazioni esplicite con altre parti secondo ISO/IEC 29500.

I dati personalizzati possono essere archiviati come tag ([ITagCollection](https://reference.aspose.com/slides/it/cpp/aspose.slides/itagcollection/)) o parti XML personalizzate ([ICustomXmlPartCollection](https://reference.aspose.com/slides/it/cpp/aspose.slides/icustomxmlpartcollection/)). Entrambe sono disponibili tramite l’interfaccia [`ICustomData`](https://reference.aspose.com/slides/it/cpp/aspose.slides/icustomdata/).

{{% alert color="primary" %}}

I tag memorizzano semplici coppie chiave‑valore di tipo stringa. Le parti XML personalizzate memorizzano dati XML strutturati e possono essere associate a una presentazione, diapositiva o forma.

{{% /alert %}}

## **Lavorare con le parti XML personalizzate**

Il metodo [`ICustomData::get_CustomXmlParts`](https://reference.aspose.com/slides/it/cpp/aspose.slides/icustomdata/get_customxmlparts/) restituisce la raccolta di parti XML personalizzate associate a un determinato oggetto della presentazione. Per esempio:

- `presentation->get_CustomData()->get_CustomXmlParts()` contiene le parti XML personalizzate associate alla presentazione stessa.
- `slide->get_CustomData()->get_CustomXmlParts()` contiene le parti XML personalizzate associate a una diapositiva specifica.
- `shape->get_CustomData()->get_CustomXmlParts()` contiene le parti XML personalizzate associate a una forma specifica.

Usa [`Presentation::get_AllCustomXmlParts`](https://reference.aspose.com/slides/it/cpp/aspose.slides/presentation/get_allcustomxmlparts/) quando devi esaminare tutte le parti XML personalizzate nella presentazione, indipendentemente da dove siano associate.

### **Aggiungere una parte XML personalizzata a una presentazione**

Usa [`ICustomXmlPartCollection::Add`](https://reference.aspose.com/slides/it/cpp/aspose.slides/icustomxmlpartcollection/add/) per aggiungere dati XML a una raccolta di parti XML personalizzate. L’XML deve essere valido e non vuoto.

L’esempio seguente aggiunge metadati strutturati alla raccolta di dati personalizzati a livello di presentazione:

```cpp
#include <DOM/ICustomData.h>
#include <DOM/ICustomXmlPart.h>
#include <DOM/ICustomXmlPartCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/guid.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

System::String customXmlContent =
    u"<?xml version=\"1.0\" encoding=\"UTF-8\"?>"
    u"<metadata xmlns=\"urn:example:metadata\">"
        u"<documentId>DOC-1001</documentId>"
        u"<workflowState>Draft</workflowState>"
    u"</metadata>";

auto presentation = System::MakeObject<Presentation>();
auto customXmlPart = presentation->get_CustomData()->get_CustomXmlParts()->Add(customXmlContent);

// Add assegna un identificatore automaticamente. Imposta un GUID specifico solo quando necessario.
customXmlPart->set_ItemId(System::Guid::NewGuid());

presentation->Save(u"presentation_with_custom_xml.pptx", SaveFormat::Pptx);
```

Il metodo `Add` può anche accettare XML come array di byte o stream, utile quando il contenuto XML è già disponibile in forma binaria.

### **Aggiungere una parte XML personalizzata a una diapositiva o a una forma**

I dati XML personalizzati possono essere associati a una diapositiva o a una forma specifica anziché all’intera presentazione. Questo è utile quando i metadati descrivono un solo oggetto, ad esempio una chiave di modello, un identificatore di record esterno o informazioni di binding.

L’esempio seguente aggiunge una parte XML personalizzata a una diapositiva e un’altra a una forma:

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/ICustomData.h>
#include <DOM/ICustomXmlPartCollection.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slides()->idx_get(0);

slide->get_CustomData()->get_CustomXmlParts()->Add(
    u"<slideMetadata xmlns=\"urn:example:slides\">"
        u"<templateKey>TitleSlide</templateKey>"
    u"</slideMetadata>");

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50.0f, 50.0f, 250.0f, 80.0f);

shape->get_TextFrame()->set_Text(u"Customer data");
shape->get_CustomData()->get_CustomXmlParts()->Add(
    u"<shapeMetadata xmlns=\"urn:example:shapes\">"
        u"<recordId>CRM-4281</recordId>"
    u"</shapeMetadata>");

presentation->Save(u"object_custom_xml.pptx", SaveFormat::Pptx);
```

Il livello al quale viene aggiunta la parte determina quale raccolta `get_CustomData()->get_CustomXmlParts()` contiene la relazione a quella parte. I dati a livello di presentazione sono appropriati per metadati a livello di documento, a livello di diapositiva per informazioni che appartengono a una specifica diapositiva e a livello di forma per metadati legati a una singola forma.

### **Elencare e verificare tutte le parti XML personalizzate**

Usa [`Presentation::get_AllCustomXmlParts`](https://reference.aspose.com/slides/it/cpp/aspose.slides/presentation/get_allcustomxmlparts/) per recuperare tutte le parti XML personalizzate da una presentazione. Ogni [`ICustomXmlPart`](https://reference.aspose.com/slides/it/cpp/aspose.slides/icustomxmlpart/) espone il proprio identificatore, il contenuto XML e gli schemi di namespace associati.

L’esempio seguente elenca tutte le parti XML personalizzate e i loro schemi di namespace:

```cpp
#include <DOM/ICustomXmlPart.h>
#include <DOM/Presentation.h>
#include <system/console.h>

using namespace Aspose::Slides;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

for (auto customXmlPart : presentation->get_AllCustomXmlParts())
{
    System::Console::WriteLine(System::String(u"ItemId: ") + customXmlPart->get_ItemId().ToString());
    System::Console::WriteLine(u"XML:");
    System::Console::WriteLine(customXmlPart->get_XmlAsString());

    for (auto namespaceSchema : customXmlPart->get_NamespaceSchemas())
    {
        System::Console::WriteLine(System::String(u"Namespace schema: ") + namespaceSchema);
    }

    System::Console::WriteLine();
}
```

[`ICustomXmlPart::get_NamespaceSchemas`](https://reference.aspose.com/slides/it/cpp/aspose.slides/icustomxmlpart/get_namespaceschemas/) restituisce gli schemi XML associati alla parte XML personalizzata. Queste informazioni possono essere utili durante la verifica di presentazioni che contengono XML prodotto da sistemi esterni.

### **Leggere e aggiornare il contenuto XML e l’ItemId**

Usa [`ICustomXmlPart::get_XmlAsString`](https://reference.aspose.com/slides/it/cpp/aspose.slides/icustomxmlpart/get_xmlasstring/) e `set_XmlAsString` per lavorare con XML come stringa UTF‑8, oppure [`ICustomXmlPart::get_XmlData`](https://reference.aspose.com/slides/it/cpp/aspose.slides/icustomxmlpart/get_xmldata/) e `set_XmlData` per lavorare con i byte grezzi dell’XML. Entrambe le rappresentazioni possono essere lette e aggiornate.

Il metodo [`ICustomXmlPart::get_ItemId`](https://reference.aspose.com/slides/it/cpp/aspose.slides/icustomxmlpart/get_itemid/) restituisce il GUID che identifica la parte XML personalizzata nel documento Office Open XML. L’identificatore può essere modificato con `set_ItemId` quando un’integrazione richiede un nuovo identificatore.

L’esempio seguente aggiorna il contenuto XML e l’identificatore:

```cpp
#include <DOM/ICustomXmlPart.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/console.h>
#include <system/guid.h>
#include <system/text/encoding.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");
auto customXmlPart = presentation->get_AllCustomXmlParts()->idx_get(0);

// Leggi l'XML corrente come testo.
auto currentXmlContent = customXmlPart->get_XmlAsString();
System::Console::WriteLine(currentXmlContent);

// Aggiorna l'XML come stringa UTF-8.
customXmlPart->set_XmlAsString(
    u"<metadata xmlns=\"urn:example:metadata\">"
        u"<documentId>DOC-1001</documentId>"
        u"<workflowState>Approved</workflowState>"
    u"</metadata>");

// XmlData fornisce lo stesso contenuto XML come byte grezzi.
auto customXmlData = customXmlPart->get_XmlData();
System::Console::WriteLine(System::Text::Encoding::get_UTF8()->GetString(customXmlData));

// Sostituisci l'identificatore quando richiesto dall'integrazione.
customXmlPart->set_ItemId(System::Guid::NewGuid());

presentation->Save(u"updated_custom_xml.pptx", SaveFormat::Pptx);
```

Quando assegni XML con `set_XmlAsString` o `set_XmlData`, fornisci XML valido e non vuoto. Usa una rappresentazione o l’altra a seconda che l’applicazione lavori principalmente con stringhe o con dati binari.

### **Rimuovere una parte XML personalizzata**

Aspose.Slides offre diversi modi per rimuovere dati XML personalizzati:

- [`ICustomXmlPart::Remove`](https://reference.aspose.com/slides/it/cpp/aspose.slides/icustomxmlpart/remove/) rimuove la parte XML personalizzata dalla presentazione.
- [`ICustomXmlPartCollection::Remove`](https://reference.aspose.com/slides/it/cpp/aspose.slides/icustomxmlpartcollection/remove/) rimuove una parte specifica da una raccolta di parti XML personalizzate.
- [`ICustomXmlPartCollection::RemoveAt`](https://reference.aspose.com/slides/it/cpp/aspose.slides/icustomxmlpartcollection/removeat/) rimuove la parte all’indice specificato nella raccolta.
- [`ICustomXmlPartCollection::Clear`](https://reference.aspose.com/slides/it/cpp/aspose.slides/icustomxmlpartcollection/clear/) rimuove tutte le parti da una raccolta specifica.

L’esempio seguente rimuove una parte XML personalizzata a livello di presentazione tramite riferimento:

```cpp
#include <DOM/ICustomData.h>
#include <DOM/ICustomXmlPartCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");
auto customXmlParts = presentation->get_CustomData()->get_CustomXmlParts();

if (customXmlParts->get_Count() > 0)
{
    auto customXmlPart = customXmlParts->idx_get(0);
    customXmlParts->Remove(customXmlPart);
}

presentation->Save(u"custom_xml_removed.pptx", SaveFormat::Pptx);
```

Se hai già un `ICustomXmlPart` e vuoi rimuovere quella parte dalla presentazione anziché da una raccolta specifica, chiama `customXmlPart->Remove()`.

Puoi anche rimuovere un elemento per indice:

```cpp
presentation->get_CustomData()->get_CustomXmlParts()->RemoveAt(0);
```

### **Cancellare tutte le parti XML personalizzate da una raccolta**

Usa `Clear` quando tutte le parti XML personalizzate associate a un determinato oggetto della presentazione devono essere rimosse.

```cpp
#include <DOM/ICustomData.h>
#include <DOM/ICustomXmlPartCollection.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");
presentation->get_Slides()->idx_get(0)->get_CustomData()->get_CustomXmlParts()->Clear();

presentation->Save(u"slide_custom_xml_cleared.pptx", SaveFormat::Pptx);
```

`Clear` influisce solo sulla raccolta selezionata. Per esempio, cancellare la raccolta di una diapositiva non cancella quelle a livello di presentazione o di forma.

Per rimuovere ogni parte XML personalizzata nella presentazione, itera su `get_AllCustomXmlParts()` e rimuovi ciascuna parte:

```cpp
#include <DOM/ICustomXmlPart.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

for (auto customXmlPart : presentation->get_AllCustomXmlParts())
{
    customXmlPart->Remove();
}

presentation->Save(u"all_custom_xml_removed.pptx", SaveFormat::Pptx);
```

### **Gestire parti XML personalizzate collegate o condivise**

In una presentazione Office Open XML, la stessa parte XML personalizzata può essere referenziata da più oggetti della presentazione. Ad esempio, un file esistente può contenere relazioni da più diapositive o forme alla stessa parte XML sottostante.

Una parte condivisa dovrebbe essere trattata come un unico oggetto dati con più riferimenti:

- Aggiornandola con `set_XmlAsString`, `set_XmlData` o `set_ItemId` si modifica la parte XML sottostante, quindi la modifica si applica ovunque la parte sia referenziata.
- `get_ItemId()` può essere usato per identificare la stessa parte XML durante la verifica delle raccolte a livello di oggetto.
- Rimuovere una parte da una specifica raccolta `get_CustomXmlParts()` la elimina solo da quella raccolta. Usa `ICustomXmlPart::Remove()` quando la parte stessa deve essere eliminata dalla presentazione.
- Prima di eliminare o sostituire una parte condivisa, verifica le raccolte a livello di oggetto per determinare se altre diapositive o forme la referenziano ancora.

Le overload di `Add` creano una nuova parte XML personalizzata a partire dal contenuto XML; non accettano un `ICustomXmlPart` esistente. Pertanto, le relazioni condivise si incontrano più comunemente quando si caricano presentazioni che le contengono già.

L’esempio seguente verifica le raccolte a livello di presentazione, diapositiva e forma per `ItemId` e segnala le parti referenziate da più di un luogo:

```cpp
#include <algorithm>
#include <vector>
#include <DOM/ICustomData.h>
#include <DOM/ICustomXmlPart.h>
#include <DOM/ICustomXmlPartCollection.h>
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <system/guid.h>
#include <system/string.h>

using namespace Aspose::Slides;

struct CustomXmlReferenceEntry
{
    System::Guid itemId;
    std::vector<System::String> owners;
};

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");
std::vector<CustomXmlReferenceEntry> referencesByItemId;

auto registerCustomXmlParts = [&referencesByItemId](
    const System::String& ownerName,
    const System::SharedPtr<ICustomXmlPartCollection>& customXmlParts)
{
    for (int32_t partIndex = 0; partIndex < customXmlParts->get_Count(); ++partIndex)
    {
        auto customXmlPart = customXmlParts->idx_get(partIndex);
        auto itemId = customXmlPart->get_ItemId();

        auto entry = std::find_if(
            referencesByItemId.begin(),
            referencesByItemId.end(),
            [&itemId](const CustomXmlReferenceEntry& referenceEntry)
            {
                return referenceEntry.itemId == itemId;
            });

        if (entry == referencesByItemId.end())
        {
            referencesByItemId.push_back({ itemId, { ownerName } });
        }
        else
        {
            entry->owners.push_back(ownerName);
        }
    }
};

registerCustomXmlParts(u"Presentation", presentation->get_CustomData()->get_CustomXmlParts());

for (int32_t slideIndex = 0; slideIndex < presentation->get_Slides()->get_Count(); ++slideIndex)
{
    auto slide = presentation->get_Slides()->idx_get(slideIndex);
    registerCustomXmlParts(
        System::String::Format(u"Slide {0}", slideIndex + 1),
        slide->get_CustomData()->get_CustomXmlParts());

    for (int32_t shapeIndex = 0; shapeIndex < slide->get_Shapes()->get_Count(); ++shapeIndex)
    {
        auto shape = slide->get_Shapes()->idx_get(shapeIndex);
        registerCustomXmlParts(
            System::String::Format(u"Slide {0}, shape {1}", slideIndex + 1, shapeIndex),
            shape->get_CustomData()->get_CustomXmlParts());
    }
}

for (const auto& referenceEntry : referencesByItemId)
{
    if (referenceEntry.owners.size() > 1)
    {
        System::Console::WriteLine(
            System::String(u"Shared custom XML part: ") + referenceEntry.itemId.ToString());

        for (const auto& ownerName : referenceEntry.owners)
        {
            System::Console::WriteLine(System::String(u"  Referenced by: ") + ownerName);
        }
    }
}
```

Questo tipo di verifica è utile prima di modificare o eliminare dati XML personalizzati in presentazioni create da sistemi esterni, perché la stessa parte di metadati può partecipare a più di una relazione.

## **Ottenere i valori dei tag**

In Slides, un tag corrisponde alla proprietà `IDocumentProperties::get_Keywords`. Questo esempio mostra come ottenere il valore di un tag con Aspose.Slides per C++ per [Presentation](https://reference.aspose.com/slides/it/cpp/aspose.slides/presentation/):

```cpp
#include <DOM/IDocumentProperties.h>
#include <DOM/Presentation.h>

using namespace Aspose::Slides;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");
auto keywords = presentation->get_DocumentProperties()->get_Keywords();
```

## **Aggiungere tag alle presentazioni**

Aspose.Slides consente di aggiungere tag alle presentazioni. Un tag tipicamente è composto da due elementi:

- il nome di una proprietà personalizzata, ad esempio `MyTag`;
- il valore della proprietà personalizzata, ad esempio `My Tag Value`.

Se devi classificare le presentazioni in base a una regola o proprietà specifica, puoi aggiungere tag a tale scopo. Per esempio, per categorizzare le presentazioni dei paesi del Nord America, puoi creare un tag “NorthAmerican” e assegnare il paese corrispondente come valore.

Questo esempio mostra come aggiungere un tag a una [Presentation](https://reference.aspose.com/slides/it/cpp/aspose.slides/presentation/) usando Aspose.Slides per C++:

```cpp
#include <DOM/ICustomData.h>
#include <DOM/ITagCollection.h>
#include <DOM/Presentation.h>

using namespace Aspose::Slides;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");
auto tags = presentation->get_CustomData()->get_Tags();
tags->idx_set(u"MyTag", u"My Tag Value");
```

I tag possono essere impostati anche per una [Slide](https://reference.aspose.com/slides/it/cpp/aspose.slides/slide/):

```cpp
#include <DOM/ICustomData.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ITagCollection.h>
#include <DOM/Presentation.h>

using namespace Aspose::Slides;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slides()->idx_get(0);
slide->get_CustomData()->get_Tags()->idx_set(u"tag", u"value");
```

Oppure per una singola [Shape](https://reference.aspose.com/slides/it/cpp/aspose.slides/shape/):

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/ICustomData.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ITagCollection.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>

using namespace Aspose::Slides;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slides()->idx_get(0);
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10.0f, 10.0f, 100.0f, 50.0f);
shape->get_TextFrame()->set_Text(u"My text");
shape->get_CustomData()->get_Tags()->idx_set(u"tag", u"value");
```

### **Limitazioni**

I tag aggiunti tramite la raccolta `get_CustomData()->get_Tags()` sono memorizzati solo nel file PowerPoint. Non vengono trasferiti alla struttura dei tag PDF quando la presentazione viene esportata in PDF. Di conseguenza, un identificatore personalizzato assegnato come tag non può essere recuperato dal PDF con tag.

**Soluzione alternativa**: è possibile memorizzare un identificatore personalizzato nel **Testo alternativo** dell’oggetto (ad esempio, `shape->set_AlternativeText(u"MyId")`). Dopo l’esportazione in PDF, il testo alternativo può apparire nella struttura dei tag PDF.

## **FAQ**

**Posso rimuovere tutti i tag da una presentazione, diapositiva o forma in un’unica operazione?**

Sì. La [tag collection](https://reference.aspose.com/slides/it/cpp/aspose.slides/tagcollection/) supporta l’operazione [Clear](https://reference.aspose.com/slides/it/cpp/aspose.slides/tagcollection/clear/) che elimina tutte le coppie chiave‑valore in una volta.

**Come elimino un singolo tag per nome senza iterare sull’intera raccolta?**

Usa [Remove(name)](https://reference.aspose.com/slides/it/cpp/aspose.slides/tagcollection/remove/) su [TagCollection](https://reference.aspose.com/slides/it/cpp/aspose.slides/tagcollection/) per cancellare il tag tramite la sua chiave.

**Come posso recuperare l’elenco completo dei nomi dei tag per analisi o filtraggio?**

Usa [GetNamesOfTags](https://reference.aspose.com/slides/it/cpp/aspose.slides/tagcollection/getnamesoftags/) sulla [tag collection](https://reference.aspose.com/slides/it/cpp/aspose.slides/tagcollection/); restituisce un array con tutti i nomi dei tag.

**Come posso trovare tutte le parti XML personalizzate indipendentemente da dove siano archiviate?**

Usa [`Presentation::get_AllCustomXmlParts`](https://reference.aspose.com/slides/it/cpp/aspose.slides/presentation/get_allcustomxmlparts/) per recuperare tutte le parti XML personalizzate nella presentazione.

**Devo usare `get_XmlAsString`/`set_XmlAsString` oppure `get_XmlData`/`set_XmlData` per aggiornare una parte XML personalizzata?**

Usa `get_XmlAsString` e `set_XmlAsString` quando l’applicazione lavora con testo XML UTF‑8. Usa `get_XmlData` e `set_XmlData` quando l’XML è già disponibile come array di byte o quando è più comodo elaborare i dati in forma binaria. Entrambe le rappresentazioni si riferiscono al contenuto XML della stessa parte XML personalizzata.