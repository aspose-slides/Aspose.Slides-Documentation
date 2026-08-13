---
title: Aspose.Slides .NET 6 platformfüggetlen (ZIP csomag)
type: docs
weight: 237
url: /hu/net/slides-for-net-6-cross-platform-zip-package/
aliases:
  - /net/slides-a-net-6-platformfuggetlen/
keywords:
- platformfüggetlen
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
- prezentáció
- .NET
- C#
- Aspose.Slides
description: "Használja az Aspose.Slides for .NET 6-ot platformfüggetlen C# alkalmazások létrehozására Windows, Linux és macOS rendszereken, amelyek PowerPoint PPT, PPTX és ODP fájlok létrehozására, szerkesztésére és átalakítására képesek."
---
## **Áttekintés**

Ez a cikk bemutatja, hogyan használható az Aspose.Slides for .NET 6 Cross-Platform egy ZIP csomagból. Leírja, hogyan tölthető le a csomag, hogyan csomagolhatók ki a `net6.0/crossplatform` mappából a fájlok, hogyan adható hozzá hivatkozás az `Aspose.Slides.dll`-hez, és hogyan konfigurálható a projektfájl, hogy a szükséges függő könyvtárak az alkalmazás kimeneti könyvtárába legyenek másolva.

A cikk továbbá leírja a platformfüggetlen csomag tartalmát, beleértve a fő Aspose.Slides .NET összeállítást és a platformfüggő grafikus alrendszer könyvtárakat Windows, Linux és macOS számára.

{{% alert title="Note" color="info" %}}

Aspose.Slides for .NET 6 Cross-Platform is also available from [NuGet](https://www.nuget.org/packages/Aspose.Slides.NET6.CrossPlatform).

{{% /alert %}}

## **Az platformfüggetlen Aspose.Slides használata ZIP csomagból**

1. Töltse le a legújabb Aspose.Slides ZIP csomagját a [Release Page](https://releases.aspose.com/slides/hu/net/)-ről. 

2. Csomagolja ki a fájlokat a *Aspose.Slides.zip\Aspose.Slides\net6.0\crossplatform* mappából, és helyezze őket abba a könyvtárba, amelyet a projekt függőségeihez fog használni.

3. Adjon hozzá hivatkozást az Aspose.Slides.dll-hez.

   ![add-project-reference-visual-studio](add-project-reference-visual-studio.png)

   A példánkban (lent) a könyvtárak a projekt mappájában a következő úton találhatók: *ConsoleApp\libs\Aspose.Slides\net6.0\crossplatform\...*

   ![browse-console-app](browse-console-app.jpg)

4. Helyezze a maradék fájlokat (amelyekre az Aspose.Slidesnek szüksége van) a kimeneti könyvtárba, úgy, hogy a csproj projektfájlba ezt az instrukciót adja hozzá:

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

5. Figyeljen a `TargetPath`-re. 

   Alapértelmezés szerint a `<CopyToOutputDirectory>` a fájlokat a relatív útvonal megtartásával másolja, de nekünk azt szeretnénk, hogy a függő könyvtárak ugyanabba a mappába kerüljenek, ahol a kimenet keletkezik (az Aspose.Slides.dll helye).

## **Megjegyzések**

### **Tulajdonosi grafikus alrendszer**

Aspose.Slides cross-platform egy könyvtárgyűjtemény:

| Aspose.Slides.dll                                          | Fő .NET összeállítás, amely az összes Aspose.Slides logikáért felel |
| ---------------------------------------------------------- | ------------------------------------------------------------------- |
| aspose.slides.drawing.capi_vc14x64.dll                     | Függőség: grafikus alrendszer implementáció Windows x64-hez          |
| aspose.slides.drawing.capi_vc14x86.dll                     | Függőség: grafikus alrendszer implementáció Windows x64-hez          |
| libaspose.slides.drawing.capi_x86_64_libstdcpp_libc2.23.so | Függőség: grafikus alrendszer implementáció Linuxra (x86/x64)       |
| libaspose.slides.drawing.capi_appleclang_x86_64.dylib      | Függőség: grafikus alrendszer implementáció macOS AMD64 (x86-64/x64) |
| libaspose.slides.drawing.capi_appleclang_arm64.dylib       | Függőség: grafikus alrendszer implementáció macOS ARM64 (AArch64)   |

Az Aspose.Slides.dll a rendszertől függő könyvtárat használja, amelyre a futtatási környezetnek szüksége van. A könyvtárak általában ugyanabban a helyen találhatók, mint az Aspose.Slides.dll bármely fájlrendszerben.

### **ZIP csomag felépítése**

A ZIP csomag a következő könyvtárstruktúrát tartalmazza:

  Aspose.Slides

  ├─── net6.0

  │  ├─── crossplatform

  │  └─── default

  ├─── net20

  ├─── net462

  └─── netstandard2.0

* Minden mappa a megfelelő .NET verzióhoz tartozó összeállításokat tartalmazza. A net6.0 esetén két változat létezik: default és crossplatform. Az utóbbi a platformfüggetlen Aspose.Slides.dll-t és összes függőségét tartalmazza. Ennek a mappának a kibontott tartalma függőségként hozzáadható egy projekthez a platformfüggetlen fejlesztéshez és más Aspose.Slides használati esetekhez.

## **Lásd még**

- [Rendszerkövetelmények](/slides/hu/net/system-requirements/)