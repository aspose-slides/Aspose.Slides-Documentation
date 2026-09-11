---
title: PowerPoint betűtípusok testreszabása Pythonban Java segítségével
linktitle: Egyéni betűtípus
type: docs
weight: 20
url: /hu/python-java/custom-font/
keywords:
- betűtípus
- egyéni betűtípus
- külső betűtípus
- betűtípus betöltése
- betűtípusok kezelése
- betűtípus mappa
- PowerPoint
- OpenDocument
- bemutató
- Python
- Java
- Aspose.Slides
description: "Testreszabhatja a betűtípusokat a PowerPoint diákon az Aspose.Slides for Python via Java segítségével, hogy prezentációi élesek és konzisztensak maradjanak minden eszközön."
---
## **Áttekintés**

Az Aspose.Slides lehetővé teszi egyéni betűtípusok használatát a bemutatókban anélkül, hogy telepítené őket az operációs rendszerben. Betűtípusokat tölthet be egyéni mappákból, biztosíthat betűtípusokat egy adott bemutatóhoz dokumentumszintű betűforrásokkal, vagy betöltheti a külső betűtípusokat közvetlenül bináris adatokból.

A betöltött betűtípusokat a bemutató renderelésekor vagy exportálásakor (például PDF, képek és egyéb támogatott formátumok) használja. Ez segít a bemutató kimenet következetességének megőrzésében különböző környezetekben. A cikk bemutatja, hogyan ellenőrizheti az Aspose.Slides által használt betűtárgy könyvtárakat, és hogyan tisztíthatja a betűtárgy gyorsítótárat külső betűtípusok használata után.

Az egyéni betűtípusok regisztrálása a rendereléshez különbözik a betűtípusok PPTX fájlba ágyazásától. Ha a betűtípust magában a bemutatóban kell tárolni, használja a betűtípus‑ágyazási funkciókat kifejezetten.

Egy bemutatótéma különböző írásrendszerekhez külön betűcsaládokra hivatkozhat. Ezek a leképezések csak a betűtípus nevét tárolják, de nem telepítik vagy töltik be a betűtípus fájlokat. Lásd a [Szkript‑specifikus témabeli betűkészletek](/slides/hu/python-java/script-specific-font-mappings/) oldalt a leképezések kezeléséhez, és használja az alábbi betöltési beállításokat, hogy a hivatkozott betűtípusok elérhetők legyenek a következetes rendereléshez.

{{% alert color="info" title="Megjegyzés" %}}

