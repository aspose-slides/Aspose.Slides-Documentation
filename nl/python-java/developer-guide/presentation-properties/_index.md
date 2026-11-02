---
title: Beheer presentatiedeigenschappen in Python
linktitle: Presentatie‑eigenschappen
type: docs
weight: 70
url: /nl/python-java/presentation-properties/
keywords:
- PowerPoint‑eigenschappen
- presentatie‑eigenschappen
- documenteigenschappen
- ingebouwde eigenschappen
- aangepaste eigenschappen
- geavanceerde eigenschappen
- eigenschappen beheren
- eigenschappen wijzigen
- documentmetadata
- metadata bewerken
- controletaal
- standaardtaal
- PowerPoint
- OpenDocument
- presentatie
- Python
- Aspose.Slides
description: "Beheer presentatiedeigenschappen in Aspose.Slides voor Python via Java en stroomlijn zoeken, branding en workflow in uw PowerPoint‑ en OpenDocument‑bestanden."
---
## **Introductie**

Aspose.Slides voor Python via Java ondersteunt **ingebouwde** en **aangepaste** documenteigenschappen. Gebruik deze eigenschappen om presentatiemetadata te lezen en bij te werken, zoals de auteur, titel en door de gebruiker gedefinieerde waarden.

Aspose.Slides stelt u in staat om met presentatiedocumenteigenschappen te werken via de klasse [DocumentProperties](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/) . Een instantie van deze klasse wordt geretourneerd door [Presentation.getDocumentProperties](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getDocumentProperties) . De volgende voorbeelden laten zien hoe u deze eigenschappen kunt lezen, wijzigen en beheren.

{{% alert color="info" title="Note" %}}
Aspose.Slides beheert de toepassings- en producentmetadata bij het opslaan van presentaties; deze velden identificeren de software die de uitvoer heeft gemaakt.
{{% /alert %}}

## **Beheer Presentatie-eigenschappen**

Documenteigenschappen slaan beschrijvende informatie op naast de presentatie-inhoud. Ze vallen in twee categorieën:

- **Ingebouwde eigenschappen** bevatten standaardmetadata, zoals de titel, auteur en documentstatistieken.
- **Aangepaste eigenschappen** slaan door de gebruiker gedefinieerde naam/waarde-paren op.

Aspose.Slides voor Python via Java biedt toegang tot beide categorieën. In PowerPoint selecteert u **Bestand → Info → Eigenschappen → Geavanceerde eigenschappen** om de documentmetadata te inspecteren. Het dialoogvenster groepeert informatie in tabbladen zoals **Samenvatting**, **Statistieken**, **Inhoud** en **Aangepast**. Gebruik het tabblad **Aangepast** om door‑gebruiker‑gedefinieerde eigenschappen te beheren.

## **Openbare eigenschappen lezen van een versleutelde presentatie**

