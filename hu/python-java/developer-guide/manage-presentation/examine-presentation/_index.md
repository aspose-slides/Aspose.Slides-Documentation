---
title: "Prezentációs információk lekérése és frissítése Pythonon keresztül Java-val"
linktitle: "Prezentációs információk"
type: docs
weight: 30
url: /hu/python-java/examine-presentation/
keywords:
- "prezentáció formátum"
- "prezentáció tulajdonságok"
- "dokumentumtulajdonságok"
- "tulajdonságok lekérése"
- "tulajdonságok olvasása"
- "tulajdonságok változtatása"
- "tulajdonságok módosítása"
- "tulajdonságok frissítése"
- "PPTX vizsgálata"
- "PPT vizsgálata"
- "ODP vizsgálata"
- "PowerPoint"
- "OpenDocument"
- "prezentáció"
- "Python"
- "Java"
- "Aspose.Slides"
description: "Fedezze fel a diák, a struktúra és a metaadatok elemzését PowerPoint és OpenDocument prezentációkban Pythonon keresztül Java-val, hogy gyorsabb betekintést és intelligensebb tartalomelemzést érjen el."
---
## **Áttekintés**

Az Aspose.Slides képes azonosítani egy prezentáció formátumát és kiolvasni a dokumentum metaadatait anélkül, hogy teljes prezentációs objektummodellt hozna létre. Ez akkor hasznos, ha fájlokat kell kategorizálni, leltárt építeni, vagy tulajdonságokat megtekinteni, mielőtt eldöntené, hogy betölti‑e és feldolgozza‑e a prezentáció tartalmát.

A példák az Aspose.Slides for Python via Java és egy kompatibilis Java‑futtatókörnyezet használatát feltételezik. Minden példa elindítja a JVM‑et, ha az még nem fut. Adja meg a példákban használt útvonalakon lévő meglévő prezentációs fájlokat.

