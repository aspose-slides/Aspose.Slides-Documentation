---
title: Beheer tags en aangepaste gegevens in presentaties met Python
linktitle: Tags en aangepaste gegevens
type: docs
weight: 300
url: /nl/python-net/managing-tags-and-custom-data/
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
- Python
- Aspose.Slides
description: "Leer hoe u tags en aangepaste XML-gegevens beheert in PowerPoint-presentaties met Aspose.Slides voor Python via .NET, inclusief het toevoegen, lezen, bijwerken, auditen en verwijderen van aangepaste XML-onderdelen."
---
## **Overzicht**

Dit artikel legt uit hoe Aspose.Slides omgaat met tags en aangepaste gegevens in PowerPoint‑presentaties. Presentatie‑specifieke gegevens kunnen worden opgeslagen als tags of als custom XML‑onderdelen. Tags zijn eenvoudige sleutel‑waarde‑tekenreeksparen, terwijl custom XML‑onderdelen gestructureerde metadata en toepassingsspecifieke XML‑payloads kunnen bevatten.

Aspose.Slides biedt API‑s voor het toevoegen, lezen, bijwerken, auditen en verwijderen van custom XML‑onderdelen op presentatieniveau, dia‑ en shape‑niveau. Custom XML‑onderdelen zijn nuttig voor integraties die informatie opslaan zoals document‑beheer‑identifiers, workflow‑status, compliance‑metadata, sjabloon‑bindinggegevens of andere gestructureerde toepassingsgegevens binnen een presentatie.

## **Gegevensopslag in presentatie‑bestanden**

PPTX‑bestanden – bestanden met de extensie `.pptx` – worden opgeslagen in het PresentationML‑formaat, dat onderdeel is van de Office Open XML‑specificatie. Office Open XML definieert de pakketsstructuur en de relaties die worden gebruikt om presentatiewaarde en gerelateerde gegevens op te slaan.

Een presentatie bevat meerdere onderdelen die via relaties met elkaar verbonden zijn. Bijvoorbeeld, een dia‑onderdeel bevat de inhoud van één dia en kan expliciete relaties hebben met andere onderdelen zoals gedefinieerd in ISO/IEC 29500.

