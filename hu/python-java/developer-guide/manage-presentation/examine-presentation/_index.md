---
title: Prezentáció információinak lekérése és frissítése Pythonon keresztül Java segítségével
linktitle: Prezentáció információk
type: docs
weight: 30
url: /hu/python-java/examine-presentation/
keywords:
- prezentáció formátum
- prezentáció tulajdonságok
- dokumentum tulajdonságok
- tulajdonságok lekérése
- tulajdonságok beolvasása
- tulajdonságok módosítása
- tulajdonságok módosítása
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
description: "Fedezze fel a diák, a struktúra és a metaadatok részleteit PowerPoint és OpenDocument prezentációkban Pythonon keresztül Java használatával a gyorsabb betekintésért és az okosabb tartalomelemzésért."
---
## **Áttekintés**

Az Aspose.Slides képes azonosítani egy prezentáció formátumát és beolvasni a dokumentum metaadatait anélkül, hogy teljes prezentációs objektummodellt hozna létre. Ez akkor hasznos, ha fájlokat kell osztályozni, leltárt kell létrehozni, vagy a tulajdonságokat meg kell vizsgálni, mielőtt döntene a prezentáció tartalmának betöltéséről és feldolgozásáról.

A példákhoz szükség van az Aspose.Slides for Python via Java-re és egy kompatibilis Java futtatókörnyezetre. Minden példa elindítja a JVM-et, ha az még nem fut. Adja meg a meglévő prezentációs fájlokat a példákban használt útvonalakon.