Ez a cikk a könnyű ellenőrzést mutatja be a [PresentationFactory](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentationfactory/) és a [PresentationInfo](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentationinfo/) segítségével, valamint a célzott módosításokat a [DocumentProperties](https://reference.aspose.com/slides/hu/python-java/aspose.slides/documentproperties/) használatával.

## **Prezentációformátum ellenőrzése**

Ha már betöltött prezentációja van, lásd a [Determine the Original Presentation Format](/slides/hu/python-java/detect-presentation-source-format/) cikket a betöltés utáni felismeréshez és a régi PPT, PPS és POT adatfolyamok korlátozásaihoz.

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

## **Könnyű prezentációs leltár építése**

Ha sok prezentációs fájlt dolgoz fel, előfordulhat, hogy egy kompakt leltárra van szüksége validáláshoz, indexeléshez vagy dokumentumkezelő rendszerhez. Ebben a helyzetben használja a [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentationfactory/#getPresentationInfo) metódust egy [PresentationInfo](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentationinfo/) objektum létrehozásához, majd hívja a [PresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentationinfo/#readDocumentProperties) metódust a dokumentum metaadatainak beolvasásához. Ez a megközelítés nem hoz létre [Presentation](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentation/) példányt, és nem igényli a teljes objektummodell bejárását.

A [DocumentProperties](https://reference.aspose.com/slides/hu/python-java/aspose.slides/documentproperties/) által biztosított kiterjesztett tulajdonságok a következő leltárértékeket adják:

| Metódus | Leltárérték |
| --- | --- |
| [getSlides](https://reference.aspose.com/slides/hu/python-java/aspose.slides/documentproperties/#getSlides) | Diák összes száma. |
| [getHiddenSlides](https://reference.aspose.com/slides/hu/python-java/aspose.slides/documentproperties/#getHiddenSlides) | Rejtett diák száma. |
| [getNotes](https://reference.aspose.com/slides/hu/python-java/aspose.slides/documentproperties/#getNotes) | Jegyzetet tartalmazó diák száma. |
| [getParagraphs](https://reference.aspose.com/slides/hu/python-java/aspose.slides/documentproperties/#getParagraphs) | Bekapcsolt bekezdések összes száma, ha elérhető. |
| [getWords](https://reference.aspose.com/slides/hu/python-java/aspose.slides/documentproperties/#getWords) | Szavak összes száma. |
| [getMultimediaClips](https://reference.aspose.com/slides/hu/python-java/aspose.slides/documentproperties/#getMultimediaClips) | Hang‑ és videoklipek összes száma. |

Az alábbi példa beolvassa ezeket az értékeket anélkül, hogy [Presentation](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentation/) objektumot hozna létre, és egy kompakt leltárt nyomtat ki. Emellett a [getHeadingPairs](https://reference.aspose.com/slides/hu/python-java/aspose.slides/documentproperties/#getHeadingPairs) metódust kombinálja a [getTitlesOfParts](https://reference.aspose.com/slides/hu/python-java/aspose.slides/documentproperties/#getTitlesOfParts) eredményével a tartalomcsoportok (pl. betűtípusok, témák, diacímek) megjelenítéséhez.

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

Minden [HeadingPair](https://reference.aspose.com/slides/hu/python-java/aspose.slides/headingpair/) egy csoportnevet és a csoport elemeinek számát adja meg. A [DocumentProperties.getTitlesOfParts](https://reference.aspose.com/slides/hu/python-java/aspose.slides/documentproperties/#getTitlesOfParts) lapos, rendezett tömböt ad vissza, ezért a heading‑pair‑ek által meghatározott egymást követő címek számát kell felhasználni.

### **Tárolt metaadatok és formátumkorlátok**

A [PresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentationinfo/#readDocumentProperties) által visszaadott leltártulajdonságok a forrásdokumentumban elérhető metaadatokat tükrözik. Az Aspose.Slides nem tölti be és nem járja be a prezentációs objektummodellt ezen értékek újraszámításához. Hiányzó tulajdonságok alapértelmezett értékkel jelennek meg, a tárolt értékek pedig elavulhatnak, ha az utolsó mentő alkalmazás nem frissítette a dokumentumtulajdonságokat.

- **PPTX:** A formátum kiterjesztett dokumentumtulajdonságokat biztosít a diák, jegyzetek, rejtett diák, bekezdések, szavak és multimédia számához, valamint heading‑pair‑ekhez és részcímekhez. Az elérhetőség attól függ, mely tulajdonságokat írta a dokumentum előállítója.
- **PPT:** A bináris formátum megfelelő dokumentum‑összegző tulajdonságokat tud tárolni. Ha egy tulajdonság hiányzik vagy nem frissült a dokumentum előállítója által, az Aspose.Slides a tárolt vagy alapértelmezett értéket adja vissza a diák alapján történő újraszámolás helyett.
- **ODP:** Az OpenDocument metaadatok általános dokumentumstatisztikákat (oldal, bekezdés, szó szám) szolgáltatnak, de ezek az értékek nem felelnek meg minden PowerPoint‑specifikus kiterjesztett tulajdonságnak. A rejtett diák, jegyzet‑diák, multimédia, heading‑pair és részcím metaadatok hiányozhatnak, és a leltártulajdonságok alapértelmezett értéket adhatnak. Ne tekintse a null értéket vagy az üres tömböt tekintélyes bizonyítéknak arra, hogy a megfelelő tartalom hiányzik.

Használja a könnyű metaadat‑megközelítést leltárokhoz és előzetes ellenőrzésekhez. Töltse be a prezentációt és vizsgálja meg a „live” objektummodellt, ha az eredménynek tükröznie kell a memória‑beli változásokat, vagy ha ellenőrizni kívánja a tényleges prezentációs tartalmat.

## **Prezentációs tulajdonságok frissítése**

A [PresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentationinfo/#readDocumentProperties) által visszaadott tulajdonságok módosíthatók anélkül, hogy [Presentation](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentation/) példányt hoznánk létre. Alkalmazza a módosításokat a [PresentationInfo.updateDocumentProperties](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentationinfo/#updateDocumentProperties) metódussal, majd írja ki a kötött prezentációt a [PresentationInfo.writeBindedPresentation](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentationinfo/#writeBindedPresentation) segítségével.

Az alábbi kép a dokumentum eredeti tulajdonságait mutatja.

![Original document properties of the PowerPoint presentation](input_properties.png)

Az alábbi példa megváltoztatja a címet és a legutóbb mentett időt, majd az eredményt egy új fájlba írja:

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

Az alábbi kép a frissített dokumentumtulajdonságokat ábrázolja.

![Changed document properties of the PowerPoint presentation](output_properties.png)

## **Hasznos hivatkozások**

Kapcsolódó biztonsági ellenőrzések és védelmi beállítások témájában lásd az alábbi cikkeket:

- [Password-Protect Presentations](/slides/hu/python-java/password-protected-presentation/)
- [Write-Protect Presentations](/slides/hu/python-java/write-protected-presentation/)

## **Gyakran ismételt kérdések**

**Hogyan ellenőrizhetem, hogy a betűtípusok beágyazottak‑e, és melyek azok?**

Töltse be a prezentációt, és használja a [Presentation.getFontsManager](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentation/#getFontsManager) metódust. Hívja a [FontsManager.getEmbeddedFonts](https://reference.aspose.com/slides/hu/python-java/aspose.slides/fontsmanager/#getEmbeddedFonts) metódust a beágyazott betűtípusok lekéréséhez, valamint a [FontsManager.getFonts](https://reference.aspose.com/slides/hu/python-java/aspose.slides/fontsmanager/#getFonts) metódust a prezentáció által használt betűtípusokhoz. Hasonlítsa össze a két eredményt, hogy megtalálja a rendereléshez szükséges, de nem beágyazott betűtípusokat.

**Hogyan tudom gyorsan megállapítani, hogy a fájl rejtett diákot tartalmaz‑e, és hány darabot?**

Ha a tárolt dokumentum‑metaadat elegendő, olvassa a [DocumentProperties.getHiddenSlides](https://reference.aspose.com/slides/hu/python-java/aspose.slides/documentproperties/#getHiddenSlides) értéket a [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentationfactory/#getPresentationInfo) és a [PresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentationinfo/#readDocumentProperties) segítségével. Ez alkalmas egy könnyű leltárhoz. Ha a prezentáció memóriában módosult, a tárolt metaadat hiányozhat vagy elavult lehet, vagy élő értékeket kell ellenőriznie; ekkor iteráljon a [Presentation.getSlides](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentation/#getSlides) metóduson, és vizsgálja meg minden dia [Slide.getHidden](https://reference.aspose.com/slides/hu/python-java/aspose.slides/slide/#getHidden) metódusát.

**Felismerhetem‑e, hogy egyedi dia‑méret és tájolás van‑e használatban, és eltér‑e‑nek az alapértelmezettől?**

Igen. Töltse be a prezentációt, és hívja a [Presentation.getSlideSize](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentation/#getSlideSize) metódust. Használja a [SlideSize.getType](https://reference.aspose.com/slides/hu/python-java/aspose.slides/slidesize/#getType), a [SlideSize.getSize](https://reference.aspose.com/slides/hu/python-java/aspose.slides/slidesize/#getSize) és a [SlideSize.getOrientation](https://reference.aspose.com/slides/hu/python-java/aspose.slides/slidesize/#getOrientation) metódusokat az aktuális beállítások összehasonlításához a várt előre beállított értékekkel és méretekkel.

**Van‑e gyors módja annak, hogy lássam, a diagramok külső adatforrásra hivatkoznak‑e?**

Igen. Keresse meg minden [Chart](https://reference.aspose.com/slides/hu/python-java/aspose.slides/chart/) elemet, és hívja a [ChartData.getDataSourceType](https://reference.aspose.com/slides/hu/python-java/aspose.slides/chartdata/#getDataSourceType) metódust. Ha a forrás egy külső munkafüzet, hívja a [ChartData.getExternalWorkbookPath](https://reference.aspose.com/slides/hu/python-java/aspose.slides/chartdata/#getExternalWorkbookPath) metódust. Az adatforrás típusa és az útvonal azonosítja a külső hivatkozást, de a cél elérhetőségének ellenőrzése külön erőforrás‑ellenőrzést igényel.

**Hogyan értékelhetem a „nehéz” diákot, amelyek lassíthatják a renderelést vagy a PDF‑exportot?**

Nincs egyetlen komplexitási tulajdonság sem. Járja be a [Presentation.getSlides](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentation/#getSlides) és minden dia [BaseSlide.getShapes](https://reference.aspose.com/slides/hu/python-java/aspose.slides/baseslide/#getShapes) gyűjteményét. Használjon alakzat‑számot, nagy képeket, effektusokat, animációkat vagy multimédiát szűrőjelzésként, és végezzen egy reprezentatív renderelést vagy exportot, mielőtt egy diát megerősített teljesítmény‑szűkítőnek tekintene.