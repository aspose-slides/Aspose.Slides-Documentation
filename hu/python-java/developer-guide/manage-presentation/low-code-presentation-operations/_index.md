---
title: Alacsony kódszintű prezentációs műveletek Pythonban Java használatával
linktitle: Alacsony kódszintű API
type: docs
weight: 50
url: /hu/python-java/low-code-presentation-operations/
keywords:
- alacsony kódszintű prezentációs API
- prezentáció konvertálása
- prezentációk egyesítése
- diák bejárása
- alakzatok bejárása
- szöveg bejárása
- alakzatok gyűjtése
- prezentáció tömörítése
- használaton kívüli master diák eltávolítása
- használaton kívüli elrendezés diák eltávolítása
- beágyazott betűtípusok tömörítése
- PowerPoint
- OpenDocument
- prezentáció
- Python
- Java
- Aspose.Slides
description: "Használja az Aspose.Slides alacsony kódszintű API-t Pythonban Java segítségével a prezentációk konvertálásához és egyesítéséhez, a tartalom bejárásához, az alakzatok gyűjtéséhez, és a prezentáció méretének csökkentéséhez."
---
## **Áttekintés**

Az [Aspose.Slides for Python via Java](https://reference.aspose.com/slides/hu/python-java/aspose.slides/) API statikus segédosztályokat biztosít a gyakori prezentációs műveletekhez. Ezek a segédeszközök a gyakran használt objektummodell-munkafolyamatokat fókuszált metódusokba csomagolják, így kevesebb kóddal konvertálhat vagy egyesíthet fájlokat, feldolgozhatja a prezentáció elemeit, gyűjthet alakzatokat, és eltávolíthatja a nem használt tartalmat.

Az alacsony kódszintű segédeszközök a leghasznosabbak, amikor a művelet egy teljes fájlra vagy prezentációra vonatkozik, és az alapértelmezett munkafolyamat megfelel az igényeinek. Használja a teljes [Aspose.Slides objektummodellt](https://reference.aspose.com/slides/hu/python-java/aspose.slides/) akkor, amikor finomhangolt vezérlésre van szükség egyedi diák, masterek, elrendezések, alakzatok, exportbeállítások vagy a prezentáció elemei közötti kapcsolatok felett.

Az alábbi táblázat összefoglalja a rendelkezésre álló segédeszközöket:

| Segédprogram | Mire használható |
| --- | --- |
| [Convert](https://reference.aspose.com/slides/hu/python-java/aspose.slides/convert/) | Prezentáció konvertálása egy másik formátumba közvetlen fájl-fájl hívással. |
| [Merger](https://reference.aspose.com/slides/hu/python-java/aspose.slides/merger/) | Ugyanazon formátumú teljes prezentációs fájlok egyesítése. |
| [ForEach](https://reference.aspose.com/slides/hu/python-java/aspose.slides/foreach/) | Művelet végrehajtása minden dia, alakzat, bekezdés vagy szövegrészlet esetén. |
| [Collect](https://reference.aspose.com/slides/hu/python-java/aspose.slides/collect/) | Alakzatok lekérése az egész prezentációból ismételt feldolgozás vagy elemzés céljából. |
| [Compress](https://reference.aspose.com/slides/hu/python-java/aspose.slides/compress/) | Használaton kívüli masterek és elrendezések eltávolítása, valamint a beágyazott betűtípus-adatok csökkentése. |

## **Prezentáció konvertálása**

Használja a [Convert.autoByExtension](https://reference.aspose.com/slides/hu/python-java/aspose.slides/convert/#autoByExtension) metódust, ha a kimeneti fájlkiterjesztés elegendő az exportformátum kiválasztásához. A metódus megnyitja a forrásprezentációt, meghatározza a szükséges formátumot a kimeneti útból, és kiírja az eredményt.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Convert

Convert.autoByExtension("input.pptx", "output.pdf")
```

A [Convert](https://reference.aspose.com/slides/hu/python-java/aspose.slides/convert/) osztály dedikált metódusokat is biztosít a PDF, SVG, JPEG, PNG és TIFF kimenethez. Használja a teljes objektummodellt, ha a prezentációt exportálás előtt felül kell vizsgálnia vagy módosítania, vagy ha olyan exportbeállítást kell konfigurálnia, amelyet a kiválasztott segédeszköz nem biztosít. Tekintse meg a [Convert Presentation](/slides/hu/python-java/convert-presentation/) oldalt a formátumspecifikus munkafolyamatokért és beállításokért.

## **Prezentációk egyesítése**

Használja a [Merger.process](https://reference.aspose.com/slides/hu/python-java/aspose.slides/merger/#process) metódust a teljes prezentációs fájlok egy hívással történő egyesítéséhez. A bemeneti prezentációknak azonos fájlformátummal kell rendelkezniük.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Merger

input_files = jpype.JArray(jpype.JString)(["part-1.pptx", "part-2.pptx"])
Merger.process(input_files, "merged.pptx")
```

A segédeszköz megfelelő, ha minden diát egy eredménybe kell fűzni, anélkül, hogy őket egyenként kiválasztaná vagy átképezné. Használja a teljes objektummodellt, ha kiválasztott diákat szeretne egyesíteni, célmastert vagy elrendezést alkalmazni, szekciókat kifejezetten megtartani, vagy különböző diaméreteket egyeztetni. Tekintse meg a [Merge Presentations](/slides/hu/python-java/merge-presentation/) oldalt ezekhez a forgatókönyvekhez.

## **Prezentációelemek bejárása**

Az [ForEach](https://reference.aspose.com/slides/hu/python-java/aspose.slides/foreach/) osztály visszahívást indít minden kért típusú prezentációelem esetén. Elkerüli a beágyazott gyűjtemény ciklusokat, és kényelmes a prezentáció-szintű ellenőrzéshez vagy formázási változtatásokhoz.

Az alábbi példa a [ForEach.slide](https://reference.aspose.com/slides/hu/python-java/aspose.slides/foreach/#slide), [ForEach.shape](https://reference.aspose.com/slides/hu/python-java/aspose.slides/foreach/#shape), [ForEach.paragraph](https://reference.aspose.com/slides/hu/python-java/aspose.slides/foreach/#paragraph) és [ForEach.portion](https://reference.aspose.com/slides/hu/python-java/aspose.slides/foreach/#portion) metódusokat használja a megfelelő elemek vizsgálatához:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ForEach, Presentation

def print_slide(slide, index):
    print(f"Slide {index}: {slide.getShapes().size()} shapes")

def print_shape(shape, slide, index):
    print(f"Shape {index} on {slide.getClass().getSimpleName()}: {shape.getName()}")

def print_paragraph(paragraph, slide, index):
    print(f"Paragraph {index} on {slide.getClass().getSimpleName()}: {paragraph.getText()}")

def print_portion(portion, paragraph, slide, index):
    print(f"Portion {index} on {slide.getClass().getSimpleName()}: {portion.getText()}")

presentation = Presentation("input.pptx")
try:
    ForEach.slide(presentation, print_slide)
    ForEach.shape(presentation, print_shape)
    ForEach.paragraph(presentation, print_paragraph)
    ForEach.portion(presentation, print_portion)
finally:
    presentation.dispose()
```

Alapértelmezés szerint a prezentáció-szintű alakzat- és szövegvégigjárás magában foglalja a normál, master és elrendezés diákot. Az `includeNotes` paraméterrel rendelkező túlterhelések a jegyzetdiákat is feldolgozhatják. Használjon közvetlen gyűjteményciklusokat, ha a végigjárási sorrend, korai kilépés, visszahívás előtti szűrés vagy részletes szülő‑gyermek vezérlés fontos.

## **Alakzatok gyűjtése**

Használja a [Collect.shapes](https://reference.aspose.com/slides/hu/python-java/aspose.slides/collect/#shapes) metódust, ha a prezentáció összes alakzatának gyűjteményére van szükség, ahelyett, hogy minden alakzatra visszahívást kapna. Ez akkor hasznos, amikor ugyanazt a halmazt többször szűrni, számolni vagy feldolgozni szeretné.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Collect, Presentation

presentation = Presentation("input.pptx")
try:
    shapes = Collect.shapes(presentation)

    for shape in shapes:
        print(f"{shape.getName()}: {shape.getClass().getSimpleName()}")
finally:
    presentation.dispose()
```

Használja a [ForEach.shape](https://reference.aspose.com/slides/hu/python-java/aspose.slides/foreach/#shape) metódust, ha minden alakzatot azonnal kezelhet, és nincs szükség a gyűjtött eredmény megtartására.

## **Prezentáció tartalmának tömörítése**

A [Compress](https://reference.aspose.com/slides/hu/python-java/aspose.slides/compress/) osztály képes eltávolítani a nem használt struktúraelemeket és csökkenteni a beágyazott betűtípus-adatokat:

- [removeUnusedLayoutSlides](https://reference.aspose.com/slides/hu/python-java/aspose.slides/compress/#removeUnusedLayoutSlides) eltávolítja azokat az elrendezés-díákat, amelyeket egyetlen normál dia sem hivatkozik.
- [removeUnusedMasterSlides](https://reference.aspose.com/slides/hu/python-java/aspose.slides/compress/#removeUnusedMasterSlides) eltávolítja azokat a master-diákat, amelyek már nincsenek használatban.
- [compressEmbeddedFonts](https://reference.aspose.com/slides/hu/python-java/aspose.slides/compress/#compressEmbeddedFonts) eltávolítja a beágyazott betűtípusokból a nem használt karaktereket.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Compress, Presentation, SaveFormat

presentation = Presentation("input.pptx")
try:
    Compress.removeUnusedLayoutSlides(presentation)
    Compress.removeUnusedMasterSlides(presentation)
    Compress.compressEmbeddedFonts(presentation)

    presentation.save("compressed.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Először távolítsa el a nem használt elrendezéseket, majd a nem használt mastereket, hogy egy elrendezés törlése után is hivatkozás nélküli master is eltávolítható legyen. Mentse az optimalizált prezentációt egy új fájlba, ha később szüksége lehet az eredeti masterekre, elrendezésekre vagy a teljes beágyazott betűtípus-adatra. További részletekért tekintse meg a [Slide Master](/slides/hu/python-java/slide-master/) és a [Embedded Font](/slides/hu/python-java/embedded-font/) oldalakat.

## **FAQ**

**Mikor érdemes az alacsony kódszintű API-t a teljes objektummodell helyett használni?**

Használjon alacsony kódszintű segédeszközöket, ha egy szabványos művelet egy teljes fájlra vagy prezentációra vonatkozik, és nem igényel részletes vezérlést az egyes elemek felett. Használja a teljes objektummodellt, ha konkrét diákat kell kiválasztani, master és elrendezés kapcsolatait kezelni, köztes állapotot vizsgálni vagy olyan viselkedést konfigurálni kell, amelyet a segédeszköz nem biztosít.

**Össze tudja-e a Merger különböző fájlformátumú prezentációkat?**

Nem. A [Merger.process](https://reference.aspose.com/slides/hu/python-java/aspose.slides/merger/#process) ugyanazon formátumú bemeneti prezentációkat igényel. Először konvertálja a bemeneti fájlokat egy közös formátumba, például a [Convert.autoByExtension](https://reference.aspose.com/slides/hu/python-java/aspose.slides/convert/#autoByExtension) segítségével, majd egyesítse a konvertált fájlokat.

**A ForEach feldolgozza a master, elrendezés és jegyzetdiákat?**

A [ForEach.slide](https://reference.aspose.com/slides/hu/python-java/aspose.slides/foreach/#slide) a normál prezentációs diákat járja be. A prezentáció-szintű [ForEach.shape](https://reference.aspose.com/slides/hu/python-java/aspose.slides/foreach/#shape), [ForEach.paragraph](https://reference.aspose.com/slides/hu/python-java/aspose.slides/foreach/#paragraph) és [ForEach.portion](https://reference.aspose.com/slides/hu/python-java/aspose.slides/foreach/#portion) műveletek alapértelmezés szerint a normál, master és elrendezés diákat tartalmazzák. Használja a `includeNotes` paraméterrel ellátott túlterheléseket `True` értékkel a jegyzetdiák bevonásához.

**Mi a különbség a ForEach.shape és a Collect.shapes között?**

Használja a [ForEach.shape](https://reference.aspose.com/slides/hu/python-java/aspose.slides/foreach/#shape) metódust, ha minden alakzatot azonnal egy visszahíváson keresztül szeretne feldolgozni. Használja a [Collect.shapes](https://reference.aspose.com/slides/hu/python-java/aspose.slides/collect/#shapes) metódust, ha egy iterálható eredményre van szüksége, amely megőrizhető, szűrhető, számlálható vagy többször átfutható.

**A Compress mindig kisebbé teszi a prezentáció fájlt?**

Nem feltétlenül. Az eredmény attól függ, hogy a prezentáció tartalmaz‑e nem használt elrendezéseket, nem használt mastereket vagy beágyazott betűtípusokat nem használt karakterekkel. Ha ezek egyike sem áll fenn, akkor a megfelelő [Compress](https://reference.aspose.com/slides/hu/python-java/aspose.slides/compress/) műveletek nem csökkenthetik a fájlméretet.

**A ForEach vagy a Compress által végzett módosítások automatikusan mentődnek?**

Nem. Ezek a segédeszközök a betöltött [Presentation](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentation/) objektumon memóriában működnek. A [ForEach](https://reference.aspose.com/slides/hu/python-java/aspose.slides/foreach/) visszahívásban vagy a [Compress](https://reference.aspose.com/slides/hu/python-java/aspose.slides/compress/) futtatása után hívja meg a [Presentation.save](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentation/#save) metódust az eredmény írásához.

## **Related Articles**

- [Prezentáció konvertálása](/slides/hu/python-java/convert-presentation/)
- [Prezentációk egyesítése](/slides/hu/python-java/merge-presentation/)
- [Dia master](/slides/hu/python-java/slide-master/)
- [Szövegdoboz kezelése](/slides/hu/python-java/manage-textbox/)
- [Beágyazott betűtípus](/slides/hu/python-java/embedded-font/)