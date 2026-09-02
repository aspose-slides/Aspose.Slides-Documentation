---
title: Funkciók áttekintése
type: docs
weight: 20
url: /hu/python-net/features-overview/
keywords:
- funkciók
- támogatott platformok
- fájlformátum
- konverzió
- renderelés
- formázás
- PowerPoint
- OpenDocument
- prezentáció
- Python
- Aspose.Slides
description: "Fedezze fel az Aspose.Slides for Python via .NET-et: egy erőteljes API a PowerPoint és OpenDocument prezentációk hatékony létrehozásához, szerkesztéséhez, automatizálásához és konvertálásához."
---
## **Támogatott platformok**
Az Aspose.Slides for Python via .NET platformok Windows x64 vagy x86, valamint a Python 3.5 vagy újabb verziója telepítve lévő számos Linux‑disztribúció esetén használhatók. A cél Linux platformhoz további követelmények vannak:
- GCC‑6 futtatókörnyezet‑könyvtárak (vagy újabb)
- A .NET Core Runtime függőségei. A .NET Core Runtime telepítése NEM szükséges
- Python 3.5‑3.7 esetén: A `pymalloc`‑tal készült Python szükséges. A `--with-pymalloc` Python build opció alapértelmezés szerint engedélyezett. Általában a `pymalloc`‑tal készült Python a fájlnévben `m` végződéssel van jelölve.
- `libpython` megosztott Python könyvtár. A `--enable-shared` Python build opció alapértelmezés szerint ki van kapcsolva, egyes Python disztribúciók nem tartalmazzák a `libpython` megosztott könyvtárat. Néhány Linux platformon a `libpython` megosztott könyvtár telepíthető a csomagkezelővel, például: `sudo apt-get install libpython3.7`. A gyakori probléma, hogy a `libpython` könyvtár más helyen van telepítve, mint a rendszer alapértelmezett megosztott könyvtárainak helye. A problémát megoldhatja, ha a Python build opciókkal alternatív könyvtárúthoz állítja be a könyvtárat a Python fordításakor, vagy szimbolikus linket hoz létre a `libpython` könyvtárfájlra a rendszer standard megosztott könyvtárak helyén. Általában a `libpython` megosztott könyvtár fájlneve `libpythonX.Ym.so.1.0` a Python 3.5‑3.7 esetén, vagy `libpythonX.Y.so.1.0` a Python 3.8 vagy újabb esetén (például: `libpython3.7m.so.1.0`, `libpython3.9.so.1.0`).

Ha további platformok támogatására van szükség, keresse a „testvér” termékeket: Aspose.Slides for .NET vagy Aspose.Slides for Java.

## **Fájlformátumok és konverziók**
Aspose.Slides for Python via .NET a legtöbb PowerPoint dokumentumformátumot támogatja. Lehetővé teszi ezen formátumok exportálását a szervezetek által széles körben használt és cserélt népszerű formátumokba is. Tekintse meg a részleteket:

