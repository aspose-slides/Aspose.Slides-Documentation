---
title: Aspose.Slides for .NET 6 Cross-Platform (ZIP csomag)
type: docs
weight: 237
url: /hu/net/slides-for-net-6-cross-platform-zip-package/
keywords:
- keresztplatformos
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
description: "Az Aspose.Slides for .NET 6 használatával olyan keresztplatformos C# alkalmazásokat építhet Windows, Linux és macOS rendszeren, amelyek PowerPoint PPT, PPTX és ODP fájlokat hoznak létre, szerkesztenek és konvertálnak."
---
## **Áttekintés**

Ez a cikk elmagyarázza, hogyan kell használni az Aspose.Slides for .NET 6 Cross-Platform verziót egy ZIP csomagból. Leírja, hogyan tölthető le a csomag, hogyan csomagolható ki a `net6.0/crossplatform` mappából, hogyan adható hozzá hivatkozás az `Aspose.Slides.dll`-hez, és hogyan konfigurálható a projektfájl annak érdekében, hogy a szükséges függő könyvtárak a program kimeneti könyvtárába másolódjanak.

A cikk továbbá ismerteti a cross‑platform csomag tartalmát, beleértve a fő Aspose.Slides .NET összeállítást és a platform‑specifikus grafikai alrendszer‑könyvtárakat Windows, Linux és macOS rendszerekhez.

{{% alert title="Megjegyzés" color="primary" %}}

Az Aspose.Slides for .NET 6 Cross-Platform verzió elérhető a [NuGet](https://www.nuget.org/packages/Aspose.Slides.NET6.CrossPlatform) oldaláról is.

{{% /alert %}}

## **Az Aspose.Slides Cross‑Platform használata ZIP csomagból**

1. Töltse le a legújabb Aspose.Slides ZIP csomagját a [Release Page](https://releases.aspose.com/slides/hu/net/) oldalról. 

2. Csomagolja ki a *Aspose.Slides.zip\Aspose.Slides\net6.0\crossplatform* mappából a fájlokat, és helyezze őket abba a mappába, amelyet a projekt függőségeihez fog használni.

3. Adjon hozzá hivatkozást az Aspose.Slides.dll-hez.

   ![add-project-reference-visual-studio](add-project-reference-visual-studio.png)

   A példánkban (lent) a könyvtárak a projekt mappájában a következő úton találhatók: *ConsoleApp\libs\Aspose.Slides\net6.0\crossplatform\...*

   ![browse-console-app](browse-console-app.jpg)

4. Helyezze a fennmaradó fájlokat (amelyekre az Aspose.Slides-nek szüksége van) a kimeneti könyvtárba, a csproj projektfájlba a következő módon utasításokat adva:

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

   Alapértelmezés szerint a `<CopyToOutputDirectory>` másolja a fájlokat a relatív útvonaluk megtartásával, azonban szükségünk van arra, hogy a függő könyvtárak ugyanabba a mappába kerüljenek, ahol a kimenet keletkezik (az Aspose.Slides.dll helye).

## **Megjegyzések**

### **Proprietáris grafikai alrendszer**

Az Aspose.Slides cross‑platform egy könyvtárgyűjtemény:

| Aspose.Slides.dll                                          | A fő .NET összeállítás, amely minden Aspose.Slides logikáért felelős |
| ---------------------------------------------------------- | ------------------------------------------------------------------- |
| aspose.slides.drawing.capi_vc14x64.dll                     | Függőség: grafikai alrendszer‑implementáció Win x64 számára          |
| aspose.slides.drawing.capi_vc14x86.dll                     | Függőség: grafikai alrendszer‑implementáció Win x86 számára          |
| libaspose.slides.drawing.capi_x86_64_libstdcpp_libc2.23.so | Függőség: grafikai alrendszer‑implementáció Linux (x86/x64) számára |
| libaspose.slides.drawing.capi_appleclang_x86_64.dylib      | Függőség: grafikai alrendszer‑implementáció macOS AMD64 (x86-64/x64) számára |
| libaspose.slides.drawing.capi_appleclang_arm64.dylib       | Függőség: grafikai alrendszer‑implementáció macOS ARM64 (AArch64) számára |

Az Aspose.Slides.dll a rendszer által megkövetelt könyvtárat használja. A könyvtárak általában ugyanabban a helyen találhatók, mint az Aspose.Slides.dll bármely fájlrendszeren.

### **ZIP csomag felépítése**

A ZIP csomag a következő mappaszerkezetet tartalmazza:

  Aspose.Slides

  ├─── net6.0

  │  ├─── crossplatform

  │  └─── default

  ├─── net20

  ├─── net462

  └─── netstandard2.0

* Minden mappa a megfelelő .NET verzióhoz tartozó összeállításokat tartalmazza. A net6.0-hoz két verzió van: default és crossplatform. Az utóbbi a cross‑platform Aspose.Slides.dll‑t és minden függőségét tartalmazza. Ennek a mappának a kibontott tartalma függőségként hozzáadható egy projekthez a cross‑platform fejlesztéshez és egyéb Aspose.Slides használati esetekhez.

## **Lásd még**

- [Rendszerkövetelmények](/slides/hu/net/system-requirements/)