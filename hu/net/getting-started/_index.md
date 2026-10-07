---
title: Kezdő lépések
type: docs
weight: 10
url: /hu/net/getting-started/
keywords:
- kezdés
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
description: "Az út egy új .NET projektből az első mentett prezentációig az Aspose.Slides segítségével: ellenőrizze a követelményeket, telepítse a csomagot, futtassa az első programot, és folytassa a gyakori feladatokkal."
---
## **Áttekintés**

Végig kell járnia az alábbi négy lépést sorrendben. Minden lépés megnevezi, mit kell tenni, és a részleteket tartalmazó cikkre mutat. Az értékelés, licencelés és támogatás a lépések után következik.

## **1. lépés: Rendszerkövetelmények ellenőrzése**

Az [Aspose.Slides for .NET](https://products.aspose.com/slides/net/) Windows, Linux és macOS rendszereken fut. A [Rendszerkövetelmények](/slides/hu/net/system-requirements/) felsorolja az operációs rendszereket és .NET verziókat, amelyeket az egyes csomagok támogatnak, valamint a Linuxhoz szükséges további könyvtárakat.

## **2. lépés: Csomag telepítése**

Az Aspose.Slides for .NET a NuGet-en keresztül érhető el két csomagként, amelyek ugyanazokat az osztályokat tartalmazzák. Adjon hozzá egyet a projektjéhez:

- Windows rendszeren: `dotnet add package Aspose.Slides.NET`
- Linux és macOS rendszeren: `dotnet add package Aspose.Slides.NET6.CrossPlatform`. Linuxon először telepítse a `fontconfig` könyvtárat.
- Alpine Linuxon, valamint olyan Linux rendszereken, ahol a glibc régebbi, mint 2.23 (x64) vagy 2.39 (ARM64): Aspose.Slides.NET, a `libgdiplus` könyvtár telepítésével.

[Telepítés](/slides/hu/net/installation/) leírja a Linux parancsokat, az extra indítási beállítást, amelyre az Aspose.Slides.NET-nek Linuxon szüksége van, és a Visual Studio lépéseit.

## **3. lépés: Hozza létre az első prezentációját**

A [gyors kezdés az Aspose.Slides for .NET kezdőlapon](/slides/hu/net/#your-first-presentation) egy teljes konzolos program: szövegdobozt ad egy diára, és PPTX fájlként menti a prezentációt. A [Prezentációk létrehozása](/slides/hu/net/create-presentation/) részletesebben ismerteti a lépéseket, és bemutatja, hogyan nyisson meg egy meglévő prezentációt, és mentse más formátumba.

## **4. lépés: Folytassa a gyakori feladatokkal**

- [Prezentáció megnyitása](/slides/hu/net/open-presentation/)
- [Prezentáció mentése](/slides/hu/net/save-presentation/)
- [Prezentáció PDF-be konvertálása](/slides/hu/net/convert-powerpoint-to-pdf/)
- [Diák képként renderelése](/slides/hu/net/convert-slide/)
- [Prezentáció szövegének szerkesztése](/slides/hu/net/manage-text/)
- [Példák diakelemekre](/slides/hu/net/examples/)

## **Értékelés és licencelés**

Licenc nélkül az Aspose.Slides értékelő módban fut: minden mentett diára vízjelet helyez, és a prezentációkból beolvasott szöveget csonkolja.

- [Az Aspose.Slides értékelése](/slides/hu/net/evaluate-aspose-slides/) leírja az értékelési korlátozásokat és azt, hogyan kérhet ideiglenes licencet.
- [Licencelés](/slides/hu/net/licensing/) bemutatja, hogyan alkalmazzon licencet fájlból, adatfolyamból vagy beágyazott erőforrásból.
- [Mérték alapú licencelés](/slides/hu/net/metered-licensing/) a használat alapján számlázott licencelést tárgyalja.
- [Támogatott fájlformátumok](/slides/hu/net/supported-file-formats/) felsorolja azokat a formátumokat, amelyeket az Aspose.Slides be tud tölteni és menteni.

## **Segítség kérése**

[Terméktámogatás](/slides/hu/net/product-support/) leírja, hogyan tehet fel kérdést az [ingyenes támogatási fórumon](https://forum.aspose.com/c/slides/11) és mit kell a jelentésben szerepeltetni.

## **GYIK**

**Szükség van Microsoft PowerPoint telepítésére?**

Nem. Az Aspose.Slides saját maga olvassa és írja a prezentációs fájlokat, nem használ PowerPointot, így szervereken és Linuxon is fut.

**Melyik csomagot használjam .NET Framework alkalmazáshoz?**

Aspose.Slides.NET. Tartalmaz összeállításokat a .NET Framework 4.6.2-től felfelé, a .NET 6-tól felfelé és a .NET Standard 2.0-hoz. Az Aspose.Slides.NET6.CrossPlatform .NET 6 vagy újabb verziót igényel.