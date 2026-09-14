---
title: Beheer gevoeligheidslabels in PowerPoint-presentaties in Python
linktitle: Gevoeligheidslabels
type: docs
weight: 50
url: /nl/python-java/sensitivity-labels/
keywords:
- gevoeligheidslabel
- Microsoft Purview
- Microsoft Information Protection
- MIP-metadata
- inhoudsmarkering
- informatiebeveiliging
- documentbeheer
- PowerPoint
- PPTX
- presentatiebeveiliging
- Python
- Aspose.Slides
description: "Lees, voeg toe, werk bij, verwijder en migreer Microsoft Purview-gevoeligheidslabels in PowerPoint PPTX-presentaties met Aspose.Slides voor Python via Java."
---
## **Overzicht**

Microsoft Purview gevoeligheidslabels helpen organisaties documenten te classificeren en te beheren. Tijdens geautomatiseerde presentatieverwerking kan een applicatie een bestaand label moeten behouden, een label toepassen dat door een beleid is geselecteerd, de status bijwerken, of labelmetadata migreren die door een oudere Microsoft Information Protection (MIP)-workflow is geschreven.

Aspose.Slides stelt moderne metadata van gevoeligheidslabels beschikbaar via [Presentation.getSensitivityLabels](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentation/#getSensitivityLabels). Deze methode retourneert een [SensitivityLabelCollection](https://reference.aspose.com/slides/nl/python-java/aspose.slides/sensitivitylabelcollection/) die kan worden geïnspecteerd en aangepast voordat de presentatie wordt opgeslagen als PPTX.

{{% alert color="info" title="Note" %}}
De identificatoren van gevoeligheidslabels en beleidsinformatie worden gedefinieerd door uw Microsoft Purview-configuratie. Controleer de beschikbaarheid van labels en de beleidsvereisten in uw omgeving voordat u metadata toevoegt of migreert. De waarden van [SensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/nl/python-java/aspose.slides/sensitivitylabel/#getContentMarkTypes) beschrijven de inhoudsmarkeringen die aan een label zijn gekoppeld; ze voegen op zichzelf geen zichtbare tekst of vormen toe aan dia's.
{{% /alert %}}

## **Begrijp eigenschappen van gevoeligheidslabels**

Elke [SensitivityLabel](https://reference.aspose.com/slides/nl/python-java/aspose.slides/sensitivitylabel/) bevat de volgende metadata:

| Methodes | Doel |
| --- | --- |
| [getId](https://reference.aspose.com/slides/nl/python-java/aspose.slides/sensitivitylabel/#getId) en [setId](https://reference.aspose.com/slides/nl/python-java/aspose.slides/sensitivitylabel/#setId) | Haal of stel de identificator van het gevoeligheidslabel in het Purview-beleid in. |
| [getSiteId](https://reference.aspose.com/slides/nl/python-java/aspose.slides/sensitivitylabel/#getSiteId) en [setSiteId](https://reference.aspose.com/slides/nl/python-java/aspose.slides/sensitivitylabel/#setSiteId) | Haal of stel de site die aan het labelbeleid is gekoppeld in. |
| [isEnabled](https://reference.aspose.com/slides/nl/python-java/aspose.slides/sensitivitylabel/#isEnabled) en [setEnabled](https://reference.aspose.com/slides/nl/python-java/aspose.slides/sensitivitylabel/#setEnabled) | Haal of stel of het label is ingeschakeld. |
| [isRemoved](https://reference.aspose.com/slides/nl/python-java/aspose.slides/sensitivitylabel/#isRemoved) en [setRemoved](https://reference.aspose.com/slides/nl/python-java/aspose.slides/sensitivitylabel/#setRemoved) | Haal of stel of het label is verwijderd. Stel de waarde in op `True` wanneer de verwijderingsstatus in de metadata moet worden behouden. |
| [getAssignmentMethodType](https://reference.aspose.com/slides/nl/python-java/aspose.slides/sensitivitylabel/#getAssignmentMethodType) en [setAssignmentMethodType](https://reference.aspose.com/slides/nl/python-java/aspose.slides/sensitivitylabel/#setAssignmentMethodType) | Haal of stel of het label automatisch of via een gebruikersbeslissing is toegepast. |
| [getContentMarkTypes](https://reference.aspose.com/slides/nl/python-java/aspose.slides/sensitivitylabel/#getContentMarkTypes) | Haal de inhoudsmarkeringstypen op die aan het label zijn gekoppeld. |

De [SensitivityLabelAssignmentType](https://reference.aspose.com/slides/nl/python-java/aspose.slides/sensitivitylabelassignmenttype/) klasse definieert hoe een label is toegewezen:

- [Standard](https://reference.aspose.com/slides/nl/python-java/aspose.slides/sensitivitylabelassignmenttype/) staat voor een standaard of automatisch toegepast label.
- [Privileged](https://reference.aspose.com/slides/nl/python-java/aspose.slides/sensitivitylabelassignmenttype/) staat voor een label dat via een gebruikersbeslissing is toegepast, inclusief handmatig toegepaste, aanbevolen en verplichte labels.

De [SensitivityLabelContentType](https://reference.aspose.com/slides/nl/python-java/aspose.slides/sensitivitylabelcontenttype/) klasse definieert de markering die aan een label is gekoppeld:

| Waarde | Betekenis |
| --- | --- |
| [None](https://reference.aspose.com/slides/nl/python-java/aspose.slides/sensitivitylabelcontenttype/) | Het label werd standaard of automatisch toegepast. |
| [Header](https://reference.aspose.com/slides/nl/python-java/aspose.slides/sensitivitylabelcontenttype/) | Header‑inhoudsmarkering is gekoppeld aan het label. |
| [Footer](https://reference.aspose.com/slides/nl/python-java/aspose.slides/sensitivitylabelcontenttype/) | Footer‑inhoudsmarkering is gekoppeld aan het label. |
| [Watermark](https://reference.aspose.com/slides/nl/python-java/aspose.slides/sensitivitylabelcontenttype/) | Watermark‑inhoudsmarkering is gekoppeld aan het label. |
| [Encryption](https://reference.aspose.com/slides/nl/python-java/aspose.slides/sensitivitylabelcontenttype/) | Encryptie‑bescherming is gekoppeld aan het label. |

Meerdere markeringstypen kunnen aan één label worden gekoppeld.

## **Lijst bestaande gevoeligheidslabels**

Lees de moderne labelverzameling uit via [Presentation.getSensitivityLabels](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentation/#getSensitivityLabels) en doorloop deze. Het volgende voorbeeld vermeldt elke eigenschap en inhoudsmarkering die voor elk label is opgeslagen:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("presentation.pptx")
try:
    sensitivity_labels = presentation.getSensitivityLabels()

    for sensitivity_label in sensitivity_labels:
        print("Label ID:", sensitivity_label.getId())
        print("Site ID:", sensitivity_label.getSiteId())
        print("Enabled:", sensitivity_label.isEnabled())
        print("Removed:", sensitivity_label.isRemoved())
        print("Assignment method:", sensitivity_label.getAssignmentMethodType())

        for content_mark_type in sensitivity_label.getContentMarkTypes():
            print("Content marking:", content_mark_type)
finally:
    presentation.dispose()
```

## **Voeg een gevoeligheidslabel toe met inhoudsmarkering**

Gebruik [SensitivityLabelCollection.add](https://reference.aspose.com/slides/nl/python-java/aspose.slides/sensitivitylabelcollection/#add) met het label‑identificator, site‑identificator, de ingeschakelde status en de toewijzingsmethode. Nadat de methode het nieuwe [SensitivityLabel](https://reference.aspose.com/slides/nl/python-java/aspose.slides/sensitivitylabel/) heeft geretourneerd, voeg je de vereiste markeringswaarden toe via de lijst die door [SensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/nl/python-java/aspose.slides/sensitivitylabel/#getContentMarkTypes) wordt geretourneerd.

Het volgende voorbeeld voegt een handmatig geselecteerd label toe dat is gekoppeld aan footer‑ en watermark‑markeringen, en slaat vervolgens het resultaat op als PPTX:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SensitivityLabelAssignmentType, SensitivityLabelContentType
from java.util import UUID

presentation = Presentation("presentation.pptx")
try:
    sensitivity_labels = presentation.getSensitivityLabels()

    label_identifier = "{11111111-2222-3333-4444-555555555555}"
    site_identifier = UUID.fromString("aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee")
    is_enabled = True
    assignment_method = SensitivityLabelAssignmentType.Privileged

    sensitivity_label = sensitivity_labels.add(label_identifier, site_identifier, is_enabled, assignment_method)

    sensitivity_label.getContentMarkTypes().addItem(jpype.JInt(SensitivityLabelContentType.Footer))
    sensitivity_label.getContentMarkTypes().addItem(jpype.JInt(SensitivityLabelContentType.Watermark))

    presentation.save("presentation_with_label.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Werk een gevoeligheidslabel bij**

De waarden van [SensitivityLabel](https://reference.aspose.com/slides/nl/python-java/aspose.slides/sensitivitylabel/) zijn lees‑/schrijfbaar, behalve dat de lijst die door [SensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/nl/python-java/aspose.slides/sensitivitylabel/#getContentMarkTypes) wordt geretourneerd, wordt aangepast via de lijstbewerkingen. Nadat je het gewenste label hebt gevonden, kun je de identifier, site‑identifier, ingeschakelde status, toewijzingsmethode, verwijderingsstatus en inhoudsmarkeringstypen bijwerken. Sla de presentatie op om de wijzigingen te bewaren.

Het volgende voorbeeld werkt de ingeschakelde status en toewijzingsmethode van het eerste label bij:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SensitivityLabelAssignmentType

presentation = Presentation("presentation.pptx")
try:
    sensitivity_labels = presentation.getSensitivityLabels()

    if sensitivity_labels.getCount() > 0:
        sensitivity_label = sensitivity_labels.get_Item(0)
        sensitivity_label.setEnabled(True)
        sensitivity_label.setAssignmentMethodType(SensitivityLabelAssignmentType.Privileged)

    presentation.save("presentation_with_updated_label.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Markeer een gevoeligheidslabel als verwijderd**

Om het feit te behouden dat een label is verwijderd, zoek je het label en roep je [SensitivityLabel.setRemoved](https://reference.aspose.com/slides/nl/python-java/aspose.slides/sensitivitylabel/#setRemoved) aan met `True`. Dit behoudt het label‑item terwijl de verwijderingsstatus wordt vastgelegd. Als je in plaats daarvan een item uit de moderne collectie wilt verwijderen, gebruik dan [SensitivityLabelCollection.removeAt](https://reference.aspose.com/slides/nl/python-java/aspose.slides/sensitivitylabelcollection/#removeAt); gebruik [SensitivityLabelCollection.clear](https://reference.aspose.com/slides/nl/python-java/aspose.slides/sensitivitylabelcollection/#clear) om alle items te verwijderen.

Het volgende voorbeeld markeert een specifiek label als verwijderd en slaat de bijgewerkte presentatie op:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    sensitivity_labels = presentation.getSensitivityLabels()
    target_label_identifier = "{11111111-2222-3333-4444-555555555555}"

    for sensitivity_label in sensitivity_labels:
        is_target_label = str(sensitivity_label.getId()).casefold() == target_label_identifier.casefold()

        if is_target_label:
            sensitivity_label.setRemoved(True)
            break

    presentation.save("presentation_with_removed_label.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Lees en migreer legacy MIP‑gevoeligheidslabels**

Ouder MIP‑gebaseerde werkstromen kunnen metadata van gevoeligheidslabels opslaan in aangepaste documenteigenschappen in plaats van in de moderne labelverzameling. Lees die metadata met [DocumentProperties.getSensitivityLabels](https://reference.aspose.com/slides/nl/python-java/aspose.slides/documentproperties/#getSensitivityLabels). De methode parseert de legacy‑aangepaste eigenschappen en retourneert een array van [SensitivityLabel](https://reference.aspose.com/slides/nl/python-java/aspose.slides/sensitivitylabel/) objecten.

Om de metadata te migreren, voeg je elk geretourneerd label toe aan de moderne [SensitivityLabelCollection](https://reference.aspose.com/slides/nl/python-java/aspose.slides/sensitivitylabelcollection/) via [SensitivityLabelCollection.add](https://reference.aspose.com/slides/nl/python-java/aspose.slides/sensitivitylabelcollection/#add). Omdat het toevoegen van een duplicate label‑identificator een uitzondering veroorzaakt, controleert het voorbeeld de doelcollectie voordat elk label wordt gekopieerd. Je kunt extra validatie toevoegen om te bevestigen dat elk legacy‑label nog bestaat in het huidige Purview‑beleid.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation_with_legacy_labels.pptx")
try:
    legacy_sensitivity_labels = presentation.getDocumentProperties().getSensitivityLabels()
    modern_sensitivity_labels = presentation.getSensitivityLabels()

    for legacy_sensitivity_label in legacy_sensitivity_labels:
        label_already_exists = False

        for modern_sensitivity_label in modern_sensitivity_labels:
            label_already_exists = str(modern_sensitivity_label.getId()).casefold() == str(legacy_sensitivity_label.getId()).casefold()

            if label_already_exists:
                break

        if not label_already_exists:
            modern_sensitivity_labels.add(legacy_sensitivity_label)

    presentation.save("presentation_with_modern_labels.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

De migratie kopieert de geparseerde labelobjecten naar de moderne collectie. Het is niet nodig om alle aangepaste documenteigenschappen te wissen, zodat niet‑gerelateerde documentmetadata intact blijft. Gebruik [Presentation.save](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentation/#save) met [SaveFormat.Pptx](https://reference.aspose.com/slides/nl/python-java/aspose.slides/saveformat/) om de moderne labelmetadata naar een PPTX‑bestand te schrijven.

## **FAQ**

**Maakt het toevoegen van een inhoudsmarkeringstype een zichtbare header, footer of watermerk op dia's?**

Nee. De waarden die via de lijst die door [SensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/nl/python-java/aspose.slides/sensitivitylabel/#getContentMarkTypes) wordt geretourneerd worden toegevoegd, beschrijven de markeringen die aan het gevoeligheidslabel zijn gekoppeld. Ze creëren geen zichtbare tekst of vormen in de presentatie. Voeg de overeenkomstige dia‑inhoud separaat toe als uw werkstroom die markeringen moet weergeven.

**Wat is het verschil tussen een label markeren als verwijderd en het verwijderen uit de collectie?**

Het aanroepen van [SensitivityLabel.setRemoved](https://reference.aspose.com/slides/nl/python-java/aspose.slides/sensitivitylabel/#setRemoved) met `True` behoudt het label‑item en registreert zijn verwijderingsstatus. Het aanroepen van [SensitivityLabelCollection.removeAt](https://reference.aspose.com/slides/nl/python-java/aspose.slides/sensitivitylabelcollection/#removeAt) verwijdert het item uit de moderne collectie. Kies de bewerking die overeenkomt met de metadata‑retentie‑eisen van uw organisatie.

**Kan een presentatie zowel legacy MIP‑metadata als moderne gevoeligheidslabels bevatten?**

Ja. Legacy‑labels kunnen blijven staan in aangepaste documenteigenschappen, terwijl moderne labels beschikbaar zijn via [Presentation.getSensitivityLabels](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentation/#getSensitivityLabels). Gebruik [DocumentProperties.getSensitivityLabels](https://reference.aspose.com/slides/nl/python-java/aspose.slides/documentproperties/#getSensitivityLabels) om de legacy‑metadata te lezen en migreer alleen de geldige labels die nog niet aanwezig zijn in de moderne collectie.

**Wat gebeurt er als een label met dezelfde identificator meer dan eens wordt toegevoegd?**

[SensitivityLabelCollection.add](https://reference.aspose.com/slides/nl/python-java/aspose.slides/sensitivitylabelcollection/#add) veroorzaakt een uitzondering wanneer de collectie al een label met dezelfde identificator bevat. Controleer de bestaande waarden die door [SensitivityLabel.getId](https://reference.aspose.com/slides/nl/python-java/aspose.slides/sensitivitylabel/#getId) worden geretourneerd voordat je labels toevoegt of migreert.

**Welk uitvoerformaat moet worden gebruikt om bijgewerkte gevoeligheidslabels te behouden?**

Sla de presentatie op als PPTX door [Presentation.save](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentation/#save) aan te roepen met [SaveFormat.Pptx](https://reference.aspose.com/slides/nl/python-java/aspose.slides/saveformat/), zoals geïllustreerd in de bovenstaande voorbeelden.