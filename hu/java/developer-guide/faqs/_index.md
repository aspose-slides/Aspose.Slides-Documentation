---
title: GYIK
type: docs
weight: 340
url: /hu/java/faqs/
keywords:
- GYIK
- prezentáció formátum
- memóriahiány hiba
- dia méret
- szöveg kinyerése
- szöveg lekérdezése
- bekezdés méret
- táblázatok formázása
- betűtípus
- PowerPoint
- OpenDocument
- prezentáció
- Java
- Aspose.Slides
description: "Válaszokat kap a Java-hoz készült Aspose.Slides GYIK-ra, amelyek a PowerPoint és OpenDocument támogatást, telepítési útmutatót, licencelést és hibaelhárítást fedik le."
---
## **Áttekintés**

Ez a GYIK válaszokat ad a gyakori kérdésekre az Aspose.Slides-ról. Tárgyalja a támogatott fájlformátumokat, kivételek kezelését nagy prezentációk esetén, a diák méretének módosítását, a diák előnézetét, a szöveg lekérdezését a prezentációkból, a táblázatkeretek formázását, képek elhelyezését, valamint a betűtípussal kapcsolatos problémák megoldását a prezentációk PDF-re vagy képekre konvertálásakor.

## **Támogatott fájlformátumok**

**Q: Milyen fájlformátumokat támogat az Aspose.Slides for Java?**

**A**: Az Aspose.Slides for Java a [Supported File Formats](/slides/hu/java/supported-file-formats/) oldalon leírt fájlformátumokat támogatja.

## **Kivételkezelés**

**Q: Memóriahiány hibát kapok egy nagy PPT-fájl betöltésekor képekkel. Van korlátozás az Aspose.Slides-ben a fájlméret tekintetében?**

**A**: Nincs konkrét képlet a prezentáció méretének kiszámítására, amelyet az Aspose.Slides támogat. Elég memóriának kell rendelkezésre állnia a teljes prezentációs struktúra és a képek tárolásához. Általában a memóriában lévő képek több helyet foglalnak, mint a merevlemezen, különösen ha a képek további effektusokat tartalmaznak.

Általánosságban az Aspose.Slides for Java könnyen kezel körülbelül 300 MB méretű prezentációs fájlokat egy 4 GB RAM-mal rendelkező szerveren.

## **Munkavégzés a diákon**

**Q: Módosíthatom a diák méretét egy prezentációban?**

**A**: A [Presentation](https://reference.aspose.com/slides/hu/java/com.aspose.slides/presentation/) osztály `getSlideSize` metódusával definiálhatja a diák méretét egy prezentációban.

**Q: Lehetőség van a prezentációban különböző méretű diák definiálására?**

**A**: Mivel a diák mérete a Microsoft PowerPoint dokumentumokban a prezentáció szintjén van meghatározva, erre nincs lehetőség.

**Q: Támogatja az Aspose.Slides for Java a dia előnézetét mentés előtt?**

**A**: A prezentáció diák renderelhetők képekké, amelyeket felhasználhat a diák előnézetéhez.

## **Munkavégzés szöveggel**

**Q: Lehetőség van a teljes szöveg lekérdezésére egy prezentációból?**

**A**: Az Aspose.Slides for Java a [SlideUtil](https://reference.aspose.com/slides/hu/java/com.aspose.slides/slideutil/) osztályt biztosítja, amely különféle módszereket kínál a prezentációk teljes szövegének lekérdezésére.

**Q: Miért különböznek a bekezdésméretek Windows és Linux operációs rendszerek között?**

**A**: A bekezdésméretek számítása a bekezdésben megjelenő szöveg méretén alapul. A szövegméret számítása a PowerPoint prezentációban megadott betűtípus metrikáin alapul. Ha a megadott betűtípus hiányzik, azt a leginkább hasonló betűtípus váltja fel, amelynek metrikái eltérnek az eredetitől. Ennek következtében a különböző rendszerekben a bekezdésméretek számítása különböző eredményeket ad a telepített betűtípusok készletétől függően. Azonos eredmény eléréséhez a rendszereken ugyanazokat a betűtípusokat telepíteni kell, vagy azokat futásidőben betölteni kell, mint [external fonts](/slides/hu/java/custom-font/).

## **Formázás és képek**

**Q: Hogyan állíthatom be egy táblázat keret színét?**

**A**: Megváltoztathatja az összes táblázatkeret színét, vagy csak a teljes táblázat körüli keretét. Az összes keret módosításához használja a `getCellFormat` metódust az [ICell](https://reference.aspose.com/slides/hu/java/com.aspose.slides/icell/) interfészből. A teljes táblázat keretéhez iterálja a cellákat, és változtassa meg a külső keretek színét.

**Q: Milyen mértékegységet használ az Aspose.Slides for Java a képek elhelyezéséhez?**

**A**: A diákon lévő összes alakzat koordinátáit és méretét pontban (72 dpi) mérik.

## **Munkavégzés betűtípusokkal**

**Q: Miért térnek el a betűtípusok a kimeneti dokumentumokban PPT PDF vagy képek konvertálásakor?**

**A**: Ez a probléma arra utalhat, hogy a prezentációban használt betűtípusok hiányoznak az operációs rendszerről, amelyen a kód fut. Telepítse a betűtípusokat az operációs rendszerbe, vagy töltse be őket külső betűtípusként a [FontsLoader](https://reference.aspose.com/slides/hu/java/com.aspose.slides/fontsloader/) osztály segítségével, ahogyan az alább látható:
```cs
var folders = new String[] { "path_to_a_folder_with_fonts" };
FontsLoader.loadExternalFonts(folders);
```