---
title: PPT konvertálása PPTX-re Pythonban
linktitle: PPT PPTX-re
type: docs
weight: 20
url: /hu/python-java/convert-ppt-to-pptx/
keywords:
- PowerPoint konvertálása
- prezentáció konvertálása
- dia konvertálása
- PPT konvertálása
- PPT PPTX-re
- PPT mentése PPTX-ként
- PPT exportálása PPTX-be
- PowerPoint
- prezentáció
- Python
- Java
- Aspose.Slides
description: "Konvertálja a régi PPT fájlokat PPTX-re Pythonban az Aspose.Slides segítségével. Tartalmaz Python példákat egyetlen fájl és kötegelt konvertáláshoz, hibakezeléshez és pontossági megjegyzésekhez."
---
## **Áttekintés**

A PPT a régi bináris PowerPoint formátum, míg a PPTX az újabb Open XML formátum. Az Aspose.Slides for Python via Java képes betölteni egy PPT fájlt és PPTX‑ként menteni anélkül, hogy a Microsoft PowerPoint jelen lenne. Ez a cikk bemutatja, hogyan konvertáljunk egyetlen fájlt vagy egy könyvtár fájljait, valamint hogy mit ellenőrizzünk a konvertálás után.

Minden példa szükség esetén elindítja a Java virtuális gépet, és a használat után felszabadítja a prezentációt. Cserélje ki a példában szereplő útvonalakat a saját fájl‑ vagy könyvtárútvonalaira.

## **PPT fájl PPTX formátumba konvertálása**

