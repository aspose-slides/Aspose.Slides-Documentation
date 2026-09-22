---
title: Prezentációk megnyitása Pythonon keresztül Java-val
linktitle: Prezentáció megnyitása
type: docs
weight: 20
url: /hu/python-java/open-presentation/
keywords:
- PowerPoint megnyitása
- prezentáció megnyitása
- PPTX megnyitása
- PPT megnyitása
- ODP megnyitása
- prezentáció betöltése
- PPTX betöltése
- PPT betöltése
- ODP betöltése
- védett prezentáció
- nagy prezentáció
- külső erőforrás
- bináris objektum
- Python
- Java
- Aspose.Slides
description: "Tanulja meg, hogyan nyithat meg PowerPoint és OpenDocument prezentációkat Pythonon keresztül Java-val, adjon meg megnyitási jelszavakat, szabályozza az erőforrások betöltését, és csökkentse a memóriahasználatot az Aspose.Slides for Python via Java segítségével."
---
## **Bevezetés**

[Aspose.Slides for Python via Java](https://products.aspose.com/slides/hu/python-java/) képes PowerPoint és OpenDocument prezentációkat betölteni fájlokból és adatfolyamokból. Miután egy prezentáció betöltésre került, megvizsgálhatja a szerkezetét, szerkesztheti a diákot, kezelheti az erőforrásokat, és elmentheti az eredeti vagy egy másik támogatott formátumban.

A betöltési viselkedés testreszabható a [LoadOptions](https://reference.aspose.com/slides/hu/python-java/aspose.slides/loadoptions/) osztállyal. Például megadhat egy megnyitási jelszót, nagy bináris objektumokat tarthat a Java heap memóriáján kívül, vezérelheti a külső erőforrásokat, vagy kihagyhat beágyazott bináris adatokat.

## **Prezentációk megnyitása**

Fájl vagy adatfolyam betöltése után [meghatározhatja az eredeti prezentáció formátumát](/slides/hu/python-java/detect-presentation-source-format/), hogy eldöntse, hogyan dolgozza fel azt az alkalmazása.

Egy meglévő prezentáció megnyitásához adja meg a fájl útvonalát a [Presentation](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentation/) konstruktorának. A prezentációt a használat után szabadítsa fel, hogy a fájlkezelők, ideiglenes adatok és egyéb erőforrások időben felszabaduljanak.

Az alábbi Python példa bemutatja, hogyan nyithat meg egy prezentációt, és hogyan kérdezheti le a diák számát:

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

A megnyitási jelszó titkosítja a prezentáció tartalmát. A teljes prezentáció betöltéséhez adja meg a helyes jelszót a [LoadOptions.setPassword](https://reference.aspose.com/slides/hu/python-java/aspose.slides/loadoptions/#setPassword) metódusnak, és adja át a beállításokat a [Presentation](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentation/) konstruktorának. A betöltés sikertelen, ha a jelszó hiányzik vagy helytelen.

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

A jelszófelismerés, validálás és titkosítási munkafolyamatok részletei a [Password-Protect Presentations](/slides/hu/python-java/password-protected-presentation/) oldalon találhatók. Ha egy titkosított prezentációt szándékosan nyilvános dokumentumtulajdonságokkal mentették, ezek a tulajdonságok jelszó nélkül is olvashatók; lásd a [Manage Presentation Properties](/slides/hu/python-java/presentation-properties/) részt.

## **Nagy prezentációk megnyitása**

A [LoadOptions.getBlobManagementOptions](https://reference.aspose.com/slides/hu/python-java/aspose.slides/loadoptions/#getBlobManagementOptions) olyan beállításokat ad vissza, amelyek szabályozzák, hogyan kezeli az Aspose.Slides a bináris nagy objektumokat, például képeket, hangot és videót. A forrásfájlt zárolhatja, engedélyezheti az ideiglenes fájlok használatát, és korlátozhatja a memóriában megtartott BLOB adat mennyiségét.

Az alábbi Python kód bemutatja egy nagy (például 2 GB) prezentáció betöltését:

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
A [PresentationLockingBehavior.KeepLocked](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentationlockingbehavior/#KeepLocked) használatával a forrásfájl zárolva marad, amíg a prezentáció példány le nem szabadul. Ne mozgassa, felülírja vagy törölje a forrásfájlt, amíg az példány él.
Az Aspose.Slides betöltéskor másolhatja a bemeneti adatfolyam tartalmát. Nagy prezentációk esetén ezért általában a fájl útvonala hatékonyabb, mint egy adatfolyam. További tárolási és memória-kezelési lehetőségek a [Manage BLOBs](/slides/hu/python-java/manage-blob/) oldalon találhatók.
{{% /alert %}}

## **Külső erőforrások vezérlése**

A [LoadOptions.setResourceLoadingCallback](https://reference.aspose.com/slides/hu/python-java/aspose.slides/loadoptions/#setResourceLoadingCallback) egy JPype proxyt vár, amely a Java erőforrásbetöltő callback interfészt valósítja meg. A callback adhat helyettesítő adatot, átirányíthat egy erőforrást, használhatja az alapértelmezett betöltőt, vagy kihagyhatja az erőforrást. Ez akkor hasznos, ha a prezentációk külső képeket tartalmaznak, amelyeket az alkalmazás‑specifikus biztonsági vagy tárolási szabályok szerint kell feloldani.

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

Egy prezentáció tartalmazhat beágyazott bináris adatokat, amelyeket az alkalmazás nem igényel vagy nem kíván megőrizni. Ilyenek például:

- VBA projektek, a [Presentation.getVbaProject](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentation/#getVbaProject) segítségével érhetők el;
- beágyazott OLE adatok, a [OleEmbeddedDataInfo.getEmbeddedFileData](https://reference.aspose.com/slides/hu/python-java/aspose.slides/oleembeddeddatainfo/#getEmbeddedFileData) segítségével érhetők el;
- ActiveX vezérlő adatok, a [Control.getActiveXControlBinary](https://reference.aspose.com/slides/hu/python-java/aspose.slides/control/#getActiveXControlBinary) segítségével érhetők el.

Állítsa a [LoadOptions.setDeleteEmbeddedBinaryObjects](https://reference.aspose.com/slides/hu/python-java/aspose.slides/loadoptions/#setDeleteEmbeddedBinaryObjects) értékét `True`‑ra, hogy a betöltés során eltávolítsa ezeket a bináris adatokat. Mentse a betöltött prezentációt, hogy a tisztított eredményt megőrizze.

Ez a beállítás csökkenti a nem kívánt beágyazott terhek kitettségét, de nem helyettesíti a teljes malware‑detektáló vagy tartalomszűrő rendszert.

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

**Hogyan tudom megállapítani, hogy egy fájl sérült és nem nyitható meg?**

Az Aspose.Slides a betöltés során parse‑ vagy formátum‑kivételeket dob. Kezelje ezt a hibát külön a helytelen jelszó hibájától, hogy az alkalmazás pontosan tudja jelezni az okot.

**Mi történik, ha a szükséges betűtípusok hiányoznak?**

A prezentáció továbbra is betölthető, de a renderelés és az export helyettesítő betűtípusokat használhat. [A betűtípus‑helyettesítés beállításával](/slides/hu/python-java/font-substitution/) vagy egyedi betűtípusok biztosításával teheti a kimenetet előre jelezhetőbbé.

**A prezentáció betöltése betölti-e a beágyazott médiát is?**

A beágyazott hang és videó elérhetővé válik a prezentáció objektummodelljén keresztül. A külső erőforrások a konfigurált erőforrás‑betöltési viselkedés szerint kerülnek feloldásra, és előfordulhat, hogy nem érhetők el, ha a helyeik nem hozzáférhetők.