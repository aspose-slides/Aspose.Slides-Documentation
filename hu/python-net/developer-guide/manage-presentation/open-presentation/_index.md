---
title: Pythonban bemutatók megnyitása
linktitle: Bemutatók megnyitása
type: docs
weight: 20
url: /hu/python-net/open-presentation/
keywords:
- PowerPoint megnyitása
- bemutató megnyitása
- PPTX megnyitása
- PPT megnyitása
- ODP megnyitása
- bemutató betöltése
- PPTX betöltése
- PPT betöltése
- ODP betöltése
- védett bemutató
- nagy bemutató
- külső erőforrás
- bináris objektum
- Python
- Aspose.Slides
description: "Tanulja meg, hogyan nyithat meg PowerPoint és OpenDocument bemutatókat Pythonban, hogyan adhat meg megnyitási jelszavakat, és hogyan csökkentheti a memóriahasználatot az Aspose.Slides for Python via .NET segítségével."
---
## **Bevezetés**

[Aspose.Slides for Python via .NET](https://products.aspose.com/slides/hu/python-net/) képes PowerPoint és OpenDocument bemutatókat betölteni fájlokból és adatfolyamokból. Miután a bemutató betöltésre került, ellenőrizheti annak szerkezetét, szerkesztheti a diákat, kezelheti az erőforrásokat, és mentheti az eredeti vagy egy másik támogatott formátumban.

A betöltési viselkedés testre szabható a [LoadOptions](https://reference.aspose.com/slides/hu/python-net/aspose.slides/loadoptions/) osztályon keresztül. Például megadhat egy megnyitási jelszót, a nagy bináris objektumokat a memória kívül tarthatja, vagy kihagyhatja a beágyazott bináris adatokat.

## **Bemutatók megnyitása**

Egy meglévő bemutató megnyitásához adja át a fájl útvonalát a [Presentation](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentation/) konstruktorának. Használjon `with` utasítást, hogy a fájlkezelők, az ideiglenes adatok és egyéb erőforrások gyorsan felszabaduljanak.

A következő Python példakód megmutatja, hogyan nyithat meg egy bemutatót és kérdezheti le a diák számát:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    print("Slide count: " + str(len(presentation.slides)))
```

## **Jelszóval védett bemutatók megnyitása**

A megnyitási jelszó titkosítja a bemutató tartalmát. A teljes bemutató betöltéséhez állítsa be a helyes jelszót a [LoadOptions.password](https://reference.aspose.com/slides/hu/python-net/aspose.slides/loadoptions/password/) tulajdonságra, majd adja át a beállításokat a [Presentation](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentation/) konstruktorának. A betöltés sikertelen, ha a jelszó hiányzik vagy hibás.

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.password = "open_password"

with slides.Presentation("encrypted-presentation.pptx", load_options) as presentation:
    print("Slide count: " + str(len(presentation.slides)))
```

A jelszófelismeréssel, -validálással és titkosítási munkafolyamatokkal kapcsolatos információkért lásd a [Password-Protect Presentations](/slides/hu/python-net/password-protected-presentation/) oldalt. Ha egy titkosított bemutatót szándékosan nyilvános dokumentum tulajdonságokkal mentettek, ezek a tulajdonságok jelszó nélkül is olvashatók; lásd a [Manage Presentation Properties](/slides/hu/python-net/presentation-properties/) részt.

## **Nagy bemutatók megnyitása**

A [LoadOptions.blob_management_options](https://reference.aspose.com/slides/hu/python-net/aspose.slides/loadoptions/blob_management_options/) határozza meg, hogyan kezeli az Aspose.Slides a nagy bináris objektumokat, például képeket, hangot és videót. A forrásfájlt zárolhatja, engedélyezheti az ideiglenes fájlokat, és korlátozhatja a memóriában megtartott BLOB adat mennyiségét.

Ez a Python kód demonstrálja egy nagy bemutató betöltését (például 2 GB):

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
A `PresentationLockingBehavior.KEEP_LOCKED` beállítással a forrásfájl zárolva marad, amíg a `Presentation` objektum el nem kerül a felszabadításra. Ne mozgassa, írja felül vagy törölje a forrásfájlt, amíg ez az objektum él.

Az Aspose.Slides a betöltés során másolhatja egy bemeneti adatfolyam tartalmát. Nagy bemutatók esetén a fájl útvonala általában hatékonyabb, mint egy adatfolyam. További tárolási és memória-kezelési lehetőségekért lásd a [Manage BLOBs](/slides/hu/python-net/manage-blob/) oldalt.
{{% /alert %}}

## **Bemutatók betöltése beágyazott bináris objektumok nélkül**

Egy bemutató tartalmazhat beágyazott bináris adatot, amelyre az alkalmazásnak nincs szüksége vagy azt nem kívánja megtartani. Példák:

- VBA projektek, a [Presentation.vba_project](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentation/vba_project/) segítségével érhetők el;
- beágyazott OLE adatok, a [OleEmbeddedDataInfo.embedded_file_data](https://reference.aspose.com/slides/hu/python-net/aspose.slides/ioleembeddeddatainfo/embedded_file_data/) segítségével érhetők el;
- ActiveX vezérlő adatok, a [Control.active_x_control_binary](https://reference.aspose.com/slides/hu/python-net/aspose.slides/control/active_x_control_binary/) segítségével érhetők el.

Állítsa a [LoadOptions.delete_embedded_binary_objects](https://reference.aspose.com/slides/hu/python-net/aspose.slides/loadoptions/delete_embedded_binary_objects/) értékét `True`‑ra a betöltés során a bináris adatok eltávolításához. Mentse a betöltött bemutatót a tisztított eredmény megőrzéséhez.

Ez a beállítás csökkenti a nem kívánt beágyazott betöltések kitettségét, de nem tekinthető teljes víruskeresési vagy tartalomszűrési rendszernek.

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.delete_embedded_binary_objects = True

with slides.Presentation("presentation-with-embedded-data.pptx", load_options) as presentation:
    presentation.save("presentation-without-embedded-data.pptx", slides.export.SaveFormat.PPTX)
```

## **GYIK**

**Hogyan tudhatom, hogy egy fájl sérült és nem nyitható meg?**

Az Aspose.Slides betöltéskor parser vagy formátum kivételt dob. Kezelje ezt a hibát külön a helytelen jelszó hibájától, hogy az alkalmazás pontosan jelenteni tudja az okot.

**Mi történik, ha a szükséges betűtípusok hiányoznak?**

A bemutató továbbra is betölthető, de a renderelés és export helyettesítő betűtípusokat használhat. A [font substitution](/slides/hu/python-net/font-substitution/) konfigurálásával vagy a [custom fonts](/slides/hu/python-net/custom-font/) megadásával tehető előre láthatóbbá a kimenet.

**Betölti-e a bemutató a beágyazott médiát is?**

A beágyazott hang és videó elérhetővé válik a bemutató objektummodellen keresztül. A külső erőforrások a alapértelmezett erőforrás‑betöltési viselkedés szerint kerülnek feloldásra, és előfordulhat, hogy nem érhetők el, ha azok helye nem hozzáférhető.