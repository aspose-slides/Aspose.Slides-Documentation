---
title: Öppna presentationer i Python via Java
linktitle: Öppna presentation
type: docs
weight: 20
url: /sv/python-java/open-presentation/
keywords:
- öppna PowerPoint
- öppna presentation
- öppna PPTX
- öppna PPT
- öppna ODP
- ladda presentation
- ladda PPTX
- ladda PPT
- ladda ODP
- skyddad presentation
- stor presentation
- extern resurs
- binärt objekt
- Python
- Java
- Aspose.Slides
description: "Lär dig hur du öppnar PowerPoint- och OpenDocument-presentationer i Python via Java, anger öppningslösenord, styr resurshämtning och minskar minnesanvändning med Aspose.Slides för Python via Java."
---
## **Introduktion**

[Aspose.Slides för Python via Java](https://products.aspose.com/slides/sv/python-java/) kan läsa in PowerPoint- och OpenDocument-presentationer från filer och strömmar. När en presentation har lästs in kan du inspektera dess struktur, redigera bilder, hantera resurser och spara den i originalformatet eller något annat stödd format.

Laddningsbeteendet kan anpassas via klassen [LoadOptions](https://reference.aspose.com/slides/sv/python-java/aspose.slides/loadoptions/). Till exempel kan du ange ett öppningslösenord, hålla stora binära objekt utanför Java‑heap‑minnet, kontrollera externa resurser eller utelämna inbäddade binära data.

## **Öppna presentationer**

Efter att ha läst in en fil eller ström kan du [fastställa dess ursprungliga presentationsformat](/slides/sv/python-java/detect-presentation-source-format/) för att välja hur din applikation behandlar den.

För att öppna en befintlig presentation, skicka dess filsökväg till konstruktorn [Presentation](https://reference.aspose.com/slides/sv/python-java/aspose.slides/presentation/). Släpp presentationen efter användning så att filhandtag, temporära data och andra resurser frigörs omedelbart.

Följande Python‑exempel visar hur man öppnar en presentation och får antalet bilder:

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

## **Öppna lösenordsskyddade presentationer**

Ett öppningslösenord krypterar presentationsinnehållet. För att läsa in hela presentationen, skicka det korrekta lösenordet till [LoadOptions.setPassword](https://reference.aspose.com/slides/sv/python-java/aspose.slides/loadoptions/#setPassword) och ange alternativen till konstruktorn [Presentation](https://reference.aspose.com/slides/sv/python-java/aspose.slides/presentation/). Inläsning misslyckas om lösenordet saknas eller är felaktigt.

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

For password detection, validation, and encryption workflows, see [Password-Protect Presentations](/slides/sv/python-java/password-protected-presentation/). If an encrypted presentation was deliberately saved with public document properties, those properties can be read without a password; see [Manage Presentation Properties](/slides/sv/python-java/presentation-properties/).

## **Öppna stora presentationer**

[LoadOptions.getBlobManagementOptions](https://reference.aspose.com/slides/sv/python-java/aspose.slides/loadoptions/#getBlobManagementOptions) returnerar alternativ som styr hur Aspose.Slides hanterar binära stora objekt som bilder, ljud och video. Du kan hålla källfilen låst, tillåta temporära filer och begränsa mängden BLOB‑data som behålls i minnet.

Följande Python‑kod demonstrerar hur man läser in en stor presentation (till exempel 2 GB):

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
Med [PresentationLockingBehavior.KeepLocked](https://reference.aspose.com/slides/sv/python-java/aspose.slides/presentationlockingbehavior/#KeepLocked) förblir källfilen låst tills presentation‑instansen släpps. Flytta, skriv över eller radera inte källfilen medan den instansen är levande.

Aspose.Slides kan kopiera innehållet i en indatatström under inläsning. För stora presentationer är en filsökväg därför i allmänhet mer effektiv än en ström. Se [Manage BLOBs](/slides/sv/python-java/manage-blob/) för ytterligare lagrings‑ och minneshanteringsalternativ.
{{% /alert %}}

## **Kontrollera externa resurser**

[LoadOptions.setResourceLoadingCallback](https://reference.aspose.com/slides/sv/python-java/aspose.slides/loadoptions/#setResourceLoadingCallback) accepterar en JPype‑proxy som implementerar Java‑gränssnittet för resursladdning. Återanropet kan leverera ersättningsdata, omdirigera en resurs, använda standardladdaren eller hoppa över resursen. Detta är användbart när presentationer innehåller externa bilder som måste lösas enligt applikationsspecifika säkerhets‑ eller lagringsregler.

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

## **Läs in presentationer utan inbäddade binära objekt**

En presentation kan innehålla inbäddade binära data som en applikation inte behöver eller inte vill behålla. Exempel inkluderar:

- VBA‑projekt, tillgängliga via [Presentation.getVbaProject](https://reference.aspose.com/slides/sv/python-java/aspose.slides/presentation/#getVbaProject);
- inbäddad OLE‑data, tillgängliga via [OleEmbeddedDataInfo.getEmbeddedFileData](https://reference.aspose.com/slides/sv/python-java/aspose.slides/oleembeddeddatainfo/#getEmbeddedFileData);
- ActiveX‑kontrolldata, tillgängliga via [Control.getActiveXControlBinary](https://reference.aspose.com/slides/sv/python-java/aspose.slides/control/#getActiveXControlBinary).

Ange [LoadOptions.setDeleteEmbeddedBinaryObjects](https://reference.aspose.com/slides/sv/python-java/aspose.slides/loadoptions/#setDeleteEmbeddedBinaryObjects) till `True` för att ta bort dessa binära data under inläsning. Spara den inlästa presentationen för att behålla det sanerade resultatet.

Detta alternativ minskar risken för oönskade inbäddade payloads, men det är inte ett fullständigt system för skadlig‑kod‑detektering eller innehållssanering.

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

**Hur kan jag avgöra att en fil är korrumperad och inte kan öppnas?**

Aspose.Slides kastar ett pars‑ eller formatfel under inläsning. Hantera det felet separat från ett felaktigt lösenord så att applikationen kan rapportera orsaken på ett korrekt sätt.

**Vad händer om nödvändiga teckensnitt saknas?**

Presentationen kan fortfarande läsas in, men rendering och export kan ersätta teckensnitt. Du kan [configure font substitution](/slides/sv/python-java/font-substitution/) eller [provide custom fonts](/slides/sv/python-java/custom-font/) för att göra resultatet mer förutsägbart.

**Laddar inläsning av en presentation även dess inbäddade media?**

Inbäddat ljud och video blir tillgängliga via presentationsobjektmodellen. Externa resurser löses upp enligt den konfigurerade resursladdningsbeteendet och kan vara otillgängliga om deras platser inte kan nås.