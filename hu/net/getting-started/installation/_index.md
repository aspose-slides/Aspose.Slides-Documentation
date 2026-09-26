---
title: Telepítés
type: docs
weight: 70
url: /hu/net/installation/
keywords:
- Aspose.Slides telepítése
- Aspose.Slides letöltése
- Aspose.Slides használata
- Aspose.Slides telepítése
- Windows
- Linux
- macOS
- PowerPoint
- OpenDocument
- prezentáció
- .NET
- C#
- Aspose.Slides
description: "Telepítse az Aspose.Slides for .NET-et a NuGet-en keresztül Windows, Linux és macOS rendszereken: válasszon a két csomag közül, adjon hozzá egyet a .NET CLI vagy a Visual Studio segítségével, és telepítse a Linux előkövetelményeket."
---
## **Áttekintés**

Ez a cikk leírja, hogyan adhat hozzá az Aspose.Slides for .NET-et egy projekthez Windows, Linux és macOS rendszereken. Az Aspose.Slides a NuGet-en keresztül kerül terjesztésre. Bármely operációs rendszeren a .NET CLI-vel adható hozzá, vagy a Visual Studio Windows verziójában a NuGet Package Manager vagy a Package Manager Console használatával. A cikk azt is ismerteti, hogy a két NuGet csomag közül melyiket válasszuk és milyen további igények merülnek fel Linuxon.

A telepítés előtt tekintse át a támogatott operációs rendszereket, .NET megvalósításokat és a további függőségeket a [Rendszerkövetelmények](/slides/hu/net/system-requirements/) oldalon.

## **Csomag választása**

Az Aspose.Slides for .NET két NuGet csomagként kerül kiadásra. Mindkettő ugyanazokat az Aspose.Slides névtér és osztályokat biztosítja, így a kód nem változik a csomagok között váltáskor; csak a csomagra való hivatkozás és a platformkövetelmények különböznek.

