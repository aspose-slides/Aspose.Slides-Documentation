---
title: Prezentációs információk lekérdezése és frissítése Pythonon keresztül Java segítségével
linktitle: Prezentációs információk
type: docs
weight: 30
url: /hu/python-java/examine-presentation/
keywords:
- prezentáció formátum
- prezentáció tulajdonságok
- dokumentumtulajdonságok
- tulajdonságok lekérése
- tulajdonságok olvasása
- tulajdonságok módosítása
- tulajdonságok változtatása
- tulajdonságok frissítése
- PPTX vizsgálata
- PPT vizsgálata
- ODP vizsgálata
- PowerPoint
- OpenDocument
- prezentáció
- Python
- Java
- Aspose.Slides
description: "Fedezze fel a diák, a struktúra és a metaadatok együttesét PowerPoint és OpenDocument prezentációkban Pythonon keresztül Java használatával a gyorsabb betekintés és az intelligensebb tartalom-ellenőrzés érdekében."
---
## **Áttekintés**

Az Aspose.Slides képes felismerni egy bemutató formátumát, és olvasni a dokumentum metaadatait anélkül, hogy teljes bemutató objektummodellt hozna létre. Ez akkor hasznos, ha fájlokat kell besorolni, készletet építeni, vagy tulajdonságokat ellenőrizni kell, mielőtt eldöntené, hogy betölti és feldolgozza a bemutató tartalmát.

A példákhoz Az Aspose.Slides for Python via Java és egy kompatibilis Java futtatókörnyezet szükséges. Minden példa elindítja a JVM-et, ha még nem fut. Adja meg a meglévő bemutató fájlokat a példákban használt útvonalakon.

