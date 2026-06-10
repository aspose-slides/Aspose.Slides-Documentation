---
title: Hogyan futtassuk a példákat
type: docs
weight: 130
url: /hu/net/how-to-run-examples/
keywords:
- példák
- szoftverkövetelmények
- NuGet
- GitHub
- PowerPoint
- OpenDocument
- prezentáció
- .NET
- C#
- Aspose.Slides
description: "Futtassa az Aspose.Slides for .NET példákat gyorsan: klónozza a repót, állítsa vissza a csomagokat, majd építse és tesztelje a PPT, PPTX és ODP funkciókat."
---
## **Szoftverkövetelmények**
Mielőtt letöltené és futtatná a példákat, ellenőrizze és erősítse meg, hogy a környezet megfelel-e ezeknek a követelményeknek: 

- Visual Studio 2010 vagy újabb.
- A NuGet Package Manager telepítve van a Visual Studio-ban. Ellenőrizze, hogy a legújabb NuGet API verzió telepítve van-e a Visual Studio-ban. 

A NuGet csomagkezelő telepítésével kapcsolatos útmutatóért látogassa meg ezt az oldalt: https://docs.microsoft.com/en-us/nuget/install-nuget-client-tools

1. Navigáljon a **Tools** > **Options** > **NuGet Package Manager** menüpontba.

1. Nyissa ki a **NuGet Package Manager**-t (dupla kattintással), majd válassza a **Package Sources**-t. 

1. Ellenőrizze és erősítse meg, hogy a nuget.org paraméter ki van választva. 

   A példaprojekt a NuGet Automatic Package Restore funkciót használja, ezért aktív internetkapcsolatra van szükség. 

   Ha nincs aktív internetkapcsolata azon a gépen, ahol a példákat futtatni kívánja, tekintse meg az [Installation](https://docs.aspose.com/slides/hu/net/installation/) oldalt, és (kézzel) adjon hozzá egy hivatkozást az Aspose.Slides.dll-re a példaprojektben.
## **Aspose.Slides letöltése a GitHub-ról**
Az összes Aspose.Slides for .NET példa a [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET) oldalon érhető el.

A tárolót klónozhatja a kedvenc GitHub kliensével, vagy letöltheti a ZIP fájlt [itt](https://github.com/aspose-slides/Aspose.Slides-for-.NET/archive/master.zip).

1. Ha letölti a ZIP fájlt, ki kell csomagolnia a tartalmát egy mappába a számítógépén. 

Az összes példa az **Examples** mappában található.

Van egy C# Visual Studio megoldásfájl. A projekteket Visual Studio 2013-ban hozták létre, de a megoldásfájlok kompatibilisek a Visual Studio 2010 SP1 és újabb verzióival.

2. Nyissa meg a megoldásfájlt a Visual Studio-ban, és építse fel a projektet.

   Az első futtatáskor a függőségek automatikusan letöltődnek a NuGet-en keresztül.

A **Examples** gyökérmappájában található **Data** mappa tartalmazza a C# példákban használt bemeneti fájlokat. A **Data** mappát le kell töltenie a példaprojekt mellé.

3. Nyissa meg a RunExamples.cs fájlt. Az összes példa innen hívódik meg.

4. Kommentálja ki a futtatni kívánt példákat a projektben.

Kérjük, forduljon fórumainkhoz, ha problémái vannak a beállításokkal vagy a példák futtatásával.
## **Közreműködés**
A projekthez úgy járulhat hozzá, hogy új példát ad hozzá vagy meglévőt fejleszt. A tárolóban lévő összes példa és bemutató projekt nyílt forráskódú, ezért Ön (és mások) szabadon felhasználhatják őket alkalmazásokban.

A közreműködéshez fork-olhatja a tárolót, szerkesztheti a forráskódot, és létrehozhat egy pull request-et. Átnézzük a változtatásokat. Ha hasznosnak találjuk, hozzáadjuk őket a tárolóhoz.