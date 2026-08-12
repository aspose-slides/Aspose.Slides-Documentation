---
title: Hantera känslighetsetiketter i PowerPoint-presentationer i Python
linktitle: Känslighetsetiketter
type: docs
weight: 50
url: /sv/python-net/sensitivity-labels/
keywords:
- känslighetsetikett
- Microsoft Purview
- Microsoft Information Protection
- MIP-metadata
- innehållsmärkning
- informationsskydd
- dokumentstyrning
- PowerPoint
- PPTX
- presentationssäkerhet
- Python
- Aspose.Slides
description: "Läs, lägg till, uppdatera, ta bort och migrera Microsoft Purview‑känslighetsetiketter i PowerPoint‑PPTX‑presentationer med Aspose.Slides för Python via .NET."
---
## **Översikt**

Microsoft Purview‑känslighetsetiketter hjälper organisationer att klassificera och hantera dokument. Under automatiserad presentationbearbetning kan en applikation behöva bevara en befintlig etikett, tillämpa en etikett som valts av en policy, uppdatera dess tillstånd eller migrera etiketmetadata som skrivits av ett äldre Microsoft Information Protection (MIP)‑arbetsflöde.

Aspose.Slides for Python via .NET exponerar modern känslighetsetikettmetadata genom [Presentation.sensitivity_labels](https://reference.aspose.com/slides/sv/python-net/aspose.slides/presentation/sensitivity_labels/). Denna egenskap returnerar en [SensitivityLabelCollection](https://reference.aspose.com/slides/sv/python-net/aspose.slides/sensitivitylabelcollection/) som kan inspekteras och ändras innan presentationen sparas som PPTX.

{{% alert color="primary" title="Obs" %}}
Känslighetsetikettidentifierare och policyinformation definieras av din Microsoft Purview‑konfiguration. Validera etikettens tillgänglighet och policykrav i din miljö innan du lägger till eller migrerar metadata. Värdena i [SensitivityLabel.content_mark_types](https://reference.aspose.com/slides/sv/python-net/aspose.slides/sensitivitylabel/content_mark_types/) beskriver de innehållsmärkningar som är kopplade till en etikett; de skapar inte i sig synlig text eller former på bilderna.
{{% /alert %}}

## **Förstå egenskaper för känslighetsetikett**

Varje [SensitivityLabel](https://reference.aspose.com/slides/sv/python-net/aspose.slides/sensitivitylabel/) innehåller följande metadata:

| Egenskap | Syfte |
| --- | --- |
| [SensitivityLabel.id](https://reference.aspose.com/slides/sv/python-net/aspose.slides/sensitivitylabel/id/) | Identifierar känslighetsetiketten i Purview‑policyn. |
| [SensitivityLabel.site_id](https://reference.aspose.com/slides/sv/python-net/aspose.slides/sensitivitylabel/site_id/) | Identifierar webbplatsen som är associerad med etikettpolicyn. |
| [SensitivityLabel.is_enabled](https://reference.aspose.com/slides/sv/python-net/aspose.slides/sensitivitylabel/is_enabled/) | Anger om etiketten är aktiverad. |
| [SensitivityLabel.is_removed](https://reference.aspose.com/slides/sv/python-net/aspose.slides/sensitivitylabel/is_removed/) | Anger att etiketten har tagits bort. Sätt denna egenskap till `True` när borttagningsstatusen måste behållas i metadata. |
| [SensitivityLabel.assignment_method_type](https://reference.aspose.com/slides/sv/python-net/aspose.slides/sensitivitylabel/assignment_method_type/) | Specificerar om etiketten tillämpades automatiskt eller genom ett användarbeslut. |
| [SensitivityLabel.content_mark_types](https://reference.aspose.com/slides/sv/python-net/aspose.slides/sensitivitylabel/content_mark_types/) | Listar de innehållsmärkningstyper som är associerade med etiketten. |

Enumeringen [SensitivityLabelAssignmentType](https://reference.aspose.com/slides/sv/python-net/aspose.slides/sensitivitylabelassignmenttype/) beskriver hur en etikett tilldelades:

- [SensitivityLabelAssignmentType.STANDARD](https://reference.aspose.com/slides/sv/python-net/aspose.slides/sensitivitylabelassignmenttype/) representerar en standard- eller automatiskt tillämpad etikett.
- [SensitivityLabelAssignmentType.PRIVILEGED](https://reference.aspose.com/slides/sv/python-net/aspose.slides/sensitivitylabelassignmenttype/) representerar en etikett som tillämpats genom ett användarbeslut, inklusive manuellt tillämpade, rekommenderade och obligatoriska etiketter.

Enumeringen [SensitivityLabelContentType](https://reference.aspose.com/slides/sv/python-net/aspose.slides/sensitivitylabelcontenttype/) identifierar den märkning som är associerad med en etikett:

| Värde | Betydelse |
| --- | --- |
| [SensitivityLabelContentType.NONE](https://reference.aspose.com/slides/sv/python-net/aspose.slides/sensitivitylabelcontenttype/) | Etiketten tillämpades som standard eller automatiskt. |
| [SensitivityLabelContentType.HEADER](https://reference.aspose.com/slides/sv/python-net/aspose.slides/sensitivitylabelcontenttype/) | Rubrikens innehållsmärkning är associerad med etiketten. |
| [SensitivityLabelContentType.FOOTER](https://reference.aspose.com/slides/sv/python-net/aspose.slides/sensitivitylabelcontenttype/) | Sidfotens innehållsmärkning är associerad med etiketten. |
| [SensitivityLabelContentType.WATERMARK](https://reference.aspose.com/slides/sv/python-net/aspose.slides/sensitivitylabelcontenttype/) | Vattenstämpelns innehållsmärkning är associerad med etiketten. |
| [SensitivityLabelContentType.ENCRYPTION](https://reference.aspose.com/slides/sv/python-net/aspose.slides/sensitivitylabelcontenttype/) | Krypteringsskydd är associerat med etiketten. |

Flera märkningstyper kan vara associerade med en etikett.

## **Lista befintliga känslighetsetiketter**

Läs den moderna etikettcollectionen från [Presentation.sensitivity_labels](https://reference.aspose.com/slides/sv/python-net/aspose.slides/presentation/sensitivity_labels/) och enumerera den. Följande exempel listar varje egenskap och innehållsmärkning som lagras för varje etikett:

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

## **Lägg till en känslighetsetikett med innehållsmärkning**

Använd [SensitivityLabelCollection.add](https://reference.aspose.com/slides/sv/python-net/aspose.slides/sensitivitylabelcollection/add/) med etikettens identifierare, platsidentifierare, aktiverat tillstånd och tilldelningsmetod. Skicka platsidentifieraren som ett Python `uuid.UUID`‑objekt. När metoden returnerar den nya [SensitivityLabel](https://reference.aspose.com/slides/sv/python-net/aspose.slides/sensitivitylabel/), lägg till de erforderliga märkningsvärdena till [SensitivityLabel.content_mark_types](https://reference.aspose.com/slides/sv/python-net/aspose.slides/sensitivitylabel/content_mark_types/).

Följande exempel lägger till en manuellt vald etikett som är associerad med sidfot‑ och vattenstämpelmärkningar och sparar sedan resultatet som PPTX:

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

## **Uppdatera en känslighetsetikett**

[Egenskaperna] för [SensitivityLabel](https://reference.aspose.com/slides/sv/python-net/aspose.slides/sensitivitylabel/) är läsbara och skrivbara, förutom att listan som returneras av [SensitivityLabel.content_mark_types](https://reference.aspose.com/slides/sv/python-net/aspose.slides/sensitivitylabel/content_mark_types/) modifieras via dess listoperationer. Efter att ha lokaliserat den önskade etiketten kan du uppdatera dess identifierare, platsidentifierare, aktiverade tillstånd, tilldelningsmetod, borttagningsstatus och innehållsmärknings‑typer. Spara presentationen för att bestå ändringarna.

Följande exempel uppdaterar det aktiverade tillståndet och tilldelningsmetoden för den första etiketten:

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

## **Markera en känslighetsetikett som borttagen**

För att bevara faktumet att en etikett har tagits bort, hitta etiketten och sätt [SensitivityLabel.is_removed](https://reference.aspose.com/slides/sv/python-net/aspose.slides/sensitivitylabel/is_removed/) till `True`. Detta behåller etikettposten samtidigt som borttagningsstatusen registreras. Om du istället måste radera en post från den moderna collectionen, använd [SensitivityLabelCollection.remove_at](https://reference.aspose.com/slides/sv/python-net/aspose.slides/sensitivitylabelcollection/remove_at/); använd [SensitivityLabelCollection.clear](https://reference.aspose.com/slides/sv/python-net/aspose.slides/sensitivitylabelcollection/clear/) för att radera varje post.

Följande exempel markerar en specifik etikett som borttagen och sparar den uppdaterade presentationen:

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

## **Läs och migrera äldre MIP‑känslighetsetiketter**

Äldre MIP‑baserade arbetsflöden kan lagra känslighetsetikettmetadata i anpassade dokument‑egenskaper i stället för den moderna etikettcollectionen. Läs den metadata med [DocumentProperties.get_sensitivity_labels](https://reference.aspose.com/slides/sv/python-net/aspose.slides/documentproperties/get_sensitivity_labels/). Metoden parsar de äldre anpassade egenskaperna och returnerar [SensitivityLabel](https://reference.aspose.com/slides/sv/python-net/aspose.slides/sensitivitylabel/)-objekt.

För att migrera metadata, lägg till varje returnerad etikett i den moderna [SensitivityLabelCollection](https://reference.aspose.com/slides/sv/python-net/aspose.slides/sensitivitylabelcollection/) via [SensitivityLabelCollection.add](https://reference.aspose.com/slides/sv/python-net/aspose.slides/sensitivitylabelcollection/add/). Eftersom ett duplicerat etikettidentifierare kastar ett undantag, kontrollerar exemplet destination‑collectionen innan varje etikett kopieras. Du kan lägga till ytterligare validering för att bekräfta att varje äldre etikett fortfarande finns i den aktuella Purview‑policyn.

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

Migreringen kopierar de parsade etiketobjekten till den moderna collectionen. Det kräver inte att alla anpassade dokumentegenskaper rensas, så orelaterad dokumentmetadata förblir intakt. Använd [Presentation.save](https://reference.aspose.com/slides/sv/python-net/aspose.slides/presentation/save/) med [SaveFormat.PPTX](https://reference.aspose.com/slides/sv/python-net/aspose.slides.export/saveformat/) för att skriva den moderna etikettmetadata till en PPTX‑fil.

## **Vanliga frågor**

**Skapar tillägg av en innehållsmärkningstyp ett synligt huvud, en sidfot eller en vattenstämpel på bilderna?**

Nej. Värden som läggs till via [SensitivityLabel.content_mark_types](https://reference.aspose.com/slides/sv/python-net/aspose.slides/sensitivitylabel/content_mark_types/) beskriver de märkningar som är associerade med känslighetsetiketten. De skapar inte synlig text eller former i presentationen. Lägg till motsvarande bildinnehåll separat om ditt arbetsflöde måste rendera dessa märkningar.

**Vad är skillnaden mellan att markera en etikett som borttagen och att radera den från collectionen?**

Att sätta [SensitivityLabel.is_removed](https://reference.aspose.com/slides/sv/python-net/aspose.slides/sensitivitylabel/is_removed/) till `True` behåller etikettposten och registrerar dess borttagningsstatus. Att anropa [SensitivityLabelCollection.remove_at](https://reference.aspose.com/slides/sv/python-net/aspose.slides/sensitivitylabelcollection/remove_at/) tar bort posten från den moderna collectionen. Välj den operation som matchar din organisations krav på metadata‑behållning.

**Kan en presentation innehålla både äldre MIP‑metadata och moderna känslighetsetiketter?**

Ja. Äldre etiketter kan finnas kvar i anpassade dokumentegenskaper medan moderna etiketter är tillgängliga via [Presentation.sensitivity_labels](https://reference.aspose.com/slides/sv/python-net/aspose.slides/presentation/sensitivity_labels/). Använd [DocumentProperties.get_sensitivity_labels](https://reference.aspose.com/slides/sv/python-net/aspose.slides/documentproperties/get_sensitivity_labels/) för att läsa den äldre metadata och migrera endast de giltiga etiketter som ännu inte finns i den moderna collectionen.

**Vad händer när en etikett med samma identifierare läggs till mer än en gång?**

[SensitivityLabelCollection.add](https://reference.aspose.com/slides/sv/python-net/aspose.slides/sensitivitylabelcollection/add/) kastar ett undantag när collectionen redan innehåller en etikett med samma identifierare. Kontrollera befintliga [SensitivityLabel.id](https://reference.aspose.com/slides/sv/python-net/aspose.slides/sensitivitylabel/id/)‑värden innan du lägger till eller migrerar etiketter.

**Vilket utdataformat bör användas för att bevara uppdaterade känslighetsetiketter?**

Spara presentationen som PPTX genom att anropa [Presentation.save](https://reference.aspose.com/slides/sv/python-net/aspose.slides/presentation/save/) med [SaveFormat.PPTX](https://reference.aspose.com/slides/sv/python-net/aspose.slides.export/saveformat/), som visas i exemplen ovan.