Töltse be a forrásfájlt a [Presentation](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentation/) osztállyal, majd hívja meg a [Presentation.save](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentation/#save) metódust a [SaveFormat.Pptx](https://reference.aspose.com/slides/hu/python-java/aspose.slides/saveformat/#Pptx) argumentummal. A `finally` blokk felszabadítja a prezentációt és annak erőforrásait.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

# Töltsük be a régi PPT prezentációt.
presentation = Presentation("presentation.ppt")
try:
    # Mentse a prezentációt PPTX formátumban.
    presentation.save("presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

A fájlkiterjesztés önmagában nem választja ki a kimeneti formátumot; ezt a [SaveFormat.Pptx](https://reference.aspose.com/slides/hu/python-java/aspose.slides/saveformat/#Pptx) argumentum határozza meg. Tartsa a bemeneti és kimeneti útvonalakat külön, ha meg akarja őrizni az eredeti PPT fájlt.

## **Több PPT fájl konvertálása**

Az alábbi példa minden `.ppt` fájlt konvertál egy könyvtárban. Minden fájlt önállóan dolgoz fel, így egy hibás konverzió sem állítja le a többi feldolgozását.

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

input_directory = Path("input")
output_directory = Path("output")

try:
    output_directory.mkdir(parents=True, exist_ok=True)
    input_files = list(input_directory.iterdir())
except OSError as error:
    print(f"Cannot prepare the conversion directories: {error}")
else:
    for input_file in input_files:
        if not input_file.is_file() or input_file.suffix.lower() != ".ppt":
            continue

        output_file = output_directory / (input_file.stem + ".pptx")
        input_path = str(input_file)
        output_path = str(output_file)
        presentation = None

        try:
            presentation = Presentation(input_path)
            presentation.save(output_path, SaveFormat.Pptx)
            print(f"Converted: {input_path}")
        except Exception as error:
            print(f"Failed: {input_path} ({error})")
        finally:
            if presentation is not None:
                presentation.dispose()
```

Produktív környezetben naplózza a teljes kivételt, döntse el, hogy a meglévő kimeneti fájl felülírható‑e, és írja a sikertelen fájlneveket egy újrapróbálási vagy felülvizsgálati sorba. Sérült fájlok, a szükséges jelszó nélkül megnyitott jelszóval védett fájlok, elérhetetlen útvonalak és nem támogatott tartalom is okozhat konvertálási hibát. Lásd a [Password-Protected Presentations](/slides/hu/python-java/password-protected-presentation/) cikket a titkosított fájlok betöltéséhez.

## **Pontosság és régi funkciók**

A konvertálás általában megőrzi a diák, mester‑dia, elrendezések, szöveg, alakzatok, képek, táblázatok és diagramok tartalmát. Azonban a PPT és PPTX nem minden funkciót ábrázol pontosan ugyanúgy. Egy olyan régi funkció, amelynek nincs PPTX megfelelője, vagy amelyet a könyvtár nem támogat, normalizálásra, kihagyásra vagy eltérő megjelenítésre kerülhet.

Ellenőrizze a konvertált fájlt, ha animációkat, áttűnéseket, beágyazott vagy hivatkozott OLE objektumokat, ActiveX vezérlőket, beágyazott médiát, ritka betűtípusokat vagy VBA makrókat tartalmaz. A sima PPTX fájl nem makró‑engedélyezett formátum, ezért megfelelő makró‑engedélyezett munkafolyamatot használjon, ha a VBA‑nak elérhetőnek kell maradnia. Győződjön meg arról is, hogy a szükséges betűtípusok és külső erőforrások jelen vannak abban a környezetben, ahol a konvertált prezentációt megnyitják vagy renderelik.

Fontos dokumentumok esetén programozottan nyissa meg újra a létrehozott PPTX‑et, ellenőrizze a kulcsfontosságú dia‑számokat és a tartalmat, majd hasonlítsa össze a megjelenését és a diavetítés viselkedését a célzott megjelenítőben. Ne tekintse a sikeres [Presentation.save](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentation/#save) hívást bizonyítékul arra, hogy minden régi funkció pontos PPTX megfelelővel rendelkezik.

## **Mikor használjuk a PPTX-et**

Használja a PPTX-et, ha a prezentációt a jelenlegi PowerPoint‑verziókban szerkesztik, Open XML csomagokkal dolgozó rendszerekkel cserélik, vagy olyan formátumban tárolják, amely könnyebben ellenőrizhető és visszaállítható, mint a régi bináris PPT. Tartsa meg az eredeti PPT‑t archiválási vagy visszagörgetési példányként, amíg a konvertált prezentáció át nem esik a pontossági ellenőrzéseken.

Ha PDF‑et, HTML‑t, képeket, XPS‑t vagy más kimeneti típust igényel, kövesse a [Convert Presentations to Multiple Formats](/slides/hu/python-java/convert-presentation/) útmutatót, ahelyett, hogy azt feltételezné, minden célformátum megőrzi a szerkeszthető PowerPoint funkciókat.

## **Online konvertáló**

Alkalmi fájl vagy gyors összehasonlítás esetén használhatja az [online PPT to PPTX converter](https://products.aspose.app/slides/hu/conversion/ppt-to-pptx) szolgáltatást. Ismétlődő konvertálásokhoz, kötegelt feldolgozáshoz vagy alkalmazásszintű hibakezeléshez használja a Python via Java API‑t.

## **Kapcsolódó cikkek**

- [PPT vs PPTX](/slides/hu/python-java/ppt-vs-pptx/)
- [Prezentációk mentése Pythonban](/slides/hu/python-java/save-presentation/)
- [Támogatott fájlformátumok](/slides/hu/python-java/supported-file-formats/)
- [Prezentációk megnyitása Pythonban](/slides/hu/python-java/open-presentation/)

## **Gyakran Ismételt Kérdések**

**Át tudok konvertálni PPT-t PPTX-re a Microsoft PowerPoint telepítése nélkül?**

Igen. Az Aspose.Slides for Python via Java betölti és elmenti a prezentációs fájlokat anélkül, hogy a Microsoft PowerPointra szükség lenne.

**A PPT‑ról PPTX‑re konvertálás pontosan megőrzi az összes tartalmat?**

A gyakori prezentációs tartalmak megmaradnak, de a teljes pontosság nem garantált minden régi vagy nem támogatott funkció esetén. Tekintse át a generált fájlt, ha makrókat, OLE vagy ActiveX objektumokat, médiát, speciális animációkat vagy ritka betűtípusokat tartalmaz.

**Átkonvertálhatok jelszóval védett PPT fájlt?**

Igen, ha a betöltéskor a helyes jelszót adja meg. A hiányzó vagy hibás jelszó miatt a betöltés meghiúsul.

**Töröljem a PPT fájlt a konvertálás után?**

Tartsa meg az eredetit, amíg a PPTX‑et a számodra fontos megjelenítőkben és munkafolyamatokban ellenőrizte. Ez visszagörgetési másolatot biztosít, ha egy régi funkció másként konvertálódik.