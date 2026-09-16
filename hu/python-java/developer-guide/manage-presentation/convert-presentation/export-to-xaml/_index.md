---
title: Prezentációk exportálása XAML-be Pythonon keresztül Java-val
linktitle: Prezentáció XAML-be
type: docs
weight: 30
url: /hu/python-java/export-to-xaml/
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
- Java
- Aspose.Slides
description: "PowerPoint és OpenDocument prezentációk exportálása XAML-be az Aspose.Slides for Python via Java segítségével. Használjon alapértelmezett beállításokat vagy vegye fel a rejtett diákat."
---
## **Áttekintés**

Ez a cikk bemutatja, hogyan lehet a PowerPoint‑prezentációkat XAML‑be exportálni az Aspose.Slides for Python via Java segítségével. Tartalmaz egy rövid bemutatást a XAML‑ról, megmutatja, hogyan lehet egy prezentációt XAML‑ba menteni az alapértelmezett beállításokkal, és bemutatja, hogyan lehet testre szabni az exportot a [XamlOptions](https://reference.aspose.com/slides/hu/python-java/aspose.slides/xamloptions/)-on keresztül, beleértve a rejtett diák exportálását is. A cikk néhány gyakori kérdésre is választ ad, amelyek a tartalék betűtípusokra, a XAML‑verem kompatibilitására és a rejtett diák export viselkedésére vonatkoznak.

A példák az Aspose.Slides for Python via Java és egy kompatibilis Java runtime meglétét igénylik. Helyezze a `pres.pptx` fájlt az aktuális munkakönyvtárba. Minden példa csak akkor indítja el a JVM‑et, ha az még nem fut.

## **A XAML‑ról**

A XAML egy XML‑alapú jelölőnyelv, amelyet a felhasználói felületek leírására használnak olyan keretrendszerekben, mint a WPF (Windows Presentation Foundation), az UWP (Universal Windows Platform) és a Xamarin.Forms.

A XAML‑fájlokkal dolgozhat vizuális tervezőben, vagy közvetlenül írhatja és szerkesztheti a jelölést.

## **Prezentációk exportálása XAML‑ba alapértelmezett beállításokkal**

A következő Python‑példa megmutatja, hogyan lehet egy prezentációt XAML‑ba exportálni az alapértelmezett beállításokkal:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, XamlOptions

presentation = Presentation("pres.pptx")
try:
    xaml_options = XamlOptions()
    presentation.save(xaml_options)
finally:
    presentation.dispose()
```

Alapértelmezés szerint az exportált diák a folyamat aktuális munkakönyvtárában lévő `pres` alkönyvtárba kerülnek mentésre. A mappa automatikusan létrejön, és a szükséges képek is oda kerülnek mentésre.

A kimeneti mappa neve a forrásfájl nevéből származik kiterjesztés nélkül. A `pres.pptx` esetén a kimeneti fájlok neve `pres/Slide_1.xaml`, `pres/Slide_2.xaml` stb. Még ha abszolút elérési utat ad meg a bemeneti prezentációnak is, a kimeneti mappa az aktuális munkakönyvtárhoz relatívan jön létre, nem pedig a bemeneti fájl mellett.

## **Prezentációk exportálása XAML‑ba egyéni beállításokkal**

Használja a [XamlOptions](https://reference.aspose.com/slides/hu/python-java/aspose.slides/xamloptions/) osztályt annak szabályozására, hogy az Aspose.Slides hogyan exportál egy prezentációt XAML‑ba.

A kimenet egyedi helyre mentéséhez valósítsa meg az `IXamlOutputSaver` interfészt, és adja át annak példányát a [setOutputSaver](https://reference.aspose.com/slides/hu/python-java/aspose.slides/xamloptions/#setOutputSaver) metódusnak a [XamlOptions](https://reference.aspose.com/slides/hu/python-java/aspose.slides/xamloptions/) osztályon keresztül.

A rejtett diák XAML‑kimenetben való felvételéhez hívja meg a [setExportHiddenSlides](https://reference.aspose.com/slides/hu/python-java/aspose.slides/xamloptions/#setExportHiddenSlides) metódust `True` értékkel, ahogyan az alábbi Python‑példában látható:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, XamlOptions

presentation = Presentation("pres.pptx")
try:
    xaml_options = XamlOptions()
    xaml_options.setExportHiddenSlides(True)
    presentation.save(xaml_options)
finally:
    presentation.dispose()
```

## **Minden generált XAML‑artifaktum rögzítése**

Egy XAML export minden exportált diára elkészíthet egy XAML dokumentumot, valamint különálló képeket és támogató erőforrásokat. Rendelj egy egyéni `IXamlOutputSaver`‑t a [XamlOptions.setOutputSaver](https://reference.aspose.com/slides/hu/python-java/aspose.slides/xamloptions/#setOutputSaver) metódushoz, hogy ezeket az artifaktumokat kapja, ahelyett, hogy az alapértelmezett fájlrendszer‑mentőt használja. Indítsa el az exportálást a XAML‑specifikus [Presentation.save](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentation/#save) túlterheléssel, amely XAML‑beállításokat fogad.

Pythonban használja a `jpype.JProxy`‑t a Java `IXamlOutputSaver` interfész megvalósításához. A visszahívási útvonalat alakítsa `str` típusúvá, és a Java bájt tömböt másolja Python `bytes`‑be a visszatérés előtt, ahogyan az alább látható.

### **A visszahívás életciklusának megértése**

Az exportáló külön meghívja az `IXamlOutputSaver.save`‑t minden generált artifaktumra:

- `path` az artifaktumot azonosítja, és tartalmazhat relatív könyvtárakat. Tartsa meg ezt az információt, mivel a XAML relatív útvonalakkal hivatkozhat erőforrásokra.
- `data` az artifaktum bájtjait tartalmazza. Képeket és egyéb bináris erőforrásokat nem szabad szövegként dekódolni.
- A mentőnek felelőssége, hogy a visszatérés előtt megőrizze vagy elmentse az adatokat. A példák minden bájt tömböt az alkalmazás által kezelt memóriába másolnak.
- Az exportálást csak akkor tekintse sikeresnek, ha a prezentáció mentési művelete visszatér, és minden visszahívás sikeresen befejeződött. Ne nyelje le a tárolási hibákat, és ne indítson felügyelet nélküli háttérírásokat. Ha a perzisztálás később történik, az általános siker jelentését csak azután adja, ha az a lépés is sikeres.

A [XamlOptions.setExportHiddenSlides](https://reference.aspose.com/slides/hu/python-java/aspose.slides/xamloptions/#setExportHiddenSlides) metódus egy egyéni mentőre is alkalmazható. Az alapértelmezett beállítás, `False`, kizárja a rejtett diák XAML dokumentumait. `True` átadása felveszi őket, valamint a exportáláshoz szükséges erőforrásokat is. Az erőforrások száma a prezentációtól függ; ne feltételezze, hogy minden diához egy visszahívás vagy egy rögzített visszahívási sorrend tartozik.

### **Export memóriaba és az artifaktumok vizsgálata**

Ez a teljes példa betölti a `pres.pptx` fájlt, minden artifaktumot egy Python szótárban gyűjt a nevek és változtathatatlan `bytes` értékek szerint, majd kiírja a nevét, típusát és a bájtok számát. Pontosan megőrzi a megadott neveket. Az ismétlődő nevek a gyűjteményt érvéletlennek jelölik, ahelyett, hogy csendben felülírnának egy artifaktumot. A példa ezt ellenőrzi, mielőtt a rezultát használja.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, XamlOptions

class MemoryXamlSaver:
    def __init__(self):
        self.artifacts = {}
        self.valid = True

    def save(self, path, data):
        name = str(path)
        if name in self.artifacts:
            self.valid = False
            print(f"Export rejected: duplicate artifact name: {name}")
            return
        self.artifacts[name] = bytes(data)

def main():

    saver = MemoryXamlSaver()
    output_saver = jpype.JProxy("com.aspose.slides.IXamlOutputSaver", inst=saver)
    presentation = Presentation("pres.pptx")
    try:
        options = XamlOptions()
        options.setOutputSaver(output_saver)
        options.setExportHiddenSlides(True)
        presentation.save(options)
    finally:
        presentation.dispose()

    if not saver.valid:
        print("Export rejected: the artifact collection is invalid.")
        return

    inspect_xaml_text = False
    image_extensions = (".png", ".jpg", ".jpeg", ".gif", ".bmp", ".tif", ".tiff", ".svg")
    for name, data in saver.artifacts.items():
        lower_name = name.lower()
        is_xaml = lower_name.endswith(".xaml")
        is_image = lower_name.endswith(image_extensions)
        kind = "slide XAML" if is_xaml else "image" if is_image else "supporting resource"
        print(f"{name}: {len(data)} bytes ({kind})")

        # Csak XAML-t dekódol, és csak akkor, ha szöveges ellenőrzésre van szükség.
        if is_xaml and inspect_xaml_text:
            markup = data.decode("utf-8")
            print(markup)


main()
```

A kiterjesztés ellenőrzések hasznosak a vizsgálathoz; őrizze meg minden artifaktumot, beleértve az ismeretlen erőforrás típusokat is. A bájtokat változatlanul hagyja tárolás vagy továbbítás során. A `bytes.decode`‑t csak UTF‑8‑kal használja olyan XAML esetén, amely szöveges feldolgozást igényel.

### **Az összegyűjtött artifaktumok csomagolása ZIP archívumba**

Ez a független példa összegyűjti az exportot, ellenőrzi a neveket, és az eredeti bájtokat egy ZIP archívumba írja. Egy egyedi archívumnév elválasztja a párhuzamos exportfeladatokat. A ZIP bejegyzések előre perjeleket (/) használnak, és megőrzik a relatív könyvtárakat. Nem biztonságos nevek vagy a normalizálás után ütköző nevek elutasítják az egész csomagot, mielőtt az írásra kerül.

```python
from uuid import uuid4
from zipfile import ZipFile

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, XamlOptions

class MemoryXamlSaver:
    def __init__(self):
        self.artifacts = {}
        self.valid = True

    def save(self, path, data):
        name = str(path)
        if name in self.artifacts:
            self.valid = False
            print(f"Export rejected: duplicate artifact name: {name}")
            return
        self.artifacts[name] = bytes(data)

def main():

    saver = MemoryXamlSaver()
    output_saver = jpype.JProxy("com.aspose.slides.IXamlOutputSaver", inst=saver)
    presentation = Presentation("pres.pptx")
    try:
        options = XamlOptions()
        options.setOutputSaver(output_saver)
        options.setExportHiddenSlides(False)
        presentation.save(options)
    finally:
        presentation.dispose()

    if not saver.valid:
        print("Export rejected: the artifact collection is invalid.")
        return

    entries = {}
    entry_names = set()
    for name, data in saver.artifacts.items():
        entry_name = name.replace("\\", "/")
        segments = entry_name.split("/")
        unsafe_name = entry_name.startswith("/") or ":" in entry_name or "\x00" in entry_name
        unsafe_name |= any(not segment.strip() or segment in (".", "..") for segment in segments)
        normalized_name = entry_name.casefold()
        if unsafe_name or normalized_name in entry_names:
            print(f"Export rejected: unsafe or duplicate artifact name: {name}")
            return
        entry_names.add(normalized_name)
        entries[entry_name] = data

    job_id = uuid4()
    archive_path = f"xaml-{job_id}.zip"
    try:
        with ZipFile(archive_path, mode="x") as archive:
            for name, data in entries.items():
                archive.writestr(name, data)

        # A zárás befejezi a ZIP könyvtárat, mielőtt a siker jelentésre kerül.
        print(f"Saved {len(entries)} artifacts to {archive_path}")
    except OSError as exception:
        print(f"Archive persistence failed: {exception}")


main()
```

A példa a Python `zipfile.ZipFile` osztályát használja egy helyi archívum írásához; az exportáló maga nem ír laza XAML vagy képfájlokat. Távoli tárolás esetén cserélje le az archívum‑írást a gyűjtött bájt tömbök feltöltésére. Használjon export‑feladat azonosítót a teljes relatív artifaktum névvel együtt blob‑kulcsként, vagy tárolja a feladat azonosítót, a relatív nevet és a bináris adatot egy adatbázis sorban. A feladatot csak akkor tegye közzé, amikor minden feltöltés befejeződött vagy az adatbázis tranzakció rögzül. Tisztítsa meg a részleges kimenetet, ha a perzisztálás meghiúsul.

Nagy prezentációk esetén egy egyéni mentő közvetlenül az alkalmazás tárolójába perzisztálhatja az egyes artifaktumokat, elkerülve ezzel az export teljes másolatának alkalmazás‑memóriában való tárolását. Tartsa a visszahívásokat szinkronban az exportáló perspektívájából: csak akkor térjen vissza, ha a célhely elfogadta a bájtokat, és engedje meg a hibák áthaladását a hívó felé.

### **Erőforrásnevek megőrzése és hivatkozások ellenőrzése**

- Normalizálja az útvonal elválasztókat, ha a célhely megköveteli, de őrizze meg a relatív könyvtárakat. Ne csak `pathlib.Path.name`‑t használjon, kivéve ha minden generált név egyedinek ismert, és az erőforrás‑hivatkozások érvényesek maradnak.
- Alkalmazzon célhely‑specifikus névvalidációt. Laza fájlok írásakor utasítsa el a gyökér‑ és a navigációs (..) útvonalakat, oldja fel a célhelyet `pathlib.Path.resolve`‑vel, és ellenőrizze, hogy a kívánt export könyvtár alatt marad-e, beleértve a könyvtár elválasztót a tartalmazási ellenőrzésben. Használjon egy alkalmazás‑vezérelt könyvtárat szimbolikus linkek nélkül, amelyek átirányíthatják a írást.
- Használjon külön mentőt és tárolási névtért minden export feladathoz. Ütközéseket detektáljon az elválasztó normalizálása után, és a célhely kis‑/nagybetű érzékenységi szabályai szerint.
- Közzététel előtt elemezze minden XAML dokumentumot XML‑ként, és ellenőrizze a fájl‑alapú erőforrás hivatkozásokat, például a kép `Source` vagy `ImageSource` attribútusait. Oldja fel minden relatív URI‑t a tartalmazó XAML artifaktum könyvtárához képest, normalizálja a keletkező tárolási nevet, és erősítse meg, hogy a megfelelő térkép‑kulcs, ZIP bejegyzés vagy tárolt objektum létezik. Kezelje külön a külső URI‑kat és a XAML jelölés kifejezéseket a relatív fájlnevektől.

Például, ha a `pres/Slide_1.xaml` a `images/image1.png`‑re hivatkozik, a tárolt erőforrásnak a `pres/images/image1.png`‑ként kell elérhetőnek lennie. Csak a `image1.png` megtartása megszakítja ezt a kapcsolatot. Az objektumtároló esetén őrizze meg ugyanazt a struktúrát a feladat előtag alatt, és tegye ezeket a forrás‑URL‑eket elérhetővé a XAML fogyasztó számára. Nyissa meg újra a kész ZIP‑et a bejegyzésnevek és erőforrás‑bájtok ellenőrzéséhez, és töltsön be reprezentatív diákat a cél XAML környezetben, hogy megerősítse a képek helyes feloldását.

## **GYIK**

**Hogyan biztosíthatom a kiszámítható betűtípusokat, ha az eredeti betűtípus nem áll rendelkezésre a gépen?**

Hívja meg a [setDefaultRegularFont](https://reference.aspose.com/slides/hu/python-java/aspose.slides/saveoptions/#setDefaultRegularFont) metódust a [XamlOptions](https://reference.aspose.com/slides/hu/python-java/aspose.slides/xamloptions/) osztályban — ez az exportálás során a hiányzó eredeti betűtípus helyett tartalék betűtípusként kerül felhasználásra. Ez nem garantálja, hogy a generált XAML a tartalék betűtípust hivatkozza, vagy hogy a betűtípus elérhető legyen a célgépen. Győződjön meg arról, hogy a XAML által hivatkozott betűtípusok elérhetők abban a környezetben, ahol a megjelenítés történik.

**Az exportált XAML csak WPF‑hez szándékozott, vagy más XAML‑veremekben is használható?**

Az Aspose.Slides a nyilvános API-ján keresztül WPF XAML‑t exportál. Más XAML‑veremekkel, például az UWP‑vel vagy a Xamarin.Forms‑zal való kompatibilitás nem garantált. Tesztelje a generált jelölést a célkörnyezetben.

**Támogatottak a rejtett diák, és hogyan akadályozhatom meg, hogy alapértelmezés szerint exportálódjanak?**

Alapértelmezés szerint a rejtett diák nincsenek belefoglalva. Ezt a viselkedést a [setExportHiddenSlides](https://reference.aspose.com/slides/hu/python-java/aspose.slides/xamloptions/#setExportHiddenSlides) metódus segítségével szabályozhatja a [XamlOptions](https://reference.aspose.com/slides/hu/python-java/aspose.slides/xamloptions/) osztályban — tartsa letiltva, ha nem kell exportálnia őket.