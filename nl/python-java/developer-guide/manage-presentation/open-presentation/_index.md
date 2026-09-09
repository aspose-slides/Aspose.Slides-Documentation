---
title: Presentaties openen in Python via Java
linktitle: Presentatie openen
type: docs
weight: 20
url: /nl/python-java/open-presentation/
keywords:
- PowerPoint openen
- presentatie openen
- PPTX openen
- PPT openen
- ODP openen
- presentatie laden
- PPTX laden
- PPT laden
- ODP laden
- beveiligde presentatie
- grote presentatie
- externe bron
- binair object
- Python
- Java
- Aspose.Slides
description: "Leer hoe u PowerPoint- en OpenDocument‑presentaties kunt openen in Python via Java, openings‑wachtwoorden kunt opgeven, het laden van bronnen kunt beheersen en het geheugenverbruik kunt verminderen met Aspose.Slides voor Python via Java."
---
## **Introductie**

[Aspose.Slides for Python via Java](https://products.aspose.com/slides/nl/python-java/) kan PowerPoint‑ en OpenDocument‑presentaties laden vanuit bestanden en streams. Nadat een presentatie is geladen, kunt u de structuur inspecteren, dia’s bewerken, bronnen beheren en deze opslaan in het oorspronkelijke of een ander ondersteund formaat.

Het laadgedrag kan worden aangepast via de [LoadOptions](https://reference.aspose.com/slides/nl/python-java/aspose.slides/loadoptions/)‑klasse. U kunt bijvoorbeeld een openings‑wachtwoord opgeven, grote binaire objecten buiten het Java‑heapgeheugen houden, externe bronnen beheren of ingebedde binaire gegevens weglaten.

## **Open Presentaties**

Om een bestaande presentatie te openen, geeft u het bestandspad door aan de [Presentation](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentation/)‑constructor. Maak de presentatie vrij nadat u deze hebt gebruikt, zodat bestands‑handles, tijdelijke gegevens en andere bronnen direct worden vrijgegeven.

De volgende Python‑voorbeeld laat zien hoe u een presentatie opent en het aantal dia's opvraagt:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("sample.pptx")
try:
    print("Slide count:", presentation.getSlides().size())
finally:
    presentation.dispose()
```

## **Open wachtwoord‑beveiligde presentaties**

Een openings‑wachtwoord versleutelt de inhoud van de presentatie. Om de volledige presentatie te laden, geeft u het juiste wachtwoord door aan [LoadOptions.setPassword](https://reference.aspose.com/slides/nl/python-java/aspose.slides/loadoptions/#setPassword) en levert u de opties aan de [Presentation](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentation/)‑constructor. Het laden mislukt wanneer het wachtwoord ontbreekt of onjuist is.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LoadOptions, Presentation

load_options = LoadOptions()
load_options.setPassword("open_password")

presentation = Presentation("encrypted-presentation.pptx", load_options)
try:
    print("Slide count:", presentation.getSlides().size())
finally:
    presentation.dispose()
```

Voor wachtwoord‑detectie, validatie en versleutelings‑workflows, zie [Wachtwoord‑beveiligde presentaties](/slides/nl/python-java/password-protected-presentation/). Als een versleutelde presentatie opzettelijk is opgeslagen met openbare documenteigenschappen, kunnen die eigenschappen worden gelezen zonder wachtwoord; zie [Presentatie‑eigenschappen beheren](/slides/nl/python-java/presentation-properties/).

## **Open grote presentaties**

De [LoadOptions.getBlobManagementOptions](https://reference.aspose.com/slides/nl/python-java/aspose.slides/loadoptions/#getBlobManagementOptions)‑methode retourneert opties die bepalen hoe Aspose.Slides binair grote objecten zoals afbeeldingen, audio en video afhandelt. U kunt het bronbestand vergrendeld houden, tijdelijke bestanden toestaan en de hoeveelheid BLOB‑gegevens die in het geheugen worden bewaard beperken.

De volgende Python‑code toont hoe een grote presentatie te laden (bijvoorbeeld 2 GB):

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LoadOptions, Presentation, PresentationLockingBehavior, SaveFormat

file_path = "large-presentation.pptx"

load_options = LoadOptions()
load_options.getBlobManagementOptions().setPresentationLockingBehavior(PresentationLockingBehavior.KeepLocked)
load_options.getBlobManagementOptions().setTemporaryFilesAllowed(True)
load_options.getBlobManagementOptions().setMaxBlobsBytesInMemory(10 * 1024 * 1024)

presentation = Presentation(file_path, load_options)
try:
    presentation.getSlides().get_Item(0).setName("Large presentation")
    presentation.save("large-presentation-copy.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

{{% alert color="info" title="Note" %}}
Met [PresentationLockingBehavior.KeepLocked](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentationlockingbehavior/#KeepLocked) blijft het bronbestand vergrendeld totdat de presentatie‑instantie wordt vrijgegeven. Verplaats, overschrijf of verwijder het bronbestand niet zolang die instantie bestaat.

Aspose.Slides kan de inhoud van een invoerstroom kopiëren tijdens het laden. Voor grote presentaties is een bestandspad daarom doorgaans efficiënter dan een stream. Zie [Manage BLOBs](/slides/nl/python-java/manage-blob/) voor extra opslag‑ en geheugenbeheeropties.
{{% /alert %}}

## **Beheer externe bronnen**

De [LoadOptions.setResourceLoadingCallback](https://reference.aspose.com/slides/nl/python-java/aspose.slides/loadoptions/#setResourceLoadingCallback) accepteert een JPype‑proxy die de Java‑resource‑laadcallback‑interface implementeert. De callback kan vervangende gegevens leveren, een bron omleiden, de standaardladder gebruiken of de bron overslaan. Dit is nuttig wanneer presentaties externe afbeeldingen bevatten die volgens toepassings‑specifieke beveiligings‑ of opslagregels moeten worden opgelost.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from pathlib import Path
from asposeslides.api import LoadOptions, Presentation, ResourceLoadingAction

class ImageLoadingHandler:
    def resourceLoading(self, resource_loading_arguments):
        is_jpeg = str(resource_loading_arguments.getOriginalUri()).lower().endswith(".jpg")
        approved_image_path = Path("approved-image.jpg")
        if not is_jpeg or not approved_image_path.exists():
            return ResourceLoadingAction.Skip

        try:
            image_data = approved_image_path.read_bytes()
            java_image_data = jpype.JArray(jpype.JByte)(image_data)
            resource_loading_arguments.setData(java_image_data)
            return ResourceLoadingAction.UserProvided
        except OSError:
            print("The approved replacement image could not be read.")
            return ResourceLoadingAction.Skip

load_options = LoadOptions()
image_loading_handler = ImageLoadingHandler()
callback = jpype.JProxy("com.aspose.slides.IResourceLoadingCallback", inst=image_loading_handler)
load_options.setResourceLoadingCallback(callback)

presentation = Presentation("presentation-with-external-images.pptx", load_options)
try:
    print("Slide count:", presentation.getSlides().size())
finally:
    presentation.dispose()
```

## **Laad presentaties zonder ingebedde binaire objecten**

Een presentatie kan ingebedde binaire gegevens bevatten die een toepassing niet nodig heeft of niet wil behouden. Voorbeelden zijn:

- VBA‑projecten, beschikbaar via [Presentation.getVbaProject](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentation/#getVbaProject);
- ingebedde OLE‑gegevens, beschikbaar via [OleEmbeddedDataInfo.getEmbeddedFileData](https://reference.aspose.com/slides/nl/python-java/aspose.slides/oleembeddeddatainfo/#getEmbeddedFileData);
- ActiveX‑controlegegevens, beschikbaar via [Control.getActiveXControlBinary](https://reference.aspose.com/slides/nl/python-java/aspose.slides/control/#getActiveXControlBinary).

Stel [LoadOptions.setDeleteEmbeddedBinaryObjects](https://reference.aspose.com/slides/nl/python-java/aspose.slides/loadoptions/#setDeleteEmbeddedBinaryObjects) in op `True` om deze binaire gegevens tijdens het laden te verwijderen. Sla de geladen presentatie op om het opgeschoonde resultaat te behouden.

Deze optie verkleint de blootstelling aan ongewenste ingebedde payloads, maar is geen volledig malware‑detectie‑ of content‑sanitiseringssysteem.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LoadOptions, Presentation, SaveFormat

load_options = LoadOptions()
load_options.setDeleteEmbeddedBinaryObjects(True)

presentation = Presentation("presentation-with-embedded-data.pptx", load_options)
try:
    presentation.save("presentation-without-embedded-data.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Veelgestelde vragen**

**Hoe kan ik bepalen dat een bestand corrupt is en niet geopend kan worden?**

Aspose.Slides gooit tijdens het laden een parser‑ of formaat‑uitzondering. Verwerk deze fout apart van een onjuist‑wachtwoord‑fout, zodat de toepassing de oorzaak nauwkeurig kan melden.

**Wat gebeurt er als vereiste lettertypen ontbreken?**

De presentatie kan nog steeds worden geladen, maar weergave en export kunnen lettertypen vervangen. U kunt [font‑substitutie configureren](/slides/nl/python-java/font-substitution/) of [aangepaste lettertypen leveren](/slides/nl/python-java/custom-font/) om de output voorspelbaarder te maken.

**Laadt het laden van een presentatie ook de ingebedde media?**

Ingebedde audio en video worden beschikbaar via het presentatie‑objectmodel. Externe bronnen worden opgelost volgens het geconfigureerde resource‑laadgedrag en kunnen onbeschikbaar zijn als hun locaties niet toegankelijk zijn.