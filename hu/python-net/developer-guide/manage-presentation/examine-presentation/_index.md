---
title: Prezentációs információk lekérdezése és frissítése Pythonban
linktitle: Prezentációs információk
type: docs
weight: 30
url: /hu/python-net/examine-presentation/
keywords:
- prezentáció formátum
- prezentáció tulajdonságok
- dokumentum tulajdonságok
- tulajdonságok lekérése
- tulajdonságok olvasása
- tulajdonságok módosítása
- tulajdonságok szerkesztése
- tulajdonságok frissítése
- PPTX vizsgálata
- PPT vizsgálata
- ODP vizsgálata
- PowerPoint
- OpenDocument
- prezentáció
- Python
- Aspose.Slides
description: "Fedezze fel a diák, a struktúra és a metaadatok részleteit PowerPoint és OpenDocument prezentációkban Python segítségével a gyorsabb betekintéshez és az intelligensebb tartalomelemzéshez."
---
## **Áttekintés**

Az Aspose.Slides képes azonosítani egy prezentáció formátumát és elolvasni a dokumentum metaadatait anélkül, hogy teljes prezentációs objektummodellt hozna létre. Ez akkor hasznos, ha fájlokat kell kategorizálni, leltárt készíteni vagy tulajdonságokat ellenőrizni szeretnél, mielőtt eldöntenéd, hogy betöltöd‑e és feldolgozod‑e a prezentáció tartalmát.