Az Aspose.Slides lehetővé teszi ezen betűtípusok betöltését a [loadExternalFonts](https://reference.aspose.com/slides/hu/python-java/aspose.slides/fontsloader/#loadExternalFonts) metódus segítségével:

* TrueType (.ttf) és TrueType Collection (.ttc) betűtípusok. Lásd a [TrueType](https://en.wikipedia.org/wiki/TrueType) oldalt.
* OpenType (.otf) betűtípusok. Lásd az [OpenType](https://en.wikipedia.org/wiki/OpenType) oldalt.

{{% /alert %}}

## **Egyéni betűtípusok betöltése**

Az Aspose.Slides lehetővé teszi a bemutatóban használt betűtípusok betöltését anélkül, hogy azokat a rendszerre telepítené. Ez befolyásolja az exportálási kimenetet – például PDF, képek és egyéb támogatott formátumok – így a létrehozott dokumentumok konzisztensnek jelennek meg a különböző környezetekben. A betűtípusok egyéni könyvtárakból töltődnek be.

1. Adjon meg egy vagy több mappát, amely a betűtípus‑fájlokat tartalmazza.
2. Hívja meg a statikus [FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/hu/python-java/aspose.slides/fontsloader/#loadExternalFonts) metódust a betűtípusok betöltéséhez ezekből a mappákból.
3. Töltse be és renderelje/exportálja a bemutatót.
4. Hívja meg a [FontsLoader.clearCache](https://reference.aspose.com/slides/hu/python-java/aspose.slides/fontsloader/#clearCache) metódust a betűtípus‑gyorsítótár törléséhez.

Az alábbi kódrészlet bemutatja a betűtípus‑betöltési folyamatot:

```python
from jpype import JArray, JString
from asposeslides.api import FontsLoader, Presentation, SaveFormat

# Definiálja az egyéni betűtípus fájlokat tartalmazó mappákat.
font_folders = JArray(JString)(["assets/fonts", "global/fonts"])

# Töltse be az egyéni betűtípusokat a megadott mappákból.
FontsLoader.loadExternalFonts(font_folders)

presentation = None
try:
    presentation = Presentation("sample.pptx")

    # Renderelje/exportálja a bemutatót a betöltött betűtípusok használatával.
    presentation.save("output.pdf", SaveFormat.Pdf)
finally:
    if presentation is not None:
        presentation.dispose()

    # Törölje a betűtípus gyorsítótárat a munka befejezése után.
    FontsLoader.clearCache()
```

{{% alert color="info" title="Megjegyzés" %}}

A [FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/hu/python-java/aspose.slides/fontsloader/#loadExternalFonts) további mappákat ad a betűtípus‑keresési útvonalakhoz, de nem változtatja meg a betűtípus‑inicializálás sorrendjét.  
A betűtípusok a következő sorrendben inicializálódnak:

1. Az alapértelmezett operációs rendszer betűtípus‑útvonala.
1. A [FontsLoader](https://reference.aspose.com/slides/hu/python-java/aspose.slides/fontsloader/) által betöltött útvonalak.

{{%/alert %}}

## **Egyéni betűtárgy-könyvtárak lekérdezése**

Az Aspose.Slides biztosítja a [getFontFolders](https://reference.aspose.com/slides/hu/python-java/aspose.slides/fontsloader/#getFontFolders) metódust, amely lehetővé teszi a betűtárgy‑könyvtárak megtalálását. Ez a metódus visszaadja a [loadExternalFonts](https://reference.aspose.com/slides/hu/python-java/aspose.slides/fontsloader/#loadExternalFonts) metódussal hozzáadott mappákat, valamint a rendszer betűtárgy‑könyvtárait.

Ez a Python kód megmutatja, hogyan használja a [getFontFolders](https://reference.aspose.com/slides/hu/python-java/aspose.slides/fontsloader/#getFontFolders) metódust:

```python
from asposeslides.api import FontsLoader

# A loadExternalFonts által hozzáadott és a rendszer betűtípus mappáit kapja meg.
font_folders = FontsLoader.getFontFolders()
```

## **Egyéni betűtípusok megadása egy bemutatóhoz**

Az Aspose.Slides biztosítja a [getDocumentLevelFontSources](https://reference.aspose.com/slides/hu/python-java/aspose.slides/loadoptions/#getDocumentLevelFontSources) metódust, amely lehetővé teszi, hogy külső betűtípusokat adjon meg, amelyeket a bemutatóval együtt használnak.

Ez a Python kód megmutatja, hogyan használja a [getDocumentLevelFontSources](https://reference.aspose.com/slides/hu/python-java/aspose.slides/loadoptions/#getDocumentLevelFontSources) metódust:

```python
from pathlib import Path
from jpype import JArray, JByte, JString
from asposeslides.api import LoadOptions, Presentation

memory_font_primary = Path("customfonts/CustomFont1.ttf").read_bytes()
memory_font_secondary = Path("customfonts/CustomFont2.ttf").read_bytes()

load_options = LoadOptions()
font_folders = JArray(JString)(["assets/fonts", "global/fonts"])
memory_fonts = JArray(JByte, 2)([memory_font_primary, memory_font_secondary])
load_options.getDocumentLevelFontSources().setFontFolders(font_folders)
load_options.getDocumentLevelFontSources().setMemoryFonts(memory_fonts)

presentation = Presentation("MyPresentation.pptx", load_options)
try:
    # Dolgozzon a bemutatóval.
    # A CustomFont1, CustomFont2, valamint a assets/fonts és a global/fonts mappákból származó betűtípusok
    # és azok alkönyvtárai elérhetők a bemutató számára.
    pass
finally:
    presentation.dispose()
```

## **Betűtípusok külső kezelése**

Az Aspose.Slides biztosítja a [loadExternalFont](https://reference.aspose.com/slides/hu/python-java/aspose.slides/fontsloader/#loadExternalFont) metódust, amely lehetővé teszi külső betűtípusok betöltését bináris adatokból.

Ez a Python kód bemutatja a bájt‑tömb alapú betűtípus‑betöltési folyamatot:

```python
from pathlib import Path
from jpype import JArray, JByte
from asposeslides.api import FontsLoader, Presentation

font_data = Path("ARIALN.TTF").read_bytes()
FontsLoader.loadExternalFont(JArray(JByte)(font_data))
font_data = Path("ARIALNBI.TTF").read_bytes()
FontsLoader.loadExternalFont(JArray(JByte)(font_data))
font_data = Path("ARIALNI.TTF").read_bytes()
FontsLoader.loadExternalFont(JArray(JByte)(font_data))

try:
    presentation = Presentation()
    try:
        # A külső betűtípusok a bemutató élettartama alatt töltődnek be.
        pass
    finally:
        presentation.dispose()
finally:
    FontsLoader.clearCache()
```

## **GYIK**

**Az egyéni betűtípusok befolyásolják az összes formátumba történő exportot (PDF, PNG, SVG, HTML)?**

Igen. A kapcsolódó betűtípusok a renderelő által az összes exportformátumban felhasználásra kerülnek.

**Az egyéni betűtípusok automatikusan be vannak ágyazva a létrejövő PPTX‑be?**

Nem. A betűtípus regisztrálása a rendereléshez nem ugyanaz, mint a PPTX‑be való ágyazás. Ha a betűtípust a bemutató fájlon belül szeretné megtartani, használja a kifejezett [ágyazási funkciókat](/slides/hu/python-java/embedded-font/).

**Irányíthatom a helyettesítési viselkedést, ha egy egyéni betűtípus nem tartalmaz bizonyos glypheket?**

Igen. Konfigurálja a [betűtípus‑helyettesítést](/slides/hu/python-java/font-substitution/), a [helyettesítési szabályokat](/slides/hu/python-java/font-replacement/), és a [fallback‑készleteket](/slides/hu/python-java/fallback-font/), hogy pontosan meghatározza, melyik betűtípust használja a hiányzó glif esetén.

**Használhatok betűtípusokat Linux/Docker konténerekben anélkül, hogy a rendszerre telepíteném őket?**

Igen. Hivatkozhat saját betűtárgy‑könyvtárakra vagy betöltheti a betűtípusokat bájt‑tömbökből. Így nincs függőség a konténer‑képen lévő rendszer‑betűtárgy‑könyvtáraktól.

**Mi van a licenceléssel – beágyazhatok bármilyen egyéni betűtípust korlátozások nélkül?**

Ön felelős a betűtípus‑licenc megfeleléséért. A feltételek változhatnak; egyes licencek tiltják az ágyazást vagy a kereskedelmi felhasználást. Mindig ellenőrizze a betűtípus EULA‑ját a kimenetek terjesztése előtt.