| Csomag | Használat célja | További követelmények |
|---|---|---|
| [Aspose.Slides.NET](https://www.nuget.org/packages/Aspose.Slides.NET/) | Windows, valamint .NET Framework alkalmazások | Linuxon és macOS-on: a `libgdiplus` könyvtár, valamint a `System.Drawing.EnableUnixSupport` kapcsoló engedélyezve az alkalmazás indításakor |
| [Aspose.Slides.NET6.CrossPlatform](https://www.nuget.org/packages/Aspose.Slides.NET6.CrossPlatform/) | .NET 6 vagy újabb Windowson, Linuxon és macOS-on | Linuxon: a `fontconfig` könyvtár, ha még nincs telepítve |

Ha bizonytalan, használja az Aspose.Slides.NET-et Windowson, és az Aspose.Slides.NET6.CrossPlatform-ot Linuxon és macOS-on. Alpine Linuxon, illetve olyan Linux rendszereken, ahol a glibc verziója régebbi, mint 2.23 (x64) vagy 2.39 (ARM64), használja helyette az Aspose.Slides.NET-et. A [Rendszerkövetelmények](/slides/hu/net/system-requirements/) felsorolja az egyes csomagok támogatott platformjait.

## **Telepítés a .NET CLI-vel**

Ezek a lépések Windows, Linux és macOS rendszereken a .NET SDK 6 vagy újabb verziójával működnek. Készítsen egy konzolalkalmazást:

```bash
dotnet new console -n HelloSlides
cd HelloSlides
```

Ezután adja hozzá a csomagot a platformjához. Csak az egyiket a két csomag közül adja hozzá a projekthez.

- Windowson: `dotnet add package Aspose.Slides.NET`
- Linuxon és macOS-on: `dotnet add package Aspose.Slides.NET6.CrossPlatform` (Linuxon először telepítse az előfeltételt; lásd a [Linux](#linux) részt)

A csomag működésének ellenőrzéséhez cserélje le a *Program.cs* tartalmát a [Prezentációk létrehozása](/slides/hu/net/create-presentation/) első példájára, és futtassa a `dotnet run` parancsot. A *hello.pptx* fájlt a projekt mappájába menti.

## **Windows**

### **Módszer 1: Az Aspose.Slides telepítése vagy frissítése a NuGet Package Managerből**

1. Nyissa meg a Microsoft Visual Studio-t.
2. Készítsen egy konzolalkalmazást, vagy nyisson meg egy meglévő projektet.
3. A **Solution Explorer**-ben kattintson jobb gombbal a projektre, és válassza a **Manage NuGet Packages** lehetőséget (vagy menjen a **Project** > **Manage NuGet Packages** menüpontra).
4. **Browse** alatt keresse meg az *Aspose.Slides* csomagot.
{{% image img="installation_1.png" alt="Aspose.Slides Installation from NuGet Package Manager - 1" %}}
5. Kattintson a **Aspose.Slides.NET**-re, majd a **Install** gombra.
   * Ha már telepítette az Aspose.Slides-et, és frissíteni szeretné, kattintson a **Update** gombra.

A csomag letöltődik, és hivatkozásként hozzáadódik a projektjéhez.

### **Módszer 2: Az Aspose.Slides telepítése vagy frissítése a Package Manager Console segítségével**

Így hivatkozhat a [Aspose.Slides.NET](https://www.nuget.org/packages/Aspose.Slides.NET/) csomagra a Package Manager Console-ban:

1. Nyissa meg a Microsoft Visual Studio-t.
2. Készítsen egy konzolalkalmazást, vagy nyisson meg egy meglévő projektet.
3. Nyissa meg a **Tools** > **NuGet Package Manager** > **Package Manager Console** menüt.
![A Package Manager Console megnyitása](installation_2.png)
4. Futtassa ezt a parancsot: `Install-Package Aspose.Slides.NET`
![Az Install-Package parancs futtatása](installation_3.png)
A legújabb kiadás telepítve van a projektjébe.

Az **Installing Aspose.Slides.NET** üzenet a ablak alja felé jelenik meg.
![Telepítési előrehaladás a Package Manager Console-ban](installation_4.png)

A letöltés befejeződésekor megjelennek a megerősítő üzenetek. A csomag az [Aspose EULA](https://about.aspose.com/legal/eula) alapján kerül terjesztésre.
![Telepítési megerősítő üzenetek](installation_5.png)

Az Aspose.Slides most már hozzáadva van a projektjéhez, és hivatkozásként szerepel.
![Aspose.Slides hivatkozva a projektben](installation_6.png)

A csomag frissítéséhez futtassa a `Update-Package Aspose.Slides.NET` parancsot a Package Manager Console-ban.

## **Linux**

Használja a fentebb leírt .NET CLI lépéseket. Válassza ki a csomagot, és telepítse az előfeltételét a disztribúció csomagkezelőjével. Debianon és Ubuntu-n:

- **Aspose.Slides.NET6.CrossPlatform**: telepítse a `fontconfig` csomagot.

  ```bash
  sudo apt-get update && sudo apt-get install -y libfontconfig1
  dotnet add package Aspose.Slides.NET6.CrossPlatform
  ```

- **Aspose.Slides.NET**: telepítse a `libgdiplus` könyvtárat, és engedélyezze a Unix támogatást a System.Drawing számára, mielőtt az alkalmazás az Aspose.Slides-et használná.

  ```bash
  sudo apt-get update && sudo apt-get install -y libgdiplus
  dotnet add package Aspose.Slides.NET
  ```

Adja hozzá ezt a nyilatkozatot az alkalmazás elején, minden Aspose.Slides hívás előtt. Egy *Program.cs* fájlban, amely felső szintű utasításokat tartalmaz, helyezze a `using` direktívák után:
```c#
  System.AppContext.SetSwitch("System.Drawing.EnableUnixSupport", true);
  ```

Használja ezt a csomagot Alpine Linuxon, valamint olyan rendszereken, ahol a glibc túl régi ahhoz, hogy az Aspose.Slides.NET6.CrossPlatform működjön.

A prezentációkban használt betűtípusoknak, vagy megfelelő helyettesítőknek, telepítve kell lenniük a rendszeren ahhoz, hogy a szöveg helyesen jelenjen meg. A [Rendszerkövetelmények](/slides/hu/net/system-requirements/) leírja, hogy az Aspose.Slides.NET milyen csomagokat igényel Alpine Linuxon, beleértve a betűtípusokat.

## **macOS**

Használja a fentebb leírt .NET CLI lépéseket a **Aspose.Slides.NET6.CrossPlatform** csomaggal, amely támogatja mind az Intel (x86_64), mind az Apple silicon (ARM64) Mac-eket:
```bash
dotnet add package Aspose.Slides.NET6.CrossPlatform
```

## **GYIK**

**Van ingyenes verzió vagy próbahasználati korlátozás?**

Igen. Licenc nélkül az Aspose.Slides értékelő módban fut: minden mentett diára értékelő vízjelet helyez, és a prezentációkból beolvasott szöveget csonkolja. A korlátozások eltávolításához alkalmazzon érvényes [licencet](/slides/hu/net/licensing/).