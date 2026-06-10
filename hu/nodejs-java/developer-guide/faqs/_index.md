---
title: GYIK
type: docs
weight: 340
url: /hu/nodejs-java/faqs/
keywords:
- GYIK
- prezentáció formátum
- memóriahiány hiba
- dia méret
- szöveg kinyerése
- szöveg lekérése
- bekezdés méret
- táblázatok formázása
- betűtípus
- PowerPoint
- OpenDocument
- prezentáció
- Node.js
- JavaScript
- Aspose.Slides
description: "Válaszokat kap a gyakran ismételt kérdésekre az Aspose.Slides for Node.js via Java témakörében, beleértve a PowerPoint és OpenDocument támogatást, a telepítési útmutatót, a licencelést és a hibaelhárítást."
---
## **Áttekintés**

Ez a GYIK válaszokat ad a gyakori kérdésekre az Aspose.Slides kapcsán. Bemutatja a támogatott fájlformátumokat, a nagy prezentációkkal dolgozás közbeni kivételek kezelését, a diák méretének módosítását, a diák előnézetét, a prezentációkból származó szöveg lekérését, a táblázatkeretek formázását, a képek elhelyezését, valamint a betűtípusokkal kapcsolatos problémák megoldását a prezentációk PDF vagy képek formátumba konvertálásakor.

## **Támogatott fájlformátumok**

**Q: Milyen fájlformátumokat támogat az Aspose.Slides for Node.js via Java?**

**A**: Az Aspose.Slides for Node.js via Java a [Supported File Formats](/slides/hu/nodejs-java/supported-file-formats/) szakaszban leírt fájlformátumokat támogatja.

## **Kivételkezelés**

**Q: Memóriahiány kivételt kapok egy nagy képeket tartalmazó PPT fájl betöltésekor. Van korlátozás az Aspose.Slides-nél a fájlmérettel kapcsolatban?**

**A**: Nincs konkrét képlet a Aspose.Slides által támogatott prezentációméret kiszámításához. Elég memóriának kell rendelkezésre állnia a teljes prezentációs struktúra és a képek tárolásához. Általában a memóriában lévő képek több helyet foglalnak, mint a merevlemezen, különösen ha a képek további effektusokat tartalmaznak.

Általánosságban az Aspose.Slides for Node.js via Java könnyedén képes kezelni körülbelül 300 MB méretű prezentációs fájlokat egy 4 GB RAM-mal rendelkező szerveren.

## **Diákkal való munka**

**Q: Megváltoztathatom egy prezentáció diáinak méretét?**

**A**: A [Presentation](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/presentation/) osztály által biztosított `getSlideSize` metódust használva definiálhatja a diák méretét egy prezentációban.

**Q: Lehetséges-e, hogy egy prezentációban a diák különböző méretűek legyenek?**

**A**: Mivel a diák mérete a Microsoft PowerPoint dokumentumokban a prezentáció szintjén van meghatározva, erre nincs lehetőség.

**Q: Támogatja-e az Aspose.Slides for Node.js via Java a dia előnézetét mentés előtt?**

**A**: A prezentáció diáit képekké renderelheti, és ezeket a képeket használhatja a diák előnézetéhez.

## **Szöveggel való munka**

**Q: Lehetséges-e a teljes szöveg lekérése egy prezentációból?**

**A**: Az Aspose.Slides for Node.js via Java a [SlideUtil](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/slideutil/) osztályt kínálja, amely többféle módszert biztosít a prezentációk teljes szövegének lekérésére.

**Q: Miért különböznek a bekezdésméretek Windows és Linux operációs rendszereken?**

**A**: A bekezdésméretek számítása a bekezdést reprezentáló szövegméret kiszámításán alapul. A szövegméret számítása a PowerPoint prezentációban megadott betűtípus metrikáira támaszkodik. Ha a megadott betűtípus hiányzik, a leginkább hasonló betűtípus veszi át, de ennek a betűtípusnak a metrikái eltérnek az eredetitől. Ennek következtében a bekezdésméretek számítása különböző rendszereken eltérő eredményeket ad, a telepített betűtípusok halmazától függően. Ahhoz, hogy ugyanazt az eredményt érje el különböző operációs rendszereken, ugyanazokat a betűtípusokat kell telepíteni a rendszerekre, vagy betölteni őket futásidőben, mint [external fonts](/slides/hu/nodejs-java/custom-font/).

## **Formázás és képek**

**Q: Hogyan állíthatom be egy táblázat keretének színét?**

**A**: A táblázat összes keretének vagy csak a teljes táblázat körüli keret színét megváltoztathatja. Az összes keret módosításához használja a [Cell](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/cell/) osztály `getCellFormat` metódusát. A teljes táblázat külső keretéhez iteráljon a cellákon, és változtassa meg a külső keretek színét.

**Q: Milyen mértékegységet használ az Aspose.Slides for Node.js via Java a képek elhelyezéséhez?**

**A**: A diákon lévő összes alakzat koordinátái és méretei pontban (72 dpi) vannak mérve.

## **Betűtípusokkal való munka**

**Q: PPT PDF-re vagy képekre konvertálásakor miért eltérnek a betűtípusok a kimeneti dokumentumokban?**

**A**: Ez a probléma azt jelezheti, hogy a prezentációban használt betűtípusok hiányoznak az operációs rendszertől, amelyen a kód futtatásra került. Telepítenie kell a betűtípusokat az operációs rendszerre, vagy betöltheti őket külső betűtípusokként a [FontsLoader](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/fontsloader/) osztály használatával, ahogy az alább látható:
```javascript
var folders = java.newArray("java.lang.String", ["path_to_a_folder_with_fonts"]));
java.callStaticMethodSync("com.aspose.slides.FontsLoader", "loadExternalFonts", folders);
```