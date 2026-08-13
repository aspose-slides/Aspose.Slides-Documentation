---
title: Aspose.Slides för .NET 6 plattformsoberoende (ZIP-paket)
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
- namnkonflikt
- extern alias
- CS0433
- PowerPoint
- OpenDocument
- presentation
- .NET
- C#
- Aspose.Slides
description: "Använd Aspose.Slides för .NET 6 för att bygga plattformsoberoende C#‑appar på Windows, Linux och macOS som skapar, redigerar och konverterar PowerPoint‑filer i PPT, PPTX och ODP‑format."
---
## **Översikt**

Den här artikeln förklarar hur du använder Aspose.Slides för .NET 6 Cross-Platform från ett ZIP‑paket. Den beskriver hur du laddar ner paketet, packar upp filerna från `net6.0/crossplatform`‑mappen, lägger till en referens till `Aspose.Slides.dll` och konfigurerar projektfilen så att de nödvändiga beroende‑biblioteken kopieras till applikationens utdata‑katalog.

Artikeln beskriver också innehållet i det plattformsoberoende paketet, inklusive huvud‑Aspose.Slides‑.NET‑assemblyn och plattforms‑specifika grafik‑underdelsbibliotek för Windows, Linux och macOS.

{{% alert title="Obs" color="info" %}}

Aspose.Slides för .NET 6 Cross-Platform finns också tillgänglig via [NuGet](https://www.nuget.org/packages/Aspose.Slides.NET6.CrossPlatform).

{{% /alert %}}

## **Använda den plattformsoberoende Aspose.Slides från ett ZIP‑paket**

1. Ladda ner ZIP‑paketet med den senaste Aspose.Slides från [Release Page](https://releases.aspose.com/slides/sv/net/).

2. Packa upp filerna från *Aspose.Slides.zip\Aspose.Slides\net6.0\crossplatform* och placera dem i den mapp som ska användas för beroenden i ditt projekt.

3. Lägg till en referens till Aspose.Slides.dll.

   ![add-project-reference-visual-studio](add-project-reference-visual-studio.png)

   I vårt exempel (nedan) finns biblioteken i projektmappen enligt följande sökväg: *ConsoleApp\libs\Aspose.Slides\net6.0\crossplatform\...*

   ![browse-console-app](browse-console-app.jpg)

4. Placera de återstående filerna (som Aspose.Slides är beroende av) i utdata‑katalogen genom att lägga till instruktioner i csproj‑projektfilen på följande sätt:

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

5. Uppmärksamma `TargetPath`.

   Som standard kopierar `<CopyToOutputDirectory>` filer och bevarar deras relativa sökväg, men vi behöver att de beroende biblioteken placeras i samma mapp där utdata genereras (Aspose.Slides.dll‑platsen).

## **Anmärkningar**

### **Proprietärt grafikundersystem**

Aspose.Slides Cross‑Platform är en samling bibliotek:

| Aspose.Slides.dll                                          | Huvud-.NET‑assembly som ansvarar för all Aspose.Slides‑logik                 |
| ---------------------------------------------------------- | -------------------------------------------------------------------------- |
| aspose.slides.drawing.capi_vc14x64.dll                     | Beroende: grafiskt undersystemimplementation för Win x64                  |
| aspose.slides.drawing.capi_vc14x86.dll                     | Beroende: grafiskt undersystemimplementation för Win x64                  |
| libaspose.slides.drawing.capi_x86_64_libstdcpp_libc2.23.so | Beroende: grafiskt undersystemimplementation för Linux (x86/x64)          |
| libaspose.slides.drawing.capi_appleclang_x86_64.dylib      | Beroende: grafiskt undersystemimplementation för macOS AMD64 (x86-64/x64) |
| libaspose.slides.drawing.capi_appleclang_arm64.dylib       | Beroende: grafiskt undersystemimplementation för macOS ARM64 (AArch64)    |

Aspose.Slides.dll använder det bibliotek som systemet det kör på kräver. Biblioteken ligger vanligtvis på samma plats som Aspose.Slides.dll i filsystemet.

### **ZIP‑paketstruktur**

ZIP‑paketet innehåller följande mappstruktur:

Aspose.Slides
├─── net6.0
│  ├─── crossplatform
│  └─── default
├─── net20
├─── net462
└─── netstandard2.0

* Varje mapp innehåller assemblies för motsvarande .NET‑version. Det finns två versioner för net6.0: default och crossplatform. Den senare innehåller den plattformsoberoende Aspose.Slides.dll och alla dess beroenden. Det uppackade innehållet i denna mapp kan användas som ett beroende i ett projekt för plattformsoberoende utveckling och andra Aspose.Slides‑användningsfall.

## **Se även**

- [Systemkrav](/slides/sv/net/system-requirements/)