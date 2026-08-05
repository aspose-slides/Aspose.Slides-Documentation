---
title: Aspose.Slides för .NET 6 Cross-Platform (ZIP-paket)
type: docs
weight: 237
url: /sv/net/slides-for-net-6-cross-platform-zip-package/
aliases:
  - /net/slides-for-net-6-cross-platform/
keywords:
- plattformsoberoende
- .NET 6
- GLIBC
- csproj
- målsökväg
- beroende bibliotek
- Aspose.Slides.dll
- System.Drawing.Common
- namnkollision
- extern alias
- CS0433
- PowerPoint
- OpenDocument
- presentation
- .NET
- C#
- Aspose.Slides
description: "Använd Aspose.Slides för .NET 6 för att skapa plattformsoberoende C#-appar på Windows, Linux och macOS som skapar, redigerar och konverterar PowerPoint PPT, PPTX och ODP-filer."
---
## **Översikt**

Denna artikel förklarar hur man använder Aspose.Slides för .NET 6 Cross-Platform från ett ZIP-paket. Den beskriver hur man laddar ner paketet, packar upp filerna från mappen `net6.0/crossplatform`, lägger till en referens till `Aspose.Slides.dll` och konfigurerar projektfilen så att de nödvändiga beroendebiblioteken kopieras till programmets utdata-katalog.

Artikeln beskriver också innehållet i cross-platform-paketet, inklusive huvud-assemblyn för Aspose.Slides .NET samt plattforms-specifika grafik-underdelsbibliotek för Windows, Linux och macOS.

{{% alert title="Note" color="primary" %}}
Aspose.Slides för .NET 6 Cross-Platform finns också tillgängligt via [NuGet](https://www.nuget.org/packages/Aspose.Slides.NET6.CrossPlatform).
{{% /alert %}}

## **Använda Cross-Platform Aspose.Slides från ett ZIP-paket**

1. Ladda ner ZIP-paketet för den senaste versionen av Aspose.Slides från [Release-sidan](https://releases.aspose.com/slides/sv/net/). 

2. Packa upp filerna från *Aspose.Slides.zip\Aspose.Slides\net6.0\crossplatform* och placera dem i den mapp som kommer att användas för beroenden i ditt projekt.

3. Lägg till en referens till Aspose.Slides.dll.

   ![add-project-reference-visual-studio](add-project-reference-visual-studio.png)

   I vårt exempel (nedan) finns biblioteken i projektmappen på följande sökväg: *ConsoleApp\libs\Aspose.Slides\net6.0\crossplatform\...*

   ![browse-console-app](browse-console-app.jpg)

4. Placera de återstående filerna (som Aspose.Slides är beroende av) i utmatningskatalogen genom att lägga till instruktioner i csproj‑projektfilen på följande sätt:

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

5. Var uppmärksam på `TargetPath`. 

   Som standard kopierar `<CopyToOutputDirectory>` filer samtidigt som den bevarar deras relativa sökväg, men vi behöver att de beroende biblioteken placeras i samma mapp där utdata genereras (platsen för Aspose.Slides.dll).

## **Anteckningar**

### **Proprietärt grafikunderdelsystem**

Aspose.Slides cross-platform är en samling bibliotek:

| Aspose.Slides.dll                                          | Huvudsaklig .NET-assembly som ansvarar för all Aspose.Slides-logik |
| ---------------------------------------------------------- | ------------------------------------------------------------------- |
| aspose.slides.drawing.capi_vc14x64.dll                     | Beroende: grafik-underdelsystemimplementation för Win x64          |
| aspose.slides.drawing.capi_vc14x86.dll                     | Beroende: grafik-underdelsystemimplementation för Win x64          |
| libaspose.slides.drawing.capi_x86_64_libstdcpp_libc2.23.so | Beroende: grafik-underdelsystemimplementation för Linux (x86/x64) |
| libaspose.slides.drawing.capi_appleclang_x86_64.dylib      | Beroende: grafik-underdelsystemimplementation för macOS AMD64 (x86-64/x64) |
| libaspose.slides.drawing.capi_appleclang_arm64.dylib       | Beroende: grafik-underdelsystemimplementation för macOS ARM64 (AArch64) |

Aspose.Slides.dll använder det bibliotek som systemet den körs på kräver. Biblioteken finns vanligtvis på samma plats som Aspose.Slides.dll i alla filsystem.

### **ZIP-paketstruktur**

ZIP-paketet innehåller följande mappstruktur:

  Aspose.Slides

  ├─── net6.0

  │  ├─── crossplatform

  │  └─── default

  ├─── net20

  ├─── net462

  └─── netstandard2.0

* Varje mapp innehåller assemblys för motsvarande .NET-version. Det finns två versioner för net6.0: default och crossplatform. Den senare innehåller den cross-platform-Aspose.Slides.dll och alla dess beroenden. Det uppackade innehållet i denna mapp kan användas som ett beroendetillägg i ett projekt för cross-platform-utveckling och andra Aspose.Slides-användningsfall.

## **Se även**

- [Systemkrav](/slides/sv/net/system-requirements/)