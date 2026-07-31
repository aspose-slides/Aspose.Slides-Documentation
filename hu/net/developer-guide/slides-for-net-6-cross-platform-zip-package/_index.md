---
title: Aspose.Slides for .NET 6 Cross-Platform (ZIP csomag)
type: docs
weight: 237
url: /hu/net/slides-for-net-6-cross-platform-zip-package/
aliases:
  - /net/slides-for-net-6-cross-platform/
keywords:
- cross-platform
- .NET 6
- GLIBC
- csproj
- cél útvonal
- függő könyvtár
- Aspose.Slides.dll
- System.Drawing.Common
- névütközés
- extern alias
- CS0433
- PowerPoint
- OpenDocument
- bemutató
- .NET
- C#
- Aspose.Slides
description: "Használja az Aspose.Slides for .NET 6-ot, hogy Windows, Linux és macOS platformokon keresztül C# alkalmazásokat építsen, amelyek PowerPoint PPT, PPTX és ODP fájlokat hoznak létre, szerkesztenek és konvertálnak."
---
## **Áttekintés**

Ez a cikk leírja, hogyan használható az Aspose.Slides for .NET 6 Cross-Platform ZIP csomagból. Bemutatja, hogyan tölthető le a csomag, hogyan csomagolhatók ki a `net6.0/crossplatform` mappából a fájlok, hogyan adható hozzá hivatkozás az `Aspose.Slides.dll`-hez, és hogyan konfigurálható a projektfájl úgy, hogy a szükséges függő könyvtárak a program kimeneti könyvtárába kerüljenek.

A cikk emellett leírja a cross-platform csomag tartalmát, beleértve a fő Aspose.Slides .NET összeállítást és a platform-specifikus grafikus alrendszer könyvtárakat Windows, Linux és macOS számára.

{{% alert title="Megjegyzés" color="primary" %}}

