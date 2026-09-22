---
title: Prezentációk mentése Pythonban
linktitle: Prezentáció mentése
type: docs
weight: 80
url: /hu/python-net/save-presentation/
keywords:
- PowerPoint mentése
- OpenDocument mentése
- prezentáció mentése
- dia mentése
- PPT mentése
- PPTX mentése
- ODP mentése
- prezentáció fájlba
- prezentáció adatfolyamba
- előre definiált nézeti típus
- szigorú Office Open XML formátum
- Zip64 mód
- bélyegkép frissítése
- mentési folyamat
- Python
- Aspose.Slides
description: "Mentse a PowerPoint és OpenDocument prezentációkat fájlokba vagy adatfolyamokba Pythonban az Aspose.Slides segítségével, és konfigurálja a PPTX kimeneti beállításokat."
---
## **Áttekintés**

Miután létrehoz egy prezentációt vagy [megnyit egy létezőt](/slides/hu/python-net/open-presentation/), használja a [Presentation.save](https://reference.aspose.com/slides/hu/python-net/aspose.slides/ipresentation/save/) metódust az eredmény írásához. Az Aspose.Slides for Python via .NET képes egy prezentációt fájlba vagy adatfolamba menteni PowerPoint, OpenDocument, PDF és egyéb formátumokban. Az alábbi szakaszok bemutatják a szabványos mentési műveleteket és a PPTX kimenethez elérhető beállításokat.

## **Prezentációk mentése fájlba**

Egy prezentáció fájlba mentéséhez adja meg a kimeneti útvonalat és egy [SaveFormat](https://reference.aspose.com/slides/hu/python-net/aspose.slides.export/saveformat/) értéket a [Presentation.save](https://reference.aspose.com/slides/hu/python-net/aspose.slides/ipresentation/save/) metódusnak. A formátumérték határozza meg, milyen típusú fájlt hoz létre az Aspose.Slides.

A következő példa egy prezentációt hoz létre, és PPTX fájlként menti el:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    # Prezentáció tartalmának hozzáadása vagy módosítása itt.

    presentation.save("Output.pptx", slides.export.SaveFormat.PPTX)
```

## **Prezentációk mentése eredeti formátumban**

A fájl- és adatfolyam-észlelési példákhoz, az újonnan létrehozott prezentációk viselkedéséhez, valamint a forrás- és kimeneti formátumok megkülönböztetéséhez lásd a [Determine the Original Presentation Format](/slides/hu/python-net/detect-presentation-source-format/) oldalt.

Kötegelt feldolgozó alkalmazásban a bemeneti formátum előre nem ismerhető. Egy fájl betöltése után olvassa ki az eredeti formátumát a [Presentation.source_format](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentation/source_format/) tulajdonságból. Az így kapott [SourceFormat](https://reference.aspose.com/slides/hu/python-net/aspose.slides/sourceformat/) értéket adja át a [SlideUtil.to_save_format](https://reference.aspose.com/slides/hu/python-net/aspose.slides.util/slideutil/to_save_format/) metódusnak a megfelelő [SaveFormat](https://reference.aspose.com/slides/hu/python-net/aspose.slides.export/saveformat/) érték lekéréséhez, majd használja a [Presentation.save](https://reference.aspose.com/slides/hu/python-net/aspose.slides/ipresentation/save/) metódust a módosított prezentáció írásához.

Az alábbi teljes példa az bemeneti könyvtár minden fájlját feldolgozza, frissíti a címét, és a betöltött formátumban menti el a kimeneti könyvtárba:

```py
from pathlib import Path

import aspose.slides as slides
from aspose.slides.util import SlideUtil

input_directory = Path("Input")
output_directory = Path("Output")

output_directory.mkdir(exist_ok=True)

for input_path in input_directory.iterdir():
    if not input_path.is_file():
        continue

    try:
        with slides.Presentation(str(input_path)) as presentation:
            source_format = presentation.source_format
            save_format = SlideUtil.to_save_format(source_format)

            presentation.document_properties.title = "Processed by the batch application"

            output_path = output_directory / input_path.name
            presentation.save(str(output_path), save_format)
    except Exception as exception:
        print(f"Cannot process '{input_path}': {exception}")
```

[SlideUtil.to_save_format] a PPT, PPTX, ODP, PPTM, PPSX, PPSM, POTX, POTM, PPS, POT, OTP, FODP és PowerPoint XML formátumokat a megfelelő prezentáció mentési formátumokra képezi le. Csak a prezentáció forrásformátumait térképezi; nem arra szolgál, hogy exportformátumokat, például PDF-et, HTML-t, TIFF-et vagy képeket válasszon. Nem támogatott vagy érvénytelen [SourceFormat] érték átadása kivételt eredményez.

A régi PPT, PPS és POT fájlok ugyanazt a bináris konténert használják. Ha egy ilyen prezentációt fájlkiterjesztés nélküli adatfolyamból töltnek be, a PPS vagy POT fájl ezért PPT‑ként azonosítható. Ha meg kell tartani ezeket a régi altípusokat, akkor a eredeti fájlnevet vagy formátum metaadatait külön tárolja, és használja ezeket a kimeneti fájlnév és formátum kiválasztásakor.

## **Prezentációk mentése adatfolyamba**

Egy prezentáció írásához, anélkül, hogy végső fájlútra támaszkodna, adjon meg egy írható [BinaryIO](https://docs.python.org/3/library/typing.html#typing.BinaryIO) adatfolyamot és egy [SaveFormat](https://reference.aspose.com/slides/hu/python-net/aspose.slides.export/saveformat/) értéket a [Presentation.save](https://reference.aspose.com/slides/hu/python-net/aspose.slides/ipresentation/save/) metódusnak. Ez a megközelítés akkor hasznos, ha a kimenetet egy webszolgáltatásból kell visszaadni, adatbázisba kell tárolni vagy memóriában kell feldolgozni.

A következő példa egy új prezentációt fájl adatfolyamba ment:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    with open("Output.pptx", "wb") as output_stream:
        presentation.save(output_stream, slides.export.SaveFormat.PPTX)
```

## **Prezentációk mentése előre definiált nézeti típussal**

Megadhatja, hogy a PowerPoint melyik nézetben nyissa meg a mentett prezentációt. A mentés előtt állítsa a [ViewProperties.last_view](https://reference.aspose.com/slides/hu/python-net/aspose.slides/viewproperties/last_view/) tulajdonságot egy [ViewType](https://reference.aspose.com/slides/hu/python-net/aspose.slides/viewtype/) értékre.

A következő példa a Diákmester nézetet állítja be kezdő nézetként:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    presentation.view_properties.last_view = slides.ViewType.SLIDE_MASTER_VIEW
    presentation.save("SlideMasterView.pptx", slides.export.SaveFormat.PPTX)
```

## **Prezentációk mentése a szigorú Office Open XML formátumban**

Egy PPTX fájl létrehozásához, amely megfelel az Office Open XML szigorú profiljának, hozzon létre egy [PptxOptions](https://reference.aspose.com/slides/hu/python-net/aspose.slides.export/pptxoptions/) példányt, és állítsa a [conformance](https://reference.aspose.com/slides/hu/python-net/aspose.slides.export/pptxoptions/conformance/) tulajdonságát a `Conformance.ISO_29500_2008_STRICT` értékre. Ezután adja át a beállításokat a [Presentation.save](https://reference.aspose.com/slides/hu/python-net/aspose.slides/ipresentation/save/) metódusnak.

```py
import aspose.slides as slides

options = slides.export.PptxOptions()
options.conformance = slides.export.Conformance.ISO_29500_2008_STRICT

with slides.Presentation() as presentation:
    presentation.save("StrictOfficeOpenXml.pptx", slides.export.SaveFormat.PPTX, options)
```

## **Prezentációk mentése Office Open XML formátumban Zip64 módban**

Egy szabványos ZIP archívum korlátozza minden bejegyzés tömörített és tömörítetlen méretét, az archívum teljes méretét és a bejegyzések számát. Mivel egy PPTX fájl ZIP archívum, egy nagyon nagy prezentáció túllépheti ezeket a korlátokat. A ZIP64 kiterjesztések növelik az alkalmazható méret- és bejegyzésszám-korlátokat.

Használja a [PptxOptions.zip_64_mode](https://reference.aspose.com/slides/hu/python-net/aspose.slides.export/pptxoptions/zip_64_mode/) tulajdonságot annak vezérlésére, hogy az Aspose.Slides írja‑e a ZIP64 kiterjesztéseket:
- `IF_NECESSARY` csak akkor használ ZIP64‑et, amikor a prezentáció meghaladja a szabványos ZIP korlátokat. Ez az alapértelmezett mód.
- `NEVER` letiltja a ZIP64 kiterjesztéseket.
- `ALWAYS` mindig írja a ZIP64 kiterjesztéseket.

A következő példa mindig engedélyezi a ZIP64 kiterjesztéseket a kimeneti prezentációhoz:

```py
import aspose.slides as slides

with slides.Presentation("Sample.pptx") as presentation:
    options = slides.export.PptxOptions()
    options.zip_64_mode = slides.export.Zip64Mode.ALWAYS

    presentation.save("OutputZip64.pptx", slides.export.SaveFormat.PPTX, options)
```

{{% alert color="warning" title="Warning" %}}
Ha a `Zip64Mode.NEVER` értéket használják, és a prezentáció nem fér bele a szabványos ZIP korlátokba, a mentési művelet egy [PptxException](https://reference.aspose.com/slides/hu/python-net/aspose.slides/pptxexception/) kivételt dob.
{{% /alert %}}

## **Prezentációk mentése Office Open XML formátumban tömörítési szintekkel**

Az PPTX kimenethez a [PptxOptions.compression_level](https://reference.aspose.com/slides/hu/python-net/aspose.slides.export/pptxoptions/compression_level/) tulajdonság beállításával egyensúlyba hozhatja a mentési sebességet és a fájlméretet. A [CompressionLevel](https://reference.aspose.com/slides/hu/python-net/aspose.slides.export/compressionlevel/) felsorolás a következő értékeket kínálja:
- `NONE` adatot tömörítés nélkül tárol.
- `LEVEL1` a leggyorsabb tömörítést és a legnagyobb tömörített kimenetet biztosítja.
- `LEVEL2`‑től `LEVEL5`‑ig fokozatosan a kisebb kimenetet részesítik előnyben a mentési sebességgel szemben.
- `LEVEL6` egyensúlyt teremt a mentési sebesség és a fájlméret között. Ez az alapértelmezett szint.
- `LEVEL7` és `LEVEL8` tovább a kisebb kimenetet részesítik előnyben a mentési sebességgel szemben.
- `LEVEL9` a legerősebb tömörítést biztosítja, és a legtöbb feldolgozási időt igényli.

A következő példa egy prezentációt tömörítés nélkül ment:

```py
import aspose.slides as slides

with slides.Presentation("Sample.pptx") as presentation:
    options = slides.export.PptxOptions()
    options.compression_level = slides.export.CompressionLevel.NONE

    presentation.save("OutputNoCompression.pptx", slides.export.SaveFormat.PPTX, options)
```

A következő példa a maximális tömörítési szintet használja:

```py
import aspose.slides as slides

with slides.Presentation("Sample.pptx") as presentation:
    options = slides.export.PptxOptions()
    options.compression_level = slides.export.CompressionLevel.LEVEL9

    presentation.save("OutputMaximumCompression.pptx", slides.export.SaveFormat.PPTX, options)
```

## **Prezentációk mentése a bélyegkép frissítése nélkül**

Amikor egy prezentációt PPTX‑ként mentenek, a [PptxOptions.refresh_thumbnail](https://reference.aspose.com/slides/hu/python-net/aspose.slides.export/pptxoptions/refresh_thumbnail/) tulajdonság vezérli a dokumentum bélyegképét:
- `True` a mentési művelet során regenerálja a bélyegképet. Ez az alapértelmezett érték.
- `False` megőrzi a meglévő bélyegképet. Ha a prezentációnak nincs bélyegképe, az Aspose.Slides nem generál újat.

A következő példa egy prezentációt ment frissítés nélkül a bélyegképén:

```py
import aspose.slides as slides

with slides.Presentation("Sample.pptx") as presentation:
    options = slides.export.PptxOptions()
    options.refresh_thumbnail = False

    presentation.save("Output.pptx", slides.export.SaveFormat.PPTX, options)
```

{{% alert color="info" title="Note" %}}
A bélyegkép frissítésének letiltása csökkentheti a PPTX fájl mentéséhez szükséges időt.
{{% /alert %}}

{{% alert color="info" title="Note" %}}
Az Aspose ingyenes [PowerPoint Splitter](https://products.aspose.app/slides/hu/splitter) eszközt biztosít, amely az Aspose.Slides API‑val készült. Kiválasztott diák mentése a prezentációból különálló PPT vagy PPTX fájlokként.
{{% /alert %}}

## **GYIK**

**Támogatja az Aspose.Slides inkrementális vagy „gyors mentés” funkciót?**

Nem. Minden mentési művelet egy teljes kimeneti fájlt ír, a megváltozott részek csak frissítése helyett.

**Több szál is mentheti ugyanazt a Presentation példányt?**

Nem. Egy [Presentation](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentation/) példány [nem szálbiztos](/slides/hu/python-net/multithreading/). Minden példányhoz egyszerre csak egy szál férjen hozzá, és így mentse.

**Mi történik a hiperhivatkozásokkal és a külsőleg hivatkozott fájlokkal, amikor egy prezentációt mentek?**

[Hyperlinks](/slides/hu/python-net/manage-hyperlinks/) megmaradnak a prezentációban. Az Aspose.Slides nem másolja a külsőleg hivatkozott fájlokat, így a mentett prezentációnak továbbra is hozzá kell férnie azok helyéhez.

**Menthetek dokumentum metaadatokat, például szerzőt, címet, céget és a létrehozás dátumát?**

Igen. Állítsa be a megfelelő [document properties](/slides/hu/python-net/presentation-properties/) értékeket a mentés előtt, és az Aspose.Slides beírja őket a kimeneti fájlba.