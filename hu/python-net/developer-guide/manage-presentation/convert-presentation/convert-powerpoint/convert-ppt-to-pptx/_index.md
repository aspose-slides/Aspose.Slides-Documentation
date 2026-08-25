---
title: PPT konvertálása PPTX-re Pythonban
linktitle: PPT PPTX-re
type: docs
weight: 20
url: /hu/python-net/convert-ppt-to-pptx/
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
- Aspose.Slides
description: "Legacy PPT fájlok konvertálása PPTX-re Pythonban az Aspose.Slides segítségével. Tartalmaz példákat egyedi fájl és kötegelt konvertálásra, hiba kezelésre és pontossági megjegyzésekre."
---
## **Áttekintés**

A PPT a régi bináris PowerPoint formátum, míg a PPTX az újabb Open XML formátum. Az Aspose.Slides for Python via .NET képes betölteni egy PPT fájlt és PPTX-ként elmenteni anélkül, hogy a Microsoft PowerPointra szükség lenne. Ez a cikk bemutatja, hogyan lehet egy fájlt vagy egy könyvtár fájljait konvertálni, és elmagyarázza, mit kell ellenőrizni a konvertálás után.

## **PPT fájl konvertálása PPTX-re**

Töltsd be a forrásfájlt a [Presentation](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentation/) osztállyal, majd hívd a [Presentation.save](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentation/save/) metódust a [SaveFormat.PPTX](https://reference.aspose.com/slides/hu/python-net/aspose.slides.export/saveformat/) argumentummal. A `with` utasítás elpusztítja a prezentációt és felszabadítja az erőforrásait, amikor a blokk véget ér.

```python
import aspose.slides as slides

# Betölti az örökölt PPT prezentációt.
with slides.Presentation("presentation.ppt") as presentation:
    # Mentse a prezentációt PPTX formátumban.
    presentation.save("presentation.pptx", slides.export.SaveFormat.PPTX)
```

A fájlkiterjesztés önmagában nem határozza meg a kimeneti formátumot; ezt a [SaveFormat.PPTX](https://reference.aspose.com/slides/hu/python-net/aspose.slides.export/saveformat/) argumentum határozza meg. Tartsd külön a bemeneti és kimeneti útvonalakat, ha meg kell őrizned az eredeti PPT fájlt.

## **Több PPT fájl konvertálása**

A következő példa minden egyes `.ppt` fájlt konvertál egy könyvtárban. Minden fájl önállóan kerül feldolgozásra, így egy hibás konvertálás sem állítja le a többi feldolgozását.

```python
from pathlib import Path

import aspose.slides as slides

input_directory = Path("input")
output_directory = Path("output")
output_directory.mkdir(parents=True, exist_ok=True)

for input_path in input_directory.glob("*.ppt"):
    output_path = output_directory / f"{input_path.stem}.pptx"

    try:
        with slides.Presentation(str(input_path)) as presentation:
            presentation.save(str(output_path), slides.export.SaveFormat.PPTX)
        print(f"Converted: {input_path}")
    except Exception as exception:
        print(f"Failed: {input_path} ({exception})")
```

Éles környezetben naplózd a teljes kivételt, döntsd el, hogy egy meglévő kimeneti fájl felülírható-e, és írd a sikertelen fájlneveket egy újrapróbálási vagy felülvizsgálati sorba. Sérült fájlok, jelszóval védett fájlok, amelyeket a szükséges jelszó nélkül nyitnak meg, elérhetetlen útvonalak és nem támogatott tartalmak is okozhatják a konvertálás hibáját. Tekintsd meg a [Password-Protected Presentations](/slides/hu/python-net/password-protected-presentation/) dokumentumot titkosított fájlok betöltéséről.

## **Pontosság és régi funkciók**

A konvertálás általában megőrzi a diák, fő sablonok, elrendezések, szöveg, alakzatok, képek, táblázatok és diagramok tartalmát. Azonban a PPT és a PPTX nem minden funkciót jelenít meg pontosan ugyanúgy. Egy örökölt funkció, amelynek nincs PPTX megfelelője, vagy amelyet a könyvtár nem támogat, normalizálható, elhagyható vagy másként jeleníthető meg.

Ellenőrizd a konvertált fájlt, ha animációkat, áttűnéseket, beágyazott vagy hivatkozott OLE objektumokat, ActiveX vezérlőket, beágyazott médiát, ritka betűtípusokat vagy VBA makrókat tartalmaz. Egy egyszerű PPTX fájl nem makrókkal kompatibilis formátum, ezért használj megfelelő makrókkal működő munkafolyamatot, ha a VBA-nak elérhetőnek kell maradnia. Emellett ellenőrizd, hogy a szükséges betűtípusok és külső erőforrások megtalálhatók-e abban a környezetben, ahol a konvertált prezentációt megnyitják vagy megjelenítik.

Fontos dokumentumok esetén nyisd meg programozottan a generált PPTX-et, és ellenőrizd a kulcsfontosságú diák számát és tartalmát, majd hasonlítsd össze a megjelenését és diavetítés viselkedését a kívánt megjelenítőben. Ne tekintsd a sikeres [Presentation.save](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentation/save/) hívást bizonyítéknak arra, hogy minden örökölt funkció pontos PPTX megfelelővel rendelkezik.

## **Mikor használjuk a PPTX-et**

Használd a PPTX-et, ha a prezentációt a jelenlegi PowerPoint verziókban szerkesztik, Open XML csomagokkal dolgozó rendszerek között cserélik, vagy egy olyan formátumban tárolják, amely könnyebben ellenőrizhető és helyreállítható, mint a régi bináris PPT. Tartsd meg az eredeti PPT-et archiválási vagy visszaállítási példányként, amíg a konvertált prezentáció át nem esik a pontossági ellenőrzéseken.

Ha PDF-, HTML-, kép-, XPS- vagy más kimeneti típust szeretnél, használj formátumspecifikus útmutatót a [Convert Presentations to Multiple Formats](/slides/hu/python-net/convert-presentation/) oldalon, ahelyett, hogy azt feltételeznéd, hogy minden cél formátum megőrzi a szerkeszthető PowerPoint funkciókat.

## **Online konverter**

Ritka fájlok vagy gyors összehasonlítás esetén használhatod az [online PPT to PPTX converter](https://products.aspose.app/slides/hu/conversion/ppt-to-pptx) eszközt. Ismételhető konvertálásokhoz, kötegelt feldolgozáshoz vagy alkalmazásszintű hiba kezeléshez használd a Python API-t.

## **Kapcsolódó cikkek**

- [PPT vs PPTX](/slides/hu/python-net/ppt-vs-pptx/)
- [Prezentációk mentése Pythonban](/slides/hu/python-net/save-presentation/)
- [Támogatott fájlformátumok](/slides/hu/python-net/supported-file-formats/)
- [Prezentációk megnyitása Pythonban](/slides/hu/python-net/open-presentation/)

## **GYIK**

**Konvertálhatok PPT-t PPTX-re Microsoft PowerPoint telepítése nélkül?**

Igen. Az Aspose.Slides for Python via .NET betölti és elmenti a prezentációs fájlokat anélkül, hogy a Microsoft PowerPointra szükség lenne.

**A PPT‑ról PPTX‑re konvertálás minden tartalmat pontosan megőriz?**

Megőrzi a szokásos prezentációs tartalmakat, de a pontos pontosság nem garantált minden örökölt vagy nem támogatott funkcióra. Vizsgáld meg a generált fájlt, ha makrókat, OLE vagy ActiveX objektumokat, médiát, speciális animációkat vagy ritka betűtípusokat tartalmaz.

**Konvertálhatok jelszóval védett PPT fájlt?**

Igen, ha a betöltéskor megadod a helyes jelszót. Hiányzó vagy helytelen jelszó esetén a betöltési művelet hibával jár.

**Töröthetem a PPT fájlt a konvertálás után?**

Tartsd meg az eredetit, amíg a PPTX-et ellenőrizted azokban a megjelenítőkben és munkafolyamatokban, amelyek számodra fontosak. Ez visszaállítási példányt biztosít, ha egy örökölt funkció másként konvertálódik.