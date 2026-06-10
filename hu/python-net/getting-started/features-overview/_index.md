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
- nyomtatás
- formázás
- PowerPoint
- OpenDocument
- prezentáció
- Python
- Aspose.Slides
description: "Fedezze fel az Aspose.Slides for Python via .NET-et: egy hatékony API, amely lehetővé teszi PowerPoint és OpenDocument prezentációk hatékony létrehozását, szerkesztését, automatizálását és konvertálását."
---
## **Támogatott platformok**
Az Aspose.Slides for Python via .NET a Windows x64 vagy x86, valamint a különféle Linux‑disztribúciók Python 3.5 vagy újabb verzióval telepítve támogatott. A cél‑Linux platformhoz további követelmények szükségesek:
- GCC‑6 futásidejű könyvtárak (vagy újabb)
- A .NET Core Runtime függőségei. Maga a .NET Core Runtime telepítése NEM szükséges
- Python 3.5‑3.7 esetén a `pymalloc` változatú Python‑t kell használni. A `--with-pymalloc` opció alapértelmezésben engedélyezett. Általában a `pymalloc` változatú Python‑t az `m` utótaggal jelölik a fájlnévben.
- `libpython` megosztott Python‑könyvtár. A `--enable-shared` opció alapértelmezésben le van tiltva, egyes Python‑disztribúciók nem tartalmazzák a `libpython` megosztott könyvtárat. Néhány Linux platformon a `libpython` telepíthető a csomagkezelővel, például: `sudo apt-get install libpython3.7`. Gyakori probléma, hogy a `libpython` könyvtár más helyen van telepítve, mint a rendszer alapértelmezett megosztott könyvtárak könyvtára. A problémát megoldhatja a Python‑fordítás során megadott alternatív könyvtárúthasználattal, vagy létrehozhat szimbolikus linket a `libpython` fájlra a rendszer szabványos megosztott könyvtárak helyén. Általában a `libpython` megosztott könyvtár fájlneve `libpythonX.Ym.so.1.0` Python 3.5‑3.7 esetén, vagy `libpythonX.Y.so.1.0` Python 3.8 vagy újabb esetén (például: `libpython3.7m.so.1.0`, `libpython3.9.so.1.0`).

Ha további platformok támogatására van szüksége, keresse a „testvértermékeket” – Aspose.Slides for .NET vagy Aspose.Slides for Java.

## **Fájlformátumok és konverziók**
Az Aspose.Slides for Python via .NET támogatja a legtöbb PowerPoint dokumentumformátumot, és lehetővé teszi azok exportálását a szervezetek által széles körben használt formátumokba. Tekintse meg az alábbi részleteket:

