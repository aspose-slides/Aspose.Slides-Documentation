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
description: "Konvertálja a régi PPT fájlokat PPTX-re Pythonban az Aspose.Slides segítségével. Tartalmaz példákat egyetlen fájl és kötegelt konverzióra, hibakezelésre és hűségi megjegyzésekre."
---
## **Áttekintés**

A PPT a régi bináris PowerPoint formátum, míg a PPTX az újabb Open XML formátum. Az Aspose.Slides for Python via .NET betölthet egy PPT fájlt, és PPTX‑ként mentheti el anélkül, hogy a Microsoft PowerPoint telepítve lenne. Ez a cikk bemutatja, hogyan lehet egy fájlt vagy egy könyvtárban lévő fájlokat konvertálni, és megmagyarázza, mit kell ellenőrizni a konverzió után.

## **PPT fájl konvertálása PPTX‑re**

Töltsd be a forrásfájlt a [Presentation](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentation/) osztállyal, majd hívd a [Presentation.save](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentation/save/) metódust a [SaveFormat.PPTX](https://reference.aspose.com/slides/hu/python-net/aspose.slides.export/saveformat/) argumentummal. A `with` utasítás felszabadítja a prezentációt és annak erőforrásait, amikor a blokk véget ér.

```python
import aspose.slides as slides

# Töltsd be a régi PPT prezentációt.
with slides.Presentation("presentation.ppt") as presentation:
    # Mentsd a prezentációt PPTX formátumban.
    presentation.save("presentation.pptx", slides.export.SaveFormat.PPTX)
```

A fájlkiterjesztés önmagában nem határozza meg a kimeneti formátumot; ezt a [SaveFormat.PPTX](https://reference.aspose.com/slides/hu/python-net/aspose.slides.export/saveformat/) argumentum biztosítja. Tartsd külön a bemeneti és kimeneti útvonalakat, ha meg szeretnéd őrizni az eredeti PPT fájlt.

## **Több PPT fájl konvertálása**

Az alábbi példa az adott könyvtárban található minden `.ppt` fájlt konvertálja. Minden fájlt önállóan dolgoz fel, így egy sikertelen konverzió sem állítja le a többi feldolgozását.

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

Éles környezetben naplózd a teljes kivételt, dönts arról, hogy a meglévő kimeneti fájl felülírható‑e, és írd a sikertelen fájlneveket egy újrapróbálási vagy felülvizsgálati sorba. Sérült fájlok, a szükséges jelszó nélkül megnyitott jelszóval védett fájlok, elérhetetlen útvonalak és nem támogatott tartalom is okozhat konverziós hibát. Lásd a [Password-Protected Presentations](/python-net/password-protected-presentation/) oldalt a titkosított fájlok betöltéséhez.

## **Hűség és örökölt funkciók**

A konverzió általában megőrzi a diák, mester‑diák, elrendezések, szöveg, alakzatok, képek, táblázatok és diagramok tartalmát. Azonban a PPT és a PPTX nem minden funkciót ábrázol pontosan ugyanúgy. Egy örökölt funkció, amelynek nincs PPTX ekvivalense, vagy amelyet a könyvtár nem támogat, normalizálódhat, kihagyásra kerülhet, vagy eltérően jelenhet meg.

Ellenőrizd a konvertált fájlt, ha animációkat, áttűnéseket, beágyazott vagy hivatkozott OLE objektumokat, ActiveX vezérlőket, beágyazott médiát, ritka betűkészleteket vagy VBA makrókat tartalmaz. Egy egyszerű PPTX fájl nem makró‑támogatott formátum, ezért megfelelő makró‑támogatott munkafolyamatot kell használni, ha a VBA‑nak elérhetőnek kell maradnia. Emellett ellenőrizd, hogy a szükséges betűkészletek és külső erőforrások jelen vannak-e abban a környezetben, ahol a konvertált prezentáció meg lesz nyitva vagy renderelve.

Fontos dokumentumok esetén programozottan nyisd meg újra a létrehozott PPTX fájlt, ellenőrizd a kulcsdiák számát és tartalmát, majd hasonlítsd össze a megjelenését és a diavetítés viselkedését a célzott nézőprogramban. Ne tekintsd a sikeres [Presentation.save](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentation/save/) hívást bizonyítéknak arra, hogy minden örökölt funkció pontos PPTX reprezentációval rendelkezik.

## **Mikor használjuk a PPTX‑et**

Használd a PPTX‑et, ha a prezentációt a jelenlegi PowerPoint verziókban szeretnéd szerkeszteni, Open XML csomagokkal dolgozó rendszerekkel cserélni, vagy olyan formátumban tárolni, amely könnyebben ellenőrizhető és helyreállítható, mint a régi bináris PPT. Tartsd meg az eredeti PPT‑t archiválási vagy visszagörgetési példányként, amíg a konvertált prezentáció át nem esik a hűség‑ellenőrzéseken.

Ha PDF‑re, HTML‑re, képekre, XPS‑re vagy egy másik kimeneti típusra van szükséged, használd a [Convert Presentations to Multiple Formats](/python-net/convert-presentation/) útmutatót a formához igazítva, ahelyett, hogy azt feltételeznéd, minden cél megőrzi a szerkeszthető PowerPoint funkciókat.

## **Online konverter**

Ritka fájlokhoz vagy gyors összehasonlításhoz használhatod az [online PPT to PPTX converter](https://products.aspose.app/slides/hu/conversion/ppt-to-pptx) eszközt. Ismételhető konverziókhoz, kötegelt feldolgozáshoz vagy alkalmazásszintű hibakezeléshez használd a Python API‑t.

## **Kapcsolódó cikkek**

- [PPT vs PPTX](/python-net/ppt-vs-pptx/)
- [Prezentációk mentése Pythonban](/python-net/save-presentation/)
- [Támogatott fájlformátumok](/python-net/supported-file-formats/)
- [Prezentációk megnyitása Pythonban](/python-net/open-presentation/)

## **GYIK**

**Átkonvertálhatom a PPT‑t PPTX‑re a Microsoft PowerPoint telepítése nélkül?**

Igen. Az Aspose.Slides for Python via .NET betölti és menti a prezentációs fájlokat anélkül, hogy a Microsoft PowerPoint szükséges lenne.

**A PPT‑ról PPTX‑re konverzió pontosan megőrzi az összes tartalmat?**

Megőrzi a szokásos prezentációs tartalmakat, de a pontos hűség nem garantált minden örökölt vagy nem támogatott funkció esetén. Ellenőrizd a létrehozott fájlt, ha makrókat, OLE vagy ActiveX objektumokat, médiát, speciális animációkat vagy ritka betűkészleteket tartalmaz.

**Átkonvertálhatok jelszóval védett PPT fájlt?**

Igen, ha a betöltéskor a helyes jelszót adod meg. A hiányzó vagy helytelen jelszó a betöltési művelet hibáját eredményezi.

**Törötnöm kell a PPT fájlt a konverzió után?**

Tartsd meg az eredetit, amíg a PPTX‑et le nem ellenőrzöd a számodra fontos nézők és munkafolyamatok szerint. Ez visszagörgetési példányt biztosít, ha egy örökölt funkció másképp konvertálódik.