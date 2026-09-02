---
title: Beheer tags en aangepaste gegevens in presentaties met C++
linktitle: Tags en aangepaste gegevens
type: docs
weight: 300
url: /nl/cpp/managing-tags-and-custom-data/
keywords:
- documenteigenschappen
- tag
- aangepaste gegevens
- aangepaste XML
- aangepast XML-onderdeel
- XML-metadata
- ItemId
- tag toevoegen
- waardeparen
- PowerPoint
- presentatie
- C++
- Aspose.Slides
description: "Leer hoe u tags en aangepaste XML-gegevens in PowerPoint-presentaties kunt beheren met Aspose.Slides voor C++, inclusief het toevoegen, lezen, bijwerken, auditen en verwijderen van aangepaste XML-onderdelen."
---
## **Overzicht**

Dit artikel legt uit hoe Aspose.Slides werkt met tags en aangepaste gegevens in PowerPoint‑presentaties. Presentatiespecifieke gegevens kunnen worden opgeslagen als tags of aangepaste XML‑onderdelen. Tags zijn eenvoudige sleutel‑waarde‑tekenreeksparen, terwijl aangepaste XML‑onderdelen gestructureerde metadata en toepassingsspecifieke XML‑payloads kunnen opslaan.

## **Gegevensopslag in presentiebestanden**

PPTX‑bestanden — bestanden met de extensie `.pptx` — worden opgeslagen in het PresentationML‑formaat, dat onderdeel is van de Office Open XML‑specificatie. Office Open XML definieert de pakketsstructuur en relaties die worden gebruikt om presentatiewaarde en gerelateerde gegevens op te slaan.

Een presentatie bevat meerdere delen die met relaties verbonden zijn. Bijvoorbeeld, een slide‑deel bevat de inhoud van één slide en kan expliciete relaties hebben met andere delen zoals gedefinieerd in ISO/IEC 29500.

