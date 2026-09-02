---
title: PowerPoint betűtípusok testreszabása Pythonban
linktitle: Egyéni betűtípus
type: docs
weight: 20
url: /hu/python-net/custom-font/
keywords:
- betűtípus
- egyéni betűtípus
- külső betűtípus
- betűtípus betöltése
- betűtípusok kezelése
- betűtípus mappa
- PowerPoint
- prezentáció
- Python
- Aspose.Slides
description: "Ágyazz be egyéni betűtípusokat a PowerPoint diáknak az Aspose.Slides for Python segítségével .NET-en keresztül, hogy prezentációi tiszták és egységesek legyenek bármilyen eszközön."
---
## **Áttekintés**

Az Aspose.Slides for Python lehetővé teszi, hogy futásidőben egyéni betűtípusokat biztosítson, így a prezentációk helyesen jelennek meg akkor is, ha a szükséges betűtípusok nincsenek telepítve a gazdarendszeren. PDF vagy képek exportálása során megadhat betűtípus‑mappákat vagy memóriában lévő betűtípus adatokat, hogy megőrizze a szövegelrendezést, a glif mérőszámokat és a tipográfiát. Ez kiszámíthatóvá teszi a szerveroldali renderelést különböző környezetekben, eltávolítja az operációs rendszer szintű betűtípus‑függőségeket, és megakadályozza a nemkívánatos helyettesítéseket vagy újratervezést. A cikk bemutatja, hogyan lehet regisztrálni a betűtípusforrásokat.

Egy prezentációtémát különböző írásrendszerekhez külön betűtípus‑családok hivatkozhatnak. Ezek a leképezések csak a betűtípusneveket tárolják, de nem telepítik vagy töltik be a betűtípusfájlokat. Tekintse meg a [Script-Specific Theme Fonts](/slides/hu/python-net/script-specific-font-mappings/) oldalt a leképezések kezeléséhez, és használja az alábbi betöltési beállításokat, hogy a hivatkozott betűtípusok elérhetők legyenek az egységes megjelenítéshez.

