---
title: Alacsony kódú prezentációs műveletek Pythonban
linktitle: Alacsony kódú API
type: docs
weight: 50
url: /hu/python-net/low-code-presentation-operations/
keywords:
- alacsony kódú prezentáció API
- prezentáció konvertálása
- prezentációk egyesítése
- alakzatok gyűjtése
- prezentáció tömörítése
- nem használt mesterdiák eltávolítása
- nem használt elrendezésdiák eltávolítása
- beágyazott betűtípusok tömörítése
- PowerPoint
- OpenDocument
- prezentáció
- Python
- Aspose.Slides
description: "Használja az Aspose.Slides alacsony kódú API-t Pythonban a prezentációk konvertálásához és egyesítéséhez, az alakzatok gyűjtéséhez, valamint a prezentáció méretének csökkentéséhez."
---
## **Áttekintés**

Az [aspose.slides.lowcode](https://reference.aspose.com/slides/hu/python-net/aspose.slides.lowcode/) modul segédosztályokat biztosít a gyakori prezentációs műveletekhez. Ezek a segédek a gyakran használt objektummodell-munkafolyamatokat fókuszált módszerekbe csomagolják, így kevesebb kóddal konvertálhat vagy egyesíthet fájlokat, gyűjthet alakzatokat, és eltávolíthatja a nem használt tartalmat.

Az alacsony kódú segédek a leghasznosabbak, ha a művelet egy teljes fájlra vagy prezentációra vonatkozik, és az alapértelmezett munkafolyamat megfelel az igényeinek. Használja a teljes [Aspose.Slides objektummodellt](https://reference.aspose.com/slides/hu/python-net/aspose.slides/), ha finomhangolt vezérlést igényel az egyes diák, mesterek, elrendezések, alakzatok, exportbeállítások vagy a prezentációelemek közötti kapcsolatok felett.

Az alábbi táblázat összefoglalja a rendelkezésre álló segédeket:

| Segédeszköz | Mire használható |
| --- | --- |
| [Convert](https://reference.aspose.com/slides/hu/python-net/aspose.slides.lowcode/convert/) | Prezentáció átalakítása egy másik formátumba közvetlen fájl‑fájl hívással. |
| [Merger](https://reference.aspose.com/slides/hu/python-net/aspose.slides.lowcode/merger/) | Ugyanazon formátumú teljes prezentációs fájlok egyesítése. |
| [Collect](https://reference.aspose.com/slides/hu/python-net/aspose.slides.lowcode/collect/) | Alakzatok lekérése a teljes prezentációból ismételt feldolgozás vagy elemzés céljából. |
| [Compress](https://reference.aspose.com/slides/hu/python-net/aspose.slides.lowcode/compress/) | Nem használt mesterek és elrendezések eltávolítása, valamint a beágyazott betűtípus adatok csökkentése. |

## **Prezentáció átalakítása**

Használja a [Convert.auto_by_extension](https://reference.aspose.com/slides/hu/python-net/aspose.slides.lowcode/convert/auto_by_extension/) amikor a kimeneti fájlkiterjesztés elegendő az exportformátum kiválasztásához. A metódus megnyitja a forrásprezentációt, meghatározza a szükséges formátumot a kimeneti útvonal alapján, és elmenti az eredményt.

```python
import aspose.slides as slides

slides.lowcode.Convert.auto_by_extension("input.pptx", "output.pdf")
```

A [Convert](https://reference.aspose.com/slides/hu/python-net/aspose.slides.lowcode/convert/) osztály dedikált metódusokat is biztosít PDF, SVG, JPEG, PNG és TIFF kimenethez. Használja a teljes objektummodellt, ha a prezentációt exportálás előtt ellenőrizni vagy módosítani kell, vagy olyan exportbeállítást kell konfigurálni, amelyet a kiválasztott segédeszköz nem tesz elérhetővé. Lásd a [Convert Presentation](/python-net/convert-presentation/) oldalt a formátumspecifikus munkafolyamatokért és opciókért.

## **Prezentációk egyesítése**

Használja a [Merger.process](https://reference.aspose.com/slides/hu/python-net/aspose.slides.lowcode/merger/process/) egyetlen hívással a teljes prezentációs fájlok egyesítéséhez. A bemeneti prezentációknak azonos fájlformátummal kell rendelkezniük.

```python
import aspose.slides as slides

input_files = ["part-1.pptx", "part-2.pptx"]
slides.lowcode.Merger.process(input_files, "merged.pptx")
```

A segédeszköz megfelelő, ha az összes diát egy eredménybe kell hozzáfűzni anélkül, hogy egyenként kiválasztaná vagy átképezi őket. Használja a teljes objektummodellt, ha kiválasztott diák egyesítésére, célmester vagy -elrendezés alkalmazására, szekciók explicite megőrzésére vagy eltérő diaszámok egyeztetésére van szükség. Lásd a [Merge Presentations](/python-net/merge-presentation/) oldalt az ilyen esetekhez.

## **Alakzatok gyűjtése**

Használja a [Collect.shapes](https://reference.aspose.com/slides/hu/python-net/aspose.slides.lowcode/collect/shapes/) amikor a prezentáció összes alakzatának gyűjteményére van szükség. Ez akkor hasznos, ha ugyanazt a halmazt többször szűrni, számlálni vagy feldolgozni kívánja.

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    shapes = slides.lowcode.Collect.shapes(presentation)

    for shape in shapes:
        print(f"{shape.name}: {type(shape).__name__}")
```

Használjon közvetlen gyűjteményciklusokat, ha a bejárási sorrend, korai kilépés, a feldolgozás előtti szűrés vagy a részletes szülő‑gyermek vezérlés fontos.

## **Prezentáció tartalmának tömörítése**

A [Compress](https://reference.aspose.com/slides/hu/python-net/aspose.slides.lowcode/compress/) osztály képes eltávolítani a nem használt szerkezeti elemeket és csökkenteni a beágyazott betűtípus adatokat:

- [Compress.remove_unused_layout_slides](https://reference.aspose.com/slides/hu/python-net/aspose.slides.lowcode/compress/remove_unused_layout_slides/) eltávolítja azokat az elrendezésdíákat, amelyeket egyetlen normál dia sem hivatkozik.
- [Compress.remove_unused_master_slides](https://reference.aspose.com/slides/hu/python-net/aspose.slides.lowcode/compress/remove_unused_master_slides/) eltávolítja a már nem használt mesterdíákat.
- [Compress.compress_embedded_fonts](https://reference.aspose.com/slides/hu/python-net/aspose.slides.lowcode/compress/compress_embedded_fonts/) eltávolítja a beágyazott betűtípusokból a nem használt karaktereket.

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    slides.lowcode.Compress.remove_unused_layout_slides(presentation)
    slides.lowcode.Compress.remove_unused_master_slides(presentation)
    slides.lowcode.Compress.compress_embedded_fonts(presentation)

    presentation.save("compressed.pptx", slides.export.SaveFormat.PPTX)
```

Előbb távolítsa el a nem használt elrendezéseket, mint a nem használt mestereket, hogy az elrendezés tisztítása után hivatkozás nélküli mester is eltávolítható legyen. Mentse az optimalizált prezentációt egy új fájlba, ha később szüksége lehet az eredeti mesterekre, elrendezésekre vagy a teljes beágyazott betűtípus adatokra. További részletekért lásd a [Slide Master](/python-net/slide-master/) és a [Embedded Font](/python-net/embedded-font/) oldalakat.

## **Gyakran Ismételt Kérdések**

**Mikor kell használni az alacsony kódú API-t a teljes objektummodell helyett?**

Használja az alacsony kódú segédeszközöket, ha egy szabványos művelet egy teljes fájlra vagy prezentációra vonatkozik, és nem igényel részletes vezérlést az egyedi elemek felett. Használja a teljes objektummodellt, ha konkrét diák kiválasztására, a mester‑ és elrendezéskapcsolatok irányítására, a köztes állapot ellenőrzésére vagy olyan viselkedés konfigurálására van szükség, amelyet a segédeszköz nem tesz elérhetővé.

**Kombinálhat‑e a Merger különböző fájlformátumú prezentációkat?**

Nem. A [Merger.process](https://reference.aspose.com/slides/hu/python-net/aspose.slides.lowcode/merger/process/) megköveteli, hogy a bemeneti prezentációk azonos formátumban legyenek. Először konvertálja a bemeneti fájlokat egy közös formátumba, például a [Convert.auto_by_extension](https://reference.aspose.com/slides/hu/python-net/aspose.slides.lowcode/convert/auto_by_extension/) segítségével, majd egyesítse a konvertált fájlokat.

**Mit tartalmaz a Collect.shapes?**

A [Collect.shapes](https://reference.aspose.com/slides/hu/python-net/aspose.slides.lowcode/collect/shapes/) a prezentációból lekérdezi az alakzatokat, hogy azokat megtartani, szűrni, számlálni vagy többször bejárni lehessen. Használjon közvetlen gyűjteményciklusokat, ha pontosan kell irányítani, mely dia típusok vagy beágyazott objektumok kerüljenek bejárásra.

**Mindig csökkenti a Compress a prezentáció fájlméretét?**

Nem feltétlenül. Az eredmény attól függ, hogy a prezentáció tartalmaz‑e nem használt elrendezéseket, nem használt mestereket vagy beágyazott betűtípusokat nem használt karakterekkel. Ha egy sem áll fenn, akkor a megfelelő [Compress](https://reference.aspose.com/slides/hu/python-net/aspose.slides.lowcode/compress/) műveletek nem csökkenthetik a fájlméretet.

**A Compress által végzett változtatások automatikusan mentésre kerülnek?**

Nem. Ezek a segédeszközök a betöltött [Presentation](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentation/) objektumon a memóriában dolgoznak. A [Compress](https://reference.aspose.com/slides/hu/python-net/aspose.slides.lowcode/compress/) futtatása után hívja meg a [Presentation.save](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentation/save/) metódust az eredmény írásához.

## **Kapcsolódó cikkek**

- [Convert Presentation](/python-net/convert-presentation/)
- [Merge Presentations](/python-net/merge-presentation/)
- [Slide Master](/python-net/slide-master/)
- [Manage Text Box](/python-net/manage-textbox/)
- [Embedded Font](/python-net/embedded-font/)