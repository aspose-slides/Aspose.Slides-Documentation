---
title: PowerPoint bemutatók megnyitása Pythonban
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
- jelszóval védett bemutató
- nagy bemutató
- külső erőforrás
- bináris objektum
- Python
- Aspose.Slides
description: "Nyissa meg a PowerPoint (.pptx, .ppt) és OpenDocument (.odp) bemutatókat könnyedén az Aspose.Slides for Python segítségével .NET-en keresztül — gyors, megbízható, teljes funkcionalitású."
---
## **Bevezetés**

A PowerPoint bemutatók létrehozása mellett a semmiből, az Aspose.Slides lehetővé teszi meglévő bemutatók megnyitását is. Egy bemutató betöltése után információkat kérhet le róla, szerkesztheti a diák tartalmát, új diákat adhat hozzá, eltávolíthat meglévőket, és egyebeket.

## **Bemutatók megnyitása**

Egy meglévő bemutató megnyitásához példányosítsa a [Presentation](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentation/) osztályt, és adja meg a fájl útvonalát a konstruktorának.

Az alábbi Python példában látható, hogyan nyithat meg egy bemutatót, és hogyan kérheti le a diák számát:

```python
import aspose.slides as slides

# Hozzon létre egy Presentation osztály példányt, és adja meg a fájl útvonalát a konstruktorának.
with slides.Presentation("sample.pptx") as presentation:
    # Írja ki a bemutató diák összes számát.
    print(presentation.slides.length)
```

## **Jelszóval védett bemutatók megnyitása**

Ha jelszóval védett bemutatót kell megnyitnia, adja meg a jelszót a [LoadOptions](https://reference.aspose.com/slides/hu/python-net/aspose.slides/loadoptions/) osztály [password](https://reference.aspose.com/slides/hu/python-net/aspose.slides/loadoptions/password/) tulajdonságán keresztül, hogy dekódolja és betöltse. Az alábbi Python kód bemutatja ezt a műveletet:

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.password = "YOUR_PASSWORD"

with slides.Presentation("sample.pptx", load_options) as presentation:
    # Végezzen műveleteket a feloldott bemutatón.
```

## **Nagy bemutatók megnyitása**

Az Aspose.Slides lehetőségeket kínál – különösen a [blob_management_options](https://reference.aspose.com/slides/hu/python-net/aspose.slides/loadoptions/blob_management_options/) tulajdonságot a [LoadOptions](https://reference.aspose.com/slides/hu/python-net/aspose.slides/loadoptions/) osztályban –, hogy segítsen nagy bemutatók betöltésében.

Az alábbi Python kód bemutatja egy nagy bemutató betöltését (például 2 GB):

```python
import aspose.slides as slides
import os

file_path = "LargePresentation.pptx"

load_options = slides.LoadOptions()
# Válassza a KeepLocked viselkedést — a bemutató fájl a Presentation példány élettartama alatt zárolva marad 
# a Presentation példányban, de nem szükséges a memóriába betölteni vagy egy ideiglenes fájlba másolni.
load_options.blob_management_options.presentation_locking_behavior = slides.PresentationLockingBehavior.KEEP_LOCKED
load_options.blob_management_options.is_temporary_files_allowed = True
load_options.blob_management_options.max_blobs_bytes_in_memory = 10 * 1024 * 1024  # 10 MB

with slides.Presentation(file_path, load_options) as presentation:
    # A nagy bemutató betöltődött és használható, miközben a memóriahasználat alacsony marad.

    # Módosítsa a bemutatót.
    presentation.slides[0].name = "Large presentation"

    # Mentse a bemutatót egy másik fájlba. A memóriahasználat ebben a műveletben alacsony marad.
    presentation.save("LargePresentation-copy.pptx", slides.export.SaveFormat.PPTX)

    # Ne tegye ezt! I/O kivétel keletkezik, mert a fájl zárolva van, amíg a Presentation objektum fel nem kerül.
    os.remove(file_path)

# Itt rendben van. A forrásfájl már nincs zárolva a Presentation objektum által.
os.remove(file_path)
```

{{% alert color="info" title="Info" %}}
A stream-ekkel való munkavégzés során felmerülő bizonyos korlátozások megkerülése érdekében az Aspose.Slides a stream tartalmát másolhatja. Egy nagy bemutató stream-ből történő betöltése a bemutató másolását eredményezi, és lassíthatja a betöltést. Ezért, ha nagy bemutatót kell betölni, erősen ajánljuk a bemutató fájl útvonalának használatát a stream helyett.

A nagy objektumokat (videó, hang, nagy felbontású képek stb.) tartalmazó bemutató létrehozásakor használhatja a [BLOB management](/slides/hu/python-net/manage-blob/) funkciót a memóriafogyasztás csökkentése érdekében.
{{%/alert %}}

## **Bemutatók betöltése beágyazott bináris objektumok nélkül**

Egy PowerPoint bemutató a következő típusú beágyazott bináris objektumokat tartalmazhat:

- VBA projekt (elérhető a [Presentation.vba_project](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentation/vba_project/) segítségével);
- OLE objektum beágyazott adat (elérhető az [OleEmbeddedDataInfo.embedded_file_data](https://reference.aspose.com/slides/hu/python-net/aspose.slides/ioleembeddeddatainfo/embedded_file_data/) segítségével);
- ActiveX vezérlő bináris adat (elérhető a [Control.active_x_control_binary](https://reference.aspose.com/slides/hu/python-net/aspose.slides/control/active_x_control_binary/) segítségével).

A [LoadOptions.delete_embedded_binary_objects](https://reference.aspose.com/slides/hu/python-net/aspose.slides/loadoptions/delete_embedded_binary_objects/) tulajdonság használatával betölthet egy bemutatót beágyazott bináris objektumok nélkül.

Ez a tulajdonság hasznos a potenciálisan rosszindulatú bináris tartalom eltávolításához. Az alábbi Python kód bemutatja, hogyan töltsön be egy bemutatót beágyazott bináris tartalom nélkül:

```py
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.delete_embedded_binary_objects = True

with slides.Presentation("malware.ppt", load_options) as presentation:
    # Végezzen műveleteket a bemutatón.
```

## **FAQ**

**Hogyan tudom megállapítani, hogy egy fájl sérült és nem nyitható meg?**

A betöltés során egy elemzési/formátum ellenőrzési kivételt kap. Az ilyen hibák gyakran egy érvénytelen ZIP struktúrára vagy hibás PowerPoint rekordokra utalnak.

**Mi történik, ha a megnyitáskor hiányoznak a szükséges betűtípusok?**

A fájl megnyílik, de a későbbi [rendering/export](/slides/hu/python-net/convert-presentation/) helyettesítheti a betűtípusokat. [Configure font substitutions](/slides/hu/python-net/font-substitution/) vagy [add the required fonts](/slides/hu/python-net/custom-font/) a futási környezethez.

**Mi van a beágyazott médiával (videó/hang) a megnyitáskor?**

Elérhetők lesznek a bemutató erőforrásaiként. Ha a média külső útvonalakon van hivatkozva, győződjön meg arról, hogy ezek az útvonalak elérhetők a környezetben; különben a [rendering/export](/slides/hu/python-net/convert-presentation/) kihagyhatja a médiát.