Az Aspose.Slides lehetővé teszi a következő betűtípusok betöltését a `load_external_font` és `load_external_fonts` metódusok segítségével a [FontsLoader](https://reference.aspose.com/slides/hu/python-net/aspose.slides/fontsloader/) osztályban:

- TrueType (.ttf) és TrueType Collection (.ttc) betűtípusok. Lásd a [TrueType] linket.
- OpenType (.otf) betűtípusok. Lásd az [OpenType] linket.

## **Egyéni betűtípusok betöltése**

Az Aspose.Slides lehetővé teszi, hogy a prezentációban használt betűtípusokat a rendszerre telepítés nélkül betöltse. Ez befolyásolja az export eredményét – például PDF, képek és más támogatott formátumok – így a kapott dokumentumok környezetfüggetlenül konzisztensnek tűnnek. A betűtípusok egyéni könyvtárakból töltődnek be.

1. Adjon meg egy vagy több mappát, amely a betűtípusfájlokat tartalmazza.
2. Hívja meg a statikus [FontsLoader.load_external_fonts](https://reference.aspose.com/slides/hu/python-net/aspose.slides/fontsloader/load_external_fonts/) metódust, hogy betöltse a betűtípusokat ezekből a mappákból.
3. Töltse be és renderelje/exportálja a prezentációt.
4. Hívja meg a [FontsLoader.clear_cache](https://reference.aspose.com/slides/hu/python-net/aspose.slides/fontsloader/clear_cache/) metódust a betűtípus‑gyorsítótár törléséhez.

Az alábbi kódrészlet bemutatja a betűtípus‑betöltési folyamatot:

```py
import aspose.slides as slides

# Definiálja a saját betűtípus fájlokat tartalmazó mappákat.
font_folders = ["fonts", "external_fonts"]

# Töltsön be egyéni betűtípusokat a megadott mappákból.
slides.FontsLoader.load_external_fonts(font_folders)

with slides.Presentation("sample.pptx") as presentation:
    # Renderelje/exportálja a prezentációt (pl. PDF‑re, képekre vagy más formátumokra) a betöltött betűtípusokkal.
    presentation.save("output.pdf", slides.export.SaveFormat.PDF)

# Törölje a betűtípus gyorsítótárát a munka befejezése után.
slides.FontsLoader.clear_cache()
```

{{% alert color="info" title="Note" %}}
[FontsLoader.load_external_fonts](https://reference.aspose.com/slides/hu/python-net/aspose.slides/fontsloader/load_external_fonts/) további mappákat ad a betűtípus‑keresési útvonalakhoz, de nem változtatja meg a betűtípus inicializálási sorrendjét.
A betűtípusok a következő sorrendben inicializálódnak:

1. Az operációs rendszer alapértelmezett betűtípus útvonala.
1. A [FontsLoader](https://reference.aspose.com/slides/hu/python-net/aspose.slides/fontsloader/) által betöltött útvonalak.
{{%/alert %}}

## **Egyéni betűtípusok mappájának lekérése**

Az Aspose.Slides biztosítja a `get_font_folders` metódust a betűtípus‑mappák lekéréséhez. Ez visszaadja mind a `load_external_fonts` által hozzáadott, mind a rendszer betűtípus‑mappáit.

Ez a Python‑kód bemutatja a `get_font_folders` használatát:

```python
import aspose.slides as slides

# Ez a hívás visszaadja az ellenőrzött betűtípus fájlok mappáit.
# Ezek tartalmazzák a load_external_fonts metódussal hozzáadott mappákat és a rendszer betűtípus mappákat.
font_folders = slides.FontsLoader.get_font_folders()
```

## **Egyéni betűtípusok megadása egy prezentációhoz**

Az Aspose.Slides biztosítja a `document_level_font_sources` tulajdonságot, amely lehetővé teszi külső betűtípusok megadását a prezentációhoz.

Az alábbi Python‑példa mutatja a `document_level_font_sources` használatát:

```python
import aspose.slides as slides

with open("CustomFont1.ttf", "br") as font1_stream:
    font1_data = font1_stream.read()
    
with open("CustomFont2.ttf", "br") as font2_stream:
    font2_data = font2_stream.read()

load_options = slides.LoadOptions()
load_options.document_level_font_sources.font_folders = ["assets\\fonts", "global\\fonts"] 
load_options.document_level_font_sources.memory_fonts = [font1_data, font2_data]

with slides.Presentation("Fonts.pptx", load_options) as presentation:
    # ...
    # Dolgozz a prezentációval.
    # A CustomFont1, a CustomFont2 és az assets\fonts és global\fonts mappákból (és azok alkönyvtáraiból) származó betűtípusok elérhetők a prezentáció számára.
    # ...
    print(len(presentation.slides))
```

## **Külső betűtípusok betöltése bináris adatokból**

Az Aspose.Slides biztosítja a `load_external_font` metódust, hogy bináris adatokból külső betűtípusokat töltsön be.

Az alábbi Python‑példa bemutatja egy betűtípus betöltését bájt‑tömbből:

```python
import aspose.slides as slides

def read_all_bytes(file_path):
    with open(file_path, "rb") as file_stream:
        file_data = file_stream.read()
    return file_data

# Külső betűtípusok betöltése bájt tömbökből.
slides.FontsLoader.load_external_font(read_all_bytes("ARIALN.TTF"))
slides.FontsLoader.load_external_font(read_all_bytes("ARIALNBI.TTF"))
slides.FontsLoader.load_external_font(read_all_bytes("ARIALNI.TTF"))

try:
    with slides.Presentation() as presentation:
        # A külső betűtípusok elérhetők ennek a prezentációs példánynak az életciklusa alatt.
        print("processing")
finally:
    slides.FontsLoader.clear_cache()
```

## **GYIK**

### A egyéni betűtípusok befolyásolják az exportot minden formátumban (PDF, PNG, SVG, HTML)?

Igen. A csatlakoztatott betűtípusokat a renderelő minden exportformátumban használja.

### A egyéni betűtípusok automatikusan beágyazásra kerülnek a létrejövő PPTX‑be?

Nem. A betűtípus regisztrálása a rendereléshez nem ugyanaz, mint a PPTX‑be való beágyazás. Ha a betűtípust a prezentációfájlba szeretné beágyazni, akkor a kifejezett [beágyazási funkciók](/slides/hu/python-net/embedded-font/) funkciót kell használni.

### Kontrollálhatom a fallback viselkedést, ha egy egyéni betűtípus bizonyos glifekkel nem rendelkezik?

Igen. Állítsa be a [betűtípus helyettesítés](/slides/hu/python-net/font-substitution/), a [helyettesítő szabályok](/slides/hu/python-net/font-replacement/) és a [fallback készletek](/slides/hu/python-net/fallback-font/) lehetőségeket, hogy pontosan meghatározza, mely betűtípust használja a kért glif hiányában.

### Használhatok betűtípusokat Linux/Docker konténerekben anélkül, hogy a rendszer szintjén telepíteném őket?

Igen. Mutasson a saját betűtípus‑mappáira vagy töltsön be betűtípusokat bájt‑tömbökből. Ez megszünteti a rendszer betűtípus könyvtárakra való függőséget a konténer képen.

### Mi a helyzet a licenceléssel – beágyazhatok bármilyen egyéni betűtípust korlátozások nélkül?

Ön felelős a betűtípus‑licenc megfeleléséért. A feltételek változóak; egyes licencek tilthatják a beágyazást vagy a kereskedelmi felhasználást. Mindig ellenőrizze a betűtípus EULA‑ját, mielőtt a kimeneteket terjesztené.