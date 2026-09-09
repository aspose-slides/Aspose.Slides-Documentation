---
title: Otevření prezentací v Pythonu přes Java
linktitle: Otevřít prezentaci
type: docs
weight: 20
url: /cs/python-java/open-presentation/
keywords:
- otevřít PowerPoint
- otevřít prezentaci
- otevřít PPTX
- otevřít PPT
- otevřít ODP
- načíst prezentaci
- načíst PPTX
- načíst PPT
- načíst ODP
- chráněná prezentace
- velká prezentace
- externí zdroj
- binární objekt
- Python
- Java
- Aspose.Slides
description: "Naučte se, jak otevírat prezentace PowerPoint a OpenDocument v Pythonu přes Java, zadávat otevírací hesla, řídit načítání zdrojů a snižovat využití paměti pomocí Aspose.Slides pro Python přes Java."
---
## **Úvod**

[Aspose.Slides for Python via Java](https://products.aspose.com/slides/cs/python-java/) může načítat prezentace PowerPoint a OpenDocument ze souborů a proudů. Po načtení prezentace můžete prozkoumat její strukturu, upravovat snímky, spravovat zdroje a uložit ji v původním nebo jiném podporovaném formátu.

Chování načítání lze přizpůsobit pomocí třídy [LoadOptions](https://reference.aspose.com/slides/cs/python-java/aspose.slides/loadoptions/). Například můžete poskytnout otevírací heslo, uchovávat velké binární objekty mimo paměť Java heap, řídit externí zdroje nebo vynechat vložená binární data.

## **Otevření prezentací**

Pro otevření existující prezentace předáte její cestu k souboru do konstruktoru [Presentation](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentation/). Po použití uvolněte prezentaci, aby byly souborové handly, dočasná data a další zdroje okamžitě uvolněny.

Následující příklad v Pythonu ukazuje, jak otevřít prezentaci a získat počet snímků:

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

## **Otevření prezentací chráněných heslem**

Otevírací heslo šifruje obsah prezentace. Pro načtení celé prezentace předáte správné heslo metodě [LoadOptions.setPassword](https://reference.aspose.com/slides/cs/python-java/aspose.slides/loadoptions/#setPassword) a poskytnete možnosti konstruktoru [Presentation](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentation/). Načtení selže, pokud heslo chybí nebo je nesprávné.

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

Pro detekci hesla, validaci a šifrovací workflow viz [Password-Protect Presentations](/slides/cs/python-java/password-protected-presentation/). Pokud byla šifrovaná prezentace úmyslně uložena s veřejnými vlastnostmi dokumentu, lze tyto vlastnosti číst bez hesla; viz [Manage Presentation Properties](/slides/cs/python-java/presentation-properties/).

## **Otevření velkých prezentací**

[LoadOptions.getBlobManagementOptions](https://reference.aspose.com/slides/cs/python-java/aspose.slides/loadoptions/#getBlobManagementOptions) vrací možnosti, které řídí, jak Aspose.Slides zachází s velkými binárními objekty, jako jsou obrázky, audio a video. Můžete nechat zdrojový soubor uzamčený, povolit dočasné soubory a omezit množství BLOB dat uchovávaných v paměti.

Následující kód v Pythonu demonstruje načtení velké prezentace (například 2 GB):

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

{{% alert color="info" title="Poznámka" %}}
S [PresentationLockingBehavior.KeepLocked](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentationlockingbehavior/#KeepLocked) zůstává zdrojový soubor uzamčený, dokud není instance prezentace uvolněna. Neměňte, nepřepisujte ani neodstraňujte zdrojový soubor, dokud je tato instance aktivní.

Aspose.Slides může při načítání zkopírovat obsah vstupního proudu. Pro velké prezentace je proto cesta k souboru obecně efektivnější než proud. Viz [Manage BLOBs](/slides/cs/python-java/manage-blob/) pro další možnosti ukládání a správy paměti.
{{% /alert %}}

## **Řízení externích zdrojů**

[LoadOptions.setResourceLoadingCallback](https://reference.aspose.com/slides/cs/python-java/aspose.slides/loadoptions/#setResourceLoadingCallback) přijímá JPype proxy implementující rozhraní Java pro callback načítání zdrojů. Callback může poskytnout náhradní data, přesměrovat zdroj, použít výchozí načítač nebo zdroj přeskočit. To je užitečné, když prezentace obsahují externí obrázky, které je nutné vyřešit podle bezpečnostních nebo úložištních pravidel aplikace.

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

## **Načtení prezentací bez vložených binárních objektů**

Prezentace může obsahovat vložená binární data, která aplikace nepotřebuje ani nechce uchovávat. Příklady zahrnují:

- VBA projekty, dostupné přes [Presentation.getVbaProject](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentation/#getVbaProject);
- vložená OLE data, dostupná přes [OleEmbeddedDataInfo.getEmbeddedFileData](https://reference.aspose.com/slides/cs/python-java/aspose.slides/oleembeddeddatainfo/#getEmbeddedFileData);
- data ovládacích prvků ActiveX, dostupná přes [Control.getActiveXControlBinary](https://reference.aspose.com/slides/cs/python-java/aspose.slides/control/#getActiveXControlBinary).

Nastavte [LoadOptions.setDeleteEmbeddedBinaryObjects](https://reference.aspose.com/slides/cs/python-java/aspose.slides/loadoptions/#setDeleteEmbeddedBinaryObjects) na `True`, aby se při načítání tato binární data odstranila. Uložte načtenou prezentaci, aby se výsledek sanitizoval.

Tato možnost snižuje riziko nechtěných vložených nákladů, ale není kompletním systémem pro detekci malwaru ani sanitizaci obsahu.

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

**Jak mohu zjistit, že soubor je poškozený a nelze jej otevřít?**

Aspose.Slides při načítání vyhodí výjimku parsování nebo formátu. Tento typ selhání je potřeba ošetřit odděleně od chyby nesprávného hesla, aby aplikace mohla přesně nahlásit příčinu.

**Co se stane, pokud chybí požadovaná písma?**

Prezentace se může načíst, ale při vykreslování a exportu může dojít k substituci písem. Můžete [konfigurovat substituci písem](/slides/cs/python-java/font-substitution/) nebo [poskytnout vlastní písma](/slides/cs/python-java/custom-font/), aby byl výstup předvídatelnější.

**Načítá se při načítání prezentace také její vložená média?**

Vložený audio a video obsah jsou dostupné přes objektový model prezentace. Externí zdroje jsou řešeny podle nakonfigurovaného chování načítání zdrojů a mohou být nedostupné, pokud jejich umístění nelze získat.