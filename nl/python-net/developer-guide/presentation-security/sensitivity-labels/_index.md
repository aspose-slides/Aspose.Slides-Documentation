---
title: Beheer gevoeligheidsetiketten in PowerPoint-presentaties met Python
linktitle: Gevoeligheidsetiketten
type: docs
weight: 50
url: /nl/python-net/sensitivity-labels/
keywords:
- gevoeligheidsetiket
- Microsoft Purview
- Microsoft Information Protection
- MIP-metadata
- contentmarkering
- informatiebeveiliging
- documentbeheer
- PowerPoint
- PPTX
- presentatiebeveiliging
- Python
- Aspose.Slides
description: "Lees, voeg toe, werk bij, verwijder en migreer Microsoft Purview gevoeligheidsetiketten in PowerPoint PPTX-presentaties met Aspose.Slides voor Python via .NET."
---
## **Overzicht**

Microsoft Purview gevoeligheidsetiketten helpen organisaties documenten te classificeren en te beheren. Tijdens geautomatiseerde verwerking van presentaties kan een applicatie een bestaand etiket moeten behouden, een etiket toepassen dat door een beleid is geselecteerd, de status bijwerken, of metabeschrijvingen van etiketten migreren die zijn geschreven door een oudere Microsoft Information Protection (MIP) workflow.

