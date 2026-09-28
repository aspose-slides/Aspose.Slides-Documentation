---
title: Keresztplatform csomag .NET 6 és újabb verziókhoz
linktitle: Keresztplatform csomag
type: docs
weight: 235
url: /hu/net/net6/
keywords:
- Aspose.Slides.NET6.CrossPlatform
- keresztplatform
- .NET 6 támogatás
- Linux
- macOS
- fontconfig
- libgdiplus
- System.Drawing.Common
- CS0433
- AWS Lambda
- .NET
- C#
- Aspose.Slides
description: "Ismerje meg, mikor kell használni az Aspose.Slides.NET6.CrossPlatform csomagot: miért létezik, milyen platformokon működik, és mire van szüksége Linuxon a libgdiplus helyett."
---
## **Bevezetés**

Aspose.Slides for .NET két NuGet csomagként érhető el. [Aspose.Slides.NET](https://www.nuget.org/packages/Aspose.Slides.NET/) a Microsoft System.Drawing.Common könyvtár segítségével rajzolja a diákot. [Aspose.Slides.NET6.CrossPlatform](https://www.nuget.org/packages/Aspose.Slides.NET6.CrossPlatform/) ehelyett a saját grafikus motorját használja. Ez a cikk elmagyarázza, miért létezik a második csomag, hol fut, milyen Linux követelményeket igényel, és hogyan élhet együtt a System.Drawing.Common-nal egy projektben.

## **Miért külön csomag**

A .NET 6-tól kezdve a Microsoft csak Windowson támogatja a System.Drawing.Common‑ot. Ennek következtében Linuxon az Aspose.Slides.NET‑nek a `System.Drawing.EnableUnixSupport` kapcsolót és a `libgdiplus` könyvtárat is szüksége van, és hibát jelez, ha a projekt a System.Drawing.Common 7‑es vagy újabb verziójára hivatkozik. [Rendszerkövetelmények](/slides/hu/net/system-requirements/) leírja ezeket a feltételeket.

Az Aspose.Slides.NET6.CrossPlatform nem használja a System.Drawing.Common‑ot vagy a `libgdiplus`‑t. Grafikus motorja egy natív könyvtár, amely a csomagban található egy építésre minden támogatott platformhoz. Mindkét csomag ugyanazokat az Aspose.Slides névtereket és osztályokat biztosítja, ezért a csere csak a csomagreferenciát érinti, nem a kódot.

| | Aspose.Slides.NET | Aspose.Slides.NET6.CrossPlatform |
|---|---|---|
| Grafika | System.Drawing.Common | Natív grafikus motor, a csomagban |
| Célkeretek | `net462`, `net6.0`, `netstandard2.0` | `net6.0` |
| Linux követelmények | `libgdiplus` és a `System.Drawing.EnableUnixSupport` kapcsoló | `fontconfig` |
| Alpine Linux | Támogatott | Nem támogatott |

## **Támogatott platformok**

Az Aspose.Slides.NET6.CrossPlatform a .NET 6‑os és újabb verziókkal működik a következő platformokon:

- **Windows**: x86 és x64. A natív könyvtár a Microsoft Visual C++ futtatókörnyezetet használja; lásd a [Rendszerkövetelmények](/slides/hu/net/system-requirements/) oldalt.
- **Linux**: x64 glibc 2.23 vagy újabb, valamint ARM64 glibc 2.39 vagy újabb.
- **macOS**: x64 (Intel) és ARM64 (Apple silicon).

Nem fut Windows ARM64-n, Alpine Linuxon vagy más musl‑alapú disztribúciókon, illetve régebbi glibc‑vel rendelkező rendszereken, például a CentOS 7‑en. Ezeken a rendszereken az Aspose.Slides.NET csomagot kell használni.

## **Telepítés Linuxon**

Linuxon a csomag a `fontconfig` könyvtárat igényli, de nem a `libgdiplus`‑t. Debian és Ubuntu esetén telepítse a `fontconfig`‑ot, majd adja hozzá a csomagot a projekthez:

```bash
sudo apt-get update && sudo apt-get install -y libfontconfig1
dotnet add package Aspose.Slides.NET6.CrossPlatform
```

Debian és Ubuntu alatt a `libfontconfig1` a DejaVu betűkészletet is telepíti, így a szöveg további betűcsomagok nélkül jelenik meg. `fontconfig` nélkül egy [Presentation](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation/) létrehozása `TypeInitializationException` hibát eredményez, amelynek belső `DllNotFoundException` üzenete szerint a `libfontconfig.so.1` nem nyitható meg. A [Rendszerkövetelmények](/slides/hu/net/system-requirements/) egy rövid programot is tartalmaz, amellyel ellenőrizhető a beállítás.

## **Felhő és konténergazdagépek**

Mivel nem igényli a `libgdiplus`‑t, az Aspose.Slides.NET6.CrossPlatform a megfelelő csomag Linuxos felhő- vagy konténerkörnyezetekben, ahol a `libgdiplus` nem telepíthető. Továbbra is szükség van a `fontconfig`‑ra és a betűkészletekre, amelyek egyes minimális alapképekben hiányozhatnak. Például a .NET 8‑as AWS Lambda alapkép egyik sem tartalmazza ezeket. Egy ilyen alapképen épülő konténerben futtassa a `dnf install -y fontconfig` parancsot, amely a Noto Sans betűkészletet is telepíti.

A konkrét felhőplatformok útmutatóiért lásd a [Aspose.Slides a felhőplatformokon](/slides/hu/net/slides-on-cloud-platforms/) oldalt.

## **System.Drawing.Common használata ugyanabban a projektben (CS0433)**

Az Aspose.Slides.NET6.CrossPlatform‑ot használó projekt hivatkozhat a System.Drawing.Common‑ra is, közvetlenül vagy egy másik csomágon keresztül. Az Aspose.Slides aktuális verziója nem tartalmaz nyilvános típusokat a `System` névtérben, ezért a két könyvtár nem ütközik, és ugyanabban a fájlban is importálható az `Aspose.Slides` és a `System.Drawing` névtér.

Ha a fordító CS0433 hibát jelez, mert egy `Image` vagy `Graphics` típus mind az Aspose.Slides, mind a System.Drawing.Common könyvtárban megtalálható, akkor a projekt egy régebbi Aspose.Slides verziót használ. Frissítse a csomagot a legújabbra. Az Aspose.Slides a megjelenített képeket [IImage](https://reference.aspose.com/slides/hu/net/aspose.slides/iimage/) objektumokként adja vissza, amelyeket a [Modern API](/slides/hu/net/modern-api/) részletez.

## **GYIK**

**Szükséges-e módosítanom a kódomat, amikor az Aspose.Slides.NET‑ről az Aspose.Slides.NET6.CrossPlatform‑ra váltok?**

Nem. Mindkét csomag ugyanazokat az Aspose.Slides névtereket és osztályokat biztosítja, ezért csak a csomagreferenciát kell kicserélni. Az Aspose.Slides.NET6.CrossPlatform nem igényli a `System.Drawing.EnableUnixSupport` kapcsolót. Egy projekthez csak az egyik csomagot adja hozzá.

**Használhatom az Aspose.Slides.NET6.CrossPlatform‑ot .NET Framework projektekben?**

Nem. A csomag csak a .NET 6‑os és újabb verziókat célozza. .NET Framework 4.6.2‑től felfelé használja az Aspose.Slides.NET‑et.