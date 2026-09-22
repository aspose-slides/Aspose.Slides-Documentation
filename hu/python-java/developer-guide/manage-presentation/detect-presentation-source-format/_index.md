---
title: Az eredeti prezentációformátum meghatározása Pythonban Java segítségével
linktitle: Forrásformátum
type: docs
weight: 35
url: /hu/python-java/detect-presentation-source-format/
keywords:
- forrásformátum
- prezentációformátum felismerése
- PowerPoint
- OpenDocument
- prezentáció
- PPT
- PPTX
- Python
- Java
- Aspose.Slides
description: "Olvassa ki egy betöltött prezentáció eredeti formátumát Pythonban Java segítségével az Aspose.Slides for Python via Java használatával, hasonlítsa össze a felismerési API‑kat, és kezelje a fájlokat, adatfolyamokat és régi formátumokat."
---
## **Áttekintés**

Prezentáció betöltése után hívja meg a [Presentation.getSourceFormat](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentation/#getSourceFormat) metódust, hogy meghatározza az eredeti formátumát. Használja, ha a további feldolgozás a formátumtól függ, amelyből a jelenlegi példány betöltődött.

A forrásformátum különbözik a [SaveFormat](https://reference.aspose.com/slides/hu/python-java/aspose.slides/saveformat/) által kiválasztott kimeneti fájl formátumától. Más formátumba mentés nem változtatja meg a meglévő példány forrásformátumát.

A példákhoz szükséges az Aspose.Slides for Python via Java, valamint egy kompatibilis Java futtatókörnyezet. Minden példa elindítja a JVM-et, ha az még nem fut.

## **A fájl forrásformátumának olvasása**

Ez a példa egy meglévő `sample.pptx` fájlt igényel. Betölti a fájlt, és a [Presentation.getSourceFormat](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentation/#getSourceFormat) segítségével választ egy alkalmazásfeldolgozási szabályt, a fájlnév helyett. Módosítsa a bemeneti útvonalat más formátumok kipróbálásához. A példa kiírja a kiválasztott szabályt; cserélje le az üzeneteket saját alkalmazáslogikájára.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SourceFormat

presentation = Presentation("sample.pptx")
try:
    source_format = presentation.getSourceFormat()
    if source_format in (SourceFormat.Ppt, SourceFormat.Pps, SourceFormat.Pot):
        print("Use the legacy PowerPoint processing policy.")
    elif source_format == SourceFormat.Pptx:
        print("Use the standard PPTX processing policy.")
    else:
        print(f"Use the general policy for source format {source_format}.")
finally:
    presentation.dispose()
```

## **Ismerje fel a támogatott értékeket**

A [SourceFormat](https://reference.aspose.com/slides/hu/python-java/aspose.slides/sourceformat/) osztály egész számú állandókat definiál, amelyek a következő prezentációformátumokat különböztetik meg. Az alábbi kiterjesztések hagyományosak, és nem az eredeti fájlnév rekonstruálása.

| SourceFormat érték | Kiterjesztés | Formátum |
| --- | --- | --- |
| `Ppt` | `.ppt` | PowerPoint 97–2003 prezentáció |
| `Pptx` | `.pptx` | Office Open XML prezentáció |
| `Pptm` | `.pptm` | Makrókkal ellátott Office Open XML prezentáció |
| `Pps` | `.pps` | PowerPoint 97–2003 diaelőadás |
| `Ppsx` | `.ppsx` | Office Open XML diaelőadás |
| `Ppsm` | `.ppsm` | Makrókkal ellátott Office Open XML diaelőadás |
| `Pot` | `.pot` | PowerPoint 97–2003 sablon |
| `Potx` | `.potx` | Office Open XML sablon |
| `Potm` | `.potm` | Makrókkal ellátott Office Open XML sablon |
| `Odp` | `.odp` | OpenDocument prezentáció |
| `Otp` | `.otp` | OpenDocument prezentációs sablon |
| `Fodp` | `.fodp` | Flat XML ODF prezentáció |
| `Xml` | `.xml` | PowerPoint XML prezentáció |

## **A forrásformátum olvasása adatfolyamból**

Ez a példa egy meglévő `sample.pps` fájlt igényel. A fájl bájtjainak memóriastreambe való beolvasása modellezi a fájlnév nélküli bemenetet, például adatbázisértéket vagy feltöltött bájt tömböt. A [Presentation](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentation/) konstruktor csak a streamet kapja. A Python beolvassa a fájl bájtjait, és a JPype átfordítja őket Java bájt tömbbé a Java memóriastreamhez.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from pathlib import Path
from asposeslides.api import Presentation

try:
    data = Path("sample.pps").read_bytes()
    java_bytes = jpype.JArray(jpype.JByte)(data)
    stream = jpype.JClass("java.io.ByteArrayInputStream")(java_bytes)
    try:
        presentation = Presentation(stream)
        try:
            print(f"Source format: {presentation.getSourceFormat()}")
        finally:
            presentation.dispose()
    finally:
        stream.close()
except OSError as exception:
    print(f"Cannot read the presentation: {exception}")
```

A PPT, PPS és POT ugyanazt az alap bináris formátumot használja. Fájl útvonallal történő betöltéskor a kiterjesztés segíthet megkülönböztetni a diaelőadást vagy a sablont. Név nélkül a régi PPS és POT tartalom `SourceFormat.Ppt`‑ként jelentkezhet; a fenti PPS példa az `SourceFormat.Ppt` egész értékét írja ki.

Ha alkalmazásának meg kell őriznie a különbséget, tartsa meg az eredeti fájlnevet vagy a résztype metaadatot külön. A kiterjesztés hasznos jelzés ezekhez a régi altípusokhoz, de nem szabad kizárólag erre támaszkodni a prezentáció tartalmának azonosításához.

## **A felismerés összehasonlítása betöltés előtt és után**

Használja a [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentationfactory/#getPresentationInfo) és a [PresentationInfo.getLoadFormat](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentationinfo/#getLoadFormat) metódusokat, ha a fájlt a teljes prezentációs objektummodell betöltése előtt kell vizsgálni. Használja a [Presentation.getSourceFormat](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentation/#getSourceFormat) metódust, ha a példány már létezik.

Ez a példa `sample.pptx`‑et igényel, és kiírja a `LoadFormat.Pptx` illetve a `SourceFormat.Pptx` egész értékeit. Production környezetben válassza a feldolgozási szakaszának megfelelő API‑t; egy már betöltött prezentáció nem igényel második vizsgálatot a forrásformátum lekérdezéséhez.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, PresentationFactory

path = "sample.pptx"
information = PresentationFactory.getInstance().getPresentationInfo(path)
print(f"Before loading: {information.getLoadFormat()}")

presentation = Presentation(path)
try:
    print(f"After loading: {presentation.getSourceFormat()}")
finally:
    presentation.dispose()
```

Az eredmények különböző osztályokból származó állandókat használnak: [LoadFormat](https://reference.aspose.com/slides/hu/python-java/aspose.slides/loadformat/) és [SourceFormat](https://reference.aspose.com/slides/hu/python-java/aspose.slides/sourceformat/). Ne hasonlítsa össze a numerikus értékeket, és ne feltételezze, hogy minden formátum azonos felismerési eredményt ad. A PowerPoint XML betöltés előtt `LoadFormat.Unknown`‑ként, betöltés után pedig `SourceFormat.Xml`‑ként jelentkezhet.

## **Tartsa külön a forrás- és kimeneti formátumokat**

Ez a példa `sample.pptx`‑et igényel, és `converted.odp`‑t ír ki. Kiírja a `SourceFormat.Pptx` egész értékét a mentés előtt és után is. Csak az ODP kimenetből betöltött új példány jelenti `Odp`‑t.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("sample.pptx")
try:
    print(f"Before saving: {presentation.getSourceFormat()}")

    presentation.save("converted.odp", SaveFormat.Odp)
    print(f"After saving: {presentation.getSourceFormat()}")

    reopened = Presentation("converted.odp")
    try:
        print(f"Reopened output: {reopened.getSourceFormat()}")
    finally:
        reopened.dispose()
finally:
    presentation.dispose()
```

A `Presentation()`‑ból nulláról létrehozott prezentáció `SourceFormat.Pptx`‑t jelöl. Nem rendelkezik bemeneti fájllal: ez az újonnan létrehozott példány alapértelmezett értéke, nem bizonyíték arra, hogy PPTX fájlt töltöttek be. Külön nyomon kell követni, hogy az alkalmazás létrehozta‑e vagy betöltötte‑e a példányt, ha ez a megkülönböztetés fontos.

## **Forrásformátum leképezése kiterjesztésre**

A következő példa `sample.pptx`‑et igényel. Minden jelenleg támogatott [SourceFormat](https://reference.aspose.com/slides/hu/python-java/aspose.slides/sourceformat/) értéket leképez egy szokásos kiterjesztésre, a bemeneti fájlnév elemzése nélkül. A visszaesés megakadályozza, hogy egy nem felismert értékhez néma módon kiterjesztést rendeljünk.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SourceFormat

extensions = {
    SourceFormat.Ppt: ".ppt",
    SourceFormat.Pptx: ".pptx",
    SourceFormat.Pptm: ".pptm",
    SourceFormat.Pps: ".pps",
    SourceFormat.Ppsx: ".ppsx",
    SourceFormat.Ppsm: ".ppsm",
    SourceFormat.Pot: ".pot",
    SourceFormat.Potx: ".potx",
    SourceFormat.Potm: ".potm",
    SourceFormat.Odp: ".odp",
    SourceFormat.Otp: ".otp",
    SourceFormat.Fodp: ".fodp",
    SourceFormat.Xml: ".xml",
}

presentation = Presentation("sample.pptx")
try:
    extension = extensions.get(presentation.getSourceFormat())
    print(extension if extension is not None else "No extension mapping is available.")
finally:
    presentation.dispose()
```

Ez a leképezés nem konvertál fájlt, és nem állítja helyre a stream betöltésekor elveszett régi PPS/POT altípust. Valódi mentéshez adja meg kifejezetten egy [SaveFormat](https://reference.aspose.com/slides/hu/python-java/aspose.slides/saveformat/) értékét, vagy használja a [Save Presentations in Their Original Format](/slides/hu/python-java/save-presentation/#save-presentations-in-their-original-format) példáját.

## **Formátumok ellenőrzése mentéssel és újranyitással**

Ez az önálló példa egy prezentációt hoz létre, és három fájlt ír a munkakönyvtárba, felülírva az azonos nevű fájlokat. Mindegyik kimenetet újra megnyitja útvonallal és memóriastreamen keresztül is. PPTX és ODP esetén mindkét útvonal a mentett formátumot jelenti. PPS esetén az útvonallal betöltött példány `Pps`‑t, a névtelen bájtokkal betöltött példány `Ppt`‑t jelent.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from pathlib import Path
from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    formats = [
        (SaveFormat.Pptx, "pptx"),
        (SaveFormat.Odp, "odp"),
        (SaveFormat.Pps, "pps"),
    ]

    for save_format, extension in formats:
        path = f"roundtrip.{extension}"
        presentation.save(path, save_format)

        from_file = Presentation(path)
        try:
            data = Path(path).read_bytes()
            java_bytes = jpype.JArray(jpype.JByte)(data)
            stream = jpype.JClass("java.io.ByteArrayInputStream")(java_bytes)
            try:
                from_stream = Presentation(stream)
                try:
                    print(f"{extension}: file={from_file.getSourceFormat()}, stream={from_stream.getSourceFormat()}")
                finally:
                    from_stream.dispose()
            finally:
                stream.close()
        finally:
            from_file.dispose()
except OSError as exception:
    print(f"Cannot read a saved presentation: {exception}")
finally:
    presentation.dispose()
```

| Mentett formátum | SourceFormat fájl útvonalból | SourceFormat névtelen adatfolyamból |
| --- | --- | --- |
| PPT | `Ppt` | `Ppt` |
| PPTX, PPTM | `Pptx`, `Pptm` megfelelően | Ugyanaz, mint a fájl útvonal |
| PPS | `Pps` | `Ppt` |
| PPSX, PPSM | `Ppsx`, `Ppsm` megfelelően | Ugyanaz, mint a fájl útvonal |
| POT | `Pot` | `Ppt` |
| POTX, POTM | `Potx`, `Potm` megfelelően | Ugyanaz, mint a fájl útvonal |
| ODP, OTP | `Odp`, `Otp` megfelelően | Ugyanaz, mint a fájl útvonal |
| FODP | `Fodp` | `Fodp` |
| PowerPoint XML | `Xml` | `Xml` |

A PPS/POT tartalom névtelen stream esetén `Ppt`‑ként azonosítható. A táblázat a formátum azonosítását írja le, nem minden prezentációs tulajdonság megőrzését a konverzió során.

## **GYIK**

**A mentés ODP formátumba megváltoztatja a PPTX‑ből betöltött prezentáció forrásformátumát?**

Nem. A meglévő példány továbbra is `Pptx`‑ként jelenti. Az ODP‑ba mentett fájlból betöltött példány `Odp`‑t jelent.

**Egy adatfolyam mindig meg tudja különböztetni a régi prezentációt, diavetítést és sablont?**

Nem. A PPT, PPS és POT ugyanazt a bináris formátumot osztják meg. Ha ez a megkülönböztetés szükséges, tartsa meg a fájlnevet vagy a résztype metaadatot külön.

**Melyik API-t használjam, ha a prezentáció már be van töltve?**

Olvassa el a [Presentation.getSourceFormat](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentation/#getSourceFormat) metódust. Használja a [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentationfactory/#getPresentationInfo) metódust a betöltés előtti vizsgálathoz.