Aangepaste gegevens kunnen worden opgeslagen als tags ([TagCollection](https://reference.aspose.com/slides/nl/python-net/aspose.slides/tagcollection/)) of als custom XML‑onderdelen ([CustomXmlPartCollection](https://reference.aspose.com/slides/nl/python-net/aspose.slides/customxmlpartcollection/)). Beide zijn beschikbaar via de [`CustomData`](https://reference.aspose.com/slides/nl/python-net/aspose.slides/customdata/)‑klasse.

{{% alert color="primary" %}}

Tags slaan eenvoudige tekenreeks‑sleutel‑waarde‑paren op. Custom XML‑onderdelen slaan gestructureerde XML‑gegevens op en kunnen worden gekoppeld aan een presentatie, dia of shape.

{{% /alert %}}

## **Werken met custom XML‑onderdelen**

De eigenschap [`CustomData.custom_xml_parts`](https://reference.aspose.com/slides/nl/python-net/aspose.slides/customdata/custom_xml_parts/) geeft de collectie van custom XML‑onderdelen terug die gekoppeld zijn aan een bepaald presentatie‑object. Bijvoorbeeld:

- `presentation.custom_data.custom_xml_parts` bevat custom XML‑onderdelen die aan de presentatie zelf gekoppeld zijn.
- `slide.custom_data.custom_xml_parts` bevat custom XML‑onderdelen die aan een specifieke dia gekoppeld zijn.
- `shape.custom_data.custom_xml_parts` bevat custom XML‑onderdelen die aan een specifieke shape gekoppeld zijn.

Gebruik [`Presentation.all_custom_xml_parts`](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentation/all_custom_xml_parts/) wanneer u alle custom XML‑onderdelen in de presentatie wilt inspecteren, ongeacht waar ze gekoppeld zijn.

### **Een custom XML‑onderdeel toevoegen aan een presentatie**

Gebruik [`CustomXmlPartCollection.add`](https://reference.aspose.com/slides/nl/python-net/aspose.slides/customxmlpartcollection/add/) om XML‑gegevens toe te voegen aan een collectie van custom XML‑onderdelen. De XML moet geldig en niet‑leeg zijn.

Het volgende voorbeeld voegt gestructureerde metadata toe aan de custom‑datacollectie op presentatieniveau:

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

    # add wijst automatisch een identifier toe. Stel een specifieke GUID alleen in wanneer vereist.
    custom_xml_part.item_id = uuid.uuid4()

    presentation.save("presentation_with_custom_xml.pptx", slides.export.SaveFormat.PPTX)
```

De `add`‑methode kan ook XML als byte‑array of stream accepteren, wat nuttig is wanneer XML‑inhoud al in binaire vorm beschikbaar is.

### **Een custom XML‑onderdeel toevoegen aan een dia of shape**

Custom XML‑gegevens kunnen worden gekoppeld aan een specifieke dia of shape in plaats van aan de volledige presentatie. Dit is nuttig wanneer metadata slechts één object beschrijft, zoals een sjabloonsleutel, een extern record‑identifier of binding‑informatie.

Het volgende voorbeeld voegt één custom XML‑onderdeel toe aan een dia en een ander aan een shape:

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

Het niveau waarop een onderdeel wordt toegevoegd bepaalt welke `custom_data.custom_xml_parts`‑collectie van het object de relatie naar dat onderdeel bevat. Gegevens op presentatieniveau zijn geschikt voor document‑brede metadata, dia‑niveau voor informatie die bij een bepaalde dia hoort, en shape‑niveau voor metadata gekoppeld aan een individuele shape.

### **Alle custom XML‑onderdelen opsommen en auditen**

Gebruik [`Presentation.all_custom_xml_parts`](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentation/all_custom_xml_parts/) om alle custom XML‑onderdelen uit een presentatie op te halen. Elk [`CustomXmlPart`](https://reference.aspose.com/slides/nl/python-net/aspose.slides/customxmlpart/) geeft zijn identifier, XML‑inhoud en bijbehorende namespace‑schema’s weer.

Het volgende voorbeeld geeft alle custom XML‑onderdelen en hun namespace‑schema’s weer:

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

[`CustomXmlPart.namespace_schemas`](https://reference.aspose.com/slides/nl/python-net/aspose.slides/customxmlpart/namespace_schemas/) retourneert de XML‑schema’s die aan het custom XML‑onderdeel gekoppeld zijn. Deze informatie kan nuttig zijn bij het auditen van presentaties die XML bevatten die door externe systemen is geproduceerd.

### **XML‑inhoud en ItemId lezen en bijwerken**

Gebruik [`CustomXmlPart.xml_as_string`](https://reference.aspose.com/slides/nl/python-net/aspose.slides/customxmlpart/xml_as_string/) om met XML als UTF‑8‑tekenreeks te werken, of [`CustomXmlPart.xml_data`](https://reference.aspose.com/slides/nl/python-net/aspose.slides/customxmlpart/xml_data/) om met de ruwe XML‑bytes te werken. Beide eigenschappen kunnen worden gelezen en bijgewerkt.

De eigenschap [`CustomXmlPart.item_id`](https://reference.aspose.com/slides/nl/python-net/aspose.slides/customxmlpart/item_id/) bevat de GUID die het custom XML‑onderdeel identificeert in het Office Open XML‑document. Deze kan ook worden gewijzigd wanneer een integratie een nieuwe identifier vereist.

Het volgende voorbeeld werkt de XML‑inhoud en de identifier bij:

```py
import uuid
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    custom_xml_part = presentation.all_custom_xml_parts[0]

    # Lees de huidige XML als tekst.
    current_xml_content = custom_xml_part.xml_as_string
    print(current_xml_content)

    # Werk de XML bij als een UTF-8 tekenreeks.
    custom_xml_part.xml_as_string = (
        '<metadata xmlns="urn:example:metadata">'
        '<documentId>DOC-1001</documentId>'
        '<workflowState>Approved</workflowState>'
        '</metadata>'
    )

    # xml_data levert dezelfde XML inhoud als ruwe bytes.
    custom_xml_data = custom_xml_part.xml_data
    print(custom_xml_data.decode("utf-8"))

    # Vervang de identifier wanneer vereist door de integratie.
    custom_xml_part.item_id = uuid.uuid4()

    presentation.save("updated_custom_xml.pptx", slides.export.SaveFormat.PPTX)
```

Bij het toekennen van `xml_as_string` of `xml_data` moet geldige, niet‑lege XML worden opgegeven. Gebruik de ene of de andere weergave afhankelijk van of de applicatie vooral met tekenreeksen of met bytes werkt.

### **Een custom XML‑onderdeel verwijderen**

Aspose.Slides biedt verschillende manieren om custom XML‑gegevens te verwijderen:

- [`CustomXmlPart.remove`](https://reference.aspose.com/slides/nl/python-net/aspose.slides/customxmlpart/remove/) verwijdert het custom XML‑onderdeel uit de presentatie.
- [`CustomXmlPartCollection.remove`](https://reference.aspose.com/slides/nl/python-net/aspose.slides/customxmlpartcollection/remove/) verwijdert een specifiek onderdeel uit een collectie van custom XML‑onderdelen.
- [`CustomXmlPartCollection.remove_at`](https://reference.aspose.com/slides/nl/python-net/aspose.slides/customxmlpartcollection/remove_at/) verwijdert het onderdeel op een bepaalde index in de collectie.
- [`CustomXmlPartCollection.clear`](https://reference.aspose.com/slides/nl/python-net/aspose.slides/customxmlpartcollection/clear/) verwijdert alle onderdelen uit een specifieke collectie.

Het volgende voorbeeld verwijdert één custom XML‑onderdeel op presentatieniveau via referentie:

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    custom_xml_parts = presentation.custom_data.custom_xml_parts

    if len(custom_xml_parts) > 0:
        custom_xml_part = custom_xml_parts[0]
        custom_xml_parts.remove(custom_xml_part)

    presentation.save("custom_xml_removed.pptx", slides.export.SaveFormat.PPTX)
```

Als u al een `CustomXmlPart` heeft en dat onderdeel uit de presentatie wilt verwijderen in plaats van een specifieke collectie aan te spreken, roep dan `custom_xml_part.remove()` aan.

U kunt ook een item op index verwijderen:

```py
presentation.custom_data.custom_xml_parts.remove_at(0)
```

### **Alle custom XML‑onderdelen uit een collectie wissen**

Gebruik `clear` wanneer alle custom XML‑onderdelen die gekoppeld zijn aan een bepaald presentatie‑object moeten worden verwijderd.

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    presentation.slides[0].custom_data.custom_xml_parts.clear()

    presentation.save("slide_custom_xml_cleared.pptx", slides.export.SaveFormat.PPTX)
```

`clear` heeft alleen effect op de geselecteerde collectie. Bijvoorbeeld, het wissen van de collectie van een dia wist niet de collecties op presentatieniveau of shape‑niveau.

Om elk custom XML‑onderdeel in de presentatie te verwijderen, doorloopt u `all_custom_xml_parts` en verwijdert u elk onderdeel:

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    for custom_xml_part in presentation.all_custom_xml_parts:
        custom_xml_part.remove()

    presentation.save("all_custom_xml_removed.pptx", slides.export.SaveFormat.PPTX)
```

### **Gekoppelde of gedeelde custom XML‑onderdelen afhandelen**

In een Office Open XML‑presentatie kan hetzelfde custom XML‑onderdeel vanuit meer dan één presentatie‑object worden gerefereerd. Bijvoorbeeld, een bestaand bestand kan relaties bevatten van meerdere dia’s of shapes naar hetzelfde onderliggende custom XML‑onderdeel.

Een gedeeld onderdeel moet worden behandeld als één gegevensobject met meerdere referenties:

- Het bijwerken van `xml_as_string`, `xml_data` of `item_id` wijzigt het onderliggende custom XML‑onderdeel, zodat de wijziging overal waar dat onderdeel wordt gerefereerd van kracht is.
- `item_id` kan worden gebruikt om hetzelfde custom XML‑onderdeel te identificeren tijdens het auditen van object‑level collecties.
- Het verwijderen van een onderdeel uit een specifieke `custom_xml_parts`‑collectie verwijdert het alleen uit die collectie. Gebruik `CustomXmlPart.remove()` wanneer het onderdeel zelf uit de gehele presentatie moet worden verwijderd.
- Voor het verwijderen of vervangen van een gedeeld onderdeel, inspecteer eerst de object‑level collecties om te bepalen of andere dia’s of shapes er nog naar verwijzen.

De `add`‑overloads maken een nieuw custom XML‑onderdeel aan op basis van XML‑inhoud; ze accepteren geen bestaand `CustomXmlPart`. Daarom komen gedeelde relaties vooral voor bij het laden van presentaties die ze al bevatten.

Het volgende voorbeeld audit de collecties op presentatieniveau, dia‑niveau en shape‑niveau op `item_id` en rapporteert onderdelen die vanuit meer dan één plaats worden gerefereerd:

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

Dit type audit is nuttig vóór het wijzigen of verwijderen van custom XML‑gegevens in presentaties die door externe systemen zijn aangemaakt, omdat hetzelfde metadata‑onderdeel kan deelnemen aan meerdere relaties.

## **Tag‑waarden ophalen**

In Slides komt een tag overeen met de eigenschap `DocumentProperties.keywords`. Deze voorbeeldcode toont hoe u een tag‑waarde kunt ophalen met Aspose.Slides voor Python via .NET voor [Presentation](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentation/):

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    keywords = presentation.document_properties.keywords
```

## **Tags toevoegen aan presentaties**

Aspose.Slides stelt u in staat tags toe te voegen aan presentaties. Een tag bestaat doorgaans uit twee items:

- de naam van een aangepaste eigenschap, bijvoorbeeld `MyTag`;
- de waarde van de aangepaste eigenschap, bijvoorbeeld `My Tag Value`.

Wanneer u presentaties wilt classificeren op basis van een specifieke regel of eigenschap, kunt u tags toevoegen voor dat doel. Bijvoorbeeld, als u presentaties uit Noord‑Amerikaanse landen wilt categoriseren, kunt u een Noord‑Amerikaanse tag aanmaken en het betreffende land als waarde toewijzen.

Deze voorbeeldcode toont hoe u een tag toevoegt aan een [Presentation](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentation/) met Aspose.Slides voor Python via .NET:

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    tags = presentation.custom_data.tags
    tags.add("MyTag", "My Tag Value")
```

Tags kunnen ook worden ingesteld voor een [Slide](https://reference.aspose.com/slides/nl/python-net/aspose.slides/slide/):

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    slide.custom_data.tags.add("tag", "value")
```

Of voor een individuele [Shape](https://reference.aspose.com/slides/nl/python-net/aspose.slides/shape/):

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, 100, 50)
    shape.text_frame.text = "My text"
    shape.custom_data.tags.add("tag", "value")
```

### **Beperkingen**

Tags die via de `custom_data.tags`‑collectie worden toegevoegd, worden uitsluitend in het PowerPoint‑bestand opgeslagen. Ze worden **niet** overgebracht naar de PDF‑tag‑structuur wanneer de presentatie naar PDF wordt geëxporteerd. Daardoor kan een aangepaste identifier die als tag is toegewezen niet worden opgehaald uit de getagde PDF.

**Work‑around**: U kunt een aangepaste identifier opslaan in de **Alt Text** van het object (bijvoorbeeld `shape.alternative_text = "MyId"`). Na export naar PDF kan de Alt Text in de PDF‑tag‑structuur verschijnen.

## **FAQ**

**Kan ik alle tags uit een presentatie, dia of shape in één bewerking verwijderen?**

Ja. De [tag collection](https://reference.aspose.com/slides/nl/python-net/aspose.slides/tagcollection/) ondersteunt een [clear](https://reference.aspose.com/slides/nl/python-net/aspose.slides/tagcollection/clear/)‑bewerking die alle sleutel‑waarde‑paren tegelijk verwijdert.

**Hoe verwijder ik één enkele tag op naam zonder door de hele collectie te itereren?**

Gebruik [remove(name)](https://reference.aspose.com/slides/nl/python-net/aspose.slides/tagcollection/remove/) op [TagCollection](https://reference.aspose.com/slides/nl/python-net/aspose.slides/tagcollection/) om de tag op sleutel te verwijderen.

**Hoe kan ik de volledige lijst met tag‑namen ophalen voor analyse of filtering?**

Gebruik [get_names_of_tags](https://reference.aspose.com/slides/nl/python-net/aspose.slides/tagcollection/get_names_of_tags/) op de [tag collection](https://reference.aspose.com/slides/nl/python-net/aspose.slides/tagcollection/); deze retourneert een array met alle tag‑namen.

**Hoe kan ik alle custom XML‑onderdelen vinden, ongeacht waar ze zijn opgeslagen?**

Gebruik [`Presentation.all_custom_xml_parts`](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentation/all_custom_xml_parts/) om alle custom XML‑onderdelen in de presentatie op te halen.

**Moet ik `xml_as_string` of `xml_data` gebruiken om een custom XML‑onderdeel bij te werken?**

Gebruik `xml_as_string` wanneer de applicatie werkt met UTF‑8 XML‑tekst. Gebruik `xml_data` wanneer de XML al beschikbaar is als byte‑array of wanneer binary‑gerichte verwerking handiger is. Beide eigenschappen representeren dezelfde XML‑inhoud van het custom XML‑onderdeel.