---
title: "Beheer presentatie-eigenschappen in Python"
linktitle: "Presentatie-eigenschappen"
type: docs
weight: 70
url: /nl/python-java/presentation-properties/
keywords:
- PowerPoint-eigenschappen
- presentatie-eigenschappen
- documenteigenschappen
- ingebouwde eigenschappen
- aangepaste eigenschappen
- geavanceerde eigenschappen
- eigenschappen beheren
- eigenschappen wijzigen
- documentmetadata
- metadata bewerken
- controleertaal
- standaardtaal
- PowerPoint
- OpenDocument
- presentatie
- Python
- Aspose.Slides
description: "Beheers presentatie-eigenschappen in Aspose.Slides voor Python via Java en stroomlijn zoeken, branding en workflow in uw PowerPoint- en OpenDocument-bestanden."
---
## **Inleiding**

Aspose.Slides ondersteunt twee soorten documenteigenschappen: **Ingebouwd** en **Aangepast**. Beide eigendomstypen zijn eenvoudig toegankelijk en beheersbaar via de Aspose.Slides‑API.

Aspose.Slides stelt u in staat om te werken met presentatie‑documenteigenschappen via de [DocumentProperties](https://reference.aspose.com/slides/nl/python-java/aspose.slides/documentproperties/)‑klasse. Een instantie van deze klasse wordt geretourneerd door [Presentation.getDocumentProperties](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentation/#getDocumentProperties). De volgende voorbeelden laten zien hoe u deze eigenschappen kunt lezen, wijzigen en beheren.

{{% alert color="info" title="Note" %}}

Houd er rekening mee dat de velden **Application** en **AppVersion** niet gewijzigd kunnen worden. Aspose.Slides herschrijft ze bij elke opslaan, zodat een opgeslagen presentatie altijd “Aspose.Slides for Java” en de versie van de gebruikte bibliotheek rapporteert. Elke waarde die aan [DocumentProperties.setNameOfApplication](https://reference.aspose.com/slides/nl/python-java/aspose.slides/documentproperties/#setNameOfApplication) wordt doorgegeven, wordt genegeerd wanneer de presentatie wordt weggeschreven.

{{% /alert %}}

## **Documenteigenschappen in PowerPoint**

Microsoft PowerPoint 2007 laat u de documenteigenschappen van presentaties beheren. Klik op het Office‑pictogram en selecteer **Voorbereiden | Eigenschappen | Geavanceerde eigenschappen**, zoals hieronder weergegeven:

|**Geavanceerde eigenschappen selecteren**|
| :- |
|![PowerPoint document properties](https://i.imgur.com/ZrmuCD6.jpg)|
Nadat u **Geavanceerde eigenschappen** hebt geselecteerd, verschijnt een dialoogvenster waarin u de documenteigenschappen van het PowerPoint‑bestand kunt beheren:

|**Eigenschappen‑dialoog**|
| :- |
|![PowerPoint document properties](https://i.imgur.com/LibmdQd.jpg)|
De **Eigenschappen‑dialoog** bevat tabbladen zoals **Algemeen**, **Samenvatting**, **Statistieken**, **Inhoud** en **Aangepast**. Deze tabbladen laten u verschillende soorten informatie over PowerPoint‑bestanden configureren. Gebruik het tabblad **Aangepast** om aangepaste eigenschappen te beheren.

## **Werken met documenteigenschappen via Aspose.Slides voor Python via Java**

Zoals eerder beschreven, ondersteunt Aspose.Slides voor Python via Java zowel **Ingebouwde** als **Aangepaste** documenteigenschappen. De [DocumentProperties](https://reference.aspose.com/slides/nl/python-java/aspose.slides/documentproperties/)‑klasse vertegenwoordigt de documenteigenschappen die aan een presentatiebestand gekoppeld zijn.

Gebruik [Presentation.getDocumentProperties](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentation/#getDocumentProperties) om deze eigenschappen te benaderen zoals hieronder beschreven.

## **Openbare eigenschappen lezen uit een versleutelde presentatie**

Een openingswachtwoord beschermt normaal zowel de inhoud van de presentatie als de documenteigenschappen. Wanneer een presentatie wordt versleuteld door `false` door te geven aan [ProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/nl/python-java/aspose.slides/protectionmanager/#setEncryptDocumentProperties), blijven de documenteigenschappen openbaar. Een toepassing kan vervolgens `true` doorgeven aan [LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/nl/python-java/aspose.slides/loadoptions/#setOnlyLoadDocumentProperties) en de openbare metadata lezen zonder het openingswachtwoord.

De “alleen‑documenteigenschappen‑laden”‑optie bepaalt wat Aspose.Slides laadt; het ontsleutelt niets. Als de eigenschappen wel bij de versleuteling zijn inbegrepen, mislukt het laden zonder wachtwoord. Als de presentatie niet versleuteld is, wordt de optie genegeerd en wordt de volledige presentatie geladen.

Het volgende voorbeeld controleert de laadmodus via [ProtectionManager.isOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/nl/python-java/aspose.slides/protectionmanager/#isOnlyDocumentPropertiesLoaded) en leest vervolgens ingebouwde eigenschappen via [Presentation.getDocumentProperties](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentation/#getDocumentProperties):

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, LoadOptions

load_options = LoadOptions()
load_options.setOnlyLoadDocumentProperties(True)

presentation = Presentation("public-properties-encrypted.pptx", load_options)
try:
    if presentation.getProtectionManager().isOnlyDocumentPropertiesLoaded():
        properties = presentation.getDocumentProperties()

        print("Author: ", properties.getAuthor())
        print("Title: ", properties.getTitle())
        print("Keywords: ", properties.getKeywords())
    else:
        print("The presentation was not loaded in document-properties-only mode.")

finally:
    presentation.dispose()
```

In deze modus wordt de slide‑inhoud niet geladen. Slides, masters, layouts, shapes, media en andere presentatie‑objecten zijn niet beschikbaar. Toepassingen moeten altijd [ProtectionManager.isOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/nl/python-java/aspose.slides/protectionmanager/#isOnlyDocumentPropertiesLoaded) controleren voordat ze een bewerking uitvoeren die het volledige presentatie‑objectmodel vereist.

{{% alert color="warning" title="Warning" %}}
Openbare metadata kunnen namen van auteurs, titels, onderwerpen, trefwoorden, bedrijfsinformatie, opmerkingen en aangepaste waarden onthullen. Versleutel gevoelige eigenschappen samen met de presentatie. Laat ze alleen openbaar wanneer indexering, classificatie, zoeken of document‑beheersystemen een specifieke eis hebben om zonder wachtwoord toegang te krijgen.
{{% /alert %}}

## **Eigenschappen bijwerken van een versleutelde presentatie**

Voor een versleuteld PPTX‑bestand is een presentatie die in “alleen‑documenteigenschappen”‑modus is geladen bedoeld om openbare metadata te lezen. Aspose.Slides kan gewijzigde eigenschappen van dat alleen‑metadata‑object niet opslaan, omdat de openbare eigenschappen consistent moeten blijven met de corresponderende gegevens in de versleutelde presentatie. Bijwerken vereist daarom het juiste openingswachtwoord en een volledige load.

Het volgende voorbeeld opent de presentatie met [LoadOptions.setPassword](https://reference.aspose.com/slides/nl/python-java/aspose.slides/loadoptions/#setPassword), werkt openbare ingebouwde eigenschappen bij en slaat het resultaat op. Vervolgens wordt met [PresentationInfo.isEncrypted](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentationinfo/#isEncrypted) gecontroleerd dat de versleuteling behouden blijft en wordt de openbare metadata zonder wachtwoord opnieuw geopend om de nieuwe waarden te verifiëren:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, LoadOptions, PresentationFactory, SaveFormat

input_path = "public-properties-encrypted.pptx"
output_path = "updated-public-properties-encrypted.pptx"

load_options = LoadOptions()
load_options.setPassword("open_password")

presentation = Presentation(input_path, load_options)
try:
    presentation.getDocumentProperties().setTitle("Updated Product Roadmap")
    presentation.getDocumentProperties().setKeywords("roadmap, planning, indexed")
    presentation.save(output_path, SaveFormat.Pptx)
finally:
    presentation.dispose()

presentation_info = PresentationFactory.getInstance().getPresentationInfo(output_path)
print("The presentation is encrypted: ", presentation_info.isEncrypted())

metadata_load_options = LoadOptions()
metadata_load_options.setOnlyLoadDocumentProperties(True)

metadata_presentation = Presentation(output_path, metadata_load_options)
try:
    if metadata_presentation.getProtectionManager().isOnlyDocumentPropertiesLoaded():
        print("Title: ", metadata_presentation.getDocumentProperties().getTitle())
        print("Keywords: ", metadata_presentation.getDocumentProperties().getKeywords())
    else:
        print("The presentation was not loaded in document-properties-only mode.")

finally:
    metadata_presentation.dispose()
```

Als een toepassing niet gemachtigd is om de presentatie‑inhoud te ontsleutelen of te laden, moet ze openbare eigenschappen van een versleuteld PPTX‑bestand als alleen‑lezen behandelen.

## **Ingebouwde eigenschappen benaderen**

De ingebouwde eigenschappen die door [DocumentProperties](https://reference.aspose.com/slides/nl/python-java/aspose.slides/documentproperties/) worden blootgesteld, omvatten: **Creator** (Auteur), **Description**, **Created** (Aanmaakdatum), **Modified** (Wijzigingsdatum), **Printed** (Laatste afdrukdatum), **LastModifiedBy**, **Keywords**, **SharedDoc** (Wordt gedeeld tussen verschillende producenten?), **PresentationFormat**, **Subject** en **Title**.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, DocumentProperties

# Instantieer de Presentation-klasse die de presentatie vertegenwoordigt
presentation = Presentation("Presentation.pptx")
try:
    # Maak een referentie naar het DocumentProperties-object dat aan de Presentation is gekoppeld
    properties = presentation.getDocumentProperties()

    # Toon de ingebouwde eigenschappen
    print("Category : ", properties.getCategory())
    print("Current Status : ", properties.getContentStatus())
    print("Creation Date : ", properties.getCreatedTime())
    print("Author : ", properties.getAuthor())
    print("Description : ", properties.getComments())
    print("KeyWords : ", properties.getKeywords())
    print("Last Modified By : ", properties.getLastSavedBy())
    print("Supervisor : ", properties.getManager())
    print("Modified Date : ", properties.getLastSavedTime())
    print("Presentation Format : ", properties.getPresentationFormat())
    print("Last Print Date : ", properties.getLastPrinted())
    print("Is Shared between producers : ", properties.getSharedDoc())
    print("Subject : ", properties.getSubject())
    print("Title : ", properties.getTitle())
finally:
    presentation.dispose()
```

## **Ingebouwde eigenschappen wijzigen**

Het wijzigen van ingebouwde eigenschappen is even simpel als ze benaderen. Gebruik de bijbehorende setter om een nieuwe waarde toe te wijzen. Het volgende voorbeeld wijzigt ingebouwde documenteigenschappen met Aspose.Slides voor Python via Java.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, DocumentProperties

presentation = Presentation("Presentation.pptx")
try:
    # Maak een referentie naar het DocumentProperties-object dat aan de Presentation is gekoppeld
    properties = presentation.getDocumentProperties()

    # Stel de ingebouwde eigenschappen in
    properties.setAuthor("Aspose.Slides for Python via Java")
    properties.setTitle("Modifying Presentation Properties")
    properties.setSubject("Aspose Subject")
    properties.setComments("Aspose Description")
    properties.setManager("Aspose Manager")

    # Sla uw presentatie op naar een bestand
    presentation.save("DocProps.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Dit voorbeeld wijzigt de ingebouwde eigenschappen van de presentatie, zoals hieronder te zien is:

|**Ingebouwde documenteigenschappen na wijziging**|
| :- |
|![PowerPoint document properties](https://i.imgur.com/zz1N9de.jpg)|

## **Aangepaste documenteigenschappen toevoegen**

Aspose.Slides voor Python via Java stelt ontwikkelaars ook in staat om aangepaste documenteigenschappen aan presentaties toe te voegen. Het voorbeeld hieronder voegt drie aangepaste eigenschappen toe, zoekt daarna de naam op die op index 2 is opgeslagen en verwijdert die eigenschap, zodat de opgeslagen presentatie er twee overhoudt. Aangepaste eigenschappen worden alfabetisch geïndexeerd, niet in de volgorde waarin ze zijn toegevoegd.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    # Documenteigenschappen ophalen
    properties = presentation.getDocumentProperties()

    # Aangepaste eigenschappen toevoegen
    properties.set_Item("New Custom", jpype.JInt(12))
    properties.set_Item("My Name", "Mudassir")
    properties.set_Item("Custom", jpype.JInt(124))

    # Eigenschapsnaam ophalen op een specifieke index
    property_name = properties.getCustomPropertyName(2)

    # Geselecteerde eigenschap verwijderen
    properties.removeCustomProperty(property_name)

    # Presentatie opslaan
    presentation.save("CustomDemo.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

|**Toegevoegde aangepaste documenteigenschappen**|
| :- |
|![PowerPoint document properties](https://i.imgur.com/HdKcxI9.png)|

## **Aangepaste eigenschappen benaderen en wijzigen**

Aspose.Slides voor Python via Java laat ontwikkelaars ook de waarden van aangepaste eigenschappen raadplegen. Het volgende voorbeeld laat zien hoe u alle aangepaste eigenschappen in een presentatie kunt benaderen en wijzigen.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, DocumentProperties

presentation = Presentation("Presentation.pptx")
try:
    # Maak een referentie naar het DocumentProperties-object dat aan de Presentation is gekoppeld
    properties = presentation.getDocumentProperties()

    # Toegang krijgen tot en aanpassen van aangepaste eigenschappen
    for i in range(properties.getCountOfCustomProperties()):
        property_name = properties.getCustomPropertyName(i)
        # Toon namen en waarden van aangepaste eigenschappen
        print("Custom Property Name : ", property_name)
        print("Custom Property Value : ", properties.get_Item(property_name))

        # Pas de waarden van aangepaste eigenschappen aan
        properties.set_Item(property_name, f"New Value {i + 1}")

    # Sla uw presentatie op naar een bestand
    presentation.save("CustomDemoModified.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Dit voorbeeld wijzigt de aangepaste eigenschappen van de [PPTX](https://docs.fileformat.com/presentation/pptx/)‑presentatie. De onderstaande figuren tonen de aangepaste eigenschappen vóór en na wijziging:

|**Aangepaste eigenschappen vóór wijziging**|
| :- |
|![PowerPoint document properties](https://i.imgur.com/Ze7YHvi.jpg)|

|**Aangepaste eigenschappen na wijziging**|
| :- |
|![PowerPoint document properties](https://i.imgur.com/Tofu0CL.jpg)|

## **Geavanceerde documenteigenschappen**

{{% alert color="info" title="Note" %}}

Nieuwe methoden [readDocumentProperties](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentationinfo/#readDocumentProperties), [updateDocumentProperties](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentationinfo/#updateDocumentProperties) en [writeBindedPresentation](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentationinfo/#writeBindedPresentation) zijn toegevoegd aan de [PresentationInfo](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentationinfo/), en het gedrag van de [DocumentProperties.setLastSavedTime](https://reference.aspose.com/slides/nl/python-java/aspose.slides/documentproperties/#setLastSavedTime)‑methode is gewijzigd.

{{% /alert %}}

De twee nieuwe methoden [readDocumentProperties](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentationinfo/#readDocumentProperties) en [updateDocumentProperties](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentationinfo/#updateDocumentProperties) zijn toegevoegd aan de [PresentationInfo](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentationinfo/)‑klasse. Ze bieden snelle toegang tot documenteigenschappen en laten u eigenschappen wijzigen en bijwerken zonder de volledige presentatie te laden.

De typische workflow van het laden van eigenschappen, het wijzigen van hun waarden en het bijwerken van het document kan als volgt worden geïmplementeerd:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PresentationFactory

# Lees de presentatie-informatie
presentation_info = PresentationFactory.getInstance().getPresentationInfo("presentation.pptx")

# Verkrijg de huidige eigenschappen
properties = presentation_info.readDocumentProperties()

# Stel de nieuwe waarden voor de velden Auteur en Titel in
properties.setAuthor("New Author")
properties.setTitle("New Title")

# Werk de presentatie bij met de nieuwe waarden
presentation_info.updateDocumentProperties(properties)
presentation_info.writeBindedPresentation("presentation.pptx")
```

Er is een alternatieve manier om eigenschappen van een specifieke presentatie als sjabloon te gebruiken om eigenschappen in andere presentaties bij te werken:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PresentationFactory

presentation_info = PresentationFactory.getInstance().getPresentationInfo("template.pptx")
template = presentation_info.readDocumentProperties()

template.setAuthor("Template Author")
template.setTitle("Template Title")
template.setCategory("Template Category")
template.setKeywords("Keyword1, Keyword2, Keyword3")
template.setCompany("Our Company")
template.setComments("Created from template")
template.setContentType("Template Content")
template.setSubject("Template Subject")

for path in ["doc1.pptx", "doc2.odp", "doc3.ppt"]:
    presentation_to_update = PresentationFactory.getInstance().getPresentationInfo(path)
    presentation_to_update.updateDocumentProperties(template)
    presentation_to_update.writeBindedPresentation(path)
```

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PresentationFactory

def update_by_template(path, template):
    presentation_to_update = PresentationFactory.getInstance().getPresentationInfo(path)
    presentation_to_update.updateDocumentProperties(template)
    presentation_to_update.writeBindedPresentation(path)
```

Een nieuwe sjabloon kan van de grond af worden gecreëerd en vervolgens worden gebruikt om meerdere presentaties bij te werken:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PresentationFactory, DocumentProperties

template = DocumentProperties()

template.setAuthor("Template Author")
template.setTitle("Template Title")
template.setCategory("Template Category")
template.setKeywords("Keyword1, Keyword2, Keyword3")
template.setCompany("Our Company")
template.setComments("Created from template")
template.setContentType("Template Content")
template.setSubject("Template Subject")

for path in ["doc1.pptx", "doc2.odp", "doc3.ppt"]:
    presentation_to_update = PresentationFactory.getInstance().getPresentationInfo(path)
    presentation_to_update.updateDocumentProperties(template)
    presentation_to_update.writeBindedPresentation(path)
```

## **Controleertaal instellen**

Aspose.Slides biedt de [PortionFormat.setLanguageId](https://reference.aspose.com/slides/nl/python-java/aspose.slides/portionformat/#setLanguageId)‑methode om de controleertaal voor een PowerPoint‑document in te stellen. De controleertaal is de taal waarvoor spelling en grammatica in de presentatie worden gecontroleerd.

Deze Python‑code toont hoe u de controleertaal voor een PowerPoint‑document instelt:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, Portion, FontData

pptx_file_name = "presentation.pptx"

presentation = Presentation(pptx_file_name)
try:
    auto_shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0)

    paragraph = auto_shape.getTextFrame().getParagraphs().get_Item(0)
    paragraph.getPortions().clear()

    new_portion = Portion()

    font = FontData("SimSun")
    portion_format = new_portion.getPortionFormat()
    portion_format.setComplexScriptFont(font)
    portion_format.setEastAsianFont(font)
    portion_format.setLatinFont(font)

    portion_format.setLanguageId("zh-CN") # stel de ID van een controleertaal in

    new_portion.setText("1。")
    paragraph.getPortions().add(new_portion)
finally:
    presentation.dispose()
```

## **Standaardtaal instellen**

Deze Python‑code toont hoe u de standaardtaal voor een volledige PowerPoint‑presentatie instelt:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, LoadOptions, ShapeType

load_options = LoadOptions()
load_options.setDefaultTextLanguage("en-US")

presentation = Presentation(load_options)
try:
    # Voegt een rechthoekige vorm met tekst toe
    shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 50)
    shape.getTextFrame().setText("New Text")

    # Controleert de taal van de eerste portion
    print(shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().getLanguageId())
finally:
    presentation.dispose()
```

## **Live‑voorbeeld**

Probeer de [**Aspose.Slides Metadata**](https://products.aspose.app/slides/nl/metadata)‑online‑app om te zien hoe u met documenteigenschappen werkt via de Aspose.Slides‑API:

[![View & Edit PowerPoint Metadata](slides-metadata.png)](https://products.aspose.app/slides/nl/metadata)

## **FAQ**

**Hoe kan ik een ingebouwde eigenschap uit een presentatie verwijderen?**

Ingebouwde eigenschappen maken een integraal onderdeel van de presentatie uit en kunnen niet volledig worden verwijderd. U kunt echter hun waarden wijzigen of ze leeg maken als de specifieke eigenschap dat toelaat.

**Wat gebeurt er als ik een aangepaste eigenschap toevoeg die al bestaat?**

Als u een aangepaste eigenschap toevoegt die reeds bestaat, wordt de bestaande waarde overschreven met de nieuwe. U hoeft de eigenschap niet vooraf te verwijderen of te controleren; Aspose.Slides werkt de waarde automatisch bij.

**Kan ik presentatieweigenschappen benaderen zonder de volledige presentatie te laden?**

Ja. Gebruik [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentationfactory/#getPresentationInfo) en vervolgens [PresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentationinfo/#readDocumentProperties) om de opgeslagen documentmetadata te lezen zonder een [Presentation](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentation/)‑instantie te creëren. Zie [Build a Lightweight Presentation Inventory](/slides/nl/python-java/examine-presentation/) voor een volledig rapportage‑voorbeeld en format‑specifieke beperkingen.

**Kan ik openbare eigenschappen van een versleutelde presentatie lezen zonder het openingswachtwoord?**

Ja. De versleuteling van documenteigenschappen moet zijn uitgeschakeld voordat de presentatie werd versleuteld, en de presentatie moet in “alleen‑documenteigenschappen”‑modus worden geladen.

**Kan ik een versleuteld PPTX‑bestand bijwerken in alleen‑documenteigenschappen‑modus?**

Nee. Publieke en versleutelde eigenschapsdata moeten consistent blijven, dus het bijwerken van een versleuteld PPTX‑bestand vereist het volledige laden van de presentatie met het juiste openingswachtwoord.