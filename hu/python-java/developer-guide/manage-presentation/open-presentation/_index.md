---
title: "Prezentációk megnyitása Pythonon keresztül Java segítségével"
linktitle: "Prezentáció megnyitása"
type: docs
weight: 20
url: /hu/python-java/open-presentation/
keywords:
- "PowerPoint megnyitása"
- "prezentáció megnyitása"
- "PPTX megnyitása"
- "PPT megnyitása"
- "ODP megnyitása"
- "prezentáció betöltése"
- "PPTX betöltése"
- "PPT betöltése"
- "ODP betöltése"
- "védett prezentáció"
- "nagy prezentáció"
- "külső erőforrás"
- "bináris objektum"
- "Python"
- "Java"
- "Aspose.Slides"
description: "Ismerje meg, hogyan nyithat meg PowerPoint és OpenDocument prezentációkat Pythonon keresztül Java-val, adhat meg nyitási jelszavakat, szabályozhatja az erőforrásbetöltést, és csökkentheti a memóriahasználatot az Aspose.Slides for Python via Java segítségével."
---
## **Bevezetés**

[Aspose.Slides for Python via Java](https://products.aspose.com/slides/hu/python-java/) képes betölteni PowerPoint és OpenDocument prezentációkat fájlokból és adatfolyamokból. A prezentáció betöltése után ellenőrizheted a szerkezetét, szerkesztheted a diát, kezelheted a forrásokat, és mentheted az eredeti vagy egy másik támogatott formátumban.

A betöltés viselkedését a [LoadOptions](https://reference.aspose.com/slides/hu/python-java/aspose.slides/loadoptions/) osztály segítségével testreszabhatod. Például megadhatsz egy nyitó jelszót, tartani a nagy bináris objektumokat a Java heap memórián kívül, szabályozhatod a külső erőforrásokat, vagy kihagyhatod a beágyazott bináris adatokat.

## **Prezentációk megnyitása**

Egy meglévő prezentáció megnyitásához add át a fájl útvonalát a [Presentation](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentation/) konstruktorának. Az használat után szabadítsd fel a prezentációt, hogy a fájlkezelők, ideiglenes adatok és egyéb erőforrások gyorsan felszabaduljanak.

Az alábbi Python példa bemutatja, hogyan nyithatsz meg egy prezentációt és hogyan kérdezheted le a diák számát:

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

## **Jelszóval védett prezentációk megnyitása**

A nyitó jelszó titkosítja a prezentáció tartalmát. A teljes prezentáció betöltéséhez add át a helyes jelszót a [LoadOptions.setPassword](https://reference.aspose.com/slides/hu/python-java/aspose.slides/loadoptions/#setPassword) metódusnak, és add meg az opciókat a [Presentation](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentation/) konstruktorának. A betöltés sikertelen, ha a jelszó hiányzik vagy helytelen.

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

A jelszó felismerésével, validálásával és titkosítási munkafolyamatokkal kapcsolatos információkért lásd a [Password-Protect Presentations](/slides/hu/python-java/password-protected-presentation/) cikket. Ha egy titkosított prezentációt szándékosan nyilvános dokumentumtulajdonságokkal mentettek, akkor ezek a tulajdonságok jelszó nélkül is olvashatók; lásd a [Manage Presentation Properties](/slides/hu/python-java/presentation-properties/) cikket.

## **Nagy prezentációk megnyitása**

[LoadOptions.getBlobManagementOptions](https://reference.aspose.com/slides/hu/python-java/aspose.slides/loadoptions/#getBlobManagementOptions) olyan beállításokat ad vissza, amelyek szabályozzák, hogyan kezeli az Aspose.Slides a nagy bináris objektumokat, például képeket, hangot és videót. A forrásfájlt lezárhatod, engedélyezheted az ideiglenes fájlokat, és korlátozhatod a memóriaban megtartott BLOB adatok mennyiségét.

Az alábbi Python kód bemutatja egy nagy prezentáció (például 2 GB) betöltését:

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

{{% alert color="info" title="Megjegyzés" %}}
Az [PresentationLockingBehavior.KeepLocked](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentationlockingbehavior/#KeepLocked) használatával a forrásfájl zárolva marad, amíg a prezentáció példány el nem lett dobva. Ne helyezd át, írd felül vagy töröld a forrásfájlt, amíg az példány él.

Az Aspose.Slides a betöltés során másolhatja a bemeneti adatfolyam tartalmát. Nagy prezentációk esetén a fájl útvonala általában hatékonyabb, mint az adatfolyam. További tárolási és memória-kezelési lehetőségekért lásd a [Manage BLOBs](/slides/hu/python-java/manage-blob/) oldalt.
{{% /alert %}}

## **Külső erőforrások szabályozása**

[LoadOptions.setResourceLoadingCallback](https://reference.aspose.com/slides/hu/python-java/aspose.slides/loadoptions/#setResourceLoadingCallback) egy JPype proxy-t fogad el, amely megvalósítja a Java erőforrásbetöltő visszahívási interfészt. A visszahívás biztosíthat helyettesítő adatot, átirányíthat egy erőforrást, használhatja az alapértelmezett betöltőt, vagy kihagyhatja az erőforrást. Ez akkor hasznos, amikor a prezentációk külső képeket tartalmaznak, amelyeket az alkalmazás-specifikus biztonsági vagy tárolási szabályok szerint kell feloldani.

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

## **Prezentációk betöltése beágyazott bináris objektumok nélkül**

Egy prezentáció tartalmazhat beágyazott bináris adatokat, amelyre egy alkalmazásnak nincs szüksége vagy nem akarja megtartani. Példák:

- VBA projektek, a [Presentation.getVbaProject](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentation/#getVbaProject) segítségével érhetők el;
- beágyazott OLE adatok, a [OleEmbeddedDataInfo.getEmbeddedFileData](https://reference.aspose.com/slides/hu/python-java/aspose.slides/oleembeddeddatainfo/#getEmbeddedFileData) segítségével érhetők el;
- ActiveX vezérlő adatok, a [Control.getActiveXControlBinary](https://reference.aspose.com/slides/hu/python-java/aspose.slides/control/#getActiveXControlBinary) segítségével érhetők el.

Állítsd a [LoadOptions.setDeleteEmbeddedBinaryObjects](https://reference.aspose.com/slides/hu/python-java/aspose.slides/loadoptions/#setDeleteEmbeddedBinaryObjects) értékét `True`-ra, hogy a betöltés során eltávolítsd ezeket a bináris adatokat. Mentsd a betöltött prezentációt a tisztított eredmény megőrzéséhez.

Ez az opció csökkenti a nem kívánt beágyazott terhek kitettségét, de nem egy teljes rosszindulatú kód-azonosító vagy tartalomszűrő rendszer.

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

## **GYIK**

**Hogyan tudhatom meg, hogy egy fájl sérült és nem nyitható meg?**

Az Aspose.Slides betöltés közben parsing vagy formátum kivételt dob. Kezeld ezt a hibát külön a helytelen jelszó hibától, hogy az alkalmazás pontosan jelenteni tudja az okot.

**Mi történik, ha a szükséges betűtípusok hiányoznak?**

A prezentáció még betölthető, de a renderelés és export esetleg helyettesítő betűtípusokat használ. Beállíthatod a [font substitution](/slides/hu/python-java/font-substitution/) konfigurálását vagy [egyedi betűtípusok](/slides/hu/python-java/custom-font/) biztosítását, hogy a kimenet előre jelezhetőbb legyen.

**Betölti-e a prezentáció a beágyazott médiát is?**

A beágyazott hang és videó elérhetővé válik a prezentáció objektummodelljén keresztül. A külső erőforrások a beállított erőforrásbetöltési viselkedés szerint kerülnek feloldásra, és előfordulhat, hogy nem érhetők el, ha azok helyei nem hozzáférhetők.