---
title: Testreszabott PowerPoint betűkészletek Pythonban
linktitle: Egyedi betűkészlet
type: docs
weight: 20
url: /hu/python-net/custom-font/
keywords:
- betűkészlet
- egyedi betűkészlet
- külső betűkészlet
- betűkészlet betöltése
- betűkészletek kezelése
- betűkészlet mappa
- PowerPoint
- bemutató
- Python
- Aspose.Slides
description: "Ágyazz be egyedi betűkészleteket PowerPoint diákba az Aspose.Slides for Python segítségével .NET-en keresztül, hogy bemutatóid élesek és konzisztensen jelenjenek meg bármilyen eszközön."
---
## **Áttekintés**

Az Aspose.Slides for Python lehetővé teszi egyedi betűkészletek biztosítását futásidőben, így a bemutatók helyesen jelennek meg akkor is, ha a szükséges betűkészletek nincsenek telepítve a gazda rendszeren. PDF‑ vagy képekre való exportálás közben betűkészlet‑mappákat vagy memóriában lévő betűkészlet‑adatokat adhat meg a szövegelrendezés, a glif‑metrikák és a tipográfia megőrzése érdekében. Ez előre láthatóvá teszi a szerveroldali renderelést különböző környezetekben, eltávolítja az operációs rendszer szintű betűkészlet‑függőségeket, és megakadályozza a nem kívánt helyettesítéseket vagy újra‑tördelést. A cikk bemutatja, hogyan regisztrálhat betűkészlet‑forrásokat.