Een openingswachtwoord beschermt normaal zowel de presentatie‑inhoud als documenteigenschappen. Wanneer een presentatie versleuteld is nadat [ProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/python-java/aspose.slides/protectionmanager/#setEncryptDocumentProperties) is aangeroepen met `False`, blijven de documenteigenschappen openbaar. Een applicatie kan dan [LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/python-java/aspose.slides/loadoptions/#setOnlyLoadDocumentProperties) aanroepen met `True` en de openbare metadata lezen zonder het openingswachtwoord op te geven.

[LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/python-java/aspose.slides/loadoptions/#setOnlyLoadDocumentProperties) bepaalt wat Aspose.Slides laadt; het ontsleutelt niets. Als de eigenschappen zijn opgenomen in de versleuteling, mislukt het laden zonder wachtwoord. Als de presentatie niet versleuteld is, wordt de optie genegeerd en wordt de volledige presentatie geladen.

Het voorbeeld vereist een versleutelde presentatie waarvan de documenteigenschappen openbaar zijn gelaten. Het verifieert de laadmethode via [ProtectionManager.isOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/python-java/aspose.slides/protectionmanager/#isOnlyDocumentPropertiesLoaded) en leest vervolgens ingebouwde eigenschappen via [Presentation.getDocumentProperties](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getDocumentProperties):

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

In deze modus wordt de slide‑inhoud niet geladen. Slides, masters, layouts, shapes, media en andere presentatie‑objecten zijn niet beschikbaar. Applicaties moeten altijd [ProtectionManager.isOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/python-java/aspose.slides/protectionmanager/#isOnlyDocumentPropertiesLoaded) controleren voordat ze een handeling uitvoeren die het volledige presentatiemodel vereist.

{{% alert color="warning" title="Warning" %}}
Openbare metadata kunnen auteursnamen, titels, onderwerpen, trefwoorden, bedrijfsinformatie, opmerkingen en aangepaste waarden blootstellen. Versleutel gevoelige eigenschappen samen met de presentatie. Laat ze alleen openbaar wanneer indexerings‑, classificatie‑, zoek‑ of documentbeheersystemen een specifieke vereiste hebben om er zonder wachtwoord toegang toe te krijgen.
{{% /alert %}}

## **Eigenschappen bijwerken van een versleutelde presentatie**

Voor een versleuteld PPTX‑bestand is een presentatie die is geladen na een aanroep van [LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/python-java/aspose.slides/loadoptions/#setOnlyLoadDocumentProperties) met `True` bedoeld om openbare metadata te lezen. Aspose.Slides kan gewijzigde eigenschappen van dat uitsluitend‑metadata‑object niet opslaan omdat de openbare eigenschappen consistent moeten blijven met de corresponderende gegevens in de versleutelde presentatie. Het bijwerken ervan vereist daarom het juiste openingswachtwoord en een volledige lading.

Het voorbeeld vereist een versleutelde PPTX‑presentatie met openbare documenteigenschappen en een bekend openingswachtwoord. Het opent de volledige presentatie met [LoadOptions.setPassword](https://reference.aspose.com/slides/python-java/aspose.slides/loadoptions/#setPassword), werkt openbare ingebouwde eigenschappen bij en slaat het resultaat op. Vervolgens wordt [PresentationInfo.isEncrypted](https://reference.aspose.com/slides/python-java/aspose.slides/presentationinfo/#isEncrypted) gebruikt om te verifiëren dat de versleuteling behouden blijft en wordt de openbare metadata opnieuw geopend zonder wachtwoord om de nieuwe waarden te controleren:

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

Als een applicatie niet mag ontcijferen of de presentatie‑inhoud mag laden, moet deze openbare eigenschappen van een versleuteld PPTX‑bestand als alleen‑lezen behandelen.

## **Toegang tot ingebouwde eigenschappen**

De [DocumentProperties](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/)‑klasse maakt ingebouwde metadata bloot via getter‑methoden, waaronder [getAuthor](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/#getAuthor), [getTitle](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/#getTitle) en [getCreatedTime](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/#getCreatedTime). Dit voorbeeld opent een bestaande presentatie en drukt de opgeslagen metadata af naar de console. Waarden zijn afhankelijk van de invoerpresentatie; sommige velden kunnen leeg zijn.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("AccessBuiltInProperties.pptx")
try:
    document_properties = presentation.getDocumentProperties()

    print("Category:", document_properties.getCategory())
    print("Content status:", document_properties.getContentStatus())
    print("Creation date:", document_properties.getCreatedTime())
    print("Author:", document_properties.getAuthor())
    print("Comments:", document_properties.getComments())
    print("Keywords:", document_properties.getKeywords())
    print("Last modified by:", document_properties.getLastSavedBy())
    print("Manager:", document_properties.getManager())
    print("Modified date:", document_properties.getLastSavedTime())
    print("Presentation format:", document_properties.getPresentationFormat())
    print("Last print date:", document_properties.getLastPrinted())
    print("Is shared between producers:", document_properties.getSharedDoc())
    print("Subject:", document_properties.getSubject())
    print("Title:", document_properties.getTitle())
finally:
    presentation.dispose()
```

## **Ingebouwde eigenschappen wijzigen**

Om ingebouwde metadata bij te werken, gebruikt u de setter‑methoden op het object dat wordt geretourneerd door [Presentation.getDocumentProperties](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getDocumentProperties). Dit voorbeeld opent een bestaande presentatie, roept [setAuthor](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/#setAuthor), [setTitle](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/#setTitle), [setSubject](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/#setSubject), [setComments](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/#setComments) en [setManager](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/#setManager) aan, en slaat vervolgens de bijgewerkte presentatie op met [Presentation.save](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#save). De opgeslagen PPTX bevat de nieuwe metadata.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("ModifyBuiltInProperties.pptx")
try:
    document_properties = presentation.getDocumentProperties()

    document_properties.setAuthor("Aspose.Slides for Python via Java")
    document_properties.setTitle("Manage PowerPoint Presentation Properties")
    document_properties.setSubject("Modify Built-in Properties")
    document_properties.setComments("Aspose description")
    document_properties.setManager("Aspose manager")

    presentation.save("DocumentProperties_output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Beheer van de hyperlink‑basis**

[DocumentProperties.getHyperlinkBase](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/#getHyperlinkBase) geeft de document‑niveau basis terug voor relatieve hyperlinks. Gebruik [DocumentProperties.setHyperlinkBase](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/#setHyperlinkBase) om deze te wijzigen of te wissen. Dit is nuttig bij het verplaatsen van een presentatie en de gekoppelde bestanden naar een andere locatie. Het staat los van de individuele hyperlink’s [Hyperlink.getExternalUrl](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlink/#getExternalUrl): het wijzigen van de basis herschrijft niet de opgeslagen linkadressen of wijzigt absolute bestemmingen.

Het voorbeeld vereist een presentatie die zowel een relatieve link, zoals `target.html`, als een absolute link, zoals `https://example.org/absolute.html`, bevat. Het leest de bestaande basis, kent een nieuw basisadres toe, en slaat de presentatie op en opent deze opnieuw om de waarde te controleren. Vervolgens wist het de basis met een lege string en verifieert de lege waarde in een apart opgeslagen bestand. Vervang het voorbeeld‑basisadres door de locatie van uw gekoppelde bestanden.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("hyperlinks.pptx")
try:
    print("Original base:", presentation.getDocumentProperties().getHyperlinkBase())

    new_base = "https://example.com/new/"
    presentation.getDocumentProperties().setHyperlinkBase(new_base)
    presentation.save("hyperlinks-updated.pptx", SaveFormat.Pptx)

    updated_presentation = Presentation("hyperlinks-updated.pptx")
    try:
        print("Base preserved:", new_base == updated_presentation.getDocumentProperties().getHyperlinkBase())

        updated_presentation.getDocumentProperties().setHyperlinkBase("")
        updated_presentation.save("hyperlinks-cleared.pptx", SaveFormat.Pptx)

        cleared_presentation = Presentation("hyperlinks-cleared.pptx")
        try:
            print("Base cleared:", "" == cleared_presentation.getDocumentProperties().getHyperlinkBase())
        finally:
            cleared_presentation.dispose()
    finally:
        updated_presentation.dispose()
finally:
    presentation.dispose()
```

De twee verificatie‑berichten moeten `True` afdrukken. Het wissen van de basis laat de individuele hyperlink‑adressen onaangetast.

Een relatieve link naar `target.pptx` opende `old/target.pptx` toen de basis naar de map `old` verwees. Na het wijzigen van de basis naar de map `new`, opslaan en opnieuw openen van de presentatie, opende dezelfde link `new/target.pptx`. Een absolute link bleef hetzelfde bestand openen. Test uw relatieve links in PowerPoint vóór en na het verplaatsen van de presentatie of het wijzigen van de basis.

## **Aangepaste presentatie‑eigenschappen toevoegen**

Aangepaste eigenschappen slaan metadata op die geen overeenkomend ingebouwd veld hebben. De [DocumentProperties.set_Item](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/#set_Item)‑methode laat u een waarde toewijzen op basis van de eigenschapsnaam. Dit voorbeeld maakt een presentatie, voegt twee tekstwaarden en een gehele versie‑waarde toe (met `jpype.JInt` om een Java‑integer door te geven), en slaat de presentatie op met [Presentation.save](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#save). Het toewijzen van een waarde aan een bestaande naam vervangt de waarde van die eigenschap.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    document_properties = presentation.getDocumentProperties()

    document_properties.set_Item("Reviewed by", "John Smith")
    document_properties.set_Item("Confidentiality level", "Internal")
    document_properties.set_Item("Document version", jpype.JInt(2))

    presentation.save("CustomDocumentProperties_output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Toegang tot en wijzigen van aangepaste eigenschappen**

Dit voorbeeld opent een presentatie met aangepaste eigenschappen en gebruikt [getCountOfCustomProperties](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/#getCountOfCustomProperties) om eroverheen te itereren. [getCustomPropertyName](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/#getCustomPropertyName) accepteert een index beginnend bij nul en retourneert de naam die wordt gebruikt door [DocumentProperties.set_Item](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/#set_Item). Het voorbeeld drukt elke oorspronkelijke naam en waarde af, vervangt elke waarde door een genummerde tekenreeks ongeacht het oorspronkelijke type, en slaat de wijzigingen op. Als er geen aangepaste eigenschappen zijn, brengt de lus geen wijzigingen aan.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("AccessAndModifyProperties.pptx")
try:
    document_properties = presentation.getDocumentProperties()

    for i in range(document_properties.getCountOfCustomProperties()):
        property_name = document_properties.getCustomPropertyName(i)
        property_value = document_properties.get_Item(property_name)

        print("Custom property name:", property_name)
        print("Custom property value:", property_value)

        document_properties.set_Item(property_name, f"New Value {i + 1}")

    presentation.save("CustomProperties_output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Live‑voorbeeld**

Probeer de [**Bekijk & Bewerk PowerPoint-metadata**](https://products.aspose.app/slides/metadata) online‑app om te zien hoe u met documenteigenschappen kunt werken via de Aspose.Slides‑API:

[![Bekijk & Bewerk PowerPoint-metadata](slides-metadata.png)](https://products.aspose.app/slides/metadata)

## **FAQ**

**Hoe kan ik een ingebouwde eigenschap uit een presentatie verwijderen?**

Ingebouwde eigenschappen maken een integraal onderdeel van de presentatie uit en kunnen niet volledig verwijderd worden. U kunt echter hun waarden wijzigen of ze leeg maken als de specifieke eigenschap dat toestaat.

**Wat gebeurt er als ik een aangepaste eigenschap toevoeg die al bestaat?**

Als u een aangepaste eigenschap toevoegt die al bestaat, wordt de bestaande waarde overschreven met de nieuwe. U hoeft de eigenschap niet vooraf te verwijderen of te controleren, aangezien Aspose.Slides de waarde automatisch bijwerkt.

**Kan ik presentatie‑eigenschappen benaderen zonder de volledige presentatie te laden?**

Ja. Gebruik [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/python-java/aspose.slides/presentationfactory/#getPresentationInfo) en vervolgens [PresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/python-java/aspose.slides/presentationinfo/#readDocumentProperties) om opgeslagen documentmetadata te lezen zonder een [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/)‑instantie aan te maken. Zie [Maak een lichtgewicht presentatienventaris](/slides/nl/python-java/examine-presentation/) voor een volledig voorbeeld en format‑specifieke beperkingen.

**Kan ik openbare eigenschappen van een versleutelde presentatie lezen zonder het openingswachtwoord?**

Ja. De presentatie moet versleuteld zijn nadat [ProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/python-java/aspose.slides/protectionmanager/#setEncryptDocumentProperties) met `False` is aangeroepen, en moet worden geladen na een aanroep van [LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/python-java/aspose.slides/loadoptions/#setOnlyLoadDocumentProperties) met `True`.

**Kan ik een versleuteld PPTX‑bestand bijwerken in alleen‑documenteigenschappen‑modus?**

Nee. Openbare en versleutelde eigenschapsgegevens moeten consistent blijven, dus het bijwerken van een versleuteld PPTX‑bestand vereist het volledig laden van de presentatie met het juiste openingswachtwoord.