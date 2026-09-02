---
title: Prezentáció-információk lekérése és frissítése Pythonban
linktitle: Prezentáció információk
type: docs
weight: 30
url: /hu/python-net/examine-presentation/
keywords:
- prezentáció formátum
- prezentáció tulajdonságok
- dokumentum tulajdonságok
- tulajdonságok lekérése
- tulajdonságok olvasása
- tulajdonságok megváltoztatása
- tulajdonságok módosítása
- tulajdonságok frissítése
- PPTX vizsgálata
- PPT vizsgálata
- ODP vizsgálata
- PowerPoint
- OpenDocument
- prezentáció
- Python
- Aspose.Slides
description: "Fedezze fel a diák, a struktúra és a metaadatok részleteit PowerPoint és OpenDocument prezentációkban Python használatával a gyorsabb betekintés és az okosabb tartalomelemzés érdekében."
---
## **Áttekintés**

Az Aspose.Slides képes azonosítani egy prezentáció formátumát, és beolvasni a dokumentum metaadatait anélkül, hogy teljes prezentáció objektummodellt hozna létre. Ez akkor hasznos, amikor fájlokat kell osztályozni, leltárt készíteni vagy tulajdonságokat ellenőrizni szeretne, mielőtt eldöntené, hogy betölti és feldolgozza a prezentáció tartalmát.