Az Aspose.Slides a következő betűkészleteket töltheti be a `load_external_font` és `load_external_fonts` metódusokkal a [FontsLoader](https://reference.aspose.com/slides/hu/python-net/aspose.slides/fontsloader/) osztályból:

- TrueType (.ttf) és TrueType Collection (.ttc) betűkészletek. Lásd a [TrueType](https://en.wikipedia.org/wiki/TrueType) oldalt.
- OpenType (.otf) betűkészletek. Lásd a [OpenType](https://en.wikipedia.org/wiki/OpenType) oldalt.

## **Egyedi betűkészletek betöltése**

Az Aspose.Slides lehetővé teszi, hogy a bemutatóban használt betűkészleteket betöltse anélkül, hogy azokat a rendszerre telepítené. Ez hatással van az exportálási kimenetre – például PDF, képek és más támogatott formátumok – így a keletkező dokumentumok környezetfüggetlenül egységesek maradnak. A betűkészleteket egyedi könyvtárakból tölti be.

1. Adjon meg egy vagy több mappát, amely a betűkészlet‑fájlokat tartalmazza.
2. Hívja meg a statikus [FontsLoader.load_external_fonts](https://reference.aspose.com/slides/hu/python-net/aspose.slides/fontsloader/load_external_fonts/) metódust a betűkészletek betöltéséhez az adott mappákból.
3. Töltse be és renderelje/exportálja a bemutatót.
4. Hívja meg a [FontsLoader.clear_cache](https://reference.aspose.com/slides/hu/python-net/aspose.slides/fontsloader/clear_cache/) metódust a betűkészlet‑gyorsítótár törléséhez.

Az alábbi kódrészlet bemutatja a betűkészlet‑betöltési folyamatot:

```py
import aspose.slides as slides

# Határozzon meg mappákat, amelyek egyedi betűkészlet-fájlokat tartalmaznak.
font_folders = [ external_font_folder1, external_font_folder2 ]

# Töltse be az egyedi betűkészleteket a megadott mappákból.
slides.FontsLoader.load_external_fonts(font_folders)

with slides.Presentation("sample.pptx") as presentation:
    # Renderelje/exportálja a bemutatót (például PDF-re, képekre vagy más formátumokra) a betöltött betűkészletek használatával.
    presentation.save("output.pdf", slides.export.SaveFormat.PDF)

# Törölje a betűkészlet gyorsítótárát a munka befejezése után.
slides.FontsLoader.clear_cache()
```

{{% alert color="info" title="Note" %}}
[FontsLoader.load_external_fonts](https://reference.aspose.com/slides/hu/python-net/aspose.slides/fontsloader/load_external_fonts/) további mappákat ad a betűkészlet‑keresési útvonalakhoz, de nem módosítja a betűkészlet‑inicializálás sorrendjét.
A betűkészletek ebben a sorrendben kerülnek inicializálásra:

1. Az operációs rendszer alapértelmezett betűkészlet‑útvonala.
1. A [FontsLoader](https://reference.aspose.com/slides/hu/python-net/aspose.slides/fontsloader/) által betöltött útvonalak.
{{%/alert %}}

## **Az egyedi betűkészlet‑mappa lekérése**

Az Aspose.Slides a `get_font_folders` metódust biztosítja a betűkészlet‑mappák lekérdezéséhez. Visszaadja mind a `load_external_fonts`‑szel hozzáadott, mind a rendszer betűkészlet‑mappáit.

Ez a Python‑kód bemutatja a `get_font_folders` használatát:

```python
import aspose.slides as slides

# Ez a hívás visszaadja azokat a mappákat, amelyekben betűkészlet-fájlok keresésre kerülnek.
# Ezek tartalmazzák a load_external_fonts metódussal hozzáadott mappákat és a rendszer betűkészlet-mappákat.
font_folders = slides.FontsLoader.get_font_folders()
```

## **Egyedi betűkészletek megadása egy bemutatóhoz**

Az Aspose.Slides a `document_level_font_sources` tulajdonságot biztosítja, amely lehetővé teszi külső betűkészletek megadását egy bemutatóhoz.

Az alábbi Python‑példa megmutatja a `document_level_font_sources` használatát:

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
    # A prezentációval dolgozni.
    # A CustomFont1, CustomFont2 és a assets\fonts és global\fonts mappákból (és azok alkönyvtáraiból) származó betűkészletek elérhetők a prezentáció számára.
    # ...
    print(len(presentation.slides))
```

## **Külső betűkészletek betöltése bináris adatokból**

Az Aspose.Slides a `load_external_font` metódust kínálja külső betűkészletek bináris adatokból történő betöltéséhez.

Az alábbi Python‑példa demonstrálja egy betűkészlet betöltését egy bájt‑tömbből:

```python
import aspose.slides as slides

def read_all_bytes(file_path):
    with open(file_path, "rb") as file_stream:
        file_data = file_stream.read()
    return file_data

# Betöltse a külső betűkészleteket bájt tömbökből.
slides.FontsLoader.load_external_font(read_all_bytes("ARIALN.TTF"))
slides.FontsLoader.load_external_font(read_all_bytes("ARIALNBI.TTF"))
slides.FontsLoader.load_external_font(read_all_bytes("ARIALNI.TTF"))

try:
    with slides.Presentation() as presentation:
        # A külső betűkészletek a bemutató példány élettartama alatt érhetők el.
        print("processing")
finally:
    slides.FontsLoader.clear_cache()
```

## **GYIK**

**Érintik-e az egyedi betűkészletek az összes formátumra (PDF, PNG, SVG, HTML) történő exportálást?**

Igen. A kapcsolódó betűkészleteket a renderelő minden exportálási formátumban használja.

**Ágyazódnak‑e automatikusan az egyedi betűkészletek a létrejövő PPTX‑be?**

Nem. A betűkészlet regisztrálása a rendereléshez nem ugyanaz, mint a PPTX‑be való beágyazás. Ha a betűkészletet a bemutató fájljába szeretné beágyazni, használja a kifejezett [beágyazási funkciókat](/slides/hu/python-net/embedded-font/).

**Szabályozhatom‑e a helyettesítési viselkedést, ha egy egyedi betűkészletnek hiányoznak bizonyos glify?**

Igen. Állítsa be a [betűkészlet‑helyettesítést](/slides/hu/python-net/font-substitution/), a [csere‑szabályokat](/slides/hu/python-net/font-replacement/), és a [helyettesítő‑készleteket](/slides/hu/python-net/fallback-font/), hogy pontosan meghatározza, melyik betűkészletet használja a hiányzó glif esetén.

**Használhatok‑e betűkészleteket Linux/Docker konténerekben anélkül, hogy rendszer‑szintű telepítést végeznék?**

Igen. Mutasson saját betűkészlet‑mappákra vagy töltse be a betűkészleteket bájt‑tömbökből. Ez eltávolítja a rendszer betűkészlet‑könyvtárakra való függőséget a konténer‑képből.

**Mi a helyzet a licenceléssel – beágyazhatok‑e bármilyen egyedi betűkészletet korlátozások nélkül?**

Ön felelős a betűkészlet‑licenceléssel kapcsolatos megfelelésért. A feltételek változóak; egyes licencek tilthatják a beágyazást vagy a kereskedelmi felhasználást. Mindig ellenőrizze a betűkészlet EULA‑ját, mielőtt a kimeneteket terjesztené.