Ez a cikk bemutatja a könnyű ellenőrzést a [PresentationFactory](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentationfactory/) és a [PresentationInfo](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentationinfo/) segítségével, valamint a célzott frissítéseket a [DocumentProperties](https://reference.aspose.com/slides/hu/python-net/aspose.slides/documentproperties/) használatával.

## **Prezentáció formátumának ellenőrzése**

Ha már betöltötted a prezentációt, lásd a [Determine the Original Presentation Format](/slides/hu/python-net/detect-presentation-source-format/) cikket a betöltés utáni azonosításhoz és a régi PPT, PPS, valamint POT stream‑ek korlátaihoz.

Használd a [PresentationFactory.get_presentation_info](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentationfactory/get_presentation_info/) metódust egy fájl megvizsgálásához anélkül, hogy [Presentation](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentation/) példányt hoznál létre. A [PresentationInfo.load_format](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentationinfo/load_format/) tulajdonság jelzi a felismert formátumot, például PPTX, PPT vagy ODP.

```python
import aspose.slides as slides

file_names = ["pres.pptx", "pres.ppt", "pres.odp"]

for file_name in file_names:
    presentation_info = slides.PresentationFactory.instance.get_presentation_info(file_name)
    print(f"{file_name}: {presentation_info.load_format}")
```

## **Könnyű prezentáció‑inventár létrehozása**

Ha sok prezentációfájlt dolgozol fel, előfordulhat, hogy egy tömör leltárra van szükséged érvényesítéshez, indexeléshez vagy dokumentumkezelő rendszerhez. Ilyen esetben használd a [PresentationFactory.get_presentation_info](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentationfactory/get_presentation_info/) metódust egy [PresentationInfo](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentationinfo/) objektum megszerzéséhez, majd hívd meg a [PresentationInfo.read_document_properties](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentationinfo/read_document_properties/) metódust a dokumentum metaadatainak beolvasásához. Ez a megközelítés nem hoz létre [Presentation](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentation/) példányt, és nem igényli a teljes prezentációs objektummodell bejárását.

A [DocumentProperties](https://reference.aspose.com/slides/hu/python-net/aspose.slides/documentproperties/) által biztosított kiterjesztett tulajdonságok a következő leltárértékeket adják meg:

| Tulajdonság | Leltár érték |
| --- | --- |
| [slides](https://reference.aspose.com/slides/hu/python-net/aspose.slides/documentproperties/slides/hu/) | Diák összes száma. |
| [hidden_slides](https://reference.aspose.com/slides/hu/python-net/aspose.slides/documentproperties/hidden_slides/) | Rejtett diák száma. |
| [notes](https://reference.aspose.com/slides/hu/python-net/aspose.slides/documentproperties/notes/) | Jegyzetet tartalmazó diák száma. |
| [paragraphs](https://reference.aspose.com/slides/hu/python-net/aspose.slides/documentproperties/paragraphs/) | Bekezdések összes száma, ha elérhető. |
| [words](https://reference.aspose.com/slides/hu/python-net/aspose.slides/documentproperties/words/) | Szavak összes száma. |
| [multimedia_clips](https://reference.aspose.com/slides/hu/python-net/aspose.slides/documentproperties/multimedia_clips/) | Hang‑ és videoklipek összes száma. |

Az alábbi példa beolvassa ezeket az értékeket anélkül, hogy [Presentation](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentation/) objektumot hozna létre, és egy tömör leltárt nyomtat ki. Emellett kombinálja a [heading_pairs](https://reference.aspose.com/slides/hu/python-net/aspose.slides/documentproperties/heading_pairs/) és a [titles_of_parts](https://reference.aspose.com/slides/hu/python-net/aspose.slides/documentproperties/titles_of_parts/) adatokat, hogy tartalmi csoportokat, például betűtípusokat, sablonokat és dia címeket jelenítsen meg.

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

Minden [HeadingPair](https://reference.aspose.com/slides/hu/python-net/aspose.slides/headingpair/) egy csoportnevet és az abban lévő elemek számát adja meg. A [DocumentProperties.titles_of_parts](https://reference.aspose.com/slides/hu/python-net/aspose.slides/documentproperties/titles_of_parts/) egy lapos, rendezett gyűjtemény, ezért a heading‑pair‑ek által meghatározott egymást követő címek számát kell felhasználni.

### **Tárolt metaadatok és formátumkorlátok**

A [PresentationInfo.read_document_properties](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentationinfo/read_document_properties/) által visszaadott leltártulajdonságok a forrásdokumentumban elérhető metaadatokat tükrözik. Az Aspose.Slides nem tölti be és nem járja be a prezentációs objektummodellt a értékek újraszámolásához ebben a hívásban. Hiányzó tulajdonságok alapértelmezett értékekkel jelennek meg, és a tárolt értékek elavultak lehetnek, ha az utolsó mentőalkalmazás nem frissítette a dokumentumtulajdonságokat.

- **PPTX:** A formátum kiterjesztett dokumentumtulajdonságokat biztosít a diák, jegyzetek, rejtett diák, bekezdések, szavak és multimédia számához, valamint heading‑pair‑ekhez és részcímekhez. Az elérhetőség attól függ, hogy a dokumentum előállítója mely tulajdonságokat írta bele.
- **PPT:** A bináris formátum tárolhat hasonló dokumentum-összefoglaló tulajdonságokat. Ha egy tulajdonság hiányzik vagy nem frissült, az Aspose.Slides a tárolt vagy alapértelmezett értéket adja vissza a diák alapján történő kiszámítás helyett.
- **ODP:** Az OpenDocument metaadatok általános dokumentumstatisztikákat tartalmaznak, például oldal, bekezdés és szó számát, de ezek az értékek nem felelnek meg minden PowerPoint‑specifikus kiterjesztett tulajdonságnak. Rejtett dia, jegyzetdia, multimédia, heading‑pair és részcím metaadatok hiányozhatnak, és a leltártulajdonságok alapértelmezett értékkel térhetnek vissza. Ne tekintsd a nulla értéket vagy az üres gyűjteményt végleges bizonyítéknak arra, hogy a megfelelő tartalom hiányzik.

Használd a könnyű metaadat‑megközelítést leltárok és előzetes ellenőrzések esetén. Töltsd be a prezentációt és vizsgáld meg a futó objektummodellt, ha az eredménynek tükröznie kell a memóriában lévő változásokat, vagy ha a tényleges tartalmat kell ellenőrizned.

## **Prezentációtulajdonságok frissítése**

A [PresentationInfo.read_document_properties](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentationinfo/read_document_properties/) által visszaadott tulajdonságok módosíthatók anélkül, hogy [Presentation](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentation/) példányt hoznánk létre. Alkalmazd a változtatásokat a [PresentationInfo.update_document_properties](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentationinfo/update_document_properties/) metódussal, majd írd vissza a kötött prezentációt a [PresentationInfo.write_binded_presentation](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentationinfo/write_binded_presentation/) metódussal.

Az alábbi kép az eredeti dokumentumtulajdonságokat mutatja.

![Original document properties of the PowerPoint presentation](input_properties.png)

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

Az alábbi kép a frissített dokumentumtulajdonságokat mutatja.

![Changed document properties of the PowerPoint presentation](output_properties.png)

## **Hasznos hivatkozások**

Kapcsolódó biztonsági ellenőrzések és védelmi beállítások tekintetében lásd az alábbi cikkeket:

- [Password-Protect Presentations](/slides/hu/python-net/password-protected-presentation/)
- [Write-Protect Presentations](/slides/hu/python-net/write-protected-presentation/)

## **GYIK**

**Hogyan ellenőrizhetem, hogy a betűtípusok beágyazottak‑e és melyek azok?**

Töltsd be a prezentációt, és használd a [Presentation.fonts_manager](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentation/fonts_manager/) szolgáltatást. Hívd meg a [FontsManager.get_embedded_fonts](https://reference.aspose.com/slides/hu/python-net/aspose.slides/fontsmanager/get_embedded_fonts/) metódust a beágyazott betűtípusok listázásához, illetve a [FontsManager.get_fonts](https://reference.aspose.com/slides/hu/python-net/aspose.slides/fontsmanager/get_fonts/) metódust a prezentáció által használt betűtípusokhoz. A két eredmény összehasonlításával megtalálhatók a megjelenítéshez szükséges, de nem beágyazott betűtípusok.

**Hogyan tudom gyorsan megállapítani, hogy a fájl rejtett diaképeket tartalmaz‑e és hány darabot?**

Ha a tárolt dokumentum‑metaadat elegendő, olvasd a [DocumentProperties.hidden_slides](https://reference.aspose.com/slides/hu/python-net/aspose.slides/documentproperties/hidden_slides/) tulajdonságot a [PresentationFactory.get_presentation_info](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentationfactory/get_presentation_info/) és a [PresentationInfo.read_document_properties](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentationinfo/read_document_properties/) segítségével. Ez egy könnyű leltárhoz alkalmas. Ha a prezentáció memóriában módosult, a tárolt metaadat hiányozhat vagy elavult lehet, vagy ha élő értékeket kell ellenőrizned, akkor iterálj a [Presentation.slides](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentation/slides/hu/) elemein, és vizsgáld meg minden dia [Slide.hidden](https://reference.aspose.com/slides/hu/python-net/aspose.slides/slide/hidden/) tulajdonságát.

**Fel tudom-e ismerni, hogy egyedi dia méret és orientáció van‑e használatban, és hogy eltér‑e az alapértelmezettektől?**

Igen. Töltsd be a prezentációt, és olvasd a [Presentation.slide_size](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentation/slide_size/) tulajdonságot. Vizsgáld meg a [SlideSize.type](https://reference.aspose.com/slides/hu/python-net/aspose.slides/slidesize/type/), [SlideSize.size](https://reference.aspose.com/slides/hu/python-net/aspose.slides/slidesize/size/) és [SlideSize.orientation](https://reference.aspose.com/slides/hu/python-net/aspose.slides/slidesize/orientation/) értékeket, hogy összehasonlítsd a jelenlegi beállításokat a várt előre definiáltakkal és méretekkel.

**Van gyors módszer arra, hogy megvizsgáljam, az ábrák külső adatforrásokra hivatkoznak‑e?**

Igen. Keresd meg minden [Chart](https://reference.aspose.com/slides/hu/python-net/aspose.slides.charts/chart/) elemet, és vizsgáld meg a [ChartData.data_source_type](https://reference.aspose.com/slides/hu/python-net/aspose.slides.charts/chartdata/data_source_type/) tulajdonságot. Külső munkafüzet esetén olvasd a [ChartData.external_workbook_path](https://reference.aspose.com/slides/hu/python-net/aspose.slides.charts/chartdata/external_workbook_path/) adatot. A forrás típus és az útvonal egy külső hivatkozást jelöl, de annak elérhetősége külön erőforrás‑ellenőrzést igényel.

**Hogyan értékelhetem a „nehéz” diákat, amelyek lassíthatják a renderelést vagy a PDF‑exportot?**

Nincs egyetlen „komplexitás” tulajdonság. Járd be a [Presentation.slides](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentation/slides/hu/) gyűjteményt, valamint minden dia [BaseSlide.shapes](https://reference.aspose.com/slides/hu/python-net/aspose.slides/baseslide/shapes/) kollekcióját. Használd a alakzatok számát és a nagy méretű képek, effektusok, animációk vagy multimédia jelenlétét jelzésként, majd mérj egy reprezentatív renderelést vagy exportot, mielőtt egy diát megerősített teljesítmény‑szűkítőként jelölnél.