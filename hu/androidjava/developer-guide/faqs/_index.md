---
title: GYIK
type: docs
weight: 340
url: /hu/androidjava/faqs/
keywords:
- GYIK
- prezentáció formátum
- memóriahiány hiba
- dia mérete
- szöveg kinyerése
- szöveg lekérése
- bekezdés mérete
- táblázatok formázása
- betűtípus
- PowerPoint
- OpenDocument
- prezentáció
- Android
- Java
- Aspose.Slides
description: "Kapjon válaszokat az Aspose.Slides for Android via Java GYIK-ra, amely lefedi a PowerPoint és OpenDocument támogatást, a telepítési útmutatót, a licencelést és a hibaelhárítást."
---
## **Áttekintés**

Ez a GYIK válaszokat ad a gyakran felmerülő kérdésekre az Aspose.Slides kapcsán. Lefedi a támogatott fájlformátumokat, a nagy prezentációk feldolgozásakor felmerülő kivételek kezelését, a diák méretének módosítását, a diák előnézetét, a prezentációkból származó szöveg lekérését, a táblázatkeretek formázását, a képek elhelyezését és a betűtípusokkal kapcsolatos problémák megoldását a prezentációk PDF-re vagy képekre konvertálásakor.

## **Támogatott fájlformátumok**

**Q:** Milyen fájlformátumokat támogat az Aspose.Slides for Android via Java?

**A:** Az Aspose.Slides for Android via Java a [Supported File Formats](/slides/hu/androidjava/supported-file-formats/) szakaszban leírt fájlformátumokat támogatja.

## **Kivételek**

**Q:** Memóriahiány kivételt kapok egy nagy PPT fájl képekkel történő betöltésekor. Van valamilyen méretkorlátozás az Aspose.Slides-ben?

**A:** Nincs konkrét képlet a Aspose.Slides által támogatott prezentáció méretének kiszámítására. Elég memóriának kell rendelkezésre állnia a teljes prezentáció struktúrájának és a képeknek a memóriában való tárolásához. Általában a memóriában a képek több helyet foglalnak el, mint a merevlemezen, különösen ha a képek további effektusokat tartalmaznak.

Általánosságban a Aspose.Slides for Android via Java könnyedén kezeli a körülbelül 300 MB körüli prezentációs fájlokat egy 4 GB RAM-mal rendelkező szerveren.

## **Diák kezelése**

**Q:** Módosíthatom a diák méretét egy prezentációban?

**A:** A [Presentation](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/presentation/) osztály által biztosított `getSlideSize` metódust használhatja a diák méretének meghatározásához a prezentációban.

**Q:** Lehetőség van-e különböző méretű diák definiálására egy prezentációban?

**A:** Mivel a diák méretét a Microsoft PowerPoint dokumentumokban a prezentáció szintjén definiálják, erre nincs megoldás.

**Q:** Támogatja-e az Aspose.Slides for Android via Java a dia előnézetét a mentés előtt?

**A:** A prezentáció diák renderelhetők képekké, és ezeket a képeket felhasználhatja a diák előnézetéhez.

## **Szöveggel való munka**

**Q:** Lehetséges-e a teljes szöveg lekérése egy prezentációból?

**A:** Az Aspose.Slides for Android via Java a [SlideUtil](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/slideutil/) osztályt kínálja, amely különféle módszereket biztosít a prezentációk teljes szövegének lekéréséhez.

**Q:** Miért különböznek a bekezdésméretek PC-n és Androidon?

**A:** A bekezdésméretek kiszámítása a bekezdésben megjelenő szöveg méretének számításán alapul. A szövegméret számítása a PowerPoint prezentációban megadott betűtípus metrikáin alapul. Ha a megadott betűtípus hiányzik, azt a leginkább hasonló betűtípussal helyettesítik, amelynek metrikái eltérnek az eredetitől. Ennek következtében a bekezdésméretek különböző rendszerekben eltérő eredményeket adnak a telepített betűtípusok összetételétől függően. Ahhoz, hogy különböző operációs rendszereken ugyanazt az eredményt érje el, ugyanolyan betűtípusokat kell telepíteni a rendszerekre, vagy futásidőben be kell tölteni őket [external fonts](/slides/hu/androidjava/custom-font/) formájában.

## **Formázás és képek**

**Q:** Hogyan állíthatom be a táblázat szegély színét?

**A:** A táblázat összes szegélyének színét, vagy csak a teljes táblázatot körülvevő szegély színét módosíthatja. Az összes szegély megváltoztatásához használja az `getCellFormat` metódust az [ICell](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/icell/) interfészből. A teljes táblázat szegélyének módosításához iteráljon a cellákon, és változtassa meg a külső szegélyek színét.

**Q:** Milyen mértékegységet használ az Aspose.Slides for Android via Java a képek elhelyezésére?

**A:** A diákon lévő összes alakzat koordinátái és méretei pontban (point) (72 dpi) vannak mérve.

## **Betűtípusok kezelése**

**Q:** PPT PDF-re vagy képekre konvertálásakor miért különböznek a betűtípusok a kimeneti dokumentumokban?

**A:** Ez a probléma arra utalhat, hogy a prezentációban használt betűtípusok hiányoznak azon a rendszeren, ahol a kód futott, telepítve. Telepítenie kell a betűtípusokat az operációs rendszerre, vagy külső betűtípusokként betöltheti őket a [FontsLoader](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/fontsloader/) osztály segítségével, ahogy az alább látható:
```java
String[] folders = new String[] { "path_to_a_folder_with_fonts" };
FontsLoader.loadExternalFonts(folders);
```