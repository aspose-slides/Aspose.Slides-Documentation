---
title: Tags en aangepaste gegevens beheren in presentaties met Python
linktitle: Tags en aangepaste gegevens
type: docs
weight: 300
url: /nl/python-java/managing-tags-and-custom-data/
keywords:
- documenteigenschappen
- tag
- aangepaste gegevens
- aangepaste XML
- aangepast XML-onderdeel
- XML-metadata
- ItemId
- tag toevoegen
- gepaarde waarden
- PowerPoint
- presentatie
- Python
- Aspose.Slides
description: "Leer hoe u tags en aangepaste XML-gegevens in PowerPoint-presentaties kunt beheren met Aspose.Slides for Python via Java, inclusief het toevoegen, lezen, bijwerken, auditen en verwijderen van aangepaste XML-onderdelen."
---
## **Overzicht**

Dit artikel legt uit hoe Aspose.Slides werkt met tags en aangepaste gegevens in PowerPoint‑presentaties. Presentatiespecifieke gegevens kunnen worden opgeslagen als tags of aangepaste XML‑onderdelen. Tags zijn eenvoudige sleutel‑waarde‑tekenreeksparen, terwijl aangepaste XML‑onderdelen gestructureerde metadata en toepassingsspecifieke XML‑payloads kunnen bevatten.

Aspose.Slides biedt API’s voor het toevoegen, lezen, bijwerken, auditen en verwijderen van aangepaste XML‑onderdelen op presentatie‑, dia‑ en vormniveau. Aangepaste XML‑onderdelen zijn nuttig voor integraties die informatie opslaan zoals document‑management‑identifiers, workflow‑status, compliance‑metadata, sjabloon‑bindingsgegevens, of andere gestructureerde toepassingsdata binnen een presentatie.

## **Gegevensopslag in presentatiebestanden**

PPTX‑bestanden — bestanden met de extensie `.pptx` — worden opgeslagen in het PresentationML‑formaat, dat deel uitmaakt van de Office Open XML‑specificatie. Office Open XML definieert de pakketsstructuur en relaties die worden gebruikt om presentatiew inhoud en gerelateerde gegevens op te slaan.

Een presentatie bevat meerdere onderdelen die via relaties met elkaar verbonden zijn. Bijvoorbeeld, een dia‑onderdeel bevat de inhoud van één dia en kan expliciete relaties hebben naar andere onderdelen, gedefinieerd door ISO/IEC 29500.