Aspose.Slides for Python via .NET stelt moderne metadata van gevoeligheidsetiketten beschikbaar via [Presentation.sensitivity_labels](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentation/sensitivity_labels/). Deze eigenschap retourneert een [SensitivityLabelCollection](https://reference.aspose.com/slides/nl/python-net/aspose.slides/sensitivitylabelcollection/) die kan worden geïnspecteerd en gewijzigd voordat de presentatie wordt opgeslagen als PPTX.

{{% alert color="primary" title="Opmerking" %}}
Gevoeligheidsetiket‑identifiers en beleidsinformatie worden gedefinieerd door uw Microsoft Purview‑configuratie. Controleer de beschikbaarheid van etiketten en beleidsvereisten in uw omgeving voordat u metadata toevoegt of migreert. De waarden van [SensitivityLabel.content_mark_types](https://reference.aspose.com/slides/nl/python-net/aspose.slides/sensitivitylabel/content_mark_types/) beschrijven de contentmarkeringen die aan een etiket zijn gekoppeld; ze voegen op zichzelf geen zichtbare tekst of vormen toe aan dia’s.
{{% /alert %}}

## **Begrijp de eigenschappen van gevoeligheidsetiketten**

Elke [SensitivityLabel](https://reference.aspose.com/slides/nl/python-net/aspose.slides/sensitivitylabel/) bevat de volgende metadata:

| Eigenschap | Doel |
| --- | --- |
| [SensitivityLabel.id](https://reference.aspose.com/slides/nl/python-net/aspose.slides/sensitivitylabel/id/) | Identificeert het gevoeligheidsetiket in het Purview‑beleid. |
| [SensitivityLabel.site_id](https://reference.aspose.com/slides/nl/python-net/aspose.slides/sensitivitylabel/site_id/) | Identificeert de site die geassocieerd is met het etiketbeleid. |
| [SensitivityLabel.is_enabled](https://reference.aspose.com/slides/nl/python-net/aspose.slides/sensitivitylabel/is_enabled/) | Geeft aan of het etiket ingeschakeld is. |
| [SensitivityLabel.is_removed](https://reference.aspose.com/slides/nl/python-net/aspose.slides/sensitivitylabel/is_removed/) | Geeft aan dat het etiket verwijderd is. Stel deze eigenschap in op `True` wanneer de verwijderingsstatus behouden moet blijven in de metadata. |
| [SensitivityLabel.assignment_method_type](https://reference.aspose.com/slides/nl/python-net/aspose.slides/sensitivitylabel/assignment_method_type/) | Specificeert of het etiket automatisch of via een gebruikersbeslissing is toegepast. |
| [SensitivityLabel.content_mark_types](https://reference.aspose.com/slides/nl/python-net/aspose.slides/sensitivitylabel/content_mark_types/) | Somt de contentmarkeringstypen op die aan het etiket zijn gekoppeld. |

De [SensitivityLabelAssignmentType](https://reference.aspose.com/slides/nl/python-net/aspose.slides/sensitivitylabelassignmenttype/) enumeratie beschrijft hoe een etiket werd toegewezen:

- [SensitivityLabelAssignmentType.STANDARD](https://reference.aspose.com/slides/nl/python-net/aspose.slides/sensitivitylabelassignmenttype/) vertegenwoordigt een standaard of automatisch toegepast etiket.
- [SensitivityLabelAssignmentType.PRIVILEGED](https://reference.aspose.com/slides/nl/python-net/aspose.slides/sensitivitylabelassignmenttype/) vertegenwoordigt een etiket toegepast via een gebruikersbeslissing, waaronder handmatig toegepaste, aanbevolen en verplichte etiketten.

De [SensitivityLabelContentType](https://reference.aspose.com/slides/nl/python-net/aspose.slides/sensitivitylabelcontenttype/) enumeratie identificeert de markering die aan een etiket is gekoppeld:

| Waarde | Betekenis |
| --- | --- |
| [SensitivityLabelContentType.NONE](https://reference.aspose.com/slides/nl/python-net/aspose.slides/sensitivitylabelcontenttype/) | Het etiket werd standaard of automatisch toegepast. |
| [SensitivityLabelContentType.HEADER](https://reference.aspose.com/slides/nl/python-net/aspose.slides/sensitivitylabelcontenttype/) | Koptekst contentmarkering is gekoppeld aan het etiket. |
| [SensitivityLabelContentType.FOOTER](https://reference.aspose.com/slides/nl/python-net/aspose.slides/sensitivitylabelcontenttype/) | Voettekst contentmarkering is gekoppeld aan het etiket. |
| [SensitivityLabelContentType.WATERMARK](https://reference.aspose.com/slides/nl/python-net/aspose.slides/sensitivitylabelcontenttype/) | Watermerk contentmarkering is gekoppeld aan het etiket. |
| [SensitivityLabelContentType.ENCRYPTION](https://reference.aspose.com/slides/nl/python-net/aspose.slides/sensitivitylabelcontenttype/) | Encryptie bescherming is gekoppeld aan het etiket. |

Meerdere markeringstypen kunnen aan één etiket worden gekoppeld.

## **Lijst bestaande gevoeligheidsetiketten**

Lees de moderne etiketcollectie via [Presentation.sensitivity_labels](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentation/sensitivity_labels/) en doorloop deze. Het volgende voorbeeld geeft elke eigenschap en contentmarkering weer die voor elk etiket is opgeslagen:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    sensitivity_labels = presentation.sensitivity_labels

    for sensitivity_label in sensitivity_labels:
        print("Label ID:", sensitivity_label.id)
        print("Site ID:", sensitivity_label.site_id)
        print("Enabled:", sensitivity_label.is_enabled)
        print("Removed:", sensitivity_label.is_removed)
        print("Assignment method:", sensitivity_label.assignment_method_type)

        for content_mark_type in sensitivity_label.content_mark_types:
            print("Content marking:", content_mark_type)
```

## **Voeg een gevoeligheidsetiket toe met contentmarkering**

Gebruik [SensitivityLabelCollection.add](https://reference.aspose.com/slides/nl/python-net/aspose.slides/sensitivitylabelcollection/add/) met de etiket‑identifier, site‑identifier, ingeschakelde status en toewijzingsmethode. Geef de site‑identifier door als een Python `uuid.UUID`‑object. Nadat de methode het nieuwe [SensitivityLabel](https://reference.aspose.com/slides/nl/python-net/aspose.slides/sensitivitylabel/) heeft geretourneerd, voeg je de vereiste markeringstypen toe aan [SensitivityLabel.content_mark_types](https://reference.aspose.com/slides/nl/python-net/aspose.slides/sensitivitylabel/content_mark_types/).

Het volgende voorbeeld voegt een handmatig geselecteerd etiket toe dat is gekoppeld aan voettekst‑ en watermerk‑markeringen, en slaat vervolgens het resultaat op als PPTX:

```python
import uuid
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    sensitivity_labels = presentation.sensitivity_labels

    label_identifier = "{11111111-2222-3333-4444-555555555555}"
    site_identifier = uuid.UUID("aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee")
    is_enabled = True
    assignment_method = slides.SensitivityLabelAssignmentType.PRIVILEGED

    sensitivity_label = sensitivity_labels.add(
        label_identifier,
        site_identifier,
        is_enabled,
        assignment_method
    )

    sensitivity_label.content_mark_types.append(slides.SensitivityLabelContentType.FOOTER)
    sensitivity_label.content_mark_types.append(slides.SensitivityLabelContentType.WATERMARK)

    presentation.save("presentation_with_label.pptx", slides.export.SaveFormat.PPTX)
```

## **Werk een gevoeligheidsetiket bij**

De eigenschappen van [SensitivityLabel](https://reference.aspose.com/slides/nl/python-net/aspose.slides/sensitivitylabel/) zijn lees‑/schrijfbaar, behalve dat de lijst die wordt geretourneerd door [SensitivityLabel.content_mark_types](https://reference.aspose.com/slides/nl/python-net/aspose.slides/sensitivitylabel/content_mark_types/) wordt aangepast via zijn lijst‑operaties. Nadat u het gewenste etiket hebt gevonden, kunt u de identifier, site‑identifier, ingeschakelde status, toewijzingsmethode, verwijderingsstatus en contentmarkeringstypen bijwerken. Sla de presentatie op om de wijzigingen te bewaren.

Het volgende voorbeeld werkt de ingeschakelde status en toewijzingsmethode van het eerste etiket bij:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    sensitivity_labels = presentation.sensitivity_labels

    if sensitivity_labels.count > 0:
        sensitivity_label = sensitivity_labels[0]
        sensitivity_label.is_enabled = True
        sensitivity_label.assignment_method_type = (
            slides.SensitivityLabelAssignmentType.PRIVILEGED
        )

    presentation.save("presentation_with_updated_label.pptx", slides.export.SaveFormat.PPTX)
```

## **Markeer een gevoeligheidsetiket als verwijderd**

Om het feit te behouden dat een etiket is verwijderd, zoek het etiket en stel [SensitivityLabel.is_removed](https://reference.aspose.com/slides/nl/python-net/aspose.slides/sensitivitylabel/is_removed/) in op `True`. Dit behoudt de etiket‑entry terwijl de verwijderingsstatus wordt geregistreerd. Als u in plaats daarvan een entry uit de moderne collectie wilt verwijderen, gebruik dan [SensitivityLabelCollection.remove_at](https://reference.aspose.com/slides/nl/python-net/aspose.slides/sensitivitylabelcollection/remove_at/); gebruik [SensitivityLabelCollection.clear](https://reference.aspose.com/slides/nl/python-net/aspose.slides/sensitivitylabelcollection/clear/) om elke entry te verwijderen.

Het volgende voorbeeld markeert een specifiek etiket als verwijderd en slaat de bijgewerkte presentatie op:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    sensitivity_labels = presentation.sensitivity_labels
    target_label_identifier = "{11111111-2222-3333-4444-555555555555}"

    for sensitivity_label in sensitivity_labels:
        identifiers_match = (
            sensitivity_label.id.casefold() == target_label_identifier.casefold()
        )

        if identifiers_match:
            sensitivity_label.is_removed = True
            break

    presentation.save("presentation_with_removed_label.pptx", slides.export.SaveFormat.PPTX)
```

## **Lees en migreer legacy MIP gevoeligheidsetiketten**

Oudere MIP‑gebaseerde workflows kunnen metadata van gevoeligheidsetiketten opslaan in aangepaste documenteigenschappen in plaats van in de moderne etiketcollectie. Lees die metadata met [DocumentProperties.get_sensitivity_labels](https://reference.aspose.com/slides/nl/python-net/aspose.slides/documentproperties/get_sensitivity_labels/). De methode parseert de legacy‑custom‑properties en retourneert [SensitivityLabel](https://reference.aspose.com/slides/nl/python-net/aspose.slides/sensitivitylabel/)‑objecten.

Om de metadata te migreren, voeg elk geretourneerd etiket toe aan de moderne [SensitivityLabelCollection](https://reference.aspose.com/slides/nl/python-net/aspose.slides/sensitivitylabelcollection/) via [SensitivityLabelCollection.add](https://reference.aspose.com/slides/nl/python-net/aspose.slides/sensitivitylabelcollection/add/). Omdat het toevoegen van een duplicate etiket‑identifier een uitzondering veroorzaakt, controleert het voorbeeld de doelsamenstelling voordat elk etiket wordt gekopieerd. U kunt extra validatie toevoegen om te bevestigen dat elk legacy‑etiket nog steeds bestaat in het huidige Purview‑beleid.

```python
import aspose.slides as slides

with slides.Presentation("presentation_with_legacy_labels.pptx") as presentation:
    legacy_sensitivity_labels = (
        presentation.document_properties.get_sensitivity_labels()
    )
    modern_sensitivity_labels = presentation.sensitivity_labels

    for legacy_sensitivity_label in legacy_sensitivity_labels:
        label_already_exists = False

        for modern_sensitivity_label in modern_sensitivity_labels:
            label_already_exists = (
                modern_sensitivity_label.id.casefold()
                == legacy_sensitivity_label.id.casefold()
            )

            if label_already_exists:
                break

        if not label_already_exists:
            modern_sensitivity_labels.add(legacy_sensitivity_label)

    presentation.save("presentation_with_modern_labels.pptx", slides.export.SaveFormat.PPTX)
```

De migratie kopieert de geparseerde etiket‑objecten naar de moderne collectie. Het vereist niet dat alle aangepaste documenteigenschappen worden gewist, zodat niet‑gerelateerde documentmetadata intact blijven. Gebruik [Presentation.save](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentation/save/) met [SaveFormat.PPTX](https://reference.aspose.com/slides/nl/python-net/aspose.slides.export/saveformat/) om de moderne etikmetadata naar een PPTX‑bestand te schrijven.

## **FAQ**

**Veroorzaakt het toevoegen van een contentmarkeringstype een zichtbaar koptekst, voettekst of watermerk op dia’s?**  

Nee. Waarden die via [SensitivityLabel.content_mark_types](https://reference.aspose.com/slides/nl/python-net/aspose.slides/sensitivitylabel/content_mark_types/) worden toegevoegd, beschrijven de markeringen die aan het gevoeligheidsetiket zijn gekoppeld. Ze creëren geen zichtbare tekst of vormen in de presentatie. Voeg de bijbehorende dia‑inhoud apart toe als uw workflow die markeringen moet renderen.

**Wat is het verschil tussen een etiket markeren als verwijderd en het uit de collectie verwijderen?**  

Het instellen van [SensitivityLabel.is_removed](https://reference.aspose.com/slides/nl/python-net/aspose.slides/sensitivitylabel/is_removed/) op `True` behoudt de etiket‑entry en registreert de verwijderingsstatus. Het aanroepen van [SensitivityLabelCollection.remove_at](https://reference.aspose.com/slides/nl/python-net/aspose.slides/sensitivitylabelcollection/remove_at/) verwijdert de entry uit de moderne collectie. Kies de bewerking die past bij de metadata‑retentie‑eisen van uw organisatie.

**Kan een presentatie zowel legacy MIP‑metadata als moderne gevoeligheidsetiketten bevatten?**  

Ja. Legacy‑etiketten kunnen blijven bestaan in aangepaste documenteigenschappen, terwijl moderne etiketten beschikbaar zijn via [Presentation.sensitivity_labels](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentation/sensitivity_labels/). Gebruik [DocumentProperties.get_sensitivity_labels](https://reference.aspose.com/slides/nl/python-net/aspose.slides/documentproperties/get_sensitivity_labels/) om de legacy‑metadata te lezen en migreer alleen de valide etiketten die nog niet aanwezig zijn in de moderne collectie.

**Wat gebeurt er wanneer een etiket met dezelfde identifier meer dan eens wordt toegevoegd?**  

[SensitivityLabelCollection.add](https://reference.aspose.com/slides/nl/python-net/aspose.slides/sensitivitylabelcollection/add/) geeft een uitzondering wanneer de collectie al een etiket met dezelfde identifier bevat. Controleer bestaande [SensitivityLabel.id](https://reference.aspose.com/slides/nl/python-net/aspose.slides/sensitivitylabel/id/)‑waarden voordat u etiketten toevoegt of migreert.

**Welk output‑formaat moet worden gebruikt om bijgewerkte gevoeligheidsetiketten te behouden?**  

Sla de presentatie op als PPTX door [Presentation.save](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentation/save/) aan te roepen met [SaveFormat.PPTX](https://reference.aspose.com/slides/nl/python-net/aspose.slides.export/saveformat/), zoals getoond in de voorbeelden hierboven.