|**Funkció**|**Leírás**|
| :- | :- |
|[Microsoft PowerPoint (PPT)](/slides/hu/python-net/ppt-vs-pptx/)|Az Aspose.Slides for Python via .NET a leggyorsabb feldolgozást biztosít ennél a prezentációs dokumentumformátúrnál.|
|[PPT‑től PPTX‑ig konverzió](/slides/hu/python-net/convert-ppt-to-pptx/)|Az Aspose.Slides for Python via .NET támogatja a PPT‑ről PPTX‑re történő átalakítást.|
|[Portable Document Format (PDF)](/slides/hu/python-net/convert-powerpoint-ppt-and-pptx-to-pdf/)|Egyetlen metódussal exportálhatja az összes támogatott fájlformátumot Adobe Portable Document Format (PDF) dokumentumokká.|
|[XML Parser Specification (XPS)](https://docs.aspose.com/slides/hu/python-net/convert-powerpoint-to-xps/)|Egyetlen metódussal exportálhatja az összes támogatott fájlformátumot XML Parser Specification (XPS) dokumentumokká.|
|[Tagged Image File Format (TIFF)](/slides/hu/python-net/convert-powerpoint-to-tiff/)|Exportálhatja az összes támogatott prezentációs fájlformátumot Tagged Image File Format (TIFF) formátumba.|
|[PPTX‑tól HTML‑ig konverzió] (https://docs.aspose.com/slides/hu/python-net/convert-powerpoint-to-html/)|Az Aspose.Slides for Python via .NET támogatja a PresentationEx HTML formátumba történő konvertálását.|

## **Renderelés és nyomtatás**
Az Aspose.Slides for Python via .NET lehetővé teszi a diákat nagy pontossággal különféle grafikus formátumokba renderelni. Tekintse meg a részleteket:

|**Funkció**|**Leírás**|
| :- | :- |
|.NET támogatott képfájlformátumok|Az Aspose.Slides for Python via .NET segítségével a prezentációs diák és a diákon levő képek renderelhetők minden .NET‑támogatott grafikus formátumba, például TIFF, PNG, BMP, JPEG, GIF és metafájlok.|
|SVG formátum|Az Aspose.Slides for Python via .NET beépített metódusokat biztosít, amelyekkel a prezentációs diák exportálhatók Scalable Vector Graphics (SVG) formátumba.|
|Prezentáció nyomtatása|Az Aspose.Slides for Python via .NET legújabb verziói beépített nyomtatási metódusokat kínálnak különböző lehetőségekkel.|

## **Tartalmi funkciók**
Az Aspose.Slides for Python via .NET lehetővé teszi a prezentációk szinte minden elemének vagy tartalmának elérését, módosítását vagy létrehozását. Tekintse meg a részleteket:

|**Funkció**|**Leírás**|
| :- | :- |
|Mesterdiák|A mesterdiák meghatározzák a normál diák elrendezését. Az Aspose.Slides for Python via .NET segítségével elérheti és módosíthatja a prezentációk mesterdiáit.|
|Normál diák|Az Aspose.Slides for Python via .NET használatával új diák különböző típusait hozhatja létre; továbbá hozzáférhet és módosíthatja a már létező diákat a prezentációkban.|
|Diák klónozása / másolása|Az Aspose.Slides for Python via .NET beépített metódusai lehetővé teszik meglévő diák klónozását vagy másolását egy prezentáción belül. Másolt és klónozott diák használhatók egyik prezentációból a másikba. Mivel egy dia a mesterdiától örököl elrendezést, a beépített klónozási metódusok automatikusan másolják a mestert.|
|Dia‑szekciók kezelése|Metódusok a diák különböző szekciókba rendezéséhez egy prezentáción belül.|
|Helyőrzők és szöveghelyőrzők|Hozzáférhet a helyőrzőkhöz és szöveghelyőrzőkhöz egy diában. Emellett új diát hozhat létre szöveghelyőrzőkkel a megfelelő metódus segítségével.|
|Fejléc és lábléc|Az Aspose.Slides for Python via .NET megkönnyíti a fejléc/lábléc kezelését a diákon.|
|Megjegyzések a diákban|Az Aspose.Slides for Python via .NET lehetővé teszi a diákhoz kapcsolódó megjegyzések elérését, módosítását és új megjegyzések hozzáadását.|
|Alakzat keresése|Megtalálhat egy adott alakzatot egy diában a hozzá tartozó alternatív szöveg alapján.|
|Háttérképek|Az Aspose.Slides for Python via .NET segítségével a mester- vagy normál dia hátterével dolgozhat.|
|Szövegdobozok|Szövegdobozok létrehozhatók a semmiből, elérhetők a már létező dobozok, és módosítható a bennük lévő szöveg az eredeti formázás megtartásával.|
|Téglalap alakzatok|Téglalap alakzatokat hozhat létre vagy módosíthat a Aspose.Slides for Python via .NET‑el.|
|Vonalas alakzatok|Vonalas (poly line) alakzatok létrehozása vagy módosítása lehetséges.|
|Ellipszis alakzatok|Ellipszis alakzatok létrehozhatók vagy módosíthatók.|
|Csoportos alakzatok|Az Aspose.Slides for Python via .NET támogatja a csoportos alakzatokat.|
|Auto alakzatok|Az Aspose.Slides for Python via .NET támogatja az auto alakzatokat.|
|SmartArt|Az Aspose.Slides for Python via .NET támogatja a SmartArt alakzatokat a MS PowerPointban.|
|Diagramok|Az Aspose.Slides for Python via .NET támogatja a MSO diagramokat a PowerPointban.|
|Alakzatok sorosítása|Az Aspose.Slides for Python via .NET sokféle alakzatot támogat. Ha egy alakzat nincs natívan támogatva, egy sorosítási módszerrel exportálhatja azt egy meglévő diáról, majd később újra felhasználhatja igényei szerint.|
|Képkocka keretek|Képek kezelése képkocka keretekben az Aspose.Slides for Python via .NET‑el.|
|Hangkeretek|Hangfájlok hivatkozása vagy beágyazása hangkeretekbe a diákon.|
|Videokeretek|Videófájlok kezelése videokeretekben; az Aspose.Slides for Python via .NET támogatja a hivatkozott és beágyazott videókat is.|
|OLE keret|OLE objektumok kezelése OLE keretekben.|
|Táblázatok|Az Aspose.Slides for Python via .NET támogatja a táblázatokat a diákon.|
|ActiveX vezérlők|ActiveX vezérlők támogatása.|
|VBA makrók|VBA makrók kezelése a prezentációkban.|
|Szövegkeret|Bármely alakzat szövege elérhető a hozzá tartozó szövegkereten keresztül.|
|Szöveg beolvasása|Beépített beolvasási metódusokkal szöveget olvashat a prezentációból vagy diáról.|
|Animációk|Animációk alkalmazása alakzatokra.|
|Diavetítések|Az Aspose.Slides for Python via .NET támogatja a diavetítéseket és a diák közötti átmeneteket.|

## **Formázási funkciók**
Az Aspose.Slides for Python via .NET segítségével szövegeket és alakzatokat formázhat a diákon. Tekintse meg a részleteket:

|**Funkció**|**Leírás**|
| :- | :- |
|Szövegformázás|<p>Az Aspose.Slides for Python via .NET‑ben a szövegek a formához tartozó szövegkeretekben kezelhetők. Így a bekezdésekkel és szakaszokkal formázhatja a szöveget. A következő elemek formázhatók:</p><p>- Betűtípus</p><p>- Betűméret</p><p>- Betűszín</p><p>- Betűárnyalatok</p><p>- Bekezdésigazítás</p><p>- Bekezdés felsorolás</p><p>- Bekezdés orientáció</p>|
|Alakzatformázás|<p>Az Aspose.Slides for Python via .NET‑ben a dia alapeleme a forma. A következő tulajdonságok formázhatók:</p><p>- Pozíció</p><p>- Méret</p><p>- Vonal</p><p>- Kitöltés (minta, színátmenet, egyszínű)</p><p>- Szöveg</p><p>- Kép</p>|

## **GYIK**

**Szükséges-e a Microsoft PowerPoint telepítése a szerveren/PC‑n, hogy a könyvtár működjön?**

Nem. A PowerPoint nem szükséges; az Aspose.Slides egy önálló motor a prezentációk létrehozásához, szerkesztéséhez, konvertálásához és rendereléséhez.

**Hogyan működik a többszálúság? Párhuzamosítható-e a feldolgozás?**

Biztonságos különböző dokumentumok feldolgozása külön szálakon; ugyanazt a [prezentáció](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentation/) objektumot nem szabad [több szál](/slides/hu/python-net/multithreading/) egyszerre használni.

**Támogatottak-e a fájljelszavak és a titkosítás?**

Igen. [Megnyithat](/slides/hu/python-net/password-protected-presentation/) titkosított prezentációkat, beállíthat vagy eltávolíthat nyitási és írási jelszót, valamint ellenőrizheti a védelmi állapotot.

**Fontcsomagokra kell gondolni Linux konténerekben?**

Igen. Ajánlott a gyakori fontcsomagok telepítése és/vagy a [font könyvtárak explicite megadása](/slides/hu/python-net/custom-font/) az alkalmazásban a váratlan helyettesítések elkerülése érdekében.

**Vannak korlátozások az értékelő verzióban?**

Az [értékelő módban](/slides/hu/python-net/licensing/) egy vízjel kerül a kimenetre, és bizonyos korlátozások érvényesek; egy [30 napos ideiglenes licenc](https://purchase.aspose.com/temporary-license/) elérhető a teljes funkcionalitás teszteléséhez.

**Támogatott-e külső formátumok importálása egy prezentációba (PDF/HTML → PPTX)?**

Igen. [PDF oldalak és HTML tartalom](/slides/hu/python-net/import-presentation/) hozzáadhatók egy prezentációhoz, ezzel diák lesznek.