|**Funkció**|**Leírás**|
| :- | :- |
|[Microsoft PowerPoint (PPT)](/slides/hu/python-net/ppt-vs-pptx/)|Az Aspose.Slides for Python via .NET a leggyorsabb feldolgozást biztosít ehhez a prezentációs dokumentumformátumhoz.|
|[PPT to PPTX conversion](/slides/hu/python-net/convert-ppt-to-pptx/)|Az Aspose.Slides for Python via .NET támogatja a PPT‑ról PPTX‑re konvertálást.|
|[Portable Document Format (PDF)](/slides/hu/python-net/convert-powerpoint-ppt-and-pptx-to-pdf/)|Egyetlen metódussal exportálhatja az összes támogatott fájlformátumot az Adobe Portable Document Format (PDF) dokumentumokba.|
|[XML Parser Specification (XPS)](https://docs.aspose.com/slides/hu/python-net/convert-powerpoint-to-xps/)|Egyetlen metódussal exportálhatja az összes támogatott fájlformátumot az XML Parser Specification (XPS) dokumentumokba.|
|[Tagged Image File Format (TIFF)](/slides/hu/python-net/convert-powerpoint-to-tiff/)|Exportálhatja az összes támogatott prezentációs fájlformátumot Tagged Image File Format (TIFF) formátumba.|
|[PPTX To HTML Conversion](https://docs.aspose.com/slides/hu/python-net/convert-powerpoint-to-html/)|Az Aspose.Slides for Python via .NET támogatja a PresentationEx HTML‑re konvertálását.|

## **Prezentáció renderelése**
Aspose.Slides for Python via .NET támogatja a diák magas hűségű renderelését a prezentációs dokumentumokban különböző grafikus formátumokba. Tekintse meg a részleteket:

|**Funkció**|**Leírás**|
| :- | :- |
|.NET Supported Image Formats|Az Aspose.Slides for Python via .NET‑el mindegyik, a .NET által támogatott grafikus formátumba renderelheti a prezentációs diákot és a diákon lévő képeket, például TIFF, PNG, BMP, JPEG, GIF és metafájlok.|
|SVG Format|Az Aspose.Slides for Python via .NET beépített metódusokat is biztosít, amelyekkel a prezentációs diákot Scalable Vector Graphics (SVG) formátumba exportálhatja.|

## **Tartalmi funkciók**
Aspose.Slides for Python via .NET lehetővé teszi, hogy a prezentációs dokumentumok szinte minden eleméhez hozzáférjen, módosítsa vagy létrehozza azt. Tekintse meg a részleteket:

|**Funkció**|**Leírás**|
| :- | :- |
|Mester dia|A mester diák határozzák meg a normál diák elrendezését. Az Aspose.Slides for Python via .NET lehetővé teszi a mester diák hozzáférését és módosítását a prezentációs dokumentumokban.|
|Normál dia|Az Aspose.Slides for Python via .NET‑el új, különböző típusú diák létrehozhatók; a meglévő diákhoz is hozzáférhet és módosíthatja őket a prezentációkban.|
|Diák klónozása / másolása|Az Aspose.Slides for Python via .NET beépített metódusai lehetővé teszik egy meglévő dia klónozását vagy másolását egy prezentáción belül. Másolt és klónozott diák használhatók egy prezentációból a másikba is. Mivel egy dia az elrendezést a mester diáktól örökli, a beépített klónozási metódusok automatikusan átmásolják a mestert klónozáskor.|
|Diaké szakaszok kezelése|Metódusok a diák különböző szakaszokba szervezéséhez egy prezentáción belül.|
|Helyőrzők és szöveghelyőrzők|Hozzáférhet a helyőrzőkhöz és szöveghelyőrzőkhöz egy dián. Ezen felül létrehozhat egy diát szöveghelyőrzőkkel teljesen a nulláról a megfelelő metódus használatával.|
|Fejléc és lábléc|Az Aspose.Slides for Python via .NET megkönnyíti a fejlécek/lábfejek kezelését a diákon.|
|Megjegyzések a diákon|Az Aspose.Slides for Python via .NET‑el hozzáférhet és módosíthatja egy dia megjegyzéseit, valamint új megjegyzéseket is hozzáadhat.|
|Alakzat keresése|Egy adott alakzatot a hozzá tartozó alternatív szöveg alapján is megtalálhatja egy dián.|
|Háttér|Az Aspose.Slides for Python via .NET lehetővé teszi a háttérrel való munkát, amely egy mester vagy normál dia része a prezentációban.|
|Szövegdobozok|Szövegdobozok hozhatók létre a semmiből. Létező szövegdobozokhoz is hozzáférhet. A szövegeket módosíthatja anélkül, hogy az eredeti formázás elveszne.|
|Téglalap alakzatok|Téglalap alakzatok létrehozhatók vagy módosíthatók az Aspose.Slides for Python via .NET‑el.|
|Polivonalak|Polivonalak létrehozhatók vagy módosíthatók az Aspose.Slides for Python via .NET‑el.|
|Ellipszis alakzatok|Ellipszis alakzatok létrehozhatók vagy módosíthatók az Aspose.Slides for Python via .NET‑el.|
|Csoport alakzatok|Az Aspose.Slides for Python via .NET támogatja a csoportosított alakzatokat.|
|Automatikus alakzatok|Az Aspose.Slides for Python via .NET támogatja az automatikus alakzatokat.|
|SmartArt|Az Aspose.Slides for Python via .NET támogatja a SmartArt alakzatokat az MS PowerPointben.|
|Diagramok|Az Aspose.Slides for Python via .NET támogatja az MSO diagramokat a PowerPointben.|
|Alakzatok sorosítása|Az Aspose.Slides for Python via .NET sok alakzatot támogat. Ha egy alakzat nincs támogatva, egy sorosítási módszerrel az adott alakzatot egy meglévő diáról sorosíthatja, így a továbbiakban igényei szerint felhasználható.|
|Képkockák|Képek kezelhetők képkockákban az Aspose.Slides for Python via .NET‑el.|
|Hangkeretek|Hangfájlok hivatkozhatók vagy beágyazhatók hangkeretekbe a diákon az Aspose.Slides for Python via .NET‑el.|
|Videokeretek|Videofájlok kezelhetők videokeretekben. Az Aspose.Slides for Python via .NET támogatja a hivatkozott és beágyazott videókat is.|
|OLE keret|OLE objektumok kezelhetők OLE keretekben az Aspose.Slides for Python via .NET‑el.|
|Táblázatok|Az Aspose.Slides for Python via .NET táblázatokat támogat a diákon.|
|ActiveX vezérlők|ActiveX vezérlők támogatása.|
|VBA makrók|VBA makrók kezelése a prezentációkban.|
|Szövegkeret|Bármely alakzathoz tartozó szöveghez hozzáférhet a szövegkeret segítségével.|
|Szöveg beolvasása|A prezentáció vagy dia szintjén beolvashatja a szöveget beépített beolvasási metódusokkal.|
|Animációk|Animációk alkalmazhatók alakzatokra.|
|Diavetítések|Az Aspose.Slides for Python via .NET támogatja a diavetítéseket és diaátmeneteket.|

## **Formázási funkciók**
Az Aspose.Slides for Python via .NET‑el formázhatja a szövegeket és alakzatokat a prezentációs diákon. Tekintse meg a részleteket:

|**Funkció**|**Leírás**|
| :- | :- |
|Text Formatting|<p>Az Aspose.Slides for Python via .NET‑ben a szövegeket a alakzatokhoz tartozó szövegkereteken keresztül kezelheti. Így a szövegeket a szövegkeretekhez tartozó bekezdések és részletek segítségével formázhatja. Ezeket a szövegelemeket az Aspose.Slides for Python via .NET segítségével formázhatja.</p><p>- Betűtípus</p><p>- Betűméret</p><p>- Betűszín</p><p>- Betűárnyalatok</p><p>- Bekezdés igazítása</p><p>- Bekezdés felsorolása</p><p>- Bekezdés tájolása</p>|
|Shape Formatting|<p>Az Aspose.Slides for Python via .NET‑ben a dia alapvető eleme egy alakzat. Ezeket az alakzat elemeket az Aspose.Slides for Python via .NET segítségével formázhatja:</p><p>- Pozíció</p><p>- Méret</p><p>- Vonal</p><p>- Kitöltés (beleértve a mintát, gradientet, szilárdot)</p><p>- Szöveg</p><p>- Kép</p>|

## **FAQ**

### Szükséges-e a Microsoft PowerPoint telepítése a szerveren/PC‑n a könyvtár működéséhez?

Nem. A PowerPoint nem szükséges; az Aspose.Slides egy önálló motor a prezentációk létrehozásához, szerkesztéséhez, konvertálásához és rendereléséhez.

### Hogyan működik a több szálas feldolgozás? Párhuzamosítható a feldolgozás?

Biztonságosan feldolgozhat különböző dokumentumokat külön szálakon; ugyanazt a [presentation](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentation/) objektumot nem szabad [multiple threads](/slides/hu/python-net/multithreading/) egyidejűleg használni.

### Támogatottak-e a fájljelszavak és a titkosítás?

Igen. [You can](/slides/hu/python-net/password-protected-presentation/) megnyithat titkosított prezentációkat, beállíthat vagy eltávolíthat nyitási és írási jelszót, és ellenőrizheti a védelem állapotát.

### Kell-e foglalkozni a betűcsomagokkal Linux konténerekben?

Igen. Ajánlott a gyakori betűcsomagok telepítése és/vagy a [specify font directories](/slides/hu/python-net/custom-font/) kifejezett megadása az alkalmazásban a váratlan helyettesítések elkerülése érdekében.

### Vannak-e korlátozások az értékelő verzióban?

Az [evaluation mode](/slides/hu/python-net/licensing/) esetén egy vízjel kerül a kimenetre, és bizonyos korlátozások érvényesek; egy [30‑day temporary license](https://purchase.aspose.com/temporary-license/) elérhető a teljes funkcionalitású teszteléshez.

### Támogatott-e külső formátumok importálása egy prezentációba (PDF/HTML → PPTX)?

Igen. PDF‑oldalakat és HTML‑tartalmat [PDF pages and HTML content](/slides/hu/python-net/import-presentation/) adhat egy prezentációhoz, amelyet diákra konvertál.