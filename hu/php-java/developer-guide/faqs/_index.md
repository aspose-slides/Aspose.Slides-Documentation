---
title: GYIK
type: docs
weight: 340
url: /hu/php-java/faqs/
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
- PHP
- Aspose.Slides
description: "Kapjon válaszokat a Aspose.Slides for PHP via Java GYIK-re, amely lefedi a PowerPoint és OpenDocument támogatást, a telepítési útmutatót, a licencelést és a hibaelhárítást."
---
## **Áttekintés**

Ez a GYIK a leggyakoribb kérdésekre ad választ az Aspose.Slides használatával kapcsolatban. Tárgyalja a támogatott fájlformátumokat, a nagy bemutatók kezelésénél felmerülő kivételek kezelését, a diák méretének módosítását, a diák előnézetét, a bemutatóból történő szövegkinyerést, a táblázatkeretek formázását, a képek elhelyezését, valamint a betűtípusokkal kapcsolatos problémák megoldását a bemutatók PDF‑re vagy képekre konvertálásakor.

## **Támogatott fájlformátumok**

**K: Milyen fájlformátumokat támogat az Aspose.Slides for PHP via Java?**

**V**: Az Aspose.Slides for PHP via Java által támogatott fájlformátumok a [Supported File Formats](/slides/hu/php-java/supported-file-formats/) oldalon találhatók.

## **Kivételek**

**K: Memóriahiányos kivételt kapok egy nagy, képeket tartalmazó PPT fájl betöltésekor. Van korlátozás az Aspose.Slides‑ben a fájlméretre vonatkozóan?**

**V**: Nincs konkrét képlet a Aspose.Slides által támogatott bemutató méretének kiszámítására. Elég memóriának kell állnia rendelkezésre a teljes bemutató szerkezetének és a képeknek a memóriában történő tárolásához. Általában a memóriában lévő képek több helyet foglalnak el, mint a merevlemezen, különösen ha a képek további effektusokkal rendelkeznek.

Általánosságban az Aspose.Slides for PHP via Java könnyedén kezel körülbelül 300 MB körüli bemutató fájlokat egy 4 GB RAM‑mal rendelkező szerveren.

## **Munkavégzés diákon**

**K: Meg tudom változtatni a diák méretét egy bemutatóban?**

**V**: A diák méretét a [Presentation](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentation/) osztály által biztosított `getSlideSize` metódussal definiálhatja.

**K: Van lehetőség különböző méretű diák definiálására egy bemutatóban?**

**V**: Mivel a diák mérete a Microsoft PowerPoint dokumentumokban a bemutató szintjén van definiálva, erre nincs mód.

**K: Támogatja az Aspose.Slides for PHP via Java a dia előnézetét mentés előtt?**

**V**: A bemutató diák renderelhetők képként, és ezeket a képeket felhasználhatja a diák előnézetéhez.

## **Munkavégzés szöveggel**

**K: Lehetséges az összes szöveg kinyerése egy bemutatóból?**

**V**: Az Aspose.Slides for PHP via Java a [SlideUtil](https://reference.aspose.com/slides/hu/php-java/aspose.slides/slideutil/) osztályt biztosítja, amely különböző módszereket kínál a bemutatók teljes szövegének lekérésére.

**K: Miért különböznek a bekezdésméretek a Windows és a Linux operációs rendszereken?**

**V**: A bekezdésméretek számítása a bekezdésben megjelenő szöveg méretén alapul. A szövegméret számítása a PowerPoint prezentációban megadott betűtípus metrikáira épül. Ha a megadott betűtípus nincs telepítve, a legközelebbi betűtípusra cserélik, amelynek metrikái eltérnek az eredetitől. Ennek következtében a különböző rendszerekben a bekezdésméretek számítása eltérő eredményt ad a telepített betűkészletek eltérése miatt. Ahhoz, hogy ugyanazt az eredményt kapja különböző operációs rendszereken, telepítenie kell ugyanazokat a betűtípusokat a rendszerekre, vagy betöltheti őket futás közben, például [external fonts](/slides/hu/php-java/custom-font/) használatával.

## **Formázás és képek**

**K: Hogyan állíthatom be egy táblázat keretének színét?**

**V**: A táblázat összes keretének vagy csak az egész táblázat körül lévő keret színét módosíthatja. Az összes keret módosításához használja a `getCellFormat` metódust a [Cell](https://reference.aspose.com/slides/hu/php-java/aspose.slides/cell/) osztályból. Az egész táblázat keretéhez iteráljon a cellákon, és változtassa meg a külső keretek színét.

**K: Mely mértékegységet használja az Aspose.Slides for PHP via Java a képek elhelyezéséhez?**

**V**: A diákon lévő összes alakzat koordinátái és méretei pontban (72 dpi) vannak megadva.

## **Munkavégzés betűtípusokkal**

**K: Miért különböznek a betűtípusok a kimeneti dokumentumokban PPT‑PDF vagy képre való konvertáláskor?**

**V**: Ez a probléma arra utalhat, hogy a prezentációban használt betűtípusok hiányoznak az adott operációs rendszerről, amelyen a kód fut. Telepítse a betűtípusokat az operációs rendszerre, vagy töltse be őket külső betűtípusokként a [FontsLoader](https://reference.aspose.com/slides/hu/php-java/aspose.slides/fontsloader/) osztály segítségével az alábbiak szerint:
```php
$folders = ["path_to_a_folder_with_fonts"];
FontsLoader::loadExternalFonts($folders);
```