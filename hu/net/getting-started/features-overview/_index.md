---
title: Funkciók áttekintése
type: docs
weight: 94
url: /hu/net/features-overview/
keywords:
- funkciók
- támogatott platformok
- fájlformátumok
- konverzió
- renderelés
- prezentációs tartalom
- PowerPoint
- OpenDocument
- prezentáció
- .NET
- C#
- Aspose.Slides
description: "Tekintse át, hogy az Aspose.Slides for .NET milyen területeket fed le, mielőtt értékelné: támogatott platformok, fájlformátumok, dia renderelés, valamint a létrehozható és szerkeszthető tartalom."
---
## **Áttekintés**

Aspose.Slides for .NET egy osztálykönyvtár PowerPoint és OpenDocument prezentációk létrehozásához, olvasásához, szerkesztéséhez, átalakításához és rendereléséhez. Nem rendelkezik saját felhasználói felülettel, és nem igényel Microsoft PowerPointot vagy Office-ot, így konzolos alkalmazásokban, asztali alkalmazásokban, például Windows Forms-ban, webalkalmazásokban és webszolgáltatásokban is használható. Ez a cikk összefoglalja, hogy a könyvtár mit fed le, és hivatkozásokat tartalmaz az egyes területeket leíró cikkekre.

## **Támogatott platformok**

Az Aspose.Slides for .NET két NuGet csomagként van terjesztve, ugyanazzal az API-val:

|**Csomag**|**A csomagban lévő build-ek**|**Operációs rendszerek**|
| :- | :- | :- |
|[Aspose.Slides.NET](https://www.nuget.org/packages/Aspose.Slides.NET/)|.NET Framework 4.6.2, .NET Standard 2.0 és .NET 6. Használható .NET Framework 4.6.2 vagy újabb, illetve .NET 6 vagy újabb verzióval.|Windows. Linux és macOS a `libgdiplus` könyvtárral és a `System.Drawing.EnableUnixSupport` kapcsolóval.|
|[Aspose.Slides.NET6.CrossPlatform](https://www.nuget.org/packages/Aspose.Slides.NET6.CrossPlatform/)|.NET 6. Használható .NET 6 vagy újabb verzióval.|Windows (x86, x64), Linux (x64 glibc 2.23 vagy újabb, ARM64 glibc 2.39 vagy újabb), és macOS (x64, ARM64).|

[Telepítés](/slides/hu/net/installation/) leírja, melyik csomagot válassza, és hogy egyes csomagoknak mi szükséges Linuxon. [System Requirements](/slides/hu/net/system-requirements/) részletesen felsorolja a támogatott platformokat.

## **Fájlformátumok és konverziók**

Aspose.Slides megnyitja és menti a PPT, PPTX, PPS, POT, PPSX, POTX, PPTM, PPSM, POTM, ODP, OTP, FODP és PowerPoint XML prezentációkat. PDF és HTML tartalmakat importál diákba, és prezentációkat ment PDF, XPS, HTML, HTML5, TIFF, animált GIF, SWF, Markdown és XAML formátumban. [Supported File Formats](/slides/hu/net/supported-file-formats/) felsorolja az összes formátumot a megfelelő olvasó és író API-val.

|**Jellemző**|**Leírás**|
| :- | :- |
|[PPT és PPTX](/slides/hu/net/ppt-vs-pptx/)|Olvas és írja mind a bináris PowerPoint 97-2003 formátumot, mind az Office Open XML formátumot.|
|[PPT to PPTX átalakítás](/slides/hu/net/convert-ppt-to-pptx/)|Átalakítja a régi PPT prezentációkat PPTX formátumba.|
|[Portable Document Format (PDF)](/slides/hu/net/convert-powerpoint-to-pdf/)|Exportálja a prezentációkat PDF-be, beleértve a PDF/A és PDF/UA dokumentumokat.|
|[XML Paper Specification (XPS)](/slides/hu/net/convert-powerpoint-to-xps/)|Exportálja a prezentációkat XPS dokumentumokként.|
|[Tagged Image File Format (TIFF)](/slides/hu/net/convert-powerpoint-to-tiff/)|Exportálja a prezentációkat TIFF képekként.|
|[HTML](/slides/hu/net/convert-powerpoint-to-html/)|Exportálja a prezentációkat HTML és HTML5 formátumba.|
|[PDF és HTML import](/slides/hu/net/import-presentation/)|Diákat hoz létre PDF oldalakról és HTML tartalmakból.|

## **Prezentáció renderelése**

Az Aspose.Slides diák és egyedi alakzatok renderelését PNG, JPEG, BMP, GIF, TIFF és SVG képek formájában, valamint diák EMF metafájlokként végzi. Lásd a [Prezentációs diák átalakítása képekké](/slides/hu/net/convert-slide/), [Dia renderelése SVG képként](/slides/hu/net/render-a-slide-as-an-svg-image/) és [Alakzat bélyegképek létrehozása](/slides/hu/net/create-shape-thumbnails/) cikkeket.

## **Tartalmi funkciók**

Az Aspose.Slides lehetővé teszi, hogy szinte minden tartalmat létrehozzon, olvasson és módosítson egy prezentációban:

|**Terület**|**Mit tehet**|
| :- | :- |
|[Diák](/slides/hu/net/presentation-slide/)|Dia hozzáadása, klónozása, átrendezése és eltávolítása; elrendezések és masterek alkalmazása; diák szervezése szekciókba; a dia méretének módosítása.|
|[Tervezés](/slides/hu/net/presentation-design/)|Háttér, témaszínek, fejléc és lábléc, valamint betűtípusok beállítása.|
|[Szöveg](/slides/hu/net/manage-text/)|Szövegkeretek, bekezdések és szakaszok létrehozása és szerkesztése; betűtípusok, színek, jelöltek és igazítás beállítása; szöveg keresése és cseréje.|
|[Alakzatok](/slides/hu/net/powerpoint-shapes/)|AutoShape-ek, vonalak, csatlakozók, csoportos alakzatok és képkockák létrehozása; pozíció, méret, vonal és egységes, gradient vagy minta kitöltés beállítása; alakzat keresése alternatív szöveg alapján.|
|[Táblázatok](/slides/hu/net/powerpoint-table/), [diagramok](/slides/hu/net/powerpoint-charts/), és [SmartArt](/slides/hu/net/powerpoint-smartart/)|Táblázatok, Microsoft Office diagramok és SmartArt diagramok létrehozása és szerkesztése.|
|[Média](/slides/hu/net/manage-media-files/), [OLE objektumok](/slides/hu/net/manage-ole/), és [ActiveX vezérlők](/slides/hu/net/activex/)|Beágyazott vagy hivatkozott audio és video keretek hozzáadása, OLE objektumok beágyazása, valamint ActiveX vezérlők hozzáadása, módosítása vagy eltávolítása.|
|[Jegyzetek](/slides/hu/net/presentation-notes/) és [megjegyzések](/slides/hu/net/presentation-comments/)|Előadói jegyzetek és felülvizsgálati megjegyzések hozzáadása, olvasása és szerkesztése.|
|[Animáció](/slides/hu/net/powerpoint-animation/) és [átmenetek](/slides/hu/net/slide-transition/)|Animációs hatások alkalmazása az alakzatokra, diaátmenetek beállítása, valamint a diavetítés beállításainak konfigurálása.|
|[Biztonság](/slides/hu/net/presentation-security/)|Prezentációk titkosítása jelszóval, írásvédelem beállítása, valamint digitális aláírások kezelése.|
|[VBA makrók](/slides/hu/net/presentation-via-vba/)|VBA modulok hozzáadása, kinyerése és eltávolítása makróval ellátott prezentációkban.|
|[Tulajdonságok](/slides/hu/net/presentation-properties/)|Dokumentum tulajdonságok olvasása és szerkesztése.|

## **GYIK**

**Szükséges-e a Microsoft PowerPoint telepítése a szerveren vagy PC-n a könyvtár működéséhez?**

Nem. A PowerPoint nem szükséges; az Aspose.Slides egy önálló motor a prezentációk létrehozásához, szerkesztéséhez, konvertálásához és rendereléséhez.

**Hogyan működik a több szálas feldolgozás? Párhuzamosítható a feldolgozás?**

Biztonságos különböző dokumentumok feldolgozása külön szálakon; ugyanazt a [Presentation](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation/) objektumot nem szabad [több szál](/slides/hu/net/multithreading/) egyidejűleg használni.

**Támogatottak-e a fájl jelszavak és a titkosítás?**

Igen. [Megnyithat](/slides/hu/net/password-protected-presentation/) titkosított prezentációkat, beállíthat vagy eltávolíthat megnyitási és írási jelszót, valamint ellenőrizheti a védelem állapotát.

**Fontokkal kapcsolatban kell aggódnom Linux konténerekben?**

Igen. A prezentációkban használt betűtípusokat, vagy megfelelő helyettesítőket, telepíteni kell a rendszerre, hogy a szöveg helyesen jelenjen meg. A [font könyvtárak megadása](/slides/hu/net/custom-font/) is lehetséges az alkalmazásban. A [Telepítés](/slides/hu/net/installation/) felsorolja az egyes csomagok Linux előkövetelményeit.

**Vannak korlátozások az értékelő verzióban?**

Igen. [licenc](/slides/hu/net/licensing/) hiányában az Aspose.Slides minden mentett diára egy értékelő vízjelet helyez, és levágja a prezentációkból olvasott szöveget. Egy [30 napos ideiglenes licenc](https://purchase.aspose.com/temporary-license/) elérhető a teljes funkcionalitás teszteléséhez.

**Támogatott-e külső formátumok importálása egy prezentációba (PDF vagy HTML PPTX-be)?**

Igen. [PDF oldalakat és HTML tartalmat](/slides/hu/net/import-presentation/) adhat hozzá egy prezentációhoz, amelyeket diákká alakít.