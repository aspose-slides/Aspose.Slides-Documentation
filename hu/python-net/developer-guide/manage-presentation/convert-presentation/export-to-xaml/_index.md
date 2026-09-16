---
title: Prezentációk exportálása XAML-be Python segítségével
linktitle: Prezentáció XAML-be
type: docs
weight: 30
url: /hu/python-net/export-to-xaml/
keywords:
- PowerPoint exportálása
- OpenDocument exportálása
- prezentáció exportálása
- PowerPoint átalakítása
- OpenDocument átalakítása
- prezentáció átalakítása
- PowerPoint XAML-be
- OpenDocument XAML-be
- prezentáció XAML-be
- PPT XAML-be
- PPTX XAML-be
- ODP XAML-be
- PPT mentése XAML-ként
- PPTX mentése XAML-ként
- ODP mentése XAML-ként
- PPT exportálása XAML-be
- PPTX exportálása XAML-be
- ODP exportálása XAML-be
- Python
- Aspose.Slides
description: "Konvertálja a PowerPoint és OpenDocument diákot XAML-be Python és az Aspose.Slides segítségével - gyors, Office-mentes megoldás, amely megőrzi a elrendezést."
---
## **Áttekintés**

Ez a cikk ismerteti, hogyan lehet PowerPoint‑prezentációkat XAML‑be exportálni az Aspose.Slides használatával. Tartalmaz egy rövid bevezetést a XAML‑ba, bemutatja, hogyan menthető egy prezentáció XAML‑ba alapértelmezett beállításokkal, és demonstrálja, hogyan lehet testre szabni az exportálást a [XamlOptions](https://reference.aspose.com/slides/hu/python-net/aspose.slides.export.xaml/xamloptions/) használatával, beleértve a rejtett diák exportálását. A cikk további gyakori kérdésekre is válaszol a tartalék betűtípusokkal, a XAML‑verem kompatibilitással és a rejtett diák exportálási viselkedésével kapcsolatban.

## **A XAML-ról**

A XAML egy XML-alapú leírónyelv, amelyet a felhasználói felületek leírására használnak olyan keretrendszerekben, mint a WPF (Windows Presentation Foundation), az UWP (Universal Windows Platform) és a Xamarin.Forms.

A XAML fájlokkal dolgozhatsz egy vizuális tervezőben, vagy közvetlenül írhatod és szerkesztheted a leírónyelvet.

## **Prezentációk exportálása XAML-be alapértelmezett beállításokkal**

Az alábbi Python példa bemutatja, hogyan exportáljunk egy prezentációt XAML‑be alapértelmezett beállításokkal:

```python
import aspose.slides as slides

with slides.Presentation("pres.pptx") as presentation:
    xaml_options = slides.export.xaml.XamlOptions()
    presentation.save(xaml_options)
```

Alapértelmezés szerint a exportált diák egy `pres` alkönyvtárba kerülnek a folyamat aktuális munkakönyvtárában, amelyet az [os.getcwd](https://docs.python.org/3/library/os.html#os.getcwd) ad vissza. A mappa automatikusan létrejön, és a szükséges képek is oda kerülnek mentésre.

A kimeneti mappa neve a forrásfájl nevéből származik kiterjesztés nélkül. A `pres.pptx` esetén a kimeneti fájlok neve `pres/Slide_1.xaml`, `pres/Slide_2.xaml` stb. Még ha abszolút útvonalat adsz meg a bemeneti prezentációhoz is, a kimeneti mappa a aktuális munkakönyvtárhoz relatív módon jön létre, nem pedig a bemeneti fájl mellé.

## **Prezentációk exportálása XAML-be egyéni beállításokkal**

Használd a [XamlOptions](https://reference.aspose.com/slides/hu/python-net/aspose.slides.export.xaml/xamloptions/) osztályt annak szabályozásához, hogy az Aspose.Slides hogyan exportál egy prezentációt XAML‑be.

A rejtett diák XAML kimenetbe való belefoglalásához állítsd a [export_hidden_slides](https://reference.aspose.com/slides/hu/python-net/aspose.slides.export.xaml/xamloptions/export_hidden_slides/) tulajdonságot `True`‑ra, ahogyan az alábbi Python példában látható:

```python
import aspose.slides as slides

with slides.Presentation("pres.pptx") as presentation:
    xaml_options = slides.export.xaml.XamlOptions()
    xaml_options.export_hidden_slides = True
    presentation.save(xaml_options)
```

## **Az összes generált XAML artefaktum rögzítése**

Az XAML export minden exportált diára egy XAML dokumentumot, valamint külön képeket és támogató erőforrásokat hozhat létre. Tartsd meg ezeket a fájlokat az export tárolásakor vagy továbbításakor.

Az alábbi példák az alapértelmezett fájlrendszer‑mentőt egy ideiglenes könyvtárban használják, majd összegyűjtik a generált fájlokat.

### **Az export életciklusának megértése**

- Indítsd el az exportálást a XAML‑specifikus [Presentation.save](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentation/save/) túlterheléssel, amely XAML beállításokat fogad. A generált fájlokat csak akkor olvasd be, amikor a hívás sikeresen befejeződött.
- Mentsd meg minden artefaktum relatív útvonalát, mivel a XAML relatív útvonalakkal hivatkozhat erőforrásokra.
- Olvasd be az artefaktumokat bájtokként. A képeket és egyéb bináris erőforrásokat nem szabad szövegként dekódolni.
- Az összesített sikert csak akkor jelentse, miután a gyűjtés és az esetleges további tárolási művelet befejeződött. Engedd, hogy a tárolási hibák eljussanak a hívóhoz, és tisztítsd meg a részleges kimenetet, ha a perzisztencia meghiúsul.

[XamlOptions.export_hidden_slides](https://reference.aspose.com/slides/hu/python-net/aspose.slides.export.xaml/xamloptions/export_hidden_slides/) alapértelmezés szerint `False`, ami kizárja a rejtett diák XAML dokumentumait. `True`‑ra állítva belefoglalja azokat és minden a exportáláshoz szükséges erőforrást. Az erőforrások száma a prezentációtól függ; ne feltételezd, hogy diánként egy fájl van.

{{% alert color="warning" title="Warning" %}}
Az példák ideiglenesen megváltoztatják a folyamat aktuális munkakönyvtárát, ami az összes szálra hat. Futtass minden exportálást egy dedikált munkafolyamatban, vagy biztosítsd, hogy a folyamatban egyéb munkák ne függjenek az aktuális könyvtártól az exportálás során. Egy egyedi ideiglenes könyvtár önmagában nem teszi biztonságossá a párhuzamos exportálásokat ugyanabban a folyamatban.
{{% /alert %}}

### **Export memória felé és az artefaktumok ellenőrzése**

Ez a teljes példa betölti a `pres.pptx` fájlt, egy ideiglenes könyvtárba exportálja, minden artefaktumot egy relatív nevek és bájtok szótárában gyűjt össze, és kiírja a nevét, típusát és bájtszámát. Megőrzi a generált könyvtárstruktúrát, és a gyűjtés után eltávolítja az ideiglenes fájlokat. A bemeneti útvonalat a munkakönyvtár megváltoztatása előtt oldja fel.

```python
import os
from pathlib import Path
from tempfile import TemporaryDirectory

import aspose.slides as slides


def collect_xaml_artifacts(source_path, export_hidden_slides):
    source_path = Path(source_path).resolve()
    original_directory = Path.cwd()
    artifacts = {}

    with TemporaryDirectory(prefix="xaml-") as temporary_directory:
        try:
            os.chdir(temporary_directory)
            with slides.Presentation(str(source_path)) as presentation:
                options = slides.export.xaml.XamlOptions()
                options.export_hidden_slides = export_hidden_slides
                presentation.save(options)

            for artifact_path in Path(temporary_directory).rglob("*"):
                if artifact_path.is_file():
                    relative_path = artifact_path.relative_to(temporary_directory)
                    artifacts[relative_path.as_posix()] = artifact_path.read_bytes()
        finally:
            os.chdir(original_directory)

    return artifacts


artifacts = collect_xaml_artifacts("pres.pptx", True)
inspect_xaml_text = False
image_extensions = {".png", ".jpg", ".jpeg", ".gif", ".bmp", ".tif", ".tiff", ".svg"}
for name, data in artifacts.items():
    extension = Path(name).suffix.lower()
    if extension == ".xaml":
        kind = "slide XAML"
    elif extension in image_extensions:
        kind = "image"
    else:
        kind = "supporting resource"
    print(f"{name}: {len(data)} bytes ({kind})")

    # Csak a XAML-t dekódolja, és csak akkor, ha szöveges vizsgálatra van szükség.
    if extension == ".xaml" and inspect_xaml_text:
        print(data.decode("utf-8"))
```

A kiterjesztés-ellenőrzés hasznos az átvizsgáláshoz; tartsd meg az összes artefaktumot, beleértve az ismeretlen erőforrástípusokat is. Tárolás vagy továbbítás során hagyd a bájtokat változatlanul. Csak azt a XAML‑t dekódold, amely szöveges feldolgozást igényel. Ez a megközelítés ideiglenes lemezterületet és memóriát is használ a gyűjtött exporthoz.

### **Gyűjtött artefaktumok csomagolása ZIP-archívumba**

Ez az önálló példa összegyűjti az exportot, ellenőrizti a neveket, és az eredeti bájtokat egy ZIP-archívumba írja. Egy egyedi archívumnév elválasztja az exportfeladatokat. A ZIP-bejegyzések előre perjel használatával és a relatív könyvtárak megtartásával kerülnek tárolásra. Nem biztonságos nevek vagy a normalizálás után ütköző nevek elutasítják a teljes csomagot, mielőtt az írásra kerülne.

```python
from uuid import uuid4
from zipfile import ZIP_DEFLATED, ZipFile
import os
from pathlib import Path
from tempfile import TemporaryDirectory

import aspose.slides as slides


def collect_xaml_artifacts(source_path, export_hidden_slides):
    source_path = Path(source_path).resolve()
    original_directory = Path.cwd()
    artifacts = {}

    with TemporaryDirectory(prefix="xaml-") as temporary_directory:
        try:
            os.chdir(temporary_directory)
            with slides.Presentation(str(source_path)) as presentation:
                options = slides.export.xaml.XamlOptions()
                options.export_hidden_slides = export_hidden_slides
                presentation.save(options)

            for artifact_path in Path(temporary_directory).rglob("*"):
                if artifact_path.is_file():
                    relative_path = artifact_path.relative_to(temporary_directory)
                    artifacts[relative_path.as_posix()] = artifact_path.read_bytes()
        finally:
            os.chdir(original_directory)

    return artifacts


def package_xaml():
    artifacts = collect_xaml_artifacts("pres.pptx", False)
    entries = {}
    normalized_names = set()
    for name, data in artifacts.items():
        entry_name = name.replace("\\", "/")
        segments = entry_name.split("/")
        unsafe_name = entry_name.startswith("/") or ":" in entry_name
        unsafe_name = unsafe_name or any(not segment.strip() or segment in {".", ".."} for segment in segments)
        normalized_name = entry_name.casefold()
        if unsafe_name or normalized_name in normalized_names:
            print(f"Export rejected: unsafe or duplicate artifact name: {name}")
            return
        normalized_names.add(normalized_name)
        entries[entry_name] = data

    archive_path = Path(f"xaml-{uuid4().hex}.zip")
    with ZipFile(archive_path, "x", compression=ZIP_DEFLATED) as archive:
        for name, data in entries.items():
            archive.writestr(name, data)

    # A ZIP könyvtár már véglegesítve lett, mielőtt a siker jelentésre kerül.
    print(f"Saved {len(entries)} artifacts to {archive_path}")


package_xaml()
```

A példa a [ZipFile](https://docs.python.org/3/library/zipfile.html#zipfile.ZipFile) használatával egy helyi archívumot ír a gyorsexport összegyűjtése után. Távoli tárolás esetén cseréld le az archívumírási lépést a gyűjtött bájtok feltöltésére. Használj egy export‑feladat azonosítót plusz a teljes relatív artefaktumnévnek objektumkulcsként, vagy tárold a feladat azonosítót, a relatív nevet és a bináris adatot egy adatbázis‑sorban. A feladatot csak akkor publikáld, amikor minden feltöltés befejeződött vagy a adatbázis‑tranzakció véglegesítve van. Tisztítsd meg a részleges kimenetet, ha a perzisztencia meghiúsul.

Nagy prezentációk esetén a tempófájlokat export után egyesével dolgozd fel ahelyett, hogy a bájtjaikat egy szótárban gyűjtenéd össze. Ez elkerüli a teljes export további memóriában történő másolatát, de nem szünteti meg az exportáló saját memóriaigényét.

### **Erőforrásnevek megőrzése és hivatkozások ellenőrzése**

- Normalizáld az útvonalelválasztókat, ha a célkönyvtár megköveteli, de tartsd meg a relatív könyvtárakat. Ne csak a végső fájlnevet őrizd meg, kivéve ha minden generált név egyedi, és az erőforrás‑hivatkozások érvényesek maradnak.
- Alkalmazz cél‑specifikus névvalidációt. Laza fájlok írása esetén utasítsd el az abszolút útvonalakat és a navigációs részeket, oldd fel a célkönyvtárat, és ellenőrizd, hogy az az export célkönyvtárán belül marad. Használj alkalmazás‑vezérelt könyvtárat szimbolikus linkek nélkül, amelyek átirányíthatják a írásokat.
- Használj külön tárolási névtérkört minden exportfeladathoz. Ütközéseket detektálj az elválasztó normalizálása után, a célkönyvtár nagybetű‑érzékenységi szabályai szerint.
- Közzététel előtt minden XAML dokumentumot XML‑ként parse‑olj, és ellenőrizd a fájlalapú erőforrás‑hivatkozásokat, például a kép `Source` vagy `ImageSource` attribútusait. Oldd fel minden relatív URI‑t a tartalmazó XAML artefaktum könyvtárához képest, normalizáld a kapott tárolónév‑értéket, és erősítsd meg, hogy a megfelelő szótárkulcs, ZIP‑bejegyzés vagy tárolt objektum létezik. Kezeld külön a külső URI‑kat és a XAML leírókifejezéseket a relatív fájlnevektől.

Például, ha a `pres/Slide_1.xaml` a `images/image1.png`‑re hivatkozik, a tárolt erőforrásnak elérhetőnek kell lennie `pres/images/image1.png`‑ként. Csak az `image1.png` megtartása megszakítaná ezt a kapcsolatot. Objektumtárolásnál őrizd meg ugyanazt a struktúrát a feladat előtagja alatt, és tedd a forrás‑URL‑eket elérhetővé a XAML‑fogyasztó számára. Nyisd meg újra a kész ZIP‑et a bejegyzésnevek és erőforrás‑bájtok ellenőrzéséhez, és tölts be reprezentatív diákot a cél XAML környezetben, hogy megerősítsd a képek helyes feloldását.

## **GYIK**

**Hogyan biztosítható a kiszámítható betűtípus, ha az eredeti betűtípus nincs telepítve a gépen?**

Állítsd be a [default_regular_font](https://reference.aspose.com/slides/hu/python-net/aspose.slides.export.xaml/xamloptions/default_regular_font/) értékét a [XamlOptions](https://reference.aspose.com/slides/hu/python-net/aspose.slides.export.xaml/xamloptions/)‑ban – ez egy tartalék betűtípusként használatos exportáláskor, ha az eredeti hiányzik. Ez nem garantálja, hogy a generált XAML a tartalék betűtípust hivatkozza, vagy hogy a betűtípus elérhető a célgépen. Bizonyosodj meg róla, hogy a XAML által hivatkozott betűtípusok elérhetők abban a környezetben, ahol megjelenik.

**A exportált XAML csak WPF‑hez készült, vagy használható más XAML‑veremekben is?**

Az Aspose.Slides a WPF XAML‑t exportálja a nyilvános API‑ján keresztül. Más XAML‑veremek, például az UWP vagy a Xamarin.Forms kompatibilitása nem garantált. Teszteld a generált leírónyelvet a célkörnyezetben.

**Támogatottak a rejtett diák, és hogyan akadályozhatom meg, hogy alapértelmezés szerint exportálódjanak?**

Alapértelmezés szerint a rejtett diák nincsenek belefoglalva. Ezt a viselkedést a [export_hidden_slides](https://reference.aspose.com/slides/hu/python-net/aspose.slides.export.xaml/xamloptions/export_hidden_slides/) beállítással a [XamlOptions](https://reference.aspose.com/slides/hu/python-net/aspose.slides.export.xaml/xamloptions/)‑ban szabályozhatod – tartsd letiltva, ha nem szeretnéd, hogy exportálásra kerüljenek.