Ez a cikk bemutatja a könnyű ellenőrzést a [PresentationFactory](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentationfactory/) és a [PresentationInfo](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentationinfo/) segítségével, valamint a célzott frissítéseket a [DocumentProperties](https://reference.aspose.com/slides/hu/python-net/aspose.slides/documentproperties/) használatával.

## **Prezentáció formátumának ellenőrzése**

Használja a [PresentationFactory.get_presentation_info](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentationfactory/get_presentation_info/) metódust egy fájl ellenőrzéséhez anélkül, hogy [Presentation](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentation/) példányt hozna létre. A [PresentationInfo.load_format](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentationinfo/load_format/) tulajdonság jelzi a felismert formátumot, például PPTX, PPT vagy ODP.

```python
import aspose.slides as slides

file_names = ["pres.pptx", "pres.ppt", "pres.odp"]

for file_name in file_names:
    presentation_info = slides.PresentationFactory.instance.get_presentation_info(file_name)
    print(f"{file_name}: {presentation_info.load_format}")
```

## **Könnyű prezentáció leltár létrehozása**

Amikor sok prezentációfájlt dolgoz fel, szüksége lehet egy kompakt leltárra az ellenőrzéshez, indexeléshez vagy egy dokumentumkezelő rendszerhez. Ebben a helyzetben használja a [PresentationFactory.get_presentation_info](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentationfactory/get_presentation_info/) metódust, hogy egy [PresentationInfo](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentationinfo/) objektumot kapjon, majd hívja a [PresentationInfo.read_document_properties](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentationinfo/read_document_properties/) metódust a dokumentum metaadatainak beolvasásához. Ez a megközelítés nem hoz létre [Presentation](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentation/) példányt, és nem igényli a teljes prezentáció objektummodell bejárását.

A [DocumentProperties](https://reference.aspose.com/slides/hu/python-net/aspose.slides/documentproperties/) által kiadott kiterjesztett tulajdonságok a következő leltárértékeket biztosítják:

| Tulajdonság | Leltár érték |
| --- | --- |
| [slides](https://reference.aspose.com/slides/hu/python-net/aspose.slides/documentproperties/slides/hu/) | A diák összes száma. |
| [hidden_slides](https://reference.aspose.com/slides/hu/python-net/aspose.slides/documentproperties/hidden_slides/) | Rejtett diák száma. |
| [notes](https://reference.aspose.com/slides/hu/python-net/aspose.slides/documentproperties/notes/) | Azon diák száma, amelyek jegyzetet tartalmaznak. |
| [paragraphs](https://reference.aspose.com/slides/hu/python-net/aspose.slides/documentproperties/paragraphs/) | A bekezdések összes száma, ha elérhető. |
| [words](https://reference.aspose.com/slides/hu/python-net/aspose.slides/documentproperties/words/) | A szavak összes száma. |
| [multimedia_clips](https://reference.aspose.com/slides/hu/python-net/aspose.slides/documentproperties/multimedia_clips/) | Az audio- és videoklipek összes száma. |

Az alábbi példa ezeket az értékeket beolvassa anélkül, hogy [Presentation](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentation/) objektumot hozna létre, és egy kompakt leltárt nyomtat ki. Emellett kombinálja a [heading_pairs](https://reference.aspose.com/slides/hu/python-net/aspose.slides/documentproperties/heading_pairs/) elemet a [titles_of_parts](https://reference.aspose.com/slides/hu/python-net/aspose.slides/documentproperties/titles_of_parts/) elemmel, hogy megjelenítse a tartalmi csoportokat, például betűtípusok, témák és diacímek.

```python
import os
import aspose.slides as slides

file_path = "sample.pptx"
presentation_info = slides.PresentationFactory.instance.get_presentation_info(file_path)
document_properties = presentation_info.read_document_properties()

print(f"File: {os.path.basename(file_path)}")
print(f"Format: {presentation_info.load_format}")
print(f"Title: {document_properties.title}")
print(f"Author: {document_properties.author}")
print("Statistics:")
print(f"  Slides: {document_properties.slides}")
print(f"  Hidden slides: {document_properties.hidden_slides}")
print(f"  Slides with notes: {document_properties.notes}")
print(f"  Paragraphs: {document_properties.paragraphs}")
print(f"  Words: {document_properties.words}")
print(f"  Multimedia clips: {document_properties.multimedia_clips}")

heading_pairs = document_properties.heading_pairs or []
titles_of_parts = document_properties.titles_of_parts or []
part_index = 0

if not heading_pairs or not titles_of_parts:
    print("Content groups: not available")
else:
    print("Content groups:")

    for heading_pair in heading_pairs:
        print(f"  {heading_pair.name} ({heading_pair.count})")

        for _ in range(heading_pair.count):
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

Minden [HeadingPair](https://reference.aspose.com/slides/hu/python-net/aspose.slides/headingpair/) egy csoportnevet és a csoportban lévő elemek számát adja meg. A [DocumentProperties.titles_of_parts](https://reference.aspose.com/slides/hu/python-net/aspose.slides/documentproperties/titles_of_parts/) egy lapos, rendezett gyűjtemény, ezért a fejlécre vonatkozó egymást követő címek számát kell felhasználni.

### **Tárolt metaadatok és formátumkorlátozások**

A [PresentationInfo.read_document_properties](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentationinfo/read_document_properties/) által visszaadott leltártulajdonságok tükrözik a forrásdokumentumban elérhető metaadatokat. Az Aspose.Slides nem tölti be és nem járja be a prezentáció objektummodelljét, hogy újraszámolja ezeket az értékeket ebben a hívásban. Hiányzó tulajdonságok alapértelmezett értékekkel vannak ábrázolva, és a tárolt értékek elavultak lehetnek, ha az alkalmazás, amely utoljára mentette a fájlt, nem frissítette a dokumentumtulajdonságokat.

- **PPTX:** A formátum kiterjesztett dokumentumtulajdonságokat biztosít a diák, jegyzetek, rejtett diák, bekezdések, szavak és multimédia számához, valamint fejlécre párokat és részcímeket. Elérhetőségük attól függ, hogy a dokumentumkészítő mely tulajdonságokat írt be.
- **PPT:** A bináris formátum tárolhatja a megfelelő dokumentumösszegzés-tulajdonságokat. Ha egy tulajdonság hiányzik vagy a dokumentumkészítő nem frissítette, az Aspose.Slides a tárolt vagy alapértelmezett értéket adja vissza ahelyett, hogy a diákból számolná ki.
- **ODP:** Az OpenDocument metaadatok általános dokumentumstatisztikákat biztosítanak, mint például oldal, bekezdés és szó szám, de ezek az értékek nem térképezhetők minden PowerPoint-specifikus kiterjesztett tulajdonságra. A rejtett diák, jegyzet-diák, multimédia, fejlécpár és részcím metaadatok esetleg nem állnak rendelkezésre, és a leltártulajdonságok alapértelmezett értékeket adhatnak vissza. Ne tekintse a null értéket vagy az üres gyűjteményt tekintélyes bizonyítéknak arra, hogy a megfelelő tartalom hiányzik.

Használja a könnyű metaadatmegközelítést leltárakhoz és előzetes ellenőrzésekhez. Töltse be a prezentációt, és ellenőrizze az élő objektummodellt, amikor az eredménynek tükröznie kell a memóriában történt változásokat, vagy amikor a tényleges prezentációtartalmat kell ellenőrizni.

## **Prezentáció tulajdonságok frissítése**

A [PresentationInfo.read_document_properties](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentationinfo/read_document_properties/) által visszaadott tulajdonságok módosíthatók anélkül, hogy [Presentation](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentation/) példányt hoznánk létre. Alkalmazza a módosításokat a [PresentationInfo.update_document_properties](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentationinfo/update_document_properties/) metódussal, majd írja ki a kötött prezentációt a [PresentationInfo.write_binded_presentation](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentationinfo/write_binded_presentation/) metódussal.

Az alábbi kép mutatja az eredeti dokumentumtulajdonságokat a PowerPoint prezentációban:
![Az eredeti dokumentumtulajdonságok a PowerPoint prezentációban](input_properties.png)

Az alábbi példa megváltoztatja a címet és az utolsó mentés időpontját, majd az eredményt egy új fájlba írja:
```python
import datetime
import aspose.slides as slides

source_file = "sample.pptx"
output_file = "sample_with_updated_properties.pptx"
presentation_info = slides.PresentationFactory.instance.get_presentation_info(source_file)
document_properties = presentation_info.read_document_properties()

document_properties.title = "Quarterly sales report"
document_properties.last_saved_time = datetime.datetime.now(datetime.timezone.utc)

presentation_info.update_document_properties(document_properties)

with open(output_file, "wb") as output_stream:
    presentation_info.write_binded_presentation(output_stream)
```

Az alábbi kép mutatja a frissített dokumentumtulajdonságokat:
![A frissített dokumentumtulajdonságok a PowerPoint prezentációban](output_properties.png)

## **Hasznos hivatkozások**

Kapcsolódó biztonsági ellenőrzések és védelmi beállítások tekintetében tekintse meg a következő cikkeket:

- [Jelszóval védett prezentációk](/slides/hu/python-net/password-protected-presentation/)
- [Írásvédett prezentációk](/slides/hu/python-net/write-protected-presentation/)

## **GYIK**

**Hogyan ellenőrizhetem, hogy be vannak-e ágyazva a betűtípusok, és melyek azok?**

Töltse be a prezentációt, és használja a [Presentation.fonts_manager](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentation/fonts_manager/) elemet. Hívja a [FontsManager.get_embedded_fonts](https://reference.aspose.com/slides/hu/python-net/aspose.slides/fontsmanager/get_embedded_fonts/) metódust a beágyazott betűtípusok lekéréséhez, valamint a [FontsManager.get_fonts](https://reference.aspose.com/slides/hu/python-net/aspose.slides/fontsmanager/get_fonts/) metódust a prezentáció által használt betűtípusok lekéréséhez. Hasonlítsa össze a két eredményt, hogy megtalálja azokat a betűtípusokat, amelyek a megjelenítéshez szükségesek, de nincsenek beágyazva.

**Hogyan tudom gyorsan megállapítani, hogy a fájl tartalmaz-e rejtett diákokat, és hány darab van?**

Amikor a tárolt dokumentummetaadatok elegendőek, olvassa a [DocumentProperties.hidden_slides](https://reference.aspose.com/slides/hu/python-net/aspose.slides/documentproperties/hidden_slides/) értéket a [PresentationFactory.get_presentation_info](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentationfactory/get_presentation_info/) és a [PresentationInfo.read_document_properties](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentationinfo/read_document_properties/) segítségével. Ez alkalmas egy könnyű leltárhoz. Ha a prezentációt memóriában módosították, a tárolt metaadatok hiányozhatnak vagy elavultak lehetnek, vagy ha élő értékeket kell ellenőrizni, járja be a [Presentation.slides](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentation/slides/hu/) gyűjteményt, és ellenőrizze minden dia [Slide.hidden](https://reference.aspose.com/slides/hu/python-net/aspose.slides/slide/hidden/) tulajdonságát.

**Képes vagyok-e felismerni, hogy egyéni diák méret és tájolás van-e használatban, és eltérnek-e az alapértelmezettől?**

Igen. Töltse be a prezentációt, és olvassa a [Presentation.slide_size](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentation/slide_size/) értéket. Ellenőrizze a [SlideSize.type](https://reference.aspose.com/slides/hu/python-net/aspose.slides/slidesize/type/), [SlideSize.size](https://reference.aspose.com/slides/hu/python-net/aspose.slides/slidesize/size/) és [SlideSize.orientation](https://reference.aspose.com/slides/hu/python-net/aspose.slides/slidesize/orientation/) tulajdonságokat, hogy összehasonlítsa a jelenlegi beállításokat az elvárt előre beállított értékekkel és méretekkel.

**Van gyors mód a diagramok külső adatforrásra hivatkozásának ellenőrzésére?**

Igen. Keresse meg minden [Chart](https://reference.aspose.com/slides/hu/python-net/aspose.slides.charts/chart/) elemet, és ellenőrizze a [ChartData.data_source_type](https://reference.aspose.com/slides/hu/python-net/aspose.slides.charts/chartdata/data_source_type/) tulajdonságot. Külső munkafüzet esetén olvassa a [ChartData.external_workbook_path](https://reference.aspose.com/slides/hu/python-net/aspose.slides.charts/chartdata/external_workbook_path/) értéket. Az adatforrás típusa és az útvonal azonosítja a külső hivatkozást, de annak elérhetősége külön erőforrás-ellenőrzést igényel.

**Hogyan értékelhetem a 'nehéz' diákat, amelyek lassíthatják a renderelést vagy a PDF exportot?**

Nincs egyetlen komplexitást mérő tulajdonság. Járja be a [Presentation.slides](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentation/slides/hu/) gyűjteményt, és minden dia [BaseSlide.shapes](https://reference.aspose.com/slides/hu/python-net/aspose.slides/baseslide/shapes/) kollekcióját. Használja a formaelemek számát és a nagy képek, hatások, animációk vagy multimédia jelenlétét szűrőjeleként, majd mérjen egy reprezentatív renderelést vagy exportot, mielőtt egy diát végleges teljesítménybottnek tekintene.