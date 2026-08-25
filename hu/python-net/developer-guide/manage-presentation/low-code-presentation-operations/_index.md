---
title: Alacsony kódú prezentációs műveletek Pythonban
linktitle: Alacsony kódú API
type: docs
weight: 50
url: /hu/python-net/low-code-presentation-operations/
keywords:
- alacsony kódú prezentációs API
- prezentáció konvertálása
- prezentációk egyesítése
- alakzatok gyűjtése
- prezentáció tömörítése
- nem használt master diák eltávolítása
- nem használt layout diák eltávolítása
- beágyazott betűkészletek tömörítése
- PowerPoint
- OpenDocument
- prezentáció
- Python
- Aspose.Slides
description: "Használja az Aspose.Slides alacsony kódú API-t Pythonban a prezentációk konvertálásához és egyesítéséhez, az alakzatok gyűjtéséhez, valamint a prezentáció méretének csökkentéséhez."
---
## **Áttekintés**

A [aspose.slides.lowcode](https://reference.aspose.com/slides/hu/python-net/aspose.slides.lowcode/) modul segédosztályokat biztosít a gyakori prezentációs műveletekhez. Ezek a segédosztályok a gyakran használt objektummodell munkafolyamatokat fókuszált metódusokba csomagolják, így kevesebb kóddal konvertálhat vagy egyesíthet fájlokat, gyűjthet alakzatokat, és eltávolíthatja a nem használt tartalmat.

Az alacsony kódú segédprogramok a leghasznosabbak, ha a művelet egy egész fájlra vagy prezentációra vonatkozik, és az alapértelmezett munkafolyamat megfelel az igényeinek. Használja a teljes [Aspose.Slides objektummodellt](https://reference.aspose.com/slides/hu/python-net/aspose.slides/) ha finomhangolt irányítást szeretne az egyes diák, főmasterek, elrendezések, alakzatok, exportbeállítások vagy a prezentációelemek közötti kapcsolatok felett.

Az alábbi táblázat összefoglalja a rendelkezésre álló segédprogramokat:

| Helper | Use it for |
| --- | --- |
| [Convert](https://reference.aspose.com/slides/hu/python-net/aspose.slides.lowcode/convert/) | Prezentáció átalakítása más formátumba közvetlen fájl‑fájl hívással. |
| [Merger](https://reference.aspose.com/slides/hu/python-net/aspose.slides.lowcode/merger/) | Ugyanazon formátumú teljes prezentációs fájlok egyesítése. |
| [Collect](https://reference.aspose.com/slides/hu/python-net/aspose.slides.lowcode/collect/) | Alakzatok lekérése a teljes prezentációból ismételt feldolgozáshoz vagy elemzéshez. |
| [Compress](https://reference.aspose.com/slides/hu/python-net/aspose.slides.lowcode/compress/) | Nem használt master‑ és elrendezés‑diákok eltávolítása és a beágyazott betűkészlet‑adatok csökkentése. |

## **Prezentáció átalakítása**

Használja a [Convert.auto_by_extension](https://reference.aspose.com/slides/hu/python-net/aspose.slides.lowcode/convert/auto_by_extension/)‑t, ha a kimeneti fájlkiterjesztés elegendő az exportformátum kiválasztásához. A metódus megnyitja a forrásprezentációt, meghatározza a kimeneti útból a szükséges formátumot, és kiírja az eredményt.

```python
import aspose.slides as slides

slides.lowcode.Convert.auto_by_extension("input.pptx", "output.pdf")
```

A [Convert](https://reference.aspose.com/slides/hu/python-net/aspose.slides.lowcode/convert/) osztály dedikált módszereket is biztosít a PDF, SVG, JPEG, PNG és TIFF kimenetekhez. Használja a teljes objektummodellt, ha a prezentációt exportálás előtt ellenőrizni vagy módosítani kell, vagy olyan exportbeállítást szeretne konfigurálni, amelyet a kiválasztott segédprogram nem biztosít. Lásd a [Convert Presentation](/slides/hu/python-net/convert-presentation/) oldalt a formátumspecifikus munkafolyamatokhoz és beállításokhoz.

## **Prezentációk egyesítése**

Használja a [Merger.process](https://reference.aspose.com/slides/hu/python-net/aspose.slides.lowcode/merger/process/)‑t a teljes prezentációs fájlok egy hívással történő egyesítéséhez. A bemeneti prezentációknak azonos fájlformátummal kell rendelkezniük.

```python
import aspose.slides as slides

input_files = ["part-1.pptx", "part-2.pptx"]
slides.lowcode.Merger.process(input_files, "merged.pptx")
```

A segédprogram akkor megfelelő, ha az összes diát egy eredménybe kell hozzáfűzni anélkül, hogy egyenként kiválasztanánk vagy átképeznénk őket. Használja a teljes objektummodellt, ha kiválasztott diák egyesítésére, célmasternél vagy elrendezésnél alkalmazásra, a szekciók kifejezett megőrzésére, vagy különböző diaméretek egyeztetésére van szükség. Lásd a [Merge Presentations](/slides/hu/python-net/merge-presentation/) oldalt ezekhez a forgatókönyvekhez.

## **Alakzatok gyűjtése**

Használja a [Collect.shapes](https://reference.aspose.com/slides/hu/python-net/aspose.slides.lowcode/collect/shapes/)‑t, ha a prezentáció összes alakzatának gyűjteményére van szükség. Ez akkor hasznos, ha ugyanazt a halmazt többször szűrni, számlálni vagy feldolgozni kell.

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    shapes = slides.lowcode.Collect.shapes(presentation)

    for shape in shapes:
        print(f"{shape.name}: {type(shape).__name__}")
```

Használjon közvetlen gyűjtemény‑ciklusokat, ha a bejárási sorrend, a korai kilépés, a feldolgozás előtti szűrés vagy a részletes szülő‑gyermek vezérlés fontos.

## **Prezentáció tartalmának tömörítése**

A [Compress](https://reference.aspose.com/slides/hu/python-net/aspose.slides.lowcode/compress/) osztály képes eltávolítani a nem használt struktúralelemeket és csökkenteni a beágyazott betűkészlet‑adatokat:

- [Compress.remove_unused_layout_slides](https://reference.aspose.com/slides/hu/python-net/aspose.slides.lowcode/compress/remove_unused_layout_slides/) eltávolítja azokat a layout‑diákat, amelyeket nincs normál dia hivatkozva.
- [Compress.remove_unused_master_slides](https://reference.aspose.com/slides/hu/python-net/aspose.slides.lowcode/compress/remove_unused_master_slides/) eltávolítja azokat a master‑diákat, amelyek már nincsenek használatban.
- [Compress.compress_embedded_fonts](https://reference.aspose.com/slides/hu/python-net/aspose.slides.lowcode/compress/compress_embedded_fonts/) eltávolítja a beágyazott betűkészletekből a nem használt karaktereket.

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    slides.lowcode.Compress.remove_unused_layout_slides(presentation)
    slides.lowcode.Compress.remove_unused_master_slides(presentation)
    slides.lowcode.Compress.compress_embedded_fonts(presentation)

    presentation.save("compressed.pptx", slides.export.SaveFormat.PPTX)
```

Először távolítsa el a nem használt elrendezéseket, majd a nem használt master‑diákat, hogy a layout‑takarítás után hivatkozás nélküli master is eltávolítható legyen. Mentse az optimalizált prezentációt egy új fájlba, ha később szüksége lehet az eredeti master‑diákra, elrendezésekre vagy a teljes beágyazott betűkészlet‑adatra. További részletekért lásd a [Slide Master](/slides/hu/python-net/slide-master/) és a [Embedded Font](/slides/hu/python-net/embedded-font/) oldalakat.

## **FAQ**

**Mikor kell az alacsony‑kódú API‑t használni a teljes objektummodell helyett?**

Használjon alacsony‑kódú segédprogramokat, ha egy szabványos művelet egy teljes fájlra vagy prezentációra vonatkozik, és nem igényel részletes irányítást az egyes elemek felett. Használja a teljes objektummodellt, ha konkrét diákat kell kiválasztani, master‑ és elrendezés‑kapcsolatokat irányítani, a köztes állapotot ellenőrizni vagy olyan viselkedést konfigurálni kell, amelyet a segédprogram nem tesz közzé.

**Kombinálhat‑e a Merger különböző fájlformátumú prezentációkat?**

NEM. A [Merger.process](https://reference.aspose.com/slides/hu/python-net/aspose.slides.lowcode/merger/process/) megköveteli, hogy a bemeneti prezentációk azonos formátumban legyenek. Először konvertálja a bemeneti fájlokat egy közös formátumba, például a [Convert.auto_by_extension](https://reference.aspose.com/slides/hu/python-net/aspose.slides.lowcode/convert/auto_by_extension/)‑vel, majd egyesítse a konvertált fájlokat.

**Mit tartalmaz a Collect.shapes?**

A [Collect.shapes](https://reference.aspose.com/slides/hu/python-net/aspose.slides.lowcode/collect/shapes/) lekéri a prezentáció alakzatait, hogy megtartók, szűrők, számlálók vagy többször bejárhatók legyenek. Használjon közvetlen gyűjtemény‑ciklusokat, ha pontosan szabályozni szeretné, mely diatípusok vagy beágyazott objektumok kerülnek felkeresésre.

**A Compress mindig kisebbre csökkenti a prezentáció fájlját?**

Nem feltétlenül. Az eredmény attól függ, hogy a prezentáció tartalmaz‑e nem használt elrendezéseket, nem használt master‑diákat vagy beágyazott betűkészleteket nem használt karakterekkel. Ha egyik sem áll fenn, a megfelelő [Compress](https://reference.aspose.com/slides/hu/python-net/aspose.slides.lowcode/compress/) műveletek nem biztos, hogy csökkentik a fájlméretet.

**A Compress által végzett módosítások automatikusan mentésre kerülnek?**

NEM. Ezek a segédprogramok a betöltött [Presentation](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentation/) objektumon memóriában működnek. A [Compress](https://reference.aspose.com/slides/hu/python-net/aspose.slides.lowcode/compress/) futtatása után hívja meg a [Presentation.save](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentation/save/) metódust az eredmény írásához.

## **Kapcsolódó cikkek**

- [Convert Presentation](/slides/hu/python-net/convert-presentation/)
- [Merge Presentations](/slides/hu/python-net/merge-presentation/)
- [Slide Master](/slides/hu/python-net/slide-master/)
- [Manage Text Box](/slides/hu/python-net/manage-textbox/)
- [Embedded Font](/slides/hu/python-net/embedded-font/)