Ez a cikk bemutatja a könnyű ellenőrzést a [PresentationFactory](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentationfactory/) és a [PresentationInfo](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentationinfo/) segítségével, valamint a célzott frissítéseket a [DocumentProperties](https://reference.aspose.com/slides/hu/python-java/aspose.slides/documentproperties/) használatával.

## **Ellenőrizze a bemutató formátumát**

Használja a [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentationfactory/#getPresentationInfo) metódust egy fájl ellenőrzéséhez anélkül, hogy [Presentation](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentation/) példányt hozna létre. A [PresentationInfo.getLoadFormat](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentationinfo/#getLoadFormat) metódus jelzi a felismert formátumot, például PPTX, PPT vagy ODP.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LoadFormat, PresentationFactory

file_names = ["pres.pptx", "pres.ppt", "pres.odp"]

for file_name in file_names:
    presentation_info = PresentationFactory.getInstance().getPresentationInfo(file_name)
    load_format = presentation_info.getLoadFormat()
    format_name = f"Other ({load_format})"

    if load_format == LoadFormat.Pptx:
        format_name = "PPTX"
    elif load_format == LoadFormat.Ppt:
        format_name = "PPT"
    elif load_format == LoadFormat.Odp:
        format_name = "ODP"

    print(f"{file_name}: {format_name}")
```

## **Könnyű bemutató leltár létrehozása**

Ha sok bemutató fájlt dolgoz fel, szüksége lehet egy kompakt leltárra az ellenőrzéshez, indexeléshez vagy egy dokumentumkezelő rendszerhez. Ebben a scenárióban használja a [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentationfactory/#getPresentationInfo) metódust egy [PresentationInfo](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentationinfo/) objektum megszerzéséhez, majd hívja a [PresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentationinfo/#readDocumentProperties) metódust a dokumentum metaadatainak olvasásához. Ez a megközelítés nem hoz létre [Presentation](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentation/) példányt, és nem igényli a teljes bemutató objektummodell bejárását.

A [DocumentProperties](https://reference.aspose.com/slides/hu/python-java/aspose.slides/documentproperties/) által biztosított kiterjesztett tulajdonságok a következő leltárértékeket adnak meg:

| Módszer | Leltárérték |
| --- | --- |
| [getSlides](https://reference.aspose.com/slides/hu/python-java/aspose.slides/documentproperties/#getSlides) | Az összes diák száma. |
| [getHiddenSlides](https://reference.aspose.com/slides/hu/python-java/aspose.slides/documentproperties/#getHiddenSlides) | A rejtett diák száma. |
| [getNotes](https://reference.aspose.com/slides/hu/python-java/aspose.slides/documentproperties/#getNotes) | Az a diák száma, amelyek tartalmaznak jegyzeteket. |
| [getParagraphs](https://reference.aspose.com/slides/hu/python-java/aspose.slides/documentproperties/#getParagraphs) | Az összes bekezdés száma, ha elérhető. |
| [getWords](https://reference.aspose.com/slides/hu/python-java/aspose.slides/documentproperties/#getWords) | Az összes szó száma. |
| [getMultimediaClips](https://reference.aspose.com/slides/hu/python-java/aspose.slides/documentproperties/#getMultimediaClips) | Az összes audio- és videoklip száma. |

A következő példa ezeknek az értékeknek az olvasását mutatja be anélkül, hogy [Presentation](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentation/) objektumot hozna létre, és egy kompakt leltárt nyomtat. Emellett a [getHeadingPairs](https://reference.aspose.com/slides/hu/python-java/aspose.slides/documentproperties/#getHeadingPairs) metódust kombinálja a [getTitlesOfParts](https://reference.aspose.com/slides/hu/python-java/aspose.slides/documentproperties/#getTitlesOfParts) metódussal, hogy megjelenítse az olyan tartalomcsoportokat, mint betűtípusok, témák és dia címek.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from pathlib import Path
from asposeslides.api import LoadFormat, PresentationFactory

file_path = "sample.pptx"
presentation_info = PresentationFactory.getInstance().getPresentationInfo(file_path)
document_properties = presentation_info.readDocumentProperties()

load_format = presentation_info.getLoadFormat()
format_name = f"Other ({load_format})"

if load_format == LoadFormat.Pptx:
    format_name = "PPTX"
elif load_format == LoadFormat.Ppt:
    format_name = "PPT"
elif load_format == LoadFormat.Odp:
    format_name = "ODP"

print(f"File: {Path(file_path).name}")
print(f"Format: {format_name}")
print(f"Title: {document_properties.getTitle()}")
print(f"Author: {document_properties.getAuthor()}")
print("Statistics:")
print(f"  Slides: {document_properties.getSlides()}")
print(f"  Hidden slides: {document_properties.getHiddenSlides()}")
print(f"  Slides with notes: {document_properties.getNotes()}")
print(f"  Paragraphs: {document_properties.getParagraphs()}")
print(f"  Words: {document_properties.getWords()}")
print(f"  Multimedia clips: {document_properties.getMultimediaClips()}")

heading_pairs = document_properties.getHeadingPairs()
titles_of_parts = document_properties.getTitlesOfParts()
heading_pairs = heading_pairs if heading_pairs is not None else []
titles_of_parts = titles_of_parts if titles_of_parts is not None else []
part_index = 0

if len(heading_pairs) == 0 or len(titles_of_parts) == 0:
    print("Content groups: not available")
else:
    print("Content groups:")

    for heading_pair in heading_pairs:
        print(f"  {heading_pair.getName()} ({heading_pair.getCount()})")

        for part_offset in range(heading_pair.getCount()):
            if part_index >= len(titles_of_parts):
                break
            print(f"    - {titles_of_parts[part_index]}")
            part_index += 1

    if part_index < len(titles_of_parts):
        print("  Other parts:")

        while part_index < len(titles_of_parts):
            print(f"    - {titles_of_parts[part_index]}")
            part_index += 1
```

Minden [HeadingPair](https://reference.aspose.com/slides/hu/python-java/aspose.slides/headingpair/) egy csoportnevet és a csoportban lévő elemek számát adja meg. A [DocumentProperties.getTitlesOfParts](https://reference.aspose.com/slides/hu/python-java/aspose.slides/documentproperties/#getTitlesOfParts) egy lapos, rendezett tömböt ad vissza, ezért a csoportonként megadott egymást követő címek számát kell felhasználni.

### **Tárolt metaadatok és formátumkorlátok**

A [PresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentationinfo/#readDocumentProperties) által visszaadott leltár tulajdonságok tükrözik a forrásdokumentumban elérhető metaadatokat. Az Aspose.Slides nem tölti be és nem járja be a bemutató objektummodellt, hogy ezeket az értékeket újraszámolja a hívás során. Hiányzó tulajdonságok alapértelmezett értékekkel jelennek meg, és a tárolt értékek elavulhatnak, ha az utoljára mentő alkalmazás nem frissítette a dokumentumtulajdonságokat.

- **PPTX:** A formátum kiterjesztett dokumentumtulajdonságokat biztosít a diák, jegyzetek, rejtett dia, bekezdés, szó és multimédia számlálókhoz, valamint heading párokhoz és részcímekhez. Az elérhetőség attól függ, mely tulajdonságokat írta a dokumentum előállító.
- **PPT:** A bináris formátum tárolhat megfelelő dokumentumösszegző tulajdonságokat. Ha egy tulajdonság hiányzik vagy nem frissítette a dokumentum előállító, az Aspose.Slides a tárolt vagy alapértelmezett értéket adja vissza ahelyett, hogy a diákból számolná ki.
- **ODP:** Az OpenDocument metaadatok általános dokumentumstatisztikákat biztosítanak, például oldal-, bekezdés- és szószámot, de ezek az értékek nem térnek le minden PowerPoint-specifikus kiterjesztett tulajdonságra. A rejtett dia, jegyzet dia, multimédia, heading-pair és részcím metaadatok előfordulhatnak, vagy hiányozhatnak, és a leltár tulajdonságok alapértelmezett értékkel térhetnek vissza. Ne tekintse a nulla értéket vagy a üres tömböt tekintélyes bizonyítéknak arra, hogy a megfelelő tartalom hiányzik.

Használja a könnyű metaadat‑megközelítést leltárakhoz és előzetes ellenőrzésekhez. Töltse be a bemutatót és ellenőrizze annak élő objektummodelljét, ha az eredménynek tükröznie kell a memóriában történt változásokat, vagy ha a tényleges bemutató tartalmát kell ellenőriznie.

## **Bemutató Tulajdonságok Frissítése**

A [PresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentationinfo/#readDocumentProperties) által visszaadott tulajdonságok szintén módosíthatók anélkül, hogy [Presentation](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentation/) példányt hoznánk létre. Alkalmazza a módosításokat a [PresentationInfo.updateDocumentProperties](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentationinfo/#updateDocumentProperties) segítségével, majd írja ki a kötött bemutatót a [PresentationInfo.writeBindedPresentation](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentationinfo/#writeBindedPresentation) segítségével.

Az alábbi kép az eredeti dokumentumtulajdonságokat mutatja.

![A PowerPoint bemutató eredeti dokumentumtulajdonságai](input_properties.png)

A következő példa megváltoztatja a címet és az utolsó mentés időpontját, és az eredményt egy új fájlba írja:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PresentationFactory
from java.io import FileOutputStream
from java.util import Date

source_file = "sample.pptx"
output_file = "sample_with_updated_properties.pptx"
presentation_info = PresentationFactory.getInstance().getPresentationInfo(source_file)
document_properties = presentation_info.readDocumentProperties()

document_properties.setTitle("Quarterly sales report")
last_saved_time = Date()
document_properties.setLastSavedTime(last_saved_time)

presentation_info.updateDocumentProperties(document_properties)
output_stream = FileOutputStream(output_file)
try:
    presentation_info.writeBindedPresentation(output_stream)
finally:
    output_stream.close()
```

Az alábbi kép a frissített dokumentumtulajdonságokat mutatja.

![A PowerPoint bemutató módosított dokumentumtulajdonságai](output_properties.png)

## **Hasznos hivatkozások**

A kapcsolódó biztonsági ellenőrzések és védelmi beállítások tekintetében lásd az alábbi cikkeket:

- [Jelszóval védett bemutatók](/slides/hu/python-java/password-protected-presentation/)
- [Írásvédelemmel ellátott bemutatók](/slides/hu/python-java/write-protected-presentation/)

## **GYIK**

**Hogyan ellenőrizhetem, hogy a betűtípusok be vannak-e ágyazva, és melyek azok?**

Töltse be a bemutatót, és használja a [Presentation.getFontsManager](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentation/#getFontsManager) metódust. Hívja a [FontsManager.getEmbeddedFonts](https://reference.aspose.com/slides/hu/python-java/aspose.slides/fontsmanager/#getEmbeddedFonts) metódust a beágyazott betűtípusok megszerzéséhez, valamint a [FontsManager.getFonts](https://reference.aspose.com/slides/hu/python-java/aspose.slides/fontsmanager/#getFonts) metódust a bemutató által használt betűtípusokhoz. Hasonlítsa össze a két eredményt, hogy megtalálja azokat a betűtípusokat, melyek a megjelenítéshez szükségesek, de nincsenek beágyazva.

**Hogyan tudom gyorsan megállapítani, hogy a fájl tartalmaz-e rejtett diákat, és hány darab van belőlük?**

Amikor a tárolt dokumentummetaadatok elegendőek, olvassa a [DocumentProperties.getHiddenSlides](https://reference.aspose.com/slides/hu/python-java/aspose.slides/documentproperties/#getHiddenSlides) értékét a [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentationfactory/#getPresentationInfo) és a [PresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentationinfo/#readDocumentProperties) segítségével. Ez alkalmas könnyű leltárhoz. Ha a bemutató memóriában módosult, a tárolt metaadatok hiányozhatnak vagy elavulhatnak, vagy élő értékek ellenőrzésére van szükség, akkor járja be a [Presentation.getSlides](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentation/#getSlides) gyűjteményt, és ellenőrizze minden dia [Slide.getHidden](https://reference.aspose.com/slides/hu/python-java/aspose.slides/slide/#getHidden) metódusát.

**Képes vagyok-e észlelni, hogy egyéni dia méret és orientáció van-e használatban, és eltérnek-e az alapértelmezettől?**

Igen. Töltse be a bemutatót, és hívja a [Presentation.getSlideSize](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentation/#getSlideSize) metódust. Használja a [SlideSize.getType](https://reference.aspose.com/slides/hu/python-java/aspose.slides/slidesize/#getType), [SlideSize.getSize](https://reference.aspose.com/slides/hu/python-java/aspose.slides/slidesize/#getSize) és [SlideSize.getOrientation](https://reference.aspose.com/slides/hu/python-java/aspose.slides/slidesize/#getOrientation) metódusokat az aktuális beállítások összehasonlításához a várt előre definiált értékekkel és méretekkel.

**Van-e gyors módja annak, hogy lássam, a diagramok külső adatforrásokra hivatkoznak-e?**

Igen. Keresse meg minden [Chart](https://reference.aspose.com/slides/hu/python-java/aspose.slides/chart/) elemet, és hívja a [ChartData.getDataSourceType](https://reference.aspose.com/slides/hu/python-java/aspose.slides/chartdata/#getDataSourceType) metódust. Külső munkafüzet esetén hívja a [ChartData.getExternalWorkbookPath](https://reference.aspose.com/slides/hu/python-java/aspose.slides/chartdata/#getExternalWorkbookPath) metódust. Az adatforrás típusa és az útvonal mutat egy külső hivatkozást, de annak elérhetősége külön erőforrás‑ellenőrzést igényel.

**Hogyan értékelhetem a 'nehéz' diákokat, amelyek lassíthatják a renderelést vagy a PDF exportot?**

Nincs egyetlen komplexitási tulajdonság sem. Járja be a [Presentation.getSlides](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentation/#getSlides) és minden dia [BaseSlide.getShapes](https://reference.aspose.com/slides/hu/python-java/aspose.slides/baseslide/#getShapes) gyűjteményét. Használjon alakzat‑számokat, nagy képek, effektusok, animációk vagy multimédia jelenlétét szűrőjelzőként, és mérjen reprezentatív renderelést vagy exportot, mielőtt egy diát megerősített teljesítmény‑szűkítőnek tekintene.