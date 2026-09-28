---
title: Rendszerkövetelmények
type: docs
weight: 60
url: /hu/net/system-requirements/
keywords:
- rendszerkövetelmények
- támogatott platformok
- célkeretrendszerek
- .NET Framework
- .NET Standard
- libgdiplus
- fontconfig
- Alpine
- Windows
- Linux
- macOS
- PowerPoint
- OpenDocument
- prezentáció
- .NET
- C#
- Aspose.Slides
description: "Ellenőrizze, hogy az Aspose.Slides for .NET-nek mire van szüksége a telepítés előtt: a NuGet csomagok által támogatott keretrendszerek, a támogatott operációs rendszerek és processzorok, valamint a Linux által igényelt könyvtárak és betűkészletek."
---
## **Bevezetés**

Az Aspose.Slides for .NET egy önálló könyvtár: nem igényli a Microsoft PowerPointot vagy a Microsoft Office-ot. Két NuGet csomagként kerül közzétételre, [Aspose.Slides.NET](https://www.nuget.org/packages/Aspose.Slides.NET/) és [Aspose.Slides.NET6.CrossPlatform](https://www.nuget.org/packages/Aspose.Slides.NET6.CrossPlatform/). Mindkettő ugyanazokat az Aspose.Slides névtereket és osztályokat biztosítja; a célkeretrendszerükben és a diák megrajzolásának módjában különböznek, ami meghatározza, hol futnak és mire van szükségük.

Ez a cikk felsorolja, hogy mely .NET verziókat és platformokat támogatja az egyes csomag, valamint a Linux által igényelt rendszerkönyvtárakat és betűkészleteket, és egy rövid programmal zárja, amely ellenőrzi a környezetet. Egy csomag projekthez adásához lásd a [Installation](/slides/hu/net/installation/) oldalt.

## **Támogatott .NET verziók**

Minden csomag egyetlen építést tartalmaz az adott célkeretrendszerhez, és a NuGet kiválasztja azt, amely megegyezik a projekt célkeretrendszerével.

| Csomag | Célkeretrendszerek a csomagban | A projektje célzhat |
|---|---|---|
| Aspose.Slides.NET | `net462`, `net6.0`, `netstandard2.0` | .NET Framework 4.6.2 vagy újabb; .NET 6 vagy újabb, beleértve a .NET 8-at, .NET 9-et és .NET 10-et |
| Aspose.Slides.NET6.CrossPlatform | `net6.0` | .NET 6 vagy újabb, beleértve a .NET 8-at, .NET 9-et és .NET 10-et |

A `netstandard2.0` építés lehetővé teszi, hogy egy .NET Standard 2.0 osztálykönyvtár hivatkozzon az Aspose.Slides.NET-re. Egy olyan alkalmazás, amely ezt a könyvtárat használja, az alkalmazás saját célkeretrendszerének megfelelő építést futtatja: egy .NET 8 alkalmazás például a `net6.0` építést futtatja.

## **Támogatott operációs rendszerek és processzorok**

**Aspose.Slides.NET** kizárólag processzorfüggetlen (AnyCPU) felügyelt kódot tartalmaz, így a betöltő .NET futtatókörnyezet processzorarchitektúráján fut. Diákat a Microsoft System.Drawing.Common könyvtárán keresztül rajzol, amelyet a Microsoft [csak Windowsra]https://learn.microsoft.com/en-us/dotnet/core/compatibility/core-libraries/6.0/system-drawing-common-windows-only támogat. Linuxon az Aspose.Slides.NET ezért a `libgdiplus` könyvtárat és egy indítási kapcsolót igényel, amelyet a [Linux](#linux) részben ismertetünk. Olyan Linux disztribúciókon fut, amelyek biztosítják a `libgdiplus`-t, például Debian, Ubuntu és Alpine Linux.

**Aspose.Slides.NET6.CrossPlatform** saját grafikus motorral rajzol diákot. A motor egy natív könyvtár, amelyet a csomag egy építésben tartalmaz minden platformra, ezért a csomag csak ezeken a platformokon fut:

| Operációs rendszer | Processzorok | Megjegyzések |
|---|---|---|
| Windows | x86, x64 | Windows az ARM64-ön nem támogatott. |
| Linux | x64, ARM64 | Glibc 2.23 vagy újabb szükséges x64-en, illetve glibc 2.39 vagy újabb ARM64-en. |
| macOS | x64 (Intel), ARM64 (Apple silicon) |  |

Az Aspose.Slides.NET6.CrossPlatform nem fut Alpine Linuxon vagy más, musl‑t használó, glibc helyett, valamint nem fut régebbi glibc‑vel rendelkező disztribúciókon, például a CentOS 7-en. Ezeken a rendszereken az Aspose.Slides.NET-et használja.

Windowson az Aspose.Slides.NET6.CrossPlatform natív könyvtára a Microsoft Visual C++ futtatókörnyezetet (*MSVCP140.dll* és *VCRUNTIME140.dll*, plusz *VCRUNTIME140_1.dll* x64‑on) használja. Ha ezek a fájlok hiányoznak a célgépen, telepítse a [Microsoft Visual C++ Redistributable]https://learn.microsoft.com/en-us/cpp/windows/latest-supported-vc-redist?view=msvc-170 linket.

## **Linux**

Mindkét csomagnak további rendszerkönyvtárakra van szüksége Linuxon. Ezek nélkül az első példa a [Create Presentations](/slides/hu/net/create-presentation/) szakaszban kivétellel bukik, a fájl mentése helyett. Az alábbi parancsok Debianra és Ubuntura vonatkoznak; ezen disztribúciókon minden könyvtár a DejaVu betűkészleteket (`fonts-dejavu-core`) is telepíti, így a szöveg további betűkészlet‑csomagok nélkül jelenik meg.

### **Aspose.Slides.NET6.CrossPlatform**

A csomag Linux‑könyvtára a `fontconfig` könyvtárat igényli:

```bash
sudo apt-get update && sudo apt-get install -y libfontconfig1
```

Enélkül egy [Presentation]https://reference.aspose.com/slides/net/aspose.slides/presentation/ létrehozása `TypeInitializationException`‑t eredményez, amelynek belső `DllNotFoundException` üzenete szerint a `libfontconfig.so.1` nem nyitható meg.

A minimális alapképek sem tartalmazhatják a `fontconfig`‑t. Például a .NET 8‑as AWS Lambda alapkép sem tartalmaz `fontconfig`‑ot, sem betűkészleteket. Egy belőle épített konténerképen futtassa a `dnf install -y fontconfig` parancsot, amely a Noto Sans betűkészleteket is telepíti.

### **Aspose.Slides.NET**

A csomagnak Linuxon két dologra van szüksége:

1. A `libgdiplus` könyvtárra:

   ```bash
   sudo apt-get update && sudo apt-get install -y libgdiplus
   ```

2. A `System.Drawing.EnableUnixSupport` kapcsolóra, amelyet az alkalmazás indításakor, bármely Aspose.Slides hívás előtt kell engedélyezni. Egy *Program.cs* felső‑szintű utasításokkal rendelkező fájlban helyezze a `using` direktívák után:

   ```c#
   System.AppContext.SetSwitch("System.Drawing.EnableUnixSupport", true);
   ```

`libgdiplus` nélkül a prezentáció mentése `TypeInitializationException`‑t eredményez, amelynek belső `DllNotFoundException` azt jelzi, hogy a `libgdiplus` nem tölthető be. A kapcsoló hiányában a belső kivétel `PlatformNotSupportedException: System.Drawing.Common is not supported on non-Windows platforms`.

{{% alert color="warning" title="Warning" %}}
A kapcsoló csak a System.Drawing.Common 6‑os verziójával működik, amelyre az Aspose.Slides.NET támaszkodik. A Microsoft eltávolította a 7‑es verzióban. Ha a projektje a System.Drawing.Common 7‑et vagy újabbat hivatkozza, közvetlenül vagy egy másik csomagon keresztül, az Aspose.Slides.NET Linuxon `PlatformNotSupportedException`‑t dob, még a `libgdiplus` telepítése és a kapcsoló engedélyezése esetén is. Ebben az esetben használja az Aspose.Slides.NET6.CrossPlatform‑ot.
{{% /alert %}}

### **Alpine Linux**

Alpine Linuxon az Aspose.Slides.NET-et a fent leírt kapcsolóval kell használni. Az Alpine‑képek általában nem tartalmaznak betűkészleteket, és a `libgdiplus` önmagában sem telepít betűket, ezért telepítse a `libgdiplus`‑t legalább egy betűkészlettel együtt. Betűkészletek nélkül a prezentáció mentése a következő hibával bukik:

```text
System.ArgumentException: Font '?' cannot be found.
```

**1. lehetőség: DejaVu betűkészletek**

Az ajánlott megoldás a `ttf-dejavu` csomag:

```dockerfile
RUN apk add --no-cache \
    libgdiplus \
    ttf-dejavu
```

Az aktuális Alpine kiadásokban a `ttf-dejavu` a `font-dejavu` csomagot telepíti, amely szintén a `fontconfig`‑t és a hozzá tartozó betűeszközöket tartalmazza.

**2. lehetőség: Microsoft alapbetűkészletek**

Ha a prezentációk Microsoft‑betűket (Arial, Times New Roman, Courier New, Verdana) használnak, telepítse a Microsoft alapbetűket. Az `update-ms-fonts` lépés a kép építésekor letölti a betűkészleteket, ezért az építésnek internetkapcsolattal kell rendelkeznie:

```dockerfile
RUN apk add --no-cache \
    libgdiplus \
    fontconfig \
    msttcorefonts-installer \
    && update-ms-fonts \
    && fc-cache -fv
```

### **Globalizáció támogatása**

Mindkét csomagnak szüksége van .NET globalizáció‑támogatásra, amelyet a Linuxos .NET az ICU könyvtárakon keresztül biztosít. [globalization‑invariant módban](https://learn.microsoft.com/en-us/dotnet/core/runtime-config/globalization) egy [Presentation]https://reference.aspose.com/slides/net/aspose.slides/presentation/ létrehozása `CultureNotFoundException: Only the invariant culture is supported in globalization-invariant mode` hibát eredményez.

Néhány konténerkép ezt a módot bekapcsolja. Például az Alpine Linuxra (runtime‑deps, runtime, aspnet) szánt .NET futtatóképek `DOTNET_SYSTEM_GLOBALIZATION_INVARIANT=true` értékre állítják, és nem tartalmazzák az ICU‑t. Egy ezekre épített képen telepítse az ICU‑t, és kapcsolja ki a módot:

```dockerfile
ENV DOTNET_SYSTEM_GLOBALIZATION_INVARIANT=false
RUN apk --no-cache add icu-libs
```

Biztosítsa továbbá, hogy a projektfájl ne állítsa be az `InvariantGlobalization` tulajdonságot `true`‑ra.

## **Ellenőrizze a beállításokat**

Egy csomag és annak követelményeinek ellenőrzéséhez futtasson egy programot, amely ment egy prezentációt, és egy diát képpé konvertál. A mentés és a konvertálás a grafikus könyvtárat és a betűkészleteket használja, amelyeket a fenti Linux‑követelmények biztosítanak.

Hozzon létre egy konzol‑alkalmazást, adja hozzá a csomagot a [Installation](/slides/hu/net/installation/) leírása szerint, cserélje le a *Program.cs* tartalmát az alábbi kódra, és futtassa a `dotnet run` parancsot. Ha Linuxon az Aspose.Slides.NET-et használja, adja hozzá a [Linux](#linux) részben bemutatott `System.Drawing.EnableUnixSupport` kapcsoló‑utasítást a `using` direktívák után. A program felső‑szintű utasításokat és `using` deklarációkat használ, amelyekhez C# 9 vagy újabb szükséges. A .NET 6‑ot vagy újabbat célzó projektek alapértelmezés szerint újabb C# verziót használnak; .NET Framework‑ot célzó projekt esetén adja hozzá a `<LangVersion>latest</LangVersion>` elemet egy `PropertyGroup`‑hoz a projektfájlban.

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 400, 100);
shape.TextFrame.Text = "Hello, Aspose.Slides!";
presentation.Save("hello.pptx", SaveFormat.Pptx);

using var image = slide.GetImage(1f, 1f);
image.Save("hello.png", ImageFormat.Png);
```

A program egy téglalapot szöveggel ad az első diához, és a *hello.pptx* fájlt a [Save]https://reference.aspose.com/slides/net/aspose.slides/presentation/save/ metódussal menti. Ezután a diát a [GetImage]https://reference.aspose.com/slides/net/aspose.slides/slide/getimage/ metódussal konvertálja, és az eredményt a [IImage.Save]https://reference.aspose.com/slides/net/aspose.slides/iimage/save/ metódussal *hello.png*‑ként menti az [ImageFormat.Png]https://reference.aspose.com/slides/net/aspose.slides/imageformat/ formátumban. Az 1‑es skálázási tényező pontonként egy képpontot jelenít meg, így az alapértelmezett 720 × 540 pont méretű dia 720 × 540 képpontos képpé alakul, a szöveg a téglalapon belül látható. Licenc nélkül mindkét fájl egy értékelő vízjelet tartalmaz; lásd a [Licensing](/slides/hu/net/licensing/) oldalt. Ha valamelyik követelmény hiányzik, a program a [Linux](#linux) részben ismertetett kivételek egyikével áll le.

## **Fejlesztői eszközök**

Az Aspose.Slides‑ot használó alkalmazásokat bármely olyan eszközzel felépítheti, amely támogatja a projekt célkeretrendszerét: a .NET SDK‑val és a `dotnet` parancssori felülettel Windowson, Linuxon és macOS‑en, vagy a Visual Studio‑val Windowson. A [Installation](/slides/hu/net/installation/) mindkettőt bemutatja.

## **GYIK**

**Szükség van Microsoft PowerPoint telepítésére a konverziókhoz és a megjelenítéshez?**

Nem, a PowerPoint nem kötelező. Az Aspose.Slides egy önálló motor a [létrehozáshoz](/slides/hu/net/create-presentation/), módosításhoz, a [konvertáláshoz](/slides/hu/net/convert-presentation/) és a [megjelenítéshez](/slides/hu/net/convert-powerpoint-to-png/) prezentációkhoz.

**Melyik csomagot használjam?**

Windowson használja az Aspose.Slides.NET-et, Linuxon és macOS‑en az Aspose.Slides.NET6.CrossPlatform‑ot. Alpine Linuxon, régebbi glibc‑vel rendelkező Linux rendszereken, illetve .NET Framework‑et célozó projektekben használja az Aspose.Slides.NET-et. Egy projekthez csak az egyik csomagot adja hozzá.

**Mely betűkészletek szükségesek a helyes megjelenítéshez?**

A prezentációban használt betűkészleteknek vagy megfelelő helyettesítőknek elérhetőnek kell lenniük az operációs rendszerben. Linuxon és macOS‑en telepítse a prezentációkhoz szükséges betűkészlet‑csomagokat a konzisztens megjelenítés érdekében. Alpine Linuxon legalább egy betűkészlet‑csomagot telepítsen a `libgdiplus` mellett, ahogy az [Alpine Linux](#alpine-linux) részben le van írva.

**Miért jelenik meg egy egyéni betűtípus helyettesítőként vagy hiányzó szövegként Linuxon?**

Ha a betűfájl névtáblája nem egységes vagy sérült, a Linux betűkészlet‑kereső (FreeType/fontconfig) érvénytelen rekordot választhat, ami a betű hiányához vezet. Egy javított névtábla‑rekorddal rendelkező betűverzió vagy egy konzisztens helyettesítő telepítése megoldja a problémát.