Az Aspose.Slides for .NET 6 Cross-Platform elérhető a [NuGet](https://www.nuget.org/packages/Aspose.Slides.NET6.CrossPlatform) oldalon is.

{{% /alert %}}

## **Cross-Platform Aspose.Slides használata ZIP csomagról**

1. Töltse le a legújabb Aspose.Slides ZIP csomagját a [Release Page](https://releases.aspose.com/slides/hu/net/) oldalról.  

2. Csomagolja ki a *Aspose.Slides.zip\Aspose.Slides\net6.0\crossplatform* mappából a fájlokat, és helyezze őket abba a könyvtárba, amelyet a projekt függőségeihez használni kíván.  

3. Adjon hozzá hivatkozást az Aspose.Slides.dll-hez.  

   ![add-project-reference-visual-studio](add-project-reference-visual-studio.png)

   A példánkban (lent) a könyvtárak a projekt mappájában találhatók a következő úton: *ConsoleApp\libs\Aspose.Slides\net6.0\crossplatform\...*  

   ![browse-console-app](browse-console-app.jpg)

4. Helyezze a maradék fájlokat (amelyekre az Aspose.Slidesnek szüksége van) a kimeneti könyvtárba úgy, hogy a csproj projektfájlba a következő módon adja hozzá az utasításokat:

```xml
<ItemGroup>

   <None Update="libs\Aspose.Slides\net6.0\crossplatform\aspose.slides.drawing.capi_vc14x64.dll">
         <CopyToOutputDirectory>PreserveNewest</CopyToOutputDirectory>
         <TargetPath>aspose.slides.drawing.capi_vc14x64.dll</TargetPath>
   </None>

   <None Update="libs\Aspose.Slides\net6.0\crossplatform\aspose.slides.drawing.capi_vc14x86.dll">
         <CopyToOutputDirectory>PreserveNewest</CopyToOutputDirectory>
         <TargetPath>aspose.slides.drawing.capi_vc14x86.dll</TargetPath>
   </None>

   <None Update="libs\Aspose.Slides\net6.0\crossplatform\Aspose.Slides.xml">
         <CopyToOutputDirectory>PreserveNewest</CopyToOutputDirectory>
         <TargetPath>Aspose.Slides.xml</TargetPath>
   </None>

   <None Update="libs\Aspose.Slides\net6.0\crossplatform\libaspose.slides.drawing.capi_appleclang_x86_64.dylib">
         <CopyToOutputDirectory>PreserveNewest</CopyToOutputDirectory>
         <TargetPath>libaspose.slides.drawing.capi_appleclang_x86_64.dylib</TargetPath>
   </None>

   <None Update="libs\Aspose.Slides\net6.0\crossplatform\libaspose.slides.drawing.capi_appleclang_arm64.dylib">
         <CopyToOutputDirectory>PreserveNewest</CopyToOutputDirectory>
         <TargetPath>libaspose.slides.drawing.capi_appleclang_arm64.dylib</TargetPath>
   </None>

   <None Update="libs\Aspose.Slides\net6.0\crossplatform\libaspose.slides.drawing.capi_x86_64_libstdcpp_libc2.23.so">
         <CopyToOutputDirectory>PreserveNewest</CopyToOutputDirectory>
         <TargetPath>libaspose.slides.drawing.capi_x86_64_libstdcpp_libc2.23.so</TargetPath>
   </None>

</ItemGroup>
```

5. Figyeljen a `TargetPath` beállításra.  

   Alapértelmezés szerint a `<CopyToOutputDirectory>` a fájlokat relatív útvonallal másolja, de nekünk azt szeretnénk, hogy a függő könyvtárak ugyanabba a mappába kerüljenek, ahol a kimenet generálódik (az Aspose.Slides.dll helye).

## **Megjegyzések**

### **Tulajdonosi grafikus alrendszer**

Az Aspose.Slides cross-platform egy könyvtárgyűjtemény:

| Aspose.Slides.dll                                          | A fő .NET összeállítás, amely minden Aspose.Slides logikát kezeli |
| ---------------------------------------------------------- | ------------------------------------------------------------------- |
| aspose.slides.drawing.capi_vc14x64.dll                     | Függőség: grafikus alrendszer megvalósítása Win x64 számára          |
| aspose.slides.drawing.capi_vc14x86.dll                     | Függőség: grafikus alrendszer megvalósítása Win x64 számára          |
| libaspose.slides.drawing.capi_x86_64_libstdcpp_libc2.23.so | Függőség: grafikus alrendszer megvalósítása Linux (x86/x64) számára |
| libaspose.slides.drawing.capi_appleclang_x86_64.dylib      | Függőség: grafikus alrendszer megvalósítása macOS AMD64 (x86-64/x64) számára |
| libaspose.slides.drawing.capi_appleclang_arm64.dylib       | Függőség: grafikus alrendszer megvalósítása macOS ARM64 (AArch64) számára |

Az Aspose.Slides.dll a rendszertől függő könyvtárat használja, amelyre a futó környezetnek szüksége van. A könyvtárak általában ugyanabban a helyen találhatók, mint az Aspose.Slides.dll, bármilyen fájlrendszerben.

### **ZIP csomag struktúra**

A ZIP csomag a következő könyvtárstruktúrát tartalmazza:

Aspose.Slides
├─── net6.0
│  ├─── crossplatform
│  └─── default
├─── net20
├─── net462
└─── netstandard2.0

* Minden mappa a hozzá tartozó .NET verzióhoz készült összeállításokat tartalmaz. A net6.0-hoz két változat létezik: default és crossplatform. Az utóbbi a cross-platform Aspose.Slides.dll-t és minden függőségét tartalmazza. Ennek a mappának a kibontott tartalma függőségként hozzáadható egy projekthez, amely cross‑platform fejlesztést és egyéb Aspose.Slides használati eseteket támogat.

## **Lásd még**

- [System Requirements](/slides/hu/net/system-requirements/)