---
title: Hantera sensitivitetsetiketter i PowerPoint-presentationer i Python
linktitle: Sensitivitetsetiketter
type: docs
weight: 50
url: /sv/python-java/sensitivity-labels/
keywords:
- sensitivitetsetikett
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
description: "Läs, lägg till, uppdatera, ta bort och migrera Microsoft Purview-sensitivitetsetiketter i PowerPoint PPTX-presentationer med Aspose.Slides för Python via Java."
---
## **Översikt**

Microsoft Purview‑sensivitetsetiketter hjälper organisationer att klassificera och styra dokument. Vid automatiserad presentationbearbetning kan en applikation behöva bevara en befintlig etikett, tillämpa en etikett som valts av en policy, uppdatera dess tillstånd eller migrera etikettdatametadata som skrivits av ett äldre Microsoft Information Protection (MIP)-arbetsflöde.

Aspose.Slides exponerar modern metadata för sensitivitetsetiketter via [Presentation.getSensitivityLabels](https://reference.aspose.com/slides/sv/python-java/aspose.slides/presentation/#getSensitivityLabels). Denna metod returnerar en [SensitivityLabelCollection](https://reference.aspose.com/slides/sv/python-java/aspose.slides/sensitivitylabelcollection/) som kan inspekteras och ändras innan presentationen sparas som PPTX.

{{% alert color="info" title="Note" %}}
Sensitivitetsetikettidentifierare och policyinformation definieras av din Microsoft Purview‑konfiguration. Validera etikettens tillgänglighet och policys krav i din miljö innan du lägger till eller migrerar metadata. Värdena för [SensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/sv/python-java/aspose.slides/sensitivitylabel/#getContentMarkTypes) beskriver de innehållsmärkningar som är kopplade till en etikett; de lägger inte själva till synlig text eller former i bilder.
{{% /alert %}}

## **Förstå egenskaper för sensitivitetsetiketter**

Varje [SensitivityLabel](https://reference.aspose.com/slides/sv/python-java/aspose.slides/sensitivitylabel/) innehåller följande metadata:

| Metoder | Syfte |
| --- | --- |
| [getId](https://reference.aspose.com/slides/sv/python-java/aspose.slides/sensitivitylabel/#getId) och [setId](https://reference.aspose.com/slides/sv/python-java/aspose.slides/sensitivitylabel/#setId) | Hämta eller sätt sensitivitetsetikettidentifieraren i Purview‑policyn. |
| [getSiteId](https://reference.aspose.com/slides/sv/python-java/aspose.slides/sensitivitylabel/#getSiteId) och [setSiteId](https://reference.aspose.com/slides/sv/python-java/aspose.slides/sensitivitylabel/#setSiteId) | Hämta eller sätt webbplatsen som är associerad med etikettpolicyn. |
| [isEnabled](https://reference.aspose.com/slides/sv/python-java/aspose.slides/sensitivitylabel/#isEnabled) och [setEnabled](https://reference.aspose.com/slides/sv/python-java/aspose.slides/sensitivitylabel/#setEnabled) | Hämta eller sätt huruvida etiketten är aktiverad. |
| [isRemoved](https://reference.aspose.com/slides/sv/python-java/aspose.slides/sensitivitylabel/#isRemoved) och [setRemoved](https://reference.aspose.com/slides/sv/python-java/aspose.slides/sensitivitylabel/#setRemoved) | Hämta eller sätt huruvida etiketten har tagits bort. Sätt värdet till `True` när borttagningsstatusen måste behållas i metadata. |
| [getAssignmentMethodType](https://reference.aspose.com/slides/sv/python-java/aspose.slides/sensitivitylabel/#getAssignmentMethodType) och [setAssignmentMethodType](https://reference.aspose.com/slides/sv/python-java/aspose.slides/sensitivitylabel/#setAssignmentMethodType) | Hämta eller sätt huruvida etiketten tillämpades automatiskt eller genom ett användarbeslut. |
| [getContentMarkTypes](https://reference.aspose.com/slides/sv/python-java/aspose.slides/sensitivitylabel/#getContentMarkTypes) | Hämta de innehållsmärkningstyper som är associerade med etiketten. |

Klassen [SensitivityLabelAssignmentType](https://reference.aspose.com/slides/sv/python-java/aspose.slides/sensitivitylabelassignmenttype/) definierar hur en etikett tilldelades:

- [Standard](https://reference.aspose.com/slides/sv/python-java/aspose.slides/sensitivitylabelassignmenttype/) representerar en standard eller automatiskt tillämpad etikett.
- [Privileged](https://reference.aspose.com/slides/sv/python-java/aspose.slides/sensitivitylabelassignmenttype/) representerar en etikett som tillämpats genom ett användarbeslut, inklusive manuellt tillämpade, rekommenderade och obligatoriska etiketter.

Klassen [SensitivityLabelContentType](https://reference.aspose.com/slides/sv/python-java/aspose.slides/sensitivitylabelcontenttype/) definierar märkning som är associerad med en etikett:

| Värde | Betydelse |
| --- | --- |
| [None](https://reference.aspose.com/slides/sv/python-java/aspose.slides/sensitivitylabelcontenttype/) | Etiketten tillämpades som standard eller automatiskt. |
| [Header](https://reference.aspose.com/slides/sv/python-java/aspose.slides/sensitivitylabelcontenttype/) | Rubrikinnehållsmärkning är associerad med etiketten. |
| [Footer](https://reference.aspose.com/slides/sv/python-java/aspose.slides/sensitivitylabelcontenttype/) | Fotnotinnehållsmärkning är associerad med etiketten. |
| [Watermark](https://reference.aspose.com/slides/sv/python-java/aspose.slides/sensitivitylabelcontenttype/) | Vattenstämpelinnehållsmärkning är associerad med etiketten. |
| [Encryption](https://reference.aspose.com/slides/sv/python-java/aspose.slides/sensitivitylabelcontenttype/) | Krypteringsskydd är associerat med etiketten. |

Flera märknings typer kan vara associerade med en etikett.

## **Lista befintliga sensitivitetsetiketter**

Läs den moderna etikettkollektionen från [Presentation.getSensitivityLabels](https://reference.aspose.com/slides/sv/python-java/aspose.slides/presentation/#getSensitivityLabels) och iterera igenom den. Följande exempel listar varje egenskap och innehållsmärkning som lagras för varje etikett:

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

## **Lägg till en sensitivitetsetikett med innehållsmärkning**

Använd [SensitivityLabelCollection.add](https://reference.aspose.com/slides/sv/python-java/aspose.slides/sensitivitylabelcollection/#add) med etikettidentifieraren, webbplatsidentifieraren, aktiveringsstatusen och tilldelningsmetoden. När metoden returnerar den nya [SensitivityLabel](https://reference.aspose.com/slides/sv/python-java/aspose.slides/sensitivitylabel/), lägg till de erforderliga märkningsvärdena via listan som returneras av [SensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/sv/python-java/aspose.slides/sensitivitylabel/#getContentMarkTypes).

Följande exempel lägger till en manuellt vald etikett som är associerad med fot- och vattenstämpelmärkningar, och sparar sedan resultatet som PPTX:

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

## **Uppdatera en sensitivitetsetikett**

[SensitivityLabel]-värdena är läs-/skrivbara, förutom att listan som returneras av [SensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/sv/python-java/aspose.slides/sensitivitylabel/#getContentMarkTypes) modifieras via dess listoperationer. Efter att ha hittat den önskade etiketten kan du uppdatera dess identifierare, webbplatsidentifierare, aktiveringsstatus, tilldelningsmetod, borttagningsstatus och innehållsmärkningstyper. Spara presentationen för att bestå förändringarna.

Följande exempel uppdaterar aktiveringsstatusen och tilldelningsmetoden för den första etiketten:

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

## **Markera en sensitivitetsetikett som borttagen**

För att bevara att en etikett har tagits bort, hitta etiketten och anropa [SensitivityLabel.setRemoved](https://reference.aspose.com/slides/sv/python-java/aspose.slides/sensitivitylabel/#setRemoved) med `True`. Detta behåller etikettposten samtidigt som dess borttagningsstatus registreras. Om du istället behöver ta bort en post från den moderna kollektionen, använd [SensitivityLabelCollection.removeAt](https://reference.aspose.com/slides/sv/python-java/aspose.slides/sensitivitylabelcollection/#removeAt); använd [SensitivityLabelCollection.clear](https://reference.aspose.com/slides/sv/python-java/aspose.slides/sensitivitylabelcollection/#clear) för att ta bort alla poster.

Följande exempel markerar en specifik etikett som borttagen och sparar den uppdaterade presentationen:

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

## **Läs och migrera äldre MIP-sensitivitetsetiketter**

Äldre MIP‑baserade arbetsflöden kan lagra metadata för sensitivitetsetiketter i anpassade dokumentegenskaper istället för den moderna etikettkollektionen. Läs den metadata med [DocumentProperties.getSensitivityLabels](https://reference.aspose.com/slides/sv/python-java/aspose.slides/documentproperties/#getSensitivityLabels). Metoden parsar de äldre anpassade egenskaperna och returnerar en array av [SensitivityLabel]-objekt.

För att migrera metadata, lägg till varje returnerad etikett i den moderna [SensitivityLabelCollection](https://reference.aspose.com/slides/sv/python-java/aspose.slides/sensitivitylabelcollection/) via [SensitivityLabelCollection.add](https://reference.aspose.com/slides/sv/python-java/aspose.slides/sensitivitylabelcollection/#add). Eftersom tillägg av en duplicerad etikettidentifierare kastar ett undantag, kontrollerar exemplet målkollektionen innan varje etikett kopieras. Du kan lägga till ytterligare validering för att bekräfta att varje äldre etikett fortfarande finns i den aktuella Purview‑policyn.

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

Migreringen kopierar de parsade etikettobjekten till den moderna kollektionen. Det kräver inte att alla anpassade dokumentegenskaper rensas, så orelaterad dokumentmetadata förblir intakt. Använd [Presentation.save](https://reference.aspose.com/slides/sv/python-java/aspose.slides/presentation/#save) med [SaveFormat.Pptx](https://reference.aspose.com/slides/sv/python-java/aspose.slides/saveformat/) för att skriva den moderna etikettdatametadata till en PPTX‑fil.

## **FAQ**

**Skapar tillägg av en innehållsmärkningstyp en synlig rubrik, fot eller vattenstämpel på bilder?**

Nej. Värden som läggs till via listan som returneras av [SensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/sv/python-java/aspose.slides/sensitivitylabel/#getContentMarkTypes) beskriver de märkningar som är associerade med sensitivitetsetiketten. De skapar ingen synlig text eller former i presentationen. Lägg till motsvarande bildinnehåll separat om ditt arbetsflöde måste rendera dessa märkningar.

**Vad är skillnaden mellan att markera en etikett som borttagen och att ta bort den från kollektionen?**

Att anropa [SensitivityLabel.setRemoved](https://reference.aspose.com/slides/sv/python-java/aspose.slides/sensitivitylabel/#setRemoved) med `True` behåller etikettposten och registrerar dess borttagningsstatus. Att anropa [SensitivityLabelCollection.removeAt](https://reference.aspose.com/slides/sv/python-java/aspose.slides/sensitivitylabelcollection/#removeAt) tar bort posten från den moderna kollektionen. Välj den operation som motsvarar din organisations krav på metadata‑bevarande.

**Kan en presentation innehålla både äldre MIP-metadata och moderna sensitivitetsetiketter?**

Ja. Äldre etiketter kan finnas kvar i anpassade dokumentegenskaper medan moderna etiketter är tillgängliga via [Presentation.getSensitivityLabels](https://reference.aspose.com/slides/sv/python-java/aspose.slides/presentation/#getSensitivityLabels). Använd [DocumentProperties.getSensitivityLabels](https://reference.aspose.com/slides/sv/python-java/aspose.slides/documentproperties/#getSensitivityLabels) för att läsa den äldre metadata och migrera endast de giltiga etiketter som ännu inte finns i den moderna kollektionen.

**Vad händer när en etikett med samma identifierare läggs till mer än en gång?**

[SensitivityLabelCollection.add](https://reference.aspose.com/slides/sv/python-java/aspose.slides/sensitivitylabelcollection/#add) kastar ett undantag när kollektionen redan innehåller en etikett med samma identifierare. Kontrollera befintliga värden som returneras av [SensitivityLabel.getId](https://reference.aspose.com/slides/sv/python-java/aspose.slides/sensitivitylabel/#getId) innan du lägger till eller migrerar etiketter.

**Vilket utdataformat bör användas för att bevara uppdaterade sensitivitetsetiketter?**

Spara presentationen som PPTX genom att anropa [Presentation.save](https://reference.aspose.com/slides/sv/python-java/aspose.slides/presentation/#save) med [SaveFormat.Pptx](https://reference.aspose.com/slides/sv/python-java/aspose.slides/saveformat/), som visas i exemplen ovan.