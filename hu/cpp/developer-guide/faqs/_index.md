---
title: GYIK
type: docs
weight: 340
url: /hu/cpp/faqs/
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
- C++
- Aspose.Slides
description: "Válaszok a Aspose.Slides for C++ GYIK-ra, amely lefedi a PowerPoint és OpenDocument támogatást, a telepítési útmutatót, a licencelést és a hibakeresést."
---
## **Áttekintés**

Ez a GYIK válaszokat ad a gyakran feltett kérdésekre az Aspose.Slides-szel kapcsolatban. Tárgyalja a támogatott fájlformátumokat, a nagy prezentációkkal dolgozás közbeni kivételek kezelését, a diák méretének módosítását, a diák előnézetét, a prezentációkból szöveg kinyerését, a táblázatos szegélyek formázását, képek elhelyezését, valamint a betűtípusokkal kapcsolatos problémák megoldását a prezentációk PDF‑re vagy képekre konvertálásakor.

## **Támogatott fájlformátumok**

**Q:** Milyen fájlformátumokat támogat az Aspose.Slides for C++?  

**A:** Az Aspose.Slides for C++ a [Támogatott fájlformátumok](/slides/hu/cpp/supported-file-formats/) oldalon leírt fájlformátumokat támogatja.

## **Kivételek**

**Q:** Egy nagy PPT fájl betöltésekor, amely képeket is tartalmaz, memóriahiány kivételt kapok. Van valamilyen korlátozás az Aspose.Slides‑nél a fájlméretre vonatkozóan?  

**A:** Nincs konkrét képlet a támogatott prezentációméret kiszámítására. Elég tárhelynek kell rendelkezésre állnia a teljes prezentációs struktúra és a képek memóriában való tárolásához. Általában a memóriában a képek több helyet foglalnak el, mint a merevlemezen, különösen, ha a képek további effektusokat tartalmaznak.

Általánosságban az Aspose.Slides for C++ könnyedén kezel körülbelül 300 MB körüli prezentációs fájlokat egy 4 GB RAM‑mal rendelkező szerveren.

## **Diákkal való munka**

**Q:** Meg tudom változtatni a diák méretét egy prezentációban?  

**A:** A [Presentation](https://reference.aspose.com/slides/hu/cpp/aspose.slides/presentation/) osztályban elérhető `get_SlideSize` metódussal határozhatja meg a diák méretét a prezentációban.

**Q:** Lehetséges-e, hogy egy prezentációban különböző méretű diák legyenek?  

**A:** Mivel a diák méretét a Microsoft PowerPoint dokumentumok szintjén határozzák meg, erre nincs lehetőség.

**Q:** Az Aspose.Slides for C++ támogatja-e a dia előnézetet mentés előtt?  

**A:** A prezentációs diák képekké renderelhetők, és ezeket a képeket felhasználhatja a diák előnézetéhez.

## **Szöveggel való munka**

**Q:** Lehetőség van a prezentáció összes szövegének kinyerésére?  

**A:** Az Aspose.Slides for C++ a `Aspose::Slides::Util` névtérben a [SlideUtil](https://reference.aspose.com/slides/hu/cpp/aspose.slides.util/slideutil/) osztályt biztosítja, amely különféle módszereket kínál a teljes szöveg kinyerésére a prezentációkból.

**Q:** Miért különböznek a bekezdésméretek Windows és Linux operációs rendszereken?  

**A:** A bekezdésméretek számítása a bekezdés szövegméretének meghatározásán alapul. A szövegméret a PowerPoint‑ban megadott betűtípus metrikáira támaszkodik. Ha a megadott betűtípus hiányzik, a legközelebbi betűtípusra cserélik, amelynek metrikái eltérnek az eredetitől. Ennek következtében a különböző rendszerekben eltérő eredményekkel járhat a bekezdésméret számítása, a telepített betűtípusok halmaza függvényében. Azonos eredmény eléréséhez telepíteni kell ugyanazokat a betűtípusokat a rendszereken, vagy futásidőben betölteni őket [külső betűtípusok](/slides/hu/cpp/custom-font/) formájában.

## **Formázás és képek**

**Q:** Hogyan állíthatom be egy táblázat szegélyének színét?  

**A:** Vagy az összes táblázatszegély színét, vagy csak a teljes táblázat körüli szegélyt módosíthatja. Az összes szegély módosításához használja az `get_CellFormat` metódust az [ICell](https://reference.aspose.com/slides/hu/cpp/aspose.slides/icell/) interfészből. A teljes táblázat szegélyéhez iteráljon a cellákon, és változtassa meg a külső szegélyek színét.

**Q:** Milyen mértékegységet használ az Aspose.Slides for C++ a képek elhelyezéséhez?  

**A:** A diákon lévő összes alakzat koordinátáit és méretét pontban (72 dpi) mérik.

## **Betűtípusok kezelése**

**Q:** PPT‑t PDF‑re vagy képekre konvertáláskor miért különböznek a betűtípusok a kimeneti dokumentumokban?  

**A:** Ez a probléma arra utalhat, hogy a prezentációban használt betűtípusok hiányoznak az operációs rendszerről, amelyen a kód fut. Telepíteni kell a betűtípusokat az operációs rendszerre, vagy külső betűtípusokként betölteni a [FontsLoader](https://reference.aspose.com/slides/hu/cpp/aspose.slides/fontsloader/) osztály segítségével, ahogyan az alább látható:
```cpp
auto folders = MakeObject<Array<String>>(1, "path_to_a_folder_with_fonts");
FontsLoader::LoadExternalFonts(folders);
```