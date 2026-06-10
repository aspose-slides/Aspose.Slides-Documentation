---
title: Fallback betűtípusok megadása prezentációkhoz Pythonban
linktitle: Fallback betűtípus
type: docs
weight: 10
url: /hu/python-net/create-fallback-font/
keywords:
- fallback betűtípus
- fallback szabály
- betűtípus alkalmazása
- betűtípus cseréje
- Unicode-tartomány
- hiányzó glif
- megfelelő glif
- PowerPoint
- OpenDocument
- prezentáció
- Python
- Aspose.Slides
description: "Elsajátítja az Aspose.Slides for Python .NET-en keresztül a fallback betűtípusok beállítását PPT, PPTX és ODP fájlokban, biztosítva a konzisztens szövegmegjelenítést bármilyen eszközön vagy operációs rendszeren."
---
## **Áttekintés**

Az Aspose.Slides lehetővé teszi, hogy fallback betűtípusokat adjunk meg a prezentáció rendereléséhez és exportálási műveletekhez. A fallback betűtípusokat akkor használjuk, amikor az elsődleges betűtípus nem tartalmaz glifeket bizonyos karakterekhez.

A fallback viselkedést fallback szabályokkal konfiguráljuk. Minden szabály egy Unicode-tartományt kapcsol össze egy vagy több betűtípussal, amelyek tartalmazhatják a szükséges glifeket. Definiálhat szabályokat különböző karaktertartományokhoz, hozzáadhat vagy eltávolíthat fallback betűtípusokat a meglévő szabályokból, és több szabályt rendezhet egy fallback betűtípus szabályok gyűjteményében.

A fallback szabályok futásidejű renderelési beállítások. Nem módosítják magát a prezentációfájlt, és nem tárolódnak a PPTX fájlban.

## **Fallback betűtípusok megadása**

Az Aspose.Slides támogatja a [FontFallBackRule](https://reference.aspose.com/slides/hu/python-net/aspose.slides/FontFallBackRule/) osztályt a fallback betűtípus alkalmazásának szabályainak megadásához. A [FontFallBackRule](https://reference.aspose.com/slides/hu/python-net/aspose.slides/FontFallBackRule/) osztály egy kapcsolatot képvisel a megadott Unicode-tartomány, amely a hiányzó glifek keresésére szolgál, és a megfelelő glifeket tartalmazó betűtípusok listája között:

```py
startUnicodeIndex = 0x0B80
endUnicodeIndex = 0x0BFF

firstRule = slides.FontFallBackRule(startUnicodeIndex, endUnicodeIndex, "Vijaya")
secondRule = slides.FontFallBackRule(0x3040, 0x309F, "MS Mincho, MS Gothic")

#Többféle módon is hozzáadhat betűtípuslistát:
fontNames =  ["Segoe UI Emoji, Segoe UI Symbol", "Arial" ]

thirdRule = slides.FontFallBackRule(0x1F300, 0x1F64F, fontNames)
```

Lehetőség van a fallback betűtípus [remove](https://reference.aspose.com/slides/hu/python-net/aspose.slides/fontfallbackrule/remove/) vagy a [add_fall_back_fonts](https://reference.aspose.com/slides/hu/python-net/aspose.slides/fontfallbackrule/add_fall_back_fonts/) hozzáadására egy meglévő [FontFallBackRule](https://reference.aspose.com/slides/hu/python-net/aspose.slides/FontFallBackRule/) objektumba.

A [FontFallBackRulesCollection](https://reference.aspose.com/slides/hu/python-net/aspose.slides/fontfallbackrulescollection/) használható a [FontFallBackRule](https://reference.aspose.com/slides/hu/python-net/aspose.slides/FontFallBackRule/) objektumok listájának rendezésére, amikor több Unicode-tartományhoz kell fallback betűtípus helyettesítési szabályokat megadni.

{{% alert color="primary" title="See also" %}} 
- [Fallback betűtípusok gyűjteményének létrehozása](/slides/hu/python-net/create-fallback-fonts-collection/)
{{% /alert %}}

## **GYIK**

**Mi a különbség a fallback betűtípus, betűtípus helyettesítés és betűtípus beágyazás között?**

A fallback betűtípus csak a fő betűtípusban hiányzó karakterekhez használatos. A [Font substitution](/slides/hu/python-net/font-substitution/) az egész megadott betűtípust egy másik betűtípusra cseréli. A [Font embedding](/slides/hu/python-net/embedded-font/) a betűtípusokat az output fájlba csomagolja, így a címzettek a szöveget a tervezett módon láthatják.

**A fallback betűtípusok alkalmazásra kerülnek exportáláskor, például PDF, PNG vagy SVG esetén, vagy csak a képernyőn történő rendereléskor?**

Igen. A fallback hatással van minden [rendering and export operations](/slides/hu/python-net/convert-presentation/) műveletre, ahol karaktereket kell kirajzolni, de azok hiányoznak a forrás betűtípusból.

**A fallback beállítása módosítja a prezentációfájlt, és a beállítás megmarad a későbbi megnyitások során?**

Nem. A fallback szabályok futásidejű renderelési beállítások a kódban; nem tárolódnak a .pptx fájlban, és nem jelennek meg a PowerPointban.

**Az operációs rendszer (Windows/Linux/macOS) és a betűtárgyak könyvtárai befolyásolják a fallback kiválasztását?**

Igen. A motor a rendelkezésre álló rendszerkönyvtárakból és a megadott [additional paths](/slides/hu/python-net/custom-font/) útvonalakból keres betűtípusokat. Ha egy betűtípus fizikailag nem érhető el, a rá hivatkozó szabály nem léphet életbe.

**A fallback működik WordArt, SmartArt és diagramok esetén?**

Igen. Amikor ezekben az objektumokban szöveg van, ugyanaz a glif-helyettesítési mechanizmus alkalmazódik a hiányzó karakterek megjelenítésére.