Aangepaste gegevens kunnen worden opgeslagen als tags ([TagCollection](https://reference.aspose.com/slides/nl/python-java/aspose.slides/tagcollection/)) of als aangepaste XML‑onderdelen ([CustomXmlPartCollection](https://reference.aspose.com/slides/nl/python-java/aspose.slides/customxmlpartcollection/)). Beide zijn beschikbaar via de klasse [CustomData](https://reference.aspose.com/slides/nl/python-java/aspose.slides/customdata/).

{{% alert color="info" title="Opmerking" %}}

Tags slaan eenvoudige tekenreeks‑sleutel‑waarde‑paren op. Aangepaste XML‑onderdelen slaan gestructureerde XML‑gegevens op en kunnen worden gekoppeld aan een presentatie, dia of vorm.

{{% /alert %}}

## **Werken met aangepaste XML‑onderdelen**

De methode [CustomData.getCustomXmlParts](https://reference.aspose.com/slides/nl/python-java/aspose.slides/customdata/#getCustomXmlParts) retourneert de collectie van aangepaste XML‑onderdelen die zijn gekoppeld aan een specifiek presentatie‑object. Bijvoorbeeld:

- De collectie van de presentatie‑[CustomData.getCustomXmlParts](https://reference.aspose.com/slides/nl/python-java/aspose.slides/customdata/#getCustomXmlParts) bevat aangepaste XML‑onderdelen die bij de presentatie zelf horen.
- De collectie van de dia‑[CustomData.getCustomXmlParts](https://reference.aspose.com/slides/nl/python-java/aspose.slides/customdata/#getCustomXmlParts) bevat aangepaste XML‑onderdelen die bij een bepaalde dia horen.
- De collectie van de vorm‑[CustomData.getCustomXmlParts](https://reference.aspose.com/slides/nl/python-java/aspose.slides/customdata/#getCustomXmlParts) bevat aangepaste XML‑onderdelen die bij een specifieke vorm horen.

Gebruik [Presentation.getAllCustomXmlParts](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentation/#getAllCustomXmlParts) wanneer u alle aangepaste XML‑onderdelen in de presentatie wilt inspecteren, ongeacht waar ze zijn gekoppeld.

### **Een aangepast XML‑onderdeel toevoegen aan een presentatie**

Gebruik [CustomXmlPartCollection.add](https://reference.aspose.com/slides/nl/python-java/aspose.slides/customxmlpartcollection/#add) om XML‑gegevens toe te voegen aan een collectie van aangepaste XML‑onderdelen. De XML moet geldig en niet‑leeg zijn.

Het volgende voorbeeld voegt gestructureerde metadata toe aan de presentatieniveau‑custom‑data‑collectie:

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

    # add kent automatisch een identifier toe. Stel een specifieke UUID alleen in wanneer dat nodig is.
    item_id = UUID.randomUUID()
    custom_xml_part.setItemId(item_id)

    presentation.save("presentation_with_custom_xml.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

De [add](https://reference.aspose.com/slides/nl/python-java/aspose.slides/customxmlpartcollection/#add)-methode kan ook XML accepteren als byte‑array of invoerstroom, wat handig is wanneer XML‑inhoud al beschikbaar is in binaire vorm.

### **Een aangepast XML‑onderdeel toevoegen aan een dia of vorm**

Aangepaste XML‑gegevens kunnen worden gekoppeld aan een specifieke dia of vorm in plaats van aan de hele presentatie. Dit is nuttig wanneer metadata slechts één object beschrijft, zoals een sjabloonsleutel, een extern record‑identifier of bindingsinformatie.

Het volgende voorbeeld voegt één aangepast XML‑onderdeel toe aan een dia en een ander aan een vorm:

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

Het niveau waarop een onderdeel wordt toegevoegd bepaalt welke object‑[CustomData.getCustomXmlParts](https://reference.aspose.com/slides/nl/python-java/aspose.slides/customdata/#getCustomXmlParts)-collectie de relatie naar dat onderdeel bevat. Gegevens op presentatieniveau zijn geschikt voor document‑brede metadata, gegevens op dia‑niveau voor informatie die bij een specifieke dia hoort, en gegevens op vorm‑niveau voor metadata die aan een individuele vorm zijn gekoppeld.

### **Alle aangepaste XML‑onderdelen opsommen en auditen**

Gebruik [Presentation.getAllCustomXmlParts](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentation/#getAllCustomXmlParts) om alle aangepaste XML‑onderdelen uit een presentatie op te halen. Elke [CustomXmlPart](https://reference.aspose.com/slides/nl/python-java/aspose.slides/customxmlpart/) geeft zijn identifier, XML‑inhoud en gekoppelde namespace‑schema’s weer.

Het volgende voorbeeld somt alle aangepaste XML‑onderdelen en hun namespace‑schema’s op:

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

[CustomXmlPart.getNamespaceSchemas](https://reference.aspose.com/slides/nl/python-java/aspose.slides/customxmlpart/#getNamespaceSchemas) retourneert de XML‑schema’s die aan het aangepaste XML‑onderdeel zijn gekoppeld. Deze informatie kan nuttig zijn bij het auditen van presentaties die XML bevatten die door externe systemen is geproduceerd.

### **XML‑inhoud en ItemId lezen en bijwerken**

Gebruik [CustomXmlPart.getXmlAsString](https://reference.aspose.com/slides/nl/python-java/aspose.slides/customxmlpart/#getXmlAsString) en [setXmlAsString](https://reference.aspose.com/slides/nl/python-java/aspose.slides/customxmlpart/#setXmlAsString) om met XML te werken als een UTF‑8‑string, of [getXmlData](https://reference.aspose.com/slides/nl/python-java/aspose.slides/customxmlpart/#getXmlData) en [setXmlData](https://reference.aspose.com/slides/nl/python-java/aspose.slides/customxmlpart/#setXmlData) om met de ruwe XML‑bytes te werken.

De methode [CustomXmlPart.getItemId](https://reference.aspose.com/slides/nl/python-java/aspose.slides/customxmlpart/#getItemId) retourneert de UUID die het aangepaste XML‑onderdeel identificeert in het Office Open XML‑document. Gebruik [setItemId](https://reference.aspose.com/slides/nl/python-java/aspose.slides/customxmlpart/#setItemId) wanneer een integratie een nieuwe identifier vereist.

Het volgende voorbeeld werkt de XML‑inhoud en de identifier bij:

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

        # Lees de huidige XML als tekst.
        current_xml_content = custom_xml_part.getXmlAsString()
        print(current_xml_content)

        # Werk de XML bij als een UTF-8-string.
        custom_xml_content = '<metadata xmlns="urn:example:metadata"><documentId>DOC-1001</documentId><workflowState>Approved</workflowState></metadata>'
        custom_xml_part.setXmlAsString(custom_xml_content)

        # getXmlData levert dezelfde XML-inhoud als ruwe bytes.
        custom_xml_data = custom_xml_part.getXmlData()
        print(bytes(custom_xml_data).decode("utf-8"))

        # Vervang de identifier wanneer de integratie daarom vraagt.
        item_id = UUID.randomUUID()
        custom_xml_part.setItemId(item_id)

        presentation.save("updated_custom_xml.pptx", SaveFormat.Pptx)
    else:
        print("No custom XML parts found.")
finally:
    presentation.dispose()
```

Bij het aanroepen van [setXmlAsString](https://reference.aspose.com/slides/nl/python-java/aspose.slides/customxmlpart/#setXmlAsString) of [setXmlData](https://reference.aspose.com/slides/nl/python-java/aspose.slides/customxmlpart/#setXmlData) moet geldige, niet‑lege XML worden opgegeven. Gebruik de ene representatie of de andere, afhankelijk van of de applicatie voornamelijk met strings of met byte‑data werkt.

### **Een aangepast XML‑onderdeel verwijderen**

Aspose.Slides biedt verschillende manieren om aangepaste XML‑gegevens te verwijderen:

- [CustomXmlPart.remove](https://reference.aspose.com/slides/nl/python-java/aspose.slides/customxmlpart/#remove) verwijdert het aangepaste XML‑onderdeel uit de presentatie.
- [CustomXmlPartCollection.remove](https://reference.aspose.com/slides/nl/python-java/aspose.slides/customxmlpartcollection/#remove) verwijdert een specifiek onderdeel uit een collectie van aangepaste XML‑onderdelen.
- [CustomXmlPartCollection.removeAt](https://reference.aspose.com/slides/nl/python-java/aspose.slides/customxmlpartcollection/#removeAt) verwijdert het onderdeel op een opgegeven index in de collectie.
- [CustomXmlPartCollection.clear](https://reference.aspose.com/slides/nl/python-java/aspose.slides/customxmlpartcollection/#clear) verwijdert alle onderdelen uit een specifieke collectie.

Het volgende voorbeeld verwijdert één presentatieniveau‑custom‑XML‑onderdeel via referentie:

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

Als u al een [CustomXmlPart](https://reference.aspose.com/slides/nl/python-java/aspose.slides/customxmlpart/) hebt en dat onderdeel uit de presentatie wilt verwijderen in plaats van een specifieke collectie aan te spreken, roep dan [CustomXmlPart.remove](https://reference.aspose.com/slides/nl/python-java/aspose.slides/customxmlpart/#remove) aan.

U kunt ook een item op index verwijderen:

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

### **Alle aangepaste XML‑onderdelen uit een collectie wissen**

Gebruik [clear](https://reference.aspose.com/slides/nl/python-java/aspose.slides/customxmlpartcollection/#clear) wanneer alle aangepaste XML‑onderdelen die aan een specifiek presentatiedobject zijn gekoppeld, moeten worden verwijderd.

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

[clear](https://reference.aspose.com/slides/nl/python-java/aspose.slides/customxmlpartcollection/#clear) beïnvloedt alleen de geselecteerde collectie. Bijvoorbeeld, het wissen van de collectie van een dia wist de collecties op presentatieniveau of vormniveau niet.

Om elk aangepast XML‑onderdeel in de presentatie te verwijderen, doorloopt u [getAllCustomXmlParts](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentation/#getAllCustomXmlParts) en verwijdert elk onderdeel:

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

### **Gekoppelde of gedeelde aangepaste XML‑onderdelen afhandelen**

In een Office Open XML‑presentatie kan hetzelfde aangepaste XML‑onderdeel vanuit meer dan één presentatiedobject worden gerefereerd. Bijvoorbeeld, een bestaand bestand kan relaties bevatten van meerdere dia’s of vormen naar hetzelfde onderliggende aangepaste XML‑onderdeel.

Een gedeeld onderdeel moet worden behandeld als één data‑object met meerdere referenties:

- Bijwerken met [setXmlAsString](https://reference.aspose.com/slides/nl/python-java/aspose.slides/customxmlpart/#setXmlAsString), [setXmlData](https://reference.aspose.com/slides/nl/python-java/aspose.slides/customxmlpart/#setXmlData) of [setItemId](https://reference.aspose.com/slides/nl/python-java/aspose.slides/customxmlpart/#setItemId) wijzigt het onderliggende aangepaste XML‑onderdeel, zodat de wijziging overal waar dat onderdeel wordt gerefereerd, van kracht is.
- [getItemId](https://reference.aspose.com/slides/nl/python-java/aspose.slides/customxmlpart/#getItemId) kan worden gebruikt om hetzelfde aangepaste XML‑onderdeel te identificeren tijdens het auditen van object‑niveau‑collecties.
- Het verwijderen van een onderdeel uit een specifieke [getCustomXmlParts](https://reference.aspose.com/slides/nl/python-java/aspose.slides/customdata/#getCustomXmlParts)-collectie verwijdert het uit die collectie. Gebruik [CustomXmlPart.remove](https://reference.aspose.com/slides/nl/python-java/aspose.slides/customxmlpart/#remove) wanneer het onderdeel zelf uit de presentatie moet worden verwijderd.
- Voordat een gedeeld onderdeel wordt verwijderd of vervangen, kunt u de object‑niveau‑collecties inspecteren om te bepalen of andere dia’s of vormen het nog steeds refereren.

De [add](https://reference.aspose.com/slides/nl/python-java/aspose.slides/customxmlpartcollection/#add)-overloads maken een nieuw aangepast XML‑onderdeel aan op basis van XML‑inhoud; ze accepteren geen bestaand [CustomXmlPart](https://reference.aspose.com/slides/nl/python-java/aspose.slides/customxmlpart/). Daarom komen gedeelde relaties vooral voor bij het laden van presentaties die ze al bevatten.

Het volgende voorbeeld auditeert presentatieniveau‑, dia‑ en vorm‑collecties op `ItemId` en rapporteert onderdelen die vanaf meer dan één locatie worden gerefereerd:

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

Dit type audit is nuttig vóór het wijzigen of verwijderen van aangepaste XML‑gegevens in presentaties die door externe systemen zijn aangemaakt, omdat hetzelfde metadata‑onderdeel mogelijk in meerdere relaties participeert.

## **Waarden van tags ophalen**

In Slides correspondeert een tag met de methode [DocumentProperties.getKeywords](https://reference.aspose.com/slides/nl/python-java/aspose.slides/documentproperties/#getKeywords). Deze voorbeeldcode toont hoe een tagwaarde kan worden opgehaald met Aspose.Slides for Python via Java voor [Presentation](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentation/):

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

## **Tags toevoegen aan presentaties**

Aspose.Slides maakt het mogelijk om tags toe te voegen aan presentaties. Een tag bestaat doorgaans uit twee elementen:

- de naam van een aangepaste eigenschap, bijvoorbeeld `MyTag`;
- de waarde van de aangepaste eigenschap, bijvoorbeeld `My Tag Value`.

Wanneer u presentaties wilt classificeren op basis van een specifieke regel of eigenschap, kunt u tags hiervoor toevoegen. Bijvoorbeeld, als u presentaties uit Noord‑Amerikaanse landen wilt categoriseren, kunt u een “North American”‑tag maken en het betreffende land als waarde toewijzen.

Deze voorbeeldcode laat zien hoe u een tag toevoegt aan een [Presentation](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentation/) met Aspose.Slides for Python via Java:

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

Tags kunnen ook worden ingesteld voor een [Slide](https://reference.aspose.com/slides/nl/python-java/aspose.slides/slide/):

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

Of voor een individuele [Shape](https://reference.aspose.com/slides/nl/python-java/aspose.slides/shape/):

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

### **Beperkingen**

Tags die via de [CustomData.getTags](https://reference.aspose.com/slides/nl/python-java/aspose.slides/customdata/#getTags)-collectie worden toegevoegd, worden alleen in het PowerPoint‑bestand opgeslagen. Ze worden **niet** overgebracht naar de PDF‑tagstructuur wanneer de presentatie wordt geëxporteerd naar PDF. Daardoor kan een aangepaste identifier die als tag is toegekend, niet worden opgehaald uit de getagde PDF.

**Omzeil­oplossing**: u kunt een aangepaste identifier opslaan in de **Alt‑tekst** van het object (bijvoorbeeld [Shape.setAlternativeText](https://reference.aspose.com/slides/nl/python-java/aspose.slides/shape/#setAlternativeText) met de waarde `"MyId"`). Na export naar PDF kan de Alt‑tekst in de PDF‑tagstructuur verschijnen.

## **FAQ**

**Kan ik alle tags uit een presentatie, dia of vorm in één bewerking verwijderen?**

Ja. De [tag collection](https://reference.aspose.com/slides/nl/python-java/aspose.slides/tagcollection/) ondersteunt een [clear](https://reference.aspose.com/slides/nl/python-java/aspose.slides/tagcollection/#clear)-bewerking die alle sleutel‑waarde‑paren in één keer verwijdert.

**Hoe verwijder ik een enkele tag op basis van de naam zonder door de hele collectie te itereren?**

Gebruik [remove](https://reference.aspose.com/slides/nl/python-java/aspose.slides/tagcollection/#remove) op de [tag collection](https://reference.aspose.com/slides/nl/python-java/aspose.slides/tagcollection/) om de tag op basis van de sleutel te verwijderen.

**Hoe kan ik de volledige lijst met tagnamen ophalen voor analyse of filtering?**

Gebruik [getNamesOfTags](https://reference.aspose.com/slides/nl/python-java/aspose.slides/tagcollection/#getNamesOfTags) op de [tag collection](https://reference.aspose.com/slides/nl/python-java/aspose.slides/tagcollection/); dit retourneert een array met alle tagnamen.

**Hoe kan ik alle aangepaste XML‑onderdelen vinden, ongeacht waar ze zijn opgeslagen?**

Gebruik [Presentation.getAllCustomXmlParts](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentation/#getAllCustomXmlParts) om alle aangepaste XML‑onderdelen in de presentatie op te halen.

**Moet ik [getXmlAsString](https://reference.aspose.com/slides/nl/python-java/aspose.slides/customxmlpart/#getXmlAsString)/[setXmlAsString](https://reference.aspose.com/slides/nl/python-java/aspose.slides/customxmlpart/#setXmlAsString) of [getXmlData](https://reference.aspose.com/slides/nl/python-java/aspose.slides/customxmlpart/#getXmlData)/[setXmlData](https://reference.aspose.com/slides/nl/python-java/aspose.slides/customxmlpart/#setXmlData) gebruiken om een aangepast XML‑onderdeel bij te werken?**

Gebruik [getXmlAsString](https://reference.aspose.com/slides/nl/python-java/aspose.slides/customxmlpart/#getXmlAsString) en [setXmlAsString](https://reference.aspose.com/slides/nl/python-java/aspose.slides/customxmlpart/#setXmlAsString) wanneer de applicatie werkt met UTF‑8 XML‑tekst. Gebruik [getXmlData](https://reference.aspose.com/slides/nl/python-java/aspose.slides/customxmlpart/#getXmlData) en [setXmlData](https://reference.aspose.com/slides/nl/python-java/aspose.slides/customxmlpart/#setXmlData) wanneer de XML al beschikbaar is als byte‑array of wanneer binaire verwerking handiger is. Beide representaties verwijzen naar dezelfde XML‑inhoud van het aangepaste XML‑onderdeel.