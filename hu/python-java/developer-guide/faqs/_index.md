---
title: GYIK
type: docs
weight: 340
url: /hu/python-java/faqs/
keywords:
- GYIK
- prezentáció formátum
- memóriakimaradás hiba
- dia méret
- szöveg kinyerés
- bekezdés mérete
- táblázat keretek
- betűtípus
- PowerPoint
- OpenDocument
- prezentáció
- Python
- Java
- Aspose.Slides
description: "Találjon válaszokat a gyakori kérdésekre az Aspose.Slides for Python via Java kapcsán, beleértve a fájlformátumokat, memóriahasználatot, dia méreteket, szöveget, táblázatokat, képeket és betűtípusokat."
---
## **Áttekintés**

Ez a GYIK a támogatott fájlformátumokat, a nagy prezentációk memóriahasználatát, a dia méreteket és előnézetet, a szöveg kinyerését, a táblázat kereteit, a képek elhelyezését és a betűtípusok eltéréseit tárgyalja, amikor a prezentációkat PDF‑re vagy képekre konvertáljuk.

## **GYIK**

### **Támogatott fájlformátumok**

**Milyen fájlformátumokat támogat az Aspose.Slides for Python via Java?**

Lásd a [Támogatott fájlformátumok](/slides/hu/python-java/supported-file-formats/) oldalt a támogatott prezentáció-, dokumentum- és képfájlformátumok, valamint azok import‑ és exportképességei tekintetében.

### **Kivételek**

**Miért kapok memóriahiány hibát, amikor nagy, képekkel teli prezentációt töltök be? Van fájlméret‑korlát?**

Nincs egyetlen fájlméret‑küszöb, amely megjósolná, hogy a prezentáció elfér‑e a memóriában. A memóriaigény a prezentáció felépítésétől, a kitömörített képektől, a hatásoktól és a végzett műveletektől függ. A képek sokkal több memóriát foglalhatnak el, mint a lemezen tömörített méretük.

Az Aspose.Slides for Python via Java a Java motorját JPype‑on keresztül használja, így a JVM halomnak elegendő helyet kell biztosítania a feldolgozáshoz. A rendelkezésre álló rendszer‑RAM önmagában nem mutatja meg, mennyi memóriát használhat a JVM. A prezentációk használatának befejezése után szabadítsa fel őket a [Presentation.dispose](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentation/#dispose) metódussal. A környezet beállításáról lásd a [Rendszerkövetelmények](/slides/hu/python-java/system-requirements/) és [Telepítés](/slides/hu/python-java/installation/) oldalakat.

### **Diákkal való munka**

**Módosíthatom a prezentáció diáinak méretét?**

Igen. Használja a [Presentation.getSlideSize](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentation/#getslidesize) metódust a prezentáció diaméret‑beállításainak lekérdezéséhez, majd a [SlideSize.setSize](https://reference.aspose.com/slides/hu/python-java/aspose.slides/slidesize/#setsize) metódust a méretek beállításához és a meglévő tartalom skálázásának kiválasztásához.

**Lehet, hogy egy prezentáción belül a diák különböző méretűek legyenek?**

Nem. A Microsoft PowerPoint dokumentumok a diákméretet a prezentáció szintjén definiálják, így minden dia ugyanazzal a mérettel rendelkezik.

**Előnézhetem a dia megjelenését a prezentáció mentése nélkül?**

Igen. Renderelje a diát képre, és jelenítse meg azt az alkalmazásában. Nem szükséges előre elmenteni a prezentációt.

### **Szöveggel való munka**

**Kinyerhetem a prezentáció összes szövegét?**

Igen. A [SlideUtil](https://reference.aspose.com/slides/hu/python-java/aspose.slides/slideutil/) osztály metódusai lehetővé teszik a szöveg kinyerését a teljes prezentációból és az egyes diákból.

**Miért különböznek a bekezdésméretek Windows és Linux alatt?**

A bekezdés méretei a szöveget megjelenítő betűtípusok metrikáitól függenek. Ha egy betűtípus hiányzik, helyettesítő lehet, amely más karakter‑szélességeket és sor‑magasságokat használ, ezáltal módosítva a sortörést és a bekezdés méretét. Telepítse ugyanazokat a betűtípusokat mindkét rendszerre, vagy töltse be ugyanazokat a betűtípus‑fájlokat a [FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/hu/python-java/aspose.slides/fontsloader/#loadexternalfonts) metódussal a prezentációk létrehozása vagy betöltése előtt.

### **Formázás és képek**

**Hogyan állíthatom be egy táblázat keretének színét?**

Használja a [Cell.getCellFormat](https://reference.aspose.com/slides/hu/python-java/aspose.slides/cell/#getcellformat) metódust az egyes cellák keretformázásának eléréséhez, és állítsa be a kívánt keretek kitöltőszínét. Az összes keret módosításához dolgozzon fel minden cellát. Ha csak a táblázat keretét szeretné módosítani, frissítse a táblázat szélein lévő cellák külső kereteit.

**Milyen egységeket használnak a képek pozicionálásához és méretezéséhez?**

A formák koordinátáit és méreteit pontban (point) adják meg. Egy hüvelyk 72 pont, ezek nem pixelkoordináták.

### **Betűtípusokkal való munka**

**Miért változnak a betűtípusok, amikor a prezentációt PDF‑re vagy képekre konvertálom?**

A konvertálást végző gépen hiányozhatnak a szükséges betűtípusok. Telepítse az eredeti betűtípusokat, vagy használja a [FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/hu/python-java/aspose.slides/fontsloader/#loadexternalfonts) metódust a betűtípus‑mappák hozzáadásához. Töltse be a külső betűtípusokat a prezentációk létrehozása vagy megnyitása előtt.

Az alábbi példa betűtípus‑mappát regisztrál. Cserélje le az útvonalat egy olyan meglévő mappára, amely a saját betűtípus‑fájljait tartalmazza. Feltételezi, hogy a környezet megegyezik a [Telepítés](/slides/hu/python-java/installation/) leírásában szereplővel.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FontsLoader

font_folders = jpype.JArray(jpype.JString)(["path_to_a_folder_with_fonts"])
FontsLoader.loadExternalFonts(font_folders)
```

A példa a JVM‑et futtatva hagyja a további prezentációs műveletekhez. A notebook használatra és a JVM életciklus‑korlátozásokra vonatkozó információk a [Korlátozások és API‑különbségek](/slides/hu/python-java/limitations-and-api-differences/) oldalon találhatók.