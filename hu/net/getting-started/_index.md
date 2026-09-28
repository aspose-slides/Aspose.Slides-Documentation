---
title: Elindulás
type: docs
weight: 10
url: /hu/net/getting-started/
keywords:
- elindulás
- rendszerkövetelmények
- telepítés
- első prezentáció
- NuGet
- PPT feldolgozás
- PPTX feldolgozás
- ODP feldolgozás
- PowerPoint
- OpenDocument
- prezentáció
- .NET
- C#
- Aspose.Slides
description: "Az út egy új .NET projektből az első, Aspose.Slides‑el elmentett prezentációig: ellenőrizd a követelményeket, telepítsd a csomagot, futtasd az első programot, és folytasd a gyakori feladatokkal."
---
## **Áttekintés**

Végig kell járni az alábbi négy lépést sorrendben. Minden lépés megnevezi, mit kell tenni, és linket biztosít a részletekkel. Az értékelésről, licencelésről és támogatásról a lépések után olvashatsz.

## **1. lépés: A rendszerkövetelmények ellenőrzése**

Aspose.Slides for .NET Windows, Linux és macOS rendszereken fut. [Rendszerkövetelmények](/slides/hu/net/system-requirements/) felsorolja az operációs rendszereket és a .NET verziókat, amelyeket az egyes csomagok támogatnak, valamint a Linux számára szükséges további könyvtárakat.

## **2. lépés: A csomag telepítése**

Aspose.Slides for .NET két NuGet csomagként érhető el, amelyek ugyanazokat a osztályokat biztosítják. Add hozzá valamelyik csomagot a projektedhez:

- Windows rendszeren: `dotnet add package Aspose.Slides.NET`
- Linux és macOS rendszeren: `dotnet add package Aspose.Slides.NET6.CrossPlatform`. Linuxon előbb telepíteni kell a `fontconfig` könyvtárat.
- Alpine Linuxon, valamint olyan Linux rendszereken, ahol a glibc régebbi, mint 2.23 (x64) vagy 2.39 (ARM64): Aspose.Slides.NET, a `libgdiplus` könyvtárral együtt.

[Telepítés](/slides/hu/net/installation/) tartalmazza a Linux parancsokat, a további indítási beállítást, amelyre az Aspose.Slides.NET Linuxon szükség van, és a Visual Studio lépéseit.

## **3. lépés: Az első prezentáció létrehozása**

A [gyors kezdő útmutató az Aspose.Slides for .NET kezdőoldalán](/slides/hu/net/#your-first-presentation) egy teljes konzolos program: szövegdobozt ad egy diára, majd PPTX fájlként menti a prezentációt. A [Prezentációk létrehozása](/slides/hu/net/create-presentation/) részletesebben magyarázza ugyanazokat a lépéseket, és bemutatja, hogyan nyiss meg egy meglévő prezentációt, valamint hogyan mentsd el más formátumban.

## **4. lépés: További gyakori feladatok**

- [Prezentáció megnyitása](/slides/hu/net/open-presentation/)
- [Prezentáció mentése](/slides/hu/net/save-presentation/)
- [Prezentáció PDF-be konvertálása](/slides/hu/net/convert-powerpoint-to-pdf/)
- [Diák képként történő renderelése](/slides/hu/net/convert-slide/)
- [Prezentáció szövegének szerkesztése](/slides/hu/net/manage-text/)
- [Példák diák elemei szerint](/slides/hu/net/examples/)

## **Értékelés és licenc**

Licenc nélkül az Aspose.Slides értékelési módban fut: minden mentett diára vízjelet tesz, és a prezentációkból beolvasott szöveget csonkolja.

- [Az Aspose.Slides kiértékelése](/slides/hu/net/evaluate-aspose-slides/) leírja az értékelési korlátozásokat és a ideiglenes licenc kérésének módját.
- [Licencelés](/slides/hu/net/licensing/) bemutatja, hogyan alkalmazz licencet fájlból, stream-ből vagy beágyazott erőforrásból.
- [Mérő licenc](/slides/hu/net/metered-licensing/) a felhasználás alapú licencelést tárgyalja.
- [Támogatott fájlformátumok](/slides/hu/net/supported-file-formats/) felsorolja az Aspose.Slides által betölthető és menthető formátumokat.

## **Segítség kérés**

[Terméktámogatás](/slides/hu/net/product-support/) elmagyarázza, hogyan tegyél fel kérdést az [ingyenes támogatási fórumban](https://forum.aspose.com/c/slides/11), és mit kell mellékelned, ha problémát jelentesz be.

## **GYIK**

**Szükségem van a Microsoft PowerPoint telepítésére?**

Nem. Az Aspose.Slides saját maga olvassa és írja a prezentációs fájlokat, nem használ PowerPointot, így szervereken és Linuxon is futtatható.

**Melyik csomagot kellene használnom egy .NET Framework alkalmazáshoz?**

Aspose.Slides.NET. Tartalmaz build-eket a .NET Framework 4.6.2 és újabb, a .NET 6 és újabb, valamint a .NET Standard 2.0 számára. Az Aspose.Slides.NET6.CrossPlatform .NET 6 vagy újabb verziót igényel.