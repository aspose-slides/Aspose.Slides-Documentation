---
title: Az eredeti bemutató formátum meghatározása Pythonban
linktitle: Forrás formátum
type: docs
weight: 35
url: /hu/python-net/detect-presentation-source-format/
keywords:
- forrás formátum
- bemutató formátum felismerése
- PowerPoint
- OpenDocument
- bemutató
- PPT
- PPTX
- Python
- Aspose.Slides
description: "Olvassa be egy betöltött bemutató eredeti formátumát Pythonban az Aspose.Slides for Python via .NET segítségével, hasonlítsa össze a detektálási API‑kat, és kezelje a fájlokat, stream‑eket és a régi formátumokat."
---
## **Áttekintés**

A bemutató betöltése után olvassa el a csak olvasható [Presentation.source_format](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentation/source_format/) tulajdonságot, hogy meghatározza annak eredeti formátumát. Használja, amikor a későbbi feldolgozás attól a formátumtól függ, amelyből a jelenlegi példány betöltődött.

A forrásformátum különbözik a kimeneti fájlhoz kiválasztott [SaveFormat](https://reference.aspose.com/slides/hu/python-net/aspose.slides.export/saveformat/) értéktől. Más formátumba mentés nem változtatja meg a meglévő példány forrásformátumát.

## **A fájl forrásformátumának olvasása**

Ez a példa egy meglévő `sample.pptx` fájlt igényel. Betölti a fájlt, és a [Presentation.source_format](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentation/source_format/) alapján választja ki az alkalmazás feldolgozási szabályát, a fájlnév helyett. Módosítsa a bemeneti útvonalat más formátumok kipróbálásához. A példa kiírja a kiválasztott szabályt; cserélje le az üzeneteket saját alkalmazáslogikájára.

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    source_format = presentation.source_format
    if source_format in (slides.SourceFormat.PPT, slides.SourceFormat.PPS, slides.SourceFormat.POT):
        print("Use the legacy PowerPoint processing policy.")
    elif source_format == slides.SourceFormat.PPTX:
        print("Use the standard PPTX processing policy.")
    else:
        print(f"Use the general policy for {source_format.name}.")
```

## **A támogatott értékek felismerése**

A [SourceFormat](https://reference.aspose.com/slides/hu/python-net/aspose.slides/sourceformat/) felsorolja a következő bemutatóformátumokat. Az alábbi kiterjesztések a szokásos kiterjesztések, nem az eredeti fájlnév rekonstrukciója.

| SourceFormat érték | Kiterjesztés | Formátum |
| --- | --- | --- |
| `PPT` | `.ppt` | PowerPoint 97–2003 bemutató |
| `PPTX` | `.pptx` | Office Open XML bemutató |
| `PPTM` | `.pptm` | Makróval bővített Office Open XML bemutató |
| `PPS` | `.pps` | PowerPoint 97–2003 diavetítés |
| `PPSX` | `.ppsx` | Office Open XML diavetítés |
| `PPSM` | `.ppsm` | Makróval bővített Office Open XML diavetítés |
| `POT` | `.pot` | PowerPoint 97–2003 sablon |
| `POTX` | `.potx` | Office Open XML sablon |
| `POTM` | `.potm` | Makróval bővített Office Open XML sablon |
| `ODP` | `.odp` | OpenDocument bemutató |
| `OTP` | `.otp` | OpenDocument bemutató sablon |
| `FODP` | `.fodp` | Flat XML ODF bemutató |
| `XML` | `.xml` | PowerPoint XML bemutató |

## **A forrásformátum olvasása egy folyam (stream) esetén**

Ez a példa egy meglévő `sample.pps` fájlt igényel. A fájl bájtjainak memóriában lévő stream-be olvasása modellezi a névtelen bemenetet, például adatbázisértéket vagy feltöltött bájt tömböt. A [Presentation](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentation/) konstruktora csak a stream-et kapja.

```python
import io
import aspose.slides as slides

with open("sample.pps", "rb") as input_file:
    data = input_file.read()

with io.BytesIO(data) as stream:
    with slides.Presentation(stream) as presentation:
        print(f"Source format: {presentation.source_format.name}")
```

A PPT, PPS és POT ugyanazt a bináris formátumot használja. Fájlúton történő betöltéskor a kiterjesztés segíthet megkülönböztetni a diavetítést vagy sablont. Név nélkül a régi PPS és POT tartalom `SourceFormat.PPT`‑ként jelenhet meg; a fenti PPS példa `PPT`‑t jelent.

Ha az alkalmazásnak meg kell őriznie a különbséget, tartsa meg az eredeti fájlnevet vagy az altípus metaadatait külön. A kiterjesztés hasznos útmutató ezekhez a régi altípusokhoz, de nem lehet az egyetlen alap a tetszőleges bemutatótartalom azonosításához.

## **Az észlelés összehasonlítása betöltés előtt és után**

Használja a [PresentationFactory.get_presentation_info](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentationfactory/get_presentation_info/) és a [PresentationInfo.load_format](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentationinfo/load_format/) módszereket, ha szüksége van a fájl ellenőrzésére a teljes bemutató objektummodell betöltése előtt. Használja a [Presentation.source_format](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentation/source_format/)‑t, ha a példány már létezik.

Ez a példa `sample.pptx`‑et igényel, és mindkét ellenőrzésnél `PPTX`‑et nyomtat. Éles környezetben válassza meg a feldolgozási szakaszhoz megfelelő API‑t; egy már betöltött bemutató nem igényel második ellenőrzést a forrásformátum megállapításához.

```python
import aspose.slides as slides

path = "sample.pptx"
information = slides.PresentationFactory.instance.get_presentation_info(path)
print(f"Before loading: {information.load_format.name}")

with slides.Presentation(path) as presentation:
    print(f"After loading: {presentation.source_format.name}")
```

A visszatérési értékek különféle enumerációk: [LoadFormat](https://reference.aspose.com/slides/hu/python-net/aspose.slides/loadformat/) és [SourceFormat](https://reference.aspose.com/slides/hu/python-net/aspose.slides/sourceformat/). Ne hasonlítsa össze őket a numerikus értékek átkonvertálásával, és ne tételezze fel, hogy minden formátumnak azonos észlelési eredményei vannak. A lent leírt mentés‑újra megnyitás ellenőrzésben a PowerPoint XML betöltés előtt `LoadFormat.UNKNOWN`‑ként jelent meg, betöltés után pedig `SourceFormat.XML`‑ként.

## **A forrás- és kimeneti formátumok különválasztása**

Ez a példa `sample.pptx`‑et igényel, és `converted.odp`‑t ír. Mind a mentés előtt, mind után `PPTX`‑et nyomtat az eredeti példányra. Csak az ODP kimenetből betöltött új példány jelent `ODP`‑t.

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    print(f"Before saving: {presentation.source_format.name}")

    presentation.save("converted.odp", slides.export.SaveFormat.ODP)
    print(f"After saving: {presentation.source_format.name}")

with slides.Presentation("converted.odp") as reopened:
    print(f"Reopened output: {reopened.source_format.name}")
```

Az `slides.Presentation()`‑vel nulláról létrehozott bemutató `SourceFormat.PPTX`‑t jelent. Nincs bemeneti fájl: ez az alapértelmezett érték egy újonnan létrehozott példánynál, nem azt bizonyítja, hogy PPTX fájl lett betöltve. Kövesse nyomon, hogy az alkalmazás létrehozta‑e vagy betöltötte‑e a példányt, ha ez a különbség fontos.

## **Forrásformátum leképezése kiterjesztésre**

A következő példa `sample.pptx`‑et igényel. Minden jelenleg támogatott [SourceFormat](https://reference.aspose.com/slides/hu/python-net/aspose.slides/sourceformat/) értéket leképez egy szokásos kiterjesztésre, a bemeneti fájlnév elemzése nélkül. A tartalék elkerüli, hogy ismeretlen értékhez csendben kiterjesztést rendeljünk.

```python
import aspose.slides as slides

extensions = {
    slides.SourceFormat.PPT: ".ppt",
    slides.SourceFormat.PPTX: ".pptx",
    slides.SourceFormat.PPTM: ".pptm",
    slides.SourceFormat.PPS: ".pps",
    slides.SourceFormat.PPSX: ".ppsx",
    slides.SourceFormat.PPSM: ".ppsm",
    slides.SourceFormat.POT: ".pot",
    slides.SourceFormat.POTX: ".potx",
    slides.SourceFormat.POTM: ".potm",
    slides.SourceFormat.ODP: ".odp",
    slides.SourceFormat.OTP: ".otp",
    slides.SourceFormat.FODP: ".fodp",
    slides.SourceFormat.XML: ".xml",
}

with slides.Presentation("sample.pptx") as presentation:
    extension = extensions.get(presentation.source_format)
    print(extension if extension is not None else "No extension mapping is available.")
```

Ez a leképezés nem konvertál fájlt, és nem állítja vissza a stream betöltése során elveszett régi PPS/POT altípust. Valódi mentéshez válasszon explicit [SaveFormat](https://reference.aspose.com/slides/hu/python-net/aspose.slides.export/saveformat/)‑t, vagy használja a [Save Presentations in Their Original Format](/slides/hu/python-net/save-presentation/#save-presentations-in-their-original-format) konverziót.

## **Formátumok ellenőrzése mentés és újranyitás által**

Ez az önálló példa létrehoz egy bemutatót, és három fájlt ír a munkakönyvtárba, felülírva az azonos nevű fájlokat. Minden kimenetet újból megnyit mind útvonallal, mind memóriában lévő stream‑mel. PPTX és ODP esetén mindkét útvonal a mentett formátumot jelenti. PPS esetén az útvonal szerint betöltés `PPS`‑t ad, míg a névtelen bájtok betöltése `PPT`‑t ad.

```python
import io
import aspose.slides as slides

formats = [slides.export.SaveFormat.PPTX, slides.export.SaveFormat.ODP, slides.export.SaveFormat.PPS]

with slides.Presentation() as presentation:
    for output_format in formats:
        path = f"roundtrip.{output_format.name.lower()}"
        presentation.save(path, output_format)

        with open(path, "rb") as input_file:
            data = input_file.read()

        with slides.Presentation(path) as from_file:
            with io.BytesIO(data) as stream:
                with slides.Presentation(stream) as from_stream:
                    print(f"{output_format.name}: file={from_file.source_format.name}, stream={from_stream.source_format.name}")
```

A fenti formátumokkal végzett ellenőrzés a megfelelő kiterjesztésű generált bemutatók esetén a következő eredményeket hozta:

| Mentett formátum | SourceFormat fájlúton | SourceFormat névtelen stream‑ből |
| --- | --- | --- |
| PPT | `PPT` | `PPT` |
| PPTX, PPTM | `PPTX`, `PPTM` respectively | Same as file path |
| PPS | `PPS` | `PPT` |
| PPSX, PPSM | `PPSX`, `PPSM` respectively | Same as file path |
| POT | `POT` | `PPT` |
| POTX, POTM | `POTX`, `POTM` respectively | Same as file path |
| ODP, OTP | `ODP`, `OTP` respectively | Same as file path |
| FODP | `FODP` | `FODP` |
| PowerPoint XML | `XML` | `XML` |

Ezeknél az ellenőrzéseknél az egyetlen forrásformátum normalizáció a PPS/POT `PPT`‑re való átalakítása névtelen stream‑eknél. A táblázat a formátum azonosítását írja le, nem a bemutató minden jellemzőjének megőrzését a konverzió során.

## **GYIK**

**Megváltozik-e egy PPTX‑ből betöltött bemutató forrásformátuma, ha ODP‑ként mentjük?**

Nem. A meglévő példány továbbra is `PPTX`‑et jelent. A mentett ODP fájlból betöltött példány `ODP`‑t jelent.

**Meg tud-e egy stream mindig megkülönböztetni egy régi bemutatót, diavetítést és sablont?**

Nem. A PPT, PPS és POT ugyanazt a bináris formátumot osztja meg. Ha a különbség fontos, tartsa meg külön a fájlnevet vagy az altípus metaadatait.

**Melyik API‑t kell használnom, ha a bemutató már be van töltve?**

Olvassa a [Presentation.source_format](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentation/source_format/). Használja a [PresentationFactory.get_presentation_info](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentationfactory/get_presentation_info/)‑t a betöltés előtti ellenőrzéshez.