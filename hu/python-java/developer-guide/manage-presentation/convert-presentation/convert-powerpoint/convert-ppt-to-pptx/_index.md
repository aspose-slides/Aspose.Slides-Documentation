---
title: PPT konvertálása PPTX-re Pythonban
linktitle: PPT-t PPTX-re
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
description: "Konvertálja a régi PPT fájlokat PPTX-re Pythonban az Aspose.Slides segítségével. Tartalmaz Python példákat egyedi fájl és kötegelt konverzióra, hibakezelésre és pontossági megjegyzésekre."
---
## **Áttekintés**

A PPT a régi bináris PowerPoint formátum, míg a PPTX az újabb Open XML formátum. Az Aspose.Slides for Python via Java képes betölteni egy PPT fájlt és PPTX‑ként menteni anélkül, hogy a Microsoft PowerPoint telepítve lenne. Ez a cikk bemutatja, hogyan lehet egy fájlt vagy egy könyvtár fájljait konvertálni, és elmagyarázza, mit kell ellenőrizni a konverzió után.

Minden példa szükség esetén elindítja a Java virtuális gépet, majd a használat után felszabadítja a prezentációt. Cserélje ki a példában szereplő útvonalakat a saját fájl vagy könyvtár útvonalaira.

## **PPT fájl konvertálása PPTX‑be**

