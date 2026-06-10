---
title: GYIK
type: docs
weight: 340
url: /hu/python-net/faq/
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
- Python
- Aspose.Slides
description: "Válaszokat kap a Aspose.Slides for Python via .NET GYIK-ra, amely lefedi a PowerPoint és OpenDocument támogatást, a telepítési útmutatót, a licencelést és a hibaelhárítást."
---
## **Áttekintés**

Ez a GYIK válaszokat ad a gyakori kérdésekre az Aspose.Slides-szel kapcsolatban. Tárgyalja a támogatott fájlformátumokat, a nagy prezentációk kezelésénél felmerülő kivételeket, a dia méretének módosítását, a diák előnézetét, a szöveg lekérését a prezentációkból, a táblázat szegélyek formázását, a képek elhelyezését, valamint a betűtípusokkal kapcsolatos problémák megoldását a prezentációk PDF‑re vagy képekre konvertálásakor.

## **Támogatott fájlformátumok**

**K: Milyen fájlformátumokat támogat az Aspose.Slides for Python via .NET?**

**V**: Az Aspose.Slides for Python via .NET támogatja az [Támogatott fájlformátumok](/slides/hu/python-net/supported-file-formats/) oldalon leírt fájlformátumokat.

## **Kivételek**

**K: Memóriahiány hibát kapok egy nagy PPT fájl képekkel történő betöltésekor. Van korlátozás az Aspose.Slides-nél a fájlméretre vonatkozóan?**

**V**: Nincs konkrét képlet a Aspose.Slides által támogatott prezentációméret kiszámításához. Elég memóriának kell rendelkezésre állnia a teljes prezentációs struktúra és a képek tárolásához. Általában a memóriában a képek több helyet foglalnak, mint a merevlemezen, különösen akkor, ha a képek további hatásokat tartalmaznak.

Általánosságban az Aspose.Slides for Python via .NET könnyen kezel körülbelül 300 MB körüli prezentációs fájlokat egy 4 GB RAM-mal rendelkező szerveren.

## **Munkavégzés diákon**

**K: Módosíthatom a diák méretét egy prezentációban?**

**V**: A [Prezentáció](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentation/) osztály által biztosított `slide_size` tulajdonságot használva definiálhatja a diák méretét egy prezentációban.

**K: Van mód a diák különböző méretű definiálására egy prezentációban?**

**V**: Mivel a diák mérete a Microsoft PowerPoint dokumentumokban a prezentáció szintjén van meghatározva, erre nincs lehetőség.

**K: Támogatja az Aspose.Slides for Python via .NET a dia előnézetét mentés előtt?**

**V**: Renderelheti a prezentáció diákját képekké, és ezeket a képeket használhatja a diák előnézetéhez.

## **Munkavégzés szövegen**

**K: Lehetséges a prezentáció összes szövegének lekérése?**

**V**: Az Aspose.Slides for Python via .NET biztosítja a [SlideUtil](https://reference.aspose.com/slides/hu/python-net/aspose.slides.util/slideutil/) osztályt az `aspose.slides.util` névtérben, amely különböző módszereket kínál a prezentációk teljes szövegének lekérésére.

**K: Miért különböznek a bekezdés méretei Windows és Linux operációs rendszereken?**

**V**: A bekezdésméretek számítása a bekezdést reprezentáló szövegméreten alapul. A szövegméret számítása a PowerPoint prezentációban megadott betűtípus metrikái szerint történik. Ha a megadott betűtípus hiányzik, a leginkább hasonló betűtípusra cserélik, de ennek a metrikái eltérnek az eredetitől. Ennek következtében a különböző rendszereken eltérő eredményeket kapunk a telepített betűkészletek különbsége miatt. Ahhoz, hogy ugyanazt az eredményt érje el különböző operációs rendszereken, telepítenie kell ugyanazokat a betűkészleteket a rendszerekre, vagy betöltheti őket futásidőben, mint [külső betűkészletek](/slides/hu/python-net/custom-font/).

## **Formázás és képek**

**K: Hogyan állíthatom be egy táblázat szegély színét?**

**V**: A táblázat összes szegélyének vagy csak a teljes táblázat körül lévő szegély színét módosíthatja. Az összes szegély megváltoztatásához használja a `cell_format` tulajdonságot a [Cell](https://reference.aspose.com/slides/hu/python-net/aspose.slides/cell/) osztályból. A teljes táblázat szegélyének módosításához iteráljon a cellákon, és változtassa meg a külső szegélyek színét.

**K: Milyen mértékegységet használ az Aspose.Slides for Python via .NET a képek elhelyezéséhez?**

**V**: A diákon található összes alakzat koordinátáit és méreteit pontban (72 dpi) mérik.

## **Munkavégzés betűtípusokkal**

**K: PPT PDF vagy képként történő konvertálásakor miért különböznek a betűtípusok a kimeneti dokumentumokban?**

**V**: Ez a probléma azt jelezheti, hogy a prezentációban használt betűtípusok hiányoznak az operációs rendszerről, amelyen a kód futott. Telepítenie kell a betűtípusokat az operációs rendszerre, vagy betöltheti őket külső betűkészletekként a [FontsLoader](https://reference.aspose.com/slides/hu/python-net/aspose.slides/fontsloader/) osztály használatával, ahogyan az alább látható:
```cs
folders = [ "path_to_a_folder_with_fonts" ]
aspose.slides.FontsLoader.load_external_fonts(folders)
```