Aangepaste gegevens kunnen worden opgeslagen als tags ([ITagCollection](https://reference.aspose.com/slides/nl/cpp/aspose.slides/itagcollection/)) of aangepaste XML‑onderdelen ([ICustomXmlPartCollection](https://reference.aspose.com/slides/nl/cpp/aspose.slides/icustomxmlpartcollection/)). Beide zijn beschikbaar via de [`ICustomData`](https://reference.aspose.com/slides/nl/cpp/aspose.slides/icustomdata/) interface.

{{% alert color="primary" %}}
Tags slaan eenvoudige tekenreeks‑sleutel‑waarde‑paren op. Aangepaste XML‑onderdelen slaan gestructureerde XML‑gegevens op en kunnen worden gekoppeld aan een presentatie, slide of vorm.
{{% /alert %}}

## **Werken met aangepaste XML‑onderdelen**

De methode [`ICustomData::get_CustomXmlParts`](https://reference.aspose.com/slides/nl/cpp/aspose.slides/icustomdata/get_customxmlparts/) retourneert de verzameling van aangepaste XML‑onderdelen die gekoppeld zijn aan een bepaald presentatie‑object. Bijvoorbeeld:

- `presentation->get_CustomData()->get_CustomXmlParts()` bevat de aangepaste XML‑onderdelen die zijn gekoppeld aan de presentatie zelf.
- `slide->get_CustomData()->get_CustomXmlParts()` bevat de aangepaste XML‑onderdelen die gekoppeld zijn aan een specifieke slide.
- `shape->get_CustomData()->get_CustomXmlParts()` bevat de aangepaste XML‑onderdelen die gekoppeld zijn aan een specifieke vorm.

Gebruik [`Presentation::get_AllCustomXmlParts`](https://reference.aspose.com/slides/nl/cpp/aspose.slides/presentation/get_allcustomxmlparts/) wanneer u alle aangepaste XML‑onderdelen in de presentatie wilt bekijken, ongeacht waar ze zijn gekoppeld.

### **Een aangepast XML‑onderdeel toevoegen aan een presentatie**

Gebruik [`ICustomXmlPartCollection::Add`](https://reference.aspose.com/slides/nl/cpp/aspose.slides/icustomxmlpartcollection/add/) om XML‑gegevens toe te voegen aan een collectie van aangepaste XML‑onderdelen. De XML moet geldig en niet‑leeg zijn.

Het volgende voorbeeld voegt gestructureerde metadata toe aan de presentatieniveau‑verzameling van aangepaste gegevens:

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

// Add kent automatisch een identifier toe. Stel een specifieke GUID alleen in wanneer nodig.
customXmlPart->set_ItemId(System::Guid::NewGuid());

presentation->Save(u"presentation_with_custom_xml.pptx", SaveFormat::Pptx);
```

De `Add`‑methode kan ook XML accepteren als een byte‑array of stream, wat nuttig is wanneer XML‑inhoud al beschikbaar is in binaire vorm.

### **Een aangepast XML‑onderdeel toevoegen aan een slide of vorm**

Aangepaste XML‑gegevens kunnen worden gekoppeld aan een specifieke slide of vorm in plaats van aan de hele presentatie. Dit is nuttig wanneer metadata alleen één object beschrijft, bijvoorbeeld een sjabloonsleutel, een extern record‑identificatie of bindinformatie.

Het volgende voorbeeld voegt één aangepast XML‑onderdeel toe aan een slide en een ander aan een vorm:

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

Het niveau waarop een onderdeel wordt toegevoegd bepaalt welke `get_CustomData()->get_CustomXmlParts()`‑verzameling de relatie naar dat onderdeel bevat. Presentatieniveau‑gegevens zijn geschikt voor metadata die het hele document bestrijken, slide‑niveau‑gegevens voor informatie die bij een specifieke slide hoort, en vorm‑niveau‑gegevens voor metadata gekoppeld aan een individuele vorm.

### **Alle aangepaste XML‑onderdelen opsommen en auditen**

Gebruik [`Presentation::get_AllCustomXmlParts`](https://reference.aspose.com/slides/nl/cpp/aspose.slides/presentation/get_allcustomxmlparts/) om alle aangepaste XML‑onderdelen uit een presentatie op te halen. Elk [`ICustomXmlPart`](https://reference.aspose.com/slides/nl/cpp/aspose.slides/icustomxmlpart/) geeft zijn identifier, XML‑inhoud en gekoppelde namespaces‑schemas weer.

Het volgende voorbeeld somt alle aangepaste XML‑onderdelen en hun namespace‑schemas op:

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

[`ICustomXmlPart::get_NamespaceSchemas`](https://reference.aspose.com/slides/nl/cpp/aspose.slides/icustomxmlpart/get_namespaceschemas/) retourneert de XML‑schemas die aan het aangepaste XML‑onderdeel zijn gekoppeld. Deze informatie kan nuttig zijn bij het auditen van presentaties die XML bevatten die door externe systemen is geproduceerd.

### **XML‑inhoud en ItemId lezen en bijwerken**

Gebruik [`ICustomXmlPart::get_XmlAsString`](https://reference.aspose.com/slides/nl/cpp/aspose.slides/icustomxmlpart/get_xmlasstring/) en `set_XmlAsString` om met XML te werken als een UTF‑8‑tekenreeks, of [`ICustomXmlPart::get_XmlData`](https://reference.aspose.com/slides/nl/cpp/aspose.slides/icustomxmlpart/get_xmldata/) en `set_XmlData` om met de ruwe XML‑bytes te werken. Beide representaties kunnen worden gelezen en bijgewerkt.

De methode [`ICustomXmlPart::get_ItemId`](https://reference.aspose.com/slides/nl/cpp/aspose.slides/icustomxmlpart/get_itemid/) retourneert de GUID die het aangepaste XML‑onderdeel identificeert in het Office Open XML‑document. De identifier kan ook worden gewijzigd met `set_ItemId` wanneer een integratie een nieuwe identifier vereist.

Het volgende voorbeeld werkt de XML‑inhoud en de identifier bij:

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

// Lees de huidige XML als tekst.
auto currentXmlContent = customXmlPart->get_XmlAsString();
System::Console::WriteLine(currentXmlContent);

// Werk de XML bij als een UTF-8 tekenreeks.
customXmlPart->set_XmlAsString(
    u"<metadata xmlns=\"urn:example:metadata\">"
        u"<documentId>DOC-1001</documentId>"
        u"<workflowState>Approved</workflowState>"
    u"</metadata>");

// XmlData levert dezelfde XML‑inhoud als ruwe bytes.
auto customXmlData = customXmlPart->get_XmlData();
System::Console::WriteLine(System::Text::Encoding::get_UTF8()->GetString(customXmlData));

// Vervang de identifier wanneer de integratie dit vereist.
customXmlPart->set_ItemId(System::Guid::NewGuid());

presentation->Save(u"updated_custom_xml.pptx", SaveFormat::Pptx);
```

Wanneer u XML toewijst met `set_XmlAsString` of `set_XmlData`, zorg dan voor geldige, niet‑lege XML. Gebruik de ene representatie of de andere, afhankelijk van of de applicatie voornamelijk met tekenreeksen of met byte‑gegevens werkt.

### **Een aangepast XML‑onderdeel verwijderen**

Aspose.Slides biedt verschillende manieren om aangepaste XML‑gegevens te verwijderen:

- [`ICustomXmlPart::Remove`](https://reference.aspose.com/slides/nl/cpp/aspose.slides/icustomxmlpart/remove/) verwijdert het aangepaste XML‑onderdeel uit de presentatie.
- [`ICustomXmlPartCollection::Remove`](https://reference.aspose.com/slides/nl/cpp/aspose.slides/icustomxmlpartcollection/remove/) verwijdert een specifiek onderdeel uit een collectie van aangepaste XML‑onderdelen.
- [`ICustomXmlPartCollection::RemoveAt`](https://reference.aspose.com/slides/nl/cpp/aspose.slides/icustomxmlpartcollection/removeat/) verwijdert het onderdeel op een opgegeven index in de collectie.
- [`ICustomXmlPartCollection::Clear`](https://reference.aspose.com/slides/nl/cpp/aspose.slides/icustomxmlpartcollection/clear/) verwijdert alle onderdelen uit een specifieke collectie.

Het volgende voorbeeld verwijdert één presentatieniveau‑aangepast XML‑onderdeel via een referentie:

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

Als u al een `ICustomXmlPart` hebt en dat onderdeel uit de presentatie wilt verwijderen in plaats van een specifieke collectie aan te spreken, roep dan `customXmlPart->Remove()` aan.

U kunt een item ook op index verwijderen:

```cpp
presentation->get_CustomData()->get_CustomXmlParts()->RemoveAt(0);
```

### **Alle aangepaste XML‑onderdelen uit een collectie wissen**

Gebruik `Clear` wanneer alle aangepaste XML‑onderdelen die gekoppeld zijn aan een bepaald presentatie‑object moeten worden verwijderd.

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

`Clear` heeft alleen effect op de geselecteerde collectie. Bijvoorbeeld, het wissen van de collectie van een slide verwijdert niet de collecties op presentatieniveau of vormniveau.

Om elk aangepast XML‑onderdeel in de presentatie te verwijderen, itereren we door `get_AllCustomXmlParts()` en verwijderen we elk onderdeel:

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

### **Gekoppelde of gedeelde aangepaste XML‑onderdelen afhandelen**

In een Office Open XML‑presentatie kan hetzelfde aangepaste XML‑onderdeel door meer dan één presentatie‑object worden gerefereerd. Bijvoorbeeld, een bestaand bestand kan relaties bevatten vanuit meerdere slides of vormen naar hetzelfde onderliggende aangepaste XML‑onderdeel.

Een gedeeld onderdeel moet worden behandeld als één gegevensobject met meerdere referenties:

- Bijwerken met `set_XmlAsString`, `set_XmlData` of `set_ItemId` verandert het onderliggende aangepaste XML‑onderdeel, waardoor de wijziging overal waar dat onderdeel wordt gerefereerd van kracht is.
- `get_ItemId()` kan worden gebruikt om hetzelfde aangepaste XML‑onderdeel te identificeren tijdens het auditen van object‑niveau‑collecties.
- Het verwijderen van een onderdeel uit een specifieke `get_CustomXmlParts()`‑collectie verwijdert het uit die collectie. Gebruik `ICustomXmlPart::Remove()` wanneer het onderdeel zelf uit de presentatie moet worden verwijderd.
- Voordat u een gedeeld onderdeel verwijdert of vervangt, inspecteer de object‑niveau‑collecties om te bepalen of andere slides of vormen het nog refereren.

De `Add`‑overloads maken een nieuw aangepast XML‑onderdeel aan vanuit XML‑inhoud; ze accepteren geen bestaand `ICustomXmlPart`. Daarom komen gedeelde relaties het vaakst voor bij het laden van presentaties die deze al bevatten.

Het volgende voorbeeld auditeert presentatieniveau‑, slide‑ en vorm‑collecties op `ItemId` en meldt onderdelen die vanuit meer dan één plaats worden gerefereerd:

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

Dit type audit is nuttig voordat u aangepaste XML‑gegevens wijzigt of verwijdert in presentaties die door externe systemen zijn aangemaakt, omdat hetzelfde metadata‑onderdeel in meer dan één relatie kan voorkomen.

## **Waarden van tags ophalen**

In Slides correspondeert een tag met de eigenschap `IDocumentProperties::get_Keywords`. Deze voorbeeldcode toont hoe u een tag‑waarde kunt ophalen met Aspose.Slides voor C++ voor [Presentation](https://reference.aspose.com/slides/nl/cpp/aspose.slides/presentation/):

```cpp
#include <DOM/IDocumentProperties.h>
#include <DOM/Presentation.h>

using namespace Aspose::Slides;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");
auto keywords = presentation->get_DocumentProperties()->get_Keywords();
```

## **Tags toevoegen aan presentaties**

Aspose.Slides maakt het mogelijk om tags toe te voegen aan presentaties. Een tag bestaat doorgaans uit twee items:

- de naam van een aangepaste eigenschap, bijvoorbeeld `MyTag`;
- de waarde van de aangepaste eigenschap, bijvoorbeeld `My Tag Value`.

Als u presentaties wilt classificeren op basis van een specifieke regel of eigenschap, kunt u tags toevoegen voor dat doel. Bijvoorbeeld, als u presentaties uit Noord‑Amerikaanse landen wilt categoriseren, kunt u een Noord‑Amerikaanse tag maken en het relevante land als waarde toewijzen.

Deze voorbeeldcode laat zien hoe u een tag toevoegt aan een [Presentation](https://reference.aspose.com/slides/nl/cpp/aspose.slides/presentation/) met Aspose.Slides voor C++:

```cpp
#include <DOM/ICustomData.h>
#include <DOM/ITagCollection.h>
#include <DOM/Presentation.h>

using namespace Aspose::Slides;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");
auto tags = presentation->get_CustomData()->get_Tags();
tags->idx_set(u"MyTag", u"My Tag Value");
```

Tags kunnen ook worden ingesteld voor een [Slide](https://reference.aspose.com/slides/nl/cpp/aspose.slides/slide/):

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

Of voor een individuele [Shape](https://reference.aspose.com/slides/nl/cpp/aspose.slides/shape/):

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

### **Beperkingen**

Tags die via de `get_CustomData()->get_Tags()`‑collectie worden toegevoegd, worden alleen in het PowerPoint‑bestand opgeslagen. Ze worden **niet** overgebracht naar de PDF‑tagstructuur wanneer de presentatie wordt geëxporteerd naar PDF. Daarom kan een aangepast identificatortag niet worden opgehaald uit de getagde PDF.

**Workaround**: u kunt een aangepast identificatie‑attribuut opslaan in de **Alt‑tekst** van het object (bijvoorbeeld `shape->set_AlternativeText(u"MyId")`). Na export naar PDF kan de Alt‑tekst in de PDF‑tagstructuur verschijnen.

## **FAQ**

**Kan ik alle tags uit een presentatie, slide of vorm in één bewerking verwijderen?**

Ja. De [tag‑collectie](https://reference.aspose.com/slides/nl/cpp/aspose.slides/tagcollection/) ondersteunt een [Clear](https://reference.aspose.com/slides/nl/cpp/aspose.slides/tagcollection/clear/)‑bewerking die alle sleutel‑waarde‑paren in één keer verwijdert.

**Hoe verwijder ik een enkele tag op basis van de naam zonder de hele collectie te doorlopen?**

Gebruik [Remove(name)](https://reference.aspose.com/slides/nl/cpp/aspose.slides/tagcollection/remove/) op [TagCollection](https://reference.aspose.com/slides/nl/cpp/aspose.slides/tagcollection/) om de tag op zijn sleutel te verwijderen.

**Hoe kan ik de volledige lijst met tagnamen ophalen voor analyse of filtering?**

Gebruik [GetNamesOfTags](https://reference.aspose.com/slides/nl/cpp/aspose.slides/tagcollection/getnamesoftags/) op de [tag‑collectie](https://reference.aspose.com/slides/nl/cpp/aspose.slides/tagcollection/); dit retourneert een array met alle tagnamen.

**Hoe vind ik alle aangepaste XML‑onderdelen, ongeacht waar ze zijn opgeslagen?**

Gebruik [`Presentation::get_AllCustomXmlParts`](https://reference.aspose.com/slides/nl/cpp/aspose.slides/presentation/get_allcustomxmlparts/) om alle aangepaste XML‑onderdelen in de presentatie op te halen.

**Moet ik `get_XmlAsString`/`set_XmlAsString` of `get_XmlData`/`set_XmlData` gebruiken om een aangepast XML‑onderdeel bij te werken?**

Gebruik `get_XmlAsString` en `set_XmlAsString` wanneer de applicatie werkt met UTF‑8‑XML‑tekst. Gebruik `get_XmlData` en `set_XmlData` wanneer de XML al beschikbaar is als byte‑array of wanneer een binaire verwerking handiger is. Beide representaties verwijzen naar de XML‑inhoud van hetzelfde aangepaste XML‑onderdeel.