Töltse be a forrásfájlt a [Presentation](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentation/) osztállyal, majd hívja meg a [Presentation.save](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentation/#save) metódust a [SaveFormat.Pptx](https://reference.aspose.com/slides/hu/python-java/aspose.slides/saveformat/#Pptx) argumentummal. A `finally` blokk elpusztítja a prezentációt és felszabadítja annak erőforrásait.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

# Betöltjük a régi PPT prezentációt.
presentation = Presentation("presentation.ppt")
try:
    # Mentse a prezentációt PPTX formátumban.
    presentation.save("presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

A fájlkiterjesztés önmagában nem választja ki a kimeneti formátumot; ezt a [SaveFormat.Pptx](https://reference.aspose.com/slides/hu/python-java/aspose.slides/saveformat/#Pptx) argumentum végzi. Tartsa külön a bemeneti és kimeneti útvonalakat, ha meg szeretné őrizni az eredeti PPT fájlt.

## **Több PPT fájl konvertálása**

A következő példa minden `.ppt` fájlt átkonvertál egy könyvtárban. Minden fájlt önállóan dolgoz fel, így egy sikertelen konverzió sem állítja meg a többi fájl feldolgozását.

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

Éles környezetben naplózza a teljes kivételt, döntse el, hogy felülírható-e egy meglévő kimeneti fájl, és írja a sikertelen fájlneveket egy újrapróbálási vagy felülvizsgálati sorba. Sérült fájlok, a szükséges jelszó nélkül megnyitott jelszóval védett fájlok, elérhetetlen útvonalak és nem támogatott tartalmak is okozhatják a konverzió sikertelenségét. Tekintse meg a [Password-Protected Presentations](/slides/hu/python-java/password-protected-presentation/) cikket a titkosított fájlok betöltéséhez.

## **Pontosság és öröklött funkciók**

A konverzió általában megőrzi a diák, a mester-diák, az elrendezések, a szöveg, az alakzatok, a képek, a táblázatok és a diagramok tartalmát. Azonban a PPT és a PPTX nem ábrázolja minden funkciót pontosan ugyanúgy. Egy örökölt funkció, amelynek nincs PPTX megfelelője, vagy amelyet a könyvtár nem támogat, normalizálható, kihagyható vagy másként jeleníthető meg.

Ellenőrizze a konvertált fájlt, ha animációkat, átmeneteket, beágyazott vagy hivatkozott OLE-objektusokat, ActiveX vezérlőket, beágyazott médiát, ritka betűtípusokat vagy VBA makrókat tartalmaz. Egy egyszerű PPTX fájl nem makrókkal rendelkező formátum, ezért használjon megfelelő, makrókat támogató munkafolyamatot, ha a VBA-nak elérhetőnek kell maradnia. Győződjön meg arról is, hogy a szükséges betűtípusok és külső erőforrások jelen vannak abban a környezetben, ahol a konvertált prezentáció meg lesz nyitva vagy renderelve.

Fontos dokumentumok esetén nyissa meg programozottan a létrehozott PPTX‑et, ellenőrizze a kulcsfontosságú diák számát és tartalmát, majd hasonlítsa össze megjelenését és diavetítés‑viselkedését a célnak megfelelő megjelenítőben. Ne tekintse a sikeres [Presentation.save](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentation/#save) hívást bizonyítéknak arra, hogy minden örökölt funkció pontos PPTX megfelelővel rendelkezik.

## **Mikor használjuk a PPTX‑et**

Használja a PPTX‑et, ha a prezentációt a jelenlegi PowerPoint verziókban szerkesztik, Open XML csomagokkal dolgozó rendszerekkel cserélik, vagy egy olyan formátumban szeretné tárolni, amely könnyebben ellenőrizhető és helyreállítható, mint a régi bináris PPT. Tartsa meg az eredeti PPT‑t archivként vagy visszaállítási másolatként, amíg a konvertált prezentáció át nem esik a pontossági ellenőrzéseken.

Ha PDF‑re, HTML‑re, képekre, XPS‑re vagy egy másik kimeneti típusra van szüksége, használja a [Convert Presentations to Multiple Formats](/slides/hu/python-java/convert-presentation/) részben található formátumspecifikus útmutatót, ahelyett, hogy azt feltételezné, hogy minden cél megőrzi a szerkeszthető PowerPoint funkciókat.

## **Online konvertáló**

Egy alkalmi fájl vagy gyors összehasonlítás esetén használhatja a [online PPT to PPTX converter](https://products.aspose.app/slides/hu/conversion/ppt-to-pptx) szolgáltatást. Ismétlődő konverziókhoz, kötegelt feldolgozáshoz vagy alkalmazásszintű hibakezeléshez használja a Python via Java API‑t.

## **Kapcsolódó cikkek**

- [PPT vs PPTX](/slides/hu/python-java/ppt-vs-pptx/)
- [Prezentációk mentése Pythonban](/slides/hu/python-java/save-presentation/)
- [Támogatott fájlformátumok](/slides/hu/python-java/supported-file-formats/)
- [Prezentációk megnyitása Pythonban](/slides/hu/python-java/open-presentation/)

## **GYIK**

**Konvertálhatok PPT‑t PPTX‑be anélkül, hogy a Microsoft PowerPoint telepítve legyen?**

Igen. Az Aspose.Slides for Python via Java betölti és menti a prezentációs fájlokat anélkül, hogy a Microsoft PowerPoint szükséges lenne.

**A PPT‑ról PPTX‑re történő konverzió pontosan megőrzi az összes tartalmat?**

Megtartja a szokásos prezentációs tartalmakat, de az pontos pontosság nem garantált minden örökölt vagy nem támogatott funkció esetén. Tekintse át a generált fájlt, ha makrókat, OLE‑ vagy ActiveX‑objektusokat, médiát, speciális animációkat vagy ritka betűtípusokat tartalmaz.

**Konvertálhatok jelszóval védett PPT fájlt?**

Igen, ha a betöltéskor megadja a megfelelő jelszót. Hiányzó vagy helytelen jelszó esetén a betöltés meghiúsul.

**Töröljem a PPT fájlt a konverzió után?**

Tartsa meg az eredetit, amíg ellenőrizte a PPTX‑et a számára fontos megjelenítőkben és munkafolyamatokban. Ez visszaállítási másolatot biztosít, ha egy örökölt funkció másként konvertálódik.