---
title: Prezentációk megnyitása Pythonban
linktitle: Prezentációk megnyitása
type: docs
weight: 20
url: /hu/python-net/open-presentation/
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
- Aspose.Slides
description: "Ismerje meg, hogyan nyithat meg PowerPoint és OpenDocument prezentációkat Pythonban, adjon meg megnyitási jelszavakat, és csökkentse a memóriahasználatot az Aspose.Slides for Python via .NET segítségével."
---
## **Bevezetés**

Aspose.Slides for Python via .NET képes PowerPoint és OpenDocument prezentációkat betölteni fájlokból és adatfolyamokból. Miután egy prezentáció be lett töltve, ellenőrizheti annak szerkezetét, szerkesztheti a diát, kezelheti az erőforrásokat, és elmentheti az eredeti vagy egy másik támogatott formátumban.

Az betöltési viselkedést a [LoadOptions](https://reference.aspose.com/slides/hu/python-net/aspose.slides/loadoptions/) osztállyal testreszabhatja. Például megadhat egy megnyitási jelszót, a nagy bináris objektumokat a memória kívül tarthatja, vagy kihagyhatja a beágyazott bináris adatokat.

## **Prezentációk megnyitása**

Fájl vagy adatfolyam betöltése után meghatározhatja az eredeti prezentációformátumot, hogy kiválassza, alkalmazása hogyan dolgozza fel azt.

Egy létező prezentáció megnyitásához adja át a fájl útvonalát a [Presentation](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentation/) konstruktorának. Használjon egy `with` utasítást, hogy a fájlkezelők, ideiglenes adatok és egyéb erőforrások gyorsan felszabaduljanak.

A következő Python példában látható, hogyan nyithat meg egy prezentációt és szerezheti meg a diák számát:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    print("Slide count: " + str(len(presentation.slides)))
```

## **Jelszóval védett prezentációk megnyitása**

A megnyitási jelszó titkosítja a prezentáció tartalmát. A teljes prezentáció betöltéséhez rendelje a helyes jelszót a [LoadOptions.password](https://reference.aspose.com/slides/hu/python-net/aspose.slides/loadoptions/password/) property-hez, és adja át az opciókat a [Presentation](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentation/) konstruktorának. A betöltés akkor sikertelen, ha a jelszó hiányzik vagy helytelen.

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.password = "open_password"

with slides.Presentation("encrypted-presentation.pptx", load_options) as presentation:
    print("Slide count: " + str(len(presentation.slides)))
```

Jelszó észleléshez, validáláshoz és titkosítási munkafolyamatokhoz lásd a [Jelszóval védett prezentációk](/slides/hu/python-net/password-protected-presentation/) szakaszt. Ha egy titkosított prezentációt szándékosan nyilvános dokumentumtulajdonságokkal mentették, azok a jelszó nélkül is olvashatók; lásd a [Prezentációtulajdonságok kezelése](/slides/hu/python-net/presentation-properties/) útmutatót.

## **Nagy prezentációk megnyitása**

[A LoadOptions.blob_management_options](https://reference.aspose.com/slides/hu/python-net/aspose.slides/loadoptions/blob_management_options/) szabályozza, hogyan kezeli az Aspose.Slides a bináris nagy objektumokat, mint például képek, audio és videó. A forrásfájlt zárolva tarthatja, engedélyezheti az ideiglenes fájlokat, és korlátozhatja a memóriában tartott BLOB adat mennyiségét.

Ez a Python kód bemutatja egy nagy prezentáció betöltését (például 2 GB):

```python
import aspose.slides as slides
file_path = "large-presentation.pptx"

load_options = slides.LoadOptions()
load_options.blob_management_options.presentation_locking_behavior = slides.PresentationLockingBehavior.KEEP_LOCKED
load_options.blob_management_options.is_temporary_files_allowed = True
load_options.blob_management_options.max_blobs_bytes_in_memory = 10 * 1024 * 1024

with slides.Presentation(file_path, load_options) as presentation:
    presentation.slides[0].name = "Large presentation"
    presentation.save("large-presentation-copy.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert color="info" title="Note" %}}
A `PresentationLockingBehavior.KEEP_LOCKED` használatával a forrásfájl zárolva marad, amíg a `Presentation` objektum el nem kerül felszabadításra. Ne mozgassa, írja felül vagy törölje a forrásfájlt, amíg ez az objektum él.

Az Aspose.Slides a betöltés során másolhatja egy bemeneti adatfolyam tartalmát. Nagy prezentációk esetén a fájl útvonal általában hatékonyabb, mint egy adatfolyam. Lásd a [BLOB-ok kezelése](/slides/hu/python-net/manage-blob/) további tárolási és memória-kezelési lehetőségekért.
{{% /alert %}}

## **Prezentációk betöltése beágyazott bináris objektumok nélkül**

Egy prezentáció tartalmazhat beágyazott bináris adatot, amelyre egy alkalmazásnak nincs szüksége vagy nem kívánja megtartani. Példák:

- VBA projektek, a [Presentation.vba_project](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentation/vba_project/) segítségével érhetők el;
- beágyazott OLE adatok, a [OleEmbeddedDataInfo.embedded_file_data](https://reference.aspose.com/slides/hu/python-net/aspose.slides/ioleembeddeddatainfo/embedded_file_data/) segítségével érhetők el;
- ActiveX vezérlő adatok, a [Control.active_x_control_binary](https://reference.aspose.com/slides/hu/python-net/aspose.slides/control/active_x_control_binary/) segítségével érhetők el.

Állítsa a [LoadOptions.delete_embedded_binary_objects](https://reference.aspose.com/slides/hu/python-net/aspose.slides/loadoptions/delete_embedded_binary_objects/) értékét `True`-ra, hogy a betöltés közben eltávolítsa ezt a bináris adatot. Mentse el a betöltött prezentációt, hogy a tisztított eredményt megőrizze.

Ez a lehetőség csökkenti a nem kívánt beágyazott terhek kitettségét, de nem helyettesíti a teljes kártevő-felismerő vagy tartalom-tisztító rendszert.

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.delete_embedded_binary_objects = True

with slides.Presentation("presentation-with-embedded-data.pptx", load_options) as presentation:
    presentation.save("presentation-without-embedded-data.pptx", slides.export.SaveFormat.PPTX)
```

## **GYIK**

**Hogyan tudom megállapítani, hogy egy fájl sérült és nem nyitható meg?**

Az Aspose.Slides betöltés közben parsing vagy formátum kivételt dob. Kezelje ezt a hibát külön a helytelen jelszó hibájától, hogy az alkalmazás pontosan jelenteni tudja az okot.

**Mi történik, ha a szükséges betűtípusok hiányoznak?**

A prezentáció továbbra is betölthető, de a megjelenítés és export esetleg helyettesítő betűtípusokat használ. [A betűtípus-helyettesítés beállításához](/slides/hu/python-net/font-substitution/) vagy [egyedi betűtípusok biztosításához](/slides/hu/python-net/custom-font/) forduljon, hogy a kimenet előre láthatóbb legyen.

**Betölti-e a prezentáció a beágyazott médiát is?**

A beágyazott audio és videó a prezentáció objektummodellen keresztül elérhető lesz. A külső források a alapértelmezett erőforrás‑betöltési viselkedés szerint kerülnek feloldásra, és előfordulhat, hogy nem elérhetők, ha azok helye nem érhető el.