Ez a cikk bemutatja a könnyű ellenőrzést a [PresentationFactory](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentationfactory/) és a [PresentationInfo](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentationinfo/) használatával, valamint a célzott frissítéseket a [DocumentProperties](https://reference.aspose.com/slides/hu/python-java/aspose.slides/documentproperties/) segítségével.

## **Ellenőrizze a prezentáció formátumát**

Használja a [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentationfactory/#getPresentationInfo) metódust, hogy egy fájlt ellenőrizzen anélkül, hogy [Presentation](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentation/) példányt hozna létre. A [PresentationInfo.getLoadFormat](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentationinfo/#getLoadFormat) metódus jelzi a felismert formátumot, például PPTX, PPT vagy ODP.

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

## **Készítsen egy könnyű prezentációs leltárt**

Amikor sok prezentációs fájlt dolgoz fel, egy kompakt leltárra lehet szüksége a validáláshoz, indexeléshez vagy egy dokumentumkezelő rendszerhez. Ebben a forgatókönyvben használja a [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentationfactory/#getPresentationInfo) metódust egy [PresentationInfo](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentationinfo/) objektum beszerezéséhez, majd hívja a [PresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentationinfo/#readDocumentProperties) metódust a dokumentum metaadatainak beolvasásához. Ez a megközelítés nem hoz létre [Presentation](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentation/) példányt, és nem igényli a teljes prezentációs objektummodell bejárását.

A [DocumentProperties](https://reference.aspose.com/slides/hu/python-java/aspose.slides/documentproperties/) által biztosított kiterjesztett tulajdonságok a következő leltári értékeket adják:

| Metódus | Leltári érték |
| --- | --- |
| [getSlides](https://reference.aspose.com/slides/hu/python-java/aspose.slides/documentproperties/#getSlides) | A diák teljes száma. |
| [getHiddenSlides](https://reference.aspose.com/slides/hu/python-java/aspose.slides/documentproperties/#getHiddenSlides) | A rejtett diák száma. |
| [getNotes](https://reference.aspose.com/slides/hu/python-java/aspose.slides/documentproperties/#getNotes) | A jegyzetet tartalmazó diák száma. |
| [getParagraphs](https://reference.aspose.com/slides/hu/python-java/aspose.slides/documentproperties/#getParagraphs) | Az elérhető bekezdések teljes száma. |
| [getWords](https://reference.aspose.com/slides/hu/python-java/aspose.slides/documentproperties/#getWords) | A szavak teljes száma. |
| [getMultimediaClips](https://reference.aspose.com/slides/hu/python-java/aspose.slides/documentproperties/#getMultimediaClips) | Az audio és videó klipek teljes száma. |

Az alábbi példa beolvassa ezeket az értékeket anélkül, hogy [Presentation](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentation/) objektumot hozna létre, és nyomtat egy kompakt leltárt. Emellett kombinálja a [getHeadingPairs](https://reference.aspose.com/slides/hu/python-java/aspose.slides/documentproperties/#getHeadingPairs) metódust a [getTitlesOfParts](https://reference.aspose.com/slides/hu/python-java/aspose.slides/documentproperties/#getTitlesOfParts) metódussal a tartalmi csoportok – például betűkészletek, témák és dia címek – megjelenítéséhez.

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

Minden [HeadingPair](https://reference.aspose.com/slides/hu/python-java/aspose.slides/headingpair/) egy csoport nevet és a csoportban lévő elemek számát adja meg. A [DocumentProperties.getTitlesOfParts](https://reference.aspose.com/slides/hu/python-java/aspose.slides/documentproperties/#getTitlesOfParts) lapos, rendezett tömböt ad vissza, ezért a heading pair‑ek által megadott egymást követő címek számát kell felhasználni.

### **Tárolt metaadatok és formátumkorlátozások**

A [PresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentationinfo/#readDocumentProperties) által visszaadott leltári tulajdonságok a forrásdokumentumban elérhető metaadatokat tükrözik. Az Aspose.Slides nem tölt be és nem jár be a prezentációs objektummodellt ezen értékek újraszámolásához. A hiányzó tulajdonságok alapértelmezett értékekkel vannak reprezentálva, és a tárolt értékek elavultak lehetnek, ha az utolsó mentést végző alkalmazás nem frissítette a dokumentum tulajdonságait.

- **PPTX:** A formátum kiterjesztett dokumentumtulajdonságokat biztosít a diák, jegyzetek, rejtett diák, bekezdések, szavak és multimédiás elemek számlálásához, valamint a heading pair‑ekhez és a részcímekhez. Az elérhetőség attól függ, hogy a dokumentum előállítója mely tulajdonságokat írta.
- **PPT:** A bináris formátum tárolhatja a megfelelő dokumentum‑összegző tulajdonságokat. Ha egy tulajdonság hiányzik vagy nem frissült a dokumentum előállítója által, az Aspose.Slides a tárolt vagy alapértelmezett értékét adja vissza, a diák alapján nem számítja ki.
- **ODP:** Az OpenDocument metaadatok általános dokumentumstatisztikákat biztosítanak, például oldalak, bekezdések és szavak számlálását, de ezek az értékek nem felelnek meg minden PowerPoint‑specifikus kiterjesztett tulajdonságnak. A rejtett diák, jegyzet‑diák, multimédia, heading‑pair és rész‑cím metaadatok hiányozhatnak, és a leltári tulajdonságok alapértelmezett értékeket adhatnak vissza. Ne tekintse a null értéket vagy az üres tömböt tekintélyes bizonyítéknak arra, hogy a megfelelő tartalom hiányzik.

Használja a könnyű metaadat‑megközelítést leltárak és előzetes ellenőrzések esetén. Töltse be a prezentációt és ellenőrizze a élő objektummodellt, ha az eredménynek a memóriában lévő változásoknak kell megfelelnie, vagy ha a tényleges prezentációs tartalmat kell ellenőrizni.

## **A prezentáció tulajdonságainak frissítése**

A [PresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentationinfo/#readDocumentProperties) által visszaadott tulajdonságok változtathatók anélkül, hogy [Presentation](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentation/) példányt hoznának létre. Alkalmazza a módosításokat a [PresentationInfo.updateDocumentProperties](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentationinfo/#updateDocumentProperties) metódussal, majd írja vissza a kötött prezentációt a [PresentationInfo.writeBindedPresentation](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentationinfo/#writeBindedPresentation) metódussal.

Az alábbi kép az eredeti dokumentumtulajdonságokat mutatja a PowerPoint prezentációban.

![Az eredeti dokumentumtulajdonságok a PowerPoint prezentációban](input_properties.png)

Az alábbi példa módosítja a címet és az utolsó mentés időpontját, majd az eredményt egy új fájlba írja:

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

Az alábbi kép a módosított dokumentumtulajdonságokat mutatja a PowerPoint prezentációban.

![A módosított dokumentumtulajdonságok a PowerPoint prezentációban](output_properties.png)

## **Hasznos hivatkozások**

Kapcsolódó biztonsági ellenőrzések és védelmi beállítások kapcsán tekintse meg a következő cikkeket:

- [Password-Protect Presentations](/slides/hu/python-java/password-protected-presentation/)
- [Write-Protect Presentations](/slides/hu/python-java/write-protected-presentation/)

## **GYIK**

**Hogyan ellenőrizhetem, hogy a betűkészletek beágyazottak-e, és melyek azok?**

Töltse be a prezentációt, és használja a [Presentation.getFontsManager](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentation/#getFontsManager) metódust. Hívja a [FontsManager.getEmbeddedFonts](https://reference.aspose.com/slides/hu/python-java/aspose.slides/fontsmanager/#getEmbeddedFonts) metódust a beágyazott betűkészletek lekéréséhez, valamint a [FontsManager.getFonts](https://reference.aspose.com/slides/hu/python-java/aspose.slides/fontsmanager/#getFonts) metódust a prezentáció által használt betűkészletekhez. Hasonlítsa össze a két eredményt, hogy megtalálja a megjelenítéshez szükséges, de nincs beágyazva lévő betűkészleteket.

**Hogyan tudom gyorsan meghatározni, hogy a fájl tartalmaz‑e rejtett diákat, és hány darab van?**

Ha a tárolt dokumentum metaadatai elegendőek, olvassa a [DocumentProperties.getHiddenSlides](https://reference.aspose.com/slides/hu/python-java/aspose.slides/documentproperties/#getHiddenSlides) értékét a [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentationfactory/#getPresentationInfo) és a [PresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentationinfo/#readDocumentProperties) segítségével. Ez egy könnyű leltárhoz alkalmas. Ha a prezentáció memóriában módosult, a tárolt metaadat hiányozhat vagy elavult lehet, vagy ha élő értékeket akar ellenőrizni, járja be a [Presentation.getSlides](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentation/#getSlides) elemet, és minden dia [Slide.getHidden](https://reference.aspose.com/slides/hu/python-java/aspose.slides/slide/#getHidden) metódusát ellenőrizze.

**Felderíthetem‑e, hogy egyedi dia méret és orientáció van‑e használatban, és eltérnek‑e az alapértelmezettektől?**

Igen. Töltse be a prezentációt, és hívja a [Presentation.getSlideSize](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentation/#getSlideSize) metódust. Használja a [SlideSize.getType](https://reference.aspose.com/slides/hu/python-java/aspose.slides/slidesize/#getType), a [SlideSize.getSize](https://reference.aspose.com/slides/hu/python-java/aspose.slides/slidesize/#getSize) és a [SlideSize.getOrientation](https://reference.aspose.com/slides/hu/python-java/aspose.slides/slidesize/#getOrientation) metódusokat a jelenlegi beállítások összehasonlításához a várt előre beállított értékekkel és dimenziókkal.

**Van gyors módja annak, hogy megtekintsem, a diagramok külső adatforrásokra hivatkoznak‑e?**

Igen. Keresse meg minden [Chart](https://reference.aspose.com/slides/hu/python-java/aspose.slides/chart/) elemet, és hívja a [ChartData.getDataSourceType](https://reference.aspose.com/slides/hu/python-java/aspose.slides/chartdata/#getDataSourceType) metódust. Külső munkafüzet esetén hívja a [ChartData.getExternalWorkbookPath](https://reference.aspose.com/slides/hu/python-java/aspose.slides/chartdata/#getExternalWorkbookPath) metódust. Az adatforrás típusa és útvonala külső hivatkozást jelez, de a cél elérhetőségének ellenőrzése külön erőforrás‑ellenőrzést igényel.

**Hogyan értékeljem a „nehéz” diákat, amelyek lassíthatják a renderelést vagy a PDF exportot?**

Nincs egyetlen komplexitási tulajdonság. Járja be a [Presentation.getSlides](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentation/#getSlides) elemet, valamint minden dia [BaseSlide.getShapes](https://reference.aspose.com/slides/hu/python-java/aspose.slides/baseslide/#getShapes) gyűjteményét. Használja a forma‑számok, nagy képek, effektusok, animációk vagy multimédia jelenlétének jeleit szűrőjelként, és mérje egy reprezentatív renderelés vagy export időt, mielőtt a diát végleges teljesítmény‑szűkítőnek tekintené.