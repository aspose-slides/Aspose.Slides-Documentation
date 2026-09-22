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
description: "Leer hoe u PowerPoint- en OpenDocument-presentaties kunt openen in Python via Java, openingswachtwoorden kunt opgeven, het laden van resources kunt beheersen en het geheugenverbruik kunt verminderen met Aspose.Slides voor Python via Java."
---
## **Inleiding**

[Aspose.Slides for Python via Java](https://products.aspose.com/slides/nl/python-java/) kan PowerPoint- en OpenDocument-presentaties laden vanuit bestanden en streams. Nadat een presentatie is geladen, kunt u de structuur inspecteren, dia's bewerken, resources beheren en deze opslaan in het originele of een ander ondersteund formaat.

Het laadgedrag kan aangepast worden via de [LoadOptions](https://reference.aspose.com/slides/nl/python-java/aspose.slides/loadoptions/)-klasse. U kunt bijvoorbeeld een openingswachtwoord opgeven, grote binaire objecten buiten het Java-heap-geheugen houden, externe resources beheren, of ingesloten binaire gegevens weglaten.

## **Open Presentaties**

Na het laden van een bestand of stream kunt u [bepalen wat het oorspronkelijke presentatieformaat is](/slides/nl/python-java/detect-presentation-source-format/) om te kiezen hoe uw applicatie deze verwerkt.

Om een bestaande presentatie te openen, geeft u het pad naar het bestand door aan de [Presentation](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentation/)-constructor. Maak de presentatie vrij nadat u klaar bent, zodat bestands-handles, tijdelijke gegevens en andere resources meteen worden vrijgegeven.

Het volgende Python-voorbeeld toont hoe u een presentatie opent en het aantal dia's opvraagt:

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

Een openingswachtwoord versleutelt de inhoud van de presentatie. Om de volledige presentatie te laden, geeft u het juiste wachtwoord door aan [LoadOptions.setPassword](https://reference.aspose.com/slides/nl/python-java/aspose.slides/loadoptions/#setPassword) en levert u de opties aan de [Presentation](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentation/)-constructor. Het laden mislukt wanneer het wachtwoord ontbreekt of onjuist is.

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

Voor wachtwoorddetectie, validatie en encryptieworkflows, zie [Password-Protect Presentations](/slides/nl/python-java/password-protected-presentation/). Als een versleutelde presentatie opzettelijk is opgeslagen met openbare documenteigenschappen, kunnen die eigenschappen gelezen worden zonder wachtwoord; zie [Manage Presentation Properties](/slides/nl/python-java/presentation-properties/).

## **Open grote presentaties**

[LoadOptions.getBlobManagementOptions](https://reference.aspose.com/slides/nl/python-java/aspose.slides/loadoptions/#getBlobManagementOptions) retourneert opties die bepalen hoe Aspose.Slides grote binaire objecten (BLOB's) zoals afbeeldingen, audio en video behandelt. U kunt het bronbestand vergrendeld houden, tijdelijke bestanden toestaan en de hoeveelheid BLOB-gegevens die in het geheugen worden bewaard beperken.

De volgende Python-code laat zien hoe u een grote presentatie laadt (bijvoorbeeld 2 GB):

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

Aspose.Slides kan de inhoud van een invoerstroom kopiëren tijdens het laden. Voor grote presentaties is een bestandspad doorgaans efficiënter dan een stream. Zie [Manage BLOBs](/slides/nl/python-java/manage-blob/) voor extra opslag‑ en geheugemanagementopties.
{{% /alert %}}

## **Beheer externe resources**

[LoadOptions.setResourceLoadingCallback](https://reference.aspose.com/slides/nl/python-java/aspose.slides/loadoptions/#setResourceLoadingCallback) accepteert een JPype-proxy die de Java-resource-laadcallback-interface implementeert. De callback kan vervangende data leveren, een resource omleiden, de standaardlader gebruiken of de resource overslaan. Dit is handig wanneer presentaties externe afbeeldingen bevatten die volgens toepassingsspecifieke beveiligings‑ of opslagregels moeten worden opgelost.

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

## **Laad presentaties zonder ingesloten binaire objecten**

Een presentatie kan ingesloten binaire data bevatten die een applicatie niet nodig heeft of niet wil behouden. Voorbeelden zijn:

- VBA-projecten, beschikbaar via [Presentation.getVbaProject](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentation/#getVbaProject);
- ingesloten OLE-data, beschikbaar via [OleEmbeddedDataInfo.getEmbeddedFileData](https://reference.aspose.com/slides/nl/python-java/aspose.slides/oleembeddeddatainfo/#getEmbeddedFileData);
- ActiveX-controlegegevens, beschikbaar via [Control.getActiveXControlBinary](https://reference.aspose.com/slides/nl/python-java/aspose.slides/control/#getActiveXControlBinary).

Stel [LoadOptions.setDeleteEmbeddedBinaryObjects](https://reference.aspose.com/slides/nl/python-java/aspose.slides/loadoptions/#setDeleteEmbeddedBinaryObjects) in op `True` om deze binaire data bij het laden te verwijderen. Sla de geladen presentatie op om het opgeschoonde resultaat te behouden.

Deze optie vermindert de blootstelling aan ongewenste ingesloten payloads, maar vormt geen volledige malware-detectie- of content-sanitiserings-systeem.

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

**Hoe kan ik zien dat een bestand beschadigd is en niet geopend kan worden?**

Aspose.Slides werpt tijdens het laden een parser- of formaat-exception. Verwerk die fout apart van een foutmelding voor een onjuist wachtwoord, zodat de applicatie de oorzaak nauwkeurig kan rapporteren.

**Wat gebeurt er als vereiste lettertypen ontbreken?**

De presentatie kan nog steeds geladen worden, maar weergave en export kunnen lettertypen vervangen. U kunt [configure font substitution](/slides/nl/python-java/font-substitution/) of [provide custom fonts](/slides/nl/python-java/custom-font/) gebruiken om de output voorspelbaarder te maken.

**Laadt het laden van een presentatie ook de ingesloten media?**

Ingesloten audio en video worden beschikbaar via het presentatiemodel. Externe resources worden opgelost volgens het geconfigureerde resource-laadgedrag en kunnen onbeschikbaar zijn als hun locaties niet toegankelijk zijn.