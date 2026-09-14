---
title: Helyettesítő betűtípusok megadása prezentációkhoz Python és Java segítségével
linktitle: Helyettesítő betűtípus
type: docs
weight: 10
url: /hu/python-java/create-fallback-font/
keywords:
- helyettesítő betűtípus
- helyettesítő szabály
- betűtípus alkalmazása
- betűtípus cseréje
- Unicode tartomány
- hiányzó glif
- helyes glif
- PowerPoint
- OpenDocument
- prezentáció
- Python
- Java
- Aspose.Slides
description: "Tanulja meg az Aspose.Slides használatát Pythonon keresztül Java-val, hogy helyettesítő betűtípusokat állítson be PPT, PPTX és ODP fájlokban, és biztosítsa a szöveg konzisztens megjelenítését minden eszközön vagy operációs rendszeren."
---
## **Áttekintés**

Az Aspose.Slides lehetővé teszi, hogy meghatározza a helyettesítő betűtípusokat a prezentáció megjelenítése és exportálása során. A helyettesítő betűtípusok akkor használatosak, amikor az elsődleges betűtípus nem tartalmaz glifeket a konkrét karakterekhez.

A helyettesítő viselkedés a helyettesítő szabályok révén konfigurálható. Minden szabály egy Unicode‑tartományt társít egy vagy több betűtípussal, amelyek a szükséges glifeket tartalmazhatják. Definiálhat szabályokat különböző karaktertartományokhoz, hozzáadhat vagy eltávolíthat helyettesítő betűtípusokat a meglévő szabályokból, és több szabályt rendezhet egy helyettesítő betűtípus szabálygyűjteményben.

A helyettesítő szabályok futásidőbeli megjelenítési beállítások. Nem módosítják magát a prezentációfájlt, és nem tárolódnak a PPTX‑fájlban.

## **Helyettesítő szabályok**

Az Aspose.Slides a [FontFallBackRule](https://reference.aspose.com/slides/hu/python-java/aspose.slides/fontfallbackrule/) osztályt biztosítja a helyettesítő betűtípusok alkalmazásának szabályozásához. Ez az osztály egy olyan kapcsolatot reprezentál, amely egy Unicode‑tartományt (amelyet a hiányzó glifek keresésére használnak) egy betűtípuslistához köti, amely a szükséges glifeket tartalmazhatja:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FontFallBackRule

start_unicode_index = 0x0B80
end_unicode_index = 0x0BFF

first_rule = FontFallBackRule(start_unicode_index, end_unicode_index, "Vijaya")
second_rule = FontFallBackRule(0x3040, 0x309F, "MS Mincho, MS Gothic")

# Többféleképpen adhatja meg a betűtípusok listáját.
font_names = jpype.JArray(jpype.JString)(["Segoe UI Emoji, Segoe UI Symbol", "Arial"])

third_rule = FontFallBackRule(0x1F300, 0x1F64F, font_names)
```

Egy helyettesítő betűtípust eltávolíthat a [remove](https://reference.aspose.com/slides/hu/python-java/aspose.slides/fontfallbackrule/#remove) metódussal, vagy helyettesítő betűtípusokat hozzáadhat a [addFallBackFonts](https://reference.aspose.com/slides/hu/python-java/aspose.slides/fontfallbackrule/#addFallBackFonts) metódussal egy meglévő [FontFallBackRule](https://reference.aspose.com/slides/hu/python-java/aspose.slides/fontfallbackrule/) objektumban.

A [FontFallBackRulesCollection](https://reference.aspose.com/slides/hu/python-java/aspose.slides/fontfallbackrulescollection/) képes rendezni egy listát a [FontFallBackRule](https://reference.aspose.com/slides/hu/python-java/aspose.slides/fontfallbackrule/) objektumokból, amikor több Unicode‑tartományhoz kell meghatározni a helyettesítő betűtípus cserére vonatkozó szabályokat.

{{% alert color="info" title="Lásd még" %}} 
- [Helyettesítő betűtípusok gyűjteményének létrehozása](/slides/hu/python-java/create-fallback-fonts-collection/)
{{% /alert %}}

## **GYIK**

**Mi a különbség a helyettesítő betűtípus, a betűtípus helyettesítés és a betűtípus beágyazás között?**

A helyettesítő betűtípus csak azokhoz a karakterekhez használatos, amelyek hiányoznak az elsődleges betűtípusból. A [Font substitution](/slides/hu/python-java/font-substitution/) az egész megadott betűtípust egy másik betűtípussal helyettesíti. A [Font embedding](/slides/hu/python-java/embedded-font/) a betűtípusokat az output fájlba csomagolja, hogy a címzettek a szöveget a tervezett módon láthassák.

**A helyettesítő betűtípusok alkalmazásra kerülnek exportáláskor, például PDF, PNG vagy SVG esetén, vagy csak a képernyőn történő megjelenítés során?**

Igen. A helyettesítés minden [rendering and export operations](/slides/hu/python-java/convert-presentation/) esetben hatással van, ahol a karaktereket meg kell jeleníteni, de azok hiányoznak a forrás betűtípusból.

**A helyettesítő konfigurálása módosítja a prezentációfájlt, és a beállítás megmarad a későbbi megnyitások során?**

Nem. A helyettesítő szabályok futásidőbeli megjelenítési beállítások a kódban; nem tárolódnak a .pptx fájlban, és nem jelennek meg a PowerPointban.

**Az operációs rendszer (Windows/Linux/macOS) és a betűtárak könyvtárainak halmaza befolyásolja a helyettesítő kiválasztását?**

Igen. A motor a rendelkezésre álló rendszerkönyvtárakból és a megadott [additional paths](/slides/hu/python-java/custom-font/) útvonalakból oldja fel a betűtípusokat. Ha egy betűtípus fizikailag nem érhető el, a rá hivatkozó szabály nem lép életbe.

**A helyettesítő működik WordArt, SmartArt és diagramok esetén?**

Igen. Amikor ezek az objektumok szöveget tartalmaznak, ugyanaz a glifhelyettesítési mechanizmus alkalmazásra kerül a hiányzó karakterek megjelenítéséhez.