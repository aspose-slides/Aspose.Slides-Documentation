---
title: Pythonon keresztül Java használatával prezentációk megnyitása
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
description: "Tanulja meg, hogyan lehet PowerPoint és OpenDocument prezentációkat megnyitni Pythonon keresztül Java használatával, megadni a megnyitási jelszavakat, kezelni az erőforrás betöltést, és csökkenteni a memóriahasználatot az Aspose.Slides for Python via Java segítségével."
---
## **Bevezetés**

[Aspose.Slides for Python via Java](https://products.aspose.com/slides/hu/python-java/) képes PowerPoint és OpenDocument prezentációkat betölteni fájlokból és adatfolyamokból. A prezentáció betöltése után ellenőrizheti annak felépítését, szerkesztheti a diákat, kezelheti az erőforrásokat, és mentheti az eredeti vagy egy másik támogatott formátumban.

A betöltés viselkedését a [LoadOptions](https://reference.aspose.com/slides/hu/python-java/aspose.slides/loadoptions/) osztály segítségével testreszabhatja. Például megadhat egy megnyitási jelszót, a nagy bináris objektumokat a Java heap memórián kívül tarthatja, szabályozhatja a külső erőforrásokat, vagy kihagyhatja a beágyazott bináris adatokat.

## **Prezentációk megnyitása**

Egy meglévő prezentáció megnyitásához adja meg a fájl elérési útját a [Presentation](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentation/) konstruktorának. A prezentáció használata után szabadítsa fel, hogy a fájlkezelők, az ideiglenes adatok és egyéb erőforrások gyorsan felszabaduljanak.

Az alábbi Python példa bemutatja, hogyan nyithat meg egy prezentációt és hogyan kérdezheti le a dia számát:

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

A jelszó érzékeléséhez, ellenőrzéséhez és titkosítási munkafolyamatokhoz lásd a [Jelszóval védett prezentációk](/slides/hu/python-java/password-protected-presentation/) oldalt. Ha egy titkosított prezentációt szándékosan nyilvános dokumentumtulajdonságokkal mentettek, akkor ezeket a tulajdonságokat jelszó nélkül is olvashatja; lásd a [Prezentáció tulajdonságainak kezelése](/slides/hu/python-java/presentation-properties/) oldalt.

## **Nagy prezentációk megnyitása**

A [LoadOptions.getBlobManagementOptions](https://reference.aspose.com/slides/hu/python-java/aspose.slides/loadoptions/#getBlobManagementOptions) visszaadja az opciókat, amelyek szabályozzák, hogyan kezeli az Aspose.Slides a bináris nagy objektumokat, például képeket, hangot és videót. A forrásfájl zárolt maradhat, engedélyezheti az ideiglenes fájlokat, és korlátozhatja a memóriában megtartott BLOB adatok mennyiségét.

Az alábbi Python kód bemutatja egy nagy prezentáció betöltését (például 2 GB):

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
Az [PresentationLockingBehavior.KeepLocked](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentationlockingbehavior/#KeepLocked) használatával a forrásfájl zárolva marad, amíg a prezentáció példány ki nem lesz bocsátva. Ne mozgassa, felülírja vagy törölje a forrásfájlt, amíg ez a példány él.

Az Aspose.Slides betöltés közben másolhatja a bemeneti adatfolyam tartalmát. Nagy prezentációk esetén a fájl elérési útja általában hatékonyabb, mint egy adatfolyam. További tárolási és memória-kezelési lehetőségekért lásd a [BLOB-ok kezelése](/slides/hu/python-java/manage-blob/) oldalt.
{{% /alert %}}

## **Külső erőforrások vezérlése**

A [LoadOptions.setResourceLoadingCallback](https://reference.aspose.com/slides/hu/python-java/aspose.slides/loadoptions/#setResourceLoadingCallback) elfogad egy JPype proxy-t, amely a Java erőforrásbetöltő visszahívási interfészt valósítja meg. A visszahívás helyettesítő adatot adhat, átirányíthat egy erőforrást, használhatja az alapértelmezett betöltőt, vagy kihagyhatja azt. Ez akkor hasznos, ha a prezentációk külső képeket tartalmaznak, amelyeket az alkalmazás-specifikus biztonsági vagy tárolási szabályok szerint kell feloldani.

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

Egy prezentáció beágyazott bináris adatokat is tartalmazhat, amelyeket egy alkalmazás nem igényel vagy nem szeretne megtartani. Példák:

- VBA projektek, a [Presentation.getVbaProject](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentation/#getVbaProject) segítségével érhetők el;
- beágyazott OLE adatok, az [OleEmbeddedDataInfo.getEmbeddedFileData](https://reference.aspose.com/slides/hu/python-java/aspose.slides/oleembeddeddatainfo/#getEmbeddedFileData) segítségével;
- ActiveX vezérlő adat, a [Control.getActiveXControlBinary](https://reference.aspose.com/slides/hu/python-java/aspose.slides/control/#getActiveXControlBinary) segítségével.

Állítsa a [LoadOptions.setDeleteEmbeddedBinaryObjects](https://reference.aspose.com/slides/hu/python-java/aspose.slides/loadoptions/#setDeleteEmbeddedBinaryObjects) értékét `True`-ra, hogy a betöltés során eltávolítsa ezeket a bináris adatokat. Mentse a betöltött prezentációt a tisztított eredmény megőrzéséhez.

Ez a beállítás csökkenti a nemkívánatos beágyazott terhelések kitettségét, de nem teljes körű rosszindulatú programok felismerését vagy tartalom-sanitizációs rendszert biztosít.

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
Az Aspose.Slides a betöltés során elemzési vagy formátumhibát dob. Kezelje ezt a hibát külön a helytelen jelszó hibától, hogy az alkalmazás pontosan jelenthesse az okot.

**Mi történik, ha a szükséges betűtípusok hiányoznak?**  
A prezentáció továbbra is betölthető, de a megjelenítés és az export esetleg betűtípus-helyettesítést alkalmaz. Beállíthatja a [betűtípus‑helyettesítés beállítása](/slides/hu/python-java/font-substitution/) vagy [egyedi betűtípusok megadása](/slides/hu/python-java/custom-font/) lehetőséget, hogy az eredmény kiszámíthatóbb legyen.

**Betölti-e a prezentáció a beágyazott médiát is?**  
A beágyazott hang és videó a prezentáció objektummodeljén keresztül lesz elérhető. A külső erőforrások feloldása a konfigurált erőforrásbetöltési viselkedés szerint történik, és előfordulhat, hogy nem elérhetők, ha azok helyei nem érhetők el.