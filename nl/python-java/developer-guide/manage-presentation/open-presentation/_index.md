---
title: Open presentaties in Python via Java
linktitle: Open presentatie
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
- externe resource
- binair object
- Python
- Java
- Aspose.Slides
description: "Leer hoe u PowerPoint- en OpenDocument-presentaties kunt openen in Python via Java, openingswachtwoorden kunt opgeven, het laden van resources kunt beheren en het geheugenverbruik kunt verminderen met Aspose.Slides voor Python via Java."
---
## **Introductie**

[Aspose.Slides for Python via Java](https://products.aspose.com/slides/nl/python-java/) kan PowerPoint- en OpenDocument-presentaties laden vanuit bestanden en streams. Nadat een presentatie is geladen, kun je de structuur inspecteren, dia's bewerken, resources beheren en deze opslaan in het oorspronkelijke of een ander ondersteund formaat.

Het laadgedrag kan aangepast worden via de [LoadOptions](https://reference.aspose.com/slides/nl/python-java/aspose.slides/loadoptions/) klasse. Bijvoorbeeld kun je een openingswachtwoord opgeven, grote binaire objecten buiten het Java-heapgeheugen houden, externe resources beheren of ingebedde binaire gegevens weglaten.

## **Presentaties openen**

Om een bestaande presentatie te openen, geef je het bestandspad door aan de [Presentation](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentation/) constructor. Maak de presentatie vrij na gebruik zodat bestands-handelingen, tijdelijke gegevens en andere bronnen onmiddellijk worden vrijgegeven.

Het volgende Python‑voorbeeld laat zien hoe je een presentatie opent en het aantal dia's opvraagt:

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

## **Wachtwoordbeveiligde presentaties openen**

Een openingswachtwoord versleutelt de inhoud van de presentatie. Om de volledige presentatie te laden, geef je het juiste wachtwoord door aan [LoadOptions.setPassword](https://reference.aspose.com/slides/nl/python-java/aspose.slides/loadoptions/#setPassword) en lever je de opties aan de [Presentation](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentation/) constructor. Laden mislukt wanneer het wachtwoord ontbreekt of onjuist is.

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

Voor wachtwoorddetectie, validatie en versleutelingswerkstromen, zie [Wachtwoordbeveiligde presentaties](/slides/nl/python-java/password-protected-presentation/). Als een versleutelde presentatie bewust is opgeslagen met publieke documenteigenschappen, kunnen die eigenschappen zonder wachtwoord gelezen worden; zie [Presentatie-eigenschappen beheren](/slides/nl/python-java/presentation-properties/).

## **Grote presentaties openen**

[LoadOptions.getBlobManagementOptions](https://reference.aspose.com/slides/nl/python-java/aspose.slides/loadoptions/#getBlobManagementOptions) geeft opties terug die bepalen hoe Aspose.Slides binaire grote objecten zoals afbeeldingen, audio en video verwerkt. Je kunt het bronbestand vergrendeld houden, tijdelijke bestanden toestaan en de hoeveelheid BLOB‑gegevens die in het geheugen behouden blijven beperken.

De volgende Python‑code demonstreert het laden van een grote presentatie (bijvoorbeeld 2 GB):

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
Met [PresentationLockingBehavior.KeepLocked](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentationlockingbehavior/#KeepLocked) blijft het bronbestand vergrendeld totdat de presentatie‑instantie wordt vrijgegeven. Verplaats, overschrijf of verwijder het bronbestand niet terwijl die instantie actief is.

Aspose.Slides kan de inhoud van een invoer‑stream kopiëren tijdens het laden. Voor grote presentaties is een bestandspad daarom doorgaans efficiënter dan een stream. Zie [Manage BLOBs](/slides/nl/python-java/manage-blob/) voor extra opslag‑ en geheugen‑beheeropties.
{{% /alert %}}

## **Externe resources beheren**

[LoadOptions.setResourceLoadingCallback](https://reference.aspose.com/slides/nl/python-java/aspose.slides/loadoptions/#setResourceLoadingCallback) accepteert een JPype‑proxy die de Java resource‑loading callback‑interface implementeert. De callback kan vervangende gegevens leveren, een resource omleiden, de standaardloader gebruiken of de resource overslaan. Dit is nuttig wanneer presentaties externe afbeeldingen bevatten die volgens toepassingsspecifieke beveiligings‑ of opslagregels moeten worden opgezocht.

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

## **Presentaties laden zonder ingebedde binaire objecten**

Een presentatie kan ingebedde binaire gegevens bevatten die een applicatie niet nodig heeft of wil behouden. Voorbeelden zijn:

- VBA‑projecten, beschikbaar via [Presentation.getVbaProject](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentation/#getVbaProject);
- ingebedde OLE‑gegevens, beschikbaar via [OleEmbeddedDataInfo.getEmbeddedFileData](https://reference.aspose.com/slides/nl/python-java/aspose.slides/oleembeddeddatainfo/#getEmbeddedFileData);
- ActiveX‑controlgegevens, beschikbaar via [Control.getActiveXControlBinary](https://reference.aspose.com/slides/nl/python-java/aspose.slides/control/#getActiveXControlBinary).

Stel [LoadOptions.setDeleteEmbeddedBinaryObjects](https://reference.aspose.com/slides/nl/python-java/aspose.slides/loadoptions/#setDeleteEmbeddedBinaryObjects) in op `True` om deze binaire gegevens tijdens het laden te verwijderen. Sla de geladen presentatie op om het gesaniteerde resultaat te behouden.

Deze optie vermindert de blootstelling aan ongewenste ingebedde payloads, maar is geen volledig systeem voor malware‑detectie of inhouds‑sanitatie.

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

## **FAQ**

**Hoe kan ik zien dat een bestand corrupt is en niet geopend kan worden?**

Aspose.Slides werpt tijdens het laden een parse‑ of format‑exception. Handel deze fout afzonderlijk af van een onjuist‑wachtwoord‑fout, zodat de applicatie de oorzaak nauwkeurig kan rapporteren.

**Wat gebeurt er als vereiste lettertypen ontbreken?**

De presentatie kan nog steeds geladen worden, maar weergave en export kunnen lettertypen vervangen. Je kunt [lettertype‑substitutie configureren](/slides/nl/python-java/font-substitution/) of [aangepaste lettertypen leveren](/slides/nl/python-java/custom-font/) om de output voorspelbaarder te maken.

**Laadt het laden van een presentatie ook de ingebedde media?**

Ingebedde audio en video zijn beschikbaar via het presentatie‑objectmodel. Externe resources worden opgezocht volgens het geconfigureerde resource‑loading gedrag en kunnen onbeschikbaar zijn als hun locaties niet toegankelijk zijn.