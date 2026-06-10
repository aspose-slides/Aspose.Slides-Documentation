---
title: GYIK
type: docs
weight: 340
url: /hu/net/faqs/
keywords:
- GYIK
- PowerPoint
- prezentáció formátum
- memóriahiány hiba
- dia méret
- szöveg kinyerése
- szöveg lekérése
- bekezdés méret
- táblázatok formázása
- betűtípus
- .NET
- C#
- Aspose.Slides
description: "Kapja meg a válaszokat az Aspose.Slides for .NET GYIK-ra, amely lefedi a PowerPoint és OpenDocument támogatást, a telepítési útmutatót, a licencelést és a hibaelhárítást."
---
## **Áttekintés**

Ez a GYIK a gyakori kérdésekre ad válaszokat az Aspose.Slides kapcsán. Kitér a támogatott fájlformátumokra, a nagy bemutatók kezelése során fellépő kivételek kezelésére, a dia méretének módosítására, a diák előnézetére, a bemutatókból származó szöveg lekérdezésére, a táblázatszegélyek formázására, a képek elhelyezésére, valamint a betűtípusokkal kapcsolatos problémák megoldására a bemutatók PDF-re vagy képekre konvertálásakor.

## **Támogatott fájlformátumok**

**K: Milyen fájlformátumokat támogat az Aspose.Slides for .NET?**

**V**: Az Aspose.Slides for .NET a [Supported File Formats](/slides/hu/net/supported-file-formats/) oldalon leírt fájlformátumokat támogatja.

## **Kivételek**

**K: OutOfMemoryException hibát kapok, amikor nagy PPT fájlt képekkel töltök be. Van valamilyen méretkorlátozás az Aspose.Slides-ben?**

**A**: Nincs konkrét képlet a Aspose.Slides által támogatott bemutató méretének kiszámítására. Elég memóriának kell rendelkezésre állnia a teljes bemutató struktúrájának és a képeknek a memóriában való tárolásához. Általában a memóriában lévő képek több helyet foglalnak, mint a merevlemezen, különösen ha a képek további effektusokat tartalmaznak.

Általánosságban az Aspose.Slides for .NET könnyedén kezel körülbelül 300 MB méretű bemutató fájlokat egy 4 GB RAM-mal rendelkező szerveren.

## **Diákkal való munka**

**K: Megváltoztathatom a diák méretét egy bemutatóban?**

**A**: A [Presentation](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation/) osztály által biztosított `SlideSize` tulajdonságot használva definiálhatja a diák méretét egy bemutatóban.

**K: Van lehetőség különböző méretű diák definiálására egy bemutatóban?**

**A**: Mivel a diák mérete a Microsoft PowerPoint dokumentumokban a bemutató szintjén van definiálva, erre nincs lehetőség.

**K: Az Aspose.Slides for .NET támogatja-e egy dia előnézetét mentés előtt?**

**A**: A bemutató diák megjeleníthető képekké, és ezeket a képeket felhasználhatja a diák előnézetére.

## **Szöveggel való munka**

**K: Lehetséges-e a bemutató összes szövegének lekérdezése?**

**A**: Az Aspose.Slides for .NET a `Aspose.Slides.Util` névtérben a [SlideUtil](https://reference.aspose.com/slides/hu/net/aspose.slides.util/slideutil/) osztályt biztosítja, amely különféle módszereket kínál a bemutatók teljes szövegének lekérésére.

**K: Miért különböznek a bekezdésméretek Windows és Linux operációs rendszereken?**

**A**: A bekezdésméretek számítása a bekezdést reprezentáló szövegméret meghatározásán alapul. A szövegméret számítása a PowerPoint bemutatóban megadott betűtípus metrikáira épül. Ha a megadott betűtípus hiányzik, azt a leginkább hasonló betűtípus helyettesíti, de ennek a betűtípusnak más metrikái vannak az eredetihez képest. Ennek következtében a bekezdésméretek számítása különböző rendszereken eltérő eredményeket ad, a telepített betűtípusok halmazától függően. Ahhoz, hogy ugyanazt az eredményt különböző operációs rendszereken érjük el, ugyanazokat a betűtípusokat kell telepíteni a rendszerekre, vagy futási időben betölteni őket [külső betűtípusok](/slides/hu/net/custom-font/)ként.

## **Formázás és képek**

**K: Hogyan állíthatom be egy táblázat szegélyének színét?**

**A**: Minden táblázatszegély vagy csak a teljes táblázat körüli szegély színét módosíthatja. Az összes szegély megváltoztatásához használja a `CellFormat` tulajdonságot az [ICell](https://reference.aspose.com/slides/hu/net/aspose.slides/icell/) interfészből. A teljes táblázat szegélyének módosításához iteráljon a cellákon, és változtassa meg a külső szegélyek színét.

**K: Milyen mértékegységet használ az Aspose.Slides for .NET a képek elhelyezésénél?**

**A**: A diákon lévő összes alakzat koordinátái és méretei pontban (72 dpi) vannak megadva.

## **Betűtípusokkal való munka**

**K: PPT PDF-re vagy képekre konvertálásakor miért különböznek a betűtípusok a kimeneti dokumentumokban?**

**A**: Ez a probléma arra utalhat, hogy a bemutatóban használt betűtípusok hiányoznak az operációs rendszertől, amelyen a kód futott. Telepítenie kell a betűtípusokat az operációs rendszerre, vagy betöltheti őket külső betűtípusként a [FontsLoader](https://reference.aspose.com/slides/hu/net/aspose.slides/fontsloader/) osztály segítségével, ahogyan az alább látható:
```cs
var folders = new string[] { "path_to_a_folder_with_fonts" };
FontsLoader.LoadExternalFonts(folders);
```